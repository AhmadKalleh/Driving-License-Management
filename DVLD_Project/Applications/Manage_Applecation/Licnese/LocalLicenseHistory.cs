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

namespace DVLD_Project.Applications.Manage_Applecation.Licnese
{
    public partial class LocalLicenseHistory : Form
    {
        private int _driver_id = -1;
        public LocalLicenseHistory(int driver_id)
        {
            InitializeComponent();
            _driver_id = driver_id;
        }

        private void prepare_settings()
        {
            

            dgvLocalLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvLocalLicenses.ColumnHeadersHeight = 30;
            dgvLocalLicenses.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvLocalLicenses.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvLocalLicenses.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvLocalLicenses.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvLocalLicenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvLocalLicenses.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvLocalLicenses.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvLocalLicenses.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvLocalLicenses.RowsDefaultCellStyle.BackColor = Color.FromArgb(42, 10, 45);
            dgvLocalLicenses.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 10, 45);
            dgvLocalLicenses.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvLocalLicenses.RowsDefaultCellStyle.SelectionForeColor = Color.White;



            

        }

        private void _RefreshLocalLicensesList(DataTable data)
        {

            dgvLocalLicenses.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvLocalLicenses.Rows.Add(
                data.Rows[i]["LicenseID"],
                data.Rows[i]["ApplicationID"],
                data.Rows[i]["ClassName"],
                Convert.ToDateTime(data.Rows[i]["IssueDate"]).ToString("M/d/yyyy h:mm tt"),
                Convert.ToDateTime(data.Rows[i]["ExpirationDate"]).ToString("M/d/yyyy h:mm tt"),
                data.Rows[i]["IsActive"]
                
                );

            }
        }

        private void LocalLicenseHistory_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsLicense.GetAllLocalLicensesByDriverID(this._driver_id);
            _RefreshLocalLicensesList(data);
        }
    }
}
