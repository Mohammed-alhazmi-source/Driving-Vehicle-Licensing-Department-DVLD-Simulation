using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.License;
using DVDL.Desktop.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.LocalDrivingLicenseApplication
{
    public partial class frmListLocalDrivingLicenseApplication : Form
    {
        DataView _LocalDrivingLicenseApplicationsView;

        private event Action<string> _OnFilterBy;

        public frmListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            _LocalDrivingLicenseApplicationsView = 
                clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplicationsDetails().DefaultView;
            dgvLocalDrivingLicenseApplications.DataSource = _LocalDrivingLicenseApplicationsView;
        }

        private string GetColumnName()
        {
            Dictionary<string, string> ColumnsNames = new Dictionary<string, string>
            {
                {LocalDrivingLicenseApplicationID.HeaderText,LocalDrivingLicenseApplicationID.Name },
                {DrivingClass.HeaderText,DrivingClass.Name},
                {NationalNo.HeaderText,NationalNo.Name },
                {FullName.HeaderText, FullName.Name },
                {Status.HeaderText, Status.Name }
            };

            if (ColumnsNames.TryGetValue(cbFilterBy.Text, out string Name))
                return Name;

            return Name;
        }

        private void FilterBy(string ColumnName)
        {
            if(string.IsNullOrEmpty(ColumnName) || ColumnName == "None" || string.IsNullOrEmpty(txtValueFilter.Text))
            {
                _LocalDrivingLicenseApplicationsView.RowFilter = "";
                lblRecordsCount.Text = _LocalDrivingLicenseApplicationsView.Count.ToString();
                return;
            }

            if (ColumnName == "LocalDrivingLicenseApplicationID")
                _LocalDrivingLicenseApplicationsView.RowFilter =
                    string.Format("[{0}] = {1}", ColumnName, txtValueFilter.Text.Trim());

            else
                _LocalDrivingLicenseApplicationsView.RowFilter =
                string.Format("[{0}] LIKE '%{1}%'", ColumnName, txtValueFilter.Text.Trim());

            dgvLocalDrivingLicenseApplications.DataSource = _LocalDrivingLicenseApplicationsView;
            lblRecordsCount.Text = _LocalDrivingLicenseApplicationsView.Count.ToString();
        }

        private void frmListLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
            lblRecordsCount.Text = _LocalDrivingLicenseApplicationsView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                _LocalDrivingLicenseApplicationsView.RowFilter = "";
                lblRecordsCount.Text = _LocalDrivingLicenseApplicationsView.Count.ToString();
                txtValueFilter.Visible = false;
                return;
            }

            txtValueFilter.Visible = true;
            txtValueFilter.Clear();
        }

        private void txtValueFilter_TextChanged(object sender, EventArgs e)
        {
            _OnFilterBy += FilterBy;
            _OnFilterBy(GetColumnName());
        }

        private void txtValueFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "L.D.L.AppID")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication AddNewApplication = new frmAddUpdateLocalDrivingLicenseApplication();
            AddNewApplication.DataBack += Application_DataBack;
            AddNewApplication.ShowDialog();
        }

        private void Application_DataBack() => _LoadData();

        private void ShowApplicationDetailsItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            int PassedTestsCount = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            frmLocalDrivingLicenseApplicationInfo showApplicationInfo = new frmLocalDrivingLicenseApplicationInfo(LDLApplicationID, PassedTestsCount);
            showApplicationInfo.DataBack += Application_DataBack;
            showApplicationInfo.ShowDialog();
        }

        private void EditApplicationItem_Click(object sender, EventArgs e)
        {
            int LocalApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmAddUpdateLocalDrivingLicenseApplication UpdateApplication =
                new frmAddUpdateLocalDrivingLicenseApplication(LocalApplicationID);
            UpdateApplication.DataBack += Application_DataBack;
            UpdateApplication.ShowDialog();
        }

        private void DeleteApplicationItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalApp =
              clsLocalDrivingLicenseApplication
              .Find((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (LocalApp != null)
            {
                if (MessageBox.Show
                (
                    "Are You Sure Delete This Application?",
                    "Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2
                ) == DialogResult.OK)
                {
                    if (LocalApp.Delete())
                    {
                        if (LocalApp.Application.Delete())
                        {
                            MessageBox.Show("Deleted Data Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Deleted Data Failed", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Deleted Data Failed", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CancelApplicationItem_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalApp  = 
                clsLocalDrivingLicenseApplication
                .Find((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if(LocalApp != null)
            {
                if (MessageBox.Show
                                (
                                    "Are You Sure Cancel This Application?",
                                    "Cancel",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2
                                ) == DialogResult.OK)
                {
                    //LocalApp.Application.ApplicationStatus = clsApplication.enApplicationStatus.Canceled;
                    //LocalApp.Application.LastStatusDate = DateTime.Now;
                    //LocalApp.Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;
                    //LocalApp.Application.ApplicationPersonID = LocalApp.Application.ObjectPerson.PersonID;

                    //LocalApp.Application.Cancel();

                    if (LocalApp.Application.Cancel())
                    {
                        MessageBox.Show("Saved Data Successfully", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _LoadData();
                    }
                    else
                        MessageBox.Show("Saved Data Failed", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ScheduleVisionTestItem_Click(object sender, EventArgs e)
        {
            int LocalAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestAppointments TestAppointments =
                new frmListTestAppointments(LocalAppID, clsTestType.enTestType.VisionTest);
            TestAppointments.ShowDialog();
            _LoadData();
        }

        private void ScheduleWrittenTestItem_Click(object sender, EventArgs e)
        {
            int LocalAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestAppointments TestAppointments =
                new frmListTestAppointments(LocalAppID, clsTestType.enTestType.WrittenTest);
            TestAppointments.ShowDialog();
            _LoadData();
        }

        private void ScheduleStreetTestItem_Click(object sender, EventArgs e)
        {
            int LocalAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestAppointments TestAppointments =
                new frmListTestAppointments(LocalAppID, clsTestType.enTestType.StreetTest);
            TestAppointments.ShowDialog();
            _LoadData();
        }

        private void IssueDrivingLicense_FirstTimeItem_Click(object sender, EventArgs e)
        {
            int LocalAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmIssueDriverLicenseFirstTime IssueDrivingLicense = new frmIssueDriverLicenseFirstTime(LocalAppID);
            IssueDrivingLicense.DataBack += Application_DataBack;
            IssueDrivingLicense.ShowDialog();
        }       

        private void ShowLicenseItem_Click(object sender, EventArgs e)
        {          
            int LocalAppID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.Find(LocalAppID);

            if (localApp == null) return;

            int LicenseID = localApp.GetActiveLicenseID();

            frmShowLicense showLicense = new frmShowLicense(LicenseID);
            showLicense.ShowDialog();            
        }

        private void ShowPersonLicenseHistoryItem_Click(object sender, EventArgs e)
        {                      
            int PersonID = clsLocalDrivingLicenseApplication.GetPersonIDByLocalDrivingLicenseApplicationID
                            (
                                 (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value
                            );

            int DriverID = clsDriver.GetDriverIDBy(PersonID);

            if(DriverID == -1)
            {
                MessageBox.Show("This Person Doesn't Driver After", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowPersonLicenseHistory personLicenseHistory = new frmShowPersonLicenseHistory(PersonID);
            personLicenseHistory.ShowDialog();
        }
      
        private void SetContextMenuItemsEnabledState
            (
               bool IssueDrivingLicense = false, bool ShowLicense         = false, bool EditApplication    = false, 
               bool ScheduleTests       = false, bool CancelApplication   = false, bool DeleteApplication  = false, 
               bool ScheduleVisionTest  = false, bool ScheduleWrittenTest = false, bool ScheduleStreetTest = false
            )
        {
            IssueDrivingLicense_FirstTimeItem.Enabled = IssueDrivingLicense;
            ShowLicenseItem.Enabled = ShowLicense;
            EditApplicationItem.Enabled = EditApplication;
            ScheduleTestsItem.Enabled = ScheduleTests;
            CancelApplicationItem.Enabled = CancelApplication;
            DeleteApplicationItem.Enabled = DeleteApplication;
            ScheduleVisionTestItem.Enabled = ScheduleVisionTest;
            ScheduleWrittenTestItem.Enabled = ScheduleWrittenTest;
            ScheduleStreetTestItem.Enabled = ScheduleStreetTest;
        }

        private void UpdateMenuBasedOnApplicationStatus(string ApplicationStatus, int PassedTests = 0)
        {
            if (ApplicationStatus == "New")
            {
                if (PassedTests == 0)
                    SetContextMenuItemsEnabledState(false, false, true, true, true, true, true, false, false);

                else if (PassedTests == 1)
                    SetContextMenuItemsEnabledState(false, false, true, true, true, true, false, true, false);

                else if (PassedTests == 2)
                    SetContextMenuItemsEnabledState(false, false, true, true, true, true, false, false, true);

                else if (PassedTests == 3)
                    SetContextMenuItemsEnabledState(true, false, true, false, true, true);
            }

            else if (ApplicationStatus == "Canceled")
                SetContextMenuItemsEnabledState(false, false, false, false, false, true);

            else if (ApplicationStatus == "Completed")
                SetContextMenuItemsEnabledState(false, true, false, false, false, false);
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApp =
                clsLocalDrivingLicenseApplication.Find((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (LDLApp == null)
            {
                return;
            }

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;
            bool IsLicenseExist = LDLApp.IsLicenseIssued();

            EditApplicationItem.Enabled = LDLApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.New
                                          && TotalPassedTests == 0;

            DeleteApplicationItem.Enabled = LDLApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.New
                                          && TotalPassedTests == 0;

            CancelApplicationItem.Enabled = LDLApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.New;

            bool PassedVisionTest = LDLApp.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LDLApp.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LDLApp.DoesPassTestType(clsTestType.enTestType.StreetTest);

            ScheduleTestsItem.Enabled = ((!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                                           LDLApp.Application.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (ScheduleTestsItem.Enabled)
            {
                ScheduleVisionTestItem.Enabled = !PassedVisionTest;

                ScheduleWrittenTestItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                ScheduleStreetTestItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }

            IssueDrivingLicense_FirstTimeItem.Enabled = (TotalPassedTests == 3) && (!IsLicenseExist) && (LDLApp.Application.ApplicationStatus != clsApplication.enApplicationStatus.Canceled);

            ShowLicenseItem.Enabled = IsLicenseExist && (LDLApp.Application.ApplicationStatus != clsApplication.enApplicationStatus.Canceled);

            //UpdateMenuBasedOnApplicationStatus
            //   (
            //     (string)dgvLocalDrivingLicenseApplications.CurrentRow.Cells["Status"].Value,
            //     (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells["PassedTests"].Value
            //   );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}