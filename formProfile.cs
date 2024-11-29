using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class formProfile : Form
    {
        private int userId;
        private DBconnection db;

        public formProfile(int userId)
        {

            InitializeComponent();
            this.userId = userId;  // Initialize user ID from the logged-in session
            LoadProfileDetails();  // Load the user profile when the form loads

            db = DBconnection.getInstanceOfDBconnection();
        }


        private void LoadProfileDetails()
        {
            string query = "SELECT FirstName, LastName, DOB, Bio, ProfileImagePath FROM UserDetails WHERE UserID = @UserID";

            SqlParameter[] parameters = {
            new SqlParameter("@UserID", userId)
        };

            DataSet profileData = db.ExecuteQuery(query, parameters);

            if (profileData.Tables[0].Rows.Count > 0)
            {
                var row = profileData.Tables[0].Rows[0];

                // Assuming aloneTextBox1 is for FirstName
                aloneTextBox1.Text = row["FirstName"].ToString();
                // Assuming aloneTextBox2 is for LastName
                aloneTextBox2.Text = row["LastName"].ToString();

                // Fill the DOB (date of birth) field
                DateTime dob = Convert.ToDateTime(row["DOB"]);
                aloneTextBox4.Text = dob.ToString("yyyy-MM-dd");

                // Fill the Bio
                txtBio.Text = row["Bio"].ToString();

                // Load the profile image if a path exists
                string imageLocation = row["ProfileImagePath"].ToString();
                if (!string.IsNullOrEmpty(imageLocation))
                {
                    Image1.ImageLocation = imageLocation;
                }
            }
        }

        private void Image1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg;*.png)|*.jpg;*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = openFileDialog.FileName;

                    if (!string.IsNullOrEmpty(imageLocation))
                    {
                        // Set the selected image to the PictureBox
                        Image1.ImageLocation = imageLocation;
                    }
                }
                else
                {
                    MessageBox.Show("No file selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string firstName = aloneTextBox1.Text; // FirstName TextBox
            string lastName = aloneTextBox2.Text;  // LastName TextBox

            DateTime dob;
            if (!DateTime.TryParse(aloneTextBox4.Text, out dob))
            {
                MessageBox.Show("Please enter a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string bio = txtBio.Text;
            string imageLocation = Image1.ImageLocation;

            // Validate fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(bio) || string.IsNullOrEmpty(imageLocation))
            {
                MessageBox.Show("Please fill out all fields and select a profile picture.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL Update query
            string updateQuery = @"UPDATE UserDetails
                           SET FirstName = @FirstName, LastName = @LastName, DOB = @DOB, 
                               Bio = @Bio, ProfileImagePath = @ProfileImagePath
                           WHERE UserID = @UserID";

            SqlParameter[] updateParams = {
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@DOB", dob),
            new SqlParameter("@Bio", bio),
            new SqlParameter("@ProfileImagePath", imageLocation),
            new SqlParameter("@UserID", userId)
        };

            int rowsAffected = db.ExecuteNonQuery(updateQuery, updateParams);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Profile updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update profile.");
            }
        }
    }

}
