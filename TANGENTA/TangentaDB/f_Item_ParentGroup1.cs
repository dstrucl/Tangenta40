using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Item_ParentGroup1
    {
        public static bool Get(string Name_ParentGroup1, string Name_ParentGroup2, string Name_ParentGroup3, ref long Item_ParentGroup1_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            if (Name_ParentGroup2 != null)
            {
                long Item_ParentGroup2_ID = -1;

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
                            Item_ParentGroup1_ID = (long)dt.Rows[0]["ID"];
                            return true;
                        }
                        else
                        {
                            sql = "insert into Item_ParentGroup1 (Name,Item_ParentGroup2_ID) values (" + spar_Name + "," + Item_ParentGroup2_ID.ToString() + ")";
                            object oret = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup2_ID, ref oret, ref Err, "Item_ParentGroup1"))
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
                    Item_ParentGroup1_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Item_ParentGroup1 (Name,Item_ParentGroup2_ID) values (" + spar_Name + ",null)";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_ParentGroup1_ID, ref oret, ref Err, "Item_ParentGroup1"))
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
    }
}
