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

        private static ID m_JOURNAL_StockTake_Type_ID_New_StockTake_opened = null;
        private static ID m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed = null;
        private static ID m_JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened = null;



        public static ID JOURNAL_StockTake_Type_ID_New_StockTake_opened
        { get { return m_JOURNAL_StockTake_Type_ID_New_StockTake_opened; } }

        public static ID JOURNAL_StockTake_Type_ID_Opened_StockTake_closed
        { get { return m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed; } }

        public static ID JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened
        { get { return m_JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened; } }



        public static bool Get_JOURNAL_StockTake_Type_ID(Transaction transaction)
        {

            if (fs.Get_TABLE_TYPE(JOURNAL_StockTake_Type_TABLE, New_StockTake_opened, ref m_JOURNAL_StockTake_Type_ID_New_StockTake_opened, transaction))
            {
                if (fs.Get_TABLE_TYPE(JOURNAL_StockTake_Type_TABLE, Opened_StockTake_closed, ref m_JOURNAL_StockTake_Type_ID_Opened_StockTake_closed, transaction))
                {
                    if (fs.Get_TABLE_TYPE(JOURNAL_StockTake_Type_TABLE, Closed_StockTake_changed, ref m_JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened, transaction))
                    {
                            return true;
                    }
                }
            }
            return false;
        }

        public static bool Get(ID xAtom_WorkPeriod_ID, ID StockTake_id, ID stocktake_type_id, DateTime dEventTime,  ref ID JOURNAL_StockTake_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_JOURNAL_StockTake_Type_ID = "@par_JOURNAL_StockTake_Type_ID";
            SQL_Parameter par_JOURNAL_StockTake_Type_ID = new SQL_Parameter(spar_JOURNAL_StockTake_Type_ID, false, stocktake_type_id);
            lpar.Add(par_JOURNAL_StockTake_Type_ID);

            string spar_StockTake_ID = "@par_StockTake_ID";
            SQL_Parameter par_StockTake_ID = new SQL_Parameter(spar_StockTake_ID, false, StockTake_id);
            lpar.Add(par_StockTake_ID);

            string spar_EventTime = "@par_EventTime";
            SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dEventTime);
            lpar.Add(par_EventTime);

            ID Atom_WorkPeriod_id = xAtom_WorkPeriod_ID;
            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, xAtom_WorkPeriod_ID);
            lpar.Add(par_Atom_WorkPeriod_ID);

            string table_name = "JOURNAL_StockTake";
            string sql = "insert into " + table_name + " (JOURNAL_StockTake_Type_ID,StockTake_ID,EventTime,Atom_WorkPeriod_ID)values(" + spar_JOURNAL_StockTake_Type_ID + "," + spar_StockTake_ID + "," + spar_EventTime + "," + spar_Atom_WorkPeriod_ID + ")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref JOURNAL_StockTake_ID, ref Err, table_name))
            {
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
