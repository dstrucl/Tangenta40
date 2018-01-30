namespace HUDCMS
{
    partial class Form_Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Help));
            this.usrc_web_Help1 = new HUDCMS.usrc_web_Help();
            this.SuspendLayout();
            // 
            // usrc_web_Help1
            // 
            this.usrc_web_Help1.BackColor = System.Drawing.Color.LemonChiffon;
            this.usrc_web_Help1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_web_Help1.LocalUrl = "Local URL:";
            this.usrc_web_Help1.Location = new System.Drawing.Point(0, 0);
            this.usrc_web_Help1.Name = "usrc_web_Help1";
            this.usrc_web_Help1.RemoteUrl = "";
            this.usrc_web_Help1.Size = new System.Drawing.Size(1123, 731);
            this.usrc_web_Help1.TabIndex = 0;
            // 
            // Form_Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 731);
            this.Controls.Add(this.usrc_web_Help1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_Help_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_web_Help usrc_web_Help1;
    }
}