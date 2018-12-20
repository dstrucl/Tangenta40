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
    public static class f_MethodOfPayment_DI
    {

        public static bool Get(GlobalData.ePaymentType ePaymentType,
                              ID Atom_BankAccount_ID,
                              ref ID PaymentType_ID,
                              ref string_v PaymentType_v,
                              ref ID MethodOfPayment_DI_ID,
                              Transaction transaction)
        {
            MethodOfPayment_DI_ID = null;
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), ref PaymentType_v, ref PaymentType_ID))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string sval_Atom_BankAccount_ID = "null";
                string scond_Atom_BankAccount_ID = " Atom_BankAccount_ID is null ";
                if (Atom_BankAccount_ID != null)
                {
                    string spar_Atom_BankAccount_ID = "@par_Atom_BankAccount_ID";
                    SQL_Parameter par_Atom_BankAccount_ID = new SQL_Parameter(spar_Atom_BankAccount_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_BankAccount_ID);
                    lpar.Add(par_Atom_BankAccount_ID);
                    sval_Atom_BankAccount_ID = spar_Atom_BankAccount_ID;
                    scond_Atom_BankAccount_ID = " Atom_BankAccount_ID = " + spar_Atom_BankAccount_ID + " ";
                }

                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID, false, PaymentType_ID);
                lpar.Add(par_PaymentType_ID);



                string sql = " select ID from MethodOfPayment_DI where PaymentType_ID = " + spar_PaymentType_ID + " and " + scond_Atom_BankAccount_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        MethodOfPayment_DI_ID = tf.set_ID(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @" insert into  MethodOfPayment_DI (PaymentType_ID,Atom_BankAccount_ID) values
                                                        (" + spar_PaymentType_ID + ","+ sval_Atom_BankAccount_ID + ")";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref MethodOfPayment_DI_ID,  ref Err, "MethodOfPayment_DI"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_MethodOfPayment_DI:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_MethodOfPayment_DI:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Get(
                              GlobalData.ePaymentType ePaymentType,
                              string PaymentType_Name,
                              ID Atom_BankAccount_ID,
                              ref ID PaymentType_ID,
                              ref string_v PaymentType_v,
                              ref ID MethodOfPayment_DI_BAccount_ID,
                              ref ID MethodOfPayment_DI_ID,
                              Transaction transaction)
        {
            MethodOfPayment_DI_ID = null;
            string transaction_MethodOfPayment_DI_Set_id = null;
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), PaymentType_Name, ref PaymentType_v, ref PaymentType_ID,transaction))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string sval_Atom_BankAccount_ID = "null";
                string scond_Atom_BankAccount_ID = " Atom_BankAccount_ID is null ";
                if (ID.Validate(Atom_BankAccount_ID))
                {
                    string spar_Atom_BankAccount_ID = "@par_Atom_BankAccount_ID";
                    SQL_Parameter par_Atom_BankAccount_ID = new SQL_Parameter(spar_Atom_BankAccount_ID, false, Atom_BankAccount_ID);
                    lpar.Add(par_Atom_BankAccount_ID);
                    sval_Atom_BankAccount_ID = spar_Atom_BankAccount_ID;
                    scond_Atom_BankAccount_ID = " Atom_BankAccount_ID = " +spar_Atom_BankAccount_ID+" ";
                }
                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID, false, PaymentType_ID);
                lpar.Add(par_PaymentType_ID);



                string sql = " select ID from MethodOfPayment_DI where PaymentType_ID = " + spar_PaymentType_ID+ " and "+scond_Atom_BankAccount_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        MethodOfPayment_DI_ID = tf.set_ID(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  MethodOfPayment_DI ( PaymentType_ID,Atom_BankAccount_ID) values
                                                        (" + spar_PaymentType_ID + ","+ sval_Atom_BankAccount_ID + ")";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref MethodOfPayment_DI_ID,  ref Err, "MethodOfPayment_DI"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_MethodOfPayment_DI:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_MethodOfPayment_DI:Get:sql=" + sql + "\r\nErr=" + Err);
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
