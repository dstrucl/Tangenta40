namespace ShopA
{
    partial class usrc_Edit_Item_Price
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
            this.nm_Price = new System.Windows.Forms.NumericUpDown();
            this.lbl_Item_Price = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Price)).BeginInit();
            this.SuspendLayout();
            // 
            // nm_Price
            // 
            this.nm_Price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nm_Price.DecimalPlaces = 2;
            this.nm_Price.Location = new System.Drawing.Point(3, 17);
            this.nm_Price.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_Price.Name = "nm_Price";
            this.nm_Price.Size = new System.Drawing.Size(120, 20);
            this.nm_Price.TabIndex = 20;
            // 
            // lbl_Item_Price
            // 
            this.lbl_Item_Price.AutoSize = true;
            this.lbl_Item_Price.Location = new System.Drawing.Point(3, 1);
            this.lbl_Item_Price.Name = "lbl_Item_Price";
            this.lbl_Item_Price.Size = new System.Drawing.Size(32, 13);
            this.lbl_Item_Price.TabIndex = 17;
            this.lbl_Item_Price.Text = "Cena";
            // 
            // usrc_Edit_Item_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nm_Price);
            this.Controls.Add(this.lbl_Item_Price);
            this.Name = "usrc_Edit_Item_Price";
            this.Size = new System.Drawing.Size(129, 42);
            ((System.ComponentModel.ISupportInitialize)(this.nm_Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Item_Price;
        private System.Windows.Forms.NumericUpDown nm_Price;
    }
}
