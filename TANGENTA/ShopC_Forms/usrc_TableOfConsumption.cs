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
using TangentaProperties;

namespace ShopC_Forms
{
    public partial class usrc_TableOfConsumption : UserControl
    {
       
        private LMOUser m_LMOUser = null;

        public enum eMode { All, Today, ThisWeek, LastWeek, ThisMonth, LastMonth, ThisYear, LastYear,ForDay, TimeSpan };
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
        public DataTable dt_XConsumption = new DataTable();

        private int m_iCurrentSelectedRow = -1;

        internal int iCurrentSelectedRow
        {
            get { return m_iCurrentSelectedRow; }
            set
            {
                m_iCurrentSelectedRow = value;
            }
        }

        private int iColIndex_Consumption_Draft = -1;
        private int iColIndex_Consumption_IssueDate = -1;
        private int iColIndex_Consumption_Storno = -1;
        private int iColIndex_Consumption_StornoReason = -1;
        private int idgvxColIndex_IssueDate = -1;


        private ConsumptionMan consM = null;

        public ConsumptionMan ConsM
        {
            get
            {
                return consM;
            }
            set
            {
                consM = value;
            }
        }

        public string ConsumptionTyp
        {
            get
            {
                if (consM != null)
                {
                    return consM.ConsumptionTyp;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsConsumptionWriteOff
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionWriteOff); }
        }

        public bool IsConsumptionOwnUse
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionOwnUse); }
        }

        public bool IsConsumptionAll
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionAll); }
        }

        public ID Current_Consumption_ID
        {
            get {
                    if (iCurrentSelectedRow >= 0)
                    {
                        if (dt_XConsumption.Rows.Count > 0)
                        {
                            if (iCurrentSelectedRow < dt_XConsumption.Rows.Count)
                            {
                                ID id = null;
                                id = tf.set_ID(dt_XConsumption.Rows[iCurrentSelectedRow]["JOURNAL_Consumption_$_cs_$$ID"]);
                                return id;
                            }
                        }
                    }

                    //if (m_LMOUser != null)
                    //{
                    //    string sDataSource = DBSync.DBSync.DataSource;
                    //    ID xDoc_ID = null;
                    //    ID xCurrent_Doc_ID = null;
                    //    if (ID.Validate(m_LMOUser.myOrganisation_Person_ID))
                    //    {
                    //        if (f_Current_Doc_ID.GetLast(ConsumptionTyp, sDataSource, m_LMOUser.myOrganisation_Person_ID, myOrg.m_myOrg_Office.ElectronicDevice_ID, ref xDoc_ID, ref xCurrent_Doc_ID))
                    //        {
                    //            if (ID.Validate(xDoc_ID))
                    //            {
                    //                iCurrentSelectedRow = FindRow(xDoc_ID);
                    //                if (iCurrentSelectedRow >= 0)
                    //                {
                    //                    return xDoc_ID;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    return ID.Invalid;
                }
        }

        private int FindRow(ID xDoc_ID)
        {
            if (ID.Validate(xDoc_ID))
            {
                foreach (DataRow dr in dt_XConsumption.Rows)
                {
                    ID xid = tf.set_ID(dr["JOURNAL_" + ConsumptionTyp + "_$_cs_$$ID"]);
                    if (ID.Validate(xid))
                    {
                        if (xDoc_ID.Equals(xid))
                        {
                            int ix = dt_XConsumption.Rows.IndexOf(dr);
                            return ix;
                        }
                    }
                }
            }
            return -1;

        }

        public usrc_TableOfConsumption()
        {
            InitializeComponent();
            ExtensionMethods.DoubleBuffered(this.dgvx_XConsumption, true);
         

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

        public void Activate_dgvx_XConsumption_SelectionChanged()
        {
            dgvx_XConsumption.ClearSelection();
            this.dgvx_XConsumption.SelectionChanged += this.dgvx_XConsumption_SelectionChanged;
            dgvx_XConsumption.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvx_XInvoice.MultiSelect = false;
            if (dt_XConsumption.Rows.Count>0)
            {
                if (iCurrentSelectedRow>=0)
                {
                    if (iCurrentSelectedRow< dt_XConsumption.Rows.Count)
                    {
                        dgvx_XConsumption.Rows[iCurrentSelectedRow].Selected = true;
                    }
                }
            }
        }


        public int Init(ConsumptionMan xdocM,
                          bool bNew,
                          bool bInitialise_usrc_Invoice,
                          int iFinancialYear,
                          ID Consumption_ID_To_show)
        {
            consM = xdocM;

            ColorDraft = TangentaProperties.Properties.Settings.Default.ColorDraft;
            ColorStorno = TangentaProperties.Properties.Settings.Default.ColorStorno;
            ColorFurs_InvoiceConfirmed = TangentaProperties.Properties.Settings.Default.ColorFurs_InvoiceConfirmed;
            ColorFurs_SalesBookInvoiceConfirmed = TangentaProperties.Properties.Settings.Default.ColorFurs_SalesBookInvoiceConfirmed;
            ColorFurs_SalesBookInvoiceNotConfirmed = TangentaProperties.Properties.Settings.Default.ColorFurs_SalesBookInvoiceNotConfirmed;


            int iRowsCount = -1;
            iRowsCount = Init_Consumption(true, bNew, iFinancialYear);
            if (iRowsCount>0)
            {
                if (ID.Validate(Current_Consumption_ID))
                {
                    ShowOrEditSelectedRow(Current_Consumption_ID);
                }
            }
            //if (bNew)
            //{
            //    ShowOrEditSelectedRow(false);
            //}
            //else
            //{
            //    if (ID.Validate(Doc_ID_To_show))
            //    {
            //        ShowOrEditSelectedRow(Doc_ID_To_show);
            //    }
            //}

            return iRowsCount;
        }

     

        private int Init_Consumption(bool bInvoice, bool bNew, int iFinancialYear)
        {
            m_bInvoice = bInvoice;
            int iRowsCount = -1;
            iCurrentSelectedRow = -1;
            string s_JOURNAL_Consumption_Type_ID_ConsumptionOwnUseDraftTime = GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionOwnUseDraftTime.ID.ToString();
            string s_JOURNAL_Consumption_Type_ID_ConsumptionOwnUseStornoTime = GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionOwnUseStornoTime.ID.ToString();
            string s_JOURNAL_Consumption_Type_ID_ConsumptionOwnUseTime = GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionOwnUseTime.ID.ToString();


            if (IsConsumptionWriteOff)
            {
                    cond = " where woao.IssueDate is not null ";
            }
            else if (IsConsumptionOwnUse)
            {
                    cond = " where ouao.IssueDate is not null  ";
            }
            else if (IsConsumptionAll)
            {
                cond = "";
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice:DocTyp=" + ConsumptionTyp + " not implemented");
                return -1;
            }



            if (ExtraCondition!=null)
            {
                s_JOURNAL_Consumption_Type_ID_ConsumptionOwnUseDraftTime = GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionOwnUseTime.ID.ToString();
                s_JOURNAL_Consumption_Type_ID_ConsumptionOwnUseStornoTime = GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionOwnUseStornoTime.ID.ToString();
                cond += " and " + ExtraCondition;
            }
            else
            {
                lpar_ExtraCondition = null;
            }

            if (iFinancialYear > 0)
            {
                cond += " and JOURNAL_Consumption_$_cs.FinancialYear = " + iFinancialYear.ToString();
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
                if (IsConsumptionWriteOff)
                {
                    lng.s_lbl_SelectionDescription_AllInvoices.Text(lbl_SelectionDescription);
                }
                else if (IsConsumptionOwnUse)
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

                //if (IsConsumptionWriteOff)
                //{
                //    if (spar_TaxID != null)
                //    {
                //        cond_Atom_myOrganisation_Person = " and JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                //             + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                //             + " and JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                //    }
                //    else
                //    {
                //        cond_Atom_myOrganisation_Person = " and JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                //             + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;
                //    }
                //}
                //else if (IsConsumptionOwnUse)
                //{
                //    if (spar_TaxID != null)
                //    {
                //        cond_Atom_myOrganisation_Person = " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                //         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                //         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                //    }
                //    else
                //    {
                //        cond_Atom_myOrganisation_Person = " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                //         + " and JOURNAL_DocProformaInvoice_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;
                //    }
                //}


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

                if (IsConsumptionWriteOff)
                {
                    lng.s_lbl_SelectionDescription_AllInvoicesOfUser.Text(lbl_SelectionDescription, s_myorg_person);
                }
                else if (IsConsumptionOwnUse)
                {
                    lng.s_lbl_SelectionDescription_AllProformaInvoices.Text(lbl_SelectionDescription, s_myorg_person);
                }
            }

            sql = @"SELECT 

            JOURNAL_Consumption_$_cs_$_cst.Name AS JOURNAL_Consumption_$_cs_$_cst_$$Name,
            JOURNAL_Consumption_$_cs_$_cst.Description AS JOURNAL_Consumption_$_cs_$_cst_$$Description,
            JOURNAL_Consumption_$_cs.FinancialYear AS JOURNAL_Consumption_$_cs_$$FinancialYear,
            JOURNAL_Consumption_$_cs.NumberInFinancialYear AS JOURNAL_Consumption_$_cs_$$NumberInFinancialYear,
            JOURNAL_Consumption_$_cs.Draft AS JOURNAL_Consumption_$_cs_$$Draft,
            JOURNAL_Consumption_$_cs.DraftNumber AS JOURNAL_Consumption_$_cs_$$DraftNumber,
            JOURNAL_Consumption_$_cs.NetSum AS JOURNAL_Consumption_$_cs_$$NetSum,
            JOURNAL_Consumption_$_cs.EndSum AS JOURNAL_Consumption_$_cs_$$EndSum,
            JOURNAL_Consumption_$_cs.TaxSum AS JOURNAL_Consumption_$_cs_$$TaxSum,
            JOURNAL_Consumption_$_cs.GrossSum AS JOURNAL_Consumption_$_cs_$$GrossSum,
            JOURNAL_Consumption_$_cs.Storno AS JOURNAL_Consumption_$_cs_$$Storno,
            JOURNAL_Consumption.EventTime AS JOURNAL_Consumption_$$EventTime,
            JOURNAL_Consumption_$_awperiod_$_aed.Name AS JOURNAL_Consumption_$_awperiod_$_aed_$$Name,
            JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.Name AS JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice_$$Name,
            JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName AS JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice_$$ShortName,
            JOURNAL_Consumption_$_awperiod.LoginTime AS JOURNAL_Consumption_$_awperiod_$$LoginTime,
            JOURNAL_Consumption_$_awperiod.LogoutTime AS JOURNAL_Consumption_$_awperiod_$$LogoutTime,
            JOURNAL_Consumption_$_awperiod_$_awperiodt.Name AS JOURNAL_Consumption_$_awperiod_$_awperiodt_$$Name,
            JOURNAL_Consumption_$_awperiod_$_awperiodt.Description AS JOURNAL_Consumption_$_awperiod_$_awperiodt_$$Description,

            woao.IssueDate as IssueDate_WriteOff,
            wor.Name as WriteOff_ReasonName,
            wor.Description as WriteOff_ReasonDescription,
            ouao.IssueDate as IssueDate_OwnUse,
            our.Name as OwnUse_ReasonName,
            our.Description as OwnUse_ReasonDescription,

            JOURNAL_Consumption_$_cs_$_cst.Name AS JOURNAL_Consumption_$_cs_$_cst_$$Name,
            JOURNAL_Consumption_$_cs_$_cst.Description AS JOURNAL_Consumption_$_cs_$_cst_$$Description,
            JOURNAL_Consumption_$_cs.Consumption_Reference_ID AS JOURNAL_Consumption_$_cs_$$Consumption_Reference_ID,
            JOURNAL_Consumption_$_cs.Consumption_Reference_Type AS JOURNAL_Consumption_$_cs_$$Consumption_Reference_Type,

            JOURNAL_Consumption_$_cs_$_acur.Name AS JOURNAL_Consumption_$_cs_$_acur_$$Name,
            JOURNAL_Consumption_$_cs_$_acur.Abbreviation AS JOURNAL_Consumption_$_cs_$_acur_$$Abbreviation,
            JOURNAL_Consumption_$_cs_$_acur.Symbol AS JOURNAL_Consumption_$_cs_$_acur_$$Symbol,
            JOURNAL_Consumption_$_cs_$_acur.CurrencyCode AS JOURNAL_Consumption_$_cs_$_acur_$$CurrencyCode,
            JOURNAL_Consumption_$_cs_$_acur.DecimalPlaces AS JOURNAL_Consumption_$_cs_$_acur_$$DecimalPlaces,
         
            JOURNAL_Consumption_$_jct.Name AS JOURNAL_Consumption_$_jct_$$Name,
            JOURNAL_Consumption_$_jct.Description AS JOURNAL_Consumption_$_jct_$$Description,

            JOURNAL_Consumption_$_cs.ID AS JOURNAL_Consumption_$_cs_$$ID,
            JOURNAL_Consumption_$_awperiod_$_awperiodt.ID AS JOURNAL_Consumption_$_awperiod_$_awperiodt_$$ID,
            JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ID AS JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice_$$ID,
            JOURNAL_Consumption_$_cs_$_cst.ID AS JOURNAL_Consumption_$_cs_$_cst_$$ID,
            JOURNAL_Consumption_$_awperiod.ID AS JOURNAL_Consumption_$_awperiod_$$ID,
            JOURNAL_Consumption_$_awperiod_$_aed.ID AS JOURNAL_Consumption_$_awperiod_$_aed_$$ID,
            JOURNAL_Consumption_$_cs_$_acur.ID AS JOURNAL_Consumption_$_cs_$_acur_$$ID,
            JOURNAL_Consumption_$_jct.ID AS JOURNAL_Consumption_$_jct_$$ID,
            JOURNAL_Consumption.ID

            FROM JOURNAL_Consumption
            INNER JOIN JOURNAL_Consumption_Type JOURNAL_Consumption_$_jct ON JOURNAL_Consumption.JOURNAL_Consumption_Type_ID = JOURNAL_Consumption_$_jct.ID
            INNER JOIN Consumption JOURNAL_Consumption_$_cs ON JOURNAL_Consumption.Consumption_ID = JOURNAL_Consumption_$_cs.ID
            left join WriteOffAddOn woao on woao.Consumption_ID = JOURNAL_Consumption_$_cs.ID
            left join WriteOffReason wor on wor.ID = woao.WriteOffReason_ID
            left join OwnUseAddOn ouao on ouao.Consumption_ID = JOURNAL_Consumption_$_cs.ID
            left join OwnUseReason our on our.ID = ouao.OwnUseReason_ID
            LEFT JOIN Atom_Currency JOURNAL_Consumption_$_cs_$_acur ON JOURNAL_Consumption_$_cs.Atom_Currency_ID = JOURNAL_Consumption_$_cs_$_acur.ID
            LEFT JOIN ConsumptionType JOURNAL_Consumption_$_cs_$_cst ON JOURNAL_Consumption_$_cs.ConsumptionType_ID = JOURNAL_Consumption_$_cs_$_cst.ID
            LEFT JOIN Atom_WorkPeriod JOURNAL_Consumption_$_awperiod ON JOURNAL_Consumption.Atom_WorkPeriod_ID = JOURNAL_Consumption_$_awperiod.ID
            LEFT JOIN Atom_WorkPeriod_TYPE JOURNAL_Consumption_$_awperiod_$_awperiodt ON JOURNAL_Consumption_$_awperiod.Atom_WorkPeriod_TYPE_ID = JOURNAL_Consumption_$_awperiod_$_awperiodt.ID 
            LEFT JOIN Atom_ElectronicDevice JOURNAL_Consumption_$_awperiod_$_aed ON JOURNAL_Consumption_$_awperiod.Atom_ElectronicDevice_ID = JOURNAL_Consumption_$_awperiod_$_aed.ID 
            LEFT JOIN Atom_Office JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice ON JOURNAL_Consumption_$_awperiod_$_aed.Atom_Office_ID = JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ID 
            ";

            if (dt_XConsumption != null)
            {
                dt_XConsumption.Dispose();
                dt_XConsumption = null;
                dt_XConsumption = new DataTable();
            }
            else
            {
                dt_XConsumption = new DataTable();
            }
            
            string Err = null;
            iColIndex_Consumption_Draft = -1;
            iColIndex_Consumption_Storno = -1;
            //iColIndex_Consumption_StornoReason = -1;
            dgvx_XConsumption.DataSource = null;
            bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XConsumption, sql, lpar_ExtraCondition, ref Err);
            if (bRes)
            {
                dgvx_XConsumption.DataSource = dt_XConsumption;

                if (!bNew)
                {
                    DataGridViewSelectedRowCollection dgvxc = dgvx_XConsumption.SelectedRows;
                    if (dgvxc.Count > 0)
                    {
                        DataGridViewRow dgvr = dgvxc[0];
                        iCurrentSelectedRow = dgvx_XConsumption.Rows.IndexOf(dgvr);
                    }
                }

                iColIndex_Consumption_Draft = dt_XConsumption.Columns.IndexOf("JOURNAL_Consumption_$_cs_$$Draft");
                iColIndex_Consumption_Storno = dt_XConsumption.Columns.IndexOf("JOURNAL_Consumption_$_cs_$$Storno");

                //iColIndex_Consumption_StornoReason = dt_XConsumption.Columns.IndexOf("StornoReason");
                //iColIndex_Consumption_IssueDate = dt_XConsumption.Columns.IndexOf("IssueDate");
                //dgvx_XConsumption.Columns[iColIndex_Consumption_IssueDate].HeaderText = lng.s_IssueDate.s;
                //dgvx_XConsumption.Columns[iColIndex_Consumption_StornoReason].HeaderText = lng.s_StornoReason.s;

                 

                 

                SetLabels();
                
                SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(JOURNAL_Consumption)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XConsumption, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                Global.g.DataGridCollumnVisible(dgvx_XConsumption,false);
                DataGridViewColumn dgvc_ConsumptionType_Name = dgvx_XConsumption.Columns["JOURNAL_Consumption_$_cs_$_cst_$$Name"];
                dgvc_ConsumptionType_Name.DisplayIndex = 1;
                dgvc_ConsumptionType_Name.Visible = true;
                dgvc_ConsumptionType_Name.ReadOnly = true;
                if (dgvx_XConsumption.Columns.Contains("IssueDate"))
                {
                    idgvxColIndex_IssueDate = dgvx_XConsumption.Columns.IndexOf(dgvx_XConsumption.Columns["IssueDate"]);
                }
                else
                {
                    DataGridViewColumn dgvc_IssueDate = new CalenderColumn.CalendarColumn();
                    dgvc_IssueDate.Name = "IssueDate";
                    idgvxColIndex_IssueDate =dgvx_XConsumption.Columns.Add(dgvc_IssueDate);
                    DataGridViewColumn dgvxc_IssueDate = dgvx_XConsumption.Columns["IssueDate"];
                    dgvxc_IssueDate.DisplayIndex = 2;
                    dgvxc_IssueDate.Visible = true;
                    dgvxc_IssueDate.HeaderText = lng.s_IssueDate.s;
                    dgvxc_IssueDate.ReadOnly = false;
                }

                DataGridViewColumn dgvxc_DraftNumber = dgvx_XConsumption.Columns["JOURNAL_Consumption_$_cs_$$DraftNumber"];
                dgvxc_DraftNumber.DisplayIndex = 3;
                dgvxc_DraftNumber.Visible = true;
                dgvxc_DraftNumber.ReadOnly = true;

                iRowsCount = dt_XConsumption.Rows.Count;
                for (int i=0;i< iRowsCount;i++)
                {
                    DataRow dr = dt_XConsumption.Rows[i];
                    DateTime_v IssueDate_WriteOff_v = tf.set_DateTime(dr["IssueDate_WriteOff"]);
                    if (IssueDate_WriteOff_v != null)
                    {
                        dgvx_XConsumption.Rows[i].Cells[idgvxColIndex_IssueDate].Value = IssueDate_WriteOff_v.v;
                    }
                    else
                    {
                        DateTime_v IssueDate_OwnUse_v = tf.set_DateTime(dr["IssueDate_OwnUse"]);
                        if (IssueDate_OwnUse_v != null)
                        {
                            dgvx_XConsumption.Rows[i].Cells[idgvxColIndex_IssueDate].Value = IssueDate_OwnUse_v.v;
                        }
                    }
                }

                if (!bNew)
                {
                    if (iRowsCount > 0)
                    {
                        if (iCurrentSelectedRow >= 0)
                        {
                            dgvx_XConsumption.Rows[iCurrentSelectedRow].Selected = true;
                        }
                        else
                        {
                            iCurrentSelectedRow = 0;
                        }
                    }
                }
                //bIgnoreChangeSelectionEvent = false;
               
                //    iColIndex_Consumption_Draft = dt_XConsumption.Columns.IndexOf("JOURNAL_DocProformaInvoice_$_dpinv_$$Draft");
                //    iColIndex_Consumption_PaymentType_Identification = dt_XConsumption.Columns.IndexOf("PaymentType_Identification");
                //    iColIndex_Consumption_PaymentType_Name = dt_XConsumption.Columns.IndexOf("PaymentType_Name");
                //    iColIndex_DocProformaInvoice_IssueDate = dt_XConsumption.Columns.IndexOf("IssueDate");
                //    dgvx_XConsumption.Columns[iColIndex_DocProformaInvoice_IssueDate].HeaderText = lng.s_IssueDate.s;

                //    dgvx_XConsumption.Columns[iColIndex_Consumption_PaymentType_Identification].Visible = false;

                //    SetLabels();
                //    SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DocProformaInvoice)));
                //    tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XConsumption, DBSync.DBSync.DB_for_Tangenta.m_DBTables);
                //    iRowsCount = dt_XConsumption.Rows.Count;
                //    if (!bNew)
                //    {
                //        if (iRowsCount > 0)
                //        {
                //            string sdb = DBSync.DBSync.DataBase;
                //            if (sdb != null)
                //            {
                //                if (!TangentaProperties.Properties.Settings.Default.Current_DataBase.Equals(sdb))
                //                {
                //                    TangentaProperties.Properties.Settings.Default.Current_DataBase = sdb;
                //                    //TangentaProperties.Properties.Settings.Default.Current_DocProformaInvoice_ID = "";
                //                    TangentaProperties.Properties.Settings.Default.Save();
                //                }
                //            }
                //            if (iCurrentSelectedRow >= 0)
                //            {
                //                dgvx_XConsumption.Rows[iCurrentSelectedRow].Selected = true;
                //            }
                //            else if (false /*TangentaProperties.Properties.Settings.Default.Current_DocProformaInvoice_ID.Length>0*/)
                //            {
                //                ID my_Current_DocProformaInvoice_ID = new ID(1/*TangentaProperties.Properties.Settings.Default.Current_DocProformaInvoice_ID*/);
                //                DataRow[] dr_Current = dt_XConsumption.Select("JOURNAL_DocProformaInvoice_$_dpinv_$$ID = " + my_Current_DocProformaInvoice_ID.ToString());
                //                if (dr_Current.Count() > 0)
                //                {
                //                    iCurrentSelectedRow = dt_XConsumption.Rows.IndexOf(dr_Current[0]);
                //                    dgvx_XConsumption.Rows[iCurrentSelectedRow].Selected = true;
                //                }
                //                else
                //                {
                //                    iCurrentSelectedRow = 0;
                //                }
                //            }
                //            else
                //            {
                //                iCurrentSelectedRow = 0;
                //            }
                //        }
                //    }
                //bIgnoreChangeSelectionEvent = false;
                //}
            }
            else
            {
                //bIgnoreChangeSelectionEvent = false;
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice Err=" + Err);
            }
            return iRowsCount;
        }

        public void BeforeRemove()
        {
            this.dgvx_XConsumption.SelectionChanged -= dgvx_XConsumption_SelectionChanged;
            this.dgvx_XConsumption.DataSource = null;
            this.Controls.Remove(dgvx_XConsumption);
            dgvx_XConsumption.Dispose();
            this.dt_XConsumption.Clear();
            this.dt_XConsumption.Columns.Clear();
            this.iCurrentSelectedRow = -1;
        }

        public void Clear()
        {
            this.dgvx_XConsumption.DataSource = null;
            this.dt_XConsumption.Clear();
            this.dt_XConsumption.Columns.Clear();
            this.iCurrentSelectedRow = -1;
        }

        private decimal Sum(string ColumnName)
        {
            decimal sum = 0;
            int iColDraft = -1;
           
            iColDraft = dt_XConsumption.Columns.IndexOf("JOURNAL_Consumption_$_cs_$$Draft");
          
            int iCol = dt_XConsumption.Columns.IndexOf(ColumnName);

            int iCount = dt_XConsumption.Rows.Count;
            int i = 0;
            for (i=0;i<iCount;i++)
            {
                if ((bool)dt_XConsumption.Rows[i][iColDraft])
                {
                    continue;
                }
                else
                { 
                    sum += (decimal)dt_XConsumption.Rows[i][iCol];
                }
            }
            return sum;
        }


        private void SetLabels()
        {
            if (dt_XConsumption.Rows.Count>0)
            { 
                string currency_symbol = GlobalData.BaseCurrency.Symbol;

                decimal gross_sum = 0;
                decimal net_sum = 0;
                decimal tax_sum = 0;
              
                gross_sum = Sum("JOURNAL_Consumption_$_cs_$$GrossSum");
                net_sum = Sum("JOURNAL_Consumption_$_cs_$$NetSum");
                tax_sum = Sum("JOURNAL_Consumption_$_cs_$$TaxSum");
                
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
                    DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_XConsumption.SelectedCells;
                    if (dgvCellCollection.Count >= 1)
                    {
                        //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                        if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_Consumption_$_cs_$$ID"].Value is long)
                        {
                            ID Identity = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["JOURNAL_Consumption_$_cs_$$ID"].Value);
                            this.iCurrentSelectedRow = dgvCellCollection[0].RowIndex;
                            SelectedInvoiceChanged(Identity, bInitialise);
                            return;
                        }

                    }
                    SelectedInvoiceChanged(null, bInitialise);
                }
            }
        }


        private void ShowOrEditSelectedRow(ID Consumption_ID_to_show)
        {
            if (ID.Validate(Consumption_ID_to_show))
            {
                DataRow[] drs = dt_XConsumption.Select("JOURNAL_Consumption_$_cs_$$ID = " + Consumption_ID_to_show.ToString());
                if (drs.Count() > 0)
                {
                    dgvx_XConsumption.ClearSelection();
                    int iRow = dt_XConsumption.Rows.IndexOf(drs[0]);
                    dgvx_XConsumption.Rows[iRow].Selected = true;
                    dgvx_XConsumption.CurrentCell = dgvx_XConsumption.Rows[iRow].Cells["JOURNAL_Consumption_$_cs_$_cst_$$Name"];
                }
            }
        }
        private void dgvx_XConsumption_SelectionChanged(object sender, EventArgs e)
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
                Global.g.Cursor_Wait(this);
                Init(consM, true,false, ((SettingsUser)m_LMOUser.oSettings).mSettingsUserValues.FinancialYear,null);
                Global.g.Cursor_Arrow(this);
            }
        }


        internal void SetMode(eMode eMode, string sText)
        {
            Mode = eMode;
            lbl_From_To.Text = sText;
        }

        private string sTimeSpan()
        {
            return " " + lng.s_from.s + " " + sDate(dtStartTime) + " " + lng.s_to.s +" "+ sDate(dtEndTime) ;
        }

        private string sTimeSpan_Suffix()
        {
            return "_"+sDate_Suffix(dtStartTime) + "__" + sDate_Suffix(dtEndTime);
        }

        private DateTime DayMinus(DateTime date)
        {
            DateTime dt = date.AddDays(-1);
            return dt;
        }

        private DateTime NextDay(DateTime date)
        {
            DateTime justdate = new DateTime(date.Year, date.Month, date.Day);
            DateTime dt = justdate.AddDays(1);
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
            string sparam1 = "@par_ConsumptionTime_Start";
            string sparam2 = "@par_ConsumptionTime_End";
            dtStartTime = new DateTime(xdtStartTime.Year, xdtStartTime.Month, xdtStartTime.Day);
            dtEndTime = new DateTime(xdtEndTime.Year, xdtEndTime.Month, xdtEndTime.Day); ;
            lpar_ExtraCondition = null;
            lpar_ExtraCondition = new List<DBConnectionControl40.SQL_Parameter>();
            SQL_Parameter par1 = new SQL_Parameter(sparam1, SQL_Parameter.eSQL_Parameter.Datetime, false, dtStartTime);
            lpar_ExtraCondition.Add(par1);
            DateTime dtNextDay = NextDay(dtEndTime);
            SQL_Parameter par2 = new SQL_Parameter(sparam2, SQL_Parameter.eSQL_Parameter.Datetime, false, dtNextDay);
            lpar_ExtraCondition.Add(par2);
            if (IsConsumptionWriteOff)
            {
                ExtraCondition = " (JOURNAL_Consumption_$$EventTime >= " + sparam1 + ") and ( JOURNAL_Consumption_$$EventTime < " + sparam2 + ") ";
            }
            else if (IsConsumptionOwnUse)
            {
                ExtraCondition = " (JOURNAL_DocProformaInvoice_$$EventTime >= " + sparam1 + ") and ( JOURNAL_DocProformaInvoice_$$EventTime < " + sparam2 + ") ";
            }

        }
        public void SetTimeSpanParam(eMode eMode, DateTime xdtStartTime, DateTime xdtEndTime)
        {
            Mode = eMode;
            if (eMode == usrc_TableOfConsumption.eMode.All)
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
                    case usrc_TableOfConsumption.eMode.Today:
                        lbl_From_To.Text = lng.s_Today.s + " " + sDate(dtStartTime);
                        sFromTo_Suffix = sDate_Suffix(dtStartTime);
                        break;
                    case usrc_TableOfConsumption.eMode.ThisWeek:
                        lbl_From_To.Text = lng.s_ThisWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;

                    case usrc_TableOfConsumption.eMode.LastWeek:
                        lbl_From_To.Text = lng.s_LastWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.ThisMonth:
                        lbl_From_To.Text = lng.s_ThisMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.LastMonth:
                        lbl_From_To.Text = lng.s_LastMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.ThisYear:
                        lbl_From_To.Text = lng.s_ThisYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.LastYear:
                        lbl_From_To.Text = lng.s_LastYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.TimeSpan:
                        lbl_From_To.Text = lng.s_TimeSpan.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_TableOfConsumption.eMode.ForDay:
                        lbl_From_To.Text = lng.s_ForDay.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                }
            }
        }

        private void dgvx_XConsumption_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex>=0)
            {
                if (IsConsumptionWriteOff)
                {
                    if ((iColIndex_Consumption_Draft >= 0) && (iColIndex_Consumption_Storno >= 0))
                    {
                        if ((bool)dt_XConsumption.Rows[e.RowIndex][iColIndex_Consumption_Draft])
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
                          
                            if (IsStorno(dt_XConsumption.Rows[e.RowIndex][iColIndex_Consumption_Storno]))
                            {
                                e.CellStyle.BackColor = ColorStorno;
                            }
                        }
                    }
                }
                else if (IsConsumptionOwnUse)
                {
                    if (iColIndex_Consumption_Draft >= 0)
                    {
                        if ((bool)dt_XConsumption.Rows[e.RowIndex][iColIndex_Consumption_Draft])
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

        private void dgvx_XConsumption_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //If a column header was clicked
            if ((e.RowIndex == -1)&&(e.ColumnIndex>=0))
            {
                //And a row is selected
                if (!(dgvx_XConsumption.SelectedRows.Count == 0))
                {
                    //Record the unique value from the column called "Name"
                    string cellid = null;
                  
                    cellid = "JOURNAL_Consumption_$_cs_$$ID";
                   
                    dgSortingSelectedItem_ID = (long)dgvx_XConsumption.SelectedRows[0].Cells[cellid].Value;
                }
            }
        }

        private void dgvx_XConsumption_Sorted(object sender, EventArgs e)
        {
            if (dgSortingSelectedItem_ID >= 0)
            {
                foreach (DataGridViewRow dgRow in dgvx_XConsumption.Rows)
                {
                    //Locate the row after the sort
                    string cellid = null;
                    if (IsConsumptionWriteOff)
                    {
                        cellid = "JOURNAL_Consumption_$_cs_$$ID";
                    }
                    else
                    {
                        cellid = "JOURNAL_DocProformaInvoice_$_dpinv_$$ID";
                    }

                    if ((long)dgRow.Cells[cellid].Value == dgSortingSelectedItem_ID)
                    {
                        //Clear the datagridview selections
                        dgvx_XConsumption.ClearSelection();
                        //Select the row at its new position
                        dgRow.Selected = true;
                        //Set currentcell using the 1st cell of the row in its new position
                        dgvx_XConsumption.CurrentCell = dgRow.Cells[0];
                        //Exit the routine
                        break;
                    }
                }
                dgSortingSelectedItem_ID = -1;
            }
        }
    }
}
