using DBConnectionControl40;
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
        public class TaxationInCountry
        {
            public string CountryCode_A3 = null;
            public string Name = null;
            public decimal Rate = 0;
            public long ID = -1;
            public TaxationInCountry(string xCountryCode_A3,string xName,decimal xRate)
            {
                CountryCode_A3 = xCountryCode_A3;
                Name = xName;
                Rate = xRate;
            }
        }

        public static f_Taxation.TaxationInCountry[] DefaultTaxationInCountryList = new f_Taxation.TaxationInCountry[] { new TaxationInCountry("SLO", "DDV 22%", 22 ),
                                                                                                                         new TaxationInCountry("SLO", "DDV 9,5%", 9.5M),
                                                                                                                         new TaxationInCountry("SLO", "DDV 0%", 0M),
                                                                                                                         new TaxationInCountry("DEU", "MWST 14%", 14M)
                                                                                                                };

        public static bool Get(string CountryCode_A3)
        {
            foreach (TaxationInCountry taxc in DefaultTaxationInCountryList)
            {

                if (taxc.CountryCode_A3.Equals(CountryCode_A3))
                {
                    long Taxation_ID = -1;
                    if (Get(taxc.Name,taxc.Rate,ref Taxation_ID))
                    {
                        taxc.ID = Taxation_ID;
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
        public static bool Get(string Name,decimal Rate, ref long Taxation_ID)
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
                    Taxation_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Taxation (Name,Rate)values(" + spar_Name + "," + sval_Rate + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Taxation_ID, ref oret, ref Err, "Taxation"))
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
    }
}
