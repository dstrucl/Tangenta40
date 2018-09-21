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

namespace ShopC
{
    public partial class usrc_ItemList1366x768 : UserControl
    {
        private ID m_Atom_WorkPeriod_ID = null;
        private string m_DocTyp = "";
        private Form_plus frmplus = null;

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
            get { return m_DocTyp; }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    m_DocTyp = s;
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


        public int m_NumberOfItemsPerPage = 10;
        public int NumberOfItemsPerPage
        {
            get { return m_NumberOfItemsPerPage; }
            set { m_NumberOfItemsPerPage = value;
//                 Init(m_Atom_WorkPeriod_ID);
                }
        }

        

        private bool m_bExclusivelySellFromStock = false;
        public bool ExclusivelySellFromStock
        {
            get { return m_bExclusivelySellFromStock; }
            set { m_bExclusivelySellFromStock = value; }
        }

        public string[] s_name_Group = null;

        public delegate void delegate_ItemAdded();
        public event delegate_ItemAdded ItemAdded = null;

        public usrc_ShopC1366x768 m_usrc_ItemMan = null;

        public usrc_Item1366x768[] usrc_Item_aray = null;
        usrc_Atom_ItemsList1366x768 m_usrc_Atom_ItemsList1366x768 = null;

        ShopABC m_ShopBC;
        DBTablesAndColumnNames DBtcn;
        private ID m_PriceList_ID = null;



        public usrc_ItemList1366x768()
        {
            InitializeComponent();

            usrc_Item_InsidePageGroupHandler1.CreateControl += Usrc_Item_InsidePageGroupHandler1_CreateControl;
            usrc_Item_InsidePageGroupHandler1.FillControl += Usrc_Item_InsidePageGroupHandler1_FillControl;
            usrc_Item_InsidePageGroupHandler1.LoadItemsList += Usrc_Item_InsidePageGroupHandler1_LoadItemsList;
            usrc_Item_InsidePageGroupHandler1.SelectControl += Usrc_Item_InsidePageGroupHandler1_SelectControl;
            usrc_Item_InsidePageGroupHandler1.SelectionChanged += Usrc_Item_InsidePageGroupHandler1_SelectionChanged;
            usrc_Item_InsidePageGroupHandler1.ControlClick += Usrc_Item_InsidePageGroupHandler1_ControlClick;
        }

        internal void Select(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
           string[] sgroup = new string[3] { appisd.s1_name, appisd.s2_name, appisd.s3_name };
            this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup);
        }

        private decimal quantityinStock(Item_Data ixdata)
        {
            if (ixdata.Stock_dQuantity != null)
            {
                return ixdata.Stock_dQuantity.v;
            }
            else
            {
                return 0;
            }
        }

        private void Usrc_Item_InsidePageGroupHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            frmplus.Flash(ctrl);
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
                decimal dquanity_in_stock = quantityinStock(idata);
                if (dquanity_in_stock > 0)
                {
                    // Add from stock
                    decimal dquantity = 1;
                    if (dquanity_in_stock<1)
                    {
                        dquantity = dquanity_in_stock;
                    }
                    
                    m_ShopBC.m_CurrentDoc.m_Basket.Add(m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                this,
                                                                                idata,
                                                                                0,
                                                                                dquantity,
                                                                                ref appisd, false);
                    m_usrc_Atom_ItemsList1366x768.AddFromStock(appisd);
                    m_usrc_Atom_ItemsList1366x768.ShowBasket(appisd.Atom_Item_UniqueName.v);
                    if (ItemAdded != null)
                    {
                        ItemAdded();
                    }
                }
                else
                {
                    // Add from factory
                    m_ShopBC.m_CurrentDoc.m_Basket.Add(m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                this,
                                                                                idata,
                                                                                1,
                                                                                0,
                                                                                ref appisd, true);
                    m_usrc_Atom_ItemsList1366x768.AddFromFactory(appisd);
                    m_usrc_Atom_ItemsList1366x768.ShowBasket(appisd.Atom_Item_UniqueName.v);
                    if (ItemAdded!=null)
                    {
                        ItemAdded();
                    }
                }
                if (appisd!=null)
                {
                    if (appisd.Atom_Item_UniqueName!=null)
                    {
                        this.usrc_Item_TextSearch1.Item_UniqueName = appisd.Atom_Item_UniqueName.v;
                        this.usrc_Item_TextSearch1.ShowGroup(appisd.s1_name, appisd.s2_name, appisd.s3_name);
                    }
                }
                
            }
        }

        internal void DoRepaint()
        {
            this.usrc_Item_InsidePageGroupHandler1.DoRepaint();
        }

        private void Usrc_Item_InsidePageGroupHandler1_ControlClick(Control ctrl, object oData, int index, bool selected)
        {
        }

        private void Usrc_Item_InsidePageGroupHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (ctrl is usrc_Item1366x768)
                {
                    usrc_Item1366x768 xusrc_Item1366x768 = (usrc_Item1366x768)ctrl;
                    xusrc_Item1366x768.SelectControl(idata, selected);
                }
            }
        }

        private bool Usrc_Item_InsidePageGroupHandler1_LoadItemsList(string[] groups, ref List<object> list)
        {
            string[] sreversgroup = reversegroup(groups);

           if ( m_ShopBC.m_CurrentDoc.m_ShopShelf.Load(m_PriceList_ID, sreversgroup))
            {
                list = m_ShopBC.m_CurrentDoc.m_ShopShelf.ListOfItems.Cast<Item_Data>().ToList<object>();
                return true;
            }
            return false;
        }

        private string[] reversegroup(string[] groups)
        {
            string[] sr = new string[3] { null, null, null };
            if (groups[2]==null)
            {
                if (groups[1] == null)
                {
                    sr[0] = groups[0];
                }
                else
                {
                    sr[0] = groups[1];
                    sr[1] = groups[0];
                }
            }
            else
            {
                sr[0] = groups[0];
                sr[1] = groups[1];
                sr[2] = groups[2];
            }
            return sr;
        }

        private void Usrc_Item_InsidePageGroupHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler.eMode emode)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (ctrl is usrc_Item1366x768)
                {
                    usrc_Item1366x768 xusrc_Item1366x768 = (usrc_Item1366x768)ctrl;

                    xusrc_Item1366x768.DoPaint(idata, m_ShopBC.m_CurrentDoc.m_Basket);
                }
            }
        }

        private void Usrc_Item_InsidePageGroupHandler1_CreateControl(ref Control ctrl)
        {
            usrc_Item1366x768 xusrc_Item1366x768 = new usrc_Item1366x768();
            ctrl = xusrc_Item1366x768;
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
                           TangentaDB.ShopABC xm_ShopBC,
                           DBTablesAndColumnNames xDBtcn, 
                           usrc_ShopC1366x768 x_usrc_ItemMan,
                           usrc_Atom_ItemsList1366x768 x_usrc_Atom_ItemsList,
                           bool xbExclusivelySellFromStock)
        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_ShopBC = xm_ShopBC;
            m_usrc_ItemMan = x_usrc_ItemMan;
            DBtcn = xDBtcn;
            //            this.m_usrc_Item_Group_Handler.ShopName = lng.s_ShopC_Name.s;
            m_usrc_Atom_ItemsList1366x768 = x_usrc_Atom_ItemsList;
            m_bExclusivelySellFromStock = xbExclusivelySellFromStock;
            frmplus = new Form_plus();
            frmplus.Owner = Global.f.GetParentForm(this);
        }



        //void usrc_item_ItemAdded()
        //{
        //    if (ItemAdded != null)
        //    {
        //        ItemAdded();
        //    }
        //}

        public bool Get_Price_Item_Stock_Data(ID xPriceList_ID)
        {
            m_PriceList_ID = xPriceList_ID;
            if (m_ShopBC.m_CurrentDoc.m_ShopShelf.GetGroupsTable(xPriceList_ID))
            {
                usrc_Item_InsidePageGroupHandler1.Init(m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group);
                return true;
            }
            return false;
        }
    }
}
