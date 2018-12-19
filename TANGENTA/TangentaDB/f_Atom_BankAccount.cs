using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Atom_BankAccount
    {
        public static bool Get(string BankName,
                            string Tax_ID,
                            string Registrattion_ID,
                            bool_v TaxPayer_v,
                            string_v Comment1_v,
                            bool Active,
                            string BankAccount,
                            string Description,
                            ref ID Atom_BankAccount_ID,
                            Transaction transaction
                            )
        {
            ID XAtom_Bank_ID = null;
            if (f_Atom_Bank.Get(BankName, Tax_ID, Registrattion_ID, TaxPayer_v, Comment1_v,  ref XAtom_Bank_ID,
                                transaction))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Atom_Bank_ID = " Atom_Bank_ID is null ";
                string sval_Atom_Bank_ID = "  null ";
                if (XAtom_Bank_ID != null)
                {
                    string spar_Atom_Bank_ID = "@par_Atom_Bank_ID";
                    SQL_Parameter par_Atom_Bank_ID = new SQL_Parameter(spar_Atom_Bank_ID, false, XAtom_Bank_ID);
                    lpar.Add(par_Atom_Bank_ID);
                    scond_Atom_Bank_ID = " Atom_Bank_ID = " + spar_Atom_Bank_ID + " ";
                    sval_Atom_Bank_ID = " " + spar_Atom_Bank_ID + " ";
                }


                string spar_Active = "@par_Active";
                SQL_Parameter par_Active = new SQL_Parameter(spar_Active, SQL_Parameter.eSQL_Parameter.Bit, false, Active);
                lpar.Add(par_Active);

                string scond_BankAccount = " TRR is null ";
                string sval_BankAccount = "  null ";
                if (BankAccount != null)
                {
                    string spar_BankAccount = "@par_BankAccount";
                    SQL_Parameter par_BankAccount = new SQL_Parameter(spar_BankAccount, SQL_Parameter.eSQL_Parameter.Nvarchar, false, BankAccount);
                    lpar.Add(par_BankAccount);
                    scond_BankAccount = " TRR = " + spar_BankAccount + " ";
                    sval_BankAccount = " " + spar_BankAccount + " ";
                }
                string scond_Description = " Description is null ";
                string sval_Description = "  null ";
                if (Description != null)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                    scond_Description = " Description = " + spar_Description + " ";
                    sval_Description = " " + spar_Description + " ";
                }
                string sql = @"select ID from Atom_BankAccount where Active = " + spar_Active
                                                                                + " and " + scond_Atom_Bank_ID
                                                                                + " and " + scond_BankAccount
                                                                                + " and " + scond_Description;
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_BankAccount_ID == null)
                        {
                            Atom_BankAccount_ID = new ID();
                        }
                        Atom_BankAccount_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        if (!transaction.Get(DBSync.DBSync.Con))
                        {
                                return false;
                        }
                        sql = @"insert into Atom_BankAccount (Atom_Bank_ID,
                                                             Active,
                                                             TRR,
                                                             Description) values
                                                             (" + sval_Atom_Bank_ID +
                                                             "," + spar_Active +
                                                             "," + sval_BankAccount +
                                                             "," + sval_Description +
                                                             ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_BankAccount_ID,  ref Err, "Atom_BankAccount"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_BankAccount:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_BankAccount:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
