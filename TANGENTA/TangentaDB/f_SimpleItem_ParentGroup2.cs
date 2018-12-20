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
    public static class f_SimpleItem_ParentGroup2
    {
        public static bool Get(string Name_ParentGroup2, string Name_ParentGroup3, ref ID SimpleItem_ParentGroup2_ID)

        {
            DataTable dt = new DataTable();
            string Err = null;
            if (Name_ParentGroup3 != null)
            {

                ID SimpleItem_ParentGroup3_ID = null;

                if (f_SimpleItem_ParentGroup3.Get(Name_ParentGroup3, ref SimpleItem_ParentGroup3_ID))
                {

                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_Name = "@par_Name";

                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name_ParentGroup2);

                    lpar.Add(par_Name);

                    string sql = "select ID from SimpleItem_ParentGroup2 where Name = " + spar_Name + " and SimpleItem_ParentGroup3_ID = " + SimpleItem_ParentGroup3_ID.ToString();

                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (SimpleItem_ParentGroup2_ID==null)
                            {
                                SimpleItem_ParentGroup2_ID = new ID();
                            }
                            SimpleItem_ParentGroup2_ID.Set(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            sql = "insert into SimpleItem_ParentGroup2 (Name,SimpleItem_ParentGroup3_ID) values (" + spar_Name + "," + SimpleItem_ParentGroup3_ID.ToString() + ")";

                            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref SimpleItem_ParentGroup2_ID, ref Err, "SimpleItem_ParentGroup2"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
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

                string sql = "select ID from SimpleItem_ParentGroup2 where Name = " + spar_Name + " and SimpleItem_ParentGroup3_ID is null";

                if (dt.Rows.Count > 0)
                {
                    if (SimpleItem_ParentGroup2_ID==null)
                    {
                        SimpleItem_ParentGroup2_ID = new ID();
                    }
                    SimpleItem_ParentGroup2_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into SimpleItem_ParentGroup2 (Name,SimpleItem_ParentGroup3_ID) values (" + spar_Name + ",null)";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref SimpleItem_ParentGroup2_ID, ref Err, "SimpleItem_ParentGroup2"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
        }

        internal static bool Get(ID simpleItem_ParentGroup2_ID, ref string_v name_ParentGroup2_v, ref ID simpleItem_ParentGroup3_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, simpleItem_ParentGroup2_ID);
            lpar.Add(par_ID);
            string sql = "select Name,SimpleItem_ParentGroup3_ID from SimpleItem_ParentGroup2 where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    name_ParentGroup2_v = tf.set_string(dt.Rows[0]["Name"]);
                    if (simpleItem_ParentGroup3_ID==null)
                    {
                        simpleItem_ParentGroup3_ID = new ID();
                    }
                    simpleItem_ParentGroup3_ID.Set(dt.Rows[0]["SimpleItem_ParentGroup3_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup2:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
