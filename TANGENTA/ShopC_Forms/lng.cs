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

namespace ShopC_Forms
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }



        public static ltext s_Form_WriteOff_AddOn = new ltext(new string[] { "Write off data", "Podatki o odpisu" });

        public static ltext s_btn_New_Empty_OwnUse = new ltext(new string[] { "New own useconsumption", "Nova lastna poraba" });

        public static ltext s_btn_New_Empty_WriteOff = new ltext(new string[] { "New write off ", "Nov odpis zalog" });

        public static ltext s_New_Consumption = new ltext(new string[] { "Take out from stock", "Ostali odvzem iz zaloge" });
        
        public static ltext s_Total = new ltext(new string[] { "TOTAL", "SKUPAJ" });

        public static ltext s_WriteOff = new ltext(new string[] { "Write off", "Odpis" });
        public static ltext s_OwnUse = new ltext(new string[] { "Own consumption", "Lastna poraba" });
        public static ltext s_AllConsumption = new ltext(new string[] { "All consumption", "Vsa poraba" });

        public static ltext s_Group1 = new ltext(new string[] { "Group 1", "Skupina 1" });
        public static ltext s_Group2 = new ltext(new string[] { "Group 2", "Skupina 2" });
        public static ltext s_Group3 = new ltext(new string[] { "Group 3", "Skupina 3" });

        public static ltext s_Are_Sure_To_Remove_All_From_Basket = new ltext(new string[] { "Are you sure to remove all items from basket ?", "Ste prepričani, da želite prestaviti vse artikle nazaj iz košare?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtomsList.cs

        public static ltext s_StornoConsumption = new ltext(new string[] { "STORNO", "Stornacija porabe" });

        public static ltext s_VODxml_export_for = new ltext(new string[] { "VOD xml export for period", "Izvoz faktur v VOD XML datoteko za obdobje od" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Issue = new ltext(new string[] { "Issue", "Izdaj" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocumentMan.cs

        public static ltext s_Print = new ltext(new string[] { "Print", "Natisni" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocumentMan.cs

        public static ltext s_AreYouSureToStornoThisConsumption = new ltext(new string[] { "Are you sure to Storno this consumption?", "Ali zares želite stornirati porabo ?" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        public static ltext s_Consumption = new ltext(new string[] { "Consumption", "Poraba" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocumentMan.cs

        public static ltext s_Year = new ltext(new string[] { "Year", "Leto" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocumentMan.cs

        public static ltext s_XML_files_Saved_OK = new ltext(new string[] { " are saved ok.", " sta uspešno zapisani." });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

        public static ltext s_XML_Files = new ltext(new string[] { "XML files:", "Datoteki za XML:" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

        public static ltext s_HasNoDecimalPlaces = new ltext(new string[] { "has no decimal places.", "nima decimalnih mest." });

        public static ltext s_Tax = new ltext(new string[] { "Taxation", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_ThereAreNotsoManyArticlesInStock = new ltext(new string[] { "There is not such quantity in stock", "Na zalogi ni tolikšne količine artikla" });

        public static ltext sYouSetAllQuantitiesToZeroDoYouwantToRemoveItem = new ltext(new string[] { "You set all quantitites to zero.Do you want to remove item?", "Vse količine ste postavili na nič.Želite umakniti artikel iz košare?" });

        public static ltext s_RetailPrice = new ltext(new string[] { "Price:", "Cena:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_Error = new ltext(new string[]{"Error",
                                         "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_FilesPreview.cs

        public static ltext s_NoInvoicesData = new ltext(new string[] { "There are now invoices for DURS in selected period", "DURS Izpis za izbrano obdbobje je prazen!" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

        public static ltext s_VOD_XML_File = new ltext(new string[] { "VOD XML file:", "XML datoteka po VOD standardu:" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Err_Write_File = new ltext(new string[] { "Error writing file:", "!Prišlo je do napake pri pisanju doatoteke:" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

        public static ltext s_you_must_have_select_one_month_period_to_do_VODxml_Output = new ltext(new string[] { "There must be selectedt exactly one month period of invoices to do VOD xml ouptut!", "Izbrani računi morajo pripadati točno izbranemu celemu mesecu, da bi lahko naredili izvoz faktur v VOD XML datoteko!" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Can_not_read_VOD_shema_file_Do_you_want_to_exit = new ltext(new string[] { "Can not read VOD shema file %%SHEMAFILE.You can not export VOD XML file unless shema file is defined!\r\nDo you want to exit?", "Napaka pri branju VOD shema datoteke %%SHEMAFILE.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_YouDidnot_select_VOD_shema_file_Do_you_want_to_exit = new ltext(new string[] { "You didn't select VOD shema file.You can not export VOD XML file unless shema file is defined!\r\n Do you want to exit?", "Niste izbrali VOD shema datoteke.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_VOD_Head = new ltext(new string[] { "HEAD", "GLAVA" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Konto_Price_with_tax_for_cash = new ltext(new string[] { "Price with tax (CASH) Konto=", "Znesek z DDV (gotovina) Konto=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Konto_Price_with_tax_for_payment_cards = new ltext(new string[] { "Price with tax (CARDS) Konto=", "Znesek z DDV (kartice) Konto=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Konto_Net_price = new ltext(new string[] { "Net price Konto=", "Neto cena Konto=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Konto_VAT_general_rate = new ltext(new string[] { "VAT Konto=", "DDV splošna stopnja Konto=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_View = new ltext(new string[]{"View",
                                                "Prikaz"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

        public static ltext s_End_Customers_Code = new ltext(new string[] { "End Customers code=", "Končni kupci Šifra=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_End_Customes_Name = new ltext(new string[] { "End Customers name=", "Končni kupci naziv=" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Export_to_VOD_XML = new ltext(new string[] { "OPAL VOD XML export", "Izvoz v OPAL VOD XML" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Folder = new ltext(new string[]{" Folder ",
                                                " Mapa "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

        public static ltext s_Save = new ltext(new string[]{"Save",
                                               "Shrani"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

        public static ltext s_VOD_xml_shema_file_path = new ltext(new string[] { "OPAL VOD XSD shema file", "OPAL VOD XML shema:" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_VODxml_OPAL_export = new ltext(new string[] { "VOD XML OPAL export", "Izpis XML VOD OPAL" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PrintReport.cs

        public static ltext s_XML_export = new ltext(new string[] { "XML export", "Izpisi XML" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PrintReport.cs

        public static ltext s_SaveAsTextFile = new ltext(new string[] { "Save as text file", "Shrani v tekstovno datoteko" });

        public static ltext s_Details = new ltext(new string[] { "Details", "Podrobnosti" });

        public static ltext s_ShowAll = new ltext(new string[] { "Show all", "Prikaži vse" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_to = new ltext(new string[] { "to", "do" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext ss_From = new ltext(new string[] { "from", "od" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext ss_OK = new ltext(new string[] { "OK", " Potrdi" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext ss_To = new ltext(new string[] { "to", "do" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs


        public static ltext s_ForDay = new ltext(new string[] { "For day", "Za dan" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_TimeSpan = new ltext(new string[] { "Time span", "Obdobje" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_Today = new ltext(new string[] { "Today", "Danes" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_ThisWeek = new ltext(new string[] { "This week", "Ta teden" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_LastWeek = new ltext(new string[] { "Last week", "Prejšni teden" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_ThisMonth = new ltext(new string[] { "This month", "Ta mesec" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_LastMonth = new ltext(new string[] { "Last month", "Prejšni mesec" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_ThisYear = new ltext(new string[] { "This year", "To leto" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_LastYear = new ltext(new string[] { "Last Year", "Prejšne leto" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs


        public static ltext s_all = new ltext(new string[] { "all", "vse" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_SelectTimeSpan = new ltext(new string[] { "Select time span", "Izberi obdobje" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_StornoReason = new ltext(new string[] { "Storno reason", "Razlog stornacije" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_IssueDate = new ltext(new string[] { "Issue date", "Čas izdaje" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_lbl_SelectionDescription_AllProformaInvoices = new ltext(new string[] { "Proforma from all", "Pedračuni os vseh" });


        public static ltext s_lbl_SelectionDescription_AllInvoices = new ltext(new string[] { "Invoices from all", "Računi od vseh" });


        public static ltext s_lbl_SelectionDescription_AllInvoicesOfUser = new ltext(new string[] { "User:", "Uporabnik:" });

        public static ltext s_from = new ltext(new string[] { "from", "od" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

        public static ltext s_Sum_WithoutTax = new ltext(new string[] { "Net price = ", "Brez davka = " });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_Sum_Tax = new ltext(new string[] { "Tax = ", "Davek = " });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_Sum_All = new ltext(new string[] { "Total = ", "Skupaj = " });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

        public static ltext s_AllData = new ltext(new string[] { "All Data", "Vsi podatki" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

        public static ltext s_Consumption_Issue = new ltext(new string[] { "Issue an consumption", "Izdaj porabo" });   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs


        public static ltext s_OwnUse_Data = new ltext(new string[] { "Own Use Data", "Podatki o lastni porabi" });   // referenced in C:\Tangenta40\TANGENTA\ShopC_Forms\Form_Consumption__AddOn.cs

        public static ltext s_AvoidStock = new ltext(new string[] { "Not from stock", "Mimo zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_FromStock = new ltext(new string[] { "From stock", "Iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC_Forms\Form_Select_Item_From_Stock.cs

        public static ltext s_Item_Not_In_Offer = new ltext(new string[] { "Item is not in offer any more!", "Artikel ni več v ponudbi!" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        public static ltext s_STORNO = new ltext(new string[] { "REVERSE", "STORNO" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_WriteOff = new ltext(new string[] { "Write off", "Odpis" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_OwnUse = new ltext(new string[] { "Own use", "Lastna poraba" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDB\InvoiceData.cs

        public static ltext st_IssuerOfConsumption = new ltext(new string[] { "IssuerOfConsumption", "OsebaKiJeIzdalaPorabo" });   // referenced in C:\Tangenta40\TANGENTA\ShopC_Forms\ConsumptionData.cs

        public static ltext st_My = new ltext(new string[] { "My", "Moja" });   // referenced in C:\Tangenta40\TANGENTA\ShopC_Forms\ConsumptionData.cs

        public static ltext s_Shop_C = new ltext(new string[] { "Shop C", "Prodajalna C" });

        public static ltext s_YouCanNotWriteInvoices_CasshierIsClosed = new ltext(new string[] { "You can not write invoices. Cashier is closed!", "Kadar je blagajna zaprta ni možno pisati in izdajati računov!" });

        public static ltext s_IssueDate_not_defined = new ltext(new string[] { "Issue date not defined", "Čas izdaje ni določen" });
        public static ltext s_PriceValueOfStock = new ltext(new string[] { "Stock price value", "Vrednost zaloge" });
        public static ltext s_Unit_DecimalPlaces = new ltext(new string[] { "Unit decimal places", "Število decimalnih mest merska enote" });
        public static ltext s_Unit_Symbol = new ltext(new string[] { "Unit symbol", "Merska enota simbol" });
        public static ltext s_Unit_Name = new ltext(new string[] { "Unit name", "Merska enota" });
        public static ltext s_StockChangeQuantity = new ltext(new string[] { "Change of quantity in stock", "Sprememba količine na zalogi" });
        public static ltext s_NewQuantityInStock = new ltext(new string[] { "NEW Quantity in stock", "Nova količina na zalogi" });
        public static ltext s_Item_UniqueName = new ltext(new string[] { "Item UNIQUE Name", "Unikatno ime artikla" });
        public static ltext s_QuantityInStock = new ltext(new string[] { "Quantity in stock", "Količina na zalogi" });
        public static ltext s_lbl_StockOfItem = new ltext(new string[] { "An inventory of an item in stocks, item", "Inventura artikla v zalogah, artikel" });
        public static ltext s_InventoryOfStock = new ltext(new string[] { "An inventory of stocks", "Inventura zalog" });

        public static ltext s_lbl_StockItems = new ltext(new string[] { "Stock items", "Zaloga artiklov" });

        public static ltext s_StockTakePriceWithoutVAT = new ltext(new string[] { "Stock-Take price without VAT", "Cena prevzemnice brez DDV" });

        public static ltext s_StockTakePriceWithVAT = new ltext(new string[] { "Stock-Take price with VAT", "Cena prevzemnice z DDV" });

        public static ltext s_CannotConvertToDecimal = new ltext(new string[] { "Can not convert to decimal", "Pretvorba v decimalno število ni uspela" });

        //public static ltext sYouSetAllQuantitiesToZeroDoYouwantToRemoveItem = new ltext(new string[] { "You set all quantitites to zero.Do you want to remove item?", "Vse količine ste postavili na nič.Želite umakniti artikel iz košare?" });

        //public static ltext s_ThereAreNotsoManyArticlesInStock = new ltext(new string[] { "There is not such quantity in stock", "Na zalogi ni tolikšne količine artikla" });

        //public static ltext s_StornoInvoice = new ltext(new string[] { "STORNO", "Stornacija računa" });

        public static ltext s_PriceTotalWithDiscountWithoutVAT = new ltext(new string[] { "Net total with discunt", "Skupaj s popustom brez DDV" });

        public static ltext s_PriceTotalWithDiscountWithVAT = new ltext(new string[] { "Total with discount", "Skupaj s popustom z DDV" });

        public static ltext s_lbl_Total = new ltext(new string[] { "Total", "Skupaj" });
        public static ltext s_chk_VAT_is_deducted = new ltext(new string[] { "VAT can be deducted", "DDV smemo odbiti" });

        public static ltext s_lbl_Discount = new ltext(new string[] { "Discount", "Popust" });



        public static ltext s_lbl_PriceWithoutVAT = new ltext(new string[] { "Price without VAT", "Cena brez DDV" });
        public static ltext s_lbl_PriceWithVAT = new ltext(new string[] { "Price with VAT", "Cena z DDV" });

        public static ltext s_CtrlColor_ItemFromFactory = new ltext(new string[] { "Item from factory colors", "Barvi artikla, ki ni v zalogi" });
        public static ltext s_CtrlColor_ItemFromProduction = new ltext(new string[] { "Item from stock colors", "Barvi artikla iz zaloge" });

        public static ltext s_CtrlColor_ShopC = new ltext(new string[] { "Shop C colors", "Barvi prodajalne C" });

        public static ltext s_Stock_ImportTime = new ltext(new string[] { "Stock Import Time", "Čas vnosa v zalogo" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_Stock_ExpiryDate = new ltext(new string[] { "Stock expiry date", "Rok uporabe v zalogi" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_StockTake_Name = new ltext(new string[] { "Stock Take name Import Time", "Ime prevzemnice" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_StockTakeDate = new ltext(new string[] { "StockTake Date","Čas prevzema v zalogo" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_StockTakePriceTotal = new ltext(new string[] { "StockTake Price Total", "Skupna cena prevzemnice" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_StockTake_ReferenceNote = new ltext(new string[] { "Reference document", "Sklic na dokument" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Organisation_Name = new ltext(new string[] { "Supplier Org. Name", "Ime dobavitelja" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Organisation_Tax_ID = new ltext(new string[] { "Supplier Org. TaxID", "Davčna št. Dobavitelja" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Organisation_PhoneNumber = new ltext(new string[] { "Supplier Org. Phone Number", "Dobavitelj (org.) Telefon" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Organisation_Email = new ltext(new string[] { "Supplier Org. Emial", "Dobavitelj (org.) Email" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Organisation_HomePage = new ltext(new string[] { "Supplier Org. HomePage", "Dobavitelj (org.) Domača Stran" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Person_First_Name = new ltext(new string[] { "Supplier  Contact Person First Name", "Kontaktna oseba dobavitelja Ime" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Person_Last_Name = new ltext(new string[] { "Supplier  Contact Person Last Name", "Kontaktna oseba dobavitelja Priimek" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Person_GsmNumber = new ltext(new string[] { "Supplier  Contact Person Mobile number", "Kontaktna oseba dobavitelja Mobilni telefon številka" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Person_PhoneNumber = new ltext(new string[] { "Supplier  Contact Person Phone number", "Kontaktna oseba dobavitelja telefon številka" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs
        public static ltext s_Supplier_Person_Email = new ltext(new string[] { "Supplier  Contact Person Email", "Kontaktna oseba dobavitelja Email" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs


        public static ltext s_ItemGroups = new ltext(new string[] { "Item groups", "Skupine Artiklov" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ItemGroups_Edit.cs

        public static ltext s_YourSelectedQuantityIsNotEqualTo = new ltext(new string[] { "Selected quantity is not equal to requested quantity!", "Izbrana količina ni enaka zahtevani količini! " });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_SelectedQuantity = new ltext(new string[] { "Selected quantity", "Izbrana količina" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_Form_SelectItemFromStock = new ltext(new string[] { "Select Items from stock", "Izberi artikel iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_StockTakeName = new ltext(new string[] { "Stock take name", "Ime prevzemnice" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_QuantityTakenFromStock = new ltext(new string[] { "Quantity taken from stock", "Količina vzeta iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        //public static ltext s_FromStock = new ltext(new string[] { "From stock", "Iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs
        //public static ltext s_AvoidStock = new ltext(new string[] { "Not from stock", "Mimo zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_Supplier = new ltext(new string[] { "Supplier", "Dobavitelj" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_ImportTime = new ltext(new string[]{"Item Stock Import time",
                                                    "Čas vnosa artikla v zalogo"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_ExpiryDate = new ltext(new string[]{"Expirx date",
                                                   "Rok uporabe"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs
        
        public static ltext s_Quantity = new ltext(new string[]{"Quantity:",
                                                   "Količina:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_Select = new ltext(new string[]{"Select",
                                                 "Izberi"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_OK = new ltext(new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_Warning = new ltext(new string[]{"Warning",
                                           "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        //public static ltext s_Cancel = new ltext(new string[]{"Cancel",
        //                                  "Prekini"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

        public static ltext s_ShopC_Name = new ltext(new string[] { "Shop C", "Prodajalna C" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_OnlyInOffer = new ltext(new string[] { "Only in offer", "Samo tiste v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_AllItems = new ltext(new string[] { "All", "Vse" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_OnlyNotInOffer = new ltext(new string[] { "Only those not in offer", "Samo tiste ki niso v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_DataChangedSaveYourData = new ltext(new string[] { "You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_DataChangedDoYouWantToCloseYesNo = new ltext(new string[] { "You have changed data. Do you want to cancel edit?", "Vnesli ste podatke.\r\nŽelite prekiniti vnos?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_Items = new ltext(new string[]{"Items",
                                                "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_ShopC_Item_Edit.cs

        public static ltext s_Select_StockEdit_Type = new ltext(new string[] { "Select stock edit type", "Izberite način urejanja zalog" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_SelectStockEditType.cs

        public static ltext s_btn_EditItemsInStock = new ltext(new string[] { "Edit stock by items in stok", "Urejanje zalog po artiklih" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_SelectStockEditType.cs

        public static ltext s_EditStockTakeItems = new ltext(new string[] { "Edit stock take items", "Urejanje zalog po prevzemnicah" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_SelectStockEditType.cs

        public static ltext s_Addressee = new ltext(new string[] { "Adresse", "Naslovnik" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_ItemUniqueName = new ltext(new string[] { "Item unique name", "Unikatno ime artikla" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs


        public static ltext s_Document_Type = new ltext(new string[] { "Document Type", "Vrsta dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_DraftNumber = new ltext(new string[] { "Draft number", "Številka onsutka" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_Form_Show_Documents_Where_stock_item_was_sold_or_reserved = new ltext(new string[] { "Invoices and ProformaInvoices of stock item", "Računi in predračuni kamor je bil prodan ali rezerviran artikel iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_FinancialYear = new ltext(new string[] { "Financial Year", "Poslovno leto" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_NumberInFinancialYear = new ltext(new string[] { "Number in financial year", "Številka v obračunskem letu" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_Draft = new ltext(new string[] { "Draft", "Osnutek" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_DocProformaInvoice = new ltext(new string[]{"Proforma-Invoice",
                                                         "Predračun"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Show_Documents_Where_stock_item_was_sold_or_reserved.cs

        public static ltext s_YouHaveEnteredOrChangedDataButNotSavedThem_Save_YesNo = new ltext(new string[] { "You have entered or changed data but not saved them.\r\nSave data ?", "Vnesli ali spremenili ste podatke a niste jih shranili.\r\nShranim podatke ?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockItem_Edit.cs

        public static ltext s_lbl_Item_Stock = new ltext(new string[] { "Stocks for item:", "Zaloge artikla:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockItem_Edit.cs

        public static ltext s_Stock = new ltext(new string[]{"Stock",
                                                "Zaloge"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockItem_Edit.cs

        public static ltext s_StockShort = new ltext(new string[]{"Stock",
                                                "Zaloga"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockItem_Edit.cs

        public static ltext s_btn_Remove = new ltext(new string[] { "Remove row", "Zbriši vrstico" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_lbl_Description = new ltext(new string[] { "Description", "Opis" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_lbl_Cost = new ltext(new string[] { "Price", "Cena" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_lbl_StocTakeCostName = new ltext(new string[] { "Cost Name", "Ime stroška" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_AddtionalCost_for_StockTake = new ltext(new string[] { "Additional cost for stock take", "Dodatni stroški za prevzemnico" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_CostDescription = new ltext(new string[] { "Cost description", "Opis stroška" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_CostPrice = new ltext(new string[] { "Cost price", "Cena stroška" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_CostName = new ltext(new string[] { "Cost name", "Ime stroška" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_StockTake_Cost_Name_must_be_defined = new ltext(new string[] { "Cost Name must be defined!\r\nEnter the name of the cost!", "Ime stroška ni določen!\r\nVpišite ime stroška." });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_Update = new ltext(new string[] { "Update", "Popravi" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_StockTake_AdditionalCost_Edit.cs

        public static ltext s_StockAddresss = new ltext(new string[] { "Stock address", "Lokacija skladiščenja" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Stock_Address_Edit.cs

        public static ltext s_StockAddressTableHasNoData_YouMustEnterData_close_anyway = new ltext(new string[] { "Stock Address has no data!\r\nDo you realy want to cancel? ", "Manjka vsaj ena loakcija skladišča.\r\nVnesti morate vsaj eno lokacijo skladišča!Želite kljub temu zapustiti dialog?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Stock_Address_Edit.cs

        public static ltext s_ExpiryDateFormText = new ltext(new string[] { "Expiry Date", "Rok uporabe" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Stock_AvoidStock_Edit.cs

        public static ltext s_PleaseDefineExpiryDateForItem = new ltext(new string[] { "Define Expiry Date for Item", "Določite rok uporabe artiklu" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Stock_AvoidStock_Edit.cs

        public static ltext s_YouCanNotEditItemsUntilAllBasketsAreEmpty = new ltext(new string[] { "You can not edit items as long you have items in baskets!", "Najprej spraznite vse košare, da bi lahko urejali artikle !" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_Item.cs

        public static ltext s_YouCanNotEditStockUntilAllBasketsAreEmpty = new ltext(new string[] { "You can not edit stock as long you have items in baskets!", "Najprej spraznite vse košare, da bi lahko urejali zaloge !" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_Item.cs

        //public static ltext s_RetailPriceWithDiscount = new ltext(new string[] { "Price with discount:", "Cena s popustom:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        //public static ltext s_RetailPrice = new ltext(new string[] { "Price:", "Cena:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        //public static ltext s_TaxPrice = new ltext(new string[]{"Tax:",
        //                                           "Davek:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        //public static ltext s_WithoutTaxPrice = new ltext(new string[]{"Without tax:",
        //                                                  "Cena brez davka:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        //public static ltext s_Discount = new ltext(new string[]{"Discount:",
        //                                           "Popust:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        //public static ltext s_Are_Sure_To_Remove_All_From_Basket = new ltext(new string[] { "Are you sure to remove all items from basket ?", "Ste prepričani, da želite prestaviti vse artikle nazaj iz košare?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtomsList.cs

        public static ltext s_Stock_ID = new ltext(new string[]{"Stock ID",
                                                   "ID v Zalogah"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_Stock_dQuantity = new ltext(new string[]{"Stock quantity",
                                                          "Kol. v skladišču"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_RetailPricePerUnit = new ltext(new string[]{"Retail price per unit",
                                                                "Prodajna cena na enoto"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePricePerUnitDiscount = new ltext(new string[]{"Purchase price per unit Discount",
                                                                "Nabavna cena na enoto Popust"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        

        public static ltext s_PurchasePriceWithoutVAT = new ltext(new string[]{"Price without VAT unit",
                                                                "Cena je brez davka"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePricePerUnitWithDiscount = new ltext(new string[]{"Purchase price with discount",
                                                                "Nabavna cena s popustom"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePricePerUnit = new ltext(new string[]{"Purchase price per unit",
                                                                "Nabavna cena na enoto"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchaseDiscount = new ltext(new string[]{"Purchase icount",
                                                                "Pubust pri nabavna ceni"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs


        public static ltext s_PurchasePriceDate = new ltext(new string[]{"Purchase price date",
                                                                         "Datum nabavne cene"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        //public static ltext s_Item_Not_In_Offer = new ltext(new string[] { "Item is not in offer any more!", "Artikel ni več v ponudbi!" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        //public static ltext s_NotEnoughItemsInStock_DoIgnoreStockQuestion = new ltext(new string[] { "There is not enough items in stock!\r\nInsert items ignoring stock (Yes/No)?", "Ni dovolj artikla (artiklov) v zalogah!\r\nVnesi artikel mimo skladišča (Da/Ne)?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        //public static ltext s_AutomaticSelectionOfItemFromStock = new ltext(new string[] { "Automatic selection of item from stock", "Samodejno izberi artikel iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        //public static ltext s_lbl_Items = new ltext(new string[] { "Items", "Artikli" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        //public static ltext s_lbl_Stock = new ltext(new string[] { "Stock", "Zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs


        public static ltext s_YouCanNotLock_StockTakeIfSumNotMatch = new ltext(new string[]{"You can not close stock take unless the sum of all item's prices plus additional costs plus trucking costs plus customs is equal the StockTakeTotalPrice!",
                                                                                "Prevzemnice ni možno zapreti, v kolikor vsota cen artiklov plus transportinh stroškov plus carine plus dodatnih stroškov ni enaka celotni ceni prevzemnice!"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_ItemIsNotDefined = new ltext(new string[] { "Item is not defined!\r\nSelect item first.", "Artikel ni izbran!\r\nNajprej izberite artikel." });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_PurchasePriceIsZeroAreYouSure = new ltext(new string[]{"Purchase price per unit is zero!\r\nAre you shure to write zero purchase item price?"
                                                                            , "Nabavna cena za artikel je nič!\r\nSte prepričani "});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_PurchasePricePerUnitIsNotDefined = new ltext(new string[]{"Purchase price per unit is not defined or is not a decimal naumber!\r\nEnter purchase price per unit."
                                                                            ,"Nabavna cena ni vpisana ali pa je vpisana z napako!\r\nVpišite Nabavno ceno na artikel."});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_dQuantityEqualsZero_InsertItemInStock = new ltext(new string[] { "Quantity is 0 !\r\n Insert item in stock any way?", "Količina je 0 !\r\nVpišem količino nič v zalogo za izbrani artikel?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_TruckingOrganisation = new ltext(new string[] { "Trucking organisation", "Transportna družba" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        //public static ltext s_lbl_StockTakeTotalPriceWithoutTax = new ltext(new string[] { "Total net price", "Cena brez DDV" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_lbl_Difference = new ltext(new string[] { "Difference:", "Razlika:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_btn_AdditionalCost = new ltext(new string[] { "Additional Cost", "Dodatni Stroški" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_lbl_StockTakeName = new ltext(new string[] { "Stock-Take:", "Prevzemnica:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_AreYouSureToLock_StockTake = new ltext(new string[] { "Are you sure to lock Stock-Take", "Ste prepričani, da zaklenete prevzemnico?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_btn_CloseStockTake = new ltext(new string[] { "Close Stock-Take", "Zapri prevzemnico" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_InvalidDiscount = new ltext(new string[] { "Discount is not valid\r\nError:Can not convert to decimal velue!", "Popust ni veljaven.\r\nNapaka:Neupešna pretvorba v decimalno število!" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs
        
        public static ltext s_InvalidPurchasePrice = new ltext(new string[] { "Purchase price is not valid\r\nError:Can not convert to decimal velue!", "Nabavna cena ni veljavna.\r\nNapaka:Neupešna pretvorba v decimalno število!" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Stock_Description = new ltext(new string[] { "Stock description", "Opis zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_SelectedItem = new ltext(new string[] { "Select Item", "Izberite Artikel" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Currency = new ltext(new string[] { "Currency", "Valuta" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_UniqueName = new ltext(new string[] { "Unique name", "Unikatno ime" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Taxation = new ltext(new string[] { "Taxation", "Davki" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        //public static ltext s_Tax = new ltext(new string[] { "Taxation", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Item = new ltext(new string[] { "Item", "Artikel" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs


        public static ltext s_Stock_dInitialQuantity = new ltext(new string[]{"Stock take quantity",
                                                                  "Kol. prevzeta"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Add = new ltext(new string[] { "Add", "Dodaj" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Remove = new ltext(new string[] { "Remove", "Odstrani" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_EditStockTake = new ltext(new string[] { "Edit stock-take", "Urejanje prevzemnic" });

        public static ltext s_DocInvoice = new ltext(new string[] { "Invoice",
                                                 "Račun" });

        //public static ltext s_HasNoDecimalPlaces = new ltext(new string[] { "has no decimal places.", "nima decimalnih mest." });


        public static ltext s_Unit = new ltext(new string[] { "Unit", "Merska enota" });

        public static ltext s_DecimalPlaces = new ltext(new string[] { "Decimal places", "Decimalna mesta" });

        public static ltext s_lbl_TruckingCustosPlusAddtional = new ltext(new string[] { "Price for Trucking,Customs,Additional Cost:", "Dodatni stroski (carina,transport..):" });

        public static ltext s_lbl_TotalTax = new ltext(new string[] { "VAT:", "DDV:" });

        public static ltext s_PurchasePricesNotDefinedYeet = new ltext(new string[] { "Purchase price has never bin defined before", "Nabavna cena še nikoli ni bila določena" });
        public static ltext s_PurchasePricesInThePast = new ltext(new string[] { "Purchase prices in the past", "Nabavne cene v preteklosti" });

    }
}
