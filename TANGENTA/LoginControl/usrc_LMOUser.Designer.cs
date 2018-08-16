namespace LoginControl
{
    partial class usrc_LMOUser
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
            this.txt_User = new System.Windows.Forms.TextBox();
            this.pic_administrator = new System.Windows.Forms.PictureBox();
            this.pic_UserManager = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_administrator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_UserManager)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_LoginLogout
            // 
            this.btn_LoginLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_LoginLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_LoginLogout.Location = new System.Drawing.Point(1, 1);
            this.btn_LoginLogout.Name = "btn_LoginLogout";
            this.btn_LoginLogout.Size = new System.Drawing.Size(115, 69);
            this.btn_LoginLogout.TabIndex = 0;
            this.btn_LoginLogout.Text = "Login";
            this.btn_LoginLogout.UseVisualStyleBackColor = true;
            this.btn_LoginLogout.Click += new System.EventHandler(this.btn_LoginLogout_Click);
            // 
            // btn_GetAccess
            // 
            this.btn_GetAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_GetAccess.Location = new System.Drawing.Point(380, 0);
            this.btn_GetAccess.Name = "btn_GetAccess";
            this.btn_GetAccess.Size = new System.Drawing.Size(210, 69);
            this.btn_GetAccess.TabIndex = 1;
            this.btn_GetAccess.Text = "Get Access";
            this.btn_GetAccess.UseVisualStyleBackColor = true;
            this.btn_GetAccess.Click += new System.EventHandler(this.btn_GetAccess_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(273, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txt_User
            // 
            this.txt_User.BackColor = System.Drawing.SystemColors.Info;
            this.txt_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_User.Location = new System.Drawing.Point(121, 31);
            this.txt_User.Multiline = true;
            this.txt_User.Name = "txt_User";
            this.txt_User.ReadOnly = true;
            this.txt_User.Size = new System.Drawing.Size(146, 37);
            this.txt_User.TabIndex = 3;
            this.txt_User.Text = "User";
            // 
            // pic_administrator
            // 
            this.pic_administrator.Location = new System.Drawing.Point(121, 4);
            this.pic_administrator.Name = "pic_administrator";
            this.pic_administrator.Size = new System.Drawing.Size(30, 23);
            this.pic_administrator.TabIndex = 4;
            this.pic_administrator.TabStop = false;
            // 
            // pic_UserManager
            // 
            this.pic_UserManager.Location = new System.Drawing.Point(157, 5);
            this.pic_UserManager.Name = "pic_UserManager";
            this.pic_UserManager.Size = new System.Drawing.Size(30, 23);
            this.pic_UserManager.TabIndex = 5;
            this.pic_UserManager.TabStop = false;
            // 
            // usrc_LMOUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.pic_UserManager);
            this.Controls.Add(this.pic_administrator);
            this.Controls.Add(this.txt_User);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_GetAccess);
            this.Controls.Add(this.btn_LoginLogout);
            this.Name = "usrc_LMOUser";
            this.Size = new System.Drawing.Size(593, 70);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_administrator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_UserManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_LoginLogout;
        internal System.Windows.Forms.Button btn_GetAccess;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.TextBox txt_User;
        internal System.Windows.Forms.PictureBox pic_administrator;
        internal System.Windows.Forms.PictureBox pic_UserManager;
    }
}
