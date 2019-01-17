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
using ShopC_Forms;

namespace ShopC_Forms
{
    public partial class usrc_Atom_ItemsList : UserControl
    {
        public ID m_Atom_WorkPeriod_ID = null;

        public usrc_Atom_Item[] usrc_Atom_Item_array = null;

        public int yPosLast = 5;

        private usrc_ItemList m_usrc_ItemList = null;


        public ConsumptionEditor ConsE;
        private DBTablesAndColumnNamesOfConsumption DBtcn;

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


        public string DocTyp
        {
            get { return ConsE.DocTyp; }
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
        private int default_usrc_Item_InsidePageHandler_ItemAtomList_Width;

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

        public usrc_Atom_ItemsList()
        {
            InitializeComponent();
            default_usrc_Item_InsidePageHandler_ItemAtomList_Width = usrc_Item_InsidePageHandler_ItemAtomList.Width;
            this.usrc_Item_InsidePageHandler_ItemAtomList.CreateControl += Usrc_Item_InsidePageHandler1_CreateControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.FillControl += Usrc_Item_InsidePageHandler1_FillControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectControl += Usrc_Item_InsidePageHandler1_SelectControl;
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectionChanged += Usrc_Item_InsidePageHandler1_SelectionChanged;
            this.usrc_Item_InsidePageHandler_ItemAtomList.Paint += Usrc_Item_InsidePageHandler1_Paint;
            this.usrc_Item_InsidePageHandler_ItemAtomList.CompareWithString += Usrc_Item_InsidePageHandler_ItemAtomList_CompareWithString;
        }

        private bool Usrc_Item_InsidePageHandler_ItemAtomList_CompareWithString(object oData, string s)
        {
            if (oData is TangentaDB.Consumption_ShopC_Item)
            {
                TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                if (dsci!=null)
                {
                    if (dsci.Atom_Item_UniqueName_v != null)
                    {
                        return dsci.Atom_Item_UniqueName_v.v.Equals(s);
                    }
                }
            }
            return false;
        }

        private void Usrc_Item_InsidePageHandler1_Paint(Control ctrl, object oData, int index, usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode xmode)
        {
            if (oData is TangentaDB.Consumption_ShopC_Item)
            {
                TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                if (ctrl is usrc_Atom_Item)
                {
                    usrc_Atom_Item xusrc_Atom_Item = (usrc_Atom_Item)ctrl;
                    xusrc_Atom_Item.DoPaint(dsci, xmode);
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectionChanged(Control ctrl, object oData, int index, bool selected)
        {
            object oidata = null;
            Control oxusrc_Item = null;
            if (ctrl != null)
            {
                if (oData is TangentaDB.Consumption_ShopC_Item)
                {
                    TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                    if (this.Parent is usrc_ShopC)
                    {
                        ((usrc_ShopC)this.Parent).m_usrc_ItemList.Select(dsci, dsci.Atom_Item_UniqueName_v.v, ref oidata,ref oxusrc_Item);
                        if (SelectionChanged!=null)
                        {
                            SelectionChanged(ctrl,index, oData,oidata, oxusrc_Item);
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
                        SelectionChanged(ctrl,index, oData, oidata, oxusrc_Item);
                   }
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_SelectControl(Control ctrl, object oData, int index, bool selected)
        {
            if (ctrl is usrc_Atom_Item)
            {
                usrc_Atom_Item xusrc_Atom_Item = (usrc_Atom_Item)ctrl;
                xusrc_Atom_Item.SelectControl(oData, selected);

                if (oData is TangentaDB.Consumption_ShopC_Item)
                {
                    TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_FillControl(Control ctrl, object oData, usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode emode)
        {
            if (oData is TangentaDB.Consumption_ShopC_Item)
            {
                TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                if (ctrl is usrc_Atom_Item)
                {
                    usrc_Atom_Item xusrc_Atom_Item = (usrc_Atom_Item)ctrl;
                    xusrc_Atom_Item.DoPaint(dsci, emode);
                }
            }
        }

        private void Usrc_Item_InsidePageHandler1_CreateControl(ref Control ctrl)
        {
            usrc_Atom_Item xusrc_Atom_Item = new usrc_Atom_Item();
            xusrc_Atom_Item.btn_RemoveClick += Xusrc_Atom_Item_btn_RemoveClick;
            ctrl = xusrc_Atom_Item;
        }

        public void RemoveItem(string sItemUniqueName, ref decimal dQuantityInBasket_FromStock,ref decimal dQuantityInBasket_FromFactory)
        {
            int index = usrc_Item_InsidePageHandler_ItemAtomList.FindItem(sItemUniqueName);
            if (index>=0)
            {
                object oData = usrc_Item_InsidePageHandler_ItemAtomList.GetItem(index);
                if (oData is TangentaDB.Consumption_ShopC_Item)
                {
                    TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)oData;
                    dQuantityInBasket_FromStock = dsci.dQuantity_FromStock;
                    dQuantityInBasket_FromFactory = dsci.dQuantity_FromFactory;
                    RemoveItem(dsci);
                }
            }
        }

        public bool RemoveItem(TangentaDB.Consumption_ShopC_Item dsci)
        {

            Item_Data xdata =this.ConsE.m_CurrentConsumption.m_ShopShelf.FindItem(dsci);
            //if usrc_ItemList is showing different group of items to dsci then xdata=null
            Transaction transaction_usrc_ItemAtomsList_RemoveItem = DBSync.DBSync.NewTransaction("usrc_ItemAtomsList.RemoveItem");
            if (this.ConsE.m_CurrentConsumption.m_Basket.RemoveItem(DocTyp, dsci, xdata, transaction_usrc_ItemAtomsList_RemoveItem))
            {
                if (transaction_usrc_ItemAtomsList_RemoveItem.Commit())
                {
                    return true;
                }
            }
            else
            {
                transaction_usrc_ItemAtomsList_RemoveItem.Rollback();
            }
            return false;
        }
    

        private void Xusrc_Atom_Item_btn_RemoveClick(TangentaDB.Consumption_ShopC_Item dsci)
        {
            if (RemoveItem(dsci))
            {
                usrc_Item_InsidePageHandler_ItemAtomList.Init(this.ConsE.m_CurrentConsumption.m_Basket.Basket_Consumption_ShopC_Item_LIST, usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode.EDIT);
                usrc_Item_InsidePageHandler_ItemAtomList.ShowPage(0);
                if (this.Parent is usrc_ShopC)
                {
                    ((usrc_ShopC)this.Parent).m_usrc_ItemList.DoRepaint();
                }
                if (After_Atom_Item_Remove != null)
                {
                    After_Atom_Item_Remove();
                }
            }
        }

        internal void Init(ID xAtom_WorkPeriod_ID,
                           usrc_ItemList x_usrc_ItemList,
                           ConsumptionEditor xconsE, 
                           DBTablesAndColumnNamesOfConsumption xDBtcn)
        {
            m_usrc_ItemList = x_usrc_ItemList;
            ConsE= xconsE;
            DBtcn = xDBtcn;
            Init(xAtom_WorkPeriod_ID);
        }

        internal void ShowBasket(string xItemUniqueName,object oidata, Control oidata_control)
        {
            usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode emode = usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode.EDIT;
            if (!ConsE.m_CurrentConsumption.bDraft)
            {
                emode = usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode.VIEW;
            }
            this.usrc_Item_InsidePageHandler_ItemAtomList.Init(ConsE.m_CurrentConsumption.m_Basket.Basket_Consumption_ShopC_Item_LIST,emode);
            object odata = null;
            Control ctrl = null;
            int index = this.usrc_Item_InsidePageHandler_ItemAtomList.FindItem(xItemUniqueName, ref odata, ref ctrl);
            if (index >= 0)
            {
                this.usrc_Item_InsidePageHandler_ItemAtomList.SelectObject(index,usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eSelection.ON_REMOTE);
                if (SelectionChanged != null)
                {
                    SelectionChanged(ctrl,index, odata, oidata, oidata_control);
                }
            }
            //this.usrc_Item_InsidePageHandler1.ShowPage(0);
        }

        internal void SetCurrentInvoice_SelectedItems()
        {
            usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode emode = usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode.EDIT;
            if (!ConsE.m_CurrentConsumption.bDraft)
            {
                emode = usrc_Item_InsidePageHandler<TangentaDB.Consumption_ShopC_Item>.eMode.VIEW;
            }
            string sinfo = "";
            if (ConsE.m_CurrentConsumption.bDraft)
            {
                sinfo = myOrg.m_myOrg_Office.ShortName_v.v+"-"+ myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name+"-"+lng.s_Draft.s+":"+ ConsE.m_CurrentConsumption.DraftNumber.ToString()+"/"+ ConsE.m_CurrentConsumption.FinancialYear.ToString();
            }
            else
            {
                bool bstorno = false;
                if (ConsE.m_CurrentConsumption.TInvoice.bStorno_v!=null)
                {
                    bstorno = ConsE.m_CurrentConsumption.TInvoice.bStorno_v.v;
                }
                if (bstorno)
                {
                    sinfo = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(myOrg.m_myOrg_Office.ShortName_v.v,
                                                                                    myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name,
                                                                                    ConsE.m_CurrentConsumption.NumberInFinancialYear,
                                                                                    ConsE.m_CurrentConsumption.FinancialYear,
                                                                                    bstorno,
                                                                                    lng.s_StornoConsumption.s
                                                                                    );
                }
                else
                {
                    sinfo = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(myOrg.m_myOrg_Office.ShortName_v.v,
                                                                                    myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name,
                                                                                    ConsE.m_CurrentConsumption.NumberInFinancialYear,
                                                                                    ConsE.m_CurrentConsumption.FinancialYear,
                                                                                    false,
                                                                                    null
                                                                                    );
                }

            }


            lbl_InvoiceInfo.Text = lng.s_DocInvoice.s + ":" + sinfo;

            this.usrc_Item_InsidePageHandler_ItemAtomList.Init(ConsE.m_CurrentConsumption.m_Basket.Basket_Consumption_ShopC_Item_LIST, emode);
            this.usrc_Item_InsidePageHandler_ItemAtomList.ShowPage(0);
        }



        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            usrc_Atom_Item usrc_atom_item = (usrc_Atom_Item)o_usrc;
            if (bVisible)
            {
                TangentaDB.Consumption_ShopC_Item dsci = (TangentaDB.Consumption_ShopC_Item)o_data;
                usrc_atom_item.DoPaint(dsci,this.usrc_Item_InsidePageHandler_ItemAtomList.Mode);
                usrc_atom_item.Visible = true;
                usrc_atom_item.Enabled = true;
            }
            else
            {
                usrc_atom_item.Visible = false;
                usrc_atom_item.Enabled = false;
            }

        }


        internal void AddFromStock(TangentaDB.Consumption_ShopC_Item dsci)
        {
            //if (m_ShopBC.m_CurrentConsumption.Add_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,true))
            //{
            //    int index = m_ShopBC.m_CurrentConsumption.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            //}
        }

        internal void AddFromFactory(TangentaDB.Consumption_ShopC_Item dsci)
        {
            //if (m_ShopBC.m_CurrentConsumption.Add_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp,ref appisd,false))
            //{
            //    int index = m_ShopBC.m_CurrentConsumption.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
            //}
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (XMessage.Box.Show(this, lng.s_Are_Sure_To_Remove_All_From_Basket, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                Transaction transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty = DBSync.DBSync.NewTransaction("usrc_ItemAtomsList.btn_ClearAll_Click.Empty");
                if (ConsE.m_CurrentConsumption.m_Basket.Empty(ConsE.m_CurrentConsumption.Doc_ID,
                                                         DocTyp, ConsE.m_CurrentConsumption.m_ShopShelf,
                                                         transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty))
                {
                    transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty.Commit();
                }
                else
                {
                    transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty.Rollback();
                }
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
            Form_ShopC_TableInspection.DoShow(pform);
        }

        private void usrc_Item_InsidePageHandler_ItemAtomList_Resize(object sender, EventArgs e)
        {
            if (default_usrc_Item_InsidePageHandler_ItemAtomList_Width != usrc_Item_InsidePageHandler_ItemAtomList.Width)
            {
                usrc_Item_InsidePageHandler_ItemAtomList.Width = default_usrc_Item_InsidePageHandler_ItemAtomList_Width;
                usrc_Item_InsidePageHandler_ItemAtomList.Left = 0;
                usrc_Item_InsidePageHandler_ItemAtomList.Visible = true;
                //MessageBox.Show("default_usrc_Item_InsidePageHandler_ItemAtomList_Width=" + default_usrc_Item_InsidePageHandler_ItemAtomList_Width.ToString() +
                //                "\r\n usrc_Item_InsidePageHandler_ItemAtomList.Width =" + usrc_Item_InsidePageHandler_ItemAtomList.Width.ToString());
            }
        }
    }
}
