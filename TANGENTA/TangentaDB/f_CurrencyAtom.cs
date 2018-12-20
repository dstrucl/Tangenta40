#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_Currency
    {
        public static bool Get(ID Currency_ID, ref ID Atom_Currency_ID, Transaction transaction)
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
                    if (Atom_Currency_ID==null)
                    {
                        Atom_Currency_ID = new ID();
                    }
                    Atom_Currency_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {

                    sql = @"insert into Atom_Currency (Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces) select Name,Abbreviation,Symbol,CurrencyCode,DecimalPlaces from Currency where ID = " + Currency_ID.ToString();
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref Atom_Currency_ID, ref Err, "Atom_Currency"))
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
