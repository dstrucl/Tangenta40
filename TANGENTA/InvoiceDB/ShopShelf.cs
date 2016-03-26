#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class ShopShelf
    {
        public Columns_Price_Item_Stock m_cpis = null;
        public string sql_Price_Item_Stock_template = null;
        public DataTable dt_Price_Item_Stock = new DataTable();
        public DataTable dt_Price_Item_Group = new DataTable();
        public List<object> items = new List<object>();


        public ShopShelf()
        {
            m_cpis = new Columns_Price_Item_Stock();

            sql_Price_Item_Stock_template = @"select 
              Price_Item.ID as " + m_cpis.sPrice_Item_ID + @",
              Price_Item.PriceList_ID as " + m_cpis.sPriceList_ID + @",
              PriceList.Name as " + m_cpis.sPriceList_Name + @",
              Currency.Name as  " + m_cpis.sCurrency_Name + @",
              Currency.Abbreviation as  " + m_cpis.sCurrency_Abbreviation + @",
              Currency.Symbol as  " + m_cpis.sCurrency_Symbol + @",
              Currency.DecimalPlaces as  " + m_cpis.sCurrency_DecimalPlaces + @",
              Stock.ID as " + m_cpis.sStock_ID + @",
              Price_Item.RetailPricePerUnit as " + m_cpis.sRetailPricePerUnit + @",
              PurchasePrice.PurchasePricePerUnit as " + m_cpis.sPurchasePricePerUnit + @",
              Price_Item.Discount as " + m_cpis.sPrice_Item_Discount + @",
              Taxation.ID as " + m_cpis.sTaxation_ID + @",
              Taxation.Rate as " + m_cpis.sTaxation_Rate + @",
              Taxation.Name as " + m_cpis.sTaxation_Name + @",
              Stock.ExpiryDate as " + m_cpis.sStock_ExpiryDate + @",
              Stock.dQuantity as " + m_cpis.sStock_dQuantity + @",
			  Stock.ImportTime as " + m_cpis.sStock_ImportTime + @",
              ptm.id  as " + m_cpis.sItem_ID + @",
              ptm.UniqueName as " + m_cpis.sItem_UniqueName + @",
			  ptm.Name as " + m_cpis.sItem_Name + @",
			  ptm.barcode as " + m_cpis.sItem_barcode + @",
			  ptm.Item_Image_ID as " + m_cpis.sItem_Image_ID + @",
              Unit.Name as " + m_cpis.sUnit_Name + @",
              Unit.Symbol as " + m_cpis.sUnit_Symbol + @",
              Unit.DecimalPlaces as " + m_cpis.sUnit_DecimalPlaces + @",
              Unit.StorageOption as " + m_cpis.sUnit_StorageOption + @",
              Unit.Description as " + m_cpis.sUnit_Description + @",
			  Item_Image.Image_Data as " + m_cpis.sItem_Image_Image_Data + @",
			  Item_Image.Image_Hash as " + m_cpis.sItem_Image_Image_Hash + @",
              ptm.Description as " + m_cpis.sItem_Description + @",
              ptm.Expiry_ID as " + m_cpis.sExpiry_ID + @", 
			  Expiry.ExpectedShelfLifeInDays as " + m_cpis.sExpiry_ExpectedShelfLifeInDays + @",
			  Expiry.SaleBeforeExpiryDateInDays as " + m_cpis.sExpiry_SaleBeforeExpiryDateInDays + @",
			  Expiry.DiscardBeforeExpiryDateInDays as " + m_cpis.sExpiry_DiscardBeforeExpiryDateInDays + @",
              Expiry.ExpiryDescription as " + m_cpis.sExpiry_ExpiryDescription + @",
			  ptm.ToOffer as " + m_cpis.sItem_ToOffer + @",
              ptm.Warranty_ID as " + m_cpis.sWarranty_ID + @",
              Warranty.WarrantyConditions as " + m_cpis.sWarranty_WarrantyConditions + @",
              Warranty.WarrantyDuration as " + m_cpis.sWarranty_WarrantyDuration + @",
              Warranty.WarrantyDurationType as " + m_cpis.sWarranty_WarrantyDurationType + @",
			  Organisation.Name as " + m_cpis.sPurchaseCompany_Name + @",
			  cStreetName_Org.StreetName as " + m_cpis.sStreetName + @",
              cHouseNumber_Org.HouseNumber as " + m_cpis.sHouseNumber + @",
              cCity_Org.City as " + m_cpis.sCity + @",
              cZIP_Org.ZIP as " + m_cpis.sZIP + @",
              cCountry_Org.Country as " + m_cpis.sCountry+ @",
              cState_Org.State as " + m_cpis.sState + @",
              s1.Name as " + m_cpis.ss1_name + @",
              s2.Name as " + m_cpis.ss2_name + @", 
              s3.Name as " + m_cpis.ss3_name + @"
              from Price_Item
              Inner Join PriceList on Price_Item.PriceList_ID = PriceList.ID
              Inner Join Currency on Currency.ID = PriceList.Currency_ID
              Inner Join Item ptm on Price_Item.Item_ID = ptm.ID
              Inner Join Unit on ptm.Unit_ID = Unit.ID
              Inner Join Taxation on Price_Item.Taxation_ID =  Taxation.ID
              Left Join PurchasePrice_Item putm on putm.Item_ID = ptm.ID
              Left Join PurchasePrice on putm.PurchasePrice_ID = PurchasePrice.ID
              Left Join Item_Image on ptm.Item_Image_ID = Item_Image.ID
              Left Join Expiry on ptm.Expiry_ID = Expiry.ID
              Left Join Warranty on ptm.Warranty_ID = Warranty.ID
              left Join Stock on   putm.ID = Stock.PurchasePrice_Item_ID
              left Join Supplier on PurchasePrice.Supplier_ID =Supplier.ID 
              left Join Organisation on Supplier.Organisation_ID =Organisation.ID 
              left Join OrganisationData on OrganisationData.Organisation_ID =Organisation.ID 
              left Join cAddress_Org on OrganisationData.cAddress_Org_ID = cAddress_Org.ID
              left Join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
              left Join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
              left Join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
              left Join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
              left Join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
              left Join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
              left Join Item_ParentGroup1 s1 ON ptm.Item_ParentGroup1_ID = s1.ID
              left Join Item_ParentGroup2 s2 ON s1.Item_ParentGroup2_ID = s2.ID
              left Join Item_ParentGroup3 s3 ON s2.Item_ParentGroup3_ID = s3.ID
	                    where ptm.ToOffer = 1 and Price_Item.PriceList_ID = ";
        }

        private bool ExistingItem(long item_id, Item_Data xItem_Data)
        {
            foreach (object o in items)
            {
                Item_Data idata = (Item_Data)o;
                if (idata.Item_ID != null)
                {
                    if (idata.Item_ID.v == item_id)
                    {
                        Stock_Data stock_data = new Stock_Data();
                        if (xItem_Data.Stock_ID != null)
                        {
                            stock_data.Stock_ID = new DBTypes.long_v();
                            stock_data.Stock_ID.v = xItem_Data.Stock_ID.v;
                        }
                        else
                        {
                            stock_data.Stock_ID = null;
                        }

                        if (xItem_Data.Stock_ImportTime != null)
                        {
                            stock_data.Stock_ImportTime = new DBTypes.DateTime_v();
                            stock_data.Stock_ImportTime.v = xItem_Data.Stock_ImportTime.v;
                        }
                        else
                        {
                            stock_data.Stock_ImportTime = null;
                        }

                        if (xItem_Data.Stock_ExpiryDate != null)
                        {
                            stock_data.Stock_ExpiryDate = new DBTypes.DateTime_v();
                            stock_data.Stock_ExpiryDate.v = xItem_Data.Stock_ExpiryDate.v;
                        }
                        else
                        {
                            stock_data.Stock_ExpiryDate = null;
                        }

                        if (xItem_Data.Stock_dQuantity != null)
                        {
                            stock_data.dQuantity = new DBTypes.decimal_v();
                            stock_data.dQuantity.v = xItem_Data.Stock_dQuantity.v;
                        }
                        else
                        {
                            stock_data.dQuantity = null;
                        }
                        idata.Stock_Data_List.Add(stock_data);
                        return true;
                    }
                }
            }
            return false;
        }

        private void Set()
        {
            items.Clear();
            foreach (DataRow dr in dt_Price_Item_Stock.Rows)
            {
                Item_Data xItem_Data = new Item_Data();
                xItem_Data.Set_Price_Item_Stock(dr);
                if (dr[m_cpis.icol_Item_ID] is long)
                {
                    long item_id = (long)dr[m_cpis.icol_Item_ID];
                    if (ExistingItem(item_id, xItem_Data))
                    {
                        continue;
                    }
                    else
                    {
                        Stock_Data stock_data = new Stock_Data();
                        if (xItem_Data.Stock_ID != null)
                        {
                            stock_data.Stock_ID = new DBTypes.long_v();
                            stock_data.Stock_ID.v = xItem_Data.Stock_ID.v;
                        }
                        else
                        {
                            stock_data.Stock_ID = null;
                        }

                        if (xItem_Data.Stock_ImportTime != null)
                        {
                            stock_data.Stock_ImportTime = new DBTypes.DateTime_v();
                            stock_data.Stock_ImportTime.v = xItem_Data.Stock_ImportTime.v;
                        }
                        else
                        {
                            stock_data.Stock_ImportTime = null;
                        }

                        if (xItem_Data.Stock_ExpiryDate != null)
                        {
                            stock_data.Stock_ExpiryDate = new DBTypes.DateTime_v();
                            stock_data.Stock_ExpiryDate.v = xItem_Data.Stock_ExpiryDate.v;
                        }
                        else
                        {
                            stock_data.Stock_ExpiryDate = null;
                        }

                        if (xItem_Data.Stock_dQuantity != null)
                        {
                            stock_data.dQuantity = new DBTypes.decimal_v();
                            stock_data.dQuantity.v = xItem_Data.Stock_dQuantity.v;
                        }
                        else
                        {
                            stock_data.dQuantity = null;
                        }
                        xItem_Data.Stock_Data_List.Add(stock_data);
                        items.Add(xItem_Data);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopShelf:Set:dr[m_cpis.icol_Item_ID] is not long !");
                }
            }

        }

        public bool Load(long m_PriceList_ID, string[] s_name_Group)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string s_group_condition = fs.GetGroupCondition(ref lpar, s_name_Group);
            string sql_Stock = sql_Price_Item_Stock_template + m_PriceList_ID.ToString() + s_group_condition + " order by ptm.Code asc";
            string Err = null;
            dt_Price_Item_Stock.Clear();
            dt_Price_Item_Stock.Columns.Clear();
            dt_Price_Item_Stock.Rows.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_Item_Stock, sql_Stock, lpar, ref Err))
            {
                m_cpis.Set(dt_Price_Item_Stock);
                Set();

                //Program.iGDIcUser101 = Program.getGuiResourcesUserCount();

                //Program.iGDIcUser102 = Program.getGuiResourcesUserCount();

                dt_Price_Item_Group.Clear();
                dt_Price_Item_Group.Columns.Clear();
                //Program.iGDIcUser103 = Program.getGuiResourcesUserCount();
                //Program.iGDIcUser104 = Program.getGuiResourcesUserCount();
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ItemList:m_usrc_Item_Group_Handler_GroupChanged:sql=" + sql_Stock + "\r\nErr=" + Err);
                return false;
            }

        }

        public bool GetGroupsTable(long PriceList_ID)
        {
            string sql = @"select 
              s1.Name as s1_name,
              s2.Name as s2_name,
              s3.Name as s3_name
              from Price_Item
              Inner Join PriceList on Price_Item.PriceList_ID = PriceList.ID
              Inner Join Item ptm on Price_Item.Item_ID = ptm.ID
              Inner Join Unit on ptm.Unit_ID = Unit.ID
              Inner Join Taxation on Price_Item.Taxation_ID =  Taxation.ID
              Left Join PurchasePrice_Item putm on putm.Item_ID = ptm.ID
              Left Join PurchasePrice on putm.PurchasePrice_ID = PurchasePrice.ID
              Left Join Item_Image on ptm.Item_Image_ID = Item_Image.ID
              Left Join Expiry on ptm.Expiry_ID = Expiry.ID
              Left Join Warranty on ptm.Warranty_ID = Warranty.ID
              left Join Stock on   putm.ID = Stock.PurchasePrice_Item_ID
              left Join Supplier on PurchasePrice.Supplier_ID =Supplier.ID 
              left Join Organisation on Supplier.Organisation_ID =Organisation.ID 
              left Join OrganisationData on OrganisationData.Organisation_ID =Organisation.ID 
              left Join cAddress_Org on OrganisationData.cAddress_Org_ID = cAddress_Org.ID
              left Join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
              left Join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
              left Join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
              left Join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
              left Join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
              left Join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
              left Join Item_ParentGroup1 s1 ON ptm.Item_ParentGroup1_ID = s1.ID
              left Join Item_ParentGroup2 s2 ON s1.Item_ParentGroup2_ID = s2.ID
              left Join Item_ParentGroup3 s3 ON s2.Item_ParentGroup3_ID = s3.ID
	                    where ptm.ToOffer = 1 and Price_Item.PriceList_ID = " + PriceList_ID.ToString() + @"
		       group by s1.Name,s2.Name,s3.Name";
            dt_Price_Item_Group.Clear();
            dt_Price_Item_Group.Rows.Clear();
            dt_Price_Item_Group.Columns.Clear();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_Item_Group, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ItemList:sGroup_List:SetGroups:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public int GetIndex(Atom_DocInvoice_Price_Item_Stock_Data appisd)
        {
            foreach (object o in items)
            {
                if (((Item_Data)o).Item_UniqueName.v.Equals(appisd.Atom_Item_UniqueName.v))
                {
                    int index = items.IndexOf(o);
                    return index;
                }
            }
            return -1;
        }

        public void Set_dQuantity_New_InStock(long stock_id, decimal dQuantity_New_InStock)
        {
            foreach (object oitem in items)
            {
                if (oitem is Item_Data)
                {
                    Item_Data item_data = (Item_Data)oitem;
                    foreach (Stock_Data stock_data in item_data.Stock_Data_List)
                    {
                        if (stock_data.Stock_ID != null)
                        {
                            if (stock_data.Stock_ID.v == stock_id)
                            {
                                if (stock_data.dQuantity != null)
                                {
                                    stock_data.dQuantity.v = dQuantity_New_InStock;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
