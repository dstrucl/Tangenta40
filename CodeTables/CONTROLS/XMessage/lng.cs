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

namespace XMessage
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Abort = new ltext( new string[]{"Abort", "Prekini"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_Retry = new ltext(new string[] { "Retry", "Ponovi" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_Ignore = new ltext(new string[] { "Ignore", "Ignoriraj" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_Yes = new ltext(new string[] { "Yes", "Da" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_No = new ltext(new string[] { "No", "Ne" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_OK = new ltext(new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

        public static ltext s_Cancel = new ltext(new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\XMessage\Form_Box.cs

    }
}
