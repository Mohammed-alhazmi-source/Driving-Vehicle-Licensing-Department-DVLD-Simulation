using DVDL.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.TestType
{
    public partial class frmListTestTypes : Form
    {
        DataView TestTypesView;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void _LoadTestTypesData()
        {
            TestTypesView = clsTestType.GetAllTestTypes().DefaultView;
            dgvTestTypes.DataSource = TestTypesView;
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypesData();
            lblRecordsCount.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void EditTestTypeItem_Click(object sender, EventArgs e)
        {
            frmEditTestType editTestType = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            editTestType.DataBack += EditTestType_DataBack;
            editTestType.ShowDialog();
        }

        private void EditTestType_DataBack()
        {
            _LoadTestTypesData();
        }
    }
}