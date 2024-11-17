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
    public partial class formRegistration : Form
    {
        private AccountService accountService;
        public formRegistration()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void formRegistration_Load(object sender, EventArgs e)
        {
            LoadPendingUsers();

        }
        private void LoadPendingUsers()
        {
            try
            {
                // Get the list of pending users
                DataSet pendingUsers = accountService.GetPendingUsers();

                // Clear any existing rows in the DataGridView
                dgvPendingUsers.Rows.Clear();

                // Loop through the data and add rows to DataGridView
                foreach (DataRow row in pendingUsers.Tables[0].Rows)
                {
                    // Add the user data into DataGridView
                    dgvPendingUsers.Rows.Add(row["UserID"], row["FirstName"], row["LastName"], row["DOB"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending users: {ex.Message}");
            }
        }

    }
}
