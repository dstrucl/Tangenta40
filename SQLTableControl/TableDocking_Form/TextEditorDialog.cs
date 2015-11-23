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
    public partial class TextEditorDialog : Form
    {
        private Object m_MainWindow;
        private string m_Text = null;
        private string m_FileName = null;
       


        public TextEditorDialog(string sText,string sFileName, Object MainWnd)
        {
            m_Text = sText;
            m_FileName = sFileName;
            m_MainWindow = MainWnd;
            InitializeComponent();
        }

        private void TextEditorDialog_Load(object sender, EventArgs e)
        {
            textEditorControl.Document.TextContent = m_Text;
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
        }

        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dRes = MessageBox.Show(lngRPM.s_File.s + ":\"" + m_FileName + "\"" + lngRPM.s_save.s + "?", lngRPM.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dRes == DialogResult.Yes)
            {
                this.textEditorControl.SaveFile(m_FileName);
            }
        }

    }
}
