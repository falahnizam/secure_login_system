using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class AdminDashBoard : Form
    {
        // Declare variables for child forms
        formDashBoard dashboard;
        formRegistration registration;
        PendingUsers pendingUser;
        formLogout logout;

        public AdminDashBoard()
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

        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            // Apply MDI properties when the dashboard loads
            mdiprop();
        }

        bool registrationExpand = false;
        private void RegistrationMenuTransition_Tick(object sender, EventArgs e)
        {
            if (registrationExpand == false)
            {
                RegistrationMenuContainer.Height += 10;
                if (RegistrationMenuContainer.Height >= 154)
                {
                    RegistrationMenuTransition.Stop();
                    registrationExpand = true;
                }
                
            }else
            {
                RegistrationMenuContainer.Height -= 10;
                if (RegistrationMenuContainer.Height <= 56)
                {
                    RegistrationMenuTransition.Stop();
                    registrationExpand = false;
                }
            }

        }
        private void btnRegistration_Click(object sender, EventArgs e)
        {
            RegistrationMenuTransition.Start();

        }



        bool eventExpand = false;

        // Transition for the event menu
        private void EventTransition_Tick(object sender, EventArgs e)
        {
            if (eventExpand == false)
            {
                EventMenuContainer.Height += 10;
                if (EventMenuContainer.Height >= 190)
                {
                    EventTransition.Stop();
                    eventExpand = true;
                }
            }
            else
            {
                EventMenuContainer.Height -= 10;
                if (EventMenuContainer.Height <= 56)
                {
                    EventTransition.Stop();
                    eventExpand = false;
                }
            }
        }

        // Handle the event button click
        private void Event_Click(object sender, EventArgs e)
        {
            EventTransition.Start();
        }

        bool sidebarExpand = true;

        // Handle sidebar expansion and collapse
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
                    btnDashboard.Width = sidebar.Width;
                    formDigitalContent.Width = sidebar.Width;
                    btnLogout.Width = sidebar.Width;
                    btnRegistration.Width = sidebar.Width;
                    formMembership.Width = sidebar.Width;
                    EventMenuContainer.Width = sidebar.Width;
                    RegistrationMenuContainer.Width = sidebar.Width;
                }
            }
        }

        // Handle the sidebar toggle button click
        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        // Handle Dashboard button click (create and show the form)
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (dashboard == null || dashboard.IsDisposed)
            {
                
                dashboard = new formDashBoard();  // Create a new instance of the form
                dashboard.FormClosed += Dashboard_FormClosed;  // Subscribe to FormClosed event
                dashboard.MdiParent = this;  // Set the MDI parent
                dashboard.WindowState = FormWindowState.Maximized;
                dashboard.ControlBox = false;
                dashboard.Show();  // Show the form
            }
            else
            {
                // If the form is already open, bring it to the front
                dashboard.Activate();
                dashboard.WindowState = FormWindowState.Maximized;
            }
        }


        // Reset the dashboard reference when the form is closed
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }
        
        private void registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            registration = null;
        }

       

        private void btnRegisterd_Click(object sender, EventArgs e)
        {
            try
            {
                if (registration == null || registration.IsDisposed)
                {
                    registration = new formRegistration();
                    registration.FormClosed += registration_FormClosed;
                    registration.MdiParent = this;  // Ensure this form is an MDI child
                    registration.ControlBox = false;
                    registration.WindowState = FormWindowState.Maximized;
                    registration.Show();
                }
                else
                {
                    registration.Activate();
                    registration.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the Registration form: {ex.Message}");
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            try
            {
                if (pendingUser == null || pendingUser.IsDisposed)
                {
                    
                    pendingUser = new PendingUsers();
                    pendingUser.FormClosed += PendingUser_FormClosed;
                    pendingUser.MdiParent = this;
                    pendingUser.ControlBox = false;
                    pendingUser.WindowState = FormWindowState.Maximized;
                    pendingUser.Show();
                }
                else
                {
                    pendingUser.Activate();
                    pendingUser.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the Registration form: {ex.Message}");
            }
        }

        private void PendingUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            pendingUser = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
    
