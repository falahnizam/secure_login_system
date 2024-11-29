using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace login
{
    public partial class PendingUsers : Form
    {
        private AccountService accountService;
        private BindingSource bindingSource;
        private List<string> roles;
        public PendingUsers()
        {
            InitializeComponent();
            accountService = new AccountService();
            bindingSource = new BindingSource();
            roles = new List<string> { "User", "Admin" };

            // Bind the ComboBox to the list of roles
            comboBoxRole.DataSource = roles;

        }

        private void dgvPendingUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPendingUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPendingUsers.SelectedRows[0];
                // Check if the value is DBNull before trying to cast it to Int32
                if (row.Cells["UserID"].Value != DBNull.Value)
                {
                    int selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value); // Get UserID
                    txtSelectedUserID.Text = selectedUserId.ToString(); // Display UserID
                }
                else
                {
                    MessageBox.Show("Selected user has no valid UserID.");
                }
            }

        }


        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadPendingUsers_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the list of pending users (RoleID = 4)
                DataSet dsPendingUsers = accountService.GetPendingUsers();
                bindingSource.DataSource = dsPendingUsers.Tables[0];
                dgvPendingUsers.DataSource = bindingSource; // Bind to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending users: {ex.Message}");
            }
        }

        private void btnRejectUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a rejection reason has been provided
                if (string.IsNullOrEmpty(txtRejectionReason.Text))
                {
                    MessageBox.Show("Please provide a reason for rejection.");
                    return;
                }

                // Ensure a user is selected for rejection
                if (string.IsNullOrEmpty(txtSelectedUserID.Text))
                {
                    MessageBox.Show("Please select a user to reject.");
                    return;
                }

                int selectedUserId = Convert.ToInt32(txtSelectedUserID.Text); // Get the selected UserID
                string rejectionReason = txtRejectionReason.Text; // Get the rejection reason from the TextBox

                // Call the RejectUser method from AccountService
                bool success = accountService.RejectUser(selectedUserId, rejectionReason);
                if (success)
                {
                    MessageBox.Show("User rejected successfully.");
                    btnLoadPendingUsers_Click(sender, e); // Reload the list of pending users to reflect changes
                }
                else
                {
                    MessageBox.Show("Error rejecting user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAcceptUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a user is selected
                if (string.IsNullOrEmpty(txtSelectedUserID.Text))
                {
                    MessageBox.Show("Please select a user to authorize.");
                    return;
                }

                // Get the selected UserID from the text box
                int selectedUserId = Convert.ToInt32(txtSelectedUserID.Text);

                // Get the selected role from the ComboBox (convert "User" to RoleID 2 and "Admin" to RoleID 1)
                int newRoleId = comboBoxRole.SelectedItem.ToString() == "Admin" ? 1 : 2;

                // Call the method to update the user's role
                bool success = accountService.AuthorizeUser(selectedUserId, newRoleId);

                if (success)
                {
                    MessageBox.Show("User role updated successfully.");
                    btnLoadPendingUsers_Click(sender, e);  // Reload the list of pending users to reflect changes
                }
                else
                {
                    MessageBox.Show("Error updating user role.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
