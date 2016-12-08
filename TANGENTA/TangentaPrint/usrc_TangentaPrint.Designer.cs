namespace TangentaPrint
{
    partial class usrc_TangentaPrint
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
            this.btn_Printers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Printers
            // 
            this.btn_Printers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Printers.Image = global::TangentaPrint.Properties.Resources.Printers;
            this.btn_Printers.Location = new System.Drawing.Point(0, 0);
            this.btn_Printers.Name = "btn_Printers";
            this.btn_Printers.Size = new System.Drawing.Size(46, 30);
            this.btn_Printers.TabIndex = 0;
            this.btn_Printers.UseVisualStyleBackColor = true;
            this.btn_Printers.Click += new System.EventHandler(this.btn_Printers_Click);
            // 
            // usrc_TangentaPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Printers);
            this.Name = "usrc_TangentaPrint";
            this.Size = new System.Drawing.Size(46, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Printers;
    }
}
