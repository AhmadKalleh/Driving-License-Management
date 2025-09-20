using DVLD_Busness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application_M
{
    public partial class ManageApplicationsTypesScreen : Form
    {
        public ManageApplicationsTypesScreen()
        {
            InitializeComponent();
        }

        private void prepare_settings()
        {
            // dgvApplicationTypes : 

            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvApplicationTypes.ColumnHeadersHeight = 30;
            dgvApplicationTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(42, 10, 45);
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 10, 45);
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvApplicationTypes.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvApplicationTypes.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvApplicationTypes.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvApplicationTypes.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvApplicationTypes.RowsDefaultCellStyle.SelectionForeColor = Color.White;



        }

        private void _RefreshApplicationsTypesList(DataTable data)
        {

            dgvApplicationTypes.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvApplicationTypes.Rows.Add(
                data.Rows[i]["ApplicationTypeID"],
                data.Rows[i]["ApplicationTypeTitle"],
                data.Rows[i]["ApplicationFees"]               
                );

            }
        }


        private void ManageApplicationsTypesScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsApplicationType.GetAllApplicationsTypes();
            _RefreshApplicationsTypesList(data);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int application_type_id = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value);
            UpdateApplicationTypeScreen screen= new UpdateApplicationTypeScreen(application_type_id);
            screen.ShowDialog();

            if (!UpdateApplicationTypeScreen.is_Match)
            {
                DataTable data = clsApplicationType.GetAllApplicationsTypes();
                _RefreshApplicationsTypesList(data);
            }

            UpdateApplicationTypeScreen.is_Match = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvApplicationTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
