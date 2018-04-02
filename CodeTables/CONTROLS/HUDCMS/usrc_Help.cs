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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HUDCMS
{
    public partial class usrc_Help: UserControl
    {
        public delegate void delegate_HelpClicked(ref string prefix);
        public event delegate_HelpClicked HelpClicked = null;

        internal Form pForm = null;
        internal string Prefix = "";

        public Form_Help hlp_dlg = null;
        internal usrc_web_Help uwebHelp = null;


        internal string RemoteURL = null;
        internal string RelativeURL = null;
        internal string ModuleName = null;
        internal string HtmlFileName = null;
        private string m_sLocalHtmlFile = null;

        internal string LocalHtmlFile
        {
            get
            {
                return m_sLocalHtmlFile;
            }
            set
            {
                m_sLocalHtmlFile = value;
            }
        }


        private bool m_RemoteURL_accessible = false;

        private bool m_LocalHtmlFile_exist = false;

        internal string Err_Local = "";
        internal string Err_Remote = "";

        internal bool RemoteURL_accessible
        {
            get { return m_RemoteURL_accessible; }
            set
            {
                m_RemoteURL_accessible = value;
            }
        }

        internal bool LocalHtmlFile_exist
        {
            get { return m_LocalHtmlFile_exist; }
            set
            {
                m_LocalHtmlFile_exist = value;
            }
        }


        public usrc_Help()
        {
            InitializeComponent();
        }

        internal bool GetRemoteURL(string prefix)
        {
            if (HUDCMS_static.GetRemoteURL(pForm,prefix, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref RemoteURL))
            {
                //if (HUDCMS_static.URLExists(RemoteURL, ref Err_Remote))
                if (HUDCMS_static.DomainAccesible(RemoteURL, ref Err_Remote))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Err_Remote = "Can not get RemoteURL";
                return false;
            }
        }

        internal bool GetRemoteURL(Form xpForm,string prefix,string  sNameSpaceDotType)
        {
            if (HUDCMS_static.GetRemoteURL(xpForm,prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref RemoteURL))
            {
                //if (HUDCMS_static.URLExists(RemoteURL, ref Err_Remote))
                if (HUDCMS_static.DomainAccesible(RemoteURL, ref Err_Remote))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Err_Remote = "Can not get RemoteURL";
                return false;
            }
        }

        internal bool GetLocalURL(string prefix)
        {
            Err_Local = null;
            string sLocalHtmlFile = null;
            if (HUDCMS_static.GetLocalHtmlFile(pForm, prefix, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref sLocalHtmlFile))
            {
                LocalHtmlFile = sLocalHtmlFile;
                if (File.Exists(sLocalHtmlFile))
                {
                    return true;
                }
                else
                {
                    //Local File does not exist
                    Err_Local = HUDCMS_static.slng_LocalHtmlFile + ":\"" + sLocalHtmlFile + "\" " + HUDCMS_static.slng_doesNotExist;
                    return false;
                }
            }
            else
            {
                Err_Local = HUDCMS_static.slng_Can_not_get_relative_URL;
                return false;
            }

        }

        internal bool GetLocalURL(Form xpForm,string prefix,string sNameSpaceDotType)
        {
            Err_Local = null;
            string sLocalHtmlFile = null;
            if (HUDCMS_static.GetLocalHtmlFile(xpForm,prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref sLocalHtmlFile))
            {
                LocalHtmlFile = sLocalHtmlFile;
                if (File.Exists(sLocalHtmlFile))
                {
                    return true;
                }
                else
                {
                    //Local File does not exist
                    Err_Local = HUDCMS_static.slng_LocalHtmlFile + ":\"" + sLocalHtmlFile + "\" " + HUDCMS_static.slng_doesNotExist;
                    return false;
                }
            }
            else
            {
                Err_Local = HUDCMS_static.slng_Can_not_get_relative_URL;
                return false;
            }

        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            if (HelpClicked!=null)
            {
                HelpClicked(ref Prefix);
            }
            pForm = Global.f.GetParentForm(this);

            RemoteURL_accessible = GetRemoteURL(Prefix);
            LocalHtmlFile_exist = GetLocalURL(Prefix);

            if (hlp_dlg==null)
            {
                hlp_dlg = new Form_Help(this);
                hlp_dlg.FormClosed += Hlp_dlg_FormClosed;
            }
            hlp_dlg.Show();
        }

        private void Hlp_dlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!hlp_dlg.IsDisposed)
            {
                if (hlp_dlg.IsAccessible)
                {
                    hlp_dlg.Close();
                }
                hlp_dlg.Dispose();
            }
            hlp_dlg = null;
        }
    }
}
