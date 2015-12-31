﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Tangenta
{
    class f_Atom_Currency
    {
        internal static bool Get(long Currency_ID, ref long Atom_Currency_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Atom_Currency.ID
                                                    from Atom_Currency
                                                    inner join Currency on Currency.Name = Atom_Currency.Name
                                                                           and Currency.Abbreviation = Atom_Currency.Abbreviation
                                                                           and Currency.Symbol = Atom_Currency.Symbol
                                                                           and Currency.DecimalPlaces = Atom_Currency.DecimalPlaces                                                   
                                                    where Currency.ID = " + Currency_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Currency_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Currency (Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces) select Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces from Currency where ID = " + Currency_ID.ToString();
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_Currency_ID, ref objretx, ref Err, "Atom_Currency"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Currency:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Currency:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


    }
}
