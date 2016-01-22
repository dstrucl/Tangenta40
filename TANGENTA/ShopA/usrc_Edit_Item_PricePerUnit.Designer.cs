namespace ShopA
{
    partial class usrc_Edit_Item_PricePerUnit
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
            this.nm_PricePerUnit_With_TAX = new System.Windows.Forms.NumericUpDown();
            this.nm_PricePerUnit_Without_TAX = new System.Windows.Forms.NumericUpDown();
            this.lbl_WithoutTax = new System.Windows.Forms.Label();
            this.llbl_WithTax = new System.Windows.Forms.Label();
            this.lbl_Item_PricePerUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit_With_TAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit_Without_TAX)).BeginInit();
            this.SuspendLayout();
            // 
            // nm_PricePerUnit_With_TAX
            // 
            this.nm_PricePerUnit_With_TAX.DecimalPlaces = 2;
            this.nm_PricePerUnit_With_TAX.Location = new System.Drawing.Point(3, 77);
            this.nm_PricePerUnit_With_TAX.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_PricePerUnit_With_TAX.Name = "nm_PricePerUnit_With_TAX";
            this.nm_PricePerUnit_With_TAX.Size = new System.Drawing.Size(122, 20);
            this.nm_PricePerUnit_With_TAX.TabIndex = 16;
            // 
            // nm_PricePerUnit_Without_TAX
            // 
            this.nm_PricePerUnit_Without_TAX.DecimalPlaces = 2;
            this.nm_PricePerUnit_Without_TAX.Location = new System.Drawing.Point(3, 40);
            this.nm_PricePerUnit_Without_TAX.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_PricePerUnit_Without_TAX.Name = "nm_PricePerUnit_Without_TAX";
            this.nm_PricePerUnit_Without_TAX.Size = new System.Drawing.Size(122, 20);
            this.nm_PricePerUnit_Without_TAX.TabIndex = 15;
            // 
            // lbl_WithoutTax
            // 
            this.lbl_WithoutTax.AutoSize = true;
            this.lbl_WithoutTax.Location = new System.Drawing.Point(3, 24);
            this.lbl_WithoutTax.Name = "lbl_WithoutTax";
            this.lbl_WithoutTax.Size = new System.Drawing.Size(62, 13);
            this.lbl_WithoutTax.TabIndex = 14;
            this.lbl_WithoutTax.Text = "brez Davka";
            // 
            // llbl_WithTax
            // 
            this.llbl_WithTax.AutoSize = true;
            this.llbl_WithTax.Location = new System.Drawing.Point(3, 62);
            this.llbl_WithTax.Name = "llbl_WithTax";
            this.llbl_WithTax.Size = new System.Drawing.Size(55, 13);
            this.llbl_WithTax.TabIndex = 13;
            this.llbl_WithTax.Text = "z Davkom";
            // 
            // lbl_Item_PricePerUnit
            // 
            this.lbl_Item_PricePerUnit.AutoSize = true;
            this.lbl_Item_PricePerUnit.Location = new System.Drawing.Point(3, 3);
            this.lbl_Item_PricePerUnit.Name = "lbl_Item_PricePerUnit";
            this.lbl_Item_PricePerUnit.Size = new System.Drawing.Size(77, 13);
            this.lbl_Item_PricePerUnit.TabIndex = 12;
            this.lbl_Item_PricePerUnit.Text = "Cena na enoto";
            // 
            // usrc_Edit_Item_PricePerUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nm_PricePerUnit_With_TAX);
            this.Controls.Add(this.nm_PricePerUnit_Without_TAX);
            this.Controls.Add(this.lbl_WithoutTax);
            this.Controls.Add(this.llbl_WithTax);
            this.Controls.Add(this.lbl_Item_PricePerUnit);
            this.Name = "usrc_Edit_Item_PricePerUnit";
            this.Size = new System.Drawing.Size(128, 101);
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit_With_TAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit_Without_TAX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nm_PricePerUnit_With_TAX;
        private System.Windows.Forms.NumericUpDown nm_PricePerUnit_Without_TAX;
        private System.Windows.Forms.Label lbl_WithoutTax;
        private System.Windows.Forms.Label llbl_WithTax;
        private System.Windows.Forms.Label lbl_Item_PricePerUnit;
    }
}
