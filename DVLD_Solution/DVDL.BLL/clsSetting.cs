using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsSetting
    {
        public enum enMode { Add = 0, Update = 1};
        public enMode Mode = enMode.Add;

        private enum enSetting { One  = 1 };

        public int SettingID {  get; set; }
        public int InternationalLicenseValidityLength { get; set; }

        public clsSetting()
        {
            SettingID = -1;
            InternationalLicenseValidityLength = 1;
            Mode = enMode.Add;
        }

        private clsSetting(int SettingID, int InternationalLicenseValidityLength)
        {
            this.SettingID = SettingID;
            this.InternationalLicenseValidityLength = InternationalLicenseValidityLength;
            Mode = enMode.Update;
        }

        public static clsSetting Find(int SettingID)
        {
            int InternationalLicenseValidityLength = 1;

            bool IsFound = clsSettingData.GetSettingInfoByID(SettingID, ref InternationalLicenseValidityLength);

            if (IsFound)
                return new clsSetting(SettingID, InternationalLicenseValidityLength);

            return null;
        }

        private bool _AddNewInternationalLicenseValidityLength()
        {
            this.SettingID = clsSettingData.AddNewInternationalLicenseValidityLength(this.InternationalLicenseValidityLength);

            return (this.SettingID != -1);
        }

        private bool _UpdateInternationalLicenseValidityLength()
        {
            return clsSettingData.UpdateInternationalLicenseValidityLength(this.SettingID, this.InternationalLicenseValidityLength);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if(_AddNewInternationalLicenseValidityLength())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateInternationalLicenseValidityLength();
            }

            return false;
        }

        public static int GetInternationalLicenseValidityLength()
        {
            return Find((int)enSetting.One).InternationalLicenseValidityLength;
        }

        public static DataTable GetAllInternationalLicenseValidityLength()
        {
            return clsSettingData.GetAllInternationalLicenseValidityLength();
        }
    }
}