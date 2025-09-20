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

namespace DVLD_Project
{
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int user_id)
        {
            clsUser user = clsUser.Find(user_id);

            if (user == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            lbUserID.Text = user.id.ToString();
            lbUsername.Text = user.username.ToString();
            lbActive.Text = (user.is_active == true) ? "Yes" : "No";
        }
    }
}
