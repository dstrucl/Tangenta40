﻿using DBConnectionControl40;
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
    public static class f_MethodOfPayment_DPI
    {

        public static bool Get(
                              GlobalData.ePaymentType ePaymentType,
                              long_v Atom_BankAccount_ID_v,
                              ref long_v PaymentType_ID_v,
                              ref string_v PaymentType_v,
                              ref long_v MethodOfPayment_DPI_ID_v)
        {
            long MethodOfPayment_DPI_ID = -1;
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), ref PaymentType_v, ref PaymentType_ID_v))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string sval_Atom_BankAccount_ID = "null";
                string scond_Atom_BankAccount_ID = " Atom_BankAccount_ID is null ";
                if (Atom_BankAccount_ID_v != null)
                {
                    string spar_Atom_BankAccount_ID = "@par_Atom_BankAccount_ID";
                    SQL_Parameter par_Atom_BankAccount_ID = new SQL_Parameter(spar_Atom_BankAccount_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_BankAccount_ID_v.v);
                    lpar.Add(par_Atom_BankAccount_ID);
                    sval_Atom_BankAccount_ID = spar_Atom_BankAccount_ID;
                    scond_Atom_BankAccount_ID = " Atom_BankAccount_ID = " + spar_Atom_BankAccount_ID + " ";
                }

                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PaymentType_ID_v.v);
                lpar.Add(par_PaymentType_ID);

                string sql = " select ID from MethodOfPayment_DPI where  PaymentType_ID = " + spar_PaymentType_ID + " and " + scond_Atom_BankAccount_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        MethodOfPayment_DPI_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  MethodOfPayment_DPI (PaymentType_ID,Atom_BankAccount_ID) values (" + spar_PaymentType_ID + ","+ sval_Atom_BankAccount_ID + ")";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_DPI_ID, ref oret, ref Err, "MethodOfPayment_DPI"))
                        {
                            MethodOfPayment_DPI_ID_v = new long_v(MethodOfPayment_DPI_ID);
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_MethodOfPayment_DPI:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_MethodOfPayment_DPI:Get:sql=" + sql + "\r\nErr=" + Err);
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
