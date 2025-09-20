using DVLD_Busness;
using DVLD_Project.Home;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
           
        }

        
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            txtPasswordLogin.UseSystemPasswordChar = true;
            this.BeginInvoke(new Action(() => txtUsernameLogin.Focus()));
            cbRememberMe.Checked = true;
            string folderPath = @"C:\login";
            string filePath = Path.Combine(folderPath, "remember_me.txt");

            

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);

                string[] parts = fileContent.Split('#');
                if (parts.Length == 2)
                {
                    string username = parts[0];
                    string password = parts[1];


                    txtUsernameLogin.Text = username;
                    txtPasswordLogin.Text = password;
                }
                
            }
            else
            {
                MessageBox.Show("الملف غير موجود.");
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            if (btnEye.Tag.ToString() == "Closed")
            {
                txtPasswordLogin.UseSystemPasswordChar = false;
                btnEye.Image = Resources.eye_close_up;
                btnEye.Tag = "Open";
            }
            else
            {
                txtPasswordLogin.UseSystemPasswordChar = true;
                btnEye.Image = Resources.eye;
                btnEye.Tag = "Closed";
            }
        }

        private void show_message_error(Guna2TextBox box, string message, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(box.Text))
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, message);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(box, "");
            }
        }

        private void txtUsernameLogin_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "username field is requerid", e);
        }

        private void txtPasswordLogin_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "password field is requerid", e);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(clsUser.IsUserExist(txtUsernameLogin.Text,txtPasswordLogin.Text))
            {
                SessionData.currentUser = clsUser.Find(txtUsernameLogin.Text, txtPasswordLogin.Text);

                if(cbRememberMe.Checked)
                {
                    File.WriteAllText(@"C:\login\remember_me.txt", txtUsernameLogin.Text + '#' + txtPasswordLogin.Text);
                }
                else
                {
                    File.WriteAllText(@"C:\login\remember_me.txt", string.Empty);
                }
                MainScreen main = new MainScreen();
                main.FormClosed += (s, args) => System.Windows.Forms.Application.Exit();
                main.Show();

                this.Hide(); 


            }
            else
            {
                MessageBox.Show("Username/password is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
