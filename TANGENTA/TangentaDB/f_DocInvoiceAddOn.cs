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
                             long_v DocInvoice_ID_v,
                             ref long_v DocInvoiceAddOn_ID_v)
        {

            if (DocInvoice_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:DocInvoice_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_DocInvoice_ID = "@par_DocInvoice_ID";
            SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID_v.v);
            lpar.Add(par_DocInvoice_ID);
            string sql = "select ID from DocInvoiceAddOn where DocInvoice_ID = " + spar_DocInvoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    long ID = (long)dt.Rows[0]["ID"];
                    if (DocInvoiceAddOn_ID_v==null)
                    {
                        DocInvoiceAddOn_ID_v = new long_v(ID);
                    }
                    else
                    {
                        DocInvoiceAddOn_ID_v.v = ID;
                    }
                }
                else
                {
                    DocInvoiceAddOn_ID_v = null;
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