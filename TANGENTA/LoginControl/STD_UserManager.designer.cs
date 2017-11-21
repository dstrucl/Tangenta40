namespace LoginControl
{
    partial class STD_UserManager
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbl_ConfirmPasword = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnChangeData = new System.Windows.Forms.Button();
            this.dgv_LoginUsers = new DataGridView_2xls.DataGridView2xls();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime = new System.Windows.Forms.TextBox();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lbl_UserLastName = new System.Windows.Forms.Label();
            this.lbl_UserFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.lbl_UserIdentity = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.chk_ChangePasswordOnFirstLogIn = new System.Windows.Forms.CheckBox();
            this.nmUpDn_MaxPasswordAge = new System.Windows.Forms.NumericUpDown();
            this.lbl_Max_Password_Age = new System.Windows.Forms.Label();
            this.lbl_ManageRoles = new System.Windows.Forms.Label();
            this.btn_ManageRoles = new System.Windows.Forms.Button();
            this.dgv_Roles = new DataGridView_2xls.DataGridView2xls();
            this.rdb_PaswordExpires_Never = new System.Windows.Forms.RadioButton();
            this.grp_PasswordExpires = new System.Windows.Forms.GroupBox();
            this.rdb_DeactivateAfterNumberOfDays = new System.Windows.Forms.RadioButton();
            this.rdb_AfterNumberOfDays = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).BeginInit();
            this.grp_PasswordExpires.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnOK.Location = new System.Drawing.Point(169, 614);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 34);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnCancel.Location = new System.Drawing.Point(637, 614);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 34);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(169, 56);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(243, 19);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_UserName.Location = new System.Drawing.Point(13, 58);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(60, 13);
            this.lbl_UserName.TabIndex = 4;
            this.lbl_UserName.Text = "UserName:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(13, 102);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(169, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(243, 19);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(169, 129);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(243, 19);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
            // 
            // lbl_ConfirmPasword
            // 
            this.lbl_ConfirmPasword.AutoSize = true;
            this.lbl_ConfirmPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConfirmPasword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_ConfirmPasword.Location = new System.Drawing.Point(13, 131);
            this.lbl_ConfirmPasword.Name = "lbl_ConfirmPasword";
            this.lbl_ConfirmPasword.Size = new System.Drawing.Size(94, 13);
            this.lbl_ConfirmPasword.TabIndex = 7;
            this.lbl_ConfirmPasword.Text = "Confirm Password:";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnAddUser.Location = new System.Drawing.Point(13, 614);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(138, 34);
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
            this.btnChangeData.Location = new System.Drawing.Point(323, 614);
            this.btnChangeData.Name = "btnChangeData";
            this.btnChangeData.Size = new System.Drawing.Size(138, 34);
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
            this.dgv_LoginUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LoginUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_LoginUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_LoginUsers.Location = new System.Drawing.Point(418, 34);
            this.dgv_LoginUsers.MultiSelect = false;
            this.dgv_LoginUsers.Name = "dgv_LoginUsers";
            this.dgv_LoginUsers.ReadOnly = true;
            this.dgv_LoginUsers.RowTemplate.Height = 24;
            this.dgv_LoginUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginUsers.Size = new System.Drawing.Size(662, 565);
            this.dgv_LoginUsers.StandardTab = true;
            this.dgv_LoginUsers.TabIndex = 15;
            this.dgv_LoginUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dgv_LoginUsers.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dgv_LoginUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_LoginUsers_DataError);
            this.dgv_LoginUsers.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(70)))));
            this.btnDeleteUser.Location = new System.Drawing.Point(483, 614);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(138, 34);
            this.btnDeleteUser.TabIndex = 13;
            this.btnDeleteUser.Text = "DeleteUser";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // txt_ComputerName_DataBaseFile_DataBaseFileCreationTime
            // 
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.BackColor = System.Drawing.SystemColors.Control;
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Location = new System.Drawing.Point(13, 6);
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Name = "txt_ComputerName_DataBaseFile_DataBaseFileCreationTime";
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.ReadOnly = true;
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Size = new System.Drawing.Size(1067, 19);
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.TabIndex = 13;
            this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime.Text = "wwqeqwewq";
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Active.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_Active.Location = new System.Drawing.Point(16, 31);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(56, 17);
            this.chk_Active.TabIndex = 1;
            this.chk_Active.Text = "Active";
            this.chk_Active.UseVisualStyleBackColor = true;
            this.chk_Active.CheckedChanged += new System.EventHandler(this.chk_Active_CheckedChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(169, 304);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(243, 19);
            this.txtLastName.TabIndex = 7;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastName_KeyPress);
            // 
            // lbl_UserLastName
            // 
            this.lbl_UserLastName.AutoSize = true;
            this.lbl_UserLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserLastName.Location = new System.Drawing.Point(13, 306);
            this.lbl_UserLastName.Name = "lbl_UserLastName";
            this.lbl_UserLastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_UserLastName.TabIndex = 21;
            this.lbl_UserLastName.Text = "Last Name";
            // 
            // lbl_UserFirstName
            // 
            this.lbl_UserFirstName.AutoSize = true;
            this.lbl_UserFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserFirstName.Location = new System.Drawing.Point(13, 279);
            this.lbl_UserFirstName.Name = "lbl_UserFirstName";
            this.lbl_UserFirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_UserFirstName.TabIndex = 20;
            this.lbl_UserFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(169, 276);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(243, 19);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstName_KeyPress);
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityNumber.Location = new System.Drawing.Point(168, 330);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(244, 19);
            this.txtIdentityNumber.TabIndex = 8;
            this.txtIdentityNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentityNumber_KeyPress);
            // 
            // lbl_UserIdentity
            // 
            this.lbl_UserIdentity.AutoSize = true;
            this.lbl_UserIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserIdentity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserIdentity.Location = new System.Drawing.Point(13, 332);
            this.lbl_UserIdentity.Name = "lbl_UserIdentity";
            this.lbl_UserIdentity.Size = new System.Drawing.Size(81, 13);
            this.lbl_UserIdentity.TabIndex = 23;
            this.lbl_UserIdentity.Text = "Identity Number";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(168, 357);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(244, 19);
            this.txtContact.TabIndex = 9;
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.AutoSize = true;
            this.lbl_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Contact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Contact.Location = new System.Drawing.Point(13, 359);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(44, 13);
            this.lbl_Contact.TabIndex = 25;
            this.lbl_Contact.Text = "Contact";
            // 
            // chk_ChangePasswordOnFirstLogIn
            // 
            this.chk_ChangePasswordOnFirstLogIn.AutoSize = true;
            this.chk_ChangePasswordOnFirstLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChangePasswordOnFirstLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_ChangePasswordOnFirstLogIn.Location = new System.Drawing.Point(16, 165);
            this.chk_ChangePasswordOnFirstLogIn.Name = "chk_ChangePasswordOnFirstLogIn";
            this.chk_ChangePasswordOnFirstLogIn.Size = new System.Drawing.Size(181, 17);
            this.chk_ChangePasswordOnFirstLogIn.TabIndex = 27;
            this.chk_ChangePasswordOnFirstLogIn.Text = "Change Password On First LogIn";
            this.chk_ChangePasswordOnFirstLogIn.UseVisualStyleBackColor = true;
            // 
            // nmUpDn_MaxPasswordAge
            // 
            this.nmUpDn_MaxPasswordAge.Location = new System.Drawing.Point(279, 40);
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
            this.nmUpDn_MaxPasswordAge.Size = new System.Drawing.Size(101, 19);
            this.nmUpDn_MaxPasswordAge.TabIndex = 28;
            this.nmUpDn_MaxPasswordAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Max_Password_Age
            // 
            this.lbl_Max_Password_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Max_Password_Age.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_Max_Password_Age.Location = new System.Drawing.Point(6, 43);
            this.lbl_Max_Password_Age.Name = "lbl_Max_Password_Age";
            this.lbl_Max_Password_Age.Size = new System.Drawing.Size(267, 13);
            this.lbl_Max_Password_Age.TabIndex = 29;
            this.lbl_Max_Password_Age.Text = "Number  of days:";
            // 
            // lbl_ManageRoles
            // 
            this.lbl_ManageRoles.AutoSize = true;
            this.lbl_ManageRoles.Location = new System.Drawing.Point(15, 397);
            this.lbl_ManageRoles.Name = "lbl_ManageRoles";
            this.lbl_ManageRoles.Size = new System.Drawing.Size(32, 13);
            this.lbl_ManageRoles.TabIndex = 31;
            this.lbl_ManageRoles.Text = "Role:";
            // 
            // btn_ManageRoles
            // 
            this.btn_ManageRoles.Location = new System.Drawing.Point(290, 390);
            this.btn_ManageRoles.Name = "btn_ManageRoles";
            this.btn_ManageRoles.Size = new System.Drawing.Size(122, 27);
            this.btn_ManageRoles.TabIndex = 32;
            this.btn_ManageRoles.Text = "Manage Roles";
            this.btn_ManageRoles.UseVisualStyleBackColor = true;
            this.btn_ManageRoles.Click += new System.EventHandler(this.btn_ManageRoles_Click);
            // 
            // dgv_Roles
            // 
            this.dgv_Roles.AllowUserToAddRows = false;
            this.dgv_Roles.AllowUserToDeleteRows = false;
            this.dgv_Roles.AllowUserToOrderColumns = true;
            this.dgv_Roles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_Roles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Roles.Location = new System.Drawing.Point(18, 423);
            this.dgv_Roles.Name = "dgv_Roles";
            this.dgv_Roles.Size = new System.Drawing.Size(394, 175);
            this.dgv_Roles.TabIndex = 33;
            // 
            // rdb_PaswordExpires_Never
            // 
            this.rdb_PaswordExpires_Never.AutoSize = true;
            this.rdb_PaswordExpires_Never.Location = new System.Drawing.Point(8, 20);
            this.rdb_PaswordExpires_Never.Name = "rdb_PaswordExpires_Never";
            this.rdb_PaswordExpires_Never.Size = new System.Drawing.Size(54, 17);
            this.rdb_PaswordExpires_Never.TabIndex = 34;
            this.rdb_PaswordExpires_Never.TabStop = true;
            this.rdb_PaswordExpires_Never.Text = "Never";
            this.rdb_PaswordExpires_Never.UseVisualStyleBackColor = true;
            this.rdb_PaswordExpires_Never.CheckedChanged += new System.EventHandler(this.rdb_PaswordExpires_Never_CheckedChanged);
            // 
            // grp_PasswordExpires
            // 
            this.grp_PasswordExpires.Controls.Add(this.rdb_DeactivateAfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.rdb_AfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.rdb_PaswordExpires_Never);
            this.grp_PasswordExpires.Controls.Add(this.lbl_Max_Password_Age);
            this.grp_PasswordExpires.Controls.Add(this.nmUpDn_MaxPasswordAge);
            this.grp_PasswordExpires.Location = new System.Drawing.Point(12, 188);
            this.grp_PasswordExpires.Name = "grp_PasswordExpires";
            this.grp_PasswordExpires.Size = new System.Drawing.Size(400, 65);
            this.grp_PasswordExpires.TabIndex = 35;
            this.grp_PasswordExpires.TabStop = false;
            this.grp_PasswordExpires.Text = "Password Expires";
            // 
            // rdb_DeactivateAfterNumberOfDays
            // 
            this.rdb_DeactivateAfterNumberOfDays.AutoSize = true;
            this.rdb_DeactivateAfterNumberOfDays.Location = new System.Drawing.Point(215, 20);
            this.rdb_DeactivateAfterNumberOfDays.Name = "rdb_DeactivateAfterNumberOfDays";
            this.rdb_DeactivateAfterNumberOfDays.Size = new System.Drawing.Size(179, 17);
            this.rdb_DeactivateAfterNumberOfDays.TabIndex = 36;
            this.rdb_DeactivateAfterNumberOfDays.TabStop = true;
            this.rdb_DeactivateAfterNumberOfDays.Text = "Not Active After Number of Days";
            this.rdb_DeactivateAfterNumberOfDays.UseVisualStyleBackColor = true;
            // 
            // rdb_AfterNumberOfDays
            // 
            this.rdb_AfterNumberOfDays.AutoSize = true;
            this.rdb_AfterNumberOfDays.Location = new System.Drawing.Point(71, 20);
            this.rdb_AfterNumberOfDays.Name = "rdb_AfterNumberOfDays";
            this.rdb_AfterNumberOfDays.Size = new System.Drawing.Size(124, 17);
            this.rdb_AfterNumberOfDays.TabIndex = 35;
            this.rdb_AfterNumberOfDays.TabStop = true;
            this.rdb_AfterNumberOfDays.Text = "After Number of days";
            this.rdb_AfterNumberOfDays.UseVisualStyleBackColor = true;
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 660);
            this.Controls.Add(this.dgv_Roles);
            this.Controls.Add(this.btn_ManageRoles);
            this.Controls.Add(this.lbl_ManageRoles);
            this.Controls.Add(this.chk_ChangePasswordOnFirstLogIn);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lbl_Contact);
            this.Controls.Add(this.txtIdentityNumber);
            this.Controls.Add(this.lbl_UserIdentity);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lbl_UserLastName);
            this.Controls.Add(this.lbl_UserFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.chk_Active);
            this.Controls.Add(this.txt_ComputerName_DataBaseFile_DataBaseFileCreationTime);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.dgv_LoginUsers);
            this.Controls.Add(this.btnChangeData);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lbl_ConfirmPasword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grp_PasswordExpires);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "UserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadDataForm";
            this.Load += new System.EventHandler(this.UserManager_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManager_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).EndInit();
            this.grp_PasswordExpires.ResumeLayout(false);
            this.grp_PasswordExpires.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lbl_ConfirmPasword;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnChangeData;
        internal DataGridView_2xls.DataGridView2xls dgv_LoginUsers;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.TextBox txt_ComputerName_DataBaseFile_DataBaseFileCreationTime;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lbl_UserLastName;
        private System.Windows.Forms.Label lbl_UserFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.Label lbl_UserIdentity;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.CheckBox chk_ChangePasswordOnFirstLogIn;
        private System.Windows.Forms.NumericUpDown nmUpDn_MaxPasswordAge;
        private System.Windows.Forms.Label lbl_Max_Password_Age;
        private System.Windows.Forms.Label lbl_ManageRoles;
        private System.Windows.Forms.Button btn_ManageRoles;
        private DataGridView_2xls.DataGridView2xls dgv_Roles;
        private System.Windows.Forms.RadioButton rdb_PaswordExpires_Never;
        private System.Windows.Forms.GroupBox grp_PasswordExpires;
        private System.Windows.Forms.RadioButton rdb_DeactivateAfterNumberOfDays;
        private System.Windows.Forms.RadioButton rdb_AfterNumberOfDays;
    }
}