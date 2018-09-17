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
            this.txt_Item_Description = new System.Windows.Forms.TextBox();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.pic_Item = new System.Windows.Forms.PictureBox();
            this.uItemStock = new ShopC.usrc_btn_Item();
            this.uItemFactory = new ShopC.usrc_btn_Item();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(92, 2);
            this.lbl_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(516, 16);
            this.lbl_Item.TabIndex = 0;
            this.lbl_Item.Text = "label1";
            this.lbl_Item.Click += new System.EventHandler(this.lbl_Item_Click);
            // 
            // txt_Item_Description
            // 
            this.txt_Item_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Item_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Item_Description.Location = new System.Drawing.Point(587, 59);
            this.txt_Item_Description.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Item_Description.Multiline = true;
            this.txt_Item_Description.Name = "txt_Item_Description";
            this.txt_Item_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Item_Description.Size = new System.Drawing.Size(71, 31);
            this.txt_Item_Description.TabIndex = 7;
            // 
            // btn_Discount
            // 
            this.btn_Discount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopC.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(585, 19);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(75, 34);
            this.btn_Discount.TabIndex = 12;
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItem.Image = global::ShopC.Properties.Resources.ItemStock_Edit;
            this.btn_EditItem.Location = new System.Drawing.Point(616, 1);
            this.btn_EditItem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(44, 19);
            this.btn_EditItem.TabIndex = 6;
            this.btn_EditItem.UseVisualStyleBackColor = false;
            this.btn_EditItem.Click += new System.EventHandler(this.btn_EditItem_Click);
            // 
            // pic_Item
            // 
            this.pic_Item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pic_Item.Location = new System.Drawing.Point(3, 2);
            this.pic_Item.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Item.Name = "pic_Item";
            this.pic_Item.Size = new System.Drawing.Size(79, 90);
            this.pic_Item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Item.TabIndex = 1;
            this.pic_Item.TabStop = false;
            // 
            // uItemStock
            // 
            this.uItemStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uItemStock.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uItemStock.ButtonItemText = "";
            this.uItemStock.DecimalPlaces = 2;
            this.uItemStock.Image = global::ShopC.Properties.Resources.Item_Stock;
            this.uItemStock.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uItemStock.Location = new System.Drawing.Point(85, 19);
            this.uItemStock.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.uItemStock.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemStock.Name = "uItemStock";
            this.uItemStock.PriceLabelText = "Price:";
            this.uItemStock.PriceText = "Price:";
            this.uItemStock.QuantityText = "Quantity";
            this.uItemStock.ReadOnly = false;
            this.uItemStock.Size = new System.Drawing.Size(259, 73);
            this.uItemStock.StockLabelText = "Price:";
            this.uItemStock.StockText = "Price:";
            this.uItemStock.TabIndex = 13;
            this.uItemStock.Type = DynEditControls.usrc_NumericUpDown2.eType.INTEGER;
            this.uItemStock.Unit = "";
            this.uItemStock.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemStock.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uItemStock.ClickItem += new System.EventHandler(this.uItemStock_Click);
            this.uItemStock.ValueChanged += new System.EventHandler(this.uItemStock_ValueChanged);
            // 
            // uItemFactory
            // 
            this.uItemFactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uItemFactory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.uItemFactory.ButtonItemText = "";
            this.uItemFactory.DecimalPlaces = 2;
            this.uItemFactory.Image = global::ShopC.Properties.Resources.Item_NoStock;
            this.uItemFactory.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uItemFactory.Location = new System.Drawing.Point(354, 19);
            this.uItemFactory.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.uItemFactory.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemFactory.Name = "uItemFactory";
            this.uItemFactory.PriceLabelText = "Price:";
            this.uItemFactory.PriceText = "Price:";
            this.uItemFactory.QuantityText = "Quantity";
            this.uItemFactory.ReadOnly = false;
            this.uItemFactory.Size = new System.Drawing.Size(224, 73);
            this.uItemFactory.StockLabelText = "Price:";
            this.uItemFactory.StockText = "Price:";
            this.uItemFactory.TabIndex = 14;
            this.uItemFactory.Type = DynEditControls.usrc_NumericUpDown2.eType.INTEGER;
            this.uItemFactory.Unit = "";
            this.uItemFactory.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemFactory.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uItemFactory.ClickItem += new System.EventHandler(this.uItemFactory_Click);
            this.uItemFactory.ValueChanged += new System.EventHandler(this.uItemFactory_ValueChanged);
            this.uItemFactory.Load += new System.EventHandler(this.uItemFactory_Load);
            // 
            // usrc_Item
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.uItemFactory);
            this.Controls.Add(this.uItemStock);
            this.Controls.Add(this.btn_Discount);
            this.Controls.Add(this.txt_Item_Description);
            this.Controls.Add(this.btn_EditItem);
            this.Controls.Add(this.pic_Item);
            this.Controls.Add(this.lbl_Item);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item";
            this.Size = new System.Drawing.Size(664, 94);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_EditItem;
        private System.Windows.Forms.TextBox txt_Item_Description;
        internal System.Windows.Forms.PictureBox pic_Item;
        internal System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.Button btn_Discount;
        private usrc_btn_Item uItemStock;
        private usrc_btn_Item uItemFactory;
    }
}
