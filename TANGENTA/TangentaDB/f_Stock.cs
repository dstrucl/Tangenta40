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

        public static bool Get_OfStockTake(ref DataTable dt_Stock_Of_Current_StockTake, long StockTake_ID)
        {
            string Err = null;
            string sql = @"select i.UniqueName,
                                  s.dQuantity,
                                  s.ImportTime,
                                  s.ExpiryDate,
                                  st.Name, 
                                  org.Name as OrganisationName,
                                  org.Tax_ID,
                                  ppi.PurchasePrice_ID,
                                  pp.PurchasePricePerUnit,
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
    }
}
