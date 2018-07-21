namespace LoginControl
{
    partial class usrc_MultipleUsers
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_Items = new System.Windows.Forms.Panel();
            this.usrc_Item_Group_Handler1 = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.usrc_Item_PageHandler1 = new usrc_Item_PageHandler.usrc_Item_PageHandler();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_Items);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Item_Group_Handler1);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 721);
            this.splitContainer1.SplitterDistance = 802;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnl_Items
            // 
            this.pnl_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Items.Location = new System.Drawing.Point(0, 0);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(802, 721);
            this.pnl_Items.TabIndex = 0;
            // 
            // usrc_Item_Group_Handler1
            // 
            this.usrc_Item_Group_Handler1.Button_Height = 32;
            this.usrc_Item_Group_Handler1.Font_Height = 10;
            this.usrc_Item_Group_Handler1.Location = new System.Drawing.Point(3, 3);
            this.usrc_Item_Group_Handler1.Name = "usrc_Item_Group_Handler1";
            this.usrc_Item_Group_Handler1.ShopName = "";
            this.usrc_Item_Group_Handler1.Size = new System.Drawing.Size(213, 715);
            this.usrc_Item_Group_Handler1.TabIndex = 0;
            // 
            // usrc_Item_PageHandler1
            // 
            this.usrc_Item_PageHandler1.CurrentPage = 0;
            this.usrc_Item_PageHandler1.Location = new System.Drawing.Point(15, 14);
            this.usrc_Item_PageHandler1.Name = "usrc_Item_PageHandler1";
            this.usrc_Item_PageHandler1.Size = new System.Drawing.Size(151, 37);
            this.usrc_Item_PageHandler1.TabIndex = 1;
            this.usrc_Item_PageHandler1.ShowObject += new usrc_Item_PageHandler.usrc_Item_PageHandler.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // usrc_MultipleUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usrc_Item_PageHandler1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_MultipleUsers";
            this.Size = new System.Drawing.Size(1028, 781);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler usrc_Item_Group_Handler1;
        private usrc_Item_PageHandler.usrc_Item_PageHandler usrc_Item_PageHandler1;
        private System.Windows.Forms.Panel pnl_Items;
    }
}
