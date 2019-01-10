using TangentaCore;

namespace Tangenta
{
    partial class usrc_DocumentMan1366x768
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_DocumentMan1366x768));
            this.cmb_DocType = new System.Windows.Forms.ComboBox();
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.btn_SelectPanels = new System.Windows.Forms.Button();
            this.m_usrc_Help = new HUDCMS.usrc_Help();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_loginControl1 = new LoginControl.usrc_LoginCtrl();
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.timer_Login_MultiUser = new System.Windows.Forms.Timer(this.components);
            this.m_usrc_TableOfDocuments = new TangentaCore.usrc_TableOfDocuments();
            this.m_usrc_DocumentEditor1366x768 = new Tangenta.usrc_DocumentEditor1366x768();
            this.usrc_TransactionControl1 = new TransactionLog.usrc_TransactionControl();
            this.SuspendLayout();
            // 
            // cmb_DocType
            // 
            this.cmb_DocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_DocType.FormattingEnabled = true;
            this.cmb_DocType.Location = new System.Drawing.Point(3, 6);
            this.cmb_DocType.Name = "cmb_DocType";
            this.cmb_DocType.Size = new System.Drawing.Size(164, 28);
            this.cmb_DocType.TabIndex = 25;
            // 
            // cmb_FinancialYear
            // 
            this.cmb_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_FinancialYear.FormattingEnabled = true;
            this.cmb_FinancialYear.Location = new System.Drawing.Point(234, 6);
            this.cmb_FinancialYear.Name = "cmb_FinancialYear";
            this.cmb_FinancialYear.Size = new System.Drawing.Size(89, 28);
            this.cmb_FinancialYear.TabIndex = 27;
            // 
            // lbl_FinancialYear
            // 
            this.lbl_FinancialYear.AutoSize = true;
            this.lbl_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinancialYear.Location = new System.Drawing.Point(183, 9);
            this.lbl_FinancialYear.Name = "lbl_FinancialYear";
            this.lbl_FinancialYear.Size = new System.Drawing.Size(45, 20);
            this.lbl_FinancialYear.TabIndex = 28;
            this.lbl_FinancialYear.Text = "Leto";
            // 
            // btn_SelectPanels
            // 
            this.btn_SelectPanels.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectPanels.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectPanels.Image")));
            this.btn_SelectPanels.Location = new System.Drawing.Point(102, 700);
            this.btn_SelectPanels.Name = "btn_SelectPanels";
            this.btn_SelectPanels.Size = new System.Drawing.Size(87, 64);
            this.btn_SelectPanels.TabIndex = 29;
            this.btn_SelectPanels.UseVisualStyleBackColor = false;
            this.btn_SelectPanels.Click += new System.EventHandler(this.btn_SelectPanels_Click);
            // 
            // m_usrc_Help
            // 
            this.m_usrc_Help.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_usrc_Help.Location = new System.Drawing.Point(313, 701);
            this.m_usrc_Help.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_Help.Name = "m_usrc_Help";
            this.m_usrc_Help.Size = new System.Drawing.Size(41, 64);
            this.m_usrc_Help.TabIndex = 31;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.Location = new System.Drawing.Point(0, 700);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 65);
            this.btn_Exit.TabIndex = 30;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_loginControl1
            // 
            this.usrc_loginControl1.Location = new System.Drawing.Point(34, 40);
            this.usrc_loginControl1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_loginControl1.Name = "usrc_loginControl1";
            this.usrc_loginControl1.Size = new System.Drawing.Size(320, 33);
            this.usrc_loginControl1.TabIndex = 37;
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_FVI_SLO1.Image_ButtonExit = ((System.Drawing.Image)(resources.GetObject("usrc_FVI_SLO1.Image_ButtonExit")));
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(215, 702);
            this.usrc_FVI_SLO1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(33, 63);
            this.usrc_FVI_SLO1.TabIndex = 32;
            this.usrc_FVI_SLO1.PasswordCheck += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.deleagteRequestPasswordCheck(this.usrc_FVI_SLO1_PasswordCheck);
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
            this.btn_Settings.Location = new System.Drawing.Point(255, 701);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(33, 64);
            this.btn_Settings.TabIndex = 34;
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // timer_Login_MultiUser
            // 
            this.timer_Login_MultiUser.Interval = 1000;
            this.timer_Login_MultiUser.Tick += new System.EventHandler(this.timer_Login_MultiUser_Tick);
            // 
            // m_usrc_TableOfDocuments
            // 
            this.m_usrc_TableOfDocuments.BackColor = System.Drawing.Color.Linen;
            this.m_usrc_TableOfDocuments.DocM = null;
            this.m_usrc_TableOfDocuments.Location = new System.Drawing.Point(0, 77);
            this.m_usrc_TableOfDocuments.Name = "m_usrc_TableOfDocuments";
            this.m_usrc_TableOfDocuments.Size = new System.Drawing.Size(357, 603);
            this.m_usrc_TableOfDocuments.TabIndex = 39;
            this.m_usrc_TableOfDocuments.SelectedInvoiceChanged += new TangentaCore.usrc_TableOfDocuments.delegate_SelectedInvoiceChanged(this.m_usrc_InvoiceTable_SelectedInvoiceChanged);
            // 
            // m_usrc_DocumentEditor1366x768
            // 
            this.m_usrc_DocumentEditor1366x768.BackColor = System.Drawing.Color.Gainsboro;
            this.m_usrc_DocumentEditor1366x768.Location = new System.Drawing.Point(360, 0);
            this.m_usrc_DocumentEditor1366x768.Margin = new System.Windows.Forms.Padding(2);
            this.m_usrc_DocumentEditor1366x768.Name = "m_usrc_DocumentEditor1366x768";
            this.m_usrc_DocumentEditor1366x768.Size = new System.Drawing.Size(1006, 768);
            this.m_usrc_DocumentEditor1366x768.TabIndex = 40;
            this.m_usrc_DocumentEditor1366x768.New_Click += new Tangenta.usrc_DocumentEditor1366x768.delegate_New_Click(this.btn_New_Click);
            this.m_usrc_DocumentEditor1366x768.Storno += new Tangenta.usrc_DocumentEditor1366x768.delegate_Storno(this.m_usrc_Invoice_Storno);
            this.m_usrc_DocumentEditor1366x768.aa_DocInvoiceSaved += new Tangenta.usrc_DocumentEditor1366x768.delegate_DocInvoiceSaved(this.m_usrc_Invoice_DocInvoiceSaved);
            this.m_usrc_DocumentEditor1366x768.aa_DocProformaInvoiceSaved += new Tangenta.usrc_DocumentEditor1366x768.delegate_DocProformaInvoiceSaved(this.m_usrc_Invoice_DocProformaInvoiceSaved);
            this.m_usrc_DocumentEditor1366x768.aa_Customer_Person_Changed += new Tangenta.usrc_DocumentEditor1366x768.delegate_Customer_Person_Changed(this.m_usrc_Invoice_Customer_Person_Changed);
            this.m_usrc_DocumentEditor1366x768.aa_Customer_Org_Changed += new Tangenta.usrc_DocumentEditor1366x768.delegate_Customer_Org_Changed(this.m_usrc_Invoice_aa_Customer_Org_Changed);
            // 
            // usrc_TransactionControl1
            // 
            this.usrc_TransactionControl1.DataBase_TransactionsLog = null;
            this.usrc_TransactionControl1.Location = new System.Drawing.Point(4, 41);
            this.usrc_TransactionControl1.Name = "usrc_TransactionControl1";
            this.usrc_TransactionControl1.Size = new System.Drawing.Size(23, 25);
            this.usrc_TransactionControl1.State = DBConnectionControl40.Transaction.eConnectionState.DICSONNECTED;
            this.usrc_TransactionControl1.TabIndex = 41;
            // 
            // usrc_DocumentMan1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.usrc_TransactionControl1);
            this.Controls.Add(this.cmb_DocType);
            this.Controls.Add(this.lbl_FinancialYear);
            this.Controls.Add(this.usrc_loginControl1);
            this.Controls.Add(this.m_usrc_DocumentEditor1366x768);
            this.Controls.Add(this.cmb_FinancialYear);
            this.Controls.Add(this.m_usrc_TableOfDocuments);
            this.Controls.Add(this.btn_SelectPanels);
            this.Controls.Add(this.m_usrc_Help);
            this.Controls.Add(this.usrc_FVI_SLO1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Settings);
            this.Name = "usrc_DocumentMan1366x768";
            this.Size = new System.Drawing.Size(1366, 768);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cmb_DocType;
        private System.Windows.Forms.ComboBox cmb_FinancialYear;
        private System.Windows.Forms.Label lbl_FinancialYear;
        #endregion

        public System.Windows.Forms.Button btn_SelectPanels;
        private HUDCMS.usrc_Help m_usrc_Help;
        private System.Windows.Forms.Button btn_Exit;
        internal LoginControl.usrc_LoginCtrl usrc_loginControl1;
        internal FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO usrc_FVI_SLO1;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Timer timer_Login_MultiUser;
        public usrc_TableOfDocuments m_usrc_TableOfDocuments;
        public usrc_DocumentEditor1366x768 m_usrc_DocumentEditor1366x768;
        private TransactionLog.usrc_TransactionControl usrc_TransactionControl1;
    }
}
