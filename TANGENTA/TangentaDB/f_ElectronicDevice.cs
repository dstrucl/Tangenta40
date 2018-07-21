using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_ElectronicDevice
    {
        public static bool Get(ref string xElectronicDevice_Name, ref string xElectronicDevice_Description, ref ID ElectronicDevice_ID)
        {
            string Err = null;

            xElectronicDevice_Name = null;
            xElectronicDevice_Description = null;


            ID xElectronicDevice_ID = null;
            string_v xElectronicDevice_Name_v = null;
            string_v xElectronicDevice_Description_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (f_Atom_Computer.Get(ref GlobalData.Atom_Computer_ID))
            {
                string scond_Atom_Computer_ID = null;
                string sval_Atom_Computer_ID = "null";
                if (ID.Validate(GlobalData.Atom_Computer_ID))
                {
                    string spar_Atom_Computer_ID = "@par_Atom_Computer_ID";
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID, false, GlobalData.Atom_Computer_ID);
                    lpar.Add(par_Atom_Computer_ID);
                    scond_Atom_Computer_ID = "Atom_Computer_ID = " + spar_Atom_Computer_ID;
                    sval_Atom_Computer_ID = spar_Atom_Computer_ID;
                }
                else
                {
                    scond_Atom_Computer_ID = "Atom_Computer_ID is null";
                    sval_Atom_Computer_ID = "null";
                }


                string sql = @"select ID,Name,Description from ElectronicDevice
                                                        where (" + scond_Atom_Computer_ID + ")";

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        xElectronicDevice_ID = new ID(dt.Rows[0]["ID"]);
                        xElectronicDevice_Name_v = tf.set_string(dt.Rows[0]["Name"]);
                        xElectronicDevice_Description_v = tf.set_string(dt.Rows[0]["Description"]);
                        if (ID.Validate(xElectronicDevice_ID))
                        {
                            ElectronicDevice_ID = xElectronicDevice_ID;
                        }

                        if (xElectronicDevice_Name_v != null)
                        {
                            xElectronicDevice_Name = xElectronicDevice_Name_v.v;
                        }

                        if (xElectronicDevice_Description_v != null)
                        {
                            xElectronicDevice_Description = xElectronicDevice_Description_v.v;
                        }
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal static bool Get(ID atom_ElectronicDevice_ID,
                                ref string electronicDevice_Name,
                                ref string electronicDevice_Description,
                                ref string computerName,
                                ref string computerName_Description,
                                ref string computerUserName,
                                ref string computerUserName_Description,
                                ref string mAC_address,
                                ref string mAC_address_Description,
                                ref string iP_address,
                                ref string iP_address_Description)
        {

            electronicDevice_Name = null;
            electronicDevice_Description = null;
            computerName = null;
            computerName_Description = null;
            computerUserName = null;
            computerUserName_Description = null;
            mAC_address = null;
            mAC_address_Description = null;
            iP_address = null;
            iP_address_Description = null;

            string sql = @"SELECT ElectronicDevice.ID,
                             ElectronicDevice.Name AS ElectronicDevice_$$Name,
                             ElectronicDevice.Description AS ElectronicDevice_$$Description,
                             ElectronicDevice_$_acomp_$_acn.Name AS ElectronicDevice_$_acomp_$_acn_$$Name,
                             ElectronicDevice_$_acomp_$_acn.Description AS ElectronicDevice_$_acomp_$_acn_$$Description,
                             ElectronicDevice_$_acomp_$_amac.MAC_address AS ElectronicDevice_$_acomp_$_amac_$$MAC_address,
                             ElectronicDevice_$_acomp_$_amac.Description AS ElectronicDevice_$_acomp_$_amac_$$Description,
                             ElectronicDevice_$_acomp_$_acun.UserName AS ElectronicDevice_$_acomp_$_acun_$$UserName,
                             ElectronicDevice_$_acomp_$_acun.Description AS ElectronicDevice_$_acomp_$_acun_$$Description,
                             ElectronicDevice_$_acomp_$_aipa.IP_address AS ElectronicDevice_$_acomp_$_aipa_$$IP_address,
                             ElectronicDevice_$_acomp_$_aipa.Description AS ElectronicDevice_$_acomp_$_aipa_$$Description,
                             ElectronicDevice_$_office.ID AS ElectronicDevice_$_office_$$ID,
                             ElectronicDevice_$_office.Name AS ElectronicDevice_$_office_$$Name,
                             ElectronicDevice_$_office.ShortName AS ElectronicDevice_$_office_$$ShortName
                            FROM ElectronicDevice 
                            LEFT JOIN Atom_Computer ElectronicDevice_$_acomp ON ElectronicDevice.Atom_Computer_ID = ElectronicDevice_$_acomp.ID 
                            LEFT JOIN Atom_ComputerName ElectronicDevice_$_acomp_$_acn ON ElectronicDevice_$_acomp.Atom_ComputerName_ID = ElectronicDevice_$_acomp_$_acn.ID 
                            LEFT JOIN Atom_MAC_address ElectronicDevice_$_acomp_$_amac ON ElectronicDevice_$_acomp.Atom_MAC_address_ID = ElectronicDevice_$_acomp_$_amac.ID 
                            LEFT JOIN Atom_ComputerUserName ElectronicDevice_$_acomp_$_acun ON ElectronicDevice_$_acomp.Atom_ComputerUserName_ID = ElectronicDevice_$_acomp_$_acun.ID 
                            LEFT JOIN Atom_IP_address ElectronicDevice_$_acomp_$_aipa ON ElectronicDevice_$_acomp.Atom_IP_address_ID = ElectronicDevice_$_acomp_$_aipa.ID 
                            LEFT JOIN Office ElectronicDevice_$_office ON ElectronicDevice.Office_ID = ElectronicDevice_$_office.ID  where ElectronicDevice.ID = " + atom_ElectronicDevice_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    electronicDevice_Name = tf._set_string(dr["ElectronicDevice_$$Name"]);
                    electronicDevice_Description = tf._set_string(dr["ElectronicDevice_$$Description"]);
                    computerName = tf._set_string(dr["ElectronicDevice_$_acomp_$_acn_$$Name"]);
                    computerName_Description = tf._set_string(dr["ElectronicDevice_$_acomp_$_acn_$$Description"]);
                    computerUserName = tf._set_string(dr["ElectronicDevice_$_acomp_$_acun_$$UserName"]);
                    computerUserName_Description = tf._set_string(dr["ElectronicDevice_$_acomp_$_acun_$$Description"]);
                    mAC_address = tf._set_string(dr["ElectronicDevice_$_acomp_$_amac_$$MAC_address"]);
                    mAC_address_Description = tf._set_string(dr["ElectronicDevice_$_acomp_$_amac_$$Description"]);
                    iP_address = tf._set_string(dr["ElectronicDevice_$_acomp_$_aipa_$$IP_address"]);
                    iP_address_Description = tf._set_string(dr["ElectronicDevice_$_acomp_$_aipa_$$Description"]);
                    return true;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_ElectronicDevice:Get(..):sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(ID Office_ID, ref DataTable tElectronicDevice)
        {
            if (ID.Validate(Office_ID))
            {
                string sql = @"SELECT 
                             ElectronicDevice.Name AS ElectronicDevice_$$Name,
                             ElectronicDevice_$_acomp_$_acn.Name AS ElectronicDevice_$_acomp_$_acn_$$Name,
                             ElectronicDevice_$_acomp_$_acun.UserName AS ElectronicDevice_$_acomp_$_acun_$$UserName,
                             ElectronicDevice_$_acomp_$_amac.MAC_address AS ElectronicDevice_$_acomp_$_amac_$$MAC_address,
                             ElectronicDevice_$_acomp_$_aipa.IP_address AS ElectronicDevice_$_acomp_$_aipa_$$IP_address,
                             ElectronicDevice_$_office.Name AS ElectronicDevice_$_office_$$Name,
                             ElectronicDevice_$_office.ShortName AS ElectronicDevice_$_office_$$ShortName,
                             ElectronicDevice.Description AS ElectronicDevice_$$Description,
                             ElectronicDevice_$_acomp_$_acn.Description AS ElectronicDevice_$_acomp_$_acn_$$Description,
                             ElectronicDevice_$_acomp_$_amac.Description AS ElectronicDevice_$_acomp_$_amac_$$Description,
                             ElectronicDevice_$_acomp_$_acun.Description AS ElectronicDevice_$_acomp_$_acun_$$Description,
                             ElectronicDevice_$_acomp_$_aipa.Description AS ElectronicDevice_$_acomp_$_aipa_$$Description,
                             ElectronicDevice_$_office.ID AS ElectronicDevice_$_office_$$ID,
                             ElectronicDevice.ID
                            FROM ElectronicDevice 
                            LEFT JOIN Atom_Computer ElectronicDevice_$_acomp ON ElectronicDevice.Atom_Computer_ID = ElectronicDevice_$_acomp.ID 
                            LEFT JOIN Atom_ComputerName ElectronicDevice_$_acomp_$_acn ON ElectronicDevice_$_acomp.Atom_ComputerName_ID = ElectronicDevice_$_acomp_$_acn.ID 
                            LEFT JOIN Atom_MAC_address ElectronicDevice_$_acomp_$_amac ON ElectronicDevice_$_acomp.Atom_MAC_address_ID = ElectronicDevice_$_acomp_$_amac.ID 
                            LEFT JOIN Atom_ComputerUserName ElectronicDevice_$_acomp_$_acun ON ElectronicDevice_$_acomp.Atom_ComputerUserName_ID = ElectronicDevice_$_acomp_$_acun.ID 
                            LEFT JOIN Atom_IP_address ElectronicDevice_$_acomp_$_aipa ON ElectronicDevice_$_acomp.Atom_IP_address_ID = ElectronicDevice_$_acomp_$_aipa.ID 
                            LEFT JOIN Office ElectronicDevice_$_office ON ElectronicDevice.Office_ID = ElectronicDevice_$_office.ID where ElectronicDevice_$_office.ID = " + Office_ID.ToString();
                if (tElectronicDevice == null)
                {
                    tElectronicDevice = new DataTable();
                }
                else
                {
                    tElectronicDevice.Columns.Clear();
                }
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref tElectronicDevice, sql, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_ElectronicDevice:Get(..):sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_ElectronicDevice:Get(..): Office_ID is not valid");
                return false;
            }
        }

        public static bool Get(ID Office_ID, ref ID ElectronicDevice_ID)
        {
            ElectronicDevice_ID = null;
            if (ID.Validate(Office_ID))
            {
                ID Atom_Computer_ID = null;
                if (f_Atom_Computer.Get(ref Atom_Computer_ID))
                {
                    string sql = @"SELECT 
                                 ElectronicDevice.ID as ElectronicDevice_ID
                                FROM ElectronicDevice 
                                LEFT JOIN Atom_Computer ElectronicDevice_$_acomp ON ElectronicDevice.Atom_Computer_ID = ElectronicDevice_$_acomp.ID 
                                LEFT JOIN Atom_ComputerName ElectronicDevice_$_acomp_$_acn ON ElectronicDevice_$_acomp.Atom_ComputerName_ID = ElectronicDevice_$_acomp_$_acn.ID 
                                LEFT JOIN Atom_MAC_address ElectronicDevice_$_acomp_$_amac ON ElectronicDevice_$_acomp.Atom_MAC_address_ID = ElectronicDevice_$_acomp_$_amac.ID 
                                LEFT JOIN Atom_ComputerUserName ElectronicDevice_$_acomp_$_acun ON ElectronicDevice_$_acomp.Atom_ComputerUserName_ID = ElectronicDevice_$_acomp_$_acun.ID 
                                LEFT JOIN Atom_IP_address ElectronicDevice_$_acomp_$_aipa ON ElectronicDevice_$_acomp.Atom_IP_address_ID = ElectronicDevice_$_acomp_$_aipa.ID 
                                LEFT JOIN Office ElectronicDevice_$_office ON ElectronicDevice.Office_ID = ElectronicDevice_$_office.ID where ElectronicDevice_$_office.ID = " + Office_ID.ToString()
                                + " and Atom_Computer_ID = " + Atom_Computer_ID.ToString();

                    DataTable dt = new DataTable();
                    string Err = null;
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ElectronicDevice_ID = tf.set_ID(dt.Rows[0]["ElectronicDevice_ID"]);
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_ElectronicDevice:Get(..):sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_ElectronicDevice:Get(..): Office_ID is not valid");
                return false;
            }
        }

        public static bool Get(ID xOffice_ID, string ElectronicDevice_Name, string ElectronicDevice_Description, ref ID ElectronicDevice_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (f_Atom_Computer.Get(ref GlobalData.Atom_Computer_ID))
            {
                string scond_Atom_Computer_ID = null;
                string sval_Atom_Computer_ID = "null";
                if (ID.Validate(GlobalData.Atom_Computer_ID))
                {
                    string spar_Atom_Computer_ID = "@par_Atom_Computer_ID";
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID, false, GlobalData.Atom_Computer_ID);
                    lpar.Add(par_Atom_Computer_ID);
                    scond_Atom_Computer_ID = "Atom_Computer_ID = " + spar_Atom_Computer_ID;
                    sval_Atom_Computer_ID = spar_Atom_Computer_ID;
                }
                else
                {
                    scond_Atom_Computer_ID = "Atom_Computer_ID is null";
                    sval_Atom_Computer_ID = "null";
                }

                string scond_Office_ID = null;
                string sval_Office_ID = "null";
                if (ID.Validate(xOffice_ID))
                {
                    string spar_Office_ID = "@par_Office_ID";
                    SQL_Parameter par_Office_ID = new SQL_Parameter(spar_Office_ID, false, xOffice_ID);
                    lpar.Add(par_Office_ID);
                    scond_Office_ID = "Office_ID = " + spar_Office_ID;
                    sval_Office_ID = spar_Office_ID;
                }
                else
                {
                    scond_Office_ID = "Office_ID is null";
                    sval_Office_ID = "null";
                }


                string scond_ElectronicDevice_Name = null;
                string sval_ElectronicDevice_Name = "null";
                if (ElectronicDevice_Name != null)
                {
                    string spar_ElectronicDevice_Name = "@par_ElectronicDevice_Name";
                    SQL_Parameter par_ElectronicDevice_Name = new SQL_Parameter(spar_ElectronicDevice_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ElectronicDevice_Name);
                    lpar.Add(par_ElectronicDevice_Name);
                    scond_ElectronicDevice_Name = "Name = " + spar_ElectronicDevice_Name;
                    sval_ElectronicDevice_Name = spar_ElectronicDevice_Name;
                }
                else
                {
                    scond_ElectronicDevice_Name = "Name is null";
                    sval_ElectronicDevice_Name = "null";
                }

                string scond_ElectronicDevice_Description = null;
                string sval_ElectronicDevice_Description = "null";
                if (ElectronicDevice_Description != null)
                {
                    string spar_ElectronicDevice_Description = "@par_ElectronicDevice_Description";
                    SQL_Parameter par_ElectronicDevice_Description = new SQL_Parameter(spar_ElectronicDevice_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ElectronicDevice_Description);
                    lpar.Add(par_ElectronicDevice_Description);
                    scond_ElectronicDevice_Description = "Description = " + spar_ElectronicDevice_Description;
                    sval_ElectronicDevice_Description = spar_ElectronicDevice_Description;
                }
                else
                {
                    scond_ElectronicDevice_Description = "Description is null";
                    sval_ElectronicDevice_Description = "null";
                }


                string sql = @"select ID,Description from ElectronicDevice
                                                        where (" + scond_Office_ID + " and " + scond_ElectronicDevice_Name + " and " + scond_Atom_Computer_ID + ")";

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (ElectronicDevice_ID == null)
                        {
                            ElectronicDevice_ID = new ID();
                        }
                        ElectronicDevice_ID.Set(dt.Rows[0]["ID"]);
                        object Current_ElectronicDevice_Description = dt.Rows[0]["Description"];
                        if ((ElectronicDevice_Description == null) && (Current_ElectronicDevice_Description is System.DBNull))
                        {
                            return true;
                        }
                        sql = null;
                        if ((ElectronicDevice_Description == null) && (Current_ElectronicDevice_Description is string))
                        {
                            sql = @"Update ElectronicDevice set Description = null where ID = " + ElectronicDevice_ID.ToString();
                        }
                        else if ((ElectronicDevice_Description != null) && (Current_ElectronicDevice_Description is string))
                        {
                            if (ElectronicDevice_Description.Equals((string)Current_ElectronicDevice_Description))
                            {
                                sql = @"Update ElectronicDevice set Description = " + sval_ElectronicDevice_Description + " where ID = " + ElectronicDevice_ID.ToString();
                            }
                        }
                        if (sql != null)
                        {
                            object ores = null;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                            {
                                LogFile.Error.Show("ERROR:f_ElectronicDevice:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        sql = @"insert into ElectronicDevice (Name,Description,Office_ID,Atom_Computer_ID) values (" + sval_ElectronicDevice_Name + "," + sval_ElectronicDevice_Description + "," + sval_Office_ID + "," + sval_Atom_Computer_ID + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ElectronicDevice_ID, ref Err, "ElectronicDevice"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
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
