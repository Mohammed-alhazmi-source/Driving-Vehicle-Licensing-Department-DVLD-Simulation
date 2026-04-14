using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsTest
    {
        public enum enMode { Add = 0, Update = 1};
        public enMode Mode = enMode.Add;

        public int TestID {  get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; } 
        public int CreatedByUserID { get; set; }

        public clsTestAppointment TestAppointmentInfo { get; set; }
        public clsUser UserInfo { get; set; }

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = null;
            CreatedByUserID = -1;
            Mode = enMode.Add;
        }

        private clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            TestAppointmentInfo = clsTestAppointment.Find(this.TestAppointmentID);
            UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            Mode = enMode.Update;
        }

        public static clsTest FindByTestID(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = null;

            bool IsFind = clsTestData.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes,
                                                         ref CreatedByUserID);

            if (IsFind)
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return null;
        }

        public static clsTest FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            bool IsFind = clsTestData.GetTestInfoByTestAppointmentID
                           (
                               TestAppointmentID,ref TestID, ref TestResult, ref Notes, ref CreatedByUserID
                           );

            if (IsFind)
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return null;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }

        private bool _UpdateTest() => clsTestData.UpdateTest(this.TestID, this.Notes);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateTest();
            }

            return false;
        }

        public static DataTable GetAllTests() => clsTestData.GetAllTests();

        public static int GetPassedTestsCount(int LocalAppID)
        {
            return clsTestData.GetPassedTestsCount(LocalAppID);
        }

        public bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return (GetPassedTestsCount(LocalDrivingLicenseApplicationID) == 3);
        }

        public static clsTest FindLastTestPerPersonIDAndTestTypeIDAndLicenseClassID(
            int PersonID, clsTestType.enTestType TestTypeID, int LicenseClassID)
        {
            int TestID = -1, TestAppointmentID = -1, CreateByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            bool IsFind = clsTestData.GetLastTestByPersonIDAndTestTypeIDAndLicenseClassID
                (
                    PersonID, (int)TestTypeID,LicenseClassID,
                    ref TestID, ref TestAppointmentID,
                    ref TestResult, ref CreateByUserID, ref Notes
                );

            if(IsFind)
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreateByUserID);

            return null;
        }
    }
}