namespace DVDL.Desktop.Users
{
    partial class frmListUsers
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowDetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddNewUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteUserItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SendEmailItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneCallItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.cbFilterIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtValueFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailsItem,
            this.toolStripSeparator1,
            this.AddNewUserItem,
            this.EditUserItem,
            this.DeleteUserItem,
            this.ChangePasswordItem,
            this.toolStripSeparator2,
            this.SendEmailItem,
            this.PhoneCallItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 282);
            // 
            // ShowDetailsItem
            // 
            this.ShowDetailsItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowDetailsItem.Image = global::DVDL.Desktop.Properties.Resources.PersonDetails_32;
            this.ShowDetailsItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowDetailsItem.Name = "ShowDetailsItem";
            this.ShowDetailsItem.Size = new System.Drawing.Size(216, 38);
            this.ShowDetailsItem.Text = "Show Details";
            this.ShowDetailsItem.Click += new System.EventHandler(this.ShowDetailsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // AddNewUserItem
            // 
            this.AddNewUserItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.AddNewUserItem.Image = global::DVDL.Desktop.Properties.Resources.Add_New_User_32;
            this.AddNewUserItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddNewUserItem.Name = "AddNewUserItem";
            this.AddNewUserItem.Size = new System.Drawing.Size(216, 38);
            this.AddNewUserItem.Text = "Add New User";
            this.AddNewUserItem.Click += new System.EventHandler(this.AddNewUserItem_Click);
            // 
            // EditUserItem
            // 
            this.EditUserItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.EditUserItem.Image = global::DVDL.Desktop.Properties.Resources.Edit_User_32;
            this.EditUserItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditUserItem.Name = "EditUserItem";
            this.EditUserItem.Size = new System.Drawing.Size(216, 38);
            this.EditUserItem.Text = "Edit";
            this.EditUserItem.Click += new System.EventHandler(this.EditUserItem_Click);
            // 
            // DeleteUserItem
            // 
            this.DeleteUserItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DeleteUserItem.Image = global::DVDL.Desktop.Properties.Resources.Delete_User_32;
            this.DeleteUserItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteUserItem.Name = "DeleteUserItem";
            this.DeleteUserItem.Size = new System.Drawing.Size(216, 38);
            this.DeleteUserItem.Text = "Delete";
            this.DeleteUserItem.Click += new System.EventHandler(this.DeleteUserItem_Click);
            // 
            // ChangePasswordItem
            // 
            this.ChangePasswordItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ChangePasswordItem.Image = global::DVDL.Desktop.Properties.Resources.Password_32;
            this.ChangePasswordItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ChangePasswordItem.Name = "ChangePasswordItem";
            this.ChangePasswordItem.Size = new System.Drawing.Size(216, 38);
            this.ChangePasswordItem.Text = "Change Password";
            this.ChangePasswordItem.Click += new System.EventHandler(this.ChangePasswordItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // SendEmailItem
            // 
            this.SendEmailItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SendEmailItem.Image = global::DVDL.Desktop.Properties.Resources.send_email_32;
            this.SendEmailItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SendEmailItem.Name = "SendEmailItem";
            this.SendEmailItem.Size = new System.Drawing.Size(216, 38);
            this.SendEmailItem.Text = "Send Email";
            this.SendEmailItem.Click += new System.EventHandler(this.SendEmailItem_Click);
            // 
            // PhoneCallItem
            // 
            this.PhoneCallItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PhoneCallItem.Image = global::DVDL.Desktop.Properties.Resources.call_32;
            this.PhoneCallItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PhoneCallItem.Name = "PhoneCallItem";
            this.PhoneCallItem.Size = new System.Drawing.Size(216, 38);
            this.PhoneCallItem.Text = "Phone Call";
            this.PhoneCallItem.Click += new System.EventHandler(this.PhoneCallItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 609);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 15F);
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(147, 609);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 24);
            this.lblRecordsCount.TabIndex = 8;
            this.lblRecordsCount.Text = "??";
            // 
            // cbFilterIsActive
            // 
            this.cbFilterIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterIsActive.BorderColor = System.Drawing.Color.Black;
            this.cbFilterIsActive.BorderRadius = 10;
            this.cbFilterIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterIsActive.ForeColor = System.Drawing.Color.Black;
            this.cbFilterIsActive.ItemHeight = 30;
            this.cbFilterIsActive.Items.AddRange(new object[] {
            "All",
            "True",
            "False"});
            this.cbFilterIsActive.Location = new System.Drawing.Point(315, 239);
            this.cbFilterIsActive.Name = "cbFilterIsActive";
            this.cbFilterIsActive.Size = new System.Drawing.Size(117, 36);
            this.cbFilterIsActive.StartIndex = 0;
            this.cbFilterIsActive.TabIndex = 43;
            this.cbFilterIsActive.Visible = false;
            this.cbFilterIsActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterIsActive_SelectedIndexChanged);
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
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "User Name",
            "Person ID",
            "Full Name",
            "Is Active"});
            this.cbFilterBy.Location = new System.Drawing.Point(119, 239);
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
            this.txtValueFilter.Location = new System.Drawing.Point(315, 239);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(389, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 41);
            this.label1.TabIndex = 44;
            this.label1.Text = "Manage Users";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVDL.Desktop.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(386, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Image = global::DVDL.Desktop.Properties.Resources.Add_New_User_72;
            this.btnAddNewUser.Location = new System.Drawing.Point(868, 184);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(112, 85);
            this.btnAddNewUser.TabIndex = 46;
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(841, 610);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 41);
            this.btnClose.TabIndex = 47;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.PersonID,
            this.FullName,
            this.UserName,
            this.IsActive});
            this.dgvUsers.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsers.Location = new System.Drawing.Point(35, 282);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Size = new System.Drawing.Size(945, 322);
            this.dgvUsers.TabIndex = 48;
            // 
            // UserID
            // 
            this.UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "User ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // PersonID
            // 
            this.PersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonID.DataPropertyName = "PersonID";
            this.PersonID.HeaderText = "Person ID";
            this.PersonID.Name = "PersonID";
            this.PersonID.ReadOnly = true;
            this.PersonID.Width = 120;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 300;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 230;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            this.IsActive.HeaderText = "Is Active";
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            // 
            // frmListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 661);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterIsActive);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValueFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListUsers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmListUsers_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private Guna.UI2.WinForms.Guna2TextBox txtValueFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterIsActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AddNewUserItem;
        private System.Windows.Forms.ToolStripMenuItem EditUserItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteUserItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SendEmailItem;
        private System.Windows.Forms.ToolStripMenuItem PhoneCallItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsActive;
    }
}