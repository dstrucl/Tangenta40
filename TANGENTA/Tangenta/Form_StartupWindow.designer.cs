namespace Tangenta
{
    partial class Form_StartupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StartupWindow));
            this.lbl_Info = new System.Windows.Forms.Label();
            this.lbl_CopyRight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Info.ForeColor = System.Drawing.Color.SkyBlue;
            this.lbl_Info.Location = new System.Drawing.Point(3, 311);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(557, 29);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "PROGRESS INFO";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CopyRight
            // 
            this.lbl_CopyRight.AutoSize = true;
            this.lbl_CopyRight.Location = new System.Drawing.Point(26, 63);
            this.lbl_CopyRight.Name = "lbl_CopyRight";
            this.lbl_CopyRight.Size = new System.Drawing.Size(35, 13);
            this.lbl_CopyRight.TabIndex = 2;
            this.lbl_CopyRight.Text = "label1";
            // 
            // Form_StartupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(564, 367);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_CopyRight);
            this.Controls.Add(this.lbl_Info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_StartupWindow";
            this.Text = "KIG Programski paket za vodenje proizvodnje tablic se nalaga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label lbl_CopyRight;
    }
}