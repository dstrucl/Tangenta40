using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Journal_Invoice
    {
        public static bool Write(long Invoice_ID, long Atom_WorkPeriod_ID, string Event_Type, string Event_Description,DateTime_v event_time, ref long journal_invoice_id)
        {
            long journal_invoice_type_id = -1;
            if (Get_journal_invoice_type_id(Event_Type,Event_Description, ref journal_invoice_type_id))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_journal_invoice_type_id = "@par_journal_invoice_type_id";
                SQL_Parameter par_journal_invoice_type_id = new SQL_Parameter(spar_journal_invoice_type_id, SQL_Parameter.eSQL_Parameter.Bigint, false, journal_invoice_type_id);
                lpar.Add(par_journal_invoice_type_id);

                string spar_Invoice_ID = "@par_Invoice_ID";
                SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Invoice_ID);
                lpar.Add(par_Invoice_ID);

                string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
                SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkPeriod_ID);
                lpar.Add(par_Atom_WorkPeriod_ID);

                DateTime dtime = DateTime.Now;
                if (event_time!=null)
                {
                    dtime = event_time.v;
                }
                string spar_EventTime = "@par_EventTime";
                SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dtime);
                lpar.Add(par_EventTime);
                string sql = "insert into journal_invoice (journal_invoice_type_id,Invoice_ID,EventTime,Atom_WorkPeriod_ID)values(" + spar_journal_invoice_type_id + "," + spar_Invoice_ID + "," + spar_EventTime + "," + spar_Atom_WorkPeriod_ID + ")";
                object ores = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref journal_invoice_id, ref ores, ref Err, "journal_invoice"))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Journal_Invoice:Write:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        public static bool Get_journal_invoice_type_id(string Event_Type,string Event_Description, ref long journal_invoice_type_id)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            string spar_Description = "@par_Description";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name,SQL_Parameter.eSQL_Parameter.Nvarchar,false,Event_Type);
            lpar.Add(par_Name);

            string par_Description_cond = null;
            string par_Description_value = null;
            if (Event_Description!=null)
            {
                par_Description_cond = " Description = " +spar_Description;
                par_Description_value = spar_Description;
            }
            else
            {
                par_Description_cond = " Description is null ";
                par_Description_value = "null";
            }

            SQL_Parameter par_Description = new SQL_Parameter(spar_Description,SQL_Parameter.eSQL_Parameter.Nvarchar,false,Event_Description);
            lpar.Add(par_Description);

            string Err= null;
            string sql = "select ID from journal_invoice_type where name = " + spar_Name + " and " + par_Description_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    journal_invoice_type_id = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into journal_invoice_type (Name,Description) values (" + spar_Name + "," + par_Description_value + ")";
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref journal_invoice_type_id, ref ores, ref Err, "journal_invoice_type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Journal_Invoice:Get_journal_invoice_type_id:sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Journal_Invoice:Get_journal_invoice_type_id:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }

        }
    }
}
