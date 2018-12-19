using DBConnectionControl40;
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
        public ID Advanced_100PercentPayment_ID = null;
        public ID Advanced_100PercentPayment_ToBankAccount_ID = null;
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
                            Advanced_100PercentPayment_ID = tf.set_ID(dr["ID"]);
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
        public bool InsertDefault(Transaction transaction)
        {
            
            if (f_TermsOfPayment.Get(lng.s_TermsOfPayment_Default_100PercentInAdvance.s,ref Advanced_100PercentPayment_ID, transaction))
            {
                if (f_TermsOfPayment.SetDefault(Advanced_100PercentPayment_ID, transaction))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
