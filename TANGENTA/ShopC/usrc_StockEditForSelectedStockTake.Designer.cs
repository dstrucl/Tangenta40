namespace ShopC
{
    partial class usrc_StockEditForSelectedStockTake
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txt_StockDescription = new System.Windows.Forms.TextBox();
            this.lbl_Stock_Description = new System.Windows.Forms.Label();
            this.TPiick_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.nmUpDn_Quantity = new System.Windows.Forms.NumericUpDown();
            this.cmb_Taxation = new System.Windows.Forms.ComboBox();
            this.lbl_Taxation = new System.Windows.Forms.Label();
            this.cmb_Currency = new System.Windows.Forms.ComboBox();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.cmb_PurchasePrice = new System.Windows.Forms.ComboBox();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.lbl_PurchasePrice = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_StockTakeItems = new System.Windows.Forms.Label();
            this.dgvx_StockTakeItemsAndPrices = new System.Windows.Forms.DataGridView();
            this.lbl_ImportTime = new System.Windows.Forms.Label();
            this.tPick_ImportTime = new System.Windows.Forms.DateTimePicker();
            this.chk_ExpiryCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeItemsAndPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.Bisque;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(3, 31);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chk_ExpiryCheck);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_ImportTime);
            this.splitContainer2.Panel1.Controls.Add(this.tPick_ImportTime);
            this.splitContainer2.Panel1.Controls.Add(this.txt_StockDescription);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Stock_Description);
            this.splitContainer2.Panel1.Controls.Add(this.TPiick_ExpiryDate);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Quantity);
            this.splitContainer2.Panel1.Controls.Add(this.nmUpDn_Quantity);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_Taxation);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Taxation);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_Currency);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Currency);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_PurchasePrice);
            this.splitContainer2.Panel1.Controls.Add(this.btn_SelectItem);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Item);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_PurchasePrice);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Remove);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Add);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_StockTakeItems);
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_StockTakeItemsAndPrices);
            this.splitContainer2.Size = new System.Drawing.Size(594, 764);
            this.splitContainer2.SplitterDistance = 212;
            this.splitContainer2.TabIndex = 2;
            // 
            // txt_StockDescription
            // 
            this.txt_StockDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_StockDescription.Location = new System.Drawing.Point(12, 137);
            this.txt_StockDescription.Multiline = true;
            this.txt_StockDescription.Name = "txt_StockDescription";
            this.txt_StockDescription.Size = new System.Drawing.Size(574, 55);
            this.txt_StockDescription.TabIndex = 13;
            // 
            // lbl_Stock_Description
            // 
            this.lbl_Stock_Description.AutoSize = true;
            this.lbl_Stock_Description.Location = new System.Drawing.Point(10, 121);
            this.lbl_Stock_Description.Name = "lbl_Stock_Description";
            this.lbl_Stock_Description.Size = new System.Drawing.Size(94, 13);
            this.lbl_Stock_Description.TabIndex = 12;
            this.lbl_Stock_Description.Text = "Stock Description:";
            // 
            // TPiick_ExpiryDate
            // 
            this.TPiick_ExpiryDate.Location = new System.Drawing.Point(396, 111);
            this.TPiick_ExpiryDate.Name = "TPiick_ExpiryDate";
            this.TPiick_ExpiryDate.Size = new System.Drawing.Size(185, 20);
            this.TPiick_ExpiryDate.TabIndex = 10;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity.Location = new System.Drawing.Point(6, 44);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(58, 13);
            this.lbl_Quantity.TabIndex = 9;
            this.lbl_Quantity.Text = "Quantity:";
            // 
            // nmUpDn_Quantity
            // 
            this.nmUpDn_Quantity.Location = new System.Drawing.Point(66, 41);
            this.nmUpDn_Quantity.Name = "nmUpDn_Quantity";
            this.nmUpDn_Quantity.Size = new System.Drawing.Size(95, 20);
            this.nmUpDn_Quantity.TabIndex = 8;
            // 
            // cmb_Taxation
            // 
            this.cmb_Taxation.FormattingEnabled = true;
            this.cmb_Taxation.Location = new System.Drawing.Point(71, 65);
            this.cmb_Taxation.Name = "cmb_Taxation";
            this.cmb_Taxation.Size = new System.Drawing.Size(95, 21);
            this.cmb_Taxation.TabIndex = 7;
            // 
            // lbl_Taxation
            // 
            this.lbl_Taxation.AutoSize = true;
            this.lbl_Taxation.Location = new System.Drawing.Point(9, 68);
            this.lbl_Taxation.Name = "lbl_Taxation";
            this.lbl_Taxation.Size = new System.Drawing.Size(51, 13);
            this.lbl_Taxation.TabIndex = 6;
            this.lbl_Taxation.Text = "Taxation:";
            // 
            // cmb_Currency
            // 
            this.cmb_Currency.FormattingEnabled = true;
            this.cmb_Currency.Location = new System.Drawing.Point(259, 65);
            this.cmb_Currency.Name = "cmb_Currency";
            this.cmb_Currency.Size = new System.Drawing.Size(95, 21);
            this.cmb_Currency.TabIndex = 5;
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.AutoSize = true;
            this.lbl_Currency.Location = new System.Drawing.Point(201, 69);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(52, 13);
            this.lbl_Currency.TabIndex = 4;
            this.lbl_Currency.Text = "Currency:";
            // 
            // cmb_PurchasePrice
            // 
            this.cmb_PurchasePrice.FormattingEnabled = true;
            this.cmb_PurchasePrice.Location = new System.Drawing.Point(252, 41);
            this.cmb_PurchasePrice.Name = "cmb_PurchasePrice";
            this.cmb_PurchasePrice.Size = new System.Drawing.Size(103, 21);
            this.cmb_PurchasePrice.TabIndex = 3;
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectItem.Location = new System.Drawing.Point(325, 9);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(256, 27);
            this.btn_SelectItem.TabIndex = 2;
            this.btn_SelectItem.Text = "Select Item";
            this.btn_SelectItem.UseVisualStyleBackColor = true;
            this.btn_SelectItem.Click += new System.EventHandler(this.btn_SelectItem_Click);
            // 
            // lbl_Item
            // 
            this.lbl_Item.Location = new System.Drawing.Point(10, 9);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(299, 27);
            this.lbl_Item.TabIndex = 1;
            this.lbl_Item.Text = "Item:";
            // 
            // lbl_PurchasePrice
            // 
            this.lbl_PurchasePrice.AutoSize = true;
            this.lbl_PurchasePrice.Location = new System.Drawing.Point(162, 45);
            this.lbl_PurchasePrice.Name = "lbl_PurchasePrice";
            this.lbl_PurchasePrice.Size = new System.Drawing.Size(82, 13);
            this.lbl_PurchasePrice.TabIndex = 0;
            this.lbl_PurchasePrice.Text = "Purchase Price:";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(228, 3);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(60, 21);
            this.btn_Update.TabIndex = 19;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(295, 1);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(60, 23);
            this.btn_Remove.TabIndex = 18;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(158, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(60, 21);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbl_StockTakeItems
            // 
            this.lbl_StockTakeItems.AutoSize = true;
            this.lbl_StockTakeItems.Location = new System.Drawing.Point(5, 11);
            this.lbl_StockTakeItems.Name = "lbl_StockTakeItems";
            this.lbl_StockTakeItems.Size = new System.Drawing.Size(101, 13);
            this.lbl_StockTakeItems.TabIndex = 1;
            this.lbl_StockTakeItems.Text = "lbl_StockTakeItems";
            // 
            // dgvx_StockTakeItemsAndPrices
            // 
            this.dgvx_StockTakeItemsAndPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_StockTakeItemsAndPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_StockTakeItemsAndPrices.Location = new System.Drawing.Point(3, 27);
            this.dgvx_StockTakeItemsAndPrices.Name = "dgvx_StockTakeItemsAndPrices";
            this.dgvx_StockTakeItemsAndPrices.Size = new System.Drawing.Size(584, 505);
            this.dgvx_StockTakeItemsAndPrices.TabIndex = 0;
            // 
            // lbl_ImportTime
            // 
            this.lbl_ImportTime.AutoSize = true;
            this.lbl_ImportTime.Location = new System.Drawing.Point(11, 97);
            this.lbl_ImportTime.Name = "lbl_ImportTime";
            this.lbl_ImportTime.Size = new System.Drawing.Size(62, 13);
            this.lbl_ImportTime.TabIndex = 15;
            this.lbl_ImportTime.Text = "ImportTime:";
            // 
            // tPick_ImportTime
            // 
            this.tPick_ImportTime.Location = new System.Drawing.Point(93, 94);
            this.tPick_ImportTime.Name = "tPick_ImportTime";
            this.tPick_ImportTime.Size = new System.Drawing.Size(185, 20);
            this.tPick_ImportTime.TabIndex = 14;
            // 
            // chk_ExpiryCheck
            // 
            this.chk_ExpiryCheck.AutoSize = true;
            this.chk_ExpiryCheck.Location = new System.Drawing.Point(396, 93);
            this.chk_ExpiryCheck.Name = "chk_ExpiryCheck";
            this.chk_ExpiryCheck.Size = new System.Drawing.Size(112, 17);
            this.chk_ExpiryCheck.TabIndex = 16;
            this.chk_ExpiryCheck.Text = "chk_ExpiryCheck;";
            this.chk_ExpiryCheck.UseVisualStyleBackColor = true;
            // 
            // usrc_StockEditForSelectedStockTake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.splitContainer2);
            this.Name = "usrc_StockEditForSelectedStockTake";
            this.Size = new System.Drawing.Size(600, 798);
            this.Load += new System.EventHandler(this.usrc_StockEditForSelectedStockTake_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeItemsAndPrices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txt_StockDescription;
        private System.Windows.Forms.Label lbl_Stock_Description;
        private System.Windows.Forms.DateTimePicker TPiick_ExpiryDate;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.NumericUpDown nmUpDn_Quantity;
        private System.Windows.Forms.ComboBox cmb_Taxation;
        private System.Windows.Forms.Label lbl_Taxation;
        private System.Windows.Forms.ComboBox cmb_Currency;
        private System.Windows.Forms.Label lbl_Currency;
        private System.Windows.Forms.ComboBox cmb_PurchasePrice;
        private System.Windows.Forms.Button btn_SelectItem;
        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.Label lbl_PurchasePrice;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_StockTakeItems;
        private System.Windows.Forms.DataGridView dgvx_StockTakeItemsAndPrices;
        private System.Windows.Forms.CheckBox chk_ExpiryCheck;
        private System.Windows.Forms.Label lbl_ImportTime;
        private System.Windows.Forms.DateTimePicker tPick_ImportTime;
    }
}
