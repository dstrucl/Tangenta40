namespace Startup
{
    partial class usrc_Startup
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
            this.lbl_StartUp = new System.Windows.Forms.Label();
            this.usrc_web_Help1 = new HUDCMS.usrc_web_Help();
            this.SuspendLayout();
            // 
            // lbl_StartUp
            // 
            this.lbl_StartUp.AutoSize = true;
            this.lbl_StartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StartUp.Location = new System.Drawing.Point(18, 12);
            this.lbl_StartUp.Name = "lbl_StartUp";
            this.lbl_StartUp.Size = new System.Drawing.Size(70, 26);
            this.lbl_StartUp.TabIndex = 0;
            this.lbl_StartUp.Text = "label1";
            // 
            // usrc_web_Help1
            // 
            this.usrc_web_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_web_Help1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usrc_web_Help1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_web_Help1.LocalUrl = "Local URL:";
            this.usrc_web_Help1.Location = new System.Drawing.Point(392, 3);
            this.usrc_web_Help1.Name = "usrc_web_Help1";
            this.usrc_web_Help1.RemoteUrl = "Remote URL:";
            this.usrc_web_Help1.Size = new System.Drawing.Size(474, 629);
            this.usrc_web_Help1.TabIndex = 1;
            // 
            // usrc_Startup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.usrc_web_Help1);
            this.Controls.Add(this.lbl_StartUp);
            this.Name = "usrc_Startup";
            this.Size = new System.Drawing.Size(869, 635);
            this.Load += new System.EventHandler(this.usrc_Startup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StartUp;
        public HUDCMS.usrc_web_Help usrc_web_Help1;
    }
}
