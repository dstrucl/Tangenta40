using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_08_to_1_09
    {
        internal static object UpgradeDB_1_08_to_1_09(object obj, ref string Err)
        {
            string sql = null;
            string[] stables = new string[] { "Atom_cCountry_Org", "Atom_cCountry_Person", "cCountry_Org", "cCountry_Person" };
            foreach (string stbl in stables)
            {
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE " + stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into " + stbl + @" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    CREATE TABLE " + stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into " + stbl + @" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
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
            UpgradeDB_inThread.Set_DataBase_Version("1.09");
            return true;

        }
    }
}
