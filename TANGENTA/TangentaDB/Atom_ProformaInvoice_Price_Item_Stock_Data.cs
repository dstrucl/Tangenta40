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
    public class Atom_DocInvoice_ShopC_Item_Price_Stock_Data
    {
        public ID DocInvoice_ShopC_Item_ID = null;
        public ID DocInvoice_ID = null;
        public ID Atom_Price_Item_ID = null;
        public ID Atom_Item_ID = null;
        public decimal_v RetailPricePerUnit = null;
        public decimal_v Discount = null;
        public decimal_v RetailPriceWithDiscount = null;
        public decimal_v TaxPrice = null;
        public decimal_v ExtraDiscount = null;
        public decimal_v dQuantity_all = null;
        public string_v Atom_Item_Name_Name = null;
        public string_v Atom_Item_UniqueName = null;
        public string_v Atom_Item_barcode_barcode = null;
        public string_v Atom_Taxation_Name = null;
        public decimal_v Atom_Taxation_Rate = null;
        public string_v Atom_Item_Description_Description = null;
        public ID Atom_Warranty_ID = null;
        public string_v Atom_Warranty_WarrantyConditions = null;
        public short_v Atom_Warranty_WarrantyDurationType = null;
        public int_v Atom_Warranty_WarrantyDuration = null;
        public ID Atom_Expiry_ID = null;
        public int_v Atom_Expiry_ExpectedShelfLifeInDays = null;
        public int_v Atom_Expiry_SaleBeforeExpiryDateInDays = null;
        public int_v Atom_Expiry_DiscardBeforeExpiryDateInDays = null;
        public string_v Atom_Expiry_ExpiryDescription = null;
        public ID Item_ID = null;
        public string s1_name = null;
        public string s2_name = null;
        public string s3_name = null;

        public ShopShelf_Source m_ShopShelf_Source = new ShopShelf_Source();

        public string_v Atom_Unit_Name = null;
        public string_v Atom_Unit_Symbol = null;
        public int_v Atom_Unit_DecimalPlaces = null;
        public string_v Atom_Unit_Description = null;
        public bool_v Atom_Unit_StorageOption = null;

        public string_v Atom_PriceList_Name = null;
        public string_v Atom_Currency_Name = null;
        public string_v Atom_Currency_Abbreviation = null;
        public string_v Atom_Currency_Symbol = null;
        public int_v Atom_Currency_DecimalPlaces = null;

        public string_v Atom_Item_Image_Hash = null;
        public byte_array_v Atom_Item_Image_Data = null;


        public decimal dQuantity_FromStock
        {
            get
            {
                return m_ShopShelf_Source.dQuantity_from_stock;
            }
        }

        public decimal dQuantity_FromFactory
        {
            get
            {
                return m_ShopShelf_Source.dQuantity_from_factory;
            }
        }

        public void Set(string DocTyp, DataRow dria,
                            ref List<object> DocInvoice_ShopC_Item_Data_list)
        {
            Stock_Data stock_data = null;
            int i = 0;
            int iCount = DocInvoice_ShopC_Item_Data_list.Count;
            Atom_Item_ID = new ID(dria["Atom_Item_ID"]);

            if (ID.Validate(Atom_Item_ID))
            {
                for (i = 0; i < iCount; i++)
                {
                    if (((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)DocInvoice_ShopC_Item_Data_list[i]).Atom_Item_ID.Equals(Atom_Item_ID))
                    {
                        stock_data = new Stock_Data();
                        stock_data.Set(dria);
                        ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)DocInvoice_ShopC_Item_Data_list[i]).m_ShopShelf_Source.Stock_Data_List.Add(stock_data);
                        return;
                    }
                }

                m_ShopShelf_Source.Clear();
                DocInvoice_ShopC_Item_ID = new ID(dria[DocTyp+"_ShopC_Item_ID"]);
                DocInvoice_ID = new ID(dria[DocTyp+"_ID"]);
                Atom_Price_Item_ID = new ID(dria["Atom_Price_Item_ID"]);
                dQuantity_all = tf.set_decimal(dria["dQuantity"]);
                RetailPricePerUnit = tf.set_decimal(dria["RetailPricePerUnit"]);
                Discount = tf.set_decimal(dria["Discount"]);
                RetailPriceWithDiscount = tf.set_decimal(dria["RetailPriceWithDiscount"]);
                TaxPrice = tf.set_decimal(dria["TaxPrice"]);
                ExtraDiscount = tf.set_decimal(dria["ExtraDiscount"]);
                //dQuantity = tf.set_decimal(dria["dQuantity"]);
                Atom_Item_UniqueName = tf.set_string(dria["Atom_Item_UniqueName"]);
                Atom_Item_Name_Name = tf.set_string(dria["Atom_Item_Name_Name"]);
                Atom_Item_barcode_barcode = tf.set_string(dria["Atom_Item_barcode_barcode"]);
                Atom_Taxation_Name = tf.set_string(dria["Atom_Taxation_Name"]);
                Atom_Taxation_Rate = tf.set_decimal(dria["Atom_Taxation_Rate"]);
                Atom_Item_Description_Description = tf.set_string(dria["Atom_Item_Description_Description"]);
                Atom_Warranty_ID = tf.set_ID(dria["Atom_Warranty_ID"]);
                Atom_Warranty_WarrantyDurationType = tf.set_short(dria["Atom_Warranty_WarrantyDurationType"]);
                Atom_Warranty_WarrantyDuration = tf.set_int(dria["Atom_Warranty_WarrantyDuration"]);
                Atom_Warranty_WarrantyConditions = tf.set_string(dria["Atom_Warranty_WarrantyConditions"]);
                Atom_Expiry_ID = tf.set_ID(dria["Atom_Expiry_ID"]);
                Atom_Expiry_ExpectedShelfLifeInDays = tf.set_int(dria["Atom_Expiry_ExpectedShelfLifeInDays"]);
                Atom_Expiry_SaleBeforeExpiryDateInDays = tf.set_int(dria["Atom_Expiry_SaleBeforeExpiryDateInDays"]);
                Atom_Expiry_DiscardBeforeExpiryDateInDays = tf.set_int(dria["Atom_Expiry_DiscardBeforeExpiryDateInDays"]);
                Atom_Expiry_ExpiryDescription = tf.set_string(dria["Atom_Expiry_ExpiryDescription"]);
                Item_ID = tf.set_ID(dria["Item_ID"]);
                Atom_Unit_Name = tf.set_string(dria["Atom_Unit_Name"]);
                Atom_Unit_Symbol = tf.set_string(dria["Atom_Unit_Symbol"]);
                Atom_Unit_DecimalPlaces = tf.set_int(dria["Atom_Unit_DecimalPlaces"]);
                Atom_Unit_Description = tf.set_string(dria["Atom_Unit_Description"]);
                Atom_Unit_StorageOption = tf.set_bool(dria["Atom_Unit_StorageOption"]);
                Atom_PriceList_Name = tf.set_string(dria["Atom_PriceList_Name"]);
                Atom_Currency_Name = tf.set_string(dria["Atom_Currency_Name"]);
                Atom_Currency_Abbreviation = tf.set_string(dria["Atom_Currency_Abbreviation"]);
                Atom_Currency_Symbol = tf.set_string(dria["Atom_Currency_Symbol"]);
                Atom_Currency_DecimalPlaces = tf.set_int(dria["Atom_Currency_DecimalPlaces"]);
                Atom_Item_Image_Hash = tf.set_string(dria["Atom_Item_Image_Hash"]);
                Atom_Item_Image_Data = tf.set_byte_array(dria["Atom_Item_Image_Data"]);
                if (dria["s1_name"] is string)
                {
                    s1_name = (string)dria["s1_name"];
                }
                if (dria["s2_name"] is string)
                {
                    s2_name = (string)dria["s2_name"];
                }
                if (dria["s3_name"] is string)
                {
                    s3_name = (string)dria["s3_name"];
                }

                stock_data = new Stock_Data();
                stock_data.Set(dria);
                m_ShopShelf_Source.Stock_Data_List.Add(stock_data);

                DocInvoice_ShopC_Item_Data_list.Add(this);
            }
            else
            {
                LogFile.Error.Show("ERROR:DocInvoice_ShopC_Item_Data:Set(DataRow dria,..):Atom_Item_ID == null");
            }
        }


        public void Set(Item_Data xItem_Data,
                        ID xDocInvoice_ID,
                        decimal xFactoryQuantity,
                        decimal xStockQuantity,
                        ID docInvoice_ShopC_Item_ID,
                        bool b_from_factory)
        {
            m_ShopShelf_Source.Clear();
            DocInvoice_ShopC_Item_ID = docInvoice_ShopC_Item_ID;
            DocInvoice_ID = new ID();
            DocInvoice_ID.Set(xDocInvoice_ID);
            Atom_Price_Item_ID = null; // tf.set_long(dria["Atom_Price_Item_ID"]);


            RetailPricePerUnit = (decimal_v)tf.Copy(xItem_Data.RetailPricePerUnit); //tf.set_decimal(dr[cpis.icol_RetailPricePerUnit]);

            Discount = (decimal_v)tf.Copy(xItem_Data.Price_Item_Discount); // tf.set_decimal(dr[cpis.icol_Discount]);

            decimal retail_price_with_discount = 0;
            RetailPriceWithDiscount = tf.set_decimal(retail_price_with_discount);
            //$$TODO

            decimal tax_price = 0;
            TaxPrice = tf.set_decimal(tax_price);

            ExtraDiscount = tf.set_decimal(xItem_Data.ExtraDiscount);

            Atom_Item_UniqueName = (string_v)tf.Copy(xItem_Data.Item_UniqueName);// tf.set_string(dr[cpis.icol_Item_UniqueName]);

            Atom_Item_Name_Name = (string_v)tf.Copy(xItem_Data.Item_Name);//tf.set_string(dr[cpis.icol_Item_Name]);
            Atom_Item_barcode_barcode = (string_v)tf.Copy(xItem_Data.Item_barcode);//tf.set_string(dr[cpis.icol_Item_barcode]);
            Atom_Taxation_Name = (string_v)tf.Copy(xItem_Data.Taxation_Name);//tf.set_string(dr[cpis.icol_Taxation_Name]);
            Atom_Taxation_Rate = (decimal_v)tf.Copy(xItem_Data.Taxation_Rate);//tf.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Atom_Item_Description_Description = (string_v)tf.Copy(xItem_Data.Item_Description);//tf.set_string(dr[cpis.icol_Item_Description]);
            Atom_Warranty_ID = null; //tf.set_long(dria["Atom_Warranty_ID"]);
            Atom_Warranty_WarrantyDurationType = (short_v)tf.Copy(xItem_Data.Warranty_WarrantyDurationType);//tf.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            Atom_Warranty_WarrantyDuration = (int_v)tf.Copy(xItem_Data.Warranty_WarrantyDuration);//tf.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            Atom_Warranty_WarrantyConditions = (string_v)tf.Copy(xItem_Data.Warranty_WarrantyConditions);//tf.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Atom_Expiry_ID = null; //tf.set_long(dr["Atom_Expiry_ID"]);
            Atom_Expiry_ExpectedShelfLifeInDays = (int_v)tf.Copy(xItem_Data.Expiry_ExpectedShelfLifeInDays);//tf.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Atom_Expiry_SaleBeforeExpiryDateInDays = (int_v)tf.Copy(xItem_Data.Expiry_SaleBeforeExpiryDateInDays);//tf.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Atom_Expiry_DiscardBeforeExpiryDateInDays = (int_v)tf.Copy(xItem_Data.Expiry_DiscardBeforeExpiryDateInDays);//tf.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Atom_Expiry_ExpiryDescription = (string_v)tf.Copy(xItem_Data.Expiry_Description);//tf.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
            Item_ID= tf.set_ID(xItem_Data.Item_ID);//tf.set_long(dr["Item_ID"]);
            Atom_Unit_Name = (string_v)tf.Copy(xItem_Data.Unit_Name);//tf.set_string(dr[cpis.icol_Unit_Name]);
            Atom_Unit_Symbol = (string_v)tf.Copy(xItem_Data.Unit_Symbol);//tf.set_string(dr[cpis.icol_Unit_Symbol]);
            Atom_Unit_DecimalPlaces = (int_v)tf.Copy(xItem_Data.Unit_DecimalPlaces);//tf.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Atom_Unit_Description = (string_v)tf.Copy(xItem_Data.Unit_Description);//tf.set_string(dr[cpis.icol_Unit_Description]);
            Atom_Unit_StorageOption = (bool_v)tf.Copy(xItem_Data.Unit_StorageOption);//tf.set_bool(dr[cpis.icol_Unit_StorageOption]);
            Atom_PriceList_Name = (string_v)tf.Copy(xItem_Data.PriceList_Name);//tf.set_string(dr[cpis.icol_PriceList_Name]);
            Atom_Currency_Name = (string_v)tf.Copy(xItem_Data.Currency_Name);// tf.set_string(dr[cpis.icol_Currency_Name]);
            Atom_Currency_Abbreviation = (string_v)tf.Copy(xItem_Data.Currency_Abbreviation);//tf.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Atom_Currency_Symbol = (string_v)tf.Copy(xItem_Data.Currency_Symbol);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces = (int_v)tf.Copy(xItem_Data.Currency_DecimalPlaces);//tf.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash = (string_v)tf.Copy(xItem_Data.Item_Image_Image_Hash);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data = (byte_array_v)tf.Copy(xItem_Data.Item_Image_Image_Data);//Itemtf.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xItem_Data.s1_name;
            s2_name = xItem_Data.s2_name;
            s3_name = xItem_Data.s3_name;
            m_ShopShelf_Source.Add_Stock_Data(xItem_Data, xFactoryQuantity, xStockQuantity, b_from_factory);
        }

        public void Set_WithNoTakeForItemData(Item_Data xItem_Data,
                        ID xDocInvoice_ID,
                        decimal xFactoryQuantity,
                        decimal xStockQuantity,
                        ID docInvoice_ShopC_Item_ID,
                        bool b_from_factory)
        {
            m_ShopShelf_Source.Clear();
            DocInvoice_ShopC_Item_ID = docInvoice_ShopC_Item_ID;
            DocInvoice_ID = new ID();
            DocInvoice_ID.Set(xDocInvoice_ID);
            Atom_Price_Item_ID = null; // tf.set_long(dria["Atom_Price_Item_ID"]);


            RetailPricePerUnit = (decimal_v)tf.Copy(xItem_Data.RetailPricePerUnit); //tf.set_decimal(dr[cpis.icol_RetailPricePerUnit]);

            Discount = (decimal_v)tf.Copy(xItem_Data.Price_Item_Discount); // tf.set_decimal(dr[cpis.icol_Discount]);

            decimal retail_price_with_discount = 0;
            RetailPriceWithDiscount = tf.set_decimal(retail_price_with_discount);
            //$$TODO

            decimal tax_price = 0;
            TaxPrice = tf.set_decimal(tax_price);

            ExtraDiscount = tf.set_decimal(xItem_Data.ExtraDiscount);

            Atom_Item_UniqueName = (string_v)tf.Copy(xItem_Data.Item_UniqueName);// tf.set_string(dr[cpis.icol_Item_UniqueName]);

            Atom_Item_Name_Name = (string_v)tf.Copy(xItem_Data.Item_Name);//tf.set_string(dr[cpis.icol_Item_Name]);
            Atom_Item_barcode_barcode = (string_v)tf.Copy(xItem_Data.Item_barcode);//tf.set_string(dr[cpis.icol_Item_barcode]);
            Atom_Taxation_Name = (string_v)tf.Copy(xItem_Data.Taxation_Name);//tf.set_string(dr[cpis.icol_Taxation_Name]);
            Atom_Taxation_Rate = (decimal_v)tf.Copy(xItem_Data.Taxation_Rate);//tf.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Atom_Item_Description_Description = (string_v)tf.Copy(xItem_Data.Item_Description);//tf.set_string(dr[cpis.icol_Item_Description]);
            Atom_Warranty_ID = null; //tf.set_long(dria["Atom_Warranty_ID"]);
            Atom_Warranty_WarrantyDurationType = (short_v)tf.Copy(xItem_Data.Warranty_WarrantyDurationType);//tf.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            Atom_Warranty_WarrantyDuration = (int_v)tf.Copy(xItem_Data.Warranty_WarrantyDuration);//tf.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            Atom_Warranty_WarrantyConditions = (string_v)tf.Copy(xItem_Data.Warranty_WarrantyConditions);//tf.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Atom_Expiry_ID = null; //tf.set_long(dr["Atom_Expiry_ID"]);
            Atom_Expiry_ExpectedShelfLifeInDays = (int_v)tf.Copy(xItem_Data.Expiry_ExpectedShelfLifeInDays);//tf.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Atom_Expiry_SaleBeforeExpiryDateInDays = (int_v)tf.Copy(xItem_Data.Expiry_SaleBeforeExpiryDateInDays);//tf.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Atom_Expiry_DiscardBeforeExpiryDateInDays = (int_v)tf.Copy(xItem_Data.Expiry_DiscardBeforeExpiryDateInDays);//tf.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Atom_Expiry_ExpiryDescription = (string_v)tf.Copy(xItem_Data.Expiry_Description);//tf.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
            Item_ID = tf.set_ID(xItem_Data.Item_ID);//tf.set_long(dr["Item_ID"]);
            Atom_Unit_Name = (string_v)tf.Copy(xItem_Data.Unit_Name);//tf.set_string(dr[cpis.icol_Unit_Name]);
            Atom_Unit_Symbol = (string_v)tf.Copy(xItem_Data.Unit_Symbol);//tf.set_string(dr[cpis.icol_Unit_Symbol]);
            Atom_Unit_DecimalPlaces = (int_v)tf.Copy(xItem_Data.Unit_DecimalPlaces);//tf.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Atom_Unit_Description = (string_v)tf.Copy(xItem_Data.Unit_Description);//tf.set_string(dr[cpis.icol_Unit_Description]);
            Atom_Unit_StorageOption = (bool_v)tf.Copy(xItem_Data.Unit_StorageOption);//tf.set_bool(dr[cpis.icol_Unit_StorageOption]);
            Atom_PriceList_Name = (string_v)tf.Copy(xItem_Data.PriceList_Name);//tf.set_string(dr[cpis.icol_PriceList_Name]);
            Atom_Currency_Name = (string_v)tf.Copy(xItem_Data.Currency_Name);// tf.set_string(dr[cpis.icol_Currency_Name]);
            Atom_Currency_Abbreviation = (string_v)tf.Copy(xItem_Data.Currency_Abbreviation);//tf.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Atom_Currency_Symbol = (string_v)tf.Copy(xItem_Data.Currency_Symbol);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces = (int_v)tf.Copy(xItem_Data.Currency_DecimalPlaces);//tf.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash = (string_v)tf.Copy(xItem_Data.Item_Image_Image_Hash);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data = (byte_array_v)tf.Copy(xItem_Data.Item_Image_Image_Data);//Itemtf.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xItem_Data.s1_name;
            s2_name = xItem_Data.s2_name;
            s3_name = xItem_Data.s3_name;
            m_ShopShelf_Source.Add_Stock_Data_WithNoTakeForItemData(xItem_Data, xFactoryQuantity, xStockQuantity, b_from_factory);
        }
        public void AddQuantity(ID doc_ShopC_Item_ID,ID stock_ID, decimal dqAdd)
        {
            foreach (Stock_Data std in m_ShopShelf_Source.Stock_Data_List)
            {
                if (ID.Validate(std.Stock_ID))
                {
                    if (std.Stock_ID.Equals(stock_ID))
                    {
                        decimal dqcur = std.dQuantity_v.v;
                        std.dQuantity_v.v = dqcur+ dqAdd;
                    }
                }
            }
        }

        public void Add_Doc_ShopC_Item(Item_Data xData, decimal xdQuantity, ID stock_ID,ID atom_Price_Item_ID)
        {
            decimal retailPricePerunit = 0;
            if (xData.RetailPricePerUnit != null)
            {
                retailPricePerunit = xData.RetailPricePerUnit.v;
            }
            decimal taxRate = 0;
            if (xData.Taxation_Rate != null)
            {
                taxRate = xData.Taxation_Rate.v;
            }

            decimal retailPriceWithDisount = decimal.Round(retailPricePerunit * xdQuantity * (1 - xData.ExtraDiscount), GlobalData.BaseCurrency.DecimalPlaces);
            decimal netprice = decimal.Round(retailPriceWithDisount / (1 + taxRate), GlobalData.BaseCurrency.DecimalPlaces);
            decimal taxprice = retailPriceWithDisount - netprice;
            //ID docInvoice_ShopC_Item = null;
            decimal_v extraDiscount_v = new decimal_v(xData.ExtraDiscount);

            if (ID.Validate(stock_ID))
            {
                this.m_ShopShelf_Source.Add_Stock_Data(stock_ID, xdQuantity);
            }
        }

        public Stock_Data From_FactoryItems()
        {
            foreach (Stock_Data std in m_ShopShelf_Source.Stock_Data_List)
            {
                if (std.Stock_ID == null)
                {
                    return std;
                }
            }
            return null;
        }

        public void GetPrices(
                        ref decimal Discount, 
                        ref decimal ExtraDiscount, 
                        ref decimal RetailPrice, 
                        ref decimal RetailPriceWithDiscount,
                        ref decimal TaxPrice,
                        ref string TaxName,
                        ref decimal TaxRate,
                        ref decimal NetPrice)
        {
            decimal dquantity_all = 0;
            decimal RetailPricePerUnit = 0;
            int i = 0;
            int iCount = this.m_ShopShelf_Source.Stock_Data_List.Count;
            Discount = this.Discount.v;
            ExtraDiscount = this.ExtraDiscount.v;
            RetailPricePerUnit = this.RetailPricePerUnit.v;
            TaxRate = this.Atom_Taxation_Rate.v;
            if (TaxName == null)
            {
                TaxName = this.Atom_Taxation_Name.v;
            }

            if (iCount > 0)
            {
                for (i = 0; i < iCount; i++)
                {
                    Stock_Data stock_data = this.m_ShopShelf_Source.Stock_Data_List[i];
                    if (stock_data.Stock_ID != null)
                    {
                        dquantity_all += stock_data.dQuantity_from_stock.v;
                    }
                    else
                    {
                        dquantity_all += stock_data.dQuantity_from_factory.v;
                    }
                }
                RetailPrice = RetailPricePerUnit * dquantity_all;
                int decimal_places = 2;
                if (GlobalData.BaseCurrency != null)
                {
                    decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                }
                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dquantity_all, Discount, ExtraDiscount, TaxRate, ref RetailPriceWithDiscount, ref TaxPrice, ref NetPrice, decimal_places);
            }
        }

    }
}
