using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class CreateAc : Form
    {
       private AccountService accountService;
       public CreateAc()
        {
            InitializeComponent();
            accountService = new AccountService();// initialize backend servive
        }
        // Event Handler for Create "Create account button click "
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearForm()
        {
            UserName.Text = "";
            Password.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            dateTimePicker1.Value = DateTime.Now; // Reset the date picker to the current date
        }


      

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            // Collect the values from the form
            string username = UserName.Text;
            string password = Password.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            DateTime dob = dateTimePicker1.Value;

            // Validate user input before calling the account creation service
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please fill in all fields before creating an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Now pass these values into the CreateAccount method
            AccountService accountService = new AccountService();
            bool accountCreated = accountService.CreateAccount(username, password, firstName, lastName, dob);

            if (accountCreated)
            {
                MessageBox.Show("Account created successfully!");
            }
            else
            {
                MessageBox.Show("Failed to create account.");
            }
        }
    }
}
