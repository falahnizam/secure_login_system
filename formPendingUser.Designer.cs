namespace login
{
    partial class PendingUsers
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
            this.dgvPendingUsers = new ADGV.AdvancedDataGridView();
            this.btnRejectUser = new System.Windows.Forms.Button();
            this.btnLoadPendingUsers = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtSelectedUserID = new System.Windows.Forms.TextBox();
            this.txtRejectionReason = new System.Windows.Forms.TextBox();
            this.lblRejectrsn = new System.Windows.Forms.Label();
            this.lblSelectedUserID = new System.Windows.Forms.Label();
            this.btnAcceptUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingUsers
            // 
            this.dgvPendingUsers.AutoGenerateContextFilters = true;
            this.dgvPendingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingUsers.DateWithTime = false;
            this.dgvPendingUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvPendingUsers.Name = "dgvPendingUsers";
            this.dgvPendingUsers.RowHeadersWidth = 62;
            this.dgvPendingUsers.RowTemplate.Height = 28;
            this.dgvPendingUsers.Size = new System.Drawing.Size(988, 523);
            this.dgvPendingUsers.TabIndex = 0;
            this.dgvPendingUsers.TimeFilter = false;
            this.dgvPendingUsers.SelectionChanged += new System.EventHandler(this.dgvPendingUsers_SelectionChanged);
            // 
            // btnRejectUser
            // 
            this.btnRejectUser.Location = new System.Drawing.Point(0, 575);
            this.btnRejectUser.Name = "btnRejectUser";
            this.btnRejectUser.Size = new System.Drawing.Size(102, 32);
            this.btnRejectUser.TabIndex = 8;
            this.btnRejectUser.Text = "Reject";
            this.btnRejectUser.UseVisualStyleBackColor = true;
            this.btnRejectUser.Click += new System.EventHandler(this.btnRejectUser_Click);
            // 
            // btnLoadPendingUsers
            // 
            this.btnLoadPendingUsers.Location = new System.Drawing.Point(0, 529);
            this.btnLoadPendingUsers.Name = "btnLoadPendingUsers";
            this.btnLoadPendingUsers.Size = new System.Drawing.Size(195, 49);
            this.btnLoadPendingUsers.TabIndex = 7;
            this.btnLoadPendingUsers.Text = "Pending Users";
            this.btnLoadPendingUsers.UseVisualStyleBackColor = true;
            this.btnLoadPendingUsers.Click += new System.EventHandler(this.btnLoadPendingUsers_Click);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DataSource = this.bindingSource1;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(203, 529);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(121, 28);
            this.comboBoxRole.TabIndex = 6;
            this.comboBoxRole.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // txtSelectedUserID
            // 
            this.txtSelectedUserID.Location = new System.Drawing.Point(504, 616);
            this.txtSelectedUserID.Name = "txtSelectedUserID";
            this.txtSelectedUserID.Size = new System.Drawing.Size(471, 26);
            this.txtSelectedUserID.TabIndex = 10;
            // 
            // txtRejectionReason
            // 
            this.txtRejectionReason.Location = new System.Drawing.Point(504, 529);
            this.txtRejectionReason.Name = "txtRejectionReason";
            this.txtRejectionReason.Size = new System.Drawing.Size(471, 26);
            this.txtRejectionReason.TabIndex = 9;
            // 
            // lblRejectrsn
            // 
            this.lblRejectrsn.AutoSize = true;
            this.lblRejectrsn.Location = new System.Drawing.Point(330, 532);
            this.lblRejectrsn.Name = "lblRejectrsn";
            this.lblRejectrsn.Size = new System.Drawing.Size(168, 20);
            this.lblRejectrsn.TabIndex = 11;
            this.lblRejectrsn.Text = "Reason For Rejection:";
            // 
            // lblSelectedUserID
            // 
            this.lblSelectedUserID.AutoSize = true;
            this.lblSelectedUserID.Location = new System.Drawing.Point(330, 619);
            this.lblSelectedUserID.Name = "lblSelectedUserID";
            this.lblSelectedUserID.Size = new System.Drawing.Size(174, 20);
            this.lblSelectedUserID.TabIndex = 12;
            this.lblSelectedUserID.Text = "Enter Selected User ID";
            // 
            // btnAcceptUser
            // 
            this.btnAcceptUser.Location = new System.Drawing.Point(93, 575);
            this.btnAcceptUser.Name = "btnAcceptUser";
            this.btnAcceptUser.Size = new System.Drawing.Size(102, 32);
            this.btnAcceptUser.TabIndex = 13;
            this.btnAcceptUser.Text = "Accept";
            this.btnAcceptUser.UseVisualStyleBackColor = true;
            this.btnAcceptUser.Click += new System.EventHandler(this.btnAcceptUser_Click);
            // 
            // PendingUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 654);
            this.Controls.Add(this.btnAcceptUser);
            this.Controls.Add(this.lblSelectedUserID);
            this.Controls.Add(this.lblRejectrsn);
            this.Controls.Add(this.txtSelectedUserID);
            this.Controls.Add(this.txtRejectionReason);
            this.Controls.Add(this.btnRejectUser);
            this.Controls.Add(this.btnLoadPendingUsers);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.dgvPendingUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PendingUsers";
            this.Text = "formPendingUser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView dgvPendingUsers;
        private System.Windows.Forms.Button btnRejectUser;
        private System.Windows.Forms.Button btnLoadPendingUsers;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtSelectedUserID;
        private System.Windows.Forms.TextBox txtRejectionReason;
        private System.Windows.Forms.Label lblRejectrsn;
        private System.Windows.Forms.Label lblSelectedUserID;
        private System.Windows.Forms.Button btnAcceptUser;
    }
}