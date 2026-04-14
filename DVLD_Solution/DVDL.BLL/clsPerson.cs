using DVDL.DAL;
using System;
using System.Data;

namespace DVDL.BLL
{
    public class clsPerson
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {SecondName} {ThirdName} {LastName}"; }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
        public clsCountry CountryInfo;

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.Add;
        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName,
                    string thirdName, string lastName, DateTime dateOfBirth, byte gender, string address,
                    string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            CountryInfo = clsCountry.Find(nationalityCountryID);
            ImagePath = imagePath;
            Mode = enMode.Update;
        }

        public static clsPerson Find(int PersonID)
        {
            string nationalNo = "", firstName = "", secondName = "", thirdName = "", lastName = "";
            DateTime dateOfBirth = DateTime.Now; byte gender = 0; string address = "";
            string phone = ""; string email = ""; int nationalityCountryID = 190; string imagePath = "";

            if (clsPersonData.GetPersonInfoByID(PersonID, ref nationalNo, ref firstName, ref secondName,
                                      ref thirdName, ref lastName, ref dateOfBirth, ref gender,
                                      ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath
                                      ))
            {
                return new clsPerson(PersonID, nationalNo, firstName, secondName, thirdName, lastName,
                    dateOfBirth, gender, address, phone, email, nationalityCountryID, imagePath);
            }

            return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1; string firstName = "", secondName = "", thirdName = "", lastName = "";
            DateTime dateOfBirth = DateTime.Now; byte gender = 0; string address = "";
            string phone = ""; string email = ""; int nationalityCountryID = 190; string imagePath = "";

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref firstName, ref secondName,
                                      ref thirdName, ref lastName, ref dateOfBirth, ref gender,
                                      ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath
                                      ))
            {
                return new clsPerson(PersonID, NationalNo, firstName, secondName, thirdName, lastName,
                    dateOfBirth, gender, address, phone, email, nationalityCountryID, imagePath);
            }

            return null;
        }

        public static bool IsPersonExist(string NationalNo) => clsPersonData.IsPersonExist(NationalNo);
        
        public static bool IsPersonExist(int PersonID) => clsPersonData.IsPersonExist(PersonID);

        public static bool IsPersonPhoneExist(string Phone) => clsPersonData.IsPersonPhoneExist(Phone);

        public static bool IsPersonEmailExist(string Email) => clsPersonData.IsPersonEmailExist(Email);

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson
                                                          (
                                                            this.NationalNo,
                                                            this.FirstName, this.SecondName, this.ThirdName,
                                                            this.LastName, this.DateOfBirth, this.Gender,
                                                            this.Address, this.Phone, this.Email,
                                                            this.NationalityCountryID,this.ImagePath
                                                          );

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson
                (
                  this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
                  this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email,
                  this.NationalityCountryID, this.ImagePath
                );
        }

        public static bool DeletePerson(int PersonID) => clsPersonData.DeletePerson(PersonID);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                        
                    else
                        return false;

                case enMode.Update: return _UpdatePerson();
            }

            return false;
        }

        public static DataTable GetAllPeople() => clsPersonData.GetAllPeople();
    }
}