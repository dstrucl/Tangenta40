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
            this.lbl_Item_Unit = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.nm_dQuantity = new System.Windows.Forms.NumericUpDown();
            this.nm_PricePerUnit = new System.Windows.Forms.NumericUpDown();
            this.btn_Edit_Units = new System.Windows.Forms.Button();
            this.lbl_PricePerUnit = new System.Windows.Forms.Label();
            this.chk_Unit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Unit
            // 
            this.cmb_Unit.FormattingEnabled = true;
            this.cmb_Unit.Location = new System.Drawing.Point(6, 52);
            this.cmb_Unit.Name = "cmb_Unit";
            this.cmb_Unit.Size = new System.Drawing.Size(96, 21);
            this.cmb_Unit.TabIndex = 5;
            // 
            // lbl_Item_Unit
            // 
            this.lbl_Item_Unit.AutoSize = true;
            this.lbl_Item_Unit.Location = new System.Drawing.Point(6, 37);
            this.lbl_Item_Unit.Name = "lbl_Item_Unit";
            this.lbl_Item_Unit.Size = new System.Drawing.Size(73, 13);
            this.lbl_Item_Unit.TabIndex = 4;
            this.lbl_Item_Unit.Text = "Merska Enota";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.AutoSize = true;
            this.lbl_Quantity.Location = new System.Drawing.Point(114, 38);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(44, 13);
            this.lbl_Quantity.TabIndex = 7;
            this.lbl_Quantity.Text = "Količina";
            // 
            // nm_dQuantity
            // 
            this.nm_dQuantity.Location = new System.Drawing.Point(116, 53);
            this.nm_dQuantity.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nm_dQuantity.Name = "nm_dQuantity";
            this.nm_dQuantity.Size = new System.Drawing.Size(97, 20);
            this.nm_dQuantity.TabIndex = 6;
            this.nm_dQuantity.ValueChanged += new System.EventHandler(this.nm_dQuantity_ValueChanged);
            // 
            // nm_PricePerUnit
            // 
            this.nm_PricePerUnit.DecimalPlaces = 2;
            this.nm_PricePerUnit.Location = new System.Drawing.Point(149, 17);
            this.nm_PricePerUnit.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nm_PricePerUnit.Name = "nm_PricePerUnit";
            this.nm_PricePerUnit.Size = new System.Drawing.Size(96, 20);
            this.nm_PricePerUnit.TabIndex = 18;
            this.nm_PricePerUnit.ValueChanged += new System.EventHandler(this.nm_PricePerUnit_ValueChanged);
            // 
            // btn_Edit_Units
            // 
            this.btn_Edit_Units.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Edit_Units.Image = global::ShopA.Properties.Resources.Edit;
            this.btn_Edit_Units.Location = new System.Drawing.Point(2, 1);
            this.btn_Edit_Units.Name = "btn_Edit_Units";
            this.btn_Edit_Units.Size = new System.Drawing.Size(37, 33);
            this.btn_Edit_Units.TabIndex = 19;
            this.btn_Edit_Units.UseVisualStyleBackColor = false;
            this.btn_Edit_Units.Click += new System.EventHandler(this.btn_Edit_Units_Click);
            // 
            // lbl_PricePerUnit
            // 
            this.lbl_PricePerUnit.AutoSize = true;
            this.lbl_PricePerUnit.Location = new System.Drawing.Point(148, 3);
            this.lbl_PricePerUnit.Name = "lbl_PricePerUnit";
            this.lbl_PricePerUnit.Size = new System.Drawing.Size(77, 13);
            this.lbl_PricePerUnit.TabIndex = 22;
            this.lbl_PricePerUnit.Text = "Cena na enoto";
            // 
            // chk_Unit
            // 
            this.chk_Unit.Location = new System.Drawing.Point(44, 2);
            this.chk_Unit.Name = "chk_Unit";
            this.chk_Unit.Size = new System.Drawing.Size(99, 19);
            this.chk_Unit.TabIndex = 23;
            this.chk_Unit.Text = "Merska enota";
            this.chk_Unit.UseVisualStyleBackColor = true;
            // 
            // usrc_Edit_Item_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chk_Unit);
            this.Controls.Add(this.lbl_PricePerUnit);
            this.Controls.Add(this.btn_Edit_Units);
            this.Controls.Add(this.nm_PricePerUnit);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.nm_dQuantity);
            this.Controls.Add(this.cmb_Unit);
            this.Controls.Add(this.lbl_Item_Unit);
            this.Name = "usrc_Edit_Item_Unit";
            this.Size = new System.Drawing.Size(252, 78);
            ((System.ComponentModel.ISupportInitialize)(this.nm_dQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_PricePerUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Unit;
        private System.Windows.Forms.Label lbl_Item_Unit;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.NumericUpDown nm_dQuantity;
        private System.Windows.Forms.NumericUpDown nm_PricePerUnit;
        private System.Windows.Forms.Button btn_Edit_Units;
        private System.Windows.Forms.Label lbl_PricePerUnit;
        private System.Windows.Forms.CheckBox chk_Unit;
    }
}
