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
    public partial class AccountSettingsScreen : Form
    {
        public AccountSettingsScreen()
        {
            InitializeComponent();
        }

        private void AccountSettingsScreen_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonalInfo(SessionData.currentUser.person_id);
            userInfo1.LoadUserInfo(SessionData.currentUser.id);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordScreen screen = new ChangePasswordScreen();
            screen.ShowDialog();
        }
    }
}
