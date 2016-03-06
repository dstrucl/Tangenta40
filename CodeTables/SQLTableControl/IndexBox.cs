#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CodeTables
{
    public class IndexBox : TextBox
    {
        public bool m_bValid = false;

        public object Initial_ID = null;

        private ID_v m_ID_v = null;

        public IndexBox():base()
        {
            base.Cursor = Cursors.No;
            base.ReadOnly = true;
            base.BorderStyle = System.Windows.Forms.BorderStyle.None;
            
        }
        public bool Valid
        {
            get { return m_bValid;}
            set { m_bValid = value;
                if (!m_bValid)
                {
                    base.Text = "";
                }
                }
        }

        public ID_v ID_v
        {
            get
            {
                try
                {
                    string s = base.Text;
                    if (s.Length>0)
                    {
                        long id = Convert.ToInt64(s);
                        if (m_ID_v == null)
                        {
                            m_ID_v = new ID_v();
                        }
                        m_ID_v.v = id;
                        return m_ID_v;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch 
                {
                    return null;
                }
            }
        }

        public override string Text
        {
            get { return base.Text;}
            set {string s  = value;
                m_bValid = false;
                if (s != null)
                {
                    if (s.Length > 0)
                    {
                        base.Text = s;
                        m_bValid = true;
                        base.BackColor = Color.LightGray;
                        if (Initial_ID == null)
                        {
                            try
                            {
                                Initial_ID = Convert.ToInt64(s);
                            }
                            catch (Exception Ex)
                            {
                                LogFile.Error.Show("ERROR:IndexBox:public override string Text:Cannot convert \"" + s + "\" to Int64! " + Ex.Message);
                                Initial_ID = null;
                            }
                        }
                    }
                    else
                    {
                        base.Text = "";
                    }
                }
                else
                {
                    base.Text = "";
                }
            }
        }
    }
}
