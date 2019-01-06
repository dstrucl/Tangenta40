namespace TangentaCore
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
            this.btn_SelectNotice = new System.Windows.Forms.Button();
            this.chk_Notice = new System.Windows.Forms.CheckBox();
            this.txt_Notice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_SelectNotice
            // 
            this.btn_SelectNotice.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectNotice.Image = Properties.Resources.SelectRow;
            this.btn_SelectNotice.Location = new System.Drawing.Point(3, 5);
            this.btn_SelectNotice.Name = "btn_SelectNotice";
            this.btn_SelectNotice.Size = new System.Drawing.Size(44, 27);
            this.btn_SelectNotice.TabIndex = 31;
            this.btn_SelectNotice.UseVisualStyleBackColor = false;
            this.btn_SelectNotice.Click += new System.EventHandler(this.btn_SelectNotice_Click);
            // 
            // chk_Notice
            // 
            this.chk_Notice.AutoSize = true;
            this.chk_Notice.Location = new System.Drawing.Point(53, 8);
            this.chk_Notice.Name = "chk_Notice";
            this.chk_Notice.Size = new System.Drawing.Size(57, 17);
            this.chk_Notice.TabIndex = 30;
            this.chk_Notice.Text = "Notice";
            this.chk_Notice.UseVisualStyleBackColor = true;
            this.chk_Notice.CheckedChanged += new System.EventHandler(this.chk_Notice_CheckedChanged);
            // 
            // txt_Notice
            // 
            this.txt_Notice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Notice.Enabled = false;
            this.txt_Notice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Notice.Location = new System.Drawing.Point(3, 34);
            this.txt_Notice.Multiline = true;
            this.txt_Notice.Name = "txt_Notice";
            this.txt_Notice.Size = new System.Drawing.Size(554, 88);
            this.txt_Notice.TabIndex = 29;
            // 
            // usrc_Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn_SelectNotice);
            this.Controls.Add(this.chk_Notice);
            this.Controls.Add(this.txt_Notice);
            this.Name = "usrc_Notice";
            this.Size = new System.Drawing.Size(556, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectNotice;
        private System.Windows.Forms.CheckBox chk_Notice;
        private System.Windows.Forms.TextBox txt_Notice;
    }
}
