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
    public static class f_CashierActivityOpened
    {
        public static bool Get(ID Atom_WorkPeriod_ID, ref ID xCashierActivityOpened_ID)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Atom_WorkPeriod_ID = null;
            string sval_Atom_WorkPeriod_ID = "null";
            if (ID.Validate(Atom_WorkPeriod_ID))
            {
                string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
                SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID,  false, Atom_WorkPeriod_ID);
                lpar.Add(par_Atom_WorkPeriod_ID);
                scond_Atom_WorkPeriod_ID = "Atom_WorkPeriod_ID = " + spar_Atom_WorkPeriod_ID;
                sval_Atom_WorkPeriod_ID = spar_Atom_WorkPeriod_ID;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivityOpened:Get:Atom_WorkPeriod_ID is not valid");
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from CashierActivityOpened where " + scond_Atom_WorkPeriod_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xCashierActivityOpened_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into CashierActivityOpened (Atom_WorkPeriod_ID) values (" + sval_Atom_WorkPeriod_ID + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref xCashierActivityOpened_ID, ref Err, "CashierActivityOpened"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_CashierActivityOpened:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivityOpened:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
