﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tangenta
{
    public class xCurrencyList
    {
        public List<xCurrency> m_CurrencyList = new List<xCurrency>();
        public xCurrencyList()
        {
            m_CurrencyList.Add(new xCurrency("Evropska unija", "EURO", "EUR", "€", 978,2));
            m_CurrencyList.Add(new xCurrency("Združene države", "AMERIŠKI DOLAR", "USD", "$", 840,2));
            m_CurrencyList.Add(new xCurrency("Japonska", "JAPONSKI JEN", "JPY", "¥", 392, 0));
            m_CurrencyList.Add(new xCurrency("Bolgarija", "BOLGARSKI LEV", "BGN", "лв", 975, 2));
            m_CurrencyList.Add(new xCurrency("Češka republika", "ČEŠKA KRONA", "CZK", "Kč", 203, 2));
            m_CurrencyList.Add(new xCurrency("Danska", "DANSKA KRONA", "DKK", "kr", 208, 2));
            m_CurrencyList.Add(new xCurrency("Združeno kraljestvo", "BRITANSKI FUNT", "GBP", "£", 826, 2));
            m_CurrencyList.Add(new xCurrency("Madžarska", "MADŽARSKI FORINT", "HUF", "Ft", 348, 2));
            m_CurrencyList.Add(new xCurrency("Poljska", "POLJSKI ZLOT", "PLN", "zł", 985, 2));
            m_CurrencyList.Add(new xCurrency("Romunija", "NOVI ROMUNSKI LEV", "RON", "lei", 946, 2));
            m_CurrencyList.Add(new xCurrency("Švedska", "ŠVEDSKA KRONA", "SEK", "kr", 752, 2));
            m_CurrencyList.Add(new xCurrency("Švica", "ŠVICARSKI FRANK", "CHF", "CHF", 756, 2));
            m_CurrencyList.Add(new xCurrency("Norveška", "NORVEŠKA KRONA", "NOK", "kr", 578, 2));
            m_CurrencyList.Add(new xCurrency("Hrvaška", "HRVAŠKA KUNA", "HRK", "kn", 191, 2));
            m_CurrencyList.Add(new xCurrency("Ruska federacija", "RUSKI RUBELJ", "RUB", "руб", 643, 2));
            m_CurrencyList.Add(new xCurrency("Turčija", "TURŠKA LIRA", "TRY", "₤", 949, 2));
            m_CurrencyList.Add(new xCurrency("Avstralija", "AVSTRALSKI DOLAR", "AUD", "$", 036, 2));
            m_CurrencyList.Add(new xCurrency("Brazilija", "BRAZILSKI REAL", "BRL", "R$", 986, 2));
            m_CurrencyList.Add(new xCurrency("Kanada", "KANADSKI DOLAR", "CAD", "$", 124, 2));
            m_CurrencyList.Add(new xCurrency("Kitajska", "KITAJSKI JUAN RENMINBI", "CNY", "¥", 156, 2));
            m_CurrencyList.Add(new xCurrency("Hongkong", "HONGKONŠKI DOLAR", "HKD", "$", 344, 2));
            m_CurrencyList.Add(new xCurrency("Indonezija", "INDONEZIJSKA RUPIJA", "IDR", "Rp", 360, 0));
            m_CurrencyList.Add(new xCurrency("Izrael", "NOVI IZRAELSKI ŠEKEL", "ILS", "₪", 376, 2));
            m_CurrencyList.Add(new xCurrency("Indija", "INDIJSKA RUPIJA", "INR", "₹", 356, 2));
            m_CurrencyList.Add(new xCurrency("Koreja, Republika", "JUŽNOKOREJSKI WON", "KRW", "₩", 410, 0));
            m_CurrencyList.Add(new xCurrency("Mehika", "MEHIŠKI PESO", "MXN", "$", 484, 2));
            m_CurrencyList.Add(new xCurrency("Malezija", "MALEZIJSKI RINGGIT", "MYR", "RM", 458, 2));
            m_CurrencyList.Add(new xCurrency("Nova Zelandija", "NOVOZELANDSKI DOLAR", "NZD", "$", 554, 2));
            m_CurrencyList.Add(new xCurrency("Filipini", "FILIPINSKI PESO", "PHP", "₱", 608, 2));
            m_CurrencyList.Add(new xCurrency("Singapur", "SINGAPURSKI DOLAR", "SGD", "$", 702, 2));
            m_CurrencyList.Add(new xCurrency("Tajska", "TAJSKI BAHT", "THB", "฿", 764, 2));
            m_CurrencyList.Add(new xCurrency("Južna Afrika", "JUŽNOAFRIŠKI RAND", "ZAR", "S", 710, 2));
        }
    }

    public class xCurrency
    {
        public long ID = -1; 
        public string State = null;
        public string Name = null;
        public string Abbreviation = null;
        public string Symbol = null;
        public int CurrencyCode = -1;
        public int DecimalPlaces = -1;

        public xCurrency()
        {
        }

        public xCurrency(string xState, string xName, string xAbbreviation, string xSymbol, short xCode, short xDecimalPlaces)
        {
        State = xState;
        Name = xName;
        Abbreviation = xAbbreviation;
        CurrencyCode = xCode;
        Symbol = xSymbol;
        DecimalPlaces = xDecimalPlaces;
        }

        internal bool SetCurrency(long currency_id, ref string Err)
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
                    CurrencyCode = (int)dt.Rows[0]["CurrencyCode"];
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
