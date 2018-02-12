#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LanguageControl;

namespace CommandLineHelp
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_CommandLineHelp = new ltext( new string[]{"Command Line Help", "Pomoč za komandno vrstico"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        public static ltext s_OK = new ltext( new string[]{"OK",
                                                         "V redu"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                                  "Prekini"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        public static ltext s_grp_HelpSettings = new ltext(new string[]{"Help addresss settings",
                                                                    "Nastavitev naslova za pomoč"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        
        public static ltext s_LocalHelpAddress = new ltext(new string[]{"Local Help folder",
                                                                        "Lokalna mapa za pomoč"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        public static ltext s_RemoteHelpAddress = new ltext(new string[]{"Remote Help URL",
                                                                         "Naslov pomoči na internetu"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs

        public static ltext s_CommandLineParameters= new ltext(new string[]{"Command line paramaters",
                                                                         "Parametri komandne vrstice"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\CommandLineHelp\CommandLineHelp_Control.cs
    }
}
