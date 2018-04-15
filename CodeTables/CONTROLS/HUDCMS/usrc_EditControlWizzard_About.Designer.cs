using FastColoredTextBoxNS;

namespace HUDCMS
{
    partial class usrc_EditControlWizzard_About
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
            this.lbl_AboutControl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_AboutControl
            // 
            this.lbl_AboutControl.AutoSize = true;
            this.lbl_AboutControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_AboutControl.Location = new System.Drawing.Point(13, 16);
            this.lbl_AboutControl.Name = "lbl_AboutControl";
            this.lbl_AboutControl.Size = new System.Drawing.Size(46, 18);
            this.lbl_AboutControl.TabIndex = 36;
            this.lbl_AboutControl.Text = "About";
            // 
            // usrc_EditControlWizzard_About
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_AboutControl);
            this.Name = "usrc_EditControlWizzard_About";
            this.Size = new System.Drawing.Size(948, 501);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_AboutControl;
    }
}
