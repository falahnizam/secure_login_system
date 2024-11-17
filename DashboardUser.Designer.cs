namespace login
{
    partial class DashboardUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardUser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnDashboard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnProfile = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.pnMembership = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.pnDigitalContent = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.EventContainer = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.EventsMenu = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.pnChat = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.eventTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pnDashboard.SuspendLayout();
            this.pnProfile.SuspendLayout();
            this.pnMembership.SuspendLayout();
            this.pnDigitalContent.SuspendLayout();
            this.EventContainer.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.pnChat.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.nightControlBox1);
            this.panel1.Controls.Add(this.btnHam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1253, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnHam
            // 
            this.btnHam.BackColor = System.Drawing.Color.Transparent;
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(0, 0);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(55, 39);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHam.TabIndex = 3;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "DashBoard";
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.Controls.Add(this.pnDashboard);
            this.sidebar.Controls.Add(this.pnProfile);
            this.sidebar.Controls.Add(this.pnMembership);
            this.sidebar.Controls.Add(this.pnDigitalContent);
            this.sidebar.Controls.Add(this.EventContainer);
            this.sidebar.Controls.Add(this.pnChat);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.ForeColor = System.Drawing.Color.Black;
            this.sidebar.Location = new System.Drawing.Point(0, 39);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(245, 673);
            this.sidebar.TabIndex = 2;
            // 
            // pnDashboard
            // 
            this.pnDashboard.Controls.Add(this.button1);
            this.pnDashboard.Location = new System.Drawing.Point(3, 3);
            this.pnDashboard.Name = "pnDashboard";
            this.pnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnDashboard.Size = new System.Drawing.Size(246, 75);
            this.pnDashboard.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(-11, -5);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(297, 106);
            this.button1.TabIndex = 1;
            this.button1.Text = "🟰   DashBoard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pnProfile
            // 
            this.pnProfile.Controls.Add(this.button7);
            this.pnProfile.Location = new System.Drawing.Point(3, 84);
            this.pnProfile.Name = "pnProfile";
            this.pnProfile.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnProfile.Size = new System.Drawing.Size(246, 75);
            this.pnProfile.TabIndex = 10;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(-21, -16);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(297, 106);
            this.button7.TabIndex = 1;
            this.button7.Text = "  🙍‍♂️   Profile";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // pnMembership
            // 
            this.pnMembership.Controls.Add(this.button3);
            this.pnMembership.Location = new System.Drawing.Point(3, 165);
            this.pnMembership.Name = "pnMembership";
            this.pnMembership.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnMembership.Size = new System.Drawing.Size(246, 75);
            this.pnMembership.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(-19, -14);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(297, 106);
            this.button3.TabIndex = 1;
            this.button3.Text = "  🫂   Membership";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pnDigitalContent
            // 
            this.pnDigitalContent.Controls.Add(this.button5);
            this.pnDigitalContent.Location = new System.Drawing.Point(3, 246);
            this.pnDigitalContent.Name = "pnDigitalContent";
            this.pnDigitalContent.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnDigitalContent.Size = new System.Drawing.Size(246, 75);
            this.pnDigitalContent.TabIndex = 8;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(-11, -10);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(297, 106);
            this.button5.TabIndex = 1;
            this.button5.Text = " ✨   Digital Content";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // EventContainer
            // 
            this.EventContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.EventContainer.Controls.Add(this.panel10);
            this.EventContainer.Controls.Add(this.panel13);
            this.EventContainer.Controls.Add(this.panel12);
            this.EventContainer.Location = new System.Drawing.Point(3, 327);
            this.EventContainer.Name = "EventContainer";
            this.EventContainer.Size = new System.Drawing.Size(246, 75);
            this.EventContainer.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.EventsMenu);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.panel10.Size = new System.Drawing.Size(246, 75);
            this.panel10.TabIndex = 9;
            // 
            // EventsMenu
            // 
            this.EventsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.EventsMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventsMenu.ForeColor = System.Drawing.Color.White;
            this.EventsMenu.Location = new System.Drawing.Point(-27, -15);
            this.EventsMenu.Name = "EventsMenu";
            this.EventsMenu.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.EventsMenu.Size = new System.Drawing.Size(297, 106);
            this.EventsMenu.TabIndex = 1;
            this.EventsMenu.Text = "    🎆   Events Menu";
            this.EventsMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventsMenu.UseVisualStyleBackColor = false;
            this.EventsMenu.Click += new System.EventHandler(this.EventsMenu_Click_1);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.button11);
            this.panel13.Location = new System.Drawing.Point(0, 136);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.panel13.Size = new System.Drawing.Size(246, 75);
            this.panel13.TabIndex = 10;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(-19, -30);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button11.Size = new System.Drawing.Size(297, 112);
            this.button11.TabIndex = 1;
            this.button11.Text = "    Events";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button10);
            this.panel12.Location = new System.Drawing.Point(3, 76);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.panel12.Size = new System.Drawing.Size(246, 76);
            this.panel12.TabIndex = 10;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button10.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(-17, -23);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button10.Size = new System.Drawing.Size(281, 113);
            this.button10.TabIndex = 1;
            this.button10.Text = "     Bookings";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // pnChat
            // 
            this.pnChat.Controls.Add(this.button6);
            this.pnChat.Location = new System.Drawing.Point(3, 408);
            this.pnChat.Name = "pnChat";
            this.pnChat.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnChat.Size = new System.Drawing.Size(246, 75);
            this.pnChat.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(-11, -21);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(297, 106);
            this.button6.TabIndex = 1;
            this.button6.Text = "  🗨️   Chat";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.button8);
            this.pnLogout.Location = new System.Drawing.Point(3, 489);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.pnLogout.Size = new System.Drawing.Size(246, 75);
            this.pnLogout.TabIndex = 10;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.button8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button8.Location = new System.Drawing.Point(-11, -23);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(297, 106);
            this.button8.TabIndex = 1;
            this.button8.Text = " 👋   Logout";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // eventTransition
            // 
            this.eventTransition.Interval = 10;
            this.eventTransition.Tick += new System.EventHandler(this.eventTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(770, 3);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 3;
            // 
            // DashboardUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 712);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardUser";
            this.Text = "\\";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pnDashboard.ResumeLayout(false);
            this.pnProfile.ResumeLayout(false);
            this.pnMembership.ResumeLayout(false);
            this.pnDigitalContent.ResumeLayout(false);
            this.EventContainer.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.pnChat.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pnDashboard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnMembership;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel pnDigitalContent;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel pnProfile;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button EventsMenu;
        private System.Windows.Forms.Timer eventTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Panel EventContainer;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button10;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
    }
}