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

        public string DocTyp
        {
            get { return m_ShopBC.DocTyp; }
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
            usrc_Atom_Item_array = null;
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
                Transaction transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFactory = DBSync.DBSync.NewTransaction("usrc_ItemAtomList.usrc_Atom_Item_RemoveClick.RemoveFactory");
                if (this.m_ShopBC.m_CurrentDoc.m_Basket.RemoveFactory(DocTyp,x_usrc_Atom_Item.m_dsci, transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFactory))
                {
                    if (transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFactory.Commit())
                    {
                        if (m_usrc_ItemList.Show(x_usrc_Atom_Item.m_dsci))
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
                }
                else
                {
                    transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFactory.Rollback();
                    LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:this.m_InvoiceDB.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST.Remove(x_usrc_Atom_Item.m_appisd) failed !");
                }
            }
            else
            {
                //if (this.m_ShopBC.m_CurrentDoc.m_Basket.Remove_and_put_back_to_ShopShelf(m_Atom_WorkPeriod_ID,DocTyp, x_usrc_Atom_Item.m_dsci, this.m_ShopBC.m_CurrentDoc.m_ShopShelf))
                //m_usrc_ItemList.SetGroup(new string[] { x_usrc_Atom_Item.m_dsci.s1_name, x_usrc_Atom_Item.m_dsci.s2_name, x_usrc_Atom_Item.m_dsci.s3_name });
                if (m_usrc_ItemList.Show(x_usrc_Atom_Item.m_dsci))
                {
                    Item_Data xData = this.m_ShopBC.m_CurrentDoc.m_ShopShelf.Get_Item_Data(x_usrc_Atom_Item.m_dsci);
                    if (xData != null)
                    {
                        Transaction transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFromBasket_And_put_back_to_Stock = DBSync.DBSync.NewTransaction("usrc_ItemAtomList.usrc_Atom_Item_RemoveClick.RemoveFromBasket_And_put_back_to_Stock");
                        if (this.m_ShopBC.m_CurrentDoc.m_Basket.RemoveFromBasket_And_put_back_to_Stock(DocTyp,
                                                                                                       m_ShopBC.m_CurrentDoc.Doc_ID,
                                                                                                       x_usrc_Atom_Item.m_dsci.dQuantity_FromStock,
                                                                                                       xData,
                                                                                                       transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFromBasket_And_put_back_to_Stock))
                        {
                            if (transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFromBasket_And_put_back_to_Stock.Commit())
                            {
                                if (m_usrc_ItemList.Show(x_usrc_Atom_Item.m_dsci))
                                {
                                    m_usrc_Item_PageHandler.DoPaint();
                                    if (After_Atom_Item_Remove != null)
                                    {
                                        After_Atom_Item_Remove();
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:1:m_usrc_ItemList.Show(x_usrc_Atom_Item.m_appisd failed !");
                                }
                            }
                        }
                        else
                        {
                            transaction_usrc_ItemAtomList_usrc_Atom_Item_RemoveClick_RemoveFromBasket_And_put_back_to_Stock.Rollback();
                            LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:this.m_InvoiceDB.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST.Remove(x_usrc_Atom_Item.m_appisd) failed !");
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:Item_Data == null");
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrs_ItemAtomsList:usrc_Atom_Item_RemoveClick:1:m_usrc_ItemList.Show(x_usrc_Atom_Item.m_appisd failed !");
                }
            }
            this.btn_ClearAll.Visible = this.m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST.Count > 0;
        }


        internal void SetCurrentInvoice_SelectedItems()
        {

            m_usrc_Item_PageHandler.Init(m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST, 5, usrc_Atom_Item_array);
            //this.m_usrc_ItemList.Reset();
            if (this.m_ShopBC.m_CurrentDoc.bDraft)
            {
                this.btn_ClearAll.Visible = this.m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST.Count > 0;
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
                Doc_ShopC_Item dsci = (Doc_ShopC_Item)o_data;
                usrc_atom_item.DoPaint(this.m_ShopBC,dsci);
                usrc_atom_item.Visible = true;
                usrc_atom_item.Enabled = true;
            }
            else
            {
                usrc_atom_item.Visible = false;
                usrc_atom_item.Enabled = false;
            }

        }


        internal usrc_Atom_Item AddFromStock(TangentaDB.Doc_ShopC_Item dsci)
        {
            int index = m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST.IndexOf(dsci);
            usrc_Atom_Item usrc_itema = (usrc_Atom_Item)m_usrc_Item_PageHandler.Show(index);
            if (usrc_itema != null)
            {
                pnl_Atom_Items.ScrollControlIntoView(usrc_itema);
            }
            this.btn_ClearAll.Visible = true;
            return usrc_itema;
        }

        internal usrc_Atom_Item AddFromFactory(TangentaDB.Doc_ShopC_Item dsci)
        {
            int index = m_ShopBC.m_CurrentDoc.m_Basket.Basket_Doc_ShopC_Item_LIST.IndexOf(dsci);
            usrc_Atom_Item usrc_itema = (usrc_Atom_Item)m_usrc_Item_PageHandler.Show(index);
            if (usrc_itema!=null)
            {
                pnl_Atom_Items.ScrollControlIntoView(usrc_itema);
            }
            this.btn_ClearAll.Visible = true;
            return usrc_itema;
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (XMessage.Box.Show(this, lng.s_Are_Sure_To_Remove_All_From_Basket, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                Transaction transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty = DBSync.DBSync.NewTransaction("usrc_ItemAtomsList.btn_ClearAll_Click.Empty");
                if (m_ShopBC.m_CurrentDoc.m_Basket.Empty(m_Atom_WorkPeriod_ID,
                                                         DocTyp,
                                                         m_ShopBC.m_CurrentDoc.m_ShopShelf,
                                                         transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty))
                {
                    if (transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty.Commit())
                    {
                        m_usrc_Item_PageHandler.DoPaint();
                        m_usrc_ItemList.DoPaint();
                        this.Cursor = Cursors.Arrow;
                        btn_ClearAll.Visible = false;
                    }
                }
                else
                {
                    transaction_usrc_ItemAtomsList_btn_ClearAll_Click_Empty.Rollback();
                }
            }
        }

        internal void Clear()
        {
            
        }
    }
}
