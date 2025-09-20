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
    public partial class InternationalLicenseHistory : Form
    {
        private int _driver_id = -1;
        public InternationalLicenseHistory(int driver_id)
        {
            InitializeComponent();
            _driver_id = driver_id;
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
            dgvInterNationalLicenses.RowsDefaultCellStyle.BackColor = Color.FromArgb(42, 10, 45);
            dgvInterNationalLicenses.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(42, 10, 45);
            dgvInterNationalLicenses.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvInterNationalLicenses.RowsDefaultCellStyle.SelectionForeColor = Color.White;





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

        private void InternationalLicenseHistory_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsInternationalLicense.GetAllInternationalLicensesByDriverID(this._driver_id);
            _RefreshInternationalLicensesList(data);
        }
    }
}
