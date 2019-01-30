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
            this.m_usrc_ItemList1366x768 = new ShopC.usrc_ItemList1366x768();
            this.m_usrc_Atom_ItemsList1366x768 = new ShopC.usrc_Atom_ItemsList1366x768();
            this.m_usrc_PriceList1 = new PriseLists.usrc_PriceList();
            this.SuspendLayout();
            // 
            // lbl_ShopC_Name
            // 
            this.lbl_ShopC_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ShopC_Name.Location = new System.Drawing.Point(1, 3);
            this.lbl_ShopC_Name.Name = "lbl_ShopC_Name";
            this.lbl_ShopC_Name.Size = new System.Drawing.Size(96, 22);
            this.lbl_ShopC_Name.TabIndex = 4;
            this.lbl_ShopC_Name.Text = "Shop C";
            // 
            // m_usrc_ItemList1366x768
            // 
            this.m_usrc_ItemList1366x768.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_ItemList1366x768.BackColor = System.Drawing.Color.YellowGreen;
            this.m_usrc_ItemList1366x768.ExclusivelySellFromStock = false;
            this.m_usrc_ItemList1366x768.Location = new System.Drawing.Point(360, 0);
            this.m_usrc_ItemList1366x768.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_ItemList1366x768.Name = "m_usrc_ItemList1366x768";
            this.m_usrc_ItemList1366x768.NumberOfItemsPerPage = 10;
            this.m_usrc_ItemList1366x768.Size = new System.Drawing.Size(646, 280);
            this.m_usrc_ItemList1366x768.TabIndex = 24;
            this.m_usrc_ItemList1366x768.Stock_Click += new ShopC.usrc_ItemList1366x768.delegate_Stock_Click(this.m_usrc_ItemList1366x768_Stock_Click);
            this.m_usrc_ItemList1366x768.Consumption_Click += new ShopC.usrc_ItemList1366x768.delegate_Consumption_Click(this.m_usrc_ItemList1366x768_Consumption_Click);
            this.m_usrc_ItemList1366x768.Items_Click += new ShopC.usrc_ItemList1366x768.delegate_Items_Click(this.m_usrc_ItemList1366x768_Items_Click);
            // 
            // m_usrc_Atom_ItemsList1366x768
            // 
            this.m_usrc_Atom_ItemsList1366x768.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Atom_ItemsList1366x768.Location = new System.Drawing.Point(0, 32);
            this.m_usrc_Atom_ItemsList1366x768.Margin = new System.Windows.Forms.Padding(5);
            this.m_usrc_Atom_ItemsList1366x768.Name = "m_usrc_Atom_ItemsList1366x768";
            this.m_usrc_Atom_ItemsList1366x768.NumberOfItemsPerPage = 10;
            this.m_usrc_Atom_ItemsList1366x768.Size = new System.Drawing.Size(360, 244);
            this.m_usrc_Atom_ItemsList1366x768.TabIndex = 5;
            // 
            // m_usrc_PriceList1
            // 
            this.m_usrc_PriceList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_usrc_PriceList1.Location = new System.Drawing.Point(55, 0);
            this.m_usrc_PriceList1.Name = "m_usrc_PriceList1";
            this.m_usrc_PriceList1.Size = new System.Drawing.Size(305, 24);
            this.m_usrc_PriceList1.TabIndex = 25;
            this.m_usrc_PriceList1.PriceListChanged += new PriseLists.usrc_PriceList.delegate_PriceListChanged(this.usrc_PriceList1_PriceListChanged);
            // 
            // usrc_ShopC1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.m_usrc_PriceList1);
            this.Controls.Add(this.m_usrc_ItemList1366x768);
            this.Controls.Add(this.m_usrc_Atom_ItemsList1366x768);
            this.Controls.Add(this.lbl_ShopC_Name);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ShopC1366x768";
            this.Size = new System.Drawing.Size(1006, 280);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_ShopC_Name;
        public usrc_Atom_ItemsList1366x768 m_usrc_Atom_ItemsList1366x768;
        public usrc_ItemList1366x768 m_usrc_ItemList1366x768;
        public PriseLists.usrc_PriceList m_usrc_PriceList1;
    }
}
