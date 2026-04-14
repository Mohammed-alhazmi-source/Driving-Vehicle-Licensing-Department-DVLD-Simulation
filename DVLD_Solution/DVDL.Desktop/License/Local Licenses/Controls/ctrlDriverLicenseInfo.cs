using DVDL.BLL;
using DVDL.Desktop.Properties;
using System.IO;
using System.Windows.Forms;

namespace DVDL.Desktop.License
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private enum _enGender { Male = 0, Female = 1};

        private int _LicenseID = -1;
        public int LicenseID => _LicenseID;
        
        private clsLicense _LicenseInfo = null;
        public clsLicense SelectedLicenseInfo => _LicenseInfo;
 
        private void _ResetDefaultValues()
        {
            lblLicenseClass.Text = "[???]";
            lblPersonName.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblIssueReason.Text = "[???]";
            lblNotes.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblIsDetained.Text = "[???]";
            pbImagePerson.Image = Resources.Male_512;
        }

        private void _LoadPersonImage()
        {
            if (_LicenseInfo.DriverInfo.PersonInfo.Gender == 0)
                pbImagePerson.Image = Resources.Male_512;
            else
                pbImagePerson.Image = Resources.Female_512;

            string ImagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (File.Exists(ImagePath))
                pbImagePerson.Load(ImagePath);
            
            //else
            //    MessageBox.Show($"Could Not Find This Image = {ImagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillDriverLicenseInfo()
        {
            lblLicenseClass.Text = _LicenseInfo.LicenseClassInfo.Name;
            lblPersonName.Text = _LicenseInfo.ApplicationInfo.PersonInfo.FullName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = (_LicenseInfo.DriverInfo.PersonInfo.Gender == (byte)_enGender.Male ? "Male" : "Female");
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToString("dd/MMM/yyyy");
            lblIssueReason.Text = _LicenseInfo.IssueReasonText;
            lblNotes.Text = (string.IsNullOrEmpty(_LicenseInfo.Notes) ? "No Notes" : _LicenseInfo.Notes);
            lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _LicenseInfo.ApplicationInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _LicenseInfo.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToString("dd/MMM/yyyy");
            lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No";
            _LoadPersonImage();
        }       

        public void LoadInfo(int LicenseID)
        {
            _LicenseInfo = clsLicense.FindByLicenseID(LicenseID);
            _LicenseID = LicenseID;

            if (_LicenseInfo == null)
            {
                _ResetDefaultValues();
                _LicenseID = -1;
                MessageBox.Show
                    (
                       $"No License With ID = {LicenseID}", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                    );
                return;
            }

            _FillDriverLicenseInfo();
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
    }
}