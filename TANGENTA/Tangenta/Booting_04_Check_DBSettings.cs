using DBConnectionControl40;
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

namespace Tangenta
{
    public class Booting_04_Check_DBSettings
    {
       

        private startup_step.eStep eStep = eStep.Check_04_DBSettings;

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_04_Check_DBSettings(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Check_DBSettings.s, m_startup, Program.nav,
                                    Startup_04_Check_DBSettings,
                                    Startup_04_Undo,
                                    startup_step.eStep.Check_04_DBSettings);
        }

        private Startup_check_proc_Result Startup_04_Check_DBSettings(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (GlobalData.Type_definitions_Read())
            {
                if (f_Currency.GetCurrencyTable(ref Err))
                {
                    if (fs.Init_Unit_Table(ref Err))
                    {
                        if (frm.m_usrc_Main.GetDBSettings(ref Err))
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
                                        startup_ShowForm_proc = Startup_04_ShowDBSettingsForm;
                                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                                    }
                                    else
                                    {
                                        return Startup_check_proc_Result.CHECK_OK;
                                    }

                                case fs.enum_GetDBSettings.No_Data_Rows:
                                    //DataBaseVersion Not written !
                                    long ID_Version = -1;
                                    if (fs.WriteDBSettings("Version", MyDataBase_Tangenta.VERSION, "1", ref ID_Version))
                                    {
                                        return Startup_check_proc_Result.CHECK_OK;
                                    }
                                    else
                                    {
                                        return Startup_check_proc_Result.CHECK_ERROR;
                                    }
                                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                case fs.enum_GetDBSettings.No_ReadOnly:
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
                                LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings  Err==null should not happen in false result  from m_usrc_Main.GetDBSettings function!");
                                return Startup_check_proc_Result.CHECK_ERROR;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings:fs.Init_Unit_Table! Err=" + Err);
                        return Startup_check_proc_Result.CHECK_ERROR;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings:f_Currency.GetCurrencyTable failed! Err=" + Err);
                    return Startup_check_proc_Result.CHECK_ERROR;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_04_Check_DBSettings:  Type_definitions_Read failed!");
                
                return Startup_check_proc_Result.CHECK_ERROR;
            }
        }

        internal Startup_eUndoProcedureResult Startup_04_Undo(startup_step xstartup_step,
                                        ref string Err)
        {
            if (fs.DeleteAll("DBSettings", ref Err))
            {
                return Startup_eUndoProcedureResult.OK;
            }
            else
            {
                return Startup_eUndoProcedureResult.ERROR;
            }
         }

        private bool Startup_04_ShowDBSettingsForm(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_04_onformresult_ShowDBSettings;
            xnav.ShowForm(new Form_DBSettings(xnav, Program.AdministratorLockedPassword), "Tangenta.Form_DBSettings");
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
                    Program.AdministratorLockedPassword = ((Form_DBSettings)form).AdministratorLockedPassword;

                    Program.OperationMode.MultiUser = ((Form_DBSettings)form).MultiuserOperationWithLogin;
                    Program.OperationMode.SingleUserLoginAsAdministrator = ((Form_DBSettings)form).SingleUserLoginAsAdministrator;
                    Program.OperationMode.StockCheckAtStartup = ((Form_DBSettings)form).StockCheckAtStartup;
                    Program.OperationMode.ShopC_ExclusivelySellFromStock = ((Form_DBSettings)form).ShopC_ExclusivelySellFromStock;
                    Program.OperationMode.MultiCurrency = ((Form_DBSettings)form).MultiCurrencyOperation;
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
