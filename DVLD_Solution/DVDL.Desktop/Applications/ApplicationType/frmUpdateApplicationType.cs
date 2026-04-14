using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVDL.Desktop.ApplicationType
{
    public partial class frmUpdateApplicationType : Form
    {
        private int _ApplicationTypeID = -1;

        public event Action DataBack;

        clsApplicationType _ApplicationType = null;

        private void _LoadApplicationTypeInfo()
        {
            lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        public override bool ValidateChildren()
        {
            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrEmpty(txtApplicationTypeTitle.Text))
                ValidateEmptyTextBox(txtApplicationTypeTitle, e);

            else if (string.IsNullOrEmpty(txtApplicationFees.Text))
                ValidateEmptyTextBox(txtApplicationFees, e);

            else
                return true;

            return false;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This Field Is Required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationTypeTitle.Text))
            {
                ValidateEmptyTextBox(sender, e);
                return;
            }

            if (txtApplicationTypeTitle.Text != _ApplicationType.ApplicationTypeTitle)
            {
                if (clsApplicationType.IsApplicationTypeExist(txtApplicationTypeTitle.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtApplicationTypeTitle, "This Title Used Another Application Type Title");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtApplicationTypeTitle, null);
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationTypeTitle, null);
            }
        }

        private void txtApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Fees Cannot Be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationFees, null);
            }

            if (!clsValidation.IsNumber(txtApplicationFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtApplicationFees, "Invalid Number.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtApplicationFees, null);
            }
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            txtApplicationTypeTitle.Focus();

            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show($"No With Application Type ID {_ApplicationTypeID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _LoadApplicationTypeInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Is Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text.Trim();
            _ApplicationType.ApplicationFees = Convert.ToDecimal(txtApplicationFees.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Saved Data Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (DataBack != null)
                    DataBack();
            }

            else
                MessageBox.Show("Saved Data Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void txtApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtApplicationFees.Text.Contains("."))
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
    }
}