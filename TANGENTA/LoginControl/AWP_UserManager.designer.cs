namespace LoginControl
{
    partial class AWP_UserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWP_UserManager));
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnChangeData = new System.Windows.Forms.Button();
            this.dgv_LoginUsers = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvx_UserRoles = new System.Windows.Forms.DataGridView();
            this.lbl_UserRoles = new System.Windows.Forms.Label();
            this.dgvx_OtherRoles = new System.Windows.Forms.DataGridView();
            this.lbl_OtherRoles = new System.Windows.Forms.Label();
            this.btn_Edit_myOrganisation_Person = new System.Windows.Forms.Button();
            this.chk_ChangePasswordOnFirstLogIn = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbl_ConfirmPasword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.grp_PasswordExpires = new System.Windows.Forms.GroupBox();
            this.rdb_PaswordExpires_Never = new System.Windows.Forms.RadioButton();
            this.rdb_AfterNumberOfDays = new System.Windows.Forms.RadioButton();
            this.rdb_DeactivateAfterNumberOfDays = new System.Windows.Forms.RadioButton();
            this.lbl_Max_Password_Age = new System.Windows.Forms.Label();
            this.nmUpDn_MaxPasswordAge = new System.Windows.Forms.NumericUpDown();
            this.chk_Enabled = new System.Windows.Forms.CheckBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UserRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_OtherRoles)).BeginInit();
            this.grp_PasswordExpires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnAddUser.Location = new System.Drawing.Point(226, 756);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(172, 42);
            this.btnAddUser.TabIndex = 10;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnAddUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnAddUser_KeyUp);
            // 
            // btnChangeData
            // 
            this.btnChangeData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnChangeData.Location = new System.Drawing.Point(419, 756);
            this.btnChangeData.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeData.Name = "btnChangeData";
            this.btnChangeData.Size = new System.Drawing.Size(172, 42);
            this.btnChangeData.TabIndex = 12;
            this.btnChangeData.Text = "Change Data";
            this.btnChangeData.UseVisualStyleBackColor = true;
            this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
            this.btnChangeData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnChangeData_KeyUp);
            // 
            // dgv_LoginUsers
            // 
            this.dgv_LoginUsers.AllowUserToAddRows = false;
            this.dgv_LoginUsers.AllowUserToDeleteRows = false;
            this.dgv_LoginUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_LoginUsers.DataGridViewWithRowNumber = false;
            this.dgv_LoginUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_LoginUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_LoginUsers.Location = new System.Drawing.Point(0, 0);
            this.dgv_LoginUsers.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_LoginUsers.MultiSelect = false;
            this.dgv_LoginUsers.Name = "dgv_LoginUsers";
            this.dgv_LoginUsers.ReadOnly = true;
            this.dgv_LoginUsers.RowTemplate.Height = 24;
            this.dgv_LoginUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginUsers.Size = new System.Drawing.Size(659, 734);
            this.dgv_LoginUsers.StandardTab = true;
            this.dgv_LoginUsers.TabIndex = 15;
            this.dgv_LoginUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dgv_LoginUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_LoginUsers_DataError);
            this.dgv_LoginUsers.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(4, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Edit_myOrganisation_Person);
            this.splitContainer1.Panel1.Controls.Add(this.chk_ChangePasswordOnFirstLogIn);
            this.splitContainer1.Panel1.Controls.Add(this.txtConfirmPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ConfirmPasword);
            this.splitContainer1.Panel1.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lblPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserName);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer1.Panel1.Controls.Add(this.grp_PasswordExpires);
            this.splitContainer1.Panel1.Controls.Add(this.chk_Enabled);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_LoginUsers);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 734);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 16;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer3.Location = new System.Drawing.Point(3, 229);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.webBrowser1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(552, 502);
            this.splitContainer3.SplitterDistance = 287;
            this.splitContainer3.TabIndex = 117;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(25, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(552, 287);
            this.webBrowser1.TabIndex = 112;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel1.Controls.Add(this.dgvx_UserRoles);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_UserRoles);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_OtherRoles);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_OtherRoles);
            this.splitContainer2.Size = new System.Drawing.Size(552, 211);
            this.splitContainer2.SplitterDistance = 279;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 116;
            // 
            // dgvx_UserRoles
            // 
            this.dgvx_UserRoles.AllowUserToAddRows = false;
            this.dgvx_UserRoles.AllowUserToDeleteRows = false;
            this.dgvx_UserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_UserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_UserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_UserRoles.Location = new System.Drawing.Point(5, 29);
            this.dgvx_UserRoles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvx_UserRoles.Name = "dgvx_UserRoles";
            this.dgvx_UserRoles.ReadOnly = true;
            this.dgvx_UserRoles.Size = new System.Drawing.Size(270, 181);
            this.dgvx_UserRoles.TabIndex = 74;
            // 
            // lbl_UserRoles
            // 
            this.lbl_UserRoles.AutoSize = true;
            this.lbl_UserRoles.Location = new System.Drawing.Point(5, 9);
            this.lbl_UserRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UserRoles.Name = "lbl_UserRoles";
            this.lbl_UserRoles.Size = new System.Drawing.Size(78, 17);
            this.lbl_UserRoles.TabIndex = 73;
            this.lbl_UserRoles.Text = "User Roles";
            // 
            // dgvx_OtherRoles
            // 
            this.dgvx_OtherRoles.AllowUserToAddRows = false;
            this.dgvx_OtherRoles.AllowUserToDeleteRows = false;
            this.dgvx_OtherRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_OtherRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_OtherRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_OtherRoles.Location = new System.Drawing.Point(4, 29);
            this.dgvx_OtherRoles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvx_OtherRoles.Name = "dgvx_OtherRoles";
            this.dgvx_OtherRoles.ReadOnly = true;
            this.dgvx_OtherRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_OtherRoles.Size = new System.Drawing.Size(257, 181);
            this.dgvx_OtherRoles.TabIndex = 75;
            // 
            // lbl_OtherRoles
            // 
            this.lbl_OtherRoles.AutoSize = true;
            this.lbl_OtherRoles.Location = new System.Drawing.Point(6, 9);
            this.lbl_OtherRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_OtherRoles.Name = "lbl_OtherRoles";
            this.lbl_OtherRoles.Size = new System.Drawing.Size(84, 17);
            this.lbl_OtherRoles.TabIndex = 74;
            this.lbl_OtherRoles.Text = "Other Roles";
            // 
            // btn_Edit_myOrganisation_Person
            // 
            this.btn_Edit_myOrganisation_Person.Location = new System.Drawing.Point(10, 186);
            this.btn_Edit_myOrganisation_Person.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Edit_myOrganisation_Person.Name = "btn_Edit_myOrganisation_Person";
            this.btn_Edit_myOrganisation_Person.Size = new System.Drawing.Size(522, 36);
            this.btn_Edit_myOrganisation_Person.TabIndex = 114;
            this.btn_Edit_myOrganisation_Person.Text = "Edit my organisation person";
            this.btn_Edit_myOrganisation_Person.UseVisualStyleBackColor = true;
            this.btn_Edit_myOrganisation_Person.Click += new System.EventHandler(this.btn_Edit_myOrganisation_Person_Click);
            // 
            // chk_ChangePasswordOnFirstLogIn
            // 
            this.chk_ChangePasswordOnFirstLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChangePasswordOnFirstLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_ChangePasswordOnFirstLogIn.Location = new System.Drawing.Point(376, 40);
            this.chk_ChangePasswordOnFirstLogIn.Margin = new System.Windows.Forms.Padding(4);
            this.chk_ChangePasswordOnFirstLogIn.Name = "chk_ChangePasswordOnFirstLogIn";
            this.chk_ChangePasswordOnFirstLogIn.Size = new System.Drawing.Size(158, 62);
            this.chk_ChangePasswordOnFirstLogIn.TabIndex = 72;
            this.chk_ChangePasswordOnFirstLogIn.Text = "Change Password On First LogIn*";
            this.chk_ChangePasswordOnFirstLogIn.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(142, 76);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(222, 22);
            this.txtConfirmPassword.TabIndex = 61;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lbl_ConfirmPasword
            // 
            this.lbl_ConfirmPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConfirmPasword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_ConfirmPasword.Location = new System.Drawing.Point(18, 84);
            this.lbl_ConfirmPasword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ConfirmPasword.Name = "lbl_ConfirmPasword";
            this.lbl_ConfirmPasword.Size = new System.Drawing.Size(118, 16);
            this.lbl_ConfirmPasword.TabIndex = 65;
            this.lbl_ConfirmPasword.Text = "Confirm Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(142, 45);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(222, 22);
            this.txtPassword.TabIndex = 59;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(18, 52);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(118, 16);
            this.lblPassword.TabIndex = 62;
            this.lblPassword.Text = "Password*:";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_UserName.Location = new System.Drawing.Point(6, 16);
            this.lbl_UserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(80, 16);
            this.lbl_UserName.TabIndex = 60;
            this.lbl_UserName.Text = "UserName*:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(142, 9);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(222, 22);
            this.txtUserName.TabIndex = 58;
            // 
            // grp_PasswordExpires
            // 
            this.grp_PasswordExpires.Controls.Add(this.rdb_PaswordExpires_Never);
            this.grp_PasswordExpires.Controls.Add(this.rdb_AfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.rdb_DeactivateAfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.lbl_Max_Password_Age);
            this.grp_PasswordExpires.Controls.Add(this.nmUpDn_MaxPasswordAge);
            this.grp_PasswordExpires.Location = new System.Drawing.Point(12, 110);
            this.grp_PasswordExpires.Margin = new System.Windows.Forms.Padding(4);
            this.grp_PasswordExpires.Name = "grp_PasswordExpires";
            this.grp_PasswordExpires.Padding = new System.Windows.Forms.Padding(4);
            this.grp_PasswordExpires.Size = new System.Drawing.Size(512, 74);
            this.grp_PasswordExpires.TabIndex = 76;
            this.grp_PasswordExpires.TabStop = false;
            this.grp_PasswordExpires.Text = "Password Expires";
            // 
            // rdb_PaswordExpires_Never
            // 
            this.rdb_PaswordExpires_Never.AutoSize = true;
            this.rdb_PaswordExpires_Never.Location = new System.Drawing.Point(14, 22);
            this.rdb_PaswordExpires_Never.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_PaswordExpires_Never.Name = "rdb_PaswordExpires_Never";
            this.rdb_PaswordExpires_Never.Size = new System.Drawing.Size(67, 21);
            this.rdb_PaswordExpires_Never.TabIndex = 34;
            this.rdb_PaswordExpires_Never.TabStop = true;
            this.rdb_PaswordExpires_Never.Text = "Never";
            this.rdb_PaswordExpires_Never.UseVisualStyleBackColor = true;
            // 
            // rdb_AfterNumberOfDays
            // 
            this.rdb_AfterNumberOfDays.AutoSize = true;
            this.rdb_AfterNumberOfDays.Location = new System.Drawing.Point(84, 22);
            this.rdb_AfterNumberOfDays.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_AfterNumberOfDays.Name = "rdb_AfterNumberOfDays";
            this.rdb_AfterNumberOfDays.Size = new System.Drawing.Size(163, 21);
            this.rdb_AfterNumberOfDays.TabIndex = 35;
            this.rdb_AfterNumberOfDays.TabStop = true;
            this.rdb_AfterNumberOfDays.Text = "After Number of days";
            this.rdb_AfterNumberOfDays.UseVisualStyleBackColor = true;
            // 
            // rdb_DeactivateAfterNumberOfDays
            // 
            this.rdb_DeactivateAfterNumberOfDays.AutoSize = true;
            this.rdb_DeactivateAfterNumberOfDays.Location = new System.Drawing.Point(255, 22);
            this.rdb_DeactivateAfterNumberOfDays.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_DeactivateAfterNumberOfDays.Name = "rdb_DeactivateAfterNumberOfDays";
            this.rdb_DeactivateAfterNumberOfDays.Size = new System.Drawing.Size(233, 21);
            this.rdb_DeactivateAfterNumberOfDays.TabIndex = 36;
            this.rdb_DeactivateAfterNumberOfDays.TabStop = true;
            this.rdb_DeactivateAfterNumberOfDays.Text = "Not Active After Number of Days";
            this.rdb_DeactivateAfterNumberOfDays.UseVisualStyleBackColor = true;
            // 
            // lbl_Max_Password_Age
            // 
            this.lbl_Max_Password_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Max_Password_Age.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_Max_Password_Age.Location = new System.Drawing.Point(4, 52);
            this.lbl_Max_Password_Age.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Max_Password_Age.Name = "lbl_Max_Password_Age";
            this.lbl_Max_Password_Age.Size = new System.Drawing.Size(334, 16);
            this.lbl_Max_Password_Age.TabIndex = 29;
            this.lbl_Max_Password_Age.Text = "Number  of days:";
            // 
            // nmUpDn_MaxPasswordAge
            // 
            this.nmUpDn_MaxPasswordAge.Location = new System.Drawing.Point(361, 45);
            this.nmUpDn_MaxPasswordAge.Margin = new System.Windows.Forms.Padding(5);
            this.nmUpDn_MaxPasswordAge.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDn_MaxPasswordAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_MaxPasswordAge.Name = "nmUpDn_MaxPasswordAge";
            this.nmUpDn_MaxPasswordAge.Size = new System.Drawing.Size(126, 22);
            this.nmUpDn_MaxPasswordAge.TabIndex = 28;
            this.nmUpDn_MaxPasswordAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chk_Enabled
            // 
            this.chk_Enabled.AutoSize = true;
            this.chk_Enabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Enabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_Enabled.Location = new System.Drawing.Point(375, 11);
            this.chk_Enabled.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Enabled.Name = "chk_Enabled";
            this.chk_Enabled.Size = new System.Drawing.Size(87, 21);
            this.chk_Enabled.TabIndex = 111;
            this.chk_Enabled.Text = "Enabled*";
            this.chk_Enabled.UseVisualStyleBackColor = true;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(-1, 741);
            this.usrc_NavigationButtons1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(1228, 79);
            this.usrc_NavigationButtons1.TabIndex = 17;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // AWP_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1230, 825);
            this.Controls.Add(this.btnChangeData);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AWP_UserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadDataForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManager_FormClosing);
            this.Load += new System.EventHandler(this.AWP_UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UserRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_OtherRoles)).EndInit();
            this.grp_PasswordExpires.ResumeLayout(false);
            this.grp_PasswordExpires.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnChangeData;
        internal DataGridView_2xls.DataGridView2xls dgv_LoginUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Label lbl_UserRoles;
        internal System.Windows.Forms.CheckBox chk_ChangePasswordOnFirstLogIn;
        internal System.Windows.Forms.TextBox txtConfirmPassword;
        internal System.Windows.Forms.Label lbl_ConfirmPasword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Label lbl_UserName;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.GroupBox grp_PasswordExpires;
        internal System.Windows.Forms.RadioButton rdb_DeactivateAfterNumberOfDays;
        internal System.Windows.Forms.RadioButton rdb_AfterNumberOfDays;
        internal System.Windows.Forms.RadioButton rdb_PaswordExpires_Never;
        internal System.Windows.Forms.NumericUpDown nmUpDn_MaxPasswordAge;
        internal System.Windows.Forms.Label lbl_Max_Password_Age;
        internal System.Windows.Forms.CheckBox chk_Enabled;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_Edit_myOrganisation_Person;
        private System.Windows.Forms.DataGridView dgvx_UserRoles;
        private System.Windows.Forms.DataGridView dgvx_OtherRoles;
        internal System.Windows.Forms.Label lbl_OtherRoles;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}