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
            this.btn_Create = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.usrc_SelectHtmlFile = new SelectFile.usrc_SelectFile();
            this.usrc_EditControl1 = new HUDCMS.usrc_EditControl();
            this.grp_Style.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_Style
            // 
            this.grp_Style.Controls.Add(this.usrc_SelectStyleFile);
            this.grp_Style.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grp_Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Style.Location = new System.Drawing.Point(9, 2);
            this.grp_Style.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Style.Name = "grp_Style";
            this.grp_Style.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Style.Size = new System.Drawing.Size(535, 85);
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
            this.usrc_SelectStyleFile.Location = new System.Drawing.Point(15, 34);
            this.usrc_SelectStyleFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectStyleFile.Name = "usrc_SelectStyleFile";
            this.usrc_SelectStyleFile.Size = new System.Drawing.Size(512, 25);
            this.usrc_SelectStyleFile.TabIndex = 0;
            this.usrc_SelectStyleFile.Title = "Save File";
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Create.Location = new System.Drawing.Point(1148, 12);
            this.btn_Create.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(121, 50);
            this.btn_Create.TabIndex = 7;
            this.btn_Create.Text = "CREATE";
            this.btn_Create.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(2, 74);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.grp_Style);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1278, 640);
            this.splitContainer1.SplitterDistance = 553;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(9, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 538);
            this.panel1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.usrc_EditControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fctb);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(715, 636);
            this.splitContainer2.SplitterDistance = 383;
            this.splitContainer2.TabIndex = 1;
            // 
            // fctb
            // 
            this.fctb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb.AutoCompleteBracketsList = new char[] {
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
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 18;
            this.fctb.CharWidth = 10;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(2, 42);
            this.fctb.Margin = new System.Windows.Forms.Padding(2);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(711, 156);
            this.fctb.TabIndex = 0;
            this.fctb.Text = "fastColoredTextBox1";
            this.fctb.Zoom = 100;
            // 
            // usrc_SelectHtmlFile
            // 
            this.usrc_SelectHtmlFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectHtmlFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.usrc_SelectHtmlFile.DefaultExtension = "css";
            this.usrc_SelectHtmlFile.FileName = "";
            this.usrc_SelectHtmlFile.Filter = "Text files (*.css)|*.css|All files (*.*)|*.*";
            this.usrc_SelectHtmlFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_SelectHtmlFile.InitialDirectory = "C:\\";
            this.usrc_SelectHtmlFile.Location = new System.Drawing.Point(29, 12);
            this.usrc_SelectHtmlFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectHtmlFile.Name = "usrc_SelectHtmlFile";
            this.usrc_SelectHtmlFile.Size = new System.Drawing.Size(1112, 34);
            this.usrc_SelectHtmlFile.TabIndex = 6;
            this.usrc_SelectHtmlFile.Title = "Save Style File";
            // 
            // usrc_EditControl1
            // 
            this.usrc_EditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditControl1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditControl1.Name = "usrc_EditControl1";
            this.usrc_EditControl1.Size = new System.Drawing.Size(715, 383);
            this.usrc_EditControl1.TabIndex = 0;
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1281, 714);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.usrc_SelectHtmlFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_HUDCMS";
            this.Text = "Form_HUDCMS";
            this.grp_Style.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_Style;
        private SelectFile.usrc_SelectFile usrc_SelectHtmlFile;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Panel panel1;
        private SelectFile.usrc_SelectFile usrc_SelectStyleFile;
        private System.Windows.Forms.SplitContainer splitContainer2;
        internal usrc_EditControl usrc_EditControl1;
    }
}