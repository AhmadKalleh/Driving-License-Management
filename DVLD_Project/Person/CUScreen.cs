using DVLD_Busness;
using DVLD_Project.Properties;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Person
{
    public partial class CUScreen : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        public static bool isMatch = true;

        private int _person_id;
        private clsPerson _new_person;
        private clsPerson _old_person;
        private string _currentImagePath = null;
        
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int person_id)
        {
            Action<int> handler = OnPersonSelected;

            if (handler != null)
            {
                handler(person_id);
            }
        }

        public CUScreen(int perosn_id)
        {
            InitializeComponent();

            _person_id = perosn_id;

            if (_person_id == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isMatch = Match.AreObjectsEqual(_old_person, _new_person);

            this.Close();
        }


        private void _FillCountriesInComoboBox()
        {
            List<string> Countries = clsCountry.GetAllCountries();

            for(int i = 0; i < Countries.Count; i++)
            {
                string country = Countries[i];
                cbCountry.Items.Add(country);
            }

            

        }

        private void _LoadData()
        {

            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 168;
            this.BeginInvoke(new Action(() => txtFirstName.Focus()));
            dtpDate.MaxDate = DateTime.Now.AddYears(-18);
            rbMale.Checked = true;
            if (_Mode == enMode.AddNew)
            {
                lbProccess.Text = "Add New Person";
                _new_person = new clsPerson();
                _old_person = new clsPerson();
                isMatch = true;
                return;
            }

            _new_person = clsPerson.Find(_person_id);
            _old_person = clsPerson.Find(_person_id);

            if (_new_person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _person_id);
                this.Close();

                return;
            }

            lbProccess.Text = "Edit Person ID = " + _person_id;
            lbID.Text = _new_person.id.ToString();
            txtFirstName.Text = _new_person.first_name;
            txtSecondName.Text = _new_person.second_name;
            txtThirdName.Text = _new_person.third_name;
            txtEmail.Text = _new_person.email;
            
            if(_new_person.gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            txtLastName.Text = _new_person.last_name;


            txtPhone.Text = _new_person.phone;
            txtAddress.Text = _new_person.address;
            dtpDate.Value = _new_person.date_of_birht;
            txtNationalNumber.Text = _new_person.national_number;

            if (!string.IsNullOrEmpty(_new_person.image_path) && File.Exists(_new_person.image_path))
            {
                using (FileStream fs = new FileStream(_new_person.image_path, FileMode.Open, FileAccess.Read))
                {
                    Image tempImage = Image.FromStream(fs);
                    cpbProfileImage.BackgroundImage = new Bitmap(tempImage); // تحميل نسخة فقط
                }

                _currentImagePath = _new_person.image_path; // خزّن المسار في متغير خاص
            }
            else
            {
                cpbProfileImage.BackgroundImage = Resources.man;
            }


            llRemoveImage.Visible = (_new_person.image_path != "");

            //this will select the country in the combobox.
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_new_person.country_id).country_name);

        }
        private void CUScreen_Load(object sender, EventArgs e)
        {
            _LoadData();
            
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;

                using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                {
                    Image tempImage = Image.FromStream(fs);
                    cpbProfileImage.BackgroundImage = new Bitmap(tempImage);
                }

                _currentImagePath = selectedFilePath; // خزّن المسار بدل استخدام ImageLocation
                llRemoveImage.Visible = true;
                // ...
            }
        }

        

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            cpbProfileImage.BackgroundImage = Resources.man;
            _currentImagePath = null;
            llRemoveImage.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountry.Text).id;



            _new_person.first_name = txtFirstName.Text;
            _new_person.second_name = txtSecondName.Text;
            _new_person.country_id = CountryID;
            _new_person.email = txtEmail.Text;
            _new_person.phone = txtPhone.Text;
            _new_person.third_name = txtThirdName.Text;
            _new_person.last_name = txtLastName.Text;
            _new_person.gendor = (byte)(rbMale.Checked == true ? 0 :1);
            _new_person.national_number = txtNationalNumber.Text;
            _new_person.date_of_birht = dtpDate.Value;
            _new_person.address = txtAddress.Text;

            if (!string.IsNullOrEmpty(_currentImagePath))
                _new_person.image_path = _currentImagePath;
            else
                _new_person.image_path = "";


            

            if (_new_person.Save())
                MessageBox.Show("Data Saved Successfully.","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");


            OnPersonSelected?.Invoke(_new_person.id);
            isMatch = Match.AreObjectsEqual(_old_person, _new_person);
             
            _Mode = enMode.Update;
            lbProccess.Text = "Edit Person ID = " + _new_person.id;
            lbID.Text = _new_person.id.ToString();
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txtNationalNumber.Text))
            {
                e.Cancel = true;
                txtNationalNumber.Focus();
                errorProvider1.SetError(txtNationalNumber, "national number field is requerid");

                
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNumber, "");
                if (clsPerson.Find(txtNationalNumber.Text) != null)
                {
                    e.Cancel = true;
                    txtNationalNumber.Focus();
                    errorProvider1.SetError(txtNationalNumber, "national number is used for another person");
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!txtEmail.Text.Contains("@"))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "invalid email address format");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void show_message_error(Guna2TextBox box, string message, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(box.Text))
            {
                e.Cancel = true;
                box.Focus();
                errorProvider1.SetError(box, message);
            }
            else
            {
                e.Cancel = false; 
                errorProvider1.SetError (box, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "first name field is requerid", e);
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "second name field is requerid", e);            
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "last name field is requerid", e);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "phone field is requerid", e);           
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            show_message_error((Guna2TextBox)sender, "address field is requerid", e);          
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            cpbProfileImage.BackgroundImage = Resources.man;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            cpbProfileImage.BackgroundImage = Resources.woman;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
             {
                    e.Handled = true; // لا نسمح إلا بالأرقام أو الحذف
             }
            
            else
            {

                e.Handled = false;

            }
        }

       
    }
}
