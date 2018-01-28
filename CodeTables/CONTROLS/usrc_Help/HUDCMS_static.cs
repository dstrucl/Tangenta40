using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public static class HUDCMS_static
    {
        private static string m_LocalUrl = "";

        public static bool GetLocalHtmlFile(Form pForm, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL,ref string sLocalHtmlFile)
        {

            if (m_ApplicationPath != null)
            {
                if (m_ApplicationPath.Length > 0)
                {
                    if (m_ApplicationPath[m_ApplicationPath.Length - 1] != '/')
                    {
                        m_ApplicationPath += "/";
                    }
                    if (GetRelativeURL(pForm, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        sLocalHtmlFile = m_ApplicationPath + RelativeBaseURL + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool LocalUrl(Form pForm, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL, ref string sLocalUrl)
        {
            string sFile = null;
             if (GetLocalHtmlFile(pForm, ref ModuleName, ref HtmlFileName, ref RelativeURL, ref sFile))
            {
                sLocalUrl =  "file:///" + sFile;
                return true;
            }
             return false;
        }

        private static string m_RemoteUrl = "https://dstrucl.github.io/Tangenta-Help/";
        public static string RemoteUrl
        {
            get { return m_RemoteUrl; }
            set { m_RemoteUrl = value; }
        }

        private static string m_ApplicationPath = "";
        public static string ApplicationPath
        {
            get { return m_ApplicationPath; }
            set { m_ApplicationPath = value; }
        }

        private static string m_ApplicationVersion = "";
        public static string ApplicationVersion
        {
            get { return m_ApplicationVersion; }
            set { m_ApplicationVersion = value; }
        }

        private static string m_Language = "";
        public static string Language
        {
            get { return m_Language; }
            set { m_Language = value; }
        }

        private static string RelativeBaseURL
        {
            get
            {
                if (m_ApplicationVersion != null)
                {
                    if (m_ApplicationVersion.Length > 0)
                    {
                        string slang = null;
                        if (m_Language != null)
                        {
                            if (m_Language.Length > 0)
                            {
                                slang = m_Language;
                            }
                        }
                        if (slang == null)
                        {
                            return m_ApplicationVersion + "/";
                        }
                        else
                        {
                            return m_ApplicationVersion + "/" + slang + "/"; ;
                        }
                    }
                }
                return null;
            }
        }

        public static bool GetRelativeURL(Form pForm, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL)
        {
            if (pForm != null)
            {
                string[] s = pForm.GetType().ToString().Split(new char[] { '.' });
                if (s.Length > 0)
                {
                    ModuleName = "";
                    HtmlFileName = s[s.Length - 1] + ".html";
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        ModuleName += s[i] + "/";
                    }
                    RelativeURL = RelativeBaseURL + ModuleName + HtmlFileName;
                    return true;
                }
            }
            return false;
        }
    }
}
