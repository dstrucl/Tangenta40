#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
    public static class f_Journal_DocProformaInvoice
    {
        public  const string PRINT = "PRINT";

        public static bool Write(ID DocProformaInvoice_ID, ID Atom_WorkPeriod_ID, ID journal_docproformainvoice_type_id, DateTime_v issue_time, ref ID Journal_DocInvoice_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_journal_docinvoice_type_id = "@par_journal_docproformainvoice_type_id";
            SQL_Parameter par_journal_invoice_type_id = new SQL_Parameter(spar_journal_docinvoice_type_id, false, journal_docproformainvoice_type_id);
            lpar.Add(par_journal_invoice_type_id);

            string spar_DocProfromaInvoice_ID = "@par_DocProformaInvoice_ID";
            SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_DocProfromaInvoice_ID, false, DocProformaInvoice_ID);
            lpar.Add(par_Invoice_ID);

            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, Atom_WorkPeriod_ID);
            lpar.Add(par_Atom_WorkPeriod_ID);

            DateTime dtime = DateTime.Now;
            if (issue_time != null)
            {
                dtime = issue_time.v;
            }

            string spar_EventTime = "@par_EventTime";
            SQL_Parameter par_EventTime = new SQL_Parameter(spar_EventTime, SQL_Parameter.eSQL_Parameter.Datetime, false, dtime);
            lpar.Add(par_EventTime);
            string sql = "insert into journal_docproformainvoice (journal_docproformainvoice_type_id,DocProformaInvoice_ID,EventTime,Atom_WorkPeriod_ID)values(" + spar_journal_docinvoice_type_id + "," + spar_DocProfromaInvoice_ID + "," + spar_EventTime + "," + spar_Atom_WorkPeriod_ID + ")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Journal_DocInvoice_ID,  ref Err, "journal_docproformainvoice"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Journal_DocProformaInvoice:Write:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get_journal_DocProformaInvoice_type_id(string Event_Type, string Event_Description, ref ID journal_invoice_type_id, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            string spar_Description = "@par_Description";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Event_Type);
            lpar.Add(par_Name);

            string par_Description_cond = null;
            string par_Description_value = null;
            if (Event_Description != null)
            {
                par_Description_cond = " Description = " + spar_Description;
                par_Description_value = spar_Description;
            }
            else
            {
                par_Description_cond = " Description is null ";
                par_Description_value = "null";
            }

            SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Event_Description);
            lpar.Add(par_Description);

            string Err = null;
            string sql = "select ID from journal_DocProformaInvoice_type where name = " + spar_Name + " and " + par_Description_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (journal_invoice_type_id==null)
                    {
                        journal_invoice_type_id = new ID();
                    }
                    journal_invoice_type_id.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into journal_DocProformaInvoice_type (Name,Description) values (" + spar_Name + "," + par_Description_value + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref journal_invoice_type_id,  ref Err, "journal_docproformainvoice_type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Journal_DocProformaInvoice:Get_journal_invoice_type_id:sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Journal_Invoice:Get_journal_invoice_type_id:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
