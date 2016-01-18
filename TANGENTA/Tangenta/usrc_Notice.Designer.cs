namespace Tangenta
{
    partial class usrc_Notice
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
            this.txt_Notice = new System.Windows.Forms.TextBox();
            this.btn_Notice = new System.Windows.Forms.Button();
            this.lbl_Notice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Notice
            // 
            this.txt_Notice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Notice.Location = new System.Drawing.Point(134, 1);
            this.txt_Notice.Multiline = true;
            this.txt_Notice.Name = "txt_Notice";
            this.txt_Notice.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Notice.Size = new System.Drawing.Size(375, 46);
            this.txt_Notice.TabIndex = 0;
            // 
            // btn_Notice
            // 
            this.btn_Notice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Notice.BackColor = System.Drawing.Color.OldLace;
            this.btn_Notice.Image = global::Tangenta.Properties.Resources.Edit;
            this.btn_Notice.Location = new System.Drawing.Point(64, 1);
            this.btn_Notice.Name = "btn_Notice";
            this.btn_Notice.Size = new System.Drawing.Size(65, 46);
            this.btn_Notice.TabIndex = 1;
            this.btn_Notice.UseVisualStyleBackColor = false;
            this.btn_Notice.Click += new System.EventHandler(this.btn_Notice_Click);
            // 
            // lbl_Notice
            // 
            this.lbl_Notice.AutoSize = true;
            this.lbl_Notice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Notice.Location = new System.Drawing.Point(0, 15);
            this.lbl_Notice.Name = "lbl_Notice";
            this.lbl_Notice.Size = new System.Drawing.Size(63, 20);
            this.lbl_Notice.TabIndex = 2;
            this.lbl_Notice.Text = "DOPIS:";
            // 
            // usrc_Notice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.Controls.Add(this.lbl_Notice);
            this.Controls.Add(this.btn_Notice);
            this.Controls.Add(this.txt_Notice);
            this.Name = "usrc_Notice";
            this.Size = new System.Drawing.Size(512, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Notice;
        private System.Windows.Forms.Button btn_Notice;
        private System.Windows.Forms.Label lbl_Notice;
    }
}
