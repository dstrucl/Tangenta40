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
            this.chk_select = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_Help
            // 
            this.txt_Help.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Help.Location = new System.Drawing.Point(25, 1);
            this.txt_Help.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Help.Multiline = true;
            this.txt_Help.Name = "txt_Help";
            this.txt_Help.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Help.Size = new System.Drawing.Size(621, 106);
            this.txt_Help.TabIndex = 0;
            // 
            // chk_select
            // 
            this.chk_select.AutoSize = true;
            this.chk_select.Location = new System.Drawing.Point(5, 41);
            this.chk_select.Name = "chk_select";
            this.chk_select.Size = new System.Drawing.Size(18, 17);
            this.chk_select.TabIndex = 1;
            this.chk_select.UseVisualStyleBackColor = true;
            // 
            // CommandLineHelp_ItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chk_select);
            this.Controls.Add(this.txt_Help);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommandLineHelp_ItemControl";
            this.Size = new System.Drawing.Size(651, 112);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Help;
        private System.Windows.Forms.CheckBox chk_select;
    }
}
