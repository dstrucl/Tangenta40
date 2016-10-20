namespace Tangenta
{
    partial class usrc_InvoiceMan
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
            this.m_usrc_Invoice = new Tangenta.usrc_Invoice();
            this.m_usrc_InvoiceTable = new Tangenta.usrc_InvoiceTable();
            this.cmb_InvoiceType = new System.Windows.Forms.ComboBox();
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_SelectPanels = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_usrc_Invoice);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_usrc_InvoiceTable);
            this.splitContainer1.Size = new System.Drawing.Size(961, 685);
            this.splitContainer1.SplitterDistance = 629;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_usrc_Invoice
            // 
            this.m_usrc_Invoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Invoice.DocInvoice = "DocInvoice";
            this.m_usrc_Invoice.Location = new System.Drawing.Point(6, 5);
            this.m_usrc_Invoice.Margin = new System.Windows.Forms.Padding(2);
            this.m_usrc_Invoice.myOrganisation_Person_ID = ((long)(0));
            this.m_usrc_Invoice.Name = "m_usrc_Invoice";
            this.m_usrc_Invoice.Size = new System.Drawing.Size(617, 675);
            this.m_usrc_Invoice.TabIndex = 0;
            this.m_usrc_Invoice.Storno += new Tangenta.usrc_Invoice.delegate_Storno(this.m_usrc_Invoice_Storno);
            this.m_usrc_Invoice.aa_DocInvoiceSaved += new Tangenta.usrc_Invoice.delegate_DocInvoiceSaved(this.m_usrc_Invoice_DocInvoiceSaved);
            this.m_usrc_Invoice.aa_Customer_Person_Changed += new Tangenta.usrc_Invoice.delegate_Customer_Person_Changed(this.m_usrc_Invoice_Customer_Person_Changed);
            this.m_usrc_Invoice.aa_Customer_Org_Changed += new Tangenta.usrc_Invoice.delegate_Customer_Org_Changed(this.m_usrc_Invoice_aa_Customer_Org_Changed);
            this.m_usrc_Invoice.aa_PriceListChanged += new Tangenta.usrc_Invoice.delegate_PriceListChanged(this.m_usrc_Invoice_PriceListChanged);
            this.m_usrc_Invoice.Load += new System.EventHandler(this.m_usrc_Invoice_Load);
            // 
            // m_usrc_InvoiceTable
            // 
            this.m_usrc_InvoiceTable.DocInvoice = "DocInvoice";
            this.m_usrc_InvoiceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_InvoiceTable.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_InvoiceTable.Name = "m_usrc_InvoiceTable";
            this.m_usrc_InvoiceTable.Size = new System.Drawing.Size(324, 681);
            this.m_usrc_InvoiceTable.TabIndex = 0;
            this.m_usrc_InvoiceTable.SelectedInvoiceChanged += new Tangenta.usrc_InvoiceTable.delegate_SelectedInvoiceChanged(this.m_usrc_InvoiceTable_SelectedInvoiceChanged);
            // 
            // cmb_InvoiceType
            // 
            this.cmb_InvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_InvoiceType.FormattingEnabled = true;
            this.cmb_InvoiceType.Location = new System.Drawing.Point(80, 3);
            this.cmb_InvoiceType.Name = "cmb_InvoiceType";
            this.cmb_InvoiceType.Size = new System.Drawing.Size(182, 28);
            this.cmb_InvoiceType.TabIndex = 25;
            // 
            // cmb_FinancialYear
            // 
            this.cmb_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_FinancialYear.FormattingEnabled = true;
            this.cmb_FinancialYear.Location = new System.Drawing.Point(324, 2);
            this.cmb_FinancialYear.Name = "cmb_FinancialYear";
            this.cmb_FinancialYear.Size = new System.Drawing.Size(80, 28);
            this.cmb_FinancialYear.TabIndex = 27;
            // 
            // lbl_FinancialYear
            // 
            this.lbl_FinancialYear.AutoSize = true;
            this.lbl_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinancialYear.Location = new System.Drawing.Point(273, 6);
            this.lbl_FinancialYear.Name = "lbl_FinancialYear";
            this.lbl_FinancialYear.Size = new System.Drawing.Size(45, 20);
            this.lbl_FinancialYear.TabIndex = 28;
            this.lbl_FinancialYear.Text = "Leto";
            // 
            // btn_New
            // 
            this.btn_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New.Image = global::Tangenta.Properties.Resources.New;
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(3, 3);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(73, 31);
            this.btn_New.TabIndex = 26;
            this.btn_New.Text = "Nov";
            this.btn_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_SelectPanels
            // 
            this.btn_SelectPanels.Image = global::Tangenta.Properties.Resources.EditAndViewInvoice;
            this.btn_SelectPanels.Location = new System.Drawing.Point(419, 0);
            this.btn_SelectPanels.Name = "btn_SelectPanels";
            this.btn_SelectPanels.Size = new System.Drawing.Size(68, 32);
            this.btn_SelectPanels.TabIndex = 29;
            this.btn_SelectPanels.UseVisualStyleBackColor = true;
            this.btn_SelectPanels.Click += new System.EventHandler(this.btn_SelectPanels_Click);
            // 
            // usrc_InvoiceMan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_SelectPanels);
            this.Controls.Add(this.lbl_FinancialYear);
            this.Controls.Add(this.cmb_FinancialYear);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.cmb_InvoiceType);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_InvoiceMan";
            this.Size = new System.Drawing.Size(960, 720);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.SplitContainer splitContainer1;
        public usrc_Invoice m_usrc_Invoice;
        public usrc_InvoiceTable m_usrc_InvoiceTable;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.ComboBox cmb_InvoiceType;
        private System.Windows.Forms.ComboBox cmb_FinancialYear;
        private System.Windows.Forms.Label lbl_FinancialYear;
        #endregion

        public System.Windows.Forms.Button btn_SelectPanels;
    }
}
