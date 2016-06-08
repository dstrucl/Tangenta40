﻿#region LICENSE 
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

namespace Tangenta
{
    public partial class usrc_Invoice : UserControl
    {
        public enum eShopsMode { A, B, C, AB, BC, AC, ABC };

        public usrc_ShopA m_usrc_ShopA = null;
        public usrc_ShopB m_usrc_ShopB = null;
        public usrc_ShopC m_usrc_ShopC = null;
        public eShopsMode m_eShopsMode = eShopsMode.BC;

        usrc_InvoiceMan m_usrc_InvoiceMan = null;
        public enum emode
        {
            view_eInvoiceType,
            edit_eInvoiceType
        }

        public delegate void delegate_Storno(bool bStorno);
        public event delegate_Storno Storno = null;

        public delegate void delegate_DocInvoiceSaved(long DocInvoice_id);
        public event delegate_DocInvoiceSaved aa_DocInvoiceSaved;

        public delegate void delegate_Customer_Person_Changed(long Customer_Person_ID);
        public event delegate_Customer_Person_Changed aa_Customer_Person_Changed = null;

        public delegate void delegate_Customer_Org_Changed(long Customer_Org_ID);
        public event delegate_Customer_Org_Changed aa_Customer_Org_Changed = null;

        public delegate void delegate_PriceListChanged();
        public event delegate_PriceListChanged aa_PriceListChanged = null;


        public long Last_myOrganisation_id = 1;
        public long Last_myOrganisation_Person_id = 1;

        public emode m_mode = emode.view_eInvoiceType;

        public DBTablesAndColumnNames DBtcn = null;

        public TangentaDB.ShopABC m_ShopABC = null;
        public InvoiceData m_InvoiceData = null;

        public long myOrganisation_Person_id
        {
            get {
                object oSelvalue = this.cmb_select_my_Organisation_Person.SelectedValue;
                if (oSelvalue is long)
                {
                    return (long)oSelvalue;
                }
                else
                {
                    return -1;
                }
            }
        }




        private decimal GrossSum = 0;
        private decimal NetSum = 0;
        private StaticLib.TaxSum TaxSum = null;


        private bool chk_Storno_CanBe_ManualyChanged = true;

        public enum enum_Invoice
        {
            Invoice,
            DocInvoice,
            Invoice_From_DocInvoice
        };



        public enum_Invoice eInvoiceType = enum_Invoice.Invoice;

        public List<Employee> Employees = new List<Employee>();

        internal void Set_eShopsMode(eShopsMode xeShopsMode)
        {
            m_eShopsMode = xeShopsMode;
            Save_eShopsMode(m_eShopsMode);
            switch (xeShopsMode)
            {
                case usrc_Invoice.eShopsMode.A:
                    Set_eShopsMode_A();
                    break;
                case usrc_Invoice.eShopsMode.B:
                    Set_eShopsMode_B();
                    break;
                case usrc_Invoice.eShopsMode.C:
                    Set_eShopsMode_C();
                    break;
                case usrc_Invoice.eShopsMode.AB:
                    Set_eShopsMode_AB();
                    break;
                case usrc_Invoice.eShopsMode.BC:
                    Set_eShopsMode_BC();
                    break;
                case usrc_Invoice.eShopsMode.AC:
                    Set_eShopsMode_AC();
                    break;
                case usrc_Invoice.eShopsMode.ABC:
                    Set_eShopsMode_ABC();
                    break;
                default:
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode!");
                    return;
            }
        }

        private void New_ShopA()
        {
            m_usrc_ShopA = new usrc_ShopA();
            m_usrc_ShopA.Init(this.m_ShopABC, DBtcn);
            m_usrc_ShopA.Dock = DockStyle.Fill;
            m_usrc_ShopA.aa_ItemAdded += M_usrc_ShopA_aa_ItemAdded;
            m_usrc_ShopA.aa_ItemRemoved += M_usrc_ShopA_aa_ItemRemoved;
            m_usrc_ShopA.EditUnits += M_usrc_ShopA_EditUnits;

        }

        private bool M_usrc_ShopA_EditUnits()
        {
            SQLTable tbl_Unit = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Unit)));
            Form_Unit_Edit unit_dlg = new Form_Unit_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Unit, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                GetUnits();
                return true;

            }
            return false;
        }

        private void M_usrc_ShopA_aa_ItemRemoved(long ID, DataTable dt)
        {
            GetPriceSum();
        }

        private void M_usrc_ShopA_aa_ItemAdded(long ID, DataTable dt)
        {
            GetPriceSum();
        }

        private void New_ShopB()
        {
            m_usrc_ShopB = new usrc_ShopB();
            m_usrc_ShopB.Init(this.m_ShopABC, DBtcn,Program.Shops_in_use);
            m_usrc_ShopB.Dock = DockStyle.Fill;
            m_usrc_ShopB.aa_ExtraDiscount += usrc_ShopB_ExtraDiscount;
            m_usrc_ShopB.aa_ItemAdded += usrc_ShopB_ItemAdded;
            m_usrc_ShopB.aa_ItemRemoved += usrc_ShopB_ItemRemoved;
            m_usrc_ShopB.aa_ItemUpdated += usrc_ShopB_ItemUpdated;

        }

        private void New_ShopC()
        {
            m_usrc_ShopC = new usrc_ShopC();
            m_usrc_ShopC.Init(this.m_ShopABC, DBtcn,Program.Shops_in_use);
            m_usrc_ShopC.Dock = DockStyle.Fill;
            m_usrc_ShopC.ItemAdded += usrc_ShopC_ItemAdded;
            m_usrc_ShopC.After_Atom_Item_Remove += usrc_ShopC_After_Atom_Item_Remove;
        }

        private void Set_eShopsMode_A()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);
        }

        private void Set_eShopsMode_B()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopB);
        }

        private void Set_eShopsMode_C()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopC);
        }


        private void Set_eShopsMode_AB()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopB);
        }


        private void Set_eShopsMode_BC()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopB);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopC);
        }

        private void Set_eShopsMode_AC()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel2Collapsed = true;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopC);
        }

        private void Set_eShopsMode_ABC()
        {
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer3.Panel1.Controls.Clear();
            this.splitContainer3.Panel2.Controls.Clear();

            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer3.Panel1Collapsed = false;
            this.splitContainer3.Panel2Collapsed = false;

            this.splitContainer1.Panel1.Controls.Add(m_usrc_ShopA);

            this.splitContainer3.Panel1.Controls.Add(m_usrc_ShopB);

            this.splitContainer3.Panel2.Controls.Add(m_usrc_ShopC);
        }

        internal void Save_eShopsMode(eShopsMode xeShopsMode)
        {
            switch (xeShopsMode)
            {
                case usrc_Invoice.eShopsMode.A:
                    Properties.Settings.Default.eShopsMode = "A";
                    break;
                case usrc_Invoice.eShopsMode.B:
                    Properties.Settings.Default.eShopsMode = "B";
                    break;
                case usrc_Invoice.eShopsMode.C:
                    Properties.Settings.Default.eShopsMode = "C";
                    break;
                case usrc_Invoice.eShopsMode.AB:
                    Properties.Settings.Default.eShopsMode = "AB";
                    break;
                case usrc_Invoice.eShopsMode.BC:
                    Properties.Settings.Default.eShopsMode = "BC";
                    break;
                case usrc_Invoice.eShopsMode.AC:
                    Properties.Settings.Default.eShopsMode = "AC";
                    break;
                case usrc_Invoice.eShopsMode.ABC:
                    Properties.Settings.Default.eShopsMode = "ABC";
                    break;
                default:
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_Invoice.m_eShopsMode illegal Mode!");
                    return;
                    break;
            }
            Properties.Settings.Default.Save();

        }

        internal void Set_eShopsMode(string eShopsMode)
        {
            if (Properties.Settings.Default.eShopsInUse.Length == 1)
            {
                eShopsMode = Properties.Settings.Default.eShopsInUse;
                this.btn_Show_Shops.Visible = false;
            }
            else
            {
                this.btn_Show_Shops.Visible = true;
            }

            if (Properties.Settings.Default.eShopsInUse.Length == 2)
            {
                if (!Properties.Settings.Default.eShopsInUse.Contains(eShopsMode))
                {
                    eShopsMode = Properties.Settings.Default.eShopsInUse;
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
            if (m_usrc_ShopA == null)
            {
                New_ShopA();
            }
            if (m_usrc_ShopC == null)
            {
                New_ShopC();
            }

            if (eShopsMode.Equals("A"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.A);
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsMode.Equals("B"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.B);
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsMode.Equals("C"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.C);
                //this.btn_Show_Shops.Visible = false;
            }
            else if (eShopsMode.Equals("AB"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.AB);
            }
            else if (eShopsMode.Equals("BC"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.BC);
            }
            else if (eShopsMode.Equals("AC"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.AC);
            }
            else if (eShopsMode.Equals("ABC"))
            {
                Set_eShopsMode(usrc_Invoice.eShopsMode.ABC);
            }
        }

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
                    case enum_Invoice.Invoice_From_DocInvoice:
                        m_InvoiceTypeName = "Invoice_From_DocInvoice";
                        break;
                    case enum_Invoice.DocInvoice:
                        m_InvoiceTypeName = "DocInvoice";
                        break;
                }
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

        public long PriceList_ShopB_ID
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
                        return -1;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                        return -1;
                    }
                }
            }
        }

        public long PriceList_ShopC_ID
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
                        return -1;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:public long PriceList_ID:this.usrc_PriceList==null");
                        return -1;
                    }
                }
            }
        }

        public usrc_Invoice()
        {
            InitializeComponent();
            m_mode = emode.view_eInvoiceType;
            lngRPM.s_Show_Shops.Text(btn_Show_Shops);
            lngRPM.s_Issuer.Text(lbl_MyOrganisation);
            lngRPM.s_Number.Text(lbl_Number);
            lngRPM.s_Currency.Text(lbl_Currency);
            //btn_BuyerSelect.Text = lngRPM.s_BuyerSelect.s;
            lngRPM.s_Issue.Text(btn_Issue);
            lngRPM.s_chk_Storno.Text(chk_Storno);

            lngRPM.s_Shop_AB = new ltext(lngRPM.s_Shop_A.sText(0) + " && " + lngRPM.s_Shop_B.sText(0), lngRPM.s_Shop_A.sText(1) + " && " + lngRPM.s_Shop_B.sText(1));
            lngRPM.s_Shop_BC = new ltext(lngRPM.s_Shop_B.sText(0) + " && " + lngRPM.s_Shop_C.sText(0), lngRPM.s_Shop_B.sText(1) + " && " + lngRPM.s_Shop_C.sText(1));
            lngRPM.s_Shop_AC = new ltext(lngRPM.s_Shop_A.sText(0) + " && " + lngRPM.s_Shop_C.sText(0), lngRPM.s_Shop_A.sText(1) + " && " + lngRPM.s_Shop_C.sText(1));
            lngRPM.s_Shop_ABC = new ltext(lngRPM.s_Shop_A.sText(0) + " && " + lngRPM.s_Shop_B.sText(0) + " && " + lngRPM.s_Shop_C.sText(0), lngRPM.s_Shop_A.sText(1) + " && " + lngRPM.s_Shop_B.sText(1) + " && " + lngRPM.s_Shop_C.sText(1));

            lngRPM.s_MyOrganisation.Text(lbl_MyOrganisation);
            lngRPM.s_Total.Text(this.lbl_Sum);
            //SetMode(m_mode);


  


        }

        internal void SetMode(emode mode)
        {
            m_mode = mode;
            if (mode == emode.edit_eInvoiceType)
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

        private bool EditMyOrganisation_Person_Data(int Index)
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            if (Index < myOrg.myOrg_Office_list.Count)
            {
                Form_myOrg_Person_Edit edt_my_company_person_dlg = new Form_myOrg_Person_Edit(myOrg.myOrg_Office_list[Index].ID_v.v);
                dres = edt_my_company_person_dlg.ShowDialog();

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
            else
            {
                return false;
            }
        }

        private bool Edit_myOrg_Office()
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office frm_office = new Form_myOrg_Office();
            dres = frm_office.ShowDialog(this);
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

        private bool Edit_myOrg_Office_Data()
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data frm_office_data = new Form_myOrg_Office_Data(myOrg.myOrg_Office_list[0].ID_v.v);
            dres = frm_office_data.ShowDialog(this);
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

        private bool Edit_myOrg_Office_Data_FVI_SLO_RealEstateBP()
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data_FVI_SLO_RealEstateBP frm_office_data_FVI_SLO_RealEstateBP = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID_v.v);
            dres = frm_office_data_FVI_SLO_RealEstateBP.ShowDialog(this);
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

        private bool EditMyOrganisation_Data(bool bAllowNew)
        {
            DialogResult dres = DialogResult.Ignore;
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Edit edt_my_company_dlg = new Form_myOrg_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation))), bAllowNew);
            dres = edt_my_company_dlg.ShowDialog(this);

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
            if (m_ShopABC == null)
            {
                m_ShopABC = new ShopABC(DBtcn);
            }

            Set_eShopsMode(Properties.Settings.Default.eShopsMode);


            string Err = null;
            if (Get_BaseCurrency(ref Err))
            {
                if (GetTaxation())
                {
                    GetUnits();
                    int iCountSimpleItemData = 0;
                    int iCountItemData = 0;

                    if (GetSimpleItemData(ref iCountSimpleItemData))
                    {
                        if (GetItemData(ref iCountItemData))
                        {
                            if ((iCountSimpleItemData + iCountItemData > 0) || (Program.Shops_in_use.Equals("A")))
                            {

                                DataTable dt_ShopB_Item_NotIn_PriceList = new DataTable();
                                //if (Program.Shops_in_use.Contains("B"))
                                //{
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
                                                        this.m_usrc_ShopB.usrc_PriceList1.PriceList_Edit(true);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bool bEdit = false;
                                                f_PriceList.CheckPriceUndefined_ShopB(ref bEdit);
                                                if (bEdit)
                                                {
                                                    this.m_usrc_ShopB.usrc_PriceList1.PriceList_Edit(true);

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
                                //}

                                //if (Program.Shops_in_use.Contains("C"))
                                //{
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
                                                        this.m_usrc_ShopC.usrc_PriceList1.PriceList_Edit(true);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                bool bEdit = false;
                                                f_PriceList.CheckPriceUndefined_ShopC(ref bEdit);
                                                if (bEdit)
                                                {
                                                    this.m_usrc_ShopC.usrc_PriceList1.PriceList_Edit(true);
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
                                //}
                                //return true;
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
                if (m_ShopABC.m_CurrentInvoice.bDraft)
                {
                    this.m_usrc_ShopB.SetDraftButtons();
                }
                else
                {
                    this.m_usrc_ShopB.SetViewButtons();
                }
                this.usrc_Customer.Show_Customer(m_ShopABC.m_CurrentInvoice);
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
                lngRPM.s_Head.Text(chk_Head);
                chk_Head.Checked = Properties.Settings.Default.InvoiceHeaderChecked;
                chk_Head.CheckedChanged += chk_Head_CheckedChanged;

                 splitContainer2.Panel1Collapsed = !chk_Head.Checked;

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

            Properties.Settings.Default.InvoiceHeaderChecked = chk_Head.Checked;
            Properties.Settings.Default.Save();
        }

        private bool DoGetCurrent(long ID)
        {
            if (GetCurrent(ID))
            {
                GetPriceSum();
                if (m_ShopABC.m_CurrentInvoice.bDraft)
                {
                    AddHandler();
                }
                else
                {
                    if (m_ShopABC.m_CurrentInvoice.Exist)
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


        private bool GetReceiptPrinter()
        {
            if (Program.usrc_Printer1.Printer == null)
            {
                Program.usrc_Printer1.Printer = new Printer();
            }
            Program.usrc_Printer1.Printer.Define(null);
            return true;
        }

        private bool Edit_Taxation()
        {
            SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
            Form_Taxation_Edit tax_dlg = new Form_Taxation_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Taxation, "ID asc");
            if (tax_dlg.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Edit_Units()
        {
            SQLTable tbl_Unit = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Unit)));
            Form_Unit_Edit unit_dlg = new Form_Unit_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Unit, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private bool GetTaxation()
        {
            if (m_ShopABC.m_xTaxationList == null)
            {
                m_ShopABC.m_xTaxationList = new xTaxationList();
            }
            string Err = null;
            DataTable dt = new DataTable();
            if (m_ShopABC.m_xTaxationList.Get(ref dt, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    dt.Clear();
                    if (Edit_Taxation())
                    {
                        if (m_ShopABC.m_xTaxationList.Get(ref dt, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:GetTaxation:m_xTaxationList.Get:Err=" + Err);
                return false;
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
                //if (dt.Rows.Count > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    dt.Clear();
                //    if (Edit_Units())
                //    {
                //        if (m_ShopABC.m_xTaxationList.Get(ref dt, ref Err))
                //        {
                //            if (dt.Rows.Count > 0)
                //            {
                //                return true;
                //            }
                //        }
                //    }
                //    return false;
                //}
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
            if (m_usrc_ShopB.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopB,Program.Shops_in_use, ref Err))
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
            if (m_usrc_ShopC.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, PriseLists.usrc_PriceList_Edit.eShopType.ShopC, Program.Shops_in_use, ref Err))
            {

            }
            else
            {
                bGet = false;
            }
            return bGet;
        }


        internal bool GetSimpleItemData(ref int iCountSimpleItemData)
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
                        if (MessageBox.Show(this, lngRPM.s_NoSimpleItemData_EnterSimpleItemDataQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            this.m_usrc_ShopB.EditShopBItem();
                            if (this.m_usrc_ShopB.GetShopBItemData(ref iCountSimpleItemData))
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
            if (this.m_usrc_ShopB.Get_Price_ShopBItem_Data(ref iCount_Price_SimpleItem_Data, PriceList_id))
            {
                if (iCount_Price_SimpleItem_Data > 0)
                {
                    return true;
                }
                else
                {
                    if (Program.Shops_in_use.Contains("C"))
                    {
                        MessageBox.Show(this, lngRPM.s_No_Price_SimpleItem_Data.s);
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
        internal bool GetItemData(ref int iCountItemData)
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
                        if (MessageBox.Show(this, lngRPM.s_NoItemData_EnterItemDataQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            this.m_usrc_ShopC.EditItem();
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



        internal bool GetOrganisationData(usrc_Main x_usrc_Main )
        {
            string sAddress = null;
            for (;;)
            {
                if (myOrg.Get(1))
                {
                    if (myOrg.Name_v == null)
                    {
                        // DataBase is empty No Organisation Data First select Shops In use !
                        Form_ShopsInUse frm_shops_in_use = new Form_ShopsInUse(x_usrc_Main);
                        frm_shops_in_use.ShowDialog(x_usrc_Main);



                        MessageBox.Show(lngRPM.s_No_OrganisationData.s);
                        if (EditMyOrganisation_Data(true))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (myOrg.Tax_ID_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_Tax_ID.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (myOrg.Address_v.StreetName_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_StreetName.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (myOrg.Address_v.HouseNumber_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_HouseNumber.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (myOrg.Address_v.ZIP_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_ZIP.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (myOrg.Address_v.City_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_City.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (myOrg.Address_v.Country_v == null)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_Country.s);
                        if (EditMyOrganisation_Data(false))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    f_Currency.Get(myOrg.Address_v.Country_ISO_3166_a3);
                    f_Taxation.Get(myOrg.Address_v.Country_ISO_3166_a3);

                    if (myOrg.myOrg_Office_list.Count > 0)
                    {
                        if (myOrg.myOrg_Office_list[0].Office_Data_ID_v == null)
                        {
                            MessageBox.Show(lngRPM.s_No_Office_Data.s);
                            if (Edit_myOrg_Office_Data())
                            {
                                continue;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            string Err = null;
                            if (myOrg.Address_v.Country_ISO_3166_a3.Equals("SLO"))
                            {
                                Program.b_FVI_SLO = true;
                            }
                            else
                            {
                                Program.b_FVI_SLO = false;
                            }

                            if (fs.Is_Sample_DB(ref Err))
                            {
                                if (Program.b_FVI_SLO)
                                {
                                    if (myOrg.myOrg_Office_list[0].myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v == null)
                                    {

                                    }
                                }
                            }
                            if (Program.b_FVI_SLO)
                            {
                                if (myOrg.myOrg_Office_list[0].myOrg_Office_FVI_SLO_RealEstate.BuildingNumber_v == null)
                                {
                                    MessageBox.Show(lngRPM.s_No_Office_Data_FVI_SLO_RealEstateBP.s);
                                    if (Edit_myOrg_Office_Data_FVI_SLO_RealEstateBP())
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
                    else
                    {
                        MessageBox.Show(lngRPM.s_No_Office.s);
                        if (Edit_myOrg_Office())
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }


                    if (myOrg.myOrg_Person_list.Count== 0)
                    {
                        MessageBox.Show(lngRPM.s_No_MyOrganisation_Person.s);
                        if (EditMyOrganisation_Person_Data(0))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    string sPhoneNumber = "";
                    string sEmail = "";
                    string sHomePage = "";
                    string sRegistration_ID = "";
                    if (myOrg.PhoneNumber_v!=null)
                    {
                        sPhoneNumber = myOrg.PhoneNumber_v.vs;
                    }
                    if (myOrg.Email_v != null)
                    {
                        sEmail = myOrg.Email_v.vs;
                    }
                    if (myOrg.HomePage_v != null)
                    {
                        sHomePage = myOrg.HomePage_v.vs;
                    }
                    if (myOrg.Registration_ID_v != null)
                    {
                        sRegistration_ID = myOrg.Registration_ID_v.vs;
                    }

                    this.txt_MyOrganisation.Text = myOrg.Name_v.vs + "," + sAddress
                        + "\r\nDavčna Številka:" + myOrg.Tax_ID_v.vs
                        + "\r\nMatična Številka:" + sRegistration_ID
                        + "\r\nTelefon:" + sPhoneNumber
                        + "\r\nEmail:" + sEmail
                        + "\r\nDomača stran:" + sHomePage;
                     Fill_MyOrganisation_Person();
                     return true;
                }
            }
        }

        private bool GetCurrent(long ID)
        {
            switch (eInvoiceType)
            {
                case enum_Invoice.Invoice:
                    return GetCurrentInvoice(ID);


                case enum_Invoice.DocInvoice:
                    return GetDocInvoiceDraft();
                case enum_Invoice.Invoice_From_DocInvoice:
                    return SelectDocInvoice();
            }
            return false;

        }


        private bool GetCurrentInvoice(long DocInvoice_ID)
        {
        string Err = null;
        //
        if (m_ShopABC.Get(true, DocInvoice_ID, ref Err)) // try to get draft
        {
                this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.m_CurrentInvoice.bDraft, m_ShopABC.m_CurrentInvoice.FinancialYear, m_ShopABC.m_CurrentInvoice.NumberInFinancialYear, m_ShopABC.m_CurrentInvoice.DraftNumber);
                if (m_ShopABC.m_CurrentInvoice.bDraft)
                {
                    SetMode(emode.edit_eInvoiceType);
                    this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                }
                else
                {
                    SetMode(emode.view_eInvoiceType);
                    this.m_usrc_ShopB.SetCurrentInvoice_SelectedShopB_Items();
                    this.m_usrc_ShopC.SetCurrentInvoice_SelectedItems();
                    chk_Storno_CanBe_ManualyChanged = false;
                    if (m_ShopABC.m_CurrentInvoice.bStorno_v != null)
                    { 
                        this.chk_Storno.Checked = m_ShopABC.m_CurrentInvoice.bStorno_v.v;
                    }
                    else
                    {
                        this.chk_Storno.Checked = false;
                    }
                    chk_Storno_CanBe_ManualyChanged = true;
                }
                this.m_usrc_ShopC.Reset();
                return true;
            }
            else
            {
                SetMode(emode.view_eInvoiceType);
                if (m_ShopABC.Get(false, DocInvoice_ID, ref Err)) // Get invoice with Invoice_ID
                {
                    this.txt_Number.Text = Program.GetInvoiceNumber(m_ShopABC.m_CurrentInvoice.bDraft, m_ShopABC.m_CurrentInvoice.FinancialYear, m_ShopABC.m_CurrentInvoice.NumberInFinancialYear, m_ShopABC.m_CurrentInvoice.DraftNumber);
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

        private void SetDraft_SelectedSimpleItems()
        {

        }

        private bool GetDocInvoiceDraft()
        {
            throw new NotImplementedException();
        }

        private bool SelectDocInvoice()
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

                    if (GlobalData.BaseCurrency == null)
                    {
                        GlobalData.BaseCurrency = new xCurrency();
                    }
                    if (GlobalData.BaseCurrency.SetCurrency(currency_id, ref Err))
                    {
                        this.txt_Currency.Text = GlobalData.BaseCurrency.Abbreviation + " " + GlobalData.BaseCurrency.Symbol;
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
            if (GlobalData.BaseCurrency == null)
            {
                GlobalData.BaseCurrency = new xCurrency();
            }
            Form_Select_DefaultCurrency sel_basecurrency_dlg = new Form_Select_DefaultCurrency(ref GlobalData.BaseCurrency);
            if (sel_basecurrency_dlg.ShowDialog() == DialogResult.OK)
            {
                string sql_SetBaseCurrency = "Insert into BaseCurrency (Currency_ID) Values (" + sel_basecurrency_dlg.Currency_ID.ToString() + ")";
                object oRes = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_SetBaseCurrency, null, ref oRes, ref Err))
                {
                    this.txt_Currency.Text = GlobalData.BaseCurrency.Abbreviation + " " + GlobalData.BaseCurrency.Symbol;
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


        internal void Fill_MyOrganisation_Person()
        {
            DataTable dtEmployees = new DataTable();
            string sql_my_company_person = @"Select ID,
                                            myOrganisation_Person_$_office_$_mo_$$ID,
                                            myOrganisation_Person_$_per_$_cfn_$$FirstName,
                                            myOrganisation_Person_$_per_$_cln_$$LastName,
                                            myOrganisation_Person_$$Job,
                                            myOrganisation_Person_$$UserName,
                                            myOrganisation_Person_$$Password,
                                            myOrganisation_Person_$$Description,
                                            myOrganisation_Person_$$Active
                                            from myOrganisation_Person_VIEW
                                            where myOrganisation_Person_$_office_$_mo_$$ID = " + Last_myOrganisation_id.ToString()
                                              + " and myOrganisation_Person_$$Active = 1";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtEmployees, sql_my_company_person, ref Err))
            {
                if (dtEmployees.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmployees.Rows)
                    {
                        Employee employee = new Employee((string)dr["myOrganisation_Person_$_per_$_cfn_$$FirstName"],
                                                         (string)dr["myOrganisation_Person_$_per_$_cln_$$LastName"],
                                                            dr["myOrganisation_Person_$$Job"],
                                                            dr["myOrganisation_Person_$$UserName"],
                                                            dr["myOrganisation_Person_$$Password"],
                                                            dr["myOrganisation_Person_$$Description"],
                                                          (bool)dr["myOrganisation_Person_$$Active"],
                                                          (long)dr["ID"],
                                                          (long)dr["myOrganisation_Person_$_office_$_mo_$$ID"]
                                                          );
                        Employees.Add(employee);
                    }
                    this.cmb_select_my_Organisation_Person.DataSource = Employees;
                    this.cmb_select_my_Organisation_Person.DisplayMember = "Person";
                    this.cmb_select_my_Organisation_Person.ValueMember = "myOrganisation_Person_ID";
                    this.cmb_select_my_Organisation_Person.SelectedItem = Last_myOrganisation_Person_id;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice:Fill_MyOrganisation_Person:Err=" + Err);
            }
        }







        private void btn_Preview_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_MyOrganisation_Click(object sender, EventArgs e)
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
                    if (m_ShopABC == null)
                    {
                        m_ShopABC = new ShopABC(DBtcn);
                    }
                    if (SetNewInvoiceDraft(FinancialYear))
                    {
                        SetMode(emode.edit_eInvoiceType);
                    }
                    return;

                case enum_Invoice.DocInvoice:
                    return;

                case enum_Invoice.Invoice_From_DocInvoice:
                    return;
            }
            return;

        }

        private bool SetNewInvoiceDraft(int FinancialYear)
        {
            long DocInvoice_ID = -1;
            string Err = null;
            if (m_ShopABC.SetNewDraft_DocInvoice(FinancialYear, this, ref DocInvoice_ID, Last_myOrganisation_Person_id, ref Err))
            {
                if (m_ShopABC.m_CurrentInvoice.DocInvoice_ID >= 0)
                {
                    this.txt_Number.Text = m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "/" + m_ShopABC.m_CurrentInvoice.DraftNumber.ToString();
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

        private void btn_edit_MyOrganisation_Click_1(object sender, EventArgs e)
        {
            EditMyOrganisation_Person_Data(0);
            myOrg.Get(1);
            if (Last_myOrganisation_Person_id >= 0)
            {
                long Atom_myOrganisation_Person_ID = -1;
                string_v office_name = null;
               // string Err = null;
                f_Atom_myOrganisation_Person.Get(Last_myOrganisation_Person_id, ref Atom_myOrganisation_Person_ID, ref office_name);
            }
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

            foreach (DataRow dr in this.m_usrc_ShopA.dt_Item_Price.Rows)
            {
                decimal price = (decimal)dr["DocInvoice_ShopA_Item_$$EndPriceWithDiscountAndTax"];
                decimal tax = (decimal)dr["DocInvoice_ShopA_Item_$$TAX"];
                decimal tax_rate = (decimal)dr["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Rate"];
                string tax_name = (string)dr["DocInvoice_ShopA_Item_$_aisha_$_tax_$$Name"];
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

            m_ShopABC.m_CurrentInvoice.m_Basket.GetPriceSum(ref dsum_GrossSum_Basket, ref dsum_TaxSum_Basket, ref dsum_NetSum_Basket, ref TaxSum);

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
            string sGrossSum = "";
            if (m_ShopABC.m_CurrentInvoice.StornoDocInvoice_ID_v == null)
            {
                sGrossSum  = dsum_GrossSum.ToString();
                this.lbl_Sum.ForeColor = Color.Black;
            }
            else
            {
                sGrossSum = "-"+dsum_GrossSum.ToString();
                this.lbl_Sum.ForeColor = Color.Red;
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

        void usrc_ShopB_ItemUpdated(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_ShopB_ExtraDiscount(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_ShopB_ItemRemoved(long ID, DataTable dt_SelectedSimpleItem)
        {
            GetPriceSum();
        }

        void usrc_ShopB_ItemAdded(long ID, DataTable dt_SelectedSimpleItem)
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

            string sql_SetPrice = "update docinvoice set GrossSum = " + spar_GrossSum + ",TaxSum = " + spar_TaxSum + ",NetSum = " + spar_NetSum + " where ID = " + m_ShopABC.m_CurrentInvoice.DocInvoice_ID.ToString();
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
            if (m_ShopABC != null)
            {
                if (m_ShopABC.m_CurrentInvoice != null)
                {
                    long myOrganisation_Person_id = -1;
                    object o_myOrganisation_Person_id = cmb_select_my_Organisation_Person.SelectedItem;
                    if (o_myOrganisation_Person_id is Tangenta.Employee)
                    {
                        Tangenta.Employee employe = (Tangenta.Employee)o_myOrganisation_Person_id;
                        myOrganisation_Person_id = employe.myOrganisation_Person_ID;
                    }

                    if (m_ShopABC.m_CurrentInvoice.Exist)
                    {
                        if (m_ShopABC.m_CurrentInvoice.bDraft)
                        {

                            // print draft invoice
                            if (UpdateInvoicePriceInDraft())
                            {
                                m_InvoiceData = new InvoiceData(m_ShopABC, m_ShopABC.m_CurrentInvoice.DocInvoice_ID, Program.b_FVI_SLO,Properties.Settings.Default.ElectronicDevice_ID);
                                if (m_InvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                                {
                                    if (m_InvoiceData.FURS_QR_v != null)
                                    {
                                        m_InvoiceData.FURS_Image_QRcode = Program.usrc_FVI_SLO1.GetQRImage(m_InvoiceData.FURS_QR_v.v);
                                        m_InvoiceData.Set_Invoice_Furs_Token();

                                    }

                                    Form_Payment payment_frm = new Form_Payment(m_InvoiceData);
                                    if (payment_frm.ShowDialog() == DialogResult.OK)
                                    {
                                        if (aa_DocInvoiceSaved != null)
                                        {
                                            aa_DocInvoiceSaved(m_ShopABC.m_CurrentInvoice.DocInvoice_ID);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            m_InvoiceData = new InvoiceData(m_ShopABC, m_ShopABC.m_CurrentInvoice.DocInvoice_ID, Program.b_FVI_SLO, Properties.Settings.Default.ElectronicDevice_ID);
                            if (m_InvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                            { // print invoice if you wish
                                if (m_InvoiceData.FURS_QR_v != null)
                                {
                                    m_InvoiceData.FURS_Image_QRcode = Program.usrc_FVI_SLO1.GetQRImage(m_InvoiceData.FURS_QR_v.v);
                                    m_InvoiceData.Set_Invoice_Furs_Token();
                                }
                                Form_PrintExistingInvoice frm_Print_Existing_invoice = new Form_PrintExistingInvoice(m_InvoiceData);
                                frm_Print_Existing_invoice.ShowDialog(this);
                            }
                        }
                    }
                }
            }
        }



        private void usrc_Customer_Load(object sender, EventArgs e)
        {

        }




        private void usrc_Customer_Customer_Person_Changed(long Customer_Person_ID)
        {
            long_v Atom_Customer_Person_ID_v = null;
            this.Cursor = Cursors.WaitCursor;
            if (m_ShopABC.m_CurrentInvoice.Update_Customer_Person(Customer_Person_ID, ref Atom_Customer_Person_ID_v))
            {
                if (Atom_Customer_Person_ID_v != null)
                {
                    usrc_Customer.Show_Customer_Person(m_ShopABC.m_CurrentInvoice);
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
                if (m_ShopABC.m_CurrentInvoice.bStorno_v!= null)
                {
                    bstorno = m_ShopABC.m_CurrentInvoice.bStorno_v.v;
                }
                
                if (chk_Storno.Checked!=bstorno)
                {
                    if (chk_Storno.Checked)
                    {
                        if (MessageBox.Show(this, lngRPM.s_Invoice.s + ": " + txt_Number.Text + "\r\n" + lngRPM.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Form_Storno frm_storno_dlg = new Form_Storno(m_ShopABC.m_CurrentInvoice.DocInvoice_ID);

                            if (frm_storno_dlg.ShowDialog()==DialogResult.Yes)
                            {
                                stornoReferenceInvoiceNumber = m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString();
                                stornoReferenceInvoiceIssueDateTime = frm_storno_dlg.m_InvoiceTime;
                                string sInvoiceToStorno = frm_storno_dlg.m_sInvoiceToStorno;
                                if (MessageBox.Show(this,sInvoiceToStorno + "\r\n" + lngRPM.s_AreYouSureToStornoThisInvoice.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
    
                                    long Storno_DocInvoice_ID = -1;
                                    DateTime stornoInvoiceIssueDateTime = new DateTime();
                                    if (m_ShopABC.m_CurrentInvoice.Storno(ref Storno_DocInvoice_ID,true, frm_storno_dlg.m_Reason,ref stornoInvoiceIssueDateTime))
                                    {
                                        if (Storno != null)
                                        {
                                            Storno(true);
                                        }
                                    }

                                    if (Program.b_FVI_SLO)
                                    {
                                        InvoiceData xInvoiceData = new InvoiceData(m_ShopABC, Storno_DocInvoice_ID, Program.b_FVI_SLO, Properties.Settings.Default.ElectronicDevice_ID);
                                        if (xInvoiceData.Read_DocInvoice()) // read Proforma Invoice again from DataBase
                                        {

                                            string furs_XML = xInvoiceData.Create_furs_InvoiceXML(true,Properties.Resources.FVI_SLO_Invoice, Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID, Properties.Settings.Default.ElectronicDevice_ID, Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID, stornoReferenceInvoiceNumber, stornoReferenceInvoiceIssueDateTime);
                                            string furs_UniqeMsgID = null;
                                            string furs_UniqeInvID = null;
                                            string furs_BarCodeValue = null;
                                            Image img_QR = null;
                                            if (Program.usrc_FVI_SLO1.Send_SingleInvoice(false,furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                                            {
                                                xInvoiceData.FURS_ZOI_v = new string_v(furs_UniqeMsgID);  
                                                xInvoiceData.FURS_EOR_v = new string_v(furs_UniqeInvID);
                                                xInvoiceData.FURS_QR_v = new string_v(furs_BarCodeValue);
                                                xInvoiceData.Write_FURS_Response_Data();
                                            }
                                            else
                                            {
                                                string xSerialNumber = null;
                                                string xSetNumber = null;
                                                string xInvoiceNumber = null;
                                                Program.usrc_FVI_SLO1.Write_SalesBookInvoice(xInvoiceData.DocInvoice_ID_v.v, xInvoiceData.FinancialYear, xInvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                                                long FVI_SLO_SalesBookInvoice_ID = -1;
                                                if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(xInvoiceData.DocInvoice_ID_v.v, xSerialNumber, xSetNumber, xInvoiceNumber, ref FVI_SLO_SalesBookInvoice_ID))
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
                        MessageBox.Show(this, lngRPM.s_YouCanNotCnacelInvoiceStorno.s);
                        chk_Storno_CanBe_ManualyChanged = false;
                        chk_Storno.Checked = true;
                        chk_Storno_CanBe_ManualyChanged = true;
                    }
                }
            }
        }


        public long myOrganisation_Person_ID { get; set; }


        private void usrc_Customer_Customer_Org_Changed(long Customer_Org_ID)
        {
            this.Cursor = Cursors.WaitCursor;
            long_v Atom_Customer_Org_ID_v = null;
            if (m_ShopABC.m_CurrentInvoice.Update_Customer_Org(Customer_Org_ID, ref Atom_Customer_Org_ID_v))
            {
                m_ShopABC.m_CurrentInvoice.Atom_Customer_Org_ID_v = Atom_Customer_Org_ID_v;
                if (Atom_Customer_Org_ID_v != null)
                {
                    usrc_Customer.Show_Customer_Org(m_ShopABC.m_CurrentInvoice);
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
            if (m_ShopABC.m_CurrentInvoice.Update_Customer_Remove())
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
            Form_ShowShops frm_sel_shops = new Form_ShowShops(this);
            frm_sel_shops.ShowDialog(this);
        }

        private void btn_MyOrganisation_Click(object sender, EventArgs e)
        {
            EditMyOrganisation_Data(false);
        }


    }
}
