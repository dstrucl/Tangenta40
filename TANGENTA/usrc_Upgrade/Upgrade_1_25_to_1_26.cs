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
    internal static class Upgrade_1_25_to_1_26
    {
        internal static object UpgradeDB_1_25_to_1_26(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_25_to_1_26 = new Transaction("UpgradeDB_1_25_to_1_26");
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_25_to_1_26))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"
                    alter table PurchasePrice add column 'Discount' DECIMAL(18,5) NULL;
                    alter table PurchasePrice add column 'PriceWithoutVAT' BIT NULL;
                    alter table PurchasePrice add column 'VATCanNotBeDeducted' BIT NULL;
                         ";
                if (!transaction_UpgradeDB_1_25_to_1_26.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_25_to_1_26.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_25_to_1_26:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }


                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_25_to_1_26))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.26", transaction_UpgradeDB_1_25_to_1_26))
                    {
                        if (transaction_UpgradeDB_1_25_to_1_26.Commit())
                        {
                            return true;
                        }
                    }
                }
            }
            transaction_UpgradeDB_1_25_to_1_26.Rollback();
            return false;
        }
    }
}
