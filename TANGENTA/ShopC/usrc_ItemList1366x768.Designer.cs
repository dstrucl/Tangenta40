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
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.usrc_Item_TextSearch1 = new ShopC.usrc_Item_TextSearch();
            this.usrc_Item_InsidePageGroupHandler1 = new usrc_Item_Group_Handler.usrc_Item_InsidePageGroupHandler();
            this.SuspendLayout();
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_GroupPath.Location = new System.Drawing.Point(13, 12);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(60, 13);
            this.lbl_GroupPath.TabIndex = 11;
            this.lbl_GroupPath.Text = "Group path";
            // 
            // usrc_Item_TextSearch1
            // 
            this.usrc_Item_TextSearch1.BackColor = System.Drawing.Color.RosyBrown;
            this.usrc_Item_TextSearch1.Location = new System.Drawing.Point(79, -1);
            this.usrc_Item_TextSearch1.Name = "usrc_Item_TextSearch1";
            this.usrc_Item_TextSearch1.Size = new System.Drawing.Size(567, 37);
            this.usrc_Item_TextSearch1.TabIndex = 16;
            // 
            // usrc_Item_InsidePageGroupHandler1
            // 
            this.usrc_Item_InsidePageGroupHandler1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsidePageGroupHandler1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item_InsidePageGroupHandler1.Location = new System.Drawing.Point(3, 38);
            this.usrc_Item_InsidePageGroupHandler1.Name = "usrc_Item_InsidePageGroupHandler1";
            this.usrc_Item_InsidePageGroupHandler1.Size = new System.Drawing.Size(640, 300);
            this.usrc_Item_InsidePageGroupHandler1.TabIndex = 17;
            // 
            // usrc_ItemList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.usrc_Item_InsidePageGroupHandler1);
            this.Controls.Add(this.usrc_Item_TextSearch1);
            this.Controls.Add(this.lbl_GroupPath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList1366x768";
            this.Size = new System.Drawing.Size(646, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private usrc_Item_PageHandler.usrc_Item_PageHandler m_usrc_Item_PageHandler;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler m_usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
        private usrc_Item1366x768 usrc_Item1366x7681;
        private usrc_Item1366x768_Button usrc_Item1366x768_Button1;
        private usrc_Item_TextSearch usrc_Item_TextSearch1;
        private usrc_Item_Group_Handler.usrc_Item_InsidePageGroupHandler usrc_Item_InsidePageGroupHandler1;
    }
}
