using DVDL.DAL;
using System;
using System.Data;

namespace DVDL.BLL
{
    public class clsDriver
    {
        public enum enMode { Add = 0, Update = 2};
        public enMode Mode = enMode.Add;

        public int DriverID {  get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsPerson PersonInfo { get; set; }
        public clsUser UserInfo { get; set; }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.Add;
        }

        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFind = clsDriverData.GetDriverInfoByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);

            if (IsFind)
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

            return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFind = clsDriverData.GetDriverInfoByPersonID
                            (PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate);

            if (IsFind)
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

            return null;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID, this.CreatedDate);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateDriver();
            }
            return false;
        }

        public static bool IsPersonDriver(int PersonID) => clsDriverData.IsPersonDriver(PersonID);

        public static int GetDriverIDBy(int PersonID) => clsDriverData.GetDriverIDBy(PersonID);

        public static DataTable GetAllDrivers() => clsDriverData.GetAllDrivers();

        public static DataTable GetLicense(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetInternationalLicenses(DriverID);
        }
    }
}