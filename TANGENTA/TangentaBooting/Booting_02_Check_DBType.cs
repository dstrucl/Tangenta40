using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaProperties;
using static Startup.startup_step;

namespace TangentaBooting
{
    public class Booting_02_Check_DBType
    {

        private Form frm = null;
        private Startup.Startup m_startup = null;


        public Booting_02_Check_DBType(Form xfmain, Startup.Startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }


        internal startup_step CreateStep()
        {
            return new startup_step(lng.s_Startup_Check_DBType.s,
                                    m_startup,
                                    Booting.nav,
                                    Startup_02_Check_DataBase_Type,
                                    Startup_02_Undo,
                                    startup_step.eStep.Check_02_DataBaseType);
        }

        private Startup_check_proc_Result Startup_02_Check_DataBase_Type(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            string sDBType = null;

            string xinifolder = Booting.CodeTables_IniFileFolder;
            if (Global.f.SetApplicationDataSubFolder(ref xinifolder, TSettings.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                Booting.CodeTables_IniFileFolder = xinifolder;
                if (CommandLineParam.bChangeConnection)
                {
                    TSettings.DBType = "";
                }
                sDBType = TSettings.DBType;
                if (sDBType.Length == 0)
                {
                    // just show window
                    startup_ShowForm_proc = Startup_02_ShowDataBaseTypeSelectionForm;
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                }
                else
                {
                    //Do Real Check
                    if (DBSync.DBSync.Startup_02_Get_eDBType_and_DB_for_Tangenta(sDBType, ref DBSync.DBSync.m_DBType,frm, Booting.CodeTables_IniFileFolder, Booting.xmlCodeTables))
                    {
                        if (Transaction.BreakOnTransactionDialog)
                        {
                            SetBreakOnTransactionLog();
                        }
                        return Startup_check_proc_Result.CHECK_OK;
                    }
                    else
                    {

                        return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                    }
                }
            }
            else
            {
                Booting.CodeTables_IniFileFolder = xinifolder;
                return Startup_check_proc_Result.CHECK_ERROR;
            }

        }

        internal Startup_eUndoProcedureResult Startup_02_Undo(startup_step xstartup_step,
                                        ref string Err)
        {
            TSettings.DBType = "";
            if (DBSync.DBSync.DB_for_Tangenta!=null)
            {
                if (DBSync.DBSync.DB_for_Tangenta.m_DBTables != null)
                {
                    if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.Con != null)
                    {
                        DBSync.DBSync.DB_for_Tangenta.m_DBTables.Con = null;
                    }
                    DBSync.DBSync.DB_for_Tangenta.m_DBTables = null;
                }
                DBSync.DBSync.DB_for_Tangenta = null;
            }
            return Startup_eUndoProcedureResult.OK;
        }

        private bool Startup_02_ShowDataBaseTypeSelectionForm(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            string sDataBaseType = "SQLITE";
            startup_OnFormResult_proc = Startup_02_onformresult_ShowDataBaseTypeSelectionForm;
            DBSync.DBSync.Show_Get_DBTypeForm(ref sDataBaseType, xnav);
            return true;
        }

        private void SetBreakOnTransactionLog()
        {
            Transaction.MyDataBase_TransactionsLog = DBSync.DBSync.DB_for_Tangenta.DB_TransactionsLog;
            Transaction.Delegate_AddTransactionLogUserControl = TransactionLog.TransactionLog.AddTransactionLogUserControl;
            Transaction.Delegate_InitTransactionLogUserControl = TransactionLog.TransactionLog.InitTransactionLogUserControl;
        }

        private Startup_onformresult_proc_Result Startup_02_onformresult_ShowDataBaseTypeSelectionForm(startup_step myStartup_step,
                                                                                            Form form,
                                                                                            NavigationButtons.Navigation.eEvent eExitResult,
                                                                                            ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                            ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is DBSync.Form_GetDBType)
                    {
                        DBConnection.eDBType eDBType = ((DBSync.Form_GetDBType)form).m_DBType;
                        string sDBType = null;
                        switch (eDBType)
                        {
                            case DBConnection.eDBType.SQLITE:
                                sDBType = "SQLITE";
                                TSettings.DBType = sDBType;
                                if (DBSync.DBSync.Startup_02_Get_eDBType_and_DB_for_Tangenta(sDBType, ref eDBType, frm, Booting.CodeTables_IniFileFolder, Booting.xmlCodeTables))
                                {
                                    if (Transaction.BreakOnTransactionDialog)
                                    {
                                        SetBreakOnTransactionLog();
                                    }
                                    return Startup_onformresult_proc_Result.NEXT;
                                }
                                else
                                {
                                    return Startup_onformresult_proc_Result.ERROR;
                                }
                            case DBConnection.eDBType.MSSQL:
                                sDBType = "MSSQL";
                                TSettings.DBType = sDBType;
                                if (DBSync.DBSync.Startup_02_Get_eDBType_and_DB_for_Tangenta(sDBType, ref eDBType, frm, Booting.CodeTables_IniFileFolder, Booting.xmlCodeTables))
                                {
                                    if (Transaction.BreakOnTransactionDialog)
                                    {
                                        SetBreakOnTransactionLog();
                                    }
                                    return Startup_onformresult_proc_Result.NEXT;
                                }
                                else
                                {
                                    return Startup_onformresult_proc_Result.ERROR;
                                }
                            default:
                                LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_02_onformresult_ShowDataBaseTypeSelectionForm:Unsuported DB type:" + eDBType.ToString());
                                return Startup_onformresult_proc_Result.ERROR;
                        }
                    }
                    else
                    {
                        if (form == null)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_02_onformresult_ShowDataBaseTypeSelectionForm:xnav.ChildDialog == null!");
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_02_onformresult_ShowDataBaseTypeSelectionForm:form is not of type DBSync.Form_GetDBType DB type:" + form.GetType().ToString());
                        }
                        return Startup_onformresult_proc_Result.ERROR;
                    }
                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_02_onformresult_ShowDataBaseTypeSelectionForm:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
