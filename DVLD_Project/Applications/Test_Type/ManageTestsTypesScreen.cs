using DVLD_Busness;
using DVLD_Project.Application_M;
using DVLD_Project.Manage_Application.Test_Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application_Type
{
    public partial class ManageTestsTypesScreen : Form
    {
        public ManageTestsTypesScreen()
        {
            InitializeComponent();
        }

        private void prepare_settings()
        {
            // dgvApplicationTypes : 

            dgvTestsTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvTestsTypes.ColumnHeadersHeight = 30;
            dgvTestsTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvTestsTypes.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvTestsTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(42, 10, 45);
            dgvTestsTypes.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 10, 45);
            dgvTestsTypes.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvTestsTypes.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvTestsTypes.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvTestsTypes.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvTestsTypes.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvTestsTypes.RowsDefaultCellStyle.SelectionForeColor = Color.White;



        }

        private void _RefreshTestsTypesList(DataTable data)
        {

            dgvTestsTypes.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvTestsTypes.Rows.Add(
                data.Rows[i]["TestTypeID"],
                data.Rows[i]["TestTypeTitle"],
                data.Rows[i]["TestTypeDescription"],
                data.Rows[i]["TestTypeFees"]
                );

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTestsTypesScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsTestType.GetAllTestTypes();
            _RefreshTestsTypesList(data);
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int test_type_id = Convert.ToInt32(dgvTestsTypes.CurrentRow.Cells[0].Value);
            UpdateTestTypeScreen screen = new UpdateTestTypeScreen(test_type_id);
            screen.ShowDialog();

            if (!UpdateTestTypeScreen.is_Match)
            {
                DataTable data = clsTestType.GetAllTestTypes();
                _RefreshTestsTypesList(data);
            }

            UpdateTestTypeScreen.is_Match = true;
        }
    }
}
