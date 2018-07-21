namespace LoginControl
{
    partial class usrc_LoginOfMyOrgUser
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
            this.btn_LoginLogout = new System.Windows.Forms.Button();
            this.btn_GetAccess = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_User = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoginLogout
            // 
            this.btn_LoginLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LoginLogout.Location = new System.Drawing.Point(3, 1);
            this.btn_LoginLogout.Name = "btn_LoginLogout";
            this.btn_LoginLogout.Size = new System.Drawing.Size(90, 131);
            this.btn_LoginLogout.TabIndex = 0;
            this.btn_LoginLogout.Text = "Login";
            this.btn_LoginLogout.UseVisualStyleBackColor = true;
            // 
            // btn_GetAccess
            // 
            this.btn_GetAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetAccess.Location = new System.Drawing.Point(201, 3);
            this.btn_GetAccess.Name = "btn_GetAccess";
            this.btn_GetAccess.Size = new System.Drawing.Size(89, 128);
            this.btn_GetAccess.TabIndex = 1;
            this.btn_GetAccess.Text = "Get Access";
            this.btn_GetAccess.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(99, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 90);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_User
            // 
            this.lbl_User.Location = new System.Drawing.Point(99, 5);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(95, 32);
            this.lbl_User.TabIndex = 3;
            this.lbl_User.Text = "User";
            // 
            // usrc_LoginOfMyOrgPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.lbl_User);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_GetAccess);
            this.Controls.Add(this.btn_LoginLogout);
            this.Name = "usrc_LoginOfMyOrgPerson";
            this.Size = new System.Drawing.Size(293, 134);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LoginLogout;
        private System.Windows.Forms.Button btn_GetAccess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_User;
    }
}
