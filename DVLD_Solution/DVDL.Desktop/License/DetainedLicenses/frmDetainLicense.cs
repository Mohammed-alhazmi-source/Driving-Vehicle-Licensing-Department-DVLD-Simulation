using DVDL.Desktop.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.License.DetainedOrReleaseLicenses
{
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID = -1;        

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        public frmDetainLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        public override bool ValidateChildren()
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                txtFineFees_Validating(txtFineFees, null);
                return false;

            }
            return true;
        }

        private void _DisabledControl()
        {
            llShowLicensesHistory.Enabled = (_LicenseID == -1 ? false : true);
            btnDetain.Enabled = false;
        }

        // في حال الرخصة تم حجزها من قبل نقوم بتحميل معلومات الحجز للرخصة
        private void _LoadDetainInfo()
        {
            lblDetianID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblDetianDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString("dd/MMM/yyyy");
            txtFineFees.Text = ((int)ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees).ToString();
            txtFineFees.ReadOnly = true;
        }

        // في حال اجراء البحث بعد رخصة محجوزة والرخصة الحالية ليست محجوزة نقوم بتفرغه معلومات الحجز للرخصة السابقة
        private void _InLoadDetainInfo()
        {
            lblDetianID.Text = "[???]";
            //lblDetianDate.Text = "[???]";
            txtFineFees.Clear();
            txtFineFees.ReadOnly = false;
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetianDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lblCreatedBy.Text = GlobalSettings.CurrentUser.UserName;


            if(_LicenseID == -1)
            {
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            }
            else
            {
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int LicenseID)
        {
            _LicenseID = LicenseID;

            if(_LicenseID == -1) // لايوجد رخصة بالرقم المدخل
            {
                lblLicenseID.Text = "[???]";
               _DisabledControl();
               _InLoadDetainInfo();
                return;
            }

            lblLicenseID.Text = _LicenseID.ToString();

            // الرخصة الحالية تم حجزها من قبل
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                _LoadDetainInfo();
                MessageBox.Show
                    (
                      $"This License Is Detained Before, Choose Another License",
                      "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                _DisabledControl();
                return;
            }

            // الرخصة غير نشطة
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show
                    (
                      $"This License Is Not Active, Choose Another License",
                      "License InActive", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                _DisabledControl();
                _LoadDetainInfo();
                return;
            }

            // هنا يعني ان الرخصة تجاوزت كل الشروط 
            _InLoadDetainInfo();
            llShowLicensesHistory.Enabled = true;
            btnDetain.Enabled = true;
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

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
                errorProvider1.SetError(txtFineFees, "This Filed Is Required");

            else
                errorProvider1.SetError(txtFineFees, null);
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("This Filed Is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int DetainID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal(txtFineFees.Text), GlobalSettings.CurrentUser.UserID);

            if (DetainID != -1)
            {
                lblDetianID.Text = DetainID.ToString();
                llShowLicenseInfo.Enabled = true;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnDetain.Enabled = false;
                MessageBox.Show("Detained License Successfully", "Detained Succussed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Detained License Failed", "Detained Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}