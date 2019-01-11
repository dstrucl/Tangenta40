namespace ShopC_Forms
{
    partial class Form_Inventura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Inventura));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_StockItems = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.dgvx_Items_in_Stock = new DataGridView_2xls.DataGridView2xls();
            this.lbl_StockOfItem = new System.Windows.Forms.Label();
            this.dgvx_SingleItemStockData = new DataGridView_2xls.DataGridView2xls();
            this.txt_Item_UniqueName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Items_in_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SingleItemStockData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.lbl_StockItems);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Print);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_Items_in_Stock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel2.Controls.Add(this.txt_Item_UniqueName);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_StockOfItem);
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_SingleItemStockData);
            this.splitContainer1.Size = new System.Drawing.Size(913, 540);
            this.splitContainer1.SplitterDistance = 448;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // lbl_StockItems
            // 
            this.lbl_StockItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StockItems.Location = new System.Drawing.Point(3, 9);
            this.lbl_StockItems.Name = "lbl_StockItems";
            this.lbl_StockItems.Size = new System.Drawing.Size(266, 19);
            this.lbl_StockItems.TabIndex = 2;
            this.lbl_StockItems.Text = "label1";
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.Image = global::ShopC_Forms.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(321, 15);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(124, 38);
            this.btn_Print.TabIndex = 1;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // dgvx_Items_in_Stock
            // 
            this.dgvx_Items_in_Stock.AllowUserToAddRows = false;
            this.dgvx_Items_in_Stock.AllowUserToDeleteRows = false;
            this.dgvx_Items_in_Stock.AllowUserToOrderColumns = true;
            this.dgvx_Items_in_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Items_in_Stock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_Items_in_Stock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_Items_in_Stock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvx_Items_in_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Items_in_Stock.DataGridViewWithRowNumber = false;
            this.dgvx_Items_in_Stock.Location = new System.Drawing.Point(3, 59);
            this.dgvx_Items_in_Stock.MultiSelect = false;
            this.dgvx_Items_in_Stock.Name = "dgvx_Items_in_Stock";
            this.dgvx_Items_in_Stock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Items_in_Stock.ShowRowErrors = false;
            this.dgvx_Items_in_Stock.Size = new System.Drawing.Size(442, 478);
            this.dgvx_Items_in_Stock.TabIndex = 0;
            // 
            // lbl_StockOfItem
            // 
            this.lbl_StockOfItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StockOfItem.Location = new System.Drawing.Point(8, 5);
            this.lbl_StockOfItem.Name = "lbl_StockOfItem";
            this.lbl_StockOfItem.Size = new System.Drawing.Size(266, 19);
            this.lbl_StockOfItem.TabIndex = 3;
            this.lbl_StockOfItem.Text = "label1";
            // 
            // dgvx_SingleItemStockData
            // 
            this.dgvx_SingleItemStockData.AllowUserToAddRows = false;
            this.dgvx_SingleItemStockData.AllowUserToDeleteRows = false;
            this.dgvx_SingleItemStockData.AllowUserToResizeRows = false;
            this.dgvx_SingleItemStockData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SingleItemStockData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvx_SingleItemStockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SingleItemStockData.DataGridViewWithRowNumber = false;
            this.dgvx_SingleItemStockData.Location = new System.Drawing.Point(3, 98);
            this.dgvx_SingleItemStockData.MultiSelect = false;
            this.dgvx_SingleItemStockData.Name = "dgvx_SingleItemStockData";
            this.dgvx_SingleItemStockData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_SingleItemStockData.Size = new System.Drawing.Size(449, 439);
            this.dgvx_SingleItemStockData.TabIndex = 1;
            // 
            // txt_Item_UniqueName
            // 
            this.txt_Item_UniqueName.Location = new System.Drawing.Point(6, 29);
            this.txt_Item_UniqueName.Multiline = true;
            this.txt_Item_UniqueName.Name = "txt_Item_UniqueName";
            this.txt_Item_UniqueName.ReadOnly = true;
            this.txt_Item_UniqueName.Size = new System.Drawing.Size(441, 49);
            this.txt_Item_UniqueName.TabIndex = 4;
            // 
            // Form_Inventura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 540);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Inventura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Inventura";
            this.Load += new System.EventHandler(this.Form_Inventura_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Items_in_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SingleItemStockData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_Items_in_Stock;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Print;
        private DataGridView_2xls.DataGridView2xls dgvx_SingleItemStockData;
        private System.Windows.Forms.Label lbl_StockItems;
        private System.Windows.Forms.Label lbl_StockOfItem;
        private System.Windows.Forms.TextBox txt_Item_UniqueName;
    }
}