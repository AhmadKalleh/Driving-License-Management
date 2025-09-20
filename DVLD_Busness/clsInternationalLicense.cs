using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsInternationalLicense
    {
        public int id { get; set; }

        public int application_id { get; set; }

        public int driver_id { get; set; }

        public int issued_using_local_license_id { get; set; }

        public DateTime issue_date { set; get; }

        public DateTime expiration_date { set; get; }

        public bool is_active { set; get; }


        public int created_by_user_id { set; get; }

        public clsInternationalLicense()
        {
            this.id = -1;
            this.application_id = -1;
            this.driver_id = -1;
            this.created_by_user_id = -1;
            this.issue_date = DateTime.Now;
            this.expiration_date = DateTime.Now;
            this.is_active = false;
            this.issued_using_local_license_id = -1;

        }

        public clsInternationalLicense(int id, int application_id, int driver_id, int issued_using_local_license_id,
            DateTime issue_date, DateTime expiration_date, bool is_active, int created_by_user_id)
        {
            this.id = id;
            this.application_id = application_id;
            this.driver_id = driver_id;
            this.issued_using_local_license_id = issued_using_local_license_id;
            this.issue_date = issue_date;
            this.expiration_date = expiration_date;
            this.is_active = is_active;
            this.created_by_user_id = created_by_user_id;
        }

        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "International License ID", @"SELECT * FROM InternationalLicenses IL WHERE IL.InternationalLicenseID = @InternationalLicenseID  ORDER BY IL.IssueDate DESC"},

            { "Local License ID", @"SELECT * FROM InternationalLicenses IL WHERE IL.IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID  ORDER BY IL.IssueDate DESC" },

            { "Status", @"SELECT * FROM InternationalLicenses IL WHERE IL.IsActive = @IsActive  ORDER BY IL.IssueDate DESC"},

            { "None", @"SELECT * FROM InternationalLicenses IL ORDER BY IL.IssueDate DESC"}
        };

        public static DataTable filter(string query, object filterValue)
        {
            return clsInternationalLicenseData.filter(query, filterValue);
        }

        public static DataTable GetAllInternationalLicensesByDriverID(int driver_id)
        {
            return clsInternationalLicenseData.GetAllInternationalLicensesByDriverID(driver_id);

        }

        private bool _AddNewInternational()
        {
            this.id = clsInternationalLicenseData.AddNewInternational(this.application_id,this.driver_id,this.issued_using_local_license_id,
                this.issue_date,this.expiration_date,this.is_active,this.created_by_user_id);
                

            return (this.id != -1);
        }

        public static clsInternationalLicense Find(int int_license_id)
        {
            int issued_using_local_license_id = -1, driver_id = -1, application_id = -1, created_by_user_id = -1;
            DateTime issue_date = DateTime.Now, expiration_date = DateTime.Now;
            
            bool is_active = false;
            



            if (clsInternationalLicenseData.GetInternationalLicenseInfoByID(int_license_id, ref application_id, ref driver_id, ref issued_using_local_license_id,
                ref issue_date, ref expiration_date,ref is_active, ref created_by_user_id))
            {
                return new clsInternationalLicense(int_license_id, application_id, driver_id, issued_using_local_license_id, issue_date, expiration_date, is_active, created_by_user_id);
            }


            else
                return null;
        }
        public bool Save()
        {
            return _AddNewInternational();
        }
        public static bool IsInternationalExistsForDriver(int driver_id,int licsnese_id)
        {
            return clsInternationalLicenseData.IsInternationalLicensesAvailable(driver_id,licsnese_id);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();

        }
    }
}
