﻿namespace ShopA
{
    partial class usrc_Editor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_Edit_Item_Description1 = new ShopA.usrc_Edit_Item_Description();
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.usrc_Edit_Item_Name1 = new ShopA.usrc_Edit_Item_Name();
            this.btn_AddNewLine = new System.Windows.Forms.Button();
            this.lbl_NetPrice_Value = new System.Windows.Forms.Label();
            this.lbl_EndNetPrice = new System.Windows.Forms.Label();
            this.txt_Discount = new System.Windows.Forms.TextBox();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.lbl_EndPriceWidthDisocunt_Value = new System.Windows.Forms.Label();
            this.lbl_Tax_Value = new System.Windows.Forms.Label();
            this.lbl_Tax = new System.Windows.Forms.Label();
            this.lbl_EndPriceWidthDisocunt = new System.Windows.Forms.Label();
            this.chk_PriceWithTax = new System.Windows.Forms.CheckBox();
            this.usrc_Edit_Item_Tax1 = new ShopA.usrc_Edit_Item_Tax();
            this.usrc_Edit_Item_Unit1 = new ShopA.usrc_Edit_Item_Unit();
            this.usrc_Edit_Item_Price1 = new ShopA.usrc_Edit_Item_Price();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Edit_Item_Description1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_EditItem);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectItem);
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Edit_Item_Name1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.btn_AddNewLine);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_NetPrice_Value);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_EndNetPrice);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Discount);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Discount);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_EndPriceWidthDisocunt_Value);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Tax_Value);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Tax);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_EndPriceWidthDisocunt);
            this.splitContainer1.Panel2.Controls.Add(this.chk_PriceWithTax);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_Tax1);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_Unit1);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_Price1);
            this.splitContainer1.Size = new System.Drawing.Size(678, 149);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_Edit_Item_Description1
            // 
            this.usrc_Edit_Item_Description1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Edit_Item_Description1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Description1.Location = new System.Drawing.Point(2, 54);
            this.usrc_Edit_Item_Description1.Name = "usrc_Edit_Item_Description1";
            this.usrc_Edit_Item_Description1.Size = new System.Drawing.Size(168, 90);
            this.usrc_Edit_Item_Description1.TabIndex = 3;
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItem.Image = global::ShopA.Properties.Resources.Edit;
            this.btn_EditItem.Location = new System.Drawing.Point(3, 5);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(37, 37);
            this.btn_EditItem.TabIndex = 6;
            this.btn_EditItem.UseVisualStyleBackColor = false;
            this.btn_EditItem.Click += new System.EventHandler(this.btn_EditItem_Click);
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectItem.Image = global::ShopA.Properties.Resources.SelectRow;
            this.btn_SelectItem.Location = new System.Drawing.Point(49, 7);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(37, 35);
            this.btn_SelectItem.TabIndex = 5;
            this.btn_SelectItem.UseVisualStyleBackColor = false;
            this.btn_SelectItem.Click += new System.EventHandler(this.btn_SelectItem_Click);
            // 
            // usrc_Edit_Item_Name1
            // 
            this.usrc_Edit_Item_Name1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Edit_Item_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Name1.Location = new System.Drawing.Point(94, 2);
            this.usrc_Edit_Item_Name1.Name = "usrc_Edit_Item_Name1";
            this.usrc_Edit_Item_Name1.Size = new System.Drawing.Size(76, 44);
            this.usrc_Edit_Item_Name1.TabIndex = 4;
            // 
            // btn_AddNewLine
            // 
            this.btn_AddNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewLine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AddNewLine.Location = new System.Drawing.Point(225, 109);
            this.btn_AddNewLine.Name = "btn_AddNewLine";
            this.btn_AddNewLine.Size = new System.Drawing.Size(272, 35);
            this.btn_AddNewLine.TabIndex = 3;
            this.btn_AddNewLine.Text = "Vpiši v novo vrstico";
            this.btn_AddNewLine.UseVisualStyleBackColor = false;
            this.btn_AddNewLine.Click += new System.EventHandler(this.btn_AddNewLine_Click);
            // 
            // lbl_NetPrice_Value
            // 
            this.lbl_NetPrice_Value.AutoSize = true;
            this.lbl_NetPrice_Value.Location = new System.Drawing.Point(288, 40);
            this.lbl_NetPrice_Value.Name = "lbl_NetPrice_Value";
            this.lbl_NetPrice_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_NetPrice_Value.TabIndex = 16;
            this.lbl_NetPrice_Value.Text = "TaxValue";
            // 
            // lbl_EndNetPrice
            // 
            this.lbl_EndNetPrice.Location = new System.Drawing.Point(225, 39);
            this.lbl_EndNetPrice.Name = "lbl_EndNetPrice";
            this.lbl_EndNetPrice.Size = new System.Drawing.Size(62, 16);
            this.lbl_EndNetPrice.TabIndex = 15;
            this.lbl_EndNetPrice.Text = "Neto cena:";
            this.lbl_EndNetPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Discount
            // 
            this.txt_Discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Discount.Location = new System.Drawing.Point(353, 131);
            this.txt_Discount.Name = "txt_Discount";
            this.txt_Discount.ReadOnly = true;
            this.txt_Discount.Size = new System.Drawing.Size(98, 15);
            this.txt_Discount.TabIndex = 14;
            // 
            // btn_Discount
            // 
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopA.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(226, 11);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(77, 25);
            this.btn_Discount.TabIndex = 13;
            this.btn_Discount.Text = "Popust";
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // lbl_EndPriceWidthDisocunt_Value
            // 
            this.lbl_EndPriceWidthDisocunt_Value.AutoSize = true;
            this.lbl_EndPriceWidthDisocunt_Value.Location = new System.Drawing.Point(430, 56);
            this.lbl_EndPriceWidthDisocunt_Value.Name = "lbl_EndPriceWidthDisocunt_Value";
            this.lbl_EndPriceWidthDisocunt_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_EndPriceWidthDisocunt_Value.TabIndex = 12;
            this.lbl_EndPriceWidthDisocunt_Value.Text = "TaxValue";
            // 
            // lbl_Tax_Value
            // 
            this.lbl_Tax_Value.AutoSize = true;
            this.lbl_Tax_Value.Location = new System.Drawing.Point(430, 40);
            this.lbl_Tax_Value.Name = "lbl_Tax_Value";
            this.lbl_Tax_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_Tax_Value.TabIndex = 11;
            this.lbl_Tax_Value.Text = "TaxValue";
            this.lbl_Tax_Value.Click += new System.EventHandler(this.lbl_Tax_Value_Click);
            // 
            // lbl_Tax
            // 
            this.lbl_Tax.Location = new System.Drawing.Point(387, 39);
            this.lbl_Tax.Name = "lbl_Tax";
            this.lbl_Tax.Size = new System.Drawing.Size(42, 16);
            this.lbl_Tax.TabIndex = 10;
            this.lbl_Tax.Text = "Davek:";
            this.lbl_Tax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_Tax.Click += new System.EventHandler(this.lbl_Tax_Click);
            // 
            // lbl_EndPriceWidthDisocunt
            // 
            this.lbl_EndPriceWidthDisocunt.Location = new System.Drawing.Point(236, 55);
            this.lbl_EndPriceWidthDisocunt.Name = "lbl_EndPriceWidthDisocunt";
            this.lbl_EndPriceWidthDisocunt.Size = new System.Drawing.Size(193, 13);
            this.lbl_EndPriceWidthDisocunt.TabIndex = 9;
            this.lbl_EndPriceWidthDisocunt.Text = "Končna cena z davkom in popustom:";
            this.lbl_EndPriceWidthDisocunt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chk_PriceWithTax
            // 
            this.chk_PriceWithTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_PriceWithTax.Location = new System.Drawing.Point(310, 13);
            this.chk_PriceWithTax.Name = "chk_PriceWithTax";
            this.chk_PriceWithTax.Size = new System.Drawing.Size(141, 24);
            this.chk_PriceWithTax.TabIndex = 5;
            this.chk_PriceWithTax.Text = "Vnos cen z davkom";
            this.chk_PriceWithTax.UseVisualStyleBackColor = true;
            // 
            // usrc_Edit_Item_Tax1
            // 
            this.usrc_Edit_Item_Tax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Tax1.Location = new System.Drawing.Point(2, 12);
            this.usrc_Edit_Item_Tax1.Name = "usrc_Edit_Item_Tax1";
            this.usrc_Edit_Item_Tax1.Size = new System.Drawing.Size(115, 41);
            this.usrc_Edit_Item_Tax1.TabIndex = 0;
            this.usrc_Edit_Item_Tax1.ValueChanged += new ShopA.usrc_Edit_Item_Tax.delegate_ValueChanged(this.usrc_Edit_Item_Tax1_ValueChanged);
            // 
            // usrc_Edit_Item_Unit1
            // 
            this.usrc_Edit_Item_Unit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Unit1.Location = new System.Drawing.Point(2, 55);
            this.usrc_Edit_Item_Unit1.Name = "usrc_Edit_Item_Unit1";
            this.usrc_Edit_Item_Unit1.Size = new System.Drawing.Size(218, 92);
            this.usrc_Edit_Item_Unit1.TabIndex = 2;
            this.usrc_Edit_Item_Unit1.ValueChanged += new ShopA.usrc_Edit_Item_Unit.delegate_ValueChanged(this.usrc_Edit_Item_Unit1_ValueChanged);
            this.usrc_Edit_Item_Unit1.EditUnits += new ShopA.usrc_Edit_Item_Unit.delegate_EditUnis(this.usrc_Edit_Item_Unit1_EditUnits);
            // 
            // usrc_Edit_Item_Price1
            // 
            this.usrc_Edit_Item_Price1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Price1.Location = new System.Drawing.Point(119, 12);
            this.usrc_Edit_Item_Price1.Name = "usrc_Edit_Item_Price1";
            this.usrc_Edit_Item_Price1.Size = new System.Drawing.Size(101, 41);
            this.usrc_Edit_Item_Price1.TabIndex = 4;
            this.usrc_Edit_Item_Price1.ValueChanged += new ShopA.usrc_Edit_Item_Price.delegate_ValueChanged(this.usrc_Edit_Item_EndPrice1_ValueChanged);
            // 
            // usrc_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_Editor";
            this.Size = new System.Drawing.Size(678, 149);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Edit_Item_Tax usrc_Edit_Item_Tax1;
        private usrc_Edit_Item_Unit usrc_Edit_Item_Unit1;
        private usrc_Edit_Item_Price usrc_Edit_Item_Price1;
        private System.Windows.Forms.CheckBox chk_PriceWithTax;
        private System.Windows.Forms.Button btn_AddNewLine;
        private System.Windows.Forms.Label lbl_EndPriceWidthDisocunt;
        private usrc_Edit_Item_Name usrc_Edit_Item_Name1;
        private System.Windows.Forms.Button btn_SelectItem;
        private System.Windows.Forms.Button btn_EditItem;
        private usrc_Edit_Item_Description usrc_Edit_Item_Description1;
        private System.Windows.Forms.Label lbl_EndPriceWidthDisocunt_Value;
        private System.Windows.Forms.Label lbl_Tax_Value;
        private System.Windows.Forms.Label lbl_Tax;
        private System.Windows.Forms.Button btn_Discount;
        private System.Windows.Forms.TextBox txt_Discount;
        private System.Windows.Forms.Label lbl_NetPrice_Value;
        private System.Windows.Forms.Label lbl_EndNetPrice;
    }
}
