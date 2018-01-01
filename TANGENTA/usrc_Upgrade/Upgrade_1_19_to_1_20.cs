using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaDB;

namespace UpgradeDB
{
    internal static class Upgrade_1_19_to_1_20
    {
        internal static object UpgradeDB_1_19_to_1_20(object obj, ref string Err)
        {
            string sql = @"
                            PRAGMA foreign_keys = OFF;

                            DROP TABLE Notice;

                            CREATE TABLE Atom_PriceList_Name 
                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL 
                            );

                            CREATE TABLE Atom_PriceList_new 
                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            Atom_PriceList_Name_ID INTEGER NOT NULL REFERENCES Atom_PriceList_Name(ID),
                            'Valid' BIT NOT NULL,
                            'ValidFrom' DATETIME NULL,
                            'ValidTo' DATETIME NULL,
                            'Description' varchar(2000) NULL,
                            Atom_Currency_ID INTEGER NOT NULL REFERENCES Atom_Currency(ID) 
                            );

                            CREATE TABLE PriceList_Name 
                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                              'Name' varchar(264) NOT NULL 
                            );

                            CREATE TABLE PriceList_new 
                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                              PriceList_Name_ID INTEGER NOT NULL REFERENCES PriceList_Name(ID),
                              'Valid' BIT NOT NULL,
                              Currency_ID INTEGER NOT NULL REFERENCES Currency(ID),
                              'ValidFrom' DATETIME NULL,
                              'ValidTo' DATETIME NULL,
                              'CreationDate' DATETIME NULL,
                              'Description' varchar(2000) NULL );
                             
                              insert into PriceList_Name (Name) values select Name from PriceList;

                              insert into PriceList_new
                              (
                              ID,
                              PriceList_Name_ID,
                              Valid,
                              Currency_ID,
                              ValidFrom,
                              ValidTo,
                              CreationDate,
                              Description
                              )
                              select 
                              pl.ID,
                              pln.ID,
                              pl.Valid,
                              pl.Currency_ID,
                              pl.ValidFrom,
                              pl.ValidTo,
                              pl.CreationDate,
                              pl.Description
                              from PriceList pl
                              inner join PriceList_Name pln on pln.Name = pl.Name;

                              insert into Atom_PriceList_Name (Name) values select Name from Atom_PriceList;

                              insert into Atom_PriceList_new
                              (
                                ID,
                              Atom_PriceList_Name_ID,
                              Valid,
                              Currency_ID,
                              ValidFrom,
                              ValidTo,
                              CreationDate,
                              Description
                              )
                              select 
                              apl.ID,
                              apln.ID,
                              apl.Valid,
                              apl.Currency_ID,
                              apl.ValidFrom,
                              apl.ValidTo,
                              apl.CreationDate,
                              apl.Description
                              from Atom_PriceList apl
                              inner join Atom_PriceList_Name apln on apln.Name = apl.Name;

                              DROP TABLE PriceList;

                              ALTER TABLE PriceList_new RENAME TO PriceList;

                              DROP TABLE Atom_PriceList;

                              ALTER TABLE Atom_PriceList_new RENAME TO Atom_PriceList;

                              PRAGMA foreign_keys = ON;

                             ";

            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
            string[] new_tables = new string[] {"Notice",
                                                "Atom_Notice",
                                                "DocInvoice",
                                                "DocInvoiceAddOn",
                                                "DocProformaInvoice",
                                                "DocProformaInvoiceAddOn",
                                                "DocInvoice_ShopC_Item",
                                                "DocProformaInvoice_ShopC_Item",
                                                "DocInvoice_ShopB_Item",
                                                "DocProformaInvoice_ShopB_Item",
                                                "Doc_ImageLib",
                                                "JOURNAL_DocInvoice_Type",
                                                "JOURNAL_DocProformaInvoice_Type",
                                                "JOURNAL_DocInvoice",
                                                "JOURNAL_DocProformaInvoice",
                                                "DocInvoice_ShopA_Item",
                                                "DocProformaInvoice_ShopA_Item",
                                                "Atom_Bank",
                                                "Atom_BankAccount",
                                                "Atom_OrganisationAccount",
                                                "Atom_PersonData",
                                                "Atom_PersonAccount",
                                                "JOURNAL_Name",
                                                "JOURNAL_TableName",
                                                "JOURNAL_TYPE",
                                                "JOURNAL",
                                                "PaymentType",
                                                "MethodOfPayment_DI",
                                                "MethodOfPayment_DPI",
                                                "Atom_Comment1",
                                                "Comment1"
                                                };

            if (DBSync.DBSync.CreateTables(new_tables, ref Err))
            {
                PaymentType_definitions xpaymentType_definitions = new PaymentType_definitions();
                if (!xpaymentType_definitions.Get())
                {
                    return false;
                }

                sql = @"       ALTER TABLE Organisation ADD COLUMN TaxPayer BIT NULL; 
                               ALTER TABLE Atom_Organisation ADD COLUMN TaxPayer BIT NULL; 
                               ALTER TABLE Organisation ADD COLUMN Comment1_ID INTEGER NULL REFERENCES Comment1(ID); 
                               ALTER TABLE Atom_Organisation ADD COLUMN Atom_Comment1_ID INTEGER NULL REFERENCES Atom_Comment1(ID); 
                               insert into Comment1 (Comment)values('Davčni zavezanec za DDV:DA'); 
                               insert into Atom_Comment1 (Comment)values('Davčni zavezanec za DDV:DA'); 
                               Update Organisation set TaxPayer = 1,
                                                 Comment1_ID = 1
                                                 where Tax_ID = '19300808';
                                Update Atom_Organisation set TaxPayer = 1,
                                                    Atom_Comment1_ID = 1
                                                    where Tax_ID = '19300808';
                             ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }


                TermsOfPayment_definitions tmpdef = new TermsOfPayment_definitions();
                tmpdef.InsertDefault();

                long_v PaymentType_ID_v = null;
                string_v sPaymentType_v = null;
                long_v CASH_MethodOfPayment_DI_v = null;
                long_v CARD_MethodOfPayment_DI_v = null;
                long_v ALLREADY_PAID_MethodOfPayment_DI_v = null;

                if (!f_MethodOfPayment_DI.Get(GlobalData.ePaymentType.CASH, null, ref PaymentType_ID_v, ref sPaymentType_v, ref CASH_MethodOfPayment_DI_v))
                {
                    return false;
                }
                if (!f_MethodOfPayment_DI.Get(GlobalData.ePaymentType.CARD, null, ref PaymentType_ID_v, ref sPaymentType_v, ref CARD_MethodOfPayment_DI_v))
                {
                    return false;
                }
                if (!f_MethodOfPayment_DI.Get(GlobalData.ePaymentType.ALLREADY_PAID, null, ref PaymentType_ID_v, ref sPaymentType_v, ref ALLREADY_PAID_MethodOfPayment_DI_v))
                {
                    return false;
                }

                sql = @"PRAGMA foreign_keys = OFF;
                               insert into JOURNAL_DocInvoice_Type (Name,Description) select Name,Description from JOURNAL_ProformaInvoice_Type;
                               insert into JOURNAL_DocInvoice_Type (Name,Description) select Name,Description from JOURNAL_Invoice_Type;
                               update Invoice set MethodOfPayment_ID = 3 where MethodOfPayment_ID is null;
                               insert into DocInvoiceAddOn
                               (
                                 DocInvoice_ID,
                                 IssueDate,
                                 TermsOfPayment_ID,
                                 MethodOfPayment_DI_ID,
                                 Atom_Warranty_ID,
                                 PaymentDeadline
                               )
                               select 
                                pi.ID,
                                jpi.EventTime,
                                " + tmpdef.Advanced_100PercentPayment_ID_v.v.ToString() + @",
                                inv.MethodOfPayment_ID,
                                null,
                                null
                                from ProformaInvoice pi
								inner join JOURNAL_ProformaInvoice jpi on jpi.ProformaInvoice_ID = pi.ID
								inner join JOURNAL_ProformaInvoice_TYPE jpit on jpit.ID = jpi.JOURNAL_ProformaInvoice_TYPE_ID and ((jpit.ID = 2) OR (jpit.ID = 4) OR ((jpit.ID = 1)and(pi.Draft=1)))
                                left join Invoice inv on pi.Invoice_ID = inv.ID;

                               insert into DocInvoice
                               (
                               Draft,
                               DraftNumber,
                               FinancialYear,
                               NumberInFinancialYear,
                               NetSum,
                               Discount,
                               EndSum,
                               TaxSum,
                               GrossSum,
                               Atom_Currency_ID,
                               Atom_Customer_Person_ID,
                               Atom_Customer_Org_ID,
                               Paid,
                               Storno,
                               Invoice_Reference_ID,
                               Invoice_Reference_Type
                               )
                               select 
                                pi.Draft,
                                pi.DraftNumber,
                                pi.FinancialYear,
                                pi.NumberInFinancialYear,
                                pi.NetSum,
                                pi.Discount,
                                pi.EndSum,
                                pi.TaxSum,
                                pi.GrossSum,
                                1,
                                pi.Atom_Customer_Person_ID,
                                pi.Atom_Customer_Org_ID,
                                inv.Paid,
                                inv.Storno,
                                inv.Invoice_Reference_ID,
                                inv.Invoice_Reference_Type
                                from ProformaInvoice pi
                                left join Invoice inv on pi.Invoice_ID = inv.ID;

                                Insert into DocInvoice_ShopA_Item
                                (
                                    DocInvoice_ID,
                                    Atom_ItemShopA_ID,
                                    Discount,
                                    dQuantity,
                                    PricePerUnit,
                                    EndPriceWithDiscountAndTax,
                                    TAX
                                )
                                select
                                    ProformaInvoice_ID,
                                    Atom_ItemShopA_ID,
                                    Discount,    
                                    dQuantity,
                                    PricePerUnit,
                                    EndPriceWithDiscountAndTax,
                                    TAX
                                from Atom_ItemShopA_Price;

                                Insert into DocInvoice_ShopB_Item
                                (
                                    RetailSimpleItemPrice,
                                    Discount,
                                    iQuantity,
                                    RetailSimpleItemPriceWithDiscount,
                                    ExtraDiscount,
                                    TaxPrice,
                                    Atom_SimpleItem_ID,
                                    Atom_PriceList_ID,
                                    Atom_Taxation_ID,
                                    DocInvoice_ID   
                                )
                                select
                                    RetailSimpleItemPrice,
                                    Discount,
                                    iQuantity,
                                    RetailSimpleItemPriceWithDiscount,
                                    ExtraDiscount,
                                    TaxPrice,
                                    Atom_SimpleItem_ID,
                                    Atom_PriceList_ID,
                                    Atom_Taxation_ID,
                                    ProformaInvoice_ID
                                from Atom_Price_SimpleItem;

                                Insert into DocInvoice_ShopC_Item
                                (
                                    dQuantity,
                                    ExtraDiscount,
                                    RetailPriceWithDiscount,
                                    TaxPrice,
                                    DocInvoice_ID,
                                    Atom_Price_Item_ID,
                                    ExpiryDate,
                                    Stock_ID
                                )
                                select
                                   dQuantity,
                                   ExtraDiscount,
                                   RetailPriceWithDiscount,
                                   TaxPrice,
                                   ProformaInvoice_ID,
                                   Atom_Price_Item_ID,
                                   ExpiryDate,
                                   Stock_ID
                                from Atom_ProformaInvoice_Price_Item_Stock;
                                PRAGMA foreign_keys = ON;
                ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                sql = @" DROP TABLE IF EXISTS JOURNAL_DocInvoice_temp;
                          CREATE TABLE JOURNAL_DocInvoice_temp
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           JOURNAL_DocInvoice_Type_ID  INTEGER  NOT NULL REFERENCES JOURNAL_DocInvoice_Type(ID),
                           DocInvoice_ID  INTEGER  NULL REFERENCES DocInvoice(ID),
                          'EventTime' DATETIME NULL,
                           Atom_WorkPeriod_ID  INTEGER  NOT NULL REFERENCES Atom_WorkPeriod(ID)
                          );

                          insert into JOURNAL_DocInvoice_temp
                          (
                            JOURNAL_DocInvoice_Type_ID,
                            DocInvoice_ID,
                            EventTime,
                            Atom_WorkPeriod_ID
                          )
                        select
                                JOURNAL_ProformaInvoice_Type_ID,
                                ProformaInvoice_ID,
                                EventTime,
                                Atom_WorkPeriod_ID
                            from JOURNAL_ProformaInvoice;

                          insert into JOURNAL_DocInvoice_temp
                          (
                            JOURNAL_DocInvoice_Type_ID,
                            DocInvoice_ID,
                            EventTime,
                            Atom_WorkPeriod_ID
                          )
                            select
                                ji.JOURNAL_Invoice_Type_ID + 6 as JOURNAL_DocInvoice_Type_ID,
                                pi.ID,
                                ji.EventTime as ji_EventTime,
                                ji.Atom_WorkPeriod_ID as ji_Atom_WorkPeriod_ID
                                from JOURNAL_Invoice ji
                                inner join ProformaInvoice pi on pi.Invoice_ID = ji.ID;

                          insert into JOURNAL_DocInvoice
                          (
                            JOURNAL_DocInvoice_Type_ID,
                            DocInvoice_ID,
                            EventTime,
                            Atom_WorkPeriod_ID
                          )
                          select 
                            JOURNAL_DocInvoice_Type_ID,
                            DocInvoice_ID,
                            EventTime,
                            Atom_WorkPeriod_ID
                            from JOURNAL_DocInvoice_temp order by EventTime asc;

                           DROP TABLE JOURNAL_DocInvoice_temp;

                      ALTER TABLE FVI_SLO_Response RENAME TO FVI_SLO_Response_temp;

                      CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL,
                      'TestEnvironment' BIT NULL
                      );

                    insert into FVI_SLO_Response
                    (
                        DocInvoice_ID,
                        MessageID,
                        UniqueInvoiceID,
                        BarCodeValue,
                        Response_DateTime
                    )
                    select 
                        pi.ID,
                        MessageID,
                        UniqueInvoiceID,
                        BarCodeValue,
                        Response_DateTime
                    from FVI_SLO_Response_temp fsit
                    inner join ProformaInvoice pi on pi.Invoice_ID = fsit.Invoice_ID;

                    DROP TABLE FVI_SLO_Response_temp;

                    ALTER TABLE FVI_SLO_SalesBookInvoice RENAME TO FVI_SLO_SalesBookInvoice_temp;

                    CREATE TABLE FVI_SLO_SalesBookInvoice
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                      'InvoiceNumber' varchar(25) NOT NULL,
                      'SetNumber' varchar(5) NOT NULL,
                      'SerialNumber' varchar(25) NOT NULL
                      );

                    insert into FVI_SLO_SalesBookInvoice
                    (
                        DocInvoice_ID,
                        InvoiceNumber,
                        SetNumber,
                        SerialNumber
                    )
                    select 
                        pi.ID,
                        InvoiceNumber,
                        SetNumber,
                        SerialNumber
                    from FVI_SLO_SalesBookInvoice_temp fsbit
                    inner join ProformaInvoice pi on pi.Invoice_ID = fsbit.Invoice_ID;

                    DROP TABLE FVI_SLO_SalesBookInvoice_temp;

                    ";

                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Drop_VIEWs(ref Err))
                    {

                        sql = @"Drop Table Atom_ProformaInvoice_Price_Item_Stock;
                                Drop Table Atom_Price_SimpleItem;
                                Drop Table Atom_ItemShopA_Price;
                                Drop Table JOURNAL_ProformaInvoice;
                                Drop Table JOURNAL_Invoice;
                                Drop Table JOURNAL_ProformaInvoice_TYPE;
                                Drop Table JOURNAL_Invoice_TYPE;
                                Drop Table JOURNAL_Delivery;
                                Drop Table JOURNAL_Delivery_TYPE;
                                Drop Table Delivery;
                                Drop Table ProformaInvoice_Notice;
                                Drop Table ProformaInvoice_ImageLib;
                                Drop Table Invoice_Image;
                                Drop Table ProformaInvoice;
                                Drop Table Invoice;
                                Drop Table MethodOfPayment;
                        ";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = @"
                                  PRAGMA foreign_keys = OFF;

                                  CREATE TABLE AccessR 
                                  ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                    'Name' varchar(264) UNIQUE NOT NULL UNIQUE ,
                                    'Description' varchar(2000) NOT NULL 
                                  );

                                  CREATE TABLE myOrganisation
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   OrganisationData_ID  INTEGER  NOT NULL REFERENCES OrganisationData(ID) UNIQUE 
                                  );

                                  CREATE TABLE Atom_myOrganisation
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   Atom_OrganisationData_ID  INTEGER  NOT NULL REFERENCES Atom_OrganisationData(ID)  
                                  );

                                 CREATE TABLE JOURNAL_myOrganisation_Type
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Name' varchar(264) NOT NULL,
                                  'Description' varchar(2000) NULL
                                  );

                                 CREATE TABLE JOURNAL_myOrganisation
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   JOURNAL_myOrganisation_Type_ID  INTEGER  NOT NULL REFERENCES JOURNAL_myOrganisation_Type(ID),
                                   myOrganisation_ID  INTEGER  NOT NULL REFERENCES myOrganisation(ID),
                                  'EventTime' DATETIME NOT NULL,
                                   Atom_WorkPeriod_ID  INTEGER  NOT NULL REFERENCES Atom_WorkPeriod(ID)
                                  );

                                 CREATE TABLE JOURNAL_myOrganisation_Person_Type
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Name' varchar(264) NOT NULL,
                                  'Description' varchar(2000) NULL
                                  );

                                CREATE TABLE myOrganisation_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'UserName' varchar(32) UNIQUE  NOT NULL UNIQUE ,
                                  'Password' varchar(32) NULL,
                                  'Job' varchar(264) NULL,
                                  'Active' BIT NOT NULL,
                                  'Description' varchar(2000) NULL,
                                   Person_ID  INTEGER  NOT NULL REFERENCES Person(ID),
                                   Office_ID  INTEGER  NOT NULL REFERENCES Office(ID)
                                  );

                                CREATE TABLE JOURNAL_myOrganisation_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   JOURNAL_myOrganisation_Person_Type_ID  INTEGER  NOT NULL REFERENCES JOURNAL_myOrganisation_Person_Type(ID),
                                   myOrganisation_Person_ID  INTEGER  NOT NULL REFERENCES myOrganisation_Person(ID),
                                  'EventTime' DATETIME NOT NULL,
                                   Atom_WorkPeriod_ID  INTEGER  NOT NULL REFERENCES Atom_WorkPeriod(ID)
                                  );

                                CREATE TABLE myOrganisation_Person_AccessR
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   AccessR_ID  INTEGER  NOT NULL REFERENCES AccessR(ID),
                                   myOrganisation_Person_ID  INTEGER  NOT NULL REFERENCES myCompany_Person(ID) 
                                  );


                                CREATE TABLE Atom_myOrganisation_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'UserName' varchar(32) NOT NULL,
                                   Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                                   Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                                  'Job' varchar(264) NULL,
                                  'Description' varchar(2000) NULL
                                  );

                                CREATE TABLE Atom_WorkPeriod_new
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   Atom_myOrganisation_Person_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation_Person(ID),
                                   Atom_WorkingPlace_ID  INTEGER  NOT NULL REFERENCES Atom_WorkingPlace(ID),
                                   Atom_Computer_ID  INTEGER  NOT NULL REFERENCES Atom_Computer(ID),
                                  'LoginTime' DATETIME NULL,
                                  'LogoutTime' DATETIME NULL,
                                   Atom_WorkPeriod_TYPE_ID  INTEGER  NULL REFERENCES Atom_WorkPeriod_TYPE(ID)
                                );

                                CREATE TABLE JOURNAL_myOrganisation_Person_AccessR_TYPE
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Name' varchar(264) NOT NULL,
                                  'Description' varchar(2000) NULL
                                  );

                                CREATE TABLE JOURNAL_myOrganisation_Person_AccessR
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  myOrganisation_Person_AccessR_TYPE_ID INTEGER  NOT NULL REFERENCES myOrganisation_Person_AccessR_TYPE(ID),
                                  myOrganisation_Person_AccessR_ID INTEGER  NOT NULL REFERENCES myOrganisation_Person_AccessR(ID),
                                  'EventTime' DATETIME NOT NULL,
                                   Atom_WorkPeriod_ID  INTEGER  NOT NULL REFERENCES Atom_WorkPeriod(ID)
                                  );

                                CREATE TABLE Office_new
                                (
                                 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  myOrganisation_ID  INTEGER  NOT NULL REFERENCES myOrganisation(ID),
                                 'Name' varchar(264) UNIQUE NOT NULL,
                                 'ShortName' varchar(10) UNIQUE  NOT NULL
                                );

                                CREATE TABLE Atom_Office_new
                                (
                                'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                 Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                                'Name' varchar(264) UNIQUE NOT NULL,
                                'ShortName' varchar(10) UNIQUE  NOT NULL
                                );

                                insert into AccessR
                                (
                                    'Name',
                                    'Description'
                                )
                                select
                                    'Name',
                                    'Description'
                                    from AccessRights;

                                insert into myOrganisation
                                (
                                  OrganisationData_ID
                                )
                                select
                                  OrganisationData_ID
                                from myCompany;


                                insert into myOrganisation_Person
                                (
                                  UserName,
                                  Password,
                                  Job,
                                  Active,
                                  Description,
                                  Person_ID,
                                  Office_ID
                                )
                                select
                                  UserName,
                                  Password,
                                  Job,
                                  Active,
                                  Description,
                                  Person_ID,
                                  Office_ID
                                from myCompany_Person;

                                insert into myOrganisation_Person_AccessR
                                  (
                                   AccessR_ID,
                                   myOrganisation_Person_ID
                                  )
                                  select
                                   AccessRights_ID,
                                   myCompany_Person_ID
                                 from myCompany_Person_AccessRights;


                                insert into Atom_myOrganisation_Person
                                (
                                  UserName,
                                  Job,
                                  Description,
                                  Atom_Person_ID,
                                  Atom_Office_ID
                                )
                                select
                                  UserName,
                                  Job,
                                  Description,
                                  Atom_Person_ID,
                                  Atom_Office_ID
                                from Atom_myCompany_Person;

                                insert into Atom_myOrganisation
                                (
                                    Atom_OrganisationData_ID
                                )
                                select
                                  Atom_OrganisationData_ID
                                from Atom_myCompany;

                                insert into Atom_WorkPeriod_new
                                  (
                                   Atom_myOrganisation_Person_ID,
                                   Atom_WorkingPlace_ID,
                                   Atom_Computer_ID,
                                   LoginTime,
                                   LogoutTime,
                                   Atom_WorkPeriod_TYPE_ID
                                  )
                                select
                                  Atom_myCompany_Person_ID,
                                  Atom_WorkingPlace_ID,
                                  Atom_Computer_ID,
                                  LoginTime,
                                  LogoutTime,
                                  Atom_WorkPeriod_TYPE_ID
                                from Atom_WorkPeriod;

                                insert into Office_new
                                (
                                 myOrganisation_ID,
                                 Name,
                                 ShortName
                                )
                                select
                                  myCompany_ID,
                                  Name,
                                  ShortName
                                from Office;

                                insert into Atom_Office_new
                                (
                                    Atom_myOrganisation_ID,
                                    Name,
                                    ShortName
                                )
                                select
                                  Atom_myCompany_ID,
                                  Name,
                                  ShortName
                                from Atom_Office;


                                DROP TABLE Atom_Office;
                                ALTER TABLE Atom_Office_new RENAME TO Atom_Office;


                                DROP TABLE Office;
                                ALTER TABLE Office_new RENAME TO Office;

                                DROP TABLE Atom_WorkPeriod;
                                ALTER TABLE Atom_WorkPeriod_new RENAME TO Atom_WorkPeriod;
                                Drop Table JOURNAL_myCompany;
                                Drop Table JOURNAL_myCompany_TYPE;
                                Drop Table myCompany_Person_AccessRights;
                                Drop Table myCompany_Person;
                                Drop Table Atom_myCompany_Person;
                                Drop Table Atom_myCompany;
                                Drop Table myCompany;
                                Drop Table AccessRights;

                                CREATE TABLE Language_NEW ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,'LanguageIndex' INT NOT NULL UNIQUE, 'Name' varchar(264) NOT NULL, 'Description' varchar(2000) NULL, 'bDefault' BIT NULL );

                                PRAGMA foreign_keys = ON;

                                ";

                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                DataTable dtLanguage = new DataTable();
                                sql = "select Name,Description,bDefault from Language";
                                if (!DBSync.DBSync.ReadDataTable(ref dtLanguage, sql, null, ref Err))
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                                int iCount = dtLanguage.Rows.Count;
                                for (int i = 0; i < iCount; i++)
                                {
                                    List<SQL_Parameter> lparx = new List<SQL_Parameter>();

                                    string spar_LanguageIndex = "@par_LanguageIndex";
                                    SQL_Parameter par_LanguageIndex = new SQL_Parameter(spar_LanguageIndex, SQL_Parameter.eSQL_Parameter.Int, false, i);
                                    lparx.Add(par_LanguageIndex);

                                    string Name = (string)dtLanguage.Rows[i]["Name"];
                                    string spar_Name = "@par_Name";
                                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
                                    lparx.Add(par_Name);

                                    object oDescription = dtLanguage.Rows[i]["Description"];
                                    string sval_Description = "null";
                                    if (oDescription is string)
                                    {
                                        string spar_Description = "@par_Description";
                                        SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, (string)oDescription);
                                        lparx.Add(par_Description);
                                        sval_Description = spar_Description;
                                    }

                                    object obDefault = dtLanguage.Rows[i]["bDefault"];
                                    string sval_bDefault = "null";
                                    if (obDefault is bool)
                                    {
                                        string spar_bDefault = "@par_bDefault";
                                        SQL_Parameter par_bDefault = new SQL_Parameter(spar_bDefault, SQL_Parameter.eSQL_Parameter.Bit, false, (bool)obDefault);
                                        lparx.Add(par_bDefault);
                                        sval_bDefault = spar_bDefault;
                                    }
                                    sql = "insert into Language_NEW (LanguageIndex,Name,Description,bDefault)values(" + spar_LanguageIndex + "," + spar_Name + "," + sval_Description + "," + sval_bDefault + ")";
                                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, lparx, ref Err))
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }
                                }
                                sql = @"            PRAGMA foreign_keys = OFF;
                                        DROP TABLE Language;
                                        ALTER TABLE Language_NEW RENAME TO Language;
                                        PRAGMA foreign_keys = ON;
                                        ";
                                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }

                                string sdb = DBSync.DBSync.DataBase;

                                if (sdb.Contains("StudioMarjetka"))
                                {
                                    sql = "update Atom_WorkPeriod set Atom_myOrganisation_Person_ID = 2";
                                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }

                                }

                                new_tables = new string[] {"Delivery",
                                                "JOURNAL_Delivery_Type",
                                                "JOURNAL_Delivery"
                                                };
                                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                                {
                                    if (DBSync.DBSync.Create_VIEWs())
                                    {
                                        UpgradeDB_inThread.Set_DataBase_Version("1.20");
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Err = "ERROR:function UpgradeDB_1_19_to_1_20 not implemented";
                return false;
            }
        }

    }
}
