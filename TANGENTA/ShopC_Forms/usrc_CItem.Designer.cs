namespace ShopC_Forms
{
    partial class usrc_CItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_CItem));
            this.lbl_Item_UniqueName = new System.Windows.Forms.Label();
            this.lbl_InStock = new System.Windows.Forms.Label();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.picInBasket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item_UniqueName
            // 
            this.lbl_Item_UniqueName.AutoEllipsis = true;
            this.lbl_Item_UniqueName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl_Item_UniqueName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_Item_UniqueName.Location = new System.Drawing.Point(3, 4);
            this.lbl_Item_UniqueName.Name = "lbl_Item_UniqueName";
            this.lbl_Item_UniqueName.Size = new System.Drawing.Size(99, 25);
            this.lbl_Item_UniqueName.TabIndex = 0;
            this.lbl_Item_UniqueName.Text = "label1";
            this.lbl_Item_UniqueName.Click += new System.EventHandler(this.lbl_Item_UniqueName_Click);
            // 
            // lbl_InStock
            // 
            this.lbl_InStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_InStock.Location = new System.Drawing.Point(2, 44);
            this.lbl_InStock.Name = "lbl_InStock";
            this.lbl_InStock.Size = new System.Drawing.Size(99, 13);
            this.lbl_InStock.TabIndex = 1;
            this.lbl_InStock.Text = "Stock:";
            this.lbl_InStock.Click += new System.EventHandler(this.lbl_InStock_Click);
            // 
            // lbl_Price
            // 
            this.lbl_Price.Location = new System.Drawing.Point(1, 31);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(74, 12);
            this.lbl_Price.TabIndex = 2;
            this.lbl_Price.Text = "Price";
            this.lbl_Price.Click += new System.EventHandler(this.lbl_Price_Click);
            // 
            // picInBasket
            // 
            this.picInBasket.Image = ((System.Drawing.Image)(resources.GetObject("picInBasket.Image")));
            this.picInBasket.Location = new System.Drawing.Point(77, 28);
            this.picInBasket.Name = "picInBasket";
            this.picInBasket.Size = new System.Drawing.Size(26, 18);
            this.picInBasket.TabIndex = 3;
            this.picInBasket.TabStop = false;
            this.picInBasket.Visible = false;
            this.picInBasket.Click += new System.EventHandler(this.picInBasket_Click);
            // 
            // usrc_Item1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picInBasket);
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.lbl_InStock);
            this.Controls.Add(this.lbl_Item_UniqueName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item1366x768";
            this.Size = new System.Drawing.Size(106, 60);
            ((System.ComponentModel.ISupportInitialize)(this.picInBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_UniqueName;
        private System.Windows.Forms.Label lbl_InStock;
        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.PictureBox picInBasket;
    }
}
