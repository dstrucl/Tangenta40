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
    public static class f_MethodOfPayment_DPI_BAccount
    {
        public static bool Get(
                              long MethodOfPayment_DPI_ID,
                              long Atom_BankAccount_ID,
                              ref long_v MethodOfPayment_DPI_BAccount_ID_v)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;
            DataTable dt = new DataTable();


            string spar_MethodOfPayment_DPI_ID = "@par_MethodOfPayment_DPI_ID";
            SQL_Parameter par_MethodOfPayment_DPI_ID = new SQL_Parameter(spar_MethodOfPayment_DPI_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DPI_ID);
            lpar.Add(par_MethodOfPayment_DPI_ID);

            string spar_Atom_BankAccount_ID = "@par_Atom_BankAccount_ID";
            SQL_Parameter par_Atom_BankAccount_ID = new SQL_Parameter(spar_Atom_BankAccount_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_BankAccount_ID);
            lpar.Add(par_Atom_BankAccount_ID);

            string sql = " select ID from MethodOfPayment_DPI_BAccount where MethodOfPayment_DPI_ID = " + spar_MethodOfPayment_DPI_ID + " and  Atom_BankAccount_ID = " + spar_Atom_BankAccount_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    MethodOfPayment_DPI_BAccount_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {

                    sql = @" insert into  MethodOfPayment_DPI_BAccount (MethodOfPayment_DPI_ID,Atom_BankAccount_ID) values
                                                    (" + spar_MethodOfPayment_DPI_ID + "," + spar_Atom_BankAccount_ID + ")";
                    object oret = null;
                    long MethodOfPayment_DPI_BAccount_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_DPI_BAccount_ID, ref oret, ref Err, "MethodOfPayment_DPI_BAccount"))
                    {
                        MethodOfPayment_DPI_BAccount_ID_v = new long_v(MethodOfPayment_DPI_BAccount_ID);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_MethodOfPayment_DPI_BAccount:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_MethodOfPayment_DPI_BAccount:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
