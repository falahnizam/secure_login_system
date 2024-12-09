using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class EventMenuContainer : Form
    {
        private int userId;
        formProfile profile;
        public EventMenuContainer(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void mdiprop()
        {
            // Set the MDI properties (bevel and background color)
            this.SetBevel(false);  // This method is from  mdiProperties static class
            var mdiClient = this.Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(232, 234, 237); // Set the background color
            }
        }

        private void UserDashBoard_Load(object sender, EventArgs e)
        {
            // Apply MDI properties when the dashboard loads
            mdiprop();

        }
        bool registrationExpand = false;

        

        private void panelLogout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventTransition_Tick(object sender, EventArgs e)
        {
            if (registrationExpand == false)
            {
                EventContainer.Height += 10;
                if (EventContainer.Height >= 154)
                {
                    EventTransition.Stop();
                    registrationExpand = true;
                }

            }
            else
            {
                EventContainer.Height -= 10;
                if (EventContainer.Height <= 56)
                {
                    EventTransition.Stop();
                    registrationExpand = false;
                }
            }

        }

        private void btnEventsMenu_Click(object sender, EventArgs e)
        {
            EventTransition.Start();
        }

        bool sidebarExpand = true;

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 22; // Decrease width to collapse
                if (sidebar.Width <= 56)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 22; // Increase width to expand
                if (sidebar.Width >= 254)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    // Adjust child forms’ width when sidebar is expanded
                    pnDashBoardUser.Width = sidebar.Width;
                    pnDigitalContentUser.Width = sidebar.Width;
                    panelLogout.Width = sidebar.Width;
                    pnChatUser.Width = sidebar.Width;
                    pnMembership.Width = sidebar.Width;
                    EventContainer.Width = sidebar.Width;
                    pnPorfileUser.Width = sidebar.Width;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnProfileUser_Click(object sender, EventArgs e)
        {
            if (profile == null || profile.IsDisposed)
            {

                profile = new formProfile(userId);  // Create a new instance of the form
                profile.FormClosed += profile_FormClosed;  // Subscribe to FormClosed event
                profile.MdiParent = this;  // Set the MDI parent
                profile.WindowState = FormWindowState.Maximized;
                profile.ControlBox = false;
                profile.Show();  // Show the form
            }
            else
            {
                // If the form is already open, bring it to the front
                profile.Activate();
                profile.WindowState = FormWindowState.Maximized;
            }
        }

        private void profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            var confirmationResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                // Close the current Admin Dashboard form
                this.Hide();
                // Hide the Admin Dashboard

                // Show the login form
                pnLogin loginForm = new pnLogin();
                loginForm.Show();
            }
        }
    }
}
