namespace HUDCMS
{
    partial class Form_HUDCMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HUDCMS));
            this.grp_Style = new System.Windows.Forms.GroupBox();
            this.usrc_SelectStyleFile = new SelectFile.usrc_SelectFile();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grp_Header = new System.Windows.Forms.GroupBox();
            this.fctb_Header = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usrc_EditControl1 = new HUDCMS.usrc_EditControl();
            this.usrc_SelectHtmlFile = new SelectFile.usrc_SelectFile();
            this.grp_Style.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grp_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_Header)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_Style
            // 
            this.grp_Style.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Style.Controls.Add(this.usrc_SelectStyleFile);
            this.grp_Style.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grp_Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Style.Location = new System.Drawing.Point(7, 2);
            this.grp_Style.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Style.Name = "grp_Style";
            this.grp_Style.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Style.Size = new System.Drawing.Size(428, 68);
            this.grp_Style.TabIndex = 6;
            this.grp_Style.TabStop = false;
            this.grp_Style.Text = "Style";
            // 
            // usrc_SelectStyleFile
            // 
            this.usrc_SelectStyleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectStyleFile.DefaultExtension = "txt";
            this.usrc_SelectStyleFile.FileName = "";
            this.usrc_SelectStyleFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectStyleFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_SelectStyleFile.InitialDirectory = "C:\\";
            this.usrc_SelectStyleFile.Location = new System.Drawing.Point(12, 27);
            this.usrc_SelectStyleFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectStyleFile.Name = "usrc_SelectStyleFile";
            this.usrc_SelectStyleFile.Size = new System.Drawing.Size(410, 27);
            this.usrc_SelectStyleFile.TabIndex = 0;
            this.usrc_SelectStyleFile.Title = "Save File";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(2, 59);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.grp_Style);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 512);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.splitContainer2.Location = new System.Drawing.Point(8, 75);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grp_Header);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(423, 430);
            this.splitContainer2.SplitterDistance = 84;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 8;
            // 
            // grp_Header
            // 
            this.grp_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grp_Header.Controls.Add(this.fctb_Header);
            this.grp_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grp_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Header.Location = new System.Drawing.Point(0, 0);
            this.grp_Header.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Header.Name = "grp_Header";
            this.grp_Header.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Header.Size = new System.Drawing.Size(423, 84);
            this.grp_Header.TabIndex = 7;
            this.grp_Header.TabStop = false;
            this.grp_Header.Text = "Header";
            // 
            // fctb_Header
            // 
            this.fctb_Header.AutoCompleteBracketsList = new char[] {
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
            this.fctb_Header.AutoIndentCharsPatterns = "";
            this.fctb_Header.AutoScrollMinSize = new System.Drawing.Size(115, 14);
            this.fctb_Header.BackBrush = null;
            this.fctb_Header.CharHeight = 14;
            this.fctb_Header.CharWidth = 8;
            this.fctb_Header.CommentPrefix = null;
            this.fctb_Header.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_Header.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb_Header.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctb_Header.IsReplaceMode = false;
            this.fctb_Header.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_Header.LeftBracket = '<';
            this.fctb_Header.LeftBracket2 = '(';
            this.fctb_Header.Location = new System.Drawing.Point(2, 23);
            this.fctb_Header.Name = "fctb_Header";
            this.fctb_Header.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_Header.RightBracket = '>';
            this.fctb_Header.RightBracket2 = ')';
            this.fctb_Header.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_Header.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_Header.ServiceColors")));
            this.fctb_Header.Size = new System.Drawing.Size(419, 59);
            this.fctb_Header.TabIndex = 0;
            this.fctb_Header.Text = "fctb_Header";
            this.fctb_Header.Zoom = 100;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 340);
            this.panel1.TabIndex = 7;
            // 
            // usrc_EditControl1
            // 
            this.usrc_EditControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_EditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditControl1.Enabled = false;
            this.usrc_EditControl1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditControl1.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_EditControl1.Name = "usrc_EditControl1";
            this.usrc_EditControl1.Size = new System.Drawing.Size(574, 508);
            this.usrc_EditControl1.SnapShotMargin = 4;
            this.usrc_EditControl1.TabIndex = 1;
            // 
            // usrc_SelectHtmlFile
            // 
            this.usrc_SelectHtmlFile.DefaultExtension = "txt";
            this.usrc_SelectHtmlFile.FileName = "";
            this.usrc_SelectHtmlFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectHtmlFile.InitialDirectory = "C:\\";
            this.usrc_SelectHtmlFile.Location = new System.Drawing.Point(11, 13);
            this.usrc_SelectHtmlFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectHtmlFile.Name = "usrc_SelectHtmlFile";
            this.usrc_SelectHtmlFile.Size = new System.Drawing.Size(1003, 27);
            this.usrc_SelectHtmlFile.TabIndex = 9;
            this.usrc_SelectHtmlFile.Title = "Save File";
            this.usrc_SelectHtmlFile.SaveFile += new SelectFile.usrc_SelectFile.delegate_SaveFile(this.usrc_SelectHtmlFile_SaveFile);
            this.usrc_SelectHtmlFile.EditFile += new SelectFile.usrc_SelectFile.delegate_EditFile(this.usrc_SelectHtmlFile_EditFile);
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1025, 571);
            this.Controls.Add(this.usrc_SelectHtmlFile);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_HUDCMS";
            this.Text = "Form_HUDCMS";
            this.Load += new System.EventHandler(this.Form_HUDCMS_Load);
            this.grp_Style.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grp_Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctb_Header)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_Style;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SelectFile.usrc_SelectFile usrc_SelectStyleFile;
        internal usrc_EditControl usrc_EditControl1;
        internal System.Windows.Forms.Panel panel1;
        internal SelectFile.usrc_SelectFile usrc_SelectHtmlFile;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grp_Header;
        private FastColoredTextBoxNS.FastColoredTextBox fctb_Header;
    }
}