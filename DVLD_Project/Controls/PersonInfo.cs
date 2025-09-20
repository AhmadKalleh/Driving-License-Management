using DVLD_Busness;
using DVLD_Project.Properties;
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
using DVLD_Project.Person;
namespace DVLD_Project
{
    public partial class PersonInfo : UserControl
    {

        public int person_id;
        public PersonInfo()
        {
            InitializeComponent();
            
        }

        public void change_backgroudColor(int r = 51 , int g = 10, int b = 48)
        {
            this.BackColor = Color.FromArgb(r, g, b);   
        }
        
        
        public void LoadPersonalInfo(int person_id)
        {
            
            clsPerson person = clsPerson.Find(person_id);
            Image img;


            if (person == null)
            {
                img = null;
                pbProfileImage.BackgroundImage = img;
                txtPersonId.Text = "???";
                txtNationalNumber.Text = "???";
                txtFullName.Text = "???";
                txtDateOfBirth.Text = "???";
                txtGendor.Text = "???";
                txtAddress.Text = "???";
                txtPhone.Text = "???";
                txtEmail.Text = "???";
                txtNationality.Text = "???";
                MessageBox.Show("No Person with PersonID: " + person_id,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.person_id = -1;
                return;
            }



            if (File.Exists(person.image_path))
            {
                using (FileStream fs = new FileStream(person.image_path, FileMode.Open, FileAccess.Read))
                {
                    img = new Bitmap(Image.FromStream(fs)); // تحميل نسخة فقط دون قفل الملف
                }
            }
            else
            {
                img = (person.gendor == 0) ? Resources.man : Resources.woman;
            }

            this.person_id = person.id;
            pbProfileImage.BackgroundImage = img;
            txtPersonId.Text = "Person ID: " + person.id;
            txtNationalNumber.Text = "National No: " + person.national_number;
            txtFullName.Text = "Full Name: " + person.FullName();
            txtDateOfBirth.Text = "Date Of Birth: " + person.date_of_birht;
            txtGendor.Text = (person.gendor == 0 ? "Male" : "Female");
            txtAddress.Text = person.address;
            txtPhone.Text = person.phone;
            txtEmail.Text = person.email;
            txtNationality.Text = clsCountry.Find(person.country_id).country_name;
        }

        public void LoadPersonalInfo(string national_number)
        {
            clsPerson person = clsPerson.Find(national_number);
            Image img;


            if (person == null)
            {
                img = null;
                pbProfileImage.BackgroundImage = img;
                txtPersonId.Text = "???";
                txtNationalNumber.Text = "???";
                txtFullName.Text = "???" ;
                txtDateOfBirth.Text = "???";
                txtGendor.Text = "???";
                txtAddress.Text = "???";
                txtPhone.Text = "???";
                txtEmail.Text = "???";
                txtNationality.Text = "???";
                MessageBox.Show("No Person with National Number: " + national_number, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.person_id = -1;
                return;
            }



            if (File.Exists(person.image_path))
            {
                using (FileStream fs = new FileStream(person.image_path, FileMode.Open, FileAccess.Read))
                {
                    img = new Bitmap(Image.FromStream(fs)); // تحميل نسخة فقط دون قفل الملف
                }
            }
            else
            {
                img = (person.gendor == 0) ? Resources.man : Resources.woman;
            }

            this.person_id = person.id;
            pbProfileImage.BackgroundImage = img;
            txtPersonId.Text = "Person ID: " + person.id;
            txtNationalNumber.Text = "National No: " + person.national_number;
            txtFullName.Text = "Full Name: " + person.FullName();
            txtDateOfBirth.Text = "Date Of Birth: " + person.date_of_birht;
            txtGendor.Text = (person.gendor == 0 ? "Male" : "Female");
            txtAddress.Text = person.address;
            txtPhone.Text = person.phone;
            txtEmail.Text = person.email;
            txtNationality.Text = clsCountry.Find(person.country_id).country_name;
        }
        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CUScreen screen = new CUScreen(person_id);
            screen.ShowDialog();
        
        }

        
    }
}
