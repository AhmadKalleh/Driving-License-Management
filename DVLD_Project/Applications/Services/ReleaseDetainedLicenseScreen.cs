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

namespace DVLD_Project.Applications.Services
{
    public partial class ReleaseDetainedLicenseScreen : Form
    {
        private int _orginal_license_id = -1;
        private int _driver_id = -1;

        private clsLicense _orginal_license;
        private clsApplication _new_application;
        private clsDetainLicense _old_detain_license;
        private clsDetainLicense _new_detain_license;

        public static bool isMatch = true;
        public ReleaseDetainedLicenseScreen()
        {
            InitializeComponent();
            driverLicenseInfoWithFilter1.OnLicenseFound += DriverLicenseInfoWithFilter1_OnLicenseFound;
            driverLicenseInfoWithFilter1.LicenseFound += UcSearchLicense1_LicenseFound;
        }

        private void DriverLicenseInfoWithFilter1_OnLicenseFound(int license_id, int driver_id)
        {
            // احفظ المعطيات واطلب تفاصيل الرخصة القديمة
            _orginal_license_id = license_id;
            _driver_id = driver_id;

            _orginal_license = clsLicense.FindByLicenseID(_orginal_license_id);
            _old_detain_license = clsDetainLicense.Find(_orginal_license.id);
            string status = clsLicense.IsDetainedLicense(_orginal_license.id);

            if (status == "No_Detained")
            {
                MessageBox.Show("Selected License is not detained , choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }
            else if (status == "Detained_Released")
            {
                MessageBox.Show("Selected License is already released , choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }

            


            else if (!_orginal_license.is_active)
            {
                MessageBox.Show("This License doesn't active,please choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                return;
            }


            lb_LicesnseID.Text = _orginal_license.id.ToString();
            lb_Detain_ID.Text = _old_detain_license.id.ToString();
            lbCreatedBy.Text = clsUser.Find(_old_detain_license.created_by_user_id).username;
            lbDetainDate.Text = _old_detain_license.detain_date.ToString("yyyy-MM-dd");
            int release_id = Convert.ToInt32(clsApplicationType.enApplicationType.RELEASEDETAINEDDRIVINGLICENSE);
            int fees = Convert.ToInt32(clsApplicationType.Find(release_id).fees);
            lbApp_Fees.Text = fees.ToString();
            lbFineFees.Text = Convert.ToInt32(_old_detain_license.fine_fees).ToString();
            int total_fees = fees + Convert.ToInt32(_old_detain_license.fine_fees);
            lbTotal_Fees.Text = total_fees.ToString();

        }


        private void UcSearchLicense1_LicenseFound(object sender, EventArgs e)
        {
            btnRelease.Enabled = true;
            

            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createNewApplication()
        {

            clsApplication orginal_application = clsApplication.Find(_orginal_license.application_id);

            _new_application.person_id = orginal_application.person_id;
            _new_application.application_date = DateTime.Now;
            _new_application.last_status_date = DateTime.Now;
            _new_application.application_type_id = Convert.ToInt32(clsApplicationType.enApplicationType.RELEASEDETAINEDDRIVINGLICENSE);
            _new_application.application_status = 3;
            _new_application.paid_fees = clsApplicationType.Find(_new_application.application_type_id).fees;
            _new_application.created_by_user_id = SessionData.currentUser.id;

            _new_application.Save();
        }

        private void ReleaseDetainedLicenseScreen_Load(object sender, EventArgs e)
        {
            _new_application = new clsApplication();
            _orginal_license = new clsLicense();
            _old_detain_license = new clsDetainLicense();
            _new_detain_license = new clsDetainLicense();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release the license ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                createNewApplication();

                _old_detain_license.is_released = true;
                _old_detain_license.released_by_user_id = SessionData.currentUser.id;
                _old_detain_license.release_app_id = _new_application.id;
                _old_detain_license.release_date = DateTime.Now;


                if (_old_detain_license.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                btnRelease.Enabled = false;
                driverLicenseInfoWithFilter1.DisabledFilter();
                lbApp_ID.Text = _new_application.id.ToString();
                isMatch = Match.AreObjectsEqual(_old_detain_license, _new_detain_license);

            }
        }
    }
}
