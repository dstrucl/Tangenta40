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
using DBConnectionControl40;

namespace CodeTables
{
    public class IndexBox : TextBox
    {
        public bool m_bValid = false;

        public ID Initial_ID = null;

        private ID m_ID = null;

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

        public ID ID
        {
            get
            {
                try
                {
                    string s = base.Text;
                    if (s.Length>0)
                    {
                        if (m_ID == null)
                        {
                            m_ID = new ID();
                        }
                        if (m_ID.Set(s))
                        {
                            return m_ID;
                        }
                        else
                        {
                            return null;
                        }
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
            set
            {
                ID xid = value;
                if (m_ID != null)
                {
                    if (xid != null)
                    {
                        m_ID = xid;
                    }
                    else
                    {
                        m_ID = xid;
                    }
                }
                else
                {
                    if (xid != null)
                    {
                        m_ID = new ID(xid);
                    }
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
                                Initial_ID = new ID(Convert.ToInt64(s));
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
