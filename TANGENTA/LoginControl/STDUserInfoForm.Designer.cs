namespace LoginControl
{
    partial class STDUserInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STDUserInfoForm));
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_first_name = new System.Windows.Forms.TextBox();
            this.lbl_first_name = new System.Windows.Forms.Label();
            this.txt_last_name = new System.Windows.Forms.TextBox();
            this.lbl_last_name = new System.Windows.Forms.Label();
            this.txt_Identiy = new System.Windows.Forms.TextBox();
            this.lbl_Identity = new System.Windows.Forms.Label();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.lbl_Contact = new System.Windows.Forms.Label();
            this.dgv_Roles = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Roles = new System.Windows.Forms.Label();
            this.chk_PasswordNeverExpires = new System.Windows.Forms.CheckBox();
            this.chk_PasswordExpiresInNumberOfDays = new System.Windows.Forms.CheckBox();
            this.chk_NotActiveAfterPasswordExpires = new System.Windows.Forms.CheckBox();
            this.txt_NumberOfDays = new System.Windows.Forms.TextBox();
            this.lbl_last_user_password_definition_time = new System.Windows.Forms.Label();
            this.txt_LastUserPasswordDefinitionTime = new System.Windows.Forms.TextBox();
            this.lbl_Password_expires_on = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_LoginHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(5, 10);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(120, 17);
            this.lbl_UserName.TabIndex = 0;
            this.lbl_UserName.Text = "lbl_username";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(136, 8);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.ReadOnly = true;
            this.txt_UserName.Size = new System.Drawing.Size(247, 20);
            this.txt_UserName.TabIndex = 1;
            // 
            // txt_first_name
            // 
            this.txt_first_name.Location = new System.Drawing.Point(136, 43);
            this.txt_first_name.Name = "txt_first_name";
            this.txt_first_name.ReadOnly = true;
            this.txt_first_name.Size = new System.Drawing.Size(250, 20);
            this.txt_first_name.TabIndex = 3;
            // 
            // lbl_first_name
            // 
            this.lbl_first_name.Location = new System.Drawing.Point(5, 45);
            this.lbl_first_name.Name = "lbl_first_name";
            this.lbl_first_name.Size = new System.Drawing.Size(120, 17);
            this.lbl_first_name.TabIndex = 2;
            this.lbl_first_name.Text = "first name";
            // 
            // txt_last_name
            // 
            this.txt_last_name.Location = new System.Drawing.Point(136, 69);
            this.txt_last_name.Name = "txt_last_name";
            this.txt_last_name.ReadOnly = true;
            this.txt_last_name.Size = new System.Drawing.Size(250, 20);
            this.txt_last_name.TabIndex = 5;
            // 
            // lbl_last_name
            // 
            this.lbl_last_name.Location = new System.Drawing.Point(4, 72);
            this.lbl_last_name.Name = "lbl_last_name";
            this.lbl_last_name.Size = new System.Drawing.Size(126, 17);
            this.lbl_last_name.TabIndex = 4;
            this.lbl_last_name.Text = "last name";
            // 
            // txt_Identiy
            // 
            this.txt_Identiy.Location = new System.Drawing.Point(7, 127);
            this.txt_Identiy.Multiline = true;
            this.txt_Identiy.Name = "txt_Identiy";
            this.txt_Identiy.ReadOnly = true;
            this.txt_Identiy.Size = new System.Drawing.Size(376, 77);
            this.txt_Identiy.TabIndex = 7;
            // 
            // lbl_Identity
            // 
            this.lbl_Identity.Location = new System.Drawing.Point(4, 107);
            this.lbl_Identity.Name = "lbl_Identity";
            this.lbl_Identity.Size = new System.Drawing.Size(139, 17);
            this.lbl_Identity.TabIndex = 6;
            this.lbl_Identity.Text = "Identity";
            // 
            // txt_Contact
            // 
            this.txt_Contact.Location = new System.Drawing.Point(7, 232);
            this.txt_Contact.Multiline = true;
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.ReadOnly = true;
            this.txt_Contact.Size = new System.Drawing.Size(376, 63);
            this.txt_Contact.TabIndex = 9;
            // 
            // lbl_Contact
            // 
            this.lbl_Contact.Location = new System.Drawing.Point(4, 213);
            this.lbl_Contact.Name = "lbl_Contact";
            this.lbl_Contact.Size = new System.Drawing.Size(139, 17);
            this.lbl_Contact.TabIndex = 8;
            this.lbl_Contact.Text = "Contact";
            // 
            // dgv_Roles
            // 
            this.dgv_Roles.AllowUserToAddRows = false;
            this.dgv_Roles.AllowUserToDeleteRows = false;
            this.dgv_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Roles.Location = new System.Drawing.Point(392, 23);
            this.dgv_Roles.Name = "dgv_Roles";
            this.dgv_Roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Roles.Size = new System.Drawing.Size(396, 352);
            this.dgv_Roles.TabIndex = 10;
            // 
            // lbl_Roles
            // 
            this.lbl_Roles.Location = new System.Drawing.Point(389, 6);
            this.lbl_Roles.Name = "lbl_Roles";
            this.lbl_Roles.Size = new System.Drawing.Size(126, 15);
            this.lbl_Roles.TabIndex = 11;
            this.lbl_Roles.Text = "Roles:";
            // 
            // chk_PasswordNeverExpires
            // 
            this.chk_PasswordNeverExpires.AutoSize = true;
            this.chk_PasswordNeverExpires.Enabled = false;
            this.chk_PasswordNeverExpires.Location = new System.Drawing.Point(11, 312);
            this.chk_PasswordNeverExpires.Name = "chk_PasswordNeverExpires";
            this.chk_PasswordNeverExpires.Size = new System.Drawing.Size(135, 17);
            this.chk_PasswordNeverExpires.TabIndex = 12;
            this.chk_PasswordNeverExpires.Text = "PasswordNeverExpires";
            this.chk_PasswordNeverExpires.UseVisualStyleBackColor = true;
            // 
            // chk_PasswordExpiresInNumberOfDays
            // 
            this.chk_PasswordExpiresInNumberOfDays.AutoSize = true;
            this.chk_PasswordExpiresInNumberOfDays.Enabled = false;
            this.chk_PasswordExpiresInNumberOfDays.Location = new System.Drawing.Point(11, 335);
            this.chk_PasswordExpiresInNumberOfDays.Name = "chk_PasswordExpiresInNumberOfDays";
            this.chk_PasswordExpiresInNumberOfDays.Size = new System.Drawing.Size(187, 17);
            this.chk_PasswordExpiresInNumberOfDays.TabIndex = 13;
            this.chk_PasswordExpiresInNumberOfDays.Text = "PasswordExpiresInNumberOfDays";
            this.chk_PasswordExpiresInNumberOfDays.UseVisualStyleBackColor = true;
            // 
            // chk_NotActiveAfterPasswordExpires
            // 
            this.chk_NotActiveAfterPasswordExpires.AutoSize = true;
            this.chk_NotActiveAfterPasswordExpires.Enabled = false;
            this.chk_NotActiveAfterPasswordExpires.Location = new System.Drawing.Point(11, 357);
            this.chk_NotActiveAfterPasswordExpires.Name = "chk_NotActiveAfterPasswordExpires";
            this.chk_NotActiveAfterPasswordExpires.Size = new System.Drawing.Size(175, 17);
            this.chk_NotActiveAfterPasswordExpires.TabIndex = 14;
            this.chk_NotActiveAfterPasswordExpires.Text = "NotActiveAfterPasswordExpires";
            this.chk_NotActiveAfterPasswordExpires.UseVisualStyleBackColor = true;
            // 
            // txt_NumberOfDays
            // 
            this.txt_NumberOfDays.Location = new System.Drawing.Point(223, 333);
            this.txt_NumberOfDays.Name = "txt_NumberOfDays";
            this.txt_NumberOfDays.ReadOnly = true;
            this.txt_NumberOfDays.Size = new System.Drawing.Size(148, 20);
            this.txt_NumberOfDays.TabIndex = 15;
            // 
            // lbl_last_user_password_definition_time
            // 
            this.lbl_last_user_password_definition_time.Location = new System.Drawing.Point(11, 390);
            this.lbl_last_user_password_definition_time.Name = "lbl_last_user_password_definition_time";
            this.lbl_last_user_password_definition_time.Size = new System.Drawing.Size(188, 17);
            this.lbl_last_user_password_definition_time.TabIndex = 16;
            this.lbl_last_user_password_definition_time.Text = "Last user password definition time";
            // 
            // txt_LastUserPasswordDefinitionTime
            // 
            this.txt_LastUserPasswordDefinitionTime.Location = new System.Drawing.Point(205, 387);
            this.txt_LastUserPasswordDefinitionTime.Name = "txt_LastUserPasswordDefinitionTime";
            this.txt_LastUserPasswordDefinitionTime.ReadOnly = true;
            this.txt_LastUserPasswordDefinitionTime.Size = new System.Drawing.Size(178, 20);
            this.txt_LastUserPasswordDefinitionTime.TabIndex = 17;
            // 
            // lbl_Password_expires_on
            // 
            this.lbl_Password_expires_on.Location = new System.Drawing.Point(428, 390);
            this.lbl_Password_expires_on.Name = "lbl_Password_expires_on";
            this.lbl_Password_expires_on.Size = new System.Drawing.Size(139, 17);
            this.lbl_Password_expires_on.TabIndex = 18;
            this.lbl_Password_expires_on.Text = "Password expires on:";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(392, 432);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(82, 23);
            this.btn_OK.TabIndex = 19;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_LoginHistory
            // 
            this.btn_LoginHistory.Location = new System.Drawing.Point(7, 432);
            this.btn_LoginHistory.Name = "btn_LoginHistory";
            this.btn_LoginHistory.Size = new System.Drawing.Size(270, 23);
            this.btn_LoginHistory.TabIndex = 20;
            this.btn_LoginHistory.Text = "History";
            this.btn_LoginHistory.UseVisualStyleBackColor = true;
            this.btn_LoginHistory.Click += new System.EventHandler(this.btn_LoginHistory_Click);
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 467);
            this.Controls.Add(this.btn_LoginHistory);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_Password_expires_on);
            this.Controls.Add(this.txt_LastUserPasswordDefinitionTime);
            this.Controls.Add(this.lbl_last_user_password_definition_time);
            this.Controls.Add(this.txt_NumberOfDays);
            this.Controls.Add(this.chk_NotActiveAfterPasswordExpires);
            this.Controls.Add(this.chk_PasswordExpiresInNumberOfDays);
            this.Controls.Add(this.chk_PasswordNeverExpires);
            this.Controls.Add(this.lbl_Roles);
            this.Controls.Add(this.dgv_Roles);
            this.Controls.Add(this.txt_Contact);
            this.Controls.Add(this.lbl_Contact);
            this.Controls.Add(this.txt_Identiy);
            this.Controls.Add(this.lbl_Identity);
            this.Controls.Add(this.txt_last_name);
            this.Controls.Add(this.lbl_last_name);
            this.Controls.Add(this.txt_first_name);
            this.Controls.Add(this.lbl_first_name);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.lbl_UserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserInfoForm";
            this.Load += new System.EventHandler(this.UserInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Roles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_first_name;
        private System.Windows.Forms.Label lbl_first_name;
        private System.Windows.Forms.TextBox txt_last_name;
        private System.Windows.Forms.Label lbl_last_name;
        private System.Windows.Forms.TextBox txt_Identiy;
        private System.Windows.Forms.Label lbl_Identity;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.Label lbl_Contact;
        private DataGridView_2xls.DataGridView2xls dgv_Roles;
        private System.Windows.Forms.Label lbl_Roles;
        private System.Windows.Forms.CheckBox chk_PasswordNeverExpires;
        private System.Windows.Forms.CheckBox chk_PasswordExpiresInNumberOfDays;
        private System.Windows.Forms.CheckBox chk_NotActiveAfterPasswordExpires;
        private System.Windows.Forms.TextBox txt_NumberOfDays;
        private System.Windows.Forms.Label lbl_last_user_password_definition_time;
        private System.Windows.Forms.TextBox txt_LastUserPasswordDefinitionTime;
        private System.Windows.Forms.Label lbl_Password_expires_on;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_LoginHistory;
    }
}