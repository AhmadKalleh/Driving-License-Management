namespace DVLD_Project.Applications.Manage_Applecation
{
    partial class DriverLicense
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
            this.PbTestTypeImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.driverLicenseInfo1 = new DVLD_Project.Controls.DriverLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.PbTestTypeImage)).BeginInit();
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
            this.lbProccess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProccess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbProccess.Location = new System.Drawing.Point(478, 170);
            this.lbProccess.Name = "lbProccess";
            this.lbProccess.Size = new System.Drawing.Size(356, 43);
            this.lbProccess.TabIndex = 8;
            this.lbProccess.Text = "Driver License Info";
            // 
            // PbTestTypeImage
            // 
            this.PbTestTypeImage.BackColor = System.Drawing.Color.Transparent;
            this.PbTestTypeImage.BackgroundImage = global::DVLD_Project.Properties.Resources.LicenseView_400;
            this.PbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbTestTypeImage.Location = new System.Drawing.Point(532, 12);
            this.PbTestTypeImage.Name = "PbTestTypeImage";
            this.PbTestTypeImage.ShadowDecoration.Parent = this.PbTestTypeImage;
            this.PbTestTypeImage.Size = new System.Drawing.Size(236, 158);
            this.PbTestTypeImage.TabIndex = 40;
            this.PbTestTypeImage.TabStop = false;
            this.PbTestTypeImage.UseTransparentBackground = true;
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
            this.btnClose.Location = new System.Drawing.Point(1246, 40);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 7;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // driverLicenseInfo1
            // 
            this.driverLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.driverLicenseInfo1.Location = new System.Drawing.Point(93, 235);
            this.driverLicenseInfo1.Name = "driverLicenseInfo1";
            this.driverLicenseInfo1.Size = new System.Drawing.Size(1146, 524);
            this.driverLicenseInfo1.TabIndex = 41;
            // 
            // DriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1336, 788);
            this.Controls.Add(this.driverLicenseInfo1);
            this.Controls.Add(this.PbTestTypeImage);
            this.Controls.Add(this.lbProccess);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriverLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriverLicense";
            this.Load += new System.EventHandler(this.DriverLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbTestTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbProccess;
        private Guna.UI2.WinForms.Guna2PictureBox PbTestTypeImage;
        private Controls.DriverLicenseInfo driverLicenseInfo1;
    }
}