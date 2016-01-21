using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;


namespace SQLTableControl
{
    public partial class ParseErrorDialog : Form
    {
        private Object m_MainWindow;
        private SourceText m_SourceText;
        private string m_lbl_Message;
        private string m_caption;
        public ParseErrorDialog(SourceText srcTxt, Object MainWnd, string message, string caption)
        {
            m_lbl_Message = message;
            m_caption = caption;
            m_SourceText = srcTxt;
            m_MainWindow = MainWnd;
            InitializeComponent();
        }

        private void ParseErrorDialog_Load(object sender, EventArgs e)
        {
            this.lbl_Message.Text = m_lbl_Message;
            this.Text = m_caption;
            textEditorControl.LoadFile(m_SourceText.FileName);
            textEditorControl.ActiveTextAreaControl.ScrollTo(m_SourceText.iLine);
            DigitalRune.Windows.TextEditor.Document.TextLocation txtStartLocation = new DigitalRune.Windows.TextEditor.Document.TextLocation(0,m_SourceText.iLine-1);
            DigitalRune.Windows.TextEditor.Document.TextLocation txtEndLocation = new DigitalRune.Windows.TextEditor.Document.TextLocation(0,m_SourceText.iLine);
            textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SetSelection(txtStartLocation, txtEndLocation);
            textEditorControl.ActiveTextAreaControl.TextArea.Caret.Position = txtStartLocation;
        }

        private void textEditorControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                TextEditorMenuStrip.Items["ItemCopy"].Enabled = false;
                TextEditorMenuStrip.Items["ItemCut"].Enabled = false;
                if (textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText != null)
                {
                    if (textEditorControl.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText.Length > 0)
                    {
                        TextEditorMenuStrip.Items["ItemCopy"].Enabled = true;
                        TextEditorMenuStrip.Items["ItemCut"].Enabled = true;
                    }
                }

                TextEditorMenuStrip.Items["ItemPaste"].Enabled = false;
                if (Clipboard.ContainsText())
                {
                    if (Clipboard.GetText().Length > 0)
                    {
                        TextEditorMenuStrip.Items["ItemPaste"].Enabled = true;
                    }
                }

                TextEditorMenuStrip.Show(this,e.X,e.Y+this.Top);
            }
        }







        private void ParseErrorDialog_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void ItemCopy_Click(object sender, EventArgs e)
        {
            this.textEditorControl.ActiveTextAreaControl.TextArea.HandleProcessDialogKey(sender);
        }

        private void ItemCut_Click(object sender, EventArgs e)
        {
            this.textEditorControl.ActiveTextAreaControl.TextArea.HandleProcessDialogKey(sender);
        }

        private void ItemPaste_Click(object sender, EventArgs e)
        {
            this.textEditorControl.ActiveTextAreaControl.TextArea.HandleProcessDialogKey(sender);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dRes = MessageBox.Show(lngRPM.s_File.s + ":\"" + m_SourceText.FileName + "\"" + lngRPM.s_save.s + "?", lngRPM.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (dRes == DialogResult.Yes)
            {
                this.textEditorControl.SaveFile(m_SourceText.FileName);
            }
        }
    }
}