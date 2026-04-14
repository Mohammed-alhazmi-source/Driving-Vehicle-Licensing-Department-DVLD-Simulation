using DVDL.BLL;
using DVDL.Desktop.License;
using DVDL.Desktop.People.Forms;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public int LocalDrivingLicenseApplicationID => _LocalDrivingLicenseApplicationID;

        private int _LicenseID = -1;

        private clsLocalDrivingLicenseApplication _LocalApp = null;
        public clsLocalDrivingLicenseApplication SelectedLocalDrivingLicenseApplication => _LocalApp;

        public event Action DataBack;

        private bool _ShowLicenseInfoEnabled;
        public bool ShowLicenseInfoEnabled
        {
            set
            {
                _ShowLicenseInfoEnabled = value;
                llShowLicenseInfo.Enabled = _ShowLicenseInfoEnabled;
            }
            get { return _ShowLicenseInfoEnabled; }
        }

        private int _PassedTestsCount = 0;
        public int PassedTestsCount { 
            set { _PassedTestsCount = value; lblNumberTest.Text = _PassedTestsCount.ToString(); } 
            get { return _PassedTestsCount; } }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblDLAppID.Text = "[???]";
            lblLicenseType.Text = "[???]";
            llShowLicenseInfo.Enabled = false;
            ctrlApplicationBasicInfo1.ResetDefaultValues();
            lblNumberTest.Text = "0";
            lblPassedTestsCount.Text = "3";          
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = _LocalApp.ID;
            lblDLAppID.Text = _LocalApp.ID.ToString();
            lblLicenseType.Text = _LocalApp.LicenseClass.Name;
            lblPassedTestsCount.Text = "3";

            _LicenseID = _LocalApp.GetActiveLicenseID();

            llShowLicenseInfo.Enabled = (_LicenseID != -1);
            
            //lblNumberTest.Text = _PassedTestsCount.ToString();
            lblNumberTest.Text = _LocalApp.GetPassedTestsCount().ToString();
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalApp.ApplicationID);
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int localAppID)
        {
            _LocalApp = clsLocalDrivingLicenseApplication.Find(localAppID);
            int PassedTest = (_LocalApp == null) ? 0 : _LocalApp.GetPassedTestsCount();

            if (_LocalApp == null)
            {
                _ResetDefaultValues();
                MessageBox.Show($"No Local Application With ID = {localAppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if(PassedTest != 3 || 
            //    _LocalApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.New ||
            //    _LocalApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.Canceled)
            //{
            //    _ResetDefaultValues();
            //    MessageBox.Show($"No Local Application Full Passed Test Count = {PassedTest}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalApp = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalApp == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("No Local Application With ID = {localAppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = _LocalApp.GetActiveLicenseID();
            frmShowLicense showLicense = new frmShowLicense(LicenseID);
            showLicense.ShowDialog();
        }
    }
}