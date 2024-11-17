namespace login
{
    partial class formRegistration
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
            this.dgvPendingUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendingUser
            // 
            this.dgvPendingUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingUser.Location = new System.Drawing.Point(0, 0);
            this.dgvPendingUser.Name = "dgvPendingUser";
            this.dgvPendingUser.RowHeadersWidth = 62;
            this.dgvPendingUser.RowTemplate.Height = 28;
            this.dgvPendingUser.Size = new System.Drawing.Size(240, 150);
            this.dgvPendingUser.TabIndex = 0;
            // 
            // formRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPendingUser);
            this.Name = "formRegistration";
            this.Text = "formNotices";
            this.Load += new System.EventHandler(this.formRegistration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendingUser;
    }
}