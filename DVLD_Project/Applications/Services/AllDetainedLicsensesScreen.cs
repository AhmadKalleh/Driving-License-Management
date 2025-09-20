using DVLD_Busness;
using DVLD_Project.Application;
using DVLD_Project.Applications.Manage_Applecation;
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

namespace DVLD_Project.Applications.Services
{
    public partial class AllDetainedLicsensesScreen : Form
    {
        private bool is_number = false;
        private int clickedRowIndex = -1;

        public ApplicationsScreen applications_screen;
        public AllDetainedLicsensesScreen(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen;
        }

        private void prepare_settings()
        {


            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvDetainedLicenses.ColumnHeadersHeight = 30;
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDetainedLicenses.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDetainedLicenses.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvDetainedLicenses.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetainedLicenses.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvDetainedLicenses.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvDetainedLicenses.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvDetainedLicenses.RowsDefaultCellStyle.SelectionForeColor = Color.White;


            cbFilter.SelectedIndex = 0;


        }

        private void _RefreshDetainedLicensesList(DataTable data)
        {

            dgvDetainedLicenses.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];

                // DetainDate (مفروض دايمًا موجود)
                string detainDate = row["DetainDate"] == DBNull.Value
                    ? ""
                    : Convert.ToDateTime(row["DetainDate"]).ToString("M/d/yyyy h:mm tt");

                // ReleaseDate (ممكن يكون NULL)
                string releaseDate = row["ReleaseDate"] == DBNull.Value
                    ? "N/A"
                    : Convert.ToDateTime(row["ReleaseDate"]).ToString("M/d/yyyy h:mm tt");

                // ReleaseApplicationID (ممكن يكون NULL)
                var releaseAppID = row["ReleaseApplicationID"] == DBNull.Value
                    ? "N/A"
                    : row["ReleaseApplicationID"].ToString();

                dgvDetainedLicenses.Rows.Add(
                    row["DetainID"],
                    row["LicenseID"],
                    detainDate,
                    row["IsReleased"],
                    row["FineFees"],
                    releaseDate,
                    row["NationalNo"],
                    row["FullName"],
                    releaseAppID
                );
            }

        }

        private void hide_components(bool ishidefortxtsearch, bool ishideforcbHelper)
        {
            txtSearch.Text = "";
            txtSearch.Visible = ishidefortxtsearch;
            cbHelper.Visible = ishideforcbHelper;
        }

        private void AllDetainedLicsensesScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsDetainLicense.GetAllDetainLicenses();
            _RefreshDetainedLicensesList(data);
            hide_components(false, false);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsDetainLicense.GetAllDetainLicenses();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false, false);
                        is_number = false;
                        _RefreshDetainedLicensesList(data);
                        break;
                    }

                case 1:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshDetainedLicensesList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(false, true);
                        is_number = false;
                        _RefreshDetainedLicensesList(data);
                        cbHelper.SelectedIndex = 0;
                        break;
                    }

                case 3:
                    {
                        hide_components(true, false);
                   
                        _RefreshDetainedLicensesList(data);
                        
                        break;
                    }


                case 4:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshDetainedLicensesList(data);

                        break;
                    }

                case 5:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshDetainedLicensesList(data);
                        break;
                    }





            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsDetainLicense.GetAllDetainLicenses();
                _RefreshDetainedLicensesList(data);
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsDetainLicense.filters_By[filter_value];

                if(filter_value.Equals("Detain ID") || filter_value.Equals("Release App ID"))
                {
                    DataTable data = clsDetainLicense.filter(query, Convert.ToInt64(txtSearch.Text));
                    _RefreshDetainedLicensesList(data);
                }
                else
                {
                    DataTable data = clsDetainLicense.filter(query, txtSearch.Text);
                    _RefreshDetainedLicensesList(data);

                }


            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ApplicationID (أرقام فقط)
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 5)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }

            // FullName (نص فقط، نمنع الأرقام)
            else if (cbFilter.SelectedIndex == 4)
            {
                if (char.IsDigit(e.KeyChar))
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
            applications_screen.RemoveControlsOfTypeFromApplicationsPanel(typeof(AllDetainedLicsensesScreen));
            applications_screen.ShowInnerPanel();
        }

        private void cbHelper_SelectedIndexChanged(object sender, EventArgs e)
        {
            int option = -1;
            DataTable data;
            if (cbHelper.SelectedItem.ToString().Equals("All"))
            {
                data = clsDetainLicense.GetAllDetainLicenses();
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsDetainLicense.filters_By[filter_value];
                option = cbHelper.SelectedIndex == 1 ? 1 : 0;
                data = clsDetainLicense.filter(query, option);
            }



            _RefreshDetainedLicensesList(data);
        }

        private void showApplicationDeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }


            int L_ID = Convert.ToInt32(dgvDetainedLicenses.Rows[clickedRowIndex].Cells["L_ID"].Value);
            int driver_id = clsLicense.FindByLicenseID(L_ID).driver_id;
            int person_id = clsDriver.Find(driver_id).person_id;
            PersonDetails details = new PersonDetails(person_id);
            details.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int L_ID = Convert.ToInt32(dgvDetainedLicenses.Rows[clickedRowIndex].Cells["L_ID"].Value);
            int driver_id = clsLicense.FindByLicenseID(L_ID).driver_id;
            int application_id = clsLicense.FindByLicenseDriverID(driver_id, L_ID).application_id;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id);
            int local_driving_license_application_id = -1;
            if (localDrivingLicenseApplication == null)
            {
                DataTable dt = clsLicense.GetAllLocalLicensesByDriverID(driver_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1]; // آخر صف
                    application_id = Convert.ToInt32(lastRow["ApplicationID"]);
                    local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
                }
            }
            else
            {
                local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
            }

            ShowLicenseHistory licenseHistory = new ShowLicenseHistory(local_driving_license_application_id);
            licenseHistory.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int L_ID = Convert.ToInt32(dgvDetainedLicenses.Rows[clickedRowIndex].Cells["L_ID"].Value);
            int driver_id = clsLicense.FindByLicenseID(L_ID).driver_id;
            int application_id = clsLicense.FindByLicenseDriverID(driver_id, L_ID).application_id;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id);
            int local_driving_license_application_id = -1;
            if (localDrivingLicenseApplication == null)
            {
                DataTable dt = clsLicense.GetAllLocalLicensesByDriverID(driver_id);
                if (dt.Rows.Count > 0)
                {
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1]; // آخر صف
                    application_id = Convert.ToInt32(lastRow["ApplicationID"]);
                    local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
                }
            }
            else
            {
                local_driving_license_application_id = clsLocalDrivingLicenseApplication.FindByApplicationID(application_id).id;
            }



            DriverLicense driverLicense = new DriverLicense(local_driving_license_application_id);
            driverLicense.ShowDialog();
        }

        private void dgvDetainedLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvDetainedLicenses.Rows[e.RowIndex].IsNewRow)
            {
                clickedRowIndex = e.RowIndex;
                dgvDetainedLicenses.ClearSelection();
                dgvDetainedLicenses.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right)
                {
                    foreach (ToolStripItem item in contextMenuStrip1.Items)
                        item.Enabled = true;

                    bool is_released = Convert.ToBoolean(dgvDetainedLicenses.Rows[clickedRowIndex].Cells["Is_Released"].Value);

                    if (is_released)
                    {
                        contextMenuStrip1.Items["releaseDetainLicenseToolStripMenuItem"].Enabled = false;
                    }
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else
            {
                clickedRowIndex = -1;
            }
        }

        private void btnDetaine_Click(object sender, EventArgs e)
        {
            DetainLicenseScreen detainLicense = new DetainLicenseScreen();
            detainLicense.ShowDialog();

            if(!DetainLicenseScreen.isMatch)
            {
                DataTable data = clsDetainLicense.GetAllDetainLicenses();
                _RefreshDetainedLicensesList(data);
            }

            DetainLicenseScreen.isMatch = true;

            
          
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicenseScreen releaseDetained = new ReleaseDetainedLicenseScreen();
            releaseDetained.ShowDialog();

            if (!ReleaseDetainedLicenseScreen.isMatch)
            {
                DataTable data = clsDetainLicense.GetAllDetainLicenses();
                _RefreshDetainedLicensesList(data);
            }

            ReleaseDetainedLicenseScreen.isMatch = true;
        }
    }
}
