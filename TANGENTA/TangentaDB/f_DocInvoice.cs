using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoice
    {
        public static bool Get(long docInvoice_ID, ref bool bDraft, ref long draftNumber, ref long financialYear, ref long numberInFinancialYear)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Draft,
                                 DraftNumber,
                                 FinancialYear,
                                 NumberInFinancialYear
                                 from DocInvoice where ID = " + docInvoice_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err ))
            {
                if (dt.Rows.Count > 0)
                {
                    bDraft = DBTypes.tf._set_bool(dt.Rows[0]["Draft"]);
                    draftNumber = DBTypes.tf._set_long(dt.Rows[0]["DraftNumber"]);
                    financialYear = DBTypes.tf._set_long(dt.Rows[0]["FinancialYear"]);
                    numberInFinancialYear = DBTypes.tf._set_long(dt.Rows[0]["NumberInFinancialYear"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:Get:sql=" + sql + "\r\nNo DocInvoice data for ID = " + docInvoice_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }
    }
}
