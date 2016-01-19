namespace Tangenta
{
    partial class usrc_Printer
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
            this.btn_Printer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Printer
            // 
            this.btn_Printer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Printer.Image = global::Tangenta.Properties.Resources.PrinterSettings;
            this.btn_Printer.Location = new System.Drawing.Point(0, 0);
            this.btn_Printer.Name = "btn_Printer";
            this.btn_Printer.Size = new System.Drawing.Size(34, 28);
            this.btn_Printer.TabIndex = 0;
            this.btn_Printer.UseVisualStyleBackColor = true;
            this.btn_Printer.Click += new System.EventHandler(this.btn_Printer_Click);
            // 
            // usrc_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Printer);
            this.Name = "usrc_Printer";
            this.Size = new System.Drawing.Size(34, 28);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btn_Printer;
    }
}
