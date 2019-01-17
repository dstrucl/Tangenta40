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

namespace TangentaCore
{
    public class DocumentEditor
    {
        public delegate void delegate_control_SetDraftButtons();
        public delegate void delegate_control_SetViewButtons();
        public delegate void delegate_control_Show_Customer(TangentaDB.CurrentDoc x_CurrentInvoice);
        public delegate void delegate_control_Customer_Text(string s);
        public delegate void delegate_control_AddOn_Show(ID ID);
        public delegate void delegate_control_AddHandler();
        public delegate void delegate_control_RemoveHandler();

        public delegate void delegate_control_InvoiceNumber_Text(string s);
        public delegate void delegate_control_SetMode(DocumentEditor.emode mode);
        public delegate void delegate_control_SetCurrentInvoice_SelectedShopB_Items();
        public delegate void delegate_control_SetCurrentInvoice_SelectedShopC_Items();

        public delegate void delegate_control_ShowStornoCheckBox(bool bvisible);
        public delegate void delegate_control_SetStornoCheckBox(bool bchecked);
        public delegate void delegate_control_ShopC_Reset();
        public delegate void delegate_control_ShopC_Clear();

        public delegate void delegate_control_btn_Issue_Show(bool bvisible);
        public delegate void delegate_control_lbl_Sum_ForeColor(Color color);
        public delegate void delegate_control_lbl_Sum_Text(string s);

        public delegate bool delegate_control_Check_DocInvoice_AddOn(DocInvoice_AddOn addOnDI);
        public delegate bool delegate_control_Get_Doc_AddOn(bool xbPrint);

        public delegate bool delegate_control_Check_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn addOnDI);
        public delegate bool delegate_control_Get_DocProforma_AddOn(bool xbPrint);

        public delegate bool delegate_control_DoCurrent(ID xID, Transaction transaction);
        public delegate bool delegate_control_Printing_DocInvoice(Control parnetcontrol);

        public delegate void delegate_DocInvoiceSaved(ID DocInvoice_id);
        public delegate void delegate_DocProformaInvoiceSaved(ID DocProformaInvoice_id);

        public delegate void delegate_control_Set_ShowShops(string eShopsShow);

        public delegate bool delegate_control_m_usrc_ShopB_usrc_PriceList1_Init(ID Currency_ID, usrc_PriceList_Edit.eShopType xeShopType, string ShopsInUse, ref ID price_list_id, ref string Err);
        public delegate bool delegate_control_m_usrc_ShopC_usrc_PriceList1_Init(ID Currency_ID, usrc_PriceList_Edit.eShopType xeShopType, string ShopsInUse, ref ID price_list_id, ref string Err);

        public delegate void delegate_control_usrc_PriceList_Ask_To_Update(char chShop, DataTable dt_ShopB_Item_NotIn_PriceList);

        public delegate bool delegate_control_Get_Price_ShopBItem_Data(ref int iCount_Price_ShopBItem_Data, ID PriceList_id);

        public delegate void delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items();

        public delegate bool delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data(ID PriceList_ID);

        public delegate void delegate_control_usrc_Customer_Show_Customer_Person(TangentaDB.CurrentDoc x_CurrentDoc);

        public delegate void delegate_control_usrc_Customer_Show_Customer_Organisation(TangentaDB.CurrentDoc x_CurrentDoc);


        public delegate void delegate_Customer_Person_Changed(ID Customer_Person_ID);
        public delegate void delegate_Customer_Org_Changed(ID Customer_Org_ID);

        public delegate void delegate_Storno(bool bStorno);
        public delegate void delegate_control_chk_Storno_Check(bool bcheck);

        public Form MainForm = null;
        public Button btn_Show_Shops = null;

        private DocumentMan DocM = null;

        public class DoCurrent_delegates
        {
            public usrc_PriceList m_usrc_PriceListB;
            public usrc_PriceList m_usrc_PriceListC;
            public delegate_control_Set_ShowShops m_delegate_control_Set_ShowShops;
            public delegate_control_SetDraftButtons m_delegate_control_SetDraftButtons;
            public delegate_control_SetViewButtons m_delegate_control_SetViewButtons;
            public delegate_control_Show_Customer m_delegate_control_Show_Customer;
            public delegate_control_Customer_Text m_delegate_control_Customer_Text;
            public delegate_control_AddOn_Show m_delegate_control_AddOn_Show;
            public delegate_control_AddHandler m_delegate_control_AddHandler;
            public delegate_control_RemoveHandler m_delegate_control_RemoveHandler;
            public delegate_control_InvoiceNumber_Text m_delegate_control_InvoiceNumber_Text;
            public delegate_control_SetMode m_delegate_control_SetMode;
            public object m_usrc_ShopB;
            public delegate_control_SetCurrentInvoice_SelectedShopB_Items m_delegate_control_SetCurrentInvoice_SelectedShopB_Items;
            public delegate_control_SetCurrentInvoice_SelectedShopC_Items m_delegate_control_SetCurrentInvoice_SelectedShopC_Items;
            public delegate_control_ShowStornoCheckBox m_delegate_control_ShowStornoCheckBox;
            public delegate_control_SetStornoCheckBox m_delegate_control_SetStornoCheckBox;
            public delegate_control_ShopC_Reset m_delegate_control_ShopC_Reset;
            public delegate_control_ShopC_Clear m_delegate_control_ShopC_Clear;
            public DataTable m_dt_Item_Price_ShopA;
            public DataTable m_dt_SelectedShopBItem;
            public delegate_control_btn_Issue_Show m_delegate_control_btn_Issue_Show;
            public delegate_control_lbl_Sum_ForeColor m_delegate_control_lbl_Sum_ForeColor;
            public delegate_control_lbl_Sum_Text m_delegate_control_lbl_Sum_Text;
            public delegate_control_Get_Price_ShopBItem_Data m_delegate_control_Get_Price_ShopBItem_Data;
            public delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items m_delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items;
            public delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data m_delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data;

            public DoCurrent_delegates(
                                        usrc_PriceList xusrc_PriceListB,
                                        usrc_PriceList xusrc_PriceListC,
                                        delegate_control_Set_ShowShops xdelegate_control_Set_ShowShops,
                                        delegate_control_SetDraftButtons xdelegate_control_SetDraftButtons,
                                        delegate_control_SetViewButtons xdelegate_control_SetViewButtons,
                                        delegate_control_Show_Customer xdelegate_control_Show_Customer,
                                        delegate_control_Customer_Text xdelegate_control_Customer_Text,
                                        delegate_control_AddOn_Show xdelegate_control_AddOn_Show,
                                        delegate_control_AddHandler xdelegate_control_AddHandler,
                                        delegate_control_RemoveHandler xdelegate_control_RemoveHandler,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        object om_usrc_ShopB,
                                        delegate_control_SetCurrentInvoice_SelectedShopB_Items xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
                                        delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                        delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                        delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                        delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                        delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                        DataTable dt_Item_Price_ShopA,
                                        DataTable dt_SelectedShopBItem,
                                        delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                        delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                        delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text,
                                        delegate_control_Get_Price_ShopBItem_Data xdelegate_control_Get_Price_ShopBItem_Data,
                                        delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items xdelegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items,
                                        delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data)
            {
                m_usrc_PriceListB = xusrc_PriceListB;
                m_usrc_PriceListC = xusrc_PriceListC;
                m_delegate_control_Set_ShowShops = xdelegate_control_Set_ShowShops;
                m_delegate_control_SetDraftButtons = xdelegate_control_SetDraftButtons;
                m_delegate_control_SetViewButtons = xdelegate_control_SetViewButtons;
                m_delegate_control_Show_Customer = xdelegate_control_Show_Customer;
                m_delegate_control_Customer_Text = xdelegate_control_Customer_Text;
                m_delegate_control_AddOn_Show = xdelegate_control_AddOn_Show;
                m_delegate_control_AddHandler = xdelegate_control_AddHandler;
                m_delegate_control_RemoveHandler = xdelegate_control_RemoveHandler;
                m_delegate_control_InvoiceNumber_Text = xdelegate_control_InvoiceNumber_Text;
                m_delegate_control_SetMode = xdelegate_control_SetMode;
                m_usrc_ShopB = om_usrc_ShopB;
                m_delegate_control_SetCurrentInvoice_SelectedShopB_Items = xdelegate_control_SetCurrentInvoice_SelectedShopB_Items;
                m_delegate_control_SetCurrentInvoice_SelectedShopC_Items = xdelegate_control_SetCurrentInvoice_SelectedShopC_Items;
                m_delegate_control_ShowStornoCheckBox = xdelegate_control_ShowStornoCheckBox;
                m_delegate_control_SetStornoCheckBox = xdelegate_control_SetStornoCheckBox;
                m_delegate_control_ShopC_Reset = xdelegate_control_ShopC_Reset;
                m_delegate_control_ShopC_Clear = xdelegate_control_ShopC_Clear;
                m_dt_Item_Price_ShopA = dt_Item_Price_ShopA;
                m_dt_SelectedShopBItem = dt_SelectedShopBItem;
                m_delegate_control_btn_Issue_Show = xdelegate_control_btn_Issue_Show;
                m_delegate_control_lbl_Sum_ForeColor = xdelegate_control_lbl_Sum_ForeColor;
                m_delegate_control_lbl_Sum_Text = xdelegate_control_lbl_Sum_Text;
                m_delegate_control_Get_Price_ShopBItem_Data = xdelegate_control_Get_Price_ShopBItem_Data;
                m_delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items = xdelegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items;
                m_delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data = xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data;
            }

           
            public void Set(usrc_PriceList xusrc_PriceListB,
                                        usrc_PriceList xusrc_PriceListC,
                                        delegate_control_Set_ShowShops xdelegate_control_Set_ShowShops,
                                        delegate_control_SetDraftButtons xdelegate_control_SetDraftButtons,
                                        delegate_control_SetViewButtons xdelegate_control_SetViewButtons,
                                        delegate_control_Show_Customer xdelegate_control_Show_Customer,
                                        delegate_control_Customer_Text xdelegate_control_Customer_Text,
                                        delegate_control_AddOn_Show xdelegate_control_AddOn_Show,
                                        delegate_control_AddHandler xdelegate_control_AddHandler,
                                        delegate_control_RemoveHandler xdelegate_control_RemoveHandler,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        object om_usrc_ShopB,
                                        delegate_control_SetCurrentInvoice_SelectedShopB_Items xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
                                        delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                        delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                        delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                        delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                        delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                        DataTable dt_Item_Price_ShopA,
                                        DataTable dt_SelectedShopBItem,
                                        delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                        delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                        delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text,
                                        delegate_control_Get_Price_ShopBItem_Data xdelegate_control_Get_Price_ShopBItem_Data,
                                        delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items xdelegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items,
                                        delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data)
            {
                m_usrc_PriceListB = xusrc_PriceListB;
                m_usrc_PriceListC = xusrc_PriceListC;
                m_delegate_control_Set_ShowShops = xdelegate_control_Set_ShowShops;
                m_delegate_control_SetDraftButtons = xdelegate_control_SetDraftButtons;
                m_delegate_control_SetViewButtons = xdelegate_control_SetViewButtons;
                m_delegate_control_Show_Customer = xdelegate_control_Show_Customer;
                m_delegate_control_Customer_Text = xdelegate_control_Customer_Text;
                m_delegate_control_AddOn_Show = xdelegate_control_AddOn_Show;
                m_delegate_control_AddHandler = xdelegate_control_AddHandler;
                m_delegate_control_RemoveHandler = xdelegate_control_RemoveHandler;
                m_delegate_control_InvoiceNumber_Text = xdelegate_control_InvoiceNumber_Text;
                m_delegate_control_SetMode = xdelegate_control_SetMode;
                m_usrc_ShopB = om_usrc_ShopB;
                m_delegate_control_SetCurrentInvoice_SelectedShopB_Items = xdelegate_control_SetCurrentInvoice_SelectedShopB_Items;
                m_delegate_control_SetCurrentInvoice_SelectedShopC_Items = xdelegate_control_SetCurrentInvoice_SelectedShopC_Items;
                m_delegate_control_ShowStornoCheckBox = xdelegate_control_ShowStornoCheckBox;
                m_delegate_control_SetStornoCheckBox = xdelegate_control_SetStornoCheckBox;
                m_delegate_control_ShopC_Reset = xdelegate_control_ShopC_Reset;
                m_delegate_control_ShopC_Clear = xdelegate_control_ShopC_Clear;
                m_dt_Item_Price_ShopA = dt_Item_Price_ShopA;
                m_dt_SelectedShopBItem = dt_SelectedShopBItem;
                m_delegate_control_btn_Issue_Show = xdelegate_control_btn_Issue_Show;
                m_delegate_control_lbl_Sum_ForeColor = xdelegate_control_lbl_Sum_ForeColor;
                m_delegate_control_lbl_Sum_Text = xdelegate_control_lbl_Sum_Text;
                m_delegate_control_Get_Price_ShopBItem_Data = xdelegate_control_Get_Price_ShopBItem_Data;
                m_delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items = xdelegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items;
                m_delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data = xdelegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data;
            }
        }

        public enum emode
        {
            view_eDocumentType,
            edit_eDocumentType
        }

        public SettingsUserValues mSettingsUserValues = null;

        public ID Atom_Currency_ID = null;

        public LoginControl.LMOUser m_LMOUser = null;

        public Door door = null;


        public emode m_mode = emode.view_eDocumentType;

        public DBTablesAndColumnNamesOfDocInvoice DBtcn = new DBTablesAndColumnNamesOfDocInvoice();

        public TangentaDB.ShopABC m_ShopABC = null;


        private InvoiceData m_InvoiceData = null;
        public InvoiceData InvoiceData
        {
            get
            {
                return m_InvoiceData;
            }
            set
            {
                m_InvoiceData = value;
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

        public DocumentEditor(DocumentMan xdocman)
        {
            DocM = xdocman;
        }


        public decimal GrossSum = 0;
        public decimal NetSum = 0;
        public StaticLib.TaxSum TaxSum = null;


        internal bool chk_Storno_CanBe_ManualyChanged = true;


        public string DocTyp
        {
            get
            {
                return DocM.DocTyp;
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
                if (m_ShopABC.m_CurrentDoc.ShowDraftButtons())
                {
                    if (doCurrentDelegates.m_delegate_control_SetDraftButtons!=null)
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
                doCurrentDelegates.m_delegate_control_Show_Customer(m_ShopABC.m_CurrentDoc);
                doCurrentDelegates.m_delegate_control_AddOn_Show(xID);
                return true;
            }
            else
            {
                doCurrentDelegates.m_delegate_control_Customer_Text("");
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
                            doCurrent_delegates.m_delegate_control_SetCurrentInvoice_SelectedShopB_Items,
                            doCurrent_delegates.m_delegate_control_SetCurrentInvoice_SelectedShopC_Items,
                            doCurrent_delegates.m_delegate_control_ShowStornoCheckBox,
                            doCurrent_delegates.m_delegate_control_SetStornoCheckBox,
                            doCurrent_delegates.m_delegate_control_ShopC_Reset,
                            doCurrent_delegates.m_delegate_control_ShopC_Clear,
                            transaction
                            ))
            {
                GetPriceSum(doCurrent_delegates.m_dt_Item_Price_ShopA,
                            doCurrent_delegates.m_dt_SelectedShopBItem,
                            doCurrent_delegates.m_delegate_control_btn_Issue_Show,
                            doCurrent_delegates.m_delegate_control_lbl_Sum_ForeColor,
                            doCurrent_delegates.m_delegate_control_lbl_Sum_Text
                            );
                if (m_ShopABC.m_CurrentDoc.bDraft)
                {
                    doCurrent_delegates.m_delegate_control_AddHandler();
                }
                else
                {
                    if (m_ShopABC.m_CurrentDoc.Exist)
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
                                delegate_control_SetCurrentInvoice_SelectedShopB_Items xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
                                delegate_control_SetCurrentInvoice_SelectedShopC_Items xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                delegate_control_ShowStornoCheckBox xdelegate_control_ShowStornoCheckBox,
                                delegate_control_SetStornoCheckBox xdelegate_control_SetStornoCheckBox,
                                delegate_control_ShopC_Reset xdelegate_control_ShopC_Reset,
                                delegate_control_ShopC_Clear xdelegate_control_ShopC_Clear,
                                Transaction transaction
                                )
        {
            if (DocTyp != null)
            {
                if (DocTyp.Equals(GlobalData.const_DocInvoice) || DocTyp.Equals(GlobalData.const_DocProformaInvoice))
                {
                    return GetCurrentInvoice(xID,
                                            xdelegate_control_InvoiceNumber_Text,
                                            xdelegate_control_SetMode,
                                            xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
                                            xdelegate_control_SetCurrentInvoice_SelectedShopC_Items,
                                            xdelegate_control_ShowStornoCheckBox,
                                            xdelegate_control_SetStornoCheckBox,
                                            xdelegate_control_ShopC_Reset,
                                            xdelegate_control_ShopC_Clear,
                                            transaction
                                            );
                }
                else
                {
                    LogFile.Error.Show("Tangenta:usrc_DocumentEditor:GetCurrent(ID xID):DocType=" + DocTyp + " is not implemented!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("Tangenta:usrc_DocumentEditor:GetCurrent(ID xID):DocType is null !");
                return false;
            }

        }

        private bool GetCurrentInvoice(ID DocInvoice_ID,
                                       delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text,
                                       delegate_control_SetMode xdelegate_control_SetMode,
                                       delegate_control_SetCurrentInvoice_SelectedShopB_Items xdelegate_control_SetCurrentInvoice_SelectedShopB_Items,
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

            if (m_ShopABC.Get(true,
                          DocInvoice_ID,
                          xAtom_myOrganisation_Person_Tax_ID,
                          m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName,
                          m_LMOUser.Atom_ElectronicDevice_Name,
                          ref Err,
                          transaction)) // try to get draft
            {
                xdelegate_control_InvoiceNumber_Text(DocumentMan.GetInvoiceNumber(m_ShopABC.m_CurrentDoc.bDraft, m_ShopABC.m_CurrentDoc.FinancialYear, m_ShopABC.m_CurrentDoc.NumberInFinancialYear, m_ShopABC.m_CurrentDoc.DraftNumber));
                if (m_ShopABC.m_CurrentDoc.bDraft)
                {
                    SetMode(DocumentEditor.emode.edit_eDocumentType, xdelegate_control_SetMode);
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopB_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopB_Items(); //this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    }
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopC_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopC_Items(); //this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    }
                }
                else
                {
                    SetMode(DocumentEditor.emode.view_eDocumentType, xdelegate_control_SetMode);
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopB_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopB_Items(); //this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    }
                    if (xdelegate_control_SetCurrentInvoice_SelectedShopC_Items != null)
                    {
                        xdelegate_control_SetCurrentInvoice_SelectedShopC_Items(); //this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    }
                    chk_Storno_CanBe_ManualyChanged = false;
                    if (DocM.IsDocInvoice)
                    {
                        xdelegate_control_ShowStornoCheckBox(true);// this.chk_Storno.Visible = true;
                        if (m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v != null)
                        {
                            xdelegate_control_SetStornoCheckBox(m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v.v);// this.chk_Storno.Checked = m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v.v;
                        }
                        else
                        {
                            xdelegate_control_SetStornoCheckBox(false);// this.chk_Storno.Checked = false;
                        }
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                    else
                    {
                        xdelegate_control_ShowStornoCheckBox(false);//this.chk_Storno.Visible = false;
                    }
                }
                if (xdelegate_control_ShopC_Reset != null)
                {
                    xdelegate_control_ShopC_Reset();// this.m_usrc_ShopC.Reset();
                   
                }
                return true;
            }
            else
            {
                SetMode(DocumentEditor.emode.view_eDocumentType, xdelegate_control_SetMode);
                string sxAtom_myOrganisation_Person_Tax_ID = m_LMOUser.Atom_myOrganisation_Person_Tax_ID;
                if (m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
                {
                    sxAtom_myOrganisation_Person_Tax_ID = null;
                }

                if (m_ShopABC.Get(false,
                                  DocInvoice_ID,
                                  sxAtom_myOrganisation_Person_Tax_ID,
                                  m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName,
                                  m_LMOUser.Atom_ElectronicDevice_Name,
                                  ref Err,
                                  transaction)) // Get invoice with Invoice_ID
                {
                    xdelegate_control_InvoiceNumber_Text(DocumentMan.GetInvoiceNumber(m_ShopABC.m_CurrentDoc.bDraft, m_ShopABC.m_CurrentDoc.FinancialYear, m_ShopABC.m_CurrentDoc.NumberInFinancialYear, m_ShopABC.m_CurrentDoc.DraftNumber));// this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.m_CurrentDoc.bDraft, m_ShopABC.m_CurrentDoc.FinancialYear, m_ShopABC.m_CurrentDoc.NumberInFinancialYear, m_ShopABC.m_CurrentDoc.DraftNumber);//

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

        private void SetMode(DocumentEditor.emode mode, delegate_control_SetMode xdelegate_control_SetMode)
        {
            m_mode = mode;
            xdelegate_control_SetMode(mode);
        }


        public void GetPriceSum(DataTable dt_Item_Price_ShopA,
                                DataTable dt_SelectedShopBItem,
                                delegate_control_btn_Issue_Show xdelegate_control_btn_Issue_Show,
                                delegate_control_lbl_Sum_ForeColor xdelegate_control_lbl_Sum_ForeColor,
                                delegate_control_lbl_Sum_Text xdelegate_control_lbl_Sum_Text
)
        {
            decimal dsum_GrossSum = 0;
            decimal dsum_TaxSum = 0;
            decimal dsum_NetSum = 0;


            TaxSum = null;
            TaxSum = new StaticLib.TaxSum();

            if (dt_Item_Price_ShopA != null)
            {
                foreach (DataRow dr in dt_Item_Price_ShopA.Rows) //foreach (DataRow dr in this.m_usrc_ShopA.dt_Item_Price.Rows)
                {
                    decimal price = (decimal)dr[DocTyp + "_ShopA_Item_$$EndPriceWithDiscountAndTax"];
                    decimal tax = (decimal)dr[DocTyp + "_ShopA_Item_$$TAX"];
                    decimal tax_rate = (decimal)dr[DocTyp + "_ShopA_Item_$_aisha_$_tax_$$Rate"];
                    string tax_name = (string)dr[DocTyp + "_ShopA_Item_$_aisha_$_tax_$$Name"];
                    dsum_GrossSum += price;
                    TaxSum.Add(tax, 0, tax_name, tax_rate);
                    dsum_NetSum += price - tax;
                }
            }

            if (dt_SelectedShopBItem != null)
            {
                foreach (DataRow dr in dt_SelectedShopBItem.Rows) //foreach (DataRow dr in this.m_usrc_ShopB.dt_SelectedShopBItem.Rows)
                {
                    decimal price = (decimal)dr["SelectedSimpleItemPrice"];
                    decimal tax = (decimal)dr["SelectedSimpleItemPriceTax"];
                    decimal tax_rate = (decimal)dr["SelectedSimpleItem_TaxRate"];
                    string tax_name = (string)dr["SelectedSimpleItem_TaxName"];
                    dsum_GrossSum += price;
                    TaxSum.Add(tax, 0, tax_name, tax_rate);
                    dsum_NetSum += price - tax;
                }
            }

            decimal dsum_GrossSum_Basket = 0;
            decimal dsum_TaxSum_Basket = 0;
            decimal dsum_NetSum_Basket = 0;

            if (m_ShopABC.m_CurrentDoc.m_Basket!=null)
            {
                m_ShopABC.m_CurrentDoc.m_Basket.GetPriceSum(ref dsum_GrossSum_Basket, ref dsum_TaxSum_Basket, ref dsum_NetSum_Basket, ref TaxSum);
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
            if (DocM.IsDocInvoice)
            {
                if (m_ShopABC.m_CurrentDoc.TInvoice.StornoDocInvoice_ID == null)
                {
                    sGrossSum = dsum_GrossSum.ToString();
                    xdelegate_control_lbl_Sum_ForeColor(Color.Black);// this.lbl_Sum.ForeColor = Color.Black;
                }
                else
                {
                    sGrossSum = dsum_GrossSum.ToString();
                    decimal_v dGrossSum_v = tf.set_decimal(m_ShopABC.m_CurrentDoc.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$GrossSum"]);
                    if (dGrossSum_v != null)
                    {
                        if (dGrossSum_v.v < 0)
                        {
                            sGrossSum = dGrossSum_v.v.ToString();
                        }
                    }
                    xdelegate_control_lbl_Sum_ForeColor(Color.Red); //this.lbl_Sum.ForeColor = Color.Red;
                }
            }
            else if (DocM.IsDocProformaInvoice)
            {
                sGrossSum = dsum_GrossSum.ToString();
                xdelegate_control_lbl_Sum_ForeColor(Color.Black);//this.lbl_Sum.ForeColor = Color.Black;
            }
            xdelegate_control_lbl_Sum_Text(sGrossSum + " " + GlobalData.BaseCurrency.Symbol);// this.lbl_Sum.Text = sGrossSum + " " + GlobalData.BaseCurrency.Symbol;// +" tax:" + TaxSum.ToString() + " " + NetSum.ToString();
        }

  
        public void btn_Issue_Click(
                                    Form pform,
                                    delegate_control_Check_DocInvoice_AddOn xdelegate_control_Check_DocInvoice_AddOn,
                                    delegate_control_Get_Doc_AddOn xdelegate_control_Get_Doc_AddOn,
                                    delegate_control_Check_DocProformaInvoice_AddOn xdelegate_control_Check_DocproformaInvoice_AddOn,
                                    delegate_control_Get_DocProforma_AddOn xdelegate_control_Get_DocProforma_AddOn,
                                    delegate_control_DoCurrent xdelegate_control_DoCurrent,
                                    delegate_DocInvoiceSaved xdelegate_DocInvoiceSaved,
                                    delegate_DocProformaInvoiceSaved xdelegate_DocProformaInvoiceSaved
                                    )
        {
            if (m_ShopABC != null)
            {
                if (m_ShopABC.m_CurrentDoc != null)
                {
                    if (m_ShopABC.m_CurrentDoc.Exist)
                    {
                        if (m_ShopABC.m_CurrentDoc.bDraft)
                        {

                            if ((TSettings.RecordCashierActivity) && (TSettings.CashierState == TangentaDB.CashierActivity.eCashierState.CLOSED))
                            {
                                XMessage.Box.Show(pform, lng.s_YouCanNotWriteInvoices_CasshierIsClosed, MessageBoxIcon.Stop);
                                return;
                            }

                            if (DocM.IsDocInvoice)
                            {
                                if (!xdelegate_control_Check_DocInvoice_AddOn(InvoiceData.AddOnDI))// if (!usrc_AddOn1.Check_DocInvoice_AddOn(DocE.m_InvoiceData.AddOnDI))
                                {
                                    if (!xdelegate_control_Get_Doc_AddOn(true)) //if(!usrc_AddOn1.Get_Doc_AddOn(true))
                                    {
                                        return;
                                    }
                                    if (!xdelegate_control_Check_DocInvoice_AddOn(InvoiceData.AddOnDI))//if (!usrc_AddOn1.Check_DocInvoice_AddOn(DocE.m_InvoiceData.AddOnDI))
                                    {
                                        return;
                                    }
                                }
                            }
                            else if (DocM.IsDocProformaInvoice)
                            {
                                if (!xdelegate_control_Check_DocproformaInvoice_AddOn(InvoiceData.AddOnDPI))  //  if (!usrc_AddOn1.Check_DocProformaInvoice_AddOn(DocE.m_InvoiceData.AddOnDPI))
                                {
                                    if (!xdelegate_control_Get_DocProforma_AddOn(true))// if (!usrc_AddOn1.Get_Doc_AddOn(true))
                                    {
                                        return;
                                    }
                                    if (!xdelegate_control_Check_DocproformaInvoice_AddOn(InvoiceData.AddOnDPI)) //if (!usrc_AddOn1.Check_DocProformaInvoice_AddOn(DocE.m_InvoiceData.AddOnDPI))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:uscr_Invoice:btn_Issue_Click:Unknown doc type.");
                            }

                            Transaction transaction_DocumentEditor_IssueDocument = DBSync.DBSync.NewTransaction("DocumentEditor_IssueDocument");

                            

                            if (IssueDocument(pform,this,xdelegate_DocInvoiceSaved, xdelegate_DocProformaInvoiceSaved, transaction_DocumentEditor_IssueDocument))
                            {
                                if (xdelegate_control_DoCurrent(m_ShopABC.m_CurrentDoc.Doc_ID, transaction_DocumentEditor_IssueDocument))// DoCurrent(m_ShopABC.m_CurrentDoc.Doc_ID);
                                {
                                    if (!transaction_DocumentEditor_IssueDocument.Commit())
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    transaction_DocumentEditor_IssueDocument.Rollback();
                                }
                            }
                            else
                            {
                                transaction_DocumentEditor_IssueDocument.Rollback();
                            }
                            return;
                        }
                        else
                        {
                            //Print existing invoice
                            InvoiceData.DocInvoice_ID = m_ShopABC.m_CurrentDoc.Doc_ID;
                            Transaction transaction_m_InvoiceData_Read_DocInvoice = DBSync.DBSync.NewTransaction("m_InvoiceData.Read_DocInvoice");
                            if (DocM.IsDocInvoice)
                            {
                                InvoiceData.AddOnDI.b_FVI_SLO = TSettings.b_FVI_SLO;
                                if (InvoiceData.Read_DocInvoice(transaction_m_InvoiceData_Read_DocInvoice)) // read Proforma Invoice again from DataBase
                                { // print invoice if you wish
                                    if (transaction_m_InvoiceData_Read_DocInvoice.Commit())
                                    {
                                        if (InvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
                                        {
                                            InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = TSettings.FVI_SLO1.GetQRImage(InvoiceData.AddOnDI.m_FURS.FURS_QR_v.v);
                                            InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
                                        }
                                        Printing_DocInvoice(pform, null);//Printing_DocInvoice();
                                                                                //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                                                                //frm_Print_Existing_invoice.ShowDialog(this);
                                    }
                                }
                                else
                                {
                                    transaction_m_InvoiceData_Read_DocInvoice.Rollback();
                                }
                            }
                            else
                            {
                                if (InvoiceData.Read_DocInvoice(transaction_m_InvoiceData_Read_DocInvoice)) // read Proforma Invoice again from DataBase
                                {
                                    if (transaction_m_InvoiceData_Read_DocInvoice.Commit())
                                    {
                                        Printing_DocInvoice(pform,null);//Printing_DocInvoice();
                                                                                //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                                                                //frm_Print_Existing_invoice.ShowDialog(this);
                                    }
                                }
                                else
                                {
                                    transaction_m_InvoiceData_Read_DocInvoice.Rollback();
                                }
                            }
                        }
                    }
                }
            }
        }

        internal bool Printing_DocInvoice(Control parentControl, Transaction transaction)
        {
            Printer printer = null;
            if (PrintersList.PrintingWithHtmlTemplate(DocTyp, ref printer))
            {
                if (transaction != null)
                {
                    transaction.Commit();
                }

                Form parentform = Global.f.GetParentForm(parentControl);
                TangentaPrint.Form_PrintDocument template_dlg = new TangentaPrint.Form_PrintDocument(m_LMOUser.Atom_WorkPeriod_ID, InvoiceData, TangentaResources.Properties.Resources.Exit, door.OpenIfUserIsAdministrator);
                template_dlg.Owner = Global.f.GetParentForm(parentform);
                if (template_dlg.ShowDialog(parentform) == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
            else
            {
                PrintDocInvoice prndocinvoice = new PrintDocInvoice(printer.PrinterName, InvoiceData);
       
                if (prndocinvoice.Print(DocumentMan.MainForm))
                {
                    if (transaction == null)
                    {
                        transaction = DBSync.DBSync.NewTransaction("DocumentEditor.SetCopyPrintInfo");
                    }
                    if (InvoiceData.SetCopyPrintInfo(m_LMOUser.Atom_WorkPeriod_ID,
                                                     printer.PrinterName,
                                                     transaction))
                    {
                        return transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }

                return true;
            }
        }

        public bool GetUnits()
        {
            if (m_ShopABC.m_xUnitList == null)
            {
                m_ShopABC.m_xUnitList = new xUnitList();
            }
            string Err = null;
            DataTable dt = new DataTable();
            if (m_ShopABC.m_xUnitList.Get(ref dt, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:GetUnits:m_xUnitList.Get:Err=" + Err);
                return false;
            }
        }

        private bool GetPriceList_ShopB(ref ID price_list_id, usrc_PriceList usrc_PriceListB)
        {
            string Err = null;
            bool bGet = true;
            NavigationButtons.Navigation nav_PriceList = new NavigationButtons.Navigation(null);
            nav_PriceList.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            if (!usrc_PriceListB.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopB, PropertiesUser.ShopsInUse_Get(mSettingsUserValues), ref price_list_id, ref Err))
            {
                bGet = false;
            }
            return bGet;
        }

        internal string GetDocType()
        {
            return DocM.DocTyp;
        }

        private void usrc_PriceList_Ask_To_Update(Form pForm, usrc_PriceList usrc_PriceList1, char chShop, DataTable dt_ShopB_Item_NotIn_PriceList)
        {
            if (PriseLists.usrc_PriceList.Ask_To_Update(chShop, dt_ShopB_Item_NotIn_PriceList, pForm))
            {
                Transaction transaction_usrc_DocumentEditor_Insert_ShopB_Items_in_PriceList = DBSync.DBSync.NewTransaction("usrc_DocumentEditor.Insert_ShopB_Items_in_PriceList");
                if (f_PriceList.Insert_ShopB_Items_in_PriceList(dt_ShopB_Item_NotIn_PriceList, pForm, transaction_usrc_DocumentEditor_Insert_ShopB_Items_in_PriceList))
                {
                    if (transaction_usrc_DocumentEditor_Insert_ShopB_Items_in_PriceList.Commit())
                    {
                        bool bPriceListChanged = false;
                        usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                    }
                }
                else
                {
                    transaction_usrc_DocumentEditor_Insert_ShopB_Items_in_PriceList.Rollback();
                }
            }
        }

        public bool Init(Form pform,
                          Button xbtnShowShops,
                          ID document_ID,
                          ref ID ShopB_pricelist_ID,
                          ref ID ShopC_pricelist_ID,
                          DocumentEditor.DoCurrent_delegates doCurrent_delegates,
                          Transaction transaction)
        {
            this.MainForm = pform;
            this.btn_Show_Shops = xbtnShowShops;
            if (DBtcn == null)
            {
                DBtcn = new DBTablesAndColumnNamesOfDocInvoice();
            }
            if (m_ShopABC == null)
            {
                m_ShopABC = new ShopABC(GetDocType, DBtcn, m_LMOUser.Atom_WorkPeriod_ID);
            }
            if (InvoiceData == null)
            {
                InvoiceData = new InvoiceData(m_ShopABC, document_ID, GlobalData.ElectronicDevice_Name);
            }
            else
            {
                InvoiceData.DocInvoice_ID = document_ID;
            }

            string showshops = TangentaProperties.Properties.Settings.Default.eShowShops;
            if (mSettingsUserValues != null)
            {
                if (mSettingsUserValues.eShowShops.Length == 0)
                {
                    mSettingsUserValues.eShowShops = showshops;
                }
                else
                {
                    showshops = mSettingsUserValues.eShowShops;
                }
            }

            doCurrent_delegates.m_delegate_control_Set_ShowShops(PropertiesUser.ShowShops_Get(mSettingsUserValues));// Set_ShowShops(mSettingsUserValues.eShowShops);
            GetUnits();

            DataTable dt_ShopB_Item_NotIn_PriceList = new DataTable();
            if (doCurrent_delegates.m_usrc_PriceListB != null)
            { 
                if (GetPriceList_ShopB(ref ShopB_pricelist_ID, doCurrent_delegates.m_usrc_PriceListB))
                {
                    if (f_PriceList.Check_All_ShopB_Items_In_PriceList(ref dt_ShopB_Item_NotIn_PriceList))
                    {
                        if (dt_ShopB_Item_NotIn_PriceList.Rows.Count > 0)
                        {
                            usrc_PriceList_Ask_To_Update(pform, doCurrent_delegates.m_usrc_PriceListB,'B', dt_ShopB_Item_NotIn_PriceList);
                        }
                        else
                        {
                            bool bEdit = false;
                            f_PriceList.CheckPriceUndefined_ShopB(ref bEdit);
                            if (bEdit)
                            {
                                //bool bPriceListChanged = false;
                                //this.m_usrc_ShopB.usrc_PriceList1.PriceList_Edit(true,xnav, ref bPriceListChanged);

                            }
                        }
                    }
                }

                int iCount_Price_SimpleItem_Data = 0;
                if (Get_Price_SimpleItem_Data(pform,
                                             ref iCount_Price_SimpleItem_Data,
                                              ShopB_pricelist_ID,
                                              doCurrent_delegates.m_delegate_control_Get_Price_ShopBItem_Data))
                {
                    doCurrent_delegates.m_delegate_control_m_usrc_ShopB_Set_dgv_SelectedShopB_Items();// this.m_usrc_ShopB.Set_dgv_SelectedShopB_Items();
                }
            }
            
           

            if (PropertiesUser.ShopsInUse_Get(mSettingsUserValues).Contains("C"))
            {
                if (GetPriceList_ShopC(ref ShopC_pricelist_ID, doCurrent_delegates.m_usrc_PriceListC))
                {
                    DataTable dt_ShopC_Item_NotIn_PriceList = new DataTable();
                    if (f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Item_NotIn_PriceList))
                    {
                        if (dt_ShopC_Item_NotIn_PriceList.Rows.Count > 0)
                        {
                            usrc_PriceList_Ask_To_Update(pform,doCurrent_delegates.m_usrc_PriceListC,'C', dt_ShopC_Item_NotIn_PriceList);
                            //if (PriseLists.usrc_PriceList.Ask_To_Update('C', dt_ShopC_Item_NotIn_PriceList, this))
                            //{
                            //    if (f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Item_NotIn_PriceList, this))
                            //    {
                            //        bool bPriceListChanged = false;
                            //        this.m_usrc_ShopC.usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                            //    }
                            //}
                        }
                        else
                        {
                            bool bEdit = false;
                            f_PriceList.CheckPriceUndefined_ShopC(ref bEdit);
                            if (bEdit)
                            {
                                //bool bPriceListChanged = false;
                                //this.m_usrc_ShopC.usrc_PriceList1.PriceList_Edit(true,xnav, ref bPriceListChanged);
                            }
                        }
                    }

                    //if (this.m_usrc_ShopC.usrc_ItemList.Get_Price_Item_Stock_Data(this.m_usrc_ShopC.usrc_PriceList1.ID))
                    if (doCurrent_delegates.m_delegate_control_m_usrc_ShopC_usrc_ItemList_Get_Price_Item_Stock_Data(ShopC_pricelist_ID))
                    {
                        if (TSettings.bStartup)
                        {
                            TSettings.bStartup = false;

                            if (DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.TextValue.Equals("1"))
                            {
                                bool ExpiryItemsFound = false;
                                string sNoExpiryDate = null;
                                string sNoSaleBeforeExpiryDate = null;
                                string sNoDiscardBeforeExpiryDate = null;
                                DataTable dt_ExpiryCheck = new DataTable();
                                if (fs.ExpiryCheck(ref dt_ExpiryCheck, ref ExpiryItemsFound, ref sNoExpiryDate, ref sNoSaleBeforeExpiryDate, ref sNoDiscardBeforeExpiryDate))
                                {
                                    if (ExpiryItemsFound)
                                    {
                                        Form_Expiry_Check frm_exp_chk = new Form_Expiry_Check(dt_ExpiryCheck, pform, sNoExpiryDate, sNoSaleBeforeExpiryDate, sNoDiscardBeforeExpiryDate);
                                        frm_exp_chk.ShowDialog();
                                    }

                                    //return DoCurrent(Document_ID);
                                    return this.DoCurrent(document_ID,doCurrent_delegates,transaction) ; //xdelegate_control_DoCurrent(document_ID, transaction);
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
                            return this.DoCurrent(document_ID,doCurrent_delegates, transaction); 
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
            if (ID.Validate(document_ID))
            {
                return this.DoCurrent(document_ID,doCurrent_delegates, transaction);
            }
            else
            {
                return true;
            }
        }

        private bool GetPriceList_ShopC(ref ID price_list_ID, usrc_PriceList usrc_PriceListC)
        {
            string Err = null;
            bool bGet = true;
            NavigationButtons.Navigation nav_PriceList = new NavigationButtons.Navigation(null);
            nav_PriceList.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            if (!usrc_PriceListC.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopC, PropertiesUser.ShopsInUse_Get(mSettingsUserValues), ref price_list_ID, ref Err))
            {
                bGet = false;
            }
            return bGet;
        }



        internal bool Get_Price_SimpleItem_Data(Form pform,
                                                ref int iCount_Price_SimpleItem_Data,
                                                ID PriceList_id,
                                                delegate_control_Get_Price_ShopBItem_Data xdelegate_control_Get_Price_ShopBItem_Data)
        {
            //if (this.m_usrc_ShopB.Get_Price_ShopBItem_Data(ref iCount_Price_SimpleItem_Data, PriceList_id))
            if (xdelegate_control_Get_Price_ShopBItem_Data(ref iCount_Price_SimpleItem_Data, PriceList_id))
            {
                if (iCount_Price_SimpleItem_Data > 0)
                {
                    return true;
                }
                else
                {
                    if (PropertiesUser.ShopsInUse_Get(mSettingsUserValues).Contains("B"))
                    {
                        string smsg = lng.s_No_ShopB_Items_or_no_prices_for_those_items.s.Replace("%s", lng.s_Shop_B.s);
                        MessageBox.Show(pform, smsg);
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }




        private bool IssueDocument(Form pform,
                                    DocumentEditor docE,
                                    delegate_DocInvoiceSaved xdelegate_DocInvoiceSaved,
                                    delegate_DocProformaInvoiceSaved xdelegate_DocProformaInvoiceSaved,
                                    Transaction transaction)
        {
            //ProgramDiagnostic.Diagnostic.Enabled = true;
            //ProgramDiagnostic.Diagnostic.Init();
            //ProgramDiagnostic.Diagnostic.Clear();
            //ProgramDiagnostic.Diagnostic.Meassure("Before fs.UpdatePriceInDraft", "?");
            
            if (fs.UpdatePriceInDraft(DocTyp, m_ShopABC.m_CurrentDoc.Doc_ID, GrossSum, TaxSum.Value,NetSum, transaction))
            {
                if (DocM.IsDocInvoice)
                {
                    InvoiceData.AddOnDI.b_FVI_SLO = TSettings.b_FVI_SLO;

                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (InvoiceData.SaveDocInvoice(ref DocInvoice_ID, TSettings.CashierActivity, GlobalData.ElectronicDevice_Name, m_LMOUser.Atom_WorkPeriod_ID, transaction))
                    {

                        m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;

                        if (TSettings.b_FVI_SLO)
                        {

                            if ((InvoiceData.AddOnDI.IsCashPayment && TSettings.FVI_SLO1.FVI_for_cash_payment)
                                || (InvoiceData.AddOnDI.IsCardPayment && TSettings.FVI_SLO1.FVI_for_card_payment)
                                || (InvoiceData.AddOnDI.IsPaymentOnBankAccount && TSettings.FVI_SLO1.FVI_for_payment_on_bank_account)
                                )
                            {
                                UniversalInvoice.Person xInvoiceAuthor = fs.GetInvoiceAuthor(m_LMOUser.Atom_myOrganisation_Person_ID);
                                this.SendInvoice(pform,GrossSum, TaxSum, xInvoiceAuthor, transaction);
                            }
                        }

                        // read saved doc Invoice again !
                        if (InvoiceData.Read_DocInvoice(transaction))
                        {
                            xdelegate_DocInvoiceSaved(m_ShopABC.m_CurrentDoc.Doc_ID);
                            Printing_DocInvoice(pform, transaction);// Printing_DocInvoice();
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
                else if (DocM.IsDocProformaInvoice)
                {
                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (InvoiceData.SaveDocProformaInvoice(ref DocInvoice_ID, GlobalData.ElectronicDevice_Name, m_LMOUser.Atom_WorkPeriod_ID,transaction))
                    {
                        m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;
                        // read saved doc Invoice again !
                        if (InvoiceData.Read_DocInvoice(transaction))
                        {
                            xdelegate_DocProformaInvoiceSaved(m_ShopABC.m_CurrentDoc.Doc_ID);
                            Printing_DocInvoice(pform, transaction);// Printing_DocInvoice();
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

        private void SendInvoice(Form pform,decimal dGrossSum, StaticLib.TaxSum xTaxSum, UniversalInvoice.Person xInvoiceAuthor, Transaction transaction)
        {
            //if (m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
            //{
            //m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = Program.usrc_FVI_SLO1.GetQRImage(m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v.v);
            //    m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
            //}
            //else
            //{
            string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(false,
                                   TangentaResources.Properties.Resources.FVI_SLO_Invoice,
                                   TSettings.FVI_SLO1.FursD_MyOrgTaxID,
                                   TSettings.FVI_SLO1.FursD_BussinesPremiseID,
                                   GlobalData.ElectronicDevice_Name,
                                   TSettings.FVI_SLO1.FursD_InvoiceAuthorTaxID,
                                   "", "",
                                   InvoiceData.IssueDate_v,
                                   InvoiceData.NumberInFinancialYear,
                                   dGrossSum,
                                   xTaxSum,
                                   xInvoiceAuthor //ToDo : Get real Invoice Autor here!
                                   );
            Image img_QR = null;
            string furs_UniqeMsgID = null;
            string furs_UniqeInvID = null;
            string furs_BarCodeValue = null;

            FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post eres = TSettings.FVI_SLO1.Send_SingleInvoice(false, furs_XML,pform, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR);
            switch (eres)
            {

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK:
                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.TIMEOUT:
                    InvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                    InvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                    InvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                    InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = img_QR;
                    InvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(InvoiceData.DocInvoice_ID, TSettings.FVI_SLO1.FursTESTEnvironment, transaction);
                    break;

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.ERROR:

                    string xSerialNumber = null;
                    string xSetNumber = null;
                    string xInvoiceNumber = null;
                    TSettings.FVI_SLO1.Write_SalesBookInvoice(InvoiceData.DocInvoice_ID, InvoiceData.FinancialYear, InvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                    ID FVI_SLO_SalesBookInvoice_ID = null;
                    if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(InvoiceData.DocInvoice_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID, transaction))
                    {
                        MessageBox.Show("Račun je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");

                        //LK SalesBookInvoice  prestavi na gumb
                        //string furs_XML_SB = m_InvoiceData.Create_furs_SalesBookInvoiceXML(Program.usrc_FVI_SLO1.XML_Template_FVI_SLO_SalesBook, Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID, xSetNumber, xSerialNumber);
                        //if (Program.usrc_FVI_SLO1.Send_SingleInvoice(furs_XML_SB, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                        //{
                        //    m_InvoiceData.FURS_Response_Data = new FURS_Response_data(furs_UniqeMsgID, furs_UniqeInvID, furs_BarCodeValue, img_QR);
                        //    m_InvoiceData.FURS_Response_Data.Image_QRcode = img_QR;
                        //    m_InvoiceData.Write_FURS_Response_Data();
                        //}
                    }
                    break;


            }
            InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
        }


        public void SetNewDraft(Form pform,
                                LMOUser xLMOUser,
                                string DocTyp,
                                int xFinancialYear,
                                xCurrency xcurrency,
                                ID Atom_Currency_ID,
                                WArea workArea,
                                delegate_control_SetMode xdelegate_control_SetMode,
                                delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text)
        {
            if (DocTyp.Equals(GlobalData.const_DocInvoice) || DocTyp.Equals(GlobalData.const_DocProformaInvoice))
            {
                if (m_ShopABC == null)
                {
                    m_ShopABC = new ShopABC(GetDocType, DBtcn, m_LMOUser.Atom_WorkPeriod_ID);
                }
                if (SetNewInvoiceDraft(pform,
                                        xLMOUser,
                                        xFinancialYear,
                                        xcurrency,
                                        Atom_Currency_ID, workArea,
                                        xdelegate_control_SetMode,
                                        xdelegate_control_InvoiceNumber_Text))
                {
                    xdelegate_control_SetMode(DocumentEditor.emode.edit_eDocumentType);// SetMode(DocumentEditor.emode.edit_eDocumentType);
                }
                return;
            }
            return;

        }

        public bool SetNewInvoiceDraft( Form pform,
                                        LMOUser xLMOUser,
                                        int FinancialYear,
                                        xCurrency xcurrency,
                                        ID xAtom_Currency_ID,
                                        WArea workArea,
                                        delegate_control_SetMode xdelegate_control_SetMode,
                                        delegate_control_InvoiceNumber_Text xdelegate_control_InvoiceNumber_Text)
        {
            ID DocInvoice_ID = null;
            string Err = null;
            if (OperationMode.MultiUser)
            {
                myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(xLMOUser.myOrganisation_Person_ID);
            }

            if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
            {
                LogFile.Error.Show("ERROR:SetInvoiceDraft:Can not find my oragnisation person!");
                return false;
            }

            Transaction transaction_SetNewInvoiceDraft = DBSync.DBSync.NewTransaction("SetNewInvoiceDraft");
            ID xAtom_WorkArea_ID = null;
            if (workArea != null)
            {
                if (!f_Atom_WorkArea.Get(workArea.Name, workArea.Description, ref xAtom_WorkArea_ID, transaction_SetNewInvoiceDraft))
                {
                    transaction_SetNewInvoiceDraft.Rollback();
                    return false;
                }
            }

            if (m_ShopABC.SetNewDraft_DocInvoice(m_LMOUser.Atom_WorkPeriod_ID, FinancialYear, xcurrency, xAtom_Currency_ID, pform, ref DocInvoice_ID, myOrg.m_myOrg_Office.m_myOrg_Person.ID, xAtom_WorkArea_ID, DocTyp, GlobalData.ElectronicDevice_Name, ref Err, transaction_SetNewInvoiceDraft))
            {
                if (transaction_SetNewInvoiceDraft.Commit())
                {
                    if (ID.Validate(m_ShopABC.m_CurrentDoc.Doc_ID))
                    {
                        xdelegate_control_InvoiceNumber_Text(m_ShopABC.m_CurrentDoc.FinancialYear.ToString() + "/" + m_ShopABC.m_CurrentDoc.DraftNumber.ToString()); // this.txt_Number.Text = DocE.m_ShopABC.m_CurrentDoc.FinancialYear.ToString() + "/" + DocE.m_ShopABC.m_CurrentDoc.DraftNumber.ToString();
                        xdelegate_control_SetMode(DocumentEditor.emode.edit_eDocumentType);// SetMode(DocumentEditor.emode.edit_eDocumentType);
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
                transaction_SetNewInvoiceDraft.Rollback();
                LogFile.Error.Show("ERROR:SetInvoiceDraft:Err=" + Err);
                return false;
            }
        }


        public void Customer_Person_Changed(ID Customer_Person_ID,
                                            delegate_control_usrc_Customer_Show_Customer_Person xdelegate_control_usrc_Customer_Show_Customer_Person,
                                            delegate_Customer_Person_Changed xdelegate_Customer_Person_Changed
                                            )
        {
            ID Atom_Customer_Person_ID = null;
            Transaction transaction_Customer_Person_Changed = DBSync.DBSync.NewTransaction("Customer_Person_Changed");
            if (m_ShopABC.m_CurrentDoc.Update_Customer_Person(DocTyp, Customer_Person_ID, ref Atom_Customer_Person_ID, transaction_Customer_Person_Changed))
            {
                if (ID.Validate(Atom_Customer_Person_ID))
                {
                    if (!transaction_Customer_Person_Changed.Commit())
                    {
                        return;
                    }
                    xdelegate_control_usrc_Customer_Show_Customer_Person(m_ShopABC.m_CurrentDoc);// usrc_Customer.Show_Customer_Person(m_ShopABC.m_CurrentDoc);
                    xdelegate_Customer_Person_Changed(Customer_Person_ID);
                }
                else
                {
                    transaction_Customer_Person_Changed.Rollback();
                }
            }
            else
            {
                transaction_Customer_Person_Changed.Rollback();
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
                if (DocM.IsDocInvoice)
                {
                    if (m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v != null)
                    {
                        bstorno = m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v.v;
                    }
                }

                if (chk_Storno_Checked != bstorno)
                {
                    if (chk_Storno_Checked)
                    {
                        if (MessageBox.Show(pform, lng.s_Invoice.s + ": " + stxt_Number + "\r\n" + lng.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Form_Storno frm_storno_dlg = new Form_Storno(m_ShopABC.m_CurrentDoc.Doc_ID);

                            if (frm_storno_dlg.ShowDialog() == DialogResult.Yes)
                            {
                                stornoReferenceInvoiceNumber = m_ShopABC.m_CurrentDoc.NumberInFinancialYear.ToString();
                                stornoReferenceInvoiceIssueDateTime = frm_storno_dlg.m_InvoiceTime;
                                string sInvoiceToStorno = frm_storno_dlg.m_sInvoiceToStorno;
                                if (MessageBox.Show(pform, sInvoiceToStorno + "\r\n" + lng.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {

                                    ID Storno_DocInvoice_ID = null;
                                    DateTime stornoInvoiceIssueDateTime = new DateTime();
                                    Transaction transaction_Storno = DBSync.DBSync.NewTransaction("Storno");
                                    if (m_ShopABC.m_CurrentDoc.Storno(m_LMOUser.Atom_WorkPeriod_ID,
                                                                      ref Storno_DocInvoice_ID,
                                                                      true,
                                                                      GlobalData.ElectronicDevice_Name,
                                                                      frm_storno_dlg.m_Reason,
                                                                      ref stornoInvoiceIssueDateTime,
                                                                      transaction_Storno))
                                    {
                                        if (TSettings.b_FVI_SLO)
                                        {
                                            InvoiceData.AddOnDI.b_FVI_SLO = TSettings.b_FVI_SLO;
                                            InvoiceData xInvoiceData = new InvoiceData(m_ShopABC, Storno_DocInvoice_ID, GlobalData.ElectronicDevice_Name);
                                            if (xInvoiceData.Read_DocInvoice(transaction)) // read Proforma Invoice again from DataBase
                                            {

                                                string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(true,
                                                                                                              TangentaResources.Properties.Resources.FVI_SLO_Invoice,
                                                                                                              TSettings.FVI_SLO1.FursD_MyOrgTaxID,
                                                                                                              TSettings.FVI_SLO1.FursD_BussinesPremiseID,
                                                                                                              GlobalData.ElectronicDevice_Name,
                                                                                                              TSettings.FVI_SLO1.FursD_InvoiceAuthorTaxID,
                                                                                                              stornoReferenceInvoiceNumber,
                                                                                                              stornoReferenceInvoiceIssueDateTime,
                                                                                                              xInvoiceData.IssueDate_v,
                                                                                                              xInvoiceData.NumberInFinancialYear,
                                                                                                              xInvoiceData.GrossSum,
                                                                                                              xInvoiceData.taxSum,
                                                                                                              xInvoiceData.Invoice_Author
                                                                                                              );
                                                string furs_UniqeMsgID = null;
                                                string furs_UniqeInvID = null;
                                                string furs_BarCodeValue = null;
                                                Image img_QR = null;
                                                if (TSettings.FVI_SLO1.Send_SingleInvoice(false, furs_XML, pform, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                                                {
                                                    xInvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                                                    xInvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                                                    xInvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                                                    if (xInvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(xInvoiceData.DocInvoice_ID, TSettings.FVI_SLO1.FursTESTEnvironment,transaction_Storno))
                                                    {

                                                    }
                                                }
                                                else
                                                {
                                                    string xSerialNumber = null;
                                                    string xSetNumber = null;
                                                    string xInvoiceNumber = null;
                                                    TSettings.FVI_SLO1.Write_SalesBookInvoice(xInvoiceData.DocInvoice_ID, xInvoiceData.FinancialYear, xInvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                                                    ID FVI_SLO_SalesBookInvoice_ID = null;
                                                    if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(xInvoiceData.DocInvoice_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID, transaction))
                                                    {
                                                        MessageBox.Show("Storno računa je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");
                                                    }
                                                    else
                                                    {
                                                        transaction_Storno.Rollback();
                                                        return false;
                                                    }
                                                }
                                            }
                                        }
                                        if (transaction_Storno.Commit())
                                        {
                                            xdelegate_Storno(true);
                                        }
                                        else
                                        {
                                            xdelegate_Storno(false);
                                        }
                                    }
                                    else
                                    {
                                        transaction_Storno.Rollback();
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(pform, lng.s_YouCanNotCancelInvoiceStorno.s);
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
            if (m_ShopABC.m_CurrentDoc.Update_Customer_Org(DocTyp, Customer_Org_ID, ref Atom_Customer_Org_ID, transaction_Customer_Org_Changed))
            {
                m_ShopABC.m_CurrentDoc.Atom_Customer_Org_ID = Atom_Customer_Org_ID;
                if (ID.Validate(Atom_Customer_Org_ID))
                {
                    if (!transaction_Customer_Org_Changed.Commit())
                    {
                        return;
                    }
                    xdelegate_control_usrc_Customer_Show_Customer_Organisation(m_ShopABC.m_CurrentDoc);
                    //usrc_Customer.Show_Customer_Org(m_ShopABC.m_CurrentDoc);
                    xdelegate_Customer_Org_Changed(Customer_Org_ID);
                }
                else
                {
                    transaction_Customer_Org_Changed.Rollback();
                }
            }
            else
            {
                transaction_Customer_Org_Changed.Rollback();
            }
        }
    }
}
