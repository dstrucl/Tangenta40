using DBTypes;

namespace TangentaPrint
{
    partial class Form_SelectTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectTemplate));
            this.lbl_Template = new System.Windows.Forms.Label();
            this.txt_Template = new System.Windows.Forms.TextBox();
            this.btn_Select_Template = new System.Windows.Forms.Button();
            this.btn_EditTemplates = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textEditorControl1 = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.rdb_A4 = new System.Windows.Forms.RadioButton();
            this.rdb_80 = new System.Windows.Forms.RadioButton();
            this.rdb_58 = new System.Windows.Forms.RadioButton();
            this.grp_PaperSize = new System.Windows.Forms.GroupBox();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.lbl_Language = new System.Windows.Forms.Label();
            this.grp_Orientation = new System.Windows.Forms.GroupBox();
            this.rdb_Portrait = new System.Windows.Forms.RadioButton();
            this.rdb_Landscape = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_PaperSize.SuspendLayout();
            this.grp_Orientation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Template
            // 
            this.lbl_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Template.Location = new System.Drawing.Point(161, 48);
            this.lbl_Template.Name = "lbl_Template";
            this.lbl_Template.Size = new System.Drawing.Size(98, 20);
            this.lbl_Template.TabIndex = 1;
            this.lbl_Template.Text = "Template";
            this.lbl_Template.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Template
            // 
            this.txt_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Template.Location = new System.Drawing.Point(314, 45);
            this.txt_Template.Name = "txt_Template";
            this.txt_Template.Size = new System.Drawing.Size(277, 26);
            this.txt_Template.TabIndex = 2;
            // 
            // btn_Select_Template
            // 
            this.btn_Select_Template.Image = global::TangentaPrint.Properties.Resources.SelectRow;
            this.btn_Select_Template.Location = new System.Drawing.Point(597, 43);
            this.btn_Select_Template.Name = "btn_Select_Template";
            this.btn_Select_Template.Size = new System.Drawing.Size(60, 29);
            this.btn_Select_Template.TabIndex = 3;
            this.btn_Select_Template.UseVisualStyleBackColor = true;
            this.btn_Select_Template.Click += new System.EventHandler(this.btn_Select_Template_Click);
            // 
            // btn_EditTemplates
            // 
            this.btn_EditTemplates.Image = global::TangentaPrint.Properties.Resources.Edit;
            this.btn_EditTemplates.Location = new System.Drawing.Point(265, 43);
            this.btn_EditTemplates.Name = "btn_EditTemplates";
            this.btn_EditTemplates.Size = new System.Drawing.Size(43, 29);
            this.btn_EditTemplates.TabIndex = 4;
            this.btn_EditTemplates.UseVisualStyleBackColor = true;
            this.btn_EditTemplates.Click += new System.EventHandler(this.btn_EditTemplates_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 105);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControl1);
            this.splitContainer1.Size = new System.Drawing.Size(870, 499);
            this.splitContainer1.SplitterDistance = 444;
            this.splitContainer1.TabIndex = 5;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(422, 499);
            this.textEditorControl1.TabIndex = 0;
            this.textEditorControl1.Text = "textEditorControl1";
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
            // grp_PaperSize
            // 
            this.grp_PaperSize.Controls.Add(this.rdb_80);
            this.grp_PaperSize.Controls.Add(this.rdb_58);
            this.grp_PaperSize.Controls.Add(this.rdb_A4);
            this.grp_PaperSize.Location = new System.Drawing.Point(12, 1);
            this.grp_PaperSize.Name = "grp_PaperSize";
            this.grp_PaperSize.Size = new System.Drawing.Size(156, 98);
            this.grp_PaperSize.TabIndex = 9;
            this.grp_PaperSize.TabStop = false;
            this.grp_PaperSize.Text = "Paper Size";
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(470, 12);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(187, 21);
            this.cmb_Language.TabIndex = 10;
            // 
            // lbl_Language
            // 
            this.lbl_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Language.Location = new System.Drawing.Point(365, 13);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(98, 20);
            this.lbl_Language.TabIndex = 11;
            this.lbl_Language.Text = "Language";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grp_Orientation
            // 
            this.grp_Orientation.Controls.Add(this.rdb_Landscape);
            this.grp_Orientation.Controls.Add(this.rdb_Portrait);
            this.grp_Orientation.Location = new System.Drawing.Point(174, 1);
            this.grp_Orientation.Name = "grp_Orientation";
            this.grp_Orientation.Size = new System.Drawing.Size(208, 34);
            this.grp_Orientation.TabIndex = 10;
            this.grp_Orientation.TabStop = false;
            this.grp_Orientation.Text = "Orientation";
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
            // Form_SelectTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(884, 605);
            this.Controls.Add(this.grp_Orientation);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.grp_PaperSize);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_EditTemplates);
            this.Controls.Add(this.btn_Select_Template);
            this.Controls.Add(this.txt_Template);
            this.Controls.Add(this.lbl_Template);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SelectTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_SelectTemplate_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grp_PaperSize.ResumeLayout(false);
            this.grp_PaperSize.PerformLayout();
            this.grp_Orientation.ResumeLayout(false);
            this.grp_Orientation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Template;
        private System.Windows.Forms.TextBox txt_Template;
        private System.Windows.Forms.Button btn_Select_Template;
        private System.Windows.Forms.Button btn_EditTemplates;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DigitalRune.Windows.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.RadioButton rdb_A4;
        private System.Windows.Forms.RadioButton rdb_80;
        private System.Windows.Forms.RadioButton rdb_58;
        private System.Windows.Forms.GroupBox grp_PaperSize;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.Label lbl_Language;
        private System.Windows.Forms.GroupBox grp_Orientation;
        private System.Windows.Forms.RadioButton rdb_Landscape;
        private System.Windows.Forms.RadioButton rdb_Portrait;
    }
}