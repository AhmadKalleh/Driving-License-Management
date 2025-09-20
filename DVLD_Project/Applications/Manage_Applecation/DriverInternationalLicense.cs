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
    public partial class DriverInternationalLicense : Form
    {
        private int _int_license_id = -1;
        public DriverInternationalLicense(int int_license)
        {
            InitializeComponent();
            _int_license_id = int_license;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void DriverInternationalLicense_Load(object sender, EventArgs e)
        {
            driverInternationalLicenseInfo1.LoadDriverInternationalLicenseInfo(this._int_license_id);
        }
    }
}
