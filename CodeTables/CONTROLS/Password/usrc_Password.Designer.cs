namespace Password
{
    partial class usrc_Password
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_Password));
            this.btn_PasswordView = new System.Windows.Forms.Button();
            this.chk_RememberPasswordInSession = new System.Windows.Forms.CheckBox();
            this.lbl_WrongPassword = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_EnterAdministratorPasword = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_PasswordView
            // 
            this.btn_PasswordView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PasswordView.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PasswordView.Image = ((System.Drawing.Image)(resources.GetObject("btn_PasswordView.Image")));
            this.btn_PasswordView.Location = new System.Drawing.Point(306, 22);
            this.btn_PasswordView.Name = "btn_PasswordView";
            this.btn_PasswordView.Size = new System.Drawing.Size(35, 21);
            this.btn_PasswordView.TabIndex = 13;
            this.btn_PasswordView.UseVisualStyleBackColor = false;
            this.btn_PasswordView.Click += new System.EventHandler(this.btn_PasswordView_Click);
            // 
            // chk_RememberPasswordInSession
            // 
            this.chk_RememberPasswordInSession.AutoSize = true;
            this.chk_RememberPasswordInSession.Location = new System.Drawing.Point(12, 68);
            this.chk_RememberPasswordInSession.Name = "chk_RememberPasswordInSession";
            this.chk_RememberPasswordInSession.Size = new System.Drawing.Size(80, 17);
            this.chk_RememberPasswordInSession.TabIndex = 12;
            this.chk_RememberPasswordInSession.Text = "checkBox1";
            this.chk_RememberPasswordInSession.UseVisualStyleBackColor = true;
            // 
            // lbl_WrongPassword
            // 
            this.lbl_WrongPassword.AutoSize = true;
            this.lbl_WrongPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_WrongPassword.Location = new System.Drawing.Point(12, 52);
            this.lbl_WrongPassword.Name = "lbl_WrongPassword";
            this.lbl_WrongPassword.Size = new System.Drawing.Size(88, 13);
            this.lbl_WrongPassword.TabIndex = 11;
            this.lbl_WrongPassword.Text = "Wrong Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(10, 23);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(288, 20);
            this.txt_Password.TabIndex = 10;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // lbl_EnterAdministratorPasword
            // 
            this.lbl_EnterAdministratorPasword.AutoSize = true;
            this.lbl_EnterAdministratorPasword.Location = new System.Drawing.Point(10, 7);
            this.lbl_EnterAdministratorPasword.Name = "lbl_EnterAdministratorPasword";
            this.lbl_EnterAdministratorPasword.Size = new System.Drawing.Size(144, 13);
            this.lbl_EnterAdministratorPasword.TabIndex = 9;
            this.lbl_EnterAdministratorPasword.Text = "Enter Administrator Password";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Location = new System.Drawing.Point(184, 91);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 32);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Location = new System.Drawing.Point(60, 91);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 32);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // usrc_Password
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_PasswordView);
            this.Controls.Add(this.chk_RememberPasswordInSession);
            this.Controls.Add(this.lbl_WrongPassword);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_EnterAdministratorPasword);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Name = "usrc_Password";
            this.Size = new System.Drawing.Size(347, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PasswordView;
        private System.Windows.Forms.CheckBox chk_RememberPasswordInSession;
        private System.Windows.Forms.Label lbl_WrongPassword;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_EnterAdministratorPasword;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Timer timer1;
    }
}
