using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_16_to_1_17
    {
        internal static object UpgradeDB_1_16_to_1_17(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_16_to_1_17 = new Transaction("UpgradeDB_1_16_to_1_17");
            string sql = null;
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_16_to_1_17))
            {
                sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Person;
                        CREATE TABLE cCountry_Person
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"INSERT INTO cCountry_Person (Country,
						 Country_ISO_3166_a2,
						Country_ISO_3166_a3,
						Country_ISO_3166_num)
						SELECT 
						State,
						State_ISO_3166_a2,
						State_ISO_3166_a3,
						State_ISO_3166_num
						FROM cState_Person";
                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {

                        sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Org;
                        CREATE TABLE cCountry_Org
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            sql = @"INSERT INTO cCountry_Org (Country,
						             Country_ISO_3166_a2,
						            Country_ISO_3166_a3,
						            Country_ISO_3166_num)
						            SELECT 
						            State,
						            State_ISO_3166_a2,
						            State_ISO_3166_a3,
						            State_ISO_3166_num
						            FROM cState_Org";
                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                            {
                                sql = @"
                                PRAGMA foreign_keys = OFF;
                                DROP TABLE Atom_cCountry_Person;
                                CREATE TABLE Atom_cCountry_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                  'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                  'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                  'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                  )";

                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                {
                                    sql = @"INSERT INTO Atom_cCountry_Person (Country,
						                             Country_ISO_3166_a2,
						                            Country_ISO_3166_a3,
						                            Country_ISO_3166_num)
						                            SELECT 
						                            State,
						                            State_ISO_3166_a2,
						                            State_ISO_3166_a3,
						                            State_ISO_3166_num
						                            FROM Atom_cState_Person";
                                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                    {

                                        sql = @"
                                                    PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_cCountry_Org;
                                                    CREATE TABLE Atom_cCountry_Org
                                                      (
                                                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                                      )";

                                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                        {
                                            sql = @"INSERT INTO Atom_cCountry_Org (Country,
						                                    Country_ISO_3166_a2,
						                                    Country_ISO_3166_a3,
						                                    Country_ISO_3166_num)
						                                    SELECT 
						                                    State,
						                                    State_ISO_3166_a2,
						                                    State_ISO_3166_a3,
						                                    State_ISO_3166_num
						                                    FROM Atom_cState_Org";
                                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                            {
                                                sql = @"
                                                CREATE TABLE cAddress_Person_backup
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    cStreetName_Person_ID  INTEGER  NOT NULL REFERENCES cStreetName_Person(ID),
                                                    cHouseNumber_Person_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Person(ID),
                                                    cCity_Person_ID  INTEGER  NOT NULL REFERENCES cCity_Person(ID),
                                                    cZIP_Person_ID  INTEGER  NOT NULL REFERENCES cZIP_Person(ID),
                                                    cState_Person_ID  INTEGER  NULL REFERENCES cState_Person(ID),
                                                    cCountry_Person_ID  INTEGER NOT NULL REFERENCES cCountry_Person(ID)
                                                    )";
                                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                {
                                                    sql = @"INSERT INTO cAddress_Person_backup (
                                                        cStreetName_Person_ID,
						                                cHouseNumber_Person_ID,
						                                cCity_Person_ID,
						                                cZIP_Person_ID,
                                                        cState_Person_ID,
                                                        cCountry_Person_ID
                                                        )
						                                SELECT 
                                                        cStreetName_Person_ID,
						                                cHouseNumber_Person_ID,
						                                cCity_Person_ID,
						                                cZIP_Person_ID,
                                                        cCountry_Person_ID,
                                                        cState_Person_ID
						                                FROM cAddress_Person";
                                                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                    {
                                                        sql = @"PRAGMA foreign_keys = OFF;
                                                                DROP TABLE cAddress_Person;
                                                                ALTER TABLE cAddress_Person_backup RENAME TO cAddress_Person;";
                                                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                        {
                                                            sql = @"
                                                                CREATE TABLE cAddress_Org_backup
                                                                  (
                                                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                   cStreetName_Org_ID  INTEGER  NOT NULL REFERENCES cStreetName_Org(ID),
                                                                   cHouseNumber_Org_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Org(ID),
                                                                   cCity_Org_ID  INTEGER  NOT NULL REFERENCES cCity_Org(ID),
                                                                   cZIP_Org_ID  INTEGER  NOT NULL REFERENCES cZIP_Org(ID),
                                                                   cState_Org_ID  INTEGER  NULL REFERENCES cState_Org(ID),
                                                                   cCountry_Org_ID  INTEGER NOT NULL REFERENCES cCountry_Org(ID)
                                                                  )";
                                                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                            {
                                                                sql = @"INSERT INTO cAddress_Org_backup (
                                                                cStreetName_Org_ID,
						                                        cHouseNumber_Org_ID,
						                                        cCity_Org_ID,
						                                        cZIP_Org_ID,
                                                                cState_Org_ID,
                                                                cCountry_Org_ID
                                                                )
						                                        SELECT 
                                                                cStreetName_Org_ID,
						                                        cHouseNumber_Org_ID,
						                                        cCity_Org_ID,
						                                        cZIP_Org_ID,
                                                                cCountry_Org_ID,
                                                                cState_Org_ID
						                                        FROM cAddress_Org";
                                                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                {
                                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                                            DROP TABLE cAddress_Org;
                                                                            ALTER TABLE cAddress_Org_backup RENAME TO cAddress_Org;";
                                                                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                    {
                                                                        sql = @"
                                                                            CREATE TABLE Atom_cAddress_Person_backup
                                                                                (
                                                                                'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                Atom_cStreetName_Person_ID  INTEGER  NOT NULL REFERENCES cStreetName_Person(ID),
                                                                                Atom_cHouseNumber_Person_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Person(ID),
                                                                                Atom_cCity_Person_ID  INTEGER  NOT NULL REFERENCES cCity_Person(ID),
                                                                                Atom_cZIP_Person_ID  INTEGER  NOT NULL REFERENCES cZIP_Person(ID),
                                                                                Atom_cState_Person_ID  INTEGER  NULL REFERENCES cState_Person(ID),
                                                                                Atom_cCountry_Person_ID  INTEGER NOT NULL REFERENCES cCountry_Person(ID)
                                                                                )";
                                                                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                        {
                                                                            sql = @"INSERT INTO Atom_cAddress_Person_backup (
                                                                                    Atom_cStreetName_Person_ID,
						                                                            Atom_cHouseNumber_Person_ID,
						                                                            Atom_cCity_Person_ID,
						                                                            Atom_cZIP_Person_ID,
                                                                                    Atom_cState_Person_ID,
                                                                                    Atom_cCountry_Person_ID
                                                                                    )
						                                                            SELECT 
                                                                                    Atom_cStreetName_Person_ID,
						                                                            Atom_cHouseNumber_Person_ID,
						                                                            Atom_cCity_Person_ID,
						                                                            Atom_cZIP_Person_ID,
                                                                                    Atom_cCountry_Person_ID,
                                                                                    Atom_cState_Person_ID
						                                                            FROM Atom_cAddress_Person";
                                                                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                            {
                                                                                sql = @"PRAGMA foreign_keys = OFF;
                                                                                        DROP TABLE Atom_cAddress_Person;
                                                                                        ALTER TABLE Atom_cAddress_Person_backup RENAME TO Atom_cAddress_Person;";
                                                                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                {
                                                                                    sql = @"
                                                                                    CREATE TABLE Atom_cAddress_Org_backup
                                                                                      (
                                                                                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                       Atom_cStreetName_Org_ID  INTEGER  NOT NULL REFERENCES cStreetName_Org(ID),
                                                                                       Atom_cHouseNumber_Org_ID  INTEGER  NOT NULL REFERENCES cHouseNumber_Org(ID),
                                                                                       Atom_cCity_Org_ID  INTEGER  NOT NULL REFERENCES cCity_Org(ID),
                                                                                       Atom_cZIP_Org_ID  INTEGER  NOT NULL REFERENCES cZIP_Org(ID),
                                                                                       Atom_cState_Org_ID  INTEGER  NULL REFERENCES cState_Org(ID),
                                                                                       Atom_cCountry_Org_ID  INTEGER NOT NULL REFERENCES cCountry_Org(ID)
                                                                                      )";
                                                                                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                    {
                                                                                        sql = @"INSERT INTO Atom_cAddress_Org_backup (
                                                                                                Atom_cStreetName_Org_ID,
						                                                                        Atom_cHouseNumber_Org_ID,
						                                                                        Atom_cCity_Org_ID,
						                                                                        Atom_cZIP_Org_ID,
                                                                                                Atom_cState_Org_ID,
                                                                                                Atom_cCountry_Org_ID
                                                                                                )
						                                                                        SELECT 
                                                                                                Atom_cStreetName_Org_ID,
						                                                                        Atom_cHouseNumber_Org_ID,
						                                                                        Atom_cCity_Org_ID,
						                                                                        Atom_cZIP_Org_ID,
                                                                                                Atom_cCountry_Org_ID,
                                                                                                Atom_cState_Org_ID
						                                                                        FROM Atom_cAddress_Org";
                                                                                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                        {
                                                                                            sql = @"PRAGMA foreign_keys = OFF;
                                                                                                    DROP TABLE Atom_cAddress_Org;
                                                                                                    ALTER TABLE Atom_cAddress_Org_backup RENAME TO Atom_cAddress_Org;";
                                                                                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                            {

                                                                                                sql = @"PRAGMA foreign_keys = OFF;
                                                                                                        DROP TABLE cState_Person;
                                                                                                        CREATE TABLE cState_Person
                                                                                                          (
                                                                                                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                          'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                          )";

                                                                                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                {
                                                                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                                                                            DROP TABLE cState_Org;
                                                                                                            CREATE TABLE cState_Org
                                                                                                              (
                                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                              )";
                                                                                                    if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                    {
                                                                                                        sql = @"
                                                                                                        PRAGMA foreign_keys = OFF;
                                                                                                        DROP TABLE Atom_cState_Person;
                                                                                                        CREATE TABLE Atom_cState_Person
                                                                                                          (
                                                                                                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                          'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                          )";
                                                                                                        if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                        {
                                                                                                            sql = @"PRAGMA foreign_keys = OFF;
                                                                                                            DROP TABLE Atom_cState_Org;
                                                                                                            CREATE TABLE Atom_cState_Org
                                                                                                              (
                                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                              )";
                                                                                                            if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                            {
                                                                                                                sql = @"PRAGMA foreign_keys = ON;";
                                                                                                                if (transaction_UpgradeDB_1_16_to_1_17.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                                                                                                                {


                                                                                                                    if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_16_to_1_17))
                                                                                                                    {
                                                                                                                        if (UpgradeDB_inThread.Set_DataBase_Version("1.17", transaction_UpgradeDB_1_16_to_1_17))
                                                                                                                        {
                                                                                                                            if (transaction_UpgradeDB_1_16_to_1_17.Commit())
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
                                                                                                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                                            return false;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                                        return false;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                                    return false;
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                                return false;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                            return false;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                        return false;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                    return false;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                return false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                            return false;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                        return false;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                    return false;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                return false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            transaction_UpgradeDB_1_16_to_1_17.Rollback();
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        transaction_UpgradeDB_1_16_to_1_17.Rollback();
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_16_to_1_17.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_16_to_1_17.Rollback();
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
