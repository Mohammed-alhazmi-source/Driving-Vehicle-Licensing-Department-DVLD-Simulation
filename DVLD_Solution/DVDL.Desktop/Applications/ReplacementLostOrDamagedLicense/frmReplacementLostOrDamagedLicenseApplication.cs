using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.License;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.Replacement_For_License
{
    public partial class frmReplacementLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        private clsLicense.enIssueReason _IssueReason = clsLicense.enIssueReason.ReplacementForDamaged;

        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)clsApplication.enApplicationType.ReplacementForaDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplacementForaLostDrivingLicense;
        }


        public frmReplacementLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Damaged License";
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.ReplacementForaDamagedDrivingLicense)).ToString();
            _IssueReason = _IssueReason = clsLicense.enIssueReason.ReplacementForDamaged;
        }        

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Lost License";
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.ReplacementForaLostDrivingLicense)).ToString();
            _IssueReason = _IssueReason = clsLicense.enIssueReason.ReplacementForLost;
        }

        private void frmReplacementForLicense_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.ReplacementForaDamagedDrivingLicense)).ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            if(ctrlDriverLicenseInfoWithFilter1.LicenseID == -1)
            {
                llShowLicensesHistory.Enabled = false;
                lblOldLicenseID.Text = "[???]";
                btnIssueReplacement.Enabled = false;
                return;
            }

            llShowLicensesHistory.Enabled = true;
            lblOldLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License Is Not Yet Expired, It Will Expired On {ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active, Choose An Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show
                    (
                      $"This License Is Detained Before, Choose Another License",
                      "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                btnIssueReplacement.Enabled = false;
                return;
            }


            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if
                (
                    MessageBox.Show
                    (
                        "Are You Sure You Want To Issue A Replacement For The License?",
                        "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1
                    ) == DialogResult.OK
                )
            {
                clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_IssueReason, GlobalSettings.CurrentUser.UserID);

                if (NewLicense == null)
                {
                    MessageBox.Show("Doesn't License Replaced Successfully","Doesn't License Issued", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblApplicationID.Text = NewLicense.ApplicationID.ToString();
                lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                _NewLicenseID = NewLicense.LicenseID;
                MessageBox.Show("License Replaced Successfully With ID = " + _NewLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnIssueReplacement.Enabled = false;
                llShowNewLicenseInfo.Enabled = true;
                gbReplacements.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.Enabled = false;
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory(
                    ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID
                    );
            showPersonLicenseHistory.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(_NewLicenseID);
            showLicense.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}