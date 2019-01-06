using CodeTables;
using DBConnectionControl40;
using DocumentManager;
using RPC;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using static Startup.CommandLineParam;
using static Startup.usrc_Startup;

namespace TangentaBooting
{
    public static class Booting
    {
        public static startup_step[] StartupStep = null;

        public static string CodeTables_IniFileFolder = null;
        public static string xmlCodeTables = "CodeTables.xml";
        public static Startup.Startup m_startup = null;


        public static NavigationButtons.Navigation nav = null;

        internal static int Auto_NEXT_in_miliseconds = 10;
        public static bool Auto_NEXT
        {
            get { return CommandLineParam.m_bAutoNext && Startup.Startup.bFirstTimeInstallation; }
        }
        public static Booting_00_TangentaAbout booting_00_TangentaAbout = null;
        public static Booting_01_TangentaLicence booting_01_TangentaLicence = null;
        public static Booting_02_Check_DBType booting_02_Check_DBType = null;
        public static Booting_03_Check_DBConnection booting_03_Check_DBConnection = null;
        public static Booting_04_Check_DBSettings booting_04_Check_DBSettings = null;
        public static Booting_05_Check_myOrganisation_Data booting_05_Check_MyOrganisation_Data = null;
        public static Booting_06_GetBaseCurrency booting_06_GetBaseCurrency = null;
        public static Booting_07_GetTaxation booting_07_GetTaxation = null;
        public static Booting_08_GetProgramSettings booting_08_GetProgramSettings = null;
        public static Booting_09_GetShopsPriceLists booting_09_GetShopsPriceLists = null;
        public static Booting_10_GetShopB_Items booting_10_GetShopB_Items = null;
        public static Booting_11_GetShopC_Items booting_11_GetShopC_Items = null;
        public static Booting_12_GetPrinters booting_12_GetPrinters = null;
        public static Booting_13_Login booting_13_Login = null;

        public static void Parse_CommandLineArguments(string[] CommandLineArguments)
        {
            if (CommandLineArguments != null)
            {
                foreach (string s in CommandLineArguments)
                {

                    if (s.Contains("?") || s.ToLower().Contains("help"))
                    {
                        CommandLineParam.bShowCommandLineHelp = true;
                    }
                    else if (s.Contains("DEMO") || s.ToLower().Contains("demo"))
                    {
                        CommandLineParam.bDemo = true;
                    }
                    else
                    {
                        if (s.ToUpper().Contains(CommandLineParam.const_command_DOCINVOICE))
                        {
                            DocumentMan.RunAs = GlobalData.const_DocInvoice;
                        }
                        if (s.ToUpper().Contains(CommandLineParam.const_command_DOCPROFORMAINVOICE))
                        {
                            DocumentMan.RunAs = GlobalData.const_DocProformaInvoice;
                        }
                        if (s.Contains(CommandLineParam.const_command_CHANGE_CONNECTION))
                        {
                            CommandLineParam.bChangeConnection = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_TRANSACTION_MONITOR))
                        {
                            CommandLineParam.bTransactionMonitor = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_TRANSACTION_BREAK_DIALOG))
                        {
                            CommandLineParam.bBreakOnTransactionDialog = true;
                            Transaction.BreakOnTransactionDialog = CommandLineParam.bBreakOnTransactionDialog;
                        }

                        if (s.Contains(CommandLineParam.const_command_STARTUP_CHECK_COLUMNS))
                        {
                            CommandLineParam.bStartupCheckColumns = true;
                            DBTableControl.StrartupCheckColumns = CommandLineParam.bStartupCheckColumns = true;

                        }

                        if (s.Contains(CommandLineParam.const_command_SYMULATOR))
                        {
                            CommandLineParam.bSymulator = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_RS232MONITOR))
                        {
                            CommandLineParam.bRS232Monitor = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_DIAGNOSTIC))
                        {
                            CommandLineParam.m_bProgramDiagnostic = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_RESETNEW))
                        {
                            CommandLineParam.bResetNew = true;
                        }
                        if (s.Contains(CommandLineParam.const_command_AUTONEXT))
                        {
                            int iAutoNext = s.IndexOf(CommandLineParam.const_command_AUTONEXT);
                            if (iAutoNext >= 0)
                            {
                                iAutoNext += CommandLineParam.const_command_AUTONEXT.Length;
                                Auto_NEXT_in_miliseconds = fs.GetFirstIntParamFromString(s.Substring(iAutoNext));
                                if (Auto_NEXT_in_miliseconds <= 0)
                                {
                                    MessageBox.Show(lng.s_AUTONEXT_missing_parameter.s);
                                    Auto_NEXT_in_miliseconds = 10;
                                }
                            }
                            CommandLineParam.m_bAutoNext = true;
                        }
                    }
                }
            }
        }
        public static void Define(Form frm_document, delegate_WebBrowserControl_DocumentCompleted xdelegate_WebBrowserControl_DocumentCompleted)
        {
            nav = new NavigationButtons.Navigation();
            if (Auto_NEXT)
            {
                nav.m_Auto_NEXT = new NavigationButtons.Auto_NEXT(Auto_NEXT_in_miliseconds);
            }
            nav.parentForm = frm_document;
            nav.OwnerForm = frm_document;
            nav.m_eButtons = NavigationButtons.Navigation.eButtons.PrevNextExit;
            nav.btn1_Image = Properties.Resources.Prev;
            nav.btn2_Image = Properties.Resources.Next;
            nav.btn3_Image = Properties.Resources.Exit_Program;
            nav.btn1_Text = lng.s_Previous.s;
            nav.btn1_ToolTip_Text = lng.s_GoToPreviousStartupStep.s;
            nav.btn2_Text = lng.s_Next.s; ;
            nav.btn2_ToolTip_Text = lng.s_GoToNextStartupStep.s;
            nav.btn3_Text = "";
            nav.btn3_ToolTip_Text = lng.s_GoToExitProgram.s;
            nav.btn1_Visible = true;
            nav.btn2_Visible = true;
            nav.btn3_Visible = true;
            nav.ExitProgramQuestionInLanguage = lng.s_RealyWantToExitProgram.s;

            m_startup = new Startup.Startup(frm_document,
                                            nav,
                                            DocumentMan.Tangenta_Question_Icon,
            Startup.Startup.bFirstTimeInstallation
            );

            Booting.booting_00_TangentaAbout = new Booting_00_TangentaAbout(frm_document, Booting.m_startup);
            Booting.booting_01_TangentaLicence = new Booting_01_TangentaLicence(frm_document, m_startup);
            Booting.booting_02_Check_DBType = new Booting_02_Check_DBType(frm_document, m_startup);
            Booting.booting_03_Check_DBConnection = new Booting_03_Check_DBConnection(frm_document, m_startup);
            Booting.booting_04_Check_DBSettings = new Booting_04_Check_DBSettings(frm_document, m_startup);
            Booting.booting_05_Check_MyOrganisation_Data = new Booting_05_Check_myOrganisation_Data(frm_document, m_startup);
            Booting.booting_06_GetBaseCurrency = new Booting_06_GetBaseCurrency(frm_document, m_startup);
            Booting.booting_07_GetTaxation = new Booting_07_GetTaxation(frm_document, m_startup);
            Booting.booting_08_GetProgramSettings = new Booting_08_GetProgramSettings(frm_document, m_startup);
            Booting.booting_09_GetShopsPriceLists = new Booting_09_GetShopsPriceLists(frm_document, m_startup);
            Booting.booting_10_GetShopB_Items = new Booting_10_GetShopB_Items(frm_document, m_startup);
            Booting.booting_11_GetShopC_Items = new Booting_11_GetShopC_Items(frm_document, m_startup);
            Booting.booting_12_GetPrinters = new Booting_12_GetPrinters(frm_document, m_startup);
            Booting.booting_13_Login = new Booting_13_Login(frm_document, m_startup);

            m_startup.ShowNews();

            m_startup.m_usrc_Startup.WebBrowserControl_DocumentCompleted += xdelegate_WebBrowserControl_DocumentCompleted;

            StartupStep = new startup_step[]
            {

                // TANGENTA_About
                booting_00_TangentaAbout.CreateStep(),
                
                // TANGENTA_Licence
                booting_01_TangentaLicence.CreateStep(),

                // CHECK DATABASE
                booting_02_Check_DBType.CreateStep(),
                
                 // CHECK DBConnection
                booting_03_Check_DBConnection.CreateStep(),

                // CHECK DBSettings
                booting_04_Check_DBSettings.CreateStep(),

                // CHECK TangentaDB.myOrg
                booting_05_Check_MyOrganisation_Data.CreateStep(),

                // CHECK BaseCurrency
                booting_06_GetBaseCurrency.CreateStep(),

                // GET Taxation
                booting_07_GetTaxation.CreateStep(),

                // GET ProgramSettings
                booting_08_GetProgramSettings.CreateStep(),

                // GET PriceList
                booting_09_GetShopsPriceLists.CreateStep(),

                // GET SHOPB Item Data
                booting_10_GetShopB_Items.CreateStep(),

                // GET SHOPC Item Data
                booting_11_GetShopC_Items.CreateStep(),

                // GET Printer
                booting_12_GetPrinters.CreateStep(),

                // LOGIN
                booting_13_Login.CreateStep()

            };

            m_startup.Steps = StartupStep;


        }
        public static eCommandLineHelpResult DoCommandLineHelp(ref string[] CommandLineArguments,
                                               bool bLanguageSelectDialogShown,
                                               ref bool bExitBeforeLogFileInitialised)
        {
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_DOCINVOICE, lng.s_commandline_DOCINVOICE.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_DOCPROFORMAINVOICE, lng.s_commandline_DOCPROFORMAINVOICE.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_CHANGE_CONNECTION, lng.s_commandline_CHANGE_CONNECTION.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_RESETNEW, lng.s_commandline_RESETNEW.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_TRANSACTION_MONITOR, lng.s_commandline_TRANSACTION_MONITOR.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_TRANSACTION_BREAK_DIALOG, lng.s_commandline_TRANSACTION_BREAK_DIALOG.s));
            command_line_help.Add(new CommandLineHelp.CommandLineHelp("/" + const_command_STARTUP_CHECK_COLUMNS, lng.s_commandline__STARTUP_CHECK_COLUMNS.s));

            //            command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DIAGNOSTIC, lng.s_const_command_DIAGNOSTIC.s));, lng.s_commandline_TRANSACTION_BREAK_DIALOG.s));

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
                                                                                                    DocumentMan.HelpLocalPath,
                                                                                                    DocumentMan.HelpRemoteURL,
                                                                                                    DocumentMan.SaveHelpSettings);
            CommandLineHelpNav.ChildDialog = hlp_frm;
            CommandLineHelpNav.ShowDialog();
            if ((CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.OK) || (CommandLineHelpNav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                bool bHelpSettingsChanged = false;
                if (hlp_frm.LocalHelpPath != null)
                {
                    if (hlp_frm.LocalHelpPath.Length > 0)
                    {
                        DocumentMan.HelpLocalPath = hlp_frm.LocalHelpPath;
                        
                        bHelpSettingsChanged = true;
                    }
                }
                if (hlp_frm.RemoteHelpURL != null)
                {
                    if (hlp_frm.RemoteHelpURL.Length > 0)
                    {
                        DocumentMan.HelpRemoteURL = hlp_frm.RemoteHelpURL;
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
                    DocumentMan.LanguageID = -1;
                    return eCommandLineHelpResult.DO_SELECT_LANGUAGE;
                }
            }
            else
            {
                bExitBeforeLogFileInitialised = true;
                DocumentMan.RPC.End();
                return eCommandLineHelpResult.EXIT;
            }
            return eCommandLineHelpResult.OK;
        }

    }
}
