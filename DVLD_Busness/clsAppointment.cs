using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int id { get; set; }

        public int test_type_id { get; set; }

        public int local_driving_license_applecation_id { get; set; }

        public DateTime appointment_date { get; set; }

        public decimal paid_fees { get; set; }

        public int created_by_user_id { set; get; }

        public bool is_locked { set; get; }

        public int retake_test_application_id { get; set; }

        public clsAppointment()
        {
            Mode = enMode.AddNew;
            this.id = -1;
            this.test_type_id = -1;
            this.created_by_user_id = -1;
            this.retake_test_application_id = -1;
            this.local_driving_license_applecation_id = -1;
            this.appointment_date = DateTime.Now;
            this.paid_fees = 0;
            this.is_locked = false;
        }

        public clsAppointment(int id, int test_type_id,int local_driving_license_applecation_id, DateTime appointment_date, 
            int created_by_user_id,int retake_test_application_id, decimal paid_fees, bool is_locked)
        {
            Mode = enMode.Update;
            this.id = id;
            this.test_type_id = test_type_id;
            this.created_by_user_id = created_by_user_id;
            this.retake_test_application_id = retake_test_application_id;
            this.local_driving_license_applecation_id = local_driving_license_applecation_id;
            this.appointment_date = appointment_date;
            this.paid_fees = paid_fees;
            this.is_locked = is_locked;
        }

        public static DataTable GetAllAppointments(int local_driving_license_applecation_id, int test_type_id)
        {
            return clsAppointmentData.GetAllAppointments(local_driving_license_applecation_id,test_type_id);

        }


        public static clsAppointment Find(int appointment_id)
        {
            int test_type_id = -1, local_driving_license_applecation_id = -1, created_by_user_id = -1, retake_test_application_id = -1;
            DateTime appointment_date = DateTime.Now;
            decimal paid_fees = 0;
            bool is_locked = false;


            if (clsAppointmentData.GetAppointmentInfoByID(appointment_id, ref test_type_id, ref local_driving_license_applecation_id, ref created_by_user_id, ref retake_test_application_id
                , ref appointment_date, ref paid_fees, ref is_locked))
            {
                return new clsAppointment(appointment_id, test_type_id, local_driving_license_applecation_id, appointment_date, created_by_user_id, 
                    retake_test_application_id, paid_fees, is_locked);
            }


            else
                return null;
        }
        public static (bool found, bool is_locked, bool test_result, int fail_count) GetLatestActiveAppointment(
                int local_driving_license_application_id,
                int test_type_id)
        {
            bool test_result = false;
            bool is_locked = false;
            int fail_count = 0;

            if (clsAppointmentData.GetLatestActiveAppointment(local_driving_license_application_id, test_type_id, ref is_locked, ref test_result, ref fail_count))
            {
                return (true, is_locked, test_result, fail_count);
            }

            return (false, false, false, 0);
        }



        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewAppointment())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return _UpdateAppointment();




            }




            return false;
        }

        private bool _AddNewAppointment()
        {


            this.id = clsAppointmentData.AddNewAppointment(this.test_type_id, this.local_driving_license_applecation_id, this.created_by_user_id,
                this.paid_fees, this.appointment_date,this.retake_test_application_id);

            return (this.id != -1);
        }

        private bool _UpdateAppointment()
        {
            return clsAppointmentData.UpdateAppointment(this.id, this.appointment_date,this.is_locked);
        }

    }
}
