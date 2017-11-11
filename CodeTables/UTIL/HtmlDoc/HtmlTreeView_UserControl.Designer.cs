namespace HtmlDoc
{
    partial class HtmlTreeView_UserControl
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
            this.trV_Html = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trV_Html
            // 
            this.trV_Html.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trV_Html.Location = new System.Drawing.Point(3, 3);
            this.trV_Html.Name = "trV_Html";
            this.trV_Html.Size = new System.Drawing.Size(816, 504);
            this.trV_Html.TabIndex = 1;
            // 
            // HtmlTreeView_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trV_Html);
            this.Name = "HtmlTreeView_UserControl";
            this.Size = new System.Drawing.Size(822, 510);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trV_Html;
    }
}
