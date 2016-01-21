namespace ShopC
{
    partial class usrc_ItemList
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
            this.pnl_Items = new System.Windows.Forms.Panel();
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_usrc_Item_Group_Handler = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.m_usrc_Item_PageHandler = new usrc_Item_PageHandler.usrc_Item_PageHandler();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Items
            // 
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnl_Items.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.pnl_Items.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Items.Location = new System.Drawing.Point(0, 0);
            this.pnl_Items.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(468, 350);
            this.pnl_Items.TabIndex = 7;
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_GroupPath.Location = new System.Drawing.Point(347, 15);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(60, 13);
            this.lbl_GroupPath.TabIndex = 11;
            this.lbl_GroupPath.Text = "Group path";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(3, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_Items);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_usrc_Item_Group_Handler);
            this.splitContainer1.Size = new System.Drawing.Size(650, 350);
            this.splitContainer1.SplitterDistance = 468;
            this.splitContainer1.TabIndex = 13;
            // 
            // m_usrc_Item_Group_Handler
            // 
            this.m_usrc_Item_Group_Handler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Item_Group_Handler.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Item_Group_Handler.Name = "m_usrc_Item_Group_Handler";
            this.m_usrc_Item_Group_Handler.Size = new System.Drawing.Size(178, 350);
            this.m_usrc_Item_Group_Handler.TabIndex = 10;
            this.m_usrc_Item_Group_Handler.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.m_usrc_Item_Group_Handler_GroupsRedefined);
            this.m_usrc_Item_Group_Handler.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.m_usrc_Item_Group_Handler_GroupChanged);
            // 
            // m_usrc_Item_PageHandler
            // 
            this.m_usrc_Item_PageHandler.CurrentPage = 0;
            this.m_usrc_Item_PageHandler.Location = new System.Drawing.Point(3, 0);
            this.m_usrc_Item_PageHandler.Name = "m_usrc_Item_PageHandler";
            this.m_usrc_Item_PageHandler.Size = new System.Drawing.Size(164, 39);
            this.m_usrc_Item_PageHandler.TabIndex = 9;
            this.m_usrc_Item_PageHandler.ShowObject += new usrc_Item_PageHandler.usrc_Item_PageHandler.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // usrc_ItemList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.m_usrc_Item_PageHandler);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList";
            this.Size = new System.Drawing.Size(656, 393);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Items;
        private usrc_Item_PageHandler.usrc_Item_PageHandler m_usrc_Item_PageHandler;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler m_usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
