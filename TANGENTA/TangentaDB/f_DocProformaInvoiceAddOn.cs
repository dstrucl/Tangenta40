using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocProformaInvoiceAddOn
    {

        public static bool Get(
                             long_v DocProformaInvoice_ID_v,
                             ref long_v DocProformaInvoiceAddOn_ID_v)
        {

            if (DocProformaInvoice_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoiceAddOn:DocProformaInvoice_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_DocProformaInvoice_ID = "@par_DocProformaInvoice_ID";
            SQL_Parameter par_DocProformaInvoice_ID = new SQL_Parameter(spar_DocProformaInvoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocProformaInvoice_ID_v.v);
            lpar.Add(par_DocProformaInvoice_ID);
            string sql = "select ID from DocProformaInvoiceAddOn where DocProformaInvoice_ID = " + spar_DocProformaInvoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    long ID = (long)dt.Rows[0]["ID"];
                    if (DocProformaInvoiceAddOn_ID_v==null)
                    {
                        DocProformaInvoiceAddOn_ID_v = new long_v(ID);
                    }
                    else
                    {
                        DocProformaInvoiceAddOn_ID_v.v = ID;
                    }
                }
                else
                {
                    DocProformaInvoiceAddOn_ID_v = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoiceAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}