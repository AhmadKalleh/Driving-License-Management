using DVLD_Project.Application_M;
using DVLD_Project.Application_Type;
using DVLD_Project.Applications.Manage_Applecation;
using DVLD_Project.Manage_Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application
{
    public partial class ApplicationsScreen : Form
    {
        private NavigationManager innerNav;
        private NavigationManager appNav;
        public ApplicationsScreen()
        {
            InitializeComponent();
            innerNav = new NavigationManager(panelScreen);
            appNav = new NavigationManager(panelScreenToApplications);
        }

        public void LoadScreen(Form f) => innerNav.Push(f);
        public void GoBackInner() => innerNav.Pop();

        public void LoadScreenToApplications(Form f) => appNav.Push(f);
        public void GoBackApplications() => appNav.Pop();

        public void HideInnerPanel()
        {
            panelScreen.Visible = false;
        }

        public void RemoveControlsOfTypeFromApplicationsPanel(Type t)
        {
            for (int i = panelScreenToApplications.Controls.Count - 1; i >= 0; i--)
            {
                var c = panelScreenToApplications.Controls[i];
                if (c.GetType() == t || c.GetType().IsSubclassOf(t) || c.GetType().Name == t.Name)
                {
                    panelScreenToApplications.Controls.RemoveAt(i);
                    try { c.Dispose(); } catch { }
                }
            }
            panelScreenToApplications.Invalidate();
            panelScreenToApplications.Refresh();
        }

        public void ShowInnerPanel()
        {
            panelScreen.Visible = true;
        }

        private void ApplicationsTypesScreen_Load(object sender, EventArgs e)
        {
            innerNav.Push(new AllApplicationsScreen(this));
        }
    }
}
