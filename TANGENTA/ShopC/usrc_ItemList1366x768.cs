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
                if (std.dQuantity_from_stock != null)
                {
                    if (dquantity_to_take_from_stock >= std.dQuantity_from_stock.v)
                    {
                        dquantity_to_take_from_stock -= std.dQuantity_from_stock.v;
                        if (f_Stock.UpdateQuantity(std.Stock_ID, 0))
                        {
                            std.dQuantity_Taken_v = new decimal_v(std.dQuantity_from_stock.v);
                            if (std.dQuantity_New_in_Stock_v==null)
                            {
                                std.dQuantity_New_in_Stock_v = new decimal_v();
                            }
                            std.dQuantity_New_in_Stock_v.v = 0;
                            std.dQuantity_from_stock.v = 0;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        decimal dQuantity_left_in_stock = std.dQuantity_from_stock.v - dquantity_to_take_from_stock;
                        if (f_Stock.UpdateQuantity(std.Stock_ID, dQuantity_left_in_stock))
                        {
                            if (std.dQuantity_New_in_Stock_v == null)
                            {
                                std.dQuantity_New_in_Stock_v = new decimal_v();
                            }
                            std.dQuantity_New_in_Stock_v.v = dQuantity_left_in_stock;
                            std.dQuantity_from_stock.v = dQuantity_left_in_stock;
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
            dquantity_not_taken_from_stock = dquantity_to_take_from_stock;
            return true;
        }


        private bool Add_Doc_ShopC_Item(Item_Data xData,decimal xdQuantity,ID stock_ID)
        {
            ID atom_Taxation_ID = null;
            ID atom_Item_ID = null;
            ID atom_Price_Item_ID = null;
            if (!f_Atom_Price_Item.Get(xData.Item_UniqueName.v,
                xData.Item_Name,
                xData.Item_barcode,
                xData.Item_Description,
                xData.Expiry_ExpectedShelfLifeInDays,
                xData.Expiry_SaleBeforeExpiryDateInDays,
                xData.Expiry_DiscardBeforeExpiryDateInDays,
                xData.Expiry_Description,
                xData.Warranty_WarrantyDurationType,
                xData.Warranty_WarrantyDuration,
                xData.Warranty_WarrantyConditions,
                xData.Unit_Name,
                xData.Unit_Symbol,
                xData.Unit_DecimalPlaces,
                xData.Unit_StorageOption,
                xData.Unit_Description,
                xData.PriceList_Name,
                xData.Currency_Abbreviation,
                xData.Currency_Name,
                xData.Item_Image_Image_Hash,
                xData.Item_Image_Image_Data,
                xData.RetailPricePerUnit,
                xData.Price_Item_Discount,
                xData.Taxation_Name,
                xData.Taxation_Rate,
                ref atom_Taxation_ID,
                ref atom_Item_ID,
                ref atom_Price_Item_ID))
            {
                return false;
            }

            decimal retailPricePerunit = 0;
            if (xData.RetailPricePerUnit != null)
            {
                retailPricePerunit = xData.RetailPricePerUnit.v;
            }
            decimal taxRate = 0;
            if (xData.Taxation_Rate != null)
            {
                taxRate = xData.Taxation_Rate.v;
            }

            decimal retailPriceWithDisount = decimal.Round(retailPricePerunit * xdQuantity * (1 - xData.ExtraDiscount), GlobalData.BaseCurrency.DecimalPlaces);
            decimal netprice = decimal.Round(retailPriceWithDisount / (1 + taxRate), GlobalData.BaseCurrency.DecimalPlaces);
            decimal taxprice = retailPriceWithDisount - netprice;
            ID docInvoice_ShopC_Item = null;
            decimal_v extraDiscount_v = new decimal_v(xData.ExtraDiscount);

            if (m_ShopBC.IsDocInvoice)
            {
                if (!f_DocInvoice_ShopC_Item.Insert(xdQuantity,
                                                    extraDiscount_v,
                                                    retailPriceWithDisount,
                                                    taxprice,
                                                    this.m_ShopBC.m_CurrentDoc.Doc_ID,
                                                    atom_Price_Item_ID,
                                                    xData.ExpiryDate,
                                                    stock_ID,
                                                    ref docInvoice_ShopC_Item))
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:!f_DocInvoice_ShopC_Item.InsertWithCopyFirst");
                    return false;
                }
            }
            else
            {
                if (!f_DocProformaInvoice_ShopC_Item.Insert(xdQuantity,
                                                    extraDiscount_v,
                                                    retailPriceWithDisount,
                                                    taxprice,
                                                    this.m_ShopBC.m_CurrentDoc.Doc_ID,
                                                    atom_Price_Item_ID,
                                                    xData.ExpiryDate,
                                                    stock_ID,
                                                    ref docInvoice_ShopC_Item))
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:update_stock_elements_in_Doc_ShopC_Item:!f_DocInvoice_ShopC_Item.InsertWithCopyFirst");
                    return false;
                }
            }

            return true;
        }

        private bool update_stock_elements_in_Doc_ShopC_Item(DataTable dtDoc_ShopC_Item, 
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
                        if (find_Doc_ShopC_Item_ID(dtDoc_ShopC_Item, std.Stock_ID, ref dqunatity_current, ref Doc_ShopC_Item_ID))
                        {
                            decimal dquantity_new = dqunatity_current + std.dQuantity_Taken_v.v;
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
                                if (appisd != null)
                                {
                                    appisd.AddQuantity(Doc_ShopC_Item_ID, std.Stock_ID, std.dQuantity_Taken_v.v);
                                }
                            }
                        }
                        else
                        {
                            //stock element that is currently not in Doc_ShopC_Item
                            if (!Add_Doc_ShopC_Item(xData, std.dQuantity_Taken_v.v, std.Stock_ID))
                            {
                                return false;
                            }
                            if (appisd == null)
                            {
                                appisd = new Atom_DocInvoice_ShopC_Item_Price_Stock_Data();

                            }
                        }
                }
            }
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

                decimal dRemainderQuantityNotTakenFromStock = 0;
                decimal dquantity_in_stock_at_the_end = 0;

                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = m_ShopBC.m_CurrentDoc.m_Basket.Find(xData.Item_UniqueName.v);
                
                if (take_from_Stock(1,xData.Stock_Data_List, ref dRemainderQuantityNotTakenFromStock, ref dquantity_in_stock_at_the_end))
                {
                    if (xData.Stock_Data_List.Count > 0)
                    {
                        if (!update_stock_elements_in_Doc_ShopC_Item(dtDoc_ShopC_Item, xData))
                        {
                            LogFile.Error.Show("ERROR:ShopC:usrc_ItemList1366x768:IncrementBasket:!update_stock_elements_in_Doc_ShopC_Item!");
                            return;
                        }
                    }
                }


                if (dRemainderQuantityNotTakenFromStock>0)
                {

                    if (!Add_Doc_ShopC_Item(xData, dRemainderQuantityNotTakenFromStock,null))
                    {
                        return;
                    }
                }

               if (ctrl is usrc_Item1366x768)
                {
                    ((usrc_Item1366x768)ctrl).DoPaint(xData, m_ShopBC.m_CurrentDoc.m_Basket);
                }




                m_usrc_Atom_ItemsList1366x768.ShowBasket(xData.Item_UniqueName.v);
                if (ItemAdded != null)
                {
                    ItemAdded();
                }

                this.usrc_Item_TextSearch1.Item_UniqueName = xData.Item_UniqueName.v;
                this.usrc_Item_TextSearch1.ShowGroup(xData.s1_name, xData.s2_name, xData.s3_name);
            }
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
