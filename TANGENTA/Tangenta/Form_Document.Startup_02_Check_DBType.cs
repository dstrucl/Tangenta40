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
        string CodeTables_IniFileFolder = null;
        string xmlCodeTables = "CodeTables.xml";
        string DataBaseType = null;

        private startup_step CStartup_02_Check_DBType()
        {
            return new startup_step(lng.s_Startup_Check_DataBase.s, m_startup, Program.nav, Startup_Check_DataBase_Type, Startup_ShowDataBaseTypeSelectionForm, onformresult_ShowDataBaseTypeSelectionForm, startup_step.eStep.Check_02_DataBaseType);
        }

        public Startup_check_proc_Result Startup_Check_DataBase_Type(startup myStartup, object o, NavigationButtons.Navigation xnav, ref string Err)
        {
            string sDBType = null;

            if (StaticLib.Func.SetApplicationDataSubFolder(ref CodeTables_IniFileFolder, Program.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                sDBType = Properties.Settings.Default.DBType;
                if (sDBType.Length == 0)
                {
                    // just show window
                    return Startup_check_proc_Result.WAIT_USER_INTERACTION;
                }
                else
                {
                    //Do Real Check
                    if (DBSync.DBSync.Get_eDBType(sDBType, ref DBSync.DBSync.m_DBType,this, CodeTables_IniFileFolder, xmlCodeTables))
                    {
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
                return Startup_check_proc_Result.CHECK_ERROR;
            }

        }

        private bool Startup_ShowDataBaseTypeSelectionForm(object oData, Navigation xnav, ref string Err)
        {
            string sDataBaseType = "SQLITE";
            DBSync.DBSync.Show_Get_DBTypeForm(ref sDataBaseType, xnav);
            return true;
        }

        private Startup_onformresult_proc_Result onformresult_ShowDataBaseTypeSelectionForm(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            switch (xnav.eExitResult)
            {
                case Navigation.eEvent.NEXT:
                    if (xnav.ChildDialog is DBSync.Form_GetDBType)
                    {
                        DBConnection.eDBType eDBType = ((DBSync.Form_GetDBType)xnav.ChildDialog).m_DBType;
                        string sDBType = null;
                        switch (eDBType)
                        {
                            case DBConnection.eDBType.SQLITE:
                                sDBType = "SQLITE";
                                Properties.Settings.Default.DBType = sDBType;
                                Properties.Settings.Default.Save();
                                if (DBSync.DBSync.Get_eDBType(sDBType, ref eDBType, this, CodeTables_IniFileFolder, xmlCodeTables))
                                {
                                    return Startup_onformresult_proc_Result.NEXT;
                                }
                                else
                                {
                                    return Startup_onformresult_proc_Result.ERROR;
                                }
                            case DBConnection.eDBType.MSSQL:
                                sDBType = "MSSQL";
                                Properties.Settings.Default.DBType = sDBType;
                                Properties.Settings.Default.Save();
                                if (DBSync.DBSync.Get_eDBType(sDBType, ref eDBType, this, CodeTables_IniFileFolder, xmlCodeTables))
                                {
                                    return Startup_onformresult_proc_Result.NEXT;
                                }
                                else
                                {
                                    return Startup_onformresult_proc_Result.ERROR;
                                }
                            default:
                                LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:Unsuported DB type:" + eDBType.ToString());
                                return Startup_onformresult_proc_Result.ERROR;
                        }
                    }
                    else
                    {
                        if (xnav.ChildDialog == null)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:xnav.ChildDialog == null!");
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:xnav.ChildDialog is not of type DBSync.Form_GetDBType DB type:" + xnav.ChildDialog.GetType().ToString());
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
                    LogFile.Error.Show("ERROR:Tangenta:FormDocument:onformresult_ShowDataBaseTypeSelectionForm:xnav.eExitResult not implemented for xnav.eExitResult = " + xnav.eExitResult.ToString());
                    return Startup_onformresult_proc_Result.ERROR;
            }
        }
    }
}
