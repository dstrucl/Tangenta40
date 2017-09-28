using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Atom_Bank
    {
        public static bool Get(string BankName,
                               string Tax_ID,
                               string Registrattion_ID,
                               bool_v TaxPayer_v,
                               string_v Comment1_v,
                               string_v Comment2_v,
                               ref long_v AtomBank_ID_v
                               )
        {
            AtomBank_ID_v = null;
            string_v OrganisationName_v = DBTypes.string_v.Set(BankName);
            string_v Tax_ID_v = DBTypes.string_v.Set(Tax_ID);
            string_v Registrattion_ID_v = DBTypes.string_v.Set(Registrattion_ID);
            long_v Atom_Organisation_ID_v = null;
            if (f_Atom_Organisation.Get(OrganisationName_v, Tax_ID_v, Registrattion_ID_v, TaxPayer_v, Comment1_v, Comment2_v,ref Atom_Organisation_ID_v))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string scond_Atom_Organisation_ID = " Atom_Organisation_ID is null ";
                string sval_Atom_Organisation_ID = " null ";
                if (Atom_Organisation_ID_v!=null)
                {
                    string spar_Atom_Organisation_ID = "@par_Atom_Organisation_ID";
                    SQL_Parameter par_Atom_Organisation_ID = new SQL_Parameter(spar_Atom_Organisation_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Organisation_ID_v.v);
                    lpar.Add(par_Atom_Organisation_ID);
                    scond_Atom_Organisation_ID = " Atom_Organisation_ID = " + spar_Atom_Organisation_ID+" ";
                    sval_Atom_Organisation_ID = " "+ spar_Atom_Organisation_ID + " ";
                }
                string sql = "select ID from Atom_Bank where " + scond_Atom_Organisation_ID;
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (AtomBank_ID_v == null)
                        {
                            AtomBank_ID_v = new long_v();
                        }
                        AtomBank_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = "insert into Atom_Bank (Atom_Organisation_ID) values(" + sval_Atom_Organisation_ID + ")";
                        long Atom_Bank_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Bank_ID, ref oret, ref Err, "Atom_Bank"))
                        {
                            if (AtomBank_ID_v == null)
                            {
                                AtomBank_ID_v = new long_v();
                            }
                            AtomBank_ID_v.v = Atom_Bank_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Bank:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Bank:Get:sql=" + sql + "\r\nErr=" + Err);
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
