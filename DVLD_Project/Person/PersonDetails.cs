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

namespace DVLD_Project.Person
{
    public partial class PersonDetails : Form
    {

        private int person_id;

        
        public PersonDetails(int person_id)
        {
            InitializeComponent();
            this.person_id = person_id;
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            personInfo1.LoadPersonalInfo(person_id);
        }
        
    }
}
