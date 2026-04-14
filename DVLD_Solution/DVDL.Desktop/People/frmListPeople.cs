using DVDL.BLL;
using DVDL.Desktop.People.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.People
{
    public partial class frmListPeople : Form
    {        
        private event Action<string> OnFilter;
        DataView  PeopleView;

        public frmListPeople()
        {
            InitializeComponent();
        }

        private void LoadPeople()
        {
            PeopleView = clsPerson.GetAllPeople().DefaultView;
            dgvPeople.DataSource = PeopleView;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            LoadPeople();
            lblRecords.Text = PeopleView.Count.ToString();
            cbFilterBy.SelectedIndex = 0;
        }
  
        void FilteringPeopleBy(string ColumnName)
        {
            if (string.IsNullOrEmpty(ColumnName) || (string.IsNullOrEmpty(txtValueFilter.Text)))
                     PeopleView.RowFilter = "";

            else if (cbFilterBy.SelectedItem.ToString() == "Person ID")
                PeopleView.RowFilter = $"{ColumnName} = '" + txtValueFilter.Text + "'";

            else
                PeopleView.RowFilter = $"{ColumnName} LIKE '%" + txtValueFilter.Text + "%'";

            dgvPeople.DataSource = PeopleView;
            lblRecords.Text = PeopleView.Count.ToString();
        }

        string GetColumnName(string ColumnText)
        {
            if (ColumnText == "None")
                return "";

            Dictionary<string, string> name = new Dictionary<string, string>()
            {
                {PersonID.HeaderText ,PersonID.Name},
                {FirstName.HeaderText ,FirstName.Name},
                {SecondName.HeaderText ,SecondName.Name},
                {ThirdName.HeaderText ,ThirdName.Name},
                {LastName.HeaderText ,LastName.Name},
                {NationalNo.HeaderText ,NationalNo.Name},
                {Gendor.HeaderText ,Gendor.Name},
                {Nationality.HeaderText ,Nationality.Name},
                {Phone.HeaderText ,Phone.Name},
                {Email.HeaderText ,Email.Name},
            };
            
            if (name.ContainsKey(ColumnText))
            {
                if (name.TryGetValue(ColumnText, out string ColumnName))
                    return ColumnName;
            }

            return "";
        }

        private void txtValueFilter_TextChanged(object sender, EventArgs e)
        {
            OnFilter += FilteringPeopleBy;
            OnFilter(GetColumnName(cbFilterBy.Text));
        }

        private void txtValueFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "Person ID" || cbFilterBy.SelectedItem.ToString() == "Phone")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson FrmAddPerson = new frmAddUpdatePerson();
            FrmAddPerson.OnSaved += RefreshLoadPeople;
            FrmAddPerson.ShowDialog();
        }

        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson FrmAddPerson = new frmAddUpdatePerson();            
            FrmAddPerson.OnSaved += RefreshLoadPeople;
            FrmAddPerson.ShowDialog();
        }

        private void EditPerson_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            frmAddUpdatePerson FrmUpdatePerson = new frmAddUpdatePerson(PersonID);
            FrmUpdatePerson.OnSaved += RefreshLoadPeople;
            FrmUpdatePerson.ShowDialog();
        }

        private void DeletePerson_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            if (clsPerson.IsPersonExist(PersonID))
            {
                if (
                    MessageBox.Show($"Are You Sure Want To Delete Person [{PersonID}]", "Confirm Delete",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    if (clsPerson.DeletePerson(PersonID))
                    {
                        MessageBox.Show("Person Deleted Successfully", "Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPeople();
                        return;
                    }

                    else
                    {
                        MessageBox.Show("Person Was Not Deleted Because It Has Data Linked To It.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show($"This Person ID {PersonID} Is Not Exists", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      
        private void ShowDetailsPerson_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvPeople.CurrentRow.Cells["PersonID"].Value);
            frmShowPersonInfo personDetails = new frmShowPersonInfo(PersonID);
            personDetails.DataBackEventHandler += RefreshLoadPeople;
            personDetails.ShowDialog();
        }

        private void RefreshLoadPeople()
        {
            LoadPeople();
        }

        private void SendEmailPerson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature IS Not Implemented It!", "Not Ready!",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PhoneCallPerson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature IS Not Implemented It!", "Not Ready!",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "None")
            {
                txtValueFilter.Visible = false;
                txtValueFilter.Text = "";
                return;
            }

            if (!string.IsNullOrEmpty(txtValueFilter.Text))
                txtValueFilter.Text = "";

            if (!txtValueFilter.Visible)
                txtValueFilter.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}