namespace DVLD_Project.Applications.Manage_Applecation
{
    partial class AddNewInternationalLicense
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbProccess = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssue = new Guna.UI2.WinForms.Guna2GradientButton();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.LLLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.applicationInfo2 = new DVLD_Project.Controls.ApplicationInfo();
            this.driverLicenseInfoWithFilter1 = new DVLD_Project.Controls.DriverLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lbProccess
            // 
            this.lbProccess.AutoSize = true;
            this.lbProccess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProccess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbProccess.Location = new System.Drawing.Point(409, 37);
            this.lbProccess.Name = "lbProccess";
            this.lbProccess.Size = new System.Drawing.Size(498, 34);
            this.lbProccess.TabIndex = 32;
            this.lbProccess.Text = "International License Application";
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BorderRadius = 20;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.close;
            this.btnClose.ImageSize = new System.Drawing.Size(40, 40);
            this.btnClose.Location = new System.Drawing.Point(1217, 23);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 33;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Animated = true;
            this.btnIssue.BackColor = System.Drawing.Color.Transparent;
            this.btnIssue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.btnIssue.BorderRadius = 20;
            this.btnIssue.BorderThickness = 2;
            this.btnIssue.CheckedState.Parent = this.btnIssue;
            this.btnIssue.CustomImages.Parent = this.btnIssue;
            this.btnIssue.Enabled = false;
            this.btnIssue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.btnIssue.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.btnIssue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.White;
            this.btnIssue.HoverState.Parent = this.btnIssue;
            this.btnIssue.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIssue.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnIssue.Location = new System.Drawing.Point(1025, 966);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.ShadowDecoration.BorderRadius = 25;
            this.btnIssue.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.btnIssue.ShadowDecoration.Enabled = true;
            this.btnIssue.ShadowDecoration.Parent = this.btnIssue;
            this.btnIssue.Size = new System.Drawing.Size(168, 53);
            this.btnIssue.TabIndex = 105;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseTransparentBackground = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // llLicenseHistory
            // 
            this.llLicenseHistory.AutoSize = true;
            this.llLicenseHistory.Enabled = false;
            this.llLicenseHistory.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llLicenseHistory.LinkColor = System.Drawing.Color.Red;
            this.llLicenseHistory.Location = new System.Drawing.Point(108, 980);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(219, 23);
            this.llLicenseHistory.TabIndex = 106;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // LLLicenseInfo
            // 
            this.LLLicenseInfo.AutoSize = true;
            this.LLLicenseInfo.Enabled = false;
            this.LLLicenseInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLLicenseInfo.LinkColor = System.Drawing.Color.Red;
            this.LLLicenseInfo.Location = new System.Drawing.Point(374, 980);
            this.LLLicenseInfo.Name = "LLLicenseInfo";
            this.LLLicenseInfo.Size = new System.Drawing.Size(186, 23);
            this.LLLicenseInfo.TabIndex = 107;
            this.LLLicenseInfo.TabStop = true;
            this.LLLicenseInfo.Text = "Show License Info";
            this.LLLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLLicenseInfo_LinkClicked);
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 40;
            // 
            // applicationInfo2
            // 
            this.applicationInfo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.applicationInfo2.Location = new System.Drawing.Point(81, 702);
            this.applicationInfo2.Name = "applicationInfo2";
            this.applicationInfo2.Size = new System.Drawing.Size(1156, 246);
            this.applicationInfo2.TabIndex = 108;
            // 
            // driverLicenseInfoWithFilter1
            // 
            this.driverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.driverLicenseInfoWithFilter1.Location = new System.Drawing.Point(81, 101);
            this.driverLicenseInfoWithFilter1.Name = "driverLicenseInfoWithFilter1";
            this.driverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1157, 617);
            this.driverLicenseInfoWithFilter1.TabIndex = 34;
            // 
            // AddNewInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1314, 1049);
            this.Controls.Add(this.applicationInfo2);
            this.Controls.Add(this.LLLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.driverLicenseInfoWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbProccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewInternationalLicense";
            this.Load += new System.EventHandler(this.AddNewInternationalLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lbProccess;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Controls.ApplicationInfo applicationInfo1;
        private Controls.DriverLicenseInfoWithFilter driverLicenseInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientButton btnIssue;
        private System.Windows.Forms.LinkLabel LLLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
        private Controls.ApplicationInfo applicationInfo2;
    }
}