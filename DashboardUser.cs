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
    public partial class DashboardUser : Form
    {
        public DashboardUser()
        {
            InitializeComponent();
        }
       
        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashboardUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void toggleButton1_ToggledChanged()
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void EventContainer_Paint(object sender, PaintEventArgs e)
        {

        }
        bool eventExpand = false;
        private void eventTransition_Tick(object sender, EventArgs e)
        {
            if (eventExpand == false)
            {
                EventContainer.Height += 10;
                if(EventContainer.Height >= 237)
                {
                    eventTransition.Stop();
                    eventExpand = false;
                }
            }
            else
            {
                EventContainer.Height -= 10;
                //event height = 72
                if (EventContainer.Height <= 75)
                {
                    eventTransition.Stop();
                    eventExpand = false;

                }
            }
        }
        private void EventsMenu_Click(object sender, EventArgs e)
        {
            eventTransition.Start();
        }

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 72 )
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            } else {
                sidebar.Width += 10;
                if (sidebar.Width >= 245) {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnDashboard.Width = sidebar.Width;
                    pnChat.Width = sidebar.Width;
                    pnDigitalContent.Width = sidebar.Width; 
                    pnLogout.Width = sidebar.Width;
                    pnProfile.Width = sidebar.Width;
                    pnMembership.Width = sidebar.Width;
                    EventContainer.Width = sidebar.Width;
                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
    }
}
