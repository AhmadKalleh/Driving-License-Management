using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enStatus
        {
            NEW = 1,
            COMPLETED = 2,
            CANCELED = 3
        };
        public int id { set; get; }
        public int person_id { set; get; }
        public int application_type_id { set; get; }
        public DateTime application_date { set; get; }
        public DateTime last_status_date { set; get; }
        public int created_by_user_id { set; get; }
        public decimal paid_fees { set; get; }
        public byte application_status { set; get; }

        public clsPerson perosn_info;   

        public clsApplicationType application_type;

        public clsApplication()
        {
            Mode = enMode.AddNew;
            this.id = -1;
            this.application_type_id = -1;
            this.application_date = DateTime.Now;
            this.last_status_date = DateTime.Now;
            this.created_by_user_id = -1;
            this.paid_fees = 0;
            this.application_status = 0;
            this.person_id = -1;

        }

        public clsApplication(int id, int perosn_id,int application_type_id,DateTime application_date,
            DateTime last_status_date,int created_by_user_id,decimal paid_fees,byte application_status)
        {
            Mode = enMode.Update;
            this.id = id;
            this.application_type_id = application_type_id;
            this.application_type = clsApplicationType.Find(application_type_id);
            this.person_id = perosn_id;
            this.perosn_info = clsPerson.Find(this.person_id);
            this.application_date = application_date;
            this.last_status_date = last_status_date;
            this.created_by_user_id = created_by_user_id;
            this.paid_fees = paid_fees;
            this.application_status = application_status;
        }


        public static clsApplication Find(int application_id)
        {
            int perosn_id = -1, application_type_id= -1, created_by_user_id=-1;
            DateTime application_date = DateTime.Now, last_status_date = DateTime.Now;
            decimal paid_fees = 0;
            byte application_status = 0;
           

            if (clsApplicationData.GetapplicationInfoByID(application_id, ref perosn_id,ref application_type_id,ref created_by_user_id, ref application_date
                , ref last_status_date, ref paid_fees,ref application_status))
            {
                return new clsApplication(application_id,perosn_id,application_type_id,application_date,last_status_date,created_by_user_id,paid_fees,application_status);
            }


            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    
                   if (_AddNewApplication())
                    {

                       Mode = enMode.Update;
                       return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                     return _UpdateApplication();
                    

            

            }




            return false;
        }

        private bool _AddNewApplication()
        {


            this.id = clsApplicationData.AddNewApplication(this.person_id,this.application_type_id,this.application_date,
                this.last_status_date,this.created_by_user_id,this.paid_fees,this.application_status);

            return (this.id != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.id, this.application_status, this.last_status_date);
        }

        public static bool DeleteApplication(int application_id)
        {
            return clsApplicationData.DeleteApplication(application_id);
        }

        public static bool UpdateApplicationsStatusByLocalDrivingLicense(int local_driving_license_application_id)
        {
            return clsApplicationData.UpdateLocalDrivingLicenseApplicationsStatus(local_driving_license_application_id);
        }
    }
}
