namespace Password
{
    partial class Form_AskForPassword
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
            this.usrc_Password1 = new usrc_Password();
            this.SuspendLayout();
            // 
            // usrc_Password1
            // 
            this.usrc_Password1.Location = new System.Drawing.Point(-2, 0);
            this.usrc_Password1.Name = "usrc_Password1";
            this.usrc_Password1.Size = new System.Drawing.Size(342, 140);
            this.usrc_Password1.TabIndex = 0;
            this.usrc_Password1.exit_OK += new usrc_Password.delegate_Password_OK(this.usrc_Password1_exit_OK);
            this.usrc_Password1.exit_Cancel += new usrc_Password.delegate_Cancel(this.usrc_Password1_exit_Cancel);
            // 
            // Form_AskForPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(342, 143);
            this.Controls.Add(this.usrc_Password1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_AskForPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AskForPassword";
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Password usrc_Password1;
    }
}