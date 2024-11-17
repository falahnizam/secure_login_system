using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace login
{
    public static class mdiProperties
    {
        // Import the required user32.dll methods
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Constants
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;  
        private const uint SWP_NOZORDER = 0x0004; 
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_NOOWNERZORDER = 0x0200;

        // Method to set the bevel (3D border effect) for MDI client area
        public static bool SetBevel(this Form form, bool show)
        {
            // Loop through controls in the form to find the MdiClient
            foreach (Control control in form.Controls)
            {
                MdiClient client = control as MdiClient;
                if (client != null)
                {
                    // Get the current extended window style
                    int windowLong = GetWindowLong(client.Handle, GWL_EXSTYLE);

                    // Modify the style based on the `show` parameter
                    if (show)
                    {
                        windowLong |= WS_EX_CLIENTEDGE;  // Add bevel
                    }
                    else
                    {
                        windowLong &= ~WS_EX_CLIENTEDGE; // Remove bevel
                    }

                    // Apply the new style
                    SetWindowLong(client.Handle, GWL_EXSTYLE, windowLong);

                    // Update the window's appearance
                    SetWindowPos(client.Handle, IntPtr.Zero, 0, 0, 0, 0,
                                 SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
                                 SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

                    return true; // Successfully set bevel
                }
            }

            // No MdiClient was found
            return false;
        }
    }
}
