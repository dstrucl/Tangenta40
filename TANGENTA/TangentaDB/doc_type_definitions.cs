﻿using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBTypes;

namespace TangentaDB
{
    public class doc_type_definitions
    {
        public class doc_type
        {
            public long ID = -1;
            public string Name = null;
            public string Description = null;
            public doc_type(string Doc_Type_Name, string Doc_Type_Description)
            {
                Name = Doc_Type_Name;
                Description = Doc_Type_Description;
            }
        }

        public doc_type HTMLPrintTemplate_Invoice = null;
        public doc_type HTMLPrintTemplate_ProformaInvoice = null;



        public List<doc_type> doc_type_list = new List<doc_type>();

        public long_v HTMLPrintTemplate_Invoice_doc_type_ID
        {
            get
            {
                if (doc_type_list.Count > 0)
                {
                    return new long_v(doc_type_list[0].ID);
                }
                else
                {
                    return null;
                }
            }
        }

        public long_v HTMLPrintTemplate_Proforma_Invoice_doc_type_ID
        {
            get
            {
                if (doc_type_list.Count > 0)
                {
                    return new long_v(doc_type_list[1].ID);
                }
                else
                {
                    return null;
                }
            }
        }

        public doc_type_definitions()
        {

            //Proforma Invoice
            HTMLPrintTemplate_Invoice = new doc_type("HTML Print Template Invoice", lng.s_HTML_Print_template_DocInvoice.s);
            HTMLPrintTemplate_ProformaInvoice = new doc_type("HTML Print Template Proforma Invoice", lng.s_HTML_Print_template_DocProformaInvoice.s);

            doc_type_list.Add(HTMLPrintTemplate_Invoice);
            doc_type_list.Add(HTMLPrintTemplate_ProformaInvoice);
        }


        public bool Read()
        {
            string Err = null;
            string sql = "select ID,Name, Description from doc_type";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {

                foreach (doc_type doct in doc_type_list)
                {
                    if (Get(doct, dt))
                    {
                        continue;
                    }
                    else
                    {
                        Set(doct);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_type:Read:Err=" + Err);
                return false;
            }
        }

        private bool Get(doc_type doct, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Name"] is string)
                {
                    string sName = (string)dr["Name"];
                    if (doct.Name.Equals(sName))
                    {
                        doct.ID = (long)dr["ID"];
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Set(doc_type doct)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, doct.Name);
            string sval_Name = spar_Name;
            lpar.Add(par_Name);

            string sval_Description = "null";
            if (doct.Description != null)
            {
                if (doct.Description.Length > 0)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, doct.Description);
                    sval_Description = spar_Description;
                    lpar.Add(par_Description);
                }
            }


            string sql = "insert into doc_type (Name,Description) values (" + sval_Name + "," + sval_Description +")";
            long dpt_id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref dpt_id, ref oret, ref Err, "doc_type"))
            {
                doct.ID = dpt_id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_type:Set:Err= " + Err);
                return false;
            }
        }
    }
}
