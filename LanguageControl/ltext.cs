using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Threading;

namespace LanguageControl
{
    public class ltext
    {
        public string[] sText = new string[DynSettings.MAX_NUMBER_OF_LANGUAGES];
        public List<object> complex_text_list = null;
        Control m_ctrl = null;
        public string s
        {
            get
            {
                if (complex_text_list == null)
                {
                    return sText[DynSettings.LanguageID];
                }
                else
                {
                    string s = "";
                    int icount = complex_text_list.Count;
                    for (int i=0;i<icount;i++)
                    {
                        object otext = complex_text_list[i];
                        if (otext is string )
                        {
                            s += (string)otext;
                        }
                        else if (otext is ltext )
                        {
                            s += ((ltext)otext).s;
                        }
                        else
                        {
                            s = "ERROR LTEXT!";
                        }
                    }
                    return s;
                }
            }
        }

        public string GetText(int i)
        {
            if (complex_text_list == null)
            {
                return sText[i];
            }
            else
            {
                    string s = "";
                    int jcount = complex_text_list.Count;
                    for (int j=0;i<jcount;j++)
                    {
                        object otext = complex_text_list[j];
                        if (otext is string )
                        {
                            s += (string)otext;
                        }
                        else if (otext is ltext )
                        {
                            s += ((ltext)otext).GetText(i);
                        }
                        else
                        {
                            s = "ERROR LTEXT!";
                        }
                    }
                    return s;
            }
        }

        public ltext(string Lang1, string Lang2)
        {
            sText[0] = Lang1;
            sText[1] = Lang2;
        }

        public ltext(List<object> complex_text)
        {
            // TODO: Complete member initialization
            this.complex_text_list = complex_text;
        }

        public ltext()
        {
            // TODO: Complete member initialization
        }

        public bool Edit(ref string[] sText)
        {
            Form_ltext_Edit dlgedit = new Form_ltext_Edit(this, ref sText);
            return dlgedit.ShowDialog() == DialogResult.Yes;
        }

        public void Text(Control ctrl)
        {
            m_ctrl = ctrl;
            m_ctrl.Text = this.s;
            m_ctrl.Tag = this;
            if ((ctrl is Button) || (ctrl is RadioButton) || (ctrl is CheckBox) || (ctrl is TextBox) || (ctrl is Label))
            {
                m_ctrl.MouseHover += m_ctrl_MouseHover;
            }
        }

        public void Text(Control ctrl,string additional_text)
        {
            m_ctrl = ctrl;
            m_ctrl.Text = this.s + additional_text;
            m_ctrl.Tag = this;
            if ((ctrl is Button) || (ctrl is RadioButton) || (ctrl is CheckBox) || (ctrl is TextBox) || (ctrl is Label))
            {
                m_ctrl.MouseHover += m_ctrl_MouseHover;
            }
        }

        public void Text(string prefix, Control ctrl)
        {
            Text(ctrl);
            m_ctrl.Text = prefix + m_ctrl.Text;
        }

        public void Text(string prefix, Control ctrl, string additional_text)
        {
            Text(ctrl);
            m_ctrl.Text = prefix + m_ctrl.Text + additional_text;
        }

        public void Text(Control ctrl, List<object> xcomplex_text_list)
        {
            m_ctrl = ctrl;
            complex_text_list = xcomplex_text_list;
            m_ctrl.Text = this.s;
            m_ctrl.Tag = this;
            if ((ctrl is Button) || (ctrl is RadioButton) || (ctrl is CheckBox) || (ctrl is TextBox) || (ctrl is Label))
            {
                m_ctrl.MouseHover += m_ctrl_MouseHover;
            }
        }

        private void save_changes()
        {
            DataTable dt_Languages = new DataTable();
            string TableName = "lngRPM";
            string sAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (sAppDataFolder[sAppDataFolder.Length - 1] != '\\')
            {
                sAppDataFolder += "\\";
            }
            string lngRPM_XML_file = sAppDataFolder + TableName;
            DynSettings.SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
        }

        void m_ctrl_MouseHover(object sender, EventArgs e)
        {
            if (DynSettings.AllowToEditText)
            {
                Color clrorg = m_ctrl.BackColor;
                m_ctrl.BackColor = Color.Red;
                m_ctrl.Refresh();
                Thread.Sleep(200);
                m_ctrl.BackColor = Color.White;
                m_ctrl.Refresh();
                Thread.Sleep(200);
                m_ctrl.BackColor = Color.Red;
                m_ctrl.Refresh();
                Thread.Sleep(200);
                m_ctrl.BackColor = clrorg;

                if (Control.ModifierKeys.HasFlag(Keys.Control))
                {
                    if (complex_text_list == null)
                    {
                        if (Edit(ref sText))
                        {
                            m_ctrl.Text = this.s;
                            m_ctrl.Refresh();
                            save_changes();
                        }
                    }
                    else
                    {
                        Form_complex_text_edit fcledit_dlg = new Form_complex_text_edit(this);
                        fcledit_dlg.ShowDialog();
                    }
                }
            }
        }

        private void ctrl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (Edit(ref sText))
                {
                    m_ctrl.Text = this.s;
                    m_ctrl.Refresh();
                    save_changes();
                }
            }
        }

        internal void SetTextFromDataRow(DataRow dataRow)
        {
            for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
            {
                if (dataRow[i + 1] is string)
                {
                    sText[i] = (string)dataRow[i + 1];
                }
                else
                {
                    sText[i] = null;
                }
            }
        }

    }
}
