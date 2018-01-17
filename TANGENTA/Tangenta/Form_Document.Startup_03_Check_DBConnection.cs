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
    public partial class Form_Document
    {
        bool bDatabaseReset = false;

        private startup_step CStartup_03_Check_DBConnection()
        {
            bDatabaseReset = Program.Reset2FactorySettings.DBConnectionControlXX_EXE;
            return new startup_step(lng.s_Startup_Check_DBConnection.s, m_startup, Program.nav,
                                    Startup_03_Check_DBConnection, 
                                    startup_step.eStep.Check_03_DBConnection);
        }

        public Startup_check_proc_Result Startup_03_Check_DBConnection(startup_step xstartup_step,
                                                   object oData,
                                                   ref delegate_startup_ShowForm_proc startup_ShowForm_proc,
                                                   ref string Err)
        {
            if (DBSync.DBSync.Startup_03_Check_DBConnection_Is_DataBase_Defined(bDatabaseReset, ref CodeTables_IniFileFolder, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix))
            {
                startup_ShowForm_proc = Startup_03_Show_TestConnectionForm;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }
            else
            {
                startup_ShowForm_proc = Startup_03_Show_ConnectionDialog;
                return Startup_check_proc_Result.WAIT_USER_INTERACTION;
            }

        }

        private bool Startup_03_Show_TestConnectionForm(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_03_onformresult_Show_TestConnectionForm;
            return DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.Startup_03_Show_TestConnectionForm(this, xnav);
        }

        private bool Startup_03_Show_ConnectionDialog(startup_step xstartup_step,
                                                            NavigationButtons.Navigation xnav,
                                                            ref delegate_startup_OnFormResult_proc startup_OnFormResult_proc)
        {
            startup_OnFormResult_proc = Startup_03_onformresult_ShowDBConnnection;
            return DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.Startup_03_Show_ConnectionDialog(xnav);
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
                        if (((DBConnectionControl40.TestConnectionForm)form).Result)
                        {
                            return Startup_onformresult_proc_Result.NEXT;
                        }
                        else
                        {
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
                        if (((DBConnectionControl40.TestConnectionForm)form).Result)
                        {
                            if (DBSync.DBSync.Startup_03_CheckDataBaseTables(this, ref bCancel))
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
                            if (DBSync.DBSync.Startup_03_CreateNewDatabase(this, ref bNewDataBase, ref bCancel))
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
                        startup_ShowForm_proc = Startup_03_Show_TestConnectionForm;
                        return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
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
                        if (((DBConnectionControl40.TestConnectionForm)form).Result)
                        {
                            if (DBSync.DBSync.Startup_03_CheckDataBaseTables(this,ref bCancel))
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
                           if (DBSync.DBSync.Startup_03_CreateNewDatabase(this,ref bNewDataBase, ref bCancel))
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
