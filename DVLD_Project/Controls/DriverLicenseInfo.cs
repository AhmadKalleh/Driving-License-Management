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
    public partial class DriverLicenseInfo : UserControl
    {
        public DriverLicenseInfo()
        {
            InitializeComponent();
        }

        
        public void LoadDriverLicenseInfo(int local_driving_license_application_id)
        {

            // Prepare basic objets info :
            clsLocalDrivingLicenseApplication clsLocal = clsLocalDrivingLicenseApplication.Find(local_driving_license_application_id);
            clsLocal.application = clsApplication.Find(clsLocal.application_id);
            clsLocal.application.perosn_info = clsPerson.Find(clsLocal.application.person_id);
            int driver_id = clsDriver.Find_By_Person_ID(clsLocal.application.person_id);
            clsLicense license = clsLicense.FindByDriverLicenseClassID(driver_id,clsLocal.license_class_id);
            Image img;

            if(license == null)
            {
                MessageBox.Show("License not found, please enter a valid License ID.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // نخرج من الدالة وما نكمل باقي الشروط
            }


            string class_name = clsLicenseClass.Find(clsLocal.license_class_id).name;
            lbLicenseClass.Text = class_name;
            lbFullName.Text = clsLocal.application.perosn_info.FullName();
            lbLicenseID.Text = license.id.ToString();
            lbIsActive.Text = (license.is_active == true) ? "Yes" : "No";
            lbNationalNo.Text = clsLocal.application.perosn_info.national_number.ToString();
            lbDateOfBirth.Text = clsLocal.application.perosn_info.date_of_birht.ToString("yyyy-MM-dd");
            lbGendor.Text = (clsLocal.application.perosn_info.gendor == 0) ? "Male" : "Female";
            cbGendor.Image = (clsLocal.application.perosn_info.gendor == 0) ? Resources.man1 : Resources.woman1;

            if (File.Exists(clsLocal.application.perosn_info.image_path))
            {
                using (FileStream fs = new FileStream(clsLocal.application.perosn_info.image_path, FileMode.Open, FileAccess.Read))
                {
                    img = new Bitmap(Image.FromStream(fs)); // تحميل نسخة فقط دون قفل الملف
                }
            }
            else
            {
                img = (clsLocal.application.perosn_info.gendor == 0) ? Resources.man1 : Resources.woman1;
            }

            pbProfileImage.BackgroundImage = img;

            lbDriverID.Text = driver_id.ToString();
            lbIssueDate.Text = license.issue_date.ToString("yyyy-MM-dd");
            lbExpirationDate.Text = license.expiration_date.ToString("yyyy-MM-dd");

            lbIssueReason.Text = clsLicense.Issue_reason[license.issue_reason];

            string status = clsLicense.IsDetainedLicense(license.id);
            if(status == "No_Detained")
            {
                lbIsDetained.Text = "No";
            }
            else if(status == "Detained_Not_Released")
            {
                lbIsDetained.Text = "Yes";
            }
            else if (status == "Detained_Released")
            {
                lbIsDetained.Text = "No";
            }
             
            lbNote.Text = license.notes;
        }
    }
}
