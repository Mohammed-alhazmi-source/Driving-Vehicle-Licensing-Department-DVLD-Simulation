using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.InternationalLicenseApplication
{
    public partial class frmShowDriverInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID = -1;

        public frmShowDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmShowDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}