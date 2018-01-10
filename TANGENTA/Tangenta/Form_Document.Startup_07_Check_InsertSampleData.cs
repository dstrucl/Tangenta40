using DBConnectionControl40;
using NavigationButtons;
using Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangentaDB;
using static Startup.startup_step;

namespace Tangenta
{
    public partial class Form_Document
    {
        

        private startup_step CStartup_07_Check_InsertSampleData()
        {
            return new startup_step(lng.s_Startup_Check_DataBase.s, m_startup, Program.nav, Startup_07_Check_InsertSampleData, Startup_05_ShowCheckInsertSampleDataForm, Startup_07_onformresult_ShowCheckInsertSampleDataForm, startup_step.eStep.Check_04_DBSettings);
        }

        public Startup_check_proc_Result Startup_07_Check_InsertSampleData(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            if (this.m_usrc_Main.CheckDBVersion(myStartup, o, xnav, ref Err))
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                return Startup_check_proc_Result.CHECK_ERROR;
            }
        }

        private bool Startup_05_ShowCheckInsertSampleDataForm(object oData, Navigation xnav, ref string Err)
        {
            DBSync.DBSync.Init_DBType(Program.bResetNew, CodeTables_IniFileFolder, ref DataBaseType, Program.bChangeConnection, ref bNewDatabaseCreated, xnav, ref bInit_DBType_Canceled);
            return true;
        }

        private Startup_onformresult_proc_Result Startup_07_onformresult_ShowCheckInsertSampleDataForm(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                        return Startup_onformresult_proc_Result.NEXT;

                case Navigation.eEvent.PREV:
                    return Startup_onformresult_proc_Result.PREV;

                case Navigation.eEvent.EXIT:
                    return Startup_onformresult_proc_Result.EXIT;

                case NavigationButtons.Navigation.eEvent.NOTHING:
                    // happens when check procedure is OK
                    return Startup_onformresult_proc_Result.NO_FORM_BUT_CHECK_OK;

                default:
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
