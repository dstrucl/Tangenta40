using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_23_to_1_24
    {


        internal static object UpgradeDB_1_23_to_1_24(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_23_to_1_24 = new Transaction("UpgradeDB_1_23_to_1_24", DBSync.DBSync.MyTransactionLog_delegates);
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_23_to_1_24))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"

                        PRAGMA foreign_keys = OFF;

                        CREATE TABLE Atom_SimpleItem_temp(
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        SimpleItem_ID INTEGER NOT NULL REFERENCES SimpleItem(ID),
                        Atom_SimpleItem_Name_ID INTEGER NOT NULL REFERENCES Atom_SimpleItem_Name(ID),
                        Atom_SimpleItem_Image_ID INTEGER NULL REFERENCES Atom_SimpleItem_Image(ID),
                        Code INTEGER null);

                        insert into Atom_SimpleItem_temp
                        (
                          ID,
                          SimpleItem_ID,
                          Atom_SimpleItem_Name_ID,
                          Atom_SimpleItem_Image_ID,
                          Code
                        )
                        select
                          asi.ID,
                          asi.SimpleItem_ID,
                          asi.Atom_SimpleItem_Name_ID,
                          asi.Atom_SimpleItem_Image_ID,
                          si.Code
                        from Atom_SimpleItem asi
                        inner join SimpleItem si on si.ID = asi.SimpleItem_ID;

                        DROP TABLE Atom_SimpleItem;
                        ALTER TABLE Atom_SimpleItem_temp RENAME TO Atom_SimpleItem;

                        PRAGMA foreign_keys = ON;
                                ";

                if (!transaction_UpgradeDB_1_23_to_1_24.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_23_to_1_24.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_23_to_1_24:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_23_to_1_24))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.24", transaction_UpgradeDB_1_23_to_1_24))
                    {
                        if (transaction_UpgradeDB_1_23_to_1_24.Commit())
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
                        transaction_UpgradeDB_1_23_to_1_24.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_23_to_1_24.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_23_to_1_24.Rollback();
                return false;
            }
        }
    }
}
