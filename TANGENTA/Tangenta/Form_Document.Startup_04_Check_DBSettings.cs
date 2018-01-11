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
        bool bNewDatabaseCreated = false;
        bool bInit_DBType_Canceled = false;

        private startup_step CStartup_04_Check_DBSettings()
        {
            return new startup_step(lng.s_Startup_Check_DataBase.s, m_startup, Program.nav, Startup_04_Check_DBSettings, Startup_04_ShowDBSettingsForm, Startup_04_onformresult_ShowDBSettings, startup_step.eStep.Check_04_DBSettings);
        }

        public Startup_check_proc_Result Startup_04_Check_DBSettings(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            fs.enum_GetDBSettings eGetDBSettings_Result = m_usrc_Main.m_UpgradeDB.Read_DBSettings(myStartup, o, xnav, ref Err);
            switch (eGetDBSettings_Result)
            {

                case fs.enum_GetDBSettings.DBSettings_OK:
                    return Startup_check_proc_Result.CHECK_OK;

                //        bResult = CheckDataBaseVersion(myStartup, ref Err);
                //        if (bResult)
                //        {
                //            //if (Program.bFirstTimeInstallation)
                //            //{
                //            //    if (fs.GetTableRowsCount("myOrganisation_Person") == 0)
                //            //    {
                //            //        //DataBase Is Empty!
                //            //        bResult = InsertSampleData(myStartup, xnav, ref Err);
                //            //        if (xnav.eExitResult == Navigation.eEvent.PREV)
                //            //        {
                //            //            goto do_Form_DBSettings;
                //            //        }
                //            //    }
                //            //}
                //        }
                //        return bResult;

                case fs.enum_GetDBSettings.No_Data_Rows:
                   //No CheckDataBaseVersion is needed because Database was allready created and its version has not been written to DBSettings table
                        return Startup_check_proc_Result.WAIT_USER_INTERACTION; // ShowDB_settings


                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                        LogFile.Error.Show(Err);
                    return Startup_check_proc_Result.CHECK_ERROR;

                case fs.enum_GetDBSettings.No_TextValue:
                    LogFile.Error.Show(Err);
                    return Startup_check_proc_Result.CHECK_ERROR;

                case fs.enum_GetDBSettings.No_ReadOnly:
                        Err = "ERROR enum_GetDBSettings return No_ReadOnly!";
                    LogFile.Error.Show(Err);
                    return Startup_check_proc_Result.CHECK_ERROR;

                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    LogFile.Error.Show(Err);
                    return Startup_check_proc_Result.CHECK_ERROR;
            }

        }

        private bool Startup_04_ShowDBSettingsForm(object oData, Navigation xnav, ref string Err)
        {
            xnav.ChildDialog = new Form_DBSettings(xnav, Program.AdministratorLockedPassword);
            xnav.ShowForm();
            return true;
        }

        private Startup_onformresult_proc_Result Startup_04_onformresult_ShowDBSettings(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    fs.enum_GetDBSettings eGetDBSettings_Result = m_usrc_Main.eGetDBSettings_Result(myStartup);
                    switch (eGetDBSettings_Result)
                    {

                        case fs.enum_GetDBSettings.DBSettings_OK:
                            return Startup_onformresult_proc_Result.NEXT;

                    //        bResult = CheckDataBaseVersion(myStartup, ref Err);
                    //        if (bResult)
                    //        {
                    //            //if (Program.bFirstTimeInstallation)
                    //            //{
                    //            //    if (fs.GetTableRowsCount("myOrganisation_Person") == 0)
                    //            //    {
                    //            //        //DataBase Is Empty!
                    //            //        bResult = InsertSampleData(myStartup, xnav, ref Err);
                    //            //        if (xnav.eExitResult == Navigation.eEvent.PREV)
                    //            //        {
                    //            //            goto do_Form_DBSettings;
                    //            //        }
                    //            //    }
                    //            //}
                    //        }
                    //        return bResult;

                        case fs.enum_GetDBSettings.No_Data_Rows:

                            return Startup_onformresult_proc_Result.NEXT; // ShowDB_settings

                        //    //No CheckDataBaseVersion is needed because Database was allready created and its version has not been written to DBSettings table
                        //        xnav.ChildDialog = new Form_DBSettings(xnav, Program.AdministratorLockedPassword);
                        //        xnav.ShowForm();

                        //        return bResult;

                        case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    //        LogFile.Error.Show(Err);
                    //        //myStartup.eNextStep = startup_step.eStep.Cancel;
                    //        return false;

                        case fs.enum_GetDBSettings.No_TextValue:
                    //        //myStartup.eNextStep = startup_step.eStep.Cancel;
                    //        return false;

                        case fs.enum_GetDBSettings.No_ReadOnly:
                    //        Err = "ERROR enum_GetDBSettings return No_ReadOnly!";
                    //        LogFile.Error.Show(Err);
                    //        //myStartup.eNextStep = startup_step.eStep.Cancel;
                    //        return false;

                        default:
                            Err = "ERROR enum_GetDBSettings not handled!";
                    //        LogFile.Error.Show(Err);
                    //        //myStartup.eNextStep = startup_step.eStep.Cancel;
                    //        return false;

                    //}

                        return Startup_onformresult_proc_Result.NEXT;
                    }
                  
            }
            return Startup_onformresult_proc_Result.ERROR;
        }
    }
}
