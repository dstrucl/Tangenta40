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
            this.usrc_StockTake_Item1 = new ShopC.usrc_StockTake_Item();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.txt_StockDescription = new System.Windows.Forms.TextBox();
            this.chk_ExpiryCheck = new System.Windows.Forms.CheckBox();
            this.lbl_ImportTime = new System.Windows.Forms.Label();
            this.tPick_ImportTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_Stock_Description = new System.Windows.Forms.Label();
            this.TPiick_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_StockTakeItems = new System.Windows.Forms.Label();
            this.dgvx_StockTakeItemsAndPrices = new DataGridView_2xls.DataGridView2xls();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_CloseStockTake = new System.Windows.Forms.Button();
            this.lbl_StockTakeName = new System.Windows.Forms.Label();
            this.btn_AdditionalCost = new System.Windows.Forms.Button();
            this.lbl_TotalPriceWithoutTax = new System.Windows.Forms.Label();
            this.txt_TotalPriceWithoutTax = new System.Windows.Forms.TextBox();
            this.txt_TruckingCustomsPlusAddtitional = new System.Windows.Forms.TextBox();
            this.lbl_TruckingCustosPlusAddtional = new System.Windows.Forms.Label();
            this.txt_VAT = new System.Windows.Forms.TextBox();
            this.lbl_TotalTax = new System.Windows.Forms.Label();
            this.txt_Difference = new System.Windows.Forms.TextBox();
            this.lbl_Difference = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.txt_StockTakePrice_WithOrWithoutTAX = new System.Windows.Forms.TextBox();
            this.lbl_StockTakePriceWithOrWithoutVAT = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grp_Item.SuspendLayout();
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
            this.splitContainer2.Location = new System.Drawing.Point(3, 95);
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
            this.splitContainer2.Size = new System.Drawing.Size(558, 700);
            this.splitContainer2.SplitterDistance = 245;
            this.splitContainer2.TabIndex = 2;
            // 
            // grp_Item
            // 
            this.grp_Item.Controls.Add(this.usrc_StockTake_Item1);
            this.grp_Item.Controls.Add(this.btn_SelectItem);
            this.grp_Item.Controls.Add(this.txt_StockDescription);
            this.grp_Item.Controls.Add(this.chk_ExpiryCheck);
            this.grp_Item.Controls.Add(this.lbl_ImportTime);
            this.grp_Item.Controls.Add(this.tPick_ImportTime);
            this.grp_Item.Controls.Add(this.lbl_Stock_Description);
            this.grp_Item.Controls.Add(this.TPiick_ExpiryDate);
            this.grp_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Item.Location = new System.Drawing.Point(0, 0);
            this.grp_Item.Name = "grp_Item";
            this.grp_Item.Size = new System.Drawing.Size(554, 241);
            this.grp_Item.TabIndex = 17;
            this.grp_Item.TabStop = false;
            this.grp_Item.Text = "Item:";
            // 
            // usrc_StockTake_Item1
            // 
            this.usrc_StockTake_Item1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_StockTake_Item1.Currency_Abbreviation = null;
            this.usrc_StockTake_Item1.Currency_Code = 0;
            this.usrc_StockTake_Item1.Currency_DecimalPlaces = 2;
            this.usrc_StockTake_Item1.Currency_Name = null;
            this.usrc_StockTake_Item1.Currency_Symbol = null;
            this.usrc_StockTake_Item1.Discount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.Location = new System.Drawing.Point(1, 28);
            this.usrc_StockTake_Item1.Name = "usrc_StockTake_Item1";
            this.usrc_StockTake_Item1.PPriceDefined = false;
            this.usrc_StockTake_Item1.PriceWithDiscountWithoutTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.PriceWithoutVAT = true;
            this.usrc_StockTake_Item1.PurchasePricePerUnitWithoutTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.PurchasePricePerUnitWithoutTaxWithDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.PurchasePricePerUnitWithTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.PurchasePricePerUnitWithTaxWithDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.Quantity = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.Size = new System.Drawing.Size(552, 91);
            this.usrc_StockTake_Item1.TabIndex = 17;
            this.usrc_StockTake_Item1.TaxationRate = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.TotalWithoutTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.TotalWithoutTaxWithDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.TotalWithTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_StockTake_Item1.TotalWithTaxWithDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SelectItem.Location = new System.Drawing.Point(420, 0);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(136, 25);
            this.btn_SelectItem.TabIndex = 2;
            this.btn_SelectItem.Text = "Select Item";
            this.btn_SelectItem.UseVisualStyleBackColor = false;
            this.btn_SelectItem.Click += new System.EventHandler(this.btn_SelectItem_Click);
            // 
            // txt_StockDescription
            // 
            this.txt_StockDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_StockDescription.Enabled = false;
            this.txt_StockDescription.Location = new System.Drawing.Point(10, 190);
            this.txt_StockDescription.Multiline = true;
            this.txt_StockDescription.Name = "txt_StockDescription";
            this.txt_StockDescription.Size = new System.Drawing.Size(536, 49);
            this.txt_StockDescription.TabIndex = 13;
            // 
            // chk_ExpiryCheck
            // 
            this.chk_ExpiryCheck.AutoSize = true;
            this.chk_ExpiryCheck.Enabled = false;
            this.chk_ExpiryCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_ExpiryCheck.Location = new System.Drawing.Point(361, 164);
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
            this.lbl_ImportTime.Location = new System.Drawing.Point(9, 120);
            this.lbl_ImportTime.Name = "lbl_ImportTime";
            this.lbl_ImportTime.Size = new System.Drawing.Size(62, 13);
            this.lbl_ImportTime.TabIndex = 15;
            this.lbl_ImportTime.Text = "ImportTime:";
            // 
            // tPick_ImportTime
            // 
            this.tPick_ImportTime.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.tPick_ImportTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tPick_ImportTime.Enabled = false;
            this.tPick_ImportTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tPick_ImportTime.Location = new System.Drawing.Point(11, 138);
            this.tPick_ImportTime.Name = "tPick_ImportTime";
            this.tPick_ImportTime.Size = new System.Drawing.Size(231, 20);
            this.tPick_ImportTime.TabIndex = 14;
            // 
            // lbl_Stock_Description
            // 
            this.lbl_Stock_Description.AutoSize = true;
            this.lbl_Stock_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Stock_Description.Location = new System.Drawing.Point(8, 170);
            this.lbl_Stock_Description.Name = "lbl_Stock_Description";
            this.lbl_Stock_Description.Size = new System.Drawing.Size(94, 13);
            this.lbl_Stock_Description.TabIndex = 12;
            this.lbl_Stock_Description.Text = "Stock Description:";
            // 
            // TPiick_ExpiryDate
            // 
            this.TPiick_ExpiryDate.CalendarForeColor = System.Drawing.Color.CornflowerBlue;
            this.TPiick_ExpiryDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TPiick_ExpiryDate.Enabled = false;
            this.TPiick_ExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TPiick_ExpiryDate.Location = new System.Drawing.Point(134, 164);
            this.TPiick_ExpiryDate.Name = "TPiick_ExpiryDate";
            this.TPiick_ExpiryDate.Size = new System.Drawing.Size(221, 20);
            this.TPiick_ExpiryDate.TabIndex = 10;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Update.Location = new System.Drawing.Point(228, 3);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(60, 21);
            this.btn_Update.TabIndex = 19;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Remove.Location = new System.Drawing.Point(295, 1);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(60, 23);
            this.btn_Remove.TabIndex = 18;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Add.Location = new System.Drawing.Point(158, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(60, 21);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = false;
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
            this.dgvx_StockTakeItemsAndPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_StockTakeItemsAndPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_StockTakeItemsAndPrices.DataGridViewWithRowNumber = true;
            this.dgvx_StockTakeItemsAndPrices.Location = new System.Drawing.Point(3, 27);
            this.dgvx_StockTakeItemsAndPrices.Name = "dgvx_StockTakeItemsAndPrices";
            this.dgvx_StockTakeItemsAndPrices.ReadOnly = true;
            this.dgvx_StockTakeItemsAndPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_StockTakeItemsAndPrices.Size = new System.Drawing.Size(548, 408);
            this.dgvx_StockTakeItemsAndPrices.TabIndex = 0;
            this.dgvx_StockTakeItemsAndPrices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_StockTakeItemsAndPrices_CellClick);
            this.dgvx_StockTakeItemsAndPrices.SelectionChanged += new System.EventHandler(this.dgvx_StockTakeItemsAndPrices_SelectionChanged);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = global::ShopC.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(423, 1);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 27);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_CloseStockTake
            // 
            this.btn_CloseStockTake.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CloseStockTake.Location = new System.Drawing.Point(2, 0);
            this.btn_CloseStockTake.Name = "btn_CloseStockTake";
            this.btn_CloseStockTake.Size = new System.Drawing.Size(76, 27);
            this.btn_CloseStockTake.TabIndex = 3;
            this.btn_CloseStockTake.Text = "btn_Close";
            this.btn_CloseStockTake.UseVisualStyleBackColor = false;
            this.btn_CloseStockTake.Click += new System.EventHandler(this.btn_CloseStockTake_Click);
            // 
            // lbl_StockTakeName
            // 
            this.lbl_StockTakeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StockTakeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StockTakeName.Location = new System.Drawing.Point(84, 8);
            this.lbl_StockTakeName.Name = "lbl_StockTakeName";
            this.lbl_StockTakeName.Size = new System.Drawing.Size(264, 16);
            this.lbl_StockTakeName.TabIndex = 5;
            this.lbl_StockTakeName.Text = "Stock Take Name";
            // 
            // btn_AdditionalCost
            // 
            this.btn_AdditionalCost.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AdditionalCost.Location = new System.Drawing.Point(322, 71);
            this.btn_AdditionalCost.Name = "btn_AdditionalCost";
            this.btn_AdditionalCost.Size = new System.Drawing.Size(120, 23);
            this.btn_AdditionalCost.TabIndex = 6;
            this.btn_AdditionalCost.Text = "btn_AdditionalCost";
            this.btn_AdditionalCost.UseVisualStyleBackColor = false;
            this.btn_AdditionalCost.Click += new System.EventHandler(this.btn_AdditionalCost_Click);
            // 
            // lbl_TotalPriceWithoutTax
            // 
            this.lbl_TotalPriceWithoutTax.Location = new System.Drawing.Point(8, 34);
            this.lbl_TotalPriceWithoutTax.Name = "lbl_TotalPriceWithoutTax";
            this.lbl_TotalPriceWithoutTax.Size = new System.Drawing.Size(109, 15);
            this.lbl_TotalPriceWithoutTax.TabIndex = 7;
            this.lbl_TotalPriceWithoutTax.Text = "Total Price:";
            this.lbl_TotalPriceWithoutTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_TotalPriceWithoutTax
            // 
            this.txt_TotalPriceWithoutTax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TotalPriceWithoutTax.Location = new System.Drawing.Point(123, 34);
            this.txt_TotalPriceWithoutTax.Name = "txt_TotalPriceWithoutTax";
            this.txt_TotalPriceWithoutTax.ReadOnly = true;
            this.txt_TotalPriceWithoutTax.Size = new System.Drawing.Size(75, 13);
            this.txt_TotalPriceWithoutTax.TabIndex = 8;
            // 
            // txt_TruckingCustomsPlusAddtitional
            // 
            this.txt_TruckingCustomsPlusAddtitional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TruckingCustomsPlusAddtitional.Location = new System.Drawing.Point(233, 77);
            this.txt_TruckingCustomsPlusAddtitional.Name = "txt_TruckingCustomsPlusAddtitional";
            this.txt_TruckingCustomsPlusAddtitional.ReadOnly = true;
            this.txt_TruckingCustomsPlusAddtitional.Size = new System.Drawing.Size(81, 13);
            this.txt_TruckingCustomsPlusAddtitional.TabIndex = 12;
            // 
            // lbl_TruckingCustosPlusAddtional
            // 
            this.lbl_TruckingCustosPlusAddtional.Location = new System.Drawing.Point(7, 75);
            this.lbl_TruckingCustosPlusAddtional.Name = "lbl_TruckingCustosPlusAddtional";
            this.lbl_TruckingCustosPlusAddtional.Size = new System.Drawing.Size(222, 15);
            this.lbl_TruckingCustosPlusAddtional.TabIndex = 11;
            this.lbl_TruckingCustosPlusAddtional.Text = "Price for Trucking,Customs,Additional Cost:";
            this.lbl_TruckingCustosPlusAddtional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_VAT
            // 
            this.txt_VAT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_VAT.Location = new System.Drawing.Point(123, 55);
            this.txt_VAT.Name = "txt_VAT";
            this.txt_VAT.ReadOnly = true;
            this.txt_VAT.Size = new System.Drawing.Size(75, 13);
            this.txt_VAT.TabIndex = 14;
            // 
            // lbl_TotalTax
            // 
            this.lbl_TotalTax.Location = new System.Drawing.Point(8, 54);
            this.lbl_TotalTax.Name = "lbl_TotalTax";
            this.lbl_TotalTax.Size = new System.Drawing.Size(109, 15);
            this.lbl_TotalTax.TabIndex = 13;
            this.lbl_TotalTax.Text = "Items Price:";
            this.lbl_TotalTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Difference
            // 
            this.txt_Difference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Difference.Location = new System.Drawing.Point(412, 53);
            this.txt_Difference.Name = "txt_Difference";
            this.txt_Difference.ReadOnly = true;
            this.txt_Difference.Size = new System.Drawing.Size(81, 13);
            this.txt_Difference.TabIndex = 16;
            // 
            // lbl_Difference
            // 
            this.lbl_Difference.Location = new System.Drawing.Point(337, 50);
            this.lbl_Difference.Name = "lbl_Difference";
            this.lbl_Difference.Size = new System.Drawing.Size(69, 15);
            this.lbl_Difference.TabIndex = 15;
            this.lbl_Difference.Text = "Difference:";
            this.lbl_Difference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Print.Image = global::ShopC.Properties.Resources.PrinterSettings;
            this.btn_Print.Location = new System.Drawing.Point(322, 0);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(93, 27);
            this.btn_Print.TabIndex = 17;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // txt_StockTakePrice_WithOrWithoutTAX
            // 
            this.txt_StockTakePrice_WithOrWithoutTAX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_StockTakePrice_WithOrWithoutTAX.Location = new System.Drawing.Point(412, 33);
            this.txt_StockTakePrice_WithOrWithoutTAX.Name = "txt_StockTakePrice_WithOrWithoutTAX";
            this.txt_StockTakePrice_WithOrWithoutTAX.ReadOnly = true;
            this.txt_StockTakePrice_WithOrWithoutTAX.Size = new System.Drawing.Size(81, 13);
            this.txt_StockTakePrice_WithOrWithoutTAX.TabIndex = 19;
            // 
            // lbl_StockTakePriceWithOrWithoutVAT
            // 
            this.lbl_StockTakePriceWithOrWithoutVAT.Location = new System.Drawing.Point(216, 32);
            this.lbl_StockTakePriceWithOrWithoutVAT.Name = "lbl_StockTakePriceWithOrWithoutVAT";
            this.lbl_StockTakePriceWithOrWithoutVAT.Size = new System.Drawing.Size(193, 15);
            this.lbl_StockTakePriceWithOrWithoutVAT.TabIndex = 18;
            this.lbl_StockTakePriceWithOrWithoutVAT.Text = "Stock Take Price With or without TAX";
            this.lbl_StockTakePriceWithOrWithoutVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(511, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(47, 24);
            this.usrc_Help1.TabIndex = 20;
            // 
            // usrc_StockEditForSelectedStockTake
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.txt_StockTakePrice_WithOrWithoutTAX);
            this.Controls.Add(this.lbl_StockTakePriceWithOrWithoutVAT);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.txt_Difference);
            this.Controls.Add(this.lbl_Difference);
            this.Controls.Add(this.txt_VAT);
            this.Controls.Add(this.lbl_TotalTax);
            this.Controls.Add(this.txt_TruckingCustomsPlusAddtitional);
            this.Controls.Add(this.lbl_TruckingCustosPlusAddtional);
            this.Controls.Add(this.txt_TotalPriceWithoutTax);
            this.Controls.Add(this.lbl_TotalPriceWithoutTax);
            this.Controls.Add(this.btn_AdditionalCost);
            this.Controls.Add(this.lbl_StockTakeName);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_CloseStockTake);
            this.Controls.Add(this.splitContainer2);
            this.Name = "usrc_StockEditForSelectedStockTake";
            this.Size = new System.Drawing.Size(564, 798);
            this.Load += new System.EventHandler(this.usrc_StockEditForSelectedStockTake_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grp_Item.ResumeLayout(false);
            this.grp_Item.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeItemsAndPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txt_StockDescription;
        private System.Windows.Forms.Label lbl_Stock_Description;
        private System.Windows.Forms.DateTimePicker TPiick_ExpiryDate;
        private System.Windows.Forms.Button btn_SelectItem;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_StockTakeItems;
        private DataGridView_2xls.DataGridView2xls dgvx_StockTakeItemsAndPrices;
        private System.Windows.Forms.CheckBox chk_ExpiryCheck;
        private System.Windows.Forms.Label lbl_ImportTime;
        private System.Windows.Forms.DateTimePicker tPick_ImportTime;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_CloseStockTake;
        private System.Windows.Forms.Label lbl_StockTakeName;
        private System.Windows.Forms.GroupBox grp_Item;
        private System.Windows.Forms.Button btn_AdditionalCost;
        private System.Windows.Forms.Label lbl_TotalPriceWithoutTax;
        private System.Windows.Forms.TextBox txt_TotalPriceWithoutTax;
        private System.Windows.Forms.TextBox txt_TruckingCustomsPlusAddtitional;
        private System.Windows.Forms.Label lbl_TruckingCustosPlusAddtional;
        private System.Windows.Forms.TextBox txt_VAT;
        private System.Windows.Forms.Label lbl_TotalTax;
        private System.Windows.Forms.TextBox txt_Difference;
        private System.Windows.Forms.Label lbl_Difference;
        private usrc_StockTake_Item usrc_StockTake_Item1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.TextBox txt_StockTakePrice_WithOrWithoutTAX;
        private System.Windows.Forms.Label lbl_StockTakePriceWithOrWithoutVAT;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}
