using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsDetainLicense
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int id {  get; set; }

        public int license_id { get; set; }

        public DateTime detain_date { get; set; }

        public decimal fine_fees { get; set; }

        public int created_by_user_id { get; set; }

        public bool is_released { get; set; }

        public DateTime? release_date { get; set; }

        public int ? released_by_user_id { get; set; }


        public int ? release_app_id { get; set; }

        public clsLicense license_info { get; set; }

        public clsApplication application_info { get; set; }


        public clsDetainLicense()
        {
            this.id = -1;
            this.license_id = -1;
            this.created_by_user_id = -1;
            this.released_by_user_id= -1;
            this.release_app_id = -1;
            this.license_info = new clsLicense();
            this.application_info = new clsApplication();   
            this.is_released = false;
            this.release_date = DateTime.Now;
            this.detain_date = DateTime.Now;
            this.fine_fees = 0;
            Mode = enMode.AddNew;

        }

        private clsDetainLicense(int id,int license_id,int created_by_user_id,int ? released_by_user_id,int ? release_app_id,
            bool is_released,DateTime ? release_date,DateTime detain_date,decimal fine_fees
            )
        {
            this.id = id;
            this.license_id = license_id;
            this.release_app_id= release_app_id;
            this.created_by_user_id = created_by_user_id;
            this.released_by_user_id = released_by_user_id ;
            this.is_released= is_released;
            this.release_date = release_date;
            this.detain_date= detain_date;
            this.fine_fees= fine_fees;
            Mode = enMode.Update;

        }



        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "Detain ID", @"SELECT * FROM vDetainedLicensesSummary  WHERE DetainID = @DetainID"},

            { "Release App ID", @"SELECT * FROM vDetainedLicensesSummary  WHERE ReleaseApplicationID = @ReleaseApplicationID"},

            { "National No", @"SELECT * FROM vDetainedLicensesSummary  WHERE NationalNo = @NationalNo" },

            { "Full Name", @"SELECT * FROM vDetainedLicensesSummary  WHERE FullName LIKE '%' + @FullName + '%'" },

            { "Status", @"SELECT * FROM vDetainedLicensesSummary  WHERE IsReleased = @IsReleased  ORDER BY DetainDate DESC"},

            { "None", @"SELECT * FROM vDetainedLicensesSummary  ORDER BY DetainDate DESC"}
        };

        public static DataTable filter(string query, object filterValue)
        {
            return clsDetainLicenseData.filter(query, filterValue);
        }

        public static DataTable GetAllDetainLicenses()
        {
            return clsDetainLicenseData.GetAllDetainLicenses();

        }

        public static clsDetainLicense Find(int license_id)
        {
            int?  released_by_user_id = -1, release_app_id = -1;
            int created_by_user_id = -1, detain_id = -1;
            DateTime detain_date = DateTime.Now;
            DateTime ? release_date = DateTime.Now;
            
            decimal fine_fees = 0;
            bool is_released = false;
            


            if (clsDetainLicenseData.GetDetainLicenseInfoByLicenseID(license_id, ref  released_by_user_id, ref detain_id, ref release_app_id, ref created_by_user_id,
                ref detain_date, ref release_date,  ref fine_fees, ref is_released))
            {
                return new clsDetainLicense(detain_id, license_id, created_by_user_id, released_by_user_id, release_app_id, is_released, release_date, detain_date, fine_fees);
            }


            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewDetainLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                case enMode.Update:
                    return _UpdateDetainLicense();




            }




            return false;
        }

        
        private bool _AddNewDetainLicense()
        {


            this.id = clsDetainLicenseData.AddNewDetainLicense(this.license_id, this.created_by_user_id,  this.released_by_user_id,
                this.release_app_id, this.is_released, this.release_date,this.detain_date,this.fine_fees);

            return (this.id != -1);
        }

        private bool _UpdateDetainLicense()
        {
            return clsDetainLicenseData.UpdateDetainLicense(this.id,this.license_id, this.created_by_user_id, this.released_by_user_id,
                this.release_app_id, this.is_released, this.release_date, this.detain_date, this.fine_fees);
        }


    }
}
