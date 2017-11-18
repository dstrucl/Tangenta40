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

using System.Reflection;
using LanguageControl;

namespace UniversalInvoice
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext st_Address = new ltext( new string[]{"Address", "Naslov"});   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Address.cs

        public static ltext st_PageNumber = new ltext(new string[] { "PageNumber", "ŠtevilkaStrani" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\GeneralToken.cs

        public static ltext st_NumberOfPages = new ltext(new string[] { "NumberOfPages", "ŠteviloStrani" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\GeneralToken.cs

        public static ltext st_Notice = new ltext(new string[] { "Notice", "Dopis" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\GeneralToken.cs

        public static ltext st_Footer = new ltext(new string[] { "Footer", "Noga" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\GeneralToken.cs

        public static ltext st_Invoice = new ltext(new string[] { "Invoice", "Račun" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_ProformaInvoice = new ltext(new string[] { "ProformaInvoice", "Predračun" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_FiscalYear = new ltext(new string[] { "FiscalYear", "ObračunskoLeto" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_Number = new ltext(new string[] { "Number", "Številka" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_Cashier = new ltext(new string[] { "Cashier", "OznakaBlagajne" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_IssuerOfInvoice = new ltext(new string[] { "IssuerOfInvoice", "OsebaKiJeIzdalaRačun" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_DateOfIssue = new ltext(new string[] { "DateOfIssue", "Datum_izdaje_računa" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_DateOfMaturity = new ltext(new string[] { "DateOfMaturity", "Datum_zapadlosti_računa" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_OfferValidUntil = new ltext(new string[] { "OfferValidUntil", "Ponudba_velja_do" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_PaymentToBankAccount = new ltext(new string[] { "PaymentToBankAccount", "PlačiloNaBančniRačun" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_PaymentToBankName = new ltext(new string[] { "PaymentToBankName", "PlačiloNaBanko" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_PaymentType = new ltext(new string[] { "PaymentType", "NačinPlačila" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_SumNetPrice = new ltext(new string[] { "SumNetPrice", "CenaSkupajBrezDavka" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_TaxRateName = new ltext(new string[] { "TaxRateName", "ImeDavčneStopnje" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_SumTax = new ltext(new string[] { "SumTax", "DavekSkupaj" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_TotalSum = new ltext(new string[] { "TotalSum", "KončnaCenaZDavkom" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs


        public static ltext st_Storno = new ltext(new string[] { "Storno", "Stornacija" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\InvoiceToken.cs

        public static ltext st_UniqueMessageID = new ltext(new string[] { "FURS_UniqueMessageID", "FURS_UnikatnaŠtevilkaSporočila" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Invoice_FURS_Token.cs

        public static ltext st_UniqueInvoiceID = new ltext(new string[] { "FURS_UniqueInvoiceID", "FURS_UnikatnaŠtevilkaRačuna" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Invoice_FURS_Token.cs

        public static ltext st_QR = new ltext(new string[] { "FURS_QRCode", "FURS_QR_koda" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Invoice_FURS_Token.cs


        public static ltext st_Organisation = new ltext(new string[] { "Organisation", "Organizacija" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Organisation.cs

        public static ltext st_Person = new ltext(new string[] { "Person", "Oseba" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\Person.cs

        public static ltext s_Yes = new ltext(new string[] { "Yes", "Da" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\TemplateToken.cs

        public static ltext s_No = new ltext(new string[] { "No", "Ne" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\TemplateToken.cs

        public static ltext st_Item = new ltext(new string[] { "Item", "StoritevAliArtikel" });   // referenced in C:\Tangenta40\TANGENTA\UniversalInvoice\ItemSold.cs

    }
}
