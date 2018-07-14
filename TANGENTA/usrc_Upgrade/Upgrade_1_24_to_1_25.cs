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


        internal static object UpgradeDB_1_24_to_1_25(object obj, ref string Err)
        {
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
                                                        'Description' varchar(2000) NULL )

                        CREATE TABLE Atom_Computer_Temp( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                      Atom_ComputerName_ID INTEGER NOT NULL REFERENCES Atom_ComputerName(ID),
                                                      Atom_MAC_address_ID INTEGER NULL REFERENCES Atom_MAC_address(ID),
                                                      Atom_ComputerUserName_ID INTEGER NULL REFERENCES Atom_ComputerUserName(ID),
                                                      Atom_IP_address_ID INTEGER NULL REFERENCES Atom_IP_address(ID) )
                        
                        CREATE TABLE Atom_ElectronicDevice_Temp ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                  'Name' varchar(264) NOT NULL,
                                                                  Atom_MAC_address_ID INTEGER NULL REFERENCES Atom_MAC_address(ID), 
                                                                  Atom_ComputerName_ID INTEGER NULL REFERENCES Atom_ComputerName(ID),
                                                                  Atom_ComputerUserName_ID INTEGER NULL REFERENCES Atom_ComputerUserName(ID), 
                                                                  FVI_SLO_RealEstateBP_ID INTEGER NULL REFERENCES FVI_SLO_RealEstateBP(ID),
                                                                  'Description' varchar(2000) NULL )

                        PRAGMA foreign_keys = ON;
                                ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_23_to_1_24:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                string[] new_tables = new string[] {
                                                        "CaseItem",
                                                        "CaseImage",
                                                        "CustomerCase",
                                                        "CaseParameter",
                                                        "SettingsType",
                                                        "SettingsValue",
                                                        "ProgramModule",
                                                        "PropertiesSettings",
                                                        "LoginTag_TYPE",
                                                        "LoginTag",
                                                        "WorkAreaImage",
                                                        "WorkArea",
                                                        "WorkAreaDocInvoice"
                                                };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    return false;
                }

                if (!Move_from_Atom_Computer_to_Atom_Computer_Temp())
                {
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

        private static bool Move_from_Atom_Computer_to_Atom_Computer_Temp()
        {
            string Err = null;
            string sql = "select ID,Name,UserName,IP_address,MAC_address from Atom_Computer";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        long_v id_v = tf.set_long(dr["ID"]);
                        if (id_v != null)
                        {
                            if (ID.IsValid(id_v.v))
                            {
                                string_v Name_v = tf.set_string(dr["Name"]);
                                string_v UserName_v = tf.set_string(dr["UserName"]);
                                string_v IP_address_v = tf.set_string(dr["IP_address"]);
                                string_v MAC_address_v = tf.set_string(dr["MAC_address"]);
                                long Atom_ComputerName_ID = -1;
                                long Atom_ComputerUserName_ID = -1;
                                long Atom_MAC_address_ID = -1;
                                long Atom_IP_address_ID = -1;

                                string sval_Atom_ComputerName_ID = "null";
                                if (Name_v != null)
                                {
                                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                    string spar_ID = "@par_ID";
                                    SQL_Parameter par_ID = new SQL_Parameter(spar_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, id_v.v);
                                    lpar.Add(par_ID);
                                    string sval_ID = spar_ID;

                                    if (!f_Atom_ComputerName.Get(Name_v.v, ref Atom_ComputerName_ID))
                                    {
                                        return false;
                                    }

                                    if (ID.IsValid(Atom_ComputerName_ID))
                                    {
                                        string spar_Atom_ComputerName_ID = "@parAtom_ComputerName_ID";
                                        SQL_Parameter par_Atom_ComputerName_ID = new SQL_Parameter(spar_Atom_ComputerName_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ComputerName_ID);
                                        lpar.Add(par_Atom_ComputerName_ID);
                                        sval_Atom_ComputerName_ID = spar_Atom_ComputerName_ID;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_24_to_1_25:Move_from_Atom_Computer_to_Atom_Computer_Temp:Atom_ComputerName_ID is not valid!");
                                        return false;
                                    }

                                    if (!f_Atom_ComputerUsername.Get(UserName_v.v, ref Atom_ComputerUserName_ID))
                                    {
                                        return false;
                                    }

                                    string sval_Atom_ComputerUserName_ID = "null";

                                    if (ID.IsValid(Atom_ComputerUserName_ID))
                                    {
                                        string spar_Atom_ComputerUserName_ID = "@parAtom_ComputerUserName_ID";
                                        SQL_Parameter par_Atom_ComputerUserName_ID = new SQL_Parameter(spar_Atom_ComputerUserName_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ComputerUserName_ID);
                                        lpar.Add(par_Atom_ComputerUserName_ID);
                                        sval_Atom_ComputerUserName_ID = spar_Atom_ComputerUserName_ID;
                                    }

                                    if (!f_Atom_MAC_address.Get(UserName_v.v, ref Atom_MAC_address_ID))
                                    {
                                        return false;
                                    }

                                    string sval_Atom_MAC_address_ID = "null";

                                    if (ID.IsValid(Atom_MAC_address_ID))
                                    {
                                        string spar_Atom_MAC_address_ID = "@parAtom_MAC_address_ID";
                                        SQL_Parameter par_Atom_MAC_address_ID = new SQL_Parameter(spar_Atom_MAC_address_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_MAC_address_ID);
                                        lpar.Add(par_Atom_MAC_address_ID);
                                        sval_Atom_MAC_address_ID = spar_Atom_MAC_address_ID;
                                    }

                                    if (!f_Atom_IP_address.Get(UserName_v.v, ref Atom_IP_address_ID))
                                    {
                                        return false;
                                    }

                                    string sval_Atom_IP_address_ID = "null";

                                    if (ID.IsValid(Atom_IP_address_ID))
                                    {
                                        string spar_Atom_IP_address_ID = "@parAtom_IP_address_ID";
                                        SQL_Parameter par_Atom_IP_address_ID = new SQL_Parameter(spar_Atom_IP_address_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_IP_address_ID);
                                        lpar.Add(par_Atom_IP_address_ID);
                                        sval_Atom_IP_address_ID = spar_Atom_IP_address_ID;
                                    }

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
                                    object oret = null;
                                    long Atom_Computer_ID = -1;
                                    if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Computer_ID, ref oret, ref Err, "Atom_Computer_Temp"))
                                    {
                                        return false;
                                    }
        
                                }
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_24_to_1_25:Move_from_Atom_Computer_to_Atom_Computer_Temp:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }
    }
}
