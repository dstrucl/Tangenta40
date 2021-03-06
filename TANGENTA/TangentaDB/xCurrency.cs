﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class xCurrency
    {
        public long ID = -1;
        public string Country= null;
        public string Name = null;
        public string Abbreviation = null;
        public string Symbol = null;
        private int m_CurrencyCode = -1;
        public int DecimalPlaces = -1;

        public int CurrencyCode
        {
            get { return m_CurrencyCode; }
            set { m_CurrencyCode = value;}
        }
        
        public xCurrency()
        {
        }

        public xCurrency(string xCountry, string xName, string xAbbreviation, string xSymbol, short xCode, short xDecimalPlaces)
        {
            Country= xCountry;
            Name = xName;
            Abbreviation = xAbbreviation;
            m_CurrencyCode = xCode;
            Symbol = xSymbol;
            DecimalPlaces = xDecimalPlaces;
        }

        public bool SetCurrency(long currency_id, ref string Err)
        {
            string sql_BaseCurrency = "select Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces from Currency where ID = " + currency_id.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseCurrency, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID = currency_id;
                    Name = (string)dt.Rows[0]["Name"];
                    Abbreviation = (string)dt.Rows[0]["Abbreviation"];
                    Symbol = (string)dt.Rows[0]["Symbol"];
                    m_CurrencyCode = (int)dt.Rows[0]["CurrencyCode"];
                    DecimalPlaces = (int)dt.Rows[0]["DecimalPlaces"];
                    return true;
                }
                else
                {
                    Err = "ERROR:Currency id = " + currency_id.ToString() + " not found in table Currency";
                    return false;
                }
            }
            else
            {
                Err = "ERROR:xCurrency:SetCurrency:Err=" + Err;
                return false;
            }
        }
    }
}
