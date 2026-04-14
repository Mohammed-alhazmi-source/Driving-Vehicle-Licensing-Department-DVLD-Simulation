using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.License
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalAppID = -1;

        public event Action DataBack;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        public frmIssueDriverLicenseFirstTime(int localAppID)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application With ID = {_LocalAppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show($"Person Already Has License Before With License ID = {LicenseID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlShowApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalAppID);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime
                                    (txtNotes.Text, GlobalSettings.CurrentUser.UserID);
            if (LicenseID != -1)
            {
                MessageBox.Show
                    (
                        $"License Issued Successfully With License ID = {LicenseID}",
                        "Succeeded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                this.Close();

                if (DataBack != null)
                    DataBack();
            }

            else
            {
                MessageBox.Show
                    (
                        $"License Issued Failed With License ID = {LicenseID}",
                        "Fielded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }
    }
}