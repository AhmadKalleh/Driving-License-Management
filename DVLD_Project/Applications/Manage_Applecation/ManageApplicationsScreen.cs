using DVLD_Project.Application;
using DVLD_Project.Applications.Manage_Applecation;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Manage_Application.Services
{
    public partial class ManageApplicationsScreen : Form
    {

        public ApplicationsScreen applications_screen;

        
        public ManageApplicationsScreen(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            applications_screen.GoBackInner();
        }

        private void btnLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            var local = new LocalDrivingLicenseApplications(applications_screen); // مرّر مرجع ApplicationsScreen
            applications_screen.HideInnerPanel();   
            applications_screen.LoadScreenToApplications(local);
        }

        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            var International = new InternationalLicenseApplications(applications_screen);
            applications_screen.HideInnerPanel();
            applications_screen.LoadScreenToApplications(International);
        }
    }
}
