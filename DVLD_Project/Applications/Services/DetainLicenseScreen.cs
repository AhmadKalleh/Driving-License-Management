using DVLD_Busness;
using DVLD_Project.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Services
{
    public partial class DetainLicenseScreen : Form
    {

        private int _orginal_license_id = -1;
        private int _driver_id = -1;
        
        private clsLicense _orginal_license;
        private clsDetainLicense _old_detain_license;
        private clsDetainLicense _new_detain_license;
        public static bool isMatch = true;
        public DetainLicenseScreen()
        {
            InitializeComponent();
            driverLicenseInfoWithFilter1.OnLicenseFound += DriverLicenseInfoWithFilter1_OnLicenseFound;
            driverLicenseInfoWithFilter1.LicenseFound += UcSearchLicense1_LicenseFound;
        }

        private void DriverLicenseInfoWithFilter1_OnLicenseFound(int license_id, int driver_id)
        {
            // احفظ المعطيات واطلب تفاصيل الرخصة القديمة
            _orginal_license_id = license_id;
            _driver_id = driver_id;

            _orginal_license = clsLicense.FindByLicenseID(_orginal_license_id);
            string status = clsLicense.IsDetainedLicense(_orginal_license.id);
            
            if (status == "Detained_Not_Released")
            {
                MessageBox.Show("Selected License is already detained , choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }
            
            
            else if (!_orginal_license.is_active)
            {
                MessageBox.Show("This License doesn't active,please choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }


            lb_LicesnseID.Text = _orginal_license.id.ToString();

            
        }

        
        private void UcSearchLicense1_LicenseFound(object sender, EventArgs e)
        {
            btnDetain.Enabled = true;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void DetainLicenseScreen_Load(object sender, EventArgs e)
        {
            lbDetainDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbCreatedBy.Text = SessionData.currentUser.username;
            _old_detain_license = new clsDetainLicense();
            _new_detain_license = new clsDetainLicense();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_detain_license, _new_detain_license);

            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain the license ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                _new_detain_license.license_id = _orginal_license.id ;
                _new_detain_license.detain_date = DateTime.Now;
                _new_detain_license.fine_fees = Convert.ToDecimal(txtFees.Text);
                _new_detain_license.created_by_user_id = SessionData.currentUser.id;
                _new_detain_license.is_released = false;
                _new_detain_license.release_date = null;
                _new_detain_license.released_by_user_id = -1;
                _new_detain_license.release_app_id = -1;



                
                if (_new_detain_license.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                
                btnDetain.Enabled = false;
                driverLicenseInfoWithFilter1.DisabledFilter();
                lb_Detain_ID.Text = _new_detain_license.id.ToString();
                isMatch = Match.AreObjectsEqual(_old_detain_license, _new_detain_license);

            }


        }
    }
}
