﻿namespace ShopC_Forms
{
    partial class Form_SelectStockEditType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectStockEditType));
            this.btn_EditStockTakeItems = new System.Windows.Forms.Button();
            this.btn_EditItemsInStock = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.btn_Inventura = new System.Windows.Forms.Button();
            this.btn_PurchasePricesPerItem = new System.Windows.Forms.Button();
            this.btn_Form_OwnUse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_EditStockTakeItems
            // 
            this.btn_EditStockTakeItems.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditStockTakeItems.Location = new System.Drawing.Point(3, 3);
            this.btn_EditStockTakeItems.Name = "btn_EditStockTakeItems";
            this.btn_EditStockTakeItems.Size = new System.Drawing.Size(147, 82);
            this.btn_EditStockTakeItems.TabIndex = 1;
            this.btn_EditStockTakeItems.Text = "btn_EditStockTakeItems";
            this.btn_EditStockTakeItems.UseVisualStyleBackColor = false;
            this.btn_EditStockTakeItems.Click += new System.EventHandler(this.btn_EditStockTakeItems_Click);
            // 
            // btn_EditItemsInStock
            // 
            this.btn_EditItemsInStock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItemsInStock.Location = new System.Drawing.Point(158, 3);
            this.btn_EditItemsInStock.Name = "btn_EditItemsInStock";
            this.btn_EditItemsInStock.Size = new System.Drawing.Size(145, 81);
            this.btn_EditItemsInStock.TabIndex = 2;
            this.btn_EditItemsInStock.Text = "btn_EditItemsInStock";
            this.btn_EditItemsInStock.UseVisualStyleBackColor = false;
            this.btn_EditItemsInStock.Click += new System.EventHandler(this.btn_EditItemsInStock_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(356, 3);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(35, 51);
            this.usrc_Help1.TabIndex = 3;
            // 
            // btn_Inventura
            // 
            this.btn_Inventura.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Inventura.Location = new System.Drawing.Point(3, 178);
            this.btn_Inventura.Name = "btn_Inventura";
            this.btn_Inventura.Size = new System.Drawing.Size(147, 81);
            this.btn_Inventura.TabIndex = 4;
            this.btn_Inventura.Text = "Trenutne zaloge";
            this.btn_Inventura.UseVisualStyleBackColor = false;
            this.btn_Inventura.Click += new System.EventHandler(this.btn_Inventura_Click);
            // 
            // btn_PurchasePricesPerItem
            // 
            this.btn_PurchasePricesPerItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PurchasePricesPerItem.Location = new System.Drawing.Point(156, 178);
            this.btn_PurchasePricesPerItem.Name = "btn_PurchasePricesPerItem";
            this.btn_PurchasePricesPerItem.Size = new System.Drawing.Size(147, 81);
            this.btn_PurchasePricesPerItem.TabIndex = 5;
            this.btn_PurchasePricesPerItem.Text = "Nabavne Cene Artiklov";
            this.btn_PurchasePricesPerItem.UseVisualStyleBackColor = false;
            this.btn_PurchasePricesPerItem.Click += new System.EventHandler(this.btn_PurchasePricesPerItem_Click);
            // 
            // btn_Form_OwnUse
            // 
            this.btn_Form_OwnUse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Form_OwnUse.Location = new System.Drawing.Point(3, 91);
            this.btn_Form_OwnUse.Name = "btn_Form_OwnUse";
            this.btn_Form_OwnUse.Size = new System.Drawing.Size(147, 81);
            this.btn_Form_OwnUse.TabIndex = 6;
            this.btn_Form_OwnUse.Text = "Form OwnUse";
            this.btn_Form_OwnUse.UseVisualStyleBackColor = false;
            this.btn_Form_OwnUse.Click += new System.EventHandler(this.btn_Form_OwnUse_Click);
            // 
            // Form_SelectStockEditType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 336);
            this.Controls.Add(this.btn_Form_OwnUse);
            this.Controls.Add(this.btn_PurchasePricesPerItem);
            this.Controls.Add(this.btn_Inventura);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_EditItemsInStock);
            this.Controls.Add(this.btn_EditStockTakeItems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SelectStockEditType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SelectStockEditType";
            this.Load += new System.EventHandler(this.Form_SelectStockEditType_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_EditStockTakeItems;
        private System.Windows.Forms.Button btn_EditItemsInStock;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.Button btn_Inventura;
        private System.Windows.Forms.Button btn_PurchasePricesPerItem;
        private System.Windows.Forms.Button btn_Form_OwnUse;
    }
}