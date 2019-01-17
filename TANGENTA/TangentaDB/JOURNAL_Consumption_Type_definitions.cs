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
    public class JOURNAL_Consumption_Type_definitions
    {
        public journaltype ConsumptionDraftTime = null;
        public journaltype ConsumptionTime = null;
        public journaltype ConsumptionStornoTime = null;


        List<journaltype> journaltype_list = new List<journaltype>();


        public JOURNAL_Consumption_Type_definitions()
        {
            //Tax Invoice
            ConsumptionDraftTime = new journaltype("ConsumptionDraftTime", lng.s_InvoiceDraftTime_description.s); ;
            journaltype_list.Add(ConsumptionDraftTime);
            ConsumptionTime = new journaltype("ConsumptionTime", lng.s_InvoiceTime_description.s);
            journaltype_list.Add(ConsumptionTime);
            ConsumptionStornoTime = new journaltype("ConsumptionStornoTime", lng.s_InvoiceStornoTime_description.s); ;
            journaltype_list.Add(ConsumptionStornoTime);

        }

        public bool Read(Transaction transaction)
        {
            string Err = null;
            string sql = "select ID,Name,Description from JOURNAL_Consumption_Type";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                foreach (journaltype jrt in journaltype_list)
                {
                    if (Get(jrt, dt))
                    {
                        continue;
                    }
                    else
                    {
                        if (!Set(jrt, transaction))
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:JOURNAL_Consumption_Type_definitions:Read:Err=" +Err);
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

        private bool Set(journaltype jrt, Transaction transaction)
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
            string sql = "insert into JOURNAL_Consumption_Type (Name,Description) values ("+sval_Name+","+sval_Description+")";
            ID jrt_id =null;
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql,lpar,ref jrt_id,ref Err,"JOURNAL_Consumption_Type"))
            {
                jrt.ID = jrt_id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:JOURNAL_Consumption_Type_definitions:Set:Err= "+Err);
                return false;
            }
        }
    }
}
