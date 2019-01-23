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
using System.Runtime.InteropServices;
using DBConnectionControl40;
using TangentaDB;
using LanguageControl;
using DBTypes;
using usrc_Item_InsideGroup_Handler;
using ShopC_Forms;

namespace ShopC_Forms
{
    public partial class usrc_ItemList : UserControl
    {
        private ID m_Atom_WorkPeriod_ID = null;
        //private Form_plus frmplus = null;

        public delegate void delegate_Stock_Click();
        public event delegate_Stock_Click Stock_Click;

        public delegate void delegate_Items_Click();
        public event delegate_Items_Click Items_Click;

        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }

        public string DocTyp
        {
            get { return m_consE.DocTyp; }
        }


        public bool SelectItemsFromStockDialog
        {
            get
            {
                return chk_SelectFromStock.Checked;
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
            set { m_NumberOfItemsPerPage = value;
//                 Init(m_Atom_WorkPeriod_ID);
                }
        }

        


        public string[] s_name_Group = null;

        public delegate void delegate_ItemAdded();
        public event delegate_ItemAdded ItemAdded = null;

        public usrc_ShopC m_usrc_ItemMan = null;

        public usrc_Item[] usrc_Item_aray = null;
        usrc_Atom_ItemsList m_usrc_Atom_ItemsList = null;

        ConsumptionEditor m_consE;
        DBTablesAndColumnNamesOfConsumption DBtcn;
        private ID m_PriceList_ID = null;



        public usrc_ItemList()
        {
            InitializeComponent();

            usrc_Item_InsidePageGroupHandler1.CreateControl += Usrc_Item_InsidePageGroupHandler1_CreateControl;
            usrc_Item_InsidePageGroupHandler1.FillControl += Usrc_Item_InsidePageGroupHandler1_FillControl;
            usrc_Item_InsidePageGroupHandler1.LoadItemsList += Usrc_Item_InsidePageGroupHandler1_LoadItemsList;
            usrc_Item_InsidePageGroupHandler1.SelectControl += Usrc_Item_InsidePageGroupHandler1_SelectControl;
            usrc_Item_InsidePageGroupHandler1.SelectionChanged += Usrc_Item_InsidePageGroupHandler1_SelectionChanged;
            usrc_Item_InsidePageGroupHandler1.ControlClick += Usrc_Item_InsidePageGroupHandler1_ControlClick;
        }

        internal void Select(TangentaDB.Consumption_ShopC_Item xdsci, string s_ItemUniqueName)
        {
           string[] sgroup = new string[3] { xdsci.s1_name, xdsci.s2_name, xdsci.s3_name };
           this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName);
        }

        internal void Select(TangentaDB.Consumption_ShopC_Item xdsci, string s_ItemUniqueName, ref object odata, ref Control ctrl)
        {
            string[] sgroup = new string[3] { xdsci.s1_name, xdsci.s2_name, xdsci.s3_name };
            this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName,ref odata, ref ctrl);
        }

        

        public bool Select_Items_From_Stock_Dialog(DataTable xdt_ShopC_Item_In_Stock, decimal dQuantityToTake, ref List<Stock_Data> taken_form_stock, ref decimal dQuantitySelected)
        {
            dQuantitySelected = 0;
            Form_Select_Item_From_Stock frm_select_item_from_stock = new Form_Select_Item_From_Stock(xdt_ShopC_Item_In_Stock, dQuantityToTake);
            if (frm_select_item_from_stock.ShowDialog(this) == DialogResult.OK)
            {
                if (taken_form_stock == null)
                {
                    taken_form_stock = new List<Stock_Data>();
                }
                else
                {
                    taken_form_stock.Clear();
                }
                foreach (DataRow dr in xdt_ShopC_Item_In_Stock.Rows)
                {
                    if (dr["TakeFromStock"] is decimal)
                    {
                        if (((decimal)dr["TakeFromStock"]) > 0)
                        {
                            Stock_Data xstd = new Stock_Data();
                            xstd.dQuantity_Taken_v = new decimal_v(((decimal)dr["TakeFromStock"]));
                            dQuantitySelected += xstd.dQuantity_Taken_v.v;
                            xstd.dQuantity_v = new decimal_v((decimal)dr["Stock_dQuantity"]);
                            xstd.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                            taken_form_stock.Add(xstd);
                        }
                    }
                }
                return true;
            }
            return false;
        }



        private void Usrc_Item_InsidePageGroupHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (ctrl != null)
            {
                add2Basket(1, ctrl, oData, index);
            }
        }

        private void add2Basket(decimal dQuantity2Add , Control ctrl, object oData, int index)
        {
            if (oData is Item_Data)
            {
                Item_Data xData = (Item_Data)oData;
                bool bRes = false;
                TangentaDB.Consumption_ShopC_Item dsci = null;
                if (this.SelectItemsFromStockDialog)
                {
                    bRes = m_consE.m_CurrentConsumption.m_Basket.Add2Basket(ref dsci,
                                                                     m_consE.DocTyp,
                                                                     m_consE.m_CurrentConsumption.Doc_ID,
                                                                     dQuantity2Add,
                                                                     xData,
                                                                     Select_Items_From_Stock_Dialog);
                }
                else
                {
                    bRes = m_consE.m_CurrentConsumption.m_Basket.Add2Basket(ref dsci,
                                                                     m_consE.DocTyp,
                                                                     m_consE.m_CurrentConsumption.Doc_ID,
                                                                     dQuantity2Add,
                                                                     xData,
                                                                     null);
                }

                if (bRes)
                {
                    if (ctrl is usrc_Item)
                    {
                        ((usrc_Item)ctrl).DoPaint(xData, m_consE.m_CurrentConsumption.m_Basket);
                    }


                    m_usrc_Atom_ItemsList.ShowBasket(xData.Item_UniqueName_v.v, xData, ctrl);
                    if (ItemAdded != null)
                    {
                        ItemAdded();
                    }

                    this.usrc_Item_TextSearch1.Item_UniqueName = xData.Item_UniqueName_v.v;
                    this.usrc_Item_TextSearch1.ShowGroup(xData.s1_name, xData.s2_name, xData.s3_name);
                }
            }

        }

        private void Usrc_Item_InsidePageGroupHandler1_ControlClick(Control ctrl, object oData, int index, bool selected)
        {
            if (ctrl != null)
            {
                add2Basket(1, ctrl, oData, index);
            }
        }




        internal void DoRepaint()
        {
            this.usrc_Item_InsidePageGroupHandler1.DoRepaint();
        }


        private void Usrc_Item_InsidePageGroupHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (ctrl is usrc_Item)
                {
                    usrc_Item xusrc_Item = (usrc_Item)ctrl;
                    xusrc_Item.SelectControl(idata, selected);
                }
            }
        }

        private bool Usrc_Item_InsidePageGroupHandler1_LoadItemsList(string[] groups, ref List<Item_Data> list)
        {
            string[] sreversgroup = usrc_Item_InsideGroupHandler.reversegroup(groups);

           if (m_consE.m_CurrentConsumption.m_ShopShelf.Load(m_PriceList_ID, sreversgroup))
            {
                list = m_consE.m_CurrentConsumption.m_ShopShelf.ListOfItems;
                return true;
            }
            return false;
        }


        private void Usrc_Item_InsidePageGroupHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler<Item_Data>.eMode emode)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (ctrl is usrc_Item)
                {
                    usrc_Item xusrc_Item = (usrc_Item)ctrl;

                    xusrc_Item.DoPaint(idata, m_consE.m_CurrentConsumption.m_Basket);
                }
            }
        }

        private void Usrc_Item_InsidePageGroupHandler1_CreateControl(ref Control ctrl)
        {
            usrc_Item xusrc_Item = new usrc_Item();
            ctrl = xusrc_Item;
        }


        void usrc_item_StockChanged(object obj)
        {
            if (obj is Item_Data)
            {
                Get_Price_Item_Stock_Data(((Item_Data)obj).PriceList_ID);
            }
        }

        void usrc_item_ItemChanged(object obj)
        {
            if (obj is TangentaDB.Item_Data)
            {
                Get_Price_Item_Stock_Data(((TangentaDB.Item_Data)obj).PriceList_ID);
            }
        }

        internal void Init(ID xAtom_WorkPeriod_ID,
                           ConsumptionEditor xconsE,
                           DBTablesAndColumnNamesOfConsumption xDBtcn, 
                           usrc_ShopC x_usrc_ItemMan,
                           usrc_Atom_ItemsList x_usrc_Atom_ItemsList)
        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_consE = xconsE;
            m_usrc_ItemMan = x_usrc_ItemMan;
            DBtcn = xDBtcn;
            m_usrc_Atom_ItemsList = x_usrc_Atom_ItemsList;
        }


        public bool Get_Price_Item_Stock_Data(ID xPriceList_ID)
        {
            m_PriceList_ID = xPriceList_ID;
            if (m_consE.m_CurrentConsumption.m_ShopShelf.GetGroupsTable(xPriceList_ID))
            {
                usrc_Item_InsidePageGroupHandler1.Init(m_consE.m_CurrentConsumption.m_ShopShelf.dt_Price_Item_Group);
                return true;
            }
            return false;
        }

        private bool usrc_Item_InsidePageGroupHandler1_InsidePageHandler_CompareWithString(object oData, string s)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (idata.Item_UniqueName_v!=null)
                { 
                    return idata.Item_UniqueName_v.v.Equals(s);
                }
            }
            return false;
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            if (Stock_Click!=null)
            {
                Stock_Click();
            }
        }

        private void btn_Items_Click(object sender, EventArgs e)
        {
            if (Items_Click!=null)
            {
                Items_Click();
            }
        }

        public void DoRefresh()
        {
            this.usrc_Item_InsidePageGroupHandler1.DoRefresh();
        }
    }
}
