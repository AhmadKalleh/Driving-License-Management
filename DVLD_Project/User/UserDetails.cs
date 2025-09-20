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
    public partial class UserDetails : Form
    {

        private int person_id;
        private int user_id;
        public UserDetails(int person_id, int user_id)
        {
            InitializeComponent();
            this.person_id = person_id;
            this.user_id = user_id;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonalInfo(this.person_id);
            userInfo1.LoadUserInfo(this.user_id);
        }
    }
}
