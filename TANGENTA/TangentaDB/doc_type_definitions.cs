using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        public doc_type Invoice = null;
        public doc_type ProformaInvoice = null;



        public List<doc_type> doc_type_list = new List<doc_type>();

        public doc_type_definitions()
        {

            //Proforma Invoice
            Invoice = new doc_type("Invoice", lngRPM.s_DocInvoice.s);
            ProformaInvoice = new doc_type("Proforma Invoice", lngRPM.s_DocProformaInvoice.s);

            doc_type_list.Add(Invoice);
            doc_type_list.Add(ProformaInvoice);
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
