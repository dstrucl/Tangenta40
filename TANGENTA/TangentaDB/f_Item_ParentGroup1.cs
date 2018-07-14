using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace TangentaDB
{
    public static class f_Item_ParentGroup1
    {
        public static bool Get(string Name_ParentGroup1, string Name_ParentGroup2, string Name_ParentGroup3, ref ID Item_ParentGroup1_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            if (Name_ParentGroup2 != null)
            {
                ID Item_ParentGroup2_ID = null;

                if (f_Item_ParentGroup2.Get(Name_ParentGroup2, Name_ParentGroup3, ref Item_ParentGroup2_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string spar_Name = "@par_Name";
                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup1);
                    lpar.Add(par_Name);
                    string sql = "select ID from Item_ParentGroup1 where Name = " + spar_Name + " and Item_ParentGroup2_ID = " + Item_ParentGroup2_ID.ToString();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (Item_ParentGroup1_ID==null)
                            {
                                Item_ParentGroup1_ID = new ID();
                            }
                            Item_ParentGroup1_ID.Set(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            sql = "insert into Item_ParentGroup1 (Name,Item_ParentGroup2_ID) values (" + spar_Name + "," + Item_ParentGroup2_ID.ToString() + ")";
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup1_ID, ref Err, "Item_ParentGroup1"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Item_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
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
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup1);
                lpar.Add(par_Name);
                string sql = "select ID from Item_ParentGroup1 where Name = " + spar_Name + " and Item_ParentGroup2_ID is null";
                if (dt.Rows.Count > 0)
                {
                    if (Item_ParentGroup1_ID==null)
                    {
                        Item_ParentGroup1_ID = new ID();
                    }
                    Item_ParentGroup1_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into Item_ParentGroup1 (Name,Item_ParentGroup2_ID) values (" + spar_Name + ",null)";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup1_ID, ref Err, "Item_ParentGroup1"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
        }


        internal static bool Get(ID item_ParentGroup1_ID, ref string_v item_ParentGroup1_v, ref ID item_ParentGroup2_ID, ref string_v item_ParentGroup2_v, ref ID item_ParentGroup3_ID, ref string_v item_ParentGroup3_v)
        {
            DataTable dt = new DataTable();
            item_ParentGroup2_ID = null;
            item_ParentGroup3_ID = null;
            item_ParentGroup1_v = null;
            item_ParentGroup2_v = null;
            item_ParentGroup3_v = null;
            if (Get(item_ParentGroup1_ID, ref item_ParentGroup1_v, ref item_ParentGroup2_ID))
            {
                if (item_ParentGroup2_ID != null)
                {
                    if (f_Item_ParentGroup2.Get(item_ParentGroup2_ID.v, ref item_ParentGroup2_v, ref item_ParentGroup3_ID))
                    {
                        if (item_ParentGroup3_ID != null)
                        {
                            if (!f_Item_ParentGroup3.Get(item_ParentGroup3_ID.v, ref item_ParentGroup3_v))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool Get(ID item_ParentGroup1_ID, ref string_v item_ParentGroup1_v, ref ID item_ParentGroup2_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            item_ParentGroup1_v = null;
            item_ParentGroup2_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, item_ParentGroup1_ID);
            lpar.Add(par_ID);
            string sql = "select Name,Item_ParentGroup2_ID from Item_ParentGroup1 where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    item_ParentGroup1_v = tf.set_string(dt.Rows[0]["Name"]);
                    if (item_ParentGroup2_ID==null)
                    {
                        item_ParentGroup2_ID = new ID();
                    }
                    item_ParentGroup2_ID.Set(dt.Rows[0]["Item_ParentGroup2_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
