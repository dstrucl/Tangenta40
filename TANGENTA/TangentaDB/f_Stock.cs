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

        public static bool GeStockTakeItems(ref DataTable dt_Stock_Of_Current_StockTake, long StockTake_ID)
        {
            string Err = null;
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
            if (DBSync.DBSync.ReadDataTable(ref dt_Stock_Of_Current_StockTake,sql,ref Err))
            {
                return true;
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

