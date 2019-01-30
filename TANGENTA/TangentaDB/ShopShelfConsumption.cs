﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class ShopShelfConsumption
    {
        public Columns_PurchasePrice_CItem_Stock m_cpis = null;
       // public string sql_Price_Item_Stock_template = null;
        public DataTable dt_Price_Item_Stock = null;
        public DataTable dt_Price_Item_Group = new DataTable();
        public List<CItem_Data> ListOfCItems = new List<CItem_Data>();


        public ShopShelfConsumption()
        {
            m_cpis = new Columns_PurchasePrice_CItem_Stock();

     //       sql_Price_Item_Stock_template = @"select 
     //         Price_Item.ID as " + m_cpis.sPrice_Item_ID + @",
     //         Price_Item.PriceList_ID as " + m_cpis.sPriceList_ID + @",
     //         PriceList_Name.Name as " + m_cpis.sPriceList_Name + @",
     //         Currency.Name as  " + m_cpis.sCurrency_Name + @",
     //         Currency.Abbreviation as  " + m_cpis.sCurrency_Abbreviation + @",
     //         Currency.Symbol as  " + m_cpis.sCurrency_Symbol + @",
     //         Currency.DecimalPlaces as  " + m_cpis.sCurrency_DecimalPlaces + @",
     //         Stock.ID as " + m_cpis.sStock_ID + @",
     //         Price_Item.RetailPricePerUnit as " + m_cpis.sRetailPricePerUnit + @",
     //         PurchasePrice.PurchasePricePerUnit as " + m_cpis.sPurchasePricePerUnit + @",
     //         Price_Item.Discount as " + m_cpis.sPrice_Item_Discount + @",
     //         Taxation.ID as " + m_cpis.sTaxation_ID + @",
     //         Taxation.Rate as " + m_cpis.sTaxation_Rate + @",
     //         Taxation.Name as " + m_cpis.sTaxation_Name + @",
     //         Stock.ExpiryDate as " + m_cpis.sStock_ExpiryDate + @",
     //         Stock.dQuantity as " + m_cpis.sStock_dQuantity + @",
			  //Stock.ImportTime as " + m_cpis.sStock_ImportTime + @",
     //         StockTake.Draft as  " + m_cpis.sStockTake_Draft + @",
     //         ptm.id  as " + m_cpis.sItem_ID + @",
     //         ptm.UniqueName as " + m_cpis.sItem_UniqueName + @",
			  //ptm.Name as " + m_cpis.sItem_Name + @",
			  //ptm.barcode as " + m_cpis.sItem_barcode + @",
			  //ptm.Item_Image_ID as " + m_cpis.sItem_Image_ID + @",
     //         Unit.Name as " + m_cpis.sUnit_Name + @",
     //         Unit.Symbol as " + m_cpis.sUnit_Symbol + @",
     //         Unit.DecimalPlaces as " + m_cpis.sUnit_DecimalPlaces + @",
     //         Unit.StorageOption as " + m_cpis.sUnit_StorageOption + @",
     //         Unit.Description as " + m_cpis.sUnit_Description + @",
			  //Item_Image.Image_Data as " + m_cpis.sItem_Image_Image_Data + @",
			  //Item_Image.Image_Hash as " + m_cpis.sItem_Image_Image_Hash + @",
     //         ptm.Description as " + m_cpis.sItem_Description + @",
     //         ptm.Expiry_ID as " + m_cpis.sExpiry_ID + @", 
			  //Expiry.ExpectedShelfLifeInDays as " + m_cpis.sExpiry_ExpectedShelfLifeInDays + @",
			  //Expiry.SaleBeforeExpiryDateInDays as " + m_cpis.sExpiry_SaleBeforeExpiryDateInDays + @",
			  //Expiry.DiscardBeforeExpiryDateInDays as " + m_cpis.sExpiry_DiscardBeforeExpiryDateInDays + @",
     //         Expiry.ExpiryDescription as " + m_cpis.sExpiry_ExpiryDescription + @",
			  //ptm.ToOffer as " + m_cpis.sItem_ToOffer + @",
     //         ptm.Warranty_ID as " + m_cpis.sWarranty_ID + @",
     //         Warranty.WarrantyConditions as " + m_cpis.sWarranty_WarrantyConditions + @",
     //         Warranty.WarrantyDuration as " + m_cpis.sWarranty_WarrantyDuration + @",
     //         Warranty.WarrantyDurationType as " + m_cpis.sWarranty_WarrantyDurationType + @",
			  //Organisation.Name as " + m_cpis.sPurchaseOrganisation_Name + @",
			  //cStreetName_Org.StreetName as " + m_cpis.sStreetName + @",
     //         cHouseNumber_Org.HouseNumber as " + m_cpis.sHouseNumber + @",
     //         cCity_Org.City as " + m_cpis.sCity + @",
     //         cZIP_Org.ZIP as " + m_cpis.sZIP + @",
     //         cCountry_Org.Country as " + m_cpis.sCountry+ @",
     //         cState_Org.State as " + m_cpis.sState + @",
     //         s1.Name as " + m_cpis.ss1_name + @",
     //         s2.Name as " + m_cpis.ss2_name + @", 
     //         s3.Name as " + m_cpis.ss3_name + @"
     //         from Price_Item
     //         Inner Join PriceList on Price_Item.PriceList_ID = PriceList.ID
     //         Inner Join PriceList_Name on PriceList.PriceList_Name_ID = PriceList_Name.ID
     //         Inner Join Currency on Currency.ID = PriceList.Currency_ID
     //         Inner Join Item ptm on Price_Item.Item_ID = ptm.ID
     //         Inner Join Unit on ptm.Unit_ID = Unit.ID
     //         Inner Join Taxation on Price_Item.Taxation_ID =  Taxation.ID
     //         Left Join PurchasePrice_Item putm on putm.Item_ID = ptm.ID
     //         Left Join PurchasePrice on putm.PurchasePrice_ID = PurchasePrice.ID
     //         Left Join Item_Image on ptm.Item_Image_ID = Item_Image.ID
     //         Left Join Expiry on ptm.Expiry_ID = Expiry.ID
     //         Left Join Warranty on ptm.Warranty_ID = Warranty.ID
     //         left Join Stock on   putm.ID = Stock.PurchasePrice_Item_ID
     //         left Join StockTake on putm.StockTake_ID = StockTake.ID
     //         left Join Supplier on StockTake.Supplier_ID =Supplier.ID 
     //         left Join Contact c on Supplier.Contact_ID =c.ID 
     //         left Join OrganisationData cod on c.OrganisationData_ID =cod.ID 
     //         left Join Organisation on cod.Organisation_ID =Organisation.ID 
     //         left Join cAddress_Org on cod.cAddress_Org_ID = cAddress_Org.ID
     //         left Join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
     //         left Join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
     //         left Join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
     //         left Join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
     //         left Join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
     //         left Join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
     //         left Join Item_ParentGroup1 s1 ON ptm.Item_ParentGroup1_ID = s1.ID
     //         left Join Item_ParentGroup2 s2 ON s1.Item_ParentGroup2_ID = s2.ID
     //         left Join Item_ParentGroup3 s3 ON s2.Item_ParentGroup3_ID = s3.ID
	    //                where ptm.ToOffer = 1 and Price_Item.RetailPricePerUnit>=0 and Price_Item.PriceList_ID = ";
        }

        private bool FillStockDataListForEachItemInItems(ID item_id, CItem_Data xItem_Data)
        {
            foreach (object o in ListOfCItems)
            {
                CItem_Data idata = (CItem_Data)o;
                if (ID.Validate(idata.Item_ID))
                {
                    if (idata.Item_ID.Equals(item_id))
                    {
 
                        CStock_Data stock_data = new CStock_Data();
                        if (xItem_Data.Stock_ID != null)
                        {
                            stock_data.Stock_ID = new ID(xItem_Data.Stock_ID);
                        }
                        else
                        {
                            stock_data.Stock_ID = null;
                        }

                        if (xItem_Data.Stock_ImportTime_v != null)
                        {
                            stock_data.Stock_ImportTime = new DBTypes.DateTime_v();
                            stock_data.Stock_ImportTime.v = xItem_Data.Stock_ImportTime_v.v;
                        }
                        else
                        {
                            stock_data.Stock_ImportTime = null;
                        }

                        if (xItem_Data.Stock_ExpiryDate_v != null)
                        {
                            stock_data.Stock_ExpiryDate = new DBTypes.DateTime_v();
                            stock_data.Stock_ExpiryDate.v = xItem_Data.Stock_ExpiryDate_v.v;
                        }
                        else
                        {
                            stock_data.Stock_ExpiryDate = null;
                        }

                        if (xItem_Data.Stock_dQuantity_v != null)
                        {
                            stock_data.dQuantity_v = tf.set_decimal(xItem_Data.Stock_dQuantity_v.v);
                        }
                        else
                        {
                            stock_data.dQuantity_v = null;
                        }

                        if (xItem_Data.StockTake_Draft_v != null)
                        {
                            stock_data.StockTake_Draft = new DBTypes.bool_v();
                            stock_data.StockTake_Draft.v = xItem_Data.StockTake_Draft_v.v;
                        }
                        else
                        {
                            stock_data.StockTake_Draft = null;
                        }

                        idata.CStock_Data_List.Add(stock_data);
                        return true;
                    }
                }
            }
            return false;
        }

        public CItem_Data FindItem(Consumption_ShopC_Item dsci)
        {
            foreach (CItem_Data xdata in this.ListOfCItems)
            {
                if (xdata.Item_UniqueName.Equals(dsci.Item_UniqueName))
                {
                    return xdata;
                }
            }
            return null;
        }

        private void ListOfItems_Set(DataTable dtPurchasePriceItem, string[] s_name_Group)
        {
            ListOfCItems.Clear();
            string s1g = "s1_name is null";
            if (s_name_Group[0] != null)
            {
                s1g = "s1_name = '"+ s_name_Group[0]+"'";
            }
            string s2g = "s2_name is null";
            if (s_name_Group[1] != null)
            {
                s2g = "s2_name = '" + s_name_Group[1] + "'";
            }
            string s3g = "s3_name is null";
            if (s_name_Group[2] != null)
            {
                s3g = "s3_name = '" + s_name_Group[2] + "'";
            }

            DataRow[] drs = dtPurchasePriceItem.Select(s1g + " and " + s2g + " and " + s3g);

            foreach (DataRow dr in drs)
            {
                CItem_Data xItem_Data = new CItem_Data();
                xItem_Data.Set_Price_Item_Stock(dr);
                ID item_id = tf.set_ID(dr[m_cpis.icol_Item_ID]);
                if (ID.Validate(item_id))
                {
                    if (FillStockDataListForEachItemInItems(item_id, xItem_Data))
                    {
                        continue;
                    }
                    else
                    {
                       CStock_Data cstock_data = new CStock_Data();
                        if (ID.Validate(xItem_Data.Stock_ID))
                        {
                            cstock_data.Stock_ID = new ID(xItem_Data.Stock_ID);
                        }
                        else
                        {
                            cstock_data.Stock_ID = null;
                        }

                        if (xItem_Data.Stock_ImportTime_v != null)
                        {
                            cstock_data.Stock_ImportTime = new DBTypes.DateTime_v();
                            cstock_data.Stock_ImportTime.v = xItem_Data.Stock_ImportTime_v.v;
                        }
                        else
                        {
                            cstock_data.Stock_ImportTime = null;
                        }

                        if (xItem_Data.StockTake_Draft_v != null)
                        {
                            cstock_data.StockTake_Draft = new DBTypes.bool_v();
                            cstock_data.StockTake_Draft.v = xItem_Data.StockTake_Draft_v.v;
                        }
                        else
                        {
                            cstock_data.StockTake_Draft = null;
                        }

                        if (xItem_Data.Stock_ExpiryDate_v != null)
                        {
                            cstock_data.Stock_ExpiryDate = new DBTypes.DateTime_v();
                            cstock_data.Stock_ExpiryDate.v = xItem_Data.Stock_ExpiryDate_v.v;
                        }
                        else
                        {
                            cstock_data.Stock_ExpiryDate = null;
                        }

                        if (xItem_Data.Stock_dQuantity_v != null)
                        {
                            cstock_data.dQuantity_v = new DBTypes.decimal_v();
                            cstock_data.dQuantity_v.v = xItem_Data.Stock_dQuantity_v.v;
                        }
                        else
                        {
                            // set stock_ID to null;
                            cstock_data.Stock_ID = null;
                            cstock_data.dQuantity_v = null;
                        }
                        xItem_Data.CStock_Data_List.Add(cstock_data);
                        ListOfCItems.Add(xItem_Data);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopShelf:Set:dr[m_cpis.icol_Item_ID] is not long !");
                }
            }

        }

        public bool Load(DataTable dtPurchasePriceItem, string[] s_name_Group)
        {
          
                m_cpis.Set(dtPurchasePriceItem);
                ListOfItems_Set(dtPurchasePriceItem, s_name_Group);

                dt_Price_Item_Group.Clear();
                dt_Price_Item_Group.Columns.Clear();
                return true;
           

        }

        //public bool Load(DataTable dtPurchasePriceItem, string[] s_name_Group)
        //{
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
        //    string s_group_condition = fs.GetGroupCondition(ref lpar, s_name_Group);
        //    string sql_Stock = sql_Price_Item_Stock_template +/*+ m_PriceList_ID.ToString() + */s_group_condition + " order by ptm.Code asc";
        //    string Err = null;
        //    dt_Price_Item_Stock.Clear();
        //    dt_Price_Item_Stock.Columns.Clear();
        //    dt_Price_Item_Stock.Rows.Clear();
        //    if (DBSync.DBSync.ReadDataTable(ref dt_Price_Item_Stock, sql_Stock, lpar, ref Err))
        //    {
        //        m_cpis.Set(dt_Price_Item_Stock);
        //        ListOfItems_Set();

        //        dt_Price_Item_Group.Clear();
        //        dt_Price_Item_Group.Columns.Clear();
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:usrc_ItemList:m_usrc_Item_Group_Handler_GroupChanged:sql=" + sql_Stock + "\r\nErr=" + Err);
        //        return false;
        //    }

        //}

        /// <summary>
        /// Get item groups of  Price List into the table dt_Price_Item_Group<br/>
        /// </summary>
        /// <param name="PriceList_ID">ID of PriceList table (table PriceList)</param>
        /// <returns>Return true if no DB error
        ///</returns>
        public bool GetGroupsTable()
        {
            string sql = @"  SELECT 
             PurchasePrice_Item_$_i_$_ipg1.Name AS s1_name,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2.Name AS s2_name,
             PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3.Name AS s3_name
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
			left join Stock s on PurchasePrice_Item.ID = s.PurchasePrice_Item_ID
			group by PurchasePrice_Item_$_i_$_ipg1.Name,PurchasePrice_Item_$_i_$_ipg1_$_ipg2.Name,PurchasePrice_Item_$_i_$_ipg1_$_ipg2_$_ipg3.Name";
         //   string sql = @"select 
         //     s1.Name as s1_name,
         //     s2.Name as s2_name,
         //     s3.Name as s3_name
         //     from Price_Item
         //     Inner Join PriceList on Price_Item.PriceList_ID = PriceList.ID
         //     Inner Join Item ptm on Price_Item.Item_ID = ptm.ID
         //     Inner Join Unit on ptm.Unit_ID = Unit.ID
         //     Inner Join Taxation on Price_Item.Taxation_ID =  Taxation.ID
         //     Left Join PurchasePrice_Item putm on putm.Item_ID = ptm.ID
         //     Left Join PurchasePrice on putm.PurchasePrice_ID = PurchasePrice.ID
         //     Left Join Item_Image on ptm.Item_Image_ID = Item_Image.ID
         //     Left Join Expiry on ptm.Expiry_ID = Expiry.ID
         //     Left Join Warranty on ptm.Warranty_ID = Warranty.ID
         //     left Join Stock on   putm.ID = Stock.PurchasePrice_Item_ID
         //     left Join StockTake on putm.StockTake_ID = StockTake.ID 
         //     left Join Supplier on StockTake.Supplier_ID =Supplier.ID 
         //     left Join Contact on Supplier.Contact_ID =Contact.ID 
         //     left Join OrganisationData on Contact.OrganisationData_ID =OrganisationData.ID 
         //     left Join Organisation on OrganisationData.Organisation_ID =Organisation.ID 
         //     left Join cAddress_Org on OrganisationData.cAddress_Org_ID = cAddress_Org.ID
         //     left Join cStreetName_Org on cAddress_Org.cStreetName_Org_ID = cStreetName_Org.ID
         //     left Join cHouseNumber_Org on cAddress_Org.cHouseNumber_Org_ID = cHouseNumber_Org.ID
         //     left Join cCity_Org on cAddress_Org.cCity_Org_ID = cCity_Org.ID
         //     left Join cZIP_Org on cAddress_Org.cZIP_Org_ID = cZIP_Org.ID
         //     left Join cCountry_Org on cAddress_Org.cCountry_Org_ID = cCountry_Org.ID
         //     left Join cState_Org on cAddress_Org.cState_Org_ID = cState_Org.ID
         //     left Join Item_ParentGroup1 s1 ON ptm.Item_ParentGroup1_ID = s1.ID
         //     left Join Item_ParentGroup2 s2 ON s1.Item_ParentGroup2_ID = s2.ID
         //     left Join Item_ParentGroup3 s3 ON s2.Item_ParentGroup3_ID = s3.ID
		       //group by s1.Name,s2.Name,s3.Name";
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

        public int GetIndex(Consumption_ShopC_Item xdsci)
        {
            foreach (CItem_Data idata in ListOfCItems)
            {
                if (idata.Item_UniqueName_v.v.Equals(xdsci.Atom_Item_UniqueName_v.v))
                {
                    int index = ListOfCItems.IndexOf(idata);
                    return index;
                }
            }
            return -1;
        }

        public CItem_Data Get_Item_Data(Consumption_ShopC_Item xdsci)
        {
            foreach (CItem_Data idata in ListOfCItems)
            {
                if (idata.Item_UniqueName_v.v.Equals(xdsci.Atom_Item_UniqueName_v.v))
                {
                    return idata;
                }
            }
            return null;
        }

        public void Set_dQuantity_New_InStock(ID stock_id, decimal dQuantity_New_InStock)
        {
            foreach (object oitem in ListOfCItems)
            {
                if (oitem is CItem_Data)
                {
                    CItem_Data item_data = (CItem_Data)oitem;
                    foreach (CStock_Data stock_data in item_data.CStock_Data_List)
                    {
                        if (ID.Validate(stock_data.Stock_ID))
                        {
                            if (stock_data.Stock_ID.Equals(stock_id))
                            {
                                if (stock_data.dQuantity_v != null)
                                {
                                    stock_data.dQuantity_v.v = dQuantity_New_InStock;
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
