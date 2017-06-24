namespace Password
{
    partial class Form_AskForPassword
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_EnterAdministratorPasword = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.lbl_WrongPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(59, 87);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 32);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(195, 87);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 32);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_EnterAdministratorPasword
            // 
            this.lbl_EnterAdministratorPasword.AutoSize = true;
            this.lbl_EnterAdministratorPasword.Location = new System.Drawing.Point(12, 9);
            this.lbl_EnterAdministratorPasword.Name = "lbl_EnterAdministratorPasword";
            this.lbl_EnterAdministratorPasword.Size = new System.Drawing.Size(144, 13);
            this.lbl_EnterAdministratorPasword.TabIndex = 2;
            this.lbl_EnterAdministratorPasword.Text = "Enter Administrator Password";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(7, 32);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(317, 20);
            this.txt_Password.TabIndex = 3;
            // 
            // lbl_WrongPassword
            // 
            this.lbl_WrongPassword.AutoSize = true;
            this.lbl_WrongPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_WrongPassword.Location = new System.Drawing.Point(11, 58);
            this.lbl_WrongPassword.Name = "lbl_WrongPassword";
            this.lbl_WrongPassword.Size = new System.Drawing.Size(88, 13);
            this.lbl_WrongPassword.TabIndex = 4;
            this.lbl_WrongPassword.Text = "Wrong Password";
            // 
            // Form_AskForPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(342, 131);
            this.Controls.Add(this.lbl_WrongPassword);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.lbl_EnterAdministratorPasword);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_AskForPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AskForPassword";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_EnterAdministratorPasword;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label lbl_WrongPassword;
    }
}