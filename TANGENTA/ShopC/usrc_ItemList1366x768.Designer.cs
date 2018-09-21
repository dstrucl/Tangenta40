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
            this.usrc_Item_TextSearch1 = new ShopC.usrc_Item_TextSearch();
            this.usrc_Item_InsidePageGroupHandler1 = new usrc_Item_InsidePageGroup_Handler.usrc_Item_InsidePageGroupHandler();
            this.SuspendLayout();
            // 
            // usrc_Item_TextSearch1
            // 
            this.usrc_Item_TextSearch1.BackColor = System.Drawing.Color.RosyBrown;
            this.usrc_Item_TextSearch1.Location = new System.Drawing.Point(3, 0);
            this.usrc_Item_TextSearch1.Name = "usrc_Item_TextSearch1";
            this.usrc_Item_TextSearch1.Size = new System.Drawing.Size(640, 37);
            this.usrc_Item_TextSearch1.TabIndex = 16;
            // 
            // usrc_Item_InsidePageGroupHandler1
            // 
            this.usrc_Item_InsidePageGroupHandler1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsidePageGroupHandler1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item_InsidePageGroupHandler1.CtrlHeightInGroupBox = 40;
            this.usrc_Item_InsidePageGroupHandler1.CtrlHeightInPage = 60;
            this.usrc_Item_InsidePageGroupHandler1.CtrlWidthInGroupBox = 100;
            this.usrc_Item_InsidePageGroupHandler1.CtrlWidthInPage = 106;
            this.usrc_Item_InsidePageGroupHandler1.Location = new System.Drawing.Point(3, 36);
            this.usrc_Item_InsidePageGroupHandler1.Name = "usrc_Item_InsidePageGroupHandler1";
            this.usrc_Item_InsidePageGroupHandler1.Size = new System.Drawing.Size(640, 300);
            this.usrc_Item_InsidePageGroupHandler1.TabIndex = 17;
            this.usrc_Item_InsidePageGroupHandler1.InsidePageHandler_CompareWithString += new usrc_Item_InsidePageGroup_Handler.usrc_Item_InsidePageGroupHandler.deleagte_InsidePageHandler_CompareWithString(this.usrc_Item_InsidePageGroupHandler1_InsidePageHandler_CompareWithString);
            // 
            // usrc_ItemList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.usrc_Item_InsidePageGroupHandler1);
            this.Controls.Add(this.usrc_Item_TextSearch1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList1366x768";
            this.Size = new System.Drawing.Size(646, 340);
            this.ResumeLayout(false);

        }

        #endregion
        private usrc_Item_TextSearch usrc_Item_TextSearch1;
        private usrc_Item_InsidePageGroup_Handler.usrc_Item_InsidePageGroupHandler usrc_Item_InsidePageGroupHandler1;
    }
}
