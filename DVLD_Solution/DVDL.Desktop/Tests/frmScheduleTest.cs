using DVDL.BLL;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Tests
{
    public partial class frmScheduleTest : Form
    {        
        int _LocalAppID = -1, _TestAppointmentID = -1;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmScheduleTest(int LocalAppID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalAppID = LocalAppID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmAddUpdateTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalAppID, _TestAppointmentID);
        }

        private void ctrlScheduleTest1_OnClosed()
        {
            this.Close();
        }
    }
}