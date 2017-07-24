using DBTypes;

namespace TangentaPrint
{
    partial class Form_PrintDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PrintDocument));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textEditorControl1 = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_SaveTemplate = new System.Windows.Forms.Button();
            this.m_usrc_SelectPrintTemplate = new TangentaPrint.usrc_SelectPrintTemplate();
            this.chk_EditTemplate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 173);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControl1);
            this.splitContainer1.Size = new System.Drawing.Size(870, 431);
            this.splitContainer1.SplitterDistance = 444;
            this.splitContainer1.TabIndex = 5;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(422, 431);
            this.textEditorControl1.TabIndex = 0;
            this.textEditorControl1.Text = "textEditorControl1";
            this.textEditorControl1.DocumentChanged += new System.EventHandler<DigitalRune.Windows.TextEditor.Document.DocumentEventArgs>(this.textEditorControl1_DocumentChanged);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(331, 140);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(91, 27);
            this.btn_Refresh.TabIndex = 7;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_SaveTemplate
            // 
            this.btn_SaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveTemplate.Location = new System.Drawing.Point(716, 140);
            this.btn_SaveTemplate.Name = "btn_SaveTemplate";
            this.btn_SaveTemplate.Size = new System.Drawing.Size(156, 27);
            this.btn_SaveTemplate.TabIndex = 8;
            this.btn_SaveTemplate.Text = "Save Template";
            this.btn_SaveTemplate.UseVisualStyleBackColor = true;
            this.btn_SaveTemplate.Click += new System.EventHandler(this.btn_SaveTemplate_Click);
            // 
            // m_usrc_SelectPrintTemplate
            // 
            this.m_usrc_SelectPrintTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_SelectPrintTemplate.f_doc_bActive = false;
            this.m_usrc_SelectPrintTemplate.f_doc_bCompressed = false;
            this.m_usrc_SelectPrintTemplate.f_doc_bDefault = false;
            this.m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v = null;
            this.m_usrc_SelectPrintTemplate.f_doc_TemplateDescription = null;
            this.m_usrc_SelectPrintTemplate.f_doc_TemplateName = "";
            this.m_usrc_SelectPrintTemplate.f_doc_xDocument_Hash = null;
            this.m_usrc_SelectPrintTemplate.Location = new System.Drawing.Point(2, 2);
            this.m_usrc_SelectPrintTemplate.Name = "m_usrc_SelectPrintTemplate";
            this.m_usrc_SelectPrintTemplate.Size = new System.Drawing.Size(881, 132);
            this.m_usrc_SelectPrintTemplate.TabIndex = 9;
            // 
            // chk_EditTemplate
            // 
            this.chk_EditTemplate.AutoSize = true;
            this.chk_EditTemplate.Location = new System.Drawing.Point(12, 146);
            this.chk_EditTemplate.Name = "chk_EditTemplate";
            this.chk_EditTemplate.Size = new System.Drawing.Size(91, 17);
            this.chk_EditTemplate.TabIndex = 10;
            this.chk_EditTemplate.Text = "Edit Template";
            this.chk_EditTemplate.UseVisualStyleBackColor = true;
            // 
            // Form_PrintDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(884, 605);
            this.Controls.Add(this.chk_EditTemplate);
            this.Controls.Add(this.btn_SaveTemplate);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.m_usrc_SelectPrintTemplate);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PrintDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_SelectTemplate_Load);
            this.Shown += new System.EventHandler(this.Form_PrintDocument_Shown);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DigitalRune.Windows.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_SaveTemplate;
        private usrc_SelectPrintTemplate m_usrc_SelectPrintTemplate;
        private System.Windows.Forms.CheckBox chk_EditTemplate;
    }
}