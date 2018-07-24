using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_JOURNAL_Atom_WorkPeriod
    {
        public static bool Get(ID JOURNAL_Atom_WorkPeriod_TYPE_ID, ID Atom_WorkPeriod_id, DateTime dEventTime, ref ID JOURNAL_Atom_WorkPeriod_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_JOURNAL_Atom_WorkPeriod_TYPE_ID = "@par_Atom_WorkPeriod_TYPE_ID";
            SQL_Parameter par_JOURNAL_Atom_WorkPeriod_TYPE_ID = new SQL_Parameter(spar_JOURNAL_Atom_WorkPeriod_TYPE_ID, false, JOURNAL_Atom_WorkPeriod_TYPE_ID);
            lpar.Add(par_JOURNAL_Atom_WorkPeriod_TYPE_ID);

            string spar_EventTime = "@par_EventTime";
            SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dEventTime);
            lpar.Add(par_EventTime);

            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, Atom_WorkPeriod_id);
            lpar.Add(par_Atom_WorkPeriod_ID);

            string table_name = "JOURNAL_Atom_WorkPeriod";
            string sql = "insert into " + table_name + " (JOURNAL_Atom_WorkPeriod_TYPE_ID,EventTime,Atom_WorkPeriod_ID)values(" + spar_JOURNAL_Atom_WorkPeriod_TYPE_ID + "," + spar_EventTime +"," + spar_Atom_WorkPeriod_ID + ")";
            string Err = null;

            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref JOURNAL_Atom_WorkPeriod_ID, ref Err, table_name))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_JOURNAL_Atom_WorkPeriod:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
