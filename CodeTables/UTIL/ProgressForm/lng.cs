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

namespace ProgressForm
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ProgressForm\Progress_Form.cs
        public static ltext s_ExportToFile = new ltext(new string[] { " Export to file",
                                           "Izvoz v datoke" });

        public static ltext s_Columns = new ltext(new string[] { "Columns", "Število stolpcev" });

        public static ltext s_Rows = new ltext(new string[] { "Rows", "Število vrstic" });

        public static ltext s_ExportDoneInXprocent = new ltext(new string[] { " Export", "Izvoženo" });
    }
}
