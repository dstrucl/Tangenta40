#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageControl
{
    public static class lngToken
    {
        public static ltext st_UniqueMessageID = new ltext("FURS_UniqueMessageID", "FURS_UnikatnaŠtevilkaSporočila");
        public static ltext st_UniqueInvoiceID = new ltext("FURS_UniqueInvoiceID", "FURS_UnikatnaŠtevilkaRačuna");
        public static ltext st_QR = new ltext("FURS_QRCode", "FURS_QR_koda");

        public static ltext st_My = new ltext("My", "Moja");
        public static ltext st_Invoice = new ltext("Invoice", "Račun");
        public static ltext st_ProformaInvoice = new ltext("ProformaInvoice", "Predračun");
        public static ltext st_Item = new ltext("Item", "StoritevAliArtikel");
        public static ltext st_Customer = new ltext("Customer", "Stranka");
        public static ltext st_Organisation = new ltext("Organisation", "Organizacija");
        public static ltext st_Person = new ltext("Person", "Oseba");
        public static ltext st_Address = new ltext("Address", "Naslov");

        public static ltext st_PageNumber = new ltext("PageNumber", "ŠtevilkaStrani");
        public static ltext st_NumberOfPages = new ltext("NumberOfPages", "ŠteviloStrani");

        public static ltext st_FiscalYear = new ltext("FiscalYear", "ObračunskoLeto");
        public static ltext st_Number = new ltext("Number", "Številka");
        public static ltext st_Cashier = new ltext("Cashier", "OznakaBlagajne");
        public static ltext st_IssuerOfInvoice = new ltext("IssuerOfInvoice", "OsebaKiJeIzdalaRačun");


        public static ltext st_DateOfIssue = new ltext("DateOfIssue", "Datum_izdaje_računa");
        public static ltext st_DateOfMaturity = new ltext("DateOfMaturity", "Datum_zapadlosti_računa");
        public static ltext st_PaymentToBankAccount = new ltext("PaymentToBankAccount", "PlačiloNaBančniRačun");
        public static ltext st_PaymentToBankName = new ltext("PaymentToBankName", "PlačiloNaBanko");
        public static ltext st_PaymentType = new ltext("PaymentType", "NačinPlačila");


        public static ltext st_SumNetPrice = new ltext("SumNetPrice", "CenaSkupajBrezDavka");
        public static ltext st_TaxRateName = new ltext("TaxRateName", "ImeDavčneStopnje");
        public static ltext st_SumTax = new ltext("SumTax", "DavekSkupaj");
        public static ltext st_TotalSum = new ltext("TotalSum", "KončnaCenaZDavkom");

        public static ltext st_Notice = new ltext("Notice", "Dopis");
        public static ltext st_Footer = new ltext("Footer", "Noga");
        public static ltext st_Storno = new ltext("Storno", "Stornacija");


    }
}
