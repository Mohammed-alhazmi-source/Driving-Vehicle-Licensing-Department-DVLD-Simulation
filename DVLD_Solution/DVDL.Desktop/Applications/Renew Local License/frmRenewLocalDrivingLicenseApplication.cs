using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.License.Renew_Local_License
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _InitializeLabelsForNewLicense()
        {
            lblRenewLocalApplicationID.Text = "[???]";
            lblRenewedLicenseID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblLicenseFees.Text = "[$$$]";
            lblOldLicenseID.Text = "[???]";
            lblTotalFees.Text = "[$$$]";
        }        

        private void _InitializeLabelsFromExistingLicense()
        {         
            lblLicenseFees.Text = ((int)ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.Fees).ToString();
            lblOldLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;
            lblTotalFees.Text = (Convert.ToInt32(lblApplicationFees.Text) + Convert.ToInt32(lblLicenseFees.Text)).ToString();
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.RenewDrivingLicenseService)).ToString();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {           
            if(ctrlDriverLicenseInfoWithFilter1.LicenseID == -1)
            {
                llShowLicensesHistory.Enabled = false;
                btnRenew.Enabled = false;
                _InitializeLabelsForNewLicense();
            }

            else
            {
                llShowLicensesHistory.Enabled = true;                
                _InitializeLabelsFromExistingLicense();

                if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
                {
                    MessageBox.Show("Selected License Is Not Active, Choose An Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnRenew.Enabled = false;
                    return;
                }
                
                if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
                {
                    MessageBox.Show($"Selected License Is Not Yet Expired, It Will Expired On {ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);                       
                    btnRenew.Enabled = false;
                    return;
                }

                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
                {
                    MessageBox.Show
                        (
                          $"This License Is Detained Before, Choose Another License",
                          "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    btnRenew.Enabled = false;
                    return;
                }

                btnRenew.Enabled = true;
            }
        }

        private void frmRenewLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense RenewLicenseInfo = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text, GlobalSettings.CurrentUser.UserID);

            if(RenewLicenseInfo == null)
            {
                MessageBox.Show($"License Issued Not Successfully", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblRenewedLicenseID.Text = RenewLicenseInfo.LicenseID.ToString();
            _NewLicenseID = RenewLicenseInfo.LicenseID;
            lblRenewLocalApplicationID.Text = RenewLicenseInfo.ApplicationID.ToString();
            MessageBox.Show($"License Issued Successfully With License ID = {RenewLicenseInfo.LicenseID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
            btnRenew.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowNewLicenseInfo.Enabled = true;
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense ShowLicense = new frmShowLicense(_NewLicenseID);
            ShowLicense.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}