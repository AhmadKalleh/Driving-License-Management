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
    public partial class ApplicationInfo : UserControl
    {
        public ApplicationInfo()
        {
            InitializeComponent();
            
        }


        public void LoadInitialDataWithApplicationInfo()
        {
            lbAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            int fees = Convert.ToInt32(clsApplicationType.Find(Convert.ToInt32(clsApplicationType.enApplicationType.NEWINTERNATIONALLICENSE)).fees);
            lbFees.Text = fees.ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            lbCreatedBy.Text = SessionData.currentUser.username;
        }

        public void LoadApplicationDataWithIntLicenseID(int application_id,int int_license_id)
        {
            lb_I_L_ApplicationID.Text = application_id.ToString();
            lb_I_L_LicesnseID.Text = int_license_id.ToString();
        }
        public void SetLocalLicenseIDWithValue(int licenseID)
        {
            lb_Local_License_ID.Text = licenseID.ToString();
        }
    }
}
