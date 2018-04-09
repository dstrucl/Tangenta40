using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HUDCMS
{
    public static class HUDCMS_static
    {
        public delegate bool delegate_ControlInfo(object o, ref string title, ref string about, ref string description);
        public static delegate_ControlInfo ControlInfo = null;

        public delegate void delegate_ShowWizzard(Control ctrl);
        public static delegate_ShowWizzard ShowWizzard = null;


        public const int MAX_FILENAME_LENGTH = 127;

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

        public static bool GetLocalHtmlFile(Form xpForm,string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string RemoteURL, ref string sLocalHtmlFile)
        {

            if (m_ApplicationPath != null)
            {
                if (m_ApplicationPath.Length > 0)
                {
                    if (m_ApplicationPath[m_ApplicationPath.Length - 1] != '/')
                    {
                        m_ApplicationPath += "/";
                    }
                    if (GetRelativeURL(xpForm,prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL))
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

        public static bool GetRemoteURL(Form xpForm,string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string RelativeURL, ref string sRemoteURL)
        {

            if (m_RemoteUrl != null)
            {
                if (m_RemoteUrl.Length > 0)
                {
                    if (m_RemoteUrl[m_RemoteUrl.Length - 1] != '/')
                    {
                        m_RemoteUrl += "/";
                    }
                    if (GetRelativeURL(xpForm,prefix, sNameSpaceDotType, ref ModuleName, ref HtmlFileName, ref RelativeURL))
                    {
                        sRemoteURL = RemoteUrl + RelativeURL;
                        return true;
                    }
                }
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
            set {m_Language = value;
                }
        }

        private static void ChangeURL(string old_Language,string new_Language )
        {
            string s_old_Language_Pattern = "/" + old_Language + "/";
            string s_new_Language_Pattern = "/" + new_Language + "/";
            if (m_RemoteUrl.Contains(s_old_Language_Pattern))
            {
                m_RemoteUrl.Replace(s_old_Language_Pattern, s_new_Language_Pattern);
            }
            if (m_RemoteHelpURL.Contains(s_old_Language_Pattern))
            {
                m_RemoteHelpURL.Replace(s_old_Language_Pattern, s_new_Language_Pattern);
            }

            
        }

        public static List<string> LanguagePrefixList = null;

        private static int m_LanguageID = 0;

        public static int LanguageID
        {
            get { return m_LanguageID; }
            set
            {
                m_LanguageID = value;
                Language = LanguagePrefixList[m_LanguageID];
            }
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
                    string sFormName = null;
                    if (FormHasName(pForm,ref sFormName))
                    {
                        HtmlFileName = prefix + sFormName + ".html";
                    }
                    else
                    {
                        HtmlFileName = prefix + s[s.Length - 1] + ".html";
                    }
                    
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

        public static void Unzip_Help(string ZipFile)
        {
            if (ApplicationPath!=null)
            {
                if (ApplicationPath.Length>0)
                {
                    string zipsource = null;
                    string apppath = null;
                    if (ApplicationPath[ApplicationPath.Length-1]=='\\')
                    {
                        apppath =  ApplicationPath;
                    }
                    else
                    {
                        apppath = ApplicationPath + '\\';
                    }
                    zipsource = apppath + ZipFile;

                    if (File.Exists(zipsource))
                    {
                        string HelpDirectory = apppath + "Tangenta-Help";

                        if (Unzip(zipsource, HelpDirectory))
                        {
                            try
                            {
                                File.Delete(zipsource);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR:HUDCMS_static:Unzip_Help:can not delete file:" + zipsource + "\r\nException=" + ex.Message);
                            }
                        }
                    }

                }
            }
        }

        internal static string GetApplicationHelpFolder()
        {
            if (ApplicationPath != null)
            {
                if (ApplicationPath.Length > 0)
                {
                    string apppath = null;
                    if ((ApplicationPath[ApplicationPath.Length - 1] == '\\')|| (ApplicationPath[ApplicationPath.Length - 1] == '/'))
                    {
                        apppath = ApplicationPath;
                    }
                    else
                    {
                        apppath = ApplicationPath + '\\';
                    }
                    string HelpDirectory = apppath + "Tangenta-Help";
                    return HelpDirectory;
                }
            }
            return null;
        }

        internal static bool Unzip(string zipPath, string extractPath)
        {
            //string startPath = @"c:\example\start";
            //string zipPath = @"c:\example\result.zip";
            //string extractPath = @"c:\example\extract";
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning: Can not extract zip file:" + zipPath + "\r\nException =" + ex.Message);
                return false;
            }

        }

        internal static bool Zip(string startPath,string zipPath)
        {
            //string startPath = @"c:\example\start";
            //string zipPath = @"c:\example\result.zip";
            //string extractPath = @"c:\example\extract";
            try
            {
                System.IO.Compression.ZipFile.CreateFromDirectory(startPath, zipPath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning: Can not make zip file:" + zipPath + "\r\nException =" + ex.Message);
                return false;
            }

        }



        private static bool FormHasName(Form pForm, ref string sFormName)
        {
            if (pForm!=null)
            {
                if (pForm.Name != null)
                {
                    if (pForm.Name.Length>0)
                    {
                        sFormName = pForm.Name;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetRelativeURL(Form xpForm, string prefix,string sNameSpaceDotType, ref string ModuleName, ref string HtmlFileName, ref string xRelativeURL)
        {
            if (sNameSpaceDotType != null)
            {
                int indexofdot = sNameSpaceDotType.IndexOf('.');
                if (indexofdot > 0)
                { 
                    string[] s = sNameSpaceDotType.Split(new char[] { '.' });
                    if (s.Length > 0)
                    {
                        ModuleName = "";
                        string sFormName = null;
                        if (FormHasName(xpForm, ref sFormName))
                        {
                            HtmlFileName = prefix + sFormName + ".html";
                        }
                        else
                        {
                            HtmlFileName = prefix + s[s.Length - 1] + ".html";
                        }
                        for (int i = 0; i < s.Length - 1; i++)
                        {
                            ModuleName += s[i] + "/";
                        }
                        xRelativeURL = Relative_ApplicationVersionAndLangugagePath + ModuleName + HtmlFileName;
                        return true;
                    }
                }
                else
                {
                    ModuleName = "";
                    HtmlFileName = prefix + sNameSpaceDotType + ".html";
                    xRelativeURL = Relative_ApplicationVersionAndLangugagePath +  HtmlFileName;
                    return true;
                }
            }
            return false;
        }

        public static bool SetIE8KeyforWebBrowserControl(string appName, int IEVersion, ref string Err)
        {
            RegistryKey Regkey = null;
            string sRegKey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                {
                    sRegKey = @"SOFTWARE\\Wow6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sRegKey, true);
                }
                else  //For 32 bit machine
                {
                    sRegKey = @"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sRegKey, true);
                }

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    Err = "Internet Explorer Registry Settings \"" + sRegKey + "\" for \"" + appName + "\" Failed - Registry Key not found!";
                    return false;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == IEVersion.ToString())
                {
                    Regkey.Close();
                    return true;
                }

                // If a key is not present add the key, Key value 11000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)11001), RegistryValueKind.DWord);

                if (FindAppkey != IEVersion.ToString())
                {
                    Regkey.SetValue(appName, unchecked((int)IEVersion), RegistryValueKind.DWord);
                }

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == IEVersion.ToString())
                {
                    if (Regkey != null)
                        Regkey.Close();
                    return true;
                }
                else
                {
                    Err = "Internet Explorer Registry Settings \"" + sRegKey + "\" for \"" + appName + "\" not written, width emulation version DWORD:" + FindAppkey;
                    if (Regkey != null)
                        Regkey.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Err = "Internet Explorer Registry Settings \"" + sRegKey + "\" for \"" + appName + "\" Failed:" + ex.Message;
                return false;
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }
    }
}
