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

        public static bool GetTable(ref DataTable xdtPurchasePrice_Item)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string sql = @"SELECT PurchasePrice_Item.ID as ID,
             PurchasePrice_Item_$_i.UniqueName AS PurchasePrice_Item_$_i_$$UniqueName,
             PurchasePrice_Item_$_i_$_ipg1.Name AS s1_name,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2.Name AS s2_name,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3.Name AS s3_name,
			 s.ID as Stock_ID,
			 s.dQuantity as Stock_dQuantity,
			 s.ExpiryDate as Stock_ExpiryDate,
			 s.ImportTime as Stock_ImportTime,
             PurchasePrice_Item_$_st.Draft AS PurchasePrice_Item_$_st_$$Draft,
             PurchasePrice_Item_$_i_$_u.Name AS PurchasePrice_Item_$_i_$_u_$$Name,
             PurchasePrice_Item_$_i.Code AS PurchasePrice_Item_$_i_$$Code,
             PurchasePrice_Item_$_i_$_exp.ID AS PurchasePrice_Item_$_i_$_exp_$$ID,
             PurchasePrice_Item_$_i.ToOffer AS PurchasePrice_Item_$_i_$$ToOffer,
             PurchasePrice_Item_$_pp.ID AS PurchasePrice_Item_$_pp_$$ID,
             PurchasePrice_Item_$_pp.PurchasePricePerUnit AS PurchasePrice_Item_$_pp_$$PurchasePricePerUnit,
             PurchasePrice_Item_$_pp_$_tax.Name AS PurchasePrice_Item_$_pp_$_tax_$$Name,
             PurchasePrice_Item_$_pp_$_tax.Rate AS PurchasePrice_Item_$_pp_$_tax_$$Rate,
             PurchasePrice_Item_$_pp.PurchasePriceDate AS PurchasePrice_Item_$_pp_$$PurchasePriceDate,
             PurchasePrice_Item_$_pp.Discount AS PurchasePrice_Item_$_pp_$$Discount,
             PurchasePrice_Item_$_pp.PriceWithoutVAT AS PurchasePrice_Item_$_pp_$$PriceWithoutVAT,
             PurchasePrice_Item_$_pp.VATCanNotBeDeducted AS PurchasePrice_Item_$_pp_$$VATCanNotBeDeducted,
             PurchasePrice_Item_$_st.Name AS PurchasePrice_Item_$_st_$$Name,
             PurchasePrice_Item_$_st.StockTake_Date AS PurchasePrice_Item_$_st_$$StockTake_Date,
             PurchasePrice_Item_$_st.StockTakePriceTotal AS PurchasePrice_Item_$_st_$$StockTakePriceTotal,
             PurchasePrice_Item_$_st.StockTakePriceTotalWithVAT AS PurchasePrice_Item_$_st_$$StockTakePriceTotalWithVAT,
             PurchasePrice_Item_$_st_$_ref.ReferenceNote AS PurchasePrice_Item_$_st_$_ref_$$ReferenceNote,
             PurchasePrice_Item_$_st_$_ref.ReferenceDate AS PurchasePrice_Item_$_st_$_ref_$$ReferenceDate,
             PurchasePrice_Item_$_st.Description AS PurchasePrice_Item_$_st_$$Description,
			 PurchasePrice_Item_$_st.Draft as  PurchasePrice_Item_$_st_$$Draft,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Name AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$Name,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Tax_ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Registration_ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$Registration_ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.TaxPayer AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$TaxPayer,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1.Comment AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1_$$Comment,
 
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt.OrganisationTYPE AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt_$$OrganisationTYPE,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg.StreetName AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg.HouseNumber AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg.City AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg_$$City,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg.ZIP AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.Country AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.Country_ISO_3166_a2 AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a2,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.Country_ISO_3166_a3 AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_a3,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.Country_ISO_3166_num AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country_ISO_3166_num,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg.State AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg_$$State,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg.PhoneNumber AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg_$$PhoneNumber,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg.FaxNumber AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg_$$FaxNumber,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg.Email AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg_$$Email,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg.HomePage AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg_$$HomePage,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo.Image_Hash AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo_$$Image_Hash,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo.Image_Data AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo_$$Image_Data,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo.Description AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo_$$Description,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per.Gender AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$$Gender,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn.FirstName AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn_$$FirstName,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln.LastName AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln_$$LastName,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per.DateOfBirth AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$$DateOfBirth,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per.Tax_ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$$Tax_ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_per.Registration_ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_per_$$Registration_ID,
 
             PurchasePrice_Item_$_pp_$_Cur.ID AS PurchasePrice_Item_$_pp_$_Cur_$$ID,
             PurchasePrice_Item_$_pp_$_Cur.Abbreviation AS PurchasePrice_Item_$_pp_$_Cur_$$Abbreviation,
             PurchasePrice_Item_$_pp_$_Cur.Name AS PurchasePrice_Item_$_pp_$_Cur_$$Name,
             PurchasePrice_Item_$_pp_$_Cur.Symbol AS PurchasePrice_Item_$_pp_$_Cur_$$Symbol,
             PurchasePrice_Item_$_pp_$_Cur.CurrencyCode AS PurchasePrice_Item_$_pp_$_Cur_$$CurrencyCode,
             PurchasePrice_Item_$_pp_$_Cur.DecimalPlaces AS PurchasePrice_Item_$_pp_$_Cur_$$DecimalPlaces,
             PurchasePrice_Item_$_st_$_ref_$_refimg.Image_Hash AS PurchasePrice_Item_$_st_$_ref_$_refimg_$$Image_Hash,
             PurchasePrice_Item_$_st_$_ref_$_refimg.Image_Data AS PurchasePrice_Item_$_st_$_ref_$_refimg_$$Image_Data,
 
             PurchasePrice_Item_$_i.Name AS PurchasePrice_Item_$_i_$$Name,
             PurchasePrice_Item_$_i.barcode AS PurchasePrice_Item_$_i_$$barcode,
             PurchasePrice_Item_$_i.Description AS PurchasePrice_Item_$_i_$$Description,
             PurchasePrice_Item_$_i_$_iimg.Image_Hash AS PurchasePrice_Item_$_i_$_iimg_$$Image_Hash,
             PurchasePrice_Item_$_i_$_iimg.Image_Data AS PurchasePrice_Item_$_i_$_iimg_$$Image_Data,
             PurchasePrice_Item_$_i_$_u.Symbol AS PurchasePrice_Item_$_i_$_u_$$Symbol,
             PurchasePrice_Item_$_i_$_u.DecimalPlaces AS PurchasePrice_Item_$_i_$_u_$$DecimalPlaces,
             PurchasePrice_Item_$_i_$_u.StorageOption AS PurchasePrice_Item_$_i_$_u_$$StorageOption,
             PurchasePrice_Item_$_i_$_u.Description AS PurchasePrice_Item_$_i_$_u_$$Description,
			 PurchasePrice_Item_$_i_$_exp.ID AS PurchasePrice_Item_$_i_$_exp_$$ID,
             PurchasePrice_Item_$_i_$_exp.ExpectedShelfLifeInDays AS PurchasePrice_Item_$_i_$_exp_$$ExpectedShelfLifeInDays,
             PurchasePrice_Item_$_i_$_exp.SaleBeforeExpiryDateInDays AS PurchasePrice_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays,
             PurchasePrice_Item_$_i_$_exp.DiscardBeforeExpiryDateInDays AS PurchasePrice_Item_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,
             PurchasePrice_Item_$_i_$_exp.ExpiryDescription AS PurchasePrice_Item_$_i_$_exp_$$ExpiryDescription,
             PurchasePrice_Item_$_i_$_wrty.WarrantyDuration AS PurchasePrice_Item_$_i_$_wrty_$$WarrantyDuration,
             PurchasePrice_Item_$_i_$_wrty.WarrantyDurationType AS PurchasePrice_Item_$_i_$_wrty_$$WarrantyDurationType,
             PurchasePrice_Item_$_i_$_wrty.WarrantyConditions AS PurchasePrice_Item_$_i_$_wrty_$$WarrantyConditions,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt_$$ID,
		    
 
             PurchasePrice_Item_$_i.ID AS PurchasePrice_Item_$_i_$$ID,
             PurchasePrice_Item_$_i_$_u.ID AS PurchasePrice_Item_$_i_$_u_$$ID,
             PurchasePrice_Item_$_i_$_ipg1.ID AS PurchasePrice_Item_$_i_$_ipg1_$$ID,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2.ID AS PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$$ID,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3.ID AS PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3_$$ID,
             PurchasePrice_Item_$_pp_$_tax.ID AS PurchasePrice_Item_$_pp_$_tax_$$ID,
             PurchasePrice_Item_$_st.ID AS PurchasePrice_Item_$_st_$$ID,
             PurchasePrice_Item_$_i_$_iimg.ID AS PurchasePrice_Item_$_i_$_iimg_$$ID,
             PurchasePrice_Item_$_i_$_wrty.ID AS PurchasePrice_Item_$_i_$_wrty_$$ID,
             PurchasePrice_Item_$_st_$_ref.ID AS PurchasePrice_Item_$_st_$_ref_$$ID,
             PurchasePrice_Item_$_st_$_ref_$_refimg.ID AS PurchasePrice_Item_$_st_$_ref_$_refimg_$$ID,
             PurchasePrice_Item_$_st_$_sup.ID AS PurchasePrice_Item_$_st_$_sup_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg_$$ID,
             PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.ID AS PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$ID

 
            FROM PurchasePrice_Item 
            INNER JOIN Item PurchasePrice_Item_$_i ON PurchasePrice_Item.Item_ID = PurchasePrice_Item_$_i.ID 
            INNER JOIN Unit PurchasePrice_Item_$_i_$_u ON PurchasePrice_Item_$_i.Unit_ID = PurchasePrice_Item_$_i_$_u.ID 
            LEFT JOIN Item_ParentGroup1 PurchasePrice_Item_$_i_$_ipg1 ON PurchasePrice_Item_$_i.Item_ParentGroup1_ID = PurchasePrice_Item_$_i_$_ipg1.ID 
            LEFT JOIN Item_ParentGroup2 PurchasePrice_Item_$_i_$_ipg1_$_ipg2 ON PurchasePrice_Item_$_i_$_ipg1.Item_ParentGroup2_ID = PurchasePrice_Item_$_i_$_ipg1_$_ipg2.ID 
            LEFT JOIN Item_ParentGroup3 PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3 ON PurchasePrice_Item_$_i_$_ipg1_$_ipg2.Item_ParentGroup3_ID = PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3.ID 
            LEFT JOIN Item_Image PurchasePrice_Item_$_i_$_iimg ON PurchasePrice_Item_$_i.Item_Image_ID = PurchasePrice_Item_$_i_$_iimg.ID 
            LEFT JOIN Expiry PurchasePrice_Item_$_i_$_exp ON PurchasePrice_Item_$_i.Expiry_ID = PurchasePrice_Item_$_i_$_exp.ID 
            LEFT JOIN Warranty PurchasePrice_Item_$_i_$_wrty ON PurchasePrice_Item_$_i.Warranty_ID = PurchasePrice_Item_$_i_$_wrty.ID 
            INNER JOIN PurchasePrice PurchasePrice_Item_$_pp ON PurchasePrice_Item.PurchasePrice_ID = PurchasePrice_Item_$_pp.ID 
            INNER JOIN Currency PurchasePrice_Item_$_pp_$_Cur ON PurchasePrice_Item_$_pp.Currency_ID = PurchasePrice_Item_$_pp_$_Cur.ID 
            INNER JOIN Taxation PurchasePrice_Item_$_pp_$_tax ON PurchasePrice_Item_$_pp.Taxation_ID = PurchasePrice_Item_$_pp_$_tax.ID 
            INNER JOIN StockTake PurchasePrice_Item_$_st ON PurchasePrice_Item.StockTake_ID = PurchasePrice_Item_$_st.ID 
            INNER JOIN Reference PurchasePrice_Item_$_st_$_ref ON PurchasePrice_Item_$_st.Reference_ID = PurchasePrice_Item_$_st_$_ref.ID 
            LEFT JOIN Reference_Image PurchasePrice_Item_$_st_$_ref_$_refimg ON PurchasePrice_Item_$_st_$_ref.Reference_Image_ID = PurchasePrice_Item_$_st_$_ref_$_refimg.ID 
            INNER JOIN Supplier PurchasePrice_Item_$_st_$_sup ON PurchasePrice_Item_$_st.Supplier_ID = PurchasePrice_Item_$_st_$_sup.ID 
            INNER JOIN Contact PurchasePrice_Item_$_st_$_sup_$_c ON PurchasePrice_Item_$_st_$_sup.Contact_ID = PurchasePrice_Item_$_st_$_sup_$_c.ID 
            LEFT JOIN OrganisationData PurchasePrice_Item_$_st_$_sup_$_c_$_orgd ON PurchasePrice_Item_$_st_$_sup_$_c.OrganisationData_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.ID 
            LEFT JOIN Organisation PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.Organisation_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.ID 
            LEFT JOIN Comment1 PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1 ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org.Comment1_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$_cmt1.ID 
            LEFT JOIN cOrgTYPE PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cOrgTYPE_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_orgt.ID 
            LEFT JOIN cAddress_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cAddress_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.ID 
            LEFT JOIN cStreetName_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cStreetName_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg.ID 
            LEFT JOIN cHouseNumber_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cHouseNumber_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg.ID 
            LEFT JOIN cCity_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cCity_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg.ID 
            LEFT JOIN cZIP_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cZIP_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg.ID 
            LEFT JOIN cCountry_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cCountry_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg.ID 
            LEFT JOIN cState_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg.cState_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg.ID 
            LEFT JOIN cPhoneNumber_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cPhoneNumber_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cphnnorg.ID 
            LEFT JOIN cFaxNumber_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cFaxNumber_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cfaxnorg.ID 
            LEFT JOIN cEmail_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cEmail_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cemailorg.ID 
            LEFT JOIN cHomePage_Org PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.cHomePage_Org_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_chomepgorg.ID 
            LEFT JOIN Logo PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo ON PurchasePrice_Item_$_st_$_sup_$_c_$_orgd.Logo_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_logo.ID 
            LEFT JOIN Person PurchasePrice_Item_$_st_$_sup_$_c_$_per ON PurchasePrice_Item_$_st_$_sup_$_c.Person_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_per.ID 
            LEFT JOIN cFirstName PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn ON PurchasePrice_Item_$_st_$_sup_$_c_$_per.cFirstName_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cfn.ID 
            LEFT JOIN cLastName PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln ON PurchasePrice_Item_$_st_$_sup_$_c_$_per.cLastName_ID = PurchasePrice_Item_$_st_$_sup_$_c_$_per_$_cln.ID 
			left join Stock s on PurchasePrice_Item.ID = s.PurchasePrice_Item_ID";
            string err = null;
            if (xdtPurchasePrice_Item!=null)
            {
                xdtPurchasePrice_Item.Dispose();
                xdtPurchasePrice_Item = null;
            }
            xdtPurchasePrice_Item = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref xdtPurchasePrice_Item, sql, lpar, ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice_Item:GetTable:sql = " + sql + "\r\nErr=" + err);
                return false;
            }
        }
    }
}
