namespace Tangenta
{
    partial class Form_DURS_FilesPreview
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_file_GLAVA = new System.Windows.Forms.Label();
            this.txt_GLAVA = new System.Windows.Forms.TextBox();
            this.lbl_file_POSTAVKE = new System.Windows.Forms.Label();
            this.txt_POSTAVKE = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_file_GLAVA);
            this.splitContainer1.Panel1.Controls.Add(this.txt_GLAVA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_file_POSTAVKE);
            this.splitContainer1.Panel2.Controls.Add(this.txt_POSTAVKE);
            this.splitContainer1.Size = new System.Drawing.Size(859, 511);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbl_file_GLAVA
            // 
            this.lbl_file_GLAVA.AutoSize = true;
            this.lbl_file_GLAVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_GLAVA.Location = new System.Drawing.Point(8, 9);
            this.lbl_file_GLAVA.Name = "lbl_file_GLAVA";
            this.lbl_file_GLAVA.Size = new System.Drawing.Size(51, 20);
            this.lbl_file_GLAVA.TabIndex = 1;
            this.lbl_file_GLAVA.Text = "label1";
            // 
            // txt_GLAVA
            // 
            this.txt_GLAVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_GLAVA.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_GLAVA.Location = new System.Drawing.Point(6, 41);
            this.txt_GLAVA.Multiline = true;
            this.txt_GLAVA.Name = "txt_GLAVA";
            this.txt_GLAVA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_GLAVA.Size = new System.Drawing.Size(433, 469);
            this.txt_GLAVA.TabIndex = 0;
            this.txt_GLAVA.WordWrap = false;
            // 
            // lbl_file_POSTAVKE
            // 
            this.lbl_file_POSTAVKE.AutoSize = true;
            this.lbl_file_POSTAVKE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_POSTAVKE.Location = new System.Drawing.Point(13, 9);
            this.lbl_file_POSTAVKE.Name = "lbl_file_POSTAVKE";
            this.lbl_file_POSTAVKE.Size = new System.Drawing.Size(51, 20);
            this.lbl_file_POSTAVKE.TabIndex = 2;
            this.lbl_file_POSTAVKE.Text = "label1";
            // 
            // txt_POSTAVKE
            // 
            this.txt_POSTAVKE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_POSTAVKE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_POSTAVKE.Location = new System.Drawing.Point(3, 41);
            this.txt_POSTAVKE.Multiline = true;
            this.txt_POSTAVKE.Name = "txt_POSTAVKE";
            this.txt_POSTAVKE.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_POSTAVKE.Size = new System.Drawing.Size(403, 467);
            this.txt_POSTAVKE.TabIndex = 1;
            this.txt_POSTAVKE.WordWrap = false;
            // 
            // Form_DURS_FilesPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(859, 511);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_DURS_FilesPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DURS_FilesPreview";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_file_GLAVA;
        private System.Windows.Forms.TextBox txt_GLAVA;
        private System.Windows.Forms.Label lbl_file_POSTAVKE;
        private System.Windows.Forms.TextBox txt_POSTAVKE;
    }
}