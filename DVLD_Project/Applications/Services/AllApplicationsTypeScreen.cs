using DVLD_Project.Application;
using DVLD_Project.Applications.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Manage_Application.Services
{
    public partial class AllApplicationsTypeScreen : Form
    {
        public ApplicationsScreen applications_screen;
        public AllApplicationsTypeScreen(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen; 
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            applications_screen.GoBackInner();
        }

        private void btnRenewDrivingLicnese_Click(object sender, EventArgs e)
        {
            RenewDrivingLicenseScreen renewDrivingLicense = new RenewDrivingLicenseScreen();
            renewDrivingLicense.ShowDialog();
        }

        private void btnReplacementLORD_Click(object sender, EventArgs e)
        {
            ReplacementForDamagedOrLostLicense replacementForDamagedOrLostLicense = new ReplacementForDamagedOrLostLicense();
            replacementForDamagedOrLostLicense.ShowDialog();
        }
    }
}
