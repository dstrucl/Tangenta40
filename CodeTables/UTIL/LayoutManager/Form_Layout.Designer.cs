using FastColoredTextBoxNS;

namespace LayoutManager
{
    partial class Form_Layout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Layout));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MyTreeListView = new BrightIdeasSoftware.TreeListView();
            this.olvc_ControlType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlLinks = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_HelpTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlUniqueName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.usrc_SelectXMLFile = new SelectFile.usrc_SelectFile();
            this.btn_ViewBookmardDic = new System.Windows.Forms.Button();
            this.btn_Images = new System.Windows.Forms.Button();
            this.lbl_ScreenResolution = new System.Windows.Forms.Label();
            this.cmb_ScreenResolution = new System.Windows.Forms.ComboBox();
            this.cmb_Form = new System.Windows.Forms.ComboBox();
            this.lbl_Form = new System.Windows.Forms.Label();
            this.usrc_EditLayout1 = new LayoutManager.usrc_EditLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(2, 101);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.MyTreeListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditLayout1);
            this.splitContainer1.Size = new System.Drawing.Size(1103, 716);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
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
            this.MyTreeListView.Size = new System.Drawing.Size(410, 712);
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
            // usrc_SelectXMLFile
            // 
            this.usrc_SelectXMLFile.BackColor = System.Drawing.Color.Lime;
            this.usrc_SelectXMLFile.ButtonEditVisible = true;
            this.usrc_SelectXMLFile.ButtonSelectText = "Save";
            this.usrc_SelectXMLFile.DefaultExtension = "txt";
            this.usrc_SelectXMLFile.FileName = "";
            this.usrc_SelectXMLFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectXMLFile.InitialDirectory = "C:\\";
            this.usrc_SelectXMLFile.LabelText = "Save File";
            this.usrc_SelectXMLFile.Location = new System.Drawing.Point(2, 71);
            this.usrc_SelectXMLFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectXMLFile.Name = "usrc_SelectXMLFile";
            this.usrc_SelectXMLFile.Size = new System.Drawing.Size(956, 26);
            this.usrc_SelectXMLFile.TabIndex = 9;
            this.usrc_SelectXMLFile.Title = "Save File";
            this.usrc_SelectXMLFile.Type = SelectFile.usrc_SelectFile.eType.SAVE;
            this.usrc_SelectXMLFile.Load += new System.EventHandler(this.usrc_SelectHtmlFile_Load);
            // 
            // btn_ViewBookmardDic
            // 
            this.btn_ViewBookmardDic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ViewBookmardDic.Location = new System.Drawing.Point(1023, 72);
            this.btn_ViewBookmardDic.Name = "btn_ViewBookmardDic";
            this.btn_ViewBookmardDic.Size = new System.Drawing.Size(77, 24);
            this.btn_ViewBookmardDic.TabIndex = 20;
            this.btn_ViewBookmardDic.Text = "Bookmarks";
            this.btn_ViewBookmardDic.UseVisualStyleBackColor = true;
            this.btn_ViewBookmardDic.Click += new System.EventHandler(this.btn_ViewBookmardDic_Click);
            // 
            // btn_Images
            // 
            this.btn_Images.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Images.Location = new System.Drawing.Point(963, 72);
            this.btn_Images.Name = "btn_Images";
            this.btn_Images.Size = new System.Drawing.Size(54, 24);
            this.btn_Images.TabIndex = 21;
            this.btn_Images.Text = "Images";
            this.btn_Images.UseVisualStyleBackColor = true;
            this.btn_Images.Click += new System.EventHandler(this.btn_Images_Click);
            // 
            // lbl_ScreenResolution
            // 
            this.lbl_ScreenResolution.AutoSize = true;
            this.lbl_ScreenResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ScreenResolution.Location = new System.Drawing.Point(0, 5);
            this.lbl_ScreenResolution.Name = "lbl_ScreenResolution";
            this.lbl_ScreenResolution.Size = new System.Drawing.Size(140, 20);
            this.lbl_ScreenResolution.TabIndex = 22;
            this.lbl_ScreenResolution.Text = "Screen Resolution";
            // 
            // cmb_ScreenResolution
            // 
            this.cmb_ScreenResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_ScreenResolution.FormattingEnabled = true;
            this.cmb_ScreenResolution.Location = new System.Drawing.Point(156, 3);
            this.cmb_ScreenResolution.Name = "cmb_ScreenResolution";
            this.cmb_ScreenResolution.Size = new System.Drawing.Size(452, 28);
            this.cmb_ScreenResolution.TabIndex = 23;
            // 
            // cmb_Form
            // 
            this.cmb_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Form.FormattingEnabled = true;
            this.cmb_Form.Location = new System.Drawing.Point(156, 38);
            this.cmb_Form.Name = "cmb_Form";
            this.cmb_Form.Size = new System.Drawing.Size(452, 28);
            this.cmb_Form.TabIndex = 25;
            // 
            // lbl_Form
            // 
            this.lbl_Form.AutoSize = true;
            this.lbl_Form.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Form.Location = new System.Drawing.Point(0, 40);
            this.lbl_Form.Name = "lbl_Form";
            this.lbl_Form.Size = new System.Drawing.Size(46, 20);
            this.lbl_Form.TabIndex = 24;
            this.lbl_Form.Text = "Form";
            // 
            // usrc_EditLayout1
            // 
            this.usrc_EditLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditLayout1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrc_EditLayout1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditLayout1.Name = "usrc_EditLayout1";
            this.usrc_EditLayout1.Size = new System.Drawing.Size(680, 712);
            this.usrc_EditLayout1.TabIndex = 0;
            // 
            // Form_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1107, 822);
            this.Controls.Add(this.cmb_Form);
            this.Controls.Add(this.lbl_Form);
            this.Controls.Add(this.cmb_ScreenResolution);
            this.Controls.Add(this.lbl_ScreenResolution);
            this.Controls.Add(this.btn_Images);
            this.Controls.Add(this.btn_ViewBookmardDic);
            this.Controls.Add(this.usrc_SelectXMLFile);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Layout";
            this.Text = "Form_HUDCMS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Wizzard_FormClosing);
            this.Load += new System.EventHandler(this.Form_Layout_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal SelectFile.usrc_SelectFile usrc_SelectXMLFile;
        internal BrightIdeasSoftware.TreeListView MyTreeListView;
        private BrightIdeasSoftware.OLVColumn olvc_ControlUniqueName;
        private BrightIdeasSoftware.OLVColumn olvc_ControlType;
        private BrightIdeasSoftware.OLVColumn olvc_ControlImage;
        private BrightIdeasSoftware.OLVColumn olvc_ControlName;
        private BrightIdeasSoftware.OLVColumn olvc_HelpTitle;
        private BrightIdeasSoftware.OLVColumn olvc_ControlLinks;
        private System.Windows.Forms.Button btn_ViewBookmardDic;
        private System.Windows.Forms.Button btn_Images;
        private System.Windows.Forms.Label lbl_ScreenResolution;
        private System.Windows.Forms.ComboBox cmb_ScreenResolution;
        private System.Windows.Forms.ComboBox cmb_Form;
        private System.Windows.Forms.Label lbl_Form;
        private usrc_EditLayout usrc_EditLayout1;
    }
}