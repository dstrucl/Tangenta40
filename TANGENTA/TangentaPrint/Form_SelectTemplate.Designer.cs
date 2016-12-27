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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Template
            // 
            this.lbl_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Template.Location = new System.Drawing.Point(6, 9);
            this.lbl_Template.Name = "lbl_Template";
            this.lbl_Template.Size = new System.Drawing.Size(85, 20);
            this.lbl_Template.TabIndex = 1;
            this.lbl_Template.Text = "label1";
            this.lbl_Template.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Template
            // 
            this.txt_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Template.Location = new System.Drawing.Point(147, 8);
            this.txt_Template.Name = "txt_Template";
            this.txt_Template.Size = new System.Drawing.Size(479, 26);
            this.txt_Template.TabIndex = 2;
            // 
            // btn_Select_Template
            // 
            this.btn_Select_Template.Image = global::TangentaPrint.Properties.Resources.SelectRow;
            this.btn_Select_Template.Location = new System.Drawing.Point(632, 6);
            this.btn_Select_Template.Name = "btn_Select_Template";
            this.btn_Select_Template.Size = new System.Drawing.Size(60, 29);
            this.btn_Select_Template.TabIndex = 3;
            this.btn_Select_Template.UseVisualStyleBackColor = true;
            this.btn_Select_Template.Click += new System.EventHandler(this.btn_Select_Template_Click);
            // 
            // btn_EditTemplates
            // 
            this.btn_EditTemplates.Image = global::TangentaPrint.Properties.Resources.Edit;
            this.btn_EditTemplates.Location = new System.Drawing.Point(98, 6);
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
            this.splitContainer1.Location = new System.Drawing.Point(2, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControl1);
            this.splitContainer1.Size = new System.Drawing.Size(912, 548);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.TabIndex = 5;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(442, 548);
            this.textEditorControl1.TabIndex = 0;
            this.textEditorControl1.Text = "textEditorControl1";
            // 
            // Form_SelectTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(926, 605);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_EditTemplates);
            this.Controls.Add(this.btn_Select_Template);
            this.Controls.Add(this.txt_Template);
            this.Controls.Add(this.lbl_Template);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SelectTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_Print_A4_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}