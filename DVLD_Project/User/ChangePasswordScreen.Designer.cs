namespace DVLD_Project.User
{
    partial class ChangePasswordScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbCu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEyeForCurrent = new Guna.UI2.WinForms.Guna2CircleButton();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEyeForNew = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnEyeForConfirm = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2GradientButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.userInfo1 = new DVLD_Project.UserInfo();
            this.personInfo1 = new DVLD_Project.PersonInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(1003, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 4;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(355, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "Change Password";
            // 
            // lbCu
            // 
            this.lbCu.AutoSize = true;
            this.lbCu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCu.ForeColor = System.Drawing.Color.White;
            this.lbCu.Location = new System.Drawing.Point(43, 696);
            this.lbCu.Name = "lbCu";
            this.lbCu.Size = new System.Drawing.Size(228, 27);
            this.lbCu.TabIndex = 8;
            this.lbCu.Text = "Current Password: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(80, 750);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "New Password: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 805);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 27);
            this.label4.TabIndex = 10;
            this.label4.Text = "Confirme Password: ";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Animated = true;
            this.txtCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentPassword.BorderColor = System.Drawing.Color.White;
            this.txtCurrentPassword.BorderRadius = 15;
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.DefaultText = "";
            this.txtCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.DisabledState.Parent = this.txtCurrentPassword;
            this.txtCurrentPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCurrentPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.txtCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtCurrentPassword.FocusedState.Parent = this.txtCurrentPassword;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.txtCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtCurrentPassword.HoverState.Parent = this.txtCurrentPassword;
            this.txtCurrentPassword.IconLeft = global::DVLD_Project.Properties.Resources.padlock;
            this.txtCurrentPassword.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtCurrentPassword.Location = new System.Drawing.Point(298, 691);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '\0';
            this.txtCurrentPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtCurrentPassword.PlaceholderText = "Current Password...";
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.ShadowDecoration.BorderRadius = 26;
            this.txtCurrentPassword.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.txtCurrentPassword.ShadowDecoration.Parent = this.txtCurrentPassword;
            this.txtCurrentPassword.Size = new System.Drawing.Size(270, 36);
            this.txtCurrentPassword.TabIndex = 0;
            this.txtCurrentPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            this.txtCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPassword_Validating);
            // 
            // btnEyeForCurrent
            // 
            this.btnEyeForCurrent.Animated = true;
            this.btnEyeForCurrent.BackColor = System.Drawing.Color.Transparent;
            this.btnEyeForCurrent.BackgroundImage = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEyeForCurrent.BorderRadius = 20;
            this.btnEyeForCurrent.CheckedState.Parent = this.btnEyeForCurrent;
            this.btnEyeForCurrent.CustomImages.Parent = this.btnEyeForCurrent;
            this.btnEyeForCurrent.FillColor = System.Drawing.Color.Transparent;
            this.btnEyeForCurrent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeForCurrent.ForeColor = System.Drawing.Color.White;
            this.btnEyeForCurrent.HoverState.Parent = this.btnEyeForCurrent;
            this.btnEyeForCurrent.Image = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForCurrent.ImageSize = new System.Drawing.Size(10, 10);
            this.btnEyeForCurrent.Location = new System.Drawing.Point(531, 699);
            this.btnEyeForCurrent.Name = "btnEyeForCurrent";
            this.btnEyeForCurrent.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeForCurrent.ShadowDecoration.Parent = this.btnEyeForCurrent;
            this.btnEyeForCurrent.Size = new System.Drawing.Size(26, 22);
            this.btnEyeForCurrent.TabIndex = 23;
            this.btnEyeForCurrent.Tag = "Closed";
            this.btnEyeForCurrent.UseTransparentBackground = true;
            this.btnEyeForCurrent.Click += new System.EventHandler(this.btnEyeForCurrent_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Animated = true;
            this.txtNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassword.BorderColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderRadius = 15;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.DisabledState.Parent = this.txtNewPassword;
            this.txtNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtNewPassword.FocusedState.Parent = this.txtNewPassword;
            this.txtNewPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtNewPassword.HoverState.Parent = this.txtNewPassword;
            this.txtNewPassword.IconLeft = global::DVLD_Project.Properties.Resources.padlock;
            this.txtNewPassword.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtNewPassword.Location = new System.Drawing.Point(298, 746);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '\0';
            this.txtNewPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNewPassword.PlaceholderText = "New Password...";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.ShadowDecoration.BorderRadius = 26;
            this.txtNewPassword.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.txtNewPassword.ShadowDecoration.Parent = this.txtNewPassword;
            this.txtNewPassword.Size = new System.Drawing.Size(270, 36);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Animated = true;
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderRadius = 15;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtConfirmPassword.FocusedState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtConfirmPassword.HoverState.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.IconLeft = global::DVLD_Project.Properties.Resources.padlock;
            this.txtConfirmPassword.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtConfirmPassword.Location = new System.Drawing.Point(298, 800);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '\0';
            this.txtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtConfirmPassword.PlaceholderText = "Confirm Password...";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.ShadowDecoration.BorderRadius = 26;
            this.txtConfirmPassword.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.txtConfirmPassword.ShadowDecoration.Parent = this.txtConfirmPassword;
            this.txtConfirmPassword.Size = new System.Drawing.Size(270, 36);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // btnEyeForNew
            // 
            this.btnEyeForNew.Animated = true;
            this.btnEyeForNew.BackColor = System.Drawing.Color.Transparent;
            this.btnEyeForNew.BackgroundImage = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEyeForNew.BorderRadius = 20;
            this.btnEyeForNew.CheckedState.Parent = this.btnEyeForNew;
            this.btnEyeForNew.CustomImages.Parent = this.btnEyeForNew;
            this.btnEyeForNew.FillColor = System.Drawing.Color.Transparent;
            this.btnEyeForNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeForNew.ForeColor = System.Drawing.Color.White;
            this.btnEyeForNew.HoverState.Parent = this.btnEyeForNew;
            this.btnEyeForNew.Image = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForNew.ImageSize = new System.Drawing.Size(10, 10);
            this.btnEyeForNew.Location = new System.Drawing.Point(531, 753);
            this.btnEyeForNew.Name = "btnEyeForNew";
            this.btnEyeForNew.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeForNew.ShadowDecoration.Parent = this.btnEyeForNew;
            this.btnEyeForNew.Size = new System.Drawing.Size(26, 22);
            this.btnEyeForNew.TabIndex = 26;
            this.btnEyeForNew.Tag = "Closed";
            this.btnEyeForNew.UseTransparentBackground = true;
            this.btnEyeForNew.Click += new System.EventHandler(this.btnEyeForNew_Click);
            // 
            // btnEyeForConfirm
            // 
            this.btnEyeForConfirm.Animated = true;
            this.btnEyeForConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnEyeForConfirm.BackgroundImage = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEyeForConfirm.BorderRadius = 20;
            this.btnEyeForConfirm.CheckedState.Parent = this.btnEyeForConfirm;
            this.btnEyeForConfirm.CustomImages.Parent = this.btnEyeForConfirm;
            this.btnEyeForConfirm.FillColor = System.Drawing.Color.Transparent;
            this.btnEyeForConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeForConfirm.ForeColor = System.Drawing.Color.White;
            this.btnEyeForConfirm.HoverState.Parent = this.btnEyeForConfirm;
            this.btnEyeForConfirm.Image = global::DVLD_Project.Properties.Resources.eye;
            this.btnEyeForConfirm.ImageSize = new System.Drawing.Size(10, 10);
            this.btnEyeForConfirm.Location = new System.Drawing.Point(531, 806);
            this.btnEyeForConfirm.Name = "btnEyeForConfirm";
            this.btnEyeForConfirm.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeForConfirm.ShadowDecoration.Parent = this.btnEyeForConfirm;
            this.btnEyeForConfirm.Size = new System.Drawing.Size(26, 22);
            this.btnEyeForConfirm.TabIndex = 27;
            this.btnEyeForConfirm.Tag = "Closed";
            this.btnEyeForConfirm.UseTransparentBackground = true;
            this.btnEyeForConfirm.Click += new System.EventHandler(this.btnEyeForConfirm_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Animated = true;
            this.btnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.btnChangePassword.BorderRadius = 20;
            this.btnChangePassword.BorderThickness = 2;
            this.btnChangePassword.CheckedState.Parent = this.btnChangePassword;
            this.btnChangePassword.CustomImages.Parent = this.btnChangePassword;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.btnChangePassword.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.HoverState.Parent = this.btnChangePassword;
            this.btnChangePassword.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChangePassword.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnChangePassword.Location = new System.Drawing.Point(918, 783);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ShadowDecoration.BorderRadius = 25;
            this.btnChangePassword.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.btnChangePassword.ShadowDecoration.Enabled = true;
            this.btnChangePassword.ShadowDecoration.Parent = this.btnChangePassword;
            this.btnChangePassword.Size = new System.Drawing.Size(150, 53);
            this.btnChangePassword.TabIndex = 28;
            this.btnChangePassword.Text = "Save";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // userInfo1
            // 
            this.userInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.userInfo1.Location = new System.Drawing.Point(25, 516);
            this.userInfo1.Name = "userInfo1";
            this.userInfo1.Size = new System.Drawing.Size(1043, 141);
            this.userInfo1.TabIndex = 6;
            // 
            // personInfo1
            // 
            this.personInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.personInfo1.Location = new System.Drawing.Point(25, 76);
            this.personInfo1.Name = "personInfo1";
            this.personInfo1.Size = new System.Drawing.Size(1043, 428);
            this.personInfo1.TabIndex = 5;
            // 
            // ChangePasswordScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1090, 872);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnEyeForConfirm);
            this.Controls.Add(this.btnEyeForNew);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.btnEyeForCurrent);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userInfo1);
            this.Controls.Add(this.personInfo1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordScreen";
            this.Load += new System.EventHandler(this.ChangePasswordScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private UserInfo userInfo1;
        private PersonInfo personInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lbCu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeForCurrent;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeForConfirm;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeForNew;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnChangePassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}