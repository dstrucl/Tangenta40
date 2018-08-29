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


namespace LanguageControl
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_DecimalPoint = new ltext(new string[] { ".", "," });   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\DynSettings.cs


        public static ltext s_Text_in_language = new ltext(new string[] { "Text in Language", "Prevod v jeziku" });   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_ltext_Edit.cs

        public static ltext s_Language = new ltext(new string[]{"Language",
                                                   "Jezik"});   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_ltext_Edit.cs

        public static ltext s_EditTitle = new ltext(new string[]{"Edit Control Text",
                                                   "Uredi napis kontrole"});   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_ltext_Edit.cs

        public static ltext s_Dictonary_of_controls_text = new ltext(new string[]{"Dictionary of all Control's Text",
                                                                                  "Slovar vseh napisov na kontrolah"});   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_Language_Dictionary.cs

        public static ltext s_ModuleName = new ltext(new string[]{"Program or library Name",
                                                                  "Ime programa ali modula"});   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_Language_Dictionary.cs

        public static ltext s_Variable = new ltext(new string[]{"Variable Name",
                                                               "Ime spremeljivke"});   // referenced in C:\Tangenta40\CodeTables\UTIL\LanguageControl\Form_Language_Dictionary.cs
    }
}
