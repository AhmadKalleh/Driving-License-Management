using DVLD_Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Busness
{
    public class clsLocalDrivingLicenseApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int id {  get; set; }

        public int application_id { get; set; }

        public int license_class_id { get; set; }

        public clsApplication application;

        public clsLicenseClass licenseClass;

        public clsLocalDrivingLicenseApplication()
        {
            Mode = enMode.AddNew;
            this.id = -1;
            this.application_id = -1;
            this.license_class_id = -1;
        }

        public clsLocalDrivingLicenseApplication(int id, int application_id, int license_class_id)
        {
            Mode = enMode.Update;
            this.id = id;
            this.license_class_id = license_class_id;
  
            this.application_id = application_id;
            this.application = clsApplication.Find(this.application_id);        
        }
        
        public static readonly Dictionary<string, string> filters_By = new Dictionary<string, string>
        {
            { "L.D.L.AppID", @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID"},

            { "National No", @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE NationalNo = @NationalNo" },

            { "Full Name", @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE FullName LIKE '%' + @FullName + '%'"},

            { "Status", @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE Status = @Status"},
        
            { "None", @"SELECT * FROM LocalDrivingLicenseApplications_View"}
        };

        public static DataTable filter(string query, object filterValue)
        {
            return clsLocalDrivingLicenseApplicationData.filter(query, filterValue);
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static int IsNewApplicationExistWithSameLicenseClass(int person_id, int license_class_id)
        {
            return clsLocalDrivingLicenseApplicationData.IsNewApplicationExistWithSameLicenseClass(person_id,license_class_id);
        }

        public static clsLocalDrivingLicenseApplication Find(int local_driving_license_application_id)
        {
            int application_id = -1, license_class_id = -1;


            if (clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(local_driving_license_application_id,ref application_id,ref license_class_id))
            {
                return new clsLocalDrivingLicenseApplication(local_driving_license_application_id, application_id, license_class_id);
            }


            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int application_id)
        {
            int local_driving_license_application_id = -1, license_class_id = -1;


            if (clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(application_id, ref local_driving_license_application_id, ref license_class_id))
            {
                return new clsLocalDrivingLicenseApplication(local_driving_license_application_id, application_id, license_class_id);
            }


            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    
                    else
                    {
                        return false;
                    }

                    


                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;

        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {


            this.id = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.application_id, this.license_class_id);
            return (this.id != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.id, this.license_class_id);
        }

    }
}
