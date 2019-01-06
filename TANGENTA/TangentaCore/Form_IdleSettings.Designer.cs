namespace TangentaCore
{
    partial class Form_IdleSettings
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.usrc_IdleSettings1 = new LoginControl.usrc_IdleSettings();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(443, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(66, 26);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(352, 0);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(66, 26);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // usrc_IdleSettings1
            // 
            this.usrc_IdleSettings1.Location = new System.Drawing.Point(1, 27);
            this.usrc_IdleSettings1.Name = "usrc_IdleSettings1";
            this.usrc_IdleSettings1.Size = new System.Drawing.Size(507, 178);
            this.usrc_IdleSettings1.TabIndex = 0;
            // 
            // Form_IdleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(510, 214);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.usrc_IdleSettings1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_IdleSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_IdleSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl.usrc_IdleSettings usrc_IdleSettings1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_OK;
    }
}