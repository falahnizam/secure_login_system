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
        private BindingSource bindingSource;
        public formRegistration()
        {
            InitializeComponent();
            accountService = new AccountService();
            bindingSource = new BindingSource();
        }

        

        private void btnLoadData_Click_1(object sender, EventArgs e)
        {
            try
            {
                // returns the object of the DBconnection class
                DBconnection dBconnection = DBconnection.getInstanceOfDBconnection();
                DataSet dsUserDetails = dBconnection.ExecuteQuery("Select * from UserDetails");
                dgvRegistration.DataSource = dsUserDetails.Tables[0];
                bindingSource.DataSource = dsUserDetails.Tables[0];
                // Bind the DataGridView to the BindingSource
                dgvRegistration.DataSource = bindingSource;

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error applying sort: {ex.Message}");
            }
            
        }

        private void dgvRegistration_SortStringChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the current sort string from the DataGridView
                string sortString = dgvRegistration.SortString;

                // If no sorting is applied, clear the sorting
                if (string.IsNullOrEmpty(sortString))
                {
                    return; // Do nothing if no sort is applied
                }

                // Apply the sort string to the BindingSource (DataTable's DefaultView)
                DataTable dataTable = (DataTable)bindingSource.DataSource;
                if (dataTable != null)
                {
                    dataTable.DefaultView.Sort = sortString; // Apply sorting based on the SortString
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying sort: {ex.Message}");
            }

        }

        private void dgvRegistration_FilterStringChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the current filter string from the DataGridView
                string filterString = dgvRegistration.FilterString;

                // Apply the filter string to the BindingSource
                if (bindingSource != null)
                {
                    bindingSource.Filter = filterString; // Apply filter to the BindingSource
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error applying filter: {ex.Message}");
            }


        }

        
        
    }
}
