namespace TangentaPrint
{
    partial class usrc_Device
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
            this.lbl_PrinterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Printer
            // 
            this.btn_Printer.Image = global::TangentaPrint.Properties.Resources.PrinterSettings;
            this.btn_Printer.Location = new System.Drawing.Point(2, 0);
            this.btn_Printer.Name = "btn_Printer";
            this.btn_Printer.Size = new System.Drawing.Size(39, 28);
            this.btn_Printer.TabIndex = 0;
            this.btn_Printer.UseVisualStyleBackColor = true;
            this.btn_Printer.Click += new System.EventHandler(this.btn_Printer_Click);
            // 
            // lbl_PrinterName
            // 
            this.lbl_PrinterName.AutoSize = true;
            this.lbl_PrinterName.Location = new System.Drawing.Point(47, 8);
            this.lbl_PrinterName.Name = "lbl_PrinterName";
            this.lbl_PrinterName.Size = new System.Drawing.Size(19, 13);
            this.lbl_PrinterName.TabIndex = 1;
            this.lbl_PrinterName.Text = "??";
            // 
            // usrc_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_PrinterName);
            this.Controls.Add(this.btn_Printer);
            this.Name = "usrc_Device";
            this.Size = new System.Drawing.Size(263, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_Printer;
        private System.Windows.Forms.Label lbl_PrinterName;
    }
}
