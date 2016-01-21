using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
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
