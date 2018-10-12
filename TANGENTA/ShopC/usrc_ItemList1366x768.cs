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

namespace ShopC
{
    public partial class usrc_ItemList1366x768 : UserControl
    {
        private ID m_Atom_WorkPeriod_ID = null;
        private string m_DocTyp = "";
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

        internal void Select(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, string s_ItemUniqueName)
        {
           string[] sgroup = new string[3] { appisd.s1_name, appisd.s2_name, appisd.s3_name };
           this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName);
        }

        internal void Select(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, string s_ItemUniqueName, ref object odata, ref Control ctrl)
        {
            string[] sgroup = new string[3] { appisd.s1_name, appisd.s2_name, appisd.s3_name };
            this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName,ref odata, ref ctrl);
        }


        private bool take_from_Stock(decimal dQuantityToGetFromStock,
                                     List<Stock_Data> stocks,
                                     ref decimal dquantity_not_taken_from_stock,
                                     ref decimal dquantity_in_stock_at_the_end)
        {
            decimal dquantity_to_take_from_stock = dQuantityToGetFromStock;
            int icount = stocks.Count;
            dquantity_in_stock_at_the_end = 0;
            for (int i = 0; i < icount; i++)
            {
                Stock_Data std = stocks[i];
                if (std.dQuantity_v != null)
                {
                    if (std.dQuantity_v.v > 0)
                    {
                        if (dquantity_to_take_from_stock >= std.dQuantity_v.v)
                        {
                            dquantity_to_take_from_stock -= std.dQuantity_v.v;
                            if (f_Stock.UpdateQuantity(std.Stock_ID, 0))
                            {
                                if (std.dQuantity_Taken_v == null)
                                {
                                    std.dQuantity_Taken_v = new decimal_v();
                                }
                                std.dQuantity_Taken_v.v = std.dQuantity_v.v;
                                std.dQuantity_v.v = 0;
                                if (dquantity_to_take_from_stock > 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            decimal dQuantity_left_in_stock = std.dQuantity_v.v - dquantity_to_take_from_stock;
                            if (f_Stock.UpdateQuantity(std.Stock_ID, dQuantity_left_in_stock))
                            {
                                if (std.dQuantity_Taken_v == null)
                                {
                                    std.dQuantity_Taken_v = new decimal_v();
                                }
                                std.dQuantity_Taken_v.v = dquantity_to_take_from_stock;

                                std.dQuantity_v.v = dQuantity_left_in_stock;
                                dquantity_in_stock_at_the_end += dQuantity_left_in_stock;
                                dquantity_to_take_from_stock = 0;

                                break;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            dquantity_not_taken_from_stock = dquantity_to_take_from_stock;
            return true;
        }


        private bool update_stock_elements_in_Doc_ShopC_Item(List<object> doc_ShopC_Items, 
                                                             Item_Data xData,
                                                             ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            List<Stock_Data> stocks = xData.Stock_Data_List;
            foreach (Stock_Data std in stocks)
            {
                ID Doc_ShopC_Item_ID = null;
                decimal dqunatity_current = 0;
                if (ID.Validate(std.Stock_ID))
                {
                    if (std.dQuantity_Taken_v != null)
                    {
                        if (std.dQuantity_Taken_v.v > 0)
                        {
                            if (find_Doc_ShopC_Item_ID(doc_ShopC_Items, std.Stock_ID, ref dqunatity_current, ref Doc_ShopC_Item_ID))
                            {
                                decimal dquantity_new = dqunatity_current + std.dQuantity_Taken_v.v;
                                if (m_ShopBC.IsDocInvoice)
                                {
                                    if (!f_DocInvoice_ShopC_Item.UpdateQuantity(Doc_ShopC_Item_ID, dquantity_new))
                                    {
                                        LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:f_DocInvoice_ShopC_Item.UpdateQuantity!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (!f_DocProformaInvoice_ShopC_Item.UpdateQuantity(Doc_ShopC_Item_ID, dquantity_new))
                                    {
                                        LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:f_DocInvoice_ShopC_Item.UpdateQuantity!");
                                        return false;
                                    }
                                }
                                if (appisd != null)
                                {
                                    appisd.AddQuantity(Doc_ShopC_Item_ID, std.Stock_ID, std.dQuantity_Taken_v.v);
                                }
                               
                            }
                            else
                            {
                                ID atom_Price_Item_ID = null;
                                ID docInvoice_ShopC_Item_ID = null;
                                //stock element that is currently not in Doc_ShopC_Item
                                if (!m_ShopBC.Add_Doc_ShopC_Item(xData, std.
                                                        dQuantity_Taken_v.v,
                                                        std.Stock_ID,
                                                        ref atom_Price_Item_ID,
                                                        ref docInvoice_ShopC_Item_ID))
                                {
                                    return false;
                                }
                                if (appisd != null)
                                {
                                    appisd.Add_Doc_ShopC_Item(xData,
                                                              std.dQuantity_Taken_v.v,
                                                              std.Stock_ID,
                                                              atom_Price_Item_ID
                                                              );
                                }
                                else
                                {
                                    //not in basket yet
                                    if (ID.Validate(std.Stock_ID))
                                    {
                                        m_ShopBC.m_CurrentDoc.m_Basket.Add_WithNoTakeForItemData(m_ShopBC.m_CurrentDoc.m_Doc_ID,
                                                                           docInvoice_ShopC_Item_ID,
                                                                           xData,
                                                                           0,
                                                                           std.dQuantity_Taken_v.v,
                                                                           ref appisd,
                                                                           false
                                                                       );
                                    }
                                }
                               
                            }
                            std.dQuantity_Taken_v.v = 0;
                        }
                    }
                }
            }
            return true;
        }
        private void Add2Basket(decimal xquantity2add,Control ctrl, object oData, int index)
        {
            //frmplus.Flash(ctrl);
            if (oData is Item_Data)
            {
                Item_Data xData = (Item_Data)oData;

                decimal dRemainderQuantityNotTakenFromStock = 0;
                decimal dquantity_in_stock_at_the_end = 0;

                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = m_ShopBC.m_CurrentDoc.m_Basket.Find(xData.Item_UniqueName.v);
                
                if (take_from_Stock(xquantity2add, xData.Stock_Data_List, ref dRemainderQuantityNotTakenFromStock, ref dquantity_in_stock_at_the_end))
                {
                    if (xquantity2add > dRemainderQuantityNotTakenFromStock)
                    {
                        if (xData.Stock_Data_List.Count > 0)
                        {
                            if (!update_stock_elements_in_Doc_ShopC_Item(m_ShopBC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST, xData, ref appisd))
                            {
                                LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:Add2Basket:!update_stock_elements_in_Doc_ShopC_Item!");
                                return;
                            }
                        }
                    }
                }


                if (dRemainderQuantityNotTakenFromStock>0)
                {
                    if (appisd == null)
                    {
                        ID atom_Price_Item_ID = null;
                        ID docInvoice_ShopC_Item_ID = null;
                        if (!m_ShopBC.Add_Doc_ShopC_Item(xData,
                                                dRemainderQuantityNotTakenFromStock,
                                                null,
                                                ref atom_Price_Item_ID,
                                                ref docInvoice_ShopC_Item_ID))
                        {
                            return;
                        }
                        m_ShopBC.m_CurrentDoc.m_Basket.Add_WithNoTakeForItemData(m_ShopBC.m_CurrentDoc.m_Doc_ID,
                                                            docInvoice_ShopC_Item_ID,
                                                            xData,
                                                            dRemainderQuantityNotTakenFromStock,
                                                            0,
                                                            ref appisd,
                                                            true
                                                        );
                    }
                    else 
                    {
                        Stock_Data std = appisd.From_FactoryItems();
                        if (std!=null)
                        {
                            //factory items exist
                            //appisd.m_ShopShelf_Source.Stock_Data_List[0].
                            std.dQuantity_v.v = std.dQuantity_v.v + xquantity2add;
                            if (ID.Validate(std.Doc_ShopC_Item_ID))
                            {
                                if (!f_DocInvoice_ShopC_Item.UpdateQuantity(std.Doc_ShopC_Item_ID, std.dQuantity_v.v))
                                {
                                    return;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:Add2Basket:std.Doc_ShopC_Item_ID is not valid!");
                            }
                        }
                        else
                        {
                            //factory  items not exist
                            ID atom_Price_Item_ID = null;
                            ID doc_ShopC_Item_ID = null;
                            if (!m_ShopBC.Add_Doc_ShopC_Item(xData,
                                                    dRemainderQuantityNotTakenFromStock,
                                                    null,
                                                    ref atom_Price_Item_ID,
                                                    ref doc_ShopC_Item_ID))
                            {
                                return;
                            }
                            Stock_Data stdx = new Stock_Data();
                            stdx.Doc_ShopC_Item_ID = doc_ShopC_Item_ID;
                            stdx.dQuantity_v = new decimal_v(xquantity2add);
                            appisd.m_ShopShelf_Source.Stock_Data_List.Add(stdx);
                        }
                    }

                }

               if (ctrl is usrc_Item1366x768)
                {
                    ((usrc_Item1366x768)ctrl).DoPaint(xData, m_ShopBC.m_CurrentDoc.m_Basket);
                }


                m_usrc_Atom_ItemsList1366x768.ShowBasket(xData.Item_UniqueName.v, xData, ctrl);
                if (ItemAdded != null)
                {
                    ItemAdded();
                }

                this.usrc_Item_TextSearch1.Item_UniqueName = xData.Item_UniqueName.v;
                this.usrc_Item_TextSearch1.ShowGroup(xData.s1_name, xData.s2_name, xData.s3_name);
            }
        }

 

        private bool find_Doc_ShopC_Item_ID(List<object>doc_ShopC_Items, ID stock_ID,ref decimal dquantity, ref ID doc_ShopC_Item_ID)
        {
            dquantity = 0;
            foreach (object odr in doc_ShopC_Items)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)odr;
                foreach (Stock_Data std in appisd.m_ShopShelf_Source.Stock_Data_List)
                {
                    if (ID.Validate(std.Stock_ID))
                    {
                        if (std.Stock_ID.Equals(stock_ID))
                        {
                            decimal_v dq_v = std.dQuantity_v;
                            if (dq_v != null)
                            {
                                dquantity = dq_v.v;
                            }
                            doc_ShopC_Item_ID = tf.set_ID(appisd.Doc_ShopC_Item_ID);
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        private void Usrc_Item_InsidePageGroupHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            if (ctrl != null)
            {
                Add2Basket(1, ctrl, oData, index);
            }
        }
        private void Usrc_Item_InsidePageGroupHandler1_ControlClick(Control ctrl, object oData, int index, bool selected)
        {
            if (ctrl != null)
            {
                Add2Basket(1, ctrl, oData, index);
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
                if (ctrl is usrc_Item1366x768)
                {
                    usrc_Item1366x768 xusrc_Item1366x768 = (usrc_Item1366x768)ctrl;
                    xusrc_Item1366x768.SelectControl(idata, selected);
                }
            }
        }

        private bool Usrc_Item_InsidePageGroupHandler1_LoadItemsList(string[] groups, ref List<object> list)
        {
            string[] sreversgroup = usrc_Item_InsideGroupHandler.reversegroup(groups);

           if ( m_ShopBC.m_CurrentDoc.m_ShopShelf.Load(m_PriceList_ID, sreversgroup))
            {
                list = m_ShopBC.m_CurrentDoc.m_ShopShelf.ListOfItems.Cast<Item_Data>().ToList<object>();
                return true;
            }
            return false;
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
            //frmplus = new Form_plus();
            //frmplus.Owner = Global.f.GetParentForm(this);
        }


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

        private bool usrc_Item_InsidePageGroupHandler1_InsidePageHandler_CompareWithString(object oData, string s)
        {
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;
                if (idata.Item_UniqueName!=null)
                { 
                    return idata.Item_UniqueName.v.Equals(s);
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
    }
}
