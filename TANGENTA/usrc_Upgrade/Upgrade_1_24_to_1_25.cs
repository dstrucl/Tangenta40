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
                        
                        PRAGMA foreign_keys = ON;
                                ";
                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_23_to_1_24:sql=" + sql + "\r\nErr=" + Err);
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
                        string_v Name_v = tf.set_string(dr["Name"]);
                        string_v UserName_v = tf.set_string(dr["UserName"]);
                        string_v IP_address_v = tf.set_string(dr["IP_address"]);
                        string_v MAC_address_v = tf.set_string(dr["MAC_address"]);

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
