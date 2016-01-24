namespace ShopA
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
            this.chk_PriceWithTax = new System.Windows.Forms.CheckBox();
            this.lbl_Line = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_AddNewLine = new System.Windows.Forms.Button();
            this.nm_Discount = new System.Windows.Forms.NumericUpDown();
            this.chk_Discount = new System.Windows.Forms.CheckBox();
            this.lbl_EndPriceWidthDisocunt = new System.Windows.Forms.Label();
            this.usrc_Edit_Item_Tax1 = new ShopA.usrc_Edit_Item_Tax();
            this.usrc_Edit_Item_Unit1 = new ShopA.usrc_Edit_Item_Unit();
            this.usrc_Edit_Item_EndPrice1 = new ShopA.usrc_Edit_Item_EndPrice();
            this.usrc_Edit_Item_Description1 = new ShopA.usrc_Edit_Item_Description();
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.usrc_Edit_Item_Name1 = new ShopA.usrc_Edit_Item_Name();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(1, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Edit_Item_Description1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_EditItem);
            this.splitContainer1.Panel1.Controls.Add(this.btn_SelectItem);
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Edit_Item_Name1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.lbl_EndPriceWidthDisocunt);
            this.splitContainer1.Panel2.Controls.Add(this.chk_Discount);
            this.splitContainer1.Panel2.Controls.Add(this.nm_Discount);
            this.splitContainer1.Panel2.Controls.Add(this.chk_PriceWithTax);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_Tax1);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_Unit1);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Edit_Item_EndPrice1);
            this.splitContainer1.Size = new System.Drawing.Size(797, 145);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 0;
            // 
            // chk_PriceWithTax
            // 
            this.chk_PriceWithTax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_PriceWithTax.Location = new System.Drawing.Point(245, 6);
            this.chk_PriceWithTax.Name = "chk_PriceWithTax";
            this.chk_PriceWithTax.Size = new System.Drawing.Size(227, 16);
            this.chk_PriceWithTax.TabIndex = 5;
            this.chk_PriceWithTax.Text = "Vnos cen z davkom";
            this.chk_PriceWithTax.UseVisualStyleBackColor = true;
            // 
            // lbl_Line
            // 
            this.lbl_Line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Line.AutoSize = true;
            this.lbl_Line.Location = new System.Drawing.Point(6, 157);
            this.lbl_Line.Name = "lbl_Line";
            this.lbl_Line.Size = new System.Drawing.Size(48, 13);
            this.lbl_Line.TabIndex = 1;
            this.lbl_Line.Text = "Vrstica:1";
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.Location = new System.Drawing.Point(354, 154);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(219, 26);
            this.btn_Update.TabIndex = 2;
            this.btn_Update.Text = "Popravi vrstico";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_AddNewLine
            // 
            this.btn_AddNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddNewLine.Location = new System.Drawing.Point(579, 153);
            this.btn_AddNewLine.Name = "btn_AddNewLine";
            this.btn_AddNewLine.Size = new System.Drawing.Size(219, 26);
            this.btn_AddNewLine.TabIndex = 3;
            this.btn_AddNewLine.Text = "Vpiši v novo vrstico";
            this.btn_AddNewLine.UseVisualStyleBackColor = true;
            this.btn_AddNewLine.Click += new System.EventHandler(this.btn_AddNewLine_Click);
            // 
            // nm_Discount
            // 
            this.nm_Discount.Location = new System.Drawing.Point(355, 117);
            this.nm_Discount.Name = "nm_Discount";
            this.nm_Discount.Size = new System.Drawing.Size(68, 20);
            this.nm_Discount.TabIndex = 7;
            // 
            // chk_Discount
            // 
            this.chk_Discount.AutoSize = true;
            this.chk_Discount.Location = new System.Drawing.Point(356, 96);
            this.chk_Discount.Name = "chk_Discount";
            this.chk_Discount.Size = new System.Drawing.Size(59, 17);
            this.chk_Discount.TabIndex = 8;
            this.chk_Discount.Text = "Popust";
            this.chk_Discount.UseVisualStyleBackColor = true;
            // 
            // lbl_EndPriceWidthDisocunt
            // 
            this.lbl_EndPriceWidthDisocunt.AutoSize = true;
            this.lbl_EndPriceWidthDisocunt.Location = new System.Drawing.Point(246, 29);
            this.lbl_EndPriceWidthDisocunt.Name = "lbl_EndPriceWidthDisocunt";
            this.lbl_EndPriceWidthDisocunt.Size = new System.Drawing.Size(131, 13);
            this.lbl_EndPriceWidthDisocunt.TabIndex = 9;
            this.lbl_EndPriceWidthDisocunt.Text = "Končna cena s popustom:";
            // 
            // usrc_Edit_Item_Tax1
            // 
            this.usrc_Edit_Item_Tax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Tax1.Location = new System.Drawing.Point(2, 3);
            this.usrc_Edit_Item_Tax1.Name = "usrc_Edit_Item_Tax1";
            this.usrc_Edit_Item_Tax1.Size = new System.Drawing.Size(115, 42);
            this.usrc_Edit_Item_Tax1.TabIndex = 0;
            // 
            // usrc_Edit_Item_Unit1
            // 
            this.usrc_Edit_Item_Unit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Unit1.Location = new System.Drawing.Point(2, 49);
            this.usrc_Edit_Item_Unit1.Name = "usrc_Edit_Item_Unit1";
            this.usrc_Edit_Item_Unit1.Size = new System.Drawing.Size(346, 92);
            this.usrc_Edit_Item_Unit1.TabIndex = 2;
            // 
            // usrc_Edit_Item_EndPrice1
            // 
            this.usrc_Edit_Item_EndPrice1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_EndPrice1.Location = new System.Drawing.Point(123, 3);
            this.usrc_Edit_Item_EndPrice1.Name = "usrc_Edit_Item_EndPrice1";
            this.usrc_Edit_Item_EndPrice1.Size = new System.Drawing.Size(116, 42);
            this.usrc_Edit_Item_EndPrice1.TabIndex = 4;
            // 
            // usrc_Edit_Item_Description1
            // 
            this.usrc_Edit_Item_Description1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Edit_Item_Description1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Description1.Location = new System.Drawing.Point(8, 54);
            this.usrc_Edit_Item_Description1.Name = "usrc_Edit_Item_Description1";
            this.usrc_Edit_Item_Description1.Size = new System.Drawing.Size(290, 88);
            this.usrc_Edit_Item_Description1.TabIndex = 3;
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.Location = new System.Drawing.Point(8, 7);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(47, 37);
            this.btn_EditItem.TabIndex = 6;
            this.btn_EditItem.Text = "Edit Item";
            this.btn_EditItem.UseVisualStyleBackColor = true;
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.Location = new System.Drawing.Point(61, 7);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(47, 39);
            this.btn_SelectItem.TabIndex = 5;
            this.btn_SelectItem.Text = "SelectItem";
            this.btn_SelectItem.UseVisualStyleBackColor = true;
            // 
            // usrc_Edit_Item_Name1
            // 
            this.usrc_Edit_Item_Name1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Edit_Item_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Name1.Location = new System.Drawing.Point(114, 4);
            this.usrc_Edit_Item_Name1.Name = "usrc_Edit_Item_Name1";
            this.usrc_Edit_Item_Name1.Size = new System.Drawing.Size(184, 44);
            this.usrc_Edit_Item_Name1.TabIndex = 4;
            // 
            // usrc_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btn_AddNewLine);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.lbl_Line);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_Editor";
            this.Size = new System.Drawing.Size(801, 183);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Edit_Item_Tax usrc_Edit_Item_Tax1;
        private usrc_Edit_Item_Unit usrc_Edit_Item_Unit1;
        private usrc_Edit_Item_EndPrice usrc_Edit_Item_EndPrice1;
        private System.Windows.Forms.CheckBox chk_PriceWithTax;
        private System.Windows.Forms.Label lbl_Line;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_AddNewLine;
        private System.Windows.Forms.Label lbl_EndPriceWidthDisocunt;
        private System.Windows.Forms.CheckBox chk_Discount;
        private System.Windows.Forms.NumericUpDown nm_Discount;
        private usrc_Edit_Item_Name usrc_Edit_Item_Name1;
        private System.Windows.Forms.Button btn_SelectItem;
        private System.Windows.Forms.Button btn_EditItem;
        private usrc_Edit_Item_Description usrc_Edit_Item_Description1;
    }
}
