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
    public static class f_SimpleItem_ParentGroup1
    {
        public static bool Get(string Name_ParentGroup1, string Name_ParentGroup2, string Name_ParentGroup3, ref long SimpleItem_ParentGroup1_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            if (Name_ParentGroup2 != null)
            {
                long SimpleItem_ParentGroup2_ID = -1;

                if (f_SimpleItem_ParentGroup2.Get(Name_ParentGroup2, Name_ParentGroup3, ref SimpleItem_ParentGroup2_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string spar_Name = "@par_Name";
                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup1);
                    lpar.Add(par_Name);
                    string sql = "select ID from SimpleItem_ParentGroup1 where Name = " + spar_Name + " and SimpleItem_ParentGroup2_ID = " + SimpleItem_ParentGroup2_ID.ToString();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            SimpleItem_ParentGroup1_ID = (long)dt.Rows[0]["ID"];
                            return true;
                        }
                        else
                        {
                            sql = "insert into SimpleItem_ParentGroup1 (Name,SimpleItem_ParentGroup2_ID) values (" + spar_Name + "," + SimpleItem_ParentGroup2_ID.ToString() + ")";
                            object oret = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref SimpleItem_ParentGroup1_ID, ref oret, ref Err, "SimpleItem_ParentGroup1"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
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
                string sql = "select ID from SimpleItem_ParentGroup1 where Name = " + spar_Name + " and SimpleItem_ParentGroup2_ID is null";
                if (dt.Rows.Count > 0)
                {
                    SimpleItem_ParentGroup1_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into SimpleItem_ParentGroup1 (Name,SimpleItem_ParentGroup2_ID) values (" + spar_Name + ",null)";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref SimpleItem_ParentGroup1_ID, ref oret, ref Err, "SimpleItem_ParentGroup1"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
        }
        public static bool Get(long SimpleItem_ParentGroup1_ID, ref string_v Name_ParentGroup1_v, ref long_v SimpleItem_ParentGroup2_ID_v)
        {
            DataTable dt = new DataTable();
            string Err = null;
            Name_ParentGroup1_v = null;
            SimpleItem_ParentGroup2_ID_v = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, SimpleItem_ParentGroup1_ID);
            lpar.Add(par_ID);
            string sql = "select Name,SimpleItem_ParentGroup2_ID from SimpleItem_ParentGroup1 where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name_ParentGroup1_v = tf.set_string(dt.Rows[0]["Name"]);
                    SimpleItem_ParentGroup2_ID_v = tf.set_long(dt.Rows[0]["SimpleItem_ParentGroup2_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup1:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(long SimpleItem_ParentGroup1_ID, ref string_v Name_ParentGroup1_v, ref string_v Name_ParentGroup2_v, ref string_v Name_ParentGroup3_v)
        {
            DataTable dt = new DataTable();

            Name_ParentGroup1_v = null;
            Name_ParentGroup2_v = null;
            Name_ParentGroup3_v = null;
            long_v SimpleItem_ParentGroup2_ID_v = null;
            if (Get(SimpleItem_ParentGroup1_ID, ref Name_ParentGroup1_v, ref SimpleItem_ParentGroup2_ID_v))
            {
                if (SimpleItem_ParentGroup2_ID_v != null)
                {
                    long_v SimpleItem_ParentGroup3_ID_v = null;
                    if (f_SimpleItem_ParentGroup2.Get(SimpleItem_ParentGroup2_ID_v.v, ref Name_ParentGroup2_v, ref SimpleItem_ParentGroup3_ID_v))
                    {
                        if (SimpleItem_ParentGroup3_ID_v != null)
                        {
                            if (f_SimpleItem_ParentGroup3.Get(SimpleItem_ParentGroup3_ID_v.v, ref Name_ParentGroup3_v))
                            {
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
