namespace Tangenta
{
    partial class Form_FirstTimeInstallationGreeting
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
            this.usrc_web_Help1 = new HUDCMS.usrc_web_Help();
            this.SuspendLayout();
            // 
            // usrc_web_Help1
            // 
            this.usrc_web_Help1.BackColor = System.Drawing.Color.GreenYellow;
            this.usrc_web_Help1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_web_Help1.LocalUrl = "Local URL:";
            this.usrc_web_Help1.Location = new System.Drawing.Point(0, 0);
            this.usrc_web_Help1.Name = "usrc_web_Help1";
            this.usrc_web_Help1.RemoteUrl = "";
            this.usrc_web_Help1.Size = new System.Drawing.Size(602, 404);
            this.usrc_web_Help1.TabIndex = 0;
            // 
            // Form_FirstTimeInstallationGreeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 404);
            this.Controls.Add(this.usrc_web_Help1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_FirstTimeInstallationGreeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_FirstTimeInstallationGreeting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HUDCMS.usrc_web_Help usrc_web_Help1;
    }
}