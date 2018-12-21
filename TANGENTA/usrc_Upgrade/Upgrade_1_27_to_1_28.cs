using DBConnectionControl40;
using DBTypes;
using System.Data;

namespace UpgradeDB
{




    internal static class Upgrade_1_27_to_1_28
    {
        private static CashierActivityList cashierActivityList = new CashierActivityList();

        internal static object UpgradeDB_1_27_to_1_28(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_27_to_1_28 = new Transaction("UpgradeDB_1_27_to_1_28");
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
                                                              ExtraDiscount DECIMAL(18, 5) NOT NULL);

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

                sql = @" 
                                DROP TABLE DocInvoice_ShopC_Item;
                                ALTER TABLE DocInvoice_ShopC_Item_TEMP RENAME TO DocInvoice_ShopC_Item;

                                DROP TABLE DocProformaInvoice_ShopC_Item;
                                ALTER TABLE DocProformaInvoice_ShopC_Item_TEMP RENAME TO DocProformaInvoice_ShopC_Item;

                                DROP TABLE Atom_Computer;
                                ALTER TABLE Atom_Computer_TEMP RENAME TO Atom_Computer;

                                DROP TABLE Atom_WorkPeriod;
                                ALTER TABLE Atom_WorkPeriod_TEMP RENAME TO Atom_WorkPeriod;

                                PRAGMA foreign_keys = ON;
                    ";
                if (!transaction_UpgradeDB_1_27_to_1_28.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

              
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
		    Atom_Price_Item_ID
		    from DocInvoice_ShopC_Item_TEMP";
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_Temp, ref Err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ID doc_ShopC_Item_ID = tf.set_ID(dr["ID"]);
                    ID doc_ID = tf.set_ID(dr["DocInvoice_ID"]);
                    ID atom_Price_Item_ID = tf.set_ID(dr["Atom_Price_Item_ID"]);
                    string sql = @"
                    INSERT Into DocInvoice_ShopC_Item_Source
                    (
                    DocInvoice_ShopC_Item_ID,
                    Stock_ID,
                    dQuantity,
                    SourceDiscount,
		            RetailPriceWithDiscount,
		            TaxPrice, 
		            ExpiryDate
		            )
                    SELECT  
                    " + doc_ShopC_Item_ID.ToString() + @",
	                Stock_ID,
		            dQuantity,
                    0,
		            RetailPriceWithDiscount,
		            TaxPrice, 
		            ExpiryDate
		            from DocInvoice_ShopC_Item where DocInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = "+ atom_Price_Item_ID.ToString();

                    if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                        return false;
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
                foreach (DataRow dr in dt.Rows)
                {
                    ID doc_ShopC_Item_ID = tf.set_ID(dr["ID"]);
                    ID doc_ID = tf.set_ID(dr["DocProformaInvoice_ID"]);
                    ID atom_Price_Item_ID = tf.set_ID(dr["Atom_Price_Item_ID"]);
                    string sql = @"
                    INSERT Into DocProformaInvoice_ShopC_Item_Source
                    (
                    DocProformaInvoice_ShopC_Item_ID,
                    Stock_ID,
                    dQuantity,
                    SourceDiscount,
		            RetailPriceWithDiscount,
		            TaxPrice, 
		            ExpiryDate
		            )
                    SELECT  
                    " + doc_ShopC_Item_ID.ToString() + @",
		            Stock_ID,
		            dQuantity,
                    0,
		            RetailPriceWithDiscount,
		            TaxPrice, 
		            ExpiryDate
		            from DocProformaInvoice_ShopC_Item where DocProformaInvoice_ID = " + doc_ID.ToString() + " and Atom_Price_Item_ID = " + atom_Price_Item_ID.ToString();

                    if (!transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                        return false;
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
