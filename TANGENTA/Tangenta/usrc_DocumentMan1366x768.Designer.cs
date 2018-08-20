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
            this.cmb_DocType = new System.Windows.Forms.ComboBox();
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_SelectPanels = new System.Windows.Forms.Button();
            this.m_usrc_Help = new HUDCMS.usrc_Help();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_loginControl1 = new LoginControl.usrc_LoginCtrl();
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.pnl_MainMenu = new System.Windows.Forms.Panel();
            this.timer_Login_MultiUser = new System.Windows.Forms.Timer(this.components);
            this.m_usrc_TableOfDocuments = new Tangenta.usrc_TableOfDocuments();
            this.m_usrc_DocumentEditor1366x768 = new Tangenta.usrc_DocumentEditor1366x768();
            this.pnl_MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_DocType
            // 
            this.cmb_DocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_DocType.FormattingEnabled = true;
            this.cmb_DocType.Location = new System.Drawing.Point(102, 4);
            this.cmb_DocType.Name = "cmb_DocType";
            this.cmb_DocType.Size = new System.Drawing.Size(164, 28);
            this.cmb_DocType.TabIndex = 25;
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
            this.btn_New.Size = new System.Drawing.Size(91, 49);
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
            this.btn_SelectPanels.Size = new System.Drawing.Size(68, 49);
            this.btn_SelectPanels.TabIndex = 29;
            this.btn_SelectPanels.UseVisualStyleBackColor = false;
            this.btn_SelectPanels.Click += new System.EventHandler(this.btn_SelectPanels_Click);
            // 
            // m_usrc_Help
            // 
            this.m_usrc_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Help.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_usrc_Help.Location = new System.Drawing.Point(1189, 4);
            this.m_usrc_Help.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_Help.Name = "m_usrc_Help";
            this.m_usrc_Help.Size = new System.Drawing.Size(56, 49);
            this.m_usrc_Help.TabIndex = 31;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.Location = new System.Drawing.Point(1252, 3);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(110, 49);
            this.btn_Exit.TabIndex = 30;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_loginControl1
            // 
            this.usrc_loginControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_loginControl1.Location = new System.Drawing.Point(498, 3);
            this.usrc_loginControl1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_loginControl1.Name = "usrc_loginControl1";
            this.usrc_loginControl1.Size = new System.Drawing.Size(607, 49);
            this.usrc_loginControl1.TabIndex = 37;
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FVI_SLO1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_FVI_SLO1.Image_ButtonExit = global::Tangenta.Properties.Resources.Exit;
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(1104, 4);
            this.usrc_FVI_SLO1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(38, 49);
            this.usrc_FVI_SLO1.TabIndex = 32;
            this.usrc_FVI_SLO1.PasswordCheck += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.deleagteRequestPasswordCheck(this.usrc_FVI_SLO1_PasswordCheck);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Settings.Image = global::Tangenta.Properties.Resources.Settings;
            this.btn_Settings.Location = new System.Drawing.Point(1149, 3);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(33, 49);
            this.btn_Settings.TabIndex = 34;
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // pnl_MainMenu
            // 
            this.pnl_MainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_MainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_MainMenu.Controls.Add(this.usrc_loginControl1);
            this.pnl_MainMenu.Controls.Add(this.lbl_FinancialYear);
            this.pnl_MainMenu.Controls.Add(this.m_usrc_Help);
            this.pnl_MainMenu.Controls.Add(this.cmb_DocType);
            this.pnl_MainMenu.Controls.Add(this.btn_New);
            this.pnl_MainMenu.Controls.Add(this.btn_Exit);
            this.pnl_MainMenu.Controls.Add(this.cmb_FinancialYear);
            this.pnl_MainMenu.Controls.Add(this.btn_SelectPanels);
            this.pnl_MainMenu.Controls.Add(this.btn_Settings);
            this.pnl_MainMenu.Controls.Add(this.usrc_FVI_SLO1);
            this.pnl_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_MainMenu.Name = "pnl_MainMenu";
            this.pnl_MainMenu.Size = new System.Drawing.Size(1363, 55);
            this.pnl_MainMenu.TabIndex = 38;
            // 
            // timer_Login_MultiUser
            // 
            this.timer_Login_MultiUser.Interval = 1000;
            this.timer_Login_MultiUser.Tick += new System.EventHandler(this.timer_Login_MultiUser_Tick);
            // 
            // m_usrc_TableOfDocuments
            // 
            this.m_usrc_TableOfDocuments.BackColor = System.Drawing.Color.Linen;
            this.m_usrc_TableOfDocuments.DocTyp = "DocInvoice";
            this.m_usrc_TableOfDocuments.Location = new System.Drawing.Point(848, 59);
            this.m_usrc_TableOfDocuments.Name = "m_usrc_TableOfDocuments";
            this.m_usrc_TableOfDocuments.Size = new System.Drawing.Size(518, 706);
            this.m_usrc_TableOfDocuments.TabIndex = 39;
            // 
            // m_usrc_DocumentEditor
            // 
            this.m_usrc_DocumentEditor1366x768.BackColor = System.Drawing.Color.Gainsboro;
            this.m_usrc_DocumentEditor1366x768.DocTyp = "DocInvoice";
            this.m_usrc_DocumentEditor1366x768.Location = new System.Drawing.Point(5, 59);
            this.m_usrc_DocumentEditor1366x768.Margin = new System.Windows.Forms.Padding(2);
            this.m_usrc_DocumentEditor1366x768.Name = "m_usrc_DocumentEditor";
            this.m_usrc_DocumentEditor1366x768.Size = new System.Drawing.Size(838, 706);
            this.m_usrc_DocumentEditor1366x768.TabIndex = 40;
            // 
            // usrc_DocumentMan1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.m_usrc_DocumentEditor1366x768);
            this.Controls.Add(this.m_usrc_TableOfDocuments);
            this.Controls.Add(this.pnl_MainMenu);
            this.Name = "usrc_DocumentMan1366x768";
            this.Size = new System.Drawing.Size(1366, 768);
            this.pnl_MainMenu.ResumeLayout(false);
            this.pnl_MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btn_New;
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
        internal System.Windows.Forms.Panel pnl_MainMenu;
        private System.Windows.Forms.Timer timer_Login_MultiUser;
        public usrc_TableOfDocuments m_usrc_TableOfDocuments;
        public usrc_DocumentEditor1366x768 m_usrc_DocumentEditor1366x768;
    }
}
