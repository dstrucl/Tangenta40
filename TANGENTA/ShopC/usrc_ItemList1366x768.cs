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

        internal void Select(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, string s_ItemUniqueName)
        {
           string[] sgroup = new string[3] { appisd.s1_name, appisd.s2_name, appisd.s3_name };
           this.usrc_Item_InsidePageGroupHandler1.SelectGroup(sgroup, s_ItemUniqueName);
        }

        private decimal quantityinStock(Item_Data ixdata)
        {
            DataTable dtStock = new DataTable();
            decimal dStockQuantity = 0;
            if (f_Stock.GetItemInStock(ixdata.Item_ID, ref dtStock))
            {

                foreach (DataRow dr in dtStock.Rows)
                {
                    decimal_v dStockQuantity_v = tf.set_decimal(dr["Stock_dQuantity"]);
                    if (dStockQuantity_v != null)
                    {
                        dStockQuantity += dStockQuantity_v.v;
                    }
                }
            }
            return dStockQuantity;
        }

        private void IncrementBasket2(Control ctrl, object oData, int index)
        {
            frmplus.Flash(ctrl);
            if (oData is Item_Data)
            {
                Item_Data idata = (Item_Data)oData;

                decimal dQuantityInBasket_FromStock = -1;
                decimal dQuantityInBasket_FromFactory = -1;

                string sItemUniqueName = null;
                if (idata.Item_UniqueName!=null)
                {
                    sItemUniqueName = idata.Item_UniqueName.v;
                }
                if (sItemUniqueName != null)
                {
                    m_usrc_Atom_ItemsList1366x768.RemoveItem(sItemUniqueName, ref dQuantityInBasket_FromStock, ref dQuantityInBasket_FromFactory);
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:(sItemUniqueName == null)!");
                    return;
                }

                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;

                if (dQuantityInBasket_FromStock < 0)
                {
                    dQuantityInBasket_FromStock = 0;
                }
                if (dQuantityInBasket_FromFactory < 0)
                {
                    dQuantityInBasket_FromFactory = 0;
                }

                decimal dquanity_in_stock = quantityinStock(idata); /* quantity from basket was allready returned to stock */

                decimal add_dquanity_from_stock_to_Factory = 0;

                decimal dquantity_to_take_From_Stock = dQuantityInBasket_FromStock 
                                                       + dQuantityInBasket_FromFactory + 1;

                decimal dquantity_to_put_fromstock = 0;
                decimal dquantity_to_put_fromfactory = 0;

                if (dquanity_in_stock > 0)
                {
                    // Add from stock
                    if (dquantity_to_take_From_Stock > dquanity_in_stock)
                    {
                        dquantity_to_put_fromstock = dquanity_in_stock;
                        add_dquanity_from_stock_to_Factory = dquantity_to_take_From_Stock - dquanity_in_stock;
                    }
                    else
                    {
                        dquantity_to_put_fromstock = dquantity_to_take_From_Stock;
                    }

                    m_ShopBC.m_CurrentDoc.m_Basket.Add(m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                this,
                                                                                idata,
                                                                                0,
                                                                                dquantity_to_put_fromstock,
                                                                                ref appisd, false);
                    m_usrc_Atom_ItemsList1366x768.AddFromStock(appisd);

                    dquantity_to_put_fromfactory = add_dquanity_from_stock_to_Factory;
                }
                else
                {
                    dquantity_to_put_fromfactory = dQuantityInBasket_FromFactory + 1;
                }


                if (dquantity_to_put_fromfactory > 0)
                {
                    // Add from factory

                    m_ShopBC.m_CurrentDoc.m_Basket.Add(m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                this,
                                                                                idata,
                                                                                dquantity_to_put_fromfactory,
                                                                                0,
                                                                                ref appisd, true);
                    m_usrc_Atom_ItemsList1366x768.AddFromFactory(appisd);
                }

                if (dquantity_to_put_fromfactory + dquantity_to_put_fromstock > 0)
                {
                    m_usrc_Atom_ItemsList1366x768.ShowBasket(appisd.Atom_Item_UniqueName.v);
                    if (ItemAdded != null)
                    {
                        ItemAdded();
                    }
                }

                if (appisd != null)
                {
                    if (appisd.Atom_Item_UniqueName != null)
                    {
                        this.usrc_Item_TextSearch1.Item_UniqueName = appisd.Atom_Item_UniqueName.v;
                        this.usrc_Item_TextSearch1.ShowGroup(appisd.s1_name, appisd.s2_name, appisd.s3_name);
                    }
                }
            }
        }

        private struct FromStockQuantity
        {
            public decimal dQuantity;
            public ID Stock_ID;
            public FromStockQuantity(decimal dquantity, ID stock_ID)
            {
                dQuantity = dquantity;
                Stock_ID = stock_ID;
            }
        }


        private bool take_from_Stock(DataTable dtStock_of_ShopC_Item,
                                     decimal dQuantityToGetFromStock,
                                     List<FromStockQuantity> stocks,
                                     ref decimal dquantity_not_taken_from_stock)
        {
            decimal dquantity_to_take_from_stock = dQuantityToGetFromStock;
            int icount = dtStock_of_ShopC_Item.Rows.Count;
            for (int i = 0; i < icount; i++)
            {
                DataRow dr = dtStock_of_ShopC_Item.Rows[i];
                decimal_v dquantity_in_stock_v = tf.set_decimal(dr["dQuantity"]);
                if (dquantity_in_stock_v != null)
                {
                    ID Stock_ID = tf.set_ID(dr["Stock_ID"]);
                    if (dquantity_to_take_from_stock >= dquantity_in_stock_v.v)
                    {
                        dquantity_to_take_from_stock -= dquantity_in_stock_v.v;
                        if (f_Stock.UpdateQuantity(Stock_ID, 0))
                        {
                            FromStockQuantity stq = new FromStockQuantity(dquantity_in_stock_v.v, Stock_ID);
                            stocks.Add(stq);
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        decimal dQuantity_left_in_stock = dquantity_in_stock_v.v - dquantity_to_take_from_stock;
                        dquantity_to_take_from_stock = 0;
                        if (f_Stock.UpdateQuantity(Stock_ID, dQuantity_left_in_stock))
                        {
                            FromStockQuantity stq = new FromStockQuantity(dquantity_in_stock_v.v, Stock_ID);
                            stocks.Add(stq);
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            dquantity_not_taken_from_stock = dquantity_to_take_from_stock;
            return true;
        }

        private void IncrementBasket(Control ctrl, object oData, int index)
        {
            frmplus.Flash(ctrl);
            if (oData is Item_Data)
            {
                Item_Data xData = (Item_Data)oData;


                DataTable dtDoc_ShopC_Item = null;

                if (this.m_ShopBC.IsDocInvoice)
                {
                    if (!f_DocInvoice_ShopC_Item.GetItems(this.m_ShopBC.m_CurrentDoc.Doc_ID, xData.Item_ID, ref dtDoc_ShopC_Item))
                    {
                        LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:f_DocInvoice_ShopC_Item.GetItems failed!");
                        return;
                    }
                }
                else
                {
                    if (!f_DocProformaInvoice_ShopC_Item.GetItems(this.m_ShopBC.m_CurrentDoc.Doc_ID, xData.Item_ID, ref dtDoc_ShopC_Item))
                    {
                        LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:f_DocProformaInvoice_ShopC_Ite.GetItems failed!");
                        return;
                    }
                }


                //decimal_v ExtraDiscount = tf.set_decimal("ExtraDiscount"
                //RetailPriceWithDiscount,
                //TaxPrice,
                //DocInvoice_ID
                //Atom_Price_Item_ID,
                //ExpiryDate,


                decimal dQuantity_FromStock = 0;
                decimal dQuantity_FromFactory = 0;

                getQuantities(dtDoc_ShopC_Item, ref dQuantity_FromStock, ref dQuantity_FromFactory);
                

                DataTable dtStock_of_ShopC_Item = null;
                if (!f_Stock.GetItemInStock(xData.Item_ID,ref dtStock_of_ShopC_Item))
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:f_Stock.GetItemInStock failed!");
                    return;
                }

                List<FromStockQuantity> stocks = new List<FromStockQuantity>();
                decimal dRemainderQuantityNotTakenFromStock = 0;
                if (take_from_Stock(dtStock_of_ShopC_Item,1, stocks,ref dRemainderQuantityNotTakenFromStock))
                {
                    if (stocks.Count>0)
                    {
                        if (!update_stock_elements_in_Doc_ShopC_Item(dtDoc_ShopC_Item,stocks))
                        {
                            LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:!update_stock_elements_in_Doc_ShopC_Item!");
                            return;
                        }
                    }
                }

                //if (dquantity_to_put_fromfactory + dquantity_to_put_fromstock > 0)
                //{
                //    m_usrc_Atom_ItemsList1366x768.ShowBasket(appisd.Atom_Item_UniqueName.v);
                //    if (ItemAdded != null)
                //    {
                //        ItemAdded();
                //    }
                //}

                //if (appisd != null)
                //{
                //    if (appisd.Atom_Item_UniqueName != null)
                //    {
                //        this.usrc_Item_TextSearch1.Item_UniqueName = appisd.Atom_Item_UniqueName.v;
                //        this.usrc_Item_TextSearch1.ShowGroup(appisd.s1_name, appisd.s2_name, appisd.s3_name);
                //    }
                //}
            }
        }

        private bool update_stock_elements_in_Doc_ShopC_Item(DataTable dtDoc_ShopC_Item, Item_Data xData, List<FromStockQuantity> stocks)
        {
            foreach (FromStockQuantity stq in stocks)
            {
                ID Doc_ShopC_Item_ID = null;
                decimal dqunatity_current = 0;
                if (find_Doc_ShopC_Item_ID(dtDoc_ShopC_Item,stq.Stock_ID,ref dqunatity_current,ref Doc_ShopC_Item_ID))
                {
                    decimal dquantity_new = dqunatity_current + stq.dQuantity;
                    if (m_ShopBC.IsDocInvoice)
                    {
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

                        }
                    }
                }
                else
                {
                    //stock element that is currently not in Doc_ShopC_Item
                    Doc_ShopC_Item_ID = tf.set_ID(dtDoc_ShopC_Item.Rows[0]["DocInvoice_ShopC_Item_ID"]);
                    if (m_ShopBC.IsDocInvoice)
                    {
                        //decimal_v retailPricePerunit
                        //f_Price_Item.Get(xData.Item_ID,
                        //                 xData.PriceList_ID,
                        //                 ref xData.RetailPricePerUnit,
                        //                 ref xData.Taxation_Name,
                        //                 ref xData.Taxation_Rate,

                        decimal retailPricePerunit = 0;
                        if (xData.RetailPricePerUnit!=null)
                        {
                            retailPricePerunit = xData.RetailPricePerUnit.v;
                        }
                        decimal taxRate = 0;
                        if (xData.Taxation_Rate != null)
                        {
                            taxRate = xData.Taxation_Rate.v;
                        }
                        xData.
                        decimal retailPriceWithDisount = decimal.Round(retailPricePerunit * stq.dQuantity * (1 - xData.ExtraDiscount),GlobalData.BaseCurrency.DecimalPlaces);
                        decimal netprice = decimal.Round(retailPriceWithDisount / (1 + taxRate), GlobalData.BaseCurrency.DecimalPlaces);
                        decimal taxprice = retailPriceWithDisount - netprice;


                        if (!f_DocInvoice_ShopC_Item.Insert(Doc_ShopC_Item_ID,
                                                            stq.dQuantity,
                                                            retailPriceWithDisount,
                                                            taxprice,
                                                            this.m_ShopBC.m_CurrentDoc.Doc_ID,
                                                            
                                                            stq.Stock_ID))
                        {
                            LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:!f_DocInvoice_ShopC_Item.InsertWithCopyFirst");
                            return false;
                        }

                    }
                }
            return true;
        }

        private bool find_Doc_ShopC_Item_ID(DataTable dtDoc_ShopC_Item, ID stock_ID,ref decimal dquantity, ref ID doc_ShopC_Item_ID)
        {
            dquantity = 0;
            foreach (DataRow dr in dtDoc_ShopC_Item.Rows)
            {
                ID doc_Shopc_Item_stock_ID = tf.set_ID(dr["Stock_ID"]);
                if (ID.Validate(doc_Shopc_Item_stock_ID))
                {
                    if (doc_Shopc_Item_stock_ID.Equals(stock_ID))
                    {
                        decimal_v dq_v = tf.set_decimal(dr["dQuantity"]);
                        if (dq_v != null)
                        {
                            dquantity = dq_v.v;
                        }
                        doc_ShopC_Item_ID = tf.set_ID(dr["DocInvoice_ShopC_Item_ID"]);
                        return true;
                    }
                }
            }
            return false;
        }

        private void getQuantities(DataTable dtDoc_ShopC_Item, ref decimal dQuantity_FromStock, ref decimal dQuantity_FromFactory)
        {
            dQuantity_FromStock = 0;
            dQuantity_FromFactory = 0;
            int icount = dtDoc_ShopC_Item.Rows.Count;
            for (int i =0;i< icount;i++)
            {
                DataRow dr = dtDoc_ShopC_Item.Rows[i];
                ID stock_ID = tf.set_ID(dr["Stock_ID"]);
                if (ID.Validate(stock_ID))
                {
                    decimal_v quantity_from_stock_v = tf.set_decimal(dr["dQuantity"]);
                    if (quantity_from_stock_v!=null)
                    {
                        dQuantity_FromStock += quantity_from_stock_v.v;
                    }
                }
                else
                {
                    decimal_v quantity_from_factory_v = tf.set_decimal(dr["dQuantity"]);
                    if (quantity_from_factory_v != null)
                    {
                        dQuantity_FromFactory += quantity_from_factory_v.v;
                    }
                }
            }
        }

        private void Usrc_Item_InsidePageGroupHandler1_SelectionChanged(Control ctrl, object oData, int index)
        {
            IncrementBasket(ctrl, oData, index);
        }
        private void Usrc_Item_InsidePageGroupHandler1_ControlClick(Control ctrl, object oData, int index, bool selected)
        {
            IncrementBasket(ctrl, oData, index);
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
            frmplus = new Form_plus();
            frmplus.Owner = Global.f.GetParentForm(this);
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
    }
}
