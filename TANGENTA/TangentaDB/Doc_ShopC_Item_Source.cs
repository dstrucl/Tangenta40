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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
   
    public class Doc_ShopC_Item_Source
    {
        public f_Stock_Data Stock_Data = null;

        public ID Doc_ShopC_Item_Source_ID = null;
        public ID Doc_ShopC_Item_ID = null;




        public decimal RetailPricePerUnit = 0;
        public decimal RetailPrice = 0;
        public decimal NetPrice = 0;
        public string_v StockTakeName_v = null;
        public DateTime_v StockTakeDate_v = null;


        public string_v Item_UniqueName_v = null;

        public decimal dQuantity = 0;
        public decimal SourceDiscount = 0;
        public decimal RetailPriceWithDiscount = 0;
        public decimal TaxPrice = 0;

        public void Set(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            Stock_Data = new f_Stock_Data(dr);
            dQuantity = DBTypes.tf._set_decimal(dr[c.dQuantity]);
            RetailPriceWithDiscount = DBTypes.tf._set_decimal(dr[c.RetailPriceWithDiscount]);
            TaxPrice = DBTypes.tf._set_decimal(dr[c.TaxPrice]);
           
            Item_UniqueName_v = DBTypes.tf.set_string(dr[c.Item_UniqueName]);
            StockTakeName_v = DBTypes.tf.set_string(dr[c.StockTakeName]);
            StockTakeDate_v = DBTypes.tf.set_DateTime(dr[c.StockTake_Date]);
            Doc_ShopC_Item_ID = DBTypes.tf.set_ID(dr[c.Doc_ShopC_Item_ID]);
            Doc_ShopC_Item_Source_ID = DBTypes.tf.set_ID(dr[c.Doc_ShopC_Item_Source_ID]);
        }

        public Doc_ShopC_Item_Source()
        {
        }

        public Doc_ShopC_Item_Source(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            Set(dr,c);
        } 


        public void Set(string docType, System.Data.DataRow dria)
        {
            Doc_ShopC_Item_ID = tf.set_ID(dria[docType + "_ShopC_Item_ID"]);
            Stock_Data = new f_Stock_Data(dria);
            //Stock_ID = tf.set_ID(dria["Stock_ID"]);
            //Stock_ImportTime = tf.set_DateTime(dria["Stock_ImportTime"]);
            //Stock_ExpiryDate = tf.set_DateTime(dria["Stock_ExpiryDate"]);
            dQuantity = tf._set_decimal(dria["dQuantity"]);
        }

        public void SetNew(ID doc_ShopC_Item_ID,
                        ID doc_ShopC_Item_Source_ID,
                        ID stock_ID,
                        decimal xdQuantity,
                        decimal sourceDiscount,
                        decimal retailPriceWithDiscount,
                        decimal taxPrice,
                        DateTime_v expiryDate_v
                        )
        {
            Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
            Doc_ShopC_Item_Source_ID = doc_ShopC_Item_Source_ID;
            
            dQuantity = xdQuantity;
            SourceDiscount = sourceDiscount;
            RetailPriceWithDiscount = retailPriceWithDiscount;
            TaxPrice = taxPrice;
            Stock_Data = new f_Stock_Data(null, expiryDate_v, null, null, stock_ID, null);
        }


        internal void GetPrices(decimal taxRate, decimal discount, decimal extraDiscount,decimal retailPricePerUnit, ref decimal xRetailPrice, ref decimal xRetailPriceWithDiscount, ref decimal xTaxPrice, ref decimal xNetPrice)
        {
            int decimal_places = 2;
            if (GlobalData.BaseCurrency != null)
            {
                decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
            }
            StaticLib.Func.CalculatePrice(retailPricePerUnit, dQuantity, discount, extraDiscount, taxRate,ref xRetailPrice, ref xRetailPriceWithDiscount, ref xTaxPrice, ref xNetPrice, decimal_places);
            this.NetPrice = xNetPrice;
        }

        private bool setQuantity(string docType,decimal xdQuantity, Transaction transaction)
        {
            if (xdQuantity == this.dQuantity)
            {
                if (docType.Equals(GlobalData.const_DocInvoice))
                {
                    if (f_DocInvoice_ShopC_Item_Source.Delete(this.Doc_ShopC_Item_Source_ID, transaction))
                    {
                        this.dQuantity = 0;
                        return true;
                    }
                }
            }
            else if (xdQuantity < this.dQuantity)
            {
                decimal dnew_quantity_in_stock = this.dQuantity - xdQuantity;
                if (docType.Equals(GlobalData.const_DocInvoice))
                {
                    if (f_DocInvoice_ShopC_Item_Source.UpdateQuantity(this.Doc_ShopC_Item_Source_ID, dnew_quantity_in_stock,transaction))
                    {
                        this.dQuantity = dnew_quantity_in_stock;
                        return true;
                    }
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Doc_ShopC_Item_Source:SendBackToStock: quantity=" + xdQuantity.ToString() + " to send back to stock is bigger than current quantity = " + dQuantity.ToString());
            }
            return false;
        }

        internal bool SendBackToStock(string docType,decimal xdQuantity,Item_Data xdata, Transaction transaction)
        {
            if (xdata != null)
            {
                if (xdata.ReceiveBackToStock(this.Stock_Data.Stock_ID, this.dQuantity, transaction))
                {
                    return setQuantity(docType, xdQuantity, transaction);
                }
            }
            else
            {
                decimal_v dQuantityInStock_v = null;
                if (f_Stock.GetQuantity(this.Stock_Data.Stock_ID, ref dQuantityInStock_v, transaction))
                {
                    if (dQuantityInStock_v != null)
                    {
                        decimal dnew_quantity_in_stock = dQuantityInStock_v.v + xdQuantity;
                        if (f_Stock.UpdateQuantity(this.Stock_Data.Stock_ID, dnew_quantity_in_stock, transaction))
                        {
                            return setQuantity(docType, xdQuantity, transaction);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:Doc_ShopC_Item_Source:SendBackToStock:dQuantity for Stock_ID =" + Stock_Data.Stock_ID.ToString()+ " not found or dQuantity is null !");
                    }
                }
               
            }
            return false;
        }

        internal bool RemoveFactory(string docType,decimal xdQuantity, Transaction transaction)
        {
            if (xdQuantity == this.dQuantity)
            {
                if (docType.Equals(GlobalData.const_DocInvoice))
                {
                    if (f_DocInvoice_ShopC_Item_Source.Delete(this.Doc_ShopC_Item_Source_ID, transaction))
                    {
                        this.dQuantity = 0;
                        return true;
                    }
                }
            }
            else if (xdQuantity < this.dQuantity)
            {
                decimal dnew_quantity_in_stock = this.dQuantity - xdQuantity;
                if (docType.Equals(GlobalData.const_DocInvoice))
                {
                    if (f_DocInvoice_ShopC_Item_Source.UpdateQuantity(this.Doc_ShopC_Item_Source_ID, dnew_quantity_in_stock, transaction))
                    {
                        this.dQuantity = dnew_quantity_in_stock;
                        return true;
                    }
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Doc_ShopC_Item_Source:SendBackToStock: quantity=" + xdQuantity.ToString() + " to send back to stock is bigger than current quantity = " + dQuantity.ToString());
            }
            return false;
        }

        internal void Set(decimal dQuantity_FromFactory2Add, decimal retailPriceWithDiscount, decimal taxPrice)
        {
            this.dQuantity = dQuantity_FromFactory2Add;
            this.RetailPriceWithDiscount = retailPriceWithDiscount;
            this.TaxPrice = taxPrice;
        }
    }
}
