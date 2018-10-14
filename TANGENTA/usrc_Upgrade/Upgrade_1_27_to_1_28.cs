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
            cashierActivityList.Clear();
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person
                string[] new_tables = new string[] {
                                        "DocInvoice_ShopC_Item_Source",
                                        "DocProformaInvoice_ShopC_Item_Source"
                                    };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
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
                    ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                if (!WriteDocInvoice_ShopC_Item_Source())
                {
                    return false;
                }

                if (!WriteDocProformaInvoice_ShopC_Item_Source())
                {
                    return false;
                }

                sql = @" 
                                DROP TABLE DocInvoice_ShopC_Item;
                                ALTER TABLE DocInvoice_ShopC_Item_TEMP RENAME TO DocInvoice_ShopC_Item;

                                DROP TABLE DocProformaInvoice_ShopC_Item;
                                ALTER TABLE DocProformaInvoice_ShopC_Item_TEMP RENAME TO DocProformaInvoice_ShopC_Item;
                                PRAGMA foreign_keys = ON;
                    ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_27_to_1_28:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

              
                if (DBSync.DBSync.Create_VIEWs())
                {
                    return UpgradeDB_inThread.Set_DataBase_Version("1.28");
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

        private static bool WriteDocInvoice_ShopC_Item_Source()
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

                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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


        private static bool WriteDocProformaInvoice_ShopC_Item_Source()
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

                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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
