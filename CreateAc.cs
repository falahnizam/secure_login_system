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
            string username = UserName.Text;
            string password = Password.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            DateTime dob = dateTimePicker1.Value;
            string gender = CBRGender.SelectedItem?.ToString(); // Get selected gender from ComboBox

            // Validate user input before calling the account creation service
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(gender))  // Check if gender is selected
            {
                MessageBox.Show("Please fill in all fields before creating an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int age = CalculateAge(dob);

            // Ensure the user is at least 13 years old
            if (age < 13)
            {
                MessageBox.Show("You must be at least 13 years old to create an account.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the process if the user is younger than 13
            }

            // Now pass these values into the CreateAccount method
            bool accountCreated = accountService.CreateAccount(username, password, firstName, lastName, dob, gender); // Pass gender

            if (accountCreated)
            {
                MessageBox.Show("Account created successfully!");
                this.Hide();

                // Show the login form
                pnLogin loginForm = new pnLogin();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Failed to create account.");
            }
        }

        private int CalculateAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;

            // If the user hasn't had their birthday this year yet, subtract 1 from the age
            if (DateTime.Now.Date < dob.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private void parrotButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            // Close the Create Account Form

            // Show the login form
            pnLogin loginForm = new pnLogin();
            loginForm.Show();

        }

        private void CBRGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateAc_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with gender options
            CBRGender.Items.Add("Male");
            CBRGender.Items.Add("Female");
            CBRGender.Items.Add("Other");

            // Optionally, set the default selection
            CBRGender.SelectedIndex = 0;
        }
    }
}
