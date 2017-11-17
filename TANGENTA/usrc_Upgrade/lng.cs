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

namespace UpgradeDB
{
    public static class lng
    {
 public static ltext s_UpgradeBackupFileExist_restore_old_Database = new ltext( new string[]{"Upgrade failed, Database backup file exists. Restore DataBase \"%s\" (Yes/No) ?", "Nadgradnja podatkovne baze je bila neuspešna.\r\n Povrnem podatkovno bazo v prejšne stanje iz datoteke:\"%s\" (Da/Ne) ?"});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_RealGrossSumIs = new ltext( new string[]{"Correct gross price = ", "\r\nPravilna končna cena = "});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_WrongGrossSum = new ltext( new string[]{"Wrong gross price =", "Nepravilna končna cena ="});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_RealTaxSumIs = new ltext( new string[]{"Correct tax = ", "\r\nPravilen davek = "});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_WrongTaxSum = new ltext( new string[]{"Wrong tax sum =", "Nepravilna davek ="});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_RealNetSumIs = new ltext( new string[]{"Correct net sum = ", "\r\nPravilna cena brez davka = "});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_ForDocInvoiceNumber = new ltext( new string[]{" for invoice number =", " za račun št.= "});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_WrongNetSum = new ltext( new string[]{"Wrong total sum without tax =", "Nepravilna cena brez davka ="});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_UpgradeDatabase = new ltext( new string[]{"Upgrade DataBase:", "Nadgradnja podatkovne baze:"});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_ImportData = new ltext( new string[]{"Importing data", "Uvoz podatkov"});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_BackupOfExistingDatabase = new ltext( new string[]{"Creating backup copy of existing DataBase :", "Ustvarjanje vranostne kopije obstoječe podatkovne baze:"});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

 public static ltext s_ReadTable = new ltext( new string[]{"Read Table :", "Berem tabelo :"});   // referenced in C:\Tangenta40\TANGENTA\usrc_Upgrade\Upgrade_inThread.cs

  }
}
