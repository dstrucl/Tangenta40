using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_17_to_1_18
    {
        internal static object UpgradeDB_1_17_to_1_18(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_17_to_1_18 = new Transaction("UpgradeDB_1_17_to_1_18");
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                //Repair StudioMarjetka DataBase
                if (DBSync.DBSync.DataBase.Contains("StudioMarjetka"))
                {

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office_Data set Atom_myOrganisation_Person_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Organisation set Registration_ID = '3802809000'";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                    sql = "Update Atom_OrganisationData set Atom_Organisation_ID = 1 , Atom_Logo_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_WorkPeriod set Atom_myOrganisation_Person_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_myOrganisation_Person set Atom_Person_ID = 1,Atom_Office_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "delete from Atom_myOrganisation_Person where ID > 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Office set myOrganisation_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Office where ID = 2";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Update Atom_Office set Atom_myOrganisation_ID = 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = "Delete from Atom_myOrganisation_Person where ID > 1";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }


                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_myOrganisation_Person where ID in (2,3)";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                            Delete from Atom_Office where ID = 2";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_myOrganisation where ID = 2";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                           Delete from Atom_OrganisationData where ID = 2";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                    sql = @"PRAGMA foreign_keys = OFF;
                            Delete from Atom_Organisation where ID = 2";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                string stbl = "Office_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Office_backup";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                stbl = "Atom_Office_backup";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = "DROP TABLE Atom_Office_backup";
                    if (!transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                sql = @"
                    CREATE TABLE Office_backup
                    (
                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                    myOrganisation_ID  INTEGER  NOT NULL REFERENCES myOrganisation(ID),
                    'Name' varchar(264) UNIQUE NOT NULL, 
                    'ShortName' varchar(10) UNIQUE  NOT NULL
                    )";
                if (transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"
                            insert into Office_backup
                            (
                             myOrganisation_ID,
                            Name, 
                            ShortName
                            )
                            select
                            myOrganisation_ID,
                            Name,
                            'KUNAVE6'
                            from office
                            ";

                    if (transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        sql = @"
                            CREATE TABLE Atom_Office_backup
                            (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                             Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                            'Name' varchar(264) UNIQUE NOT NULL, 
                            'ShortName' varchar(10) UNIQUE  NOT NULL
                            )";
                        if (transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            sql = @"
                                insert into Atom_Office_backup
                                (
                                Atom_myOrganisation_ID,
                                Name, 
                                ShortName
                                )
                                select
                                Atom_myOrganisation_ID,
                                Name,
                                'KUNAVE6'
                                from Atom_office
                                ";
                            if (transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                            {

                                sql = @"PRAGMA foreign_keys = OFF;
                                    DROP TABLE Office;
                                    DROP TABLE Atom_Office;
                                    ALTER TABLE Office_backup RENAME TO Office;
                                    ALTER TABLE Atom_Office_backup RENAME TO Atom_Office; 
                                    PRAGMA foreign_keys = ON; ";
                                if (transaction_UpgradeDB_1_17_to_1_18.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                {
                                    if (DBSync.DBSync.Create_VIEWs())
                                    {
                                        if (UpgradeDB_inThread.Set_DataBase_Version("1.18", transaction_UpgradeDB_1_17_to_1_18))
                                        {
                                            transaction_UpgradeDB_1_17_to_1_18.Commit();
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        transaction_UpgradeDB_1_17_to_1_18.Rollback();
                                        return false;
                                    }
                                }
                                else
                                {
                                    transaction_UpgradeDB_1_17_to_1_18.Rollback();
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                transaction_UpgradeDB_1_17_to_1_18.Rollback();
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            transaction_UpgradeDB_1_17_to_1_18.Rollback();
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        transaction_UpgradeDB_1_17_to_1_18.Rollback();
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_17_to_1_18.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_17_to_1_18:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_17_to_1_18.Rollback();
                return false;
            }
        }

    }
}
