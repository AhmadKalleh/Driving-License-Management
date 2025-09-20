using DVLD_Busness;
using DVLD_Project.Application;
using DVLD_Project.Applications.Manage_Applecation.Licnese;
using DVLD_Project.Applications.Manage_Applecation.SechduleTests;
using DVLD_Project.Applications.Manage_Applecation.Tests;
using DVLD_Project.Manage_Application.Services;
using DVLD_Project.Properties;
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
    public partial class LocalDrivingLicenseApplications : Form
    {
        private bool is_number = false;
        private int clickedRowIndex = -1;

        public ApplicationsScreen applications_screen;
        public LocalDrivingLicenseApplications(ApplicationsScreen applications_screen)
        {
            InitializeComponent();
            this.applications_screen = applications_screen;
        }


        private void prepare_settings()
        {
            // dgvApplication : 

            dgvApplication.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvApplication.ColumnHeadersHeight = 30;
            dgvApplication.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplication.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplication.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplication.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplication.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvApplication.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvApplication.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvApplication.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvApplication.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvApplication.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvApplication.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvApplication.RowsDefaultCellStyle.SelectionForeColor = Color.White;



            // cbFilter : 

            cbFilter.SelectedIndex = 0;

        }

        private void _RefreshLocalDrivingLicenseApplicationsList(DataTable data)
        {

            dgvApplication.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvApplication.Rows.Add(
                data.Rows[i]["LocalDrivingLicenseApplicationID"],
                data.Rows[i]["ClassName"],
                data.Rows[i]["NationalNo"],
                data.Rows[i]["FullName"],
                Convert.ToDateTime(data.Rows[i]["ApplicationDate"]).ToString("M/d/yyyy h:mm tt"),
                data.Rows[i]["PassedTestCount"],
                data.Rows[i]["Status"]
                );

            }
        }

        private void hide_components(bool ishidefortxtsearch, bool ishideforcbHelper)
        {
            txtSearch.Text = "";
            txtSearch.Visible = ishidefortxtsearch;
            cbHelper.Visible = ishideforcbHelper;
        }

        private void LocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            _RefreshLocalDrivingLicenseApplicationsList(data);    
            hide_components(false, false);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false, false);
                        is_number = false;
                        _RefreshLocalDrivingLicenseApplicationsList(data);
                        break;
                    }

                case 1:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshLocalDrivingLicenseApplicationsList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(true, false);
                        _RefreshLocalDrivingLicenseApplicationsList(data);
                        break;
                    }

                case 3:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshLocalDrivingLicenseApplicationsList(data);
                        break;
                    }

                case 4:
                    {
                        hide_components(false, true);
                        cbHelper.SelectedIndex = 0;
                        is_number = false;
                        _RefreshLocalDrivingLicenseApplicationsList(data);
                        break;
                    }

                


            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ApplicationID (أرقام فقط)
            if (cbFilter.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }

            // FullName (نص فقط، نمنع الأرقام)
            else if (cbFilter.SelectedIndex == 3)
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
            
            applications_screen.RemoveControlsOfTypeFromApplicationsPanel(typeof(LocalDrivingLicenseApplications));
            applications_screen.ShowInnerPanel();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            CULocalDrivingLicenseScreen screen = new CULocalDrivingLicenseScreen(-1);
            screen.ShowDialog();
            if (!CULocalDrivingLicenseScreen.isMatch)
            {
                DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                _RefreshLocalDrivingLicenseApplicationsList(data);
            }

            CULocalDrivingLicenseScreen.isMatch = true;
        }

       

        private void cbHelper_SelectedIndexChanged(object sender, EventArgs e)
        {
            string option = "";
            DataTable data;
            if (cbHelper.SelectedItem.ToString().Equals("All"))
            {
                data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsLocalDrivingLicenseApplication.filters_By[filter_value];
                option = cbHelper.SelectedIndex == 1 ? "New" :(cbHelper.SelectedIndex == 2)? "Completed" : "Cancelled";
                data = clsLocalDrivingLicenseApplication.filter(query, option);
            }



            _RefreshLocalDrivingLicenseApplicationsList(data);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                _RefreshLocalDrivingLicenseApplicationsList(data);
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsLocalDrivingLicenseApplication.filters_By[filter_value];

                if (filter_value.Equals("L.D.L.AppID"))
                {

                    DataTable data = clsLocalDrivingLicenseApplication.filter(query, Convert.ToInt64(txtSearch.Text));
                    _RefreshLocalDrivingLicenseApplicationsList(data);
                }
                else
                {
                    DataTable data = clsLocalDrivingLicenseApplication.filter(query, txtSearch.Text.ToString());
                    _RefreshLocalDrivingLicenseApplicationsList(data);
                }
            }
        }

        private void dgvApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                clickedRowIndex = e.RowIndex;
                dgvApplication.ClearSelection();
                
                if (e.Button == MouseButtons.Right)
                {
                    // استرجاع القيم من الصف
                    string status = dgvApplication.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    int passedTestCount = Convert.ToInt32(dgvApplication.Rows[e.RowIndex].Cells["Passed_Tests"].Value);


                    foreach (ToolStripItem item in contextMenuStrip1.Items)
                        item.Enabled = true;


                    // الشرط 1: إذا Status = New و PassedTestCount != 3
                    if (status == "New" && passedTestCount != 3)
                    {
                        contextMenuStrip1.Items["issueDrivingLicenseToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = false;

                        if(passedTestCount == 1 || passedTestCount == 2)
                        {
                            contextMenuStrip1.Items["editApplicationToolStripMenuItem"].Enabled = false;

                        }
                    }


                    // الشرط 2: إذا Status = New و PassedTestCount = 3
                    else if (status == "New" && passedTestCount == 3)
                    {
                        contextMenuStrip1.Items["sechduleTestsToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = false;
                    }
                    // الشرط 3: إذا Status = Completed و PassedTestCount = 3


                    else if (status == "Completed" && passedTestCount == 3)
                    {
                        for (int i = 0; i < contextMenuStrip1.Items.Count; i++)
                        {
                            contextMenuStrip1.Items[i].Enabled = false;
                        }

                        contextMenuStrip1.Items["showApplicationDeatToolStripMenuItem"].Enabled = true;
                        contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = true;
                        contextMenuStrip1.Items["showPersonLicenseHistoryToolStripMenuItem"].Enabled = true;
                    }

                    else if (status == "Cancelled")
                    {
                        contextMenuStrip1.Items["editApplicationToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["cancelApplicationToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["sechduleTestsToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["issueDrivingLicenseToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["showLicenseToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Show(Cursor.Position);

                        return;
                    }

                    // التعامل مع SubItems للعنصر رقم 5
                    if (contextMenuStrip1.Items["sechduleTestsToolStripMenuItem"] is ToolStripMenuItem item5)
                    {
                        // إظهار كل SubItems مبدئياً
                        foreach (ToolStripItem sub in item5.DropDownItems)
                        {
                            sub.Enabled = true;
                        }

                        if (passedTestCount == 0)
                        {
                            item5.DropDownItems["scheduleWrittenTestToolStripMenuItem1"].Enabled = false;
                            item5.DropDownItems["scheduleStreetTestToolStripMenuItem2"].Enabled = false;
                        }
                        else if (passedTestCount == 1)
                        {
                            item5.DropDownItems["scheduleVisionTestToolStripMenuItem"].Enabled = false;
                            item5.DropDownItems["scheduleStreetTestToolStripMenuItem2"].Enabled = false;
                        }
                        else if (passedTestCount == 2)
                        {
                            item5.DropDownItems["scheduleVisionTestToolStripMenuItem"].Enabled = false;
                            item5.DropDownItems["scheduleWrittenTestToolStripMenuItem1"].Enabled = false;
                        }
                    }
                    

                    // أخيراً: عرض القائمة
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else
            {
                clickedRowIndex = -1;
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this application ? ", "Confirm Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;

                clsLocalDrivingLicenseApplication licenseApplication = clsLocalDrivingLicenseApplication.Find(local_driving_license_application_id);

                
                if(clsApplication.DeleteApplication(licenseApplication.application_id))
                {
                    MessageBox.Show("Application Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                    _RefreshLocalDrivingLicenseApplicationsList(data);
                }
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;

            CULocalDrivingLicenseScreen screen = new CULocalDrivingLicenseScreen(local_driving_license_application_id);
            screen.ShowDialog();
            if (!CULocalDrivingLicenseScreen.isMatch)
            {
                DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                _RefreshLocalDrivingLicenseApplicationsList(data);
            }

            CULocalDrivingLicenseScreen.isMatch = true;

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;
            clsLocalDrivingLicenseApplication licenseApplication = clsLocalDrivingLicenseApplication.Find(local_driving_license_application_id);

            clsApplication application = clsApplication.Find(licenseApplication.application_id);

            application.application_status = 2;
            application.last_status_date = DateTime.Now;


            if (MessageBox.Show("Are you sure you want to cancel this application ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (application.Save())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                    _RefreshLocalDrivingLicenseApplicationsList(data);
                }
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;
            int passed_tests = (int)dgvApplication.Rows[clickedRowIndex].Cells["Passed_Tests"].Value;
            sechduleTests sechduleTests = new sechduleTests(clsTestType.Test_Type_With_ID.Keys.ElementAt(0),Resources.eye_scan, local_driving_license_application_id,passed_tests);
            sechduleTests.ShowDialog();

            DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            _RefreshLocalDrivingLicenseApplicationsList(data);
        }

        private void scheduleWrittenTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;
            int passed_tests = (int)dgvApplication.Rows[clickedRowIndex].Cells["Passed_Tests"].Value;
            sechduleTests sechduleTests = new sechduleTests(clsTestType.Test_Type_With_ID.Keys.ElementAt(1), Resources.test__1_, local_driving_license_application_id, passed_tests);
            sechduleTests.ShowDialog();

            DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            _RefreshLocalDrivingLicenseApplicationsList(data);
        }

        private void scheduleStreetTestToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;
            int passed_tests = (int)dgvApplication.Rows[clickedRowIndex].Cells["Passed_Tests"].Value;
            sechduleTests sechduleTests = new sechduleTests(clsTestType.Test_Type_With_ID.Keys.ElementAt(2), Resources.driving_test, local_driving_license_application_id, passed_tests);
            sechduleTests.ShowDialog();

            DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            _RefreshLocalDrivingLicenseApplicationsList(data);
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;
            int passed_tests = (int)dgvApplication.Rows[clickedRowIndex].Cells["Passed_Tests"].Value;

            IssueDrivingLicenseForTheFirstTime issueDrivingLicenseForTheFirstTime = new IssueDrivingLicenseForTheFirstTime(local_driving_license_application_id, passed_tests);
            issueDrivingLicenseForTheFirstTime.ShowDialog();


            if(!IssueDrivingLicenseForTheFirstTime.isMatch)
            {
                DataTable data = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
                _RefreshLocalDrivingLicenseApplicationsList(data);
            }

            IssueDrivingLicenseForTheFirstTime.isMatch = true;
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;

            DriverLicense driverLicense = new DriverLicense(local_driving_license_application_id);
            driverLicense.ShowDialog();

            

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int local_driving_license_application_id = (int)dgvApplication.Rows[clickedRowIndex].Cells["L_D_L_AppID"].Value;

            ShowLicenseHistory licenseHistory = new ShowLicenseHistory(local_driving_license_application_id);
            licenseHistory.ShowDialog();


        }
    }
}
