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
using SQLTableControl;
using System.Windows.Forms;
using LanguageControl;
using BlagajnaTableClass;
using DBTypes;

namespace InvoiceDB
{
    public static class f_PurchasePrice_Item
    {
        public static bool GetOneFrom_Item_ID(long Item_ID, ref long_v PurchasePrice_Item_ID)
        {
            string Err = null;
            int iLimit = 1;

            string sql = @"select " + DBSync.DBSync.sTop(iLimit) + @"ppi.ID 
                            from PurchasePrice_Item  ppi
                            inner join PurchasePrice pp on pp.ID = ppi.PurchasePrice_ID
                            where ppi.Item_ID = " + Item_ID.ToString() + " order by pp.PurchasePriceDate desc " + DBSync.DBSync.sLimit(iLimit);
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PurchasePrice_Item_ID == null)
                    {
                        PurchasePrice_Item_ID = new long_v();
                    }
                    PurchasePrice_Item_ID.v = (long)dt.Rows[0]["ID"];
                }
                else
                {
                    PurchasePrice_Item_ID = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PurchasePrice_Item:GetOneFrom_Item_ID:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
