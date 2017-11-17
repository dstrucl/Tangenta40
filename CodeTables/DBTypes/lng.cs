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

namespace DBTypes
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_UnknownPictureFormatSaveInJpg = new ltext(new string[] { "Error:Unknown picture format! Save in jpeg format?", "Nepoznan format slike! Shranim v Jpeg formatu?" });   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_SaveInJpgQuestion = new ltext(new string[] { "Save in jpeg format?", "Shranim v Jpeg formatu?" });   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_MemoryBmpPictureFormatNotAllowed_SaveInJpg = new ltext(new string[] { "MemoryBmp picture format not allowed for storing in DataBase! Convert in jpeg format?", "Slike v formatu \"MemoryBmp\"  ni veljavna za vpis v podatkovno bazo! Shranim v Jpeg formatu?" });   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_File = new ltext(new string[]{"File",
                                       "Datoteka"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_File_does_not_exist = new ltext(new string[]{"File does not exist:",
                                                       "Datoteka ne obstaja :"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_Illegal_format_for = new ltext(new string[]{"Illegal format for",
                                                 "Neveljaven format for"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_UnsuportedType = new ltext(new string[]{"Unsupported type",
                                                  "Neveljaven typ"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_ErrorNoImage = new ltext(new string[]{"ERROR No image in Func.ImageStore!",
                                                "NAPAKA: Ni slike v Func.ImageStore!"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\DBTypes.cs

        public static ltext s_Woman = new ltext(new string[]{"Woman",
                                       "Ženska"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\func.cs

        public static ltext s_Man = new ltext(new string[]{"Man",
                                       "Moški"});   // referenced in C:\Tangenta40\CodeTables\DBTypes\func.cs

    }
}
