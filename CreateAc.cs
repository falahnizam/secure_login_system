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
            Email.Text = "";
        }


      

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            DateTime dob = dateTimePicker1.Value;
            string gender = CBRGender.SelectedItem?.ToString(); // Get selected gender from ComboBox
            string email = Email.Text; // Get email from the email TextBox

            // Validate user input before calling the account creation service
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please fill in all fields before creating an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address with a domain name.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if the password is strong enough
            if (CheckPasswordStrength(password) != PasswordStrength.Strong)
            {
                MessageBox.Show("Please use a stronger password. A strong password must include at least 12 characters, uppercase and lowercase letters, numbers, and special characters.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int age = CalculateAge(dob);

            // Ensure the user is at least 13 years old
            if (age < 13)
            {
                MessageBox.Show("You must be at least 13 years old to create an account.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the process if the user is younger than 13
            }

            // Check if the email is already in use
            bool emailExists = accountService.CheckEmailExists(email);
            if (emailExists)
            {
                MessageBox.Show("The email address is already in use. Please use a different email.", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the account creation if the email is already in use
            }
            bool usernameExists = accountService.CheckUserNameExists(username);
            if (usernameExists)
            {
                MessageBox.Show("The username is already in use. Please choose a different username.", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the account creation if the username already exists
            }

            // Now pass these values into the CreateAccount method, including the email
            bool accountCreated = accountService.CreateAccount(username, password, firstName, lastName, dob, gender, email);

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
        private bool IsValidEmail(string email)
        {
            // Regex pattern to check for a valid email format (including domain name)
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }
        public enum PasswordStrength
        {
            Weak,
            Medium,
            Strong
        }
        public PasswordStrength CheckPasswordStrength(string password)
        {
            int score = 0;

            // Length: Add points based on password length
            if (password.Length >= 5) score++;
            if (password.Length >= 9) score++;

            // Uppercase letters
            if (password.Any(char.IsUpper)) score++;

            // Lowercase letters
            if (password.Any(char.IsLower)) score++;

            // Digits
            if (password.Any(char.IsDigit)) score++;

            // Special characters
            if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;

            // Assign strength based on score
            if (score <= 2) return PasswordStrength.Weak;
            else if (score <= 4) return PasswordStrength.Medium;
            else return PasswordStrength.Strong;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            string password = Password.Text;
            PasswordStrength strength = CheckPasswordStrength(password);

            // Display password strength in the label
            switch (strength)
            {
                case PasswordStrength.Weak:
                    lblPasswordStrength.Text = "Weak";
                    lblPasswordStrength.ForeColor = Color.Red;
                    break;
                case PasswordStrength.Medium:
                    lblPasswordStrength.Text = "Medium";
                    lblPasswordStrength.ForeColor = Color.Orange;
                    break;
                case PasswordStrength.Strong:
                    lblPasswordStrength.Text = "Strong";
                    lblPasswordStrength.ForeColor = Color.Green;
                    break;
            }

        }

        private void unHidebtn_Click(object sender, EventArgs e)
        {
            if (Password.PasswordChar == '\0')
            {
                hidebtn.BringToFront();
                Password.PasswordChar = '*';
            }

        }

        private void hidebtn_Click(object sender, EventArgs e)
        {
            if (Password.PasswordChar == '*')
            {
                unHidebtn.BringToFront();
                Password.PasswordChar = '\0';
            }

        }
    }
}
