using DVDL.BLL;
using DVDL.Desktop.License;
using DVDL.Desktop.People.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.InternationalLicenseApplication
{
    public partial class frmListInternationalLicensesApplications : Form
    {
        DataView _InternationalLicensesView;
        DataTable _dtInternationalLicenses = null;

        public frmListInternationalLicensesApplications()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicensesApplications.DataSource = _dtInternationalLicenses;
            _InternationalLicensesView = _dtInternationalLicenses.DefaultView;
        }

        private void _FilterBy(string ColumnName)
        {
            if(string.IsNullOrEmpty(ColumnName) || ColumnName == "None" || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _InternationalLicensesView.RowFilter = "";
                lblRecordsCount.Text = _InternationalLicensesView.Count.ToString();
                return;
            }

            _InternationalLicensesView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtFilterValue.Text.Trim());
            lblRecordsCount.Text = _InternationalLicensesView.Count.ToString();
        }

        private string _GetColumnName()
        {
            switch (cbFilterBy.Text)
            {
                case "International License ID": return InternationalLicenseID.Name;
                case "Application ID":           return ApplicationID.Name;
                case "Driver ID":                return DriverID.Name;
                case "License ID":               return LicenseID.Name;
            }
            
            return "";
        }

        private void frmListInternationalLicensesApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
            cbFilterBy.SelectedIndex = 0;
            cbFilterByActiveOrInActive.SelectedIndex = 0;
            lblRecordsCount.Text = _InternationalLicensesView.Count.ToString();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicenseApplication issueInternationalLicenseApplication =
                new frmIssueInternationalLicenseApplication();
            issueInternationalLicenseApplication.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                cbFilterByActiveOrInActive.Visible = false;

                if (_InternationalLicensesView != null)
                    _InternationalLicensesView.RowFilter = "";
                
                return;
            }

            else if(cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbFilterByActiveOrInActive.Visible = true;

                if (_InternationalLicensesView != null)
                    _InternationalLicensesView.RowFilter = "";

                return;
            }

            txtFilterValue.Visible = true;
            _InternationalLicensesView.RowFilter = "";
            cbFilterByActiveOrInActive.Visible = false;
            txtFilterValue.Clear();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "International License ID" || cbFilterBy.Text == "Driver ID" || 
                cbFilterBy.Text == "License ID" || cbFilterBy.Text == "Application ID")
            {
                    e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
            }
        }

        private void cbFilterByActiveOrInActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterByActiveOrInActive.Text == "All")
            {
                _InternationalLicensesView.RowFilter = "";
                lblRecordsCount.Text = _InternationalLicensesView.Count.ToString();
                return;
            }

            _InternationalLicensesView.RowFilter = string.Format("[{0}] = {1}", "IsActive", (cbFilterByActiveOrInActive.Text == "Yes" ? true : false));
            lblRecordsCount.Text = _InternationalLicensesView.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _FilterBy(_GetColumnName());
        }

        private void ShowPersonDetailsItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicensesApplications.CurrentRow.Cells["DriverID"].Value;
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo(clsLicense.FindByDriverID(DriverID).DriverInfo.PersonID);
            showPersonInfo.ShowDialog();
        }

        private void ShowLicenseDetailsItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvInternationalLicensesApplications.CurrentRow.Cells["LicenseID"].Value;
            frmShowLicense showLicense = new frmShowLicense(LicenseID);
            showLicense.ShowDialog();
        }

        private void ShowPersonLicenseHistoryItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicensesApplications.CurrentRow.Cells["DriverID"].Value;
            clsDriver DriverInfo = clsDriver.FindByDriverID(DriverID);

            if(DriverInfo != null)
            {
                frmShowPersonLicenseHistory showPersonLicenseHistory = new frmShowPersonLicenseHistory(DriverInfo.PersonID);
                showPersonLicenseHistory.ShowDialog();
            }
        }

        private void ShowInternationalLicenseDetailsItem_Click(object sender, EventArgs e)
        {
            frmShowDriverInternationalLicenseInfo showDriverInternationalLicenseInfo =
                new frmShowDriverInternationalLicenseInfo(
                    (int)dgvInternationalLicensesApplications.CurrentRow.Cells["InternationalLicenseID"].Value);
            showDriverInternationalLicenseInfo.ShowDialog();
        }
    }
}