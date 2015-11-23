namespace CommandLineHelp
{
    partial class CommandLineHelp_Control
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
            this.btn_CommandLineHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CommandLineHelp
            // 
            this.btn_CommandLineHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CommandLineHelp.Location = new System.Drawing.Point(0, 0);
            this.btn_CommandLineHelp.Name = "btn_CommandLineHelp";
            this.btn_CommandLineHelp.Size = new System.Drawing.Size(187, 28);
            this.btn_CommandLineHelp.TabIndex = 0;
            this.btn_CommandLineHelp.Text = "button1";
            this.btn_CommandLineHelp.UseVisualStyleBackColor = true;
            this.btn_CommandLineHelp.Click += new System.EventHandler(this.btn_CommandLineHelp_Click);
            // 
            // CommandLineHelp_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_CommandLineHelp);
            this.Name = "CommandLineHelp_Control";
            this.Size = new System.Drawing.Size(190, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CommandLineHelp;
    }
}
