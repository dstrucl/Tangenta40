namespace CommandLineHelp
{
    partial class CommandLineHelp_ItemControl
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
            this.txt_Help = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Help
            // 
            this.txt_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Help.Location = new System.Drawing.Point(3, 1);
            this.txt_Help.Multiline = true;
            this.txt_Help.Name = "txt_Help";
            this.txt_Help.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Help.Size = new System.Drawing.Size(527, 87);
            this.txt_Help.TabIndex = 0;
            // 
            // CommandLineHelp_ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txt_Help);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CommandLineHelp_ItemControl";
            this.Size = new System.Drawing.Size(533, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Help;
    }
}
