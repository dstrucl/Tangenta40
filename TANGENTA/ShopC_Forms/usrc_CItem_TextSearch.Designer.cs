namespace ShopC_Forms
{
    partial class usrc_CItem_TextSearch
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
            this.txt_Item_UniqueName = new System.Windows.Forms.TextBox();
            this.lbl_Group = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Item_UniqueName
            // 
            this.txt_Item_UniqueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Item_UniqueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Item_UniqueName.Location = new System.Drawing.Point(3, 17);
            this.txt_Item_UniqueName.Name = "txt_Item_UniqueName";
            this.txt_Item_UniqueName.Size = new System.Drawing.Size(447, 22);
            this.txt_Item_UniqueName.TabIndex = 0;
            // 
            // lbl_Group
            // 
            this.lbl_Group.Location = new System.Drawing.Point(1, 1);
            this.lbl_Group.Name = "lbl_Group";
            this.lbl_Group.Size = new System.Drawing.Size(446, 16);
            this.lbl_Group.TabIndex = 1;
            this.lbl_Group.Text = "lbl_Group";
            // 
            // usrc_Item_TextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.Controls.Add(this.lbl_Group);
            this.Controls.Add(this.txt_Item_UniqueName);
            this.Name = "usrc_Item_TextSearch";
            this.Size = new System.Drawing.Size(452, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Item_UniqueName;
        private System.Windows.Forms.Label lbl_Group;
    }
}
