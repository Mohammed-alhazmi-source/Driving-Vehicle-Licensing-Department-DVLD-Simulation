using System;
using System.Windows.Forms;

namespace DVDL.Desktop.License
{
    public partial class frmShowLicense : Form
    {
        private int _LicenseID = -1;
        public frmShowLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}