using DVDL.BLL;
using DVDL.Desktop.Applications.InternationalLicenseApplication;
using DVDL.Desktop.License.DetainedOrReleaseLicenses;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.License.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDriver _Driver = null;

        private DataTable _dtDriverLocalLicensesHistory = null;
        private DataTable _dtDriverInternationalLicensesHistory = null;

        private void _InitializeColumnsForLocalDrivingLicensesApplications()
        {
            if (dgvLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";
                dgvLocalLicenses.Columns[0].Width = 100;

                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[1].Width = 120;

                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].Width = 240;

                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].Width = 150;

                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[4].Width = 150;

                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[5].Width = 100;

                lblLocalLicensesRecordsCount.Text = dgvLocalLicenses.Rows.Count.ToString();
            }
        }

        private void _LoadLocalLicensesInfo()
        {
            _dtDriverLocalLicensesHistory = clsDriver.GetLicense(_DriverID);

            if (_dtDriverLocalLicensesHistory == null)
            {
                _DriverID = -1;
                return;
            }

            dgvLocalLicenses.DataSource = _dtDriverLocalLicensesHistory;
            _InitializeColumnsForLocalDrivingLicensesApplications();
        }

        private void _InitializeColumnsForInternationalLicenses()
        {
            if (dgvInternalLicenses.Rows.Count > 0)
            {
                dgvInternalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternalLicenses.Columns[0].Width = 100;

                dgvInternalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternalLicenses.Columns[1].Width = 120;

                dgvInternalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternalLicenses.Columns[2].Width = 120;

                dgvInternalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternalLicenses.Columns[3].Width = 300;
                
                dgvInternalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternalLicenses.Columns[4].Width = 305;
                
                dgvInternalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternalLicenses.Columns[5].Width = 100;

                lblInternationalLicensesRecordsCount.Text = dgvInternalLicenses.Rows.Count.ToString();
            }
        }

        private void _LoadInternationalLicensesInfo()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);

            if(_dtDriverInternationalLicensesHistory == null)
            {
                _DriverID = -1;
                return;
            }

            dgvInternalLicenses.DataSource = _dtDriverInternationalLicensesHistory;
            _InitializeColumnsForInternationalLicenses();
        }

        public void LoadInfoByDriverID(int DriverID)
        {
            _Driver = clsDriver.FindByDriverID(DriverID);

            if(_Driver == null)
            {
                MessageBox.Show("There Is No Driver With ID = " + DriverID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = DriverID;

            _LoadLocalLicensesInfo();
            _LoadInternationalLicensesInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if(_Driver == null)
            {
                MessageBox.Show("There Is No Driver Linked With Person With ID = " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;
            _LoadLocalLicensesInfo();
            _LoadInternationalLicensesInfo();
        }

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();
        }

        private void ShowLocalLicenseInfoItem_Click(object sender, EventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            showLicense.ShowDialog();
        }

        private void ShowInternationalLicenseItem_Click(object sender, EventArgs e)
        {
            frmShowDriverInternationalLicenseInfo showDriverInternationalLicenseInfo
                    = new frmShowDriverInternationalLicenseInfo((int)dgvInternalLicenses.CurrentRow.Cells[0].Value);
            showDriverInternationalLicenseInfo.ShowDialog();
        }

        private void DetainLicenseItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            detainLicense.ShowDialog();
        }
    }
}