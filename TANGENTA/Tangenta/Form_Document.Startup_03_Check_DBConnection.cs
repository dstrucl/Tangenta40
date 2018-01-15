using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document
    {
        bool bDatabaseReset = false;

        private startup_step CStartup_03_Check_DBConnection()
        {
            bDatabaseReset = Program.Reset2FactorySettings.DBConnectionControlXX_EXE;
            return new startup_step(lng.s_Startup_Check_DBConnection.s, m_startup, Program.nav, Startup_03_Check_DBConnection, Startup_03_ShowDBConnectionForm, Startup_03_onformresult_ShowDBConnnection, startup_step.eStep.Check_03_DBConnection);
        }

        public Startup_check_proc_Result Startup_03_Check_DBConnection(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            if (DBSync.DBSync.Startup_03_Check_DBConnection_Is_DataBase_Defined(bDatabaseReset, ref CodeTables_IniFileFolder, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix, TangentaDataBaseDef.MyDataBase_Tangenta.DataBaseFilePrefix))
            {
                return Startup_check_proc_Result.WAIT_USER_INTERACTION_0;
            }
            else
            {
                return Startup_check_proc_Result.WAIT_USER_INTERACTION_2;
            }

        }

        private bool Startup_03_ShowDBConnectionForm(object oData, Navigation xnav, startup_step.Startup_check_proc_Result echeck_proc_Result, ref string Err)
        {
           switch (echeck_proc_Result)
            {
                case Startup_check_proc_Result.WAIT_USER_INTERACTION_0:
                    DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.Startup_03_Show_TestConnectionForm(this, xnav);
                    return true;

                case Startup_check_proc_Result.WAIT_USER_INTERACTION_2:
                    DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.Startup_03_Show_ConnectionDialog(xnav);
                    return true;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_03_ShowDBConnectionForm: echeck_proc_Result = " + echeck_proc_Result.ToString() + " not implememented!");
                    return false;
            }
          
        }

        private Startup_onformresult_proc_Result Startup_03_onformresult_ShowDBConnnection(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (xnav.ChildDialog is DBConnectionControl40.TestConnectionForm)
                    {
                        if (((DBConnectionControl40.TestConnectionForm)xnav.ChildDialog).Result)
                        {
                            return Startup_onformresult_proc_Result.NEXT;
                        }
                        else
                        {
                            return Startup_onformresult_proc_Result.WAIT_USER_INTERACTION_1;
                        }
                    }
                    else if (xnav.ChildDialog is DBConnectionControl40.ConnectionDialog)
                    {
                        return Startup_onformresult_proc_Result.DO_CHECK_PROC_AGAIN;
                    }
                    else if (xnav.ChildDialog is DBConnectionControl40.SQLiteConnectionDialog)
                    {
                        if (DBSync.DBSync.Startup_03_Set_LocalDB_From_SQLiteConnectionDialog((DBConnectionControl40.SQLiteConnectionDialog)xnav.ChildDialog))
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
                        LogFile.Error.Show("ERROR:Tangenta:Form_Document:Startup_03_onformresult_ShowDBConnnection:xnav.ChildDialog = " + xnav.ChildDialog.GetType().ToString() + " is not implemented!");
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
                    if (xnav.ChildDialog is DBConnectionControl40.TestConnectionForm)
                    {
                        if (((DBConnectionControl40.TestConnectionForm)xnav.ChildDialog).Result)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_03_onformresult_ShowDBConnnection:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
