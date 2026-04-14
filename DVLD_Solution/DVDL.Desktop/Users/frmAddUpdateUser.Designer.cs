namespace DVDL.Desktop.Users
{
    partial class frmAddUpdateUser
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter = new DVDL.Desktop.People.Controls.ctrlPersonCardWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.ckbShowHideConfirmPassword = new System.Windows.Forms.CheckBox();
            this.ckbShowHidePassword = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cbkIsActive = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPersonInfoNext = new System.Windows.Forms.Button();
            this.tcUserInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(354, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(340, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Name:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblUserID.ForeColor = System.Drawing.Color.Black;
            this.lblUserID.Location = new System.Drawing.Point(464, 124);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(33, 19);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(371, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(279, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm Password:";
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tpPersonInfo);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Font = new System.Drawing.Font("Tahoma", 18F);
            this.tcUserInfo.Location = new System.Drawing.Point(9, 23);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(996, 512);
            this.tcUserInfo.TabIndex = 9;
            this.tcUserInfo.SelectedIndexChanged += new System.EventHandler(this.tcUserInfo_SelectedIndexChanged);
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.BackColor = System.Drawing.Color.White;
            this.tpPersonInfo.Controls.Add(this.btnPersonInfoNext);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter);
            this.tpPersonInfo.Font = new System.Drawing.Font("Tahoma", 5F);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 38);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(988, 470);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            // 
            // ctrlPersonCardWithFilter
            // 
            this.ctrlPersonCardWithFilter.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithFilter.FilterEnabled = true;
            this.ctrlPersonCardWithFilter.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.ctrlPersonCardWithFilter.Location = new System.Drawing.Point(21, 3);
            this.ctrlPersonCardWithFilter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ctrlPersonCardWithFilter.Name = "ctrlPersonCardWithFilter";
            this.ctrlPersonCardWithFilter.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter.Size = new System.Drawing.Size(953, 415);
            this.ctrlPersonCardWithFilter.TabIndex = 0;
            this.ctrlPersonCardWithFilter.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter_OnPersonSelected);
            this.ctrlPersonCardWithFilter.DataBackEventHandler += new System.Action(this.ctrlPersonCardWithFilter_DataBackEventHandler);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.White;
            this.tpLoginInfo.Controls.Add(this.ckbShowHideConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.ckbShowHidePassword);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.cbkIsActive);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.lblUserID);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 38);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(988, 470);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            // 
            // ckbShowHideConfirmPassword
            // 
            this.ckbShowHideConfirmPassword.AutoSize = true;
            this.ckbShowHideConfirmPassword.Location = new System.Drawing.Point(694, 281);
            this.ckbShowHideConfirmPassword.Name = "ckbShowHideConfirmPassword";
            this.ckbShowHideConfirmPassword.Size = new System.Drawing.Size(15, 14);
            this.ckbShowHideConfirmPassword.TabIndex = 10;
            this.ckbShowHideConfirmPassword.UseVisualStyleBackColor = true;
            this.ckbShowHideConfirmPassword.CheckedChanged += new System.EventHandler(this.ckbShowHideConfirmPassword_CheckedChanged);
            // 
            // ckbShowHidePassword
            // 
            this.ckbShowHidePassword.AutoSize = true;
            this.ckbShowHidePassword.Location = new System.Drawing.Point(694, 227);
            this.ckbShowHidePassword.Name = "ckbShowHidePassword";
            this.ckbShowHidePassword.Size = new System.Drawing.Size(15, 14);
            this.ckbShowHidePassword.TabIndex = 9;
            this.ckbShowHidePassword.UseVisualStyleBackColor = true;
            this.ckbShowHidePassword.CheckedChanged += new System.EventHandler(this.ckbShowHidePassword_CheckedChanged);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(468, 274);
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 30);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPassword.Location = new System.Drawing.Point(468, 221);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 30);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUserName.Location = new System.Drawing.Point(468, 165);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 30);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // cbkIsActive
            // 
            this.cbkIsActive.AutoSize = true;
            this.cbkIsActive.Checked = true;
            this.cbkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkIsActive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cbkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbkIsActive.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbkIsActive.Location = new System.Drawing.Point(468, 323);
            this.cbkIsActive.Name = "cbkIsActive";
            this.cbkIsActive.Size = new System.Drawing.Size(86, 23);
            this.cbkIsActive.TabIndex = 3;
            this.cbkIsActive.Text = "Is Active";
            this.cbkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 25F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(392, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 41);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Add New User";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnClose.Image = global::DVDL.Desktop.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(713, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 47);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSave.Image = global::DVDL.Desktop.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(861, 538);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 47);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPersonInfoNext
            // 
            this.btnPersonInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonInfoNext.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnPersonInfoNext.Image = global::DVDL.Desktop.Properties.Resources.Next_32;
            this.btnPersonInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPersonInfoNext.Location = new System.Drawing.Point(821, 417);
            this.btnPersonInfoNext.Name = "btnPersonInfoNext";
            this.btnPersonInfoNext.Size = new System.Drawing.Size(138, 47);
            this.btnPersonInfoNext.TabIndex = 52;
            this.btnPersonInfoNext.Text = "Next";
            this.btnPersonInfoNext.UseVisualStyleBackColor = true;
            this.btnPersonInfoNext.Click += new System.EventHandler(this.btnPersonInfoNext_Click);
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 596);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit User Info";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox cbkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox ckbShowHideConfirmPassword;
        private System.Windows.Forms.CheckBox ckbShowHidePassword;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPersonInfoNext;
    }
}