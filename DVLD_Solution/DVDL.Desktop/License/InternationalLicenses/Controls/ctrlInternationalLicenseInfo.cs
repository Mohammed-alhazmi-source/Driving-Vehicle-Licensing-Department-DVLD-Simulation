using DVDL.BLL;
using DVDL.Desktop.Properties;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.InternationalLicenseApplication
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        public int InternationalLicenseID => _InternationalLicenseID;

        private enum enGender { Male = 0, Female = 1};

        private clsInternationalLicense _InternationalLicenseInfo = null;
        public clsInternationalLicense SelectedInternationalLicenseInfo => _InternationalLicenseInfo;

        private void _ResetDefaultValues()
        {
            lblPersonName.Text = "[???]";
            lblInternationalLicenseID.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblApplicationID.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            pbImagePerson.Image = Resources.Male_512;

        }

        private void _LoadPersonImage()
        {
            if (string.IsNullOrEmpty(_InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath))
            {
                if (_InternationalLicenseInfo.DriverInfo.PersonInfo.Gender == (byte)enGender.Male)
                    pbImagePerson.Image = Resources.Male_512;

                else
                    pbImagePerson.Image = Resources.Female_512;

                return;
            }

            pbImagePerson.ImageLocation = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;
        }

        private void _FillInternationalLicenseInfo()
        {
            _InternationalLicenseID = _InternationalLicenseInfo.InternationalLicenseID;
            lblPersonName.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.FullName;
            lblInternationalLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicenseInfo.LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = (_InternationalLicenseInfo.DriverInfo.PersonInfo.Gender == (byte)enGender.Male ? "Male" : "Female");
            lblIssueDate.Text = _InternationalLicenseInfo.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicenseInfo.ApplicationID.ToString();
            lblIsActive.Text = (_InternationalLicenseInfo.IsActive ? "Yes" : "No");
            lblDateOfBirth.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicenseInfo.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicenseInfo.ExpirationDate.ToShortDateString();
            _LoadPersonImage();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicense)
        {
            _InternationalLicenseInfo = clsInternationalLicense.Find(InternationalLicense);

            if(_InternationalLicenseInfo == null)
            {
                _ResetDefaultValues();
                _InternationalLicenseID = -1;
                MessageBox.Show($"Not International License With ID = {InternationalLicense}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInternationalLicenseInfo();
        }

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
    }
}