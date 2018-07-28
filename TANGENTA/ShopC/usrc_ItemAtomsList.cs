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

namespace ShopC
{
    public partial class usrc_Atom_ItemsList : UserControl
    {
        public ID m_Atom_WorkPeriod_ID = null;

        public usrc_Atom_Item[] usrc_Atom_Item_array = null;

        public int yPosLast = 5;

        private usrc_ItemList m_usrc_ItemList = null;
        public TangentaDB.ShopABC m_ShopBC;
        private DBTablesAndColumnNames DBtcn;

        public delegate void delegate_After_Atom_Item_Remove();
        public event delegate_After_Atom_Item_Remove After_Atom_Item_Remove = null;


        public long Item_ID = -1;

        private string m_DocInvoice = "DocInvoice";

        public string DocInvoice
        {
            get { return m_DocInvoice; }
            set
            {
                m_DocInvoice = value;
            }
        }

        public bool IsDocInvoice
        {
            get
            { return DocInvoice.Equals("DocInvoice"); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocInvoice.Equals("DocProformaInvoice"); }
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
            if (usrc_Atom_Item_array==null)
            { 
                usrc_Atom_Item_array = new usrc_Atom_Item[NumberOfItemsPerPage];

                int i = 0;
                int yPos = 0;
                for (i = 0; i < m_NumberOfItemsPerPage; i++)
                {
                    usrc_Atom_Item xusrc_Atom_Item = new usrc_Atom_Item();
                    xusrc_Atom_Item.btn_RemoveClick += usrc_Atom_Item_RemoveClick; 
                    xusrc_Atom_Item.Top = yPos;
                    xusrc_Atom_Item.Left = 5;
                    xusrc_Atom_Item.Width = this.pnl_Atom_Items.Width - 10;
                    xusrc_Atom_Item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    xusrc_Atom_Item.Visible = false;
                    yPos += xusrc_Atom_Item.Height + 1;
                    //usrc_item.ItemAdded += new usrc_Item.delegate_ItemAdded(usrc_item_ItemAdded);
                    usrc_Atom_Item_array[i] = xusrc_Atom_Item;
                    this.pnl_Atom_Items.Controls.Add(xusrc_Atom_Item);
                }
            }
        }

        public usrc_Atom_ItemsList()
        {
            InitializeComponent();
        }

        internal void Init(ID xAtom_WorkPeriod_ID,usrc_ItemList x_usrc_ItemList, TangentaDB.ShopABC xm_InvoiceDB, DBTablesAndColumnNames xDBtcn)
        {
            m_usrc_ItemList = x_usrc_ItemList;
            m_ShopBC=xm_InvoiceDB;
            DBtcn = xDBtcn;
            // pias_Atom_Item_List.Clear();
            Init(xAtom_WorkPeriod_ID);
        }



        internal void usrc_Atom_Item_RemoveClick(usrc_Atom_Item x_usrc_Atom_Item, bool bFactory)
        {
            if (bFactory)
            {
                if (this.m_ShopBC.m_CurrentInvoice.m_Basket.RemoveFactory(DocInvoice,x_usrc_Atom_Item.m_appisd))
                {
                    if (m_usrc_ItemList.Show(x_usrc_Atom_Item.m_appisd))
                    {
                        m_usrc_Item_PageHandler.DoPaint();
                        if (After_Atom_Item_Remove!=null)
                        {
                            After_Atom_Item_Remove();
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:m_usrc_ItemList.ShowFactory(x_usrc_Atom_Item.m_appisd failed !");
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:this.m_InvoiceDB.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST.Remove(x_usrc_Atom_Item.m_appisd) failed !");
                }
            }
            else
            {
                if (this.m_ShopBC.m_CurrentInvoice.m_Basket.Remove_and_put_back_to_ShopShelf(m_Atom_WorkPeriod_ID,DocInvoice, x_usrc_Atom_Item.m_appisd, this.m_ShopBC.m_CurrentInvoice.m_ShopShelf))
                {
                    if (m_usrc_ItemList.Show(x_usrc_Atom_Item.m_appisd))
                    {
                        m_usrc_Item_PageHandler.DoPaint();
                        if (After_Atom_Item_Remove != null)
                        {
                            After_Atom_Item_Remove();
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:m_usrc_ItemList.ShowFactory(x_usrc_Atom_Item.m_appisd failed !");
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:this.m_InvoiceDB.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST.Remove(x_usrc_Atom_Item.m_appisd) failed !");
                }
            }
            this.btn_ClearAll.Visible = this.m_ShopBC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Count > 0;
        }


        internal void SetCurrentInvoice_SelectedItems()
        {

            m_usrc_Item_PageHandler.Init(m_ShopBC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST, 5, usrc_Atom_Item_array);
            this.m_usrc_ItemList.Reset();
            if (this.m_ShopBC.m_CurrentInvoice.bDraft)
            {
                this.btn_ClearAll.Visible = this.m_ShopBC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Count > 0;
            }
            else
            {
                this.btn_ClearAll.Visible = false;
            }
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


        internal usrc_Atom_Item AddFromStock(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            if (m_ShopBC.m_CurrentInvoice.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocInvoice,ref appisd,true))
            {
                int index = m_ShopBC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
                usrc_Atom_Item usrc_itema = (usrc_Atom_Item)m_usrc_Item_PageHandler.Show(index);
                if (usrc_itema != null)
                {
                    pnl_Atom_Items.ScrollControlIntoView(usrc_itema);
                }
                this.btn_ClearAll.Visible = true;
                return usrc_itema;
            }
            else
            {
                return null;
            }
        }

        internal usrc_Atom_Item AddFromFactory(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {

            if (m_ShopBC.m_CurrentInvoice.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocInvoice,ref appisd,false))
            {

                int index = m_ShopBC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.IndexOf(appisd);
                usrc_Atom_Item usrc_itema = (usrc_Atom_Item)m_usrc_Item_PageHandler.Show(index);
                if (usrc_itema!=null)
                {
                    pnl_Atom_Items.ScrollControlIntoView(usrc_itema);
                }
                this.btn_ClearAll.Visible = true;
                return usrc_itema;
            }
            else
            {
                return null;
            }
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (XMessage.Box.Show(this, lng.s_Are_Sure_To_Remove_All_From_Basket, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                m_ShopBC.m_CurrentInvoice.m_Basket.Empty(m_Atom_WorkPeriod_ID,DocInvoice, m_ShopBC.m_CurrentInvoice.m_ShopShelf);
                m_usrc_Item_PageHandler.DoPaint();
                m_usrc_ItemList.Reset();
                this.Cursor = Cursors.Arrow;
                btn_ClearAll.Visible = false;
            }
        }

        internal void Clear()
        {
            
        }
    }
}
