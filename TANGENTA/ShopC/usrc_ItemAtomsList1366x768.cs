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
            this.usrc_Item_InsidePageHandler1.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            this.usrc_Item_InsidePageHandler1.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            this.usrc_Item_InsidePageHandler1.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            this.usrc_Item_InsidePageHandler1.SelectionChanged += Usrc_Item_InsidePageHandler1_SelectionChanged;
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            if (oData is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oData;
                if (this.Parent is usrc_ShopC1366x768)
                {
                    ((usrc_ShopC1366x768)this.Parent).m_usrc_ItemList1366x768.Select(appisd);
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

        private void Xusrc_Atom_Item1366x768_btn_RemoveClick(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            if (appisd.dQuantity_FromFactory>0)
            {
                this.m_ShopBC.m_CurrentDoc.m_Basket.RemoveFactory(DocTyp, appisd);
            }
            else if (appisd.dQuantity_FromStock > 0)
            {
                this.m_ShopBC.m_CurrentDoc.m_Basket.Remove_and_put_back_to_ShopShelf(m_Atom_WorkPeriod_ID, DocTyp, appisd, this.m_ShopBC.m_CurrentDoc.m_ShopShelf);
            }
            usrc_Item_InsidePageHandler1.Init(this.m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(),usrc_Item_InsidePageHandler.eMode.EDIT);
            usrc_Item_InsidePageHandler1.ShowPage(0);
            if (this.Parent is usrc_ShopC1366x768)
            {
                ((usrc_ShopC1366x768)this.Parent).m_usrc_ItemList1366x768.DoRepaint();
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

        internal void ShowBasket(string xItemUniqueName)
        {
            usrc_Item_InsidePageHandler.eMode emode = usrc_Item_InsidePageHandler.eMode.EDIT;
            if (!m_ShopBC.m_CurrentDoc.bDraft)
            {
                emode = usrc_Item_InsidePageHandler.eMode.VIEW;
            }
            this.usrc_Item_InsidePageHandler1.Init(m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(), emode);
            int index = this.usrc_Item_InsidePageHandler1.FindItem(xItemUniqueName);
            if (index >= 0)
            {
                this.usrc_Item_InsidePageHandler1.SelectObject(index);
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
            this.usrc_Item_InsidePageHandler1.Init(m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Cast<Atom_DocInvoice_ShopC_Item_Price_Stock_Data>().ToList<object>(), emode);
            this.usrc_Item_InsidePageHandler1.ShowPage(0);
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
            if (m_ShopBC.m_CurrentDoc.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,true))
            {
                int index = m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            }
        }

        internal void AddFromFactory(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {

            if (m_ShopBC.m_CurrentDoc.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,false))
            {
                int index = m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            }
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
    }
}
