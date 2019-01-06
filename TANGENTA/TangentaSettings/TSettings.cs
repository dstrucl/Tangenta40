using CodeTables;
using DBConnectionControl40;
using DBTypes;
using FiscalVerificationOfInvoices_SLO;
using Global;
using LoginControl;
using RPC;
using Startup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using static TangentaDB.CashierActivity;

namespace TangentaSettings
{
    public class TSettings
    {

        public static FVI_SLO_MessageBox message_box = null;

        public static Thread_FVI thread_fvi = null;

        public static string m_XmlFileName = null;

        public const string TANGENTA_VODSHEMA_SUB_FOLDER = "\\TangentaVODshema";
        public const string TANGENTA_SETTINGS_SUB_FOLDER = "\\TangentaSettings";
        public const string TANGENTA_SQLITEBACKUP_SUB_FOLDER = "\\TangentaSQliteBackup";

        public static string AdministratorLockedPassword = "dhlpt"; //"dhlpt" is Locked password for "12345"

        public static string DBType
        {
            get
            {
                return Properties.Settings.Default.DBType;
            }
            set
            {
                Properties.Settings.Default.DBType = value;
                Properties.Settings.Default.Save();
            }
        }



        public static bool m_CountryHasFVI = false;

        public static bool CountryHasFVI
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



        public static LMOUser LMO1User
        {
            get
            {
                if (loginControl1 != null)
                {
                    return loginControl1.LMO1User;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool Login_MultipleUsers
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


        private static string m_RunAs = null;

        public static string RunAs
        {
            get
            {
                if (m_RunAs != null)
                {
                    if (m_RunAs.ToUpper().Equals(CommandLineParam.const_command_DOCINVOICE))
                    {
                        return GlobalData.const_DocInvoice;
                    }
                    else if (m_RunAs.ToUpper().Equals(CommandLineParam.const_command_DOCPROFORMAINVOICE))
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
            set
            {
                string s = value;
                m_RunAs = s.ToUpper();
            }
        }



        public static bool bStartup = true;

        private UserControl usrc_DocumentMan = null;

        public delegate void delegate_Control_SetMode(TSettings.eMode mode);
        private delegate_Control_SetMode delegate_control_SetMode = null;

        public delegate int delegate_Control_TableOfDocuments_Init(TSettings xdocM,
                          bool bNew,
                          bool bInitialise_usrc_Invoice,
                          int iFinancialYear,
                          ID Doc_ID_To_show);

        public delegate_Control_TableOfDocuments_Init Delegate_control_TableOfDocuments_Init = null;


        public delegate bool delegate_Control_DocumentEditor_Init(ID xDocument_ID);

        public delegate_Control_DocumentEditor_Init Delegate_Control_DocumentEditor_Init = null;

        public delegate void delegate_Control_SetInitialMode();
        public delegate_Control_SetInitialMode Delegate_Control_SetInitialMode = null;



        public static bool UseWorkAreas
        {
            get
            {

                return Properties.Settings.Default.UseWorkAreas;
            }

        }

        public static CashierActivity CashierActivity
        {
            get
            {
                if (loginControl1 != null)
                {
                    return loginControl1.CashierActivity;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool ControlLayout_TouchScreen
        {
            get
            {
                return Properties.Settings.Default.ControlLayout_TouchScreen;
            }
        }

        private static LoginControl.LoginCtrl loginControl1 = null;
        public static LoginControl.LoginCtrl LoginControl1
        {
           get
            {
                return loginControl1;
            }
            set
            {
                loginControl1= value;
            }


        }

        public static bool RecordCashierActivity
        {
            get
            {
                if (loginControl1 != null)
                {
                    return loginControl1.RecordCashierActivity;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (loginControl1 != null)
                {
                    loginControl1.RecordCashierActivity = value;
                }
            }
        }

        public static eCashierState CashierState
        {
            get
            {
                if (loginControl1 != null)
                {
                    return loginControl1.CashierState;
                }
                else
                {
                    return eCashierState.CLOSED;
                }
            }
        }

        private static FVI_SLO m_FVI_SLO1 = null;
        public static FVI_SLO FVI_SLO1
        {
            get
            {
                return m_FVI_SLO1;
            }
            set
            {
                m_FVI_SLO1 = value;
            }
        }


        public static bool b_FVI_SLO
        {
            get
            {
                return OperationMode.FiscalVerificationOfInvoices;
            }
            set
            {
                OperationMode.FiscalVerificationOfInvoices = value;
            }
        }

        public SettingsUserValues mSettingsUserValues = null;

        public LoginControl.LMOUser m_LMOUser = null;

            
        public int timer_Login_MultiUsers_Countdown = 100;

        internal CtrlLayout cl_btn_New = null;
        internal CtrlLayout cl_cmb_InvoiceType = null;
        internal CtrlLayout cl_lbl_FinancialYear = null;

        public bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;

        public static string eShopsInUse
        {
            get
            {
                return Properties.Settings.Default.eShopsInUse;
            }
        }

        public static bool ShowAdministratorsInMultiuserLogin
        {
            get {
                return Properties.Settings.Default.ShowAdministratorsInMultiuserLogin;
                }
        }

        public static Icon Tangenta_Question_Icon {
            get
            {
                return Properties.Resources.Tangenta_Question;
            }
        }

        public static RPC.RPC RPC = null;


        public static int LanguageID
        {
            get
            {
                return Properties.Settings.Default.LanguageID;
            }

            set
            {
                Properties.Settings.Default.LanguageID = value;
                Properties.Settings.Default.Save();
            }

        }
        
        public static string HelpLocalPath
        {
            get
            {
                return Properties.Settings.Default.HelpLocalPath;
            }

            set
            {
                Properties.Settings.Default.HelpLocalPath = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string HelpRemoteURL
        {
            get
            {
                return Properties.Settings.Default.HelpRemoteURL;
            }
            set
            {
                Properties.Settings.Default.HelpRemoteURL = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void SaveHelpSettings(string LocalHelpPath, string RemoteHelpURL)
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

        public static bool AutomaticSelectionOfItemFromStock
        {
            get
            {
                return Properties.Settings.Default.AutomaticSelectionOfItemFromStock;
            }
        }

        public TSettings(delegate_Control_SetMode xdelegate_control_SetMode,
                         delegate_Control_SetInitialMode xdelegate_Control_SetInitialMode
                        )
        {
            delegate_control_SetMode = xdelegate_control_SetMode;
            Delegate_Control_SetInitialMode = xdelegate_Control_SetInitialMode;
        }

        public void SetMode(TSettings.eMode mode)
        {
            Mode = mode;
            if (mode == TSettings.eMode.Shops)
            {
                Properties.Settings.Default.eManagerMode = "Shops";
            }
            else if (mode == TSettings.eMode.InvoiceTable)
            {
                Properties.Settings.Default.eManagerMode = "InvoiceTable";
            }
            else
            {
                Properties.Settings.Default.eManagerMode = "Shops&InvoiceTable";
            }
            Properties.Settings.Default.Save();
            delegate_control_SetMode(Mode);
        }

        internal void Cursor_Arrow()
        {
            if (usrc_DocumentMan != null)
            {
                Form parent_frm = Global.f.GetParentForm(usrc_DocumentMan);
                if (parent_frm != null)
                {
                    parent_frm.Cursor = Cursors.Arrow;
                }
            }
        }

        public bool SetDocument(ID xCurrent_Doc_ID, Transaction transaction)
        {

            int iRowsCount = Delegate_control_TableOfDocuments_Init(this, false, true, this.mSettingsUserValues.FinancialYear, null);


            if (!Delegate_Control_DocumentEditor_Init(xCurrent_Doc_ID))
            {
                Cursor_Arrow();
                return false;
            }

            SetInitialMode();

            SetMode(Mode);
            return true;

        }

        public void SetInitialMode()
        {
            string sManagerMode = Properties.Settings.Default.eManagerMode;
            if ((sManagerMode.Contains("Shops")) && (sManagerMode.Contains("InvoiceTable")))
            {
                Mode = TSettings.eMode.Shops_and_InvoiceTable;
            }
            else if (sManagerMode.Equals("Shops"))
            {
                Mode = TSettings.eMode.Shops;
            }
            else if (sManagerMode.Equals("InvoiceTable"))
            {
                Mode = TSettings.eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_DocumentMan:SetInitialMode:Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
                Mode = TSettings.eMode.Shops_and_InvoiceTable;
            }

            Delegate_Control_SetInitialMode();
        }


        public static void LayoutSave(Form frm,SettingsUserValues xSettingsUserValues)
        {
            switch (frm.WindowState)
            {
                case FormWindowState.Minimized:
                    xSettingsUserValues.Form_WindowState = 0;
                    break;
                case FormWindowState.Normal:
                    xSettingsUserValues.Form_WindowState = 1;
                    xSettingsUserValues.Form_Width = frm.Width;
                    xSettingsUserValues.Form_Height = frm.Height;
                    xSettingsUserValues.Form_Left = frm.Left;
                    xSettingsUserValues.Form_Top = frm.Top;
                    break;
                case FormWindowState.Maximized:
                    xSettingsUserValues.Form_WindowState = 2;
                    break;
            }

            //SaveSplitControlsSpliterDistance(xSettingsUserValues);

        }

        private void SaveSplitControlsSpliterDistance(SettingsUserValues xSettingsUserValues)
        {
            //if (SplitContainer1_spd > 0)
            //{
            //    mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance = SplitContainer1_spd;
            //}
            //if (this.m_usrc_DocumentEditor != null)
            //{
            //    this.m_usrc_DocumentEditor.SaveSplitControlsSpliterDistance(xSettingsUserValues);
            //}
        }

        public static void SaveSettings(Form frm,LoginControl.LMOUser xLMOUser)
        {
            SettingsUser user_settings = (SettingsUser)xLMOUser.oSettings;
            if (user_settings != null)
            {
                LayoutSave(frm,user_settings.mSettingsUserValues);
                Transaction transaction_Form_Document_SaveSettings_user_settings_Save = DBSync.DBSync.NewTransaction("Form_Document.SaveSettings.user_settings.Save");
                if (user_settings.Save(transaction_Form_Document_SaveSettings_user_settings_Save))
                {
                    if (transaction_Form_Document_SaveSettings_user_settings_Save.Commit())
                    {
                        //((Form_SettingsUsers)xLMOUser.Form_settingsuser).InitAfterSave();
                        //((Form_SettingsUsers)xLMOUser.Form_settingsuser).Refresh();
                        //if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan)
                        //{
                        //    ((usrc_DocumentMan)xLMOUser.m_usrc_DocumentMan).BeforeRemove();
                        //    this.Controls.Remove((usrc_DocumentMan)xLMOUser.m_usrc_DocumentMan);
                        //    ((usrc_DocumentMan)xLMOUser.m_usrc_DocumentMan).Dispose();
                        //}
                        //else if (xLMOUser.m_usrc_DocumentMan is usrc_DocumentMan1366x768)
                        //{
                        //    this.Controls.Remove((usrc_DocumentMan1366x768)xLMOUser.m_usrc_DocumentMan);
                        //    ((usrc_DocumentMan1366x768)xLMOUser.m_usrc_DocumentMan).Dispose();
                        //}
                    }
                }
                else
                {
                    transaction_Form_Document_SaveSettings_user_settings_Save.Rollback();
                }
            }
            xLMOUser.m_usrc_DocumentMan = null;
        }
    }
}
