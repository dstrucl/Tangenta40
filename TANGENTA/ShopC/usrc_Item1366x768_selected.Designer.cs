namespace ShopC
{
    partial class usrc_Item1366x768_selected
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
            this.components = new System.ComponentModel.Container();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.lbl_bypass_Stock = new System.Windows.Forms.Label();
            this.lbl_from_Stock = new System.Windows.Forms.Label();
            this.lbl_VAT = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pic_Item = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(4, 2);
            this.lbl_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(402, 19);
            this.lbl_Item.TabIndex = 0;
            this.lbl_Item.Text = "label1";
            this.lbl_Item.Click += new System.EventHandler(this.Controls_Click);
            // 
            // lbl_bypass_Stock
            // 
            this.lbl_bypass_Stock.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_bypass_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_bypass_Stock.Location = new System.Drawing.Point(4, 41);
            this.lbl_bypass_Stock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_bypass_Stock.Name = "lbl_bypass_Stock";
            this.lbl_bypass_Stock.Size = new System.Drawing.Size(250, 19);
            this.lbl_bypass_Stock.TabIndex = 14;
            this.lbl_bypass_Stock.Text = "bypass Stock";
            this.lbl_bypass_Stock.Click += new System.EventHandler(this.Controls_Click);
            // 
            // lbl_from_Stock
            // 
            this.lbl_from_Stock.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_from_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_from_Stock.Location = new System.Drawing.Point(4, 22);
            this.lbl_from_Stock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_from_Stock.Name = "lbl_from_Stock";
            this.lbl_from_Stock.Size = new System.Drawing.Size(250, 19);
            this.lbl_from_Stock.TabIndex = 15;
            this.lbl_from_Stock.Text = "from Stock:";
            this.lbl_from_Stock.Click += new System.EventHandler(this.Controls_Click);
            // 
            // lbl_VAT
            // 
            this.lbl_VAT.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_VAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_VAT.Location = new System.Drawing.Point(4, 60);
            this.lbl_VAT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_VAT.Name = "lbl_VAT";
            this.lbl_VAT.Size = new System.Drawing.Size(250, 19);
            this.lbl_VAT.TabIndex = 16;
            this.lbl_VAT.Text = "Taxation";
            this.lbl_VAT.Click += new System.EventHandler(this.Controls_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pic_Item
            // 
            this.pic_Item.Location = new System.Drawing.Point(255, 23);
            this.pic_Item.Name = "pic_Item";
            this.pic_Item.Size = new System.Drawing.Size(150, 59);
            this.pic_Item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Item.TabIndex = 17;
            this.pic_Item.TabStop = false;
            this.pic_Item.Click += new System.EventHandler(this.Controls_Click);
            // 
            // usrc_Item1366x768_selected
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pic_Item);
            this.Controls.Add(this.lbl_VAT);
            this.Controls.Add(this.lbl_from_Stock);
            this.Controls.Add(this.lbl_bypass_Stock);
            this.Controls.Add(this.lbl_Item);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item1366x768_selected";
            this.Size = new System.Drawing.Size(410, 84);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.usrc_Item1366x768_selected_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lbl_Item;
        internal System.Windows.Forms.Label lbl_bypass_Stock;
        internal System.Windows.Forms.Label lbl_from_Stock;
        internal System.Windows.Forms.Label lbl_VAT;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.PictureBox pic_Item;
    }
}
