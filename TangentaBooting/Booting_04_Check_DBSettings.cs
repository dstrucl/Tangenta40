using DBConnectionControl40;
using DocumentManager;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDataBaseDef;
using TangentaDB;
using UpgradeDB;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_04_Check_DBSettings
    {
       


        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_04_Check_DBSettings(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Check_DBSettings.s, m_startup, Booting.nav,
                                    Startup_04_Check_DBSettings,
                                    Startup_04_Undo,
                                    startup_step.eStep.Check_04_DBSettings);
        }

        private Startup_check_proc_Result Startup_04_Check_DBSettings(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            string xFullBackupFile = null;
            bool bUpgradeDone = false;
            fs.enum_GetDBSettings eGetDBSettings_Result = UpgradeDB.UpgradeDB_inThread.Read_DBSettings_Version(ref m_startup.CurrentDataBaseVersionTextValue, ref xFullBackupFile, ref Err);
            Startup_check_proc_Result eres = Startup_check_proc_Result.CHECK_ERROR;
            switch (eGetDBSettings_Result)
            {
                case fs.enum_GetDBSettings.DBSettings_OK:
                    if (m_startup.CheckUpgrade(ref bUpgradeDone, ref Err))
                    {
                        if (bUpgradeDone)
                        {
                            startup_ShowForm_proc = Startup_04_ShowDBSettingsForm;
                            eres = Startup_check_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            eres = Startup_check_proc_Result.CHECK_OK;
                        }
                    }
                    else
                    {
                        return Startup_check_proc_Result.CHECK_ERROR;
                    }
                    break;

                case fs.enum_GetDBSettings.No_Data_Rows:
                    //DataBaseVersion Not written !
                    ID ID_Version = null;

                    Transaction transaction_MyDataBase_Tangenta_VERSION = DBSync.DBSync.NewTransaction("MyDataBase_Tangenta_VERSION");

                    if (fs.WriteDBSettings("Version", MyDataBase_Tangenta.VERSION, "1", ref ID_Version, transaction_MyDataBase_Tangenta_VERSION))
                    {
                        if (transaction_MyDataBase_Tangenta_VERSION.Commit())
                        {
                            eres = Startup_check_proc_Result.CHECK_OK;
                        }
                        else
                        {
                            eres = Startup_check_proc_Result.CHECK_ERROR;
                        }
                    }
                    else
                    {
                        eres = Startup_check_proc_Result.CHECK_ERROR;
                    }
                    break;

                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                case fs.enum_GetDBSettings.No_ReadOnly:
                case fs.enum_GetDBSettings.No_TextValue:
                    return Startup_check_proc_Result.CHECK_ERROR;
                default:
                    return Startup_check_proc_Result.CHECK_ERROR;
            }



            if (GlobalData.Type_definitions_Read())
            {
                if (f_Currency.GetCurrencyTable(ref Err))
                {
                    Transaction transaction_Init_Unit_Table = DBSync.DBSync.NewTransaction("Init_Unit_Table");
                    if (fs.Init_Unit_Table(ref Err, transaction_Init_Unit_Table))
                    {
                        transaction_Init_Unit_Table.Commit();
                        if (GetDBSettings(ref Err))
                        {
                            return eres;
                        }
                        else
                        {
                            if (Err != null)
                            {

                                if (Err.Contains(fs.ERROR))
                                {
                                    return Startup_check_proc_Result.CHECK_ERROR;
                                }
                                else if (Err.Equals(fs.EMPTYTABLE))
                                {
                                    startup_ShowForm_proc = Startup_04_ShowDBSettingsForm;
                                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                                }
                                else
                                {
                                    XMessage.Box.Show(frm, lng.s_No_DB_Settings_for, " " + Err, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                    startup_ShowForm_proc = Startup_04_ShowDBSettingsForm;
                                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:Form:Startup_04_Check_DBSettings  Err==null should not happen in false result  from m_usrc_Main.GetDBSettings function!");
                                return Startup_check_proc_Result.CHECK_ERROR;
                            }
                        }
                    }
                    else
                    {
                        transaction_Init_Unit_Table.Rollback();
                        LogFile.Error.Show("ERROR:Tangenta:Form:Startup_04_Check_DBSettings:fs.Init_Unit_Table! Err=" + Err);
                        return Startup_check_proc_Result.CHECK_ERROR;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:Form:Startup_04_Check_DBSettings:f_Currency.GetCurrencyTable failed! Err=" + Err);
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form:Startup_04_Check_DBSettings:  Type_definitions_Read failed!");
                
                return Startup_check_proc_Result.CHECK_ERROR;
            }
        }

        internal bool GetDBSettings(ref string Err)
        {
            bool bReadOnly = false;
            Err = null;
            long lRowsCount = fs.GetTableRowsCount("DBSettings");
            if (lRowsCount > 1) //Database "Version" is wriiten after database creation in DBSettings
            {
                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref DocumentMan.AdministratorLockedPassword, ref bReadOnly, ref Err))
                {
                    case fs.enum_GetDBSettings.DBSettings_OK:
                        string MultiuserOperationWithLogin = null;
                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, ref MultiuserOperationWithLogin, ref bReadOnly, ref Err))
                        {
                            case fs.enum_GetDBSettings.DBSettings_OK:
                                OperationMode.MultiUser = MultiuserOperationWithLogin.Equals("1");

                                string StockCheckAtStartup = null;
                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name, ref StockCheckAtStartup, ref bReadOnly, ref Err))
                                {
                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                        OperationMode.StockCheckAtStartup = StockCheckAtStartup.Equals("1");

                                        string sSingleUserLoginAsAdministrator = null;
                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.SingleUserLoginAsAdministrator.Name, ref sSingleUserLoginAsAdministrator, ref bReadOnly, ref Err))
                                        {
                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                OperationMode.SingleUserLoginAsAdministrator = sSingleUserLoginAsAdministrator.Equals("1");

                                                string sShopC_ExclusivelySellFromStock = null;
                                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name, ref sShopC_ExclusivelySellFromStock, ref bReadOnly, ref Err))
                                                {
                                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                                        OperationMode.ShopC_ExclusivelySellFromStock = sShopC_ExclusivelySellFromStock.Equals("1");

                                                        string sMultiCurrencyOperation = null;
                                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name, ref sMultiCurrencyOperation, ref bReadOnly, ref Err))
                                                        {
                                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                                OperationMode.MultiCurrency = sMultiCurrencyOperation.Equals("1");
                                                                string sNumberOfMonthAfterNewYearToAllowCreateNewInvoice = null;
                                                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Name, ref sNumberOfMonthAfterNewYearToAllowCreateNewInvoice, ref bReadOnly, ref Err))
                                                                {
                                                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                                                        try
                                                                        {
                                                                            OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice = Convert.ToInt32(sNumberOfMonthAfterNewYearToAllowCreateNewInvoice);
                                                                        }
                                                                        catch
                                                                        {
                                                                            OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice = 1;
                                                                        }
                                                                        return true;

                                                                    case fs.enum_GetDBSettings.No_TextValue:
                                                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Name;
                                                                        return false;

                                                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:

                                                                        return false;
                                                                }
                                                                break;

                                                            case fs.enum_GetDBSettings.No_TextValue:
                                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name;
                                                                return false;

                                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:

                                                                return false;
                                                        }
                                                        break;

                                                    case fs.enum_GetDBSettings.No_TextValue:
                                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name;
                                                        return false;

                                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                        return false;
                                                }
                                                break;


                                            case fs.enum_GetDBSettings.No_TextValue:
                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                                return false;

                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                return false;
                                        }
                                        break;

                                    case fs.enum_GetDBSettings.No_ReadOnly:
                                    case fs.enum_GetDBSettings.No_TextValue:
                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name;
                                        return false;
                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                        return false;
                                }
                                break;


                            case fs.enum_GetDBSettings.No_ReadOnly:
                            case fs.enum_GetDBSettings.No_TextValue:
                            case fs.enum_GetDBSettings.No_Data_Rows:
                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                return false;
                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                return false;
                        }
                        break;
                    case fs.enum_GetDBSettings.No_ReadOnly:
                    case fs.enum_GetDBSettings.No_TextValue:
                    case fs.enum_GetDBSettings.No_Data_Rows:
                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name;
                        return false;

                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                        Err = fs.ERROR;
                        return false;
                }

                return false; // GlobalData.Type_definitions_Read();
            }
            else
            {
                Err = fs.EMPTYTABLE;
                return false; // No DataRows;
            }
        }


        internal Startup_eUndoProcedureResult Startup_04_Undo(startup_step xstartup_step,
                                        ref string Err)
        {
            Transaction transaction_Startup_04_Undo = DBSync.DBSync.NewTransaction("Startup_04_Undo");
            if (fs.DeleteAll("DBSettings", ref Err, transaction_Startup_04_Undo))
            {
                if (transaction_Startup_04_Undo.Commit())
                {
                    return Startup_eUndoProcedureResult.OK;
                }
                else
                {
                    return Startup_eUndoProcedureResult.ERROR;
                }
            }
            else
            {
                transaction_Startup_04_Undo.Rollback();
                return Startup_eUndoProcedureResult.ERROR;
            }
         }

        private bool Startup_04_ShowDBSettingsForm(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_04_onformresult_ShowDBSettings;
            xnav.ShowForm(new Form_DBSettings(xnav, DocumentMan.AdministratorLockedPassword), typeof(Form_DBSettings).ToString());
            return true;
        }

        private Startup_onformresult_proc_Result Startup_04_onformresult_ShowDBSettings(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    bool bDBSettingsChanged = ((Form_DBSettings)form).Changed;
                    DocumentMan.AdministratorLockedPassword = ((Form_DBSettings)form).AdministratorLockedPassword;

                    OperationMode.MultiUser = ((Form_DBSettings)form).MultiuserOperationWithLogin;
                    OperationMode.SingleUserLoginAsAdministrator = ((Form_DBSettings)form).SingleUserLoginAsAdministrator;
                    OperationMode.StockCheckAtStartup = ((Form_DBSettings)form).StockCheckAtStartup;
                    OperationMode.ShopC_ExclusivelySellFromStock = ((Form_DBSettings)form).ShopC_ExclusivelySellFromStock;
                    OperationMode.MultiCurrency = ((Form_DBSettings)form).MultiCurrencyOperation;
                    return Startup_onformresult_proc_Result.NEXT;

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_04_onformresult_ShowDBSettings:xnav.eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;



            }
            
        }
    }
}
