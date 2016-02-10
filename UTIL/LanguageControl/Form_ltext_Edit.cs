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

namespace LanguageControl
{
    public partial class Form_ltext_Edit : Form
    {
        private ltext ltext;
        string[] m_sText = null;
        DataTable dt_Translations = new DataTable();

        public Form_ltext_Edit(ltext xltext, ref string[] sText)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.ltext = xltext;
            m_sText = sText;
            dt_Translations.Columns.Add("ID", typeof(int));
            dt_Translations.Columns.Add(lngRPM.s_Language.s, typeof(string));
            dt_Translations.Columns.Add(lngRPM.s_Text_in_language.s, typeof(string));
            int icount = m_sText.Count();
            for (int i =0;i<icount;i++)
            {
                DataRow dr = dt_Translations.NewRow();
                dr[0] = i;
                dr[1] = DynSettings.s_language.GetText(i);
                dr[2] = xltext.GetText(i);
                dt_Translations.Rows.Add(dr);
            }
            dgv_Lng.DataSource = dt_Translations;
            dt_Translations.AcceptChanges();
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataTable dtChanges = dt_Translations.GetChanges();
            if (dtChanges != null)
            {
                if (dtChanges.Rows.Count > 0)
                {
                    if (MessageBox.Show("Save changes ?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int icount = m_sText.Count();
                        for (int i = 0; i < icount; i++)
                        {
                            object o = dt_Translations.Rows[i][2];
                            if (o is string)
                            {
                                m_sText[i] = (string)o;
                            }
                            else
                            {
                                m_sText[i] = null;
                            }
                        }
                        DialogResult = DialogResult.Yes;
                        this.Close();
                        return;
                    }
                }
            }
            DialogResult = DialogResult.No;
            this.Close();
            return;
        }

    }
}
