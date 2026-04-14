using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode { Add = 0, Update = 1 }
        private enMode _Mode = enMode.Add;

        public event Action DataBack;

        public event Action DataBackAfterUpdatePersonInfo;

        private int _UserID = -1;

        private clsUser _User = null;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text))
                errorProvider1.SetError(Temp, "This Filed Is Required");
            else
                errorProvider1.SetError(Temp, null);
        }

        public override bool ValidateChildren()
        {
            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrEmpty(txtUserName.Text) || !string.IsNullOrEmpty(errorProvider1.GetError(txtUserName)))
                ValidateEmptyTextBox(txtUserName, e);

            else if (string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrEmpty(errorProvider1.GetError(txtPassword)))
                ValidateEmptyTextBox(txtPassword, e);

            else if (string.IsNullOrEmpty(txtConfirmPassword.Text) || !string.IsNullOrEmpty(errorProvider1.GetError(txtConfirmPassword)))
                ValidateEmptyTextBox(txtConfirmPassword, e);

            else return true;

            return false;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.Add)
            {
                _User = new clsUser();
                lblTitle.Text = "Add New User";

                ctrlPersonCardWithFilter.Focus();
                tpLoginInfo.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnPersonInfoNext.Enabled = true;
                btnSave.Enabled = true;
            }

            ctrlPersonCardWithFilter.FilterEnabled = true;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbkIsActive.Checked = true;
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardWithFilter.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show($"No User With ID = {_UserID}", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = clsUtil.DecryptPassword(_User.Password);
            txtConfirmPassword.Text = txtPassword.Text;
            cbkIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter.LoadPersonInfo(_User.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadUserInfo();
        }




        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                ValidateEmptyTextBox(sender, e);

            else if (txtPassword.Text != txtConfirmPassword.Text)
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation Does Not Match Password");
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                ValidateEmptyTextBox(sender, e);
                return;
            }

            if(_Mode == enMode.Update)
            {
                if(_User != null)
                {
                    if (!(txtUserName.Text.Trim() != _User.UserName))
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtUserName, null);
                        return;
                    }
                }
            }

            if (clsUser.IsUserExist(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This User Name Used By Another User");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            // add mode
            if (ctrlPersonCardWithFilter.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter.PersonID))
                {
                    MessageBox.Show("Selected Person Already Has A User, Choose Another One.", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter.Focus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select A Person,", "Select A Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter.Focus();
            }
        }

        private void ctrlPersonCardWithFilter_OnPersonSelected(int PersonID)
        {
            if (PersonID != -1)
                btnPersonInfoNext.Enabled = true;

            else
                btnPersonInfoNext.Enabled = false;
        }

        private void ctrlPersonCardWithFilter_DataBackEventHandler() => DataBackAfterUpdatePersonInfo?.Invoke();

        private void tcUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tcUserInfo.SelectedIndex == 1 && IsPersonReadyForUserCreation())
            //{
            //    CheckAndMoveToUserInfoTab();
            //    tcUserInfo.SelectedIndex = 0;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Check Or Fill Fields Because Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.PersonInfo = ctrlPersonCardWithFilter.SelectedPersonInfo;
            _User.PersonID = ctrlPersonCardWithFilter.PersonID;
            _User.IsActive = (cbkIsActive.Checked ? true : false);

            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;

                lblTitle.Text = "Update User";

                lblUserID.Text = _User.UserID.ToString();

                if (DataBack != null)
                    DataBack();
            }

            else
                MessageBox.Show("Data Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowHidePassword(object sender, TextBox txtTemp)
        {
            CheckBox ckb = (CheckBox)sender;

            if(ckb != null)
            {
                if (ckb.Checked)
                    txtTemp.PasswordChar = '\0';
                else
                    txtTemp.PasswordChar = '*';
            }
        }

        private void ckbShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowHidePassword(sender, txtPassword);
        }

        private void ckbShowHideConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowHidePassword(sender, txtConfirmPassword);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}