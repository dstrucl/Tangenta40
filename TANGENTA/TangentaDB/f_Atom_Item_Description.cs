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
    public static class f_Atom_Item_Description
    {
        public static bool Get(string_v item_Description, ref ID atom_Item_Description_ID, ref string Err)
        {
            if (item_Description != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Description = "@par_Description";
                DBConnectionControl40.SQL_Parameter par_Description = new DBConnectionControl40.SQL_Parameter(spar_Description, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, item_Description.v);
                lpar.Add(par_Description);
                string sql_select_Atom_Item_Description_ID = @"select ID as Atom_Item_Description_ID from Atom_Item_Description where Description = " + spar_Description;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_Description_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        atom_Item_Description_ID = tf.set_ID(dt.Rows[0]["Atom_Item_Description_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_Description = @"insert into Atom_Item_Description (Description)values(" + spar_Description + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Description, lpar, ref atom_Item_Description_ID, ref Err, "Atom_Item_Description"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_Description:Get:"+ sql_Insert_Atom_Item_Description + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_Description:Get:" + sql_select_Atom_Item_Description_ID + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                atom_Item_Description_ID = null;
                return true;
            }
        }
    }
}
