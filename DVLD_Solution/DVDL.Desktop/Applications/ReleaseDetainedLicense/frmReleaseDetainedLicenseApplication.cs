using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.License.DetainedOrReleaseLicenses
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _LicenseID = -1;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void _ResetDefaultValuesForDetainLicenseInfo()
        {
            lblDetianID.Text = "[???]";
            lblDetianDate.Text = "[???]";
            lblFineFees.Text = "[$$$]";
            lblLicenseID.Text = "[???]";
            lblIsReleased.Text = "[???]";
            lblReleaseDate.Text = "[???]";
            lblTotalFees.Text = "[???]";
            lblApplicationID.Text = "[???]";
        }

        private void _LoadDetainLicenseInfo()
        {
            lblDetianID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblDetianDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString("dd/MMM/yyyy");
            lblFineFees.Text = ((int)ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees).ToString();
            lblLicenseID.Text = _LicenseID.ToString();
            lblIsReleased.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.IsReleased ? "Yes" : "No";
            lblCreatedBy.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblTotalFees.Text = (Convert.ToInt32(lblFineFees.Text) + Convert.ToInt32(lblApplicationFees.Text)).ToString();
        }

        private void _DisabledControl()
        {
            llShowLicensesHistory.Enabled = (_LicenseID == -1 ? false : true);
            btnRelease.Enabled = false;
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense)).ToString();
            lblReleasedBy.Text = GlobalSettings.CurrentUser.UserName;

            if (_LicenseID == -1)
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;

            else
            {
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                _LoadDetainLicenseInfo();
            }
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            _LicenseID = LicenseID;

            if(_LicenseID == -1)
            {
                _DisabledControl();
                _ResetDefaultValuesForDetainLicenseInfo();
                return;
            }

            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License Is Not Detained, Choose Another License", "Not Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _DisabledControl();
                _ResetDefaultValuesForDetainLicenseInfo();
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This License Is Not Active, Choose Another License", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _DisabledControl();
                return;
            }

            _LoadDetainLicenseInfo();
            llShowLicensesHistory.Enabled = true;
            btnRelease.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int ReleaseApplicationID = -1;

            bool IsReleased = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense
                                (
                                    GlobalSettings.CurrentUser.UserID, ref ReleaseApplicationID
                                );


            if(ReleaseApplicationID != -1 && IsReleased)
            {
                MessageBox.Show
                    (
                        "Released License Successfully", "Released Succussed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

                lblApplicationID.Text = ReleaseApplicationID.ToString();
                lblIsReleased.Text = IsReleased ? "Yes" : "No";
                lblReleaseDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.ReleaseDate?.ToString("dd/MMM/yyyy");
                btnRelease.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                llShowLicenseInfo.Enabled = true;
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(_LicenseID);
            showLicense.ShowDialog();
        }
    }
}