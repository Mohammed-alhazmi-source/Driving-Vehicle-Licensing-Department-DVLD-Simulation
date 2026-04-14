using DVDL.DAL;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace DVDL.BLL
{
    public class clsDetainedLicense
    {
        public enum enMode { Add= 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public int DetainID {  get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        //public clsLicense LicenseInfo { get; set; }
        public clsUser CreatedByUserInfo { get; set; }
        public clsUser ReleasedByUserInfo { get; set; }
        public clsApplication ApplicationInfo { get; set; }

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;            
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
            Mode = enMode.Add;
        }

        private clsDetainedLicense
            (
                int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees,
                int CreatedByUserID, bool IsReleased, DateTime? ReleaseDate,
                int ReleasedByUserID, int ReleaseApplicationID
            )
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            // هذه تحميل معلومات الرخصة راح تعمل تكرار في الاستدعاءات ولن يتم التنفيذ
            // لان اصلا في طبق منطق الرخصة بيتم تحميل معلومات الحجز للرخصة وهنا ايضا نريد نحمل معلومات 
            // الرخصة راح يدخل في تكرار هذا بفضل الله ثم بفضل التتبع اكتشتفت هذه المشكلة 
            //this.LicenseInfo = clsLicense.FindByLicenseID(this.LicenseID);

            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.ReleasedByUserInfo = clsUser.FindByUserID(this.ReleasedByUserID);
            this.ApplicationInfo = clsApplication.Find(this.ReleaseApplicationID);
            Mode = enMode.Update;
        }

        public static clsDetainedLicense FindByID(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            decimal FineFees = 0; 
            bool IsReleased = false;
            DateTime DetainDate = DateTime.Now;
            DateTime? ReleaseDate = null;

            bool IsFound = clsDetainedLicenseData.GetDetainedLicenseInfoByID
                             (
                                 DetainID, ref LicenseID, ref DetainDate, ref FineFees,
                                 ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID,
                                 ref ReleaseApplicationID
                             );

            if (IsFound)
                return new clsDetainedLicense
                    (
                        DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                        ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                    );

            return null;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime DetainDate = DateTime.Now;
            DateTime? ReleaseDate = null;

            bool IsFound = clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID
                             (
                                 LicenseID, ref DetainID, ref DetainDate, ref FineFees,
                                 ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID,
                                 ref ReleaseApplicationID
                             );

            if (IsFound)
                return new clsDetainedLicense
                    (
                        DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                        ReleaseDate, ReleasedByUserID, ReleaseApplicationID
                    );

            return null;
        }

        private bool _AddNewDetainLicense()
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense
                            (
                                this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID                                
                            );

            return (this.DetainID != -1);
        }

        private bool _UpdateDetainLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense
                (
                    this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID                 
                );
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewDetainLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateDetainLicense();
            }

            return false;
        }

        public static bool IsDetainedLicense(int LicenseID)
        {
            return clsDetainedLicenseData.IsDetainedLicense(LicenseID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public bool ReleaseDetainLicense(int ReleasedByUserID, int ApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainLicense(this.DetainID, ReleasedByUserID, ApplicationID);
            //clsDetainedLicense ReleaseLicense = new clsDetainedLicense();

            //ReleaseLicense.LicenseID = this.LicenseID;
            //ReleaseLicense.DetainDate = this.DetainDate;
            //ReleaseLicense.FineFees = this.FineFees;
            //ReleaseLicense.CreatedByUserID = this.CreatedByUserID;
            //this.IsReleased = true;
            //this.ReleaseDate = DateTime.Now;
            //this.ReleasedByUserID = ReleasedByUserID;
            //this.ReleaseApplicationID = ApplicationID;

            //if (!this.Save())
            //    return false;

            //return true;
        }       
    }
}