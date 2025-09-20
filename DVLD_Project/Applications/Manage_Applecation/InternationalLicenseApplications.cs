using DVLD_Busness;
using DVLD_Project.Application;
using DVLD_Project.Applications.Manage_Applecation.Licnese;
using DVLD_Project.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation
{
    public partial class InternationalLicenseApplications : Form
    {
        private bool is_number = false;
        private int clickedRowIndex = -1;

        public ApplicationsScreen applications_screen;
        public InternationalLicenseApplications(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen;
        }


        private void prepare_settings()
        {


            dgvInterNationalLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvInterNationalLicenses.ColumnHeadersHeight = 30;
            dgvInterNationalLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvInterNationalLicenses.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvInterNationalLicenses.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvInterNationalLicenses.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvInterNationalLicenses.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvInterNationalLicenses.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvInterNationalLicenses.RowsDefaultCellStyle.SelectionForeColor = Color.White;


            cbFilter.SelectedIndex = 0;


        }

        private void _RefreshInternationalLicensesList(DataTable data)
        {

            dgvInterNationalLicenses.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvInterNationalLicenses.Rows.Add(
                data.Rows[i]["InternationalLicenseID"],
                data.Rows[i]["ApplicationID"],
                data.Rows[i]["DriverID"],
                data.Rows[i]["IssuedUsingLocalLicenseID"],
                Convert.ToDateTime(data.Rows[i]["IssueDate"]).ToString("M/d/yyyy h:mm tt"),
                Convert.ToDateTime(data.Rows[i]["ExpirationDate"]).ToString("M/d/yyyy h:mm tt"),
                data.Rows[i]["IsActive"]

                );

            }
        }

        private void hide_components(bool ishidefortxtsearch, bool ishideforcbHelper)
        {
            txtSearch.Text = "";
            txtSearch.Visible = ishidefortxtsearch;
            cbHelper.Visible = ishideforcbHelper;
        }

        private void InternationalLicenseApplications_Load(object sender, EventArgs e)
        {

            prepare_settings();
            DataTable data = clsInternationalLicense.GetAllInternationalLicenses();
            _RefreshInternationalLicensesList(data);
            hide_components(false, false);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsInternationalLicense.GetAllInternationalLicenses();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false, false);
                        is_number = false;
                        _RefreshInternationalLicensesList(data);
                        break;
                    }

                case 1:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshInternationalLicensesList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshInternationalLicensesList(data);
                        break;
                    }

                case 3:
                    {
                        hide_components(false, true);
                        is_number = false;
                        _RefreshInternationalLicensesList(data);
                        cbHelper.SelectedIndex = 0;
                        break;
                    }

                



            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsInternationalLicense.GetAllInternationalLicenses();
                _RefreshInternationalLicensesList(data);
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsInternationalLicense.filters_By[filter_value];

                

                DataTable data = clsInternationalLicense.filter(query, Convert.ToInt64(txtSearch.Text));
                _RefreshInternationalLicensesList(data);
                
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ApplicationID (أرقام فقط)
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }     

            // NationalNo أو باقي الحالات (مسموح أي شيء)
            else
            {
                e.Handled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            applications_screen.RemoveControlsOfTypeFromApplicationsPanel(typeof(InternationalLicenseApplications));
            applications_screen.ShowInnerPanel();
        }

        private void cbHelper_SelectedIndexChanged(object sender, EventArgs e)
        {
            int option = -1;
            DataTable data;
            if (cbHelper.SelectedItem.ToString().Equals("All"))
            {
                data = clsInternationalLicense.GetAllInternationalLicenses();
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsInternationalLicense.filters_By[filter_value];
                option = cbHelper.SelectedIndex == 1 ? 1 : 0;
                data = clsLocalDrivingLicenseApplication.filter(query, option);
            }



            _RefreshInternationalLicensesList(data);
        }

        private void dgvInterNationalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvInterNationalLicenses.Rows[e.RowIndex].IsNewRow)
            {
                clickedRowIndex = e.RowIndex;
                dgvInterNationalLicenses.ClearSelection();
                dgvInterNationalLicenses.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else
            {
                clickedRowIndex = -1;
            }
        }

        private void showApplicationDeatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }


            int driver_id = Convert.ToInt32(dgvInterNationalLicenses.Rows[clickedRowIndex].Cells["Driver_ID"].Value);
            int person_id = clsDriver.Find(driver_id).person_id;
            PersonDetails details = new PersonDetails(person_id);
            details.ShowDialog();

            
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driver_id = Convert.ToInt32(dgvInterNationalLicenses.Rows[clickedRowIndex].Cells["Driver_ID"].Value);
            int license_id = (int)dgvInterNationalLicenses.Rows[clickedRowIndex].Cells["L_License_ID"].Value;
            int application_id = clsLicense.FindByLicenseDriverID(driver_id,license_id).application_id;
            int local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;

            DriverLicense driverLicense = new DriverLicense(local_driving_license_application_id);
            driverLicense.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driver_id = Convert.ToInt32(dgvInterNationalLicenses.Rows[clickedRowIndex].Cells["Driver_ID"].Value);
            int license_id = (int)dgvInterNationalLicenses.Rows[clickedRowIndex].Cells["L_License_ID"].Value;
            int application_id = clsLicense.FindByLicenseDriverID(driver_id, license_id).application_id;
            int local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;

            ShowLicenseHistory licenseHistory = new ShowLicenseHistory(local_driving_license_application_id);
            licenseHistory.ShowDialog();
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            AddNewInternationalLicense screen = new AddNewInternationalLicense();
            screen.ShowDialog();
            if (!AddNewInternationalLicense.isMatch)
            {
                DataTable data = clsInternationalLicense.GetAllInternationalLicenses();
                _RefreshInternationalLicensesList(data);
            }

            AddNewInternationalLicense.isMatch = true;
        }
    }
}
