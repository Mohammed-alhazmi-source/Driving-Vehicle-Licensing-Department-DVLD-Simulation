using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsTestType
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3};

        public clsTestType.enTestType ID {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsTestType()
        {
            ID = clsTestType.enTestType.VisionTest;
            Title = "";
            Description = "";
            Fees = 0;
            Mode = enMode.Add;
        }

        private clsTestType(clsTestType.enTestType ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
            Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            this.ID =(clsTestType.enTestType) clsTestTypeData.AddNewTestType(this.Title, this.Description, this.Fees);

            return ((int)this.ID != - 1);
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public static clsTestType Find(clsTestType.enTestType ID)
        {
            string Title = "", Description = "";
            decimal Fees = 0;

            bool IsFind = clsTestTypeData.GetTestTypeInfoByID((int)ID, ref Title, ref Description, ref Fees);

            if (IsFind)
                return new clsTestType(ID, Title, Description, Fees);

            return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }

        public static DataTable GetAllTestTypes() => clsTestTypeData.GetAllTestTypes();

        public static bool IsTestTypeExist(string Title) => clsTestTypeData.IsTestTypeExist(Title);
    }
}