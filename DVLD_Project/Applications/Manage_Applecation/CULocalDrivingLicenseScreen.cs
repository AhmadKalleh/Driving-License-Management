using DVLD_Busness;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation
{
    public partial class CULocalDrivingLicenseScreen : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public static bool isMatch = true;
        private int _person_id = -1;
        private PersonInfoWithFilter _personInfoControl;
        private clsLocalDrivingLicenseApplication _new_local_driving_license_application;
        private clsLocalDrivingLicenseApplication _old_local_driving_license_application;
        private clsApplication _new_application;
        private int _local_driving_license_application_id;
        private ApplicationInfo _ApplicationInfoForm;
        public CULocalDrivingLicenseScreen(int local_driving_license_application_id)
        {
            InitializeComponent();

            _local_driving_license_application_id = local_driving_license_application_id;

            if (_local_driving_license_application_id == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void LoadData()
        {


            if (_Mode == enMode.AddNew)
            {
                lbProccess.Text = "New Local Driving License Application";
                _new_local_driving_license_application = new clsLocalDrivingLicenseApplication();
                _old_local_driving_license_application = new clsLocalDrivingLicenseApplication();
                _new_application = new clsApplication();
                isMatch = true;
                LoadScreenWithPersonalInfo();
                return;
            }


            lbProccess.Text = "Update Local Driving License Application";
            _new_local_driving_license_application = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            _old_local_driving_license_application = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            _new_application = clsApplication.Find(_new_local_driving_license_application.application_id);

            if (_new_local_driving_license_application == null)
            {
                MessageBox.Show("This form will be closed because No Local Driving License Application with ID = " + _local_driving_license_application_id);
                this.Close();

                return;
            }

            this._person_id = _new_local_driving_license_application.application.person_id;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
            LoadScreenWithPersonalInfo();


        }

        private void CULocalDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadScreenWithApplicationInfo()
        {
            panel.Visible = false;
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if (_ApplicationInfoForm != null)
            {
                PanelScreen.Controls.Add(_ApplicationInfoForm);
                _ApplicationInfoForm.Show();


                return;
            }

            int mode = -1;

            if (_Mode == enMode.AddNew)
                mode = 0;
            else
                mode = 1;

            _ApplicationInfoForm = new ApplicationInfo(this._local_driving_license_application_id, mode);
            _ApplicationInfoForm.Dock = DockStyle.Fill;
            _ApplicationInfoForm.TopLevel = false;
            PanelScreen.Controls.Add(_ApplicationInfoForm);
            _ApplicationInfoForm.Show();
        }
        private void PersonSelectedHandler(int personId)
        {
            this._person_id = personId;

        }
        private void LoadScreenWithPersonalInfo()
        {
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if (_personInfoControl != null)
            {
                PanelScreen.Controls.Add(_personInfoControl);
                _personInfoControl.Show();
                return;
            }

            int mode = -1;

            if (_Mode == enMode.AddNew)
                mode = 0;
            else
                mode = 1;


            _personInfoControl = new PersonInfoWithFilter(this._person_id, mode);
            _personInfoControl.OnPersonSelected += PersonSelectedHandler;
            _personInfoControl.Dock = DockStyle.Fill;
            PanelScreen.Controls.Add(_personInfoControl);
            _personInfoControl.Show();
        }
        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            LoadScreenWithPersonalInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_local_driving_license_application, _new_local_driving_license_application);
            this.Close();
        }

        private void btnApplicationInfo_Click(object sender, EventArgs e)
        {
            LoadScreenWithApplicationInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            btnApplicationInfo.Checked = true;
            LoadScreenWithApplicationInfo();
            btnSave.Enabled = true;


            //if (this._person_id != -1)
            //{
            //    if (clsUser.IsUserExist(this._person_id))
            //    {
            //        MessageBox.Show("Selected Person already has a user, choose another one. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        btnApplicationInfo.Checked = true;
            //        LoadScreenWithApplicationInfo();
            //        btnSave.Enabled = true;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Selected Person does not exists, choose another one. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
      
            int  license_class_id = _ApplicationInfoForm.license_class_id;

            

            int app_id = clsLocalDrivingLicenseApplication.IsNewApplicationExistWithSameLicenseClass(this._person_id, license_class_id);

            if (app_id > 0)
            {
                MessageBox.Show("Choose another license Class ,the selected Person Already have an active application for the selected class with id = " + app_id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(_new_application.Mode == clsApplication.enMode.Update)
            {
                _new_local_driving_license_application.application_id = _new_application.id;
                _new_local_driving_license_application.license_class_id = license_class_id;

                if (_new_local_driving_license_application.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                _new_application.person_id = _person_id;
                _new_application.application_type_id = (int)clsApplicationType.enApplicationType.NEWLOCALLICENSE;
                _new_application.application_date = DateTime.Now;
                _new_application.last_status_date = DateTime.Now;
                _new_application.created_by_user_id = SessionData.currentUser.id;
                _new_application.paid_fees = _ApplicationInfoForm.paid_fees;
                _new_application.application_status = (int)clsApplication.enStatus.NEW;

                if (_new_application.Save())
                {
                    _new_local_driving_license_application.application_id = _new_application.id;
                    _new_local_driving_license_application.license_class_id = license_class_id;

                    if (_new_local_driving_license_application.Save())
                    {
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            isMatch = Match.AreObjectsEqual(_old_local_driving_license_application, _new_local_driving_license_application);
            _Mode = enMode.Update;
            lbProccess.Text = "Update Local Driving License Application";

            _ApplicationInfoForm.editLocalDrivingLicenseApplecationIDLabel(_new_local_driving_license_application.id);


        }
    }
}
