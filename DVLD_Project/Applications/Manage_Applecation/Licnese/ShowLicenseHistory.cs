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

namespace DVLD_Project.Applications.Manage_Applecation.Licnese
{
    public partial class ShowLicenseHistory : Form
    {

        
        private int _local_driving_license_application_id;
        private int _person_id = -1;

        public ShowLicenseHistory(int local_driving_license_application_id)
        {
            InitializeComponent();
            this._local_driving_license_application_id = local_driving_license_application_id;
        }

        

        private void LoadData()
        {
            clsLocalDrivingLicenseApplication clsLocal = clsLocalDrivingLicenseApplication.Find(_local_driving_license_application_id);
            this._person_id = clsApplication.Find(clsLocal.application_id).person_id;
            int driver_id = clsDriver.Find_By_Person_ID(this._person_id);
            driverLicenses1.LoadDataWithLocalLicensesHistory(driver_id);
        }
        private void ShowLicenseHistory_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
