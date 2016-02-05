#region LICENSE 
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

namespace LogFile
{
    public partial class TextBoxDialog_Form : Form
    {
        public string m_Result;
        private string m_sMessageResultMayNotBeEmpty;
        private bool m_bResultMayNotBeEmpty;

        public TextBoxDialog_Form(string Title, string slabel, string default_text, string sMessageResultMayNotBeEmpty, bool bResultMayNotBeEmpty)
        {
            InitializeComponent();
            lbl_Instruction.Text = slabel;
            this.Text = Title;
            txtDataBaseFile.Text = default_text;
            btn_OK.Text = lngConn.s_Ok.s;
            btn_Cancel.Text = lngConn.s_Cancel.s;
            m_Result = "";
            m_sMessageResultMayNotBeEmpty = sMessageResultMayNotBeEmpty;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txtDataBaseFile.Text.Length > 0)
            {
                 m_Result = txtDataBaseFile.Text;
                 DialogResult = DialogResult.OK;
                 Close();

            }
            else
            {
                if (m_bResultMayNotBeEmpty)
                {
                    MessageBox.Show(m_sMessageResultMayNotBeEmpty, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    m_Result = txtDataBaseFile.Text;
                     DialogResult = DialogResult.OK;
                     Close();
                }
            }
        }
    }
}
