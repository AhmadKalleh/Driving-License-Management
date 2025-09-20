using DVLD_Busness;
using DVLD_Project.Applications.Manage_Applecation;
using DVLD_Project.Applications.Manage_Applecation.Licnese;
using DVLD_Project.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Services
{
    public partial class RenewDrivingLicenseScreen : Form
    {

        private int _old_license_id = -1;
        private int _driver_id = -1;
        private clsLicense _new_license;
        private clsLicense _old_license;
        private clsApplication _new_application;
        public RenewDrivingLicenseScreen()
        {
            InitializeComponent();
            driverLicenseInfoWithFilter1.LicenseFound += UcSearchLicense1_LicenseFound;
            driverLicenseInfoWithFilter1.OnLicenseFound += DriverLicenseInfoWithFilter1_OnLicenseFound;
        }

        private void DriverLicenseInfoWithFilter1_OnLicenseFound(int license_id, int driver_id)
        {
            clsLicense license = clsLicense.FindByLicenseID(license_id);

            if (!license.is_active)
            {
                MessageBox.Show("This License doesn't active,please choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (license.expiration_date > DateTime.Now)
            {
                btnRenew.Enabled = false;
                llLicenseHistory.Enabled = false;
                LLLicenseInfo.Enabled = false;
                MessageBox.Show("Selected License is not expiared yet,it will expire on :" + license.expiration_date.ToString("yyyy-MM-dd"), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this._old_license_id = license_id;
            _old_license = clsLicense.FindByLicenseID(_old_license_id);
            this._driver_id = driver_id;
            applicationNewLicenseInfo1.SetOldLicenseIDAndFees(license_id);
        }
        private void UcSearchLicense1_LicenseFound(object sender, EventArgs e)
        {
            // تفعيل زر وإظهار بيانات
            btnRenew.Enabled = true;
            llLicenseHistory.Enabled = true;

        }

        private void RenewDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            _new_license = new clsLicense();
            _old_license = new clsLicense();
            _new_application = new clsApplication();
            applicationNewLicenseInfo1.LoadInitialDataWithApplicationNewLicenseInfo();

        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int application_id = clsLicense.FindByLicenseDriverID(this._driver_id, this._old_license_id).application_id;
            int local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;

            ShowLicenseHistory licenseHistory = new ShowLicenseHistory(local_driving_license_application_id);
            licenseHistory.ShowDialog();
        }

        private void LLLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicense driverLicense = new DriverLicense(_new_license.id);
            driverLicense.ShowDialog();
        }

        private void createNewApplication()
        {
            
            clsApplication orginal_application = clsApplication.Find(_old_license.application_id);

            _new_application.person_id = orginal_application.person_id;
            _new_application.application_date = DateTime.Now;
            _new_application.last_status_date = DateTime.Now;
            _new_application.application_type_id = Convert.ToInt32(clsApplicationType.enApplicationType.RENEWDRIVINGLICENSE);
            _new_application.application_status = 3;
            _new_application.paid_fees = clsApplicationType.Find(_new_application.application_type_id).fees;
            _new_application.created_by_user_id = SessionData.currentUser.id;

            _new_application.Save();
        }

        private bool IsOldLicesneExpiared()
        {
            return (_old_license.expiration_date < DateTime.Now);
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(IsOldLicesneExpiared())
            {
                if (MessageBox.Show("Are you sure you want to renew the license ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    createNewApplication();

                    _new_license.application_id = _new_application.id;
                    _new_license.driver_id = _driver_id;
                    _new_license.license_class_id = _old_license.license_class_id;
                    _new_license.issue_date = DateTime.Now;
                    _new_license.expiration_date = DateTime.Now.AddYears(clsLicenseClass.Find(_old_license.license_class_id).default_validity_length);
                    _new_license.notes = applicationNewLicenseInfo1.notes;
                    _new_license.paid_fees = clsLicenseClass.Find(_new_license.license_class_id).class_fees;
                    _new_license.is_active = true;
                    _new_license.issue_reason = Convert.ToByte(clsLicense.enIssueReason.RENEW);
                    _new_license.created_by_user_id = SessionData.currentUser.id;

                    
                    _old_license.UpdateStatus(false);

                    if (_new_license.Save())
                    {
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    LLLicenseInfo.Enabled = true;
                    btnRenew.Enabled = false;
                    driverLicenseInfoWithFilter1.DisabledFilter();
                    applicationNewLicenseInfo1.LoadDataAfterNewApplication(_new_license.id, _new_application.id, _new_license.expiration_date);

                }
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
