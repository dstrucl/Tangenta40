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

namespace Password
{
    public static class lng
    {
 public static ltext s_RememberPasswordForSession = new ltext( new string[]{"Until the end of program, don't ask for password again", "Za čas tokratnega delovanja aplikacije ni potrebno ponovno vnesti skrbniškega gesla"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_Password.cs

 public static ltext s_Enter_Administrator_Password = new ltext( new string[]{"Enter Administrator Password", "Vpišite skrbniško geslo"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_Password.cs

 public static ltext s_Wrong_Password = new ltext( new string[]{"Wrong Password", "Napačno geslo"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_Password.cs

 public static ltext s_OK = new ltext( new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_Password.cs

 public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_Password.cs

 public static ltext s_RetypePassword = new ltext( new string[]{"Retype password:", "Ponovite geslo:"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_PasswordDefinition.cs

 public static ltext s_Minimum_Password_Length_is = new ltext( new string[]{"The length of password text must be >= ",
                                                                   "Dolžina gesla mora biti >= "});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_PasswordDefinition.cs

 public static ltext s_Password_does_not_match = new ltext( new string[]{"Password does not match!",
                                                                   "Gesli se ne ujemata"});   // referenced in C:\Tangenta40\CodeTables\CONTROLS\Password\usrc_PasswordDefinition.cs

  }
}
