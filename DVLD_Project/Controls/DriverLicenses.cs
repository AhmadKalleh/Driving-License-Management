using DVLD_Project.Applications.Manage_Applecation.Licnese;
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
    public partial class DriverLicenses : UserControl
    {
        private int _driver_id;
        public DriverLicenses()
        {
            InitializeComponent();
            
        }

        private LocalLicenseHistory _localLicenseInfo;
        private InternationalLicenseHistory _internationalLicenseInfo;
        private void DriverLicenses_Load(object sender, EventArgs e)
        {

        }

        public void LoadDataWithLocalLicensesHistory(int driver_id)
        {
            this._driver_id = driver_id;
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if (_localLicenseInfo != null)
            {
                PanelScreen.Controls.Add(_localLicenseInfo);
                _localLicenseInfo.Show();
                return;
            }



            _localLicenseInfo = new LocalLicenseHistory(driver_id);
            _localLicenseInfo.TopLevel = false;
            _localLicenseInfo.Dock = DockStyle.Fill;
            PanelScreen.Controls.Add(_localLicenseInfo);
            _localLicenseInfo.Show();
        }

        public void LoadDataWithInternationalLicensesHistory(int driver_id)
        {
            if (PanelScreen.Controls.Count > 0)
                PanelScreen.Controls.Clear();

            if (_internationalLicenseInfo != null)
            {
                PanelScreen.Controls.Add(_internationalLicenseInfo);
                _localLicenseInfo.Show();
                return;
            }



            _internationalLicenseInfo = new InternationalLicenseHistory(driver_id);
            _internationalLicenseInfo.TopLevel = false;
            _internationalLicenseInfo.Dock = DockStyle.Fill;
            PanelScreen.Controls.Add(_internationalLicenseInfo);
            _internationalLicenseInfo.Show();
        }

        private void btnLocalLicenses_Click(object sender, EventArgs e)
        {
            LoadDataWithLocalLicensesHistory(_driver_id);
        }

        private void btnInternationalLicenses_Click(object sender, EventArgs e)
        {
            LoadDataWithInternationalLicensesHistory(_driver_id);
        }
    }
}
