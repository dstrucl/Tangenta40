namespace LanguageManager
{
    partial class Form_ViewGetingReferencesProgress
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
            this.txt_output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_output
            // 
            this.txt_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_output.Location = new System.Drawing.Point(0, 0);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_output.Size = new System.Drawing.Size(728, 512);
            this.txt_output.TabIndex = 0;
            // 
            // Form_ViewGetingReferencesProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 512);
            this.Controls.Add(this.txt_output);
            this.Name = "Form_ViewGetingReferencesProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ViewGetingReferencesProgress";
            this.Shown += new System.EventHandler(this.Form_ViewGetingReferencesProgress_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_output;
    }
}