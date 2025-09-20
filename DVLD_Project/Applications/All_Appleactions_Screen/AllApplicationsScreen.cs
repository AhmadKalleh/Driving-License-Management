using DVLD_Project.Application;
using DVLD_Project.Application_M;
using DVLD_Project.Application_Type;
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
    public partial class AllApplicationsScreen : Form
    {

        public ApplicationsScreen applications_screen;
        
        public AllApplicationsScreen(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen;
        }

        

        

        private void btnManageApplications_Click(object sender, EventArgs e)
        {
            applications_screen.LoadScreen(new ManageApplicationsScreen(applications_screen));
        }

        private void btnDrivingLicense_Click(object sender, EventArgs e)
        {
            applications_screen.LoadScreen(new AllApplicationsTypeScreen(applications_screen));
            
        }

        private void btnManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            ManageApplicationsTypesScreen screen = new ManageApplicationsTypesScreen();
            screen.ShowDialog();
        }

        private void btnManageTestsTypes_Click(object sender, EventArgs e)
        {
            ManageTestsTypesScreen screen = new ManageTestsTypesScreen();
            screen.ShowDialog();
        }

        private void btnDetainLicences_Click(object sender, EventArgs e)
        {
            applications_screen.HideInnerPanel();
            applications_screen.LoadScreenToApplications(new AllDetainedLicsensesScreen(applications_screen));
        }
    }
}
