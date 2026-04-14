using DVDL.BLL;
using DVDL.Desktop.Classes;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;

        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        public override bool ValidateChildren()
        {
            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
                ValidateEmptyTextBox(txtCurrentPassword, e);

            else if (string.IsNullOrEmpty(txtNewPassword.Text))
                ValidateEmptyTextBox(txtNewPassword, e);
            
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                ValidateEmptyTextBox(txtConfirmPassword, e);

            else
                return true;

            return false;
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void _ShowHidePassword(object senderCheckBox, object senderTextBox)
        {
            CheckBox ckb = (CheckBox)senderCheckBox;
            Guna2TextBox txt = (Guna2TextBox)senderTextBox;

            if (ckb.Checked)
                txt.PasswordChar = '\0';
            else
                txt.PasswordChar = '*';
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text))
                errorProvider1.SetError(Temp, "This Filed Is Required");
            else
                errorProvider1.SetError(Temp, null);
        }

        private void btnCloseForm_Click(object sender, EventArgs e) => this.Close();

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            ctrlUserCard1.LoadUserInfo(_UserID);

            if (ctrlUserCard1.UserID == -1)
            {
                MessageBox.Show("User with ID = " + _UserID.ToString() + " was not found.", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
                ValidateEmptyTextBox(sender, e);

            else if (clsUser.ComputeHast(txtCurrentPassword.Text) != ctrlUserCard1.SelectedUserInfo.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password Is Wrong");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e) => ValidateEmptyTextBox(sender, e);

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                ValidateEmptyTextBox(sender, e);

            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation\nDoes Not Match Password");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("This Filed Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlUserCard1.SelectedUserInfo.Password = clsUtil.EncryptPassword(txtNewPassword.Text);

            if (ctrlUserCard1.SelectedUserInfo.ChangePassword(ctrlUserCard1.UserID, ctrlUserCard1.SelectedUserInfo.Password))
            {
                MessageBox.Show("Changed Password Successfully", "Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();
            }
            else
                MessageBox.Show("Changed Password Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void ckbShowHideCurrentPassword_CheckedChanged(object sender, EventArgs e)
        {
            _ShowHidePassword(sender, txtCurrentPassword);
        }

        private void ckbShowHideNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            _ShowHidePassword(sender, txtNewPassword);
        }

        private void ckbShowHideConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            _ShowHidePassword(sender, txtConfirmPassword);
        }
    }
}