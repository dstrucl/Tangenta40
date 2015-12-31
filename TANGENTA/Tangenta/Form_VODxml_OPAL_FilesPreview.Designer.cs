namespace Tangenta
{
    partial class Form_VODxml_OPAL_FilesPreview
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
            this.lbl_file_GLAVA = new System.Windows.Forms.Label();
            this.txt_GLAVA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_file_GLAVA
            // 
            this.lbl_file_GLAVA.AutoSize = true;
            this.lbl_file_GLAVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_GLAVA.Location = new System.Drawing.Point(11, 9);
            this.lbl_file_GLAVA.Name = "lbl_file_GLAVA";
            this.lbl_file_GLAVA.Size = new System.Drawing.Size(51, 20);
            this.lbl_file_GLAVA.TabIndex = 5;
            this.lbl_file_GLAVA.Text = "label1";
            // 
            // txt_GLAVA
            // 
            this.txt_GLAVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_GLAVA.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_GLAVA.Location = new System.Drawing.Point(12, 32);
            this.txt_GLAVA.Multiline = true;
            this.txt_GLAVA.Name = "txt_GLAVA";
            this.txt_GLAVA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_GLAVA.Size = new System.Drawing.Size(835, 749);
            this.txt_GLAVA.TabIndex = 4;
            this.txt_GLAVA.WordWrap = false;
            // 
            // Form_VODxml_OPAL_FilesPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 793);
            this.Controls.Add(this.lbl_file_GLAVA);
            this.Controls.Add(this.txt_GLAVA);
            this.Name = "Form_VODxml_OPAL_FilesPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DURS_FilesPreview";
            this.Load += new System.EventHandler(this.Form_XML_FilesPreview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_file_GLAVA;
        private System.Windows.Forms.TextBox txt_GLAVA;


    }
}