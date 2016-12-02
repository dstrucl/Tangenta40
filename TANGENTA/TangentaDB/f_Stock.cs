using DBConnectionControl40;
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
        public static bool Add(DateTime tImportTime,decimal dQuantity,DateTime_v tExpiry_v,long PurchasePrice_Item_ID,long Stock_AddressLevel1_ID,string Description, ref long Stock_ID)
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
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PurchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

            string spar_Stock_AddressLevel1_ID = "null";
            if (Stock_AddressLevel1_ID >= 0)
            {
                spar_Stock_AddressLevel1_ID = "@par_Stock_AddressLevel1_ID";
                SQL_Parameter par_Stock_AddressLevel1_ID = new SQL_Parameter(spar_Stock_AddressLevel1_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Stock_AddressLevel1_ID);
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
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Stock_ID, ref oret, ref Err, "Stock"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Add:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GeStockTakeItems(ref DataTable dt_Stock_Of_Current_StockTake,ref Doc_ShopC_Item[] array_Doc_ShopC_Item, long StockTake_ID)
        {
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
                                  tr.TruckingCost,
                                  tr.Customs,                                  
                                  st.Name as StockTake_Name, 
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
            if (DBSync.DBSync.ReadDataTable(ref dt_Stock_Of_Current_StockTake, sql, ref Err))
            {
                int iCount = dt_Stock_Of_Current_StockTake.Rows.Count;
                if (iCount > 0)
                {
                    array_Doc_ShopC_Item = new Doc_ShopC_Item[iCount];
                    sql = @"select  
                                    di.Draft,
                                    di.DraftNumber,
                                    di.FinancialYear,
                                    di.NumberInFinancialYear,
                                    disci.Stock_ID,
                                    disci.DocInvoice_ID,
                                    disci.ID
                            from DocInvoice_ShopC_Item disci
                            inner join  DocInvoice di on disci.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice jdi on jdi.DocInvoice_ID = di.ID
                            inner join  JOURNAL_DocInvoice_Type jdit on jdi.JOURNAL_DocInvoice_Type_ID = jdit.ID and jdit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID
                            left join  Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on disci.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                    dt_DocInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                    if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                    {
                        sql = @"select  
                                    dpi.Draft,
                                    dpi.DraftNumber,
                                    dpi.FinancialYear,
                                    dpi.NumberInFinancialYear,
                                    dpisci.Stock_ID,
                                    dpisci.DocProformaInvoice_ID,
                                    dpisci.ID
                            from DocProformaInvoice_ShopC_Item dpisci
                            inner join  DocProformaInvoice dpi on dpisci.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice jdpi on jdpi.DocProformaInvoice_ID = dpi.ID
                            inner join  JOURNAL_DocProformaInvoice_Type jdpit on jdpi.JOURNAL_DocProformaInvoice_Type_ID = jdpit.ID and jdpit.ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString() + @"
                            inner join  Atom_WorkPeriod awp on jdpi.Atom_WorkPeriod_ID = awp.ID
                            left join  Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join  Atom_myOrganisation_Person amop on awp.Atom_myOrganisation_Person_ID = amop.ID
                            left join  Atom_Person ap on amop.Atom_Person_ID = ap.ID
                            left join  Atom_cFirstName acfn on ap.Atom_cFirstName_ID = acfn.ID
                            left join  Atom_cLastName acln on ap.Atom_cLastName_ID = acln.ID
                            inner join  Stock s on dpisci.Stock_ID = s.ID
                            inner join  PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID and ppi.StockTake_ID = " + StockTake_ID.ToString();
                        dt_DocProformaInvoice_ShopC_Item_of_StockTake.Rows.Clear();
                        if (DBSync.DBSync.ReadDataTable(ref dt_DocProformaInvoice_ShopC_Item_of_StockTake, sql, ref Err))
                        {

                            for (int i=0;i<iCount;i++)
                            {
                                long xstock_id = (long)dt_Stock_Of_Current_StockTake.Rows[i]["Stock_ID"];
                                DataRow[] drs_DocInvoice = dt_DocInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());
                                DataRow[] drs_DocProformaInvoice = dt_DocProformaInvoice_ShopC_Item_of_StockTake.Select("Stock_ID=" + xstock_id.ToString());

                                int iCount1 = drs_DocInvoice.Length;
                                int iCount2 = drs_DocProformaInvoice.Length;
                                if (iCount1 + iCount2 > 0)
                                {
                                    array_Doc_ShopC_Item[i] = new Doc_ShopC_Item(xstock_id,
                                                                                 drs_DocInvoice,
                                                                                 drs_DocProformaInvoice);
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


        public static bool Remove(long Stock_ID, long StockTake_ID)
        {
                string Err = null;
            string sql = @"delete from Stock 
                         where ID in (select s.ID from Stock s
                                     inner join PurchasePrice_Item ppi on  s.PurchasePrice_Item_ID = ppi.ID
                                     where ppi.StockTake_ID = " + StockTake_ID.ToString() + " and s.ID =" + Stock_ID.ToString()+")";
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref oret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StockTake_AdditionalCost.cs:Remove:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool Update(long currentStock_ID, 
                                  DateTime tImportTime, 
                                  decimal dQuantity, 
                                  DateTime_v tExpiry_v, 
                                  long PurchasePrice_Item_ID,
                                  long Stock_AddressLevel1_ID, 
                                  string Description)
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
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PurchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

            string spar_Stock_AddressLevel1_ID = "null";
            if (Stock_AddressLevel1_ID >= 0)
            {
                spar_Stock_AddressLevel1_ID = "@par_Stock_AddressLevel1_ID";
                SQL_Parameter par_Stock_AddressLevel1_ID = new SQL_Parameter(spar_Stock_AddressLevel1_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Stock_AddressLevel1_ID);
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
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref oret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}

