using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class f_OrganisationAccount
    {
        public static bool Get(
                        ID BankAccount_ID,
                        ID Organisation_ID,
                        string_v Organisation_BankAccount_Description_v,
                        ref ID OrganisationAccount_ID,
                        Transaction transaction)
        {
            string Err = null;

            string BankAccount_ID_v_cond = "BankAccount_ID is null";
            string BankAccount_ID_v_Value = "null";

            if (ID.Validate(BankAccount_ID))
            {
                    BankAccount_ID_v_Value = BankAccount_ID.ToString();
                    BankAccount_ID_v_cond = "BankAccount_ID = " + BankAccount_ID.ToString();
            }

            string Organisation_ID_v_cond = "Organisation_ID is null";
            string Organisation_ID_v_Value = "null";

            if (Organisation_ID != null)
            {
                    Organisation_ID_v_Value = Organisation_ID.ToString();
                    Organisation_ID_v_cond = "Organisation_ID = " + Organisation_ID.ToString();
            }

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Organisation_BankAccount_Description_v_ID_v_cond = "Description is null";
            string Organisation_BankAccount_Description_v_ID_v_Value = "null";

            if (Organisation_BankAccount_Description_v != null)
            {
                Organisation_BankAccount_Description_v_ID_v_Value = "@par_Organisation_BankAccount_Description";
                SQL_Parameter par_Organisation_BankAccount_Description = new SQL_Parameter(Organisation_BankAccount_Description_v_ID_v_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Organisation_BankAccount_Description_v.v);
                lpar.Add(par_Organisation_BankAccount_Description);
                Organisation_BankAccount_Description_v_ID_v_cond = " Description = " + Organisation_BankAccount_Description_v_ID_v_Value;
            }

            string sql_select = "select ID from OrganisationAccount where " + BankAccount_ID_v_cond + @" and 
                                                                            " + Organisation_ID_v_cond + @" and  
                                                                            " + Organisation_BankAccount_Description_v_ID_v_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (OrganisationAccount_ID == null)
                    {
                        OrganisationAccount_ID = new ID();
                    }
                    OrganisationAccount_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    string sql_insert = @"insert into OrganisationAccount (BankAccount_ID,Organisation_ID,Description) values (
                                                                            " + BankAccount_ID_v_Value.ToString() + @",
                                                                            " + Organisation_ID_v_Value + @",
                                                                            " + Organisation_BankAccount_Description_v_ID_v_Value + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql_insert, lpar, ref OrganisationAccount_ID,  ref Err, "OrganisationAccount"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_OrganisationAccount:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OrganisationAccount:Get:sql=" + sql_select + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool DeleteAll(Transaction transaction)
        {

            return fs.DeleteAll("OrganisationAccount", transaction);
        }
    }
}
