using DVDL.BLL;
using DVDL.Desktop.People.Forms;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        public int ApplicationID => _ApplicationID;

        private clsApplication _ApplicationInfo = null;
        public clsApplication ApplicationInfo => _ApplicationInfo;

        public event Action DataBack;

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetDefaultValues()
        {           
            lblApplicationID.Text = "[???]";
            lblApplicationStatus.Text = "[???]";
            lblApplicationType.Text = "[???]";
            lblApplicant.Text = "[???]";
            lblApplicationDate.Text = "[???]";
            lblLastStatusDate.Text = "[???]";
            lblUserName.Text = "[???]";
            llViewPersonInfo.Enabled = false;
        }

        private void _FillLoadApplicationInfo()
        {
            _ApplicationID = _ApplicationInfo.ApplicationID;
            lblApplicationID.Text = _ApplicationInfo.ApplicationID.ToString();
            lblApplicationStatus.Text = _ApplicationInfo.StatusText;
            lblApplicationType.Text = _ApplicationInfo.ApplicationType.ToString();
            lblApplicationFees.Text = ((int)clsApplicationType.Find((int)clsApplication.enApplicationType.NewLocalDrivingLicenseService).ApplicationFees).ToString();
            lblApplicant.Text = _ApplicationInfo.PersonInfo.FullName;
            lblApplicationDate.Text = _ApplicationInfo.ApplicationDate.ToString("dd/MMM/yyyy");
            lblLastStatusDate.Text = _ApplicationInfo.LastStatusDate.ToString("dd/MMM/yyyy");
            lblUserName.Text = _ApplicationInfo.UserInfo.UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _ApplicationInfo = clsApplication.Find(ApplicationID);

            if(_ApplicationInfo == null)
            {
                ResetDefaultValues();
                MessageBox.Show($"No Local Application With ID = {ApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLoadApplicationInfo();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo(_ApplicationInfo.ApplicationPersonID);
            showPersonInfo.DataBackEventHandler += ShowPersonInfo_DataBackEventHandler;
            showPersonInfo.ShowDialog();
        }

        private void ShowPersonInfo_DataBackEventHandler()
        {
            LoadApplicationInfo(_ApplicationID);

            DataBack?.Invoke();
        }
    }
}