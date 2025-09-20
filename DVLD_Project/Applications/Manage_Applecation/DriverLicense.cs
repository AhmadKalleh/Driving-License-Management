using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation
{
    public partial class DriverLicense : Form
    {
        private int local_driving_license_application_id;
        public DriverLicense(int local_driving_license_application_id)
        {
            InitializeComponent();
            this.local_driving_license_application_id = local_driving_license_application_id;
        }

        private void DriverLicense_Load(object sender, EventArgs e)
        {
            driverLicenseInfo1.LoadDriverLicenseInfo(local_driving_license_application_id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
