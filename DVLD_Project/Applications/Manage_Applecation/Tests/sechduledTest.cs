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
    public partial class sechduledTest : Form
    {
        private Image _test_type_image;
        private int _appointment_id = -1;
        public static bool isMatch = true;
        private int _fail_count;
        private clsTest _old_test;
        private clsTest _new_test;
        private clsAppointment _appointment;
        public sechduledTest(Image test_type_image, int appointment_id, int fail_count)
        {
            InitializeComponent();
            _test_type_image = test_type_image;
            _appointment_id = appointment_id;
            _fail_count = fail_count;
        }

        private void LoadData()
        {
            _new_test = new clsTest();
            _old_test = new clsTest();
            PbTestTypeImage.BackgroundImage = _test_type_image;
            _appointment = clsAppointment.Find(this._appointment_id);
            lbD_L_App_ID.Text = _appointment.local_driving_license_applecation_id.ToString();
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_appointment.local_driving_license_applecation_id);
            clsApplication application = clsApplication.Find(localDrivingLicenseApplication.application_id);
            lbFullName.Text = clsPerson.Find(application.person_id).FullName();
            lbLicenseClass.Text = clsLicenseClass.Find(localDrivingLicenseApplication.license_class_id).name;
            lbCount.Text = _fail_count.ToString();
            lbDate.Text = _appointment.appointment_date.ToString("yyyy-MM-dd");
            lbFees.Text = Convert.ToInt32(_appointment.paid_fees).ToString();

        }
        private void sechduledTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save? After that you cann't change the Pass/Fail results after you save?.","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                _new_test.test_appointment_id = _appointment.id;
                _new_test.created_by_user_id = SessionData.currentUser.id;
                _new_test.test_result = Convert.ToBoolean((rbPass.Checked == true) ? 1 : 0);

                if (txtNote.Text != string.Empty)
                    _new_test.notes = txtNote.Text;

                _appointment.is_locked = true;

                isMatch = Match.AreObjectsEqual(_old_test, _new_test);

                if (_appointment.Save() && _new_test.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
