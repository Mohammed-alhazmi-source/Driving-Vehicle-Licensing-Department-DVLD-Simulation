using DVDL.BLL;
using DVDL.Desktop.Classes;
using DVDL.Desktop.Properties;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVDL.Desktop.People.Forms
{
    public partial class frmAddUpdatePerson : Form
    {
        private enum enMode { Add = 0, Update = 1 };
        private enMode _Mode = enMode.Add;
        private enum enGendor { Male = 0, Female = 1 };

        private int _PersonID = -1;

        private clsPerson _person = null;

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;

        public event Action OnSaved;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private new bool ValidateChildren()
        {
            CancelEventArgs e = new CancelEventArgs();
            bool FoundError = false;
            if (txtFirstName.Text == "")
            {
                txtFirstName.Validating += ValidateEmptyTextBox;
                ValidateEmptyTextBox(txtFirstName, e);
                FoundError = true;
            }

            else if (txtSecondName.Text == "")
            {
                txtSecondName.Validating += ValidateEmptyTextBox;
                ValidateEmptyTextBox(txtSecondName, e);
                FoundError = true;
            }

            else if (txtLastName.Text == "")
            {
                txtLastName.Validating += ValidateEmptyTextBox;
                ValidateEmptyTextBox(txtLastName, e);
                FoundError = true;
            }

            else if (txtNationalNo.Text == "")
            {
                ValidateEmptyTextBox(txtNationalNo, e);
                FoundError = true;
            }

            else if (txtPhone.Text == "")
            {
                ValidateEmptyTextBox(txtPhone, e);
                FoundError = true;
            }

            else if (txtAddress.Text == "")
            {
                txtAddress.Validating += ValidateEmptyTextBox;
                ValidateEmptyTextBox(txtAddress, e);
                FoundError = true;
            }

            return FoundError;
        }

        private void LoadPersonInfo()
        {
            _person = clsPerson.Find(_PersonID);

            if (_person == null)
            {
                MessageBox.Show($"No Person With ID = {_PersonID}", "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Mode = enMode.Update;
            lblPersonID.Text = _person.PersonID.ToString();
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            txtNationalNo.Text = _person.NationalNo;
            dtpDateOfBirth.Value = _person.DateOfBirth;

            if (!string.IsNullOrEmpty(_person.ImagePath))
                pbPersonImage.ImageLocation = _person.ImagePath;

            if (_person.Gender == (byte)enGendor.Male) rbMale.Checked = true;
            else rbFemale.Checked = true;

            txtPhone.Text = _person.Phone;
            txtEmail.Text = _person.Email;
            cbCountries.SelectedIndex = cbCountries.FindString(_person.CountryInfo.Name);
            txtAddress.Text = _person.Address;

            if (!string.IsNullOrEmpty(_person.ImagePath))
                btnRemoveImage.Visible = true;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            Guna2TextBox txt = (Guna2TextBox)sender;

            if (txt != null)
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txt, "This Field Is Required");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txt, null);
                }
            }
        }

        private void RadioButtonCheckedChanged(object sender, Bitmap ImagePath)
        {
            Guna2CustomRadioButton rb = (Guna2CustomRadioButton)sender;

            if (rb != null)
            {
                if (rb.Checked)
                {
                    if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                        return;

                    pbPersonImage.Image = ImagePath;
                }
            }
        }

        // دالة عملها تقوم بتهيئة القيم الافتراضية للكنترولز
        private void _ResetDefaultValues()
        {
            // الدالة هذه تقوم بتعبية القائمة المنسدلة باسماء الدول القادمة من الداتا بيز
            _FillCountriesInComboBox();

            // اذا كان وضعية الكنترول اضافة يتم انشاء كائن من كلاس الشخص واسناد عنوان النموذج اضافة شخص جديد
            if (_Mode == enMode.Add)
            {
                if (_person == null)
                    _person = new clsPerson();

                lblTitle.Text = "Add New Person";          
            }
            else // اذا كان الوضعية تعديل فقط يغير عنوان الواجهة
            {
                lblTitle.Text = "Update Person";
            }

            // اذا كان اطار الصورة يحتوي على مسار صورة تم اختيارها نظهر رابط حذف الصورة غير ذلك لانظهره
            btnRemoveImage.Visible = !string.IsNullOrEmpty(pbPersonImage.ImageLocation);

            // عمر الشخص المقبول يكون 18 السنة الى 100 سنة
            // اقل عمر مسموع به هو 18 عام
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            // الحد الاقصى للعمر الافتراضي الذي يقبله النظام هو 100 عام
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            // تهيئة بقية الكونترول بالقيم الافتراضية لها 
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rbMale.Checked = true;
        }

        // دالة تقوم بتعبئة القائمة المنسدلة باسماء دول العالم المرجعة من قاعدة البيانات
        private void _FillCountriesInComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            foreach (DataRow Country in Countries.Rows)
            {
                cbCountries.Items.Add(Country["CountryName"]);
            }
            cbCountries.SelectedIndex = cbCountries.FindString("Yemen");
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
                ValidateEmptyTextBox(sender, e);

            if (_Mode == enMode.Add)
            {
                if (clsPerson.IsPersonPhoneExist(txtPhone.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPhone, "Phone Number Is Used For Another Person!");
                }

                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtPhone, "");
                }
            }

            // اذا كان موجود هذا الرقم من قبل في قاعدة البيانات لايسمح بالانتقال من الحقل
            else if (txtPhone.Text != _person.Phone && clsPerson.IsPersonPhoneExist(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone Number Is Used For Another Person!");
            }

            // رقم الهاتف لم يوجد من قبل يسمح بالاكمال في اضافة البيانات الباقية
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
                ValidateEmptyTextBox(sender, e);

            else if (_Mode == enMode.Add)
            {
                if (clsPerson.IsPersonExist(txtNationalNo.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "National Number Is Used For Another Person!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtNationalNo, null);
                }
            }

            else if (txtNationalNo.Text.Trim() != _person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "National Number Is Used For Another Person!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                errorProvider1.SetError(txtEmail, null);

            else if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "InValid Email Address Format!");
            }

            else if (_Mode == enMode.Add)
            {
                if (clsPerson.IsPersonEmailExist(txtEmail.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Email Address Is Used For Another Person!");
                }

                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, null);
                }
            }

            else if (txtEmail.Text.Trim() != _person.Email && clsPerson.IsPersonEmailExist(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Email Address Is Used For Another Person!");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonCheckedChanged(sender, Resources.Male_512);
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonCheckedChanged(sender, Resources.Female_512);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            openFile.DefaultExt = "png|*.png";
            openFile.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFile.FileName))
            {
                pbPersonImage.ImageLocation = openFile.FileName;
                btnRemoveImage.Visible = true;
            }
        }
      
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked) pbPersonImage.Image = Resources.Male_512;

            else pbPersonImage.Image = Resources.Female_512;

            btnRemoveImage.Visible = false;
        }

        private bool _HandlePersonImage()
        {
            if (_person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_person.ImagePath != "")
                {
                    File.Delete(_person.ImagePath);
                }
            }

            if (pbPersonImage.ImageLocation != null)
            {
                string SourceImageFile = pbPersonImage.ImageLocation;
                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonImage.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void AssignmentPersonInfo()
        {
            _person.NationalNo = txtNationalNo.Text;
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Gender = (rbMale.Checked ? (byte)enGendor.Male : (byte)enGendor.Female);
            _person.Address = txtAddress.Text;
            _person.Phone = txtPhone.Text;
            _person.Email = txtEmail.Text;
            _person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;
            _person.ImagePath = (string.IsNullOrEmpty(pbPersonImage.ImageLocation) ? "" : pbPersonImage.ImageLocation);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Doesn't Was Field Is Empty", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            AssignmentPersonInfo();

            if (_person.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblPersonID.Text = _person.PersonID.ToString();

                _Mode = enMode.Update;

                lblTitle.Text = "Update Person";

                DataBack?.Invoke(this, _person.PersonID);

                OnSaved?.Invoke();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                LoadPersonInfo();
        }

        private void frmAddUpdatePerson_Activated(object sender, EventArgs e)
        {
            txtFirstName.Focus();
        }
    }
}