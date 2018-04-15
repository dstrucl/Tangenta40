using FastColoredTextBoxNS;

namespace HUDCMS
{
    partial class usrc_EditControlWizzard_Image
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditControl_Image));
            this.lbl_Image = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chk_ImageIncluded = new System.Windows.Forms.CheckBox();
            this.dgv_link = new System.Windows.Forms.DataGridView();
            this.btn_Link = new System.Windows.Forms.Button();
            this.fctb_CtrlImageCaption = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lbl_SnapShotMargin = new System.Windows.Forms.Label();
            this.nmUpDn_SnapShotMargin = new System.Windows.Forms.NumericUpDown();
            this.lbl_LinkedControls = new System.Windows.Forms.Label();
            this.lbl_ImageCaption = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pic_Control = new System.Windows.Forms.PictureBox();
            this.usrc_SelectPictureFile = new SelectFile.usrc_SelectFile();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlImageCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SnapShotMargin)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Image
            // 
            this.lbl_Image.AutoSize = true;
            this.lbl_Image.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Image.Location = new System.Drawing.Point(14, 13);
            this.lbl_Image.Name = "lbl_Image";
            this.lbl_Image.Size = new System.Drawing.Size(48, 18);
            this.lbl_Image.TabIndex = 40;
            this.lbl_Image.Text = "Image";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.SaddleBrown;
            this.splitContainer1.Location = new System.Drawing.Point(3, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.chk_ImageIncluded);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_link);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Link);
            this.splitContainer1.Panel1.Controls.Add(this.fctb_CtrlImageCaption);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_SnapShotMargin);
            this.splitContainer1.Panel1.Controls.Add(this.nmUpDn_SnapShotMargin);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_LinkedControls);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ImageCaption);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(699, 262);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 43;
            // 
            // chk_ImageIncluded
            // 
            this.chk_ImageIncluded.AutoSize = true;
            this.chk_ImageIncluded.Checked = true;
            this.chk_ImageIncluded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ImageIncluded.Location = new System.Drawing.Point(7, 6);
            this.chk_ImageIncluded.Margin = new System.Windows.Forms.Padding(2);
            this.chk_ImageIncluded.Name = "chk_ImageIncluded";
            this.chk_ImageIncluded.Size = new System.Drawing.Size(93, 17);
            this.chk_ImageIncluded.TabIndex = 57;
            this.chk_ImageIncluded.Text = "Include Image";
            this.chk_ImageIncluded.UseVisualStyleBackColor = true;
            // 
            // dgv_link
            // 
            this.dgv_link.AllowUserToAddRows = false;
            this.dgv_link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_link.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_link.Location = new System.Drawing.Point(7, 46);
            this.dgv_link.MultiSelect = false;
            this.dgv_link.Name = "dgv_link";
            this.dgv_link.ReadOnly = true;
            this.dgv_link.Size = new System.Drawing.Size(223, 82);
            this.dgv_link.TabIndex = 56;
            this.dgv_link.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_link_CellClick);
            // 
            // btn_Link
            // 
            this.btn_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Link.Image = global::HUDCMS.Properties.Resources.NoLink;
            this.btn_Link.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Link.Location = new System.Drawing.Point(235, 80);
            this.btn_Link.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(100, 48);
            this.btn_Link.TabIndex = 55;
            this.btn_Link.Text = "Add Link";
            this.btn_Link.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Link.UseVisualStyleBackColor = true;
            this.btn_Link.Click += new System.EventHandler(this.btn_Link_Click);
            // 
            // fctb_CtrlImageCaption
            // 
            this.fctb_CtrlImageCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_CtrlImageCaption.AutoCompleteBracketsList = new char[] {
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
            this.fctb_CtrlImageCaption.AutoIndentCharsPatterns = "";
            this.fctb_CtrlImageCaption.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctb_CtrlImageCaption.BackBrush = null;
            this.fctb_CtrlImageCaption.CharHeight = 14;
            this.fctb_CtrlImageCaption.CharWidth = 8;
            this.fctb_CtrlImageCaption.CommentPrefix = null;
            this.fctb_CtrlImageCaption.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_CtrlImageCaption.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_CtrlImageCaption.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctb_CtrlImageCaption.IsReplaceMode = false;
            this.fctb_CtrlImageCaption.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_CtrlImageCaption.LeftBracket = '<';
            this.fctb_CtrlImageCaption.LeftBracket2 = '(';
            this.fctb_CtrlImageCaption.Location = new System.Drawing.Point(6, 151);
            this.fctb_CtrlImageCaption.Name = "fctb_CtrlImageCaption";
            this.fctb_CtrlImageCaption.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_CtrlImageCaption.RightBracket = '>';
            this.fctb_CtrlImageCaption.RightBracket2 = ')';
            this.fctb_CtrlImageCaption.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_CtrlImageCaption.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_CtrlImageCaption.ServiceColors")));
            this.fctb_CtrlImageCaption.Size = new System.Drawing.Size(315, 97);
            this.fctb_CtrlImageCaption.TabIndex = 54;
            this.fctb_CtrlImageCaption.Zoom = 100;
            this.fctb_CtrlImageCaption.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            // 
            // lbl_SnapShotMargin
            // 
            this.lbl_SnapShotMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SnapShotMargin.AutoSize = true;
            this.lbl_SnapShotMargin.Location = new System.Drawing.Point(232, 30);
            this.lbl_SnapShotMargin.Name = "lbl_SnapShotMargin";
            this.lbl_SnapShotMargin.Size = new System.Drawing.Size(89, 13);
            this.lbl_SnapShotMargin.TabIndex = 53;
            this.lbl_SnapShotMargin.Text = "Snap shot margin";
            // 
            // nmUpDn_SnapShotMargin
            // 
            this.nmUpDn_SnapShotMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nmUpDn_SnapShotMargin.Location = new System.Drawing.Point(260, 49);
            this.nmUpDn_SnapShotMargin.Margin = new System.Windows.Forms.Padding(4);
            this.nmUpDn_SnapShotMargin.Name = "nmUpDn_SnapShotMargin";
            this.nmUpDn_SnapShotMargin.Size = new System.Drawing.Size(75, 20);
            this.nmUpDn_SnapShotMargin.TabIndex = 52;
            this.nmUpDn_SnapShotMargin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nmUpDn_SnapShotMargin.ValueChanged += new System.EventHandler(this.nmUpDn_SnapShotMargin_ValueChanged);
            // 
            // lbl_LinkedControls
            // 
            this.lbl_LinkedControls.AutoSize = true;
            this.lbl_LinkedControls.Location = new System.Drawing.Point(14, 30);
            this.lbl_LinkedControls.Name = "lbl_LinkedControls";
            this.lbl_LinkedControls.Size = new System.Drawing.Size(80, 13);
            this.lbl_LinkedControls.TabIndex = 51;
            this.lbl_LinkedControls.Text = "Linked Controls";
            // 
            // lbl_ImageCaption
            // 
            this.lbl_ImageCaption.AutoSize = true;
            this.lbl_ImageCaption.Location = new System.Drawing.Point(4, 135);
            this.lbl_ImageCaption.Name = "lbl_ImageCaption";
            this.lbl_ImageCaption.Size = new System.Drawing.Size(43, 13);
            this.lbl_ImageCaption.TabIndex = 49;
            this.lbl_ImageCaption.Text = "Caption";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(24, 24);
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pic_Control);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 262);
            this.panel2.TabIndex = 36;
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.Color.Gray;
            this.pic_Control.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_Control.Location = new System.Drawing.Point(3, 39);
            this.pic_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(458, 371);
            this.pic_Control.TabIndex = 0;
            this.pic_Control.TabStop = false;
            // 
            // usrc_SelectPictureFile
            // 
            this.usrc_SelectPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectPictureFile.ButtonEditVisible = true;
            this.usrc_SelectPictureFile.ButtonSelectText = "Save";
            this.usrc_SelectPictureFile.DefaultExtension = "txt";
            this.usrc_SelectPictureFile.FileName = "";
            this.usrc_SelectPictureFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectPictureFile.InitialDirectory = "C:\\";
            this.usrc_SelectPictureFile.LabelText = "Save File";
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(77, 13);
            this.usrc_SelectPictureFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(450, 30);
            this.usrc_SelectPictureFile.TabIndex = 34;
            this.usrc_SelectPictureFile.Title = "Save File";
            this.usrc_SelectPictureFile.Type = SelectFile.usrc_SelectFile.eType.SAVE;
            // 
            // usrc_EditControl_Image
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbl_Image);
            this.Controls.Add(this.usrc_SelectPictureFile);
            this.Name = "usrc_EditControl_Image";
            this.Size = new System.Drawing.Size(705, 319);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlImageCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SnapShotMargin)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Image;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_SnapShotMargin;
        internal System.Windows.Forms.NumericUpDown nmUpDn_SnapShotMargin;
        private System.Windows.Forms.Label lbl_ImageCaption;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lbl_LinkedControls;
        internal System.Windows.Forms.PictureBox pic_Control;
        internal SelectFile.usrc_SelectFile usrc_SelectPictureFile;
        internal FastColoredTextBox fctb_CtrlImageCaption;
        internal System.Windows.Forms.Button btn_Link;
        internal System.Windows.Forms.DataGridView dgv_link;
        internal System.Windows.Forms.CheckBox chk_ImageIncluded;
    }
}
