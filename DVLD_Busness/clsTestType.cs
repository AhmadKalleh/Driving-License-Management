using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsTestType
    {
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public decimal fees { get; set; }

        public static readonly Dictionary<string, int> Test_Type_With_ID = new Dictionary<string, int>
        {
            {"Vision Test"  , 1 },
            {"Written Test" , 2 },
            {"Street Test"  , 3 }
        };

        public clsTestType()
        {
            this.id = -1;
            this.title = string.Empty;
            this.description = string.Empty;
            this.fees = 0;
        }

        public clsTestType(int id, string title, decimal fees,string description)
        {
            this.id = id;
            this.title = title;
            this.fees = fees;
            this.description = description;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(id,this.title,this.description,this.fees);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestsTypes ();

        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static clsTestType Find(int id)
        {

            string title = "", description = "";
            decimal fees = 0;

            if (clsTestTypeData.GetTestTypeInfoByID(id,ref title, ref description, ref fees))
            {
                return new clsTestType(id,title,fees,description);
            }


            else
                return null;
        }
    }
}
