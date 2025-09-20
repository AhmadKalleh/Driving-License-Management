using DVLD_Busness;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace DVLD_Project.Person
{
    public partial class PeopleScreen : Form
    {
        public PeopleScreen()
        {
            InitializeComponent();
        }

        private bool is_number = false;
        private int clickedRowIndex = -1;
        private void prepare_settings()
        {
            // dgvPeople : 

            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvPeople.ColumnHeadersHeight = 30;
            dgvPeople.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvPeople.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvPeople.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvPeople.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvPeople.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvPeople.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvPeople.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvPeople.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvPeople.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvPeople.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvPeople.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvPeople.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            ((DataGridViewImageColumn)dgvPeople.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Zoom;


            // cbFilter : 

            cbFilter.SelectedIndex = 0;
            
        }

        private void _RefreshPeopleList(DataTable data)
        {
            
            dgvPeople.Rows.Clear();
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string imagePath = data.Rows[i]["ImagePath"].ToString();

                Image img;

                if (File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        img = new Bitmap(Image.FromStream(fs)); // تحميل نسخة فقط دون قفل الملف
                    }
                }
                else
                {
                    img = (Convert.ToByte(data.Rows[i]["Gendor"]) == 0) ? Resources.man : Resources.woman;
                }
                dgvPeople.Rows.Add(
                img,
                data.Rows[i]["PersonID"],
                data.Rows[i]["NationalNo"],
                data.Rows[i]["FirstName"],
                data.Rows[i]["SecondName"],
                data.Rows[i]["ThirdName"],
                data.Rows[i]["LastName"],
                (Convert.ToByte(data.Rows[i]["Gendor"]) == 0) ? "Male" : "Female",
                data.Rows[i]["DateOfBirth"],
                data.Rows[i]["CountryName"],
                data.Rows[i]["Phone"],
                data.Rows[i]["Email"]
                );

            }
        }

        private void hide_components(bool ishidefortxtsearch, bool ishideforcbHelper)
        {
            txtSearch.Text = "";
            txtSearch.Visible = ishidefortxtsearch;
            cbHelper.Visible = ishideforcbHelper;
        }
        private void PeopleScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsPerson.GetAllPersons();
            _RefreshPeopleList(data);          
            hide_components(false,false);
            
        }

        private void fill_cbHelper(List<string> list)
        {
            cbHelper.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                cbHelper.Items.Add(list[i]);
            }

            cbHelper.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsPerson.GetAllPersons();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false,false);
                        is_number = false;                    
                        _RefreshPeopleList(data);                       
                        break;
                    }

                case 1:
                    {
                        hide_components(true, false);      
                        is_number = true;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 3:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 4:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 5:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 6:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }

                case 7:
                    {
                        hide_components(false, true);
                        List<string> list = clsCountry.GetAllCountries();
                        fill_cbHelper(list);
                        is_number = false;
                        break;
                    }

                case 8:
                    {
                        hide_components(false, true);
                        fill_cbHelper(new List<string> { "male", "female" });
                        is_number = false;
                        break;
                    }

                case 9:
                    {
                        hide_components(true, false);
                        is_number = false;
                        break;
                    }

                case 10:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshPeopleList(data);
                        break;
                    }
    
            }
        }

        

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (is_number)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true; // لا نسمح إلا بالأرقام أو الحذف
                }
            }
            else
            {
                
                    e.Handled = false;
                
            }
        }

        private void cbHelper_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter_value = cbFilter.SelectedItem.ToString();
            string query = clsPerson.filters_By[filter_value];

            int option = -1;

            if (filter_value.Equals("nationality"))
            {
                option = cbHelper.SelectedIndex + 1;
            }
            else
            {
                option = cbHelper.SelectedItem.ToString() == "male" ? 0 : 1;
            }
            
            DataTable data = clsPerson.filter(query,option);
            _RefreshPeopleList(data);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsPerson.GetAllPersons();
                _RefreshPeopleList(data);

            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsPerson.filters_By[filter_value];

                if (filter_value.Equals("person_id"))
                {

                    DataTable data = clsPerson.filter(query, Convert.ToInt64(txtSearch.Text));                   
                    _RefreshPeopleList(data);
                }
                else
                {
                    DataTable data = clsPerson.filter(query, txtSearch.Text.ToString());                    
                    _RefreshPeopleList(data);
                }
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            CUScreen screen = new CUScreen(-1);
            screen.ShowDialog();
            if (!CUScreen.isMatch)
            {
                DataTable data = clsPerson.GetAllPersons();
                _RefreshPeopleList(data);
            }

            CUScreen.isMatch = true;
        }

        private void dgvPeople_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvPeople.Rows[e.RowIndex].IsNewRow)
            {
                clickedRowIndex = e.RowIndex;
                dgvPeople.ClearSelection();
                dgvPeople.Rows[e.RowIndex].Selected = true;

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

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            int person_id = Convert.ToInt32(dgvPeople.Rows[clickedRowIndex].Cells["id"].Value);
            PersonDetails details = new PersonDetails(person_id);
            details.ShowDialog();

            if (!CUScreen.isMatch)
            {
                DataTable data = clsPerson.GetAllPersons();
                _RefreshPeopleList(data);
            }

            CUScreen.isMatch = true;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            int person_id = Convert.ToInt32(dgvPeople.Rows[clickedRowIndex].Cells["id"].Value);

            CUScreen screen = new CUScreen(person_id);
            screen.ShowDialog();

            if (!CUScreen.isMatch)
            {
                DataTable data = clsPerson.GetAllPersons();
                _RefreshPeopleList(data);
            }

            CUScreen.isMatch = true;
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUScreen screen = new CUScreen(-1);
            screen.ShowDialog();
            if (!CUScreen.isMatch)
            {
                DataTable data = clsPerson.GetAllPersons();
                _RefreshPeopleList(data);
            }

            CUScreen.isMatch = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete person [" + (dgvPeople.CurrentRow.Cells[1].Value) + "]", "Confirm Delete", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerosn((int)dgvPeople.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    DataTable data = clsPerson.GetAllPersons();
                    _RefreshPeopleList(data);
                }

                else
                    MessageBox.Show("Person is not deleted due to data connected to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("send email feature is stap (.-.)","Note",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("phone call feature is stap (.-.)", "Note", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
