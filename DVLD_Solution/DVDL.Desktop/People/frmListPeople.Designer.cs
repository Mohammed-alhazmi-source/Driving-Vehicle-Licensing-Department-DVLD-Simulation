namespace DVDL.Desktop.People
{
    partial class frmListPeople
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeople));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowDetailsPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SendEmailPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneCallPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtValueFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.PersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailsPerson,
            this.toolStripSeparator1,
            this.AddNewPerson,
            this.EditPerson,
            this.DeletePerson,
            this.toolStripSeparator2,
            this.SendEmailPerson,
            this.PhoneCallPerson});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(236, 292);
            // 
            // ShowDetailsPerson
            // 
            this.ShowDetailsPerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.ShowDetailsPerson.Image = ((System.Drawing.Image)(resources.GetObject("ShowDetailsPerson.Image")));
            this.ShowDetailsPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowDetailsPerson.Name = "ShowDetailsPerson";
            this.ShowDetailsPerson.Size = new System.Drawing.Size(235, 46);
            this.ShowDetailsPerson.Text = "Show Details";
            this.ShowDetailsPerson.Click += new System.EventHandler(this.ShowDetailsPerson_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // AddNewPerson
            // 
            this.AddNewPerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.AddNewPerson.Image = ((System.Drawing.Image)(resources.GetObject("AddNewPerson.Image")));
            this.AddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewPerson.Name = "AddNewPerson";
            this.AddNewPerson.Size = new System.Drawing.Size(235, 46);
            this.AddNewPerson.Text = "Add New Person";
            this.AddNewPerson.Click += new System.EventHandler(this.AddNewPerson_Click);
            // 
            // EditPerson
            // 
            this.EditPerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.EditPerson.Image = ((System.Drawing.Image)(resources.GetObject("EditPerson.Image")));
            this.EditPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditPerson.Name = "EditPerson";
            this.EditPerson.Size = new System.Drawing.Size(235, 46);
            this.EditPerson.Text = "Edit";
            this.EditPerson.Click += new System.EventHandler(this.EditPerson_Click);
            // 
            // DeletePerson
            // 
            this.DeletePerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.DeletePerson.Image = ((System.Drawing.Image)(resources.GetObject("DeletePerson.Image")));
            this.DeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeletePerson.Name = "DeletePerson";
            this.DeletePerson.Size = new System.Drawing.Size(235, 46);
            this.DeletePerson.Text = "Delete";
            this.DeletePerson.Click += new System.EventHandler(this.DeletePerson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // SendEmailPerson
            // 
            this.SendEmailPerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.SendEmailPerson.Image = ((System.Drawing.Image)(resources.GetObject("SendEmailPerson.Image")));
            this.SendEmailPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SendEmailPerson.Name = "SendEmailPerson";
            this.SendEmailPerson.Size = new System.Drawing.Size(235, 46);
            this.SendEmailPerson.Text = "Send Email";
            this.SendEmailPerson.Click += new System.EventHandler(this.SendEmailPerson_Click);
            // 
            // PhoneCallPerson
            // 
            this.PhoneCallPerson.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.PhoneCallPerson.Image = ((System.Drawing.Image)(resources.GetObject("PhoneCallPerson.Image")));
            this.PhoneCallPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PhoneCallPerson.Name = "PhoneCallPerson";
            this.PhoneCallPerson.Size = new System.Drawing.Size(235, 46);
            this.PhoneCallPerson.Text = "Phone Call";
            this.PhoneCallPerson.Click += new System.EventHandler(this.PhoneCallPerson_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblRecords.Font = new System.Drawing.Font("Tahoma", 14F);
            this.lblRecords.ForeColor = System.Drawing.Color.Black;
            this.lblRecords.Location = new System.Drawing.Point(130, 567);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(28, 23);
            this.lblRecords.TabIndex = 5;
            this.lblRecords.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filter By:";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Tahoma", 25F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(516, 148);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(221, 42);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "Manage People";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderColor = System.Drawing.Color.Black;
            this.cbFilterBy.BorderRadius = 10;
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gendor",
            "Nationality",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(112, 228);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(191, 36);
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.TabIndex = 35;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.BorderColor = System.Drawing.Color.Black;
            this.txtValueFilter.BorderRadius = 5;
            this.txtValueFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.txtValueFilter.Location = new System.Drawing.Point(310, 228);
            this.txtValueFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.PasswordChar = '\0';
            this.txtValueFilter.PlaceholderText = "Search Here";
            this.txtValueFilter.SelectedText = "";
            this.txtValueFilter.Size = new System.Drawing.Size(321, 36);
            this.txtValueFilter.TabIndex = 43;
            this.txtValueFilter.Visible = false;
            this.txtValueFilter.TextChanged += new System.EventHandler(this.txtValueFilter_TextChanged);
            this.txtValueFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueFilter_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL.Desktop.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(534, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVDL.Desktop.Properties.Resources.Add_Person_72;
            this.btnAddPerson.Location = new System.Drawing.Point(1142, 184);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(92, 82);
            this.btnAddPerson.TabIndex = 44;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonID,
            this.NationalNo,
            this.FirstName,
            this.SecondName,
            this.ThirdName,
            this.LastName,
            this.DateOfBirth,
            this.Gendor,
            this.Nationality,
            this.Phone,
            this.Email});
            this.dgvPeople.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeople.Location = new System.Drawing.Point(27, 272);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.Size = new System.Drawing.Size(1207, 292);
            this.dgvPeople.TabIndex = 45;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1088, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 34);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PersonID
            // 
            this.PersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonID.DataPropertyName = "PersonID";
            this.PersonID.DividerWidth = 1;
            this.PersonID.HeaderText = "Person ID";
            this.PersonID.Name = "PersonID";
            this.PersonID.ReadOnly = true;
            // 
            // NationalNo
            // 
            this.NationalNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.DividerWidth = 1;
            this.NationalNo.HeaderText = "National No.";
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.DividerWidth = 1;
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 110;
            // 
            // SecondName
            // 
            this.SecondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SecondName.DataPropertyName = "SecondName";
            this.SecondName.DividerWidth = 1;
            this.SecondName.HeaderText = "Second Name";
            this.SecondName.Name = "SecondName";
            this.SecondName.ReadOnly = true;
            // 
            // ThirdName
            // 
            this.ThirdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ThirdName.DataPropertyName = "ThirdName";
            this.ThirdName.DividerWidth = 1;
            this.ThirdName.HeaderText = "Third Name";
            this.ThirdName.Name = "ThirdName";
            this.ThirdName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LastName.DataPropertyName = "LastName";
            this.LastName.DividerWidth = 1;
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.DividerWidth = 1;
            this.DateOfBirth.HeaderText = "Date Of Birth";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 150;
            // 
            // Gendor
            // 
            this.Gendor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Gendor.DataPropertyName = "Gendor";
            this.Gendor.DividerWidth = 1;
            this.Gendor.HeaderText = "Gendor";
            this.Gendor.Name = "Gendor";
            this.Gendor.ReadOnly = true;
            // 
            // Nationality
            // 
            this.Nationality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nationality.DataPropertyName = "Nationality";
            this.Nationality.DividerWidth = 1;
            this.Nationality.HeaderText = "Nationality";
            this.Nationality.Name = "Nationality";
            this.Nationality.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Phone.DataPropertyName = "Phone";
            this.Phone.DividerWidth = 1;
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Email.DataPropertyName = "Email";
            this.Email.DividerWidth = 1;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 608);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.txtValueFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "frmListPeople";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsPerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem EditPerson;
        private System.Windows.Forms.ToolStripMenuItem DeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SendEmailPerson;
        private System.Windows.Forms.ToolStripMenuItem PhoneCallPerson;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2TextBox txtValueFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}