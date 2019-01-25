namespace ShopC_Forms
{
    partial class usrc_CItem_Button
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
            this.lbl_Item = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Item.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(2, 3);
            this.lbl_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(96, 35);
            this.lbl_Item.TabIndex = 0;
            this.lbl_Item.Text = "label1";
            this.lbl_Item.Click += new System.EventHandler(this.lbl_Item_Click);
            // 
            // usrc_Item_Button
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.Controls.Add(this.lbl_Item);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Item_Button";
            this.Size = new System.Drawing.Size(100, 40);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lbl_Item;
    }
}
