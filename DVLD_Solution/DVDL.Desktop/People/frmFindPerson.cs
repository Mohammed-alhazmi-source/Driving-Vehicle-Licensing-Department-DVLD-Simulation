using System;
using System.Windows.Forms;

namespace DVDL.Desktop.People
{
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event Action<object, int> DataBack;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
        }
    }
}