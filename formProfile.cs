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
using System.IO;

namespace login
{
    public partial class formProfile : Form
    {
        private int userId;
        private DBconnection db;

        public formProfile(int userId)
        {

            InitializeComponent();
            this.userId = userId;
            db = DBconnection.getInstanceOfDBconnection();
            // Initialize user ID from the logged-in session
            LoadProfileDetails();  // Load the user profile when the form loads

            
        }



        private void LoadProfileDetails()
        {

            // SQL query to fetch user details based on userId
            string query = "SELECT FirstName, LastName, DOB, Bio, ProfileImagePath, Gender, CreatedAt  FROM UserDetails WHERE UserID = @UserID";

            SqlParameter[] parameters = {
        new SqlParameter("@UserID", userId)  // Ensure userId is being passed correctly
    };

            DataSet profileData = db.ExecuteQuery(query, parameters);  // Execute the query and get the result

            // Check if the query returned any data
            if (profileData != null && profileData.Tables.Count > 0 && profileData.Tables[0].Rows.Count > 0)
            {
                var row = profileData.Tables[0].Rows[0];  // Get the first row of the first table

                // Populate the UI controls with data from the query
                FirstName.Text = row["FirstName"].ToString();
                LastName.Text = row["LastName"].ToString();

                DateTime dob;
                if (DateTime.TryParse(row["DOB"].ToString(), out dob))
                {
                    DOB.Text = dob.ToString("yyyy-MM-dd");
                    DOB.ReadOnly = true;
                }
                else
                {
                    DOB.Text = string.Empty;
                }

                txtBio.Text = row["Bio"].ToString();

                string gender = row["Gender"].ToString();
                Gender.Text = gender;
                Gender.ReadOnly = true;

                DateTime createdAt;
                if (DateTime.TryParse(row["CreatedAt"].ToString(), out createdAt))
                {
                    Joined.Text = createdAt.ToString("yyyy-MM-dd");  // Assuming txtJoined is the TextBox to show the joined date
                }
                else
                {
                    Joined.Text = string.Empty;
                }

                // Safely handle ProfileImagePath
                string imageLocation = row["ProfileImagePath"] != DBNull.Value ? row["ProfileImagePath"].ToString() : string.Empty;

                if (!string.IsNullOrEmpty(imageLocation))
                {
                    // Retrieve the image from Local AppData
                    string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp", "ProfileImages");
                    string imageFilePath = Path.Combine(appDataPath, imageLocation);  // Assuming 'imageLocation' stores the filename

                    if (File.Exists(imageFilePath))
                    {
                        Image1.ImageLocation = imageFilePath;  // Display the image
                    }
                    else
                    {
                        Image1.Image = null;  // Handle case where no image is available
                    }
                }
                else
                {
                    Image1.Image = null;  // Handle case where no image path is stored
                }
            }
            else
            {
                // Handle the case when no data is returned
                MessageBox.Show("No profile data found for this user.");
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
                        // Set AppData folder path (LocalApplicationData)
                        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApp", "ProfileImages");

                        // Ensure the directory exists
                        if (!Directory.Exists(appDataPath))
                        {
                            Directory.CreateDirectory(appDataPath);
                        }

                        // Generate a unique filename using userId (or a hash if needed)
                        string imageFileName = $"{userId}_{Guid.NewGuid()}.jpg";  // Unique filename (using GUID)
                        string newImagePath = Path.Combine(appDataPath, imageFileName);

                        // Log the path for debugging
                        MessageBox.Show("Saving image to: " + newImagePath);  // Debugging step

                        // Save the image to the AppData folder
                        File.Copy(imageLocation, newImagePath, true);  // true allows overwriting if the file already exists

                        // Set the image to PictureBox (Image1)
                        Image1.ImageLocation = newImagePath;

                        // Optionally store the image path in the database (if needed)
                        // Save the new image path to your database if necessary
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
            string firstName = FirstName.Text; // FirstName TextBox
            string lastName = LastName.Text;  // LastName TextBox

            DateTime dob;
            if (!DateTime.TryParse(DOB.Text, out dob))
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
