using FastColoredTextBoxNS;

namespace HUDCMS
{
    partial class usrc_EditControl_Description
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditControl_Description));
            this.lbl_Description = new System.Windows.Forms.Label();
            this.fctb_CtrlDescription = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Description.Location = new System.Drawing.Point(4, 11);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(104, 24);
            this.lbl_Description.TabIndex = 38;
            this.lbl_Description.Text = "Description";
            // 
            // fctb_CtrlDescription
            // 
            this.fctb_CtrlDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_CtrlDescription.AutoCompleteBracketsList = new char[] {
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
            this.fctb_CtrlDescription.AutoIndentCharsPatterns = "";
            this.fctb_CtrlDescription.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fctb_CtrlDescription.BackBrush = null;
            this.fctb_CtrlDescription.CharHeight = 18;
            this.fctb_CtrlDescription.CharWidth = 10;
            this.fctb_CtrlDescription.CommentPrefix = null;
            this.fctb_CtrlDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_CtrlDescription.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_CtrlDescription.IsReplaceMode = false;
            this.fctb_CtrlDescription.Language = Language.HTML;
            this.fctb_CtrlDescription.LeftBracket = '<';
            this.fctb_CtrlDescription.LeftBracket2 = '(';
            this.fctb_CtrlDescription.Location = new System.Drawing.Point(3, 52);
            this.fctb_CtrlDescription.Name = "fctb_CtrlDescription";
            this.fctb_CtrlDescription.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_CtrlDescription.RightBracket = '>';
            this.fctb_CtrlDescription.RightBracket2 = ')';
            this.fctb_CtrlDescription.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_CtrlDescription.ServiceColors = ((ServiceColors)(resources.GetObject("fctb_CtrlDescription.ServiceColors")));
            this.fctb_CtrlDescription.Size = new System.Drawing.Size(724, 210);
            this.fctb_CtrlDescription.TabIndex = 37;
            this.fctb_CtrlDescription.Zoom = 100;
            // 
            // usrc_EditControl_Description
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_Description);
            this.Controls.Add(this.fctb_CtrlDescription);
            this.Name = "usrc_EditControl_Description";
            this.Size = new System.Drawing.Size(730, 269);
            ((System.ComponentModel.ISupportInitialize)(this.fctb_CtrlDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Description;
        internal FastColoredTextBox fctb_CtrlDescription;
    }
}
