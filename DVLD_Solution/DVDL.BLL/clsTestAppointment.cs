using DVDL.DAL;
using System;
using System.Data;

namespace DVDL.BLL
{
    public class clsTestAppointment
    {
        public enum enMode { Add = 0, Update = 1 }
        public enMode Mode = enMode.Add;

        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public int LocalAppId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public int TestID => _GetTestID();


        public clsTestType TestTypeInfo { get; set; }
        public clsLocalDrivingLicenseApplication LocalAppInfo { get; set; }
        public clsUser UserInfo { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LocalAppId = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            RetakeTestApplicationID = -1;
        }

        private clsTestAppointment
            (
                int testAppointmentID, clsTestType.enTestType testTypeID, int localAppId, DateTime appointmentDate,
                decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID
            )
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalAppId = localAppId;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            TestTypeInfo = clsTestType.Find(testTypeID);
            LocalAppInfo = clsLocalDrivingLicenseApplication.Find(localAppId);
            UserInfo = clsUser.FindByUserID(createdByUserID);
            RetakeTestApplicationInfo = clsApplication.Find(retakeTestApplicationID);
            Mode = enMode.Update;
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = (int)clsTestType.enTestType.VisionTest;
            int LocalAppID = -1, CreatedByUserID = -1;
            int RetakeTestApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;

            bool IsFind = clsTestAppointmentData.GetTestAppointmentInfoByID
                (
                    TestAppointmentID, ref TestTypeID, ref LocalAppID, ref AppointmentDate,
                    ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID
                );

            if (IsFind)
                return new clsTestAppointment
                    (
                        TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalAppID, AppointmentDate,
                        PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                    );

            return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment
                (
                  (int)this.TestTypeID, this.LocalAppId, this.AppointmentDate, this.PaidFees, this.CreatedByUserID,
                  this.IsLocked, this.RetakeTestApplicationID
                );

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment
                (this.TestAppointmentID, (int)this.TestTypeID, this.LocalAppId, this.AppointmentDate, this.PaidFees,
                this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }
        
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update:
                    return _UpdateTestAppointment();
            }

            return false;
        }

        public bool UpdateStatus()
        {
            return clsTestAppointmentData.UpdateStatus(this.TestAppointmentID, true);
        }

        public static DataTable GetAllTestAppointments() => clsTestAppointmentData.GetAllTestAppointments();

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalAppID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalAppID, (int)TestTypeID);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalAppId, (int)TestTypeID);
        }

        public static bool IsLastTestAppointmentNotLocked(int LocalAppID, int TestTypeID, ref bool IsLocked)
        {
            return clsTestAppointmentData.IsLastTestAppointmentNotLocked(LocalAppID, TestTypeID, ref IsLocked);
        }

        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            return clsTestAppointmentData.IsTestAppointmentLocked(TestAppointmentID);
        }

        private int _GetTestID() => clsTestAppointmentData.GetTestID(TestAppointmentID);
    }
}