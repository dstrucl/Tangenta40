﻿namespace LoginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
            this.lbl_username = new System.Windows.Forms.Label();
            this.btn_UserInfo = new System.Windows.Forms.Button();
            this.btn_UserManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_username
            // 
            this.lbl_username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_username.Location = new System.Drawing.Point(6, -1);
            this.lbl_username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(188, 45);
            this.lbl_username.TabIndex = 0;
            this.lbl_username.Text = "label1";
            this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_UserInfo
            // 
            this.btn_UserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UserInfo.Image = ((System.Drawing.Image)(resources.GetObject("btn_UserInfo.Image")));
            this.btn_UserInfo.Location = new System.Drawing.Point(197, -1);
            this.btn_UserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_UserInfo.Name = "btn_UserInfo";
            this.btn_UserInfo.Size = new System.Drawing.Size(37, 46);
            this.btn_UserInfo.TabIndex = 1;
            this.btn_UserInfo.UseVisualStyleBackColor = true;
            this.btn_UserInfo.Click += new System.EventHandler(this.btn_UserInfo_Click);
            // 
            // btn_UserManager
            // 
            this.btn_UserManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_UserManager.Image = ((System.Drawing.Image)(resources.GetObject("btn_UserManager.Image")));
            this.btn_UserManager.Location = new System.Drawing.Point(236, -1);
            this.btn_UserManager.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_UserManager.Name = "btn_UserManager";
            this.btn_UserManager.Size = new System.Drawing.Size(38, 46);
            this.btn_UserManager.TabIndex = 2;
            this.btn_UserManager.UseVisualStyleBackColor = true;
            this.btn_UserManager.Visible = false;
            this.btn_UserManager.Click += new System.EventHandler(this.btn_UserManager_Click);
            // 
            // LoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn_UserManager);
            this.Controls.Add(this.btn_UserInfo);
            this.Controls.Add(this.lbl_username);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginControl";
            this.Size = new System.Drawing.Size(275, 44);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_username;
        public System.Windows.Forms.Button btn_UserInfo;
        public System.Windows.Forms.Button btn_UserManager;



    }
}
