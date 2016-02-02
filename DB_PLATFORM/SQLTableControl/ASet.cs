using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageControl;

namespace SQLTableControl
{
    public static class ASet
    {
        public static bool SuperAdministrator = false;

        public static string KEYWORD_LINES = "@@LINES";

        public static void Init(int xLanguageID, bool bDebug_SQL)
        {
            LanguageControl.DynSettings.LanguageID = xLanguageID;
            bPreviewSQLBeforeExecution = bDebug_SQL;
        }

        public static bool bPreviewSQLBeforeExecution
        {
            get
            {
                return DBConnectionControl40.DynSettings.bPreviewSQLBeforeExecution;
            }
            set
            {
                DBConnectionControl40.DynSettings.bPreviewSQLBeforeExecution = value;
            }
        }

        public static void Settings_Reset()
        {
            Properties.Settings.Default.Reset();
        }

        public static int LanguageID
        {
            get
            {
                return LanguageControl.DynSettings.LanguageID;
            }
            set
            {
                LanguageControl.DynSettings.LanguageID = value;
            }
        }
    }
}
