namespace ShopC
{
    partial class usrc_btn_Item
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
            this.btn_Item = new System.Windows.Forms.Button();
            this.usrc_NumericUpDown21 = new DynEditControls.usrc_NumericUpDown2();
            this.SuspendLayout();
            // 
            // btn_Item
            // 
            this.btn_Item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Item.Location = new System.Drawing.Point(0, 0);
            this.btn_Item.Name = "btn_Item";
            this.btn_Item.Size = new System.Drawing.Size(66, 72);
            this.btn_Item.TabIndex = 1;
            this.btn_Item.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Item.UseVisualStyleBackColor = true;
            this.btn_Item.Click += new System.EventHandler(this.btn_Item_Click);
            // 
            // usrc_NumericUpDown21
            // 
            this.usrc_NumericUpDown21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NumericUpDown21.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_NumericUpDown21.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.usrc_NumericUpDown21.DecimalPlaces = 2;
            this.usrc_NumericUpDown21.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.usrc_NumericUpDown21.Label1 = "Price:";
            this.usrc_NumericUpDown21.Label2 = "Price:";
            this.usrc_NumericUpDown21.Label3 = "Quantity";
            this.usrc_NumericUpDown21.Label4 = "Price:";
            this.usrc_NumericUpDown21.Label5 = "Price:";
            this.usrc_NumericUpDown21.Location = new System.Drawing.Point(66, 1);
            this.usrc_NumericUpDown21.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.usrc_NumericUpDown21.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_NumericUpDown21.Name = "usrc_NumericUpDown21";
            this.usrc_NumericUpDown21.ReadOnly = false;
            this.usrc_NumericUpDown21.Size = new System.Drawing.Size(213, 70);
            this.usrc_NumericUpDown21.TabIndex = 2;
            this.usrc_NumericUpDown21.Type = DynEditControls.usrc_NumericUpDown2.eType.INTEGER;
            this.usrc_NumericUpDown21.Unit = "";
            this.usrc_NumericUpDown21.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_NumericUpDown21.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.usrc_NumericUpDown21.ValueChanged += new System.EventHandler(this.usrc_NumericUpDown21_ValueChanged);
            // 
            // usrc_btn_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.usrc_NumericUpDown21);
            this.Controls.Add(this.btn_Item);
            this.Name = "usrc_btn_Item";
            this.Size = new System.Drawing.Size(280, 73);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Item;
        private DynEditControls.usrc_NumericUpDown2 usrc_NumericUpDown21;
    }
}
