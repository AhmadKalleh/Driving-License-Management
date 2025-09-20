using DVLD_Busness;
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

namespace DVLD_Project.Controls
{
    public partial class DriverInternationalLicenseInfo : UserControl
    {
        public DriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadDriverInternationalLicenseInfo(int int_license_id)
        {
            clsInternationalLicense internationalLicense = clsInternationalLicense.Find(int_license_id);
            clsApplication related_application = clsApplication.Find(internationalLicense.application_id);
            clsPerson related_person = clsPerson.Find(related_application.person_id);
            Image img;

            lbFullName.Text = related_person.FullName();
            lbIntLicenseID.Text = internationalLicense.id.ToString();
            lbApplicationID.Text = related_application.id.ToString();   
            lbLicenseID.Text = internationalLicense.issued_using_local_license_id.ToString();
            lbIsActive.Text = (internationalLicense.is_active == true) ? "Yes" : "No";
            lbNationalNo.Text =related_person.national_number.ToString();
            lbDateOfBirth.Text = related_person.date_of_birht.ToString("yyyy-MM-dd");
            lbGendor.Text = (related_person.gendor == 0) ? "Male" : "Female";
            cbGendor.Image = (related_person.gendor == 0) ? Resources.man1 : Resources.woman1;
            lbDriverID.Text = internationalLicense.driver_id.ToString();
            lbIssueDate.Text = internationalLicense.issue_date.ToString("yyyy-MM-dd");
            lbExpirationDate.Text = internationalLicense.expiration_date.ToString("yyyy-MM-dd");

            if (File.Exists(related_person.image_path))
            {
                using (FileStream fs = new FileStream(related_person.image_path, FileMode.Open, FileAccess.Read))
                {
                    img = new Bitmap(Image.FromStream(fs)); // تحميل نسخة فقط دون قفل الملف
                }
            }
            else
            {
                img = (related_person.gendor == 0) ? Resources.man1 : Resources.woman1;
            }

            pbProfileImage.BackgroundImage = img;
        }
    }
}
