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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Project.User
{
    public partial class LoginInfo : Form
    {



        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int user_id;

        public LoginInfo(int user_id,int mode)
        {
            InitializeComponent();

            this.user_id = user_id;
            if (mode == 0)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;
        public bool is_Active => cbIsActive.Checked;


        public void editUserIDLabel(int user_id)
        {
            lbUserID.Text = user_id.ToString();
        }

        
        private void change_eye_state(Guna2TextBox box, Guna2CircleButton button)
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

        private void btnEyeForPassword_Click(object sender, EventArgs e)
        {
            change_eye_state(txtPassword,(Guna2CircleButton)sender);
        }

        private void btnEyeForConfirmPassword_Click(object sender, EventArgs e)
        {
            change_eye_state(txtConfirmPassword, (Guna2CircleButton)sender);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {

                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "You must Confirm Password to match Original Password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void LoginInfo_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                clsUser user = clsUser.Find(this.user_id);
                if (user != null)
                {
                    lbUserID.Text = user.id.ToString();
                    txtUsername.Text = user.username;
                    txtPassword.Text = user.password;
                    txtConfirmPassword.Text = user.password;
                    cbIsActive.Checked = user.is_active;
                }
                else
                {
                    MessageBox.Show("User Not found","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username field is requried");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }
    }
}
