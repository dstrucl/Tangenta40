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
        public static ID Atom_ElectronicDevice_ID = null;

        internal static object UpgradeDB_1_25_to_1_25(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"
                    alter table PurchasePrice add column 'Discount' DECIMAL(18,5) NULL;
                    alter table PurchasePrice add column 'PriceWithoutVAT' BIT NULL;
                    alter table PurchasePrice add column 'VATCanNotBeDeducted' BIT NULL;
                         ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_25_to_1_26:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                if (DBSync.DBSync.Create_VIEWs())
                {
                    return UpgradeDB_inThread.Set_DataBase_Version("1.26");
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
    }
}
