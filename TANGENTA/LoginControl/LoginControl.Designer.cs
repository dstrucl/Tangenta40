namespace LoginControl
{
    partial class LoginControl
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
            this.lbl_username = new System.Windows.Forms.Label();
            this.btn_UserInfo = new System.Windows.Forms.Button();
            this.btn_UserManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(4, 4);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(35, 13);
            this.lbl_username.TabIndex = 0;
            this.lbl_username.Text = "label1";
            // 
            // btn_UserInfo
            // 
            this.btn_UserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UserInfo.Location = new System.Drawing.Point(364, -1);
            this.btn_UserInfo.Name = "btn_UserInfo";
            this.btn_UserInfo.Size = new System.Drawing.Size(95, 22);
            this.btn_UserInfo.TabIndex = 1;
            this.btn_UserInfo.Text = "User Info";
            this.btn_UserInfo.UseVisualStyleBackColor = true;
            this.btn_UserInfo.Click += new System.EventHandler(this.btn_UserInfo_Click);
            // 
            // btn_UserManager
            // 
            this.btn_UserManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UserManager.Location = new System.Drawing.Point(241, -1);
            this.btn_UserManager.Name = "btn_UserManager";
            this.btn_UserManager.Size = new System.Drawing.Size(117, 22);
            this.btn_UserManager.TabIndex = 2;
            this.btn_UserManager.Text = "User Manager";
            this.btn_UserManager.UseVisualStyleBackColor = true;
            this.btn_UserManager.Visible = false;
            this.btn_UserManager.Click += new System.EventHandler(this.btn_UserManager_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_UserManager);
            this.Controls.Add(this.btn_UserInfo);
            this.Controls.Add(this.lbl_username);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(460, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_username;
        public System.Windows.Forms.Button btn_UserInfo;
        public System.Windows.Forms.Button btn_UserManager;



    }
}
