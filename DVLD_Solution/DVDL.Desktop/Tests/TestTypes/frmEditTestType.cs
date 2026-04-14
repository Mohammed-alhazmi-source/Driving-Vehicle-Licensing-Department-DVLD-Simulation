using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.TestType
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public event Action DataBack;

        private clsTestType _TestType = null;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void _LoadTestTypeData()
        {
            lblTestTypeID.Text = Convert.ToInt32(_TestType.ID).ToString();    
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = Convert.ToInt32(_TestType.Fees).ToString();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if(_TestType == null)
            {
                MessageBox.Show($"No ID With Test Type ID {_TestTypeID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _LoadTestTypeData();
        }

        public override bool ValidateChildren()
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtFees.Text))
                return false;
            
            return true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if(string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, $"{Temp.Name} Cannot Be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }    
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
                ValidateEmptyTextBox(sender, e);

            if(txtTitle.Text != _TestType.Title)
            {
                if(clsTestType.IsTestTypeExist(txtTitle.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtTitle, "This Title Is Used Another Test Type,Choose Another Title!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtTitle, null);
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e) => ValidateEmptyTextBox(sender, e);

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
                ValidateEmptyTextBox(sender, e);

            if(!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valide!, put the mouse over the red icon(s)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = Convert.ToDecimal(txtFees.Text);


            if (_TestType.Save())
            {
                MessageBox.Show("Saved Data Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (DataBack != null)
                    DataBack.Invoke();
            }

            else
                MessageBox.Show("Saved Data Failed", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFees.Text.Contains("."))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }

            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}