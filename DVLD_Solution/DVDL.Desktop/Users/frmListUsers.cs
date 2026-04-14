using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVDL.Desktop.Users
{
    public partial class frmListUsers : Form
    {
        DataView UsersView;
        private event Action<string> OnFilterBy;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void LoadUsers()
        {
            UsersView = clsUser.GetAllUsers().DefaultView;
            dgvUsers.DataSource = UsersView;
        }

        private void FilterDataBy(string Column)
        {
            if (string.IsNullOrEmpty(Column) || Column == "None" || string.IsNullOrEmpty(txtValueFilter.Text.Trim()))
                UsersView.RowFilter = "";

            else if (Column == UserID.Name || Column == PersonID.Name)
                UsersView.RowFilter = string.Format("[{0}] = {1}", Column, txtValueFilter.Text);

            else
                UsersView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", Column, txtValueFilter.Text);
          
            dgvUsers.DataSource = UsersView;
            lblRecordsCount.Text = UsersView.Count.ToString();
        }

        private string GetColumnName()
        {
            Dictionary<string, string> Columns = new Dictionary<string, string>
            {
                {UserID.HeaderText, UserID.Name },
                {UserName.HeaderText, UserName.Name },
                {PersonID.HeaderText, PersonID.Name },
                {FullName.HeaderText, FullName.Name },
                {IsActive.HeaderText, IsActive.Name },
            };

            if (Columns.TryGetValue(cbFilterBy.Text, out string ColumnName))
                return ColumnName;

            return "";
        }

        private void FilterDataByFlagIsActive(string Column)
        {
            if (cbFilterIsActive.Text == "All")
                UsersView.RowFilter = "";

            else
                UsersView.RowFilter = string.Format("[{0}] = {1}", Column, cbFilterIsActive.Text);

            dgvUsers.DataSource = UsersView;
            lblRecordsCount.Text = UsersView.Count.ToString();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
            cbFilterBy.SelectedIndex = 0;
            cbFilterIsActive.SelectedIndex = 0;
            lblRecordsCount.Text = UsersView.Count.ToString();        
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                UsersView.RowFilter = "";
                txtValueFilter.Visible = false;
                cbFilterIsActive.Visible = false;
                return;
            }

            if (cbFilterBy.Text == "Is Active")
            {
                txtValueFilter.Visible = false;
                cbFilterIsActive.Visible = true;
                UsersView.RowFilter = "";
                return;
            }

            UsersView.RowFilter = "";
            cbFilterIsActive.Visible = false;
            txtValueFilter.Visible = true;
            txtValueFilter.ResetText();
        }

        private void txtValueFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void txtValueFilter_TextChanged(object sender, EventArgs e)
        {
            OnFilterBy += FilterDataBy;
            OnFilterBy(GetColumnName());
            OnFilterBy -= FilterDataBy;
        }

        private void cbFilterIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterBy += FilterDataByFlagIsActive;
            OnFilterBy(GetColumnName());
            OnFilterBy -= FilterDataByFlagIsActive;
        }

        private void DataBack() => LoadUsers();

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser AddNewUser = new frmAddUpdateUser();
            AddNewUser.DataBack += DataBack;
            AddNewUser.ShowDialog();
        }

        private void ShowDetailsItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo showUserInfo = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            showUserInfo.DataBack += DataBack;
            showUserInfo.ShowDialog();
        }

        private void AddNewUserItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser addNewUser = new frmAddUpdateUser();
            addNewUser.DataBack += DataBack;
            addNewUser.ShowDialog();
        }

        private void EditUserItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser updateUser = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            updateUser.DataBack += DataBack;
            updateUser.DataBackAfterUpdatePersonInfo += DataBack;
            updateUser.ShowDialog();
        }

        private void DeleteUserItem_Click(object sender, EventArgs e)
        {
            if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Has Been Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                lblRecordsCount.Text = UsersView.Count.ToString();
            }

            else
                MessageBox.Show("User Is Not Deleted Due To Data Connected To It", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ChangePasswordItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }

        private void SendEmailItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implementation","Not Ready",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PhoneCallItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implementation", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}