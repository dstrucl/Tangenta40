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

namespace LogFile
{

    public static class LogFile
    {
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
                    using (var stream = client.OpenRead("http://wwww.google.com"))
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
            }
            return bRes;
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
                        MessageBox.Show(lngRPM.s_LogFile.s + ":" + lngRPM.s_Error.s + ":" + lngRPM.s_CanNotWriteOrDeleteFileInFolder.s + ":\"" + Log_File + "\"");
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

                Log_RemoteDB_data_ProgramSettings = new Log_RemoteDB_data(const_inifile_prefix, 1, Log_DBConnection.eDBType.MSSQL, LanguageControl.lngRPM.s_Connection_To_LogTables_defualt_ProgramSettings.s);

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
