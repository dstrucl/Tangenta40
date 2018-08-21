namespace ShopC
{
    partial class usrc_Item1366x768
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
            this.uItemStock = new ShopC.usrc_btn_Item();
            this.chk_FromStock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(4, 2);
            this.lbl_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(258, 36);
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
            this.txt_Item_Description.Location = new System.Drawing.Point(265, 2);
            this.txt_Item_Description.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Item_Description.Multiline = true;
            this.txt_Item_Description.Name = "txt_Item_Description";
            this.txt_Item_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Item_Description.Size = new System.Drawing.Size(110, 38);
            this.txt_Item_Description.TabIndex = 7;
            // 
            // btn_Discount
            // 
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopC.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(332, 41);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(47, 75);
            this.btn_Discount.TabIndex = 12;
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
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
            this.uItemStock.Location = new System.Drawing.Point(1, 41);
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
            this.uItemStock.Size = new System.Drawing.Size(258, 77);
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
            // chk_FromStock
            // 
            this.chk_FromStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chk_FromStock.Location = new System.Drawing.Point(264, 44);
            this.chk_FromStock.Name = "chk_FromStock";
            this.chk_FromStock.Size = new System.Drawing.Size(63, 71);
            this.chk_FromStock.TabIndex = 14;
            this.chk_FromStock.Text = "From Stock";
            this.chk_FromStock.UseVisualStyleBackColor = false;
            // 
            // usrc_Item1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.chk_FromStock);
            this.Controls.Add(this.uItemStock);
            this.Controls.Add(this.btn_Discount);
            this.Controls.Add(this.txt_Item_Description);
            this.Controls.Add(this.lbl_Item);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item1366x768";
            this.Size = new System.Drawing.Size(380, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Item_Description;
        internal System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.Button btn_Discount;
        private usrc_btn_Item uItemStock;
        private System.Windows.Forms.CheckBox chk_FromStock;
    }
}
