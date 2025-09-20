using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsApplicationType
    {

        public int id {  get; set; }

        public string title { get; set; }

        public decimal fees { get; set; }

        public enum enApplicationType
        {
            NEWLOCALLICENSE = 1,
            RENEWDRIVINGLICENSE = 2,
            REPLACEMENTFORALOSTDRIVINGLICENSE = 3,
            REPLACEMENTFORADAMAGEDRIVINGLICENSE = 4,
            RELEASEDETAINEDDRIVINGLICENSE = 5,
            NEWINTERNATIONALLICENSE = 6,
            RETAKETEST = 7
        };
        public clsApplicationType() 
        {
            this.id = -1;
            this.title = string.Empty;
            this.fees = 0;
        }

        public clsApplicationType(int id, string title, decimal fees)
        {
            this.id = id;
            this.title = title;
            this.fees = fees;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.id, this.title, this.fees);
        }

        public static DataTable GetAllApplicationsTypes()
        {
            return clsApplicationTypeData.GetAllApplicationsTypes();

        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static clsApplicationType Find(int id)
        {
            
            string title = "";
            decimal fees = 0;

            if (clsApplicationTypeData.GetApplicationTypeInfoByID(id,ref title,ref fees))
            {
                return new clsApplicationType(id, title, fees);
            }


            else
                return null;
        }


    }
}
