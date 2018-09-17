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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usrc_Item_InsidePage_Handler
{
    public partial class usrc_Item_InsidePageHandler : UserControl
    {
        public enum eMode { VIEW,EDIT};

        private eMode m_eMode = eMode.VIEW;
        public eMode Mode
        {
            get
            {
                return m_eMode;
            }
            private set
            {
                m_eMode = value;
            }
        }

        public enum eCollectionType { ARRAY,LIST};
        private class Page
        {
            public int ItemsCount;
            public int iControlStartIndex;
            public int iControlEndIndex;
            public int iObjectDataStartIndex;
            public int iObjectDataEndIndex;
        }

        private eCollectionType m_ecollectiontype = eCollectionType.ARRAY;
        public eCollectionType CollectionType
        {
            get
            {
                return m_ecollectiontype;
            }
            private set
            {
                m_ecollectiontype = value;
            }
        }


        public delegate void delegate_CreateControl(ref Control ctrl);
        public event delegate_CreateControl CreateControl = null;

        public delegate void delegate_FillControl(Control ctrl, object oData, eMode xMode);
        public event delegate_FillControl FillControl = null;

        public delegate bool delegate_SetName(object oData, ref string name);
        public event delegate_SetName SetName = null;


        public delegate void delegate_SelectControl(Control ctrl, object oData,int index, bool selected);
        public event delegate_SelectControl SelectControl = null;

        public delegate void delegate_ControlClick(Control ctrl, object oData, int index, bool selected);
        public event delegate_ControlClick ControlClick = null;

        public delegate void delegate_SelectionChanged(Control ctrl, object oData, int index, bool selected);
        public event delegate_SelectionChanged SelectionChanged = null;

        public delegate void delegate_Paint(Control ctrl,object oData, int index);
        public event delegate_Paint Paint = null;

        public delegate void delegate_PageChanged(int iPage);
        public event delegate_PageChanged PageChanged = null;


        private object[] m_ousrc_Item_array = null;
        private Control[] ctrlItems_array = null;

        private List<object> m_ousrc_Item_list = null;
        private List<Control> ctrlItems_list = null;

        private List<Page> Pages = new List<Page>();

        private int numberOfCtrlColumns = 0;
        private int numberOCtrlfRows = 0;

        private int m_ctrlWidth = 100;

        public int CtrlWidth
        {
            get
            {
                return m_ctrlWidth;
            }
            set
            {
                m_ctrlWidth = value;
            }
        }

        private int m_ctrlHeight = 40;
        public int CtrlHeight
        {
            get
            {
                return m_ctrlHeight;
            }
            set
            {
                m_ctrlHeight = value;
            }
        }

        private int ctrlItemsCount
        {
            get
            {
                return numberOfCtrlColumns * numberOCtrlfRows;
            }
        }


        private int NumberOfPageAllocatedItems
        {
            get
            {
                int isum = 0;
                foreach (Page ipg in Pages)
                {
                    isum += ipg.ItemsCount;
                }
                return isum;
            }
        }


        private int m_xNumberOfItems = 0;
        public int NumberOfItems
        {
            get
            {
                return m_xNumberOfItems;
            }
            private set
            {
                m_xNumberOfItems = value;
            }
        }


        private int m_CurrentPage = -1;
        public int CurrentPage
        {
            get { return m_CurrentPage; }
            private set
            {
                m_CurrentPage = value;
            }
        }

        private int m_SelectedIndex = -1;
        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
            set
            {
                m_SelectedIndex = value;
            }
        }


        public int NumberOfPages
        {
            get { return Pages.Count; }
        }

        public string SelectedItemName
        {
            get
            {
                if (SetName != null)
                {
                    if (m_SelectedIndex >= 0)
                    {
                        string sname = null;
                        switch (CollectionType)
                        {
                            case eCollectionType.ARRAY:
                                if (SetName(m_ousrc_Item_array[m_SelectedIndex], ref sname))
                                {
                                    return sname;
                                }
                                else
                                {
                                    return null;
                                }
                            case eCollectionType.LIST:
                                if (SetName(m_ousrc_Item_list[m_SelectedIndex], ref sname))
                                {
                                    return sname;
                                }
                                else
                                {
                                    return null;
                                }
                            default:
                                MessageBox.Show("ERROR:CollectionType not implemented:" + CollectionType.ToString());
                                return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public usrc_Item_InsidePageHandler()
        {
            InitializeComponent();
        }


        public void refresh()
        {
            GetLayoutMatrix();
            initialise();
            if (m_SelectedIndex>=0)
            {
                if (m_SelectedIndex >= NumberOfItems)
                {
                    SelectObject(NumberOfItems - 1);
                }
                else
                {
                    SelectObject(m_SelectedIndex);
                }
            }
            else
            {
                if (NumberOfItems > 0)
                {
                    SelectObject(0);
                }
            }

        }

        private void RemoveControlItems()
        {
            if (ctrlItems_array != null)
            {
                foreach (Control xc in ctrlItems_array)
                {
                    if (xc != null)
                    {
                        this.Controls.Remove(xc);
                        xc.Dispose();
                    }
                }
                ctrlItems_array = null;
            }
        }
        private void create_controls()
        {
            int i = 0;
            ctrlItems_array = new Control[ctrlItemsCount];
            for (int irow = 0; irow < numberOCtrlfRows; irow++)
            {
                for (int icol = 0; icol < numberOfCtrlColumns; icol++)
                {
                    Control xctrl = null;
                    CreateControl(ref xctrl);
                    if (xctrl != null)
                    {
                        xctrl.Click += Xctrl_Click;
                        xctrl.Left = icol * CtrlWidth;
                        xctrl.Top = irow * CtrlHeight;
                        xctrl.Width = CtrlWidth;
                        xctrl.Height = CtrlHeight;
                        xctrl.Visible = false;
                        this.Controls.Add(xctrl);
                        ctrlItems_array[i] = xctrl;
                        i++;
                    }
                }
            }
            Control Xctrl0 = ctrlItems_array[0];
            if (Xctrl0 != null)
            {
                btn_Prev.Top = Xctrl0.Top;
                btn_Prev.Left = Xctrl0.Left;
                btn_Prev.Width = Xctrl0.Width;
                btn_Prev.Height = Xctrl0.Height;
            }
            btn_Prev.Visible = false;

            int ilast = ctrlItemsCount - 1;
            Control Xctrlast = ctrlItems_array[ilast];
            if (Xctrlast != null)
            {
                btn_Next.Top = Xctrlast.Top;
                btn_Next.Left = Xctrlast.Left;
                btn_Next.Width = Xctrlast.Width;
                btn_Next.Height = Xctrlast.Height;
            }
            btn_Next.Visible = false;

        }

        private void Xctrl_Click(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control xtrl = (Control)sender;
                if (xtrl.Tag is int)
                {
                    int iObj = (int)xtrl.Tag;

                    if (ControlClick!=null)
                    {
                        switch (CollectionType)
                        {
                            case eCollectionType.ARRAY:
                                ControlClick(xtrl, m_ousrc_Item_array[iObj], iObj, iObj == SelectedIndex);
                                break;
                            case eCollectionType.LIST:
                                ControlClick(xtrl, m_ousrc_Item_list[iObj], iObj, iObj == SelectedIndex);
                                break;
                            default:
                                MessageBox.Show("ERROR:Xctrl_Click:CollectionType not implemented:" + CollectionType.ToString());
                                break;
                        }
                    }
                    if (iObj != m_SelectedIndex)
                    {
                        SelectObject(iObj);
                        if (SelectionChanged != null)
                        {
                            switch (CollectionType)
                            {
                                case eCollectionType.ARRAY:
                                    SelectionChanged(xtrl, m_ousrc_Item_array[iObj], iObj, iObj == SelectedIndex);
                                    break;
                                case eCollectionType.LIST:
                                    SelectionChanged(xtrl, m_ousrc_Item_list[iObj], iObj, iObj == SelectedIndex);
                                    break;
                                default:
                                    MessageBox.Show("ERROR:Xctrl_Click:CollectionType not implemented:" + CollectionType.ToString());
                                    break;
                            }
                        }
                    }
                    else
                    {
                        SelectObject(iObj);
                    }
                    
                }
            }
        }

        private void GetLayoutMatrix()
        {
            numberOfCtrlColumns = this.Width / m_ctrlWidth;
            numberOCtrlfRows = this.Height / m_ctrlHeight;

            RemoveControlItems();

            if (ctrlItemsCount > 0)
            {
                if (CreateControl != null)
                {
                    create_controls();
                }
            }
        }

        private void initialise()
        {
            Pages.Clear();
            if (NumberOfItems > 0)
            {
                if (CreateControl != null)
                {
                    if (ctrlItems_array==null)
                    {
                        create_controls();
                    }
                }
                Page pgPrev = null;
                int rest_items = NumberOfItems - NumberOfPageAllocatedItems;
                while (rest_items > 0)
                {
                    if (Pages.Count == 0)
                    {
                        if (rest_items <= ctrlItemsCount)
                        {
                            Page pg = new Page();
                            pg.ItemsCount = rest_items;
                            pg.iControlStartIndex = 0;
                            pg.iControlEndIndex = rest_items - 1;
                            pg.iObjectDataStartIndex = NumberOfPageAllocatedItems;
                            pg.iObjectDataEndIndex = pg.iObjectDataStartIndex + pg.ItemsCount - 1;
                            Pages.Add(pg);
                            pgPrev = pg;
                            rest_items = NumberOfItems - NumberOfPageAllocatedItems;
                        }
                        else
                        {
                            Page pg = new Page();
                            pg.ItemsCount = ctrlItemsCount;
                            pg.iControlStartIndex = 0;
                            pg.iControlEndIndex = ctrlItemsCount - 1;
                            pg.iObjectDataStartIndex = NumberOfPageAllocatedItems;
                            pg.iObjectDataEndIndex = pg.iObjectDataStartIndex + pg.ItemsCount - 1;
                            if (pgPrev != null)
                            {
                                pgPrev.ItemsCount--;
                                pgPrev.iControlEndIndex--;
                                pgPrev.iObjectDataEndIndex--;
                                pg.iObjectDataStartIndex--;
                                pg.iObjectDataEndIndex--;
                            }
                            Pages.Add(pg);
                            pgPrev = pg;
                            rest_items = NumberOfItems - NumberOfPageAllocatedItems;
                        }
                    }
                    else
                    {
                        if (rest_items < ctrlItemsCount)
                        {
                            Page pg = new Page();
                            pg.ItemsCount = rest_items;
                            pg.iControlStartIndex = 1;
                            if (rest_items == ctrlItemsCount - 1)
                            {
                                pg.iControlEndIndex = ctrlItemsCount - 2;
                            }
                            else
                            {
                                pg.iControlEndIndex = pg.iControlStartIndex + rest_items;
                            }
                            pg.iObjectDataStartIndex = NumberOfPageAllocatedItems;
                            pg.iObjectDataEndIndex = pg.iObjectDataStartIndex + rest_items;
                            if (pgPrev != null)
                            {
                                pgPrev.ItemsCount--;
                                pgPrev.iControlEndIndex--;
                                pgPrev.iObjectDataEndIndex--;
                                pg.iObjectDataStartIndex--;
                                pg.iObjectDataEndIndex--;
                                pg.ItemsCount++;
                                if (pg.ItemsCount >= ctrlItemsCount)
                                {
                                    pg.ItemsCount--;
                                }
                            }
                            Pages.Add(pg);
                            pgPrev = pg;
                            rest_items = NumberOfItems - NumberOfPageAllocatedItems;
                        }
                        else
                        {
                            Page pg = new Page();
                            pg.ItemsCount = ctrlItemsCount - 1;
                            pg.iControlStartIndex = 1;
                            pg.iControlEndIndex = ctrlItemsCount - 2;
                            pg.iObjectDataStartIndex = NumberOfPageAllocatedItems;
                            pg.iObjectDataEndIndex = pg.iObjectDataStartIndex + pg.ItemsCount - 1;
                            if (pgPrev != null)
                            {
                                pgPrev.ItemsCount--;
                                pgPrev.iControlEndIndex--;
                                pgPrev.iObjectDataEndIndex--;
                                pg.iObjectDataStartIndex--;
                                pg.iObjectDataEndIndex--;
                            }
                            Pages.Add(pg);
                            pgPrev = pg;
                            rest_items = NumberOfItems - NumberOfPageAllocatedItems;
                        }
                    }
                }
            }
            else
            {
                if (CreateControl != null)
                {
                    if (ctrlItems_array == null)
                    {
                        create_controls();
                    }
                }
                if (ctrlItems_array != null)
                {
                    foreach (Control xctrl in ctrlItems_array)
                    {
                        if (xctrl != null)
                        {
                            xctrl.Visible = false;
                        }
                    }
                }
            }
        }

        public void Init(object xDataCollection, eMode xMode)
        {
            Mode = xMode;
            SelectedIndex = -1;
            if (xDataCollection is object[])
            {
                m_ousrc_Item_array = (object[])xDataCollection;
                NumberOfItems = m_ousrc_Item_array.Length;
                CollectionType = eCollectionType.ARRAY;
            }
            else
            {
                m_ousrc_Item_list = (List<object>)xDataCollection;
                NumberOfItems = m_ousrc_Item_list.Count;
                CollectionType = eCollectionType.LIST;
            }
            initialise();
        }


        public void ShowPage(int iPage)
        {
            //HideControls();
            if (iPage >= 0)
            {
                if (Pages.Count > 0)
                {
                    if (iPage < Pages.Count)
                    {
                        int icount = Pages[iPage].ItemsCount;
                        int ictrl = Pages[iPage].iControlStartIndex;
                        if (ictrl == 1)
                        {
                            ctrlItems_array[0].Visible = false;
                        }
                        else if (ictrl == 0)
                        {
                            ctrlItems_array[0].Visible = true;
                        }

                        int iobj = Pages[iPage].iObjectDataStartIndex;
                        for (int i = 0; i < icount; i++)
                        {
                            if (FillControl != null)
                            {
                                switch (CollectionType)
                                {
                                    case eCollectionType.ARRAY:
                                        ctrlItems_array[ictrl].Tag = iobj;
                                        FillControl(ctrlItems_array[ictrl], m_ousrc_Item_array[iobj],Mode);
                                        if (SelectControl != null)
                                        {
                                            if (m_SelectedIndex == iobj)
                                            {
                                                SelectControl(ctrlItems_array[ictrl], m_ousrc_Item_array[iobj], iobj, true);
                                            }
                                            else
                                            {
                                                SelectControl(ctrlItems_array[ictrl], m_ousrc_Item_array[iobj], iobj, false);
                                            }
                                        }
                                        break;
                                    case eCollectionType.LIST:
                                        ctrlItems_array[ictrl].Tag = iobj;
                                        FillControl(ctrlItems_array[ictrl], m_ousrc_Item_list[iobj],Mode);
                                        if (SelectControl != null)
                                        {
                                            if (m_SelectedIndex == iobj)
                                            {
                                                SelectControl(ctrlItems_array[ictrl], m_ousrc_Item_list[iobj], iobj, true);
                                            }
                                            else
                                            {
                                                SelectControl(ctrlItems_array[ictrl], m_ousrc_Item_list[iobj], iobj, false);
                                            }
                                        }
                                        break;
                                }
                                ctrlItems_array[ictrl].Visible = true;
                                ictrl++;
                                iobj++;

                            }
                        }

                        while (ictrl <ctrlItemsCount )
                        {
                            ctrlItems_array[ictrl].Visible = false;
                            ictrl++;
                        }

                        if (CurrentPage != iPage)
                        {
                            CurrentPage = iPage;
                            if (PageChanged!=null)
                            {
                                PageChanged(m_CurrentPage+1);
                            }
                        }
                        btn_Prev.Visible = false;
                        btn_Next.Visible = false;
                        if (iPage == 0)
                        {
                            btn_Prev.Visible = false;
                            if (iPage < Pages.Count - 1)
                            {
                                btn_Next.Visible = true;
                                btn_Next.Text = Convert.ToString(iPage + 2); ;
                            }
                            else
                            {
                                btn_Next.Visible = false;
                            }
                        }
                        else if (iPage > 0)
                        {
                            btn_Prev.Visible = true;
                            btn_Prev.Text = Convert.ToString(iPage);
                            if (iPage < Pages.Count - 1)
                            {
                                btn_Next.Visible = true;
                                btn_Next.Text = Convert.ToString(iPage + 2); ;
                            }
                            else
                            {
                                btn_Next.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        public bool SelectObject(int index)
        {
            if (index < NumberOfItems)
            {
                int ictrl = 0;
                int ipage = 0;
                if (get_page(index,ref ipage, ref ictrl))
                {
                    m_SelectedIndex = index;
                    ShowPage(ipage);
                    if (Paint != null)
                    {
                        switch (CollectionType)
                        {
                            case eCollectionType.ARRAY:
                                Paint(ctrlItems_array[ictrl], m_ousrc_Item_array[index], index);
                                break;
                            case eCollectionType.LIST:
                                Paint(ctrlItems_array[ictrl], m_ousrc_Item_list[index], index);
                                break;
                        }
                    }
                    return true;
                }
            }
            return false;
        }


        private bool get_page(int index,ref int iPage,ref int iCtrl)
        {
            int icount = Pages.Count;
            int isum = 0;
            iPage = -1;
            iCtrl = -1;
            for (int i=0;i< icount;i++)
            {
                int ipgcount = Pages[i].ItemsCount;
                if ((index >=isum)&&(index < isum+ ipgcount))
                {
                    iCtrl = Pages[i].iControlStartIndex + (index - isum);
                    iPage = i;
                    return true;
                }
                isum += ipgcount;
            }
            return false;
        }

        private void HideControls()
        {
            foreach (Control xctrl in this.Controls)
            {
                xctrl.Visible = false;
            }
        }

        private void usrc_Item_InsidePageHandler_Resize(object sender, EventArgs e)
        {
            refresh();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (m_CurrentPage < Pages.Count-1)
            {
                ShowPage(m_CurrentPage + 1);
            }
        }

        private void btn_Prev_Click(object sender, EventArgs e)
        {
            if (m_CurrentPage > 0)
            {
                ShowPage(m_CurrentPage - 1);
            }
        }

    }
}
