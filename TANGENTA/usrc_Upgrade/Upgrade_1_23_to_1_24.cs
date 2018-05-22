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
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
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

                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_23_to_1_24:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
                if (DBSync.DBSync.Create_VIEWs())
                {
                    return UpgradeDB_inThread.Set_DataBase_Version("1.24");
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
