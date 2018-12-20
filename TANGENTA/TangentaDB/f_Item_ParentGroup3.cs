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
    public static class f_Item_ParentGroup3
    {
        public static bool Get(string Name, ref ID Item_ParentGroup3_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string sql = "select ID from Item_ParentGroup3 where Name = " + spar_Name;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Item_ParentGroup3_ID==null)
                    {
                        Item_ParentGroup3_ID = new ID();
                    }
                    Item_ParentGroup3_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into Item_ParentGroup3 (Name) values (" + spar_Name + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Item_ParentGroup3_ID, ref Err, "Item_ParentGroup3"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_ParentGroup3:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item_ParentGroup3:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        internal static bool Get(ID item_ParentGroup3_ID, ref string_v item_ParentGroup3_v)
        {
            item_ParentGroup3_v = null;
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, item_ParentGroup3_ID);
            lpar.Add(par_ID);
            string sql = "select Name,from Item_ParentGroup3 where ID = " + spar_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    item_ParentGroup3_v = tf.set_string(dt.Rows[0]["Name"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item_ParentGroup3:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
