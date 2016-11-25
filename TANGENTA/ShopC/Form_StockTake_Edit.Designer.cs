namespace ShopC
{
    partial class Form_StockTake_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StockTake_Edit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditTable1 = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvx_StockTakeItemsAndPrices = new System.Windows.Forms.DataGridView();
            this.lbl_StockTakeItems = new System.Windows.Forms.Label();
            this.lbl_PurchasePrice = new System.Windows.Forms.Label();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.cmb_PurchasePrice = new System.Windows.Forms.ComboBox();
            this.cmb_Currency = new System.Windows.Forms.ComboBox();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.cmb_Taxation = new System.Windows.Forms.ComboBox();
            this.lbl_Taxation = new System.Windows.Forms.Label();
            this.nmUpDn_Quantity = new System.Windows.Forms.NumericUpDown();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.TPiick_ExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_ExpiryDate = new System.Windows.Forms.Label();
            this.lbl_Stock_Description = new System.Windows.Forms.Label();
            this.txt_StockDescription = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeItemsAndPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditTable1);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 729);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_EditTable1
            // 
            this.usrc_EditTable1.AllowUserToAddNew = true;
            this.usrc_EditTable1.AllowUserToChange = true;
            this.usrc_EditTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditTable1.GetRandomData = true;
            this.usrc_EditTable1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditTable1.Name = "usrc_EditTable1";
            this.usrc_EditTable1.SelectionButtonVisible = true;
            this.usrc_EditTable1.Size = new System.Drawing.Size(604, 729);
            this.usrc_EditTable1.TabIndex = 0;
            this.usrc_EditTable1.Title = "";
            this.usrc_EditTable1.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable1.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txt_StockDescription);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_Stock_Description);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_ExpiryDate);
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
            this.splitContainer2.Size = new System.Drawing.Size(400, 729);
            this.splitContainer2.SplitterDistance = 204;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvx_StockTakeItemsAndPrices
            // 
            this.dgvx_StockTakeItemsAndPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_StockTakeItemsAndPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_StockTakeItemsAndPrices.Location = new System.Drawing.Point(3, 27);
            this.dgvx_StockTakeItemsAndPrices.Name = "dgvx_StockTakeItemsAndPrices";
            this.dgvx_StockTakeItemsAndPrices.Size = new System.Drawing.Size(394, 482);
            this.dgvx_StockTakeItemsAndPrices.TabIndex = 0;
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
            // lbl_PurchasePrice
            // 
            this.lbl_PurchasePrice.AutoSize = true;
            this.lbl_PurchasePrice.Location = new System.Drawing.Point(162, 45);
            this.lbl_PurchasePrice.Name = "lbl_PurchasePrice";
            this.lbl_PurchasePrice.Size = new System.Drawing.Size(82, 13);
            this.lbl_PurchasePrice.TabIndex = 0;
            this.lbl_PurchasePrice.Text = "Purchase Price:";
            this.lbl_PurchasePrice.Click += new System.EventHandler(this.lbl_PurchasePrice_Click);
            // 
            // lbl_Item
            // 
            this.lbl_Item.Location = new System.Drawing.Point(10, 9);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(299, 27);
            this.lbl_Item.TabIndex = 1;
            this.lbl_Item.Text = "Item:";
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectItem.Location = new System.Drawing.Point(315, 9);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(76, 27);
            this.btn_SelectItem.TabIndex = 2;
            this.btn_SelectItem.Text = "Select Item";
            this.btn_SelectItem.UseVisualStyleBackColor = true;
            // 
            // cmb_PurchasePrice
            // 
            this.cmb_PurchasePrice.FormattingEnabled = true;
            this.cmb_PurchasePrice.Location = new System.Drawing.Point(252, 41);
            this.cmb_PurchasePrice.Name = "cmb_PurchasePrice";
            this.cmb_PurchasePrice.Size = new System.Drawing.Size(103, 21);
            this.cmb_PurchasePrice.TabIndex = 3;
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
            // nmUpDn_Quantity
            // 
            this.nmUpDn_Quantity.Location = new System.Drawing.Point(66, 41);
            this.nmUpDn_Quantity.Name = "nmUpDn_Quantity";
            this.nmUpDn_Quantity.Size = new System.Drawing.Size(95, 20);
            this.nmUpDn_Quantity.TabIndex = 8;
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
            // TPiick_ExpiryDate
            // 
            this.TPiick_ExpiryDate.Location = new System.Drawing.Point(99, 95);
            this.TPiick_ExpiryDate.Name = "TPiick_ExpiryDate";
            this.TPiick_ExpiryDate.Size = new System.Drawing.Size(185, 20);
            this.TPiick_ExpiryDate.TabIndex = 10;
            // 
            // lbl_ExpiryDate
            // 
            this.lbl_ExpiryDate.AutoSize = true;
            this.lbl_ExpiryDate.Location = new System.Drawing.Point(16, 98);
            this.lbl_ExpiryDate.Name = "lbl_ExpiryDate";
            this.lbl_ExpiryDate.Size = new System.Drawing.Size(64, 13);
            this.lbl_ExpiryDate.TabIndex = 11;
            this.lbl_ExpiryDate.Text = "Expiry Date:";
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
            // txt_StockDescription
            // 
            this.txt_StockDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_StockDescription.Location = new System.Drawing.Point(12, 137);
            this.txt_StockDescription.Multiline = true;
            this.txt_StockDescription.Name = "txt_StockDescription";
            this.txt_StockDescription.Size = new System.Drawing.Size(384, 55);
            this.txt_StockDescription.TabIndex = 13;
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
            // 
            // Form_StockTake_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_StockTake_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_StockTake_Edit";
            this.Load += new System.EventHandler(this.Form_StockTake_Edit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeItemsAndPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_StockTakeItems;
        private System.Windows.Forms.DataGridView dgvx_StockTakeItemsAndPrices;
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable1;
        private System.Windows.Forms.Label lbl_PurchasePrice;
        private System.Windows.Forms.TextBox txt_StockDescription;
        private System.Windows.Forms.Label lbl_Stock_Description;
        private System.Windows.Forms.Label lbl_ExpiryDate;
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
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
    }
}