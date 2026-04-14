using DVDL.BLL;
using DVDL.Desktop.Classes;

using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public override bool ValidateChildren()
        {
            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrEmpty(txtUserName.Text))
            {                
                ValidateEmptyTextBox(txtUserName, e);
                txtUserName.Focus();
                return true;
            }

            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ValidateEmptyTextBox(txtPassword, e);
                txtPassword.Focus();
                return true;
            }

            return false;
        }

        private void _ResetDefaultValues()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox Temp = (Guna2TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text))
                errorProvider1.SetError(Temp, "This Filed Is Required");

            else
                errorProvider1.SetError(Temp, null);
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserName.Focus();

            string UserName = "", Password = "";

            if(GlobalSettings.GetStoredCredential(ref UserName,ref Password))
            {
                cbkRememberme.Checked = true;
                txtUserName.Text = UserName;
                txtPassword.Text = clsUtil.Decrypt(Password);
            }
            else
            {
                cbkRememberme.Checked = false;
                txtUserName.Clear();
                txtPassword.Clear();
            }
        }

        private void cbk_Show_Hide_Password_CheckedChanged(object sender, EventArgs e)
        {
            if (cbk_Show_Hide_Password.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e) => ValidateEmptyTextBox(sender, e);

        private void txtPassword_Validating(object sender, CancelEventArgs e) => ValidateEmptyTextBox(sender, e);

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            if (this.ValidateChildren())
            {
                MessageBox.Show("This Fields Is Required", "Fill Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValues();
                return;
            }

            try
            {
                clsUser User = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), clsUser.ComputeHast(txtPassword.Text.Trim()));

                if (User != null)
                {
                    if (!User.IsActive)
                    {
                        MessageBox.Show("Your Account Is Not Active, Contact Admin.", "In Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _ResetDefaultValues();
                        return;
                    }

                    if (cbkRememberme.Checked)
                        GlobalSettings.RememberUsernameAndPassword(txtUserName.Text.Trim(), clsUtil.Encrypt(txtPassword.Text.Trim()));
                    else
                        GlobalSettings.DeleteUserAccountFromRegistry();

                    GlobalSettings.CurrentUser = User;
                    frmMain main = new frmMain(this);
                    this.Hide();
                    main.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Invalid UserName Or Password", "Wrong Creational", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _ResetDefaultValues();
                }
            }
            catch (Exception ex)
            {
                clsLogHandler.Log("UI - frmLogin", ex.Message);
            }
        }       
    }
}