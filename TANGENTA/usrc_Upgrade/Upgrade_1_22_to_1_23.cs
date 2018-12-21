using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_22_to_1_23
    {


        internal static object UpgradeDB_1_22_to_1_23(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_22_to_1_23 = new Transaction("UpgradeDB_1_22_to_1_23");
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_22_to_1_23))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"
                        PRAGMA foreign_keys = OFF;

                        CREATE TABLE Item_temp (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'UniqueName' varchar(264) UNIQUE NOT NULL UNIQUE ,
                        'Name' varchar(264) NULL,
                         Unit_ID INTEGER NOT NULL REFERENCES Unit(ID),
                         'Code' INTEGER NULL,
                        Item_ParentGroup1_ID INTEGER NULL REFERENCES Item_ParentGroup1(ID),
                       'barcode' varchar(32) NULL,
                       'Description' varchar(2000) NULL,
                        Item_Image_ID INTEGER NULL REFERENCES Item_Image(ID),
                        Expiry_ID INTEGER NULL REFERENCES Expiry(ID),
                        Warranty_ID INTEGER NULL REFERENCES Warranty(ID),
                        'ToOffer' BIT NOT NULL );

                        insert into Item_temp
                        (
                          ID,
                          UniqueName,
                          Name,
                          Unit_ID,
                          Code,
                          Item_ParentGroup1_ID,
                          barcode,
                          Description,
                          Item_Image_ID,
                          Expiry_ID,
                          Warranty_ID,
                          ToOffer
                        )
                        select
                          ID,
                          UniqueName,
                          Name,
                          Unit_ID,
                          Code,
                          Item_ParentGroup1_ID,
                          barcode,
                          Description,
                          Item_Image_ID,
                          Expiry_ID,
                          Warranty_ID,
                          ToOffer  
                        from Item;

                        DROP TABLE Item;
                        ALTER TABLE Item_temp RENAME TO Item;

                        PRAGMA foreign_keys = ON;
                                ";

                if (!transaction_UpgradeDB_1_22_to_1_23.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_22_to_1_23:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_22_to_1_23))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.23", transaction_UpgradeDB_1_22_to_1_23))
                    {
                        if (transaction_UpgradeDB_1_22_to_1_23.Commit())
                        {
                            return true;
                        }
                    }
                }
            }
            transaction_UpgradeDB_1_22_to_1_23.Rollback();
            return false;
        }
    }
}
