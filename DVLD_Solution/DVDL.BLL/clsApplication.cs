using DVDL.DAL;
using System;

namespace DVDL.BLL
{
    public class clsApplication
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 };

        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1, RenewDrivingLicenseService = 2,
            ReplacementForaLostDrivingLicense = 3, ReplacementForaDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6,
            RetakeTest = 7
        }

        public int ApplicationID { get; set; }

        public int ApplicationPersonID { get; set; }

        public clsPerson PersonInfo { get; set; }

        public DateTime ApplicationDate { get; set; }

        public enApplicationType ApplicationType { get; set; }

        public clsApplicationType ApplicationTypeInfo { get; set; }

        public enApplicationStatus ApplicationStatus { get; set; }

        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New: return "New";
                    case enApplicationStatus.Canceled: return "Canceled";
                    case enApplicationStatus.Completed: return "Competed";
                    default: return "Unknown";
                }
            }
        }

        public DateTime LastStatusDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUser UserInfo { get; set; }

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationType = enApplicationType.NewLocalDrivingLicenseService;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            Mode = enMode.Add;
        }

        private clsApplication(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate,
            enApplicationType ApplicationTypeID,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationType = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonInfo = clsPerson.Find(this.ApplicationPersonID);
            this.ApplicationTypeInfo = clsApplicationType.Find((int)this.ApplicationType);
            this.UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }


        public static clsApplication Find(int ApplicationID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            byte ApplicationStatus = (byte)enApplicationStatus.New;
            int ApplicationTypeID = (int)enApplicationType.NewLocalDrivingLicenseService;

            bool IsFind = clsApplicationData.GetApplicationInfoByID
                (
                  ApplicationID, ref PersonID, ref ApplicationDate, ref ApplicationTypeID,
                  ref ApplicationStatus, ref LastStatusDate, ref PaidFees,
                  ref CreatedByUserID
                );

            if (IsFind)
                return new clsApplication(ApplicationID, PersonID, ApplicationDate, (enApplicationType)ApplicationTypeID,
                    (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return null;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication
                (
                    this.ApplicationPersonID, this.ApplicationDate, (int)this.ApplicationType,
                    (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID
                );

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication
                (
                  this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate, (byte)this.ApplicationType,
                  (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees
                  , this.CreatedByUserID
                );
        }

        public bool UpdateStatus()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, (int)this.ApplicationStatus);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Canceled);
        }

        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, (int)enApplicationStatus.Completed);
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }
       
        public static bool DoesPersonHaveActiveApplication(int PersonID, enApplicationType ApplicationTypeID)
        {
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return (GetActiveApplicationID(this.PersonInfo.PersonID, (enApplicationType)ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID,  enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public static int HasIncompleteRequestOfType(int PersonID, enApplicationStatus ApplicationStatus, 
                                                      int LicenseClassID)
        {
            return clsApplicationData.HasIncompleteRequestOfType(PersonID, (int)ApplicationStatus, LicenseClassID);
        }

        public static bool HasLicenseInCategory(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.HasLicenseInCategory(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }           
    }
}