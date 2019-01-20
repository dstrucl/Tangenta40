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

namespace TangentaDB
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name); 
        }
        public static ltext s_OwnUse = new ltext(new string[] { "Own use", "Lastna poraba" });
        public static ltext s_WriteOff = new ltext(new string[] { "Write off", "Odpis" });

        public static ltext s_ImportType_not_defined = new ltext(new string[] { "Not used", "Ni v uporabi" });
        public static ltext s_ImportType_PurchasePrices = new ltext(new string[] { "Import prices from purchase prices", "Uvozi cene iz nabavnih cen" });
        public static ltext s_ImportType_OtherPriceList = new ltext(new string[] { "Import prices from other price list", "Uvozi cene iz drugega cenika" });

        public static ltext s_ImportCheck_not_defined = new ltext(new string[] { "Not used", "Ni v uporabi" });
        public static ltext s_ImportCheck_OnStartupEachDay = new ltext(new string[] { "On startup each day","Ob zagonu vsak dan" });
        public static ltext s_ImportCheck_OnStartupEachWeek = new ltext(new string[] { "On startup each week", "Ob zagonu vsak teden"});
        public static ltext s_ImportCheck_OnStartupEachMonth = new ltext(new string[] { "On startup each month", "Ob zagonu vsak mesec" });


        public static ltext s_Undefined = new ltext(new string[] { "Undefined", "Nedoločeno" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\CashierActivity.cs

        public static ltext s_To = new ltext(new string[] { "to", "do" });

        public static ltext s_StornoInvoice = new ltext(new string[] { "STORNO", "Stornacija računa" });

        public static ltext s_CopyPrintNumber = new ltext(new string[] { "COPY:", "KOPIJA:"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_SetNewFinancial = new ltext(new string[] { " Do you want to set new financial year ", "Želite Novo leto " });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_AsDefaultFinancialYear = new ltext(new string[] { "\r\n as new default (selected) financial  year", " \r\n določiti kot privzeto (izbrano) finančno leto ?" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_CurrentComputerTimeIsInNewYear = new ltext(new string[] { " Current computer time is in new Year" , " Računalnikova ura kaže Novo leto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_HappyNewYear = new ltext(new string[] { "Happy New Year", "Srečno Novo leto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_OpenNewFiscalYearYesNo = new ltext(new string[] { "Do you want to open new fiscal year:", "Ali želite odpreti novo obračunsko leto:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_IssueDate_not_defined = new ltext(new string[] { " Issue Date Not defined!\r\n", " Datum izdaje računa ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_MethodOfPayment_DI_not_defined = new ltext(new string[] { " Method of payment is not defined!\r\n", " Način plačila ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_MethodOfPayment_DI_BankAccount_not_defined = new ltext(new string[] { " Bank Account is not defined!\r\n", " Bančni račun ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_MethodOfPayment_DI_PaymentDeadline_not_defined = new ltext(new string[] { " Payment deadline is not defined!\r\n", " Rok plačila ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_FVI_not_done = new ltext(new string[] { "Fiscal verification of invoice was not done", "Davčno potrjevanje računa ni bilo izvedeno" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_FVI_done_in_test_environment = new ltext(new string[] { "Fiscal verification done in TEST ENVIRONMENT!", "Davčno potrjevanje računa izvedeno v TESTNEM OKOLJU" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs

        public static ltext s_TermsOfPayment_are_not_defined = new ltext(new string[] { " Terms of payment are not defined\r\n", " Plačilni pogoji niso določeni!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocInvoice_AddOn.cs


        public static ltext s_MethodOfPayment_DPI_not_defined = new ltext(new string[] { " Proforma Invoice method of payment is not defined!\r\n", " Način plačila za predračun ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocProformaInvoice_AddOn.cs

        public static ltext s_MethodOfPayment_DPI_Duration_is_not_defined = new ltext(new string[] { " Payment deadline is not defined!\r\n", " Rok plačila ni določen!\r\n" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\DocProformaInvoice_AddOn.cs

        public static ltext s_A4_Portrait_description = new ltext(new string[] { "A4 portrait", "A4 pokončno" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_page_type_definitions.cs

        public static ltext s_A4_Landscape_description = new ltext(new string[] { "A4 landscape", "A4 landscape" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_page_type_definitions.cs

        public static ltext s_Roll_paper_80_mm_description = new ltext(new string[] { "Roll paper 80 mm", "Papir v roli 80 mm" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_page_type_definitions.cs

        public static ltext s_Roll_paper_58_mm_description = new ltext(new string[] { "Roll paper 58 mm", "Papir v roli 58 mm" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_page_type_definitions.cs

        public static ltext s_HTML_Print_template_DocProformaInvoice = new ltext(new string[]{"HTML Print Template Proforma-Invoice",
                                                         "HTML predloga za tiskanje predračuna"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_type_definitions.cs

        public static ltext s_HTML_Print_template_DocInvoice = new ltext(new string[]{"HTML Print Template Invoice",
                                                                         "HTML predloga za tiskanje računa"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\doc_type_definitions.cs

        public static ltext s_FVI_SLO_RealEstateBP_has_no_Data = new ltext(new string[] { "No data for Fiscal Verification system in Slovenia. \r\nYou can not do fiscal verification until you enter RealEstate data!", "Ni vnešenih podatkov o poslovnem prosturu potrebnih za davčno upravo.\r\nPotrejavanje računov ne bo delalo dokler ne vnesete podatkov o poslovnem prostoru!" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_Atom_FVI_SLO_RealEstateBP.cs

        public static ltext s_Tax_ID = new ltext(new string[] { "VAT ID", "Davč.št." });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_DocInvoice.cs

        public static ltext s_PhisycalPerson = new ltext(new string[]{"Physical Person",
                                           "Fizična oseba"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_DocInvoice.cs

        public static ltext s_Organisation = new ltext(new string[]{"Organisation",
                                                      "Organizacija"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_DocInvoice.cs

        public static ltext s_Woman = new ltext(new string[]{"Woman",
                                       "Ženska"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_DocInvoice.cs

        public static ltext s_Man = new ltext(new string[]{"Man",
                                       "Moški"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_DocInvoice.cs


        public static ltext s_ItemPriceUndefined = new ltext(new string[] { "List of items which prices are undefined", "Seznam artiklov, ki nimajo določene prodajne cene" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_PriceList.cs

        public static ltext s_PriceListIsNotUpdatedBecauseYouDidnotSelect = new ltext(new string[] { "Price List is not updated because you did not defined Tax rate!", "Cenik ni posodobljen z novimi artikli in/ali servisi, ker niste določili davčne stopnje!" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\f_PriceList.cs

        public static ltext s_PaymentType_CASH = new ltext(new string[] { "Cash", "Gotovina" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_PaymentType_CASH_OR_PAYMENT_CARD = new ltext(new string[] { "Cash or payment card", "Gotovina ali plačilna kartica" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_PaymentType_BANK_ACCOUNT_TRANSFER = new ltext(new string[] { "Bank account transfer", "Plačilo na tekoči račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_PaymentType_ALLREADY_PAID = new ltext(new string[] { "Allready paid", "Že plačano" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_PaymentType_PAYMENT_CARD = new ltext(new string[] { "Payment card", "Plačilna kartica" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext s_PaymentType_ANY_TYPE = new ltext(new string[] { "Payment any type", "Vsi načini plačila" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\GlobalData.cs

        public static ltext st_My = new ltext(new string[] { "My", "Moja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_Invoice = new ltext(new string[] { "Invoice", "Račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_ProformaInvoice = new ltext(new string[] { "ProformaInvoice", "Predračun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_Customer = new ltext(new string[] { "Customer", "Stranka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_IssuerOfInvoice = new ltext(new string[] { "IssuerOfInvoice", "OsebaKiJeIzdalaRačun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_DateOfMaturity = new ltext(new string[] { "DateOfMaturity", "Datum_zapadlosti_računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_OfferValidUntil = new ltext(new string[] { "OfferValidUntil", "Ponudba_velja_do" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_Bank = new ltext(new string[] { "Bank", "Banka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_Furs_Test_Environment = new ltext(new string[] { "FURS Test environment INVOICE NOT VALID", "FURS TESTNO okolje RAČUN NI VELJAVEN!" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_Shop_B = new ltext(new string[] { "B", "B" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_STORNO = new ltext(new string[] { "REVERSE", "STORNO" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_journal_invoice_type_Print_Original_description = new ltext(new string[] { "Print Original", "Tiskanja originalnega računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_journal_invoice_type_Print_Copy_description = new ltext(new string[] { "Print Copy", "Tiskanja kopije računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_PaymentOnBankAccount = new ltext(new string[] { "Payment to Bank acount", "Plačilo na bančni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext s_ProformaInvoiceDraftTime_description = new ltext(new string[] { "Proforma Invoice Draft Time", "Čas izdelave osnutka pred-računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocProformaInvoice_Type_definitions .cs

        public static ltext s_ProformaInvoiceTime_description = new ltext(new string[] { "Proforma Invoice Time", "Čas izdaje pred-računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocProformaInvoice_Type_definitions .cs

        public static ltext s_ConsumptionOwnUseDraftTime_description = new ltext(new string[] { "Consumption Own Use Draft Time", "Čas izdelave osnutka lastne porabe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_ConsumptionOwnUseTime_description = new ltext(new string[] { "Consumption Own Use Time", "Čas izdaje lastne porabe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_ConsumptionOwnUseStornoTime_description = new ltext(new string[] { "Consumption Own Use STORNO Time", "Čas stornacije lastne porabe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_ConsumptionWriteOffDraftTime_description = new ltext(new string[] { "Consumption Write Off Draft Time", "Čas izdelave osnutka odpisa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_ConsumptionWriteOffTime_description = new ltext(new string[] { "Consumption Write Off Time", "Čas izdaje odpisa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_ConsumptionWriteOffStornoTime_description = new ltext(new string[] { "Consumption Own Use STORNO Time", "Čas stornacije odpisa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs


        public static ltext s_InvoiceDraftTime_description = new ltext(new string[] { "Invoice Draft Time", "Čas izdelave osnutka računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_InvoiceTime_description = new ltext(new string[] { "Invoice Time", "Čas izdaje računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_InvoicePaidTime_description = new ltext(new string[] { "Invoice Paid Time", "Čas plačila računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_InvoiceStornoTime_description = new ltext(new string[] { "Invoice Storno Time", "Čas stornacije računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\JOURNAL_DocInvoice_Type_definitions.cs

        public static ltext s_TermsOfPayment_Default_100PercentInAdvance = new ltext(new string[] { "100% full payment in advance", "100% Avans" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\TermsOfPayment_definitions.cs

        public static ltext s_EndPrice = new ltext(new string[] { "Total", "Cena" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\ShopABC.cs

        public static ltext s_Tax = new ltext(new string[]{"Tax",
                                                   "Davek"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\ShopABC.cs

        public static ltext s_PriceWithoutTax = new ltext(new string[]{"Price without tax",
                                                          "Cena brez davka"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\ShopABC.cs

        public static ltext s_RetailPricePerUnit = new ltext(new string[]{"Retail price per unit",
                                                                "Prodajna cena na enoto"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\ShopABC.cs

        public static ltext s_Quantity = new ltext(new string[]{"Quantity:",
                                                   "Količina:"});   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\ShopABC.cs

        public static ltext s_No_OrganisationData = new ltext(new string[]{"There is no data about your company. You must enter your company data first!",
                                                         "Ni podatkov o vašem podjetju. Najprej morate vnesti podatke o svojem podjetju"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_StreetName = new ltext(new string[]{"There is no Street Name address of your company. You must enter Street Name address of your company!",
                                                         "Ni podatka o naslovu ulice vašega podjetja. Vnesti morate naslov ulice vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_HouseNumber = new ltext(new string[]{"There is no house number of your company. You must enter house number of your company!",
                                                         "Ni podatka o hišni številki vašega podjetja. Vnesti morate hišno številko vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_ZIP = new ltext(new string[]{"There is no ZIP of your company. You must enter ZIP of your company!",
                                                         "Ni podatka o številki pošte vašega podjetja. Vnesti morate številko pošte vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_City = new ltext(new string[]{"There is no city of your company. You must enter city of your company!",
                                                         "Ni podatka o kraju vašega podjetja. Vnesti morate kraj vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_Office_Data = new ltext(new string[]{"There is no office address of your organisation. You must have office address in your organisation!",
                                                         "Vaše podjetje nima dodatnih  potakov poslovne enot (naslov, opis..),\nVpisati morate še podatke poslovne enote!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_Office_Data_FVI_SLO_RealEstateBP = new ltext(new string[]{"Missing Real Estate Data for your office. You need them for Fiscal verification of invoices in Slovenia!",
                                                                              "Vaša poslovna enota nima podatkov o poslovnem prosturu potrebnih za davčno potrjevanje računov,\nVpisati morate še podatke o poslovnem prostoru, ki so potrebni za davčno potrjevanje računov!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_Person = new ltext(new string[]{"There is no person of your company which is active. You must enter person of your company! (Also Check if Active flag is set!)",
                                                              "Vaše podjetje nima vsaj ene osebe, ki bi bila označena za aktivno.\nVnesti morate osebo ali osebe v vašem podjetju in pri tem mora imeti imeti najmanj ena oseba odkljukano, da je aktivna!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_Tax_ID = new ltext(new string[]{"There is no Tax ID of your company. You must enter Tax ID of your company!",
                                                            "Vaše podjetje nima davčne številke. Vnesti morate davčno številko vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_No_MyOrganisation_Country = new ltext(new string[] {"There is no country of your company. You must enter country of your company!",
                                                     "Ni podatka v kateri državi je vaše podjetje. Vnesti morate državo v kateri je podjetje" });

        public static ltext s_No_Office = new ltext(new string[] { "There is no office of your organisation. You must have at least one office in your organisation!",
                                                 "Vaše podjetje nima poslovnih enot,\nVpisati morate vsaj eno poslovno enoto!" });

    }
}
