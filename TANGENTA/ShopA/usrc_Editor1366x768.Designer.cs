namespace ShopA
{
    partial class usrc_Editor1366x768
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
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.btn_SelectItem = new System.Windows.Forms.Button();
            this.btn_AddNewLine = new System.Windows.Forms.Button();
            this.lbl_NetPrice_Value = new System.Windows.Forms.Label();
            this.chk_PriceWithTax = new System.Windows.Forms.CheckBox();
            this.lbl_EndNetPrice = new System.Windows.Forms.Label();
            this.lbl_EndPriceWidthDisocunt = new System.Windows.Forms.Label();
            this.lbl_Tax = new System.Windows.Forms.Label();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.lbl_Tax_Value = new System.Windows.Forms.Label();
            this.lbl_EndPriceWidthDisocunt_Value = new System.Windows.Forms.Label();
            this.txt_Discount = new System.Windows.Forms.TextBox();
            this.lbl_ShopA_Name = new System.Windows.Forms.Label();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.usrc_Edit_Item_Unit1 = new ShopA.usrc_Edit_Item_Unit();
            this.usrc_Edit_Item_Tax1 = new ShopA.usrc_Edit_Item_Tax();
            this.usrc_Edit_Item_Description1 = new ShopA.usrc_Edit_Item_Description();
            this.usrc_Edit_Item_Price1 = new ShopA.usrc_Edit_Item_Price();
            this.usrc_Edit_Item_Name1 = new ShopA.usrc_Edit_Item_Name();
            this.SuspendLayout();
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItem.Image = global::ShopA.Properties.Resources.Edit;
            this.btn_EditItem.Location = new System.Drawing.Point(118, 0);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(62, 40);
            this.btn_EditItem.TabIndex = 6;
            this.btn_EditItem.UseVisualStyleBackColor = false;
            this.btn_EditItem.Click += new System.EventHandler(this.btn_EditItem_Click);
            // 
            // btn_SelectItem
            // 
            this.btn_SelectItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectItem.Image = global::ShopA.Properties.Resources.SelectRow;
            this.btn_SelectItem.Location = new System.Drawing.Point(178, 0);
            this.btn_SelectItem.Name = "btn_SelectItem";
            this.btn_SelectItem.Size = new System.Drawing.Size(62, 40);
            this.btn_SelectItem.TabIndex = 5;
            this.btn_SelectItem.UseVisualStyleBackColor = false;
            this.btn_SelectItem.Click += new System.EventHandler(this.btn_SelectItem_Click);
            // 
            // btn_AddNewLine
            // 
            this.btn_AddNewLine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_AddNewLine.Location = new System.Drawing.Point(715, 37);
            this.btn_AddNewLine.Name = "btn_AddNewLine";
            this.btn_AddNewLine.Size = new System.Drawing.Size(128, 40);
            this.btn_AddNewLine.TabIndex = 3;
            this.btn_AddNewLine.Text = "Vpiši v novo vrstico";
            this.btn_AddNewLine.UseVisualStyleBackColor = false;
            this.btn_AddNewLine.Click += new System.EventHandler(this.btn_AddNewLine_Click);
            // 
            // lbl_NetPrice_Value
            // 
            this.lbl_NetPrice_Value.AutoSize = true;
            this.lbl_NetPrice_Value.Location = new System.Drawing.Point(659, 1);
            this.lbl_NetPrice_Value.Name = "lbl_NetPrice_Value";
            this.lbl_NetPrice_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_NetPrice_Value.TabIndex = 16;
            this.lbl_NetPrice_Value.Text = "TaxValue";
            // 
            // chk_PriceWithTax
            // 
            this.chk_PriceWithTax.Location = new System.Drawing.Point(614, 17);
            this.chk_PriceWithTax.Name = "chk_PriceWithTax";
            this.chk_PriceWithTax.Size = new System.Drawing.Size(138, 24);
            this.chk_PriceWithTax.TabIndex = 5;
            this.chk_PriceWithTax.Text = "Vnos cen z davkom";
            this.chk_PriceWithTax.UseVisualStyleBackColor = true;
            // 
            // lbl_EndNetPrice
            // 
            this.lbl_EndNetPrice.Location = new System.Drawing.Point(611, 1);
            this.lbl_EndNetPrice.Name = "lbl_EndNetPrice";
            this.lbl_EndNetPrice.Size = new System.Drawing.Size(42, 16);
            this.lbl_EndNetPrice.TabIndex = 15;
            this.lbl_EndNetPrice.Text = "Neto cena:";
            this.lbl_EndNetPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_EndPriceWidthDisocunt
            // 
            this.lbl_EndPriceWidthDisocunt.Location = new System.Drawing.Point(738, 20);
            this.lbl_EndPriceWidthDisocunt.Name = "lbl_EndPriceWidthDisocunt";
            this.lbl_EndPriceWidthDisocunt.Size = new System.Drawing.Size(186, 14);
            this.lbl_EndPriceWidthDisocunt.TabIndex = 9;
            this.lbl_EndPriceWidthDisocunt.Text = "Končna cena z davkom in popustom:";
            this.lbl_EndPriceWidthDisocunt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Tax
            // 
            this.lbl_Tax.Location = new System.Drawing.Point(714, 1);
            this.lbl_Tax.Name = "lbl_Tax";
            this.lbl_Tax.Size = new System.Drawing.Size(22, 16);
            this.lbl_Tax.TabIndex = 10;
            this.lbl_Tax.Text = "Davek:";
            this.lbl_Tax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Discount
            // 
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopA.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(849, 37);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(72, 40);
            this.btn_Discount.TabIndex = 13;
            this.btn_Discount.Text = "Popust";
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // lbl_Tax_Value
            // 
            this.lbl_Tax_Value.AutoSize = true;
            this.lbl_Tax_Value.Location = new System.Drawing.Point(741, 1);
            this.lbl_Tax_Value.Name = "lbl_Tax_Value";
            this.lbl_Tax_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_Tax_Value.TabIndex = 11;
            this.lbl_Tax_Value.Text = "TaxValue";
            // 
            // lbl_EndPriceWidthDisocunt_Value
            // 
            this.lbl_EndPriceWidthDisocunt_Value.AutoSize = true;
            this.lbl_EndPriceWidthDisocunt_Value.Location = new System.Drawing.Point(930, 21);
            this.lbl_EndPriceWidthDisocunt_Value.Name = "lbl_EndPriceWidthDisocunt_Value";
            this.lbl_EndPriceWidthDisocunt_Value.Size = new System.Drawing.Size(52, 13);
            this.lbl_EndPriceWidthDisocunt_Value.TabIndex = 12;
            this.lbl_EndPriceWidthDisocunt_Value.Text = "TaxValue";
            // 
            // txt_Discount
            // 
            this.txt_Discount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Discount.Location = new System.Drawing.Point(927, 52);
            this.txt_Discount.Name = "txt_Discount";
            this.txt_Discount.ReadOnly = true;
            this.txt_Discount.Size = new System.Drawing.Size(76, 22);
            this.txt_Discount.TabIndex = 17;
            // 
            // lbl_ShopA_Name
            // 
            this.lbl_ShopA_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_ShopA_Name.Location = new System.Drawing.Point(4, 5);
            this.lbl_ShopA_Name.Name = "lbl_ShopA_Name";
            this.lbl_ShopA_Name.Size = new System.Drawing.Size(112, 23);
            this.lbl_ShopA_Name.TabIndex = 18;
            this.lbl_ShopA_Name.Text = "A";
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Location = new System.Drawing.Point(5, 27);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(35, 13);
            this.lbl_Description.TabIndex = 19;
            this.lbl_Description.Text = "label1";
            // 
            // usrc_Edit_Item_Unit1
            // 
            this.usrc_Edit_Item_Unit1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usrc_Edit_Item_Unit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Unit1.Location = new System.Drawing.Point(243, 43);
            this.usrc_Edit_Item_Unit1.Name = "usrc_Edit_Item_Unit1";
            this.usrc_Edit_Item_Unit1.Size = new System.Drawing.Size(455, 34);
            this.usrc_Edit_Item_Unit1.TabIndex = 2;
            this.usrc_Edit_Item_Unit1.ValueChanged += new ShopA.usrc_Edit_Item_Unit.delegate_ValueChanged(this.usrc_Edit_Item_Unit1_ValueChanged);
            this.usrc_Edit_Item_Unit1.EditUnits += new ShopA.usrc_Edit_Item_Unit.delegate_EditUnis(this.usrc_Edit_Item_Unit1_EditUnits);
            // 
            // usrc_Edit_Item_Tax1
            // 
            this.usrc_Edit_Item_Tax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Tax1.Location = new System.Drawing.Point(383, 0);
            this.usrc_Edit_Item_Tax1.Name = "usrc_Edit_Item_Tax1";
            this.usrc_Edit_Item_Tax1.Size = new System.Drawing.Size(116, 44);
            this.usrc_Edit_Item_Tax1.TabIndex = 0;
            this.usrc_Edit_Item_Tax1.ValueChanged += new ShopA.usrc_Edit_Item_Tax.delegate_ValueChanged(this.usrc_Edit_Item_Tax1_ValueChanged);
            // 
            // usrc_Edit_Item_Description1
            // 
            this.usrc_Edit_Item_Description1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Description1.Location = new System.Drawing.Point(2, 42);
            this.usrc_Edit_Item_Description1.Name = "usrc_Edit_Item_Description1";
            this.usrc_Edit_Item_Description1.Size = new System.Drawing.Size(240, 38);
            this.usrc_Edit_Item_Description1.TabIndex = 3;
            // 
            // usrc_Edit_Item_Price1
            // 
            this.usrc_Edit_Item_Price1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Price1.Location = new System.Drawing.Point(501, 0);
            this.usrc_Edit_Item_Price1.Name = "usrc_Edit_Item_Price1";
            this.usrc_Edit_Item_Price1.Size = new System.Drawing.Size(101, 38);
            this.usrc_Edit_Item_Price1.TabIndex = 4;
            this.usrc_Edit_Item_Price1.ValueChanged += new ShopA.usrc_Edit_Item_Price.delegate_ValueChanged(this.usrc_Edit_Item_EndPrice1_ValueChanged);
            // 
            // usrc_Edit_Item_Name1
            // 
            this.usrc_Edit_Item_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Name1.Location = new System.Drawing.Point(240, 0);
            this.usrc_Edit_Item_Name1.Name = "usrc_Edit_Item_Name1";
            this.usrc_Edit_Item_Name1.Size = new System.Drawing.Size(144, 45);
            this.usrc_Edit_Item_Name1.TabIndex = 4;
            // 
            // usrc_Editor1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lbl_Description);
            this.Controls.Add(this.lbl_ShopA_Name);
            this.Controls.Add(this.txt_Discount);
            this.Controls.Add(this.lbl_EndPriceWidthDisocunt);
            this.Controls.Add(this.lbl_EndPriceWidthDisocunt_Value);
            this.Controls.Add(this.btn_AddNewLine);
            this.Controls.Add(this.usrc_Edit_Item_Unit1);
            this.Controls.Add(this.lbl_NetPrice_Value);
            this.Controls.Add(this.btn_EditItem);
            this.Controls.Add(this.chk_PriceWithTax);
            this.Controls.Add(this.lbl_EndNetPrice);
            this.Controls.Add(this.usrc_Edit_Item_Tax1);
            this.Controls.Add(this.usrc_Edit_Item_Description1);
            this.Controls.Add(this.lbl_Tax);
            this.Controls.Add(this.usrc_Edit_Item_Price1);
            this.Controls.Add(this.btn_Discount);
            this.Controls.Add(this.btn_SelectItem);
            this.Controls.Add(this.lbl_Tax_Value);
            this.Controls.Add(this.usrc_Edit_Item_Name1);
            this.Name = "usrc_Editor1366x768";
            this.Size = new System.Drawing.Size(1006, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label lbl_NetPrice_Value;
        private System.Windows.Forms.Label lbl_EndNetPrice;
        private System.Windows.Forms.TextBox txt_Discount;
        private System.Windows.Forms.Label lbl_ShopA_Name;
        private System.Windows.Forms.Label lbl_Description;
    }
}
