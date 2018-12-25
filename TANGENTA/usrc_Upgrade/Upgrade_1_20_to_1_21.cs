using CodeTables;
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TangentaDB;

namespace UpgradeDB
{
    internal static class Upgrade_1_20_to_1_21
    {
        internal static object UpgradeDB_1_20_to_1_21(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_20_to_1_21 = new Transaction("UpgradeDB_1_20_to_1_21", DBSync.DBSync.MyTransactionLog_delegates);
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_20_to_1_21))
            {
                string[] new_tables = new string[] {"Contact",
                                                "Trucking",
                                                "Purchase_Order",
                                                "StockTake",
                                                "StockTakeCostName",
                                                "StockTakeCostDescription",
                                                "StockTake_AdditionalCost",
                                                "JOURNAL_StockTake_Type",
                                                "JOURNAL_StockTake",
                                                "ElectronicDevice"};
                if (DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_20_to_1_21))
                {
                    ID Atom_ElectronicDevice_ID =null;
                    if (f_Atom_ElectronicDevice.Get(new ID(1),"ED1", null, ref Atom_ElectronicDevice_ID, transaction_UpgradeDB_1_20_to_1_21))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        string spar_Atom_ElectronicDevice_ID = "@par_Atom_ElectronicDevice_ID";
                        SQL_Parameter par_Atom_ElectronicDevice_ID = new SQL_Parameter(spar_Atom_ElectronicDevice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ElectronicDevice_ID);
                        lpar.Add(par_Atom_ElectronicDevice_ID);
                        string sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE IF EXISTS Atom_WorkPeriod_temp;

                        CREATE TABLE Atom_WorkPeriod_temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                            Atom_myOrganisation_Person_ID INTEGER NOT NULL REFERENCES Atom_myOrganisation_Person(ID),
                                                            Atom_WorkArea_ID INTEGER NOT NULL REFERENCES Atom_WorkArea(ID),
                                                            Atom_Computer_ID INTEGER NOT NULL REFERENCES Atom_Computer(ID),
                                                            Atom_ElectronicDevice_ID INTEGER NOT NULL REFERENCES ElectronicDevice(ID),
                                                            'LoginTime' DATETIME NULL,
                                                            'LogoutTime' DATETIME NULL,
                                                            Atom_WorkPeriod_TYPE_ID INTEGER NULL REFERENCES Atom_WorkPeriod_TYPE(ID));

                        insert into Atom_WorkPeriod_temp
                        (
                          ID,
                          Atom_myOrganisation_Person_ID,
                          Atom_WorkArea_ID,
                          Atom_Computer_ID,
                          Atom_ElectronicDevice_ID,
                          Atom_WorkPeriod_TYPE_ID,
                          LoginTime,
                          LogoutTime
                        )
                        select
                            ID,
                            Atom_myOrganisation_Person_ID,
                            Atom_WorkArea_ID,
                            Atom_Computer_ID,
                            " + spar_Atom_ElectronicDevice_ID + @",
                            Atom_WorkPeriod_TYPE_ID,
                            LoginTime,
                            LogoutTime
                            from Atom_WorkPeriod;
                        DROP TABLE Atom_WorkPeriod;
                        ALTER TABLE Atom_WorkPeriod_temp RENAME TO Atom_WorkPeriod;
                        PRAGMA foreign_keys = ON;
                        ";
                        if (!transaction_UpgradeDB_1_20_to_1_21.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, lpar, ref Err))
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_20_to_1_21:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                        sql = @"
                        PRAGMA foreign_keys = OFF;
                        CREATE TABLE PurchasePrice_NEW(
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'PurchasePricePerUnit' DECIMAL(18,5) NOT NULL,
                            Currency_ID INTEGER NOT NULL REFERENCES Currency(ID),
                            Taxation_ID INTEGER NOT NULL REFERENCES Taxation(ID),
                        'PurchasePriceDate' DATETIME NOT NULL );

                            Insert into PurchasePrice_NEW
                                (
                                    PurchasePricePerUnit,
                                    Currency_ID,
                                    Taxation_ID,
                                    PurchasePriceDate
                                )
                                select
                                    PurchasePricePerUnit,
                                    Currency_ID,
                                    Taxation_ID,
                                    PurchasePriceDate
                                from PurchasePrice;
                        
                        CREATE TABLE PurchasePrice_Item_NEW 
                        ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            Item_ID INTEGER NOT NULL REFERENCES Item(ID),
                            PurchasePrice_ID INTEGER NOT NULL REFERENCES PurchasePrice(ID),
                            StockTake_ID INTEGER NOT NULL REFERENCES StockTake(ID) 
                        );

                            Insert into PurchasePrice_NEW
                                (
                                    PurchasePricePerUnit,
                                    Currency_ID,
                                    Taxation_ID,
                                    PurchasePriceDate
                                )
                                select
                                    PurchasePricePerUnit,
                                    Currency_ID,
                                    Taxation_ID,
                                    PurchasePriceDate
                                from PurchasePrice;

                            CREATE TABLE Supplier_NEW 
                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT, 
                            Contact_ID INTEGER NOT NULL REFERENCES Contact(ID) UNIQUE );

                            PRAGMA foreign_keys = ON;
                        ";

                        if (!transaction_UpgradeDB_1_20_to_1_21.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_20_to_1_21:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }

                        if (!FillStockTake(transaction_UpgradeDB_1_20_to_1_21))
                        {
                            return false;
                        }

                        if (DBSync.DBSync.DataBase.Contains("StudioMarjetka"))
                        {
                            sql = "update Bank set Organisation_ID = 2 where ID = 1";
                            if (!transaction_UpgradeDB_1_20_to_1_21.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_20_to_1_21:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                        }
                        sql = @"
                            PRAGMA foreign_keys = OFF;
                            DROP TABLE doc;
                            DROP TABLE doc_type;
                            DROP TABLE doc_page_type;

                            CREATE TABLE Atom_Currency_NEW ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' varchar(264) NOT NULL, 'Abbreviation' varchar(50) NOT NULL, 'Symbol' varchar(5) NOT NULL, 'CurrencyCode' INT NOT NULL, 'DecimalPlaces' INT NOT NULL );

                            insert into Atom_Currency_NEW (ID,Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces) select ID,Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces from Atom_Currency;

                            DROP TABLE Atom_Currency;
                            ALTER TABLE Atom_Currency_NEW RENAME TO Atom_Currency;

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
                            'CreationDate' DATETIME NULL,
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
                             
                              insert into PriceList_Name (Name)  select Name from PriceList;

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

                              insert into Atom_PriceList_Name (Name)  select Name from Atom_PriceList;

                              insert into Atom_PriceList_new
                              (
                                ID,
                              Atom_PriceList_Name_ID,
                              Valid,
                              Atom_Currency_ID,
                              ValidFrom,
                              ValidTo,
                              Description
                              )
                              select 
                              apl.ID,
                              apln.ID,
                              apl.Valid,
                              apl.Atom_Currency_ID,
                              apl.ValidFrom,
                              apl.ValidTo,
                              apl.Description
                              from Atom_PriceList apl
                              inner join Atom_PriceList_Name apln on apln.Name = apl.Name;

                              DROP TABLE PriceList;

                              ALTER TABLE PriceList_new RENAME TO PriceList;

                              DROP TABLE Atom_PriceList;

                              ALTER TABLE Atom_PriceList_new RENAME TO Atom_PriceList;

                              DELETE FROM Currency;
                              delete from sqlite_sequence where name='Currency';
                              ";
                        if (!transaction_UpgradeDB_1_20_to_1_21.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_20_to_1_21:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }

                        if (!fs.Init_Currency_Table(ref Err, transaction_UpgradeDB_1_20_to_1_21))
                        {
                            return false;
                        }

                        sql = @"update Atom_Currency set Name = 'Euro' where Name = 'EURO';
                                PRAGMA foreign_keys = ON;
                              ";

                        if (!transaction_UpgradeDB_1_20_to_1_21.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_20_to_1_21:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }

                        new_tables = new string[] {"doc_type",
                                                    "doc_page_type",
                                                    "doc" };

                        if (DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_20_to_1_21))
                        {
                            if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_20_to_1_21))
                            {
                                if (UpgradeDB_inThread.Set_DataBase_Version("1.21", transaction_UpgradeDB_1_20_to_1_21))
                                {
                                    if (transaction_UpgradeDB_1_20_to_1_21.Commit())
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    transaction_UpgradeDB_1_20_to_1_21.Rollback();
                                    return false;
                                }
                            }
                            else
                            {
                                transaction_UpgradeDB_1_20_to_1_21.Rollback();
                                return false;
                            }
                        }
                        else
                        {
                            transaction_UpgradeDB_1_20_to_1_21.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        transaction_UpgradeDB_1_20_to_1_21.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_20_to_1_21.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_20_to_1_21.Rollback();
                return false;
            }
        }

        private static bool FillStockTake(Transaction transaction)
        {
            DataTable dtPurchasePrice_Item_OLD = new DataTable();
            DataTable dtPurchasePrice_OLD = new DataTable();
            DataTable dtReference = new DataTable();
            DataTable dtOrganisation = new DataTable();
            ID Unknown_Trucking_ID = null;
            string Err = null;
            string sql = "select * from PurchasePrice_Item";
            if (DBSync.DBSync.ReadDataTable(ref dtPurchasePrice_Item_OLD, sql, ref Err))
            {
                sql = "select * from PurchasePrice";
                if (DBSync.DBSync.ReadDataTable(ref dtPurchasePrice_OLD, sql, ref Err))
                {
                    sql = "select * from Reference";
                    if (DBSync.DBSync.ReadDataTable(ref dtReference, sql, ref Err))
                    {
                        sql = "select * from Organisation";
                        if (DBSync.DBSync.ReadDataTable(ref dtOrganisation, sql, ref Err))
                        {

                            string sdb = DBSync.DBSync.DataBase;

                            if (sdb.Contains("StudioMarjetka"))
                            {
                                ID Contact_ID_drEckstein = null;
                                if (InsertDrEcksteinGmbh_Contact(ref Contact_ID_drEckstein,transaction))
                                {
                                    ID Contact_ID_Bizjan_doo = null;
                                    if (InsertBizjan_doo_Contact(ref Contact_ID_Bizjan_doo, transaction))
                                    {

                                        sql = "insert into Supplier_NEW (Contact_ID)values(" + Contact_ID_drEckstein.ToString() + ")";

                                        ID Suplier_ID_drEckstein = null;

                                        if (!transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref Suplier_ID_drEckstein, ref Err, "Supplier_NEW"))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }

                                        ID Suplier_ID_Bizjan_doo = null;
                                        sql = "insert into Supplier_NEW (Contact_ID)values(" + Contact_ID_Bizjan_doo.ToString() + ")";
                                        if (!transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref Suplier_ID_Bizjan_doo,  ref Err, "Supplier_NEW"))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }

                                        int iCount = dtPurchasePrice_Item_OLD.Rows.Count;
                                        for (int i = 0; i < iCount; i++)
                                        {
                                            // for each old PurchasePrice_Item 
                                            DataRow drPurchasePrice_Item = dtPurchasePrice_Item_OLD.Rows[i];

                                            ID PurchasePrice_ID = tf.set_ID(drPurchasePrice_Item["PurchasePrice_ID"]);
                                            ID Item_ID = tf.set_ID(drPurchasePrice_Item["Item_ID"]);

                                            DataRow[] drs_PurchasePrice_OLD = dtPurchasePrice_OLD.Select("ID=" + PurchasePrice_ID.ToString());
                                            if (drs_PurchasePrice_OLD.Count() == 1)
                                            {
                                                DataRow drPurchasePrice = drs_PurchasePrice_OLD[0];
                                                decimal PurchasePricePerUnit = (decimal)drPurchasePrice["PurchasePricePerUnit"];
                                                DateTime PurchasePriceDate = (DateTime)drPurchasePrice["PurchasePriceDate"];
                                                ID Currency_ID = tf.set_ID(drPurchasePrice["Currency_ID"]);
                                                ID Taxation_ID = tf.set_ID(drPurchasePrice["Taxation_ID"]);
                                                ID Supplier_ID = tf.set_ID(drPurchasePrice["Supplier_ID"]);
                                                ID Reference_ID = null;
                                                ID PurchasePrice_NEW_ID =null;
                                                if (!f_PurchasePrice.Get_InUpdate("PurchasePrice_NEW", PurchasePricePerUnit, Taxation_ID, Currency_ID, ref PurchasePrice_NEW_ID, transaction))
                                                {
                                                    return false;
                                                }


                                                if (drPurchasePrice["Reference_ID"] is long)
                                                {
                                                    Reference_ID = tf.set_ID(drPurchasePrice["Reference_ID"]);
                                                }


                                                sql = @"select o.Name from Organisation o
                                                                inner join Supplier s  on s.Organisation_ID = o.ID where s.ID = " + Supplier_ID.ToString();
                                                DataTable dtSupplier = new DataTable();
                                                if (!DBSync.DBSync.ReadDataTable(ref dtSupplier, sql, ref Err))
                                                {
                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:FillStockTake:sql=" + sql + "\r\nErr=" + Err);
                                                    return false;
                                                }
                                                string SupplierName = null;
                                                if (dtSupplier.Rows.Count > 0)
                                                {
                                                    SupplierName = (string)dtSupplier.Rows[0]["Name"];
                                                }

                                                if (SupplierName != null)
                                                {
                                                    if (SupplierName.Contains("Eckstein"))
                                                    {
                                                        Supplier_ID = Suplier_ID_drEckstein;
                                                    }
                                                    else if (SupplierName.Contains("Bizjan"))
                                                    {
                                                        Supplier_ID = Suplier_ID_Bizjan_doo;
                                                    }
                                                    else if (!UnknownSupplier(ref Supplier_ID, transaction))
                                                    {
                                                        return false;
                                                    }

                                                }
                                                else if (!UnknownSupplier(ref Supplier_ID, transaction))
                                                {
                                                    return false;
                                                }


                                                string ReferenceNote = null;
                                                string ReferenceHash = null;
                                                Image ReferenceImage = null;

                                                if (ID.Validate(Reference_ID))
                                                {
                                                    if (f_Reference.GetData(Reference_ID, ref ReferenceNote, ref ReferenceHash, ref ReferenceImage))
                                                    {

                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    //No reference
                                                    if (f_Reference.Get("Brez reference v stari bazi bazi verzije 1.9", null, ref Reference_ID, transaction))
                                                    {
                                                        ReferenceNote = "Brez reference";
                                                    }
                                                    else
                                                    {
                                                        return false;
                                                    }
                                                }
                                                DateTime_v StockTake_Date_v = new DateTime_v(PurchasePriceDate);
                                                string StockTake_Name = null;
                                                if (StockTake_Date_v != null)
                                                {
                                                    StockTake_Name = ReferenceNote + ":" + StockTake_Date_v.v.Day.ToString() + "." + StockTake_Date_v.v.Month.ToString() + "." + StockTake_Date_v.v.Year.ToString() + ":Prenos iz stare baze";
                                                }
                                                else
                                                {
                                                    StockTake_Name = ReferenceNote + ":Prenos iz stare baze";
                                                }
                                                decimal_v StockTakePriceTotal_v = new decimal_v(0);
                                                ID Reference_ID_v = new ID(Reference_ID);
                                                bool_v StockTakeDraft_v = new bool_v(false);
                                                if (!ID.Validate(Unknown_Trucking_ID))
                                                {
                                                    if (!UnknownTrucking(ref Unknown_Trucking_ID, transaction))
                                                    {
                                                        return false;
                                                    }
                                                }
                                                ID StockTake_ID = null;
                                                if (f_StockTake.Get(StockTake_Name,
                                                            StockTake_Date_v,
                                                            StockTakePriceTotal_v,
                                                            Reference_ID_v,
                                                            "Prenos prevzemnice iz stare baze",
                                                            Supplier_ID,
                                                            Unknown_Trucking_ID,
                                                            StockTakeDraft_v,
                                                            ref StockTake_ID,
                                                            transaction
                                                            ))
                                                {
                                                    ID PurchasePrice_Item_NEW_ID = null;
                                                    if (!f_PurchasePrice_Item.Get("PurchasePrice_Item_NEW", Item_ID, PurchasePrice_NEW_ID, StockTake_ID, ref PurchasePrice_Item_NEW_ID, transaction))
                                                    {
                                                        return false;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:No data row in PurchasePrice ID =" + PurchasePrice_ID.ToString());
                                                return false;
                                            }
                                        }

                                        sql = @"
                                        PRAGMA foreign_keys = OFF;
                                        DROP TABLE Supplier;
                                        ALTER TABLE Supplier_NEW RENAME TO Supplier;
                                        DROP TABLE PurchasePrice;
                                        ALTER TABLE PurchasePrice_NEW RENAME TO PurchasePrice;
                                        DROP TABLE PurchasePrice_Item;
                                        ALTER TABLE PurchasePrice_Item_NEW RENAME TO PurchasePrice_Item;
                                        DROP TABLE JOURNAL_PurchasePrice;
                                        DROP TABLE JOURNAL_PurchasePrice_TYPE;
                                        update Language set Name = 'Slovensko' where Name = 'Slovene';
                                        PRAGMA foreign_keys = ON;
                                        ";
                                        if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }

                                        sql = "update PurchasePrice set PurchasePricePerUnit = ";
                                        List<SQL_Parameter> lpary = new List<SQL_Parameter>();
                                        string spar_PurchasePricePerUnitWrong = "@par_PurchasePricePerUnitWrong";
                                        decimal dPurchasePricePerUnitWrong = 1455;
                                        SQL_Parameter par_StockTakePriceTotalWrong = new SQL_Parameter(spar_PurchasePricePerUnitWrong, SQL_Parameter.eSQL_Parameter.Decimal, false, dPurchasePricePerUnitWrong);
                                        lpary.Add(par_StockTakePriceTotalWrong);
                                        decimal dPurchasePricePerUnitReal = 14.55M;
                                        string spar_PurchasePricePerUnitReal = "@par_PurchasePricePerUnitReal";
                                        SQL_Parameter par_StockTakePriceTotalReal = new SQL_Parameter(spar_PurchasePricePerUnitReal, SQL_Parameter.eSQL_Parameter.Decimal, false, dPurchasePricePerUnitReal);
                                        lpary.Add(par_StockTakePriceTotalReal);

                                        sql = "update PurchasePrice set PurchasePricePerUnit = " + spar_PurchasePricePerUnitReal + " where PurchasePricePerUnit = " + spar_PurchasePricePerUnitWrong;
                                        if (!transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpary,  ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }

                                        if (!f_JOURNAL_Stock.Get_JOURNAL_Stock_Type_ID(transaction))
                                        {
                                            return false;
                                        }
                                        sql = "select ID from StockTake";
                                        DataTable dtStockTake = new DataTable();
                                        if (DBSync.DBSync.ReadDataTable(ref dtStockTake, sql, ref Err))
                                        {
                                            foreach (DataRow dr in dtStockTake.Rows)
                                            {
                                                ID StockTake_ID = tf.set_ID(dr["ID"]);
                                                DataTable dt_Stock_Of_Current_StockTake = new DataTable();
                                                Doc_ShopC_Item[] array_Doc_ShopC_Item = null;
                                                if (f_Stock.GeStockTakeItems(ref dt_Stock_Of_Current_StockTake, ref array_Doc_ShopC_Item, StockTake_ID))
                                                {
                                                    decimal dsum = 0;
                                                    foreach (DataRow drx in dt_Stock_Of_Current_StockTake.Rows)
                                                    {
                                                        decimal dquantity = (decimal)drx["dInitialQuantity"];
                                                        decimal dpurchasepriceperitem = (decimal)drx["PurchasePricePerUnit"];
                                                        dsum += dquantity * dpurchasepriceperitem;
                                                    }
                                                    List<SQL_Parameter> lparx = new List<SQL_Parameter>();
                                                    string spar_StockTakePriceTotal = "@par_StockTakePriceTotal";
                                                    SQL_Parameter par_StockTakePriceTotal = new SQL_Parameter(spar_StockTakePriceTotal, SQL_Parameter.eSQL_Parameter.Decimal, false, dsum);
                                                    lparx.Add(par_StockTakePriceTotal);
                                                    sql = "update StockTake set StockTakePriceTotal = " + spar_StockTakePriceTotal + " where ID = " + StockTake_ID.ToString();
                                                    if (!transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lparx, ref Err))
                                                    {
                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
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
                                sql = @"
                                        PRAGMA foreign_keys = OFF;
                                        DROP TABLE Supplier;
                                        ALTER TABLE Supplier_NEW RENAME TO Supplier;
                                        DROP TABLE PurchasePrice;
                                        ALTER TABLE PurchasePrice_NEW RENAME TO PurchasePrice;
                                        DROP TABLE PurchasePrice_Item;
                                        ALTER TABLE PurchasePrice_Item_NEW RENAME TO PurchasePrice_Item;
                                        DROP TABLE JOURNAL_PurchasePrice;
                                        DROP TABLE JOURNAL_PurchasePrice_TYPE;
                                        update Language set Name = 'Slovensko' where Name = 'Slovene';
                                        PRAGMA foreign_keys = ON;
                                        ";
                                if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Upgrade_inThread:FillStockTake:" + sql + ":\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Upgrade_inThread:FillStockTake:" + sql + ":\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Upgrade_inThread:FillStockTake:" + sql + ":\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Upgrade_inThread:FillStockTake:" + sql + ":\r\nErr=" + Err);
                return false;
            }
        }

        private static bool UnknownSupplier(ref ID Unknown_Supplier_ID, Transaction transaction)
        {
            ID UnknownContact_ID = null;
            if (UnknownContact(ref UnknownContact_ID, transaction))
            {
                return (f_Supplier.Get("Supplier_NEW", UnknownContact_ID, ref Unknown_Supplier_ID, transaction));
            }
            else
            {
                return false;
            }
        }

        private static bool UnknownContact(ref ID Unknown_Contact_ID, Transaction transaction)
        {
            string_v Organisation_Name_v = new string_v("Neznani dobavitelj");
            string_v Tax_ID_v = new string_v("neznana dav.št.");
            string_v Registration_ID_v = new string_v("neznana mat.št.");
            bool_v TaxPayer_v = null;
            string_v Comment1_v = null;
            string_v OrganisationTYPE_v = new string_v("neznani tip organizacije");
            PostAddress_v Address_v = new PostAddress_v();
            Address_v.City_v = new dstring_v("naznano mesto");
            Address_v.StreetName_v = new dstring_v("neznana ulica");
            Address_v.HouseNumber_v = new dstring_v("neznana številka");
            Address_v.ZIP_v = new dstring_v("neznani ZIP");
            Address_v.City_v = new dstring_v("naznano mesto");
            Address_v.Country_v = new dstring_v("Slovenija");
            Address_v.Country_ISO_3166_a2_v = new dstring_v("SI");
            Address_v.Country_ISO_3166_a3_v = new dstring_v("SVN");
            Address_v.Country_ISO_3166_num_v = new dshort_v(705);
            Address_v.State_v = null;
            string_v PhoneNumber_v = null;
            string_v FaxNumber_v = null;
            string_v Email_v = null;
            string_v HomePage_v = null;
            ID BankAccount_ID = null;
            string_v Organisation_BankAccount_Description_v = null;
            string_v Image_Hash_v = null;
            byte_array_v Image_Data_v = null;
            string_v Image_Description_v = null;
            bool_v Person_Gender_v = new bool_v(false);
            string_v FirstName_v = new DBTypes.string_v("neznana ime");
            string_v LastName_v = new DBTypes.string_v("neznano priimek");
            DateTime_v DateOfBirth_v = null;
            string_v Person_Tax_ID_v = new string_v("neznana dav.št.");
            string_v Person_Registration_ID_v = new string_v("neznana mat.št.");
            ID cAdressAtom_Org_iD = null;
            ID Organisation_ID = null;
            ID OrganisationData_ID = null;
            ID OrganisationAccount_ID = null;
            ID Person_ID = null;

            return (f_Contact.Get(Organisation_Name_v,
                Tax_ID_v,
                Registration_ID_v,
                TaxPayer_v,
                Comment1_v,
                OrganisationTYPE_v,
                Address_v,
                PhoneNumber_v,
                FaxNumber_v,
                Email_v,
                HomePage_v,
                BankAccount_ID,
                Organisation_BankAccount_Description_v,
                Image_Hash_v,
                Image_Data_v,
                Image_Description_v,
                Person_Gender_v,
                FirstName_v,
                LastName_v,
                DateOfBirth_v,
                Person_Tax_ID_v,
                Person_Registration_ID_v,
                ref cAdressAtom_Org_iD,
                ref Organisation_ID,
                ref OrganisationData_ID,
                ref OrganisationAccount_ID,
                ref Person_ID,
                ref Unknown_Contact_ID, transaction));
        }


        private static bool UnknownTrucking(ref ID Unknown_Trucking_ID, Transaction transaction)
        {
            ID UnknownContact_ID = null;
            if (UnknownContact(ref UnknownContact_ID, transaction))
            {
                decimal_v TruckingCost_v = null;
                string_v TruckingNumber_v = null;
                decimal_v Customs_v = null;
                string_v Description_v = new string_v("Transportni stroški niso znani");

                return (f_Trucking.Get(UnknownContact_ID,
                                TruckingCost_v,
                                TruckingNumber_v,
                                Customs_v,
                                Description_v,
                                        ref Unknown_Trucking_ID, transaction));
            }
            else
            {
                return false;
            }
        }

        private static bool InsertDrEcksteinGmbh_Contact(ref ID Contact_ID, Transaction transaction)
        {
            string_v Organisation_Name_v = new string_v("Linde Eckstein GmbH");
            string_v Tax_ID_v = new string_v("132747963");
            string_v Registration_ID_v = new string_v("218/167/50501");
            bool_v TaxPayer_v = new bool_v(true);
            string_v Comment1_v = null;
            string_v OrganisationTYPE_v = new string_v("Gmbh");
            PostAddress_v Address_v = new PostAddress_v();

            Address_v.StreetName_v = new dstring_v("Flurstraße");
            Address_v.HouseNumber_v = new dstring_v("27 a – 35");
            Address_v.ZIP_v = new dstring_v("90522");
            Address_v.City_v = new dstring_v("Oberasbach");
            Address_v.Country_v = new dstring_v("Germany");
            Address_v.Country_ISO_3166_a2_v = new dstring_v("DE");
            Address_v.Country_ISO_3166_a3_v = new dstring_v("DEU");
            Address_v.Country_ISO_3166_num_v = new dshort_v(276);
            Address_v.State_v = null;

            string_v PhoneNumber_v = new string_v("+49 911 96 92-0");
            string_v FaxNumber_v = new string_v("+49 911 96 92-200");
            string_v Email_v = new string_v("M.Peter@eckstein-kosmetik.de");
            string_v HomePage_v = new string_v("http://www.eckstein-kosmetik.de/");
            ID BankAccount_ID = null;
            string_v Organisation_BankAccount_Description_v = null;
            string_v Image_Hash_v = null;
            byte_array_v Image_Data_v = null;
            string_v Image_Description_v = null;
            ID cAdressAtom_Org_iD = null;
            ID Organisation_ID = null;
            ID OrganisationData_ID = null;
            ID OrganisationAccount_ID = null;

            bool_v Person_Gender_v = null;
            string_v FirstName_v = null;
            string_v LastName_v = null;
            DateTime_v DateOfBirth_v = null;
            string_v Person_Tax_ID_v = null;
            string_v Person_Registration_ID_v = null;


            ID Person_ID = null;

            if (f_Contact.Get(Organisation_Name_v,
            Tax_ID_v,
            Registration_ID_v,
            TaxPayer_v,
            Comment1_v,
            OrganisationTYPE_v,
            Address_v,
            PhoneNumber_v,
            FaxNumber_v,
            Email_v,
            HomePage_v,
            BankAccount_ID,
            Organisation_BankAccount_Description_v,
            Image_Hash_v,
            Image_Data_v,
            Image_Description_v,
            Person_Gender_v,
            FirstName_v,
            LastName_v,
            DateOfBirth_v,
            Person_Tax_ID_v,
            Person_Registration_ID_v,
            ref cAdressAtom_Org_iD,
            ref Organisation_ID,
            ref OrganisationData_ID,
            ref OrganisationAccount_ID,
            ref Person_ID,
            ref Contact_ID,
            transaction))
            {
                return true;
            }
            else
            {
                Contact_ID = null;
                return false;
            }
        }



        private static bool InsertBizjan_doo_Contact(ref ID Contact_ID, Transaction transaction)
        {
            string_v Organisation_Name_v = new string_v("Bizjan d.o.o.&Co");
            string_v Tax_ID_v = new string_v("18351182");
            string_v Registration_ID_v = new string_v("1319337000");
            bool_v TaxPayer_v = new bool_v(true);
            string_v Comment1_v = null;
            string_v OrganisationTYPE_v = new string_v("d.o.o.");
            PostAddress_v Address_v = new PostAddress_v();

            Address_v.StreetName_v = new dstring_v("Malgajeva ulica");
            Address_v.HouseNumber_v = new dstring_v("7");
            Address_v.ZIP_v = new dstring_v("1000");
            Address_v.City_v = new dstring_v("Ljubljana");
            Address_v.Country_v = new dstring_v("Slovenija");
            Address_v.Country_ISO_3166_a2_v = new dstring_v("SI");
            Address_v.Country_ISO_3166_a3_v = new dstring_v("SVN");
            Address_v.Country_ISO_3166_num_v = new dshort_v(705);
            Address_v.State_v = null;

            string_v PhoneNumber_v = new string_v("+386 1 4347711 ");
            string_v FaxNumber_v = new string_v("+386 1 4347712");
            string_v Email_v = new string_v("bizjan.co@siol.net");
            string_v HomePage_v = new string_v("http://www.bizjan-co.si");
            ID BankAccount_ID = null;
            string_v Organisation_BankAccount_Description_v = null;
            string_v Image_Hash_v = null;
            byte_array_v Image_Data_v = null;
            string_v Image_Description_v = null;
            ID cAdressAtom_Org_iD = null;
            ID Organisation_ID = null;
            ID OrganisationData_ID = null;
            ID OrganisationAccount_ID = null;
            bool_v Person_Gender_v = null;
            string_v FirstName_v = null;
            string_v LastName_v = null;
            DateTime_v DateOfBirth_v = null;
            string_v Person_Tax_ID_v = null;
            string_v Person_Registration_ID_v = null;


            ID Person_ID = null;

            if (f_Contact.Get(Organisation_Name_v,
            Tax_ID_v,
            Registration_ID_v,
            TaxPayer_v,
            Comment1_v,
            OrganisationTYPE_v,
            Address_v,
            PhoneNumber_v,
            FaxNumber_v,
            Email_v,
            HomePage_v,
            BankAccount_ID,
            Organisation_BankAccount_Description_v,
            Image_Hash_v,
            Image_Data_v,
            Image_Description_v,
            Person_Gender_v,
            FirstName_v,
            LastName_v,
            DateOfBirth_v,
            Person_Tax_ID_v,
            Person_Registration_ID_v,
            ref cAdressAtom_Org_iD,
            ref Organisation_ID,
            ref OrganisationData_ID,
            ref OrganisationAccount_ID,
            ref Person_ID,
            ref Contact_ID,
            transaction))
            {
                return true;
            }
            else
            {
                Contact_ID = null;
                return false;
            }
        }

    }
}
