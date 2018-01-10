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
        bool bNewDatabaseCreated = false;
        bool bInit_DBType_Canceled = false;

        private startup_step CStartup_04_Check_DBSettings()
        {
            return new startup_step(lng.s_Startup_Check_DataBase.s, m_startup, Program.nav, Startup_04_Check_DBSettings, Startup_04_ShowDBSettingsForm, Startup_04_onformresult_ShowDBSettings, startup_step.eStep.Check_04_DBSettings);
        }

        public Startup_check_proc_Result Startup_04_Check_DBSettings(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            if (m_usrc_Main.m_UpgradeDB.Read_DBSettings_Version(myStartup, o, xnav, ref Err))
            {
                return Startup_check_proc_Result.CHECK_OK;
            }
            else
            {
                return Startup_check_proc_Result.CHECK_ERROR;
            }

        }

        private bool Startup_04_ShowDBSettingsForm(object oData, Navigation xnav, ref string Err)
        {
            return true;
        }

        private Startup_onformresult_proc_Result Startup_04_onformresult_ShowDBSettings(startup myStartup, object oData, Navigation xnav, ref string Err)
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:Startup_04_onformresult_ShowDBSettings:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
