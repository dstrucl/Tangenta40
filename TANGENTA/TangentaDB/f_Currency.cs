﻿using Country_ISO_3166;
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
    public static class f_Currency
    {
        private static DataTable dtCurrency = null;

        public static bool Get(int Country_num, ref long Currency_ID)
        {
            Currency_ID = -1;
            ISO_3166_Table iso_3166_Table = new ISO_3166_Table();

            foreach (ISO_3166 iso in iso_3166_Table.item)
            {
                if (iso.State_Number == Country_num)
                {
                    if (Get(iso.Currency_Abbreviation, iso.Currency_Name, iso.Currency_Symbol,iso.Currency_Code,iso.Currency_DecimalPlaces, ref Currency_ID))
                    {
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


     

        public static bool GetCurrencyTable(ref string Err)
        {
            long lRowsCount = fs.GetTableRowsCount("Currency");
            if (lRowsCount > 0)
            {
                return true;
            }
            else
            {
                return fs.Init_Currency_Table(ref Err);
            }
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

            string sql = "select ID,Name,Symbol,CurrencyCode,DecimalPlaces from Currency where Abbreviation = " + spar_Abbreviation;// + " and  Name = " + spar_Name + " and CurrencyCode = " + spar_CurrencyCode + " and DecimalPlaces = " + spar_DecimalPlaces;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Currency_ID = (long)dt.Rows[0]["ID"];
                    object oName = dt.Rows[0]["Name"];
                    string xCurrencyName = null;
                    if (oName is string)
                    {
                        xCurrencyName = (string)oName;
                    }

                    object oSymbol = dt.Rows[0]["Symbol"];
                    string xCurrencySymbol = null;
                    if (oSymbol is string)
                    {
                        xCurrencySymbol = (string)oSymbol;
                    }

                    object oCurrencyCode = dt.Rows[0]["CurrencyCode"];
                    int xCurrencyCode = -1;
                    if (oCurrencyCode is int)
                    {
                        xCurrencyCode = (int)oCurrencyCode;
                    }

                    object oDecimalPlaces = dt.Rows[0]["DecimalPlaces"];
                    int xDecimalPlaces = -1;
                    if (oDecimalPlaces is int)
                    {
                        xDecimalPlaces = (int)oDecimalPlaces;
                    }

                    if ((xCurrencyName!=null)&&(xCurrencySymbol!=null)&&(xCurrencyCode>=0))
                    {
                        if ((xCurrencyName.Equals(Name))&& (xCurrencySymbol.Equals(Symbol))&&(xCurrencyCode== CurrencyCode)&&(xDecimalPlaces== DecimalPlaces))
                        {
                            return true;
                        }
                        else
                        {
                            sql = "update Currency set Name = " + spar_Name + ", Symbol = " + spar_Symbol + ", CurrencyCode = " + spar_CurrencyCode + ",DecimalPlaces = " + spar_DecimalPlaces + " where ID = " + Currency_ID.ToString();
                            object ores = null;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql,lpar,ref ores,ref Err))
                            {
                                LogFile.Error.Show("ERROR:f_Currency:InsertDefault:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Currency:InsertDefault:Err= !((xCurrencyName!=null)&&(xCurrencySymbol!=null)&&(xCurrencyCode>=0))");
                        return false;
                    }


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

        public static bool Get(long Currency_ID, ref string Abbreviation, ref string Name, ref string Symbol, ref int CurrencyCode, ref int DecimalPlaces)
        {
            string sql = "select Abbreviation,Name,Symbol,CurrencyCode,DecimalPlaces from Currency where ID = " + Currency_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql,  ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Abbreviation = null;
                    object oAbbreviation = dt.Rows[0]["Abbreviation"];
                    if (oAbbreviation is string)
                    {
                        Abbreviation = (string)oAbbreviation;
                    }
                    Name = null;
                    object oName = dt.Rows[0]["Name"];
                    if (oName is string)
                    {
                        Name = (string)oName;
                    }
                    Symbol = null;
                    object oSymbol = dt.Rows[0]["Symbol"];
                    if (oSymbol is string)
                    {
                        Symbol = (string)oSymbol;
                    }
                    CurrencyCode = -1;
                    object oCurrencyCode = dt.Rows[0]["CurrencyCode"];
                    if (oCurrencyCode is int)
                    {
                        CurrencyCode = (int)oCurrencyCode;
                    }
                    DecimalPlaces = -1;
                    object oDecimalPlaces = dt.Rows[0]["DecimalPlaces"];
                    if (oDecimalPlaces is int)
                    {
                        DecimalPlaces = (int)oDecimalPlaces;
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Currency.Get(long Currency_ID, ref string Abbreviation, ref string Name, ref string Symbol, ref int CurrencyCode, ref int DecimalPlaces),sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Currency.Get(long Currency_ID, ref string Abbreviation, ref string Name, ref string Symbol, ref int CurrencyCode, ref int DecimalPlaces):sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(long Currency_ID, 
                               ref string_v Abbreviation_v, 
                               ref string_v Name_v, 
                               ref string_v Symbol_v, 
                               ref int_v CurrencyCode_v, 
                               ref int_v DecimalPlaces_v)
        {
            string sql = "select Abbreviation,Name,Symbol,CurrencyCode,DecimalPlaces from Currency where ID = " + Currency_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            Abbreviation_v = null;
            Name_v = null;
            Symbol_v = null;
            CurrencyCode_v = null;
            DecimalPlaces_v = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Abbreviation_v = tf.set_string(dt.Rows[0]["Abbreviation"]);
                    Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    Symbol_v = tf.set_string(dt.Rows[0]["Symbol"]);
                    CurrencyCode_v = tf.set_int(dt.Rows[0]["CurrencyCode"]);
                    DecimalPlaces_v = tf.set_int(dt.Rows[0]["DecimalPlaces"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Currency:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static DataTable GetTable(bool breload)
        {
            if (breload)
            {
                if (dtCurrency != null)
                {
                    dtCurrency.Dispose();
                    dtCurrency = null;
                }
            }
            if (dtCurrency != null)
            {
                return dtCurrency;
            }
            else
            {
                string Err = null;
                dtCurrency = new DataTable();
                string sql = @"select ID,Abbreviation,Name,Symbol,CurrencyCode,DecimalPlaces from Currency";
                if (DBSync.DBSync.ReadDataTable(ref dtCurrency, sql, ref Err))
                {
                    return dtCurrency;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Currency.cs:GetTable:sql=" + sql + "\r\nErr=" + Err);
                    return null;
                }
            }
        }
    }
}
