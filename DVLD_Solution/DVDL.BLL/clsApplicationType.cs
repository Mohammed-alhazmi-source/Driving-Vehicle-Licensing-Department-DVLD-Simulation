using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsApplicationType
    {
        public enum enMode { Add = 0, Update = 1};
        public enMode Mode = enMode.Add;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationFees = 0;
            Mode = enMode.Add;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationFees;
            Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {
            return false;

            //TODO...
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID,this.ApplicationTypeTitle,
                                                                this.ApplicationFees); 
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = "";
            decimal Fees = 0;

            bool IsFind = clsApplicationTypeData.GetApplicationTypeInfoByID(ID, ref Title, ref Fees);

            if(IsFind)
                return new clsApplicationType(ID, Title, Fees);

            return null;
        }

        public static DataTable GetAllApplicationsTypes() => clsApplicationTypeData.GetAllApplicationTypes();

        public static decimal GetFeesByApplicationType(int ApplicationTypeID)
        {
            return clsApplicationTypeData.GetFeesByApplicationType(ApplicationTypeID);
        }

        public static bool IsApplicationTypeExist(string Title) => clsApplicationTypeData.IsApplicationTypeExist(Title);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateApplicationType();
            }

            return false;
        }

    }
}