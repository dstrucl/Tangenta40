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

namespace DBSync
{
    public static class lng
    {
 public static ltext s_CanNotReadDataBaseFile = new ltext( new string[]{"ERRRO:Can not read database file.", "NAPAKA:Neuspešno branje podatkovne baze."});   // referenced in C:\Tangenta40\CodeTables\DBSync\DBSync.cs

 public static ltext s_CheckLocalDatabase = new ltext( new string[]{"Check Local DataBase:", "Preverjanje lokalne baze podatkov:"});   // referenced in C:\Tangenta40\CodeTables\DBSync\DBSync.cs

 public static ltext s_LocalDatabase_OK = new ltext( new string[]{"Local DataBase = ", "Lokalna baza podatkov = "});   // referenced in C:\Tangenta40\CodeTables\DBSync\DBSync.cs

 public static ltext s_ConnectionToLocalDatabaseFailed = new ltext( new string[]{"Connection to SQLite database file was not successful.", "Povezava na SQLite podatkovno datoteko ni uspela!"});   // referenced in C:\Tangenta40\CodeTables\DBSync\DBSync.cs

 public static ltext s_DataBaseFile = new ltext( new string[]{"Database file:", "Podatkovna baza:"});   // referenced in C:\Tangenta40\CodeTables\DBSync\DBSync.cs

 public static ltext s_SelectDatabase = new ltext( new string[]{"Select Database type", "Izberite tip podatkovne baze"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_GetDBType.cs

 public static ltext s_Server = new ltext( new string[]{"Server",
                                           "Strežnik"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_DBmanager.cs

 public static ltext s_DataBase = new ltext( new string[]{"Database",
                                             "Podatkovna baza"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_DBmanager.cs

 public static ltext s_DataBaseVersion = new ltext( new string[]{"DataBaseVersion", "Verzija podatkovne baze:"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_DBmanager.cs

 public static ltext s_DatabaseInfo = new ltext( new string[]{"Database INFO:", "O podatkovni bazi:"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_DBmanager.cs

 public static ltext s_Database = new ltext( new string[]{"Database", "Podatkovna baza"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_DBmanager.cs

 public static ltext s_Copyright_KIG = new ltext( new string[]{"This program is property of KIG d.d. All right reserved.", "Ta program je last podjetja KIG.d.d. Vse pravice so pridržane."});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_StartupWindow.cs

 public static ltext s_Startup_title = new ltext( new string[]{"KIG Plates, program for production of vehichle plates", "KIG program za proizvodnjo registrskih tablic"});   // referenced in C:\Tangenta40\CodeTables\DBSync\Form_StartupWindow.cs


  }
}
