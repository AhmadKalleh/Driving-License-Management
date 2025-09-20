using DVLD_Project.Application;
using DVLD_Project.Dashboard;
using DVLD_Project.Drivers;
using DVLD_Project.Person;
using DVLD_Project.Properties;
using DVLD_Project.User;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Home
{
    public partial class MainScreen : Form
    {

        Dictionary<string, Image[]> myDict;
        public MainScreen()
        {
            myDict = new Dictionary<string, Image[]>
            {
                { "Dashboard", new Image[] { Resources.dashboard__1_, Resources.dashboard } },

                { "Applications", new Image[] { Resources.website__1_, Resources.website } },

                { "People", new Image[] { Resources.crowd_of_users__1_, Resources.crowd_of_users } },

                { "Drivers", new Image[] { Resources.profile__1_, Resources.profile } },

                { "Users", new Image[] { Resources.administrator__1_, Resources.administrator } },

                { "Settings", new Image[] { Resources.account_settings__1_, Resources.account_settings } },

                { "Log out", new Image[] { Resources.logout__1_, Resources.logout } }
            };

            InitializeComponent();
        }


        public void LoadScreen(object sender)
        {
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            Form form = sender as Form;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            PanelScreen.Controls.Add(form);
            form.Show();
        }

        private void HighlightActiveButton(object clickedButton)
        {
            foreach (Control control in panelSidebar.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2GradientButton btn)
                {
                    if (btn == clickedButton)
                    {
                        
                        btn.FillColor = Color.FromArgb(142, 7, 224);
                        btn.FillColor2 = Color.FromArgb(224, 7, 215);
                        btn.ForeColor = Color.White;
                        btn.Image = myDict[btn.Text.ToString()][0];
                    }
                    else
                    {
                        
                        btn.FillColor = panelSidebar.BackColor;
                        btn.FillColor2 = panelSidebar.BackColor;
                        btn.ForeColor = Color.DarkGray;
                        btn.Image = myDict[btn.Text.ToString()][1];
                    }
                }
            }
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new DashboardScreen());
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new ApplicationsScreen());

           
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new PeopleScreen());
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new DriversScreen());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new UsersScreen());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            LoadScreen(new AccountSettingsScreen());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(sender);
            
            LoginScreen screen = new LoginScreen();
            screen.FormClosed += (s, args) => System.Windows.Forms.Application.Exit();
            screen.Show();

            this.Hide();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            LoadScreen(new DashboardScreen());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelScreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
