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

namespace usrc_Item_PageHandler
{
    public partial class usrc_Item_InsidePageHandler : UserControl
    {
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

        public delegate void delegate_FillControl(Control ctrl, object oData);
        public event delegate_FillControl FillControl = null;

        public delegate void delegate_SelectControl(Control ctrl, object oData,int index, bool selected);
        public event delegate_SelectControl SelectControl = null;

        public delegate void delegate_Select(object oData, int index);
        public event delegate_Select Select = null;

        public delegate void delegate_SelectionChanged(Control ctrl,object oData, int index);
        public event delegate_SelectionChanged SelectionChanged = null;

        public delegate void delegate_PageChanged(int iPage);
        public event delegate_PageChanged PageChanged = null;

        public delegate void delegate_Deselect(object oData, int index);
        public event delegate_Deselect Deselect = null;

        private object[] m_ousrc_Item_array = null;
        private Control[] ctrlItems_array = null;

        private List<object> m_ousrc_Item_list = null;
        private List<Control> ctrlItems_list = null;

        private List<Page> Pages = new List<Page>();

        private int numberOfCtrlColumns = 0;
        private int numberOCtrlfRows = 0;

        private int m_ctrlWidth = 100;

        private int CtrlWidth
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
        private int CtrlHeight
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


        private int m_NumberOfItems = 0;
        public int NumberOfItems
        {
            get
            {
                return m_NumberOfItems;
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



        public usrc_Item_InsidePageHandler()
        {
            InitializeComponent();
        }


        public void refresh()
        {
            GetLayoutMatrix();
            initialise();
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
            btn_Prev.Top = ctrlItems_array[0].Top;
            btn_Prev.Left = ctrlItems_array[0].Left;
            btn_Prev.Width = ctrlItems_array[0].Width;
            btn_Prev.Height = ctrlItems_array[0].Height;
            btn_Prev.Visible = false;

            int ilast = ctrlItemsCount - 1;
            btn_Next.Top = ctrlItems_array[ilast].Top;
            btn_Next.Left = ctrlItems_array[ilast].Left;
            btn_Next.Width = ctrlItems_array[ilast].Width;
            btn_Next.Height = ctrlItems_array[ilast].Height;
            btn_Next.Visible = false;

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
            if (m_NumberOfItems > 0)
            {
                if (CreateControl != null)
                {
                    if (ctrlItems_array==null)
                    {
                        create_controls();
                    }
                }
                Page pgPrev = null;
                int rest_items = m_NumberOfItems - NumberOfPageAllocatedItems;
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
                            rest_items = m_NumberOfItems - NumberOfPageAllocatedItems;
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
                            rest_items = m_NumberOfItems - NumberOfPageAllocatedItems;
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
                            rest_items = m_NumberOfItems - NumberOfPageAllocatedItems;
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
                            rest_items = m_NumberOfItems - NumberOfPageAllocatedItems;
                        }
                    }
                }
            }
        }

        public void Init(object xDataCollection)
        {
            if (xDataCollection is object[])
            {
                m_ousrc_Item_array = (object[])xDataCollection;
                m_NumberOfItems = m_ousrc_Item_array.Length;
                CollectionType = eCollectionType.ARRAY;
            }
            else
            {
                m_ousrc_Item_list = (List<object>)xDataCollection;
                m_NumberOfItems = m_ousrc_Item_list.Count;
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
                                        FillControl(ctrlItems_array[ictrl], m_ousrc_Item_array[iobj]);
                                        break;
                                    case eCollectionType.LIST:
                                        FillControl(ctrlItems_array[ictrl], m_ousrc_Item_list[iobj]);
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
            if (index < m_NumberOfItems)
            {
                int ictrl = 0;
                int ipage = 0;
                if (get_page(index,ref ipage, ref ictrl))
                {
                    int icount = m_NumberOfItems;
                    for (int i=0;i< icount;i++)
                    {
                        if (i == index)
                        {
                            if (Select != null)
                            {
                                if (ipage != m_CurrentPage)
                                {
                                    switch (CollectionType)
                                    {
                                        case eCollectionType.ARRAY:
                                            Select(m_ousrc_Item_array[index], index);
                                            break;
                                        case eCollectionType.LIST:
                                            Select(m_ousrc_Item_list[index], index);
                                            break;
                                    }
                                    for (int k=index+1;k<icount;k++)
                                    {
                                        switch (CollectionType)
                                        {
                                            case eCollectionType.ARRAY:
                                                Deselect(m_ousrc_Item_array[k], k);
                                                break;
                                            case eCollectionType.LIST:
                                                Deselect(m_ousrc_Item_list[k], k);
                                                break;
                                        }
                                    }
                                    ShowPage(ipage);
                                    if (m_SelectedIndex != index)
                                    {
                                        m_SelectedIndex = index;
                                        if (SelectionChanged != null)
                                        {
                                            switch (CollectionType)
                                            {
                                                case eCollectionType.ARRAY:
                                                    SelectionChanged(ctrlItems_array[ictrl], m_ousrc_Item_array[index], index);
                                                    break;
                                                case eCollectionType.LIST:
                                                    SelectionChanged(ctrlItems_array[ictrl], m_ousrc_Item_list[index], index);
                                                    break;
                                            }
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                    if (SelectControl != null)
                                    {
                                        int ixctrls_Start = Pages[ipage].iControlStartIndex;
                                        int ixctrls_End = Pages[ipage].iControlEndIndex;
                                        int ixobj_Start = Pages[ipage].iObjectDataStartIndex;
                                        for (int j = ixctrls_Start; j <= ixctrls_End; j++)
                                        {
                                            if (j == ictrl)
                                            {
                                                switch (CollectionType)
                                                {
                                                    case eCollectionType.ARRAY:
                                                        SelectControl(ctrlItems_array[j], m_ousrc_Item_array[index], index, true);
                                                        break;
                                                    case eCollectionType.LIST:
                                                        SelectControl(ctrlItems_array[j], m_ousrc_Item_list[index], index, true);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (CollectionType)
                                                {
                                                    case eCollectionType.ARRAY:
                                                        SelectControl(ctrlItems_array[j], m_ousrc_Item_array[ixobj_Start], ixobj_Start, false);
                                                        break;
                                                    case eCollectionType.LIST:
                                                        SelectControl(ctrlItems_array[j], m_ousrc_Item_list[ixobj_Start], ixobj_Start, false);
                                                        break;
                                                }
                                            }
                                            ixobj_Start++;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Deselect != null)
                            {
                                switch (CollectionType)
                                {
                                    case eCollectionType.ARRAY:
                                        Deselect(m_ousrc_Item_array[i], i);
                                        break;
                                    case eCollectionType.LIST:
                                        Deselect(m_ousrc_Item_list[i], i);
                                        break;
                                }
                            }
                        }
                    }
                    m_SelectedIndex = index;
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
