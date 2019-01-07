using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace UpgradeDB
{




    internal static class Upgrade_1_27_to_1_28
    {
        private static CashierActivityList cashierActivityList = new CashierActivityList();

        internal static object UpgradeDB_1_27_to_1_28(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_27_to_1_28 = DBSync.DBSync.NewTransaction("UpgradeDB_1_27_to_1_28");
            cashierActivityList.Clear();
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_27_to_1_28))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person
                string[] new_tables = new string[] {
                                        "DocInvoice_ShopC_Item_Source",
                                        "DocProformaInvoice_ShopC_Item_Source",
                                        "StornoName",
                                        "StornoReason",
                                    };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_27_to_1_28))
                {
                    transaction_UpgradeDB_1_27_to_1_28.Rollback();
                    return false;
                }

                string sql = @"
                    PRAGMA foreign_keys = OFF;
                    CREATE TABLE DocInvoice_ShopC_Item_TEMP ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                              DocInvoice_ID INTEGER NOT NULL REFERENCES DocInvoice(ID),
                                                              Atom_Price_Item_ID INTEGER NOT NULL REFERENCES Atom_Price_Item(ID),
                                                              ExtraDiscount DECIMAL(18, 5));

                    CREATE TABLE DocInvoice_ShopC_Item_Source_TEMP 
                                                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                               DocInvoice_ShopC_Item_TEMP_ID INTEGER NOT NULL REFERENCES DocInvoice_ShopC_Item_TEMP(ID),
                                                               Stock_ID INTEGER NULL REFERENCES Stock(ID),
                                                               dQuantity DECIMAL(18,5) NOT NULL,
                                                               'SourceDiscount' DECIMAL(18,5) NOT NULL,
                                                               'RetailPriceWithDiscount' DECIMAL(18,5) NOT NULL,
                                                               'TaxPrice' DECIMAL(18,5) NOT NULL,
                                                               'ExpiryDate' DATETIME NULL );               

                    Insert into DocInvoice_ShopC_Item_TEMP(DocInvoice_ID,
                                                           Atom_Price_Item_ID,
                                                           ExtraDiscount) 
                                                           SELECT 
                                                           DocInvoice_ID,
                                                           Atom_Price_Item_ID,
                                                           ExtraDiscount
                                                           from DocInvoice_ShopC_Item  group by DocInvoice_ID,Atom_Price_Item_ID,ExtraDiscount;

                    CREATE TABLE DocProformaInvoice_ShopC_Item_TEMP ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                              DocProformaInvoice_ID INTEGER NOT NULL REFERENCES DocProformaInvoice(ID),
                                                              Atom_Price_Item_ID INTEGER NOT NULL REFERENCES Atom_Price_Item(ID),
                                                              ExtraDiscount DECIMAL(18, 5) NOT NULL);

                    CREATE TABLE DocProformaInvoice_ShopC_Item_Source_TEMP 
                                                            ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                               DocProformaInvoice_ShopC_Item_TEMP_ID INTEGER NOT NULL REFERENCES DocProformaInvoice_ShopC_Item_TEMP(ID),
                                                               Stock_ID INTEGER NULL REFERENCES Stock(ID),
                                                               dQuantity DECIMAL(18,5) NOT NULL,
                                                               'SourceDiscount' DECIMAL(18,5) NOT NULL,
                                                               'RetailPriceWithDiscount' DECIMAL(18,5) NOT NULL,
                                                               'TaxPrice' DECIMAL(18,5) NOT NULL,
                                                               'ExpiryDate' DATETIME NULL );  

                    Insert into  DocProformaInvoice_ShopC_Item_TEMP (DocProformaInvoice_ID,
                                                           Atom_Price_Item_ID,
                                                           ExtraDiscount) 
                                                           SELECT 
                                                           DocProformaInvoice_ID,
                                                           Atom_Price_Item_ID,
                                                           ExtraDiscount
                                                           from DocProformaInvoice_ShopC_Item  group by DocProformaInvoice_ID,Atom_Price_Item_ID,ExtraDiscount;

                     CREATE TABLE Atom_WorkPeriod_TEMP 
                     ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT, 
                        Atom_myOrganisation_Person_ID INTEGER NOT NULL REFERENCES Atom_myOrganisation_Person(ID),
                        Atom_ElectronicDevice_ID INTEGER NOT NULL REFERENCES Atom_ElectronicDevice(ID),
                        'LoginTime' DATETIME NULL,
                        'LogoutTime' DATETIME NULL,
                        Atom_WorkPeriod_TYPE_ID INTEGER NULL REFERENCES Atom_WorkPeriod_TYPE(ID),
                        Atom_IP_address_ID INTEGER NULL REFERENCES Atom_IP_address(ID) );

                    CREATE TABLE Atom_Computer_TEMP ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        Atom_ComputerName_ID INTEGER NOT NULL REFERENCES Atom_ComputerName(ID),
                                                        Atom_MAC_address_ID INTEGER NULL REFERENCES Atom_MAC_address(ID),
                                                        Atom_ComputerUserName_ID INTEGER NULL REFERENCES Atom_ComputerUserName(ID) );

                     insert into Atom_WorkPeriod_TEMP 
                     (  ID, 
                        Atom_myOrganisation_Person_ID,
                        Atom_ElectronicDevice_ID,
                        LoginTime,
                        LogoutTime,
                        Atom_WorkPeriod_TYPE_ID,
                        Atom_IP_address_ID)
                     select 
                     awp.ID,
                     awp.Atom_myOrganisation_Person_ID,
                     awp.Atom_ElectronicDevice_ID,
                     awp.LoginTime,
                     awp.LogoutTime,
                     awp.Atom_WorkPeriod_TYPE_ID,
                     ac.Atom_IP_address_ID
                     from Atom_WorkPeriod awp
                     inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                     inner join Atom_Computer ac on aed.Atom_Computer_ID = ac.ID;

                    insert into Atom_Computer_TEMP
                    (
                    ID,
                    Atom_ComputerName_ID,
                    Atom_MAC_address_ID,
                    Atom_ComputerUserName_ID)
                    select
                    ID,
                    Atom_ComputerName_ID,
                    Atom_MAC_address_ID,
                    Atom_ComputerUserName_ID
                    from Atom_Computer;
                    ";
                if (!transaction_UpgradeDB_1_27_to_1_28.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_27_to_1_28.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }


                if (!WriteDocInvoice_ShopC_Item_Source(transaction_UpgradeDB_1_27_to_1_28))
                {
                    transaction_UpgradeDB_1_27_to_1_28.Rollback();
                    return false;
                }

                if (!WriteDocProformaInvoice_ShopC_Item_Source(transaction_UpgradeDB_1_27_to_1_28))
                {
                    transaction_UpgradeDB_1_27_to_1_28.Rollback();
                    return false;
                }

                transaction_UpgradeDB_1_27_to_1_28.Commit();

                sql = @"        
                                PRAGMA foreign_keys = OFF;

                                DROP TABLE DocInvoice_ShopC_Item;

                                CREATE TABLE DocInvoice_ShopC_Item ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                              DocInvoice_ID INTEGER NOT NULL REFERENCES DocInvoice(ID),
                                                              Atom_Price_Item_ID INTEGER NOT NULL REFERENCES Atom_Price_Item(ID),
                                                              ExtraDiscount DECIMAL(18, 5));

                                insert into DocInvoice_ShopC_Item
                                                              (
                                                              ID,
                                                              DocInvoice_ID,
                                                              Atom_Price_Item_ID,
                                                              ExtraDiscount
                                                              )
                                                              select 
                                                              ID,
                                                              DocInvoice_ID,
                                                              Atom_Price_Item_ID,
                                                              ExtraDiscount
                                                              from DocInvoice_ShopC_Item_TEMP;

                                insert into DocInvoice_ShopC_Item_Source
                                                             (
                                                               ID,
                                                               DocInvoice_ShopC_Item_ID,
                                                               Stock_ID,
                                                               dQuantity,
                                                               SourceDiscount,
                                                               RetailPriceWithDiscount,
                                                               TaxPrice,
                                                               ExpiryDate
                                                              )
                                                             select 
                                                               ID,
                                                               DocInvoice_ShopC_Item_TEMP_ID,
                                                               Stock_ID,
                                                               dQuantity,
                                                               SourceDiscount,
                                                               RetailPriceWithDiscount,
                                                               TaxPrice,
                                                               ExpiryDate
                                                               from DocInvoice_ShopC_Item_Source_TEMP;

                                DROP TABLE DocProformaInvoice_ShopC_Item;

                                CREATE TABLE DocProformaInvoice_ShopC_Item ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                              DocProformaInvoice_ID INTEGER NOT NULL REFERENCES DocProformaInvoice(ID),
                                                              Atom_Price_Item_ID INTEGER NOT NULL REFERENCES Atom_Price_Item(ID),
                                                              ExtraDiscount DECIMAL(18, 5));

                                insert into DocProformaInvoice_ShopC_Item
                                                              (
                                                              ID,
                                                              DocProformaInvoice_ID,
                                                              Atom_Price_Item_ID,
                                                              ExtraDiscount
                                                              )
                                                              select 
                                                              ID,
                                                              DocProformaInvoice_ID,
                                                              Atom_Price_Item_ID,
                                                              ExtraDiscount
                                                              from DocProformaInvoice_ShopC_Item_TEMP;

                                insert into DocProformaInvoice_ShopC_Item_Source
                                                             (
                                                               ID,
                                                               DocProformaInvoice_ShopC_Item_ID,
                                                               Stock_ID,
                                                               dQuantity,
                                                               SourceDiscount,
                                                               RetailPriceWithDiscount,
                                                               TaxPrice,
                                                               ExpiryDate
                                                              )
                                                             select 
                                                               ID,
                                                               DocProformaInvoice_ShopC_Item_TEMP_ID,
                                                               Stock_ID,
                                                               dQuantity,
                                                               SourceDiscount,
                                                               RetailPriceWithDiscount,
                                                               TaxPrice,
                                                               ExpiryDate
                                                               from DocProformaInvoice_ShopC_Item_Source_TEMP;

                                DROP TABLE DocInvoice_ShopC_Item_Source_TEMP;
                                DROP TABLE DocInvoice_ShopC_Item_TEMP;

                                DROP TABLE DocProformaInvoice_ShopC_Item_Source_TEMP;
                                DROP TABLE DocProformaInvoice_ShopC_Item_TEMP;
                                
                                DROP TABLE Atom_WorkPeriod;
                                ALTER TABLE Atom_WorkPeriod_TEMP RENAME TO Atom_WorkPeriod;

                                DROP TABLE Atom_Computer;
                                ALTER TABLE Atom_Computer_TEMP RENAME TO Atom_Computer;
                                PRAGMA foreign_keys = ON;
                                
                    ";
                //if (!transaction_UpgradeDB_1_27_to_1_28.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                DBSync.DBSync.Con.TransactionsOnly = false;
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
                DBSync.DBSync.Con.TransactionsOnly = true;

                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_27_to_1_28))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.28", transaction_UpgradeDB_1_27_to_1_28))
                    {
                        if (transaction_UpgradeDB_1_27_to_1_28.Commit())
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
                        transaction_UpgradeDB_1_27_to_1_28.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_27_to_1_28.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_27_to_1_28.Rollback();
                return false;
            }
        }

        private static bool WriteDocInvoice_ShopC_Item_Source(Transaction transaction)
        {
            string sql_Temp = @"Select 
            ID, 
		    DocInvoice_ID,
		    Atom_Price_Item_ID,
            ExtraDiscount
		    from DocInvoice_ShopC_Item_TEMP";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_Temp, ref Err))
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                    
                    ID doc_ShopC_Item_TEMP_ID = tf.set_ID(dr["ID"]);
                    ID doc_ID = tf.set_ID(dr["DocInvoice_ID"]);
                    ID atom_Price_Item_ID = tf.set_ID(dr["Atom_Price_Item_ID"]);
                    decimal_v ExtraDiscount_v = tf.set_decimal(dr["ExtraDiscount"]);
                    ID[] doc_ShopC_Item_ID = null;
                    ID[] stock_ID = null;
                    if (get_doc_ShopC_Item_ID("DocInvoice",doc_ID, atom_Price_Item_ID, ExtraDiscount_v, ref doc_ShopC_Item_ID, ref stock_ID))
                    {
                        string sql = null;
                        foreach (ID stock_id in stock_ID)
                        {
                            if (ID.Validate(stock_id))
                            {
                                sql = @"
                                INSERT Into DocInvoice_ShopC_Item_Source_TEMP
                                (
                                DocInvoice_ShopC_Item_TEMP_ID,
                                Stock_ID,
                                dQuantity,
                                SourceDiscount,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        )
                                SELECT  
                                " + doc_ShopC_Item_TEMP_ID.ToString() + @",
	                            " + stock_id.ToString() + @",
		                        dQuantity,
                                0,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        from DocInvoice_ShopC_Item where DocInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = " + atom_Price_Item_ID.ToString();
                            }
                            else
                            {
                                sql = @"
                                INSERT Into DocInvoice_ShopC_Item_Source_TEMP
                                (
                                DocInvoice_ShopC_Item_TEMP_ID,
                                Stock_ID,
                                dQuantity,
                                SourceDiscount,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        )
                                SELECT  
                                " + doc_ShopC_Item_TEMP_ID.ToString() + @",
	                            null,
		                        dQuantity,
                                0,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        from DocInvoice_ShopC_Item where DocInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = " + atom_Price_Item_ID.ToString();
                            }
                            if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con, sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql_Temp + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool get_doc_ShopC_Item_ID(string doctype,ID doc_ID, ID atom_Price_Item_ID, decimal_v extraDiscount_v, ref ID[] doc_ShopC_Item_ID, ref ID[] stock_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_doc_ID = "@par_doc_ID";
            SQL_Parameter par_doc_ID = new SQL_Parameter(spar_doc_ID, false, doc_ID);
            lpar.Add(par_doc_ID);

            string spar_atom_Price_Item_ID = "@par_atom_Price_Item_ID";
            SQL_Parameter par_atom_Price_Item_ID = new SQL_Parameter(spar_atom_Price_Item_ID, false, atom_Price_Item_ID);
            lpar.Add(par_atom_Price_Item_ID);


            string scond_ExtraDiscount = "ExtraDiscount is null";
            if (extraDiscount_v != null)
            {
                string spar_ExtraDiscount = "@par_ExtraDiscount";
                SQL_Parameter par_ExtraDiscount = new SQL_Parameter(spar_ExtraDiscount,SQL_Parameter.eSQL_Parameter.Decimal, false, extraDiscount_v.v);
                lpar.Add(par_ExtraDiscount);
                scond_ExtraDiscount = "ExtraDiscount = " + spar_ExtraDiscount;
            }

            string sql = @"Select 
                            ID, 
                            Stock_ID
		                    from "+ doctype + "_ShopC_Item where "+ doctype + "_ID = "+ spar_doc_ID + " and Atom_Price_Item_ID = "+ spar_atom_Price_Item_ID+" and "+ scond_ExtraDiscount;
            DataTable dt = new DataTable();
            string err = null;
            if (DBSync.DBSync.Con.ReadDataTable(ref dt, sql,lpar,ref err))
            {
                int iCount = dt.Rows.Count;
                if (iCount>0)
                {
                    doc_ShopC_Item_ID = new ID[iCount];
                    stock_ID = new ID[iCount];
                    for (int i=0;i<iCount;i++)
                    { 
                        doc_ShopC_Item_ID[i] = tf.set_ID(dt.Rows[i]["ID"]);
                        stock_ID[i] = tf.set_ID(dt.Rows[i]["Stock_ID"]);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("iCount==0");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        private static bool WriteDocProformaInvoice_ShopC_Item_Source(Transaction transaction)
        {
            string sql_Temp = @"Select 
            ID, 
		    DocProformaInvoice_ID,
		    Atom_Price_Item_ID
		    from DocProformaInvoice_ShopC_Item_TEMP";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_Temp, ref Err))
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;

                    ID doc_ShopC_Item_TEMP_ID = tf.set_ID(dr["ID"]);
                    ID doc_ID = tf.set_ID(dr["DocProformaInvoice_ID"]);
                    ID atom_Price_Item_ID = tf.set_ID(dr["Atom_Price_Item_ID"]);
                    decimal_v ExtraDiscount_v = tf.set_decimal(dr["ExtraDiscount"]);
                    ID[] doc_ShopC_Item_ID = null;
                    ID[] stock_ID = null;
                    if (get_doc_ShopC_Item_ID("DocProformaInvoice", doc_ID, atom_Price_Item_ID, ExtraDiscount_v, ref doc_ShopC_Item_ID, ref stock_ID))
                    {
                        string sql = null;
                        foreach (ID stock_id in stock_ID)
                        {
                            if (ID.Validate(stock_id))
                            {
                                sql = @"
                                INSERT Into DocProformaInvoice_ShopC_Item_Source_TEMP
                                (
                                DocProformaInvoice_ShopC_Item_TEMP_ID,
                                Stock_ID,
                                dQuantity,
                                SourceDiscount,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        )
                                SELECT  
                                " + doc_ShopC_Item_TEMP_ID.ToString() + @",
	                            " + stock_id.ToString() + @",
		                        dQuantity,
                                0,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        from DocProformaInvoice_ShopC_Item where DocProformaInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = " + atom_Price_Item_ID.ToString();
                            }
                            else
                            {
                                sql = @"
                                INSERT Into DocProformaInvoice_ShopC_Item_Source_TEMP
                                (
                                DocProformaInvoice_ShopC_Item_TEMP_ID,
                                Stock_ID,
                                dQuantity,
                                SourceDiscount,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        )
                                SELECT  
                                " + doc_ShopC_Item_TEMP_ID.ToString() + @",
	                            null,
		                        dQuantity,
                                0,
		                        RetailPriceWithDiscount,
		                        TaxPrice, 
		                        ExpiryDate
		                        from DocProformaInvoice_ShopC_Item where DocProformaInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = " + atom_Price_Item_ID.ToString();
                            }
                            if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con, sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql_Temp + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
