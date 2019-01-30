using DBConnectionControl40;
using DBTypes;
using LoginControl;
using PriseLists;
//using ShopB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using TangentaPrint;
using TangentaProperties;

namespace ShopC_Forms
{
    public class ConsumptionEditor
    {
        public delegate void delegate_control_SetDraftButtons();
        public delegate void delegate_control_SetViewButtons();

        public delegate void delegate_control_AddOn_Show(ID ID);
        public delegate void delegate_control_AddHandler();
        public delegate void delegate_control_RemoveHandler();

        public delegate void delegate_control_InvoiceNumber_Text(string s);
        public delegate void delegate_control_SetMode(ConsumptionEditor.emode mode);
        public delegate void delegate_control_SetCurrentInvoice_SelectedShopB_Items();
        public delegate void delegate_control_SetCurrentInvoice_SelectedShopC_Items();

        public delegate void delegate_control_ShowStornoCheckBox(bool bvisible);
        public delegate void delegate_control_SetStornoCheckBox(bool bchecked);
        public delegate void delegate_control_ShopC_Reset();
        public delegate void delegate_control_ShopC_Clear();

        public delegate void delegate_control_btn_Issue_Show(bool bvisible);
        public delegate void delegate_control_lbl_Sum_ForeColor(Color color);
        public delegate void delegate_control_lbl_Sum_Text(string s);

        public delegate bool delegate_control_Check_WriteOffAddOn(WriteOffAddOn addOnWriteOff);
        public delegate bool delegate_control_Check_OwnUseAddOn(OwnUseAddOn addOnOwnUse);

        public delegate bool delegate_control_Get_WriteOff_AddOn(bool xbPrint);
        public delegate bool delegate_control_Get_OwnUse_AddOn(bool xbPrint);

        public delegate bool delegate_control_DoCurrent(ID xID, Transaction transaction);
        public delegate bool delegate_control_Printing_Consumption(Control parnetcontrol);

        public delegate void delegate_ConsumptionSaved(ID Consumption_id);
        public delegate void delegate_DocProformaInvoiceSaved(ID DocProformaInvoice_id);

        public delegate void delegate_control_Set_ShowShops(string eShopsShow);

        public delegate bool delegate_control_m_usrc_ShopC_usrc_PriceList1_Init(ID Currency_ID, usrc_PriceList_Edit.eShopType xeShopType, string ShopsInUse, ref ID price_list_id, ref string Err);

        public delegate void delegate_control_usrc_PriceList_Ask_To_Update(char chShop, DataTable dt_ShopB_Item_NotIn_PriceList);


        public delegate bool delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data( DataTable dtPurchasePrices);

        public delegate void delegate_control_usrc_Customer_Show_Customer_Person(TangentaDB.CurrentDoc x_CurrentDoc);

        public delegate void delegate_control_usrc_Customer_Show_Customer_Organisation(TangentaDB.CurrentDoc x_CurrentDoc);


        public delegate void delegate_Customer_Person_Changed(ID Customer_Person_ID);
        public delegate void delegate_Customer_Org_Changed(ID Customer_Org_ID);

        public delegate void delegate_Storno(bool bStorno);
        public delegate void delegate_control_chk_Storno_Check(bool bcheck);

        public Form MainForm = null;

        public LoginControl.LMOUser m_LMOUser = null;

        public xUnitList m_xUnitList = null;

        internal ConsumptionMan ConsM = null;

        public DataTable dtPurchasePrice_Item = null;

        TangentaTableClass.SQL_Database_Tables_Definition td = null;

        public class DoCurrent_delegates
        {
            public usrc_PriceList m_usrc_PriceListC;
            public delegate_control_SetDraftButtons m_delegate_control_SetDraftButtons;
            public delegate_control_SetViewButtons m_delegate_control_SetViewButtons;
            public delegate_control_AddOn_Show m_delegate_control_AddOn_Show;
            public delegate_control_AddHandler m_delegate_control_AddHandler;
            public delegate_control_RemoveHandler m_delegate_control_RemoveHandler;
            public delegate_control_InvoiceNumber_Text m_delegate_control_InvoiceNumber_Text;
            public delegate_control_SetMode m_delegate_control_SetMode;
            public delegate_control_SetCurrentInvoice_SelectedShopC_Items m_delegate_control_SetCurrentInvoice_SelectedShopC_Items;
            public delegate_control_ShowStornoCheckBox m_delegate_control_ShowStornoCheckBox;
            public delegate_control_SetStornoCheckBox m_delegate_control_SetStornoCheckBox;
            public delegate_control_ShopC_Reset m_delegate_control_ShopC_Reset;
            public delegate_control_ShopC_Clear m_delegate_control_ShopC_Clear;
            public delegate_control_btn_Issue_Show m_delegate_control_btn_Issue_Show;
            public delegate_control_lbl_Sum_ForeColor m_delegate_control_lbl_Sum_ForeColor;
            public delegate_control_lbl_Sum_Text m_delegate_control_lbl_Sum_Text;
            public delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data m_delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data;

            public DoCurrent_delegates(
                                        usrc_PriceList xusrc_PriceListC,
                                        //delegate_control_Set_ShowShops xdelegate_control_Set_ShowShops,
                                        //delegate_control_SetDraftButtons xdelegate_control_SetDraftButtons,
                                        //delegate_control_SetViewButtons xdelegate_control_SetViewButtons,
                                        delegate_control_AddOn_Show xdelegate_control_AddOn_Show,
                                        delegate_control_AddHandler xdelegate_control_AddHandler,
                                        delegate_control_RemoveHandler xdelegate_control_RemoveHandler,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                        delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                        delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                        delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                        delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                        delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                        delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                        delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text,
                                        delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data)
            {
                m_usrc_PriceListC = xusrc_PriceListC;
                //m_delegate_control_SetDraftButtons = xdelegate_control_SetDraftButtons;
                //m_delegate_control_SetViewButtons = xdelegate_control_SetViewButtons;
                m_delegate_control_AddOn_Show = xdelegate_control_AddOn_Show;
                m_delegate_control_AddHandler = xdelegate_control_AddHandler;
                m_delegate_control_RemoveHandler = xdelegate_control_RemoveHandler;
                m_delegate_control_InvoiceNumber_Text = xdelegate_control_InvoiceNumber_Text;
                m_delegate_control_SetMode = xdelegate_control_SetMode;
                m_delegate_control_SetCurrentInvoice_SelectedShopC_Items = xdelegate_control_SetCurrentInvoice_SelectedShopC_Items;
                m_delegate_control_ShowStornoCheckBox = xdelegate_control_ShowStornoCheckBox;
                m_delegate_control_SetStornoCheckBox = xdelegate_control_SetStornoCheckBox;
                m_delegate_control_ShopC_Reset = xdelegate_control_ShopC_Reset;
                m_delegate_control_ShopC_Clear = xdelegate_control_ShopC_Clear;
                m_delegate_control_btn_Issue_Show = xdelegate_control_btn_Issue_Show;
                m_delegate_control_lbl_Sum_ForeColor = xdelegate_control_lbl_Sum_ForeColor;
                m_delegate_control_lbl_Sum_Text = xdelegate_control_lbl_Sum_Text;
                m_delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data = xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data;
            }


            public void Set(usrc_PriceList xusrc_PriceListB,
                                        usrc_PriceList xusrc_PriceListC,
                                        delegate_control_Set_ShowShops xdelegate_control_Set_ShowShops,
                                        delegate_control_SetDraftButtons xdelegate_control_SetDraftButtons,
                                        delegate_control_SetViewButtons xdelegate_control_SetViewButtons,
                                        delegate_control_AddOn_Show xdelegate_control_AddOn_Show,
                                        delegate_control_AddHandler xdelegate_control_AddHandler,
                                        delegate_control_RemoveHandler xdelegate_control_RemoveHandler,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        delegate_control_SetCurrentInvoice_SelectedShopB_Items xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
                                        delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                        delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                        delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                        delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                        delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                        delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                        delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                        delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text,
                                        delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data)
            {
                m_usrc_PriceListC = xusrc_PriceListC;
                m_delegate_control_SetDraftButtons = xdelegate_control_SetDraftButtons;
                m_delegate_control_SetViewButtons = xdelegate_control_SetViewButtons;
                m_delegate_control_AddOn_Show = xdelegate_control_AddOn_Show;
                m_delegate_control_AddHandler = xdelegate_control_AddHandler;
                m_delegate_control_RemoveHandler = xdelegate_control_RemoveHandler;
                m_delegate_control_InvoiceNumber_Text = xdelegate_control_InvoiceNumber_Text;
                m_delegate_control_SetMode = xdelegate_control_SetMode;
                m_delegate_control_SetCurrentInvoice_SelectedShopC_Items = xdelegate_control_SetCurrentInvoice_SelectedShopC_Items;
                m_delegate_control_ShowStornoCheckBox = xdelegate_control_ShowStornoCheckBox;
                m_delegate_control_SetStornoCheckBox = xdelegate_control_SetStornoCheckBox;
                m_delegate_control_ShopC_Reset = xdelegate_control_ShopC_Reset;
                m_delegate_control_ShopC_Clear = xdelegate_control_ShopC_Clear;
                m_delegate_control_btn_Issue_Show = xdelegate_control_btn_Issue_Show;
                m_delegate_control_lbl_Sum_ForeColor = xdelegate_control_lbl_Sum_ForeColor;
                m_delegate_control_lbl_Sum_Text = xdelegate_control_lbl_Sum_Text;
                m_delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data = xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data;
            }
        }

        public enum emode
        {
            view_eDocumentType,
            edit_eDocumentType
        }

        //public SettingsUserValues mSettingsUserValues = null;

        public ID Atom_Currency_ID = null;

        //public LoginControl.LMOUser m_LMOUser = null;

        //public Door door = null;


        public emode m_mode = emode.view_eDocumentType;

        public DBTablesAndColumnNamesOfConsumption DBtcn = new DBTablesAndColumnNamesOfConsumption();

        private CurrentConsumption m_CurrentCons = null;
        public CurrentConsumption CurrentCons
        {
            get
            {
                return m_CurrentCons;
            }
            set
            {
                m_CurrentCons = value;
            }
        }

        private ConsumptionData m_ConsumptionData = null;
        public ConsumptionData MyConsumptionData
        {
            get
            {
                return m_ConsumptionData;
            }
            set
            {
                m_ConsumptionData = value;
            }
        }

        public ID myOrganisation_Person_id
        {
            get
            {
                if (myOrg.m_myOrg_Office != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Person.ID;
                    }
                }
                return null;
            }
        }

        public ConsumptionEditor(ConsumptionMan xdocman)
        {
            ConsM = xdocman;
            CurrentCons = new CurrentConsumption(this,DBtcn);
        }


        public decimal GrossSum = 0;
        public decimal NetSum = 0;
        public StaticLib.TaxSum TaxSum = null;


        internal bool chk_Storno_CanBe_ManualyChanged = true;


        public string DocTyp
        {
            get
            {
                return ConsM.ConsumptionTyp;
            }
        }

        public bool DoCurrent(ID xID,
                              DoCurrent_delegates doCurrentDelegates,
                              Transaction transaction
                              )
        {
            if (DoGetCurrent(xID,
                              doCurrentDelegates,
                              transaction
                             ))
            {
                if (CurrentCons.ShowDraftButtons())
                {
                    if (doCurrentDelegates.m_delegate_control_SetDraftButtons != null)
                    {
                        doCurrentDelegates.m_delegate_control_SetDraftButtons();
                    }

                }
                else
                {
                    if (doCurrentDelegates.m_delegate_control_SetViewButtons != null)
                    {
                        doCurrentDelegates.m_delegate_control_SetViewButtons();
                    }
                }
                doCurrentDelegates.m_delegate_control_AddOn_Show(xID);
                return true;
            }
            else
            {
                doCurrentDelegates.m_delegate_control_AddOn_Show(null);
                return false;
            }
        }

        private bool DoGetCurrent(ID xID,
                                  DoCurrent_delegates doCurrent_delegates,
                                  Transaction transaction
            )
        {
            if (GetCurrent(xID,
                            doCurrent_delegates.m_delegate_control_InvoiceNumber_Text,
                            doCurrent_delegates.m_delegate_control_SetMode,
                            doCurrent_delegates.m_delegate_control_SetCurrentInvoice_SelectedShopC_Items,
                            doCurrent_delegates.m_delegate_control_ShowStornoCheckBox,
                            doCurrent_delegates.m_delegate_control_SetStornoCheckBox,
                            doCurrent_delegates.m_delegate_control_ShopC_Reset,
                            doCurrent_delegates.m_delegate_control_ShopC_Clear,
                            transaction
                            ))
            {
                GetPriceSum(doCurrent_delegates.m_delegate_control_btn_Issue_Show,
                            doCurrent_delegates.m_delegate_control_lbl_Sum_ForeColor,
                            doCurrent_delegates.m_delegate_control_lbl_Sum_Text
                            );
                if (CurrentCons.bDraft)
                {
                    doCurrent_delegates.m_delegate_control_AddHandler();
                }
                else
                {
                    if (CurrentCons.Exist)
                    {
                        doCurrent_delegates.m_delegate_control_RemoveHandler();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GetCurrent(ID xID,
                                delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                delegate_control_SetMode xdelegate_control_SetMode,
                                delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                Transaction transaction
                                )
        {
            return GetCurrentConsumption(xID,
                                    xdelegate_control_InvoiceNumber_Text,
                                    xdelegate_control_SetMode,
                                    xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                    xdelegate_control_ShowStornoCheckBox,
                                    xdelegate_control_SetStornoCheckBox,
                                    xdelegate_control_ShopC_Reset,
                                    xdelegate_control_ShopC_Clear,
                                    transaction
                                    );
        }


        public bool Get(bool bDraft,
                        ID ID,
                        string xTaxID,
                        string xOfficeShortName,
                        string xElectronicDeviceName,
                        ref string Err,
                        Transaction transaction)
        {
            //SQLTable tbl_Invoice = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Invoice));
            //SQLTable tbl_Consumption = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Consumption));
            //SQLTable tbl_Atom_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation_Person));
            //SQLTable tbl_Atom_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Atom_myOrganisation));

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_TaxID = null;
            if (xTaxID != null)
            {
                spar_TaxID = "@par_Tax_ID";
                SQL_Parameter par_TaxID = new SQL_Parameter(spar_TaxID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xTaxID);
                lpar.Add(par_TaxID);
            }

            string spar_OfficeShortName = "@par_OffSName";
            SQL_Parameter par_OfficeShortName = new SQL_Parameter(spar_OfficeShortName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xOfficeShortName);
            lpar.Add(par_OfficeShortName);

            string spar_ElectronicDeviceName = "@par_EDName";
            SQL_Parameter par_ElectronicDeviceName = new SQL_Parameter(spar_ElectronicDeviceName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xElectronicDeviceName);
            lpar.Add(par_ElectronicDeviceName);

            string cond = null;
            string sql_GetDraft = null;

            if (ID.Validate(ID))
            {
                cond = " where  JOURNAL_Consumption_$_cs.ID = " + ID.ToString();
            }
            else if (bDraft)
            {
                cond = " where JOURNAL_Consumption_$_cs.Draft = 1 ";
            }
            else
            {
                cond = "";
            }


            if (cond.Length > 0)
            {
                if (xTaxID != null)
                {
                    cond += " and JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                        + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                        + " and JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                }
                else
                {
                    cond += " and JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                        + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;

                }

            }
            else
            {
                if (xTaxID != null)
                {
                    cond += " where JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                        + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName
                        + " and JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.Tax_ID = " + spar_TaxID;
                }
                else
                {
                    cond += " where JOURNAL_Consumption_$_awperiod_$_aed.Name = " + spar_ElectronicDeviceName
                        + " and JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ShortName = " + spar_OfficeShortName;
                }
            }

            sql_GetDraft = @"Select
                    JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                    JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acln.LastName AS JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
                    JOURNAL_Consumption_$_awperiod_$_amcper.Job AS JOURNAL_Consumption_$_awperiod_$_amcper_$$Job,
                    JOURNAL_Consumption_$_awperiod_$_amcper.Description AS JOURNAL_Consumption_$_awperiod_$_amcper_$$Description,
                    JOURNAL_Consumption_$_cs.ID AS JOURNAL_Consumption_$_cs_$$ID,
                    JOURNAL_Consumption_$_awperiod_$_amcper.ID AS JOURNAL_Consumption_$_awperiod_$_amcper_$$ID,
                    JOURNAL_Consumption_$_cs.FinancialYear AS JOURNAL_Consumption_$_cs_$$FinancialYear,
                    JOURNAL_Consumption_$_cs.NumberInFinancialYear AS JOURNAL_Consumption_$_cs_$$NumberInFinancialYear,
                    JOURNAL_Consumption_$_cs.Draft AS JOURNAL_Consumption_$_cs_$$Draft,
                    JOURNAL_Consumption_$_cs.DraftNumber AS JOURNAL_Consumption_$_cs_$$DraftNumber,
                    JOURNAL_Consumption_$_cs.NetSum AS JOURNAL_Consumption_$_cs_$$NetSum,
                    JOURNAL_Consumption_$_cs.EndSum AS JOURNAL_Consumption_$_cs_$$EndSum,
                    JOURNAL_Consumption_$_cs.TaxSum AS JOURNAL_Consumption_$_cs_$$TaxSum,
                    JOURNAL_Consumption_$_cs.GrossSum AS JOURNAL_Consumption_$_cs_$$GrossSum,
					woao.IssueDate as IssueDate_WriteOff,
					wor.Name as WriteOff_ReasonName,
					wor.Description as WriteOff_ReasonDescription,
					ouao.IssueDate as IssueDate_OwnUse,
					our.Name as OwnUse_ReasonName,
					our.Description as OwnUse_ReasonDescription,
                    acur.ID as Atom_Currency_ID,
                    acur.Name as CurrencyName,
                    acur.Abbreviation as CurrencyAbbreviation,
                    acur.Symbol as CurrencySymbol,
                    acur.CurrencyCode as CurrencyCode,
                    acur.DecimalPlaces as CurrencyDecimalPlaces,
                    JOURNAL_Consumption_$_cs.Storno AS JOURNAL_Consumption_$_cs_$$Storno,
                    JOURNAL_Consumption_$_cs.Consumption_Reference_ID AS JOURNAL_Consumption_$_cs_$$Consumption_Reference_ID,
                    JOURNAL_Consumption_$_cs.Consumption_Reference_Type AS JOURNAL_Consumption_$_cs_$$Consumption_Reference_Type,
                    JOURNAL_Consumption.EventTime
                    FROM JOURNAL_Consumption 
                    INNER JOIN JOURNAL_Consumption_Type JOURNAL_Consumption_$_cst ON JOURNAL_Consumption.JOURNAL_Consumption_Type_ID = JOURNAL_Consumption_$_cst.ID
                    LEFT JOIN Consumption JOURNAL_Consumption_$_cs ON JOURNAL_Consumption.Consumption_ID = JOURNAL_Consumption_$_cs.ID 
                                                                        and ((((JOURNAL_Consumption_$_cst.Name='ConsumptionOwnUseDraftTime')or(JOURNAL_Consumption_$_cst.Name='ConsumptionWriteOffDraftTime')) and (JOURNAL_Consumption_$_cs.Draft=1))
																		
                                                                            or(((JOURNAL_Consumption_$_cst.Name='ConsumptionOwnUseTime') 
																			or (JOURNAL_Consumption_$_cst.Name='ConsumptionWriteOffTime') 
																			or (JOURNAL_Consumption_$_cst.Name='ConsumptionOwnUseStornoTime')
																			or (JOURNAL_Consumption_$_cst.Name='ConsumptionWriteOffDraftTimeStornoTime')
																			or  (JOURNAL_Consumption_$_cst.Name='Storno*'))
                                                                                and (JOURNAL_Consumption_$_cs.Draft=0)))
                    INNER JOIN Atom_Currency acur ON acur.ID = JOURNAL_Consumption_$_cs.Atom_Currency_ID
                    LEFT JOIN Atom_WorkPeriod JOURNAL_Consumption_$_awperiod ON JOURNAL_Consumption.Atom_WorkPeriod_ID = JOURNAL_Consumption_$_awperiod.ID
                    LEFT JOIN Atom_ElectronicDevice JOURNAL_Consumption_$_awperiod_$_aed ON JOURNAL_Consumption_$_awperiod.Atom_ElectronicDevice_ID = JOURNAL_Consumption_$_awperiod_$_aed.ID
                    Left JOIN Atom_Office JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice ON JOURNAL_Consumption_$_awperiod_$_aed.Atom_Office_ID = JOURNAL_Consumption_$_awperiod_$_aed_$_aoffice.ID
                    LEFT JOIN Atom_myOrganisation_Person JOURNAL_Consumption_$_awperiod_$_amcper ON JOURNAL_Consumption_$_awperiod.Atom_myOrganisation_Person_ID = JOURNAL_Consumption_$_awperiod_$_amcper.ID
                    Left JOIN Atom_Office JOURNAL_Consumption_$_awperiod_$_amcper_$_aoffice ON JOURNAL_Consumption_$_awperiod_$_amcper.Atom_Office_ID = JOURNAL_Consumption_$_awperiod_$_amcper_$_aoffice.ID
                    LEFT JOIN Atom_Person JOURNAL_Consumption_$_awperiod_$_amcper_$_aper ON JOURNAL_Consumption_$_awperiod_$_amcper.Atom_Person_ID = JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.ID
                    LEFT JOIN Atom_cFirstName JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acfn ON JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acfn.ID
                    LEFT JOIN Atom_cLastName JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acln ON JOURNAL_Consumption_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = JOURNAL_Consumption_$_awperiod_$_amcper_$_aper_$_acln.ID
                    left join WriteOffAddOn woao on woao.Consumption_ID = JOURNAL_Consumption_$_cs.ID
					left join WriteOffReason wor on wor.ID = woao.WriteOffReason_ID
					left join OwnUseAddOn ouao on ouao.Consumption_ID = JOURNAL_Consumption_$_cs.ID
					left join OwnUseReason our on our.ID = ouao.OwnUseReason_ID
                    " + cond;






            CurrentCons.dtCurrent_Invoice.Columns.Clear();
            CurrentCons.dtCurrent_Invoice.Clear();
            if (DBSync.DBSync.ReadDataTable(ref CurrentCons.dtCurrent_Invoice, sql_GetDraft, lpar, ref Err))
            {
                if (CurrentCons.dtCurrent_Invoice.Rows.Count > 0)
                {
                    CurrentCons.Exist = true;
                    CurrentCons.bDraft = (bool)CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$Draft"];
                    CurrentCons.Doc_ID = tf.set_ID(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$ID"]);
                    CurrentCons.EventTime = (DateTime)CurrentCons.dtCurrent_Invoice.Rows[0]["EventTime"];

                    if (CurrentCons.Atom_Currency_ID == null)
                    {
                        CurrentCons.Atom_Currency_ID = new ID();
                    }
                    CurrentCons.Atom_Currency_ID = tf.set_ID(CurrentCons.dtCurrent_Invoice.Rows[0]["Atom_Currency_ID"]);
                    if (CurrentCons.Currency == null)
                    {
                        CurrentCons.Currency = new xCurrency();
                    }

                    CurrentCons.Currency.ID = CurrentCons.Atom_Currency_ID;
                    CurrentCons.Currency.Name = (string)CurrentCons.dtCurrent_Invoice.Rows[0]["CurrencyName"];
                    CurrentCons.Currency.Abbreviation = (string)CurrentCons.dtCurrent_Invoice.Rows[0]["CurrencyAbbreviation"];
                    CurrentCons.Currency.Symbol = (string)CurrentCons.dtCurrent_Invoice.Rows[0]["CurrencySymbol"];
                    CurrentCons.Currency.CurrencyCode = (int)CurrentCons.dtCurrent_Invoice.Rows[0]["CurrencyCode"];
                    CurrentCons.Currency.DecimalPlaces = (int)CurrentCons.dtCurrent_Invoice.Rows[0]["CurrencyDecimalPlaces"];

                    CurrentCons.TInvoice.StornoConsumption_ID = tf.set_ID(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$Consumption_Reference_ID"]);

                    CurrentCons.TInvoice.Invoice_Reference_Type_v = tf.set_string(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$Consumption_Reference_Type"]);
                    CurrentCons.TInvoice.bStorno_v = tf.set_bool(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$Storno"]);

                    CurrentCons.FinancialYear = (int)CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$FinancialYear"];

             
                    object oNumberInFinancialYear = CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$NumberInFinancialYear"];
                    if (oNumberInFinancialYear is int)
                    {
                        CurrentCons.NumberInFinancialYear = (int)oNumberInFinancialYear;
                    }
                    else
                    {
                        CurrentCons.NumberInFinancialYear = -1;
                    }

                    CurrentCons.DraftNumber = (int)CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$DraftNumber"];

                    ID xConsumption_ID = CurrentCons.Doc_ID;
                    if (CurrentCons.TInvoice.StornoConsumption_ID != null)
                    {
                        decimal_v dGrossSum_v = tf.set_decimal(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_cs_$$GrossSum"]);
                        if (dGrossSum_v != null)
                        {
                            if (dGrossSum_v.v < 0)
                            {
                                xConsumption_ID = CurrentCons.TInvoice.StornoConsumption_ID;
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:GetDraft:select ... from " + DBtcn.stbl_Consumption_TableName + ":\r\nErr=" + Err);
                return false;
            }
        }




        private bool GetCurrentConsumption(ID Consumption_ID,
                                       delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                       delegate_control_SetMode xdelegate_control_SetMode,
                                       delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                        delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                        delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                        delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                        delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                        Transaction transaction
                                       )
        {
            string Err = null;
            //
            string xAtom_myOrganisation_Person_Tax_ID = m_LMOUser.Atom_myOrganisation_Person_Tax_ID;
            if (m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
            {
                xAtom_myOrganisation_Person_Tax_ID = null;
            }

            if (Get(true,
                          Consumption_ID,
                          xAtom_myOrganisation_Person_Tax_ID,
                          m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName,
                          m_LMOUser.Atom_ElectronicDevice_Name,
                          ref Err,
                          transaction)) // try to get draft
            {
                xdelegate_control_InvoiceNumber_Text(ConsumptionMan.GetInvoiceNumber(CurrentCons.bDraft, CurrentCons.FinancialYear, CurrentCons.NumberInFinancialYear, CurrentCons.DraftNumber));
                if (CurrentCons.bDraft)
                {
                    SetMode(ConsumptionEditor.emode.edit_eDocumentType, xdelegate_control_SetMode);
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopC_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopC_Items(); //this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    }
                }
                else
                {
                    SetMode(ConsumptionEditor.emode.view_eDocumentType, xdelegate_control_SetMode);
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopC_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopC_Items(); //this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    }
                    chk_Storno_CanBe_ManualyChanged = false;
                    xdelegate_control_ShowStornoCheckBox(true);// this.chk_Storno.Visible = true;
                    if (CurrentCons.TInvoice.bStorno_v != null)
                    {
                        xdelegate_control_SetStornoCheckBox(CurrentCons.TInvoice.bStorno_v.v);// this.chk_Storno.Checked = m_ShopABC.CurrentCons.TInvoice.bStorno_v.v;
                    }
                    else
                    {
                        xdelegate_control_SetStornoCheckBox(false);// this.chk_Storno.Checked = false;
                    }
                    chk_Storno_CanBe_ManualyChanged = true;
                }
                if (xdelegate_control_ShopC_Reset != null)
                {
                    xdelegate_control_ShopC_Reset();// this.m_usrc_ShopC.Reset();

                }
                return true;
            }
            else
            {
                SetMode(ConsumptionEditor.emode.view_eDocumentType, xdelegate_control_SetMode);
                string sxAtom_myOrganisation_Person_Tax_ID = m_LMOUser.Atom_myOrganisation_Person_Tax_ID;
                if (m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
                {
                    sxAtom_myOrganisation_Person_Tax_ID = null;
                }

                if (Get(false,
                                  Consumption_ID,
                                  sxAtom_myOrganisation_Person_Tax_ID,
                                  m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName,
                                  m_LMOUser.Atom_ElectronicDevice_Name,
                                  ref Err,
                                  transaction)) // Get invoice with Invoice_ID
                {
                    xdelegate_control_InvoiceNumber_Text(ConsumptionMan.GetInvoiceNumber(CurrentCons.bDraft, CurrentCons.FinancialYear, CurrentCons.NumberInFinancialYear, CurrentCons.DraftNumber));// this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.CurrentCons.bDraft, m_ShopABC.CurrentCons.FinancialYear, m_ShopABC.CurrentCons.NumberInFinancialYear, m_ShopABC.CurrentCons.DraftNumber);//

                    if (xdelegate_control_ShopC_Clear != null)
                    {
                        xdelegate_control_ShopC_Clear();// this.m_usrc_ShopC.Clear();
                    }
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopC_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopC_Items(); //this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    }

                    if (xdelegate_control_ShopC_Reset != null)
                    {
                        xdelegate_control_ShopC_Reset();//this.m_usrc_ShopC.Reset();
                    }

                    return true;
                }
                else
                {
                    if (xdelegate_control_ShopC_Reset != null)
                    {
                        xdelegate_control_ShopC_Reset();//this.m_usrc_ShopC.Reset();
                    }
                    return false;
                }
            }
        }

        private void SetMode(ConsumptionEditor.emode mode, delegate_control_SetMode xdelegate_control_SetMode)
        {
            m_mode = mode;
            xdelegate_control_SetMode(mode);
        }


        public void GetPriceSum(delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text
)
        {
            decimal dsum_GrossSum = 0;
            decimal dsum_TaxSum = 0;
            decimal dsum_NetSum = 0;


            TaxSum = null;
            TaxSum = new StaticLib.TaxSum();



            decimal dsum_GrossSum_Basket = 0;
            decimal dsum_TaxSum_Basket = 0;
            decimal dsum_NetSum_Basket = 0;

            if (CurrentCons.m_Basket != null)
            {
                CurrentCons.m_Basket.GetPriceSum(ref dsum_GrossSum_Basket, ref dsum_TaxSum_Basket, ref dsum_NetSum_Basket, ref TaxSum);
            }
            dsum_GrossSum += dsum_GrossSum_Basket;
            dsum_TaxSum += dsum_TaxSum_Basket;
            dsum_NetSum += dsum_NetSum_Basket;


            if (dsum_GrossSum > 0)
            {
                xdelegate_control_btn_Issue_Show(true);// btn_Issue.Visible = true;
            }
            else
            {
                xdelegate_control_btn_Issue_Show(false);//btn_Issue.Visible = false;
            }
            GrossSum = dsum_GrossSum;
            NetSum = dsum_NetSum;
            string sGrossSum = "";
            if (CurrentCons.TInvoice.StornoConsumption_ID == null)
            {
                sGrossSum = dsum_GrossSum.ToString();
                xdelegate_control_lbl_Sum_ForeColor(Color.Black);// this.lbl_Sum.ForeColor = Color.Black;
            }
            else
            {
                sGrossSum = dsum_GrossSum.ToString();
                decimal_v dGrossSum_v = tf.set_decimal(CurrentCons.dtCurrent_Invoice.Rows[0]["JOURNAL_Consumption_$_dinv_$$GrossSum"]);
                if (dGrossSum_v != null)
                {
                    if (dGrossSum_v.v < 0)
                    {
                        sGrossSum = dGrossSum_v.v.ToString();
                    }
                }
                xdelegate_control_lbl_Sum_ForeColor(Color.Red); //this.lbl_Sum.ForeColor = Color.Red;
            }
            xdelegate_control_lbl_Sum_Text(sGrossSum + " " + GlobalData.BaseCurrency.Symbol);// this.lbl_Sum.Text = sGrossSum + " " + GlobalData.BaseCurrency.Symbol;// +" tax:" + TaxSum.ToString() + " " + NetSum.ToString();
        }


        public void btn_Issue_Click(
                                    Form pform,
                                    delegate_control_Get_WriteOff_AddOn xdelegate_control_Get_WriteOff_AddOn,
                                    delegate_control_Check_WriteOffAddOn xdelegate_control_Check_WriteOff_AddOn,
                                    delegate_control_Get_OwnUse_AddOn xdelegate_control_Get_OwnUse_AddOn,
                                    delegate_control_DoCurrent xdelegate_control_DoCurrent,
                                    delegate_ConsumptionSaved xdelegate_ConsumptionSaved,
                                    delegate_DocProformaInvoiceSaved xdelegate_DocProformaInvoiceSaved
                                    )
        {
            if (CurrentCons != null)
            {
                if (CurrentCons.Exist)
                {
                    if (CurrentCons.bDraft)
                    {

                        if ((TSettings.RecordCashierActivity) && (TSettings.CashierState == TangentaDB.CashierActivity.eCashierState.CLOSED))
                        {
                            XMessage.Box.Show(pform, lng.s_YouCanNotWriteInvoices_CasshierIsClosed, MessageBoxIcon.Stop);
                            return;
                        }

                        if (!xdelegate_control_Check_WriteOff_AddOn(m_ConsumptionData.AddOnWriteOff))// if (!usrc_AddOn1.Check_Consumption_AddOn(DocE.m_InvoiceData.AddOnDI))
                        {
                            if (!xdelegate_control_Get_WriteOff_AddOn(true)) //if(!usrc_AddOn1.Get_Doc_AddOn(true))
                            {
                                return;
                            }
                            if (!xdelegate_control_Check_WriteOff_AddOn(MyConsumptionData.AddOnWriteOff))//if (!usrc_AddOn1.Check_Consumption_AddOn(DocE.m_InvoiceData.AddOnDI))
                            {
                                return;
                            }
                        }

                        Transaction transaction_ConsumptionEditor_IssueDocument = DBSync.DBSync.NewTransaction("ConsumptionEditor_IssueDocument");



                        if (IssueDocument(pform, this, xdelegate_ConsumptionSaved, xdelegate_DocProformaInvoiceSaved, transaction_ConsumptionEditor_IssueDocument))
                        {
                            if (xdelegate_control_DoCurrent(CurrentCons.Doc_ID, transaction_ConsumptionEditor_IssueDocument))// DoCurrent(m_ShopABC.CurrentCons.Doc_ID);
                            {
                                if (!transaction_ConsumptionEditor_IssueDocument.Commit())
                                {
                                    return;
                                }
                            }
                            else
                            {
                                transaction_ConsumptionEditor_IssueDocument.Rollback();
                            }
                        }
                        else
                        {
                            transaction_ConsumptionEditor_IssueDocument.Rollback();
                        }
                        return;
                    }
                    else
                    {
                        //Print existing invoice
                        MyConsumptionData.Consumption_ID = CurrentCons.Doc_ID;
                        Transaction transaction_m_InvoiceData_Read_Consumption = DBSync.DBSync.NewTransaction("m_InvoiceData.Read_Consumption");
                        if (ConsM.IsWriteOff)
                        {
                            if (MyConsumptionData.Read_Consumption(transaction_m_InvoiceData_Read_Consumption)) // read Proforma Invoice again from DataBase
                            { // print invoice if you wish
                                if (transaction_m_InvoiceData_Read_Consumption.Commit())
                                {
                                    Printing_Consumption(pform, null);//Printing_Consumption();
                                                                      //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                                                      //frm_Print_Existing_invoice.ShowDialog(this);
                                }
                            }
                            else
                            {
                                transaction_m_InvoiceData_Read_Consumption.Rollback();
                            }
                        }
                        else
                        {
                            if (MyConsumptionData.Read_Consumption(transaction_m_InvoiceData_Read_Consumption)) // read Proforma Invoice again from DataBase
                            {
                                if (transaction_m_InvoiceData_Read_Consumption.Commit())
                                {
                                    Printing_Consumption(pform, null);//Printing_Consumption();
                                                                      //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                                                      //frm_Print_Existing_invoice.ShowDialog(this);
                                }
                            }
                            else
                            {
                                transaction_m_InvoiceData_Read_Consumption.Rollback();
                            }
                        }
                    }
                }
            }
        }

        internal bool Printing_Consumption(Control parentControl, Transaction transaction)
        {
            Printer printer = null;
            if (PrintersList.PrintingWithHtmlTemplate(DocTyp, ref printer))
            {
                if (transaction != null)
                {
                    transaction.Commit();
                }

                //Form parentform = Global.f.GetParentForm(parentControl);
                //TangentaPrint.Form_PrintDocument template_dlg = new TangentaPrint.Form_PrintDocument(m_LMOUser.Atom_WorkPeriod_ID, ConsumptionData, TangentaResources.Properties.Resources.Exit, true);
                //template_dlg.Owner = Global.f.GetParentForm(parentform);
                //if (template_dlg.ShowDialog(parentform) == DialogResult.OK)
                //{
                //    return true;
                //}
                return false;
            }
            else
            {
                PrintConsumption prnConsumption = new PrintConsumption(printer.PrinterName/*, ConsumptionData*/);

                if (prnConsumption.Print(ConsumptionMan.MainForm))
                {
                    if (transaction == null)
                    {
                        transaction = DBSync.DBSync.NewTransaction("ConsumptionEditor.SetCopyPrintInfo");
                    }
                    //if (InvoiceData.SetCopyPrintInfo(m_LMOUser.Atom_WorkPeriod_ID,
                    //                                 printer.PrinterName,
                    //                                 transaction))
                    //{
                    //    return transaction.Commit();
                    //}
                    //else
                    //{
                    //    transaction.Rollback();
                    //    return false;
                    //}
                }

                return true;
            }
        }

        public bool GetUnits()
        {
            if (m_xUnitList == null)
            {
                m_xUnitList = new xUnitList();
            }
            string Err = null;
            DataTable dt = new DataTable();
            if (m_xUnitList.Get(ref dt, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:GetUnits:m_xUnitList.Get:Err=" + Err);
                return false;
            }
        }



        internal string GetDocType()
        {
            return ConsM.ConsumptionTyp;
        }

        private void usrc_PriceList_Ask_To_Update(Form pForm, usrc_PriceList usrc_PriceList1, char chShop, DataTable dt_ShopB_Item_NotIn_PriceList)
        {
            if (PriseLists.usrc_PriceList.Ask_To_Update(chShop, dt_ShopB_Item_NotIn_PriceList, pForm))
            {
                Transaction transaction_usrc_ConsumptionEditor_Insert_ShopB_Items_in_PriceList = DBSync.DBSync.NewTransaction("usrc_ConsumptionEditor.Insert_ShopB_Items_in_PriceList");
                if (f_PriceList.Insert_ShopB_Items_in_PriceList(dt_ShopB_Item_NotIn_PriceList, pForm, transaction_usrc_ConsumptionEditor_Insert_ShopB_Items_in_PriceList))
                {
                    if (transaction_usrc_ConsumptionEditor_Insert_ShopB_Items_in_PriceList.Commit())
                    {
                        bool bPriceListChanged = false;
                        usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                    }
                }
                else
                {
                    transaction_usrc_ConsumptionEditor_Insert_ShopB_Items_in_PriceList.Rollback();
                }
            }
        }



        public bool Init(Form pform,
                          ID document_ID,
                          ConsumptionEditor.DoCurrent_delegates doCurrent_delegates,
                          Transaction transaction)
        {
            this.MainForm = pform;
            if (DBtcn == null)
            {
                DBtcn = new DBTablesAndColumnNamesOfConsumption();
            }
            if (MyConsumptionData == null)
            {
                MyConsumptionData = new ConsumptionData(GetDocType, document_ID, GlobalData.ElectronicDevice_Name);
            }
            else
            {
                MyConsumptionData.Consumption_ID = document_ID;
            }

            string showshops = TangentaProperties.Properties.Settings.Default.eShowShops;
            //if (mSettingsUserValues != null)
            //{
            //    if (mSettingsUserValues.eShowShops.Length == 0)
            //    {
            //        mSettingsUserValues.eShowShops = showshops;
            //    }
            //    else
            //    {
            //        showshops = mSettingsUserValues.eShowShops;
            //    }
            //}

            //doCurrent_delegates.m_delegate_control_Set_ShowShops(PropertiesUser.ShowShops_Get(mSettingsUserValues));// Set_ShowShops(mSettingsUserValues.eShowShops);
            GetUnits();

            DataTable dt_ShopB_Item_NotIn_PriceList = new DataTable();




            if (GetPurchasePriceList_ShopC())
            {
               
                if (doCurrent_delegates.m_delegate_control_m_usrc_ConsumptionShopC_usrc_ItemList_Get_PurchasePrice_Item_Stock_Data(dtPurchasePrice_Item))
                {
                     return this.DoCurrent(document_ID, doCurrent_delegates, transaction);
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

            //if (ID.Validate(document_ID))
            //{
            //    return this.DoCurrent(document_ID, doCurrent_delegates, transaction);
            //}
            //else
            //{
            //    return true;
            //}
        }

        private bool GetPurchasePriceList_ShopC()
        {
            if (dtPurchasePrice_Item!=null)
            {
                dtPurchasePrice_Item.Dispose();
                dtPurchasePrice_Item = null;
            }
            dtPurchasePrice_Item = new DataTable();
            return f_PurchasePrice_Item.GetTable(ref dtPurchasePrice_Item);
        }








        private bool IssueDocument(Form pform,
                                    ConsumptionEditor docE,
                                    delegate_ConsumptionSaved xdelegate_ConsumptionSaved,
                                    delegate_DocProformaInvoiceSaved xdelegate_DocProformaInvoiceSaved,
                                    Transaction transaction)
        {
            //ProgramDiagnostic.Diagnostic.Enabled = true;
            //ProgramDiagnostic.Diagnostic.Init();
            //ProgramDiagnostic.Diagnostic.Clear();
            //ProgramDiagnostic.Diagnostic.Meassure("Before fs.UpdatePriceInDraft", "?");

            if (fs.UpdatePriceInDraft(DocTyp, CurrentCons.Doc_ID, GrossSum, TaxSum.Value, NetSum, transaction))
            {
                if (ConsM.IsWriteOff)
                {


                    ID Consumption_ID = null;
                    // save doc Invoice 
                    if (MyConsumptionData.SaveConsumption(ref Consumption_ID, TSettings.CashierActivity, GlobalData.ElectronicDevice_Name, m_LMOUser.Atom_WorkPeriod_ID, transaction))
                    {

                        CurrentCons.Doc_ID = Consumption_ID;

                        // read saved doc Invoice again !
                        if (MyConsumptionData.Read_Consumption(transaction))
                        {
                            xdelegate_ConsumptionSaved(CurrentCons.Doc_ID);
                            Printing_Consumption(pform, transaction);// Printing_Consumption();
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
                else if (ConsM.IsOwnUse)
                {
                    ID Consumption_ID = null;
                    // save doc Invoice 
                    if (MyConsumptionData.SaveConsumptionOwnUse(ref Consumption_ID, GlobalData.ElectronicDevice_Name, m_LMOUser.Atom_WorkPeriod_ID, transaction))
                    {
                        CurrentCons.Doc_ID = Consumption_ID;
                        // read saved doc Invoice again !
                        if (MyConsumptionData.Read_Consumption(transaction))
                        {
                            xdelegate_DocProformaInvoiceSaved(CurrentCons.Doc_ID);
                            Printing_Consumption(pform, transaction);// Printing_Consumption();
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
                    LogFile.Error.Show("ERROR:Tangenta:usrc_Invoice:IssueDocument:Unknown doc type!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public void SetNewDraft(Form pform,
                                LMOUser xLMOUser,
                                string DocTyp,
                                f_Consumption.eConsumptionType xeConsumptionType,
                                int xFinancialYear,
                                xCurrency xcurrency,
                                ID Atom_Currency_ID,
                                delegate_control_SetMode xdelegate_control_SetMode,
                                delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text)
        {
            if (DocTyp.Equals(GlobalData.const_ConsumptionAll) || DocTyp.Equals(GlobalData.const_ConsumptionWriteOff) || DocTyp.Equals(GlobalData.const_ConsumptionOwnUse))
            {
                if (SetNewConsumptionDraft(pform,
                                        xLMOUser,
                                        xeConsumptionType,
                                        xFinancialYear,
                                        xcurrency,
                                        Atom_Currency_ID,
                                        xdelegate_control_SetMode,
                                        xdelegate_control_InvoiceNumber_Text))
                {
                    xdelegate_control_SetMode(ConsumptionEditor.emode.edit_eDocumentType);// SetMode(ConsumptionEditor.emode.edit_eDocumentType);
                }
                return;
            }
            return;

        }

        public bool SetNewConsumptionDraft(Form pform,
                                        LMOUser xLMOUser,
                                        f_Consumption.eConsumptionType xeConsumptionType,
                                        int FinancialYear,
                                        xCurrency xcurrency,
                                        ID xAtom_Currency_ID,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text)
        {
            ID Consumption_ID = null;
            string Err = null;
            if (OperationMode.MultiUser)
            {
                myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(xLMOUser.myOrganisation_Person_ID);
            }

            if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
            {
                LogFile.Error.Show("ERROR:SetNewConsumptionDraft:Can not find my oragnisation person!");
                return false;
            }

            
            int draftNumber = 0;
            Transaction transaction_SetNewConsumptionDraft = DBSync.DBSync.NewTransaction("SetNewConsumptionDraft");
            if (f_Consumption.SetNewDraft_Consumption(m_LMOUser.Atom_WorkPeriod_ID,
                                        xeConsumptionType,
                                        FinancialYear,
                                        xcurrency,
                                        xAtom_Currency_ID,
                                        ref Consumption_ID,
                                        ref draftNumber,
                                        transaction_SetNewConsumptionDraft))
            {
                this.CurrentCons.DraftNumber = draftNumber;
                this.CurrentCons.Doc_ID = Consumption_ID;
                if (transaction_SetNewConsumptionDraft.Commit())
                {
                    if (ID.Validate(CurrentCons.Doc_ID))
                    {
                        xdelegate_control_InvoiceNumber_Text(CurrentCons.FinancialYear.ToString() + "/" + CurrentCons.DraftNumber.ToString()); // this.txt_Number.Text = DocE.m_ShopABC.CurrentCons.FinancialYear.ToString() + "/" + DocE.m_ShopABC.CurrentCons.DraftNumber.ToString();
                        xdelegate_control_SetMode(ConsumptionEditor.emode.edit_eDocumentType);// SetMode(ConsumptionEditor.emode.edit_eDocumentType);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                transaction_SetNewConsumptionDraft.Rollback();
                LogFile.Error.Show("ERROR:SetNewConsumptionDraft:Err=" + Err);
                return false;
            }
        }

        

       

        public bool Storno_CheckedChanged(Form pform,
                                            bool chk_Storno_Checked,
                                            string stxt_Number,
                                            delegate_Storno xdelegate_Storno,
                                            delegate_control_chk_Storno_Check xdelegate_control_chk_Storno_Check,
                                            Transaction transaction
                                          )
        {

            string stornoReferenceInvoiceNumber = "";
            string stornoReferenceInvoiceIssueDateTime = "";

            if (chk_Storno_CanBe_ManualyChanged)
            {
                bool bstorno = false;
                if (ConsM.IsWriteOff)
                {
                    if (CurrentCons.TInvoice.bStorno_v != null)
                    {
                        bstorno = CurrentCons.TInvoice.bStorno_v.v;
                    }
                }

                if (chk_Storno_Checked != bstorno)
                {
                    if (chk_Storno_Checked)
                    {
                        if (MessageBox.Show(pform, lng.s_Consumption.s + ": " + stxt_Number + "\r\n" + lng.s_AreYouSureToStornoThisConsumption.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            //Form_Storno frm_storno_dlg = new Form_Storno(m_ShopABC.CurrentCons.Doc_ID);

                            //if (frm_storno_dlg.ShowDialog() == DialogResult.Yes)
                            //{
                            //    stornoReferenceInvoiceNumber = m_ShopABC.CurrentCons.NumberInFinancialYear.ToString();
                            //    stornoReferenceInvoiceIssueDateTime = frm_storno_dlg.m_InvoiceTime;
                            //    string sInvoiceToStorno = frm_storno_dlg.m_sInvoiceToStorno;
                            //    if (MessageBox.Show(pform, sInvoiceToStorno + "\r\n" + lng.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            //    {

                            //        ID Storno_Consumption_ID = null;
                            //        DateTime stornoInvoiceIssueDateTime = new DateTime();
                            //        Transaction transaction_Storno = DBSync.DBSync.NewTransaction("Storno");
                            //        if (m_ShopABC.CurrentCons.Storno(m_LMOUser.Atom_WorkPeriod_ID,
                            //                                          ref Storno_Consumption_ID,
                            //                                          true,
                            //                                          GlobalData.ElectronicDevice_Name,
                            //                                          frm_storno_dlg.m_Reason,
                            //                                          ref stornoInvoiceIssueDateTime,
                            //                                          transaction_Storno))
                            //        {
                            //            if (TSettings.b_FVI_SLO)
                            //            {
                            //                InvoiceData.AddOnDI.b_FVI_SLO = TSettings.b_FVI_SLO;
                            //                InvoiceData xInvoiceData = new InvoiceData(m_ShopABC, Storno_Consumption_ID, GlobalData.ElectronicDevice_Name);
                            //                if (xInvoiceData.Read_Consumption(transaction)) // read Proforma Invoice again from DataBase
                            //                {

                            //                    string furs_XML = Consumption_AddOn.FURS.Create_furs_InvoiceXML(true,
                            //                                                                                  TangentaResources.Properties.Resources.FVI_SLO_Invoice,
                            //                                                                                  TSettings.FVI_SLO1.FursD_MyOrgTaxID,
                            //                                                                                  TSettings.FVI_SLO1.FursD_BussinesPremiseID,
                            //                                                                                  GlobalData.ElectronicDevice_Name,
                            //                                                                                  TSettings.FVI_SLO1.FursD_InvoiceAuthorTaxID,
                            //                                                                                  stornoReferenceInvoiceNumber,
                            //                                                                                  stornoReferenceInvoiceIssueDateTime,
                            //                                                                                  xInvoiceData.IssueDate_v,
                            //                                                                                  xInvoiceData.NumberInFinancialYear,
                            //                                                                                  xInvoiceData.GrossSum,
                            //                                                                                  xInvoiceData.taxSum,
                            //                                                                                  xInvoiceData.Invoice_Author
                            //                                                                                  );
                            //                    string furs_UniqeMsgID = null;
                            //                    string furs_UniqeInvID = null;
                            //                    string furs_BarCodeValue = null;
                            //                    Image img_QR = null;
                            //                    if (TSettings.FVI_SLO1.Send_SingleInvoice(false, furs_XML, pform, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                            //                    {
                            //                        xInvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                            //                        xInvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                            //                        xInvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                            //                        if (xInvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(xInvoiceData.Consumption_ID, TSettings.FVI_SLO1.FursTESTEnvironment,transaction_Storno))
                            //                        {

                            //                        }
                            //                    }
                            //                    else
                            //                    {
                            //                        string xSerialNumber = null;
                            //                        string xSetNumber = null;
                            //                        string xInvoiceNumber = null;
                            //                        TSettings.FVI_SLO1.Write_SalesBookInvoice(xInvoiceData.Consumption_ID, xInvoiceData.FinancialYear, xInvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                            //                        ID FVI_SLO_SalesBookInvoice_ID = null;
                            //                        if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(xInvoiceData.Consumption_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID, transaction))
                            //                        {
                            //                            MessageBox.Show("Storno računa je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");
                            //                        }
                            //                        else
                            //                        {
                            //                            transaction_Storno.Rollback();
                            //                            return false;
                            //                        }
                            //                    }
                            //                }
                            //            }
                            //            if (transaction_Storno.Commit())
                            //            {
                            //                xdelegate_Storno(true);
                            //            }
                            //            else
                            //            {
                            //                xdelegate_Storno(false);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            transaction_Storno.Rollback();
                            //        }

                            //    }
                            //}
                        }
                    }
                    else
                    {
                        //MessageBox.Show(pform, lng.s_YouCanNotCancelInvoiceStorno.s);
                        chk_Storno_CanBe_ManualyChanged = false;
                        xdelegate_control_chk_Storno_Check(true);
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                }
            }
            return true;
        }

        public void Customer_Org_Changed(ID Customer_Org_ID,
                                                        delegate_control_usrc_Customer_Show_Customer_Organisation xdelegate_control_usrc_Customer_Show_Customer_Organisation,
                                                        delegate_Customer_Org_Changed xdelegate_Customer_Org_Changed
                                                        )
        {
            ID Atom_Customer_Org_ID = null;
            Transaction transaction_Customer_Org_Changed = DBSync.DBSync.NewTransaction("Customer_Org_Changed");
            //if (m_ShopABC.CurrentCons.Update_Customer_Org(DocTyp, Customer_Org_ID, ref Atom_Customer_Org_ID, transaction_Customer_Org_Changed))
            //{
            //    m_ShopABC.CurrentCons.Atom_Customer_Org_ID = Atom_Customer_Org_ID;
            //    if (ID.Validate(Atom_Customer_Org_ID))
            //    {
            //        if (!transaction_Customer_Org_Changed.Commit())
            //        {
            //            return;
            //        }
            //        xdelegate_control_usrc_Customer_Show_Customer_Organisation(m_ShopABC.CurrentCons);
            //        //usrc_Customer.Show_Customer_Org(m_ShopABC.CurrentCons);
            //        xdelegate_Customer_Org_Changed(Customer_Org_ID);
            //    }
            //    else
            //    {
            //        transaction_Customer_Org_Changed.Rollback();
            //    }
            //}
            //else
            //{
            //    transaction_Customer_Org_Changed.Rollback();
            //}
        }
        internal bool CountInBaskets(ref decimal count_in_baskets)
        {
            string sql = @"select dQuantity 
                        from Consumption_ShopC_Item  appis
                        inner join Consumption pi on appis.Consumption_ID = pi.ID
                        where pi.Draft = 1 and appis.Stock_ID is not null";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                decimal d = 0;
                int iCount = dt.Rows.Count;
                for (int i = 0; i < iCount; i++)
                {
                    d += (decimal)dt.Rows[i][0];
                }
                count_in_baskets = d;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ItemMan:CountInBaskets:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
