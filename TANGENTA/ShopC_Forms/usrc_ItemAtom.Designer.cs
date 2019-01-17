namespace ShopC_Forms
{
    partial class usrc_Atom_Item
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
            this.lbl_Item_UniqueName = new System.Windows.Forms.Label();
            this.lbl_RetailPriceValue = new System.Windows.Forms.Label();
            this.lbl_DiscountValue = new System.Windows.Forms.Label();
            this.lbl_DiscountText = new System.Windows.Forms.Label();
            this.btn_RemoveFromBasket = new System.Windows.Forms.Button();
            this.lbl_Quantity_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Item_UniqueName
            // 
            this.lbl_Item_UniqueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Item_UniqueName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item_UniqueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item_UniqueName.Location = new System.Drawing.Point(3, 3);
            this.lbl_Item_UniqueName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item_UniqueName.Name = "lbl_Item_UniqueName";
            this.lbl_Item_UniqueName.Size = new System.Drawing.Size(288, 18);
            this.lbl_Item_UniqueName.TabIndex = 0;
            this.lbl_Item_UniqueName.Text = "label1";
            this.lbl_Item_UniqueName.Click += new System.EventHandler(this.lbl_Item_Click);
            // 
            // lbl_RetailPriceValue
            // 
            this.lbl_RetailPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_RetailPriceValue.Location = new System.Drawing.Point(86, 22);
            this.lbl_RetailPriceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_RetailPriceValue.Name = "lbl_RetailPriceValue";
            this.lbl_RetailPriceValue.Size = new System.Drawing.Size(73, 13);
            this.lbl_RetailPriceValue.TabIndex = 20;
            this.lbl_RetailPriceValue.Text = "0";
            this.lbl_RetailPriceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_RetailPriceValue.Click += new System.EventHandler(this.lbl_RetailPriceValue_Click);
            // 
            // lbl_DiscountValue
            // 
            this.lbl_DiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_DiscountValue.Location = new System.Drawing.Point(223, 22);
            this.lbl_DiscountValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DiscountValue.Name = "lbl_DiscountValue";
            this.lbl_DiscountValue.Size = new System.Drawing.Size(64, 13);
            this.lbl_DiscountValue.TabIndex = 21;
            this.lbl_DiscountValue.Text = "0%";
            this.lbl_DiscountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_DiscountValue.Click += new System.EventHandler(this.lbl_DiscountValue_Click);
            // 
            // lbl_DiscountText
            // 
            this.lbl_DiscountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_DiscountText.Location = new System.Drawing.Point(168, 22);
            this.lbl_DiscountText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DiscountText.Name = "lbl_DiscountText";
            this.lbl_DiscountText.Size = new System.Drawing.Size(47, 13);
            this.lbl_DiscountText.TabIndex = 23;
            this.lbl_DiscountText.Text = "Popust:";
            this.lbl_DiscountText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_DiscountText.Click += new System.EventHandler(this.lbl_DiscountText_Click);
            // 
            // btn_RemoveFromBasket
            // 
            this.btn_RemoveFromBasket.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_RemoveFromBasket.Image = TangentaResources.Properties.Resources.RemoveFromBoxToFactory;
            this.btn_RemoveFromBasket.Location = new System.Drawing.Point(290, 1);
            this.btn_RemoveFromBasket.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RemoveFromBasket.Name = "btn_RemoveFromBasket";
            this.btn_RemoveFromBasket.Size = new System.Drawing.Size(68, 37);
            this.btn_RemoveFromBasket.TabIndex = 25;
            this.btn_RemoveFromBasket.UseVisualStyleBackColor = false;
            this.btn_RemoveFromBasket.Visible = false;
            this.btn_RemoveFromBasket.Click += new System.EventHandler(this.btn_RemoveFromBasket_Click);
            // 
            // lbl_Quantity_Value
            // 
            this.lbl_Quantity_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity_Value.Location = new System.Drawing.Point(5, 22);
            this.lbl_Quantity_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Quantity_Value.Name = "lbl_Quantity_Value";
            this.lbl_Quantity_Value.Size = new System.Drawing.Size(73, 13);
            this.lbl_Quantity_Value.TabIndex = 27;
            this.lbl_Quantity_Value.Text = "0 kom";
            this.lbl_Quantity_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Quantity_Value.Click += new System.EventHandler(this.lbl_Quantity_Value_Click);
            // 
            // usrc_Atom_Item1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_Quantity_Value);
            this.Controls.Add(this.btn_RemoveFromBasket);
            this.Controls.Add(this.lbl_DiscountText);
            this.Controls.Add(this.lbl_DiscountValue);
            this.Controls.Add(this.lbl_RetailPriceValue);
            this.Controls.Add(this.lbl_Item_UniqueName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Atom_Item1366x768";
            this.Size = new System.Drawing.Size(362, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_UniqueName;
        private System.Windows.Forms.Label lbl_RetailPriceValue;
        private System.Windows.Forms.Label lbl_DiscountValue;
        private System.Windows.Forms.Label lbl_DiscountText;
        private System.Windows.Forms.Button btn_RemoveFromBasket;
        private System.Windows.Forms.Label lbl_Quantity_Value;
    }
}
