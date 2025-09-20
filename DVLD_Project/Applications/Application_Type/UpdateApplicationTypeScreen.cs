using DVLD_Busness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Application_M
{
    public partial class UpdateApplicationTypeScreen : Form
    {

        private int application_type_id;
        public UpdateApplicationTypeScreen(int application_type_id)
        {
            InitializeComponent();
            this.application_type_id = application_type_id;
        }

        public static bool is_Match = true;
        clsApplicationType _old_application_type;
        clsApplicationType _new_application_type;
        private void btnClose_Click(object sender, EventArgs e)
        {
            is_Match = Match.AreObjectsEqual(_old_application_type, _new_application_type);

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _new_application_type.title = txtTitle.Text;
            _new_application_type.fees = Convert.ToDecimal(txtFees.Text);


            if(_new_application_type.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            is_Match = Match.AreObjectsEqual(_old_application_type, _new_application_type);

        }

        private void LoadData()
        {
            clsApplicationType application = clsApplicationType.Find(application_type_id);
            lbID.Text = application.id.ToString();
            txtTitle.Text = application.title.ToString();
            txtFees.Text = application.fees.ToString();

            _old_application_type = clsApplicationType.Find(application_type_id);
            _new_application_type = clsApplicationType.Find(application_type_id);
        }
        private void UpdateApplicationTypeScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
