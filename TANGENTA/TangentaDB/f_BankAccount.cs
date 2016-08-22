using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_BankAccount
    {
        public static bool Get(
                string_v TRR_v,
                bool_v Active_v,
                string_v BankAccount_Description_v,
                long_v Bank_ID_v,
                ref long_v BankAccount_ID_v)
        {
            string Err = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string TRR_v_cond = "TRR is null";
            string TRR_v_Value = "null";

            if (TRR_v != null)
            {
                TRR_v_Value = "@par_TRR";
                SQL_Parameter par_Organisation_BankAccount_Description = new SQL_Parameter(TRR_v_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, TRR_v.v);
                lpar.Add(par_Organisation_BankAccount_Description);
                TRR_v_cond = " TRR = " + TRR_v_Value;
            }

            string BankAccount_Description_v_cond = "Description is null";
            string BankAccount_Description_v_Value = "null";

            if (BankAccount_Description_v != null)
            {
                BankAccount_Description_v_Value = "@par_BankAccount_Description";
                SQL_Parameter par_Organisation_BankAccount_BankAccount_Description = new SQL_Parameter(BankAccount_Description_v_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, BankAccount_Description_v.v);
                lpar.Add(par_Organisation_BankAccount_BankAccount_Description);
                BankAccount_Description_v_cond = " Description = " + BankAccount_Description_v_Value;
            }

            string Active_v_cond = "Active is null";
            string Active_v_Value = "null";

            if (Active_v != null)
            {
                string sbinVal = "0";
                if (Active_v.v)
                {
                    sbinVal = "1";
                }
                Active_v_Value = sbinVal;

                Active_v_cond = "Active = " + Active_v_Value;
            }

            string Bank_ID_v_cond = "Bank_ID is null";
            string Bank_ID_v_Value = "null";

            if (Bank_ID_v != null)
            {
                Bank_ID_v_Value = Bank_ID_v.v.ToString();
                Bank_ID_v_cond = "Bank_ID = " + Bank_ID_v.v.ToString();
            }


            string sql_select = "select ID from BankAccount where " + Bank_ID_v_cond + @" and 
                                                                            " + TRR_v_cond + @" and  
                                                                            " + BankAccount_Description_v_cond + @" and  
                                                                            " + Active_v_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (BankAccount_ID_v == null)
                    {
                        BankAccount_ID_v = new long_v();
                    }
                    BankAccount_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = @"insert into BankAccount (TRR,Active,Description,Bank_ID) values (
                                                                            " + TRR_v_Value + @",
                                                                            " + Active_v_Value + @",
                                                                            " + BankAccount_Description_v_Value + @",
                                                                            "  + Bank_ID_v_Value + ")";
                    object oret = null;
                    long BankAccount_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref BankAccount_ID, ref oret, ref Err, "BankAccount"))
                    {
                        if (BankAccount_ID_v == null)
                        {
                            BankAccount_ID_v = new long_v();
                        }
                        BankAccount_ID_v.v = BankAccount_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_BankAccount:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_BankAccount:Get:sql=" + sql_select + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("BankAccount");
        }
    }
}
