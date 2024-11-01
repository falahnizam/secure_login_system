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
            // Collect the values from the form
            string username = textBox5.Text;
            string password = textBox6.Text;
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            DateTime dob = dateTimePicker1.Value;

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

        private void CreateAc_Load(object sender, EventArgs e)
        {

        }
    }
}
