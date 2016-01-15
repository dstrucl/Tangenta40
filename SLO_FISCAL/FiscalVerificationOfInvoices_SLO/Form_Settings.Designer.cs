namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.chk_DebugAndTest = new System.Windows.Forms.CheckBox();
            this.lbl_CertificateFileName = new System.Windows.Forms.Label();
            this.txt_CertificateFile = new System.Windows.Forms.TextBox();
            this.btn_BrowseCertificateFile = new System.Windows.Forms.Button();
            this.txt_CertificatePassword = new System.Windows.Forms.TextBox();
            this.lbl_Certificate_Password = new System.Windows.Forms.Label();
            this.txt_fursWebServiceURL = new System.Windows.Forms.TextBox();
            this.lbl_fursWebServiceURL = new System.Windows.Forms.Label();
            this.txt_fursXmlNamespace = new System.Windows.Forms.TextBox();
            this.lbl_fursXmlNamespace = new System.Windows.Forms.Label();
            this.lbl_timeOutInSec = new System.Windows.Forms.Label();
            this.nm_UpDown_timeOutInSec = new System.Windows.Forms.NumericUpDown();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_timeOutInSec)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_DebugAndTest
            // 
            this.chk_DebugAndTest.AutoSize = true;
            this.chk_DebugAndTest.Location = new System.Drawing.Point(17, 10);
            this.chk_DebugAndTest.Name = "chk_DebugAndTest";
            this.chk_DebugAndTest.Size = new System.Drawing.Size(91, 17);
            this.chk_DebugAndTest.TabIndex = 0;
            this.chk_DebugAndTest.Text = "Debug && Test";
            this.chk_DebugAndTest.UseVisualStyleBackColor = true;
            // 
            // lbl_CertificateFileName
            // 
            this.lbl_CertificateFileName.AutoSize = true;
            this.lbl_CertificateFileName.Location = new System.Drawing.Point(18, 44);
            this.lbl_CertificateFileName.Name = "lbl_CertificateFileName";
            this.lbl_CertificateFileName.Size = new System.Drawing.Size(98, 13);
            this.lbl_CertificateFileName.TabIndex = 1;
            this.lbl_CertificateFileName.Text = "Datoteka Certifikat:";
            // 
            // txt_CertificateFile
            // 
            this.txt_CertificateFile.Location = new System.Drawing.Point(129, 41);
            this.txt_CertificateFile.Name = "txt_CertificateFile";
            this.txt_CertificateFile.Size = new System.Drawing.Size(340, 20);
            this.txt_CertificateFile.TabIndex = 2;
            // 
            // btn_BrowseCertificateFile
            // 
            this.btn_BrowseCertificateFile.Location = new System.Drawing.Point(488, 41);
            this.btn_BrowseCertificateFile.Name = "btn_BrowseCertificateFile";
            this.btn_BrowseCertificateFile.Size = new System.Drawing.Size(53, 20);
            this.btn_BrowseCertificateFile.TabIndex = 3;
            this.btn_BrowseCertificateFile.Text = "...";
            this.btn_BrowseCertificateFile.UseVisualStyleBackColor = true;
            this.btn_BrowseCertificateFile.Click += new System.EventHandler(this.btn_BrowseCertificateFile_Click);
            // 
            // txt_CertificatePassword
            // 
            this.txt_CertificatePassword.Location = new System.Drawing.Point(129, 76);
            this.txt_CertificatePassword.Name = "txt_CertificatePassword";
            this.txt_CertificatePassword.Size = new System.Drawing.Size(340, 20);
            this.txt_CertificatePassword.TabIndex = 5;
            // 
            // lbl_Certificate_Password
            // 
            this.lbl_Certificate_Password.AutoSize = true;
            this.lbl_Certificate_Password.Location = new System.Drawing.Point(18, 79);
            this.lbl_Certificate_Password.Name = "lbl_Certificate_Password";
            this.lbl_Certificate_Password.Size = new System.Drawing.Size(87, 13);
            this.lbl_Certificate_Password.TabIndex = 4;
            this.lbl_Certificate_Password.Text = "Certifikat GESLO";
            // 
            // txt_fursWebServiceURL
            // 
            this.txt_fursWebServiceURL.Location = new System.Drawing.Point(161, 118);
            this.txt_fursWebServiceURL.Name = "txt_fursWebServiceURL";
            this.txt_fursWebServiceURL.Size = new System.Drawing.Size(350, 20);
            this.txt_fursWebServiceURL.TabIndex = 7;
            // 
            // lbl_fursWebServiceURL
            // 
            this.lbl_fursWebServiceURL.AutoSize = true;
            this.lbl_fursWebServiceURL.Location = new System.Drawing.Point(18, 121);
            this.lbl_fursWebServiceURL.Name = "lbl_fursWebServiceURL";
            this.lbl_fursWebServiceURL.Size = new System.Drawing.Size(126, 13);
            this.lbl_fursWebServiceURL.TabIndex = 6;
            this.lbl_fursWebServiceURL.Text = "FURS Web servise URL:";
            // 
            // txt_fursXmlNamespace
            // 
            this.txt_fursXmlNamespace.Location = new System.Drawing.Point(192, 159);
            this.txt_fursXmlNamespace.Name = "txt_fursXmlNamespace";
            this.txt_fursXmlNamespace.Size = new System.Drawing.Size(340, 20);
            this.txt_fursXmlNamespace.TabIndex = 9;
            // 
            // lbl_fursXmlNamespace
            // 
            this.lbl_fursXmlNamespace.AutoSize = true;
            this.lbl_fursXmlNamespace.Location = new System.Drawing.Point(18, 162);
            this.lbl_fursXmlNamespace.Name = "lbl_fursXmlNamespace";
            this.lbl_fursXmlNamespace.Size = new System.Drawing.Size(124, 13);
            this.lbl_fursXmlNamespace.TabIndex = 8;
            this.lbl_fursXmlNamespace.Text = "FURS XML Namespace:";
            // 
            // lbl_timeOutInSec
            // 
            this.lbl_timeOutInSec.AutoSize = true;
            this.lbl_timeOutInSec.Location = new System.Drawing.Point(20, 207);
            this.lbl_timeOutInSec.Name = "lbl_timeOutInSec";
            this.lbl_timeOutInSec.Size = new System.Drawing.Size(252, 13);
            this.lbl_timeOutInSec.TabIndex = 10;
            this.lbl_timeOutInSec.Text = "Dovoljen čas (\"timeout\") za transakcijo v sekundah:";
            // 
            // nm_UpDown_timeOutInSec
            // 
            this.nm_UpDown_timeOutInSec.Location = new System.Drawing.Point(285, 207);
            this.nm_UpDown_timeOutInSec.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nm_UpDown_timeOutInSec.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nm_UpDown_timeOutInSec.Name = "nm_UpDown_timeOutInSec";
            this.nm_UpDown_timeOutInSec.Size = new System.Drawing.Size(184, 20);
            this.nm_UpDown_timeOutInSec.TabIndex = 11;
            this.nm_UpDown_timeOutInSec.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(155, 252);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 25);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(270, 251);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(87, 25);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "PREKINI";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 287);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.nm_UpDown_timeOutInSec);
            this.Controls.Add(this.lbl_timeOutInSec);
            this.Controls.Add(this.txt_fursXmlNamespace);
            this.Controls.Add(this.lbl_fursXmlNamespace);
            this.Controls.Add(this.txt_fursWebServiceURL);
            this.Controls.Add(this.lbl_fursWebServiceURL);
            this.Controls.Add(this.txt_CertificatePassword);
            this.Controls.Add(this.lbl_Certificate_Password);
            this.Controls.Add(this.btn_BrowseCertificateFile);
            this.Controls.Add(this.txt_CertificateFile);
            this.Controls.Add(this.lbl_CertificateFileName);
            this.Controls.Add(this.chk_DebugAndTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavitve za komunikacijo z DAVČNO UPRAVO";
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_timeOutInSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_DebugAndTest;
        private System.Windows.Forms.Label lbl_CertificateFileName;
        private System.Windows.Forms.TextBox txt_CertificateFile;
        private System.Windows.Forms.Button btn_BrowseCertificateFile;
        private System.Windows.Forms.TextBox txt_CertificatePassword;
        private System.Windows.Forms.Label lbl_Certificate_Password;
        private System.Windows.Forms.TextBox txt_fursWebServiceURL;
        private System.Windows.Forms.Label lbl_fursWebServiceURL;
        private System.Windows.Forms.TextBox txt_fursXmlNamespace;
        private System.Windows.Forms.Label lbl_fursXmlNamespace;
        private System.Windows.Forms.Label lbl_timeOutInSec;
        private System.Windows.Forms.NumericUpDown nm_UpDown_timeOutInSec;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}