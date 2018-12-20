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
using CodeTables;
using System.Windows.Forms;
using LanguageControl;
using TangentaTableClass;
using DBTypes;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_PurchasePrice_Item
    {
        public static bool GetOneFrom_Item_ID(ID Item_ID, ref ID PurchasePrice_Item_ID)
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
                        PurchasePrice_Item_ID = new ID();
                    }
                    PurchasePrice_Item_ID.Set(dt.Rows[0]["ID"]);
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

        public static bool Get(ID Item_ID, ID PurchasePrice_ID, ID StockTake_ID, ref ID PurchasePrice_Item_ID, Transaction transaction)
        {
            string Err = null;
            string sql = null;
            PurchasePrice_Item_ID = null;
            sql = "select ID from PurchasePrice_Item where Item_ID = " + Item_ID.ToString() + " and PurchasePrice_ID = " + PurchasePrice_ID.ToString() + " and StockTake_ID = " + StockTake_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PurchasePrice_Item_ID==null)
                    {
                        PurchasePrice_Item_ID = new ID();
                    }
                    PurchasePrice_Item_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into PurchasePrice_Item (Item_ID,PurchasePrice_ID,StockTake_ID) values (" + Item_ID.ToString() + "," + PurchasePrice_ID.ToString() + "," + StockTake_ID.ToString() + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref PurchasePrice_Item_ID, ref Err, "PurchasePrice_Item"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(string PurchasePrice_Item_TableName,ID Item_ID, ID PurchasePrice_ID, ID StockTake_ID, ref ID PurchasePrice_Item_ID, Transaction transaction)
        {
            string Err = null;
            string sql = null;
            PurchasePrice_Item_ID = null;
            sql = "select ID from "+PurchasePrice_Item_TableName+" where Item_ID = " + Item_ID.ToString() + " and PurchasePrice_ID = " + PurchasePrice_ID.ToString() + " and StockTake_ID = " + StockTake_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (PurchasePrice_Item_ID==null)
                    {
                        PurchasePrice_Item_ID = new ID();
                    }
                    PurchasePrice_Item_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into "+ PurchasePrice_Item_TableName + " (Item_ID,PurchasePrice_ID,StockTake_ID) values (" + Item_ID.ToString() + "," + PurchasePrice_ID.ToString() + "," + StockTake_ID.ToString() + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref PurchasePrice_Item_ID, ref Err, PurchasePrice_Item_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetLastItemPrices(ID Item_ID,ID Currency_ID,ref DataTable dtPurchasePrices,int Limit)
        {
            string Err = null;
            string sql = null;
            if (dtPurchasePrices==null)
            {
                dtPurchasePrices = new DataTable();
            }
            else
            {
                dtPurchasePrices.Clear();
                dtPurchasePrices.Columns.Clear();

            }

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Item_ID = "@par_Item_ID";
            SQL_Parameter par_Item_ID = new SQL_Parameter(spar_Item_ID, false, Item_ID);
            lpar.Add(par_Item_ID);

            string spar_Currency_ID = "@par_Currency_ID";
            SQL_Parameter par_Currency_ID = new SQL_Parameter(spar_Currency_ID, false, Currency_ID);
            lpar.Add(par_Currency_ID);

            switch (DBSync.DBSync.m_DBType)
            {
                case DBConnection.eDBType.SQLITE:
                sql = @"select pp.PurchasePricePerUnit as PurchasePricePerUnit,
	                        pp.PurchasePriceDate as PurchasePriceDate,
	                        o.Name as SupplierName,
	                        st.Name as StockTakeName,
	                        st.StockTake_Date as StockTake_Date
                            from PurchasePrice_Item ppi
                            inner join Item i on i.ID = ppi.Item_ID
                            inner join PurchasePrice pp on pp.ID = ppi.PurchasePrice_ID
                            left join StockTake st on st.ID = ppi.StockTake_ID
                            left join Supplier su on su.ID = st.Supplier_ID
                            left join Contact c on c.ID = su.Contact_ID
                            left join OrganisationData od on od.id = c.OrganisationData_ID
                            left  join Organisation o on o.id = od.Organisation_ID
                            where ppi.Item_ID = " + spar_Item_ID + " and pp.Currency_ID = "+ spar_Currency_ID + " order by PurchasePriceDate desc limit " + Limit.ToString();
                    break;

                case DBConnection.eDBType.MSSQL:
                    sql = @"select top "+ Limit.ToString() + @" pp.PurchasePricePerUnit as PurchasePricePerUnit,
	                        pp.PurchasePriceDate as PurchasePriceDate,
	                        o.Name as SupplierName,
	                        st.Name as StockTakeName,
	                        st.StockTake_Date as StockTake_Date
                            from PurchasePrice_Item ppi
                            inner join Item i on i.ID = ppi.Item_ID
                            inner join PurchasePrice pp on pp.ID = ppi.PurchasePrice_ID
                            left join StockTake st on st.ID = ppi.StockTake_ID
                            left join Supplier su on su.ID = st.Supplier_ID
                            left join Contact c on c.ID = su.Contact_ID
                            left join OrganisationData od on od.id = c.OrganisationData_ID
                            left  join Organisation o on o.id = od.Organisation_ID
                            where ppi.Item_ID = " + spar_Item_ID + " and pp.Currency_ID = " + spar_Currency_ID + " order by PurchasePriceDate desc ";
                    break;

                default:
                    LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:GetLastItemPrices:Not implemented for m_DBType="+ DBSync.DBSync.m_DBType.ToString());
                    return false;
            }
            if (DBSync.DBSync.ReadDataTable(ref dtPurchasePrices, sql,lpar,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:GetLastItemPrices:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
