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
    public static class f_Atom_Item_barcode
    {
        public static bool Get(string_v item_barcode, ref ID atom_Item_barcode_ID, ref string Err)
        {
            if (item_barcode != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_barcode = "@par_barcode";
                DBConnectionControl40.SQL_Parameter par_barcode = new DBConnectionControl40.SQL_Parameter(spar_barcode, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, item_barcode.v);
                lpar.Add(par_barcode);
                string sql_select_Atom_Item_barcode_ID = @"select ID as Atom_Item_barcode_ID from Atom_Item_barcode where barcode = " + spar_barcode;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_barcode_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        atom_Item_barcode_ID = tf.set_ID(dt.Rows[0]["Atom_Item_barcode_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_barcode = @"insert into Atom_Item_barcode (barcode)values(" + spar_barcode + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_barcode, lpar, ref atom_Item_barcode_ID, ref Err, "Atom_Item_barcode"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_barcode:Get:sql="+ sql_Insert_Atom_Item_barcode + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Item_barcode:Get:sql=" + sql_select_Atom_Item_barcode_ID + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                atom_Item_barcode_ID = null;
                return true;
            }

        }
    }
}
