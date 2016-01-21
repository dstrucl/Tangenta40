using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class Atom_ProformaInvoice_Price_Item_Stock_Data
    {
        public long_v Atom_ProformaInvoice_Price_Item_Stock_ID = null;
        public long_v ProformaInvoice_ID = null;
        public long_v Atom_Price_Item_ID = null;
        public long_v Atom_Item_ID = null;
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
        public long_v Atom_Warranty_ID = null;
        public string_v Atom_Warranty_WarrantyConditions = null;
        public short_v Atom_Warranty_WarrantyDurationType = null;
        public int_v Atom_Warranty_WarrantyDuration = null;
        public long_v Atom_Expiry_ID = null;
        public int_v Atom_Expiry_ExpectedShelfLifeInDays = null;
        public int_v Atom_Expiry_SaleBeforeExpiryDateInDays = null;
        public int_v Atom_Expiry_DiscardBeforeExpiryDateInDays = null;
        public string_v Atom_Expiry_ExpiryDescription = null;
        public long_v Item_ID = null;
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

        public void Set(DataRow dria,
                            ref List<object> Atom_ProformaInvoice_Price_Item_Stock_Data_list)
        {
            Stock_Data stock_data = null;
            int i = 0;
            int iCount = Atom_ProformaInvoice_Price_Item_Stock_Data_list.Count;
            Atom_Item_ID = func.set_long(dria["Atom_Item_ID"]);

            if (Atom_Item_ID != null)
            {
                for (i = 0; i < iCount; i++)
                {
                    if (((Atom_ProformaInvoice_Price_Item_Stock_Data)Atom_ProformaInvoice_Price_Item_Stock_Data_list[i]).Atom_Item_ID.v == Atom_Item_ID.v)
                    {
                        stock_data = new Stock_Data();
                        stock_data.Set(dria);
                        ((Atom_ProformaInvoice_Price_Item_Stock_Data)Atom_ProformaInvoice_Price_Item_Stock_Data_list[i]).m_ShopShelf_Source.Stock_Data_List.Add(stock_data);
                        return;
                    }
                }

                m_ShopShelf_Source.Clear();
                Atom_ProformaInvoice_Price_Item_Stock_ID = func.set_long(dria["Atom_ProformaInvoice_Price_Item_Stock_ID"]);
                ProformaInvoice_ID = func.set_long(dria["ProformaInvoice_ID"]);
                Atom_Price_Item_ID = func.set_long(dria["Atom_Price_Item_ID"]);
                dQuantity_all = func.set_decimal(dria["dQuantity"]);
                RetailPricePerUnit = func.set_decimal(dria["RetailPricePerUnit"]);
                Discount = func.set_decimal(dria["Discount"]);
                RetailPriceWithDiscount = func.set_decimal(dria["RetailPriceWithDiscount"]);
                TaxPrice = func.set_decimal(dria["TaxPrice"]);
                ExtraDiscount = func.set_decimal(dria["ExtraDiscount"]);
                //dQuantity = func.set_decimal(dria["dQuantity"]);
                Atom_Item_UniqueName = func.set_string(dria["Atom_Item_UniqueName"]);
                Atom_Item_Name_Name = func.set_string(dria["Atom_Item_Name_Name"]);
                Atom_Item_barcode_barcode = func.set_string(dria["Atom_Item_barcode_barcode"]);
                Atom_Taxation_Name = func.set_string(dria["Atom_Taxation_Name"]);
                Atom_Taxation_Rate = func.set_decimal(dria["Atom_Taxation_Rate"]);
                Atom_Item_Description_Description = func.set_string(dria["Atom_Item_Description_Description"]);
                Atom_Warranty_ID = func.set_long(dria["Atom_Warranty_ID"]);
                Atom_Warranty_WarrantyDurationType = func.set_short(dria["Atom_Warranty_WarrantyDurationType"]);
                Atom_Warranty_WarrantyDuration = func.set_int(dria["Atom_Warranty_WarrantyDuration"]);
                Atom_Warranty_WarrantyConditions = func.set_string(dria["Atom_Warranty_WarrantyConditions"]);
                Atom_Expiry_ID = func.set_long(dria["Atom_Expiry_ID"]);
                Atom_Expiry_ExpectedShelfLifeInDays = func.set_int(dria["Atom_Expiry_ExpectedShelfLifeInDays"]);
                Atom_Expiry_SaleBeforeExpiryDateInDays = func.set_int(dria["Atom_Expiry_SaleBeforeExpiryDateInDays"]);
                Atom_Expiry_DiscardBeforeExpiryDateInDays = func.set_int(dria["Atom_Expiry_DiscardBeforeExpiryDateInDays"]);
                Atom_Expiry_ExpiryDescription = func.set_string(dria["Atom_Expiry_ExpiryDescription"]);
                Item_ID = func.set_long(dria["Item_ID"]);
                Atom_Unit_Name = func.set_string(dria["Atom_Unit_Name"]);
                Atom_Unit_Symbol = func.set_string(dria["Atom_Unit_Symbol"]);
                Atom_Unit_DecimalPlaces = func.set_int(dria["Atom_Unit_DecimalPlaces"]);
                Atom_Unit_Description = func.set_string(dria["Atom_Unit_Description"]);
                Atom_Unit_StorageOption = func.set_bool(dria["Atom_Unit_StorageOption"]);
                Atom_PriceList_Name = func.set_string(dria["Atom_PriceList_Name"]);
                Atom_Currency_Name = func.set_string(dria["Atom_Currency_Name"]);
                Atom_Currency_Abbreviation = func.set_string(dria["Atom_Currency_Abbreviation"]);
                Atom_Currency_Symbol = func.set_string(dria["Atom_Currency_Symbol"]);
                Atom_Currency_DecimalPlaces = func.set_int(dria["Atom_Currency_DecimalPlaces"]);
                Atom_Item_Image_Hash = func.set_string(dria["Atom_Item_Image_Hash"]);
                Atom_Item_Image_Data = func.set_byte_array(dria["Atom_Item_Image_Data"]);
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

                Atom_ProformaInvoice_Price_Item_Stock_Data_list.Add(this);
            }
            else
            {
                LogFile.Error.Show("ERROR:Atom_ProformaInvoice_Price_Item_Stock_Data:Set(DataRow dria,..):Atom_Item_ID == null");
            }
        }


        public void Set(object xusrc_Item, Item_Data xItem_Data,long xProformaInvoice_ID, decimal xFactoryQuantity, decimal xStockQuantity, bool b_from_factory)
        {
            m_ShopShelf_Source.Clear();
            Atom_ProformaInvoice_Price_Item_Stock_ID = null;
            ProformaInvoice_ID = new long_v();
            ProformaInvoice_ID.v = xProformaInvoice_ID;
            Atom_Price_Item_ID = null; // func.set_long(dria["Atom_Price_Item_ID"]);


            RetailPricePerUnit = (decimal_v)func.Copy(xItem_Data.RetailPricePerUnit); //func.set_decimal(dr[cpis.icol_RetailPricePerUnit]);

            Discount = (decimal_v)func.Copy(xItem_Data.Price_Item_Discount); // func.set_decimal(dr[cpis.icol_Discount]);

            decimal retail_price_with_discount = 0;
            RetailPriceWithDiscount = func.set_decimal(retail_price_with_discount);
            //$$TODO

            decimal tax_price = 0;
            TaxPrice = func.set_decimal(tax_price);

            ExtraDiscount = func.set_decimal(xItem_Data.ExtraDiscount);

            Atom_Item_UniqueName = (string_v)func.Copy(xItem_Data.Item_UniqueName);// func.set_string(dr[cpis.icol_Item_UniqueName]);

            Atom_Item_Name_Name = (string_v)func.Copy(xItem_Data.Item_Name);//func.set_string(dr[cpis.icol_Item_Name]);
            Atom_Item_barcode_barcode = (string_v)func.Copy(xItem_Data.Item_barcode);//func.set_string(dr[cpis.icol_Item_barcode]);
            Atom_Taxation_Name = (string_v)func.Copy(xItem_Data.Taxation_Name);//func.set_string(dr[cpis.icol_Taxation_Name]);
            Atom_Taxation_Rate = (decimal_v)func.Copy(xItem_Data.Taxation_Rate);//func.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Atom_Item_Description_Description = (string_v)func.Copy(xItem_Data.Item_Description);//func.set_string(dr[cpis.icol_Item_Description]);
            Atom_Warranty_ID = null; //func.set_long(dria["Atom_Warranty_ID"]);
            Atom_Warranty_WarrantyDurationType = (short_v)func.Copy(xItem_Data.Warranty_WarrantyDurationType);//func.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            Atom_Warranty_WarrantyDuration = (int_v)func.Copy(xItem_Data.Warranty_WarrantyDuration);//func.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            Atom_Warranty_WarrantyConditions = (string_v)func.Copy(xItem_Data.Warranty_WarrantyConditions);//func.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Atom_Expiry_ID = null; //func.set_long(dr["Atom_Expiry_ID"]);
            Atom_Expiry_ExpectedShelfLifeInDays = (int_v)func.Copy(xItem_Data.Expiry_ExpectedShelfLifeInDays);//func.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Atom_Expiry_SaleBeforeExpiryDateInDays = (int_v)func.Copy(xItem_Data.Expiry_SaleBeforeExpiryDateInDays);//func.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Atom_Expiry_DiscardBeforeExpiryDateInDays = (int_v)func.Copy(xItem_Data.Expiry_DiscardBeforeExpiryDateInDays);//func.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Atom_Expiry_ExpiryDescription = (string_v)func.Copy(xItem_Data.Expiry_Description);//func.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
            Item_ID = (long_v)func.Copy(xItem_Data.Item_ID);//func.set_long(dr["Item_ID"]);
            Atom_Unit_Name = (string_v)func.Copy(xItem_Data.Unit_Name);//func.set_string(dr[cpis.icol_Unit_Name]);
            Atom_Unit_Symbol = (string_v)func.Copy(xItem_Data.Unit_Symbol);//func.set_string(dr[cpis.icol_Unit_Symbol]);
            Atom_Unit_DecimalPlaces = (int_v)func.Copy(xItem_Data.Unit_DecimalPlaces);//func.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Atom_Unit_Description = (string_v)func.Copy(xItem_Data.Unit_Description);//func.set_string(dr[cpis.icol_Unit_Description]);
            Atom_Unit_StorageOption = (bool_v)func.Copy(xItem_Data.Unit_StorageOption);//func.set_bool(dr[cpis.icol_Unit_StorageOption]);
            Atom_PriceList_Name = (string_v)func.Copy(xItem_Data.PriceList_Name);//func.set_string(dr[cpis.icol_PriceList_Name]);
            Atom_Currency_Name = (string_v)func.Copy(xItem_Data.Currency_Name);// func.set_string(dr[cpis.icol_Currency_Name]);
            Atom_Currency_Abbreviation = (string_v)func.Copy(xItem_Data.Currency_Abbreviation);//func.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Atom_Currency_Symbol = (string_v)func.Copy(xItem_Data.Currency_Symbol);//func.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces = (int_v)func.Copy(xItem_Data.Currency_DecimalPlaces);//func.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash = (string_v)func.Copy(xItem_Data.Item_Image_Image_Hash);//func.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data = (byte_array_v)func.Copy(xItem_Data.Item_Image_Image_Data);//Itemfunc.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xItem_Data.s1_name;
            s2_name = xItem_Data.s2_name;
            s3_name = xItem_Data.s3_name;
            m_ShopShelf_Source.Add_Stock_Data(xItem_Data, xFactoryQuantity, xStockQuantity, b_from_factory);
        }
    }
}
