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
    public static class lngTName
    {

        public static ltext lngt_t_Atom_Bank = new ltext("Archive Bank", "Arhiv bank");
        public static ltext lngt_t_Atom_BankAccount = new ltext("Archive Bank Account", "Arhiv bančnih računov");
        public static ltext lngt_t_Atom_OrganisationAccount = new ltext("Archive Organisation Account", "Arhiv bančnih računov organizacije");
        public static ltext lngt_t_Atom_PersonData = new ltext("Archive Personal Data", "Arhiv osebnih podatkov");
        public static ltext lngt_t_Atom_PersonAccount = new ltext("Archive Person Bank Accounts", "Arhiv osebnih bančnih računov");
        public static ltext lngt_t_JOURNAL_Name = new ltext("JOURNAL type name", "Ime vrste dogodka");
        public static ltext lngt_t_JOURNAL_TableName = new ltext("JOURNAL Table Name", "Tabela dogodka");
        public static ltext lngt_t_JOURNAL_TYPE = new ltext("JOURNAL type", "Vrsta dogodka");
        public static ltext lngt_t_JOURNAL = new ltext("JOURNAL", "Dnevnik dogodkov");




        public static ltext lngt_t_JOURNAL_myOrganisation_Person = new ltext("myOrganisation Person event", "Dogodek osebe moje organizacije");
        public static ltext lngt_t_JOURNAL_myOrganisation_Person_TYPE = new ltext("myOrganisation Person event type", "Vrsta dogodka osebe moje organizacije");
        public static ltext lngt_t_JOURNAL_myOrganisation_Person_AccessRights_TYPE = new ltext("myOrganisation Person AccessRights event type", "Vrsta dogodka pravic osebe moje organizacije");
        public static ltext lngt_t_JOURNAL_myOrganisation_Person_AccessRights = new ltext("myOrganisation Person AccessRights event", "Dogodek pravic osebe moje organizacije");
        public static ltext lngt_t_FVI_SLO_SalesBookInvoice = new ltext("Sales Book Invoice", "Vezana knjiga računov");
        public static ltext lngt_t_DocInvoice_ShopA_Item = new ltext("Invoice ShopA Item ", "Artikli prodajalne A na računu");
        public static ltext lngt_t_DocProformaInvoice_ShopA_Item = new ltext("Proforma invoice ShopA Item ", "Artikli prodajalne A na pred-računu");
        public static ltext lngt_t_Atom_ItemShopA = new ltext("Shopa A Item", "Prodajalna A Artikli");
        public static ltext lngt_t_Atom_Unit_ShopA = new ltext("Shopa A Unit", "Prodajalna A merske enote");
        public static ltext lngt_t_Atom_ItemShopA_Image = new ltext("Shopa A Item Image", "Prodajalna A Slika Artikla");
        public static ltext lngt_t_Notice = new ltext("Notice", "Dopis");
        public static ltext lngt_t_Atom_FVI_SLO_RealEstateBP = new ltext("FVI_SLO RealEstateBP", "Davčni podatki o poslovnem prostoru");
        public static ltext lngt_t_FVI_SLO_Response = new ltext("FVI Response", "Overovljanje računov pri davčni upravi");
        public static ltext lngt_t_FVI_SLO_RealEstateBP = new ltext("Business premises", "Davčni podatki o poslovnem prostoru");
        public static ltext lngt_t_doc_page_type = new ltext("Document page type", "Oblika strani dokumenta");
        public static ltext lngt_t_Language = new ltext("Language", "Jezik");
        public static ltext lngt_t_JOURNAL_doc = new ltext("Document journal", "Dnevnik dokumenta");
        public static ltext lngt_t_JOURNAL_doc_Type = new ltext("Document journal type", "Vrsta dogodka dokumenta");
        public static ltext lngt_t_doc = new ltext("Document", "Dokument");
        public static ltext lngt_t_doc_type = new ltext("Document type", "Vrsta dokumenta");
        public static ltext lngt_Atom_WorkPeriod_Descrition = new ltext("Working shift description", "Vrsta šihta opis");
        public static ltext lngt_Atom_WorkPeriod_TYPE = new ltext("Working shift type", "Vrsta šihta");
        public static ltext lngt_Atom_Office_Data = new ltext("Office Data archive", "Poslovna enota podatki arhiv");
        public static ltext lngt_Office_Data = new ltext("Office Data", "Poslovna enota podatki");
        public static ltext lngt_JOURNAL_Delivery = new ltext("Journal Delivery", "Dnevnik dobave");
        public static ltext lngt_JOURNAL_Delivery_Type = new ltext("Journal Delivery types", "Dnevnik vrst dobave");
        public static ltext lngt_Delivery = new ltext("Delivery", "Dobava");
        public static ltext lngt_DeliveryType = new ltext("Delivery type", "Vrsta dobave");
        public static ltext lngt_Atom_WorkPeriod = new ltext("Working shift", "Šiht");
        public static ltext lngt_Atom_WorkingPlace = new ltext("Working place archive", "Delovno mesto arhiv");
        public static ltext lngt_Atom_Office = new ltext("Office archive", "Poslovna enota arhiv");
        public static ltext lngt_WorkingPlace = new ltext("Working place", "Delovno mesto");
        public static ltext lngt_Atom_Computer = new ltext("Computer archive", "Računalnik arhiv");
        public static ltext lngt_Office = new ltext("Office", "Poslovna enota");

        public static ltext lngt_Atom_PersonImage = new ltext("Person Image archive", "Slika osebe arhiv");
        public static ltext lngt_Atom_cEmail_Person = new ltext("Email archive", "e-pošta arhiv");

        public static ltext lngt_Atom_cGsmNumber_Person = new ltext("GSM Number archive", "GSM");
        public static ltext lngt_Atom_cPhoneNumber_Person = new ltext("Phone Number archive", "Telefon arhiv");
        public static ltext lngt_Atom_cCardType_Person = new ltext("Card Type archive", "Vrsta kartice arhiv");
        public static ltext lngt_Atom_cLastName = new ltext("Last Name archive", "Priimek arhiv");
        public static ltext lngt_Atom_cFirstName = new ltext("First Name archive", "ime arhiv");

        public static ltext lngt_Atom_Logo = new ltext("Organisation Logo archive", "Organizacija logotip arhiv");
        public static ltext lngt_Logo = new ltext("Organisation Logo", "Organizacija logotip");
        public static ltext lngt_SimpleItem_ParentGroup1 = new ltext("SimpleItem Parent Group 1", "skupina");
        public static ltext lngt_SimpleItem_ParentGroup2 = new ltext("SimpleItem Parent Group 2", "pod-skupina");
        public static ltext lngt_SimpleItem_ParentGroup3 = new ltext("SimpleItem Parent Group 3", "pod-pod-skupina");

        public static ltext lngt_JOURNAL_Stock = new ltext("Journal stock", "Dnevnik skladišče");
        public static ltext lngt_JOURNAL_Taxation = new ltext("Journal taxation", "Dnevnik davki");
        public static ltext lngt_JOURNAL_PurchasePrice = new ltext("Journal purchase price", "Dnevnik nabavne cene");
        public static ltext lngt_JOURNAL_Customer_Org = new ltext("Journal customer organisation", "Dnevnik stranka pravna oseba");

        public static ltext lngt_JOURNAL_Customer_Person_Data_Image = new ltext("Journal customer person data image", "Dnevnik Kartoteka slike");
        public static ltext lngt_JOURNAL_Customer_Person_Data = new ltext("Journal customer person data", "Dnevnik Kartoteka");
        public static ltext lngt_JOURNAL_Customer_Person = new ltext("Journal customer person", "Dnevnik stranka fizična oseba");

        public static ltext lngt_JOURNAL_Person = new ltext("Journal person", "Dnevnik fizične osebe");
        public static ltext lngt_JOURNAL_myOrganisation = new ltext("Journal myOrganisation", "Dnevnik moja organizacija");
        public static ltext lngt_JOURNAL_PriceList = new ltext("Journal PriceList", "Dnevnik Cenik");
        public static ltext lngt_JOURNAL_SimpleItem = new ltext("Journal SimpleItem", "Dnevnik SimpleItem");
        public static ltext lngt_JOURNAL_Item = new ltext("Journal Item", "Dnevnik Artikel");
        public static ltext lngt_JOURNAL_DocProformaInvoice = new ltext("Journal Proforma Invoice", "Dnevnik Predračun");
        public static ltext lngt_JOURNAL_DocInvoice = new ltext("Journal Invoice", "Dnevnik Račun");

        public static ltext lngt_JOURNAL_Invoice_Type = new ltext("Journal event  Invoice", "Dogodek Račun tip");
        public static ltext lngt_JOURNAL_Stock_Type = new ltext("Journal event  Stock", "Dogodek skladišče");
        public static ltext lngt_JOURNAL_Taxation_Type = new ltext("Journal event  Taxation", "Dogodek davki");
        public static ltext lngt_JOURNAL_PurchasePrice_Type = new ltext("Journal event  purchase price", "Dogodek nabavne cene");
        public static ltext lngt_JOURNAL_Customer_Org_Type = new ltext("Journal event  customer organisation", "Dogodek stranke pravne osebe");
        public static ltext lngt_JOURNAL_Customer_Person_Type = new ltext("Journal event  customer person", "Dogodek stranke fizične osebe");
        public static ltext lngt_JOURNAL_myOrganisation_Person_Type = new ltext("Journal event  employee", "Dogodek zaposleni");
        public static ltext lngt_JOURNAL_myOrganisation_Type = new ltext("Journal event  my company", "Dogodek moja organizacija");
        public static ltext lngt_JOURNAL_SimpleItem_Type = new ltext("Journal event  SimpleItem", "Dogodek storitve");
        public static ltext lngt_JOURNAL_Item_Type = new ltext("Journal event  item", "Dogodek artikli");
        public static ltext lngt_JOURNAL_DocInvoice_Type = new ltext("Journal event  DocInvoice", "Dogodek računa");
        public static ltext lngt_JOURNAL_DocProformaInvoice_Type = new ltext("Journal event  DocProformaInvoice", "Dogodek predračuna");
        public static ltext lngt_JOURNAL_PriceList_Type = new ltext("Journal event  PriceList Account", "Dogodek cenik");


        public static ltext lngt_OrganisationAccount = new ltext("Organisation Account", "Račun organizacije");
        public static ltext lngt_BankAccount = new ltext("Bank Account", "Bančni račun");
        public static ltext lngt_Bank = new ltext("Bank", "Banka");
        public static ltext lngt_PersonAccount = new ltext("Person Account", "Osebni račun");
        public static ltext lngt_PersonData = new ltext("Person Data", "Osebni podatki");
        public static ltext lngt_Suplier = new ltext("Supplier", "Dobavitelj");
        public static ltext lngt_Customer_Org  = new ltext("Customer Organisation", "Stranka organizacija");
        public static ltext lngt_Customer_Person = new ltext("Customer Person", "Stranka fizična oseba");
        public static ltext lngt_Atom_Customer_Org = new ltext("Customer Organisation archive", "Stranka organizacija arhiv");
        public static ltext lngt_Atom_Customer_Person = new ltext("Customer Perso archive", "Stranka fizična oseba arhiv");

        public static ltext lngt_PersonImage = new ltext("Person Image", "Slika osebe");
        public static ltext lngt_Reference_Image = new ltext("Reference document image", "Sklic slika dokumenta");
        public static ltext lngt_PurchasePrice = new ltext("Purchase price", "Nabavna cena");
        public static ltext lngt_Atom_OrganisationData = new ltext("Organisation Data archive", "Podatki o organizaciji arhiv");
        public static ltext lngt_OrganisationData = new ltext("Organisation Data", "Podatki o organizaciji");
        public static ltext lngt_myOrganisation_Person_AccessRights = new ltext("My Organisation Person Access Rights", "Dostopne pravice osebe v podjetju");
        public static ltext lngt_AccessRights = new ltext("Access Rights", "Dostopne pravice");
        public static ltext lngt_myOrganisation_PersonData = new ltext("My Organisation Person Data", "Podatki o uporabniku v podjetju");
        public static ltext lngt_Units = new ltext("Measurement unit", "Merska enota");
        public static ltext lngt_UnitsArchive = new ltext("Measurement unit archive", "Merska enota arhiv");
        public static ltext lngt_PurchasePriceList = new ltext("Purchase price list", "NABAVNI CENIK");
        public static ltext lngt_DocInvoice_ShopB_Item = new ltext("Invoice ShopB Item", "Artikli trgovine B na računu");
        public static ltext lngt_DocProformaInvoice_ShopB_Item = new ltext("Proforma Invoice ShopB Item", "Artikli trgovine B na pred-računu");
        public static ltext lngt_Atom_Price_Item = new ltext("Price Item archive", "Cena Artikel arhiv");
        public static ltext lngt_PriceListType = new ltext("Price List Type", "Tip cenika");
        public static ltext lngt_PriceListTypeAtom = new ltext("Price List Type archive", "Tip cenika arhiv ");
        public static ltext lngt_Atom_Currency = new ltext("Currency archive", "Valuta arhiv");
        
        public static ltext lngt_PurchasePrice_Item = new ltext("Item purchase price", "Nabavne cene artiklov");
        public static ltext lngt_PurchasePriceList_Item = new ltext("Purchase Price list for items", "Nabavni cenik artiklov");
        public static ltext lngt_Atom_PriceList = new ltext("Price list", "Cenik");
        public static ltext lngt_ExchangeRateSource = new ltext("Exchange Rate Source", "Vir Menjalnega razmerja");
        public static ltext lngt_RateToBaseCurrency = new ltext("Exchange Rate to Base Currency", "Menjalno razmerje glede na osnovno valuto");
        public static ltext lngt_BaseCurrency = new ltext("Base Currency", "Osnovna Valuta");
        public static ltext lngt_Currency = new ltext("Currency", "Valute");
        public static ltext lngt_PriceList = new ltext("Price list", "Cenik");
        public static ltext lngt_Price_Item = new ltext("Price list item", "Cenik artiklov");
        public static ltext lngt_Price_SimpleItem = new ltext("Price list SimpleItem", "Cenik storitev");
        
        public static ltext lngt_Atom_cAddress_Org = new ltext("Address Organisation", "Naslovi organizacij");
        public static ltext lngt_Atom_cAddress_Person = new ltext("Address Person", "Naslovi oseb");
        public static ltext lngt_cAddress_Org = new ltext("Address Organisation", "Naslovi organizacij");
        public static ltext lngt_cAddress_Person = new ltext("Address Person", "Naslovi oseb");
        public static ltext lngt_Atom_cState_Org = new ltext("State", "Dežela");
        public static ltext lngt_Atom_cCountry_Org = new ltext("Country", "Država");
        public static ltext lngt_Atom_cZIP_Org = new ltext("ZIP", "Številka pošte");
        public static ltext lngt_Atom_cCity_Org = new ltext("City", "Kraj");
        public static ltext lngt_Atom_cHouseNumber_Org = new ltext("House number", "Hišna številka");
        public static ltext lngt_Atom_cStreetName_Org = new ltext("Street name", "Cesta prebivališča");

        public static ltext lngt_Atom_cState_Person = new ltext("State", "Dežela");
        public static ltext lngt_Atom_cCountry_Person = new ltext("Country", "Država");
        public static ltext lngt_Atom_cZIP_Person = new ltext("ZIP", "Številka pošte");
        public static ltext lngt_Atom_cCity_Person = new ltext("City", "Kraj");
        public static ltext lngt_Atom_cHouseNumber_Person = new ltext("House number", "Hišna številka");
        public static ltext lngt_Atom_cStreetName_Person = new ltext("Street name", "Cesta prebivališča");

        public static ltext lngt_Stock_AddressLevel1 = new ltext("Stock Address Level 2", "Naslov skladišča 1");
        public static ltext lngt_Stock_AddressLevel2 = new ltext("Stock Address Level 2", "Naslov skladišča 2");
        public static ltext lngt_Stock_AddressLevel3 = new ltext("Stock Address Level 3", "Naslov skladišča 3");
        public static ltext lngt_Item_ParentGroup1 = new ltext("Item Parent Group 1", "Artikel skupina 1");
        public static ltext lngt_Item_ParentGroup2 = new ltext("Item Parent Group 2", "Artikel skupina 2");
        public static ltext lngt_Item_ParentGroup3 = new ltext("Item Parent Group 3", "Artikel skupina 3");
        public static ltext lngt_Atom_Expiry = new ltext("Expiry archive", "Rok uporabe arhiv");
        public static ltext lngt_Atom_Warranty = new ltext("Warranty arhiv", "Garancija arhiv");
        public static ltext lngt_Expiry = new ltext("Expiry", "Rok uporabe");
        public static ltext lngt_Warranty = new ltext("Warranty", "Garancija");
        public static ltext lngt_Atom_Item_ExpiryDescription = new ltext("Expiry Description", "Pogoji uporabe");
        public static ltext lngt_Item_Image = new ltext("Item Image", "Slika artikla");
        
        public static ltext lngt_SimpleItem_Image = new ltext("SimpleItem Image", "Slika storitve");
        public static ltext lngt_DBm_Image_Name = new ltext("Image Name", "Ime posnetka");
        public static ltext lngt_DBm_Image_Author = new ltext("Image Author", "Avtor posnetka");
        public static ltext lngt_DBm_Image_CaptureLocation = new ltext("Capture Location", "Kraj posnetka");
        public static ltext lngt_DBm_Image_FileName = new ltext("Image File Name", "Ime datoteke");
        public static ltext lngt_DBm_Image_Ext = new ltext("Image type (extension)", "Tip posnetka (Končnica)");
        public static ltext lngt_DBm_Image_Path = new ltext("Image path", "Izvorna pot posnetka");
        public static ltext lngt_DBm_Image_Computer = new ltext("Computer source of Image", "Izvorni računalnik posnetka");
        public static ltext lngt_DBm_Image_ComputerUser = new ltext("Computer user source of image ID", "Izvorni računalniški uporabnik posnetka ID");
        public static ltext lngt_DBm_Image_CaptureTime = new ltext("Capture time", "Čas posnetka");
        public static ltext lngt_DBm_Image_Size = new ltext("Image Size", "Velikost posnetka");
        public static ltext lngt_DBm_Image_Data = new ltext("Image", "Posnetek");
        public static ltext lngt_DBm_Image = new ltext("Image", "Slika");

        public static ltext lngt_DBm_Document_Name = new ltext("Document Name", "Ime dokumenta");
        public static ltext lngt_DBm_Document_Author = new ltext("Document Author", "Avtor dokumenta");
        public static ltext lngt_DBm_Document_CaptureLocation = new ltext("Capture Location", "Kraj dokumenta");
        public static ltext lngt_DBm_Document_FileName = new ltext("Document File Name", "Ime datoteke");
        public static ltext lngt_DBm_Document_Ext = new ltext("Document type (extension)", "Tip dokumenta (Končnica)");
        public static ltext lngt_DBm_Document_Path = new ltext("Document path", "Izvorna pot dokumenta");
        public static ltext lngt_DBm_Document_Computer = new ltext("Computer source of Document", "Izvorni računalnik dokumenta");
        public static ltext lngt_DBm_Document_ComputerUser = new ltext("Computer user source of Document ID", "Izvorni računalniški uporabnik dokumenta ID");
        public static ltext lngt_DBm_Document_CaptureTime = new ltext("Capture time", "Čas dokumenta");
        public static ltext lngt_DBm_Document_Size = new ltext("Document Size", "Velikost dokumenta");
        public static ltext lngt_DBm_Document_Data = new ltext("Document content", "Dokument - vsebina");
        public static ltext lngt_DBm_Document = new ltext("Document", "Dokument");


        public static ltext lngt_InvoiceItem = new ltext("Product Item", "Artikel");
        public static ltext lngt_Invoice = new ltext("Invoice", "Račun");
        public static ltext lngt_SimpleItem = new ltext("SimpleItem", "Storitev");
        public static ltext lngt_Stock = new ltext("Stock", "Zaloge");
        public static ltext lngt_Taxation = new ltext("Taxation", "Davki");
        public static ltext lngt_ItemName = new ltext("Item Name", "Ime artikla");
        public static ltext lngt_Reference = new ltext("Reference", "Sklic");
        public static ltext lngt_myOrganisation = new ltext("My Organisation", "Moja Firma");
        public static ltext lngt_Organisation = new ltext("Organisation", "Organizacija");
        public static ltext lngt_cOrgType = new ltext("Organisation Type", "Tip organizacije");
        public static ltext lngt_BuyerPerson = new ltext("Person", "Fizična oseba");
        public static ltext lngt_Press_Data_JOURNAL_DATA = new ltext("Press data JOURNAL DATA", "Podatki Dnevnika izdelave tablic");
        public static ltext lngt_Press_Data_JOURNAL_EVENT = new ltext("Press data JOURNAL EVENTS", "Dogodki Dnevnika izdelave tablic");
        public static ltext lngt_Press_Data_JOURNAL = new ltext("Press data JOURNAL", "Dnevnik izdelave tablic");
        public static ltext lngt_stock_symbols = new ltext("Symbol table", "Tabela znakov");
        public static ltext lngt_stock_symbols_type = new ltext("Symbol groups", "Skupine simbolov");
        public static ltext lngt_User = new ltext("Users", "Uporabniki");
        public static ltext lngt_Series = new ltext("Series", "Opis serij");
        public static ltext lngt_Orders = new ltext("Orders", "Naročila");
        public static ltext lngt_VehiclePlatesList = new ltext("Vehicle Plates List", "Seznam tablic");
        public static ltext lngt_PlateVersions = new ltext("Plate Versions", "Verzije Tablic");
        public static ltext lngt_Customer = new ltext("Customer", "Naročnik");
        public static ltext lngt_Press_Data = new ltext("Press Data", "Podatki za prešo");

        public static ltext lngt_Atom_Organisation = new ltext("Organisation archive", "Organizacija arhiv");
        public static ltext lngt_BuyerAtom_Person = new ltext("Buyer Person arh", "Kupec oseba arhiv");
        public static ltext lngt_Atom_myOrganisation = new ltext("My Organisation arh", "Moje podjetje arhiv");
        public static ltext lngt_Atom_myOrganisation_Person = new ltext("My Organisation Person arh", "Zaposleni arhiv");
        public static ltext lngt_t_DocInvoice_ShopC_Item = new ltext("Invoice ShopC Item", "Artikli prodajalne C na računu");
        public static ltext lngt_t_DocProformaInvoice_ShopC_Item = new ltext("Proforma Invoice ShopC Item", "Artikli prodajalne C na pred-računu");
        public static ltext lngt_myOrganisation_Person = new ltext("myCommpany_Person", "Oseba podjetja");
        public static ltext lngt_TermsOfPayment = new ltext("TermsOfPayment", "Plačilni pogoji");
        public static ltext lngt_Invoice_Image = new ltext("Invoice Image", "Račun Slika");
        public static ltext lngt_ProformaInvoice_Image = new ltext("Proforma Invoice Image", "Predračun Slika");
        public static ltext lngt_DocInvoice_Image = new ltext("Invoice Image", "Slike računa");
        public static ltext lngt_DocInvoice_Notice = new ltext("Invoice Notice", "Dopis na računu");
        public static ltext lngt_DocProformaInvoice_Notice = new ltext("Proforma Invoice Notice", "Dopis na predračunu");
        public static ltext lngt_DocProformaInvoice_Image = new ltext("Doc Proforma Invoice Image", "Slike predračuna");
        public static ltext lngt_Doc_ImageLib = new ltext("Document image library", "Knjižnica slik za dokumente");

        public static ltext lngt_DocInvoice = new ltext("Invoice", "Račun");
        public static ltext lngt_DocProformaInvoice = new ltext("Proforma Invoice", "Predračun");

        public static ltext lngt_Atom_SimpleItem_Image = new ltext("SimpleItem Image Archive", "Slika storitve arhiv");

        public static ltext lngt_Atom_Taxation  = new ltext("Taxation Archive", "Obdavčitev storitve arhiv");
        public static ltext lngt_Atom_SimpleItem_Name = new ltext("SimpleItem Name Archive", "Ime storitve arhiv");
        public static ltext lngt_Atom_Item_WarrantyConditions = new ltext("Atom_Item_WarrantyConditions", "Garancijski pogoji Artikla");
        public static ltext lngt_Atom_Item_Description = new ltext("Atom_Item_Description", "Opis Artikla");
        
        public static ltext lngt_Atom_Item_barcode = new ltext("Item barcode Archive", "barkoda artikla arhiv");
        public static ltext lngt_Atom_Item_Name = new ltext("Atom_Item_Name", "Ime Artikla");
        public static ltext lngt_Atom_Item_ImageLib = new ltext("Item Image Lib Archive", "Knjižnica Slik Artiklov");
        public static ltext lngt_Atom_Item_Image = new ltext("Item Image Archive", "Slika Artikla Arhiv");
        public static ltext lngt_cCardType_Perosn = new ltext("Card Type", "Vrsta Kartice");
        public static ltext lngt_cFirstName = new ltext("First Name","Ime");
        public static ltext lngt_cLastName = new ltext ("Last Name","Priimek");
        public static ltext lngt_cCmdTYPE = new ltext ("Command Type","Vrsta ukaza");
        public static ltext lngt_cHistory = new ltext ("History","Zgodovina");
        public static ltext lngt_cStreetName = new ltext ("Street Name","Ime ulice");
        public static ltext lngt_cHouseNumber = new ltext ("House Number","Hišna številka");
        public static ltext lngt_cStrAddr = new ltext ("Street Address","Naslov ulice");
        public static ltext lngt_cCity = new ltext ("City","Mesto");
        public static ltext lngt_cCountry= new ltext ("Country","Država");
        public static ltext lngt_cState = new ltext ("State","Dežela");
        public static ltext lngt_cPhoneNumber = new ltext ("Phone Number","Telefonska številka");
        public static ltext lngt_cFaxNumber = new ltext ("Fax Number","Faks");
        public static ltext lngt_cEmail = new ltext ("Email","Email");
        public static ltext lngt_cHomePage = new ltext ("HomePage","Domača stran");
        public static ltext lngt_cZIP = new ltext ("ZIP","Poštna številka");
        public static ltext lngt_cAddress = new ltext ("Address","Naslov");
        public static ltext lngt_cOrganisation = new ltext("Organisation", "Organizacija");
        public static ltext lngt_cVehicleCategory = new ltext ("Vehicle Category","Kategorija vozila");
        public static ltext lngt_cOwnerTYPE = new ltext ("Owner type","Vrsta lastništva");
        public static ltext lngt_cOwner = new ltext ("Owner","Lastnik");
        public static ltext lngt_crfidcode = new ltext ("RFID code","RFID koda");
        public static ltext lngt_cbarcode = new ltext ("BAR-code","barkoda");
        public static ltext lngt_cRegPNum = new ltext ("Register Plates Number","Številka tablice");
        public static ltext lngt_cChassisNumber = new ltext ("Chassis Number","Številka šasije");
        public static ltext lngt_cModelName = new ltext("Ime modela", "Model Name");
        public static ltext lngt_cManufName = new ltext ("Manufacturer Name","Proizvajalec");
        public static ltext lngt_cFuelType = new ltext ("Fuel Type","Vrsta goriva");
        public static ltext lngt_cColorType = new ltext ("Vehicle Color","Barva vozila");
        public static ltext lngt_cVehicle = new ltext ("Vehicle","Vozilo");
        public static ltext lngt_cDirection = new ltext ("Direction","Smer vožnje");
        public static ltext lngt_evt_ProcessTYPE = new ltext ("Process Type","Vrsta procesa");
        public static ltext lngt_evp_TskDescTYPE = new ltext ("Task TYPE","Vrsta naloge");
        public static ltext lngt_evp_TskDesc = new ltext ("Task Description","Opis Naloge");
        public static ltext lngt_evp_Task = new ltext ( "Police Task", "Policijska naloga" );
        public static ltext lngt_evt_Proc = new ltext ("Inspection Servis Process","Tehnični Servis Process");
        public static ltext lngt_evt_TehServis = new ltext ( "Inspection Servis", "Tehnični Servis" );
        public static ltext lngt_cGate = new ltext ("Gate","Vrata");

        public static ltext lngt_evc_Carina = new ltext ("Customs","Carina");
        public static ltext lngt_tsmi_ManageTables_Carina = new ltext ( "Customs", "Carina" );

        public static ltext lngt_cLocationTYPE = new ltext ("Location Type","Tip lokacije");
        public static ltext lngt_cLocation = new ltext ("Location","Lokacija");
        public static ltext lngt_cSOrganisation = new ltext ("Support Organisation","Servisna služba");
        public static ltext lngt_cDInvTYPE = new ltext ("Device Type","Vrsta naprave");
        public static ltext lngt_cDInv = new ltext ("Device","Naprava");
        public static ltext lngt_cPicture = new ltext ("Picture","Fotografija");
        public static ltext lngt_eva_Person = new ltext ("Person","Oseba");

        public static ltext lngt_Clanarina = new ltext("Dues", "Članarina");

        public static ltext lngt_tsmi_ManageTables_Person = new ltext ("Person","Oseba");
        public static ltext lngt_tsmi_ManageTables_Membership = new ltext("Membership", "Članarina");

        public static ltext lngt_eva_Permission = new ltext ("Permission","Dovoljenja");
        public static ltext lngt_eva_User = new ltext ("User","Uporabnik");
        public static ltext lngt_cOrgTYPE = new ltext ("Organisation Type","Vrsta Organizacije");
        public static ltext lngt_cOrg = new ltext ("Organisation","Organizacija");
        public static ltext lngt_evp_FieldC = new ltext ("Field Control","Kontrola na terenu");

        public static ltext tsmi_ManageTables_Police = new ltext ( "Field Control", "Kontrola na terenu" );


        public static ltext lngt_evp_Pol_Task = new ltext ("Police Order","Policijski Nalog");
        public static ltext lngt_Police = new ltext ( "Police", "Policija" );
        public static ltext lngt_Carina = new ltext ( "Customs", "Carina" );
        public static ltext lngt_TechnicalServise = new ltext ( "Vehicle inspection servis", "Tehnični pregled vozil" );


        #region New TableNames
        public static ltext lngt_cEmisija = new ltext("Emission", "Emisija");
        public static ltext lngt_cStreetName_Org = new ltext("Street Name","Ime ulice");
        public static ltext lngt_cStreetName_Person = new ltext("StreetName","Ime ulice");
        public static ltext lngt_cHouseNumber_Org = new ltext("House Number","Hišna številka");
        public static ltext lngt_cHouseNumber_Person = new ltext("House Number","Hišna številka");
        public static ltext lngt_cStrAddr_Org = new ltext("Street Address","Hišni naslov");
        public static ltext lngt_cStrAddr_Person = new ltext("Street Address", "Hišni naslov");
        public static ltext lngt_cCity_Org = new ltext("City","Mesto");
        public static ltext lngt_cCity_Person = new ltext("City", "Mesto");
        public static ltext lngt_cCountry_Org = new ltext("Country","Država");
        public static ltext lngt_cCountry_Person = new ltext("Country", "Država");
        public static ltext lngt_cState_Org = new ltext("State","Dežela");
        public static ltext lngt_cState_Person = new ltext("State", "Dežela");
        public static ltext lngt_cPhoneNumber_Org = new ltext("Phone Number","Tel. številka");
        public static ltext lngt_cPhoneNumber_Person = new ltext("Phone Number", "Tel. številka");
        public static ltext lngt_cGsmNumber_Person = new ltext("Gsm Number", "Gsm številka");
        public static ltext lngt_cFaxNumber_Org = new ltext("Fax Number","Faks. številka");
        public static ltext lngt_cFaxNumber_Person = new ltext("Fax Number", "Faks. številka");
        public static ltext lngt_cEmail_Org = new ltext("Email","Elektronski naslov");
        public static ltext lngt_cEmail_Person = new ltext("Email", "Elektronski naslov");
        public static ltext lngt_cHomePage_Org = new ltext("Home Page", "Domača stran");
        public static ltext lngt_cHomePage_Person = new ltext("Personal Home Page", "Osebna Domača stran");
        public static ltext lngt_cZIP_Org = new ltext("ZIP","Poštna Številka");
        public static ltext lngt_cZIP_Person = new ltext("ZIP", "Poštna Številka");
        public static ltext lngt_evt_ProcessTYPE_FC_Police = new ltext("Police Field Control Process Type","Policijska kontrola tip procesa");
        public static ltext lngt_evt_ProcessTYPE_TehServis = new ltext("Inspection SimpleItem Process Type","Vrsta procesa na tehničnem servisu");
        public static ltext lngt_evt_Proc_TehServis = new ltext("Inspection SimpleItem Process", "Proces tehničnega servisa");
        public static ltext lngt_cDInv_Carina = new ltext("Inventory Customs","Inventar Carine");
        public static ltext lngt_cDInv_FC_Police = new ltext("Inventory Polic","Inventar Policije");
        public static ltext lngt_cDInv_Person = new ltext("Inventory Of Person Administration","Inventar urejanja osebnih podatkov");
        public static ltext lngt_cDInv_TehServis = new ltext("Inventory Of Inspection SimpleItems", "Inventar Tehinčnega servisa");
        public static ltext lngt_cLocationTYPE_Carina = new ltext("Customs Location","Lokacija Carine");
        public static ltext lngt_cLocationTYPE_Org = new ltext("Organisation Location Taype","Vrste lokacije Organizacije");
        public static ltext lngt_cLocationTYPE_Person = new ltext("Person Administration Location Type", "Vrsta mesta administriranja osebnih podatkov");
        public static ltext lngt_cLocationTYPE_FC_Police = new ltext("Field Control Location Type","Vrsta lokacije kontrole na terenu");
        public static ltext lngt_cLocationTYPE_TehServis = new ltext("Inspection SimpleItem Location Type","Vrsta lokacije tehničnega servisa");
        public static ltext lngt_cLocation_Carina = new ltext("Customs Location","Lokacija Carine");
        public static ltext lngt_cLocation_Org = new ltext("Organisation Location","Lokacija Organizacije");
        public static ltext lngt_cLocation_FC_Police = new ltext("Field Control Location","Lokacija kontrole na terenu");
        public static ltext lngt_cLocation_TehServis = new ltext("Inspection SimpleItem Location","Lokacija Tehničnega servisa");
        public static ltext lngt_cSOrganisation_Carina = new ltext("Support company for Customs","Servisna služba za carino");
        public static ltext lngt_cSOrganisation_FC_Police = new ltext("Support company for Police", "Servisna služba za policijo");
        public static ltext lngt_cSOrganisation_Person = new ltext("Support company for Perosnal Administration", "Servisna služba adminsitracije osebnih podatkov");
        public static ltext lngt_cSOrganisation_TehServis = new ltext("Support company for Inspection SimpleItem", "Servisna služba za tehnični servis");
        public static ltext lngt_cDInvTYPE_Carina = new ltext("Inventory type of Customs","Tip carinske opreme");
        public static ltext lngt_cDInvTYPE_FC_Police = new ltext("Inventory type of Police Field Control", "Tip policijske opreme na terenu");
        public static ltext lngt_cDInvTYPE_Person = new ltext("Inventory type of Personal Administration", "Tip opreme adminsitracije osebnih podatkov");
        public static ltext lngt_cDInvTYPE_TehServis = new ltext("Inventory type of Inspection SimpleItem", "Tip opreme na tehničnem servisu");
        public static ltext lngt_cPicture_Carina = new ltext("Picture at Customs","Slika na Carini");
        public static ltext lngt_cPicture_FC_Police = new ltext("Picture of the field control","Slika iz terena");
        public static ltext lngt_cPicture_Person = new ltext("Picture Of Person","Slika Osebe");
        public static ltext lngt_cPicture_TehServis = new ltext("Picture at Inspoection Servise", "Slike na tehničnem servisu");
        public static ltext lngt_eva_Permission_FC_Police = new ltext("Permission of field control user","Uporabniška dovoljenja delavca na terenu");
        public static ltext lngt_eva_Permission_Person = new ltext("User Permission to enter personal data", "Uporabniška dovoljenja za vnos osebnih podatkov");
        public static ltext lngt_eva_Permission_Vehicle = new ltext("User Permission to enter vehicle data", "Uporabniška dovoljenja za vnos podatkov vozil");
        public static ltext lngt_eva_Permission_TehServis = new ltext("User Permission to enter Insection SimpleItem data", "Uporabniška dovoljenja za vnos podatkov na tehničnem servisu");
        public static ltext lngt_eva_User_Person = new ltext("User Login data for personal administration ","Uporabniški podatki za prijavo osebne administracije");
        public static ltext lngt_eva_User_FC_Police = new ltext("User Login data for police field control", "Uporabniški podatki za prijavo kontrole na terenu");
        public static ltext lngt_eva_User_TehServis = new ltext("User Login data for Inspection SimpleItem", "Uporabbniški podatki za prijavo na tehničnem servisu ");
        public static ltext lngt_evp_FC_Police = new ltext("Police Field Control", "Policijska Kontrola na Terenu");
        public static ltext lngt_ManufName_Carina = new ltext("Customs equipment manufacturer", "Dopavitelj opreme Carini");
        public static ltext lngt_ManufName_TehServis = new ltext("Inspection SimpleItems equipment manufacturer", "Dobavitelj opreme Tehničnemu servisu");
        public static ltext lngt_ManufName_Person = new ltext("Personal administration equipment manufacturer", "Dobavitelj opreme uradom za vno osebnih podatkov");
        public static ltext lngt_ManufName_FC_Police = new ltext("Police equipment manufacturer", "Dobavitelj policijske opreme");
        #endregion

        public static ltext lngt_DBSettings = new ltext ( "DataBase Settings", "Nastavitve v bazi" );

    }
}
