using DVDL.DAL;
using System;
using System.Data;

namespace DVDL.BLL
{
    public class clsLocalDrivingLicenseApplication
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public clsApplication Application { get; set; }
        public clsLicenseClass LicenseClass { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            ID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.Add;
        }

        private clsLocalDrivingLicenseApplication(int ID, int ApplicationID, int LicenseClassID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.Application = clsApplication.Find(this.ApplicationID);            
            this.LicenseClass = clsLicenseClass.Find(this.LicenseClassID);
            Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication Find(int ID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFind = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID
                (
                    ID, ref ApplicationID, ref LicenseClassID
                );

            if(IsFind)
                return new clsLocalDrivingLicenseApplication(ID, ApplicationID, LicenseClassID);

            return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFind = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (
                    ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID
                );

            if (IsFind)
                return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);

            return null;
        }

        public static int GetPersonIDByLocalDrivingLicenseApplicationID(int LDLAID)
        {
            return clsLocalDrivingLicenseApplicationData.GetPersonIDByLocalDrivingLicenseApplicationID(LDLAID);
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.ID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                (this.ApplicationID, this.LicenseClassID);

            return (this.ID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (this.ID, this.LicenseClassID);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID);
        }

        public bool Delete()
        {
            return DeleteLocalDrivingLicenseApplication(this.ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateLocalDrivingLicenseApplication();
            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationsDetails()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationsDetails();
        }

        public static int GetApplicationIDBy(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetApplicationIDBy(LocalDrivingLicenseApplicationID);
        }

        public int GetPassedTestsCount()
        {
            return clsTest.GetPassedTestsCount(this.ID);
        }        

        public bool IsLicenseIssued()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.Application.PersonInfo.PersonID, this.LicenseClassID) != -1;
        }

        public bool SetComplete()
        {
            return this.Application.SetComplete();
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.Application.PersonInfo.PersonID, this.LicenseClassID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.ID, (int)TestTypeID);
        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public int TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(ID, (int)TestTypeID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.ID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static clsTest GetLastPerTestType(int PersonID, clsTestType.enTestType TestTypeID,int LicenseClassID
            )
        {
            return clsTest.FindLastTestPerPersonIDAndTestTypeIDAndLicenseClassID(
                PersonID, TestTypeID, LicenseClassID);
        }

        public clsTest GetLastPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonIDAndTestTypeIDAndLicenseClassID(
                this.Application.PersonInfo.PersonID, TestTypeID,
                this.LicenseClassID);
        }

        public bool PassedAllTests()
        {
            return (clsTest.GetPassedTestsCount(this.ID) == 3);
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriver Driver = clsDriver.FindByPersonID(this.Application.PersonInfo.PersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.Application.PersonInfo.PersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.CreatedDate = DateTime.Now;


                if (Driver.Save())
                    DriverID = Driver.DriverID;
                else
                    DriverID = -1;
            }

            else
                DriverID = Driver.DriverID;

            clsLicense License = new clsLicense();
            License.ApplicationID = this.Application.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClassID = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClass.Fees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if(License.Save())
            {
                this.SetComplete();
                return License.LicenseID;
            }

            else return -1;
        }
    }
}