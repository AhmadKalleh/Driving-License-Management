using DVLD_Busness;
using DVLD_Project.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Services
{
    public partial class ReplacementForDamagedOrLostLicense : Form
    {
        private int _oldLicenseId = -1;
        private int _driverId = -1;
        private clsLicense _newLicense;
        private clsLicense _oldLicense;
        private clsApplication _newApplication;

        private readonly string DAMAGED = "Replacement For Damaged License";
        private readonly string LOST = "Replacement For Lost License";
        private decimal DAMAGED_FEES = -1;
        private decimal LOST_FEES = -1;

        public ReplacementForDamagedOrLostLicense()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            // ربط الحدث من الـ UserControl إلى الفورم
            driverLicenseInfoWithFilter1.OnLicenseFound += DriverLicenseInfoWithFilter1_OnLicenseFound;
            driverLicenseInfoWithFilter1.LicenseFound += UcSearchLicense1_LicenseFound;

            // إذا أردت يمكن ربط حدث Load هنا أو في مصمم الفورم
            this.Load += ReplacementForDamagedOrLostLicense_Load;
        }

        private void ReplacementForDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInitialData();

                // لا تهيئ _oldLicense هنا لأنّه سيُملأ بعد البحث
                _newLicense = new clsLicense();
                _newApplication = new clsApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحميل: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInitialData()
        {
            // اقرأ الرسوم من قاعدة البيانات — افترض أن الدوال ترجع القيم أو تلقِي الاستثناء
            DAMAGED_FEES = clsApplicationType.Find(Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORADAMAGEDRIVINGLICENSE)).fees;
            LOST_FEES = clsApplicationType.Find(Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORALOSTDRIVINGLICENSE)).fees;

            lbAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbCreatedBy.Text = SessionData.currentUser.username;
            lbProccess.Text = DAMAGED;
            rbDamaged.Checked = true;
            lbAppFees.Text = Convert.ToInt32(DAMAGED_FEES).ToString();
        }

        // هذا الحدث يستقبل licenseId و driverId من الـ UserControl
        private void DriverLicenseInfoWithFilter1_OnLicenseFound(int license_id, int driver_id)
        {
            // احفظ المعطيات واطلب تفاصيل الرخصة القديمة
            _oldLicenseId = license_id;
            _driverId = driver_id;



            _oldLicense = clsLicense.FindByLicenseID(_oldLicenseId);
            if (!_oldLicense.is_active)
            {
                MessageBox.Show("This License doesn't active,please choose anthor one", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            if (_oldLicense == null)
            {
                MessageBox.Show("Unable to load selected license details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            lb_OLD_License_ID.Text = _oldLicenseId.ToString();

            // قد ترغب بعرض معلومات إضافية على الفورم هنا
            // e.g. lblDriverName.Text = clsPerson.Find(_oldLicense.person_id)?.FullName ?? "N/A";
        }

        // بعيدة عن التفاصيل — تفعّل زر الإصدار عند العثور العام
        private void UcSearchLicense1_LicenseFound(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ينشئ application جديد ويعيد true لو نجح.
        /// </summary>
        private bool CreateNewApplication()
        {
            if (_oldLicense == null)
            {
                MessageBox.Show("Old license information is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsApplication originalApplication = clsApplication.Find(_oldLicense.application_id);
            if (originalApplication == null)
            {
                MessageBox.Show("Original application not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _newApplication = new clsApplication
            {
                person_id = originalApplication.person_id,
                application_date = DateTime.Now,
                last_status_date = DateTime.Now,
                application_type_id = rbDamaged.Checked
                    ? Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORADAMAGEDRIVINGLICENSE)
                    : Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORALOSTDRIVINGLICENSE),
                application_status = 3,
                paid_fees = clsApplicationType.Find(rbDamaged.Checked
                    ? Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORADAMAGEDRIVINGLICENSE)
                    : Convert.ToInt32(clsApplicationType.enApplicationType.REPLACEMENTFORALOSTDRIVINGLICENSE)).fees,
                created_by_user_id = SessionData.currentUser.id
            };

            try
            {
                bool saved = _newApplication.Save();
                if (!saved)
                {
                    MessageBox.Show("Failed to create application record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return saved;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// يجهّز كائن الرخصة الجديدة ويحفظها، يعيد true لو نجح.
        /// </summary>
        private bool CreateNewLicense()
        {
            if (_oldLicense == null || _newApplication == null) return false;

            try
            {
                _newLicense = new clsLicense
                {
                    application_id = _newApplication.id,
                    driver_id = _driverId,
                    license_class_id = _oldLicense.license_class_id,
                    issue_date = DateTime.Now,
                    expiration_date = DateTime.Now.AddYears(clsLicenseClass.Find(_oldLicense.license_class_id).default_validity_length),
                    notes = string.Empty,
                    paid_fees = clsLicenseClass.Find(_oldLicense.license_class_id).class_fees,
                    is_active = true,
                    issue_reason = rbDamaged.Checked
                        ? Convert.ToByte(clsLicense.enIssueReason.REPLACEMENT_FOR_DAMAGED)
                        : Convert.ToByte(clsLicense.enIssueReason.REPLACEMENT_FOR_LOST),
                    created_by_user_id = SessionData.currentUser.id
                };

                return _newLicense.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving new license: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// يطبق الاستبدال: يحدث حالة الرخصة القديمة ثم يحفظ الجديدة.
        /// نقترح أن يكون هذا كله داخل معاملة (transaction) على مستوى الداتا لييير إذا أمكن.
        /// </summary>
        private void ApplyReplacement()
        {
            // تحقق قبل التنفيذ
            if (_oldLicense == null)
            {
                MessageBox.Show("No selected license to replace.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // تأكيد من المستخدم
            var result = MessageBox.Show("Are you sure you want to replace this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                // 1. أنشئ application جديد
                if (!CreateNewApplication()) return;

                // 2. أغلق / عيّن حالة القديمة إلى غير فعالة
                bool oldUpdated = _oldLicense.UpdateStatus(false);

                // 3. أنشئ و احفظ الرخصة الجديدة
                bool newSaved = CreateNewLicense();

                if (newSaved && oldUpdated)
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PostSaveSuccess();
                }
                else
                {
                    // هنا إذا استطعنا عمل rollback في DataLayer فنعيد العمليات
                    MessageBox.Show("Failed to complete replacement. Please contact admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PostSaveSuccess()
        {
            btnIssueReplacement.Enabled = false;
            driverLicenseInfoWithFilter1.DisabledFilter();

            // عرض النتائج داخل الفورم
            if (_newLicense != null) lb_Replaced_LicesnseID.Text = _newLicense.id.ToString();
            if (_newApplication != null) lb_L_R_ApplicationID.Text = _newApplication.id.ToString();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            ApplyReplacement();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lbProccess.Text = DAMAGED;
            lbAppFees.Text = Convert.ToInt32(DAMAGED_FEES).ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lbProccess.Text = LOST;
            lbAppFees.Text = Convert.ToInt32(LOST_FEES).ToString();
        }
    }
}
