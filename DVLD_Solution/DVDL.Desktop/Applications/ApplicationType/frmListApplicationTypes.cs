using DVDL.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.ApplicationType
{
    public partial class frmListApplicationTypes : Form
    {
        DataView ApplicationTypesView;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            ApplicationTypesView = clsApplicationType.GetAllApplicationsTypes().DefaultView;
            dgvApplicationTypes.DataSource = ApplicationTypesView;
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
            lblRecordsCount.Text = ApplicationTypesView.Count.ToString();
        }

        private void EditApplicationTypeItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            frmUpdateApplicationType updateApplicationType = new frmUpdateApplicationType(ApplicationTypeID);
            updateApplicationType.DataBack += UpdateApplicationType_DataBack;
            updateApplicationType.ShowDialog();
        }

        private void UpdateApplicationType_DataBack()
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}