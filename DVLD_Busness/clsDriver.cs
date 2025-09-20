using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsDriver
    {
        
        public int id { set; get; }

        public int person_id { set; get; }

        public int created_by_user_id { set; get; }

        public DateTime created_date { get; set; }

        public clsPerson perosn_info;

        public clsDriver()
        {
            
            this.id = -1;
            this.person_id = -1;
            this.created_by_user_id = -1;
            this.created_date = DateTime.Now;
        }

        private clsDriver(int  id,int person_id,int created_by_user_id,DateTime created_date)
        {
            

            this.id = id;
            this.person_id = person_id;
            this.created_by_user_id=created_by_user_id;
            this.created_date = created_date;
        }

        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "Driver ID", @"SELECT * FROM vDriversSummary WHERE DriverID = @DriverID"},

            { "National No", @"SELECT * FROM vDriversSummary WHERE NationalNo = @NationalNo" },

            { "Person ID", @"SELECT * FROM vDriversSummary WHERE PersonID = @PersonID"},

            { "Full Name", @"SELECT * FROM vDriversSummary WHERE FullName LIKE '%' + @FullName + '%'"},

            { "None", @"SELECT * FROM vDriversSummary"}
        };

        public static DataTable filter(string query, object filterValue)
        {
            return clsDriverData.filter(query, filterValue);
        }

        public bool Save()
        {
            return _AddNewDriver();
        }

        private bool _AddNewDriver()
        {


            this.id = clsDriverData.AddNewDriver(this.person_id, this.created_by_user_id,this.created_date);

            return (this.id != -1);
        }

        public static clsDriver Find(int id)
        {
            int perosn_id = -1, created_by_user_id = -1;
            DateTime created_date = DateTime.Now;



            if (clsDriverData.GetDriverInfoByID(id, ref perosn_id, ref created_by_user_id, ref created_date))
            {
                return new clsDriver(id,perosn_id,created_by_user_id,created_date);
            }


            else
                return null;
        }

        public static int Find_By_Person_ID(int perosn_id)
        {
            int driver_id = -1;



            if (clsDriverData.GetDriverInfoByPersonID(ref driver_id,perosn_id))
            {
                return driver_id;
            }


            else
                return -1;
        }

        public static bool IsDriverExist(int perosn_id)
        {
            return clsDriverData.IsDriverExist(perosn_id);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();

        }
    }
}
