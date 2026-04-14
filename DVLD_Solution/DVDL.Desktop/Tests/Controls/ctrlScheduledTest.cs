using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.Properties;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        public event Action OnClosed;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private int _TestAppointmentID = -1;

        private clsTestAppointment _TestAppointment = null;

        private clsTest _Test = null;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbImageTestType.Image = Resources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbImageTestType.Image = Resources.Written_Test_512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbImageTestType.Image = Resources.driving_test_512;
                        break;
                }
            }
        }

        private bool _LoadTestData()
        {
            _Test = clsTest.FindByTestAppointmentID(_TestAppointmentID);

            if(_Test == null)
            {
                MessageBox.Show($"Error: No Test With ID = {_TestAppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblTestID.Text = _Test.TestID.ToString();

            if (_Test.TestResult) rbPass.Checked = true;
            else rbFail.Checked = true;

            txtNotes.Text = _Test.Notes;

            lblUserMessage.Visible = true;
            lblUserMessage.Text = $"Cannot Scheduled, {_TestTypeID} Because Attend Test";
            btnSave.Enabled = false;
            rbFail.Enabled = false;
            rbPass.Enabled = false;
            txtNotes.ReadOnly = true;

            return true;
        }

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment.TestID == -1)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;

            lblDLAppID.Text = _TestAppointment.LocalAppInfo.ID.ToString();
            lblLicenseType.Text = _TestAppointment.LocalAppInfo.LicenseClass.Name;
            lblApplicant.Text = _TestAppointment.LocalAppInfo.Application.PersonInfo.FullName;
            lblTrial.Text = _TestAppointment.LocalAppInfo.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("dd/MMM/yyyy");
            lblTestTypeFees.Text = ((int)_TestAppointment.PaidFees).ToString();

            if(_TestAppointment.TestID == -1)
            {
                lblUserMessage.Visible = false;
                lblTestID.Text = "N/A";

                _Test = new clsTest();
            }

            else
            {
                if (!_LoadTestData()) return;
            }
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _TestAppointment.TestAppointmentID;
            _Test.TestResult = (rbPass.Checked ? true : false);
            _Test.Notes = txtNotes.Text;
            _Test.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            if(_Test.Save())
            {
                MessageBox.Show("Saved Data Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTestID.Text = _Test.TestID.ToString();
                btnClose.PerformClick();
                return;
            }
            else
            {
                MessageBox.Show("Saved Data Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTestID.Text = "N/A";
                btnClose.PerformClick();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnClosed?.Invoke();
        }
    }
}