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
    internal static class Upgrade_1_24_to_1_25
    {

        public static ID Atom_ElectronicDevice_ID = null;

        internal static object UpgradeDB_1_24_to_1_25(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_24_to_1_25  = new Transaction("UpgradeDB_1_24_to_1_25");
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person

                string sql = @"

                        PRAGMA foreign_keys = OFF;

                        CREATE TABLE Atom_ComputerName ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                         'Name' varchar(264) NOT NULL,
                                                         'Description' varchar(2000) NULL );

                        CREATE TABLE Atom_ComputerUserName ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                              'UserName' varchar(32) NOT NULL,
                                                              'Description' varchar(2000) NULL );

                        CREATE TABLE Atom_MAC_address ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        'MAC_address' varchar(32) NOT NULL,
                                                        'Description' varchar(2000) NULL );

                        CREATE TABLE Atom_IP_address ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        'IP_address' varchar(32) NOT NULL,
                                                        'Description' varchar(2000) NULL );

                        CREATE TABLE Atom_Computer_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                     Atom_ComputerName_ID INTEGER NOT NULL REFERENCES Atom_ComputerName(ID),
                                                     Atom_MAC_address_ID INTEGER NULL REFERENCES Atom_MAC_address(ID),
                                                     Atom_ComputerUserName_ID INTEGER NULL REFERENCES Atom_ComputerUserName(ID),
                                                     Atom_IP_address_ID INTEGER NULL REFERENCES Atom_IP_address(ID) );
                        
                        CREATE TABLE Atom_ElectronicDevice_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                 'Name' varchar(264) NOT NULL,
                                                                  Atom_Computer_ID INTEGER NOT NULL REFERENCES Atom_Computer(ID),
                                                                  Atom_Office_ID INTEGER NOT NULL REFERENCES Atom_Office(ID),
                                                                 'Description' varchar(2000) NULL );

                        CREATE TABLE Atom_WorkPeriod_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                            Atom_myOrganisation_Person_ID INTEGER NOT NULL REFERENCES Atom_myOrganisation_Person(ID),
                                                            Atom_ElectronicDevice_ID INTEGER NOT NULL REFERENCES Atom_ElectronicDevice(ID),
                                                            'LoginTime' DATETIME NULL,
                                                            'LogoutTime' DATETIME NULL,
                                                            Atom_WorkPeriod_TYPE_ID INTEGER NULL REFERENCES Atom_WorkPeriod_TYPE(ID) );

                         ";
                if (!transaction_UpgradeDB_1_24_to_1_25.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_24_to_1_25.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_24_to_1_25:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                if (!Import_From_Atom_WorkPeriod_To_Atom_WorkPeriod_Temp(transaction_UpgradeDB_1_24_to_1_25))
                {
                    return false;
                }

                sql = @"
                        DROP TABLE Atom_Computer;
                        ALTER TABLE Atom_Computer_Temp RENAME TO Atom_Computer;

                        DROP TABLE Atom_ElectronicDevice;
                        ALTER TABLE Atom_ElectronicDevice_Temp RENAME TO Atom_ElectronicDevice;

                        DROP TABLE Atom_WorkPeriod;
                        ALTER TABLE Atom_WorkPeriod_Temp RENAME TO Atom_WorkPeriod;

                        DROP TABLE WorkingPlace;

                        DROP TABLE Atom_WorkingPlace;



                        ";

                if (!transaction_UpgradeDB_1_24_to_1_25.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_24_to_1_25.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_24_to_1_25:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }



                string[] new_tables = new string[] {
                                        "CaseItem",
                                        "CaseImage",
                                        "CustomerCase",
                                        "CaseParameter",
                                        "SettingsType",
                                        "ProgramModule",
                                        "PropertiesSettings",
                                        "LoginTag_TYPE",
                                        "LoginTag",
                                        "WorkAreaImage",
                                        "WorkArea",
                                        "Atom_WorkArea",
                                        "Atom_WorkAreaImage",
                                        "ElectronicDevice",
                                        "DocInvoice_Atom_WorkArea",
                                        "myOrganisation_Person_SingleUser",
                                        "TermsOfPayment_Default",
                                        "LoginUsers_ParentGroup3",
                                        "LoginUsers_ParentGroup2",
                                        "LoginUsers_ParentGroup1",
                                        "JOURNAL_Atom_WorkPeriod_TYPE",
                                        "JOURNAL_Atom_WorkPeriod",
                                        "DocInvoice_ShopC_Item_AdditionalData",
                                        "WorkArea_ParentGroup3",
                                        "WorkArea_ParentGroup2",
                                        "WorkArea_ParentGroup1",
                                        "Current_DocInvoice_ID",
                                        "Current_DocProformaInvoice_ID",
                                        "DocInvoice_ShopC_Item_AdditionalData_TYPE"
                                    };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    return false;
                }

                sql = @"

                        CREATE TABLE LoginUsers_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                       myOrganisation_Person_ID INTEGER NOT NULL REFERENCES myOrganisation_Person(ID),
                                                       'Enabled' BIT NOT NULL,
                                                       'UserName' varchar(32) UNIQUE NOT NULL UNIQUE ,
                                                       'Password' BLOB NULL,
                                                       'PasswordNeverExpires' BIT NOT NULL,
                                                       'Time_When_AdministratorSetsPassword' DATETIME NULL,
                                                       'Time_When_UserSetsItsOwnPassword_FirstTime' DATETIME NULL,
                                                       'Time_When_UserSetsItsOwnPassword_LastTime' DATETIME NULL,
                                                       'Administrator_LoginUsers_ID' INTEGER NULL,
                                                       'ChangePasswordOnFirstLogin' BIT NOT NULL,
                                                       'Maximum_password_age_in_days' INT NULL,
                                                       'NotActiveAfterPasswordExpires' BIT NOT NULL,
                                                       LoginUsers_ParentGroup1_ID INTEGER NULL REFERENCES LoginUsers_ParentGroup1(ID) );

                        insert into LoginUsers_Temp ( ID,
                                                       myOrganisation_Person_ID,
                                                       Enabled,
                                                       UserName,
                                                       Password,
                                                       PasswordNeverExpires,
                                                       Time_When_AdministratorSetsPassword,
                                                       Time_When_UserSetsItsOwnPassword_FirstTime,
                                                       Time_When_UserSetsItsOwnPassword_LastTime,
                                                       Administrator_LoginUsers_ID,
                                                       ChangePasswordOnFirstLogin,
                                                       Maximum_password_age_in_days,
                                                       NotActiveAfterPasswordExpires,
                                                       LoginUsers_ParentGroup1_ID)
                                                        select
                                                        ID,
                                                       myOrganisation_Person_ID,
                                                       Enabled,
                                                       UserName,
                                                       Password,
                                                       PasswordNeverExpires,
                                                       Time_When_AdministratorSetsPassword,
                                                       Time_When_UserSetsItsOwnPassword_FirstTime,
                                                       Time_When_UserSetsItsOwnPassword_LastTime,
                                                       Administrator_LoginUsers_ID,
                                                       ChangePasswordOnFirstLogin,
                                                       Maximum_password_age_in_days,
                                                       NotActiveAfterPasswordExpires,
                                                        null
                                                        from LoginUsers;
                        DROP Table LoginUsers;

                        ALTER TABLE LoginUsers_Temp RENAME TO LoginUsers;

                        CREATE TABLE PersonData_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                       cGsmNumber_Person_ID INTEGER NULL REFERENCES cGsmNumber_Person(ID),
                                                       cPhoneNumber_Person_ID INTEGER NULL REFERENCES cPhoneNumber_Person(ID),
                                                       cEmail_Person_ID INTEGER NULL REFERENCES cEmail_Person(ID),
                                                       cAddress_Person_ID INTEGER NULL REFERENCES cAddress_Person(ID),
                                                      'CardNumber' varchar(50) NULL,
                                                       cCardType_Person_ID INTEGER NULL REFERENCES cCardType_Person(ID),
                                                       PersonImage_ID INTEGER NULL REFERENCES PersonImage(ID),
                                                      'Description' varchar(2000) NULL,
                                                       'PIN' INT NULL,
                                                       Person_ID INTEGER NOT NULL REFERENCES Person(ID) );

                        insert into PersonData_Temp ( ID,
                                                       cGsmNumber_Person_ID,
                                                       cPhoneNumber_Person_ID,
                                                       cEmail_Person_ID,
                                                       cAddress_Person_ID,
                                                       CardNumber,
                                                       cCardType_Person_ID,
                                                       PersonImage_ID,
                                                       Description,
                                                       PIN,
                                                       Person_ID) 
                                                        select
                                                       ID,
                                                       cGsmNumber_Person_ID,
                                                       cPhoneNumber_Person_ID,
                                                       cEmail_Person_ID,
                                                       cAddress_Person_ID,
                                                       CardNumber,
                                                       cCardType_Person_ID,
                                                       PersonImage_ID,
                                                       Description,
                                                       NULL,
                                                       Person_ID from PersonData;

                        DROP Table PersonData;

                        ALTER TABLE PersonData_Temp RENAME TO PersonData;

                        PRAGMA foreign_keys = ON;
                        ";

                if (!transaction_UpgradeDB_1_24_to_1_25.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_24_to_1_25:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                if (DBSync.DBSync.Create_VIEWs())
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.25", transaction_UpgradeDB_1_24_to_1_25))
                    {
                        if (!transaction_UpgradeDB_1_24_to_1_25.Commit())
                        {
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        transaction_UpgradeDB_1_24_to_1_25.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_24_to_1_25.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_24_to_1_25.Rollback();
                return false;
            }
        }

        private static bool Import_From_Atom_WorkPeriod_To_Atom_WorkPeriod_Temp(Transaction transaction)
        {
            string sql = @"select awp.ID as Atom_WorkPeriod_ID,
                                  ac.ID as Atom_Computer_ID,
                                  awp.Atom_myOrganisation_Person_ID as Atom_myOrganisation_Person_ID,
                                  amop.Atom_Office_ID as Atom_Office_ID,
                                  ac.Name as Atom_Computer_Name,
                                  ac.UserName as Atom_Computer_UserName,
                                  ac.IP_Address as Atom_Computer_IP_Address,
                                  ac.MAC_Address as Atom_Computer_MAC_Address,
                                  aed.Name as Atom_ElectronicDevice_Name,
                                  aed.Description as Atom_ElectronicDevice_Description,
                                  awp.LoginTime as LoginTime,
                                  awp.LogoutTime as LogoutTime,
                                  awpt.Name as Atom_WorkPeriod_TYPE_Name,
                                  awpt.Description as Atom_WorkPeriod_TYPE_Description
                                  from Atom_WorkPeriod awp
                                  INNER JOIN Atom_Computer ac ON ac.ID = awp.Atom_Computer_ID
                                  INNER JOIN Atom_ElectronicDevice aed ON aed.ID = awp.Atom_ElectronicDevice_ID
                                  INNER JOIN Atom_myOrganisation_Person amop ON amop.ID = awp.Atom_myOrganisation_Person_ID
                                  LEFT JOIN Atom_WorkPeriod_TYPE awpt on awpt.ID = awp.Atom_WorkPeriod_TYPE_ID
                                ";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                int iCount = dt.Rows.Count;
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ID xAtom_WorkPeriod_ID = tf.set_ID(dr["Atom_WorkPeriod_ID"]);
                    ID xOld_Atom_Computer_ID = tf.set_ID(dr["Atom_Computer_ID"]);
                    ID xAtom_myOrganisation_Person_ID = tf.set_ID(dr["Atom_myOrganisation_Person_ID"]);
                    ID xAtom_Office_ID = tf.set_ID(dr["Atom_Office_ID"]);
                    string_v sAtom_Computer_Name_v = tf.set_string(dr["Atom_Computer_Name"]);
                    string_v sAtom_Computer_UserName_v = tf.set_string(dr["Atom_Computer_UserName"]);
                    string_v sAtom_Computer_IP_Address_v = tf.set_string(dr["Atom_Computer_IP_Address"]);
                    string_v sAtom_Computer_MAC_Address_v = tf.set_string(dr["Atom_Computer_MAC_Address"]);
                    string_v sAtom_ElectronicDevice_Name_v = tf.set_string(dr["Atom_ElectronicDevice_Name"]);
                    string_v sAtom_ElectronicDevice_Description_v = tf.set_string(dr["Atom_ElectronicDevice_Description"]);
                    DateTime_v LoginTime_v = tf.set_DateTime(dr["LoginTime"]);
                    DateTime_v LogoutTime_v = tf.set_DateTime(dr["LogoutTime"]);
                    string_v sAtom_WorkPeriod_TYPE_Name_v = tf.set_string(dr["Atom_WorkPeriod_TYPE_Name"]);
                    string_v sAtom_WorkPeriod_TYPE_Description_v = tf.set_string(dr["Atom_WorkPeriod_TYPE_Description"]);

                    ID xAtom_Computer_ID = null;
                    if (Move_from_Atom_Computer_to_Atom_Computer_Temp(xOld_Atom_Computer_ID,
                                 sAtom_Computer_Name_v,
                                 sAtom_Computer_UserName_v,
                                 sAtom_Computer_IP_Address_v,
                                 sAtom_Computer_MAC_Address_v,
                                 ref xAtom_Computer_ID,
                                 transaction))
                    {

                        string sAtom_ElectronicDevice_Name = null;
                        if (sAtom_ElectronicDevice_Name_v != null)
                        {
                            sAtom_ElectronicDevice_Name = sAtom_ElectronicDevice_Name_v.v;
                        }


                        string sAtom_ElectronicDevice_Description = null;
                        if (sAtom_ElectronicDevice_Description_v != null)
                        {
                            sAtom_ElectronicDevice_Description = sAtom_ElectronicDevice_Description_v.v;
                        }

                     
                        if (!f_Atom_ElectronicDevice.Get_Temp(xAtom_Computer_ID,xAtom_Office_ID, sAtom_ElectronicDevice_Name, sAtom_ElectronicDevice_Description, ref Atom_ElectronicDevice_ID, transaction))
                        {
                            return false;
                        }

                        string sAtom_WorkPeriod_TYPE_Name = null;
                        if (sAtom_WorkPeriod_TYPE_Name_v != null)
                        {
                            sAtom_WorkPeriod_TYPE_Name = sAtom_WorkPeriod_TYPE_Name_v.v;
                        }


                        string sAtom_WorkPeriod_TYPE_Description = null;
                        if (sAtom_WorkPeriod_TYPE_Description_v != null)
                        {
                            sAtom_WorkPeriod_TYPE_Description = sAtom_WorkPeriod_TYPE_Description_v.v;
                        }

                        DateTime LoginTime = DateTime.MinValue;
                        if (LoginTime_v!=null)
                        {
                            LoginTime = LoginTime_v.v;
                        }

                        if (!f_Atom_WorkPeriod.Insert_into_Atom_WorkPeriod_Temp(xAtom_WorkPeriod_ID, sAtom_WorkPeriod_TYPE_Name, sAtom_WorkPeriod_TYPE_Description, xAtom_myOrganisation_Person_ID, Atom_ElectronicDevice_ID, LoginTime, LogoutTime_v, transaction))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    i++;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERRRO:UpgradeDB:Upgrade_1_24_to_125:Move_from_Atom_Computer_to_Atom_Computer_Temp:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool Move_from_Atom_Computer_to_Atom_Computer_Temp(
            ID old_Atom_Computer_ID,
            string_v Name_v,
            string_v UserName_v,
             string_v IP_address_v,
             string_v MAC_address_v,
            ref ID xAtom_Computer_ID,
            Transaction transaction)
        {
            string Err = null;
            string sql = null; 
            ID Atom_ComputerName_ID = null;
            ID Atom_ComputerUserName_ID = null;
            ID Atom_MAC_address_ID = null;
            ID Atom_IP_address_ID = null;

            string sval_Atom_ComputerName_ID = "null";
            if (Name_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string spar_ID = "@par_ID";
                SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, old_Atom_Computer_ID);
                lpar.Add(par_ID);
                string sval_ID = spar_ID;

                if (!f_Atom_ComputerName.Get(Name_v.v, ref Atom_ComputerName_ID, transaction))
                {
                    return false;
                }

                string scond_Atom_ComputerName_ID = "Atom_ComputerName_ID is null";
                if (ID.Validate(Atom_ComputerName_ID))
                {
                    string spar_Atom_ComputerName_ID = "@parAtom_ComputerName_ID";
                    SQL_Parameter par_Atom_ComputerName_ID = new SQL_Parameter(spar_Atom_ComputerName_ID, false, Atom_ComputerName_ID);
                    lpar.Add(par_Atom_ComputerName_ID);
                    scond_Atom_ComputerName_ID = "Atom_ComputerName_ID=" + spar_Atom_ComputerName_ID;
                    sval_Atom_ComputerName_ID = spar_Atom_ComputerName_ID;
                }
                else
                {
                    LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_24_to_1_25:Move_from_Atom_Computer_to_Atom_Computer_Temp:Atom_ComputerName_ID is not valid!");
                    return false;
                }

                if (!f_Atom_ComputerUsername.Get(UserName_v.v, ref Atom_ComputerUserName_ID, transaction))
                {
                    return false;
                }

                string scond_Atom_ComputerUserName_ID = "Atom_ComputerUserName_ID is null";
                string sval_Atom_ComputerUserName_ID = "null";

                if (ID.Validate(Atom_ComputerUserName_ID))
                {
                    string spar_Atom_ComputerUserName_ID = "@parAtom_ComputerUserName_ID";
                    SQL_Parameter par_Atom_ComputerUserName_ID = new SQL_Parameter(spar_Atom_ComputerUserName_ID, false, Atom_ComputerUserName_ID);
                    lpar.Add(par_Atom_ComputerUserName_ID);
                    scond_Atom_ComputerUserName_ID = "Atom_ComputerUserName_ID="+ spar_Atom_ComputerUserName_ID;
                    sval_Atom_ComputerUserName_ID = spar_Atom_ComputerUserName_ID;
                }


                if (IP_address_v == null)
                {
                    IP_address_v = new string_v(f_Atom_IP_address.Get());
                }
                if (!f_Atom_IP_address.Get(IP_address_v.v, ref Atom_IP_address_ID, transaction))
                {
                    return false;
                }


                string scond_Atom_IP_address_ID = "Atom_IP_address_ID is null";
                string sval_Atom_IP_address_ID = "null";

                if (ID.Validate(Atom_IP_address_ID))
                {
                    string spar_Atom_IP_address_ID = "@parAtom_IP_address_ID";
                    SQL_Parameter par_Atom_IP_address_ID = new SQL_Parameter(spar_Atom_IP_address_ID, false, Atom_IP_address_ID);
                    lpar.Add(par_Atom_IP_address_ID);
                    scond_Atom_IP_address_ID = "Atom_IP_address_ID="+ spar_Atom_IP_address_ID;
                    sval_Atom_IP_address_ID = spar_Atom_IP_address_ID;
                }

                if (MAC_address_v == null)
                {
                    MAC_address_v = new string_v(f_Atom_MAC_address.Get());
                }

                if (!f_Atom_MAC_address.Get(MAC_address_v.v, ref Atom_MAC_address_ID, transaction))
                {
                    return false;
                }


                string scond_Atom_MAC_address_ID = "Atom_MAC_address_ID is null";
                string sval_Atom_MAC_address_ID = "null";

                if (ID.Validate(Atom_MAC_address_ID))
                {
                    string spar_Atom_MAC_address_ID = "@parAtom_MAC_address_ID";
                    SQL_Parameter par_Atom_MAC_address_ID = new SQL_Parameter(spar_Atom_MAC_address_ID, false, Atom_MAC_address_ID);
                    lpar.Add(par_Atom_MAC_address_ID);
                    scond_Atom_MAC_address_ID = "Atom_MAC_address_ID="+ spar_Atom_MAC_address_ID;
                    sval_Atom_MAC_address_ID = spar_Atom_MAC_address_ID;
                }

                sql = @"Select ID from Atom_Computer_Temp where " + scond_Atom_ComputerName_ID
                                                          + " and " + scond_Atom_ComputerUserName_ID
                                                          + " and " + scond_Atom_MAC_address_ID
                                                          + " and " + scond_Atom_IP_address_ID;

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt,sql,lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        xAtom_Computer_ID = tf.set_ID(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_Computer_Temp (ID,
                                                        Atom_ComputerName_ID,
                                                        Atom_ComputerUserName_ID,
                                                        Atom_MAC_address_ID,
                                                        Atom_IP_address_ID)
                                                        values
                                                        (" + sval_ID +
                                                            "," + sval_Atom_ComputerName_ID +
                                                            "," + sval_Atom_ComputerUserName_ID +
                                                            "," + sval_Atom_MAC_address_ID +
                                                            "," + sval_Atom_IP_address_ID +
                                                            ")";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref xAtom_Computer_ID, ref Err, "Atom_Computer_Temp"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERRRO:UpgradeDB:Upgrade_1_24_to_125:Move_from_Atom_Computer_to_Atom_Computer_Temp:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERRRO:UpgradeDB:Upgrade_1_24_to_125:Move_from_Atom_Computer_to_Atom_Computer_Temp:sql=" + sql + "\r\nErr=" + Err);
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
