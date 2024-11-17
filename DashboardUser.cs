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
        bool eventExpand = false;
        private void eventTransition_Tick(object sender, EventArgs e)
        {
            if (eventExpand == false)
            {
                EventContainer.Height += 10;
                if(EventContainer.Height >= 120)
                {
                    eventTransition.Stop();
                    eventExpand = true;
                }
            }
            else
            {
                EventContainer.Height -= 10;
                //event height = 55
                if (EventContainer.Height <= 55)
                {
                    eventTransition.Stop();
                    eventExpand = false;

                }
            }
        }
        

        bool sidebarExpand = true; // Indicates whether the sidebar is currently expanded or collapsed

        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            // If the sidebar is expanded, we want to collapse it
            if (sidebarExpand)
            {
                sidebar.Width -= 22; // Decrease the width by 10px every tick (i.e., collapsing)
                if (sidebar.Width <= 72) // When the sidebar reaches 72px width, stop collapsing
                {
                    sidebarExpand = false; // The sidebar is now fully collapsed
                    sidebarTransition.Stop(); // Stop the timer to stop the animation
                }
            }
            else // If the sidebar is collapsed, we want to expand it
            {
                sidebar.Width += 22; // Increase the width by 10px every tick 
                if (sidebar.Width >=158) // When the sidebar reaches 220px width, stop expanding
                {
                    sidebarExpand = true; // The sidebar is now fully expanded
                    sidebarTransition.Stop(); // Stop the timer to stop the animation

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

        private void EventsMenu_Click_1(object sender, EventArgs e)
        {
            eventTransition.Start();
        }
    }
}
