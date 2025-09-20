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

namespace DVLD_Project.Controls
{
    public partial class DriverLicenseInfoWithFilter : UserControl
    {
        public event EventHandler LicenseFound;
        int local_driving_license_application_id = -1;

        public event Action<int,int> OnLicenseFound;
        public DriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.FindByLicenseID(Convert.ToInt32(txtSearch.Text));

            if (license == null)
            {
                MessageBox.Show("License not found, please enter a valid License ID.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // نخرج من الدالة وما نكمل باقي الشروط
            }

            int driver_id = license.driver_id;


            LicenseFound?.Invoke(this, EventArgs.Empty);
            OnLicenseFound?.Invoke(Convert.ToInt32(txtSearch.Text), driver_id);

            
            
            
            int application_id = clsLicense.FindByLicenseDriverID(driver_id, license.id).application_id;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id);

            if (localDrivingLicenseApplication == null)
            {
                DataTable dt = clsLicense.GetAllLocalLicensesByDriverID(driver_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1]; // آخر صف
                    application_id = Convert.ToInt32(lastRow["ApplicationID"]);
                    local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
                }
            }
            else
            {
                 local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
            }

            


            driverLicenseInfo1.LoadDriverLicenseInfo(local_driving_license_application_id);

            

        }

        public void DisabledFilter()
        {
            panel.Enabled = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }
    }
}
