using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlagajnaTableClass;
using SQLTableControl;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;
using System.Data;
using System.Windows.Forms;

namespace InvoiceDB
{
    public class ShopABC
    {


        BlagajnaTableClass.SQL_Database_Tables_Definition td = null;
        DBTablesAndColumnNames DBtcn = null;

        public xTaxationList m_xTaxationList = null;

        public xUnitList m_xUnitList = null;

        public CurrentInvoice m_CurrentInvoice = null;


        public bool Get(ref long Invoice_ID, bool bDraft, long ID, ref string Err)
        {
            SQLTable tbl_Invoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Invoice));
            SQLTable tbl_ProformaInvoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(ProformaInvoice));
            SQLTable tbl_Atom_myCompany_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany_Person));
            SQLTable tbl_Atom_myCompany = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany));

            string cond = null;
            if (ID >= 0)
            {
                cond = " where  JOURNAL_ProformaInvoice_$_pinv_$$ID = " + ID.ToString();
            }
            else if (bDraft)
            {
                cond = " where JOURNAL_ProformaInvoice_$_pinv_$$Draft = 1 ";
            }
            else
            {
                cond = "";
            }



            string sql_GetDraft = @"Select
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$Job,
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$UserName,
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$Description,
                        JOURNAL_ProformaInvoice_$_pinv_$$ID,
                        JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                        JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                        JOURNAL_ProformaInvoice_$_pinv_$$Draft,
                        JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber,
                        JOURNAL_ProformaInvoice_$_pinv_$_acusper_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                        JOURNAL_ProformaInvoice_$_pinv_$$Discount,
                        JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
                        JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                        JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                        JOURNAL_ProformaInvoice_$_pinv_$$WarrantyExist,
                        JOURNAL_ProformaInvoice_$_pinv_$$WarrantyDurationType,
                        JOURNAL_ProformaInvoice_$_pinv_$$WarrantyDuration,
                        JOURNAL_ProformaInvoice_$_pinv_$$WarrantyConditions,
                        JOURNAL_ProformaInvoice_$_pinv_$$ProformaInvoiceDuration,
                        JOURNAL_ProformaInvoice_$_pinv_$$ProformaInvoiceDurationType,
                        JOURNAL_ProformaInvoice_$_pinv_$_trmpay_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$$PaymentDeadline,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$ID,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
                        JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno
                        from JOURNAL_ProformaInvoice_VIEW " + cond;


            m_CurrentInvoice.dtCurrent_Invoice.Clear();
            if (DBSync.DBSync.ReadDataTable(ref m_CurrentInvoice.dtCurrent_Invoice, sql_GetDraft, ref Err))
            {
                if (m_CurrentInvoice.dtCurrent_Invoice.Rows.Count > 0)
                {
                    m_CurrentInvoice.Exist = true;
                    m_CurrentInvoice.bDraft = (bool)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$$Draft"];
                    m_CurrentInvoice.Invoice_ID = (long)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID"];
                    m_CurrentInvoice.ProformaInvoice_ID = (long)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$$ID"];
                    m_CurrentInvoice.FinancialYear = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear"];
                    m_CurrentInvoice.bStorno = (bool)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno"];

                    object o_Atom_Customer_Person_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$_acusper_$$ID"];
                    if (o_Atom_Customer_Person_ID is long)
                    {
                        if (m_CurrentInvoice.Atom_Customer_Person_ID_v == null)
                        {
                            m_CurrentInvoice.Atom_Customer_Person_ID_v = new long_v();
                        }
                        m_CurrentInvoice.Atom_Customer_Person_ID_v.v = (long)o_Atom_Customer_Person_ID;
                    }
                    else
                    {
                        m_CurrentInvoice.Atom_Customer_Person_ID_v = null;
                    }
                    object o_Atom_Customer_Org_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$$ID"];
                    if (o_Atom_Customer_Org_ID is long)
                    {
                        if (m_CurrentInvoice.Atom_Customer_Org_ID_v == null)
                        {
                            m_CurrentInvoice.Atom_Customer_Org_ID_v = new long_v();
                        }
                        m_CurrentInvoice.Atom_Customer_Org_ID_v.v = (long)o_Atom_Customer_Org_ID;
                    }
                    else
                    {
                        m_CurrentInvoice.Atom_Customer_Org_ID_v = null;
                    }
                    object oNumberInFinancialYear = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear"];
                    if (oNumberInFinancialYear is int)
                    {
                        m_CurrentInvoice.NumberInFinancialYear = (int)oNumberInFinancialYear;
                    }
                    else
                    {
                        m_CurrentInvoice.NumberInFinancialYear = -1;
                    }

                    m_CurrentInvoice.DraftNumber = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber"];
                    Invoice_ID = m_CurrentInvoice.Invoice_ID;
                    if (Read_ShopB_Price_Item_Table(m_CurrentInvoice.ProformaInvoice_ID, ref m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem))
                    {
                        if (m_CurrentInvoice.m_Basket.Read_Atom_ProformaInvoice_Price_Item_Stock_Table(m_CurrentInvoice.ProformaInvoice_ID))
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
                        return false;
                    }
                }
                else
                {
                    m_CurrentInvoice.Exist = false;
                    m_CurrentInvoice.bDraft = false;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:GetDraft:select ... from " + DBtcn.stbl_ProformaInvoice_TableName + ":\r\nErr=" + Err);
                return false;
            }
        }


        public bool Read_ShopB_Price_Item_Table(long ProformaInvoice_ID, ref DataTable dt_Atom_Price_SimpleItem)
        {
            string Err = null;
            string sql_select_Atom_Price_SimpleItem = @"SELECT 
                                                Atom_Price_SimpleItem.ID, 
                                                Atom_Price_SimpleItem.ProformaInvoice_ID, 
                                                Atom_Price_SimpleItem.Atom_PriceList_ID,
                                                Atom_Price_SimpleItem.RetailSimpleItemPrice,
                                                Atom_Price_SimpleItem.Discount,
                                                Atom_Price_SimpleItem.ExtraDiscount,
                                                Atom_Price_SimpleItem.TaxPrice, 
                                                Atom_Price_SimpleItem.RetailSimpleItemPriceWithDiscount,
                                                Atom_PriceList.Name As Atom_PriceList_Name,
                                                Atom_Price_SimpleItem.Atom_Taxation_ID,
                                                Atom_Taxation.Name As Atom_Taxation_Name,
                                                Atom_Taxation.Rate As Atom_Taxation_Rate,
                                                Atom_SimpleItem.SimpleItem_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Name_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Image_ID, 
                                                Atom_Price_SimpleItem.iQuantity, 
                                                Atom_SimpleItem_Name.Name,
                                                Atom_SimpleItem_Name.Abbreviation, 
                                                Atom_PriceList.Name AS Atom_PriceList_Name,
                                                Atom_Currency.Name AS Atom_Currency_Name,
                                                Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                                                Atom_Currency.Symbol AS Atom_Currency_Symbol,
                                                Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces 
                                                from Atom_Price_SimpleItem
                                                inner join Atom_PriceList on Atom_Price_SimpleItem.Atom_PriceList_ID = Atom_PriceList.ID
                                                inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                                                inner join Atom_Taxation on Atom_Price_SimpleItem.Atom_Taxation_ID = Atom_Taxation.ID
                                                inner join Atom_SimpleItem on Atom_Price_SimpleItem.Atom_SimpleItem_ID = Atom_SimpleItem.ID
                                                Inner Join ProformaInvoice on ProformaInvoice.ID = Atom_Price_SimpleItem.ProformaInvoice_ID 
                                                Inner Join Invoice on ProformaInvoice.Invoice_ID = Invoice.ID 
                                                Inner Join Atom_SimpleItem_Name on Atom_SimpleItem_Name.ID = Atom_SimpleItem.Atom_SimpleItem_Name_ID
                                                where ProformaInvoice.Invoice_ID is not null and Atom_Price_SimpleItem.ProformaInvoice_ID = " + ProformaInvoice_ID.ToString();
            dt_Atom_Price_SimpleItem.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Atom_Price_SimpleItem, sql_select_Atom_Price_SimpleItem, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_Atom_SimpleItem_Table:select ... from Atom_SimpleItem:\r\n Err=" + Err);
                return false;
            }
        }


        public bool Read_ProformaInvoice_Atom_Item_Stock_Table(long ProformaInvoice_ID, long Atom_Item_ID, ref DataTable dtDraft_ProformaInvoice_Atom_Item_Stock, string scond, ref string Err)
        {
            string sql_select_ProformaInvoice_Atom_Item_Stock = @"
            SELECT 
            Atom_ProformaInvoice_Price_Item_Stock.dQuantity AS dQuantity,
            Atom_ProformaInvoice_Price_Item_Stock.ExtraDiscount AS ExtraDiscount,
            Atom_ProformaInvoice_Price_Item_Stock.RetailPriceWithDiscount AS RetailPriceWithDiscount,
            Atom_ProformaInvoice_Price_Item_Stock.TaxPrice AS  TaxPrice,
            Atom_ProformaInvoice_Price_Item_Stock.ID AS Atom_ProformaInvoice_Price_Item_Stock_ID,
            Atom_ProformaInvoice_Price_Item_Stock.ProformaInvoice_ID,
            Atom_ProformaInvoice_Price_Item_Stock.Stock_ID,
            Atom_ProformaInvoice_Price_Item_Stock.ExpiryDate,
            Atom_ProformaInvoice_Price_Item_Stock.Atom_Price_Item_ID,
            Atom_Item.ID as Atom_Item_ID,
            Atom_Price_Item.RetailPricePerUnit AS  RetailPricePerUnit,
            PurchasePrice.PurchasePricePerUnit,
            Atom_Price_Item.Discount AS  Discount,
            Atom_Item.UniqueName AS Atom_Item_UniqueName,
            Atom_Item_Name.Name AS Atom_Item_Name_Name,
            Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
            Atom_Taxation.Name AS Atom_Taxation_Name,
            Atom_Taxation.Rate AS Atom_Taxation_Rate,
            Atom_Item_Description.Description AS Atom_Item_Description_Description,
            Atom_Item.Atom_Warranty_ID,
            Atom_Unit.Name AS Atom_Unit_Name,
            Atom_Unit.Symbol AS Atom_Unit_Symbol,
            Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
            Atom_Unit.Description AS Atom_Unit_Description,
            Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
            Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
            Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
            Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
            Atom_Item.Atom_Expiry_ID,
            Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
            Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
            Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
            Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
            PurchasePrice_Item.Item_ID,
            Stock.ImportTime AS Stock_ImportTime,
            Stock.dQuantity AS Stock_dQuantity,
            Stock.ExpiryDate AS Stock_ExpiryDate,
            Atom_PriceList.Name AS Atom_PriceList_Name,
            Atom_Currency.Name AS Atom_Currency_Name,
            Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
            Atom_Currency.Symbol AS Atom_Currency_Symbol,
            Atom_Currency.CurrencyCode AS Atom_Currency_CurrencyCode,
            Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces,
            aiil.Image_Hash as Atom_Item_Image_Hash,
            aiil.Image_Data as Atom_Item_Image_Data,
            itm_g1.Name as s1_name,
            itm_g2.Name as s2_name, 
            itm_g3.Name as s3_name
            FROM Atom_ProformaInvoice_Price_Item_Stock
            INNER JOIN  Atom_Price_Item ON Atom_ProformaInvoice_Price_Item_Stock.Atom_Price_Item_ID = Atom_Price_Item.ID 
            INNER JOIN  Atom_Taxation ON Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID 
            INNER JOIN  Atom_PriceList ON Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID 
            INNER JOIN  Atom_Currency ON Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
            INNER JOIN  ProformaInvoice ON Atom_ProformaInvoice_Price_Item_Stock.ProformaInvoice_ID = ProformaInvoice.ID 
            INNER JOIN  Invoice ON ProformaInvoice.Invoice_ID = Invoice.ID
            INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
            INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
            INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
            LEFT JOIN  Stock ON Atom_ProformaInvoice_Price_Item_Stock.Stock_ID = Stock.ID 
            LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
            LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
            LEFT JOIN  PurchasePrice_Item ON Stock.PurchasePrice_Item_ID = PurchasePrice_Item.ID 
            LEFT JOIN  PurchasePrice ON PurchasePrice.ID = PurchasePrice_Item.PurchasePrice_ID 
            LEFT JOIN  Item itms ON PurchasePrice_Item.Item_ID = itms.ID 
            LEFT JOIN  Item_ParentGroup1 itm_g1 ON itms.Item_ParentGroup1_ID = itm_g1.ID 
            LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
            LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
            LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
            LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
            LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
            LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
            LEFT JOIN  Item_Image ON itms.Item_Image_ID = Item_Image.ID 
            where  (Atom_ProformaInvoice_Price_Item_Stock.ProformaInvoice_ID =  " + ProformaInvoice_ID.ToString() + ") and ( Atom_Item.ID = " + Atom_Item_ID.ToString() + ")" + scond;
            m_CurrentInvoice.dtCurrent_Atom_ProformaInvoice_Price_Item_Stock.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dtDraft_ProformaInvoice_Atom_Item_Stock, sql_select_ProformaInvoice_Atom_Item_Stock, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_ProformaInvoice_Atom_Item_Stock_Table:select ... from ProformaInvoice_Atom_Item_Stock:\r\n Err=" + Err);
                return false;
            }
        }

        public ShopABC(DBTablesAndColumnNames xDBtcn)
        {
            m_CurrentInvoice = new CurrentInvoice(this, xDBtcn);
            td = DBSync.DBSync.DB_for_Blagajna.mt;
            DBtcn = xDBtcn;

        }

        public bool SetNewDraft_Invoice(int iFinancialYear, Control pParent, ref long Invoice_ID,
                                  long myCompany_Person_ID,
                                  ref string Err)
        {
            DataTable dt = new DataTable();
            int xDraftNumber = -1;
            int iLimit = 1;
            string sql = @"select " + DBSync.DBSync.sTop(iLimit) + "DraftNumber from ProformaInvoice where Invoice_ID is not null order by DraftNumber desc " + DBSync.DBSync.sLimit(iLimit);
            if (!DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                LogFile.Error.Show("ERROR:InvoiceDB:SetNewDraft:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                xDraftNumber = (int)dt.Rows[0]["DraftNumber"];
                xDraftNumber++;
            }
            else
            {
                xDraftNumber = 0;
            }

            dt.Clear();
            dt.Columns.Clear();
            sql = @"select " + DBSync.DBSync.sTop(iLimit) + "ID,Invoice_ID,DraftNumber from ProformaInvoice where FinancialYear = " + iFinancialYear.ToString() + " and Invoice_ID is not null order by DraftNumber desc " + DBSync.DBSync.sLimit(iLimit);
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count == 1)
                {
                    //Draft already set
                    try
                    {
                        Invoice_ID = (long)dt.Rows[0]["Invoice_ID"];
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:InvoiceDB:SetNewDraft: Invoice_ID is not defined in ProformaInvoice! Exception =" + ex.Message);
                        return false;
                    }
                }

                string sql_SetDraftInvoice = "insert into " + DBtcn.stbl_Invoice_TableName
                                       + "("
                                            + DBtcn.GetName(td.m_Invoice.PaymentDeadline.GetType()) + ","
                                            + DBtcn.GetName(td.m_Invoice.m_MethodOfPayment.GetType()) + "_ID,"
                                            + DBtcn.GetName(td.m_Invoice.Paid.GetType()) + ","
                                            + DBtcn.GetName(td.m_Invoice.Storno.GetType())
                                       + @") values ( null,"
                                            + "null,"
                                            + "0,"
                                            + "0"
                                          + ")";
                m_CurrentInvoice.dtCurrent_Invoice.Clear();
                object objret = null;
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_SetDraftInvoice, null, ref Invoice_ID, ref objret, ref Err, DBtcn.stbl_Invoice_TableName))
                {
                    long Atom_myCompany_Person_ID = -1;
                    this.m_CurrentInvoice.Invoice_ID = Invoice_ID;
                    m_CurrentInvoice.FinancialYear = iFinancialYear;
                    m_CurrentInvoice.DraftNumber = xDraftNumber;
                    string_v office_name = null;
                    string error = null;
                    if (f_Atom_myCompany_Person.Get(myCompany_Person_ID, ref Atom_myCompany_Person_ID, ref office_name) == myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK)
                    {
                        //**TODO
                        string sql_SetDraftProformaInvoice = "insert into " + DBtcn.stbl_ProformaInvoice_TableName
                       + "("
                            + DBtcn.GetName(td.m_ProformaInvoice.m_Invoice.GetType()) + "_ID,"
                            + DBtcn.GetName(td.m_ProformaInvoice.FinancialYear.GetType()) + ","
                            + DBtcn.GetName(td.m_ProformaInvoice.DraftNumber.GetType()) + ","
                            + DBtcn.GetName(td.m_ProformaInvoice.Draft.GetType())
                       + @") values ( "
                        + Invoice_ID.ToString() + ","
                            + m_CurrentInvoice.FinancialYear.ToString() + ","
                            + m_CurrentInvoice.DraftNumber.ToString() + ","
                            + "1"
                          + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_SetDraftProformaInvoice, null, ref this.m_CurrentInvoice.ProformaInvoice_ID, ref objret, ref Err, DBtcn.stbl_Invoice_TableName))
                        {
                            long Journal_ProformaInvoice_ID = -1;
                            return f_Journal_ProformaInvoice.Write(this.m_CurrentInvoice.ProformaInvoice_ID, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID, null, ref Journal_ProformaInvoice_ID);
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:SetDraft:insert into " + DBtcn.stbl_Invoice_TableName + ":\r\nErr=" + Err);
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
                    LogFile.Error.Show("ERROR:SetDraft:insert into " + DBtcn.stbl_ProformaInvoice_TableName + ":\r\nErr=" + Err);
                    return false;
                }

            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceDB:SetNewDraft:Err=" + Err);
                return false;
            }
        }



        private bool Find_Atom_myCompany_Person_ID(long Atom_myCompany_ID, ref long Atom_myCompany_Person_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string sql_find_Atom_myCompany_Person_ID = @"select
                                Atom_myCompany_Person.ID as Atom_myCompany_Person_ID
                                from Atom_myCompany_Person
                                inner join myCompany_Person on Atom_myCompany_Person.UserName = myCompany_Person.UserName
                                where Atom_myCompany_Person.Atom_myCompany_ID = " + Atom_myCompany_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_myCompany_Person_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_myCompany_Person_ID = (long)dt.Rows[0]["Atom_myCompany_Person_ID"];
                }
                else
                {
                    Atom_myCompany_Person_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_myCompany_Person_ID: select
                                Atom_myCompany_Person.ID as Atom_myCompany_Person_ID
                                from Atom_myCompany_Person:\r\nErr=" + Err);
                return false;
            }
        }


        public bool Update_SelectedSimpleItem(DataRow dataRow, ref string Err)
        {
            Err = "NOT finished!";
            return false;
        }




        bool Get_Atom_Price_SimpleItem_ID(long ProformaInvoice_ID,
                                       long Price_SimpleItem_ID,
                                       long Atom_SimpleItem_Name_ID,
                                       long Atom_SimpleItem_Image_ID,
                                       decimal Atom_SimpleItem_TaxPrice,
                                       decimal Atom_SimpleItem_Discount,
                                       decimal Atom_SimpleItem_RetailSimpleItemPriceWithDiscount,
                                       string Atom_SimpleItem_Abbreviation,
                                       string Atom_SimpleItem_Image_ID_string,
                                       ref long Atom_Price_SimpleItem_ID
                                       )
        {
            if (Get_Atom_SimpleItem_ID(ProformaInvoice_ID,
                                    Price_SimpleItem_ID,
                                    Atom_SimpleItem_Name_ID,
                                    Atom_SimpleItem_Image_ID,
                                    Atom_SimpleItem_TaxPrice,
                                    Atom_SimpleItem_Discount,
                                    Atom_SimpleItem_RetailSimpleItemPriceWithDiscount,
                                    Atom_SimpleItem_Abbreviation,
                                    Atom_SimpleItem_Image_ID_string,
                                    ref Atom_Price_SimpleItem_ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Get_Atom_SimpleItem_ID(long ProformaInvoice_ID,
                                       long Price_SimpleItem_ID,
                                       long Atom_SimpleItem_Name_ID,
                                       long Atom_SimpleItem_Image_ID,
                                       decimal Atom_SimpleItem_TaxPrice,
                                       decimal Atom_SimpleItem_Discount,
                                       decimal Atom_SimpleItem_RetailSimpleItemPriceWithDiscount,
                                       string Atom_SimpleItem_Abbreviation,
                                       string Atom_SimpleItem_Image_ID_string,
                                       ref long Atom_SimpleItem_ID
                                       )
        {
            string Err = null;

            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            lpar.Clear();
            //string param_Atom_SimpleItem_RetailSimpleItemPrice = "@Atom_SimpleItem_RetailSimpleItemPrice";
            //DBConnectionControl40.SQL_Parameter par_Atom_SimpleItem_RetailSimpleItemPrice = new DBConnectionControl40.SQL_Parameter(param_Atom_SimpleItem_RetailSimpleItemPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Atom_SimpleItem_RetailSimpleItemPrice);
            //lpar.Add(par_Atom_SimpleItem_RetailSimpleItemPrice);
            string sparam_Atom_SimpleItem_TaxPrice = "@Atom_SimpleItem_TaxPrice";
            DBConnectionControl40.SQL_Parameter par_Atom_SimpleItem_TaxPrice = new DBConnectionControl40.SQL_Parameter(sparam_Atom_SimpleItem_TaxPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Atom_SimpleItem_TaxPrice);
            lpar.Add(par_Atom_SimpleItem_TaxPrice);
            string sparam_Atom_SimpleItem_Discount = "@Atom_SimpleItem_Discount";
            DBConnectionControl40.SQL_Parameter par_Atom_SimpleItem_Discount = new DBConnectionControl40.SQL_Parameter(sparam_Atom_SimpleItem_Discount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Atom_SimpleItem_Discount);
            lpar.Add(par_Atom_SimpleItem_Discount);
            string sparam_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount = "@Atom_SimpleItem_RetailSimpleItemPriceWithDiscount";
            DBConnectionControl40.SQL_Parameter par_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount = new DBConnectionControl40.SQL_Parameter(sparam_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Atom_SimpleItem_RetailSimpleItemPriceWithDiscount);
            lpar.Add(par_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount);

            string sparam_Atom_SimpleItem_Abbreviation = "@Atom_SimpleItem_Abbreviation";
            DBConnectionControl40.SQL_Parameter par_Atom_SimpleItem_Abbreviation = new DBConnectionControl40.SQL_Parameter(sparam_Atom_SimpleItem_Abbreviation, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, Atom_SimpleItem_Abbreviation);
            lpar.Add(par_Atom_SimpleItem_Abbreviation);

            string sql_Select_Atom_SimpleItem = @"
                                select ID from Atom_SimpleItem
                                   where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString() + @" and
                                    SimpleItem_ID = " + Price_SimpleItem_ID.ToString() + @" and
                                    Atom_SimpleItem_Name_ID = " + Atom_SimpleItem_Name_ID.ToString() + @" and
                                    Atom_SimpleItem_Image_ID = " + Atom_SimpleItem_Image_ID_string + @" and
                                    Abbreviation = " + sparam_Atom_SimpleItem_Abbreviation + @" and
                                    Discount = " + sparam_Atom_SimpleItem_Discount + @" and
                                    TaxPrice = " + sparam_Atom_SimpleItem_TaxPrice + @" and
                                    RetailSimpleItemPriceWithDiscount = " + sparam_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount + @"
                                ";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_Select_Atom_SimpleItem, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_SimpleItem_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_SimpleItem = @"
                                insert into Atom_SimpleItem
                                (
                                    ProformaInvoice_ID,
                                    SimpleItem_ID,
                                    Atom_SimpleItem_Name_ID,
                                    Atom_SimpleItem_Image_ID,
                                    iQuantity,
                                    Abbreviation,
                                    Discount,
                                    TaxPrice,
                                    RetailSimpleItemPriceWithDiscount
                                )
                                values
                                (
                                    " + ProformaInvoice_ID.ToString() + @",
                                    " + Price_SimpleItem_ID.ToString() + @",
                                    " + Atom_SimpleItem_Name_ID.ToString() + @",
                                    " + Atom_SimpleItem_Image_ID_string + @",
                                    1,
                                    " + sparam_Atom_SimpleItem_Abbreviation + @",
                                    " + sparam_Atom_SimpleItem_Discount + @",
                                    " + sparam_Atom_SimpleItem_TaxPrice + @",
                                    " + sparam_Atom_SimpleItem_RetailSimpleItemPriceWithDiscount + @"
                                )
                                ";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_SimpleItem, lpar, ref Atom_SimpleItem_ID, ref objretx, ref Err, DBtcn.stbl_Atom_ShopBItem_TableName))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Get_Atom_SimpleItem_ID:insert into Insert_Atom_SimpleItem_Taxation failed!\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Get_Atom_SimpleItem_ID:insert select ID from Atom_SimpleItem failed!\r\nErr=" + Err);
                return false;
            }
        }

        private bool Find_Atom_SimpleItem_Image_ID(string Atom_SimpleItem_Image_Image_Hash, ref long Atom_SimpleItem_Image_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string sql_find_Atom_SimpleItem_Image_ID = @"select
                                                    Atom_SimpleItem_Image.ID as Atom_SimpleItem_Image_ID
                                                    from Atom_SimpleItem_Image
                                                    where Image_Hash = '" + Atom_SimpleItem_Image_Image_Hash + "'";


            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_SimpleItem_Image_ID, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_SimpleItem_Image_ID = (long)dt.Rows[0]["Atom_SimpleItem_Image_ID"];
                }
                else
                {
                    Atom_SimpleItem_Image_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_SimpleItem_Image_ID:
                                          select
                                        Atom_SimpleItem_Image.ID as Atom_SimpleItem_Image_ID
                                        from Atom_SimpleItem_Image:\r\nErr=" + Err);
                return false;
            }

        }

        private bool Find_Atom_Taxation_ID(string Atom_Taxation_Name, decimal Atom_Taxation_Rate, ref long Atom_Taxation_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            string param_Taxation_Rate = "@taxation_rate";
            DBConnectionControl40.SQL_Parameter par = new DBConnectionControl40.SQL_Parameter(param_Taxation_Rate, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Atom_Taxation_Rate);
            lpar.Add(par);

            string sql_find_Atom_Taxation_ID = @"select
                                                    Atom_Taxation.ID as Atom_Taxation_ID
                                                    from Atom_Taxation
                                                    where Name = '" + Atom_Taxation_Name + @"'
                                                          and Rate = " + param_Taxation_Rate;


            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_Taxation_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Taxation_ID = (long)dt.Rows[0]["Atom_Taxation_ID"];
                }
                else
                {
                    Atom_Taxation_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_Taxation_ID:
                                          select
                                         Atom_Taxation.ID as Atom_Taxation_ID
                                          from Atom_Taxation:\r\nErr=" + Err);
                return false;
            }
        }

        private bool Find_Atom_SimpleItem_Name_ID(string Atom_SimpleItem_Name, ref long Atom_SimpleItem_Name_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string sql_find_Atom_SimpleItem_Name_ID = @"select
                                                    Atom_SimpleItem_Name.ID as Atom_SimpleItem_Name_ID
                                                    from Atom_SimpleItem_Name
                                                    where Name = '" + Atom_SimpleItem_Name + "'";


            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_SimpleItem_Name_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_SimpleItem_Name_ID = (long)dt.Rows[0]["Atom_SimpleItem_Name_ID"];
                }
                else
                {
                    Atom_SimpleItem_Name_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_SimpleItem_Name_ID:
                                            select
                                            Atom_SimpleItem_Name.ID as Atom_SimpleItem_Name_ID
                                            from Atom_SimpleItem_Name:\r\nErr=" + Err);
                return false;
            }

        }


        public bool Update_SelectedSimpleItem(long Atom_Price_SimpleItem_ID,
                                             int iCount,
                                             decimal Discount,
                                             decimal ExtraDiscount,
                                             decimal RetailSimpleItemPrice,
                                             string Taxation_Name,
                                             decimal Taxation_Rate,
                                             ref decimal RetailSimpleItemPriceWithDiscount,
                                             ref decimal TaxPrice,
                                             ref decimal PriceWithoutTax,
                                             ref string Err)
        {
            int decimal_places = 2;
            if (GlobalData.BaseCurrency != null)
            {
                decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
            }
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            bool bUpdate_Atom_SimpleItem_Taxation_ID = false;
            int irow_Atom_SimpleItem = (int)FindRowIndex_In_dtDraft_Atom_SimpleItem(Atom_Price_SimpleItem_ID);
            long new_Atom_Taxation_ID = -1;
            if (irow_Atom_SimpleItem >= 0)
            {
                long Atom_Taxation_ID = (long)m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem.Rows[irow_Atom_SimpleItem]["Atom_Taxation_ID"];

                string sparam_Atom_Taxation_Rate = "@Atom_Taxation_Rate";
                DBConnectionControl40.SQL_Parameter par_Atom_Taxation_Rate = new DBConnectionControl40.SQL_Parameter(sparam_Atom_Taxation_Rate, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Taxation_Rate);
                lpar.Add(par_Atom_Taxation_Rate);

                DataTable dt = new DataTable();
                string sql_get_Atom_SimpleItem_Taxation = "select ID from Atom_Taxation where Name = '" + Taxation_Name + "' and Rate = " + sparam_Atom_Taxation_Rate;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_get_Atom_SimpleItem_Taxation, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        new_Atom_Taxation_ID = (long)dt.Rows[0]["ID"];
                        if (Atom_Taxation_ID != new_Atom_Taxation_ID)
                        {
                            bUpdate_Atom_SimpleItem_Taxation_ID = true;
                        }
                    }
                    else
                    {
                        string sql_insert_Atom_SimpleItem_Taxation = "insert into Atom_Taxation (Name,Rate) values ('" + Taxation_Name + "'," + sparam_Atom_Taxation_Rate + ")";
                        object objretx = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert_Atom_SimpleItem_Taxation, lpar, ref new_Atom_Taxation_ID, ref objretx, ref Err, DBtcn.stbl_Atom_Taxation_TableName))
                        {
                            if (Atom_Taxation_ID != new_Atom_Taxation_ID)
                            {
                                bUpdate_Atom_SimpleItem_Taxation_ID = true;
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



                lpar.Clear();

                string param_RetailSimpleItemPrice = "@RetailSimpleItemPrice";
                DBConnectionControl40.SQL_Parameter par_RetailSimpleItemPrice = new DBConnectionControl40.SQL_Parameter(param_RetailSimpleItemPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, RetailSimpleItemPrice);
                lpar.Add(par_RetailSimpleItemPrice);

                string param_Discount = "@Discount";
                DBConnectionControl40.SQL_Parameter par_Discount = new DBConnectionControl40.SQL_Parameter(param_Discount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Discount);
                lpar.Add(par_Discount);

                string param_ExtraDiscount = "@ExtraDiscount";
                DBConnectionControl40.SQL_Parameter par_ExtraDiscount = new DBConnectionControl40.SQL_Parameter(param_ExtraDiscount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, ExtraDiscount);
                lpar.Add(par_ExtraDiscount);

                decimal dQuantity = Convert.ToDecimal(iCount);
                StaticLib.Func.CalculatePrice(RetailSimpleItemPrice, dQuantity, Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount, ref TaxPrice, ref PriceWithoutTax, decimal_places);



                string param_RetailSimpleItemPriceWithDiscount = "@RetailSimpleItemPriceWithDiscount";
                DBConnectionControl40.SQL_Parameter par_RetailSimpleItemPriceWithDiscount = new DBConnectionControl40.SQL_Parameter(param_RetailSimpleItemPriceWithDiscount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, RetailSimpleItemPriceWithDiscount);
                lpar.Add(par_RetailSimpleItemPriceWithDiscount);


                string param_TaxPrice = "@TaxPrice";
                DBConnectionControl40.SQL_Parameter par_TaxPrice = new DBConnectionControl40.SQL_Parameter(param_TaxPrice, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                lpar.Add(par_TaxPrice);

                long to_update_Atom_Taxation_ID = -1;
                if (bUpdate_Atom_SimpleItem_Taxation_ID)
                {
                    to_update_Atom_Taxation_ID = new_Atom_Taxation_ID;
                }
                else
                {
                    to_update_Atom_Taxation_ID = Atom_Taxation_ID;
                }
                string sql_update_Atom_SimpleItem = @"Update  Atom_Price_SimpleItem
                                                  set iQuantity = " + iCount.ToString() + @",
                                                      RetailSimpleItemPrice = " + param_RetailSimpleItemPrice + @",
                                                      Discount = " + param_Discount + @",
                                                      ExtraDiscount = " + param_ExtraDiscount + @",
                                                      TaxPrice = " + param_TaxPrice + @",
                                                      Atom_Taxation_ID = " + to_update_Atom_Taxation_ID.ToString() + @",
                                                      RetailSimpleItemPriceWithDiscount = " + param_RetailSimpleItemPriceWithDiscount + @"
                                                   where ID = " + Atom_Price_SimpleItem_ID.ToString();
                object ores = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_update_Atom_SimpleItem, lpar, ref ores, ref Err))
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
                LogFile.Error.Show("ERROR:Update_SelectedSimpleItem:FindRowIndex_In_dtDraft_Atom_SimpleItem FAILED!");
                return false;
            }
        }

        private int FindRowIndex_In_dtDraft_Atom_SimpleItem(long Atom_Price_SimpleItem_ID)
        {
            DataRow[] foundRows;
            foundRows = m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem.Select("ID=" + Atom_Price_SimpleItem_ID.ToString());
            if (foundRows.Count() > 0)
            {
                return m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem.Rows.IndexOf(foundRows[0]);
            }
            else
            {
                return -1;
            }
        }

        public bool Delete_SelectedSimpleItem(long Atom_Price_SimpleItem_ID, ref string Err)
        {
            string sql_delete_Atom_SimpleItem = @"delete from Atom_Price_SimpleItem
                                                   where ID = " + Atom_Price_SimpleItem_ID.ToString();
            object ores = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_delete_Atom_SimpleItem, null, ref ores, ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string SetWarrantyDurationText(short WarantyDurationType, int WarantyDuration)
        {
            string s = "Error:SetWarrantyDur:";
            switch (WarantyDurationType)
            {
                case 0:
                    if (WarantyDuration == 1)
                    {
                        s = WarantyDuration.ToString() + " leto";
                    }
                    else if (WarantyDuration == 2)
                    {
                        s = WarantyDuration.ToString() + " leti";
                    }
                    else if (WarantyDuration == 3)
                    {
                        s = WarantyDuration.ToString() + " leta";
                    }
                    else if (WarantyDuration == 4)
                    {
                        s = WarantyDuration.ToString() + " leta";
                    }
                    else if (WarantyDuration > 4)
                    {
                        s = WarantyDuration.ToString() + " let";
                    }
                    else
                    {
                        s = WarantyDuration.ToString() + " let";
                    }
                    break;

                case 1:
                    if (WarantyDuration == 1)
                    {
                        s = WarantyDuration.ToString() + " mesec";
                    }
                    else if (WarantyDuration == 2)
                    {
                        s = WarantyDuration.ToString() + " meseca";
                    }
                    else if (WarantyDuration == 3)
                    {
                        s = WarantyDuration.ToString() + " mesece";
                    }
                    else if (WarantyDuration == 4)
                    {
                        s = WarantyDuration.ToString() + " mesece";
                    }
                    else if (WarantyDuration > 4)
                    {
                        s = WarantyDuration.ToString() + " mesecev";
                    }
                    else
                    {
                        s = WarantyDuration.ToString() + " mesecev";
                    }
                    break;
            }
            return s;
        }


    }
}
