using DVDL.BLL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.License.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set 
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public event Action<int> OnLicenseSelected;       

        private int _LicenseID = -1;

        public int LicenseID => ctrlDriverLicenseInfo1.LicenseID;

        public clsLicense SelectedLicenseInfo => ctrlDriverLicenseInfo1.SelectedLicenseInfo;

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilterValue.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);
        }

        public override bool ValidateChildren()
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
                return false;

            return true;
        }

        public void txtLicenseIDFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtFilterValue.Text))
                btnFindLicenseInfo.PerformClick();

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
                errorProvider1.SetError(txtFilterValue, "Selected License ID");

            else
                errorProvider1.SetError(txtFilterValue, null);
        }

        private void btnFindLicenseInfo_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            _LicenseID = Convert.ToInt32(txtFilterValue.Text.Trim());
            LoadLicenseInfo(_LicenseID);
        }
    }
}