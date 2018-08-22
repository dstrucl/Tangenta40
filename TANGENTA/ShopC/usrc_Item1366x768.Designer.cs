namespace ShopC
{
    partial class usrc_Item1366x768
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chk_FromStock = new System.Windows.Forms.CheckBox();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.uItemStock = new DynEditControls.usrc_NumericUpDown2();
            this.SuspendLayout();
            // 
            // chk_FromStock
            // 
            this.chk_FromStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_FromStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chk_FromStock.Location = new System.Drawing.Point(215, 3);
            this.chk_FromStock.Name = "chk_FromStock";
            this.chk_FromStock.Size = new System.Drawing.Size(63, 94);
            this.chk_FromStock.TabIndex = 14;
            this.chk_FromStock.Text = "From Stock";
            this.chk_FromStock.UseVisualStyleBackColor = false;
            // 
            // btn_Discount
            // 
            this.btn_Discount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = global::ShopC.Properties.Resources.Discount;
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(285, 4);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(47, 93);
            this.btn_Discount.TabIndex = 12;
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // uItemStock
            // 
            this.uItemStock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.uItemStock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.uItemStock.DecimalPlaces = 2;
            this.uItemStock.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uItemStock.Label1 = "Price:";
            this.uItemStock.Label2 = "Price:";
            this.uItemStock.Label3 = "Quantity";
            this.uItemStock.Label4 = "Price:";
            this.uItemStock.Label5 = "Price:";
            this.uItemStock.Location = new System.Drawing.Point(3, 3);
            this.uItemStock.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.uItemStock.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemStock.Name = "uItemStock";
            this.uItemStock.ReadOnly = false;
            this.uItemStock.Size = new System.Drawing.Size(215, 94);
            this.uItemStock.TabIndex = 15;
            this.uItemStock.Type = DynEditControls.usrc_NumericUpDown2.eType.INTEGER;
            this.uItemStock.Unit = "";
            this.uItemStock.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uItemStock.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // usrc_Item1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.uItemStock);
            this.Controls.Add(this.chk_FromStock);
            this.Controls.Add(this.btn_Discount);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item1366x768";
            this.Size = new System.Drawing.Size(335, 100);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Discount;
        private System.Windows.Forms.CheckBox chk_FromStock;
        private DynEditControls.usrc_NumericUpDown2 uItemStock;
    }
}
