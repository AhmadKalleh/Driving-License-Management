using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsLicense
    {
        public enum enIssueReason
        {
            FIRST_TIME = 1,
            RENEW = 2,
            REPLACEMENT_FOR_DAMAGED = 3,
            REPLACEMENT_FOR_LOST = 4
        };


        public int id { set; get; }

        public int application_id { set; get; }

        public int driver_id { set; get; }

        public int license_class_id { set; get; }

        public DateTime issue_date { set; get; }

        public DateTime expiration_date { set; get; }

        public string notes { set; get; }

        public decimal paid_fees { set; get; }

        public bool is_active { set; get; }

        public byte issue_reason { set; get; }

        public int created_by_user_id { set; get; }

        public static readonly Dictionary<int, string> Issue_reason = new Dictionary<int, string>
        {
            {1,"First Time" },
            {2,"Renew" },
            {3,"Replacement for damaged" },
            {4,"Replacement for lost" },
        };

        public clsLicense()
        {
            this.id = -1;
            this.application_id = -1;
            this.driver_id = -1;
            this.license_class_id = -1;
            this.created_by_user_id = -1;
            this.issue_date = DateTime.Now;
            this.expiration_date = DateTime.Now;
            this.paid_fees = 0;
            this.is_active = false;
            this.issue_reason = 0;
            this.notes = string.Empty;
        }

        private clsLicense(int id, int application_id, int driver_id, int license_class_id, DateTime issue_date, DateTime expiration_date, 
            string notes, decimal paid_fees, bool is_active, byte issue_reason, int created_by_user_id)
        {
            this.id = id;
            this.application_id = application_id;
            this.driver_id = driver_id;
            this.license_class_id = license_class_id;
            this.issue_date = issue_date;
            this.expiration_date = expiration_date;
            this.notes = notes;
            this.paid_fees = paid_fees;
            this.is_active = is_active;
            this.issue_reason = issue_reason;
            this.created_by_user_id = created_by_user_id;
        }

        private bool _AddNewLicense()
        {
            this.id = clsLicenseData.AddNewLicense(this.driver_id,this.application_id,this.license_class_id,this.created_by_user_id,
                this.issue_date,this.expiration_date, this.notes,this.paid_fees,this.is_active, this.issue_reason
                );

            return (this.id != -1);
        }

        public static clsLicense FindByDriverLicenseClassID(int driver_id,int license_class_id)
        {
            int license_id = -1, application_id = -1, created_by_user_id = -1;
            DateTime issue_date = DateTime.Now, expiration_date =DateTime.Now;
            string notes = string.Empty;
            decimal paid_fees = 0;
            bool is_active = false;
            byte issue_reason = 0;



            if (clsLicenseData.GetLicenseInfoByDriverLicenseClassID(driver_id, license_class_id, ref license_id, ref application_id, ref created_by_user_id, 
                ref issue_date,ref expiration_date,ref notes,ref paid_fees,ref is_active,ref issue_reason))
            {
                return new clsLicense(license_id, application_id, driver_id, license_class_id, issue_date, expiration_date,
                    notes, paid_fees, is_active, issue_reason, created_by_user_id
                    );
            }


            else
                return null;
        }

        public static clsLicense FindByLicenseDriverID(int driver_id, int license_id)
        {
            int license_class_id = -1, application_id = -1, created_by_user_id = -1;
            DateTime issue_date = DateTime.Now, expiration_date = DateTime.Now;
            string notes = string.Empty;
            decimal paid_fees = 0;
            bool is_active = false;
            byte issue_reason = 0;



            if (clsLicenseData.GetLicenseInfoByLicenseDriverID(driver_id, license_id, ref license_class_id, ref application_id, ref created_by_user_id,
                ref issue_date, ref expiration_date, ref notes, ref paid_fees, ref is_active, ref issue_reason))
            {
                return new clsLicense(license_id, application_id, driver_id, license_class_id, issue_date, expiration_date,
                    notes, paid_fees, is_active, issue_reason, created_by_user_id
                    );
            }


            else
                return null;
        }

        public static clsLicense FindByLicenseID(int license_id)
        {
            int license_class_id = -1,driver_id = -1, application_id = -1, created_by_user_id = -1;
            DateTime issue_date = DateTime.Now, expiration_date = DateTime.Now;
            string notes = string.Empty;
            decimal paid_fees = 0;
            bool is_active = false;
            byte issue_reason = 0;



            if (clsLicenseData.GetLicenseInfoByLicenseID(license_id, ref driver_id, ref license_class_id, ref application_id, ref created_by_user_id,
                ref issue_date, ref expiration_date, ref notes, ref paid_fees, ref is_active, ref issue_reason))
            {
                return new clsLicense(license_id, application_id, driver_id, license_class_id, issue_date, expiration_date,
                    notes, paid_fees, is_active, issue_reason, created_by_user_id
                    );
            }


            else
                return null;
        }
        public bool Save()
        {
            return _AddNewLicense();
        }

        public bool UpdateStatus(bool is_active)
        {
            return clsLicenseData.UpdateStatus(this.id,is_active);
        }

        public static DataTable GetAllLocalLicensesByDriverID(int driver_id)
        {
            return clsLicenseData.GetAllLocalLicensesByDriverID(driver_id);

        }

        public static string IsDetainedLicense(int license_id)
        {
            return clsLicenseData.IsDetainedLicense(license_id);
        }
    }
}
