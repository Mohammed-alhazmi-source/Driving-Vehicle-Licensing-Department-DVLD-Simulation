using DVDL.BLL;
using DVDL.Desktop.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVDL.Desktop.Applications.LocalDrivingLicenseApplication
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        private enum enMode { Add = 0, Update = 1 };
        private enMode _Mode = enMode.Add;

        private int _LocalDrivingLicenseApplicationID = -1;

        private static DataTable _dtLicenseClasses = null;

        public event Action DataBack;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        private void _FillLicenseClassesInComboBox()
        {
            if (_dtLicenseClasses == null)
                _dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            if (_dtLicenseClasses.Rows.Count > 0)
            {
                foreach (DataRow Row in _dtLicenseClasses.Rows)
                {
                    cbLicenseClasses.Items.Add(Row["ClassName"]);
                }
                cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString("Class 3 - Ordinary driving license");
            }            
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.Add)
            {
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                _LocalDrivingLicenseApplication.Application = new clsApplication();
                lblTitle.Text = "New Local Driving License Application";
                lblDLApplicationID.Text = "[???]";
                tpApplicationInfo.Enabled = false;
            }
            else
                lblTitle.Text = "Update Local Driving License Application";

            ctrlPersonCardWithFilter.FilterFocus();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            _FillLicenseClassesInComboBox();
            int ApplicationTypeID = (int)clsApplication.enApplicationType.NewLocalDrivingLicenseService;
            lblApplicationFees.Text = ((int)clsApplicationType.GetFeesByApplicationType(ApplicationTypeID)).ToString();
            lblUserName.Text = GlobalSettings.CurrentUser.UserName;
        }

        private void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application With L.D.L.ApplicationID = " + _LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter.FilterEnabled = false;
            ctrlPersonCardWithFilter.LoadPersonInfo(_LocalDrivingLicenseApplication.Application.PersonInfo.PersonID);
            lblDLApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.Application.ApplicationDate.ToShortDateString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LocalDrivingLicenseApplication.LicenseClass.Name);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.Application.ApplicationTypeInfo.ApplicationFees.ToString();
            lblUserName.Text = _LocalDrivingLicenseApplication.Application.UserInfo.UserName;
        }

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab =
                    tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter.PersonID != -1)
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLocalDrivingLicenseApplicationInfo.SelectedTab =
                    tcLocalDrivingLicenseApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }
            else
            {
                MessageBox.Show("Please Select A Person,", "Select A Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter.FilterFocus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter.PersonID == -1)
            {
                MessageBox.Show("Please Select A Person,", "Select A Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter.FilterFocus();
                return;
            }

            _LocalDrivingLicenseApplication.Application.ApplicationPersonID = ctrlPersonCardWithFilter.PersonID;
            _LocalDrivingLicenseApplication.Application.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.Application.ApplicationType = clsApplication.enApplicationType.NewLocalDrivingLicenseService;
            _LocalDrivingLicenseApplication.Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.Application.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.Application.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.Application.CreatedByUserID = GlobalSettings.CurrentUser.UserID;

            int LicenseClassID = clsLicenseClass.GetLicenseClassIDBy(cbLicenseClasses.Text);
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(
                        ctrlPersonCardWithFilter.PersonID,
                        clsApplication.enApplicationType.NewLocalDrivingLicenseService,
                        LicenseClassID
                        );

            if (_LocalDrivingLicenseApplication.LicenseClassID != clsLicenseClass.GetLicenseClassIDBy(cbLicenseClasses.Text))
            {
                if (ActiveApplicationID != -1)
                {
                    MessageBox.Show($"Choose Another License Class, The Selected Person Already Have An Active Application For The Selected Class With ID = {ActiveApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter.PersonID, LicenseClassID))
            {
                MessageBox.Show("Choose Another License Class, The Selected Person Already Have An Active Application For The Selected Class ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LocalDrivingLicenseApplication.Application.Save())
            {
                _LocalDrivingLicenseApplication.ApplicationID = _LocalDrivingLicenseApplication.Application.ApplicationID;
                _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

                if (_LocalDrivingLicenseApplication.Save())
                {
                    lblDLApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();

                    MessageBox.Show("Saved Data Successfully", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Local Driving License Application";

                    if (DataBack != null)
                        DataBack.Invoke();
                }
                else
                {
                    MessageBox.Show("Saved Data Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Saved Data Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter.FilterFocus();
        }
    }
}