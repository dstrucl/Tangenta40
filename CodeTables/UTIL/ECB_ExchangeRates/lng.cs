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

namespace ECB_ExchangeRates
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Reference = new ltext( new string[]{"Reference",
                                                                  "Povezava"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_ExchangeRatePerDay = new ltext(new string[]{"Exchange Rate per day",
                                                                          "Menjalna razmerja po dnevih"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_lbl_Date = new ltext(new string[]{"Date",
                                                                          "Datum"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_lbl_From = new ltext(new string[]{"From",
                                                                          "od"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_lbl_To = new ltext(new string[]{"To",
                                                                          "do"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_lbl_FromCountryExchange = new ltext(new string[]{"From Country Exchange:",
                                                                          "Iz valute:"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_lbl_ToCountryExchange = new ltext(new string[]{"To Country Exchange:",
                                                                           "V valuto:"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

        public static ltext s_btn_Calculate = new ltext(new string[]{"Calculate",
                                                                     "Pretvori"});   // referenced in C:\Tangenta40\CodeTables\UTIL\ECB_ExchangeRates\Form_ECBExchangeRates.cs

    }
}
