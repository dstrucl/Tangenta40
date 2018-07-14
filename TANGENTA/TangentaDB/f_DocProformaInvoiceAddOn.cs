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
                             ID DocProformaInvoice_ID,
                             ref ID DocProformaInvoiceAddOn_ID)
        {

            if (DocProformaInvoice_ID == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoiceAddOn:DocProformaInvoice_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_DocProformaInvoice_ID = "@par_DocProformaInvoice_ID";
            SQL_Parameter par_DocProformaInvoice_ID = new SQL_Parameter(spar_DocProformaInvoice_ID,  false, DocProformaInvoice_ID);
            lpar.Add(par_DocProformaInvoice_ID);
            string sql = "select ID from DocProformaInvoiceAddOn where DocProformaInvoice_ID = " + spar_DocProformaInvoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (DocProformaInvoiceAddOn_ID==null)
                    {
                        DocProformaInvoiceAddOn_ID = new ID();
                    }
                    DocProformaInvoiceAddOn_ID.Set(dt.Rows[0]["ID"]);
                }
                else
                {
                    DocProformaInvoiceAddOn_ID = null;
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