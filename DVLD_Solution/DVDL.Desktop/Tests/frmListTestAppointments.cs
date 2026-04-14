using DVDL.BLL;
using DVDL.Desktop.Properties;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Tests
{
    public partial class frmListTestAppointments : Form
    {        
        private int _LocalAppID = -1;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public frmListTestAppointments(int LocalAppID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalAppID = LocalAppID;
            _TestType = TestType;
        }

        private void _LoadTestAppointmentsData()
        {
            dgvTestAppointments.DataSource = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalAppID, _TestType);
        }

        private void _ResetDefaultValues()
        {
            if (_TestType == clsTestType.enTestType.VisionTest)
            {
                lblTitle.Text = "Vision Test Appointments";
                pbTestTypeImage.Image = Resources.Vision_512;
            }
            else if (_TestType == clsTestType.enTestType.WrittenTest)
            {
                lblTitle.Text = "Written Test Appointments";
                pbTestTypeImage.Image = Resources.Written_Test_512;
            }
            else if (_TestType == clsTestType.enTestType.StreetTest)
            {
                lblTitle.Text = "Street Test Appointments";
                pbTestTypeImage.Image = Resources.driving_test_512;
            }
        }

        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {            
            _ResetDefaultValues();
            ctrlShowApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalAppID);
            _LoadTestAppointmentsData();

            if (dgvTestAppointments.Rows.Count > 0)
                lblRecordsCount.Text = dgvTestAppointments.Rows.Count.ToString();
            else
                lblRecordsCount.Text = "0";
        }

        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication
                = clsLocalDrivingLicenseApplication.Find(_LocalAppID);

            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalAppID, (int)_TestType))
            {
                MessageBox.Show(
                        "Person Already Have An Active Appointment For This Test, You Cannot Add New Appointment",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest Test = localDrivingLicenseApplication.GetLastPerTestType(_TestType);

            if(Test == null)
            {
                frmScheduleTest addTestAppointment1 =
                                new frmScheduleTest(_LocalAppID, _TestType);
                addTestAppointment1.ShowDialog();
                _LoadTestAppointmentsData();
                lblRecordsCount.Text = dgvTestAppointments.Rows.Count.ToString();
                return;
            }          

            if (Test.TestResult == true)
            {
                MessageBox.Show("This Person Already Passed This Test Before, You Can Only Retake Failed Test",
                       "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest addTestAppointment =
                            new frmScheduleTest(_LocalAppID, _TestType);
            addTestAppointment.ShowDialog();
            _LoadTestAppointmentsData();
            lblRecordsCount.Text = dgvTestAppointments.Rows.Count.ToString();
        }

        private void EditTestAppointmentItem_Click(object sender, EventArgs e)
        {
            if(dgvTestAppointments.Rows.Count > 0)
            {
                int TestAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;
                frmScheduleTest UpdateTestAppointment = new frmScheduleTest(_LocalAppID, _TestType, TestAppointmentID);

                UpdateTestAppointment.ShowDialog();
                _LoadTestAppointmentsData();                
            }
        }

        private void TakeTestItem_Click(object sender, EventArgs e)
        {
            //if (clsTestAppointment.IsTestAppointmentLocked((int)dgvTestAppointments.CurrentRow.Cells[0].Value))
            //{
            //    MessageBox.Show("This Appointment Is Locked", "Locked",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            frmTakeTest fTakeTest = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, _TestType);
            fTakeTest.ShowDialog();

            //frmTakeTest TakeTest = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value,_TestType);
            //TakeTest.ShowDialog();
            
            _LoadTestAppointmentsData();
            ctrlShowApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalAppID);
            //ctrlShowApplicationInfo1.PassedTestsCount = clsTest.GetPassedTestsCount(_LocalAppID);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}