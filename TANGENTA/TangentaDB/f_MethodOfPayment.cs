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
    public static class f_MethodOfPayment
    {

        public static bool Get(GlobalData.ePaymentType ePaymentType,
                              long_v BankAccount_ID_v,
                              ref long MethodOfPayment_ID)
        {
            string sPaymentType = null;
            MethodOfPayment_ID = -1;

            sPaymentType = GlobalData.Get_sPaymentType(ePaymentType);


            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;
            DataTable dt = new DataTable();

            string scond_PaymentType = " PaymentType is null ";
            string sval_PaymentType = " null ";


            string scond_Atom_BankAccount_ID = " Atom_BankAccount_ID is null ";
            string sval_Atom_BankAccount_ID = " null ";

            string spar_PaymentType = "@par_PaymentType";
            SQL_Parameter par_PaymentType = new SQL_Parameter(spar_PaymentType, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sPaymentType);
            lpar.Add(par_PaymentType);
            scond_PaymentType = " PaymentType = " + spar_PaymentType;
            sval_PaymentType = " " + spar_PaymentType + " ";

            string spar_Atom_BankAccount_ID = "@par_Atom_BankAccount_ID";
            if (BankAccount_ID_v != null)
            {
                SQL_Parameter par_Atom_BankAccount_ID = new SQL_Parameter(spar_Atom_BankAccount_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, BankAccount_ID_v.v);
                lpar.Add(par_Atom_BankAccount_ID);
                scond_Atom_BankAccount_ID = " Atom_BankAccount_ID = " + spar_Atom_BankAccount_ID;
                sval_Atom_BankAccount_ID = " " + spar_Atom_BankAccount_ID + " ";
            }


            string sql = " select ID from MethodOfPayment where " + scond_PaymentType + " and " + scond_Atom_BankAccount_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    MethodOfPayment_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {

                    sql = @" insert into  MethodOfPayment (PaymentType,Atom_BankAccount_ID) values
                                                    (" + sval_PaymentType +","+ sval_Atom_BankAccount_ID + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_ID, ref oret, ref Err, "MethodOfPayment"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_MethodOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_MethodOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
