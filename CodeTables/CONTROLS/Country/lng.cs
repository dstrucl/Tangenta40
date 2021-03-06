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

namespace Country_ISO_3166
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Form_Select_Country_ISO_3166_Title = new ltext( new string[]{"Select State", "Izberite Državo"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Number = new ltext(new string[] { "Number", "Številka" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext ss_Abbreviation = new ltext(new string[] { "Abbreviation", "Okrajšava" });   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Country = new ltext(new string[]{"Country",
                                         "Država"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Currency_Name = new ltext(new string[]{"Currency Name",
                                         "Ime valute"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Currency = new ltext(new string[]{"Currency",
                                         "Valuta"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Currency_Symbol = new ltext(new string[]{"Currency Symbol",
                                         "Znak valute"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Currency_Code = new ltext(new string[]{"Currency Code",
                                         "Koda valute"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs

        public static ltext s_Currency_DecimalPlaces = new ltext(new string[]{"Currency decimal places",
                                         "Število decimalk valute"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Country\Form_Select_Country_ISO_3166.cs
    }
}
