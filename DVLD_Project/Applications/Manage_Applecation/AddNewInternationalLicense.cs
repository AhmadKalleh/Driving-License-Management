using DVLD_Busness;
using DVLD_Project.Applications.Manage_Applecation.Licnese;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation
{
    public partial class AddNewInternationalLicense : Form
    {
        public static bool isMatch = true;
        public clsInternationalLicense _old_international_license;
        public clsInternationalLicense _new_international_licenses;
        private clsApplication _new_application;
        private int _license_id = -1;
        private int _driver_id = - 1;


        public AddNewInternationalLicense()
        {
            InitializeComponent();

            driverLicenseInfoWithFilter1.LicenseFound += UcSearchLicense1_LicenseFound;
            driverLicenseInfoWithFilter1.OnLicenseFound += DriverLicenseInfoWithFilter1_OnLicenseFound;
        }

        private void DriverLicenseInfoWithFilter1_OnLicenseFound(int license_id, int driver_id)
        {
            if (clsInternationalLicense.IsInternationalExistsForDriver(driver_id, license_id) ||
            clsInternationalLicense.GetAllInternationalLicensesByDriverID(driver_id).Rows.Count > 0)
            {
                btnIssue.Enabled = false;
                LLLicenseInfo.Enabled = false;
                llLicenseHistory.Enabled = false;
                MessageBox.Show("This driver already has an International License.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsLicense.FindByLicenseID(license_id).expiration_date < DateTime.Now)
            {
                btnIssue.Enabled = false;
                LLLicenseInfo.Enabled = false;
                llLicenseHistory.Enabled = false;
                MessageBox.Show("This License exceeds Expiration Date ,please renew this license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this._license_id = license_id;
            this._driver_id = driver_id;
            applicationInfo2.SetLocalLicenseIDWithValue(license_id);
        }
        private void UcSearchLicense1_LicenseFound(object sender, EventArgs e)
        {
            // تفعيل زر وإظهار بيانات
            btnIssue.Enabled = true;
            llLicenseHistory.Enabled = true;
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_international_license, _new_international_licenses);
            this.Close();
        }

        private void createNewApplication()
        {
            clsLicense license = clsLicense.FindByLicenseID(_license_id);
            clsApplication orginal_application = clsApplication.Find(license.application_id);

            _new_application.person_id = orginal_application.person_id;
            _new_application.application_date = DateTime.Now;
            _new_application.last_status_date = DateTime.Now;
            _new_application.application_type_id =Convert.ToInt32(clsApplicationType.enApplicationType.NEWINTERNATIONALLICENSE);
            _new_application.application_status = 3;
            _new_application.paid_fees = clsApplicationType.Find(_new_application.application_type_id).fees;
            _new_application.created_by_user_id = SessionData.currentUser.id;

            _new_application.Save();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to issue the license ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                createNewApplication();
                clsLicense license = clsLicense.FindByLicenseID(this._license_id);
                _old_international_license.application_id = _new_application.id;
                _old_international_license.driver_id = license.driver_id;
                _old_international_license.issued_using_local_license_id = license.id;
                _old_international_license.issue_date = DateTime.Now;
                _old_international_license.expiration_date = DateTime.Now.AddYears(1);
                _old_international_license.is_active = true;
                _old_international_license.created_by_user_id = SessionData.currentUser.id;


                if (_old_international_license.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isMatch = Match.AreObjectsEqual(_old_international_license, _new_international_licenses);

                LLLicenseInfo.Enabled = true;
                btnIssue.Enabled = false;
                driverLicenseInfoWithFilter1.DisabledFilter();
                applicationInfo2.LoadApplicationDataWithIntLicenseID(_new_application.id, _old_international_license.id);
                
            }
        }

        private void AddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            _old_international_license = new clsInternationalLicense();
            _new_international_licenses = new clsInternationalLicense();
            _new_application = new clsApplication();
            applicationInfo2.LoadInitialDataWithApplicationInfo();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            int application_id = clsLicense.FindByLicenseDriverID(this._driver_id, this._license_id).application_id;
            int local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;

            ShowLicenseHistory licenseHistory = new ShowLicenseHistory(local_driving_license_application_id);
            licenseHistory.ShowDialog();
        }

        private void LLLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            DriverInternationalLicense driverLicense = new DriverInternationalLicense(_old_international_license.id);
            driverLicense.ShowDialog();
        }
    }
}
