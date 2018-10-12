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

namespace TangentaDataBaseDef
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext lng_t_CashierActivityOpened = new ltext(new string[] { "Cashier opening","Odprtje blagajne" });

        public static ltext lng_t_CashierActivityClosed = new ltext(new string[] { "Cashier closing", "Zaprtje blagajne" });

        public static ltext lng_t_CashierActivity_DocInvoice = new ltext(new string[] { "Casshier activity Invoice", "Aktivnost blagajne računi" });

        public static ltext lng_t_CashierActivity = new ltext(new string[] { "Casshier activity", "Aktivnost blagajne" });

        public static ltext lng_t_DocInvoice_ShopC_Item_AdditionalData = new ltext(new string[] { "DocInvoice ShopC Item Additional Data", "Artikel prodajalne C dodatni podatki na računu" });

        public static ltext lng_t_WorkArea_ParentGroup3 = new ltext(new string[] { "Work area group 3", "Delovno področje skupina 3" });

        public static ltext lng_t_WorkArea_ParentGroup2 = new ltext(new string[] { "Work area group 2", "Delovno področje skupina 2" });

        public static ltext lng_t_WorkArea_ParentGroup1 = new ltext(new string[] { "Work area group 1", "Delovno področje skupina 1" });

        public static ltext lng_t_Current_DocInvoice_ID = new ltext(new string[] { "Last User Invoice ID", "Uporabnikov zadnji račun ID" });

        public static ltext lng_t_Current_DocProformaInvoice_ID = new ltext(new string[] { "Last User Proforma-Invoice ID", "Uporabnikov zadnji predračun ID" });

        public static ltext lng_t_DocInvoice_ShopC_Item_AdditionalData_TYPE = new ltext(new string[] { "DocInvoice ShopC Item Additional Data", "Artikel prodajalne C vrsta dodatnega podatka na računu" });

        public static ltext lngt_DBm_Image_Name = new ltext(new string[] { "Image Name", "Ime posnetka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_Author = new ltext(new string[] { "Image Author", "Avtor posnetka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_CaptureLocation = new ltext(new string[] { "Capture Location", "Kraj posnetka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_FileName = new ltext(new string[] { "Image File Name", "Ime datoteke" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_Ext = new ltext(new string[] { "Image type (extension)", "Tip posnetka (Končnica)" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_Path = new ltext(new string[] { "Image path", "Izvorna pot posnetka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_Computer = new ltext(new string[] { "Computer source of Image", "Izvorni računalnik posnetka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Image_ComputerUser = new ltext(new string[] { "Computer user source of image ID", "Izvorni računalniški uporabnik posnetka ID" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_Name = new ltext(new string[] { "Document Name", "Ime dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_Author = new ltext(new string[] { "Document Author", "Avtor dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_FileName = new ltext(new string[] { "Document File Name", "Ime datoteke" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_Ext = new ltext(new string[] { "Document type (extension)", "Tip dokumenta (Končnica)" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_Path = new ltext(new string[] { "Document path", "Izvorna pot dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_Computer = new ltext(new string[] { "Computer source of Document", "Izvorni računalnik dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_DBm_Document_ComputerUser = new ltext(new string[] { "Computer user source of Document ID", "Izvorni računalniški uporabnik dokumenta ID" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.cs

        public static ltext lngt_t_Atom_Comment1 = new ltext(new string[] { "Comment 1 archive", "Komentar 1 arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Comment1 = new ltext(new string[] { "Comment 1", "Komentar 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_MethodOfPayment_DI = new ltext(new string[] { "Invoice method of payment", "Račun način plačila" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_MethodOfPayment_DPI = new ltext(new string[] { "Proforma Invoice method of payment", "Predračun način plačila" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_PaymentType = new ltext(new string[] { "Payment type", "Način plačila" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_StockTakeCostDescription = new ltext(new string[] { "Stock take cost description", "Prevzmenica opis stroška" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_StockTakeCostName = new ltext(new string[] { "Stock take cost name", "Prevzmenica ime stroška" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_StockTake_AdditionalCost = new ltext(new string[] { "Stock take additional cost", "Prevzmenica dodatni stroški" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Contact = new ltext(new string[] { "Contact", "Kontakt" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_StockTake = new ltext(new string[] { "Stock Take", "Prevzemnica" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_PurchasePrice = new ltext(new string[] { "Purchase Price", "Prevzemne cene" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Purchase_Order = new ltext(new string[] { "Purchase Order", "Naročilo Dobavitelju" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Trucking = new ltext(new string[] { "Trucking", "Transport" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_ElectronicDevice = new ltext(new string[] { "Electronic Device", "Elektronska naprava" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_LoginUsers_ParentGroup3 = new ltext(new string[] { "Users parent group 3", "Uporabniki skupina 3" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_LoginUsers_ParentGroup2 = new ltext(new string[] { "Users parent group 2", "Uporabniki skupina 2" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_LoginUsers_ParentGroup1 = new ltext(new string[] { "Users parent group 2", "Uporabniki skupina 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_ElectronicDevice = new ltext(new string[] { "Electronic Device archive", "Elektronska naprava arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_Bank = new ltext(new string[] { "Archive Bank", "Arhiv bank" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_BankAccount = new ltext(new string[] { "Archive Bank Account", "Arhiv bančnih računov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_OrganisationAccount = new ltext(new string[] { "Archive Organisation Account", "Arhiv bančnih računov organizacije" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_PersonData = new ltext(new string[] { "Archive Personal Data", "Arhiv osebnih podatkov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_PersonAccount = new ltext(new string[] { "Archive Person Bank Accounts", "Arhiv osebnih bančnih računov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_Name = new ltext(new string[] { "JOURNAL type name", "Ime vrste dogodka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_TableName = new ltext(new string[] { "JOURNAL Table Name", "Tabela dogodka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_TYPE = new ltext(new string[] { "JOURNAL type", "Vrsta dogodka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_myOrganisation_Person_TYPE = new ltext(new string[] { "myOrganisation Person event type", "Vrsta dogodka osebe moje organizacije" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_myOrganisation_Person_AccessRights_TYPE = new ltext(new string[] { "myOrganisation Person AccessRights event type", "Vrsta dogodka pravic osebe moje organizacije" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_FVI_SLO_SalesBookInvoice = new ltext(new string[] { "Sales Book Invoice", "Vezana knjiga računov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocInvoice_ShopA_Item = new ltext(new string[] { "Invoice ShopA Item ", "Artikli prodajalne A na računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocProformaInvoice_ShopA_Item = new ltext(new string[] { "Proforma invoice ShopA Item ", "Artikli prodajalne A na pred-računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_ItemShopA_Image = new ltext(new string[] { "Shopa A Item Image", "Prodajalna A Slika Artikla" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Notice = new ltext(new string[] { "Notice", "Dopis" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_Notice = new ltext(new string[] { "Notice Archive", "Dopis arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Atom_FVI_SLO_RealEstateBP = new ltext(new string[] { "FVI_SLO RealEstateBP", "Davčni podatki o poslovnem prostoru" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_FVI_SLO_Response = new ltext(new string[] { "FVI Response", "Overovljanje računov pri davčni upravi" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_FVI_SLO_RealEstateBP = new ltext(new string[] { "Business premises", "Davčni podatki o poslovnem prostoru" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_doc_page_type = new ltext(new string[] { "Document page type", "Oblika strani dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_Language = new ltext(new string[] { "Language", "Jezik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_JOURNAL_doc_Type = new ltext(new string[] { "Document journal type", "Vrsta dogodka dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_doc_type = new ltext(new string[] { "Document type", "Vrsta dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_WorkPeriod_Descrition = new ltext(new string[] { "Working shift description", "Vrsta šihta opis" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_WorkPeriod_TYPE = new ltext(new string[] { "Working shift type", "Vrsta šihta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Office_Data = new ltext(new string[] { "Office Data archive", "Poslovna enota podatki arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Office_Data = new ltext(new string[] { "Office Data", "Poslovna enota podatki" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Delivery_Type = new ltext(new string[] { "Journal Delivery types", "Dnevnik vrst dobave" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DeliveryType = new ltext(new string[] { "Delivery type", "Vrsta dobave" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_WorkPeriod = new ltext(new string[] { "Working shift", "Šiht" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_WorkArea = new ltext(new string[] { "Work area archive", "Področje dela arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Office = new ltext(new string[] { "Office archive", "Poslovna enota arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_WorkAreaImage = new ltext(new string[] { "Work area image archive", "Slika področja dela arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Computer = new ltext(new string[] { "Computer archive", "Računalnik arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Office = new ltext(new string[] { "Office", "Poslovna enota" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_PersonImage = new ltext(new string[] { "Person Image archive", "Slika osebe arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cEmail_Person = new ltext(new string[] { "Email archive", "e-pošta arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cGsmNumber_Person = new ltext(new string[] { "GSM Number archive", "GSM" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cPhoneNumber_Person = new ltext(new string[] { "Phone Number archive", "Telefon arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cCardType_Person = new ltext(new string[] { "Card Type archive", "Vrsta kartice arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cLastName = new ltext(new string[] { "Last Name archive", "Priimek arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cFirstName = new ltext(new string[] { "First Name archive", "ime arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Logo = new ltext(new string[] { "Organisation Logo archive", "Organizacija logotip arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Logo = new ltext(new string[] { "Organisation Logo", "Organizacija logotip" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_SimpleItem_ParentGroup1 = new ltext(new string[] { "SimpleItem Parent Group 1", "skupina" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_SimpleItem_ParentGroup2 = new ltext(new string[] { "SimpleItem Parent Group 2", "pod-skupina" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_SimpleItem_ParentGroup3 = new ltext(new string[] { "SimpleItem Parent Group 3", "pod-pod-skupina" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Customer_Person_Data_Image = new ltext(new string[] { "Journal customer person data image", "Dnevnik Kartoteka slike" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Customer_Person_Data = new ltext(new string[] { "Journal customer person data", "Dnevnik Kartoteka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Person = new ltext(new string[] { "Journal person", "Dnevnik fizične osebe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Stock_Type = new ltext(new string[] { "Journal event  Stock", "Dogodek skladišče" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Taxation_Type = new ltext(new string[] { "Journal event  Taxation", "Dogodek davki" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_StockTake_Type = new ltext(new string[] { "Journal event  stock take", "Dogodek prevzemnice" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Customer_Org_Type = new ltext(new string[] { "Journal event  customer organisation", "Dogodek stranke pravne osebe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Customer_Person_Type = new ltext(new string[] { "Journal event  customer person", "Dogodek stranke fizične osebe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_myOrganisation_Person_Type = new ltext(new string[] { "Journal event  employee", "Dogodek zaposleni" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_myOrganisation_Type = new ltext(new string[] { "Journal event  my company", "Dogodek moja organizacija" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_SimpleItem_Type = new ltext(new string[] { "Journal event  SimpleItem", "Dogodek storitve" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_Item_Type = new ltext(new string[] { "Journal event  item", "Dogodek artikli" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_DocInvoice_Type = new ltext(new string[] { "Journal event  DocInvoice", "Dogodek računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_DocProformaInvoice_Type = new ltext(new string[] { "Journal event  DocProformaInvoice", "Dogodek predračuna" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_JOURNAL_PriceList_Type = new ltext(new string[] { "Journal event  PriceList Account", "Dogodek cenik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_OrganisationAccount = new ltext(new string[] { "Organisation Account", "Račun organizacije" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_BankAccount = new ltext(new string[] { "Bank Account", "Bančni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Bank = new ltext(new string[] { "Bank", "Banka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_PersonAccount = new ltext(new string[] { "Person Account", "Osebni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_PersonData = new ltext(new string[] { "Person Data", "Osebni podatki" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Suplier = new ltext(new string[] { "Supplier", "Dobavitelj" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Customer_Org = new ltext(new string[] { "Customer Organisation", "Stranka organizacija" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Customer_Person = new ltext(new string[] { "Customer Person", "Stranka fizična oseba" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Customer_Org = new ltext(new string[] { "Customer Organisation archive", "Stranka organizacija arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Customer_Person = new ltext(new string[] { "Customer Perso archive", "Stranka fizična oseba arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_PersonImage = new ltext(new string[] { "Person Image", "Slika osebe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Reference_Image = new ltext(new string[] { "Reference document image", "Sklic slika dokumenta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_OrganisationData = new ltext(new string[] { "Organisation Data archive", "Podatki o organizaciji arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_OrganisationData = new ltext(new string[] { "Organisation Data", "Podatki o organizaciji" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_myOrganisation_Person_AccessRights = new ltext(new string[] { "My Organisation Person Access Rights", "Dostopne pravice osebe v podjetju" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_AccessRights = new ltext(new string[] { "Access Rights", "Dostopne pravice" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Units = new ltext(new string[] { "Measurement unit", "Merska enota" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_UnitsArchive = new ltext(new string[] { "Measurement unit archive", "Merska enota arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DocInvoice_ShopB_Item = new ltext(new string[] { "Invoice ShopB Item", "Artikli trgovine B na računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DocProformaInvoice_ShopB_Item = new ltext(new string[] { "Proforma Invoice ShopB Item", "Artikli trgovine B na pred-računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Price_Item = new ltext(new string[] { "Price Item archive", "Cena Artikel arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Currency = new ltext(new string[] { "Currency archive", "Valuta arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_PurchasePrice_Item = new ltext(new string[] { "Item purchase price", "Nabavne cene artiklov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_PriceList = new ltext(new string[] { "Price list", "Cenik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_ExchangeRateSource = new ltext(new string[] { "Exchange Rate Source", "Vir Menjalnega razmerja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_RateToBaseCurrency = new ltext(new string[] { "Exchange Rate to Base Currency", "Menjalno razmerje glede na osnovno valuto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_BaseCurrency = new ltext(new string[] { "Base Currency", "Osnovna Valuta" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Currency = new ltext(new string[] { "Currency", "Valute" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_PriceList = new ltext(new string[] { "Price list", "Cenik" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Price_Item = new ltext(new string[] { "Price list item", "Cenik artiklov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Price_SimpleItem = new ltext(new string[] { "Price list SimpleItem", "Cenik storitev" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cAddress_Org = new ltext(new string[] { "Address Organisation", "Naslovi organizacij" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cAddress_Person = new ltext(new string[] { "Address Person", "Naslovi oseb" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cAddress_Org = new ltext(new string[] { "Address Organisation", "Naslovi organizacij" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cAddress_Person = new ltext(new string[] { "Address Person", "Naslovi oseb" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cState_Org = new ltext(new string[] { "State", "Dežela" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cCountry_Org = new ltext(new string[] { "Country", "Država" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cZIP_Org = new ltext(new string[] { "ZIP", "Številka pošte" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cCity_Org = new ltext(new string[] { "City", "Kraj" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cHouseNumber_Org = new ltext(new string[] { "House number", "Hišna številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cStreetName_Org = new ltext(new string[] { "Street name", "Cesta prebivališča" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cState_Person = new ltext(new string[] { "State", "Dežela" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cCountry_Person = new ltext(new string[] { "Country", "Država" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cZIP_Person = new ltext(new string[] { "ZIP", "Številka pošte" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cCity_Person = new ltext(new string[] { "City", "Kraj" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cHouseNumber_Person = new ltext(new string[] { "House number", "Hišna številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_cStreetName_Person = new ltext(new string[] { "Street name", "Cesta prebivališča" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Stock_AddressLevel1 = new ltext(new string[] { "Stock Address Level 2", "Naslov skladišča 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Stock_AddressLevel2 = new ltext(new string[] { "Stock Address Level 2", "Naslov skladišča 2" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Stock_AddressLevel3 = new ltext(new string[] { "Stock Address Level 3", "Naslov skladišča 3" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Item_ParentGroup1 = new ltext(new string[] { "Item Parent Group 1", "Artikel skupina 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Item_ParentGroup2 = new ltext(new string[] { "Item Parent Group 2", "Artikel skupina 2" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Item_ParentGroup3 = new ltext(new string[] { "Item Parent Group 3", "Artikel skupina 3" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Expiry = new ltext(new string[] { "Expiry archive", "Rok uporabe arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Warranty = new ltext(new string[] { "Warranty arhiv", "Garancija arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Expiry = new ltext(new string[] { "Expiry", "Rok uporabe" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Warranty = new ltext(new string[] { "Warranty", "Garancija" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Item_Image = new ltext(new string[] { "Item Image", "Slika artikla" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_SimpleItem_Image = new ltext(new string[] { "SimpleItem Image", "Slika storitve" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_InvoiceItem = new ltext(new string[] { "Product Item", "Artikel" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_SimpleItem = new ltext(new string[] { "SimpleItem", "Storitev" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Stock = new ltext(new string[] { "Stock", "Zaloge" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Taxation = new ltext(new string[] { "Taxation", "Davki" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_ItemName = new ltext(new string[] { "Item Name", "Ime artikla" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Reference = new ltext(new string[] { "Reference", "Sklic" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_myOrganisation = new ltext(new string[] { "My Organisation", "Moja Firma" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Organisation = new ltext(new string[] { "Organisation", "Organizacija" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cOrgType = new ltext(new string[] { "Organisation Type", "Tip organizacije" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_BuyerPerson = new ltext(new string[] { "Person", "Fizična oseba" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Organisation = new ltext(new string[] { "Organisation archive", "Organizacija arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_BuyerAtom_Person = new ltext(new string[] { "Buyer Person arh", "Kupec oseba arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_myOrganisation_Person = new ltext(new string[] { "My Organisation Person arh", "Zaposleni arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocInvoice_ShopC_Item = new ltext(new string[] { "Proforma Invoice ShopC Item", "Artikli prodajalne C na računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocProformaInvoice_ShopC_Item = new ltext(new string[] { "Proforma Invoice ShopC Item", "Artikli prodajalne C na pred-računu" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocInvoice_ShopC_Item_Source = new ltext(new string[] { "ShopC Item Source", "Izvor artikla prodajalne C v košari" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_t_DocProformaInvoice_ShopC_Item_Source = new ltext(new string[] { "ShopC Item Source", "Izvor artikla prodajalne C v košari" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_myOrganisation_Person = new ltext(new string[] { "myCommpany_Person", "Oseba podjetja" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_TermsOfPayment = new ltext(new string[] { "TermsOfPayment", "Plačilni pogoji" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DocInvoiceAddOn = new ltext(new string[] { "Invoice addition", "Račun dodatek" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_ProformaInvoiceAddOn = new ltext(new string[] { "Proforma Invoice ", "Predračun dodatek" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DocInvoice_Image = new ltext(new string[] { "Invoice Image", "Slike računa" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_DocProformaInvoice = new ltext(new string[] { "Proforma Invoice", "Predračun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_SimpleItem_Image = new ltext(new string[] { "SimpleItem Image Archive", "Slika storitve arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Taxation = new ltext(new string[] { "Taxation Archive", "Obdavčitev storitve arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_SimpleItem_Name = new ltext(new string[] { "SimpleItem Name Archive", "Ime storitve arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Item_Description = new ltext(new string[] { "Atom_Item_Description", "Opis Artikla" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Item_barcode = new ltext(new string[] { "Item barcode Archive", "barkoda artikla arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Item_Name = new ltext(new string[] { "Atom_Item_Name", "Ime Artikla" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Item_ImageLib = new ltext(new string[] { "Item Image Lib Archive", "Knjižnica Slik Artiklov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_Item_Image = new ltext(new string[] { "Item Image Archive", "Slika Artikla Arhiv" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cCardType_Perosn = new ltext(new string[] { "Card Type", "Vrsta Kartice" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cFirstName = new ltext(new string[] { "First Name", "Ime" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cLastName = new ltext(new string[] { "Last Name", "Priimek" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cStreetName_Person = new ltext(new string[] { "StreetName", "Ime ulice" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cHouseNumber_Org = new ltext(new string[] { "House Number", "Hišna številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cHouseNumber_Person = new ltext(new string[] { "House Number", "Hišna številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cCity_Org = new ltext(new string[] { "City", "Mesto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cCity_Person = new ltext(new string[] { "City", "Mesto" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cCountry_Org = new ltext(new string[] { "Country", "Država" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cCountry_Person = new ltext(new string[] { "Country", "Država" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cState_Org = new ltext(new string[] { "State", "Dežela" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cState_Person = new ltext(new string[] { "State", "Dežela" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cPhoneNumber_Org = new ltext(new string[] { "Phone Number", "Tel. številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cPhoneNumber_Person = new ltext(new string[] { "Phone Number", "Tel. številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cGsmNumber_Person = new ltext(new string[] { "Gsm Number", "Gsm številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cFaxNumber_Org = new ltext(new string[] { "Fax Number", "Faks. številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cEmail_Org = new ltext(new string[] { "Email", "Elektronski naslov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cEmail_Person = new ltext(new string[] { "Email", "Elektronski naslov" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cHomePage_Org = new ltext(new string[] { "Home Page", "Domača stran" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cZIP_Org = new ltext(new string[] { "ZIP", "Poštna Številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_cZIP_Person = new ltext(new string[] { "ZIP", "Poštna Številka" });   // referenced in C:\Tangenta40\TANGENTA\TangentaDataBaseDef\MyDataBase.TableDefinitions.cs

        public static ltext lngt_Atom_myOrganisation = new ltext(new string[] { "My Organisation arh", "Moje podjetje arhiv" });

        public static ltext lngt_Delivery = new ltext(new string[] { "Delivery", "Dobava" });

        public static ltext lngt_JOURNAL_Customer_Org = new ltext(new string[] { "Journal customer organisation", "Dnevnik stranka pravna oseba" });

        public static ltext lngt_JOURNAL_Delivery = new ltext(new string[] { "Journal Delivery", "Dnevnik dobave" });

        public static ltext lngt_Invoice = new ltext(new string[] { "Invoice", "Račun" });

        public static ltext lngt_JOURNAL_Customer_Person = new ltext(new string[] { "Journal customer person", "Dnevnik stranka fizična oseba" });

        public static ltext lngt_JOURNAL_DocInvoice = new ltext(new string[] { "Journal Invoice", "Dnevnik Račun" });

        public static ltext lngt_JOURNAL_DocProformaInvoice = new ltext(new string[] { "Journal Proforma Invoice", "Dnevnik Predračun" });

        public static ltext lngt_JOURNAL_PriceList = new ltext(new string[] { "Journal PriceList", "Dnevnik Cenik" });

        public static ltext lngt_JOURNAL_Item = new ltext(new string[] { "Journal Item", "Dnevnik Artikel" });

        public static ltext lngt_JOURNAL_myOrganisation = new ltext(new string[] { "Journal myOrganisation", "Dnevnik moja organizacija" });

        public static ltext lngt_JOURNAL_Stock = new ltext(new string[] { "Journal stock", "Dnevnik skladišče" });

        public static ltext lngt_JOURNAL_Taxation = new ltext(new string[] { "Journal taxation", "Dnevnik davki" });

        public static ltext lngt_JOURNAL_StockTake = new ltext(new string[] { "Journal stoke take", "Dnevnik prevzemnice" });

        public static ltext lngt_JOURNAL_SimpleItem = new ltext(new string[] { "Journal SimpleItem", "Dnevnik SimpleItem" });

        public static ltext lngt_t_Atom_ItemShopA = new ltext(new string[] { "Shopa A Item", "Prodajalna A Artikli" });

        public static ltext lngt_t_doc = new ltext(new string[] { "Document", "Dokument" });

        public static ltext lngt_t_JOURNAL = new ltext(new string[] { "JOURNAL", "Dnevnik dogodkov" });

        public static ltext lngt_t_JOURNAL_doc = new ltext(new string[] { "Document journal", "Dnevnik dokumenta" });

        public static ltext lngt_t_JOURNAL_myOrganisation_Person = new ltext(new string[] { "myOrganisation Person event", "Dogodek osebe moje organizacije" });

        public static ltext lngt_t_JOURNAL_myOrganisation_Person_AccessRights = new ltext(new string[] { "myOrganisation Person AccessRights event", "Dogodek pravic osebe moje organizacije" });

        public static ltext lngt_t_LoginUsers = new ltext(new string[] { "Users", "Uporabniki" });

        public static ltext lngt_t_LoginRoles = new ltext(new string[] { "User rights", "Pravice uporabnikov" });

        public static ltext lngt_t_LoginUsersAndLoginRoles = new ltext(new string[] { "Users and Access rights", "Uporabniki in pravice dostopa" });

        public static ltext lngt_t_LoginSession = new ltext(new string[] { "Login session", "Dnevnik prijav" });

        public static ltext lngt_t_LoginFailed = new ltext(new string[] { "Login failed", "Neuspešne prijave" });

        public static ltext lngt_t_LoginManagerEvent = new ltext(new string[] { "Login Manager Event", "Dogodek urejanja uporabnikov" });

        public static ltext lngt_t_LoginManagerJournal = new ltext(new string[] { "Login Manager Event JOURNAL", "Dnevnik dogodkov urejanja uporabnikov" });

        public static ltext lngt_t_Atom_PriceList_Name = new ltext(new string[] { "Price List Name archive", "Ime cenika arhiv" });

        public static ltext lngt_t_PriceList_Name = new ltext(new string[] { "Price List Name", "Ime cenika" });

        public static ltext lngt_t_Atom_ComputerName = new ltext(new string[] { "Computer Name", "Ime računalnika" });

        public static ltext lngt_t_Atom_ComputerUserName = new ltext(new string[] { "Computer login username", "Uporabniško ime za prijavo v računalnik" });

        public static ltext lngt_t_Atom_MAC_address = new ltext(new string[] { "Computer ethernet MAC address", "MAC naslov" });

        public static ltext lngt_t_CaseItem = new ltext(new string[] { "Case", "Zadeva" });

        public static ltext lngt_t_CaseImage = new ltext(new string[] { "Case image", "Zadeva slika" });

        public static ltext lngt_t_CustomerCase = new ltext(new string[] { "Customer Case", "Stranke zadeva" });

        public static ltext lngt_t_CaseParameter = new ltext(new string[] { "Case parameter", "Parameter zadeve" });

        public static ltext lngt_t_SettingsType = new ltext(new string[] { "Settings type", "Podatkovni tip nastavitve" });

        public static ltext lngt_t_SettingsValue = new ltext(new string[] { "Settings value", "Vrednost nastavitve" });

        public static ltext lngt_t_ProgramModule = new ltext(new string[] { "Program module", "Programski modul" });

        public static ltext lngt_t_PropertiesSettings = new ltext(new string[] { "Properties Settings", "Programske nastavitve" });

        public static ltext lngt_t_LoginTag_TYPE = new ltext(new string[] { "Login Tag", "Vrsta prijave" });

        public static ltext lngt_t_LoginTag = new ltext(new string[] { "Login Tag", "Prijavni označevalec" });

        public static ltext lngt_t_WorkAreaImage = new ltext(new string[] { "Work Area Image", "Slika delovnega področja" });

        public static ltext lngt_t_WorkArea = new ltext(new string[] { "Work Area", "Delovno področje" });

        public static ltext lngt_t_DocInvoice_Atom_WorkArea = new ltext(new string[] { "Invoice Work Area", "Delovno področje na računu" });

        public static ltext lngt_t_Atom_IP_address = new ltext(new string[] { "IP Address", "IP naslovi" });

        public static ltext lngt_t_myOrganisation_Person_SingleUser = new ltext(new string[] { "My organisation person single user", "Edini uporabnik v moji oragniazciji" });

        public static ltext lngt_t_TermsOfPayment_Default = new ltext(new string[] { "Deafult terms of payment", "Privzeti plačilni pogoji" });

        public static ltext lng_t_JOURNAL_Atom_WorkPeriod = new ltext(new string[] { "Journal Atom Work Period", "Dnevnik šihtov" });

        public static ltext lng_t_JOURNAL_Atom_WorkPeriod_TYPE = new ltext(new string[] { "Journal Atom Work Period Type", "Vrsta dogodka v dnevniku šihtov" });

    }
}
