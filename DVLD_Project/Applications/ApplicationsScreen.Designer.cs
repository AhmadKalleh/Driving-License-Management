namespace DVLD_Project.Application
{
    partial class ApplicationsScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelScreenToApplications = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.panelScreenToApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "Applications";
            // 
            // panelScreenToApplications
            // 
            this.panelScreenToApplications.BackColor = System.Drawing.Color.Transparent;
            this.panelScreenToApplications.BorderRadius = 30;
            this.panelScreenToApplications.BorderThickness = 1;
            this.panelScreenToApplications.Controls.Add(this.panelScreen);
            this.panelScreenToApplications.Location = new System.Drawing.Point(12, 12);
            this.panelScreenToApplications.Name = "panelScreenToApplications";
            this.panelScreenToApplications.ShadowDecoration.BorderRadius = 20;
            this.panelScreenToApplications.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.panelScreenToApplications.ShadowDecoration.Parent = this.panelScreenToApplications;
            this.panelScreenToApplications.Size = new System.Drawing.Size(1335, 667);
            this.panelScreenToApplications.TabIndex = 4;
            this.panelScreenToApplications.UseTransparentBackground = true;
            // 
            // panelScreen
            // 
            this.panelScreen.BackColor = System.Drawing.Color.Transparent;
            this.panelScreen.BorderRadius = 30;
            this.panelScreen.BorderThickness = 1;
            this.panelScreen.Location = new System.Drawing.Point(264, 98);
            this.panelScreen.Name = "panelScreen";
            this.panelScreen.ShadowDecoration.BorderRadius = 20;
            this.panelScreen.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.panelScreen.ShadowDecoration.Parent = this.panelScreen;
            this.panelScreen.Size = new System.Drawing.Size(845, 504);
            this.panelScreen.TabIndex = 5;
            this.panelScreen.UseTransparentBackground = true;
            // 
            // ApplicationsTypesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1359, 691);
            this.Controls.Add(this.panelScreenToApplications);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ApplicationsTypesScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "x";
            this.Load += new System.EventHandler(this.ApplicationsTypesScreen_Load);
            this.panelScreenToApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientPanel panelScreenToApplications;
        private Guna.UI2.WinForms.Guna2GradientPanel panelScreen;
    }
}