using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.License;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.InternationalLicenseApplication
{
    public partial class frmIssueInternationalLicenseApplication : Form
    {
        private int _NewInternationalLicenseID = -1;

        public frmIssueInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmIssueInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationID.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblLocalLicenseID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense)).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            if(ctrlDriverLicenseInfoWithFilter1.LicenseID == -1)
            {
                btnIssueInternationalLicense.Enabled = false;
                llShowLicensesHistory.Enabled = false;
                return;
            }

            llShowLicensesHistory.Enabled = true;
            lblLocalLicenseID.Text = LicenseID.ToString();

            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License Is Expired, It Expired On {ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueInternationalLicense.Enabled = false;
                return;
            }

            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active, Choose An Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueInternationalLicense.Enabled = false;
                return;
            }

            if(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.Name != "Class 3 - Ordinary driving license")
            {
                MessageBox.Show
                    (
                        $"This License Is Not Class 3 - Ordinary driving license  = {LicenseID}",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                btnIssueInternationalLicense.Enabled = false;
                return;
            }

            int InternationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseByLicenseID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if(InternationalLicenseID != -1)
            {
                MessageBox.Show
                    (
                        $"Person Already Have An Active International License With ID = {InternationalLicenseID}",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                btnIssueInternationalLicense.Enabled = false;
                return;
            }

            btnIssueInternationalLicense.Enabled = true;
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense =
                clsInternationalLicense.IssueNewInternationalLicense
                (
                    ctrlDriverLicenseInfoWithFilter1.LicenseID, GlobalSettings.CurrentUser.UserID
                );

            if (InternationalLicense != null)
            {
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                _NewInternationalLicenseID = InternationalLicense.InternationalLicenseID;
                llShowNewLicenseInfo.Enabled = true;
                btnIssueInternationalLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                MessageBox.Show("Saved Data Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Saved Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //clsApplication Application = new clsApplication();
            //Application.ApplicationPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            //Application.ApplicationDate = DateTime.Now;
            //Application.ApplicationType = clsApplication.enApplicationType.NewInternationalLicense;
            //Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            //Application.LastStatusDate = DateTime.Now;
            //Application.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            //Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            //if(!Application.Save())
            //{
            //    MessageBox.Show("Saved Application Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //InternationalLicense.ApplicationID = Application.ApplicationID;
            //InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            //InternationalLicense.LicenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
            //InternationalLicense.IssueDate = DateTime.Now;
            //InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            //InternationalLicense.IsActive = true;
            //InternationalLicense.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            //if (InternationalLicense.Save())
            //{
            //    lblApplicationID.Text = Application.ApplicationID.ToString();
            //    lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            //    _NewInternationalLicenseID = InternationalLicense.InternationalLicenseID;
            //    MessageBox.Show("Saved Data Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //else
            //    MessageBox.Show("Saved Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverInternationalLicenseInfo showDriverInternationalLicenseInfo =
                new frmShowDriverInternationalLicenseInfo(_NewInternationalLicenseID);
            showDriverInternationalLicenseInfo.ShowDialog();
        }
    }
}