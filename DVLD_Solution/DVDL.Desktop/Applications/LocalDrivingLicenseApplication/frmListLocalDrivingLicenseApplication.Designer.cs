namespace DVDL.Desktop.Applications.LocalDrivingLicenseApplication
{
    partial class frmListLocalDrivingLicenseApplication
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
            this.label6 = new System.Windows.Forms.Label();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtValueFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowApplicationDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditApplicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ScheduleTestsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleVisionTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleWrittenTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleStreetTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.IssueDrivingLicense_FirstTimeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowLicenseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowPersonLicenseHistoryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.LocalDrivingLicenseApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivingClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedTests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(347, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(524, 41);
            this.label6.TabIndex = 42;
            this.label6.Text = "Local Driving License Applications";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderColor = System.Drawing.Color.Black;
            this.cbFilterBy.BorderRadius = 10;
            this.cbFilterBy.CustomizableEdges.BottomLeft = false;
            this.cbFilterBy.CustomizableEdges.TopRight = false;
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(105, 224);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(191, 36);
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.TabIndex = 42;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.BorderColor = System.Drawing.Color.Black;
            this.txtValueFilter.BorderRadius = 5;
            this.txtValueFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValueFilter.CustomizableEdges.BottomLeft = false;
            this.txtValueFilter.CustomizableEdges.TopRight = false;
            this.txtValueFilter.DefaultText = "";
            this.txtValueFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValueFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValueFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValueFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtValueFilter.ForeColor = System.Drawing.Color.Black;
            this.txtValueFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValueFilter.IconLeft = global::DVDL.Desktop.Properties.Resources.search_32;
            this.txtValueFilter.Location = new System.Drawing.Point(303, 223);
            this.txtValueFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.PasswordChar = '\0';
            this.txtValueFilter.PlaceholderForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtValueFilter.PlaceholderText = "Search Here";
            this.txtValueFilter.SelectedText = "";
            this.txtValueFilter.Size = new System.Drawing.Size(250, 36);
            this.txtValueFilter.TabIndex = 42;
            this.txtValueFilter.Visible = false;
            this.txtValueFilter.TextChanged += new System.EventHandler(this.txtValueFilter_TextChanged);
            this.txtValueFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueFilter_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // cmsApplications
            // 
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowApplicationDetailsItem,
            this.toolStripSeparator1,
            this.EditApplicationItem,
            this.DeleteApplicationItem,
            this.toolStripSeparator2,
            this.CancelApplicationItem,
            this.toolStripSeparator3,
            this.ScheduleTestsItem,
            this.toolStripSeparator4,
            this.IssueDrivingLicense_FirstTimeItem,
            this.toolStripSeparator5,
            this.ShowLicenseItem,
            this.toolStripSeparator6,
            this.ShowPersonLicenseHistoryItem});
            this.cmsApplications.Name = "contextMenuStrip";
            this.cmsApplications.Size = new System.Drawing.Size(321, 344);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // ShowApplicationDetailsItem
            // 
            this.ShowApplicationDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowApplicationDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.PersonDetails_32;
            this.ShowApplicationDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowApplicationDetailsItem.Name = "ShowApplicationDetailsItem";
            this.ShowApplicationDetailsItem.Size = new System.Drawing.Size(320, 38);
            this.ShowApplicationDetailsItem.Text = "Show Application Details";
            this.ShowApplicationDetailsItem.Click += new System.EventHandler(this.ShowApplicationDetailsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(317, 6);
            // 
            // EditApplicationItem
            // 
            this.EditApplicationItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.EditApplicationItem.Image = global::DVDL.Desktop.Properties.Resources.edit_32;
            this.EditApplicationItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditApplicationItem.Name = "EditApplicationItem";
            this.EditApplicationItem.Size = new System.Drawing.Size(320, 38);
            this.EditApplicationItem.Text = "Edit Application";
            this.EditApplicationItem.Click += new System.EventHandler(this.EditApplicationItem_Click);
            // 
            // DeleteApplicationItem
            // 
            this.DeleteApplicationItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DeleteApplicationItem.Image = global::DVDL.Desktop.Properties.Resources.Delete_32_2;
            this.DeleteApplicationItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteApplicationItem.Name = "DeleteApplicationItem";
            this.DeleteApplicationItem.Size = new System.Drawing.Size(320, 38);
            this.DeleteApplicationItem.Text = "Delete Application";
            this.DeleteApplicationItem.Click += new System.EventHandler(this.DeleteApplicationItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(317, 6);
            // 
            // CancelApplicationItem
            // 
            this.CancelApplicationItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.CancelApplicationItem.Image = global::DVDL.Desktop.Properties.Resources.Delete_32;
            this.CancelApplicationItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelApplicationItem.Name = "CancelApplicationItem";
            this.CancelApplicationItem.Size = new System.Drawing.Size(320, 38);
            this.CancelApplicationItem.Text = "Cancel Application";
            this.CancelApplicationItem.Click += new System.EventHandler(this.CancelApplicationItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(317, 6);
            // 
            // ScheduleTestsItem
            // 
            this.ScheduleTestsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScheduleVisionTestItem,
            this.ScheduleWrittenTestItem,
            this.ScheduleStreetTestItem});
            this.ScheduleTestsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ScheduleTestsItem.Image = global::DVDL.Desktop.Properties.Resources.Schedule_Test_32;
            this.ScheduleTestsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleTestsItem.Name = "ScheduleTestsItem";
            this.ScheduleTestsItem.Size = new System.Drawing.Size(320, 38);
            this.ScheduleTestsItem.Text = "Schedule Tests";
            // 
            // ScheduleVisionTestItem
            // 
            this.ScheduleVisionTestItem.Image = global::DVDL.Desktop.Properties.Resources.Vision_Test_32;
            this.ScheduleVisionTestItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleVisionTestItem.Name = "ScheduleVisionTestItem";
            this.ScheduleVisionTestItem.Size = new System.Drawing.Size(245, 38);
            this.ScheduleVisionTestItem.Text = "Schedule Vision Test";
            this.ScheduleVisionTestItem.Click += new System.EventHandler(this.ScheduleVisionTestItem_Click);
            // 
            // ScheduleWrittenTestItem
            // 
            this.ScheduleWrittenTestItem.Image = global::DVDL.Desktop.Properties.Resources.Written_Test_32;
            this.ScheduleWrittenTestItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleWrittenTestItem.Name = "ScheduleWrittenTestItem";
            this.ScheduleWrittenTestItem.Size = new System.Drawing.Size(245, 38);
            this.ScheduleWrittenTestItem.Text = "Schedule Written Test";
            this.ScheduleWrittenTestItem.Click += new System.EventHandler(this.ScheduleWrittenTestItem_Click);
            // 
            // ScheduleStreetTestItem
            // 
            this.ScheduleStreetTestItem.Image = global::DVDL.Desktop.Properties.Resources.Street_Test_32;
            this.ScheduleStreetTestItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleStreetTestItem.Name = "ScheduleStreetTestItem";
            this.ScheduleStreetTestItem.Size = new System.Drawing.Size(245, 38);
            this.ScheduleStreetTestItem.Text = "Schedule Street Test";
            this.ScheduleStreetTestItem.Click += new System.EventHandler(this.ScheduleStreetTestItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(317, 6);
            // 
            // IssueDrivingLicense_FirstTimeItem
            // 
            this.IssueDrivingLicense_FirstTimeItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.IssueDrivingLicense_FirstTimeItem.Image = global::DVDL.Desktop.Properties.Resources.IssueDrivingLicense_32;
            this.IssueDrivingLicense_FirstTimeItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.IssueDrivingLicense_FirstTimeItem.Name = "IssueDrivingLicense_FirstTimeItem";
            this.IssueDrivingLicense_FirstTimeItem.Size = new System.Drawing.Size(320, 38);
            this.IssueDrivingLicense_FirstTimeItem.Text = "Issue Driving License (First Time)";
            this.IssueDrivingLicense_FirstTimeItem.Click += new System.EventHandler(this.IssueDrivingLicense_FirstTimeItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(317, 6);
            // 
            // ShowLicenseItem
            // 
            this.ShowLicenseItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowLicenseItem.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.ShowLicenseItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLicenseItem.Name = "ShowLicenseItem";
            this.ShowLicenseItem.Size = new System.Drawing.Size(320, 38);
            this.ShowLicenseItem.Text = "Show License";
            this.ShowLicenseItem.Click += new System.EventHandler(this.ShowLicenseItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(317, 6);
            // 
            // ShowPersonLicenseHistoryItem
            // 
            this.ShowPersonLicenseHistoryItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowPersonLicenseHistoryItem.Image = global::DVDL.Desktop.Properties.Resources.PersonLicenseHistory_32;
            this.ShowPersonLicenseHistoryItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowPersonLicenseHistoryItem.Name = "ShowPersonLicenseHistoryItem";
            this.ShowPersonLicenseHistoryItem.Size = new System.Drawing.Size(320, 38);
            this.ShowPersonLicenseHistoryItem.Text = "Show Person License History";
            this.ShowPersonLicenseHistoryItem.Click += new System.EventHandler(this.ShowPersonLicenseHistoryItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 572);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 43;
            this.label1.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(126, 572);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 24);
            this.lblRecordsCount.TabIndex = 44;
            this.lblRecordsCount.Text = "??";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL.Desktop.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(507, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1058, 572);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 37);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Image = global::DVDL.Desktop.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1107, 188);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(100, 72);
            this.btnAddNewApplication.TabIndex = 47;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocalDrivingLicenseApplicationID,
            this.DrivingClass,
            this.NationalNo,
            this.FullName,
            this.ApplicationDate,
            this.PassedTests,
            this.Status});
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsApplications;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseApplications.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(18, 266);
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1189, 300);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 48;
            // 
            // LocalDrivingLicenseApplicationID
            // 
            this.LocalDrivingLicenseApplicationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LocalDrivingLicenseApplicationID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            this.LocalDrivingLicenseApplicationID.HeaderText = "L.D.L.AppID";
            this.LocalDrivingLicenseApplicationID.Name = "LocalDrivingLicenseApplicationID";
            this.LocalDrivingLicenseApplicationID.ReadOnly = true;
            this.LocalDrivingLicenseApplicationID.Width = 120;
            // 
            // DrivingClass
            // 
            this.DrivingClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DrivingClass.DataPropertyName = "ClassName";
            this.DrivingClass.HeaderText = "Driving Class";
            this.DrivingClass.Name = "DrivingClass";
            this.DrivingClass.ReadOnly = true;
            this.DrivingClass.Width = 233;
            // 
            // NationalNo
            // 
            this.NationalNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.HeaderText = "National No.";
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.ReadOnly = true;
            this.NationalNo.Width = 120;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 235;
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApplicationDate.DataPropertyName = "ApplicationDate";
            this.ApplicationDate.HeaderText = "Application Date";
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.ReadOnly = true;
            this.ApplicationDate.Width = 200;
            // 
            // PassedTests
            // 
            this.PassedTests.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PassedTests.DataPropertyName = "PassedTestCount";
            this.PassedTests.HeaderText = "Passed Tests";
            this.PassedTests.Name = "PassedTests";
            this.PassedTests.ReadOnly = true;
            this.PassedTests.Width = 130;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 90;
            // 
            // frmListLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 616);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtValueFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListLocalDrivingLicenseApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplication_Load);
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2TextBox txtValueFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem ShowApplicationDetailsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EditApplicationItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ScheduleTestsItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduleVisionTestItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduleWrittenTestItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduleStreetTestItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem IssueDrivingLicense_FirstTimeItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem ShowLicenseItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonLicenseHistoryItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalDrivingLicenseApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivingClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}