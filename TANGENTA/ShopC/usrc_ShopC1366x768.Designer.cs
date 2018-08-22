namespace ShopC
{
    partial class usrc_ShopC1366x768
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
            this.lbl_ShopC_Name = new System.Windows.Forms.Label();
            this.usrc_ItemList1366x7681 = new ShopC.usrc_ItemList1366x768();
            this.usrc_Atom_ItemsList1366x768 = new ShopC.usrc_Atom_ItemsList1366x768();
            this.SuspendLayout();
            // 
            // lbl_ShopC_Name
            // 
            this.lbl_ShopC_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ShopC_Name.Location = new System.Drawing.Point(2, 3);
            this.lbl_ShopC_Name.Name = "lbl_ShopC_Name";
            this.lbl_ShopC_Name.Size = new System.Drawing.Size(142, 13);
            this.lbl_ShopC_Name.TabIndex = 4;
            this.lbl_ShopC_Name.Text = "Shop C";
            // 
            // usrc_ItemList1366x7681
            // 
            this.usrc_ItemList1366x7681.BackColor = System.Drawing.Color.YellowGreen;
            this.usrc_ItemList1366x7681.DocTyp = "";
            this.usrc_ItemList1366x7681.ExclusivelySellFromStock = false;
            this.usrc_ItemList1366x7681.Location = new System.Drawing.Point(360, 0);
            this.usrc_ItemList1366x7681.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_ItemList1366x7681.Name = "usrc_ItemList1366x7681";
            this.usrc_ItemList1366x7681.NumberOfItemsPerPage = 10;
            this.usrc_ItemList1366x7681.Size = new System.Drawing.Size(646, 280);
            this.usrc_ItemList1366x7681.TabIndex = 24;
            // 
            // usrc_Atom_ItemsList1366x768
            // 
            this.usrc_Atom_ItemsList1366x768.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Atom_ItemsList1366x768.DocTyp = "";
            this.usrc_Atom_ItemsList1366x768.Location = new System.Drawing.Point(0, 19);
            this.usrc_Atom_ItemsList1366x768.Margin = new System.Windows.Forms.Padding(5);
            this.usrc_Atom_ItemsList1366x768.Name = "usrc_Atom_ItemsList1366x768";
            this.usrc_Atom_ItemsList1366x768.NumberOfItemsPerPage = 10;
            this.usrc_Atom_ItemsList1366x768.Size = new System.Drawing.Size(360, 258);
            this.usrc_Atom_ItemsList1366x768.TabIndex = 5;
            // 
            // usrc_ShopC1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.usrc_ItemList1366x7681);
            this.Controls.Add(this.usrc_Atom_ItemsList1366x768);
            this.Controls.Add(this.lbl_ShopC_Name);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ShopC1366x768";
            this.Size = new System.Drawing.Size(1006, 280);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_ShopC_Name;
        public usrc_Atom_ItemsList1366x768 usrc_Atom_ItemsList1366x768;
        public usrc_ItemList1366x768 usrc_ItemList1366x768;
        private usrc_ItemList1366x768 usrc_ItemList1366x7681;
    }
}
