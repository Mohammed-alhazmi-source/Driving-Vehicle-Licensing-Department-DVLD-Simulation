using System;
using System.Windows.Forms;

namespace DVDL.Desktop.People.Forms
{
    public partial class frmShowPersonInfo : Form
    {
        public event Action DataBackEventHandler;

        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();   
            ctrlPersonCard.LoadPersonInfo(PersonID);
        }

        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonCard.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            DataBackEventHandler?.Invoke();
        }

        private void ctrlPersonCard_DataBackEventHandler()
        {
            DataBackEventHandler?.Invoke();            
        }
    }
}