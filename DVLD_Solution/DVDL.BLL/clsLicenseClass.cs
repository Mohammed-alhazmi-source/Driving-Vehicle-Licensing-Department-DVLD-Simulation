using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsLicenseClass
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public int LicenseClassID {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal Fees { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID = -1;
            Name = "";
            Description = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = 5;
            Fees = 0;
            Mode = enMode.Add;
        }

        private clsLicenseClass(int ID, string Name, string Description, 
                                byte MinimumAllowedAge, byte DefaultValidityLength, decimal Fees)
        {
            this.LicenseClassID = ID;
            this.Name = Name;
            this.Description = Description;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;
            Mode = enMode.Update;
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass
                (                
                  this.Name, this.Description, this.MinimumAllowedAge, this.DefaultValidityLength, this.Fees
                );

            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass
                (
                  this.LicenseClassID, this.Name, this.Description, this.MinimumAllowedAge, 
                  this.DefaultValidityLength, this.Fees
                ) ;
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update: return _UpdateLicenseClass();
            }

            return false;
        }

        public static bool IsLicenseClassExist(string ClassName) => clsLicenseClassData.IsLicenseClassExist(ClassName);

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string Name = "", Description = "";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            decimal Fees = 0;

            bool IsFind = clsLicenseClassData.GetLicenseClassInfoByID
                (
                  LicenseClassID, ref Name, ref Description, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees
                );

            if (IsFind)
                return new clsLicenseClass(LicenseClassID, Name, Description, MinimumAllowedAge, DefaultValidityLength, 
                    Fees);

            return null;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = -1; string Description = "";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            decimal Fees = 0;

            bool IsFind = clsLicenseClassData.GetLicenseClassInfoByClassName
                (
                  ClassName, ref LicenseClassID, ref Description, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees
                );

            if (IsFind)
                return new clsLicenseClass(LicenseClassID, ClassName, Description, MinimumAllowedAge, DefaultValidityLength,
                    Fees);

            return null;
        }

        public static DataTable GetAllLicenseClasses() => clsLicenseClassData.GetAllLicenseClasses();

        public static int GetLicenseClassIDBy(string Name) => clsLicenseClassData.GetLicenseClassIDBy(Name);
    }
}