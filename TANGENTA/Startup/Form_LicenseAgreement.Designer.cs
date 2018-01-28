namespace Startup
{
    partial class Form_LicenseAgreement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LicenseAgreement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_NotAcceptLicenseAgreement = new System.Windows.Forms.RadioButton();
            this.rdb_AcceptLicenseAgreement = new System.Windows.Forms.RadioButton();
            this.btn_Print = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdb_NotAcceptLicenseAgreement);
            this.groupBox1.Controls.Add(this.rdb_AcceptLicenseAgreement);
            this.groupBox1.Location = new System.Drawing.Point(3, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdb_NotAcceptLicenseAgreement
            // 
            this.rdb_NotAcceptLicenseAgreement.AutoSize = true;
            this.rdb_NotAcceptLicenseAgreement.Location = new System.Drawing.Point(7, 33);
            this.rdb_NotAcceptLicenseAgreement.Name = "rdb_NotAcceptLicenseAgreement";
            this.rdb_NotAcceptLicenseAgreement.Size = new System.Drawing.Size(173, 17);
            this.rdb_NotAcceptLicenseAgreement.TabIndex = 5;
            this.rdb_NotAcceptLicenseAgreement.Text = "Not Accept License Agreement";
            this.rdb_NotAcceptLicenseAgreement.UseVisualStyleBackColor = true;
            // 
            // rdb_AcceptLicenseAgreement
            // 
            this.rdb_AcceptLicenseAgreement.AutoSize = true;
            this.rdb_AcceptLicenseAgreement.Location = new System.Drawing.Point(7, 12);
            this.rdb_AcceptLicenseAgreement.Name = "rdb_AcceptLicenseAgreement";
            this.rdb_AcceptLicenseAgreement.Size = new System.Drawing.Size(153, 17);
            this.rdb_AcceptLicenseAgreement.TabIndex = 4;
            this.rdb_AcceptLicenseAgreement.Text = "Accept License Agreement";
            this.rdb_AcceptLicenseAgreement.UseVisualStyleBackColor = true;
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Print.Location = new System.Drawing.Point(187, 416);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(216, 27);
            this.btn_Print.TabIndex = 4;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(2, 30);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(22, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(599, 327);
            this.webBrowser1.TabIndex = 5;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, 0);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(602, 27);
            this.usrc_NavigationButtons1.TabIndex = 6;
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
            // Form_LicenseAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(603, 449);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_LicenseAgreement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Agreement";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_NotAcceptLicenseAgreement;
        private System.Windows.Forms.RadioButton rdb_AcceptLicenseAgreement;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}