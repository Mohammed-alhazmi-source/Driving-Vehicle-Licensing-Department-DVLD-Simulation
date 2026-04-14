using DVDL.BLL;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;
        
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void fTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadInfo(_TestAppointmentID);
        }

        private void ctrlScheduledTest1_OnClosed() => this.Close();   
    }
}