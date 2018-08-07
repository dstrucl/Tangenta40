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
using DBTypes;
using LoginControl;

namespace Tangenta
{
    public partial class usrc_TableOfDocuments : UserControl
    {
        private LMOUser m_LMOUser = null;

        public enum eMode { All, Today, ThisWeek, LastWeek, ThisMonth, LastMonth, ThisYear, LastYear, TimeSpan };
        public delegate void delegate_SelectedInvoiceChanged(ID Invoice_ID, bool bInitialise);
        public event delegate_SelectedInvoiceChanged SelectedInvoiceChanged;
        public Color ColorDraft;
        public Color ColorStorno;
        public Color ColorFurs_InvoiceConfirmed;
        public Color ColorFurs_SalesBookInvoiceConfirmed;
        public Color ColorFurs_SalesBookInvoiceNotConfirmed;

        public bool m_bInvoice = false;
        public string cond = null;

        long dgSortingSelectedItem_ID = -1;


        public string ExtraCondition = null;
        public List<SQL_Parameter> lpar_ExtraCondition = null;
        public DateTime dtStartTime;
        public DateTime dtEndTime;
        public eMode Mode = eMode.All;

        public string sFromTo_Suffix = "";
        public DataTable dt_XInvoice = new DataTable();

        private int m_iCurrentSelectedRow = -1;

        private int iCurrentSelectedRow
        {
            get { return m_iCurrentSelectedRow; }
            set
            {
                m_iCurrentSelectedRow = value;
            }
        }

        private int iColIndex_DocInvoice_Draft = -1;
        private int iColIndex_DocInvoice_IssueDate = -1;
        private int iColIndex_DocProformaInvoice_IssueDate = -1;
        private int iColIndex_DocInvoice_Invoice_Storno = -1;
        private int iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue = -1;
        private int iColIndex_DocInvoice_FSI_SLO_ID = -1;
        private int iColIndex_DocInvoice_FSI_SLO_EOR = -1;
        private int iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = -1;
        private int iColIndex_DocInvoice_PaymentType_Name = -1;
        private int iColIndex_DocInvoice_PaymentType_Identification = -1;


        //private bool bIgnoreChangeSelectionEvent = false;

        private string m_DocTyp = null;

        public string DocTyp
        {
            get { return m_DocTyp; }
            set
            {
                m_DocTyp = value;
            }
        }

        public bool IsDocInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocProformaInvoice); }
        }

        public ID Current_Doc_ID
        {
            get {
                    if (iCurrentSelectedRow >= 0)
                    {
                        if (dt_XInvoice.Rows.Count > 0)
                        {
                            if (iCurrentSelectedRow < dt_XInvoice.Rows.Count)
                            {
                                ID id = null;
                                if (IsDocInvoice)
                                {
                                    id = tf.set_ID(dt_XInvoice.Rows[iCurrentSelectedRow]["JOURNAL_DocInvoice_$_dinv_$$ID"]);
                                }
                                else if (IsDocProformaInvoice)
                                {
                                    id = tf.set_ID(dt_XInvoice.Rows[iCurrentSelectedRow]["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"]);
                                }
                                return id;
                            }
                        }
                    }

                    if (m_LMOUser != null)
                    {
                        string sDataSource = DBSync.DBSync.DataSource;
                        ID xDoc_ID = null;
                        ID xCurrent_Doc_ID = null;
                        if (ID.Validate(m_LMOUser.myOrganisation_Person_ID))
                        {
                            if (f_Current_Doc_ID.GetLast(DocTyp, sDataSource, m_LMOUser.myOrganisation_Person_ID, myOrg.m_myOrg_Office.ElectronicDevice_ID, ref xDoc_ID, ref xCurrent_Doc_ID))
                            {
                                if (ID.Validate(xDoc_ID))
                                {
                                    iCurrentSelectedRow = FindRow(xDoc_ID);
                                    if (iCurrentSelectedRow >= 0)
                                    {
                                        return xDoc_ID;
                                    }
                                }
                            }
                        }
                    }
                    return ID.Invalid;
                }
        }

        private int FindRow(ID xDoc_ID)
        {
            if (ID.Validate(xDoc_ID))
            {
                foreach (DataRow dr in dt_XInvoice.Rows)
                {
                    ID xid = tf.set_ID(dr["JOURNAL_" + DocTyp + "_$_dinv_$$ID"]);
                    if (ID.Validate(xid))
                    {
                        if (xDoc_ID.Equals(xid))
                        {
                            int ix = dt_XInvoice.Rows.IndexOf(dr);
                            return ix;
                        }
                    }
                }
            }
            return -1;

        }

        public usrc_TableOfDocuments()
        {
            InitializeComponent();
            ExtensionMethods.DoubleBuffered(this.dgvx_XInvoice, true);
            dtStartTime = DateTime.Now;
            dtEndTime = DateTime.Now;
            lbl_From_To.Text = lng.s_AllData.s;
            lng.s_Sum_All.Text(this.lbl_Sum_All);
            lng.s_Sum_Tax.Text(this.lbl_Sum_Tax);
            lng.s_Sum_WithoutTax.Text(this.lbl_Sum_WithoutTax);
            lng.s_from.Text(this.lbl_From_To);
        }

        public void Bind(LMOUser xLMOUser)
        {
            m_LMOUser = xLMOUser;
        }
        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            dgvx_XInvoice.ClearSelection();
            this.dgvx_XInvoice.SelectionChanged += this.dgvx_XInvoice_SelectionChanged;
            dgvx_XInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvx_XInvoice.MultiSelect = false;
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


        internal int Init(string doc_type,
                          bool bNew,
                          bool bInitialise_usrc_Invoice,
                          int iFinancialYear,
                          ID Doc_ID_To_show)
        {
            ColorDraft = Properties.Settings.Default.ColorDraft;
            ColorStorno = Properties.Settings.Default.ColorStorno;
            ColorFurs_InvoiceConfirmed = Properties.Settings.Default.ColorFurs_InvoiceConfirmed;
            ColorFurs_SalesBookInvoiceConfirmed = Properties.Settings.Default.ColorFurs_SalesBookInvoiceConfirmed;
            ColorFurs_SalesBookInvoiceNotConfirmed = Properties.Settings.Default.ColorFurs_SalesBookInvoiceNotConfirmed;

            DocTyp = doc_type;

            int iRowsCount = -1;
            iRowsCount = Init_Invoice(true, bNew, iFinancialYear);
            if (bNew)
            {
                ShowOrEditSelectedRow(false);
            }
            else
            {
                if (ID.Validate(Doc_ID_To_show))
                {
                    ShowOrEditSelectedRow(Doc_ID_To_show);
                }
            }

            return iRowsCount;
        }

        private int Init_Invoice(bool bInvoice, bool bNew, int iFinancialYear)
        {
            m_bInvoice = bInvoice;
            int iRowsCount = -1;
            iCurrentSelectedRow = -1;
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
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice:DocTyp=" + DocTyp + " not implemented");
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

            string ElectronicDevice_Name = GlobalData.ElectronicDevice_Name;
            if (lpar_ExtraCondition == null)
            {
                lpar_ExtraCondition = new List<SQL_Parameter>();
            }
            string spar_ElectronicDevice_Name = "@par_ElectronicDevice_Name";
            SQL_Parameter par_ElectronicDevice_Name = new SQL_Parameter(spar_ElectronicDevice_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ElectronicDevice_Name);
            lpar_ExtraCondition.Add(par_ElectronicDevice_Name);

            string cond_Atom_myOrganisation_Person = "";

            if ((m_LMOUser.IsAdministrator)||(m_LMOUser.IsUserManager))
            {
                if (IsDocInvoice)
                {
                    lng.s_lbl_SelectionDescription_AllInvoices.Text(lbl_SelectionDescription);
                }
                else if (IsDocProformaInvoice)
                {
                    lng.s_lbl_SelectionDescription_AllProformaInvoices.Text(lbl_SelectionDescription);
                }
            }
            else
            {
                // in case that user is not administrator
                // set condition to show only documents of Atom_myOrg_Person
                //string spar_Atom_myOrganisation_Person_Tax_ID = "@par_AOP_Tax_ID";
                //SQL_Parameter par_Atom_myOrganisation_Person_Tax_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_Tax_ID, SQL_Parameter.eSQL_Parameter.Nvarchar, false,m_LMOUser.Atom_myOrganisation_Person_Tax_ID);
                //lpar_ExtraCondition.Add(par_Atom_myOrganisation_Person_Tax_ID);

                string spar_TaxID = null;

                if (!m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
                {
                    spar_TaxID = "@par_Tax_ID";
                    SQL_Parameter par_TaxID = new SQL_Parameter(spar_TaxID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, m_LMOUser.Atom_myOrganisation_Person_Tax_ID);
                    lpar_ExtraCondition.Add(par_TaxID);
                }

                string spar_OfficeShortName = "@par_OffSName";
                SQL_Parameter par_OfficeShortName = new SQL_Parameter(spar_OfficeShortName, SQL_Parameter.eSQL_Parameter.Nvarchar, false,m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName);
                lpar_ExtraCondition.Add(par_OfficeShortName);

                string spar_ElectronicDeviceName = "@par_EDName";
                SQL_Parameter par_ElectronicDeviceName = new SQL_Parameter(spar_ElectronicDeviceName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, m_LMOUser.Atom_ElectronicDevice_Name);
                lpar_ExtraCondition.Add(par_ElectronicDeviceName);

                if (IsDocInvoice)
                {
                    if (spar_TaxID != null)
                    {
                        cond_Atom_myOrganisation_Person = " and JOURNAL_DocInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                             + " and JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                             + " and JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                    }
                    else
                    {
                        cond_Atom_myOrganisation_Person = " and JOURNAL_DocInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                             + " and JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;
                    }
                }
                else if (IsDocProformaInvoice)
                {
                    if (spar_TaxID != null)
                    {
                        cond_Atom_myOrganisation_Person = " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                    }
                    else
                    {
                        cond_Atom_myOrganisation_Person = " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;
                    }
                }


                cond += cond_Atom_myOrganisation_Person;
                string s_myorg_person = "??";
                if (myOrg.m_myOrg_Office!=null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person!=null)
                    {
                       if (myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v!=null)
                        {
                            s_myorg_person = myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v.v;
                        }
                        if (myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v != null)
                        {
                            s_myorg_person += " "+myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v.v;
                        }
                    }
                }
                if (IsDocInvoice)
                {
                    lng.s_lbl_SelectionDescription_AllInvoicesOfUser.Text(lbl_SelectionDescription, s_myorg_person);
                }
                else if (IsDocProformaInvoice)
                {
                    lng.s_lbl_SelectionDescription_AllProformaInvoices.Text(lbl_SelectionDescription, s_myorg_person);
                }
            }

            if (IsDocInvoice)
            {
                string sAtom_WorkArea_Name = "";
                string sAtom_WorkArea_Join = "";
                if (Program.UseWorkAreas)
                {
                    sAtom_WorkArea_Join = @" LEFT JOIN DocInvoice_Atom_WorkArea diawa ON diawa.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID 
                                             LEFT JOIN Atom_WorkArea awa ON diawa.Atom_WorkArea_ID = awa.ID ";
                    sAtom_WorkArea_Name = " awa.Name as Atom_WorkArea_Name,";
                }
                if (Program.b_FVI_SLO)
                {
                    sql = @"SELECT " +
                    sAtom_WorkArea_Name +
                    @"JOURNAL_DocInvoice_$_dinv.NumberInFinancialYear AS JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                    JOURNAL_DocInvoice_$_dinv.GrossSum AS JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                    JOURNAL_DocInvoice_$_dinv.FinancialYear AS JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                    diao.IssueDate as IssueDate,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
                    pt.Identification AS PaymentType_Identification,
                    pt.Name AS PaymentType_Name,
                    JOURNAL_DocInvoice_$_dinv.NetSum AS JOURNAL_DocInvoice_$_dinv_$$NetSum,
                    JOURNAL_DocInvoice_$_dinv.TaxSum AS JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                    JOURNAL_DocInvoice.EventTime AS JOURNAL_DocInvoice_$$EventTime,
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
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_DocInvoice_$_awperiod_$_aed.Name as JOURNAL_DocInvoice_$_awperiod_$_aed_$$Name,
                    JOURNAL_DocInvoice_$_dinv_$_fvisres.UniqueInvoiceID AS EOR,
                    JOURNAL_DocInvoice_$_dinv_$_fvisres.BarCodeValue As JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.InvoiceNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$InvoiceNumber,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.SetNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$SetNumber,
                    JOURNAL_DocInvoice_$_dinv_$_fvisbi.SerialNumber AS JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$SerialNumber,
                    JOURNAL_DocInvoice_$_dinv.ID AS JOURNAL_DocInvoice_$_dinv_$$ID, 
                    JOURNAL_DocInvoice_$_jpinvt.ID AS JOURNAL_DocInvoice_$_jpinvt_$$ID,
                    JOURNAL_DocInvoice_$_dinv_$_fvisres.ID AS JOURNAL_DocInvoice_$_dinv_$_fvisres_$$ID,
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
                    LEFT JOIN DocInvoiceAddOn diao ON diao.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                    LEFT JOIN TermsOfPayment topay ON diao.TermsOfPayment_ID = topay.ID
                    LEFT JOIN MethodOfPayment_DI mtpdi ON diao.MethodOfPayment_DI_ID = mtpdi.ID
                    LEFT JOIN PaymentType pt ON mtpdi.PaymentType_ID = pt.ID
                    LEFT JOIN FVI_SLO_Response JOURNAL_DocInvoice_$_dinv_$_fvisres ON JOURNAL_DocInvoice_$_dinv_$_fvisres.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID 
                    LEFT JOIN FVI_SLO_SalesBookInvoice JOURNAL_DocInvoice_$_dinv_$_fvisbi ON JOURNAL_DocInvoice_$_dinv_$_fvisbi.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
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
                    INNER JOIN Atom_ElectronicDevice JOURNAL_DocInvoice_$_awperiod_$_aed ON JOURNAL_DocInvoice_$_awperiod.Atom_ElectronicDevice_ID = JOURNAL_DocInvoice_$_awperiod_$_aed.ID
                    INNER JOIN Atom_Office JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice ON JOURNAL_DocInvoice_$_awperiod_$_aed.Atom_Office_ID = JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice.ID
                    INNER JOIN Atom_Computer JOURNAL_DocInvoice_$_awperiod_$_aed_$_acomp ON JOURNAL_DocInvoice_$_awperiod_$_aed.Atom_Computer_ID = JOURNAL_DocInvoice_$_awperiod_$_aed_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_awperiodt.ID
                    "
                    + sAtom_WorkArea_Join
                    + cond + " and ((JOURNAL_DocInvoice_$_jpinvt.ID = " 
                    + s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime 
                    + ")) and  JOURNAL_DocInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDevice_Name 
                    + " order by JOURNAL_DocInvoice_$_dinv_$$FinancialYear desc,JOURNAL_DocInvoice_$_dinv_$$Draft desc, JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear desc, JOURNAL_DocInvoice_$_dinv_$$DraftNumber desc";
                }
                else
                {
                    sql = @"SELECT" +
                    sAtom_WorkArea_Name +
                  @"JOURNAL_DocInvoice_$_dinv.NumberInFinancialYear AS JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear,
                    JOURNAL_DocInvoice_$_dinv.GrossSum AS JOURNAL_DocInvoice_$_dinv_$$GrossSum,
                    JOURNAL_DocInvoice_$_dinv.FinancialYear AS JOURNAL_DocInvoice_$_dinv_$$FinancialYear,
                    diao.IssueDate as IssueDate,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_dinv_$_acusper_$_aper_$_acln_$$LastName,
                    pt.Identification AS PaymentType_Identification,
                    pt.Name AS PaymentType_Name,
                    JOURNAL_DocInvoice_$_dinv.NetSum AS JOURNAL_DocInvoice_$_dinv_$$NetSum,
                    JOURNAL_DocInvoice_$_dinv.TaxSum AS JOURNAL_DocInvoice_$_dinv_$$TaxSum,
                    JOURNAL_DocInvoice.EventTime AS JOURNAL_DocInvoice_$$EventTime,
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
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                    JOURNAL_DocInvoice_$_awperiod_$_aed.Name as JOURNAL_DocInvoice_$_awperiod_$_aed_$$Name,
                    JOURNAL_DocInvoice_$_dinv.Draft AS JOURNAL_DocInvoice_$_dinv_$$Draft,
                    JOURNAL_DocInvoice_$_dinv.DraftNumber AS JOURNAL_DocInvoice_$_dinv_$$DraftNumber,
                    JOURNAL_DocInvoice_$_dinv.ID AS JOURNAL_DocInvoice_$_dinv_$$ID, 
                    JOURNAL_DocInvoice_$_jpinvt.ID AS JOURNAL_DocInvoice_$_jpinvt_$$ID
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
                    LEFT JOIN DocInvoiceAddOn diao ON diao.DocInvoice_ID = JOURNAL_DocInvoice_$_dinv.ID
                    LEFT JOIN TermsOfPayment topay ON diao.TermsOfPayment_ID = topay.ID
                    LEFT JOIN MethodOfPayment_DI mtpdi ON diao.MethodOfPayment_DI_ID = mtpdi.ID
                    LEFT JOIN PaymentType pt ON mtpdi.PaymentType_ID = pt.ID
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
                    INNER JOIN Atom_ElectronicDevice JOURNAL_DocInvoice_$_awperiod_$_aed ON JOURNAL_DocInvoice_$_awperiod.Atom_ElectronicDevice_ID = JOURNAL_DocInvoice_$_awperiod_$_aed.ID
                    INNER JOIN Atom_Office JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice ON JOURNAL_DocInvoice_$_awperiod_$_aed.Atom_Office_ID = JOURNAL_DocInvoice_$_awperiod_$_aed_$_aoffice.ID
                    INNER JOIN Atom_Computer JOURNAL_DocInvoice_$_awperiod_$_aed_$_acomp ON JOURNAL_DocInvoice_$_awperiod_$_aed.Atom_Computer_ID = JOURNAL_DocInvoice_$_awperiod_$_aed_$_acomp.ID
                    LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocInvoice_$_awperiod_$_awperiodt.ID
                    "
                    + sAtom_WorkArea_Join
                    + cond +
                    " and ((JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceDraftTime + ")or(JOURNAL_DocInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_InvoiceStornoTime
                    + ")) and  JOURNAL_DocInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDevice_Name
                    + " order by JOURNAL_DocInvoice_$_dinv.FinancialYear desc,JOURNAL_DocInvoice_$_dinv_$$Draft desc, JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear desc, JOURNAL_DocInvoice_$_dinv_$$DraftNumber desc";
                }
            }
            else if (IsDocProformaInvoice)
            {
                sql = @"SELECT
                JOURNAL_DocProformaInvoice_$_dpinv.NumberInFinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear,
                JOURNAL_DocProformaInvoice_$_dpinv.GrossSum AS JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum,
                dpiao.IssueDate as IssueDate,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn.FirstName AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acfn_$$FirstName,
                JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln.LastName AS JOURNAL_DocProformaInvoice_$_dpinv_$_acusper_$_aper_$_acln_$$LastName,
                pt.Identification AS PaymentType_Identification,
                pt.Name AS PaymentType_Name,
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
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice.Name AS JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear AS JOURNAL_DocProformaInvoice_$_dpinv_$$FinancialYear,
                JOURNAL_DocProformaInvoice.EventTime AS JOURNAL_DocProformaInvoice_$$EventTime,
                JOURNAL_DocProformaInvoice_$_dpinv.Draft AS JOURNAL_DocProformaInvoice_$_dpinv_$$Draft,
                JOURNAL_DocProformaInvoice_$_dpinv.DraftNumber AS JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber,
                JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name AS JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$$Name,
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
                LEFT JOIN DocProformaInvoiceAddOn dpiao on dpiao.DocProformaInvoice_ID = JOURNAL_DocProformaInvoice_$_dpinv.ID
                LEFT JOIN TermsOfPayment topay ON dpiao.TermsOfPayment_ID = topay.ID
                LEFT JOIN MethodOfPayment_DPI mtpdpi ON dpiao.MethodOfPayment_DPI_ID = mtpdpi.ID
                LEFT JOIN PaymentType pt ON mtpdpi.PaymentType_ID = pt.ID
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
                INNER JOIN Atom_ElectronicDevice JOURNAL_DocProformaInvoice_$_awperiod_$_aed ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_ElectronicDevice_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_aed.ID
                INNER JOIN Atom_Office JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice ON JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Atom_Office_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice.ID
                INNER JOIN Atom_Computer JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_acomp ON JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Atom_Computer_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_acomp.ID
                LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_DocProformaInvoice_$_awperiod_$_awperiodt ON JOURNAL_DocProformaInvoice_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_DocProformaInvoice_$_awperiod_$_awperiodt.ID
                " + cond 
                + " and (JOURNAL_DocProformaInvoice_$_jpinvt.ID = " + s_JOURNAL_DocInvoice_Type_ID_ProformaInvoiceDraftTime 
                + ") and  JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDevice_Name +
                " order by JOURNAL_DocProformaInvoice_$_dpinv.FinancialYear desc,JOURNAL_DocProformaInvoice_$_dpinv.Draft desc, JOURNAL_DocProformaInvoice_$_dpinv_$$NumberInFinancialYear desc, JOURNAL_DocProformaInvoice_$_dpinv_$$DraftNumber desc";
            }
            //bIgnoreChangeSelectionEvent = true;
            if (dt_XInvoice != null)
            {
                dt_XInvoice.Dispose();
                dt_XInvoice = null;
                dt_XInvoice = new DataTable();
            }
            else
            {
                dt_XInvoice = new DataTable();
            }
            
            string Err = null;
            iColIndex_DocInvoice_Draft = -1;
            iColIndex_DocInvoice_Invoice_Storno = -1;
            dgvx_XInvoice.DataSource = null;
            bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XInvoice, sql, lpar_ExtraCondition, ref Err);
            if (bRes)
            {
                dgvx_XInvoice.DataSource = dt_XInvoice;

                if (!bNew)
                {
                    DataGridViewSelectedRowCollection dgvxc = dgvx_XInvoice.SelectedRows;
                    if (dgvxc.Count > 0)
                    {
                        DataGridViewRow dgvr = dgvxc[0];
                        iCurrentSelectedRow = dgvx_XInvoice.Rows.IndexOf(dgvr);
                    }
                }

                if (IsDocInvoice)
                {
                    iColIndex_DocInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Draft");
                    iColIndex_DocInvoice_Invoice_Storno = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$$Storno");
                    iColIndex_DocInvoice_IssueDate = dt_XInvoice.Columns.IndexOf("IssueDate");
                    dgvx_XInvoice.Columns[iColIndex_DocInvoice_IssueDate].HeaderText = lng.s_IssueDate.s;
                    if (Program.b_FVI_SLO)
                    {
                        iColIndex_DocInvoice_FSI_SLO_ID = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_fvisres_$$ID"); 
                        iColIndex_DocInvoice_FSI_SLO_EOR = dt_XInvoice.Columns.IndexOf("EOR");
                        iColIndex_DocInvoice_FSI_SLO_Response_BarCodeValue = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue");
                        iColIndex_DocInvoice_FSI_SLO_SalesBookInvoice_InvoiceNumber = dt_XInvoice.Columns.IndexOf("JOURNAL_DocInvoice_$_dinv_$_iinv_$_fvisbi_$$InvoiceNumber");
                    }

                    iColIndex_DocInvoice_PaymentType_Identification = dt_XInvoice.Columns.IndexOf("PaymentType_Identification");
                    iColIndex_DocInvoice_PaymentType_Name = dt_XInvoice.Columns.IndexOf("PaymentType_Name");

                    dgvx_XInvoice.Columns[iColIndex_DocInvoice_PaymentType_Identification].Visible = false;

                    dgvx_XInvoice.Columns["Atom_WorkArea_Name"].HeaderText = lng.s_Atom_WorkArea_Name.s;

                    SetLabels();
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocInvoice)));
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    if (Program.b_FVI_SLO)
                    {
                        dgvx_XInvoice.Columns["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue"].HeaderText = lng.s_FURS_BarCode.s;
                    }
                    iRowsCount = dt_XInvoice.Rows.Count;
                    if (!bNew)
                    {
                        if (iRowsCount > 0)
                        {
                            string sdb = DBSync.DBSync.DataBase;
                            if (sdb != null)
                            {
                                if (!Properties.Settings.Default.Current_DataBase.Equals(sdb))
                                {
                                    Properties.Settings.Default.Current_DataBase = sdb;
                                    //Properties.Settings.Default.Current_DocInvoice_ID = "";
                                    Properties.Settings.Default.Save();
                                }
                            }
                            if (iCurrentSelectedRow >= 0)
                            {
                                dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                            }
                            else if (false /*Properties.Settings.Default.Current_DocInvoice_ID.Length > 0*/)
                            {
                                DataRow[] dr_Current = dt_XInvoice.Select("JOURNAL_DocInvoice_$_dinv_$$ID = " /*+ Properties.Settings.Default.Current_DocInvoice_ID*/);
                                if (dr_Current.Count() > 0)
                                {
                                    iCurrentSelectedRow = dt_XInvoice.Rows.IndexOf(dr_Current[0]);
                                    dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                                }
                                else
                                {
                                    iCurrentSelectedRow = 0;
                                }
                            }
                            else
                            {
                                iCurrentSelectedRow = 0;
                            }
                        }
                    }
                    //bIgnoreChangeSelectionEvent = false;
                }
                else if (IsDocProformaInvoice)
                {
                    iColIndex_DocInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");
                    iColIndex_DocInvoice_PaymentType_Identification = dt_XInvoice.Columns.IndexOf("PaymentType_Identification");
                    iColIndex_DocInvoice_PaymentType_Name = dt_XInvoice.Columns.IndexOf("PaymentType_Name");
                    iColIndex_DocProformaInvoice_IssueDate = dt_XInvoice.Columns.IndexOf("IssueDate");
                    dgvx_XInvoice.Columns[iColIndex_DocProformaInvoice_IssueDate].HeaderText = lng.s_IssueDate.s;

                    dgvx_XInvoice.Columns[iColIndex_DocInvoice_PaymentType_Identification].Visible = false;

                    SetLabels();
                    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocProformaInvoice)));
                    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                    iRowsCount = dt_XInvoice.Rows.Count;
                    if (!bNew)
                    {
                        if (iRowsCount > 0)
                        {
                            string sdb = DBSync.DBSync.DataBase;
                            if (sdb != null)
                            {
                                if (!Properties.Settings.Default.Current_DataBase.Equals(sdb))
                                {
                                    Properties.Settings.Default.Current_DataBase = sdb;
                                    //Properties.Settings.Default.Current_DocProformaInvoice_ID = "";
                                    Properties.Settings.Default.Save();
                                }
                            }
                            if (iCurrentSelectedRow >= 0)
                            {
                                dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                            }
                            else if (false /*Properties.Settings.Default.Current_DocProformaInvoice_ID.Length>0*/)
                            {
                                ID my_Current_DocProformaInvoice_ID = new ID(1/*Properties.Settings.Default.Current_DocProformaInvoice_ID*/);
                                DataRow[] dr_Current = dt_XInvoice.Select("JOURNAL_DocProformaInvoice_$_dpinv_$$ID = " + my_Current_DocProformaInvoice_ID.ToString());
                                if (dr_Current.Count() > 0)
                                {
                                    iCurrentSelectedRow = dt_XInvoice.Rows.IndexOf(dr_Current[0]);
                                    dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;
                                }
                                else
                                {
                                    iCurrentSelectedRow = 0;
                                }
                            }
                            else
                            {
                                iCurrentSelectedRow = 0;
                            }
                        }
                    }
                    //bIgnoreChangeSelectionEvent = false;
                }
            }
            else
            {
                //bIgnoreChangeSelectionEvent = false;
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
                iColPayment = dt_XInvoice.Columns.IndexOf("PaymentType_Identification");
            }
            else if (IsDocProformaInvoice)
            {
                iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");
                iCol = dt_XInvoice.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$GrossSum");
                iColPayment = dt_XInvoice.Columns.IndexOf("PaymentType_Identification");
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
                lbl_Sum_All.Text = lng.s_Sum_All.s + gross_sum.ToString() + " " + currency_symbol;
                lbl_Sum_Tax.Text = lng.s_Sum_Tax.s + tax_sum.ToString() + " " + currency_symbol; ;
                lbl_Sum_WithoutTax.Text = lng.s_Sum_WithoutTax.s + net_sum.ToString() + " " + currency_symbol; 

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
            if (!(dgSortingSelectedItem_ID >= 0))
            {
                if (SelectedInvoiceChanged != null)
                {
                    DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_XInvoice.SelectedCells;
                    if (dgvCellCollection.Count >= 1)
                    {
                        //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                        if (IsDocInvoice)
                        {
                            if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocInvoice_$_dinv_$$ID"].Value is long)
                            {
                                ID Identity = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocInvoice_$_dinv_$$ID"].Value);
                                this.iCurrentSelectedRow = dgvCellCollection[0].RowIndex;
                                SelectedInvoiceChanged(Identity, bInitialise);
                                return;
                            }
                        }
                        else if (IsDocProformaInvoice)
                        {
                            if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"].Value is long)
                            {
                                ID Identity = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["JOURNAL_DocProformaInvoice_$_dpinv_$$ID"].Value);
                                this.iCurrentSelectedRow = dgvCellCollection[0].RowIndex;
                                SelectedInvoiceChanged(Identity, bInitialise);
                                return;
                            }
                        }

                    }
                    SelectedInvoiceChanged(null, bInitialise);
                }
            }
        }


        private void ShowOrEditSelectedRow(ID Doc_ID_to_show)
        {
            if (ID.Validate(Doc_ID_to_show))
            {
                if (IsDocInvoice)
                {
                    DataRow[] drs = dt_XInvoice.Select("JOURNAL_DocInvoice_$_dinv_$$ID = " + Doc_ID_to_show.ToString());
                    if (drs.Count() > 0)
                    {
                        int iRow = dt_XInvoice.Rows.IndexOf(drs[0]);
                        dgvx_XInvoice.Rows[iRow].Selected = true;
                    }
                }
                else
                {
                    DataRow[] drs = dt_XInvoice.Select("JOURNAL_DocProformaInvoice_$_dpinv_$$ID = " + Doc_ID_to_show.ToString());
                    if (drs.Count() > 0)
                    {
                        int iRow = dt_XInvoice.Rows.IndexOf(drs[0]);
                        dgvx_XInvoice.Rows[iRow].Selected = true;
                    }
                }
            }
        }
        private void dgvx_XInvoice_SelectionChanged(object sender, EventArgs e)
        {
            //if (!bIgnoreChangeSelectionEvent)
            //{
            ShowOrEditSelectedRow(false);
            //}
        }

        private void btn_TimeSpan_Click(object sender, EventArgs e)
        {
            Form_Select_TimeSpan frm_timespan = new Form_Select_TimeSpan(this);
            if (frm_timespan.ShowDialog()== DialogResult.OK)
            {
                Program.Cursor_Wait();
                Init(DocTyp, true,false, ((SettingsUser)m_LMOUser.oSettings).mSettingsUserValues.FinancialYear,null);
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
            return " " + lng.s_from.s + " " + sDate(dtStartTime) + " " + lng.s_to.s +" "+ sDate(DayMinus(dtEndTime)) ;
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
            dtStartTime = new DateTime(xdtStartTime.Year, xdtStartTime.Month, xdtStartTime.Day);
            dtEndTime = new DateTime(xdtEndTime.Year, xdtEndTime.Month, xdtEndTime.Day); ;
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
            if (eMode == usrc_TableOfDocuments.eMode.All)
            {
                lbl_From_To.Text = lng.s_ShowAll.s;
                sFromTo_Suffix = "";
                ExtraCondition = null;
                lpar_ExtraCondition = null;
            }
            else
            {
                SetTimeSpanParam_Ex(xdtStartTime, xdtEndTime);
                switch (eMode)
                {
                    case usrc_TableOfDocuments.eMode.Today:
                        lbl_From_To.Text = lng.s_Today.s + " " + sDate(dtStartTime);
                        sFromTo_Suffix = sDate_Suffix(dtStartTime);
                        break;
                    case usrc_TableOfDocuments.eMode.ThisWeek:
                        lbl_From_To.Text = lng.s_ThisWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;

                    case usrc_TableOfDocuments.eMode.LastWeek:
                        lbl_From_To.Text = lng.s_LastWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfDocuments.eMode.ThisMonth:
                        lbl_From_To.Text = lng.s_ThisMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfDocuments.eMode.LastMonth:
                        lbl_From_To.Text = lng.s_LastMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfDocuments.eMode.ThisYear:
                        lbl_From_To.Text = lng.s_ThisYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfDocuments.eMode.LastYear:
                        lbl_From_To.Text = lng.s_LastYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfDocuments.eMode.TimeSpan:
                        lbl_From_To.Text = lng.s_TimeSpan.s + sTimeSpan();
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
                if (IsDocInvoice)
                {
                    if ((iColIndex_DocInvoice_Draft >= 0) && (iColIndex_DocInvoice_Invoice_Storno >= 0))
                    {
                        if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Draft])
                        {
                            e.CellStyle.BackColor = ColorDraft;
                            DataGridViewRow row = dgv.Rows[e.RowIndex];
                            row.Height = 64;

                        }
                        else 
                        {
                            DataGridViewRow row = dgv.Rows[e.RowIndex];
                            row.Height = 20;
                            e.CellStyle.BackColor = Color.White;
                          
                            if (Program.b_FVI_SLO)
                            {
                                if (dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_EOR] is string)
                                {
                                    e.CellStyle.BackColor = ColorFurs_InvoiceConfirmed;
                                  
                                }
                                else
                                {
                                    if (!(dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_FSI_SLO_ID] is System.DBNull))
                                    {
                                        e.CellStyle.BackColor = ColorFurs_SalesBookInvoiceNotConfirmed;
                                    }
                                }
                            }
                            if (IsStorno(dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Invoice_Storno]))
                            {
                                e.CellStyle.BackColor = ColorStorno;
                            }
                        }
                    }
                }
                else if (IsDocProformaInvoice)
                {
                    if (iColIndex_DocInvoice_Draft >= 0)
                    {
                        if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_DocInvoice_Draft])
                        {
                            e.CellStyle.BackColor = ColorDraft;
                        } 
                        else
                        {
                            e.CellStyle.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private bool IsStorno(object v)
        {
            if (v is bool)
            {
                return (bool)v;
            }
            else
            {
                return false;
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            Form_PrintReport frm_print = new Form_PrintReport(this);
            frm_print.ShowDialog();
        }

        private void dgvx_XInvoice_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If a column header was clicked
            if ((e.RowIndex == -1)&&(e.ColumnIndex>=0))
            {
                //And a row is selected
                if (!(dgvx_XInvoice.SelectedRows.Count == 0))
                {
                    //Record the unique value from the column called "Name"
                    string cellid = null;
                    if (IsDocInvoice)
                    {
                        cellid = "JOURNAL_DocInvoice_$_dinv_$$ID";
                    }
                    else
                    {
                        cellid = "JOURNAL_DocProformaInvoice_$_dpinv_$$ID";
                    }
                    dgSortingSelectedItem_ID = (long)dgvx_XInvoice.SelectedRows[0].Cells[cellid].Value;
                }
            }
        }

        private void dgvx_XInvoice_Sorted(object sender, EventArgs e)
        {
            if (dgSortingSelectedItem_ID >= 0)
            {
                foreach (DataGridViewRow dgRow in dgvx_XInvoice.Rows)
                {
                    //Locate the row after the sort
                    string cellid = null;
                    if (IsDocInvoice)
                    {
                        cellid = "JOURNAL_DocInvoice_$_dinv_$$ID";
                    }
                    else
                    {
                        cellid = "JOURNAL_DocProformaInvoice_$_dpinv_$$ID";
                    }

                    if ((long)dgRow.Cells[cellid].Value == dgSortingSelectedItem_ID)
                    {
                        //Clear the datagridview selections
                        dgvx_XInvoice.ClearSelection();
                        //Select the row at its new position
                        dgRow.Selected = true;
                        //Set currentcell using the 1st cell of the row in its new position
                        dgvx_XInvoice.CurrentCell = dgRow.Cells[0];
                        //Exit the routine
                        break;
                    }
                }
                dgSortingSelectedItem_ID = -1;
            }
        }
    }
}
