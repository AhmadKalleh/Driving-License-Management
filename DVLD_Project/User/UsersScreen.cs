using DVLD_Busness;
using DVLD_Project.Person;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.User
{
    public partial class UsersScreen : Form
    {
        public UsersScreen()
        {
            InitializeComponent();
        }


        private bool is_number = false;
        private int clickedRowIndex = -1;
        private void prepare_settings()
        {
            // dgvPeople : 

            dgvUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 7, 215);
            dgvUser.ColumnHeadersHeight = 30;
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvUser.AlternatingRowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvUser.DefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvUser.RowsDefaultCellStyle.Font = new Font("Arial Rounded MT", 10, FontStyle.Bold);
            dgvUser.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(51, 10, 48);
            dgvUser.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 10, 48);
            dgvUser.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvUser.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
            dgvUser.RowsDefaultCellStyle.BackColor = Color.FromArgb(40, 1, 37);
            dgvUser.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(40, 1, 37);
            dgvUser.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvUser.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            

            // cbFilter : 

            cbFilter.SelectedIndex = 0;

        }

        private void _RefreshUsersList(DataTable data)
        {

            dgvUser.Rows.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {

                dgvUser.Rows.Add(
                data.Rows[i]["UserID"],
                data.Rows[i]["PersonID"],
                data.Rows[i]["FullName"],
                data.Rows[i]["UserName"],
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

        private void UsersScreen_Load(object sender, EventArgs e)
        {
            prepare_settings();
            DataTable data = clsUser.GetAllUsers();
            _RefreshUsersList(data);
            hide_components(false, false);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = clsUser.GetAllUsers();
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    {
                        hide_components(false, false);
                        is_number = false;
                        _RefreshUsersList(data);
                        break;
                    }

                case 1:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshUsersList(data);
                        break;
                    }

                case 2:
                    {
                        hide_components(true, false);
                        is_number = true;
                        _RefreshUsersList(data);
                        break;
                    }

                case 3:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshUsersList(data);
                        break;
                    }

                case 4:
                    {
                        hide_components(true, false);
                        is_number = false;
                        _RefreshUsersList(data);
                        break;
                    }

                case 5:
                    {
                        hide_components(false, true);
                        cbHelper.SelectedIndex = 0;
                        is_number = false;
                        _RefreshUsersList(data);
                        break;
                    }

              
            }
        }

        private void cbHelper_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int option = -1;
            DataTable data;
            if (cbHelper.SelectedItem.ToString().Equals("all"))
            {
                 data = clsUser.GetAllUsers();             
            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsUser.filters_By[filter_value];
                option = cbHelper.SelectedIndex == 1 ? 1 : 0;
                data = clsUser.filter(query, option);
            }


            
            _RefreshUsersList(data);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                DataTable data = clsUser.GetAllUsers();
                _RefreshUsersList(data);

            }
            else
            {
                string filter_value = cbFilter.SelectedItem.ToString();
                string query = clsUser.filters_By[filter_value];

                if (filter_value.Equals("person_id") || filter_value.Equals("user_id"))
                {

                    DataTable data = clsPerson.filter(query, Convert.ToInt64(txtSearch.Text));                  
                    _RefreshUsersList(data);
                }
                else
                {
                    DataTable data = clsPerson.filter(query, txtSearch.Text.ToString());                   
                    _RefreshUsersList(data);
                }
            }
        }

        

        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvUser.Rows[e.RowIndex].IsNewRow)
            {
                clickedRowIndex = e.RowIndex;
                dgvUser.ClearSelection();
                dgvUser.Rows[e.RowIndex].Selected = true;

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

        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            CUScreen screen = new CUScreen(-1);
            screen.ShowDialog();
            if (!CUScreen.isMatch)
            {
                DataTable data = clsUser.GetAllUsers();
                _RefreshUsersList(data);
            }

            CUScreen.isMatch = true;
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("send email feature is stap (.-.)", "Note", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("phone call feature is stap (.-.)", "Note", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CUScreen screen = new CUScreen(-1);
            screen.ShowDialog();
            if (!CUScreen.isMatch)
            {
                DataTable data = clsUser.GetAllUsers();
                _RefreshUsersList(data);
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

            int user_id = Convert.ToInt32(dgvUser.Rows[clickedRowIndex].Cells["user_id"].Value);

            CUScreen screen = new CUScreen(user_id);
            screen.ShowDialog();

            if (!CUScreen.isMatch)
            {
                DataTable data = clsUser.GetAllUsers();
                _RefreshUsersList(data);
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


            if (MessageBox.Show("Are you sure you want to delete user [" + (dgvUser.CurrentRow.Cells[0].Value) + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvUser.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    DataTable data = clsUser.GetAllUsers();
                    _RefreshUsersList(data);
                }

                else
                    MessageBox.Show("User is not deleted due to data connected to it.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordScreen screen = new ChangePasswordScreen();
            screen.ShowDialog();
        }

        private void showDeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex < 0)
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            int user_id = Convert.ToInt32(dgvUser.Rows[clickedRowIndex].Cells["user_id"].Value);
            int person_id = Convert.ToInt32(dgvUser.Rows[clickedRowIndex].Cells["person_id"].Value);
            UserDetails details = new UserDetails(person_id,user_id);
            details.ShowDialog();

            if (!CUScreen.isMatch)
            {
                DataTable data = clsUser.GetAllUsers();
                _RefreshUsersList(data);
            }

            CUScreen.isMatch = true;

        }

        
    }
}
