using DVLD_Project.Application;
using DVLD_Project.Applications.Manage_Applecation;
using DVLD_Project.Dashboard;
using DVLD_Project.Home;
using DVLD_Project.Person;
using DVLD_Project.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUScreen = DVLD_Project.User.CUScreen;

namespace DVLD_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new LoginScreen());

        }
    }
}
