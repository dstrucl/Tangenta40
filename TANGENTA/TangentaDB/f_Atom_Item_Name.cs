using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Atom_Item_Name
    {
        public static bool Get(string_v Item_Name, ref ID Atom_Item_Name_ID)
        {
            string Err = null;
            if (Item_Name != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Name = "@par_Name";
                DBConnectionControl40.SQL_Parameter par_Name = new DBConnectionControl40.SQL_Parameter(spar_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Item_Name.v);
                lpar.Add(par_Name);
                string sql = @"select ID as Atom_Item_Name_ID from Atom_Item_Name where Name = " + spar_Name;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Item_Name_ID==null)
                        {
                            Atom_Item_Name_ID = new ID();
                        }
                        Atom_Item_Name_ID.Set(dt.Rows[0]["Atom_Item_Name_ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_Item_Name (Name)values(" + spar_Name + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Item_Name_ID,  ref Err, "Atom_Item_Name"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_Name:Get:\r\n" + sql + "!\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_Name:Get:\r\n" + sql + "!\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_Name:Get:Item_Name is not defined!");
                return false;
            }
        }
    }
}
