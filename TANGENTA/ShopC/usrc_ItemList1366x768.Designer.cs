namespace ShopC
{
    partial class usrc_ItemList1366x768
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
            this.m_usrc_Item_Group_Handler = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.m_usrc_Item_PageHandler = new usrc_Item_PageHandler.usrc_Item_PageHandler();
            this.SuspendLayout();
            // 
            // pnl_Items
            // 
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnl_Items.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.pnl_Items.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Items.Location = new System.Drawing.Point(4, 57);
            this.pnl_Items.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(509, 336);
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
            // m_usrc_Item_Group_Handler
            // 
            this.m_usrc_Item_Group_Handler.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_usrc_Item_Group_Handler.Button_Height = 48;
            this.m_usrc_Item_Group_Handler.Font_Height = 10;
            this.m_usrc_Item_Group_Handler.Location = new System.Drawing.Point(520, 57);
            this.m_usrc_Item_Group_Handler.Name = "m_usrc_Item_Group_Handler";
            this.m_usrc_Item_Group_Handler.ShopName = "";
            this.m_usrc_Item_Group_Handler.Size = new System.Drawing.Size(121, 336);
            this.m_usrc_Item_Group_Handler.TabIndex = 10;
            this.m_usrc_Item_Group_Handler.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.m_usrc_Item_Group_Handler_GroupsRedefined);
            this.m_usrc_Item_Group_Handler.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.m_usrc_Item_Group_Handler_GroupChanged);
            // 
            // m_usrc_Item_PageHandler
            // 
            this.m_usrc_Item_PageHandler.CurrentPage = 0;
            this.m_usrc_Item_PageHandler.Location = new System.Drawing.Point(3, 0);
            this.m_usrc_Item_PageHandler.Name = "m_usrc_Item_PageHandler";
            this.m_usrc_Item_PageHandler.Size = new System.Drawing.Size(187, 56);
            this.m_usrc_Item_PageHandler.TabIndex = 9;
            this.m_usrc_Item_PageHandler.ShowObject += new usrc_Item_PageHandler.usrc_Item_PageHandler.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // usrc_ItemList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnl_Items);
            this.Controls.Add(this.m_usrc_Item_Group_Handler);
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.m_usrc_Item_PageHandler);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList1366x768";
            this.Size = new System.Drawing.Size(656, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Items;
        private usrc_Item_PageHandler.usrc_Item_PageHandler m_usrc_Item_PageHandler;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler m_usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
    }
}
