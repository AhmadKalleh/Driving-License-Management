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
    public partial class ApplicationNewLicenseInfo : UserControl
    {
        private int fees = -1;
        public ApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }
        
        public string notes => txtNote.Text;

        public void LoadInitialDataWithApplicationNewLicenseInfo()
        {
            lbAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            fees = Convert.ToInt32(clsApplicationType.Find(Convert.ToInt32(clsApplicationType.enApplicationType.RENEWDRIVINGLICENSE)).fees);
            lbAppFees.Text = fees.ToString();
            lbCreatedBy.Text = SessionData.currentUser.username;
        }

        public void SetOldLicenseIDAndFees(int licenseID)
        {
            int paid_fees = Convert.ToInt32(clsLicense.FindByLicenseID(licenseID).paid_fees);
            lb_OLD_License_ID.Text = licenseID.ToString();
            lbLicenseFees.Text = paid_fees.ToString();
            int total_fees = fees + paid_fees;
            lbTotalFees.Text = Convert.ToInt32(total_fees).ToString();   
        }

        public void LoadDataAfterNewApplication(int renewed_license_id,int renew_application_id,DateTime expiration_date)
        {
            lb_Renweed_LicesnseID.Text = renewed_license_id.ToString(); 
            lb_R_L_ApplicationID.Text = renew_application_id.ToString();
            lbExpirationDate.Text = expiration_date.ToString("yyyy-MM-dd");
        }
        
    }
}
