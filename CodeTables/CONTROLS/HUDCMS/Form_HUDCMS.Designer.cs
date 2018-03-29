using FastColoredTextBoxNS;

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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MyTreeListView = new BrightIdeasSoftware.TreeListView();
            this.olvc_ControlType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlLinks = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_HelpTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlUniqueName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.usrc_SelectHtmlFile = new SelectFile.usrc_SelectFile();
            this.cmbr_GeneralHelpFiles = new ComboBox_Recent.ComboBox_RecentList();
            this.lbl_GeneralHelp = new System.Windows.Forms.Label();
            this.btn_EditGeneralHelpFile = new System.Windows.Forms.Button();
            this.btn_EditGeneralStyles = new System.Windows.Forms.Button();
            this.lbl_GeneralStyles = new System.Windows.Forms.Label();
            this.cmbr_GeneralStyleFiles = new ComboBox_Recent.ComboBox_RecentList();
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
            this.grp_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_Header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).BeginInit();
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
            this.grp_Style.Size = new System.Drawing.Size(677, 68);
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
            this.usrc_SelectStyleFile.Size = new System.Drawing.Size(659, 27);
            this.usrc_SelectStyleFile.TabIndex = 0;
            this.usrc_SelectStyleFile.Title = "Save File";
            this.usrc_SelectStyleFile.EditFile += new SelectFile.usrc_SelectFile.delegate_EditFile(this.usrc_SelectStyleFile_EditFile);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(2, 83);
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
            this.splitContainer1.Size = new System.Drawing.Size(1080, 552);
            this.splitContainer1.SplitterDistance = 688;
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
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(672, 470);
            this.splitContainer2.SplitterDistance = 90;
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
            this.grp_Header.Size = new System.Drawing.Size(672, 90);
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
            this.fctb_Header.Size = new System.Drawing.Size(668, 65);
            this.fctb_Header.TabIndex = 0;
            this.fctb_Header.Text = "fctb_Header";
            this.fctb_Header.Zoom = 100;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.MyTreeListView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(672, 374);
            this.splitContainer3.SplitterDistance = 183;
            this.splitContainer3.TabIndex = 8;
            // 
            // MyTreeListView
            // 
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlType);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlName);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlImage);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlLinks);
            this.MyTreeListView.AllColumns.Add(this.olvc_HelpTitle);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlUniqueName);
            this.MyTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvc_ControlType,
            this.olvc_ControlName,
            this.olvc_ControlImage,
            this.olvc_ControlLinks,
            this.olvc_HelpTitle,
            this.olvc_ControlUniqueName});
            this.MyTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyTreeListView.Location = new System.Drawing.Point(0, 0);
            this.MyTreeListView.MultiSelect = false;
            this.MyTreeListView.Name = "MyTreeListView";
            this.MyTreeListView.OwnerDraw = true;
            this.MyTreeListView.ShowGroups = false;
            this.MyTreeListView.ShowImagesOnSubItems = true;
            this.MyTreeListView.Size = new System.Drawing.Size(672, 374);
            this.MyTreeListView.TabIndex = 0;
            this.MyTreeListView.UseCompatibleStateImageBehavior = false;
            this.MyTreeListView.View = System.Windows.Forms.View.Details;
            this.MyTreeListView.VirtualMode = true;
            this.MyTreeListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.MyTreeListView_CellRightClick);
            this.MyTreeListView.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.MyTreeListView_SubItemChecking);
            this.MyTreeListView.SelectedIndexChanged += new System.EventHandler(this.MyTreeListView_SelectedIndexChanged);
            // 
            // olvc_ControlType
            // 
            this.olvc_ControlType.AspectName = "ControlType";
            this.olvc_ControlType.Text = "Control Type";
            this.olvc_ControlType.Width = 245;
            // 
            // olvc_ControlName
            // 
            this.olvc_ControlName.AspectName = "ControlName";
            this.olvc_ControlName.Text = "Control Name";
            this.olvc_ControlName.UseInitialLetterForGroup = true;
            this.olvc_ControlName.Width = 180;
            this.olvc_ControlName.WordWrap = true;
            // 
            // olvc_ControlImage
            // 
            this.olvc_ControlImage.AspectName = "ControlImage";
            this.olvc_ControlImage.Text = "Control Image";
            this.olvc_ControlImage.Width = 107;
            // 
            // olvc_ControlLinks
            // 
            this.olvc_ControlLinks.AspectName = "ControlLink";
            this.olvc_ControlLinks.Text = "Link";
            this.olvc_ControlLinks.UseInitialLetterForGroup = true;
            this.olvc_ControlLinks.Width = 40;
            this.olvc_ControlLinks.WordWrap = true;
            // 
            // olvc_HelpTitle
            // 
            this.olvc_HelpTitle.AspectName = "HelpTitle";
            this.olvc_HelpTitle.Text = "Help Title";
            this.olvc_HelpTitle.UseInitialLetterForGroup = true;
            this.olvc_HelpTitle.Width = 360;
            this.olvc_HelpTitle.WordWrap = true;
            // 
            // olvc_ControlUniqueName
            // 
            this.olvc_ControlUniqueName.AspectName = "ControlUniqueName";
            this.olvc_ControlUniqueName.Text = "Control Unique Name";
            this.olvc_ControlUniqueName.UseInitialLetterForGroup = true;
            this.olvc_ControlUniqueName.Width = 360;
            this.olvc_ControlUniqueName.WordWrap = true;
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
            this.panel1.Size = new System.Drawing.Size(150, 46);
            this.panel1.TabIndex = 7;
            // 
            // usrc_SelectHtmlFile
            // 
            this.usrc_SelectHtmlFile.DefaultExtension = "txt";
            this.usrc_SelectHtmlFile.FileName = "";
            this.usrc_SelectHtmlFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectHtmlFile.InitialDirectory = "C:\\";
            this.usrc_SelectHtmlFile.Location = new System.Drawing.Point(11, 55);
            this.usrc_SelectHtmlFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectHtmlFile.Name = "usrc_SelectHtmlFile";
            this.usrc_SelectHtmlFile.Size = new System.Drawing.Size(1011, 26);
            this.usrc_SelectHtmlFile.TabIndex = 9;
            this.usrc_SelectHtmlFile.Title = "Save File";
            this.usrc_SelectHtmlFile.SaveFile += new SelectFile.usrc_SelectFile.delegate_SaveFile(this.usrc_SelectHtmlFile_SaveFile);
            this.usrc_SelectHtmlFile.EditFile += new SelectFile.usrc_SelectFile.delegate_EditFile(this.usrc_SelectHtmlFile_EditFile);
            this.usrc_SelectHtmlFile.Load += new System.EventHandler(this.usrc_SelectHtmlFile_Load);
            // 
            // cmbr_GeneralHelpFiles
            // 
            this.cmbr_GeneralHelpFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbr_GeneralHelpFiles.AskToCreateRecentItemsFolder = false;
            this.cmbr_GeneralHelpFiles.DisplayMember = "text";
            this.cmbr_GeneralHelpFiles.DisplayTime = true;
            this.cmbr_GeneralHelpFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbr_GeneralHelpFiles.FormattingEnabled = true;
            this.cmbr_GeneralHelpFiles.InsertOnKeyPress = true;
            this.cmbr_GeneralHelpFiles.Key = null;
            this.cmbr_GeneralHelpFiles.Location = new System.Drawing.Point(113, 4);
            this.cmbr_GeneralHelpFiles.MaxRecentCount = 10;
            this.cmbr_GeneralHelpFiles.Name = "cmbr_GeneralHelpFiles";
            this.cmbr_GeneralHelpFiles.ReadOnly = false;
            this.cmbr_GeneralHelpFiles.RecentItemsFileName = null;
            this.cmbr_GeneralHelpFiles.RecentItemsFolder = "";
            this.cmbr_GeneralHelpFiles.Size = new System.Drawing.Size(940, 21);
            this.cmbr_GeneralHelpFiles.TabIndex = 10;
            // 
            // lbl_GeneralHelp
            // 
            this.lbl_GeneralHelp.AutoSize = true;
            this.lbl_GeneralHelp.Location = new System.Drawing.Point(10, 7);
            this.lbl_GeneralHelp.Name = "lbl_GeneralHelp";
            this.lbl_GeneralHelp.Size = new System.Drawing.Size(96, 13);
            this.lbl_GeneralHelp.TabIndex = 11;
            this.lbl_GeneralHelp.Text = "General Help Files:";
            // 
            // btn_EditGeneralHelpFile
            // 
            this.btn_EditGeneralHelpFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditGeneralHelpFile.Location = new System.Drawing.Point(1059, 2);
            this.btn_EditGeneralHelpFile.Name = "btn_EditGeneralHelpFile";
            this.btn_EditGeneralHelpFile.Size = new System.Drawing.Size(75, 23);
            this.btn_EditGeneralHelpFile.TabIndex = 12;
            this.btn_EditGeneralHelpFile.Text = "Edit";
            this.btn_EditGeneralHelpFile.UseVisualStyleBackColor = true;
            this.btn_EditGeneralHelpFile.Click += new System.EventHandler(this.btn_EditGeneralHelpFile_Click);
            // 
            // btn_EditGeneralStyles
            // 
            this.btn_EditGeneralStyles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditGeneralStyles.Location = new System.Drawing.Point(1059, 29);
            this.btn_EditGeneralStyles.Name = "btn_EditGeneralStyles";
            this.btn_EditGeneralStyles.Size = new System.Drawing.Size(75, 23);
            this.btn_EditGeneralStyles.TabIndex = 15;
            this.btn_EditGeneralStyles.Text = "Edit";
            this.btn_EditGeneralStyles.UseVisualStyleBackColor = true;
            this.btn_EditGeneralStyles.Click += new System.EventHandler(this.btn_EditGeneralStyles_Click);
            // 
            // lbl_GeneralStyles
            // 
            this.lbl_GeneralStyles.AutoSize = true;
            this.lbl_GeneralStyles.Location = new System.Drawing.Point(10, 32);
            this.lbl_GeneralStyles.Name = "lbl_GeneralStyles";
            this.lbl_GeneralStyles.Size = new System.Drawing.Size(94, 13);
            this.lbl_GeneralStyles.TabIndex = 14;
            this.lbl_GeneralStyles.Text = "General Style files:";
            // 
            // cmbr_GeneralStyleFiles
            // 
            this.cmbr_GeneralStyleFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbr_GeneralStyleFiles.AskToCreateRecentItemsFolder = false;
            this.cmbr_GeneralStyleFiles.DisplayMember = "text";
            this.cmbr_GeneralStyleFiles.DisplayTime = true;
            this.cmbr_GeneralStyleFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbr_GeneralStyleFiles.FormattingEnabled = true;
            this.cmbr_GeneralStyleFiles.InsertOnKeyPress = true;
            this.cmbr_GeneralStyleFiles.Key = null;
            this.cmbr_GeneralStyleFiles.Location = new System.Drawing.Point(113, 29);
            this.cmbr_GeneralStyleFiles.MaxRecentCount = 10;
            this.cmbr_GeneralStyleFiles.Name = "cmbr_GeneralStyleFiles";
            this.cmbr_GeneralStyleFiles.ReadOnly = false;
            this.cmbr_GeneralStyleFiles.RecentItemsFileName = null;
            this.cmbr_GeneralStyleFiles.RecentItemsFolder = "";
            this.cmbr_GeneralStyleFiles.Size = new System.Drawing.Size(940, 21);
            this.cmbr_GeneralStyleFiles.TabIndex = 13;
            // 
            // usrc_EditControl1
            // 
            this.usrc_EditControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_EditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditControl1.Enabled = false;
            this.usrc_EditControl1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditControl1.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_EditControl1.Name = "usrc_EditControl1";
            this.usrc_EditControl1.Size = new System.Drawing.Size(383, 548);
            this.usrc_EditControl1.SnapShotMargin = 4;
            this.usrc_EditControl1.TabIndex = 1;
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(960, 822);
            this.Controls.Add(this.btn_EditGeneralStyles);
            this.Controls.Add(this.lbl_GeneralStyles);
            this.Controls.Add(this.cmbr_GeneralStyleFiles);
            this.Controls.Add(this.btn_EditGeneralHelpFile);
            this.Controls.Add(this.lbl_GeneralHelp);
            this.Controls.Add(this.cmbr_GeneralHelpFiles);
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
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ComboBox_Recent.ComboBox_RecentList cmbr_GeneralHelpFiles;
        private System.Windows.Forms.Label lbl_GeneralHelp;
        private System.Windows.Forms.Button btn_EditGeneralHelpFile;
        private System.Windows.Forms.Button btn_EditGeneralStyles;
        private System.Windows.Forms.Label lbl_GeneralStyles;
        private ComboBox_Recent.ComboBox_RecentList cmbr_GeneralStyleFiles;
        private System.Windows.Forms.SplitContainer splitContainer3;
        internal BrightIdeasSoftware.TreeListView MyTreeListView;
        private BrightIdeasSoftware.OLVColumn olvc_ControlUniqueName;
        private BrightIdeasSoftware.OLVColumn olvc_ControlType;
        private BrightIdeasSoftware.OLVColumn olvc_ControlImage;
        private BrightIdeasSoftware.OLVColumn olvc_ControlName;
        private BrightIdeasSoftware.OLVColumn olvc_HelpTitle;
        private BrightIdeasSoftware.OLVColumn olvc_ControlLinks;
    }
}