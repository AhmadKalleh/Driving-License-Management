using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsLicenseClass
    {
        public int id {  get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public byte minimum_allowed_age { get; set; }

        public byte default_validity_length { get; set; }

        public decimal class_fees { get; set; }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public clsLicenseClass(int id, string name, string description, decimal class_fees, byte minimum_allowed_age, byte default_validity_length)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.class_fees = class_fees;
            this.minimum_allowed_age = minimum_allowed_age;
            this.default_validity_length = default_validity_length;
        }

        public static clsLicenseClass Find(int id)
        {

            string name = "", description = "";
            byte minimum_allowed_age = 0, default_validity_length = 0;
            decimal class_fees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(id, ref name, ref description, ref minimum_allowed_age,ref default_validity_length,ref class_fees))
            {
                return new clsLicenseClass(id, name, description,class_fees, minimum_allowed_age,default_validity_length);
            }


            else
                return null;
        }
    }
}
