using DVDL.DAL;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL.BLL
{
    public class clsLicense
    {
        public enum enMode { Add = 0 , Update = 1};
        public enMode Mode = enMode.Add;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 };

        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public string IssueReasonText => GetIssueReasonText(this.IssueReason);

        public clsApplication ApplicationInfo { get; set; }
        public clsDriver DriverInfo { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }

        public clsDetainedLicense DetainedInfo { get; set; }

        public bool IsDetained => clsDetainedLicense.IsDetainedLicense(this.LicenseID);

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;
            Mode = enMode.Add;
        }

        private clsLicense
            (
                int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, 
                enIssueReason IssueReason, int CreatedByUserID
            )
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            
            ApplicationInfo = clsApplication.Find(this.ApplicationID);
            DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
            DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

            Mode = enMode.Update;
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = (byte)enIssueReason.FirstTime;

            bool IsFind = clsLicenseData.GetLicenseInfoByID
                (
                    LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate,
                    ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID
                );

            if (IsFind)
                return new clsLicense
                    (
                        LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                        Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID
                    );

            return null;
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = (byte)enIssueReason.FirstTime;

            bool IsFind = clsLicenseData.GetLicenseInfoByApplicationID
                (
                    ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate,
                    ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID
                );

            if (IsFind)
                return new clsLicense
                    (
                        LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                        Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID
                    );

            return null;
        }

        public static clsLicense FindByDriverID(int DriverID)
        {
            int LicenseID = -1, ApplicationID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = (byte)enIssueReason.FirstTime;

            bool IsFind = clsLicenseData.GetLicenseInfoByDriverID
                (
                    DriverID, ref LicenseID, ref ApplicationID, ref LicenseClassID, ref IssueDate,
                    ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID
                );

            if (IsFind)
                return new clsLicense
                    (
                        LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                        Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID
                    );

            return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense
                (
                    this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate,
                    this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID
                );

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense
                (
                    this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
                    this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason,
                    this.CreatedByUserID
                );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateLicense();
            }
            return false;
        }

        public static DataTable GetAllLicenses() => clsLicenseData.GetAllLicenses();

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID); 
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            //return clsLicenseData.IsLicenseExistByPersonID(PersonID, LicenseClassID);

            return (clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int ApplicationPersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(ApplicationPersonID, LicenseClassID);
        }
        
        public Boolean IsLicenseExpired() => this.ExpirationDate < DateTime.Now;

        public bool DeactivateCurrentLicense() => clsLicenseData.DeactivateLicense(this.LicenseID);

        public string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case clsLicense.enIssueReason.FirstTime: return "First Time";
                case clsLicense.enIssueReason.Renew: return "Renew";
                case clsLicense.enIssueReason.ReplacementForDamaged: return "Replacement For Damaged";
                case clsLicense.enIssueReason.ReplacementForLost: return "Replacement For Lost";
            }

            return "";
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();
            
            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationType = clsApplication.enApplicationType.RenewDrivingLicenseService;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.RenewDrivingLicenseService);
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassInfo = this.LicenseClassInfo;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.Fees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationType =
                (
                    IssueReason == enIssueReason.ReplacementForDamaged 
                        ? clsApplication.enApplicationType.ReplacementForaDamagedDrivingLicense
                        : clsApplication.enApplicationType.ReplacementForaLostDrivingLicense
                );

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetFeesByApplicationType((int)Application.ApplicationType);
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save()) return null;

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassInfo = this.LicenseClassInfo;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0; // no fees for the license because it's a replacement 
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save()) return null;

            DeactivateCurrentLicense();

            return NewLicense;
        }

        public int Detain(decimal FineFees, int CreatedByUserID)
        {
            clsDetainedLicense DetainLicense = new clsDetainedLicense();

            DetainLicense.LicenseID = this.LicenseID;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.FineFees = FineFees;
            DetainLicense.CreatedByUserID = CreatedByUserID;

            if (DetainLicense.Save())
                return DetainLicense.DetainID;

            return -1;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationType = clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.GetFeesByApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense);
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            return this.DetainedInfo.ReleaseDetainLicense(ReleasedByUserID, Application.ApplicationID);
        }
    }
}