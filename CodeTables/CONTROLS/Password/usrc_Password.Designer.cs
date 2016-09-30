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
            this.txt_Password = new TextBoxRecent.TextBoxR();
            this.txt_Password_Retyped = new TextBoxRecent.TextBoxR();
            this.lbl_Retype_Password = new System.Windows.Forms.Label();
            this.btn_PasswordView = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.Location = new System.Drawing.Point(3, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(219, 20);
            this.txt_Password.TabIndex = 0;
            this.txt_Password.UseSystemPasswordChar = true;
            this.txt_Password.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            // 
            // txt_Password_Retyped
            // 
            this.txt_Password_Retyped.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password_Retyped.Location = new System.Drawing.Point(3, 44);
            this.txt_Password_Retyped.Name = "txt_Password_Retyped";
            this.txt_Password_Retyped.Size = new System.Drawing.Size(219, 20);
            this.txt_Password_Retyped.TabIndex = 1;
            this.txt_Password_Retyped.UseSystemPasswordChar = true;
            // 
            // lbl_Retype_Password
            // 
            this.lbl_Retype_Password.AutoSize = true;
            this.lbl_Retype_Password.Location = new System.Drawing.Point(4, 27);
            this.lbl_Retype_Password.Name = "lbl_Retype_Password";
            this.lbl_Retype_Password.Size = new System.Drawing.Size(92, 13);
            this.lbl_Retype_Password.TabIndex = 2;
            this.lbl_Retype_Password.Text = "Retype password:";
            // 
            // btn_PasswordView
            // 
            this.btn_PasswordView.Image = ((System.Drawing.Image)(resources.GetObject("btn_PasswordView.Image")));
            this.btn_PasswordView.Location = new System.Drawing.Point(187, 23);
            this.btn_PasswordView.Name = "btn_PasswordView";
            this.btn_PasswordView.Size = new System.Drawing.Size(35, 21);
            this.btn_PasswordView.TabIndex = 3;
            this.btn_PasswordView.UseVisualStyleBackColor = true;
            this.btn_PasswordView.Click += new System.EventHandler(this.btn_PasswordView_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // usrc_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.btn_PasswordView);
            this.Controls.Add(this.lbl_Retype_Password);
            this.Controls.Add(this.txt_Password_Retyped);
            this.Controls.Add(this.txt_Password);
            this.Name = "usrc_Password";
            this.Size = new System.Drawing.Size(226, 67);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxRecent.TextBoxR txt_Password;
        private TextBoxRecent.TextBoxR txt_Password_Retyped;
        private System.Windows.Forms.Label lbl_Retype_Password;
        private System.Windows.Forms.Button btn_PasswordView;
        private System.Windows.Forms.Timer timer1;
    }
}
