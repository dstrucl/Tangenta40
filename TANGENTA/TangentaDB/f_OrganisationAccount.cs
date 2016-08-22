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
                        long_v BankAccount_ID_v,
                        long_v Organisation_ID_v,
                        string_v Organisation_BankAccount_Description_v,
                        ref long_v OrganisationAccount_ID_v)
        {
            string Err = null;

            string BankAccount_ID_v_cond = "BankAccount_ID is null";
            string BankAccount_ID_v_Value = "null";

            if (BankAccount_ID_v != null)
            {
                    BankAccount_ID_v_Value = BankAccount_ID_v.v.ToString();
                    BankAccount_ID_v_cond = "BankAccount_ID = " + BankAccount_ID_v.v.ToString();
            }

            string Organisation_ID_v_cond = "Organisation_ID is null";
            string Organisation_ID_v_Value = "null";

            if (Organisation_ID_v != null)
            {
                    Organisation_ID_v_Value = Organisation_ID_v.v.ToString();
                    Organisation_ID_v_cond = "Organisation_ID = " + Organisation_ID_v.v.ToString();
            }

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Organisation_BankAccount_Description_v_ID_v_cond = "Organisation_BankAccount_Description_v_ID is null";
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
                    if (OrganisationAccount_ID_v == null)
                    {
                        OrganisationAccount_ID_v = new long_v();
                    }
                    OrganisationAccount_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = @"insert into OrganisationAccount (BankAccount_ID,Organisation_ID,Description) values (
                                                                            " + BankAccount_ID_v_Value.ToString() + @",
                                                                            " + Organisation_ID_v_Value + @",
                                                                            " + Organisation_BankAccount_Description_v_ID_v_Value + ")";
                    object oret = null;
                    long OrganisationAccount_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref OrganisationAccount_ID, ref oret, ref Err, "OrganisationAccount"))
                    {
                        if (OrganisationAccount_ID_v == null)
                        {
                            OrganisationAccount_ID_v = new long_v();
                        }
                        OrganisationAccount_ID_v.v = OrganisationAccount_ID;
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

        public static bool DeleteAll()
        {

            return fs.DeleteAll("OrganisationAccount");
        }
    }
}
