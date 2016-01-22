namespace ShopA
{
    partial class usrc_Edit_Item_Unit
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
            this.cmb_Unit = new System.Windows.Forms.ComboBox();
            this.lbl_Item_Unit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_Unit
            // 
            this.cmb_Unit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Unit.FormattingEnabled = true;
            this.cmb_Unit.Location = new System.Drawing.Point(7, 24);
            this.cmb_Unit.Name = "cmb_Unit";
            this.cmb_Unit.Size = new System.Drawing.Size(135, 21);
            this.cmb_Unit.TabIndex = 5;
            // 
            // lbl_Item_Unit
            // 
            this.lbl_Item_Unit.AutoSize = true;
            this.lbl_Item_Unit.Location = new System.Drawing.Point(6, 6);
            this.lbl_Item_Unit.Name = "lbl_Item_Unit";
            this.lbl_Item_Unit.Size = new System.Drawing.Size(73, 13);
            this.lbl_Item_Unit.TabIndex = 4;
            this.lbl_Item_Unit.Text = "Merska Enota";
            // 
            // usrc_Edit_Item_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmb_Unit);
            this.Controls.Add(this.lbl_Item_Unit);
            this.Name = "usrc_Edit_Item_Unit";
            this.Size = new System.Drawing.Size(148, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Unit;
        private System.Windows.Forms.Label lbl_Item_Unit;
    }
}
