﻿namespace TangentaPrint
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
            this.cmb_SelectPrintTemplate = new System.Windows.Forms.ComboBox();
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
            this.grp_Orientation.SuspendLayout();
            this.grp_PaperSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_SelectPrintTemplate
            // 
            this.cmb_SelectPrintTemplate.FormattingEnabled = true;
            this.cmb_SelectPrintTemplate.Location = new System.Drawing.Point(304, 47);
            this.cmb_SelectPrintTemplate.Name = "cmb_SelectPrintTemplate";
            this.cmb_SelectPrintTemplate.Size = new System.Drawing.Size(353, 21);
            this.cmb_SelectPrintTemplate.TabIndex = 19;
            // 
            // grp_Orientation
            // 
            this.grp_Orientation.Controls.Add(this.rdb_Landscape);
            this.grp_Orientation.Controls.Add(this.rdb_Portrait);
            this.grp_Orientation.Location = new System.Drawing.Point(165, 3);
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
            this.lbl_Language.Location = new System.Drawing.Point(356, 15);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(98, 20);
            this.lbl_Language.TabIndex = 18;
            this.lbl_Language.Text = "Language";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(461, 14);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(187, 21);
            this.cmb_Language.TabIndex = 17;
            // 
            // grp_PaperSize
            // 
            this.grp_PaperSize.Controls.Add(this.rdb_80);
            this.grp_PaperSize.Controls.Add(this.rdb_58);
            this.grp_PaperSize.Controls.Add(this.rdb_A4);
            this.grp_PaperSize.Location = new System.Drawing.Point(3, 3);
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
            this.lbl_Template.Location = new System.Drawing.Point(152, 50);
            this.lbl_Template.Name = "lbl_Template";
            this.lbl_Template.Size = new System.Drawing.Size(98, 20);
            this.lbl_Template.TabIndex = 13;
            this.lbl_Template.Text = "Template";
            this.lbl_Template.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_EditTemplates
            // 
            this.btn_EditTemplates.Image = global::TangentaPrint.Properties.Resources.Edit;
            this.btn_EditTemplates.Location = new System.Drawing.Point(256, 45);
            this.btn_EditTemplates.Name = "btn_EditTemplates";
            this.btn_EditTemplates.Size = new System.Drawing.Size(43, 29);
            this.btn_EditTemplates.TabIndex = 14;
            this.btn_EditTemplates.UseVisualStyleBackColor = true;
            // 
            // usrc_SelectPrintTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmb_SelectPrintTemplate);
            this.Controls.Add(this.grp_Orientation);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.grp_PaperSize);
            this.Controls.Add(this.btn_EditTemplates);
            this.Controls.Add(this.lbl_Template);
            this.Name = "usrc_SelectPrintTemplate";
            this.Size = new System.Drawing.Size(672, 106);
            this.grp_Orientation.ResumeLayout(false);
            this.grp_Orientation.PerformLayout();
            this.grp_PaperSize.ResumeLayout(false);
            this.grp_PaperSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_SelectPrintTemplate;
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
    }
}