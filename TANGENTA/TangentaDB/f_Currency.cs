using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Currency
    {
        public class CurrencyInCountry
        {
            public string CountryCode_A3 = null;
            public string Abbreviation = null;
            public string Name = null;
            public string Symbol = null;
            public int CurrencyCode = -1;
            public int DecimalPlaces = 0;
            public long ID = -1;
            public CurrencyInCountry(string xCountryCode_A3,string xAbbreviation, string xName,string xSymbol,int xCurrencyCode, int xDecimalPlaces)
            {
                CountryCode_A3 = xCountryCode_A3;
                Abbreviation = xAbbreviation;
                Name = xName;
                Symbol = xSymbol;
                CurrencyCode = xCurrencyCode;
                DecimalPlaces = xDecimalPlaces;
            }
        }
        public static f_Currency.CurrencyInCountry[] DefaultCurrencyInCountryList = new f_Currency.CurrencyInCountry[] { new CurrencyInCountry("SLO", "EUR","EURO","€",978,2),
                                                                                                                         new CurrencyInCountry("DEU", "EUR","EURO","€",978,2)
                                                                                                                };

        public static bool Get(string CountryCode_A3)
        {
            foreach (CurrencyInCountry cur in DefaultCurrencyInCountryList)
            {

                if (cur.CountryCode_A3.Equals(CountryCode_A3))
                {
                    long Currency_ID = -1;
                    if (Get(cur.Abbreviation,cur.Name, cur.Symbol,cur.CurrencyCode,cur.DecimalPlaces, ref Currency_ID))
                    {
                        cur.ID = Currency_ID;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool Get(string Abbreviation,string Name,string Symbol,int CurrencyCode, int DecimalPlaces, ref long Currency_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_Abbreviation = "@par_Abbreviation";
            SQL_Parameter par_Abbreviation = new SQL_Parameter(spar_Abbreviation, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Abbreviation);
            lpar.Add(par_Abbreviation);

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);


            string spar_Symbol = "@par_Symbol";
            SQL_Parameter par_Symbol = new SQL_Parameter(spar_Symbol, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Symbol);
            lpar.Add(par_Symbol);


            string spar_CurrencyCode = "@par_CurrencyCode";
            SQL_Parameter par_CurrencyCode = new SQL_Parameter(spar_CurrencyCode, SQL_Parameter.eSQL_Parameter.Int, false, CurrencyCode);
            lpar.Add(par_CurrencyCode);

            string spar_DecimalPlaces = "@par_DecimalPlaces";
            SQL_Parameter par_DecimalPlaces = new SQL_Parameter(spar_DecimalPlaces, SQL_Parameter.eSQL_Parameter.Int, false, DecimalPlaces);
            lpar.Add(par_DecimalPlaces);

            string sql = "select ID from Currency where Abbreviation = "+ spar_Abbreviation + " and  Name = " + spar_Name + " and CurrencyCode = " + spar_CurrencyCode + " and DecimalPlaces = " + spar_DecimalPlaces;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Currency_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Currency (Abbreviation,Name,Symbol,CurrencyCode,DecimalPlaces)values(" + spar_Abbreviation + "," + spar_Name + "," + spar_Symbol+ "," + spar_CurrencyCode + "," + spar_DecimalPlaces + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Currency_ID, ref oret, ref Err, "Currency"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Currency:InsertDefault:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Currency:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
