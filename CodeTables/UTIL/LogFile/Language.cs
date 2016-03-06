#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace LogFile
{
    public static class Language
    {
        public static int id=0;
        public static string[] s_Warning = { "Warning", "Opozorilo" };
        public static string[] s_save = { "Save", "Shrani" };
        public static string[] s_File = { "File", "Datoteka" };
        public static string[] sFilter = { "Log Files |*.txt|All files|*.*", "Log datoteke|*.txt|Vse datoteke|*.*" };
        public static string[] slLogManager = { "Log Manager", "Pregled nad Logi" };
        public static string[] slLogFile = { "Log File", "Log Datoteka" };
        public static string[] sbtnBrowse             = { "Browse", "Izberi" };
        public static string[] sbtn_View              = { "View", "Poglej" };
        public static string[] sbtn_SetDefaultLogFile = { "Set Default Log File", "Nastavi privzeto Log datoteko" };
        public static string[] sbtnCancel             = { "Cancel", "Prekini" };
        public static string[] sbtn_SaveSettings      = { "Save Settings", "Shrani nastavitve" };
        public static string[] slDefaultLogFile       = { "Default Log File:", "Privzeta Log Datoteka:" };
        public static string[] slLogLevel             = { "Write Log  after Level:", "Piši Log nad nivojem:" };
        public static string[] s_chk_WriteLog2DB_on_exit = { "Write Log to DataBase on program exit","Prepiši LogFile v podatkovno bazo ob zaključku programa"};
        
        
    }
}
