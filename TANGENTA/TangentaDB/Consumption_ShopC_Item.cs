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
    public class Consumption_ShopC_Item
    {
        public ID Consumption_ShopC_Item_ID = null;
        public ID Consumption_ID = null;
        public ID PurchasePrice_Item_ID = null;
        public ID Item_ID = null;

        public decimal PurchasePricePerUnit = 0;
        public decimal PurchasePricePerUnit_Discount = 0;

        public decimal TaxationRate
        {
            get
            {
                if (Taxation_Rate_v!=null)
                {
                    return Taxation_Rate_v.v;
                }
                else
                {
                    return 0;
                }
            }

        }
       

        public string_v Item_Name_v = null;
        public string_v Item_UniqueName_v = null;
        public string_v Item_barcode_v = null;
        public string_v Taxation_Name_v = null;
        public decimal_v Taxation_Rate_v = null;
        public string_v Item_Description = null;
        public ID Warranty_ID = null;
        public string_v WarrantyConditions_v = null;
        public short_v WarrantyDurationType_v = null;
        public int_v WarrantyDuration_v = null;
        public ID Expiry_ID = null;
        public int_v Expiry_ExpectedShelfLifeInDays_v = null;
        public int_v Expiry_SaleBeforeExpiryDateInDays_v = null;
        public int_v Expiry_DiscardBeforeExpiryDateInDays_v = null;
        public string_v Expiry_ExpiryDescription = null;

        public string_v Unit_Name_v = null;
        public string_v Unit_Symbol_v = null;
        public int_v Unit_DecimalPlaces_v = null;
        public string_v Unit_Description_v = null;
        public bool_v Unit_StorageOption_v = null;

        
        public string_v Currency_Name_v = null;
        public string_v Currency_Abbreviation_v = null;
        public string_v Currency_Symbol_v = null;

        
        

      

        public int_v Atom_Currency_DecimalPlaces_v = null;

        public string_v Atom_Item_Image_Hash_v = null;
        public byte_array_v Atom_Item_Image_Data_v = null;

        public string s1_name = null;
        public string s2_name = null;
        public string s3_name = null;

        public ShopC_Item_Source_ListConsumption dsciS_List = new ShopC_Item_Source_ListConsumption();

        public string Item_UniqueName
        {
            get
            {
                if (Item_UniqueName_v!=null)
                {
                    return Item_UniqueName_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        public string Item_Name
        {
            get
            {
                if (Item_Name_v != null)
                {
                    return Item_Name_v.v;
                }
                else
                {
                    return null;
                }
            }
        }
        public decimal TotalDiscount
        {
            get
            {
                return PurchasePricePerUnit_Discount;
            }
        }


        public decimal dQuantity_FromStock
        {
            get
            {
                return dsciS_List.dQuantity_from_stock;
            }
        }

        //public decimal dQuantity_FromFactory
        //{
        //    get
        //    {
        //        return dsciS_List.dQuantity_from_factory;
        //    }
        //}

        public void Set(string docTyp, DataRow dria,
                            ref List<Consumption_ShopC_Item> Consumption_ShopC_Item_Data_list)
        {
            Consumption_ShopC_Item_Source dsciS = null;
            int i = 0;
            int iCount = Consumption_ShopC_Item_Data_list.Count;
            Item_ID = new ID(dria["Item_ID"]);

            if (ID.Validate(Item_ID))
            {
                for (i = 0; i < iCount; i++)
                {
                    if (((Consumption_ShopC_Item)Consumption_ShopC_Item_Data_list[i]).Item_ID.Equals(Item_ID))
                    {
                        dsciS = new Consumption_ShopC_Item_Source();
                        dsciS.Set(docTyp,dria);
                        Consumption_ShopC_Item_Data_list[i].dsciS_List.Add(dsciS);
                        return;
                    }
                }

                Consumption_ShopC_Item_ID = tf.set_ID(dria[ "Consumption_ShopC_Item_ID"]);
                Consumption_ID = tf.set_ID(dria["Consumption_ID"]);
                PurchasePrice_Item_ID = new ID(dria["PurchasePrice_Item_ID"]);
                PurchasePricePerUnit = tf._set_decimal(dria["PurchasePricePerUnit"]);
                PurchasePricePerUnit_Discount = tf._set_decimal(dria["PurchasePricePerUnit_Discount"]);
                Item_UniqueName_v = tf.set_string(dria["Item_UniqueName"]);
                Item_Name_v = tf.set_string(dria["Item_Name"]);
                Item_barcode_v = tf.set_string(dria["Item_barcode"]);
                Taxation_Name_v = tf.set_string(dria["Taxation_Name"]);
                Taxation_Rate_v = tf.set_decimal(dria["Taxation_Rate"]);
                Item_Description = tf.set_string(dria["Item_Description"]);
                Warranty_ID = tf.set_ID(dria["Warranty_ID"]);
                WarrantyDurationType_v = tf.set_short(dria["WarrantyDurationType"]);
                WarrantyDuration_v = tf.set_int(dria["WarrantyDuration"]);
                WarrantyConditions_v = tf.set_string(dria["WarrantyConditions"]);
                Expiry_ID = tf.set_ID(dria["Expiry_ID"]);
                Expiry_ExpectedShelfLifeInDays_v = tf.set_int(dria["Expiry_ExpectedShelfLifeInDays"]);
                Expiry_SaleBeforeExpiryDateInDays_v = tf.set_int(dria["Expiry_SaleBeforeExpiryDateInDays"]);
                Expiry_DiscardBeforeExpiryDateInDays_v = tf.set_int(dria["Expiry_DiscardBeforeExpiryDateInDays"]);
                Expiry_ExpiryDescription = tf.set_string(dria["Expiry_ExpiryDescription"]);
                Unit_Name_v = tf.set_string(dria["Unit_Name"]);
                Unit_Symbol_v = tf.set_string(dria["Unit_Symbol"]);
                Unit_DecimalPlaces_v = tf.set_int(dria["Unit_DecimalPlaces"]);
                Unit_Description_v = tf.set_string(dria["Unit_Description"]);
                Unit_StorageOption_v = tf.set_bool(dria["Unit_StorageOption"]);
                Currency_Name_v = tf.set_string(dria["Currency_Name"]);
                Currency_Abbreviation_v = tf.set_string(dria["Currency_Abbreviation"]);
                Currency_Symbol_v = tf.set_string(dria["Currency_Symbol"]);
                Atom_Currency_DecimalPlaces_v = tf.set_int(dria["Currency_DecimalPlaces"]);
                Atom_Item_Image_Hash_v = tf.set_string(dria["Image_Hash"]);
                Atom_Item_Image_Data_v = tf.set_byte_array(dria["Image_Data"]);
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

                if (dsciS_List.Get(Consumption_ShopC_Item_ID))
                {
                    Consumption_ShopC_Item_Data_list.Add(this);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Consumption_ShopC_Item_Data:Set(DataRow dria,..):Atom_Item_ID == null");
            }
        }
        public decimal dQuantity_all
        {
            get
            {
                return dsciS_List.dQuantity_all;
            }
        }

        public decimal PurchqsePriceWithDiscount
        {

            get
            {
                return dsciS_List.RetailPriceWithDiscount(PurchasePricePerUnit,this.PurchasePricePerUnit_Discount, 0, TaxationRate);
            }

        }

        public decimal TaxPrice
        {

            get
            {
                return dsciS_List.TaxPrice(PurchasePricePerUnit, PurchasePricePerUnit_Discount, 0, TaxationRate);
            }

        }

        public decimal NetPrice
        {

            get
            {
                return dsciS_List.NetPrice(PurchasePricePerUnit, PurchasePricePerUnit_Discount, 0, TaxationRate);
            }

        }

        private static bool IsNull_Stock_ExpiryDate(Stock_Data z)
        {
            if (z == null)
            {
                return true;
            }
            else
            {
                if (z.Stock_ExpiryDate == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static int Compare_Stock_ExpiryDate(Stock_Data x, Stock_Data y)
        {
            if (IsNull_Stock_ExpiryDate(x))
            {
                if (IsNull_Stock_ExpiryDate(y))
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (IsNull_Stock_ExpiryDate(y))
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Stock_ExpiryDate.v.CompareTo(y.Stock_ExpiryDate.v);
                    return retval;
                }
            }

        }


     

   

        public void Set(CItem_Data xItem_Data,
                        ID xConsumption_ID,
                        decimal xFactoryQuantity,
                        decimal xStockQuantity,
                        ID consumption_ShopC_Item_ID,
                        bool b_from_factory)
        {
           // m_ShopShelf_Source.Clear();
            Consumption_ShopC_Item_ID = consumption_ShopC_Item_ID;
            Consumption_ID = new ID();
            Consumption_ID.Set(xConsumption_ID);
            PurchasePrice_Item_ID = null; // tf.set_long(dria["Atom_Price_Item_ID"]);

            //RetailPricePerUnit = (decimal_v)tf.Copy(xItem_Data.RetailPricePerUnit); //tf.set_decimal(dr[cpis.icol_RetailPricePerUnit]);

            //Discount = (decimal_v)tf.Copy(xItem_Data.Price_Item_Discount); // tf.set_decimal(dr[cpis.icol_Discount]);

            //ExtraDiscount = tf.set_decimal(xItem_Data.ExtraDiscount);

            Item_UniqueName_v = (string_v)tf.Copy(xItem_Data.Item_UniqueName_v);// tf.set_string(dr[cpis.icol_Item_UniqueName]);

            Item_Name_v = (string_v)tf.Copy(xItem_Data.Item_Name_v);//tf.set_string(dr[cpis.icol_Item_Name]);
            Item_barcode_v = (string_v)tf.Copy(xItem_Data.Item_barcode_v);//tf.set_string(dr[cpis.icol_Item_barcode]);
            Taxation_Name_v = (string_v)tf.Copy(xItem_Data.Taxation_Name_v);//tf.set_string(dr[cpis.icol_Taxation_Name]);
            Taxation_Rate_v = (decimal_v)tf.Copy(xItem_Data.Taxation_Rate_v);//tf.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Item_Description = (string_v)tf.Copy(xItem_Data.Item_Description_v);//tf.set_string(dr[cpis.icol_Item_Description]);
            Warranty_ID = null; //tf.set_long(dria["Atom_Warranty_ID"]);
            WarrantyDurationType_v = (short_v)tf.Copy(xItem_Data.Warranty_WarrantyDurationType_v);//tf.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            WarrantyDuration_v = (int_v)tf.Copy(xItem_Data.Warranty_WarrantyDuration_v);//tf.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            WarrantyConditions_v = (string_v)tf.Copy(xItem_Data.Warranty_WarrantyConditions_v);//tf.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Expiry_ID = null; //tf.set_long(dr["Atom_Expiry_ID"]);
            Expiry_ExpectedShelfLifeInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_ExpectedShelfLifeInDays_v);//tf.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Expiry_SaleBeforeExpiryDateInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_SaleBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Expiry_DiscardBeforeExpiryDateInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_DiscardBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Expiry_ExpiryDescription = (string_v)tf.Copy(xItem_Data.Expiry_Description_v);//tf.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
            //Item_ID= tf.set_ID(xItem_Data.Item_ID);//tf.set_long(dr["Item_ID"]);
            Unit_Name_v = (string_v)tf.Copy(xItem_Data.Unit_Name_v);//tf.set_string(dr[cpis.icol_Unit_Name]);
            Unit_Symbol_v = (string_v)tf.Copy(xItem_Data.Unit_Symbol_v);//tf.set_string(dr[cpis.icol_Unit_Symbol]);
            Unit_DecimalPlaces_v = (int_v)tf.Copy(xItem_Data.Unit_DecimalPlaces_v);//tf.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Unit_Description_v = (string_v)tf.Copy(xItem_Data.Unit_Description_v);//tf.set_string(dr[cpis.icol_Unit_Description]);
            Unit_StorageOption_v = (bool_v)tf.Copy(xItem_Data.Unit_StorageOption_v);//tf.set_bool(dr[cpis.icol_Unit_StorageOption]);
            Currency_Name_v = (string_v)tf.Copy(xItem_Data.Currency_Name_v);// tf.set_string(dr[cpis.icol_Currency_Name]);
            Currency_Abbreviation_v = (string_v)tf.Copy(xItem_Data.Currency_Abbreviation_v);//tf.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Currency_Symbol_v = (string_v)tf.Copy(xItem_Data.Currency_Symbol_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces_v = (int_v)tf.Copy(xItem_Data.Currency_DecimalPlaces);//tf.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash_v = (string_v)tf.Copy(xItem_Data.Item_Image_Image_Hash_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data_v = (byte_array_v)tf.Copy(xItem_Data.Item_Image_Image_Data_v);//Itemtf.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xItem_Data.s1_name;
            s2_name = xItem_Data.s2_name;
            s3_name = xItem_Data.s3_name;
            //m_ShopShelf_Source.Add_Stock_Data(xItem_Data, doc_ShopC_Item_ID, xFactoryQuantity, xStockQuantity, b_from_factory);
        }


        //internal bool AddFactory(string doc_type, ID doc_ID, CItem_Data xData, decimal dQuantity_FromFactory2Add, Transaction transaction)
        //{
        //    Consumption_ShopC_Item_Source dsciSx = this.dsciS_List.FindFactory();
        //    if (dsciSx==null)
        //    {
        //        if (xData.Taxation_Rate_v != null)
        //        {
        //            if (xData.PurchasePricePerUnit_v != null)
        //            {
        //                decimal retailPriceWithDiscount = 0;
        //                decimal taxPrice = 0;
        //                decimal retailPriceWithDiscount_WithoutTax = 0;

        //                StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
        //                                             dQuantity_FromFactory2Add,
        //                                              0,
        //                                              xData.ExtraDiscount,
        //                                              xData.Taxation_Rate_v.v,
        //                                              ref retailPriceWithDiscount,
        //                                              ref taxPrice,
        //                                              ref retailPriceWithDiscount_WithoutTax,
        //                                              GlobalData.BaseCurrency.DecimalPlaces
        //                                              );
        //                ID docInvoice_ShopC_Item_Source_ID = null;
        //                if (f_Consumption_ShopC_Item_Source.Insert(this.Consumption_ShopC_Item_ID,
        //                                                           dQuantity_FromFactory2Add,
        //                                                           new decimal_v(xData.ExtraDiscount),
        //                                                           retailPriceWithDiscount,
        //                                                           taxPrice,
        //                                                           xData.ExpiryDate_v,
        //                                                           null,
        //                                                           ref docInvoice_ShopC_Item_Source_ID,
        //                                                           transaction))
        //                {
        //                    dsciSx = new Consumption_ShopC_Item_Source();
        //                    dsciSx.SetNew(this.Consumption_ShopC_Item_ID,
        //                                  docInvoice_ShopC_Item_Source_ID,
        //                                  null,
        //                                  dQuantity_FromFactory2Add,
        //                                   0,
        //                                  retailPriceWithDiscount,
        //                                  taxPrice,
        //                                  xData.ExpiryDate_v);
        //                    this.dsciS_List.Add(dsciSx);
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:AddFactory:2:(xData.RetailPricePerUnit_v == null");
        //                return false;

        //            }
        //        }
        //        else
        //        {
        //            LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:AddFactory:2:(xData.Taxation_Rate_v == null");
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (xData.Taxation_Rate_v != null)
        //        {
        //            if (xData.PurchasePricePerUnit_v != null)
        //            {
        //                decimal retailPriceWithDiscount = 0;
        //                decimal taxPrice = 0;
        //                decimal retailPriceWithDiscount_WithoutTax = 0;

        //                decimal dnew_Quantity_FromFActory = dsciSx.dQuantity + dQuantity_FromFactory2Add;
        //                StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
        //                                             dnew_Quantity_FromFActory,
        //                                              0,//xData.Discount,
        //                                              xData.ExtraDiscount,
        //                                              xData.Taxation_Rate_v.v,
        //                                              ref retailPriceWithDiscount,
        //                                              ref taxPrice,
        //                                              ref retailPriceWithDiscount_WithoutTax,
        //                                              GlobalData.BaseCurrency.DecimalPlaces
        //                                              );
        //                if (f_Consumption_ShopC_Item_Source.Update(dsciSx.Consumption_ShopC_Item_Source_ID,
        //                                                           dnew_Quantity_FromFActory,
        //                                                           retailPriceWithDiscount,
        //                                                           taxPrice,
        //                                                           transaction))
        //                {
                            
        //                    dsciSx.Set(dnew_Quantity_FromFActory,
        //                               retailPriceWithDiscount,
        //                               taxPrice
        //                               );
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:AddFactory:2:(xData.RetailPricePerUnit_v == null");
        //                return false;

        //            }
        //        }
        //        else
        //        {
        //            LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:AddFactory:2:(xData.Taxation_Rate_v == null");
        //            return false;
        //        }
        //    }
        //}


        //internal bool SetFactory(string doc_type, ID doc_ID, CItem_Data xData, decimal dQuantity_FromFactory, Transaction transaction)
        //{

        //    Consumption_ShopC_Item_Source dsciSx = this.dsciS_List.FindFactory();
        //    if (dsciSx == null)
        //    {
        //        if (dQuantity_FromFactory > 0)
        //        {
        //            if (xData.Taxation_Rate_v != null)
        //            {
        //                if (xData.PurchasePricePerUnit_v != null)
        //                {
        //                    decimal retailPriceWithDiscount = 0;
        //                    decimal taxPrice = 0;
        //                    decimal retailPriceWithDiscount_WithoutTax = 0;

        //                    StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
        //                                                    dQuantity_FromFactory,
        //                                                    0,//xData.Discount,
        //                                                    xData.ExtraDiscount,
        //                                                    xData.Taxation_Rate_v.v,
        //                                                    ref retailPriceWithDiscount,
        //                                                    ref taxPrice,
        //                                                    ref retailPriceWithDiscount_WithoutTax,
        //                                                    GlobalData.BaseCurrency.DecimalPlaces
        //                                                    );
        //                    ID docInvoice_ShopC_Item_Source_ID = null;
        //                    if (f_Consumption_ShopC_Item_Source.Insert(this.Consumption_ShopC_Item_ID,
        //                                                                dQuantity_FromFactory,
        //                                                                new decimal_v(xData.ExtraDiscount),
        //                                                                retailPriceWithDiscount,
        //                                                                taxPrice,
        //                                                                xData.ExpiryDate_v,
        //                                                                null,
        //                                                                ref docInvoice_ShopC_Item_Source_ID,
        //                                                                transaction))
        //                    {
        //                        dsciSx = new Consumption_ShopC_Item_Source();
        //                        dsciSx.SetNew(this.Consumption_ShopC_Item_ID,
        //                                        docInvoice_ShopC_Item_Source_ID,
        //                                        null,
        //                                        dQuantity_FromFactory,
        //                                        0,
        //                                        retailPriceWithDiscount,
        //                                        taxPrice,
        //                                        xData.ExpiryDate_v);
        //                        this.dsciS_List.Add(dsciSx);
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetFactory:2:(xData.RetailPricePerUnit_v == null");
        //                    return false;

        //                }
        //            }
        //            else
        //            {
        //                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetFactory:2:(xData.Taxation_Rate_v == null");
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        //Factory item allready item exist
        //        if (xData.Taxation_Rate_v != null)
        //        {
        //            if (xData.PurchasePricePerUnit_v != null)
        //            {
        //                decimal retailPriceWithDiscount = 0;
        //                decimal taxPrice = 0;
        //                decimal retailPriceWithDiscount_WithoutTax = 0;

        //                StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
        //                                                dQuantity_FromFactory,
        //                                                0,//xData.Discount,
        //                                                xData.ExtraDiscount,
        //                                                xData.Taxation_Rate_v.v,
        //                                                ref retailPriceWithDiscount,
        //                                                ref taxPrice,
        //                                                ref retailPriceWithDiscount_WithoutTax,
        //                                                GlobalData.BaseCurrency.DecimalPlaces
        //                                                );
        //                if (dQuantity_FromFactory > 0)
        //                {
        //                    if (f_Consumption_ShopC_Item_Source.Update(dsciSx.Consumption_ShopC_Item_Source_ID,
        //                                                                dQuantity_FromFactory,
        //                                                                retailPriceWithDiscount,
        //                                                                taxPrice,
        //                                                                transaction))
        //                    {

        //                        dsciSx.Set(dQuantity_FromFactory,
        //                                    retailPriceWithDiscount,
        //                                    taxPrice
        //                                    );
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    if (f_Consumption_ShopC_Item_Source.Delete(dsciSx.Consumption_ShopC_Item_Source_ID, transaction))
        //                    {
        //                        this.dsciS_List.dsciS_list.Remove(dsciSx);
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        return false;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetFactory:2:(xData.RetailPricePerUnit_v == null");
        //                return false;

        //            }
        //        }
        //        else
        //        {
        //            LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetFactory:2:(xData.Taxation_Rate_v == null");
        //            return false;
        //        }
        //    }
        //}

        internal bool SetNew(string doc_type, ID cons_ID, CItem_Data xData, List<CStock_Data> std_taken_List,  Transaction transaction)
        {
           

            this.Set(xData);
            this.Consumption_ID = cons_ID;

            if (doc_type.Equals(GlobalData.const_ConsumptionAll))
            {
                if (f_Consumption_ShopC_Item.Insert(cons_ID, xData.Item_ID,ref this.Consumption_ShopC_Item_ID, transaction))
                {
                    if (std_taken_List != null)
                    {
                        foreach (CStock_Data stdx in std_taken_List)
                        {
                            decimal discount = 0;
                            if (xData.PurchasePrice_Item_Discount_v != null)
                            {
                                discount = xData.PurchasePrice_Item_Discount_v.v;
                            }

                            if (xData.Taxation_Rate_v != null)
                            {
                                if (xData.PurchasePricePerUnit_v != null)
                                {
                                    decimal retailPriceWithDiscount = 0;
                                    decimal taxPrice = 0;
                                    decimal retailPriceWithDiscount_WithoutTax = 0;

                                    StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
                                                                  stdx.dQuantity_Taken_v.v,
                                                                  discount,
                                                                  0,
                                                                  xData.Taxation_Rate_v.v,
                                                                  ref retailPriceWithDiscount,
                                                                  ref taxPrice,
                                                                  ref retailPriceWithDiscount_WithoutTax,
                                                                  GlobalData.BaseCurrency.DecimalPlaces
                                                                  );

                                    decimal dnew_stock_quantity = stdx.dQuantity_v.v - stdx.dQuantity_Taken_v.v;

                                    if (f_Stock.UpdateQuantity(stdx.Stock_ID, dnew_stock_quantity, transaction))
                                    {
                                        stdx.dQuantity_v.v = dnew_stock_quantity;
                                        CStock_Data std_data = xData.Find_Stock_Data(stdx);
                                        if (std_data != null)
                                        {
                                            std_data.dQuantity_v.v = dnew_stock_quantity;
                                            if (std_data.dQuantity_Taken_v != null)
                                            {
                                                std_data.dQuantity_Taken_v = null;
                                            }
                                            ID docInvoice_ShopC_Item_Source_ID = null;
                                            if (f_Consumption_ShopC_Item_Source.Insert(this.Consumption_ShopC_Item_ID,
                                                                                       stdx.Stock_ID,
                                                                                       stdx.dQuantity_Taken_v.v,
                                                                                      
                                                                                       ref docInvoice_ShopC_Item_Source_ID, 
                                                                                       transaction))
                                            {
                                                Consumption_ShopC_Item_Source dsciSx = new Consumption_ShopC_Item_Source();
                                                dsciSx.SetNew(this.Consumption_ShopC_Item_ID,
                                                              docInvoice_ShopC_Item_Source_ID,
                                                              stdx.Stock_ID,
                                                               stdx.dQuantity_Taken_v.v,
                                                               0,
                                                              retailPriceWithDiscount,
                                                              taxPrice,
                                                              xData.ExpiryDate_v);
                                                this.dsciS_List.Add(dsciSx);
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetNew:1:xData.Find_Stock_Data(stdx) == null");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetNew:1:(xData.RetailPricePerUnit_v == null");
                                    return false;

                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetNew:1:(xData.Taxation_Rate_v == null");
                                return false;

                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (doc_type.Equals(GlobalData.const_DocProformaInvoice))
            {
                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:SetNew:Not implemented for const_DocProformaInvoice !");
                return false;

                //if (f_DocProformaInvoice_ShopC_Item.Insert(doc_ID, Atom_Price_Item_ID, xData.ExtraDiscount, ref doc_ShopC_Item_ID))
                //{

                //}
            }
            return false;
        }

        private void Set(CItem_Data xData)
        {
            Item_UniqueName_v = (string_v)tf.Copy(xData.Item_UniqueName_v);// tf.set_string(dr[cpis.icol_Item_UniqueName]);

            Item_Name_v = (string_v)tf.Copy(xData.Item_Name_v);//tf.set_string(dr[cpis.icol_Item_Name]);
            Item_barcode_v = (string_v)tf.Copy(xData.Item_barcode_v);//tf.set_string(dr[cpis.icol_Item_barcode]);
            Taxation_Name_v = (string_v)tf.Copy(xData.Taxation_Name_v);//tf.set_string(dr[cpis.icol_Taxation_Name]);
            Taxation_Rate_v = (decimal_v)tf.Copy(xData.Taxation_Rate_v);//tf.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Item_Description = (string_v)tf.Copy(xData.Item_Description_v);//tf.set_string(dr[cpis.icol_Item_Description]);
            Warranty_ID = null; //tf.set_long(dria["Atom_Warranty_ID"]);
            WarrantyDurationType_v = (short_v)tf.Copy(xData.Warranty_WarrantyDurationType_v);//tf.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            WarrantyDuration_v = (int_v)tf.Copy(xData.Warranty_WarrantyDuration_v);//tf.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            WarrantyConditions_v = (string_v)tf.Copy(xData.Warranty_WarrantyConditions_v);//tf.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Expiry_ID = null; //tf.set_long(dr["Atom_Expiry_ID"]);
            Expiry_ExpectedShelfLifeInDays_v = (int_v)tf.Copy(xData.Expiry_ExpectedShelfLifeInDays_v);//tf.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Expiry_SaleBeforeExpiryDateInDays_v = (int_v)tf.Copy(xData.Expiry_SaleBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Expiry_DiscardBeforeExpiryDateInDays_v = (int_v)tf.Copy(xData.Expiry_DiscardBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Expiry_ExpiryDescription = (string_v)tf.Copy(xData.Expiry_Description_v);//tf.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
                                                                                          //Item_ID = tf.set_ID(xData.Item_ID);//tf.set_long(dr["Item_ID"]);
            Unit_Name_v = (string_v)tf.Copy(xData.Unit_Name_v);//tf.set_string(dr[cpis.icol_Unit_Name]);
            Unit_Symbol_v = (string_v)tf.Copy(xData.Unit_Symbol_v);//tf.set_string(dr[cpis.icol_Unit_Symbol]);
            Unit_DecimalPlaces_v = (int_v)tf.Copy(xData.Unit_DecimalPlaces_v);//tf.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Unit_Description_v = (string_v)tf.Copy(xData.Unit_Description_v);//tf.set_string(dr[cpis.icol_Unit_Description]);
            Unit_StorageOption_v = (bool_v)tf.Copy(xData.Unit_StorageOption_v);//tf.set_bool(dr[cpis.icol_Unit_StorageOption]);
            //Atom_PriceList_Name_v = (string_v)tf.Copy(xData.PriceList_Name_v);//tf.set_string(dr[cpis.icol_PriceList_Name]);
            Currency_Name_v = (string_v)tf.Copy(xData.Currency_Name_v);// tf.set_string(dr[cpis.icol_Currency_Name]);
            Currency_Abbreviation_v = (string_v)tf.Copy(xData.Currency_Abbreviation_v);//tf.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Currency_Symbol_v = (string_v)tf.Copy(xData.Currency_Symbol_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces_v = (int_v)tf.Copy(xData.Currency_DecimalPlaces);//tf.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash_v = (string_v)tf.Copy(xData.Item_Image_Image_Hash_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data_v = (byte_array_v)tf.Copy(xData.Item_Image_Image_Data_v);//Itemtf.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xData.s1_name;
            s2_name = xData.s2_name;
            s3_name = xData.s3_name;

            if (xData.PurchasePricePerUnit_v != null)
            {
                this.PurchasePricePerUnit = xData.PurchasePricePerUnit_v.v;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Consumption_ShopC_Item:Set(Item_Data xData):xData.RetailPricePerUnit_v == null!");
            }
            this.PurchasePricePerUnit_Discount = 0;
            if (xData.PurchasePrice_Item_Discount_v!=null)
            {
                this.PurchasePricePerUnit_Discount = xData.PurchasePrice_Item_Discount_v.v;
            }

            //ExtraDiscount = 0;
        }

        internal bool Set(string doc_type, ID doc_ID, CItem_Data xData, List<CStock_Data> taken_from_Stock_List, Transaction transaction)
        {
            foreach (CStock_Data stdx in taken_from_Stock_List)
            {
                Consumption_ShopC_Item_Source dsciSx = this.dsciS_List.Find(stdx);
                decimal discount = 0;
                if (dsciSx==null)
                {
                    dsciSx = new Consumption_ShopC_Item_Source();
                    
                    if (xData.PurchasePrice_Item_Discount_v != null)
                    {
                        discount = xData.PurchasePrice_Item_Discount_v.v;
                   }

                    if (xData.Taxation_Rate_v != null)
                    {
                        if (xData.PurchasePricePerUnit_v != null)
                        {
                            decimal retailPriceWithDiscount = 0;
                            decimal taxPrice = 0;
                            decimal retailPriceWithDiscount_WithoutTax = 0;

                            StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
                                                          stdx.dQuantity_Taken_v.v,
                                                          discount,
                                                          0,
                                                          xData.Taxation_Rate_v.v,
                                                          ref retailPriceWithDiscount,
                                                          ref taxPrice,
                                                          ref retailPriceWithDiscount_WithoutTax,
                                                          GlobalData.BaseCurrency.DecimalPlaces
                                                          );
                            ID docInvoice_ShopC_Item_Source_ID = null;
                            if (f_Consumption_ShopC_Item_Source.Insert(this.Consumption_ShopC_Item_ID,
                                                                       stdx.Stock_ID,
                                                                       stdx.dQuantity_Taken_v.v,                                                                      
                                                                       ref docInvoice_ShopC_Item_Source_ID,
                                                                       transaction))
                            {
                                dsciSx.SetNew(this.Consumption_ShopC_Item_ID,
                                           docInvoice_ShopC_Item_Source_ID,
                                           stdx.Stock_ID,
                                           stdx.dQuantity_Taken_v.v,
                                           0,
                                           retailPriceWithDiscount,
                                           taxPrice,
                                            xData.ExpiryDate_v
                                           );
                                this.dsciS_List.Add(dsciSx);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    if (xData.PurchasePrice_Item_Discount_v != null)
                    {
                        discount = xData.PurchasePrice_Item_Discount_v.v;
                    }
                    decimal retailPriceWithDiscount = 0;
                    decimal taxPrice = 0;
                    decimal retailPriceWithDiscount_WithoutTax = 0;

                    decimal dnewQuantity = dsciSx.dQuantity + stdx.dQuantity_Taken_v.v;

                    StaticLib.Func.CalculatePrice(xData.PurchasePricePerUnit_v.v,
                                                  dnewQuantity,
                                                  discount,
                                                  0,
                                                  xData.Taxation_Rate_v.v,
                                                  ref retailPriceWithDiscount,
                                                  ref taxPrice,
                                                  ref retailPriceWithDiscount_WithoutTax,
                                                  GlobalData.BaseCurrency.DecimalPlaces
                                                  );

                    
                    if (f_Consumption_ShopC_Item_Source.Update(dsciSx.Consumption_ShopC_Item_Source_ID,dnewQuantity, transaction ))
                    {
                        dsciSx.dQuantity = dnewQuantity;
                        dsciSx.PurchasePricePerUnit = retailPriceWithDiscount;
                        dsciSx.TaxPrice = taxPrice;
                    }
                }
            }
            return true;
        }


        internal bool RemoveSources(string docTyp, CItem_Data xdata, Transaction transaction)
        {
           if (this.dsciS_List.RemoveSources(docTyp,xdata, transaction))
            {
                if (f_Consumption_ShopC_Item.Delete(this.Consumption_ShopC_Item_ID, transaction))
                {
                    return true;
                }
            }
            return false;
        }

        public void Set_WithNoTakeForItemData(Item_Data xItem_Data,
                        ID xConsumption_ID,
                        decimal xFactoryQuantity,
                        decimal xStockQuantity,
                        ID doc_ShopC_Item_ID,
                        bool b_from_factory)
        {
           // m_ShopShelf_Source.Clear();
            Consumption_ShopC_Item_ID = doc_ShopC_Item_ID;
            Consumption_ID = new ID();
            Consumption_ID.Set(xConsumption_ID);
            PurchasePrice_Item_ID = null; // tf.set_long(dria["Atom_Price_Item_ID"]);


            //RetailPricePerUnit = (decimal_v)tf.Copy(xItem_Data.RetailPricePerUnit); //tf.set_decimal(dr[cpis.icol_RetailPricePerUnit]);

            //Discount = (decimal_v)tf.Copy(xItem_Data.Price_Item_Discount); // tf.set_decimal(dr[cpis.icol_Discount]);

            decimal retail_price_with_discount = 0;
            //RetailPriceWithDiscount = tf.set_decimal(retail_price_with_discount);
            //$$TODO

            decimal tax_price = 0;
            //TaxPrice = tf.set_decimal(tax_price);

            //ExtraDiscount = tf.set_decimal(xItem_Data.ExtraDiscount);

            Item_UniqueName_v = (string_v)tf.Copy(xItem_Data.Item_UniqueName_v);// tf.set_string(dr[cpis.icol_Item_UniqueName]);

            Item_Name_v = (string_v)tf.Copy(xItem_Data.Item_Name_v);//tf.set_string(dr[cpis.icol_Item_Name]);
            Item_barcode_v = (string_v)tf.Copy(xItem_Data.Item_barcode_v);//tf.set_string(dr[cpis.icol_Item_barcode]);
            Taxation_Name_v = (string_v)tf.Copy(xItem_Data.Taxation_Name_v);//tf.set_string(dr[cpis.icol_Taxation_Name]);
            Taxation_Rate_v = (decimal_v)tf.Copy(xItem_Data.Taxation_Rate_v);//tf.set_decimal(dr[cpis.icol_Taxation_Rate]);
            Item_Description = (string_v)tf.Copy(xItem_Data.Item_Description_v);//tf.set_string(dr[cpis.icol_Item_Description]);
            Warranty_ID = null; //tf.set_long(dria["Atom_Warranty_ID"]);
            WarrantyDurationType_v = (short_v)tf.Copy(xItem_Data.Warranty_WarrantyDurationType_v);//tf.set_short(dr[cpis.icol_Warranty_WarrantyDurationType]);
            WarrantyDuration_v = (int_v)tf.Copy(xItem_Data.Warranty_WarrantyDuration_v);//tf.set_int(dr[cpis.icol_Warranty_WarrantyDuration]);
            WarrantyConditions_v = (string_v)tf.Copy(xItem_Data.Warranty_WarrantyConditions_v);//tf.set_string(dr[cpis.icol_Warranty_WarrantyConditions]);
            Expiry_ID = null; //tf.set_long(dr["Atom_Expiry_ID"]);
            Expiry_ExpectedShelfLifeInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_ExpectedShelfLifeInDays_v);//tf.set_int(dr[cpis.icol_Expiry_ExpectedShelfLifeInDays]);
            Expiry_SaleBeforeExpiryDateInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_SaleBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_SaleBeforeExpiryDateInDays]);
            Expiry_DiscardBeforeExpiryDateInDays_v = (int_v)tf.Copy(xItem_Data.Expiry_DiscardBeforeExpiryDateInDays_v);//tf.set_int(dr[cpis.icol_Expiry_DiscardBeforeExpiryDateInDays]);
            Expiry_ExpiryDescription = (string_v)tf.Copy(xItem_Data.Expiry_Description_v);//tf.set_string(dr[cpis.icol_Expiry_ExpiryDescription]);
            //Item_ID = tf.set_ID(xItem_Data.Item_ID);//tf.set_long(dr["Item_ID"]);
            Unit_Name_v = (string_v)tf.Copy(xItem_Data.Unit_Name_v);//tf.set_string(dr[cpis.icol_Unit_Name]);
            Unit_Symbol_v = (string_v)tf.Copy(xItem_Data.Unit_Symbol_v);//tf.set_string(dr[cpis.icol_Unit_Symbol]);
            Unit_DecimalPlaces_v = (int_v)tf.Copy(xItem_Data.Unit_DecimalPlaces_v);//tf.set_int(dr[cpis.icol_Unit_DecimalPlaces]);
            Unit_Description_v = (string_v)tf.Copy(xItem_Data.Unit_Description_v);//tf.set_string(dr[cpis.icol_Unit_Description]);
            Unit_StorageOption_v = (bool_v)tf.Copy(xItem_Data.Unit_StorageOption_v);//tf.set_bool(dr[cpis.icol_Unit_StorageOption]);
            Currency_Name_v = (string_v)tf.Copy(xItem_Data.Currency_Name_v);// tf.set_string(dr[cpis.icol_Currency_Name]);
            Currency_Abbreviation_v = (string_v)tf.Copy(xItem_Data.Currency_Abbreviation_v);//tf.set_string(dr[cpis.icol_Currency_Abbreviation]);
            Currency_Symbol_v = (string_v)tf.Copy(xItem_Data.Currency_Symbol_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Currency_DecimalPlaces_v = (int_v)tf.Copy(xItem_Data.Currency_DecimalPlaces);//tf.set_int(dr[cpis.icol_Currency_DecimalPlaces]);
            Atom_Item_Image_Hash_v = (string_v)tf.Copy(xItem_Data.Item_Image_Image_Hash_v);//tf.set_string(dr[cpis.icol_Currency_Symbol]);
            Atom_Item_Image_Data_v = (byte_array_v)tf.Copy(xItem_Data.Item_Image_Image_Data_v);//Itemtf.set_byte_array(dr[cpis.icol_Item_Image_Image_Data]);
            s1_name = xItem_Data.s1_name;
            s2_name = xItem_Data.s2_name;
            s3_name = xItem_Data.s3_name;
            //m_ShopShelf_Source.Add_Stock_Data_WithNoTakeForItemData(xItem_Data, doc_ShopC_Item_ID, xFactoryQuantity, xStockQuantity, b_from_factory);
        }
        public void AddQuantity(ID doc_ShopC_Item_ID,ID stock_ID, decimal dqAdd)
        {
            //foreach (Stock_Data std in m_ShopShelf_Source.Stock_Data_List)
            //{
            //    if (ID.Validate(std.Stock_ID))
            //    {
            //        if (std.Stock_ID.Equals(stock_ID))
            //        {
            //            decimal dqcur = std.dQuantity_v.v;
            //            std.dQuantity_v.v = dqcur+ dqAdd;
            //        }
            //    }
            //}
        }

        public void Add_Consumption_ShopC_Item(Item_Data xData, decimal xdQuantity, ID stock_ID,ID atom_Price_Item_ID)
        {
            decimal retailPricePerunit = 0;
            if (xData.RetailPricePerUnit_v != null)
            {
                retailPricePerunit = xData.RetailPricePerUnit_v.v;
            }
            decimal taxRate = 0;
            if (xData.Taxation_Rate_v != null)
            {
                taxRate = xData.Taxation_Rate_v.v;
            }

            decimal retailPriceWithDisount = decimal.Round(retailPricePerunit * xdQuantity * (1 - xData.ExtraDiscount), GlobalData.BaseCurrency.DecimalPlaces);
            decimal netprice = decimal.Round(retailPriceWithDisount / (1 + taxRate), GlobalData.BaseCurrency.DecimalPlaces);
            decimal taxprice = retailPriceWithDisount - netprice;
            //ID docInvoice_ShopC_Item = null;
            decimal_v extraDiscount_v = new decimal_v(xData.ExtraDiscount);

            if (ID.Validate(stock_ID))
            {
               // this.m_ShopShelf_Source.Add_Stock_Data(stock_ID, xdQuantity);
            }
        }

        internal bool ItemEquals(Item_Data xItemData)
        {
           if (Item_UniqueName!=null)
            {
                if (xItemData.Item_UniqueName!=null)
                {
                    return Item_UniqueName.Equals(xItemData.Item_UniqueName);
                }
            }
            return false;
        }

        internal ID Find_Item_ID()
        {
            ID item_ID = null;
            if (f_Item.Get(Item_UniqueName, ref item_ID))
            {
                return item_ID;
            }
            else
            {
                return null;
            }
        }
    }
}
