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
            ID atom_Taxation_ID = null;
            return f_Atom_Price_Item.Get(appisd.Atom_Item_UniqueName.v,
                                        appisd.Atom_Item_Name_Name,
                                        appisd.Atom_Item_barcode_barcode,
                                        appisd.Atom_Item_Description_Description,
                                        appisd.Atom_Expiry_ExpectedShelfLifeInDays,
                                        appisd.Atom_Expiry_SaleBeforeExpiryDateInDays,
                                        appisd.Atom_Expiry_DiscardBeforeExpiryDateInDays,
                                        appisd.Atom_Expiry_ExpiryDescription,
                                        appisd.Atom_Warranty_WarrantyDurationType,
                                        appisd.Atom_Warranty_WarrantyDuration,
                                        appisd.Atom_Warranty_WarrantyConditions,
                                        appisd.Atom_Unit_Name,
                                        appisd.Atom_Unit_Symbol,
                                        appisd.Atom_Unit_DecimalPlaces,
                                        appisd.Atom_Unit_StorageOption,
                                        appisd.Atom_Unit_Description,
                                        appisd.Atom_PriceList_Name,
                                        appisd.Atom_Currency_Abbreviation,
                                        appisd.Atom_Currency_Name,
                                        appisd.Atom_Item_Image_Hash,
                                        appisd.Atom_Item_Image_Data,
                                        appisd.RetailPricePerUnit.v,
                                        appisd.Discount.v,
                                        appisd.Atom_Taxation_Name.v,
                                        appisd.Atom_Taxation_Rate.v,
                                        ref atom_Taxation_ID,
                                        ref appisd.Atom_Item_ID,
                                        ref appisd.Atom_Price_Item_ID
                                        );
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
