using DVLD_Busness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation.Tests
{
    public partial class IssueDrivingLicenseForTheFirstTime : Form
    {
        private int _local_driving_license_application_id;
        private int _passed_tests;
        private clsLicense _new_license;
        private clsLicense _old_license;
        private clsDriver _driver;
        private int _driver_id;
        public static bool isMatch = true;
        public IssueDrivingLicenseForTheFirstTime(int local_driving_license_application_id, int passed_tests)
        {
            InitializeComponent();
            _local_driving_license_application_id = local_driving_license_application_id;
            _passed_tests = passed_tests;
        }

        private void IssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            localDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(this._local_driving_license_application_id, this._passed_tests);
            _new_license = new clsLicense();
            _old_license = new clsLicense();
            _driver = new clsDriver();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_license, _new_license);
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication clsLocal = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            clsLocal.application = clsApplication.Find(clsLocal.application_id);


            if(!clsDriver.IsDriverExist(clsLocal.application.person_id))
            {       
                _driver.person_id = clsLocal.application.person_id;
                _driver.created_by_user_id = SessionData.currentUser.id;
                _driver.created_date = DateTime.Now;
                _driver.Save();
                _driver_id = _driver.id;
            }
            else
            {
                _driver_id = clsDriver.Find_By_Person_ID(clsLocal.application.person_id);
            }


            _old_license.application_id = clsLocal.application_id;
            _old_license.driver_id = _driver_id;
            _old_license.license_class_id = clsLocal.license_class_id;
            _old_license.issue_date = DateTime.Now;
            _old_license.expiration_date = DateTime.Now.AddYears(clsLicenseClass.Find(clsLocal.license_class_id).default_validity_length);
            _old_license.notes = txtNote.Text;
            _old_license.paid_fees = clsLicenseClass.Find(_old_license.license_class_id).class_fees;
            _old_license.is_active = true;
            _old_license.issue_reason = Convert.ToByte(clsLicense.enIssueReason.FIRST_TIME);
            _old_license.created_by_user_id = SessionData.currentUser.id;

            if(_old_license.Save())
            {
                clsApplication.UpdateApplicationsStatusByLocalDrivingLicense(_local_driving_license_application_id);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            isMatch = Match.AreObjectsEqual(_old_license, _new_license);
            btnIssue.Enabled = false;
        }
    }
}
