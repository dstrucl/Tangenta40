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
    public partial class usrcG_Item_PageHandler<T>: UserControl
    {
        public delegate void delegate_ShowObject(int Item_id_index,object o_data, object o_usrc, bool bVisible);
        public event delegate_ShowObject ShowObject = null;
        public object m_datatable_or_list = null;
        public T[] m_ousrc_Item_array = null;

        private RadioButton[] NumericPageButton = null;
        private int m_NumberOfNumericPageButtons = 0;
        private int m_MaxNumberOfItemsPerPage = 100;

        private int m_iFirst_In_Item_id_array = -1;
        private int m_iLast_In_Item_id_array = -1;

        private int m_NumberOfPages = 0;

        private int m_CurrentPage = 0;

        public int CurrentPage
        {
            get { return m_CurrentPage; }
            set {
                m_CurrentPage = value;
            }
        }


        public int NumberOfPages
        {
            get { return m_NumberOfPages; }
        }

        public int iFirst_In_Item_id_array
        {
            get { return m_iFirst_In_Item_id_array; }
        }

        public int iLast_In_Item_id_array
        {
            get { return m_iLast_In_Item_id_array; }
        }


        public int NumberOfNumericPageButtons
        {
            get { return m_NumberOfNumericPageButtons; }
        }

        public int MaxNumberOfItemsPerPage
        {
            get { return m_MaxNumberOfItemsPerPage; }
        }

        private void CreateNumButtons(int xNumberOfNumericPageButtons)
        {
            if (m_NumberOfNumericPageButtons != xNumberOfNumericPageButtons)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is RadioButton)
                    {
                        this.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }
                int iLeft = this.btn_Next.Left + 2;
                NumericPageButton = new RadioButton[xNumberOfNumericPageButtons];
                for (int i = 0; i < xNumberOfNumericPageButtons; i++)
                {
                    RadioButton rbtn = new RadioButton();
                    NumericPageButton[i] = rbtn;
                    rbtn.Appearance = Appearance.Button;
                    int iname = i + 1;
                    rbtn.Name = "btn_n" + iname.ToString();
                    rbtn.Tag = i;
                    rbtn.Height = this.Height - 2;
                    rbtn.Top = 1;
                    rbtn.Left = iLeft;
                    rbtn.Width = rbtn.Height;
                    rbtn.Font = new Font("Arial", 10);
                    rbtn.Text = iname.ToString();
                    rbtn.TextAlign = ContentAlignment.MiddleCenter;
                    iLeft += rbtn.Width + 1;
                    this.Controls.Add(rbtn);
                    iLeft += rbtn.Width + 2;
                }
                btn_Prev.Left = iLeft;
                btn_Last.Left = btn_Prev.Left + btn_Prev.Width + 2;
                m_NumberOfNumericPageButtons = xNumberOfNumericPageButtons;
            }
        }

        public usrcG_Item_PageHandler()
        {
            InitializeComponent();
            CreateNumButtons(m_NumberOfNumericPageButtons);

        }

        public void Init(object datatable_or_list, int xNumberOfNumericPagePuttons, T[] ousrc_Item_array)
        {
            CurrentPage = 0;
            m_datatable_or_list = datatable_or_list;
            m_ousrc_Item_array = ousrc_Item_array;
            CreateNumButtons(xNumberOfNumericPagePuttons);
            m_NumberOfNumericPageButtons = xNumberOfNumericPagePuttons;
            m_MaxNumberOfItemsPerPage = ousrc_Item_array.Count();
            DoPaint();
        }


        public void DoPaint()
        {
            object oRet = null;
            this.btn_First.Visible = false;
            this.btn_Prev.Visible = false;
            this.btn_Next.Visible = false;
            this.btn_Last.Visible = false;

            this.btn_First.Enabled = false;
            this.btn_Prev.Enabled = false;
            this.btn_Next.Enabled = false;
            this.btn_Last.Enabled = false;

            
            int count = 0;
            DataTable dt = null;
            List<object> list = null;
            if (m_datatable_or_list is DataTable)
            {
                dt = (DataTable)m_datatable_or_list;
                count = dt.Rows.Count;
            }
            else if (m_datatable_or_list is List<object>)
            {
                list = (List<object>)m_datatable_or_list;
                count = list.Count;
            }



            
            if (count > 0)
            {
                int remeinder = count % m_MaxNumberOfItemsPerPage;
                int divresult = count / m_MaxNumberOfItemsPerPage;
                m_NumberOfPages = divresult;
                if (remeinder > 0)
                {
                    m_NumberOfPages++;
                }
                if (m_NumberOfPages > 1)
                {
                    if (m_NumberOfPages <= m_NumberOfNumericPageButtons)
                    {
                        int iLeft = 0;
                        for (int i=0;i<m_NumberOfNumericPageButtons;i++)
                        {
                            if (i<m_NumberOfPages)
                            {
                                NumericPageButton[i].Visible = true;
                                NumericPageButton[i].Left = iLeft;
                                NumericPageButton[i].Text = ((int)(i+1)).ToString();
                                NumericPageButton[i].Tag = i;
                                iLeft +=NumericPageButton[i].Width+2;
                            }
                            else
                            {
                                NumericPageButton[i].Visible = false;
                            }
                        }
                        ShowCurrentPage(ref oRet,-1);
                    }
                    else
                    {

                        btn_First.Visible = true;
                        btn_Prev.Visible = true;
                        btn_Next.Visible = true;
                        btn_Last.Visible = true;

                        btn_First.Enabled = true;
                        btn_Prev.Enabled = true;
                        btn_Next.Enabled = true;
                        btn_Last.Enabled = true;

                        btn_First.Top = 1;
                        btn_Prev.Top = 1;
                        btn_Next.Top = 1;
                        btn_Last.Top = 1;

                        btn_First.Height = this.Height - 2;
                        btn_Prev.Height = this.Height - 2;
                        btn_Next.Height = this.Height - 2;
                        btn_Last.Height = this.Height - 2;

                        btn_First.Width = btn_First.Height;
                        btn_Prev.Width = btn_First.Height;
                        btn_Next.Width = btn_First.Height;
                        btn_Last.Width = btn_First.Height;
                        int iLeft = 1;
                        btn_First.Left = iLeft;
                        iLeft = btn_First.Left + btn_First.Width + 1;
                        btn_Prev.Left = iLeft;
                        iLeft = btn_Prev.Left + btn_Prev.Width+1;

                        for (int i = 0; i < m_NumberOfNumericPageButtons; i++)
                        {
                            NumericPageButton[i].Visible = true;
                            NumericPageButton[i].Left = iLeft;
                            NumericPageButton[i].Text = ((int)(CurrentPage + i + 1)).ToString();
                            NumericPageButton[i].Tag = CurrentPage + i; 
                            iLeft += NumericPageButton[i].Width + 2;
                        }
                        btn_Next.Left = iLeft;
                        iLeft += btn_Next.Width + 1;
                        btn_Last.Left = iLeft;
                        iLeft += btn_Last.Width + 1;
                        this.Width = iLeft;
                        ShowCurrentPage(ref oRet, -1);
                    }
                }
                else
                {
                    for (int i = 0; i < m_NumberOfNumericPageButtons; i++)
                    {
                        NumericPageButton[i].Visible = false;
                    }
                    ShowCurrentPage(ref oRet, -1);
                }
            }
            else
            {
                for (int i = 0; i < m_NumberOfNumericPageButtons; i++)
                {
                    NumericPageButton[i].Visible = false;
                }
                if (m_ousrc_Item_array != null)
                {
                    int m_ousrc_count = m_ousrc_Item_array.Count();
                    int o_usrc_Index = 0;
                    while (o_usrc_Index < m_ousrc_count)
                    {
                        ShowObject(-1, null, m_ousrc_Item_array[o_usrc_Index], false);
                        o_usrc_Index++;
                    }
                }
            }
        }

        private void ShowCurrentPage(ref object oReturn,int index)
        {
            RemoveHandler();
            setcolor();
            oReturn = null;
            int iStart = CurrentPage * m_MaxNumberOfItemsPerPage;
            int iEnd = -1;
            int count = 0;
            DataTable dt = null;
            List<object> list = null;
            if (m_datatable_or_list is DataTable)
            {
                dt = (DataTable)m_datatable_or_list;
                count = dt.Rows.Count;
            }
            else if (m_datatable_or_list is List<object>)
            {
                list = (List<object>)m_datatable_or_list;
                count = list.Count;
            }

            int m_ousrc_count = m_ousrc_Item_array.Count();
            if (iStart+m_MaxNumberOfItemsPerPage<=count)
            {
                iEnd = iStart + m_MaxNumberOfItemsPerPage;
            }
            else
            {
                iEnd = count;
            }
            int i = 0;
            if (ShowObject!=null)
            {
                int o_usrc_Index = 0;
                for (i = iStart; i < iEnd; i++)
                {
                    if (m_datatable_or_list is DataTable)
                    {
                        ShowObject(i, ((DataTable)m_datatable_or_list).Rows[i], m_ousrc_Item_array[o_usrc_Index], true);
                    }
                    else if (m_datatable_or_list is List<object>)
                    {
                        ShowObject(i, ((List<object>)m_datatable_or_list)[i], m_ousrc_Item_array[o_usrc_Index], true);
                    }
                    if (index>=0)
                    {
                        if (i==index)
                        {
                            oReturn = m_ousrc_Item_array[o_usrc_Index];
                        }
                    }

                    o_usrc_Index++;
                }
                while (o_usrc_Index < m_ousrc_count)
                {
                    ShowObject(-1, null, m_ousrc_Item_array[o_usrc_Index], false);
                    o_usrc_Index++;
                }
            }

            AddHandler();
        }

        private void setcolor()
        {
            int iCount = NumericPageButton.Count();
            for (int i = 0; i < iCount; i++)
            {
                RadioButton rb = NumericPageButton[i];
                if (rb.Visible)
                {
                    int iTag = (int)rb.Tag;
                    if (CurrentPage == iTag)
                    {
                        rb.Checked = true;
                        rb.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        rb.Checked = false;
                        rb.BackColor = Color.Azure;
                    }
                }
            }
        }

        private void AddHandler()
        {
            btn_First.Click += btn_First_Click;
            btn_Prev.Click += btn_Prev_Click;
            btn_Next.Click += btn_Next_Click;
            btn_Last.Click += btn_Last_Click;
            foreach (RadioButton rb in this.NumericPageButton)
            {
                rb.CheckedChanged += CheckedChanged;
            }
        }

        void btn_First_Click(object sender, EventArgs e)
        {
            object oRet = null;
            CurrentPage = 0;
            SetPageButtons();
            ShowCurrentPage(ref oRet, -1);
        }

        void btn_Prev_Click(object sender, EventArgs e)
        {
            object oRet = null;
            if (CurrentPage>0)
            {
                CurrentPage--;
                SetPageButtons();
                ShowCurrentPage(ref oRet, -1);
            }
            
        }

        private void SetPageButtons()
        {
            int iMiddleButton = m_NumberOfNumericPageButtons / 2;
            int iLastPage =this.m_NumberOfPages-1;
            int iFirstPageOnScreen = CurrentPage-iMiddleButton;
            while (iFirstPageOnScreen<0)
            {
                iFirstPageOnScreen++;
            }
            int iLastPageOnScreen = iFirstPageOnScreen + m_NumberOfNumericPageButtons - 1;
            while (CurrentPage > iLastPageOnScreen)
            {
                iFirstPageOnScreen++;
                iLastPageOnScreen++;
            }

            while (iLastPageOnScreen > m_NumberOfPages-1)
            {
                if (iFirstPageOnScreen > 0)
                {
                    iFirstPageOnScreen--;
                }
                if (iLastPageOnScreen > 0)
                {
                    iLastPageOnScreen--;
                }
                if ((iFirstPageOnScreen==0)&&(iLastPageOnScreen == 0))
                {
                    break;
                }
            }
            
            while ((iFirstPageOnScreen > 0) &&  (iFirstPageOnScreen > (iLastPageOnScreen-(m_NumberOfNumericPageButtons-1))))
            {
                iFirstPageOnScreen--;
            }

            int i=0;
            int j = 0;

            int count_buttons = this.NumericPageButton.Count();

            if (count_buttons > 0)
            {
                for (i = iFirstPageOnScreen; i <= iLastPageOnScreen; i++)
                {
                    NumericPageButton[j].Tag = i;
                    NumericPageButton[j].Text = (i + 1).ToString();
                    j++;
                }
            }
             
        }

        void btn_Next_Click(object sender, EventArgs e)
        {
            object oRet = null;
            if (CurrentPage < m_NumberOfPages - 1)
            {
                CurrentPage++;
            }
            SetPageButtons();
            ShowCurrentPage(ref oRet, -1);
        }

        void btn_Last_Click(object sender, EventArgs e)
        {
            object oRet = null;
            if (CurrentPage < m_NumberOfPages - 1)
            {
                CurrentPage = m_NumberOfPages - 1;
            }
            SetPageButtons();
            ShowCurrentPage(ref oRet, -1);
        }

        void btn_Prev_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btn_First_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                object oRet = null;
                CurrentPage = (int)rb.Tag;
                ShowCurrentPage(ref oRet, -1);
            }
        }

        private void RemoveHandler()
        {
            btn_First.Click -= btn_First_Click;
            btn_Prev.Click -= btn_Prev_Click;
            btn_Next.Click -= btn_Next_Click;
            btn_Last.Click -= btn_Last_Click;
            foreach (RadioButton rb in NumericPageButton)
            {
                rb.CheckedChanged -= CheckedChanged;
            }
        }

        public object Show(int index)
        {
            CurrentPage = index / m_MaxNumberOfItemsPerPage;
            DoPaint();
            SetPageButtons();
            object oRet = null;
            ShowCurrentPage(ref oRet,index);
            return oRet;
        }
    }
}
