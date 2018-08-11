namespace LoginControl
{
    partial class usrc_IdleSettings
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
            this.chk_ShowIdleControl = new System.Windows.Forms.CheckBox();
            this.lbl_TimeInSecondsToActivateIdleControl = new System.Windows.Forms.Label();
            this.nmUpDn_TimeInSecondsToActivateIdleControl = new System.Windows.Forms.NumericUpDown();
            this.chk_ExitWithButton = new System.Windows.Forms.CheckBox();
            this.lbl_URL1 = new System.Windows.Forms.Label();
            this.txt_URL1 = new System.Windows.Forms.TextBox();
            this.txt_URL2 = new System.Windows.Forms.TextBox();
            this.lbl_URL2 = new System.Windows.Forms.Label();
            this.chk_ShowURL2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_TimeInSecondsToActivateIdleControl)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_ShowIdleControl
            // 
            this.chk_ShowIdleControl.AutoSize = true;
            this.chk_ShowIdleControl.Location = new System.Drawing.Point(15, 7);
            this.chk_ShowIdleControl.Name = "chk_ShowIdleControl";
            this.chk_ShowIdleControl.Size = new System.Drawing.Size(109, 17);
            this.chk_ShowIdleControl.TabIndex = 0;
            this.chk_ShowIdleControl.Text = "Show Idle Control";
            this.chk_ShowIdleControl.UseVisualStyleBackColor = true;
            // 
            // lbl_TimeInSecondsToActivateIdleControl
            // 
            this.lbl_TimeInSecondsToActivateIdleControl.Location = new System.Drawing.Point(16, 35);
            this.lbl_TimeInSecondsToActivateIdleControl.Name = "lbl_TimeInSecondsToActivateIdleControl";
            this.lbl_TimeInSecondsToActivateIdleControl.Size = new System.Drawing.Size(226, 13);
            this.lbl_TimeInSecondsToActivateIdleControl.TabIndex = 1;
            this.lbl_TimeInSecondsToActivateIdleControl.Text = "Time In Seconds To Activate Idle Control";
            this.lbl_TimeInSecondsToActivateIdleControl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nmUpDn_TimeInSecondsToActivateIdleControl
            // 
            this.nmUpDn_TimeInSecondsToActivateIdleControl.Location = new System.Drawing.Point(248, 33);
            this.nmUpDn_TimeInSecondsToActivateIdleControl.Name = "nmUpDn_TimeInSecondsToActivateIdleControl";
            this.nmUpDn_TimeInSecondsToActivateIdleControl.Size = new System.Drawing.Size(62, 20);
            this.nmUpDn_TimeInSecondsToActivateIdleControl.TabIndex = 2;
            // 
            // chk_ExitWithButton
            // 
            this.chk_ExitWithButton.AutoSize = true;
            this.chk_ExitWithButton.Location = new System.Drawing.Point(15, 60);
            this.chk_ExitWithButton.Name = "chk_ExitWithButton";
            this.chk_ExitWithButton.Size = new System.Drawing.Size(98, 17);
            this.chk_ExitWithButton.TabIndex = 3;
            this.chk_ExitWithButton.Text = "Exit with button";
            this.chk_ExitWithButton.UseVisualStyleBackColor = true;
            // 
            // lbl_URL1
            // 
            this.lbl_URL1.Location = new System.Drawing.Point(16, 86);
            this.lbl_URL1.Name = "lbl_URL1";
            this.lbl_URL1.Size = new System.Drawing.Size(97, 13);
            this.lbl_URL1.TabIndex = 4;
            this.lbl_URL1.Text = "URL1:";
            this.lbl_URL1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_URL1
            // 
            this.txt_URL1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_URL1.Location = new System.Drawing.Point(119, 83);
            this.txt_URL1.Name = "txt_URL1";
            this.txt_URL1.Size = new System.Drawing.Size(305, 20);
            this.txt_URL1.TabIndex = 5;
            // 
            // txt_URL2
            // 
            this.txt_URL2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_URL2.Location = new System.Drawing.Point(65, 144);
            this.txt_URL2.Name = "txt_URL2";
            this.txt_URL2.Size = new System.Drawing.Size(359, 20);
            this.txt_URL2.TabIndex = 7;
            // 
            // lbl_URL2
            // 
            this.lbl_URL2.Location = new System.Drawing.Point(16, 147);
            this.lbl_URL2.Name = "lbl_URL2";
            this.lbl_URL2.Size = new System.Drawing.Size(43, 13);
            this.lbl_URL2.TabIndex = 6;
            this.lbl_URL2.Text = "URL2:";
            this.lbl_URL2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chk_ShowURL2
            // 
            this.chk_ShowURL2.AutoSize = true;
            this.chk_ShowURL2.Location = new System.Drawing.Point(19, 121);
            this.chk_ShowURL2.Name = "chk_ShowURL2";
            this.chk_ShowURL2.Size = new System.Drawing.Size(84, 17);
            this.chk_ShowURL2.TabIndex = 8;
            this.chk_ShowURL2.Text = "Show URL2";
            this.chk_ShowURL2.UseVisualStyleBackColor = true;
            // 
            // usrc_IdleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chk_ShowURL2);
            this.Controls.Add(this.txt_URL2);
            this.Controls.Add(this.lbl_URL2);
            this.Controls.Add(this.txt_URL1);
            this.Controls.Add(this.lbl_URL1);
            this.Controls.Add(this.chk_ExitWithButton);
            this.Controls.Add(this.nmUpDn_TimeInSecondsToActivateIdleControl);
            this.Controls.Add(this.lbl_TimeInSecondsToActivateIdleControl);
            this.Controls.Add(this.chk_ShowIdleControl);
            this.Name = "usrc_IdleSettings";
            this.Size = new System.Drawing.Size(431, 187);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_TimeInSecondsToActivateIdleControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_ShowIdleControl;
        private System.Windows.Forms.Label lbl_TimeInSecondsToActivateIdleControl;
        private System.Windows.Forms.NumericUpDown nmUpDn_TimeInSecondsToActivateIdleControl;
        private System.Windows.Forms.CheckBox chk_ExitWithButton;
        private System.Windows.Forms.Label lbl_URL1;
        private System.Windows.Forms.TextBox txt_URL1;
        private System.Windows.Forms.TextBox txt_URL2;
        private System.Windows.Forms.Label lbl_URL2;
        private System.Windows.Forms.CheckBox chk_ShowURL2;
    }
}
