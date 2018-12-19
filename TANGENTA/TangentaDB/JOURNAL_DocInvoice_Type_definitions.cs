#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class JOURNAL_DocInvoice_Type_definitions
    {
        public journaltype InvoiceDraftTime = null;
        public journaltype InvoiceTime = null;
        public journaltype InvoicePaidTime = null;
        public journaltype InvoiceStornoTime = null;


        List<journaltype> journaltype_list = new List<journaltype>();


        public JOURNAL_DocInvoice_Type_definitions()
        {
            //Tax Invoice
            InvoiceDraftTime = new journaltype("InvoiceDraftTime", lng.s_InvoiceDraftTime_description.s); ;
            journaltype_list.Add(InvoiceDraftTime);
            InvoiceTime = new journaltype("InvoiceTime", lng.s_InvoiceTime_description.s);
            journaltype_list.Add(InvoiceTime);
            InvoicePaidTime = new journaltype("InvoicePaidTime", lng.s_InvoicePaidTime_description.s); ;
            journaltype_list.Add(InvoicePaidTime);
            InvoiceStornoTime = new journaltype("InvoiceStornoTime", lng.s_InvoiceStornoTime_description.s); ;
            journaltype_list.Add(InvoiceStornoTime);

        }

        public bool Read()
        {
            string Err = null;
            string sql = "select ID,Name,Description from JOURNAL_DocInvoice_Type";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                string transaction_Set_JournalTyp_id = null;
                foreach (journaltype jrt in journaltype_list)
                {
                    if (Get(jrt, dt))
                    {
                        continue;
                    }
                    else
                    {
                        const string TRANSACTION_Set_JournalType = "Set_JournalType";
                        if (transaction_Set_JournalTyp_id==null)
                        {
                            if (!DBSync.DBSync.DB_for_Tangenta.BeginTransaction(TRANSACTION_Set_JournalType, ref transaction_Set_JournalTyp_id))
                            {
                                return false;
                            }
                        }
                        if (!Set(jrt))
                        {
                            DBSync.DBSync.DB_for_Tangenta.RollbackTransaction(transaction_Set_JournalTyp_id);
                            return false;
                        }
                    }

                }
                if (transaction_Set_JournalTyp_id != null)
                {
                    if (DBSync.DBSync.DB_for_Tangenta.CommitTransaction(transaction_Set_JournalTyp_id))
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:JOURNAL_DocInvoice_Type_definitions:Read:Err=" +Err);
                return false;
            }
        }

        private bool Get(journaltype jrt,DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Name"] is string)
                {
                    string sName = (string)dr["Name"];
                    if (jrt.Name.Equals(sName))
                    {
                        jrt.ID = tf.set_ID(dr["ID"]);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Set(journaltype jrt)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, jrt.Name);
            string sval_Name = spar_Name;
            lpar.Add(par_Name);

            string sval_Description = "null";
            if (jrt.Description!=null)
            {
                if (jrt.Description.Length>0)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description,SQL_Parameter.eSQL_Parameter.Nvarchar,false,jrt.Description);
                    sval_Description = spar_Description;
                    lpar.Add(par_Description);
                }
            }

            string sql = "insert into JOURNAL_DocInvoice_Type (Name,Description) values ("+sval_Name+","+sval_Description+")";
            ID jrt_id =null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar,ref jrt_id,ref Err,"JOURNAL_DocInvoice_Type"))
            {
                jrt.ID = jrt_id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:JOURNAL_DocInvoice_Type_definitions:Set:Err= "+Err);
                return false;
            }
        }
    }

    public class journaltype
    {
        public ID ID = null;
        public string Name = null;
        public string Description = null;
        public journaltype(string xName, string xDescription)
        {
            Name = xName;
            Description = xDescription;
        }

    }
}
