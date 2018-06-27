#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using LanguageControl;
using System.Net;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace LogFile
{

    public static class LogFile
    {
        public static RPC.RPC rpc = null;

        private static string m_VersionControlSourceVersion = null;
        public static string VersionControlSourceVersion
        {
            get
            {
                return m_VersionControlSourceVersion;
            }
            set
            {
                m_VersionControlSourceVersion = value;
            }
        }


        public enum eType {CLIENT,SERVER};
        public static eType m_eType = eType.CLIENT;
        private static bool bFirstWrite = true;
        private static ManageLogs_Form ManageLogsDlg = null;
        public const string const_inifile_prefix = "LogFile_DB_";
        public const int const_Log2DB_flag_Write2DB_on_exit = 0x01;
        public static Log_RemoteDB_data Log_RemoteDB_data_ProgramSettings = null;
        public static Log_DBConnection m_LogDB_con = null;
        public static string UserName = "Uknown User";
        public static string[] LogSplitSeparator = new string[] { "<#Log>" };



        public const int LOG_LEVEL_RUN_RELEASE = 1;
        public const int LOG_LEVEL_DEBUG_RELEASE = 2;
        public const int LOG_LEVEL_DEBUG_MESSAGE_BOX = 3;

        public const string sLOG_LEVEL_RUN_RELEASE = "LOG_LEVEL_RUN_RELEASE";
        public const string sLOG_LEVEL_DEBUG_RELEASE = "LOG_LEVEL_DEBUG_RELEASE";
        public const string sLOG_LEVEL_DEBUG_MESSAGE_BOX = "LOG_LEVEL_DEBUG_MESSAGE_BOX";

        public const string LOGLEVEL = "LOGLEVEL=";


        public static string strAppDir;
        public static string DefaultLogFileName;
        public static string Log_File;
        internal static string LogFileName;
        internal static string LogFolder;
        public static string LogDBConnectionString = null;
        public static int LogLevel;
        private static bool bTrigger = true;
        private static Mutex Mutex = new Mutex();
        private static int MutexTimeout_in_ms = 2000;
        internal static List<CanNotWriteLogClass> list_exlog = new List<CanNotWriteLogClass>();
        public static Image Image_Cancel = null;


        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool WriteLog2DBOnProgramExit
        {
            get
            {
                return (Settings.Log2DB_flags & const_Log2DB_flag_Write2DB_on_exit) > 0;
            }
            set
            {
                bool bValue = value;
                if (bValue)
                {
                    Settings.Log2DB_flags = Settings.Log2DB_flags | const_Log2DB_flag_Write2DB_on_exit;
                }
                else
                {
                    Settings.Log2DB_flags = Settings.Log2DB_flags & (~const_Log2DB_flag_Write2DB_on_exit);
                }
            }

        }

        public static int LanguageID = 0;

        private static bool GetLogLevelFromCommandLineArguments(string[] CommandLineArguments, ref int level)
        {
            if (CommandLineArguments != null)
            {
                if (CommandLineArguments.Length > 0)
                {
                    foreach (string sArg in CommandLineArguments)
                    {
                        string csArgs = sArg.ToLower();
                        int iLogLevel = csArgs.LastIndexOf(LOGLEVEL);
                        if (iLogLevel >= 0)
                        {
                            string sa = csArgs.Substring(iLogLevel + LOGLEVEL.Length);
                            if (sa.Length > 0)
                            {
                                level = Convert.ToInt32(sa);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal static void SetLogFile()
        {

            strAppDir = Application.UserAppDataPath;
            LogFolder = Settings.LogFolder;
            if (LogFile.LogFolder.Length == 0)
            {
                LogFile.LogFolder = strAppDir;
            }
            if (LogFile.LogFolder[LogFile.LogFolder.Length - 1] != '\\')
            {
                LogFile.LogFolder += "\\";
            }

            LogFileName = Settings.LogFile;

            if (!Directory.Exists(LogFolder))
            {
                if (LogFolder != null)
                {
                    if (LogFolder.Length > 0)
                    {
                        try
                        {

                            Directory.CreateDirectory(LogFolder);

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show("Log folder not created:" + LogFolder + "\r\nException:" + Ex.Message);
                        }
                    }
                }
            }

            if (!Directory.Exists(LogFolder))
            {
                MessageBox.Show("Log folder does not exist:" + LogFile.LogFolder + "\r\nLog folder is set to:" + strAppDir, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogFile.LogFolder = strAppDir;
                if (LogFile.LogFolder[LogFile.LogFolder.Length - 1] != '\\')
                {
                    LogFile.LogFolder += "\\";
                }
                Settings.LogFolder = LogFolder;
                Settings.Save();
            }
            LogFile.Log_File = LogFile.LogFolder + LogFileName;
        }

        public static void InitLogFile(string[] CommandLineArguments)
        {
            MutexTimeout_in_ms = Settings.MutexTimeout;
            if (!GetLogLevelFromCommandLineArguments(CommandLineArguments, ref LogLevel))
            {
                LogLevel = Settings.LogLevel;
                if (LogLevel < LOG_LEVEL_RUN_RELEASE)
                {
                    LogLevel = LOG_LEVEL_RUN_RELEASE;
                }
            }

            SetLogFile();
            //strAppDir =Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            //strAppDir = Application.LocalUserAppDataPath;

        }

        private static bool xWrite(int Level, string type, string s)
        {
            bool bRes = true; 
            if (Level <= LogLevel)
            {

                DateTime dt = DateTime.Now;
                string DateTimeString = ":" + dt.Day.ToString("D2") + ":" + dt.Month.ToString("D2") + ":" + dt.Year.ToString("D4") + ":" + dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + ":" + dt.Millisecond.ToString("D3");
                string sLine = LogSplitSeparator[0] + DateTimeString + "|" + type + Level.ToString() + "|" + s;

                if (Mutex.WaitOne(MutexTimeout_in_ms))
                {
                    try
                    {
                        TextWriter twr = new StreamWriter(Log_File, true);
                        twr.WriteLine(sLine);
                        twr.Close();
                    }
                    catch (Exception ex)
                    {
                        CanNotWriteLogClass exlog = new CanNotWriteLogClass(dt, type, s, ex.Message);
                        list_exlog.Add(exlog);
                        bRes = false;
                    }
                    finally
                    {
                        Mutex.ReleaseMutex();
                    }

                }
                else
                {
                    CanNotWriteLogClass exlog = new CanNotWriteLogClass(dt, type, s, "ERROR Log Mutex Timeout");
                    list_exlog.Add(exlog);
                }

                if (LogLevel == LogFile.LOG_LEVEL_DEBUG_MESSAGE_BOX)
                {
                    if (bTrigger)
                    {
                        MessageBox.Show(sLine, "LOG WRITE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (rpc!=null)
                {
                    if (type.Equals("E"))
                    {
                        RPC_LogFile(sLine);
                    }
                    else if (LogLevel >= LogFile.LOG_LEVEL_DEBUG_RELEASE)
                    {
                        RPC_LogFile(sLine);
                    }
                }
            }
            return bRes;
        }

        private static void RPC_LogFile(string sLine)
        {
            string ComputerInfo = GetComputerInfo();
            string sRPC_ErrMsg = "\r\n" +
                                 "  <div class ='VCsver'>" + VersionControlSourceVersion + "</div>\r\n" +
                                 "  <div class ='ComputerInfo'>" + GetComputerInfo() + "</div>\r\n" +
                                 "  <div class ='OsInfo'>" + getOSInfo() + "</div>\r\n" +
                                 "  <div class ='DotNetInfo'>" + GetDotNetVersion.GetVersionFromRegistry() + "</div>\r\n" +
                                 "  <div class ='Log'>" + sLine + "</div>\r\n" +
                                 "\r\n";
            RPC.RPCd rpcd = new RPC.RPCd("http://www.tangenta.si/RPCLog.php", sRPC_ErrMsg);
            rpc.Execute(rpcd);
            string sResult = rpcd.GetResult(10000);
            if (sResult != null)
            {
                if (sResult.Equals("Success"))
                {
                }
            }
        }

        public static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MEMORYSTATUSEX
        {
            internal uint dwLength;
            internal uint dwMemoryLoad;
            internal ulong ullTotalPhys;
            internal ulong ullAvailPhys;
            internal ulong ullTotalPageFile;
            internal ulong ullAvailPageFile;
            internal ulong ullTotalVirtual;
            internal ulong ullAvailVirtual;
            internal ulong ullAvailExtendedVirtual;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        private static double GlobalMemoryStatusEX()
        {
            MEMORYSTATUSEX statEX = new MEMORYSTATUSEX();
            statEX.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            double d = 0;
            if (GlobalMemoryStatusEx(ref statEX))
            {
                d = (double)statEX.ullTotalPhys;
            }
            return d;
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string sMacAddress = "";
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }


        public static string GetComputerInfo()
        {
            string scinfo = "MAC="+ GetMACAddress() + ";Username=" + Environment.UserName + "; MachineName=" + Environment.MachineName;
            string OStype = "; OS Type=";
            if (Environment.Is64BitOperatingSystem) { OStype = "64-Bit;"; } else { OStype = "32-Bit;"; }
            string CPUname = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            OStype += Environment.ProcessorCount.ToString() + ";"+ CPUname;
            scinfo += ";" + OStype + ";RAM=" + GlobalMemoryStatusEX().ToString();
            return scinfo;
        }

    internal static void Write(int Level, string type, string s)
        {
            if (xWrite(Level,type,s))
            {
                return;
            }
            else
            {
                if (bFirstWrite)
                {
                    
                    LogFile.LogFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)+"\\Log";
                    if (!Directory.Exists(LogFile.LogFolder))
                    {
                        Directory.CreateDirectory(LogFile.LogFolder);
                    }
                    if (Directory.Exists(LogFile.LogFolder))
                    {
                        LogFile.LogFileName = "Log.txt";
                        LogFile.Log_File = LogFile.LogFolder + "\\" + LogFile.LogFileName;
                        if (xWrite(Level, type, s))
                        {
                            Settings.LogFile = LogFile.LogFileName;
                            Settings.LogFolder = LogFile.LogFolder;
                            Settings.Save();
                            return;
                        }
                    }
                    for (;;)
                    {
                        MessageBox.Show(lng.s_LogFile.s + ":" + lng.s_Error.s + ":" + lng.s_CanNotWriteOrDeleteFileInFolder.s + ":\"" + Log_File + "\"");
                        ManageLogs_Form mng_log = new ManageLogs_Form(Image_Cancel);
                        if (mng_log.ShowDialog()==DialogResult.OK)
                        {
                            if (xWrite(Level, type, s))
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        public static void Write(int Level, string s)
        {
            Write(Level, "L", s);
        }

        public static void WriteRELEASE(string s)
        {
            Write(LogFile.LOG_LEVEL_RUN_RELEASE, "L", s);
        }

        public static void WriteDEBUG(string s)
        {
            if (LogLevel >= LogFile.LOG_LEVEL_DEBUG_RELEASE)
            {
                Write(LogFile.LOG_LEVEL_DEBUG_RELEASE, "L", s);
            }
        }

        public static void Log2DB()
        {
            Log2DB_Form log2db_frm = new Log2DB_Form();
            log2db_frm.ShowDialog();
        }

        public static Form LogManager(Form parentform,bool bDoModal)
        {
            if (ManageLogsDlg != null)
            {
                if (ManageLogsDlg.IsDisposed)
                {
                    ManageLogsDlg = null;
                }
            }
            if (ManageLogsDlg == null)
            {
                ManageLogsDlg = new ManageLogs_Form(Image_Cancel);
                if (parentform!=null)
                {
                    if (parentform.TopMost)
                    {
                        ManageLogsDlg.TopMost = true;
                    }
                }
                if (bDoModal)
                {
                    ManageLogsDlg.ShowDialog();
                }
                else
                {
                    ManageLogsDlg.Show();
                }
            }
            if (!bDoModal)
            {
                ManageLogsDlg.Activate();
            }
            return ManageLogsDlg;
        }

        public static void Trigger(bool p)
        {
            bTrigger = p;
        }

        public static bool Manage_DBConnection(Form ParentForm,string recent_items_folder, bool bChangeConnection)
        {
            if ((Settings.Log2DB_flags & const_Log2DB_flag_Write2DB_on_exit) > 0)
            {
                // Check LogDataBaseConnection
                if (m_LogDB_con == null)
                {
                    m_LogDB_con = new Log_DBConnection(recent_items_folder);
                }

                Log_RemoteDB_data_ProgramSettings = new Log_RemoteDB_data(const_inifile_prefix, 1, Log_DBConnection.eDBType.MSSQL, lng.s_Connection_To_LogTables_defualt_ProgramSettings.s);

                return GetConnection(ParentForm, Log_RemoteDB_data_ProgramSettings, bChangeConnection);
            }
            else
            {
                return true;
            }
        }


        public static bool GetConnection(Form ParentForm,Log_RemoteDB_data Log_RemoteDB_data_ProgramSettings, bool bChangeConnection)
        {
            string Err = null;
            if (bChangeConnection)
            {
                if (!m_LogDB_con.CreateNewDataBaseConnection(ParentForm, Log_RemoteDB_data_ProgramSettings))
                {
                    return false;
                }
            }
            if (m_LogDB_con.MakeDataBaseConnection(ParentForm, Log_RemoteDB_data_ProgramSettings))
            {
                if (Log_RemoteDB_data_ProgramSettings.Save(const_inifile_prefix, ref Err))
                {
                    if (CheckTables(m_LogDB_con))
                    {
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show("LogFile Tables not exists! Create LogFile Tables ?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            SQL_LogTables sql_log_tables = new SQL_LogTables(m_LogDB_con);
                            if (sql_log_tables.Create_SQL_LogTables())
                            {
                                if (CheckTables(m_LogDB_con))
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
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    Error.Show(Err);
                }
            }
            return false;
        }

        private static bool CheckTables(Log_DBConnection m_LogDB_con)
        {
            string Err = null;
            LogFile_DataSet.Log_VIEW m_Log_VIEW = new LogFile_DataSet.Log_VIEW(m_LogDB_con);
            m_Log_VIEW.Clear();
            m_Log_VIEW.select.all(true);
            if (m_Log_VIEW.Read(2, ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void WriteLog2DB(string UserName, string Description, ref int xLogFile_id)
        {
            WriteLog2DB_Form write_2_log_form = new WriteLog2DB_Form(m_LogDB_con, UserName, Description);
            write_2_log_form.ShowDialog();
            xLogFile_id = write_2_log_form.LogFile_id;
        }

    }
}
