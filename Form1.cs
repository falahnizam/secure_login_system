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
    public partial class pnLogin : Form
    {
        private AccountService accountService;
        private DashboardUser dashboardUser;
        public pnLogin()
        {
            InitializeComponent();
            accountService = new AccountService(); 
        }

        private void SIGN_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignIn_Click(object sender, EventArgs e)
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
            bool isAuthenticated = accountService.AuthenticateUser(username, password);
            if (isAuthenticated)
            {
                MessageBox.Show("Login Successful");
                // Optionally, you can navigate to the DashboardUser here
                DashboardUser dashboardUser = new DashboardUser();
                dashboardUser.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            CreateAc createAccountForm = new CreateAc();
            createAccountForm.Show();
            this.Hide();
        }
    }

}