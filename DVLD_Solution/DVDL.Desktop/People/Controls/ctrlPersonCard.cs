using DVDL.BLL;
using DVDL.Desktop.People.Forms;
using DVDL.Desktop.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVDL.Desktop.People.UserControls
{
    public partial class ctrlPersonCard : UserControl
    {
        private enum enGendor { Male = 0, Female = 1 };

        public event Action DataBackEventHandler;

        private int _PersonID = -1;
        
        public int PersonID => _PersonID;

        private clsPerson _Person;

        public clsPerson SelectedPersonInfo => _Person;

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[?????]";
            lblFullName.Text = "[?????]";
            lblNationalNo.Text = "[?????]";
            lblGendor.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblAddres.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblCountry.Text = "[?????]";
            llEditPerson.Enabled = false;
            pbPersonImage.Image = Resources.Male_512;
        }

        private void _LoadPersonImage()
        {
            if (string.IsNullOrEmpty(_Person.ImagePath))
            {
                if (_Person.Gender == (byte)enGendor.Male)
                    pbPersonImage.Image = Resources.Male_512;

                else
                    pbPersonImage.Image = Resources.Female_512;
            }

            else if (File.Exists(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;

            else
                MessageBox.Show($"Could Not Find This Image = {_Person.ImagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void _FillPersonInfo()
        {
            llEditPerson.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = (_Person.Gender == (byte)enGendor.Male ? "Male" : "Female");
            lblEmail.Text = (string.IsNullOrEmpty(_Person.Email) ? "[?????]" : _Person.Email);
            lblAddres.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.Name;
            _LoadPersonImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if(_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person With PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Person With NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_PersonID == -1)
            {
                MessageBox.Show("No Person With PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddUpdatePerson UpdatePerson = new frmAddUpdatePerson(_PersonID);
            UpdatePerson.DataBack += UpdatePerson_DataBack;
            UpdatePerson.ShowDialog();           
        }

        private void UpdatePerson_DataBack(object sender, int PersonID)
        {
            LoadPersonInfo(_PersonID);
            DataBackEventHandler?.Invoke();
        }
    }
}