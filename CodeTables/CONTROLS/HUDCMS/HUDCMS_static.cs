using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public static class HUDCMS_static
    {
        private static string m_LocalUrl = "";

        private static string m_slng_LocalHtmlFile = "Local html file ";

        public static string slng_LocalHtmlFile { get { return m_slng_LocalHtmlFile; }
                                                 set { m_slng_LocalHtmlFile = value; } }

        private static string m_slng_doesNotExist = " does not exist ";

        public static string slng_doesNotExist { get { return m_slng_doesNotExist; }
                                                 set { m_slng_doesNotExist = value; }
                                                }

        private static string m_slng_Can_not_get_relative_URL = "ERROR:Can not_get relative URL";

        public static string slng_Can_not_get_relative_URL { get { return m_slng_Can_not_get_relative_URL; }
                                                             set { m_slng_Can_not_get_relative_URL = value; }
                                                            }

        internal static void SetControlAnchorAll(Control ctrl)
        {
            ctrl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        private static string m_slng_LocalURL = "Local HTML";

        private static string m_slng_FormName = "Form Name";
        public static string slng_FormName
        {
            get { return m_slng_FormName; }
            set { m_slng_FormName = value; }
        }
        private static string m_slng_FormTitle = "Form Caption";
        public static string slng_FormTitle
        {
            get { return m_slng_FormTitle; }
            set { m_slng_FormTitle = value; }
        }

        public static string slng_LocalURL
        {
            get { return m_slng_LocalURL; }
            set { m_slng_LocalURL = value; }
        }

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
                        sLocalHtmlFile = m_ApplicationPath + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetRemoteURL(Form pForm, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL, ref string sRemoteURL)
        {

            if (m_RemoteUrl != null)
            {
                if (m_RemoteUrl.Length > 0)
                {
                    if (m_RemoteUrl[m_RemoteUrl.Length - 1] != '/')
                    {
                        m_RemoteUrl += "/";
                    }
                    if (GetRelativeURL(pForm, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        sRemoteURL = m_RemoteUrl + RelativeURL;
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

        public static bool URLExists(string url, ref string Err)
        {
            bool result = false;
            Err = null;
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 1200; // miliseconds
            webRequest.Method = "HEAD";

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
                result = true;
            }
            catch (WebException webException)
            {
                Err= url + " doesn't exist: " + webException.Message;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
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
