namespace ShopC
{
    partial class usrc_Atom_ItemsList1366x768
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
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.usrc_Item_InsidePageHandler1 = new usrc_Item_PageHandler.usrc_Item_InsidePageHandler();
            this.SuspendLayout();
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ClearAll.Image = global::ShopC.Properties.Resources.RemoveAll;
            this.btn_ClearAll.Location = new System.Drawing.Point(410, 0);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(61, 44);
            this.btn_ClearAll.TabIndex = 10;
            this.btn_ClearAll.UseVisualStyleBackColor = false;
            this.btn_ClearAll.Visible = false;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // usrc_Item_InsidePageHandler1
            // 
            this.usrc_Item_InsidePageHandler1.BackColor = System.Drawing.Color.OldLace;
            this.usrc_Item_InsidePageHandler1.Location = new System.Drawing.Point(4, 46);
            this.usrc_Item_InsidePageHandler1.Name = "usrc_Item_InsidePageHandler1";
            this.usrc_Item_InsidePageHandler1.SelectedIndex = -1;
            this.usrc_Item_InsidePageHandler1.Size = new System.Drawing.Size(469, 249);
            this.usrc_Item_InsidePageHandler1.TabIndex = 11;
            // 
            // usrc_Atom_ItemsList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Item_InsidePageHandler1);
            this.Controls.Add(this.btn_ClearAll);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Atom_ItemsList1366x768";
            this.Size = new System.Drawing.Size(476, 297);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ClearAll;
        private usrc_Item_PageHandler.usrc_Item_InsidePageHandler usrc_Item_InsidePageHandler1;
    }
}
