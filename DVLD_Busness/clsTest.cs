using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsTest
    {
        public int id { get; set; }

        public int test_appointment_id { get; set; }
        public bool test_result { get; set; }

        public string notes { get; set; }

        public int created_by_user_id { set; get; }

        public clsTest()
        {
            this.id = -1;
            this.test_result = false;
            this.test_appointment_id = -1;
            this.notes = string.Empty;
            this.created_by_user_id = -1;
        }


        private clsTest(int id, int test_appointment_id, bool test_result, string notes, int created_by_user_id)
        {
            this.id = id;
            this.test_appointment_id = test_appointment_id;
            this.test_result = test_result;
            this.notes = notes;
            this.created_by_user_id = created_by_user_id;
        }

        private bool _AddNewTest()
        {
            this.id = clsTestData.AddNewTest(this.test_appointment_id,this.created_by_user_id,this.notes,this.test_result);

            return (this.id != -1);
        }
        public bool Save()
        {
            return _AddNewTest();
        }
    }
}
