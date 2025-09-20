namespace DVLD_Project.Applications.Services
{
    partial class RenewDrivingLicenseScreen
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
            this.LLLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lbProccess = new System.Windows.Forms.Label();
            this.applicationNewLicenseInfo1 = new DVLD_Project.Controls.ApplicationNewLicenseInfo();
            this.driverLicenseInfoWithFilter1 = new DVLD_Project.Controls.DriverLicenseInfoWithFilter();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // LLLicenseInfo
            // 
            this.LLLicenseInfo.AutoSize = true;
            this.LLLicenseInfo.Enabled = false;
            this.LLLicenseInfo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLLicenseInfo.LinkColor = System.Drawing.Color.Red;
            this.LLLicenseInfo.Location = new System.Drawing.Point(343, 1001);
            this.LLLicenseInfo.Name = "LLLicenseInfo";
            this.LLLicenseInfo.Size = new System.Drawing.Size(234, 23);
            this.LLLicenseInfo.TabIndex = 114;
            this.LLLicenseInfo.TabStop = true;
            this.LLLicenseInfo.Text = "Show New License Info";
            this.LLLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLLicenseInfo_LinkClicked);
            // 
            // llLicenseHistory
            // 
            this.llLicenseHistory.AutoSize = true;
            this.llLicenseHistory.Enabled = false;
            this.llLicenseHistory.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llLicenseHistory.LinkColor = System.Drawing.Color.Red;
            this.llLicenseHistory.Location = new System.Drawing.Point(77, 1001);
            this.llLicenseHistory.Name = "llLicenseHistory";
            this.llLicenseHistory.Size = new System.Drawing.Size(219, 23);
            this.llLicenseHistory.TabIndex = 113;
            this.llLicenseHistory.TabStop = true;
            this.llLicenseHistory.Text = "Show License History";
            this.llLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLicenseHistory_LinkClicked);
            // 
            // btnRenew
            // 
            this.btnRenew.Animated = true;
            this.btnRenew.BackColor = System.Drawing.Color.Transparent;
            this.btnRenew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.btnRenew.BorderRadius = 20;
            this.btnRenew.BorderThickness = 2;
            this.btnRenew.CheckedState.Parent = this.btnRenew;
            this.btnRenew.CustomImages.Parent = this.btnRenew;
            this.btnRenew.Enabled = false;
            this.btnRenew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.btnRenew.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.btnRenew.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.HoverState.Parent = this.btnRenew;
            this.btnRenew.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRenew.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnRenew.Location = new System.Drawing.Point(1070, 986);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.ShadowDecoration.BorderRadius = 25;
            this.btnRenew.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.btnRenew.ShadowDecoration.Enabled = true;
            this.btnRenew.ShadowDecoration.Parent = this.btnRenew;
            this.btnRenew.Size = new System.Drawing.Size(168, 53);
            this.btnRenew.TabIndex = 112;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseTransparentBackground = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
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
            this.btnClose.Location = new System.Drawing.Point(1244, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 110;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbProccess
            // 
            this.lbProccess.AutoSize = true;
            this.lbProccess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProccess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbProccess.Location = new System.Drawing.Point(390, 26);
            this.lbProccess.Name = "lbProccess";
            this.lbProccess.Size = new System.Drawing.Size(412, 34);
            this.lbProccess.TabIndex = 109;
            this.lbProccess.Text = "Renew License Application";
            // 
            // applicationNewLicenseInfo1
            // 
            this.applicationNewLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.applicationNewLicenseInfo1.Location = new System.Drawing.Point(81, 628);
            this.applicationNewLicenseInfo1.Name = "applicationNewLicenseInfo1";
            this.applicationNewLicenseInfo1.Size = new System.Drawing.Size(1157, 352);
            this.applicationNewLicenseInfo1.TabIndex = 115;
            // 
            // driverLicenseInfoWithFilter1
            // 
            this.driverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.driverLicenseInfoWithFilter1.Location = new System.Drawing.Point(81, 63);
            this.driverLicenseInfoWithFilter1.Name = "driverLicenseInfoWithFilter1";
            this.driverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1157, 617);
            this.driverLicenseInfoWithFilter1.TabIndex = 111;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 40;
            this.guna2Elipse2.TargetControl = this.applicationNewLicenseInfo1;
            // 
            // RenewDrivingLicenseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1314, 1067);
            this.Controls.Add(this.applicationNewLicenseInfo1);
            this.Controls.Add(this.driverLicenseInfoWithFilter1);
            this.Controls.Add(this.LLLicenseInfo);
            this.Controls.Add(this.llLicenseHistory);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbProccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RenewDrivingLicenseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RenewDrivingLicenseScreen";
            this.Load += new System.EventHandler(this.RenewDrivingLicenseScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.DriverLicenseInfoWithFilter driverLicenseInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.LinkLabel LLLicenseInfo;
        private System.Windows.Forms.LinkLabel llLicenseHistory;
        private Guna.UI2.WinForms.Guna2GradientButton btnRenew;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbProccess;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Controls.ApplicationNewLicenseInfo applicationNewLicenseInfo1;
    }
}