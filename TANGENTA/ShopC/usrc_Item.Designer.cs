namespace ShopC
{
    partial class usrc_Item
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Item = new System.Windows.Forms.Label();
            this.lbl_InStock = new System.Windows.Forms.Label();
            this.txt_InStock = new System.Windows.Forms.TextBox();
            this.txt_Item_Description = new System.Windows.Forms.TextBox();
            this.lbl_ItemPrice = new System.Windows.Forms.Label();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.btn_NoStock = new System.Windows.Forms.Button();
            this.btn_Stock = new System.Windows.Forms.Button();
            this.pic_Item = new System.Windows.Forms.PictureBox();
            this.nmUpDn_FactoryQuantity = new DynEditControls.usrc_NumericUpDown2();
            this.nmUpDn_StockQuantity = new DynEditControls.usrc_NumericUpDown2();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(112, 2);
            this.lbl_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(461, 16);
            this.lbl_Item.TabIndex = 0;
            this.lbl_Item.Text = "label1";
            this.lbl_Item.Click += new System.EventHandler(this.lbl_Item_Click);
            // 
            // lbl_InStock
            // 
            this.lbl_InStock.AutoSize = true;
            this.lbl_InStock.Location = new System.Drawing.Point(183, 22);
            this.lbl_InStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_InStock.Name = "lbl_InStock";
            this.lbl_InStock.Size = new System.Drawing.Size(53, 13);
            this.lbl_InStock.TabIndex = 4;
            this.lbl_InStock.Text = "Na Zalogi";
            // 
            // txt_InStock
            // 
            this.txt_InStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_InStock.Location = new System.Drawing.Point(249, 19);
            this.txt_InStock.Margin = new System.Windows.Forms.Padding(4);
            this.txt_InStock.Name = "txt_InStock";
            this.txt_InStock.ReadOnly = true;
            this.txt_InStock.Size = new System.Drawing.Size(87, 20);
            this.txt_InStock.TabIndex = 5;
            this.txt_InStock.Text = "000";
            // 
            // txt_Item_Description
            // 
            this.txt_Item_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Item_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Item_Description.Location = new System.Drawing.Point(540, 69);
            this.txt_Item_Description.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Item_Description.Multiline = true;
            this.txt_Item_Description.Name = "txt_Item_Description";
            this.txt_Item_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Item_Description.Size = new System.Drawing.Size(89, 16);
            this.txt_Item_Description.TabIndex = 7;
            // 
            // lbl_ItemPrice
            // 
            this.lbl_ItemPrice.AutoSize = true;
            this.lbl_ItemPrice.Location = new System.Drawing.Point(353, 24);
            this.lbl_ItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ItemPrice.Name = "lbl_ItemPrice";
            this.lbl_ItemPrice.Size = new System.Drawing.Size(35, 13);
            this.lbl_ItemPrice.TabIndex = 8;
            this.lbl_ItemPrice.Text = "Cena:";
            // 
            // txt_Price
            // 
            this.txt_Price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Price.Location = new System.Drawing.Point(398, 20);
            this.txt_Price.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.ReadOnly = true;
            this.txt_Price.Size = new System.Drawing.Size(87, 20);
            this.txt_Price.TabIndex = 9;
            // 
            // btn_Discount
            // 
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopC.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(545, 24);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(89, 30);
            this.btn_Discount.TabIndex = 12;
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItem.Image = global::ShopC.Properties.Resources.ItemStock_Edit;
            this.btn_EditItem.Location = new System.Drawing.Point(581, 0);
            this.btn_EditItem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(44, 24);
            this.btn_EditItem.TabIndex = 6;
            this.btn_EditItem.UseVisualStyleBackColor = false;
            this.btn_EditItem.Click += new System.EventHandler(this.btn_EditItem_Click);
            // 
            // btn_NoStock
            // 
            this.btn_NoStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_NoStock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_NoStock.Enabled = false;
            this.btn_NoStock.Image = global::ShopC.Properties.Resources.Item_NoStock;
            this.btn_NoStock.Location = new System.Drawing.Point(323, 42);
            this.btn_NoStock.Margin = new System.Windows.Forms.Padding(4);
            this.btn_NoStock.Name = "btn_NoStock";
            this.btn_NoStock.Size = new System.Drawing.Size(72, 44);
            this.btn_NoStock.TabIndex = 3;
            this.btn_NoStock.UseVisualStyleBackColor = false;
            this.btn_NoStock.Click += new System.EventHandler(this.btn_Factory_Click);
            // 
            // btn_Stock
            // 
            this.btn_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Stock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Stock.Image = global::ShopC.Properties.Resources.Item_Stock;
            this.btn_Stock.Location = new System.Drawing.Point(108, 19);
            this.btn_Stock.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stock.Name = "btn_Stock";
            this.btn_Stock.Size = new System.Drawing.Size(72, 68);
            this.btn_Stock.TabIndex = 2;
            this.btn_Stock.UseVisualStyleBackColor = false;
            this.btn_Stock.Click += new System.EventHandler(this.btn_Stock_Click);
            // 
            // pic_Item
            // 
            this.pic_Item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pic_Item.Location = new System.Drawing.Point(4, 4);
            this.pic_Item.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Item.Name = "pic_Item";
            this.pic_Item.Size = new System.Drawing.Size(100, 81);
            this.pic_Item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Item.TabIndex = 1;
            this.pic_Item.TabStop = false;
            // 
            // nmUpDn_FactoryQuantity
            // 
            this.nmUpDn_FactoryQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nmUpDn_FactoryQuantity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nmUpDn_FactoryQuantity.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nmUpDn_FactoryQuantity.DecimalPlaces = 2;
            this.nmUpDn_FactoryQuantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_FactoryQuantity.Location = new System.Drawing.Point(402, 41);
            this.nmUpDn_FactoryQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDn_FactoryQuantity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nmUpDn_FactoryQuantity.Name = "nmUpDn_FactoryQuantity";
            this.nmUpDn_FactoryQuantity.ReadOnly = false;
            this.nmUpDn_FactoryQuantity.Size = new System.Drawing.Size(136, 45);
            this.nmUpDn_FactoryQuantity.TabIndex = 14;
            this.nmUpDn_FactoryQuantity.Type = DynEditControls.usrc_NumericUpDown2.eType.DECIMAL;
            this.nmUpDn_FactoryQuantity.Unit = "l";
            this.nmUpDn_FactoryQuantity.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.nmUpDn_FactoryQuantity.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_FactoryQuantity.ValueChanged += new System.EventHandler(this.nmUpDn_FactoryQuantity_ValueChanged);
            // 
            // nmUpDn_StockQuantity
            // 
            this.nmUpDn_StockQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nmUpDn_StockQuantity.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nmUpDn_StockQuantity.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nmUpDn_StockQuantity.DecimalPlaces = 2;
            this.nmUpDn_StockQuantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_StockQuantity.Location = new System.Drawing.Point(187, 41);
            this.nmUpDn_StockQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDn_StockQuantity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nmUpDn_StockQuantity.Name = "nmUpDn_StockQuantity";
            this.nmUpDn_StockQuantity.ReadOnly = false;
            this.nmUpDn_StockQuantity.Size = new System.Drawing.Size(129, 45);
            this.nmUpDn_StockQuantity.TabIndex = 13;
            this.nmUpDn_StockQuantity.Type = DynEditControls.usrc_NumericUpDown2.eType.DECIMAL;
            this.nmUpDn_StockQuantity.Unit = "";
            this.nmUpDn_StockQuantity.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.nmUpDn_StockQuantity.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_StockQuantity.ValueChanged += new System.EventHandler(this.nmUpDn_StockQuantity_ValueChanged);
            // 
            // usrc_Item
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.nmUpDn_FactoryQuantity);
            this.Controls.Add(this.nmUpDn_StockQuantity);
            this.Controls.Add(this.btn_Discount);
            this.Controls.Add(this.txt_Price);
            this.Controls.Add(this.lbl_ItemPrice);
            this.Controls.Add(this.txt_Item_Description);
            this.Controls.Add(this.btn_EditItem);
            this.Controls.Add(this.txt_InStock);
            this.Controls.Add(this.lbl_InStock);
            this.Controls.Add(this.btn_NoStock);
            this.Controls.Add(this.btn_Stock);
            this.Controls.Add(this.pic_Item);
            this.Controls.Add(this.lbl_Item);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item";
            this.Size = new System.Drawing.Size(635, 89);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Stock;
        private System.Windows.Forms.Button btn_NoStock;
        private System.Windows.Forms.Label lbl_InStock;
        private System.Windows.Forms.TextBox txt_InStock;
        private System.Windows.Forms.Button btn_EditItem;
        private System.Windows.Forms.TextBox txt_Item_Description;
        private System.Windows.Forms.Label lbl_ItemPrice;
        private System.Windows.Forms.TextBox txt_Price;
        internal System.Windows.Forms.PictureBox pic_Item;
        internal System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.Button btn_Discount;
        private DynEditControls.usrc_NumericUpDown2 nmUpDn_StockQuantity;
        private DynEditControls.usrc_NumericUpDown2 nmUpDn_FactoryQuantity;
    }
}
