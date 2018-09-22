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
using System.Windows.Forms;
using DBTypes;
using DBConnectionControl40;

namespace TangentaDB
{
    public class CurrentDoc
    {
        public class TaxInvoice
        {
            public ID StornoDocInvoice_ID = null;
            public string_v Invoice_Reference_Type_v = null;
            public bool_v bStorno_v = null;
        }

        public class ProformaInvoice
        {
            public ID TermsOfPayment_ID = null;
            public string_v TermsOfPayment_Description_v = null;
            public long_v DocDuration_v = null;
            public int_v DocDuration_Type_v = null;
        }

        public xCurrency Currency = null;
        public ID Atom_Currency_ID = null;

        public InvoiceData.eType m_eType = InvoiceData.eType.UNKNOWN;

        public ShopABC m_InvoiceDB = null;

        public string sql_Price_Item_Stock_template = null;


        public DataTable dtCurrent_Invoice = new DataTable();
        public DataTable dtCurrent_Atom_Price_ShopBItem = new DataTable();

        public DataTable dtCurrent_DocInvoice_ShopC_Item = new DataTable();

        public ShopShelf m_ShopShelf = new ShopShelf();
        public Basket m_Basket = new Basket();

        DBTablesAndColumnNames DBtcn = null;

        public int FinancialYear;
        public int NumberInFinancialYear;


        public int DraftNumber;

        public ID m_Doc_ID = null;
        public ID Doc_ID
        {
            get
            {
                return m_Doc_ID;
            }
            set
            {
                m_Doc_ID = value;
            }
        }

        public DateTime EventTime = DateTime.MinValue;

        // DocInvoice
        public CurrentDoc.TaxInvoice TInvoice = new CurrentDoc.TaxInvoice();

        // DocProformaInvoice
        public CurrentDoc.ProformaInvoice PInvoice = new CurrentDoc.ProformaInvoice();


        public ID Atom_Customer_Person_ID = null;
        public ID Atom_Customer_Org_ID = null;
        public bool bDraft = false;
        public bool m_Exist = false;
        public bool Exist
        {
            get { return m_Exist; }

            set {
                    m_Exist = value;
                    if (!m_Exist)
                    {
                        dtCurrent_Atom_Price_ShopBItem.Clear();
                        dtCurrent_DocInvoice_ShopC_Item.Clear();
                        if (m_Basket != null)
                        {
                            m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Clear();
                        }
                    }
                }
        
       }

        public CurrentDoc(ShopABC xInvoiceDB, DBTablesAndColumnNames xDBtcn)
        {
            m_InvoiceDB = xInvoiceDB;
            DBtcn = xDBtcn;
            FinancialYear = DateTime.Now.Year;
            NumberInFinancialYear = 1;
            Doc_ID = new ID();
            Doc_ID.V = Doc_ID.InvalidID;
        }


        public void Set_SelectedShopB_Items(string xDocTyp,DataGridView dgv_SelectedSimpleItems,
                                           DataTable dt_SelectedSimpleItem,
                                           DataGridView dgv_SimpleItem,
                                           DataTable dt_SimpleItems)
        {
            ID Atom_SimpleItem_ID;
            ID DocInvoice_ShopB_Item_DocInvoice_ID;
            ID DocInvoice_ShopB_Item_SimpleItem_ID;
            ID DocInvoice_ShopB_Item_Atom_SimpleItem_Name_ID;
            ID DocInvoice_ShopB_Item_Atom_SimpleItem_Image_ID;
            ID DocInvoice_ShopB_Item_Atom_Taxation_ID;
            int DocInvoice_ShopB_Item_Quantity;
            string DocInvoice_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name;
            string DocInvoice_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Abbreviation;
            decimal DocInvoice_ShopB_Item_RetailSimpleItemPrice;
            decimal DocInvoice_ShopB_Item_Discount;
            string DocInvoice_ShopB_Item_Atom_Taxation_Name;
            decimal DocInvoice_ShopB_Item_Atom_Taxation_Rate;
            decimal DocInvoice_ShopB_Item_TaxPrice;
            decimal DocInvoice_ShopB_Item_RetailSimpleItemPriceWithDiscount;
            decimal DocInvoice_ShopB_Item_PriceWithoutTax;
            decimal DocInvoice_ShopB_Item_ExtraDiscount;
            dt_SelectedSimpleItem.Clear();
            foreach (DataRow drsa in dtCurrent_Atom_Price_ShopBItem.Rows)
            {
                Atom_SimpleItem_ID = tf.set_ID(drsa["ID"]);
                DocInvoice_ShopB_Item_DocInvoice_ID = tf.set_ID(drsa[xDocTyp+"_ID"]);
                DocInvoice_ShopB_Item_SimpleItem_ID = tf.set_ID(drsa["SimpleItem_ID"]);
                DocInvoice_ShopB_Item_Atom_SimpleItem_Name_ID = tf.set_ID(drsa["Atom_SimpleItem_Name_ID"]);
                DocInvoice_ShopB_Item_Atom_SimpleItem_Image_ID = tf.set_ID(drsa["Atom_SimpleItem_Image_ID"]);

                DocInvoice_ShopB_Item_Atom_Taxation_ID = tf.set_ID(drsa["Atom_Taxation_ID"]);
                DocInvoice_ShopB_Item_Quantity = (int)drsa["iQuantity"];
                DocInvoice_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name = (string)drsa["Name"];
                DocInvoice_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Abbreviation = (string)drsa["Abbreviation"];
                DocInvoice_ShopB_Item_RetailSimpleItemPrice = (decimal)drsa["RetailSimpleItemPrice"];
                DocInvoice_ShopB_Item_Discount = (decimal)drsa["Discount"];
                DocInvoice_ShopB_Item_ExtraDiscount = (decimal)drsa["ExtraDiscount"];
                DocInvoice_ShopB_Item_Atom_Taxation_Name = (string)drsa["Atom_Taxation_Name"];
                DocInvoice_ShopB_Item_Atom_Taxation_Rate = (decimal)drsa["Atom_Taxation_Rate"];
                DocInvoice_ShopB_Item_TaxPrice = (decimal)drsa["TaxPrice"];
                DocInvoice_ShopB_Item_RetailSimpleItemPriceWithDiscount = (decimal)drsa["RetailSimpleItemPriceWithDiscount"];

                DocInvoice_ShopB_Item_PriceWithoutTax = DocInvoice_ShopB_Item_RetailSimpleItemPriceWithDiscount - DocInvoice_ShopB_Item_TaxPrice;

                DataRow dr = dt_SelectedSimpleItem.NewRow();
                //dr[DBtcn.column_SelectedShopBItem_dt_ShopBItem_Index] = Find_dt_SimpleItem_Index(dt_SimpleItems, DocInvoice_ShopB_Item_SimpleItem_ID);
                dr[DBtcn.column_Selected_Atom_Price_ShopBItem_ID] = Atom_SimpleItem_ID.V;
                dr[DBtcn.column_SelectedShopBItem_ShopBItem_ID] = DocInvoice_ShopB_Item_SimpleItem_ID.V;
                dr[DBtcn.column_SelectedShopBItem_Count] = DocInvoice_ShopB_Item_Quantity;
                dr[DBtcn.column_SelectedShopBItemName] = DocInvoice_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name;
                dr[DBtcn.column_SelectedShopBItemPriceWithoutTax] = DocInvoice_ShopB_Item_PriceWithoutTax;
                dr[DBtcn.column_SelectedShopBItemPriceTax] = DocInvoice_ShopB_Item_TaxPrice;
                dr[DBtcn.column_SelectedShopBItem_TaxName] = DocInvoice_ShopB_Item_Atom_Taxation_Name;
                dr[DBtcn.column_SelectedShopBItem_TaxRate] = DocInvoice_ShopB_Item_Atom_Taxation_Rate;
                dr[DBtcn.column_SelectedShopBItem_ExtraDiscount] = DocInvoice_ShopB_Item_ExtraDiscount;
                dr[DBtcn.column_SelectedShopBItemPrice] = DocInvoice_ShopB_Item_RetailSimpleItemPriceWithDiscount;
                dr[DBtcn.column_SelectedShopBItemRetailPricePerUnit] = DocInvoice_ShopB_Item_RetailSimpleItemPrice;
                dt_SelectedSimpleItem.Rows.Add(dr);
                int index = dt_SelectedSimpleItem.Rows.IndexOf(dr);
                if (DocInvoice_ShopB_Item_ExtraDiscount != 0)
                {
                    try
                    {
                        dgv_SelectedSimpleItems.Rows[index].Cells["btn_discount"].Value = DocInvoice_ShopB_Item_ExtraDiscount;
                    }
                    catch
                    {
                        dgv_SelectedSimpleItems.Rows[index].Cells["SelectedSimpleItem_ExtraDiscount"].Value = DocInvoice_ShopB_Item_ExtraDiscount;
                    }
                }
            }
            m_InvoiceDB.Set_dgv_selected_ShopB_Items_Columns(dgv_SelectedSimpleItems);

        }

        private int Find_dt_SimpleItem_Index(DataTable dt_SimpleItems, ID Atom_SimpleItem_SimpleItem_ID)
        {
            DataRow[] dr = null;
            if (dt_SimpleItems.Rows.Count > 0)
            {
                dr = dt_SimpleItems.Select("ID=" + Atom_SimpleItem_SimpleItem_ID.ToString());
                if (dr.Count() > 0)
                {
                    return dt_SimpleItems.Rows.IndexOf(dr[0]);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public bool Add_DocInvoice_Atom_Price_Items_Stock(ID xAtom_WorkPeriod_ID,
                                                             string xDocTyp,
                                                             ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd,
                                                             bool b_from_stock
                                                             )
        {
            return Add_DocInvoice_ShopC_Item(xAtom_WorkPeriod_ID, xDocTyp, ref appisd, b_from_stock);
        }

        private bool Add_DocInvoice_ShopC_Item(ID xAtom_WorkPeriod_ID, string xDocTyp, ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, bool b_from_stock)
        {
            ID Atom_Price_Item_ID = null;
            if (Get_Atom_Price_Item(ref appisd))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                int decimal_places = GlobalData.Get_BaseCurrency_DecimalPlaces();
                Atom_Price_Item_ID = appisd.Atom_Price_Item_ID;



                string spar_ExtraDiscount = "@par_ExtraDiscount";
                SQL_Parameter par_ExtraDiscount = new SQL_Parameter(spar_ExtraDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, appisd.ExtraDiscount.v);

                decimal dQuantity_from_factory = appisd.m_ShopShelf_Source.dQuantity_from_factory;
                decimal dQuantity_from_stock = appisd.m_ShopShelf_Source.dQuantity_from_stock;

                string spar_RetailPriceWithDiscount = "@par_RetailPriceWithDiscount";
                string spar_TaxPrice = "@par_TaxPrice";
                string spar_dQuantity = "@par_dQuantity";

                foreach (Stock_Data stock_data in appisd.m_ShopShelf_Source.Stock_Data_List)
                {
                    if (b_from_stock)
                    {
                        if (stock_data.Stock_ID == null)
                        {
                            continue;
                        }

                        if (stock_data.dQuantity_from_stock != null)
                        {
                            if (stock_data.dQuantity_from_stock.v == 0)
                            {
                                continue;
                            }
                        }
                    }

                    decimal RetailPriceWithDiscount = 0;

                    decimal TaxPrice = 0;

                    decimal RetailPriceWithDiscount_WithoutTax = 0;

                    lpar.Clear();
                    lpar.Add(par_ExtraDiscount);
                    ID Stock_ID = stock_data.Stock_ID;



                    string scond_Stock_ID = null;
                    string sValue_Stock_ID = null;
                    decimal dquantity_in_stock_data = 0;
                    if (Stock_ID != null)
                    {
                        dquantity_in_stock_data = stock_data.dQuantity.v;
                        StaticLib.Func.CalculatePrice(appisd.RetailPricePerUnit.v, dquantity_in_stock_data, appisd.Discount.v, appisd.ExtraDiscount.v, appisd.Atom_Taxation_Rate.v, ref RetailPriceWithDiscount, ref TaxPrice, ref RetailPriceWithDiscount_WithoutTax, decimal_places);
                        SQL_Parameter par_dQuantity = null;
                        par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity_in_stock_data);
                        lpar.Add(par_dQuantity);
                        scond_Stock_ID = "(Stock_ID = " + Stock_ID.ToString() + ")";
                        sValue_Stock_ID = Stock_ID.ToString();
                        SQL_Parameter par_RetailPriceWithDiscount = new SQL_Parameter(spar_RetailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailPriceWithDiscount);
                        lpar.Add(par_RetailPriceWithDiscount);
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                    }
                    else
                    {
                        StaticLib.Func.CalculatePrice(appisd.RetailPricePerUnit.v, dQuantity_from_factory, appisd.Discount.v, appisd.ExtraDiscount.v, appisd.Atom_Taxation_Rate.v, ref RetailPriceWithDiscount, ref TaxPrice, ref RetailPriceWithDiscount_WithoutTax, decimal_places);
                        SQL_Parameter par_dQuantity = null;
                        par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity_from_factory);
                        lpar.Add(par_dQuantity);
                        SQL_Parameter par_RetailPriceWithDiscount = new SQL_Parameter(spar_RetailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailPriceWithDiscount);
                        lpar.Add(par_RetailPriceWithDiscount);
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        scond_Stock_ID = "(Stock_ID is null)";
                        sValue_Stock_ID = "null";
                    }

                    string spar_ExpiryDate = "@par_ExpiryDate";

                    string scond_ExpiryDate = null;

                    string sValue_ExpiryDate = null;
                    if (stock_data.Stock_ExpiryDate != null)
                    {
                        SQL_Parameter par_ExpiryDate = new SQL_Parameter(spar_ExpiryDate, SQL_Parameter.eSQL_Parameter.Datetime, false, stock_data.Stock_ExpiryDate.v);
                        lpar.Add(par_ExpiryDate);
                        scond_ExpiryDate = "(ExpiryDate = " + spar_ExpiryDate + ")";
                        sValue_ExpiryDate = spar_ExpiryDate;
                    }
                    else
                    {
                        scond_ExpiryDate = "(ExpiryDate is null)";
                        sValue_ExpiryDate = "null";
                    }

                    if (xDocTyp == null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:CurrentInvoice.cs:Get_DocInvoice_ShopC_Item:xDocTyp==null.");
                        return false;
                    }

                    string sql_select_DocInvoice_ShopC_Item_ID = @"select ID as " + xDocTyp + @"_ShopC_Item_ID, 
                                                                    dQuantity,
                                                                    ExtraDiscount,
                                                                    RetailPriceWithDiscount,
                                                                    TaxPrice
                                                                    from " + xDocTyp + @"_ShopC_Item
                                                                    where " + xDocTyp + @"_ID = " + Doc_ID.ToString() + @" and
                                                                            Atom_Price_Item_ID = " + Atom_Price_Item_ID.ToString() + @" and "
                                                                                    + scond_ExpiryDate + @" and "
                                                                                    + scond_Stock_ID;
                    DataTable dt = new DataTable();
                    string Err = null;
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_DocInvoice_ShopC_Item_ID, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            appisd.DocInvoice_ShopC_Item_ID = tf.set_ID(dt.Rows[0][xDocTyp + "_ShopC_Item_ID"]);
                            // appisd.dQuantity_all.v = appisd.m_Warehouse.dQuantity_all;
                            appisd.RetailPriceWithDiscount = tf.set_decimal(dt.Rows[0]["RetailPriceWithDiscount"]);
                            appisd.ExtraDiscount = tf.set_decimal(dt.Rows[0]["ExtraDiscount"]);
                            appisd.TaxPrice = tf.set_decimal(dt.Rows[0]["TaxPrice"]);
                            decimal_v dQuantity_v = tf.set_decimal(dt.Rows[0]["dQuantity"]);
                            decimal dcurrent_quantity_in_basket = 0;
                            if (dQuantity_v != null)
                            {
                                dcurrent_quantity_in_basket = dQuantity_v.v;
                            }

                            //$$TODO  pias.Stock_ID = long_v.Copy(pis.Stock_ID);
                            string sql_update_DocInvoice_ShopC_Item_ID = @"update " + xDocTyp + @"_ShopC_Item set
                                                                    dQuantity = " + spar_dQuantity + @",
                                                                    ExtraDiscount = " + spar_ExtraDiscount + @",
                                                                    RetailPriceWithDiscount = " + spar_RetailPriceWithDiscount + @",
                                                                    TaxPrice= " + spar_TaxPrice + @"
                                                                    where " + xDocTyp + @"_ID = " + Doc_ID.ToString() + @" and
                                                                            Atom_Price_Item_ID = " + Atom_Price_Item_ID.ToString() + @" and "
                                                                                            + scond_ExpiryDate + @" and "
                                                                                            + scond_Stock_ID;
                            object ores = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_select_DocInvoice_ShopC_Item_ID, lpar, ref ores, ref Err))
                            {
                                if (Stock_ID != null)
                                {
                                    decimal newdquantity_in_stock_data = dquantity_in_stock_data -(dQuantity_from_stock - dcurrent_quantity_in_basket);

                                    if (newdquantity_in_stock_data >= 0)
                                    {
                                        stock_data.dQuantity_New_in_Stock = new decimal_v(newdquantity_in_stock_data);
                                        stock_data.Remove_from_StockShelf(xAtom_WorkPeriod_ID);
                                    }
                                }
                            }
                            continue;
                        }
                        else
                        {

                            string sql_insert_DocInvoice_ShopC_Item_ID = @"insert into " + xDocTyp + @"_ShopC_Item 
                                                                            (
                                                                            dQuantity,
                                                                            ExtraDiscount,
                                                                            RetailPriceWithDiscount,
                                                                            TaxPrice,
                                                                            " + xDocTyp + @"_ID,
                                                                            Atom_Price_Item_ID,
                                                                            ExpiryDate,
                                                                            Stock_ID
                                                                            )
                                                                            values
                                                                            (
                                                                            " + spar_dQuantity + @",
                                                                            " + spar_ExtraDiscount + @",
                                                                            " + spar_RetailPriceWithDiscount + @",
                                                                            " + spar_TaxPrice + @",
                                                                            " + Doc_ID.ToString() + @",
                                                                            " + Atom_Price_Item_ID.ToString() + @",
                                                                            " + sValue_ExpiryDate + @", 
                                                                            " + sValue_Stock_ID
                                                                                    + ")";
                            ID DocInvoice_ShopC_Item_ID = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert_DocInvoice_ShopC_Item_ID, lpar, ref DocInvoice_ShopC_Item_ID, ref Err, xDocTyp))
                            {
                                appisd.DocInvoice_ShopC_Item_ID = tf.set_ID(DocInvoice_ShopC_Item_ID);

                                if (Stock_ID != null)
                                {
                                    stock_data.Remove_from_StockShelf(xAtom_WorkPeriod_ID);
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Get_DocInvoice_ShopC_Item:sql=" + sql_insert_DocInvoice_ShopC_Item_ID + " failed!\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_DocInvoice_ShopC_Item:sql=" + sql_select_DocInvoice_ShopC_Item_ID + " failed!\r\nErr=" + Err);
                        return false;
                    }


                } // foreach
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Insert_DocInvoice_Atom_Price_Items_Stock(ID xAtom_WorkPeriod_ID,
                                                             string xDocTyp,
                                                             ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd,
                                                             bool b_from_stock
                                                             )
        {
            return Get_DocInvoice_ShopC_Item(xAtom_WorkPeriod_ID,xDocTyp, ref appisd, b_from_stock);
        }

        private bool Get_DocInvoice_ShopC_Item(ID xAtom_WorkPeriod_ID,string xDocTyp,ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, bool b_from_stock)
        {
            ID Atom_Price_Item_ID = null;
            if (Get_Atom_Price_Item(ref appisd))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                int decimal_places = GlobalData.Get_BaseCurrency_DecimalPlaces();
                Atom_Price_Item_ID = appisd.Atom_Price_Item_ID;



                string spar_ExtraDiscount = "@par_ExtraDiscount";
                SQL_Parameter par_ExtraDiscount = new SQL_Parameter(spar_ExtraDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, appisd.ExtraDiscount.v);

                decimal dQuantity_from_factory = appisd.m_ShopShelf_Source.dQuantity_from_factory;
                decimal dQuantity_from_stock = appisd.m_ShopShelf_Source.dQuantity_from_stock;

                string spar_RetailPriceWithDiscount = "@par_RetailPriceWithDiscount";
                string spar_TaxPrice = "@par_TaxPrice";
                string spar_dQuantity = "@par_dQuantity";

                foreach (Stock_Data stock_data in appisd.m_ShopShelf_Source.Stock_Data_List)
                {
                    if (b_from_stock)
                    {
                        if (stock_data.Stock_ID == null)
                        {
                            continue;
                        }

                        if (stock_data.dQuantity_from_stock != null)
                        {
                            if (stock_data.dQuantity_from_stock.v == 0)
                            {
                                continue;
                            }
                        }
                    }

                    decimal RetailPriceWithDiscount = 0;

                    decimal TaxPrice = 0;

                    decimal RetailPriceWithDiscount_WithoutTax = 0;

                    lpar.Clear();
                    lpar.Add(par_ExtraDiscount);
                    ID Stock_ID = stock_data.Stock_ID;



                    string scond_Stock_ID = null;
                    string sValue_Stock_ID = null;
                    if (Stock_ID != null)
                    {
                        decimal dquantity = stock_data.dQuantity.v;
                        StaticLib.Func.CalculatePrice(appisd.RetailPricePerUnit.v, dquantity, appisd.Discount.v, appisd.ExtraDiscount.v, appisd.Atom_Taxation_Rate.v, ref RetailPriceWithDiscount, ref TaxPrice, ref RetailPriceWithDiscount_WithoutTax, decimal_places);
                        SQL_Parameter par_dQuantity = null;
                        par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity);
                        lpar.Add(par_dQuantity);
                        scond_Stock_ID = "(Stock_ID = " + Stock_ID.ToString() + ")";
                        sValue_Stock_ID = Stock_ID.ToString();
                        SQL_Parameter par_RetailPriceWithDiscount = new SQL_Parameter(spar_RetailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailPriceWithDiscount);
                        lpar.Add(par_RetailPriceWithDiscount);
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                    }
                    else
                    {
                        StaticLib.Func.CalculatePrice(appisd.RetailPricePerUnit.v, dQuantity_from_factory, appisd.Discount.v, appisd.ExtraDiscount.v, appisd.Atom_Taxation_Rate.v, ref RetailPriceWithDiscount, ref TaxPrice, ref RetailPriceWithDiscount_WithoutTax, decimal_places);
                        SQL_Parameter par_dQuantity = null;
                        par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity_from_factory);
                        lpar.Add(par_dQuantity);
                        SQL_Parameter par_RetailPriceWithDiscount = new SQL_Parameter(spar_RetailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailPriceWithDiscount);
                        lpar.Add(par_RetailPriceWithDiscount);
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        scond_Stock_ID = "(Stock_ID is null)";
                        sValue_Stock_ID = "null";
                    }

                    string spar_ExpiryDate = "@par_ExpiryDate";

                    string scond_ExpiryDate = null;

                    string sValue_ExpiryDate = null;
                    if (stock_data.Stock_ExpiryDate != null)
                    {
                        SQL_Parameter par_ExpiryDate = new SQL_Parameter(spar_ExpiryDate, SQL_Parameter.eSQL_Parameter.Datetime, false, stock_data.Stock_ExpiryDate.v);
                        lpar.Add(par_ExpiryDate);
                        scond_ExpiryDate = "(ExpiryDate = " + spar_ExpiryDate + ")";
                        sValue_ExpiryDate = spar_ExpiryDate;
                    }
                    else
                    {
                        scond_ExpiryDate = "(ExpiryDate is null)";
                        sValue_ExpiryDate = "null";
                    }

                    if (xDocTyp==null)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:CurrentInvoice.cs:Get_DocInvoice_ShopC_Item:xDocTyp==null.");
                        return false;
                    }

                    string sql_select_DocInvoice_ShopC_Item_ID = @"select ID as "+xDocTyp+@"_ShopC_Item_ID, 
                                                                    dQuantity,
                                                                    ExtraDiscount,
                                                                    RetailPriceWithDiscount,
                                                                    TaxPrice
                                                                    from "+xDocTyp+@"_ShopC_Item
                                                                    where "+xDocTyp+@"_ID = " + Doc_ID.ToString() + @" and
                                                                            Atom_Price_Item_ID = " + Atom_Price_Item_ID.ToString() + @" and "
                                                                                    + scond_ExpiryDate + @" and "
                                                                                    + scond_Stock_ID;
                    DataTable dt = new DataTable();
                    string Err = null;
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_DocInvoice_ShopC_Item_ID, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (appisd.DocInvoice_ShopC_Item_ID==null)
                            {
                                appisd.DocInvoice_ShopC_Item_ID = new ID();
                            }
                            appisd.DocInvoice_ShopC_Item_ID.Set(dt.Rows[0][xDocTyp+"_ShopC_Item_ID"]);
                            // appisd.dQuantity_all.v = appisd.m_Warehouse.dQuantity_all;
                            appisd.RetailPriceWithDiscount = tf.set_decimal(dt.Rows[0]["RetailPriceWithDiscount"]);
                            appisd.ExtraDiscount = tf.set_decimal(dt.Rows[0]["ExtraDiscount"]);
                            appisd.TaxPrice = tf.set_decimal(dt.Rows[0]["TaxPrice"]);
                            //$$TODO  pias.Stock_ID = long_v.Copy(pis.Stock_ID);
                            continue;
                        }
                        else
                        {



                            string sql_insert_DocInvoice_ShopC_Item_ID = @"insert into "+xDocTyp+@"_ShopC_Item 
                                                                            (
                                                                            dQuantity,
                                                                            ExtraDiscount,
                                                                            RetailPriceWithDiscount,
                                                                            TaxPrice,
                                                                            "+xDocTyp+@"_ID,
                                                                            Atom_Price_Item_ID,
                                                                            ExpiryDate,
                                                                            Stock_ID
                                                                            )
                                                                            values
                                                                            (
                                                                            " + spar_dQuantity + @",
                                                                            " + spar_ExtraDiscount + @",
                                                                            " + spar_RetailPriceWithDiscount + @",
                                                                            " + spar_TaxPrice + @",
                                                                            " + Doc_ID.ToString() + @",
                                                                            " + Atom_Price_Item_ID.ToString() + @",
                                                                            " + sValue_ExpiryDate + @", 
                                                                            " + sValue_Stock_ID
                                                                                    + ")";
                            ID DocInvoice_ShopC_Item_ID = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert_DocInvoice_ShopC_Item_ID, lpar, ref DocInvoice_ShopC_Item_ID,  ref Err, xDocTyp))
                            {
                                appisd.DocInvoice_ShopC_Item_ID = new ID(DocInvoice_ShopC_Item_ID);

                                if (Stock_ID != null)
                                {
                                    stock_data.Remove_from_StockShelf(xAtom_WorkPeriod_ID);
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Get_DocInvoice_ShopC_Item:sql="+ sql_insert_DocInvoice_ShopC_Item_ID + " failed!\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_DocInvoice_ShopC_Item:sql="+ sql_select_DocInvoice_ShopC_Item_ID+" failed!\r\nErr=" + Err);
                        return false;
                    }


                } // foreach
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool SaveDocProformaInvoice(string xDocTyp,ref ID xDocInvoice_ID, DocProformaInvoice_AddOn xDocProformaInvoice_AddOn,string ElectronicDevice_Name, ref int xNumberInFinancialYear)
        {
            string sql = null;
            object ores = null;
            string Err = null;
            if (GetNewNumberInFinancialYear(xDocTyp, ElectronicDevice_Name))
            {
                xNumberInFinancialYear = NumberInFinancialYear;
                sql = "update DocProformaInvoice set Draft =0,NumberInFinancialYear = " + NumberInFinancialYear.ToString() + "  where ID = " + Doc_ID.ToString(); // Close Proforma Invoice
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    xDocInvoice_ID = Doc_ID;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:CurrentInvoice:SaveDocProformaInvoice:Err=" + Err);
                }
            }
            return false;
        }


        private bool Get_Atom_Price_Item(ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            ID Atom_Taxation_ID = null;
            if (Get_Atom_Taxation_ID(appisd.Atom_Taxation_Name, appisd.Atom_Taxation_Rate, ref Atom_Taxation_ID))
            {
                if (ID.Validate(Atom_Taxation_ID))
                {
                    string scond_Atom_Taxation_ID = " Atom_Taxation_ID = " + Atom_Taxation_ID.ToString();
                    if (Get_Atom_Item(ref appisd))
                    {
                        string scond_Atom_Item_ID = " Atom_Item_ID = " + appisd.Atom_Item_ID.ToString();
                        ID Atom_PriceList_ID = null;
                        if (f_Atom_PriceList.Get(ref appisd, ref Atom_PriceList_ID))
                        {
                            if (ID.Validate(Atom_PriceList_ID))
                            {
                                ID Atom_Item_Image_ID = null;
                                Get_Atom_Item_Image(appisd.Atom_Item_ID, appisd.Atom_Item_Image_Hash, appisd.Atom_Item_Image_Data, ref Atom_Item_Image_ID);


                                string scond_Atom_PriceList_ID = " Atom_PriceList_ID = " + Atom_PriceList_ID.ToString();

                                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();


                                string spar_RetailPricePerUnit = "@par_RetailPricePerUnit";
                                DBConnectionControl40.SQL_Parameter par_RetailPricePerUnit = new DBConnectionControl40.SQL_Parameter(spar_RetailPricePerUnit, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, appisd.RetailPricePerUnit.v);
                                lpar.Add(par_RetailPricePerUnit);

                                string spar_Discount = "@par_Discount";
                                DBConnectionControl40.SQL_Parameter par_Discount = new DBConnectionControl40.SQL_Parameter(spar_Discount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, appisd.Discount.v);
                                lpar.Add(par_Discount);


                                string sql = @"select ID as Atom_Price_Item_ID 
                                                      from Atom_Price_Item 
                                                            where
                                                           RetailPricePerUnit = " + spar_RetailPricePerUnit + @" and
                                                           Discount = " + spar_Discount + @" and
                                                           " + scond_Atom_Taxation_ID + @" and
                                                           " + scond_Atom_Item_ID + @" and
                                                           " + scond_Atom_PriceList_ID;



                                DataTable dt = new DataTable();
                                string Err = null;
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (appisd.Atom_Price_Item_ID==null)
                                        {
                                            appisd.Atom_Price_Item_ID = new ID();
                                        }
                                        appisd.Atom_Price_Item_ID.Set(dt.Rows[0]["Atom_Price_Item_ID"]);
                                        return true;
                                    }
                                    else
                                    {

                                        sql = @"insert into Atom_Price_Item 
                                                                (RetailPricePerUnit,
                                                                 Discount,
                                                                 Atom_Taxation_ID,
                                                                 Atom_Item_ID, 
                                                                 Atom_PriceList_ID
                                                                )   values("
                                                                              + spar_RetailPricePerUnit + ",\r\n"
                                                                              + spar_Discount + ",\r\n"
                                                                              + Atom_Taxation_ID.ToString() + ",\r\n"
                                                                              + appisd.Atom_Item_ID.ToString() + ",\r\n"
                                                                              + Atom_PriceList_ID.ToString()
                                                                              + ")";



                                        ID Atom_Price_Item_ID = null;
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Price_Item_ID, ref Err, "Atom_Price_Item"))
                                        {
                                            if (appisd.Atom_Price_Item_ID==null)
                                            {
                                                appisd.Atom_Price_Item_ID = new ID();
                                            }
                                            appisd.Atom_Price_Item_ID.Set(Atom_Price_Item_ID);
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }


                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:No Atom_PriceList_ID is not defined !");
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
                    LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:No Atom_Item_Taxation_ID is not defined !");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Get_Atom_Item(ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            string Err = null;
            ID Atom_Item_Name_ID = null;

            string scond_Atom_Item_Name_ID = "(Atom_Item_Name_ID is null)";
            string sv_Atom_Item_Name_ID = " null" ;

            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();

            if (appisd.Atom_Item_Name_Name != null)
            {
                if (f_Atom_Item_Name.Get(appisd.Atom_Item_Name_Name, ref Atom_Item_Name_ID))
                {
                    if (ID.Validate(Atom_Item_Name_ID))
                    {
                        string spar_Atom_Item_Name_ID = "@par_Atom_Item_Name_ID";
                        DBConnectionControl40.SQL_Parameter par_Atom_Item_Name_ID = new DBConnectionControl40.SQL_Parameter(spar_Atom_Item_Name_ID, false, Atom_Item_Name_ID);
                        lpar.Add(par_Atom_Item_Name_ID);
                        scond_Atom_Item_Name_ID = "(Atom_Item_Name_ID = @par_Atom_Item_Name_ID)";
                        sv_Atom_Item_Name_ID = " @par_Atom_Item_Name_ID ";
                    }
                }
            }


            string sAtom_Unit_ID = null;
            ID Atom_Unit_ID = null;

            if (Get_Atom_Unit_ID(appisd, ref Atom_Unit_ID))
            {

                if (ID.Validate(Atom_Unit_ID))
                {
                    string scond_UniqueName = null;
                    string sv_UniqueName = null;

                    string spar_UniqueName = "@par_UniqueName";
                    DBConnectionControl40.SQL_Parameter par_UniqueName = new DBConnectionControl40.SQL_Parameter(spar_UniqueName, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Item_UniqueName.v);
                    lpar.Add(par_UniqueName);
                    scond_UniqueName = "(UniqueName = @par_UniqueName)";
                    sv_UniqueName = spar_UniqueName;

                    sAtom_Unit_ID = Atom_Unit_ID.ToString();
                    ID Atom_Item_barcode_ID = null;
                    string scond_Atom_Item_barcode_ID = null;
                    string sv_Atom_Item_barcode_ID = null;
                    if (Get_Atom_Item_barcode(appisd.Atom_Item_barcode_barcode, ref Atom_Item_barcode_ID, ref Err))
                    {
                        if (ID.Validate(Atom_Item_barcode_ID))
                        {
                            scond_Atom_Item_barcode_ID = "(Atom_Item_barcode_ID = " + Atom_Item_barcode_ID.ToString() + ")";
                            sv_Atom_Item_barcode_ID = Atom_Item_barcode_ID.ToString();
                        }
                        else
                        {
                            scond_Atom_Item_barcode_ID = "(Atom_Item_barcode_ID is null)";
                            sv_Atom_Item_barcode_ID = "null";
                        }
                    }
                    ID Atom_Item_Description_ID = null;
                    string scond_Atom_Item_Description_ID = null;
                    string sv_Atom_Item_Description_ID = null;
                    if (Get_Atom_Item_Description(appisd.Atom_Item_Description_Description, ref Atom_Item_Description_ID, ref Err))
                    {
                        if (ID.Validate(Atom_Item_Description_ID))
                        {
                            scond_Atom_Item_Description_ID = "(Atom_Item_Description_ID = " + Atom_Item_Description_ID.ToString() + ")";
                            sv_Atom_Item_Description_ID = Atom_Item_Description_ID.ToString();
                        }
                        else
                        {
                            scond_Atom_Item_Description_ID = "(Atom_Item_Description_ID is null)";
                            sv_Atom_Item_Description_ID = "null";
                        }
                    }

                    ID Atom_Expiry_ID = null;
                    string scond_Atom_Expiry_ID = null;
                    string sv_Atom_Expiry_ID = null;
                    if (appisd.Atom_Expiry_ExpectedShelfLifeInDays != null)
                    {
                        if (Get_Atom_Expiry(appisd.Atom_Expiry_ExpectedShelfLifeInDays,
                                            appisd.Atom_Expiry_SaleBeforeExpiryDateInDays,
                                            appisd.Atom_Expiry_DiscardBeforeExpiryDateInDays,
                                            appisd.Atom_Expiry_ExpiryDescription,
                                            ref Atom_Expiry_ID, ref Err))
                        {
                            scond_Atom_Expiry_ID = "(Atom_Expiry_ID = " + Atom_Expiry_ID.ToString() + ")";
                            sv_Atom_Expiry_ID = Atom_Expiry_ID.ToString();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        scond_Atom_Expiry_ID = "(Atom_Expiry_ID is null)";
                        sv_Atom_Expiry_ID = "null";
                    }

                    ID Atom_Item_Atom_Warranty_ID = null;
                    string scond_Atom_Warranty_ID = null;
                    string sv_Atom_Warranty_ID = null;
                    if (ID.Validate(appisd.Atom_Warranty_ID))
                    {
                        if (Get_Atom_Warranty(appisd.Atom_Warranty_WarrantyDurationType, appisd.Atom_Warranty_WarrantyDuration, appisd.Atom_Warranty_WarrantyConditions, ref Atom_Item_Atom_Warranty_ID, ref Err))
                        {
                            scond_Atom_Warranty_ID = "(Atom_Warranty_ID = " + Atom_Item_Atom_Warranty_ID.ToString() + ")";
                            sv_Atom_Warranty_ID = Atom_Item_Atom_Warranty_ID.ToString();

                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        scond_Atom_Warranty_ID = "(Atom_Warranty_ID is null)";
                        sv_Atom_Warranty_ID = "null";

                    }


                    string sql = @"select ID as Atom_Item_ID from Atom_Item 
                                                    where
                                                    " + scond_Atom_Item_Name_ID+ @" and
                                                    " + scond_UniqueName + @" and
                                                    " + scond_Atom_Item_barcode_ID + @" and
                                                    " + scond_Atom_Item_Description_ID + @" and
                                                    " + scond_Atom_Warranty_ID + @" and
                                                    " + scond_Atom_Expiry_ID;



                    DataTable dt = new DataTable();

                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (appisd.Atom_Item_ID == null)
                            {
                                appisd.Atom_Item_ID = new ID();
                            }
                            appisd.Atom_Item_ID.Set(dt.Rows[0]["Atom_Item_ID"]);
                            return true;
                        }
                        else
                        {
                            sql = @"insert into Atom_Item 
                                    (
                                        UniqueName,
                                        Atom_Item_Name_ID,
                                        Atom_Unit_ID,
                                        Atom_Item_barcode_ID,
                                        Atom_Item_Description_ID,
                                        Atom_Warranty_ID,
                                        Atom_Expiry_ID
                                    )   values("
                                    + sv_UniqueName + ",\r\n"
                                    + sv_Atom_Item_Name_ID + ",\r\n"
                                    + sAtom_Unit_ID + ",\r\n"
                                    + sv_Atom_Item_barcode_ID + ",\r\n"
                                    + sv_Atom_Item_Description_ID + ",\r\n"
                                    + sv_Atom_Warranty_ID + ",\r\n"
                                    + sv_Atom_Expiry_ID
                                    + ")";



                            ID Atom_Item_ID = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Item_ID, ref Err, DBtcn.stbl_Atom_Item_TableName))
                            {
                                if (appisd.Atom_Item_ID == null)
                                {
                                    appisd.Atom_Item_ID = new ID();
                                }
                                appisd.Atom_Item_ID.Set(Atom_Item_ID);
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Get_Atom_Item:insert into Atom_Item failed!\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {

                        LogFile.Error.Show("ERROR:Get_Atom_Item:select ID as Atom_Item_ID from Atom_Item failed!\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item:Atom_Unit_ID not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ShowDraftButtons()
        {
            if (bDraft)
            {
                //Check if Draft not To Old !
                DateTime dtNow = DateTime.Now;
                TimeSpan ts = dtNow - this.EventTime;
                if (ts.Days > 300)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Get_Atom_Warranty(short_v Warranty_WarrantyDurationType, int_v Warranty_WarrantyDuration, string_v Warranty_WarrantyConditions, ref ID Atom_Item_Atom_Warranty_ID, ref string Err)
        {
            string scond_WarrantyDurationType = null;
            string sv_WarrantyDurationType = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (Warranty_WarrantyDurationType != null)
            {
                string spar_WarrantyDurationType = "@par_WarrantyDurationType";
                DBConnectionControl40.SQL_Parameter par_WarrantyDurationType = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDurationType, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Smallint, false, Warranty_WarrantyDurationType.v);
                lpar.Add(par_WarrantyDurationType);
                scond_WarrantyDurationType = "(WarrantyDurationType = " + spar_WarrantyDurationType + ")";
                sv_WarrantyDurationType = spar_WarrantyDurationType;
            }
            else
            {
                scond_WarrantyDurationType = "(WarrantyDurationType is null)";
                sv_WarrantyDurationType = "null";
            }

            string scond_WarrantyDuration = null;
            string sv_WarrantyDuration = null;
            if (Warranty_WarrantyDuration != null)
            {
                string spar_WarrantyDuration = "@par_WarrantyDuration";
                DBConnectionControl40.SQL_Parameter par_WarrantyDuration = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDuration, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Warranty_WarrantyDuration.v);
                lpar.Add(par_WarrantyDuration);
                scond_WarrantyDuration = "(WarrantyDuration = " + spar_WarrantyDuration + ")";
                sv_WarrantyDuration = spar_WarrantyDuration;
            }
            else
            {
                scond_WarrantyDuration = "(WarrantyDuration is null)";
                sv_WarrantyDuration = "null";
            }

            string scond_WarrantyConditions = null;
            string sv_WarrantyConditions = null;
            if (Warranty_WarrantyConditions != null)
            {
                string spar_WarrantyConditions = "@par_WarrantyConditions";
                DBConnectionControl40.SQL_Parameter par_WarrantyConditions = new DBConnectionControl40.SQL_Parameter(spar_WarrantyConditions, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Warranty_WarrantyConditions.v);
                lpar.Add(par_WarrantyConditions);
                scond_WarrantyConditions = "(WarrantyConditions = " + spar_WarrantyConditions + ")";
                sv_WarrantyConditions = spar_WarrantyConditions;
            }
            else
            {
                scond_WarrantyConditions = "(WarrantyConditions is null)";
                sv_WarrantyConditions = "null";
            }


            string sql_select_Atom_Warranty_ID = @"select ID as Atom_Warranty_ID from Atom_Warranty where " + scond_WarrantyDurationType + " and " + scond_WarrantyDuration + " and " + scond_WarrantyConditions;

            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Warranty_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Item_Atom_Warranty_ID==null)
                    {
                        Atom_Item_Atom_Warranty_ID = new ID();
                    }
                    Atom_Item_Atom_Warranty_ID.Set(dt.Rows[0]["Atom_Warranty_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Warranty = @"insert into Atom_Warranty (WarrantyDurationType, WarrantyDuration, WarrantyConditions)values(" + sv_WarrantyDurationType + "," + sv_WarrantyDuration + "," + sv_WarrantyConditions + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Warranty, lpar, ref Atom_Item_Atom_Warranty_ID, ref Err, DBtcn.stbl_Atom_Warranty_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_Atom_Warranty:insert into Atom_Warranty failed!\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Get_Atom_Warranty:select ID as Atom_Warranty_ID from Atom_Warranty failed!\r\nErr=" + Err);
                return false;
            }
        }

        private bool Get_Atom_Unit_ID(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, ref ID Atom_Unit_ID)
        {
            string Err = null;
            string scond_Unit_Name = null;
            string sv_Unit_Name = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (appisd.Atom_Unit_Name != null)
            {
                string spar_Unit_Name = "@par_Unit_Name";
                DBConnectionControl40.SQL_Parameter par_Unit_Name = new DBConnectionControl40.SQL_Parameter(spar_Unit_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Unit_Name.v);
                lpar.Add(par_Unit_Name);
                scond_Unit_Name = "(Name = " + spar_Unit_Name + ")";
                sv_Unit_Name = spar_Unit_Name;
            }
            else
            {
                scond_Unit_Name = "(Name is null)";
                sv_Unit_Name = "null";
            }

            string scond_Unit_Symbol = null;
            string sv_Unit_Symbol = null;
            if (appisd.Atom_Unit_Symbol != null)
            {
                string spar_Unit_Symbol = "@par_Unit_Symbol";
                DBConnectionControl40.SQL_Parameter par_Unit_Symbol = new DBConnectionControl40.SQL_Parameter(spar_Unit_Symbol, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Unit_Symbol.v);
                lpar.Add(par_Unit_Symbol);
                scond_Unit_Symbol = "(Symbol = " + spar_Unit_Symbol + ")";
                sv_Unit_Symbol = spar_Unit_Symbol;
            }
            else
            {
                scond_Unit_Symbol = "(Symbol is null)";
                sv_Unit_Symbol = "null";
            }

            string scond_Unit_DecimalPlaces = null;
            string sv_Unit_DecimalPlaces = null;
            if (appisd.Atom_Unit_DecimalPlaces != null)
            {
                string spar_Unit_DecimalPlaces = "@par_Unit_DecimalPlaces";
                DBConnectionControl40.SQL_Parameter par_DiscardBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_Unit_DecimalPlaces, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Smallint, false, appisd.Atom_Unit_DecimalPlaces.v);
                lpar.Add(par_DiscardBeforeExpiryDateInDays);
                scond_Unit_DecimalPlaces = "(DecimalPlaces = " + spar_Unit_DecimalPlaces + ")";
                sv_Unit_DecimalPlaces = spar_Unit_DecimalPlaces;
            }
            else
            {
                scond_Unit_DecimalPlaces = "(DecimalPlaces is null)";
                sv_Unit_DecimalPlaces = "null";
            }

            string scond_Unit_StorageOption = null;
            string sv_Unit_StorageOption = null;
            if (appisd.Atom_Unit_StorageOption != null)
            {
                string spar_ExpiryDescription = "@par_StorageOption";
                DBConnectionControl40.SQL_Parameter par_ExpiryDescription = new DBConnectionControl40.SQL_Parameter(spar_ExpiryDescription, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Bit, false, appisd.Atom_Unit_StorageOption.v);
                lpar.Add(par_ExpiryDescription);
                scond_Unit_StorageOption = "(StorageOption = " + spar_ExpiryDescription + ")";
                sv_Unit_StorageOption = spar_ExpiryDescription;
            }
            else
            {
                scond_Unit_StorageOption = "(StorageOption is null)";
                sv_Unit_StorageOption = "null";
            }

            string scond_Unit_Description = null;
            string sv_Unit_Description = null;
            if (appisd.Atom_Unit_Description != null)
            {
                string spar_Unit_Description = "@par_Unit_Description";
                DBConnectionControl40.SQL_Parameter par_Unit_Description = new DBConnectionControl40.SQL_Parameter(spar_Unit_Description, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, appisd.Atom_Unit_Description.v);
                lpar.Add(par_Unit_Description);
                scond_Unit_Description = "(Description = " + spar_Unit_Description + ")";
                sv_Unit_Description = spar_Unit_Description;
            }
            else
            {
                scond_Unit_Description = "(Description is null)";
                sv_Unit_Description = "null";
            }
            string sql_select_Atom_Unit_ID = @"select ID as Atom_Unit_ID from Atom_Unit where " + scond_Unit_Name + " and "
                                                                                                   + scond_Unit_Symbol + " and "
                                                                                                   + scond_Unit_DecimalPlaces + " and "
                                                                                                   + scond_Unit_StorageOption + " and "
                                                                                                   + scond_Unit_Description;



            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Unit_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Unit_ID==null)
                    {
                        Atom_Unit_ID = new ID();
                    }
                    Atom_Unit_ID.Set(dt.Rows[0]["Atom_Unit_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Unit = @"insert into Atom_Unit (Name,
                                                                                             Symbol,
                                                                                             DecimalPlaces,
                                                                                             StorageOption,
                                                                                             Description
                                                                                            )
                                                                                            values
                                                                                            ("
                                                                                             + sv_Unit_Name + ","
                                                                                             + sv_Unit_Symbol + ","
                                                                                             + sv_Unit_DecimalPlaces + ","
                                                                                             + sv_Unit_StorageOption + ","
                                                                                             + sv_Unit_Description
                                                                                            + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Unit, lpar, ref Atom_Unit_ID,  ref Err, "Atom_Unit"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_Atom_Unit_ID:insert into Atom_Unit failed!\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Get_Atom_Unit_ID:select ID as Atom_Unit_ID from Atom_Unit failed!\r\nErr=" + Err);
                return false;
            }
        }

        public bool Update_Customer_Remove(string xDocTyp)
        {
            string sql = "update "+ xDocTyp + " set Atom_Customer_Org_ID = null,Atom_Customer_Person_ID = null where ID = " + this.Doc_ID.ToString();
            string Err = null;
            object ores = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
            {
                this.Atom_Customer_Org_ID = null;
                this.Atom_Customer_Person_ID = null;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:Update_Customer_Remove:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool Get_Atom_Item_Image(ID Atom_Item_ID, string_v Atom_Item_Image_Hash, byte_array_v Atom_Item_Image_Data, ref ID Atom_Item_Image_ID)
        {
            string Err = null;
            if (Atom_Item_Image_Hash != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Item_Image_Hash = "@par_Item_Image_Image_Hash";
                DBConnectionControl40.SQL_Parameter par_Item_Image_Hash = new DBConnectionControl40.SQL_Parameter(spar_Item_Image_Hash, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Atom_Item_Image_Hash.v);
                lpar.Add(par_Item_Image_Hash);
                string sql_select_Atom_Item_Item_Image_Hash_ID = @"select Atom_Item_Image.ID as Atom_Item_Image_ID from Atom_Item_Image inner join Atom_Item_ImageLib on Atom_Item_ImageLib.ID = Atom_Item_Image.Atom_Item_ImageLib_ID where (Atom_Item_ImageLib.Image_Hash = " + spar_Item_Image_Hash + ") and (Atom_Item_Image.Atom_Item_ID = " + Atom_Item_ID.ToString() + ")";
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_Item_Image_Hash_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Item_Image_ID==null)
                        {
                            Atom_Item_Image_ID = new ID();
                        }
                        Atom_Item_Image_ID.Set(dt.Rows[0]["Atom_Item_Image_ID"]);
                        return true;
                    }
                    else
                    {
                        ID Atom_Item_ImageLib_ID = null;
                        string sql_select_Atom_Item_ImageLib_ID = @"select ID as Atom_Item_ImageLib_ID from Atom_Item_ImageLib where Atom_Item_ImageLib.Image_Hash = " + spar_Item_Image_Hash;
                        DataTable dt2 = new DataTable();
                        if (DBSync.DBSync.ReadDataTable(ref dt2, sql_select_Atom_Item_ImageLib_ID, lpar, ref Err))
                        {
                            if (dt2.Rows.Count > 0)
                            {
                                if (Atom_Item_ImageLib_ID==null)
                                {
                                    Atom_Item_ImageLib_ID = new ID();
                                }
                                Atom_Item_ImageLib_ID.Set(dt2.Rows[0]["Atom_Item_ImageLib_ID"]);
                            }
                            else
                            {
                                string spar_Item_Image_Data = "@par_Item_Image_Image_Data";
                                DBConnectionControl40.SQL_Parameter par_Item_Image_Data = new DBConnectionControl40.SQL_Parameter(spar_Item_Image_Data, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varbinary, false, Atom_Item_Image_Data.v);
                                lpar.Add(par_Item_Image_Data);
                                string sql_Insert_Atom_Item_Item_Image_Hash = @"insert into Atom_Item_ImageLib (Image_Hash,Image_Data)values(" + spar_Item_Image_Hash + "," + spar_Item_Image_Data + ")";
                                if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Item_Image_Hash, lpar, ref Atom_Item_ImageLib_ID,  ref Err, DBtcn.stbl_Atom_Item_ImageLib_TableName))
                                {
                                    LogFile.Error.Show("ERROR:Get_Atom_Item_Image:insert into Atom_Item_ImageLib failed!\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Image:select ID as Atom_Item_ImageLib_ID from Atom_Item_ImageLib failed!\r\nErr=" + Err);
                            return false;
                        }
                        string sql_Insert_Atom_Item_Image = @"insert into Atom_Item_Image (Atom_Item_ID,Atom_Item_ImageLib_ID)values(" + Atom_Item_ID.ToString() + "," + Atom_Item_ImageLib_ID.ToString() + ")";
                        if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Image, null, ref Atom_Item_Image_ID, ref Err, DBtcn.stbl_Atom_Item_Image_TableName))
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Image:insert into Atom_Item_ImageLib failed!\r\nErr=" + Err);
                            return false;
                        }
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item_Image:select ID as Atom_Item_Image_ID from Atom_Item_Image failed!\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        bool Get_Atom_Expiry(int_v Expiry_ExpectedShelfLifeInDays,
                                    int_v Expiry_SaleBeforeExpiryDateInDays,
                                    int_v Expiry_DiscardBeforeExpiryDateInDays,
                                    string_v Expiry_ExpiryDescription,
                                    ref ID Atom_Expiry_ID, ref string Err)
        {
            string scond_ExpectedShelfLifeInDays = null;
            string sv_ExpectedShelfLifeInDays = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (Expiry_ExpectedShelfLifeInDays != null)
            {
                string spar_ExpectedShelfLifeInDays = "@par_ExpectedShelfLifeInDays";
                DBConnectionControl40.SQL_Parameter par_ExpectedShelfLifeInDays = new DBConnectionControl40.SQL_Parameter(spar_ExpectedShelfLifeInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Expiry_ExpectedShelfLifeInDays.v);
                lpar.Add(par_ExpectedShelfLifeInDays);
                scond_ExpectedShelfLifeInDays = "(ExpectedShelfLifeInDays = " + spar_ExpectedShelfLifeInDays + ")";
                sv_ExpectedShelfLifeInDays = spar_ExpectedShelfLifeInDays;
            }
            else
            {
                scond_ExpectedShelfLifeInDays = "(ExpectedShelfLifeInDays is null)";
                sv_ExpectedShelfLifeInDays = "null";
            }
            string scond_Expiry_SaleBeforeExpiryDateInDays = null;
            string sv_Expiry_SaleBeforeExpiryDateInDays = null;
            if (Expiry_SaleBeforeExpiryDateInDays != null)
            {
                string spar_SaleBeforeExpiryDateInDays = "@par_SaleBeforeExpiryDateInDays";
                DBConnectionControl40.SQL_Parameter par_SaleBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_SaleBeforeExpiryDateInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Expiry_SaleBeforeExpiryDateInDays.v);
                lpar.Add(par_SaleBeforeExpiryDateInDays);
                scond_Expiry_SaleBeforeExpiryDateInDays = "(SaleBeforeExpiryDateInDays = " + spar_SaleBeforeExpiryDateInDays + ")";
                sv_Expiry_SaleBeforeExpiryDateInDays = spar_SaleBeforeExpiryDateInDays;
            }
            else
            {
                scond_Expiry_SaleBeforeExpiryDateInDays = "(SaleBeforeExpiryDateInDays is null)";
                sv_Expiry_SaleBeforeExpiryDateInDays = "null";
            }

            string scond_Expiry_DiscardBeforeExpiryDateInDays = null;
            string sv_Expiry_DiscardBeforeExpiryDateInDays = null;
            if (Expiry_DiscardBeforeExpiryDateInDays != null)
            {
                string spar_DiscardBeforeExpiryDateInDays = "@par_DiscardBeforeExpiryDateInDays";
                DBConnectionControl40.SQL_Parameter par_DiscardBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_DiscardBeforeExpiryDateInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Expiry_DiscardBeforeExpiryDateInDays.v);
                lpar.Add(par_DiscardBeforeExpiryDateInDays);
                scond_Expiry_DiscardBeforeExpiryDateInDays = "(DiscardBeforeExpiryDateInDays = " + spar_DiscardBeforeExpiryDateInDays + ")";
                sv_Expiry_DiscardBeforeExpiryDateInDays = spar_DiscardBeforeExpiryDateInDays;
            }
            else
            {
                scond_Expiry_DiscardBeforeExpiryDateInDays = "(DiscardBeforeExpiryDateInDays is null)";
                sv_Expiry_DiscardBeforeExpiryDateInDays = "null";
            }

            string scond_Expiry_ExpiryDescription = null;
            string sv_Expiry_ExpiryDescription = null;
            if (Expiry_ExpiryDescription != null)
            {
                string spar_ExpiryDescription = "@par_ExpiryDescription";
                DBConnectionControl40.SQL_Parameter par_ExpiryDescription = new DBConnectionControl40.SQL_Parameter(spar_ExpiryDescription, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Expiry_ExpiryDescription.v);
                lpar.Add(par_ExpiryDescription);
                scond_Expiry_ExpiryDescription = "(ExpiryDescription = " + spar_ExpiryDescription + ")";
                sv_Expiry_ExpiryDescription = spar_ExpiryDescription;
            }
            else
            {
                scond_Expiry_ExpiryDescription = "(ExpiryDescription is null)";
                sv_Expiry_ExpiryDescription = "null";
            }

            string sql_select_Atom_Expiry_ID = @"select ID as Atom_Expiry_ID from Atom_Expiry where " + scond_ExpectedShelfLifeInDays + " and "
                                                                                                   + scond_Expiry_SaleBeforeExpiryDateInDays + " and "
                                                                                                   + scond_Expiry_DiscardBeforeExpiryDateInDays + " and "
                                                                                                   + scond_Expiry_ExpiryDescription;



            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Expiry_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Expiry_ID==null)
                    {
                        Atom_Expiry_ID = new ID();
                    }
                    Atom_Expiry_ID.Set(dt.Rows[0]["Atom_Expiry_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Item_ExpiryDescription = @"insert into Atom_Expiry (ExpectedShelfLifeInDays,
                                                                                             SaleBeforeExpiryDateInDays,
                                                                                             DiscardBeforeExpiryDateInDays,
                                                                                             ExpiryDescription)values("
                                                                                             + sv_ExpectedShelfLifeInDays + ","
                                                                                             + sv_Expiry_SaleBeforeExpiryDateInDays + ","
                                                                                             + sv_Expiry_DiscardBeforeExpiryDateInDays + ","
                                                                                             + sv_Expiry_ExpiryDescription
                                                                                            + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_ExpiryDescription, lpar, ref Atom_Expiry_ID, ref Err, DBtcn.stbl_Atom_Item_ExpiryDescription_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_Atom_Expiry:insert into Atom_Expiry failed!\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Get_Atom_Expiry:select ID as Atom_Expiry_ID from Atom_Expiry failed!\r\nErr=" + Err);
                return false;
            }
        }


        bool Get_Atom_Warranty(short_v Warranty_WarrantyDurationType,
                              int_v Warranty_WarrantyDuration,
                              string_v Warranty_WarrantyConditions,
                              ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data pias,
                              ref ID Atom_Warranty_ID, ref string Err)
        {
            string scond_WarrantyDurationType = null;
            string sv_WarrantyDurationType = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (Warranty_WarrantyDurationType != null)
            {
                string spar_WarrantyDurationType = "@par_WarrantyDurationType";
                DBConnectionControl40.SQL_Parameter par_WarrantyDurationType = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDurationType, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Smallint, false, Warranty_WarrantyDurationType.v);
                lpar.Add(par_WarrantyDurationType);
                scond_WarrantyDurationType = "(WarrantyDurationType = " + spar_WarrantyDurationType + ")";
                sv_WarrantyDurationType = spar_WarrantyDurationType;
            }
            else
            {
                scond_WarrantyDurationType = "(WarrantyDurationType is null)";
                sv_WarrantyDurationType = "null";
            }

            string scond_WarrantyDuration = null;
            string sv_WarrantyDuration = null;
            if (Warranty_WarrantyDuration != null)
            {
                string spar_WarrantyDuration = "@par_WarrantyDuration";
                DBConnectionControl40.SQL_Parameter par_WarrantyDuration = new DBConnectionControl40.SQL_Parameter(spar_WarrantyDuration, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, Warranty_WarrantyDuration.v);
                lpar.Add(par_WarrantyDuration);
                scond_WarrantyDuration = "(WarrantyDuration = " + spar_WarrantyDuration + ")";
                sv_WarrantyDuration = spar_WarrantyDuration;
            }
            else
            {
                scond_WarrantyDuration = "(WarrantyDuration is null)";
                sv_WarrantyDuration = "null";
            }

            string scond_WarrantyConditions = null;
            string sv_WarrantyConditions = null;
            if (Warranty_WarrantyConditions != null)
            {
                string spar_WarrantyConditions = "@par_WarrantyConditions";
                DBConnectionControl40.SQL_Parameter par_WarrantyConditions = new DBConnectionControl40.SQL_Parameter(spar_WarrantyConditions, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Warranty_WarrantyConditions.v);
                lpar.Add(par_WarrantyConditions);
                scond_WarrantyConditions = "(WarrantyConditions = " + spar_WarrantyConditions + ")";
                sv_WarrantyConditions = spar_WarrantyConditions;
            }
            else
            {
                scond_WarrantyConditions = "(WarrantyConditions is null)";
                sv_WarrantyConditions = "null";
            }


            string sql_select_Atom_Warranty_ID = @"select ID as Atom_Warranty_ID from Atom_Warranty where " + scond_WarrantyDurationType + " and " + scond_WarrantyDuration + " and " + scond_WarrantyConditions;

            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Warranty_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Warranty_ID==null)
                    {
                        Atom_Warranty_ID = new ID();
                    }
                    Atom_Warranty_ID.Set(dt.Rows[0]["Atom_Warranty_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Warranty = @"insert into Atom_Warranty (WarrantyDurationType, WarrantyDuration, WarrantyConditions)values(" + sv_WarrantyDurationType + "," + sv_WarrantyDuration + "," + sv_WarrantyConditions + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Warranty, lpar, ref Atom_Warranty_ID, ref Err, DBtcn.stbl_Atom_Warranty_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_Atom_Warranty:insert into Atom_Warranty failed!\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Get_Atom_Warranty:select ID as Atom_Warranty_ID from Atom_Warranty failed!\r\nErr=" + Err);
                return false;
            }

        }

        private bool Get_Atom_Item_Description(string_v Item_Description, ref ID Atom_Item_Description_ID, ref string Err)
        {
            if (Item_Description != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Description = "@par_Description";
                DBConnectionControl40.SQL_Parameter par_Description = new DBConnectionControl40.SQL_Parameter(spar_Description, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Item_Description.v);
                lpar.Add(par_Description);
                string sql_select_Atom_Item_Description_ID = @"select ID as Atom_Item_Description_ID from Atom_Item_Description where Description = " + spar_Description;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_Description_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Item_Description_ID==null)
                        {
                            Atom_Item_Description_ID = new ID();
                        }
                        Atom_Item_Description_ID.Set(dt.Rows[0]["Atom_Item_Description_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_Description = @"insert into Atom_Item_Description (Description)values(" + spar_Description + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Description, lpar, ref Atom_Item_Description_ID, ref Err, DBtcn.stbl_Atom_Item_Description_TableName))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Description:insert into Atom_Item_Description failed!\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item_Description:select ID as Atom_Item_Description_ID from Atom_Item_Description failed!\r\nErr=" + Err);
                    return false;
                }

            }
            else
            {
                Atom_Item_Description_ID = null;
                return true;
            }

        }

        private bool Get_Atom_Taxation_ID(string_v Taxation_Name, decimal_v Taxation_Rate, ref ID Atom_Taxation_ID)
        {
            string Err = null;
            if ((Taxation_Name != null) && (Taxation_Rate != null))
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Taxation_Name = "@par_Taxation_Name";
                DBConnectionControl40.SQL_Parameter par_Taxation_Name = new DBConnectionControl40.SQL_Parameter(spar_Taxation_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Taxation_Name.v);
                lpar.Add(par_Taxation_Name);
                string spar_Taxation_Rate = "@par_Taxation_Rate";
                DBConnectionControl40.SQL_Parameter par_Taxation_Rate = new DBConnectionControl40.SQL_Parameter(spar_Taxation_Rate, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Taxation_Rate.v);
                lpar.Add(par_Taxation_Rate);
                string sql_select_Atom_Item_barcode_ID = @"select ID as Atom_Taxation_ID from Atom_Taxation where Name = " + spar_Taxation_Name + " and Rate = " + spar_Taxation_Rate;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_barcode_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Taxation_ID==null)
                        {
                            Atom_Taxation_ID = new ID();
                        }
                        Atom_Taxation_ID.Set(dt.Rows[0]["Atom_Taxation_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_Taxation = @"insert into Atom_Taxation (Name,Rate)values(" + spar_Taxation_Name + "," + spar_Taxation_Rate + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Taxation, lpar, ref Atom_Taxation_ID, ref Err, DBtcn.stbl_Atom_Taxation_TableName))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Taxation:insert into Atom_Taxation failed!\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item_Taxation:select ID as Atom_Taxation_ID from Atom_Taxation failed!\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                Err = "ERROR:Get_Atom_Item_Taxation:Taxation_Name can not be null!";
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private bool Get_Atom_Item_barcode(string_v Item_barcode, ref ID Atom_Item_barcode_ID, ref string Err)
        {
            if (Item_barcode != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_barcode = "@par_barcode";
                DBConnectionControl40.SQL_Parameter par_barcode = new DBConnectionControl40.SQL_Parameter(spar_barcode, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Item_barcode.v);
                lpar.Add(par_barcode);
                string sql_select_Atom_Item_barcode_ID = @"select ID as Atom_Item_barcode_ID from Atom_Item_barcode where barcode = " + spar_barcode;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_barcode_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Item_barcode_ID==null)
                        {
                            Atom_Item_barcode_ID = new ID();
                        }
                        Atom_Item_barcode_ID.Set(dt.Rows[0]["Atom_Item_barcode_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_barcode = @"insert into Atom_Item_barcode (barcode)values(" + spar_barcode + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_barcode, lpar, ref Atom_Item_barcode_ID, ref Err, DBtcn.stbl_Atom_Item_barcode_TableName))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_barcode:insert into Atom_Item_barcode failed!\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                Atom_Item_barcode_ID = null;
                return true;
            }

        }




        public bool Remove_usrc_Atom_Item_Factory_Items()
        {
            string sIn_ID_list = null;
            if (sIn_ID_list != null)
            {
                sIn_ID_list += ")";
                string sql_Delete_DocInvoice_Atom_Item_Stock = "delete from DocInvoice_ShopC_Item where (DocInvoice_ID = " + Doc_ID.ToString() + ") and DocInvoice_ShopC_Item.Stock_ID is null and Atom_Price_Item_ID in " + sIn_ID_list;
                object objret = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_DocInvoice_Atom_Item_Stock, null, ref objret, ref Err))
                {
                    string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from DocInvoice_ShopC_Item)";
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Price_Item, null, ref objret, ref Err))
                    {
                        string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_Image, null, ref objret, ref Err))
                        {
                            string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_ImageLib, null, ref objret, ref Err))
                            {

                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:delete from Atom_Item_Image:Err=" + Err);
                                return false;
                            }

                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:delete from Atom_Item:Err=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:delete from Atom_Item_Image:Err=" + Err);
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:delete from DocInvoice_ShopC_Item:Err=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:No factory Items. Expected at least one Remove_usrc_Atom_Item_Factory_Items item!");
                return false;
            }
        }

        public bool SaveDocInvoice(string xDocTyp,ref ID xDocInvoice_ID, DocInvoice_AddOn xDocInvoice_AddOn,CashierActivity ca, string ElectronicDevice_Name,ref int xNumberInFinancialYear)
        {
            string sql = null;
            object ores = null;
            string Err = null;
            if (GetNewNumberInFinancialYear(xDocTyp,  ElectronicDevice_Name))
            {
                xNumberInFinancialYear = NumberInFinancialYear;
                sql = "update DocInvoice set Draft =0,NumberInFinancialYear = " + NumberInFinancialYear.ToString() + "  where ID = " + Doc_ID.ToString(); // Close Proforma Invoice
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    xDocInvoice_ID = Doc_ID;
                    if (ca != null)
                    {
                       if (ca.Add(xDocInvoice_ID))
                        {
                            return true;
                        }
                       else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Save:Err=" + Err);
                }
            }
            return false;
        }

        private bool GetNewNumberInFinancialYear(string xDocTyp,string ElectronicDevice_Name,ref int xNumberInFinancialYear)
        {
            //string cond = null;
            int iLimit = 1;
            /* CHECK_and_CORRECT */
            //if (Invoice_ID >= 0)
            //{
            //    cond = "Invoice_ID is not null";
            //}
            //else
            //{
            //    cond = "Invoice_ID is null";
            //}
            //string sql = " select " + DBSync.DBSync.sTop(iLimit) + " NumberInFinancialYear from DocInvoice where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " and " + cond + " order by NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);
            //string sql = " select " + DBSync.DBSync.sTop(iLimit) + " NumberInFinancialYear from "+ DocInvoice + " where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " order by NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ElectronicDevice_Name = "@par_ElectronicDevice_Name";
            SQL_Parameter par_ElectronicDevice_Name = new SQL_Parameter(spar_ElectronicDevice_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ElectronicDevice_Name);
            lpar.Add(par_ElectronicDevice_Name);

            string sql = null;
            if (Currency.CurrencyCode == 978)
            {
                // Euro currency
                sql = @"select " + DBSync.DBSync.sTop(iLimit) + "di.NumberInFinancialYear from " + xDocTyp + " di " +
                "\r\n inner join Atom_Currency acur on di.Atom_Currency_ID = acur.ID " +
                "\r\n inner join JOURNAL_" + xDocTyp + " jdi on jdi." + xDocTyp + "_ID = di.ID " +
                "\r\n inner join JOURNAL_" + xDocTyp + "_TYPE jdit on jdi.JOURNAL_" + xDocTyp + "_TYPE_ID = jdit.ID " +
                "\r\n inner join Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID " +
                "\r\n inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID " +
                "\r\n where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " and aed.Name = " + spar_ElectronicDevice_Name + " and acur.CurrencyCode = 978 order by aed.Name asc, NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);
            }
            else
            {
                sql = @"select " + DBSync.DBSync.sTop(iLimit) + "di.NumberInFinancialYear from " + xDocTyp + " di " +
                "\r\n inner join Atom_Currency acur on di.Atom_Currency_ID = acur.ID " +
                "\r\n inner join JOURNAL_" + xDocTyp + " jdi on jdi." + xDocTyp + "_ID = di.ID " +
                "\r\n inner join JOURNAL_" + xDocTyp + "_TYPE jdit on jdi.JOURNAL_" + xDocTyp + "_TYPE_ID = jdit.ID " +
                "\r\n inner join Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID " +
                "\r\n inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID " +
                "\r\n where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " and aed.Name = " + spar_ElectronicDevice_Name + " and acur.CurrencyCode <> 978 order by aed.Name asc, NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);
            }


            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count == 1)
                {
                    int iLastNumberInFinancialYear = (int)dt.Rows[0]["NumberInFinancialYear"];
                    if (iLastNumberInFinancialYear == 452)
                    {
                        MessageBox.Show("Number changed from 452 to 456");
                        xNumberInFinancialYear = 456;
                    }
                    else
                    {
                        xNumberInFinancialYear = iLastNumberInFinancialYear + 1;
                    }
                }
                else
                {
                    xNumberInFinancialYear = 1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoices:GetNewNumberInFinancialYear:Err=" + Err);
                return false;
            }
        }

        private bool GetNewNumberInFinancialYear(string xDocTyp, string ElectronicDevice_Name)
        {
            return GetNewNumberInFinancialYear(xDocTyp, ElectronicDevice_Name,ref NumberInFinancialYear);
        }

        public bool Update_Customer_Person(string xDocTyp, ID Customer_Person_ID, ref ID xAtom_Customer_Person_ID)
        {
            if (f_Atom_Customer_Person.Get(Customer_Person_ID, ref xAtom_Customer_Person_ID))
            {
                if (ID.Validate(xAtom_Customer_Person_ID))
                {
                    string sql = "update "+xDocTyp+" set Atom_Customer_Person_ID = " + xAtom_Customer_Person_ID.ToString() + ",Atom_Customer_Org_ID = null where ID = " + this.Doc_ID.ToString();
                    string Err = null;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                        if (Atom_Customer_Person_ID == null)
                        {
                            Atom_Customer_Person_ID = new ID();
                        }
                        Atom_Customer_Person_ID = xAtom_Customer_Person_ID;
                        Atom_Customer_Org_ID = null;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:CurrentInvoice:Update_Customer_Person:\r\nsql=" + sql + "\r\nErr=" + Err);
                    }
                }
            }
            return false;
        }

        public bool Update_Customer_Org(string xDocTyp,ID Customer_Org_ID, ref ID xAtom_Customer_Org_ID)
        {
            if (f_Atom_Customer_Org.Get(Customer_Org_ID, ref xAtom_Customer_Org_ID))
            {
                if (ID.Validate(xAtom_Customer_Org_ID))
                {
                    string sql = "update "+xDocTyp+" set Atom_Customer_Org_ID = " + xAtom_Customer_Org_ID.ToString() + ",Atom_Customer_Person_ID = null where ID = " + this.Doc_ID.ToString();
                    string Err = null;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                        if (Atom_Customer_Org_ID == null)
                        {
                            Atom_Customer_Org_ID = new ID();
                        }
                        Atom_Customer_Org_ID.Set(xAtom_Customer_Org_ID);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:CurrentInvoice:Update_Customer_Org:\r\nsql=" + sql + "\r\nErr=" + Err);
                    }
                }
            }
            return false;
        }




        public bool SetDocInvoiceTime(DateTime_v issue_time,ID xAtom_WorkPeriod_ID)
        {
            if (issue_time != null)
            {
                ID Journal_DocInvoice_ID = null;
              
                return f_Journal_DocInvoice.Write(this.Doc_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID, issue_time, ref Journal_DocInvoice_ID);
              
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:SetDocInvoiceTime:issue_time is null");
                return false;

            }
        }

        public bool SetDocProformaInvoiceTime(DateTime_v issue_time, ID xAtom_WorkPeriod_ID)
        {
            if (issue_time != null)
            {
                ID Journal_DocInvoice_ID = null;

                return f_Journal_DocProformaInvoice.Write(this.Doc_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceTime.ID, issue_time, ref Journal_DocInvoice_ID);

            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:SetDocProformaInvoiceTime:issue_time is null");
                return false;

            }
        }
   

        public bool Storno(ID xAtom_WorkPeriod_ID,ref ID Storno_DocInvoice_ID,  bool bStorno,string ElectronicDevice_Name, string sReason,ref  DateTime retissue_time)
        {
            object ores = null;
            string Err = null;
            DataTable dt_ProfInv = new DataTable();
            string sql = @"select  
                        Draft,
                        DraftNumber, 
                        FinancialYear,
                        NumberInFinancialYear,
                        NetSum,
                        Discount,
                        EndSum,
                        TaxSum,
                        GrossSum,
                        Atom_Currency_ID,
                        Atom_Customer_Person_ID,
                        Atom_Customer_Org_ID,
                        aw.WarrantyConditions,
                        aw.WarrantyDurationType,
                        aw.WarrantyDuration,
                        diao.TermsOfPayment_ID,
                        diao.PaymentDeadline,
                        diao.MethodOfPayment_DI_ID
                        Paid,
                        Storno,
                        Invoice_Reference_ID,
                        Invoice_Reference_Type from DocInvoice di
					    inner join 	DocInvoiceAddOn diao on diao.DocInvoice_ID = di.ID
						left join Atom_Warranty aw on diao.Atom_Warranty_ID = aw.ID
						where di.ID = " + Doc_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt_ProfInv, sql, ref Err))
            {
                int_v DraftNumber_v = tf.set_int(dt_ProfInv.Rows[0]["DraftNumber"]);
                int_v FinancialYear_v = tf.set_int(dt_ProfInv.Rows[0]["FinancialYear"]);
                decimal_v NetSum_v = tf.set_decimal(dt_ProfInv.Rows[0]["NetSum"]);
                decimal_v Discount_v = tf.set_decimal(dt_ProfInv.Rows[0]["Discount"]);
                decimal_v EndSum_v = tf.set_decimal(dt_ProfInv.Rows[0]["EndSum"]);
                decimal_v TaxSum_v = tf.set_decimal(dt_ProfInv.Rows[0]["TaxSum"]);
                decimal_v GrossSum_v = tf.set_decimal(dt_ProfInv.Rows[0]["GrossSum"]);
                ID Atom_Customer_Person_ID = tf.set_ID(dt_ProfInv.Rows[0]["Atom_Customer_Person_ID"]);
                ID Atom_Customer_Org_ID = tf.set_ID(dt_ProfInv.Rows[0]["Atom_Customer_Org_ID"]);
                ID Atom_Currency_ID = tf.set_ID(dt_ProfInv.Rows[0]["Atom_Currency_ID"]);

                string_v WarrantyConditions_v = tf.set_string(dt_ProfInv.Rows[0]["WarrantyConditions"]);
                int_v WarrantyDurationType_v = tf.set_int(dt_ProfInv.Rows[0]["WarrantyDurationType"]);
                int_v WarrantyDuration_v = tf.set_int(dt_ProfInv.Rows[0]["WarrantyDuration"]);
                ID TermsOfPayment_ID = tf.set_ID(dt_ProfInv.Rows[0]["TermsOfPayment_ID"]);
                int iNewNumberInFinancialYear = -1;
                GetNewNumberInFinancialYear(GlobalData.const_DocInvoice, ElectronicDevice_Name,ref iNewNumberInFinancialYear);
                int_v iNewNumberInFinancialYear_v = new int_v(iNewNumberInFinancialYear);

                ID Storno_Invoice_ID = new ID(Doc_ID);

                NetSum_v.v = -NetSum_v.v;
                TaxSum_v.v = -TaxSum_v.v;
                GrossSum_v.v = -GrossSum_v.v;

                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                sql = @"insert into DocInvoice (
                                                Draft,
                                                DraftNumber,
                                                FinancialYear,
                                                NumberInFinancialYear,
                                                NetSum,
                                                Discount,
                                                EndSum,
                                                TaxSum,
                                                GrossSum,
                                                Atom_Currency_ID,
                                                Atom_Customer_Person_ID,
                                                Atom_Customer_Org_ID,
                                                Invoice_Reference_ID,
                                                Storno,
                                                Invoice_Reference_Type
                                                )
                                                values
                                                (
                                                    0,"
                                                            + GetParam("DraftNumber", ref lpar, DraftNumber_v) + ","
                                                            + GetParam("FinancialYear", ref lpar, FinancialYear_v) + ","
                                                            + GetParam("NumberInFinancialYear", ref lpar, iNewNumberInFinancialYear_v) + ","
                                                            + GetParam("NetSum", ref lpar, NetSum_v) + ","
                                                            + GetParam("Discount", ref lpar, Discount_v) + ","
                                                            + GetParam("EndSum", ref lpar, EndSum_v) + ","
                                                            + GetParam("TaxSum", ref lpar, TaxSum_v) + ","
                                                            + GetParam("GrossSum", ref lpar, GrossSum_v) + ","
                                                            + GetParam("Atom_Currency_ID", ref lpar, Atom_Currency_ID) + ","
                                                            + GetParam("Atom_Customer_Person_ID", ref lpar, Atom_Customer_Person_ID) + ","
                                                            + GetParam("Atom_Customer_Org_ID", ref lpar, Atom_Customer_Org_ID) + ","
                                                            + GetParam("Invoice_Reference_ID", ref lpar, Storno_Invoice_ID) + @",
                                                            1,
                                                            'STORNO'
                                                            )";

                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Storno_DocInvoice_ID, ref Err, GlobalData.const_DocInvoice))
                        {
                            string sBit = "0";
                            if (bStorno)
                            {
                                sBit = "1";
                            }
                            sql = " update Docinvoice set Storno  = " + sBit + @",
                                                   Invoice_Reference_ID = " + Storno_DocInvoice_ID.ToString() + @",
                                                   Invoice_Reference_Type = 'STORNO' where ID = " + this.Doc_ID.ToString();

                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                        {
                            ID Journal_DocInvoice_ID = null;
                            DateTime_v issue_time = new DateTime_v(DateTime.Now);

                            retissue_time = issue_time.v;

                            if (f_Journal_DocInvoice.Write(Storno_DocInvoice_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID, issue_time, ref Journal_DocInvoice_ID))
                            {
                                  return true;
                            }
                            return false;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }

        private string GetParam(string scol_name, ref List<SQL_Parameter> lpar, object type_v)
        {
            string sParam = "@par_" + scol_name;
            if (type_v == null)
            {
                return "null";
            }
            if (type_v is int_v)
            {
                lpar.Add(new SQL_Parameter(sParam, SQL_Parameter.eSQL_Parameter.Int, false, ((int_v)type_v).v));
                return sParam;
            }
            else if (type_v is long_v)
            {
                lpar.Add(new SQL_Parameter(sParam, SQL_Parameter.eSQL_Parameter.Bigint, false, ((long_v)type_v).v));
                return sParam;
            }
            else if (type_v is decimal_v)
            {
                lpar.Add(new SQL_Parameter(sParam, SQL_Parameter.eSQL_Parameter.Decimal, false, ((decimal_v)type_v).v));
                return sParam;
            }
            else if (type_v is string_v)
            {
                lpar.Add(new SQL_Parameter(sParam, SQL_Parameter.eSQL_Parameter.Varchar, false, ((string_v)type_v).v));
                return sParam;
            }
            else if (type_v is bool_v)
            {
                lpar.Add(new SQL_Parameter(sParam, SQL_Parameter.eSQL_Parameter.Bit, false, ((bool_v)type_v).v));
                return sParam;
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:GetParam:type_v not implemented : " + type_v.GetType().ToString());
                return null;
            }
        }

        public int ItemsCount(string xDocTyp)
        {
            int iCount = 0;
            string Err = null;
            string sql = "select '"+xDocTyp+"_ShopA_Item' as "+xDocTyp+"_ShopA_Item, count(ID) AS " + xDocTyp + "_Items_Count from " + xDocTyp + "_ShopA_Item where " + xDocTyp + "_ID = " + Doc_ID.ToString()
                        + " UNION ALL select '" + xDocTyp + "_ShopB_Item' as " + xDocTyp + "_ShopB_Item,count(ID) AS " + xDocTyp + "_Items_Count from " + xDocTyp + "_ShopB_Item where " + xDocTyp + "_ID = " + Doc_ID.ToString()
                        + " UNION ALL select '" + xDocTyp + "_ShopC_Item' as " + xDocTyp + "_ShopC_Item,count(ID) AS " + xDocTyp + "_Items_Count from " + xDocTyp + "_ShopC_Item where " + xDocTyp + "_ID = " + Doc_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    iCount = Convert.ToInt32(dt.Rows[0][xDocTyp + "_Items_Count"]) + Convert.ToInt32(dt.Rows[1][xDocTyp + "_Items_Count"]) + Convert.ToInt32(dt.Rows[2][xDocTyp + "_Items_Count"]);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:CurrentInvoice:ItemsCount:sql=" + sql + "\r\nErr=" + Err);
            }
            return iCount;
        }
    }
}
