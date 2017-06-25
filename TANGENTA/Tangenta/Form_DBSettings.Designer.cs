namespace Tangenta
{
    partial class Form_DBSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DBSettings));
            this.lbl_Administrator_Password = new System.Windows.Forms.Label();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.usrc_Password1 = new Password.usrc_PasswordDefinition();
            this.chk_StockCheckAtStartup = new System.Windows.Forms.CheckBox();
            this.chk_MultiUserOperation = new System.Windows.Forms.CheckBox();
            this.lbl_DataBaseVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Administrator_Password
            // 
            this.lbl_Administrator_Password.AutoSize = true;
            this.lbl_Administrator_Password.Location = new System.Drawing.Point(14, 32);
            this.lbl_Administrator_Password.Name = "lbl_Administrator_Password";
            this.lbl_Administrator_Password.Size = new System.Drawing.Size(116, 13);
            this.lbl_Administrator_Password.TabIndex = 1;
            this.lbl_Administrator_Password.Text = "Administrator Password";
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(3, 170);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(280, 63);
            this.usrc_NavigationButtons1.TabIndex = 2;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // usrc_Password1
            // 
            this.usrc_Password1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.usrc_Password1.Location = new System.Drawing.Point(12, 49);
            this.usrc_Password1.MaxLength = 5;
            this.usrc_Password1.MinPasswordLength = 5;
            this.usrc_Password1.Name = "usrc_Password1";
            this.usrc_Password1.PasswordLocked = true;
            this.usrc_Password1.ReadOnly = false;
            this.usrc_Password1.Size = new System.Drawing.Size(245, 67);
            this.usrc_Password1.TabIndex = 0;
            // 
            // chk_StockCheckAtStartup
            // 
            this.chk_StockCheckAtStartup.AutoSize = true;
            this.chk_StockCheckAtStartup.Location = new System.Drawing.Point(17, 145);
            this.chk_StockCheckAtStartup.Name = "chk_StockCheckAtStartup";
            this.chk_StockCheckAtStartup.Size = new System.Drawing.Size(138, 17);
            this.chk_StockCheckAtStartup.TabIndex = 3;
            this.chk_StockCheckAtStartup.Text = "Stock Check At Startup";
            this.chk_StockCheckAtStartup.UseVisualStyleBackColor = true;
            // 
            // chk_MultiUserOperation
            // 
            this.chk_MultiUserOperation.AutoSize = true;
            this.chk_MultiUserOperation.Location = new System.Drawing.Point(17, 122);
            this.chk_MultiUserOperation.Name = "chk_MultiUserOperation";
            this.chk_MultiUserOperation.Size = new System.Drawing.Size(118, 17);
            this.chk_MultiUserOperation.TabIndex = 4;
            this.chk_MultiUserOperation.Text = "Multi user operation";
            this.chk_MultiUserOperation.UseVisualStyleBackColor = true;
            // 
            // lbl_DataBaseVersion
            // 
            this.lbl_DataBaseVersion.AutoSize = true;
            this.lbl_DataBaseVersion.Location = new System.Drawing.Point(16, 5);
            this.lbl_DataBaseVersion.Name = "lbl_DataBaseVersion";
            this.lbl_DataBaseVersion.Size = new System.Drawing.Size(95, 13);
            this.lbl_DataBaseVersion.TabIndex = 5;
            this.lbl_DataBaseVersion.Text = "Data Base Version";
            // 
            // Form_DBSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(288, 233);
            this.Controls.Add(this.lbl_DataBaseVersion);
            this.Controls.Add(this.chk_MultiUserOperation);
            this.Controls.Add(this.chk_StockCheckAtStartup);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.lbl_Administrator_Password);
            this.Controls.Add(this.usrc_Password1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DBSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Password.usrc_PasswordDefinition usrc_Password1;
        private System.Windows.Forms.Label lbl_Administrator_Password;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.CheckBox chk_StockCheckAtStartup;
        private System.Windows.Forms.CheckBox chk_MultiUserOperation;
        private System.Windows.Forms.Label lbl_DataBaseVersion;
    }
}