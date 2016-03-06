namespace ErrorCreateWindowHandle
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
            this.pnl_Group = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl_Items
            // 
            this.pnl_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.pnl_Items.BackColor = System.Drawing.Color.Thistle;
            this.pnl_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Items.Location = new System.Drawing.Point(0, 0);
            this.pnl_Items.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(503, 393);
            this.pnl_Items.TabIndex = 7;
            // 
            // pnl_Group
            // 
            this.pnl_Group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Group.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnl_Group.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Group.Location = new System.Drawing.Point(507, 0);
            this.pnl_Group.Name = "pnl_Group";
            this.pnl_Group.Size = new System.Drawing.Size(148, 392);
            this.pnl_Group.TabIndex = 8;
            // 
            // usrc_ItemList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnl_Group);
            this.Controls.Add(this.pnl_Items);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_ItemList";
            this.Size = new System.Drawing.Size(656, 393);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Items;
        private System.Windows.Forms.Panel pnl_Group;

    }
}
