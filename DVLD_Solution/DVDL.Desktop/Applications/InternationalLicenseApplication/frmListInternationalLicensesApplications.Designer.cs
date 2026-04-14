namespace DVDL.Desktop.Applications.InternationalLicenseApplication
{
    partial class frmListInternationalLicensesApplications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesApplications = new System.Windows.Forms.DataGridView();
            this.InternationalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowInternationalLicenseDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowPersonLicenseHistoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterByActiveOrInActive = new System.Windows.Forms.ComboBox();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL.Desktop.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(468, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVDL.Desktop.Properties.Resources.International_32;
            this.pictureBox2.Location = new System.Drawing.Point(625, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(309, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "International License Applications";
            // 
            // dgvInternationalLicensesApplications
            // 
            this.dgvInternationalLicensesApplications.AllowUserToAddRows = false;
            this.dgvInternationalLicensesApplications.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesApplications.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesApplications.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalLicensesApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InternationalLicenseID,
            this.ApplicationID,
            this.DriverID,
            this.LicenseID,
            this.IssueDate,
            this.ExpirationDate,
            this.IsActive});
            this.dgvInternationalLicensesApplications.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicensesApplications.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicensesApplications.Location = new System.Drawing.Point(42, 295);
            this.dgvInternationalLicensesApplications.Name = "dgvInternationalLicensesApplications";
            this.dgvInternationalLicensesApplications.ReadOnly = true;
            this.dgvInternationalLicensesApplications.Size = new System.Drawing.Size(1062, 257);
            this.dgvInternationalLicensesApplications.TabIndex = 3;
            // 
            // InternationalLicenseID
            // 
            this.InternationalLicenseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InternationalLicenseID.DataPropertyName = "InternationalLicenseID";
            this.InternationalLicenseID.HeaderText = "Int.License ID";
            this.InternationalLicenseID.Name = "InternationalLicenseID";
            this.InternationalLicenseID.ReadOnly = true;
            this.InternationalLicenseID.Width = 150;
            // 
            // ApplicationID
            // 
            this.ApplicationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApplicationID.DataPropertyName = "ApplicationID";
            this.ApplicationID.HeaderText = "Application ID";
            this.ApplicationID.Name = "ApplicationID";
            this.ApplicationID.ReadOnly = true;
            this.ApplicationID.Width = 140;
            // 
            // DriverID
            // 
            this.DriverID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DriverID.DataPropertyName = "DriverID";
            this.DriverID.HeaderText = "Driver ID";
            this.DriverID.Name = "DriverID";
            this.DriverID.ReadOnly = true;
            // 
            // LicenseID
            // 
            this.LicenseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LicenseID.DataPropertyName = "LicenseID";
            this.LicenseID.HeaderText = "L.License ID";
            this.LicenseID.Name = "LicenseID";
            this.LicenseID.ReadOnly = true;
            this.LicenseID.Width = 120;
            // 
            // IssueDate
            // 
            this.IssueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.ReadOnly = true;
            this.IssueDate.Width = 200;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ExpirationDate.DataPropertyName = "ExpirationDate";
            this.ExpirationDate.HeaderText = "Expiration Date";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            this.ExpirationDate.Width = 209;
            // 
            // IsActive
            // 
            this.IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "Is Active";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailsItem,
            this.toolStripSeparator1,
            this.ShowLicenseDetailsItem,
            this.ShowInternationalLicenseDetailsItem,
            this.toolStripSeparator2,
            this.ShowPersonLicenseHistoryItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(331, 168);
            // 
            // ShowPersonDetailsItem
            // 
            this.ShowPersonDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowPersonDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.PersonDetails_32;
            this.ShowPersonDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonDetailsItem.Name = "ShowPersonDetailsItem";
            this.ShowPersonDetailsItem.Size = new System.Drawing.Size(330, 38);
            this.ShowPersonDetailsItem.Text = "Show Person Details";
            this.ShowPersonDetailsItem.Click += new System.EventHandler(this.ShowPersonDetailsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(327, 6);
            // 
            // ShowLicenseDetailsItem
            // 
            this.ShowLicenseDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowLicenseDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.ShowLicenseDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseDetailsItem.Name = "ShowLicenseDetailsItem";
            this.ShowLicenseDetailsItem.Size = new System.Drawing.Size(330, 38);
            this.ShowLicenseDetailsItem.Text = "Show License Details";
            this.ShowLicenseDetailsItem.Click += new System.EventHandler(this.ShowLicenseDetailsItem_Click);
            // 
            // ShowInternationalLicenseDetailsItem
            // 
            this.ShowInternationalLicenseDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowInternationalLicenseDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.International_32;
            this.ShowInternationalLicenseDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowInternationalLicenseDetailsItem.Name = "ShowInternationalLicenseDetailsItem";
            this.ShowInternationalLicenseDetailsItem.Size = new System.Drawing.Size(330, 38);
            this.ShowInternationalLicenseDetailsItem.Text = "Show International License Details";
            this.ShowInternationalLicenseDetailsItem.Click += new System.EventHandler(this.ShowInternationalLicenseDetailsItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(327, 6);
            // 
            // ShowPersonLicenseHistoryItem
            // 
            this.ShowPersonLicenseHistoryItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowPersonLicenseHistoryItem.Image = global::DVDL.Desktop.Properties.Resources.PersonLicenseHistory_32;
            this.ShowPersonLicenseHistoryItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonLicenseHistoryItem.Name = "ShowPersonLicenseHistoryItem";
            this.ShowPersonLicenseHistoryItem.Size = new System.Drawing.Size(330, 38);
            this.ShowPersonLicenseHistoryItem.Text = "Show Person License History";
            this.ShowPersonLicenseHistoryItem.Click += new System.EventHandler(this.ShowPersonLicenseHistoryItem_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Application ID",
            "Driver ID",
            "License ID",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(133, 261);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(227, 27);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lbl.Location = new System.Drawing.Point(47, 261);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(80, 22);
            this.lbl.TabIndex = 5;
            this.lbl.Text = "Filter By:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFilterValue.Location = new System.Drawing.Point(366, 261);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(227, 27);
            this.txtFilterValue.TabIndex = 6;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterByActiveOrInActive
            // 
            this.cbFilterByActiveOrInActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterByActiveOrInActive.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterByActiveOrInActive.FormattingEnabled = true;
            this.cbFilterByActiveOrInActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterByActiveOrInActive.Location = new System.Drawing.Point(366, 262);
            this.cbFilterByActiveOrInActive.Name = "cbFilterByActiveOrInActive";
            this.cbFilterByActiveOrInActive.Size = new System.Drawing.Size(109, 27);
            this.cbFilterByActiveOrInActive.TabIndex = 7;
            this.cbFilterByActiveOrInActive.Visible = false;
            this.cbFilterByActiveOrInActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterByActiveOrInActive_SelectedIndexChanged);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Image = global::DVDL.Desktop.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1004, 217);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(100, 72);
            this.btnAddNewApplication.TabIndex = 8;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(955, 558);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 46);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label2.Location = new System.Drawing.Point(47, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 13F);
            this.lblRecordsCount.Location = new System.Drawing.Point(150, 558);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 22);
            this.lblRecordsCount.TabIndex = 11;
            this.lblRecordsCount.Text = "??";
            // 
            // frmListInternationalLicensesApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1141, 616);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.cbFilterByActiveOrInActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dgvInternationalLicensesApplications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListInternationalLicensesApplications";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List International Licenses Applications";
            this.Load += new System.EventHandler(this.frmListInternationalLicensesApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesApplications;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterByActiveOrInActive;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistoryItem;
        private System.Windows.Forms.ToolStripMenuItem ShowInternationalLicenseDetailsItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternationalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
    }
}