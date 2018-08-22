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
            this.usrc_Item_Group_Handler1 = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.usrc_Item1366x768_Button2 = new ShopC.usrc_Item1366x768_Button();
            this.usrc_Item_TextSearch1 = new ShopC.usrc_Item_TextSearch();
            this.pnl_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Items
            // 
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnl_Items.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.pnl_Items.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Items.Controls.Add(this.usrc_Item1366x768_Button2);
            this.pnl_Items.Location = new System.Drawing.Point(-1, 1);
            this.pnl_Items.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(646, 120);
            this.pnl_Items.TabIndex = 7;
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_GroupPath.Location = new System.Drawing.Point(3, 133);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(60, 13);
            this.lbl_GroupPath.TabIndex = 11;
            this.lbl_GroupPath.Text = "Group path";
            // 
            // usrc_Item_Group_Handler1
            // 
            this.usrc_Item_Group_Handler1.BackColor = System.Drawing.Color.Khaki;
            this.usrc_Item_Group_Handler1.Button_Height = 48;
            this.usrc_Item_Group_Handler1.Font_Height = 10;
            this.usrc_Item_Group_Handler1.Location = new System.Drawing.Point(0, 160);
            this.usrc_Item_Group_Handler1.Name = "usrc_Item_Group_Handler1";
            this.usrc_Item_Group_Handler1.ShopName = "";
            this.usrc_Item_Group_Handler1.Size = new System.Drawing.Size(646, 120);
            this.usrc_Item_Group_Handler1.TabIndex = 15;
            // 
            // usrc_Item1366x768_Button2
            // 
            this.usrc_Item1366x768_Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.usrc_Item1366x768_Button2.ExclusivelySellFromStock = false;
            this.usrc_Item1366x768_Button2.Location = new System.Drawing.Point(0, 0);
            this.usrc_Item1366x768_Button2.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Item1366x768_Button2.Name = "usrc_Item1366x768_Button2";
            this.usrc_Item1366x768_Button2.Size = new System.Drawing.Size(100, 40);
            this.usrc_Item1366x768_Button2.TabIndex = 0;
            // 
            // usrc_Item_TextSearch1
            // 
            this.usrc_Item_TextSearch1.BackColor = System.Drawing.Color.RosyBrown;
            this.usrc_Item_TextSearch1.Location = new System.Drawing.Point(200, 120);
            this.usrc_Item_TextSearch1.Name = "usrc_Item_TextSearch1";
            this.usrc_Item_TextSearch1.Size = new System.Drawing.Size(446, 40);
            this.usrc_Item_TextSearch1.TabIndex = 16;
            // 
            // usrc_ItemList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.usrc_Item_TextSearch1);
            this.Controls.Add(this.usrc_Item_Group_Handler1);
            this.Controls.Add(this.pnl_Items);
            this.Controls.Add(this.lbl_GroupPath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList1366x768";
            this.Size = new System.Drawing.Size(646, 280);
            this.pnl_Items.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Items;
        private usrc_Item_PageHandler.usrc_Item_PageHandler m_usrc_Item_PageHandler;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler m_usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
        private usrc_Item1366x768 usrc_Item1366x7681;
        private usrc_Item1366x768_Button usrc_Item1366x768_Button1;
        private usrc_Item1366x768_Button usrc_Item1366x768_Button2;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler usrc_Item_Group_Handler1;
        private usrc_Item_TextSearch usrc_Item_TextSearch1;
    }
}
