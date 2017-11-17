using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class TermsOfPayment_definitions
    {
        public long_v Advanced_100PercentPayment_ID_v = null;
        public long_v Advanced_100PercentPayment_ToBankAccount_ID_v = null;
        public DataTable dt_TermsOfPayment = null;

        public bool Read()
        {
            string Err = null;
            string sql = @"select ID,Description from TermsOfPayment";
            if (dt_TermsOfPayment == null)
            {
                dt_TermsOfPayment = new DataTable();
            }
            dt_TermsOfPayment.Clear();
            dt_TermsOfPayment.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_TermsOfPayment, sql,ref Err))
            {
                foreach (DataRow dr in dt_TermsOfPayment.Rows)
                {
                    object oDescription = dr["Description"];
                    if (oDescription is string)
                    {
                        if (lng.s_TermsOfPayment_Default_100PercentInAdvance.s.Equals((string)oDescription))
                        {
                            Advanced_100PercentPayment_ID_v = tf.set_long(dr["ID"]);
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:TermsOfPayment_definitions:Read:slq=" +sql+"\r\nErr="+Err);
                return false;
            }

        }
        public bool InsertDefault()
        {
            
            if (f_TermsOfPayment.Get(lng.s_TermsOfPayment_Default_100PercentInAdvance.s,ref Advanced_100PercentPayment_ID_v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
