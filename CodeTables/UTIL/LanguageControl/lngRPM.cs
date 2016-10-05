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

namespace LanguageControl
{
    public static class lngRPM
    {
        public static ltext s_new_proforma_invoice_draft = new ltext("New Proforma Invoice draft","Nov osnutek predračuna");
        #region StartUp
        public static ltext s_WithoutDatabaseSettingsProgramCanNotRun_ExitOKOrCancel = new ltext("Without settings written to Database program can not run.\r\nTo enter database settings press OK, to exit program pres Cancel",
                                                                                                "Brez nastavitev določenih v podatkovni bazi program ne more delovati.\r\nZa ponovni vpis teh nastvaitev pritisnite gumb OK, če želite program končati pritidnite gumb Prekini");
        public static ltext s_No_DB_Settings_for = new ltext("Data value in table DBSettings is missing or is not valid for", "Vrstica v tabeli DBSettings manjka ali ni veljavna za");
        public static ltext s_RetypePassword = new ltext("Retype password:", "Ponovite geslo:");
        public static ltext s_DoYouWantToUpgradeDBToLatestVersion = new ltext("Upgrade to newest Database version?", "Nadgradim podtakovno bazo na zadnjo verzijo?");
        public static ltext s_Bank = new ltext("Bank", "Banka");
        public static ltext s_BankAccount = new ltext("Bank Account", "Bančni račun");
        public static ltext s_YouHaveChangedSomeDataButNotAllSampleData_YouShouldChangeAllSampleDataToYourRealData = new ltext ("You have only changed some of sample data!\r\nIf you want to run this application with your real data, press OK and then change all sample data to your real organisation data.If you want to run this application with your modified sample data press Cancel", "Spremenili ste samo nekatere vzorčne podatke.\r\nČe želite, da bo program uporabljal prave podatke pritisnite gumb \"V redu\" in spremenite vse vzorčne podatke v prave podatke.\r\nČe želite, da bo program uporabljal spremenjene vzorčne podatke in tekel kot demo aplikacija pritisnite gumb \"Prekini\"");
        public static ltext s_Database_Version_is = new ltext("Database version is:", "Zbirka podatkov je verzije:");
        public static ltext s_ThisProgramWorksOnlyWithDatabase_Version = new ltext("\r\nThis program works only with database version:", "\r\nTa program lahko dela le z zbirko podatkov katere verzija je:");

        public static ltext s_Startup_Check_DataBase = new ltext("Connecting with Database","Povezovanje z bazo podatkov");
        public static ltext s_Startup_Read_DBSettings = new ltext("Read Database Settings", "Branje nastavitev iz baze podatkov");
        public static ltext s_Startup_CheckDBVersion = new ltext("Check database", "Preverjanje baze podatkov");
        public static ltext s_Startup_GetOrganisationData = new ltext("Reading organisation data ", "Branje podatkov o vaši organizaciji");
        public static ltext s_Startup_Get_ProgramSettings = new ltext("Get program settings", "Programske nastavitve");
        public static ltext s_SetShopsPricelists = new ltext("Set shop's priselists", "Branje cenikov");
        public static ltext s_Startup_GetBaseCurrency = new ltext("Getting default currency", "Pridobivanje privzete valute");
        public static ltext s_Startup_GetTaxation = new ltext("Reading default taxation", "Branje davčnih stopenj");
        public static ltext s_Startup_GetSimpleItemData = new ltext("Reading ShopB Items", "Branje artiklov/storitev trgovine B");
        public static ltext s_Startup_GetItemData = new ltext("Reading ShopC Items", "Branje artiklov/storitev trgovine C");
        public static ltext s_Startup_Login = new ltext("Login", "Prijava");



        #endregion

        public static ltext s_NoConnectionToDatabase_You_must_set_Database_connection_to_go_next_step = new ltext("There was no succesfull database connection check!\r\nPlease make succesful database connection check.\r\nYou can not go to next step, until succesfull database connection check.\\To check database connection press button Check database connection",
                                                                                                                  "Ni bilo uspešnega preverjanja povezave na podatkovno bazo!\r\nDa bi lahko pritisnili gumb za naprej mora biti povezava na podatkovno bazo uspešno preverjena. Preverjanje povezave na podatkovno bazo naredite tako da pritisnete na gumb:\"Preveri povezavo na podatkovno bazo\"");
        public static ltext s_Previous = new ltext("Previous", "Nazaj");
        public static ltext s_myOrganisation_Person_Data = new ltext("Organisation person data", "Podatki o osebi v organizaciji");
        public static ltext s_DataNotSavedEndYesNo = new ltext("New or changed data are not written to database.\r\nQuit (Yes/No)?", "Novi ali spremenjeni podatki se niso zapisali v bazo podatkov.\r\nKončam (Da/Ne)?");
        public static ltext s_StartupProgram = new ltext("Program Startup", "Zagon Programa Tangenta");

        public static ltext s_DataBaseIsEmpty_InsertInitialData = new ltext("Database is empty. If you want to preview this program first, then let this program to insert imaginary initial sample data of your organisation (Organisation1) and you will change this data later to your real organisation data, than select:",
                                                                            "Baza podatkov je prazna!\r\nV kolikor si želite pred uporabo program najprej ogledati, potem je najbolje, da program samodejno vstavi začetne namišljene podatke neke splošne organizacije (Podjetje1), vi pa potem te podatke lahko kadarkoli spremenite v vaše prave podatke. Če je temu tako, potem izberite:");
        public static ltext s_DataBaseIsEmpty_EnterData = new ltext("If you want to enter your data manually than select:",
                                                                    "V kolikor želite, da sami vnesete podatke potem izberite:");
        public static ltext s_Write_predefined_data_into_a_new_database = new ltext("Write initial default data into a new database", "Napišite začetne privzete podatke v novo bazo podatkov");
        public static ltext s_Enter_your_data_manually = new ltext("Enter your data manually", "Ročni vnos podatkov v novo bazo podatkov");

        public static ltext s_UpgradeBackupFileExist_restore_old_Database = new ltext("Upgrade failed, Database backup file exists. Restore DataBase \"%s\" (Yes/No) ?", "Nadgradnja podatkovne baze je bila neuspešna.\r\n Povrnem podatkovno bazo v prejšne stanje iz datoteke:\"%s\" (Da/Ne) ?");
        public static ltext s_CanNotReadDataBaseFile = new ltext("ERRRO:Can not read database file.", "NAPAKA:Neuspešno branje podatkovne baze.");
        public static ltext s_DataBaseVersion = new ltext("DataBaseVersion", "Verzija podatkovne baze:");
        public static ltext s_ElectronicDevice_ID = new ltext("Electronic Device ID", "Oznaka blagajne");
        public static ltext s_chk_AllowToEditText = new ltext("Allow to edit controls text", "Urejanje besedil v oknih");
        public static ltext s_RecentText = new ltext("Recent Text", "Nedavni tekst");
        public static ltext s_FVI_SLO_Error = new ltext("Error in communication with Tax Administration ", "Napaka v komunikaciji z davčno upravo");
        public static ltext s_Edit_Office_Data_FVI_SLO_RealEstateBP = new ltext("Office Data for FURS!", "Podatki poslovne enote potrebni za davčno potrjevanje");
        public static ltext s_Edit_Office_Data = new ltext("Other Office Data!", "Ostali podatki poslovne enote");
        public static ltext s_Edit_Offices = new ltext("Offices of your organisation!", "Poslovne enote vaše oragnizacije");
        public static ltext s_SalesBookInvoice_UnsentMsg = new ltext("Send unsent invoices from SalesBookInvoice in ten days after invoice issue date!", "Pošljite neposlane račune iz vezane knjige računov najkasneje v desetih dneh od izstavitve računa!");
        public static ltext s_SendtoDurs = new ltext("Send", "Pošlji");
        public static ltext s_Issuer_FirstName = new ltext("Issuer first name", "Ime blagajnika");
        public static ltext s_Issuer_LastName = new ltext("Issuer last name", "Priimek blagajnika");
        public static ltext s_FinancialYear = new ltext("Financial Year", "Poslovno leto");
        public static ltext s_InvoiceNumber = new ltext("Invoice Number in Financial Year", "Številka računa v poslovnem letu");
        public static ltext s_IssueDate = new ltext("Issue date", "Čas izdaje računa");
        public static ltext s_GrossSum = new ltext("Total", "Znesek računa");
        public static ltext s_TaxSum = new ltext("Tax", "Davek");
        public static ltext s_NetSum = new ltext("Net sum", "Neto cena");
        public static ltext s_SalesBook_SerialNumber = new ltext("SalesBookInvoice Serial Number", "Serijska številka vezane knjige računov");
        public static ltext s_SalesBook_SetNumber = new ltext("SalesBookInvoice Set Number", "Številka seta vezane knjige računov");
        public static ltext s_SalesBook_InvoiceNumber = new ltext("SalesBookInvoice Invoice Number", "Številka računa");

        public static ltext s_SalesBookInvoice_SetNumber_GraterThanAllSetsDefinedInSettings = new ltext("Set number is greater the number of all sets.Please ask tehnical support to change settings.", "Vnesli ste številko seta iz vezane knjige računov, ki je večja od števila vseh setov.\r\nPokličite tehnično podporo, da spremeni nastavite, ali pa vnesite pravo številko.");

        public static ltext s_GoToSalesBookInvoice = new ltext("Write into SalesBookInvoice", "Vpišite v vezano knjgo računov");
        public static ltext s_SalesBookInvoice_SetNumber_Not_OK = new ltext("SalesBookInvoice set number is not OK!", "Številka seta iz vezane knjige računov ni ustrezna!");
        public static ltext sSalesBookInvoice_SerialNumber_does_not_match_patern = new ltext("SalesBook serial number does not match patern ####-####### where '#' means number 0-9!"
                                                                                              + "\r\nPlease write serial number in proper format or ask technical support to change Regular Expression pattern in Settings."
                                                                                              + "\r\nIf you press Yes, serial number with wrong format will be accepted, otherwise press No ?",
                                                                                              "Serijska številka vezane knjige računov ne ustreza formatu ####-####### (štiri številke, minus nato še sedem številk)!"
                                                                                              + "\r\nVpišite serijsko številko v navedenem formatu ali pa naj vam tehnična podpora spremeni format za serijsko številko v nastavitvah."
                                                                                             + "\r\nV kolikor izberete Da (Yes) bo serijska številka sprejeta ne glede na format, če kliknete Ne(No) nadaljujete z vnosom?");



        public static ltext s_LastSetNumberIsMoreThan_MAX_SalesBookInvoice_SetNumber = new ltext("SetNumber in SalesBookInvoice exceeded maximum set number which is set to:", "Številka seta v vezani knjigi računov presega zadnjo številko seta ki je:");
        public static ltext s_TakeNewSalesBookInvoiceAndWriteItsSerialNumberFirst = new ltext("Use new SalesBookInvoice and enter it's serial number first!", "Vzemite novo vezano knjigo računov in vpišite najprej njeno serijsko številko!");
        public static ltext s_FURS_BarCode = new ltext("FURS Bar (QR) code", "Davčna QR ali bar koda");

        public static ltext s_InternetConnectionISOK_maybe_FURS_server_is_not_online = new ltext("Your computer has Internet Connection."
                                                                                                 + "\r\nIf there is no communication with DURS please call them to check if their server is online!",
                                                                                                 "Vaš računalnik ima povezavo v svetovni splet (\"internet\")."
                                                                                                 + "\r\nČe še vedno ne uspete poslati podatke na DURS, preverite na DURS-u, če njihov strežnik za potrjevanje računov deluje.");


        public static ltext s_NoInternetConnection = new ltext("You have no Internet Connection!"
                                                                + "\r\nPlease check your cable connection or Wifi Connection!"
                                                            , "Nimate povezave na svetovni splet (\"Internet\")!"
                                                            + "\r\nČe ste na brezžični povezavi preverite ali le ta deluje, sicer pa preverite ali je mrežni kabel sploh priključen v vaš rečunalnik."
                                                            );

        public static ltext s_CheckInternetConnection = new ltext("Check Internet Connection", "Preveri povezavo na svetovni splet");
        public static ltext s_InvoiceNotSentOK = new ltext("Invoice was not sent to DURS !", "Račun ni bil uspešno poslan ali potrjen na davčni upravi");
        public static ltext s_InstructionToTryToSendFURSDataAgain = new ltext("Data was not send to DURS!\r\nYou can:"
                                                                              + "\r\n\r\n   1. click \"Send invoice data to DURS again\" button after you have checked your internet connection ! or"
                                                                              + "\r\n\r\n   2. click \"Write into SalesBookInvoice\" button to write invoice data into Sales Book Invoice.",
                                                                              "Račun ni bil supešno poslan davčni upravi!\r\n\r\nIzberete lahko:"
                                                                              + "\r\n\r\n   1. kliknite gumb \"Ponovno pošlji račun davčni upravi\" v kolikor ste preverili, da imate povezavo na svetovni splet ali pa"
                                                                              + "\r\n\r\n   2. kliknite gumb \"Vpišite v vezano knjigo računov\" kjer boste potem morali račun vpisati v vezano knjigo računov,"
                                                                              + "r\n      le to pa boste lahko poslali davčni upravi, ko bo zopet povezava z davčno upravo delovala.");
        public static ltext s_TryToSendFURSDataAgain = new ltext("Send invoice data to DURS again", "Ponovno pošlji račun davčni upravi");
        public static ltext s_Total = new ltext("TOTAL", "SKUPAJ");

        public static ltext s_AreYouSure_ToResetSettingsToInitialvalues = new ltext("Do you realy want to reset all settings to initial values?\r\nIf yes, you will lost all user settings you have defined.", "Ste prepričani, da zares želite ponastaviti nastavitve na začetno programsko vrednost?\r\nV kolikor ste, vedite, da boste izgubili vse nastavitve ki ste jih ročno vnesli.");
        public static ltext s_DoYouRealyWantToResetSettingsFor_FiscalVerificationOfInvoices = new ltext("Do you realy want to reset Settings for fiscal verification of invoices", "Ste prepričani, da zares želite ponastaviti nastavitve za davčno potrjevanje računov na začetno programsko vrednost ?");

        public static ltext s_SalesBookInvoice = new ltext("Sales book invoice", "Vezana knjiga računov");
        public static ltext s_Price_for = new ltext("Price for", "Cena za ");
        public static ltext s_TaxRate_must_be_defined = new ltext("Tax rate name must be defined!", "Davčna stopnja mora biti določena!");
        public static ltext s_Item_name_must_be_defined = new ltext("Item name must be defined!", "Ime postavke mora biti določen!");

        public static ltext s_Show_Shops = new ltext("Shops", "Prodajalne");

        public static ltext s_YouMustSelectAtLeastOneShop = new ltext("You must select at least on shop!", "Izbrati morate najmanj eno prodajalno!");

        public static ltext s_Shops_In_Use = new ltext("Shops in use", "Prodajalne v uporabi");

        public static ltext s_chk_A_in_use =  new ltext("Shop A in use", "Prodajalna A v uporabi");
        public static ltext s_chk_B_in_use =  new ltext("Shop C in use", "Prodajalna B v uporabi");
        public static ltext s_chk_C_in_use =  new ltext("Shop C in use", "Prodajalna C v uporabi");

        public static ltext s_lbl_ShopA_Name = new ltext("Shop A Name", "Ime prodajalne A");
        public static ltext s_lbl_ShopB_Name = new ltext("Shop B Name", "Ime prodajalne B");
        public static ltext s_lbl_ShopC_Name  = new ltext("Shop C Name", "Ime prodajalne C");


        public static ltext s_lbl_FURS_BussinesData = new ltext("FURS bussines data", "FURS poslovni podatki");
        public static ltext s_fursBuildingNumber = new ltext("Building number", "Številka stavbe");
        public static ltext s_lbl_BuildingSectionNumber = new ltext("Building section number", "Številka dela stavbe");
        public static ltext s_lbl_Community = new ltext("Community", "Naselje");
        public static ltext s_lbl_CadastralNumber = new ltext("Cadastral number", "Katastrska številka");
        public static ltext s_lbl_ValidityDate = new ltext("Validity Date", "Datum veljavnosti");
        public static ltext s_lbl_ClosingTag = new ltext("Closing tag", "Oznaka zaprtja");
        public static ltext s_lbl_SoftwareSupplier_TaxNumber = new ltext("Software supplier Tax ID", "Davčna številka dobavitelja programske opreme");
        public static ltext s_lbl_PremiseType = new ltext("Premise type", "Vrsta Nepremičnine");
        public static ltext s_lbl_MyOrganisation_TaxID = new ltext("My organisation Tax ID", "Davčna številka moje organizacije");
        public static ltext s_lbl_BussinesPremiseID = new ltext("Bussines Premise ID", "Oznaka poslovnega prostora");
        public static ltext s_lbl_InvoiceAuthor_TaxID = new ltext("Davčna številka izdajatelja računa", "Davčna številka izdajatelja računa");
        public static ltext s_btn_ImportFromDataBase = new ltext("Import from Data Base", "Uvozi iz baze podatkov");




        public static ltext s_SelectCertificate = new ltext("Select certificate", "Izberite Certifikat");

        public static ltext s_Furs_Environment = new ltext("FURS environment", "FURS okolje");

        public static ltext s_Furs_Test_Environment = new ltext("FURS Test environment", "FURS TESTNO okolje !");
        public static ltext s_YouHaveNoDocumentTemplateToPrintOnA4 = new ltext("You have no html document template for printing Invoice on A4 paper format!\r\nYou must insert document template html into database!", "Nimate vnešenih html predlog za tiskanje na A4 papir.\r\nVnesti morate v bazo vsaj eno html predlogo za tisaknje računov na A4 tiskalniku!");
        public static ltext s_FVI_SLO_RealEstateBP_has_no_Data = new ltext("No data for Fiscal Verification system in Slovenia. \r\nYou can not do fiscal verification until you enter RealEstate data!", "Ni vnešenih podatkov o poslovnem prosturu potrebnih za davčno upravo.\r\nPotrejavanje računov ne bo delalo dokler ne vnesete podatkov o poslovnem prostoru!");
        public static ltext s_btn_Tokens = new ltext("View replacement word", "Ključne besede za izdelavo predlog");
        public static ltext s_Form_Select_Country_ISO_3166_Title = new ltext("Select State", "Izberite Državo");
        public static ltext s_YouMustEnterYourOrganisationData = new ltext("You must enter your organisation data. Without organisation data program can not run!", "Morate vpisati podatke o vaši organizaciji in vsaj eni osebi. Brez tega program ne more delovati!");
        public static ltext s_YouMustEnterYourOfficeData = new ltext("You must enter your office data. Without office data program can not run!", "Morate vpisati podatke o vsaj eni poslovni enoti vaše organizacije in vsaj eni osebi. Brez tega program ne more delovati!");
        public static ltext s_YouMustEnterYourOfficeAddressData = new ltext("You must enter your office address data. Without office address data program can not run!", "Morate vpisati podatke o naslovu poslovne enote vaše organizacije. Brez tega program ne more delovati!");
        public static ltext s_YouMustEnterYourOfficePersonData = new ltext("You must enter your organisation perosn data. Without at least one oragnisation person data program can not run!", "Morate vpisati podatke o vsaj eni osebi vaše organizacije. Brez tega program ne more delovati!");

        public static ltext s_YouDidNotEnterYourOrganisationData = new ltext("You did not enter your organisation data. Without organisation data program can not run! Program will end? ", "Morate vpisati podatke o vaši organizaciji in vsaj eni osebi. Brez tega program ne more delovati! Program se konča ?");
        public static ltext s_YouDidNotEnterYourOrganisationPersonData = new ltext("You did not enter your organisation person data. Without any organisation person data program can not run! Program will end? ", "Morate vpisati podatke o vsaj eni osebi v vaši organizaciji. Brez tega program ne more delovati! Program se konča ?");

        public static ltext s_YouDidNotWriteDataToDB_SaveData_YesOrNo = new ltext("Write to Data Base.\r\n(Press Yes or No)?", "Vpišem podatke v podatkovno bazo?\r\n(Pritisni gumb Da ali Ne) ?");

        public static ltext s_PurchasePriceInfoText = new ltext("Item:%s1  Purchase Price  = %s2", "Artikel/Storitev:%s1 Nabavna cena = %s2");
        public static ltext s_btn_PurchasePriceInfo = new ltext("Purchase Price Info", "Informacija o nabavni ceni");
        public static ltext s_ExtraDiscountMakesLowerPriceThan_PurchasePrice = new ltext("Retail price %s1 with discount %s2 is %s3 and is smaller or equal to purchase price %s4. Do you agree ?", "Cena %s1 s popustom %s2 znaša %s3 in je manjša ali enaka nabavni ceni %s4. Soglašate ?");
        public static ltext s_rdb_EndPrice = new ltext("End price:", "Končna cena:");
        public static ltext s_rdb_CustomDiscount = new ltext("Discount:", "Popust:");
        public static ltext s_Template = new ltext("Template", "Predloga");
        public static ltext s_Registration_ID = new ltext("Registration ID", "Matična.št.");
        public static ltext s_Tax_ID = new ltext("VAT ID", "Davč.št.");
        public static ltext s_OrganisationAccount = new ltext("Organisation Bank-Accounts", "Bančni računi organizacije");

        public static ltext s_DatabaseInfo = new ltext("Database INFO:", "O podatkovni bazi:");
        public static ltext s_Database = new ltext("Database", "Podatkovna baza");
        public static ltext s_err_CreateViews = new ltext("Error create views", "Napaka pri izdelavi prikazov (\"VIEWS\"");
        public static ltext s_SelectDatabase = new ltext("Select Database type", "Izberite tip podatkovne baze");
        public static ltext s_SimpleItemGroups = new ltext("Simple Item groups", "Skupine enostavnih Artiklov");
        public static ltext s_ItemGroups = new ltext("Item groups", "Skupine Artiklov");
        public static ltext s_Logos = new ltext("Logos in Database ", "Logotip podjetja");
        public static ltext s_DBSettings = new ltext("Settings in Database ", "Nastavitve v podatkovni bazi");
        public static ltext s_ExpiryStockCheck = new ltext("Expiry stock check", "Kontrola zalog");
        public static ltext s_ItemsWithNoExpiryData = new ltext("Items with no expiry data", "Artikli, ki nimajo podatka o roku uporabe");
        public static ltext s_ItemsToSale = new ltext("Items to sale with discount", "Artikli, ki naj gredo v razprodajo");
        public static ltext s_ItemsToDiscart = new ltext("Items to discard", "Artikli, ki naj gredo v uničenje");
        public static ltext s_Legend = new ltext("Legend", "Legenda");
        public static ltext s_StockAddresss = new ltext("Stock address", "Lokacija skladiščenja");
        public static ltext s_TermsOfPayments = new ltext("Payment terms", "Plačilni pogoji");
        public static ltext s_Warrantys = new ltext("Warranty data", "Dolžine garancijskih rokov");
        public static ltext s_Expirys = new ltext("Expiry data", "Dolžine rokov uporabe");
        public static ltext s_Units = new ltext("Units", "Enote");
        public static ltext s_WorkingPlace = new ltext("Working place","Delovna Mesta");

        public static ltext s_DBSettingsTableHasNoData_YouMustEnterData_close_anyway = new ltext("DB Settings table has no data!\r\nDo you realy want to cancel? ", "Manjkajo nastavitve v podatkovni bazi.\r\nŽelite kljub temu zapustiti dialog?");

        public static ltext s_StockAddressTableHasNoData_YouMustEnterData_close_anyway = new ltext("Stock Address has no data!\r\nDo you realy want to cancel? ", "Manjka vsaj ena loakcija skladišča.\r\nVnesti morate vsaj eno lokacijo skladišča!Želite kljub temu zapustiti dialog?");
        public static ltext s_TermsOfPaymentTableHasNoData_YouMustEnterData_close_anyway = new ltext("Terms of payment of payment has no data!\r\nDo you realy want to cancel? ", "Manjka vsaj en plačilni pogoj.\r\nVnesti morate vsaj en plačilni pogoj!Želite kljub temu zapustiti dialog?");
        
        public static ltext s_WarrantyTableHasNoData_YouMustEnterData_close_anyway = new ltext("Warranty Table has no data. You must have at least one warranty  data row!\r\nDo you realy want to cancel? ", "Tabela garancijskih rokov uporabe je prazna.\r\nVnesti morate vsaj en garancijski rok uporabe!Želite kljub temu zapustiti dialog?");
        
        public static ltext s_ExpiryTableHasNoData_YouMustEnterData_close_anyway = new ltext("Expiry Table has no data. You must have at least one expiry data row!\r\nDo you realy want to cancel? ", "Tabela rokov uporabe je prazna.\r\nVnesti morate vsaj en rok uporabe!Želite kljub temu zapustiti dialog?");
        public static ltext s_WorkingPlaceTableHasNoData_YouMustEnterData_close_anyway = new ltext("Working Place Table has no data. You must have at least one Working Place data row!\r\nDo you realy want to cancel? ", "Tabela merskih enot je prazna.\r\nVnesti morate vsaj eno mersko enoto!Želite kljub temu zapustiti dialog?");
        public static ltext s_UnitTableHasNoData_YouMustEnterData_close_anyway = new ltext("Unit table has no data. You must have at least one measure unit data row!\r\nDo you realy want to cancel? ", "Tabela merskih enot je prazna.\r\nVnesti morate vsaj eno mersko enoto!Želite kljub temu zapustiti dialog?");
        public static ltext s_CurrencyTableHasNoData_YouMustEnterData_close_anyway = new ltext("Currency table has no data. You must have at least one currency data row!\r\nDo you realy want to cancel? ", "Tabela valut je prazna.\r\nVnesti morate vsaj eno valuto!Želite kljub temu zapustiti dialog?");
        public static ltext s_btn_SimpleItem_Groups = new ltext("Simple item groups", "Skupine enostavnih artiklov");
        public static ltext s_btn_ItemGroups = new ltext("Item groups", "Skupine artiklov");
        public static ltext s_btn_Logo = new ltext("Logo", "Logotip");
        public static ltext s_btn_DBSettings = new ltext("DB Settings", "Nastavitve v bazi");
        public static ltext s_btn_Stock_Address = new ltext("Stock places", "Skaldiščna mesta");
        public static ltext s_btn_TermsOfPayment = new ltext("Terms of payment", "Plačilni pogoji");
        public static ltext s_btn_Warranty = new ltext("Warranty", "Garancije");
        public static ltext s_btn_Expiry = new ltext("Expiry", "Roki uporabe");
        public static ltext s_btn_WorkingPlace = new ltext("Jobs", "Delovna mesta");
        public static ltext s_btn_Units = new ltext("Units", "Merske enote");
        public static ltext s_btn_Currency = new ltext("Currency", "Valute");
        public static ltext s_btn_Taxation = new ltext("Taxation", "Davčne stopnje");
        public static ltext s_CodeTables = new ltext("Code tables", "Šifranti");
        public static ltext s_YouHaveChangedLanguageYouMustRestartProgramToUseNewLanguage = new ltext("You have selected another language.\r\nYou must restart program to use another language.", "Izbrali ste drug jezik. Da bo program delal v novem jeziku, ponovno zaženite program.");
        public static ltext s_lbl_SimpleItems = new ltext("Store A", "Trgovina A");
        public static ltext s_lbl_SelectedSimpleItems = new ltext("Selected in Store A", "Izbrano iz A");
        public static ltext s_lbl_Items = new ltext("Items", "Artikli");
        public static ltext s_lbl_Stock = new ltext("Stock", "Zaloge");
        public static ltext s_lbl_StoreA_SelectetItems = new ltext("Store B selected items", "Trgovina B izbrani artikli");

        public static ltext s_YouHaveEnteredOrChangedDataButNotSavedThem_Save_YesNo = new ltext("You have entered or changed data but not saved them.\r\nSave data ?", "Vnesli ali spremenili ste podatke a niste jih shranili.\r\nShranim podatke ?");

        public static ltext s_lbl_Item_Stock = new ltext("Stocks for item:", "Zaloge artikla:");
        public static ltext s_YouCanNotEditItemsUntilAllBasketsAreEmpty = new ltext("You can not edit items as long you have items in baskets!", "Najprej spraznite vse košare, da bi lahko urejali artikle !");
        public static ltext s_YouCanNotEditStockUntilAllBasketsAreEmpty = new ltext("You can not edit stock as long you have items in baskets!", "Najprej spraznite vse košare, da bi lahko urejali zaloge !");

        public static ltext s_chk_Storno = new ltext("Storno", "Storno");

        public static ltext s_Shop_A = new ltext("A", "A");
        public static ltext s_Shop_B = new ltext("B", "B");
        public static ltext s_Shop_C = new ltext("C", "C");
        public static ltext s_Shop_AB = new ltext(s_Shop_A.sText(0)+"&"+ s_Shop_B.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1));
        public static ltext s_Shop_BC = new ltext(s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1));
        public static ltext s_Shop_AC = new ltext(s_Shop_A.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_C.sText(1));
        public static ltext s_Shop_ABC = new ltext(s_Shop_A.sText(0) + "&" + s_Shop_B.sText(0) + "&" + s_Shop_C.sText(0), s_Shop_A.sText(1) + "&" + s_Shop_B.sText(1) + "&" + s_Shop_C.sText(1));

        public static ltext s_Abort = new ltext("Abort", "Prekini");
        public static ltext s_Retry = new ltext("Retry", "Ponovi");
        public static ltext s_Ignore = new ltext("Ignore", "Ignoriraj");

        public static ltext s_Are_Sure_To_Remove_All_From_Basket = new ltext("Are you sure to remove all items from basket ?", "Ste prepričani, da želite prestaviti vse artikle nazaj iz košare?");
        public static ltext s_InvoiceDraftTime_description = new ltext("Invoice Draft Time", "Čas izdelave osnutka računa");
        public static ltext s_InvoiceTime_description = new ltext("Invoice Time", "Čas izdaje računa");
        public static ltext s_InvoicePaidTime_description = new ltext("Invoice Paid Time", "Čas plačila računa");
        public static ltext s_InvoiceStornoTime_description = new ltext("Invoice Storno Time", "Čas stornacije računa");
        public static ltext s_DocInvoiceTime_description = new ltext("Invoice Time", "Čas izdaje računa");
        public static ltext s_DocProformaInvoiceTime_description = new ltext("Proforma Invoice Time", "Čas izdaje predračuna");
        public static ltext s_Konto_Price_with_tax_for_cash = new ltext("Price with tax (CASH) Konto=", "Znesek z DDV (gotovina) Konto=");
        public static ltext s_Konto_Price_with_tax_for_payment_cards = new ltext("Price with tax (CARDS) Konto=", "Znesek z DDV (kartice) Konto=");
        public static ltext s_Konto_Net_price = new ltext("Net price Konto=", "Neto cena Konto=");
        public static ltext s_Konto_VAT_general_rate = new ltext("VAT Konto=", "DDV splošna stopnja Konto=");
        public static ltext s_End_Customers_Code = new ltext("End Customers code=", "Končni kupci Šifra=");
        public static ltext s_End_Customes_Name = new ltext("End Customers name=", "Končni kupci naziv=");

        public static ltext s_VODxml_export_for = new ltext("VOD xml export for period", "Izvoz faktur v VOD XML datoteko za obdobje od");
        public static ltext s_you_can_do_VODxml_Output_just_for_past_month = new ltext("You can do VOD xml export just for any month in the past!", "Izvoz faktur v VOD XML datoteko lahko naredite samo za katerikoli že pretekli mesec!");
        public static ltext s_you_must_have_select_one_month_period_to_do_VODxml_Output = new ltext("There must be selectedt exactly one month period of invoices to do VOD xml ouptut!", "Izbrani računi morajo pripadati točno izbranemu celemu mesecu, da bi lahko naredili izvoz faktur v VOD XML datoteko!");
        public static ltext s_Can_not_read_VOD_shema_file_Do_you_want_to_exit = new ltext("Can not read VOD shema file %%SHEMAFILE.You can not export VOD XML file unless shema file is defined!\r\nDo you want to exit?", "Napaka pri branju VOD shema datoteke %%SHEMAFILE.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?");
        public static ltext s_YouDidnot_select_VOD_shema_file_Do_you_want_to_exit = new ltext("You didn't select VOD shema file.You can not export VOD XML file unless shema file is defined!\r\n Do you want to exit?", "Niste izbrali VOD shema datoteke.\r\nBrez VOD shema datoteke ni možno izvoziti faktur v VOD XML datoteko!\r\nŽelite končati?");


        public static ltext s_VOD_xml_shema_file_path = new ltext("OPAL VOD XSD shema file", "OPAL VOD XML shema:");

        public static ltext s_Export_to_VOD_XML = new ltext("OPAL VOD XML export", "Izvoz v OPAL VOD XML");

        public static ltext s_XML_files_Saved_OK = new ltext(" are saved ok.", " sta uspešno zapisani.");
        public static ltext s_VOD_XML_File = new ltext("VOD XML file:", "XML datoteka po VOD standardu:");
        public static ltext s_XML_Files = new ltext("XML files:", "Datoteki za XML:");
        public static ltext s_SelectObligatoryWriteReasonForStorno = new ltext("Select existing reason to reverse invoice", "Izberite že vnešen razlog za stornacijo računa");
        public static ltext s_ObligatoryWriteReasonForStorno = new ltext("Write new reason to reverse invoice", "Spodaj vpišite nov razlog za stornacijo računa");
        public static ltext s_YouCanNotCnacelInvoiceStorno = new ltext("You can not reverse reversed invoice to invoice!", "Razveljavitev stornacije računa ni možna. Napišite nov račun!");
        public static ltext s_WriteReasonForStorno = new ltext("Write reason text to reverse invoice!", "Napisati morate razlog za stornacijo računa!");
        public static ltext s_Price = new ltext("Price", "Cena");
        public static ltext s_Storno_Instruction = new ltext("To reverse Invoice select or write reason and click STORNO button", "Za stornacijo računa izberite ali napišite razlog in kliknite na gumb Storno");
        public static ltext s_STORNO = new ltext("REVERSE", "STORNO");
        public static ltext s_Storno = new ltext("Reverse Invoice", "Stornacija računa");
        public static ltext s_DURS_Files = new ltext("Durs files:", "Datoteki za DURS:");
        public static ltext s_DURS_files_Saved_OK = new ltext(" are saved ok.", " sta uspešno zapisani.");
        public static ltext s_Err_Write_File = new ltext("Error writing file:", "!Prišlo je do napake pri pisanju doatoteke:");
        public static ltext s_NoInvoicesData = new ltext("There are now invoices for DURS in selected period", "DURS Izpis za izbrano obdbobje je prazen!");


        public static ltext s_VODxml_OPAL_export = new ltext("VOD XML OPAL export", "Izpis XML VOD OPAL");
        public static ltext s_XML_export = new ltext("XML export", "Izpisi XML");
        public static ltext s_DURS_output = new ltext("Tax inspection output", "DURS Izpisi");
        public static ltext s_Value = new ltext("Value", "Podatek");
        public static ltext s_MustBeUnique = new ltext(" must be unique", " morajo biti unikatni");
        public static ltext s_Data_in_Column = new ltext("Data in Column", "Podatki v stolpcu");
        public static ltext s_Add_Customer_to_invoice = new ltext("Add customer to (proforma)invoice", "Dodaj stranko na (pred)račun");
        public static ltext s_DateOfBirth = new ltext("Date of Birth", "Datum rojstva");

        public static ltext s_WriteOnYourAccount = new ltext("write on the (profroma)invoice?", "vpisati na (pred)račun ?");
        public static ltext s_DoYouWantPerson = new ltext("Do You want customer:", "Želite stranko:");
        public static ltext s_MethodOfPayment = new ltext("Payment type", "Način plačila");
        
        public static ltext s_Sum_All = new ltext("Total = ", "Skupaj = ");
        public static ltext s_Sum_Tax = new ltext("Tax = ", "Davek = ");
        public static ltext s_Sum_WithoutTax = new ltext("Net price = ", "Brez davka = ");

        public static ltext s_Today = new ltext("Today", "Danes");
        public static ltext s_ThisWeek = new ltext("This week", "Ta teden");
        public static ltext s_LastWeek = new ltext("Last week", "Prejšni teden");
        public static ltext s_ThisMonth = new ltext("This month", "Ta mesec");
        public static ltext s_LastMonth = new ltext("Last month", "Prejšni mesec");
        public static ltext s_ThisYear = new ltext("This year", "To leto");
        public static ltext s_LastYear = new ltext("Last Year", "Prejšne leto");
        public static ltext s_TimeSpan = new ltext("Time span", "Obdobje");

        public static ltext s_from = new ltext("from", "od");
        public static ltext s_to = new ltext("to", "do");

        public static ltext s_ShowAll = new ltext("Show all", "Prikaži vse");
        public static ltext s_AreYouSureToCancelStornoOfThisInvoice = new ltext("Are you sure to cancel Storno of this invoice?", "Ali zares želite razveljaviti stornacijo računa ?");
        public static ltext s_AreYouSureToStornoThisInvoice = new ltext("Are you sure to Storno this invoice?", "Ali zares želite stornirati račun ?");
        public static ltext s_RealGrossSumIs = new ltext("Correct gross price = ", "\r\nPravilna končna cena = ");
        public static ltext s_WrongGrossSum = new ltext("Wrong gross price =", "Nepravilna končna cena =");

        public static ltext s_RealTaxSumIs = new ltext("Correct tax = ", "\r\nPravilen davek = ");
        public static ltext s_WrongTaxSum = new ltext("Wrong tax sum =", "Nepravilna davek =");

        public static ltext s_RealNetSumIs = new ltext("Correct net sum = ", "\r\nPravilna cena brez davka = ");
        public static ltext s_ForDocInvoiceNumber = new ltext(" for invoice number =", " za račun št.= ");
        public static ltext s_ForDocProformaInvoiceNumber = new ltext(" for proforma invoice number =", " za predračun št.= ");
        public static ltext s_WrongNetSum = new ltext("Wrong total sum without tax =", "Nepravilna cena brez davka =");

        public static ltext s_If_you_want_to_change_the_tax_only_to_the_selected_article___ = new ltext("If you want to change the tax only to the selected article (service), click (No).\r\nIf you want to change the tax to all trade items click the button (Yes).",
                                                                                         "Če želite spremeniti davek samo izbranemu artiklu (storitvi) kliknite gumb (Ne).\r\nČe želite spremeniti davek vsem artiklom kliknite gumb (Da).");

        public static ltext s_belongs_to_many_other_trade_items_and_services = new ltext("belongs to many other trade items and services."," pripada tudi mnogim drugim artiklom in storitvam.");
        public static ltext s_Tax_with_name = new ltext("Tax whose name is ", "Davek katerega ime je ");
        public static ltext s_PrinterNotSuported = new ltext("Printig receipts with printer %%% is not suported:", "Z izbranim tiskalnikom %%% ni možno tiskati račune.\nIzberite drug tiskalnik.");

        public static ltext s_dgv_SimpleItems_column_SimpleItem_Abbreviation = new ltext("Abbreviation","Oznaka");
        public static ltext s_dgv_SimpleItems_column_RetailSimpleItemPrice = new ltext("Price","Cena");
        public static ltext s_dgv_SimpleItems_column_SimpleItem_Name = new ltext("Name","Ime");
        public static ltext s_dgv_SimpleItems_column_Discount = new ltext("Discount","Popust");
        public static ltext s_dgv_SimpleItems_column_PriceList_Name = new ltext("PriceList","Cenik");
        public static ltext s_dgv_SimpleItems_column_Taxation_Name = new ltext("Taxation","Davek");
        public static ltext s_dgv_SimpleItems_column_Taxation_Rate = new ltext("Taxation rate","Davčna stopnja");
        public static ltext s_dgv_SimpleItems_column_SimpleItem_Code = new ltext("Code","razvrst.št.");
        public static ltext s_dgv_SimpleItems_column_SimpleItem_Image_Image_Data = new ltext("Image","Slika");
        public static ltext s_dgv_SimpleItems_column_s1_name = new ltext("Group 1","Skupina 1");
        public static ltext s_dgv_SimpleItems_column_s2_name = new ltext("Group 2", "Skupina 2");
        public static ltext s_dgv_SimpleItems_column_s3_name = new ltext("Group 3", "Skupina 3");

        public static ltext s_RealyWantToExitProgram = new ltext("Do you realy want to end program? (Yes/No)", "Želite končati program? (Da/Ne)");
        public static ltext s_SelectTimeSpan = new ltext("Select time span", "Izberi obdobje");
        public static ltext s_FirstNameOfPersonThatPrintedInvoice = new ltext("First Name of person who printed invoice", "Ime osebe, ki je natisnila račun");
        public static ltext s_LastNameOfPersonThatPrintedInvoice = new ltext("Last Name of person who printed invoice", "Priimek osebe, ki je natisnila račun");
        public static ltext s_journal_invoice_type_PrintError = new ltext("Print Error:", "Tiskanja računa NAPAKA:");
        public static ltext s_journal_invoice_type_Print = new ltext("Print", "Tiskanja računa");
        public static ltext s_Journal_InvoicePrint = new ltext("Print journal for invoice", "Dnevnik tiskanja računa");
        public static ltext s_Issue = new ltext("Issue", "Izstavitev");
        public static ltext s_Head = new ltext("Head", "Glava");
            
        public static ltext s_ExtraDiscount = new ltext("Extra discount", "Dodaten popust");
        public static ltext s_PriceListDiscount = new ltext("PriceList discount", "Popust po ceniku");
        public static ltext s_TotalDiscount = new ltext("Total discount", "Ves popust");

        public static ltext s_Draft = new ltext("Draft", "Osnutek");

        public static ltext s_Year = new ltext("Year", "Leto");
        public static ltext s_UpgradeDatabase = new ltext("Upgrade DataBase:", "Nadgradnja podatkovne baze:");
        public static ltext s_ImportData = new ltext("Importing data", "Uvoz podatkov");
        public static ltext s_BackupOfExistingDatabase = new ltext("Creating backup copy of existing DataBase :", "Ustvarjanje vranostne kopije obstoječe podatkovne baze:");
        public static ltext s_ReadTable = new ltext("Read Table :", "Berem tabelo :");
        public static ltext s_AllInvoiceDataAndArchiveAreDeleted = new ltext("All Invoices and Archive data are deleted!", "Vsi računi in arhiv so zbrisani!");
        public static ltext s_Start_NewFinancialYear = new ltext("Sart new financial Year", "Odprem novo obračunsko leto?");
        public static ltext s_Other = new ltext("...", "...");
        public static ltext s_AllInGroup = new ltext("All", "Vsi");

        public static ltext s_OrganisationData = new ltext("Organisation data", "Razširjeni podatki organizacije");
        public static ltext s_OrganisationBankAccounts = new ltext("Bank Accounts", "Bančni računi");
        public static ltext s_Customers_org = new ltext("Customer Organisation", "Stranka organizacija");
        public static ltext s_BankAccounts = new ltext("Bank Accounts", "Bančni računi");
        public static ltext s_PersonAccounts = new ltext("Person Accounts", "Osebni bančni računi");
        public static ltext s_Expanded_PersonData = new ltext("Detailed person data", "Razširjeni osebni podatki");
        public static ltext s_Customers_Person = new ltext("Customer person", "Stranke fizične osebe");
        public static ltext s_OnlyInOffer = new ltext("Only in offer", "Samo tiste v ponudbi");
        public static ltext s_AllItems = new ltext("All", "Vse");
        public static ltext s_OnlyNotInOffer = new ltext("Only those not in offer", "Samo tiste ki niso v ponudbi");

        public static ltext s_OnlyValidPriceList = new ltext("Only valid pricelists", "Samo veljavni Ceniki");
          public static ltext s_AllPriceList = new ltext("All PriceLists", "Vsi Ceniki");
          public static ltext s_OnlyUnvalid = new ltext("Only unvalid pricelists", "samo neveljavni Ceniki"); 

        public static ltext s_EditPriceList = new ltext("Edit Price List", "Urejanje Cenikov");
        public static ltext s_ItemPriceUndefined = new ltext("List of items which prices are undefined", "Seznam artiklov, ki nimajo določene prodajne cene");
        public static ltext s_SimpleItemPriceUndefined = new ltext("List of SimpleItems which prices are undefined", "Seznam storitev, ki nimajo določene cene");
        public static ltext s_PaymentAndPrint = new ltext("Payment and Print", "Način plačila in izdaja računa");
        public static ltext s_AmountReceived = new ltext("Amount received", "Prejeti znesek");
        public static ltext s_AcceptedCashAmount = new ltext("Amount received", "Vnesite prejeti znesek");
        public static ltext s_EndPrice = new ltext("Total", "Cena");

        public static ltext s_Print = new ltext("Print", "Tiskaj");
        public static ltext s_AlreadyPaid = new ltext("Already paid", "Že plačano");
        public static ltext s_ToReturn = new ltext("Money back", "Vračilo");
        public static ltext s_PaymentCard = new ltext("Payment Card", "Plačilna Kartica");

        public static ltext s_PaymentOnBankAccount = new ltext("Payment to Bank acount", "Plačilo na bančni račun");
        public static ltext s_Cash = new ltext("Cash", "Gotovina");
        public static ltext s_Amount = new ltext("Amount", "Znesek");

        public static ltext s_chk_PrintAll = new ltext("Print all at once", "Tiskaj vse naenkrat");
        public static ltext s_PaperName = new ltext("Paper Name", "Vrsta papirja");
        public static ltext s_Printer = new ltext("Printer", "Tiskalnik");
        public static ltext s_NotInPrinterList = new ltext(" is not installed.", " ni nameščen.");
        public static ltext s_SelectReceiptPrinter = new ltext("Select receipt printe", "Izbrati morate tiskalnik za tiskanje računov!");

        public static ltext s_Next = new ltext("Next", "Naprej");
        
        public static ltext s_Items_Text = new ltext("Items", "Artikli");

        public static ltext s_BuyerSelect = new ltext("Select", "Izberi");
        
        public static ltext s_Type = new ltext("Type", "Vrsta");
        public static ltext s_CardNumber = new ltext("Card Number", "Št. kartice");
        public static ltext s_Currency = new ltext("Currency", "Valuta");
        public static ltext s_Number = new ltext("Number", "Številka");
        public static ltext s_PriceList = new ltext("Price List", "Cenik");
        public static ltext s_UniqueName = new ltext("Unique name", "Unikatno ime");
        public static ltext s_Name = new ltext("name", "ime");
        public static ltext s_Pricelist_is_not_complete = new ltext("Pricelist is not complete", "Cenik je nepopoln");
        public static ltext s_SimpleItem_Not_in_PriceList = new ltext("SimpleItem not in pricelist:", "V ceniku manjkajo sledeče storitve:");
        public static ltext s_Item_Not_in_PriceList = new ltext("Item not in pricelist:", "V ceniku manjkajo sledeči artikli:");
        public static ltext s_PriceListIsNotUpdatedBecauseYouDidnotSelect = new ltext("Price List is not updated because you did not defined Tax rate!", "Cenik ni posodobljen z novimi artikli in/ali servisi, ker niste določili davčne stopnje!");
        public static ltext s_DataChangedSaveYourData = new ltext("You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?");
        public static ltext s_DataChangedDoYouWantToCloseYesNo = new ltext("You have changed data. Do you want to cancel edit?", "Vnesli ste podatke.\r\nŽelite prekiniti vnos?");
        public static ltext s_ExpiryDateFormText = new ltext("Expiry Date", "Rok uporabe");
        public static ltext s_PleaseDefineExpiryDate = new ltext("Define Expiry Date!", "Določite rok uporabe!");
        public static ltext s_Manage_PriceLists = new ltext("Manage PRICE LISTS", "UREJANJE CENIKOV");
        public static ltext s_TaxationTableHasNoData_YouMustEnterData_close_anyway = new ltext("Taxation table has no data. You must have at least one taxation row data!\r\nDo you realy want to cancel? ", "Tabela davčnih stopenj je prazna.\r\nVnesti morate vsaj eno davčno stopnjo!Želite kljub temu zapustiti dialog?");
        public static ltext s_PriceList_SimpleItems = new ltext("Pricelist SimpleItems","CENIK STORITEV");
        public static ltext s_PriceList_Items = new ltext("Pricelist Items", "CENIK ARTIKLOV");
        public static ltext s_PurchasePrice_Items = new ltext("PurchasePrice_Items", "NABAVNI CENIK ARTIKLOV");

        public static ltext s_Taxation = new ltext("Taxation", "Davki");
        public static ltext s_PriceListType = new ltext("Price List Type", "Ceniki");
        public static ltext s_NoPriceList_AskToCreatePriceList = new ltext("No Price List, Write Price List?", "Ni cenikov.\r\nVnesi cenike ?");
        public static ltext s_TherAreNoSimpleItemAndItemData = new ltext("There Are No SimpleItem And Item Data.Restart program, then enter SimpleItems, items and pricelists.", "Ni vnešenih artiklov in/ali storitev.\r\nPonovno zaženite program in vnesite podatke o storitvah in artiklih ter njihove cenike.");
        public static ltext s_SelectedCurrency = new ltext("Selected currency:", "Izbrana valuta:");
        public static ltext s_SelectDefaultCurrency = new ltext("Select default currency", "Izberi privzeto valuto");
        public static ltext s_Item = new ltext("Item", "Artikel");
        public static ltext s_NoItemData_EnterItemDataQuestion = new ltext("No item data. Enter item data ?", "Ni podatkov o artiklih. Vnesite podatke o artiklih?");

        public static ltext s_No_Price_SimpleItem_Data = new ltext("Pricelist for SimpleItems has no prices!", "V izbranem ceniku ni cen o vaših storitvah !");

        public static ltext s_NoSimpleItemData_EnterSimpleItemDataQuestion = new ltext("No SimpleItem data. Enter SimpleItem data ?", "Ni podatkov o vaših storitvah. Vnesite podatke o storitvah?");
        public static ltext s_Yes = new ltext("Yes", "Da");
        public static ltext s_No = new ltext("No", "Ne");
        public static ltext s_InTable = new ltext(" int Table ", " v tabeli ");
        public static ltext s_RowWithID = new ltext(" Row with ID = ", "Vrstica katere ID = ");
        public static ltext s_IsReferencedSeveralTimes = new ltext(" is referenced several times from other tables!", " je naslovljena večkrat tudi iz drugih tabel!");
        public static ltext s_IfYouChangeThisRowThisWillAffectAllRowsThatAreReferencingIt = new ltext("Changing data of this row will affect all rows from other tables that are referencing it.", "Če spremenite to vrstico, bo to imelo za posledico, da se bo spremenila vsebina vrstic v drugih tabelah, ki naslavljajo to vrstico.");
        public static ltext s_BellowIsTheListOfTableReferences = new ltext("Bellow is the list of table references.", "Spodaj so prikazane vrstice drugih tabel, ki naslavljajo navedeno vrstico.");
        public static ltext s_ChangeThisRowQuestion = new ltext("Change this row?", "Spremenim vrstico?");

        public static ltext s_ReferencedTableRow = new ltext("Referenced Table Row:", "Naslovljena vrstica:");
        public static ltext s_Tangenta = new ltext("Tangenta", "Tangenta");
        public static ltext s_null_means_nod_data = new ltext("null means no data", "nič pomeni da podatka ni");
        public static ltext s_ValueMustBeUnique = new ltext("Value must be unique!", "Podatek mora biti unikaten!");
        public static ltext s_null = new ltext("null", "brez");

        public static ltext s_CanNotBeNull = new ltext(": can not be undefined",
                                                                 ": ne sme biti nedoločeno!");
        public static ltext s_NumberOfTabelsToCreate = new ltext("Number Of Tabels To Create = ",
                                                                 "Število tabel v podatkovni bazi : ");
        public static ltext s_WaitToCreate_Tables = new ltext("Wait to create tables in database",
                                                               "Počakajte, da se naredijo tabele v podatkovni bazi");
        public static ltext s_Copyright_Tangenta = new ltext("(C)opyright Tangenta Public Licence.", "Ta program je zaščiten z licenco:\"(C)opyright Tangenta Public Licence!\"");
         
        public static ltext s_Stock_ID = new ltext("Stock ID",
                                                   "ID v Zalogah");

        public static ltext s_RetailPriceWithDiscount = new ltext("Price with discount:", "Cena s popustom:");

        public static ltext s_RetailPrice = new ltext("Price:", "Cena:");

        public static ltext s_Tax = new ltext("Tax",
                                                   "Davek");

        public static ltext s_TaxPrice = new ltext("Tax:",
                                                   "Davek:");

        public static ltext s_PriceWithoutTax = new ltext("Price without tax",
                                                          "Cena brez davka");
        public static ltext s_WithoutTaxPrice = new ltext("Without tax:",
                                                          "Cena brez davka:");


        public static ltext s_Stock_dQuantity = new ltext("Stock quantity",
                                                          "Kol. v skladišču");

        public static ltext s_RetailPricePerUnit = new ltext("Retail price per unit",
                                                                "Prodajna cena na enoto");

        public static ltext s_PurchasePricePerUnit = new ltext("Purchase price per unit",
                                                                "Nabavna cena na enoto");

        public static ltext s_ExpiryDate = new ltext("Expirx date",
                                                   "Rok uporabe");

        public static ltext s_Quantity = new ltext("Quantity:",
                                                   "Količina:");
        
        public static ltext s_Discount = new ltext("Discount:",
                                                   "Popust:");

        public static ltext s_Invoice = new ltext("Invoice",
                                                  "Račun");

        public static ltext s_DocProformaInvoice = new ltext("Proforma-Invoice",
                                                         "Predračun");

        public static ltext s_DocInvoice= new ltext("Invoice",
                                                         "Račun");

        public static ltext s_DocInvoice_From_DocProformaInvoice = new ltext("Invoice from Proforma-Invoice",
                                                                       "Račun iz Predračuna");

        public static ltext s_Stock = new ltext("Stock",
                                                "Zaloge");

        public static ltext s_Items = new ltext("Items",
                                                "Artikli");

        public static ltext s_ShopA_Items = new ltext("Shop A Items",
                                                   "Artikli/Storitve prodajalne A");

        public static ltext s_ShopB_Items = new ltext("Shop B Items",
                                                   "Artikli/Storitve prodajalne B");

        public static ltext s_btn_New = new ltext("New",
                                                    "Nov");

        public static ltext s_lbl_BuyerFirstName = new ltext("Buyer First Name",
                                                    "Kupec ime");

        public static ltext s_Buyer = new ltext("Buyer",
                                                    "Kupec");

        public static ltext s_Issuer = new ltext("Issuer",
                                                    "Izstavitelj");

        public static ltext s_MyOrganisation = new ltext("My organisation",
                                                    "Moja oragnizacija");

        public static ltext s_Office = new ltext("Office",
                                                    "Poslovna enota");

        public static ltext s_No_OrganisationData = new ltext("There is no data about your company. You must enter your company data first!",
                                                         "Ni podatkov o vašem podjetju. Najprej morate vnesti podatke o svojem podjetju");


        public static ltext s_No_MyOrganisation_StreetName = new ltext("There is no Street Name address of your company. You must enter Street Name address of your company!",
                                                         "Ni podatka o naslovu ulice vašega podjetja. Vnesti morate naslov ulice vašega podjetja");

        public static ltext s_No_MyOrganisation_HouseNumber = new ltext("There is no house number of your company. You must enter house number of your company!",
                                                         "Ni podatka o hišni številki vašega podjetja. Vnesti morate hišno številko vašega podjetja");

        public static ltext s_No_MyOrganisation_ZIP = new ltext("There is no ZIP of your company. You must enter ZIP of your company!",
                                                         "Ni podatka o številki pošte vašega podjetja. Vnesti morate številko pošte vašega podjetja");

        public static ltext s_No_MyOrganisation_City = new ltext("There is no city of your company. You must enter city of your company!",
                                                         "Ni podatka o kraju vašega podjetja. Vnesti morate kraj vašega podjetja");

        public static ltext s_No_MyOrganisation_Country= new ltext("There is no country of your company. You must enter country of your company!",
                                                             "Ni podatka v kateri državi je vaše podjetje. Vnesti morate državo v kateri je podjetje");

        public static ltext s_No_Office = new ltext("There is no office of your organisation. You must have at least one office in your organisation!",
                                                         "Vaše podjetje nima poslovnih enot,\nVpisati morate vsaj eno poslovno enoto!");

        public static ltext s_No_Office_Data = new ltext("There is no office address of your organisation. You must have office address in your organisation!",
                                                         "Vaše podjetje nima dodatnih  potakov poslovne enot (naslov, opis..),\nVpisati morate še podatke poslovne enote!");

        public static ltext s_No_Office_Data_FVI_SLO_RealEstateBP = new ltext("Missing Real Estate Data for your office. You need them for Fiscal verification of invoices in Slovenia!",
                                                                              "Vaša poslovna enota nima podatkov o poslovnem prosturu potrebnih za davčno potrjevanje računov,\nVpisati morate še podatke o poslovnem prostoru, ki so potrebni za davčno potrjevanje računov!");

        public static ltext s_No_MyOrganisation_Person = new ltext("There is no person of your company which is active. You must enter person of your company! (Also Check if Active flag is set!)",
                                                              "Vaše podjetje nima vsaj ene osebe, ki bi bila označena za aktivno.\nVnesti morate osebo ali osebe v vašem podjetju in pri tem mora imeti imeti najmanj ena oseba odkljukano, da je aktivna!");


        public static ltext s_No_MyOrganisation_name = new ltext("There is no name of your company. You must enter name of your company!",
                                                            "Vaše podjetje nima imena. Vnesti morate ime vašega podjetja");

        public static ltext s_No_MyOrganisation_Tax_ID = new ltext("There is no Tax ID of your company. You must enter Tax ID of your company!",
                                                            "Vaše podjetje nima davčne številke. Vnesti morate davčno številko vašega podjetja");
        
        public static ltext sRowsCount = new ltext("Rows count = ", "Število vrstic = ");

        public static ltext s_Format = new ltext("Format", "Format");

        public static ltext s_Width = new ltext("width", "širina");
        public static ltext s_Height = new ltext("height", "višina");
        public static ltext s_Size = new ltext("Size", "Velikost");
        public static ltext s_Bytes = new ltext("Byte", "Bytov");
        public static ltext s_Byte = new ltext("Byte", "Byte");
        public static ltext s_ResizeImage = new ltext("Resize Image", "Spremeni Velikost Slike");
        public static ltext s_KeepAspectRation = new ltext("Keep aspect ration", "Ohrani razmerje med širino in višino");

        public static ltext s_Error_Insert_Unique_the_same_allready_exists_at_id = new ltext("\r\nThe same value allready exists at ID =  %I64d", "\r\nIsta vrednost že obstaja pri ID =  %I64d");

        public static ltext s_Error_Insert_Unique = new ltext("Error, Can not insert values into table %s because of Unique constraint violation ", "Napaka pri vnosu v tabelo %s, ker unikatna vrednost že obstaja (angl. >>Unique constraint<<). Podrobno ");

        public static ltext s_AreYouSureToDeleteView = new ltext("Are you sure to delete view", "Ste prepričani izbrisati prikaz");
        public static ltext s_DeleteViewTitle = new ltext("Delete View", "Zbriši prikaz");

        public static ltext s_Close = new ltext("Close",
                                         "Zapri");

        #region s_SelectViewForTable

        public static ltext s_DeleteViewForTable = new ltext("Delete view for table:",
                                                             "Zbriši prikaz tabele:");

        public static ltext s_SelectViewForTable = new ltext("Select view for table:",
                                                             "Izberi prikaz tabele:");
        public static ltext s_Select = new ltext("Select",
                                                 "Izberi");

        public static ltext s_SelectAsDefaultView = new ltext("Select as default View",
                                                              "Izberi kot privzeti prikaz");

        public static ltext s_SelectedView = new ltext("Selected View = ",
                                                       "Izbrani prikaz = ");

        public static ltext s_TableView = new ltext("Table View ",
                                                       "Vnešeni prikaz tabele ");

        public static ltext s_DoesNotExist = new ltext(" does not exist!",
                                                       " ne obstaja!");

        #endregion


        public static ltext s_Question = new ltext("?", "?");

        public static ltext s_CreateNewViewQuestion = new ltext("Create new View? \r\nIf yes current column selection will be lost !",
                                                        "Ustvarim nov prikaz? \r\nČe kliknete gumb Da, boste izbrisali trenutni izbor stolpcev !");

        public static ltext s_SelectColumnsBeforeShow = new ltext("You have not selected columns to show the view.\r\nSelect columns by dragging them in arrows directions.",
                                                                     "Niste izbrali stolpcev za prikaz.\r\nIzberite jih s povlačenjem kot kažeta puščici.");

    public static ltext s_Descending = new ltext("Descending",
                                                         "Padajoče");
    public static ltext s_DeleteView = new ltext("Delete", "Zbriši");
    public static ltext s_Connection_To_LogTables_defualt_ProgramSettings = new ltext("Connection to DB with Log Tables (default Database=ProgramSettings)", "Povezava na podatkovno bazo z Log Tabelami (privzeta Baza:LogFile)");

    public static ltext s_AddAttachment = new ltext("Add Attachment", "Dodaj Priponko");

    public static ltext s_Picture = new ltext("Picture", "Slika");

    public static ltext s_Attachment = new ltext("Attachment", "Priponka");

    public static ltext s_DoesNotExistOrWasDeleted = new ltext(" does not exist or was deleted!",
                                                   " ne obstaja ali pa je bila zbrisana!");

    public static ltext s_Add_Picture = new ltext("Add Picture", "Dodaj sliko");

    public static ltext s_Write2DB = new ltext("Write to DataBase", "Vpiši v bazo");

    public static ltext s_ConnectionToLogFileDataBase = new ltext("Connection to DataBase:", "Povezava na podatkovno bazo:");
    public static ltext s_LogFile_Lines = new ltext("Log file lines:", "Število vrstic dnevniške datoteke(\"Log file\"):");

    public static ltext s_ImportLogFileToDatabase = new ltext("Import LogFile to DataBase", "Uvozi dnevniško datoteko v podatkovno bazo");

    public static ltext s_DontWriteLogs = new ltext("Do not write Logs", "Ne piši dnevniške datoteke");




    public static ltext s_TimerStopAlert_Text = new ltext("Timer Stop Alert", "Ura izklopi opozorila");
    public static ltext s_TimerStopEnablePress_Text = new ltext("TimerStopEnablePress", "Ura izklopi omogočanje preše");
    public static ltext s_LastWrittenInRemoteDB_Form = new ltext("Last Written In RemoteDB", "Nazadnje vpisani v centralno bazo");

    public static ltext s_ProgramSettings = new ltext("Program Settings", "Nastavitve programa");
    public static ltext s_PutIn_Settings_Saved = new ltext("Import settings are saved OK", "Nastavitve za uvoz so shranjene.");
        #region LangSIMON

    public static ltext ss_UNKNOWN_ERROR_CHECK_SENSOR = new ltext("Uknown Error Check Sensor Leuze", "Nepozana napaka senzorja Leuze");
    public static ltext ss_NO_ANSWER_FROM_SENSOR_LEUZE = new ltext("No answer from sensor Leuze", "Senzor Leuze ne komunicira");
    public static ltext ss_WRONG_CHAR_SET_ON_PRESS = new ltext("Wrong char on press", "Napačen znak na preši");
    public static ltext ss_MORE_CHAR_ON_PRESS_THEN_NEEDED = new ltext("More chars on press than needed", "Več znakov na preši kot je potrebno");
    public static ltext ss_LESS_CHAR_ON_PRESS_THEN_NEEDED = new ltext("Less chars on press than needed", "Manj znakov na preši kot je potrebno");
    public static ltext ss_COULDNT_START_APLICATION = new ltext("Can not start application:", "Ne morem zagnati aplikacije:");
    public static ltext ss_PRESS_IS_READY = new ltext("Press ready", "Preša pripravljena");
    public static ltext ss_PROCESSING = new ltext("Processing", "Procesiranje");


    public static ltext ss_RepairRegular = new ltext("Repair Regular", "Popravilo serij");
    public static ltext ss_mrvl_code_not_defined = new ltext("mrvl code not defined", "MRVL koda ni definirana");
    public static ltext ss_mrvl_code_allready_exist = new ltext("mrvl code allready exist", "MRVL koda že obstaja");
    public static ltext ss_lblLptAdress = new ltext("LPT Address", "LPT Naslov");
    public static ltext ss_grbLptPortSettings = new ltext("Shield LPT Port", "Grbi LPT Port");
    public static ltext ss_grbProcessSettings = new ltext("Shield Process Settings", "Lepljenje Grbov Nastavitve");

    public static ltext ss_Pack = new ltext("Pack", "Pakiranje");
    public static ltext ss_SeriesRegular = new ltext("Series", "Serije");
    public static ltext ss_ClosePressForm = new ltext("Close Press Form", "Zapri Okno za prešo");
    public static ltext ss_VehiclePlatesList_id	= new ltext("VehiclePlatesList_id","VehiclePlatesList_id");
    public static ltext ss_Abbreviation	= new ltext("Abbreviation","Okrajšava");
    public static ltext ss_About = new ltext("About","O programu");
    public static ltext ss_Add = new ltext("Add","Dodaj");
    public static ltext ss_AddIntervals = new ltext("Add intervals","Dodaj intervale");
    public static ltext ss_Address = new ltext("Address","	Naslov");
    public static ltext ss_Administration = new ltext("Administration","Administracija");
    public static ltext ss_Administrator = new ltext("Administrator","Administrator");
    public static ltext ss_All = new ltext("All","Vse");
    public static ltext ss_AlreadyExists = new ltext("Already exists","Že obstaja");
    public static ltext ss_AvailablePlates = new ltext("Available plates","	Tablice na voljo");
    public static ltext ss_BaudRate = new ltext("BaudRate","Hitrost prenosa");
    public static ltext ss_Browse = new ltext("Browse","Razišči");	   
    public static ltext ss_BeforeYouStart = new ltext("before you start"," preden zaženete");
    public static ltext ss_Cancel = new ltext("Cancel","Prekliči");
    public static ltext ss_Cascade = new ltext("Cascade","Razporedi okna v kaskado ");
    public static ltext ss_Change = new ltext("Change","Spremeni");
    public static ltext ss_ChangeAccountingDataBaseConnection = new ltext("Change Connection To Accounting DataBase","Spremeni povezavo na računovodsko bazo podatkov");
    public static ltext ss_ChangeImage = new ltext("Change image"," Zamenjaj sliko");
    public static ltext ss_ChangePassword = new ltext("Change password","Zamenjaj geslo");
    public static ltext ss_ChangeProductionDataBaseConnection = new ltext("Change Connection To Production DataBase"," Spremeni povezavo na produkcijsko bazo podatkov");
    public static ltext ss_ChangesProcessed = new ltext("Changes processed"," Spremembe končane");
    public static ltext ss_ChangesWillBeLost = new ltext("Changes will be lost.	"," Spremembe se ne bodo upoštevale.");
    public static ltext ss_ChangesWillTakeEffectOnNexStart = new ltext("Changes will take effect on next start"," Spremebe bodo stopile v veljavo ob naslednjem zagonu programa	");
    public static ltext ss_Char = new ltext("Char","	Znak");
    public static ltext ss_CharacterMismatch = new ltext("Character mismatch","	Znaki se ne ujemajo");
    public static ltext ss_Chars = new ltext("Chars:","	Znaki:");
    public static ltext ss_check_if_Ean_count_matches_for_series = new ltext("Check if EAN count matches for series"," Preverjanje  EAN števil za serije");
    public static ltext ss_check_if_Ean_count_matches_for_series_R4 = new ltext("Check if EAN count matches for series R4"," 	Preverjanje  EAN števil za serije R4");
    public static ltext ss_check_if_Ean_count_matches_for_SimpleItems = new ltext("Check if EAN count matches for SimpleItems"," Preverjanje  EAN števil za servise	");
    public static ltext ss_check_if_Ean_count_matches_for_SimpleItems_R4 = new ltext("Check if EAN count matches for SimpleItems R4"," Preverjanje  EAN števil za servise R4	");
    public static ltext ss_check_update_status_set_pressed_pressed_r4 = new ltext("Check and update status, shield data and packed data"," Preverjanje statusov, grbov in pakiranj	");
    public static ltext ss_CheckComplete = new ltext("Check complete","Preveri končane	");
    public static ltext ss_CheckOrdersProgress = new ltext("Check Pantheon progress","Preveri napredek v Pantheonu	");
    public static ltext ss_CheckOrdersStatus = new ltext("Check Order Status"," 	Preveri napredek naročil");
    public static ltext ss_CheckSize = new ltext("Check plate size"," Preveri velikost tablic");
    public static ltext ss_CheckStatus = new ltext("Check orders progress"," 	Preveri napredek naročil");
    public static ltext ss_ChooseDate = new ltext("Choose date	"," Izberi datum");
    public static ltext ss_ClearLast = new ltext("Undo","	Razveljavi");
    public static ltext ss_Close = new ltext("Close","	Zapri");
    public static ltext ss_Closed = new ltext("Closed","	Zaprto");
    public static ltext ss_CloseProgram = new ltext("Close Press Window","	Zaprite okno za prešo");
    public static ltext ss_Column = new ltext("Column","	Stolpec	");
    public static ltext ss_Complex_Stamps_system = new ltext("Stamp system","	Štempiljski sistem");
    public static ltext ss_ConfirmPassword = new ltext("Confirm password","	Potrdi geslo");
    public static ltext ss_ConfirmProduction = new ltext("Confirm production","	Potrdi izdelavo");
    public static ltext ss_ConfirmProductionOrder = new ltext("Confirm production - Order number: ","	Potrdi izdelavo - številka naročila:");
    public static ltext ss_Connected = new ltext("Connected","	Priključeno");
    public static ltext ss_Continue = new ltext("Do you want to continue?","	Ali želite nadaljevati?");
    public static ltext ss_CorrectIrta = new ltext("Correct orders","	Popravi naročilo");
    public static ltext ss_CorrectPack = new ltext("Correct packing	","Popravilo pakiranja");
    public static ltext ss_CorrectPlateOther = new ltext("Correct plate - other	","Popravilo tablic - ostale");
    public static ltext ss_CorrectPlateR4 = new ltext("Correct plate - R4	","Popravilo tablic - R4");
    public static ltext ss_CorrectPlateStandard = new ltext("Correct plate - standard"," 	Popravilo tablic - standardne");
//    COULDNT_START_APLICATION	ExE aplikacija se ni zagnala. Preveri nastavitve!");
     public static ltext ss_Count = new ltext("Count","	Število	");
    public static ltext ss_CreateEAN = new ltext("Create EAN codes"," 	Ustvari EAN kode");
    public static ltext ss_CreateInterval = new ltext("Create interval	"," Ustvari intervale");
    public static ltext ss_Custom = new ltext("Custom","Izbirna");
    public static ltext ss_Customer = new ltext("Customer","Stranka");
    public static ltext ss_Customer_id = new ltext("Customer_id"," šifra stranke  (\"Customer_id\")");
    public static ltext ss_CustomerCode = new ltext("Customer code"," Šifra stranke");
    public static ltext ss_CustomerDoesntExist = new ltext("Customer doesn't exist"," Stranka ne obstaja");
    public static ltext ss_CustomerEnabled = new ltext("Customer enabled","	Stranka vključena");
    public static ltext ss_CustomerId = new ltext("Customer id	"," ID stranke");
    public static ltext ss_CustomerNotEnabled = new ltext("Customer not enabled	"," Stranka ni vključena");
    public static ltext ss_CustomerShield = new ltext("Customer shield	"," Grb stranke");
    public static ltext ss_DataBase = new ltext("DataBase"," Podatkovna baza");
    public static ltext ss_DatabaseConnectionAccounting = new ltext("Connection to Accounting database"," Podatkovna baza računovodstva");
    public static ltext ss_DatabaseConnectionProduction = new ltext("Connection to Production database","Podatkovna baza proizvodnje");
    public static ltext ss_DatabaseError = new ltext("Database error","Napaka v bazi");
    public static ltext ss_Date = new ltext("Date"," Datum	");
    public static ltext ss_DateLastChange = new ltext("Last change","Zadnja sprememba");
    public static ltext ss_DateOrder = new ltext("Date order"," Datum naročila");
    public static ltext ss_Day = new ltext("Day"," Dan");
    public static ltext ss_Delay = new ltext("Delay","Zakasnitev");
    public static ltext ss_DeleteImage = new ltext("Delete image"," Odstrani sliko");
    public static ltext ss_Delimeter = new ltext("Delimeter	"," Delimeter");
    public static ltext ss_Denied = new ltext("Denied","Zavrnjeno");
    public static ltext ss_Deny = new ltext("Deny","Zavrni");
    public static ltext ss_DenyReason = new ltext("Deny reason","Razlog zavrnitve");
    public static ltext ss_Description = new ltext("Description	","Opis");
    public static ltext ss_DescriptionInternal = new ltext("Internal description"," Interni opis");
    public static ltext ss_DescriptionMrvl = new ltext("Description Orders	"," Opis MRVL");
    public static ltext ss_DescriptionPantheon = new ltext("Description Pantheon","	Opis Pantheon");
    public static ltext ss_DisableCharChecking = new ltext("Disable char checking","	Izklopi preverjanje znakov");
    public static ltext ss_District = new ltext("District"," Okrožje");
    public static ltext ss_DistrictAndShieldEnabled = new ltext("District and shield enabled"," Okrožje in grb vključena");
    public static ltext ss_DistrictAndShieldFromCustomer = new ltext("District and shield from customer"," Okrožje in grb iz stranke");
    public static ltext ss_DistrictAndShieldFromShield = new ltext("District and shield from shield"," Okrožje in grb iz grba");
    public static ltext ss_DoInterval = new ltext("Support intervals"," Podpira interval");
    public static ltext ss_DoneProcessing = new ltext("Done processing"," Procesiranje končano");
    public static ltext ss_EAN = new ltext("EAN"," EAN");
    public static ltext ss_EANalreadyExists = new ltext("EAN already exists","EAN že obstaja");
    public static ltext ss_EANcodeExists  = new ltext("EANcodeExists","EAN koda že obstaja");
    public static ltext ss_EANincorrect = new ltext("EAN incorrect","Napačen EAN");
    public static ltext ss_EANNew = new ltext("New EAN"," Novi EAN");
    public static ltext ss_EANOld = new ltext("Old EAN","	Stari EAN");
    public static ltext ss_EditCharacters = new ltext("Edit characters"," Urejanje znakov");
    public static ltext ss_EditCustomers = new ltext("Edit customers"," Uredi stranke");
    public static ltext ss_EditDistricts = new ltext("Edit districts"," Uredi okrožja	");
    public static ltext ss_EditIntervals = new ltext("Edit intervals"," Uredi intervale");
    public static ltext ss_EditNumericSystems = new ltext("Numeric Systems Editor","Urejevalnik številskih sistemov");
    public static ltext ss_EditPantheonIdents = new ltext("Edit pantheon idents	","Uredi idente Pantheona");
    public static ltext ss_EditPasswords = new ltext("Enter password	"," Vpišite geslo");
    public static ltext ss_EditPlateForms = new ltext("Edit plate number/formats"," Uredi formate tablic");
    public static ltext ss_EditPlateVersions = new ltext("Edit plate versions","	Uredi verzije tablic");
    public static ltext ss_EditPressSettings  = new ltext("Edit Press Settings","Nastavitev preše");
    public static ltext ss_EditSettings = new ltext("Edit settings"," Uredi nastavitve");
    public static ltext ss_EditShields = new ltext("Edit shields","	Uredi grbe");
    public static ltext ss_EditUsers = new ltext("Edit users	"," Uredi uporabnike");
    public static ltext ss_EditWorkingPlaces = new ltext("Edit WorkingPlaces	"," Uredi stroje");
    public static ltext ss_Enabled = new ltext("Enabled	"," Vključeno");
    public static ltext ss_EndInterval = new ltext("End interval","	Konec intervala	");
    public static ltext ss_EndSeries = new ltext("End","	Končaj");
    public static ltext ss_EndWorkInProgressFirst = new ltext("End work in progress first","	Najprej končaj delo v postopku.");
    public static ltext ss_EnterDenyReason = new ltext("Enter deny reason","	Vnesi razlog zavrnitve	");
    public static ltext ss_EnterPrintNumber = new ltext("Enter print number","	Vnesi številko tiska");
    public static ltext ss_Error = new ltext("Error","Napaka	");
    public static ltext ss_ErrorCheckingIntervals = new ltext("Error checking intervals","	Napaka pri preverjanju intervalov");
    public static ltext ss_ErrorDescription = new ltext("Error description","	Opis napake");
    public static ltext ss_ErrorImportTextDocument = new ltext("Error import text document","	Napaka pri uvozu tekstovne datoteke");
    public static ltext ss_ErrorInXMLdocument = new ltext("Error in XML document","	Napaka v XML dokumentu");
    public static ltext ss_ErrorsFound = new ltext("Errors found","	Obstajajo napake");
    public static ltext ss_ErrorUsersTableNotInitializide = new ltext("Users Table has not User \"administrator\" in first row!","Uporabniška tabela (\"Users\") nima uporabnika \"administrator\" v prvi vrstici!");
    public static ltext ss_ErrorUsersTableNotRead = new ltext("Error Users Table Not Read!","Uporabniška tabela ni bila uspešno prebrana");
    public static ltext ss_ExceededLength = new ltext("Exceeded length","Prekoračena dolžina");
    public static ltext ss_ExceededLengthBike = new ltext("Exceeded bike length","Prekoračena dolžina za motor");
    public static ltext ss_ExceededLengthNarrow = new ltext("Exceeded narrow length","	Prekoračena ožana dolžina");
    public static ltext ss_Exit = new ltext("Exit","	Izhod");
    public static ltext ss_ExportOrders = new ltext("Export orders","	Izvoz dobavnic");
    public static ltext ss_False = new ltext("false","	Ne");
    public static ltext ss_FileNotFound = new ltext("File not found","	Nisem našel datoteke");
    public static ltext ss_FillByWorkingPlaceseries_Empty = new ltext("There is no series of regular plates to produce","Ni zaloge za serijo standardnih tablic");
    public static ltext ss_FillByWorkingPlaceSimpleItem_Empty = new ltext("There is no SimpleItem of regular plates","Ni  naloge servisa standardnih tablic ");
    public static ltext ss_FirstName = new ltext("First name","	Ime");
    public static ltext ss_Font = new ltext("Font","Pisava	");
    public static ltext ss_FontNarrow = new ltext("Font narrow","Ozka pisava");
    public static ltext ss_FontNarrowHeight = new ltext("Font narrow size","Višina ozke pisave");
    public static ltext ss_FrameColor = new ltext("Frame Color","	Barva okvirja	");
    public static ltext ss_From = new ltext("from", "od");
    public static ltext ss_GrandTotal = new ltext("Grand total","Skupno");
//grbLptPortSettings grbLptPortSettings	Nastavitve LPT	");
//grbLptPortSettings grbProcessSettings	Nastavitev procesa	");
//grbRS232settings	Nastavitve Leuze RS232	");
    public static ltext ss_Ident = new ltext("Ident	"," Ident");
    public static ltext ss_ImportIrtaDone = new ltext("Import from Orders to Production is finished.","	Uvoz iz MRVL v IRTA končan");
//        ImportOffers, Uvoz naročil");
    public static ltext ss_ImportOrders = new ltext("Import orders","Uvozi naročila");
    public static ltext ss_ImportOrdersIBMWebSphere = new ltext("Import orders from IBM Web Sphere	"," Uvozi naročila IBM Web Sphere");
    public static ltext ss_ImportOrdersIBMWebSphereNotImplemented = new ltext("Import orders from IBM Web sphere is not active"," Uvozi naročila z IBM Web Sphere ni v uporabi");
    public static ltext ss_ltextImportRow = new ltext("Import Row	","Uvozi vrstico");
    public static ltext ss_IndexTables = new ltext("Index tables	","Šifranti");
    public static ltext ss_InProduction = new ltext("In production	","V izdelavi");
    public static ltext ss_Interval = new ltext("Interval","Interval");
    public static ltext ss_IntervalEnd = new ltext("Interval end"," Konec intervala	");
    public static ltext ss_IntervalEndAvailable = new ltext("Available end	"," Konec intervala na voljo");
    public static ltext ss_IntervalEndNew = new ltext("End of interval"," Konec novega intervala");
    public static ltext ss_IntervalError = new ltext("Interval error"," Napaka intervala");
    public static ltext ss_Intervals = new ltext("Intervals"," Intervali");
    public static ltext ss_IntervalStart = new ltext("Interval start"," Začetek intervala");
    public static ltext ss_IntervalStartAvailable = new ltext("Available start	"," Začetek intervala na voljo");
    public static ltext ss_IntervalStartNew = new ltext("Start of interval	"," Začetek novega intervala");
    public static ltext ss_InvalidCharacter = new ltext("Invalid character	","Napačen znak");
    public static ltext ss_InvalidData = new ltext("Invalid data","Napačni podatki	");
    public static ltext ss_InvalidDataEntered = new ltext("Invalid data entered	"," Vnešeni napačni podatki	");
    public static ltext ss_InvalidPassword = new ltext("Username and password don't match."," Uporabniško ime in geslo se ne ujemata");
    public static ltext ss_InvalidUserName = new ltext("User name does not exist","Uporabniško ime ne obstaja");
    public static ltext ss_Invoice = new ltext("Invoice	"," Dobavnica");
    public static ltext ss_InvoiceDate = new ltext("Invoice date"," 	Datum dobavnice	");
    public static ltext ss_InvoiceNote = new ltext("Invoice number","	Številka dobavnice");
    public static ltext ss_irta_code_allready_exist = new ltext("'irta_code' allready exists!", "'irta_code' ki ste ga vnesli že obstaja! Vnesite unikatno 'irta_code'.");
    public static ltext ss_irta_code_not_defined = new ltext("Field 'irta_code' may not be empty!"," 	Polje 'irta_code' ne sme biti prazno!");
    public static ltext ss_IrtaCode = new ltext("Production code"," Številka IRTA	");
    public static ltext ss_IrtaId = new ltext("Production ID"," ID IRTA	");
    public static ltext ss_KIG_MRVL_number_system = new ltext("KIG-MRVL number system"," KIG-MRVL številski sistem");
    public static ltext ss_Language = new ltext("Language"," Jezik	");
    public static ltext ss_LastName = new ltext("Last name"," Jezik	 ");
//        lblEanErr	Ean napaka	");
//lblErr	Napaka	");
//lblLptAdress	LPT naslov vrat	");
//lblPressRelease	Sprostitev preše	");
//lblQtyLeftToselect	Ostalo za izbrati");
    public static ltext ss_Length = new ltext("Length","Dolžina	");
    public static ltext ss_LengthBike = new ltext("Length bike"," Dolžina motorne	");
    public static ltext ss_LengthMismatch = new ltext("Lenght mismatch","	Dolžina se ne ujema	");
    public static ltext ss_LengthNarrow = new ltext("Length narrow","Dolžina ožane");
//        LESS_CHAR_ON_PRESS_THEN_NEEDED	Manj znakov na preši kot potrebno	");
    public static ltext ss_Line = new ltext("Line"," Vrstica	");
    public static ltext ss_Line1_X = new ltext("Frist line distance from left edge in mm"," Odmik prve vrstice od levega roba v mm");
    public static ltext ss_Line1_Y = new ltext("First line distance from top edge in mm	"," Odmik prve vrstice od zgornjega roba  v mm");
    public static ltext ss_Line2_X = new ltext("Second line distance from left edge in mm"," Odmik druge vrstice od levega roba v mm");
    public static ltext ss_Line2_Y = new ltext("Second line distance from top edge in mm"," Odmik druge vrstice od zgornjega roba v mm");
    public static ltext ss_Load = new ltext("Load"," Obremenitev");
    public static ltext ss_Login = new ltext("Log-in"," Prijava");
    public static ltext ss_MakeShield = new ltext("Make shield"," Vsebuje grb");
    public static ltext ss_MayNotBeNull = new ltext("may not be empty!"," ne sme biti prazen!");
    public static ltext ss_Month = new ltext("Month"," Mesec");
//        MORE_CHAR_ON_PRESS_THEN_NEEDED	Več znakov na preši kot je potrebno	");
    public static ltext ss_MrvlCode = new ltext("Orders code","Šifra MRVL");
    public static ltext ss_NewIntervals = new ltext("New intervals"," Novi intervali");
//        NO_ANSWER_FROM_SENSOR_LEUZE	Ni odgovora od senzorja Leuze	");
// NoEANcodeForCorrection	EAN koda še ni bila uporabljena	");
    public static ltext ss_NoRows = new ltext("No rows"," Novi intervali");
    public static ltext ss_NothingSelected = new ltext("Nothing selected","Nič ni izbrano ");
    public static ltext ss_NotInProduction = new ltext("Not in production"," 	Ni v izdelavi");
    public static ltext ss_NotNumeric = new ltext("Value is not numeric	"," Vrednost ni številka");
    public static ltext ss_NotPositive = new ltext("Value is not positive"," Vrednost ni pozitivna številka");
    public static ltext ss_NrOfSegments = new ltext("Nr. of segments"," Št. segmentov");
    public static ltext ss_NullTableValue = new ltext("Without"," BREZ");
    public static ltext ss_NumberFormat = new ltext("Number/Format	"," Število/Format");
    public static ltext ss_NumberFormatEnabled = new ltext("Number/Format enabled"," Število/Format vključena");
    public static ltext ss_NumberFormatId = new ltext("Number/Format id	"," ID Številka/Format");
    public static ltext ss_NumbersMismatch = new ltext("Numbers mismatch"," Številke se ne ujemajo");
    public static ltext ss_OK = new ltext("OK"," Potrdi");
    public static ltext ss_Open = new ltext("Open"," Odpri");
    public static ltext ss_Order = new ltext("Order	"," Naročilo");
    public static ltext ss_OrderCustomerDistrict = new ltext("Order customer district"," Okrožje stranke");
    public static ltext ss_OrderNr = new ltext("Order nr."," Št. naročila");
    public static ltext ss_OrderNrPantheon = new ltext("Order nr. Pantheon"," Št. naročila Pantheon	");
    public static ltext ss_OrderNumberPantheon = new ltext("Order nr. Pantheon"," Št. naročila Pantheon	");
    public static ltext ss_OrdersStatusId = new ltext("Orders status id	"," ID statusa naročila");
    public static ltext ss_OverlapsExistingInterval = new ltext("Overlaps existing interval"," Prekriva se z obstoječim intervalom");
    public static ltext ss_PackCount = new ltext("Pack count"," Število zapakiranih	");
    public static ltext ss_Packed = new ltext("Packed"," Zapakirano");
    public static ltext ss_Packing = new ltext("Packing"," Pakiranje");
    public static ltext ss_PackStart = new ltext("Pack start"," Začni pakiranje	");
    public static ltext ss_PantheonCustKey = new ltext("Pantheon cust. key"," Začni pakiranje");
    public static ltext ss_PantheonIdentDoesntExist = new ltext("Pantheon ident doesn't exist in plates database","	Pantheon ident ne obstaja v bazi tablic	");
    public static ltext ss_PantheonSubjectDoesntExist = new ltext("Subject doesn't exist in Pantheon database"," Stranka ne obstaja v bazi Pantheon");
    public static ltext ss_Password = new ltext("Password	"," Geslo");
    public static ltext ss_PasswordConfirm = new ltext("Confirm password","Ponovite geslo");
    public static ltext ss_PasswordMismatch = new ltext("Password mismatch"," Geslo se ne ujema");
    public static ltext ss_PaswordLengthToSmall = new ltext("Password length must be > 0"," Dolžina gesla mora biti večja od 0	");
    public static ltext ss_PaswordsNotMatch = new ltext("Passwords does not match!","Gesli se ne ujemata!	");
    public static ltext ss_PatternMismatch = new ltext("Pattern mismatch"," Vzorec se ne ujema");
    public static ltext ss_Picture = new ltext("Picture"," Slika");
    public static ltext ss_Plate = new ltext("Plate	","Tablica");
    public static ltext ss_PlateCode = new ltext("Plate Code"," Koda tablice");
    public static ltext ss_PlateColor = new ltext("Plate Color	"," Barva tablice");
    public static ltext ss_PlateFontName = new ltext("Font Family Name	"," Ime pisave");
    public static ltext ss_PlateFormDoesntExist = new ltext("Plate form doesn't exist","Format tablice ne obstaja");
    public static ltext ss_PlateFormNotEnabled = new ltext("Plate form not enabled	","Format tablice ni vključen");
    public static ltext ss_PlateHeightIn_mm = new ltext("Plate Height (mm)	"," Višina Tablice v mm");
    public static ltext ss_PlateNotFound = new ltext("Plate not found	"," Tablice nisem našel");
    public static ltext ss_PlateNr = new ltext("Plate nr.	"," Št. tablice");
    public static ltext ss_PlateNumber = new ltext("Plate number","Številka tablice");
    public static ltext ss_PlateNumberMismatch = new ltext("Plate number mismatch"," Številka tablice se ne ujema	");
    public static ltext ss_PlateShieldColor = new ltext("Shield Color"," Barva grba");
    public static ltext ss_PlatesLeft = new ltext("Plates left"," Preostalo tablic");
    public static ltext ss_PlateTextColor = new ltext("Text Color"," Barva besedila	");
    public static ltext ss_PlateVersion = new ltext("Plate version","Verzija tablice	");
    public static ltext ss_PlateVersionDoesntExist = new ltext("Plate version doesn't exist"," Verzija tablice ne obstaja");
    public static ltext ss_PlateVersionIsDisabled = new ltext("Plate Version is not active!","Verzija tablic neaktivna!");
    public static ltext ss_PlateVersionNotEnabled = new ltext("Plate version not enabled","	Verzija tablice ni vključena	");
    public static ltext ss_PlateVersions_id = new ltext("PlateVersions_id","	VerzijaTablic_id (\"PlateVersions_id\")");
    public static ltext ss_PlateWidthIn_mm = new ltext("Plate Width (mm)","	Širina Tablice v mm	");
    public static ltext ss_PleaseEnterSearchCriteria = new ltext("Please enter search criteria","	Prosim vnesi kriterije iskanja	");
    public static ltext ss_PleaseSelectLanguage = new ltext("Please select language	","Prosim izberi jezik	");
//   Port	Vrata");
        public static ltext ss_Post = new ltext("Post","Pošta");
    public static ltext ss_PostCode = new ltext("Post code","	Poštna št.	");
    public static ltext ss_Press = new ltext("Press","	Vtisni	");
//        PRESS_AUTOMATIC_IS_READY	ni uporabljen !!!!!!!!!!!");
    public static ltext ss_Press_Custom = new ltext("On Demand","	Servis");
//        PRESS_IS_READY	Preša pripravljena	");
    public static ltext ss_Press_Repair = new ltext("Repair","	Popravila");
    public static ltext ss_Press_Series = new ltext("Series","	Serije	");
    public static ltext ss_PressCount = new ltext("Press count","	Število vtisnjenih	");
    public static ltext ss_PressCountR4 = new ltext("Press count R4","	Število vtisnjenih R4");
    public static ltext ss_Pressed = new ltext("Pressed","	Vtisnjeno	");
    public static ltext ss_PressedR4 = new ltext("Pressed R4"," Vtisnjeno R4	");
    public static ltext ss_PressEnable = new ltext("Bit Addres for Press Enable","	Bitni naslov za vklop preše	");
    public static ltext ss_PressPlateOther = new ltext("Press plate - other	"," Vtis tablic - ostale");
    public static ltext ss_PressPlateR4 = new ltext("Press plate - R4","	Vtis tablic - R4		");
    public static ltext ss_PressPlateStandard = new ltext("Press plate - standard","	Vtis tablic - standardne");
    public static ltext ss_PressStart = new ltext("Press start","Začni vtis	");
    public static ltext ss_PressStartR4 = new ltext("Press start R4	"," Začni vtis R4");
    public static ltext ss_PressWorkingPlaces = new ltext("Press WorkingPlaces"," Stroj za vtis	");
    public static ltext ss_PressWorkingPlacesId = new ltext("Press WorkingPlaces id	"," ID stroja za vtis");
    public static ltext ss_PressWorkingPlacesR4 = new ltext("Press WorkingPlaces R4	"," Stroj za vtis R4");
    public static ltext ss_Print = new ltext("Print","	Natisni	");
    public static ltext ss_PrintCustom = new ltext("Print custom","	Natisni poljubno");
    public static ltext ss_PrintSeries = new ltext("Print series"," Natisni serije");
    public static ltext ss_PrintSimpleItems = new ltext("Print SimpleItems"," Natisni servise	");
    public static ltext ss_Priority = new ltext("Priority","Prioriteta");
    public static ltext ss_PriorityR4 = new ltext("Priority R4"," Prioriteta R4");
    public static ltext ss_Process = new ltext("Process	"," Procesiraj");
//        PROCESSING	Obdelava");
    public static ltext ss_ProcessOrder1 = new ltext("Process order"," Prevzem naročila	");
    public static ltext ss_ProcessOrders = new ltext("Process orders","	Procesiranje naročil");
    public static ltext ss_Product = new ltext("Product","	Izdelek	");
    public static ltext ss_Production = new ltext("Production","	Proizvodnja");
    public static ltext ss_Quantity = new ltext("Quantity","	Količina");
    public static ltext ss_QuantityNotMatchInterval = new ltext("Quantity doesn't match interval","	Količina se ne ujema z intervalom	");
    public static ltext ss_QuantityOfPlates = new ltext("Quantity of plates"," Število tablic	");
    public static ltext ss_QuantityOfR4 = new ltext("Quantity of R4","	Število R4	");
    public static ltext ss_QuantityToMake = new ltext("Quantity to make	","Število za izdelavo	");
    public static ltext ss_R4 = new ltext("R4"," R4");
    public static ltext ss_Realization = new ltext("Realization"," Realizacija");
    public static ltext ss_ReallyChange = new ltext("Really change?	"," Res spremenim?	");
    public static ltext ss_ReallyContinue = new ltext("Do you REALLY want to continue?	"," ALI RES ŽELITE NADALJEVATI? LAHKO SE POKVARI BAZA");
    public static ltext ss_Refresh = new ltext("Refresh","Osveži		");
    public static ltext ss_RePack = new ltext("Repack","Ponovno pakiranje");
    public static ltext ss_RepairOther = new ltext("Repair other"," Popravilo ostalo");
    public static ltext ss_RepairR4 = new ltext("Repair R4"," Popravilo R4");
    public static ltext ss_RepeatScan = new ltext("Repeat scan [Esc]"," Ponovi branje [Esc]	");
    public static ltext ss_Replacement = new ltext("Replacement	","  Zamenjava");
    public static ltext ss_ScanCode = new ltext("Scan code","Sekinarana koda");
    public static ltext ss_Search = new ltext("Search","	Išči	");
    public static ltext ss_SelectWorkingPlaces = new ltext("Select WorkingPlaces","	Izberi napravo	");
    public static ltext ss_SellectAll = new ltext("Sellect All","	Izberi vse");
    public static ltext ss_Series = new ltext("Series","	Serije	");
    public static ltext ss_SeriesOther = new ltext("Series other","	Serije ostalo");
    public static ltext ss_SeriesR4 = new ltext("Series R4","	Serije R4");
    public static ltext ss_Server = new ltext("Server","	Strežnik	");
    public static ltext ss_SimpleItemOther = new ltext("SimpleItem other","	Servisi ostalo	");
    public static ltext ss_SimpleItemR4 = new ltext("	SimpleItem R4","	Servisi R4	");
    public static ltext ss_SimpleItemRegular = new ltext("SimpleItem regular","	Servisi običajnih	");
    public static ltext ss_SimpleItems = new ltext("SimpleItems","	Servisi	");
    public static ltext ss_SetPriority = new ltext("Set priority","	Nastavi prioriteto");
    public static ltext ss_SetPriorityOther = new ltext("Set priority other","	Nastavi prioriteto ostalo");
    public static ltext ss_SettingName = new ltext("Setting name","	Naziv nastavitve");
    public static ltext ss_Settings = new ltext("Settings","	Nastavitve	");
    public static ltext ss_SettingsError = new ltext("Settings error","	Napaka nastavitev");
//        SettingsPress	Nastavitev delovnega okolja Preša");
    public static ltext ss_Shield = new ltext("Shield","	Grb	");
    public static ltext ss_ShieldDoesntExist = new ltext("Shield doesn't exist","	Grb ne obstaja	");
    public static ltext ss_ShieldEnabled = new ltext("Shield enabled","Grb vključen		");
    public static ltext ss_ShieldEnd = new ltext("Shield end","	Lepljenje grbov končano	");
    public static ltext ss_ShieldGlue = new ltext("Shield glue","	Lepljenje grbov	");
    public static ltext ss_ShieldGlueR4 = new ltext("Shield glue R4","	Lepljenje grbov R4	");
    public static ltext ss_ShieldNotEnabled = new ltext("Shield not enabled","	Grb ni vključen	");
    public static ltext ss_ShieldR4 = new ltext("Shield glue R4","	Lepljenje grbov R4	");
    public static ltext ss_Shields_id = new ltext("	Shields_id","	ime grba	");
    public static ltext ss_ShieldStandard = new ltext("Shield glue","	Lepljenje grbov	");
    public static ltext ss_ShieldStart = new ltext("Shield start","	Lepljenje grbov pričeto	");
    public static ltext ss_ShieldStartR4 = new ltext("Shield start R4","	Lepljenje grbov R4 pričeto");
    public static ltext ss_SmallLarge = new ltext("Small, large","	Majhna, velika	");
    public static ltext ss_Split = new ltext("Split","	Razbij	");
    public static ltext ss_SplitIntervals = new ltext("Split intervals","	Razbij intervale");
    public static ltext ss_StandardPlates = new ltext("Standard plates","	Standardne tablice");
    public static ltext ss_StartInterval = new ltext("Start interval","	Začetek intervala");
    public static ltext ss_StationOther = new ltext("Other station","	Ostala mesta");
    public static ltext ss_StationPack = new ltext("Pack station","	Mesto za pakiranje");
    public static ltext ss_StationPress = new ltext("Press station","	Mesto za vtis");
    public static ltext ss_StationPressR4 = new ltext("Press R4 station","	Mesto za vtis R4");
    public static ltext ss_StationShield = new ltext("Shield glue station"," Mesto za lepljenje grbov");
    public static ltext ss_stock_area_Edit = new ltext("Area","	Področne skupine	");
    public static ltext ss_stock_area_type_Edit = new ltext("Area Type","	Vrste Področij");
    public static ltext ss_stock_block_Edit = new ltext("Blocks	"," Urejanje zaloge");

        
    public static ltext ss_stock_group_Edit = new ltext("Number system	","Številski sistemi");
    public static ltext ss_stock_market_Edit = new ltext("Country","Država");
    public static ltext ss_stock_symbols_Edit = new ltext("Symbols","Simboli");
    public static ltext ss_stock_symbols_type_Edit = new ltext("Symbols type","Vrsta simbolov");
    public static ltext ss_StringTooLong = new ltext("String too long","Niz znakov predolg");
    public static ltext ss_Supervisor = new ltext("Supervisor"," Nadzornik");
    public static ltext ss_Table = new ltext("Table","Tabela");
    public static ltext ss_Tile = new ltext("Tile","Razporedi okna drugo pod drugim");
    public static ltext ss_To = new ltext("to","do");
    public static ltext ss_True = new ltext("true","Da");
    public static ltext ss_Type = new ltext("Type","Tip");
//   UNKNOWN_ERROR_CHECK_SENSOR	Neznana napaka	");
    public static ltext ss_UserHasWithoutRights = new ltext("This User has not rights!","Ta uporabnik nima nobenih pravic!");
    public static ltext ss_Username = new ltext("Username"," Uporabniško ime");
    public static ltext ss_UserNameAllreadyExist = new ltext("Username allready exist. Try Again.","Uporabniško ime že obstaja! Izberite - vpišite drugo ime.");
    public static ltext ss_UserNameDoesNotExist = new ltext("User name does not exist!","Uporabniško ime ne obstaja");
    public static ltext ss_UsernameNotDefined = new ltext("Username is not defined. You must enter user name first.	"," Manjka uporabniško ime. Najprej vpišite uporabniško ime!");
    public static ltext ss_Value = new ltext("Value	","Vrednost	");
    public static ltext ss_Variant = new ltext("Variant"," Varianta	");
    public static ltext ss_Version = new ltext("Version","Verzija	");
    public static ltext ss_VersionEnabled = new ltext("Version enabled","Verzija vključena");
    public static ltext ss_VersionId = new ltext("Version id","	ID verzije");
    public static ltext ss_VIEW_PressData = new ltext("View Press Data","Pregled dela na prešah	");
    public static ltext ss_ViewAccountingDataBaseConnection = new ltext("Connection To Accounting DataBase","Povezava na računovodsko bazo podatkov		");
    public static ltext ss_ViewProductionDataBaseConnection = new ltext("Connection To Production DataBase","Povezava na produkcijsko bazo podatkov");
    public static ltext ss_ViewWorkProcess = new ltext("View work process","Pregled dela");
    public static ltext ss_Warning = new ltext("Warning	","Opozorilo");
    public static ltext ss_Windows = new ltext("Windows","	Okna");
    public static ltext ss_WindowsAuthentication = new ltext("Windows authentication","Windows prijava");
    public static ltext ss_Worker = new ltext("Worker","Delavec	");
    public static ltext ss_WorkingPlaces = new ltext("WorkingPlaces","Stroj");
    public static ltext ss_WorkingPlacesDescription = new ltext("WorkingPlaces description","Opis stroja");
    public static ltext ss_WorkingPlaceshield = new ltext("Shield","Lepljenje grbov");
    public static ltext ss_WorkingPlacesId = new ltext("WorkingPlaces ID","ID stroja");
    public static ltext ss_WorkingPlacesPack = new ltext("Pack"," Pakiranje");
    public static ltext ss_WorkingPlacesPress = new ltext("Press","Vtis");
    public static ltext ss_WorkingPlacesPressR4 = new ltext("Press R4","Vtis R4	");
    public static ltext ss_WorkProcess = new ltext("Work process"," Proces dela	");
    public static ltext ss_WorkReport = new ltext("Work report","Poročilo dela	");
    //WRONG_CHAR_SET_ON_PRESS	Napačen znak na preši");
     public static ltext ss_Year = new ltext("Year","leto");

        #endregion

        public static ltext s_Settings_For_MRVL_Input_folders = new ltext("Settings for MRVL input folders", "Nastavitev MRVL vhodnih map");
        public static ltext s_AskToSetPutInFolders = new ltext("Set MRVL input folders ?", "Nastavitev MRVL vhodnih map ?");

        public static ltext s_MRVL_Folder = new ltext("MRVL input folder:", "MRVL vhodna mapa:");
        public static ltext s_MRVL_OK_Folder = new ltext("MRVL OK folder:", "MRVL OK mapa:");
        public static ltext s_MRVL_ERROR_Folder = new ltext("MRVL ERROR folder:", "MRVL NAPAKE mapa:");
        public static ltext s_MRVL_GARBAGE_Folder = new ltext("MRVL GARBAGE folder:", "MRVL SMETI mapa:");

        public static ltext s_ImportMRVL = new ltext("Import from MRVL", "Uvozi iz MRVL");
        public static ltext s_ImortedTableName = new ltext("Imorted Table Name:", "Ime tabele:");
        public static ltext s_Import_Saved_To_File = new ltext("Import Saved To File:", "Uvoz je prenešen v datoteko:");
        public static ltext s_Html_No_Rows_Found_To_Import = new ltext("No Rows To Import", "Program ne najde vrstic za prenos v Html zapisu.");

        public static ltext s_YouCanNotStartProgramWithoutSettingsInDataBase = new ltext("You can not start program without settings read form DataBase ProgramSettings", "Ni možno zagnati programa ne da bi program lahko prebral nastavitve iz podatkovne baze ProgramSettings");
        public static ltext s_Error_Writing_ProgramSettings_After_Creating_Tables = new ltext("Error Write Default Settings after Creating and ProgramSettings Tables", "Napaka pri pisanju priveztih nastavitev po ustvarjanju tabel v bazi ProgramSettings!");
        public static ltext s_Error_Read_settings_After_Craeating_And_Writing_ProgramSettings_Tables = new ltext("Error Read Settings after Creating and Reading ProgramSettings Tables", "Napaka pri branju nastavitev po ustvarjanju in pisanju privzetih vrednosti v bazo ProgramSettings!");
        public static ltext s_Error_Craeating_ProgramSettings_Tables = new ltext("Error Creating ProgramSettings Tables", "Napaka pri ustvarjanju tabel v bazi ProgramSettings");
        public static ltext s_ProgramSettings_Tables_Error = new ltext("ProgramSettings Tables Error:", "Napaka pri branju tabel iz baze ProgramSettings:");
        public static ltext s_ProgramSettings_CreateNew_Tables_Question = new ltext("Create new Tables in DataBase ProgramSettings?", "Ustvarim nove tabele v podatkovni bazi ProgramSettings ?");

        public static ltext s_Connection_To_LocalDBProgramSettings = new ltext("Connection To Local DataBase:ProgramSettings", "Povezava na logalno podatkovno bazo:ProgramSettings");
        public static ltext s_Connection_To_ProgramSettings = new ltext("Connection To DataBase:ProgramSettings", "Povezava na podatkovno bazo:ProgramSettings");

        public static ltext s_UnknownPictureFormatSaveInJpg = new ltext("Error:Unknown picture format! Save in jpeg format?", "Nepoznan format slike! Shranim v Jpeg formatu?");

        public static ltext s_SaveInJpgQuestion = new ltext("Save in jpeg format?", "Shranim v Jpeg formatu?");

        public static ltext s_MemoryBmpPictureFormatNotAllowed_SaveInJpg = new ltext("MemoryBmp picture format not allowed for storing in DataBase! Convert in jpeg format?", "Slike v formatu \"MemoryBmp\"  ni veljavna za vpis v podatkovno bazo! Shranim v Jpeg formatu?");

        public static ltext s_Paste = new ltext("Paste", "Prilepi");
        public static ltext s_ImportFrom_HTML_clipboard = new ltext("Import by copy and paste HTML Page", "Uvozi naročila MNZ s uporabo odložišča");


        public static ltext s_LeuzeSettingsButton_Visible = new ltext("Leuze Settings Button Visible", "Prikaži gum za Leuze nastavitev");
        public static ltext s_DelayToShowNewPlate = new ltext("Delay to show new plate.", "Zakasnitev za prikaz naslednje tablice v ms");
        public static ltext s_LeuzeSettings = new ltext("Leuze Settings", "Nastavitve čitalnika Leuze");
        public static ltext s_Leuze_SettingsChanged_SaveQuestion = new ltext("Leuze settings are changed. Save ?", "Nastavitve čitalnika Leuze so spremenjene. Shranim spremembe?");
        public static ltext s_CircularInputBufferLength = new ltext("Circular Input Buffer Length", "Velikost vhodnega krožnega pred-pomnilnika");
        public static ltext s_btn_RepeatScanNew = new ltext("<-Repeat [+]", "<-Ponovi [+]");
        public static ltext s_RegularExpressionNotValid = new ltext("regular expression is not valid :", "regularno pravilo ni veljavno ");
        public static ltext s_Press_Err_Bit_Pos = new ltext("Press Error Bit Pos", "Bitno mesto za napako na preši");
        public static ltext s_Ean_Err_Bit_Pos = new ltext("EAN Error Bit Pos", "Bitno mesto za napako EAN");
        public static ltext s_Press_Enable_Bit_Pos = new ltext("Press Enable Bit Pos", "Bitno mesto za dovoljenje preši");
        public static ltext s_Press_Program_Running_Bit_Pos = new ltext("Program Is Running Bit Pos", "Bitno mesto signala, da program teče.");
        public static ltext s_Press_Ready_Bit = new ltext("Press ready bit", "Signal preši, da je program zagnan.");
        public static ltext s_WriteMaskedToLPTPort = new ltext("Write bits to LPT port", "Na LPT vpisuj posamezne bite");
        public static ltext s_AlertErrorBitPosition = new ltext("Alert Press Error (bit position 0..7):", "Napaka preše (bitno mesto 0..7):");
        public static ltext s_AlertEanErrBitPosition = new ltext("Alert Error EAN (bit position 0..7):", "Napaka EAN (bitno mesto 0..7):");
        public static ltext s_PressReleaseBitPosition = new ltext("Enable press (bit position 0..7):", "Omogoči prešo (bitno mesto 0..7):");


        public static ltext s_End = new ltext("End", "Končaj");
        public static ltext s_EndSeries = new ltext("End series", "Končaj serijo");
        public static ltext s_PressSeriesForPriorityGreaterThan = new ltext("Press series for priority greater than:", "Preša dela serije samo za prioritete večje od:");
        public static ltext s_LocalDB_CreateNewOnReload = new ltext("Reload whole DataBase", "Pri ponovnem nalaganju naloži celo bazo");

        public static ltext s_AllwaysReloadDataBase = new ltext("Reload whole DataBase on Startup", "Ob zagonu programa vedno naloži celo bazo");
        public static ltext s_ReloadWholeDataBase_ThisCanLastMinutes = new ltext("Reload whole DataBase ?\r\n Reloading whole DataBase can last few minutes.", "Ponovno naložim celotno podatkovno bazo?\r\nNalaganje lahko traja največ nekaj minut.");
        public static ltext s_ThereIsNoPlateInDataBaseWhereEan = new ltext("There is no plate in DataBase where Ean = ", "V bazi podatkov ni tablice katere EAN = ");
        public static ltext s_EAN_allready_exists_IN_Irta_ean_R4 = new ltext("EAN allready exists in table Irta_ean_R4", "EAN že obstaja v tabeli Irta_ean_R4");
        public static ltext s_EAN_allready_exists_IN_Irta_ean = new ltext("EAN allready exists in table Irta_ean", "EAN že obstaja v tabeli Irta_ean");
        public static ltext s_RegularPhysicalPlateDimensionWidth = new ltext("Regular plate width", "Širina navadne tablice");
        public static ltext s_chk_WaitPressUndoIsDone = new ltext("Wait until undo is done", "Počakaj, da se razveljavitev konča");
        public static ltext s_chk_Ask_WaitPressUndoIsDone = new ltext("Ask for undo wait dialog", "Vprašaj za razveljavitveni dialog");
        public static ltext s_chk_Ask_DoPressUndoQuestion = new ltext("Ask Before Undo", "Vprašaj za razveljavitev");

        public static ltext s_SynchronisationDone = new ltext("Synhronisation with central database is done.", "Sinhronizacija s centralno bazo je končana.");
        public static ltext s_WaitUntilLocal2RemoteSynchornisationIsDone = new ltext("Please wait until synchronisation with central database is done.", "Prosimo počakajte, da se podatki uskladijo v centralni bazi.");
        public static ltext s_WaitUndoIsDone = new ltext("Wait until undo is done in central database?", "Počakam, da se razveljavitev uskladi s centralno bazo podatkov?");
        public static ltext s_DoUndoQuestion = new ltext("Undo selected rows?", "Razveljavim izbrane vrstice?");
        public static ltext s_LogFile = new ltext("Log file", "Dnevniška datoteka (\"Log file\")");
        public static ltext s_PressSettings = new ltext("Press settings", "Nastavitve Preše");
        public static ltext s_Time = new ltext("Time", "Čas");
        public static ltext s_Message = new ltext("Message", "Sporočilo");

        public static ltext s_WorkPlacesDidntChanged = new ltext("Press tasks were not move to another press machine.", "Nalog za prešo v administraciji niso prenesli na drugo prešo.");
        public static ltext s_PrioritiesDidntChanged = new ltext("Priorites didn't changed.", "Priorite so nespremenjene.");
        public static ltext s_NoNewPlatesToInsertFromRemoteDB = new ltext("No new data for insert into local table 'Press_Data'.", "Ni novih vrstic za vpis v lokalno tabelo 'Press_Data'.");
        public static ltext s_Number_of_rows_where_WorkPlace_id_in_table_Press_Data_was_updated = new ltext("Number of rows where WorkPlace_id in table Press_Data was updated = ", "Število vrstic kjer je delovno mesto ('WorkPlace_id') posodobljeno = ");
        public static ltext s_Number_of_rows_where_PRIORITY_in_table_Press_Data_was_updated = new ltext("Number of rows where PRIORITY in table Press_Data was updated = ", "Število vrstic kjer je PRIORITETA ('PRIORITY') posodobljena = ");
        public static ltext s_local_Press_Data_JOURNAL_Event_INSERT_inserted_OK = new ltext("Events 'INSERT' was succesfully inserted into local Press_Data_JOURNAL", "Dogodki tipa 'INSERT' so uspešno vpisani v lokalni dnevnik 'Press_Data_JOURNAL'");
        public static ltext s_local_Press_Data_rows_inserted =  new ltext("Number of rows inserted into local table Press_Data = ","Število vrstic vpisanih v lokalno tabelo \"Press_Data\" = ");
        public static ltext s_NumberOfRowsReaded_in_ = new ltext("Number of rows readed from table ", "Število prebranih vrstic iz tabele ");
        public static ltext s_NumberOfNewDataRows_in_ = new ltext("Number of new rows in ", "Število novih vrstic v ");
        public static ltext s_Where = new ltext("where", "kjer je");
        public static ltext s_Read_ =   new ltext("Read ","Berem ");
        public static ltext s_Last_Irta_ean_id = new ltext("Last Irta_ean_id = ", "Zadnji Irta_ean_id = ");
        public static ltext s_Last_Irta_ean_R4_id = new ltext("Last Irta_ean_R4_id = ", "Zadnji Irta_ean_R4_id = ");
        public static ltext s_Get_last_Irta_ean_id_from_local_Press_Data_table = new ltext("Reading last Irta_ean_id from local Press_Data table", "Berem zadnji Irta_ean_id iz lokalne tabele Press_Data");
        public static ltext s_Get_last_Irta_ean_R4_id_from_local_Press_Data_table = new ltext("Reading last Irta_ean_R4_id from local Press_Data table", "Berem zadnji Irta_ean_R4_id iz lokalne tabele Press_Data");
        public static ltext s_Execute_Update_Press_Data_Irta_ean_OK = new ltext("Update of table Press_Data_Irta_ean on database finished OK.", "Posodobitev tabele:\"Press_Data_Irta_ean\" je uspešno končana.");
        public static ltext s_Execute_Update_Press_Data_Irta_ean_on_ = new ltext("Update of table Press_Data_Irta_ean on database ", "Poteka posodobitev tabele:\"Press_Data_Irta_ean\" v bazi ");
        public static ltext s_Local2RemoteSynchronisationDone = new ltext("Synchornisation Done ", "Uskladitev podatkov je končana!");
        public static ltext s_Local2RemoteSynchronisationDeletedDataLeft = new ltext("Synchornisation of deleted data left = ", "Število izbrisanih podatkovnih paketov za uskladitev = ");
        public static ltext s_Local2RemoteSynchronisationDataLeft = new ltext("Synchornisation data left = ", "Število podatkovnih paketov za uskladitev = ");
        public static ltext s_Local2RemoteSynchronisationStart = new ltext("Synchornisation with central database is running!", "Uskladitev podatkov s centralno podatkovno bazo je v teku!");
        public static ltext s_WaitRemoteDBSynchronisationIsFinished = new ltext("Wait until remote database synchronisation is done!", "Prosim počakajte,da se uskladitev podatkov s centralno podatkovno bazo konča!");
        public static ltext s_RunAsMDIClient = new ltext("Run as MDI Client", "Delovanje znotraj glavnega okna");
        public static ltext s_LeuzeGeneralTimeout = new ltext("General Timeout", "Časovna omejitev");
        public static ltext s_WaitDelayForRead = new ltext("Read delay", "Zamik branja");
        public static ltext s_NoMoreDataPeriod = new ltext("End Waiting Time", "Čakalni interval na koncu");
        public static ltext s_NumberOfLeuzeRepetitions = new ltext("Number of retries", "Št. ponavljanj ob napaki");

        public static ltext s_TimeoutLeuze = new ltext("Timeout waiting Leuze to respond", "Čas branja senzorja Leuze je potekel!");
        public static ltext s_O = new ltext("CHAR O!", "ČRKA O!");
        public static ltext s_Space = new ltext("SPACE!", "PRESLEDEK!");
        public static ltext s_NarrowFont = new ltext("Narrow Font", "OŽANE ČRKE");
        public static ltext s_stop_alert = new ltext("Stop Alert", "Utišaj zvok");
        public static ltext s_NumberOfAll =  new ltext("Count:", "Št.vseh:");
        public static ltext s_EAN_allready_exists = new ltext("EAN allrady exists", "EAN že obstaja !");
        public static ltext s_Finished = new ltext("THE END", "KONEC");
        public static ltext s_Save_Settings_Question = new ltext("Save new settings ?", "Shranim nove nastavitve?");
        public static ltext s_AllCount = new ltext("All count:", "Število vseh");
        public static ltext s_OnlyPlatesForProduction = new ltext("Only plates for production", "Za proizvodnjo");
        public static ltext s_ShowAllPlatesInSeries = new ltext("Show each single plate in series", "Pokaži vsako tablico v seriji");
        public static ltext s_Series = new ltext("Series", "Serije");
        public static ltext s_Limit = new ltext("Limit", "Omejitev");
        public static ltext s_VIEW_PressData = new ltext("Press Data View ", "Pregled dela na prešah");
        public static ltext sPress_R4 =  new ltext("Press R4","Preša R4");
        public static ltext sPress_1= new ltext("Press 1","Preša 1");
        public static ltext sPress_2= new ltext("Press 2","Preša 2");
        public static ltext s_Refresh = new ltext("Refresh", "Osveži");

        public static ltext s_ViewPressData = new ltext("View Press Data", "Pregled dela");
        #region VIEW_Undo_Process_Form
        public static ltext s_Undone_Plates_JOURNAL = new ltext("Undo history", "Dnevnik razveljavitev v lokalni bazi");
        public static ltext s_PlatesInUndoProcess = new ltext("Plates in undo process", "Tablice v razveljavitvenem procesu");
        public static ltext s_VIEW_Undo_Process_LocalDB_Form_Title = new ltext("Undo plates view in local database", "Pregled razveljavitev na preši v lokalni bazi");
        #endregion

        public static ltext s_PlatesUndoProcesStarted = new ltext("Undo process started!\r\nYou can check if it is finnished by pressing button View undo process", "Razveljavitveni proces natisnjenih tablic se je zagnal.\r\nAli se je razveljavitveni proces končal lahko preverite, če pritisnete gumb Pregled razveljavitev");
        public static ltext s_Check_Selected = new ltext("Check selected", "Označi izbrane");
        public static ltext s_Uncheck_Selected = new ltext("Uncheck selected", "Odznači izbrane");

        public static ltext s_btn_SaveAsLastEan = new ltext("Save default EAN", "Shrani začetni EAN");
        public static ltext s_btn_EAN_barcode_reader_READ = new ltext("Read EAN", "Preberi EAN");
        public static ltext s_Press_Symulation_Title = new ltext("Press symulator", "Simulator preše");

        public static ltext s_Copyright_KIG = new ltext("This program is property of KIG d.d. All right reserved.", "Ta program je last podjetja KIG.d.d. Vse pravice so pridržane.");
        public static ltext s_Startup_title = new ltext("KIG Plates, program for production of vehichle plates", "KIG program za proizvodnjo registrskih tablic");
        public static ltext s_ShowRowNumbers = new ltext("Show Row Numbers", "Prikaži številke vrstic");
        public static ltext s_ErrorStartExecuteExcel = new ltext("Error opening file:", "Napaka pri odpiranju datoteke:");
        public static ltext s_ErrorInExportToExcel = new ltext("Error in export", "Napaka pri izvozu");


        public static ltext s_Columns = new ltext("Columns", "Število stolpcev");
        public static ltext s_Rows = new ltext("Rows", "Število vrstic");
        public static ltext s_ExportToFile = new ltext(" Export to file", "Izvoz v datoke");
        public static ltext s_ExportDoneInXprocent = new ltext(" Export", "Izvoženo");
        public static ltext s_ThereAreNoSelectedRowsToExport = new ltext("You didn't select rows to export into  \"Excel\"(.xls) file.", "Niste izbrali vrstic za izvoz v \"Excel\" datoteko?");
        public static ltext s_SaveSelectedRowsToExcelFile =  new ltext("Export selected rows to Excel file?", "Izvozim izbrane vrstice v \"Excel\" datoteko?");

        public static ltext s_LocalDB_Data_Press_VIEW = new ltext("Local Press Data VIEW", "Pregled podatkov lokalne baze");
        public static ltext s_AllData = new ltext("All Data", "Vsi podatki");
        public static ltext s_LastPressed = new ltext("Last pressed", "Nazadnje natisnjeni");
        public static ltext s_ToBePressed = new ltext("To press", "Za tiskanje");

        public static ltext s_Analyze = new ltext("DB Details", "Podroben pregled");
        public static ltext s_CheckLocalDatabase = new ltext("Check Local DataBase:", "Preverjanje lokalne baze podatkov:");
        public static ltext s_LocalDatabase_OK = new ltext("Local DataBase = ", "Lokalna baza podatkov = ");
        public static ltext s_GetWorkingPlace_OK = new ltext("Working place = ", "Delovno mesto = ");
        public static ltext s_GetWorkingPlace_ID = new ltext("Reading working place ID.", "Branje delovnega mesta.");

        public static ltext s_UndoPressedPlates = new ltext("Undo pressed plates.", "Razveljavi natisnjene tablice.");
        public static ltext s_EanIsAllreadyUsedInTabliceETForTables = new ltext("Table bellow shows ean codes that allready exist in TabliceET and can not be written into database TabliceET! Select all those rows and press button Undo.", "Tabela spodaj prikazuje vse tiste tablice, katerih ean koda že obstaja v centralni bazi. Izberite v stolpcu Razveljavi tablice za razveljavitev in pritisnite gumb Razveljavi.");
        public static ltext s_DoPress = new ltext("Press", "Natisni");
        public static ltext s_Local2Remote = new ltext("Update from Local to Remote DB", "Posodbi iz Lokalne v Oddaljeno bazo.");
        public static ltext sYouDidntSelectAnyRowsToUndo = new ltext("No rows selected for undo.", "Niste izbrali niti ene vrstice za razveljavitev.");
        public static ltext s_ResetSettings = new ltext("Reset settings","Ponastavi nastavitve");
        public static ltext sResetSettingsQuestion = new ltext("Set initial(\"factory\") settings ?", "Izbrišem vse nastavitve in jih postavim na začetne (\"tovarniške\") nastavitve?");
        public static ltext sWorkingPlaceIsNotDefinedAndYouHaveNoAdministratorRole_LoginAsAdministratorOrAsUserWithAdministratorRoleThenYouCanDefineWorkingPlace 
            = new ltext("Working place is not defined yet and you logged in as user with no Administrator Role.\r\nYou must login as Administrator or as user with Administrator role to be able to define Working Place.", "Delovno mesto ni določeno!\r\nPrijavili ste se kot uporabnik ki nima Administratorske vloge.\r\nŠele, če se prijavite kot uporabnik z administratorskimi pravicami (vlogo) lahko določite delovno mesto.");
        public static ltext s_YouNotDefinedWorkingPlace = new ltext("Working place is not defined!", "Delovno mesto niste določili!");
        public static ltext sConfirm = new ltext("Confirm", "Potrdi izbiro");
        public static ltext s_DefineWorkingPlace = new ltext("Define Working Place", "Določite deolvno mesto");
        public static ltext sYouHaveSelectedWorkingPlace_id = new ltext("Your selected working place is :", "Izbrali ste delovno mesto :");
        public static ltext s_ForWorkingWith_PressRegular_WorkingPlace_id_must_be_2_or_3 = new ltext("To work on ordinary press (not R4) \r\nworking place id must be set to %1 or %2.\r\nYou can change working place id in Settings.", "Za delo na navadni preši morate \r\n nastaviti številko delovnega mesta na %1 ali %2. Številko delovanga mesta lahko spremenite v nastavitvah");
        public static ltext sNoPLatesToBeDone = new ltext("No plates to produce any more.", "Vse tablice so narejene.\r\nV bazi ni vpisanih tablic za proizvodnjo.");
        public static ltext sNoMorePLatesToBeDone = new ltext("No plates to produce any more.", "Vse tablice so narejene.");

        public static ltext s_Repair = new ltext("Repair", "Popravila");
        public static ltext s_Undo = new ltext("Undo", "Razveljavi");
        public static ltext s_SYMULATOR = new ltext("SYMULATOR!", "SIMULATOR!");
        public static ltext s_CanNotWriteOrDeleteFileInFolder = new ltext("Can not write or delete files in folder :", "Ni omogočeno pisanje in brisanje datotek v mapi :");
        public static ltext s_SelectAnotherFolder = new ltext("Select another folder.", "Izberite drugo mapo.");

        public static ltext s_select_folder_for_recent_combobox_data = new ltext("Select Folder for recent combo-box data", "Izberite mabo za shranjevanje nedavnih vnosov v kontrli tipa:\"Combo-Box\"");

        public static ltext s_Main_Title = new ltext("KIG Plates Production", "KIG Proizvodnja Tablic");
        public static ltext s_WorkingPlace_id = new ltext("Working Place ID", "ID delovnega mesta");
        public static ltext s_WorkingPlace_type = new ltext("Working Place Type", "Vrsta delovnega mesta");
        public static ltext s_WorkingPlace_description = new ltext("Working Place Name", "Ime delovnega mesta");
        public static ltext s_Table_is_missing= new ltext("Table is missing", "Manjka tabela");
        public static ltext s_Column_is_missing= new ltext("Column is missing", "Manjka stolpec");
        public static ltext s_connection_failed= new ltext("Connection failed", "Povezava ni uspela");
        public static ltext s_primary_key_is_missing= new ltext("Key is missing", "Manjka ključ (\"foreign key\")");



        public static ltext s_CommandLineHelp = new ltext("Command Line Help", "Pomoč za komandno vrstico");
        public static ltext s_commandline_RS232MONITOR = new ltext("Activates RS232 Monitor for Leuze sensor.\r\n With RS232 Monitor Form you can see data streem from Leuze Sensor", "Aktivira RS232 Monitor.\r\n Z njim lahko spreljate prihod podatkov od Leuze senzorja,\r\nki prečita postavljena orodja (črke) za prešanje tablice.");
        public static ltext s_commandline_SYMULATOR = new ltext("Enables SYMULATION for Press working places \r\n and Shows button Next in Press Forms", "Omogoči simulacijo preše tako, da v oknih za prešo prikaže \r\n gumb Next s katerim simuliramo vpis EAN kode v \"textbox\".");
        public static ltext s_commandline_CHANGE_CONNECTION = new ltext("Shows connection dialogs.\r\nThis command in command line enables you to change database connection at program startup.", "Prikaže dialoge za ustvarjanje povezav na strežnike.\r\nTo vam omogoči, da ob zagonu programa nastavite nove povezave na strežnike.");
        public static ltext s_commandline_RESETNEW = new ltext("Starts program without saved settings!", "Zažene program kot novo instalacijo brez vseh nastavitev!");
        public static ltext s_const_command_DIAGNOSTIC = new ltext("Enables Diagnostics of program speed.\r\n You can press F10 on main form to view speed results", "Omogoči diagnosticiranje hitrosti izvajanja programa. \r\n S pritsikom na F10 se prikaže okno z rezultati meritev.");
        public static ltext s_CreatePressDBTables = new ltext("Create PressDB Tables?", "Ustvarim tabele v PressDB?");
        public static ltext s_ConnectionToLocalDatabaseFailed = new ltext("Connection to SQLite database file was not successful.", "Povezava na SQLite podatkovno datoteko ni uspela!");
        public static ltext s_Another_instance_is_running = new ltext("Another instance is running", "Program je bil že zagnan in ravnokar teče!");
        public static ltext s_ActiveUsers = new ltext("Active users:", "Prijavljeni uporabniki:");
        public static ltext s_LoginHistoryForUser = new ltext("Login History for user:", "Zgodovina prijav za uporabnika:");

        public static ltext s_LoginTime = new ltext("Login Time", "Čas prijave");
        public static ltext s_LogoutTime = new ltext("Logout Time", "Čas odjave");
        public static ltext s_LoginHistoryAndActiveUsers = new ltext("Show Active Users and Login History","Prikaži aktivne uporabnike in zgodovino prijav");

        public static ltext s_UserInfo = new ltext("User Info", "Informacija o uporabniku");
        public static ltext s_Roles = new ltext("Roles:", "Vloge:");

        public static ltext s_PasswordExpiresAfter = new ltext("Days after password expires:", "Število dni do poteka veljavnosti gesla:");
        public static ltext s_RoleManagerForm = new ltext("Manage Roles", "Urejanje Vlog");
        public static ltext s_btn_ManageRoles = new ltext("Manage Roles", "Urejanje Vlog");
        public static ltext s_lbl_ManageRoles = new ltext("Roles:", "Vloge:");
        public static ltext s_New_Password = new ltext("New password:", "Novo geslo:");
        public static ltext s_Confirm_New_Password = new ltext("Confirm new password:", "Ponovite novo geslo:");
        public static ltext s_Error_NoLanguageResourceFilesInFolder = new ltext("Error:No Language resource files in folder",
                                                                          "Napaka:Ni jezikovnih \"resource\" datotek v mapi"); 

        public static ltext s_Program_can_not_start_if_language_is_not_defined = new ltext("\r\nProgram can not start if language is not defined\r\n or language resource file is missing!",
                                                                                     "\r\nProgram se ne more zagnati, če jezik ni določen\r\n oziroma jezikovna \"resource\" datoteka manjka!");

        public static ltext s_NotInFolder = new ltext("not in folder",
                                                 "manjka v mapi");

        public static ltext s_Text_in_language = new ltext("Text in Language","Prevod v jeziku");

        public static ltext s_FullScreen = new ltext("Full Screen",
                                                   "Čez cel zaslon");

        public static ltext s_Language = new ltext("Language",
                                                   "Jezik");

        public static ltext s_UserThatChangesPassword = new ltext("UserName:", "Uporabnik:");

        public static ltext s_PasswordExpiredSetNewPassword = new ltext("Passwored expired!\r\nSet new password!",
                                                                        "Veljavnost gesla je potekla!\r\nDoločite novo geslo!");

        public static ltext s_AdministratorRequestForNewPassword = new ltext("Adminstrator requests that you set your own secret password on first login!\r\nSet your password!",
                                                                             "Administrator zahteva, da določite lastno geslo ob prvi prijavi!\r\nDoločite lastno geslo!");

        public static ltext s_FristLognSetNewPassword = new ltext("!\r\nSet new password for user:",
                                                                "Veljavnost gesla je potekla!\r\nDoločite novo geslo za uporabnika:");

        public static ltext s_rdb_AfterNumberOfDays = new ltext("After Number of Days",
                                                                "Po številu dni");

        public static ltext s_rdb_DeactivateAfterNumberOfDays = new ltext("Not active after expires",
                                                                          "Ni veljavno po poteku");
        public static ltext s_PasswordExpires = new ltext("Password expires :",
                                                          "Geslo preneha veljati :");

        public static ltext s_RolesDataTableIsChanged_Question_SAVE = new ltext("Roles data table is changed!\r\nSave changes ?",
                                                                                "Tabela vlog je spremenjena!\r\nShranim spremembe ?");

        public static ltext s_YouCanNotSetMinumumPasswordLengthLessThan3 = new ltext("You can not set property minimum password length less than 3!",
                                                                                     "Najmanjša možna nastavitev dolžine gesla je 3 znake!");

        public static ltext s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers3 = new ltext(
                            "You must define password which has at least ",
                            "Geslo morate določiti tako, da njegovo število znakov ne bo manjše od ");

        public static ltext s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers2 = new ltext(
                            " !",
                            " !");
        
        public static ltext s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1 = new ltext(
                            "Password is not defined!\r\n Password length must be at least ",
                            "Geslo ni določeno!\r\nGeslo morate določiti tako, da njegovo število znakov ne bo manjše od ");

     
        public static ltext sUserDataAreChanged = new ltext("User data are changed OK.", "Uporabniški podatki so spremenjeni.");

        public static ltext s_Contact = new ltext("Contact",
                                                "Kontakt");
        public static ltext s_DataBaseFileCreationTime = new ltext("Database file creation time:", "Podatkovna baza čas ustvaritve:");

        public static ltext s_DataBaseFile = new ltext("Database file:", "Podatkovna baza:");

        public static ltext s_ComputerName = new ltext("Computer:", "Računalnik:");

        public static ltext s_StockCheckAtStartup = new ltext("Stock check at startup", "Preverjanje zalog ob zagonu programa");
        public static ltext s_MultiuserOperationWithLogin = new ltext("Multi user operation with login",
                                                             "Večuporabniško delovanje in prijava z geslom");

        public static ltext s_Administrator_password = new ltext("Administrator password",
                                                "Skrbniško geslo");
        public static ltext s_Administrator = new ltext("Administrator",
                                                "Administrator");

        public static ltext s_HeadNurse = new ltext("Head Nurse",
                                                    "Glavna medicinska sestra");

        public static ltext s_Nurse = new ltext("Nurse",
                                                "Medicinska sestra");

        public static ltext s_Clinic = new ltext("Clinic",
                                                 "Ordinacija");

        public static ltext s_Active = new ltext("Active",
                                                 "Aktivno");

        public static ltext s_NotActive = new ltext("Not Active",
                                                 "Neaktivna");

        public static ltext s_Password = new ltext("Password",
                                                   "Geslo");

        public static ltext s_RoleName = new ltext("User Rights",
                                                   "Pravice");

        public static ltext s_UserName = new ltext("User Name",
                                                   "Uporabniško Ime");

        public static ltext s_ManageRole = new ltext("Manage role",
                                                     "Izberi delovno mesto in urejaj uporabnike");

        public static ltext s_ManageUSers = new ltext("Manage Users",
                                                             "Urejanje uporabnikov");

        public static ltext s_Connection_Info = new ltext("Connection info",
                                                          "Informacija o povezavi");

        public static ltext s_Login = new ltext("Login",
                                                "Prijava");

        public static ltext s_Login_for = new ltext("Login ",
                                                    "Prijavite se v program");

        public static ltext s_Password_Wrong = new ltext("Password wrong!",
                                                         "Geslo ni pravilno!");

        public static ltext s_UserNameNotFound = new ltext("User name not found.",
                                                           "Uporabniško ime ne obstaja");

        public static ltext s_AddUser = new ltext("Add User",
                                                  "Dodaj uporabnika");

        public static ltext s_NewUser = new ltext("New User",
                                                  "Nov uporabnik");

        public static ltext s_UserNameIsNotWritten = new ltext("User name may not be empty!",
                                                               "Uporabniško ime ni vpisano!");

        public static ltext s_YourUsernameHasExpired = new ltext("Your user-name has expired!",
                                                                 "Vaše uporabniško ime je poteklo!");

        public static ltext s_YourUsernameIsDisabled = new ltext("User-name you've already written  is not activated!",
                                                                 "Uporabniško ime ni omogočeno!");

        public static ltext s_Minimum_Password_Length_is = new ltext("The length of password text must be >= ",
                                                                   "Dolžina gesla mora biti >= ");
        public static ltext s_Password_does_not_match = new ltext("Password does not match!",
                                                                   "Gesli se ne ujemata");

        public static ltext s_Title_UserManager = new ltext("User Manager for:",
                                                            "Urejanje uporabnikov za:");

        public static ltext s_lblUserName_UserManager = new ltext("User Name:",
                                                               "Uporabniško Ime:");

        public static ltext s_lblPassword_UserManager = new ltext("Password:",
                                                               "Geslo:");

        public static ltext s_lblConfirmPassword_UserManager = new ltext("Confirm Password:",
                                                                      "Potrdi geslo:");

        public static ltext s_btnAddUser_UserManager = new ltext("Add User:",
                                                             "Dodaj uporabnika:");

        public static ltext s_btn_DeleteUser = new ltext("Delete",
                                                         "Zbriši");

        public static ltext s_btnChangeData_UserManager = new ltext("Change",
                                                                    "Spremeni");

        public static ltext s_sLoginEnterUserNameAndPasswordWithRights = new ltext("Please enter user name and password with rights for ",
                                                                         "Prosim vnesite uporabniško ime in geslo s pravicami ");

        public static ltext s_sLoginEnterUserNameAndPassword = new ltext("Please enter user name and password",
                                                                         "Prosim vnesite uporabniško ime in geslo");


        public static ltext s_OnComputer = new ltext("on computer",
                                                         "na računalniku");
        public static ltext s_btnOK_UserManager = new ltext("OK",
                                                         "OK");

        public static ltext s_btnCancel_UserManager = new ltext("Cancel",
                                                         "Prekini");



        public static ltext s_IdentityNumber = new ltext("Identity",
                                                 "Identiteta");

        public static ltext s_LoginControl_Init_Error = new ltext("Error LoginControl Init: ",
                                                            "Napaka pri inicializaciji kontrole \"LoginControl\" v funkciji Init:");

        public static ltext s_Connection_To_TabliceET = new ltext("Connection to TablicET",
                                                            "Povezava na bazo TablicET");

        public static ltext s_Connection_To_PlatesDB = new ltext("Connection to PlatesDB",
                                                            "Povezava na bazo PlatesDB");

        public static ltext s_Connection_To_PantheonDB = new ltext ("Connection to Pantheon Database",
                                                              "Povezava na bazo Pantheon"); 

        #region LoginControl



        public static ltext s_LoginSuperAdministrator = new ltext("Enter password for SUPER-ADMINISTRATOR!\r\n SUPER-ADMINISTRATOR password expires in very short period of time. \r\n You can get this password by calling:\r\n Srečko Virant  (+386 41 771 339)\r\n or \r\nDamjan Štrucl (+386 41 707 369)", "Vnesite geslo za SUPER-ADMINISTRATOR!\r\nSUPER-ADMINISTRATOR geslo poteče prej kot v enem dnevu.\r\nZa SUPER-ADMINISTRATOR-sko geslo pokličite:\r\n +386 41 771 339 (g. Srečo Virant )\r\n ali\r\n +386 41 707 369 (g. Damjan Štrucl)");

        public static ltext s_CreateLoginTablesQuestion = new ltext("Users and Roles tables are missing.\r\nCreate Users and Roles tables?", "Manjkajo tabele \"Users\" and \"Roles\".\r\n Ustvarim tabele potrebne za prijavo?");
        public static ltext s_LoginConnection = new ltext("Login connection:", "Prijavna povezava:");
        #endregion
        #region stock
        public static ltext s_stock_area_type_Name = new ltext("Area type", "Vrsta področja");

        #endregion

        #region Insert_Intervals_Form
        public static ltext s_FilterlengthIsNotAsTheNumberOfPlacesForNumericSystem = new ltext("ERROR:Filter length is not the same as number of places (digits) of numeric system!", "NAPAKA:Dolžina znakov v filtru ni enaka številu mest številskega sistema");
        public static ltext s_SymbolsInFilterDoesNotMatchNumericSystemSymbols = new ltext("ERROR:All symbols in filter does not match numeric system symbols!", "NAPAKA:Vsi simboli v filtru ne ustrezajo simbolom številskega sistema!");
        #endregion

        #region EditIntervals 
        public static ltext s_interval_type = new ltext("Interval type", "Tip intervala");
        public static ltext s_from_plate_string = new ltext("From number", "Od številke");
        public static ltext s_to_plate_string = new ltext("To number", "Do številke");
        public static ltext s_District = new ltext("Region:", "Regija:");
        public static ltext s_EditIntervalsForNumSystemsGroup = new ltext("Edit intervals for numeric system :", "Urejanje intervalov za številski sistem :");
        public static ltext s_Select_Intervals_for_Numeric_System = new ltext("Select interval's numeric system", "Izberite številski sistem intervalov");
        public static ltext s_InsertIntoBlockType = new ltext("Insert into intervals of type", "Vstavi v intervale tipa");
        public static ltext s_NewBlockType = new ltext("New intervals of type", "Nove intervale tipa");
        

        public static ltext s_OpenXmlFile = new ltext("Open", "Odpri");
        public static ltext s_SaveXmlFile = new ltext("Save", "Shrani");

        public static ltext s_Index = new ltext("Index", "index");
        public static ltext s_InsertIntervalsforGroup = new ltext("Insert Intervals for numeric system:", "Vstavi intervale za številski sistem:");
        public static ltext s_Apply = new ltext("Apply", "Vstavi");
        public static ltext s_Add = new ltext("Add", "Dodaj");
        public static ltext s_Remove = new ltext("Remove", "Odstrani");
        public static ltext s_Remove_All = new ltext("Remove all", "Odstrani vse");

        public static ltext s_NewIntervalType = new ltext("New interval type ", "Nova vrsta intervalov");
        public static ltext s_ExistingIntervalType = new ltext("Existing interval type ", "Obstoječa vrsta intervalov");
        public static ltext s_Filter = new ltext("Filter", "Filter");

        public static ltext s_Inserted = new ltext("Inserted", "Zapisano");
        public static ltext s_Description = new ltext("Description", "opis");
        public static ltext s_btnInsertIntervals = new ltext("Insert intervals", "Vstavi intervale");
        public static ltext s_FilterDescription = new ltext("Filter description:", "Opis filtra:");
        public static ltext s_ErrorWrongFilterSizeFilterLengthMustBe = new ltext("ERROR: Filter text length is not ", "NAPAKA:Dolžina filter teksta ni ");
        public static ltext s_InitNumericSpace = new ltext("Init numeric space", "Začetna nastavitev številskega prostora");
        public static ltext s_SizeOfNumericSpaceIs = new ltext("Size of numeric space for ", "Velikost številskega prostora za ");
        public static ltext s_InitNumericSystemSpace = new ltext("Init numeric space as", "Inicializiraj ves številski prostor kot:");
        #endregion

        #region EditNumericStystem

            public static ltext s_m_pnum_symbols_bModified_Save = new ltext("Symbols data has changed. Save?", "Tabela simbolov ima spremembe. Shranim spremembe?");
            public static ltext s_m_pnum_symbols_type_bModified_Save = new ltext("Symbols type data has changed. Save?", "Seznam tabel simbolov ima spremembe. Shranim spremembe?");
            public static ltext s_m_pnum_field_bModified_Save = new ltext("Numeric system description data has changed. Save?", "Opis številskega sistema ima spremembe. Shranim spremembe?");
            public static ltext s_m_pnum_group_bModified_Save = new ltext("Numeric system data has changed. Save?", "Številski sistem ima spremembe . Shranim spremembe?");
            public static ltext s_NumericSystem = new ltext("Numeric System", "Številski sistem");
            public static ltext s_IsInUseIn = new ltext(" is in use in: ", " je v uporabi pri:");
            public static ltext s_YouCanNotDeleteNumericSystemInUse = new ltext(" You can not delete numeric system in use.", " Ne morete zbrisati številskega sistema, ki je v uporabi.");
            public static ltext s_pnum_group_Name = new ltext("Num.System Name", "Ime številskega sistema");

            public static ltext s_PlateVersions_plate_code_Name = new ltext("Plate code", "Vrsta tablice");

            public static ltext s_PlateVersions_pnum_Market_Name = new ltext("Market", "Tržna skupina");

            public static ltext s_pnum_Format_Symbols_Symbol = new ltext("Format Symbols", "Formatni simboli");

            public static ltext s_PlateVersions_plate_code = new ltext("Plate Version", "Verzija tablice");

            public static ltext s_all = new ltext("all", "vse");
            public static ltext s_intervals_ = new ltext("Intervals_", "Intervali_");
            public static ltext s_SUM_size_of_type = new ltext("Sum(size) for:", "Vsota velikosti blokov za:");
            public static ltext s_NumSystemsGroup = new ltext("Num.Systems for:", "Številski sistemi za:");

            public static ltext s_NumericStystemName = new ltext("Num.System Name:","Ime štev.sistema:");

            public static ltext s_EditNumericStystem = new ltext("Edit register plates numeric systems",
                                                                 "Urejanje tabličnih številskih sistemov");

            public static ltext s_EditNumericStystem_by_places = new ltext("Edit by places",
                                                                          "Urejanje po številskih mestih");

            public static ltext s_EditNumericStystem_select = new ltext("Select editor type for numeric systems",
                                                                        "Izberite način urejanja številskega sistema");

            public static ltext s_EditNumericStystem_by_fields = new ltext("Edit by fields",
                                                                           "Urejanje po skupinah");

            public static ltext s_AreYouSureToDeleteRow = new ltext("Are you shure to delete row?",
                                                                    "Ste prepričani zbrisati vrstico?");
            public static ltext s_pnum_symbols_type_Name = new ltext("Symbols name",
                                                                     "Ime simbolov");
        #endregion

        #region UserManager

        public static ltext s_btnChangePassword_UserManager = new ltext("Change password:",
                                                                        "Spremeni geslo:");



        #endregion

        #region FTP_Settings_Form

        public static ltext  s_FTP_User_List_Is_Empty = new ltext("FTP User List (evl_FTP_USER table) is empty!\n FTP Server will not start until you enter at least one user in to the User List (Table=evl_FTP_USER) and restart program",
                                                                  "FTP seznam uporabnikov (tabela:\"evl_FTP_USER\") je prazen!\n FTP strežnik se ne bo zagnal dokler ne vnesete v seznam vsaj enega uporabnika in ponovno zaženete program.");

        public static ltext  s_FTP_Settings_Form_Title = new ltext("FTP Settings",
                                                                   "FTP Nastavitve");

        public static ltext s_lbl_Port = new ltext("Port:",
                                                   "Vrata (\"Port\"):");

        public static ltext s_lbl_Timeout = new ltext("Timeout:",
                                                   "Timeout:");

        public static ltext s_lbl_UserName = new ltext("User:",
                                                       "Uporabnik:");

        public static ltext s_lbl_Password = new ltext("Password:",
                                                       "Geslo:");
        public static ltext s_OK = new ltext("OK",
                                                 "V redu");

        public static ltext s_You_must_restart_program_to_take_FTP_changes_effect = new ltext(" You must restart program to take FTP new ftp settings effect!",
                                                                                                "Morate ponovno zagnati program, da bi sprememba FTP nastavitev imela učinek!");


        #endregion
        #region Putin
        public static ltext s_Customs = new ltext("Customs",
                                                    "Carina");

        public static ltext s_TehServis = new ltext("Inspection SimpleItem",
                                                    "Tehnični servis");

        public static ltext s_Police = new ltext("Police",
                                                 "Policija");

        public static ltext s_InputFolder = new ltext("Input Folder",
                                                      "Vhodna mapa");

        public static ltext s_NotInTable = new ltext("not in table",
                                                     "ni v tabeli");

        public static ltext s_OKFolder = new ltext("OK Folder",
                                                   "Mapa uspešnih vpisov");

        public static ltext s_ErrorFolder = new ltext("OK Folder",
                                                   "Mapa neuspešnih vpisov");

        public static ltext s_GarbageFolder = new ltext("OK Folder",
                                                        "Mapa smeti");

        public static ltext s_ResponseFolder = new ltext("Response Folder",
                                                         "Mapa odgovorov");

        #endregion

        #region CreateView_Form

        public static ltext s_SelectView = new ltext("Select View",
                                                     "Izberi prikaz");

        public static ltext s_CreateNewView = new ltext("Ceate New View",
                                                         "Ustvari Nov Prikaz");

        public static ltext s_CanNotSaveViewWithNoColumn = new ltext("Can not create and save Table view without columns!",
                                                                     "Ni možno narediti  in shraniti tabelaričnega pogleda brez definiranih stolpcev!");

        public static ltext s_UseFilter = new ltext("Use filter",
                                                    "Uporabi filter");
        public static ltext s_Show = new ltext("Show",
                                               "Prikaži");

        public static ltext s_PrimaryView  = new ltext("Primary View",
                                                        "Osnovni (začetni) prikaz");

        
        #endregion

        #region TableDocking_Form
        public static ltext s_SaveWindowsConfiguration = new ltext("Save Windows Positions and Size ?",
                                                                   "Shranim pozicije in velikosti oken ?");


        public static ltext s_DataEditor = new ltext("Data Editor",
                                                     "Vnos podatkov");

        public static ltext s_ViewManager = new ltext("View Manager",
                                                      "Urejanje prikazov");

        public static ltext s_PrimaryTable = new ltext("Primary Table",
                                                       "Osnovna tabela");
        public static ltext s_Table_View_1 = new ltext("Table View 1",
                                                       "Tabelarični Prikaz 1");
        public static ltext s_Table_View_2 = new ltext("Table View 2",
                                                       "Tabelarični Prikaz 2");
        public static ltext s_Table_View_3 = new ltext("Table View 3",
                                                       "Tabelarični Prikaz 3");
        public static ltext s_Table_View_4 = new ltext("Table View 4",
                                                       "Tabelarični Prikaz 4");

        public static ltext s_SaveWindowConfiguration = new ltext("Save Window Configuration",
                                                                  "Shrani konfiguracijo oken");
        public static ltext s_Edit_XML_Configuration = new ltext("Edit XML Configuration record",
                                                                 "Preglej ali uredi XML konfiguracijski zapis");
        
        #endregion


        #region SaveViewForm

        public static ltext s_ViewToSave = new ltext("Save View : ",
                                                       "Shrani prikaz : ");

        public static ltext s_SaveViewForTable = new ltext("Save view for table:",
                                                           "Shrani prikaz tabele:");

        public static ltext s_Save = new ltext("Save",
                                               "Shrani");


        public static ltext s_ViewWithName = new ltext("View with name:",
                                                          "Prikaz z imenom:");

        public static ltext s_AllreadyExistForTable =  new ltext("Allready exist for table ",
                                                                 "že obstaja za tabelo ");

        public static ltext s_YouMustDefineViewNameOrCancel = new ltext("You must define View Name or press Cancel",
                                                                        "Ime prikaza morate izbrati ali pa pritisnite na gumb Prekini");

        public static ltext s_CurrentViewIsSuccesfulySavedUnderName = new ltext("Current View is saved under name:",
                                                                                "Prikaz je shranjen pod imenom:");

        public static ltext s_OverWriteExistingView = new ltext("View name allready exist! Do you want to overwrite view name:",
                                                                "Prikaz že obstaja! Želite da se prepiši čez pogled:");

        #endregion
        #region TabaleViewForm

        public static ltext s_Reload = new ltext("Reload",
                                                "Pon. naloži");
        public static ltext s_View =  new ltext("View",
                                                "Prikaz");


        public static ltext s_ConnectWithEditTableForm = new ltext("Bind selection with Edit Table",
                                                                   "Poveži izbiro z oknom za vnos podatkov");

        #endregion
        #region RandomDataParam_Form
        public static ltext sFileDoesNotExist = new ltext("Warning! File does not exist or is not defined!",
                                                          "Opozorilo! Datoteka ne obstaja ali pa še ni določena!");

        public static ltext sFolderDoesNotExist = new ltext("Warning! Folder does not exist or is not defined!",
                                                          "Opozorilo! Mapa ne obstaja ali pa še ni določena!");

        public static ltext s_SelectRandomDataParameters = new ltext("Select RandomData Parameters",
                                                                        "Izberite nastavitve za naključni generator podatkov");

        public static ltext s_OnlyForTable = new ltext("Only for table:",
                                                       "Samo za tabelo:");

        public static ltext s_ForAllTablesInDB = new ltext("For All Tables",
                                                           "Za vse tabele");

        public static ltext s_AllSettingsAreNotOK = new ltext("All settings are not OK and virtual secretary will not work, exit anyway?",
                                                             "Vse nastavitve niso podane, zato delo virtualnega tajnika ne bo mogoče. Zaprem okno vseeno?");
        #endregion

 
        public static ltext s_ErrorView =  new ltext ("Error creating view :",
                                                       "Napaka! V bazi podatkov je prišlo do napake pri ustvarjanju prikaza:");

        public static ltext sE3Plate = new ltext ("KIG E3Plate",
                                          "KIG - Elektronska tretja Tablica");

        public static ltext sJudoClubSokol = new ltext("Judo Club Sokol",
                                                        "Judo Klub Sokol");

       public static ltext s_File = new ltext("File",
                                       "Datoteka");

       public static ltext s_ExportTemplateToolStripMenuItem = new ltext("Create Import/export Template",
                                                                   "Ustvari uvozno/izvozno predlogo");

       public static ltext s_WaitUntilRandomParamSettingDialogIsClosed = new ltext("Wait until Random Param Setting Dialog is closed.",
                                                                             "Čakanje, da se nastavitveni dialog nakjučnega generatorja konča.");

       public static ltext s_YouCanNotStartVirtualSecretaryUntilRandomDataParentAreSet = new ltext("You can not start Virtual Secretay until all Random Param Settings are defined.",
                                                                                                     "Virtualnega tajnika ni možno zagnati dogler niso podane vse nastavitve.");
       public static ltext s_EditTable = new ltext("Edit Table :",
                                        "Urejanje tabele:");

       public static ltext s_DataInsertedIntoDataBaseOK = new ltext("Data Inserted Into Data Base OK.",
                                                                    "Podatki so vnešeni v bazo podatkov.");

       public static ltext s_DataView_Form = new ltext("Set Table View Criteria:",
                                                       "Nastavitve prikaza tabele:");


       public static ltext s_save = new ltext("save",
                                        "Datoteka");

       public static ltext s_File_Not_Opened = new ltext("File not opened:",
                                              "Datoteka ni možno odpreti:");

       public static ltext s_File_allready_Opened = new ltext("File is already opened:",
                                              "Datoteka je že odprta:");

       public static ltext s_File_does_not_exist = new ltext ("File does not exist:",
                                                       "Datoteka ne obstaja :");

       public static ltext s_Error = new ltext ("Error",
                                         "Napaka");

       public static ltext s_Create = new ltext ("Create",
                                          "Ustvari");

       public static ltext s_Delete = new ltext ("Drop Table ",
                                          "Zbriši Tabelo");

       public static ltext s_Connect = new ltext ("Connect",
                                           "Vzpostavi povezavo");

       public static ltext s_Edit = new ltext ("Edit",
                                        "Uredi");

       public static ltext s_Or = new ltext(" or ",
                                        " ali ");

       public static ltext s_Warning = new ltext ("Warning",
                                           "Opozorilo");

       public static ltext s_Info = new ltext ("Info",
                                        "Opozorilo");
       
       public static ltext s_DeleteRows = new ltext ("Delete Rows",
                                              "Zbriši vrstice");

       public static ltext s_FormTitle = new ltext ("Electronic Vehicle Licence Database Manager ",
                                             "Elektronska Tablica Vozila urejanje podatkovne baze ");

       public static ltext s_Err_TableNameDoesNotExist =  new ltext ("Table name does not exist:",
                                                               "V bazi podatkov ne obstaja tabela z imenom:");

       public static ltext s_TableDeletedOK =  new ltext ("Tabel is deleted OK",
                                                   "Tabela je uspešno izbrisana iz baze podatkov");

       public static ltext s_Err_TableNotDeleted =  new ltext ("Error: Table not deleted.",
                                                         "Napaka, tabela se ni zbrisala."
                                                   );
       public static ltext s_CreateTableInstruction =  new ltext ("Table does not exist. You can create table ",
                                                         "Tabela ne obstaja. Ustvarite novo tabelo ");

       public static ltext s_CreateTablesInDataBaseQuestion =  new ltext ("Create tables in database ",
                                                                   "Ali naj ustvarim tabele v podatkovni bazi ");

       public static ltext s_DropTablesInDataBaseQuestion =  new ltext ("Delete (drop) tables in database ",
                                                                 "Ali naj izbrišem tabele v podatkovni bazi ");

       public static ltext s_ManageTables =  new ltext ("Manage data",
                                                 "Vnos podatkov");

       public static ltext s_TransactionServer = new ltext("Transaction Server",
                                                           "Komunikacijski Strežnik");

       public static ltext s_TransactionServerSettings = new ltext("FTP settings",
                                                                    "FTP nastavitve");

       public static ltext s_TransactionServerMonitor = new ltext("FTP Monitor",
                                                                   "FTP Monitor");
       public static ltext s_TransactionServerUsers = new ltext("FTP User Manager",
                                                                   "FTP Uporabniki");
        

       public static ltext s_CreateTables =  new ltext ("Create tables",
                                                 "Ustvari tabele");

       public static ltext s_DropTables =  new ltext ("Drop tables",
                                               "Izbriši tabele");

       public static ltext s_AllTablesCreatedOK =   new ltext ("All tables are created OK.",
                                                        "Vse tabele so uspešno ustvarjene.");

       public static ltext s_err_AllTablesCreated =   new ltext ("ERROR:All tables are not created.",
                                                        "NAPAKA:Vse tabele niso ustvarjene.");

       public static ltext s_AllTablesDropedOK =   new ltext ("All tables are deleted OK.",
                                                        "Vse tabele so uspešno izbrisane.");

       public static ltext s_err_AllTablesDroped =   new ltext ("ERROR:All tables are not deleted.",
                                                        "NAPAKA:Vse tabele niso izbrisane.");

       public static ltext s_AllTablesWillBeDeletedAndRewrittenWithTestData =new ltext ("All tables will be deleted and rewritten with autogenerated test data. Are you sure? ",
                                                                                 "Ali se naj izbrišejo vse tabele in zamenjajo z avtomatsko generiranimi testnimi podatki ?");

       public static ltext s_GroupBoxImport_AddressData = new ltext ("Tables for adress data ",
                                                      "Tabele za naslove");

       public static ltext s_GroupBoxImport_PersonalData = new ltext ("Tables for personal names ",
                                                        "Tabele za osebna imena");

       public static ltext s_GroupBoxImport_VehicleData = new ltext ("Tables for vehicle data ",
                                                        "Tabele povezane z vozili");

       public static ltext s_GroupBoxImport_OrganisationData = new ltext ("Tables for companies data ",
                                                       "Tabele povezane s podjetji");

       public static ltext s_Person = new ltext ("Person",
                                          "Oseba");

       public static ltext s_chk_PasswordNeverExpires = new ltext("Never",
                                                                  "Nikoli");

       public static ltext s_chk_ChangePasswordOnFirstLogIn = new ltext("Change Password On First LogIn",
                                                                        "Spremeni geslo ob prvi prijavi");

       public static ltext s_Max_Password_Age = new ltext("Number of days:",
                                                          "Število dni:");

       public static ltext s_FirstName = new ltext ("First Name",
                                             "Ime");

       public static ltext s_LastName = new ltext ("Last Name",
                                             "Priimek");


       public static ltext s_Address = new ltext ("Address",
                                           "Naslov");


       public static ltext s_StreetName =  new ltext ("Street Name",
                                                       "Ulica");

       public static ltext s_HouseNumber =  new ltext ("Adress Number",
                                                    "Hišna številka");

       public static ltext s_City =  new ltext ("City",
                                         "Mesto");

       public static ltext s_State =  new ltext ("State",
                                         "Dežela");

       public static ltext s_ZIP =  new ltext ("ZIP",
                                        "Poštna Številka");

       public static ltext s_Country =  new ltext ("Country",
                                         "Država");

       public static ltext s_PhoneNumber =  new ltext ("Phone number",
                                                "Telefonska številka");

       public static ltext s_FaxNumber =  new ltext ("Fax number",
                                              "Telefaks");

       public static ltext s_HomePage =  new ltext ("Home page",
                                              "Domača stran");

       public static ltext s_Email =  new ltext ("Email",
                                          "Elektronski naslov");

       
       public static ltext s_Organisation = new ltext("Organisation",
                                                      "Organizacija");

       public static ltext s_ManufacturerName =  new ltext ("Manufacturer",
                                                     "Proizvajalec");

       public static ltext s_VehicleCategory =  new ltext ("Category",
                                                    "Tip vozila");

       public static ltext s_FuelType =  new ltext ("Fuel type",
                                             "Vrsta goriva");

       public static ltext s_Directory =  new ltext ("Folder",
                                             "Mapa");

       public static ltext s_ImportFrom =  new ltext ("Import from",
                                               "Uvozi iz");
       public static ltext s_Does_not_exist_Create_this_folder = new ltext ("Does not exist.\nCreate this folder?",
                                                                    " ne obstaja. Naj se mapa naredi?");

       public static ltext s_Created = new ltext (" is successfully created!",
                                            "je uspešno narejena.");

       public static ltext s_There_Is_No_Column_Name = new ltext ("There is no column name ",
                                            "Ne obstaja stolpec z imenom");

       public static ltext s_In_Table = new ltext (" in tabel",
                                            " v tabeli");

       public static ltext s_Data_From_File   = new ltext ("Data From File",
                                                   "Podatki iz datoteke");

       public static ltext s_are_successuly_imported_into_table = new ltext (" are successfully imported into table ",
                                                   " so uspešno vpisani v tabelo ");

       public static ltext s_in_DataBase = new ltext (" in database",
                                                   " podatkovne baze");

       public static ltext s_on_Server = new ltext (" on server",
                                                   " na strežniku");

       public static ltext s_Vehicle = new ltext (" Vehicle",
                                           " Vozilo");

       public static ltext s_No_Table_or_Column_Name_in_Line = new ltext (" No Table or Column Name in line ",
                                                           " Manjka ime tabela ali ime stolpca v vrtsici ");

       public static ltext s_Table= new ltext ("Table",
                                        "Tabela");
       public static ltext s_Not_in_Database_line = new ltext (" is not in database, line:",
                                                   " ni v bazi podatkov, vrstica:");

       public static ltext s_Comma_is_missing_to_separate_cells_column_name_from_cell_value_in_line = new ltext ("Comma (',') is missing to separate cell's column name from cell value in line:",
                                                                               "Manjka vejica(',') ki bi ločevala ime stolpca v kateri je celica in njeno vrednost v vrstici:");

       public static ltext s_TableNameIsExpectedToBeBeforeDataLines = new ltext ("Table name is expected to be before column data lines !",
                                                                          "Manjka ime tabele pred podatki !");

       public static ltext s_CanNotFindColumnName = new ltext ("Can not find column name",
                                                        "V tabeli ni stolpca z imenom");

       public static ltext s_CanNotFindForeignKey = new ltext ("Can not find foreign key",
                                                        "V tabeli ni ključa z imenom");
       public static ltext s_CanNotFindIndexToTableID = new ltext ("There is no index name to foreign table",
                                                             "Manjka ime indexa na tabelo");

       public static ltext s_NoColumnName = new ltext ("Missing column name",
                                                   "Manjka ime stolpca");

       public static ltext s_Columns_Are = new ltext ("columns are",
                                               " so stolpci");

       public static ltext s_ForeignKeysAre = new ltext ("Foreign keys are",
                                                  "Ključi (povezave) so");

       public static ltext s_Illegal_end_table_XML_command_expected = new ltext ("Illegal end table XML command expected",
                                                                          "Neveljaven XML zaključek tabele, pričakuje se");
       public static ltext s_Illegal_format_for = new ltext ("Illegal format for",
                                                 "Neveljaven format for");

       public static ltext s_UnsuportedType = new ltext ("Unsupported type",
                                                  "Neveljaven typ");

       public static ltext sCreateRandomData = new ltext ("Create Random Data",
                                                   "Vnesi naključno generirane podatke");

       public static ltext sRandomDataSettings = new ltext ("Settings",
                                                            "Nastavitve");

       public static ltext sSettings = new ltext("Settings",
                                                            "Nastavitve");

       #region E3P Main menu
       public static ltext sRandomGeneratorSettings = new ltext("Random Generator Data Settings",
                                                        "Nastavitve generatorja naključnih podatkov");

       public static ltext sCreatetables = new ltext("CreateTables",
                                                     "Ustvari tabele");


        public static ltext sProgramSettings = new ltext("Program Settings",
                                                         "Programske nastavitve");


       #endregion 
       public static ltext sBtnCallSecretaryToWork = new ltext("Virtual Secretary",
                                                          "Virtualna tajnica");

       public static ltext sInsertData = new ltext ("Insert Data in Database",
                                             "Vpiši v bazo");

       
       public static ltext sUpdate = new ltext ("Update",
                                                    "Popravi");

       public static ltext sNew = new ltext("New",
                                                    "Nov vnos");

       public static ltext s_Woman = new ltext ("Woman",
                                       "Ženska");

       public static ltext s_Man = new ltext ("Man",
                                       "Moški");

        public static ltext s_Male = new ltext("Male",
                                        "Moški");

        public static ltext s_Female = new ltext("Female",
                                        "Ženski");

        public static ltext s_ErrorNoData = new ltext ("ERROR No Data! There are no InputControls!",
                                          "NAPAKA: Ni Podatkov! Input Kontrole niso ustvarjene!");

       public static ltext s_ErrorNoImage = new ltext ("ERROR No image in Func.ImageStore!",
                                                "NAPAKA: Ni slike v Func.ImageStore!");

       public static ltext s_FolderMan = new ltext (" Folder of Man pictures !",
                                                " Mapa moških fotografij");
       public static ltext s_FolderWoman = new ltext (" Folder of Woman pictures!",
                                                " Mapa ženskih fotografij");

       public static ltext s_Folder = new ltext(" Folder ",
                                                " Mapa ");

       public static ltext s_FolderNotExists = new ltext(" Folder not exists:",
                                                " Mapa ne obstaja:");

       #region Options Form

       public static ltext s_You_must_restart_program_to_take_language_change_effect = new ltext(" You must restart program to take language change effect!",
                                                                                        "Morate ponovno zagnati program, da bi sprememba jezika imela učinek!");

       public static ltext s_You_must_restart_program_for_this_program_work_as = new ltext(" You must restart program for this program to work as:",
                                                                                          "Morate ponovno zagnati program, da bi da bi ta program delal kot:");

       public static ltext s_SloveneLanguage = new ltext("Slovene",
                                                         "Slovensko");

       public static ltext s_EnglishLanguage = new ltext("English",
                                                         "Angleško ");

       public static ltext s_ViewSQLcommandBeforeExecution = new ltext("Preview SQL command before Execution",
                                                                       "Prikaži SQL ukaz pred izvedbo");

       public static ltext s_sChangeWorkingPlace = new ltext("Change wroking place",
                                                             "Spremeni delovno mesto");


       public static ltext s_DefaultXMLFolder = new ltext("Default INI files Folder",
                                                          "Privzeta mapa INI datotek");
       public static ltext s_XMLFolder = new ltext("INI files Folder",
                                                   "Mapa INI datotek");

       public static ltext s_CreateNewFolder = new ltext("Create New Folder",
                                                         "Ustvari novo mapo");

       public static ltext s_ErrorCreateNewFolder = new ltext("ERROR: Create New Folder",
                                                              "Prišlo je do napake pri ustvarjanju nove mape.");
       #endregion

       #region XML

       public static ltext s_Error_Saving_XMLFile = new ltext("ERROR: Create New Folder",
                                                              "Prišlo je do napake pri ustvarjanju nove mape.");
       public static ltext s_XMLFolderIsNotDefined = new ltext("XMLFolder is not defined yet. Use Program Settings to define it!",
                                                               "XML mapa ni določene. V programskih nastavitvah izberite XML mapo!");

       public static ltext s_XmlFileNotLoadedInXmlDocument = new ltext("XML file is not loaded into XmlDocument!",
                                                                       "XML datoteka ni uspešno preprana v XmlDokument!");

       public static ltext s_XmlRootNotFound = new ltext("XML root node not found!",
                                                   "XML začetno vozlišče ni ustrezno!");

       public static ltext s_XmlNodeNotFound = new ltext("Can not find node ",
                                                   "Ne najdem vozlisča ");

       public static ltext s_Expected = new ltext(" Expected ",
                                                   " Pričakuje se ");

       public static ltext s_XmlIlegalNode = new ltext(" Illegal xml node ",
                                                       " Neveljavno xml stičišče ");
       #endregion


       #region LogIn

       public static ltext s_Cancel = new ltext ("Cancel",
                                          "Prekini");

        public static ltext s_sSelectWorkingPlaceLevel = new ltext ("Select working place",
                                                             "Izberi delovno mesto");

        public static ltext s_sChangeWorkingPlaceLevel = new ltext ("Change working place",
                                                             "Zamenjaj delovno mesto");

        public static ltext s_sLoginPassword = new ltext ("Password:",
                                                   "Geslo:");

        public static ltext s_sLoginEnterPassword = new ltext ("Please enter password for:",
                                                        "Prosim vnesite geslo za:");


        public static ltext s_sLoginFailedEnterPassword = new ltext ("Password is wrong!\nEnter password again for:",
                                                              "Geslo je napačno!\nVnesite geslo za:");

        public static ltext s_sLoginAccessDenied = new ltext ("Password is wrong!\nAccess denied for:",
                                                       "Geslo je napačno!\nDostop onemogočen za:");

        public static ltext s_ADMINISTRATOR = new ltext ("Adminsitrator",
                                                  "Adminsitrator");

        public static ltext s_MINISTRY_ADMINISTRATOR = new ltext ("Ministry Administrator",
                                                           "Ministrski Adminsitrator");

        public static ltext s_MINISTRY_SUPERVISOR = new ltext ("Ministry Supervisor",
                                                        "Ministrski Nadzornik");

        public static ltext s_CARINA_ADMINISTRATOR = new ltext ("Customs Administrator",
                                                         "Carinski Administrator");

        public static ltext s_CARINA_SUPERVISOR = new ltext ("Customs Supervisor",
                                                      "Carinski Nadzornik");

        public static ltext s_POLICE_ADMINISTRATOR = new ltext ("Police Administrator",
                                                         "Policijski Administrator");

        public static ltext s_POLICE_SUPERVISOR = new ltext ("Police Supervisor",
                                                      "Policijski Nadzornik");

        public static ltext s_TEHSimpleItem_ADMINISTRATOR = new ltext ("Inspection SimpleItem Administrator",
                                                             "Tehnični Servis Administrator");

        public static ltext s_TEHSimpleItem_SUPERVISOR = new ltext ("Inspection SimpleItem Supervisor",
                                                          "Tehnični Servis Nadzornik");
        #endregion
        #region RandomControl

        public static ltext s_Start = new ltext ("Start!",
                                          "Začni!");

        public static ltext s_Pause = new ltext ("Pause",
                                          "Pavza");

        public static ltext s_VirtaulSecretary = new ltext ("Virtual Secretary",
                                                     "Virtualna Tajnica");

        public static ltext s_NumberOfEntries = new ltext ("Number of Entries:",
                                                    "Število vnosov:");

        #endregion

        #region TableNames

        #endregion

        public static ltext s_DropAllTablesNotSupported_for_data_base_type = new ltext("Drop all tables not supported for data base type", "Brisanje vseh tabel ni podprto za podtakovno bazo tipa ");
        public static ltext s_TablesInSQLiteDatabase = new ltext("Tables in SQLite Database:", "Tabele v SQLite podatkovni bazi:");
        public static ltext s_AreNotOK_CreateNewTable = new ltext(" are not valid ! Create new DataBase and Tables?", " niso veljavne! Ustvarimo novo SQLite podatkovno bazo in tabele?");

        public static ltext s_Error_Table_DoesNotHavePrimary_ID = new ltext("Error table does not have primary ID!",
                                                                            "Napaka tabela nima indexnega stolpca!");

        public static ltext s_DataBaseHasNoTablesItIsEmpty = new ltext("Database has not tables.It is allready empty.",
                                                                       "Podatkovna baza nima tabel. Je prazna.");



        public static ltext s_lbl_StreetName = new ltext("Adress", "Naslov");
        public static ltext s_lbl_Street_Number = new ltext("House number", "Hišna št.");
        public static ltext s_lbl_Post = new ltext("Post number", "Poštna št.");
        public static ltext s_lbl_City = new ltext("City", "Kraj");
    }
}
     
