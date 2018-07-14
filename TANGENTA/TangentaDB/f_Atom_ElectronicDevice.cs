#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_ElectronicDevice
    {

        public static bool Get(ref string xElectronicDevice_Name, ref string xElectronicDevice_Description,ref ID Atom_ElectronicDevice_ID)
        {
            string Err = null;

            ID.SetInvalid(ref Atom_ElectronicDevice_ID);
            xElectronicDevice_Name = null;
            xElectronicDevice_Description = null;


            ID xAtom_ElectronicDevice_ID = null;
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


                string sql = @"select ID,Name,Description from Atom_ElectronicDevice
                                                        where (" + scond_Atom_Computer_ID + ")";

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        xAtom_ElectronicDevice_ID = new ID(dt.Rows[0]["ID"]);
                        xElectronicDevice_Name_v = tf.set_string(dt.Rows[0]["Name"]);
                        xElectronicDevice_Description_v = tf.set_string(dt.Rows[0]["Description"]);
                        if (ID.Validate(xAtom_ElectronicDevice_ID))
                        {
                            Atom_ElectronicDevice_ID = xAtom_ElectronicDevice_ID;
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
                    LogFile.Error.Show("ERROR:f_Atom_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Get(string ElectronicDevice_Name, string ElectronicDevice_Description, ref ID Atom_ElectronicDevice_ID)
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
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID,  false, GlobalData.Atom_Computer_ID);
                    lpar.Add(par_Atom_Computer_ID);
                    scond_Atom_Computer_ID = "Atom_Computer_ID = " + spar_Atom_Computer_ID;
                    sval_Atom_Computer_ID = spar_Atom_Computer_ID;
                }
                else
                {
                    scond_Atom_Computer_ID = "Atom_Computer_ID is null";
                    sval_Atom_Computer_ID = "null";
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


                string sql = @"select ID,Description from Atom_ElectronicDevice
                                                        where (" + scond_ElectronicDevice_Name + " and " + scond_Atom_Computer_ID + ")";

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_ElectronicDevice_ID==null)
                        {
                            Atom_ElectronicDevice_ID = new ID();
                        }
                        Atom_ElectronicDevice_ID.Set(dt.Rows[0]["ID"]);
                        object Current_ElectronicDevice_Description = dt.Rows[0]["Description"];
                        if ((ElectronicDevice_Description == null) && (Current_ElectronicDevice_Description is System.DBNull))
                        {
                            return true;
                        }
                        sql = null;
                        if ((ElectronicDevice_Description == null) && (Current_ElectronicDevice_Description is string))
                        {
                            sql = @"Update Atom_ElectronicDevice set Description = null where ID = " + Atom_ElectronicDevice_ID.ToString();
                        }
                        else if ((ElectronicDevice_Description != null) && (Current_ElectronicDevice_Description is string))
                        {
                            if (ElectronicDevice_Description.Equals((string)Current_ElectronicDevice_Description))
                            {
                                sql = @"Update Atom_ElectronicDevice set Description = " + sval_ElectronicDevice_Description + " where ID = " + Atom_ElectronicDevice_ID.ToString();
                            }
                        }
                        if (sql != null)
                        {
                            object ores = null;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                            {
                                LogFile.Error.Show("ERROR:f_Atom_ElectronicDevice:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_ElectronicDevice (Name,Description,Atom_Computer_ID) values (" + sval_ElectronicDevice_Name + "," + sval_ElectronicDevice_Description + "," + sval_Atom_Computer_ID + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_ElectronicDevice_ID, ref Err, "Atom_ElectronicDevice"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_ElectronicDevice:Get:" + sql + "\r\nErr=" + Err);
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
