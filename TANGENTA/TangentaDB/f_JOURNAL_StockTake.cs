using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangentaDB;

namespace TangentaDB
{
    public static class f_JOURNAL_StockTake
    {
        public const string JOURNAL_StockTake_Type_TABLE = "JOURNAL_StockTake_Type";

        public const string New_StockTake_opened = "New StockTake opened";
        public const string Opened_StockTake_closed = "Opened StockTake closed";
        public const string Closed_StockTake_changed = "Closed StockTake changed";

        private static long m_JOURNAL_StockTake_Type_ID_New_StockTake_opened = -1;
        private static long m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed = -1;
        private static long m_JOURNAL_StockTake_Type_ID_Closed_StockTake_changed = -1;



        public static long JOURNAL_StockTake_Type_ID_New_StockTake_opened
        { get { return m_JOURNAL_StockTake_Type_ID_New_StockTake_opened; } }

        public static long JOURNAL_StockTake_Type_ID_Opened_StockTake_closed
        { get { return m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed; } }

        public static long JOURNAL_StockTake_Type_ID_Closed_StockTake_changed
        { get { return m_JOURNAL_StockTake_Type_ID_Closed_StockTake_changed; } }



        public static bool Get_JOURNAL_StockTake_Type_ID()
        {

            if (fs.Get_JOURNAL_TYPE(JOURNAL_StockTake_Type_TABLE, New_StockTake_opened, ref m_JOURNAL_StockTake_Type_ID_New_StockTake_opened))
            {
                if (fs.Get_JOURNAL_TYPE(JOURNAL_StockTake_Type_TABLE, Opened_StockTake_closed, ref m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed))
                {
                    if (fs.Get_JOURNAL_TYPE(JOURNAL_StockTake_Type_TABLE, Closed_StockTake_changed, ref m_JOURNAL_StockTake_Type_ID_Closed_StockTake_changed))
                    {
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool Get(long StockTake_id, long stocktake_type_id, DateTime dEventTime,  ref long_v JOURNAL_StockTake_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_JOURNAL_StockTake_Type_ID = "@par_JOURNAL_StockTake_Type_ID";
            SQL_Parameter par_JOURNAL_StockTake_Type_ID = new SQL_Parameter(spar_JOURNAL_StockTake_Type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, stocktake_type_id);
            lpar.Add(par_JOURNAL_StockTake_Type_ID);

            string spar_StockTake_ID = "@par_StockTake_ID";
            SQL_Parameter par_StockTake_ID = new SQL_Parameter(spar_StockTake_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, StockTake_id);
            lpar.Add(par_StockTake_ID);

            string spar_EventTime = "@par_EventTime";
            SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dEventTime);
            lpar.Add(par_EventTime);

            long Atom_WorkPeriod_id = GlobalData.Atom_WorkPeriod_ID;
            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkPeriod_id);
            lpar.Add(par_Atom_WorkPeriod_ID);

            string table_name = "JOURNAL_StockTake";
            string sql = "insert into " + table_name + " (JOURNAL_StockTake_Type_ID,StockTake_ID,EventTime,Atom_WorkPeriod_ID)values(" + spar_JOURNAL_StockTake_Type_ID + "," + spar_StockTake_ID + "," + spar_EventTime + "," + spar_Atom_WorkPeriod_ID + ")";
            long id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, table_name))
            {
                if (JOURNAL_StockTake_ID == null)
                {
                    JOURNAL_StockTake_ID = new long_v();
                }
                JOURNAL_StockTake_ID.v = id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_JOURNAL_StockTake:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
