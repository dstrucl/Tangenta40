namespace Tangenta
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
            this.SuspendLayout();
            // 
            // lbl_StartUp
            // 
            this.lbl_StartUp.AutoSize = true;
            this.lbl_StartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StartUp.Location = new System.Drawing.Point(18, 12);
            this.lbl_StartUp.Name = "lbl_StartUp";
            this.lbl_StartUp.Size = new System.Drawing.Size(93, 32);
            this.lbl_StartUp.TabIndex = 0;
            this.lbl_StartUp.Text = "label1";
            // 
            // usrc_Startup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_StartUp);
            this.Name = "usrc_Startup";
            this.Size = new System.Drawing.Size(869, 635);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StartUp;
    }
}
