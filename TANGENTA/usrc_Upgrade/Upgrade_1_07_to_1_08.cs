using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_07_to_1_08
    {
        internal static object UpgradeDB_1_07_to_1_08(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_07_to_1_08 = new Transaction("UpgradeDB_1_07_to_1_08");
            if (UpgradeDB_1_07_to_1_08_Change_Table_Person(transaction_UpgradeDB_1_07_to_1_08))
            {
                if (UpgradeDB_1_07_to_1_08_Change_Table_Organisation(transaction_UpgradeDB_1_07_to_1_08))
                {
                    if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person(transaction_UpgradeDB_1_07_to_1_08))
                    {
                        if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation(transaction_UpgradeDB_1_07_to_1_08))
                        {
                            if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office(transaction_UpgradeDB_1_07_to_1_08))
                            {
                                if (UpgradeDB_inThread.Set_DataBase_Version("1.08", transaction_UpgradeDB_1_07_to_1_08))
                                {
                                    if (transaction_UpgradeDB_1_07_to_1_08.Commit())
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }

                            }
                        }
                    }

                }
            }
            transaction_UpgradeDB_1_07_to_1_08.Rollback();
            return false;
        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Person(Transaction transaction)
        {
            string Err = null;
            string sql = @"CREATE TABLE Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           cFirstName_ID  INTEGER  NOT NULL REFERENCES cFirstName(ID),
                           cLastName_ID  INTEGER  NULL REFERENCES cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID' varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL
                          )
            ";
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = @"INSERT INTO Person_backup SELECT * FROM Person";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Person;
                            ALTER TABLE Person_backup RENAME TO Person;
                            PRAGMA foreign_keys = ON;";
                    if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person(Transaction transaction)
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           Atom_cFirstName_ID  INTEGER  NOT NULL REFERENCES Atom_cFirstName(ID),
                           Atom_cLastName_ID  INTEGER  NULL REFERENCES Atom_cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID'  varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL,
                           Atom_cGsmNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cGsmNumber_Person(ID),
                           Atom_cPhoneNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cPhoneNumber_Person(ID),
                           Atom_cEmail_Person_ID  INTEGER  NULL REFERENCES Atom_cEmail_Person(ID),
                           Atom_cAddress_Person_ID  INTEGER  NULL REFERENCES Atom_cAddress_Person(ID),
                          'CardNumber' varchar(50) NULL,
                           Atom_cCardType_Person_ID  INTEGER  NULL REFERENCES Atom_cCardType_Person(ID),
                           Atom_PersonImage_ID  INTEGER  NULL REFERENCES Atom_PersonImage(ID)
                          )
            ";
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Person_backup SELECT * FROM Atom_Person";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Person;
                            ALTER TABLE Atom_Person_backup RENAME TO Atom_Person;
                            PRAGMA foreign_keys = ON;";
                    if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Organisation(Transaction transaction)
        {
            string Err = null;
            string sql = @"CREATE TABLE Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = @"INSERT INTO Organisation_backup SELECT * FROM Organisation";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Organisation;
                            ALTER TABLE Organisation_backup RENAME TO Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation(Transaction transaction)
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Organisation_backup SELECT * FROM Atom_Organisation";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Organisation;
                            ALTER TABLE Atom_Organisation_backup RENAME TO Atom_Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office(Transaction transaction)
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Office_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                          'Name' varchar(264) NOT NULL 
                          )
            ";
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Office_backup SELECT * FROM Atom_Office";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Office;
                            ALTER TABLE Atom_Office_backup RENAME TO Atom_Office;
                            PRAGMA foreign_keys = ON;";
                    if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
