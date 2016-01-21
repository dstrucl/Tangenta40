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
using InvoiceDB;

namespace ShopC
{
    public partial class usrc_ItemList : UserControl
    {

        public int m_NumberOfItemsPerPage = 10;
        public int NumberOfItemsPerPage
        {
            get { return m_NumberOfItemsPerPage; }
            set { m_NumberOfItemsPerPage = value;
                 Init();
                }
        }

        public string[] s_name_Group = null;

        public delegate void delegate_ItemAdded();
        public event delegate_ItemAdded ItemAdded = null;

        public usrc_ShopC m_usrc_ItemMan = null;

        public usrc_Item[] usrc_Item_aray = null;
        usrc_Atom_ItemsList m_usrc_Atom_ItemsList = null;
        ShopBC m_ShopBC;
        DBTablesAndColumnNames DBtcn;
        int ipnl_Items_Width_default = -1;
        private long m_PriceList_ID = -1;

        public usrc_ItemList()
        {
            InitializeComponent();
            ipnl_Items_Width_default = pnl_Items.Width;
        }

        private void Init()
        {
                      

            usrc_Item_aray = new usrc_Item[NumberOfItemsPerPage];

            int i=0;
            int yPos = 0;
            while (pnl_Items.Controls.Count>0)
            {
                Control ctrl = pnl_Items.Controls[0];
                this.pnl_Items.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
            pnl_Items.AutoScrollOffset = new Point(0, 0);
            pnl_Items.AutoScrollPosition = new Point(0, 0);
            for (i=0;i<m_NumberOfItemsPerPage;i++)
            {
                usrc_Item usrc_item = new usrc_Item();
                usrc_item.m_usrc_ItemList = this;
                usrc_item.Top = yPos;
                usrc_item.Left = 5;
                usrc_item.Width = this.pnl_Items.Width - 10;
                usrc_item.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                yPos += usrc_item.Height + 1;
                usrc_item.ItemAdded2Basket += new usrc_Item.delegate_ItemAdded2Basket(usrc_item_ItemAdded);
                usrc_item.ItemChanged += usrc_item_ItemChanged;
                usrc_item.StockChanged += usrc_item_StockChanged;
                usrc_item.BackColor = GlobalData.Color_Stock;
                usrc_Item_aray[i] = usrc_item;
                this.pnl_Items.Controls.Add(usrc_item);
            }
            this.pnl_Items.AutoScroll = true;
            this.pnl_Items.HorizontalScroll.Enabled = true;
            this.pnl_Items.VerticalScroll.Enabled = true;
        }

        void usrc_item_StockChanged(object obj)
        {
            if (obj is Item_Data)
            {
                Get_Price_Item_Stock_Data(((Item_Data)obj).PriceList_ID.v);
            }
        }

        void usrc_item_ItemChanged(object obj)
        {
            if (obj is InvoiceDB.Item_Data)
            {
                Get_Price_Item_Stock_Data(((InvoiceDB.Item_Data)obj).PriceList_ID.v);
            }
        }

        internal void Init(InvoiceDB.ShopBC xm_ShopBC, DBTablesAndColumnNames xDBtcn, usrc_ShopC x_usrc_ItemMan)
        {
            m_ShopBC = xm_ShopBC;
            m_usrc_ItemMan = x_usrc_ItemMan;
            DBtcn = xDBtcn;
            Init();
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




        public bool Get_Price_Item_Stock_Data(long PriceList_ID)
        {
            m_PriceList_ID = PriceList_ID;
            if (m_ShopBC.m_CurrentInvoice.m_ShopShelf.GetGroupsTable(PriceList_ID))
            {
                m_usrc_Item_Group_Handler.Set_Groups(m_ShopBC.m_CurrentInvoice.m_ShopShelf.dt_Price_Item_Group);
                return true;
            }
            else
            {
                return false;
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
        }

        private void m_usrc_Item_Group_Handler_GroupChanged(string[] s_name)
        {
            s_name_Group = s_name;

            if (m_ShopBC.m_CurrentInvoice.m_ShopShelf.Load(m_PriceList_ID, s_name))
            {
                lbl_GroupPath.Text = m_usrc_Item_Group_Handler.GroupPath;
                m_usrc_Item_PageHandler.Init(m_ShopBC.m_CurrentInvoice.m_ShopShelf.items, 5, usrc_Item_aray);
            }

        }

        internal bool Show(InvoiceDB.Atom_ProformaInvoice_Price_Item_Stock_Data appisd)
        {
            string[] sGroupArr = new string[3];
            sGroupArr[0] = appisd.s1_name;
            sGroupArr[1] = appisd.s2_name;
            sGroupArr[2] = appisd.s3_name;
            if (m_usrc_Item_Group_Handler.Set(sGroupArr))
            {
                int index = m_ShopBC.m_CurrentInvoice.m_ShopShelf.GetIndex(appisd);
                if (index>=0)
                { 
                    m_usrc_Item_PageHandler.Show(index);
                    return true;
                }
            }
            return false;

        }

        private void m_usrc_Item_Group_Handler_GroupsRedefined(int Level)
        {
            if (Level == 0)
            {
                pnl_Items.Width = ipnl_Items_Width_default + m_usrc_Item_Group_Handler.Width + 2;
                m_usrc_Item_Group_Handler.Visible = false;
            }
            else
            {
                m_usrc_Item_Group_Handler.Visible = true;
                pnl_Items.Width = ipnl_Items_Width_default;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_Items.AutoScroll = true;
            pnl_Items.AutoSize = false;
            pnl_Items.VerticalScroll.Visible = true;

        }
    }
}
