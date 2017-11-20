using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_09_to_1_10
    {
        internal static object UpgradeDB_1_09_to_1_10(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "Atom_myOrganisation_Person";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                      CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');                    
                    PRAGMA foreign_keys = ON;";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    string[] new_tables = new string[] { "FVI_SLO_RealEstateBP", "FVI_SLO_Response", "Atom_FVI_SLO_RealEstateBP" };
                    if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                    {
                        if (DBSync.DBSync.Create_VIEWs())
                        {
                            UpgradeDB_inThread.Set_DataBase_Version("1.10");
                            return true;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }
    }
}
