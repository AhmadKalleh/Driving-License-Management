using DVLD_Busness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Dashboard
{
    public partial class DashboardScreen : Form
    {
        public DashboardScreen()
        {
            InitializeComponent();
        }

        DateTime dateTime = DateTime.Now;

        private void DashboardScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbTime.Text = DateTime.Now.ToString("dddd, MMMM d,yyyy");
            lbPeopleCount.Text = clsPerson.GetPeopleCount().ToString();
            lbUsersCount.Text = clsUser.GetUserCount().ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTime = dateTime.AddSeconds(1);
            lbTimeNow.Text = dateTime.ToString("h:m:ss", CultureInfo.InvariantCulture);
        }
    }
}
