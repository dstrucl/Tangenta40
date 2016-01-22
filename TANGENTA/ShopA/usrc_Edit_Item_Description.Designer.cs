namespace ShopA
{
    partial class usrc_Edit_Item_Description
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
            this.lbl_Item_Description = new System.Windows.Forms.Label();
            this.txt_Item_Description = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Item_Description
            // 
            this.lbl_Item_Description.AutoSize = true;
            this.lbl_Item_Description.Location = new System.Drawing.Point(5, 7);
            this.lbl_Item_Description.Name = "lbl_Item_Description";
            this.lbl_Item_Description.Size = new System.Drawing.Size(106, 13);
            this.lbl_Item_Description.TabIndex = 3;
            this.lbl_Item_Description.Text = "Opis artikla ali storive";
            // 
            // txt_Item_Description
            // 
            this.txt_Item_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Item_Description.Location = new System.Drawing.Point(2, 26);
            this.txt_Item_Description.Multiline = true;
            this.txt_Item_Description.Name = "txt_Item_Description";
            this.txt_Item_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Item_Description.Size = new System.Drawing.Size(219, 181);
            this.txt_Item_Description.TabIndex = 2;
            // 
            // usrc_Edit_Item_Description
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_Item_Description);
            this.Controls.Add(this.txt_Item_Description);
            this.Name = "usrc_Edit_Item_Description";
            this.Size = new System.Drawing.Size(224, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item_Description;
        private System.Windows.Forms.TextBox txt_Item_Description;
    }
}
