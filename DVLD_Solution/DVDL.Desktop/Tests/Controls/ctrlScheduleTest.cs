using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.Properties;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _Mode = enMode.Add;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1};

        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        private clsTestAppointment _TestAppointment = null;

        private int _LocalDrivingLicenseApplicationID = -1;

        private int _TestAppointmentID = -1;

        public event Action OnClosed;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTest.Text = "Vision Test";
                        pbImageTestType.Image = Resources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gbTest.Text = "Written Test";
                        pbImageTestType.Image = Resources.Written_Test_512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gbTest.Text = "Street Test";
                        pbImageTestType.Image = Resources.driving_test_512;
                        break;
                }
            }
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            if (TestAppointmentID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if( _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"Error: No Local Driving License Application With ID = {_LocalDrivingLicenseApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
         
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestFees.Text = ((int)clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.RetakeTest)).ToString();
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestApplicationID.Text = "N/A";
            }
        
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeTestFees.Text = "0";
                lblTitle.Text = "Schedule Test";
                lblRetakeTestApplicationID.Text = "N/A";
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblLicenseType.Text = _LocalDrivingLicenseApplication.LicenseClass.Name;
            lblApplicant.Text = _LocalDrivingLicenseApplication.Application.PersonInfo.FullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
           
            if (_Mode == enMode.Add)
            {
                lblTestTypeFees.Text = ((int)clsTestType.Find(_TestTypeID).Fees).ToString();
                dtpAppointmentDate.MinDate = DateTime.Now;
                lblRetakeTestApplicationID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();
            }

            else
            {
                if (!_LoadTestAppointmentData()) return;
            }

            lblTotleFees.Text = (Convert.ToInt32(lblRetakeTestFees.Text) + Convert.ToInt32(lblTestTypeFees.Text)).ToString();

            if (_HandlePassedTestType())
                return;

            if (!_HandleActiveTestAppointmentConstraint()) return;

            if (!_HandleAppointmentLockedConstraint()) return;

            if (!_HandlePreviousTestConstraint()) return;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show($"Error: No Appointment With ID = {_TestAppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblTestTypeFees.Text = ((int)_TestAppointment.PaidFees).ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) == 0)
                dtpAppointmentDate.MinDate = DateTime.Now;
            else
                dtpAppointmentDate.MinDate = _TestAppointment.AppointmentDate;

            dtpAppointmentDate.Value = _TestAppointment.AppointmentDate;
            
            if(_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeTestFees.Text = "0";
                lblRetakeTestApplicationID.Text = "N/A";
            }
            else
            {
                lblRetakeTestFees.Text = ((int)_TestAppointment.RetakeTestApplicationInfo.PaidFees).ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestApplicationID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();                
            }
            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode == enMode.Add && clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID,(int)_TestTypeID))
            {
                lblSubTitle.Text = "Person Already Sat For The Test Appointment Not Locked";
                lblSubTitle.Visible = true;
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }

            return true;
        }
       
        private bool _HandlePassedTestType()
        {
            if(_Mode == enMode.Add && _LocalDrivingLicenseApplication.DoesPassTestType(_TestTypeID))
            {
                lblSubTitle.Visible = true;
                lblSubTitle.Text = "This Person Already Passed This Test Before, You Can Only Retake Failed Test";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return true;
            }

            return false;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblSubTitle.Visible = true;
                lblSubTitle.Text = "Person Already Sat For The Test, Appointment Locked.";
                dtpAppointmentDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
                lblSubTitle.Visible = false;

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblSubTitle.Visible = false;
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if(!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblSubTitle.Text = "Cannot Schedule, Vision Test Should Be Passed First";
                        lblSubTitle.Visible = true;
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblSubTitle.Visible = false;
                        btnSave.Enabled = true;
                        dtpAppointmentDate.Enabled = true;
                    }
                    return true;

                case clsTestType.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblSubTitle.Text = "Cannot Schedule, Written Test Should Be Passed First";
                        lblSubTitle.Visible = true;
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblSubTitle.Visible = false;
                        btnSave.Enabled = true;
                        dtpAppointmentDate.Enabled = true;
                    }
                    return true;
            }

            return false;
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        private bool _HandleRetakeApplication()
        {
            if(_Mode == enMode.Add && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication Application = new clsApplication();

                Application.ApplicationPersonID = _LocalDrivingLicenseApplication.Application.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationType = clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.RetakeTest);
                Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

                if(!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Failed To Create Application,", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication()) return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalAppId = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblTestTypeFees.Text);
            _TestAppointment.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;

                MessageBox.Show("Data Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClose.PerformClick();
            }
            else
                MessageBox.Show("Error:Data Is Not Save Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClosed?.Invoke();
        }
    }
}