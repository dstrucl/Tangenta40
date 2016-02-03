namespace FiscalVerificationOfInvoices_SLO
{
    partial class usrc_FURS_environment_settings
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
            this.txt_fursXmlNamespace = new System.Windows.Forms.TextBox();
            this.lbl_fursXmlNamespace = new System.Windows.Forms.Label();
            this.txt_fursWebServiceURL = new System.Windows.Forms.TextBox();
            this.lbl_fursWebServiceURL = new System.Windows.Forms.Label();
            this.txt_CertificatePassword = new System.Windows.Forms.TextBox();
            this.lbl_Certificate_Password = new System.Windows.Forms.Label();
            this.btn_BrowseCertificateFile = new System.Windows.Forms.Button();
            this.txt_CertificateFile = new System.Windows.Forms.TextBox();
            this.lbl_CertificateFileName = new System.Windows.Forms.Label();
            this.lbl_Environment = new System.Windows.Forms.Label();
            this.usrc_FURS_BussinesPremiseData1 = new FiscalVerificationOfInvoices_SLO.usrc_FURS_BussinesPremiseData();
            this.SuspendLayout();
            // 
            // txt_fursXmlNamespace
            // 
            this.txt_fursXmlNamespace.Location = new System.Drawing.Point(140, 78);
            this.txt_fursXmlNamespace.Name = "txt_fursXmlNamespace";
            this.txt_fursXmlNamespace.Size = new System.Drawing.Size(281, 20);
            this.txt_fursXmlNamespace.TabIndex = 18;
            // 
            // lbl_fursXmlNamespace
            // 
            this.lbl_fursXmlNamespace.AutoSize = true;
            this.lbl_fursXmlNamespace.Location = new System.Drawing.Point(5, 81);
            this.lbl_fursXmlNamespace.Name = "lbl_fursXmlNamespace";
            this.lbl_fursXmlNamespace.Size = new System.Drawing.Size(124, 13);
            this.lbl_fursXmlNamespace.TabIndex = 17;
            this.lbl_fursXmlNamespace.Text = "FURS XML Namespace:";
            // 
            // txt_fursWebServiceURL
            // 
            this.txt_fursWebServiceURL.Location = new System.Drawing.Point(140, 50);
            this.txt_fursWebServiceURL.Name = "txt_fursWebServiceURL";
            this.txt_fursWebServiceURL.Size = new System.Drawing.Size(281, 20);
            this.txt_fursWebServiceURL.TabIndex = 16;
            // 
            // lbl_fursWebServiceURL
            // 
            this.lbl_fursWebServiceURL.AutoSize = true;
            this.lbl_fursWebServiceURL.Location = new System.Drawing.Point(5, 53);
            this.lbl_fursWebServiceURL.Name = "lbl_fursWebServiceURL";
            this.lbl_fursWebServiceURL.Size = new System.Drawing.Size(126, 13);
            this.lbl_fursWebServiceURL.TabIndex = 15;
            this.lbl_fursWebServiceURL.Text = "FURS Web servise URL:";
            // 
            // txt_CertificatePassword
            // 
            this.txt_CertificatePassword.Location = new System.Drawing.Point(502, 22);
            this.txt_CertificatePassword.Name = "txt_CertificatePassword";
            this.txt_CertificatePassword.Size = new System.Drawing.Size(148, 20);
            this.txt_CertificatePassword.TabIndex = 14;
            // 
            // lbl_Certificate_Password
            // 
            this.lbl_Certificate_Password.AutoSize = true;
            this.lbl_Certificate_Password.Location = new System.Drawing.Point(453, 25);
            this.lbl_Certificate_Password.Name = "lbl_Certificate_Password";
            this.lbl_Certificate_Password.Size = new System.Drawing.Size(43, 13);
            this.lbl_Certificate_Password.TabIndex = 13;
            this.lbl_Certificate_Password.Text = "GESLO";
            // 
            // btn_BrowseCertificateFile
            // 
            this.btn_BrowseCertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BrowseCertificateFile.Location = new System.Drawing.Point(403, 21);
            this.btn_BrowseCertificateFile.Name = "btn_BrowseCertificateFile";
            this.btn_BrowseCertificateFile.Size = new System.Drawing.Size(21, 20);
            this.btn_BrowseCertificateFile.TabIndex = 12;
            this.btn_BrowseCertificateFile.Text = "...";
            this.btn_BrowseCertificateFile.UseVisualStyleBackColor = true;
            this.btn_BrowseCertificateFile.Click += new System.EventHandler(this.btn_BrowseCertificateFile_Click);
            // 
            // txt_CertificateFile
            // 
            this.txt_CertificateFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CertificateFile.Location = new System.Drawing.Point(140, 21);
            this.txt_CertificateFile.Name = "txt_CertificateFile";
            this.txt_CertificateFile.Size = new System.Drawing.Size(267, 20);
            this.txt_CertificateFile.TabIndex = 11;
            // 
            // lbl_CertificateFileName
            // 
            this.lbl_CertificateFileName.AutoSize = true;
            this.lbl_CertificateFileName.Location = new System.Drawing.Point(5, 24);
            this.lbl_CertificateFileName.Name = "lbl_CertificateFileName";
            this.lbl_CertificateFileName.Size = new System.Drawing.Size(98, 13);
            this.lbl_CertificateFileName.TabIndex = 10;
            this.lbl_CertificateFileName.Text = "Datoteka Certifikat:";
            // 
            // lbl_Environment
            // 
            this.lbl_Environment.AutoSize = true;
            this.lbl_Environment.Location = new System.Drawing.Point(5, 0);
            this.lbl_Environment.Name = "lbl_Environment";
            this.lbl_Environment.Size = new System.Drawing.Size(82, 13);
            this.lbl_Environment.TabIndex = 19;
            this.lbl_Environment.Text = "lbl_Environment";
            // 
            // usrc_FURS_BussinesPremiseData1
            // 
            this.usrc_FURS_BussinesPremiseData1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FURS_BussinesPremiseData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_FURS_BussinesPremiseData1.Location = new System.Drawing.Point(-1, 104);
            this.usrc_FURS_BussinesPremiseData1.Name = "usrc_FURS_BussinesPremiseData1";
            this.usrc_FURS_BussinesPremiseData1.ReadOnly = false;
            this.usrc_FURS_BussinesPremiseData1.Size = new System.Drawing.Size(667, 235);
            this.usrc_FURS_BussinesPremiseData1.TabIndex = 20;
            // 
            // usrc_FURS_environment_settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.usrc_FURS_BussinesPremiseData1);
            this.Controls.Add(this.lbl_Environment);
            this.Controls.Add(this.txt_fursXmlNamespace);
            this.Controls.Add(this.lbl_fursXmlNamespace);
            this.Controls.Add(this.txt_fursWebServiceURL);
            this.Controls.Add(this.lbl_fursWebServiceURL);
            this.Controls.Add(this.txt_CertificatePassword);
            this.Controls.Add(this.lbl_Certificate_Password);
            this.Controls.Add(this.btn_BrowseCertificateFile);
            this.Controls.Add(this.txt_CertificateFile);
            this.Controls.Add(this.lbl_CertificateFileName);
            this.Name = "usrc_FURS_environment_settings";
            this.Size = new System.Drawing.Size(665, 342);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_fursXmlNamespace;
        private System.Windows.Forms.Label lbl_fursXmlNamespace;
        private System.Windows.Forms.TextBox txt_fursWebServiceURL;
        private System.Windows.Forms.Label lbl_fursWebServiceURL;
        private System.Windows.Forms.TextBox txt_CertificatePassword;
        private System.Windows.Forms.Label lbl_Certificate_Password;
        private System.Windows.Forms.Button btn_BrowseCertificateFile;
        private System.Windows.Forms.TextBox txt_CertificateFile;
        private System.Windows.Forms.Label lbl_CertificateFileName;
        private System.Windows.Forms.Label lbl_Environment;
        private usrc_FURS_BussinesPremiseData usrc_FURS_BussinesPremiseData1;
    }
}
