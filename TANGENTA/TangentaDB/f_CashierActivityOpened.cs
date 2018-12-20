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
    public static class f_CashierActivityOpened
    {
        public static bool Get(ID Atom_WorkPeriod_ID, ref ID xCashierActivityOpened_ID, ref DateTime loginTime)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Atom_WorkPeriod_ID = null;
            string sval_Atom_WorkPeriod_ID = "null";
            if (ID.Validate(Atom_WorkPeriod_ID))
            {
                string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
                SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, Atom_WorkPeriod_ID);
                lpar.Add(par_Atom_WorkPeriod_ID);
                scond_Atom_WorkPeriod_ID = "Atom_WorkPeriod_ID = " + spar_Atom_WorkPeriod_ID;
                sval_Atom_WorkPeriod_ID = spar_Atom_WorkPeriod_ID;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_CashierActivityOpened:Get:Atom_WorkPeriod_ID is not valid");
                return false;
            }
            if (!f_Atom_WorkPeriod.GetLoginTime(Atom_WorkPeriod_ID,ref loginTime))
            {
                return false;
            }
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from CashierActivityOpened where " + scond_Atom_WorkPeriod_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xCashierActivityOpened_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into CashierActivityOpened (Atom_WorkPeriod_ID) values (" + sval_Atom_WorkPeriod_ID + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref xCashierActivityOpened_ID, ref Err, "CashierActivityOpened"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_CashierActivityOpened:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivityOpened:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetPerson(ID xCashierActivityOpened_ID, ref string firstName, ref string lastName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            string sql = @"select 
                           acfn.FirstName as FirstName,
                           acln.LastName as LastName
                           from CashierActivityOpened  cao
                           inner join Atom_WorkPeriod awp on cao.Atom_WorkPeriod_ID = awp.ID
                           inner join Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                           inner join Atom_Person aper on amop.Atom_Person_ID = aper.ID
                           inner join Atom_cFirstName acfn on aper.Atom_cFirstName_ID = acfn.ID
                           inner join Atom_cLastName acln on aper.Atom_cLastName_ID = acln.ID
                    where cao.ID = " + xCashierActivityOpened_ID.ToString();
            string Err = null;
            lastName = null;
            firstName = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string_v first_name_v = tf.set_string(dt.Rows[0]["FirstName"]);
                    if (first_name_v != null)
                    {
                        firstName = first_name_v.v;
                    }

                    string_v last_name_v = tf.set_string(dt.Rows[0]["LastName"]);
                    if (last_name_v != null)
                    {
                        lastName = last_name_v.v;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_CashierActivityOpened:GetPerson:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
