using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _PassedTestsCount = 0;
        private int _LocalAppID = -1;
        public event Action DataBack;

        

        public frmLocalDrivingLicenseApplicationInfo(int LocalAppID, int PassedTestsCount)
        {
            InitializeComponent();
            _LocalAppID = LocalAppID;
            _PassedTestsCount = PassedTestsCount;
        }

        private void btnPrimaryClose_Click(object sender, EventArgs e) => this.Close();

        private void btnClose_Click(object sender, EventArgs e) => btnPrimaryClose_Click(null, null);

        private void frmShowApplicationInfo_Load(object sender, EventArgs e)
        {
            //ctrlDrivingLicenseApplicationInfo1.PassedTestsCount = _PassedTestsCount;
            ctrlDrivingLicenseApplicationInfo1.LoadApplicationInfoByLocalDrivingAppID(_LocalAppID);
        }

        private void ctrlShowApplicationInfo1_DataBack()
        {
            DataBack?.Invoke();
        }
    }
}
