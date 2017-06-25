namespace TangentaPrint
{
    partial class usrc_SelectPrintTemplate
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
            this.grp_Orientation = new System.Windows.Forms.GroupBox();
            this.rdb_Landscape = new System.Windows.Forms.RadioButton();
            this.rdb_Portrait = new System.Windows.Forms.RadioButton();
            this.lbl_Language = new System.Windows.Forms.Label();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.grp_PaperSize = new System.Windows.Forms.GroupBox();
            this.rdb_80 = new System.Windows.Forms.RadioButton();
            this.rdb_58 = new System.Windows.Forms.RadioButton();
            this.rdb_A4 = new System.Windows.Forms.RadioButton();
            this.lbl_Template = new System.Windows.Forms.Label();
            this.btn_EditTemplates = new System.Windows.Forms.Button();
            this.cmb_SelectPrinter = new System.Windows.Forms.ComboBox();
            this.lbl_printer = new System.Windows.Forms.Label();
            this.btn_SelectPrinter = new System.Windows.Forms.Button();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.cmb_SelectPrintTemplate = new EWSoftware.ListControls.MultiColumnComboBox();
            this.chk_Default = new System.Windows.Forms.CheckBox();
            this.grp_Orientation.SuspendLayout();
            this.grp_PaperSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SelectPrintTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_Orientation
            // 
            this.grp_Orientation.Controls.Add(this.rdb_Landscape);
            this.grp_Orientation.Controls.Add(this.rdb_Portrait);
            this.grp_Orientation.Location = new System.Drawing.Point(164, 39);
            this.grp_Orientation.Name = "grp_Orientation";
            this.grp_Orientation.Size = new System.Drawing.Size(208, 34);
            this.grp_Orientation.TabIndex = 16;
            this.grp_Orientation.TabStop = false;
            this.grp_Orientation.Text = "Orientation";
            // 
            // rdb_Landscape
            // 
            this.rdb_Landscape.AutoSize = true;
            this.rdb_Landscape.Location = new System.Drawing.Point(107, 14);
            this.rdb_Landscape.Name = "rdb_Landscape";
            this.rdb_Landscape.Size = new System.Drawing.Size(78, 17);
            this.rdb_Landscape.TabIndex = 7;
            this.rdb_Landscape.TabStop = true;
            this.rdb_Landscape.Text = "Landscape";
            this.rdb_Landscape.UseVisualStyleBackColor = true;
            // 
            // rdb_Portrait
            // 
            this.rdb_Portrait.AutoSize = true;
            this.rdb_Portrait.Location = new System.Drawing.Point(6, 14);
            this.rdb_Portrait.Name = "rdb_Portrait";
            this.rdb_Portrait.Size = new System.Drawing.Size(58, 17);
            this.rdb_Portrait.TabIndex = 6;
            this.rdb_Portrait.TabStop = true;
            this.rdb_Portrait.Text = "Portrait";
            this.rdb_Portrait.UseVisualStyleBackColor = true;
            // 
            // lbl_Language
            // 
            this.lbl_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Language.Location = new System.Drawing.Point(355, 50);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(98, 20);
            this.lbl_Language.TabIndex = 18;
            this.lbl_Language.Text = "Language";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(460, 49);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(187, 21);
            this.cmb_Language.TabIndex = 17;
            this.cmb_Language.SelectedValueChanged += new System.EventHandler(this.cmb_Language_SelectedValueChanged);
            // 
            // grp_PaperSize
            // 
            this.grp_PaperSize.Controls.Add(this.rdb_80);
            this.grp_PaperSize.Controls.Add(this.rdb_58);
            this.grp_PaperSize.Controls.Add(this.rdb_A4);
            this.grp_PaperSize.Location = new System.Drawing.Point(2, 38);
            this.grp_PaperSize.Name = "grp_PaperSize";
            this.grp_PaperSize.Size = new System.Drawing.Size(156, 98);
            this.grp_PaperSize.TabIndex = 15;
            this.grp_PaperSize.TabStop = false;
            this.grp_PaperSize.Text = "Paper Size";
            // 
            // rdb_80
            // 
            this.rdb_80.AutoSize = true;
            this.rdb_80.Location = new System.Drawing.Point(6, 44);
            this.rdb_80.Name = "rdb_80";
            this.rdb_80.Size = new System.Drawing.Size(77, 17);
            this.rdb_80.TabIndex = 7;
            this.rdb_80.TabStop = true;
            this.rdb_80.Text = "Roll 80 mm";
            this.rdb_80.UseVisualStyleBackColor = true;
            // 
            // rdb_58
            // 
            this.rdb_58.AutoSize = true;
            this.rdb_58.Location = new System.Drawing.Point(6, 71);
            this.rdb_58.Name = "rdb_58";
            this.rdb_58.Size = new System.Drawing.Size(77, 17);
            this.rdb_58.TabIndex = 8;
            this.rdb_58.TabStop = true;
            this.rdb_58.Text = "Roll 58 mm";
            this.rdb_58.UseVisualStyleBackColor = true;
            // 
            // rdb_A4
            // 
            this.rdb_A4.AutoSize = true;
            this.rdb_A4.Location = new System.Drawing.Point(6, 17);
            this.rdb_A4.Name = "rdb_A4";
            this.rdb_A4.Size = new System.Drawing.Size(38, 17);
            this.rdb_A4.TabIndex = 6;
            this.rdb_A4.TabStop = true;
            this.rdb_A4.Text = "A4";
            this.rdb_A4.UseVisualStyleBackColor = true;
            // 
            // lbl_Template
            // 
            this.lbl_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Template.Location = new System.Drawing.Point(164, 81);
            this.lbl_Template.Name = "lbl_Template";
            this.lbl_Template.Size = new System.Drawing.Size(101, 20);
            this.lbl_Template.TabIndex = 13;
            this.lbl_Template.Text = "Template";
            this.lbl_Template.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_EditTemplates
            // 
            this.btn_EditTemplates.Image = global::TangentaPrint.Properties.Resources.Edit;
            this.btn_EditTemplates.Location = new System.Drawing.Point(271, 77);
            this.btn_EditTemplates.Name = "btn_EditTemplates";
            this.btn_EditTemplates.Size = new System.Drawing.Size(43, 29);
            this.btn_EditTemplates.TabIndex = 14;
            this.btn_EditTemplates.UseVisualStyleBackColor = true;
            this.btn_EditTemplates.Click += new System.EventHandler(this.btn_EditTemplates_Click);
            // 
            // cmb_SelectPrinter
            // 
            this.cmb_SelectPrinter.FormattingEnabled = true;
            this.cmb_SelectPrinter.Location = new System.Drawing.Point(127, 9);
            this.cmb_SelectPrinter.Name = "cmb_SelectPrinter";
            this.cmb_SelectPrinter.Size = new System.Drawing.Size(353, 21);
            this.cmb_SelectPrinter.TabIndex = 20;
            // 
            // lbl_printer
            // 
            this.lbl_printer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_printer.Location = new System.Drawing.Point(2, 10);
            this.lbl_printer.Name = "lbl_printer";
            this.lbl_printer.Size = new System.Drawing.Size(119, 20);
            this.lbl_printer.TabIndex = 21;
            this.lbl_printer.Text = "Printer";
            this.lbl_printer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_SelectPrinter
            // 
            this.btn_SelectPrinter.Location = new System.Drawing.Point(486, 9);
            this.btn_SelectPrinter.Name = "btn_SelectPrinter";
            this.btn_SelectPrinter.Size = new System.Drawing.Size(170, 23);
            this.btn_SelectPrinter.TabIndex = 22;
            this.btn_SelectPrinter.Text = "Select printer";
            this.btn_SelectPrinter.UseVisualStyleBackColor = true;
            this.btn_SelectPrinter.Click += new System.EventHandler(this.btn_SelectPrinter_Click);
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Location = new System.Drawing.Point(274, 109);
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(419, 20);
            this.txt_Description.TabIndex = 24;
            // 
            // lbl_Description
            // 
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Description.Location = new System.Drawing.Point(162, 110);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(101, 20);
            this.lbl_Description.TabIndex = 23;
            this.lbl_Description.Text = "Description";
            this.lbl_Description.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_SelectPrintTemplate
            // 
            this.cmb_SelectPrintTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_SelectPrintTemplate.DropDownFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmb_SelectPrintTemplate.Location = new System.Drawing.Point(320, 82);
            this.cmb_SelectPrintTemplate.Name = "cmb_SelectPrintTemplate";
            this.cmb_SelectPrintTemplate.Size = new System.Drawing.Size(268, 21);
            this.cmb_SelectPrintTemplate.TabIndex = 25;
            this.cmb_SelectPrintTemplate.Text = "cmb_SelectPrintTemplate";
            // 
            // chk_Default
            // 
            this.chk_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Default.AutoSize = true;
            this.chk_Default.Location = new System.Drawing.Point(595, 85);
            this.chk_Default.Name = "chk_Default";
            this.chk_Default.Size = new System.Drawing.Size(60, 17);
            this.chk_Default.TabIndex = 26;
            this.chk_Default.Text = "Default";
            this.chk_Default.UseVisualStyleBackColor = true;
            // 
            // usrc_SelectPrintTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk_Default);
            this.Controls.Add(this.cmb_SelectPrintTemplate);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.lbl_Description);
            this.Controls.Add(this.btn_SelectPrinter);
            this.Controls.Add(this.lbl_printer);
            this.Controls.Add(this.cmb_SelectPrinter);
            this.Controls.Add(this.grp_Orientation);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.grp_PaperSize);
            this.Controls.Add(this.btn_EditTemplates);
            this.Controls.Add(this.lbl_Template);
            this.Name = "usrc_SelectPrintTemplate";
            this.Size = new System.Drawing.Size(696, 135);
            this.grp_Orientation.ResumeLayout(false);
            this.grp_Orientation.PerformLayout();
            this.grp_PaperSize.ResumeLayout(false);
            this.grp_PaperSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SelectPrintTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_Orientation;
        private System.Windows.Forms.RadioButton rdb_Landscape;
        private System.Windows.Forms.RadioButton rdb_Portrait;
        private System.Windows.Forms.Label lbl_Language;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.GroupBox grp_PaperSize;
        private System.Windows.Forms.RadioButton rdb_80;
        private System.Windows.Forms.RadioButton rdb_58;
        private System.Windows.Forms.RadioButton rdb_A4;
        private System.Windows.Forms.Button btn_EditTemplates;
        private System.Windows.Forms.Label lbl_Template;
        private System.Windows.Forms.ComboBox cmb_SelectPrinter;
        private System.Windows.Forms.Label lbl_printer;
        private System.Windows.Forms.Button btn_SelectPrinter;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label lbl_Description;
        private EWSoftware.ListControls.MultiColumnComboBox cmb_SelectPrintTemplate;
        private System.Windows.Forms.CheckBox chk_Default;
    }
}
