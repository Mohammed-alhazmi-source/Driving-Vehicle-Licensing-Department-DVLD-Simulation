using DVDL.BLL;
using DVDL.Desktop.People.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.License.DetainedOrReleaseLicenses
{
    public partial class frmListDetainedLicenses : Form
    {
        DataView _DetainedReleasedLicensesView;

        event Action<string> _OnFilterBy;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _LoadDetainedAndReleasedLicenses()
        {
            _DetainedReleasedLicensesView = clsDetainedLicense.GetAllDetainedLicenses().DefaultView;

            if (_DetainedReleasedLicensesView != null)
            {
                dgvDetainedLicenses.DataSource = _DetainedReleasedLicensesView;
                lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
            }
        }

        private void _FilterBy(string ColumnName)
        {
            if(string.IsNullOrEmpty(ColumnName) || ColumnName == "None" || string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _DetainedReleasedLicensesView.RowFilter = "";
                lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
                return;
            }

            if(ColumnName == DetainID.Name || ColumnName == LicenseID.Name)
            {
                _DetainedReleasedLicensesView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtFilterValue.Text);
                lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
                return;
            }

            _DetainedReleasedLicensesView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", ColumnName, txtFilterValue.Text);
            lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
        }

        private string _GetColumnName()
        {
            switch (cbFilterBy.Text)
            {
                case "Detain ID": return DetainID.Name;
                case "License ID": return LicenseID.Name;
                case "National No.": return NationalNo.Name;
                case "Full Name": return FullName.Name;
            }

            return "";
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbFilterByRelease.SelectedIndex = 0;
            _LoadDetainedAndReleasedLicenses();
            lblRecordsCount.Text = (_DetainedReleasedLicensesView != null) ? _DetainedReleasedLicensesView.Count.ToString() : "0";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "None")
            {
                txtFilterValue.Visible = false;
                cbFilterByRelease.Visible = false;

                if (_DetainedReleasedLicensesView != null)
                {
                    _DetainedReleasedLicensesView.RowFilter = "";
                    lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
                }
                return;
            }

            if(cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbFilterByRelease.Visible = true;
                
                if (_DetainedReleasedLicensesView != null) _DetainedReleasedLicensesView.RowFilter = "";
                return;
            }

            cbFilterByRelease.Visible = false;
            txtFilterValue.Visible = true;
            txtFilterValue.Clear();
        }

        private void cbFilterByRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterByRelease.Text == "All")
            {
                if (_DetainedReleasedLicensesView != null)
                {
                    _DetainedReleasedLicensesView.RowFilter = "";
                    lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
                }

                return;
            }

            _DetainedReleasedLicensesView.RowFilter = string.Format("[{0}] = {1}", IsReleased.Name, ((cbFilterByRelease.Text == "Yes" ? 1 : 0)));
            lblRecordsCount.Text = _DetainedReleasedLicensesView.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _OnFilterBy += _FilterBy;
            _OnFilterBy(_GetColumnName());
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "License ID")
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            // طريقتي عند الضغط على السجل وفتح القائمة اشوف هل هي محجوزة اذا نعم نفعل العنصر لفك الحجز
            // اذا ليست محجوزة نجعله معطل خلاص تم تفعيلها 
            // طريقتي اكثر دقة ولكن بطيئة لانها في كل ضغطة يتم الذهاب الى قاعدة البيانات كثرة زيارة قاعدة البيانات
            //clsDetainedLicense DetainLicense = clsDetainedLicense.FindByID((int)dgvDetainedLicenses.CurrentRow.Cells["DetainID"].Value);                       
            //if (DetainLicense != null)
            //{
            //    ReleaseItem.Enabled = !DetainLicense.IsReleased;
            //    return;
            //}

            //ReleaseItem.Enabled = false;



            // طريقة الدكتور هي افضل البيانات تم تحميلها في الجدول خلاص بحسب القيمة الموجودة في عمود IsReleased
            // يتم التحديد هل هي محجوزة ام لا هي افضل ولكن ليست موثوقة من ناحية قد يكون هناك خلال في البيانات او
            // لم يتم تحميل البيانات بعد فك حجز رخصة حصل مشكلة عند تحميل البيانات من القاعدة هنا راح يكون مشكلة 
            ReleaseItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value;
        }

        private void btnAddDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
            _LoadDetainedAndReleasedLicenses();
        }       

        private void ReleaseItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication releaseLicense = new frmReleaseDetainedLicenseApplication((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            releaseLicense.ShowDialog();
            _LoadDetainedAndReleasedLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPersonDetailsItem_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.FindByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            
            if(License != null)
            {
                frmShowPersonInfo showPersonInfo = new frmShowPersonInfo(License.DriverInfo.PersonID);
                showPersonInfo.ShowDialog();
            }
        }

        private void ShowLicenseDetailsItem_Click(object sender, EventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            showLicense.ShowDialog();
        }

        private void ShowPersonLicenseHistoryItem_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.FindByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frmShowPersonLicenseHistory showPersonLicenseHistory =
                new frmShowPersonLicenseHistory(License.DriverInfo.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication releaseLicense = new frmReleaseDetainedLicenseApplication();
            releaseLicense.ShowDialog();
        }
    }
}