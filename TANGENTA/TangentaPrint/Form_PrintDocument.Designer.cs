using DBTypes;
using FastColoredTextBoxNS;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PrintDocument));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_usrc_Invoice_Preview = new TangentaPrint.usrc_Invoice_Preview();
            this.textEditorControl1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_SaveTemplate = new System.Windows.Forms.Button();
            this.chk_EditTemplate = new System.Windows.Forms.CheckBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.m_usrc_SelectPrintTemplate = new TangentaPrint.usrc_SelectPrintTemplate();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditorControl1)).BeginInit();
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
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_usrc_Invoice_Preview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1027, 521);
            this.splitContainer1.SplitterDistance = 523;
            this.splitContainer1.TabIndex = 5;
            // 
            // m_usrc_Invoice_Preview
            // 
            this.m_usrc_Invoice_Preview.AutoScroll = true;
            this.m_usrc_Invoice_Preview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_usrc_Invoice_Preview.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_usrc_Invoice_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Invoice_Preview.DocumentTemplate = new byte[] {
        ((byte)(68)),
        ((byte)(0)),
        ((byte)(111)),
        ((byte)(0)),
        ((byte)(99)),
        ((byte)(0)),
        ((byte)(117)),
        ((byte)(0)),
        ((byte)(109)),
        ((byte)(0)),
        ((byte)(101)),
        ((byte)(0)),
        ((byte)(110)),
        ((byte)(0)),
        ((byte)(116)),
        ((byte)(0)),
        ((byte)(32)),
        ((byte)(0)),
        ((byte)(84)),
        ((byte)(0)),
        ((byte)(101)),
        ((byte)(0)),
        ((byte)(109)),
        ((byte)(0)),
        ((byte)(112)),
        ((byte)(0)),
        ((byte)(108)),
        ((byte)(0)),
        ((byte)(97)),
        ((byte)(0)),
        ((byte)(116)),
        ((byte)(0)),
        ((byte)(101)),
        ((byte)(0)),
        ((byte)(32)),
        ((byte)(0)),
        ((byte)(110)),
        ((byte)(0)),
        ((byte)(111)),
        ((byte)(0)),
        ((byte)(116)),
        ((byte)(0)),
        ((byte)(32)),
        ((byte)(0)),
        ((byte)(115)),
        ((byte)(0)),
        ((byte)(101)),
        ((byte)(0)),
        ((byte)(116)),
        ((byte)(0))};
            this.m_usrc_Invoice_Preview.html_doc_template_text = "Document Template not set";
            this.m_usrc_Invoice_Preview.html_doc_text = "Error can not decode template!";
            this.m_usrc_Invoice_Preview.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Invoice_Preview.Name = "m_usrc_Invoice_Preview";
            this.m_usrc_Invoice_Preview.Size = new System.Drawing.Size(523, 521);
            this.m_usrc_Invoice_Preview.TabIndex = 0;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textEditorControl1.AutoIndentCharsPatterns = "";
            this.textEditorControl1.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.textEditorControl1.BackBrush = null;
            this.textEditorControl1.CharHeight = 14;
            this.textEditorControl1.CharWidth = 8;
            this.textEditorControl1.CommentPrefix = null;
            this.textEditorControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textEditorControl1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.textEditorControl1.IsReplaceMode = false;
            this.textEditorControl1.Language = FastColoredTextBoxNS.Language.HTML;
            this.textEditorControl1.LeftBracket = '<';
            this.textEditorControl1.LeftBracket2 = '(';
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Paddings = new System.Windows.Forms.Padding(0);
            this.textEditorControl1.RightBracket = '>';
            this.textEditorControl1.RightBracket2 = ')';
            this.textEditorControl1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textEditorControl1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textEditorControl1.ServiceColors")));
            this.textEditorControl1.Size = new System.Drawing.Size(500, 521);
            this.textEditorControl1.TabIndex = 1;
            this.textEditorControl1.Text = "fastColoredTextBox1";
            this.textEditorControl1.Zoom = 100;
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
            this.btn_SaveTemplate.Location = new System.Drawing.Point(873, 140);
            this.btn_SaveTemplate.Name = "btn_SaveTemplate";
            this.btn_SaveTemplate.Size = new System.Drawing.Size(156, 27);
            this.btn_SaveTemplate.TabIndex = 8;
            this.btn_SaveTemplate.Text = "Save Template";
            this.btn_SaveTemplate.UseVisualStyleBackColor = true;
            this.btn_SaveTemplate.Click += new System.EventHandler(this.btn_SaveTemplate_Click);
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
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Location = new System.Drawing.Point(888, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(101, 34);
            this.btn_Exit.TabIndex = 11;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(995, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(45, 34);
            this.usrc_Help1.TabIndex = 12;
            // 
            // m_usrc_SelectPrintTemplate
            // 
            this.m_usrc_SelectPrintTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_SelectPrintTemplate.doc_TemplateDescription = null;
            this.m_usrc_SelectPrintTemplate.doc_TemplateName = "";
            this.m_usrc_SelectPrintTemplate.Doc_v = null;
            this.m_usrc_SelectPrintTemplate.f_doc_bActive = false;
            this.m_usrc_SelectPrintTemplate.f_doc_bCompressed = false;
            this.m_usrc_SelectPrintTemplate.f_doc_bDefault = false;
            this.m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v = null;
            this.m_usrc_SelectPrintTemplate.f_doc_xDocument_Hash = null;
            this.m_usrc_SelectPrintTemplate.Location = new System.Drawing.Point(2, 2);
            this.m_usrc_SelectPrintTemplate.Name = "m_usrc_SelectPrintTemplate";
            this.m_usrc_SelectPrintTemplate.Size = new System.Drawing.Size(1038, 132);
            this.m_usrc_SelectPrintTemplate.TabIndex = 9;
            // 
            // Form_PrintDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1041, 695);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.chk_EditTemplate);
            this.Controls.Add(this.btn_SaveTemplate);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.m_usrc_SelectPrintTemplate);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_PrintDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_SelectTemplate_Load);
            this.Shown += new System.EventHandler(this.Form_PrintDocument_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditorControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_SaveTemplate;
        private usrc_SelectPrintTemplate m_usrc_SelectPrintTemplate;
        private System.Windows.Forms.CheckBox chk_EditTemplate;
        private usrc_Invoice_Preview m_usrc_Invoice_Preview;
        private System.Windows.Forms.Button btn_Exit;
        private FastColoredTextBoxNS.FastColoredTextBox textEditorControl1;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}