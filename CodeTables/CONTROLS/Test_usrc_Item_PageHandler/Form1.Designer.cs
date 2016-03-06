namespace Test_usrc_Item_PageHandler
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_Items = new System.Windows.Forms.Panel();
            this.usrc_Item_PageHandler = new usrc_Item_PageHandler.usrc_Item_PageHandler();
            this.SuspendLayout();
            // 
            // pnl_Items
            // 
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Items.Location = new System.Drawing.Point(47, 105);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(620, 457);
            this.pnl_Items.TabIndex = 1;
            // 
            // usrc_Item_PageHandler
            // 
            this.usrc_Item_PageHandler.Location = new System.Drawing.Point(43, 24);
            this.usrc_Item_PageHandler.Name = "usrc_Item_PageHandler";
            this.usrc_Item_PageHandler.Size = new System.Drawing.Size(215, 51);
            this.usrc_Item_PageHandler.TabIndex = 0;
            this.usrc_Item_PageHandler.ShowObject += new usrc_Item_PageHandler.usrc_Item_PageHandler.delegate_ShowObject(this.usrc_Item_PageHandler_ShowObject);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 590);
            this.Controls.Add(this.pnl_Items);
            this.Controls.Add(this.usrc_Item_PageHandler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Item_PageHandler.usrc_Item_PageHandler usrc_Item_PageHandler;
        private System.Windows.Forms.Panel pnl_Items;
    }
}

