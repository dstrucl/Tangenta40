namespace ShopC
{
    partial class Form_plus
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
            this.components = new System.ComponentModel.Container();
            this.lbl_Sign = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_Sign
            // 
            this.lbl_Sign.AutoSize = true;
            this.lbl_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sign.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lbl_Sign.Location = new System.Drawing.Point(0, 0);
            this.lbl_Sign.Name = "lbl_Sign";
            this.lbl_Sign.Size = new System.Drawing.Size(19, 20);
            this.lbl_Sign.TabIndex = 0;
            this.lbl_Sign.Text = "+";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_plus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(20, 20);
            this.Controls.Add(this.lbl_Sign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_plus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_plus";
            this.Load += new System.EventHandler(this.Form_plus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Sign;
        private System.Windows.Forms.Timer timer1;
    }
}