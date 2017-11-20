using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    public class Old_tables_1_04_to_1_05
    {
        public DataTable dt_DocInvoice = new DataTable();
        public DataTable dt_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice_Type = new DataTable();
        public bool Read()
        {
            string Err = null;
            string sql = "select * from DocInvoice";
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
            {
                sql = "select * from Invoice";
                if (DBSync.DBSync.ReadDataTable(ref dt_Invoice, sql, ref Err))
                {
                    sql = "select * from JOURNAL_Invoice";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice, sql, ref Err))
                    {
                        sql = "select * from Journal_Invoice_Type";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice_Type, sql, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err=" + Err);
                            return false;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err=" + Err);
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err=" + Err);
                return false;
            }

        }
    }
}
