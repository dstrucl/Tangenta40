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

namespace Excell_Export
{
    public static class lng
    {
 public static ltext s_ErrorStartExecuteExcel = new ltext( new string[]{"Error opening file:", "Napaka pri odpiranju datoteke:"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Export2Excell.cs

 public static ltext s_ErrorInExportToExcel = new ltext( new string[]{"Error in export", "Napaka pri izvozu"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Export2Excell.cs

 public static ltext s_ThereAreNoSelectedRowsToExport = new ltext( new string[]{"You didn't select rows to export into  \"Excel\"(.xls) file.", "Niste izbrali vrstic za izvoz v \"Excel\" datoteko?"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Export2Excell.cs

 public static ltext s_Columns = new ltext( new string[]{"Columns", "Število stolpcev"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Progress_Form.cs

 public static ltext s_Rows = new ltext( new string[]{"Rows", "Število vrstic"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Progress_Form.cs

 public static ltext s_ExportToFile = new ltext( new string[]{" Export to file", "Izvoz v datoke"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Progress_Form.cs

 public static ltext s_ExportDoneInXprocent = new ltext( new string[]{" Export", "Izvoženo"});   // referenced in C:\Tangenta40\CodeTables\Excell_Export\Progress_Form.cs


  }
}
