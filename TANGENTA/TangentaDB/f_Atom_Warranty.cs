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
    public static class f_Atom_Warranty
    {
        public static bool Get(short_v Warranty_WarrantyDurationType, int_v Warranty_WarrantyDuration, string_v Warranty_WarrantyConditions, ref ID Atom_Item_Atom_Warranty_ID, ref string Err)
        {
            string scond_WarrantyDurationType = null;
            string sv_WarrantyDurationType = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (Warranty_WarrantyDurationType != null)
            {
                string spar_WarrantyDurationType = "@par_WarrantyDurationType";
                DBConnectionControl40.SQL_Parameter par_WarrantyDurationType = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDurationType, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Smallint, false, Warranty_WarrantyDurationType.v);
                lpar.Add(par_WarrantyDurationType);
                scond_WarrantyDurationType = "(WarrantyDurationType = " + spar_WarrantyDurationType + ")";
                sv_WarrantyDurationType = spar_WarrantyDurationType;
            }
            else
            {
                scond_WarrantyDurationType = "(WarrantyDurationType is null)";
                sv_WarrantyDurationType = "null";
            }

            string scond_WarrantyDuration = null;
            string sv_WarrantyDuration = null;
            if (Warranty_WarrantyDuration != null)
            {
                string spar_WarrantyDuration = "@par_WarrantyDuration";
                DBConnectionControl40.SQL_Parameter par_WarrantyDuration = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDuration, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Warranty_WarrantyDuration.v);
                lpar.Add(par_WarrantyDuration);
                scond_WarrantyDuration = "(WarrantyDuration = " + spar_WarrantyDuration + ")";
                sv_WarrantyDuration = spar_WarrantyDuration;
            }
            else
            {
                scond_WarrantyDuration = "(WarrantyDuration is null)";
                sv_WarrantyDuration = "null";
            }

            string scond_WarrantyConditions = null;
            string sv_WarrantyConditions = null;
            if (Warranty_WarrantyConditions != null)
            {
                string spar_WarrantyConditions = "@par_WarrantyConditions";
                DBConnectionControl40.SQL_Parameter par_WarrantyConditions = new DBConnectionControl40.SQL_Parameter(spar_WarrantyConditions, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Warranty_WarrantyConditions.v);
                lpar.Add(par_WarrantyConditions);
                scond_WarrantyConditions = "(WarrantyConditions = " + spar_WarrantyConditions + ")";
                sv_WarrantyConditions = spar_WarrantyConditions;
            }
            else
            {
                scond_WarrantyConditions = "(WarrantyConditions is null)";
                sv_WarrantyConditions = "null";
            }


            string sql_select_Atom_Warranty_ID = @"select ID as Atom_Warranty_ID from Atom_Warranty where " + scond_WarrantyDurationType + " and " + scond_WarrantyDuration + " and " + scond_WarrantyConditions;

            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Warranty_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Item_Atom_Warranty_ID = tf.set_ID(dt.Rows[0]["Atom_Warranty_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Warranty = @"insert into Atom_Warranty (WarrantyDurationType, WarrantyDuration, WarrantyConditions)values(" + sv_WarrantyDurationType + "," + sv_WarrantyDuration + "," + sv_WarrantyConditions + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql_Insert_Atom_Warranty, lpar, ref Atom_Item_Atom_Warranty_ID, ref Err, "Atom_Warranty"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Warranty:Get:sql="+ sql_Insert_Atom_Warranty + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Warranty:Get:sql=" + sql_select_Atom_Warranty_ID + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
