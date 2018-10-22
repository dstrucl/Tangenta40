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

        internal void Select(Doc_ShopC_Item xdsci, string s_ItemUniqueName)
        {
           string[] sgroup = new string[3] { xdsci.s1_name, xdsci.s2_name, xdsci.s3_name };
           this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName);
        }

        internal void Select(Doc_ShopC_Item xdsci, string s_ItemUniqueName, ref object odata, ref Control ctrl)
        {
            string[] sgroup = new string[3] { xdsci.s1_name, xdsci.s2_name, xdsci.s3_name };
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

      

        private bool update_stock_elements_in_Doc_ShopC_Item( 
                                                             Item_Data xData,
                                                             ref Doc_ShopC_Item dsci)

        {
            dsci = m_ShopBC.m_CurrentDoc.m_Basket.Find(xData.Item_UniqueName);
            if (dsci!=null)
            {
                // item allready in basket

            }
            else
            {
                // item not in basket
                //dsci = m_ShopBC.m_CurrentDoc.m_Basket.Add(xData,);
            }

            List<Doc_ShopC_Item> doc_ShopC_Items = m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST;

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
                                    //if (!f_DocInvoice_ShopC_Item.UpdateQuantity(Doc_ShopC_Item_ID, dquantity_new))
                                    //{
                                    //    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:f_DocInvoice_ShopC_Item.UpdateQuantity!");
                                    //    return false;
                                    //}
                                }
                                else
                                {
                                    if (!f_DocProformaInvoice_ShopC_Item.UpdateQuantity(Doc_ShopC_Item_ID, dquantity_new))
                                    {
                                        LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:f_DocInvoice_ShopC_Item.UpdateQuantity!");
                                        return false;
                                    }
                                }
                                if (dsci != null)
                                {
                                    dsci.AddQuantity(Doc_ShopC_Item_ID, std.Stock_ID, std.dQuantity_Taken_v.v);
                                }
                               
                            }
                            else
                            {
                                ID atom_Price_Item_ID = null;
                                ID docInvoice_ShopC_Item_ID = null;
                                //stock element that is currently not in Doc_ShopC_Item
                                //if (!m_ShopBC.Add_Doc_ShopC_Item(xData, std.
                                //                        dQuantity_Taken_v.v,
                                //                        std.Stock_ID,
                                //                        ref atom_Price_Item_ID,
                                //                        ref docInvoice_ShopC_Item_ID))
                                //{
                                //    return false;
                                //}
                                if (dsci != null)
                                {
                                    dsci.Add_Doc_ShopC_Item(xData,
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
                                                                           ref dsci,
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


                Doc_ShopC_Item dsci = m_ShopBC.m_CurrentDoc.m_Basket.Find(xData.Item_UniqueName_v.v);


                decimal dQuantitySelectedFromStock = 0;

                DataTable xdt_ShopC_Item_In_Stock = null;
                if (f_Stock.GetItemInStock(xData.Item_ID, ref xdt_ShopC_Item_In_Stock))
                {
                    List<Stock_Data> taken_from_Stock_List = new List<Stock_Data>();

                    if (SelectItemsFromStockDialog)
                    {
                        Select_Items_From_Stock_Dialog(xdt_ShopC_Item_In_Stock, xquantity2add, ref taken_from_Stock_List, ref dQuantitySelectedFromStock);
                    }
                    else
                    {
                        AutoSelect_Items_From_Stock(xdt_ShopC_Item_In_Stock, xquantity2add, ref taken_from_Stock_List, ref dQuantitySelectedFromStock);
                    }

                    if (m_ShopBC.m_CurrentDoc.m_Basket.WriteItemStockTransferInDataBase(m_ShopBC.DocTyp,
                                                                                        m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                        xData, 
                                                                                        ref dsci, 
                                                                                        taken_from_Stock_List,
                                                                                        xquantity2add - dQuantitySelectedFromStock))
                    {
                        if (ctrl is usrc_Item1366x768)
                        {
                            ((usrc_Item1366x768)ctrl).DoPaint(xData, m_ShopBC.m_CurrentDoc.m_Basket);
                        }


                        m_usrc_Atom_ItemsList1366x768.ShowBasket(xData.Item_UniqueName_v.v, xData, ctrl);
                        if (ItemAdded != null)
                        {
                            ItemAdded();
                        }

                        this.usrc_Item_TextSearch1.Item_UniqueName = xData.Item_UniqueName_v.v;
                        this.usrc_Item_TextSearch1.ShowGroup(xData.s1_name, xData.s2_name, xData.s3_name);
                    }
                }
            }
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

        private void AutoSelect_Items_From_Stock(DataTable xdt_ShopC_Item_In_Stock, decimal xquantity2add, ref List<Stock_Data> taken_from_stock, ref decimal dQuantitySelectedFromStock)
        {
            if (!xdt_ShopC_Item_In_Stock.Columns.Contains("TakeFromStock"))
            {
                xdt_ShopC_Item_In_Stock.Columns.Add(new DataColumn("TakeFromStock", typeof(decimal)));
            }

            if (taken_from_stock == null)
            {
                taken_from_stock = new List<Stock_Data>();
            }
            else
            {
                taken_from_stock.Clear();
            }
            dQuantitySelectedFromStock = 0;
            foreach (DataRow dr in xdt_ShopC_Item_In_Stock.Rows)
            {
                decimal dQinStock = (decimal)dr["Stock_dQuantity"];
                if (dQinStock>0)
                {
                    if (dQinStock >= xquantity2add)
                    {
                        dr["Stock_dQuantity"]= dQinStock - xquantity2add;
                        dr["TakeFromStock"] = xquantity2add;
                        dQuantitySelectedFromStock = xquantity2add;

                        Stock_Data xstd = new Stock_Data();
                        xstd.dQuantity_Taken_v = new decimal_v(((decimal)dr["TakeFromStock"]));
                        xstd.dQuantity_v = new decimal_v(dQinStock);
                        xstd.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                        taken_from_stock.Add(xstd);

                        return;
                    }
                    else
                    {
                        // take all
                        dr["TakeFromStock"] =  dQinStock;
                        dr["Stock_dQuantity"] = 0;
                        dQuantitySelectedFromStock += dQinStock;
                        xquantity2add -= dQinStock;

                        Stock_Data xstd = new Stock_Data();
                        xstd.dQuantity_Taken_v = new decimal_v(((decimal)dr["TakeFromStock"]));
                        xstd.dQuantity_v = new decimal_v(dQinStock);
                        xstd.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                        taken_from_stock.Add(xstd);

                    }
                }
            }
        }

        private bool find_Doc_ShopC_Item_ID(List<Doc_ShopC_Item> doc_ShopC_Items, ID stock_ID,ref decimal dquantity, ref ID doc_ShopC_Item_ID)
        {
            dquantity = 0;
            foreach (object odr in doc_ShopC_Items)
            {
                Doc_ShopC_Item dsci = (Doc_ShopC_Item)odr;
                //foreach (Stock_Data std in dsci.Stock_Data_List)
                //{
                //    if (ID.Validate(std.Stock_ID))
                //    {
                //        if (std.Stock_ID.Equals(stock_ID))
                //        {
                //            decimal_v dq_v = std.dQuantity_v;
                //            if (dq_v != null)
                //            {
                //                dquantity = dq_v.v;
                //            }
                //            doc_ShopC_Item_ID = tf.set_ID(dsci.Doc_ShopC_Item_ID);
                //            return true;
                //        }
                //    }
                //}
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
    }
}
