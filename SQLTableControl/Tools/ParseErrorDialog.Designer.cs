namespace SQLTableControl
{
    partial class ParseErrorDialog
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
            this.lbl_File = new System.Windows.Forms.Label();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.TextBox();
            this.TextEditorMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditorControl = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.TextEditorMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_File
            // 
            this.lbl_File.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_File.Location = new System.Drawing.Point(12, 8);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(84, 24);
            this.lbl_File.TabIndex = 1;
            this.lbl_File.Text = "File:";
            this.lbl_File.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FileName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.Location = new System.Drawing.Point(102, 10);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(754, 24);
            this.lbl_FileName.TabIndex = 2;
            this.lbl_FileName.Text = "label1";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 38);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(84, 24);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message:";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(107, 41);
            this.lbl_Message.Multiline = true;
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lbl_Message.Size = new System.Drawing.Size(749, 81);
            this.lbl_Message.TabIndex = 7;
            this.lbl_Message.WordWrap = false;
            // 
            // TextEditorMenuStrip
            // 
            this.TextEditorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemCopy,
            this.ItemCut,
            this.ItemPaste});
            this.TextEditorMenuStrip.Name = "TextEditorMenuStrip";
            this.TextEditorMenuStrip.Size = new System.Drawing.Size(162, 70);
            // 
            // ItemCopy
            // 
            this.ItemCopy.Name = "ItemCopy";
            this.ItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ItemCopy.Size = new System.Drawing.Size(161, 22);
            this.ItemCopy.Text = "Copy";
            this.ItemCopy.Click += new System.EventHandler(this.ItemCopy_Click);
            // 
            // ItemCut
            // 
            this.ItemCut.Name = "ItemCut";
            this.ItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ItemCut.Size = new System.Drawing.Size(161, 22);
            this.ItemCut.Text = "Cut";
            this.ItemCut.Click += new System.EventHandler(this.ItemCut_Click);
            // 
            // ItemPaste
            // 
            this.ItemPaste.Name = "ItemPaste";
            this.ItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.ItemPaste.Size = new System.Drawing.Size(161, 22);
            this.ItemPaste.Text = "Paste";
            this.ItemPaste.Click += new System.EventHandler(this.ItemPaste_Click);
            // 
            // textEditorControl
            // 
            this.textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditorControl.Location = new System.Drawing.Point(12, 128);
            this.textEditorControl.Name = "textEditorControl";
            this.textEditorControl.ShowHRuler = true;
            this.textEditorControl.Size = new System.Drawing.Size(844, 487);
            this.textEditorControl.TabIndex = 0;
            this.textEditorControl.Text = "textEditorControl1";
            this.textEditorControl.ContextMenuRequest += new System.Windows.Forms.MouseEventHandler(this.textEditorControl_MouseClick);
            this.textEditorControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textEditorControl_MouseClick);
            // 
            // ParseErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 627);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.lbl_File);
            this.Controls.Add(this.textEditorControl);
            this.Name = "ParseErrorDialog";
            this.Text = "ParseErrorDialog";
            this.Load += new System.EventHandler(this.ParseErrorDialog_Load);
            this.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.ParseErrorDialog_QueryAccessibilityHelp);
            this.TextEditorMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_File;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox lbl_Message;
        private System.Windows.Forms.ContextMenuStrip TextEditorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ItemCopy;
        private System.Windows.Forms.ToolStripMenuItem ItemCut;
        private System.Windows.Forms.ToolStripMenuItem ItemPaste;
        public DigitalRune.Windows.TextEditor.TextEditorControl textEditorControl;
    }
}