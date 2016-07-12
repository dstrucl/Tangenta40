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
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using DBConnectionControl40;
using LanguageControl;
using DBTypes;
using TangentaDB;
using ThreadProcessor;
using System.ComponentModel;
using System.IO;
using Startup;

namespace UpgradeDB
{
    public partial class UpgradeDB_inThread :Component
    {
        public class Upgrade
        {
            public string DBVersion = null;
            public ThreadP_Message.delegate_Procedure procedure;
            public Upgrade(string DBVer, ThreadP_Message.delegate_Procedure proc)
            {
                DBVersion = DBVer;
                procedure = proc;
            }
        }


        private Control m_parent_ctrl = null;
        public string m_Full_backup_filename = null;

        public delegate void delegate_Backup();
        public event delegate_Backup Backup;
        public enum eUpgrade { none, from_1_04_to_105 };
        public Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05 = null;
        internal eUpgrade m_eUpgrade = eUpgrade.none;
        Database_Upgrade_WindowsForm_Thread wfp_ui_thread = null;
        List<TableDataItem> TableDataItem_List = new List<TableDataItem>();

        public Upgrade[] UpgradeArray = null;

        public UpgradeDB_inThread(Control xparent_ctrl )
        {
            m_parent_ctrl = xparent_ctrl;
            UpgradeArray = new Upgrade[]
            {
                new Upgrade("1.0",UpgradeDB_1_0_to_1_01),
                new Upgrade("1.01",UpgradeDB_1_01_to_1_02),
                new Upgrade("1.02",UpgradeDB_1_02_to_1_03),
                new Upgrade("1.03",UpgradeDB_1_03_to_1_04),
                new Upgrade("1.04",UpgradeDB_1_04_to_1_05),
                new Upgrade("1.05",UpgradeDB_1_05_to_1_06),
                new Upgrade("1.06",UpgradeDB_1_06_to_1_07),
                new Upgrade("1.07",UpgradeDB_1_07_to_1_08),
                new Upgrade("1.08",UpgradeDB_1_08_to_1_09),
                new Upgrade("1.09",UpgradeDB_1_09_to_1_10),
                new Upgrade("1.10",UpgradeDB_1_10_to_1_11),
                new Upgrade("1.11",UpgradeDB_1_11_to_1_12),
                new Upgrade("1.12",UpgradeDB_1_12_to_1_13),
                new Upgrade("1.13",UpgradeDB_1_13_to_1_14),
                new Upgrade("1.14",UpgradeDB_1_14_to_1_15),
                new Upgrade("1.15",UpgradeDB_1_15_to_1_16),
                new Upgrade("1.16",UpgradeDB_1_16_to_1_17),
                new Upgrade("1.17",UpgradeDB_1_17_to_1_18),
                new Upgrade("1.18",UpgradeDB_1_18_to_1_19),
                new Upgrade("1.19",UpgradeDB_1_19_to_1_20)
            };
        }
        public bool UpgradeDB(string sOldDBVersion, string sNewDBVersion, ref string Err, string xBackupFileName)
        {
            int i = 0;
            int iCount = UpgradeArray.Length;
            for (i = 0; i < iCount; i++)
            {
                if (UpgradeArray[i].DBVersion.Equals(sOldDBVersion))
                {
                    int j = i;
                    Form_Upgrade_inThread frm_upgr = new Form_Upgrade_inThread(this, UpgradeArray, j, xBackupFileName);
                    frm_upgr.ShowDialog();
                }
            }
            return true;
        }

        private object UpgradeDB_1_19_to_1_20(object obj, ref string Err)
        {
            string[] new_tables = new string[] {"DocInvoice",
                                                "DocProformaInvoice",
                                                "DocInvoice_ShopC_Item",
                                                "DocProformaInvoice_ShopC_Item",
                                                "DocInvoice_ShopB_Item",
                                                "DocProformaInvoice_ShopB_Item",
                                                "Doc_ImageLib",
                                                "DocInvoice_Notice",
                                                "DocProformaInvoice_Notice",
                                                "DocInvoice_Image",
                                                "DocProformaInvoice_Image",
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
                                                "JOURNAL"
                                                };

            if (DBSync.DBSync.CreateTables(new_tables, ref Err))
            {
                string sql = @"insert into JOURNAL_DocInvoice_Type (Name,Description) select Name,Description from JOURNAL_ProformaInvoice_Type;
                               insert into JOURNAL_DocInvoice_Type (Name,Description) select Name,Description from JOURNAL_Invoice_Type;
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
                               Atom_Customer_Person_ID,
                               Atom_Customer_Org_ID,
                               WarrantyExist,
                               WarrantyConditions,
                               WarrantyDurationType,
                               WarrantyDuration,
                               TermsOfPayment_ID,
                               PaymentDeadline,
                               MethodOfPayment_ID,
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
                                pi.Atom_Customer_Person_ID,
                                pi.Atom_Customer_Org_ID,
                                pi.WarrantyExist,
                                pi.WarrantyConditions,
                                pi.WarrantyDurationType,
                                pi.WarrantyDuration,
                                pi.TermsOfPayment_ID,
                                inv.PaymentDeadline,
                                inv.MethodOfPayment_ID,
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
                      'Response_DateTime' DATETIME NULL
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
                        ";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = @"
                                  PRAGMA foreign_keys = OFF;

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

                                CREATE TABLE myOrganisation_Person_AccessRights
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                   AccessRights_ID  INTEGER  NOT NULL REFERENCES AccessRights(ID),
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

                                CREATE TABLE JOURNAL_myOrganisation_Person_AccessRights_TYPE
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Name' varchar(264) NOT NULL,
                                  'Description' varchar(2000) NULL
                                  );

                                CREATE TABLE JOURNAL_myOrganisation_Person_AccessRights
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  myOrganisation_Person_AccessRights_TYPE_ID INTEGER  NOT NULL REFERENCES myOrganisation_Person_AccessRights_TYPE(ID),
                                  myOrganisation_Person_AccessRights_ID INTEGER  NOT NULL REFERENCES myOrganisation_Person_AccessRights(ID),
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

                                insert into myOrganisation_Person_AccessRights
                                  (
                                   AccessRights_ID,
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

                                PRAGMA foreign_keys = ON;

                                ";

                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
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
                                        CheckDataBaseTables(ref Err);
                                        Set_DatBase_Version("1.20");
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

        private bool CheckDataBaseTables(ref string Err)
        {
            string sql = "SELECT name FROM sqlite_master WHERE type='table';";
            List<string> missing_table_list = new List<string>();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                string exsist_in_m_DBTables_items = "exsist_in_m_DBTables_items";
                dt.Columns.Add(new DataColumn(exsist_in_m_DBTables_items, typeof(bool)));
                foreach (DataRow dr in dt.Rows)
                {
                    dr[exsist_in_m_DBTables_items] = false;
                }
                int iCount_items = DBSync.DBSync.DB_for_Tangenta.m_DBTables.items.Count;
                int i;
                for (i=0;i< iCount_items; i++)
                {
                    string table_name = DBSync.DBSync.DB_for_Tangenta.m_DBTables.items[i].TableName;
                    DataRow[] drs =  dt.Select("name = '" + table_name + "'");
                    if (drs.Count() > 0)
                    {
                        foreach (DataRow dr in drs)
                        {
                            dr[exsist_in_m_DBTables_items] = true;
                        }
                        continue;
                    }
                    else
                    {
                        missing_table_list.Add(table_name);
                    }
                }
                Err = null;
                DataRow[] drs2 = dt.Select(exsist_in_m_DBTables_items + "= false");
                if (drs2.Count()>0)
                {
                    string slist = "";
                    foreach (DataRow dr in drs2)
                    {
                        if (((string)dr["name"]).Equals("sqlite_sequence"))
                        {
                            continue;
                        }
                        else
                        {
                            slist += "\r\n'" + (string)dr["name"] + "',";
                        }
                    }
                    if (slist.Length>0)
                    {
                        Err = "ERROR:There are tables in DataBase " + DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DataSource + " which are not used in program:" + slist;
                    }
                }
                if (missing_table_list.Count > 0)
                {
                    if (Err == null)
                    {
                        Err = "ERROR:Tables:";
                    }
                    else
                    {
                        Err += "\r\n\r\nERROR:Tables:";
                    }

                    iCount_items = missing_table_list.Count;
                    i = 0;
                    for (;;)
                    {
                        if (i < iCount_items)
                        {
                            Err += "\r\n'" + missing_table_list[i] + "'";
                        }
                        i++;
                        if (i == iCount_items)
                        {
                            break;
                        }
                        else
                        {
                            Err += ",";
                        }
                    }
                    Err += "\r\n are not defined in DataBase '" + DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DataSource + "'";
                }
                if (Err == null)
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private object UpgradeDB_1_18_to_1_19(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                //Repair StudioMarjetka DataBase
                string stbl = "Office_Data_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Office_Data_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                stbl = "Atom_Office_Data_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Atom_Office_Data_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                sql = @"
                        CREATE TABLE Office_Data_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Office_ID  INTEGER  NOT NULL REFERENCES Office(ID),
                           cAddress_Org_ID  INTEGER  NULL REFERENCES cAddress_Org(ID),
                          'Description' varchar(2000) NULL

                          )";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"
                            insert into Office_Data_backup
                            (
                             Office_ID,
                             cAddress_Org_ID, 
                             Description
                            )
                            select
                            1,
                            cAddress_Org_ID,
                            Description
                            from office_data where ID = 1;
                            ";

                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = @"
                            CREATE TABLE Atom_Office_Data_backup
                              (
                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                               Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                               Atom_cAddress_Org_ID  INTEGER  NULL REFERENCES Atom_cAddress_Org(ID),
                              'Description' varchar(2000) NULL
                              )";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = "update Atom_Office_Data set Atom_Office_ID = 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "update Atom_FVI_SLO_RealEstateBP set Atom_Office_Data_ID = 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "delete from Atom_FVI_SLO_RealEstateBP  where ID > 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "delete from Atom_Office_Data where ID > 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = @"
                                insert into Atom_Office_Data_backup
                                (
                                Atom_Office_ID,
                                Atom_cAddress_Org_ID, 
                                Description
                                )
                                select
                                Atom_Office_ID,
                                Atom_cAddress_Org_ID,
                                Description
                                from Atom_Office_Data
                                ";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {

                                sql = @"PRAGMA foreign_keys = OFF;
                                    DROP TABLE Office_Data;
                                    DROP TABLE Atom_Office_Data;
                                    ALTER TABLE Office_Data_backup RENAME TO Office_Data;
                                    ALTER TABLE Atom_Office_Data_backup RENAME TO Atom_Office_Data; 
                                    PRAGMA foreign_keys = ON; ";
                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    if (DBSync.DBSync.Create_VIEWs())
                                    {
                                        Set_DatBase_Version("1.19");
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private object UpgradeDB_1_17_to_1_18(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                //Repair StudioMarjetka DataBase
                if (DBSync.DBSync.DataBase.Contains("StudioMarjetka"))
                {

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office_Data set Atom_myOrganisation_Person_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Organisation set Registration_ID = '3802809000'";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                    sql = "Update Atom_OrganisationData set Atom_Organisation_ID = 1 , Atom_Logo_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_WorkPeriod set Atom_myOrganisation_Person_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_myOrganisation_Person set Atom_Person_ID = 1,Atom_Office_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "delete from Atom_myOrganisation_Person where ID > 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Office set myOrganisation_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Office where ID = 2";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Delete from Atom_myOrganisation_Person where ID > 1";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }


                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_myOrganisation_Person where ID in (2,3)";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                            Delete from Atom_Office where ID = 2";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_myOrganisation where ID = 2";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_OrganisationData where ID = 2";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                            Delete from Atom_Organisation where ID = 2";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                string stbl = "Office_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Office_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                stbl = "Atom_Office_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Atom_Office_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                sql = @"
                    CREATE TABLE Office_backup
                    (
                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                    myOrganisation_ID  INTEGER  NOT NULL REFERENCES myOrganisation(ID),
                    'Name' varchar(264) UNIQUE NOT NULL, 
                    'ShortName' varchar(10) UNIQUE  NOT NULL
                    )";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"
                            insert into Office_backup
                            (
                             myOrganisation_ID,
                            Name, 
                            ShortName
                            )
                            select
                            myOrganisation_ID,
                            Name,
                            'KUNAVE6'
                            from office
                            ";

                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = @"
                            CREATE TABLE Atom_Office_backup
                            (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                             Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                            'Name' varchar(264) UNIQUE NOT NULL, 
                            'ShortName' varchar(10) UNIQUE  NOT NULL
                            )";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = @"
                                insert into Atom_Office_backup
                                (
                                Atom_myOrganisation_ID,
                                Name, 
                                ShortName
                                )
                                select
                                Atom_myOrganisation_ID,
                                Name,
                                'KUNAVE6'
                                from Atom_office
                                ";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {

                                sql = @"PRAGMA foreign_keys = OFF;
                                    DROP TABLE Office;
                                    DROP TABLE Atom_Office;
                                    ALTER TABLE Office_backup RENAME TO Office;
                                    ALTER TABLE Atom_Office_backup RENAME TO Atom_Office; 
                                    PRAGMA foreign_keys = ON; ";
                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    if (DBSync.DBSync.Create_VIEWs())
                                    {
                                        Set_DatBase_Version("1.18");
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    

        private object UpgradeDB_1_16_to_1_17(object obj,ref string Err)
        {
            string sql = null;
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Person;
                        CREATE TABLE cCountry_Person
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"INSERT INTO cCountry_Person (Country,
						 Country_ISO_3166_a2,
						Country_ISO_3166_a3,
						Country_ISO_3166_num)
						SELECT 
						State,
						State_ISO_3166_a2,
						State_ISO_3166_a3,
						State_ISO_3166_num
						FROM cState_Person";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {

                        sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Org;
                        CREATE TABLE cCountry_Org
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = @"INSERT INTO cCountry_Org (Country,
						             Country_ISO_3166_a2,
						            Country_ISO_3166_a3,
						            Country_ISO_3166_num)
						            SELECT 
						            State,
						            State_ISO_3166_a2,
						            State_ISO_3166_a3,
						            State_ISO_3166_num
						            FROM cState_Org";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                sql = @"
                                PRAGMA foreign_keys = OFF;
                                DROP TABLE Atom_cCountry_Person;
                                CREATE TABLE Atom_cCountry_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                  'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                  'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                  'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                  )";

                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    sql = @"INSERT INTO Atom_cCountry_Person (Country,
						                             Country_ISO_3166_a2,
						                            Country_ISO_3166_a3,
						                            Country_ISO_3166_num)
						                            SELECT 
						                            State,
						                            State_ISO_3166_a2,
						                            State_ISO_3166_a3,
						                            State_ISO_3166_num
						                            FROM Atom_cState_Person";
                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                    {

                                        sql = @"
                                                    PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_cCountry_Org;
                                                    CREATE TABLE Atom_cCountry_Org
                                                      (
                                                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                                      )";

                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                        {
                                            sql = @"INSERT INTO Atom_cCountry_Org (Country,
						                                    Country_ISO_3166_a2,
						                                    Country_ISO_3166_a3,
						                                    Country_ISO_3166_num)
						                                    SELECT 
						                                    State,
						                                    State_ISO_3166_a2,
						                                    State_ISO_3166_a3,
						                                    State_ISO_3166_num
						                                    FROM Atom_cState_Org";
                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                            {
                                                sql = @"
                                                CREATE TABLE cAddress_Person_backup
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    cStreetName_Person_ID  INTEGER  NOT NULL REFERENCES cStreetName_Person(ID),
                                                    cHouseNumber_Person_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Person(ID),
                                                    cCity_Person_ID  INTEGER  NOT NULL REFERENCES cCity_Person(ID),
                                                    cZIP_Person_ID  INTEGER  NOT NULL REFERENCES cZIP_Person(ID),
                                                    cState_Person_ID  INTEGER  NULL REFERENCES cState_Person(ID),
                                                    cCountry_Person_ID  INTEGER NOT NULL REFERENCES cCountry_Person(ID)
                                                    )";
                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                {
                                                    sql = @"INSERT INTO cAddress_Person_backup (
                                                        cStreetName_Person_ID,
						                                cHouseNumber_Person_ID,
						                                cCity_Person_ID,
						                                cZIP_Person_ID,
                                                        cState_Person_ID,
                                                        cCountry_Person_ID
                                                        )
						                                SELECT 
                                                        cStreetName_Person_ID,
						                                cHouseNumber_Person_ID,
						                                cCity_Person_ID,
						                                cZIP_Person_ID,
                                                        cCountry_Person_ID,
                                                        cState_Person_ID
						                                FROM cAddress_Person";
                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                    {
                                                        sql = @"PRAGMA foreign_keys = OFF;
                                                                DROP TABLE cAddress_Person;
                                                                ALTER TABLE cAddress_Person_backup RENAME TO cAddress_Person;";
                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                        {
                                                            sql = @"
                                                                CREATE TABLE cAddress_Org_backup
                                                                  (
                                                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                   cStreetName_Org_ID  INTEGER  NOT NULL REFERENCES cStreetName_Org(ID),
                                                                   cHouseNumber_Org_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Org(ID),
                                                                   cCity_Org_ID  INTEGER  NOT NULL REFERENCES cCity_Org(ID),
                                                                   cZIP_Org_ID  INTEGER  NOT NULL REFERENCES cZIP_Org(ID),
                                                                   cState_Org_ID  INTEGER  NULL REFERENCES cState_Org(ID),
                                                                   cCountry_Org_ID  INTEGER NOT NULL REFERENCES cCountry_Org(ID)
                                                                  )";
                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                            {
                                                                sql = @"INSERT INTO cAddress_Org_backup (
                                                                cStreetName_Org_ID,
						                                        cHouseNumber_Org_ID,
						                                        cCity_Org_ID,
						                                        cZIP_Org_ID,
                                                                cState_Org_ID,
                                                                cCountry_Org_ID
                                                                )
						                                        SELECT 
                                                                cStreetName_Org_ID,
						                                        cHouseNumber_Org_ID,
						                                        cCity_Org_ID,
						                                        cZIP_Org_ID,
                                                                cCountry_Org_ID,
                                                                cState_Org_ID
						                                        FROM cAddress_Org";
                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                                            DROP TABLE cAddress_Org;
                                                                            ALTER TABLE cAddress_Org_backup RENAME TO cAddress_Org;";
                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                    {
                                                                        sql = @"
                                                                            CREATE TABLE Atom_cAddress_Person_backup
                                                                                (
                                                                                'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                Atom_cStreetName_Person_ID  INTEGER  NOT NULL REFERENCES cStreetName_Person(ID),
                                                                                Atom_cHouseNumber_Person_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Person(ID),
                                                                                Atom_cCity_Person_ID  INTEGER  NOT NULL REFERENCES cCity_Person(ID),
                                                                                Atom_cZIP_Person_ID  INTEGER  NOT NULL REFERENCES cZIP_Person(ID),
                                                                                Atom_cState_Person_ID  INTEGER  NULL REFERENCES cState_Person(ID),
                                                                                Atom_cCountry_Person_ID  INTEGER NOT NULL REFERENCES cCountry_Person(ID)
                                                                                )";
                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                            {
                                                                            sql = @"INSERT INTO Atom_cAddress_Person_backup (
                                                                                    Atom_cStreetName_Person_ID,
						                                                            Atom_cHouseNumber_Person_ID,
						                                                            Atom_cCity_Person_ID,
						                                                            Atom_cZIP_Person_ID,
                                                                                    Atom_cState_Person_ID,
                                                                                    Atom_cCountry_Person_ID
                                                                                    )
						                                                            SELECT 
                                                                                    Atom_cStreetName_Person_ID,
						                                                            Atom_cHouseNumber_Person_ID,
						                                                            Atom_cCity_Person_ID,
						                                                            Atom_cZIP_Person_ID,
                                                                                    Atom_cCountry_Person_ID,
                                                                                    Atom_cState_Person_ID
						                                                            FROM Atom_cAddress_Person";
                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                            {
                                                                                sql = @"PRAGMA foreign_keys = OFF;
                                                                                        DROP TABLE Atom_cAddress_Person;
                                                                                        ALTER TABLE Atom_cAddress_Person_backup RENAME TO Atom_cAddress_Person;";
                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                {
                                                                                    sql = @"
                                                                                    CREATE TABLE Atom_cAddress_Org_backup
                                                                                      (
                                                                                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                       Atom_cStreetName_Org_ID  INTEGER  NOT NULL REFERENCES cStreetName_Org(ID),
                                                                                       Atom_cHouseNumber_Org_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Org(ID),
                                                                                       Atom_cCity_Org_ID  INTEGER  NOT NULL REFERENCES cCity_Org(ID),
                                                                                       Atom_cZIP_Org_ID  INTEGER  NOT NULL REFERENCES cZIP_Org(ID),
                                                                                       Atom_cState_Org_ID  INTEGER  NULL REFERENCES cState_Org(ID),
                                                                                       Atom_cCountry_Org_ID  INTEGER NOT NULL REFERENCES cCountry_Org(ID)
                                                                                      )";
                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                    {
                                                                                        sql = @"INSERT INTO Atom_cAddress_Org_backup (
                                                                                                Atom_cStreetName_Org_ID,
						                                                                        Atom_cHouseNumber_Org_ID,
						                                                                        Atom_cCity_Org_ID,
						                                                                        Atom_cZIP_Org_ID,
                                                                                                Atom_cState_Org_ID,
                                                                                                Atom_cCountry_Org_ID
                                                                                                )
						                                                                        SELECT 
                                                                                                Atom_cStreetName_Org_ID,
						                                                                        Atom_cHouseNumber_Org_ID,
						                                                                        Atom_cCity_Org_ID,
						                                                                        Atom_cZIP_Org_ID,
                                                                                                Atom_cCountry_Org_ID,
                                                                                                Atom_cState_Org_ID
						                                                                        FROM Atom_cAddress_Org";
                                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                        {
                                                                                            sql = @"PRAGMA foreign_keys = OFF;
                                                                                                    DROP TABLE Atom_cAddress_Org;
                                                                                                    ALTER TABLE Atom_cAddress_Org_backup RENAME TO Atom_cAddress_Org;";
                                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                            {

                                                                                                sql = @"PRAGMA foreign_keys = OFF;
                                                                                                        DROP TABLE cState_Person;
                                                                                                        CREATE TABLE cState_Person
                                                                                                          (
                                                                                                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                          'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                          )";

                                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                {
                                                                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                                                                            DROP TABLE cState_Org;
                                                                                                            CREATE TABLE cState_Org
                                                                                                              (
                                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                              )";
                                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                    {
                                                                                                        sql = @"
                                                                                                        PRAGMA foreign_keys = OFF;
                                                                                                        DROP TABLE Atom_cState_Person;
                                                                                                        CREATE TABLE Atom_cState_Person
                                                                                                          (
                                                                                                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                          'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                          )";
                                                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                        {
                                                                                                            sql = @"PRAGMA foreign_keys = OFF;
                                                                                                            DROP TABLE Atom_cState_Org;
                                                                                                            CREATE TABLE Atom_cState_Org
                                                                                                              (
                                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                              )";
                                                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                            {
                                                                                                                sql = @"PRAGMA foreign_keys = ON;";
                                                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                                {


                                                                                                                    if (DBSync.DBSync.Create_VIEWs())
                                                                                                                    {
                                                                                                                        Set_DatBase_Version("1.17");
                                                                                                                        return true;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        return false;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                                    return false;
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                                return false;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                            return false;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                        return false;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                    return false;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                return false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                            return false;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                        return false;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                    return false;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                return false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private object UpgradeDB_1_15_to_1_16(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                sql = @"
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_ID INTEGER NULL;
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_Type varchar(25) NULL;
                    ";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.16");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_15_to_1_16:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }

        private object UpgradeDB_1_14_to_1_15(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                sql = @"
                        CREATE TABLE Stock_backup
                        (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'ImportTime' DATETIME NOT NULL,
                        'dQuantity' DECIMAL(10,5) NOT NULL,
                        'ExpiryDate' DATETIME NULL,
                        PurchasePrice_Item_ID  INTEGER  NOT NULL REFERENCES PurchasePrice_Item(ID),
                        Stock_AddressLevel1_ID  INTEGER  NULL REFERENCES Stock_AddressLevel1(ID),
                        'Description' varchar(2000) NULL
                        )
                ";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"INSERT INTO Stock_backup (ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description)
						SELECT 
						ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description 
						FROM Stock";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = @"PRAGMA foreign_keys = OFF;
                        DROP TABLE Stock;
                        ALTER TABLE Stock_backup RENAME TO Stock;
                        PRAGMA foreign_keys = ON;";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            string[] new_tables = new string[] { "FVI_SLO_SalesBookInvoice"};
                            if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                            {
                                if (DBSync.DBSync.Create_VIEWs())
                                {
                                    Set_DatBase_Version("1.15");
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }

        private object UpgradeDB_1_13_to_1_14(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string[] new_tables = new string[] {"Atom_ItemShopA", "Atom_ItemShopA_Image",  "DocInvoice_ShopA_Item" };
                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.14");
                        return true;
                    }
                }
            }
            return false;
        }

        private object UpgradeDB_1_12_to_1_13(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "FVI_SLO_Response";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"
                    DROP TABLE " + stbl + @";
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                else
                {
                    sql = @"
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.13");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private object UpgradeDB_1_11_to_1_12(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "DocInvoice_Notice";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.12");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private object UpgradeDB_1_10_to_1_11(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "DocInvoice_Notice";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                          'NoticeText' TEXT NULL,
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                          'NoticeText' TEXT NULL,
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                          
                      );
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.11");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_10_to_1_11:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private object UpgradeDB_1_09_to_1_10(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "Atom_myOrganisation_Person";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                      CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');                    
                    PRAGMA foreign_keys = ON;";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    string[] new_tables = new string[] { "FVI_SLO_RealEstateBP", "FVI_SLO_Response", "Atom_FVI_SLO_RealEstateBP" };
                    if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                    {
                        if (DBSync.DBSync.Create_VIEWs())
                        {
                            Set_DatBase_Version("1.10");
                            return true;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }

        private object UpgradeDB_1_08_to_1_09(object obj, ref string Err)
        {
            string sql = null;
            string[] stables = new string[] { "Atom_cCountry_Org", "Atom_cCountry_Person", "cCountry_Org", "cCountry_Person" };
            foreach (string stbl in stables)
            {
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE "+ stbl + @";
                    CREATE TABLE "+ stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into "+stbl+@" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    CREATE TABLE "+ stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into "+ stbl + @" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
                    PRAGMA foreign_keys = ON;";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                   continue;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            Set_DatBase_Version("1.09");
            return true;

        }

        private object UpgradeDB_1_07_to_1_08(object obj, ref string Err)
        {
            if (UpgradeDB_1_07_to_1_08_Change_Table_Person())
            {
                if (UpgradeDB_1_07_to_1_08_Change_Table_Organisation())
                {
                    if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person())
                    {
                        if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation())
                        {
                            if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office())
                            {
                                Set_DatBase_Version("1.08");
                                return true;
                            }
                        }
                    }

                }
            }
            return false;
        }

        private object UpgradeDB_1_06_to_1_07(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string[] new_tables = new string[] { "doc_page_type", "Language", "doc_type", "doc", "JOURNAL_doc_Type", "JOURNAL_doc"};
                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        if (f_doc.InsertDefault())
                        {
                            Set_DatBase_Version("1.07");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private object UpgradeDB_1_05_to_1_06(object obj, ref string Err)
        {
            //DBSync.DBSync.DB_for_Tangenta
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                if (DBSync.DBSync.Create_VIEWs())
                {
                    Set_DatBase_Version("1.06");
                    return true;
                }
            }
            return false;
        }

        private object UpgradeDB_1_04_to_1_05(object obj, ref string Err)
        {
            Check_DB_1_04();
            m_Old_tables_1_04_to_1_05 = new Old_tables_1_04_to_1_05();
            if (m_Old_tables_1_04_to_1_05.Read())
            {
                m_eUpgrade = eUpgrade.from_1_04_to_105;
                wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
                wfp_ui_thread.Start();


                List<DataTable> dt_List = new List<DataTable>();
                string Message_Title = " 1.04 -> 1.05";

                SQLTable tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonData));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                SQLTable xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_PersonData = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }

                TableDataItem_List.Add(dt_PersonData);


                Err = null;
                Message_Title = " 1.04 -> 1.05";
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_myOrganisation = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_myOrganisation);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Atom_myOrganisation = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_myOrganisation);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_Item);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_SimpleItem);

                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_OrganisationAccount);


                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice_ShopB_Item));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_DocInvoice_ShopB_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DocInvoice_ShopB_Item);


                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice_ShopC_Item));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_Atom_DocInvoice_Price_Item_Stock = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_DocInvoice_Price_Item_Stock);


                Err = null;
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.DBSettings));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_DBSettings = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DBSettings);

                Err = null;
                tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.BaseCurrency));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
                TableDataItem dt_BaseCurrency = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_BaseCurrency);


                wfp_ui_thread.Message(lngRPM.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

                if (DBSync.DBSync.DB_for_Tangenta.DataBase_Make_BackupTemp())
                {
                    if (DBSync.DBSync.DB_for_Tangenta.DataBase_Delete())
                    {
                        if (DBSync.DBSync.DB_for_Tangenta.DataBase_Create())
                        {
                            wfp_ui_thread.Message(lngRPM.s_ImportData.s);
                            if (Write_TableDataItem_List(m_eUpgrade, m_Old_tables_1_04_to_1_05))
                            {
                                // Correct Item's Units
                                Set_DatBase_Version("1.05");
                                string sql = "update item set Unit_ID=1";
                                object ores = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                                {
                                    wfp_ui_thread.End();
                                    return true;
                                }
                                else
                                {
                                    wfp_ui_thread.End();
                                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                                    return false;
                                }

                            }
                        }
                    }
                }
                wfp_ui_thread.End();
                return true;
            }
            else
            {
                return false;
            }
        }

        private object UpgradeDB_1_03_to_1_04(object obj, ref string Err)
        {
            // correct taxation
            string sql = @"select apsi.ID,RetailSimpleItemPrice,Discount,iQuantity,RetailSimpleItemPriceWithDiscount,ExtraDiscount,Rate from atom_price_simpleitem apsi 
                            inner join atom_taxation at on apsi.atom_taxation_ID = at.ID";
            DataTable dt_atom_price_simpleitem1 = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem1, sql, ref Err))
            {
                if (dt_atom_price_simpleitem1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    foreach (DataRow dr in dt_atom_price_simpleitem1.Rows)
                    {
                        lpar.Clear();
                        long ID = (long)dr["ID"];
                        decimal RetailSimpleItemPrice = (decimal)dr["RetailSimpleItemPrice"];
                        decimal Discount = (decimal)dr["Discount"];
                        int iQuantity = (int)dr["iQuantity"];
                        decimal RetailSimpleItemPriceWithDiscount = (decimal)dr["RetailSimpleItemPriceWithDiscount"];
                        decimal ExtraDiscount = (decimal)dr["ExtraDiscount"];
                        decimal Taxation_Rate = (decimal)dr["Rate"];
                        decimal RetailSimpleItemPriceAll = RetailSimpleItemPrice * iQuantity;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated = RetailSimpleItemPrice * iQuantity;
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax = 0;

                        int decimal_places = 2;
                        if (GlobalData.BaseCurrency != null)
                        {
                            decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                        }
                        decimal dQuantity = Convert.ToDecimal(iQuantity);
                        StaticLib.Func.CalculatePrice(RetailSimpleItemPriceAll, dQuantity, Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount_Calculated, ref TaxPrice, ref RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax, decimal_places);
                        string spar_TaxPrice = "@par_TaxPrice";
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        sql = " update atom_price_simpleitem set TaxPrice=" + spar_TaxPrice + " where ID = " + ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            continue;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }

                string Column_PrefixTable = "invoicetable_";
                sql = @" select 
                            pi.ID,
                            Atom_myOrganisation_Person_ID,
                            Draft,
                            DraftNumber,
                            FinancialYear,
                            NumberInFinancialYear,
                            DocInvoiceTime,
                            FirstPrintTime,
                            NetSum,
                            Discount,
                            EndSum,
                            TaxSum,
                            GrossSum,
                            Atom_Customer_Person_ID,
                            Atom_Customer_Org_ID,
                            WarrantyExist,
                            WarrantyConditions,
                            WarrantyDurationType,
                            WarrantyDuration,
                            DocDuration,
                            DocDurationType,
                            TermsOfPayment_ID,
                            Invoice_ID,
                            i.PaymentDeadline as " + Column_PrefixTable + @"PaymentDeadline,
                            i.MethodOfPayment_ID as " + Column_PrefixTable + @"MethodOfPayment_ID,
                            i.Paid as " + Column_PrefixTable + @"Paid,
                            i.Storno as " + Column_PrefixTable + @"Storno
                            from DocInvoice  pi
                            inner join Invoice i on i.ID = pi.Invoice_ID";
                DataTable dt_DocInvoice = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
                {
                    if (dt_DocInvoice.Rows.Count > 0)
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        List<DocInvoice_Connection_Class> DocInvoice_con_List = new List<DocInvoice_Connection_Class>();
                        string sErrors = "";
                        foreach (DataRow dr in dt_DocInvoice.Rows)
                        {
                            lpar.Clear();
                            long docinvoice_ID = (long)dr["ID"];
                            string sql_atom_price_simpleitem = "select * from atom_price_simpleitem where DocInvoice_ID = " + docinvoice_ID.ToString();
                            DocInvoice_Connection_Class picc = new DocInvoice_Connection_Class();
                            picc.ID = docinvoice_ID;
                            DataTable dt_atom_price_simpleitem2 = new DataTable();
                            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem2, sql_atom_price_simpleitem, ref Err))
                            {
                                if (dt_atom_price_simpleitem2.Rows.Count > 0)
                                {
                                    decimal TaxSum = 0;
                                    decimal NetSum = 0;
                                    decimal GrossSum = 0;
                                    foreach (DataRow dr_atom_price_simpleitem in dt_atom_price_simpleitem2.Rows)
                                    {
                                        GrossSum += (decimal)dr_atom_price_simpleitem["RetailSimpleItemPriceWithDiscount"];
                                        TaxSum += (decimal)dr_atom_price_simpleitem["TaxPrice"];
                                    }
                                    NetSum = GrossSum - TaxSum;
                                    string sNumber = ((int)dr["FinancialYear"]).ToString() + "/" + ((int)dr["NumberInFinancialYear"]).ToString();
                                    if ((decimal)dr["NetSum"] != NetSum)
                                    {
                                        sErrors += lngRPM.s_WrongNetSum.s + ((decimal)dr["NetSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealNetSumIs.s + NetSum.ToString() + "\r\n";
                                        dr["NetSum"] = NetSum;
                                    }
                                    if ((decimal)dr["TaxSum"] != TaxSum)
                                    {
                                        sErrors += lngRPM.s_WrongTaxSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealTaxSumIs.s + TaxSum.ToString() + "\r\n";
                                        dr["TaxSum"] = TaxSum;
                                    }
                                    if ((decimal)dr["GrossSum"] != GrossSum)
                                    {
                                        sErrors += lngRPM.s_WrongGrossSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealGrossSumIs.s + GrossSum.ToString() + "\r\n";
                                        dr["GrossSum"] = GrossSum;
                                    }
                                }
                                picc.dt_atom_price_simpleitem = dt_atom_price_simpleitem2;
                                string sql_journal_docinvoice = "select * from journal_docinvoice where DocInvoice_ID = " + docinvoice_ID.ToString();
                                DataTable dt_journal_docinvoice = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_journal_docinvoice, sql_journal_docinvoice, ref Err))
                                {
                                    picc.dt_journal_docinvoice = dt_journal_docinvoice;
                                    DocInvoice_con_List.Add(picc);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        if (sErrors.Length > 0)
                        {
                            MessageBox.Show(m_parent_ctrl, sErrors, "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                        if (DeleteTable_And_ResetAutoincrement("journal_docinvoice"))
                        {
                            if (DeleteTable_And_ResetAutoincrement("atom_price_simpleitem"))
                            {
                                if (DeleteTable_And_ResetAutoincrement("DocInvoice"))
                                {
                                    if (DeleteTable_And_ResetAutoincrement("Invoice"))
                                    {

                                        foreach (DataRow dr in dt_DocInvoice.Rows)
                                        {
                                            long new_Invoice_id = -1;
                                            if (fs.WriteRow("Invoice", dr, Column_PrefixTable, true, ref new_Invoice_id))
                                            {
                                                dr["Invoice_ID"] = new_Invoice_id;
                                                long new_DocInvoice_id = -1;
                                                if (fs.WriteRow("DocInvoice", dr, Column_PrefixTable, false, ref new_DocInvoice_id))
                                                {
                                                    DocInvoice_Connection_Class xpicc = Get_DocInvoice_Connection_Class(DocInvoice_con_List, (long)dr["ID"]);
                                                    if (xpicc != null)
                                                    {
                                                        if (!xpicc.WriteNew(new_DocInvoice_id))
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (Set_DatBase_Version("1.04"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private object UpgradeDB_1_02_to_1_03(object obj, ref string Err)
        {
            // correct taxation
            string sql = @"select apsi.ID,RetailSimpleItemPrice,Discount,iQuantity,RetailSimpleItemPriceWithDiscount,ExtraDiscount,Rate from atom_price_simpleitem apsi 
                            inner join atom_taxation at on apsi.atom_taxation_ID = at.ID";
            DataTable dt_atom_price_simpleitem1 = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem1, sql, ref Err))
            {
                if (dt_atom_price_simpleitem1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    foreach (DataRow dr in dt_atom_price_simpleitem1.Rows)
                    {
                        lpar.Clear();
                        long ID = (long)dr["ID"];
                        decimal RetailSimpleItemPrice = (decimal)dr["RetailSimpleItemPrice"];
                        decimal Discount = (decimal)dr["Discount"];
                        int iQuantity = (int)dr["iQuantity"];
                        decimal RetailSimpleItemPriceWithDiscount = (decimal)dr["RetailSimpleItemPriceWithDiscount"];
                        decimal ExtraDiscount = (decimal)dr["ExtraDiscount"];
                        decimal Taxation_Rate = (decimal)dr["Rate"];
                        decimal RetailSimpleItemPriceAll = RetailSimpleItemPrice * iQuantity;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated = RetailSimpleItemPrice * iQuantity;
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax = 0;

                        int decimal_places = 2;
                        if (GlobalData.BaseCurrency != null)
                        {
                            decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                        }
                        //RetailSimpleItemPriceAll has allready price for all quantity so dQunatity = 1
                        StaticLib.Func.CalculatePrice(RetailSimpleItemPriceAll, 1, Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount_Calculated, ref TaxPrice, ref RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax, decimal_places);
                        string spar_TaxPrice = "@par_TaxPrice";
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        sql = " update atom_price_simpleitem set TaxPrice=" + spar_TaxPrice + " where ID = " + ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            continue;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }

                string Column_PrefixTable = "invoicetable_";
                sql = @" select 
                            pi.ID,
                            Atom_myOrganisation_Person_ID,
                            Draft,
                            DraftNumber,
                            FinancialYear,
                            NumberInFinancialYear,
                            DocInvoiceTime,
                            FirstPrintTime,
                            NetSum,
                            Discount,
                            EndSum,
                            TaxSum,
                            GrossSum,
                            Atom_Customer_Person_ID,
                            Atom_Customer_Org_ID,
                            WarrantyExist,
                            WarrantyConditions,
                            WarrantyDurationType,
                            WarrantyDuration,
                            DocDuration,
                            DocDurationType,
                            TermsOfPayment_ID,
                            Invoice_ID,
                            i.PaymentDeadline as " + Column_PrefixTable + @"PaymentDeadline,
                            i.MethodOfPayment_ID as " + Column_PrefixTable + @"MethodOfPayment_ID,
                            i.Paid as " + Column_PrefixTable + @"Paid,
                            i.Storno as " + Column_PrefixTable + @"Storno
                            from DocInvoice  pi
                            inner join Invoice i on i.ID = pi.Invoice_ID";
                DataTable dt_DocInvoice = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
                {
                    if (dt_DocInvoice.Rows.Count > 0)
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        List<DocInvoice_Connection_Class> DocInvoice_con_List = new List<DocInvoice_Connection_Class>();
                        string sErrors = "";
                        foreach (DataRow dr in dt_DocInvoice.Rows)
                        {
                            lpar.Clear();
                            long docinvoice_ID = (long)dr["ID"];
                            string sql_atom_price_simpleitem = "select * from atom_price_simpleitem where DocInvoice_ID = " + docinvoice_ID.ToString();
                            DocInvoice_Connection_Class picc = new DocInvoice_Connection_Class();
                            picc.ID = docinvoice_ID;
                            DataTable dt_atom_price_simpleitem2 = new DataTable();
                            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem2, sql_atom_price_simpleitem, ref Err))
                            {
                                if (dt_atom_price_simpleitem2.Rows.Count > 0)
                                {
                                    decimal TaxSum = 0;
                                    decimal NetSum = 0;
                                    decimal GrossSum = 0;
                                    foreach (DataRow dr_atom_price_simpleitem in dt_atom_price_simpleitem2.Rows)
                                    {
                                        GrossSum += (decimal)dr_atom_price_simpleitem["RetailSimpleItemPriceWithDiscount"];
                                        TaxSum += (decimal)dr_atom_price_simpleitem["TaxPrice"];
                                    }
                                    NetSum = GrossSum - TaxSum;
                                    string sNumber = ((int)dr["FinancialYear"]).ToString() + "/" + ((int)dr["NumberInFinancialYear"]).ToString();
                                    if ((decimal)dr["NetSum"] != NetSum)
                                    {
                                        sErrors += lngRPM.s_WrongNetSum.s + ((decimal)dr["NetSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealNetSumIs.s + NetSum.ToString() + "\r\n";
                                        dr["NetSum"] = NetSum;
                                    }
                                    if ((decimal)dr["TaxSum"] != TaxSum)
                                    {
                                        sErrors += lngRPM.s_WrongTaxSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealTaxSumIs.s + TaxSum.ToString() + "\r\n";
                                        dr["TaxSum"] = TaxSum;
                                    }
                                    if ((decimal)dr["GrossSum"] != GrossSum)
                                    {
                                        sErrors += lngRPM.s_WrongGrossSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForDocInvoiceNumber.s + sNumber + lngRPM.s_RealGrossSumIs.s + GrossSum.ToString() + "\r\n";
                                        dr["GrossSum"] = GrossSum;
                                    }
                                }
                                picc.dt_atom_price_simpleitem = dt_atom_price_simpleitem2;
                                string sql_journal_docinvoice = "select * from journal_docinvoice where DocInvoice_ID = " + docinvoice_ID.ToString();
                                DataTable dt_journal_docinvoice = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_journal_docinvoice, sql_journal_docinvoice, ref Err))
                                {
                                    picc.dt_journal_docinvoice = dt_journal_docinvoice;
                                    DocInvoice_con_List.Add(picc);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        if (sErrors.Length > 0)
                        {
                            MessageBox.Show(m_parent_ctrl, sErrors, "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        //if (DeleteTable_And_ResetAutoincrement("journal_docinvoice"))
                        //{
                        //    if (DeleteTable_And_ResetAutoincrement("atom_price_simpleitem"))
                        //    {
                        //        if (DeleteTable_And_ResetAutoincrement("DocInvoice"))
                        //        {
                        //            if (DeleteTable_And_ResetAutoincrement("Invoice"))
                        //            {

                        //                foreach (DataRow dr in dt_DocInvoice.Rows)
                        //                {
                        //                    long new_Invoice_id = -1;
                        //                    if (fs.WriteRow("Invoice", dr,  Column_PrefixTable, true, ref new_Invoice_id))
                        //                    {
                        //                        dr["Invoice_ID"] = new_Invoice_id;
                        //                        long new_DocInvoice_id = -1;
                        //                        if (fs.WriteRow("DocInvoice", dr, Column_PrefixTable, false, ref new_DocInvoice_id))
                        //                        {
                        //                            DocInvoice_Connection_Class xpicc = Get_DocInvoice_Connection_Class(DocInvoice_con_List,(long)dr["ID"]);
                        //                            if (xpicc !=null)
                        //                            {
                        //                                if (!xpicc.WriteNew(new_DocInvoice_id))
                        //                                {
                        //                                    return false;
                        //                                }
                        //                            }
                        //                        }
                        //                    }
                        //                }
                        if (Set_DatBase_Version("1.03"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private object UpgradeDB_1_01_to_1_02(object obj, ref string Err)
        {
            wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
            wfp_ui_thread.Start();

            List<DataTable> dt_List = new List<DataTable>();
            SQLTable tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item));
            wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + " 1.01 -> 1.02");
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            SQLTable xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {

                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_Item);

            tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem));
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_SimpleItem);

            tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount));
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_OrganisationAccount);


            wfp_ui_thread.Message(lngRPM.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

            if (DBSync.DBSync.DB_for_Tangenta.DataBase_Make_BackupTemp())
            {
                if (DBSync.DBSync.DB_for_Tangenta.DataBase_Delete())
                {
                    if (DBSync.DBSync.DB_for_Tangenta.DataBase_Create())
                    {
                        wfp_ui_thread.Message(lngRPM.s_ImportData.s);
                        if (Write_TableDataItem_List(m_eUpgrade, m_Old_tables_1_04_to_1_05))
                        {
                            Set_DatBase_Version("1.02");
                        }
                    }
                }
            }
            wfp_ui_thread.End();
            return true;
        }

        private object UpgradeDB_1_0_to_1_01(object o, ref string Err)
        {
            SQLTable tbl_Logo = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Logo));
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Logo.sql_CreateTable, null, ref Err))
            {
                SQLTable tbl_Atom_Logo = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_Logo));
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_Logo.sql_CreateTable, null, ref Err))
                {
                    string sql = "alter table OrganisationData add column Logo_ID NULL references Logo(ID)";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = "alter table Atom_OrganisationData add column Atom_Logo_ID NULL references Atom_Logo(ID)";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = "DROP VIEW OrganisationData_VIEW";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                sql = "DROP VIEW Atom_OrganisationData_VIEW";
                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    SQLTable tbl_OrganisationData = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationData));
                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_OrganisationData.sql_CreateView, null, ref Err))
                                    {
                                        SQLTable tbl_Atom_OrganisationData = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_OrganisationData));
                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_OrganisationData.sql_CreateView, null, ref Err))
                                        {

                                            sql = @"PRAGMA foreign_keys = OFF;
                                                    CREATE TABLE Atom_OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Atom_Organisation_ID  INTEGER  NOT NULL REFERENCES Atom_Organisation(ID),
                                                    Atom_cAddress_Org_ID  INTEGER  NULL REFERENCES Atom_cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    'BankName' varchar(264) NULL,
                                                    'TRR' varchar(264) NULL
                                                    , Atom_Logo_ID NULL references Atom_Logo(ID));

                                            INSERT INTO Atom_OrganisationData_tmp (id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID)
                                                SELECT id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID FROM Atom_OrganisationData;
                                            DROP TABLE Atom_OrganisationData;
                                            ALTER TABLE Atom_OrganisationData_tmp RENAME TO Atom_OrganisationData;

                                            CREATE TABLE OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Organisation_ID  INTEGER  NOT NULL REFERENCES Organisation(ID),
                                                    cAddress_Org_ID  INTEGER  NULL REFERENCES cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    Logo_ID NULL references Logo(ID));

                                            INSERT INTO OrganisationData_tmp (id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID)
                                                SELECT id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID FROM OrganisationData;
                                            DROP TABLE OrganisationData;
                                            ALTER TABLE OrganisationData_tmp RENAME TO OrganisationData;


                                            CREATE TABLE Atom_PriceList_tmp
                                              (
                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                              'Name' varchar(264) UNIQUE  NOT NULL UNIQUE ,
                                              'Valid' BIT NOT NULL,
                                              'ValidFrom' DATETIME NULL,
                                              'ValidTo' DATETIME NULL,
                                              'Description' varchar(2000) NULL,
                                               Atom_Currency_ID  INTEGER  NOT NULL REFERENCES Atom_Currency(ID),
                                               Atom_myOrganisation_Person_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation_Person(ID)
                                              );
                                            INSERT INTO Atom_PriceList_tmp (id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myOrganisation_Person_ID)
                                                SELECT id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myOrganisation_Person_ID FROM Atom_PriceList;
                                            DROP TABLE Atom_PriceList;
                                            ALTER TABLE Atom_PriceList_tmp RENAME TO Atom_PriceList;

                                            PRAGMA foreign_keys = ON;";

                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                            {
                                                DataTable dt = new DataTable();
                                                sql = "select Organisation_ID from myOrganisation order by ID desc";
                                                long Organisation_ID = -1;
                                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                {
                                                    if (dt.Rows.Count > 0)
                                                    {
                                                        Organisation_ID = (long)dt.Rows[0]["Organisation_ID"];
                                                    }
                                                }
                                                sql = @"PRAGMA foreign_keys = OFF;
                                                DROP TABLE myOrganisation;
                                                CREATE TABLE myOrganisation
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    OrganisationData_ID  INTEGER  NOT NULL REFERENCES OrganisationData(ID) UNIQUE
                                                    );";
                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                {
                                                    if (Organisation_ID >= 0)
                                                    {
                                                        sql = "select ID  from OrganisationData where Organisation_ID = " + Organisation_ID.ToString() + " order by ID desc";
                                                        long OrganisationData_ID = -1;
                                                        dt.Clear();
                                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                        {
                                                            if (dt.Rows.Count > 0)
                                                            {
                                                                OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                sql = "insert into myOrganisation (OrganisationData_ID)values(" + OrganisationData_ID.ToString() + ");";
                                                                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    return false;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    dt.Clear();
                                                    sql = "select Atom_Organisation_ID from Atom_myOrganisation order by ID desc";
                                                    long Atom_Organisation_ID = -1;
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            Atom_Organisation_ID = (long)dt.Rows[0]["Atom_Organisation_ID"];
                                                        }
                                                    }
                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_myOrganisation;
                                                    CREATE TABLE Atom_myOrganisation
                                                        (
                                                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        Atom_OrganisationData_ID  INTEGER  NOT NULL REFERENCES Atom_OrganisationData(ID) UNIQUE
                                                        );";
                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                    {
                                                        if (Atom_Organisation_ID >= 0)
                                                        {
                                                            sql = "select ID  from Atom_OrganisationData where Atom_Organisation_ID = " + Atom_Organisation_ID.ToString() + " order by ID desc";
                                                            long Atom_OrganisationData_ID = -1;
                                                            dt.Clear();
                                                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                            {
                                                                if (dt.Rows.Count > 0)
                                                                {
                                                                    Atom_OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                    sql = "insert into Atom_myOrganisation (Atom_OrganisationData_ID)values(" + Atom_OrganisationData_ID.ToString() + ");";
                                                                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        sql = "DROP VIEW myOrganisation_Person_VIEW";
                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                        {
                                                            SQLTable tbl_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation_Person));
                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_myOrganisation_Person.sql_CreateView, null, ref Err))
                                                            {
                                                                sql = "DROP VIEW myOrganisation_VIEW";
                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    SQLTable tbl_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation));
                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_myOrganisation.sql_CreateView, null, ref Err))
                                                                    {
                                                                        sql = "DROP VIEW Atom_myOrganisation_Person_VIEW";
                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                        {
                                                                            SQLTable tbl_Atom_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation_Person));
                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_myOrganisation_Person.sql_CreateView, null, ref Err))
                                                                            {
                                                                                sql = "DROP VIEW Atom_myOrganisation_VIEW";
                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                {
                                                                                    SQLTable tbl_Atom_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));
                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_myOrganisation.sql_CreateView, null, ref Err))
                                                                                    {

                                                                                        sql = "DROP VIEW DocInvoice_VIEW";
                                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                        {
                                                                                            SQLTable tbl_DocInvoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice));
                                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_DocInvoice.sql_CreateView, null, ref Err))
                                                                                            {
                                                                                                sql = "DROP VIEW JOURNAL_DocInvoice_VIEW";
                                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                {
                                                                                                    SQLTable tbl_JOURNAL_DocInvoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(JOURNAL_DocInvoice));
                                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_JOURNAL_DocInvoice.sql_CreateView, null, ref Err))
                                                                                                    {
                                                                                                        if (Set_DatBase_Version("1.01"))
                                                                                                        {
                                                                                                            return true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            LogFile.Error.Show("ERROR:usrc_Invoice:UpgradeDB_1_0_to_1_01:Err=" + Err);
            return false;
        }


        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Office_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                          'Name' varchar(264) NOT NULL 
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Office_backup SELECT * FROM Atom_Office";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Office;
                            ALTER TABLE Atom_Office_backup RENAME TO Atom_Office;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Person()
        {
            string Err = null;
            string sql = @"CREATE TABLE Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           cFirstName_ID  INTEGER  NOT NULL REFERENCES cFirstName(ID),
                           cLastName_ID  INTEGER  NULL REFERENCES cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID' varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Person_backup SELECT * FROM Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Person;
                            ALTER TABLE Person_backup RENAME TO Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           Atom_cFirstName_ID  INTEGER  NOT NULL REFERENCES Atom_cFirstName(ID),
                           Atom_cLastName_ID  INTEGER  NULL REFERENCES Atom_cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID'  varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL,
                           Atom_cGsmNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cGsmNumber_Person(ID),
                           Atom_cPhoneNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cPhoneNumber_Person(ID),
                           Atom_cEmail_Person_ID  INTEGER  NULL REFERENCES Atom_cEmail_Person(ID),
                           Atom_cAddress_Person_ID  INTEGER  NULL REFERENCES Atom_cAddress_Person(ID),
                          'CardNumber' varchar(50) NULL,
                           Atom_cCardType_Person_ID  INTEGER  NULL REFERENCES Atom_cCardType_Person(ID),
                           Atom_PersonImage_ID  INTEGER  NULL REFERENCES Atom_PersonImage(ID)
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Person_backup SELECT * FROM Atom_Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Person;
                            ALTER TABLE Atom_Person_backup RENAME TO Atom_Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Organisation()
        {
            string Err = null;
            string sql = @"CREATE TABLE Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Organisation_backup SELECT * FROM Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Organisation;
                            ALTER TABLE Organisation_backup RENAME TO Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Organisation_backup SELECT * FROM Atom_Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Organisation;
                            ALTER TABLE Atom_Organisation_backup RENAME TO Atom_Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private DocInvoice_Connection_Class Get_DocInvoice_Connection_Class(List<DocInvoice_Connection_Class> DocInvoice_con_List, long DocInvoice_ID)
        {
            foreach (DocInvoice_Connection_Class picc in DocInvoice_con_List)
            {
                if (picc.ID == DocInvoice_ID)
                {
                    return picc;
                }
            }
            return null;
        }



        public bool DeleteTable_And_ResetAutoincrement(string tbl_name)
        {
            // now write
            string Err = null;
            object ores = null;
            string sql = "Delete from " + tbl_name;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
            {
                sql = "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = '" + tbl_name + "'";
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:DeleteTable_And_ResetAutoincrement:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:DeleteTable_And_ResetAutoincrement:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        private bool Check_DB_1_04()
        {
            string Err  = null;
            string sql = "select ID,FinancialYear,NumberInFinancialYear,NetSum,TaxSum,GrossSum from DocInvoice where Draft=0";
            DataTable dt_DocInvoice = new DataTable();
            DataTable dt_DocInvoice_ShopB_Item = new DataTable();
            DataTable dt_Atom_DocInvoice_Price_Item_Stock = new DataTable();
            DataTable dt_Atom_Price_Item = new DataTable();
            string sErrMsg = "";
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
            {
                sql = "select ID,RetailSimpleItemPrice,iQuantity,TaxPrice,DocInvoice_ID from DocInvoice_ShopB_Item";
                if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopB_Item, sql, ref Err))
                {
                    sql = "select ID,RetailPriceWithDiscount,dQuantity,Atom_Price_Item_ID,DocInvoice_ID from Atom_DocInvoice_Price_Item_Stock";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Atom_DocInvoice_Price_Item_Stock, sql, ref Err))
                    {
                        sql = "select ID,RetailPricePerUnit from Atom_Price_Item";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Atom_Price_Item, sql, ref Err))
                        {
                            long DocInvoice_ID = -1;
                            int iFinancialYear = -1;
                            int iNumberInFinancialYear = -1;
                            decimal NetSum = -1;
                            decimal TaxSum = -1;
                            decimal GrossSum = -1;
                            decimal ItemsGrossSum = -1;
                            foreach (DataRow dr in dt_DocInvoice.Rows)
                            {
                                DocInvoice_ID = (long)dr["ID"];
                                iFinancialYear = (int)dr["FinancialYear"];
                                iNumberInFinancialYear = (int)dr["NumberInFinancialYear"];
                                NetSum = (decimal)dr["NetSum"];
                                TaxSum = (decimal)dr["TaxSum"];
                                GrossSum = (decimal)dr["GrossSum"];
                                List<long> DocInvoice_ShopB_Item_ID_list = new List<long>();
                                long DocInvoice_ShopB_Item_ID = -1;
                                GetItemsSum(DocInvoice_ID, dt_DocInvoice_ShopB_Item, dt_Atom_DocInvoice_Price_Item_Stock, dt_Atom_Price_Item, ref ItemsGrossSum, ref DocInvoice_ShopB_Item_ID);
                                if (ItemsGrossSum == GrossSum)
                                {
                                    continue;
                                }
                                else
                                {
                                    sErrMsg += "ERROR:Proforma_Invoice_ID = " + DocInvoice_ID.ToString() + " GrossSum=" + GrossSum.ToString() + " ItemsGrossSum = " + ItemsGrossSum.ToString() + "\r\n";
                                    if (((DocInvoice_ID == 45) || (DocInvoice_ID == 47) || (DocInvoice_ID == 89)) && (DocInvoice_ShopB_Item_ID>=0))
                                    {
                                        string sql_update = "update DocInvoice_ShopB_Item set iQuantity = 1 where DocInvoice_ID = " + DocInvoice_ID.ToString() + " and ID =" + DocInvoice_ShopB_Item_ID.ToString();
                                        object ores=null;
                                        if (!DBSync.DBSync.ExecuteNonQuerySQL(sql_update,null,ref ores,ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                            }
                            if (sErrMsg.Length > 0)
                            {
                                LogFile.Error.Show("Check_DB_1_04:Errors:\r\n" + sErrMsg);
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                            return false;

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                        return false;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                    return false;

                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql="+sql+"\r\nErr="+Err);
                return false;

            }
        }

        private void GetItemsSum(long DocInvoice_ID,  DataTable dt_DocInvoice_ShopB_Item, DataTable dt_Atom_DocInvoice_Price_Item_Stock, DataTable dt_Atom_Price_Item, ref decimal ItemsGrossSum, ref long DocInvoice_ShopB_Item_ID)
        {
            decimal dsum = 0;
            DataRow[] drs_DocInvoice_ShopB_Item = dt_DocInvoice_ShopB_Item.Select("DocInvoice_ID=" + DocInvoice_ID.ToString());
            if (drs_DocInvoice_ShopB_Item.Count()>0)
            {
                int iQuantity = -1;
                
                int icol_iQuantity = dt_DocInvoice_ShopB_Item.Columns.IndexOf("iQuantity");
                int icol_RetailPriceWithDiscount = dt_DocInvoice_ShopB_Item.Columns.IndexOf("RetailSimpleItemPrice");
                
                decimal dRetailPriceWithDiscount = -1;
                foreach (DataRow dr_DocInvoice_ShopB_Item in drs_DocInvoice_ShopB_Item)
                {
                    iQuantity = (int)dr_DocInvoice_ShopB_Item[icol_iQuantity];
                    DocInvoice_ShopB_Item_ID = (long)dr_DocInvoice_ShopB_Item["ID"];
                    dRetailPriceWithDiscount =(decimal)dr_DocInvoice_ShopB_Item[icol_RetailPriceWithDiscount];
                    dsum += dRetailPriceWithDiscount * iQuantity;
                }
            }

            DataRow[] drs_Atom_DocInvoice_Price_Item_Stock = dt_Atom_DocInvoice_Price_Item_Stock.Select("DocInvoice_ID=" + DocInvoice_ID.ToString());
            if (drs_Atom_DocInvoice_Price_Item_Stock.Count()>0)
            {
                decimal dQuantity = -1;
                int icol_iQuantity = dt_Atom_DocInvoice_Price_Item_Stock.Columns.IndexOf("dQuantity");
                int icol_Atom_Price_Item_ID = dt_Atom_DocInvoice_Price_Item_Stock.Columns.IndexOf("Atom_Price_Item_ID");

                decimal dRetailPricePerUnit = -1;
                
                foreach (DataRow dr_Atom_DocInvoice_Price_Item_Stock in drs_Atom_DocInvoice_Price_Item_Stock)
                {
                    dQuantity = (decimal)dr_Atom_DocInvoice_Price_Item_Stock[icol_iQuantity];
                    long Atom_Price_Item_ID = (long)dr_Atom_DocInvoice_Price_Item_Stock[icol_Atom_Price_Item_ID];
                    DataRow[] drs_Atom_Price_Item = dt_Atom_Price_Item.Select("ID="+Atom_Price_Item_ID.ToString());
                    if (drs_Atom_Price_Item.Count()==1)
                    {
                        dRetailPricePerUnit = (decimal)drs_Atom_Price_Item[0]["RetailPricePerUnit"];
                        dsum += decimal.Round(dQuantity * dRetailPricePerUnit,2);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:GetItemsSum:drs_Atom_Price_Item.Count()!=1");
                    }
                }
            }
            ItemsGrossSum = dsum;
        }



        private bool Set_DatBase_Version(string Version)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_TextValue = "@par_TextValue";
            SQL_Parameter par_TextValue = new SQL_Parameter(spar_TextValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Version);
            lpar.Add(par_TextValue);
            string sql = null;
            if (DBSync.DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                sql = @"update DBSettings set TextValue = " + spar_TextValue + @" where Name = 'Version';
                                           PRAGMA foreign_keys = ON;";
            }
            else
            {
                sql = @"update DBSettings set TextValue = " + spar_TextValue + @" where Name = 'Version';";
            }
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Set_DatBase_Version:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool Write_TableDataItem_List(eUpgrade eUpgr,Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            foreach (TableDataItem tdi in TableDataItem_List)
            {
                if (!tdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05))
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_Upgrade_Click(object sender, EventArgs e)
        {
            if (Backup != null)
            {
                Backup();
            }
        }

        public bool Read_DBSettings_Version(ref fs.enum_GetDBSettings eGetDBSettings_Result,ref bool bUpgradeDone, ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            Restore_if_UpgradeBackupFileExists(ref m_Full_backup_filename);
            eGetDBSettings_Result = fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.Version.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err);
            switch (eGetDBSettings_Result)
            {
                case fs.enum_GetDBSettings.DBSettings_OK:
                    if (xTextValue.Equals(DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue))
                    {
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show(m_parent_ctrl, "Podatkovna baza je verzije:" + xTextValue + "\r\nTa program dela lahko dela le z verzijo podatkovne baze:" + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue + "\r\nNadgradim podatkovno bazo na novo verzijo?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            bUpgradeDone = UpgradeDB(xTextValue, DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue, ref Err, m_Full_backup_filename);
                            return true;
                        }
                        else
                        {
                            Err = "Podatkovna baza je verzije:" + xTextValue + "\r\nTa program dela lahko dela le z verzijo podatkovne baze:" + DBSync.DBSync.DB_for_Tangenta.Settings.Version.TextValue;
                            return false;
                        }
                    }


                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;



                case fs.enum_GetDBSettings.No_Data_Rows:
                    if (CheckInsertDefaultOrganisation())
                    {
                        if (TangentaSampleDB.TangentaSampleDB.Init_Sample_DB(ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        if (fs.Init_Default_DB(ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }

                case fs.enum_GetDBSettings.No_TextValue:
                    return false;

                case fs.enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    return false;

            }
        }

        private bool Restore_if_UpgradeBackupFileExists(ref string full_backup_filename)
        {

            string full_backup_folder = DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DataBaseFilePath;
            string DB_Name = DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DataBaseName;
            full_backup_filename = null;
            if (full_backup_folder != null)
            {
                if (full_backup_folder.Length > 0)
                {
                    if (full_backup_folder[full_backup_folder.Length - 1] != '\\')
                    {
                        full_backup_folder += '\\';
                    }
                    full_backup_filename = full_backup_folder+"UpgradeBackup_" + DB_Name;
                    if (File.Exists(full_backup_filename))
                    {
                        string stext = lngRPM.s_UpgradeBackupFileExist_restore_old_Database.s.Replace("%s", full_backup_filename);
                        if (MessageBox.Show(stext,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1)== DialogResult.Yes)
                        {
                            try
                            {
                                string sOrgDBFile = DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.SQLiteDataBaseFile;
                                File.Copy(full_backup_filename, sOrgDBFile, true);
                                File.Delete(full_backup_filename);
                                return true;
                            }
                            catch (Exception ex)
                            {
                                LogFile.Error.Show("ERROR:UpgradeDB_inThread:Restore_if_BackupFileExist:Backup file=\"" + full_backup_filename + "\"\r\nException="+ex.Message);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            LogFile.Error.Show("ERROR:usrc_Upgrade:Form_Upgrade_Load:Backup file=\"" + full_backup_filename + "\" not created!");
            return false;

        }

        public  bool Read_DBSettings(object oData, ref string Err,ref startup_step.eStep eNextStep)
        {
            bool bUpgradeDone = false;
            fs.enum_GetDBSettings eGetDBSettings_Result = fs.enum_GetDBSettings.No_TextValue;
            if (Read_DBSettings_Version(ref eGetDBSettings_Result,ref bUpgradeDone, ref Err))
            {
                if (GlobalData.JOURNAL_DocInvoice_Type_definitions.Read())
                {
                    if (Read_DBSettings_LastInvoiceType(bUpgradeDone, ref Err))
                    {
                        if (fs.Read_DBSettings_StockCheckAtStartup(bUpgradeDone, ref Err))
                        {
                            if (f_JOURNAL_Stock.Get_JOURNAL_Stock_Type_ID())
                            {
                                switch (eGetDBSettings_Result)
                                {
                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                        eNextStep++;
                                        return true;
                                }
                                eNextStep++;
                                return true;
                            }
                        }
                    }
                }
            }
            eNextStep = startup_step.eStep.End;
            return false;
        }

        private  bool Read_DBSettings_LastInvoiceType(bool bUpgradeDone, ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.LastInvoiceType.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err))
            {
                case fs.enum_GetDBSettings.DBSettings_OK:
                    if (!xReadOnly)
                    {
                        DBSync.DBSync.DB_for_Tangenta.Settings.LastInvoiceType.TextValue = xTextValue;
                    }
                    return true;


                case fs.enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;

                case fs.enum_GetDBSettings.No_Data_Rows:
                    if (MessageBox.Show(m_parent_ctrl, "Podatkovna baza je prazna!\r\nVstavim vzorčne podatke studia Marjetka?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (TangentaSampleDB.TangentaSampleDB.Init_Sample_DB(ref Err))
                        {
                            return false;
                            //$$$
                            //if (Get_BaseCurrency(ref Err))
                            //{
                            //    return true;
                            //}
                            //else
                            //{
                            //    LogFile.Error.Show("ERROR:1:enum_GetDBSettings.No_Data_Rows:Get_BaseCurrency:Err = " + Err);
                            //    return false;
                            //}
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        if (bUpgradeDone)
                        {
                            return true;
                        }
                        else
                        {
                            if (fs.Init_Default_DB(ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_DBSettings:Init_Default_DB:Err=" + Err);
                                return false;
                            }
                        }
                    }
                //break;

                case fs.enum_GetDBSettings.No_TextValue:
                    return false;

                case fs.enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    return false;
            }
        }

        private bool CheckInsertDefaultOrganisation()
        {
            if (MessageBox.Show(m_parent_ctrl, lngRPM.s_DataBaseIsEmpty_InsertInitialData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class TableDataItem
    {
        public SQLTable tbl = null;
        public DataTable dt = null;
        public List<TableDataItem> fkey_TableDataItem_List = new List<TableDataItem>();
        public TableDataItem prev = null;

        public TableDataItem(SQLTable xtbl, ref List<DataTable> dt_List,TableDataItem xprev, ref string Err)
        {
            // TODO: Complete member initialization
            tbl = xtbl;
            prev = xprev;
            foreach (Column col in xtbl.Column)
            {
                if (col.fKey != null)
                {
                    if (!col.fKey.fTable.TableName.Equals("Atom_WorkPeriod"))
                    {
                        TableDataItem tdi = new TableDataItem(col.fKey.fTable, ref dt_List, this, ref Err);
                        if (Err != null)
                        {
                            return;
                        }
                        fkey_TableDataItem_List.Add(tdi);
                    }
                }
            }
            if (Find_dt_List(ref dt, dt_List, tbl.TableName))
            {
                return;
            }
            else
            {
                string sql = "select * from " + xtbl.TableName;
                dt = new DataTable();
                dt.TableName = tbl.TableName;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    dt.Columns.Add("old_ID", typeof(long));
                    dt_List.Add(dt);
                }
            }
        }

        internal bool Write2DB(Database_Upgrade_WindowsForm_Thread wfp_ui_thread,UpgradeDB_inThread.eUpgrade eUpgr,Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            string Err = null;
            foreach (TableDataItem xtdi in fkey_TableDataItem_List)
            {
                xtdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05);
            }

            if (eUpgr == UpgradeDB_inThread.eUpgrade.from_1_04_to_105)
            {
                if (this.tbl.TableName.ToLower().Equals("pricelist"))
                {
                    if (GlobalData.Office_ID<0)
                    { 
                        string sql = "insert into Office (myOrganisation_ID,Name)values(1,'P1')";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,null,ref GlobalData.Office_ID,ref oret, ref Err,"Office"))
                        {
                            sql = "insert into myOrganisation_Person (UserName,Password,Job,Active,Description,Person_ID,Office_ID)values('marjetkah',null,'Direktor',1,'Direktorica in lastnica podjetja',1,1)";
                            long x_myOrganisation_Person_ID = -1;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref x_myOrganisation_Person_ID, ref oret, ref Err, "Office"))
                            {
                                
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
                {
                    string sql = null;
                    object oret = null;
                    if (GlobalData.Atom_Office_ID < 0)
                    {
                        sql = "insert into Atom_Office (Atom_myOrganisation_ID,Name)values(1,'P1')";
                        if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref GlobalData.Atom_Office_ID, ref oret, ref Err, "Atom_Office"))
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }

                    DateTime dtStart = new DateTime(2015, 4, 29);
                    DateTime_v dtEnd_v = new DateTime_v();
                    dtEnd_v.v = DateTime.Now;
                    if (!GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04,null,dtStart,dtEnd_v, ref Err))
                    {
                        return false;
                    }


                }
                else if (this.tbl.TableName.ToLower().Equals("docinvoice"))
                {
                    DateTime dtStart = new DateTime(2015, 4, 29);
                    DateTime_v dtEnd_v = new DateTime_v();
                    dtEnd_v.v = DateTime.Now;
                    GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04, null, dtStart, dtEnd_v, ref Err);
                }
            }

            string tname = tbl.TableName;
            string sql_insert_columns = null;
            string sql_insert_values = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            bool bDocInvoiceTime = false;
            bool bFirstPrintTime = false;
            bool bPaid = false;
            bool bStorno = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["old_id"] is System.DBNull)
                {
                    wfp_ui_thread.Message(lngRPM.s_ImportData.s + ":" + tname);
                    sql_insert_columns = null;
                    sql_insert_values = null;
                    lpar.Clear();
                    long old_id = (long)dr["id"];
                    DateTime_v InvoiceTime_v = null;
                    DateTime_v PaidTime_v = null;
                    DateTime_v StornoTime_v = null;
                    foreach (DataColumn dcol in dt.Columns)
                    {
                        if (dcol.ColumnName.ToUpper().Equals("ID") || dcol.ColumnName.ToUpper().Equals("OLD_ID"))
                        {
                            continue;
                        }
                        else
                        {
                            if (eUpgr == UpgradeDB_inThread.eUpgrade.from_1_04_to_105)
                            {
                                if (dcol.ColumnName.ToLower().Equals("myorganisation_person_id"))
                                {
                                    continue;
                                }
                                if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
                                {
                                    if (dcol.ColumnName.ToLower().Equals("atom_myorganisation_person_id"))
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (this.tbl.TableName.ToLower().Equals("docinvoice"))
                                    {
                                        if (dcol.ColumnName.ToLower().Equals("atom_myorganisation_person_id"))
                                        {
                                            continue;
                                        }
                                    }

                                }
                            }
                        }
                        object o = dr[dcol];
                        string sparname = null;
                        SQL_Parameter par = null;
                        if (new_SQL_Parameter(this, dr, dcol, ref sparname, o, ref par))
                        {
                            if (dcol.ColumnName.ToLower().Equals("paid"))
                            {
                                bPaid = true;
                            }
                            if (dcol.ColumnName.ToLower().Equals("storno"))
                            {
                                bStorno = true;
                            }

                            if (dcol.ColumnName.ToLower().Equals("firstprinttime"))
                            {
                                bFirstPrintTime = true;
                            }
                            else if (dcol.ColumnName.ToLower().Equals("docinvoicetime"))
                            {
                                bDocInvoiceTime = true;
                            }
                            else
                            {
                                if (par != null)
                                {
                                    lpar.Add(par);
                                }
                                if (sql_insert_columns == null)
                                {
                                    sql_insert_columns = dcol.ColumnName;
                                }
                                else
                                {
                                    sql_insert_columns += "," + dcol.ColumnName;
                                }
                                if (sql_insert_values == null)
                                {
                                    sql_insert_values = sparname;
                                }
                                else
                                {
                                    sql_insert_values += "," + sparname;
                                }

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (bDocInvoiceTime)
                    { 
                        if (dr["docinvoicetime"] is DateTime)
                        {
                            InvoiceTime_v = new DateTime_v();
                            InvoiceTime_v.v = (DateTime)dr["docinvoicetime"];
                        }
                    }

                    if (bPaid)
                    {
                        if (dr["Paid"] is bool)
                        {
                            PaidTime_v = new DateTime_v();
                            PaidTime_v.v = GetDocInvoiceTime(old_id,m_Old_tables_1_04_to_1_05);
                        }
                    }

                    if (bStorno)
                    {
                        if (dr["Storno"] is bool)
                        {
                            if ((bool)dr["Storno"])
                            {
                                StornoTime_v = new DateTime_v();
                                StornoTime_v.v = GetInvoiceStornoTime(old_id, m_Old_tables_1_04_to_1_05);
                            }
                            else
                            {
                                bStorno = false;
                            }
                        }
                    }

                    string sql_insert = " insert into " + tname + " (" + sql_insert_columns + ") values (" + sql_insert_values + ")";
                    long new_id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref new_id, ref ores, ref Err, tname))
                    {
                        dr["OLD_ID"] = old_id;
                        dr["id"] = new_id;
                        if (tname.ToLower().Equals("docinvoice"))
                        { 
                            long Journal_DocInvoice_ID = -1;
                            f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.Description, InvoiceTime_v, ref Journal_DocInvoice_ID);
                            if (dr["Draft"] is bool)
                            {
                                if (!(bool)dr["Draft"])
                                { 
                                    f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.Description ,InvoiceTime_v, ref Journal_DocInvoice_ID);
                                    f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoicePaidTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoicePaidTime.Description, InvoiceTime_v, ref Journal_DocInvoice_ID);
                                }
                            }
                        }
                        else if (tname.ToLower().Equals("invoice"))
                        {
                            long Journal_Invoice_ID = -1;
                            f_Journal_DocProformaInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Paid", "Plačano", PaidTime_v, ref Journal_Invoice_ID);
                            if (bStorno)
                            { 
                                f_Journal_DocProformaInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Storno*", "Napaka pri vnosu", StornoTime_v, ref Journal_Invoice_ID);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:Err=" + Err);
                        return false;
                    }
                }
            }
            return true;
        }

        private DateTime GetInvoiceStornoTime(long Invoice_id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_Journal_Invoice.Select("invoice_id=" + Invoice_id.ToString());
            if (drs.Count() > 0)
            {
                return (DateTime)drs[0]["EventTime"];
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetInvoiceStornoTime:Err id =" + Invoice_id.ToString() + " not found in table DocInvoice!");
                return DateTime.Now;
            }
        }

        private DateTime GetDocInvoiceTime(long id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {

            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_DocInvoice.Select("id=" + id.ToString());
            if (drs.Count()>0)
            {
                if (drs[0]["DocInvoiceTime"] is DateTime)
                { 
                    return (DateTime)drs[0]["DocInvoiceTime"];
                }
                else
                {
                    //LogFile.Error.Show("ERROR:usrc_Upgrade:GetDocInvoiceTime:DocInvoiceTime type = " + drs[0]["DocInvoiceTime"].GetType().ToString());
                    return DateTime.Now;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetDocInvoiceTime:Err id =" + id.ToString() + " not found in table DocInvoice!");
                return DateTime.Now;
            }
        }


        private bool Find_dt_List(ref DataTable dtchk, List<DataTable> dt_List, string tname)
        {
            foreach (DataTable xdt in dt_List)
            {
                if (xdt.TableName.Equals(tname))
                {
                    dtchk = xdt;
                    return true;
                }
            }
            return false;
        }

        private bool new_SQL_Parameter(TableDataItem tdi, DataRow dr, DataColumn dcol, ref string sparname, object o, ref SQL_Parameter par)
        {
            long new_ID = -1;
            sparname = "@par_" + dcol.ColumnName;
            //if (tdi.tbl.TableName.Equals("Atom_cAddress_Org"))
            //{
            //    MessageBox.Show("Atom_cAddress_Org");
            //}
            if (IsForeignKey(tdi, dr, dcol, ref new_ID))
            {
                o = new_ID;
            }
            if (o is string)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Nvarchar, false, o);
            }
            else if (o is bool)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bit, false, o);
            }
            else if (o is short)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);

            }
            else if (o is ushort)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);
            }
            else if (o is int)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);
            }
            else if (o is uint)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);

            }
            else if (o is long)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);

            }
            else if (o is ulong)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);
            }
            else if (o is DateTime)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Datetime, false, o);
            }
            else if (o is byte[])
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Varbinary, false, o);
            }
            else if (o is decimal)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Decimal, false, o);
            }
            else if (o is float)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Float, false, o);
            }
            else if (o is System.DBNull)
            {
                sparname = "null";
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:new_SQL_Parameter: type = " + o.GetType().ToString() + " not implemented !");
                return false;
            }
            return true;
        }

        private bool IsForeignKey(TableDataItem tdi, DataRow dr, DataColumn dcol, ref long new_ID)
        {
            foreach (Column col in tdi.tbl.Column)
            {
                if (col.fKey != null)
                {
                    if (col.Name.Equals(dcol.ColumnName))
                    {
                        foreach (TableDataItem xtdi in tdi.fkey_TableDataItem_List)
                        {
                            if (col.fKey.fTable.TableName.Equals(xtdi.tbl.TableName))
                            {
                                object o_Old_ID = dr[dcol.ColumnName];
                                if (o_Old_ID is long)
                                {
                                    DataRow[] drs = xtdi.dt.Select("old_ID = " + ((long)o_Old_ID).ToString());
                                    if (drs.Count() > 0)
                                    {
                                        new_ID = (long)drs[0]["ID"];
                                        return true;
                                    }
                                }
                           }
                        }
                    }
                }
            }
            return false;
        }
    }

    public class Old_tables_1_04_to_1_05
    {
        public DataTable dt_DocInvoice = new DataTable();
        public DataTable dt_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice_Type = new DataTable();
        public bool Read()
        {
            string Err = null;
            string sql = "select * from DocInvoice";
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice,sql, ref Err))
            {
                sql = "select * from Invoice";
                if (DBSync.DBSync.ReadDataTable(ref dt_Invoice,sql, ref Err))
                {
                    sql = "select * from JOURNAL_Invoice";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice,sql, ref Err))
                    {
                        sql = "select * from Journal_Invoice_Type";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice_Type,sql, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                            return false;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                return false;
            }

        }

    }
}
