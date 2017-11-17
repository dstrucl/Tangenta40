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

namespace Startup
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_License_agreement = new ltext(new string[] { "License agreement", "Licenčna pogodba" });   // referenced in C:\Tangenta40\TANGENTA\Startup\Form_LicenseAgreement.cs

        public static ltext s_I_accept_the_terms_in_the_license_agreement = new ltext(new string[] { "I accept the terms in the license agreement", "V celoti sprejemam pogoje in določila licenčne pogodbe" });   // referenced in C:\Tangenta40\TANGENTA\Startup\Form_LicenseAgreement.cs

        public static ltext s_I_do_not_accept_the_terms_in_the_license_agreement = new ltext(new string[] { "I do not accept the terms in the license agreement", "Ne sprejemam pogojev licenčne pogodbe" });   // referenced in C:\Tangenta40\TANGENTA\Startup\Form_LicenseAgreement.cs

        public static ltext s_Print = new ltext(new string[] { "Print", "Tiskaj" });   // referenced in C:\Tangenta40\TANGENTA\Startup\Form_LicenseAgreement.cs

        public static ltext s_Select = new ltext(new string[]{"Select",
                                                 "Izberi"});   // referenced in C:\Tangenta40\TANGENTA\Startup\Form_Navigate.cs

        public static ltext s_StartupProgram = new ltext(new string[] { "Program Startup", "Zagon Programa Tangenta" });   // referenced in C:\Tangenta40\TANGENTA\Startup\usrc_Startup.cs

    }
}
