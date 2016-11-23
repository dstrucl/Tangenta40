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

namespace Tangenta
{
    static class Program
    {

        #region Constants
        const string const_command_DOCINVOICE = "DOCINVOICE";
        const string const_command_DOCPROFORMAINVOICE = "DOCPROFORMAINVOICE";
        const string const_command_CHANGE_CONNECTION = "CHANGE-CONNECTION";
        const string const_command_RESETNEW = "RESETNEW";
        const string const_command_AUTONEXT = "AUTONEXT";
        const string const_command_DIAGNOSTIC = "DIAGNOSTIC";
        const string const_command_SYMULATOR = "SYMULATOR";
        const string const_command_RS232MONITOR = "RS232MONITOR";

        public const string const_DocInvoice = "DocInvoice";
        public const string const_DocProformaInvoice = "DocProformaInvoice";

        #endregion

        #region Variables
        internal static string AdministratorLockedPassword = "dhlpt"; //"dhlpt" is Locked password for "12345"
        internal static bool MultiuserOperationWithLogin = true;
        internal static bool StockCheckAtStartup = true;
        private static string m_RunAs = null;

        internal static string RunAs
        {
            get
            {
                if (m_RunAs != null)
                {
                    if (m_RunAs.ToUpper().Equals(const_command_DOCINVOICE))
                    {
                        return const_DocInvoice;
                    }
                    else if (m_RunAs.ToUpper().Equals(const_command_DOCPROFORMAINVOICE))
                    {
                        return const_DocProformaInvoice;
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

        internal static usrc_FVI_SLO usrc_FVI_SLO1 = null;
        internal static usrc_Printer usrc_Printer1 = null;

        internal static Form_Document MainForm = null;

        internal static bool bShowCommandLineHelp = false;
        internal static bool bDemo = false;

        internal static List<CommandLineHelp.CommandLineHelp> command_line_help = new List<CommandLineHelp.CommandLineHelp>();

        internal static bool bChangeConnection = false;
        internal static bool bSymulator = false;
        internal static bool bRS232Monitor = false;
        internal static bool b_FVI_SLO = false;
        internal static long Atom_FVI_SLO_RealEstateBP_ID = -1;
        internal static class Reset2FactorySettings
        {
            internal static bool Tangenta_EXE = false;
            internal static bool DBConnectionControlXX_EXE = false;
            internal static bool LangugaControl_DLL = false;
            internal static bool FiscalVerification_DLL = false;
            internal static bool LogFile_DLL = false;
        }

        public static bool bFirstTimeInstallation = false;

        private static bool m_bProgramDiagnostic = false;

        public static List<Control> ListOfAllSplitConatinerControls = new List<Control>(); // used for save user resize 
        public static string SplitConatinerControlsDefaulValues = "";
        #endregion

        #region External WIN_API
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);
        #endregion

        #region Properties

        public static string Shops_in_use
        {
            get { return Properties.Settings.Default.eShopsInUse; }
        }

        public static long myOrganisation_Person_ID
        {
            get
            {
                if (MainForm != null)
                {
                    return MainForm.myOrganisation_Person_ID;
                }
                else
                {
                    return -1;
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
                sNumber = FinancialYear.ToString() + "/" + lngRPM.s_Draft.s + " " + DraftNumber.ToString();
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
                            RunAs = Program.const_DocInvoice;
                        }
                        if (s.ToUpper().Contains(const_command_DOCPROFORMAINVOICE))
                        {
                            RunAs = Program.const_DocProformaInvoice;
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
                            Form_Reset_Properties_Settings_Default frm_set = new Form_Reset_Properties_Settings_Default();

                            if (frm_set.ShowDialog() == DialogResult.Yes)
                            {
                                Properties.Settings.Default.Reset();
                                CodeTables.ASet.Settings_Reset();
                                Reset2FactorySettings.Tangenta_EXE = frm_set.bTangenta_EXE;
                                Reset2FactorySettings.DBConnectionControlXX_EXE = frm_set.bDBConnectionControlXX_EXE;
                                Reset2FactorySettings.LangugaControl_DLL = frm_set.bLangugaControl_DLL;
                                Reset2FactorySettings.FiscalVerification_DLL = frm_set.bFiscalVerification_DLL;
                            }
                            else
                            {
                                Reset2FactorySettings.Tangenta_EXE = false;
                                Reset2FactorySettings.DBConnectionControlXX_EXE = false;
                                Reset2FactorySettings.LangugaControl_DLL = false;
                                Reset2FactorySettings.FiscalVerification_DLL = false;
                            }
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
                                    MessageBox.Show(lngRPM.s_AUTONEXT_missing_parameter.s);
                                    Auto_NEXT_in_miliseconds = 10;
                                }
                            }
                            m_bAutoNext = true;
                        }
                    }
                }
            }       
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bExitBeforeLogFileInitialised = false;

            try
            {
                bool bLanguageSelectDialogShown = false;
                bool bLanguageSelected = false;
                string Err = null;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                string[] CommandLineArguments = System.Environment.GetCommandLineArgs();

DoSelectLanguage:
                if (Properties.Settings.Default.LanguageID < 0)
                {
                    bFirstTimeInstallation = true;
                    NavigationButtons.Navigation LanguageNav = new NavigationButtons.Navigation();
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
                        return;
                    }
                }

                NavigationButtons.lngRPM_strings.LanguagePrefix = LanguageControl.DynSettings.LanguagePrefix;
                NavigationButtons.lngRPM_strings.s_OK = LanguageControl.lngRPM.s_OK.s;
                NavigationButtons.lngRPM_strings.s_Cancel = LanguageControl.lngRPM.s_Cancel.s;

                LogFile.Language.id = LanguageControl.DynSettings.LanguageID = Properties.Settings.Default.LanguageID;    //Settings_Tangenta.Settings.LanguageID; ;

                Parse_CommandLineArguments(CommandLineArguments);

                if (bShowCommandLineHelp)
                {

                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DOCINVOICE, lngRPM.s_commandline_DOCINVOICE.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DOCPROFORMAINVOICE, lngRPM.s_commandline_DOCPROFORMAINVOICE.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_CHANGE_CONNECTION, lngRPM.s_commandline_CHANGE_CONNECTION.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_RESETNEW, lngRPM.s_commandline_RESETNEW.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_SYMULATOR, lngRPM.s_commandline_SYMULATOR.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_RS232MONITOR, lngRPM.s_commandline_RS232MONITOR.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DIAGNOSTIC, lngRPM.s_const_command_DIAGNOSTIC.s));
                    command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_AUTONEXT, lngRPM.s_commandline_AUTONEXT.s));

                    NavigationButtons.Navigation CommandLineHelpNav = new NavigationButtons.Navigation();
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
                    CommandLineHelpNav.btn1_Text = lngRPM.s_Previous.s;
                    CommandLineHelpNav.btn2_Image = Properties.Resources.Next;
                    CommandLineHelpNav.btn2_Text = lngRPM.s_Next.s;
                    CommandLineHelpNav.btn2_Visible = true;
                    CommandLineHelpNav.btn3_Image = Properties.Resources.Exit_Program;
                    CommandLineHelpNav.btn3_Text = "";
                    CommandLineHelpNav.btn3_Visible = true;
                    CommandLineHelpNav.btn2_ToolTip_Text = "Press to go to next step";
                    CommandLineHelpNav.btn3_ToolTip_Text = "Exit program Tangenta";
                    CommandLineHelpNav.ExitProgramQuestionInLanguage = lngRPM.s_RealyWantToExitProgram.s;

                    CommandLineHelp.CommandLineHelp_Form hlp_frm = new CommandLineHelp.CommandLineHelp_Form(command_line_help, CommandLineHelpNav, Properties.Resources.Tangenta_Question);
                    CommandLineHelpNav.ChildDialog = hlp_frm;
                    CommandLineHelpNav.ShowDialog();
                    if ((CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.OK)||(CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
                    {
                        CommandLineArguments = hlp_frm.CommandLineArguments;
                        Parse_CommandLineArguments(CommandLineArguments);
                    }
                    else if (CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        if (bLanguageSelectDialogShown)
                        {
                            Properties.Settings.Default.LanguageID = -1;
                            goto DoSelectLanguage;
                        }
                    }
                    else
                    {
                        bExitBeforeLogFileInitialised = true;
                        return;
                    }
                }


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
                if (!LogFile.Settings.Load(Reset2FactorySettings.LogFile_DLL,IniFile, ref Err))
                {
                    MessageBox.Show("ERROR Loading LogFile Settings ! Err=" + Err);
                }

                LogFile.LogFile.InitLogFile(CommandLineArguments);

                LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE, "ProgramStart !");

                LanguageControl.DynSettings.LoadLanguages(Reset2FactorySettings.LangugaControl_DLL);
                LanguageControl.DynSettings.AllowToEditText = Properties.Settings.Default.AllowToEditLanguageText;


                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    LogFile.LogFile.Write(1, "Another instance is allready running !");
                    MessageBox.Show(lngRPM.s_Another_instance_is_running.s);
                    return;
                }


                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "Tangenta", out createdNew))
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
            }
            finally
            {
                if (!bExitBeforeLogFileInitialised)
                {
                    if (LogFile.LogFile.WriteLog2DBOnProgramExit)
                    {
                        //LogFile.LogFile.WriteLog2DB(Program.UserName, "LogFile to DB on program Exit!", ref LogFile_id);
                    }
                }
            }

        }
    }
}
