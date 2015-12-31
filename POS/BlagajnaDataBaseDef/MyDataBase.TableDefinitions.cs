using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DBConnectionControl40;
using BlagajnaTableClass;
using SQLTableControl;
using LanguageControl;

namespace BlagajnaDataBaseDef
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
        public Settings_Item LastInvoiceType = null;
        public Settings_Item StockCheckAtStartup = null;

        public Settings(string Ver)
        {
            Version = new Settings_Item("Version",Ver,true);
            LastInvoiceType = new Settings_Item("LastInvoiceType", "Invoice", true);
            Version = new Settings_Item("Version", Ver, true);
            StockCheckAtStartup = new Settings_Item("StockCheckAtStartup", "1", true);
        }

    }
    partial class MyDataBase_Blagajna
    {
        public const string VERSION = "1.10";
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
        public SQLTable t_cState_Person = null;
        /* 11 */
        public SQLTable t_cCountry_Person = null;
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
        public SQLTable t_cState_Org = null;
        /* 18 */
        public SQLTable t_cCountry_Org = null;
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
        public SQLTable t_myCompany = null;
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
        public SQLTable t_MethodOfPayment = null;
        /* 32 */
        public SQLTable t_Invoice = null;
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
        public SQLTable t_ProformaInvoice = null;
        /* 46 */
        public SQLTable t_ProformaInvoice_Image = null;
        /* 47 */
        public SQLTable t_ProformaInvoice_ImageLib = null;
        /* 48 */
        public SQLTable t_Invoice_Image = null;
        /* 49 */
        public SQLTable t_TermsOfPayment = null;
        /* 50 */
        public SQLTable t_myCompany_Person = null;
        /* 51 */
        public SQLTable t_Atom_ProformaInvoice_Price_Item_Stock = null;
        /* 52 */
        public SQLTable t_Atom_myCompany_Person = null;
        /* 53 */
        public SQLTable t_Atom_myCompany = null;
        /* 54 */
        public SQLTable t_Atom_Person = null;
        /* 55 */
        public SQLTable t_Atom_Organisation = null;
        /* 56 */
        public SQLTable t_SimpleItem_Image = null;
        /* 57 */
        public SQLTable t_Item_Image = null;
        /* 58 */
        public SQLTable t_Expiry = null;
        /* 59 */
        public SQLTable t_Warranty = null;
        /* 60 */
        public SQLTable t_Atom_Expiry = null;
        /* 61 */
        public SQLTable t_Atom_Warranty = null;
        /* 62 */
        public SQLTable t_Item_ParentGroup3 = null;
        /* 63 */
        public SQLTable t_Item_ParentGroup2 = null;
        /* 64 */
        public SQLTable t_Item_ParentGroup1 = null;
        /* 65 */
        public SQLTable t_Stock_AddressLevel3 = null;
        /* 66 */
        public SQLTable t_Stock_AddressLevel2 = null;
        /* 67 */
        public SQLTable t_Stock_AddressLevel1 = null;
        /* 68 */
        public SQLTable t_Atom_cStreetName_Person = null;
        /* 69 */
        public SQLTable t_Atom_cHouseNumber_Person = null;

        /* 70 */
        public SQLTable t_Atom_cCity_Person = null;

        /* 71 */
        public SQLTable t_Atom_cZIP_Person = null;

        /* 72 */
        public SQLTable t_Atom_cState_Person = null;

        /* 73 */
        public SQLTable t_Atom_cCountry_Person = null;

        /* 74 */
        public SQLTable t_Atom_cStreetName_Org = null;

        /* 75 */
        public SQLTable t_Atom_cHouseNumber_Org = null;

        /* 76 */
        public SQLTable t_Atom_cCity_Org  = null;

        /* 77 */
        public SQLTable t_Atom_cZIP_Org  = null;

        /* 78 */
        public SQLTable t_Atom_cState_Org = null;

        /* 79 */
        public SQLTable t_Atom_cCountry_Org = null;

        /* 80 */
        public SQLTable t_cAddress_Person = null;

        /* 81 */
        public SQLTable t_cAddress_Org = null;

        /* 82 */
        public SQLTable t_Atom_cAddress_Person = null;

        /* 83 */
        public SQLTable t_Atom_cAddress_Org = null;

        /* 84 */
        public SQLTable t_Price_Item = null;

        /* 85 */
        public SQLTable t_Price_SimpleItem = null;

        /* 86 */
        public SQLTable t_PriceList = null;

        /* 87 */
        public SQLTable t_Currency = null;

        /* 88 */
        public SQLTable t_BaseCurrency = null;

        /* 89 */
        public SQLTable t_RateToBaseCurrency = null;

        /* 90 */
        public SQLTable t_ExchangeRateSource = null;

        /* 91 */
        public SQLTable t_Atom_PriceList = null;

        /* 92 */
        public SQLTable t_PurchasePrice_Item = null;

        /* 93 */
        public SQLTable t_Atom_Currency = null;

        /* 94 */
        public SQLTable t_Atom_Price_Item = null;

        /* 95 */
        public SQLTable t_Atom_Price_SimpleItem = null;

        /* 96 */
        public SQLTable t_PersonImage = null;

        /* 97 */
        public SQLTable t_Unit = null;

        /* 98 */
        public SQLTable t_Atom_Unit = null;

        /* 99 */
        public SQLTable t_AccessRights = null;

        /* 100 */
        public SQLTable t_myCompany_Person_AccessRights = null;

        /* 101 */
        public SQLTable t_OrganisationData = null;

        /* 102 */
        public SQLTable t_PurchasePrice = null;

        /* 103 */
        public SQLTable t_Reference_Image = null;

        /* 104 */
        public SQLTable t_Atom_OrganisationData = null;

        /* 105 */
        public SQLTable t_Supplier = null;

        /* 106 */
        public SQLTable t_Customer_Org = null;

        /* 107 */
        public SQLTable t_Customer_Person = null;

        /* 108 */
        public SQLTable t_Atom_Customer_Org = null;

        /* 109 */
        public SQLTable t_Atom_Customer_Person = null;

        /* 110 */
        public SQLTable t_PersonData = null;

        /* 111 */
        public SQLTable t_PersonAccount = null;

        /* 112 */
        public SQLTable t_Bank = null;

        /* 113 */
        public SQLTable t_BankAccount = null;

        /* 114 */
        public SQLTable t_OrganisationAccount = null;

        /* 115 */
        public SQLTable t_JOURNAL_Invoice_Type = null;

        /* 116 */
        public SQLTable t_JOURNAL_PriceList_Type = null; 

        /* 117 */
        public SQLTable t_JOURNAL_ProformaInvoice_Type = null;

        /* 118 */
        public SQLTable t_JOURNAL_Item_Type = null;

        /* 119 */
        public SQLTable t_JOURNAL_SimpleItem_Type = null;

        /* 120 */
        public SQLTable t_JOURNAL_myCompany_Type = null;

        /* 121 */
        public SQLTable t_JOURNAL_myCompany_Person_Type = null;

        /* 122 */
        public SQLTable t_JOURNAL_Customer_Person_Type = null;

        /* 123 */
        public SQLTable t_JOURNAL_Customer_Org_Type = null;

        /* 124 */
        public SQLTable t_JOURNAL_PurchasePrice_Type = null;

        /* 125 */
        public SQLTable t_JOURNAL_Taxation_Type = null;

        /* 126 */
        public SQLTable t_JOURNAL_Stock_Type = null;

        /* 127 */
        public SQLTable t_JOURNAL_Invoice = null;

        /* 128 */
        public SQLTable t_JOURNAL_ProformaInvoice = null;

        /* 129 */
        public SQLTable t_JOURNAL_Item = null;

        /* 130 */
        public SQLTable t_JOURNAL_SimpleItem = null;

        /* 131 */
        public SQLTable t_JOURNAL_PriceList = null;

        /* 132 */
        public SQLTable t_JOURNAL_myCompany = null;

        /* 133 */
        public SQLTable t_JOURNAL_Person = null;

        /* 134 */
        public SQLTable t_JOURNAL_Customer_Person = null;

        /* 135 */
        public SQLTable t_JOURNAL_Customer_Person_Data = null;

        /* 136 */
        public SQLTable t_JOURNAL_Customer_Person_Data_Image = null;

        /* 137 */
        public SQLTable t_JOURNAL_Customer_Org = null;

        /* 138 */
        public SQLTable t_JOURNAL_PurchasePrice = null;

        /* 139 */
        public SQLTable t_JOURNAL_Taxation = null;

        /* 140 */
        public SQLTable t_JOURNAL_Stock = null;

        /* 141 */
        public SQLTable t_SimpleItem_ParentGroup3 = null;

        /* 142 */
        public SQLTable t_SimpleItem_ParentGroup2 = null;

        /* 143 */
        public SQLTable t_SimpleItem_ParentGroup1 = null;

        /* 144 */
        public SQLTable t_Logo = null;

        /* 145 */
        public SQLTable t_Atom_Logo = null;

        /* 146 */
        public SQLTable t_Atom_cFirstName = null;
                        
        /* 147 */       
        public SQLTable t_Atom_cLastName = null;
                        
        /* 148 */       
        public SQLTable t_Atom_cCardType_Person = null;
                        
        /* 149 */       
        public SQLTable t_Atom_cPhoneNumber_Person = null;
                        
        /* 150 */       
        public SQLTable t_Atom_cGsmNumber_Person = null;
                        
        /* 151 */       
        public SQLTable t_Atom_cEmail_Person = null;
                        
        /* 152 */       
        public SQLTable t_Atom_PersonImage = null;

        /* 153 */
        public SQLTable t_Office = null;

        /* 154 */
        public SQLTable t_Atom_Computer = null;

        /* 155 */
        public SQLTable t_WorkingPlace = null;

        /* 156 */
        public SQLTable t_Atom_Office = null;

        /* 157 */
        public SQLTable t_Atom_WorkingPlace = null;

        /* 158 */
        public SQLTable t_Atom_WorkPeriod = null;

        /* 159 */
        public SQLTable t_DeliveryType = null;

        /* 160 */
        public SQLTable t_Delivery = null;

        /* 161 */
        public SQLTable t_JOURNAL_Delivery_Type = null;

        /* 162 */
        public SQLTable t_JOURNAL_Delivery = null;

         /* 163 */
        public SQLTable t_Office_Data = null;

        /* 164 */
        public SQLTable t_Atom_Office_Data = null;

        /* 165 */
        public SQLTable t_Atom_WorkPeriod_TYPE = null;

        /* 166 */
        public SQLTable t_Atom_WorkPeriod_Descrition = null;

        /* 167 */
        public SQLTable t_doc_type = null;

        /* 168 */
        public SQLTable t_doc = null;

        /* 169 */
        public SQLTable t_JOURNAL_doc_Type = null;

        /* 170 */
        public SQLTable t_JOURNAL_doc = null;

        /* 171 */
        public SQLTable t_Language = null;

        /* 172 */
        public SQLTable t_doc_page_type = null;

        /* 173 */
        public SQLTable t_FVI_SLO_RealEstateBP = null;

        /* 174 */
        public SQLTable t_FVI_SLO_Response = null;



        public void Define_SQL_Database_Tables() // constructor;
        {
            Settings = new Settings(VERSION);

            /* 1 */
            t_cFirstName = new SQLTable((Object)new cFirstName(),"cfn", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cFirstName);
            t_cFirstName.AddColumn((Object)mt.m_cFirstName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cFirstName.AddColumn((Object)mt.m_cFirstName.FirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "First Name", "Ime") );
            m_DBTables.items.Add(t_cFirstName);

            /* 2 */
            t_cLastName = new SQLTable((Object)new cLastName(),"cln", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cLastName);
            t_cLastName.AddColumn((Object)mt.m_cLastName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cLastName.AddColumn((Object)mt.m_cLastName.LastName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Last Name", "Priimek") );
            m_DBTables.items.Add(t_cLastName);

            /* 3 */
            t_cPhoneNumber_Person = new SQLTable((Object)new cPhoneNumber_Person(),"cphnnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cPhoneNumber_Person);
            t_cPhoneNumber_Person.AddColumn((Object)mt.m_cPhoneNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cPhoneNumber_Person.AddColumn((Object)mt.m_cPhoneNumber_Person.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Phone Number", "Številka telefona") );
            m_DBTables.items.Add(t_cPhoneNumber_Person);

            /* 4 */
            t_cGsmNumber_Person = new SQLTable((Object)new cGsmNumber_Person(),"cgsmnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cGsmNumber_Person);
            t_cGsmNumber_Person.AddColumn((Object)mt.m_cGsmNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cGsmNumber_Person.AddColumn((Object)mt.m_cGsmNumber_Person.GsmNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "GSM:", "GSM:") );
            m_DBTables.items.Add(t_cGsmNumber_Person);

            /* 5 */
            t_cEmail_Person = new SQLTable((Object)new cEmail_Person(),"cemailper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cEmail_Person);
            t_cEmail_Person.AddColumn((Object)mt.m_cEmail_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cEmail_Person.AddColumn((Object)mt.m_cEmail_Person.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Email", "Elektronski naslov (Email)") );
            m_DBTables.items.Add(t_cEmail_Person);

            /* 6 */
            t_cZIP_Person = new SQLTable((Object)new cZIP_Person(),"zipper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cZIP_Person);
            t_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_cZIP_Person);

            /* 7 */
            t_cStreetName_Person = new SQLTable((Object)new cStreetName_Person(),"cstrnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cStreetName_Person);
            t_cStreetName_Person.AddColumn((Object)mt.m_cStreetName_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cStreetName_Person.AddColumn((Object)mt.m_cStreetName_Person.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Street Name", "Ime ceste/ulice") );
            m_DBTables.items.Add(t_cStreetName_Person);

            /* 8 */
            t_cHouseNumber_Person = new SQLTable((Object)new cHouseNumber_Person(),"chounper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cHouseNumber_Person);
            t_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_cHouseNumber_Person);

            /* 9 */
            t_cCity_Person = new SQLTable((Object)new cCity_Person(),"ccitper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCity_Person);
        
            t_cCity_Person.AddColumn((Object)mt.m_cCity_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCity_Person.AddColumn((Object)mt.m_cCity_Person.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "City", "Mesto") );
            m_DBTables.items.Add(t_cCity_Person);

            /* 10 */
            t_cState_Person = new SQLTable((Object)new cState_Person(),"cstper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cState_Person);
            t_cState_Person.SetInputControls = m_ISO_3166_Table.SetInputControls;
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "State", "Država") );
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.State_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a2", "ISO_3166 a2"));
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.State_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_cState_Person.AddColumn((Object)mt.m_cState_Person.State_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_cState_Person);

            /* 11 */
            t_cCountry_Person = new SQLTable((Object)new cCountry_Person(),"ccouper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCountry_Person);
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCountry_Person.AddColumn((Object)mt.m_cCountry_Person.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Country", "Dežela") );
            m_DBTables.items.Add(t_cCountry_Person);

            /* 12 */
            t_Person = new SQLTable((Object)new Person(),"per", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_BuyerPerson);
            t_Person.AddColumn((Object)mt.m_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Person.AddColumn((Object)mt.m_Person.Gender, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.RadioButtons, new ltext( "Gender:Female/Male", "Spol:Ženska/Moški") );
            t_Person.AddColumn((Object)mt.m_Person.m_cFirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "First Name ID", "Ime ID") );
            t_Person.AddColumn((Object)mt.m_Person.m_cLastName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Last Name ID", "Priimek ID") );
            t_Person.AddColumn((Object)mt.m_Person.DateOfBirth, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Date of Birth", "Datum Rojstva") );
            t_Person.AddColumn((Object)mt.m_Person.Tax_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax number", "Davčna številka") );
            t_Person.AddColumn((Object)mt.m_Person.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Registration number", "Matična številka") );
            m_DBTables.items.Add(t_Person);

            /* 13 */
            t_cOrgTYPE = new SQLTable((Object)new cOrgTYPE(),"orgt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cOrgType);
            t_cOrgTYPE.AddColumn((Object)mt.m_cOrgTYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cOrgTYPE.AddColumn((Object)mt.m_cOrgTYPE.OrganisationTYPE, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Organisation Type", "Vrsta organizacije") );
            m_DBTables.items.Add(t_cOrgTYPE);


            /* 14 */
            t_cStreetName_Org = new SQLTable((Object)new cStreetName_Org(),"cstrnorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cOrgType);
            t_cStreetName_Org.AddColumn((Object)mt.m_cStreetName_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cStreetName_Org.AddColumn((Object)mt.m_cStreetName_Org.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street Name", "Ime ulice") );
            m_DBTables.items.Add(t_cStreetName_Org);

            /* 15 */
            t_cHouseNumber_Org = new SQLTable((Object)new cHouseNumber_Org(),"chounorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cHouseNumber_Org);
            t_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna Številka") );
            m_DBTables.items.Add(t_cHouseNumber_Org);


            /* 16 */
            t_cCity_Org = new SQLTable((Object)new cCity_Org(),"ccitorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCity_Org);
            t_cCity_Org.AddColumn((Object)mt.m_cCity_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCity_Org.AddColumn((Object)mt.m_cCity_Org.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "City", "Mesto") );
            m_DBTables.items.Add(t_cCity_Org);

            /* 17 */
            t_cState_Org = new SQLTable((Object)new cState_Org(),"cstorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cState_Org);
            t_cState_Org.SetInputControls = m_ISO_3166_Table.SetInputControls;
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "State", "Država") );
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.State_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a2", "ISO_3166 a2"));
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.State_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_cState_Org.AddColumn((Object)mt.m_cState_Org.State_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_cState_Org);

            /* 18 */
            t_cCountry_Org = new SQLTable((Object)new cCountry_Org(),"ccouorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCountry_Org);
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCountry_Org.AddColumn((Object)mt.m_cCountry_Org.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Country", "Dežela") );
            m_DBTables.items.Add(t_cCountry_Org);

            /* 19 */
            t_cZIP_Org = new SQLTable((Object)new cZIP_Org(),"cziporg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cZIP_Org);
            t_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Št. Pošte") );
            m_DBTables.items.Add(t_cZIP_Org);

            /* 20 */
            t_cPhoneNumber_Org = new SQLTable((Object)new cPhoneNumber_Org(),"cphnnorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cPhoneNumber_Org);
            t_cPhoneNumber_Org.AddColumn((Object)mt.m_cPhoneNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cPhoneNumber_Org.AddColumn((Object)mt.m_cPhoneNumber_Org.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Phone Number", "Številka telefona") );
            m_DBTables.items.Add(t_cPhoneNumber_Org);

            /* 21 */
            t_cFaxNumber_Org = new SQLTable((Object)new cFaxNumber_Org(),"cfaxnorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cFaxNumber_Org);
            t_cFaxNumber_Org.AddColumn((Object)mt.m_cFaxNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cFaxNumber_Org.AddColumn((Object)mt.m_cFaxNumber_Org.FaxNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Fax Number", "Številka Faksa") );
            m_DBTables.items.Add(t_cFaxNumber_Org);

            /* 22 */
            t_cEmail_Org = new SQLTable((Object)new cEmail_Org(),"cemailorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cEmail_Org);
            t_cEmail_Org.AddColumn((Object)mt.m_cEmail_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cEmail_Org.AddColumn((Object)mt.m_cEmail_Org.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Email", "Elektronski naslov (Email)") );
            m_DBTables.items.Add(t_cEmail_Org);

            /* 23 */
            t_cHomePage_Org = new SQLTable((Object)new cHomePage_Org(),"chomepgorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cHomePage_Org);
            t_cHomePage_Org.AddColumn((Object)mt.m_cHomePage_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cHomePage_Org.AddColumn((Object)mt.m_cHomePage_Org.HomePage, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "HomePage", "Domača stran") );
            m_DBTables.items.Add(t_cHomePage_Org);


            /* 24 */
            t_Organisation = new SQLTable((Object)new Organisation(),"org", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Organisation);
            t_Organisation.AddColumn((Object)mt.m_Organisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation name", "Ime Firme") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Tax_ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "TAX ID", "Davčna številka") );
            t_Organisation.AddColumn((Object)mt.m_Organisation.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "REGISTRATION ID", "Matična številka") );
            m_DBTables.items.Add(t_Organisation);

            /* 25 */
            t_myCompany = new SQLTable((Object)new myCompany(),"mc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_myCompany);
            t_myCompany.AddColumn((Object)mt.m_myCompany.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_myCompany.AddColumn((Object)mt.m_myCompany.m_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation data ID", "Organizacija podatki ID") );
            m_DBTables.items.Add(t_myCompany);

            /* 26 */
            t_Reference = new SQLTable((Object)new Reference(),"ref", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Reference);
            t_Reference.AddColumn((Object)mt.m_Reference.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Reference.AddColumn((Object)mt.m_Reference.ReferenceNote, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Reference", "Sklic") );
            t_Reference.AddColumn((Object)mt.m_Reference.m_Reference_Image, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Document Image", "Slika dokumenta") );
            m_DBTables.items.Add(t_Reference);

            /* 27 */
            t_Item = new SQLTable((Object)new Item(),"i", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ItemName);
            t_Item.AddColumn((Object)mt.m_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item.AddColumn((Object)mt.m_Item.Code, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item Code", "Št.Artikla") );
            t_Item.AddColumn((Object)mt.m_Item.UniqueName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unique Item Name", "Unikatni Naziv Artikla") );
            t_Item.AddColumn((Object)mt.m_Item.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item Name", "Ime Artikla") );
            t_Item.AddColumn((Object)mt.m_Item.m_Item_ParentGroup1, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "ID item group 1", "ID skupine artiklov 1") );
            t_Item.AddColumn((Object)mt.m_Item.m_Unit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Unit ID", "Enota ID") );
            t_Item.AddColumn((Object)mt.m_Item.barcode, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item barcode", "črtna koda") );
            t_Item.AddColumn((Object)mt.m_Item.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_Item.AddColumn((Object)mt.m_Item.m_Item_Image, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item Image ID", "Slika Artikla ID") );
            t_Item.AddColumn((Object)mt.m_Item.m_Expiry, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry ID", "Rok uporabe ID") );
            t_Item.AddColumn((Object)mt.m_Item.m_Warranty, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty ID", "Garancija ID") );
            t_Item.AddColumn((Object)mt.m_Item.ToOffer, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.ReadOnly_CheckBox_default_true, new ltext( "To offer", "V ponudbi") );
            m_DBTables.items.Add(t_Item);

            /* 28 */
            t_Taxation = new SQLTable((Object)new Taxation(),"tax", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Taxation);
            t_Taxation.AddColumn((Object)mt.m_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Taxation.AddColumn((Object)mt.m_Taxation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Name", "Ime") );
            t_Taxation.AddColumn((Object)mt.m_Taxation.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Rate", "Stopnja") );
            m_DBTables.items.Add(t_Taxation);

            /* 29 */
            t_Stock = new SQLTable((Object)new Stock(),"stock", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Stock);
            t_Stock.AddColumn((Object)mt.m_Stock.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock.AddColumn((Object)mt.m_Stock.ImportTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker_Now, new ltext( "Import time", "Čas vnosa") );
            t_Stock.AddColumn((Object)mt.m_Stock.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Quantity in Stok", "Količina na zalogi") );
            t_Stock.AddColumn((Object)mt.m_Stock.ExpiryDate, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry Date", "Rok uporabe") );
            t_Stock.AddColumn((Object)mt.m_Stock.m_PurchasePrice_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Purchase Price Item ID", "Nabavna Cena Artikel ID") );
            t_Stock.AddColumn((Object)mt.m_Stock.m_Stock_AddressLevel1, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "ID Stock Address Level 1", "ID Naslova nivo 1") );
            t_Stock.AddColumn((Object)mt.m_Stock.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Stock);

            /* 30 */
            t_SimpleItem = new SQLTable((Object)new SimpleItem(),"si", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem);
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Name", "Ime") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Abbreviation", "Kratica") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.ToOffer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "To offer", "V ponudbi") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.m_SimpleItem_Image, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item/Service Image ID ", "Slika artikla/storitve ID") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.Code, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Code", "Št.storitve") );
            t_SimpleItem.AddColumn((Object)mt.m_SimpleItem.m_SimpleItem_ParentGroup1, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Group", "Skupina") );
            m_DBTables.items.Add(t_SimpleItem);

            /* 31 */
            t_MethodOfPayment = new SQLTable((Object)new MethodOfPayment(),"metopay", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem);
            t_MethodOfPayment.AddColumn((Object)mt.m_MethodOfPayment.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_MethodOfPayment.AddColumn((Object)mt.m_MethodOfPayment.PaymentType, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Payment Type", "Način plačila") );
            m_DBTables.items.Add(t_MethodOfPayment);

            /* 32 */
            t_Invoice = new SQLTable((Object)new Invoice(),"inv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Invoice);
            t_Invoice.AddColumn((Object)mt.m_Invoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Invoice.AddColumn((Object)mt.m_Invoice.PaymentDeadline, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Payment Deadline", "Rok plačila") );
            t_Invoice.AddColumn((Object)mt.m_Invoice.m_MethodOfPayment, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Method Of Payment ID", "Način Plačila ID") );
            t_Invoice.AddColumn((Object)mt.m_Invoice.Paid, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Paid", "Plačano") );
            t_Invoice.AddColumn((Object)mt.m_Invoice.Storno, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Storno", "Stornirano") );
            m_DBTables.items.Add(t_Invoice);


            /* 33 */
            t_Atom_Item = new SQLTable((Object)new Atom_Item(),"ai", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_InvoiceItem);
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.UniqueName, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Unique Name", "Unikatno ime") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_Name, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "ItemName ID", "Ime Artikla ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Unit, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Unit archive ID", "Enota arhiv ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_barcode, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item barcode ID", "barkoda ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Item_Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item description ID", "Opis artikla ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Expiry, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry ID", "Rok uporabe ID") );
            t_Atom_Item.AddColumn((Object)mt.m_Atom_Item.m_Atom_Warranty, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty ID", "Garancija ID") );
            m_DBTables.items.Add(t_Atom_Item);

            /* 34 */
            t_Atom_SimpleItem = new SQLTable((Object)new Atom_SimpleItem(),"asi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_InvoiceItem);
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "SimpleItem ID", "Artikel/Storitev ID") );
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_Atom_SimpleItem_Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "SimpleItem Name ID", "Ime Artikla/Storitve ID") );
            t_Atom_SimpleItem.AddColumn((Object)mt.m_Atom_SimpleItem.m_Atom_SimpleItem_Image, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "SimpleItem Image ID", "Slika Artikla/Storitve ID") );
            m_DBTables.items.Add(t_Atom_SimpleItem);

            /* 35 */
            t_cCardType_Person = new SQLTable((Object)new cCardType_Person(),"cardtper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCardType_Perosn);
            t_cCardType_Person.AddColumn((Object)mt.m_cCardType_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cCardType_Person.AddColumn((Object)mt.m_cCardType_Person.CardType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Card Type", "Vrsta Kartice") );
            m_DBTables.items.Add(t_cCardType_Person);

            /* 36 */
            t_DBSettings = new SQLTable((Object)new DBSettings(),"dbset", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cCardType_Perosn);
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Name", "Ime Nastavitve") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.TextValue, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Value", "Vrednost Nastavitve") );
            t_DBSettings.AddColumn((Object)mt.m_DBSettings.ReadOnly, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox, new ltext( "Read Only", "Samo za branje") );
            m_DBTables.items.Add(t_DBSettings);

            /* 37 */
            t_Atom_Item_Image = new SQLTable((Object)new Atom_Item_Image(),"aiimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Item_Image);
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.m_Atom_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Item ID", "Artikel ID") );
            t_Atom_Item_Image.AddColumn((Object)mt.m_Atom_Item_Image.m_Atom_Item_ImageLib, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Image ID", "Slika ID") );
            m_DBTables.items.Add(t_Atom_Item_Image);

            /* 38 */
            t_Atom_Item_ImageLib = new SQLTable((Object)new Atom_Item_ImageLib(),"aiimgl", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Item_ImageLib);
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "ident. slike") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image", "Slika artikla") );
            t_Atom_Item_ImageLib.AddColumn((Object)mt.m_Atom_Item_ImageLib.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Image description", "Opis slike") );
            m_DBTables.items.Add(t_Atom_Item_ImageLib);

            /* 39 */
            t_Atom_Item_Name = new SQLTable((Object)new Atom_Item_Name(),"ain", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Item_Name);
            t_Atom_Item_Name.AddColumn((Object)mt.m_Atom_Item_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Name.AddColumn((Object)mt.m_Atom_Item_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item Name", "Ime artikla") );            
            m_DBTables.items.Add(t_Atom_Item_Name);


            /* 40 */
            t_Atom_Item_barcode = new SQLTable((Object)new Atom_Item_barcode(),"aibar", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Item_barcode);
            t_Atom_Item_barcode.AddColumn((Object)mt.m_Atom_Item_barcode.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_barcode.AddColumn((Object)mt.m_Atom_Item_barcode.barcode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item barcode", "Črtna koda artikla") );        
            m_DBTables.items.Add(t_Atom_Item_barcode);


        /* 41 */
            t_Atom_Item_Description = new SQLTable((Object)new Atom_Item_Description(),"aid", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Item_Description);
            t_Atom_Item_Description.AddColumn((Object)mt.m_Atom_Item_Description.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Item_Description.AddColumn((Object)mt.m_Atom_Item_Description.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Item Description", "Opis artikla") );            
            m_DBTables.items.Add(t_Atom_Item_Description);


        /* 42 */
            t_Atom_SimpleItem_Name = new SQLTable((Object)new Atom_SimpleItem_Name(),"asin", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_SimpleItem_Name);
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "SimpleItem Name archive", "Ime artikla/storitve arhiv") );
            t_Atom_SimpleItem_Name.AddColumn((Object)mt.m_Atom_SimpleItem_Name.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "SimpleItem Abbreviation archive", "Kratica artikla/storitve arhiv") );
            m_DBTables.items.Add(t_Atom_SimpleItem_Name);


        /* 43 */
            t_Atom_Taxation = new SQLTable((Object)new Atom_Taxation(),"atax", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Taxation);
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "Taxation Name", "Naziv obdavčitve") );
            t_Atom_Taxation.AddColumn((Object)mt.m_Atom_Taxation.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Taxation Rate", "Davčna Stopnja") );
            m_DBTables.items.Add(t_Atom_Taxation);

        /* 44 */
            t_Atom_SimpleItem_Image = new SQLTable((Object)new Atom_SimpleItem_Image(),"asinimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_SimpleItem_Image);
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Atom_SimpleItem_Image_Hash", "Ident slike") );
            t_Atom_SimpleItem_Image.AddColumn((Object)mt.m_Atom_SimpleItem_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Atom_SimpleItem_Image", "Slika artikla/storitve") );            
            m_DBTables.items.Add(t_Atom_SimpleItem_Image);


        /* 45 */
            t_ProformaInvoice = new SQLTable((Object)new ProformaInvoice(),"pinv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ProformaInvoice);
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.Draft, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Draft", "Osnutek") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.DraftNumber, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Draft Number", "Številka Osnutka") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.FinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Financial Year", "Obračunsko Leto") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.NumberInFinancialYear, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Number in Financial Year", "Številka v Obračunskem Letu") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.NetSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Net Sum", "Cena brez DDV") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.Discount, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.EndSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "End Sum", "Cena s popustom") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.TaxSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Tax Sum", "DDV") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.GrossSum, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Gross Sum", "Cena za plačilo") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.m_Atom_Customer_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Customer Person archive ID", "Oseba Kupec arhiv ID") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.m_Atom_Customer_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Customer Company archive ID", "Kupec Organizacija arhiv ID") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.WarrantyExist, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty", "Garancija") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.WarrantyConditions, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty conditions", "Garancijski pogoji") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.WarrantyDurationType, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty Duration Type", "Tip trajanja garancije") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.WarrantyDuration, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty Duration", "Garancijski čas") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.ProformaInvoiceDuration, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Duration", "Čas veljavnosti ponudbe") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.ProformaInvoiceDurationType, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Duration Type", "Veljavnosti ponudbe v") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.m_TermsOfPayment, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "TermsOfPayment ID", "Plačilni pogoji ID") );
            t_ProformaInvoice.AddColumn((Object)mt.m_ProformaInvoice.m_Invoice, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Invoice ID", "Račun ID") );
            m_DBTables.items.Add(t_ProformaInvoice);

        /* 46 */
            t_ProformaInvoice_Image = new SQLTable((Object)new ProformaInvoice_Image(),"pinvimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ProformaInvoice_Image);
            t_ProformaInvoice_Image.AddColumn((Object)mt.m_ProformaInvoice_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_ProformaInvoice_Image.AddColumn((Object)mt.m_ProformaInvoice_Image.m_ProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "ProformaInvoice ID", "Predračun ID") );            
            t_ProformaInvoice_Image.AddColumn((Object)mt.m_ProformaInvoice_Image.m_ProformaInvoice_ImageLib, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "ProformaInvoice_ImageLib _ID", "Knjižnica slik ID") );            
            m_DBTables.items.Add(t_ProformaInvoice_Image);

        /* 47 */
            t_ProformaInvoice_ImageLib = new SQLTable((Object)new ProformaInvoice_ImageLib(),"pinvimgl", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ProformaInvoice_Image);
            t_ProformaInvoice_ImageLib.AddColumn((Object)mt.m_ProformaInvoice_ImageLib.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_ProformaInvoice_ImageLib.AddColumn((Object)mt.m_ProformaInvoice_ImageLib.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Ident slike") );            
            t_ProformaInvoice_ImageLib.AddColumn((Object)mt.m_ProformaInvoice_ImageLib.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image", "Slika") );            
            t_ProformaInvoice_ImageLib.AddColumn((Object)mt.m_ProformaInvoice_ImageLib.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Image Description", "Opis slike") );            
            m_DBTables.items.Add(t_ProformaInvoice_ImageLib);


        /* 48 */
            t_Invoice_Image = new SQLTable((Object)new Invoice_Image(), "invimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Invoice_Image);
            t_Invoice_Image.AddColumn((Object)mt.m_Invoice_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Invoice_Image.AddColumn((Object)mt.m_Invoice_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Ident slike") );
            t_Invoice_Image.AddColumn((Object)mt.m_Invoice_Image.Description, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image description", "Opis slike") );
            t_Invoice_Image.AddColumn((Object)mt.m_Invoice_Image.m_Invoice, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Image", "Slika") );
            t_Invoice_Image.AddColumn((Object)mt.m_Invoice_Image.InvoiceImage, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.TextBox, new ltext( "Image", "Slike") );
            m_DBTables.items.Add(t_Invoice_Image);

        /* 49 */
            t_TermsOfPayment = new SQLTable((Object)new TermsOfPayment(),"trmpay", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_TermsOfPayment);
            t_TermsOfPayment.AddColumn((Object)mt.m_TermsOfPayment.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_TermsOfPayment.AddColumn((Object)mt.m_TermsOfPayment.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );            
            m_DBTables.items.Add(t_TermsOfPayment);

        /* 50 */
            t_myCompany_Person = new SQLTable((Object)new myCompany_Person(),"mcomper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_myCompany_Person);
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.UserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox, new ltext( "UserName", "Uporabniško ime") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.Password, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Password", "Geslo") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.Job, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Job", "Delovno mesto") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.Active, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "Active", "Aktivna") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "My Company Person ID", "Oseba v podjetju ID") );
            t_myCompany_Person.AddColumn((Object)mt.m_myCompany_Person.m_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Office ID", "Poslovna enota ID") );
            m_DBTables.items.Add(t_myCompany_Person);

        /* 51 */
            t_Atom_ProformaInvoice_Price_Item_Stock = new SQLTable((Object)new Atom_ProformaInvoice_Price_Item_Stock(),"apinvpis", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ProformaInvoice_Atom_Item_Stock);
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Selected Quantity", "Izbrana Količina") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Extra Discount", "Dodatni Popust") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.RetailPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "RetailSimpleItemPrice with discount", "Prodajna cena s popustom") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax price", "Davek") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.m_ProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Proforma Invoice ID", "Predračun ID") );            
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.m_Atom_Price_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Price-Item arh ID", "Cena-Artikel arh ID") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.ExpiryDate,Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Expiry Date", "Rok uporabe") );
            t_Atom_ProformaInvoice_Price_Item_Stock.AddColumn((Object)mt.m_Atom_ProformaInvoice_Price_Item_Stock.m_Stock, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Stock ID", "Zaloga ID") );
            m_DBTables.items.Add(t_Atom_ProformaInvoice_Price_Item_Stock);

        /* 52 */
            t_Atom_myCompany_Person = new SQLTable((Object)new Atom_myCompany_Person(),"amcper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_myCompany_Person);
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.UserName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "UserName", "Uporabniško ime") );
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Person arh ID", "Oseba arh ID") );            
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.m_Atom_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "My Company arh ID", "Podjetje arh ID") );
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.Job, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Job", "Delovno mesto") );            
            t_Atom_myCompany_Person.AddColumn((Object)mt.m_Atom_myCompany_Person.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Description", "Opis") );            
            m_DBTables.items.Add(t_Atom_myCompany_Person);

        /* 53 */
            t_Atom_myCompany = new SQLTable((Object)new Atom_myCompany(),"amc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_myCompany);
            t_Atom_myCompany.AddColumn((Object)mt.m_Atom_myCompany.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_myCompany.AddColumn((Object)mt.m_Atom_myCompany.m_Atom_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation data ID archive", "Organizacija podatki ID arhiv") );
            m_DBTables.items.Add(t_Atom_myCompany);

        /* 54 */
            t_Atom_Person = new SQLTable((Object)new Atom_Person(),"aper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_BuyerAtom_Person);
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

        /* 55 */
            t_Atom_Organisation = new SQLTable((Object)new Atom_Organisation(),"aorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Organisation);
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation name", "Ime Organizacije") );
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Tax_ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TAX ID", "Davčna številka"));
            t_Atom_Organisation.AddColumn((Object)mt.m_Atom_Organisation.Registration_ID, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Registration ID", "Matična Številka"));
            m_DBTables.items.Add(t_Atom_Organisation);

         /* 56 */
            t_SimpleItem_Image = new SQLTable((Object)new SimpleItem_Image(),"siimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem_Image);
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_SimpleItem_Image.AddColumn((Object)mt.m_SimpleItem_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "SimpleItem Image", "Slika artikla/storitve") );
            m_DBTables.items.Add(t_SimpleItem_Image);

         /* 57 */
            t_Item_Image = new SQLTable((Object)new Item_Image(),"iimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Item_Image);
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_Item_Image.AddColumn((Object)mt.m_Item_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Item Image", "Slika Storitve") );
            m_DBTables.items.Add(t_Item_Image);

         /* 58 */
            t_Expiry = new SQLTable((Object)new Expiry(),"exp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Expiry);
            t_Expiry.AddColumn((Object)mt.m_Expiry.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.ExpectedShelfLifeInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expected Shelf Life In Days", "Pričakovani rok uporabe (v dneh)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.SaleBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "SaleBeforeExpiryDateInDays", "Razprodaja zaloge pred rokom uporabe (v dnevih)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.DiscardBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "DiscardBeforeExpiryDateInDays", "Znebitev zaloge pred rokom uporabe (v dnevih)") );
            t_Expiry.AddColumn((Object)mt.m_Expiry.ExpiryDescription, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expiry Description", "Opis roka uporabe") );
            m_DBTables.items.Add(t_Expiry);

         /* 59 */
            t_Warranty = new SQLTable((Object)new Warranty(),"wrty", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Warranty);
            t_Warranty.AddColumn((Object)mt.m_Warranty.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyDuration, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "čas garancije", "čas garancije") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyDurationType, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty duration unit", "Enota časa garancije") );
            t_Warranty.AddColumn((Object)mt.m_Warranty.WarrantyConditions, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Warranty conditions", "Garancijski pogoji") );
            m_DBTables.items.Add(t_Warranty);

         /* 60 */
            t_Atom_Expiry = new SQLTable((Object)new Atom_Expiry(),"aexp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Expiry);
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ExpectedShelfLifeInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Expected Shelf Life In Days", "Pričakovani rok uporabe (v dneh)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.SaleBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "SaleBeforeAtom_ExpiryDateInDays", "Razprodaja zaloge pred rokom uporabe (v dnevih)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.DiscardBeforeExpiryDateInDays, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "DiscardBeforeAtom_ExpiryDateInDays", "Znebitev zaloge pred rokom uporabe (v dnevih)") );
            t_Atom_Expiry.AddColumn((Object)mt.m_Atom_Expiry.ExpiryDescription, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Atom_Expiry Description ID", "Opis roka uporabe ID") );
            m_DBTables.items.Add(t_Atom_Expiry);

         /* 61 */
            t_Atom_Warranty = new SQLTable((Object)new Atom_Warranty(),"awrty", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Warranty);
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyDuration, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "čas garancije", "čas garancije") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyDurationType, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Atom_Warranty duration unit", "Enota časa garancije") );
            t_Atom_Warranty.AddColumn((Object)mt.m_Atom_Warranty.WarrantyConditions, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.RichTextBox, new ltext( "Atom_Warranty conditions ID", "Garancijski pogoji ID") );
            m_DBTables.items.Add(t_Atom_Warranty);

         /* 62 */
            t_Item_ParentGroup3 = new SQLTable((Object)new Item_ParentGroup3(),"ipg3", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Item_ParentGroup3);
            t_Item_ParentGroup3.AddColumn((Object)mt.m_Item_ParentGroup3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup3.AddColumn((Object)mt.m_Item_ParentGroup3.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Name of group 3", "Ime skupine 3") );
            m_DBTables.items.Add(t_Item_ParentGroup3);

         /* 63 */
            t_Item_ParentGroup2 = new SQLTable((Object)new Item_ParentGroup2(),"ipg2", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Item_ParentGroup2);
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 2", "Ime skupine 2") );
            t_Item_ParentGroup2.AddColumn((Object)mt.m_Item_ParentGroup2.m_Item_ParentGroup3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 3", "ID skupine artiklov 3") );
            m_DBTables.items.Add(t_Item_ParentGroup2);

         /* 64 */
            t_Item_ParentGroup1 = new SQLTable((Object)new Item_ParentGroup1(),"ipg1", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Item_ParentGroup1);
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 1", "Ime skupine 1") );
            t_Item_ParentGroup1.AddColumn((Object)mt.m_Item_ParentGroup1.m_Item_ParentGroup2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 2", "ID skupine artiklov 2") );
            m_DBTables.items.Add(t_Item_ParentGroup1);

         /* 65 */
            t_Stock_AddressLevel3 = new SQLTable((Object)new Stock_AddressLevel3(),"sal3", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Stock_AddressLevel3);
            t_Stock_AddressLevel3.AddColumn((Object)mt.m_Stock_AddressLevel3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel3.AddColumn((Object)mt.m_Stock_AddressLevel3.Address, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Stock Address Level 3", "Naslov nivo 3") );
            m_DBTables.items.Add(t_Stock_AddressLevel3);

         /* 66 */
            t_Stock_AddressLevel2 = new SQLTable((Object)new Stock_AddressLevel2(),"sal2", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Stock_AddressLevel2);
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.Address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock Address Level 2", "Naslov nivo 2") );
            t_Stock_AddressLevel2.AddColumn((Object)mt.m_Stock_AddressLevel2.m_Stock_AddressLevel3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID Stock Adreess 3", "ID Naslova nivo 3") );
            m_DBTables.items.Add(t_Stock_AddressLevel2);

         /* 67 */
            t_Stock_AddressLevel1 = new SQLTable((Object)new Stock_AddressLevel1(),"sal1", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Stock_AddressLevel1);
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.Address, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock Address 2", "Naslov nivo 1") );
            t_Stock_AddressLevel1.AddColumn((Object)mt.m_Stock_AddressLevel1.m_Stock_AddressLevel2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID Stock Address 2", "ID Naslova nivo 2") );
            m_DBTables.items.Add(t_Stock_AddressLevel1);


        /* 68 */
            t_Atom_cStreetName_Person = new SQLTable((Object)new Atom_cStreetName_Person(),"astrnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cStreetName_Person);;
            t_Atom_cStreetName_Person.AddColumn((Object)mt.m_Atom_cStreetName_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cStreetName_Person.AddColumn((Object)mt.m_Atom_cStreetName_Person.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street name", "Cesta") );
            m_DBTables.items.Add(t_Atom_cStreetName_Person);

        /* 69 */
            t_Atom_cHouseNumber_Person = new SQLTable((Object)new Atom_cHouseNumber_Person(),"ahounper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cHouseNumber_Person);
            t_Atom_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cHouseNumber_Person.AddColumn((Object)mt.m_cHouseNumber_Person.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_Atom_cHouseNumber_Person);

        /* 70 */
            t_Atom_cCity_Person = new SQLTable((Object)new Atom_cCity_Person(),"acitper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cCity_Person);
            t_Atom_cCity_Person.AddColumn((Object)mt.m_Atom_cCity_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCity_Person.AddColumn((Object)mt.m_Atom_cCity_Person.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "City", "Kraj") );
            m_DBTables.items.Add(t_Atom_cCity_Person);

        /* 71 */
            t_Atom_cZIP_Person = new SQLTable((Object)new Atom_cZIP_Person(),"azipper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cZIP_Person);
            t_Atom_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cZIP_Person.AddColumn((Object)mt.m_cZIP_Person.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cZIP_Person);

        /* 72 */
            t_Atom_cState_Person = new SQLTable((Object)new Atom_cState_Person(),"astper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cState_Person);
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Person.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "State", "Država") );
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Person.State_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a2", "ISO_3166 a3"));
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Person.State_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_Atom_cState_Person.AddColumn((Object)mt.m_Atom_cState_Person.State_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_Atom_cState_Person);

        /* 73 */
            t_Atom_cCountry_Person = new SQLTable((Object)new Atom_cCountry_Person(),"acouper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cCountry_Person);
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCountry_Person.AddColumn((Object)mt.m_Atom_cCountry_Org.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Country", "Dežela") );
            m_DBTables.items.Add(t_Atom_cCountry_Person);

        /* 74 */
            t_Atom_cStreetName_Org = new SQLTable((Object)new Atom_cStreetName_Org(),"astrnorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cStreetName_Org);;
            t_Atom_cStreetName_Org.AddColumn((Object)mt.m_Atom_cStreetName_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cStreetName_Org.AddColumn((Object)mt.m_Atom_cStreetName_Org.StreetName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Street name", "Cesta") );
            m_DBTables.items.Add(t_Atom_cStreetName_Org);

        /* 75 */
            t_Atom_cHouseNumber_Org = new SQLTable((Object)new Atom_cHouseNumber_Org(),"ahounorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cHouseNumber_Org);
            t_Atom_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cHouseNumber_Org.AddColumn((Object)mt.m_cHouseNumber_Org.HouseNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "House Number", "Hišna številka") );
            m_DBTables.items.Add(t_Atom_cHouseNumber_Org);

        /* 76 */
            t_Atom_cCity_Org = new SQLTable((Object)new Atom_cCity_Org(),"acitorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cCity_Org);
            t_Atom_cCity_Org.AddColumn((Object)mt.m_Atom_cCity_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCity_Org.AddColumn((Object)mt.m_Atom_cCity_Org.City, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "City", "Kraj") );
            m_DBTables.items.Add(t_Atom_cCity_Org);

        /* 77 */
            t_Atom_cZIP_Org = new SQLTable((Object)new Atom_cZIP_Org(),"aziporg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cZIP_Org);
            t_Atom_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cZIP_Org.AddColumn((Object)mt.m_cZIP_Org.ZIP, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cZIP_Org);

        /* 78 */
            t_Atom_cState_Org = new SQLTable((Object)new Atom_cState_Org(), "astorg",Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cState_Org);
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.State, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "State", "Država") );
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.State_ISO_3166_a2, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a2", "ISO_3166 a3"));
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.State_ISO_3166_a3, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 a3", "ISO_3166 a3"));
            t_Atom_cState_Org.AddColumn((Object)mt.m_Atom_cState_Org.State_ISO_3166_num, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("ISO_3166 num", "ISO_3166 št."));
            m_DBTables.items.Add(t_Atom_cState_Org);


        /* 79 */
            t_Atom_cCountry_Org = new SQLTable((Object)new Atom_cCountry_Org(),"acouorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cCountry_Org);
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCountry_Org.AddColumn((Object)mt.m_Atom_cCountry_Org.Country, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "ZIP", "Številka pošte") );
            m_DBTables.items.Add(t_Atom_cCountry_Org);

        /* 80 */
            t_cAddress_Person = new SQLTable((Object)new cAddress_Person(), "cadrper",Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cAddress_Person);
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cStreetName_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cHouseNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cCity_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cZIP_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cState_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Država ID") );
            t_cAddress_Person.AddColumn((Object)mt.m_cAddress_Person.m_cCountry_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Dežela ID") );
            m_DBTables.items.Add(t_cAddress_Person);

        /* 81 */
            t_cAddress_Org = new SQLTable((Object)new cAddress_Org(),"cadrorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_cAddress_Org);
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cStreetName_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cHouseNumber_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cCity_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cZIP_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cState_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Država ID") );
            t_cAddress_Org.AddColumn((Object)mt.m_cAddress_Org.m_cCountry_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Dežela ID") );
            m_DBTables.items.Add(t_cAddress_Org);

        /* 82 */
            t_Atom_cAddress_Person = new SQLTable((Object)new Atom_cAddress_Person(),"acadrper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cAddress_Person);
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cStreetName_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cHouseNumber_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cCity_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cZIP_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cState_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Država ID") );
            t_Atom_cAddress_Person.AddColumn((Object)mt.m_Atom_cAddress_Person.m_Atom_cCountry_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Dežela ID") );
            m_DBTables.items.Add(t_Atom_cAddress_Person);

        /* 83 */
            t_Atom_cAddress_Org = new SQLTable((Object)new Atom_cAddress_Org(),"acadrorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cAddress_Org);
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cStreetName_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Street Name ID", "Cesta ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cHouseNumber_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "House Number ID", "Hišna številka ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cCity_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "City ID", "Mesto ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cZIP_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ZIP ID", "Številka Pošte ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cState_Org, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "State ID", "Država ID") );
            t_Atom_cAddress_Org.AddColumn((Object)mt.m_Atom_cAddress_Org.m_Atom_cCountry_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Country ID", "Dežela ID") );
            m_DBTables.items.Add(t_Atom_cAddress_Org);

        /* 84 */
            t_Price_Item = new SQLTable((Object)new Price_Item(),"pi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Price_Item);
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.RetailPricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail Price Per Unit", "Maloprodajna cena na komad") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation ID", "Obdavčitev ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Item ID", "Artikel ID") );
            t_Price_Item.AddColumn((Object)mt.m_Price_Item.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Price List ID", "Cenik ID") );
            m_DBTables.items.Add(t_Price_Item);

        /* 85 */
            t_Price_SimpleItem = new SQLTable((Object)new Price_SimpleItem(),"psi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Price_SimpleItem);
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.RetailSimpleItemPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail price", "Prodajna cena") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljavno") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation ID", "Obdavčitev ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "SimpleItem ID", "Artikel/Storitev ID") );
            t_Price_SimpleItem.AddColumn((Object)mt.m_Price_SimpleItem.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.ReadOnlyTable, new ltext( "Price list ID", "Cenik ID") );
            m_DBTables.items.Add(t_Price_SimpleItem);

        /* 86 */
            t_PriceList = new SQLTable((Object)new PriceList(),"pl", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PriceList);
            t_PriceList.AddColumn((Object)mt.m_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Price List Name", "Ime Cenika") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.Valid, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljaven") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.ValidFrom, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid from", "Velja od") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.ValidTo, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid to", "Velja do") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.CreationDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Creation time", "Čas nastanka") );
            t_PriceList.AddColumn((Object)mt.m_PriceList.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_PriceList);

        /* 87 */
            t_Currency = new SQLTable((Object)new Currency(),"Cur", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Currency);
            t_Currency.AddColumn((Object)mt.m_Currency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Currency.AddColumn((Object)mt.m_Currency.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.TextBox, new ltext( "Currency letter code", "Oznaka valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Currency Name", "Ime Valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox, new ltext( "Currency Symbol", "Znak valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.CurrencyCode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Code", "Šifra valute") );
            t_Currency.AddColumn((Object)mt.m_Currency.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalk") );
            m_DBTables.items.Add(t_Currency);


        /* 88 */
            t_BaseCurrency = new SQLTable((Object)new BaseCurrency(),"bcur", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_BaseCurrency);
            t_BaseCurrency.AddColumn((Object)mt.m_BaseCurrency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_BaseCurrency.AddColumn((Object)mt.m_BaseCurrency.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            m_DBTables.items.Add(t_BaseCurrency);

        /* 89 */
            t_RateToBaseCurrency = new SQLTable((Object)new RateToBaseCurrency(),"rtbcur", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_RateToBaseCurrency);
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_BaseCurrency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Base Currency ID", "Osnovna Valuta ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.Rate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate", "Menjalno razmerje") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.RateDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate Date", "Datum Menjalnega razmerja") );
            t_RateToBaseCurrency.AddColumn((Object)mt.m_RateToBaseCurrency.m_ExchangeRateSource, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Exchange Rate Source", "Vir Menjalnega razmerja") );
            m_DBTables.items.Add(t_RateToBaseCurrency);

        /* 90 */
            t_ExchangeRateSource = new SQLTable((Object)new ExchangeRateSource(),"exchgrs", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_ExchangeRateSource);
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Source Name", "Ime vira") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.URL, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "URL", "URL") );
            t_ExchangeRateSource.AddColumn((Object)mt.m_ExchangeRateSource.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_ExchangeRateSource);

        /* 91 */
            t_Atom_PriceList = new SQLTable((Object)new Atom_PriceList(),"apl", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_PriceList);;
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Price list name ", "Ime cenika") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.Valid, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid", "Veljavno") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ValidFrom, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid from", "Veljavno od") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.ValidTo, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Valid to", "Veljavno do") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            t_Atom_PriceList.AddColumn((Object)mt.m_Atom_PriceList.m_Atom_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID archive ", "Valuta ID arhiv") );
            m_DBTables.items.Add(t_Atom_PriceList);


        /* 92 */
            t_PurchasePrice_Item = new SQLTable((Object)new PurchasePrice_Item(),"ppi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PurchasePrice_Item);
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.m_PurchasePrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Purchase price ID", "Nabavna cena ID") );
            t_PurchasePrice_Item.AddColumn((Object)mt.m_PurchasePrice_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item ID", "Artikel ID") );
            m_DBTables.items.Add(t_PurchasePrice_Item);

        /* 93 */
            t_Atom_Currency = new SQLTable((Object)new Atom_Currency(),"acur", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Currency);
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Name", "Ime valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Abbreviation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency Abbreviation", "Oznaka valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency symbol", "Znak valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.CurrencyCode, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency code", "številka valute") );
            t_Atom_Currency.AddColumn((Object)mt.m_Atom_Currency.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal Places", "Število decimalk") );
            m_DBTables.items.Add(t_Atom_Currency);


        /* 94 */
            t_Atom_Price_Item  = new SQLTable((Object)new Atom_Price_Item(),"api", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Price_Item);
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.RetailPricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail price per unit", "Prodajna cena artikla") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation archive ID", "Obdavćitev arhiv ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_Item, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Item archive ID", "Artikel arhiv ID") );
            t_Atom_Price_Item.AddColumn((Object)mt.m_Atom_Price_Item.m_Atom_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price Item archive ID", "Cenik Artiklov arhiv ID") );
            m_DBTables.items.Add(t_Atom_Price_Item);

        /* 95 */
            t_Atom_Price_SimpleItem  = new SQLTable((Object)new Atom_Price_SimpleItem(),"apsi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Price_SimpleItem);
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.RetailSimpleItemPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Retail SimpleItem price", "Cena storitve") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.Discount, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Discount", "Popust") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.iQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.RetailSimpleItemPriceWithDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "RetailSimpleItemPrice with discount", "Prodajna cena s popustom") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.ExtraDiscount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Extra Discount", "Dodatni Popust") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.TaxPrice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Tax price", "Davek") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.m_Atom_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "SimpleItem archive ID", "Artikel/Storitev arhiv ID") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.m_Atom_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Price SimpleItem archive ID", "Cenik artikel/storitev arhiv ID") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.m_Atom_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation archive ID", "Obdavćitev arhiv ID") );
            t_Atom_Price_SimpleItem.AddColumn((Object)mt.m_Atom_Price_SimpleItem.m_ProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ProformaInvoice ID", "Pred-Račun ID") );
            m_DBTables.items.Add(t_Atom_Price_SimpleItem);

         /* 96 */
            t_PersonImage = new SQLTable((Object)new PersonImage(),"perimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PersonImage);
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Image Hash", "Hash slike") );
            t_PersonImage.AddColumn((Object)mt.m_PersonImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Person Image", "Slika osebe") );
            m_DBTables.items.Add(t_PersonImage);

         /* 97 */
            t_Unit = new SQLTable((Object)new Unit(),"u", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Units);
            t_Unit.AddColumn((Object)mt.m_Unit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Unit.AddColumn((Object)mt.m_Unit.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unit Name", "Ime enote") );
            t_Unit.AddColumn((Object)mt.m_Unit.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Symbol", "Simbol") );
            t_Unit.AddColumn((Object)mt.m_Unit.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalnih mest") );
            t_Unit.AddColumn((Object)mt.m_Unit.StorageOption, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Storage option", "Možnost skladiščenja") );
            t_Unit.AddColumn((Object)mt.m_Unit.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Unit);

         /* 98 */
            t_Atom_Unit = new SQLTable((Object)new Atom_Unit(),"au", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_UnitsArchive);
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Unit Name", "Ime enote") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Symbol, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Symbol", "Simbol") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.DecimalPlaces, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Decimal places", "Število decimalnih mest") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.StorageOption, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Storage option", "Možnost skladiščenja") );
            t_Atom_Unit.AddColumn((Object)mt.m_Atom_Unit.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Atom_Unit);

        /* 99 */
            t_AccessRights = new SQLTable((Object)new AccessRights(),"accr", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_AccessRights); ;
            t_AccessRights.AddColumn((Object)mt.m_AccessRights.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_AccessRights.AddColumn((Object)mt.m_AccessRights.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Name of access Rights", "Ime dostopne pravice") );
            t_AccessRights.AddColumn((Object)mt.m_AccessRights.Description, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Description of access Rights", "Opis dostopne pravice") );
            m_DBTables.items.Add(t_AccessRights);

        /* 100 */
            t_myCompany_Person_AccessRights = new SQLTable((Object)new myCompany_Person_AccessRights(),"mcperaccr", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_myCompany_Person_AccessRights); ;
            t_myCompany_Person_AccessRights.AddColumn((Object)mt.m_myCompany_Person_AccessRights.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_myCompany_Person_AccessRights.AddColumn((Object)mt.m_myCompany_Person_AccessRights.m_AccessRights, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Access Rights ID", "Dostopne pravice ID") );
            t_myCompany_Person_AccessRights.AddColumn((Object)mt.m_myCompany_Person_AccessRights.m_myCompany_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Company person ID", "Oseba v podjetju ID") );
            m_DBTables.items.Add(t_myCompany_Person_AccessRights);

         /* 101 */
            t_OrganisationData = new SQLTable((Object)new OrganisationData(),"orgd", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_OrganisationData); ;
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cOrgTYPE, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Company Type", "Tip Firme") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cAddress_Org, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Address ID", "Naslov ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cPhoneNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Phone Number ID", "Telefonska številka ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cFaxNumber_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Fax Number ID", "Številka Faksa ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cEmail_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_cHomePage_Org, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "HomePage ID", "Domača stran ID") );
            t_OrganisationData.AddColumn((Object)mt.m_OrganisationData.m_Logo, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Logo ID", "Logotip ID") );
            m_DBTables.items.Add(t_OrganisationData);

          /* 102 */
            t_PurchasePrice = new SQLTable((Object)new PurchasePrice(),"pp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PurchasePrice); ;
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.PurchasePricePerUnit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Purchase price per unit", "Nabavna cena na enoto") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.PurchasePriceDate, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimeNow, new ltext( "Purchase price date", "Datum nabavne cene") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Reference, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Reference ID", "Sklic ID") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Currency, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Currency ID", "Valuta ID") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Taxation ID", "Davek ID") );
            t_PurchasePrice.AddColumn((Object)mt.m_PurchasePrice.m_Supplier, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Supplier ID", "Dobavitelj ID") );
            m_DBTables.items.Add(t_PurchasePrice);

         /* 103 */
            t_Reference_Image = new SQLTable((Object)new Reference_Image(),"refimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Reference_Image); ;
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.TextBox_ReadOnly, new ltext( "Reference Image Hash", "Ident slike v sklicu") );
            t_Reference_Image.AddColumn((Object)mt.m_Reference_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.PictureBox, new ltext( "Reference Image Hash", "Slika daokumenta v sklicu") );
            m_DBTables.items.Add(t_Reference_Image);

         /* 104 */
            t_Atom_OrganisationData = new SQLTable((Object)new Atom_OrganisationData(),"aorgd", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_OrganisationData); ;
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

        /* 105 */
            t_Supplier = new SQLTable((Object)new Supplier(),"sup", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Suplier);
            t_Supplier.AddColumn((Object)mt.m_Supplier.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Supplier.AddColumn((Object)mt.m_Supplier.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            m_DBTables.items.Add(t_Supplier);

        /* 106 */
        
            t_Customer_Org = new SQLTable((Object)new Customer_Org(), "cusorg",Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Customer_Org);
            t_Customer_Org.AddColumn((Object)mt.m_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Customer_Org.AddColumn((Object)mt.m_Customer_Org.m_OrganisationData, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            m_DBTables.items.Add(t_Customer_Org);

        /* 107 */
            t_Customer_Person = new SQLTable((Object)new Customer_Person(),"cusper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Customer_Person);
            t_Customer_Person.AddColumn((Object)mt.m_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Customer_Person.AddColumn((Object)mt.m_Customer_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Person ID", "Oseba ID") );
            m_DBTables.items.Add(t_Customer_Person);

        /* 108 */
            t_Atom_Customer_Org = new SQLTable((Object)new Atom_Customer_Org(),"acusorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Customer_Org);
            t_Atom_Customer_Org.AddColumn((Object)mt.m_Atom_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Customer_Org.AddColumn((Object)mt.m_Atom_Customer_Org.m_Atom_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID archive", "Organizacija ID arhiv") );
            m_DBTables.items.Add(t_Atom_Customer_Org);

        /* 109 */
            t_Atom_Customer_Person = new SQLTable((Object)new Atom_Customer_Person(),"acusper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Customer_Person);
            t_Atom_Customer_Person.AddColumn((Object)mt.m_Atom_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Customer_Person.AddColumn((Object)mt.m_Atom_Customer_Person.m_Atom_Person, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Person ID archive", "Oseba ID arthiv") );
            m_DBTables.items.Add(t_Atom_Customer_Person);

        /* 110 */
            t_PersonData = new SQLTable((Object)new PersonData(), "perd",Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PersonData);
            t_PersonData.AddColumn((Object)mt.m_PersonData.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Person ID", "Oseba ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cGsmNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "GSM Number ID", "Gsm ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cPhoneNumber_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Telephone Number ID", "Telefon ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cEmail_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Email ID", "Elektronski naslov ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cAddress_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Adress ID", "Naslov ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.CardNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Number", "Številka kartice") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_cCardType_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card Type ID", "Vrsta Kartice ID") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.m_PersonImage, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image", "Slika") );
            t_PersonData.AddColumn((Object)mt.m_PersonData.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_PersonData);

        /* 111 */
            t_PersonAccount = new SQLTable((Object)new PersonAccount(),"peracc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_PersonAccount);
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.m_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Bank Account ID", "Bančni račun ID") );
            t_PersonAccount.AddColumn((Object)mt.m_PersonAccount.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Person ID", "Oseba ID") );
            m_DBTables.items.Add(t_PersonAccount);

        /* 112 */
            t_Bank = new SQLTable((Object)new Bank(),"bank", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Bank);
            t_Bank.AddColumn((Object)mt.m_Bank.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Bank.AddColumn((Object)mt.m_Bank.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Organisation ID", "Organizacija ID") );
            m_DBTables.items.Add(t_Bank);

        /* 113 */
            t_BankAccount = new SQLTable((Object)new BankAccount(),"bankacc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_BankAccount);
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.m_Bank, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Bank ID", "Banka ID") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.TRR, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Account", "TRR") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.Active, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.CheckBox_default_true, new ltext( "Active", "Aktiven") );
            t_BankAccount.AddColumn((Object)mt.m_BankAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_BankAccount);

        /* 114 */
            t_OrganisationAccount = new SQLTable((Object)new OrganisationAccount(),"orgacc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_OrganisationAccount);
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.m_BankAccount, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Bank Account ID", "Bančni račun ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.m_Organisation, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Organisation ID", "Oseba ID") );
            t_OrganisationAccount.AddColumn((Object)mt.m_OrganisationAccount.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_OrganisationAccount);

        /* 115 */
            t_JOURNAL_Invoice_Type = new SQLTable((Object)new JOURNAL_Invoice_Type(),"jinvt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Invoice_Type);
            t_JOURNAL_Invoice_Type.AddColumn((Object)mt.m_JOURNAL_Invoice_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Invoice_Type.AddColumn((Object)mt.m_JOURNAL_Invoice_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Invoice_Type.AddColumn((Object)mt.m_JOURNAL_Invoice_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Invoice_Type);

        /* 116 */
            t_JOURNAL_PriceList_Type = new SQLTable((Object)new JOURNAL_PriceList_Type(),"jplt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_PriceList_Type);
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_PriceList_Type.AddColumn((Object)mt.m_JOURNAL_PriceList_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_PriceList_Type);


        /* 117 */
            t_JOURNAL_ProformaInvoice_Type = new SQLTable((Object)new JOURNAL_ProformaInvoice_Type(),"jpinvt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_ProformaInvoice_Type);
            t_JOURNAL_ProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_ProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_ProformaInvoice_Type.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_ProformaInvoice_Type);

        /* 118 */
            t_JOURNAL_Item_Type = new SQLTable((Object)new JOURNAL_Item_Type(),"jit", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Item_Type);
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Item_Type.AddColumn((Object)mt.m_JOURNAL_Item_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Item_Type);

        /* 119 */
            t_JOURNAL_SimpleItem_Type = new SQLTable((Object)new JOURNAL_SimpleItem_Type(),"jsit", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_SimpleItem_Type);
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_SimpleItem_Type.AddColumn((Object)mt.m_JOURNAL_SimpleItem_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_SimpleItem_Type);

        /* 120 */
            t_JOURNAL_myCompany_Type = new SQLTable((Object)new JOURNAL_myCompany_Type(),"jmct", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_myCompany_Type);
            t_JOURNAL_myCompany_Type.AddColumn((Object)mt.m_JOURNAL_myCompany_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myCompany_Type.AddColumn((Object)mt.m_JOURNAL_myCompany_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_myCompany_Type.AddColumn((Object)mt.m_JOURNAL_myCompany_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_myCompany_Type);

        /* 121 */
            t_JOURNAL_myCompany_Person_Type = new SQLTable((Object)new JOURNAL_Person_Type(),"jpert", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_myCompany_Person_Type);
            t_JOURNAL_myCompany_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myCompany_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_myCompany_Person_Type.AddColumn((Object)mt.m_JOURNAL_Person_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_myCompany_Person_Type);


        /* 122 */
            t_JOURNAL_Customer_Person_Type = new SQLTable((Object)new JOURNAL_Customer_Person_Type(),"jcuspert", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Person_Type);
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Customer_Person_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Type);

        /* 123 */
            t_JOURNAL_Customer_Org_Type = new SQLTable((Object)new JOURNAL_Customer_Org_Type(),"jcusorgt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Org_Type);
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Customer_Org_Type.AddColumn((Object)mt.m_JOURNAL_Customer_Org_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Org_Type);

        /* 124 */
            t_JOURNAL_PurchasePrice_Type = new SQLTable((Object)new JOURNAL_PurchasePrice_Type(),"jppt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_PurchasePrice_Type);
            t_JOURNAL_PurchasePrice_Type.AddColumn((Object)mt.m_JOURNAL_PurchasePrice_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PurchasePrice_Type.AddColumn((Object)mt.m_JOURNAL_PurchasePrice_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_PurchasePrice_Type.AddColumn((Object)mt.m_JOURNAL_PurchasePrice_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_PurchasePrice_Type);

        /* 125 */
            t_JOURNAL_Taxation_Type = new SQLTable((Object)new JOURNAL_Taxation_Type(),"jtaxt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Taxation_Type);
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Taxation_Type.AddColumn((Object)mt.m_JOURNAL_Taxation_Type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Taxation_Type);

        /* 126 */
            t_JOURNAL_Stock_Type = new SQLTable((Object)new JOURNAL_Stock_Type(),"jstockt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Stock_Type);
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Type Name", "Ime") );
            t_JOURNAL_Stock_Type.AddColumn((Object)mt.m_JOURNAL_Stock_Type.Description, Column.nullTYPE.NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Stock_Type);

        /* 127 */
            t_JOURNAL_Invoice = new SQLTable((Object)new JOURNAL_Invoice(),"jinv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Invoice);
            t_JOURNAL_Invoice.AddColumn((Object)mt.m_JOURNAL_Invoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Invoice.AddColumn((Object)mt.m_JOURNAL_Invoice.m_JOURNAL_Invoice_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal event invoice ID", "Dogodek račun ID") );
            t_JOURNAL_Invoice.AddColumn((Object)mt.m_JOURNAL_Invoice.m_Invoice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Invoice ID", "Račun ID") );
            t_JOURNAL_Invoice.AddColumn((Object)mt.m_JOURNAL_Invoice.EventTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Invoice.AddColumn((Object)mt.m_JOURNAL_Invoice.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Invoice);

        /* 128 */
            t_JOURNAL_ProformaInvoice = new SQLTable((Object)new JOURNAL_ProformaInvoice(),"jpinv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_ProformaInvoice);
            t_JOURNAL_ProformaInvoice.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_ProformaInvoice.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice.m_JOURNAL_ProformaInvoice_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event proforma-invoice ID", "Dogodek predračun ID") );
            t_JOURNAL_ProformaInvoice.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice.m_ProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Predračun ID") );
            t_JOURNAL_ProformaInvoice.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_ProformaInvoice.AddColumn((Object)mt.m_JOURNAL_ProformaInvoice.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext("Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_ProformaInvoice);


        /* 129 */
            t_JOURNAL_Item = new SQLTable((Object)new JOURNAL_Item(),"ji", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Item);
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_JOURNAL_Item_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event item ID", "Dogodek predračun ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_Item, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Predračun ID") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Item.AddColumn((Object)mt.m_JOURNAL_Item.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID"));
            m_DBTables.items.Add(t_JOURNAL_Item);

        /* 130 */
            t_JOURNAL_SimpleItem = new SQLTable((Object)new JOURNAL_SimpleItem(),"jsi", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_SimpleItem);
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_JOURNAL_SimpleItem_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event SimpleItem ID", "Dogodek storitev ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_SimpleItem, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Proforma SimpleItem ID", "Artikel/Storitev ID") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_SimpleItem.AddColumn((Object)mt.m_JOURNAL_SimpleItem.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_SimpleItem);

        /* 131 */
            t_JOURNAL_PriceList = new SQLTable((Object)new JOURNAL_PriceList(),"jpl", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_PriceList);
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_JOURNAL_PriceList_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event price list ID", "Dogodek cenik ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_PriceList, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Price list ID", "Cenik ID") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_PriceList.AddColumn((Object)mt.m_JOURNAL_PriceList.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_PriceList);

        /* 132 */
            t_JOURNAL_myCompany = new SQLTable((Object)new JOURNAL_myCompany(),"jmc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_myCompany);
            t_JOURNAL_myCompany.AddColumn((Object)mt.m_JOURNAL_myCompany.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_myCompany.AddColumn((Object)mt.m_JOURNAL_myCompany.m_JOURNAL_myCompany_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event my organisation ID", "Dogodek moja organizacija ID") );
            t_JOURNAL_myCompany.AddColumn((Object)mt.m_JOURNAL_myCompany.m_myCompany, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "My organisation ID", "Moja organizacija ID") );
            t_JOURNAL_myCompany.AddColumn((Object)mt.m_JOURNAL_myCompany.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_myCompany.AddColumn((Object)mt.m_JOURNAL_myCompany.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_myCompany);

        /* 133 */
            t_JOURNAL_Person = new SQLTable((Object)new JOURNAL_Person(),"jper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Person);
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_JOURNAL_Person_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event person ID", "Dogodek fizična oseba ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Person ID", "Fizična oseba ID") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Person.AddColumn((Object)mt.m_JOURNAL_Person.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext(  "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Person);

        /* 134 */
            t_JOURNAL_Customer_Person = new SQLTable((Object)new JOURNAL_Customer_Person(),"jcusper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Person);
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_JOURNAL_Customer_Person_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event customer person ID", "Dogodek fizična oseba ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_Customer_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Customer person ID", "Stranka fizična oseba ID") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Customer_Person.AddColumn((Object)mt.m_JOURNAL_Customer_Person.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person);

        /* 135 */
            t_JOURNAL_Customer_Person_Data = new SQLTable((Object)new JOURNAL_Customer_Person_Data(),"jcusperd", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Person_Data);
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.m_JOURNAL_Customer_Person, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal customer person ID", "Dnevnik fizična oseba ID") );
            t_JOURNAL_Customer_Person_Data.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data.m_Description, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Data);

        /* 136 */
            t_JOURNAL_Customer_Person_Data_Image = new SQLTable((Object)new JOURNAL_Customer_Person_Data_Image(),"jcusperdimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Person_Data_Image);
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Image Hash", "Identifikacija slike (\"Image_Hash\")") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Image Data", "Slika") );
            t_JOURNAL_Customer_Person_Data_Image.AddColumn((Object)mt.m_JOURNAL_Customer_Person_Data_Image.Description, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_JOURNAL_Customer_Person_Data_Image);

        /* 137 */
            t_JOURNAL_Customer_Org = new SQLTable((Object)new JOURNAL_Customer_Org(),"jcusorg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Customer_Org);
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_JOURNAL_Customer_Org_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event customer organisation ID", "Dogodek stranka organizacija ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_Customer_Org, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Customer organisation ID", "Stranka organizacija ID") );
            t_JOURNAL_Customer_Org.AddColumn((Object)mt.m_JOURNAL_Customer_Org.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") ); 
            m_DBTables.items.Add(t_JOURNAL_Customer_Org);

        /* 138 */
            t_JOURNAL_PurchasePrice = new SQLTable((Object)new JOURNAL_PurchasePrice(),"jpp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_PurchasePrice);
            t_JOURNAL_PurchasePrice.AddColumn((Object)mt.m_JOURNAL_PurchasePrice.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_PurchasePrice.AddColumn((Object)mt.m_JOURNAL_PurchasePrice.m_JOURNAL_PurchasePrice_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event purchase price ID", "Dogodek nabavna cena ID") );
            t_JOURNAL_PurchasePrice.AddColumn((Object)mt.m_JOURNAL_PurchasePrice.m_PurchasePrice, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Purchase price ID", "Nabavna cena ID") );
            t_JOURNAL_PurchasePrice.AddColumn((Object)mt.m_JOURNAL_PurchasePrice.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_PurchasePrice.AddColumn((Object)mt.m_JOURNAL_PurchasePrice.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_PurchasePrice);

        /* 139 */
            t_JOURNAL_Taxation = new SQLTable((Object)new JOURNAL_Taxation(),"jtax", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Taxation);
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_JOURNAL_Taxation_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event taxation ID", "Dogodek davki ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_Taxation, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Taxation ID", "Davek ID") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Taxation.AddColumn((Object)mt.m_JOURNAL_Taxation.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Taxation);

        /* 140 */
            t_JOURNAL_Stock = new SQLTable((Object)new JOURNAL_Stock(),"jstock", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Stock);
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_JOURNAL_Stock_Type, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Journal event stock ID", "Dogodek skladišče ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_Stock, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Stock ID", "Skladišče ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Event time", "Čas dogodka") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            t_JOURNAL_Stock.AddColumn((Object)mt.m_JOURNAL_Stock.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.DUPLICATE, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            m_DBTables.items.Add(t_JOURNAL_Stock);

        /* 141 */
            t_SimpleItem_ParentGroup3 = new SQLTable((Object)new SimpleItem_ParentGroup3(),"sipg3", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem_ParentGroup3);
            t_SimpleItem_ParentGroup3.AddColumn((Object)mt.m_SimpleItem_ParentGroup3.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup3.AddColumn((Object)mt.m_SimpleItem_ParentGroup3.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "Name of group 3", "Ime skupine 3") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup3);

        /* 142 */
            t_SimpleItem_ParentGroup2 = new SQLTable((Object)new SimpleItem_ParentGroup2(),"sipg2", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem_ParentGroup2);
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 2", "Ime skupine 2") );
            t_SimpleItem_ParentGroup2.AddColumn((Object)mt.m_SimpleItem_ParentGroup2.m_SimpleItem_ParentGroup3, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 3", "ID skupine artiklov 3") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup2);

        /* 143 */
            t_SimpleItem_ParentGroup1 = new SQLTable((Object)new SimpleItem_ParentGroup1(),"sipg1", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_SimpleItem_ParentGroup1);
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Name of group 1", "Ime skupine 1") );
            t_SimpleItem_ParentGroup1.AddColumn((Object)mt.m_SimpleItem_ParentGroup1.m_SimpleItem_ParentGroup2, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "ID of item group 2", "ID skupine artiklov 2") );
            m_DBTables.items.Add(t_SimpleItem_ParentGroup1);

        /* 144 */
            t_Logo = new SQLTable((Object)new Logo(),"logo", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Logo);
            t_Logo.AddColumn((Object)mt.m_Logo.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Logo.AddColumn((Object)mt.m_Logo.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Ident slike") );
            t_Logo.AddColumn((Object)mt.m_Logo.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image", "Slika") );
            t_Logo.AddColumn((Object)mt.m_Logo.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Logo);

        /* 145 */
            t_Atom_Logo = new SQLTable((Object)new Atom_Logo(),"alogo", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Logo);
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Ident slike") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Logo", "Slika logotipa") );
            t_Atom_Logo.AddColumn((Object)mt.m_Atom_Logo.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Description", "Opis") );
            m_DBTables.items.Add(t_Atom_Logo);

        /* 146 */
            t_Atom_cFirstName = new SQLTable((Object)new Atom_cFirstName(),"acfn", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cFirstName);
            t_Atom_cFirstName.AddColumn((Object)mt.m_Atom_cFirstName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cFirstName.AddColumn((Object)mt.m_Atom_cFirstName.FirstName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "First Name", "Ime") );
            m_DBTables.items.Add(t_Atom_cFirstName);
                        
        /* 147 */       
            t_Atom_cLastName = new SQLTable((Object)new Atom_cLastName(),"acln", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cLastName);
            t_Atom_cLastName.AddColumn((Object)mt.m_Atom_cLastName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cLastName.AddColumn((Object)mt.m_Atom_cLastName.LastName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Last Name", "Priimek") );
            m_DBTables.items.Add(t_Atom_cLastName);
                        
        /* 148 */       
            t_Atom_cCardType_Person = new SQLTable((Object)new Atom_cCardType_Person(),"acardtper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cCardType_Person);
            t_Atom_cCardType_Person.AddColumn((Object)mt.m_Atom_cCardType_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cCardType_Person.AddColumn((Object)mt.m_Atom_cCardType_Person.CardType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card type", "Vrsta kartice") );
            m_DBTables.items.Add(t_Atom_cCardType_Person);
                        
        /* 149 */       
            t_Atom_cPhoneNumber_Person = new SQLTable((Object)new Atom_cPhoneNumber_Person(),"aphnnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cPhoneNumber_Person);
            t_Atom_cPhoneNumber_Person.AddColumn((Object)mt.m_Atom_cPhoneNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cPhoneNumber_Person.AddColumn((Object)mt.m_Atom_cPhoneNumber_Person.PhoneNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Phone number", "Telefon") );
            m_DBTables.items.Add(t_Atom_cPhoneNumber_Person);
                        
        /* 150 */       
            t_Atom_cGsmNumber_Person = new SQLTable((Object)new Atom_cGsmNumber_Person(),"agsmnper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cGsmNumber_Person);
            t_Atom_cGsmNumber_Person.AddColumn((Object)mt.m_Atom_cGsmNumber_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cGsmNumber_Person.AddColumn((Object)mt.m_Atom_cGsmNumber_Person.GsmNumber, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "GSM number", "gsm") );
            m_DBTables.items.Add(t_Atom_cGsmNumber_Person);
                        
        /* 151 */       
            t_Atom_cEmail_Person = new SQLTable((Object)new Atom_cEmail_Person(),"aemailper", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_cEmail_Person);
            t_Atom_cEmail_Person.AddColumn((Object)mt.m_Atom_cEmail_Person.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_cEmail_Person.AddColumn((Object)mt.m_Atom_cEmail_Person.Email, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Card type", "Vrsta kartice") );
            m_DBTables.items.Add(t_Atom_cEmail_Person);
                        
        /* 152 */       
            t_Atom_PersonImage = new SQLTable((Object)new Atom_PersonImage(),"aperimg", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_PersonImage);
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.Image_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Hash", "Identiteta slike") );
            t_Atom_PersonImage.AddColumn((Object)mt.m_Atom_PersonImage.Image_Data, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Image Data", "Slika") );
            m_DBTables.items.Add(t_Atom_PersonImage);


        /* 153 */
            t_Office =  new SQLTable((Object)new Office(),"office", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Office);
            t_Office.AddColumn((Object)mt.m_Office.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Office.AddColumn((Object)mt.m_Office.m_myCompany, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "My Company ID", "Moja oragnizacija ID") );
            t_Office.AddColumn((Object)mt.m_Office.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext( "Office Name", "Ime poslovne enote") );
            m_DBTables.items.Add(t_Office);


        /* 154 */
            t_Atom_Computer = new SQLTable((Object)new Atom_Computer(),"acomp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Computer);
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer Name", "Ime računalnika") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.UserName, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer UserName", "Računalniško prijavno ime") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.IP_address, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "IP address", "IP naslov") );
            t_Atom_Computer.AddColumn((Object)mt.m_Atom_Computer.MAC_address, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "MAC address", "MAC naslov") );
            m_DBTables.items.Add(t_Atom_Computer);

        /* 155 */
            t_WorkingPlace  = new SQLTable((Object)new WorkingPlace(),"wp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_WorkingPlace);
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place name", "Ime delovnega mesta") );
            t_WorkingPlace.AddColumn((Object)mt.m_WorkingPlace.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place description", "Opis delovnega mesta") );
            m_DBTables.items.Add(t_WorkingPlace);

        /* 156 */
            t_Atom_Office =  new SQLTable((Object)new Atom_Office(),"aoffice", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Office);
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.m_Atom_myCompany, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "My Company archive ID", "Moja oragnizacija arhiv ID") );
            t_Atom_Office.AddColumn((Object)mt.m_Atom_Office.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office Name archive", "Ime poslovne enote") );
            m_DBTables.items.Add(t_Atom_Office);

        /* 157 */
            t_Atom_WorkingPlace  = new SQLTable((Object)new Atom_WorkingPlace(),"awplace", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_WorkingPlace);
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place name", "Ime delovnega mesta") );
            t_Atom_WorkingPlace.AddColumn((Object)mt.m_Atom_WorkingPlace.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place description", "Opis delovnega mesta") );
            m_DBTables.items.Add(t_Atom_WorkingPlace);

        /* 158 */
            t_Atom_WorkPeriod  = new SQLTable((Object)new Atom_WorkPeriod(),"awperiod", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_WorkPeriod);
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_myCompany_Person, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Company Person archive ID", "Zaposleni arhiv ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_WorkingPlace, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Working place archive ID", "Ime delovnega mesta arhiv ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_Computer, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Computer_ID", "Computer_ID") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.LoginTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work start time", "Začetek dela") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.LogoutTime, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work end time", "Konec dela") );
            t_Atom_WorkPeriod.AddColumn((Object)mt.m_Atom_WorkPeriod.m_Atom_WorkPeriod_TYPE, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work end time", "Konec dela") );
            m_DBTables.items.Add(t_Atom_WorkPeriod);

        /* 159 */
            t_DeliveryType  = new SQLTable((Object)new DeliveryType(),"delt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_DeliveryType);
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type name", "Vrsta dobave") );
            t_DeliveryType.AddColumn((Object)mt.m_DeliveryType.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type description", "Opis vrste dobave") );
            m_DBTables.items.Add(t_DeliveryType);

        /* 160 */
            t_Delivery  = new SQLTable((Object)new Delivery(),"deliv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Delivery);
            t_Delivery.AddColumn((Object)mt.m_Delivery.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_DeliveryType, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery type ID", "Vrsta dobave ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_Stock, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Stock ID", "Zaloga ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.m_ProformaInvoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Proforma Invoice ID", "Račun ID") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.dQuantity, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Quantity", "Količina") );
            t_Delivery.AddColumn((Object)mt.m_Delivery.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery description", "Dobava opis") );
            m_DBTables.items.Add(t_Delivery);

        /* 161 */
            t_JOURNAL_Delivery_Type = new SQLTable((Object)new JOURNAL_Delivery_Type(),"jdelivt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Delivery_Type);
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type name", "Vrsta dobave") );
            t_JOURNAL_Delivery_Type.AddColumn((Object)mt.m_JOURNAL_Delivery_Type.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type description", "Vrsta opis") );
            m_DBTables.items.Add(t_JOURNAL_Delivery_Type);

        /* 162 */
            t_JOURNAL_Delivery  = new SQLTable((Object)new JOURNAL_Delivery(),"jdeliv", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_JOURNAL_Delivery);
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_JOURNAL_Delivery_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Journal Delivery type ID", "Vrsta dobave ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_Delivery, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Delivery ID", "Dobava ID") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event Time", "Čas dogodka") );
            t_JOURNAL_Delivery.AddColumn((Object)mt.m_JOURNAL_Delivery.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_Delivery);

        /* 163 */
            t_Office_Data  = new SQLTable((Object)new Office_Data(),"officed", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Office_Data);
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.m_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office ID", "Poslovna enota ID") );
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.m_cAddress_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office address ID", "Poslovna enota naslov ID") );
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.m_myCompany_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office CEA ID", "Vodja poslovne enote ID") );
            t_Office_Data.AddColumn((Object)mt.m_Office_Data.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office Description", "Poslovna enota opis") );
            m_DBTables.items.Add(t_Office_Data);

        /* 164 */
            t_Atom_Office_Data = new SQLTable((Object)new Atom_Office_Data(),"aofficed", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_Office_Data);
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.m_Atom_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office archive ID", "Poslovna enota arhiv ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.m_Atom_cAddress_Org, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office address archive ID", "Poslovna enota naslov arhiv ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.m_Atom_myCompany_Person, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office CEA archive ID", "Vodja poslovne enote arhiv ID") );
            t_Atom_Office_Data.AddColumn((Object)mt.m_Atom_Office_Data.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Office Description", "Poslovna enota opis") );
            m_DBTables.items.Add(t_Atom_Office_Data);

        /* 165 */
            t_Atom_WorkPeriod_TYPE  = new SQLTable((Object)new Atom_WorkPeriod_TYPE(),"awperiodt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_WorkPeriod_TYPE);
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type name", "Naziv vrste šihta") );
            t_Atom_WorkPeriod_TYPE.AddColumn((Object)mt.m_Atom_WorkPeriod_TYPE.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type description", "Naziv vrste šihta opis") );
            m_DBTables.items.Add(t_Atom_WorkPeriod_TYPE);

        /* 166 */
            t_Atom_WorkPeriod_Descrition  = new SQLTable((Object)new Atom_WorkPeriod_Description(),"awperiodd", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_Atom_WorkPeriod_Descrition);
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            t_Atom_WorkPeriod_Descrition.AddColumn((Object)mt.m_Atom_WorkPeriod_Description.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Workshift type description", "Naziv vrste šihta opis") );
            m_DBTables.items.Add(t_Atom_WorkPeriod_Descrition);


         /* 167 */
            t_doc_type = new SQLTable((Object)new doc_type(), "doctype", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_doc_type);
            t_doc_type.AddColumn((Object)mt.m_doc_type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type name", "Ime vrste dokumenta"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type description", "Opis vrste dokumenta"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.m_Language, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Language ID", "Jezik ID"));
            t_doc_type.AddColumn((Object)mt.m_doc_type.m_doc_page_type, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page type ID", "Oblika strani ID"));
            m_DBTables.items.Add(t_doc_type);

        /* 168 */
            t_doc = new SQLTable((Object)new doc(), "doc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_doc);
            t_doc.AddColumn((Object)mt.m_doc.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc.AddColumn((Object)mt.m_doc.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document name", "Ime dokumenta"));
            t_doc.AddColumn((Object)mt.m_doc.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document description", "Opis dokumenta"));
            t_doc.AddColumn((Object)mt.m_doc.xDocument, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document", "Dokument"));
            t_doc.AddColumn((Object)mt.m_doc.xDocument_Hash, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new ltext("Document HASH", "Dokument HASH"));
            t_doc.AddColumn((Object)mt.m_doc.Active, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Active", "V uporabi"));
            t_doc.AddColumn((Object)mt.m_doc.bDefault, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Default", "Privzeti dokument"));
            t_doc.AddColumn((Object)mt.m_doc.Compressed, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Compressed", "Stisnjen"));
            t_doc.AddColumn((Object)mt.m_doc.m_doc_type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document type ID", "Vrsta dokumenta ID"));
            m_DBTables.items.Add(t_doc);

         /* 169 */
            t_JOURNAL_doc_Type = new SQLTable((Object)new JOURNAL_doc_Type(), "jdoct", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_JOURNAL_doc_Type);
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("HTML template event name", "Ime dogodka HTML predloge"));
            t_JOURNAL_doc_Type.AddColumn((Object)mt.m_JOURNAL_doc_Type.Description, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("HTML template event description", "Opis dogodka HTML predloge"));
            m_DBTables.items.Add(t_JOURNAL_doc_Type);

        /* 170 */
            t_JOURNAL_doc  = new SQLTable((Object)new JOURNAL_doc(), "jdoc", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_JOURNAL_doc);
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext( "ID", "ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_JOURNAL_doc_Type, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document event name ID", "Dogodek dokumenta ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_doc, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Document ID", "Dokument ID") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_ProformaInvoice, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Proforma Invoice ID", "(Pred)Račun ID"));
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.EventTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Event Time", "Čas dogodka") );
            t_JOURNAL_doc.AddColumn((Object)mt.m_JOURNAL_doc.m_Atom_WorkPeriod, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext( "Work shift ID", "Šiht ID") );
            m_DBTables.items.Add(t_JOURNAL_doc);

        /* 171 */
            t_Language = new SQLTable((Object)new Language(), "lng", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_Language);
            t_Language.AddColumn((Object)mt.m_Language.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_Language.AddColumn((Object)mt.m_Language.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Language", "Jezik"));
            t_Language.AddColumn((Object)mt.m_Language.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Description", "Opis"));
            t_Language.AddColumn((Object)mt.m_Language.bDefault, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Default", "Privzeti jezik"));
            m_DBTables.items.Add(t_Language);

         /* 172 */
            t_doc_page_type = new SQLTable((Object)new doc_page_type(), "pgt", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_doc_page_type);
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page Name", "Ime strani"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Description, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page Description", "Opis strani"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Width, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page width (mm)", "Širina strani (mm)"));
            t_doc_page_type.AddColumn((Object)mt.m_doc_page_type.Height, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Page height (mm)", "Višina strani (mm)"));
            m_DBTables.items.Add(t_doc_page_type);


         /* 173 */
            t_FVI_SLO_RealEstateBP = new SQLTable((Object)new FVI_SLO_RealEstateBP(), "fvislore", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_FVI_SLO_RealEstateBP);
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.m_Office, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Office ID", "Poslovna enota ID"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.BuildingNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingNumber", "Številka stavbe"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.BuildingSectionNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("BuildingSectionNumber", "Številka dela stavbe"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.Community, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Community", "Naselje"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.CadastralNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("CadastralNumber", "Številka katastrske občine"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ValidityDate, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ValidityDate", "Datum začetka veljavnosti podatkov"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.ClosingTag, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("ClosingTag", "ZaprtjePoslovnegaProstora"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.SoftwareSupplier_TaxNumber, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SW supplier tax number", "Davčna številka dobavitelja programske opreme ali vzdrževalca"));
            t_FVI_SLO_RealEstateBP.AddColumn((Object)mt.m_FVI_SLO_RealEstateBP.PremiseType, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Premise Type", "Vrsta poslovnega prostora"));
            m_DBTables.items.Add(t_FVI_SLO_RealEstateBP);


        /* 174 */
            t_FVI_SLO_Response = new SQLTable((Object)new FVI_SLO_Response(), "fvisloresp", Column.Flags.FILTER_AND_UNIQUE, lngTName.lngt_t_FVI_SLO_Response); ;
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.m_Invoice, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Invoice ID", "Račun ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.MessageID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Message ID", "Transakcija ID"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.UniqueInvoiceID, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("UniqueInvoiceID", "Enkratna identifikacijska oznaka računa"));
            t_FVI_SLO_Response.AddColumn((Object)mt.m_FVI_SLO_Response.Response_DateTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Response Time", "Čas odgovora"));
            m_DBTables.items.Add(t_FVI_SLO_Response);

        }
    }
 }

