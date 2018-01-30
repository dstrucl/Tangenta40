namespace HUDCMS
{
    partial class usrc_Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_Control));
            this.lbl_Control = new System.Windows.Forms.Label();
            this.pic_Control = new System.Windows.Forms.PictureBox();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usrc_SelectPictureFile = new SelectFile.usrc_SelectFile();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Control
            // 
            this.lbl_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Control.AutoSize = true;
            this.lbl_Control.Location = new System.Drawing.Point(3, 4);
            this.lbl_Control.Name = "lbl_Control";
            this.lbl_Control.Size = new System.Drawing.Size(48, 17);
            this.lbl_Control.TabIndex = 3;
            this.lbl_Control.Text = "Dialog";
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Control.Location = new System.Drawing.Point(4, 54);
            this.pic_Control.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(856, 143);
            this.pic_Control.TabIndex = 2;
            this.pic_Control.TabStop = false;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
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
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(221, 18);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.CharHeight = 18;
            this.fastColoredTextBox1.CharWidth = 10;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(882, 132);
            this.fastColoredTextBox1.TabIndex = 4;
            this.fastColoredTextBox1.Text = "fastColoredTextBox1";
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Location = new System.Drawing.Point(6, 37);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.fastColoredTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(882, 341);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.pic_Control);
            this.panel1.Controls.Add(this.usrc_SelectPictureFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 201);
            this.panel1.TabIndex = 4;
            // 
            // usrc_SelectPictureFile
            // 
            this.usrc_SelectPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectPictureFile.DefaultExtension = "txt";
            this.usrc_SelectPictureFile.FileName = "";
            this.usrc_SelectPictureFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectPictureFile.InitialDirectory = "C:\\";
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(4, 14);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(856, 33);
            this.usrc_SelectPictureFile.TabIndex = 3;
            this.usrc_SelectPictureFile.Title = "Save File";
            this.usrc_SelectPictureFile.SaveFile += new SelectFile.usrc_SelectFile.delegate_SaveFile(this.usrc_SelectPictureFile_SaveFile);
            // 
            // usrc_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbl_Control);
            this.Name = "usrc_Control";
            this.Size = new System.Drawing.Size(907, 386);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Control;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SelectFile.usrc_SelectFile usrc_SelectPictureFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_Control;
    }
}
