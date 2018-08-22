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
            this.components = new System.ComponentModel.Container();
            this.txt_Item_Description = new TextBoxRecent.TextBoxR();
            this.SuspendLayout();
            // 
            // txt_Item_Description
            // 
            this.txt_Item_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Item_Description.Location = new System.Drawing.Point(0, 0);
            this.txt_Item_Description.Multiline = true;
            this.txt_Item_Description.Name = "txt_Item_Description";
            this.txt_Item_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Item_Description.Size = new System.Drawing.Size(224, 40);
            this.txt_Item_Description.TabIndex = 4;
            // 
            // usrc_Edit_Item_Description
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_Item_Description);
            this.Name = "usrc_Edit_Item_Description";
            this.Size = new System.Drawing.Size(224, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBoxRecent.TextBoxR txt_Item_Description;
    }
}
