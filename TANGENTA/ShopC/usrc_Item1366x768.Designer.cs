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
            this.lbl_Item_UniqueName = new System.Windows.Forms.Label();
            this.lbl_InStock = new System.Windows.Forms.Label();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Item_UniqueName
            // 
            this.lbl_Item_UniqueName.AutoEllipsis = true;
            this.lbl_Item_UniqueName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_Item_UniqueName.Location = new System.Drawing.Point(3, 3);
            this.lbl_Item_UniqueName.Name = "lbl_Item_UniqueName";
            this.lbl_Item_UniqueName.Size = new System.Drawing.Size(100, 28);
            this.lbl_Item_UniqueName.TabIndex = 0;
            this.lbl_Item_UniqueName.Text = "label1";
            this.lbl_Item_UniqueName.Click += new System.EventHandler(this.lbl_Item_Click_1);
            // 
            // lbl_InStock
            // 
            this.lbl_InStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_InStock.Location = new System.Drawing.Point(1, 46);
            this.lbl_InStock.Name = "lbl_InStock";
            this.lbl_InStock.Size = new System.Drawing.Size(103, 14);
            this.lbl_InStock.TabIndex = 1;
            this.lbl_InStock.Text = "Stock:";
            // 
            // lbl_Price
            // 
            this.lbl_Price.Location = new System.Drawing.Point(1, 31);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(71, 14);
            this.lbl_Price.TabIndex = 2;
            this.lbl_Price.Text = "Price";
            // 
            // usrc_Item1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.lbl_InStock);
            this.Controls.Add(this.lbl_Item_UniqueName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item1366x768";
            this.Size = new System.Drawing.Size(106, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_UniqueName;
        private System.Windows.Forms.Label lbl_InStock;
        private System.Windows.Forms.Label lbl_Price;
    }
}
