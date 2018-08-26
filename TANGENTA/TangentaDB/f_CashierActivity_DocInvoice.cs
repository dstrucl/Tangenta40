using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_CashierActivity_DocInvoice
    {
        public static bool Insert(ID xCashierActivity_ID,ID xDocInvoice_ID, ref ID xCashierActivity_DocInvoice_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_CashierActivity_ID = "@par_CashierActivityID";
            SQL_Parameter par_CashierActivity_ID = new SQL_Parameter(spar_CashierActivity_ID,  false, xCashierActivity_ID);
            lpar.Add(par_CashierActivity_ID);

            string spar_DocInvoice_ID = "@par_DocInvoice_ID";
            SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, false, xDocInvoice_ID);
            lpar.Add(par_DocInvoice_ID);



            string sql = @"insert into CashierActivity_DocInvoice (DocInvoice_ID,CashierActivity_ID) values (" + spar_DocInvoice_ID + "," + spar_CashierActivity_ID + ")";
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref xCashierActivity_ID, ref Err, "CashierActivity_DocInvoice"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivity_DocInvoice:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }
    }
}
