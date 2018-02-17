using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace HUDCMS
{
    public static class HUDCMS_static
    {

        private static string RelativeURL = null;

        private static string m_LocalHelpPath = "";
        public static string LocalHelpPath
        {
            get {
                string sLocalHelpPath = null;
                if (m_LocalHelpPath != null)
                {
                    if (m_LocalHelpPath.Length > 0)
                    {
                        sLocalHelpPath = m_LocalHelpPath;
                    }
                }
                if (sLocalHelpPath != null)
                {
                    return sLocalHelpPath;
                }
                else
                {
                    if (m_ApplicationPath != null)
                    {
                        if (m_ApplicationPath.Length > 0)
                        {
                            if (m_ApplicationPath[m_ApplicationPath.Length - 1] != '/')
                            {
                                m_ApplicationPath += "/";
                            }
                        }
                        else
                        {
                            m_ApplicationPath = "";
                        }
                    }
                    else
                    {
                        m_ApplicationPath = "";
                    }

                    if (m_ApplicationVersion != null)
                    {
                        if (m_ApplicationVersion.Length > 0)
                        {
                            if (m_ApplicationVersion[m_ApplicationVersion.Length - 1] != '/')
                            {
                                m_ApplicationVersion += "/";
                            }
                        }
                        else
                        {
                            m_ApplicationVersion = "";
                        }
                    }
                    else
                    {
                        m_ApplicationVersion = "";
                    }
                    return ApplicationPath + "Tangenta-Help/";
                }
            }
            set {
                m_LocalHelpPath = value;
            }
        }

        private static string m_RemoteHelpURL = "";
        public static string RemoteHelpURL
        {
            get { return m_RemoteHelpURL; }
            set { m_RemoteHelpURL = value; }
        }

        private static string m_slng_LocalHtmlFile = "Local html file ";

        public static string slng_LocalHtmlFile { get { return m_slng_LocalHtmlFile; }
                                                 set { m_slng_LocalHtmlFile = value; } }

        private static string m_slng_doesNotExist = " does not exist ";

        public static string slng_doesNotExist { get { return m_slng_doesNotExist; }
                                                 set { m_slng_doesNotExist = value; }
                                                }
        private static string m_slng_WriteSomethingAbout = "Write something about ";

        public static string slng_WriteSomethingAbout
        {
            get { return m_slng_WriteSomethingAbout; }
            set { m_slng_WriteSomethingAbout = value; }
        }

        private static string m_slng_Can_not_get_relative_URL = "ERROR:Can not_get relative URL";

        public static string slng_Can_not_get_relative_URL { get { return m_slng_Can_not_get_relative_URL; }
                                                             set { m_slng_Can_not_get_relative_URL = value; }
                                                            }

        private static string m_slng_JavaScriptElementsWillNotBoShownInHelp = "Java script will not work in help files!\r\n";

        public static string slng_JavaScriptElementsWillNotBoShownInHelp
        {
            get { return m_slng_JavaScriptElementsWillNotBoShownInHelp; }
            set { m_slng_JavaScriptElementsWillNotBoShownInHelp = value; }
        }
            
        internal static void SetControlAnchorTopLeftRight(Control ctrl)
        {
            ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
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

        private static string m_slng_UserControlName = "UserControl Name";
        public static string slng_UserControlName
        {
            get { return m_slng_UserControlName; }
            set { m_slng_UserControlName = value; }
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

        public static bool GetLocalHtmlFile(Form pForm,string prefix, ref string ModuleName, ref string HtmlFileName, ref string RemoteURL,ref string sLocalHtmlFile)
        {

            if (m_ApplicationPath != null)
            {
                if (m_ApplicationPath.Length > 0)
                {
                    if (m_ApplicationPath[m_ApplicationPath.Length - 1] != '/')
                    {
                        m_ApplicationPath += "/";
                    }
                    if (GetRelativeURL(pForm, prefix, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        if (LocalHelpPath!=null)
                        {
                            if (LocalHelpPath.Length>0)
                            {
                                if ((LocalHelpPath[LocalHelpPath.Length-1]!='/')&& (LocalHelpPath[LocalHelpPath.Length - 1] != '\\'))
                                {
                                    LocalHelpPath += '/';
                                }
                            }
                        }
                        sLocalHtmlFile = LocalHelpPath + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetLocalHtmlFile(string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string RemoteURL, ref string sLocalHtmlFile)
        {

            if (m_ApplicationPath != null)
            {
                if (m_ApplicationPath.Length > 0)
                {
                    if (m_ApplicationPath[m_ApplicationPath.Length - 1] != '/')
                    {
                        m_ApplicationPath += "/";
                    }
                    if (GetRelativeURL(prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        if (LocalHelpPath != null)
                        {
                            if (LocalHelpPath.Length > 0)
                            {
                                if ((LocalHelpPath[LocalHelpPath.Length - 1] != '/') && (LocalHelpPath[LocalHelpPath.Length - 1] != '\\'))
                                {
                                    LocalHelpPath += '/';
                                }
                            }
                        }
                        sLocalHtmlFile = LocalHelpPath + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool GetRemoteURL(Form pForm, string prefix,ref string ModuleName, ref string HtmlFileName, ref string RelativeURL, ref string sRemoteURL)
        {

            if (m_RemoteUrl != null)
            {
                if (m_RemoteUrl.Length > 0)
                {
                    if (m_RemoteUrl[m_RemoteUrl.Length - 1] != '/')
                    {
                        m_RemoteUrl += "/";
                    }
                    if (GetRelativeURL(pForm,prefix, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        sRemoteURL = RemoteUrl + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetRemoteURL(string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL, ref string sRemoteURL)
        {

            if (m_RemoteUrl != null)
            {
                if (m_RemoteUrl.Length > 0)
                {
                    if (m_RemoteUrl[m_RemoteUrl.Length - 1] != '/')
                    {
                        m_RemoteUrl += "/";
                    }
                    if (GetRelativeURL(prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        sRemoteURL = RemoteUrl + RelativeURL;
                        return true;
                    }
                }
            }
            return false;
        }


        public static bool LocalUrl(Form pForm,string prefix, ref string ModuleName, ref string HtmlFileName, ref string xRelativeURL, ref string sLocalUrl)
        {
            string sFile = null;
             if (GetLocalHtmlFile(pForm, prefix, ref ModuleName, ref HtmlFileName, ref xRelativeURL, ref sFile))
            {
                sLocalUrl =  "file:///" + sFile;
                return true;
            }
             return false;
        }

        private static string m_RemoteUrl = "https://dstrucl.github.io/Tangenta-Help/";
        public static string RemoteUrl
        {
            get { if (m_RemoteHelpURL != null)
                    {
                        if (m_RemoteHelpURL.Length > 0)
                        {
                            return m_RemoteHelpURL;
                        }
                    }
                    return m_RemoteUrl;
                }
            set { m_RemoteUrl = value; }
        }

        public static string RemoteDomain
        {
            get
            {
                if (m_RemoteHelpURL != null)
                {
                    if (m_RemoteHelpURL.Length > 0)
                    {
                        int iStartDomain = RemoteUrl.IndexOf("//");
                        if (iStartDomain<0)
                        {
                            iStartDomain = RemoteUrl.IndexOf("/");
                        }
                        if (iStartDomain >= 0)
                        {
                            string s = RemoteUrl.Substring(iStartDomain);
                            int iEndDomain = s.IndexOf("/");
                            if (iEndDomain>=0)
                            {
                                s = s.Substring(0, iEndDomain);
                            }
                            return s;
                        }
                    }
                }
                return null;
            }
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

        public static bool GetDomainFromUrl(string url,ref string domain,ref string Err)
        {
            Err = null;
            try
            {
                Uri myUri = new Uri(url);
                domain = myUri.Host;  // host is "www.contoso.com"
                return true;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
        }
        public static bool DomainAccesible(string url, ref string Err)
        {
            string host = null;
            if (GetDomainFromUrl(url, ref host, ref Err))
            {
                try
                {
                    Ping myPing = new Ping();
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                    bool bres = (reply.Status == IPStatus.Success);
                    if (!bres)
                    {
                        Err = host + " is not accessible!";
                    }
                    return bres;
                }
                catch (Exception ex)
                {
                    Err = host + " doesn't exist: " + ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
                
        }

        public static bool URLExists(string url, ref string Err)
        {
        

            bool result = false;
            Err = null;
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.WebRequest wc = System.Net.WebRequest.Create(url); //args[0]);
            ((HttpWebRequest)wc).UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/0.2.153.1 Safari/525.19";
            wc.Timeout = 1000;
            wc.Method = "HEAD";


            //WebRequest webRequest = WebRequest.Create(url);
            //webRequest.Timeout = 1200; // miliseconds
            //webRequest.Method = "HEAD";

            //HttpWebResponse response = null;
            WebResponse response = null;
            try
            {
                response = wc.GetResponse();
//                response = (HttpWebResponse)webRequest.GetResponse();
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

        private static string Relative_ApplicationVersionAndLangugagePath
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
                            if (m_ApplicationVersion[m_ApplicationVersion.Length - 1] == '/')
                            {
                                return m_ApplicationVersion + slang + "/";
                            }
                            else
                            {
                                return m_ApplicationVersion + "/" + slang + "/";
                            }
                        }
                    }
                }
                return null;
            }
        }

        public static string Local_ApplicationVersionAndLangugagePath
        {
            get
            {
                return LocalHelpPath + Relative_ApplicationVersionAndLangugagePath;
            }
        }

        public static string Remote_ApplicationVersionAndLangugagePath
        {
            get
            {
                return RemoteUrl + Relative_ApplicationVersionAndLangugagePath;
            }
        }


        public static bool GetRelativeURL(Form pForm,string prefix, ref string ModuleName, ref string HtmlFileName, ref string xRelativeURL)
        {
            if (pForm != null)
            {
                string[] s = pForm.GetType().ToString().Split(new char[] { '.' });
                if (s.Length > 0)
                {
                    ModuleName = "";
                    HtmlFileName = prefix + s[s.Length - 1] + ".html";
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        ModuleName += s[i] + "/";
                    }
                    xRelativeURL = Relative_ApplicationVersionAndLangugagePath + ModuleName + HtmlFileName;
                    return true;
                }
            }
            return false;
        }

        public static bool GetRelativeURL(string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string xRelativeURL)
        {
            if (sNameSpaceDotType != null)
            {
                string[] s = sNameSpaceDotType.Split(new char[] { '.' });
                if (s.Length > 0)
                {
                    ModuleName = "";
                    HtmlFileName = prefix+s[s.Length - 1] + ".html";
                    for (int i = 0; i < s.Length - 1; i++)
                    {
                        ModuleName += s[i] + "/";
                    }
                    xRelativeURL = Relative_ApplicationVersionAndLangugagePath + ModuleName + HtmlFileName;
                    return true;
                }
            }
            return false;
        }

    }
}
