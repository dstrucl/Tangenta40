#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;
using TangentaDB;

namespace TangentaDB
{

    public static class f_Atom_Price_ShopBItem
    {
        public static bool Get(string DocInvoice,
                                 long Price_SimpleItem_ID,
                                 long DocInvoice_ID,
                                 ref long DocInvoice_ShopB_Item_ID,
                                 ref int Quantity,
                                 ref decimal RetailSimpleItemPrice,
                                 ref decimal Discount,
                                 ref decimal ExtraDiscount,
                                 ref decimal taxRate,
                                 ref string taxName,
                                 ref decimal RetailSimpleItemPriceWithDiscount,
                                 ref decimal TaxPrice,
                                 ref decimal PriceWithoutTax
                                 )
        {
            if (Find_DocInvoice_ShopB_Item_ID(DocInvoice,DocInvoice_ID, Price_SimpleItem_ID, ref DocInvoice_ShopB_Item_ID, ref Quantity, ref RetailSimpleItemPrice, ref Discount, ref ExtraDiscount, ref taxRate, ref taxName, ref RetailSimpleItemPriceWithDiscount, ref TaxPrice))
            {
                if (DocInvoice_ShopB_Item_ID >= 0)
                {
                    return true;
                }
                else
                {
                    long PriceList_ID = -1;
                    long SimpleItem_ID = -1;
                    long Taxation_ID = -1;
                    if (Find_PriceList_SimpleItem_Taxation(Price_SimpleItem_ID,ref RetailSimpleItemPrice,ref Discount,ref taxRate,ref taxName, ref PriceList_ID, ref SimpleItem_ID, ref Taxation_ID))
                    {
                        long Atom_PriceList_ID = -1;

                        if (f_Atom_PriceList.Get(PriceList_ID, ref Atom_PriceList_ID))
                        {
                            long Atom_SimpleItem_ID = -1;
                            if (f_Atom_ShopBItem.Get(SimpleItem_ID, ref Atom_SimpleItem_ID))
                            {
                                long Atom_Taxation_ID = -1;
                                if (f_Atom_Taxation.Get(Taxation_ID, ref Atom_Taxation_ID))
                                {
                                    List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                                    string sparam_RetailSimpleItemPrice = "@par_RetailSimpleItemPrice";
                                    DBConnectionControl40.SQL_Parameter par_RetailSimpleItemPrice = new DBConnectionControl40.SQL_Parameter(sparam_RetailSimpleItemPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, RetailSimpleItemPrice);
                                    lpar.Add(par_RetailSimpleItemPrice);

                                    int decimal_places = 2;
                                    if (GlobalData.BaseCurrency!=null)
                                    {
                                        decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                                    }

                                    decimal dQuantity = Convert.ToDecimal(Quantity);

                                    StaticLib.Func.CalculatePrice(RetailSimpleItemPrice, dQuantity, Discount, ExtraDiscount, taxRate, ref RetailSimpleItemPriceWithDiscount, ref TaxPrice, ref PriceWithoutTax, decimal_places);

                                  
                                    //decimal xRetailSimpleItemPriceWithDiscount =  decimal.Round((RetailSimpleItemPrice - RetailSimpleItemPrice * Discount),decimal_places);
                                    //RetailSimpleItemPriceWithDiscount = decimal.Round((xRetailSimpleItemPriceWithDiscount - decimal.Round(xRetailSimpleItemPriceWithDiscount * ExtraDiscount, decimal_places)) * Quantity, decimal_places);
                                    
                                    //TaxPrice = decimal.Round(RetailSimpleItemPriceWithDiscount * taxRate, decimal_places);
                                    //PriceWithoutTax = RetailSimpleItemPriceWithDiscount - TaxPrice;

                                    string sparam_RetailSimpleItemPriceWithDiscount = "@par_RetailSimpleItemPriceWithDiscount";
                                    DBConnectionControl40.SQL_Parameter par_RetailSimpleItemPriceWithDiscount = new DBConnectionControl40.SQL_Parameter(sparam_RetailSimpleItemPriceWithDiscount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, RetailSimpleItemPriceWithDiscount);
                                    lpar.Add(par_RetailSimpleItemPriceWithDiscount);
                                    string sparam_Discount = "@par_Discount";
                                    DBConnectionControl40.SQL_Parameter par_Discount = new DBConnectionControl40.SQL_Parameter(sparam_Discount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Discount);
                                    lpar.Add(par_Discount);
                                    string sparam_ExtraDiscount = "@par_ExtraDiscount";
                                    DBConnectionControl40.SQL_Parameter par_ExtraDiscount = new DBConnectionControl40.SQL_Parameter(sparam_ExtraDiscount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, ExtraDiscount);
                                    lpar.Add(par_ExtraDiscount);
                                    string sparam_TaxPrice = "@par_TaxPrice";
                                    DBConnectionControl40.SQL_Parameter par_TaxPrice = new DBConnectionControl40.SQL_Parameter(sparam_TaxPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                                    lpar.Add(par_TaxPrice);
                                    string sql = null;
                                    if (DocInvoice == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaDB:f_PriceAtom_ServiceAtom.cs:f_Atom_Price_ShopBItem:DocInvoice is null.");
                                        return false;
                                    }
                                    else
                                    {
                                        sql = @"insert into "+DocInvoice+@"_ShopB_Item 
                                                            (RetailSimpleItemPrice,
                                                             Discount,
                                                             iQuantity,
                                                             RetailSimpleItemPriceWithDiscount,
                                                             ExtraDiscount,
                                                             TaxPrice,
                                                             Atom_SimpleItem_ID,
                                                             Atom_PriceList_ID,
                                                             Atom_Taxation_ID,
                                                             "+ DocInvoice + @"_ID
                                                            )
                                                            values
                                                            (" + sparam_RetailSimpleItemPrice + @",
                                                             " + sparam_Discount + @",
                                                             1,
                                                             " + sparam_RetailSimpleItemPriceWithDiscount + @",
                                                             " + sparam_ExtraDiscount + @",
                                                             " + sparam_TaxPrice + @",
                                                             " + Atom_SimpleItem_ID.ToString() + @",
                                                             " + Atom_PriceList_ID.ToString() + @",
                                                             " + Atom_Taxation_ID.ToString() + @",
                                                             " + DocInvoice_ID.ToString() + @"
                                                            )";
                                    }
                                    object objretx = null;
                                    string Err = null;
                                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref DocInvoice_ShopB_Item_ID, ref objretx, ref Err, DocInvoice+"_ShopB_Item"))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:f_DocInvoice_ShopB_Item:Get:" + sql + "\r\nErr=" + Err);
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
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private static bool Find_PriceList_SimpleItem_Taxation(long Price_SimpleItem_ID,ref decimal RetailSimpleItemPrice,ref decimal Discount,ref decimal taxRate, ref string taxName, ref long PriceList_ID, ref long SimpleItem_ID, ref long Taxation_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql_find = @"select 
                                        RetailSimpleItemPrice,
                                        Discount,
                                        Taxation.Rate,
                                        Taxation.Name,
                                        PriceList_ID,
                                        SimpleItem_ID,
                                        Taxation_ID 
                                        from Price_SimpleItem 
                                        INNER JOIN Taxation on Price_SimpleItem.Taxation_ID = Taxation.ID
                                        where Price_SimpleItem.ID = " + Price_SimpleItem_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    taxRate = (decimal)dt.Rows[0]["Rate"];
                    taxName = (string)dt.Rows[0]["Name"];
                    RetailSimpleItemPrice = (decimal)dt.Rows[0]["RetailSimpleItemPrice"];
                    object oDiscount = dt.Rows[0]["Discount"];
                    Discount = 0;
                    if (oDiscount is decimal)
                    {
                        Discount = (decimal)oDiscount;
                    }
                    Taxation_ID = (long)dt.Rows[0]["Taxation_ID"];
                    PriceList_ID = (long)dt.Rows[0]["PriceList_ID"];
                    SimpleItem_ID = (long)dt.Rows[0]["SimpleItem_ID"];
                    Taxation_ID = (long)dt.Rows[0]["Taxation_ID"];
                    return true;
                }
                else
                {
                    PriceList_ID = -1;
                    SimpleItem_ID = -1;
                    Taxation_ID = -1;
                    LogFile.Error.Show(@"ERROR:PriceList_ID not found in Price_SimpleItem for Price_SimpleItem_ID = " + Price_SimpleItem_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_DocInvoice_ShopB_Item_ID:select
                                DocInvoice_ShopB_Item.ID as DocInvoice_ShopB_Item_ID
                                from DocInvoice_ShopB_Item:\r\nErr=" + Err);
                return false;
            }


        }

        private static bool Find_DocInvoice_ShopB_Item_ID(string DocInvoice,
                                                          long DocInvoice_ID,
                                                          long Price_SimpleItem_ID, 
                                                          ref long DocInvoice_ShopB_Item_ID,
                                                          ref int Quantity,
                                                          ref decimal RetailSimpleItemPrice,
                                                          ref decimal Discount,
                                                          ref decimal ExtraDiscount,
                                                          ref decimal taxRate,
                                                          ref string  taxName,
                                                          ref decimal RetailSimpleItemPriceWithDiscount,
                                                          ref decimal TaxPrice)
        {
            string Err = null;
            DataTable dt = new DataTable();
            int decimal_places = GlobalData.Get_BaseCurrency_DecimalPlaces();

            string sql_find_Atom_SimpleItem_ID = @"select
                                " + DocInvoice + @"_ShopB_Item.ID as "+DocInvoice+@"_ShopB_Item_ID,
                                " + DocInvoice + @"_ShopB_Item.RetailSimpleItemPrice,
                                " + DocInvoice + @"_ShopB_Item.Discount,
                                " + DocInvoice + @"_ShopB_Item.iQuantity,
                                " + DocInvoice + @"_ShopB_Item.RetailSimpleItemPriceWithDiscount,
                                " + DocInvoice + @"_ShopB_Item.ExtraDiscount,
                                " + DocInvoice + @"_ShopB_Item.TaxPrice,
                                Atom_Taxation.Rate,
                                Atom_Taxation.Name
                                from "+DocInvoice+@"_ShopB_Item
                                inner join Atom_PriceList on "+DocInvoice+@"_ShopB_Item.Atom_PriceList_ID = Atom_PriceList.ID
                                inner join Atom_SimpleItem on "+DocInvoice+@"_ShopB_Item.Atom_SimpleItem_ID = Atom_SimpleItem.ID
				                inner join Atom_SimpleItem_Name on Atom_SimpleItem.Atom_SimpleItem_Name_ID = Atom_SimpleItem_Name.ID
                                inner join PriceList on Atom_PriceList.Name = PriceList.Name
                                inner join Price_SimpleItem on Price_SimpleItem.PriceList_ID = PriceList.ID
                                inner join SimpleItem on   Price_SimpleItem.SimpleItem_ID = SimpleItem.ID and
                                                        Atom_SimpleItem_Name.Abbreviation = SimpleItem.Abbreviation and
												        Atom_SimpleItem_Name.Name = SimpleItem.Name 
                                inner join Atom_Taxation on "+DocInvoice+@"_ShopB_Item.Atom_Taxation_ID = Atom_Taxation.ID
                                inner join Taxation on Taxation.Name = Atom_Taxation.Name and Taxation.Rate = Atom_Taxation.Rate
                                where SimpleItem.ToOffer = 1 and "+DocInvoice+@"_ID = " + DocInvoice_ID.ToString() + " and Price_SimpleItem.ID =  " + Price_SimpleItem_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_SimpleItem_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    DocInvoice_ShopB_Item_ID = (long)dt.Rows[0][DocInvoice+"_ShopB_Item_ID"];
                    Quantity = (int)dt.Rows[0]["iQuantity"];
                    RetailSimpleItemPrice = (decimal)dt.Rows[0]["RetailSimpleItemPrice"];
                    Discount = (decimal)dt.Rows[0]["Discount"];
                    ExtraDiscount = (decimal)dt.Rows[0]["ExtraDiscount"];
                    taxRate = (decimal)dt.Rows[0]["Rate"];
                    taxName = (string)dt.Rows[0]["Name"];
                    RetailSimpleItemPriceWithDiscount = (decimal)dt.Rows[0]["RetailSimpleItemPriceWithDiscount"];
                    TaxPrice = (decimal)dt.Rows[0]["TaxPrice"];
                }
                else
                {
                    DocInvoice_ShopB_Item_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_DocInvoice_ShopB_Item_ID:sql="+ sql_find_Atom_SimpleItem_ID+"\r\nErr=" + Err);
                return false;
            }
        }
    }
}
