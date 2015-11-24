namespace Tangenta
{
    partial class usrc_Atom_ItemsList
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
            this.m_usrc_Item_PageHandler = new usrc_Item_PageHandler.usrc_Item_PageHandler();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.pnl_Atom_Items = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_usrc_Item_PageHandler
            // 
            this.m_usrc_Item_PageHandler.CurrentPage = 0;
            this.m_usrc_Item_PageHandler.Location = new System.Drawing.Point(3, 1);
            this.m_usrc_Item_PageHandler.Name = "m_usrc_Item_PageHandler";
            this.m_usrc_Item_PageHandler.Size = new System.Drawing.Size(216, 38);
            this.m_usrc_Item_PageHandler.TabIndex = 9;
            this.m_usrc_Item_PageHandler.ShowObject += new usrc_Item_PageHandler.usrc_Item_PageHandler.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearAll.Image = global::Tangenta.Properties.Resources.RemoveAll;
            this.btn_ClearAll.Location = new System.Drawing.Point(421, -1);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(54, 41);
            this.btn_ClearAll.TabIndex = 10;
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Visible = false;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // pnl_Atom_Items
            // 
            this.pnl_Atom_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Atom_Items.AutoScroll = true;
            this.pnl_Atom_Items.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.pnl_Atom_Items.BackColor = System.Drawing.Color.GhostWhite;
            this.pnl_Atom_Items.BackgroundImage = global::Tangenta.Properties.Resources.Shopping_Basket;
            this.pnl_Atom_Items.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnl_Atom_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Atom_Items.Location = new System.Drawing.Point(0, 41);
            this.pnl_Atom_Items.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Atom_Items.Name = "pnl_Atom_Items";
            this.pnl_Atom_Items.Size = new System.Drawing.Size(476, 259);
            this.pnl_Atom_Items.TabIndex = 8;
            // 
            // usrc_Atom_ItemsList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_ClearAll);
            this.Controls.Add(this.m_usrc_Item_PageHandler);
            this.Controls.Add(this.pnl_Atom_Items);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Atom_ItemsList";
            this.Size = new System.Drawing.Size(476, 297);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Atom_Items;
        private usrc_Item_PageHandler.usrc_Item_PageHandler m_usrc_Item_PageHandler;
        private System.Windows.Forms.Button btn_ClearAll;

    }
}
