
namespace ShopC_Forms
{
    partial class usrc_ConsumptionMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_ConsumptionMan));
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.btn_SelectPanels = new System.Windows.Forms.Button();
            this.m_usrc_Help = new HUDCMS.usrc_Help();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.timer_Login_MultiUser = new System.Windows.Forms.Timer(this.components);
            this.m_usrc_TableOfConsumption = new ShopC_Forms.usrc_TableOfConsumption();
            this.m_usrc_ConsumptionEditor = new ShopC_Forms.usrc_ConsumptionEditor();
            this.usrc_DocIssue1 = new ShopC_Forms.usrc_DocIssue();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.cmb_ConsumptionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // timer_Login_MultiUser
            // 
            this.timer_Login_MultiUser.Interval = 1000;
            this.timer_Login_MultiUser.Tick += new System.EventHandler(this.timer_Login_MultiUser_Tick);
            // 
            // m_usrc_TableOfConsumption
            // 
            this.m_usrc_TableOfConsumption.BackColor = System.Drawing.Color.Linen;
            this.m_usrc_TableOfConsumption.ConsM = null;
            this.m_usrc_TableOfConsumption.Location = new System.Drawing.Point(0, 50);
            this.m_usrc_TableOfConsumption.Name = "m_usrc_TableOfConsumption";
            this.m_usrc_TableOfConsumption.Size = new System.Drawing.Size(357, 630);
            this.m_usrc_TableOfConsumption.TabIndex = 39;
            this.m_usrc_TableOfConsumption.SelectedInvoiceChanged += new ShopC_Forms.usrc_TableOfConsumption.delegate_SelectedInvoiceChanged(this.m_usrc_InvoiceTable_SelectedInvoiceChanged);
            // 
            // m_usrc_ConsumptionEditor
            // 
            this.m_usrc_ConsumptionEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_ConsumptionEditor.BackColor = System.Drawing.Color.Gainsboro;
            this.m_usrc_ConsumptionEditor.Location = new System.Drawing.Point(360, 0);
            this.m_usrc_ConsumptionEditor.Margin = new System.Windows.Forms.Padding(2);
            this.m_usrc_ConsumptionEditor.Name = "m_usrc_ConsumptionEditor";
            this.m_usrc_ConsumptionEditor.Size = new System.Drawing.Size(713, 768);
            this.m_usrc_ConsumptionEditor.TabIndex = 40;
            this.m_usrc_ConsumptionEditor.New_Click += new ShopC_Forms.usrc_ConsumptionEditor.delegate_New_Click(this.btn_New_Click);
            this.m_usrc_ConsumptionEditor.SetTotalColor += new ShopC_Forms.usrc_ConsumptionEditor.delegate_SetTotalColor(this.m_usrc_ConsumptionEditor_SetTotalColor);
            this.m_usrc_ConsumptionEditor.SetTotal += new ShopC_Forms.usrc_ConsumptionEditor.delegate_SetTotal(this.m_usrc_ConsumptionEditor_SetTotal);
            this.m_usrc_ConsumptionEditor.SetBtnIssueLabel += new ShopC_Forms.usrc_ConsumptionEditor.delegate_SetBtnIssueLabel(this.m_usrc_ConsumptionEditor_SetBtnIssueLabel);
            this.m_usrc_ConsumptionEditor.SetBtnIssueVisible += new ShopC_Forms.usrc_ConsumptionEditor.delegate_SetBtnIssueVisible(this.m_usrc_ConsumptionEditor_SetBtnIssueVisible);
            this.m_usrc_ConsumptionEditor.Storno += new ShopC_Forms.usrc_ConsumptionEditor.delegate_Storno(this.m_usrc_Invoice_Storno);
            this.m_usrc_ConsumptionEditor.aa_DocInvoiceSaved += new ShopC_Forms.usrc_ConsumptionEditor.delegate_DocInvoiceSaved(this.m_usrc_Invoice_DocInvoiceSaved);
            this.m_usrc_ConsumptionEditor.aa_DocProformaInvoiceSaved += new ShopC_Forms.usrc_ConsumptionEditor.delegate_DocProformaInvoiceSaved(this.m_usrc_Invoice_DocProformaInvoiceSaved);
            // 
            // usrc_DocIssue1
            // 
            this.usrc_DocIssue1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usrc_DocIssue1.BackgroundImage")));
            this.usrc_DocIssue1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usrc_DocIssue1.BtnIssueLabel = "Issue";
            this.usrc_DocIssue1.BtnIssueVisible = true;
            this.usrc_DocIssue1.Location = new System.Drawing.Point(361, 688);
            this.usrc_DocIssue1.Name = "usrc_DocIssue1";
            this.usrc_DocIssue1.Size = new System.Drawing.Size(150, 80);
            this.usrc_DocIssue1.TabIndex = 42;
            this.usrc_DocIssue1.Total = "SKUPAJ";
            this.usrc_DocIssue1.TotalColor = System.Drawing.SystemColors.ControlText;
            this.usrc_DocIssue1.Visible = false;
            this.usrc_DocIssue1.DoClick += new ShopC_Forms.usrc_DocIssue.delegate_Click(this.usrc_DocIssue1_DoClick);
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
            // 
            // cmb_ConsumptionType
            // 
            this.cmb_ConsumptionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_ConsumptionType.FormattingEnabled = true;
            this.cmb_ConsumptionType.Location = new System.Drawing.Point(3, 6);
            this.cmb_ConsumptionType.Name = "cmb_ConsumptionType";
            this.cmb_ConsumptionType.Size = new System.Drawing.Size(164, 28);
            this.cmb_ConsumptionType.TabIndex = 25;
            // 
            // usrc_ConsumptionMan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.usrc_DocIssue1);
            this.Controls.Add(this.cmb_ConsumptionType);
            this.Controls.Add(this.lbl_FinancialYear);
            this.Controls.Add(this.m_usrc_ConsumptionEditor);
            this.Controls.Add(this.cmb_FinancialYear);
            this.Controls.Add(this.m_usrc_TableOfConsumption);
            this.Controls.Add(this.btn_SelectPanels);
            this.Controls.Add(this.m_usrc_Help);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Settings);
            this.Name = "usrc_ConsumptionMan";
            this.Size = new System.Drawing.Size(1073, 784);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox cmb_FinancialYear;
        private System.Windows.Forms.Label lbl_FinancialYear;
        #endregion

        public System.Windows.Forms.Button btn_SelectPanels;
        private HUDCMS.usrc_Help m_usrc_Help;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Timer timer_Login_MultiUser;
        public usrc_TableOfConsumption m_usrc_TableOfConsumption;
        public usrc_ConsumptionEditor m_usrc_ConsumptionEditor;
        private usrc_DocIssue usrc_DocIssue1;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.ComboBox cmb_ConsumptionType;
    }
}
