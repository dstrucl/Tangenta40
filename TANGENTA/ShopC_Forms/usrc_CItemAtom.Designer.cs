namespace ShopC_Forms
{
    partial class usrc_Atom_CItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_Atom_CItem));
            this.lbl_Item_UniqueName = new System.Windows.Forms.Label();
            this.lbl_PurchasePrice = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.btn_RemoveFromBasket = new System.Windows.Forms.Button();
            this.lbl_PurchasePriceDiscount = new System.Windows.Forms.Label();
            this.lbl_PurchasePricePerUnitWithoutDiscount = new System.Windows.Forms.Label();
            this.txt_PurchasePricePerUnitWithoutDiscount = new System.Windows.Forms.TextBox();
            this.txt_PurchasePriceDiscount = new System.Windows.Forms.TextBox();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.txt_PurchasePriceWithDiscount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Item_UniqueName
            // 
            this.lbl_Item_UniqueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Item_UniqueName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item_UniqueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item_UniqueName.Location = new System.Drawing.Point(3, 1);
            this.lbl_Item_UniqueName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item_UniqueName.Name = "lbl_Item_UniqueName";
            this.lbl_Item_UniqueName.Size = new System.Drawing.Size(296, 18);
            this.lbl_Item_UniqueName.TabIndex = 0;
            this.lbl_Item_UniqueName.Text = "label1";
            this.lbl_Item_UniqueName.Click += new System.EventHandler(this.lbl_Item_Click);
            // 
            // lbl_PurchasePrice
            // 
            this.lbl_PurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PurchasePrice.Location = new System.Drawing.Point(127, 63);
            this.lbl_PurchasePrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PurchasePrice.Name = "lbl_PurchasePrice";
            this.lbl_PurchasePrice.Size = new System.Drawing.Size(75, 13);
            this.lbl_PurchasePrice.TabIndex = 21;
            this.lbl_PurchasePrice.Text = "Purchase Price:";
            this.lbl_PurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PurchasePrice.Click += new System.EventHandler(this.lbl_DiscountValue_Click);
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity.Location = new System.Drawing.Point(1, 62);
            this.lbl_Quantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(47, 13);
            this.lbl_Quantity.TabIndex = 23;
            this.lbl_Quantity.Text = "Quantity:";
            this.lbl_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Quantity.Click += new System.EventHandler(this.lbl_DiscountText_Click);
            // 
            // btn_RemoveFromBasket
            // 
            this.btn_RemoveFromBasket.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_RemoveFromBasket.Image = ((System.Drawing.Image)(resources.GetObject("btn_RemoveFromBasket.Image")));
            this.btn_RemoveFromBasket.Location = new System.Drawing.Point(301, 3);
            this.btn_RemoveFromBasket.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RemoveFromBasket.Name = "btn_RemoveFromBasket";
            this.btn_RemoveFromBasket.Size = new System.Drawing.Size(62, 75);
            this.btn_RemoveFromBasket.TabIndex = 25;
            this.btn_RemoveFromBasket.UseVisualStyleBackColor = false;
            this.btn_RemoveFromBasket.Visible = false;
            this.btn_RemoveFromBasket.Click += new System.EventHandler(this.btn_RemoveFromBasket_Click);
            // 
            // lbl_PurchasePriceDiscount
            // 
            this.lbl_PurchasePriceDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PurchasePriceDiscount.Location = new System.Drawing.Point(4, 42);
            this.lbl_PurchasePriceDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PurchasePriceDiscount.Name = "lbl_PurchasePriceDiscount";
            this.lbl_PurchasePriceDiscount.Size = new System.Drawing.Size(191, 13);
            this.lbl_PurchasePriceDiscount.TabIndex = 27;
            this.lbl_PurchasePriceDiscount.Text = "Purchase Price Discount";
            this.lbl_PurchasePriceDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_PurchasePriceDiscount.Click += new System.EventHandler(this.lbl_Quantity_Value_Click);
            // 
            // lbl_PurchasePricePerUnitWithoutDiscount
            // 
            this.lbl_PurchasePricePerUnitWithoutDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PurchasePricePerUnitWithoutDiscount.Location = new System.Drawing.Point(4, 25);
            this.lbl_PurchasePricePerUnitWithoutDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PurchasePricePerUnitWithoutDiscount.Name = "lbl_PurchasePricePerUnitWithoutDiscount";
            this.lbl_PurchasePricePerUnitWithoutDiscount.Size = new System.Drawing.Size(196, 13);
            this.lbl_PurchasePricePerUnitWithoutDiscount.TabIndex = 28;
            this.lbl_PurchasePricePerUnitWithoutDiscount.Text = "PurchasePrice Per Unit ";
            this.lbl_PurchasePricePerUnitWithoutDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_PurchasePricePerUnitWithoutDiscount
            // 
            this.txt_PurchasePricePerUnitWithoutDiscount.Location = new System.Drawing.Point(205, 20);
            this.txt_PurchasePricePerUnitWithoutDiscount.Name = "txt_PurchasePricePerUnitWithoutDiscount";
            this.txt_PurchasePricePerUnitWithoutDiscount.ReadOnly = true;
            this.txt_PurchasePricePerUnitWithoutDiscount.Size = new System.Drawing.Size(94, 20);
            this.txt_PurchasePricePerUnitWithoutDiscount.TabIndex = 29;
            // 
            // txt_PurchasePriceDiscount
            // 
            this.txt_PurchasePriceDiscount.Location = new System.Drawing.Point(205, 40);
            this.txt_PurchasePriceDiscount.Name = "txt_PurchasePriceDiscount";
            this.txt_PurchasePriceDiscount.ReadOnly = true;
            this.txt_PurchasePriceDiscount.Size = new System.Drawing.Size(94, 20);
            this.txt_PurchasePriceDiscount.TabIndex = 30;
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Location = new System.Drawing.Point(51, 58);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.ReadOnly = true;
            this.txt_Quantity.Size = new System.Drawing.Size(72, 20);
            this.txt_Quantity.TabIndex = 31;
            // 
            // txt_PurchasePriceWithDiscount
            // 
            this.txt_PurchasePriceWithDiscount.Location = new System.Drawing.Point(205, 60);
            this.txt_PurchasePriceWithDiscount.Name = "txt_PurchasePriceWithDiscount";
            this.txt_PurchasePriceWithDiscount.ReadOnly = true;
            this.txt_PurchasePriceWithDiscount.Size = new System.Drawing.Size(94, 20);
            this.txt_PurchasePriceWithDiscount.TabIndex = 32;
            // 
            // usrc_Atom_CItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_PurchasePriceWithDiscount);
            this.Controls.Add(this.txt_Quantity);
            this.Controls.Add(this.txt_PurchasePriceDiscount);
            this.Controls.Add(this.txt_PurchasePricePerUnitWithoutDiscount);
            this.Controls.Add(this.lbl_PurchasePricePerUnitWithoutDiscount);
            this.Controls.Add(this.lbl_PurchasePriceDiscount);
            this.Controls.Add(this.btn_RemoveFromBasket);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.lbl_PurchasePrice);
            this.Controls.Add(this.lbl_Item_UniqueName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Atom_CItem";
            this.Size = new System.Drawing.Size(364, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_UniqueName;
        private System.Windows.Forms.Label lbl_PurchasePrice;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.Button btn_RemoveFromBasket;
        private System.Windows.Forms.Label lbl_PurchasePriceDiscount;
        private System.Windows.Forms.Label lbl_PurchasePricePerUnitWithoutDiscount;
        private System.Windows.Forms.TextBox txt_PurchasePricePerUnitWithoutDiscount;
        private System.Windows.Forms.TextBox txt_PurchasePriceDiscount;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.TextBox txt_PurchasePriceWithDiscount;
    }
}
