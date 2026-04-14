namespace DVDL.Desktop.Tests
{
    partial class frmListTestAppointments
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
            this.dgvTestAppointments = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditTestAppointmentItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTestItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewTestAppointment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlShowApplicationInfo1 = new DVDL.Desktop.Applications.Controls.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTestAppointments
            // 
            this.dgvTestAppointments.AllowUserToAddRows = false;
            this.dgvTestAppointments.AllowUserToDeleteRows = false;
            this.dgvTestAppointments.AllowUserToOrderColumns = true;
            this.dgvTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestAppointments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTestAppointments.Location = new System.Drawing.Point(30, 407);
            this.dgvTestAppointments.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dgvTestAppointments.Name = "dgvTestAppointments";
            this.dgvTestAppointments.ReadOnly = true;
            this.dgvTestAppointments.Size = new System.Drawing.Size(1132, 172);
            this.dgvTestAppointments.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditTestAppointmentItem,
            this.TakeTestItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 80);
            // 
            // EditTestAppointmentItem
            // 
            this.EditTestAppointmentItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.EditTestAppointmentItem.Image = global::DVDL.Desktop.Properties.Resources.edit_32;
            this.EditTestAppointmentItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditTestAppointmentItem.Name = "EditTestAppointmentItem";
            this.EditTestAppointmentItem.Size = new System.Drawing.Size(136, 38);
            this.EditTestAppointmentItem.Text = "Edit";
            this.EditTestAppointmentItem.Click += new System.EventHandler(this.EditTestAppointmentItem_Click);
            // 
            // TakeTestItem
            // 
            this.TakeTestItem.Image = global::DVDL.Desktop.Properties.Resources.Test_32;
            this.TakeTestItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TakeTestItem.Name = "TakeTestItem";
            this.TakeTestItem.Size = new System.Drawing.Size(136, 38);
            this.TakeTestItem.Text = "Take Test";
            this.TakeTestItem.Click += new System.EventHandler(this.TakeTestItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(312, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(549, 33);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackColor = System.Drawing.Color.Transparent;
            this.pbTestTypeImage.Image = global::DVDL.Desktop.Properties.Resources.Written_Test_512;
            this.pbTestTypeImage.Location = new System.Drawing.Point(11, 88);
            this.pbTestTypeImage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(258, 234);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 43;
            this.pbTestTypeImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 365);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "Appointments:";
            // 
            // btnAddNewTestAppointment
            // 
            this.btnAddNewTestAppointment.BackColor = System.Drawing.Color.White;
            this.btnAddNewTestAppointment.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddNewTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewTestAppointment.Image = global::DVDL.Desktop.Properties.Resources.AddAppointment_32;
            this.btnAddNewTestAppointment.Location = new System.Drawing.Point(1073, 356);
            this.btnAddNewTestAppointment.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnAddNewTestAppointment.Name = "btnAddNewTestAppointment";
            this.btnAddNewTestAppointment.Size = new System.Drawing.Size(89, 48);
            this.btnAddNewTestAppointment.TabIndex = 45;
            this.btnAddNewTestAppointment.UseVisualStyleBackColor = false;
            this.btnAddNewTestAppointment.Click += new System.EventHandler(this.btnAddNewTestAppointment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 585);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 47;
            this.label2.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(118, 585);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(25, 19);
            this.lblRecordsCount.TabIndex = 48;
            this.lblRecordsCount.Text = "??";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1006, 584);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 36);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlShowApplicationInfo1
            // 
            this.ctrlShowApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlShowApplicationInfo1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.ctrlShowApplicationInfo1.Location = new System.Drawing.Point(300, 60);
            this.ctrlShowApplicationInfo1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ctrlShowApplicationInfo1.Name = "ctrlShowApplicationInfo1";
            this.ctrlShowApplicationInfo1.PassedTestsCount = 0;
            this.ctrlShowApplicationInfo1.ShowLicenseInfoEnabled = false;
            this.ctrlShowApplicationInfo1.Size = new System.Drawing.Size(862, 289);
            this.ctrlShowApplicationInfo1.TabIndex = 49;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1173, 624);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlShowApplicationInfo1);
            this.Controls.Add(this.pbTestTypeImage);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewTestAppointment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTestAppointments);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "frmListTestAppointments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointments";
            this.Load += new System.EventHandler(this.frmManageTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTestAppointments;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewTestAppointment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EditTestAppointmentItem;
        private System.Windows.Forms.ToolStripMenuItem TakeTestItem;
        private Applications.Controls.ctrlDrivingLicenseApplicationInfo ctrlShowApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}