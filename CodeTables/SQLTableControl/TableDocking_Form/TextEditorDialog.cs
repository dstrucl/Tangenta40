﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;


namespace CodeTables
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
            DialogResult dRes = MessageBox.Show(lng.s_File.s + ":\"" + m_FileName + "\"" + lng.s_save.s + "?", lng.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dRes == DialogResult.Yes)
            {
                this.textEditorControl.SaveFile(m_FileName);
            }
        }

    }
}
