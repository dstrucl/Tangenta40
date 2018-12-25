using DBConnectionControl40;
using DBTypes;
using System.Data;

namespace UpgradeDB
{




    internal static class Upgrade_1_28_to_1_29
    {
        private static CashierActivityList cashierActivityList = new CashierActivityList();

        internal static object UpgradeDB_1_28_to_1_29(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_28_to_1_29 = new Transaction("UpgradeDB_1_28_to_1_29", DBSync.DBSync.MyTransactionLog_delegates);
            cashierActivityList.Clear();
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_28_to_1_29))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string strVAT_bit = "0";
                if (DBSync.DBSync.DataBase.ToLower().Contains("studiomarjetka"))
                {
                    strVAT_bit = "0";
                }
                string sql = @"
                    PRAGMA foreign_keys = OFF;
                    CREATE TABLE StockTake_TEMP ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                  'Name' varchar(264) UNIQUE NOT NULL UNIQUE ,
                                                  'StockTake_Date' DATETIME NOT NULL,
                                                  'StockTakePriceTotal' DECIMAL(18,5) NOT NULL,
                                                  'StockTakePriceTotalWithVAT'  BIT NOT NULL,
                                                   Reference_ID INTEGER NOT NULL REFERENCES Reference(ID),
                                                  'Description' varchar(2000) NULL,
                                                   Supplier_ID INTEGER NOT NULL REFERENCES Supplier(ID),
                                                   Trucking_ID INTEGER NOT NULL REFERENCES Trucking(ID),
                                                  'Draft' BIT NOT NULL );

                    CREATE TABLE WorkArea_TEMP ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                 'Name' varchar(264) NOT NULL,
                                                 'Description' varchar(2000) NULL,
                                                  'Active' BIT NOT NULL,
                                                  WorkAreaImage_ID INTEGER NULL REFERENCES WorkAreaImage(ID),
                                                  WorkArea_ParentGroup1_ID INTEGER NULL REFERENCES WorkArea_ParentGroup1(ID),
                                                  PriceList_ID INTEGER NULL REFERENCES PriceList(ID)
                                                  );

                    Insert into StockTake_TEMP( ID,
                                                  Name,
                                                  StockTake_Date,
                                                  StockTakePriceTotal,
                                                  StockTakePriceTotalWithVAT,
                                                  Reference_ID,
                                                  Description,
                                                  Supplier_ID,
                                                  Trucking_ID,
                                                  Draft) 
                                                  SELECT 
                                                  ID,
                                                  Name,
                                                  StockTake_Date,
                                                  StockTakePriceTotal,
                                                  "+strVAT_bit+@",
                                                  Reference_ID,
                                                  Description,
                                                  Supplier_ID,
                                                  Trucking_ID,
                                                  Draft
                                                  from StockTake;


                    insert into WorkArea_TEMP ( ID,
                                                 Name,
                                                 Description,
                                                 Active,
                                                 WorkAreaImage_ID,
                                                 WorkArea_ParentGroup1_ID,
                                                 PriceList_ID
                                                )
                                                select
                                                ID,
                                                Name,
                                                Description,
                                                Active,
                                                WorkAreaImage_ID,
                                                WorkArea_ParentGroup1_ID,
                                                1
                                                from WorkArea;

                                DROP TABLE StockTake;
                                ALTER TABLE StockTake_TEMP RENAME TO StockTake;

                                DROP TABLE WorkArea;
                                ALTER TABLE WorkArea_TEMP RENAME TO WorkArea;

                                PRAGMA foreign_keys = ON;
                    ";
                if (!transaction_UpgradeDB_1_28_to_1_29.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_28_to_1_29.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_28_to_1_29:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_28_to_1_29))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.29", transaction_UpgradeDB_1_28_to_1_29))
                    {
                        transaction_UpgradeDB_1_28_to_1_29.Commit();
                        return true;
                    }
                    else
                    {
                        transaction_UpgradeDB_1_28_to_1_29.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_28_to_1_29.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_28_to_1_29.Rollback();
                return false;
            }
        }
    }
}
