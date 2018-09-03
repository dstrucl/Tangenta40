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

namespace TangentaPrint
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        #region PrintStockTake

        public static ltext s_STOCKTAKE = new ltext(new string[] { "STOCKTAKE", "PREVZEMNICA" });
        public static ltext s_Date = new ltext(new string[] { "Date", "Datum" });
        public static ltext s_SupplierTaxID = new ltext(new string[] { "Supplier VAT ID", "Dobavitelj davčna št." });
        public static ltext s_Supplier = new ltext(new string[] { "Supplier", "Dobavitelj" });
        public static ltext s_BuyerTaxID = new ltext(new string[] { "Buyer VAT ID", "Kupec davčna št." });
        public static ltext s_Buyer = new ltext(new string[] { "Buyer", "Kupec" });
        public static ltext s_DeliveryNumber = new ltext(new string[] { "Delivery number", "Št, dobavnice" });
        public static ltext s_DeliveryNumberDate = new ltext(new string[] { "Delivery date", "Datum dobavnice" });
        public static ltext s_Item = new ltext(new string[] { "Item", "Artikel" });
        public static ltext s_Amount = new ltext(new string[] { "Amount", "Znesek" });
        public static ltext s_Quantity = new ltext(new string[] { "Quantity", "Količina" });
        public static ltext s_VAT = new ltext(new string[] { "VAT", "DDV" });
        public static ltext s_without_VAT = new ltext(new string[] { "without VAT", "brez DDV" });
        public static ltext s_with_VAT = new ltext(new string[] { "with VAT", "z DDV" });
        public static ltext s_Total = new ltext(new string[] { "without VAT", "brez DDV" });
        public static ltext s_PostingDate = new ltext(new string[] { "Posting Date", "Datum knjiženja" });

        #endregion

        public static ltext s_CalculatedVAT = new ltext(new string[] { "VAT:", "Obračunani DDV:" });
        
        public static ltext s_TaxBase = new ltext(new string[] { "Taxable amount:", "Osnova:" });

        public static ltext s_Total_turnover = new ltext(new string[] { "Total turnover:", "Skupni promet:" });
        

        public static ltext s_InvoicesIssued = new ltext(new string[] { "Invoices:", "Izdani računi:" });

        public static ltext s_Storno = new ltext(new string[] { "STORNO", "STORNO" });

        public static ltext s_From = new ltext(new string[] { "from", "od" });
        public static ltext s_To = new ltext(new string[] { "to", "do" });

        public static ltext s_SaleStartDate = new ltext(new string[] { "Sales start date:", "Datum začetka prodaje:" });
        public static ltext s_SaleEndDate = new ltext(new string[] { "Sales end date:", "Datum zaključka prodaje:" });

        public static ltext s_CashierClose_Number = new ltext(new string[] { "Closing cashier ((@@EDName@@)) Closing Num.:", "Zaključek blagajne ((@@EDName@@)) Št. zaključka:"});

        
        public static ltext s_TaxID_for_VAT = new ltext(new string[] { "ID for VAT: ", "ID za DDV: " });
        
        public static ltext s_BussinessUnit = new ltext(new string[] { "Office: ", "PE: " });
        public static ltext s_OrganisationName = new ltext(new string[] { "Organisation name", "Organizacija" });
        public static ltext s_OfficeName = new ltext(new string[] { "Office Name", "Poslovna enota" });
        public static ltext s_ElectronicDevice = new ltext(new string[] { "Electronic device", "Elektronska naprava" });

        public static ltext s_NumberOfInvoices = new ltext(new string[] { "Number Of Invoices", "Število računov" });
        public static ltext s_NumberOfCashInvoices = new ltext(new string[] { "Number Of cash payments", "Število plačil z gotovino" });
        public static ltext s_NumberOfCardInvoices = new ltext(new string[] { "Number Of card payments", "Število plačil s kartico" });

        public static ltext s_IncomeForOrg = new ltext(new string[] { "Income for", "Iztržki za" });

        public static ltext s_IssuerPerson = new ltext(new string[] { "Person", "Oseba" });
        public static ltext s_MethodOfPayment = new ltext(new string[] { "Method of payment", "Način plačila:" });
        public static ltext s_TotalWithVAT = new ltext(new string[] { "Total", "Skupaj z DDV" });

        public static ltext s_NetSum = new ltext(new string[] { "Net sum", "Skupaj brez DDV" });

        public static ltext s_TaxTotal = new ltext(new string[] { "Tax sum", "Davek skupaj" });
        public static ltext s_TaxTotalcheck = new ltext(new string[] { "Tax 2 sum ", "Davek 2 skupaj" });
        public static ltext s_IssueTime = new ltext(new string[] { "Inv. Time", "Datum računa" });
        public static ltext s_InvoiceNumber = new ltext(new string[] { "Inv. Num.:", "Št.računa" });

        public static ltext s_InvoiceAllreadyPrintedToPrintCopyCloseAndOpenThisDialogAgain = new ltext(new string[] { "To print copy of this invoice close and open this dialog again.", "Za tiskanje kopije računa zapustite ta dialog in ponovno pritisnite na gumb Tiskanje." });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintJournal.cs

        public static ltext s_HistoryOfInvoiceAndPrint = new ltext(new string[] { "History of Invoice", "Zgodovina računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintJournal.cs
        public static ltext s_HistoryOfProformaInvoiceAndPrint = new ltext(new string[] { "History of Proforma-Invoice", "Zgodovina pred-računa ali ponudbe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintJournal.cs

        public static ltext s_Printer = new ltext(new string[] { "Printer", "Tiskalnik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintJournal.cs

        public static ltext s_doc_TemplateName = new ltext(new string[] { "Template name", "Ime predloge" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_doc_TemplateDescription = new ltext(new string[] { "Template description", "Opis predloge" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_doc_Type = new ltext(new string[] { "Document type", "Vrsta dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_doc_Page_Type = new ltext(new string[] { "Format type", "Oblika strani" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_doc_TemplateLanguage = new ltext(new string[] { "Template langugage", "Jezik predloge" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_chk_Edit_PrintTemplate = new ltext(new string[] { "Edit printning template", "Urejanje predloge za tiskanje" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_HTML_PrintDocument_SaveYesNo = new ltext(new string[] { "Do you want to save new printing template ?", "Želite shraniti novo predlogo za tiskanje?" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_HTML_PrintDocument_Template_DocInvoice_Allready_Exists_SaveYesNo = new ltext(new string[] { "Name for html print document template must be unique.\r\nDo you want to change existing template ?", "Ime HTML predloge za tiskanje mora biti unikatno.\r\nŽelite spremeniti obstoječo predlogo ?" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_Print_DocInvoice = new ltext(new string[] { "Print invoice", "Natisni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_Print_DocProformaInvoice = new ltext(new string[] { "Print proforma invoice", "Natisni predračun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_btn_SaveHtmlTemplate = new ltext(new string[] { "Save Template", "Shrani predlogo" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_btn_Refresh = new ltext(new string[] { "Refresh", "Osveži" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_PageType_NotDefined = new ltext(new string[] { "Page type not defined !", "Neveljaven tip papirja !" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_PageOrientation_PORTRAIT = new ltext(new string[] { "Page orientation PORTRAIT", "POKONČNA orientacija papirja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_PageOrientation_LANDSCAPE = new ltext(new string[] { "Page orientation LANDSCAPE", "LEŽEČA orientacija papirja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_YouHaveNoDocumentTemplateFor = new ltext(new string[] { "You have no html document template for printing:\r\nYou must insert document template html into database!", "Nimate vnešenih html predlog za tiskanje na:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_Paper_A4 = new ltext(new string[] { "A4 paper format", "A4 papir" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_Paper_Roll58 = new ltext(new string[] { "58mm roll paper format", "Rolo papir širine 58 mm" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_Paper_Roll80 = new ltext(new string[] { "80mm roll paper format", "Rolo papir širine 80 mm" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext s_DocProformaInvoice = new ltext(new string[]{"Proforma-Invoice",
                                                         "Predračun"});   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext ss_Exit = new ltext(new string[] { "Exit", "	Izhod" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_PrintDocument.cs

        public static ltext sPrinterListDataChanged_Save = new ltext(new string[] { "Printer data list and settings has changed. Save new list?", "Podatki o tiskalnikih so se spremenili. Shranim podatke? " });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_DefinePrinters.cs

        public static ltext s_PrinterIsAllreadyOnTheList = new ltext(new string[] { "Printer is allready on the list", "Tiskalnik je že v seznamu za uporabo" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_DefinePrinters.cs

        public static ltext s_Add_Printer = new ltext(new string[] { "Add Printer", "Dodaj tiskalnik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_DefinePrinters.cs

        public static ltext s_Form_DefinePrinters = new ltext(new string[] { "Printer settings", "Nastavitev tiskalnikov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_DefinePrinters.cs

        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                           "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_DefinePrinters.cs

        public static ltext s_OnlyInOffer = new ltext(new string[] { "Only in offer", "Samo tiste v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_Templates.cs

        public static ltext s_AllItems = new ltext(new string[] { "All", "Vse" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_Templates.cs

        public static ltext s_OnlyNotInOffer = new ltext(new string[] { "Only those not in offer", "Samo tiste ki niso v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_Templates.cs

        public static ltext s_DataChangedSaveYourData = new ltext(new string[] { "You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_Templates.cs

        public static ltext s_Items = new ltext(new string[]{"Items",
                                                "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_Templates.cs

        public static ltext s_Form_TemplateTokens_Caption = new ltext(new string[] { "Template tokens", "Ključne spremenljvke za izdelavo predlog" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Form_TemplateTokens.cs

        public static ltext s_PrinterNotSuported = new ltext(new string[] { "Printig receipts with printer %%% is not suported:", "Z izbranim tiskalnikom %%% ni možno tiskati račune.\nIzberite drug tiskalnik." });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_journal_invoice_type_PrintError = new ltext(new string[] { "Print Error:", "Tiskanja računa NAPAKA:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_journal_invoice_type_Print = new ltext(new string[] { "Print", "Tiskanja računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_chk_PrintAll = new ltext(new string[] { "Print all at once", "Tiskaj vse naenkrat" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_PaperName = new ltext(new string[] { "Paper Name", "Vrsta papirja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_NotInPrinterList = new ltext(new string[] { " is not installed.", " ni nameščen." });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_SelectReceiptPrinter = new ltext(new string[] { "Select receipt printe", "Izbrati morate tiskalnik za tiskanje računov!" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\Printer.cs

        public static ltext s_btn_PrintingHistory = new ltext(new string[] { "Printing History", "Zgodovina Tiskanja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Invoice_Preview.cs

        public static ltext s_btn_Tokens = new ltext(new string[] { "View replacement word", "Ključne besede za izdelavo predlog" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Invoice_Preview.cs

        public static ltext sPrinterNotFound = new ltext(new string[] { "Printer not found:", "Tiskalnik ni nameščen:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_Invoices = new ltext(new string[] { "Printing invoices", "Tiskanje računov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_ProformaInvoices = new ltext(new string[] { "Printing proforma invoices", "Tiskanje pred-računov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_MothodOfPayment_Cash = new ltext(new string[] { "Cash", "Gotovina" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_MothodOfPayment_Card = new ltext(new string[] { "Card", "Kartica" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_MothodOfPayment_BankAccount = new ltext(new string[] { "Bank Account", "Plačilo na bančni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_MothodOfPayment = new ltext(new string[] { "Method of payment", "Način plačila" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Printning_Reports = new ltext(new string[] { "Printing reports", "Tiskanje izpiskov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Invoices = new ltext(new string[]{"Invoices",
                                                  "Računi"});   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_Remove = new ltext(new string[] { "Remove", "Odstrani" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_Printer.cs

        public static ltext s_FirstNameOfPersonThatPrintedInvoice = new ltext(new string[] { "First Name of person who printed invoice", "Ime osebe, ki je natisnila račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_PrintExistingInvoice.cs

        public static ltext s_LastNameOfPersonThatPrintedInvoice = new ltext(new string[] { "Last Name of person who printed invoice", "Priimek osebe, ki je natisnila račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_PrintExistingInvoice.cs

        public static ltext s_Journal_Invoice = new ltext(new string[] { "Journal for invoice", "Dnevnik računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_PrintExistingInvoice.cs

        public static ltext s_Journal_ProformaInvoice = new ltext(new string[] { "Journal for Proforma-invoice", "Dnevnik predračuna ali ponudbe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_PrintExistingInvoice.cs

        public static ltext s_Print = new ltext(new string[] { "Print", "Tiskaj" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_PrintExistingInvoice.cs

        public static ltext s_Default = new ltext(new string[] { "Default", "Privzeto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_PaperSize = new ltext(new string[] { "Paper size", "Velikost papirja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_Template = new ltext(new string[] { "Template", "Predloga" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_SelectPrinter = new ltext(new string[] { "Select printer", "Izberi tiskalnik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_Language = new ltext(new string[]{"Language",
                                                   "Jezik"});   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_Description = new ltext(new string[] { "Description", "opis" });   // referenced in C:\Tangenta40\TANGENTA\TangentaPrint\usrc_SelectPrintTemplate.cs

        public static ltext s_DocInvoice = new ltext(new string[]{"Invoice",
                                                 "Račun" });
    }
}
