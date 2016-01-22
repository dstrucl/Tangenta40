namespace ShopA
{
    partial class usrc_Quantity
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
            this.chk_Quantity = new System.Windows.Forms.CheckBox();
            this.nm_dQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_Quantity
            // 
            this.chk_Quantity.AutoSize = true;
            this.chk_Quantity.Location = new System.Drawing.Point(7, 2);
            this.chk_Quantity.Name = "chk_Quantity";
            this.chk_Quantity.Size = new System.Drawing.Size(63, 17);
            this.chk_Quantity.TabIndex = 0;
            this.chk_Quantity.Text = "Količina";
            this.chk_Quantity.UseVisualStyleBackColor = true;
            // 
            // nm_dQuantity
            // 
            this.nm_dQuantity.Location = new System.Drawing.Point(7, 26);
            this.nm_dQuantity.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nm_dQuantity.Name = "nm_dQuantity";
            this.nm_dQuantity.Size = new System.Drawing.Size(120, 20);
            this.nm_dQuantity.TabIndex = 1;
            // 
            // usrc_Quantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nm_dQuantity);
            this.Controls.Add(this.chk_Quantity);
            this.Name = "usrc_Quantity";
            this.Size = new System.Drawing.Size(132, 52);
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_Quantity;
        private System.Windows.Forms.NumericUpDown nm_dQuantity;
    }
}
