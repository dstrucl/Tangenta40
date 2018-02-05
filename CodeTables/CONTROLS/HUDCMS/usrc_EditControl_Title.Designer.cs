namespace HUDCMS
{
    partial class usrc_EditControl_Title
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditControl_Title));
            this.cmb_HtmlTag = new System.Windows.Forms.ComboBox();
            this.lbl_Control_Title = new System.Windows.Forms.Label();
            this.lbl_HtmlTag = new System.Windows.Forms.Label();
            this.lbl_HTML_class = new System.Windows.Forms.Label();
            this.cmb_HTMLClass = new System.Windows.Forms.ComboBox();
            this.fctb_CtrlTitle = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_HtmlTag
            // 
            this.cmb_HtmlTag.FormattingEnabled = true;
            this.cmb_HtmlTag.Location = new System.Drawing.Point(206, 12);
            this.cmb_HtmlTag.Name = "cmb_HtmlTag";
            this.cmb_HtmlTag.Size = new System.Drawing.Size(177, 24);
            this.cmb_HtmlTag.TabIndex = 24;
            // 
            // lbl_Control_Title
            // 
            this.lbl_Control_Title.AutoSize = true;
            this.lbl_Control_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Control_Title.Location = new System.Drawing.Point(12, 10);
            this.lbl_Control_Title.Name = "lbl_Control_Title";
            this.lbl_Control_Title.Size = new System.Drawing.Size(45, 24);
            this.lbl_Control_Title.TabIndex = 37;
            this.lbl_Control_Title.Text = "Title";
            // 
            // lbl_HtmlTag
            // 
            this.lbl_HtmlTag.AutoSize = true;
            this.lbl_HtmlTag.Location = new System.Drawing.Point(130, 15);
            this.lbl_HtmlTag.Name = "lbl_HtmlTag";
            this.lbl_HtmlTag.Size = new System.Drawing.Size(70, 17);
            this.lbl_HtmlTag.TabIndex = 38;
            this.lbl_HtmlTag.Text = "HTML tag";
            // 
            // lbl_HTML_class
            // 
            this.lbl_HTML_class.AutoSize = true;
            this.lbl_HTML_class.Location = new System.Drawing.Point(408, 15);
            this.lbl_HTML_class.Name = "lbl_HTML_class";
            this.lbl_HTML_class.Size = new System.Drawing.Size(70, 17);
            this.lbl_HTML_class.TabIndex = 40;
            this.lbl_HTML_class.Text = "HTML tag";
            // 
            // cmb_HTMLClass
            // 
            this.cmb_HTMLClass.FormattingEnabled = true;
            this.cmb_HTMLClass.Location = new System.Drawing.Point(504, 15);
            this.cmb_HTMLClass.Name = "cmb_HTMLClass";
            this.cmb_HTMLClass.Size = new System.Drawing.Size(177, 24);
            this.cmb_HTMLClass.TabIndex = 39;
            // 
            // fctb_Title
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
            this.fctb_CtrlTitle.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fctb_CtrlTitle.BackBrush = null;
            this.fctb_CtrlTitle.CharHeight = 18;
            this.fctb_CtrlTitle.CharWidth = 10;
            this.fctb_CtrlTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_CtrlTitle.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_CtrlTitle.IsReplaceMode = false;
            this.fctb_CtrlTitle.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_CtrlTitle.Location = new System.Drawing.Point(4, 85);
            this.fctb_CtrlTitle.Name = "fctb_Title";
            this.fctb_CtrlTitle.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_CtrlTitle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_CtrlTitle.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_Title.ServiceColors")));
            this.fctb_CtrlTitle.Size = new System.Drawing.Size(702, 106);
            this.fctb_CtrlTitle.TabIndex = 41;
            this.fctb_CtrlTitle.Zoom = 100;
            // 
            // usrc_EditControl_Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.fctb_CtrlTitle);
            this.Controls.Add(this.lbl_HTML_class);
            this.Controls.Add(this.cmb_HTMLClass);
            this.Controls.Add(this.lbl_HtmlTag);
            this.Controls.Add(this.lbl_Control_Title);
            this.Controls.Add(this.cmb_HtmlTag);
            this.Name = "usrc_EditControl_Title";
            this.Size = new System.Drawing.Size(706, 197);
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_Control_Title;
        private System.Windows.Forms.Label lbl_HtmlTag;
        private System.Windows.Forms.Label lbl_HTML_class;
        internal System.Windows.Forms.ComboBox cmb_HtmlTag;
        internal System.Windows.Forms.ComboBox cmb_HTMLClass;
        internal FastColoredTextBoxNS.FastColoredTextBox fctb_CtrlTitle;
    }
}
