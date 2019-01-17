﻿#region LICENSE 
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
using TangentaDB;

namespace ShopC_Forms
{
    public class CurrentConsumption
    {
        public class TaxInvoice
        {
            public ID StornoConsumption_ID = null;
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


        public DataTable dtCurrent_Invoice = null;
        public DataTable dtCurrent_Atom_Price_ShopBItem = null;

        public DataTable dtCurrent_Consumption_ShopC_Item = null;

        public ShopShelfConsumption m_ShopShelf = null;
        public BasketConsumption m_Basket = null;

        DBTablesAndColumnNamesOfDocInvoice DBtcn = null;

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

        // Consumption
        public CurrentConsumption.TaxInvoice TInvoice = new CurrentConsumption.TaxInvoice();

        // DocProformaInvoice
        public CurrentConsumption.ProformaInvoice PInvoice = new CurrentConsumption.ProformaInvoice();


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
                        dtCurrent_Consumption_ShopC_Item.Clear();
                        if (m_Basket != null)
                        {
                            m_Basket.Basket_Consumption_ShopC_Item_LIST.Clear();
                        }
                    }
                }
        
       }

        public CurrentConsumption(ShopABC xInvoiceDB, DBTablesAndColumnNamesOfDocInvoice xDBtcn)
        {
            m_InvoiceDB = xInvoiceDB;
            DBtcn = xDBtcn;

            dtCurrent_Invoice = new DataTable();
            dtCurrent_Atom_Price_ShopBItem = new DataTable();

            dtCurrent_Consumption_ShopC_Item = new DataTable();

            m_ShopShelf = new ShopShelfConsumption();
            m_Basket = new BasketConsumption();

            
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
            ID Consumption_ShopB_Item_Consumption_ID;
            ID Consumption_ShopB_Item_SimpleItem_ID;
            ID Consumption_ShopB_Item_Atom_SimpleItem_Name_ID;
            ID Consumption_ShopB_Item_Atom_SimpleItem_Image_ID;
            ID Consumption_ShopB_Item_Atom_Taxation_ID;
            int Consumption_ShopB_Item_Quantity;
            string Consumption_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name;
            string Consumption_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Abbreviation;
            decimal Consumption_ShopB_Item_RetailSimpleItemPrice;
            decimal Consumption_ShopB_Item_Discount;
            string Consumption_ShopB_Item_Atom_Taxation_Name;
            decimal Consumption_ShopB_Item_Atom_Taxation_Rate;
            decimal Consumption_ShopB_Item_TaxPrice;
            decimal Consumption_ShopB_Item_RetailSimpleItemPriceWithDiscount;
            decimal Consumption_ShopB_Item_PriceWithoutTax;
            decimal Consumption_ShopB_Item_ExtraDiscount;
            dt_SelectedSimpleItem.Clear();
            foreach (DataRow drsa in dtCurrent_Atom_Price_ShopBItem.Rows)
            {
                Atom_SimpleItem_ID = tf.set_ID(drsa["ID"]);
                Consumption_ShopB_Item_Consumption_ID = tf.set_ID(drsa[xDocTyp+"_ID"]);
                Consumption_ShopB_Item_SimpleItem_ID = tf.set_ID(drsa["SimpleItem_ID"]);
                Consumption_ShopB_Item_Atom_SimpleItem_Name_ID = tf.set_ID(drsa["Atom_SimpleItem_Name_ID"]);
                Consumption_ShopB_Item_Atom_SimpleItem_Image_ID = tf.set_ID(drsa["Atom_SimpleItem_Image_ID"]);

                Consumption_ShopB_Item_Atom_Taxation_ID = tf.set_ID(drsa["Atom_Taxation_ID"]);
                Consumption_ShopB_Item_Quantity = (int)drsa["iQuantity"];
                Consumption_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name = (string)drsa["Name"];
                Consumption_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Abbreviation = (string)drsa["Abbreviation"];
                Consumption_ShopB_Item_RetailSimpleItemPrice = (decimal)drsa["RetailSimpleItemPrice"];
                Consumption_ShopB_Item_Discount = (decimal)drsa["Discount"];
                Consumption_ShopB_Item_ExtraDiscount = (decimal)drsa["ExtraDiscount"];
                Consumption_ShopB_Item_Atom_Taxation_Name = (string)drsa["Atom_Taxation_Name"];
                Consumption_ShopB_Item_Atom_Taxation_Rate = (decimal)drsa["Atom_Taxation_Rate"];
                Consumption_ShopB_Item_TaxPrice = (decimal)drsa["TaxPrice"];
                Consumption_ShopB_Item_RetailSimpleItemPriceWithDiscount = (decimal)drsa["RetailSimpleItemPriceWithDiscount"];

                Consumption_ShopB_Item_PriceWithoutTax = Consumption_ShopB_Item_RetailSimpleItemPriceWithDiscount - Consumption_ShopB_Item_TaxPrice;

                DataRow dr = dt_SelectedSimpleItem.NewRow();
                //dr[DBtcn.column_SelectedShopBItem_dt_ShopBItem_Index] = Find_dt_SimpleItem_Index(dt_SimpleItems, Consumption_ShopB_Item_SimpleItem_ID);
                dr[DBtcn.column_Selected_Atom_Price_ShopBItem_ID] = Atom_SimpleItem_ID.V;
                dr[DBtcn.column_SelectedShopBItem_ShopBItem_ID] = Consumption_ShopB_Item_SimpleItem_ID.V;
                dr[DBtcn.column_SelectedShopBItem_Count] = Consumption_ShopB_Item_Quantity;
                dr[DBtcn.column_SelectedShopBItemName] = Consumption_ShopB_Item_Atom_SimpleItem_Atom_SimpleItem_Name;
                dr[DBtcn.column_SelectedShopBItemPriceWithoutTax] = Consumption_ShopB_Item_PriceWithoutTax;
                dr[DBtcn.column_SelectedShopBItemPriceTax] = Consumption_ShopB_Item_TaxPrice;
                dr[DBtcn.column_SelectedShopBItem_TaxName] = Consumption_ShopB_Item_Atom_Taxation_Name;
                dr[DBtcn.column_SelectedShopBItem_TaxRate] = Consumption_ShopB_Item_Atom_Taxation_Rate;
                dr[DBtcn.column_SelectedShopBItem_ExtraDiscount] = Consumption_ShopB_Item_ExtraDiscount;
                dr[DBtcn.column_SelectedShopBItemPrice] = Consumption_ShopB_Item_RetailSimpleItemPriceWithDiscount;
                dr[DBtcn.column_SelectedShopBItemRetailPricePerUnit] = Consumption_ShopB_Item_RetailSimpleItemPrice;
                dt_SelectedSimpleItem.Rows.Add(dr);
                int index = dt_SelectedSimpleItem.Rows.IndexOf(dr);
                if (Consumption_ShopB_Item_ExtraDiscount != 0)
                {
                    try
                    {
                        dgv_SelectedSimpleItems.Rows[index].Cells["btn_discount"].Value = Consumption_ShopB_Item_ExtraDiscount;
                    }
                    catch
                    {
                        dgv_SelectedSimpleItems.Rows[index].Cells["SelectedSimpleItem_ExtraDiscount"].Value = Consumption_ShopB_Item_ExtraDiscount;
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

     

        internal bool SaveConsumptionOwnUse(string xDocTyp,ref ID xConsumption_ID, OwnUseAddOn xOwnUseAddOn, string ElectronicDevice_Name, ref int xNumberInFinancialYear, Transaction transaction)
        {
            string sql = null;
            string Err = null;
            if (GetNewNumberInFinancialYear(xDocTyp, ElectronicDevice_Name))
            {
                xNumberInFinancialYear = NumberInFinancialYear;
                sql = "update DocProformaInvoice set Draft =0,NumberInFinancialYear = " + NumberInFinancialYear.ToString() + "  where ID = " + Doc_ID.ToString(); // Close Proforma Invoice
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    xConsumption_ID = Doc_ID;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:CurrentInvoice:SaveDocProformaInvoice:Err=" + Err);
                }
            }
            return false;
        }


        public bool Get_Atom_Price_Item(ref TangentaDB.Consumption_ShopC_Item xdsci, Transaction transaction)
        {
            ID atom_Taxation_ID = null;
            return f_Atom_Price_Item.Get(xdsci.Atom_Item_UniqueName_v.v,
                                        xdsci.Atom_Item_Name_Name_v,
                                        xdsci.Atom_Item_barcode_barcode_v,
                                        xdsci.Atom_Item_Description_Description,
                                        xdsci.Atom_Expiry_ExpectedShelfLifeInDays_v,
                                        xdsci.Atom_Expiry_SaleBeforeExpiryDateInDays_v,
                                        xdsci.Atom_Expiry_DiscardBeforeExpiryDateInDays_v,
                                        xdsci.Atom_Expiry_ExpiryDescription,
                                        xdsci.Atom_Warranty_WarrantyDurationType_v,
                                        xdsci.Atom_Warranty_WarrantyDuration_v,
                                        xdsci.Atom_Warranty_WarrantyConditions_v,
                                        xdsci.Atom_Unit_Name_v,
                                        xdsci.Atom_Unit_Symbol_v,
                                        xdsci.Atom_Unit_DecimalPlaces_v,
                                        xdsci.Atom_Unit_StorageOption_v,
                                        xdsci.Atom_Unit_Description_v,
                                        xdsci.Atom_PriceList_Name_v,
                                        xdsci.Atom_Currency_Abbreviation_v,
                                        xdsci.Atom_Currency_Name_v,
                                        xdsci.Atom_Item_Image_Hash_v,
                                        xdsci.Atom_Item_Image_Data_v,
                                        new decimal_v(xdsci.RetailPricePerUnit),
                                        new decimal_v(xdsci.Discount),
                                        xdsci.Atom_Taxation_Name_v,
                                        xdsci.Atom_Taxation_Rate_v,
                                        ref atom_Taxation_ID,
                                        ref xdsci.Atom_Item_ID,
                                        ref xdsci.Atom_Price_Item_ID,
                                        transaction
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

        public bool Update_Customer_Remove(string xDocTyp, Transaction transaction)
        {
            string sql = "update "+ xDocTyp + " set Atom_Customer_Org_ID = null,Atom_Customer_Person_ID = null where ID = " + this.Doc_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
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


        public bool Remove_usrc_Atom_Item_Factory_Items(Transaction transaction)
        {
            string sIn_ID_list = null;
            if (sIn_ID_list != null)
            {
                sIn_ID_list += ")";
                string sql_Delete_Consumption_Atom_Item_Stock = "delete from Consumption_ShopC_Item where (Consumption_ID = " + Doc_ID.ToString() + ") and Consumption_ShopC_Item.Stock_ID is null and Atom_Price_Item_ID in " + sIn_ID_list;
                string Err = null;
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Consumption_Atom_Item_Stock, null,  ref Err))
                {
                    string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from Consumption_ShopC_Item)";
                    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Price_Item, null,  ref Err))
                    {
                        string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Item_Image, null,  ref Err))
                        {
                            string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Item_ImageLib, null,  ref Err))
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
                    LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:delete from Consumption_ShopC_Item:Err=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Remove_usrc_Atom_Item_Factory_Items:No factory Items. Expected at least one Remove_usrc_Atom_Item_Factory_Items item!");
                return false;
            }
        }

        public bool SaveConsumptionWriteOff(string xDocTyp,ref ID xConsumption_ID, WriteOffAddOn xWriteOffAddOn,CashierActivity ca, string ElectronicDevice_Name,ref int xNumberInFinancialYear, Transaction transaction)
        {
            string sql = null;
            string Err = null;
            if (GetNewNumberInFinancialYear(xDocTyp,  ElectronicDevice_Name))
            {
                xNumberInFinancialYear = NumberInFinancialYear;
                sql = "update Consumption set Draft =0,NumberInFinancialYear = " + NumberInFinancialYear.ToString() + "  where ID = " + Doc_ID.ToString(); // Close Proforma Invoice
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
                {
                    xConsumption_ID = Doc_ID;
                    if (ca != null)
                    {
                       //if (ca.Add(xConsumption_ID, transaction))
                       // {
                       //     return true;
                       // }
                       //else
                       // {
                       //     return false;
                       // }

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
            //string sql = " select " + DBSync.DBSync.sTop(iLimit) + " NumberInFinancialYear from Consumption where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " and " + cond + " order by NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);
            //string sql = " select " + DBSync.DBSync.sTop(iLimit) + " NumberInFinancialYear from "+ Consumption + " where Draft = 0 and FinancialYear = " + FinancialYear.ToString() + " order by NumberInFinancialYear desc " + DBSync.DBSync.sLimit(iLimit);

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

        public bool Update_Customer_Person(string xDocTyp, ID Customer_Person_ID, ref ID xAtom_Customer_Person_ID, Transaction transaction)
        {
            if (f_Atom_Customer_Person.Get(Customer_Person_ID, ref xAtom_Customer_Person_ID, transaction))
            {
                if (ID.Validate(xAtom_Customer_Person_ID))
                {
                    string sql = "update "+xDocTyp+" set Atom_Customer_Person_ID = " + xAtom_Customer_Person_ID.ToString() + ",Atom_Customer_Org_ID = null where ID = " + this.Doc_ID.ToString();
                    string Err = null;
                    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
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

        public bool Update_Customer_Org(string xDocTyp,ID Customer_Org_ID, ref ID xAtom_Customer_Org_ID, Transaction transaction)
        {
            if (f_Atom_Customer_Org.Get(Customer_Org_ID, ref xAtom_Customer_Org_ID, transaction))
            {
                if (ID.Validate(xAtom_Customer_Org_ID))
                {
                    string sql = "update "+xDocTyp+" set Atom_Customer_Org_ID = " + xAtom_Customer_Org_ID.ToString() + ",Atom_Customer_Person_ID = null where ID = " + this.Doc_ID.ToString();
                    string Err = null;
                    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
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




        public bool SetConsumptionTime(DateTime_v issue_time,ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            if (issue_time != null)
            {
                ID Journal_Consumption_ID = null;
              
                return f_Journal_Consumption.Write(this.Doc_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionTime.ID, issue_time, ref Journal_Consumption_ID, transaction);
              
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:SetConsumptionTime:issue_time is null");
                return false;

            }
        }

        public bool SetDocProformaInvoiceTime(DateTime_v issue_time, ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            if (issue_time != null)
            {
                ID Journal_Consumption_ID = null;

                return f_Journal_DocProformaInvoice.Write(this.Doc_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceTime.ID, issue_time, ref Journal_Consumption_ID, transaction);

            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:SetDocProformaInvoiceTime:issue_time is null");
                return false;

            }
        }


        public bool Storno(ID xAtom_WorkPeriod_ID,
                            ref ID Storno_Consumption_ID,
                            bool bStorno,
                            string ElectronicDevice_Name,
                            string sReason,
                            ref DateTime retissue_time,
                            Transaction transaction)
        {
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
                        diao.MethodOfPayment_DI_ID,
                        Paid,
                        Storno,
                        Invoice_Reference_ID,
                        Invoice_Reference_Type 
                        from Consumption di
					    inner join 	ConsumptionAddOn diao on diao.Consumption_ID = di.ID
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
                ID MethodOfPayment_DI_ID = tf.set_ID(dt_ProfInv.Rows[0]["MethodOfPayment_DI_ID"]);
                int iNewNumberInFinancialYear = -1;
                GetNewNumberInFinancialYear(GlobalData.const_Consumption, ElectronicDevice_Name, ref iNewNumberInFinancialYear);
                int_v iNewNumberInFinancialYear_v = new int_v(iNewNumberInFinancialYear);

                ID Storno_Invoice_ID = new ID(Doc_ID);

                NetSum_v.v = -NetSum_v.v;
                TaxSum_v.v = -TaxSum_v.v;
                GrossSum_v.v = -GrossSum_v.v;

                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
               
                sql = @"insert into Consumption (
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

                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Storno_Consumption_ID, ref Err, GlobalData.const_Consumption))
                {

                    string spar_DocumentInvoice_ID = "@par_DocumentInvoice_ID";
                    SQL_Parameter par_DocumentInvoice_ID = new SQL_Parameter(spar_DocumentInvoice_ID, false, Storno_Consumption_ID);
                    lpar.Add(par_DocumentInvoice_ID);

                    string spar_IssueDate = "@par_IssueDate";
                    DateTime dtIssueDate = DateTime.Today;
                    SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, dtIssueDate);
                    lpar.Add(par_IssueDate);

                    string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                    SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, false, TermsOfPayment_ID);
                    lpar.Add(par_TermsOfPayment_ID);

                    string spar_MethodOfPayment_DI_ID = "@par_MethodOfPayment_DI_ID";
                    SQL_Parameter par_MethodOfPayment_DI_ID = new SQL_Parameter(spar_MethodOfPayment_DI_ID, false, MethodOfPayment_DI_ID);
                    lpar.Add(par_MethodOfPayment_DI_ID);

                   
                    sql = @" insert into ConsumptionAddOn
                                     (Consumption_ID,
                                      IssueDate,
                                      TermsOfPayment_ID,
                                      MethodOfPayment_DI_ID)
                                      values
                                     (" + spar_DocumentInvoice_ID + ","
                             + spar_IssueDate + ","
                             + spar_TermsOfPayment_ID + ","
                             + spar_MethodOfPayment_DI_ID + ")";

                    ID Storno_ConsumptionAddOn_ID = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Storno_ConsumptionAddOn_ID, ref Err, "ConsumptionAddOn"))
                    {

                        string sBit = "0";
                        if (bStorno)
                        {
                            sBit = "1";
                        }
                        
                        sql = " update Consumption set Storno  = " + sBit + @",
                                                       Invoice_Reference_ID = " + Storno_Consumption_ID.ToString() + @",
                                                       Invoice_Reference_Type = 'STORNO' where ID = " + this.Doc_ID.ToString();

                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            ID stornoReason_ID = null;
                            if (f_StornoReason.Get(Storno_Consumption_ID, sReason, ref stornoReason_ID, transaction))
                            {
                                ID Journal_Consumption_ID = null;
                                DateTime_v issue_time = new DateTime_v(DateTime.Now);
                                retissue_time = issue_time.v;

                                if (f_Journal_Consumption.Write(Storno_Consumption_ID, xAtom_WorkPeriod_ID, GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionStornoTime.ID, issue_time, ref Journal_Consumption_ID, transaction))
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:CurrentInvoice:Storno:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
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
            else if (type_v is ID)
            {
                lpar.Add(new SQL_Parameter(sParam,  false, (ID)type_v));
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
