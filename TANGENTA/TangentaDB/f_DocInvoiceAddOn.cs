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

        public static bool Get(
                                long_v DocInvoice_ID_v,
                                long_v TermsOfPayment_ID_v,
                                long_v MethodOfPayment_DI_ID_v,
                                long_v Atom_Warranty_ID_v,
                                DateTime PaymentDeadLine,
                                ref long_v DocInvoiceAddOn_ID)
        {

            if (DocInvoice_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:DocInvoice_ID_v==null");
                return false;
            }
            if (TermsOfPayment_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:TermsOfPayment_ID_v==null");
                return false;
            }

            if (MethodOfPayment_DI_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:MethodOfPayment_DI_ID_v==null");
                return false;
            }
           // if (Atom_Warranty_ID == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoiceAddOn:Atom_Warranty_ID==null");
                return false;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_DocInvoice_ID = "@par_DocInvoice_ID";
            SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID_v.v);
            lpar.Add(par_DocInvoice_ID);

            string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
            SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, TermsOfPayment_ID_v.v);
            lpar.Add(par_TermsOfPayment_ID);

            string spar_MethodOfPayment_DI_ID = "@par_MethodOfPayment_DI_ID";
            SQL_Parameter par_MethodOfPayment_DI_ID = new SQL_Parameter(spar_MethodOfPayment_DI_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DI_ID_v.v);
            lpar.Add(par_MethodOfPayment_DI_ID);

            string spar_Atom_Warranty_ID = "@par_Atom_Warranty_ID";
            SQL_Parameter par_Atom_Warranty_ID = new SQL_Parameter(spar_Atom_Warranty_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Warranty_ID_v.v);
            lpar.Add(par_Atom_Warranty_ID);

            return false;
        }
    }
}