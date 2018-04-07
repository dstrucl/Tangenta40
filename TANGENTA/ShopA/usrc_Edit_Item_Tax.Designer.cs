namespace ShopA
{
    partial class usrc_Edit_Item_Tax
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
            this.lbl_Item_TaxRate = new System.Windows.Forms.Label();
            this.cmb_TaxRate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Item_TaxRate
            // 
            this.lbl_Item_TaxRate.AutoSize = true;
            this.lbl_Item_TaxRate.Location = new System.Drawing.Point(3, 0);
            this.lbl_Item_TaxRate.Name = "lbl_Item_TaxRate";
            this.lbl_Item_TaxRate.Size = new System.Drawing.Size(90, 13);
            this.lbl_Item_TaxRate.TabIndex = 2;
            this.lbl_Item_TaxRate.Text = "lbl_Item_TaxRate";
            // 
            // cmb_TaxRate
            // 
            this.cmb_TaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_TaxRate.FormattingEnabled = true;
            this.cmb_TaxRate.Location = new System.Drawing.Point(4, 17);
            this.cmb_TaxRate.Name = "cmb_TaxRate";
            this.cmb_TaxRate.Size = new System.Drawing.Size(137, 21);
            this.cmb_TaxRate.TabIndex = 3;
            // 
            // usrc_Edit_Item_Tax
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_TaxRate);
            this.Controls.Add(this.lbl_Item_TaxRate);
            this.Name = "usrc_Edit_Item_Tax";
            this.Size = new System.Drawing.Size(146, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_TaxRate;
        private System.Windows.Forms.ComboBox cmb_TaxRate;
    }
}
