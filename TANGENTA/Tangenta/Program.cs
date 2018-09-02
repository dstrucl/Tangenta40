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
using System.Windows.Forms;
using TangentaDataBaseDef;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using LanguageControl;
using System.Threading;
using System.Diagnostics;
using DBConnectionControl40;
using DBTypes;
using FiscalVerificationOfInvoices_SLO;
using TangentaDB;
using System.Reflection;
using TangentaPrint;
using LoginControl;
using static TangentaDB.CashierActivity;

namespace Tangenta
{
    internal static class Program
    {

        #region Constants
        internal const string TANGENTA_SETTINGS_SUB_FOLDER = "\\TangentaSettings";
        internal const string TANGENTA_SQLITEBACKUP_SUB_FOLDER = "\\TangentaSQliteBackup";
        internal const string TANGENTA_VODSHEMA_SUB_FOLDER = "\\TangentaVODshema";
        private const string const_command_DOCINVOICE = "DOCINVOICE";
        private const string const_command_DOCPROFORMAINVOICE = "DOCPROFORMAINVOICE";
        private const string const_command_CHANGE_CONNECTION = "CHANGE-CONNECTION";
        private const string const_command_RESETNEW = "RESETNEW";
        private const string const_command_AUTONEXT = "AUTONEXT";
        private const string const_command_DIAGNOSTIC = "DIAGNOSTIC";
        private const string const_command_SYMULATOR = "SYMULATOR";
        private const string const_command_RS232MONITOR = "RS232MONITOR";



        #endregion

        #region Variables
        internal static string AdministratorLockedPassword = "dhlpt"; //"dhlpt" is Locked password for "12345"


        internal static class OperationMode
        {
            internal static bool MultiUser = true;
            internal static bool SingleUserLoginAsAdministrator = false;
            internal static bool StockCheckAtStartup = true;
            internal static bool ShopC_ExclusivelySellFromStock = false;
            internal static bool MultiCurrency = false;
            internal static int NumberOfMonthAfterNewYearToAllowCreateNewInvoice = 1;
            internal static bool FiscalVerificationOfInvoices = false;
        }


        private static string m_RunAs = null;

        internal static RPC.RPC rpc = null;

        internal static string RunAs
        {
            get
            {
                if (m_RunAs != null)
                {
                    if (m_RunAs.ToUpper().Equals(const_command_DOCINVOICE))
                    {
                        return GlobalData.const_DocInvoice;
                    }
                    else if (m_RunAs.ToUpper().Equals(const_command_DOCPROFORMAINVOICE))
                    {
                        return GlobalData.const_DocProformaInvoice;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:RunAs=" + m_RunAs + " not implemented!");
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set { string s = value;
                m_RunAs = s.ToUpper();
                }   
        }

        internal static NavigationButtons.Navigation nav = null;
        internal static bool m_bAutoNext = false;
        internal static int Auto_NEXT_in_miliseconds = 10;
        internal static bool Auto_NEXT
        {
            get { return m_bAutoNext && bFirstTimeInstallation; }
        }

        internal static bool bStartup = true;

        internal static string IniFileName = "Tangenta.ini";
        internal static string IniFolder = "";
        internal static string IniFile = "";

        internal static FVI_SLO FVI_SLO1 = null;

        internal static FVI_SLO_MessageBox message_box = null;

        internal static Thread_FVI thread_fvi = null;

        internal static Form_Document MainForm = null;

        internal static bool bShowCommandLineHelp = false;
        internal static bool bDemo = false;

        internal static List<CommandLineHelp.CommandLineHelp> command_line_help = new List<CommandLineHelp.CommandLineHelp>();

        internal static bool bResetNew = false;
        internal static bool bChangeConnection = false;
        internal static bool bSymulator = false;
        internal static bool bRS232Monitor = false;

        internal static ID ProgramModule_ID = null;

        internal static bool m_CountryHasFVI = false;

        internal static bool CountryHasFVI
        {
            get
            {
                return m_CountryHasFVI;
            }
            set
            {
                m_CountryHasFVI = value;
            }
        }

        internal static bool b_FVI_SLO
        {
            get {
                return OperationMode.FiscalVerificationOfInvoices;
                }
            set {
                OperationMode.FiscalVerificationOfInvoices = value;
                }
        }


        

        internal static bool Login_MultipleUsers
        {
            get
            {
                if (OperationMode.MultiUser)
                {
                    return Properties.Settings.Default.Login_MultipleUsers;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static class Reset2FactorySettings
        {
            internal static bool Tangenta_EXE = false;
            internal static bool DBConnectionControlXX_EXE = false;
            internal static bool CodeTables_DLL = false;
            internal static bool LangugaControl_DLL = false;
            internal static bool TangentaPrint_DLL = false;
            internal static bool FiscalVerification_DLL = false;
            internal static bool LogFile_DLL = false;
            internal static bool ColorSettings_DLL = false;
        }

        public static bool bFirstTimeInstallation = false;

        private static bool m_bProgramDiagnostic = false;

        public static List<Control> ListOfAllSplitConatinerControls = new List<Control>(); // used for save user resize 
        public static string SplitConatinerControlsDefaulValues = "";
        #endregion

        #region External WIN_API
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        extern private static  bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);
        #endregion

        #region Properties

        public static string Shops_in_use
        {
            get { return Properties.Settings.Default.eShopsInUse; }
        }

        public static eCashierState CashierState
        {
            get
            {
                if (MainForm != null)
                {
                    return MainForm.CashierState;
                }
                else
                {
                    return eCashierState.CLOSED;
                }
            }
        }

        public static bool ProgramDiagnostic
        {
            get { return m_bProgramDiagnostic; }
        }

        public static string AssemblyName
        {
            get
            {
                return typeof(Tangenta.Program).Assembly.GetName().Name;
            }
        }

        public static bool ControlLayout_TouchScreen
        {
            get
            {
                return Properties.Settings.Default.ControlLayout_TouchScreen;
            }
        }

        public static bool RecordCashierActivity
        {
            get
            {
                if (MainForm != null)
                {
                    return MainForm.RecordCashierActivity;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (MainForm != null)
                {
                    MainForm.RecordCashierActivity = value;
                }
            }
        }


        public static bool UseWorkAreas {
                                        get { return Properties.Settings.Default.UseWorkAreas; }

                                    }


        #endregion

        #region Methods

        internal static int getGuiResourcesUserCount()
        {
            return GetGuiResources(System.Diagnostics.Process.GetCurrentProcess().Handle, 1);
        }





        internal static int Get_BaseCurrency_DecimalPlaces()
        {
            if (GlobalData.BaseCurrency != null)
            {
                return GlobalData.BaseCurrency.DecimalPlaces;
            }
            else
            {
                LogFile.Error.Show("ERROR:Program:Get_DecimalPlaces:BaseCurrency is not defined!");
                return 0;
            }
        }

        internal static void Cursor_Wait()
        {
            if (MainForm != null)
            {
                MainForm.Cursor = Cursors.WaitCursor;
            }
        }

        internal static void Cursor_Arrow()
        {
            if (MainForm != null)
            {
                MainForm.Cursor = Cursors.Arrow;
            }
        }


        internal static string GetInvoiceNumber(bool bDraft, int FinancialYear, int NumberInFinancialYear, int DraftNumber)
        {
            string sNumber = null;
            if (bDraft)
            {
                sNumber = FinancialYear.ToString() + "/" + lng.s_Draft.s + " " + DraftNumber.ToString();
            }
            else
            {
                sNumber = FinancialYear.ToString() + "/" + NumberInFinancialYear.ToString();
            }
            return sNumber;
        }

        #endregion

       
        private static void Parse_CommandLineArguments(string[] CommandLineArguments)
        {
            if (CommandLineArguments != null)
            {
                foreach (string s in CommandLineArguments)
                {

                    if (s.Contains("?") || s.ToLower().Contains("help"))
                    {
                        bShowCommandLineHelp = true;
                    }
                    else if (s.Contains("DEMO") || s.ToLower().Contains("demo"))
                    {
                        bDemo = true;
                    }
                    else
                    {
                        if (s.ToUpper().Contains(const_command_DOCINVOICE))
                        {
                            RunAs = GlobalData.const_DocInvoice;
                        }
                        if (s.ToUpper().Contains(const_command_DOCPROFORMAINVOICE))
                        {
                            RunAs = GlobalData.const_DocProformaInvoice;
                        }
                        if (s.Contains(const_command_CHANGE_CONNECTION))
                        {
                            bChangeConnection = true;
                        }
                        if (s.Contains(const_command_SYMULATOR))
                        {
                            bSymulator = true;
                        }
                        if (s.Contains(const_command_RS232MONITOR))
                        {
                            bRS232Monitor = true;
                        }
                        if (s.Contains(const_command_DIAGNOSTIC))
                        {
                            m_bProgramDiagnostic = true;
                        }
                        if (s.Contains(const_command_RESETNEW))
                        {
                            bResetNew = true;
                        }
                        if (s.Contains(const_command_AUTONEXT))
                        {
                            int iAutoNext = s.IndexOf(const_command_AUTONEXT);
                            if (iAutoNext>=0)
                            {
                                iAutoNext += const_command_AUTONEXT.Length;
                                Auto_NEXT_in_miliseconds = fs.GetFirstIntParamFromString(s.Substring(iAutoNext));
                                if (Auto_NEXT_in_miliseconds<=0)
                                {
                                    MessageBox.Show(lng.s_AUTONEXT_missing_parameter.s);
                                    Auto_NEXT_in_miliseconds = 10;
                                }
                            }
                            m_bAutoNext = true;
                        }
                    }
                }
            }       
        }

        public enum eCommandLineHelpResult {OK,DO_SELECT_LANGUAGE,EXIT }


        public static void SaveHelpSettings(string LocalHelpPath,string RemoteHelpURL)
        {
            bool xbHelpSettingsChanged = false;
            if (LocalHelpPath != null)
            {
                if (LocalHelpPath.Length > 0)
                {
                    Properties.Settings.Default.HelpLocalPath = LocalHelpPath;
                    xbHelpSettingsChanged = true;
                }
            }
            if (RemoteHelpURL != null)
            {
                if (RemoteHelpURL.Length > 0)
                {
                    Properties.Settings.Default.HelpRemoteURL = RemoteHelpURL;
                    xbHelpSettingsChanged = true;
                }
            }
            if (xbHelpSettingsChanged)
            {
                Properties.Settings.Default.Save();
            }

        }

        public static eCommandLineHelpResult DoCommandLineHelp(ref string[] CommandLineArguments,
                                                               bool bLanguageSelectDialogShown,
                                                               ref bool bExitBeforeLogFileInitialised)
        {
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_DOCINVOICE, lng.s_commandline_DOCINVOICE.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_DOCPROFORMAINVOICE, lng.s_commandline_DOCPROFORMAINVOICE.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_CHANGE_CONNECTION, lng.s_commandline_CHANGE_CONNECTION.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_RESETNEW, lng.s_commandline_RESETNEW.s));
//            command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DIAGNOSTIC, lng.s_const_command_DIAGNOSTIC.s));
//            command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_AUTONEXT, lng.s_commandline_AUTONEXT.s));

            NavigationButtons.Navigation CommandLineHelpNav = new NavigationButtons.Navigation(null);
            if (Auto_NEXT)
            {
                CommandLineHelpNav.m_Auto_NEXT = new NavigationButtons.Auto_NEXT(10);
            }
            CommandLineHelpNav.bDoModal = true;
            CommandLineHelpNav.m_eButtons = NavigationButtons.Navigation.eButtons.PrevNextExit;
            if (bLanguageSelectDialogShown)
            {
                CommandLineHelpNav.btn1_Visible = true;
                CommandLineHelpNav.btn1_Image = Properties.Resources.Prev;
            }
            else
            {
                CommandLineHelpNav.btn1_Visible = false;
            }
            CommandLineHelpNav.btn1_Text = lng.s_Previous.s;
            CommandLineHelpNav.btn2_Image = Properties.Resources.Next;
            CommandLineHelpNav.btn2_Text = lng.s_Next.s;
            CommandLineHelpNav.btn2_Visible = true;
            CommandLineHelpNav.btn3_Image = Properties.Resources.Exit_Program;
            CommandLineHelpNav.btn3_Text = "";
            CommandLineHelpNav.btn3_Visible = true;
            CommandLineHelpNav.btn2_ToolTip_Text = "Press to go to next step";
            CommandLineHelpNav.btn3_ToolTip_Text = "Exit program Tangenta";
            CommandLineHelpNav.ExitProgramQuestionInLanguage = lng.s_RealyWantToExitProgram.s;

            CommandLineHelp.CommandLineHelp_Form hlp_frm = new CommandLineHelp.CommandLineHelp_Form(command_line_help,
                                                                                                    CommandLineHelpNav, 
                                                                                                    Properties.Resources.Tangenta_Question,
                                                                                                    Properties.Settings.Default.HelpLocalPath,
                                                                                                    Properties.Settings.Default.HelpRemoteURL,
                                                                                                    SaveHelpSettings);
            CommandLineHelpNav.ChildDialog = hlp_frm;
            CommandLineHelpNav.ShowDialog();
            if ((CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.OK) || (CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                bool bHelpSettingsChanged = false;
                if (hlp_frm.LocalHelpPath!=null)
                {
                    if (hlp_frm.LocalHelpPath.Length > 0)
                    {
                        Properties.Settings.Default.HelpLocalPath = hlp_frm.LocalHelpPath;
                        bHelpSettingsChanged = true;
                    }
                }
                if (hlp_frm.RemoteHelpURL!=null)
                {
                    if (hlp_frm.RemoteHelpURL.Length > 0)
                    {
                        Properties.Settings.Default.HelpRemoteURL = hlp_frm.RemoteHelpURL;
                        bHelpSettingsChanged = true;
                    }
                }
                if (bHelpSettingsChanged)
                {
                    Properties.Settings.Default.Save();
                }

                CommandLineArguments = hlp_frm.CommandLineArguments;
                Parse_CommandLineArguments(CommandLineArguments);
            }
            else if (CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
            {
                if (bLanguageSelectDialogShown)
                {
                    Properties.Settings.Default.LanguageID = -1;
                    return eCommandLineHelpResult.DO_SELECT_LANGUAGE;
                }
            }
            else
            {
                bExitBeforeLogFileInitialised = true;
                rpc.End();
                return eCommandLineHelpResult.EXIT;
            }
            return eCommandLineHelpResult.OK;
        }

        internal static string GetInformationalVersion(Assembly assembly)
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool bExitBeforeLogFileInitialised = false;
            string Err = null;
            rpc = new RPC.RPC();
            LogFile.LogFile.rpc = Program.rpc;
            LogFile.LogFile.VersionControlSourceVersion = GetInformationalVersion(Assembly.GetExecutingAssembly());
            if (rpc.Start(ref Err))
            {
                try
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    string[] CommandLineArguments = System.Environment.GetCommandLineArgs();

                    LanguageControl.DynSettings.InitLanguagePrefixList();


                    HUDCMS.HUDCMS_static.LanguagePrefixList = LanguageControl.DynSettings.LanguagePrefixList;
                    HUDCMS.HUDCMS_static.LanguageID = LanguageControl.DynSettings.LanguageID;

                    HUDCMS.HUDCMS_static.Language = "";

                    HUDCMS.HUDCMS_static.ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);

                    HUDCMS.HUDCMS_static.ApplicationVersion = Global.f.GetAssemblyVersion(Assembly.GetExecutingAssembly().GetName().Version.Build,
                                                                                          Assembly.GetExecutingAssembly().GetName().Version.Major,
                                                                                          Assembly.GetExecutingAssembly().GetName().Version.MajorRevision,
                                                                                          Assembly.GetExecutingAssembly().GetName().Version.Minor,
                                                                                          Assembly.GetExecutingAssembly().GetName().Version.MinorRevision);

                    var appName = Process.GetCurrentProcess().ProcessName + ".exe";
                    if (!HUDCMS.HUDCMS_static.SetIE8KeyforWebBrowserControl(appName, 11001, ref Err))
                    {
                        MessageBox.Show(HUDCMS.HUDCMS_static.slng_JavaScriptElementsWillNotBoShownInHelp,
                                        Err);
                    }


                    Parse_CommandLineArguments(CommandLineArguments);

                DoResetNew:
                    bool bLanguageSelectDialogShown = false;
                    bool bLanguageSelected = false;

                    if (bResetNew)
                    {
                        Properties.Settings.Default.Reset();
                        CodeTables.ASet.Settings_Reset();
                    }


                    HUDCMS.HUDCMS_static.Language = LanguageControl.DynSettings.LanguagePrefix;
                    HUDCMS.HUDCMS_static.LanguageID = LanguageControl.DynSettings.LanguageID;

                    NavigationButtons.lngRPM_strings.LanguagePrefix = LanguageControl.DynSettings.LanguagePrefix;
                    NavigationButtons.lngRPM_strings.s_OK = lng.s_OK.s;
                    NavigationButtons.lngRPM_strings.s_Cancel = lng.s_Cancel.s;

                    HUDCMS.HUDCMS_static.slng_LocalURL = lng.s_LocalHelpFolder.s;
                    HUDCMS.HUDCMS_static.slng_LocalHtmlFile = lng.s_slng_LocalHtmlFile.s;
                    HUDCMS.HUDCMS_static.slng_doesNotExist = lng.s_slng_dowsNotExist.s;
                    HUDCMS.HUDCMS_static.slng_Can_not_get_relative_URL = lng.s_slng_Can_not_get_relative_URL.s;
                    HUDCMS.HUDCMS_static.slng_JavaScriptElementsWillNotBoShownInHelp = lng.s_slng_JavaScriptElementsWillNotBoShownInHelp.s;
                    HUDCMS.HUDCMS_static.slng_WriteSomethingAbout = lng.s_slng_WriteSomethingAbout.s;
                    HUDCMS.HUDCMS_static.ControlInfo = CodeTables.Globals.ControlInfo;

                    DoSelectLanguage:
                    if (!bLanguageSelected)
                    {
                        SelectLanguage(ref bLanguageSelectDialogShown, ref bLanguageSelected, ref bExitBeforeLogFileInitialised);
                        if (bExitBeforeLogFileInitialised)
                        {
                            return; // end program
                        }
                    }

                    HUDCMS.HUDCMS_static.Language = LanguageControl.DynSettings.LanguagePrefix;
                    HUDCMS.HUDCMS_static.LanguageID = LanguageControl.DynSettings.LanguageID;

                    NavigationButtons.lngRPM_strings.LanguagePrefix = LanguageControl.DynSettings.LanguagePrefix;
                    NavigationButtons.lngRPM_strings.s_OK = lng.s_OK.s;
                    NavigationButtons.lngRPM_strings.s_Cancel = lng.s_Cancel.s;

                    ColorSettings.ControlColorDic.ImageCancel = Properties.Resources.Exit;
                    ColorSettings.ControlColorDic.sColorIndex = lng.s_ColorSettings_ControlColorDic_ColorIndex.s;
                    ColorSettings.ControlColorDic.sColorOfIndex = lng.s_ColorSettings_ControlColorDic_ColorOfIndex.s;
                    ColorSettings.ControlColorDic.sOfColorPallete = lng.s_ColorSettings_ControlColorDic_sOfColorPallete.s;
                    ColorSettings.ControlColorDic.sIsUsedOnTheseControls = lng.s_ColorSettings_ControlColorDic_sIsUsedOnTheseControls.s;

                    HUDCMS.HUDCMS_static.slng_LocalURL = lng.s_LocalHelpFolder.s;
                    HUDCMS.HUDCMS_static.slng_LocalHtmlFile = lng.s_slng_LocalHtmlFile.s;
                    HUDCMS.HUDCMS_static.slng_doesNotExist = lng.s_slng_dowsNotExist.s;
                    HUDCMS.HUDCMS_static.slng_Can_not_get_relative_URL = lng.s_slng_Can_not_get_relative_URL.s;
                    HUDCMS.HUDCMS_static.slng_JavaScriptElementsWillNotBoShownInHelp = lng.s_slng_JavaScriptElementsWillNotBoShownInHelp.s;
                    HUDCMS.HUDCMS_static.slng_WriteSomethingAbout = lng.s_slng_WriteSomethingAbout.s;
                    HUDCMS.HUDCMS_static.ControlInfo = CodeTables.Globals.ControlInfo;

                    if (bResetNew)
                    {
                        DoResetNewModules();
                        bResetNew = false;
                    }

                    if (bShowCommandLineHelp)
                    {
                        bShowCommandLineHelp = false;
                        switch (DoCommandLineHelp(ref CommandLineArguments,bLanguageSelectDialogShown,ref bExitBeforeLogFileInitialised))
                        {
                            case eCommandLineHelpResult.DO_SELECT_LANGUAGE:
                                goto DoSelectLanguage;
                            case eCommandLineHelpResult.EXIT:
                                return;

                        }
                    }

                    HUDCMS.HUDCMS_static.LocalHelpPath = Properties.Settings.Default.HelpLocalPath;
                    HUDCMS.HUDCMS_static.RemoteHelpURL = Properties.Settings.Default.HelpRemoteURL;
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        // code or timeout value when running tests in debug mode
                        if (Properties.Settings.Default.HelpLocalPath.Length == 0)
                        {
                            Properties.Settings.Default.HelpLocalPath = "C:\\Tangenta-Help\\";
                            Properties.Settings.Default.Save();
                            HUDCMS.HUDCMS_static.LocalHelpPath = Properties.Settings.Default.HelpLocalPath;
                        }
                    }

                        if (bResetNew)
                    {
                        goto DoResetNew;
                    }

                    Colors.Init();
                    Startup.Colors.Init();
                    CodeTables.Colors.Init();
                    ShopA.Colors.Init();
                    ShopB.Colors.Init();
                    ShopC.Colors.Init();
                    XMessage.Colors.Init();

                    SetColorSettingsText();
                    ColorSettings.Sheme.Load(ref Err);

                    IniFolder = Application.CommonAppDataPath;
                    int iLen = IniFolder.Length;
                    if (iLen > 0)
                    {
                        if (IniFolder[iLen - 1] != '\\')
                        {
                            IniFolder += '\\';
                        }
                    }
                    IniFile = IniFolder + IniFileName;

                    LogFile.LogFile.Image_Cancel = Properties.Resources.Exit;

                    LogFile.Settings.m_eType = LogFile.Settings.eType.IniFile_Settings;
                    if (!LogFile.Settings.Load(Reset2FactorySettings.LogFile_DLL, IniFile, ref Err))
                    {
                        MessageBox.Show("ERROR Loading LogFile Settings ! Err=" + Err);
                    }

                    LogFile.LogFile.InitLogFile(CommandLineArguments);

                    LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE, "ProgramStart !");

                    LanguageControl.DynSettings.Init();
                    SetAllModulesLanguages();
                    
                    LanguageControl.DynSettings.LoadLanguages(Reset2FactorySettings.LangugaControl_DLL);
                    LanguageControl.DynSettings.AllowToEditText = Properties.Settings.Default.AllowToEditLanguageText;


                    //if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                    //{
                    //    LogFile.LogFile.Write(1, "Another instance is allready running !");
                    //    MessageBox.Show(lng.s_Another_instance_is_running.s);
                    //    rpc.End();
                    //    return;
                    //}


                    bool createdNew = true;
                    using (Mutex mutex = new Mutex(true, "Tangenta2", out createdNew))
                    {
                        if (createdNew)
                        {
                            LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE, "Mutex Tangenta createdNew.");


                            MainForm = new Form_Document();
                            Application.Run(MainForm);
                            if (Program.nav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                            {
                                if (bLanguageSelected)
                                {
                                    bLanguageSelected = false;
                                    Properties.Settings.Default.LanguageID = -1;
                                    goto DoSelectLanguage;
                                }
                            }
                        }
                        else
                        {
                            Process current = Process.GetCurrentProcess();
                            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                            {
                                if (process.Id != current.Id)
                                {
                                    SetForegroundWindow(process.MainWindowHandle);
                                }
                                break;
                            }
                        }
                    }

                }
                catch (Exception Ex)
                {
                    if (Ex.InnerException != null)
                    {
                        if (Ex.InnerException.InnerException != null)
                        {
                            LogFile.Error.Show("ERROR!!:Program:Exception=" + Ex.Message + "\r\n STACK TRACE :\r\n" + Ex.StackTrace + "\r\n INNER EXCEPTION :\r\n" + Ex.InnerException.Message + "\r\n INNER-INNER EXCEPTION :\r\n" + Ex.InnerException.InnerException.Message);
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR!!:Program:Exception=" + Ex.Message + "\r\n STACK TRACE :\r\n" + Ex.StackTrace + "\r\n INNER EXCEPTION :\r\n" + Ex.InnerException.Message);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR!!:Program:Exception=" + Ex.Message + "\r\n STACK TRACE :\r\n" + Ex.StackTrace);
                    }
                    if (thread_fvi != null)
                    {
                        thread_fvi.End(message_box);
                    }
                }
                finally
                {
                    DBSync.DBSync.DB_for_Tangenta_SessionDisconnect();
                    if (!bExitBeforeLogFileInitialised)
                    {
                        if (LogFile.LogFile.WriteLog2DBOnProgramExit)
                        {
                            //LogFile.LogFile.WriteLog2DB(Program.UserName, "LogFile to DB on program Exit!", ref LogFile_id);
                        }
                    }
                }
                rpc.End();
            }
        }


        private static void SetColorSettingsText()
        {
            ColorSettings.Sheme.slng_AndFontSize = lng.slng_AndFontSize.s;
            ColorSettings.Sheme.slng_BackColor = lng.slng_BackColor.s;
            ColorSettings.Sheme.slng_ForeColor = lng.slng_ForeColor.s;
            ColorSettings.Sheme.slng_Form_ColorPicker_Caption = lng.slng_BackColor.s;
            ColorSettings.Sheme.slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily = lng.slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily.s;
        }

        private static void SetAllModulesLanguages()
        {
            lng.SetDictionary();
            LanguageControl.lng.SetDictionary();
            CommandLineHelp.lng.SetDictionary();
            Country_ISO_3166.lng.SetDictionary();
            CodeTables.lng.SetDictionary();
            DataGridView_2xls.lng.SetDictionary();
            Excell_Export.lng.SetDictionary();
            DynEditControls.lng.SetDictionary();
            DBTypes.lng.SetDictionary();
            DBConnectionControl40.lng.SetDictionary();
            LogFile.lng.SetDictionary();
            Password.lng.SetDictionary();
            TextBoxRecent.lng.SetDictionary();
            usrc_Item_Group_Handler.lng.SetDictionary();
            XMessage.lng.SetDictionary();
            DBSync.lng.SetDictionary();
            TangentaDataBaseDef.lng.SetDictionary();
            FiscalVerificationOfInvoices_SLO.lng.SetDictionary();
            TangentaDB.lng.SetDictionary();
            UniversalInvoice.lng.SetDictionary();
            Form_Discount.lng.SetDictionary();
            PriseLists.lng.SetDictionary();
            ShopA.lng.SetDictionary();
            ShopB.lng.SetDictionary();
            ShopC.lng.SetDictionary();
            Startup.lng.SetDictionary();
            TangentaSampleDB.lng.SetDictionary();
            ProgressForm.lng.SetDictionary();
            TangentaPrint.lng.SetDictionary();
            UpgradeDB.lng.SetDictionary();
            uwpfGUI.lng.SetDictionary();
            LoginControl.lng.SetDictionary();
        }

       

        private static void SelectLanguage(ref bool bLanguageSelectDialogShown,ref bool bLanguageSelected,ref bool bExitBeforeLogFileInitialised)
        {
            if (Properties.Settings.Default.LanguageID < 0)
            {
                bFirstTimeInstallation = true;
                NavigationButtons.Navigation LanguageNav = new NavigationButtons.Navigation(null);
                LanguageNav.bDoModal = true;
                LanguageNav.m_eButtons = NavigationButtons.Navigation.eButtons.PrevNextExit;
                LanguageNav.btn1_Visible = false;
                LanguageNav.btn2_Image = Properties.Resources.Next;
                LanguageNav.btn2_Text = "START";
                LanguageNav.btn2_Visible = true;
                LanguageNav.btn3_Image = Properties.Resources.Exit_Program;
                LanguageNav.btn3_Text = "";
                LanguageNav.btn3_Visible = true;
                LanguageNav.btn2_ToolTip_Text = "Press to select language and go to next step";
                LanguageNav.btn3_ToolTip_Text = "Exit program Tangenta";

                bLanguageSelectDialogShown = true;

                if (LanguageControl.DynSettings.SelectLanguage(Properties.Resources.Tangenta_Icon, AssemblyName, -1, LanguageNav))
                {
                    bLanguageSelected = true;
                    Properties.Settings.Default.LanguageID = LanguageControl.DynSettings.LanguageID;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    bExitBeforeLogFileInitialised = true;
                    rpc.End();
                    return;
                }
            }

            LogFile.Language.id = LanguageControl.DynSettings.LanguageID = Properties.Settings.Default.LanguageID;    //Settings_Tangenta.Settings.LanguageID; ;
        }

        private static void DoResetNewModules()
        {
            Form_Reset_Properties_Settings_Default frm_set = new Form_Reset_Properties_Settings_Default();

            if (frm_set.ShowDialog() == DialogResult.Yes)
            {
                Reset2FactorySettings.Tangenta_EXE = frm_set.bTangenta_EXE;
                Reset2FactorySettings.DBConnectionControlXX_EXE = frm_set.bDBConnectionControlXX_EXE;
                Reset2FactorySettings.CodeTables_DLL = frm_set.bCodeTables_DLL;
                Reset2FactorySettings.Tangenta_EXE = frm_set.bTangenta_EXE;
                Reset2FactorySettings.LangugaControl_DLL = frm_set.bLangugaControl_DLL;
                Reset2FactorySettings.TangentaPrint_DLL = frm_set.bTangentaPrint_DLL;
                Reset2FactorySettings.FiscalVerification_DLL = frm_set.bFiscalVerification_DLL;
                Reset2FactorySettings.ColorSettings_DLL = frm_set.bColorSettings_DLL;
            }
            else
            {
                Reset2FactorySettings.Tangenta_EXE = false;
                Reset2FactorySettings.DBConnectionControlXX_EXE = false;
                Reset2FactorySettings.CodeTables_DLL = false;
                Reset2FactorySettings.LangugaControl_DLL = false;
                Reset2FactorySettings.TangentaPrint_DLL = false;
                Reset2FactorySettings.FiscalVerification_DLL = false;
                Reset2FactorySettings.ColorSettings_DLL = false;
            }

            if (Reset2FactorySettings.CodeTables_DLL)
            {
                CodeTables.SQLTable.ResetSettings();
            }

            if (Reset2FactorySettings.ColorSettings_DLL)
            {
                ColorSettings.Sheme.ResetSettings();
            }

        }
    }
}
