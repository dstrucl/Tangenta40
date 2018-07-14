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
    public static class f_MethodOfPayment_DPI
    {

        public static bool Get(
                              GlobalData.ePaymentType ePaymentType,
                              ID Atom_BankAccount_ID,
                              ref ID PaymentType_ID,
                              ref string_v PaymentType_v,
                              ref ID MethodOfPayment_DPI_ID)
        {
            if (f_PaymentType.Get(GlobalData.Get_sPaymentType(ePaymentType), ref PaymentType_v, ref PaymentType_ID))
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
                    scond_Atom_BankAccount_ID = " Atom_BankAccount_ID = " + spar_Atom_BankAccount_ID + " ";
                }

                string spar_PaymentType_ID = "@par_PaymentType";
                SQL_Parameter par_PaymentType_ID = new SQL_Parameter(spar_PaymentType_ID,  false, PaymentType_ID);
                lpar.Add(par_PaymentType_ID);

                string sql = " select ID from MethodOfPayment_DPI where  PaymentType_ID = " + spar_PaymentType_ID + " and " + scond_Atom_BankAccount_ID;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (MethodOfPayment_DPI_ID==null)
                        {
                            MethodOfPayment_DPI_ID = new ID();
                        }
                        MethodOfPayment_DPI_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  MethodOfPayment_DPI (PaymentType_ID,Atom_BankAccount_ID) values (" + spar_PaymentType_ID + ","+ sval_Atom_BankAccount_ID + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref MethodOfPayment_DPI_ID,  ref Err, "MethodOfPayment_DPI"))
                        {
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
