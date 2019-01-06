namespace ShopC_Forms
{
    partial class usrc_StockTake_Item
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
            this.chk_VATCanNotBeDeducted = new System.Windows.Forms.CheckBox();
            this.lbl_PriceWithVAT = new System.Windows.Forms.Label();
            this.txt_TotalWithTax = new System.Windows.Forms.TextBox();
            this.txt_PriceWithDiscountWithTax = new System.Windows.Forms.TextBox();
            this.cmb_PurchasePriceWithoutDiscountAndWithTax = new System.Windows.Forms.ComboBox();
            this.lbl_PriceWithoutVAT = new System.Windows.Forms.Label();
            this.txt_TotalWithoutTax = new System.Windows.Forms.TextBox();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.txt_PriceWithDiscountWithoutTax = new System.Windows.Forms.TextBox();
            this.lbl_PriceWithDiscount = new System.Windows.Forms.Label();
            this.cmb_Discount = new System.Windows.Forms.ComboBox();
            this.lbl_Discount = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.nmUpDn_Quantity = new System.Windows.Forms.NumericUpDown();
            this.cmb_Taxation = new System.Windows.Forms.ComboBox();
            this.lbl_Taxation = new System.Windows.Forms.Label();
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax = new System.Windows.Forms.ComboBox();
            this.lbl_PurchasePrice = new System.Windows.Forms.Label();
            this.cmb_Currency = new System.Windows.Forms.ComboBox();
            this.lbl_Currency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_VATCanNotBeDeducted
            // 
            this.chk_VATCanNotBeDeducted.AutoSize = true;
            this.chk_VATCanNotBeDeducted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_VATCanNotBeDeducted.Location = new System.Drawing.Point(384, 6);
            this.chk_VATCanNotBeDeducted.Name = "chk_VATCanNotBeDeducted";
            this.chk_VATCanNotBeDeducted.Size = new System.Drawing.Size(150, 17);
            this.chk_VATCanNotBeDeducted.TabIndex = 46;
            this.chk_VATCanNotBeDeducted.Text = "VAT can be deducted";
            this.chk_VATCanNotBeDeducted.UseVisualStyleBackColor = true;
            // 
            // lbl_PriceWithVAT
            // 
            this.lbl_PriceWithVAT.AutoSize = true;
            this.lbl_PriceWithVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PriceWithVAT.Location = new System.Drawing.Point(2, 77);
            this.lbl_PriceWithVAT.Name = "lbl_PriceWithVAT";
            this.lbl_PriceWithVAT.Size = new System.Drawing.Size(91, 13);
            this.lbl_PriceWithVAT.TabIndex = 45;
            this.lbl_PriceWithVAT.Text = "Price with VAT";
            // 
            // txt_TotalWithTax
            // 
            this.txt_TotalWithTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_TotalWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_TotalWithTax.Location = new System.Drawing.Point(465, 66);
            this.txt_TotalWithTax.Name = "txt_TotalWithTax";
            this.txt_TotalWithTax.Size = new System.Drawing.Size(85, 20);
            this.txt_TotalWithTax.TabIndex = 44;
            this.txt_TotalWithTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TotalWithTax_KeyUp);
            // 
            // txt_PriceWithDiscountWithTax
            // 
            this.txt_PriceWithDiscountWithTax.BackColor = System.Drawing.Color.Cornsilk;
            this.txt_PriceWithDiscountWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PriceWithDiscountWithTax.Location = new System.Drawing.Point(288, 69);
            this.txt_PriceWithDiscountWithTax.Name = "txt_PriceWithDiscountWithTax";
            this.txt_PriceWithDiscountWithTax.Size = new System.Drawing.Size(84, 20);
            this.txt_PriceWithDiscountWithTax.TabIndex = 43;
            // 
            // cmb_PurchasePriceWithoutDiscountAndWithTax
            // 
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.Enabled = false;
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.FormattingEnabled = true;
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.Location = new System.Drawing.Point(118, 69);
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.Name = "cmb_PurchasePriceWithoutDiscountAndWithTax";
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.Size = new System.Drawing.Size(89, 21);
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.TabIndex = 42;
            this.cmb_PurchasePriceWithoutDiscountAndWithTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmb_PurchasePriceWithoutDiscountAndWithTax_KeyUp);
            // 
            // lbl_PriceWithoutVAT
            // 
            this.lbl_PriceWithoutVAT.AutoSize = true;
            this.lbl_PriceWithoutVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PriceWithoutVAT.Location = new System.Drawing.Point(2, 49);
            this.lbl_PriceWithoutVAT.Name = "lbl_PriceWithoutVAT";
            this.lbl_PriceWithoutVAT.Size = new System.Drawing.Size(109, 13);
            this.lbl_PriceWithoutVAT.TabIndex = 41;
            this.lbl_PriceWithoutVAT.Text = "Price without VAT";
            // 
            // txt_TotalWithoutTax
            // 
            this.txt_TotalWithoutTax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_TotalWithoutTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_TotalWithoutTax.Location = new System.Drawing.Point(465, 42);
            this.txt_TotalWithoutTax.Name = "txt_TotalWithoutTax";
            this.txt_TotalWithoutTax.Size = new System.Drawing.Size(85, 20);
            this.txt_TotalWithoutTax.TabIndex = 40;
            this.txt_TotalWithoutTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TotalWithoutTax_KeyUp);
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total.Location = new System.Drawing.Point(465, 28);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(31, 13);
            this.lbl_Total.TabIndex = 39;
            this.lbl_Total.Text = "Total";
            // 
            // txt_PriceWithDiscountWithoutTax
            // 
            this.txt_PriceWithDiscountWithoutTax.BackColor = System.Drawing.Color.Cornsilk;
            this.txt_PriceWithDiscountWithoutTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PriceWithDiscountWithoutTax.Location = new System.Drawing.Point(288, 45);
            this.txt_PriceWithDiscountWithoutTax.Name = "txt_PriceWithDiscountWithoutTax";
            this.txt_PriceWithDiscountWithoutTax.ReadOnly = true;
            this.txt_PriceWithDiscountWithoutTax.Size = new System.Drawing.Size(84, 20);
            this.txt_PriceWithDiscountWithoutTax.TabIndex = 38;
            // 
            // lbl_PriceWithDiscount
            // 
            this.lbl_PriceWithDiscount.AutoSize = true;
            this.lbl_PriceWithDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PriceWithDiscount.Location = new System.Drawing.Point(288, 31);
            this.lbl_PriceWithDiscount.Name = "lbl_PriceWithDiscount";
            this.lbl_PriceWithDiscount.Size = new System.Drawing.Size(87, 13);
            this.lbl_PriceWithDiscount.TabIndex = 37;
            this.lbl_PriceWithDiscount.Text = "Pr.With.Discount";
            // 
            // cmb_Discount
            // 
            this.cmb_Discount.Enabled = false;
            this.cmb_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Discount.FormattingEnabled = true;
            this.cmb_Discount.Location = new System.Drawing.Point(210, 45);
            this.cmb_Discount.Name = "cmb_Discount";
            this.cmb_Discount.Size = new System.Drawing.Size(74, 21);
            this.cmb_Discount.TabIndex = 36;
            // 
            // lbl_Discount
            // 
            this.lbl_Discount.AutoSize = true;
            this.lbl_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Discount.Location = new System.Drawing.Point(212, 31);
            this.lbl_Discount.Name = "lbl_Discount";
            this.lbl_Discount.Size = new System.Drawing.Size(52, 13);
            this.lbl_Discount.TabIndex = 35;
            this.lbl_Discount.Text = "Discount:";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity.Location = new System.Drawing.Point(5, 5);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(49, 13);
            this.lbl_Quantity.TabIndex = 34;
            this.lbl_Quantity.Text = "Quantity:";
            // 
            // nmUpDn_Quantity
            // 
            this.nmUpDn_Quantity.Enabled = false;
            this.nmUpDn_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.nmUpDn_Quantity.Location = new System.Drawing.Point(60, 3);
            this.nmUpDn_Quantity.Name = "nmUpDn_Quantity";
            this.nmUpDn_Quantity.Size = new System.Drawing.Size(59, 20);
            this.nmUpDn_Quantity.TabIndex = 33;
            this.nmUpDn_Quantity.ValueChanged += new System.EventHandler(this.nmUpDn_Quantity_ValueChanged);
            // 
            // cmb_Taxation
            // 
            this.cmb_Taxation.Enabled = false;
            this.cmb_Taxation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Taxation.FormattingEnabled = true;
            this.cmb_Taxation.Location = new System.Drawing.Point(376, 42);
            this.cmb_Taxation.Name = "cmb_Taxation";
            this.cmb_Taxation.Size = new System.Drawing.Size(86, 21);
            this.cmb_Taxation.TabIndex = 32;
            // 
            // lbl_Taxation
            // 
            this.lbl_Taxation.AutoSize = true;
            this.lbl_Taxation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Taxation.Location = new System.Drawing.Point(381, 26);
            this.lbl_Taxation.Name = "lbl_Taxation";
            this.lbl_Taxation.Size = new System.Drawing.Size(51, 13);
            this.lbl_Taxation.TabIndex = 31;
            this.lbl_Taxation.Text = "Taxation:";
            // 
            // cmb_PurchasePriceWithoutDiscountAndWithoutTax
            // 
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Enabled = false;
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.FormattingEnabled = true;
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Location = new System.Drawing.Point(118, 45);
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Name = "cmb_PurchasePriceWithoutDiscountAndWithoutTax";
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.Size = new System.Drawing.Size(89, 21);
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.TabIndex = 30;
            this.cmb_PurchasePriceWithoutDiscountAndWithoutTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmb_PurchasePriceWithoutDiscountAndWithoutTax_KeyUp);
            // 
            // lbl_PurchasePrice
            // 
            this.lbl_PurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PurchasePrice.Location = new System.Drawing.Point(117, 31);
            this.lbl_PurchasePrice.Name = "lbl_PurchasePrice";
            this.lbl_PurchasePrice.Size = new System.Drawing.Size(87, 13);
            this.lbl_PurchasePrice.TabIndex = 29;
            this.lbl_PurchasePrice.Text = "Purchase Price:";
            this.lbl_PurchasePrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_Currency
            // 
            this.cmb_Currency.Enabled = false;
            this.cmb_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Currency.FormattingEnabled = true;
            this.cmb_Currency.Location = new System.Drawing.Point(263, 3);
            this.cmb_Currency.Name = "cmb_Currency";
            this.cmb_Currency.Size = new System.Drawing.Size(103, 21);
            this.cmb_Currency.TabIndex = 48;
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Currency.Location = new System.Drawing.Point(130, 7);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(127, 13);
            this.lbl_Currency.TabIndex = 47;
            this.lbl_Currency.Text = "Currency:";
            this.lbl_Currency.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // usrc_StockTake_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cmb_Currency);
            this.Controls.Add(this.lbl_Currency);
            this.Controls.Add(this.chk_VATCanNotBeDeducted);
            this.Controls.Add(this.lbl_PriceWithVAT);
            this.Controls.Add(this.txt_TotalWithTax);
            this.Controls.Add(this.txt_PriceWithDiscountWithTax);
            this.Controls.Add(this.cmb_PurchasePriceWithoutDiscountAndWithTax);
            this.Controls.Add(this.lbl_PriceWithoutVAT);
            this.Controls.Add(this.txt_TotalWithoutTax);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.txt_PriceWithDiscountWithoutTax);
            this.Controls.Add(this.lbl_PriceWithDiscount);
            this.Controls.Add(this.cmb_Discount);
            this.Controls.Add(this.lbl_Discount);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.nmUpDn_Quantity);
            this.Controls.Add(this.cmb_Taxation);
            this.Controls.Add(this.lbl_Taxation);
            this.Controls.Add(this.cmb_PurchasePriceWithoutDiscountAndWithoutTax);
            this.Controls.Add(this.lbl_PurchasePrice);
            this.Name = "usrc_StockTake_Item";
            this.Size = new System.Drawing.Size(556, 94);
            this.Load += new System.EventHandler(this.usrc_StockTake_Item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_PriceWithVAT;
        private System.Windows.Forms.TextBox txt_TotalWithTax;
        private System.Windows.Forms.TextBox txt_PriceWithDiscountWithTax;
        private System.Windows.Forms.Label lbl_PriceWithoutVAT;
        private System.Windows.Forms.TextBox txt_TotalWithoutTax;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.TextBox txt_PriceWithDiscountWithoutTax;
        private System.Windows.Forms.Label lbl_PriceWithDiscount;
        private System.Windows.Forms.Label lbl_Discount;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.Label lbl_Taxation;
        private System.Windows.Forms.Label lbl_PurchasePrice;
        private System.Windows.Forms.CheckBox chk_VATCanNotBeDeducted;
        private System.Windows.Forms.ComboBox cmb_PurchasePriceWithoutDiscountAndWithTax;
        private System.Windows.Forms.ComboBox cmb_Discount;
        private System.Windows.Forms.NumericUpDown nmUpDn_Quantity;
        private System.Windows.Forms.ComboBox cmb_Taxation;
        private System.Windows.Forms.ComboBox cmb_PurchasePriceWithoutDiscountAndWithoutTax;
        private System.Windows.Forms.ComboBox cmb_Currency;
        private System.Windows.Forms.Label lbl_Currency;
    }
}
