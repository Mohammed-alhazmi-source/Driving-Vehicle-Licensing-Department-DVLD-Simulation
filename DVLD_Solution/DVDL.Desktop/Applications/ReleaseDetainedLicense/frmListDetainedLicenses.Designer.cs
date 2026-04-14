namespace DVDL.Desktop.License.DetainedOrReleaseLicenses
{
    partial class frmListDetainedLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.DetainID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReleased = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FineFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ReleaseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.cbFilterByRelease = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.btnAddDetainLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.ShowPersonDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicenseDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPersonLicenseHistoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.cmsDetainedLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(421, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Detained Licenses";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL.Desktop.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(548, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetainID,
            this.LicenseID,
            this.DetainDate,
            this.IsReleased,
            this.FineFees,
            this.ReleaseDate,
            this.NationalNo,
            this.FullName,
            this.ReleaseApplicationID});
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmsDetainedLicenses;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainedLicenses.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(21, 280);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1223, 296);
            this.dgvDetainedLicenses.TabIndex = 2;
            // 
            // DetainID
            // 
            this.DetainID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DetainID.DataPropertyName = "DetainID";
            this.DetainID.HeaderText = "Detain ID";
            this.DetainID.Name = "DetainID";
            this.DetainID.ReadOnly = true;
            this.DetainID.Width = 95;
            // 
            // LicenseID
            // 
            this.LicenseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LicenseID.DataPropertyName = "LicenseID";
            this.LicenseID.HeaderText = "License ID";
            this.LicenseID.Name = "LicenseID";
            this.LicenseID.ReadOnly = true;
            this.LicenseID.Width = 99;
            // 
            // DetainDate
            // 
            this.DetainDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DetainDate.DataPropertyName = "DetainDate";
            this.DetainDate.HeaderText = "Detain Date";
            this.DetainDate.Name = "DetainDate";
            this.DetainDate.ReadOnly = true;
            this.DetainDate.Width = 142;
            // 
            // IsReleased
            // 
            this.IsReleased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsReleased.DataPropertyName = "IsReleased";
            this.IsReleased.HeaderText = "Is Released";
            this.IsReleased.Name = "IsReleased";
            this.IsReleased.ReadOnly = true;
            this.IsReleased.Width = 107;
            // 
            // FineFees
            // 
            this.FineFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FineFees.DataPropertyName = "FineFees";
            this.FineFees.HeaderText = "Fine Fees";
            this.FineFees.Name = "FineFees";
            this.FineFees.ReadOnly = true;
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ReleaseDate.DataPropertyName = "ReleaseDate";
            this.ReleaseDate.HeaderText = "Release Date";
            this.ReleaseDate.Name = "ReleaseDate";
            this.ReleaseDate.ReadOnly = true;
            this.ReleaseDate.Width = 140;
            // 
            // NationalNo
            // 
            this.NationalNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.HeaderText = "National No.";
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.ReadOnly = true;
            this.NationalNo.Width = 110;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 260;
            // 
            // ReleaseApplicationID
            // 
            this.ReleaseApplicationID.DataPropertyName = "ReleaseApplicationID";
            this.ReleaseApplicationID.HeaderText = "R.App ID";
            this.ReleaseApplicationID.Name = "ReleaseApplicationID";
            this.ReleaseApplicationID.ReadOnly = true;
            // 
            // cmsDetainedLicenses
            // 
            this.cmsDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailsItem,
            this.ShowLicenseDetailsItem,
            this.ShowPersonLicenseHistoryItem,
            this.toolStripSeparator1,
            this.ReleaseItem});
            this.cmsDetainedLicenses.Name = "cmsDetainedLicenses";
            this.cmsDetainedLicenses.Size = new System.Drawing.Size(293, 162);
            this.cmsDetainedLicenses.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDetainedLicenses_Opening);
            // 
            // ReleaseItem
            // 
            this.ReleaseItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ReleaseItem.Image = global::DVDL.Desktop.Properties.Resources.Release_Detained_License_32;
            this.ReleaseItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ReleaseItem.Name = "ReleaseItem";
            this.ReleaseItem.Size = new System.Drawing.Size(292, 38);
            this.ReleaseItem.Text = "Release";
            this.ReleaseItem.Click += new System.EventHandler(this.ReleaseItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(26, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "License ID",
            "National No.",
            "Full Name",
            "Is Released"});
            this.cbFilterBy.Location = new System.Drawing.Point(104, 241);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 31);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // cbFilterByRelease
            // 
            this.cbFilterByRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterByRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbFilterByRelease.Font = new System.Drawing.Font("Tahoma", 14F);
            this.cbFilterByRelease.FormattingEnabled = true;
            this.cbFilterByRelease.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterByRelease.Location = new System.Drawing.Point(319, 241);
            this.cbFilterByRelease.Name = "cbFilterByRelease";
            this.cbFilterByRelease.Size = new System.Drawing.Size(81, 31);
            this.cbFilterByRelease.TabIndex = 5;
            this.cbFilterByRelease.Visible = false;
            this.cbFilterByRelease.SelectedIndexChanged += new System.EventHandler(this.cbFilterByRelease_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtFilterValue.Location = new System.Drawing.Point(319, 241);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(209, 31);
            this.txtFilterValue.TabIndex = 6;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // btnAddDetainLicense
            // 
            this.btnAddDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetainLicense.Image = global::DVDL.Desktop.Properties.Resources.Detain_64;
            this.btnAddDetainLicense.Location = new System.Drawing.Point(1144, 204);
            this.btnAddDetainLicense.Name = "btnAddDetainLicense";
            this.btnAddDetainLicense.Size = new System.Drawing.Size(100, 70);
            this.btnAddDetainLicense.TabIndex = 7;
            this.btnAddDetainLicense.UseVisualStyleBackColor = true;
            this.btnAddDetainLicense.Click += new System.EventHandler(this.btnAddDetainLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1102, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 37);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(26, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRecordsCount.Location = new System.Drawing.Point(120, 580);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(25, 19);
            this.lblRecordsCount.TabIndex = 10;
            this.lblRecordsCount.Text = "??";
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseLicense.Image = global::DVDL.Desktop.Properties.Resources.Release_Detained_License_64;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1038, 204);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(100, 70);
            this.btnReleaseLicense.TabIndex = 11;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // ShowPersonDetailsItem
            // 
            this.ShowPersonDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowPersonDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.PersonDetails_32;
            this.ShowPersonDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonDetailsItem.Name = "ShowPersonDetailsItem";
            this.ShowPersonDetailsItem.Size = new System.Drawing.Size(292, 38);
            this.ShowPersonDetailsItem.Text = "Show Person Details";
            this.ShowPersonDetailsItem.Click += new System.EventHandler(this.ShowPersonDetailsItem_Click);
            // 
            // ShowLicenseDetailsItem
            // 
            this.ShowLicenseDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowLicenseDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.ShowLicenseDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseDetailsItem.Name = "ShowLicenseDetailsItem";
            this.ShowLicenseDetailsItem.Size = new System.Drawing.Size(292, 38);
            this.ShowLicenseDetailsItem.Text = "Show License Details";
            this.ShowLicenseDetailsItem.Click += new System.EventHandler(this.ShowLicenseDetailsItem_Click);
            // 
            // ShowPersonLicenseHistoryItem
            // 
            this.ShowPersonLicenseHistoryItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowPersonLicenseHistoryItem.Image = global::DVDL.Desktop.Properties.Resources.PersonLicenseHistory_32;
            this.ShowPersonLicenseHistoryItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonLicenseHistoryItem.Name = "ShowPersonLicenseHistoryItem";
            this.ShowPersonLicenseHistoryItem.Size = new System.Drawing.Size(292, 38);
            this.ShowPersonLicenseHistoryItem.Text = "Show Person License History";
            this.ShowPersonLicenseHistoryItem.Click += new System.EventHandler(this.ShowPersonLicenseHistoryItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(289, 6);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 624);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddDetainLicense);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbFilterByRelease);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.cmsDetainedLicenses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterByRelease;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Button btnAddDetainLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip cmsDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem ReleaseItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetainID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsReleased;
        private System.Windows.Forms.DataGridViewTextBoxColumn FineFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseApplicationID;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsItem;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseDetailsItem;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistoryItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}