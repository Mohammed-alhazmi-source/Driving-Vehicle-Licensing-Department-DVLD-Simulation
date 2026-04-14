using DVDL.BLL;
using DVDL.Desktop.People.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnPersonSelected;

        public event Action DataBackEventHandler;


        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
                OnPersonSelected(PersonID);
        }

        public int PersonID => ctrlPersonCard.PersonID;

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard.SelectedPersonInfo; }
        }

        public override bool ValidateChildren()
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text))
            {
                CancelEventArgs e = new CancelEventArgs();
                txtFilterValue.Validating += txtFilterValue_Validating;
                txtFilterValue_Validating(txtFilterValue, e);
                return false;
            }

            return true;
        }

        private void FindNow()
        {           
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard.LoadPersonInfo(Convert.ToInt32(txtFilterValue.Text.Trim()));
                    break;

                case "National No.":
                    ctrlPersonCard.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;
            }
           
            // هنا يتم اطلاق الحدث اذا تم الاشتراك من قبل المستخدم في الحدث وكان القروب بوكس مفعل هنا يتم ارجاع المعرف 
            // الى الواجهة الي اشتركت في هذا الحدث
            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlPersonCard.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow(); 
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addPerson = new frmAddUpdatePerson();
            addPerson.DataBack += DataBackEvent;
            addPerson.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard.LoadPersonInfo(PersonID);
        }      
        
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valide!, Put The Mouse Over The Red Icon", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FindNow();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_Validating(object sender,CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {                
                errorProvider1.SetError(txtFilterValue, "This Filed Is Required");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonCard_DataBackEventHandler()
        {
            DataBackEventHandler?.Invoke();
        }
    }
}