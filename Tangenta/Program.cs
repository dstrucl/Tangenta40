using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlagajnaDataBaseDef;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using LanguageControl;
using System.Threading;
using System.Diagnostics;
using DBConnectionControl40;
using DBTypes;
using FiscalVerificationOfInvoices_SLO;

namespace Tangenta
{
    static class Program
    {
        public static bool bStartup = true;

        public const string PRESS_DATA_XML = "PressDB.xml";

        public const int const_NoLimit = -1;
        public const string const_inifile_prefix = "Blagajna_";

        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        extern public static int GetGuiResources(IntPtr hProcess, int uiFlags);


        public static string IniFileName = "Tangenta.ini";
        public static string IniFolder = "";
        public static string IniFile = "";
        public static usrc_FVI_SLO usrc_FVI_SLO1 = null;

        internal static long Office_ID = -1;
        internal static long WorkingPlace_ID = -1;
        internal static long Atom_Office_ID = -1;
        internal static long Atom_Computer_ID = -1;
        internal static long Atom_WorkingPlace_ID = -1;
        internal static long Atom_myCompany_Person_ID = -1;
        internal static long Atom_WorkPeriod_ID = -1;

        internal static JOURNAL_ProformaInvoice_Type_definitions JOURNAL_ProformaInvoice_Type_definitions = new JOURNAL_ProformaInvoice_Type_definitions();
        

        internal static string UserName = "UserName not defined";


        internal static Form_Main MainForm = null;

        private static bool m_bProgramDiagnostic = false;

        public static Printer ReceiptPrinter = null;


        public static long myCompany_Person_ID
        {
            get
            {
                if (MainForm != null)
                {
                    return MainForm.myCompany_Person_ID;
                }
                else
                {
                    return -1;
                }
            }
        }


        public static xCurrency BaseCurrency
        {
            get
            {
                if (MainForm != null)
                {
                    return MainForm.BaseCurrency;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool ProgramDiagnostic
        {
            get { return m_bProgramDiagnostic; }
        }

        


        public static int getGuiResourcesUserCount()
        {
            return GetGuiResources(System.Diagnostics.Process.GetCurrentProcess().Handle, 1);
        }


        const string const_command_CHANGE_CONNECTION = "CHANGE-CONNECTION";
        const string const_command_SYMULATOR = "SYMULATOR";
        const string const_command_RS232MONITOR = "RS232MONITOR";
        const string const_command_DIAGNOSTIC = "DIAGNOSTIC";

        internal static bool bShowCommandLineHelp = false;
        internal static bool bDemo = false;

        public static List<CommandLineHelp.CommandLineHelp> command_line_help = new List<CommandLineHelp.CommandLineHelp>();

        internal static bool bChangeConnection = false;
        internal static bool bSymulator = false;
        internal static bool bRS232Monitor = false;
        public static Color Color_Factory = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
        public static Color Color_Stock = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        internal static bool b_FVI_SLO = true;

        //public static int iGDIcUser100;
        //public static int iGDIcUser101;
        //public static int iGDIcUser102;
        //public static int iGDIcUser103;
        //public static int iGDIcUser104;

        //public static int iGDIcUser_After_Insert_usrc_Item2;
        //public static int iGDIcUser_Insert_usrc_Item1;
        //public static int iGDIcUser_Insert_usrc_Item2;
        //public static int iGDIcUser_Insert_usrc_Item4;
        //public static int iGDIcUser_Insert_usrc_Item5;
        //public static int iGDIcUser_Insert_usrc_Item6;

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public static int Get_BaseCurrency_DecimalPlaces()
        {
            if (Program.BaseCurrency != null)
            {
                return Program.BaseCurrency.DecimalPlaces;
            }
            else
            {
                LogFile.Error.Show("ERROR:Program:Get_DecimalPlaces:BaseCurrency is not defined!");
                return 0;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            try
            {

                string Err = null;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

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

                LogFile.Settings.m_eType = LogFile.Settings.eType.IniFile_Settings;
                if (!LogFile.Settings.Load(IniFile, ref Err))
                {
                    MessageBox.Show("ERROR Loading LogFile Settings ! Err=" + Err);
                }
                //Settings_Kig_Programski_Paket.Settings.m_eType = Settings_Kig_Programski_Paket.Settings.eType.DataBase_Settings;

                //Settings_Kig_Programski_Paket.Settings_List.Load(
                string[] CommandLineArguments = System.Environment.GetCommandLineArgs();


                LogFile.LogFile.InitLogFile(CommandLineArguments);
                LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE, "ProgramStart !");

                //if (!CrystalReportInstalled(ref VersionOfCrystalReport))
                //{
                //    MessageBox.Show("Error: Crystal Report Not Installed!\r\nYou must install Crystal Report befor starting " + Application.ProductName + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
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
                    }
                }

                LanguageControl.DynSettings.LoadLanguages();
                LanguageControl.DynSettings.LanguageID = Properties.Settings.Default.LanguageID;    //Settings_Blagajna.Settings.LanguageID; ;
                LanguageControl.DynSettings.AllowToEditText = Properties.Settings.Default.AllowToEditLanguageText;


                if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    LogFile.LogFile.Write(1, "Another instance is allready running !");
                    MessageBox.Show(lngRPM.s_Another_instance_is_running.s);
                    return;
                }

                command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_CHANGE_CONNECTION, lngRPM.s_commandline_CHANGE_CONNECTION.s));
                command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_SYMULATOR, lngRPM.s_commandline_SYMULATOR.s));
                command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_RS232MONITOR, lngRPM.s_commandline_RS232MONITOR.s));
                command_line_help.Add(new CommandLineHelp.CommandLineHelp(const_command_DIAGNOSTIC, lngRPM.s_const_command_DIAGNOSTIC.s));



                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "Tangenta", out createdNew))
                {
                    if (createdNew)
                    {
                        LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_DEBUG_RELEASE, "Mutex Tangenta createdNew.");

                        if (bShowCommandLineHelp)
                        {
                            CommandLineHelp.CommandLineHelp_Form hlp_frm = new CommandLineHelp.CommandLineHelp_Form(command_line_help);
                            if (hlp_frm.ShowDialog() == DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                        MainForm = new Form_Main();
                        Application.Run(MainForm);
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
                if (LogFile.LogFile.WriteLog2DBOnProgramExit)
                {
                    //LogFile.LogFile.WriteLog2DB(Program.UserName, "LogFile to DB on program Exit!", ref LogFile_id);
                }
            }

        }



        internal static void PriceList_Edit(long m_Currency_ID, ComboBox cmb_PriceListType, xPriceList m_xPriceList,bool bEditUndefined)
        {
            string Err = null;
            int xPriceListType_Count = 0;
            Form_PriceList_Edit PriceList_Edit_dlg = new Form_PriceList_Edit(bEditUndefined);
            if (PriceList_Edit_dlg.ShowDialog() == DialogResult.OK)
            {
                if (m_xPriceList.Get_PriceLists_of_Currency(m_Currency_ID, ref xPriceListType_Count, ref Err))
                {
                    if (xPriceListType_Count > 0)
                    {
                        cmb_PriceListType.DataSource = m_xPriceList.List_xPriceList;
                        cmb_PriceListType.DisplayMember = "xPriceList_Name";
                        cmb_PriceListType.ValueMember = "xPriceList_ID";
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                }
            }
        }

        internal static void Cursor_Wait()
        {
            if (MainForm!=null)
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
                sNumber = FinancialYear.ToString() + "/"+lngRPM.s_Draft.s + " " + DraftNumber.ToString();
            }
            else
            {
                sNumber = FinancialYear.ToString() + "/" + NumberInFinancialYear.ToString();
            }
            return sNumber;
        }

        public static bool GetWorkPeriod(string Atom_WorkPeriod_Type_Name,string x_Atom_WorkPeriod_Type_Description, DateTime dtStart, DateTime_v dtEnd_v, ref string Err)
        {
            if (Atom_WorkPeriod_ID < 0)
            {
                if (Atom_myCompany_Person_ID < 0)
                {
                    string_v office_name = null;
                    if (f_Atom_myCompany_Person.Get(1, ref Atom_myCompany_Person_ID,ref office_name, ref Err)== myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK)
                    {
                        if (f_WorkingPlace.Get(office_name.v, "Tangenta 1", ref WorkingPlace_ID))
                        {
                            if (f_Atom_WorkingPlace.Get(Program.WorkingPlace_ID, ref Atom_WorkingPlace_ID))
                            {
                                if (f_Atom_Computer.Get(ref Program.Atom_Computer_ID))
                                {
                                    string Atom_WorkPeriod_Type_Description = x_Atom_WorkPeriod_Type_Description;
                                    if (Atom_WorkPeriod_Type_Name.Equals(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04))
                                    {
                                        Atom_WorkPeriod_Type_Description = "Stari šiht od 29.4.2015 do " + dtEnd_v.v.Day.ToString() + "." + dtEnd_v.v.Month.ToString() + "." + dtEnd_v.v.Year.ToString();
                                    }
                                    if (f_Atom_WorkPeriod.Get(Atom_WorkPeriod_Type_Name,Atom_WorkPeriod_Type_Description , Atom_myCompany_Person_ID, Atom_WorkingPlace_ID, Atom_Computer_ID, dtStart, dtEnd_v, ref Atom_WorkPeriod_ID))
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
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal static bool Get_JOURNAL_Types_ID()
        {
            if (f_JOURNAL_Stock.Get_JOURNAL_Stock_Type_ID())
            {
                return true;
            }
            return false;
        }
    }

}
