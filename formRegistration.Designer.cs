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
            this.components = new System.ComponentModel.Container();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dgvRegistration = new ADGV.AdvancedDataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(0, 590);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(195, 49);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click_1);
            // 
            // dgvRegistration
            // 
            this.dgvRegistration.AutoGenerateContextFilters = true;
            this.dgvRegistration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistration.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRegistration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistration.DateWithTime = false;
            this.dgvRegistration.Location = new System.Drawing.Point(0, 0);
            this.dgvRegistration.Name = "dgvRegistration";
            this.dgvRegistration.RowHeadersWidth = 62;
            this.dgvRegistration.RowTemplate.Height = 28;
            this.dgvRegistration.Size = new System.Drawing.Size(872, 584);
            this.dgvRegistration.TabIndex = 2;
            this.dgvRegistration.TimeFilter = false;
            this.dgvRegistration.SortStringChanged += new System.EventHandler(this.dgvRegistration_SortStringChanged);
            this.dgvRegistration.FilterStringChanged += new System.EventHandler(this.dgvRegistration_FilterStringChanged);
            // 
            // bindingSource1
            // 
            // 
            // formRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 710);
            this.ControlBox = false;
            this.Controls.Add(this.dgvRegistration);
            this.Controls.Add(this.btnLoadData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formRegistration";
            this.Text = "Registration";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadData;
        private ADGV.AdvancedDataGridView dgvRegistration;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}