
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DBConnectionControl40;
using TangentaTableClass;
using CodeTables;
using LanguageControl;
using DBConnectionControl40;

namespace TangentaDataBaseDef
{
    public class Settings_Item
    {
        private string m_Name;

        public string Name
        {
            get {return m_Name;}
        }


        public string TextValue;
        public bool ReadOnly;
        public Settings_Item(string xName,string xTextValue, bool xReadOnly)
        {
            m_Name = xName;
            TextValue = xTextValue;
            ReadOnly = xReadOnly;
        }
    }

    public class Settings
    {
        public Settings_Item Version=null;
        public Settings_Item StockCheckAtStartup = null;
        public Settings_Item AdminPassword = null;
        public Settings_Item MultiUserOperation = null;
        public Settings_Item SingleUserLoginAsAdministrator = null;
        public Settings_Item ShopC_ExclusivelySellFromStock = null;
        public Settings_Item MultiCurrencyOperation = null;
        public Settings_Item NumberOfMonthAfterNewYearToAllowCreateNewInvoice = null;
        public Settings_Item FiscalVerificationOfInvoices = null;

        public Settings(string Ver)
        {
            Version = new Settings_Item("Version",Ver,true);
            StockCheckAtStartup = new Settings_Item("StockCheckAtStartup", "1", false);
            AdminPassword = new Settings_Item("AdminPassword", "12345", false);
            MultiUserOperation = new Settings_Item("MultiUserOperation", "1", false);
            SingleUserLoginAsAdministrator = new Settings_Item("SingleUserLoginAsAdministrator", "0", false);
            ShopC_ExclusivelySellFromStock = new Settings_Item("ShopC_ExclusivelySellFromStock", "0", false);
            MultiCurrencyOperation = new Settings_Item("MultCurrencyOperation", "0", false);
            NumberOfMonthAfterNewYearToAllowCreateNewInvoice = new Settings_Item("NumberOfMonthAfterNewYearToAllowCreateNewInvoice", "1", false);
            FiscalVerificationOfInvoices = new Settings_Item("FiscalVerificationOfInvoices", "1", false);
        }

    }
    partial class MyDataBase_Tangenta
    {
        public const string VERSION = "1.25";
        public Settings Settings = null;

        /* 1 */
        public SQLTable t_cFirstName = null;
        /* 2 */
        public SQLTable t_cLastName = null;
        /* 3 */
        public SQLTable t_cPhoneNumber_Person = null;
        /* 4 */
        public SQLTable t_cGsmNumber_Person = null;
        /* 5 */
        public SQLTable t_cEmail_Person = null;
        /* 6 */
        public SQLTable t_cZIP_Person = null;
        /* 7 */
        public SQLTable t_cStreetName_Person = null;
        /* 8 */
        public SQLTable t_cHouseNumber_Person = null;
        /* 9 */
        public SQLTable t_cCity_Person = null;
        /* 10 */
        public SQLTable t_cCountry_Person = null;
        /* 11 */
        public SQLTable t_cState_Person = null;
        /* 12 */
        public SQLTable t_Person = null;
        /* 13 */
        public SQLTable t_cOrgTYPE = null;
        /* 14 */
        public SQLTable t_cStreetName_Org = null;
        /* 15 */
        public SQLTable t_cHouseNumber_Org = null;
        /* 16 */
        public SQLTable t_cCity_Org = null;
        /* 17 */
        public SQLTable t_cCountry_Org = null;
        /* 18 */
        public SQLTable t_cState_Org = null;
        /* 19 */
        public SQLTable t_cZIP_Org = null;
        /* 20 */
        public SQLTable t_cPhoneNumber_Org = null;
        /* 21 */
        public SQLTable t_cFaxNumber_Org = null;
        /* 22 */
        public SQLTable t_cEmail_Org = null;
        /* 23 */
        public SQLTable t_cHomePage_Org = null;
        /* 24 */
        public SQLTable t_Organisation = null;
        /* 25 */
        public SQLTable t_myOrganisation = null;
        /* 26 */
        public SQLTable t_Reference = null;
        /* 27 */
        public SQLTable t_Item = null;
        /* 28 */
        public SQLTable t_Taxation = null;
        /* 29 */
        public SQLTable t_Stock = null;
        /* 30 */
        public SQLTable t_SimpleItem = null;
        /* 31 */
        public SQLTable t_MethodOfPayment_DI = null;
        /* 32 */
        public SQLTable t_JOURNAL_DocProformaInvoice_Type = null;
        /* 33 */
        public SQLTable t_Atom_Item = null;
        /* 34 */
        public SQLTable t_Atom_SimpleItem = null;
        /* 35 */
        public SQLTable t_cCardType_Person = null;
        /* 36 */
        public SQLTable t_DBSettings = null;
        /* 37 */
        public SQLTable t_Atom_Item_Image = null;
        /* 38 */
        public SQLTable t_Atom_Item_ImageLib = null;
        /* 39 */
        public SQLTable t_Atom_Item_Name = null;
        /* 40 */
        public SQLTable t_Atom_Item_barcode = null;
        /* 41 */
        public SQLTable t_Atom_Item_Description = null;
        /* 42 */
        public SQLTable t_Atom_SimpleItem_Name = null;
        /* 43 */
        public SQLTable t_Atom_Taxation = null;
        /* 43 */
        public SQLTable t_Atom_SimpleItem_Image = null;
        /* 45 */
        public SQLTable t_DocInvoice = null;
        /* 46 */
        public SQLTable t_Doc_ImageLib = null;
        /* 47 */
        public SQLTable t_DocInvoiceAddOn = null;
        /* 48 */
        public SQLTable t_TermsOfPayment = null;
        /* 49 */
        public SQLTable t_myOrganisation_Person = null;
        /* 50 */
        public SQLTable t_DocInvoice_ShopC_Item = null;
        /* 51 */
        public SQLTable t_Atom_myOrganisation_Person = null;
        /* 52 */
        public SQLTable t_Atom_myOrganisation = null;
        /* 53 */
        public SQLTable t_Atom_Person = null;
        /* 54 */
        public SQLTable t_Atom_Organisation = null;
        /* 55 */
        public SQLTable t_SimpleItem_Image = null;
        /* 56 */
        public SQLTable t_Item_Image = null;
        /* 57 */
        public SQLTable t_Expiry = null;
        /* 58 */
        public SQLTable t_Warranty = null;
        /* 59 */
        public SQLTable t_Atom_Expiry = null;
        /* 60 */
        public SQLTable t_Atom_Warranty = null;
        /* 61 */
        public SQLTable t_Item_ParentGroup3 = null;
        /* 62 */
        public SQLTable t_Item_ParentGroup2 = null;
        /* 63 */
        public SQLTable t_Item_ParentGroup1 = null;
        /* 64 */
        public SQLTable t_Stock_AddressLevel3 = null;
        /* 65 */
        public SQLTable t_Stock_AddressLevel2 = null;
        /* 66 */
        public SQLTable t_Stock_AddressLevel1 = null;
        /* 67 */
        public SQLTable t_Atom_cStreetName_Person = null;
        /* 68 */
        public SQLTable t_Atom_cHouseNumber_Person = null;

        /* 69 */
        public SQLTable t_Atom_cCity_Person = null;

        /* 70 */
        public SQLTable t_Atom_cZIP_Person = null;

        /* 71 */
        public SQLTable t_Atom_cCountry_Person = null;

        /* 72 */
        public SQLTable t_Atom_cState_Person = null;

        /* 73 */
        public SQLTable t_Atom_cStreetName_Org = null;

        /* 74 */
        public SQLTable t_Atom_cHouseNumber_Org = null;

        /* 75 */
        public SQLTable t_Atom_cCity_Org  = null;

        /* 76 */
        public SQLTable t_Atom_cZIP_Org  = null;

        /* 77 */
        public SQLTable t_Atom_cCountry_Org = null;

        /* 78 */
        public SQLTable t_Atom_cState_Org = null;

        /* 79 */
        public SQLTable t_cAddress_Person = null;

        /* 80 */
        public SQLTable t_cAddress_Org = null;

        /* 81 */
        public SQLTable t_Atom_cAddress_Person = null;

        /* 82 */
        public SQLTable t_Atom_cAddress_Org = null;

        /* 83 */
        public SQLTable t_Price_Item = null;

        /* 84 */
        public SQLTable t_Price_SimpleItem = null;

        /* 85 */
        public SQLTable t_PriceList = null;

        /* 86 */
        public SQLTable t_Currency = null;

        /* 87 */
        public SQLTable t_BaseCurrency = null;

        /* 88 */
        public SQLTable t_RateToBaseCurrency = null;

        /* 89 */
        public SQLTable t_ExchangeRateSource = null;

        /* 90 */
        public SQLTable t_Atom_PriceList = null;

        /* 91 */
        public SQLTable t_PurchasePrice_Item = null;

        /* 92 */
        public SQLTable t_Atom_Currency = null;

        /* 93 */
        public SQLTable t_Atom_Price_Item = null;

        /* 94 */
        public SQLTable t_DocInvoice_ShopB_Item = null;

        /* 95 */
        public SQLTable t_PersonImage = null;

        /* 96 */
        public SQLTable t_Unit = null;

        /* 97 */
        public SQLTable t_Atom_Unit = null;

        /* 98 */
        public SQLTable t_OrganisationData = null;

        /* 99 */
        public SQLTable t_PurchasePrice = null;

        /* 100 */
        public SQLTable t_Reference_Image = null;

        /* 101 */
        public SQLTable t_Atom_OrganisationData = null;

        /* 102 */
        public SQLTable t_Supplier = null;

        /* 103 */
        public SQLTable t_Customer_Org = null;

        /* 104 */
        public SQLTable t_Customer_Person = null;

        /* 105 */
        public SQLTable t_Atom_Customer_Org = null;

        /* 106 */
        public SQLTable t_Atom_Customer_Person = null;

        /* 107 */
        public SQLTable t_PersonData = null;

        /* 108 */
        public SQLTable t_PersonAccount = null;

        /* 109 */
        public SQLTable t_Bank = null;

        /* 110 */
        public SQLTable t_BankAccount = null;

        /* 111 */
        public SQLTable t_OrganisationAccount = null;

        /* 112 */
        public SQLTable t_JOURNAL_PriceList_Type = null; 

        /* 113 */
        public SQLTable t_JOURNAL_DocInvoice_Type = null;

        /* 114 */
        public SQLTable t_JOURNAL_Item_Type = null;

        /* 115 */
        public SQLTable t_JOURNAL_SimpleItem_Type = null;

        /* 116 */
        public SQLTable t_JOURNAL_myOrganisation_Type = null;

        /* 117 */
        public SQLTable t_JOURNAL_myOrganisation_Person_Type = null;

        /* 118 */
        public SQLTable t_JOURNAL_Customer_Person_Type = null;

        /* 119 */
        public SQLTable t_JOURNAL_Customer_Org_Type = null;

        /* 120 */
        public SQLTable t_JOURNAL_StockTake_Type = null;

        /* 121 */
        public SQLTable t_JOURNAL_Taxation_Type = null;

        /* 122 */
        public SQLTable t_JOURNAL_Stock_Type = null;

        /* 123 */
        public SQLTable t_JOURNAL_DocInvoice = null;

        /* 124 */
        public SQLTable t_JOURNAL_DocProformaInvoice = null;

        /* 125 */
        public SQLTable t_JOURNAL_Item = null;

        /* 126 */
        public SQLTable t_JOURNAL_SimpleItem = null;

        /* 127 */
        public SQLTable t_JOURNAL_PriceList = null;

        /* 128 */
        public SQLTable t_JOURNAL_myOrganisation = null;

        /* 129 */
        public SQLTable t_JOURNAL_Person = null;

        /* 130 */
        public SQLTable t_JOURNAL_Customer_Person = null;

        /* 131 */
        public SQLTable t_JOURNAL_Customer_Person_Data = null;

        /* 132 */
        public SQLTable t_JOURNAL_Customer_Person_Data_Image = null;

        /* 133 */
        public SQLTable t_JOURNAL_Customer_Org = null;

        /* 134 */
        public SQLTable t_JOURNAL_StockTake = null;

        /* 135 */
        public SQLTable t_JOURNAL_Taxation = null;

        /* 136 */
        public SQLTable t_JOURNAL_Stock = null;

        /* 137 */
        public SQLTable t_SimpleItem_ParentGroup3 = null;

        /* 138 */
        public SQLTable t_SimpleItem_ParentGroup2 = null;

        /* 139 */
        public SQLTable t_SimpleItem_ParentGroup1 = null;

        /* 140 */
        public SQLTable t_Logo = null;

        /* 141 */
        public SQLTable t_Atom_Logo = null;

        /* 142 */
        public SQLTable t_Atom_cFirstName = null;
                        
        /* 143 */       
        public SQLTable t_Atom_cLastName = null;
                        
        /* 144 */       
        public SQLTable t_Atom_cCardType_Person = null;
                        
        /* 145 */       
        public SQLTable t_Atom_cPhoneNumber_Person = null;
                        
        /* 146 */       
        public SQLTable t_Atom_cGsmNumber_Person = null;
                        
        /* 147 */       
        public SQLTable t_Atom_cEmail_Person = null;
                        
        /* 148 */       
        public SQLTable t_Atom_PersonImage = null;

        /* 149 */
        public SQLTable t_Office = null;

        /* 150 */
        public SQLTable t_Atom_Computer = null;

        /* 151 */
        public SQLTable t_WorkingPlace = null;

        /* 152 */
        public SQLTable t_Atom_Office = null;

        /* 153 */
        public SQLTable t_Atom_WorkingPlace = null;

        /* 154 */
        public SQLTable t_Atom_WorkPeriod = null;

        /* 155 */
        public SQLTable t_DeliveryType = null;

        /* 156 */
        public SQLTable t_Delivery = null;

        /* 157 */
        public SQLTable t_JOURNAL_Delivery_Type = null;

        /* 158 */
        public SQLTable t_JOURNAL_Delivery = null;

        /* 159 */
        public SQLTable t_Office_Data = null;

        /* 160 */
        public SQLTable t_Atom_Office_Data = null;

        /* 161 */
        public SQLTable t_Atom_WorkPeriod_TYPE = null;

        /* 162 */
        public SQLTable t_Atom_WorkPeriod_Descrition = null;

        /* 163 */
        public SQLTable t_doc_type = null;

        /* 164 */
        public SQLTable t_doc = null;

        /* 165 */
        public SQLTable t_JOURNAL_doc_Type = null;

        /* 166 */
        public SQLTable t_JOURNAL_doc = null;

        /* 167 */
        public SQLTable t_Language = null;

        /* 168 */
        public SQLTable t_doc_page_type = null;

        /* 169 */
        public SQLTable t_FVI_SLO_RealEstateBP = null;

        /* 170 */
        public SQLTable t_FVI_SLO_Response = null;

        /* 171 */
        public SQLTable t_Atom_FVI_SLO_RealEstateBP = null;

        /* 172 */
        public SQLTable t_Notice = null;

        /* 173 */
        public SQLTable t_Atom_ItemShopA_Image = null;

        /* 174 */
        public SQLTable t_Atom_ItemShopA = null;

        /* 175 */
        public SQLTable t_DocInvoice_ShopA_Item = null;

        /* 176 */
        public SQLTable t_FVI_SLO_SalesBookInvoice = null;

        /* 177 */
        public SQLTable t_DocProformaInvoice = null;

        /* 178 */
        public SQLTable t_DocProformaInvoice_ShopC_Item = null;

        /* 179 */
        public SQLTable t_DocProformaInvoice_ShopB_Item = null;

        /* 180 */
        public SQLTable t_DocProformaInvoiceAddOn = null;

        /* 181 */
        public SQLTable t_DocProformaInvoice_ShopA_Item = null;

        /* 182 */
        public SQLTable t_JOURNAL_myOrganisation_Person_TYPE = null;

        /* 183 */
        public SQLTable t_JOURNAL_myOrganisation_Person = null;

        /* 184 */
        public SQLTable t_Atom_Bank = null;
                        
        /* 185 */       
        public SQLTable t_Atom_BankAccount = null;
                        
        /* 186 */       
        public SQLTable t_Atom_OrganisationAccount = null;

        /* 187 */       
        public SQLTable t_Atom_PersonData = null;

        /* 188 */
        public SQLTable t_Atom_PersonAccount = null;

        /* 189 */
        public SQLTable t_JOURNAL_Name = null;

        /* 190 */
        public SQLTable t_JOURNAL_TableName = null;

        /* 191 */
        public SQLTable t_JOURNAL_TYPE = null;

        /* 192 */
        public SQLTable t_JOURNAL = null;

        /* 193 */
        public SQLTable t_Atom_ElectronicDevice = null;

        /* 194 */
        public SQLTable t_Trucking = null;

        /* 195 */
        public SQLTable t_Purchase_Order = null;

        /* 196 */
        public SQLTable t_StockTake = null;

        /* 197 */
        public SQLTable t_Contact = null;

        /* 198 */
        public SQLTable t_StockTake_AdditionalCost = null;

        /* 199 */
        public SQLTable t_StockTakeCostName = null;

        /* 200 */
        public SQLTable t_StockTakeCostDescription = null;

        /* 201 */
        public SQLTable t_PaymentType = null;

        /* 202 */
        public SQLTable t_MethodOfPayment_DPI = null;

        /* 203 */
        public SQLTable t_Atom_Notice = null;

        /* 204 */
        public SQLTable t_Comment1 = null;

        /* 205 */
        public SQLTable t_Atom_Comment1 = null;

        /* 206 */
        public SQLTable t_LoginUsers = null;

        /* 207 */
        public SQLTable t_LoginRoles = null;

        /* 208 */
        public SQLTable t_LoginUsersAndLoginRoles = null;

        /* 209 */
        public SQLTable t_LoginSession = null;

        /* 210 */
        public SQLTable t_LoginFailed = null;

        /* 211 */
        public SQLTable t_LoginManagerEvent = null;

        /* 212 */
        public SQLTable t_LoginManagerJournal = null;

        /* 213 */
        public SQLTable t_Atom_PriceList_Name =null;

        /* 214 */
        public SQLTable t_PriceList_Name = null;

        /* 215 */
        public SQLTable t_Atom_ComputerName = null;

        /* 216 */
        public SQLTable t_Atom_ComputerUserName = null;

        /* 217 */
        public SQLTable t_Atom_MAC_address = null;

        /* 218 */
        public SQLTable t_CaseItem = null;

        /* 219 */
        public SQLTable t_CaseImage = null;

        /* 220 */
        public SQLTable t_CustomerCase = null;

        /* 221 */
        public SQLTable t_CaseParameter = null;

        /* 222 */
        public SQLTable t_SettingsType = null;

        /* 223 */
        public SQLTable t_SettingsValue = null;

        /* 224 */
        public SQLTable t_ProgramModule = null;

        /* 225 */
        public SQLTable t_PropertiesSettings = null;

        /* 226 */
        public SQLTable t_LoginTag_TYPE = null;

        /* 227 */
        public SQLTable t_LoginTag = null;

        /* 228 */
        public SQLTable t_WorkAreaImage = null;

        /* 229 */
        public SQLTable t_WorkArea = null;

        /* 230 */
        public SQLTable t_WorkAreaDocInvoice = null;

        /* 231 */
        public SQLTable t_Atom_IP_address = null;

        public void Define_SQL_Database_Tables() // constructor;
        {
            Settings = new Settings(VERSION);
            m_DBTables.items.Clear();
            TableNames.list.Clear();
            /* 1 */
            t_cFirstName = new SQLTable((Object)new cFirstName(),"cfn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cFirstName);
            t_cFirstName.AddColumn((Object)mt.m_cFirstName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cFirstName.AddColumn((Object)mt.m_cFirstName.FirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "First Name", "Ime") );
            m_DBTables.items.Add(t_cFirstName);

            /* 2 */
            t_cLastName = new SQLTable((Object)new cLastName(),"cln", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cLastName);
            t_cLastName.AddColumn((Object)mt.m_cLastName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cLastName.AddColumn((Object)mt.m_cLastName.LastName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Last Name", "Priimek") );
            m_DBTables.items.Add(t_cLastName);

            /* 3 */
            t_cPhoneNumber_Person = new SQLTable((Object)new cPhoneNumber_Person(),"cphnnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cPhoneNumber_Person);
            t_cPhoneNumber_Person.AddColumn((Object)mt.m_cPhoneNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cPhoneNumber_Person.AddColumn((Object)mt.m_cPhoneNumber_Person.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Phone Number", "Številka telefona") );
            m_DBTables.items.Add(t_cPhoneNumber_Person);

            /* 4 */
            t_cGsmNumber_Person = new SQLTable((Object)new cGsmNumber_Person(),"cgsmnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cGsmNumber_Person);
            t_cGsmNumber_Person.AddColumn((Object)mt.m_cGsmNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cGsmNumber_Person.AddColumn((Object)mt.m_cGsmNumber_Person.GsmNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "GSM:", "GSM:") );
            m_DBTables.items.Add(t_cGsmNumber_Person);

            /* 5 */
            t_cEmail_Person = new SQLTable((Object)new cEmail_Person(),"cemailper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cEmail_Person);
            t_cEmail_Person.AddColumn((Object)mt.m_cEmail_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cEmail_Person.AddColumn((Object)mt.m_cEmail_Person.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Email", "Elektronski naslov (Email)") );
            m_DBTables.items.Add(t_cEmail_Person);

            /* 6 */
            t_cZIP_Person = new SQLTable((Object)new cZIP_Person(),"zipper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cZIP_Person);
            t_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_cZIP_Person);

            /* 7 */
            t_cStreetName_Person = new SQLTable((Object)new cStreetName_Person(),"cstrnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cStreetName_Person);
            t_cStreetName_Person.AddColumn((Object)mt.m_cStreetName_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cStreetName_Person.AddColumn((Object)mt.m_cStreetName_Person.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Street Name", "Ime ceste/ulice") );
            m_DBTables.items.Add(t_cStreetName_Person);

            /* 8 */
            t_cHouseNumber_Person = new SQLTable((Object)new cHouseNumber_Person(),"chounper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cHouseNumber_Person);
            t_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_cHouseNumber_Person);

            /* 9 */
            t_cCity_Person = new SQLTable((Object)new cCity_Person(),"ccitper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCity_Person);
        
            t_cCity_Person.AddColumn((Object)mt.m_cCity_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCity_Person.AddColumn((Object)mt.m_cCity_Person.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "City", "Mesto") );
            m_DBTables.items.Add(t_cCity_Person);

            /* 10 */
            t_cCountry_Person = new SQLTable((Object)new cCountry_Person(),"cstper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCountry_Person);
            t_cCountry_Person.SetInputControls = m_ISO_3166_Table.SetInputControls;
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Country", "Država") );
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.Country_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a2", "ISO_3166 a2"));
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.Country_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.Country_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_cCountry_Person);

            /* 11 */
            t_cState_Person = new SQLTable((Object)new cState_Person(),"ccouper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cState_Person);
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "State", "Dežela") );
            m_DBTables.items.Add(t_cState_Person);

            /* 12 */
            t_Person = new SQLTable((Object)new Person(),"per", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_BuyerPerson);
            t_Person.AddColumn((Object)mt.m_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Person.AddColumn((Object)mt.m_Person.Gender, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.RadioButtons, new ltext( "Gender:Female/Male", "Spol:Ženska/Moški") );
            t_Person.AddColumn((Object)mt.m_Person.m_cFirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "First Name ID", "Ime ID") );
            t_Person.AddColumn((Object)mt.m_Person.m_cLastName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Last Name ID", "Priimek ID") );
            t_Person.AddColumn((Object)mt.m_Person.DateOfBirth, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Date of Birth", "Datum Rojstva") );
            t_Person.AddColumn((Object)mt.m_Person.Tax_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax number", "Davčna številka") );
            t_Person.AddColumn((Object)mt.m_Person.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Registration number", "Matična številka") );
            m_DBTables.items.Add(t_Person);

            /* 13 */
            t_cOrgTYPE = new SQLTable((Object)new cOrgTYPE(),"orgt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cOrgType);
            t_cOrgTYPE.AddColumn((Object)mt.m_cOrgTYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cOrgTYPE.AddColumn((Object)mt.m_cOrgTYPE.OrganisationTYPE, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Organisation Type", "Vrsta organizacije") );
            m_DBTables.items.Add(t_cOrgTYPE);


            /* 14 */
            t_cStreetName_Org = new SQLTable((Object)new cStreetName_Org(),"cstrnorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cOrgType);
            t_cStreetName_Org.AddColumn((Object)mt.m_cStreetName_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cStreetName_Org.AddColumn((Object)mt.m_cStreetName_Org.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street Name", "Ime ulice") );
            m_DBTables.items.Add(t_cStreetName_Org);

            /* 15 */
            t_cHouseNumber_Org = new SQLTable((Object)new cHouseNumber_Org(),"chounorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cHouseNumber_Org);
            t_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna Številka") );
            m_DBTables.items.Add(t_cHouseNumber_Org);


            /* 16 */
            t_cCity_Org = new SQLTable((Object)new cCity_Org(),"ccitorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCity_Org);
            t_cCity_Org.AddColumn((Object)mt.m_cCity_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCity_Org.AddColumn((Object)mt.m_cCity_Org.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "City", "Mesto") );
            m_DBTables.items.Add(t_cCity_Org);

            /* 17 */
            t_cCountry_Org = new SQLTable((Object)new cCountry_Org(), "ccouorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCountry_Org);
            t_cCountry_Org.SetInputControls = m_ISO_3166_Table.SetInputControls;
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Country", "Država") );
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.Country_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a2", "ISO_3166 a2"));
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.Country_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.Country_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_cCountry_Org);

            /* 18 */
            t_cState_Org = new SQLTable((Object)new cState_Org(), "cstorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cState_Org);
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "State", "Dežela") );
            m_DBTables.items.Add(t_cState_Org);

            /* 19 */
            t_cZIP_Org = new SQLTable((Object)new cZIP_Org(),"cziporg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cZIP_Org);
            t_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Št. Pošte") );
            m_DBTables.items.Add(t_cZIP_Org);

            /* 20 */
            t_cPhoneNumber_Org = new SQLTable((Object)new cPhoneNumber_Org(),"cphnnorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cPhoneNumber_Org);
            t_cPhoneNumber_Org.AddColumn((Object)mt.m_cPhoneNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cPhoneNumber_Org.AddColumn((Object)mt.m_cPhoneNumber_Org.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Phone Number", "Številka telefona") );
            m_DBTables.items.Add(t_cPhoneNumber_Org);

            /* 21 */
            t_cFaxNumber_Org = new SQLTable((Object)new cFaxNumber_Org(),"cfaxnorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cFaxNumber_Org);
            t_cFaxNumber_Org.AddColumn((Object)mt.m_cFaxNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cFaxNumber_Org.AddColumn((Object)mt.m_cFaxNumber_Org.FaxNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Fax Number", "Številka Faksa") );
            m_DBTables.items.Add(t_cFaxNumber_Org);

            /* 22 */
            t_cEmail_Org = new SQLTable((Object)new cEmail_Org(),"cemailorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cEmail_Org);
            t_cEmail_Org.AddColumn((Object)mt.m_cEmail_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cEmail_Org.AddColumn((Object)mt.m_cEmail_Org.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Email", "Elektronski naslov (Email)") );
            m_DBTables.items.Add(t_cEmail_Org);

            /* 23 */
            t_cHomePage_Org = new SQLTable((Object)new cHomePage_Org(),"chomepgorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cHomePage_Org);
            t_cHomePage_Org.AddColumn((Object)mt.m_cHomePage_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHomePage_Org.AddColumn((Object)mt.m_cHomePage_Org.HomePage, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "HomePage", "Domača stran") );
            m_DBTables.items.Add(t_cHomePage_Org);


            /* 24 */
            t_Organisation = new SQLTable((Object)new Organisation(),"org", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Organisation);
            t_Organisation.AddColumn((Object)mt.m_Organisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation name", "Ime Firme") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Tax_ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "TAX ID", "Davčna številka") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "REGISTRATION ID", "Matična številka") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.TaxPayer, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext("VAT payer", "Zavezanec za DDV"));
            t_Organisation.AddColumn((Object)mt.m_Organisation.m_Comment1, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Comment 1 ID", "Komentar 1 ID"));
            m_DBTables.items.Add(t_Organisation);

            /* 25 */
            t_myOrganisation = new SQLTable((Object)new myOrganisation(),"mo", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_myOrganisation);
            t_myOrganisation.AddColumn((Object)mt.m_myOrganisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_myOrganisation.AddColumn((Object)mt.m_myOrganisation.m_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation data ID", "Organizacija podatki ID") );
            m_DBTables.items.Add(t_myOrganisation);

            /* 26 */
            t_Reference = new SQLTable((Object)new Reference(),"ref", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Reference);
            t_Reference.AddColumn((Object)mt.m_Reference.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Reference.AddColumn((Object)mt.m_Reference.ReferenceNote, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Reference", "Sklic") );
            t_Reference.AddColumn((Object)mt.m_Reference.m_Reference_Image, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Document Image", "Slika dokumenta") );
            m_DBTables.items.Add(t_Reference);

            /* 27 */
            t_Item = new SQLTable((Object)new Item(),"i", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_ItemName);
            t_Item.AddColumn((Object)mt.m_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item.AddColumn((Object)mt.m_Item.UniqueName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unique Item Name", "Unikatni Naziv Artikla") );
            t_Item.AddColumn((Object)mt.m_Item.Name, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Item Name", "Ime Artikla"));
            t_Item.AddColumn((Object)mt.m_Item.m_Unit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Unit ID", "Enota ID"));
            t_Item.AddColumn((Object)mt.m_Item.Code, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Item Code", "Št.Artikla"));
            t_Item.AddColumn((Object)mt.m_Item.m_Item_ParentGroup1, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "ID item group 1", "ID skupine artiklov 1") );
            t_Item.AddColumn((Object)mt.m_Item.barcode, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item barcode", "črtna koda") );
            t_Item.AddColumn((Object)mt.m_Item.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_Item.AddColumn((Object)mt.m_Item.m_Item_Image, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item Image ID", "Slika Artikla ID") );
            t_Item.AddColumn((Object)mt.m_Item.m_Expiry, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry ID", "Rok uporabe ID") );
            t_Item.AddColumn((Object)mt.m_Item.m_Warranty, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty ID", "Garancija ID") );
            t_Item.AddColumn((Object)mt.m_Item.ToOffer, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.ReadOnly_CheckBox_default_true, new ltext( "To offer", "V ponudbi") );
            m_DBTables.items.Add(t_Item);

            /* 28 */
            t_Taxation = new SQLTable((Object)new Taxation(),"tax", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Taxation);
            t_Taxation.AddColumn((Object)mt.m_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Taxation.AddColumn((Object)mt.m_Taxation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name", "Ime") );
            t_Taxation.AddColumn((Object)mt.m_Taxation.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Rate", "Stopnja") );
            m_DBTables.items.Add(t_Taxation);

            /* 29 */
            t_Stock = new SQLTable((Object)new Stock(), "stock", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Stock);
            t_Stock.AddColumn((Object)mt.m_Stock.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Stock.AddColumn((Object)mt.m_Stock.ImportTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker_Now, new ltext("Import time", "Čas vnosa"));
            t_Stock.AddColumn((Object)mt.m_Stock.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Quantity in Stok", "Količina na zalogi"));
            t_Stock.AddColumn((Object)mt.m_Stock.ExpiryDate, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.DateTimePicker_Now, new ltext("Expiry Date", "Rok uporabe"));
            t_Stock.AddColumn((Object)mt.m_Stock.m_PurchasePrice_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase Price Item ID", "Nabavna Cena Artikel ID"));
            t_Stock.AddColumn((Object)mt.m_Stock.m_Stock_AddressLevel1, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("ID Stock Address Level 1", "ID Naslova nivo 1"));
            t_Stock.AddColumn((Object)mt.m_Stock.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Stock);

            /* 30 */
            t_SimpleItem = new SQLTable((Object)new SimpleItem(),"si", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SimpleItem);
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Name", "Ime") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Abbreviation", "Kratica") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.ToOffer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "To offer", "V ponudbi") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.m_SimpleItem_Image, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item/Service Image ID ", "Slika artikla/storitve ID") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Code, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Code", "Št.Artikla/Storitve") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.m_SimpleItem_ParentGroup1, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Group", "Skupina") );
            m_DBTables.items.Add(t_SimpleItem);

            /* 31 */
            t_MethodOfPayment_DI = new SQLTable((Object)new MethodOfPayment_DI(),"mtpdi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_MethodOfPayment_DI);
            t_MethodOfPayment_DI.AddColumn((Object)mt.m_MethodOfPayment_DI.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_MethodOfPayment_DI.AddColumn((Object)mt.m_MethodOfPayment_DI.m_PaymentType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Payment Type ID", "Način plačila ID") );
            t_MethodOfPayment_DI.AddColumn((Object)mt.m_MethodOfPayment_DI.m_Atom_BankAccount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Bank Account archive ID", "Bančni račun arhiv ID"));
            m_DBTables.items.Add(t_MethodOfPayment_DI);

            /* 32 */
            t_JOURNAL_DocProformaInvoice_Type = new SQLTable((Object)new JOURNAL_DocProformaInvoice_Type(), "jdpinvt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_DocProformaInvoice_Type);
            t_JOURNAL_DocProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_DocProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Type Name", "Ime"));
            t_JOURNAL_DocProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_JOURNAL_DocProformaInvoice_Type);


            /* 33 */
            t_Atom_Item = new SQLTable((Object)new Atom_Item(),"ai", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_InvoiceItem);
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.UniqueName, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Unique Name", "Unikatno ime") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_Name, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item Name ID", "Ime Artikla ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Unit, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Unit archive ID", "Enota arhiv ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_barcode, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item barcode ID", "barkoda ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item description ID", "Opis artikla ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Expiry, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry ID", "Rok uporabe ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Warranty, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty ID", "Garancija ID") );
            m_DBTables.items.Add(t_Atom_Item);

            /* 34 */
            t_Atom_SimpleItem = new SQLTable((Object)new Atom_SimpleItem(), "asi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_InvoiceItem);
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SimpleItem ID", "Artikel/Storitev ID"));
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_Atom_SimpleItem_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SimpleItem Name ID", "Ime Artikla/Storitve ID"));
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_Atom_SimpleItem_Image, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SimpleItem Image ID", "Slika Artikla/Storitve ID"));
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.Code, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Code", "Koda Artikla/Storitve"));
            m_DBTables.items.Add(t_Atom_SimpleItem);

            /* 35 */
            t_cCardType_Person = new SQLTable((Object)new cCardType_Person(),"cardtper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCardType_Perosn);
            t_cCardType_Person.AddColumn((Object)mt.m_cCardType_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCardType_Person.AddColumn((Object)mt.m_cCardType_Person.CardType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Card Type", "Vrsta Kartice") );
            m_DBTables.items.Add(t_cCardType_Person);

            /* 36 */
            t_DBSettings = new SQLTable((Object)new TangentaTableClass.DBSettings(),"dbset", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cCardType_Perosn);
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Name", "Ime Nastavitve") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.TextValue, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Value", "Vrednost Nastavitve") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.ReadOnly, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox, new ltext( "Read Only", "Samo za branje") );
            m_DBTables.items.Add(t_DBSettings);

            /* 37 */
            t_Atom_Item_Image = new SQLTable((Object)new Atom_Item_Image(),"aiimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Item_Image);
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.m_Atom_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Item ID", "Artikel ID") );
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.m_Atom_Item_ImageLib, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Image ID", "Slika ID") );
            m_DBTables.items.Add(t_Atom_Item_Image);

            /* 38 */
            t_Atom_Item_ImageLib = new SQLTable((Object)new Atom_Item_ImageLib(),"aiimgl", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Item_ImageLib);
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "ident. slike") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image", "Slika artikla") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Image description", "Opis slike") );
            m_DBTables.items.Add(t_Atom_Item_ImageLib);

            /* 39 */
            t_Atom_Item_Name = new SQLTable((Object)new Atom_Item_Name(),"ain", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Item_Name);
            t_Atom_Item_Name.AddColumn((Object)mt.m_Atom_Item_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Name.AddColumn((Object)mt.m_Atom_Item_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item Name", "Ime artikla") );            
            m_DBTables.items.Add(t_Atom_Item_Name);


            /* 40 */
            t_Atom_Item_barcode = new SQLTable((Object)new Atom_Item_barcode(),"aibar", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Item_barcode);
            t_Atom_Item_barcode.AddColumn((Object)mt.m_Atom_Item_barcode.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_barcode.AddColumn((Object)mt.m_Atom_Item_barcode.barcode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item barcode", "Črtna koda artikla") );        
            m_DBTables.items.Add(t_Atom_Item_barcode);


        /* 41 */
            t_Atom_Item_Description = new SQLTable((Object)new Atom_Item_Description(),"aid", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Item_Description);
            t_Atom_Item_Description.AddColumn((Object)mt.m_Atom_Item_Description.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Description.AddColumn((Object)mt.m_Atom_Item_Description.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item Description", "Opis artikla") );            
            m_DBTables.items.Add(t_Atom_Item_Description);


        /* 42 */
            t_Atom_SimpleItem_Name = new SQLTable((Object)new Atom_SimpleItem_Name(),"asin", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_SimpleItem_Name);
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "SimpleItem Name archive", "Ime artikla/storitve arhiv") );
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "SimpleItem Abbreviation archive", "Kratica artikla/storitve arhiv") );
            m_DBTables.items.Add(t_Atom_SimpleItem_Name);


        /* 43 */
            t_Atom_Taxation = new SQLTable((Object)new Atom_Taxation(),"atax", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Taxation);
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Taxation Name", "Naziv obdavčitve") );
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Taxation Rate", "Davčna Stopnja") );
            m_DBTables.items.Add(t_Atom_Taxation);

        /* 44 */
            t_Atom_SimpleItem_Image = new SQLTable((Object)new Atom_SimpleItem_Image(),"asinimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_SimpleItem_Image);
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Atom_SimpleItem_Image_Hash", "Ident slike") );
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Atom_SimpleItem_Image", "Slika artikla/storitve") );            
            m_DBTables.items.Add(t_Atom_SimpleItem_Image);


            /* 45 */
            t_DocInvoice = new SQLTable((Object)new DocInvoice(), "dinv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Invoice);
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Draft, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Draft", "Osnutek"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.DraftNumber, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Draft Number", "Številka Osnutka"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.FinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Financial Year", "Obračunsko Leto"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.NumberInFinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Number in Financial Year", "Številka v Obračunskem Letu"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.NetSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Net Sum", "Cena brez DDV"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Discount, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Discount", "Popust"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.EndSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("End Sum", "Cena s popustom"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.TaxSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Tax Sum", "DDV"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.GrossSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Gross Sum", "Cena za plačilo"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.m_Atom_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Curreny archiv ID", "Valuta arhiv ID"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.m_Atom_Customer_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customer Person archive ID", "Oseba Kupec arhiv ID"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.m_Atom_Customer_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customer Organisation archive ID", "Kupec Organizacija arhiv ID"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Paid, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Paid", "Plačano"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Storno, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Storno", "Stornirano"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Invoice_Reference_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice Reference ID", "Referenca na račun ID"));
            t_DocInvoice.AddColumn((Object)mt.m_DocInvoice.Invoice_Reference_Type, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice Reference Type", "Vrsta reference na račun"));
            m_DBTables.items.Add(t_DocInvoice);


            /* 46 */

            t_Doc_ImageLib = new SQLTable((Object)new Doc_ImageLib(),"dimgl", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DocInvoice_Image);
            t_Doc_ImageLib.AddColumn((Object)mt.m_Doc_ImageLib.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Doc_ImageLib.AddColumn((Object)mt.m_Doc_ImageLib.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Ident slike") );
            t_Doc_ImageLib.AddColumn((Object)mt.m_Doc_ImageLib.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image", "Slika") );
            t_Doc_ImageLib.AddColumn((Object)mt.m_Doc_ImageLib.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Image Description", "Opis slike") );            
            m_DBTables.items.Add(t_Doc_ImageLib);


         /* 47 */
            t_DocInvoiceAddOn = new SQLTable((Object)new DocInvoiceAddOn(), "dinvao", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DocInvoiceAddOn);
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "DocInvoice ID", "Račun ID") );
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.IssueDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice Time", "Datum računa"));
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_TermsOfPayment, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Terms of payment ID", "Plačilni pogoji ID") );
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_MethodOfPayment_DI, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Terms of payment ID", "Plačilni pogoji ID"));
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_Atom_Warranty, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Warranty archive ID", "Garancija arhiv ID"));
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.PaymentDeadline, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Payment deadline", "Rok plačila"));
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_Atom_Notice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Notice Archive ID", "Dopis arhiv ID"));
            t_DocInvoiceAddOn.AddColumn((Object)mt.m_DocInvoiceAddOn.m_Doc_ImageLib, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Doc image lib archive ID", "Slika arhiv ID"));
            m_DBTables.items.Add(t_DocInvoiceAddOn);

        /* 48 */
            t_TermsOfPayment = new SQLTable((Object)new TermsOfPayment(),"trmpay", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_TermsOfPayment);
            t_TermsOfPayment.AddColumn((Object)mt.m_TermsOfPayment.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_TermsOfPayment.AddColumn((Object)mt.m_TermsOfPayment.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );            
            m_DBTables.items.Add(t_TermsOfPayment);

        /* 49 */
            t_myOrganisation_Person = new SQLTable((Object)new myOrganisation_Person(),"mcomper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_myOrganisation_Person);
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.Job, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Job", "Delovno mesto") );
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.Active, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "Active", "Aktivna") );
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "My Organisation Person ID", "Oseba v podjetju ID") );
            t_myOrganisation_Person.AddColumn((Object)mt.m_myOrganisation_Person.m_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Office ID", "Poslovna enota ID") );
            m_DBTables.items.Add(t_myOrganisation_Person);

        /* 50 */
            t_DocInvoice_ShopC_Item = new SQLTable((Object)new DocInvoice_ShopC_Item(),"dinvshci", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_DocProformaInvoice_ShopC_Item);
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Selected Quantity", "Izbrana Količina") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Extra Discount", "Dodatni Popust") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.RetailPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "RetailSimpleItemPrice with discount", "Prodajna cena s popustom") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax price", "Davek") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Invoice ID", "Račun ID") );            
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.m_Atom_Price_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Price-Item arh ID", "Cena-Artikel arh ID") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.ExpiryDate,Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Expiry Date", "Rok uporabe") );
            t_DocInvoice_ShopC_Item.AddColumn((Object)mt.m_DocInvoice_ShopC_Item.m_Stock, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Stock ID", "Zaloga ID") );
            m_DBTables.items.Add(t_DocInvoice_ShopC_Item);

        /* 51 */
            t_Atom_myOrganisation_Person = new SQLTable((Object)new Atom_myOrganisation_Person(),"amcper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_myOrganisation_Person);
            t_Atom_myOrganisation_Person.AddColumn((Object)mt.m_Atom_myOrganisation_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_myOrganisation_Person.AddColumn((Object)mt.m_Atom_myOrganisation_Person.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Person arh ID", "Oseba arh ID") );            
            t_Atom_myOrganisation_Person.AddColumn((Object)mt.m_Atom_myOrganisation_Person.m_Atom_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "My Organisation arh ID", "Podjetje arh ID") );
            t_Atom_myOrganisation_Person.AddColumn((Object)mt.m_Atom_myOrganisation_Person.Job, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Job", "Delovno mesto") );            
            t_Atom_myOrganisation_Person.AddColumn((Object)mt.m_Atom_myOrganisation_Person.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );            
            m_DBTables.items.Add(t_Atom_myOrganisation_Person);

        /* 52 */
            t_Atom_myOrganisation = new SQLTable((Object)new Atom_myOrganisation(),"amc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_myOrganisation);
            t_Atom_myOrganisation.AddColumn((Object)mt.m_Atom_myOrganisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_myOrganisation.AddColumn((Object)mt.m_Atom_myOrganisation.m_Atom_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation data ID archive", "Organizacija podatki ID arhiv") );
            m_DBTables.items.Add(t_Atom_myOrganisation);

        /* 53 */
            t_Atom_Person = new SQLTable((Object)new Atom_Person(),"aper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_BuyerAtom_Person);
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.Gender, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.RadioButtons, new ltext( "Male/Female", "Moški/Ženska") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cFirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "First Name ID", "Ime ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cLastName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Last Name ID", "Priimek ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.DateOfBirth, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Date of Birth", "Datum Rojstva") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.Tax_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax id", "Davčna številka") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Registration id", "EMŠO") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cGsmNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Phone Number ID", "Telefonska številka ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cPhoneNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Gsm Number ID", "Številka Gsm ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cEmail_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cAddress_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Address ID", "Naslov ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.CardNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Number", "Številka kartice") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_cCardType_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Type ID", "Vrsta Kartice ID") );
            t_Atom_Person.AddColumn((Object)mt.m_BuyerAtom_Person.m_Atom_PersonImage, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image", "Slika") );
            m_DBTables.items.Add(t_Atom_Person);

        /* 54 */
            t_Atom_Organisation = new SQLTable((Object)new Atom_Organisation(),"aorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Organisation);
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation name", "Ime Organizacije") );
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Tax_ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TAX ID", "Davčna številka"));
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Registration ID", "Matična Številka"));
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.TaxPayer, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Tax payer", "Davčni zavezanec"));
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.m_Atom_Comment1, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Comment 1 archive ID", "Komentar 1 arhiv ID"));
            m_DBTables.items.Add(t_Atom_Organisation);

         /* 55 */
            t_SimpleItem_Image = new SQLTable((Object)new SimpleItem_Image(),"siimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SimpleItem_Image);
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "SimpleItem Image", "Slika artikla/storitve") );
            m_DBTables.items.Add(t_SimpleItem_Image);

         /* 56 */
            t_Item_Image = new SQLTable((Object)new Item_Image(),"iimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Item_Image);
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item Image", "Slika Storitve") );
            m_DBTables.items.Add(t_Item_Image);

         /* 57 */
            t_Expiry = new SQLTable((Object)new Expiry(),"exp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Expiry);
            t_Expiry.AddColumn((Object)mt.m_Expiry.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.ExpectedShelfLifeInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expected Shelf Life In Days", "Pričakovani rok uporabe (v dneh)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.SaleBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "SaleBeforeExpiryDateInDays", "Razprodaja zaloge pred rokom uporabe (v dnevih)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.DiscardBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "DiscardBeforeExpiryDateInDays", "Znebitev zaloge pred rokom uporabe (v dnevih)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.ExpiryDescription, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry Description", "Opis roka uporabe") );
            m_DBTables.items.Add(t_Expiry);

         /* 58 */
            t_Warranty = new SQLTable((Object)new Warranty(),"wrty", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Warranty);
            t_Warranty.AddColumn((Object)mt.m_Warranty.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyDuration, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "čas garancije", "čas garancije") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyDurationType, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty duration unit", "Enota časa garancije") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyConditions, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty conditions", "Garancijski pogoji") );
            m_DBTables.items.Add(t_Warranty);

         /* 59 */
            t_Atom_Expiry = new SQLTable((Object)new Atom_Expiry(),"aexp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Expiry);
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ExpectedShelfLifeInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expected Shelf Life In Days", "Pričakovani rok uporabe (v dneh)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.SaleBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "SaleBeforeAtom_ExpiryDateInDays", "Razprodaja zaloge pred rokom uporabe (v dnevih)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.DiscardBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "DiscardBeforeAtom_ExpiryDateInDays", "Znebitev zaloge pred rokom uporabe (v dnevih)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ExpiryDescription, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Atom_Expiry Description ID", "Opis roka uporabe ID") );
            m_DBTables.items.Add(t_Atom_Expiry);

         /* 60 */
            t_Atom_Warranty = new SQLTable((Object)new Atom_Warranty(),"awrty", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Warranty);
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyDuration, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "čas garancije", "čas garancije") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyDurationType, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Atom_Warranty duration unit", "Enota časa garancije") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyConditions, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.RichTextBox, new ltext( "Atom_Warranty conditions ID", "Garancijski pogoji ID") );
            m_DBTables.items.Add(t_Atom_Warranty);

         /* 61 */
            t_Item_ParentGroup3 = new SQLTable((Object)new Item_ParentGroup3(),"ipg3", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Item_ParentGroup3);
            t_Item_ParentGroup3.AddColumn((Object)mt.m_Item_ParentGroup3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup3.AddColumn((Object)mt.m_Item_ParentGroup3.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Name of group 3", "Ime skupine 3") );
            m_DBTables.items.Add(t_Item_ParentGroup3);

         /* 62 */
            t_Item_ParentGroup2 = new SQLTable((Object)new Item_ParentGroup2(),"ipg2", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Item_ParentGroup2);
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 2", "Ime skupine 2") );
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.m_Item_ParentGroup3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 3", "ID skupine artiklov 3") );
            m_DBTables.items.Add(t_Item_ParentGroup2);

         /* 63 */
            t_Item_ParentGroup1 = new SQLTable((Object)new Item_ParentGroup1(),"ipg1", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Item_ParentGroup1);
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 1", "Ime skupine 1") );
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.m_Item_ParentGroup2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 2", "ID skupine artiklov 2") );
            m_DBTables.items.Add(t_Item_ParentGroup1);

         /* 64 */
            t_Stock_AddressLevel3 = new SQLTable((Object)new Stock_AddressLevel3(),"sal3", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Stock_AddressLevel3);
            t_Stock_AddressLevel3.AddColumn((Object)mt.m_Stock_AddressLevel3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel3.AddColumn((Object)mt.m_Stock_AddressLevel3.Address, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Stock Address Level 3", "Naslov nivo 3") );
            m_DBTables.items.Add(t_Stock_AddressLevel3);

         /* 65 */
            t_Stock_AddressLevel2 = new SQLTable((Object)new Stock_AddressLevel2(),"sal2", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Stock_AddressLevel2);
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.Address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock Address Level 2", "Naslov nivo 2") );
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.m_Stock_AddressLevel3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID Stock Adreess 3", "ID Naslova nivo 3") );
            m_DBTables.items.Add(t_Stock_AddressLevel2);

         /* 66 */
            t_Stock_AddressLevel1 = new SQLTable((Object)new Stock_AddressLevel1(),"sal1", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Stock_AddressLevel1);
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.Address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock Address 2", "Naslov nivo 1") );
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.m_Stock_AddressLevel2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID Stock Address 2", "ID Naslova nivo 2") );
            m_DBTables.items.Add(t_Stock_AddressLevel1);


        /* 67 */
            t_Atom_cStreetName_Person = new SQLTable((Object)new Atom_cStreetName_Person(),"astrnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cStreetName_Person);;
            t_Atom_cStreetName_Person.AddColumn((Object)mt.m_Atom_cStreetName_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cStreetName_Person.AddColumn((Object)mt.m_Atom_cStreetName_Person.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street name", "Cesta") );
            m_DBTables.items.Add(t_Atom_cStreetName_Person);

        /* 68 */
            t_Atom_cHouseNumber_Person = new SQLTable((Object)new Atom_cHouseNumber_Person(),"ahounper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cHouseNumber_Person);
            t_Atom_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_Atom_cHouseNumber_Person);

        /* 69 */
            t_Atom_cCity_Person = new SQLTable((Object)new Atom_cCity_Person(),"acitper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cCity_Person);
            t_Atom_cCity_Person.AddColumn((Object)mt.m_Atom_cCity_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCity_Person.AddColumn((Object)mt.m_Atom_cCity_Person.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "City", "Kraj") );
            m_DBTables.items.Add(t_Atom_cCity_Person);

        /* 70 */
            t_Atom_cZIP_Person = new SQLTable((Object)new Atom_cZIP_Person(),"azipper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cZIP_Person);
            t_Atom_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cZIP_Person);

        /* 71 */
            t_Atom_cCountry_Person = new SQLTable((Object)new Atom_cCountry_Person(),"astper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cCountry_Person);
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Person.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Country", "Država") );
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Person.Country_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a2", "ISO_3166 a3"));
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Person.Country_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Person.Country_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_Atom_cCountry_Person);

        /* 72 */
            t_Atom_cState_Person = new SQLTable((Object)new Atom_cState_Person(),"acouper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cState_Person);
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Org.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "State", "Dežela") );
            m_DBTables.items.Add(t_Atom_cState_Person);

        /* 73 */
            t_Atom_cStreetName_Org = new SQLTable((Object)new Atom_cStreetName_Org(),"astrnorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cStreetName_Org);;
            t_Atom_cStreetName_Org.AddColumn((Object)mt.m_Atom_cStreetName_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cStreetName_Org.AddColumn((Object)mt.m_Atom_cStreetName_Org.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street name", "Cesta") );
            m_DBTables.items.Add(t_Atom_cStreetName_Org);

        /* 74 */
            t_Atom_cHouseNumber_Org = new SQLTable((Object)new Atom_cHouseNumber_Org(),"ahounorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cHouseNumber_Org);
            t_Atom_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_Atom_cHouseNumber_Org);

        /* 75 */
            t_Atom_cCity_Org = new SQLTable((Object)new Atom_cCity_Org(),"acitorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cCity_Org);
            t_Atom_cCity_Org.AddColumn((Object)mt.m_Atom_cCity_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCity_Org.AddColumn((Object)mt.m_Atom_cCity_Org.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "City", "Kraj") );
            m_DBTables.items.Add(t_Atom_cCity_Org);

        /* 76 */
            t_Atom_cZIP_Org = new SQLTable((Object)new Atom_cZIP_Org(),"aziporg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cZIP_Org);
            t_Atom_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cZIP_Org);

        /* 77 */
            t_Atom_cCountry_Org = new SQLTable((Object)new Atom_cCountry_Org(), "astorg",Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cCountry_Org);
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Country", "Država") );
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.Country_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a2", "ISO_3166 a3"));
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.Country_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.Country_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_Atom_cCountry_Org);


        /* 78 */
            t_Atom_cState_Org = new SQLTable((Object)new Atom_cState_Org(),"acouorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cState_Org);
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cState_Org);

        /* 79 */
            t_cAddress_Person = new SQLTable((Object)new cAddress_Person(), "cadrper",Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cAddress_Person);
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cStreetName_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cHouseNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cCity_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cZIP_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cCountry_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Država ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cState_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Dežela ID") );
            m_DBTables.items.Add(t_cAddress_Person);

        /* 80 */
            t_cAddress_Org = new SQLTable((Object)new cAddress_Org(),"cadrorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_cAddress_Org);
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cStreetName_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cHouseNumber_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cCity_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cZIP_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cCountry_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Država ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cState_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Dežela ID") );
            m_DBTables.items.Add(t_cAddress_Org);

        /* 81 */
            t_Atom_cAddress_Person = new SQLTable((Object)new Atom_cAddress_Person(),"acadrper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cAddress_Person);
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cStreetName_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cHouseNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cCity_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cZIP_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cCountry_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Država ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cState_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Dežela ID") );
            m_DBTables.items.Add(t_Atom_cAddress_Person);

        /* 82 */
            t_Atom_cAddress_Org = new SQLTable((Object)new Atom_cAddress_Org(),"acadrorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cAddress_Org);
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cStreetName_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cHouseNumber_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cCity_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cZIP_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cCountry_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Država ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cState_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Dežela ID") );
            m_DBTables.items.Add(t_Atom_cAddress_Org);

        /* 83 */
            t_Price_Item = new SQLTable((Object)new Price_Item(),"pi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Price_Item);
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.RetailPricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail Price Per Unit", "Maloprodajna cena na komad") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation ID", "Obdavčitev ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Item ID", "Artikel ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Price List ID", "Cenik ID") );
            m_DBTables.items.Add(t_Price_Item);

        /* 84 */
            t_Price_SimpleItem = new SQLTable((Object)new Price_SimpleItem(),"psi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Price_SimpleItem);
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.RetailSimpleItemPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail price", "Prodajna cena") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljavno") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation ID", "Obdavčitev ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "SimpleItem ID", "Artikel/Storitev ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Price list ID", "Cenik ID") );
            m_DBTables.items.Add(t_Price_SimpleItem);

        /* 85 */
            t_PriceList = new SQLTable((Object)new PriceList(),"pl", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_PriceList);
            t_PriceList.AddColumn((Object)mt.m_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.m_PriceList_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price List Name ID", "Ime Cenika ID") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.Valid, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljaven") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.ValidFrom, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid from", "Velja od") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.ValidTo, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid to", "Velja do") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.CreationDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Creation time", "Čas nastanka") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_PriceList);

        /* 86 */
            t_Currency = new SQLTable((Object)new Currency(),"Cur", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Currency);
            t_Currency.AddColumn((Object)mt.m_Currency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Currency.AddColumn((Object)mt.m_Currency.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.TextBox, new ltext( "Currency letter code", "Oznaka valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Currency Name", "Ime Valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Currency Symbol", "Znak valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.CurrencyCode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Code", "Šifra valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalk") );
            m_DBTables.items.Add(t_Currency);


        /* 87 */
            t_BaseCurrency = new SQLTable((Object)new BaseCurrency(),"bcur", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_BaseCurrency);
            t_BaseCurrency.AddColumn((Object)mt.m_BaseCurrency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_BaseCurrency.AddColumn((Object)mt.m_BaseCurrency.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            m_DBTables.items.Add(t_BaseCurrency);

        /* 88 */
            t_RateToBaseCurrency = new SQLTable((Object)new RateToBaseCurrency(),"rtbcur", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_RateToBaseCurrency);
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_BaseCurrency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Base Currency ID", "Osnovna Valuta ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate", "Menjalno razmerje") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.RateDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate Date", "Datum Menjalnega razmerja") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_ExchangeRateSource, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate Source", "Vir Menjalnega razmerja") );
            m_DBTables.items.Add(t_RateToBaseCurrency);

        /* 89 */
            t_ExchangeRateSource = new SQLTable((Object)new ExchangeRateSource(),"exchgrs", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_ExchangeRateSource);
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Source Name", "Ime vira") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.URL, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "URL", "URL") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_ExchangeRateSource);

        /* 90 */
            t_Atom_PriceList = new SQLTable((Object)new Atom_PriceList(),"apl", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_PriceList);;
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.m_Atom_PriceList_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price list name archive ID ", "Ime cenika arhiv ID") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.Valid, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljavno") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ValidFrom, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid from", "Veljavno od") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ValidTo, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid to", "Veljavno do") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.CreationDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Creation Date", "Datum nastanka"));
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.m_Atom_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID archive ", "Valuta ID arhiv") );
            m_DBTables.items.Add(t_Atom_PriceList);


         /* 91 */
            t_PurchasePrice_Item = new SQLTable((Object)new PurchasePrice_Item(), "ppi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_PurchasePrice_Item);
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Item ID", "Artikel ID"));
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.m_PurchasePrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase price ID", "Nabavna cena ID"));
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.m_StockTake, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimeNow, new ltext("Stock Take ID", "Prevzemnica ID"));
            m_DBTables.items.Add(t_PurchasePrice_Item);


         /* 92 */
            t_Atom_Currency = new SQLTable((Object)new Atom_Currency(),"acur", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Currency);
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Name", "Ime valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Abbreviation", "Oznaka valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency symbol", "Znak valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.CurrencyCode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency code", "številka valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal Places", "Število decimalk") );
            m_DBTables.items.Add(t_Atom_Currency);


        /* 93 */
            t_Atom_Price_Item  = new SQLTable((Object)new Atom_Price_Item(),"api", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Price_Item);
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.RetailPricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail price per unit", "Prodajna cena artikla") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation archive ID", "Obdavćitev arhiv ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item archive ID", "Artikel arhiv ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price Item archive ID", "Cenik Artiklov arhiv ID") );
            m_DBTables.items.Add(t_Atom_Price_Item);

        /* 94 */
            t_DocInvoice_ShopB_Item  = new SQLTable((Object)new DocInvoice_ShopB_Item(),"dinvshbi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DocInvoice_ShopB_Item);
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.RetailSimpleItemPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail SimpleItem price", "Cena storitve") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.iQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.RetailSimpleItemPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "RetailSimpleItemPrice with discount", "Prodajna cena s popustom") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Extra Discount", "Dodatni Popust") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax price", "Davek") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.m_Atom_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "SimpleItem archive ID", "Artikel/Storitev arhiv ID") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.m_Atom_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price SimpleItem archive ID", "Cenik artikel/storitev arhiv ID") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.m_Atom_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation archive ID", "Obdavćitev arhiv ID") );
            t_DocInvoice_ShopB_Item.AddColumn((Object)mt.m_DocInvoice_ShopB_Item.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Invoice ID", "Račun ID") );
            m_DBTables.items.Add(t_DocInvoice_ShopB_Item);

         /* 95 */
            t_PersonImage = new SQLTable((Object)new PersonImage(),"perimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_PersonImage);
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Person Image", "Slika osebe") );
            m_DBTables.items.Add(t_PersonImage);

         /* 96 */
            t_Unit = new SQLTable((Object)new Unit(),"u", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Units);
            t_Unit.AddColumn((Object)mt.m_Unit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Unit.AddColumn((Object)mt.m_Unit.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unit Name", "Ime enote") );
            t_Unit.AddColumn((Object)mt.m_Unit.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Symbol", "Simbol") );
            t_Unit.AddColumn((Object)mt.m_Unit.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalnih mest") );
            t_Unit.AddColumn((Object)mt.m_Unit.StorageOption, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Storage option", "Možnost skladiščenja") );
            t_Unit.AddColumn((Object)mt.m_Unit.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Unit);

         /* 97 */
            t_Atom_Unit = new SQLTable((Object)new Atom_Unit(),"au", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_UnitsArchive);
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unit Name", "Ime enote") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Symbol", "Simbol") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalnih mest") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.StorageOption, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Storage option", "Možnost skladiščenja") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Atom_Unit);

         /* 98 */
            t_OrganisationData = new SQLTable((Object)new OrganisationData(),"orgd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_OrganisationData); ;
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cOrgTYPE, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Organisation Type", "Tip Firme") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cAddress_Org, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Address ID", "Naslov ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cPhoneNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Phone Number ID", "Telefonska številka ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cFaxNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Fax Number ID", "Številka Faksa ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cEmail_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cHomePage_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "HomePage ID", "Domača stran ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_Logo, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Logo ID", "Logotip ID") );
            m_DBTables.items.Add(t_OrganisationData);

          /* 99 */
            t_PurchasePrice = new SQLTable((Object)new PurchasePrice(), "pp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_PurchasePrice); ;
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.PurchasePricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase price per unit", "Nabavna cena na enoto"));
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Currency ID", "Valuta ID"));
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Taxation ID", "Davek ID"));
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.PurchasePriceDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase Price Date", "Datum nabavne cene"));
            m_DBTables.items.Add(t_PurchasePrice);

          /* 100 */
            t_Reference_Image = new SQLTable((Object)new Reference_Image(),"refimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Reference_Image); ;
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Reference Image Hash", "Ident slike v sklicu") );
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Reference Image Hash", "Slika daokumenta v sklicu") );
            m_DBTables.items.Add(t_Reference_Image);

         /* 101 */
            t_Atom_OrganisationData = new SQLTable((Object)new Atom_OrganisationData(),"aorgd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_OrganisationData); ;
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_Atom_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Organisation ID arhive", "Organizacija ID arhiv") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_Atom_cAddress_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Address ID", "Naslov ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_cPhoneNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Phone Number ID", "Telefonska številka ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_cFaxNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Fax Number ID", "Številka Faksa ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_cEmail_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_cHomePage_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "HomePage ID", "Domača stran ID") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_cOrgTYPE, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "E-Mail", "e-pošta") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.BankName, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Bank Name", "Ime Banke") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.TRR, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Bank Account", "Bančni račun") );
            t_Atom_OrganisationData.AddColumn((Object)mt.m_Atom_OrganisationData.m_Atom_Logo, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Organisation Logo archive ID", "Logo arhiv ID") );
            m_DBTables.items.Add(t_Atom_OrganisationData);

        /* 102 */
            t_Supplier = new SQLTable((Object)new Supplier(),"sup", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Suplier);
            t_Supplier.AddColumn((Object)mt.m_Supplier.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Supplier.AddColumn((Object)mt.m_Supplier.m_Contact, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Contact ID", "Kontakt ID") );
            m_DBTables.items.Add(t_Supplier);

        /* 103 */
        
            t_Customer_Org = new SQLTable((Object)new Customer_Org(), "cusorg",Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Customer_Org);
            t_Customer_Org.AddColumn((Object)mt.m_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Customer_Org.AddColumn((Object)mt.m_Customer_Org.m_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            m_DBTables.items.Add(t_Customer_Org);

        /* 104 */
            t_Customer_Person = new SQLTable((Object)new Customer_Person(),"cusper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Customer_Person);
            t_Customer_Person.AddColumn((Object)mt.m_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Customer_Person.AddColumn((Object)mt.m_Customer_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Person ID", "Oseba ID") );
            m_DBTables.items.Add(t_Customer_Person);

        /* 105 */
            t_Atom_Customer_Org = new SQLTable((Object)new Atom_Customer_Org(),"acusorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Customer_Org);
            t_Atom_Customer_Org.AddColumn((Object)mt.m_Atom_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Customer_Org.AddColumn((Object)mt.m_Atom_Customer_Org.m_Atom_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID archive", "Organizacija ID arhiv") );
            m_DBTables.items.Add(t_Atom_Customer_Org);

        /* 106 */
            t_Atom_Customer_Person = new SQLTable((Object)new Atom_Customer_Person(),"acusper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Customer_Person);
            t_Atom_Customer_Person.AddColumn((Object)mt.m_Atom_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Customer_Person.AddColumn((Object)mt.m_Atom_Customer_Person.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Person ID archive", "Oseba ID arthiv") );
            m_DBTables.items.Add(t_Atom_Customer_Person);

        /* 107 */
            t_PersonData = new SQLTable((Object)new PersonData(), "perd",Column.Flags.FILTER_AND_UNIQUE, lng.lngt_PersonData);
            t_PersonData.AddColumn((Object)mt.m_PersonData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cGsmNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "GSM Number ID", "Gsm ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cPhoneNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Telephone Number ID", "Telefon ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cEmail_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cAddress_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Adress ID", "Naslov ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.CardNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Number", "Številka kartice") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cCardType_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Type ID", "Vrsta Kartice ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_PersonImage, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image", "Slika") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Person ID", "Oseba ID"));
            m_DBTables.items.Add(t_PersonData);

        /* 108 */
            t_PersonAccount = new SQLTable((Object)new PersonAccount(),"peracc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_PersonAccount);
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.m_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Bank Account ID", "Bančni račun ID") );
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Person ID", "Oseba ID") );
            m_DBTables.items.Add(t_PersonAccount);

        /* 109 */
            t_Bank = new SQLTable((Object)new Bank(),"bank", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Bank);
            t_Bank.AddColumn((Object)mt.m_Bank.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Bank.AddColumn((Object)mt.m_Bank.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            m_DBTables.items.Add(t_Bank);

        /* 110 */
            t_BankAccount = new SQLTable((Object)new BankAccount(),"bankacc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_BankAccount);
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.TRR, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Account", "TRR") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.Active, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "Active", "Aktiven") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.m_Bank, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Bank ID", "Banka ID"));
            m_DBTables.items.Add(t_BankAccount);

        /* 111 */
            t_OrganisationAccount = new SQLTable((Object)new OrganisationAccount(),"orgacc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_OrganisationAccount);
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.m_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Bank Account ID", "Bančni račun ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation ID", "Oseba ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_OrganisationAccount);

        /* 112 */
            t_JOURNAL_PriceList_Type = new SQLTable((Object)new JOURNAL_PriceList_Type(),"jplt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_PriceList_Type);
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_PriceList_Type);

        /* 113 */
            t_JOURNAL_DocInvoice_Type = new SQLTable((Object)new JOURNAL_DocInvoice_Type(),"jpinvt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_DocInvoice_Type);
            t_JOURNAL_DocInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocInvoice_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_DocInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocInvoice_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_DocInvoice_Type.AddColumn((Object)mt.m_JOURNAL_DocInvoice_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_DocInvoice_Type);

        /* 114 */
            t_JOURNAL_Item_Type = new SQLTable((Object)new JOURNAL_Item_Type(),"jit", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Item_Type);
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Item_Type);

        /* 115 */
            t_JOURNAL_SimpleItem_Type = new SQLTable((Object)new JOURNAL_SimpleItem_Type(),"jsit", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_SimpleItem_Type);
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_SimpleItem_Type);

        /* 116 */
            t_JOURNAL_myOrganisation_Type = new SQLTable((Object)new JOURNAL_myOrganisation_Type(),"jmct", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_myOrganisation_Type);
            t_JOURNAL_myOrganisation_Type.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myOrganisation_Type.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_myOrganisation_Type.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_myOrganisation_Type);

        /* 117 */
            t_JOURNAL_myOrganisation_Person_Type = new SQLTable((Object)new JOURNAL_Person_Type(),"jpert", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_myOrganisation_Person_Type);
            t_JOURNAL_myOrganisation_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myOrganisation_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_myOrganisation_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_myOrganisation_Person_Type);


        /* 118 */
            t_JOURNAL_Customer_Person_Type = new SQLTable((Object)new JOURNAL_Customer_Person_Type(),"jcuspert", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Person_Type);
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Type);

        /* 119 */
            t_JOURNAL_Customer_Org_Type = new SQLTable((Object)new JOURNAL_Customer_Org_Type(),"jcusorgt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Org_Type);
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Org_Type);

        /* 120 */
            t_JOURNAL_StockTake_Type = new SQLTable((Object)new JOURNAL_StockTake_Type(),"jstt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_StockTake_Type);
            t_JOURNAL_StockTake_Type.AddColumn((Object)mt.m_JOURNAL_StockTake_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_StockTake_Type.AddColumn((Object)mt.m_JOURNAL_StockTake_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_StockTake_Type.AddColumn((Object)mt.m_JOURNAL_StockTake_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_StockTake_Type);

        /* 121 */
            t_JOURNAL_Taxation_Type = new SQLTable((Object)new JOURNAL_Taxation_Type(),"jtaxt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Taxation_Type);
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Taxation_Type);

        /* 122 */
            t_JOURNAL_Stock_Type = new SQLTable((Object)new JOURNAL_Stock_Type(),"jstockt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Stock_Type);
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Stock_Type);

        /* 123 */
            t_JOURNAL_DocInvoice = new SQLTable((Object)new JOURNAL_DocInvoice(),"jdinv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_DocInvoice);
            t_JOURNAL_DocInvoice.AddColumn((Object)mt.m_JOURNAL_DocInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_DocInvoice.AddColumn((Object)mt.m_JOURNAL_DocInvoice.m_JOURNAL_DocInvoice_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal event invoice ID", "Dogodek račun ID") );
            t_JOURNAL_DocInvoice.AddColumn((Object)mt.m_JOURNAL_DocInvoice.m_DocInvoice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Invoice ID", "Račun ID") );
            t_JOURNAL_DocInvoice.AddColumn((Object)mt.m_JOURNAL_DocInvoice.EventTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_DocInvoice.AddColumn((Object)mt.m_JOURNAL_DocInvoice.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_DocInvoice);

        /* 124 */
            t_JOURNAL_DocProformaInvoice = new SQLTable((Object)new JOURNAL_DocProformaInvoice(),"jdpinv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_DocProformaInvoice);
            t_JOURNAL_DocProformaInvoice.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_DocProformaInvoice.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice.m_JOURNAL_DocProformaInvoice_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event proforma-invoice ID", "Dogodek predračun ID") );
            t_JOURNAL_DocProformaInvoice.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice.m_DocProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Predračun ID") );
            t_JOURNAL_DocProformaInvoice.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_DocProformaInvoice.AddColumn((Object)mt.m_JOURNAL_DocProformaInvoice.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_DocProformaInvoice);


        /* 125 */
            t_JOURNAL_Item = new SQLTable((Object)new JOURNAL_Item(),"ji", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Item);
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_JOURNAL_Item_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event item ID", "Dogodek predračun ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Predračun ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID"));
            m_DBTables.items.Add(t_JOURNAL_Item);

        /* 126 */
            t_JOURNAL_SimpleItem = new SQLTable((Object)new JOURNAL_SimpleItem(),"jsi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_SimpleItem);
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_JOURNAL_SimpleItem_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event SimpleItem ID", "Dogodek storitev ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma SimpleItem ID", "Artikel/Storitev ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_SimpleItem);

        /* 127 */
            t_JOURNAL_PriceList = new SQLTable((Object)new JOURNAL_PriceList(),"jpl", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_PriceList);
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_JOURNAL_PriceList_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event price list ID", "Dogodek cenik ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Price list ID", "Cenik ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_PriceList);

        /* 128 */
            t_JOURNAL_myOrganisation = new SQLTable((Object)new JOURNAL_myOrganisation(),"jmc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_myOrganisation);
            t_JOURNAL_myOrganisation.AddColumn((Object)mt.m_JOURNAL_myOrganisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myOrganisation.AddColumn((Object)mt.m_JOURNAL_myOrganisation.m_JOURNAL_myOrganisation_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event my organisation ID", "Dogodek moja organizacija ID") );
            t_JOURNAL_myOrganisation.AddColumn((Object)mt.m_JOURNAL_myOrganisation.m_myOrganisation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "My organisation ID", "Moja organizacija ID") );
            t_JOURNAL_myOrganisation.AddColumn((Object)mt.m_JOURNAL_myOrganisation.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_myOrganisation.AddColumn((Object)mt.m_JOURNAL_myOrganisation.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_myOrganisation);

        /* 129 */
            t_JOURNAL_Person = new SQLTable((Object)new JOURNAL_Person(),"jper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Person);
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_JOURNAL_Person_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event person ID", "Dogodek fizična oseba ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Person ID", "Fizična oseba ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext(  "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Person);

        /* 130 */
            t_JOURNAL_Customer_Person = new SQLTable((Object)new JOURNAL_Customer_Person(),"jcusper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Person);
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_JOURNAL_Customer_Person_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event customer person ID", "Dogodek fizična oseba ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_Customer_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Customer person ID", "Stranka fizična oseba ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person);

        /* 131 */
            t_JOURNAL_Customer_Person_Data = new SQLTable((Object)new JOURNAL_Customer_Person_Data(),"jcusperd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Person_Data);
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.m_JOURNAL_Customer_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal customer person ID", "Dnevnik fizična oseba ID") );
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.m_Description, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Data);

        /* 132 */
            t_JOURNAL_Customer_Person_Data_Image = new SQLTable((Object)new JOURNAL_Customer_Person_Data_Image(),"jcusperdimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Person_Data_Image);
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Image Hash", "Identifikacija slike (\"Image_Hash\")") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Image Data", "Slika") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Description, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Data_Image);

        /* 133 */
            t_JOURNAL_Customer_Org = new SQLTable((Object)new JOURNAL_Customer_Org(),"jcusorg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Customer_Org);
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_JOURNAL_Customer_Org_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event customer organisation ID", "Dogodek stranka organizacija ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_Customer_Org, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Customer organisation ID", "Stranka organizacija ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") ); 
            m_DBTables.items.Add(t_JOURNAL_Customer_Org);

        /* 134 */
            t_JOURNAL_StockTake = new SQLTable((Object)new JOURNAL_StockTake(),"jst", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_StockTake);
            t_JOURNAL_StockTake.AddColumn((Object)mt.m_JOURNAL_StockTake.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_StockTake.AddColumn((Object)mt.m_JOURNAL_StockTake.m_JOURNAL_StockTake_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event stock take ID", "Dogodek Prevzemnica ID") );
            t_JOURNAL_StockTake.AddColumn((Object)mt.m_JOURNAL_StockTake.m_StockTake, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Stock take ID", "Prevzemnica ID") );
            t_JOURNAL_StockTake.AddColumn((Object)mt.m_JOURNAL_StockTake.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_StockTake.AddColumn((Object)mt.m_JOURNAL_StockTake.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_StockTake);

        /* 135 */
            t_JOURNAL_Taxation = new SQLTable((Object)new JOURNAL_Taxation(),"jtax", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Taxation);
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_JOURNAL_Taxation_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event taxation ID", "Dogodek davki ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Taxation ID", "Davek ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Taxation);

        /* 136 */
            t_JOURNAL_Stock = new SQLTable((Object)new JOURNAL_Stock(),"jstock", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Stock);
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_JOURNAL_Stock_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event stock ID", "Dogodek skladišče ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_Stock, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Stock ID", "Skladišče ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            m_DBTables.items.Add(t_JOURNAL_Stock);

        /* 137 */
            t_SimpleItem_ParentGroup3 = new SQLTable((Object)new SimpleItem_ParentGroup3(),"sipg3", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SimpleItem_ParentGroup3);
            t_SimpleItem_ParentGroup3.AddColumn((Object)mt.m_SimpleItem_ParentGroup3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup3.AddColumn((Object)mt.m_SimpleItem_ParentGroup3.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Name of group 3", "Ime skupine 3") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup3);

        /* 138 */
            t_SimpleItem_ParentGroup2 = new SQLTable((Object)new SimpleItem_ParentGroup2(),"sipg2", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SimpleItem_ParentGroup2);
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 2", "Ime skupine 2") );
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.m_SimpleItem_ParentGroup3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 3", "ID skupine artiklov 3") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup2);

        /* 139 */
            t_SimpleItem_ParentGroup1 = new SQLTable((Object)new SimpleItem_ParentGroup1(),"sipg1", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SimpleItem_ParentGroup1);
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 1", "Ime skupine 1") );
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.m_SimpleItem_ParentGroup2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 2", "ID skupine artiklov 2") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup1);

        /* 140 */
            t_Logo = new SQLTable((Object)new Logo(),"logo", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Logo);
            t_Logo.AddColumn((Object)mt.m_Logo.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Logo.AddColumn((Object)mt.m_Logo.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Ident slike") );
            t_Logo.AddColumn((Object)mt.m_Logo.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image", "Slika") );
            t_Logo.AddColumn((Object)mt.m_Logo.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Logo);

        /* 141 */
            t_Atom_Logo = new SQLTable((Object)new Atom_Logo(),"alogo", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Logo);
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Ident slike") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Logo", "Slika logotipa") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Atom_Logo);

        /* 142 */
            t_Atom_cFirstName = new SQLTable((Object)new Atom_cFirstName(),"acfn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cFirstName);
            t_Atom_cFirstName.AddColumn((Object)mt.m_Atom_cFirstName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cFirstName.AddColumn((Object)mt.m_Atom_cFirstName.FirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "First Name", "Ime") );
            m_DBTables.items.Add(t_Atom_cFirstName);
                        
        /* 143 */       
            t_Atom_cLastName = new SQLTable((Object)new Atom_cLastName(),"acln", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cLastName);
            t_Atom_cLastName.AddColumn((Object)mt.m_Atom_cLastName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cLastName.AddColumn((Object)mt.m_Atom_cLastName.LastName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Last Name", "Priimek") );
            m_DBTables.items.Add(t_Atom_cLastName);
                        
        /* 144 */       
            t_Atom_cCardType_Person = new SQLTable((Object)new Atom_cCardType_Person(),"acardtper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cCardType_Person);
            t_Atom_cCardType_Person.AddColumn((Object)mt.m_Atom_cCardType_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCardType_Person.AddColumn((Object)mt.m_Atom_cCardType_Person.CardType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card type", "Vrsta kartice") );
            m_DBTables.items.Add(t_Atom_cCardType_Person);
                        
        /* 145 */       
            t_Atom_cPhoneNumber_Person = new SQLTable((Object)new Atom_cPhoneNumber_Person(),"aphnnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cPhoneNumber_Person);
            t_Atom_cPhoneNumber_Person.AddColumn((Object)mt.m_Atom_cPhoneNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cPhoneNumber_Person.AddColumn((Object)mt.m_Atom_cPhoneNumber_Person.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Phone number", "Telefon") );
            m_DBTables.items.Add(t_Atom_cPhoneNumber_Person);
                        
        /* 146 */       
            t_Atom_cGsmNumber_Person = new SQLTable((Object)new Atom_cGsmNumber_Person(),"agsmnper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cGsmNumber_Person);
            t_Atom_cGsmNumber_Person.AddColumn((Object)mt.m_Atom_cGsmNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cGsmNumber_Person.AddColumn((Object)mt.m_Atom_cGsmNumber_Person.GsmNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "GSM number", "gsm") );
            m_DBTables.items.Add(t_Atom_cGsmNumber_Person);
                        
        /* 147 */       
            t_Atom_cEmail_Person = new SQLTable((Object)new Atom_cEmail_Person(),"aemailper", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_cEmail_Person);
            t_Atom_cEmail_Person.AddColumn((Object)mt.m_Atom_cEmail_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cEmail_Person.AddColumn((Object)mt.m_Atom_cEmail_Person.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card type", "Vrsta kartice") );
            m_DBTables.items.Add(t_Atom_cEmail_Person);
                        
        /* 148 */       
            t_Atom_PersonImage = new SQLTable((Object)new Atom_PersonImage(),"aperimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_PersonImage);
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Identiteta slike") );
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Data", "Slika") );
            m_DBTables.items.Add(t_Atom_PersonImage);


        /* 149 */
            t_Office =  new SQLTable((Object)new Office(),"office", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Office);
            t_Office.AddColumn((Object)mt.m_Office.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Office.AddColumn((Object)mt.m_Office.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Office Name", "Ime poslovne enote") );
            t_Office.AddColumn((Object)mt.m_Office.ShortName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Office Short Name", "Kratko ime"));
            t_Office.AddColumn((Object)mt.m_Office.m_myOrganisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext("My Organisation ID", "Moja oragnizacija ID"));
            m_DBTables.items.Add(t_Office);


        /* 150 */
            t_Atom_Computer = new SQLTable((Object)new Atom_Computer(),"acomp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Computer);
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.m_Atom_ComputerName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer Name ID", "Ime računalnika ID") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.m_Atom_MAC_address, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("MAC address", "MAC naslov ID"));
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.m_Atom_ComputerUserName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer UserName ID", "Računalniško prijavno ime ID") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.m_Atom_IP_address, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "IP address ID", "IP naslov ID") );
            m_DBTables.items.Add(t_Atom_Computer);

        /* 151 */
            t_WorkingPlace  = new SQLTable((Object)new WorkingPlace(),"wp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_WorkingPlace);
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place name", "Ime delovnega mesta") );
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place description", "Opis delovnega mesta") );
            m_DBTables.items.Add(t_WorkingPlace);

        /* 152 */
            t_Atom_Office =  new SQLTable((Object)new Atom_Office(),"aoffice", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Office);
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.m_Atom_myOrganisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "My Organisation archive ID", "Moja oragnizacija arhiv ID") );
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office Name archive", "Ime poslovne enote") );
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.ShortName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Office Short Name", "Kratko Ime poslovne enote"));
            m_DBTables.items.Add(t_Atom_Office);

        /* 153 */
            t_Atom_WorkingPlace  = new SQLTable((Object)new Atom_WorkingPlace(),"awplace", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_WorkingPlace);
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place name", "Ime delovnega mesta") );
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place description", "Opis delovnega mesta") );
            m_DBTables.items.Add(t_Atom_WorkingPlace);

        /* 154 */
            t_Atom_WorkPeriod  = new SQLTable((Object)new Atom_WorkPeriod(),"awperiod", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_WorkPeriod);
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_myOrganisation_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation Person archive ID", "Zaposleni arhiv ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_WorkingPlace, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place archive ID", "Ime delovnega mesta arhiv ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_Computer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer_ID", "Computer_ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_ElectronicDevice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Electronic device ID", "Elektronska naprava ID"));
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.LoginTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work start time", "Začetek dela") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.LogoutTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work end time", "Konec dela") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_WorkPeriod_TYPE, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work end time", "Konec dela") );
            m_DBTables.items.Add(t_Atom_WorkPeriod);

        /* 155 */
            t_DeliveryType  = new SQLTable((Object)new DeliveryType(),"delt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DeliveryType);
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type name", "Vrsta dobave") );
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type description", "Opis vrste dobave") );
            m_DBTables.items.Add(t_DeliveryType);

        /* 156 */
            t_Delivery  = new SQLTable((Object)new Delivery(),"deliv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Delivery);
            t_Delivery.AddColumn((Object)mt.m_Delivery.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_DeliveryType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type ID", "Vrsta dobave ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_Stock, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock ID", "Zaloga ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Račun ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery description", "Dobava opis") );
            m_DBTables.items.Add(t_Delivery);

        /* 157 */
            t_JOURNAL_Delivery_Type = new SQLTable((Object)new JOURNAL_Delivery_Type(),"jdelivt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Delivery_Type);
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type name", "Vrsta dobave") );
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type description", "Vrsta opis") );
            m_DBTables.items.Add(t_JOURNAL_Delivery_Type);

        /* 158 */
            t_JOURNAL_Delivery  = new SQLTable((Object)new JOURNAL_Delivery(),"jdeliv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_JOURNAL_Delivery);
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_JOURNAL_Delivery_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type ID", "Vrsta dobave ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_Delivery, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery ID", "Dobava ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event Time", "Čas dogodka") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Delivery);

        /* 159 */
            t_Office_Data  = new SQLTable((Object)new Office_Data(),"officed", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Office_Data);
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.m_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.ReadOnlyTable, new ltext("Office ID", "Poslovna enota ID"));
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.m_cAddress_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Office address ID", "Poslovna enota naslov ID"));
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Office Description", "Poslovna enota opis"));
            m_DBTables.items.Add(t_Office_Data);

        /* 160 */
            t_Atom_Office_Data = new SQLTable((Object)new Atom_Office_Data(),"aofficed", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_Office_Data);
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.m_Atom_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Office archive ID", "Poslovna enota arhiv ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.m_Atom_cAddress_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office address archive ID", "Poslovna enota naslov arhiv ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office Description", "Poslovna enota opis") );
            m_DBTables.items.Add(t_Atom_Office_Data);

        /* 161 */
            t_Atom_WorkPeriod_TYPE  = new SQLTable((Object)new Atom_WorkPeriod_TYPE(),"awperiodt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_WorkPeriod_TYPE);
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type name", "Naziv vrste šihta") );
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type description", "Naziv vrste šihta opis") );
            m_DBTables.items.Add(t_Atom_WorkPeriod_TYPE);

        /* 162 */
            t_Atom_WorkPeriod_Descrition  = new SQLTable((Object)new Atom_WorkPeriod_Description(),"awperiodd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_Atom_WorkPeriod_Descrition);
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type description", "Naziv vrste šihta opis") );
            m_DBTables.items.Add(t_Atom_WorkPeriod_Descrition);


         /* 163 */
            t_doc_type = new SQLTable((Object)new doc_type(), "doctype", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_doc_type);
            t_doc_type.AddColumn((Object)mt.m_doc_type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type name", "Ime vrste dokumenta"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type description", "Opis vrste dokumenta"));
            m_DBTables.items.Add(t_doc_type);

        /* 164 */
            t_doc = new SQLTable((Object)new doc(), "doc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_doc);
            t_doc.AddColumn((Object)mt.m_doc.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc.AddColumn((Object)mt.m_doc.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document name", "Ime dokumenta"));
            t_doc.AddColumn((Object)mt.m_doc.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document description", "Opis dokumenta"));
            t_doc.AddColumn((Object)mt.m_doc.xDocument, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document", "Dokument"));
            t_doc.AddColumn((Object)mt.m_doc.xDocument_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new ltext("Document HASH", "Dokument HASH"));
            t_doc.AddColumn((Object)mt.m_doc.Active, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Active", "V uporabi"));
            t_doc.AddColumn((Object)mt.m_doc.bDefault, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Default", "Privzeti dokument"));
            t_doc.AddColumn((Object)mt.m_doc.Compressed, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Compressed", "Stisnjen"));
            t_doc.AddColumn((Object)mt.m_doc.m_doc_type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type ID", "Vrsta dokumenta ID"));
            t_doc.AddColumn((Object)mt.m_doc.m_Language, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Language ID", "Jezik ID"));
            t_doc.AddColumn((Object)mt.m_doc.m_doc_page_type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page Type ID", "Oblika strani ID"));
            m_DBTables.items.Add(t_doc);

         /* 165 */
            t_JOURNAL_doc_Type = new SQLTable((Object)new JOURNAL_doc_Type(), "jdoct", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_doc_Type);
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("HTML template event name", "Ime dogodka HTML predloge"));
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("HTML template event description", "Opis dogodka HTML predloge"));
            m_DBTables.items.Add(t_JOURNAL_doc_Type);

        /* 166 */
            t_JOURNAL_doc  = new SQLTable((Object)new JOURNAL_doc(), "jdoc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_doc);
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_JOURNAL_doc_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document event name ID", "Dogodek dokumenta ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_doc, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document ID", "Dokument ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_DocInvoice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Proforma Invoice ID", "(Pred)Račun ID"));
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event Time", "Čas dogodka") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_doc);

        /* 167 */
            t_Language = new SQLTable((Object)new TangentaTableClass.Language(), "lng", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Language);
            t_Language.AddColumn((Object)mt.m_Language.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Language.AddColumn((Object)mt.m_Language.LanguageIndex, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Language Index", "Index jezika"));
            t_Language.AddColumn((Object)mt.m_Language.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Language", "Jezik"));
            t_Language.AddColumn((Object)mt.m_Language.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            t_Language.AddColumn((Object)mt.m_Language.bDefault, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Default", "Privzeti jezik"));
            m_DBTables.items.Add(t_Language);

         /* 168 */
            t_doc_page_type = new SQLTable((Object)new doc_page_type(), "pgt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_doc_page_type);
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page Name", "Ime strani"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page Description", "Opis strani"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Width, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page width (mm)", "Širina strani (mm)"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Height, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page height (mm)", "Višina strani (mm)"));
            m_DBTables.items.Add(t_doc_page_type);


         /* 169 */
            t_FVI_SLO_RealEstateBP = new SQLTable((Object)new FVI_SLO_RealEstateBP(), "fvislore", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_FVI_SLO_RealEstateBP);
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.BuildingNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingNumber", "Številka stavbe"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.BuildingSectionNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingSectionNumber", "Številka dela stavbe"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.Community, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Community", "Naselje"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.CadastralNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("CadastralNumber", "Številka katastrske občine"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ValidityDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ValidityDate", "Datum začetka veljavnosti podatkov"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ClosingTag, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ClosingTag", "ZaprtjePoslovnegaProstora"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.SoftwareSupplier_TaxNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SW supplier tax number", "Davčna številka dobavitelja programske opreme ali vzdrževalca"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.PremiseType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Premise Type", "Vrsta poslovnega prostora"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.m_Office_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.ReadOnlyTable, new ltext("Office Data ID", "Poslovna enota podatki ID"));
            m_DBTables.items.Add(t_FVI_SLO_RealEstateBP);


        /* 170 */
            t_FVI_SLO_Response = new SQLTable((Object)new FVI_SLO_Response(), "fvisloresp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_FVI_SLO_Response); ;
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice ID", "Račun ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.MessageID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Message ID", "Transakcija ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.UniqueInvoiceID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("UniqueInvoiceID", "Enkratna identifikacijska oznaka računa"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.BarCodeValue, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("QR BarCode", "QR bar koda"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.Response_DateTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Response Time", "Čas odgovora"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.TestEnvironment, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Test Environment", "TESTNO OKOLJE"));
            m_DBTables.items.Add(t_FVI_SLO_Response);


        /* 171 */
            t_Atom_FVI_SLO_RealEstateBP = new SQLTable((Object)new Atom_FVI_SLO_RealEstateBP(), "afvislore", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_FVI_SLO_RealEstateBP);
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.m_Atom_Office_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Atom Office Data ID", "Poslovna enota podatki arh ID"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.BuildingNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingNumber", "Številka stavbe"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.BuildingSectionNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingSectionNumber", "Številka dela stavbe"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.Community, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Community", "Naselje"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.CadastralNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("CadastralNumber", "Številka katastrske občine"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.ValidityDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ValidityDate", "Datum začetka veljavnosti podatkov"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.ClosingTag, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ClosingTag", "ZaprtjePoslovnegaProstora"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.SoftwareSupplier_TaxNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SW supplier tax number", "Davčna številka dobavitelja programske opreme ali vzdrževalca"));
            t_Atom_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_Atom_FVI_SLO_RealEstateBP.PremiseType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Premise Type", "Vrsta poslovnega prostora"));
            m_DBTables.items.Add(t_Atom_FVI_SLO_RealEstateBP);

         /* 172 */
            t_Notice = new SQLTable((Object)new Notice(), "notice", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Notice);
            t_Notice.AddColumn((Object)mt.m_Notice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Notice.AddColumn((Object)mt.m_Notice.NoticeText, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Notice text", "Dopis"));
            m_DBTables.items.Add(t_Notice);


         /* 173 */
            t_Atom_ItemShopA_Image = new SQLTable((Object)new Atom_ItemShopA_Image(), "aishaimg", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_ItemShopA_Image);
            t_Atom_ItemShopA_Image.AddColumn((Object)mt.m_Atom_ItemShopA_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_ItemShopA_Image.AddColumn((Object)mt.m_Atom_ItemShopA_Image.m_Atom_ItemShopA, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ShopA Item ID", "Artikel Prodajalne A ID"));
            t_Atom_ItemShopA_Image.AddColumn((Object)mt.m_Atom_ItemShopA_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Image identity", "Identiteta slike"));
            t_Atom_ItemShopA_Image.AddColumn((Object)mt.m_Atom_ItemShopA_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Image", "Slika"));
            t_Atom_ItemShopA_Image.AddColumn((Object)mt.m_Atom_ItemShopA_Image.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Atom_ItemShopA_Image);

            /* 174 */
            t_Atom_ItemShopA = new SQLTable((Object)new Atom_ItemShopA(), "aisha", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_ItemShopA);
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Item Name", "Ime artikla ali storitve"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Item Description", "Opis artikla ali storitve"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Tax ID", "Obdavčitev ID"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.m_Unit, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Unit ID", "Merska enota ID"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.m_Supplier, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Supplier ID", "Dobavitelj ID"));
            t_Atom_ItemShopA.AddColumn((Object)mt.m_Atom_ItemShopA.VisibleForSelection, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Visible for selection", "Vidno za izbor"));
            m_DBTables.items.Add(t_Atom_ItemShopA);

            /* 175 */
            t_DocInvoice_ShopA_Item = new SQLTable((Object)new DocInvoice_ShopA_Item(), "dinvshai", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_DocInvoice_ShopA_Item);
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Proforma invoice ID", "Predračun ID"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.m_Atom_ItemShopA, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Shop A Item ID", "Prodajalna A artikel ID"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Discount", "Popust"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.dQuantity, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Quantity", "Količina"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.PricePerUnit, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Price per unit", "Cena na enoto"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("End price", "Končna cena"));
            t_DocInvoice_ShopA_Item.AddColumn((Object)mt.m_DocInvoice_ShopA_Item.TAX, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TAX", "Davek"));
            m_DBTables.items.Add(t_DocInvoice_ShopA_Item);

            /* 176 */
            t_FVI_SLO_SalesBookInvoice = new SQLTable((Object)new FVI_SLO_SalesBookInvoice(), "fvisbi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_FVI_SLO_SalesBookInvoice);
            t_FVI_SLO_SalesBookInvoice.AddColumn((Object)mt.m_FVI_SLO_SalesBookInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_FVI_SLO_SalesBookInvoice.AddColumn((Object)mt.m_FVI_SLO_SalesBookInvoice.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice ID", "Račun ID"));
            t_FVI_SLO_SalesBookInvoice.AddColumn((Object)mt.m_FVI_SLO_SalesBookInvoice.InvoiceNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice Number ID", "Številka Računa ID"));
            t_FVI_SLO_SalesBookInvoice.AddColumn((Object)mt.m_FVI_SLO_SalesBookInvoice.SetNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Set Number", "Številka posameznega obrazca iz vezane knjige računov"));
            t_FVI_SLO_SalesBookInvoice.AddColumn((Object)mt.m_FVI_SLO_SalesBookInvoice.SerialNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Serial Number", "Serijska številka vezane knjige računov"));
            m_DBTables.items.Add(t_FVI_SLO_SalesBookInvoice);

            /* 177 */
            t_DocProformaInvoice = new SQLTable((Object)new DocProformaInvoice(), "dpinv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DocProformaInvoice);
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.Draft, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Draft", "Osnutek"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.DraftNumber, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Draft Number", "Številka Osnutka"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.FinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Financial Year", "Obračunsko Leto"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.NumberInFinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Number in Financial Year", "Številka v Obračunskem Letu"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.NetSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Net Sum", "Cena brez DDV"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.Discount, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Discount", "Popust"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.EndSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("End Sum", "Cena s popustom"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.TaxSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Tax Sum", "DDV"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.GrossSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Gross Sum", "Cena za plačilo"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.m_Atom_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Currency archive ID", "Valuta arhiv ID"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.m_Atom_Customer_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customer Person archive ID", "Oseba Kupec arhiv ID"));
            t_DocProformaInvoice.AddColumn((Object)mt.m_DocProformaInvoice.m_Atom_Customer_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customer Organisation archive ID", "Kupec Organizacija arhiv ID"));
            m_DBTables.items.Add(t_DocProformaInvoice);

            /* 178 */
            t_DocProformaInvoice_ShopC_Item = new SQLTable((Object)new DocProformaInvoice_ShopC_Item(), "dpinvshci", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_DocProformaInvoice_ShopC_Item);
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext("Selected Quantity", "Izbrana Količina"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Extra Discount", "Dodatni Popust"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.RetailPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("RetailSimpleItemPrice with discount", "Prodajna cena s popustom"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Tax price", "Davek"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.m_DocProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext("Proforma Invoice ID", "Predračun ID"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.m_Atom_Price_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext("Price-Item arh ID", "Cena-Artikel arh ID"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.ExpiryDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext("Expiry Date", "Rok uporabe"));
            t_DocProformaInvoice_ShopC_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopC_Item.m_Stock, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext("Stock ID", "Zaloga ID"));
            m_DBTables.items.Add(t_DocProformaInvoice_ShopC_Item);

            /* 179 */
            t_DocProformaInvoice_ShopB_Item = new SQLTable((Object)new DocProformaInvoice_ShopB_Item(), "dpinvshbi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_DocProformaInvoice_ShopB_Item);
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.RetailSimpleItemPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Retail SimpleItem price", "Cena storitve"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Discount", "Popust"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.iQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Quantity", "Količina"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.RetailSimpleItemPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("RetailSimpleItemPrice with discount", "Prodajna cena s popustom"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Extra Discount", "Dodatni Popust"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Tax price", "Davek"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.m_Atom_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SimpleItem archive ID", "Artikel/Storitev arhiv ID"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.m_Atom_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Price SimpleItem archive ID", "Cenik artikel/storitev arhiv ID"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.m_Atom_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Taxation archive ID", "Obdavćitev arhiv ID"));
            t_DocProformaInvoice_ShopB_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopB_Item.m_DocProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice ID", "Račun ID"));
            m_DBTables.items.Add(t_DocProformaInvoice_ShopB_Item);

            /* 180 */
            t_DocProformaInvoiceAddOn = new SQLTable((Object)new DocProformaInvoiceAddOn(), "dpivao", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_ProformaInvoiceAddOn);
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_DocProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Proforma invoice ID", "Predračun ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.IssueDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Proforma Invoice Time", "Datum predračuna"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_MethodOfPayment_DPI, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Method of payment ID", "Način plačila ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_TermsOfPayment, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Terms of payment ID", "Plačilni pogoji ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_Atom_Warranty, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Warranty archive ID", "Garancija arhiv ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.DocDuration, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Duration", "Veljavnost ponudbe"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.DocDurationType, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Duration Type", "Tip veljavnosti ponudbe"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_Atom_Notice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Notice archive ID", "Dopis arhiv ID"));
            t_DocProformaInvoiceAddOn.AddColumn((Object)mt.m_DocProformaInvoiceAddOn.m_Doc_ImageLib, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Image lib ID", "Slika ID"));
            m_DBTables.items.Add(t_DocProformaInvoiceAddOn);

            /* 181 */
            t_DocProformaInvoice_ShopA_Item = new SQLTable((Object)new DocProformaInvoice_ShopA_Item(), "dpinvshai", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_DocProformaInvoice_ShopA_Item);
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.m_DocProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Proforma invoice ID", "Predračun ID"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.m_Atom_ItemShopA, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Shop A Item ID", "Prodajalna A artikel ID"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Discount", "Popust"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.dQuantity, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Quantity", "Količina"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.PricePerUnit, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Price per unit", "Cena na enoto"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.EndPriceWithDiscountAndTax, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("End price", "Končna cena"));
            t_DocProformaInvoice_ShopA_Item.AddColumn((Object)mt.m_DocProformaInvoice_ShopA_Item.TAX, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TAX", "Davek"));
            m_DBTables.items.Add(t_DocProformaInvoice_ShopA_Item);

            /* 182 */
            t_JOURNAL_myOrganisation_Person_TYPE = new SQLTable((Object)new JOURNAL_myOrganisation_Person_TYPE(), "jmopt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_myOrganisation_Person_TYPE);
            t_JOURNAL_myOrganisation_Person_TYPE.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person_TYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_myOrganisation_Person_TYPE.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person_TYPE.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Name", "Ime"));
            t_JOURNAL_myOrganisation_Person_TYPE.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person_TYPE.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_JOURNAL_myOrganisation_Person_TYPE);

            /* 183 */
            t_JOURNAL_myOrganisation_Person = new SQLTable((Object)new JOURNAL_myOrganisation_Person(), "jmop", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_myOrganisation_Person);
            t_JOURNAL_myOrganisation_Person.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_myOrganisation_Person.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person.m_JOURNAL_myOrganisation_Person_TYPE, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Journal my organisation person ID", "Dogodek osebo moje organizacije ID"));
            t_JOURNAL_myOrganisation_Person.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person.m_myOrganisation_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext(";y organisation person ID", "Oseba moje organizacije ID"));
            t_JOURNAL_myOrganisation_Person.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Event Time", "Čas dogodka"));
            t_JOURNAL_myOrganisation_Person.AddColumn((Object)mt.m_JOURNAL_myOrganisation_Person.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work shift ID", "Šiht ID"));
            m_DBTables.items.Add(t_JOURNAL_myOrganisation_Person);


            /* 184 */
            t_Atom_Bank = new SQLTable((Object)new Atom_Bank(), "ab", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_Bank);
            t_Atom_Bank.AddColumn((Object)mt.m_Atom_Bank.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_Bank.AddColumn((Object)mt.m_Atom_Bank.m_Atom_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Archive Organisation ID", "Arhiv Organizacije ID"));
            m_DBTables.items.Add(t_Atom_Bank);

            /* 185 */
            t_Atom_BankAccount = new SQLTable((Object)new Atom_BankAccount(), "abc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_BankAccount);
            t_Atom_BankAccount.AddColumn((Object)mt.m_Atom_BankAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_BankAccount.AddColumn((Object)mt.m_Atom_BankAccount.m_Atom_Bank,Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Bank ID", "Arhiv Banke ID"));
            t_Atom_BankAccount.AddColumn((Object)mt.m_Atom_BankAccount.Active, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Active", "Aktiven"));
            t_Atom_BankAccount.AddColumn((Object)mt.m_Atom_BankAccount.TRR, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Bank Account", "TRR"));
            t_Atom_BankAccount.AddColumn((Object)mt.m_Atom_BankAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Atom_BankAccount);

            /* 186 */
            t_Atom_OrganisationAccount = new SQLTable((Object)new Atom_OrganisationAccount(), "aoc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_OrganisationAccount);
            t_Atom_OrganisationAccount.AddColumn((Object)mt.m_Atom_OrganisationAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_OrganisationAccount.AddColumn((Object)mt.m_Atom_OrganisationAccount.m_Atom_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Bank Account ID", "Arhiv Bančni račun ID"));
            t_Atom_OrganisationAccount.AddColumn((Object)mt.m_Atom_OrganisationAccount.m_Atom_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Organisation ID", "Arhiv Organizacije ID"));
            t_Atom_OrganisationAccount.AddColumn((Object)mt.m_Atom_OrganisationAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Atom_OrganisationAccount);

            /* 187 */
            t_Atom_PersonData = new SQLTable((Object)new Atom_PersonData(), "apd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_PersonData);
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive person ID", "Arhiv osebe ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_cAddress_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Address Person ID", "Arhiv naslov osebe ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_cCardType_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Card Type ID", "Arhiv vrsta kartice ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.CardNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Card number", "Številka kartice zaupanja"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_cEmail_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive email person ID", "Arhiv e-naslovov osebe ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_cGsmNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive person gsm number ID", "Arhiv gsm številka  osebe ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_cPhoneNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive person phone number ID", "Arhiv tel. številka  osebe ID"));
            t_Atom_PersonData.AddColumn((Object)mt.m_Atom_PersonData.m_Atom_PersonImage, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive person image ID", "Arhiv slika osebe ID"));
            m_DBTables.items.Add(t_Atom_PersonData);

            /* 188 */
            t_Atom_PersonAccount = new SQLTable((Object)new Atom_PersonAccount(), "apa", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_PersonAccount);
            t_Atom_PersonAccount.AddColumn((Object)mt.m_Atom_PersonAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_PersonAccount.AddColumn((Object)mt.m_Atom_PersonAccount.m_Atom_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Bank Account ID", "Arhiv bančni račun ID"));
            t_Atom_PersonAccount.AddColumn((Object)mt.m_Atom_PersonAccount.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Archive Person ID", "Arhiv oseba ID"));
            m_DBTables.items.Add(t_Atom_PersonAccount);

            /* 189 */
            t_JOURNAL_Name = new SQLTable((Object)new JOURNAL_Name(), "jn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_Name);
            t_JOURNAL_Name.AddColumn((Object)mt.m_JOURNAL_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_Name.AddColumn((Object)mt.m_JOURNAL_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("JOURNAL type name", "Ime vrste dogodka"));
            m_DBTables.items.Add(t_JOURNAL_Name);

            /* 190 */
            t_JOURNAL_TableName = new SQLTable((Object)new JOURNAL_TableName(), "jtn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_TableName);
            t_JOURNAL_TableName.AddColumn((Object)mt.m_JOURNAL_TableName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_TableName.AddColumn((Object)mt.m_JOURNAL_TableName.TableName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Table Name", "Ime tabele"));
            m_DBTables.items.Add(t_JOURNAL_TableName);

            /* 191 */
            t_JOURNAL_TYPE = new SQLTable((Object)new JOURNAL_TYPE(), "jt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL_TYPE);
            t_JOURNAL_TYPE.AddColumn((Object)mt.m_JOURNAL_TYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_TYPE.AddColumn((Object)mt.m_JOURNAL_TYPE.m_JOURNAL_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("JOURNAL event Name", "Ime dogodka"));
            t_JOURNAL_TYPE.AddColumn((Object)mt.m_JOURNAL_TYPE.m_JOURNAL_TableName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("JOURNAL TableName ID", "Ime tabele dogodka ID"));
            t_JOURNAL_TYPE.AddColumn((Object)mt.m_JOURNAL_TYPE.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_JOURNAL_TYPE);

            /* 192 */
            t_JOURNAL = new SQLTable((Object)new JOURNAL(), "j", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_JOURNAL);
            t_JOURNAL.AddColumn((Object)mt.m_JOURNAL.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL.AddColumn((Object)mt.m_JOURNAL.m_JOURNAL_TYPE, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Journal type ID", "Vrsta dogodka ID"));
            t_JOURNAL.AddColumn((Object)mt.m_JOURNAL.Table_RowID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Event Table Row ID", "Vrstica tabele dogodka ID"));
            t_JOURNAL.AddColumn((Object)mt.m_JOURNAL.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Event Time", "Čas dogodka"));
            t_JOURNAL.AddColumn((Object)mt.m_JOURNAL.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work shift ID", "Šiht ID"));
            m_DBTables.items.Add(t_JOURNAL);

            /* 193 */
            t_Atom_ElectronicDevice = new SQLTable((Object)new Atom_ElectronicDevice(), "aed", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_ElectronicDevice);
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Electronic Device Name", "Ime elektronske naprave"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.m_Atom_MAC_address, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("MAC Address ID", "MAC naslov ID"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.m_Atom_ComputerName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Computer Name ID", "Ime računalnika ID"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.m_Atom_ComputerUserName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Computer username ID", "Ime 'Windows' uporabnika ID"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.m_FVI_SLO_RealEstateBP, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("MAC Address ID", "MAC naslov ID"));
            t_Atom_ElectronicDevice.AddColumn((Object)mt.m_Atom_ElectronicDevice.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Electronic Device Description", "Opis elektronske naprave"));
            m_DBTables.items.Add(t_Atom_ElectronicDevice);

            /* 194 */
            t_Trucking = new SQLTable((Object)new Trucking(), "trc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Trucking);
            t_Trucking.AddColumn((Object)mt.m_Trucking.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Trucking.AddColumn((Object)mt.m_Trucking.m_Contact, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Contact ID", "Kontakt ID"));
            t_Trucking.AddColumn((Object)mt.m_Trucking.TruckingCost, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Trucking costs", "Transportni stroški"));
            t_Trucking.AddColumn((Object)mt.m_Trucking.TruckingNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Trucking number", "Transportna številka"));
            t_Trucking.AddColumn((Object)mt.m_Trucking.Customs, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customs", "Carina"));
            t_Trucking.AddColumn((Object)mt.m_Trucking.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Trucking);

            /* 195 */
            t_Purchase_Order = new SQLTable((Object)new Purchase_Order(), "po", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Purchase_Order);
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.Purchase_Order_Number, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase Order Number", "Številka Naročilnice Dobavitelju"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.Purchase_Order_Date, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Purchase Order Date", "Datum Naročilnice Dobavitelju"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.m_Supplier, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Supplier ID", "Dobavitelj ID"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.DeliveryTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Delivery Time", "Rok Dobave"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.m_Reference, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Reference ID", "Referenca ID"));
            t_Purchase_Order.AddColumn((Object)mt.m_Purchase_Order.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_Purchase_Order);

            /* 196 */
            t_StockTake = new SQLTable((Object)new StockTake(), "st", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_StockTake);
            t_StockTake.AddColumn((Object)mt.m_StockTake.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Name", "Oznaka"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.StockTake_Date, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker_Now, new ltext("Stock Take Date", "Datum Prevzemnice"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.StockTakePriceTotal, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Stock Take price total", "Skupna cena prevzemnice"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.m_Reference, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Reference ID", "Sklic ID"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.m_Supplier, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Supplier ID", "Dobavitelj ID"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.m_Trucking, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Trucking ID", "Transport ID"));
            t_StockTake.AddColumn((Object)mt.m_StockTake.Draft, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnly_CheckBox_default_true, new ltext("Draft", "Osnutek"));
            m_DBTables.items.Add(t_StockTake);

            /* 197 */
            t_Contact = new SQLTable((Object)new Contact(), "c", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Contact);
            t_Contact.AddColumn((Object)mt.m_Contact.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Contact.AddColumn((Object)mt.m_Contact.m_OrganisationData, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Organisation Data ID", "Organizacija Podatki ID"));
            t_Contact.AddColumn((Object)mt.m_Contact.m_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Person ID", "Oseba ID"));
            m_DBTables.items.Add(t_Contact);

            /* 198 */
            t_StockTake_AdditionalCost = new SQLTable((Object)new StockTake_AdditionalCost(), "stac", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_StockTake_AdditionalCost);
            t_StockTake_AdditionalCost.AddColumn((Object)mt.m_StockTake_AdditionalCost.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_StockTake_AdditionalCost.AddColumn((Object)mt.m_StockTake_AdditionalCost.m_StockTakeCostName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Stock Take Cost Name ID", "Prevzemnica ime stroška ID"));
            t_StockTake_AdditionalCost.AddColumn((Object)mt.m_StockTake_AdditionalCost.Cost, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.NumericUpDown, new ltext("Cost", "Strošek"));
            t_StockTake_AdditionalCost.AddColumn((Object)mt.m_StockTake_AdditionalCost.m_StockTakeCostDescription, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Stock Take Cost Description", "Prevzemnica opis stroška ID"));
            t_StockTake_AdditionalCost.AddColumn((Object)mt.m_StockTake_AdditionalCost.m_StockTake, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("StockTake ID", "Prevzemnica ID"));
            m_DBTables.items.Add(t_StockTake_AdditionalCost);

            /* 199 */
            t_StockTakeCostName = new SQLTable((Object)new StockTakeCostName(), "stcn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_StockTakeCostName);
            t_StockTakeCostName.AddColumn((Object)mt.m_StockTakeCostName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_StockTakeCostName.AddColumn((Object)mt.m_StockTakeCostName.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Name", "Ime"));
            m_DBTables.items.Add(t_StockTakeCostName);

            /* 200 */
            t_StockTakeCostDescription = new SQLTable((Object)new StockTakeCostDescription(), "stcd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_StockTakeCostDescription);
            t_StockTakeCostDescription.AddColumn((Object)mt.m_StockTakeCostDescription.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_StockTakeCostDescription.AddColumn((Object)mt.m_StockTakeCostDescription.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            m_DBTables.items.Add(t_StockTakeCostDescription);

            /* 201 */
            t_PaymentType = new SQLTable((Object)new PaymentType(), "pt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_PaymentType);
            t_PaymentType.AddColumn((Object)mt.m_PaymentType.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_PaymentType.AddColumn((Object)mt.m_PaymentType.Identification, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Payment Type Identification", "Univerzalana oznaka načina plačila"));
            t_PaymentType.AddColumn((Object)mt.m_PaymentType.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Payment Type", "Način plačila"));
            m_DBTables.items.Add(t_PaymentType);


            /* 202 */
            t_MethodOfPayment_DPI = new SQLTable((Object)new MethodOfPayment_DPI(), "mtpdpi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_MethodOfPayment_DPI);
            t_MethodOfPayment_DPI.AddColumn((Object)mt.m_MethodOfPayment_DPI.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_MethodOfPayment_DPI.AddColumn((Object)mt.m_MethodOfPayment_DPI.m_PaymentType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Payment Type ID", "Način plačila ID"));
            t_MethodOfPayment_DPI.AddColumn((Object)mt.m_MethodOfPayment_DPI.m_Atom_BankAccount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BankAccount archive ID", "Bančni račun arhiv ID"));
            m_DBTables.items.Add(t_MethodOfPayment_DPI);

            /* 203 */
            t_Atom_Notice = new SQLTable((Object)new Atom_Notice(), "anotice", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_Notice);
            t_Atom_Notice.AddColumn((Object)mt.m_Notice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_Notice.AddColumn((Object)mt.m_Notice.NoticeText, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Notice text", "Dopis"));
            m_DBTables.items.Add(t_Atom_Notice);

            /* 204 */
            t_Comment1 = new SQLTable((Object)new Comment1(), "cmt1", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Comment1);
            t_Comment1.AddColumn((Object)mt.m_Comment1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Comment1.AddColumn((Object)mt.m_Comment1.Comment, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Comment", "Komentar"));
            m_DBTables.items.Add(t_Comment1);

            /* 205 */
            t_Atom_Comment1 = new SQLTable((Object)new Atom_Comment1(), "acmt1", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_Comment1);
            t_Atom_Comment1.AddColumn((Object)mt.m_Atom_Comment1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_Comment1.AddColumn((Object)mt.m_Atom_Comment1.Comment, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Comment", "Komentar"));
            m_DBTables.items.Add(t_Atom_Comment1);

            /* 206 */
            t_LoginUsers = new SQLTable((Object)new LoginUsers(), "lusr", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginUsers);
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.m_myOrganisation_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("My Organisation Person ID", "Oseba v podjetju ID"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Enabled, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Enabled", "Omogočeno"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.UserName, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("User Name", "Uporabniško ime"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Password, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Password", "Geslo"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.PasswordNeverExpires, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Password never expires", "Geslo nikoli ne poteče"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Time_When_AdministratorSetsPassword, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Time when administrator sets password", "Čas administratorskega nastavitva gesla"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("First time user sets its own password", "Čas prve uporabnikove nastavitva gesla"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Last time user sets its own password", "Čas zadnje uporabnikove nastavitva gesla"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Administrator_LoginUsers_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Administrator LoginUsers ID", "ID administratorskega uporabnika"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.ChangePasswordOnFirstLogin, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Change password on first login", "Zamenjaj geslo ob prvi prijavi"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.Maximum_password_age_in_days, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Maximum password age in days", "Maksimalna starost gesla v dnevih"));
            t_LoginUsers.AddColumn((Object)mt.m_LoginUsers.NotActiveAfterPasswordExpires, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("User not active any more after password expires", "Uporabnik postane neaktiven po preteku gesla"));
            m_DBTables.items.Add(t_LoginUsers);

            /* 207 */
            t_LoginRoles = new SQLTable((Object)new LoginRoles(), "lrol", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginRoles);
            t_LoginRoles.AddColumn((Object)mt.m_LoginRoles.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginRoles.AddColumn((Object)mt.m_LoginRoles.Role, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Access Right", "Pravica"));
            m_DBTables.items.Add(t_LoginRoles);

            /* 208 */
            t_LoginUsersAndLoginRoles = new SQLTable((Object)new LoginUsersAndLoginRoles(), "lusrrol", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginUsersAndLoginRoles);
            t_LoginUsersAndLoginRoles.AddColumn((Object)mt.m_LoginUsersAndLoginRoles.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginUsersAndLoginRoles.AddColumn((Object)mt.m_LoginUsersAndLoginRoles.m_LoginUsers, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("LoginUsers ID", "Uporabnik za prijavo ID"));
            t_LoginUsersAndLoginRoles.AddColumn((Object)mt.m_LoginUsersAndLoginRoles.m_LoginRoles, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("LoginRoles ID", "Seznam pravic ID"));
            m_DBTables.items.Add(t_LoginUsersAndLoginRoles);

            /* 209 */
            t_LoginSession = new SQLTable((Object)new LoginSession(), "lses", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginSession);
            t_LoginSession.AddColumn((Object)mt.m_LoginSession.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginSession.AddColumn((Object)mt.m_LoginSession.m_LoginUsers, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login user ID", "Uporabniško ime ID"));
            t_LoginSession.AddColumn((Object)mt.m_LoginSession.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work period archive ID", "Šiht arhiv ID"));
            m_DBTables.items.Add(t_LoginSession);

            /* 210 */
            t_LoginFailed = new SQLTable((Object)new LoginFailed(), "lfail", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginFailed);
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.AttemptTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Failed login attempt time", "Čas neuspešne prijave"));
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.UserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("User name", "Uporabniško ime"));
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.Password_wrong, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Password wrong", "Napačno geslo"));
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.Username_does_not_exist, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Username does not exist", "Uporabniško ime ne obstaja"));
            t_LoginFailed.AddColumn((Object)mt.m_LoginFailed.m_Atom_Computer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Computer archive ID", "Računalnik arhiv ID"));
            m_DBTables.items.Add(t_LoginFailed);

            /* 211 */
            t_LoginManagerEvent = new SQLTable((Object)new LoginManagerEvent(), "lmevt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginManagerEvent);
            t_LoginManagerEvent.AddColumn((Object)mt.m_LoginManagerEvent.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginManagerEvent.AddColumn((Object)mt.m_LoginManagerEvent.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Login Manager Event Name", "Ime dogodka urejanja prijav uporabnikov"));
            m_DBTables.items.Add(t_LoginManagerEvent);

            /* 212 */
            t_LoginManagerJournal = new SQLTable((Object)new LoginManagerJournal(), "lmj", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginManagerJournal);
            t_LoginManagerJournal.AddColumn((Object)mt.m_LoginManagerJournal.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginManagerJournal.AddColumn((Object)mt.m_LoginManagerJournal.m_LoginUsers, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login user ID", "Uporabnik ID"));
            t_LoginManagerJournal.AddColumn((Object)mt.m_LoginManagerJournal.m_LoginManagerEvent, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login Manager Event ID", "Dogodek urejanja prijav ID"));
            t_LoginManagerJournal.AddColumn((Object)mt.m_LoginManagerJournal.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Event Time", "Čas dogodka"));
            m_DBTables.items.Add(t_LoginManagerJournal);

            /* 213 */
            t_Atom_PriceList_Name  = new SQLTable((Object)new Atom_PriceList_Name(), "apln", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_PriceList_Name);
            t_Atom_PriceList_Name.AddColumn((Object)mt.m_Atom_PriceList_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_PriceList_Name.AddColumn((Object)mt.m_Atom_PriceList_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Price list name", "Ime cenika"));
            m_DBTables.items.Add(t_Atom_PriceList_Name);

            /* 214 */
            t_PriceList_Name = new SQLTable((Object)new PriceList_Name(), "pln", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_PriceList_Name);
            t_PriceList_Name.AddColumn((Object)mt.m_PriceList_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_PriceList_Name.AddColumn((Object)mt.m_PriceList_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Price list name", "Ime cenika"));
            m_DBTables.items.Add(t_PriceList_Name);

            /* 215 */
            t_Atom_ComputerName = new SQLTable((Object)new Atom_ComputerName(), "acn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_ComputerName);
            t_Atom_ComputerName.AddColumn((Object)mt.m_Atom_ComputerName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_ComputerName.AddColumn((Object)mt.m_Atom_ComputerName.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Computer name", "Ime računalnika"));
            t_Atom_ComputerName.AddColumn((Object)mt.m_Atom_ComputerName.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Computer description", "Opis računalnika"));
            m_DBTables.items.Add(t_Atom_ComputerName);


            /* 216 */
            t_Atom_ComputerUserName = new SQLTable((Object)new Atom_ComputerUserName(), "acun", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_ComputerUserName);
            t_Atom_ComputerUserName.AddColumn((Object) mt.m_Atom_ComputerUserName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_ComputerUserName.AddColumn((Object) mt.m_Atom_ComputerUserName.UserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Windows login username", "Prijavno uporabniško ime v operacijski sistemi"));
            t_Atom_ComputerUserName.AddColumn((Object)mt.m_Atom_ComputerUserName.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Windows login username description", "Opis uporabniškega imena v operacijskem sistemu"));
            m_DBTables.items.Add(t_Atom_ComputerUserName);

            /* 217 */
            t_Atom_MAC_address = new SQLTable((Object)new Atom_MAC_address(), "amac", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_MAC_address);
            t_Atom_MAC_address.AddColumn((Object) mt.m_Atom_MAC_address.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_MAC_address.AddColumn((Object) mt.m_Atom_MAC_address.MAC_address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("MAC Address", "MAC naslov"));
            t_Atom_MAC_address.AddColumn((Object)mt.m_Atom_MAC_address.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("MAC Address description", "Opis MAC Naslova"));
            m_DBTables.items.Add(t_Atom_MAC_address);

            /* 218 */
            t_CaseItem = new SQLTable((Object)new CaseItem(), "casei", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_CaseItem);
            t_CaseItem.AddColumn((Object) mt.m_CaseItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_CaseItem.AddColumn((Object) mt.m_CaseItem.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case name", "Ime zadeve"));
            t_CaseItem.AddColumn((Object)mt.m_CaseItem.StartDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case start", "Začetek zadeve "));
            t_CaseItem.AddColumn((Object)mt.m_CaseItem.EndDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case end", "Konec zadeve"));
            t_CaseItem.AddColumn((Object)mt.m_CaseItem.CaseParameter, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case parameter", "Parameter zadeve"));
            t_CaseItem.AddColumn((Object)mt.m_CaseItem.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case Description", "Opis zadeve"));
            m_DBTables.items.Add(t_CaseItem);

            /* 219 */
            t_CaseImage = new SQLTable((Object)new CaseImage(), "ci", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_CaseImage);
            t_CaseImage.AddColumn((Object) mt.m_CaseImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_CaseImage.AddColumn((Object)mt.m_CaseImage.m_CustomerCase, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Customer case ID", "Stranka zadeva ID"));
            t_CaseImage.AddColumn((Object) mt.m_CaseImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case Image HASH", "Slika zadeve ident."));
            t_CaseImage.AddColumn((Object)mt.m_CaseImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case Image", "Slika zadeve"));
            m_DBTables.items.Add(t_CaseImage);

            /* 220 */
            t_CustomerCase = new SQLTable((Object)new CustomerCase(), "cc", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_CustomerCase);
            t_CustomerCase.AddColumn((Object) mt.m_CustomerCase.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_CustomerCase.AddColumn((Object)mt.m_CustomerCase.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Person ID", "Oseba ID")); 
            t_CustomerCase.AddColumn((Object)mt.m_CustomerCase.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Organisation ID", "Organiazcija ID"));
            t_CustomerCase.AddColumn((Object)mt.m_CustomerCase.EntryTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case Entry Time", "Čas vnosa zadeve"));
            t_CustomerCase.AddColumn((Object) mt.m_CustomerCase.m_CaseItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case ID", "Zadeva ID"));
            t_CustomerCase.AddColumn((Object) mt.m_CustomerCase.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case description", "Opis zadeve"));
            m_DBTables.items.Add(t_CustomerCase);

            /* 221 */
            t_CaseParameter = new SQLTable((Object)new CaseParameter(), "cp", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_CaseParameter);
            t_CaseParameter.AddColumn((Object)mt.m_CaseParameter.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_CaseParameter.AddColumn((Object)mt.m_CaseParameter.ParameterValue, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter value", "Vrednost parametra"));
            t_CaseParameter.AddColumn((Object)mt.m_CaseParameter.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Case description", "Opis zadeve"));
            m_DBTables.items.Add(t_CaseParameter);

            /* 222 */
            t_SettingsType = new SQLTable((Object)new SettingsType(), "sett", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_SettingsType);
            t_SettingsType.AddColumn((Object)mt.m_SettingsType.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_SettingsType.AddColumn((Object)mt.m_SettingsType.Typ, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings Type", "Podatkovni tip nastavitvenega parametra"));
            t_SettingsType.AddColumn((Object)mt.m_SettingsType.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings Type description", "Opis tipa nastavitvenega parametra"));
            m_DBTables.items.Add(t_SettingsType);

            /* 223 */
            t_SettingsValue = new SQLTable((Object)new SettingsValue(), "setv", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_SettingsValue);
            t_SettingsValue.AddColumn((Object)mt.m_SettingsValue.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_SettingsValue.AddColumn((Object)mt.m_SettingsValue.SettingsVal, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings Value", " Vrednost nastavitvenega parametra"));
            m_DBTables.items.Add(t_SettingsValue);

            /* 224 */
            t_ProgramModule = new SQLTable((Object)new ProgramModule(), "pm", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_ProgramModule);
            t_ProgramModule.AddColumn((Object) mt.m_ProgramModule.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_ProgramModule.AddColumn((Object) mt.m_ProgramModule.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Program Module", "Ime programskega modula"));
            t_ProgramModule.AddColumn((Object) mt.m_ProgramModule.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Program Module description", "Opis programskega modula"));
            m_DBTables.items.Add(t_ProgramModule);

            /* 225 */
            t_PropertiesSettings = new SQLTable((Object)new PropertiesSettings(), "ps", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_PropertiesSettings);
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.m_Atom_ElectronicDevice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Electronic Device ID", "Elektronska naprava ID"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.m_ProgramModule, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Program Module ID", "Programski modul ID"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings Name", "Ime nastavitve"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.m_SettingsType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings data type ID", "Podatkovni tip nastavitve ID"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.m_SettingsValue, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings value ID", "Vrednost nastavitve ID"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.TestEnvironment, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Test Environment", "Testno okolje"));
            t_PropertiesSettings.AddColumn((Object) mt.m_PropertiesSettings.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Settings description", "Opis nastavitve"));
            m_DBTables.items.Add(t_PropertiesSettings);

            /* 226 */
            t_LoginTag_TYPE = new SQLTable((Object)new LoginTag_TYPE(), "ltt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginTag_TYPE);
            t_LoginTag_TYPE.AddColumn((Object) mt.m_LoginTag_TYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginTag_TYPE.AddColumn((Object) mt.m_LoginTag_TYPE.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login type", "Način prijave"));
            t_LoginTag_TYPE.AddColumn((Object) mt.m_LoginTag_TYPE.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login type description", "Opis načina prijave"));
            m_DBTables.items.Add(t_LoginTag_TYPE);

            /* 227 */
            t_LoginTag = new SQLTable((Object)new LoginTag(), "lt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_LoginTag);
            t_LoginTag.AddColumn((Object) mt.m_LoginTag.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_LoginTag.AddColumn((Object) mt.m_LoginTag.m_LoginUsers, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login user  account ID", "Upirabniški račun ID"));
            t_LoginTag.AddColumn((Object) mt.m_LoginTag.m_LoginTag_TYPE, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login type ID", "Način prijave"));
            t_LoginTag.AddColumn((Object) mt.m_LoginTag.LoginKeyValue, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Login key", "Prijavni ključ"));
            m_DBTables.items.Add(t_LoginTag);

            /* 227 */
            t_WorkAreaImage = new SQLTable((Object)new WorkAreaImage(), "wai", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_WorkAreaImage);
            t_WorkAreaImage.AddColumn((Object)mt.m_WorkAreaImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_WorkAreaImage.AddColumn((Object)mt.m_WorkAreaImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area image", "Slika delovnega področja"));
            t_WorkAreaImage.AddColumn((Object)mt.m_WorkAreaImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Image identification", "Ident. slike"));
            t_WorkAreaImage.AddColumn((Object)mt.m_WorkAreaImage.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area image description", "Opis slike delovnega področja"));
            m_DBTables.items.Add(t_WorkAreaImage);

            /* 229 */
            t_WorkArea = new SQLTable((Object)new WorkArea(), "wa", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_WorkArea);
            t_WorkArea.AddColumn((Object) mt.m_WorkArea.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_WorkArea.AddColumn((Object) mt.m_WorkArea.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area name", "Ime delovnega področja"));
            t_WorkArea.AddColumn((Object) mt.m_WorkArea.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area desription", "Opis delovnega področja"));
            t_WorkArea.AddColumn((Object)mt.m_WorkArea.Active, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area active", "Delovno področje je aktivno"));
            t_WorkArea.AddColumn((Object) mt.m_WorkArea.m_WorkAreaImage, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area image ID", "Slika delovnega področja ID"));
            m_DBTables.items.Add(t_WorkArea);

            /* 230 */
            t_WorkAreaDocInvoice = new SQLTable((Object)new WorkAreaDocInvoice(), "wadi", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_WorkAreaDocInvoice);
            t_WorkAreaDocInvoice.AddColumn((Object) mt.m_WorkAreaDocInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_WorkAreaDocInvoice.AddColumn((Object) mt.m_WorkAreaDocInvoice.m_DocInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("DocInvoice ID", "Račun ID"));
            t_WorkAreaDocInvoice.AddColumn((Object) mt.m_WorkAreaDocInvoice.m_WorkArea, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Work area ID", "Delovno področje ID"));
            m_DBTables.items.Add(t_WorkAreaDocInvoice);

            /* 231 */
            t_Atom_IP_address = new SQLTable((Object)new Atom_IP_address(), "aipa", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_t_Atom_IP_address);
            t_Atom_IP_address.AddColumn((Object)mt.m_Atom_IP_address.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Atom_IP_address.AddColumn((Object)mt.m_Atom_IP_address.IP_address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("IP address", "IP naslov"));
            t_Atom_IP_address.AddColumn((Object)mt.m_Atom_IP_address.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("IP description", "IP opis"));
            m_DBTables.items.Add(t_Atom_IP_address);
        }
    }
 }

