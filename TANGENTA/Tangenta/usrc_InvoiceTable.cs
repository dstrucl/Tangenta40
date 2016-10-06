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
using TangentaDB;

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

        private int iCurrentSelectedRow = -1;

        private usrc_Invoice.enum_Invoice enum_Invoice;
        private int iColIndex_DocInvoice_Draft = -1;
        private int iColIndex_DocInvoice_Invoice_Storno = -1;
        private int iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue = -1;
        private int iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = -1;
        private bool bIgnoreChangeSelectionEvent = false;

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
            { return DocInvoice.Equals("DocInvoice"); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocInvoice.Equals("DocProformaInvoice"); }
        }

        public long Current_Doc_ID
        {
            get { if (iCurrentSelectedRow >= 0)
                  {
                    if (dt_XInvoice.Rows.Count > 0)
                    {
                        if (iCurrentSelectedRow < dt_XInvoice.Rows.Count)
                        {
                            long id = -1;
                            if (IsDocInvoice)
                            {
                                id = (long)dt_XInvoice.Rows[iCurrentSelectedRow]["JOURNAL_DocInvoice_$_dinv_$$ID"];
                            }
                            else if (IsDocProformaInvoice)
                            {
                                id = (long)dt_XInvoice.Rows[iCurrentSelectedRow]["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"];
                            }
                            return id;
                        }
                    }
                    }
                  return -1;
                }
        }


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

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            dgvx_XInvoice.ClearSelection();
            this.dgvx_XInvoice.SelectionChanged += this.dgvx_XInvoice_SelectionChanged;
            dgvx_XInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvx_XInvoice.MultiSelect = false;
            if (dt_XInvoice.Rows.Count>0)
            {
                if (iCurrentSelectedRow>=0)
                {
                    if (iCurrentSelectedRow< dt_XInvoice.Rows.Count)
                    {
                        dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                    }
                }
            }
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
                case usrc_Invoice.enum_Invoice.TaxInvoice:
                    iRowsCount = Init_Invoice(true, bNew, iFinancialYear);
                    if (bNew)
                    {
                        ShowOrEditSelectedRow(false);
                    }
                    break;
                case usrc_Invoice.enum_Invoice.ProformaInvoice:
                    iRowsCount = Init_DocInvoice();
                    break;
            }
            return iRowsCount;
        }

        private int Init_DocInvoice()
        {
            int iRowsCount = -1;
            return iRowsCount;
        }

        private int Init_Invoice(bool bInvoice, bool bNew, int iFinancialYear)
        {
            m_bInvoice = bInvoice;
            int iRowsCount = -1;
            string s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime = GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString();
            string s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime = GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID.ToString();
            string s_JOURNAL_DocInvoice_Type_ID_ProformaInvoiceDraftTime = GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString();

            if (IsDocInvoice)
            {
                if (bInvoice)
                {
                    cond = " where JOURNAL_DocInvoice_$_dinv.ID is not null ";
                }
                else
                {
                    cond = " where JOURNAL_DocInvoice_$_dinv.ID is null ";
                }
            }
            else if (IsDocProformaInvoice)
            {
                if (bInvoice)
                {
                    cond = " where JOURNAL_DocProformaInvoice_$_dpinv.ID is not null ";
                }
                else
                {
                    cond = " where JOURNAL_DocProformaInvoice_$_dpinv.ID is null ";
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice:DocInvoice=" + DocInvoice + " not implemented");
                return -1;
            }


            if (ExtraCondition!=null)
            {
                s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime = GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString();
                s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime = GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID.ToString();
                cond += " and " + ExtraCondition;
            }
            else
            {
                lpar_ExtraCondition = null;
            }

            if (iFinancialYear > 0)
            {
                if (IsDocInvoice)
                {
                    cond += " and JOURNAL_DocInvoice_$_dinv.FinancialYear = " + iFinancialYear.ToString();
                }
                else if (IsDocProformaInvoice)
                {
                    cond += " and JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear = " + iFinancialYear.ToString();
                }
            }

            string sql = null;
            if (IsDocInvoice)
            {
                if (Program.b_FVI_SLO)
                {
                    sql = @"SELECT
                    JOURNAL_DocInvoice_$_dinv.NumberInFinancialYear AS JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                    JOURNAL_DocInvoice_$_dinv.GrossSum AS JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                    JOURNAL_DocInvoice.EventTime AS JOURNAL_DocInvoice_$$EventTime,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_dinv_$_metopay.PaymentType AS JOURNAL_DocInvoice_$_dinv_$_metopay_$$PaymentType,
                    JOURNAL_DocInvoice_$_dinv.NetSum AS JOURNAL_DocInvoice_$_dinv_$$NetSum,
                    JOURNAL_DocInvoice_$_dinv.TaxSum AS JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                    JOURNAL_DocInvoice_$_dinv.FinancialYear AS JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                    JOURNAL_DocInvoice_$_dinv.Draft AS JOURNAL_DocInvoice_$_dinv_$$Draft,
                    JOURNAL_DocInvoice_$_dinv.DraftNumber AS JOURNAL_DocInvoice_$_dinv_$$DraftNumber,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper_$$Email,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$$DateOfBirth,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Name AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Name,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Tax_ID,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Registration_ID,
                    JOURNAL_DocInvoice_$_dinv.Paid AS JOURNAL_DocInvoice_$_dinv_$$Paid,
                    JOURNAL_DocInvoice_$_dinv.Storno AS JOURNAL_DocInvoice_$_dinv_$$Storno,
                    JOURNAL_DocInvoice_$_dinv.Discount AS JOURNAL_DocInvoice_$_dinv_$$Discount,
                    JOURNAL_DocInvoice_$_dinv.EndSum AS JOURNAL_DocInvoice_$_dinv_$$EndSum,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$$UserName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_DocInvoice_$_dinv_$_fvisres.BarCodeValue As JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.InvoiceNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$InvoiceNumber,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.SetNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$SetNumber,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.SerialNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$SerialNumber,
                    JOURNAL_DocInvoice_$_dinv.ID AS JOURNAL_DocInvoice_$_dinv_$$ID, 
                    JOURNAL_DocInvoice_$_jpinvt.ID AS JOURNAL_DocInvoice_$_jpinvt_$$ID,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.ID AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$ID
                    FROM JOURNAL_DocInvoice
                    INNER JOIN JOURNAL_DocInvoice_Type JOURNAL_DocInvoice_$_jpinvt ON JOURNAL_DocInvoice.JOURNAL_DocInvoice_Type_ID = JOURNAL_DocInvoice_$_jpinvt.ID
                    INNER JOIN DocInvoice JOURNAL_DocInvoice_$_dinv ON JOURNAL_DocInvoice.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                    LEFT JOIN Atom_Customer_Person JOURNAL_DocInvoice_$_dinv_$_acusper ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper.ID
                    LEFT JOIN Atom_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper ON JOURNAL_DocInvoice_$_dinv_$_acusper.Atom_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.ID
                    LEFT JOIN Atom_cFirstName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acardtper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aperimg ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aperimg.ID
                    LEFT JOIN Atom_Customer_Org JOURNAL_DocInvoice_$_dinv_$_acusorg ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Org_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg.ID
                    LEFT JOIN Atom_Organisation JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg ON JOURNAL_DocInvoice_$_dinv_$_acusorg.Atom_Organisation_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.ID
                    LEFT JOIN TermsOfPayment JOURNAL_DocInvoice_$_dinv_$_trmpay ON JOURNAL_DocInvoice_$_dinv.TermsOfPayment_ID = JOURNAL_DocInvoice_$_dinv_$_trmpay.ID
                    LEFT JOIN FVI_SLO_Response JOURNAL_DocInvoice_$_dinv_$_fvisres ON JOURNAL_DocInvoice_$_dinv_$_fvisres.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID 
                    LEFT JOIN FVI_SLO_SalesBookInvoice JOURNAL_DocInvoice_$_dinv_$_fvisbi ON JOURNAL_DocInvoice_$_dinv_$_fvisbi.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                    LEFT JOIN MethodOfPayment JOURNAL_DocInvoice_$_dinv_$_metopay ON JOURNAL_DocInvoice_$_dinv.MethodOfPayment_ID = JOURNAL_DocInvoice_$_dinv_$_metopay.ID
                    INNER JOIN Atom_WorkPeriod JOURNAL_DocInvoice_$_awperiod ON JOURNAL_DocInvoice.Atom_WorkPeriod_ID = JOURNAL_DocInvoice_$_awperiod.ID
                    INNER JOIN Atom_myOrganisation_Person JOURNAL_DocInvoice_$_awperiod_$_amcper ON JOURNAL_DocInvoice_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper.ID
                    INNER JOIN Atom_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_DocInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.ID
                    INNER JOIN Atom_cFirstName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
                    INNER JOIN Atom_Office JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_DocInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.ID
                    INNER JOIN Atom_myOrganisation JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myOrganisation_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
                    INNER JOIN Atom_OrganisationData JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
                    INNER JOIN Atom_Organisation JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                    LEFT JOIN cPhoneNumber_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
                    LEFT JOIN cFaxNumber_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
                    LEFT JOIN cEmail_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
                    LEFT JOIN cHomePage_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
                    LEFT JOIN cOrgTYPE JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
                    LEFT JOIN Atom_Logo JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
                    INNER JOIN Atom_WorkingPlace JOURNAL_DocInvoice_$_awperiod_$_awplace ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_DocInvoice_$_awperiod_$_awplace.ID
                    INNER JOIN Atom_Computer JOURNAL_DocInvoice_$_awperiod_$_acomp ON JOURNAL_DocInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_DocInvoice_$_awperiod_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_awperiodt.ID
                    " + cond + " and ((JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime + ")) order by JOURNAL_DocInvoice_$_dinv_$$FinancialYear desc,JOURNAL_DocInvoice_$_dinv_$$Draft desc, JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear desc, JOURNAL_DocInvoice_$_dinv_$$DraftNumber desc";
                }
                else
                {
                    sql = @"SELECT
                    JOURNAL_DocInvoice_$_dinv.FinancialYear AS JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                    JOURNAL_DocInvoice_$_dinv.Draft AS JOURNAL_DocInvoice_$_dinv_$$Draft,
                    JOURNAL_DocInvoice_$_dinv.DraftNumber AS JOURNAL_DocInvoice_$_dinv_$$DraftNumber,
                    JOURNAL_DocInvoice_$_dinv.NumberInFinancialYear AS JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                    JOURNAL_DocInvoice_$_dinv.GrossSum AS JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                    JOURNAL_DocInvoice.EventTime AS JOURNAL_DocInvoice_$$EventTime,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_dinv_$_metopay.PaymentType AS JOURNAL_DocInvoice_$_dinv_$_metopay_$$PaymentType,
                    JOURNAL_DocInvoice_$_dinv.NetSum AS JOURNAL_DocInvoice_$_dinv_$$NetSum,
                    JOURNAL_DocInvoice_$_dinv.TaxSum AS JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper_$$Email,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$$DateOfBirth,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Name AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Name,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Tax_ID,
                    JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg_$$Registration_ID,
                    JOURNAL_DocInvoice_$_dinv.Paid AS JOURNAL_DocInvoice_$_dinv_$$Paid,
                    JOURNAL_DocInvoice_$_dinv.Storno AS JOURNAL_DocInvoice_$_dinv_$$Storno,
                    JOURNAL_DocInvoice_$_dinv.Discount AS JOURNAL_DocInvoice_$_dinv_$$Discount,
                    JOURNAL_DocInvoice_$_dinv.EndSum AS JOURNAL_DocInvoice_$_dinv_$$EndSum,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$$UserName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_DocInvoice_$_dinv.ID AS JOURNAL_DocInvoice_$_dinv_$$ID, 
                    JOURNAL_DocInvoice_$_jpinvt.ID AS JOURNAL_DocInvoice_$_jpinvt_$$ID,
                    FROM JOURNAL_DocInvoice
                    INNER JOIN JOURNAL_DocInvoice_Type JOURNAL_DocInvoice_$_jpinvt ON JOURNAL_DocInvoice.JOURNAL_DocInvoice_Type_ID = JOURNAL_DocInvoice_$_jpinvt.ID
                    INNER JOIN DocInvoice JOURNAL_DocInvoice_$_dinv ON JOURNAL_DocInvoice.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                    LEFT JOIN Atom_Customer_Person JOURNAL_DocInvoice_$_dinv_$_acusper ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper.ID
                    LEFT JOIN Atom_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper ON JOURNAL_DocInvoice_$_dinv_$_acusper.Atom_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.ID
                    LEFT JOIN Atom_cFirstName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acardtper ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aperimg ON JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_aperimg.ID
                    LEFT JOIN Atom_Customer_Org JOURNAL_DocInvoice_$_dinv_$_acusorg ON JOURNAL_DocInvoice_$_dinv.Atom_Customer_Org_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg.ID
                    LEFT JOIN Atom_Organisation JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg ON JOURNAL_DocInvoice_$_dinv_$_acusorg.Atom_Organisation_ID = JOURNAL_DocInvoice_$_dinv_$_acusorg_$_aorg.ID
                    LEFT JOIN TermsOfPayment JOURNAL_DocInvoice_$_dinv_$_trmpay ON JOURNAL_DocInvoice_$_dinv.TermsOfPayment_ID = JOURNAL_DocInvoice_$_dinv_$_trmpay.ID
                    LEFT JOIN MethodOfPayment JOURNAL_DocInvoice_$_dinv_$_metopay ON JOURNAL_DocInvoice_$_dinv.MethodOfPayment_ID = JOURNAL_DocInvoice_$_dinv_$_metopay.ID
                    INNER JOIN Atom_WorkPeriod JOURNAL_DocInvoice_$_awperiod ON JOURNAL_DocInvoice.Atom_WorkPeriod_ID = JOURNAL_DocInvoice_$_awperiod.ID
                    INNER JOIN Atom_myOrganisation_Person JOURNAL_DocInvoice_$_awperiod_$_amcper ON JOURNAL_DocInvoice_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper.ID
                    INNER JOIN Atom_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_DocInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.ID
                    INNER JOIN Atom_cFirstName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                    LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
                    LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
                    LEFT JOIN Atom_cEmail_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
                    LEFT JOIN Atom_cCardType_Person JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
                    LEFT JOIN Atom_PersonImage JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
                    INNER JOIN Atom_Office JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_DocInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.ID
                    INNER JOIN Atom_myOrganisation JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myOrganisation_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
                    INNER JOIN Atom_OrganisationData JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
                    INNER JOIN Atom_Organisation JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                    LEFT JOIN cPhoneNumber_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
                    LEFT JOIN cFaxNumber_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
                    LEFT JOIN cEmail_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
                    LEFT JOIN cHomePage_Org JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
                    LEFT JOIN cOrgTYPE JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
                    LEFT JOIN Atom_Logo JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
                    INNER JOIN Atom_WorkingPlace JOURNAL_DocInvoice_$_awperiod_$_awplace ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_DocInvoice_$_awperiod_$_awplace.ID
                    INNER JOIN Atom_Computer JOURNAL_DocInvoice_$_awperiod_$_acomp ON JOURNAL_DocInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_DocInvoice_$_awperiod_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_awperiodt.ID
                    " + cond + " and ((JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime + ")) order by JOURNAL_DocInvoice_$_dinv.FinancialYear desc,JOURNAL_DocInvoice_$_dinv_$$Draft desc, JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear desc, JOURNAL_DocInvoice_$_dinv_$$DraftNumber desc";
                }
            }
            else if (IsDocProformaInvoice)
            {
                sql = @"SELECT
                JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$FinancialYear,
                JOURNAL_DocProformaInvoice_$_dpinv.Draft AS JOURNAL_DocProformaInvoice_$_dpinv_$$Draft,
                JOURNAL_DocProformaInvoice_$_dpinv.DraftNumber AS JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber,
                JOURNAL_DocProformaInvoice_$_dpinv.NumberInFinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear,
                JOURNAL_DocProformaInvoice_$_dpinv.GrossSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum,
                JOURNAL_DocProformaInvoice.EventTime AS JOURNAL_DocProformaInvoice_$$EventTime,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn_$$FirstName,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln_$$LastName,
                JOURNAL_DocProformaInvoice_$_dpinv_$_metopay.PaymentType AS JOURNAL_DocProformaInvoice_$_dpinv_$_metopay_$$PaymentType,
                JOURNAL_DocProformaInvoice_$_dpinv.NetSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$NetSum,
                JOURNAL_DocProformaInvoice_$_dpinv.TaxSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$TaxSum,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_agsmnper.GsmNumber AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aphnnper.PhoneNumber AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aemailper.Email AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aemailper_$$Email,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.DateOfBirth AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$$DateOfBirth,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg.Name AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg_$$Name,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg.Tax_ID AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg_$$Tax_ID,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg.Registration_ID AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg_$$Registration_ID,
                JOURNAL_DocProformaInvoice_$_dpinv.Discount AS JOURNAL_DocProformaInvoice_$_dpinv_$$Discount,
                JOURNAL_DocProformaInvoice_$_dpinv.EndSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$EndSum,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.UserName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$$UserName,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                JOURNAL_DocProformaInvoice_$_dpinv.ID AS JOURNAL_DocProformaInvoice_$_dpinv_$$ID, 
                JOURNAL_DocProformaInvoice_$_jpinvt.ID AS JOURNAL_DocProformaInvoice_$_jpinvt_$$ID
                FROM JOURNAL_DocProformaInvoice
                INNER JOIN JOURNAL_DocProformaInvoice_Type JOURNAL_DocProformaInvoice_$_jpinvt ON JOURNAL_DocProformaInvoice.JOURNAL_DocProformaInvoice_Type_ID = JOURNAL_DocProformaInvoice_$_jpinvt.ID
                INNER JOIN DocProformaInvoice JOURNAL_DocProformaInvoice_$_dpinv ON JOURNAL_DocProformaInvoice.DocProformaInvoice_ID = JOURNAL_DocProformaInvoice_$_dpinv.ID
                LEFT JOIN Atom_Customer_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper ON JOURNAL_DocProformaInvoice_$_dpinv.Atom_Customer_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper.ID
                LEFT JOIN Atom_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper.Atom_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.ID
                LEFT JOIN Atom_cFirstName JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cFirstName_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn.ID
                LEFT JOIN Atom_cLastName JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cLastName_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln.ID
                LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_agsmnper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_agsmnper.ID
                LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aphnnper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aphnnper.ID
                LEFT JOIN Atom_cEmail_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aemailper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aemailper.ID
                LEFT JOIN Atom_cCardType_Person JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acardtper ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acardtper.ID
                LEFT JOIN Atom_PersonImage JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aperimg ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper.Atom_PersonImage_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_aperimg.ID
                LEFT JOIN Atom_Customer_Org JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg ON JOURNAL_DocProformaInvoice_$_dpinv.Atom_Customer_Org_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg.ID
                LEFT JOIN Atom_Organisation JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg ON JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg.Atom_Organisation_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_acusorg_$_aorg.ID
                LEFT JOIN TermsOfPayment JOURNAL_DocProformaInvoice_$_dpinv_$_trmpay ON JOURNAL_DocProformaInvoice_$_dpinv.TermsOfPayment_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_trmpay.ID
                LEFT JOIN MethodOfPayment JOURNAL_DocProformaInvoice_$_dpinv_$_metopay ON JOURNAL_DocProformaInvoice_$_dpinv.MethodOfPayment_ID = JOURNAL_DocProformaInvoice_$_dpinv_$_metopay.ID
                INNER JOIN Atom_WorkPeriod JOURNAL_DocProformaInvoice_$_awperiod ON JOURNAL_DocProformaInvoice.Atom_WorkPeriod_ID = JOURNAL_DocProformaInvoice_$_awperiod.ID
                INNER JOIN Atom_myOrganisation_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.ID
                INNER JOIN Atom_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.ID
                INNER JOIN Atom_cFirstName JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.ID
                LEFT JOIN Atom_cLastName JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.ID
                LEFT JOIN Atom_cGsmNumber_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_agsmnper.ID
                LEFT JOIN Atom_cPhoneNumber_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aphnnper.ID
                LEFT JOIN Atom_cEmail_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aemailper.ID
                LEFT JOIN Atom_cCardType_Person JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_cCardType_Person_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acardtper.ID
                LEFT JOIN Atom_PersonImage JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_aperimg.ID
                INNER JOIN Atom_Office JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice.ID
                INNER JOIN Atom_myOrganisation JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice.Atom_myOrganisation_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.ID
                INNER JOIN Atom_OrganisationData JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.ID
                INNER JOIN Atom_Organisation JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                LEFT JOIN cPhoneNumber_Org JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID
                LEFT JOIN cFaxNumber_Org JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID
                LEFT JOIN cEmail_Org JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID
                LEFT JOIN cHomePage_Org JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID
                LEFT JOIN cOrgTYPE JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_orgt.ID
                LEFT JOIN Atom_Logo JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo ON JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$_amc_$_aorgd_$_alogo.ID
                INNER JOIN Atom_WorkingPlace JOURNAL_DocProformaInvoice_$_awperiod_$_awplace ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_WorkingPlace_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_awplace.ID
                INNER JOIN Atom_Computer JOURNAL_DocProformaInvoice_$_awperiod_$_acomp ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_Computer_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_acomp.ID
                LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocProformaInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_awperiodt.ID
                " + cond + " and (JOURNAL_DocProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_ProformaInvoiceDraftTime + ") order by JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear desc,JOURNAL_DocProformaInvoice_$_dpinv_$$Draft desc, JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear desc, JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber desc";
            }
            if (!bNew)
            {
                DataGridViewSelectedRowCollection dgvxc = dgvx_XInvoice.SelectedRows;
                if (dgvxc.Count>0)
                {
                    DataGridViewRow dgvr = dgvxc[0];
                    iCurrentSelectedRow = dgvx_XInvoice.Rows.IndexOf(dgvr);
                }
            }
            bIgnoreChangeSelectionEvent = true;
            dt_XInvoice.Clear();
            dt_XInvoice.Columns.Clear();
            string Err = null;
            iColIndex_DocInvoice_Draft = -1;
            iColIndex_DocInvoice_Invoice_Storno = -1;
            bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XInvoice, sql, lpar_ExtraCondition, ref Err);
            if (bRes)
            {
                dgvx_XInvoice.DataSource = dt_XInvoice;
                if (IsDocInvoice)
                {
                    iColIndex_DocInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Draft");
                    iColIndex_DocInvoice_Invoice_Storno = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Storno");
                    if (Program.b_FVI_SLO)
                    {
                        iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue");
                        iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$InvoiceNumber");
                    }


                    SetLabels();
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice)));
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    if (Program.b_FVI_SLO)
                    {
                        dgvx_XInvoice.Columns["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue"].HeaderText = lngRPM.s_FURS_BarCode.s;
                    }
                    iRowsCount = dt_XInvoice.Rows.Count;
                    if (!bNew)
                    {
                        if (iRowsCount > 0)
                        {
                            if (iCurrentSelectedRow >= 0)
                            {
                                dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                            }
                            else if (Properties.Settings.Default.Current_DocInvoice_ID >= 0)
                            {
                                DataRow[] dr_Current = dt_XInvoice.Select("JOURNAL_DocInvoice_$_dinv_$$ID = " + Properties.Settings.Default.Current_DocInvoice_ID.ToString());
                                if (dr_Current.Count() > 0)
                                {
                                    iCurrentSelectedRow = dt_XInvoice.Rows.IndexOf(dr_Current[0]);
                                    dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                                }
                            }
                            else
                            {
                                iCurrentSelectedRow = 0;
                            }
                        }
                    }
                    bIgnoreChangeSelectionEvent = false;
                }
                else if (IsDocProformaInvoice)
                {
                    iColIndex_DocInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");

                    SetLabels();
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice)));
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    iRowsCount = dt_XInvoice.Rows.Count;
                    if (!bNew)
                    {
                        if (iRowsCount > 0)
                        {
                            if (iCurrentSelectedRow >= 0)
                            {
                                dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                            }
                            else if (Properties.Settings.Default.Current_DocInvoice_ID >= 0)
                            {
                                DataRow[] dr_Current = dt_XInvoice.Select("JOURNAL_DocProformaInvoice_$_dpinv_$$ID = " + Properties.Settings.Default.Current_DocInvoice_ID.ToString());
                                if (dr_Current.Count() > 0)
                                {
                                    iCurrentSelectedRow = dt_XInvoice.Rows.IndexOf(dr_Current[0]);
                                    dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                                }
                            }
                            else
                            {
                                iCurrentSelectedRow = 0;
                            }
                        }
                    }
                    bIgnoreChangeSelectionEvent = false;
                }
            }
            else
            {
                bIgnoreChangeSelectionEvent = false;
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice Err=" + Err);
            }
            return iRowsCount;
        }

        private decimal Sum(string ColumnName)
        {
            decimal sum = 0;
            int iColDraft = -1;
            if (IsDocInvoice)
            {
                iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Draft");
            }
            else if (IsDocProformaInvoice)
            {
                iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");
            }
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
            int iColDraft = -1;
            int iCol = -1;
            int iColPayment = -1;
            if (IsDocInvoice)
            {
                iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Draft");
                iCol = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$GrossSum");
                iColPayment = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_metopay_$$PaymentType");
            }
            else if (IsDocProformaInvoice)
            {
                iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");
                iCol = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum");
                iColPayment = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$_metopay_$$PaymentType");
            }

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

                decimal gross_sum = 0;
                decimal net_sum = 0;
                decimal tax_sum = 0;
                if (IsDocInvoice)
                {
                    gross_sum = Sum("JOURNAL_DocInvoice_$_dinv_$$GrossSum");
                    net_sum = Sum("JOURNAL_DocInvoice_$_dinv_$$NetSum");
                    tax_sum = Sum("JOURNAL_DocInvoice_$_dinv_$$TaxSum");
                }
                else if (IsDocProformaInvoice)
                {
                    gross_sum = Sum("JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum");
                    net_sum = Sum("JOURNAL_DocProformaInvoice_$_dpinv_$$NetSum");
                    tax_sum = Sum("JOURNAL_DocProformaInvoice_$_dpinv_$$TaxSum");
                }
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
                    if (IsDocInvoice)
                    {
                        if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocInvoice_$_dinv_$$ID"].Value is long)
                        {
                            long Identity = (long)dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocInvoice_$_dinv_$$ID"].Value;
                            this.iCurrentSelectedRow = dgvCellCollection[0].RowIndex;
                            SelectedInvoiceChanged(Identity, bInitialise);
                            return;
                        }
                    }
                    else if (IsDocProformaInvoice)
                    {
                        if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"].Value is long)
                        {
                            long Identity = (long)dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"].Value;
                            this.iCurrentSelectedRow = dgvCellCollection[0].RowIndex;
                            SelectedInvoiceChanged(Identity, bInitialise);
                            return;
                        }
                    }

                }
                SelectedInvoiceChanged(-1, bInitialise);
            }
        }

        private void dgvx_XInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (!bIgnoreChangeSelectionEvent)
            {
                ShowOrEditSelectedRow(false);
            }
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
            string sparam1 = "@par_DocInvoiceTime_Start";
            string sparam2 = "@par_DocInvoiceTime_End";
            dtStartTime = xdtStartTime;
            dtEndTime = xdtEndTime;
            lpar_ExtraCondition = null;
            lpar_ExtraCondition = new List<DBConnectionControl40.SQL_Parameter>();
            SQL_Parameter par1 = new SQL_Parameter(sparam1, SQL_Parameter.eSQL_Parameter.Datetime, false, dtStartTime);
            lpar_ExtraCondition.Add(par1);
            SQL_Parameter par2 = new SQL_Parameter(sparam2, SQL_Parameter.eSQL_Parameter.Datetime, false, dtEndTime);
            lpar_ExtraCondition.Add(par2);
            if (IsDocInvoice)
            {
                ExtraCondition = " (JOURNAL_DocInvoice_$$EventTime >= " + sparam1 + ") and ( JOURNAL_DocInvoice_$$EventTime < " + sparam2 + ") ";
            }
            else if (IsDocProformaInvoice)
            {
                ExtraCondition = " (JOURNAL_DocProformaInvoice_$$EventTime >= " + sparam1 + ") and ( JOURNAL_DocProformaInvoice_$$EventTime < " + sparam2 + ") ";
            }

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
                if ((iColIndex_DocInvoice_Draft >= 0) && (iColIndex_DocInvoice_Invoice_Storno>=0))
                {
                    if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Draft])
                    {
                        e.CellStyle.BackColor = ColorDraft;
                    }
                    bool bxstorno = false;
                    if (dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Invoice_Storno] is bool)
                    {
                        bxstorno = (bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Invoice_Storno];
                    }
                    else if (bxstorno)
                    {
                        e.CellStyle.BackColor = ColorStorno;
                    }
                    else
                    {
                        if (Program.b_FVI_SLO)
                        {
                            if ((dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue] is string) && (dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber] is string))
                            {
                                e.CellStyle.BackColor = ColorFurs_SalesBookInvoiceConfirmed;
                            }
                            else if (dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue] is string)
                            {
                                e.CellStyle.BackColor = ColorFurs_InvoiceConfirmed;
                            }
                            else if (dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber] is string)
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
