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

namespace Tangenta
{
    public static class lng
    {
 public static ltext s_SelectNotice = new ltext( new string[]{"Select Notice", "Izber dopis"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_Notice.cs

 public static ltext s_DataBaseIsEmpty_InsertInitialData = new ltext( new string[]{"Database is empty. If you want to preview this program first, then let this program to insert imaginary initial sample data of your organisation (Organisation1) and you will change this data later to your real organisation data, than select:",
                                                                            "Baza podatkov je prazna!\r\nV kolikor si želite pred uporabo program najprej ogledati, potem je najbolje, da program samodejno vstavi začetne namišljene podatke neke splošne organizacije (Podjetje1), vi pa potem te podatke lahko kadarkoli spremenite v vaše prave podatke. Če je temu tako, potem izberite:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_CheckInsertSampleData.cs

 public static ltext s_DataBaseIsEmpty_EnterData = new ltext( new string[]{"If you want to enter your data manually than select:",
                                                                    "V kolikor želite, da sami vnesete podatke potem izberite:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_CheckInsertSampleData.cs

 public static ltext s_Write_predefined_data_into_a_new_database = new ltext( new string[]{"Write initial default data into a new database", "Napišite začetne privzete podatke v novo bazo podatkov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_CheckInsertSampleData.cs

 public static ltext s_Enter_your_data_manually = new ltext( new string[]{"Enter your data manually", "Ročni vnos podatkov v novo bazo podatkov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_CheckInsertSampleData.cs

 public static ltext s_CodeTables = new ltext( new string[]{"Code tables", "Šifranti"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_CodeTables.cs

 public static ltext s_Add_Customer_to_invoice = new ltext( new string[]{"Add customer to (proforma)invoice", "Dodaj stranko na (pred)račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_WriteOnYourAccount = new ltext( new string[]{"write on the (profroma)invoice?", "vpisati na (pred)račun ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_DoYouWantCustomer = new ltext( new string[]{"Do You want customer:", "Želite stranko:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_Yes = new ltext( new string[]{"Yes", "Da"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_No = new ltext( new string[]{"No", "Ne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_Address = new ltext( new string[]{"Address",
                                           "Naslov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_City = new ltext( new string[]{"City",
                                         "Mesto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_State = new ltext( new string[]{"State",
                                         "Dežela"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_ZIP = new ltext( new string[]{"ZIP",
                                        "Poštna Številka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_Country = new ltext( new string[]{"Country",
                                         "Država"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Assign.cs

 public static ltext s_DataBaseVersion = new ltext( new string[]{"DataBaseVersion", "Verzija podatkovne baze:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings.cs

 public static ltext s_StockCheckAtStartup = new ltext( new string[]{"Stock check at startup", "Preverjanje zalog ob zagonu programa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings.cs

 public static ltext s_MultiuserOperationWithLogin = new ltext( new string[]{"Multi user operation with login",
                                                             "Večuporabniško delovanje in prijava z geslom"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings.cs

 public static ltext s_Administrator_password = new ltext( new string[]{"Administrator password",
                                                "Skrbniško geslo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings.cs

 public static ltext s_Password_does_not_match = new ltext( new string[]{"Password does not match!",
                                                                   "Gesli se ne ujemata"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings.cs

 public static ltext s_PaymentOfProformaInvoiceAndPrint = new ltext( new string[]{"Terms of payment  and print", "Način plačila in izdaja predračuna"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocProformaInvoice_AddOn.cs

 public static ltext s_ExpiryStockCheck = new ltext( new string[]{"Expiry stock check", "Kontrola zalog"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Check.cs

 public static ltext s_ItemsWithNoExpiryData = new ltext( new string[]{"Items with no expiry data", "Artikli, ki nimajo podatka o roku uporabe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Check.cs

 public static ltext s_ItemsToSale = new ltext( new string[]{"Items to sale with discount", "Artikli, ki naj gredo v razprodajo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Check.cs

 public static ltext s_ItemsToDiscart = new ltext( new string[]{"Items to discard", "Artikli, ki naj gredo v uničenje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Check.cs

 public static ltext s_Legend = new ltext( new string[]{"Legend", "Legenda"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Check.cs

 public static ltext s_FVI_instruction = new ltext( new string[]{"Fiscal verification of invoices is obligatory in Slovenia.\r\nIf you are from any reason not obligated to do fiscal verification of invoices please uncheck the checkbox below.", "Davčno potrjevanje računov pri davčni upravi je v Sloveniji obvezno.\r\nV kolikor niste zavezanec za davčno potrjevanje računov odstranite kljukico spodaj."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_FVI_check.cs

 public static ltext s_FVI_Check = new ltext( new string[]{"Fiscal Verification of invoices", "Davčno potrjevanje računov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_FVI_check.cs

 public static ltext s_DataNotSavedEndYesNo = new ltext( new string[]{"New or changed data are not written to database.\r\nQuit (Yes/No)?", "Novi ali spremenjeni podatki se niso zapisali v bazo podatkov.\r\nKončam (Da/Ne)?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_Edit_Offices = new ltext( new string[]{"Offices of your organisation!", "Poslovne enote vaše oragnizacije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_YouMustEnterYourOrganisationData = new ltext( new string[]{"You must enter your organisation data. Without organisation data program can not run!", "Morate vpisati podatke o vaši organizaciji in vsaj eni osebi. Brez tega program ne more delovati!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_YouDidNotEnterYourOrganisationData = new ltext( new string[]{"You did not enter your organisation data. Without organisation data program can not run! Program will end? ", "Morate vpisati podatke o vaši organizaciji in vsaj eni osebi. Brez tega program ne more delovati! Program se konča ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_YouDidNotWriteDataToDB_SaveData_YesOrNo = new ltext( new string[]{"Write to Data Base.\r\n(Press Yes or No)?", "Vpišem podatke v podatkovno bazo?\r\n(Pritisni gumb Da ali Ne) ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_BankAccounts = new ltext( new string[]{"Bank Accounts", "Bančni računi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_MyOrganisation = new ltext( new string[]{"My organisation",
                                                    "Moja oragnizacija"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_Warning = new ltext( new string[]{"Warning",
                                           "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Edit.cs

 public static ltext s_Community1 = new ltext( new string[]{"C1", "KS1"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data_FVI_SLO_RealEstateBP.cs

 public static ltext s_Edit_Office_Data_FVI_SLO_RealEstateBP = new ltext( new string[]{"Office Data for FURS!", "Podatki poslovne enote potrebni za davčno potrjevanje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data_FVI_SLO_RealEstateBP.cs

 //public static ltext s_Edit_Office_Data_FVI_SLO_RealEstateBP = new ltext( new string[]{"Office Data for FURS!", "Podatki poslovne enote potrebni za davčno potrjevanje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data.cs

 public static ltext s_YouMustEnterYourOfficeAddressData = new ltext( new string[]{"You must enter your office address data. Without office address data program can not run!", "Morate vpisati podatke o naslovu poslovne enote vaše organizacije. Brez tega program ne more delovati!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data.cs

 //public static ltext s_YouDidNotWriteDataToDB_SaveData_YesOrNo = new ltext( new string[]{"Write to Data Base.\r\n(Press Yes or No)?", "Vpišem podatke v podatkovno bazo?\r\n(Pritisni gumb Da ali Ne) ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data.cs

 //public static ltext s_Warning = new ltext( new string[]{"Warning",
 //                                          "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office_Data.cs

 //public static ltext s_DataNotSavedEndYesNo = new ltext( new string[]{"New or changed data are not written to database.\r\nQuit (Yes/No)?", "Novi ali spremenjeni podatki se niso zapisali v bazo podatkov.\r\nKončam (Da/Ne)?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 public static ltext s_Edit_Office_Data = new ltext( new string[]{"Other Office Data!", "Ostali podatki poslovne enote"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 // public static ltext s_Edit_Offices = new ltext( new string[]{"Offices of your organisation!", "Poslovne enote vaše oragnizacije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 public static ltext s_YouMustEnterYourOfficeData = new ltext( new string[]{"You must enter your office data. Without office data program can not run!", "Morate vpisati podatke o vsaj eni poslovni enoti vaše organizacije in vsaj eni osebi. Brez tega program ne more delovati!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 //public static ltext s_YouDidNotWriteDataToDB_SaveData_YesOrNo = new ltext( new string[]{"Write to Data Base.\r\n(Press Yes or No)?", "Vpišem podatke v podatkovno bazo?\r\n(Pritisni gumb Da ali Ne) ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 //public static ltext s_Warning = new ltext( new string[]{"Warning",
 //                                          "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Office.cs

 public static ltext s_myOrganisation_Person_Data = new ltext( new string[]{"Organisation person data", "Podatki o osebi v organizaciji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 //public static ltext s_DataNotSavedEndYesNo = new ltext( new string[]{"New or changed data are not written to database.\r\nQuit (Yes/No)?", "Novi ali spremenjeni podatki se niso zapisali v bazo podatkov.\r\nKončam (Da/Ne)?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 //public static ltext s_Edit_Office_Data = new ltext( new string[]{"Other Office Data!", "Ostali podatki poslovne enote"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 public static ltext s_YouMustEnterYourOfficePersonData = new ltext( new string[]{"You must enter your organisation perosn data. Without at least one oragnisation person data program can not run!", "Morate vpisati podatke o vsaj eni osebi vaše organizacije. Brez tega program ne more delovati!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 public static ltext s_YouDidNotEnterYourOrganisationPersonData = new ltext( new string[]{"You did not enter your organisation person data. Without any organisation person data program can not run! Program will end? ", "Morate vpisati podatke o vsaj eni osebi v vaši organizaciji. Brez tega program ne more delovati! Program se konča ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 //public static ltext s_YouDidNotWriteDataToDB_SaveData_YesOrNo = new ltext( new string[]{"Write to Data Base.\r\n(Press Yes or No)?", "Vpišem podatke v podatkovno bazo?\r\n(Pritisni gumb Da ali Ne) ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 //public static ltext s_Warning = new ltext( new string[]{"Warning",
 //                                          "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_myOrg_Person_Edit.cs

 public static ltext s_New_Empty_Invoice = new ltext( new string[]{"New Emtpy Invoice draft", "Nov prazen osnutek računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_NewDocument.cs

 public static ltext s_New_Empty_ProformaInvoice = new ltext( new string[]{"New Emtpy Proforma-Invoice draft", "Nov prazen osnutek predračuna"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_NewDocument.cs

 public static ltext s_Total = new ltext( new string[]{"TOTAL", "SKUPAJ"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_NewDocument.cs

 public static ltext s_Draft = new ltext( new string[]{"Draft", "Osnutek"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_NewDocument.cs

 public static ltext s_VODxml_OPAL_export = new ltext( new string[]{"VOD XML OPAL export", "Izpis XML VOD OPAL"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PrintReport.cs

 public static ltext s_XML_export = new ltext( new string[]{"XML export", "Izpisi XML"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PrintReport.cs

 public static ltext s_DURS_output = new ltext( new string[]{"Tax inspection output", "DURS Izpisi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PrintReport.cs

 public static ltext s_AreYouSure_ToResetSettingsToInitialvalues = new ltext( new string[]{"Do you realy want to reset all settings to initial values?\r\nIf yes, you will lost all user settings you have defined.", "Ste prepričani, da zares želite ponastaviti nastavitve na začetno programsko vrednost?\r\nV kolikor ste, vedite, da boste izgubili vse nastavitve ki ste jih ročno vnesli."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Reset_Properties_Settings_Default.cs

 //public static ltext s_Yes = new ltext( new string[]{"Yes", "Da"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Reset_Properties_Settings_Default.cs

 //public static ltext s_No = new ltext( new string[]{"No", "Ne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Reset_Properties_Settings_Default.cs

 public static ltext s_Show_Shops = new ltext( new string[]{"Shops", "Prodajalne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_A = new ltext( new string[]{"A", "A"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_B = new ltext( new string[]{"B", "B"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_C = new ltext( new string[]{"C", "C"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_AB = new ltext( new string[]{s_Shop_A.sText(0)+"&"+ s_Shop_B.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_BC = new ltext( new string[]{s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_AC = new ltext( new string[]{s_Shop_A.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shop_ABC = new ltext( new string[]{s_Shop_A.sText(0) + "&" + s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShowShops.cs

 public static ltext s_Shops_In_Use = new ltext( new string[]{"Shops in use", "Prodajalne v uporabi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ShopsInUse.cs

 public static ltext s_SimpleItemGroups = new ltext( new string[]{"Simple Item groups", "Skupine enostavnih Artiklov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_SimpleItemGroups_Edit.cs

 public static ltext s_ItemGroups = new ltext( new string[]{"Item groups", "Skupine Artiklov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ItemGroups_Edit.cs

 public static ltext s_Logos = new ltext( new string[]{"Logos in Database ", "Logotip podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Logo_Edit.cs

 public static ltext s_Copyright_KIG = new ltext( new string[]{"This program is property of KIG d.d. All right reserved.", "Ta program je last podjetja KIG.d.d. Vse pravice so pridržane."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_StartupWindow.cs

 public static ltext s_Startup_title = new ltext( new string[]{"KIG Plates, program for production of vehichle plates", "KIG program za proizvodnjo registrskih tablic"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_StartupWindow.cs

 public static ltext s_TermsOfPayments = new ltext( new string[]{"Payment terms", "Plačilni pogoji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_TermsOfPayment_Edit.cs

 public static ltext s_TermsOfPaymentTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Terms of payment of payment has no data!\r\nDo you realy want to cancel? ", "Manjka vsaj en plačilni pogoj.\r\nVnesti morate vsaj en plačilni pogoj!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_TermsOfPayment_Edit.cs

 public static ltext s_DBSettings = new ltext( new string[]{"Settings in Database ", "Nastavitve v podatkovni bazi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings_Edit.cs

 public static ltext s_DBSettingsTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"DB Settings table has no data!\r\nDo you realy want to cancel? ", "Manjkajo nastavitve v podatkovni bazi.\r\nŽelite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DBSettings_Edit.cs

 public static ltext s_Warrantys = new ltext( new string[]{"Warranty data", "Dolžine garancijskih rokov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Warranty_Edit.cs

 public static ltext s_WarrantyTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Warranty Table has no data. You must have at least one warranty  data row!\r\nDo you realy want to cancel? ", "Tabela garancijskih rokov uporabe je prazna.\r\nVnesti morate vsaj en garancijski rok uporabe!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Warranty_Edit.cs

 public static ltext s_Expirys = new ltext( new string[]{"Expiry data", "Dolžine rokov uporabe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Edit.cs

 public static ltext s_ExpiryTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Expiry Table has no data. You must have at least one expiry data row!\r\nDo you realy want to cancel? ", "Tabela rokov uporabe je prazna.\r\nVnesti morate vsaj en rok uporabe!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Expiry_Edit.cs

 public static ltext s_WorkingPlace = new ltext( new string[]{"Working place","Delovna Mesta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_WorkingPlace_Edit.cs

 public static ltext s_WorkingPlaceTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Working Place Table has no data. You must have at least one Working Place data row!\r\nDo you realy want to cancel? ", "Tabela merskih enot je prazna.\r\nVnesti morate vsaj eno mersko enoto!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_WorkingPlace_Edit.cs

 public static ltext s_Units = new ltext( new string[]{"Units", "Enote"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Unit_Edit.cs

 public static ltext s_UnitTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Unit table has no data. You must have at least one measure unit data row!\r\nDo you realy want to cancel? ", "Tabela merskih enot je prazna.\r\nVnesti morate vsaj eno mersko enoto!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Unit_Edit.cs

 public static ltext s_Error = new ltext( new string[]{"Error",
                                         "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_FilesPreview.cs

 public static ltext s_DURS_Files = new ltext( new string[]{"Durs files:", "Datoteki za DURS:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_DURS_files_Saved_OK = new ltext( new string[]{" are saved ok.", " sta uspešno zapisani."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_Err_Write_File = new ltext( new string[]{"Error writing file:", "!Prišlo je do napake pri pisanju doatoteke:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_NoInvoicesData = new ltext( new string[]{"There are now invoices for DURS in selected period", "DURS Izpis za izbrano obdbobje je prazen!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_Save = new ltext( new string[]{"Save",
                                               "Shrani"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_View = new ltext( new string[]{"View",
                                                "Prikaz"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 //public static ltext s_Error = new ltext( new string[]{"Error",
 //                                        "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_Folder = new ltext( new string[]{" Folder ",
                                                " Mapa "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DURS_output.cs

 public static ltext s_DateOfBirth = new ltext( new string[]{"Date of Birth", "Datum rojstva"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_WriteOnYourAccount = new ltext( new string[]{"write on the (profroma)invoice?", "vpisati na (pred)račun ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_DoYouWantCustomer = new ltext( new string[]{"Do You want customer:", "Želite stranko:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_Yes = new ltext( new string[]{"Yes", "Da"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_No = new ltext( new string[]{"No", "Ne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_Address = new ltext( new string[]{"Address",
 //                                          "Naslov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_City = new ltext( new string[]{"City",
 //                                        "Mesto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_State = new ltext( new string[]{"State",
 //                                        "Dežela"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_ZIP = new ltext( new string[]{"ZIP",
 //                                       "Poštna Številka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 //public static ltext s_Country = new ltext( new string[]{"Country",
 //                                        "Država"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Assign.cs

 public static ltext s_Today = new ltext( new string[]{"Today", "Danes"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_ThisWeek = new ltext( new string[]{"This week", "Ta teden"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_LastWeek = new ltext( new string[]{"Last week", "Prejšni teden"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_ThisMonth = new ltext( new string[]{"This month", "Ta mesec"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_LastMonth = new ltext( new string[]{"Last month", "Prejšni mesec"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_ThisYear = new ltext( new string[]{"This year", "To leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_LastYear = new ltext( new string[]{"Last Year", "Prejšne leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_TimeSpan = new ltext( new string[]{"Time span", "Obdobje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_SelectTimeSpan = new ltext( new string[]{"Select time span", "Izberi obdobje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext ss_From = new ltext( new string[]{"from", "od"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext ss_OK = new ltext( new string[]{"OK"," Potrdi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext ss_To = new ltext( new string[]{"to","do"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_AllData = new ltext( new string[]{"All Data", "Vsi podatki"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_all = new ltext( new string[]{"all", "vse"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_TimeSpan.cs

 public static ltext s_SelectObligatoryWriteReasonForStorno = new ltext( new string[]{"Select existing reason to reverse invoice", "Izberite že vnešen razlog za stornacijo računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_ObligatoryWriteReasonForStorno = new ltext( new string[]{"Write new reason to reverse invoice", "Spodaj vpišite nov razlog za stornacijo računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_WriteReasonForStorno = new ltext( new string[]{"Write reason text to reverse invoice!", "Napisati morate razlog za stornacijo računa!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_Price = new ltext( new string[]{"Price", "Cena"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_Storno_Instruction = new ltext( new string[]{"To reverse Invoice select or write reason and click STORNO button", "Za stornacijo računa izberite ali napišite razlog in kliknite na gumb Storno"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_Storno = new ltext( new string[]{"Reverse Invoice", "Stornacija računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_Invoice = new ltext( new string[]{"Invoice",
                                                  "Račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_Time = new ltext( new string[]{"Time", "Čas"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Storno.cs

 public static ltext s_CurrencyTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Currency table has no data. You must have at least one currency data row!\r\nDo you realy want to cancel? ", "Tabela valut je prazna.\r\nVnesti morate vsaj eno valuto!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Currency_Edit.cs

 public static ltext s_Currency = new ltext( new string[]{"Currency", "Valuta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Currency_Edit.cs

 //public static ltext s_Error = new ltext( new string[]{"Error",
 //                                        "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_FilesPreview.cs

 public static ltext s_Konto_Price_with_tax_for_cash = new ltext( new string[]{"Price with tax (CASH) Konto=", "Znesek z DDV (gotovina) Konto="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_Konto_Price_with_tax_for_payment_cards = new ltext( new string[]{"Price with tax (CARDS) Konto=", "Znesek z DDV (kartice) Konto="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_Konto_Net_price = new ltext( new string[]{"Net price Konto=", "Neto cena Konto="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_Konto_VAT_general_rate = new ltext( new string[]{"VAT Konto=", "DDV splošna stopnja Konto="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_End_Customers_Code = new ltext( new string[]{"End Customers code=", "Končni kupci Šifra="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_End_Customes_Name = new ltext( new string[]{"End Customers name=", "Končni kupci naziv="});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_VODxml_export_for = new ltext( new string[]{"VOD xml export for period", "Izvoz faktur v VOD XML datoteko za obdobje od"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_you_can_do_VODxml_Output_just_for_past_month = new ltext( new string[]{"You can do VOD xml export just for any month in the past!", "Izvoz faktur v VOD XML datoteko lahko naredite samo za katerikoli že pretekli mesec!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_you_must_have_select_one_month_period_to_do_VODxml_Output = new ltext( new string[]{"There must be selectedt exactly one month period of invoices to do VOD xml ouptut!", "Izbrani računi morajo pripadati točno izbranemu celemu mesecu, da bi lahko naredili izvoz faktur v VOD XML datoteko!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_Can_not_read_VOD_shema_file_Do_you_want_to_exit = new ltext( new string[]{"Can not read VOD shema file %%SHEMAFILE.You can not export VOD XML file unless shema file is defined!\r\nDo you want to exit?", "Napaka pri branju VOD shema datoteke %%SHEMAFILE.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_YouDidnot_select_VOD_shema_file_Do_you_want_to_exit = new ltext( new string[]{"You didn't select VOD shema file.You can not export VOD XML file unless shema file is defined!\r\n Do you want to exit?", "Niste izbrali VOD shema datoteke.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_VOD_xml_shema_file_path = new ltext( new string[]{"OPAL VOD XSD shema file", "OPAL VOD XML shema:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_Export_to_VOD_XML = new ltext( new string[]{"OPAL VOD XML export", "Izvoz v OPAL VOD XML"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_VOD_XML_File = new ltext( new string[]{"VOD XML file:", "XML datoteka po VOD standardu:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_Err_Write_File = new ltext( new string[]{"Error writing file:", "!Prišlo je do napake pri pisanju doatoteke:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_NoInvoicesData = new ltext( new string[]{"There are now invoices for DURS in selected period", "DURS Izpis za izbrano obdbobje je prazen!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_from = new ltext( new string[]{"from", "od"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 public static ltext s_to = new ltext( new string[]{"to", "do"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_Save = new ltext( new string[]{"Save",
 //                                              "Shrani"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_View = new ltext( new string[]{"View",
 //                                               "Prikaz"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_Error = new ltext( new string[]{"Error",
 //                                        "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_Folder = new ltext( new string[]{" Folder ",
 //                                               " Mapa "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_VODxml_OPAL_output.cs

 //public static ltext s_Error = new ltext( new string[]{"Error",
 //                                        "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_FilesPreview.cs

 public static ltext s_XML_files_Saved_OK = new ltext( new string[]{" are saved ok.", " sta uspešno zapisani."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 public static ltext s_XML_Files = new ltext( new string[]{"XML files:", "Datoteki za XML:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_Err_Write_File = new ltext( new string[]{"Error writing file:", "!Prišlo je do napake pri pisanju doatoteke:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_NoInvoicesData = new ltext( new string[]{"There are now invoices for DURS in selected period", "DURS Izpis za izbrano obdbobje je prazen!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_Save = new ltext( new string[]{"Save",
 //                                              "Shrani"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_View = new ltext( new string[]{"View",
 //                                               "Prikaz"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_Error = new ltext( new string[]{"Error",
 //                                        "Napaka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 //public static ltext s_Folder = new ltext( new string[]{" Folder ",
 //                                               " Mapa "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_XML_output.cs

 public static ltext s_OrganisationAccount = new ltext( new string[]{"Organisation Bank-Accounts", "Bančni računi organizacije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationAccount_Edit.cs

 public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationAccount_Edit.cs

 public static ltext s_Items = new ltext( new string[]{"Items",
                                                "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationAccount_Edit.cs

 public static ltext s_Customers_Person = new ltext( new string[]{"Customer person", "Stranke fizične osebe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonAccount_Edit .cs

 //public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonAccount_Edit .cs

 //public static ltext s_Items = new ltext( new string[]{"Items",
 //                                               "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonAccount_Edit .cs

 public static ltext s_OrganisationData = new ltext( new string[]{"Organisation data", "Razširjeni podatki organizacije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationData_Edi .cs

 //public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationData_Edi .cs

 //public static ltext s_Items = new ltext( new string[]{"Items",
 //                                               "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_OrganisationData_Edi .cs

 //public static ltext s_Customers_Person = new ltext( new string[]{"Customer person", "Stranke fizične osebe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonData_Edit.cs

 //public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonData_Edit.cs

 //public static ltext s_Items = new ltext( new string[]{"Items",
 //                                               "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_PersonData_Edit.cs

 //public static ltext s_OrganisationData = new ltext( new string[]{"Organisation data", "Razširjeni podatki organizacije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Edit.cs

 public static ltext s_Customers_org = new ltext( new string[]{"Customer Organisation", "Stranka organizacija"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Edit.cs

 //public static ltext s_BankAccounts = new ltext( new string[]{"Bank Accounts", "Bančni računi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Edit.cs

 //public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Org_Edit.cs

 //public static ltext s_BankAccounts = new ltext( new string[]{"Bank Accounts", "Bančni računi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Edit.cs

 //public static ltext s_Customers_Person = new ltext( new string[]{"Customer person", "Stranke fizične osebe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Edit.cs

 //public static ltext s_DataChangedSaveYourData = new ltext( new string[]{"You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Edit.cs

 //public static ltext s_Items = new ltext( new string[]{"Items",
 //                                               "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Customer_Person_Edit.cs

 public static ltext s_PaymentOfInvoiceAndPrint = new ltext( new string[]{"Payment and Print", "Način plačila in izdaja računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_AddOn.cs

 public static ltext s_AmountReceived = new ltext( new string[]{"Amount received", "Prejeti znesek"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_PaymentCash.cs

 public static ltext s_AcceptedCashAmount = new ltext( new string[]{"Amount received", "Vnesite prejeti znesek"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_PaymentCash.cs

 public static ltext s_EndPrice = new ltext( new string[]{"Total", "Cena"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_PaymentCash.cs

 public static ltext s_ToReturn = new ltext( new string[]{"Money back", "Vračilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_PaymentCash.cs

 public static ltext s_Amount = new ltext( new string[]{"Amount", "Znesek"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_DocInvoice_PaymentCash.cs

 public static ltext s_btn_SimpleItem_Groups = new ltext( new string[]{"Simple item groups", "Skupine enostavnih artiklov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_ItemGroups = new ltext( new string[]{"Item groups", "Skupine artiklov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Logo = new ltext( new string[]{"Logo", "Logotip"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_DBSettings = new ltext( new string[]{"DB Settings", "Nastavitve v bazi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Stock_Address = new ltext( new string[]{"Stock places", "Skaldiščna mesta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_TermsOfPayment = new ltext( new string[]{"Terms of payment", "Plačilni pogoji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Warranty = new ltext( new string[]{"Warranty", "Garancije"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Expiry = new ltext( new string[]{"Expiry", "Roki uporabe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_WorkingPlace = new ltext( new string[]{"Jobs", "Delovna mesta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Units = new ltext( new string[]{"Units", "Merske enote"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Currency = new ltext( new string[]{"Currency", "Valute"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_btn_Taxation = new ltext( new string[]{"Taxation", "Davčne stopnje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_CodeTables.cs

 public static ltext s_Tax_ID = new ltext( new string[]{"VAT ID", "Davč.št."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_Type = new ltext( new string[]{"Type", "Vrsta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_CardNumber = new ltext( new string[]{"Card Number", "Št. kartice"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_Buyer = new ltext( new string[]{"Buyer",
                                                    "Kupec"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_Person = new ltext( new string[]{"Person",
                                          "Oseba"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 //public static ltext s_Address = new ltext( new string[]{"Address",
 //                                          "Naslov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_Organisation = new ltext( new string[]{"Organisation",
                                                      "Organizacija"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Customer.cs

 public static ltext s_btn_Select_BankAccount = new ltext( new string[]{"Select your bank account", "Izberite vaš bančni račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Invoice_Issue = new ltext( new string[]{"Issue an invoice", "Izdaj račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_ProformaInvoice_Issue = new ltext( new string[]{"Issue an offer", "Izdaj ponudbo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_lbl_DateOfProformaInvoiceIssue = new ltext( new string[]{"Proforma Invoice Date", "Datum ponudbe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_DocProformaInvoice_ValidToDate_must_be_later_than_IssueDay = new ltext( new string[]{"Proforma Invoice validy date must be later then issue date!", "Datum veljavnosti ponudbe mora biti kasnejši od datuma ponudbe!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Number_Of_Months = new ltext( new string[]{"Number of months","Število mesecev"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Number_Of_Days = new ltext( new string[]{"Number of days", "Število dni"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_rdb_Valid_Tender_Until = new ltext( new string[]{"Valid until", "Veljavnost ponudbe do"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_rbtn_NumberOf = new ltext( new string[]{"Number of "," Število"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_grp_ValidityOfTheTender = new ltext( new string[]{"The duration of the offer", "Veljavnost ponudbe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_TermsOfPayment = new ltext( new string[]{"Terms of payment", "Plačilni pogoji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Payment_on_bank_account = new ltext( new string[]{"Payment on bank account", "Plačilo na bančni račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Payment_by_cash_or_card_on_delivery = new ltext( new string[]{"Payment by cash or credit card on delivery", "Plačilo z gotovino ali kreditno kartico po povzetju"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_MethodOfPayment = new ltext( new string[]{"Payment type", "Način plačila"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_OK = new ltext( new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocProformaInvoice_AddOn .cs

 public static ltext s_Year = new ltext( new string[]{"Year", "Leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceMan.cs

 //public static ltext s_Invoice = new ltext( new string[]{"Invoice",
 //                                                 "Račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceMan.cs

 public static ltext s_DocProformaInvoice = new ltext( new string[]{"Proforma-Invoice",
                                                         "Predračun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceMan.cs

 public static ltext s_btn_New = new ltext( new string[]{"New",
                                                    "Nov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceMan.cs

 public static ltext s_IssueDate = new ltext( new string[]{"Issue date", "Čas izdaje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_FURS_BarCode = new ltext( new string[]{"FURS Bar (QR) code", "Davčna QR ali bar koda"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_Sum_All = new ltext( new string[]{"Total = ", "Skupaj = "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_Sum_Tax = new ltext( new string[]{"Tax = ", "Davek = "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_Sum_WithoutTax = new ltext( new string[]{"Net price = ", "Brez davka = "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_Today = new ltext( new string[]{"Today", "Danes"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_ThisWeek = new ltext( new string[]{"This week", "Ta teden"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_LastWeek = new ltext( new string[]{"Last week", "Prejšni teden"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_ThisMonth = new ltext( new string[]{"This month", "Ta mesec"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_LastMonth = new ltext( new string[]{"Last month", "Prejšni mesec"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_ThisYear = new ltext( new string[]{"This year", "To leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_LastYear = new ltext( new string[]{"Last Year", "Prejšne leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_TimeSpan = new ltext( new string[]{"Time span", "Obdobje"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_from = new ltext( new string[]{"from", "od"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_to = new ltext( new string[]{"to", "do"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_ShowAll = new ltext( new string[]{"Show all", "Prikaži vse"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 //public static ltext s_AllData = new ltext( new string[]{"All Data", "Vsi podatki"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_InvoiceTable.cs

 public static ltext s_WithoutDatabaseSettingsProgramCanNotRun_ExitOKOrCancel = new ltext( new string[]{"Without settings written to Database program can not run.\r\nTo enter database settings press OK, to exit program pres Cancel",
                                                                                                "Brez nastavitev določenih v podatkovni bazi program ne more delovati.\r\nZa ponovni vpis teh nastvaitev pritisnite gumb OK, če želite program končati pritidnite gumb Prekini"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Document.cs

 public static ltext s_No_DB_Settings_for = new ltext( new string[]{"Data value in table DBSettings is missing or is not valid for", "Vrstica v tabeli DBSettings manjka ali ni veljavna za"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Document.cs

 public static ltext s_DoYouWantToUpgradeDBToLatestVersion = new ltext( new string[]{"Upgrade to newest Database version?", "Nadgradim podtakovno bazo na zadnjo verzijo?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Document.cs

 public static ltext s_Database_Version_is = new ltext( new string[]{"Database version is:", "Zbirka podatkov je verzije:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Document.cs

 public static ltext s_ThisProgramWorksOnlyWithDatabase_Version = new ltext( new string[]{"\r\nThis program works only with database version:", "\r\nTa program lahko dela le z zbirko podatkov katere verzija je:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Document.cs

 public static ltext s_Payment_Deadline = new ltext( new string[]{"Payment deadline", "Rok plačila"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 public static ltext s_Valid_Until = new ltext( new string[]{"valid until ", " velja do "});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 public static ltext s_ProformaInvoice_Validity = new ltext( new string[]{"Proforma Invoice Validity", "Veljavnost ponudbe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 public static ltext s_Invoice_IssueDate = new ltext( new string[]{"Invoice Date", "Datum računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 public static ltext s_ProformaInvoice_IssueDate = new ltext( new string[]{"Proforma Invoice Date", "Datum ponudbe"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 //public static ltext s_Number_Of_Months = new ltext( new string[]{"Number of months","Število mesecev"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 //public static ltext s_Number_Of_Days = new ltext( new string[]{"Number of days", "Število dni"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 //public static ltext s_TermsOfPayment = new ltext( new string[]{"Terms of payment", "Plačilni pogoji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 //public static ltext s_MethodOfPayment = new ltext( new string[]{"Payment type", "Način plačila"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_AddOn.cs

 public static ltext s_lbl_DateOfInvoiceIssue = new ltext( new string[]{"Invoice Date", "Datum računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_Payment_Deadline = new ltext( new string[]{"Payment deadline", "Rok plačila"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_btn_Select_BankAccount = new ltext( new string[]{"Select your bank account", "Izberite vaš bančni račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_Invoice_Issue = new ltext( new string[]{"Issue an invoice", "Izdaj račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_TermsOfPayment = new ltext( new string[]{"Terms of payment", "Plačilni pogoji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_MethodOfPayment = new ltext( new string[]{"Payment type", "Način plačila"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 public static ltext s_AlreadyPaid = new ltext( new string[]{"Already paid", "Že plačano"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 public static ltext s_PaymentCard = new ltext( new string[]{"Payment Card", "Plačilna Kartica"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 public static ltext s_PaymentOnBankAccount = new ltext( new string[]{"Payment to Bank acount", "Plačilo na bančni račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 public static ltext s_Cash = new ltext( new string[]{"Cash", "Gotovina"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 //public static ltext s_OK = new ltext( new string[]{"OK",
 //                                                "V redu"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_DocInvoice_AddOn.cs

 public static ltext s_New_Copy_ThisInvoice_ToNewProformaInvoice = new ltext( new string[]{"Copy Invoice %s to new Proforma Invoice", "Kopiraj račun %s v nov osnutek predračuna"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Another_DocType.cs

 public static ltext s_New_Copy_ThisProformaInvoice_ToInvoice = new ltext( new string[]{"Copy Proforma-Invoice %s to new Invoice draft", "Kopiraj predračun %s v nov osnutek računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Another_DocType.cs

 public static ltext s_IntoFinancialYear = new ltext( new string[]{"Into Financial Year", "v poslovno leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Another_DocType.cs

 public static ltext s_New_Copy_ThisInvoice_ToNewOne = new ltext( new string[]{"Copy Invoice %s to new one", "Kopiraj račun %s v nov osnutek računa"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Same_DocType.cs

 public static ltext s_New_Copy_ThisProformaInvoice_ToNewOne = new ltext( new string[]{"Copy Proforma-Invoice %s to new one", "Kopiraj predračun %s v nov osnutek predračuna"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Same_DocType.cs

 //public static ltext s_IntoFinancialYear = new ltext( new string[]{"Into Financial Year", "v poslovno leto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_New_Copy_of_Same_DocType.cs

 public static ltext s_PurchasePrice_Items = new ltext( new string[]{"PurchasePrice_Items", "NABAVNI CENIK ARTIKLOV"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_PurchasePriceList_Edit.cs

 public static ltext s_YouMustSelectAtLeastOneShop = new ltext( new string[]{"You must select at least on shop!", "Izbrati morate najmanj eno prodajalno!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_chk_A_in_use = new ltext( new string[]{"Shop A in use", "Prodajalna A v uporabi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_chk_B_in_use = new ltext( new string[]{"Shop B in use", "Prodajalna B v uporabi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_chk_C_in_use = new ltext( new string[]{"Shop C in use", "Prodajalna C v uporabi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_lbl_ShopA_Name = new ltext( new string[]{"Shop A Name", "Ime prodajalne A"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_lbl_ShopB_Name = new ltext( new string[]{"Shop B Name", "Ime prodajalne B"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_lbl_ShopC_Name = new ltext( new string[]{"Shop C Name", "Ime prodajalne C"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 //public static ltext s_Shop_A = new ltext( new string[]{"A", "A"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 //public static ltext s_Shop_B = new ltext( new string[]{"B", "B"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 //public static ltext s_Shop_C = new ltext( new string[]{"C", "C"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 //public static ltext s_Warning = new ltext( new string[]{"Warning",
 //                                          "Opozorilo"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_ShopsInuse.cs

 public static ltext s_SelectedCurrency = new ltext( new string[]{"Selected currency:", "Izbrana valuta:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_DefaultCurrency.cs

 public static ltext s_SelectDefaultCurrency = new ltext( new string[]{"Select default currency", "Izberi privzeto valuto"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Select_DefaultCurrency.cs

 public static ltext s_TaxationTableHasNoData_YouMustEnterData_close_anyway = new ltext( new string[]{"Taxation table has no data. You must have at least one taxation row data!\r\nDo you realy want to cancel? ", "Tabela davčnih stopenj je prazna.\r\nVnesti morate vsaj eno davčno stopnjo!Želite kljub temu zapustiti dialog?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Taxation_Edit.cs

 public static ltext s_Taxation = new ltext( new string[]{"Taxation", "Davki"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Taxation_Edit.cs

 public static ltext s_PurchasePriceInfoText = new ltext( new string[]{"Item:%s1  Purchase Price  = %s2", "Artikel/Storitev:%s1 Nabavna cena = %s2"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 public static ltext s_btn_PurchasePriceInfo = new ltext( new string[]{"Purchase Price Info", "Informacija o nabavni ceni"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 public static ltext s_ExtraDiscountMakesLowerPriceThan_PurchasePrice = new ltext( new string[]{"Retail price %s1 with discount %s2 is %s3 and is smaller or equal to purchase price %s4. Do you agree ?", "Cena %s1 s popustom %s2 znaša %s3 in je manjša ali enaka nabavni ceni %s4. Soglašate ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 public static ltext s_rdb_EndPrice = new ltext( new string[]{"End price:", "Končna cena:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 public static ltext s_rdb_CustomDiscount = new ltext( new string[]{"Discount:", "Popust:"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 //public static ltext s_Price = new ltext( new string[]{"Price", "Cena"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Discount.cs

 public static ltext s_ElectronicDevice_ID = new ltext( new string[]{"Electronic Device ID", "Oznaka blagajne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_chk_AllowToEditText = new ltext( new string[]{"Allow to edit controls text", "Urejanje besedil v oknih"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_CloseLogManagerDialog = new ltext( new string[]{"Close Log Manager Dialog!", "Končaj oziroma zapri dialog dnevniških nastavitev!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_YouHaveChangedLanguageYouMustRestartProgramToUseNewLanguage = new ltext( new string[]{"You have selected another language.\r\nYou must restart program to use another language.", "Izbrali ste drug jezik. Da bo program delal v novem jeziku, ponovno zaženite program."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_LogFile = new ltext( new string[]{"Log file", "Dnevniška datoteka (\"Log file\")"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_FullScreen = new ltext( new string[]{"Full Screen",
                                                   "Čez cel zaslon"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_Language = new ltext( new string[]{"Language",
                                                   "Jezik"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext sProgramSettings = new ltext( new string[]{"Program Settings",
                                                         "Programske nastavitve"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_ProgramSettings.cs

 public static ltext s_GoToPreviousStartupStep = new ltext( new string[]{"Go to previous startup step", "Pojdi na prejšni korak"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_GoToNextStartupStep = new ltext( new string[]{"Go to next startup step", "Nadaljuj na naslednji korak"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_GoToExitProgram = new ltext( new string[]{"Exit program", "Končaj program"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_Check_DataBase = new ltext( new string[]{"Connecting with Database","Povezovanje z bazo podatkov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_Read_DBSettings = new ltext( new string[]{"Read Database Settings", "Branje nastavitev iz baze podatkov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_CheckDBVersion = new ltext( new string[]{"Check database", "Preverjanje baze podatkov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetOrganisationData = new ltext( new string[]{"Reading organisation data ", "Branje podatkov o vaši organizaciji"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_Get_ProgramSettings = new ltext( new string[]{"Get program settings", "Programske nastavitve"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_SetShopsPricelists = new ltext( new string[]{"Set shop's priselists", "Branje cenikov"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetBaseCurrency = new ltext( new string[]{"Getting default currency", "Pridobivanje privzete valute"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetTaxation = new ltext( new string[]{"Reading default taxation", "Branje davčnih stopenj"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetSimpleItemData = new ltext( new string[]{"Reading ShopB Items", "Branje artiklov/storitev trgovine B"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetItemData = new ltext( new string[]{"Reading ShopC Items", "Branje artiklov/storitev trgovine C"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_GetPrinter = new ltext( new string[]{"Get Printers", "Nastavitve tiskanja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Startup_Login = new ltext( new string[]{"Login", "Prijava"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Previous = new ltext( new string[]{"Previous", "Nazaj"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_RealyWantToExitProgram = new ltext( new string[]{"Do you realy want to end program? (Yes/No)", "Želite končati program? (Da/Ne)"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Next = new ltext( new string[]{"Next", "Naprej"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_Tangenta = new ltext( new string[]{"Tangenta", "Tangenta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Form_Document.cs

 public static ltext s_AUTONEXT_missing_parameter = new ltext( new string[]{"/AUTONEXT missing or parsing error for Auto_NEXT_in_miliseconds!/r/n(Example:\"/AUTONEXT==10\")\r\nAuto_NEXT_in_miliseconds = 10ms : is default value", "/AUTONEXT manjka parameter - število milisikund za skok na naslednji korak!\r\n\"/AUTONEXT=10\")\r\nAuto_NEXT_in_miliseconds = 10ms : je privzeta vrednost s katero bo program nadaljeval."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_Previous = new ltext( new string[]{"Previous", "Nazaj"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_RealyWantToExitProgram = new ltext( new string[]{"Do you realy want to end program? (Yes/No)", "Želite končati program? (Da/Ne)"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_Draft = new ltext( new string[]{"Draft", "Osnutek"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_Next = new ltext( new string[]{"Next", "Naprej"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_RS232MONITOR = new ltext( new string[]{"Activates RS232 Monitor for Leuze sensor.\r\n With RS232 Monitor Form you can see data streem from Leuze Sensor", "Aktivira RS232 Monitor.\r\n Z njim lahko spreljate prihod podatkov od Leuze senzorja,\r\nki prečita postavljena orodja (črke) za prešanje tablice."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_DOCINVOICE = new ltext( new string[]{"Starts program to edit or view Invoices","Zažene program tako, da začnete najprej urejati ali pregledovati račune"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_DOCPROFORMAINVOICE = new ltext( new string[]{"Starts program to edit or view proforma invoices", "Zažene program tako, da začnete najprej urejati predračune"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_CHANGE_CONNECTION = new ltext( new string[]{"Shows connection dialogs.\r\nThis command in command line enables you to change database connection at program startup.", "Prikaže dialoge za ustvarjanje povezav na strežnike.\r\nTo vam omogoči, da ob zagonu programa nastavite nove povezave na strežnike."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_RESETNEW = new ltext( new string[]{"Starts program without saved settings!", "Zažene program kot novo instalacijo brez vseh nastavitev!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_commandline_AUTONEXT = new ltext( new string[]{"Starts program with automatic predefined setup! It works only with RESETNEW command.\r\nExample = /AUTNEXT=1000", "Avtomastki zagon tako da program sam pritiska na gumb naprej, deluje samo če s zažene program kot novo instalacijo brez vseh nastavitev oziroma z /RESETNEW parametrom.\r\nPrimer:/AUTONEXT=1000"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_const_command_DIAGNOSTIC = new ltext( new string[]{"Enables Diagnostics of program speed.\r\n You can press F10 on main form to view speed results", "Omogoči diagnosticiranje hitrosti izvajanja programa. \r\n S pritsikom na F10 se prikaže okno z rezultati meritev."});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_Another_instance_is_running = new ltext( new string[]{"Another instance is running", "Program je bil že zagnan in ravnokar teče!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_OK = new ltext( new string[]{"OK",
 //                                                "V redu"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\Program.cs

 //public static ltext s_Total = new ltext( new string[]{"TOTAL", "SKUPAJ"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Show_Shops = new ltext( new string[]{"Shops", "Prodajalne"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_chk_Storno = new ltext( new string[]{"Storno", "Storno"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_B = new ltext( new string[]{"B", "B"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_C = new ltext( new string[]{"C", "C"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_AB = new ltext( new string[]{s_Shop_A.sText(0)+"&"+ s_Shop_B.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_BC = new ltext( new string[]{s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_AC = new ltext( new string[]{s_Shop_A.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Shop_ABC = new ltext( new string[]{s_Shop_A.sText(0) + "&" + s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1)});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_YouCanNotCnacelInvoiceStorno = new ltext( new string[]{"You can not reverse reversed invoice to invoice!", "Razveljavitev stornacije računa ni možna. Napišite nov račun!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_AreYouSureToStornoThisInvoice = new ltext( new string[]{"Are you sure to Storno this invoice?", "Ali zares želite stornirati račun ?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_Head = new ltext( new string[]{"Head", "Glava"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_Print = new ltext( new string[]{"Print", "Tiskaj"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_BuyerSelect = new ltext( new string[]{"Select", "Izberi"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Currency = new ltext( new string[]{"Currency", "Valuta"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_Number = new ltext( new string[]{"Number", "Številka"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_ShopC_Items_or_no_prices_for_those_items = new ltext( new string[]{"Shop %s has no items to sell or prices for them are not defined!", "V prodajalni %s ni nobenih artiklov ali pa le ti nimajo določenih prodajnih cen v ceniku!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_NoSimpleItemData_EnterSimpleItemDataQuestion = new ltext( new string[]{"No SimpleItem data. Enter SimpleItem data ?", "Ni podatkov o vaših storitvah. Vnesite podatke o storitvah?"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_Invoice = new ltext( new string[]{"Invoice",
 //                                                 "Račun"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_Issuer = new ltext( new string[]{"Issuer",
                                                    "Izstavitelj"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 //public static ltext s_MyOrganisation = new ltext( new string[]{"My organisation",
 //                                                   "Moja oragnizacija"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_OrganisationData = new ltext( new string[]{"There is no data about your company. You must enter your company data first!",
                                                         "Ni podatkov o vašem podjetju. Najprej morate vnesti podatke o svojem podjetju"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_StreetName = new ltext( new string[]{"There is no Street Name address of your company. You must enter Street Name address of your company!",
                                                         "Ni podatka o naslovu ulice vašega podjetja. Vnesti morate naslov ulice vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_HouseNumber = new ltext( new string[]{"There is no house number of your company. You must enter house number of your company!",
                                                         "Ni podatka o hišni številki vašega podjetja. Vnesti morate hišno številko vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_ZIP = new ltext( new string[]{"There is no ZIP of your company. You must enter ZIP of your company!",
                                                         "Ni podatka o številki pošte vašega podjetja. Vnesti morate številko pošte vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_City = new ltext( new string[]{"There is no city of your company. You must enter city of your company!",
                                                         "Ni podatka o kraju vašega podjetja. Vnesti morate kraj vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_Office_Data = new ltext( new string[]{"There is no office address of your organisation. You must have office address in your organisation!",
                                                         "Vaše podjetje nima dodatnih  potakov poslovne enot (naslov, opis..),\nVpisati morate še podatke poslovne enote!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_Office_Data_FVI_SLO_RealEstateBP = new ltext( new string[]{"Missing Real Estate Data for your office. You need them for Fiscal verification of invoices in Slovenia!",
                                                                              "Vaša poslovna enota nima podatkov o poslovnem prosturu potrebnih za davčno potrjevanje računov,\nVpisati morate še podatke o poslovnem prostoru, ki so potrebni za davčno potrjevanje računov!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_Person = new ltext( new string[]{"There is no person of your company which is active. You must enter person of your company! (Also Check if Active flag is set!)",
                                                              "Vaše podjetje nima vsaj ene osebe, ki bi bila označena za aktivno.\nVnesti morate osebo ali osebe v vašem podjetju in pri tem mora imeti imeti najmanj ena oseba odkljukano, da je aktivna!"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

 public static ltext s_No_MyOrganisation_Tax_ID = new ltext( new string[]{"There is no Tax ID of your company. You must enter Tax ID of your company!",
                                                            "Vaše podjetje nima davčne številke. Vnesti morate davčno številko vašega podjetja"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        //public static ltext s_OK = new ltext( new string[]{"OK",
        //                                                "V redu"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs

        //public static ltext s_Cancel = new ltext( new string[]{"Cancel",
        //                                         "Prekini"});   // referenced in C:\Tangenta40\TANGENTA\Tangenta\usrc_Invoice.cs
        public static ltext s_Issue = new ltext(new string[] { "Issue", "Izstavitev" });

        public static ltext s_No_MyOrganisation_Country = new ltext(new string[] {"There is no country of your company. You must enter country of your company!",
                                                     "Ni podatka v kateri državi je vaše podjetje. Vnesti morate državo v kateri je podjetje" });

        public static ltext s_No_Office = new ltext(new string[] { "There is no office of your organisation. You must have at least one office in your organisation!",
                                                 "Vaše podjetje nima poslovnih enot,\nVpisati morate vsaj eno poslovno enoto!" });

    }
}
