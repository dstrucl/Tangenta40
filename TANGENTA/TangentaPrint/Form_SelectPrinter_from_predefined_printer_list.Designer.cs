namespace TangentaPrint
{
    partial class Form_SelectPrinter_from_predefined_printer_list
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.cmb_PrinterList = new System.Windows.Forms.ComboBox();
            this.lbl_PrinterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(189, 92);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(82, 27);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // cmb_PrinterList
            // 
            this.cmb_PrinterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_PrinterList.FormattingEnabled = true;
            this.cmb_PrinterList.Location = new System.Drawing.Point(140, 12);
            this.cmb_PrinterList.Name = "cmb_PrinterList";
            this.cmb_PrinterList.Size = new System.Drawing.Size(212, 24);
            this.cmb_PrinterList.TabIndex = 1;
            // 
            // lbl_PrinterName
            // 
            this.lbl_PrinterName.AutoSize = true;
            this.lbl_PrinterName.Location = new System.Drawing.Point(12, 17);
            this.lbl_PrinterName.Name = "lbl_PrinterName";
            this.lbl_PrinterName.Size = new System.Drawing.Size(35, 13);
            this.lbl_PrinterName.TabIndex = 2;
            this.lbl_PrinterName.Text = "label1";
            // 
            // Form_SelectPrinter_from_predefined_printer_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 127);
            this.Controls.Add(this.lbl_PrinterName);
            this.Controls.Add(this.cmb_PrinterList);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SelectPrinter_from_predefined_printer_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SelectPrinter_from_predefined_printer_list";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.ComboBox cmb_PrinterList;
        private System.Windows.Forms.Label lbl_PrinterName;
    }
}