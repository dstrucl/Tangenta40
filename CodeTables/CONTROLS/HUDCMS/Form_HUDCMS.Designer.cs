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
            this.usrc_SelectStyleFile = new SelectFile.usrc_SelectFile();
            this.fctb_Style = new FastColoredTextBoxNS.FastColoredTextBox();
            this.grp_Style = new System.Windows.Forms.GroupBox();
            this.usrc_SelectHtmlFile = new SelectFile.usrc_SelectFile();
            this.btn_Create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_Style)).BeginInit();
            this.grp_Style.SuspendLayout();
            this.SuspendLayout();
            // 
            // usrc_SelectStyleFile
            // 
            this.usrc_SelectStyleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectStyleFile.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.usrc_SelectStyleFile.DefaultExtension = "css";
            this.usrc_SelectStyleFile.FileName = "";
            this.usrc_SelectStyleFile.Filter = "Text files (*.css)|*.css|All files (*.*)|*.*";
            this.usrc_SelectStyleFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_SelectStyleFile.InitialDirectory = "C:\\";
            this.usrc_SelectStyleFile.Location = new System.Drawing.Point(17, 35);
            this.usrc_SelectStyleFile.Name = "usrc_SelectStyleFile";
            this.usrc_SelectStyleFile.Size = new System.Drawing.Size(901, 34);
            this.usrc_SelectStyleFile.TabIndex = 0;
            this.usrc_SelectStyleFile.Title = "Save Style File";
            this.usrc_SelectStyleFile.Load += new System.EventHandler(this.usrc_SelectStyleFile_Load);
            // 
            // fctb_Style
            // 
            this.fctb_Style.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_Style.AutoCompleteBracketsList = new char[] {
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
            this.fctb_Style.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.fctb_Style.BackBrush = null;
            this.fctb_Style.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fctb_Style.CharHeight = 18;
            this.fctb_Style.CharWidth = 10;
            this.fctb_Style.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_Style.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_Style.IsReplaceMode = false;
            this.fctb_Style.Language = FastColoredTextBoxNS.Language.HTML;
            this.fctb_Style.Location = new System.Drawing.Point(6, 75);
            this.fctb_Style.Name = "fctb_Style";
            this.fctb_Style.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_Style.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_Style.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_Style.ServiceColors")));
            this.fctb_Style.Size = new System.Drawing.Size(1039, 287);
            this.fctb_Style.TabIndex = 5;
            this.fctb_Style.Text = "fastColoredTextBox1";
            this.fctb_Style.Zoom = 100;
            // 
            // grp_Style
            // 
            this.grp_Style.Controls.Add(this.fctb_Style);
            this.grp_Style.Controls.Add(this.usrc_SelectStyleFile);
            this.grp_Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Style.Location = new System.Drawing.Point(12, 53);
            this.grp_Style.Name = "grp_Style";
            this.grp_Style.Size = new System.Drawing.Size(1051, 368);
            this.grp_Style.TabIndex = 6;
            this.grp_Style.TabStop = false;
            this.grp_Style.Text = "Style";
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
            this.usrc_SelectHtmlFile.Location = new System.Drawing.Point(29, 13);
            this.usrc_SelectHtmlFile.Name = "usrc_SelectHtmlFile";
            this.usrc_SelectHtmlFile.Size = new System.Drawing.Size(901, 34);
            this.usrc_SelectHtmlFile.TabIndex = 6;
            this.usrc_SelectHtmlFile.Title = "Save Style File";
            // 
            // btn_Create
            // 
            this.btn_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Create.Location = new System.Drawing.Point(936, 12);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(121, 50);
            this.btn_Create.TabIndex = 7;
            this.btn_Create.Text = "CREATE";
            this.btn_Create.UseVisualStyleBackColor = true;
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1075, 815);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.usrc_SelectHtmlFile);
            this.Controls.Add(this.grp_Style);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_HUDCMS";
            this.Text = "Form_HUDCMS";
            ((System.ComponentModel.ISupportInitialize)(this.fctb_Style)).EndInit();
            this.grp_Style.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectFile.usrc_SelectFile usrc_SelectStyleFile;
        private FastColoredTextBoxNS.FastColoredTextBox fctb_Style;
        private System.Windows.Forms.GroupBox grp_Style;
        private SelectFile.usrc_SelectFile usrc_SelectHtmlFile;
        private System.Windows.Forms.Button btn_Create;
    }
}