namespace Tangenta
{
    partial class usrc_Main
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_Printer1 = new Tangenta.usrc_Printer();
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.m_usrc_Help = new usrc_Help.usrc_Help();
            this.m_usrc_DBSettings = new Tangenta.usrc_Settings();
            this.m_usrc_InvoiceMan = new Tangenta.usrc_InvoiceMan();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(850, 1);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(63, 31);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_Printer1
            // 
            this.usrc_Printer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Printer1.Location = new System.Drawing.Point(714, 1);
            this.usrc_Printer1.Name = "usrc_Printer1";
            this.usrc_Printer1.PaperName = null;
            this.usrc_Printer1.Size = new System.Drawing.Size(39, 31);
            this.usrc_Printer1.TabIndex = 7;
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FVI_SLO1.FursCertificateFileName = "";
            this.usrc_FVI_SLO1.FursCertificatePassword = "";
            this.usrc_FVI_SLO1.FursD_BuildingNumber = "";
            this.usrc_FVI_SLO1.FursD_BuildingSectionNumber = "";
            this.usrc_FVI_SLO1.FursD_BussinesPremiseID = "KUNAVE6";
            this.usrc_FVI_SLO1.FursD_CadastralNumber = "";
            this.usrc_FVI_SLO1.FursD_ClosingTag = "";
            this.usrc_FVI_SLO1.FursD_Community = "";
            this.usrc_FVI_SLO1.FursD_ElectronicDeviceID = null;
            this.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID = "10329048";
            this.usrc_FVI_SLO1.FursD_MyOrgTaxID = "10329048";
            this.usrc_FVI_SLO1.FursD_PremiseType = "99999999";
            this.usrc_FVI_SLO1.FursD_SoftwareSupplierTaxID = "99999999";
            this.usrc_FVI_SLO1.FursD_ValidityDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.usrc_FVI_SLO1.FursWebServiceURL = "https://blagajne.fu.gov.si:9003/v1/cash_registers";
            this.usrc_FVI_SLO1.FursXmlNamespace = "http://www.fu.gov.si/";
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(669, 1);
            this.usrc_FVI_SLO1.MessageBox_Length = 100;
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(39, 31);
            this.usrc_FVI_SLO1.TabIndex = 6;
            // 
            // m_usrc_Help
            // 
            this.m_usrc_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Help.Location = new System.Drawing.Point(804, 1);
            this.m_usrc_Help.Name = "m_usrc_Help";
            this.m_usrc_Help.Size = new System.Drawing.Size(40, 31);
            this.m_usrc_Help.TabIndex = 5;
            // 
            // m_usrc_DBSettings
            // 
            this.m_usrc_DBSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_DBSettings.Location = new System.Drawing.Point(759, 1);
            this.m_usrc_DBSettings.Name = "m_usrc_DBSettings";
            this.m_usrc_DBSettings.Size = new System.Drawing.Size(39, 31);
            this.m_usrc_DBSettings.TabIndex = 4;
            this.m_usrc_DBSettings.Backup += new Tangenta.usrc_Settings.delegate_Backup(this.m_usrc_DBSettings_Backup);
            this.m_usrc_DBSettings.Settings_Click += new Tangenta.usrc_Settings.delegate_Settings_Click(this.m_usrc_DBSettings_Settings_Click);
            // 
            // m_usrc_InvoiceMan
            // 
            this.m_usrc_InvoiceMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_InvoiceMan.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_InvoiceMan.Name = "m_usrc_InvoiceMan";
            this.m_usrc_InvoiceMan.Size = new System.Drawing.Size(918, 605);
            this.m_usrc_InvoiceMan.TabIndex = 2;
            // 
            // usrc_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Printer1);
            this.Controls.Add(this.usrc_FVI_SLO1);
            this.Controls.Add(this.m_usrc_Help);
            this.Controls.Add(this.m_usrc_DBSettings);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.m_usrc_InvoiceMan);
            this.Name = "usrc_Main";
            this.Size = new System.Drawing.Size(918, 605);
            this.ResumeLayout(false);

        }

        #endregion

        internal usrc_InvoiceMan m_usrc_InvoiceMan;
        private System.Windows.Forms.Button btn_Exit;
        private usrc_Settings m_usrc_DBSettings;
        private usrc_Help.usrc_Help m_usrc_Help;
        private FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO usrc_FVI_SLO1;
        private usrc_Printer usrc_Printer1;
    }
}
