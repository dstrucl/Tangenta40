using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoiceAddOn
    {

        public static bool Get(
                             ID DocInvoice_ID,
                             ref ID DocInvoiceAddOn_ID)
        {

            if (DocInvoice_ID == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:DocInvoice_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_DocInvoice_ID = "@par_DocInvoice_ID";
            SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, false, DocInvoice_ID);
            lpar.Add(par_DocInvoice_ID);
            string sql = "select ID from DocInvoiceAddOn where DocInvoice_ID = " + spar_DocInvoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (DocInvoiceAddOn_ID==null)
                    {
                        DocInvoiceAddOn_ID = new ID();
                    }
                    DocInvoiceAddOn_ID.Set(dt.Rows[0]["ID"]);
                }
                else
                {
                    DocInvoiceAddOn_ID = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}