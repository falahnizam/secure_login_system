﻿using System;
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
    public partial class pnLogin : Form
    {
        private AccountService accountService;
        private EventMenuContainer dashboardUser;

        public pnLogin()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void SignIn_Click_1(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            // Validate user input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call the AuthenticateUser method
            var result = accountService.AuthenticateUser(username, password);

            // Check if authentication was successful
            if (result.IsAuthenticated)
            {
                MessageBox.Show("Login Successful");

                // Role-based redirection
                if (result.RoleID == 1) // Admin role
                {
                    // Open Admin Dashboard
                    AdminDashBoard adminDashboard = new AdminDashBoard();
                    adminDashboard.Show();
                    this.Hide(); // Hide the login form
                }
                else if (result.RoleID == 2) // Regular user role
                {
                    // Open User Dashboard
                    EventMenuContainer userDashboard = GetUserDashboard(result);
                    userDashboard.Show();
                    this.Hide(); // Hide the login form
                }
                else if (result.RoleID == 4) // Pending role
                {
                    MessageBox.Show("Your account is pending approval. Please contact an administrator.", "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your account role is not recognized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to get the User Dashboard
        private static EventMenuContainer GetUserDashboard(AccountService.UserAuthenticationResult result)
        {
            return new EventMenuContainer(result.UserID);

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            CreateAc createAccountForm = new CreateAc();
            createAccountForm.FormClosed += (s, args) => this.Show();  // Show login form again when CreateAc form is closed
            createAccountForm.Show();
            this.Hide();
        }

        private void hidebtn_Click(object sender, EventArgs e)
        {

            if (txtPassword.PasswordChar == '*')
            {
                unHidebtn.BringToFront();
                txtPassword.PasswordChar = '\0';
            }

        }

        private void unHidebtn_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                hidebtn.BringToFront();
                txtPassword.PasswordChar = '*';
            }

        }
    }
}
