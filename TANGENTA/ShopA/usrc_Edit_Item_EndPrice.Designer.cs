namespace ShopA
{
    partial class usrc_Edit_Item_EndPrice
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
            this.nm_EndPrice = new System.Windows.Forms.NumericUpDown();
            this.lbl_Item_EndPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nm_EndPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nm_EndPrice
            // 
            this.nm_EndPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nm_EndPrice.DecimalPlaces = 2;
            this.nm_EndPrice.Location = new System.Drawing.Point(3, 17);
            this.nm_EndPrice.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_EndPrice.Name = "nm_EndPrice";
            this.nm_EndPrice.Size = new System.Drawing.Size(120, 20);
            this.nm_EndPrice.TabIndex = 20;
            // 
            // lbl_Item_EndPrice
            // 
            this.lbl_Item_EndPrice.AutoSize = true;
            this.lbl_Item_EndPrice.Location = new System.Drawing.Point(3, 1);
            this.lbl_Item_EndPrice.Name = "lbl_Item_EndPrice";
            this.lbl_Item_EndPrice.Size = new System.Drawing.Size(71, 13);
            this.lbl_Item_EndPrice.TabIndex = 17;
            this.lbl_Item_EndPrice.Text = "Končna cena";
            // 
            // usrc_Edit_Item_EndPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nm_EndPrice);
            this.Controls.Add(this.lbl_Item_EndPrice);
            this.Name = "usrc_Edit_Item_EndPrice";
            this.Size = new System.Drawing.Size(129, 42);
            ((System.ComponentModel.ISupportInitialize)(this.nm_EndPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Item_EndPrice;
        private System.Windows.Forms.NumericUpDown nm_EndPrice;
    }
}
