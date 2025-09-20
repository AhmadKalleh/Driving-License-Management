namespace DVLD_Project.Applications.Manage_Applecation
{
    partial class DriverInternationalLicense
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
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.PbTestTypeImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbProccess = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.driverInternationalLicenseInfo1 = new DVLD_Project.Controls.DriverInternationalLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.PbTestTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
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
            this.btnClose.Location = new System.Drawing.Point(1239, 46);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 8;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PbTestTypeImage
            // 
            this.PbTestTypeImage.BackColor = System.Drawing.Color.Transparent;
            this.PbTestTypeImage.BackgroundImage = global::DVLD_Project.Properties.Resources.LicenseView_400;
            this.PbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PbTestTypeImage.Location = new System.Drawing.Point(536, 46);
            this.PbTestTypeImage.Name = "PbTestTypeImage";
            this.PbTestTypeImage.ShadowDecoration.Parent = this.PbTestTypeImage;
            this.PbTestTypeImage.Size = new System.Drawing.Size(236, 158);
            this.PbTestTypeImage.TabIndex = 42;
            this.PbTestTypeImage.TabStop = false;
            this.PbTestTypeImage.UseTransparentBackground = true;
            // 
            // lbProccess
            // 
            this.lbProccess.AutoSize = true;
            this.lbProccess.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProccess.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbProccess.Location = new System.Drawing.Point(381, 207);
            this.lbProccess.Name = "lbProccess";
            this.lbProccess.Size = new System.Drawing.Size(593, 43);
            this.lbProccess.TabIndex = 41;
            this.lbProccess.Text = "Driver International License Info";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImage = global::DVLD_Project.Properties.Resources.International_32;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2PictureBox1.Location = new System.Drawing.Point(551, 59);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(56, 35);
            this.guna2PictureBox1.TabIndex = 43;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // driverInternationalLicenseInfo1
            // 
            this.driverInternationalLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.driverInternationalLicenseInfo1.Location = new System.Drawing.Point(62, 278);
            this.driverInternationalLicenseInfo1.Name = "driverInternationalLicenseInfo1";
            this.driverInternationalLicenseInfo1.Size = new System.Drawing.Size(1208, 405);
            this.driverInternationalLicenseInfo1.TabIndex = 44;
            // 
            // DriverInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1336, 727);
            this.Controls.Add(this.driverInternationalLicenseInfo1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lbProccess);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.PbTestTypeImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DriverInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DriverInternationalLicense";
            this.Load += new System.EventHandler(this.DriverInternationalLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbTestTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox PbTestTypeImage;
        private System.Windows.Forms.Label lbProccess;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Controls.DriverInternationalLicenseInfo driverInternationalLicenseInfo1;
    }
}