#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using DBConnectionControl40;
using LanguageControl;
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_InvoiceTable : UserControl
    {
        public enum eMode { All, Today, ThisWeek, LastWeek, ThisMonth, LastMonth, ThisYear, LastYear, TimeSpan };
        public delegate void delegate_SelectedInvoiceChanged(long Invoice_ID, bool bInitialise);
        public event delegate_SelectedInvoiceChanged SelectedInvoiceChanged;
        public Color ColorDraft;
        public Color ColorStorno;
        public Color ColorFurs_InvoiceConfirmed;
        public Color ColorFurs_SalesBookInvoiceConfirmed;
        public Color ColorFurs_SalesBookInvoiceNotConfirmed;

        public bool m_bInvoice = false;
        public string cond = null;

        public string ExtraCondition = null;
        public List<SQL_Parameter> lpar_ExtraCondition = null;
        public DateTime dtStartTime;
        public DateTime dtEndTime;
        public eMode Mode = eMode.All;

        public string sFromTo_Suffix = "";
        public DataTable dt_XInvoice = new DataTable();

        private usrc_Invoice.enum_Invoice enum_Invoice;
        private int iColIndex_ProformaInvoice_Draft = -1;
        private int iColIndex_ProformaInvoice_Invoice_Storno = -1;
        private int iColIndex_ProformaInvoice_FSI_SLO_Response_BarCodeValue = -1;
        private int iColIndex_ProformaInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = -1;

        public usrc_InvoiceTable()
        {
            InitializeComponent();
            ExtensionMethods.DoubleBuffered(this.dgvx_XInvoice, true);
            dtStartTime = DateTime.Now;
            dtEndTime = DateTime.Now;
            lbl_From_To.Text = lngRPM.s_AllData.s;
            lngRPM.s_Sum_All.Text(this.lbl_Sum_All);
            lngRPM.s_Sum_Tax.Text(this.lbl_Sum_Tax);
            lngRPM.s_Sum_WithoutTax.Text(this.lbl_Sum_WithoutTax);
            lngRPM.s_from.Text(this.lbl_From_To);
        }

        internal int Init(usrc_Invoice.enum_Invoice xenum_Invoice, bool bNew,bool bInitialise_usrc_Invoice,int iFinancialYear)
        {
            ColorDraft = Properties.Settings.Default.ColorDraft;
            ColorStorno = Properties.Settings.Default.ColorStorno;
            ColorFurs_InvoiceConfirmed = Properties.Settings.Default.ColorFurs_InvoiceConfirmed;
            ColorFurs_SalesBookInvoiceConfirmed = Properties.Settings.Default.ColorFurs_SalesBookInvoiceConfirmed;
            ColorFurs_SalesBookInvoiceNotConfirmed = Properties.Settings.Default.ColorFurs_SalesBookInvoiceNotConfirmed;

            int iRowsCount = -1;
            enum_Invoice = xenum_Invoice;
            switch (enum_Invoice)
            {
                case usrc_Invoice.enum_Invoice.Invoice:
                    this.dgvx_XInvoice.SelectionChanged -= new System.EventHandler(this.dgvx_XInvoice_SelectionChanged);
                    iRowsCount = Init_Invoice(true, bNew, iFinancialYear);
                    ShowOrEditSelectedRow(bInitialise_usrc_Invoice);
                    this.dgvx_XInvoice.SelectionChanged += new System.EventHandler(this.dgvx_XInvoice_SelectionChanged);
                    break;
                case usrc_Invoice.enum_Invoice.ProformaInvoice:
                    iRowsCount = Init_ProformaInvoice();
                    break;
            }
            return iRowsCount;
        }

        private int Init_ProformaInvoice()
        {
            int iRowsCount = -1;
            return iRowsCount;
        }

        private int Init_Invoice(bool bInvoice, bool bNew, int iFinancialYear)
        {
            m_bInvoice = bInvoice;
            int iRowsCount = -1;
            string s_JOURNAL_ProformaInvoice_Type_ID_InvoiceDraftTime = GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString();
            string s_JOURNAL_ProformaInvoice_Type_ID_InvoiceStornoTime = GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceStornoTime.ID.ToString();
            if (bInvoice)
            {
                cond = " where JOURNAL_ProformaInvoice_$_pinv_$_inv.ID is not null ";
            }
            else
            {
                cond = " where JOURNAL_ProformaInvoice_$_pinv_$_inv.ID is null ";
            }

            if (ExtraCondition!=null)
            {
                s_JOURNAL_ProformaInvoice_Type_ID_InvoiceDraftTime = GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.ID.ToString();
                s_JOURNAL_ProformaInvoice_Type_ID_InvoiceStornoTime = GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceStornoTime.ID.ToString();
                cond += " and " + ExtraCondition;
            }
            else
            {
                lpar_ExtraCondition = null;
            }

            if (iFinancialYear > 0)
            {
                cond += " and JOURNAL_ProformaInvoice_$_pinv.FinancialYear = " + iFinancialYear.ToString();
            }

            string sql = null;
            if (Program.b_FVI_SLO)
            {
/*
                CREATE VIEW JOURNAL_ProformaInvoice_VIEW AS
SELECT
  JOURNAL_ProformaInvoice.ID,
JOURNAL_ProformaInvoice_$_jpinvt.ID AS JOURNAL_ProformaInvoice_$_jpinvt_$$ID,
JOURNAL_ProformaInvoice_$_jpinvt.Name AS JOURNAL_ProformaInvoice_$_jpinvt_$$Name,
JOURNAL_ProformaInvoice_$_jpinvt.Description AS JOURNAL_ProformaInvoice_$_jpinvt_$$Description,
JOURNAL_ProformaInvoice_$_pinv.ID AS JOURNAL_ProformaInvoice_$_pinv_$$ID,
JOURNAL_ProformaInvoice_$_pinv.Draft AS JOURNAL_ProformaInvoice_$_pinv_$$Draft,
JOURNAL_ProformaInvoice_$_pinv.DraftNumber AS JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber,
JOURNAL_ProformaInvoice_$_pinv.FinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
JOURNAL_ProformaInvoice_$_pinv.NumberInFinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
JOURNAL_ProformaInvoice_$_pinv.NetSum AS JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
JOURNAL_ProformaInvoice_$_pinv.Discount AS JOURNAL_ProformaInvoice_$_pinv_$$Discount,
JOURNAL_ProformaInvoice_$_pinv.EndSum AS JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
JOURNAL_ProformaInvoice_$_pinv.TaxSum AS JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
JOURNAL_ProformaInvoice_$_pinv.GrossSum AS JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
JOURNAL_ProformaInvoice_$_pinv_$_acusper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Gender AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$Gender,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$DateOfBirth,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Tax_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$Tax_ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Registration_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$Registration_ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$Email,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper.StreetName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper.HouseNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper.City AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper.ZIP AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.Country AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.Country_ISO_3166_a2 AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a2,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.Country_ISO_3166_a3 AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a3,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.Country_ISO_3166_num AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_num,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper.State AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper_$$State,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.CardNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$CardNumber,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper.CardType AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper_$$CardType,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.Image_Hash AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg_$$Image_Hash,
JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.Image_Data AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg_$$Image_Data,
JOURNAL_ProformaInvoice_$_pinv_$_acusorg.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Name AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Name,
JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Tax_ID,
JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Registration_ID,
JOURNAL_ProformaInvoice_$_pinv.WarrantyExist AS JOURNAL_ProformaInvoice_$_pinv_$$WarrantyExist,
JOURNAL_ProformaInvoice_$_pinv.WarrantyConditions AS JOURNAL_ProformaInvoice_$_pinv_$$WarrantyConditions,
JOURNAL_ProformaInvoice_$_pinv.WarrantyDurationType AS JOURNAL_ProformaInvoice_$_pinv_$$WarrantyDurationType,
JOURNAL_ProformaInvoice_$_pinv.WarrantyDuration AS JOURNAL_ProformaInvoice_$_pinv_$$WarrantyDuration,
JOURNAL_ProformaInvoice_$_pinv.ProformaInvoiceDuration AS JOURNAL_ProformaInvoice_$_pinv_$$ProformaInvoiceDuration,
JOURNAL_ProformaInvoice_$_pinv.ProformaInvoiceDurationType AS JOURNAL_ProformaInvoice_$_pinv_$$ProformaInvoiceDurationType,
JOURNAL_ProformaInvoice_$_pinv_$_trmpay.ID AS JOURNAL_ProformaInvoice_$_pinv_$_trmpay_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_trmpay.Description AS JOURNAL_ProformaInvoice_$_pinv_$_trmpay_$$Description,
JOURNAL_ProformaInvoice_$_pinv_$_inv.ID AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_inv.PaymentDeadline AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$PaymentDeadline,
JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.ID AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$ID,
JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.PaymentType AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
JOURNAL_ProformaInvoice_$_pinv_$_inv.Paid AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
JOURNAL_ProformaInvoice_$_pinv_$_inv.Storno AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno,
JOURNAL_ProformaInvoice_$_pinv_$_inv.Invoice_Reference_ID AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Invoice_Reference_ID,
JOURNAL_ProformaInvoice_$_pinv_$_inv.Invoice_Reference_Type AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Invoice_Reference_Type,
  JOURNAL_ProformaInvoice.EventTime AS JOURNAL_ProformaInvoice_$$EventTime,
JOURNAL_ProformaInvoice_$_awperiod.ID AS JOURNAL_ProformaInvoice_$_awperiod_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$UserName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Gender AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$Gender,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.DateOfBirth AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$DateOfBirth,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Tax_ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$Tax_ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Registration_ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$Registration_ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper_$$GsmNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper_$$PhoneNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.Email AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper_$$Email,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper.StreetName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper_$$StreetName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper.HouseNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper.City AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper_$$City,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper.ZIP AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper_$$ZIP,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.Country AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper_$$Country,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.Country_ISO_3166_a2 AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a2,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.Country_ISO_3166_a3 AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_a3,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.Country_ISO_3166_num AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper_$$Country_ISO_3166_num,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper.State AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper_$$State,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.CardNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$$CardNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.CardType AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper_$$CardType,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.Image_Hash AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg_$$Image_Hash,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.Image_Data AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg_$$Image_Data,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Name,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.Tax_ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Tax_ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.Registration_ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg_$$Registration_ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg.StreetName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg_$$StreetName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg.HouseNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg_$$HouseNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg.City AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg_$$City,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg.ZIP AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg_$$ZIP,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.Country AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg_$$Country,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.Country_ISO_3166_a2 AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg_$$Country_ISO_3166_a2,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.Country_ISO_3166_a3 AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg_$$Country_ISO_3166_a3,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.Country_ISO_3166_num AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg_$$Country_ISO_3166_num,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg.State AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg_$$State,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.PhoneNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg_$$PhoneNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.FaxNumber AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg_$$FaxNumber,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.Email AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg_$$Email,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.HomePage AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg_$$HomePage,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.OrganisationTYPE AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt_$$OrganisationTYPE,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.BankName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$$BankName,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.TRR AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$$TRR,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.Image_Hash AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo_$$Image_Hash,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.Image_Data AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo_$$Image_Data,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.Description AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo_$$Description,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Job AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$Job,
JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Description AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$Description,
JOURNAL_ProformaInvoice_$_awperiod_$_awplace.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_awplace_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_awplace.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_awplace_$$Name,
JOURNAL_ProformaInvoice_$_awperiod_$_awplace.Description AS JOURNAL_ProformaInvoice_$_awperiod_$_awplace_$$Description,
JOURNAL_ProformaInvoice_$_awperiod_$_acomp.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_acomp_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_acomp.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_acomp_$$Name,
JOURNAL_ProformaInvoice_$_awperiod_$_acomp.UserName AS JOURNAL_ProformaInvoice_$_awperiod_$_acomp_$$UserName,
JOURNAL_ProformaInvoice_$_awperiod_$_acomp.IP_address AS JOURNAL_ProformaInvoice_$_awperiod_$_acomp_$$IP_address,
JOURNAL_ProformaInvoice_$_awperiod_$_acomp.MAC_address AS JOURNAL_ProformaInvoice_$_awperiod_$_acomp_$$MAC_address,
JOURNAL_ProformaInvoice_$_awperiod.LoginTime AS JOURNAL_ProformaInvoice_$_awperiod_$$LoginTime,
JOURNAL_ProformaInvoice_$_awperiod.LogoutTime AS JOURNAL_ProformaInvoice_$_awperiod_$$LogoutTime,
JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.ID AS JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt_$$ID,
JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt_$$Name,
JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.Description AS JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt_$$Description
FROM JOURNAL_ProformaInvoice
INNER JOIN JOURNAL_ProformaInvoice_Type JOURNAL_ProformaInvoice_$_jpinvt ON JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_$_jpinvt.ID
INNER JOIN ProformaInvoice JOURNAL_ProformaInvoice_$_pinv ON JOURNAL_ProformaInvoice.ProformaInvoice_ID = JOURNAL_ProformaInvoice_$_pinv.ID
LEFT JOIN Atom_Customer_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper.ID
LEFT JOIN Atom_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.ID
LEFT JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.ID
LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.ID
LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.ID
LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.ID
LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.ID
LEFT JOIN Atom_cAddress_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cAddress_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.ID
LEFT JOIN Atom_cStreetName_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cStreetName_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper.ID
LEFT JOIN Atom_cHouseNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cHouseNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper.ID
LEFT JOIN Atom_cCity_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cCity_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper.ID
LEFT JOIN Atom_cZIP_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cZIP_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper.ID
LEFT JOIN Atom_cCountry_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cCountry_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astper.ID
LEFT JOIN Atom_cState_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper.Atom_cState_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acouper.ID
LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper.ID
LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.ID
LEFT JOIN Atom_Customer_Org JOURNAL_ProformaInvoice_$_pinv_$_acusorg ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Org_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg.ID
LEFT JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg ON JOURNAL_ProformaInvoice_$_pinv_$_acusorg.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.ID
LEFT JOIN TermsOfPayment JOURNAL_ProformaInvoice_$_pinv_$_trmpay ON JOURNAL_ProformaInvoice_$_pinv.TermsOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_trmpay.ID
LEFT JOIN Invoice JOURNAL_ProformaInvoice_$_pinv_$_inv ON JOURNAL_ProformaInvoice_$_pinv.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv.ID
LEFT JOIN MethodOfPayment JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay ON JOURNAL_ProformaInvoice_$_pinv_$_inv.MethodOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.ID
INNER JOIN Atom_WorkPeriod JOURNAL_ProformaInvoice_$_awperiod ON JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = JOURNAL_ProformaInvoice_$_awperiod.ID
INNER JOIN Atom_myCompany_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper ON JOURNAL_ProformaInvoice_$_awperiod.Atom_myCompany_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper.ID
INNER JOIN Atom_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.ID
INNER JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
LEFT JOIN Atom_cAddress_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cAddress_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.ID
LEFT JOIN Atom_cStreetName_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cStreetName_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper.ID
LEFT JOIN Atom_cHouseNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cHouseNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper.ID
LEFT JOIN Atom_cCity_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cCity_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper.ID
LEFT JOIN Atom_cZIP_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cZIP_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper.ID
LEFT JOIN Atom_cCountry_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cCountry_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.ID
LEFT JOIN Atom_cState_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cState_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper.ID
LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
INNER JOIN Atom_Office JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.ID
INNER JOIN Atom_myCompany JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myCompany_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
INNER JOIN Atom_OrganisationData JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
INNER JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
LEFT JOIN Atom_cAddress_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_cAddress_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.ID
LEFT JOIN Atom_cStreetName_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cStreetName_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg.ID
LEFT JOIN Atom_cHouseNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cHouseNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg.ID
LEFT JOIN Atom_cCity_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cCity_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg.ID
LEFT JOIN Atom_cZIP_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cZIP_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg.ID
LEFT JOIN Atom_cCountry_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cCountry_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.ID
LEFT JOIN Atom_cState_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cState_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg.ID
LEFT JOIN cPhoneNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
LEFT JOIN cFaxNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
LEFT JOIN cEmail_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
LEFT JOIN cHomePage_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
LEFT JOIN cOrgTYPE JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
LEFT JOIN Atom_Logo JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
INNER JOIN Atom_WorkingPlace JOURNAL_ProformaInvoice_$_awperiod_$_awplace ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awplace.ID
INNER JOIN Atom_Computer JOURNAL_ProformaInvoice_$_awperiod_$_acomp ON JOURNAL_ProformaInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_ProformaInvoice_$_awperiod_$_acomp.ID
LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.ID
*/



                sql = @"SELECT
                    JOURNAL_ProformaInvoice_$_pinv.NumberInFinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                    JOURNAL_ProformaInvoice_$_pinv.GrossSum AS JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                    JOURNAL_ProformaInvoice.EventTime AS JOURNAL_ProformaInvoice_$$EventTime,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.PaymentType AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
                    JOURNAL_ProformaInvoice_$_pinv.NetSum AS JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                    JOURNAL_ProformaInvoice_$_pinv.TaxSum AS JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                    JOURNAL_ProformaInvoice_$_pinv.FinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                    JOURNAL_ProformaInvoice_$_pinv.Draft AS JOURNAL_ProformaInvoice_$_pinv_$$Draft,
                    JOURNAL_ProformaInvoice_$_pinv.DraftNumber AS JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$Email,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$DateOfBirth,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Name AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Name,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Tax_ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Registration_ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.Paid AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.Storno AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno,
                    JOURNAL_ProformaInvoice_$_pinv.Discount AS JOURNAL_ProformaInvoice_$_pinv_$$Discount,
                    JOURNAL_ProformaInvoice_$_pinv.EndSum AS JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$UserName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisres.BarCodeValue As JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi_$$BarCodeValue,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.InvoiceNumber AS JOURNAL_ProformaInvoice_$_pinv_$_iinv_$_fvisbi_$$InvoiceNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.SetNumber AS JOURNAL_ProformaInvoice_$_pinv_$_iinv_$_fvisbi_$$SetNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.SerialNumber AS JOURNAL_ProformaInvoice_$_pinv_$_iinv_$_fvisbi_$$SerialNumber,
                    JOURNAL_ProformaInvoice_$_pinv.ID AS JOURNAL_ProformaInvoice_$_pinv_$$ID, 
                    JOURNAL_ProformaInvoice_$_jpinvt.ID AS JOURNAL_ProformaInvoice_$_jpinvt_$$ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.ID AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.ID AS JOURNAL_ProformaInvoice_$_pinv_$_iinv_$_fvisbi_$$ID
                    FROM JOURNAL_ProformaInvoice
                    INNER JOIN JOURNAL_ProformaInvoice_Type JOURNAL_ProformaInvoice_$_jpinvt ON JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_$_jpinvt.ID
                    INNER JOIN ProformaInvoice JOURNAL_ProformaInvoice_$_pinv ON JOURNAL_ProformaInvoice.ProformaInvoice_ID = JOURNAL_ProformaInvoice_$_pinv.ID
                    LEFT JOIN Atom_Customer_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper.ID
                    LEFT JOIN Atom_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.ID
                    LEFT JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.ID
                    LEFT JOIN Atom_Customer_Org JOURNAL_ProformaInvoice_$_pinv_$_acusorg ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Org_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg.ID
                    LEFT JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg ON JOURNAL_ProformaInvoice_$_pinv_$_acusorg.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.ID
                    LEFT JOIN TermsOfPayment JOURNAL_ProformaInvoice_$_pinv_$_trmpay ON JOURNAL_ProformaInvoice_$_pinv.TermsOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_trmpay.ID
                    LEFT JOIN Invoice JOURNAL_ProformaInvoice_$_pinv_$_inv ON JOURNAL_ProformaInvoice_$_pinv.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv.ID
                    LEFT JOIN FVI_SLO_Response JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisres ON JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisres.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv.ID and JOURNAL_ProformaInvoice_$_pinv.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisres.Invoice_ID
                    LEFT JOIN FVI_SLO_SalesBookInvoice JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi ON JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv.ID and JOURNAL_ProformaInvoice_$_pinv.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi.Invoice_ID
                    LEFT JOIN MethodOfPayment JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay ON JOURNAL_ProformaInvoice_$_pinv_$_inv.MethodOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.ID
                    INNER JOIN Atom_WorkPeriod JOURNAL_ProformaInvoice_$_awperiod ON JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = JOURNAL_ProformaInvoice_$_awperiod.ID
                    INNER JOIN Atom_myCompany_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper ON JOURNAL_ProformaInvoice_$_awperiod.Atom_myCompany_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper.ID
                    INNER JOIN Atom_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.ID
                    INNER JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
                    INNER JOIN Atom_Office JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.ID
                    INNER JOIN Atom_myCompany JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myCompany_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
                    INNER JOIN Atom_OrganisationData JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
                    INNER JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                    LEFT JOIN cPhoneNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
                    LEFT JOIN cFaxNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
                    LEFT JOIN cEmail_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
                    LEFT JOIN cHomePage_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
                    LEFT JOIN cOrgTYPE JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
                    LEFT JOIN Atom_Logo JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
                    INNER JOIN Atom_WorkingPlace JOURNAL_ProformaInvoice_$_awperiod_$_awplace ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awplace.ID
                    INNER JOIN Atom_Computer JOURNAL_ProformaInvoice_$_awperiod_$_acomp ON JOURNAL_ProformaInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_ProformaInvoice_$_awperiod_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.ID
                    " + cond + " and ((JOURNAL_ProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_ProformaInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_ProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_ProformaInvoice_Type_ID_InvoiceStornoTime + ")) order by JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear desc,JOURNAL_ProformaInvoice_$_pinv_$$Draft desc, JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear desc, JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber desc";
            }
            else
            {
                sql = @"SELECT
                    JOURNAL_ProformaInvoice_$_pinv.FinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                    JOURNAL_ProformaInvoice_$_pinv.Draft AS JOURNAL_ProformaInvoice_$_pinv_$$Draft,
                    JOURNAL_ProformaInvoice_$_pinv.DraftNumber AS JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber,
                    JOURNAL_ProformaInvoice_$_pinv.NumberInFinancialYear AS JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                    JOURNAL_ProformaInvoice_$_pinv.GrossSum AS JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                    JOURNAL_ProformaInvoice.EventTime AS JOURNAL_ProformaInvoice_$$EventTime,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.PaymentType AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
                    JOURNAL_ProformaInvoice_$_pinv.NetSum AS JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                    JOURNAL_ProformaInvoice_$_pinv.TaxSum AS JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$Email,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$DateOfBirth,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Name AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Name,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Tax_ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Registration_ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.Paid AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.Storno AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno,
                    JOURNAL_ProformaInvoice_$_pinv.Discount AS JOURNAL_ProformaInvoice_$_pinv_$$Discount,
                    JOURNAL_ProformaInvoice_$_pinv.EndSum AS JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$UserName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_ProformaInvoice_$_pinv.ID AS JOURNAL_ProformaInvoice_$_pinv_$$ID, 
                    JOURNAL_ProformaInvoice_$_jpinvt.ID AS JOURNAL_ProformaInvoice_$_jpinvt_$$ID,
                    JOURNAL_ProformaInvoice_$_pinv_$_inv.ID AS JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID
                    FROM JOURNAL_ProformaInvoice
                    INNER JOIN JOURNAL_ProformaInvoice_Type JOURNAL_ProformaInvoice_$_jpinvt ON JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_$_jpinvt.ID
                    INNER JOIN ProformaInvoice JOURNAL_ProformaInvoice_$_pinv ON JOURNAL_ProformaInvoice.ProformaInvoice_ID = JOURNAL_ProformaInvoice_$_pinv.ID
                    LEFT JOIN Atom_Customer_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper.ID
                    LEFT JOIN Atom_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.ID
                    LEFT JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aperimg.ID
                    LEFT JOIN Atom_Customer_Org JOURNAL_ProformaInvoice_$_pinv_$_acusorg ON JOURNAL_ProformaInvoice_$_pinv.Atom_Customer_Org_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg.ID
                    LEFT JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg ON JOURNAL_ProformaInvoice_$_pinv_$_acusorg.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg.ID
                    LEFT JOIN TermsOfPayment JOURNAL_ProformaInvoice_$_pinv_$_trmpay ON JOURNAL_ProformaInvoice_$_pinv.TermsOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_trmpay.ID
                    LEFT JOIN Invoice JOURNAL_ProformaInvoice_$_pinv_$_inv ON JOURNAL_ProformaInvoice_$_pinv.Invoice_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv.ID
                    LEFT JOIN MethodOfPayment JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay ON JOURNAL_ProformaInvoice_$_pinv_$_inv.MethodOfPayment_ID = JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay.ID
                    INNER JOIN Atom_WorkPeriod JOURNAL_ProformaInvoice_$_awperiod ON JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = JOURNAL_ProformaInvoice_$_awperiod.ID
                    INNER JOIN Atom_myCompany_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper ON JOURNAL_ProformaInvoice_$_awperiod.Atom_myCompany_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper.ID
                    INNER JOIN Atom_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.ID
                    INNER JOIN Atom_cFirstName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
                    INNER JOIN Atom_Office JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.ID
                    INNER JOIN Atom_myCompany JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myCompany_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
                    INNER JOIN Atom_OrganisationData JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
                    INNER JOIN Atom_Organisation JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                    LEFT JOIN cPhoneNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
                    LEFT JOIN cFaxNumber_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
                    LEFT JOIN cEmail_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
                    LEFT JOIN cHomePage_Org JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
                    LEFT JOIN cOrgTYPE JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
                    LEFT JOIN Atom_Logo JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
                    INNER JOIN Atom_WorkingPlace JOURNAL_ProformaInvoice_$_awperiod_$_awplace ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awplace.ID
                    INNER JOIN Atom_Computer JOURNAL_ProformaInvoice_$_awperiod_$_acomp ON JOURNAL_ProformaInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_ProformaInvoice_$_awperiod_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt ON JOURNAL_ProformaInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_ProformaInvoice_$_awperiod_$_awperiodt.ID
                    " + cond + " and ((JOURNAL_ProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_ProformaInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_ProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_ProformaInvoice_Type_ID_InvoiceStornoTime + ")) order by JOURNAL_ProformaInvoice_$_pinv.FinancialYear desc,JOURNAL_ProformaInvoice_$_pinv_$$Draft desc, JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear desc, JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber desc";
            }
            int iCurrentSelectedRow = -1;
            if (!bNew)
            {
                DataGridViewSelectedRowCollection dgvxc = dgvx_XInvoice.SelectedRows;
                if (dgvxc.Count>0)
                {
                    DataGridViewRow dgvr = dgvxc[0];
                    iCurrentSelectedRow = dgvx_XInvoice.Rows.IndexOf(dgvr);
                }
            }
            //this.dgvx_XInvoice.SelectionChanged -= new System.EventHandler(this.dgvx_XInvoice_SelectionChanged); // remove handler
            dt_XInvoice.Clear();
            dt_XInvoice.Columns.Clear();
            string Err = null;
            iColIndex_ProformaInvoice_Draft = -1;
            iColIndex_ProformaInvoice_Invoice_Storno = -1;
            bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XInvoice, sql, lpar_ExtraCondition, ref Err);
            if (bRes)
            {
                dgvx_XInvoice.DataSource = dt_XInvoice;
                iColIndex_ProformaInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
                iColIndex_ProformaInvoice_Invoice_Storno = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno");
                if (Program.b_FVI_SLO)
                {
                    iColIndex_ProformaInvoice_FSI_SLO_Response_BarCodeValue = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi_$$BarCodeValue"); ;
                    iColIndex_ProformaInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_iinv_$_fvisbi_$$InvoiceNumber"); ;
                }


                SetLabels();
                //this.dgvx_XInvoice.SelectionChanged += new System.EventHandler(this.dgvx_XInvoice_SelectionChanged); // Add Handler
                SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(ProformaInvoice)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                dgvx_XInvoice.Columns["JOURNAL_ProformaInvoice_$_pinv_$_inv_$_fvisbi_$$BarCodeValue"].HeaderText = lngRPM.s_FURS_BarCode.s;
                iRowsCount = dt_XInvoice.Rows.Count;
                if (!bNew)
                {
                    if (iRowsCount > 0)
                    {
                        if (iCurrentSelectedRow >= 0)
                        {
                            dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;


                        }
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice Err=" + Err);
            }
            return iRowsCount;
        }

        private decimal Sum(string ColumnName)
        {
            decimal sum = 0;
            int iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
            int iCol = dt_XInvoice.Columns.IndexOf(ColumnName);
            int iCount = dt_XInvoice.Rows.Count;
            int i = 0;
            for (i=0;i<iCount;i++)
            {
                if ((bool)dt_XInvoice.Rows[i][iColDraft])
                {
                    continue;
                }
                else
                { 
                    sum += (decimal)dt_XInvoice.Rows[i][iCol];
                }
            }
            return sum;
        }

        private void SumPayments(SumPaymentList xSumPaymentList)
        {

            int iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
            int iCol = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
            int iColPayment = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType");
            
            int iCount = dt_XInvoice.Rows.Count;
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                if ((bool)dt_XInvoice.Rows[i][iColDraft])
                {
                    continue;
                }
                else
                {
                    if (dt_XInvoice.Rows[i][iColPayment] is string)
                    {
                        xSumPaymentList.Add((decimal)dt_XInvoice.Rows[i][iCol], (string)dt_XInvoice.Rows[i][iColPayment]);
                    }
                }
            }
        }

        private void SetLabels()
        {
            if (dt_XInvoice.Rows.Count>0)
            { 
                string currency_symbol = GlobalData.BaseCurrency.Symbol;
                SumPaymentList xSumPaymentList = new SumPaymentList();
                SumPayments(xSumPaymentList);
                if (xSumPaymentList.SumPayment_List.Count > 0)
                {
                    lbl_Payment1.Text = xSumPaymentList.SumPayment_List[0].PaymentType + " = " + xSumPaymentList.SumPayment_List[0].Sum.ToString() + " " + currency_symbol;
                }
                if (xSumPaymentList.SumPayment_List.Count > 1)
                {
                    lbl_Payment2.Text = xSumPaymentList.SumPayment_List[1].PaymentType + " = " + xSumPaymentList.SumPayment_List[1].Sum.ToString() + " " + currency_symbol;
                }

                decimal gross_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
                decimal net_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$NetSum");
                decimal tax_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$TaxSum");
                lbl_Sum_All.Text = lngRPM.s_Sum_All.s + gross_sum.ToString() + " " + currency_symbol;
                lbl_Sum_Tax.Text = lngRPM.s_Sum_Tax.s + tax_sum.ToString() + " " + currency_symbol; ;
                lbl_Sum_WithoutTax.Text = lngRPM.s_Sum_WithoutTax.s + net_sum.ToString() + " " + currency_symbol; 

            }
            else
            {
                lbl_Sum_All.Text = "";
                lbl_Sum_Tax.Text = "";
                lbl_Sum_WithoutTax.Text = "";
                lbl_Payment2.Text = "";
                lbl_Payment1.Text = "";

            }


        }

        private void ShowOrEditSelectedRow(bool bInitialise)
        {
            if (SelectedInvoiceChanged!=null)
            { 
                DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_XInvoice.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                    if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_ProformaInvoice_$_pinv_$$ID"].Value is long)
                    {
                        long Identity = (long)dgvCellCollection[0].OwningRow.Cells["JOURNAL_ProformaInvoice_$_pinv_$$ID"].Value;
                        SelectedInvoiceChanged(Identity, bInitialise);
                        return;
                    }
                }
                SelectedInvoiceChanged(-1, bInitialise);
            }
        }

        private void dgvx_XInvoice_SelectionChanged(object sender, EventArgs e)
        {
            ShowOrEditSelectedRow(false);
        }

        private void btn_TimeSpan_Click(object sender, EventArgs e)
        {
            Form_Select_TimeSpan frm_timespan = new Form_Select_TimeSpan(this);
            if (frm_timespan.ShowDialog()== DialogResult.OK)
            {
                Program.Cursor_Wait();
                Init(enum_Invoice, true,false, Properties.Settings.Default.FinancialYear);
                Program.Cursor_Arrow();
            }
        }


        internal void SetMode(eMode eMode, string sText)
        {
            Mode = eMode;
            lbl_From_To.Text = sText;
        }

        private string sTimeSpan()
        {
            return " " + lngRPM.s_from.s + " " + sDate(dtStartTime) + " " + lngRPM.s_to.s +" "+ sDate(DayMinus(dtEndTime)) ;
        }

        private string sTimeSpan_Suffix()
        {
            return "_"+sDate_Suffix(dtStartTime) + "__" + sDate_Suffix(DayMinus(dtEndTime));
        }

        private DateTime DayMinus(DateTime date)
        {
            DateTime dt = date.AddDays(-1);
            return dt;
        }

        private string sDate(DateTime date)
        {
            return date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString();
        }

        private string sDate_Suffix(DateTime date)
        {
            return "_"+ date.Day.ToString() + "_" + date.Month.ToString() + "_" + date.Year.ToString();
        }

        private void SetTimeSpanParam_Ex(DateTime xdtStartTime,DateTime xdtEndTime)
        {
            string sparam1 = "@par_ProformaInvoiceTime_Start";
            string sparam2 = "@par_ProformaInvoiceTime_End";
            dtStartTime = xdtStartTime;
            dtEndTime = xdtEndTime;
            lpar_ExtraCondition = null;
            lpar_ExtraCondition = new List<DBConnectionControl40.SQL_Parameter>();
            SQL_Parameter par1 = new SQL_Parameter(sparam1, SQL_Parameter.eSQL_Parameter.Datetime, false, dtStartTime);
            lpar_ExtraCondition.Add(par1);
            SQL_Parameter par2 = new SQL_Parameter(sparam2, SQL_Parameter.eSQL_Parameter.Datetime, false, dtEndTime);
            lpar_ExtraCondition.Add(par2);
            ExtraCondition = " (JOURNAL_ProformaInvoice_$$EventTime >= " + sparam1 + ") and ( JOURNAL_ProformaInvoice_$$EventTime < " + sparam2 + ") ";

        }
        internal void SetTimeSpanParam(eMode eMode, DateTime xdtStartTime, DateTime xdtEndTime)
        {
            Mode = eMode;
            if (eMode == usrc_InvoiceTable.eMode.All)
            {
                lbl_From_To.Text = lngRPM.s_ShowAll.s;
                sFromTo_Suffix = "";
                ExtraCondition = null;
                lpar_ExtraCondition = null;
            }
            else
            {
                SetTimeSpanParam_Ex(xdtStartTime, xdtEndTime);
                switch (eMode)
                {
                    case usrc_InvoiceTable.eMode.Today:
                        lbl_From_To.Text = lngRPM.s_Today.s + " " + sDate(dtStartTime);
                        sFromTo_Suffix = sDate_Suffix(dtStartTime);
                        break;
                    case usrc_InvoiceTable.eMode.ThisWeek:
                        lbl_From_To.Text = lngRPM.s_ThisWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;

                    case usrc_InvoiceTable.eMode.LastWeek:
                        lbl_From_To.Text = lngRPM.s_LastWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.ThisMonth:
                        lbl_From_To.Text = lngRPM.s_ThisMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.LastMonth:
                        lbl_From_To.Text = lngRPM.s_LastMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.ThisYear:
                        lbl_From_To.Text = lngRPM.s_ThisYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.LastYear:
                        lbl_From_To.Text = lngRPM.s_LastYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.TimeSpan:
                        lbl_From_To.Text = lngRPM.s_TimeSpan.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                }
            }
        }

        private void dgvx_XInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex>=0)
            {
                if ((iColIndex_ProformaInvoice_Draft >= 0) && (iColIndex_ProformaInvoice_Invoice_Storno>=0))
                {
                    if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_Draft])
                    {
                        e.CellStyle.BackColor = ColorDraft;
                    }
                    else if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_Invoice_Storno])
                    {
                        e.CellStyle.BackColor = ColorStorno;
                    }
                    else
                    {
                        if (Program.b_FVI_SLO)
                        {
                            if ((dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_FSI_SLO_Response_BarCodeValue] is string) && (dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber] is string))
                            {
                                e.CellStyle.BackColor = ColorFurs_SalesBookInvoiceConfirmed;
                            }
                            else if (dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_FSI_SLO_Response_BarCodeValue] is string)
                            {
                                e.CellStyle.BackColor = ColorFurs_InvoiceConfirmed;
                            }
                            else if (dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber] is string)
                            {
                                e.CellStyle.BackColor = ColorFurs_SalesBookInvoiceNotConfirmed;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            Form_PrintReport frm_print = new Form_PrintReport(this);
            frm_print.ShowDialog();
        }
    }
}
