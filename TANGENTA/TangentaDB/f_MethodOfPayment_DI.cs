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

        public static bool Get(
                              GlobalData.ePaymentType ePaymentType,
                              long_v Atom_BankAccount_ID_v,
                              ref long_v PaymentType_ID_v,
                              ref string_v PaymentType_v,
                              ref long_v MethodOfPayment_DI_BAccount_ID_v,
                              ref long_v MethodOfPayment_DI_ID_v)
        {
            long MethodOfPayment_DI_ID = -1;
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), ref PaymentType_v, ref PaymentType_ID_v))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();


                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PaymentType_ID_v.v);
                lpar.Add(par_PaymentType_ID);



                string sql = " select ID from MethodOfPayment_DI where PaymentType_ID = " + spar_PaymentType_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        MethodOfPayment_DI_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                        if (Atom_BankAccount_ID_v!=null)
                        {
                            return f_MethodOfPayment_DI_BAccount.Get(MethodOfPayment_DI_ID_v.v, Atom_BankAccount_ID_v.v, ref MethodOfPayment_DI_BAccount_ID_v);
                        }
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  MethodOfPayment_DI (PaymentType_ID) values
                                                        (" + spar_PaymentType_ID + ")";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_DI_ID, ref oret, ref Err, "MethodOfPayment_DI"))
                        {
                            MethodOfPayment_DI_ID_v = new long_v(MethodOfPayment_DI_ID);
                            if (Atom_BankAccount_ID_v != null)
                            {
                                return f_MethodOfPayment_DI_BAccount.Get(MethodOfPayment_DI_ID_v.v, Atom_BankAccount_ID_v.v, ref MethodOfPayment_DI_BAccount_ID_v);
                            }
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
                              long_v Atom_BankAccount_ID_v,
                              ref long_v PaymentType_ID_v,
                              ref string_v PaymentType_v,
                              ref long_v MethodOfPayment_DI_BAccount_ID_v,
                              ref long_v MethodOfPayment_DI_ID_v)
        {
            long MethodOfPayment_DI_ID = -1;
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), PaymentType_Name, ref PaymentType_v, ref PaymentType_ID_v))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();



                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PaymentType_ID_v.v);
                lpar.Add(par_PaymentType_ID);



                string sql = " select ID from MethodOfPayment_DI where PaymentType_ID = " + spar_PaymentType_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        MethodOfPayment_DI_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                        if (Atom_BankAccount_ID_v != null)
                        {
                            return f_MethodOfPayment_DI_BAccount.Get(MethodOfPayment_DI_ID_v.v, Atom_BankAccount_ID_v.v, ref MethodOfPayment_DI_BAccount_ID_v);
                        }
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  MethodOfPayment_DI ( PaymentType_ID) values
                                                        ("+ spar_PaymentType_ID + ")";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_DI_ID, ref oret, ref Err, "MethodOfPayment_DI"))
                        {
                            MethodOfPayment_DI_ID_v = new long_v(MethodOfPayment_DI_ID);
                            if (Atom_BankAccount_ID_v != null)
                            {
                                return f_MethodOfPayment_DI_BAccount.Get(MethodOfPayment_DI_ID_v.v, Atom_BankAccount_ID_v.v, ref MethodOfPayment_DI_BAccount_ID_v);
                            }
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
