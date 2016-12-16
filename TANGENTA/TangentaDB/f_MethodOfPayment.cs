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
                              long BankAccount_ID,
                              ref long MethodOfPayment_ID,
                              ref string sMethodOfPayment)
        {
            string sPaymentType = null;
            MethodOfPayment_ID = -1;
            sMethodOfPayment = null;
            switch (ePaymentType)
            {
            case GlobalData.ePaymentType.CASH:
                sPaymentType = lngRPM.s_PaymentType_CASH.s;
                break;
            case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                sPaymentType = lngRPM.s_PaymentType_CASH_OR_PAYMENT_CARD.s;
                break;
            case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                sPaymentType = lngRPM.s_PaymentType_BANK_ACCOUNT_TRANSFER.s;
                break;
            case GlobalData.ePaymentType.ALLREADY_PAID:
                sPaymentType = lngRPM.s_PaymentType_ALLREADY_PAID.s;
                break;
            case GlobalData.ePaymentType.PAYMENT_CARD:
                sPaymentType = lngRPM.s_PaymentType_PAYMENT_CARD.s;
                break;
            case GlobalData.ePaymentType.NONE:
                LogFile.Error.Show("ERROR:TangentaDB:f_MethodOfPayment:Get:ePaymentType == GlobalData.ePaymentType.NONE!");
                return false;
            default:
                LogFile.Error.Show("ERROR:TangentaDB:f_MethodOfPayment:Get:ePaymentType == "+ ePaymentType.ToString()+"!");
                return false;

            }

            sMethodOfPayment = sPaymentType;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;
            DataTable dt = new DataTable();

            string scond_PaymentType = " PaymentType is null ";
            string sval_PaymentType = " null ";


            string scond_BankAccount_ID = " BankAccount_ID is null ";
            string sval_BankAccount_ID = " null ";

            string spar_PaymentType = "@par_PaymentType";
            SQL_Parameter par_PaymentType = new SQL_Parameter(spar_PaymentType, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sPaymentType);
            lpar.Add(par_PaymentType);
            scond_PaymentType = " PaymentType = " + spar_PaymentType;
            sval_PaymentType = " " + spar_PaymentType + " ";

            string spar_BankAccount_ID = "@par_BankAccount_ID";
            SQL_Parameter par_BankAccount_ID = new SQL_Parameter(spar_BankAccount_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, BankAccount_ID);
            lpar.Add(par_BankAccount_ID);

            scond_BankAccount_ID = " BankAccount_ID = " + spar_BankAccount_ID;
            sval_BankAccount_ID = " " + spar_BankAccount_ID + " ";

            string sql = " select ID from MethodOfPayment where " + scond_PaymentType + " and " + scond_BankAccount_ID;
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
                                                    (" + sval_PaymentType + ")";
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
