namespace LoginControl
{
    partial class AWP_UserInfo_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWP_UserInfo_Form));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lbl_ChangePasswordOnFirstLogIn = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.grp_PasswordExpires = new System.Windows.Forms.GroupBox();
            this.chkp_PasswordNotActiveAfterNumberOfDays = new Check.check();
            this.chkp_PasswordExpiresAfterNumbersOfDays = new Check.check();
            this.chkp_PasswordNeverExpires = new Check.check();
            this.lbl_PaswordExpires_Never = new System.Windows.Forms.Label();
            this.lbl_AfterNumberOfDays = new System.Windows.Forms.Label();
            this.lbl_DeactivateAfterNumberOfDays = new System.Windows.Forms.Label();
            this.lbl_Max_Password_Age = new System.Windows.Forms.Label();
            this.nmUpDn_MaxPasswordAge = new System.Windows.Forms.NumericUpDown();
            this.lbl_Enabled = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.chkp_ChangePasswordOnFirstLogin = new Check.check();
            this.chkp_Enabled = new Check.check();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_LoginHistory = new System.Windows.Forms.Button();
            this.usrc_PasswordBytes1 = new LoginControl.usrc_PasswordBytes();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.dgvx_UserRoles = new System.Windows.Forms.DataGridView();
            this.grp_PasswordExpires.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordNotActiveAfterNumberOfDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordExpiresAfterNumbersOfDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordNeverExpires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_ChangePasswordOnFirstLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_Enabled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UserRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(13, 154);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(502, 246);
            this.webBrowser1.TabIndex = 112;
            // 
            // lbl_ChangePasswordOnFirstLogIn
            // 
            this.lbl_ChangePasswordOnFirstLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChangePasswordOnFirstLogIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_ChangePasswordOnFirstLogIn.Location = new System.Drawing.Point(333, 34);
            this.lbl_ChangePasswordOnFirstLogIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lbl_ChangePasswordOnFirstLogIn.Name = "lbl_ChangePasswordOnFirstLogIn";
            this.lbl_ChangePasswordOnFirstLogIn.Size = new System.Drawing.Size(138, 50);
            this.lbl_ChangePasswordOnFirstLogIn.TabIndex = 121;
            this.lbl_ChangePasswordOnFirstLogIn.Text = "Change Password On First login";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(108, 8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(178, 19);
            this.txtUserName.TabIndex = 119;
            // 
            // grp_PasswordExpires
            // 
            this.grp_PasswordExpires.Controls.Add(this.chkp_PasswordNotActiveAfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.chkp_PasswordExpiresAfterNumbersOfDays);
            this.grp_PasswordExpires.Controls.Add(this.chkp_PasswordNeverExpires);
            this.grp_PasswordExpires.Controls.Add(this.lbl_PaswordExpires_Never);
            this.grp_PasswordExpires.Controls.Add(this.lbl_AfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.lbl_DeactivateAfterNumberOfDays);
            this.grp_PasswordExpires.Controls.Add(this.lbl_Max_Password_Age);
            this.grp_PasswordExpires.Controls.Add(this.nmUpDn_MaxPasswordAge);
            this.grp_PasswordExpires.Location = new System.Drawing.Point(13, 89);
            this.grp_PasswordExpires.Name = "grp_PasswordExpires";
            this.grp_PasswordExpires.Size = new System.Drawing.Size(506, 59);
            this.grp_PasswordExpires.TabIndex = 122;
            this.grp_PasswordExpires.TabStop = false;
            this.grp_PasswordExpires.Text = "Password Expires";
            // 
            // chkp_PasswordNotActiveAfterNumberOfDays
            // 
            this.chkp_PasswordNotActiveAfterNumberOfDays.Image = ((System.Drawing.Image)(resources.GetObject("chkp_PasswordNotActiveAfterNumberOfDays.Image")));
            this.chkp_PasswordNotActiveAfterNumberOfDays.Location = new System.Drawing.Point(281, 13);
            this.chkp_PasswordNotActiveAfterNumberOfDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkp_PasswordNotActiveAfterNumberOfDays.Name = "chkp_PasswordNotActiveAfterNumberOfDays";
            this.chkp_PasswordNotActiveAfterNumberOfDays.Size = new System.Drawing.Size(19, 20);
            this.chkp_PasswordNotActiveAfterNumberOfDays.State = Check.check.eState.UNDEFINED;
            this.chkp_PasswordNotActiveAfterNumberOfDays.TabIndex = 132;
            this.chkp_PasswordNotActiveAfterNumberOfDays.TabStop = false;
            // 
            // chkp_PasswordExpiresAfterNumbersOfDays
            // 
            this.chkp_PasswordExpiresAfterNumbersOfDays.Image = ((System.Drawing.Image)(resources.GetObject("chkp_PasswordExpiresAfterNumbersOfDays.Image")));
            this.chkp_PasswordExpiresAfterNumbersOfDays.Location = new System.Drawing.Point(110, 18);
            this.chkp_PasswordExpiresAfterNumbersOfDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkp_PasswordExpiresAfterNumbersOfDays.Name = "chkp_PasswordExpiresAfterNumbersOfDays";
            this.chkp_PasswordExpiresAfterNumbersOfDays.Size = new System.Drawing.Size(19, 20);
            this.chkp_PasswordExpiresAfterNumbersOfDays.State = Check.check.eState.UNDEFINED;
            this.chkp_PasswordExpiresAfterNumbersOfDays.TabIndex = 131;
            this.chkp_PasswordExpiresAfterNumbersOfDays.TabStop = false;
            // 
            // chkp_PasswordNeverExpires
            // 
            this.chkp_PasswordNeverExpires.Image = ((System.Drawing.Image)(resources.GetObject("chkp_PasswordNeverExpires.Image")));
            this.chkp_PasswordNeverExpires.Location = new System.Drawing.Point(6, 18);
            this.chkp_PasswordNeverExpires.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkp_PasswordNeverExpires.Name = "chkp_PasswordNeverExpires";
            this.chkp_PasswordNeverExpires.Size = new System.Drawing.Size(19, 21);
            this.chkp_PasswordNeverExpires.State = Check.check.eState.UNDEFINED;
            this.chkp_PasswordNeverExpires.TabIndex = 130;
            this.chkp_PasswordNeverExpires.TabStop = false;
            // 
            // lbl_PaswordExpires_Never
            // 
            this.lbl_PaswordExpires_Never.AutoSize = true;
            this.lbl_PaswordExpires_Never.Location = new System.Drawing.Point(30, 18);
            this.lbl_PaswordExpires_Never.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lbl_PaswordExpires_Never.Name = "lbl_PaswordExpires_Never";
            this.lbl_PaswordExpires_Never.Size = new System.Drawing.Size(36, 13);
            this.lbl_PaswordExpires_Never.TabIndex = 34;
            this.lbl_PaswordExpires_Never.TabStop = true;
            this.lbl_PaswordExpires_Never.Text = "Never";
            // 
            // lbl_AfterNumberOfDays
            // 
            this.lbl_AfterNumberOfDays.AutoSize = true;
            this.lbl_AfterNumberOfDays.Location = new System.Drawing.Point(134, 18);
            this.lbl_AfterNumberOfDays.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lbl_AfterNumberOfDays.Name = "lbl_AfterNumberOfDays";
            this.lbl_AfterNumberOfDays.Size = new System.Drawing.Size(106, 13);
            this.lbl_AfterNumberOfDays.TabIndex = 35;
            this.lbl_AfterNumberOfDays.TabStop = true;
            this.lbl_AfterNumberOfDays.Text = "After Number of days";
            // 
            // lbl_DeactivateAfterNumberOfDays
            // 
            this.lbl_DeactivateAfterNumberOfDays.AutoSize = true;
            this.lbl_DeactivateAfterNumberOfDays.Location = new System.Drawing.Point(306, 18);
            this.lbl_DeactivateAfterNumberOfDays.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lbl_DeactivateAfterNumberOfDays.Name = "lbl_DeactivateAfterNumberOfDays";
            this.lbl_DeactivateAfterNumberOfDays.Size = new System.Drawing.Size(161, 13);
            this.lbl_DeactivateAfterNumberOfDays.TabIndex = 36;
            this.lbl_DeactivateAfterNumberOfDays.TabStop = true;
            this.lbl_DeactivateAfterNumberOfDays.Text = "Not Active After Number of Days";
            // 
            // lbl_Max_Password_Age
            // 
            this.lbl_Max_Password_Age.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Max_Password_Age.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_Max_Password_Age.Location = new System.Drawing.Point(6, 41);
            this.lbl_Max_Password_Age.Name = "lbl_Max_Password_Age";
            this.lbl_Max_Password_Age.Size = new System.Drawing.Size(267, 13);
            this.lbl_Max_Password_Age.TabIndex = 29;
            this.lbl_Max_Password_Age.Text = "Number  of days:";
            this.lbl_Max_Password_Age.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nmUpDn_MaxPasswordAge
            // 
            this.nmUpDn_MaxPasswordAge.Location = new System.Drawing.Point(281, 39);
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
            this.nmUpDn_MaxPasswordAge.ReadOnly = true;
            this.nmUpDn_MaxPasswordAge.Size = new System.Drawing.Size(101, 19);
            this.nmUpDn_MaxPasswordAge.TabIndex = 28;
            this.nmUpDn_MaxPasswordAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_Enabled
            // 
            this.lbl_Enabled.AutoSize = true;
            this.lbl_Enabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Enabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_Enabled.Location = new System.Drawing.Point(333, 14);
            this.lbl_Enabled.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.lbl_Enabled.Name = "lbl_Enabled";
            this.lbl_Enabled.Size = new System.Drawing.Size(50, 13);
            this.lbl_Enabled.TabIndex = 123;
            this.lbl_Enabled.Text = "Enabled*";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btn_ChangePassword);
            this.splitContainer3.Panel1.Controls.Add(this.chkp_ChangePasswordOnFirstLogin);
            this.splitContainer3.Panel1.Controls.Add(this.chkp_Enabled);
            this.splitContainer3.Panel1.Controls.Add(this.btn_Cancel);
            this.splitContainer3.Panel1.Controls.Add(this.btn_LoginHistory);
            this.splitContainer3.Panel1.Controls.Add(this.webBrowser1);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_ChangePasswordOnFirstLogIn);
            this.splitContainer3.Panel1.Controls.Add(this.usrc_PasswordBytes1);
            this.splitContainer3.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_UserName);
            this.splitContainer3.Panel1.Controls.Add(this.grp_PasswordExpires);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Enabled);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvx_UserRoles);
            this.splitContainer3.Size = new System.Drawing.Size(650, 438);
            this.splitContainer3.SplitterDistance = 518;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 124;
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ChangePassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ChangePassword.Location = new System.Drawing.Point(228, 406);
            this.btn_ChangePassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(213, 27);
            this.btn_ChangePassword.TabIndex = 130;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Visible = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // chkp_ChangePasswordOnFirstLogin
            // 
            this.chkp_ChangePasswordOnFirstLogin.Image = ((System.Drawing.Image)(resources.GetObject("chkp_ChangePasswordOnFirstLogin.Image")));
            this.chkp_ChangePasswordOnFirstLogin.Location = new System.Drawing.Point(304, 36);
            this.chkp_ChangePasswordOnFirstLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkp_ChangePasswordOnFirstLogin.Name = "chkp_ChangePasswordOnFirstLogin";
            this.chkp_ChangePasswordOnFirstLogin.Size = new System.Drawing.Size(19, 21);
            this.chkp_ChangePasswordOnFirstLogin.State = Check.check.eState.UNDEFINED;
            this.chkp_ChangePasswordOnFirstLogin.TabIndex = 129;
            this.chkp_ChangePasswordOnFirstLogin.TabStop = false;
            // 
            // chkp_Enabled
            // 
            this.chkp_Enabled.Image = ((System.Drawing.Image)(resources.GetObject("chkp_Enabled.Image")));
            this.chkp_Enabled.Location = new System.Drawing.Point(304, 10);
            this.chkp_Enabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkp_Enabled.Name = "chkp_Enabled";
            this.chkp_Enabled.Size = new System.Drawing.Size(19, 21);
            this.chkp_Enabled.State = Check.check.eState.UNDEFINED;
            this.chkp_Enabled.TabIndex = 128;
            this.chkp_Enabled.TabStop = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(446, 406);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 27);
            this.btn_Cancel.TabIndex = 127;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_LoginHistory
            // 
            this.btn_LoginHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_LoginHistory.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_LoginHistory.Location = new System.Drawing.Point(10, 406);
            this.btn_LoginHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_LoginHistory.Name = "btn_LoginHistory";
            this.btn_LoginHistory.Size = new System.Drawing.Size(214, 27);
            this.btn_LoginHistory.TabIndex = 126;
            this.btn_LoginHistory.Text = "Login History";
            this.btn_LoginHistory.UseVisualStyleBackColor = false;
            this.btn_LoginHistory.Click += new System.EventHandler(this.btn_LoginHistory_Click);
            // 
            // usrc_PasswordBytes1
            // 
            this.usrc_PasswordBytes1.Location = new System.Drawing.Point(6, 31);
            this.usrc_PasswordBytes1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usrc_PasswordBytes1.MinPasswordLength = 5;
            this.usrc_PasswordBytes1.Name = "usrc_PasswordBytes1";
            this.usrc_PasswordBytes1.Size = new System.Drawing.Size(280, 50);
            this.usrc_PasswordBytes1.TabIndex = 125;
            this.usrc_PasswordBytes1.PasswordChanged += new LoginControl.usrc_PasswordBytes.delegate_PasswordChanged(this.usrc_PasswordBytes1_PasswordChanged);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_UserName.Location = new System.Drawing.Point(10, 10);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(64, 13);
            this.lbl_UserName.TabIndex = 120;
            this.lbl_UserName.Text = "UserName*:";
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
            this.dgvx_UserRoles.Location = new System.Drawing.Point(3, 3);
            this.dgvx_UserRoles.Name = "dgvx_UserRoles";
            this.dgvx_UserRoles.ReadOnly = true;
            this.dgvx_UserRoles.Size = new System.Drawing.Size(123, 431);
            this.dgvx_UserRoles.TabIndex = 127;
            // 
            // AWP_UserInfo_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(650, 438);
            this.Controls.Add(this.splitContainer3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AWP_UserInfo_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadDataForm";
            this.Load += new System.EventHandler(this.AWP_UserInfo_Form_Load);
            this.grp_PasswordExpires.ResumeLayout(false);
            this.grp_PasswordExpires.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordNotActiveAfterNumberOfDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordExpiresAfterNumbersOfDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_PasswordNeverExpires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_MaxPasswordAge)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkp_ChangePasswordOnFirstLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkp_Enabled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UserRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        internal System.Windows.Forms.Label lbl_ChangePasswordOnFirstLogIn;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.GroupBox grp_PasswordExpires;
        internal System.Windows.Forms.Label lbl_PaswordExpires_Never;
        internal System.Windows.Forms.Label lbl_AfterNumberOfDays;
        internal System.Windows.Forms.Label lbl_DeactivateAfterNumberOfDays;
        internal System.Windows.Forms.Label lbl_Max_Password_Age;
        internal System.Windows.Forms.NumericUpDown nmUpDn_MaxPasswordAge;
        internal System.Windows.Forms.Label lbl_Enabled;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_LoginHistory;
        private usrc_PasswordBytes usrc_PasswordBytes1;
        internal System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.DataGridView dgvx_UserRoles;
        private Check.check chkp_Enabled;
        private Check.check chkp_PasswordNotActiveAfterNumberOfDays;
        private Check.check chkp_PasswordExpiresAfterNumbersOfDays;
        private Check.check chkp_PasswordNeverExpires;
        private Check.check chkp_ChangePasswordOnFirstLogin;
        private System.Windows.Forms.Button btn_ChangePassword;
    }
}