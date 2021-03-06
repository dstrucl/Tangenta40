﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace TangentaDB
{
    public static class f_Item_ParentGroup2
    {
        public static bool Get(string Name_ParentGroup2, string Name_ParentGroup3, ref long Item_ParentGroup2_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            if (Name_ParentGroup3 != null)
            {
                long Item_ParentGroup3_ID = -1;

                if (f_Item_ParentGroup3.Get(Name_ParentGroup3, ref Item_ParentGroup3_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string spar_Name = "@par_Name";
                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup2);
                    lpar.Add(par_Name);
                    string sql = "select ID from Item_ParentGroup2 where Name = " + spar_Name + " and Item_ParentGroup3_ID = " + Item_ParentGroup3_ID.ToString();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Item_ParentGroup2_ID = (long)dt.Rows[0]["ID"];
                            return true;
                        }
                        else
                        {
                            sql = "insert into Item_ParentGroup2 (Name,Item_ParentGroup3_ID) values (" + spar_Name + "," + Item_ParentGroup3_ID.ToString() + ")";
                            object oret = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup2_ID, ref oret, ref Err, "Item_ParentGroup2"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Item_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
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
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_Name = "@par_Name";
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup2);
                lpar.Add(par_Name);
                string sql = "select ID from Item_ParentGroup2 where Name = " + spar_Name + " and Item_ParentGroup3_ID is null";
                if (dt.Rows.Count > 0)
                {
                    Item_ParentGroup2_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Item_ParentGroup2 (Name,Item_ParentGroup3_ID) values (" + spar_Name + ",null)";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup2_ID, ref oret, ref Err, "Item_ParentGroup2"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
        }


        internal static bool Get(long Item_ParentGroup2_ID, ref string_v item_ParentGroup2_v, ref long_v item_ParentGroup3_ID_v)
        {
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Item_ParentGroup2_ID);
            lpar.Add(par_ID);
            string sql = "select Name,Item_ParentGroup3_ID from Item_ParentGroup2 where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    item_ParentGroup2_v = tf.set_string(dt.Rows[0]["Name"]);
                    item_ParentGroup3_ID_v = tf.set_long(dt.Rows[0]["Item_ParentGroup3_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
