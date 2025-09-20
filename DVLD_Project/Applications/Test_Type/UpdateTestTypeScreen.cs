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

namespace DVLD_Project.Manage_Application.Test_Type
{
    public partial class UpdateTestTypeScreen : Form
    {

        private int test_type_id;
        public UpdateTestTypeScreen(int test_type_id)
        {
            InitializeComponent();
            this.test_type_id = test_type_id;
        }

        public static bool is_Match = true;
        clsTestType _old_test_type;
        clsTestType _new_test_type;


        private void LoadData()
        {
            clsTestType test = clsTestType.Find(test_type_id);
            lbID.Text = test.id.ToString();
            txtDescriotion.Text = test.description;
            txtTitle.Text = test.title.ToString();
            txtFees.Text = test.fees.ToString();

            _old_test_type = clsTestType.Find(test_type_id);
            _new_test_type = clsTestType.Find(test_type_id);
        }
        private void UpdateTestTypeScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            is_Match = Match.AreObjectsEqual(_old_test_type, _new_test_type);

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _new_test_type.title = txtTitle.Text;
            _new_test_type.description = txtDescriotion.Text;
            _new_test_type.fees = Convert.ToDecimal(txtFees.Text);


            if (_new_test_type.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            is_Match = Match.AreObjectsEqual(_old_test_type, _new_test_type);
        }
    }
}
