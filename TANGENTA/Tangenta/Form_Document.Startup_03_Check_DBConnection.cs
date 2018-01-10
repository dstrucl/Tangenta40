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
    

        private startup_step CStartup_03_Check_DBConnection()
        {
            return new startup_step(lng.s_Startup_Check_DataBase.s, m_startup, Program.nav, Startup_03_Check_DBConnection, Startup_03_ShowDBConnectionForm, Startup_03_onformresult_ShowDBConnnection, startup_step.eStep.Check_03_DBConnection);
        }

        public Startup_check_proc_Result Startup_03_Check_DBConnection(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
             return Startup_check_proc_Result.WAIT_USER_INTERACTION;
        }

        private bool Startup_03_ShowDBConnectionForm(object oData, Navigation xnav, ref string Err)
        {
            DBSync.DBSync.Init_DBType(Program.bResetNew, CodeTables_IniFileFolder, ref DataBaseType, Program.bChangeConnection, ref bNewDatabaseCreated, xnav, ref bInit_DBType_Canceled);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_03_onformresult_ShowDBConnnection(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (DBSync.DBSync.Evaluate_InitDBType(Program.bResetNew, CodeTables_IniFileFolder, ref DataBaseType, Program.bChangeConnection, ref  bNewDatabaseCreated, xnav, ref bInit_DBType_Canceled))
                    {
                        return Startup_onformresult_proc_Result.NEXT;
                    }
                    else
                    {
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_03_onformresult_ShowDBConnnection:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
