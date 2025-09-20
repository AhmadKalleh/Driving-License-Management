using DVLD_Busness;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation.Tests
{
    public partial class AddNewAppointmentForTest : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private string _test_type;
        private Image _test_type_image;
        private int _local_driving_license_application_id;
        private int _fail_count;
        private clsAppointment _old_appointment;
        private clsAppointment _new_appointment;
        private int _appointment_id = -1;

        private decimal test_fees = 0;

        public static bool isMatch = true;

        public AddNewAppointmentForTest(
            int appointment_id,
            int local_driving_license_application_id,
            int fail_count,
            string test_type,
            Image test_type_image)
        {
            InitializeComponent();

            _test_type = test_type;
            _test_type_image = test_type_image;
            _local_driving_license_application_id = local_driving_license_application_id;
            _fail_count = fail_count;
            _appointment_id = appointment_id;

            _Mode = (_appointment_id == -1) ? enMode.AddNew : enMode.Update;
        }

        private void AddNewAppointmentForTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_appointment, _new_appointment);
            this.Close();
        }

        #region Loading Data

        private void LoadData()
        {
            SetupDatePicker();
            LoadBasicInfo();
            LoadAppointmentData();
            CalculateAndDisplayFees();

            isMatch = true;
        }

        private void SetupDatePicker()
        {
            dtpDate.MinDate = DateTime.Now;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpDate.ShowUpDown = true;
        }

        private void LoadBasicInfo()
        {
            PbTestTypeImage.BackgroundImage = _test_type_image;
            lbTest.Text = _test_type;
            lbD_L_App_ID.Text = _local_driving_license_application_id.ToString();

            var localApp = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            var app = clsApplication.Find(localApp.application_id);
            var person = clsPerson.Find(app.person_id);

            lbFullName.Text = person.FullName();
            lbLicenseClass.Text = clsLicenseClass.Find(localApp.license_class_id).name;
            lbCount.Text = _fail_count.ToString();
        }

        private void LoadAppointmentData()
        {
            if (_Mode == enMode.AddNew)
            {
                _old_appointment = new clsAppointment();
                _new_appointment = new clsAppointment();

                test_fees = clsTestType.Find(clsTestType.Test_Type_With_ID[_test_type]).fees;
            }
            else
            {
                _old_appointment = clsAppointment.Find(_appointment_id);
                _new_appointment = clsAppointment.Find(_appointment_id);

                dtpDate.MinDate = _old_appointment.appointment_date;
                test_fees = _old_appointment.paid_fees;

                if (_fail_count > 0 && _old_appointment.retake_test_application_id != -1)
                {
                    lbR_Test_App_ID.Text = _old_appointment.retake_test_application_id.ToString();
                }
            }

            lbFees.Text = test_fees.ToString("0.##");
        }

        private void CalculateAndDisplayFees()
        {
            decimal retakeFees = 0;

            if (_fail_count == 0)
            {
                pRetakeTestInfo.Enabled = false;
            }
            else
            {
                pRetakeTestInfo.Enabled = true;
                retakeFees = clsApplicationType
                    .Find((int)clsApplicationType.enApplicationType.RETAKETEST)
                    .fees;

                lbR_App_Fees.Text = retakeFees.ToString("0.##");
            }

            lbTotal_Fees.Text = (test_fees + retakeFees).ToString("0.##");
        }

        #endregion

        #region Saving

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplication retakeApplication = new clsApplication();

            if (_fail_count > 0 && _old_appointment.retake_test_application_id == -1)
            {
                CreateRetakeApplication(retakeApplication);
            }

            PrepareAppointment(retakeApplication);

            isMatch = Match.AreObjectsEqual(_old_appointment, _new_appointment);

            if (_old_appointment.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnSave.Enabled = false;
        }

        private bool CreateRetakeApplication(clsApplication new_application)
        {
            var localApp = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            var originalApp = clsApplication.Find(localApp.application_id);

            new_application.person_id = originalApp.person_id;
            new_application.application_date = DateTime.Now;
            new_application.last_status_date = DateTime.Now;
            new_application.application_status = originalApp.application_status;
            new_application.application_type_id = (int)clsApplicationType.enApplicationType.RETAKETEST;
            new_application.paid_fees = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RETAKETEST).fees;
            new_application.created_by_user_id = SessionData.currentUser.id;

            return new_application.Save();

            
        }

        private void PrepareAppointment(clsApplication retakeApplication)
        {
            _old_appointment.test_type_id = clsTestType.Test_Type_With_ID[_test_type];
            _old_appointment.local_driving_license_applecation_id = _local_driving_license_application_id;
            _old_appointment.appointment_date = dtpDate.Value;
            _old_appointment.paid_fees = test_fees;
            _old_appointment.created_by_user_id = SessionData.currentUser.id;
            _old_appointment.is_locked = false;

            if (retakeApplication.id != -1)
            {
                _old_appointment.retake_test_application_id = retakeApplication.id;
            }


        }

        #endregion
    }
}
