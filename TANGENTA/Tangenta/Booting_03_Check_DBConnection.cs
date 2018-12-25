using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Startup.startup_step;

namespace Tangenta
{
    public class Booting_03_Check_DBConnection
    {
        public bool bDatabaseReset = false;

        private Form_Document frm = null;
        private startup m_startup = null;


        public Booting_03_Check_DBConnection(Form_Document xfmain, startup x_sturtup)
        {
            frm = xfmain;
            m_startup = x_sturtup;

        }

        internal startup_step CreateStep()
        {
            bDatabaseReset = Program.Reset2FactorySettings.DBConnectionControlXX_EXE;
            if (Program.bChangeConnection)
            {
                bDatabaseReset = true;
            }
            return new startup_step(lng.s_Startup_Check_DBConnection.s, m_startup, Program.nav,
                                    Startup_03_Check_DBConnection,
                                    Startup_03_Undo,
                                    startup_step.eStep.Check_03_DBConnection);
        }

        private Startup_check_proc_Result Startup_03_Check_DBConnection(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            string xinifolder = frm.CodeTables_IniFileFolder;
            if (DBSync.DBSync.Startup_03_Check_DBConnection_Is_DataBase_Defined(bDatabaseReset, ref xinifolder, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix))
            {
                frm.CodeTables_IniFileFolder = xinifolder; 
                startup_ShowForm_proc = Startup_03_Show_TestConnectionForm;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
            else
            {
                frm.CodeTables_IniFileFolder = xinifolder;
                startup_ShowForm_proc = Startup_03_Show_ConnectionDialog;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
        }

        internal Startup_eUndoProcedureResult Startup_03_Undo(startup_step xstartup_step,
                                        ref string Err)
        {
            DBSync.DBSync.Startup_03_Undo_DBConnection();
            return Startup_eUndoProcedureResult.OK;
        }

        private bool Startup_03_Show_TestConnectionForm(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_03_onformresult_Show_TestConnectionForm;
            return DBSync.DBSync.Con.Startup_03_Show_TestConnectionForm(frm, xnav);
        }

        private bool Startup_03_Show_ConnectionDialog(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_03_onformresult_ShowDBConnnection;
            return DBSync.DBSync.Con.Startup_03_Show_ConnectionDialog(xnav, DBSync.DBSync.DB_for_Tangenta.DB_TransactionsLog.MyTransactionLog_delegates);
        }
        
        private Startup_onformresult_proc_Result Startup_03_onformresult_Show_TestConnectionForm(startup_step myStartup_step,
                                                                                    Form form,
                                                                                    NavigationButtons.Navigation.eEvent eExitResult,
                                                                                    ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                    ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is DBConnectionControl40.TestConnectionForm)
                    {
                        switch(((DBConnectionControl40.TestConnectionForm)form).Result)
                        {
                            case DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.OK:
                                return Startup_onformresult_proc_Result.NEXT;

                            case DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.CHANGE:
                            case DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.FAILED:
                                startup_ShowForm_proc = Startup_03_Show_ConnectionDialog;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                        }
                    }
                    Err = "ERROR:Tangenta_Form_Document:Startup_03_onformresult_Show_TestConnectionForm:form is not of type " + typeof(DBConnectionControl40.TestConnectionForm).ToString();
                    return Startup_onformresult_proc_Result.ERROR;

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    bool bNewDataBase = false;
                    bool bCancel = false;
                    if (form is DBConnectionControl40.TestConnectionForm)
                    {
                        if (((DBConnectionControl40.TestConnectionForm)form).Result== DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.OK)
                        {
                            if (DBSync.DBSync.Startup_03_CheckDataBaseTables(frm, ref bCancel))
                            {
                                return Startup_onformresult_proc_Result.NEXT;
                            }
                            else
                            {
                                bDatabaseReset = true;
                                return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                            }
                        }
                        else
                        {
                            if (((DBConnectionControl40.TestConnectionForm)form).Result == DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.CHANGE)
                            {
                                startup_ShowForm_proc = Startup_03_Show_ConnectionDialog;
                                return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                            }
                            else if (((DBConnectionControl40.TestConnectionForm)form).Result == DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.FAILED)
                            {
                                if (DBSync.DBSync.Startup_03_CreateNewDatabase(frm, ref bNewDataBase, ref bCancel))
                                {
                                    if (bCancel || !bNewDataBase)

                                    {
                                        bDatabaseReset = true;
                                        return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                                    }
                                    else
                                    {
                                        return Startup_onformresult_proc_Result.NEXT;
                                    }

                                }
                                else
                                {
                                    bDatabaseReset = true;
                                    return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                                }
                            }
                            else
                            {
                                return Startup_onformresult_proc_Result.ERROR;
                            }
                        }
                    }
                    else
                    {
                        return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;
                    }

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_03_onformresult_ShowDBConnnection:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }


        private Startup_onformresult_proc_Result Startup_03_onformresult_ShowDBConnnection(startup_step myStartup_step,
                                                                                            Form form,
                                                                                            NavigationButtons.Navigation.eEvent eExitResult,
                                                                                            ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                                                            ref string Err)
        {
            switch (eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (form is DBConnectionControl40.ConnectionDialog)
                    {
                        DBConnectionControl40.ConnectionDialog frm_ConnectionDialog = (DBConnectionControl40.ConnectionDialog)form;
                        if (DBSync.DBSync.RemoteDB_data != null)
                        {
                            DBSync.DBSync.RemoteDB_data.bWindowsAuthentication = frm_ConnectionDialog.m_con.WindowsAuthentication;
                            DBSync.DBSync.RemoteDB_data.DataSource = frm_ConnectionDialog.m_con.DataSource;
                            DBSync.DBSync.RemoteDB_data.DataBase = frm_ConnectionDialog.m_con.DataBase;
                            DBSync.DBSync.RemoteDB_data.UserName = frm_ConnectionDialog.m_con.UserName;
                            DBSync.DBSync.RemoteDB_data.crypted_Password = frm_ConnectionDialog.m_con.PasswordCrypted;
                            if (DBSync.DBSync.RemoteDB_data.Save(frm.CodeTables_IniFileFolder,ref Err))
                            {
                                return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                            }
                        }
                        return Startup_onformresult_proc_Result.ERROR;
                    }
                    else if (form is DBConnectionControl40.SQLiteConnectionDialog)
                    {
                        if (DBSync.DBSync.Startup_03_Set_LocalDB_From_SQLiteConnectionDialog((DBConnectionControl40.SQLiteConnectionDialog)form))
                        {
                            bDatabaseReset = false;
                            return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                        }
                        else
                        {
                            return Startup_onformresult_proc_Result.ERROR;
                        }

                    }
                    else
                    {
                        Err="ERROR:Tangenta:Form_Document:Startup_03_onformresult_ShowDBConnnection:form = " + form.GetType().ToString() + " is not implemented!";
                        return Startup_onformresult_proc_Result.ERROR;
                    }

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    bool bNewDataBase = false;
                    bool bCancel = false;
                    if (form is DBConnectionControl40.TestConnectionForm)
                    {
                        if (((DBConnectionControl40.TestConnectionForm)form).Result == DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.OK)
                        {
                            if (DBSync.DBSync.Startup_03_CheckDataBaseTables(frm, ref bCancel))
                            {
                                return Startup_onformresult_proc_Result.NEXT;
                            }
                            else
                            {
                                bDatabaseReset = true;
                                return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                            }
                        }
                        else if (((DBConnectionControl40.TestConnectionForm)form).Result == DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.FAILED)
                        {

                            if (DBSync.DBSync.Startup_03_CreateNewDatabase(frm, ref bNewDataBase, ref bCancel))
                            {
                                if (bCancel || !bNewDataBase)
                                {
                                    bDatabaseReset = true;
                                    return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                                }
                                else
                                {
                                    return Startup_onformresult_proc_Result.NEXT;
                                }

                            }
                            else
                            {
                                bDatabaseReset = true;
                                return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                            }
                        }
                        else if (((DBConnectionControl40.TestConnectionForm)form).Result == DBConnectionControl40.TestConnectionForm.eTestConnectionFormResult.CHANGE)
                        {
                            startup_ShowForm_proc = Startup_03_Show_ConnectionDialog;
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION;
                        }
                        else
                        {
                            return Startup_onformresult_proc_Result.ERROR;
                        }
                    }
                    else
                    {
                        return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;
                    }

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_03_onformresult_ShowDBConnnection:eExitResult not implemented for xnav.eExitResult = " + eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
