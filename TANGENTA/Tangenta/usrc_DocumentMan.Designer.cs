namespace Tangenta
{
    partial class usrc_DocumentMan
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmb_InvoiceType = new System.Windows.Forms.ComboBox();
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_SelectPanels = new System.Windows.Forms.Button();
            this.m_usrc_Help = new HUDCMS.usrc_Help();
            this.btn_Backup = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.loginControl1 = new LoginControl.LoginCtrl();
            this.btn_CodeTables = new System.Windows.Forms.Button();
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.pnl_MainMenu = new System.Windows.Forms.Panel();
            this.usrc_TangentaPrint1 = new TangentaPrint.usrc_TangentaPrint();
            this.m_usrc_DocumentEditor = new Tangenta.usrc_DocumentEditor();
            this.m_usrc_TableOfDocuments = new Tangenta.usrc_TableOfDocuments();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnl_MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_usrc_DocumentEditor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_usrc_TableOfDocuments);
            this.splitContainer1.Size = new System.Drawing.Size(993, 680);
            this.splitContainer1.SplitterDistance = 589;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmb_InvoiceType
            // 
            this.cmb_InvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_InvoiceType.FormattingEnabled = true;
            this.cmb_InvoiceType.Location = new System.Drawing.Point(84, 4);
            this.cmb_InvoiceType.Name = "cmb_InvoiceType";
            this.cmb_InvoiceType.Size = new System.Drawing.Size(182, 28);
            this.cmb_InvoiceType.TabIndex = 25;
            // 
            // cmb_FinancialYear
            // 
            this.cmb_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_FinancialYear.FormattingEnabled = true;
            this.cmb_FinancialYear.Location = new System.Drawing.Point(327, 4);
            this.cmb_FinancialYear.Name = "cmb_FinancialYear";
            this.cmb_FinancialYear.Size = new System.Drawing.Size(89, 28);
            this.cmb_FinancialYear.TabIndex = 27;
            // 
            // lbl_FinancialYear
            // 
            this.lbl_FinancialYear.AutoSize = true;
            this.lbl_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinancialYear.Location = new System.Drawing.Point(272, 9);
            this.lbl_FinancialYear.Name = "lbl_FinancialYear";
            this.lbl_FinancialYear.Size = new System.Drawing.Size(45, 20);
            this.lbl_FinancialYear.TabIndex = 28;
            this.lbl_FinancialYear.Text = "Leto";
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New.Image = global::Tangenta.Properties.Resources.New;
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(5, 3);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(73, 31);
            this.btn_New.TabIndex = 26;
            this.btn_New.Text = "Nov";
            this.btn_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_SelectPanels
            // 
            this.btn_SelectPanels.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectPanels.Image = global::Tangenta.Properties.Resources.EditAndViewInvoice;
            this.btn_SelectPanels.Location = new System.Drawing.Point(423, 2);
            this.btn_SelectPanels.Name = "btn_SelectPanels";
            this.btn_SelectPanels.Size = new System.Drawing.Size(68, 32);
            this.btn_SelectPanels.TabIndex = 29;
            this.btn_SelectPanels.UseVisualStyleBackColor = false;
            this.btn_SelectPanels.Click += new System.EventHandler(this.btn_SelectPanels_Click);
            // 
            // m_usrc_Help
            // 
            this.m_usrc_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Help.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_usrc_Help.Location = new System.Drawing.Point(864, 3);
            this.m_usrc_Help.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_Help.Name = "m_usrc_Help";
            this.m_usrc_Help.Size = new System.Drawing.Size(38, 31);
            this.m_usrc_Help.TabIndex = 31;
            // 
            // btn_Backup
            // 
            this.btn_Backup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Backup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Backup.Image = global::Tangenta.Properties.Resources.UpgradeDataBase;
            this.btn_Backup.Location = new System.Drawing.Point(906, 3);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(38, 31);
            this.btn_Backup.TabIndex = 35;
            this.btn_Backup.UseVisualStyleBackColor = false;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(948, 3);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(44, 31);
            this.btn_Exit.TabIndex = 30;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // loginControl1
            // 
            this.loginControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginControl1.DataTableCreationMode = LoginControl.LoginCtrl.eDataTableCreationMode.AWP;
            this.loginControl1.Location = new System.Drawing.Point(498, 3);
            this.loginControl1.Margin = new System.Windows.Forms.Padding(4);
            this.loginControl1.MinPasswordLength = 5;
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.RecentItemsFolder = "";
            this.loginControl1.Size = new System.Drawing.Size(182, 32);
            this.loginControl1.TabIndex = 37;
            // 
            // btn_CodeTables
            // 
            this.btn_CodeTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CodeTables.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CodeTables.Image = global::Tangenta.Properties.Resources.CodeTablesImage;
            this.btn_CodeTables.Location = new System.Drawing.Point(684, 4);
            this.btn_CodeTables.Name = "btn_CodeTables";
            this.btn_CodeTables.Size = new System.Drawing.Size(40, 31);
            this.btn_CodeTables.TabIndex = 36;
            this.btn_CodeTables.UseVisualStyleBackColor = false;
            this.btn_CodeTables.Click += new System.EventHandler(this.btn_CodeTables_Click);
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FVI_SLO1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_FVI_SLO1.FursD_ElectronicDeviceID = "";
            this.usrc_FVI_SLO1.FursTESTEnvironment = false;
            this.usrc_FVI_SLO1.Image_ButtonExit = global::Tangenta.Properties.Resources.Exit;
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(728, 4);
            this.usrc_FVI_SLO1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_FVI_SLO1.MessageBox_Length = 100;
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(37, 31);
            this.usrc_FVI_SLO1.TabIndex = 32;
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Settings.Image = global::Tangenta.Properties.Resources.Settings;
            this.btn_Settings.Location = new System.Drawing.Point(822, 3);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(37, 31);
            this.btn_Settings.TabIndex = 34;
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // pnl_MainMenu
            // 
            this.pnl_MainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_MainMenu.Controls.Add(this.loginControl1);
            this.pnl_MainMenu.Controls.Add(this.lbl_FinancialYear);
            this.pnl_MainMenu.Controls.Add(this.m_usrc_Help);
            this.pnl_MainMenu.Controls.Add(this.cmb_InvoiceType);
            this.pnl_MainMenu.Controls.Add(this.btn_Backup);
            this.pnl_MainMenu.Controls.Add(this.btn_New);
            this.pnl_MainMenu.Controls.Add(this.btn_Exit);
            this.pnl_MainMenu.Controls.Add(this.cmb_FinancialYear);
            this.pnl_MainMenu.Controls.Add(this.btn_SelectPanels);
            this.pnl_MainMenu.Controls.Add(this.btn_CodeTables);
            this.pnl_MainMenu.Controls.Add(this.btn_Settings);
            this.pnl_MainMenu.Controls.Add(this.usrc_TangentaPrint1);
            this.pnl_MainMenu.Controls.Add(this.usrc_FVI_SLO1);
            this.pnl_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_MainMenu.Name = "pnl_MainMenu";
            this.pnl_MainMenu.Size = new System.Drawing.Size(993, 37);
            this.pnl_MainMenu.TabIndex = 38;
            // 
            // usrc_TangentaPrint1
            // 
            this.usrc_TangentaPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_TangentaPrint1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_TangentaPrint1.Location = new System.Drawing.Point(771, 4);
            this.usrc_TangentaPrint1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_TangentaPrint1.Name = "usrc_TangentaPrint1";
            this.usrc_TangentaPrint1.Size = new System.Drawing.Size(46, 31);
            this.usrc_TangentaPrint1.TabIndex = 33;
            // 
            // m_usrc_Invoice
            // 
            this.m_usrc_DocumentEditor.DocInvoice = "DocInvoice";
            this.m_usrc_DocumentEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_DocumentEditor.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_DocumentEditor.Margin = new System.Windows.Forms.Padding(2);
            this.m_usrc_DocumentEditor.Name = "m_usrc_Invoice";
            this.m_usrc_DocumentEditor.Size = new System.Drawing.Size(585, 676);
            this.m_usrc_DocumentEditor.TabIndex = 0;
            this.m_usrc_DocumentEditor.Storno += new Tangenta.usrc_DocumentEditor.delegate_Storno(this.m_usrc_Invoice_Storno);
            this.m_usrc_DocumentEditor.aa_DocInvoiceSaved += new Tangenta.usrc_DocumentEditor.delegate_DocInvoiceSaved(this.m_usrc_Invoice_DocInvoiceSaved);
            this.m_usrc_DocumentEditor.aa_DocProformaInvoiceSaved += new Tangenta.usrc_DocumentEditor.delegate_DocProformaInvoiceSaved(this.m_usrc_Invoice_DocProformaInvoiceSaved);
            this.m_usrc_DocumentEditor.aa_Customer_Person_Changed += new Tangenta.usrc_DocumentEditor.delegate_Customer_Person_Changed(this.m_usrc_Invoice_Customer_Person_Changed);
            this.m_usrc_DocumentEditor.aa_Customer_Org_Changed += new Tangenta.usrc_DocumentEditor.delegate_Customer_Org_Changed(this.m_usrc_Invoice_aa_Customer_Org_Changed);
            this.m_usrc_DocumentEditor.Load += new System.EventHandler(this.m_usrc_Invoice_Load);
            // 
            // m_usrc_InvoiceTable
            // 
            this.m_usrc_TableOfDocuments.DocInvoice = "DocInvoice";
            this.m_usrc_TableOfDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_TableOfDocuments.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_TableOfDocuments.Name = "m_usrc_InvoiceTable";
            this.m_usrc_TableOfDocuments.Size = new System.Drawing.Size(396, 676);
            this.m_usrc_TableOfDocuments.TabIndex = 0;
            this.m_usrc_TableOfDocuments.SelectedInvoiceChanged += new Tangenta.usrc_TableOfDocuments.delegate_SelectedInvoiceChanged(this.m_usrc_InvoiceTable_SelectedInvoiceChanged);
            // 
            // usrc_DocumentMan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnl_MainMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_DocumentMan";
            this.Size = new System.Drawing.Size(993, 720);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnl_MainMenu.ResumeLayout(false);
            this.pnl_MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }


        public usrc_DocumentEditor m_usrc_DocumentEditor;
        public usrc_TableOfDocuments m_usrc_TableOfDocuments;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.ComboBox cmb_InvoiceType;
        private System.Windows.Forms.ComboBox cmb_FinancialYear;
        private System.Windows.Forms.Label lbl_FinancialYear;
        #endregion

        public System.Windows.Forms.Button btn_SelectPanels;
        private HUDCMS.usrc_Help m_usrc_Help;
        private System.Windows.Forms.Button btn_Backup;
        private System.Windows.Forms.Button btn_Exit;
        internal LoginControl.LoginCtrl loginControl1;
        private System.Windows.Forms.Button btn_CodeTables;
        private TangentaPrint.usrc_TangentaPrint usrc_TangentaPrint1;
        internal FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO usrc_FVI_SLO1;
        private System.Windows.Forms.Button btn_Settings;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Panel pnl_MainMenu;
    }
}
