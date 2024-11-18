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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // returns the object of the DBconnection class
            DBconnection dBconnection = DBconnection.getInstanceOfDBconnection();
            DataSet dsUserDetails = dBconnection.ExecuteQuery("Select * from UserDetails");
            dgvRegistration.DataSource = dsUserDetails.Tables[0];
        }
    }
}
