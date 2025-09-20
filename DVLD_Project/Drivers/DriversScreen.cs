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

namespace DVLD_Project.Drivers
{
    public partial class DriversScreen : Form
    {
        private bool is_number = false;
        private int clickedRowIndex = -1;
        public DriversScreen()
        {
            InitializeComponent();
        }

        private void prepare_settings()
        {
            // dgvPeople : 

            dgvDrivers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvDrivers.ColumnHeadersHeight = 30;
            dgvDrivers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDrivers.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDrivers.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDrivers.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvDrivers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvDrivers.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvDrivers.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvDrivers.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvDrivers.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvDrivers.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvDrivers.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvDrivers.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            

            // cbFilter : 

            cbFilter.SelectedIndex = 0;

        }

        private void _RefreshDriversList(DataTable data)
        {

            dgvDrivers.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvDrivers.Rows.Add(
                data.Rows[i]["DriverID"],
                data.Rows[i]["PersonID"],
                data.Rows[i]["NationalNo"],
                data.Rows[i]["FullName"],
                Convert.ToDateTime(data.Rows[i]["CreatedDate"]).ToString("M/d/yyyy h:mm tt"),
                data.Rows[i]["NumberOfActiveLicense"]
                
                );

            }
        }

        private void hide_components(bool ishidefortxtsearch)
        {
            txtSearch.Text = "";
            txtSearch.Visible = ishidefortxtsearch;
            
        }

        private void DriversScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsDriver.GetAllDrivers();
            _RefreshDriversList(data);
            hide_components(false);
        }

        

        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsDriver.GetAllDrivers();
                _RefreshDriversList(data);
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsDriver.filters_By[filter_value];

                if (filter_value.Equals("Driver ID") || filter_value.Equals("Person ID"))
                {

                    DataTable data = clsDriver.filter(query, Convert.ToInt64(txtSearch.Text));
                    _RefreshDriversList(data);
                }
                else
                {
                    DataTable data = clsDriver.filter(query, txtSearch.Text.ToString());
                    _RefreshDriversList(data);
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsDriver.GetAllDrivers();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false);
                        is_number = false;
                        _RefreshDriversList(data);
                        break;
                    }

                case 1:
                    {
                        hide_components(true);
                        is_number = true;
                        _RefreshDriversList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(true);
                        is_number = true;
                        _RefreshDriversList(data);
                        break;
                    }

                case 3:
                    {
                        hide_components(true);
                        _RefreshDriversList(data);
                        break;
                    }

                case 4:
                    {
                        hide_components(true);
                        is_number = false;
                        _RefreshDriversList(data);
                        break;
                    }




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
    }
}
