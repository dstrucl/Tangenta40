#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion


using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TangentaTableClass;
using CodeTables;
using LanguageControl;
using DBTypes;
using TangentaDB;
using ShopA;
using ShopB;
using ShopC;
using System.Drawing;
using System.Linq;
using Startup;
using DBConnectionControl40;
using LoginControl;

namespace Tangenta
{
    public partial class usrc_DocumentEditor1366x768 : UserControl
    {
        SettingsUserValues mSettingsUserValues = null;
        public ID Atom_Currency_ID = null;
        private LoginControl.LMOUser m_LMOUser = null;
        private Door door = null;
        public usrc_ShopA m_usrc_ShopA = null;
        public usrc_ShopB m_usrc_ShopB = null;
        public usrc_ShopC m_usrc_ShopC = null;

        public string ShopsMode = "";
        private usrc_DocumentMan1366x768 m_usrc_DocumentMan = null;
        private NavigationButtons.Navigation nav = null;


        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

       

        private string m_DocTyp = null;

        public string DocTyp
        {
            get {
                    if (m_DocTyp==null)
                    {
                        //LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property DocTyp: DocTyp is not defined (m_DocInvoice = null)!");
                    }
                    return m_DocTyp;
                }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    m_DocTyp = s;
                    this.usrc_Customer.DocTyp = m_DocTyp;
                }
                else
                {
                    if (s != null)
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property string DocTyp: DocTyp = " + s + " is not implemented!");
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property string DocTyp: DocTyp  value ==  null");
                    }

                }

                if (this.m_ShopABC != null)
                {
                    this.m_ShopABC.DocTyp = DocTyp;
                }
                if (this.m_usrc_ShopB!= null)
                {
                    this.m_usrc_ShopB.DocTyp = DocTyp;
                }
                if (this.m_usrc_ShopC != null)
                {
                    this.m_usrc_ShopC.DocTyp = DocTyp;
                }
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

        public enum emode
        {
            view_eDocumentType,
            edit_eDocumentType
        }

        public delegate void delegate_Storno(bool bStorno);
        public event delegate_Storno Storno = null;

        public delegate void delegate_DocInvoiceSaved(ID DocInvoice_id);
        public event delegate_DocInvoiceSaved aa_DocInvoiceSaved;

        public delegate void delegate_DocProformaInvoiceSaved(ID DocProformaInvoice_id);
        public event delegate_DocProformaInvoiceSaved aa_DocProformaInvoiceSaved;

        public delegate void delegate_Customer_Person_Changed(ID Customer_Person_ID);
        public event delegate_Customer_Person_Changed aa_Customer_Person_Changed = null;

        public delegate void delegate_Customer_Org_Changed(ID Customer_Org_ID);
        public event delegate_Customer_Org_Changed aa_Customer_Org_Changed = null;



        public emode m_mode = emode.view_eDocumentType;

        public DBTablesAndColumnNames DBtcn = null;

        public TangentaDB.ShopABC m_ShopABC = null;


        public InvoiceData m_InvoiceData = null;

        public ID myOrganisation_Person_id
        {
            get
            {
                if (myOrg.m_myOrg_Office!=null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Person.ID;
                    }
                }
                return null;
            }
        }




        internal decimal GrossSum = 0;
        private decimal NetSum = 0;
        private StaticLib.TaxSum TaxSum = null;


        private bool chk_Storno_CanBe_ManualyChanged = true;

        public int NumberOfShopBGroupLevels
        {
            get
            {
                if (this.m_usrc_ShopB != null)
                {
                    return m_usrc_ShopB.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int NumberOfShopCGroupLevels
        {
            get
            {
                if (this.m_usrc_ShopC != null)
                {
                    return m_usrc_ShopC.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
        }


        public List<Employee> Employees = new List<Employee>();

        private void New_ShopA()
        {
            if (m_usrc_ShopA==null)
            {
                m_usrc_ShopA = new usrc_ShopA();
            }
            m_usrc_ShopA.Init(this.m_ShopABC, DBtcn);
            m_usrc_ShopA.Dock = DockStyle.Fill;
            m_usrc_ShopA.aa_ItemAdded += M_usrc_ShopA_aa_ItemAdded;
            m_usrc_ShopA.aa_ItemRemoved += M_usrc_ShopA_aa_ItemRemoved;
            m_usrc_ShopA.EditUnits += M_usrc_ShopA_EditUnits;

        }

        private bool M_usrc_ShopA_EditUnits()
        {
            SQLTable tbl_Unit = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Unit)));
            Form_Unit_Edit unit_dlg = new Form_Unit_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Unit, "ID asc",nav);
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                GetUnits();
                return true;

            }
            return false;
        }

        private void M_usrc_ShopA_aa_ItemRemoved(ID ID, DataTable dt)
        {
            GetPriceSum();
        }

        private void M_usrc_ShopA_aa_ItemAdded(ID ID, DataTable dt)
        {
            GetPriceSum();
        }


        private void New_ShopC()
        {
            if (m_usrc_ShopC == null)
            {
                m_usrc_ShopC = new usrc_ShopC();
                m_usrc_ShopC.DocTyp = this.DocTyp;
                m_usrc_ShopC.CheckAccessPriceList += M_usrcCheckPriceListAccess;
                m_usrc_ShopC.CheckAccessStock += M_usrc_ShopC_CheckAccessStock;
                m_usrc_ShopC.CheckIfAdministrator += M_usrc_ShopC_CheckIfAdministrator;
            }
            m_usrc_ShopC.Init(m_LMOUser.Atom_WorkPeriod_ID,this.m_ShopABC, DBtcn,Program.Shops_in_use,Properties.Settings.Default.AutomaticSelectionOfItemFromStock,Program.OperationMode.ShopC_ExclusivelySellFromStock);
            m_usrc_ShopC.Dock = DockStyle.Fill;
            m_usrc_ShopC.ItemAdded += usrc_ShopC_ItemAdded;
            m_usrc_ShopC.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
        }

        private bool M_usrc_ShopC_CheckIfAdministrator()
        {
            return m_LMOUser.IsAdministrator;
        }

        private bool M_usrc_ShopC_CheckAccessStock()
        {
            return door.OpenStockEdit(Global.f.GetParentForm(this));
        }

        private bool M_usrcCheckPriceListAccess()
        {
            return door.OpenPriceList(Global.f.GetParentForm(this));
        }

        private void Set_eShopsMode_A()
        {
            ShopsMode = "A";
        }

        private void Set_eShopsMode_B()
        {
            ShopsMode = "B";
        }

        private void Set_eShopsMode_C()
        {
            ShopsMode = "C";
        }


        private void Set_eShopsMode_AB()
        {
            ShopsMode = "AB";
        }


        private void Set_eShopsMode_BC()
        {
            ShopsMode = "BC";
        }

        private void Set_eShopsMode_AC()
        {
            ShopsMode = "AC";
        }

        private void Set_eShopsMode_ABC()
        {
            ShopsMode = "ABC";
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            mSettingsUserValues.eShopsInUse = xshops_inuse;
            this.Set_eShopsMode(xshops_inuse);
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
            this.Refresh();
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            chk_Head.Checked = bvisible;
            this.Refresh();
            this.Refresh();
        }

        private void New_ShopB()

        {

            if (m_usrc_ShopB == null)

            {

                m_usrc_ShopB = new usrc_ShopB();

                m_usrc_ShopB.DocTyp = this.DocTyp;

                m_usrc_ShopB.CheckAccessPriceList += M_usrcCheckPriceListAccess;

            }

            m_usrc_ShopB.Init(this.m_ShopABC, DBtcn, Program.Shops_in_use);

            m_usrc_ShopB.Dock = DockStyle.Fill;

            m_usrc_ShopB.aa_ExtraDiscount += usrc_ShopB_ExtraDiscount;

            m_usrc_ShopB.aa_ItemAdded += usrc_ShopB_ItemAdded;

            m_usrc_ShopB.aa_ItemRemoved += usrc_ShopB_ItemRemoved;

            m_usrc_ShopB.aa_ItemUpdated += usrc_ShopB_ItemUpdated;

        }


        internal void Set_eShopsMode(string eShopsMode)
        {
            if (mSettingsUserValues.eShopsInUse.Length == 1)
            {
                eShopsMode = mSettingsUserValues.eShopsInUse;
 //               this.btn_Show_Shops.Visible = false;
            }
            else
            {
                this.btn_Show_Shops.Visible = true;
            }

            if (mSettingsUserValues.eShopsInUse.Length == 2)
            {
                if (!mSettingsUserValues.eShopsInUse.Contains(eShopsMode))
                {
                    eShopsMode = mSettingsUserValues.eShopsInUse;
                }
            }


            if (m_usrc_ShopA==null)
            {
                New_ShopA();
            }

            if (m_usrc_ShopB == null)
            {
                New_ShopB();
            }
            
            if (m_usrc_ShopC == null)
            {
                New_ShopC();
            }

            if (eShopsMode.Equals("A"))
            {
                Set_eShopsMode_A();
            }
            else if (eShopsMode.Equals("B"))
            {
                Set_eShopsMode_B();
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsMode.Equals("C"))
            {
                Set_eShopsMode_C();
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsMode.Equals("AB"))
            {
                Set_eShopsMode_AB();
            }
            else if (eShopsMode.Equals("BC"))
            {
                Set_eShopsMode_BC();
            }
            else if (eShopsMode.Equals("AC"))
            {
                Set_eShopsMode_AC();
            }
            else if (eShopsMode.Equals("ABC"))
            {
                Set_eShopsMode_ABC();
            }
        }

        public enum enum_GetOrganisation_Person_Data { MyOrganisation_Data_OK,
            No_MyOrganisation_Tax_ID,
            No_MyOrganisation_name,
            No_MyOrganisation_StreetName,
            No_MyOrganisation_HouseNumber,
            No_MyOrganisation_ZIP,
            No_MyOrganisation_City,
            No_MyOrganisation_Country,
            No_MyOrganisation_State,
            No_MyOrganisationData,
            No_MyOrganisation_Person_FirstName,
            No_MyOrganisation_Person,
            Error_Load_MyOrganisation_data

        };

        private bool EventsActive;

        public ID PriceList_ShopB_ID
        {
            get
            {
                if (m_usrc_ShopB != null)
                {
                    return m_usrc_ShopB.usrc_PriceList1.ID;
                }
                else
                {
                    if (this.DesignMode)
                    {
                        return null;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                        return null;
                    }
                }
            }
        }


        public ID PriceList_ShopC_ID
        {
            get
            {
                if (m_usrc_ShopC != null)
                {
                    return m_usrc_ShopC.usrc_PriceList1.ID;
                }
                else
                {
                    if (this.DesignMode)
                    {
                        return null;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                        return null;
                    }
                }
            }
        }

        public bool ShopA_DefaultVisible
        {
            get { return mSettingsUserValues.eShopsMode.Contains("A"); }
        }
        public bool ShopB_DefaultVisible
        {
            get { return mSettingsUserValues.eShopsMode.Contains("B"); }
        }

        public bool ShopC_DefaultVisible
        {
            get { return mSettingsUserValues.eShopsMode.Contains("Ç"); }
        }

        public bool HeadVisible
        {
            get {
                 return this.chk_Head.Checked;
                }
        }

        public usrc_DocumentEditor1366x768()
        {
            InitializeComponent();
            usrc_AddOn1.Init(this);
            m_mode = emode.view_eDocumentType;
            lng.s_Show_Shops.Text(btn_Show_Shops);
            lng.s_Issuer.Text(lbl_MyOrganisation);
            lng.s_Number.Text(lbl_Number);
            //btn_BuyerSelect.Text = lng.s_BuyerSelect.s;
            lng.s_Issue.Text(btn_Issue);
            lng.s_chk_Storno.Text(chk_Storno);

            lng.s_Shop_AB = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1));
            lng.s_Shop_BC = new ltext(lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_AC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_C.sText(1));
            lng.s_Shop_ABC = new ltext(lng.s_Shop_A.sText(0) + " && " + lng.s_Shop_B.sText(0) + " && " + lng.s_Shop_C.sText(0), lng.s_Shop_A.sText(1) + " && " + lng.s_Shop_B.sText(1) + " && " + lng.s_Shop_C.sText(1));

            lng.s_MyOrganisation.Text(lbl_MyOrganisation);
            lng.s_Total.Text(this.lbl_Sum);

        }

        internal void SetMode(emode mode)
        {
            m_mode = mode;
            if (mode == emode.edit_eDocumentType)
            {
                this.m_usrc_ShopA.SetMode(usrc_ShopA.eMode.EDIT);
                this.m_usrc_ShopB.SetMode(usrc_ShopB.eMode.EDIT);
                this.m_usrc_ShopC.SetMode(usrc_ShopC.eMode.EDIT);
            }
            else
            {
                this.m_usrc_ShopA.SetMode(usrc_ShopA.eMode.VIEW);
                this.m_usrc_ShopB.SetMode(usrc_ShopB.eMode.VIEW);
                this.m_usrc_ShopC.SetMode(usrc_ShopC.eMode.VIEW);
            }

            if (mode == emode.view_eDocumentType)
            {
                chk_Storno.Visible = true;
                lng.s_Print.Text(btn_Issue);
            }
            else
            {
                lng.s_Issue.Text(btn_Issue);
                chk_Storno.Visible = false;
            }

        }

        public void EnableControls(bool b)
        {
            //this.splitContainer1.Enabled = b;
        }

      
        private bool EditMyOrganisation_Data(bool bAllowNew,NavigationButtons.Navigation xnav)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Edit edt_my_company_dlg = new Form_myOrg_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation))), bAllowNew,xnav,null);
            this.Cursor = Cursors.Arrow;
            xnav.ChildDialog = edt_my_company_dlg;
            xnav.ShowDialog();
            if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK)|| (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Initialise(usrc_DocumentMan1366x768 xusrc_DocumentMan1366x768, LoginControl.LMOUser xLMOUser)
        {
            this.mSettingsUserValues = ((SettingsUser)xLMOUser.oSettings).mSettingsUserValues;
            m_usrc_DocumentMan = xusrc_DocumentMan1366x768;
            m_LMOUser = xLMOUser;
            door = new Door(m_LMOUser);
            lng.s_Head.Text(chk_Head);
            chk_Head.Checked = mSettingsUserValues.InvoiceHeaderChecked;
            chk_Head.CheckedChanged += chk_Head_CheckedChanged;
            //splitContainer2.Panel1Collapsed = !chk_Head.Checked;
            SetOperationMode();
            return true;
        }

        private void SetOperationMode()
        {
            if (Program.OperationMode.MultiUser)
            {
                txt_Issuer.Visible = false;
                lbl_Issuer.Visible = false;
            }
            else 
            {
                txt_Issuer.Visible = true;
                lbl_Issuer.Visible = true;
            }

        }

        public bool Init(ID Document_ID)
        {
            if (DBtcn == null)
            {
                DBtcn = new DBTablesAndColumnNames();
            }
            if (m_ShopABC == null)
            {
                m_ShopABC = new ShopABC(DocTyp,DBtcn,m_LMOUser.Atom_WorkPeriod_ID);
            }
            if (m_InvoiceData == null)
            {
                m_InvoiceData = new InvoiceData(m_ShopABC, Document_ID, GlobalData.ElectronicDevice_Name);
            }
            else
            {
                m_InvoiceData.DocInvoice_ID = Document_ID;
            }

            if (mSettingsUserValues.eShopsMode.Length==0)
            {
                mSettingsUserValues.eShopsMode = Properties.Settings.Default.eShopsInUse;
            }
            Set_eShopsMode(mSettingsUserValues.eShopsMode);
            GetUnits();

            DataTable dt_ShopB_Item_NotIn_PriceList = new DataTable();
            if (GetPriceList_ShopB())
            {
                if (f_PriceList.Check_All_ShopB_Items_In_PriceList(ref dt_ShopB_Item_NotIn_PriceList))
                {
                    if (dt_ShopB_Item_NotIn_PriceList.Rows.Count > 0)
                    {
                        if (PriseLists.usrc_PriceList.Ask_To_Update('B', dt_ShopB_Item_NotIn_PriceList, this))
                        {
                            if (f_PriceList.Insert_ShopB_Items_in_PriceList(dt_ShopB_Item_NotIn_PriceList, this))
                            {
                                bool bPriceListChanged = false;
                                this.m_usrc_ShopB.usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                            }
                        }
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

                int iCount_Price_SimpleItem_Data = 0;
                if (Get_Price_SimpleItem_Data(ref iCount_Price_SimpleItem_Data, this.m_usrc_ShopB.usrc_PriceList1.ID))
                {
                    this.m_usrc_ShopB.Set_dgv_SelectedShopB_Items();
                }
            }
            else
            {
                return false;
            }

            if (Program.Shops_in_use.Contains("C"))
            {
                if (GetPriceList_ShopC())
                {
                    DataTable dt_ShopC_Item_NotIn_PriceList = new DataTable();
                    if (f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Item_NotIn_PriceList))
                    {
                        if (dt_ShopC_Item_NotIn_PriceList.Rows.Count > 0)
                        {
                            if (PriseLists.usrc_PriceList.Ask_To_Update('C', dt_ShopC_Item_NotIn_PriceList, this))
                            {
                                if (f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Item_NotIn_PriceList, this))
                                {
                                    bool bPriceListChanged = false;
                                    this.m_usrc_ShopC.usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                                }
                            }
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

                    if (this.m_usrc_ShopC.usrc_ItemList.Get_Price_Item_Stock_Data(this.m_usrc_ShopC.usrc_PriceList1.ID))
                    {
                        if (Program.bStartup)
                        {
                            Program.bStartup = false;

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
                                        Form_Expiry_Check frm_exp_chk = new Form_Expiry_Check(dt_ExpiryCheck, this, sNoExpiryDate, sNoSaleBeforeExpiryDate, sNoDiscardBeforeExpiryDate);
                                        frm_exp_chk.ShowDialog();
                                    }
                                    return DoCurrent(Document_ID);
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
                            return DoCurrent(Document_ID); 
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
            return DoCurrent(Document_ID);
        }

        internal void SetColor()
        {
            this.BackColor = Colors.m_usrc_DocumentEditor.BackColor;
            this.ForeColor = Colors.m_usrc_DocumentEditor.ForeColor;
            //this.splitContainer2.Panel1.BackColor = Colors.HeadColor.BackColor;
            //this.splitContainer2.Panel1.ForeColor = Colors.HeadColor.ForeColor;

            if (m_usrc_ShopA!=null)
            {
                m_usrc_ShopA.SetColor();
            }
            if (m_usrc_ShopB != null)
            {
                m_usrc_ShopB.SetColor();
            }
            if (m_usrc_ShopC != null)
            {
                m_usrc_ShopC.SetColor();
            }
        }

        public bool DoCurrent(ID xID)
        {
            if (DoGetCurrent(xID))
            {
                if (m_ShopABC.m_CurrentDoc.ShowDraftButtons())
                {
                    this.m_usrc_ShopB.SetDraftButtons();
                }
                else
                {
                    this.m_usrc_ShopB.SetViewButtons();
                }
                this.usrc_Customer.Show_Customer(m_ShopABC.m_CurrentDoc);
                this.usrc_AddOn1.Show(xID);
                return true;
            }
            else
            {
                usrc_Customer.Text = "";
                this.usrc_AddOn1.Show(null);
                return false;
            }
        }

        private void chk_Head_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Head.Checked)
            {
                //splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                //splitContainer2.Panel1Collapsed = true;
            }

            ((SettingsUser)m_LMOUser.oSettings).mSettingsUserValues.InvoiceHeaderChecked = chk_Head.Checked;
            Properties.Settings.Default.Save();
        }

        private bool DoGetCurrent(ID xID)
        {
            if (GetCurrent(xID))
            {
                GetPriceSum();
                if (m_ShopABC.m_CurrentDoc.bDraft)
                {
                    AddHandler();
                }
                else
                {
                    if (m_ShopABC.m_CurrentDoc.Exist)
                    {
                        RemoveHandler();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddHandler()
        {
            if (!EventsActive)
            {
                EventsActive = true;
                if (this.m_usrc_ShopB!=null)
                {
                    this.m_usrc_ShopB.aa_ItemAdded += new usrc_ShopB.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB.aa_ItemRemoved += new usrc_ShopB.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB.aa_ItemUpdated += new usrc_ShopB.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB.aa_ExtraDiscount += new usrc_ShopB.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }

        private void RemoveHandler()
        {
            if (EventsActive)
            {
                EventsActive = false;
                if (m_usrc_ShopB != null)
                {
                    this.m_usrc_ShopB.aa_ItemAdded -= new usrc_ShopB.delegate_ItemAdded(usrc_ShopB_ItemAdded);
                    this.m_usrc_ShopB.aa_ItemRemoved -= new usrc_ShopB.delegate_ItemRemoved(usrc_ShopB_ItemRemoved);
                    this.m_usrc_ShopB.aa_ItemUpdated -= new usrc_ShopB.delegate_ItemUpdated(usrc_ShopB_ItemUpdated);
                    this.m_usrc_ShopB.aa_ExtraDiscount -= new usrc_ShopB.delegate_ExtraDiscount(usrc_ShopB_ExtraDiscount);
                }
            }
        }



        private bool GetUnits()
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


        private bool GetPriceList_ShopB()
        {
            string Err = null;
            bool bGet = true;
            NavigationButtons.Navigation nav_PriceList = new NavigationButtons.Navigation(null);
            nav_PriceList.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            if (m_usrc_ShopB.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopB,Program.Shops_in_use,  ref Err))
            {

            }
            else
            {
                bGet = false;
            }
            return bGet;
        }

        private bool GetPriceList_ShopC()
        {
            string Err = null;
            bool bGet = true;
            NavigationButtons.Navigation nav_PriceList = new NavigationButtons.Navigation(null);
            nav_PriceList.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            if (m_usrc_ShopC.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopC, Program.Shops_in_use,  ref Err))
            {

            }
            else
            {
                bGet = false;
            }
            return bGet;
        }

        public bool Get_ShopB_ItemData(startup myStartup,object oData, NavigationButtons.Navigation xnav,ref string Err)
        {
            if (Program.Shops_in_use.Contains("B"))
            {
                if (myStartup.bInsertSampleData)
                {
                    if (!TangentaSampleDB.TangentaSampleDB.sbd.Write_ShopB_Items(xnav))
                    {
                        //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                        return false;
                    }
                    else if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        //myStartup.eNextStep--;
                        return true;
                    }
                    else if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
                    {
                        //myStartup.eNextStep = startup_step.eStep.Cancel;
                        return true;
                    }
                }
                if (this.m_usrc_ShopB == null)
                {
                    Set_eShopsMode(Program.Shops_in_use);
                }
            }

            int iCountSimpleItemData = -1;

            if (GetSimpleItemData(ref iCountSimpleItemData))
            {
                //myStartup.eNextStep++;
                return true;
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        private bool GetSimpleItemData(ref int iCountSimpleItemData)
        {
            if (this.m_usrc_ShopB.GetShopBItemData(ref iCountSimpleItemData))
            {
                if (iCountSimpleItemData > 0)
                {
                    return true;
                }
                else
                {
                    if (Program.Shops_in_use.Contains("B"))
                    {
                        //if (MessageBox.Show(this, lng.s_NoSimpleItemData_EnterSimpleItemDataQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        //{
                            this.m_usrc_ShopB.EditShopBItem();
                            if (this.m_usrc_ShopB.GetShopBItemData(ref iCountSimpleItemData))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        //}
                        //else
                        //{
                        //    return true;
                        //}
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

        internal bool Get_Price_SimpleItem_Data(ref int iCount_Price_SimpleItem_Data, ID PriceList_id)
        {
            if (this.m_usrc_ShopB.Get_Price_ShopBItem_Data(ref iCount_Price_SimpleItem_Data, PriceList_id))
            {
                if (iCount_Price_SimpleItem_Data > 0)
                {
                    return true;
                }
                else
                {
                    if (Program.Shops_in_use.Contains("B"))
                    {
                        string smsg = lng.s_No_ShopB_Items_or_no_prices_for_those_items.s.Replace("%s",lng.s_Shop_B.s);
                        MessageBox.Show(this, smsg);
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

        private bool GetItemData(ref int iCountItemData,NavigationButtons.Navigation xnav)
        {
            if (this.m_usrc_ShopC.GetItemData(ref iCountItemData))
            {
                if (iCountItemData > 0)
                {
                    return true;
                }
                else
                {
                    if (Program.Shops_in_use.Contains("C"))
                    {
                        this.m_usrc_ShopC.EditItem(xnav);
                        if (this.m_usrc_ShopC.GetItemData(ref iCountItemData))
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
            }
            else
            {
                return false;
            }
        }

        private bool GetCurrent(ID xID)
        {
            if (DocTyp != null)
            {
                if (DocTyp.Equals(GlobalData.const_DocInvoice) || DocTyp.Equals(GlobalData.const_DocProformaInvoice))
                {
                    return GetCurrentInvoice(xID);
                }
                else
                {
                    LogFile.Error.Show("Tangenta:usrc_DocumentEditor:GetCurrent(ID xID):DocType=" + DocTyp+ " is not implemented!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("Tangenta:usrc_DocumentEditor:GetCurrent(ID xID):DocType is null !");
                return false;
            }

        }


        private bool GetCurrentInvoice(ID DocInvoice_ID)
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
                          ref Err)) // try to get draft
        {
                this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.m_CurrentDoc.bDraft, m_ShopABC.m_CurrentDoc.FinancialYear, m_ShopABC.m_CurrentDoc.NumberInFinancialYear, m_ShopABC.m_CurrentDoc.DraftNumber);
                if (m_ShopABC.m_CurrentDoc.bDraft)
                {
                    SetMode(emode.edit_eDocumentType);
                    this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                }
                else
                {
                    SetMode(emode.view_eDocumentType);
                    this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    chk_Storno_CanBe_ManualyChanged = false;
                    if (IsDocInvoice)
                    {
                        this.chk_Storno.Visible = true;
                        if (m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v != null)
                        {
                            this.chk_Storno.Checked = m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v.v;
                        }
                        else
                        {
                            this.chk_Storno.Checked = false;
                        }
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                    else
                    {
                        this.chk_Storno.Visible = false;
                    }
                }
                this.m_usrc_ShopC.Reset();
                return true;
            }
            else
            {
                SetMode(emode.view_eDocumentType);
                string sxAtom_myOrganisation_Person_Tax_ID = m_LMOUser.Atom_myOrganisation_Person_Tax_ID;
                if (m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator,AWP.ROLE_UserManagement }))
                {
                    sxAtom_myOrganisation_Person_Tax_ID = null;
                }

                if (m_ShopABC.Get(false, 
                                  DocInvoice_ID,
                                  sxAtom_myOrganisation_Person_Tax_ID,
                                  m_LMOUser.Atom_ElectronicDevice_Atom_Office_ShortName,
                                  m_LMOUser.Atom_ElectronicDevice_Name,
                                  ref Err)) // Get invoice with Invoice_ID
                {
                    this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.m_CurrentDoc.bDraft, m_ShopABC.m_CurrentDoc.FinancialYear, m_ShopABC.m_CurrentDoc.NumberInFinancialYear, m_ShopABC.m_CurrentDoc.DraftNumber);
                    this.m_usrc_ShopC.Clear();
                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    this.m_usrc_ShopC.Reset();
                    return true;
                }
                else
                {
                    this.m_usrc_ShopC.Reset();
                    return false;
                }
            }
        }

        private bool DoSelectBaseCurrency(startup myStartup,NavigationButtons.Navigation xnav, ref string Err)
        {
            if (Select_BaseCurrency(xnav, ref Err))
            {
                if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                {
                    myStartup.sbd.DeleteAll();
                    //myStartup.eNextStep = startup_step.eStep.CheckDBVersion;
                }
                else if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)
                {
                    //myStartup.eNextStep++;
                }
                else if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
                {
                    //myStartup.eNextStep = startup_step.eStep.Cancel;
                }
                return true;
            }
            else
            {
                //myStartup.eNextStep = startup_step.eStep.Cancel;
                return false;
            }

        }

        public  bool Get_BaseCurrency(startup myStartup,object oData,NavigationButtons.Navigation xnav, ref string Err)
        {
            string BaseCurrency_Text = null;
            if (xnav.LastStartupDialog_TYPE.Equals("Tangenta.Form_ShopsInUse"))
            {
                return DoSelectBaseCurrency(myStartup, xnav, ref Err);
            }
            else
            {
                if (GlobalData.Get_BaseCurrency(ref BaseCurrency_Text, ref Err))
                {
                    if (BaseCurrency_Text != null)
                    {
                        return true;
                    }
                    else
                    {
                        return DoSelectBaseCurrency(myStartup, xnav, ref Err);
                    }
                }
                return false;
            }
        }


        private bool Select_BaseCurrency(NavigationButtons.Navigation xnav,ref string Err)
        {
            if (GlobalData.BaseCurrency == null)
            {
                GlobalData.BaseCurrency = new xCurrency();
            }
            ID DefaultCurrency_ID = myOrg.Default_Currency_ID;
            Form_Select_DefaultCurrency sel_basecurrency_dlg = new Form_Select_DefaultCurrency(DefaultCurrency_ID,ref GlobalData.BaseCurrency,xnav);
            xnav.ChildDialog = sel_basecurrency_dlg;
            xnav.ShowDialog();
            if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
            {
                return true;
            }
            if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)||(xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
            {
                if (GlobalData.InsertIntoBaseCurrency(sel_basecurrency_dlg.Currency_ID, ref Err))
                {
                    return true;
                }
                else
                {
                    Err = "ERROR:usrc_Invoice:Select_BaseCurrency:InsertIntoBaseCurrency:Err=" + Err;
                    return false;
                }


            }
            else
            {
                Err = "ERROR: Default Currency is not selected!";
                return false;
            }

        }


        internal void Fill_MyOrganisation_Person()
        {
            if (ID.Validate(myOrg.ID))
            {
                DataTable dtEmployees = new DataTable();
                string sql_my_company_person = @"Select ID,
                                            myOrganisation_Person_$_office_$_mo_$$ID,
                                            myOrganisation_Person_$_per_$_cfn_$$FirstName,
                                            myOrganisation_Person_$_per_$_cln_$$LastName,
                                            myOrganisation_Person_$$Job,
                                            myOrganisation_Person_$$Description,
                                            myOrganisation_Person_$$Active
                                            from myOrganisation_Person_VIEW
                                            where myOrganisation_Person_$_office_$_mo_$$ID = " + myOrg.ID.ToString()
                                                  + " and myOrganisation_Person_$$Active = 1";
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dtEmployees, sql_my_company_person, ref Err))
                {
                    if (dtEmployees.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtEmployees.Rows)
                        {
                            Employee employee = new Employee((string)dr["myOrganisation_Person_$_per_$_cfn_$$FirstName"],
                                                                dr["myOrganisation_Person_$_per_$_cln_$$LastName"],
                                                                dr["myOrganisation_Person_$$Job"],
                                                                dr["myOrganisation_Person_$$Description"],
                                                              (bool)dr["myOrganisation_Person_$$Active"],
                                                              (long)dr["ID"],
                                                              (long)dr["myOrganisation_Person_$_office_$_mo_$$ID"]
                                                              );
                            Employees.Add(employee);
                        }

                        string suser = "??";
                        if (myOrg.m_myOrg_Office!=null)
                        {
                            if (myOrg.m_myOrg_Office.m_myOrg_Person!=null)
                            {
                                if (myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v!=null)
                                {
                                    suser = myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v.v;
                                }
                                if (myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v != null)
                                {
                                    suser += " " +myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v.v;
                                }

                            }
                        }
                        this.txt_Issuer.Text = suser;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:Fill_MyOrganisation_Person:Err=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:Fill_MyOrganisation_Person:myOrg.ID is not defined!");
            }
        }

        public void SetNewDraft(LMOUser xLMOUser, string DocTyp, int xFinancialYear,xCurrency xcurrency, ID Atom_Currency_ID, WArea workArea)
        {
            if (DocTyp.Equals(GlobalData.const_DocInvoice)|| DocTyp.Equals(GlobalData.const_DocProformaInvoice))
            {
                    if (m_ShopABC == null)
                    {
                    m_ShopABC = new ShopABC(this.DocTyp, DBtcn, m_LMOUser.Atom_WorkPeriod_ID);
                    }
                    if (SetNewInvoiceDraft(xLMOUser,xFinancialYear, xcurrency, Atom_Currency_ID, workArea))
                    {
                        SetMode(emode.edit_eDocumentType);
                    }
                    return;
            }
            return;

        }

        private bool SetNewInvoiceDraft(LMOUser xLMOUser,  int FinancialYear, xCurrency xcurrency, ID xAtom_Currency_ID, WArea workArea)
        {
            ID DocInvoice_ID = null;
            string Err = null;
            if (Program.OperationMode.MultiUser)
            {
                myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(xLMOUser.myOrganisation_Person_ID);
            }

            if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
            {
                LogFile.Error.Show("ERROR:SetInvoiceDraft:Can not find my oragnisation person!");
                return false;
            }

            ID xAtom_WorkArea_ID = null;
            if (workArea != null)
            {
                if (!f_Atom_WorkArea.Get(workArea.Name, workArea.Description, ref xAtom_WorkArea_ID))
                {
                    return false;
                }
            }

            if (m_ShopABC.SetNewDraft_DocInvoice(m_LMOUser.Atom_WorkPeriod_ID, FinancialYear, xcurrency, xAtom_Currency_ID,this, ref DocInvoice_ID, myOrg.m_myOrg_Office.m_myOrg_Person.ID, xAtom_WorkArea_ID,this.DocTyp, GlobalData.ElectronicDevice_Name, ref Err))
            {
                if (ID.Validate(m_ShopABC.m_CurrentDoc.Doc_ID))
                {
                    this.txt_Number.Text = m_ShopABC.m_CurrentDoc.FinancialYear.ToString() + "/" + m_ShopABC.m_CurrentDoc.DraftNumber.ToString();
                    SetMode(emode.edit_eDocumentType);
                }

                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:SetInvoiceDraft:Err=" + Err);
                return false;
            }
        }

     

        public void GetPriceSum()
        {
            decimal dsum_GrossSum = 0;
            decimal dsum_TaxSum = 0;
            decimal dsum_NetSum = 0;


            TaxSum = null;
            TaxSum = new StaticLib.TaxSum();

            foreach (DataRow dr in this.m_usrc_ShopA.dt_Item_Price.Rows)
            {
                decimal price = (decimal)dr[DocTyp+"_ShopA_Item_$$EndPriceWithDiscountAndTax"];
                decimal tax = (decimal)dr[DocTyp + "_ShopA_Item_$$TAX"];
                decimal tax_rate = (decimal)dr[DocTyp + "_ShopA_Item_$_aisha_$_tax_$$Rate"];
                string tax_name = (string)dr[DocTyp + "_ShopA_Item_$_aisha_$_tax_$$Name"];
                dsum_GrossSum += price;
                TaxSum.Add(tax, 0, tax_name, tax_rate);
                dsum_NetSum += price - tax;
            }


            foreach (DataRow dr in this.m_usrc_ShopB.dt_SelectedShopBItem.Rows)
            {
                decimal price = (decimal)dr["SelectedSimpleItemPrice"];
                decimal tax = (decimal)dr["SelectedSimpleItemPriceTax"];
                decimal tax_rate = (decimal)dr["SelectedSimpleItem_TaxRate"];
                string tax_name = (string)dr["SelectedSimpleItem_TaxName"];
                dsum_GrossSum += price;
                TaxSum.Add(tax,0, tax_name, tax_rate);
                dsum_NetSum += price - tax;
            }

            decimal dsum_GrossSum_Basket = 0;
            decimal dsum_TaxSum_Basket = 0;
            decimal dsum_NetSum_Basket = 0;

            m_ShopABC.m_CurrentDoc.m_Basket.GetPriceSum(ref dsum_GrossSum_Basket, ref dsum_TaxSum_Basket, ref dsum_NetSum_Basket, ref TaxSum);

            dsum_GrossSum += dsum_GrossSum_Basket;
            dsum_TaxSum += dsum_TaxSum_Basket;
            dsum_NetSum += dsum_NetSum_Basket;

  
            if (dsum_GrossSum > 0)
            {
                btn_Issue.Visible = true;
            }
            else
            {
                btn_Issue.Visible = false;
            }
            GrossSum = dsum_GrossSum;
            NetSum = dsum_NetSum;
            string sGrossSum = "";
            if (IsDocInvoice)
            {
                if (m_ShopABC.m_CurrentDoc.TInvoice.StornoDocInvoice_ID == null)
                {
                    sGrossSum = dsum_GrossSum.ToString();
                    this.lbl_Sum.ForeColor = Color.Black;
                }
                else
                {
                    sGrossSum =  dsum_GrossSum.ToString();
                    decimal_v dGrossSum_v = tf.set_decimal(m_ShopABC.m_CurrentDoc.dtCurrent_Invoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$$GrossSum"]);
                    if (dGrossSum_v != null)
                    {
                        if (dGrossSum_v.v < 0)
                        {
                            sGrossSum = dGrossSum_v.v.ToString();
                        }
                    }
                    this.lbl_Sum.ForeColor = Color.Red;
                }
            }
            else if (IsDocProformaInvoice)
            {
                sGrossSum = dsum_GrossSum.ToString();
                this.lbl_Sum.ForeColor = Color.Black;
            }
            this.lbl_Sum.Text = sGrossSum + " " + GlobalData.BaseCurrency.Symbol;// +" tax:" + TaxSum.ToString() + " " + NetSum.ToString();
        }

        private void usrc_ShopC_ItemAdded()
        {
            GetPriceSum();
        }

        private void usrc_ShopC_After_Atom_Item_Remove()
        {
            GetPriceSum();
        }

        private void usrc_ShopB_ItemUpdated(ID ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        private void usrc_ShopB_ExtraDiscount(ID ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        private void usrc_ShopB_ItemRemoved(ID ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        private void usrc_ShopB_ItemAdded(ID ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        private bool UpdateInvoicePriceInDraft()
        {
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            string spar_GrossSum = "@par_GrossSum";
            DBConnectionControl40.SQL_Parameter par_GrossSum = new DBConnectionControl40.SQL_Parameter(spar_GrossSum, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, GrossSum);
            lpar.Add(par_GrossSum);
            decimal TaxSum_Value = TaxSum.Value;
            string spar_TaxSum = "@par_TaxSum";

            DBConnectionControl40.SQL_Parameter par_TaxSum = new DBConnectionControl40.SQL_Parameter(spar_TaxSum, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, TaxSum_Value);
            lpar.Add(par_TaxSum);
            string spar_NetSum = "@par_NetSum";
            DBConnectionControl40.SQL_Parameter par_NetSum = new DBConnectionControl40.SQL_Parameter(spar_NetSum, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, NetSum);
            lpar.Add(par_NetSum);

            string sql_SetPrice = "update "+this.DocTyp+" set GrossSum = " + spar_GrossSum + ",TaxSum = " + spar_TaxSum + ",NetSum = " + spar_NetSum + " where ID = " + m_ShopABC.m_CurrentDoc.Doc_ID.ToString();
            object ores = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_SetPrice, lpar, ref ores, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:UpdateInvoicePriceInDraft:Err=" + Err);
                return false;
            }
        }


        private bool IssueDocument()
        {
            //ProgramDiagnostic.Diagnostic.Enabled = true;
            //ProgramDiagnostic.Diagnostic.Init();
            //ProgramDiagnostic.Diagnostic.Clear();
            //ProgramDiagnostic.Diagnostic.Meassure("Before fs.UpdatePriceInDraft", "?");

            if (fs.UpdatePriceInDraft(DocTyp, m_ShopABC.m_CurrentDoc.Doc_ID, GrossSum, TaxSum.Value, NetSum))
            {
                if (IsDocInvoice)
                {
                    this.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                  
                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (m_InvoiceData.SaveDocInvoice(ref DocInvoice_ID,GlobalData.ElectronicDevice_Name,m_LMOUser.Atom_WorkPeriod_ID))
                    {

                        m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;

                        if (Program.b_FVI_SLO)
                        {

                            if ((m_InvoiceData.AddOnDI.IsCashPayment && Program.FVI_SLO1.FVI_for_cash_payment)
                                || (m_InvoiceData.AddOnDI.IsCardPayment && Program.FVI_SLO1.FVI_for_card_payment)
                                || (m_InvoiceData.AddOnDI.IsPaymentOnBankAccount && Program.FVI_SLO1.FVI_for_payment_on_bank_account)
                                )
                            {
                                UniversalInvoice.Person xInvoiceAuthor = fs.GetInvoiceAuthor(m_LMOUser.Atom_myOrganisation_Person_ID);
                                this.SendInvoice(GrossSum, TaxSum, xInvoiceAuthor);
                            }
                        }

                        // read saved doc Invoice again !
                        if (m_InvoiceData.Read_DocInvoice())
                        {

                            if (aa_DocInvoiceSaved != null)
                            {
                                aa_DocInvoiceSaved(m_ShopABC.m_CurrentDoc.Doc_ID);
                            }
                            Printing_DocInvoice();
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
                    ID DocInvoice_ID = null;
                    // save doc Invoice 
                    if (m_InvoiceData.SaveDocProformaInvoice(ref DocInvoice_ID,GlobalData.ElectronicDevice_Name,m_LMOUser.Atom_WorkPeriod_ID))
                    {
                        m_ShopABC.m_CurrentDoc.Doc_ID = DocInvoice_ID;
                        // read saved doc Invoice again !
                        if (m_InvoiceData.Read_DocInvoice())
                        {

                            if (aa_DocProformaInvoiceSaved != null)
                            {
                                aa_DocProformaInvoiceSaved(m_ShopABC.m_CurrentDoc.Doc_ID);
                            }

                            Printing_DocInvoice();
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

        private void SendInvoice(decimal dGrossSum,StaticLib.TaxSum xTaxSum,UniversalInvoice.Person xInvoiceAuthor)
        {
            //if (m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
            //{
            //m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = Program.usrc_FVI_SLO1.GetQRImage(m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v.v);
            //    m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
            //}
            //else
            //{
                string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(false,
                                       Properties.Resources.FVI_SLO_Invoice,
                                       Program.FVI_SLO1.FursD_MyOrgTaxID,
                                       Program.FVI_SLO1.FursD_BussinesPremiseID,
                                       GlobalData.ElectronicDevice_Name,
                                       Program.FVI_SLO1.FursD_InvoiceAuthorTaxID,
                                       "", "",
                                       m_InvoiceData.IssueDate_v,
                                       m_InvoiceData.NumberInFinancialYear,
                                       dGrossSum,
                                       xTaxSum,
                                       xInvoiceAuthor //ToDo : Get real Invoice Autor here!
                                       );
                Image img_QR = null;
                string furs_UniqeMsgID = null;
                string furs_UniqeInvID = null;
                string furs_BarCodeValue = null;

                FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post eres = Program.FVI_SLO1.Send_SingleInvoice(false, furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR);
                switch (eres)
                { 

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK:
                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.TIMEOUT:
                    m_InvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                    m_InvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                    m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                    m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = img_QR;
                    m_InvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(m_InvoiceData.DocInvoice_ID,Program.FVI_SLO1.FursTESTEnvironment);
                    break;

                case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.ERROR:

                    string xSerialNumber = null;
                    string xSetNumber = null;
                    string xInvoiceNumber = null;
                    Program.FVI_SLO1.Write_SalesBookInvoice(m_InvoiceData.DocInvoice_ID, m_InvoiceData.FinancialYear, m_InvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                    ID FVI_SLO_SalesBookInvoice_ID = null;
                    if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(m_InvoiceData.DocInvoice_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID))
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
            m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
            //}
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (m_ShopABC != null)
            {
                if (m_ShopABC.m_CurrentDoc != null)
                {
                    if (m_ShopABC.m_CurrentDoc.Exist)
                    {
                        if (m_ShopABC.m_CurrentDoc.bDraft)
                        {
                            if (IsDocInvoice)
                            {
                                if (!usrc_AddOn1.Check_DocInvoice_AddOn(this.m_InvoiceData.AddOnDI))
                                {
                                    if (!usrc_AddOn1.Get_Doc_AddOn(true))
                                    {
                                        return;
                                    }
                                    if (!usrc_AddOn1.Check_DocInvoice_AddOn(this.m_InvoiceData.AddOnDI))
                                    {
                                        return;
                                    }
                                }
                            }
                            else if (IsDocProformaInvoice)
                            {
                                if (!usrc_AddOn1.Check_DocProformaInvoice_AddOn(this.m_InvoiceData.AddOnDPI))
                                {
                                    if (!usrc_AddOn1.Get_Doc_AddOn(true))
                                    {
                                        return;
                                    }
                                    if (!usrc_AddOn1.Check_DocProformaInvoice_AddOn(this.m_InvoiceData.AddOnDPI))
                                    {
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:uscr_Invoice:btn_Issue_Click:Unknown doc type.");
                            }

                            IssueDocument();
                            DoCurrent(m_ShopABC.m_CurrentDoc.Doc_ID);
                            return;
                        }
                        else
                        {
                            //Print existing invoice
                            m_InvoiceData.DocInvoice_ID = m_ShopABC.m_CurrentDoc.Doc_ID;
                            if (IsDocInvoice)
                            {
                                this.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                if (m_InvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                                { // print invoice if you wish
                                    if (m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
                                    {
                                        m_InvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode = Program.FVI_SLO1.GetQRImage(m_InvoiceData.AddOnDI.m_FURS.FURS_QR_v.v);
                                        m_InvoiceData.AddOnDI.m_FURS.Set_Invoice_Furs_Token();
                                    }
                                    Printing_DocInvoice();
                                    //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                    //frm_Print_Existing_invoice.ShowDialog(this);
                                }
                            }
                            else
                            {
                                if (m_InvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                                {
                                    Printing_DocInvoice();
                                    //TangentaPrint.Form_PrintJournal frm_Print_Existing_invoice = new TangentaPrint.Form_PrintJournal(m_InvoiceData,"UNKNOWN PRINETR NAME??",Program.usrc_TangentaPrint1);
                                    //frm_Print_Existing_invoice.ShowDialog(this);
                                }
                            }
                        }
                    }
                }
            }
        }

   
        private InvoiceData Set_AddOn(InvoiceData invoiceData)
        {
            if (IsDocInvoice)
            {
                invoiceData.AddOnDI = this.m_InvoiceData.AddOnDI;
                invoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                invoiceData.AddOnDPI = null;
                invoiceData.AddOnDI.Get(invoiceData.DocInvoice_ID);
            }
            else if (IsDocProformaInvoice)
            {
                invoiceData.AddOnDPI = this.m_InvoiceData.AddOnDPI;
                invoiceData.AddOnDI = null;
                invoiceData.AddOnDPI.Get(invoiceData.DocInvoice_ID);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_Invoice:SetAddOn:Unknown doc type!");
                invoiceData.AddOnDI = null;
                invoiceData.AddOnDPI = null;
            }
            return invoiceData;
        }

        private bool Printing_DocInvoice()
        {
            TangentaPrint.Form_PrintDocument template_dlg = new TangentaPrint.Form_PrintDocument(m_LMOUser.Atom_WorkPeriod_ID, m_InvoiceData,Properties.Resources.Exit,door.OpenIfUserIsAdministrator);
            template_dlg.Owner = Global.f.GetParentForm(this);
            if (template_dlg.ShowDialog(this)==DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        private void usrc_Customer_Customer_Person_Changed(ID Customer_Person_ID)
        {
            ID Atom_Customer_Person_ID = null;
            this.Cursor = Cursors.WaitCursor;
            if (m_ShopABC.m_CurrentDoc.Update_Customer_Person(DocTyp,Customer_Person_ID, ref Atom_Customer_Person_ID))
            {
                if (ID.Validate(Atom_Customer_Person_ID))
                {
                    usrc_Customer.Show_Customer_Person(m_ShopABC.m_CurrentDoc);
                    if (aa_Customer_Person_Changed != null)
                    {
                        aa_Customer_Person_Changed(Customer_Person_ID);
                    }
                }

            }
            this.Cursor = Cursors.Arrow;
        }


        private void chk_Storno_CheckedChanged(object sender, EventArgs e)
        {

            string stornoReferenceInvoiceNumber = "";
            string stornoReferenceInvoiceIssueDateTime = "";

            if (chk_Storno_CanBe_ManualyChanged)
            {
                bool bstorno = false;
                if (IsDocInvoice)
                {
                    if (m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v != null)
                    {
                        bstorno = m_ShopABC.m_CurrentDoc.TInvoice.bStorno_v.v;
                    }
                }
                
                if (chk_Storno.Checked!=bstorno)
                {
                    if (chk_Storno.Checked)
                    {
                        if (MessageBox.Show(this, lng.s_Invoice.s + ": " + txt_Number.Text + "\r\n" + lng.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Form_Storno frm_storno_dlg = new Form_Storno(m_ShopABC.m_CurrentDoc.Doc_ID);

                            if (frm_storno_dlg.ShowDialog()==DialogResult.Yes)
                            {
                                stornoReferenceInvoiceNumber = m_ShopABC.m_CurrentDoc.NumberInFinancialYear.ToString();
                                stornoReferenceInvoiceIssueDateTime = frm_storno_dlg.m_InvoiceTime;
                                string sInvoiceToStorno = frm_storno_dlg.m_sInvoiceToStorno;
                                if (MessageBox.Show(this,sInvoiceToStorno + "\r\n" + lng.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
    
                                    ID Storno_DocInvoice_ID = null;
                                    DateTime stornoInvoiceIssueDateTime = new DateTime();
                                    if (m_ShopABC.m_CurrentDoc.Storno(m_LMOUser.Atom_WorkPeriod_ID, ref Storno_DocInvoice_ID,true,GlobalData.ElectronicDevice_Name, frm_storno_dlg.m_Reason,ref stornoInvoiceIssueDateTime))
                                    {
                                        if (Storno != null)
                                        {
                                            Storno(true);
                                        }
                                    }

                                    if (Program.b_FVI_SLO)
                                    {
                                        this.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                        InvoiceData xInvoiceData = new InvoiceData(m_ShopABC, Storno_DocInvoice_ID,GlobalData.ElectronicDevice_Name);
                                        if (xInvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                                        {

                                            string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(true,
                                                                                                          Properties.Resources.FVI_SLO_Invoice,
                                                                                                          Program.FVI_SLO1.FursD_MyOrgTaxID,
                                                                                                          Program.FVI_SLO1.FursD_BussinesPremiseID,
                                                                                                          GlobalData.ElectronicDevice_Name,
                                                                                                          Program.FVI_SLO1.FursD_InvoiceAuthorTaxID,
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
                                            if (Program.FVI_SLO1.Send_SingleInvoice(false,furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                                            {
                                                xInvoiceData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);  
                                                xInvoiceData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                                                xInvoiceData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                                                xInvoiceData.AddOnDI.m_FURS.Write_FURS_Response_Data(xInvoiceData.DocInvoice_ID,Program.FVI_SLO1.FursTESTEnvironment);
                                            }
                                            else
                                            {
                                                string xSerialNumber = null;
                                                string xSetNumber = null;
                                                string xInvoiceNumber = null;
                                                Program.FVI_SLO1.Write_SalesBookInvoice(xInvoiceData.DocInvoice_ID, xInvoiceData.FinancialYear, xInvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                                                ID FVI_SLO_SalesBookInvoice_ID = null;
                                                if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(xInvoiceData.DocInvoice_ID, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID))
                                                {
                                                    MessageBox.Show("Storno računa je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, lng.s_YouCanNotCnacelInvoiceStorno.s);
                        chk_Storno_CanBe_ManualyChanged = false;
                        chk_Storno.Checked = true;
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                }
            }
        }




        private void usrc_Customer_Customer_Org_Changed(ID Customer_Org_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            ID Atom_Customer_Org_ID = null;
            if (m_ShopABC.m_CurrentDoc.Update_Customer_Org(DocTyp,Customer_Org_ID, ref Atom_Customer_Org_ID))
            {
                m_ShopABC.m_CurrentDoc.Atom_Customer_Org_ID = Atom_Customer_Org_ID;
                if (ID.Validate(Atom_Customer_Org_ID))
                {
                    usrc_Customer.Show_Customer_Org(m_ShopABC.m_CurrentDoc);
                    if (aa_Customer_Org_Changed != null)
                    {
                        aa_Customer_Org_Changed(Customer_Org_ID);
                    }
                }

            }
            this.Cursor = Cursors.Arrow;
        }

        private bool usrc_Customer_aa_Customer_Removed(string xDoxTyp)
        {
            this.Cursor = Cursors.WaitCursor;
            if (m_ShopABC.m_CurrentDoc.Update_Customer_Remove(xDoxTyp))
            {
                this.Cursor = Cursors.Arrow;
                return true;
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                return false;
            }
        }

        private void btn_Select_Shops_Click(object sender, EventArgs e)
        {
            Form_ShowShops frm_sel_shops = new Form_ShowShops(this,mSettingsUserValues);
            if (frm_sel_shops.ShowDialog(this)==DialogResult.OK)
            {
                Set_eShopsMode(mSettingsUserValues.eShopsMode);
                if (LayoutChanged!=null)
                {
                    LayoutChanged();
                }
            }
            
        }

        private void btn_MyOrganisation_Click(object sender, EventArgs e)
        {
            NavigationButtons.Navigation nav_EditMyOrganisation_Data = new NavigationButtons.Navigation(null);
            nav_EditMyOrganisation_Data.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            nav_EditMyOrganisation_Data.bDoModal = true;
            EditMyOrganisation_Data(false, nav_EditMyOrganisation_Data);
        }

        private void usrc_Currency1_CurrencyChanged(xCurrency currency, ID xAtom_Currency_ID)
        {
            GlobalData.BaseCurrency = currency;
            Atom_Currency_ID = xAtom_Currency_ID;
        }

        private void chk_Head_CheckedChanged_1(object sender, EventArgs e)
        {
            if (LayoutChanged != null)
            {
                LayoutChanged();
            }
        }
    }
}
