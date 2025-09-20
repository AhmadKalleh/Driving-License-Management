using DVLD_Busness;
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

namespace DVLD_Project
{
    public partial class PersonInfoWithFilter : UserControl
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        private int person_id;
        private bool is_number=false;
        public event Action<int> OnPersonSelected;
        public PersonInfoWithFilter(int person_id, int mode)
        {
            InitializeComponent();
            this.person_id = person_id;
             
            if(mode == 0)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }


        protected virtual void PersonSelected(int person_id)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            {
                handler(person_id);
            }
        }

        
        private void PersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            personInfo1.change_backgroudColor(42, 10, 45);
            cbFilter.SelectedIndex = 0;

            if(_Mode == enMode.Update)
            {
                
                txtSearch.Text = this.person_id.ToString();
                panel.Enabled = false;
                personInfo1.LoadPersonalInfo(this.person_id);

            }
            
        }


        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSearch.Text))
            {
                btnSearch.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                personInfo1.LoadPersonalInfo(txtSearch.Text.ToString());
            }
            else
            {
                personInfo1.LoadPersonalInfo(Convert.ToInt32(txtSearch.Text));
            }    

            if(OnPersonSelected != null)
            {
                OnPersonSelected(personInfo1.person_id);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                is_number = false;
                break;

                case 1:
                is_number = true;
                break;
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


        private void PersonSelectedHandler(int personId)
        {
            cbFilter.SelectedIndex = 1;
            txtSearch.Text = personId.ToString();
            if (OnPersonSelected != null)
            {
                OnPersonSelected(personId);
                personInfo1.LoadPersonalInfo(personId);
            }

        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            CUScreen screen = new CUScreen(-1);
            screen.OnPersonSelected += PersonSelectedHandler;
            screen.ShowDialog();
            
        }
    }
}
