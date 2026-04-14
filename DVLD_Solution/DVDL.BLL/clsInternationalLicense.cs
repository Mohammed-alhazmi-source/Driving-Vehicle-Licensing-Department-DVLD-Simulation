using DVDL.DAL;
using System;
using System.Data;

namespace DVDL.BLL
{
    public class clsInternationalLicense
    {
        public enum enMode { Add = 0, Update = 1};
        public enMode Mode = enMode.Add;

        public int InternationalLicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        
        public bool IsInternationalLicenseExpired => this.ExpirationDate < DateTime.Now;

        public clsApplication ApplicationInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsLicense LicenseInfo { get; set; }
        public clsUser UserInfo { get; set; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            IsActive = true;
            CreatedByUserID = -1;
            Mode = enMode.Add;
        }

        private clsInternationalLicense
            (
                int InternationalLicenseID, int ApplicationID, int DriverID, int LicenseID,
                DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID
            )
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseID = LicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationInfo = clsApplication.Find(this.ApplicationID);
            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseInfo = clsLicense.FindByLicenseID(this.LicenseID);
            this.UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            bool IsFound = clsInternationalLicenseData.GetInternationalLicenseInfoByID
                              (
                                  InternationalLicenseID, ref ApplicationID, ref DriverID,
                                  ref LicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, 
                                  ref CreatedByUserID
                              );

            if (IsFound)
                return new clsInternationalLicense
                    (
                        InternationalLicenseID, ApplicationID, DriverID, LicenseID, IssueDate,
                        ExpirationDate, IsActive, CreatedByUserID
                    );

            return null;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense
                                            (
                                                this.ApplicationID, this.DriverID, this.LicenseID, this.IssueDate,
                                                this.ExpirationDate, this.IsActive, this.CreatedByUserID
                                            );

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense
                (
                    this.InternationalLicenseID, this.ApplicationID, this.DriverID,
                    this.LicenseID, this.IssueDate, this.ExpirationDate, this.IsActive,
                    this.CreatedByUserID
                );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateInternationalLicense();
            }

            return false;
        }

        public bool DeactivateInternationalLicense()
        {
            return clsInternationalLicenseData.DeactivateInternationalLicense(this.InternationalLicenseID);
        }

        public static int GetActiveInternationalLicenseByLicenseID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseByLicenseID(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetInternationalLicenses(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static clsInternationalLicense IssueNewInternationalLicense(int LicenseID, int CreatedByUserID)
        {
            clsLicense LicenseInfo = clsLicense.FindByLicenseID(LicenseID);

            if (LicenseInfo == null)
                return null;

            clsApplication Application = new clsApplication();
            Application.ApplicationPersonID = LicenseInfo.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationType = clsApplication.enApplicationType.NewInternationalLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense);
            Application.CreatedByUserID = CreatedByUserID ;

            if (!Application.Save())
                return null;

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            InternationalLicense.ApplicationID = Application.ApplicationID;
            InternationalLicense.DriverID = LicenseInfo.DriverInfo.DriverID;
            InternationalLicense.LicenseID = LicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(clsSetting.GetInternationalLicenseValidityLength());
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID = CreatedByUserID;

            if (InternationalLicense.Save())
                return InternationalLicense;

            return null;
        }
    }
}