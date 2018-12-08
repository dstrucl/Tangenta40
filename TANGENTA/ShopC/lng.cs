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

namespace ShopC
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


        public static ltext s_CannotConvertToDecimal = new ltext(new string[] { "Can not convert to decimal", "Pretvorba v decimalno število ni uspela" });

        public static ltext sYouSetAllQuantitiesToZeroDoYouwantToRemoveItem = new ltext(new string[] { "You set all quantitites to zero.Do you want to remove item?", "Vse količine ste postavili na nič.Želite umakniti artikel iz košare?" });

        public static ltext s_ThereAreNotsoManyArticlesInStock = new ltext(new string[] { "There is not such quantity in stock", "Na zalogi ni tolikšne količine artikla" });

        public static ltext s_StornoInvoice = new ltext(new string[] { "STORNO", "Stornacija računa" });

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

        public static ltext s_FromStock = new ltext(new string[] { "From stock", "Iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs
        public static ltext s_AvoidStock = new ltext(new string[] { "Not from stock", "Mimo zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

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

        public static ltext s_Cancel = new ltext(new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\Form_Select_Item_From_Stock.cs

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

        public static ltext s_RetailPriceWithDiscount = new ltext(new string[] { "Price with discount:", "Cena s popustom:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_RetailPrice = new ltext(new string[] { "Price:", "Cena:" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_TaxPrice = new ltext(new string[]{"Tax:",
                                                   "Davek:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_WithoutTaxPrice = new ltext(new string[]{"Without tax:",
                                                          "Cena brez davka:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_Discount = new ltext(new string[]{"Discount:",
                                                   "Popust:"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom.cs

        public static ltext s_Are_Sure_To_Remove_All_From_Basket = new ltext(new string[] { "Are you sure to remove all items from basket ?", "Ste prepričani, da želite prestaviti vse artikle nazaj iz košare?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtomsList.cs

        public static ltext s_Stock_ID = new ltext(new string[]{"Stock ID",
                                                   "ID v Zalogah"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_Stock_dQuantity = new ltext(new string[]{"Stock quantity",
                                                          "Kol. v skladišču"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_RetailPricePerUnit = new ltext(new string[]{"Retail price per unit",
                                                                "Prodajna cena na enoto"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePricePerUnitDiscount = new ltext(new string[]{"Purchase price per unit Discount",
                                                                "Nabavna cena na enoto Popust"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePricePerUnit = new ltext(new string[]{"Purchase price per unit",
                                                                "Nabavna cena na enoto"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_PurchasePriceDate = new ltext(new string[]{"Purchase price date",
                                                                         "Datum nabavne cene"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ItemAtom_View.cs

        public static ltext s_Item_Not_In_Offer = new ltext(new string[] { "Item is not in offer any more!", "Artikel ni več v ponudbi!" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        public static ltext s_NotEnoughItemsInStock_DoIgnoreStockQuestion = new ltext(new string[] { "There is not enough items in stock!\r\nInsert items ignoring stock (Yes/No)?", "Ni dovolj artikla (artiklov) v zalogah!\r\nVnesi artikel mimo skladišča (Da/Ne)?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        public static ltext s_AutomaticSelectionOfItemFromStock = new ltext(new string[] { "Automatic selection of item from stock", "Samodejno izberi artikel iz zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        public static ltext s_lbl_Items = new ltext(new string[] { "Items", "Artikli" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs

        public static ltext s_lbl_Stock = new ltext(new string[] { "Stock", "Zaloge" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_ShopC.cs


        public static ltext s_YouCanNotLock_StockTakeIfSumNotMatch = new ltext(new string[]{"You can not close stock take unless the sum of all item's prices plus additional costs plus trucking costs plus customs is equal the StockTakeTotalPrice!",
                                                                                "Prevzemnice ni možno zapreti, v kolikor vsota cen artiklov plus transportinh stroškov plus carine plus dodatnih stroškov ni enaka celotni ceni prevzemnice!"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_ItemIsNotDefined = new ltext(new string[] { "Item is not defined!\r\nSelect item first.", "Artikel ni izbran!\r\nNajprej izberite artikel." });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_PurchasePriceIsZeroAreYouSure = new ltext(new string[]{"Purchase price per unit is zero!\r\nAre you shure to write zero purchase item price?"
                                                                            , "Nabavna cena za artikel je nič!\r\nSte prepričani "});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_PurchasePricePerUnitIsNotDefined = new ltext(new string[]{"Purchase price per unit is not defined or is not a decimal naumber!\r\nEnter purchase price per unit."
                                                                            ,"Nabavna cena ni vpisana ali pa je vpisana z napako!\r\nVpišite Nabavno ceno na artikel."});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_dQuantityEqualsZero_InsertItemInStock = new ltext(new string[] { "Quantity is 0 !\r\n Insert item in stock any way?", "Količina je 0 !\r\nVpišem količino nič v zalogo za izbrani artikel?" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_TruckingOrganisation = new ltext(new string[] { "Trucking organisation", "Transportna družba" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_lbl_StockTakeTotalPriceWithoutTax = new ltext(new string[] { "Total net price", "Cena brez DDV" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

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

        public static ltext s_Tax = new ltext(new string[] { "Taxation", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Item = new ltext(new string[] { "Item", "Artikel" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs


        public static ltext s_Stock_dInitialQuantity = new ltext(new string[]{"Stock take quantity",
                                                                  "Kol. prevzeta"});   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Add = new ltext(new string[] { "Add", "Dodaj" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_Remove = new ltext(new string[] { "Remove", "Odstrani" });   // referenced in C:\Tangenta40\TANGENTA\ShopC\usrc_StockEditForSelectedStockTake.cs

        public static ltext s_EditStockTake = new ltext(new string[] { "Edit stock-take", "Urejanje prevzemnic" });

        public static ltext s_DocInvoice = new ltext(new string[] { "Invoice",
                                                 "Račun" });

        public static ltext s_HasNoDecimalPlaces = new ltext(new string[] { "has no decimal places.", "nima decimalnih mest." });


        public static ltext s_Unit = new ltext(new string[] { "Unit", "Merska enota" });

        public static ltext s_DecimalPlaces = new ltext(new string[] { "Decimal places", "Decimalna mesta" });

        public static ltext s_lbl_TruckingCustosPlusAddtional = new ltext(new string[] { "Price for Trucking,Customs,Additional Cost:", "Dodatni stroski (carina,transport..):" });

        public static ltext s_lbl_TotalTax = new ltext(new string[] { "VAT:", "DDV:" });

        public static ltext s_PurchasePricesNotDefinedYeet = new ltext(new string[] { "Purchase price has never bin defined before", "Nabavna cena še nikoli ni bila določena" });
        public static ltext s_PurchasePricesInThePast = new ltext(new string[] { "Purchase prices in the past", "Nabavne cene v preteklosti" });

    }
}
