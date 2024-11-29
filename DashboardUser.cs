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
    public partial class DashboardUser : Form
    {
        formProfile profile;
        public DashboardUser()
        {
            InitializeComponent();

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
        bool eventExpand = false;
        private void eventTransition_Tick(object sender, EventArgs e)
        {
            if (eventExpand == false)
            {
                EventContainer.Height += 10;
                if(EventContainer.Height >= 120)
                {
                    eventTransition.Stop();
                    eventExpand = true;
                }
            }
            else
            {
                EventContainer.Height -= 10;
                //event height = 55
                if (EventContainer.Height <= 55)
                {
                    eventTransition.Stop();
                    eventExpand = false;

                }
            }
        }
        

        bool sidebarExpand = true; // Indicates whether the sidebar is currently expanded or collapsed

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            // If the sidebar is expanded, we want to collapse it
            if (sidebarExpand)
            {
                sidebar.Width -= 22; // Decrease the width by 10px every tick (i.e., collapsing)
                if (sidebar.Width <= 72) // When the sidebar reaches 72px width, stop collapsing
                {
                    sidebarExpand = false; // The sidebar is now fully collapsed
                    sidebarTransition.Stop(); // Stop the timer to stop the animation
                }
            }
            else // If the sidebar is collapsed, we want to expand it
            {
                sidebar.Width += 22; // Increase the width by 10px every tick 
                if (sidebar.Width >=158) // When the sidebar reaches 220px width, stop expanding
                {
                    sidebarExpand = true; // The sidebar is now fully expanded
                    sidebarTransition.Stop(); // Stop the timer to stop the animation

                    pnDashboard.Width = sidebar.Width;
                    pnChat.Width = sidebar.Width;
                    pnDigitalContent.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    pnProfile.Width = sidebar.Width;
                    pnMembership.Width = sidebar.Width;
                    EventContainer.Width = sidebar.Width;
                }
            }
        }


        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void EventsMenu_Click_1(object sender, EventArgs e)
        {
            eventTransition.Start();
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            var confirmationResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                // Close the current Admin Dashboard form
                this.Close();
                // Hide the User Dashboard

                // Show the login form
                pnLogin loginForm = new pnLogin();
                loginForm.Show();

            }
        }

        private void DashboardUser_Load(object sender, EventArgs e)
        {
            // Apply MDI properties when the dashboard loads
            mdiprop();

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (profile == null || profile.IsDisposed)
            {

                formProfile formProfile = new formProfile();
                profile = formProfile;  // Create a new instance of the form
                profile.FormClosed += Dashboard_FormClosed;  // Subscribe to FormClosed event
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

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }
    }
}
