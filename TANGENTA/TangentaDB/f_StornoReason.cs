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
    public static class f_StornoReason
    {
        public static bool Get(ID docInvoice_ID,ID stornoName_ID, ref ID stornoReason_ID, Transaction transaction)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_DocInvoice_ID = null;
            string sval_DocInvoice_ID = "null";
            if (ID.Validate(docInvoice_ID))
            {
                string spar_DocInvoice_ID = "@par_DocInvoice_ID";
                SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID,  false, docInvoice_ID);
                lpar.Add(par_DocInvoice_ID);
                scond_DocInvoice_ID = "DocInvoice_ID = " + spar_DocInvoice_ID;
                sval_DocInvoice_ID = spar_DocInvoice_ID;
            }
            else
            {
                scond_DocInvoice_ID = "DocInvoice_ID is null";
                sval_DocInvoice_ID = "null";
            }

            string scond_stornoName_ID = null;
            string sval_stornoName_ID = "null";
            if (ID.Validate(docInvoice_ID))
            {
                string spar_stornoName_ID = "@par_stornoName_ID";
                SQL_Parameter par_stornoName_ID = new SQL_Parameter(spar_stornoName_ID, false, stornoName_ID);
                lpar.Add(par_stornoName_ID);
                scond_stornoName_ID = "StornoName_ID = " + spar_stornoName_ID;
                sval_stornoName_ID = spar_stornoName_ID;
            }
            else
            {
                scond_stornoName_ID = "StornoName_ID is null";
                sval_stornoName_ID = "null";
            }

            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from StornoReason where " + scond_DocInvoice_ID +" and " + scond_stornoName_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                   if (stornoReason_ID == null)
                   {
                        stornoReason_ID = new ID();
                   }
                   stornoReason_ID.Set(dt.Rows[0]["ID"]);
                   return true;
                }
                else
                {
                    sql = @"insert into StornoReason (DocInvoice_ID,StornoName_ID) values (" + sval_DocInvoice_ID + ","+ sval_stornoName_ID + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref stornoReason_ID,  ref Err, "StornoReason"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_StornoReason:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_StornoReason:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(ID docInvoice_ID,string xstornoName, ref ID stornoReason_ID, Transaction transaction)
        {
            ID stornoName_ID = null;
            if (f_StornoName.Get(xstornoName, ref stornoName_ID, transaction))
            {
                return Get(docInvoice_ID, stornoName_ID, ref stornoReason_ID, transaction);
            }
            else
            {
                return false;
            }
        }
    }
}
