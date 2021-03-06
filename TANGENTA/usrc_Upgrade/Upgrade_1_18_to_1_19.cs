﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_18_to_1_19
    {
        internal static object UpgradeDB_1_18_to_1_19(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                //Repair StudioMarjetka DataBase
                string stbl = "Office_Data_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Office_Data_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                stbl = "Atom_Office_Data_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Atom_Office_Data_backup";
                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                sql = @"
                        CREATE TABLE Office_Data_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Office_ID  INTEGER  NOT NULL REFERENCES Office(ID),
                           cAddress_Org_ID  INTEGER  NULL REFERENCES cAddress_Org(ID),
                          'Description' varchar(2000) NULL

                          )";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"
                            insert into Office_Data_backup
                            (
                             Office_ID,
                             cAddress_Org_ID, 
                             Description
                            )
                            select
                            1,
                            cAddress_Org_ID,
                            Description
                            from office_data where ID = 1;
                            ";

                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = @"
                            CREATE TABLE Atom_Office_Data_backup
                              (
                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                               Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                               Atom_cAddress_Org_ID  INTEGER  NULL REFERENCES Atom_cAddress_Org(ID),
                              'Description' varchar(2000) NULL
                              )";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = "update Atom_Office_Data set Atom_Office_ID = 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "update Atom_FVI_SLO_RealEstateBP set Atom_Office_Data_ID = 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "delete from Atom_FVI_SLO_RealEstateBP  where ID > 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = "delete from Atom_Office_Data where ID > 1";
                            if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                            sql = @"
                                insert into Atom_Office_Data_backup
                                (
                                Atom_Office_ID,
                                Atom_cAddress_Org_ID, 
                                Description
                                )
                                select
                                Atom_Office_ID,
                                Atom_cAddress_Org_ID,
                                Description
                                from Atom_Office_Data
                                ";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {

                                sql = @"PRAGMA foreign_keys = OFF;
                                    DROP TABLE Office_Data;
                                    DROP TABLE Atom_Office_Data;
                                    ALTER TABLE Office_Data_backup RENAME TO Office_Data;
                                    ALTER TABLE Atom_Office_Data_backup RENAME TO Atom_Office_Data; 
                                    PRAGMA foreign_keys = ON; ";
                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    if (DBSync.DBSync.Create_VIEWs())
                                    {
                                        UpgradeDB_inThread.Set_DataBase_Version("1.19");
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_18_to_1_19:sql=" + sql + "\r\nErr=" + Err);
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
