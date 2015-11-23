namespace LogFile
{
    partial class TextEditorDialog
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
            this.textEditorControl = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.ItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.TextEditorMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextEditorMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditorControl
            // 
            this.textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditorControl.Location = new System.Drawing.Point(9, 29);
            this.textEditorControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.ShowHRuler = true;
            this.textEditorControl.Size = new System.Drawing.Size(631, 470);
            this.textEditorControl.TabIndex = 0;
            this.textEditorControl.Text = "textEditorControl1";
            this.textEditorControl.Load += new System.EventHandler(this.textEditorControl_Load);
            this.textEditorControl.ContextMenuRequest += new System.Windows.Forms.MouseEventHandler(this.textEditorControl_MouseClick);
            this.textEditorControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textEditorControl_MouseClick);
            // 
            // ItemCopy
            // 
            this.ItemCopy.Name = "ItemCopy";
            this.ItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ItemCopy.Size = new System.Drawing.Size(144, 22);
            this.ItemCopy.Text = "Copy";
            this.ItemCopy.Click += new System.EventHandler(this.ItemCopy_Click);
            // 
            // ItemCut
            // 
            this.ItemCut.Name = "ItemCut";
            this.ItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ItemCut.Size = new System.Drawing.Size(144, 22);
            this.ItemCut.Text = "Cut";
            this.ItemCut.Click += new System.EventHandler(this.ItemCut_Click);
            // 
            // ItemPaste
            // 
            this.ItemPaste.Name = "ItemPaste";
            this.ItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ItemPaste.Size = new System.Drawing.Size(144, 22);
            this.ItemPaste.Text = "Paste";
            this.ItemPaste.Click += new System.EventHandler(this.ItemPaste_Click);
            // 
            // TextEditorMenuStrip
            // 
            this.TextEditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemCopy,
            this.ItemCut,
            this.ItemPaste});
            this.TextEditorMenuStrip.Name = "TextEditorMenuStrip";
            this.TextEditorMenuStrip.Size = new System.Drawing.Size(145, 70);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveASToolStripMenuItem,
            this.recentToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveASToolStripMenuItem
            // 
            this.saveASToolStripMenuItem.Name = "saveASToolStripMenuItem";
            this.saveASToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveASToolStripMenuItem.Text = "Save AS";
            this.saveASToolStripMenuItem.Click += new System.EventHandler(this.saveASToolStripMenuItem_Click);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            // 
            // TextEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 509);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textEditorControl);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TextEditorDialog";
            this.ShowInTaskbar = false;
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.TextEditorDialog_Load);
            this.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.ParseErrorDialog_QueryAccessibilityHelp);
            this.TextEditorMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DigitalRune.Windows.TextEditor.TextEditorControl textEditorControl;
        private System.Windows.Forms.ToolStripMenuItem ItemCopy;
        private System.Windows.Forms.ToolStripMenuItem ItemCut;
        private System.Windows.Forms.ToolStripMenuItem ItemPaste;
        private System.Windows.Forms.ContextMenuStrip TextEditorMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
    }
}