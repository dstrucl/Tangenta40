﻿#region LICENSE 
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
using System.Windows.Forms;
using DBTypes;
using LanguageControl;
using XMessage;
using TangentaDB;
using DBConnectionControl40;
using usrc_Item_InsidePage_Handler;

namespace ShopC
{
    public partial class usrc_Atom_ItemsList1366x768 : UserControl
    {
        public ID m_Atom_WorkPeriod_ID = null;

        public usrc_Atom_Item1366x768[] usrc_Atom_Item_array = null;

        public int yPosLast = 5;

        private usrc_ItemList1366x768 m_usrc_ItemList1366x768 = null;


        public TangentaDB.ShopABC m_ShopBC;
        private DBTablesAndColumnNames DBtcn;

        public delegate void delegate_After_Atom_Item_Remove();
        public event delegate_After_Atom_Item_Remove After_Atom_Item_Remove = null;

        public delegate void delegate_SelectionChanged(Control ctrl,
                                                      int index, 
                                                      object odata,
                                                      object oItemData,
                                                      Control ctrl_item_data
                                                      );

        public event delegate_SelectionChanged SelectionChanged = null;


        public long Item_ID = -1;

        private string m_DocTyp = "";

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

        public int m_NumberOfItemsPerPage = 10;


        public int NumberOfItemsPerPage
        {
            get { return m_NumberOfItemsPerPage; }
            set
            {
                m_NumberOfItemsPerPage = value;
                Init(m_Atom_WorkPeriod_ID);
            }
        }
        private void Init(ID xAtom_WorkPeriod_ID)
        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
        }

        public usrc_Atom_ItemsList1366x768()
        {
            InitializeComponent();
            this.usrc_Item_InsidePageHandler_ItemAtomList.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectionChanged += Usrc_Item_InsidePageHandler1_SelectionChanged;
            this.usrc_Item_InsidePageHandler_ItemAtomList.Paint += Usrc_Item_InsidePageHandler1_Paint;
            this.usrc_Item_InsidePageHandler_ItemAtomList.CompareWithString += Usrc_Item_InsidePageHandler_ItemAtomList_CompareWithString;
        }

        private bool Usrc_Item_InsidePageHandler_ItemAtomList_CompareWithString(object oData, string s)
        {
            if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                if (appisd!=null)
                {
                    if (appisd.Atom_Item_UniqueName != null)
                    {
                        return appisd.Atom_Item_UniqueName.v.Equals(s);
                    }
                }
            }
            return false;
        }

        private void Usrc_Item_InsidePageHandler1_Paint(Control ctrl, object oData, int index, usrc_Item_InsidePageHandler.eMode xmode)
        {
            if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                if (ctrl is usrc_Atom_Item1366x768)
                {
                    usrc_Atom_Item1366x768 xusrc_Atom_Item1366x768 = (usrc_Atom_Item1366x768)ctrl;
                    xusrc_Atom_Item1366x768.DoPaint(appisd, xmode);
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            object oidata = null;
            Control oxusrc_Item1366x768 = null;
            if (ctrl != null)
            {
                if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                    if (this.Parent is usrc_ShopC1366x768)
                    {
                        ((usrc_ShopC1366x768)this.Parent).m_usrc_ItemList1366x768.Select(appisd, appisd.Atom_Item_UniqueName.v, ref oidata,ref oxusrc_Item1366x768);
                        if (SelectionChanged!=null)
                        {
                            SelectionChanged(ctrl,index, oData,oidata, oxusrc_Item1366x768);
                        }
                    }
                }
            }
            else
            {
                if (index == -1)
                {
                    // this is deselection 
                   if (SelectionChanged != null)
                   {
                        SelectionChanged(ctrl,index, oData, oidata, oxusrc_Item1366x768);
                   }
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (ctrl is usrc_Atom_Item1366x768)
            {
                usrc_Atom_Item1366x768 xusrc_Atom_Item1366x768 = (usrc_Atom_Item1366x768)ctrl;
                xusrc_Atom_Item1366x768.SelectControl(oData, selected);

                if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler.eMode emode)
        {
            if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                if (ctrl is usrc_Atom_Item1366x768)
                {
                    usrc_Atom_Item1366x768 xusrc_Atom_Item1366x768 = (usrc_Atom_Item1366x768)ctrl;
                    xusrc_Atom_Item1366x768.DoPaint(appisd, emode);
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            usrc_Atom_Item1366x768 xusrc_Atom_Item1366x768 = new usrc_Atom_Item1366x768();
            xusrc_Atom_Item1366x768.btn_RemoveClick += Xusrc_Atom_Item1366x768_btn_RemoveClick;
            ctrl = xusrc_Atom_Item1366x768;
        }

        public void RemoveItem(string sItemUniqueName, ref decimal dQuantityInBasket_FromStock,ref decimal dQuantityInBasket_FromFactory)
        {
            int index = usrc_Item_InsidePageHandler_ItemAtomList.FindItem(sItemUniqueName);
            if (index>=0)
            {
                object oData = usrc_Item_InsidePageHandler_ItemAtomList.GetItem(index);
                if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                    dQuantityInBasket_FromStock = appisd.dQuantity_FromStock;
                    dQuantityInBasket_FromFactory = appisd.dQuantity_FromFactory;
                    RemoveItem(appisd);
                }
            }
        }

        public void RemoveItem(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            if (appisd.dQuantity_FromFactory > 0)
            {
                this.m_ShopBC.m_CurrentDoc.m_Basket.RemoveFactory(DocTyp, appisd);
            }

            if (appisd.dQuantity_FromStock > 0)
            {
                this.m_ShopBC.m_CurrentDoc.m_Basket.Remove_and_put_back_to_ShopShelf(m_Atom_WorkPeriod_ID, DocTyp, appisd, this.m_ShopBC.m_CurrentDoc.m_ShopShelf);
            }

            if ((appisd.dQuantity_FromFactory == 0)&&(appisd.dQuantity_FromStock==0))
            {
                // this is invalid case 
                this.m_ShopBC.m_CurrentDoc.m_Basket.RemoveAll(DocTyp, appisd);
            }
        }
    

        private void Xusrc_Atom_Item1366x768_btn_RemoveClick(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            RemoveItem(appisd);
            usrc_Item_InsidePageHandler_ItemAtomList.Init(this.m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(),usrc_Item_InsidePageHandler.eMode.EDIT);
            usrc_Item_InsidePageHandler_ItemAtomList.ShowPage(0);
            if (this.Parent is usrc_ShopC1366x768)
            {
                ((usrc_ShopC1366x768)this.Parent).m_usrc_ItemList1366x768.DoRepaint();
            }
            if (After_Atom_Item_Remove!=null)
            {
                After_Atom_Item_Remove();
            }
        }

        internal void Init(ID xAtom_WorkPeriod_ID,
                           usrc_ItemList1366x768 x_usrc_ItemList1366x768,
                           TangentaDB.ShopABC xm_InvoiceDB, 
                           DBTablesAndColumnNames xDBtcn)
        {
            m_usrc_ItemList1366x768 = x_usrc_ItemList1366x768;
            m_ShopBC=xm_InvoiceDB;
            DBtcn = xDBtcn;
            Init(xAtom_WorkPeriod_ID);
        }

        internal void ShowBasket(string xItemUniqueName,object oidata, Control oidata_control)
        {
            usrc_Item_InsidePageHandler.eMode emode = usrc_Item_InsidePageHandler.eMode.EDIT;
            if (!m_ShopBC.m_CurrentDoc.bDraft)
            {
                emode = usrc_Item_InsidePageHandler.eMode.VIEW;
            }
            this.usrc_Item_InsidePageHandler_ItemAtomList.Init(m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(), emode);
            object odata = null;
            Control ctrl = null;
            int index = this.usrc_Item_InsidePageHandler_ItemAtomList.FindItem(xItemUniqueName, ref odata, ref ctrl);
            if (index >= 0)
            {
                this.usrc_Item_InsidePageHandler_ItemAtomList.SelectObject(index,usrc_Item_InsidePageHandler.eSelection.ON_REMOTE);
                if (SelectionChanged != null)
                {
                    SelectionChanged(ctrl,index, odata, oidata, oidata_control);
                }
            }
            //this.usrc_Item_InsidePageHandler1.ShowPage(0);
        }

        internal void SetCurrentInvoice_SelectedItems()
        {
            usrc_Item_InsidePageHandler.eMode emode = usrc_Item_InsidePageHandler.eMode.EDIT;
            if (!m_ShopBC.m_CurrentDoc.bDraft)
            {
                emode = usrc_Item_InsidePageHandler.eMode.VIEW;
            }
            string sinfo = "";
            if (m_ShopBC.m_CurrentDoc.bDraft)
            {
                sinfo = myOrg.m_myOrg_Office.ShortName_v.v+"-"+ myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name+"-"+lng.s_Draft.s+":"+ m_ShopBC.m_CurrentDoc.DraftNumber.ToString()+"/"+ m_ShopBC.m_CurrentDoc.FinancialYear.ToString();
            }
            else
            {
                bool bstorno = false;
                if (m_ShopBC.m_CurrentDoc.TInvoice.bStorno_v!=null)
                {
                    bstorno = m_ShopBC.m_CurrentDoc.TInvoice.bStorno_v.v;
                }
                if (bstorno)
                {
                    sinfo = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(myOrg.m_myOrg_Office.ShortName_v.v,
                                                                                    myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name,
                                                                                    m_ShopBC.m_CurrentDoc.NumberInFinancialYear,
                                                                                    m_ShopBC.m_CurrentDoc.FinancialYear,
                                                                                    bstorno,
                                                                                    lng.s_StornoInvoice.s
                                                                                    );
                }
                else
                {
                    sinfo = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(myOrg.m_myOrg_Office.ShortName_v.v,
                                                                                    myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name,
                                                                                    m_ShopBC.m_CurrentDoc.NumberInFinancialYear,
                                                                                    m_ShopBC.m_CurrentDoc.FinancialYear,
                                                                                    false,
                                                                                    null
                                                                                    );
                }

            }

            if (m_ShopBC.IsDocInvoice)
            {

                lbl_InvoiceInfo.Text = lng.s_DocInvoice.s + ":" + sinfo;
            }
            this.usrc_Item_InsidePageHandler_ItemAtomList.Init(m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(), emode);
            this.usrc_Item_InsidePageHandler_ItemAtomList.ShowPage(0);
        }



        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            usrc_Atom_Item usrc_atom_item = (usrc_Atom_Item)o_usrc;
            if (bVisible)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o_data;
                usrc_atom_item.DoPaint(this.m_ShopBC,appisd);
                usrc_atom_item.Visible = true;
                usrc_atom_item.Enabled = true;
            }
            else
            {
                usrc_atom_item.Visible = false;
                usrc_atom_item.Enabled = false;
            }

        }


        internal void AddFromStock(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            //if (m_ShopBC.m_CurrentDoc.Add_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,true))
            //{
            //    int index = m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            //}
        }

        internal void AddFromFactory(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            //if (m_ShopBC.m_CurrentDoc.Add_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,false))
            //{
            //    int index = m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            //}
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (XMessage.Box.Show(this, lng.s_Are_Sure_To_Remove_All_From_Basket, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                m_ShopBC.m_CurrentDoc.m_Basket.Empty(m_Atom_WorkPeriod_ID,DocTyp, m_ShopBC.m_CurrentDoc.m_ShopShelf);
                this.Cursor = Cursors.Arrow;
                btn_ClearAll.Visible = false;
            }
        }

        internal void Clear()
        {
            
        }

        private void showTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pform = Global.f.GetParentForm(this);
            Form_ShopC_TableInspection.DoShow(pform, m_ShopBC);
        }
    }
}
