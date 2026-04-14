using DVDL.Desktop.Applications.InternationalLicenseApplication;
using DVDL.Desktop.Applications.LocalDrivingLicenseApplication;
using DVDL.Desktop.Applications.Replacement_For_License;
using DVDL.Desktop.ApplicationType;
using DVDL.Desktop.Classes;
using DVDL.Desktop.Driver;
using DVDL.Desktop.License.DetainedOrReleaseLicenses;
using DVDL.Desktop.License.Renew_Local_License;
using DVDL.Desktop.People;
using DVDL.Desktop.TestType;
using DVDL.Desktop.Users;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            _frmLogin = frmLogin;
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void PeopleItem_Click(object sender, EventArgs e)
        {
            frmListPeople listPeople = new frmListPeople();
            listPeople.ShowDialog();
        }

        private void UsersItem_Click(object sender, EventArgs e)
        {
            frmListUsers listUsers = new frmListUsers();
            listUsers.ShowDialog();
        }

        private void SignOutItem_Click(object sender, EventArgs e)
        {
            GlobalSettings.CurrentUser = null;
            _frmLogin.Show();
            this.Close();           
        }

        private void CurrentUserInfoItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo showUserInfo = new frmShowUserInfo(GlobalSettings.CurrentUser.UserID);
            showUserInfo.ShowDialog();
        }

        private void ChangePasswordItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(GlobalSettings.CurrentUser.UserID);
            changePassword.ShowDialog();
        }

        private void ManageApplicationTypesItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes applicationTypes = new frmListApplicationTypes();
            applicationTypes.ShowDialog();
        }

        private void ManageTestTypesItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes listTestTypes = new frmListTestTypes();
            listTestTypes.ShowDialog();
        }

        private void LocalLicenseItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication AddLocalDrivingLicenseApplication = 
                new frmAddUpdateLocalDrivingLicenseApplication();
            AddLocalDrivingLicenseApplication.ShowDialog();
        }

        private void LocalDrivingLicenseApplicationsItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication ListLocalDrivingLicenseApplication
                = new frmListLocalDrivingLicenseApplication();
            ListLocalDrivingLicenseApplication.ShowDialog();
        }

        private void DriversItem_Click(object sender, EventArgs e)
        {
            frmListDrivers listDrivers = new frmListDrivers();
            listDrivers.ShowDialog();
        }

        private void RetakeTestItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication ListLocalDrivingLicenseApplication =
                new frmListLocalDrivingLicenseApplication();
            ListLocalDrivingLicenseApplication.ShowDialog();
        }

        private void RenewDrivingLicenseItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication RenewLicense = new frmRenewLocalDrivingLicenseApplication();
            RenewLicense.ShowDialog();
        }

        private void ReplacementForLostOrDamagedLicenseItem_Click(object sender, EventArgs e)
        {
            frmReplacementLostOrDamagedLicenseApplication replacementForLicense = new frmReplacementLostOrDamagedLicenseApplication();
            replacementForLicense.ShowDialog();
        }

        private void InternationalLicenseItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicenseApplication issueInternationalLicenseApplication
                = new frmIssueInternationalLicenseApplication();
            issueInternationalLicenseApplication.ShowDialog();
        }

        private void InternationalLicenseApplicationsItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicensesApplications listInternationalLicensesApplications =
                new frmListInternationalLicensesApplications();
            listInternationalLicensesApplications.ShowDialog();
        }

        private void DetainLicenseItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void ReleaseDetainedLicenseItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication releaseLicense = new frmReleaseDetainedLicenseApplication();
            releaseLicense.ShowDialog();
        }

        private void ReleaseDetainedDrivingLicenseItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication releaseLicense = new frmReleaseDetainedLicenseApplication();
            releaseLicense.ShowDialog();
        }

        private void ManageDetainedLicensesItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses listDetainedLicenses = new frmListDetainedLicenses();
            listDetainedLicenses.ShowDialog();
        }
    }
}