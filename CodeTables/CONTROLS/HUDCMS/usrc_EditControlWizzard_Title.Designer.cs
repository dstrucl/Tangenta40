namespace HUDCMS
{
    partial class usrc_EditControlWizzard_Title
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditControlWizzard_Title));
            this.cmb_HtmlTag = new System.Windows.Forms.ComboBox();
            this.lbl_Control_Title = new System.Windows.Forms.Label();
            this.lbl_HtmlHeadingsTag = new System.Windows.Forms.Label();
            this.fctb_CtrlTitle = new FastColoredTextBoxNS.FastColoredTextBox();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_HtmlTag
            // 
            this.cmb_HtmlTag.FormattingEnabled = true;
            this.cmb_HtmlTag.Location = new System.Drawing.Point(240, 11);
            this.cmb_HtmlTag.Name = "cmb_HtmlTag";
            this.cmb_HtmlTag.Size = new System.Drawing.Size(56, 21);
            this.cmb_HtmlTag.TabIndex = 24;
            // 
            // lbl_Control_Title
            // 
            this.lbl_Control_Title.AutoSize = true;
            this.lbl_Control_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Control_Title.Location = new System.Drawing.Point(12, 10);
            this.lbl_Control_Title.Name = "lbl_Control_Title";
            this.lbl_Control_Title.Size = new System.Drawing.Size(35, 18);
            this.lbl_Control_Title.TabIndex = 37;
            this.lbl_Control_Title.Text = "Title";
            // 
            // lbl_HtmlHeadingsTag
            // 
            this.lbl_HtmlHeadingsTag.AutoSize = true;
            this.lbl_HtmlHeadingsTag.Location = new System.Drawing.Point(102, 13);
            this.lbl_HtmlHeadingsTag.Name = "lbl_HtmlHeadingsTag";
            this.lbl_HtmlHeadingsTag.Size = new System.Drawing.Size(101, 13);
            this.lbl_HtmlHeadingsTag.TabIndex = 38;
            this.lbl_HtmlHeadingsTag.Text = "HTML headings tag";
            // 
            // fctb_CtrlTitle
            // 
            this.fctb_CtrlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_CtrlTitle.AutoCompleteBracketsList = new char[] {
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
            this.fctb_CtrlTitle.AutoIndentCharsPatterns = "";
            this.fctb_CtrlTitle.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctb_CtrlTitle.BackBrush = null;
            this.fctb_CtrlTitle.CharHeight = 14;
            this.fctb_CtrlTitle.CharWidth = 8;
            this.fctb_CtrlTitle.CommentPrefix = null;
            this.fctb_CtrlTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_CtrlTitle.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_CtrlTitle.IsReplaceMode = false;
            this.fctb_CtrlTitle.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_CtrlTitle.LeftBracket = '<';
            this.fctb_CtrlTitle.LeftBracket2 = '(';
            this.fctb_CtrlTitle.Location = new System.Drawing.Point(4, 42);
            this.fctb_CtrlTitle.Name = "fctb_CtrlTitle";
            this.fctb_CtrlTitle.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_CtrlTitle.RightBracket = '>';
            this.fctb_CtrlTitle.RightBracket2 = ')';
            this.fctb_CtrlTitle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_CtrlTitle.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_CtrlTitle.ServiceColors")));
            this.fctb_CtrlTitle.Size = new System.Drawing.Size(702, 52);
            this.fctb_CtrlTitle.TabIndex = 41;
            this.fctb_CtrlTitle.Zoom = 100;
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(343, 10);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(100, 20);
            this.txt_ID.TabIndex = 45;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(318, 13);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(18, 13);
            this.lbl_ID.TabIndex = 44;
            this.lbl_ID.Text = "ID";
            // 
            // usrc_EditControlWizzard_Title
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.fctb_CtrlTitle);
            this.Controls.Add(this.lbl_HtmlHeadingsTag);
            this.Controls.Add(this.lbl_Control_Title);
            this.Controls.Add(this.cmb_HtmlTag);
            this.Name = "usrc_EditControlWizzard_Title";
            this.Size = new System.Drawing.Size(706, 103);
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Control_Title;
        private System.Windows.Forms.Label lbl_HtmlHeadingsTag;
        internal System.Windows.Forms.ComboBox cmb_HtmlTag;
        internal FastColoredTextBoxNS.FastColoredTextBox fctb_CtrlTitle;
        internal System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label lbl_ID;
    }
}
