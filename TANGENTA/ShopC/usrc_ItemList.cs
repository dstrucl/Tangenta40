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

namespace ShopC
{
    public partial class usrc_ItemList : UserControl
    {
        private ID m_Atom_WorkPeriod_ID = null;
        private string m_DocTyp = "";

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

        public int SplitContainer1_spd
        {
            get
            {
                return splitContainer1.SplitterDistance;
            }
            set
            {
                string Err = null;
                if (!StaticLib.Func.SetSplitContainerValue(splitContainer1, value, ref Err))
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_ItemList:SetSplitContainer 1 SplitterDistance:Err=" + Err);
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
            set
            {
                m_NumberOfItemsPerPage = value;
                Init(m_Atom_WorkPeriod_ID);
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

        public usrc_ShopC m_usrc_ItemMan = null;

        public usrc_Item[] usrc_Item_aray = null;
        usrc_Atom_ItemsList m_usrc_Atom_ItemsList = null;
        ShopABC m_ShopBC;
        DBTablesAndColumnNames DBtcn;
        int ipnl_Items_Width_default = -1;
        private ID m_PriceList_ID = null;


        public int NumberOfGroupLevels
        {
            get
            {
                if (m_usrc_Item_Group_Handler != null)
                {
                    return m_usrc_Item_Group_Handler.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
        }

        public usrc_ItemList()
        {
            InitializeComponent();
            ipnl_Items_Width_default = pnl_Items.Width;
        }

        private void Init(ID xAtom_WorkPeriod_ID)
        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;

            usrc_Item_aray = new usrc_Item[NumberOfItemsPerPage];

            int i = 0;
            int yPos = 0;
            while (pnl_Items.Controls.Count > 0)
            {
                Control ctrl = pnl_Items.Controls[0];
                this.pnl_Items.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            pnl_Items.AutoScrollOffset = new Point(0, 0);
            pnl_Items.AutoScrollPosition = new Point(0, 0);
            for (i = 0; i < m_NumberOfItemsPerPage; i++)
            {
                usrc_Item usrc_item = new usrc_Item(m_Atom_WorkPeriod_ID);
                usrc_item.m_usrc_ItemList = this;
                usrc_item.ExclusivelySellFromStock = this.ExclusivelySellFromStock;
                usrc_item.Top = yPos;
                usrc_item.Left = 5;
                usrc_item.Width = this.pnl_Items.Width - 10;
                usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                yPos += usrc_item.Height + 1;
                usrc_item.ItemAdded2Basket += new usrc_Item.delegate_ItemAdded2Basket(usrc_item_ItemAdded);
                usrc_item.ItemChanged += usrc_item_ItemChanged;
                usrc_item.StockChanged += usrc_item_StockChanged;
                usrc_item.BackColor = Colors.ItemFromStock.BackColor;
                usrc_item.ForeColor = Colors.ItemFromStock.ForeColor;
                usrc_Item_aray[i] = usrc_item;
                this.pnl_Items.Controls.Add(usrc_item);
            }
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.HorizontalScroll.Enabled = true;
            this.pnl_Items.VerticalScroll.Enabled = true;
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=TRUE");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:Init(..) Visible=FALSE");
            }
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

        internal void Init(ID xAtom_WorkPeriod_ID, TangentaDB.ShopABC xm_ShopBC, DBTablesAndColumnNames xDBtcn, usrc_ShopC x_usrc_ItemMan, bool xbExclusivelySellFromStock)
        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_ShopBC = xm_ShopBC;
            m_usrc_ItemMan = x_usrc_ItemMan;
            DBtcn = xDBtcn;
            this.m_usrc_Item_Group_Handler.ShopName = lng.s_ShopC_Name.s;
            m_bExclusivelySellFromStock = xbExclusivelySellFromStock;
            Init(m_Atom_WorkPeriod_ID);
        }

        public void Init(usrc_Atom_ItemsList x_usrc_Atom_ItemsList)
        {
            m_usrc_Atom_ItemsList = x_usrc_Atom_ItemsList;
        }


        void usrc_item_ItemAdded()
        {
            if (ItemAdded != null)
            {
                ItemAdded();
            }
        }




        public bool Get_Price_Item_Stock_Data(ID PriceList_ID)
        {
            m_PriceList_ID = PriceList_ID;
            if (m_ShopBC.m_CurrentDoc.m_ShopShelf.GetGroupsTable(PriceList_ID))
            {
                if (m_usrc_Item_Group_Handler.Set_Groups(m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group))
                {
                    splitContainer1.Panel2Collapsed = false;
                    string Err = null;
                    if (m_usrc_Item_Group_Handler.NumberOfGroupLevels > 1)
                    {

                        StaticLib.Func.SetSplitContainerValue(splitContainer1, splitContainer1.Width - 32, ref Err);

                    }
                    else
                    {
                        StaticLib.Func.SetSplitContainerValue(splitContainer1, splitContainer1.Width - 82, ref Err);
                    }

                    if (m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows.Count > 0)
                    {
                        string s1_name = null;
                        string s2_name = null;
                        string s3_name = null;
                        if (m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s1_name"] is string)
                        {
                            s1_name = (string)m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s1_name"];
                        }
                        if (m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s2_name"] is string)
                        {
                            s2_name = (string)m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s2_name"];
                        }
                        if (m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s3_name"] is string)
                        {
                            s3_name = (string)m_ShopBC.m_CurrentDoc.m_ShopShelf.dt_Price_Item_Group.Rows[0]["s3_name"];
                        }

                        string[] sGroup = new string[] { s1_name, s2_name, s3_name };
                        m_usrc_Item_Group_Handler.Select(sGroup);
                        return true;
                    }
                }
                else
                {
                    splitContainer1.Panel2Collapsed = true;
                    string[] sGroup = new string[] { null, null, null };
                    m_usrc_Item_Group_Handler.Select(sGroup);
                    return true;
                }
            }
            return false;
        }

        internal void HideGroupHandlerForm()
        {
            if (m_usrc_Item_Group_Handler!=null)
            {
                m_usrc_Item_Group_Handler.HideGroupHandlerForm();
            }
        }

        internal void Reset()
        {
            m_usrc_Item_PageHandler.DoPaint();

        }

        private void m_usrc_Item_PageHandler_ShowObject(int Item_id_index, object o_data, object o_usrc, bool bVisible)
        {
            if (this.Visible)
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=TRUE");
                usrc_Item usrc_item = (usrc_Item)o_usrc;
                if (bVisible)
                {
                    Item_Data iData = (Item_Data)o_data;
                    usrc_item.Visible = true;
                    usrc_item.Enabled = true;
                    usrc_item.DoPaint(iData, s_name_Group, m_usrc_Atom_ItemsList);
                }
                else
                {
                    usrc_item.Visible = false;
                    usrc_item.Enabled = false;
                }
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("-> usrc_ItemList:m_usrc_Item_PageHandler_ShowObject(..) Visible=FALSE");
            }
        }

        private void Paint_Group(string[] s_name)
        {
            if (m_ShopBC.m_CurrentDoc.m_ShopShelf.Load(m_PriceList_ID, s_name))
            {
                lbl_GroupPath.Text = m_usrc_Item_Group_Handler.GroupPath;
                m_usrc_Item_PageHandler.Init(m_ShopBC.m_CurrentDoc.m_ShopShelf.ListOfItems, 5, usrc_Item_aray);
            }
        }

        private void m_usrc_Item_Group_Handler_GroupChanged(string[] s_name)
        {
            s_name_Group = s_name;
            Paint_Group(s_name_Group);
        }

        public void Paint_Current_Group()
        {
            Paint_Group(s_name_Group);
        }


        internal bool Show(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            string[] sGroupArr = new string[3];
            sGroupArr[0] = appisd.s1_name;
            sGroupArr[1] = appisd.s2_name;
            sGroupArr[2] = appisd.s3_name;
            m_usrc_Item_Group_Handler.Select(sGroupArr);
            int index = m_ShopBC.m_CurrentDoc.m_ShopShelf.GetIndex(appisd);
            if (index >= 0)
            {
                m_usrc_Item_PageHandler.Show(index);
                return true;
            }
            return false;

        }

        private void m_usrc_Item_Group_Handler_GroupsRedefined(int Level)
        {
            if (Level == 0)
            {
                pnl_Items.Width = ipnl_Items_Width_default + m_usrc_Item_Group_Handler.Width + 2;
                m_usrc_Item_Group_Handler.SetVisible(false);
            }
            else
            {
                m_usrc_Item_Group_Handler.SetVisible(true);
                pnl_Items.Width = ipnl_Items_Width_default;
            }

        }
    }
}