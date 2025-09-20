using DVLD_Busness;
using DVLD_Project.Applications.Manage_Applecation.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Manage_Applecation.SechduleTests
{
    public partial class sechduleTests : Form
    {
        private string _test_type;
        private Image _test_type_image;
        private int _local_driving_license_application_id;
        private int _passed_tests;
        private int clickedRowIndex = -1;

        private void prepare_settings()
        {
            // dgvApplication : 

            dgvAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvAppointments.ColumnHeadersHeight = 30;
            dgvAppointments.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvAppointments.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvAppointments.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvAppointments.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvAppointments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvAppointments.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvAppointments.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvAppointments.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvAppointments.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvAppointments.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvAppointments.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvAppointments.RowsDefaultCellStyle.SelectionForeColor = Color.White;



         

        }

        private void _RefreshAppointmentsList(DataTable data)
        {

            dgvAppointments.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                
                dgvAppointments.Rows.Add(
                data.Rows[i]["TestAppointmentID"],
                Convert.ToDateTime(data.Rows[i]["AppointmentDate"]).ToString("M/d/yyyy h:mm tt"),
                data.Rows[i]["PaidFees"],
                data.Rows[i]["IsLocked"]
                
                );

            }
        }
        public sechduleTests(string test_type,Image test_type_image,
            int local_driving_license_application_id, int passed_tests )
        {
            InitializeComponent();
            this._test_type = test_type;
            this._test_type_image = test_type_image;
            this._local_driving_license_application_id = local_driving_license_application_id;
            this._passed_tests = passed_tests;
        }

        private void SechduleTests_Load(object sender, EventArgs e)
        {
            localDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(this._local_driving_license_application_id, this._passed_tests);
            PbTestTypeImage.BackgroundImage = this._test_type_image;
            lbTestType.Text = this._test_type+ " Appointments";

            prepare_settings();
            DataTable dt = clsAppointment.GetAllAppointments(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);
            _RefreshAppointmentsList(dt);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            
            var appointment_result = clsAppointment.GetLatestActiveAppointment(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);

            
            if(!appointment_result.is_locked && appointment_result.found)
            {
                MessageBox.Show("Person already have an active appointment for this test you cann't add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if(appointment_result.is_locked && appointment_result.test_result && appointment_result.found)
            {
                MessageBox.Show("This Person already passed this test before,you can only retake failed test ", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            AddNewAppointmentForTest addNewAppointment = new AddNewAppointmentForTest(-1,
                this._local_driving_license_application_id,
                appointment_result.fail_count
                , this._test_type, this._test_type_image);

            addNewAppointment.ShowDialog();

            
            if(!AddNewAppointmentForTest.isMatch)
            {
                DataTable data = clsAppointment.GetAllAppointments(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);
                _RefreshAppointmentsList(data);
            }
            
            

            AddNewAppointmentForTest.isMatch = true;
        }

        private void dgvAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvAppointments.Rows[e.RowIndex].IsNewRow)
            {
                clickedRowIndex = e.RowIndex;
                dgvAppointments.ClearSelection();
                dgvAppointments.Rows[e.RowIndex].Selected = true;

                if (e.Button == MouseButtons.Right)
                {
                    bool is_locked = Convert.ToBoolean(dgvAppointments.Rows[clickedRowIndex].Cells["Is_Locked"].Value);

                    foreach (ToolStripItem item in contextMenuStrip1.Items)
                        item.Enabled = true;


                    if(is_locked)
                    {
                        contextMenuStrip1.Items["editToolStripMenuItem"].Enabled = false;
                        contextMenuStrip1.Items["takeTestToolStripMenuItem"].Enabled = false;
                    }
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            else
            {
                clickedRowIndex = -1;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appointment_result = clsAppointment.GetLatestActiveAppointment(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);

            int appointment_id = Convert.ToInt32(dgvAppointments.Rows[clickedRowIndex].Cells["Appointment_ID"].Value);

          

            AddNewAppointmentForTest addNewAppointment = new AddNewAppointmentForTest(appointment_id,
                this._local_driving_license_application_id,
                appointment_result.fail_count
                , this._test_type, this._test_type_image);

            addNewAppointment.ShowDialog();


            if (!AddNewAppointmentForTest.isMatch)
            {
                DataTable data = clsAppointment.GetAllAppointments(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);
                _RefreshAppointmentsList(data);
            }



            AddNewAppointmentForTest.isMatch = true;

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appointment_result = clsAppointment.GetLatestActiveAppointment(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);
            int appointment_id = Convert.ToInt32(dgvAppointments.Rows[clickedRowIndex].Cells["Appointment_ID"].Value);

            sechduledTest test = new sechduledTest(this._test_type_image, appointment_id, appointment_result.fail_count);
            test.ShowDialog();

            if(!sechduledTest.isMatch)
            {
                DataTable data = clsAppointment.GetAllAppointments(this._local_driving_license_application_id, clsTestType.Test_Type_With_ID[this._test_type]);
                _RefreshAppointmentsList(data);
            }

            sechduledTest.isMatch = true;
        }
    }
}
