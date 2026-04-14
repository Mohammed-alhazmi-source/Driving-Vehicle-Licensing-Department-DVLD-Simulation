using DVDL.BLL;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
       
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {   
            if(_PersonID != -1)
            {
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlDriverLicensesInfo1.LoadInfoByPersonID(_PersonID);
            }    

            else
            {
                ctrlPersonCardWithFilter1.FilterEnabled = true;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
                ctrlDriverLicensesInfo1.Clear();

            else
                ctrlDriverLicensesInfo1.LoadInfoByPersonID(PersonID);
        }
    }
}