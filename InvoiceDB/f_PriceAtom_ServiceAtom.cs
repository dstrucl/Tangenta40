using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;
using InvoiceDB;

namespace InvoiceDB
{

    public static class f_Atom_Price_SimpleItem
    {
        public static bool Get(long Price_SimpleItem_ID,
                                 long ProformaInvoice_ID,
                                 ref long Atom_Price_SimpleItem_ID,
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
            if (Find_Atom_Price_SimpleItem_ID(ProformaInvoice_ID, Price_SimpleItem_ID, ref Atom_Price_SimpleItem_ID, ref Quantity, ref RetailSimpleItemPrice, ref Discount, ref ExtraDiscount, ref taxRate, ref taxName, ref RetailSimpleItemPriceWithDiscount, ref TaxPrice))
            {
                if (Atom_Price_SimpleItem_ID >= 0)
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
                            if (f_Atom_SimpleItem.Get(SimpleItem_ID, ref Atom_SimpleItem_ID))
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
                                    string sql = @"insert into Atom_Price_SimpleItem 
                                                            (RetailSimpleItemPrice,
                                                             Discount,
                                                             iQuantity,
                                                             RetailSimpleItemPriceWithDiscount,
                                                             ExtraDiscount,
                                                             TaxPrice,
                                                             Atom_SimpleItem_ID,
                                                             Atom_PriceList_ID,
                                                             Atom_Taxation_ID,
                                                             ProformaInvoice_ID
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
                                                             " + ProformaInvoice_ID.ToString() + @"
                                                            )";
                                    object objretx = null;
                                    string Err = null;
                                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Price_SimpleItem_ID, ref objretx, ref Err, "Atom_Price_SimpleItem"))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:f_Atom_Price_SimpleItem:Get:" + sql + "\r\nErr=" + Err);
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
                    Discount = (decimal)dt.Rows[0]["Discount"];
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
                LogFile.Error.Show(@"ERROR:Find_Atom_Price_SimpleItem_ID:select
                                Atom_Price_SimpleItem.ID as Atom_Price_SimpleItem_ID
                                from Atom_Price_SimpleItem:\r\nErr=" + Err);
                return false;
            }


        }

        private static bool Find_Atom_Price_SimpleItem_ID(
                                                          long ProformaInvoice_ID,
                                                          long Price_SimpleItem_ID, 
                                                          ref long Atom_Price_SimpleItem_ID,
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
                                Atom_Price_SimpleItem.ID as Atom_Price_SimpleItem_ID,
                                Atom_Price_SimpleItem.RetailSimpleItemPrice,
                                Atom_Price_SimpleItem.Discount,
                                Atom_Price_SimpleItem.iQuantity,
                                Atom_Price_SimpleItem.RetailSimpleItemPriceWithDiscount,
                                Atom_Price_SimpleItem.ExtraDiscount,
                                Atom_Price_SimpleItem.TaxPrice,
                                Atom_Taxation.Rate,
                                Atom_Taxation.Name
                                from Atom_Price_SimpleItem
                                inner join Atom_PriceList on Atom_Price_SimpleItem.Atom_PriceList_ID = Atom_PriceList.ID
                                inner join Atom_SimpleItem on Atom_Price_SimpleItem.Atom_SimpleItem_ID = Atom_SimpleItem.ID
				                inner join Atom_SimpleItem_Name on Atom_SimpleItem.Atom_SimpleItem_Name_ID = Atom_SimpleItem_Name.ID
                                inner join PriceList on Atom_PriceList.Name = PriceList.Name
                                inner join Price_SimpleItem on Price_SimpleItem.PriceList_ID = PriceList.ID
                                inner join SimpleItem on   Price_SimpleItem.SimpleItem_ID = SimpleItem.ID and
                                                        Atom_SimpleItem_Name.Abbreviation = SimpleItem.Abbreviation and
												        Atom_SimpleItem_Name.Name = SimpleItem.Name 
                                inner join Atom_Taxation on Atom_Price_SimpleItem.Atom_Taxation_ID = Atom_Taxation.ID
                                inner join Taxation on Taxation.Name = Atom_Taxation.Name and Taxation.Rate = Atom_Taxation.Rate
                                where SimpleItem.ToOffer = 1 and ProformaInvoice_ID = " + ProformaInvoice_ID.ToString() + " and Price_SimpleItem.ID =  " + Price_SimpleItem_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_SimpleItem_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Price_SimpleItem_ID = (long)dt.Rows[0]["Atom_Price_SimpleItem_ID"];
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
                    Atom_Price_SimpleItem_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_Price_SimpleItem_ID:select
                                Atom_Price_SimpleItem.ID as Atom_Price_SimpleItem_ID
                                from Atom_Price_SimpleItem:\r\nErr=" + Err);
                return false;
            }

        }
    }
}
