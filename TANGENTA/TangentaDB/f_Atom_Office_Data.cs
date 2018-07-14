#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_Office_Data
    {
        public static bool Get(
                                 ID Office_Data_ID,
                                 ref ID Atom_Office_Data_ID)
        {

            ID cAddress_Org_ID = null;
            ID Office_ID = null;
            string Description = null;
            string sql = @"select 
                            od.Office_ID,
                            od.cAddress_Org_ID,
                            od.Description
                            from Office_Data od
                            where od.ID = " + Office_Data_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_Office_ID = dt.Rows[0]["Office_ID"];
                    if (o_Office_ID is long)
                    {
                        if (Office_ID == null)
                        {
                            Office_ID = new ID();
                        }
                        Office_ID.Set(o_Office_ID);
                        
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:Office_ID is null!");
                        return false;
                    }

                    object o_cAddress_Org_ID = dt.Rows[0]["cAddress_Org_ID"];
                    if (o_cAddress_Org_ID is long)
                    {
                        if (cAddress_Org_ID==null)
                        {
                            cAddress_Org_ID = new ID();
                        }
                        cAddress_Org_ID.Set(o_cAddress_Org_ID);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:cAddress_Org_ID is null!");
                        return false;
                    }


                    object o_Description = dt.Rows[0]["Description"];
                    if (o_Description is string)
                    {
                        Description = (string)o_Description;
                    }

                    ID Atom_cAddress_Org_ID = null;
                    ID Atom_Office_ID = null;

                    if (f_Atom_Office.Get(Office_ID, ref Atom_Office_ID))
                    {
                        if (f_Atom_cAddress_Org.Get(cAddress_Org_ID, ref Atom_cAddress_Org_ID))
                        {
                            DBTypes.string_v Office_Name = new DBTypes.string_v();
                            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                            string scond_Description = null;
                            string sval_Description = "null";
                            if (Description != null)
                            {
                                string spar_Description = "@par_Description";
                                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                                lpar.Add(par_Description);
                                scond_Description = "Description = " + spar_Description;
                                sval_Description = spar_Description;
                            }
                            else
                            {
                                scond_Description = "Description is null";
                                sval_Description = "null";
                            }


                            sql = @"select
                                    ID
                                    from Atom_Office_Data
                                    where  Atom_Office_ID = " + Atom_Office_ID.ToString() + @" and 
                                            Atom_cAddress_Org_ID = " + Atom_cAddress_Org_ID.ToString() + @" and
                                            " + scond_Description;
                            dt.Clear();
                            dt.Columns.Clear();
                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    if (Atom_Office_Data_ID==null)
                                    {
                                        Atom_Office_Data_ID = new ID();
                                    }
                                    Atom_Office_Data_ID.Set(dt.Rows[0]["ID"]);
                                    return true;
                                }
                                else
                                {
                                    sql = @"insert into Atom_Office_Data (Atom_Office_ID,Atom_cAddress_Org_ID,Description) values (" + Atom_Office_ID.ToString() + "," + Atom_cAddress_Org_ID.ToString() + "," + sval_Description + ")";
                                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Office_Data_ID, ref Err, "Atom_Office_Data"))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                                    }
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:sql=" + sql + "\r\nErr=" + Err);
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:No Office_Data data link for Office_Data_ID =" + Office_Data_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Office_Data:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
