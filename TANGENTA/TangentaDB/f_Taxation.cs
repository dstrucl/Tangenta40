using Country_ISO_3166;
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Taxation
    {
        private static DataTable dtTaxation = null;

        public static bool Get(int Country_num, ref tnr[] tax_rates)
        {
            tax_rates = null;
            Tax_Rates_by_Country_List country_ISO_3166_list = new Tax_Rates_by_Country_List();
            foreach (Tax_Rates_by_Country taxc in country_ISO_3166_list.item)
            {

                if (taxc.Country_Code_ISO_3166 == Country_num)
                {
                    if (taxc.rates != null)
                    {
                        tax_rates = new tnr[taxc.rates.Length];
                        int i = 0;
                        for (i=0;i< tax_rates.Length;i++)
                        {
                            tax_rates[i] = taxc.rates[i].Clone();
                            if (Get(tax_rates[i].Name, tax_rates[i].Rate, ref tax_rates[i].Taxation_ID))
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool Get(string Name,decimal Rate, ref ID Taxation_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //Table Language
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);

            string spar_Rate = "@par_Rate";
            string sval_Rate = "null";
            SQL_Parameter par_Rate = new SQL_Parameter(spar_Rate, SQL_Parameter.eSQL_Parameter.Decimal, false, Rate);
            lpar.Add(par_Rate);
            sval_Rate = spar_Rate;

            string sql = "select ID from Taxation where Name = " + spar_Name + " and Rate = " + sval_Rate;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Taxation_ID==null)
                    {
                        Taxation_ID = new ID();
                    }
                    Taxation_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into Taxation (Name,Rate)values(" + spar_Name + "," + sval_Rate + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Taxation_ID, ref Err, "Taxation"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Taxation:InsertDefault:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Taxation:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static DataTable GetTable(bool breload)
        {
            if (breload)
            {
                if (dtTaxation != null)
                {
                    dtTaxation.Dispose();
                    dtTaxation = null;
                }
            }
            if (dtTaxation!=null)
            {
                return dtTaxation;
            }
            else
            {
                string Err = null;
                dtTaxation = new DataTable();
                string sql = @"select ID,Name,Rate from Taxation";
                if (DBSync.DBSync.ReadDataTable(ref dtTaxation,sql,ref Err))
                {
                    return dtTaxation;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_taxation.cs:GetTable:sql=" + sql + "\r\nErr=" + Err);
                    return null;
                }
            }
        }

        public static bool Get(ID Taxation_ID, ref  string_v Taxation_Name_v, ref decimal_v Taxation_Rate_v)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //Table Language
            string spar_ID = "@par_ID";
            Taxation_Name_v = null;
            Taxation_Rate_v = null;
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, Taxation_ID);
            lpar.Add(par_ID);


            string sql = "select Name,Rate from Taxation where ID = " + spar_ID;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Taxation_Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    Taxation_Rate_v = tf.set_decimal(dt.Rows[0]["Rate"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Taxation:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
