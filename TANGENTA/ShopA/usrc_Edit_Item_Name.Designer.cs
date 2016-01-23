namespace ShopA
{
    partial class usrc_Edit_Item_Name
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
            this.txt_ItemName = new System.Windows.Forms.TextBox();
            this.lbl_ItemName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_ItemName
            // 
            this.txt_ItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ItemName.Location = new System.Drawing.Point(2, 16);
            this.txt_ItemName.Name = "txt_ItemName";
            this.txt_ItemName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ItemName.Size = new System.Drawing.Size(173, 20);
            this.txt_ItemName.TabIndex = 0;
            this.txt_ItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ItemName_KeyPress);
            // 
            // lbl_ItemName
            // 
            this.lbl_ItemName.AutoSize = true;
            this.lbl_ItemName.Location = new System.Drawing.Point(3, 0);
            this.lbl_ItemName.Name = "lbl_ItemName";
            this.lbl_ItemName.Size = new System.Drawing.Size(106, 13);
            this.lbl_ItemName.TabIndex = 1;
            this.lbl_ItemName.Text = "Ime Artikla ali storitve";
            // 
            // usrc_Edit_Item_Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_ItemName);
            this.Controls.Add(this.txt_ItemName);
            this.Name = "usrc_Edit_Item_Name";
            this.Size = new System.Drawing.Size(178, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ItemName;
        private System.Windows.Forms.Label lbl_ItemName;
    }
}
