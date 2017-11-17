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

namespace DynEditControls
{
    public static class lng
    {
 public static ltext s_Male = new ltext( new string[]{"Male",
                                        "Moški"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\EditControl.cs

 public static ltext s_Female = new ltext( new string[]{"Female",
                                        "Ženski"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\EditControl.cs

 public static ltext s_Format = new ltext( new string[]{"Format", "Format"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_Width = new ltext( new string[]{"width", "širina"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_Height = new ltext( new string[]{"height", "višina"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_Size = new ltext( new string[]{"Size", "Velikost"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_Bytes = new ltext( new string[]{"Byte", "Bytov"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_ResizeImage = new ltext( new string[]{"Resize Image", "Spremeni Velikost Slike"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_KeepAspectRation = new ltext( new string[]{"Keep aspect ration", "Ohrani razmerje med širino in višino"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_UnknownPictureFormatSaveInJpg = new ltext( new string[]{"Error:Unknown picture format! Save in jpeg format?", "Nepoznan format slike! Shranim v Jpeg formatu?"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_SaveInJpgQuestion = new ltext( new string[]{"Save in jpeg format?", "Shranim v Jpeg formatu?"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_OK = new ltext( new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

 public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\DynEditControls\ResizeImage_Form.cs

  }
}
