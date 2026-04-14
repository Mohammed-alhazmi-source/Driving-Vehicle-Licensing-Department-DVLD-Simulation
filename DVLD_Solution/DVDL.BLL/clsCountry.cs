using DVDL.DAL;
using System.Data;

namespace DVDL.BLL
{
    public class clsCountry
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private clsCountry()
        {
            ID = -1;
            Name = "";
        }

        private clsCountry(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public static clsCountry Find(int ID)
        {
            string Name = "";

            bool IsFound = clsCountryData.GetCountryInfoByID(ID, ref Name);

            if(IsFound)
                return new clsCountry(ID, Name);

            return null;
        }

        public static clsCountry Find(string Name)
        {
            int ID = -1;

            bool IsFound = clsCountryData.GetCountryInfoByName(ref ID, Name);

            if (IsFound)
                return new clsCountry(ID, Name);

            return null;
        }

        public static DataTable GetAllCountries() => clsCountryData.GetAllCountries();
    }
}