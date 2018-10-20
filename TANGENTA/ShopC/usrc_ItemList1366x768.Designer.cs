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
            this.btn_Stock = new System.Windows.Forms.Button();
            this.btn_Items = new System.Windows.Forms.Button();
            this.chk_SelectFromStock = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // usrc_Item_TextSearch1
            // 
            this.usrc_Item_TextSearch1.BackColor = System.Drawing.Color.RosyBrown;
            this.usrc_Item_TextSearch1.Location = new System.Drawing.Point(3, 0);
            this.usrc_Item_TextSearch1.Name = "usrc_Item_TextSearch1";
            this.usrc_Item_TextSearch1.Size = new System.Drawing.Size(380, 37);
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
            // btn_Stock
            // 
            this.btn_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Stock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Stock.Image = global::ShopC.Properties.Resources.Edit;
            this.btn_Stock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Stock.Location = new System.Drawing.Point(499, 1);
            this.btn_Stock.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Stock.Name = "btn_Stock";
            this.btn_Stock.Size = new System.Drawing.Size(73, 32);
            this.btn_Stock.TabIndex = 23;
            this.btn_Stock.Text = "Stock";
            this.btn_Stock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Stock.UseVisualStyleBackColor = false;
            this.btn_Stock.Click += new System.EventHandler(this.btn_Stock_Click);
            // 
            // btn_Items
            // 
            this.btn_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Items.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Items.Image = global::ShopC.Properties.Resources.Edit;
            this.btn_Items.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Items.Location = new System.Drawing.Point(574, 0);
            this.btn_Items.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Items.Name = "btn_Items";
            this.btn_Items.Size = new System.Drawing.Size(68, 32);
            this.btn_Items.TabIndex = 22;
            this.btn_Items.Text = "Items";
            this.btn_Items.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Items.UseVisualStyleBackColor = false;
            this.btn_Items.Click += new System.EventHandler(this.btn_Items_Click);
            // 
            // chk_SelectFromStock
            // 
            this.chk_SelectFromStock.BackColor = System.Drawing.Color.LemonChiffon;
            this.chk_SelectFromStock.Location = new System.Drawing.Point(389, 3);
            this.chk_SelectFromStock.Name = "chk_SelectFromStock";
            this.chk_SelectFromStock.Size = new System.Drawing.Size(103, 31);
            this.chk_SelectFromStock.TabIndex = 24;
            this.chk_SelectFromStock.Text = "Stock Selection";
            this.chk_SelectFromStock.UseVisualStyleBackColor = false;
            // 
            // usrc_ItemList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.chk_SelectFromStock);
            this.Controls.Add(this.btn_Stock);
            this.Controls.Add(this.btn_Items);
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
        private System.Windows.Forms.Button btn_Stock;
        private System.Windows.Forms.Button btn_Items;
        private System.Windows.Forms.CheckBox chk_SelectFromStock;
    }
}
