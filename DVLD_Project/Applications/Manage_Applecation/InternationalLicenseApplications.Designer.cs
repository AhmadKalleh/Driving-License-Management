namespace DVLD_Project.Applications.Manage_Applecation
{
    partial class InternationalLicenseApplications
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbHelper = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dgvInterNationalLicenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Int_License_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.App_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_License_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issue_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expiration_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnBack = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnAddNewLicense = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterNationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbHelper
            // 
            this.cbHelper.Animated = true;
            this.cbHelper.BackColor = System.Drawing.Color.Transparent;
            this.cbHelper.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.cbHelper.BorderRadius = 15;
            this.cbHelper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHelper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHelper.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.cbHelper.FocusedColor = System.Drawing.Color.Empty;
            this.cbHelper.FocusedState.Parent = this.cbHelper;
            this.cbHelper.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHelper.ForeColor = System.Drawing.Color.White;
            this.cbHelper.FormattingEnabled = true;
            this.cbHelper.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.cbHelper.HoverState.Parent = this.cbHelper;
            this.cbHelper.ItemHeight = 30;
            this.cbHelper.Items.AddRange(new object[] {
            "All",
            "Active",
            "In Active"});
            this.cbHelper.ItemsAppearance.Parent = this.cbHelper;
            this.cbHelper.Location = new System.Drawing.Point(492, 279);
            this.cbHelper.Name = "cbHelper";
            this.cbHelper.ShadowDecoration.Parent = this.cbHelper;
            this.cbHelper.Size = new System.Drawing.Size(237, 36);
            this.cbHelper.TabIndex = 50;
            this.cbHelper.TextOffset = new System.Drawing.Point(3, 0);
            this.cbHelper.SelectedIndexChanged += new System.EventHandler(this.cbHelper_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.White;
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(20, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtSearch.Location = new System.Drawing.Point(509, 279);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtSearch.PlaceholderText = "Search...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 26;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.Empty;
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(249, 36);
            this.txtSearch.TabIndex = 49;
            this.txtSearch.TextOffset = new System.Drawing.Point(20, 0);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 47;
            this.label2.Text = "Filter By:";
            // 
            // cbFilter
            // 
            this.cbFilter.Animated = true;
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.cbFilter.BorderRadius = 15;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(10)))), ((int)(((byte)(48)))));
            this.cbFilter.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilter.FocusedState.Parent = this.cbFilter;
            this.cbFilter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.ForeColor = System.Drawing.Color.White;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.cbFilter.HoverState.Parent = this.cbFilter;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "International License ID",
            "Local License ID",
            "Status"});
            this.cbFilter.ItemsAppearance.Parent = this.cbFilter;
            this.cbFilter.Location = new System.Drawing.Point(211, 279);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.ShadowDecoration.Parent = this.cbFilter;
            this.cbFilter.Size = new System.Drawing.Size(237, 36);
            this.cbFilter.TabIndex = 46;
            this.cbFilter.TextOffset = new System.Drawing.Point(3, 0);
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDeatToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(305, 112);
            // 
            // showApplicationDeatToolStripMenuItem
            // 
            this.showApplicationDeatToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showApplicationDeatToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_32;
            this.showApplicationDeatToolStripMenuItem.Name = "showApplicationDeatToolStripMenuItem";
            this.showApplicationDeatToolStripMenuItem.Size = new System.Drawing.Size(304, 36);
            this.showApplicationDeatToolStripMenuItem.Text = "Show Person Details";
            this.showApplicationDeatToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDeatToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.LicenseView_400;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(304, 36);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.guarantee;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(304, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 32);
            this.label1.TabIndex = 43;
            this.label1.Text = "International License Applications";
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 15;
            this.guna2Elipse2.TargetControl = this.contextMenuStrip1;
            // 
            // dgvInterNationalLicenses
            // 
            this.dgvInterNationalLicenses.AllowUserToAddRows = false;
            this.dgvInterNationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInterNationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInterNationalLicenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvInterNationalLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInterNationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterNationalLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.dgvInterNationalLicenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInterNationalLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInterNationalLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInterNationalLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInterNationalLicenses.ColumnHeadersHeight = 22;
            this.dgvInterNationalLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Int_License_ID,
            this.App_ID,
            this.Driver_ID,
            this.L_License_ID,
            this.Issue_Date,
            this.Expiration_Date,
            this.Is_Active});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInterNationalLicenses.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInterNationalLicenses.EnableHeadersVisualStyles = false;
            this.dgvInterNationalLicenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.dgvInterNationalLicenses.Location = new System.Drawing.Point(47, 344);
            this.dgvInterNationalLicenses.MultiSelect = false;
            this.dgvInterNationalLicenses.Name = "dgvInterNationalLicenses";
            this.dgvInterNationalLicenses.ReadOnly = true;
            this.dgvInterNationalLicenses.RowHeadersVisible = false;
            this.dgvInterNationalLicenses.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInterNationalLicenses.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInterNationalLicenses.RowTemplate.DividerHeight = 3;
            this.dgvInterNationalLicenses.RowTemplate.Height = 60;
            this.dgvInterNationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInterNationalLicenses.Size = new System.Drawing.Size(1270, 307);
            this.dgvInterNationalLicenses.TabIndex = 53;
            this.dgvInterNationalLicenses.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvInterNationalLicenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInterNationalLicenses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvInterNationalLicenses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvInterNationalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvInterNationalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvInterNationalLicenses.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.dgvInterNationalLicenses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvInterNationalLicenses.ThemeStyle.HeaderStyle.Height = 22;
            this.dgvInterNationalLicenses.ThemeStyle.ReadOnly = true;
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.Height = 60;
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvInterNationalLicenses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvInterNationalLicenses.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInterNationalLicenses_CellMouseDown);
            // 
            // Int_License_ID
            // 
            this.Int_License_ID.FillWeight = 70F;
            this.Int_License_ID.HeaderText = "Int.License ID";
            this.Int_License_ID.MinimumWidth = 6;
            this.Int_License_ID.Name = "Int_License_ID";
            this.Int_License_ID.ReadOnly = true;
            // 
            // App_ID
            // 
            this.App_ID.FillWeight = 60F;
            this.App_ID.HeaderText = "App ID";
            this.App_ID.MinimumWidth = 6;
            this.App_ID.Name = "App_ID";
            this.App_ID.ReadOnly = true;
            // 
            // Driver_ID
            // 
            this.Driver_ID.FillWeight = 60F;
            this.Driver_ID.HeaderText = "Driver ID";
            this.Driver_ID.MinimumWidth = 6;
            this.Driver_ID.Name = "Driver_ID";
            this.Driver_ID.ReadOnly = true;
            // 
            // L_License_ID
            // 
            this.L_License_ID.FillWeight = 60F;
            this.L_License_ID.HeaderText = "L.License ID";
            this.L_License_ID.MinimumWidth = 6;
            this.L_License_ID.Name = "L_License_ID";
            this.L_License_ID.ReadOnly = true;
            // 
            // Issue_Date
            // 
            this.Issue_Date.HeaderText = "Issue Date";
            this.Issue_Date.MinimumWidth = 6;
            this.Issue_Date.Name = "Issue_Date";
            this.Issue_Date.ReadOnly = true;
            // 
            // Expiration_Date
            // 
            this.Expiration_Date.HeaderText = "Expiration Date";
            this.Expiration_Date.MinimumWidth = 6;
            this.Expiration_Date.Name = "Expiration_Date";
            this.Expiration_Date.ReadOnly = true;
            // 
            // Is_Active
            // 
            this.Is_Active.FillWeight = 60F;
            this.Is_Active.HeaderText = "Is Active";
            this.Is_Active.MinimumWidth = 6;
            this.Is_Active.Name = "Is_Active";
            this.Is_Active.ReadOnly = true;
            this.Is_Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // guna2Elipse3
            // 
            this.guna2Elipse3.BorderRadius = 20;
            this.guna2Elipse3.TargetControl = this.dgvInterNationalLicenses;
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Image = global::DVLD_Project.Properties.Resources.left_arrow;
            this.btnBack.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBack.Location = new System.Drawing.Point(14, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(55, 55);
            this.btnBack.TabIndex = 52;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddNewLicense
            // 
            this.btnAddNewLicense.Animated = true;
            this.btnAddNewLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(7)))), ((int)(((byte)(215)))));
            this.btnAddNewLicense.BorderRadius = 20;
            this.btnAddNewLicense.BorderThickness = 2;
            this.btnAddNewLicense.CheckedState.Parent = this.btnAddNewLicense;
            this.btnAddNewLicense.CustomImages.Parent = this.btnAddNewLicense;
            this.btnAddNewLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.btnAddNewLicense.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.btnAddNewLicense.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLicense.ForeColor = System.Drawing.Color.White;
            this.btnAddNewLicense.HoverState.Parent = this.btnAddNewLicense;
            this.btnAddNewLicense.Image = global::DVLD_Project.Properties.Resources.add;
            this.btnAddNewLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewLicense.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnAddNewLicense.Location = new System.Drawing.Point(1039, 268);
            this.btnAddNewLicense.Name = "btnAddNewLicense";
            this.btnAddNewLicense.ShadowDecoration.BorderRadius = 25;
            this.btnAddNewLicense.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(7)))), ((int)(((byte)(224)))));
            this.btnAddNewLicense.ShadowDecoration.Enabled = true;
            this.btnAddNewLicense.ShadowDecoration.Parent = this.btnAddNewLicense;
            this.btnAddNewLicense.Size = new System.Drawing.Size(278, 53);
            this.btnAddNewLicense.TabIndex = 51;
            this.btnAddNewLicense.Text = "add new License";
            this.btnAddNewLicense.Click += new System.EventHandler(this.btnAddNewLicense_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.BackgroundImage = global::DVLD_Project.Properties.Resources.filter;
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(47, 279);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.ShadowDecoration.Parent = this.guna2CirclePictureBox1;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(32, 33);
            this.guna2CirclePictureBox1.TabIndex = 48;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImage = global::DVLD_Project.Properties.Resources.international;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2PictureBox1.Location = new System.Drawing.Point(594, 64);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(214, 170);
            this.guna2PictureBox1.TabIndex = 44;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // InternationalLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(1)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1359, 691);
            this.Controls.Add(this.dgvInterNationalLicenses);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddNewLicense);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.cbHelper);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InternationalLicenseApplications";
            this.Text = "InternationalLicenseApplications";
            this.Load += new System.EventHandler(this.InternationalLicenseApplications_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterNationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton btnBack;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddNewLicense;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbHelper;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDeatToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInterNationalLicenses;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Int_License_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn App_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_License_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expiration_Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Is_Active;
    }
}