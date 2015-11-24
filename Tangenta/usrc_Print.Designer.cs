namespace Tangenta
{
    partial class usrc_Print
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
            this.lbl_PrinterName_Value = new System.Windows.Forms.Label();
            this.lbl_PrinterName = new System.Windows.Forms.Label();
            this.lbl_PaperName_Value = new System.Windows.Forms.Label();
            this.lbl_PaperName = new System.Windows.Forms.Label();
            this.btn_SelectPrinter = new System.Windows.Forms.Button();
            this.btn_PageSetup = new System.Windows.Forms.Button();
            this.chk_PrintAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_PrinterName_Value
            // 
            this.lbl_PrinterName_Value.Location = new System.Drawing.Point(87, 5);
            this.lbl_PrinterName_Value.Name = "lbl_PrinterName_Value";
            this.lbl_PrinterName_Value.Size = new System.Drawing.Size(217, 16);
            this.lbl_PrinterName_Value.TabIndex = 10;
            this.lbl_PrinterName_Value.Text = "PRINTER name value";
            this.lbl_PrinterName_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PrinterName
            // 
            this.lbl_PrinterName.Location = new System.Drawing.Point(3, 5);
            this.lbl_PrinterName.Name = "lbl_PrinterName";
            this.lbl_PrinterName.Size = new System.Drawing.Size(83, 16);
            this.lbl_PrinterName.TabIndex = 9;
            this.lbl_PrinterName.Text = "printer name:";
            this.lbl_PrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PaperName_Value
            // 
            this.lbl_PaperName_Value.Location = new System.Drawing.Point(87, 21);
            this.lbl_PaperName_Value.Name = "lbl_PaperName_Value";
            this.lbl_PaperName_Value.Size = new System.Drawing.Size(217, 16);
            this.lbl_PaperName_Value.TabIndex = 8;
            this.lbl_PaperName_Value.Text = "Paper name value";
            this.lbl_PaperName_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PaperName
            // 
            this.lbl_PaperName.Location = new System.Drawing.Point(3, 21);
            this.lbl_PaperName.Name = "lbl_PaperName";
            this.lbl_PaperName.Size = new System.Drawing.Size(83, 16);
            this.lbl_PaperName.TabIndex = 7;
            this.lbl_PaperName.Text = "Paper name:";
            this.lbl_PaperName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SelectPrinter
            // 
            this.btn_SelectPrinter.Location = new System.Drawing.Point(331, -1);
            this.btn_SelectPrinter.Name = "btn_SelectPrinter";
            this.btn_SelectPrinter.Size = new System.Drawing.Size(85, 25);
            this.btn_SelectPrinter.TabIndex = 12;
            this.btn_SelectPrinter.Text = "Printer select";
            this.btn_SelectPrinter.UseVisualStyleBackColor = true;
            this.btn_SelectPrinter.Click += new System.EventHandler(this.btn_SelectPrinter_Click);
            // 
            // btn_PageSetup
            // 
            this.btn_PageSetup.Location = new System.Drawing.Point(422, -1);
            this.btn_PageSetup.Name = "btn_PageSetup";
            this.btn_PageSetup.Size = new System.Drawing.Size(81, 25);
            this.btn_PageSetup.TabIndex = 11;
            this.btn_PageSetup.Text = "Page Setup";
            this.btn_PageSetup.UseVisualStyleBackColor = true;
            this.btn_PageSetup.Click += new System.EventHandler(this.btn_PageSetup_Click);
            // 
            // chk_PrintAll
            // 
            this.chk_PrintAll.AutoSize = true;
            this.chk_PrintAll.Location = new System.Drawing.Point(334, 27);
            this.chk_PrintAll.Name = "chk_PrintAll";
            this.chk_PrintAll.Size = new System.Drawing.Size(80, 17);
            this.chk_PrintAll.TabIndex = 13;
            this.chk_PrintAll.Text = "checkBox1";
            this.chk_PrintAll.UseVisualStyleBackColor = true;
            // 
            // usrc_Print
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.chk_PrintAll);
            this.Controls.Add(this.btn_SelectPrinter);
            this.Controls.Add(this.btn_PageSetup);
            this.Controls.Add(this.lbl_PrinterName_Value);
            this.Controls.Add(this.lbl_PrinterName);
            this.Controls.Add(this.lbl_PaperName_Value);
            this.Controls.Add(this.lbl_PaperName);
            this.Name = "usrc_Print";
            this.Size = new System.Drawing.Size(523, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PrinterName_Value;
        private System.Windows.Forms.Label lbl_PrinterName;
        private System.Windows.Forms.Label lbl_PaperName_Value;
        private System.Windows.Forms.Label lbl_PaperName;
        private System.Windows.Forms.Button btn_SelectPrinter;
        private System.Windows.Forms.Button btn_PageSetup;
        private System.Windows.Forms.CheckBox chk_PrintAll;

    }
}
