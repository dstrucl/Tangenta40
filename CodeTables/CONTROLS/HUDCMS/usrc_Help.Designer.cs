namespace HUDCMS
{
    partial class usrc_Help
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
            this.btn_Help = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Help
            // 
            this.btn_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Help.Image = Properties.Resources.Help_bmp;
            this.btn_Help.Location = new System.Drawing.Point(0, 0);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(56, 61);
            this.btn_Help.TabIndex = 0;
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // usrc_Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Help);
            this.Name = "usrc_Help";
            this.Size = new System.Drawing.Size(56, 61);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Help;
    }
}
