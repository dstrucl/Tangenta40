namespace ShopC
{
    partial class Form_ShopC_TableInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ShopC_TableInspection));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.chk_OnlyFromStock = new System.Windows.Forms.CheckBox();
            this.dgvx_ShopC_Docs = new DataGridView_2xls.DataGridView2xls();
            this.rdb_ProformaInvoice = new System.Windows.Forms.RadioButton();
            this.rdb_Invoice = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbl_Doc_Info = new System.Windows.Forms.Label();
            this.dgvx_DocID_ShopC_Items = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Stock_Info = new System.Windows.Forms.Label();
            this.dgvx_Stock = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvx_Doc_ShopC_Item_Source = new DataGridView_2xls.DataGridView2xls();
            this.lbl_dgvx_Doc_ShopC_Item_Source = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopC_Docs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_DocID_ShopC_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Doc_ShopC_Item_Source)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Bisque;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel1.Controls.Add(this.btn_Reload);
            this.splitContainer1.Panel1.Controls.Add(this.chk_OnlyFromStock);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_ShopC_Docs);
            this.splitContainer1.Panel1.Controls.Add(this.rdb_ProformaInvoice);
            this.splitContainer1.Panel1.Controls.Add(this.rdb_Invoice);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 686);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_Reload
            // 
            this.btn_Reload.Location = new System.Drawing.Point(295, 12);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(80, 29);
            this.btn_Reload.TabIndex = 4;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // chk_OnlyFromStock
            // 
            this.chk_OnlyFromStock.AutoSize = true;
            this.chk_OnlyFromStock.Location = new System.Drawing.Point(12, 29);
            this.chk_OnlyFromStock.Name = "chk_OnlyFromStock";
            this.chk_OnlyFromStock.Size = new System.Drawing.Size(107, 17);
            this.chk_OnlyFromStock.TabIndex = 3;
            this.chk_OnlyFromStock.Text = "Only  From Stock";
            this.chk_OnlyFromStock.UseVisualStyleBackColor = true;
            // 
            // dgvx_ShopC_Docs
            // 
            this.dgvx_ShopC_Docs.AllowUserToAddRows = false;
            this.dgvx_ShopC_Docs.AllowUserToDeleteRows = false;
            this.dgvx_ShopC_Docs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ShopC_Docs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ShopC_Docs.DataGridViewWithRowNumber = false;
            this.dgvx_ShopC_Docs.Location = new System.Drawing.Point(4, 51);
            this.dgvx_ShopC_Docs.MultiSelect = false;
            this.dgvx_ShopC_Docs.Name = "dgvx_ShopC_Docs";
            this.dgvx_ShopC_Docs.ReadOnly = true;
            this.dgvx_ShopC_Docs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ShopC_Docs.Size = new System.Drawing.Size(372, 632);
            this.dgvx_ShopC_Docs.TabIndex = 2;
            // 
            // rdb_ProformaInvoice
            // 
            this.rdb_ProformaInvoice.AutoSize = true;
            this.rdb_ProformaInvoice.Location = new System.Drawing.Point(72, 6);
            this.rdb_ProformaInvoice.Name = "rdb_ProformaInvoice";
            this.rdb_ProformaInvoice.Size = new System.Drawing.Size(110, 17);
            this.rdb_ProformaInvoice.TabIndex = 1;
            this.rdb_ProformaInvoice.Text = "Proforma Invoices";
            this.rdb_ProformaInvoice.UseVisualStyleBackColor = true;
            // 
            // rdb_Invoice
            // 
            this.rdb_Invoice.AutoSize = true;
            this.rdb_Invoice.Checked = true;
            this.rdb_Invoice.Location = new System.Drawing.Point(6, 6);
            this.rdb_Invoice.Name = "rdb_Invoice";
            this.rdb_Invoice.Size = new System.Drawing.Size(65, 17);
            this.rdb_Invoice.TabIndex = 0;
            this.rdb_Invoice.TabStop = true;
            this.rdb_Invoice.Text = "Invoices";
            this.rdb_Invoice.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Bisque;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer2.Panel2.Controls.Add(this.lbl_Stock_Info);
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_Stock);
            this.splitContainer2.Size = new System.Drawing.Size(415, 686);
            this.splitContainer2.SplitterDistance = 352;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbl_Doc_Info
            // 
            this.lbl_Doc_Info.AutoSize = true;
            this.lbl_Doc_Info.Location = new System.Drawing.Point(6, 10);
            this.lbl_Doc_Info.Name = "lbl_Doc_Info";
            this.lbl_Doc_Info.Size = new System.Drawing.Size(35, 13);
            this.lbl_Doc_Info.TabIndex = 4;
            this.lbl_Doc_Info.Text = "label1";
            // 
            // dgvx_DocID_ShopC_Items
            // 
            this.dgvx_DocID_ShopC_Items.AllowUserToAddRows = false;
            this.dgvx_DocID_ShopC_Items.AllowUserToDeleteRows = false;
            this.dgvx_DocID_ShopC_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_DocID_ShopC_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_DocID_ShopC_Items.DataGridViewWithRowNumber = false;
            this.dgvx_DocID_ShopC_Items.Location = new System.Drawing.Point(6, 29);
            this.dgvx_DocID_ShopC_Items.MultiSelect = false;
            this.dgvx_DocID_ShopC_Items.Name = "dgvx_DocID_ShopC_Items";
            this.dgvx_DocID_ShopC_Items.ReadOnly = true;
            this.dgvx_DocID_ShopC_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_DocID_ShopC_Items.Size = new System.Drawing.Size(217, 320);
            this.dgvx_DocID_ShopC_Items.TabIndex = 3;
            // 
            // lbl_Stock_Info
            // 
            this.lbl_Stock_Info.AutoSize = true;
            this.lbl_Stock_Info.Location = new System.Drawing.Point(12, 10);
            this.lbl_Stock_Info.Name = "lbl_Stock_Info";
            this.lbl_Stock_Info.Size = new System.Drawing.Size(56, 13);
            this.lbl_Stock_Info.TabIndex = 6;
            this.lbl_Stock_Info.Text = "Stock Info";
            // 
            // dgvx_Stock
            // 
            this.dgvx_Stock.AllowUserToAddRows = false;
            this.dgvx_Stock.AllowUserToDeleteRows = false;
            this.dgvx_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Stock.DataGridViewWithRowNumber = false;
            this.dgvx_Stock.Location = new System.Drawing.Point(3, 28);
            this.dgvx_Stock.MultiSelect = false;
            this.dgvx_Stock.Name = "dgvx_Stock";
            this.dgvx_Stock.ReadOnly = true;
            this.dgvx_Stock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Stock.Size = new System.Drawing.Size(409, 296);
            this.dgvx_Stock.TabIndex = 5;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Doc_Info);
            this.splitContainer3.Panel1.Controls.Add(this.dgvx_DocID_ShopC_Items);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lbl_dgvx_Doc_ShopC_Item_Source);
            this.splitContainer3.Panel2.Controls.Add(this.dgvx_Doc_ShopC_Item_Source);
            this.splitContainer3.Size = new System.Drawing.Size(415, 352);
            this.splitContainer3.SplitterDistance = 226;
            this.splitContainer3.TabIndex = 5;
            // 
            // dgvx_Doc_ShopC_Item_Source
            // 
            this.dgvx_Doc_ShopC_Item_Source.AllowUserToAddRows = false;
            this.dgvx_Doc_ShopC_Item_Source.AllowUserToDeleteRows = false;
            this.dgvx_Doc_ShopC_Item_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Doc_ShopC_Item_Source.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Doc_ShopC_Item_Source.DataGridViewWithRowNumber = false;
            this.dgvx_Doc_ShopC_Item_Source.Location = new System.Drawing.Point(3, 29);
            this.dgvx_Doc_ShopC_Item_Source.MultiSelect = false;
            this.dgvx_Doc_ShopC_Item_Source.Name = "dgvx_Doc_ShopC_Item_Source";
            this.dgvx_Doc_ShopC_Item_Source.ReadOnly = true;
            this.dgvx_Doc_ShopC_Item_Source.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Doc_ShopC_Item_Source.Size = new System.Drawing.Size(179, 323);
            this.dgvx_Doc_ShopC_Item_Source.TabIndex = 5;
            // 
            // lbl_dgvx_Doc_ShopC_Item_Source
            // 
            this.lbl_dgvx_Doc_ShopC_Item_Source.AutoSize = true;
            this.lbl_dgvx_Doc_ShopC_Item_Source.Location = new System.Drawing.Point(3, 8);
            this.lbl_dgvx_Doc_ShopC_Item_Source.Name = "lbl_dgvx_Doc_ShopC_Item_Source";
            this.lbl_dgvx_Doc_ShopC_Item_Source.Size = new System.Drawing.Size(35, 13);
            this.lbl_dgvx_Doc_ShopC_Item_Source.TabIndex = 5;
            this.lbl_dgvx_Doc_ShopC_Item_Source.Text = "label1";
            // 
            // Form_ShopC_TableInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 686);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ShopC_TableInspection";
            this.Text = "Form_ShopC_TableInspection";
            this.Load += new System.EventHandler(this.Form_ShopC_TableInspection_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopC_Docs)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_DocID_ShopC_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Stock)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Doc_ShopC_Item_Source)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataGridView_2xls.DataGridView2xls dgvx_ShopC_Docs;
        private System.Windows.Forms.RadioButton rdb_ProformaInvoice;
        private System.Windows.Forms.RadioButton rdb_Invoice;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_Doc_Info;
        private DataGridView_2xls.DataGridView2xls dgvx_DocID_ShopC_Items;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.CheckBox chk_OnlyFromStock;
        private System.Windows.Forms.Label lbl_Stock_Info;
        private DataGridView_2xls.DataGridView2xls dgvx_Stock;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_dgvx_Doc_ShopC_Item_Source;
        private DataGridView_2xls.DataGridView2xls dgvx_Doc_ShopC_Item_Source;
    }
}