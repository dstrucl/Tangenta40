﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlagajnaTableClass;
using SQLTableControl;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_Invoice : UserControl
    {
        usrc_InvoiceMan m_usrc_InvoiceMan = null;
        public enum emode
        {
            view_eInvoiceType,
            edit_eInvoiceType
        }

        public delegate void delegate_Storno(bool bStorno);
        public event delegate_Storno Storno = null;

        public delegate void delegate_ProformaInvoiceSaved(long ProformaInvoice_id);
        public event delegate_ProformaInvoiceSaved aa_ProformaInvoiceSaved;

        public delegate void delegate_Customer_Person_Changed(long Customer_Person_ID);
        public event delegate_Customer_Person_Changed aa_Customer_Person_Changed = null;

        public delegate void delegate_Customer_Org_Changed(long Customer_Org_ID);
        public event delegate_Customer_Org_Changed aa_Customer_Org_Changed = null;

        public delegate void delegate_PriceListChanged();
        public event delegate_PriceListChanged aa_PriceListChanged = null;


        public long Last_myCompany_id = 1;
        public long Last_myCompany_Person_id = 1;

        public emode m_mode = emode.view_eInvoiceType;
        long myCompany_Person_id = -1;

        public DBTablesAndColumnNames DBtcn = null;

        public InvoiceDB.ShopBC m_ShopBC = null;
        public InvoiceData m_InvoiceData = null;

        public xTaxationList m_xTaxationList = null;

        public InvoiceDB.xCurrency BaseCurrency = null;

        public InvoiceDB.xPriceList m_xPriceList = null;

        private decimal GrossSum = 0;
        private decimal NetSum = 0;
        private StaticLib.TaxSum TaxSum = null;


        private bool chk_Storno_CanBe_ManualyChanged = true;

        public enum enum_Invoice
        {
            Invoice,
            ProformaInvoice,
            Invoice_From_ProformaInvoice
        };



        public enum_Invoice eInvoiceType = enum_Invoice.Invoice;

        public List<Employee> Employees = new List<Employee>();
        public class InvoiceType
        {
            private enum_Invoice m_eInvoiceType = enum_Invoice.Invoice;
            private string m_InvoiceType_Text = null;
            private string m_InvoiceTypeName = null;

            public enum_Invoice eInvoiceType
            {
                get { return m_eInvoiceType; }
            }
            public string InvoiceType_Text
            {
                get { return m_InvoiceType_Text; }
            }

            public string InvoiceTypeName
            {
                get { return m_InvoiceTypeName; }
            }

            public InvoiceType(string name, enum_Invoice etyp)
            {
                m_InvoiceType_Text = name;
                m_eInvoiceType = etyp;
                switch (etyp)
                {
                    case enum_Invoice.Invoice:
                        m_InvoiceTypeName = "Invoice";
                        break;
                    case enum_Invoice.Invoice_From_ProformaInvoice:
                        m_InvoiceTypeName = "Invoice_From_ProformaInvoice";
                        break;
                    case enum_Invoice.ProformaInvoice:
                        m_InvoiceTypeName = "ProformaInvoice";
                        break;
                }
            }

        }


        public enum enum_GetCompany_Person_Data { MyCompany_Data_OK,
            No_MyCompany_Tax_ID,
            No_MyCompany_name,
            No_MyCompany_StreetName,
            No_MyCompany_HouseNumber,
            No_MyCompany_ZIP,
            No_MyCompany_City,
            No_MyCompany_State,
            No_MyCompany_Country,
            No_MyCompanyData,
            No_MyCompany_Person_FirstName,
            No_MyCompany_Person,
            Error_Load_MyCompany_data

        };





        DataTable dt_myCompany_Person = new DataTable();
        private bool EventsActive;

        public long PriceList_ID
        {
            get
            {
                if (this.usrc_PriceList != null)
                {
                    return this.usrc_PriceList.ID;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                    return -1;
                }
            }
        }

        public usrc_Invoice()
        {
            InitializeComponent();
            m_mode = emode.view_eInvoiceType;
            lngRPM.s_Issuer.Text(lbl_MyCompany);
            lngRPM.s_Number.Text(lbl_Number);
            lngRPM.s_Currency.Text(lbl_Currency);
            //btn_BuyerSelect.Text = lngRPM.s_BuyerSelect.s;
            lngRPM.s_Issue.Text(btn_Issue);
            lngRPM.s_chk_Storno.Text(chk_Storno);
            lngRPM.s_CodeTables.Text(btn_CodeTables);
            //SetMode(m_mode);

        }

        internal void SetMode(emode mode)
        {
            m_mode = mode;
            this.usrc_SimpleItemMan.SetMode(mode);
            this.usrc_ItemMan.SetMode(mode);
            if (mode == emode.view_eInvoiceType)
            {
                chk_Storno.Visible = true;
                lngRPM.s_Print.Text(btn_Issue);
            }
            else
            {
                lngRPM.s_Issue.Text(btn_Issue);
                chk_Storno.Visible = false;
            }

        }

        public void EnableControls(bool b)
        {
            this.splitContainer1.Enabled = b;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private bool EditMyCompany_Person_Data()
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            if (Program.b_FVI_SLO)
            {
                Form_MyCompany_Person_Data_Edit edt_my_company_person_dlg = new Form_MyCompany_Person_Data_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(FVI_SLO_RealEstateBP))));
                dres = edt_my_company_person_dlg.ShowDialog();
            }
            else
            {
                Form_MyCompany_Person_Data_Edit edt_my_company_person_dlg = new Form_MyCompany_Person_Data_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person))));
                dres = edt_my_company_person_dlg.ShowDialog();
            }

            if (dres == DialogResult.OK)
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

        public bool Initialise(Form pparent, usrc_InvoiceMan xusrc_InvoiceMan)
        {
            m_usrc_InvoiceMan = xusrc_InvoiceMan;
            this.txt_Number.Text = "";
            if (DBtcn == null)
            {
                DBtcn = new DBTablesAndColumnNames();
            }
            if (m_ShopBC == null)
            {
                m_ShopBC = new ShopBC(DBtcn);
            }
            this.usrc_SimpleItemMan.Init(m_ShopBC, DBtcn);
            this.usrc_ItemMan.Init(m_ShopBC, DBtcn, this);



            string Err = null;
            if (Get_BaseCurrency(ref Err))
            {
                if (GetCompanyData())
                {
                    if (GetTaxation())
                    {
                        int iCountSimpleItemData = 0;
                        int iCountItemData = 0;

                        if (GetSimpleItemData(ref iCountSimpleItemData))
                        {
                            if (GetItemData(ref iCountItemData))
                            {
                                if (iCountSimpleItemData + iCountItemData > 0)
                                {
                                    if (GetPriceList())
                                    {
                                        int iCount_Price_SimpleItem_Data = 0;

                                        if (Get_Price_SimpleItem_Data(ref iCount_Price_SimpleItem_Data, this.usrc_PriceList.ID))
                                        {

                                            this.usrc_SimpleItemMan.Set_dgv_SelectedSimpleItems();

                                        }

                                        if (this.usrc_ItemMan.usrc_ItemList.Get_Price_Item_Stock_Data(this.usrc_PriceList.ID))
                                        {


                                            f_PriceList.Check(pparent);
                                            bool bEditPriceList = false;
                                            f_PriceList.CheckPriceUndefined(pparent, DBSync.DBSync.DB_for_Blagajna.m_DBTables, ref bEditPriceList);
                                            if (bEditPriceList)
                                            {
                                                Program.PriceList_Edit(BaseCurrency.ID, this.usrc_PriceList.cmb_PriceListType, m_xPriceList, true);
                                            }

                                            if (Program.bStartup)
                                            {
                                                Program.bStartup = false;
                                                if (DBSync.DBSync.DB_for_Blagajna.Settings.StockCheckAtStartup.TextValue.Equals("1"))
                                                {
                                                    bool ExpiryItemsFound = false;
                                                    string sNoExpiryDate = null;
                                                    string sNoSaleBeforeExpiryDate = null;
                                                    string sNoDiscardBeforeExpiryDate = null;
                                                    DataTable dt_ExpiryCheck = new DataTable();
                                                    if (fs.ExpiryCheck(ref dt_ExpiryCheck,ref ExpiryItemsFound,ref sNoExpiryDate,ref sNoSaleBeforeExpiryDate,ref sNoDiscardBeforeExpiryDate))
                                                    {
                                                        Form_Expiry_Check frm_exp_chk = new Form_Expiry_Check(dt_ExpiryCheck, this, sNoExpiryDate, sNoSaleBeforeExpiryDate, sNoDiscardBeforeExpiryDate);
                                                        frm_exp_chk.ShowDialog();
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
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, lngRPM.s_TherAreNoSimpleItemAndItemData.s);
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
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR: Get_BaseCurrency:Err = " + Err);
                return false;
            }

        }

        private bool DoCurrent(long ID)
        {
            if (DoGetCurrent(ID))
            {
                if (m_ShopBC.m_CurrentInvoice.bDraft)
                {
                    this.usrc_SimpleItemMan.SetDraftButtons();
                }
                else
                {
                    this.usrc_SimpleItemMan.SetViewButtons();
                }
                this.usrc_Customer.Show_Customer(m_ShopBC.m_CurrentInvoice);
                return true;
            }
            else
            {
                usrc_Customer.Text = "";
                return false;
            }
        }

        public bool Init(Form pparent, usrc_InvoiceMan xusrc_InvoiceMan, long ID, bool bInitialise)
        {
            if (bInitialise)
            {
                lngRPM.s_rdbStore_SimpleItem_And_Item.Text(rdbStore_SimpleItem_And_Item);
                lngRPM.s_rdbStore_Item.Text(rdbStore_Item);
                lngRPM.s_rdbStore_SimpleItem.Text(rdbStore_SimpleItem);
                lngRPM.s_Head.Text(chk_Head);
                chk_Head.Checked = true;
                chk_Head.CheckedChanged += chk_Head_CheckedChanged;
                if (Initialise(pparent, xusrc_InvoiceMan))
                {
                    if (GetReceiptPrinter())
                    {
                        return DoCurrent(ID);
                    }
                }
            }
            else
            {
                return DoCurrent(ID);
            }
            return false;
        }

        void chk_Head_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Head.Checked)
            {
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {
                splitContainer2.Panel1Collapsed = true;
            }
        }

        private bool DoGetCurrent(long ID)
        {
            if (GetCurrent(ID))
            {
                GetPriceSum();
                if (m_ShopBC.m_CurrentInvoice.bDraft)
                {
                    AddHandler();
                }
                else
                {
                    if (m_ShopBC.m_CurrentInvoice.Exist)
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
                this.usrc_SimpleItemMan.aa_ItemAdded += new usrc_SimpleItemMan.delegate_ItemAdded(usrc_SimpleItemMan_ItemAdded);
                this.usrc_SimpleItemMan.aa_ItemRemoved += new usrc_SimpleItemMan.delegate_ItemRemoved(usrc_SimpleItemMan_ItemRemoved);
                this.usrc_SimpleItemMan.aa_ItemUpdated += new usrc_SimpleItemMan.delegate_ItemUpdated(usrc_SimpleItemMan_ItemUpdated);
                this.usrc_SimpleItemMan.aa_ExtraDiscount += new usrc_SimpleItemMan.delegate_ExtraDiscount(usrc_SimpleItemMan_ExtraDiscount);
            }
        }

        private void RemoveHandler()
        {
            if (EventsActive)
            {
                EventsActive = false;
                this.usrc_SimpleItemMan.aa_ItemAdded -= new usrc_SimpleItemMan.delegate_ItemAdded(usrc_SimpleItemMan_ItemAdded);
                this.usrc_SimpleItemMan.aa_ItemRemoved -= new usrc_SimpleItemMan.delegate_ItemRemoved(usrc_SimpleItemMan_ItemRemoved);
                this.usrc_SimpleItemMan.aa_ItemUpdated -= new usrc_SimpleItemMan.delegate_ItemUpdated(usrc_SimpleItemMan_ItemUpdated);
                this.usrc_SimpleItemMan.aa_ExtraDiscount -= new usrc_SimpleItemMan.delegate_ExtraDiscount(usrc_SimpleItemMan_ExtraDiscount);
            }
        }


        private bool GetReceiptPrinter()
        {
            if (Program.usrc_Printer1.Printer == null)
            {
                Program.usrc_Printer1.Printer = new Printer();
            }
            Program.usrc_Printer1.Printer.Define(null);
            return true;
        }


        private bool GetTaxation()
        {
            if (m_xTaxationList == null)
            {
                m_xTaxationList = new xTaxationList();
            }
            string Err = null;
            if (m_xTaxationList.Get(ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:GetTaxation:m_xTaxationList.Ge:Err=" + Err);
                return false;
            }
        }

        private bool GetPriceList()
        {
            string Err = null;
            return usrc_PriceList.Init(BaseCurrency.ID, ref Err);
        }


        internal bool GetSimpleItemData(ref int iCountSimpleItemData)
        {
            if (this.usrc_SimpleItemMan.GetSimpleItemData(ref iCountSimpleItemData))
            {
                if (iCountSimpleItemData > 0)
                {
                    return true;
                }
                else
                {
                    if (MessageBox.Show(this, lngRPM.s_NoSimpleItemData_EnterSimpleItemDataQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.usrc_SimpleItemMan.EditSimpleItem();
                        if (this.usrc_SimpleItemMan.GetSimpleItemData(ref iCountSimpleItemData))
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

        internal bool Get_Price_SimpleItem_Data(ref int iCount_Price_SimpleItem_Data, long PriceList_id)
        {
            if (this.usrc_SimpleItemMan.Get_Price_SimpleItem_Data(ref iCount_Price_SimpleItem_Data, PriceList_id))
            {
                if (iCount_Price_SimpleItem_Data > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, lngRPM.s_No_Price_SimpleItem_Data.s);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        internal bool GetItemData(ref int iCountItemData)
        {
            if (this.usrc_ItemMan.GetItemData(ref iCountItemData))
            {
                if (iCountItemData > 0)
                {
                    return true;
                }
                else
                {
                    if (MessageBox.Show(this, lngRPM.s_NoItemData_EnterItemDataQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.usrc_ItemMan.EditItem();
                        if (this.usrc_ItemMan.GetItemData(ref iCountItemData))
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



        internal bool GetCompanyData()
        {
            string sAddress = null;
            for (;;)
            {
                switch (myOrg.SelectCompanyData(dt_myCompany_Person, Last_myCompany_id, Last_myCompany_Person_id, ref sAddress))
                {
                    case myOrg.enum_GetCompany_Person_Data.MyCompany_Data_OK:
                        {
                            this.txt_MyCompany.Text = myOrg.Name_v.vs + "," + sAddress
                             + "\r\nDavčna Številka:" + myOrg.Tax_ID_v.vs
                             + "\r\nMatična Številka:" + myOrg.Registration_ID_v.vs
                             + "\r\nTelefon:" + myOrg.PhoneNumber_v.vs
                             + "\r\nEmail:" + myOrg.Email_v.vs
                             + "\r\nDomača stran:" + myOrg.HomePage_v.vs;
                            Fill_MyCompany_Person();

                            return true;
                        }
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompanyData:
                        MessageBox.Show(lngRPM.s_No_CompanyData.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_StreetName:
                        MessageBox.Show(lngRPM.s_No_MyCompany_StreetName.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_HouseNumber:
                        MessageBox.Show(lngRPM.s_No_MyCompany_HouseNumber.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_ZIP:
                        MessageBox.Show(lngRPM.s_No_MyCompany_ZIP.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_City:
                        MessageBox.Show(lngRPM.s_No_MyCompany_City.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_State:
                        MessageBox.Show(lngRPM.s_No_MyCompany_State.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_name:
                        MessageBox.Show(lngRPM.s_No_MyCompany_name.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;

                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_Person:
                        MessageBox.Show(lngRPM.s_No_MyCompany_Person.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;

                    case myOrg.enum_GetCompany_Person_Data.No_MyCompany_Tax_ID:
                        MessageBox.Show(lngRPM.s_No_MyCompany_Tax_ID.s);
                        if (!EditMyCompany_Person_Data())
                        {
                            return false;
                        }
                        break;
                }
            }
        }




        private bool GetCurrent(long ID)
        {
            switch (eInvoiceType)
            {
                case enum_Invoice.Invoice:
                    return GetCurrentInvoice(ID);


                case enum_Invoice.ProformaInvoice:
                    return GetProformaInvoiceDraft();
                case enum_Invoice.Invoice_From_ProformaInvoice:
                    return SelectProformaInvoice();
            }
            return false;

        }


        private bool GetCurrentInvoice(long ID)
        {
            string Err = null;
            long Invoice_ID = -1;
            //
            if (m_ShopBC.Get(ref Invoice_ID, true, ID, ref Err)) // try to get draft
            {
                if (Invoice_ID >= 0)
                {
                    this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopBC.m_CurrentInvoice.bDraft, m_ShopBC.m_CurrentInvoice.FinancialYear, m_ShopBC.m_CurrentInvoice.NumberInFinancialYear, m_ShopBC.m_CurrentInvoice.DraftNumber);
                    if (m_ShopBC.m_CurrentInvoice.bDraft)
                    {
                        SetMode(emode.edit_eInvoiceType);
                        this.usrc_SimpleItemMan.SetCurrentInvoice_SelectedSimpleItems();
                        this.usrc_ItemMan.SetCurrentInvoice_SelectedItems();
                    }
                    else
                    {
                        SetMode(emode.view_eInvoiceType);
                        this.usrc_SimpleItemMan.SetCurrentInvoice_SelectedSimpleItems();
                        this.usrc_ItemMan.SetCurrentInvoice_SelectedItems();
                        chk_Storno_CanBe_ManualyChanged = false;
                        this.chk_Storno.Checked = m_ShopBC.m_CurrentInvoice.bStorno;
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                    this.usrc_ItemMan.Reset();
                    return true;
                }
                else
                {
                    SetMode(emode.view_eInvoiceType);
                    if (m_ShopBC.Get(ref Invoice_ID, false, ID, ref Err)) // Get invoice with Invoice_ID
                    {
                        if (Invoice_ID >= 0)
                        {
                            this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopBC.m_CurrentInvoice.bDraft, m_ShopBC.m_CurrentInvoice.FinancialYear, m_ShopBC.m_CurrentInvoice.NumberInFinancialYear, m_ShopBC.m_CurrentInvoice.DraftNumber);
                            this.usrc_ItemMan.Clear();
                            this.usrc_ItemMan.SetCurrentInvoice_SelectedItems();
                        }
                        this.usrc_ItemMan.Reset();
                        return true;
                    }
                    else
                    {
                        this.usrc_ItemMan.Reset();
                        return false;
                    }
                }
            }
            else
            {
                this.usrc_ItemMan.Reset();
                return false;
            }
        }

        private void SetDraft_SelectedSimpleItems()
        {

        }

        private bool GetProformaInvoiceDraft()
        {
            throw new NotImplementedException();
        }

        private bool SelectProformaInvoice()
        {
            throw new NotImplementedException();
        }









        internal bool Get_BaseCurrency(ref string Err)
        {
            string sql_BaseCurrency = "select Currency_ID from BaseCurrency";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_BaseCurrency, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    long currency_id = (long)dt.Rows[0]["Currency_ID"];

                    if (BaseCurrency == null)
                    {
                        BaseCurrency = new xCurrency();
                    }
                    if (BaseCurrency.SetCurrency(currency_id, ref Err))
                    {
                        this.txt_Currency.Text = BaseCurrency.Abbreviation + " " + BaseCurrency.Symbol;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (Select_BaseCurrency(ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                Err = "ERROR:usrc_Invoice:Init_Currency_Table:Err=" + Err;
                return false;
            }
        }

        private bool Select_BaseCurrency(ref string Err)
        {
            if (BaseCurrency == null)
            {
                BaseCurrency = new xCurrency();
            }
            Form_Select_DefaultCurrency sel_basecurrency_dlg = new Form_Select_DefaultCurrency(ref BaseCurrency);
            if (sel_basecurrency_dlg.ShowDialog() == DialogResult.OK)
            {
                string sql_SetBaseCurrency = "Insert into BaseCurrency (Currency_ID) Values (" + sel_basecurrency_dlg.Currency_ID.ToString() + ")";
                object oRes = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_SetBaseCurrency, null, ref oRes, ref Err))
                {
                    this.txt_Currency.Text = BaseCurrency.Abbreviation + " " + BaseCurrency.Symbol;
                    return true;
                }
                else
                {
                    Err = "ERROR:usrc_Invoice:Init_Currency_Table:Err=" + Err;
                    return false;
                }

            }
            else
            {
                Err = "ERROR: Default Currency is not selected!";
                return false;
            }

        }


        private void Fill_MyCompany_Person()
        {
            DataTable dtEmployees = new DataTable();
            string sql_my_company_person = @"Select ID,
                                            myCompany_Person_$_office_$_mc_$$ID,
                                            myCompany_Person_$_per_$_cfn_$$FirstName,
                                            myCompany_Person_$_per_$_cln_$$LastName,
                                            myCompany_Person_$$Job,
                                            myCompany_Person_$$UserName,
                                            myCompany_Person_$$Password,
                                            myCompany_Person_$$Description,
                                            myCompany_Person_$$Active
                                            from myCompany_Person_VIEW
                                            where myCompany_Person_$_office_$_mc_$$ID = " + Last_myCompany_id.ToString()
                                              + " and myCompany_Person_$$Active = 1";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtEmployees, sql_my_company_person, ref Err))
            {
                if (dtEmployees.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmployees.Rows)
                    {
                        Employee employee = new Employee((string)dr["myCompany_Person_$_per_$_cfn_$$FirstName"],
                                                         (string)dr["myCompany_Person_$_per_$_cln_$$LastName"],
                                                            dr["myCompany_Person_$$Job"],
                                                            dr["myCompany_Person_$$UserName"],
                                                            dr["myCompany_Person_$$Password"],
                                                            dr["myCompany_Person_$$Description"],
                                                          (bool)dr["myCompany_Person_$$Active"],
                                                          (long)dr["ID"],
                                                          (long)dr["myCompany_Person_$_office_$_mc_$$ID"]
                                                          );
                        Employees.Add(employee);
                    }
                    this.cmb_select_my_Company_Person.DataSource = Employees;
                    this.cmb_select_my_Company_Person.DisplayMember = "Person";
                    this.cmb_select_my_Company_Person.ValueMember = "myCompany_Person_ID";
                    this.cmb_select_my_Company_Person.SelectedItem = Last_myCompany_Person_id;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:Fill_MyCompany_Person:Err=" + Err);
            }
        }







        private void btn_Preview_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_MyCompany_Click(object sender, EventArgs e)
        {

        }


        private void cmb_InvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SetNewDraft(enum_Invoice eInvType, int FinancialYear)
        {
            switch (eInvoiceType)
            {
                case enum_Invoice.Invoice:
                    if (m_ShopBC == null)
                    {
                        m_ShopBC = new ShopBC(DBtcn);
                    }
                    if (SetNewInvoiceDraft(FinancialYear))
                    {
                        SetMode(emode.edit_eInvoiceType);
                    }
                    return;

                case enum_Invoice.ProformaInvoice:
                    return;

                case enum_Invoice.Invoice_From_ProformaInvoice:
                    return;
            }
            return;

        }

        private bool SetNewInvoiceDraft(int FinancialYear)
        {
            long Invoice_ID = -1;
            string Err = null;
            if (m_ShopBC.SetNewDraft_Invoice(FinancialYear, this, ref Invoice_ID, Last_myCompany_Person_id, ref Err))
            {
                if (m_ShopBC.m_CurrentInvoice.Invoice_ID >= 0)
                {
                    this.txt_Number.Text = m_ShopBC.m_CurrentInvoice.FinancialYear.ToString() + "/" + m_ShopBC.m_CurrentInvoice.DraftNumber.ToString();
                    SetMode(emode.edit_eInvoiceType);
                }

                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:SetInvoiceDraft:Err=" + Err);
                return false;
            }
        }

        private void btn_edit_MyCompany_Click_1(object sender, EventArgs e)
        {
            EditMyCompany_Person_Data();
            string sAddress = null;
            myOrg.SelectCompanyData(dt_myCompany_Person, Last_myCompany_id, Last_myCompany_Person_id, ref sAddress);
            if (Last_myCompany_Person_id >= 0)
            {
                long Atom_myCompany_Person_ID = -1;
                string_v office_name = null;
                string Err = null;
                f_Atom_myCompany_Person.Get(Last_myCompany_Person_id, ref Atom_myCompany_Person_ID, ref office_name);
            }
        }

        private void usrc_SimpleItemMan_Load(object sender, EventArgs e)
        {

        }

        private void btn_SelectBaseCurrency_Click(object sender, EventArgs e)
        {
            string Err = null;
            Select_BaseCurrency(ref Err);
        }

        private void lbl_PriceList_SimpleItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_PriceList_SimpleItem_Click(object sender, EventArgs e)
        {

        }

        private void cmb_PriceList_SimpleItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GetPriceSum()
        {
            decimal dsum_GrossSum = 0;
            decimal dsum_TaxSum = 0;
            decimal dsum_NetSum = 0;


            TaxSum = null;
            TaxSum = new StaticLib.TaxSum();

            foreach (DataRow dr in this.usrc_SimpleItemMan.dt_SelectedSimpleItem.Rows)
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

            m_ShopBC.m_CurrentInvoice.m_Basket.GetPriceSum(ref dsum_GrossSum_Basket, ref dsum_TaxSum_Basket, ref dsum_NetSum_Basket, ref TaxSum);

            dsum_GrossSum += dsum_GrossSum_Basket;
            dsum_TaxSum += dsum_TaxSum_Basket;
            dsum_NetSum += dsum_NetSum_Basket;

            //dsum_NetSum += appisd.Get.v;

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
            this.lbl_Sum.Text = dsum_GrossSum.ToString() + " " + BaseCurrency.Symbol;// +" tax:" + TaxSum.ToString() + " " + NetSum.ToString();
        }

        private void usrc_ItemMan_ItemAdded()
        {
            GetPriceSum();
        }

        private void usrc_ItemMan_After_Atom_Item_Remove()
        {
            GetPriceSum();
        }

        void usrc_SimpleItemMan_ItemUpdated(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_SimpleItemMan_ExtraDiscount(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_SimpleItemMan_ItemRemoved(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_SimpleItemMan_ItemAdded(long ID, DataTable dt_SelectedSimpleItem)
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

            string sql_SetPrice = "update proformainvoice set GrossSum = " + spar_GrossSum + ",TaxSum = " + spar_TaxSum + ",NetSum = " + spar_NetSum + " where ID = " + m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID.ToString();
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

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (m_ShopBC != null)
            {
                if (m_ShopBC.m_CurrentInvoice != null)
                {
                    long myCompany_Person_id = -1;
                    object o_myCompany_Person_id = cmb_select_my_Company_Person.SelectedItem;
                    if (o_myCompany_Person_id is Tangenta.Employee)
                    {
                        Tangenta.Employee employe = (Tangenta.Employee)o_myCompany_Person_id;
                        myCompany_Person_id = employe.myCompany_Person_ID;
                    }

                    if (m_ShopBC.m_CurrentInvoice.Exist)
                    {
                        if (m_ShopBC.m_CurrentInvoice.bDraft)
                        {

                            // print draft invoice
                            if (UpdateInvoicePriceInDraft())
                            {
                                m_InvoiceData = new InvoiceData(m_ShopBC, m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID);
                                if (m_InvoiceData.Read_ProformaInvoice()) // read Proforma Invoice again from DataBase
                                {
                                    Form_Payment payment_frm = new Form_Payment(m_InvoiceData);
                                    if (payment_frm.ShowDialog() == DialogResult.OK)
                                    {
                                        if (aa_ProformaInvoiceSaved != null)
                                        {
                                            aa_ProformaInvoiceSaved(m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_InvoiceData = new InvoiceData(m_ShopBC, m_ShopBC.m_CurrentInvoice.ProformaInvoice_ID);
                            if (m_InvoiceData.Read_ProformaInvoice()) // read Proforma Invoice again from DataBase
                            { // print invoice if you wish
                                Form_PrintExistingInvoice frm_Print_Existing_invoice = new Form_PrintExistingInvoice(m_InvoiceData);
                                frm_Print_Existing_invoice.ShowDialog(this);
                            }
                        }
                    }
                }
            }
        }


        private void rdbStore_SimpleItem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbStore_SimpleItem.Checked)
            {
                this.splitContainer1.Panel1Collapsed = false;
                this.splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
            }
        }

        private void rdbStore_Item_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbStore_Item.Checked)
            {
                this.splitContainer1.Panel2Collapsed = false;
                this.splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
            }

        }

        private void rdbStore_SimpleItem_And_Item_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbStore_SimpleItem_And_Item.Checked)
            {
                this.splitContainer1.Panel1Collapsed = false;
                this.splitContainer1.Panel2Collapsed = false;
            }
        }


        private void usrc_Customer_Load(object sender, EventArgs e)
        {

        }




        private void usrc_Customer_Customer_Person_Changed(long Customer_Person_ID)
        {
            long_v Atom_Customer_Person_ID_v = null;
            this.Cursor = Cursors.WaitCursor;
            if (m_ShopBC.m_CurrentInvoice.Update_Customer_Person(Customer_Person_ID, ref Atom_Customer_Person_ID_v))
            {
                if (Atom_Customer_Person_ID_v != null)
                {
                    usrc_Customer.Show_Customer_Person(m_ShopBC.m_CurrentInvoice);
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
            if (chk_Storno_CanBe_ManualyChanged)
            {
                if (chk_Storno.Checked!=m_ShopBC.m_CurrentInvoice.bStorno)
                {
                    if (chk_Storno.Checked)
                    {
                        if (MessageBox.Show(this, lngRPM.s_Invoice.s + ": " + txt_Number.Text + "\r\n" + lngRPM.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Form_Storno frm_storno_dlg = new Form_Storno(m_ShopBC.m_CurrentInvoice.Invoice_ID);
                            if (frm_storno_dlg.ShowDialog()==DialogResult.Yes)
                            {
                                string sInvoiceToStorno = frm_storno_dlg.m_sInvoiceToStorno;
                                if (MessageBox.Show(this,sInvoiceToStorno + "\r\n" + lngRPM.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    if (m_ShopBC.m_CurrentInvoice.Storno(true, frm_storno_dlg.m_Reason))
                                    {
                                        if (Storno != null)
                                        {
                                            Storno(true);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, lngRPM.s_YouCanNotCnacelInvoiceStorno.s);
                        chk_Storno_CanBe_ManualyChanged = false;
                        chk_Storno.Checked = true;
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                }
            }
        }


        public long myCompany_Person_ID { get; set; }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            Form_CodeTables fct_dlg = new Form_CodeTables();
            fct_dlg.ShowDialog();
        }

        private void usrc_Customer_Customer_Org_Changed(long Customer_Org_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            long_v Atom_Customer_Org_ID_v = null;
            if (m_ShopBC.m_CurrentInvoice.Update_Customer_Org(Customer_Org_ID, ref Atom_Customer_Org_ID_v))
            {
                m_ShopBC.m_CurrentInvoice.Atom_Customer_Org_ID_v = Atom_Customer_Org_ID_v;
                if (Atom_Customer_Org_ID_v != null)
                {
                    usrc_Customer.Show_Customer_Org(m_ShopBC.m_CurrentInvoice);
                    if (aa_Customer_Org_Changed != null)
                    {
                        aa_Customer_Org_Changed(Customer_Org_ID);
                    }
                }

            }
            this.Cursor = Cursors.Arrow;
        }

        private bool usrc_Customer_aa_Customer_Removed()
        {
            this.Cursor = Cursors.WaitCursor;
            if (m_ShopBC.m_CurrentInvoice.Update_Customer_Remove())
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
    }
}