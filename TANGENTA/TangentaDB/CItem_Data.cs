#region LICENSE 
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
    public class CItem_Data
    {
        public string[] m_s_name_Group = null;
        //public decimal nmUpDn_FactoryQuantity_Value = 0;
        public decimal nmUpDn_StockQuantity_Value = 0;
       
        public string_v Currency_Name_v = null;
        public string_v Currency_Abbreviation_v = null;
        public string_v Currency_Symbol_v = null;
        public int_v Currency_DecimalPlaces = null;
        public ID Stock_ID = null;
        public DateTime_v Stock_ExpiryDate_v = null;
        public decimal_v Stock_dQuantity_v = null;
        public decimal PurchasePricePerUnitWithDiscount = 0;
        public decimal_v PurchasePrice_Item_Discount_v = null;
        public DateTime_v Stock_ImportTime_v = null;
        public bool_v StockTake_Draft_v = null;
        public ID Item_ID = null;
        public ID PurchasePrice_Item_ID = null;
        public string_v Item_UniqueName_v = null;
        public string_v Item_Name_v = null;
        public string_v Item_barcode_v = null;
        public ID Item_Image_ID = null;
        public byte_array_v Item_Image_Image_Data_v = null;
        public string_v Item_Image_Image_Hash_v = null;
        public string_v Item_Description_v = null;
        public string_v Unit_Name_v = null;
        public string_v Unit_Symbol_v = null;
        public int_v Unit_DecimalPlaces_v = null;
        public bool_v Unit_StorageOption_v = null;
        public string_v Unit_Description_v = null;
        public int_v Expiry_ExpectedShelfLifeInDays_v = null;
        public int_v Expiry_SaleBeforeExpiryDateInDays_v = null;
        public int_v Expiry_DiscardBeforeExpiryDateInDays_v = null;
        public string_v Expiry_Description_v = null;
        public ID Item_Expiry_ID = null;
        public bool_v Item_ToOffer_v = null;

     

        public ID Item_Warranty_ID = null;
        public string_v Warranty_WarrantyConditions_v = null;
        public int_v Warranty_WarrantyDuration_v = null;
        public short_v Warranty_WarrantyDurationType_v = null;
        public ID Taxation_ID = null;
        public string_v Taxation_Name_v = null;
        public decimal_v Taxation_Rate_v = null;
        public decimal_v PurchasePricePerUnit_v = null;
        public string_v PurchaseOrganisation_Name_v = null;
        public PostAddress_v PurchaseOrganisation_Address_v = new PostAddress_v();
        public DateTime_v ExpiryDate_v;
        public string s1_name = null;
        public string s2_name = null;
        public string s3_name = null;

        public List<CStock_Data> CStock_Data_List = new List<CStock_Data>();

        public decimal Taxation_Rate
        {
            get
            {
                if (Taxation_Rate_v != null)
                {
                    return Taxation_Rate_v.v;
                }
                return 0;
            }
        }

        public string Item_UniqueName
        {
            get
            {
                if (Item_UniqueName_v!=null)
                {
                    return Item_UniqueName_v.v;
                }
                return null;
            }
        }
        public CItem_Data()
        {
        }

        public void Set_Price_Item_Stock(DataRow xdr)
        {
            //Price_Item_ID = tf.set_ID(xdr["Price_Item_ID"]);
            //Price_Item_Discount_v = tf.set_decimal(xdr["Price_Item_Discount"]);
            //PriceList_ID = tf.set_ID(xdr["PriceList_ID"]);
            //PriceList_Name_v = tf.set_string(xdr["PriceList_Name"]);
            Currency_Name_v = tf.set_string(xdr["PurchasePrice_Item_$_pp_$_Cur_$$Name"]); ;
            Currency_Abbreviation_v = tf.set_string(xdr["PurchasePrice_Item_$_pp_$_Cur_$$Abbreviation"]);
            Currency_Symbol_v = tf.set_string(xdr["PurchasePrice_Item_$_pp_$_Cur_$$Symbol"]);
            Currency_DecimalPlaces = tf.set_int(xdr["PurchasePrice_Item_$_pp_$_Cur_$$DecimalPlaces"]);
            Stock_ID = tf.set_ID(xdr["Stock_ID"]);
            Stock_ExpiryDate_v = tf.set_DateTime(xdr["Stock_ExpiryDate"]);
            Stock_dQuantity_v = tf.set_decimal(xdr["Stock_dQuantity"]);
            PurchasePricePerUnit_v = tf.set_decimal(xdr["PurchasePrice_Item_$_pp_$$PurchasePricePerUnit"]);
            PurchasePrice_Item_Discount_v = tf.set_decimal(xdr["PurchasePrice_Item_$_pp_$$Discount"]);
            Stock_ImportTime_v = tf.set_DateTime(xdr["Stock_ImportTime"]);
            StockTake_Draft_v = tf.set_bool(xdr["PurchasePrice_Item_$_st_$$Draft"]);
            Item_ID = tf.set_ID(xdr["PurchasePrice_Item_$_i_$$ID"]);
            PurchasePrice_Item_ID = tf.set_ID(xdr["ID"]);
            Item_UniqueName_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$$UniqueName"]);
            Item_Name_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$$Name"]);
            Item_barcode_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$$barcode"]);
            Item_Image_ID = tf.set_ID(xdr["PurchasePrice_Item_$_i_$$ID"]);
            Item_Image_Image_Data_v = tf.set_byte_array(xdr["PurchasePrice_Item_$_i_$_iimg_$$Image_Data"]);
            Item_Image_Image_Hash_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_iimg_$$Image_Hash"]);
            Item_Description_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$$Description"]);
            Unit_Name_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_u_$$Name"]);
            Unit_Symbol_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_u_$$Symbol"]);
            Unit_DecimalPlaces_v = tf.set_int(xdr["PurchasePrice_Item_$_i_$_u_$$DecimalPlaces"]);
            Unit_StorageOption_v = tf.set_bool(xdr["PurchasePrice_Item_$_i_$_u_$$StorageOption"]);
            Unit_Description_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_u_$$Description"]);
            Expiry_ExpectedShelfLifeInDays_v = tf.set_int(xdr["PurchasePrice_Item_$_i_$_exp_$$ExpectedShelfLifeInDays"]);
            Expiry_SaleBeforeExpiryDateInDays_v = tf.set_int(xdr["PurchasePrice_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays"]);
            Expiry_DiscardBeforeExpiryDateInDays_v = tf.set_int(xdr["PurchasePrice_Item_$_i_$_exp_$$DiscardBeforeExpiryDateInDays"]);
            Expiry_Description_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_exp_$$ExpiryDescription"]);
            Item_Expiry_ID = tf.set_ID(xdr["PurchasePrice_Item_$_i_$_exp_$$ID"]);
            Item_ToOffer_v = tf.set_bool(xdr["PurchasePrice_Item_$_i_$$ToOffer"]);
            Item_Warranty_ID = tf.set_ID(xdr["PurchasePrice_Item_$_i_$_wrty_$$ID"]);
            Warranty_WarrantyConditions_v = tf.set_string(xdr["PurchasePrice_Item_$_i_$_wrty_$$WarrantyConditions"]);
            Warranty_WarrantyDuration_v = tf.set_int(xdr["PurchasePrice_Item_$_i_$_wrty_$$WarrantyDuration"]);
            Warranty_WarrantyDurationType_v = tf.set_short(fs.MyConvertToShort(xdr["PurchasePrice_Item_$_i_$_wrty_$$WarrantyDurationType"]));
            Taxation_ID = tf.set_ID(xdr["PurchasePrice_Item_$_pp_$_tax_$$ID"]);
            Taxation_Name_v = tf.set_string(xdr["PurchasePrice_Item_$_pp_$_tax_$$Name"]);
            Taxation_Rate_v = tf.set_decimal(xdr["PurchasePrice_Item_$_pp_$_tax_$$Rate"]);
            PurchasePricePerUnit_v = tf.set_decimal(xdr["PurchasePrice_Item_$_pp_$$PurchasePricePerUnit"]);
            PurchaseOrganisation_Name_v = tf.set_string(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$Name"]);
            PurchaseOrganisation_Address_v.StreetName_v = tf.set_dstring(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName"]);
            PurchaseOrganisation_Address_v.HouseNumber_v = tf.set_dstring(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber"]);
            PurchaseOrganisation_Address_v.City_v = tf.set_dstring(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg_$$City"]);
            PurchaseOrganisation_Address_v.ZIP_v = tf.set_dstring(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg_$$ZIP"]);
            PurchaseOrganisation_Address_v.Country_v = tf.set_dstring(xdr["PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country"]);
            if (xdr["s1_name"] is string)
            {
                s1_name = (string)xdr["s1_name"];
            }
            if (xdr["s2_name"] is string)
            {
                s2_name = (string)xdr["s2_name"];
            }
            if (xdr["s3_name"] is string)
            {
                s3_name = (string)xdr["s3_name"];
            }
        }

        internal CStock_Data Find_Stock_Data(ID stock_ID)
        {
            foreach (CStock_Data cstock_data in this.CStock_Data_List)
            {
                if (ID.Validate(cstock_data.Stock_ID))
                {
                    if (cstock_data.Stock_ID.Equals(stock_ID))
                    {
                        return cstock_data;
                    }
                }
            }
            return null;
        }

        public decimal dQuantity_OfCStockItems
        {
            get
            {
                decimal d = 0;
                foreach (CStock_Data stock_data in this.CStock_Data_List)
                {
                    if (stock_data.Stock_ID != null)
                    {
                        if (stock_data.StockTake_Draft != null)
                        {
                            if (stock_data.StockTake_Draft.v == false)
                            {
                                if (stock_data.dQuantity_v != null)
                                {
                                    d += stock_data.dQuantity_v.v;
                                }
                            }
                        }
                    }
                }
                return d;
            }
        }

        //public decimal Discount {
        //    get
        //    {
        //        if (this.Price_Item_Discount_v!=null)
        //        {
        //            return Price_Item_Discount_v.v;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}

        public void SetNewStock(ID stock_ID, decimal dnewinstock)
        {
           foreach(CStock_Data std in this.CStock_Data_List)
           {
                if ((std.Stock_ID==null)&&(std.dQuantity_v==null))
                {
                    std.Stock_ID = tf.set_ID(stock_ID);
                    std.dQuantity_v = tf.set_decimal(dnewinstock);
                    return;
                }
           }

            CStock_Data xstd = new CStock_Data();
            xstd.Stock_ID = tf.set_ID(stock_ID);
            xstd.dQuantity_v = tf.set_decimal(dnewinstock);
            this.CStock_Data_List.Add(xstd);

        }

        internal bool ReceiveBackToStock(ID stock_ID, decimal xdQuantity, Transaction transaction)
        {
            if (ID.Validate(stock_ID))
            {
                foreach (CStock_Data std in this.CStock_Data_List)
                {
                    if (ID.Validate(std.Stock_ID))
                    {
                        if (std.Stock_ID.Equals(stock_ID))
                        {
                            if (std.dQuantity_v==null)
                            {
                                std.dQuantity_v = new decimal_v();
                            }
                            decimal dnew_quantity_in_stock = std.dQuantity_v.v + xdQuantity;
                            if (f_Stock.UpdateQuantity(stock_ID, dnew_quantity_in_stock, transaction))
                            {
                                std.dQuantity_v.v = dnew_quantity_in_stock;
                                return true;
                            }
                        }
                    }
                    //else
                    //{
                    //    LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:std.Stock_ID is not valid!");
                    //}
                    //return true;
                }
                // THIS ITEM has no stock his it is FACTORY ITEM
                //LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:stock_ID was not found in m_ShopSehlf!!");
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:stock_ID is not valid!");

            }
            return false;
        }

        internal CStock_Data Find_Stock_Data(CStock_Data stdtaken)
        {
            if (ID.Validate(stdtaken.Stock_ID))
            {
                foreach (CStock_Data stdx in this.CStock_Data_List)
                {
                    if (ID.Validate(stdx.Stock_ID))
                    {
                        if (stdx.Stock_ID.Equals(stdtaken.Stock_ID))
                        {
                            return stdx;
                        }
                    }
                }
            }
            return null;
        }
    }
}
