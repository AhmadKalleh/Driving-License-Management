using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Busness.clsPerson;

namespace DVLD_Busness
{
    public class clsCountry
    {
        public int id { set; get; }

        public string country_name { set; get; }

        public clsCountry()

        {
            this.id = -1;
            this.country_name = "";

            

        }

        private clsCountry(int id, string country_name)

        {
            this.id = id;
            this.country_name = country_name;
            
        }

        public static clsCountry Find(int id)
        {

            string CountryName = "";
            
            
            if (clsCountryData.GetCountryInfoByID(id, ref CountryName))

                return new clsCountry(id, CountryName);
            else
                return null;

        }


        public static clsCountry Find(string country_name)
        {

            int id = -1;
            


            if (clsCountryData.GetCountryInfoByName(country_name, ref id))

                return new clsCountry(id, country_name);
            else
                return null;

        }
        public static List<string> GetAllCountries()
        {
            return clsCountryData.GetAllCountries();

        }
    }
}
