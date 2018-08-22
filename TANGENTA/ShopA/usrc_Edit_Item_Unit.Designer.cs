namespace ShopA
{
    partial class usrc_Edit_Item_Unit
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
            this.cmb_Unit = new System.Windows.Forms.ComboBox();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.nm_dQuantity = new System.Windows.Forms.NumericUpDown();
            this.nm_PricePerUnit = new System.Windows.Forms.NumericUpDown();
            this.lbl_PricePerUnit = new System.Windows.Forms.Label();
            this.chk_Unit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Unit
            // 
            this.cmb_Unit.FormattingEnabled = true;
            this.cmb_Unit.Location = new System.Drawing.Point(97, 2);
            this.cmb_Unit.Name = "cmb_Unit";
            this.cmb_Unit.Size = new System.Drawing.Size(66, 21);
            this.cmb_Unit.TabIndex = 5;
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(167, 7);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(44, 13);
            this.lbl_Quantity.TabIndex = 7;
            this.lbl_Quantity.Text = "Količina";
            this.lbl_Quantity.Click += new System.EventHandler(this.lbl_Quantity_Click);
            // 
            // nm_dQuantity
            // 
            this.nm_dQuantity.Location = new System.Drawing.Point(217, 5);
            this.nm_dQuantity.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nm_dQuantity.Name = "nm_dQuantity";
            this.nm_dQuantity.Size = new System.Drawing.Size(63, 20);
            this.nm_dQuantity.TabIndex = 6;
            this.nm_dQuantity.ValueChanged += new System.EventHandler(this.nm_dQuantity_ValueChanged);
            // 
            // nm_PricePerUnit
            // 
            this.nm_PricePerUnit.DecimalPlaces = 2;
            this.nm_PricePerUnit.Location = new System.Drawing.Point(371, 4);
            this.nm_PricePerUnit.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_PricePerUnit.Name = "nm_PricePerUnit";
            this.nm_PricePerUnit.Size = new System.Drawing.Size(74, 20);
            this.nm_PricePerUnit.TabIndex = 18;
            this.nm_PricePerUnit.ValueChanged += new System.EventHandler(this.nm_PricePerUnit_ValueChanged);
            // 
            // lbl_PricePerUnit
            // 
            this.lbl_PricePerUnit.AutoSize = true;
            this.lbl_PricePerUnit.Location = new System.Drawing.Point(288, 8);
            this.lbl_PricePerUnit.Name = "lbl_PricePerUnit";
            this.lbl_PricePerUnit.Size = new System.Drawing.Size(77, 13);
            this.lbl_PricePerUnit.TabIndex = 22;
            this.lbl_PricePerUnit.Text = "Cena na enoto";
            // 
            // chk_Unit
            // 
            this.chk_Unit.Location = new System.Drawing.Point(3, 3);
            this.chk_Unit.Name = "chk_Unit";
            this.chk_Unit.Size = new System.Drawing.Size(91, 25);
            this.chk_Unit.TabIndex = 23;
            this.chk_Unit.Text = "Merska enota";
            this.chk_Unit.UseVisualStyleBackColor = true;
            // 
            // usrc_Edit_Item_Unit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chk_Unit);
            this.Controls.Add(this.lbl_PricePerUnit);
            this.Controls.Add(this.nm_PricePerUnit);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.nm_dQuantity);
            this.Controls.Add(this.cmb_Unit);
            this.Name = "usrc_Edit_Item_Unit";
            this.Size = new System.Drawing.Size(451, 30);
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Unit;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.NumericUpDown nm_dQuantity;
        private System.Windows.Forms.NumericUpDown nm_PricePerUnit;
        private System.Windows.Forms.Label lbl_PricePerUnit;
        private System.Windows.Forms.CheckBox chk_Unit;
    }
}
