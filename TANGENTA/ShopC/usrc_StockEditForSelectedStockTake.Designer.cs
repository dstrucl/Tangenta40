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
            this.grp_Item = new System.Windows.Forms.GroupBox();
            this.txt_StockDescription = new System.Windows.Forms.TextBox();
            this.chk_ExpiryCheck = new System.Windows.Forms.CheckBox();
            this.lbl_ImportTime = new System.Windows.Forms.Label();
            this.tPick_ImportTime = new System.Windows.Forms.DateTimePicker();
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
            this.lbl_PurchasePrice = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_StockTakeItems = new System.Windows.Forms.Label();
            this.dgvx_StockTakeItemsAndPrices = new DataGridView_2xls.DataGridView2xls();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_LockStockTake = new System.Windows.Forms.Button();
            this.lbl_StockTakeName = new System.Windows.Forms.Label();
            this.btn_AdditionalCost = new System.Windows.Forms.Button();
            this.lbl_TotalPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grp_Item.SuspendLayout();
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
            this.splitContainer2.Location = new System.Drawing.Point(3, 57);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grp_Item);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_Update);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Remove);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Add);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_StockTakeItems);
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_StockTakeItemsAndPrices);
            this.splitContainer2.Size = new System.Drawing.Size(504, 738);
            this.splitContainer2.SplitterDistance = 204;
            this.splitContainer2.TabIndex = 2;
            // 
            // grp_Item
            // 
            this.grp_Item.Controls.Add(this.txt_StockDescription);
            this.grp_Item.Controls.Add(this.chk_ExpiryCheck);
            this.grp_Item.Controls.Add(this.lbl_ImportTime);
            this.grp_Item.Controls.Add(this.tPick_ImportTime);
            this.grp_Item.Controls.Add(this.lbl_Stock_Description);
            this.grp_Item.Controls.Add(this.TPiick_ExpiryDate);
            this.grp_Item.Controls.Add(this.lbl_Quantity);
            this.grp_Item.Controls.Add(this.nmUpDn_Quantity);
            this.grp_Item.Controls.Add(this.cmb_Taxation);
            this.grp_Item.Controls.Add(this.lbl_Taxation);
            this.grp_Item.Controls.Add(this.cmb_Currency);
            this.grp_Item.Controls.Add(this.lbl_Currency);
            this.grp_Item.Controls.Add(this.cmb_PurchasePrice);
            this.grp_Item.Controls.Add(this.btn_SelectItem);
            this.grp_Item.Controls.Add(this.lbl_PurchasePrice);
            this.grp_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Item.Location = new System.Drawing.Point(0, 0);
            this.grp_Item.Name = "grp_Item";
            this.grp_Item.Size = new System.Drawing.Size(500, 200);
            this.grp_Item.TabIndex = 17;
            this.grp_Item.TabStop = false;
            this.grp_Item.Text = "Item:";
            // 
            // txt_StockDescription
            // 
            this.txt_StockDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_StockDescription.Location = new System.Drawing.Point(12, 157);
            this.txt_StockDescription.Multiline = true;
            this.txt_StockDescription.Name = "txt_StockDescription";
            this.txt_StockDescription.Size = new System.Drawing.Size(482, 45);
            this.txt_StockDescription.TabIndex = 13;
            // 
            // chk_ExpiryCheck
            // 
            this.chk_ExpiryCheck.AutoSize = true;
            this.chk_ExpiryCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_ExpiryCheck.Location = new System.Drawing.Point(385, 133);
            this.chk_ExpiryCheck.Name = "chk_ExpiryCheck";
            this.chk_ExpiryCheck.Size = new System.Drawing.Size(112, 17);
            this.chk_ExpiryCheck.TabIndex = 16;
            this.chk_ExpiryCheck.Text = "chk_ExpiryCheck;";
            this.chk_ExpiryCheck.UseVisualStyleBackColor = true;
            this.chk_ExpiryCheck.CheckedChanged += new System.EventHandler(this.chk_ExpiryCheck_CheckedChanged);
            // 
            // lbl_ImportTime
            // 
            this.lbl_ImportTime.AutoSize = true;
            this.lbl_ImportTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ImportTime.Location = new System.Drawing.Point(8, 85);
            this.lbl_ImportTime.Name = "lbl_ImportTime";
            this.lbl_ImportTime.Size = new System.Drawing.Size(62, 13);
            this.lbl_ImportTime.TabIndex = 15;
            this.lbl_ImportTime.Text = "ImportTime:";
            // 
            // tPick_ImportTime
            // 
            this.tPick_ImportTime.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.tPick_ImportTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tPick_ImportTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tPick_ImportTime.Location = new System.Drawing.Point(10, 103);
            this.tPick_ImportTime.Name = "tPick_ImportTime";
            this.tPick_ImportTime.Size = new System.Drawing.Size(231, 20);
            this.tPick_ImportTime.TabIndex = 14;
            // 
            // lbl_Stock_Description
            // 
            this.lbl_Stock_Description.AutoSize = true;
            this.lbl_Stock_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Stock_Description.Location = new System.Drawing.Point(8, 137);
            this.lbl_Stock_Description.Name = "lbl_Stock_Description";
            this.lbl_Stock_Description.Size = new System.Drawing.Size(94, 13);
            this.lbl_Stock_Description.TabIndex = 12;
            this.lbl_Stock_Description.Text = "Stock Description:";
            // 
            // TPiick_ExpiryDate
            // 
            this.TPiick_ExpiryDate.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.TPiick_ExpiryDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TPiick_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TPiick_ExpiryDate.Location = new System.Drawing.Point(162, 131);
            this.TPiick_ExpiryDate.Name = "TPiick_ExpiryDate";
            this.TPiick_ExpiryDate.Size = new System.Drawing.Size(221, 20);
            this.TPiick_ExpiryDate.TabIndex = 10;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity.Location = new System.Drawing.Point(3, 30);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(49, 13);
            this.lbl_Quantity.TabIndex = 9;
            this.lbl_Quantity.Text = "Quantity:";
            // 
            // nmUpDn_Quantity
            // 
            this.nmUpDn_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.nmUpDn_Quantity.Location = new System.Drawing.Point(63, 27);
            this.nmUpDn_Quantity.Name = "nmUpDn_Quantity";
            this.nmUpDn_Quantity.Size = new System.Drawing.Size(95, 20);
            this.nmUpDn_Quantity.TabIndex = 8;
            // 
            // cmb_Taxation
            // 
            this.cmb_Taxation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Taxation.FormattingEnabled = true;
            this.cmb_Taxation.Location = new System.Drawing.Point(68, 55);
            this.cmb_Taxation.Name = "cmb_Taxation";
            this.cmb_Taxation.Size = new System.Drawing.Size(95, 21);
            this.cmb_Taxation.TabIndex = 7;
            // 
            // lbl_Taxation
            // 
            this.lbl_Taxation.AutoSize = true;
            this.lbl_Taxation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Taxation.Location = new System.Drawing.Point(6, 58);
            this.lbl_Taxation.Name = "lbl_Taxation";
            this.lbl_Taxation.Size = new System.Drawing.Size(51, 13);
            this.lbl_Taxation.TabIndex = 6;
            this.lbl_Taxation.Text = "Taxation:";
            // 
            // cmb_Currency
            // 
            this.cmb_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Currency.FormattingEnabled = true;
            this.cmb_Currency.Location = new System.Drawing.Point(256, 55);
            this.cmb_Currency.Name = "cmb_Currency";
            this.cmb_Currency.Size = new System.Drawing.Size(95, 21);
            this.cmb_Currency.TabIndex = 5;
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.AutoSize = true;
            this.lbl_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Currency.Location = new System.Drawing.Point(198, 59);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(52, 13);
            this.lbl_Currency.TabIndex = 4;
            this.lbl_Currency.Text = "Currency:";
            // 
            // cmb_PurchasePrice
            // 
            this.cmb_PurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_PurchasePrice.FormattingEnabled = true;
            this.cmb_PurchasePrice.Location = new System.Drawing.Point(249, 27);
            this.cmb_PurchasePrice.Name = "cmb_PurchasePrice";
            this.cmb_PurchasePrice.Size = new System.Drawing.Size(103, 21);
            this.cmb_PurchasePrice.TabIndex = 3;
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SelectItem.Location = new System.Drawing.Point(358, 3);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(136, 32);
            this.btn_SelectItem.TabIndex = 2;
            this.btn_SelectItem.Text = "Select Item";
            this.btn_SelectItem.UseVisualStyleBackColor = true;
            this.btn_SelectItem.Click += new System.EventHandler(this.btn_SelectItem_Click);
            // 
            // lbl_PurchasePrice
            // 
            this.lbl_PurchasePrice.AutoSize = true;
            this.lbl_PurchasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PurchasePrice.Location = new System.Drawing.Point(159, 31);
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
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(295, 1);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(60, 23);
            this.btn_Remove.TabIndex = 18;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
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
            this.dgvx_StockTakeItemsAndPrices.AllowUserToAddRows = false;
            this.dgvx_StockTakeItemsAndPrices.AllowUserToDeleteRows = false;
            this.dgvx_StockTakeItemsAndPrices.AllowUserToOrderColumns = true;
            this.dgvx_StockTakeItemsAndPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_StockTakeItemsAndPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_StockTakeItemsAndPrices.DataGridViewWithRowNumber = false;
            this.dgvx_StockTakeItemsAndPrices.Location = new System.Drawing.Point(3, 27);
            this.dgvx_StockTakeItemsAndPrices.MultiSelect = false;
            this.dgvx_StockTakeItemsAndPrices.Name = "dgvx_StockTakeItemsAndPrices";
            this.dgvx_StockTakeItemsAndPrices.ReadOnly = true;
            this.dgvx_StockTakeItemsAndPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_StockTakeItemsAndPrices.Size = new System.Drawing.Size(494, 487);
            this.dgvx_StockTakeItemsAndPrices.TabIndex = 0;
            this.dgvx_StockTakeItemsAndPrices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_StockTakeItemsAndPrices_CellClick);
            this.dgvx_StockTakeItemsAndPrices.SelectionChanged += new System.EventHandler(this.dgvx_StockTakeItemsAndPrices_SelectionChanged);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::ShopC.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(444, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(61, 26);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_LockStockTake
            // 
            this.btn_LockStockTake.Location = new System.Drawing.Point(2, 2);
            this.btn_LockStockTake.Name = "btn_LockStockTake";
            this.btn_LockStockTake.Size = new System.Drawing.Size(76, 27);
            this.btn_LockStockTake.TabIndex = 3;
            this.btn_LockStockTake.Text = "btn_Lock";
            this.btn_LockStockTake.UseVisualStyleBackColor = true;
            this.btn_LockStockTake.Click += new System.EventHandler(this.btn_LockStockTake_Click);
            // 
            // lbl_StockTakeName
            // 
            this.lbl_StockTakeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StockTakeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StockTakeName.Location = new System.Drawing.Point(84, 8);
            this.lbl_StockTakeName.Name = "lbl_StockTakeName";
            this.lbl_StockTakeName.Size = new System.Drawing.Size(210, 16);
            this.lbl_StockTakeName.TabIndex = 5;
            this.lbl_StockTakeName.Text = "Stock Take Name";
            // 
            // btn_AdditionalCost
            // 
            this.btn_AdditionalCost.Location = new System.Drawing.Point(184, 32);
            this.btn_AdditionalCost.Name = "btn_AdditionalCost";
            this.btn_AdditionalCost.Size = new System.Drawing.Size(144, 23);
            this.btn_AdditionalCost.TabIndex = 6;
            this.btn_AdditionalCost.Text = "btn_AdditionalCost";
            this.btn_AdditionalCost.UseVisualStyleBackColor = true;
            this.btn_AdditionalCost.Click += new System.EventHandler(this.btn_AdditionalCost_Click);
            // 
            // lbl_TotalPrice
            // 
            this.lbl_TotalPrice.Location = new System.Drawing.Point(8, 36);
            this.lbl_TotalPrice.Name = "lbl_TotalPrice";
            this.lbl_TotalPrice.Size = new System.Drawing.Size(91, 15);
            this.lbl_TotalPrice.TabIndex = 7;
            this.lbl_TotalPrice.Text = "lbl_TotalPrice";
            this.lbl_TotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_StockEditForSelectedStockTake
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.lbl_TotalPrice);
            this.Controls.Add(this.btn_AdditionalCost);
            this.Controls.Add(this.lbl_StockTakeName);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_LockStockTake);
            this.Controls.Add(this.splitContainer2);
            this.Name = "usrc_StockEditForSelectedStockTake";
            this.Size = new System.Drawing.Size(510, 798);
            this.Load += new System.EventHandler(this.usrc_StockEditForSelectedStockTake_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grp_Item.ResumeLayout(false);
            this.grp_Item.PerformLayout();
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
        private System.Windows.Forms.Label lbl_PurchasePrice;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_StockTakeItems;
        private DataGridView_2xls.DataGridView2xls dgvx_StockTakeItemsAndPrices;
        private System.Windows.Forms.CheckBox chk_ExpiryCheck;
        private System.Windows.Forms.Label lbl_ImportTime;
        private System.Windows.Forms.DateTimePicker tPick_ImportTime;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_LockStockTake;
        private System.Windows.Forms.Label lbl_StockTakeName;
        private System.Windows.Forms.GroupBox grp_Item;
        private System.Windows.Forms.Button btn_AdditionalCost;
        private System.Windows.Forms.Label lbl_TotalPrice;
    }
}
