namespace ShopC
{
    partial class usrc_ShopC
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.usrc_Atom_ItemsList = new ShopC.usrc_Atom_ItemsList();
            this.usrc_ItemList = new ShopC.usrc_ItemList();
            this.lbl_ShopC_Name = new System.Windows.Forms.Label();
            this.btn_Stock = new System.Windows.Forms.Button();
            this.lbl_Items = new System.Windows.Forms.Label();
            this.btn_Items = new System.Windows.Forms.Button();
            this.lbl_Stock = new System.Windows.Forms.Label();
            this.usrc_PriceList1 = new PriseLists.usrc_PriceList();
            this.chk_AutomaticSelectionOfItemFromStock = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(0, 33);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.usrc_Atom_ItemsList);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer3.Panel2.Controls.Add(this.usrc_ItemList);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(1260, 505);
            this.splitContainer3.SplitterDistance = 597;
            this.splitContainer3.TabIndex = 1;
            // 
            // usrc_Atom_ItemsList
            // 
            this.usrc_Atom_ItemsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Atom_ItemsList.DocInvoice = "DocInvoice";
            this.usrc_Atom_ItemsList.Location = new System.Drawing.Point(5, 6);
            this.usrc_Atom_ItemsList.Margin = new System.Windows.Forms.Padding(5);
            this.usrc_Atom_ItemsList.Name = "usrc_Atom_ItemsList";
            this.usrc_Atom_ItemsList.NumberOfItemsPerPage = 10;
            this.usrc_Atom_ItemsList.Size = new System.Drawing.Size(583, 493);
            this.usrc_Atom_ItemsList.TabIndex = 5;
            // 
            // usrc_ItemList
            // 
            this.usrc_ItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_ItemList.DocInvoice = "DocInvoice";
            this.usrc_ItemList.Location = new System.Drawing.Point(1, 6);
            this.usrc_ItemList.Margin = new System.Windows.Forms.Padding(5);
            this.usrc_ItemList.Name = "usrc_ItemList";
            this.usrc_ItemList.NumberOfItemsPerPage = 10;
            this.usrc_ItemList.Size = new System.Drawing.Size(653, 496);
            this.usrc_ItemList.TabIndex = 22;
            // 
            // lbl_ShopC_Name
            // 
            this.lbl_ShopC_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ShopC_Name.AutoSize = true;
            this.lbl_ShopC_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ShopC_Name.Location = new System.Drawing.Point(343, 5);
            this.lbl_ShopC_Name.Name = "lbl_ShopC_Name";
            this.lbl_ShopC_Name.Size = new System.Drawing.Size(103, 17);
            this.lbl_ShopC_Name.TabIndex = 4;
            this.lbl_ShopC_Name.Text = "Izbrani Artikli";
            // 
            // btn_Stock
            // 
            this.btn_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Stock.Image = global::ShopC.Properties.Resources.Edit;
            this.btn_Stock.Location = new System.Drawing.Point(1064, 3);
            this.btn_Stock.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stock.Name = "btn_Stock";
            this.btn_Stock.Size = new System.Drawing.Size(37, 28);
            this.btn_Stock.TabIndex = 21;
            this.btn_Stock.UseVisualStyleBackColor = true;
            this.btn_Stock.Click += new System.EventHandler(this.btn_Stock_Click);
            // 
            // lbl_Items
            // 
            this.lbl_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Items.AutoSize = true;
            this.lbl_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Items.Location = new System.Drawing.Point(1147, 8);
            this.lbl_Items.Name = "lbl_Items";
            this.lbl_Items.Size = new System.Drawing.Size(49, 17);
            this.lbl_Items.TabIndex = 20;
            this.lbl_Items.Text = "Artikli";
            // 
            // btn_Items
            // 
            this.btn_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Items.Image = global::ShopC.Properties.Resources.Edit;
            this.btn_Items.Location = new System.Drawing.Point(1216, 3);
            this.btn_Items.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Items.Name = "btn_Items";
            this.btn_Items.Size = new System.Drawing.Size(37, 28);
            this.btn_Items.TabIndex = 19;
            this.btn_Items.UseVisualStyleBackColor = true;
            this.btn_Items.Click += new System.EventHandler(this.btn_Items_Click);
            // 
            // lbl_Stock
            // 
            this.lbl_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Stock.AutoSize = true;
            this.lbl_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Stock.Location = new System.Drawing.Point(982, 9);
            this.lbl_Stock.Name = "lbl_Stock";
            this.lbl_Stock.Size = new System.Drawing.Size(58, 17);
            this.lbl_Stock.TabIndex = 5;
            this.lbl_Stock.Text = "Zaloge";
            // 
            // usrc_PriceList1
            // 
            this.usrc_PriceList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.usrc_PriceList1.Location = new System.Drawing.Point(1, 0);
            this.usrc_PriceList1.Name = "usrc_PriceList1";
            this.usrc_PriceList1.Size = new System.Drawing.Size(278, 24);
            this.usrc_PriceList1.TabIndex = 22;
            this.usrc_PriceList1.PriceListChanged += new PriseLists.usrc_PriceList.delegate_PriceListChanged(this.usrc_PriceList1_PriceListChanged);
            // 
            // chk_AutomaticSelectionOfItemFromStock
            // 
            this.chk_AutomaticSelectionOfItemFromStock.AutoSize = true;
            this.chk_AutomaticSelectionOfItemFromStock.Location = new System.Drawing.Point(508, 7);
            this.chk_AutomaticSelectionOfItemFromStock.Name = "chk_AutomaticSelectionOfItemFromStock";
            this.chk_AutomaticSelectionOfItemFromStock.Size = new System.Drawing.Size(199, 17);
            this.chk_AutomaticSelectionOfItemFromStock.TabIndex = 23;
            this.chk_AutomaticSelectionOfItemFromStock.Text = "AutomaticSelectionOfItemFromStock";
            this.chk_AutomaticSelectionOfItemFromStock.UseVisualStyleBackColor = true;
            // 
            // usrc_ShopC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.chk_AutomaticSelectionOfItemFromStock);
            this.Controls.Add(this.usrc_PriceList1);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.lbl_Items);
            this.Controls.Add(this.btn_Stock);
            this.Controls.Add(this.btn_Items);
            this.Controls.Add(this.lbl_ShopC_Name);
            this.Controls.Add(this.lbl_Stock);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ShopC";
            this.Size = new System.Drawing.Size(1260, 538);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_ShopC_Name;
        private System.Windows.Forms.Button btn_Stock;
        private System.Windows.Forms.Label lbl_Items;
        private System.Windows.Forms.Button btn_Items;
        private System.Windows.Forms.Label lbl_Stock;
        public usrc_Atom_ItemsList usrc_Atom_ItemsList;
        public usrc_ItemList usrc_ItemList;
        public PriseLists.usrc_PriceList usrc_PriceList1;
        private System.Windows.Forms.CheckBox chk_AutomaticSelectionOfItemFromStock;
    }
}
