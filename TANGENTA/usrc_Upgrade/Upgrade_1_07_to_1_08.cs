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
            if (UpgradeDB_1_07_to_1_08_Change_Table_Person())
            {
                if (UpgradeDB_1_07_to_1_08_Change_Table_Organisation())
                {
                    if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person())
                    {
                        if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation())
                        {
                            if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office())
                            {
                                UpgradeDB_inThread.Set_DataBase_Version("1.08");
                                return true;
                            }
                        }
                    }

                }
            }
            return false;
        }

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Person()
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
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Person_backup SELECT * FROM Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Person;
                            ALTER TABLE Person_backup RENAME TO Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person()
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
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Person_backup SELECT * FROM Atom_Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Person;
                            ALTER TABLE Atom_Person_backup RENAME TO Atom_Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Organisation()
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
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Organisation_backup SELECT * FROM Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Organisation;
                            ALTER TABLE Organisation_backup RENAME TO Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation()
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
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Organisation_backup SELECT * FROM Atom_Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Organisation;
                            ALTER TABLE Atom_Organisation_backup RENAME TO Atom_Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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

        private static bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Office_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Atom_myOrganisation_ID  INTEGER  NOT NULL REFERENCES Atom_myOrganisation(ID),
                          'Name' varchar(264) NOT NULL 
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Office_backup SELECT * FROM Atom_Office";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Office;
                            ALTER TABLE Atom_Office_backup RENAME TO Atom_Office;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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
