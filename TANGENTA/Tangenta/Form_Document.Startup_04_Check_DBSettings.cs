using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document
    {
        bool bNewDatabaseCreated = false;
        bool bInit_DBType_Canceled = false;

        private startup_step CStartup_04_Check_DBSettings()
        {
            return new startup_step(lng.s_Startup_Check_DBSettings.s, m_startup, Program.nav,
                                    Startup_04_Check_DBSettings, startup_step.eStep.Check_04_DBSettings);
        }

        public Startup_check_proc_Result Startup_04_Check_DBSettings(startup_step myStartup_step, object o, ref string Err)
        {
            if (GlobalData.Type_definitions_Read())
            {
                if (m_usrc_Main.GetDBSettings(ref Err))
                {
                    string xFullBackupFile = null;
                    bool bUpgradeDone = false;
                    bool bInsertSampleData = false;
                    bool bCanceled = false;
                    fs.enum_GetDBSettings eGetDBSettings_Result = UpgradeDB.UpgradeDB_inThread.Read_DBSettings_Version(m_startup, ref xFullBackupFile, ref bUpgradeDone, ref bInsertSampleData, ref bCanceled, ref Err);
                    switch (eGetDBSettings_Result)
                    {
                        case fs.enum_GetDBSettings.DBSettings_OK:
                            if (bUpgradeDone)
                            {
                                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                            }
                            else
                            {
                                return Startup_check_proc_Result.CHECK_OK;
                            }

                        case fs.enum_GetDBSettings.Error_Load_DBSettings:
                        case fs.enum_GetDBSettings.No_ReadOnly:
                        case fs.enum_GetDBSettings.No_Data_Rows:
                        case fs.enum_GetDBSettings.No_TextValue:
                            return Startup_check_proc_Result.CHECK_ERROR;
                        default:
                            return Startup_check_proc_Result.CHECK_ERROR;
                    }
                }
                else
                {
                    if (Err != null)
                    {
                        if (Err.Contains("ERROR:"))
                        {
                            return Startup_check_proc_Result.CHECK_ERROR;
                        }
                        else
                        {
                            XMessage.Box.Show(this, lng.s_No_DB_Settings_for, " " + Err, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings  Err==null should not happen in false result  from m_usrc_Main.GetDBSettings function!");
                        return Startup_check_proc_Result.CHECK_ERROR;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings:  Type_definitions_Read failed!");
                return Startup_check_proc_Result.CHECK_ERROR;
            }
        }
        private bool Startup_04_ShowDBSettingsForm(Navigation xnav)
        {
            xnav.ShowForm(new Form_DBSettings(xnav, Program.AdministratorLockedPassword), "Tangenta.Form_DBSettings");
            return true;
        }

        private Startup_onformresult_proc_Result Startup_04_onformresult_ShowDBSettings(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    bool bDBSettingsChanged = ((Form_DBSettings)xnav.ChildDialog).Changed;
                    Program.AdministratorLockedPassword = ((Form_DBSettings)xnav.ChildDialog).AdministratorLockedPassword;

                    Program.OperationMode.MultiUser = ((Form_DBSettings)xnav.ChildDialog).MultiuserOperationWithLogin;
                    Program.OperationMode.SingleUserLoginAsAdministrator = ((Form_DBSettings)xnav.ChildDialog).SingleUserLoginAsAdministrator;
                    Program.OperationMode.StockCheckAtStartup = ((Form_DBSettings)xnav.ChildDialog).StockCheckAtStartup;
                    Program.OperationMode.ShopC_ExclusivelySellFromStock = ((Form_DBSettings)xnav.ChildDialog).ShopC_ExclusivelySellFromStock;
                    Program.OperationMode.MultiCurrency = ((Form_DBSettings)xnav.ChildDialog).MultiCurrencyOperation;
                    return Startup_onformresult_proc_Result.NEXT;

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_04_onformresult_ShowDBSettings:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;



            }
            
        }
    }
}
