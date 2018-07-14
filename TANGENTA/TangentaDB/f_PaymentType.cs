using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_PaymentType
    {
        public static bool Get(string identification,string name,ref string_v PaymentType_Name_v,ref ID PaymentType_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Identification = "@par_Identification";
            SQL_Parameter par_Identification = new SQL_Parameter(spar_Identification, SQL_Parameter.eSQL_Parameter.Nvarchar, false, identification);
            lpar.Add(par_Identification);

            string sql = "select ID,Name from PaymentType where Identification = " + spar_Identification;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PaymentType_ID==null)
                    {
                        PaymentType_ID = new ID();
                    }
                    PaymentType_ID.Set(dt.Rows[0]["ID"]);
                    PaymentType_Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    return true;
                }
                else
                {
                    string spar_Name = "@par_Name";
                    SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, name);
                    lpar.Add(par_Name);

                    sql = "insert into PaymentType (Identification,Name) values (" + spar_Identification + ","+ spar_Name + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref PaymentType_ID, ref Err, "PaymentType"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PaymentType:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PaymentType:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(string identification,ref string_v PaymentType_Name_v,  ref ID PaymentType_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Identification = "@par_Identification";
            SQL_Parameter par_Identification = new SQL_Parameter(spar_Identification, SQL_Parameter.eSQL_Parameter.Nvarchar, false, identification);
            lpar.Add(par_Identification);

            string sql = "select ID,Name from PaymentType where Identification = " + spar_Identification;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PaymentType_ID==null)
                    {
                        PaymentType_ID = new ID();
                    }
                    PaymentType_ID.Set(dt.Rows[0]["ID"]);
                    PaymentType_Name_v = tf.set_string(dt.Rows[0]["Name"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PaymentType:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
