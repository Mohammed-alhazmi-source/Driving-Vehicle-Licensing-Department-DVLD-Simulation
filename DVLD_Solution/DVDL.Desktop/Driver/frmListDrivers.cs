using DVDL.BLL;
using DVDL.Desktop.License;
using DVDL.Desktop.People.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.Driver
{
    public partial class frmListDrivers : Form
    {
        private DataView _DriversView;
        private event Action<string> OnFilterBy;


        public frmListDrivers()
        {
            InitializeComponent();
        }


        private void _LoadDriversInfo()
        {
            _DriversView = clsDriver.GetAllDrivers().DefaultView;
            dgvDrivers.DataSource = _DriversView;
        }

        private string GetColumnName()
        {
            Dictionary<string, string> Columns = new Dictionary<string, string>
            {
                {DriverID.HeaderText,DriverID.Name },
                {PersonID.HeaderText, PersonID.Name },
                {NationalNo.HeaderText, NationalNo.Name },
                {FullName.HeaderText, FullName.Name }
            };

            if (Columns.TryGetValue(cbFilterBy.Text, out string ColumnName))
                return ColumnName;

            return "";
        }

        private void _FilterBy(string Column)
        {
            if(string.IsNullOrEmpty(Column) || Column == "None" || string.IsNullOrEmpty(txtValueFilter.Text))
            {
                _DriversView.RowFilter = "";
                lblRecordsCount.Text = _DriversView.Count.ToString();
                return;
            }

            if (Column == DriverID.Name || Column == PersonID.Name)
                _DriversView.RowFilter = string.Format("[{0}] = {1}", Column, txtValueFilter.Text);

            else
                _DriversView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", Column, txtValueFilter.Text);

            dgvDrivers.DataSource = _DriversView;
            lblRecordsCount.Text = _DriversView.Count.ToString();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _LoadDriversInfo();
            lblRecordsCount.Text = _DriversView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                txtValueFilter.Visible = false;
                _DriversView.RowFilter = "";
                lblRecordsCount.Text = _DriversView.Count.ToString();
                return;
            }

            txtValueFilter.Visible = true;
            txtValueFilter.Clear();
        }

        private void txtValueFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void txtValueFilter_TextChanged(object sender, EventArgs e)
        {
            OnFilterBy += _FilterBy;
            OnFilterBy(GetColumnName());
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void ShowPersonInfoItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo((int)dgvDrivers.CurrentRow.Cells[1].Value);
            showPersonInfo.DataBackEventHandler += _LoadDriversInfo;
            showPersonInfo.ShowDialog();
        }

        private void IssueInternationalLicenseItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowPersonLicenseHistoryItem_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory((int)dgvDrivers.CurrentRow.Cells["PersonID"].Value);
            showPersonLicenseHistory.ShowDialog();
        }
    }
}