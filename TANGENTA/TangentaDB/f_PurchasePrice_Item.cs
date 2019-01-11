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

     

        public static bool GetLastItemPrices(ID Item_ID, ID Currency_ID, ref DataTable dtPurchasePrices, int Limit)
        {
            string Err = null;
            string sql = null;
            if (dtPurchasePrices == null)
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
                    sql = @" SELECT PurchasePrice_Item.ID,
                     PurchasePrice_Item_$_i.ID AS PurchasePrice_Item_$_i_$$ID,
                     PurchasePrice_Item_$_i.UniqueName AS PurchasePrice_Item_$_i_$$UniqueName,
                     PurchasePrice_Item_$_i.Name AS PurchasePrice_Item_$_i_$$Name,
                     PurchasePrice_Item_$_i_$_u.ID AS PurchasePrice_Item_$_i_$_u_$$ID,
                     PurchasePrice_Item_$_i_$_u.Name AS PurchasePrice_Item_$_i_$_u_$$Name,
                     PurchasePrice_Item_$_i_$_u.Symbol AS PurchasePrice_Item_$_i_$_u_$$Symbol,
                     PurchasePrice_Item_$_i_$_u.DecimalPlaces AS PurchasePrice_Item_$_i_$_u_$$DecimalPlaces,
                     PurchasePrice_Item_$_i_$_u.StorageOption AS PurchasePrice_Item_$_i_$_u_$$StorageOption,
                     PurchasePrice_Item_$_i_$_u.Description AS PurchasePrice_Item_$_i_$_u_$$Description,
                     PurchasePrice_Item_$_i.Code AS PurchasePrice_Item_$_i_$$Code,
                     PurchasePrice_Item_$_i.barcode AS PurchasePrice_Item_$_i_$$barcode,
                     PurchasePrice_Item_$_i.Description AS PurchasePrice_Item_$_i_$$Description,
                     PurchasePrice_Item_$_i.ToOffer AS PurchasePrice_Item_$_i_$$ToOffer,
                     PurchasePrice_Item_$_pp.ID AS PurchasePrice_Item_$_pp_$$ID,
                     PurchasePrice_Item_$_pp.PurchasePricePerUnit AS PurchasePricePerUnit,
                     PurchasePrice_Item_$_pp_$_Cur.ID AS PurchasePrice_Item_$_pp_$_Cur_$$ID,
                     PurchasePrice_Item_$_pp_$_Cur.Abbreviation AS PurchasePrice_Item_$_pp_$_Cur_$$Abbreviation,
                     PurchasePrice_Item_$_pp_$_Cur.Name AS PurchasePrice_Item_$_pp_$_Cur_$$Name,
                     PurchasePrice_Item_$_pp_$_Cur.Symbol AS PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                     PurchasePrice_Item_$_pp_$_Cur.CurrencyCode AS PurchasePrice_Item_$_pp_$_Cur_$$CurrencyCode,
                     PurchasePrice_Item_$_pp_$_Cur.DecimalPlaces AS PurchasePrice_Item_$_pp_$_Cur_$$DecimalPlaces,
                     PurchasePrice_Item_$_pp_$_tax.ID AS PurchasePrice_Item_$_pp_$_tax_$$ID,
                     PurchasePrice_Item_$_pp_$_tax.Name AS PurchasePrice_Item_$_pp_$_tax_$$Name,
                     PurchasePrice_Item_$_pp_$_tax.Rate AS PurchasePrice_Item_$_pp_$_tax_$$Rate,
                     PurchasePrice_Item_$_pp.PurchasePriceDate AS PurchasePriceDate,
                     PurchasePrice_Item_$_pp.Discount AS PurchasePrice_Item_$_pp_$$Discount,
                     PurchasePrice_Item_$_pp.PriceWithoutVAT AS PurchasePrice_Item_$_pp_$$PriceWithoutVAT,
                     PurchasePrice_Item_$_pp.VATCanNotBeDeducted AS PurchasePrice_Item_$_pp_$$VATCanNotBeDeducted,
                     PurchasePrice_Item_$_st.Draft AS PurchasePrice_Item_$_st_$$Draft,
                    PurchasePrice_Item_$_st.Name as StockTakeName,
                    PurchasePrice_Item_$_st.StockTake_Date as StockTake_Date,
                    PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Name as  SupplierName
                    FROM PurchasePrice_Item 
                    INNER JOIN Item PurchasePrice_Item_$_i ON PurchasePrice_Item.Item_ID = PurchasePrice_Item_$_i.ID 
                    INNER JOIN Unit PurchasePrice_Item_$_i_$_u ON PurchasePrice_Item_$_i.Unit_ID = PurchasePrice_Item_$_i_$_u.ID 
                    INNER JOIN PurchasePrice PurchasePrice_Item_$_pp ON PurchasePrice_Item.PurchasePrice_ID = PurchasePrice_Item_$_pp.ID 
                    INNER JOIN Currency PurchasePrice_Item_$_pp_$_Cur ON PurchasePrice_Item_$_pp.Currency_ID = PurchasePrice_Item_$_pp_$_Cur.ID 
                    INNER JOIN Taxation PurchasePrice_Item_$_pp_$_tax ON PurchasePrice_Item_$_pp.Taxation_ID = PurchasePrice_Item_$_pp_$_tax.ID 
                    INNER JOIN StockTake PurchasePrice_Item_$_st ON PurchasePrice_Item.StockTake_ID = PurchasePrice_Item_$_st.ID 
                    INNER JOIN Supplier PurchasePrice_Item_$_st_$_sup ON PurchasePrice_Item_$_st.Supplier_ID = PurchasePrice_Item_$_st_$_sup.ID 
                    INNER JOIN Contact PurchasePrice_Item_$_st_$_sup_$_c ON PurchasePrice_Item_$_st_$_sup.Contact_ID = PurchasePrice_Item_$_st_$_sup_$_c.ID 
                    LEFT JOIN OrganisationData PurchasePrice_Item_$_st_$_sup_$_c_$_orgd ON PurchasePrice_Item_$_st_$_sup_$_c.OrganisationData_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.ID 
                    LEFT JOIN Organisation PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.Organisation_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.ID 
                            where PurchasePrice_Item_$_i.ID  = " + spar_Item_ID + " and PurchasePrice_Item_$_pp_$_Cur.ID = " + spar_Currency_ID + " order by PurchasePrice_Item_$_pp.PurchasePriceDate desc limit " + Limit.ToString();
                    break;

                case DBConnection.eDBType.MSSQL:
                    sql = @"select top " + Limit.ToString() + @" PurchasePrice_Item.ID,
                     PurchasePrice_Item_$_i.ID AS PurchasePrice_Item_$_i_$$ID,
                     PurchasePrice_Item_$_i.UniqueName AS PurchasePrice_Item_$_i_$$UniqueName,
                     PurchasePrice_Item_$_i.Name AS PurchasePrice_Item_$_i_$$Name,
                     PurchasePrice_Item_$_i_$_u.ID AS PurchasePrice_Item_$_i_$_u_$$ID,
                     PurchasePrice_Item_$_i_$_u.Name AS PurchasePrice_Item_$_i_$_u_$$Name,
                     PurchasePrice_Item_$_i_$_u.Symbol AS PurchasePrice_Item_$_i_$_u_$$Symbol,
                     PurchasePrice_Item_$_i_$_u.DecimalPlaces AS PurchasePrice_Item_$_i_$_u_$$DecimalPlaces,
                     PurchasePrice_Item_$_i_$_u.StorageOption AS PurchasePrice_Item_$_i_$_u_$$StorageOption,
                     PurchasePrice_Item_$_i_$_u.Description AS PurchasePrice_Item_$_i_$_u_$$Description,
                     PurchasePrice_Item_$_i.Code AS PurchasePrice_Item_$_i_$$Code,
                     PurchasePrice_Item_$_i.barcode AS PurchasePrice_Item_$_i_$$barcode,
                     PurchasePrice_Item_$_i.Description AS PurchasePrice_Item_$_i_$$Description,
                     PurchasePrice_Item_$_i.ToOffer AS PurchasePrice_Item_$_i_$$ToOffer,
                     PurchasePrice_Item_$_pp.ID AS PurchasePrice_Item_$_pp_$$ID,
                     PurchasePrice_Item_$_pp.PurchasePricePerUnit AS PurchasePricePerUnit,
                     PurchasePrice_Item_$_pp_$_Cur.ID AS PurchasePrice_Item_$_pp_$_Cur_$$ID,
                     PurchasePrice_Item_$_pp_$_Cur.Abbreviation AS PurchasePrice_Item_$_pp_$_Cur_$$Abbreviation,
                     PurchasePrice_Item_$_pp_$_Cur.Name AS PurchasePrice_Item_$_pp_$_Cur_$$Name,
                     PurchasePrice_Item_$_pp_$_Cur.Symbol AS PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
                     PurchasePrice_Item_$_pp_$_Cur.CurrencyCode AS PurchasePrice_Item_$_pp_$_Cur_$$CurrencyCode,
                     PurchasePrice_Item_$_pp_$_Cur.DecimalPlaces AS PurchasePrice_Item_$_pp_$_Cur_$$DecimalPlaces,
                     PurchasePrice_Item_$_pp_$_tax.ID AS PurchasePrice_Item_$_pp_$_tax_$$ID,
                     PurchasePrice_Item_$_pp_$_tax.Name AS PurchasePrice_Item_$_pp_$_tax_$$Name,
                     PurchasePrice_Item_$_pp_$_tax.Rate AS PurchasePrice_Item_$_pp_$_tax_$$Rate,
                     PurchasePrice_Item_$_pp.PurchasePriceDate AS PurchasePriceDate,
                     PurchasePrice_Item_$_pp.Discount AS PurchasePrice_Item_$_pp_$$Discount,
                     PurchasePrice_Item_$_pp.PriceWithoutVAT AS PurchasePrice_Item_$_pp_$$PriceWithoutVAT,
                     PurchasePrice_Item_$_pp.VATCanNotBeDeducted AS PurchasePrice_Item_$_pp_$$VATCanNotBeDeducted,
                     PurchasePrice_Item_$_st.Draft AS PurchasePrice_Item_$_st_$$Draft,
                    PurchasePrice_Item_$_st.Name as StockTakeName,
                    PurchasePrice_Item_$_st.StockTake_Date as StockTake_Date,
                    PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Name as  SupplierName
                    FROM PurchasePrice_Item 
                    INNER JOIN Item PurchasePrice_Item_$_i ON PurchasePrice_Item.Item_ID = PurchasePrice_Item_$_i.ID 
                    INNER JOIN Unit PurchasePrice_Item_$_i_$_u ON PurchasePrice_Item_$_i.Unit_ID = PurchasePrice_Item_$_i_$_u.ID 
                    INNER JOIN PurchasePrice PurchasePrice_Item_$_pp ON PurchasePrice_Item.PurchasePrice_ID = PurchasePrice_Item_$_pp.ID 
                    INNER JOIN Currency PurchasePrice_Item_$_pp_$_Cur ON PurchasePrice_Item_$_pp.Currency_ID = PurchasePrice_Item_$_pp_$_Cur.ID 
                    INNER JOIN Taxation PurchasePrice_Item_$_pp_$_tax ON PurchasePrice_Item_$_pp.Taxation_ID = PurchasePrice_Item_$_pp_$_tax.ID 
                    INNER JOIN StockTake PurchasePrice_Item_$_st ON PurchasePrice_Item.StockTake_ID = PurchasePrice_Item_$_st.ID 
                    INNER JOIN Supplier PurchasePrice_Item_$_st_$_sup ON PurchasePrice_Item_$_st.Supplier_ID = PurchasePrice_Item_$_st_$_sup.ID 
                    INNER JOIN Contact PurchasePrice_Item_$_st_$_sup_$_c ON PurchasePrice_Item_$_st_$_sup.Contact_ID = PurchasePrice_Item_$_st_$_sup_$_c.ID 
                    LEFT JOIN OrganisationData PurchasePrice_Item_$_st_$_sup_$_c_$_orgd ON PurchasePrice_Item_$_st_$_sup_$_c.OrganisationData_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.ID 
                    LEFT JOIN Organisation PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.Organisation_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.ID 

                            where PurchasePrice_Item_$_i.ID = " + spar_Item_ID + " and  PurchasePrice_Item_$_pp_$_Cur.ID = " + spar_Currency_ID + " order by PurchasePriceDate desc ";
                    break;

                default:
                    LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:GetLastItemPrices:Not implemented for m_DBType=" + DBSync.DBSync.m_DBType.ToString());
                    return false;
            }
            if (DBSync.DBSync.ReadDataTable(ref dtPurchasePrices, sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:GetLastItemPrices:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetLastItemsPurchasePriceTable(ref DataTable dtItemsPurchasePrice)
        {
            if (dtItemsPurchasePrice!=null)
            {
                dtItemsPurchasePrice.Dispose();
                dtItemsPurchasePrice = null;
            }
            dtItemsPurchasePrice = new DataTable();


            DataColumn dcol_Item_ID = new DataColumn("Item_ID", typeof(long));
            DataColumn dcol_Item_UniqueName = new DataColumn("Item_UniqueName ", typeof(string));
            DataColumn dcol_PurchasePricePerItemWithVAT = new DataColumn("PurchasePricePerItemWithVAT", typeof(decimal));
            DataColumn dcol_PurchasePricePerItemWithoutVAT = new DataColumn("PurchasePricePerItemWithoutVAT", typeof(decimal));
            DataColumn dcol_VAT = new DataColumn("VAT", typeof(decimal));
            DataColumn dcol_Discount = new DataColumn("Discount", typeof(decimal));
            DataColumn dcol_SupplierName = new DataColumn("SupplierName", typeof(string));
            DataColumn dcol_StockTakeTime = new DataColumn("StockTakeTime", typeof(DateTime));
            dtItemsPurchasePrice.Columns.Add(dcol_Item_ID);
            dtItemsPurchasePrice.Columns.Add(dcol_Item_UniqueName);
            dtItemsPurchasePrice.Columns.Add(dcol_PurchasePricePerItemWithVAT);
            dtItemsPurchasePrice.Columns.Add(dcol_PurchasePricePerItemWithoutVAT);
            dtItemsPurchasePrice.Columns.Add(dcol_VAT);
            dtItemsPurchasePrice.Columns.Add(dcol_Discount);
            dtItemsPurchasePrice.Columns.Add(dcol_SupplierName);
            dtItemsPurchasePrice.Columns.Add(dcol_StockTakeTime);

            int iCount = 0;
            DataTable dtItems = new DataTable();
            if (f_Item.GetItemData(ref dtItems, ref iCount))
            {
                if (iCount>0)
                {
                    for (int i = 0; i < iCount; i++)
                    {
                        DataRow dr = dtItemsPurchasePrice.Rows[i];
                        ID item_ID = tf.set_ID(dr["ID"]);
                        if (ID.Validate(item_ID))
                        {
                            DataTable dtPurchasePrices = new DataTable();
                            if (GetLastItemPrices(item_ID, GlobalData.BaseCurrency.ID, ref dtPurchasePrices, 1))
                            {
                                int icountPurchasePrice = dtPurchasePrices.Rows.Count;
                                if (icountPurchasePrice > 0)
                                {
                                    DataRow drPurchasePrices = dtPurchasePrices.Rows[0];
                                    DataRow drItemsPurchasePrice = dtItemsPurchasePrice.NewRow();
                                    drItemsPurchasePrice["Item_ID"] = drPurchasePrices["PurchasePrice_Item_$_i_$$ID"];
                                    drItemsPurchasePrice["Item_UniqueName"] = drPurchasePrices["PurchasePrice_Item_$_i_$$UniqueName"];
                                    drItemsPurchasePrice["PurchasePricePerItemWithVAT"] = drPurchasePrices["PurchasePricePerUnit"];
                                    drItemsPurchasePrice["PurchasePricePerItemWithoutVAT"] = drPurchasePrices["PurchasePrice_Item_$_pp_$$PriceWithoutVAT"];
                                    drItemsPurchasePrice["VAT"] = drPurchasePrices["PurchasePrice_Item_$_pp_$_tax_$$Rate"];
                                    drItemsPurchasePrice["Discount"] = drPurchasePrices["PurchasePrice_Item_$_pp_$$Discount"];
                                    drItemsPurchasePrice["SupplierName"] = drPurchasePrices["SupplierName"];
                                    drItemsPurchasePrice["StockTakeTime"] = drPurchasePrices["StockTake_Date"];
                                    dtPurchasePrices.Rows.Add(drItemsPurchasePrice);
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
