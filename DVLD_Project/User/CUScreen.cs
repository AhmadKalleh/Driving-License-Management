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

namespace DVLD_Project.User
{
    public partial class CUScreen : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public static bool isMatch = true;
        private int _user_id;
        private int _person_id = -1;
        private clsUser _new_user;
        private clsUser _old_user;
        private PersonInfoWithFilter _personInfoControl;
        private LoginInfo _loginInfoForm;
        public CUScreen(int user_id)
        {

            InitializeComponent();

            _user_id = user_id;

            if (_user_id == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_user, _new_user);
            this.Close();
        }

        private void LoadScreenWithPersonalInfo()
        {
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if(_personInfoControl != null)
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


            _personInfoControl = new PersonInfoWithFilter(this._person_id,mode);
            _personInfoControl.OnPersonSelected += PersonSelectedHandler;
            _personInfoControl.Dock = DockStyle.Fill;
            PanelScreen.Controls.Add(_personInfoControl);
            _personInfoControl.Show();
        }

        private void LoadScreenWithLoginInfo()
        {
            panel.Visible = false;
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if (_loginInfoForm != null)
            {
                 PanelScreen.Controls.Add(_loginInfoForm);
                _loginInfoForm.Show();
                
                
                return ;
            }

            int mode = -1;

            if (_Mode == enMode.AddNew)
                mode = 0;
            else
                mode = 1;

            _loginInfoForm = new LoginInfo(this._user_id,mode);
            _loginInfoForm.Dock = DockStyle.Fill;
            _loginInfoForm.TopLevel = false;
            PanelScreen.Controls.Add(_loginInfoForm);
            _loginInfoForm.Show();
        }

        private void PersonSelectedHandler(int personId)
        {
            this._person_id = personId;
            
        }

        private void LoadData()
        {
            

            if (_Mode == enMode.AddNew)
            {
                lbProccess.Text = "Add New User";
                _new_user = new clsUser();
                _old_user = new clsUser();
                isMatch = true;
                LoadScreenWithPersonalInfo();
                return;
            }


            lbProccess.Text = "Update User";
            _new_user = clsUser.Find(_user_id);
            _old_user = clsUser.Find(_user_id);


            if (_new_user == null)
            {
                MessageBox.Show("This form will be closed because No User with ID = " + _user_id);
                this.Close();

                return;
            }

            this._person_id = _new_user.person_id;
            btnNext.Enabled = false;
            btnSave.Enabled = true;
            LoadScreenWithPersonalInfo();


        }
        private void CUScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {

            panel.Visible = true;
            LoadScreenWithPersonalInfo();
        }

        private void btnLoginInfo_Click(object sender, EventArgs e)
        {
            LoadScreenWithLoginInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if(this._person_id != -1)
            {
                if (clsUser.IsUserExist(this._person_id))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnLoginInfo.Checked = true;
                    LoadScreenWithLoginInfo();
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Selected Person does not exists, choose another one. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _new_user.username = _loginInfoForm.Username;
            _new_user.password = _loginInfoForm.Password;
            _new_user.is_active = _loginInfoForm.is_Active;
            _new_user.person_id = this._person_id;

            if (_new_user.Save())
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("Usename already exists, choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isMatch = Match.AreObjectsEqual(_old_user, _new_user);

            _Mode = enMode.Update;
            lbProccess.Text = "Update User";
            _loginInfoForm.editUserIDLabel(_new_user.id);
        }
    }
}
