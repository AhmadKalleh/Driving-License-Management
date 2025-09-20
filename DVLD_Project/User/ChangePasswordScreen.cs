using DVLD_Busness;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
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
    public partial class ChangePasswordScreen : Form
    {
        public ChangePasswordScreen()
        {
            InitializeComponent();
        }


        private void change_eye_state(Guna2TextBox box,Guna2CircleButton button)
        {
            if (button.Tag.ToString() == "Closed")
            {
                box.UseSystemPasswordChar = false;
                button.Image = Resources.eye_close_up;
                button.Tag = "Open";
            }
            else
            {
                box.UseSystemPasswordChar = true;
                button.Image = Resources.eye;
                button.Tag = "Closed";
            }
        }
        

        private void ChangePasswordScreen_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonalInfo(SessionData.currentUser.person_id);
            userInfo1.LoadUserInfo(SessionData.currentUser.id);
        }

        private void btnEyeForCurrent_Click(object sender, EventArgs e)
        {
            change_eye_state(txtCurrentPassword,(Guna2CircleButton)sender);
        }

        private void btnEyeForNew_Click(object sender, EventArgs e)
        {
            change_eye_state(txtNewPassword,(Guna2CircleButton)sender);
        }

        private void btnEyeForConfirm_Click(object sender, EventArgs e)
        {
            change_eye_state(txtConfirmPassword,(Guna2CircleButton)sender);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                txtCurrentPassword.Focus();
                errorProvider1.SetError(txtCurrentPassword, "Current Password field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");

                if(!clsUser.IsUserExist(SessionData.currentUser.username,txtCurrentPassword.Text))
                {
                    e.Cancel = true;
                    txtCurrentPassword.Focus();
                    errorProvider1.SetError(txtCurrentPassword, "Current Password is Wrong");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtCurrentPassword, "");
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
            {
                
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "You must Confirm Password to match New Password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(clsUser.change_password(SessionData.currentUser.id,txtNewPassword.Text))
            {
                MessageBox.Show("Password changed successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
