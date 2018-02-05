namespace HUDCMS
{
    partial class usrc_EditControl_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditControl_About));
            this.lbl_AboutControl = new System.Windows.Forms.Label();
            this.fctb_CtrlAbout = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_AboutControl
            // 
            this.lbl_AboutControl.AutoSize = true;
            this.lbl_AboutControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_AboutControl.Location = new System.Drawing.Point(13, 16);
            this.lbl_AboutControl.Name = "lbl_AboutControl";
            this.lbl_AboutControl.Size = new System.Drawing.Size(60, 24);
            this.lbl_AboutControl.TabIndex = 36;
            this.lbl_AboutControl.Text = "About";
            // 
            // fctb_aBoutControl
            // 
            this.fctb_CtrlAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_CtrlAbout.AutoCompleteBracketsList = new char[] {
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
            this.fctb_CtrlAbout.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fctb_CtrlAbout.BackBrush = null;
            this.fctb_CtrlAbout.CharHeight = 18;
            this.fctb_CtrlAbout.CharWidth = 10;
            this.fctb_CtrlAbout.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_CtrlAbout.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_CtrlAbout.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctb_CtrlAbout.IsReplaceMode = false;
            this.fctb_CtrlAbout.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_CtrlAbout.Location = new System.Drawing.Point(3, 44);
            this.fctb_CtrlAbout.Name = "fctb_aBoutControl";
            this.fctb_CtrlAbout.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_CtrlAbout.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_CtrlAbout.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_aBoutControl.ServiceColors")));
            this.fctb_CtrlAbout.Size = new System.Drawing.Size(937, 444);
            this.fctb_CtrlAbout.TabIndex = 35;
            this.fctb_CtrlAbout.Zoom = 100;
            // 
            // usrc_EditControl_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lbl_AboutControl);
            this.Controls.Add(this.fctb_CtrlAbout);
            this.Name = "usrc_EditControl_About";
            this.Size = new System.Drawing.Size(948, 501);
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_AboutControl;
        internal FastColoredTextBoxNS.FastColoredTextBox fctb_CtrlAbout;
    }
}
