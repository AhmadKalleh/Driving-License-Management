using DVLD_Busness;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ApplicationInfo : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _local_application_id;


        public ApplicationInfo(int local_application_id, int mode)
        {
            InitializeComponent();

            this._local_application_id = local_application_id;
            if (mode == 0)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        public int license_class_id => Convert.ToInt32(cbHelper.SelectedValue);

        public int paid_fees => Convert.ToInt32(lbApplicationFees.Text);

        public void editLocalDrivingLicenseApplecationIDLabel(int local_driving_license_application_id)
        {
            lbL_D_L_ApplicationID.Text = local_driving_license_application_id.ToString();
        }
        private void prepareData()
        {
            lbApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            lbCreatedBy.Text = SessionData.currentUser.username;

            var appType = clsApplicationType.Find((int)clsApplicationType.enApplicationType.NEWLOCALLICENSE);

            if (appType != null)
            {
                lbApplicationFees.Text = (Convert.ToInt32(appType.fees)).ToString();
            }


           


        }
        private void ApplicationInfo_Load(object sender, EventArgs e)
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            cbHelper.DisplayMember = "ClassName";        // الاسم الظاهر في الكومبو
            cbHelper.ValueMember = "LicenseClassID";     // القيمة الداخلية
            cbHelper.DataSource = dt;
            cbHelper.SelectedIndex = 0;


            if (_Mode == enMode.Update)
            {
                clsLocalDrivingLicenseApplication local_driving_license = clsLocalDrivingLicenseApplication.Find(this._local_application_id);
                clsApplication application = clsApplication.Find(local_driving_license.application_id);
                if (local_driving_license != null)
                {
                    lbL_D_L_ApplicationID.Text = local_driving_license.id.ToString();
                    lbApplicationDate.Text = application.application_date.ToString("yyyy-MM-dd");
                    cbHelper.SelectedIndex = local_driving_license.license_class_id - 1;
                    lbApplicationFees.Text = (Convert.ToInt32(application.paid_fees)).ToString();
                    lbCreatedBy.Text = SessionData.currentUser.username;
                }
            }
            else
            {
                prepareData();
            }
        }
    }
}
