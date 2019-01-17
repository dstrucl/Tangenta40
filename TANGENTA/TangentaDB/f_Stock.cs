﻿using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TangentaDB
{
    public static class f_Stock
    {
        public static bool Add(ID xAtom_WorkPeriod_ID,DateTime tImportTime,decimal dQuantity,DateTime_v tExpiry_v,ID PurchasePrice_Item_ID,ID Stock_AddressLevel1_ID,string Description, ref ID Stock_ID, Transaction transaction)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_ImportTime = "@par_ImportTime";
            SQL_Parameter par_ImportTime = new SQL_Parameter(spar_ImportTime, SQL_Parameter.eSQL_Parameter.Datetime, false, tImportTime);
            lpar.Add(par_ImportTime);

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity);
            lpar.Add(par_dQuantity);

            string spar_tExpiry = "null";
            if (tExpiry_v != null)
            {
                spar_tExpiry = "@par_tExpiry";
                SQL_Parameter par_tExpiry = new SQL_Parameter(spar_tExpiry, SQL_Parameter.eSQL_Parameter.Datetime, false, tExpiry_v.v);
                lpar.Add(par_tExpiry);
            }

            string spar_PurchasePrice_Item_ID = "@par_PurchasePrice_Item_ID";
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, false, PurchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

            string spar_Stock_AddressLevel1_ID = "null";
            if (ID.Validate(Stock_AddressLevel1_ID))
            {
                spar_Stock_AddressLevel1_ID = "@par_Stock_AddressLevel1_ID";
                SQL_Parameter par_Stock_AddressLevel1_ID = new SQL_Parameter(spar_Stock_AddressLevel1_ID, false, Stock_AddressLevel1_ID);
                lpar.Add(par_Stock_AddressLevel1_ID);
            }

            string spar_Description = "null";
            if (Description != null)
            {
                if (Description.Length > 0)
                {
                    spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                }
            }
            string sql = "insert into Stock (ImportTime,dQuantity,ExpiryDate,PurchasePrice_Item_ID,Stock_AddressLevel1_ID,description)values(" 
                         + spar_ImportTime 
                         + "," + spar_dQuantity 
                         + "," + spar_tExpiry
                         + "," + spar_PurchasePrice_Item_ID
                         + "," + spar_Stock_AddressLevel1_ID
                         + "," + spar_Description
                         + ")";
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Stock_ID,  ref Err, "Stock"))
            {
                ID JOURNAL_Stock_ID_v = null;
                if (f_JOURNAL_Stock.Get(Stock_ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data, xAtom_WorkPeriod_ID,DateTime.Now, dQuantity, ref JOURNAL_Stock_ID_v, transaction))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Add:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

       
        public static bool GeStockTakeItems(ref DataTable dt_Stock_Of_Current_StockTake,ref Doc_ShopC_Item[] array_Doc_ShopC_Item, ID StockTake_ID)
        {
            DataTable dt_dQuantity = new DataTable();

            DataTable dt_DocInvoice_ShopC_Item_of_StockTake = new DataTable();
            DataTable dt_DocProformaInvoice_ShopC_Item_of_StockTake = new DataTable();
            string Err = null;
            array_Doc_ShopC_Item = null;
            string sql = @"select i.UniqueName,
                                  s.dQuantity,
                                  s.ImportTime,
                                  s.ExpiryDate,
                                  pp.PurchasePricePerUnit,
                                  cur.Symbol,
                                  org.Name as Supplier,
                                  t.Name as TaxationName,
                                  s.Description,
                                  ctrorg.Name as TruckingOrganisation,
                                  org.Tax_ID as Supplier_Tax_ID,
                                  st.StockTakePriceTotal,
                                  st.Draft,
                                  tr.TruckingCost,
                                  tr.Customs,                                  
                                  st.Name as StockTake_Name, 
                                  u.Name as UnitName,
                                  u.symbol as UnitSymbol,
                                  u.DecimalPlaces as UnitDecimalPlaces,
                                  u.StorageOption as UnitStorageOption,
                                  pp.Discount,
                                  pp.PriceWithoutVAT,
                                  pp.VATCanNotBeDeducted,
                                  t.Rate as TaxationRate,
                                  s.ID as Stock_ID,
                                  s.PurchasePrice_Item_ID,
                                  ppi.PurchasePrice_ID,
                                  i.ID as Item_ID,
                                  pp.Currency_ID, 
                                  pp.Taxation_ID
                           from Stock s
                           inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and StockTake_ID = " + StockTake_ID.ToString()+ @"
                           inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                           inner join Currency cur on pp.Currency_ID = cur.ID
                           inner join Taxation t on pp.Taxation_ID = t.ID
                           inner join Item i on ppi.Item_ID = i.ID
                           inner join Unit u on i.Unit_ID = u.ID
                           inner join StockTake st on ppi.StockTake_ID = st.ID 
                           left join  Supplier sp on st.Supplier_ID = sp.ID
                           left join  Contact c on sp.Contact_ID = c.ID
                           left join  OrganisationData orgd on c.OrganisationData_ID = orgd.ID
                           left join  Organisation org on orgd.Organisation_ID = org.ID
                           left join  Trucking tr on st.Trucking_ID = tr.ID
                           left join  Contact ctr on tr.Contact_ID = ctr.ID
                           left join  OrganisationData ctrorgd on ctr.OrganisationData_ID = ctrorgd.ID
                           left join  Organisation ctrorg on ctrorgd.Organisation_ID = ctrorg.ID
                          ";

            if (dt_Stock_Of_Current_StockTake == null)
            {
                dt_Stock_Of_Current_StockTake = new DataTable();
            }
            dt_Stock_Of_Current_StockTake.Rows.Clear();
            dt_Stock_Of_Current_StockTake.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Stock_Of_Current_StockTake, sql, ref Err))
            {
                DataColumn dcol_InitialQuantity = new DataColumn("dInitialQuantity", typeof(decimal));
                dt_Stock_Of_Current_StockTake.Columns.Add(dcol_InitialQuantity);
                foreach (DataRow dr in dt_Stock_Of_Current_StockTake.Rows)
                {
                    long stock_id = (long)dr["stock_id"];
                    if ((DBSync.DBSync.m_DBType == DBConnection.eDBType.MSSQL))
                    {
                        sql = "select top 1 dQuantity from Journal_Stock where Stock_ID = " + stock_id.ToString() + " and ((Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data.ToString() + ") OR (Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed + ")) order by EventTime desc";
                    }
                    else
                    {
                        sql = "select dQuantity from Journal_Stock where Stock_ID = " + stock_id.ToString() + " and ((Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data.ToString() + ") OR (Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed + ")) order by EventTime desc limit 1";
                    }
                    dt_dQuantity.Rows.Clear();
                    dt_dQuantity.Columns.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt_dQuantity,sql,ref Err))
                    {
                        decimal dInitialQuantity = 0;
                        if (dt_dQuantity.Rows.Count>0)
                        {
                            dInitialQuantity = (decimal)dt_dQuantity.Rows[0]["dQuantity"];
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:No initial quantity for Stock_ID = "+ stock_id.ToString() + " in JOURNAL_STOCK!");
                        }
                        dr[dcol_InitialQuantity] = dInitialQuantity;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                int iCount = dt_Stock_Of_Current_StockTake.Rows.Count;
                if (iCount > 0)
                {
                    array_Doc_ShopC_Item = new Doc_ShopC_Item[iCount];
                    sql = @"select  
                                    di.Draft,
                                    di.DraftNumber,
                                    di.FinancialYear,
                                    di.NumberInFinancialYear,
                                    discis.Stock_ID,
                                    disci.DocInvoice_ID,
                                    disci.ID
                            from DocInvoice_ShopC_Item disci
							inner join DocInvoice_ShopC_Item_Source discis on discis.DocInvoice_ShopC_Item_ID = disci.ID
                            inner join  DocInvoice di on disci.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice jdi on jdi.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice_Type jdit on jdi.JOURNAL_DocInvoice_Type_ID = jdit.ID and jdit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID
                            left join  ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on discis.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                    dt_DocInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                    {
                        sql = @"select  
                                    dpi.Draft,
                                    dpi.DraftNumber,
                                    dpi.FinancialYear,
                                    dpi.NumberInFinancialYear,
                                    dpiscis.Stock_ID,
                                    dpisci.DocProformaInvoice_ID,
                                    dpisci.ID
                            from DocProformaInvoice_ShopC_Item dpisci
                            inner join  DocProformaInvoice_ShopC_Item_Source dpiscis on dpiscis.DocProformaInvoice_ShopC_Item_ID = dpisci.ID
                            inner join  DocProformaInvoice dpi on dpisci.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice jdpi on jdpi.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice_Type jdpit on jdpi.JOURNAL_DocProformaInvoice_Type_ID = jdpit.ID and jdpit.ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdpi.Atom_WorkPeriod_ID = awp.ID
                            left join  ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on dpiscis.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                        dt_DocProformaInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt_DocProformaInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                        {

                            for (int i=0;i<iCount;i++)
                            {
                                ID xstock_id = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[i]["Stock_ID"]);
                                DataRow[] drs_DocInvoice = dt_DocInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());
                                DataRow[] drs_DocProformaInvoice = dt_DocProformaInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());

                                int iCount1 = drs_DocInvoice.Length;
                                int iCount2 = drs_DocProformaInvoice.Length;
                                if (iCount1 + iCount2 > 0)
                                {
                                    //array_Doc_ShopC_Item[i] = new Doc_ShopC_Item(xstock_id,
                                    //                                             drs_DocInvoice,
                                    //                                             drs_DocProformaInvoice);
                                }
                                else
                                {
                                    array_Doc_ShopC_Item[i] = null;
                                }
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    array_Doc_ShopC_Item = null;
                    return true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
            return false;
            }
        }

        public static bool GeStockTakeItems(ref DataTable dt_Stock_Of_Current_StockTake, ref Consumption_ShopC_Item[] array_Doc_ShopC_Item, ID StockTake_ID)
        {
            DataTable dt_dQuantity = new DataTable();

            DataTable dt_DocInvoice_ShopC_Item_of_StockTake = new DataTable();
            DataTable dt_DocProformaInvoice_ShopC_Item_of_StockTake = new DataTable();
            string Err = null;
            array_Doc_ShopC_Item = null;
            string sql = @"select i.UniqueName,
                                  s.dQuantity,
                                  s.ImportTime,
                                  s.ExpiryDate,
                                  pp.PurchasePricePerUnit,
                                  cur.Symbol,
                                  org.Name as Supplier,
                                  t.Name as TaxationName,
                                  s.Description,
                                  ctrorg.Name as TruckingOrganisation,
                                  org.Tax_ID as Supplier_Tax_ID,
                                  st.StockTakePriceTotal,
                                  st.Draft,
                                  tr.TruckingCost,
                                  tr.Customs,                                  
                                  st.Name as StockTake_Name, 
                                  u.Name as UnitName,
                                  u.symbol as UnitSymbol,
                                  u.DecimalPlaces as UnitDecimalPlaces,
                                  u.StorageOption as UnitStorageOption,
                                  pp.Discount,
                                  pp.PriceWithoutVAT,
                                  pp.VATCanNotBeDeducted,
                                  t.Rate as TaxationRate,
                                  s.ID as Stock_ID,
                                  s.PurchasePrice_Item_ID,
                                  ppi.PurchasePrice_ID,
                                  i.ID as Item_ID,
                                  pp.Currency_ID, 
                                  pp.Taxation_ID
                           from Stock s
                           inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and StockTake_ID = " + StockTake_ID.ToString() + @"
                           inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                           inner join Currency cur on pp.Currency_ID = cur.ID
                           inner join Taxation t on pp.Taxation_ID = t.ID
                           inner join Item i on ppi.Item_ID = i.ID
                           inner join Unit u on i.Unit_ID = u.ID
                           inner join StockTake st on ppi.StockTake_ID = st.ID 
                           left join  Supplier sp on st.Supplier_ID = sp.ID
                           left join  Contact c on sp.Contact_ID = c.ID
                           left join  OrganisationData orgd on c.OrganisationData_ID = orgd.ID
                           left join  Organisation org on orgd.Organisation_ID = org.ID
                           left join  Trucking tr on st.Trucking_ID = tr.ID
                           left join  Contact ctr on tr.Contact_ID = ctr.ID
                           left join  OrganisationData ctrorgd on ctr.OrganisationData_ID = ctrorgd.ID
                           left join  Organisation ctrorg on ctrorgd.Organisation_ID = ctrorg.ID
                          ";

            if (dt_Stock_Of_Current_StockTake == null)
            {
                dt_Stock_Of_Current_StockTake = new DataTable();
            }
            dt_Stock_Of_Current_StockTake.Rows.Clear();
            dt_Stock_Of_Current_StockTake.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Stock_Of_Current_StockTake, sql, ref Err))
            {
                DataColumn dcol_InitialQuantity = new DataColumn("dInitialQuantity", typeof(decimal));
                dt_Stock_Of_Current_StockTake.Columns.Add(dcol_InitialQuantity);
                foreach (DataRow dr in dt_Stock_Of_Current_StockTake.Rows)
                {
                    long stock_id = (long)dr["stock_id"];
                    if ((DBSync.DBSync.m_DBType == DBConnection.eDBType.MSSQL))
                    {
                        sql = "select top 1 dQuantity from Journal_Stock where Stock_ID = " + stock_id.ToString() + " and ((Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data.ToString() + ") OR (Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed + ")) order by EventTime desc";
                    }
                    else
                    {
                        sql = "select dQuantity from Journal_Stock where Stock_ID = " + stock_id.ToString() + " and ((Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data.ToString() + ") OR (Journal_Stock_Type_ID = " + f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed + ")) order by EventTime desc limit 1";
                    }
                    dt_dQuantity.Rows.Clear();
                    dt_dQuantity.Columns.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt_dQuantity, sql, ref Err))
                    {
                        decimal dInitialQuantity = 0;
                        if (dt_dQuantity.Rows.Count > 0)
                        {
                            dInitialQuantity = (decimal)dt_dQuantity.Rows[0]["dQuantity"];
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:No initial quantity for Stock_ID = " + stock_id.ToString() + " in JOURNAL_STOCK!");
                        }
                        dr[dcol_InitialQuantity] = dInitialQuantity;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }

                int iCount = dt_Stock_Of_Current_StockTake.Rows.Count;
                if (iCount > 0)
                {
                    array_Doc_ShopC_Item = new Consumption_ShopC_Item[iCount];
                    sql = @"select  
                                    di.Draft,
                                    di.DraftNumber,
                                    di.FinancialYear,
                                    di.NumberInFinancialYear,
                                    discis.Stock_ID,
                                    disci.DocInvoice_ID,
                                    disci.ID
                            from DocInvoice_ShopC_Item disci
							inner join DocInvoice_ShopC_Item_Source discis on discis.DocInvoice_ShopC_Item_ID = disci.ID
                            inner join  DocInvoice di on disci.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice jdi on jdi.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice_Type jdit on jdi.JOURNAL_DocInvoice_Type_ID = jdit.ID and jdit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID
                            left join  ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on discis.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                    dt_DocInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                    {
                        sql = @"select  
                                    dpi.Draft,
                                    dpi.DraftNumber,
                                    dpi.FinancialYear,
                                    dpi.NumberInFinancialYear,
                                    dpiscis.Stock_ID,
                                    dpisci.DocProformaInvoice_ID,
                                    dpisci.ID
                            from DocProformaInvoice_ShopC_Item dpisci
                            inner join  DocProformaInvoice_ShopC_Item_Source dpiscis on dpiscis.DocProformaInvoice_ShopC_Item_ID = dpisci.ID
                            inner join  DocProformaInvoice dpi on dpisci.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice jdpi on jdpi.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice_Type jdpit on jdpi.JOURNAL_DocProformaInvoice_Type_ID = jdpit.ID and jdpit.ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdpi.Atom_WorkPeriod_ID = awp.ID
                            left join  ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on dpiscis.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                        dt_DocProformaInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt_DocProformaInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                        {

                            for (int i = 0; i < iCount; i++)
                            {
                                ID xstock_id = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[i]["Stock_ID"]);
                                DataRow[] drs_DocInvoice = dt_DocInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());
                                DataRow[] drs_DocProformaInvoice = dt_DocProformaInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());

                                int iCount1 = drs_DocInvoice.Length;
                                int iCount2 = drs_DocProformaInvoice.Length;
                                if (iCount1 + iCount2 > 0)
                                {
                                    //array_Doc_ShopC_Item[i] = new Doc_ShopC_Item(xstock_id,
                                    //                                             drs_DocInvoice,
                                    //                                             drs_DocProformaInvoice);
                                }
                                else
                                {
                                    array_Doc_ShopC_Item[i] = null;
                                }
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    array_Doc_ShopC_Item = null;
                    return true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:Get_OfStockTake:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }



        internal static bool GetQuantity(ID stock_ID, ref decimal_v dQuantityInStock_v, Transaction transaction)
        {
            dQuantityInStock_v = null;
            string sql = @"select dQuantity                                
                           from Stock  where ID = " + stock_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    dQuantityInStock_v = tf.set_decimal(dt.Rows[0]["dQuantity"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.cs:GetQuantity:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool UpdateQuantity(ID stock_ID, decimal xdQuantity,Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, xdQuantity);
            lpar.Add(par_dQuantity);

            string sql = "update Stock set dQuantity = " + spar_dQuantity
                            + " where ID = " + stock_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:UpdateQuantity:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Remove(ID Stock_ID, ID StockTake_ID, Transaction transaction)
        {
                string Err = null;
            string sql = @"
                         delete from JOURNAL_Stock where Stock_ID  =" + Stock_ID.ToString() + @";
                         delete from Stock 
                         where ID in (select s.ID from Stock s
                                     inner join PurchasePrice_Item ppi on  s.PurchasePrice_Item_ID = ppi.ID
                                     where ppi.StockTake_ID = " + StockTake_ID.ToString() + " and s.ID =" + Stock_ID.ToString()+")";
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Remove:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Update(ID xAtom_WorkPeriod_ID,
                                  ID currentStock_ID, 
                                  DateTime tImportTime, 
                                  decimal dQuantity, 
                                  DateTime_v tExpiry_v, 
                                  ID PurchasePrice_Item_ID,
                                  ID Stock_AddressLevel1_ID, 
                                  string Description,
                                  Transaction transaction)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_ImportTime = "@par_ImportTime";
            SQL_Parameter par_ImportTime = new SQL_Parameter(spar_ImportTime, SQL_Parameter.eSQL_Parameter.Datetime, false, tImportTime);
            lpar.Add(par_ImportTime);

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity);
            lpar.Add(par_dQuantity);

            string spar_tExpiry = "null";
            if (tExpiry_v != null)
            {
                spar_tExpiry = "@par_tExpiry";
                SQL_Parameter par_tExpiry = new SQL_Parameter(spar_tExpiry, SQL_Parameter.eSQL_Parameter.Datetime, false, tExpiry_v.v);
                lpar.Add(par_tExpiry);
            }

            string spar_PurchasePrice_Item_ID = "@par_PurchasePrice_Item_ID";
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, false, PurchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

            string spar_Stock_AddressLevel1_ID = "null";
            if (ID.Validate(Stock_AddressLevel1_ID))
            {
                spar_Stock_AddressLevel1_ID = "@par_Stock_AddressLevel1_ID";
                SQL_Parameter par_Stock_AddressLevel1_ID = new SQL_Parameter(spar_Stock_AddressLevel1_ID, false, Stock_AddressLevel1_ID);
                lpar.Add(par_Stock_AddressLevel1_ID);
            }

            string spar_Description = "null";
            if (Description != null)
            {
                if (Description.Length > 0)
                {
                    spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                }
            }
            string sql = "Update Stock set ImportTime = " + spar_ImportTime
                            + ",dQuantity = " + spar_dQuantity
                            + ",ExpiryDate = " + spar_tExpiry
                            + ",PurchasePrice_Item_ID = " + spar_PurchasePrice_Item_ID
                            + ",Stock_AddressLevel1_ID = " + spar_Stock_AddressLevel1_ID
                            + ",description = " + spar_Description
                            + " where ID = " + currentStock_ID.ToString();

            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar, ref Err))
            {
                ID JOURNAL_Stock_ID = null;
                if (f_JOURNAL_Stock.Get(currentStock_ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed, xAtom_WorkPeriod_ID, DateTime.Now, dQuantity, ref JOURNAL_Stock_ID, transaction))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetItemInStock(ID Item_ID,ref DataTable dt_ShopC_Item_In_Stock)
        {
            string Err = null;
            if (dt_ShopC_Item_In_Stock == null)
            {
                dt_ShopC_Item_In_Stock = new DataTable();
            }
            else
            {
                dt_ShopC_Item_In_Stock.Dispose();
                dt_ShopC_Item_In_Stock = new DataTable();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Item_ID = "@par_Item_ID";
            SQL_Parameter par_Item_ID = new SQL_Parameter(spar_Item_ID, false, Item_ID);
            lpar.Add(par_Item_ID);

            string sql = @"select 
                                  s.ImportTime as Stock_ImportTime,
                                  s.dQuantity as Stock_dQuantity,
                                  s.ExpiryDate as Stock_Expiry_Date,
                                  pp.PurchasePricePerUnit as PurchasePricePerUnit,
                                  pp.Discount as PurchaseDiscount,
                                  pp.PriceWithoutVAT as PurchasePriceWithoutVAT,
                                  s.Stock_AddressLevel1_ID,
                                  s.Description as Stock_Description,
                                  i.UniqueName as Item_UniqueName,
                                  i.Name as Item_Name,
                                  i.Code as Item_Code,
                                  i.barcode as Item_barcode,
                                  stk.Name as StockTake_Name,
                                  stk.StockTake_Date,
                                  org.Name as Supplier_Organisation_Name,
                                  cfn.FirstName as Supplier_Person_FirstName,
                                  cln.LastName as Supplier_Person_LastName,
                                  cgsmp.GsmNumber as Supplier_Person_GsmNumber,
                                  cemailp.Email as Supplier_Person_Email,
                                  u.Symbol as UnitSymbol,
                                  s.PurchasePrice_Item_ID as  Stock_PurchasePrice_Item_ID,
                                  s.ID as Stock_ID
                                  from Stock s
                                  inner join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  inner join Unit u on i.Unit_ID = u.ID
                                  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join StockTake stk on ppi.StockTake_ID = stk.ID
                                  left join Supplier sup on stk.Supplier_ID = sup.ID
                                  left join Contact con on sup.Contact_ID = con.ID
                                  left join OrganisationData orgd on con.OrganisationData_ID = orgd.ID
                                  left join Organisation org on orgd.Organisation_ID = org.ID
                                  left join Person per on con.Person_ID = per.ID
                                  left join cFirstName cfn on per.cFirstName_ID = cfn.ID
                                  left join cLastName cln on per.cLastName_ID = cln.ID
                                  left join PersonData perd on perd.Person_ID = per.ID
                                  left join cGsmNumber_Person cgsmp on perd.cGsmNumber_Person_ID = cgsmp.ID
                                  left join cEmail_Person cemailp on perd.cEmail_Person_ID = cemailp.ID
                                  where ppi.Item_ID = " + spar_Item_ID + " and s.dQuantity > 0 order by Stock_Expiry_Date asc";
            if (DBSync.DBSync.ReadDataTable(ref dt_ShopC_Item_In_Stock, sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.GetItemInStock:slq=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetItemInStock(ID Item_ID, ref DataTable dt_ShopC_Item_In_Stock, string order_by)
        {
            string Err = null;
            if (dt_ShopC_Item_In_Stock == null)
            {
                dt_ShopC_Item_In_Stock = new DataTable();
            }
            else
            {
                dt_ShopC_Item_In_Stock.Dispose();
                dt_ShopC_Item_In_Stock = new DataTable();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Item_ID = "@par_Item_ID";
            SQL_Parameter par_Item_ID = new SQL_Parameter(spar_Item_ID, false, Item_ID);
            lpar.Add(par_Item_ID);

            string sql = @"select 
                                  s.ImportTime as Stock_ImportTime,
                                  s.dQuantity as Stock_dQuantity,
                                  s.ExpiryDate as Stock_Expiry_Date,
                                  pp.PurchasePricePerUnit as PurchasePricePerUnit,
                                  pp.Discount as PurchaseDiscount,
                                  pp.PriceWithoutVAT as PurchasePriceWithoutVAT,
                                  t.Name as TaxationName,
                                  s.Stock_AddressLevel1_ID,
                                  s.Description as Stock_Description,
                                  i.UniqueName as Item_UniqueName,
                                  i.Name as Item_Name,
                                  i.Code as Item_Code,
                                  i.barcode as Item_barcode,
                                  stk.Name as StockTake_Name,
                                  stk.StockTake_Date,
                                  org.Name as Supplier_Organisation_Name,
                                  cfn.FirstName as Supplier_Person_FirstName,
                                  cln.LastName as Supplier_Person_LastName,
                                  cgsmp.GsmNumber as Supplier_Person_GsmNumber,
                                  cemailp.Email as Supplier_Person_Email,
                                  u.Symbol as UnitSymbol,
                                  s.PurchasePrice_Item_ID as  Stock_PurchasePrice_Item_ID,
                                  s.ID as Stock_ID
                                  from Stock s
                                  inner join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  inner join Unit u on i.Unit_ID = u.ID
                                  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join Taxation t on pp.Taxation_ID = t.ID
                                  inner join StockTake stk on ppi.StockTake_ID = stk.ID
                                  left join Supplier sup on stk.Supplier_ID = sup.ID
                                  left join Contact con on sup.Contact_ID = con.ID
                                  left join OrganisationData orgd on con.OrganisationData_ID = orgd.ID
                                  left join Organisation org on orgd.Organisation_ID = org.ID
                                  left join Person per on con.Person_ID = per.ID
                                  left join cFirstName cfn on per.cFirstName_ID = cfn.ID
                                  left join cLastName cln on per.cLastName_ID = cln.ID
                                  left join PersonData perd on perd.Person_ID = per.ID
                                  left join cGsmNumber_Person cgsmp on perd.cGsmNumber_Person_ID = cgsmp.ID
                                  left join cEmail_Person cemailp on perd.cEmail_Person_ID = cemailp.ID
                                  where ppi.Item_ID = " + spar_Item_ID
                                  + " and s.dQuantity > 0 " + order_by; //order by Stock_Expiry_Date asc";
            if (DBSync.DBSync.ReadDataTable(ref dt_ShopC_Item_In_Stock, sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.GetItemInStock:slq=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
        public static decimal GetQuantityInStock(DataTable dtShopCItemInStock)
        {
            int icount = dtShopCItemInStock.Rows.Count;
            decimal dQuantityInStock = 0;
            for (int i=0;i< icount;i++)
            {
                decimal_v dQuantity_v = tf.set_decimal(dtShopCItemInStock.Rows[i]["Stock_dQuantity"]);
                if (dQuantity_v!=null)
                {
                    dQuantityInStock += dQuantity_v.v;
                }
            }
            return dQuantityInStock;
        }

        public static decimal GetPriceValueInStock(DataTable dtShopCItemInStock)
        {
            int icount = dtShopCItemInStock.Rows.Count;
            decimal dPriceValueInStock = 0;
            for (int i = 0; i < icount; i++)
            {
                decimal_v dPriceValue_v = tf.set_decimal(dtShopCItemInStock.Rows[i]["PurchasePricePerUnit"]);
                decimal_v dDiscount_v = tf.set_decimal(dtShopCItemInStock.Rows[i]["PurchaseDiscount"]);
                decimal discount = 0;
                if (dDiscount_v!=null)
                {
                    discount = dDiscount_v.v;
                }
                if (dPriceValue_v != null)
                {
                    dPriceValueInStock += dPriceValue_v.v*(1- discount);
                }
            }
            return dPriceValueInStock;
        }

        //CREATE TABLE PurchasePrice( ID,
        //                            PurchasePricePerUnit
        //                            Currency_ID,
        //                            Taxation_ID, 
        //                            PurchasePriceDate,
        //                            Discount
        //                            PriceWithoutVAT
        //                            VATCanNotBeDeducted)

        public static bool GetStock(ref DataTable dtStock)
        {
            string Err = null;
            if (dtStock == null)
            {
                dtStock = new DataTable();
            }
            else
            {
                dtStock.Dispose();
                dtStock = new DataTable();
            }
            string sql = @"select s.ID as Stock_ID,
                                  i.UniqueName as Item_UniqueName,
                                  s.ImportTime as Stock_ImportTime,
                                  s.dQuantity as Stock_dQuantity,
                                  s.ExpiryDate as Stock_Expiry_Date,
                                  s.PurchasePrice_Item_ID as  Stock_PurchasePrice_Item_ID,
                                  s.Stock_AddressLevel1_ID,
                                  s.Description as Stock_Description,
                                  i.Name as Item_Name,
                                  i.Code as Item_Code,
                                  i.barcode as Item_barcode,
                                  stk.Name as StockTake_Name,
                                  stk.StockTake_Date,
                                  org.Name as Supplier_Organisation_Name,
                                  cfn.FirstName as Supplier_Person_FirstName,
                                  cln.LastName as Supplier_Person_LastName,
                                  cgsmp.GsmNumber as Supplier_Person_GsmNumber,
                                  cemailp.Email as Supplier_Person_Email,
                                  u.Symbol as UnitSymbol,
                                  pp.PurchasePricePerUnit as PurchasePricePerUnit,
                                  pp.PurchasePriceDate as PurchasePriceDate,
                                  pp.Discount as PurchaseDiscount,
                                  pp.PriceWithoutVAT as PriceWithoutVAT,
                                  pp.VATCanNotBeDeducted as VATCanNotBeDeducted,
                                  t.Name as TaxationName
                                  from Stock s
                                  inner join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  inner join Unit u on i.Unit_ID = u.ID
                                  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join Taxation t on pp.Taxation_ID = t.ID
                                  inner join StockTake stk on ppi.StockTake_ID = stk.ID
                                  left join Supplier sup on stk.Supplier_ID = sup.ID
                                  left join Contact con on sup.Contact_ID = con.ID
                                  left join OrganisationData orgd on con.OrganisationData_ID = orgd.ID
                                  left join Organisation org on orgd.Organisation_ID = org.ID
                                  left join Person per on con.Person_ID = per.ID
                                  left join cFirstName cfn on per.cFirstName_ID = cfn.ID
                                  left join cLastName cln on per.cLastName_ID = cln.ID
                                  left join PersonData perd on perd.Person_ID = per.ID
                                  left join cGsmNumber_Person cgsmp on perd.cGsmNumber_Person_ID = cgsmp.ID
                                  left join cEmail_Person cemailp on perd.cEmail_Person_ID = cemailp.ID
                                  order by s.ImportTime asc";
            if (DBSync.DBSync.ReadDataTable(ref dtStock, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.GetStock:slq=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetStockOrderBy(ref DataTable dtStock, string order_by)
        {
            string Err = null;
            if (dtStock == null)
            {
                dtStock = new DataTable();
            }
            else
            {
                dtStock.Dispose();
                dtStock = new DataTable();
            }
            string sql = @"select s.ID as Stock_ID,
                                  i.UniqueName as Item_UniqueName,
                                  s.ImportTime as Stock_ImportTime,
                                  s.dQuantity as Stock_dQuantity,
                                  s.ExpiryDate as Stock_Expiry_Date,
                                  s.PurchasePrice_Item_ID as  Stock_PurchasePrice_Item_ID,
                                  s.Stock_AddressLevel1_ID,
                                  s.Description as Stock_Description,
                                  i.Name as Item_Name,
                                  i.Code as Item_Code,
                                  i.barcode as Item_barcode,
                                  stk.Name as StockTake_Name,
                                  stk.StockTake_Date,
                                  org.Name as Supplier_Organisation_Name,
                                  cfn.FirstName as Supplier_Person_FirstName,
                                  cln.LastName as Supplier_Person_LastName,
                                  cgsmp.GsmNumber as Supplier_Person_GsmNumber,
                                  cemailp.Email as Supplier_Person_Email,
                                  u.Symbol as UnitSymbol,
                                  pp.PurchasePricePerUnit as PurchasePricePerUnit,
                                  pp.PurchasePriceDate as PurchasePriceDate,
                                  pp.Discount as PurchaseDiscount,
                                  pp.PriceWithoutVAT as PriceWithoutVAT,
                                  pp.VATCanNotBeDeducted as VATCanNotBeDeducted,
                                  t.Name as TaxationName
                                  from Stock s
                                  inner join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  inner join Unit u on i.Unit_ID = u.ID
                                  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join Taxation t on pp.Taxation_ID = t.ID
                                  inner join StockTake stk on ppi.StockTake_ID = stk.ID
                                  left join Supplier sup on stk.Supplier_ID = sup.ID
                                  left join Contact con on sup.Contact_ID = con.ID
                                  left join OrganisationData orgd on con.OrganisationData_ID = orgd.ID
                                  left join Organisation org on orgd.Organisation_ID = org.ID
                                  left join Person per on con.Person_ID = per.ID
                                  left join cFirstName cfn on per.cFirstName_ID = cfn.ID
                                  left join cLastName cln on per.cLastName_ID = cln.ID
                                  left join PersonData perd on perd.Person_ID = per.ID
                                  left join cGsmNumber_Person cgsmp on perd.cGsmNumber_Person_ID = cgsmp.ID
                                  left join cEmail_Person cemailp on perd.cEmail_Person_ID = cemailp.ID
                                 " + order_by;
            if (DBSync.DBSync.ReadDataTable(ref dtStock, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.GetStock:slq=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool GetStock(ref DataTable dtStock, string item_unique_name)
        {
            string Err = null;
            if (dtStock == null)
            {
                dtStock = new DataTable();
            }
            else
            {
                dtStock.Dispose();
                dtStock = new DataTable();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_UniqueName = "@par_UniqueName";
            SQL_Parameter par_UniqueName = new SQL_Parameter(spar_UniqueName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, item_unique_name);
            lpar.Add(par_UniqueName);

            string sql = @"select s.ID as Stock_ID,
                                  i.UniqueName as Item_UniqueName,
                                  s.ImportTime as Stock_ImportTime,
                                  s.dQuantity as Stock_dQuantity,
                                  s.ExpiryDate as Stock_Expiry_Date,
                                  s.PurchasePrice_Item_ID as  Stock_PurchasePrice_Item_ID,
                                  s.Stock_AddressLevel1_ID,
                                  s.Description as Stock_Description,
                                  i.Name as Item_Name,
                                  i.Code as Item_Code,
                                  i.barcode as Item_barcode,
                                  stk.Name as StockTake_Name,
                                  stk.StockTake_Date,
                                  org.Name as Supplier_Organisation_Name,
                                  cfn.FirstName as Supplier_Person_FirstName,
                                  cln.LastName as Supplier_Person_LastName,
                                  cgsmp.GsmNumber as Supplier_Person_GsmNumber,
                                  cemailp.Email as Supplier_Person_Email,
                                  u.Symbol as UnitSymbol
                                  from Stock s
                                  inner join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  inner join Unit u on i.Unit_ID = u.ID
                                  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join StockTake stk on ppi.StockTake_ID = stk.ID
                                  left join Supplier sup on stk.Supplier_ID = sup.ID
                                  left join Contact con on sup.Contact_ID = con.ID
                                  left join OrganisationData orgd on con.OrganisationData_ID = orgd.ID
                                  left join Organisation org on orgd.Organisation_ID = org.ID
                                  left join Person per on con.Person_ID = per.ID
                                  left join cFirstName cfn on per.cFirstName_ID = cfn.ID
                                  left join cLastName cln on per.cLastName_ID = cln.ID
                                  left join PersonData perd on perd.Person_ID = per.ID
                                  left join cGsmNumber_Person cgsmp on perd.cGsmNumber_Person_ID = cgsmp.ID
                                  left join cEmail_Person cemailp on perd.cEmail_Person_ID = cemailp.ID
                                  where i.UniqueName = " + spar_UniqueName + @"
                                  order by s.ImportTime asc";
            if (DBSync.DBSync.ReadDataTable(ref dtStock, sql,lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.f_Stock.GetStock:slq=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}

