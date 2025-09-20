using DVLD_Busness;
using DVLD_Project.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Controls
{
    public partial class LocalDrivingLicenseApplicationInfo : UserControl
    {
        
        int person_id;
        public LocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadLocalDrivingLicenseApplicationInfo(int local_driving_license_application_id,int passed_tests)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(local_driving_license_application_id);

            if(localDrivingLicenseApplication != null )
            {
                clsApplication application = clsApplication.Find(localDrivingLicenseApplication.application_id);
                this.person_id = application.person_id;
                if(application != null)
                {
                    lbD_L_App_ID.Text = localDrivingLicenseApplication.id.ToString();
                    lbLicenseClass.Text = clsLicenseClass.Find(localDrivingLicenseApplication.license_class_id).name;
                    lbPassedTests.Text = passed_tests.ToString()+"/3";
                    lBApplicationID.Text = application.id.ToString();
                    lbStatus.Text = "New";
                    lbFees.Text = (Convert.ToInt32(application.paid_fees)).ToString();
                    lbType.Text = clsApplicationType.Find(application.application_type_id).title;
                    lbDate.Text = application.application_date.ToString("yyyy-MM-dd");
                    lbStatusDate.Text = application.last_status_date.ToString("yyyy-MM-dd");
                    lbCreatedBy.Text = clsUser.Find(application.created_by_user_id).username;
                    lbFullName.Text = clsPerson.Find(application.person_id).FullName();
                }
            }
        }

        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetails details = new PersonDetails(person_id);
            details.ShowDialog();
        }

     
    }
}
