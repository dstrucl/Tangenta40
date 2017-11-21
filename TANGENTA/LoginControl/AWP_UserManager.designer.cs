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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnChangeData = new System.Windows.Forms.Button();
            this.dgv_LoginUsers = new DataGridView_2xls.DataGridView2xls();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_Job = new System.Windows.Forms.TextBox();
            this.lbl_Job = new System.Windows.Forms.Label();
            this.txt_UserTax_ID = new System.Windows.Forms.TextBox();
            this.lbl_UserTax_ID = new System.Windows.Forms.Label();
            this.dgv_Roles = new DataGridView_2xls.DataGridView2xls();
            this.btn_ManageRoles = new System.Windows.Forms.Button();
            this.lbl_ManageRoles = new System.Windows.Forms.Label();
            this.chk_ChangePasswordOnFirstLogIn = new System.Windows.Forms.CheckBox();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.lbl_UserIdentity = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lbl_UserLastName = new System.Windows.Forms.Label();
            this.lbl_UserFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lbl_ConfirmPasword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.grp_PasswordExpires = new System.Windows.Forms.GroupBox();
            this.rdb_DeactivateAfterNumberOfDays = new System.Windows.Forms.RadioButton();
            this.rdb_AfterNumberOfDays = new System.Windows.Forms.RadioButton();
            this.rdb_PaswordExpires_Never = new System.Windows.Forms.RadioButton();
            this.lbl_Max_Password_Age = new System.Windows.Forms.Label();
            this.nmUpDn_MaxPasswordAge = new System.Windows.Forms.NumericUpDown();
            this.pic_Image = new System.Windows.Forms.PictureBox();
            this.btn_PersonImage = new System.Windows.Forms.Button();
            this.lbl_Street = new System.Windows.Forms.Label();
            this.txt_StreetName = new System.Windows.Forms.TextBox();
            this.lbl_HouseNumber = new System.Windows.Forms.Label();
            this.txt_HouseNumber = new System.Windows.Forms.TextBox();
            this.lbl_City = new System.Windows.Forms.Label();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.lbl_ZIP = new System.Windows.Forms.Label();
            this.txt_ZIP = new System.Windows.Forms.TextBox();
            this.lbl_Country = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lbl_Gsm = new System.Windows.Forms.Label();
            this.txt_GSM = new System.Windows.Forms.TextBox();
            this.lbl_Tel = new System.Windows.Forms.Label();
            this.txt_TEL = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.cmb_Office = new System.Windows.Forms.ComboBox();
            this.lbl_Office = new System.Windows.Forms.Label();
            this.cmb_Country = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).BeginInit();
            this.grp_PasswordExpires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).BeginInit();
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
            this.dgv_LoginUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_LoginUsers.DataGridViewWithRowNumber = false;
            this.dgv_LoginUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_LoginUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_LoginUsers.Location = new System.Drawing.Point(0, 0);
            this.dgv_LoginUsers.MultiSelect = false;
            this.dgv_LoginUsers.Name = "dgv_LoginUsers";
            this.dgv_LoginUsers.ReadOnly = true;
            this.dgv_LoginUsers.RowTemplate.Height = 24;
            this.dgv_LoginUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginUsers.Size = new System.Drawing.Size(554, 606);
            this.dgv_LoginUsers.StandardTab = true;
            this.dgv_LoginUsers.TabIndex = 15;
            this.dgv_LoginUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dgv_LoginUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_LoginUsers_DataError);
            this.dgv_LoginUsers.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Country);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Office);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Office);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Email);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Email);
            this.splitContainer1.Panel1.Controls.Add(this.btn_PersonImage);
            this.splitContainer1.Panel1.Controls.Add(this.pic_Image);
            this.splitContainer1.Panel1.Controls.Add(this.txt_TEL);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Tel);
            this.splitContainer1.Panel1.Controls.Add(this.txt_GSM);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Gsm);
            this.splitContainer1.Panel1.Controls.Add(this.textBox6);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_State);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Country);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ZIP);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ZIP);
            this.splitContainer1.Panel1.Controls.Add(this.txt_City);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_City);
            this.splitContainer1.Panel1.Controls.Add(this.txt_HouseNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_HouseNumber);
            this.splitContainer1.Panel1.Controls.Add(this.txt_StreetName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Street);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Job);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Job);
            this.splitContainer1.Panel1.Controls.Add(this.txt_UserTax_ID);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserTax_ID);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Roles);
            this.splitContainer1.Panel1.Controls.Add(this.btn_ManageRoles);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ManageRoles);
            this.splitContainer1.Panel1.Controls.Add(this.chk_ChangePasswordOnFirstLogIn);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Description);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Description);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdentityNumber);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserIdentity);
            this.splitContainer1.Panel1.Controls.Add(this.txtLastName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserLastName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserFirstName);
            this.splitContainer1.Panel1.Controls.Add(this.txtFirstName);
            this.splitContainer1.Panel1.Controls.Add(this.chk_Active);
            this.splitContainer1.Panel1.Controls.Add(this.txtConfirmPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ConfirmPasword);
            this.splitContainer1.Panel1.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lblPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_UserName);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer1.Panel1.Controls.Add(this.grp_PasswordExpires);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_LoginUsers);
            this.splitContainer1.Size = new System.Drawing.Size(978, 606);
            this.splitContainer1.SplitterDistance = 420;
            this.splitContainer1.TabIndex = 16;
            // 
            // txt_Job
            // 
            this.txt_Job.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Job.Location = new System.Drawing.Point(86, 270);
            this.txt_Job.Name = "txt_Job";
            this.txt_Job.Size = new System.Drawing.Size(331, 19);
            this.txt_Job.TabIndex = 79;
            // 
            // lbl_Job
            // 
            this.lbl_Job.AutoSize = true;
            this.lbl_Job.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Job.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Job.Location = new System.Drawing.Point(5, 271);
            this.lbl_Job.Name = "lbl_Job";
            this.lbl_Job.Size = new System.Drawing.Size(24, 13);
            this.lbl_Job.TabIndex = 80;
            this.lbl_Job.Text = "Job";
            // 
            // txt_UserTax_ID
            // 
            this.txt_UserTax_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserTax_ID.Location = new System.Drawing.Point(293, 249);
            this.txt_UserTax_ID.Name = "txt_UserTax_ID";
            this.txt_UserTax_ID.Size = new System.Drawing.Size(124, 19);
            this.txt_UserTax_ID.TabIndex = 77;
            // 
            // lbl_UserTax_ID
            // 
            this.lbl_UserTax_ID.AutoSize = true;
            this.lbl_UserTax_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserTax_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserTax_ID.Location = new System.Drawing.Point(216, 252);
            this.lbl_UserTax_ID.Name = "lbl_UserTax_ID";
            this.lbl_UserTax_ID.Size = new System.Drawing.Size(67, 13);
            this.lbl_UserTax_ID.TabIndex = 78;
            this.lbl_UserTax_ID.Text = "User TAX ID";
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
            this.dgv_Roles.DataGridViewWithRowNumber = false;
            this.dgv_Roles.Location = new System.Drawing.Point(3, 475);
            this.dgv_Roles.Name = "dgv_Roles";
            this.dgv_Roles.Size = new System.Drawing.Size(411, 128);
            this.dgv_Roles.TabIndex = 75;
            // 
            // btn_ManageRoles
            // 
            this.btn_ManageRoles.Location = new System.Drawing.Point(276, 442);
            this.btn_ManageRoles.Name = "btn_ManageRoles";
            this.btn_ManageRoles.Size = new System.Drawing.Size(122, 27);
            this.btn_ManageRoles.TabIndex = 74;
            this.btn_ManageRoles.Text = "Manage Roles";
            this.btn_ManageRoles.UseVisualStyleBackColor = true;
            // 
            // lbl_ManageRoles
            // 
            this.lbl_ManageRoles.AutoSize = true;
            this.lbl_ManageRoles.Location = new System.Drawing.Point(4, 449);
            this.lbl_ManageRoles.Name = "lbl_ManageRoles";
            this.lbl_ManageRoles.Size = new System.Drawing.Size(32, 13);
            this.lbl_ManageRoles.TabIndex = 73;
            this.lbl_ManageRoles.Text = "Role:";
            // 
            // chk_ChangePasswordOnFirstLogIn
            // 
            this.chk_ChangePasswordOnFirstLogIn.AutoSize = true;
            this.chk_ChangePasswordOnFirstLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ChangePasswordOnFirstLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_ChangePasswordOnFirstLogIn.Location = new System.Drawing.Point(8, 113);
            this.chk_ChangePasswordOnFirstLogIn.Name = "chk_ChangePasswordOnFirstLogIn";
            this.chk_ChangePasswordOnFirstLogIn.Size = new System.Drawing.Size(181, 17);
            this.chk_ChangePasswordOnFirstLogIn.TabIndex = 72;
            this.chk_ChangePasswordOnFirstLogIn.Text = "Change Password On First LogIn";
            this.chk_ChangePasswordOnFirstLogIn.UseVisualStyleBackColor = true;
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Description.Location = new System.Drawing.Point(75, 410);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(339, 19);
            this.txt_Description.TabIndex = 67;
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Description.Location = new System.Drawing.Point(4, 412);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(60, 13);
            this.lbl_Description.TabIndex = 71;
            this.lbl_Description.Text = "Description";
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityNumber.Location = new System.Drawing.Point(86, 249);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(113, 19);
            this.txtIdentityNumber.TabIndex = 66;
            // 
            // lbl_UserIdentity
            // 
            this.lbl_UserIdentity.AutoSize = true;
            this.lbl_UserIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserIdentity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserIdentity.Location = new System.Drawing.Point(5, 252);
            this.lbl_UserIdentity.Name = "lbl_UserIdentity";
            this.lbl_UserIdentity.Size = new System.Drawing.Size(81, 13);
            this.lbl_UserIdentity.TabIndex = 70;
            this.lbl_UserIdentity.Text = "Identity Number";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(86, 228);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(331, 19);
            this.txtLastName.TabIndex = 64;
            // 
            // lbl_UserLastName
            // 
            this.lbl_UserLastName.AutoSize = true;
            this.lbl_UserLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserLastName.Location = new System.Drawing.Point(5, 230);
            this.lbl_UserLastName.Name = "lbl_UserLastName";
            this.lbl_UserLastName.Size = new System.Drawing.Size(58, 13);
            this.lbl_UserLastName.TabIndex = 69;
            this.lbl_UserLastName.Text = "Last Name";
            // 
            // lbl_UserFirstName
            // 
            this.lbl_UserFirstName.AutoSize = true;
            this.lbl_UserFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserFirstName.Location = new System.Drawing.Point(5, 210);
            this.lbl_UserFirstName.Name = "lbl_UserFirstName";
            this.lbl_UserFirstName.Size = new System.Drawing.Size(57, 13);
            this.lbl_UserFirstName.TabIndex = 68;
            this.lbl_UserFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(86, 207);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(331, 19);
            this.txtFirstName.TabIndex = 63;
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Active.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chk_Active.Location = new System.Drawing.Point(218, 35);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(56, 17);
            this.chk_Active.TabIndex = 57;
            this.chk_Active.Text = "Active";
            this.chk_Active.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(105, 84);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(178, 19);
            this.txtConfirmPassword.TabIndex = 61;
            // 
            // lbl_ConfirmPasword
            // 
            this.lbl_ConfirmPasword.AutoSize = true;
            this.lbl_ConfirmPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConfirmPasword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_ConfirmPasword.Location = new System.Drawing.Point(5, 90);
            this.lbl_ConfirmPasword.Name = "lbl_ConfirmPasword";
            this.lbl_ConfirmPasword.Size = new System.Drawing.Size(94, 13);
            this.lbl_ConfirmPasword.TabIndex = 65;
            this.lbl_ConfirmPasword.Text = "Confirm Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(105, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(178, 19);
            this.txtPassword.TabIndex = 59;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(5, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 62;
            this.lblPassword.Text = "Password:";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_UserName.Location = new System.Drawing.Point(5, 36);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(60, 13);
            this.lbl_UserName.TabIndex = 60;
            this.lbl_UserName.Text = "UserName:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(71, 33);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(141, 19);
            this.txtUserName.TabIndex = 58;
            // 
            // grp_PasswordExpires
            // 
            this.grp_PasswordExpires.Controls.Add(this.rdb_DeactivateAfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.rdb_AfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.rdb_PaswordExpires_Never);
            this.grp_PasswordExpires.Controls.Add(this.lbl_Max_Password_Age);
            this.grp_PasswordExpires.Controls.Add(this.nmUpDn_MaxPasswordAge);
            this.grp_PasswordExpires.Location = new System.Drawing.Point(4, 136);
            this.grp_PasswordExpires.Name = "grp_PasswordExpires";
            this.grp_PasswordExpires.Size = new System.Drawing.Size(410, 65);
            this.grp_PasswordExpires.TabIndex = 76;
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
            // pic_Image
            // 
            this.pic_Image.Location = new System.Drawing.Point(289, 5);
            this.pic_Image.Name = "pic_Image";
            this.pic_Image.Size = new System.Drawing.Size(128, 128);
            this.pic_Image.TabIndex = 97;
            this.pic_Image.TabStop = false;
            // 
            // btn_PersonImage
            // 
            this.btn_PersonImage.Location = new System.Drawing.Point(242, 3);
            this.btn_PersonImage.Name = "btn_PersonImage";
            this.btn_PersonImage.Size = new System.Drawing.Size(45, 25);
            this.btn_PersonImage.TabIndex = 98;
            this.btn_PersonImage.Text = "image";
            this.btn_PersonImage.UseVisualStyleBackColor = true;
            // 
            // lbl_Street
            // 
            this.lbl_Street.AutoSize = true;
            this.lbl_Street.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Street.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Street.Location = new System.Drawing.Point(5, 294);
            this.lbl_Street.Name = "lbl_Street";
            this.lbl_Street.Size = new System.Drawing.Size(35, 13);
            this.lbl_Street.TabIndex = 82;
            this.lbl_Street.Text = "Street";
            // 
            // txt_StreetName
            // 
            this.txt_StreetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StreetName.Location = new System.Drawing.Point(39, 291);
            this.txt_StreetName.Name = "txt_StreetName";
            this.txt_StreetName.Size = new System.Drawing.Size(180, 19);
            this.txt_StreetName.TabIndex = 81;
            // 
            // lbl_HouseNumber
            // 
            this.lbl_HouseNumber.AutoSize = true;
            this.lbl_HouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HouseNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_HouseNumber.Location = new System.Drawing.Point(225, 294);
            this.lbl_HouseNumber.Name = "lbl_HouseNumber";
            this.lbl_HouseNumber.Size = new System.Drawing.Size(84, 13);
            this.lbl_HouseNumber.TabIndex = 84;
            this.lbl_HouseNumber.Text = "House Naumber";
            // 
            // txt_HouseNumber
            // 
            this.txt_HouseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HouseNumber.Location = new System.Drawing.Point(315, 291);
            this.txt_HouseNumber.Name = "txt_HouseNumber";
            this.txt_HouseNumber.Size = new System.Drawing.Size(102, 19);
            this.txt_HouseNumber.TabIndex = 83;
            // 
            // lbl_City
            // 
            this.lbl_City.AutoSize = true;
            this.lbl_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_City.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_City.Location = new System.Drawing.Point(5, 315);
            this.lbl_City.Name = "lbl_City";
            this.lbl_City.Size = new System.Drawing.Size(24, 13);
            this.lbl_City.TabIndex = 86;
            this.lbl_City.Text = "City";
            // 
            // txt_City
            // 
            this.txt_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_City.Location = new System.Drawing.Point(53, 312);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(185, 19);
            this.txt_City.TabIndex = 85;
            // 
            // lbl_ZIP
            // 
            this.lbl_ZIP.AutoSize = true;
            this.lbl_ZIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ZIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_ZIP.Location = new System.Drawing.Point(244, 315);
            this.lbl_ZIP.Name = "lbl_ZIP";
            this.lbl_ZIP.Size = new System.Drawing.Size(79, 13);
            this.lbl_ZIP.TabIndex = 88;
            this.lbl_ZIP.Text = "Poštna številka";
            // 
            // txt_ZIP
            // 
            this.txt_ZIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ZIP.Location = new System.Drawing.Point(329, 312);
            this.txt_ZIP.Name = "txt_ZIP";
            this.txt_ZIP.Size = new System.Drawing.Size(88, 19);
            this.txt_ZIP.TabIndex = 87;
            // 
            // lbl_Country
            // 
            this.lbl_Country.AutoSize = true;
            this.lbl_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Country.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Country.Location = new System.Drawing.Point(5, 339);
            this.lbl_Country.Name = "lbl_Country";
            this.lbl_Country.Size = new System.Drawing.Size(43, 13);
            this.lbl_Country.TabIndex = 90;
            this.lbl_Country.Text = "Country";
            // 
            // lbl_State
            // 
            this.lbl_State.AutoSize = true;
            this.lbl_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_State.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_State.Location = new System.Drawing.Point(245, 339);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(32, 13);
            this.lbl_State.TabIndex = 92;
            this.lbl_State.Text = "State";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(283, 337);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(134, 19);
            this.textBox6.TabIndex = 91;
            // 
            // lbl_Gsm
            // 
            this.lbl_Gsm.AutoSize = true;
            this.lbl_Gsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gsm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Gsm.Location = new System.Drawing.Point(5, 364);
            this.lbl_Gsm.Name = "lbl_Gsm";
            this.lbl_Gsm.Size = new System.Drawing.Size(34, 13);
            this.lbl_Gsm.TabIndex = 94;
            this.lbl_Gsm.Text = "GSM:";
            // 
            // txt_GSM
            // 
            this.txt_GSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GSM.Location = new System.Drawing.Point(37, 362);
            this.txt_GSM.Name = "txt_GSM";
            this.txt_GSM.Size = new System.Drawing.Size(125, 19);
            this.txt_GSM.TabIndex = 93;
            // 
            // lbl_Tel
            // 
            this.lbl_Tel.AutoSize = true;
            this.lbl_Tel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Tel.Location = new System.Drawing.Point(165, 365);
            this.lbl_Tel.Name = "lbl_Tel";
            this.lbl_Tel.Size = new System.Drawing.Size(30, 13);
            this.lbl_Tel.TabIndex = 96;
            this.lbl_Tel.Text = "TEL:";
            // 
            // txt_TEL
            // 
            this.txt_TEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TEL.Location = new System.Drawing.Point(195, 363);
            this.txt_TEL.Name = "txt_TEL";
            this.txt_TEL.Size = new System.Drawing.Size(113, 19);
            this.txt_TEL.TabIndex = 95;
            // 
            // txt_Email
            // 
            this.txt_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Email.Location = new System.Drawing.Point(53, 387);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(364, 19);
            this.txt_Email.TabIndex = 99;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Email.Location = new System.Drawing.Point(5, 389);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 100;
            this.lbl_Email.Text = "Email";
            // 
            // cmb_Office
            // 
            this.cmb_Office.FormattingEnabled = true;
            this.cmb_Office.Location = new System.Drawing.Point(53, 5);
            this.cmb_Office.Name = "cmb_Office";
            this.cmb_Office.Size = new System.Drawing.Size(185, 21);
            this.cmb_Office.TabIndex = 101;
            // 
            // lbl_Office
            // 
            this.lbl_Office.AutoSize = true;
            this.lbl_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Office.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_Office.Location = new System.Drawing.Point(5, 10);
            this.lbl_Office.Name = "lbl_Office";
            this.lbl_Office.Size = new System.Drawing.Size(38, 13);
            this.lbl_Office.TabIndex = 103;
            this.lbl_Office.Text = "Office:";
            // 
            // cmb_Country
            // 
            this.cmb_Country.FormattingEnabled = true;
            this.cmb_Country.Location = new System.Drawing.Point(49, 336);
            this.cmb_Country.Name = "cmb_Country";
            this.cmb_Country.Size = new System.Drawing.Size(189, 21);
            this.cmb_Country.TabIndex = 104;
            // 
            // AWP_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(984, 660);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnChangeData);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "AWP_UserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadDataForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManager_FormClosing);
            this.Load += new System.EventHandler(this.UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginUsers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).EndInit();
            this.grp_PasswordExpires.ResumeLayout(false);
            this.grp_PasswordExpires.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnChangeData;
        internal DataGridView_2xls.DataGridView2xls dgv_LoginUsers;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Job;
        private System.Windows.Forms.Label lbl_Job;
        private System.Windows.Forms.TextBox txt_UserTax_ID;
        private System.Windows.Forms.Label lbl_UserTax_ID;
        private DataGridView_2xls.DataGridView2xls dgv_Roles;
        private System.Windows.Forms.Button btn_ManageRoles;
        private System.Windows.Forms.Label lbl_ManageRoles;
        private System.Windows.Forms.CheckBox chk_ChangePasswordOnFirstLogIn;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.Label lbl_UserIdentity;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lbl_UserLastName;
        private System.Windows.Forms.Label lbl_UserFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lbl_ConfirmPasword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox grp_PasswordExpires;
        private System.Windows.Forms.RadioButton rdb_DeactivateAfterNumberOfDays;
        private System.Windows.Forms.RadioButton rdb_AfterNumberOfDays;
        private System.Windows.Forms.RadioButton rdb_PaswordExpires_Never;
        private System.Windows.Forms.Label lbl_Max_Password_Age;
        private System.Windows.Forms.NumericUpDown nmUpDn_MaxPasswordAge;
        private System.Windows.Forms.Label lbl_Office;
        private System.Windows.Forms.ComboBox cmb_Office;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Button btn_PersonImage;
        private System.Windows.Forms.PictureBox pic_Image;
        private System.Windows.Forms.TextBox txt_TEL;
        private System.Windows.Forms.Label lbl_Tel;
        private System.Windows.Forms.TextBox txt_GSM;
        private System.Windows.Forms.Label lbl_Gsm;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label lbl_Country;
        private System.Windows.Forms.TextBox txt_ZIP;
        private System.Windows.Forms.Label lbl_ZIP;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.Label lbl_City;
        private System.Windows.Forms.TextBox txt_HouseNumber;
        private System.Windows.Forms.Label lbl_HouseNumber;
        private System.Windows.Forms.TextBox txt_StreetName;
        private System.Windows.Forms.Label lbl_Street;
        private System.Windows.Forms.ComboBox cmb_Country;
    }
}