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
using TangentaTableClass;
using CodeTables;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DBConnectionControl40;

namespace TangentaDB
{
    public class ShopABC
    {
        TangentaTableClass.SQL_Database_Tables_Definition td = null;
        DBTablesAndColumnNames DBtcn = null;

        public xTaxationList m_xTaxationList = null;

        public xUnitList m_xUnitList = null;

        public CurrentInvoice m_CurrentInvoice = null;

        private string m_DocInvoice = "DocInvoice";

        public string DocInvoice
        {
            get { return m_DocInvoice; }
            set
            {
                m_DocInvoice = value;
            }
        }

        public bool IsDocInvoice
        {
            get
            { return fs.IsDocInvoice(DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
               return fs.IsDocProformaInvoice(DocInvoice);
            }
        }

        public bool Get(bool bDraft, long ID, ref string Err)
        {
            //SQLTable tbl_Invoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Invoice));
            //SQLTable tbl_DocInvoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice));
            //SQLTable tbl_Atom_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation_Person));
            //SQLTable tbl_Atom_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));

            string cond = null;
            string sql_GetDraft = null;
            if (IsDocInvoice)
            {
                if (ID >= 0)
                {
                    cond = " where  JOURNAL_DocInvoice_$_dinv.ID = " + ID.ToString();
                }
                else if (bDraft)
                {
                    cond = " where JOURNAL_DocInvoice_$_dinv.Draft = 1 ";
                }
                else
                {
                    cond = "";
                }
                sql_GetDraft = @"Select
                        JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                        JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                        JOURNAL_DocInvoice_$_awperiod_$_amcper.Job AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$$Job,
                        JOURNAL_DocInvoice_$_awperiod_$_amcper.Description AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$$Description,
                        JOURNAL_DocInvoice_$_dinv.ID AS JOURNAL_DocInvoice_$_dinv_$$ID,
                        JOURNAL_DocInvoice_$_awperiod_$_amcper.ID AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$$ID,
                        JOURNAL_DocInvoice_$_dinv.FinancialYear AS JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                        JOURNAL_DocInvoice_$_dinv.NumberInFinancialYear AS JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                        JOURNAL_DocInvoice_$_dinv.Draft AS JOURNAL_DocInvoice_$_dinv_$$Draft,
                        JOURNAL_DocInvoice_$_dinv.DraftNumber AS JOURNAL_DocInvoice_$_dinv_$$DraftNumber,
                        JOURNAL_DocInvoice_$_dinv_$_acusper.ID AS JOURNAL_DocInvoice_$_dinv_$_acusper_$$ID,
                        JOURNAL_DocInvoice_$_dinv_$_acusorg.ID AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$$ID,
                        JOURNAL_DocInvoice_$_dinv.NetSum AS JOURNAL_DocInvoice_$_dinv_$$NetSum,
                        JOURNAL_DocInvoice_$_dinv.Discount AS JOURNAL_DocInvoice_$_dinv_$$Discount,
                        JOURNAL_DocInvoice_$_dinv.EndSum AS JOURNAL_DocInvoice_$_dinv_$$EndSum,
                        JOURNAL_DocInvoice_$_dinv.TaxSum AS JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                        JOURNAL_DocInvoice_$_dinv.GrossSum AS JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                        acur.ID as Atom_Currency_ID,
                        acur.Name as CurrencyName,
                        acur.Abbreviation as CurrencyAbbreviation,
                        acur.Symbol as CurrencySymbol,
                        acur.CurrencyCode as CurrencyCode,
                        acur.DecimalPlaces as CurrencyDecimalPlaces,
                        diao.Atom_Warranty_ID,
                        aw.WarrantyDurationType,
                        aw.WarrantyDuration,
                        aw.WarrantyConditions,
                        diao.TermsOfPayment_ID,
                        diao.PaymentDeadline,
                        mtpdi.ID as MethodOfPayment_DI_ID,
                        pt.Identification as PaymentType_Identification,
                        JOURNAL_DocInvoice_$_dinv.Paid AS JOURNAL_DocInvoice_$_dinv_$$Paid,
                        JOURNAL_DocInvoice_$_dinv.Storno AS JOURNAL_DocInvoice_$_dinv_$$Storno,
                        JOURNAL_DocInvoice_$_dinv.Invoice_Reference_ID AS JOURNAL_DocInvoice_$_dinv_$$Invoice_Reference_ID,
                        JOURNAL_DocInvoice_$_dinv.Invoice_Reference_Type AS JOURNAL_DocInvoice_$_dinv_$$Invoice_Reference_Type
                        FROM JOURNAL_DocInvoice
                        INNER JOIN JOURNAL_DocInvoice_Type JOURNAL_DocInvoice_$_jpinvt ON JOURNAL_DocInvoice.JOURNAL_DocInvoice_Type_ID = JOURNAL_DocInvoice_$_jpinvt.ID
                        LEFT JOIN DocInvoice JOURNAL_DocInvoice_$_dinv ON JOURNAL_DocInvoice.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                        INNER JOIN Atom_Currency acur ON acur.ID = JOURNAL_DocInvoice_$_dinv.Atom_Currency_ID
                        LEFT JOIN Atom_WorkPeriod JOURNAL_DocInvoice_$_awperiod ON JOURNAL_DocInvoice.Atom_WorkPeriod_ID = JOURNAL_DocInvoice_$_awperiod.ID
                        LEFT JOIN Atom_myOrganisation_Person JOURNAL_DocInvoice_$_awperiod_$_amcper ON JOURNAL_DocInvoice_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper.ID
                        LEFT JOIN Atom_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_DocInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.ID
                        LEFT JOIN Atom_cFirstName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                        LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                        LEFT JOIN Atom_Customer_Person JOURNAL_DocInvoice_$_dinv_$_acusper ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper.ID
                        LEFT JOIN Atom_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper ON JOURNAL_DocInvoice_$_dinv_$_acusper.Atom_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.ID
                        LEFT JOIN Atom_cFirstName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.ID
                        LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.ID
                        LEFT JOIN Atom_Customer_Org JOURNAL_DocInvoice_$_dinv_$_acusorg ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Org_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg.ID
                        LEFT JOIN Atom_Organisation JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg ON JOURNAL_DocInvoice_$_dinv_$_acusorg.Atom_Organisation_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.ID
						left join DocInvoiceAddOn diao on diao.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                        left join TermsOfPayment topay on diao.TermsOfPayment_ID = topay.id
                        left join MethodOfPayment_DI mtpdi on diao.MethodOfPayment_DI_ID = mtpdi.id
                        left join PaymentType pt on mtpdi.PaymentType_ID = pt.ID
                        left join Atom_Warranty aw on diao.Atom_Warranty_ID = aw.ID
                        " + cond;

            }
            else if (IsDocProformaInvoice)
            {
                if (ID >= 0)
                {
                    cond = " where  JOURNAL_DocProformaInvoice_$_dpinv.ID = " + ID.ToString();
                }
                else if (bDraft)
                {
                    cond = " where JOURNAL_DocProformaInvoice_$_dpinv.Draft = 1 ";
                }
                else
                {
                    cond = "";
                }
                sql_GetDraft = @"Select
                        JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                        JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                        JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.Job AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$$Job,
                        JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.Description AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$$Description,
                        JOURNAL_DocProformaInvoice_$_dpinv.ID AS JOURNAL_DocProformaInvoice_$_dpinv_$$ID,
                        JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.ID AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$$ID,
                        JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$FinancialYear,
                        JOURNAL_DocProformaInvoice_$_dpinv.NumberInFinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear,
                        JOURNAL_DocProformaInvoice_$_dpinv.Draft AS JOURNAL_DocProformaInvoice_$_dpinv_$$Draft,
                        JOURNAL_DocProformaInvoice_$_dpinv.DraftNumber AS JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber,
                        JOURNAL_DocProformaInvoice_$_dpinv_$_acusper.ID AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$$ID,
                        JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg.ID AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$$ID,
                        JOURNAL_DocProformaInvoice_$_dpinv.NetSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$NetSum,
                        JOURNAL_DocProformaInvoice_$_dpinv.Discount AS JOURNAL_DocProformaInvoice_$_dpinv_$$Discount,
                        JOURNAL_DocProformaInvoice_$_dpinv.EndSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$EndSum,
                        JOURNAL_DocProformaInvoice_$_dpinv.TaxSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$TaxSum,
                        JOURNAL_DocProformaInvoice_$_dpinv.GrossSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum,
                        acur.ID as Atom_Currency_ID,
                        acur.Name as CurrencyName,
                        acur.Abbreviation as CurrencyAbbreviation,
                        acur.Symbol as CurrencySymbol,
                        acur.CurrencyCode as CurrencyCode,
                        acur.DecimalPlaces as CurrencyDecimalPlaces,
                        dpiao.Atom_Warranty_ID as Atom_Warranty_ID,
                        aw.WarrantyDurationType as WarrantyDurationType,
                        aw.WarrantyDuration as WarrantyDuration,
                        aw.WarrantyConditions as WarrantyConditions,
                        dpiao.TermsOfPayment_ID as TermsOfPayment_ID,
                        topay.Description as TermsOfPayment_Description,
                        dpiao.DocDuration as DocDuration,
                        dpiao.DocDurationType as DocDurationType
                        FROM JOURNAL_DocProformaInvoice
                        INNER JOIN JOURNAL_DocProformaInvoice_Type JOURNAL_DocProformaInvoice_$_jdpinvt ON JOURNAL_DocProformaInvoice.JOURNAL_DocProformaInvoice_Type_ID = JOURNAL_DocProformaInvoice_$_jdpinvt.ID
                        INNER JOIN DocProformaInvoice JOURNAL_DocProformaInvoice_$_dpinv ON JOURNAL_DocProformaInvoice.DocProformaInvoice_ID = JOURNAL_DocProformaInvoice_$_dpinv.ID
                        INNER JOIN Atom_Currency acur ON acur.ID = JOURNAL_DocProformaInvoice_$_dpinv.Atom_Currency_ID
                        INNER JOIN Atom_WorkPeriod JOURNAL_DocProformaInvoice_$_awperiod ON JOURNAL_DocProformaInvoice.Atom_WorkPeriod_ID = JOURNAL_DocProformaInvoice_$_awperiod.ID
                        INNER JOIN Atom_myOrganisation_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.ID
                        INNER JOIN Atom_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.ID
                        INNER JOIN Atom_cFirstName JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                        LEFT JOIN Atom_cLastName JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                        LEFT JOIN Atom_Customer_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper ON JOURNAL_DocProformaInvoice_$_dpinv.Atom_Customer_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper.ID
                        LEFT JOIN Atom_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper.Atom_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.ID
                        LEFT JOIN Atom_cFirstName JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn.ID
                        LEFT JOIN Atom_cLastName JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln.ID
                        LEFT JOIN Atom_Customer_Org JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg ON JOURNAL_DocProformaInvoice_$_dpinv.Atom_Customer_Org_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg.ID
                        LEFT JOIN Atom_Organisation JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg.Atom_Organisation_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg.ID
                        left join DocProformaInvoiceAddOn dpiao on dpiao.DocProformaInvoice_ID = JOURNAL_DocProformaInvoice_$_dpinv.ID
                        left join TermsOfPayment topay on dpiao.TermsOfPayment_ID = topay.ID
                        left join Atom_Warranty aw on dpiao.Atom_Warranty_ID = aw.ID
                        " + cond;
            }
            else
            {
                Err="ERROR:ShpaABC.cs:ShopABC:Get:Error " + this.DocInvoice + " not implemented!";
                LogFile.Error.Show(Err);
                return false;
            }





            m_CurrentInvoice.dtCurrent_Invoice.Columns.Clear();
            m_CurrentInvoice.dtCurrent_Invoice.Clear();
            if (DBSync.DBSync.ReadDataTable(ref m_CurrentInvoice.dtCurrent_Invoice, sql_GetDraft, ref Err))
            {
                if (m_CurrentInvoice.dtCurrent_Invoice.Rows.Count > 0)
                {
                    if (IsDocInvoice)
                    {
                        m_CurrentInvoice.Exist = true;
                        m_CurrentInvoice.bDraft = (bool)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$Draft"];
                        m_CurrentInvoice.Doc_ID = (long)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$ID"];

                        m_CurrentInvoice.Atom_Currency_ID = (long)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["Atom_Currency_ID"];
                        if (m_CurrentInvoice.Currency==null)
                        {
                            m_CurrentInvoice.Currency = new xCurrency();
                        }

                        m_CurrentInvoice.Currency.ID = m_CurrentInvoice.Atom_Currency_ID;
                        m_CurrentInvoice.Currency.Name = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyName"];
                        m_CurrentInvoice.Currency.Abbreviation = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyAbbreviation"];
                        m_CurrentInvoice.Currency.Symbol = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencySymbol"];
                        m_CurrentInvoice.Currency.CurrencyCode = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyCode"];
                        m_CurrentInvoice.Currency.DecimalPlaces = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyDecimalPlaces"];

                        m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v = tf.set_long(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$Invoice_Reference_ID"]);
                        m_CurrentInvoice.TInvoice.Invoice_Reference_Type_v = tf.set_string(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$Invoice_Reference_Type"]);
                        m_CurrentInvoice.TInvoice.bStorno_v = tf.set_bool(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$Storno"]);

                        m_CurrentInvoice.FinancialYear = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$FinancialYear"];

                        object o_Atom_Customer_Person_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_acusper_$$ID"];
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
                        object o_Atom_Customer_Org_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_acusorg_$$ID"];
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
                        object oNumberInFinancialYear = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear"];
                        if (oNumberInFinancialYear is int)
                        {
                            m_CurrentInvoice.NumberInFinancialYear = (int)oNumberInFinancialYear;
                        }
                        else
                        {
                            m_CurrentInvoice.NumberInFinancialYear = -1;
                        }

                        m_CurrentInvoice.DraftNumber = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$DraftNumber"];

                        long xDocInvoice_ID = m_CurrentInvoice.Doc_ID;
                        if (m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v != null)
                        {
                            decimal_v dGrossSum_v = tf.set_decimal(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$GrossSum"]);
                            if (dGrossSum_v!=null)
                            {
                               if (dGrossSum_v.v < 0)
                                {
                                    xDocInvoice_ID = m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v.v;
                                }
                            }
                        }

                        if (Read_ShopB_Price_Item_Table(xDocInvoice_ID, ref m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem))
                        {
                            m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Clear();
                            if (m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice,xDocInvoice_ID, ref m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST))
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
                    else if (IsDocProformaInvoice)
                    {
                        m_CurrentInvoice.Exist = true;
                        m_CurrentInvoice.bDraft = (bool)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$$Draft"];
                        m_CurrentInvoice.Doc_ID = (long)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"];

                        m_CurrentInvoice.Currency.ID = m_CurrentInvoice.Atom_Currency_ID;
                        m_CurrentInvoice.Currency.Name = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyName"];
                        m_CurrentInvoice.Currency.Abbreviation = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyAbbreviation"];
                        m_CurrentInvoice.Currency.Symbol = (string)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencySymbol"];
                        m_CurrentInvoice.Currency.CurrencyCode = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyCode"];
                        m_CurrentInvoice.Currency.DecimalPlaces = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["CurrencyDecimalPlaces"];


                        m_CurrentInvoice.PInvoice.DocDuration_v = tf.set_long(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["DocDuration"]);
                        m_CurrentInvoice.PInvoice.DocDuration_Type_v = tf.set_int(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["DocDurationType"]);
                        m_CurrentInvoice.PInvoice.TermsOfPayment_ID_v = tf.set_long(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["TermsOfPayment_ID"]);
                        m_CurrentInvoice.PInvoice.TermsOfPayment_Description_v = tf.set_string(m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["TermsOfPayment_Description"]);

                        m_CurrentInvoice.FinancialYear = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$$FinancialYear"];

                        object o_Atom_Customer_Person_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$$ID"];
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
                        object o_Atom_Customer_Org_ID = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$$ID"];
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
                        object oNumberInFinancialYear = m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear"];
                        if (oNumberInFinancialYear is int)
                        {
                            m_CurrentInvoice.NumberInFinancialYear = (int)oNumberInFinancialYear;
                        }
                        else
                        {
                            m_CurrentInvoice.NumberInFinancialYear = -1;
                        }

                        m_CurrentInvoice.DraftNumber = (int)m_CurrentInvoice.dtCurrent_Invoice.Rows[0]["JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber"];

                        long xDocInvoice_ID = m_CurrentInvoice.Doc_ID;
                        if (m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v != null)
                        {
                            xDocInvoice_ID = m_CurrentInvoice.TInvoice.StornoDocInvoice_ID_v.v;
                        }

                        if (Read_ShopB_Price_Item_Table(xDocInvoice_ID, ref m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem))
                        {
                            m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Clear();
                            if (m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice,xDocInvoice_ID, ref m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST))
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
                        Err = "ERROR:ShopABC.cs:ShopABC:Get:Error DocInvoice of type " + DocInvoice + " not implemented";
                        LogFile.Error.Show(Err);
                        return false;
                    }
                }
                else
                {
                    m_CurrentInvoice.bDraft = false;
                    m_CurrentInvoice.Exist = false;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:GetDraft:select ... from " + DBtcn.stbl_DocInvoice_TableName + ":\r\nErr=" + Err);
                return false;
            }
        }


        public bool Read_ShopB_Price_Item_Table(long DocInvoice_ID, ref DataTable dt_DocInvoice_ShopB_Item)
        {
            string Err = null;
            string sql_select_DocInvoice_ShopB_Item = null;
            if (IsDocInvoice)
            {
                sql_select_DocInvoice_ShopB_Item = @"SELECT 
                                                DocInvoice_ShopB_Item.ID, 
                                                DocInvoice_ShopB_Item.DocInvoice_ID, 
                                                DocInvoice_ShopB_Item.Atom_PriceList_ID,
                                                DocInvoice_ShopB_Item.RetailSimpleItemPrice,
                                                DocInvoice_ShopB_Item.Discount,
                                                DocInvoice_ShopB_Item.ExtraDiscount,
                                                DocInvoice_ShopB_Item.TaxPrice, 
                                                DocInvoice_ShopB_Item.RetailSimpleItemPriceWithDiscount,
                                                DocInvoice_ShopB_Item.Atom_Taxation_ID,
                                                Atom_Taxation.Name As Atom_Taxation_Name,
                                                Atom_Taxation.Rate As Atom_Taxation_Rate,
                                                Atom_SimpleItem.SimpleItem_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Name_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Image_ID, 
                                                DocInvoice_ShopB_Item.iQuantity, 
                                                Atom_SimpleItem_Name.Name,
                                                Atom_SimpleItem_Name.Abbreviation, 
                                                Atom_PriceList_Name.Name AS Atom_PriceList_Name,
                                                Atom_Currency.Name AS Atom_Currency_Name,
                                                Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                                                Atom_Currency.Symbol AS Atom_Currency_Symbol,
                                                Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces 
                                                from DocInvoice_ShopB_Item
                                                inner join Atom_PriceList on DocInvoice_ShopB_Item.Atom_PriceList_ID = Atom_PriceList.ID
                                                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                                                inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                                                inner join Atom_Taxation on DocInvoice_ShopB_Item.Atom_Taxation_ID = Atom_Taxation.ID
                                                inner join Atom_SimpleItem on DocInvoice_ShopB_Item.Atom_SimpleItem_ID = Atom_SimpleItem.ID
                                                Inner Join DocInvoice on DocInvoice.ID = DocInvoice_ShopB_Item.DocInvoice_ID 
                                                Inner Join Atom_SimpleItem_Name on Atom_SimpleItem_Name.ID = Atom_SimpleItem.Atom_SimpleItem_Name_ID
                                                where DocInvoice_ShopB_Item.DocInvoice_ID = " + DocInvoice_ID.ToString();
            }
            else if (IsDocProformaInvoice)
            {
                sql_select_DocInvoice_ShopB_Item = @"SELECT 
                                                DocProformaInvoice_ShopB_Item.ID, 
                                                DocProformaInvoice_ShopB_Item.DocProformaInvoice_ID, 
                                                DocProformaInvoice_ShopB_Item.Atom_PriceList_ID,
                                                DocProformaInvoice_ShopB_Item.RetailSimpleItemPrice,
                                                DocProformaInvoice_ShopB_Item.Discount,
                                                DocProformaInvoice_ShopB_Item.ExtraDiscount,
                                                DocProformaInvoice_ShopB_Item.TaxPrice, 
                                                DocProformaInvoice_ShopB_Item.RetailSimpleItemPriceWithDiscount,
                                                DocProformaInvoice_ShopB_Item.Atom_Taxation_ID,
                                                Atom_Taxation.Name As Atom_Taxation_Name,
                                                Atom_Taxation.Rate As Atom_Taxation_Rate,
                                                Atom_SimpleItem.SimpleItem_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Name_ID, 
                                                Atom_SimpleItem.Atom_SimpleItem_Image_ID, 
                                                DocProformaInvoice_ShopB_Item.iQuantity, 
                                                Atom_SimpleItem_Name.Name,
                                                Atom_SimpleItem_Name.Abbreviation, 
                                                Atom_PriceList_Name.Name AS Atom_PriceList_Name,
                                                Atom_Currency.Name AS Atom_Currency_Name,
                                                Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                                                Atom_Currency.Symbol AS Atom_Currency_Symbol,
                                                Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces 
                                                from DocProformaInvoice_ShopB_Item
                                                inner join Atom_PriceList on DocProformaInvoice_ShopB_Item.Atom_PriceList_ID = Atom_PriceList.ID
                                                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                                                inner join Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                                                inner join Atom_Taxation on DocProformaInvoice_ShopB_Item.Atom_Taxation_ID = Atom_Taxation.ID
                                                inner join Atom_SimpleItem on DocProformaInvoice_ShopB_Item.Atom_SimpleItem_ID = Atom_SimpleItem.ID
                                                Inner Join DocProformaInvoice on DocProformaInvoice.ID = DocProformaInvoice_ShopB_Item.DocProformaInvoice_ID 
                                                Inner Join Atom_SimpleItem_Name on Atom_SimpleItem_Name.ID = Atom_SimpleItem.Atom_SimpleItem_Name_ID
                                                where DocProformaInvoice_ShopB_Item.DocProformaInvoice_ID = " + DocInvoice_ID.ToString();
            }
            else
            {
                Err = "ERROR:Read_Atom_SimpleItem_Table:DocInvoice =" + DocInvoice + " not implemented";
                LogFile.Error.Show(Err);
            }
            dt_DocInvoice_ShopB_Item.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice_ShopB_Item, sql_select_DocInvoice_ShopB_Item, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_Atom_SimpleItem_Table:select ... from Atom_SimpleItem:sql="+ sql_select_DocInvoice_ShopB_Item+"\r\n Err=" + Err);
                return false;
            }
        }

        public bool Copy_ShopB_Price_Item_Table(string xDocInvoice, long doc_ID, DataTable xdt_ShopB_Items)
        {
            foreach (DataRow dr in xdt_ShopB_Items.Rows)
            {
                string Atom_ShopB_Item_Name = tf._set_string(dr["Name"]);
                string Atom_ShopB_Item_Abbreviation = tf._set_string(dr["Abbreviation"]);
                string Atom_PriceList_Name = tf._set_string(dr["Atom_PriceList_Name"]);
                string_v Atom_Taxation_Name_v= tf.set_string(dr["Atom_Taxation_Name"]);
                decimal_v Atom_Taxation_Rate_v = tf.set_decimal(dr["Atom_Taxation_Rate"]);
                long Atom_PriceList_ID = tf._set_long(dr["Atom_PriceList_ID"]);
                bool_v ToOffer_v = null;
                long_v SimpleItem_Image_ID_v = null;
                Image SimpleItem_Image = null;
                string_v SimpleItem_Image_Hash = null;
                string_v SimpleItem_ParentGroup1_v = null;
                string_v SimpleItem_ParentGroup2_v = null;
                string_v SimpleItem_ParentGroup3_v = null;
                int_v Code_v = null;
                long_v SimpleItem_ID_v = null;
                if (f_SimpleItem.Get(Atom_ShopB_Item_Name,
                                     Atom_ShopB_Item_Abbreviation,
                                     ref ToOffer_v,
                                     ref SimpleItem_Image_ID_v,
                                     ref SimpleItem_Image,
                                     ref SimpleItem_Image_Hash,
                                     ref Code_v,
                                     ref SimpleItem_ParentGroup1_v,
                                     ref SimpleItem_ParentGroup2_v,
                                     ref SimpleItem_ParentGroup3_v,
                                     ref SimpleItem_ID_v
                                     ))
                {
                    if (ToOffer_v != null)
                    {
                        if (!ToOffer_v.v)
                        {
                            // ShopB Item is not in offer any more
                        }
                    }
                    long_v PriceList_ID_v = null;
                    bool_v Valid_v = null;
                    DateTime_v ValidFrom_v = null;
                    DateTime_v ValidTo_v = null;
                    DateTime_v CreationDate_v = null;
                    string_v Description_v = null;
                    long_v Currency_ID_v = null;
                    string_v CurrencyAbbreviation_v = null;
                    string_v CurrencyName_v = null;
                    string_v CurrencySymbol_v = null;
                    int_v CurrencyCode_v = null;
                    int_v CurrencyDecimalPlaces_v = null;
                    if (!f_PriceList.Get(Atom_PriceList_Name,
                                         ref PriceList_ID_v,
                                         ref Valid_v,
                                         ref ValidFrom_v,
                                         ref ValidTo_v,
                                         ref CreationDate_v,
                                         ref Description_v,
                                         ref Currency_ID_v,
                                         ref CurrencyAbbreviation_v,
                                         ref CurrencyName_v,
                                         ref CurrencySymbol_v,
                                         ref CurrencyCode_v,
                                         ref CurrencyDecimalPlaces_v
                                         ))
                    {
                        return false;
                    }
                    if (PriceList_ID_v!=null)
                    {
                        long_v Price_SimpleItem_ID_v = null;
                        decimal_v RetailSimpleItemPrice_v = null;
                        decimal_v Discount_v = null;
                        long_v Taxation_ID_v = null;
                        string_v Taxation_Name_v = null;
                        decimal_v Taxation_Rate_v = null;
                        if (f_Price_SimpleItem.Get(PriceList_ID_v.v,
                                               SimpleItem_ID_v.v,
                                               ref Price_SimpleItem_ID_v,
                                               ref RetailSimpleItemPrice_v,
                                               ref Discount_v,
                                               ref Taxation_ID_v,
                                               ref Taxation_Name_v,
                                               ref Taxation_Rate_v
                                               ))
                        {
                            if (Price_SimpleItem_ID_v!=null)
                            {
                                decimal RetailPriceWithDiscount = 0;
                                decimal RetailShopBItemPrice = 0;
                                decimal Discount = 0;
                                decimal ExtraDiscount = 0;
                                decimal Taxation_Rate = 0;
                                string Taxation_Name = null;
                                decimal Tax = 0;
                                int iCount = 1;
                                long Atom_Price_ShopBItem_ID = -1;
                                decimal PriceWithoutTax = 0;
                                if (f_Atom_Price_ShopBItem.Get(xDocInvoice,
                                                            Price_SimpleItem_ID_v.v,
                                                            doc_ID,
                                                            ref Atom_Price_ShopBItem_ID,
                                                            ref iCount,
                                                            ref RetailShopBItemPrice,
                                                            ref Discount,
                                                            ref ExtraDiscount,
                                                            ref Taxation_Rate,
                                                            ref Taxation_Name,
                                                            ref RetailPriceWithDiscount,
                                                            ref Tax,
                                                            ref PriceWithoutTax
                                                          ))
                                {
                                    continue;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }


        public bool Read_DocInvoice_Atom_Item_Stock_Table(long DocInvoice_ID, long Atom_Item_ID, ref DataTable dtDraft_DocInvoice_Atom_Item_Stock, string scond, ref string Err)
        {
            string sql_select_DocInvoice_Atom_Item_Stock = null;
            if (IsDocInvoice)
            {
                sql_select_DocInvoice_Atom_Item_Stock = @"
                SELECT 
                DocInvoice_ShopC_Item.dQuantity AS dQuantity,
                DocInvoice_ShopC_Item.ExtraDiscount AS ExtraDiscount,
                DocInvoice_ShopC_Item.RetailPriceWithDiscount AS RetailPriceWithDiscount,
                DocInvoice_ShopC_Item.TaxPrice AS  TaxPrice,
                DocInvoice_ShopC_Item.ID AS DocInvoice_ShopC_Item_ID,
                DocInvoice_ShopC_Item.DocInvoice_ID,
                DocInvoice_ShopC_Item.Stock_ID,
                DocInvoice_ShopC_Item.ExpiryDate,
                DocInvoice_ShopC_Item.Atom_Price_Item_ID,
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
                FROM DocInvoice_ShopC_Item
                INNER JOIN  Atom_Price_Item ON DocInvoice_ShopC_Item.Atom_Price_Item_ID = Atom_Price_Item.ID 
                INNER JOIN  Atom_Taxation ON Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID 
                INNER JOIN  Atom_PriceList ON Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID 
                INNER JOIN  Atom_Currency ON Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
                INNER JOIN  DocInvoice ON DocInvoice_ShopC_Item.DocInvoice_ID = DocInvoice.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Stock ON DocInvoice_ShopC_Item.Stock_ID = Stock.ID 
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
                where  (DocInvoice_ShopC_Item.DocInvoice_ID =  " + DocInvoice_ID.ToString() + ") and ( Atom_Item.ID = " + Atom_Item_ID.ToString() + ")" + scond;
            }
            else if (IsDocProformaInvoice)
            {
                sql_select_DocInvoice_Atom_Item_Stock = @"
                SELECT 
                DocProformaInvoice_ShopC_Item.dQuantity AS dQuantity,
                DocProformaInvoice_ShopC_Item.ExtraDiscount AS ExtraDiscount,
                DocProformaInvoice_ShopC_Item.RetailPriceWithDiscount AS RetailPriceWithDiscount,
                DocProformaInvoice_ShopC_Item.TaxPrice AS  TaxPrice,
                DocProformaInvoice_ShopC_Item.ID AS DocProformaInvoice_ShopC_Item_ID,
                DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID,
                DocProformaInvoice_ShopC_Item.Stock_ID,
                DocProformaInvoice_ShopC_Item.ExpiryDate,
                DocProformaInvoice_ShopC_Item.Atom_Price_Item_ID,
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
                FROM DocProformaInvoice_ShopC_Item
                INNER JOIN  Atom_Price_Item ON DocProformaInvoice_ShopC_Item.Atom_Price_Item_ID = Atom_Price_Item.ID 
                INNER JOIN  Atom_Taxation ON Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID 
                INNER JOIN  Atom_PriceList ON Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID 
                INNER JOIN  Atom_Currency ON Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID 
                INNER JOIN  DocProformaInvoice ON DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID = DocProformaInvoice.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Stock ON DocProformaInvoice_ShopC_Item.Stock_ID = Stock.ID 
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
                where  (DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID =  " + DocInvoice_ID.ToString() + ") and ( Atom_Item.ID = " + Atom_Item_ID.ToString() + ")" + scond;
            }
            else
            {
                Err = "DocInvoice = " + DocInvoice + " not implemented.";
                LogFile.Error.Show("ERROR:Read_DocInvoice_Atom_Item_Stock_Table:Err=" + Err);
                return false;
            }
            m_CurrentInvoice.dtCurrent_DocInvoice_ShopC_Item.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dtDraft_DocInvoice_Atom_Item_Stock, sql_select_DocInvoice_Atom_Item_Stock, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Read_DocInvoice_Atom_Item_Stock_Table:sql=" + sql_select_DocInvoice_Atom_Item_Stock + "\r\n Err=" + Err);
                return false;
            }
        }

        public ShopABC(DBTablesAndColumnNames xDBtcn)
        {
            m_CurrentInvoice = new CurrentInvoice(this, xDBtcn);
            td = DBSync.DBSync.DB_for_Tangenta.mt;
            DBtcn = xDBtcn;

        }

        public bool SetNewDraft_DocInvoice(int iFinancialYear, xCurrency xcurrency, long xAtom_Currency_ID, Control pParent, ref long DocInvoice_ID,
                                  long myOrganisation_Person_ID,
                                  string DocInvoice,
                                  string ElectronicDevice_Name,
                                  ref string Err)
        {
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ElectronicDevice_Name = "@par_ElectronicDevice_Name";
            SQL_Parameter par_ElectronicDevice_Name = new SQL_Parameter(spar_ElectronicDevice_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ElectronicDevice_Name);
            lpar.Add(par_ElectronicDevice_Name);

            int xDraftNumber = -1;
            int iLimit = 1;
            string sql = @"select " + DBSync.DBSync.sTop(iLimit) + "di.DraftNumber from "+DocInvoice+" di "+
                          "\r\n inner join JOURNAL_"+ DocInvoice + " jdi on jdi."+ DocInvoice+"_ID = di.ID "+
                          "\r\n inner join JOURNAL_" + DocInvoice + "_TYPE jdit on jdi.JOURNAL_" + DocInvoice + "_TYPE_ID = jdit.ID " +
                          "\r\n inner join Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID " +
                          "\r\n inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID " +
                          "\r\n where aed.Name = "+ spar_ElectronicDevice_Name + " order by aed.Name asc, DraftNumber desc " + DBSync.DBSync.sLimit(iLimit);
            if (!DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
            {
                LogFile.Error.Show("ERROR:TangentaDB:SetNewDraft:sql=" + sql + "\r\nErr=" + Err);
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
            sql = @"select " + DBSync.DBSync.sTop(iLimit) + "ID,DraftNumber from "+DocInvoice+" where FinancialYear = " + iFinancialYear.ToString() + " order by DraftNumber desc " + DBSync.DBSync.sLimit(iLimit);
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count == 1)
                {
                    //Draft already set
                    try
                    {
                        DocInvoice_ID = (long)dt.Rows[0]["ID"];
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:SetNewDraft: ID is not defined in "+DocInvoice+"! Exception =" + ex.Message);
                        return false;
                    }
                }

                long Atom_myOrganisation_Person_ID = -1;
                m_CurrentInvoice.FinancialYear = iFinancialYear;
                m_CurrentInvoice.DraftNumber = xDraftNumber;
                string_v office_name = null;
                if (f_Atom_myOrganisation_Person.Get(myOrganisation_Person_ID, ref Atom_myOrganisation_Person_ID, ref office_name))
                {
                    //**TODO
                    string sql_SetDraftDocInvoice = null;
                    if (IsDocInvoice)
                    {
                        sql_SetDraftDocInvoice = "insert into " + DocInvoice
                        + "("
                            + DBtcn.GetName(td.m_DocInvoice.FinancialYear.GetType()) + ","
                            + DBtcn.GetName(td.m_DocInvoice.DraftNumber.GetType()) + ","
                            + DBtcn.GetName(td.m_DocInvoice.Draft.GetType()) + ","
                            + "Atom_Currency_ID,"
                            + DBtcn.GetName(td.m_DocInvoice.Storno.GetType())
                        + @") values ( "
                            + m_CurrentInvoice.FinancialYear.ToString() + ","
                            + m_CurrentInvoice.DraftNumber.ToString() + ","
                            + "1,"
                            + xAtom_Currency_ID.ToString()+","
                            + "0"
                            + ")";
                    }
                    else if (IsDocProformaInvoice)
                    {
                        sql_SetDraftDocInvoice = "insert into " + DocInvoice
                        + "("
                            + DBtcn.GetName(td.m_DocInvoice.FinancialYear.GetType()) + ","
                            + DBtcn.GetName(td.m_DocInvoice.DraftNumber.GetType()) + ","
                            + DBtcn.GetName(td.m_DocInvoice.Draft.GetType())
                            + "Atom_Currency_ID"
                        + @") values ( "
                            + m_CurrentInvoice.FinancialYear.ToString() + ","
                            + m_CurrentInvoice.DraftNumber.ToString() + ","
                            + "1,"
                            + xAtom_Currency_ID.ToString()
                            + ")";
                    }
                    else
                    {
                        Err="ERROR:SetDraft:DocInvoice" + DocInvoice + " not implemented.";
                        LogFile.Error.Show(Err);
                        return false;
                    }
                    object objret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_SetDraftDocInvoice, null, ref this.m_CurrentInvoice.Doc_ID, ref objret, ref Err, DocInvoice))
                    {
                        long Journal_DocInvoice_ID = -1;
                        if (IsDocInvoice)
                        {
                            return f_Journal_DocInvoice.Write(this.m_CurrentInvoice.Doc_ID, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID, null, ref Journal_DocInvoice_ID);
                        }
                        else if (IsDocProformaInvoice)
                        {
                            DateTime_v dt_v = new DateTime_v(DateTime.Now);
                            return f_Journal_DocProformaInvoice.Write(this.m_CurrentInvoice.Doc_ID, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID, null, ref Journal_DocInvoice_ID);
                        }
                        else
                        {
                            Err = "ERROR:SetDraft:DocInvoice" + DocInvoice + " not implemented.";
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:SetDraft:insert into " + DocInvoice + ":\r\nErr=" + Err);
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
                LogFile.Error.Show("ERROR:TangentaDB:SetNewDraft:Err=" + Err);
                return false;
            }
        }



        private bool Find_Atom_myOrganisation_Person_ID(long Atom_myOrganisation_ID, ref long Atom_myOrganisation_Person_ID, ref string Err)
        {
            DataTable dt = new DataTable();
            string sql_find_Atom_myOrganisation_Person_ID = @"select
                                amoper.ID as Atom_myOrganisation_Person_ID
                                from Atom_myOrganisation_Person amoper
                                inner join myOrganisation_Person  moper on amoper.Job = moper.Job and amoper.Description = moper.Description
								inner join Atom_Person aper on aper.ID = amoper.Atom_Person_ID
								inner join Atom_cFirstName acfn on acfn.ID = aper.Atom_cFirstName_ID
								inner join Atom_cLastName acln on acln.ID = aper.Atom_cLastName_ID
								inner join Atom_Office ao on ao.ID = amoper.Atom_Office_ID
								inner join Office  o on o.ID = moper.Office_ID and o.Name = ao.Name
                                inner join Person  p on p.ID = moper.Person_ID and p.Gender = aper.Gender and p.DateOfBirth = aper.DateOfBirth and p.Tax_ID = aper.Tax_ID
								inner join cFirstName cfn on  cfn.ID = p.cFirstName_ID and acfn.FirstName = cfn.FirstName
								inner join cLastName cln on  cln.ID = p.cLastName_ID and acln.LastName = cln.LastName
                                where ao.Atom_myOrganisation_ID = " + Atom_myOrganisation_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql_find_Atom_myOrganisation_Person_ID, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_myOrganisation_Person_ID = (long)dt.Rows[0]["Atom_myOrganisation_Person_ID"];
                }
                else
                {
                    Atom_myOrganisation_Person_ID = -1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(@"ERROR:Find_Atom_myOrganisation_Person_ID: select
                                Atom_myOrganisation_Person.ID as Atom_myOrganisation_Person_ID
                                from Atom_myOrganisation_Person:\r\nErr=" + Err);
                return false;
            }
        }


        public bool Update_SelectedSimpleItem(DataRow dataRow, ref string Err)
        {
            Err = "NOT finished!";
            return false;
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


        public bool Update_SelectedSimpleItem(long DocInvoice_ShopB_Item_ID,
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
            int irow_Atom_SimpleItem = (int)FindRowIndex_In_dtDraft_Atom_SimpleItem(DocInvoice_ShopB_Item_ID);
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
                string sql_update_Atom_SimpleItem = null;
                if (IsDocInvoice)
                {
                    sql_update_Atom_SimpleItem = @"Update  DocInvoice_ShopB_Item
                                                  set iQuantity = " + iCount.ToString() + @",
                                                      RetailSimpleItemPrice = " + param_RetailSimpleItemPrice + @",
                                                      Discount = " + param_Discount + @",
                                                      ExtraDiscount = " + param_ExtraDiscount + @",
                                                      TaxPrice = " + param_TaxPrice + @",
                                                      Atom_Taxation_ID = " + to_update_Atom_Taxation_ID.ToString() + @",
                                                      RetailSimpleItemPriceWithDiscount = " + param_RetailSimpleItemPriceWithDiscount + @"
                                                   where ID = " + DocInvoice_ShopB_Item_ID.ToString();
                }
                else if (IsDocProformaInvoice)
                {
                    sql_update_Atom_SimpleItem = @"Update  DocProformaInvoice_ShopB_Item
                                                  set iQuantity = " + iCount.ToString() + @",
                                                      RetailSimpleItemPrice = " + param_RetailSimpleItemPrice + @",
                                                      Discount = " + param_Discount + @",
                                                      ExtraDiscount = " + param_ExtraDiscount + @",
                                                      TaxPrice = " + param_TaxPrice + @",
                                                      Atom_Taxation_ID = " + to_update_Atom_Taxation_ID.ToString() + @",
                                                      RetailSimpleItemPriceWithDiscount = " + param_RetailSimpleItemPriceWithDiscount + @"
                                                   where ID = " + DocInvoice_ShopB_Item_ID.ToString();
                }
                else
                {
                    Err="ERROR:Update_SelectedSimpleItem:FindRowIndex_In_dtDraft_Atom_SimpleItem:DocInvoice=" + DocInvoice + " not implemented";
                    LogFile.Error.Show(Err);
                    return false;
                }
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

        public void Set_dgv_selected_ShopB_Items_Columns(DataGridView dgv)
        {
            dgv.Columns[DBtcn.column_SelectedShopBItemName].HeaderText = lng.s_Shop_B.s;
            //this.dgv.Columns[DBtcn.column_SelectedShopBItemName].MinimumWidth = 120;
            //this.dgv.Columns[DBtcn.column_SelectedShopBItemName].Width = 120;
            dgv.Columns[DBtcn.column_SelectedShopBItemPriceWithoutTax].HeaderText = lng.s_PriceWithoutTax.s;
            dgv.Columns[DBtcn.column_SelectedShopBItemPriceTax].HeaderText = lng.s_Tax.s;
            dgv.Columns[DBtcn.column_SelectedShopBItemPrice].HeaderText = lng.s_EndPrice.s; 
            dgv.Columns[DBtcn.column_SelectedShopBItem_Count].HeaderText = lng.s_Quantity.s;
            dgv.Columns[DBtcn.column_SelectedShopBItemPriceDiscount].Visible = false;
            dgv.Columns[DBtcn.column_SelectedShopBItem_ShopBItem_ID].Visible = false;
            dgv.Columns[DBtcn.column_Selected_Atom_Price_ShopBItem_ID].Visible = false;
            //dgv.Columns[DBtcn.column_SelectedShopBItem_dt_ShopBItem_Index].Visible = false;
            dgv.Columns[DBtcn.column_SelectedShopBItem_ExtraDiscount].Visible = false;
            dgv.Columns[DBtcn.column_SelectedShopBItemRetailPricePerUnit].Visible = true;
            dgv.Columns[DBtcn.column_SelectedShopBItemRetailPricePerUnit].HeaderText = lng.s_RetailPricePerUnit.s;
            
            dgv.Columns[DBtcn.column_SelectedShopBItem_TaxName].Visible = false;
            dgv.Columns[DBtcn.column_SelectedShopBItem_TaxRate].Visible = false;
        }

        private int FindRowIndex_In_dtDraft_Atom_SimpleItem(long DocInvoice_ShopB_Item_ID)
        {
            DataRow[] foundRows;
            foundRows = m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem.Select("ID=" + DocInvoice_ShopB_Item_ID.ToString());
            if (foundRows.Count() > 0)
            {
                return m_CurrentInvoice.dtCurrent_Atom_Price_ShopBItem.Rows.IndexOf(foundRows[0]);
            }
            else
            {
                return -1;
            }
        }

        public bool Delete_SelectedSimpleItem(long DocInvoice_ShopB_Item_ID, ref string Err)
        {

            string sql_delete_Atom_SimpleItem = null;
            if (IsDocInvoice)
            {
                sql_delete_Atom_SimpleItem = @"delete from DocInvoice_ShopB_Item
                                                   where ID = " + DocInvoice_ShopB_Item_ID.ToString();
            }
            else if (IsDocProformaInvoice)
            {
                sql_delete_Atom_SimpleItem = @"delete from DocProformaInvoice_ShopB_Item
                                                   where ID = " + DocInvoice_ShopB_Item_ID.ToString();
            }
            else
            {
                Err = "ERROR:ShopABC.cs:ShopABC:Delete_SelectedSimpleItem:DocInvoice=" + DocInvoice + " not implemented.";
                return false;
            }
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
