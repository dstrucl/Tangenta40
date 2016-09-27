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
using LanguageControl;
using StaticLib;
using DBTypes;

namespace CodeTables
{
    public partial class usrc_myGroupBox : UserControl
    {

        internal object IndexInitialValue = null;

        public delegate void delegate_ObjectChanged(SQLTable tbl, usrc_InputControl InputControl);
        public event delegate_ObjectChanged usrc_InputControl_ObjectChanged = null;

        public delegate void delegate_IndexChanged(SQLTable tbl,usrc_myGroupBox myGroupBox);
        public event delegate_IndexChanged usrc_myGroupBox_IndexChanged = null;

        public delegate bool delegate_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, CodeTables.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction);
        public event delegate_RowReferenceFromTable_Check_NoChangeToOther RowReferenceFromTable_Check_NoChangeToOther = null;

        public delegate void delegate_Unique_parameter_exist(SQLTable tbl, Column col, DataTable dt,object value, ref bool handled);
        public event delegate_Unique_parameter_exist Unique_parameter_exist = null;

        public bool bUnique_parameter_exist = false;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        public DBTableControl m_DBTables;
        public bool bExpanded;
        public string sParentKeys;
        public SQLTable pSQL_Table;
        public Object pParentWindow;
        private Control pControl;
        public Column m_refernce_column = null;
        public IndexBox ixt_ID = null;
        public usrc_InputControl_Label usrc_lbl = null;

        private EditTable_Assistant_Form m_EditTable_Assistant_Form;

        const int WM_RBUTTONUP = 0x0205;

        public List<MyControl> controls = new List<MyControl>();
        private Button btnExpand;
        internal Button btnSelect=null;

        internal bool m_SelectionButtonVisible = true;

        private bool readOnly = false;

        private NavigationButtons.Navigation nav = null;


        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; 
                }
        }


        public bool SelectionButtonVisible
        {
            get
            {
                if (btnSelect != null)
                {
                    return btnSelect.Visible;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                m_SelectionButtonVisible = value;
                if (btnSelect != null)
                {
                    btnSelect.Visible = m_SelectionButtonVisible;
                }
            }
        }


        public bool Changed
        {
            get
            {
                return pic_Changed.Changed;
            }
        }

        public bool Changed_down
        {
            get
            {
                return pic_Changed.Changed;
            }
            set
            {
                foreach (Column col in this.pSQL_Table.Column)
                {
                    if (col.InputControl != null)
                    {
                        col.InputControl.Changed = false;
                    }
                    if (col.fKey != null)
                    {
                        if (col.fKey.fTable != null)
                        {
                            if (col.fKey.fTable.myGroupBox != null)
                            {
                                col.fKey.fTable.myGroupBox.Changed_up = value;
                            }
                        }
                    }
                }
                pic_Changed.Changed = value;
            }
        }

        public bool Changed_up
        {
            get
            {
                return pic_Changed.Changed;
            }
            set
            {
                bool b = value;
                pic_Changed.Changed = b;
                if (b)
                {
                    if (this.pSQL_Table.pParentTable!=null)
                    {
                        if (this.pSQL_Table.pParentTable.myGroupBox!=null)
                        {
                            this.pSQL_Table.pParentTable.myGroupBox.Changed_up = true;
                        }
                    }
                }
            }
        }

        public ID_v ID_v
        {
            get
            {
                if (this.ixt_ID!=null)
                {
                    return this.ixt_ID.ID_v;
                }
                else
                {
                    return null;
                }
            }
        }

        public usrc_myGroupBox()
        {
            InitializeComponent();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (bExpanded)
            {
                bExpanded = false;
                btnExpand.Text = "";
                btnExpand.Image = Resource.IconPlus.ToBitmap();
            }
            else
            {
                bExpanded = true;
                btnExpand.Text = "";
                btnExpand.Image = Resource.IconMinus.ToBitmap();
            }
            System.IntPtr wparam = new IntPtr(0);
            System.IntPtr lparam = new IntPtr(0);
            PostMessage(pControl.Handle.ToInt32(), Func.WM_USER_REDRAW_FORM, wparam, lparam);
        }


        public void Init(SQLTable pTbl,
                         Column x_refernce_column, 
                         string sPrKeys, 
                         Object pPrevWindow, 
                         Control xControl, 
                         DBTableControl xDBTables,
                         bool xbReadOnly,
                         NavigationButtons.Navigation xnav)
        {
             nav = xnav;
             int x = 3;
             readOnly = xbReadOnly;
             m_DBTables = xDBTables;
             pControl = xControl;
             m_refernce_column = x_refernce_column;
             pParentWindow = pPrevWindow;
             pSQL_Table = pTbl;
             pSQL_Table.myGroupBox = this;
             sParentKeys = sPrKeys;
             this.grpBox.Text = pTbl.lngTableName.s;
             if (pPrevWindow.GetType() == typeof(Panel))
             {
                 ((Panel)pPrevWindow).Controls.Add(this);
             }
             if (pPrevWindow.GetType() == typeof(usrc_myGroupBox))
             {
                 ((usrc_myGroupBox)pPrevWindow).grpBox.Controls.Add(this);
             }
             bExpanded = true;
             btnExpand = new Button();
             btnExpand.Text = "";
             btnExpand.Image = Resource.IconMinus.ToBitmap();
             btnExpand.Top = 14;
             btnExpand.Left = x;
             btnExpand.Width = 22;
             btnExpand.Height = 22;
             btnExpand.Click +=new EventHandler(btnExpand_Click);
             btnExpand.Visible = true;
             btnExpand.Cursor = Cursors.Arrow;
             this.grpBox.Controls.Add(btnExpand);
             x = btnExpand.Left + btnExpand.Width + 2;
             if (m_refernce_column != null)
             {
                 usrc_lbl = new usrc_InputControl_Label();
                 usrc_lbl.Init(m_refernce_column, -1, readOnly);
                 usrc_lbl.null_selected += new usrc_InputControl_Label.delegate_null_selected(m_usrc_InputControl_Label_null_selected);
                 usrc_lbl.Left = x;
                 usrc_lbl.Top = btnExpand.Top + 3;
                 this.grpBox.Controls.Add(usrc_lbl);
                 usrc_lbl.Visible = true;
                 x = usrc_lbl.Left + x + usrc_lbl.Width + 2;
                 ixt_ID = new IndexBox();
                 ixt_ID.Width = 60;
                 ixt_ID.Left = x;
                 ixt_ID.BackColor = Color.LightGray;
                 ixt_ID.Top = btnExpand.Top;
                 ixt_ID.ReadOnly = true;
                 if (m_refernce_column.fKey != null)
                 {
                     m_refernce_column.fKey.reference_ID = null;
                 }
                 this.grpBox.Controls.Add(ixt_ID);
                 ixt_ID.Visible = true;
                 x = ixt_ID.Left + ixt_ID.Width + 2;
             }
             if (!readOnly)
             {
                 btnSelect = new Button();
                 btnSelect.Text = "";
                 btnSelect.Image = Properties.Resources.SelectRow;
                 btnSelect.Top = btnExpand.Top;
                 btnSelect.Left = x;
                 btnSelect.Width = 32;
                 btnSelect.Height = btnExpand.Height;
                 btnSelect.Click += new EventHandler(btnSelect_Click);
                 btnSelect.Visible = m_SelectionButtonVisible;
                 this.grpBox.Controls.Add(btnSelect);
             }
             else
             {
                 this.grpBox.Cursor = Cursors.No;
             }
             if (m_refernce_column != null)
             {
                 if (m_refernce_column.nulltype == Column.nullTYPE.NULL)
                 {
                     ixt_ID.Visible = false;
                     if (btnSelect!=null)
                     { 
                         btnSelect.Visible = false;
                     }

                     bExpanded = false;
                     btnExpand.Visible = false;

                     btnExpand.Text = "";
                     btnExpand.Image = Resource.IconPlus.ToBitmap();
                     System.IntPtr wparam = new IntPtr(0);
                     System.IntPtr lparam = new IntPtr(0);
                     PostMessage(pControl.Handle.ToInt32(), Func.WM_USER_REDRAW_FORM, wparam, lparam);
                 }
             }
        }
        internal bool DifferentToIndexInitialValue()
        {
            if (usrc_lbl != null)
            {
                if (usrc_lbl.Initial_NoData != null)
                {
                    if (usrc_lbl.Initial_NoData.v != usrc_lbl.Null_Selected)
                    {
                        return true;
                    }
                    else
                    {
                        if (!usrc_lbl.Initial_NoData.v)
                        {
                            if (DifferentToIndexInitialValue_not_null())
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (DifferentToIndexInitialValue_not_null())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private bool DifferentToIndexInitialValue_not_null()
        {
            if ((IndexInitialValue == null)&&(ixt_ID.Initial_ID==null))
            {
                return false;
            }
            else if ((IndexInitialValue == null)&&(ixt_ID.Initial_ID!=null))
            {
                return true;
            }
            else if ((IndexInitialValue != null)&&(ixt_ID.Initial_ID==null))
            {
                return true;
            }
            else
            {
                if ((IndexInitialValue != null) && (!ixt_ID.Valid))
                {
                    return true;
                }
                else  if (ixt_ID.ID_v!=null)
                {
                    if ((long)IndexInitialValue != (long)ixt_ID.ID_v.v)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((long)IndexInitialValue != (long)ixt_ID.Initial_ID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        void m_usrc_InputControl_Label_null_selected(bool b)
        {
            
            if (b)
            {
                //if (usrc_lbl.Initial_NoData
                ixt_ID.Visible = false;
                if (btnSelect!=null)
                { 
                    btnSelect.Visible = false;
                }
                btnExpand.Visible = false;
                if (bExpanded)
                {
                    bExpanded = false;
                    btnExpand.Text = "";
                    btnExpand.Image = Resource.IconPlus.ToBitmap();
                    System.IntPtr wparam = new IntPtr(0);
                    System.IntPtr lparam = new IntPtr(0);
                    PostMessage(pControl.Handle.ToInt32(), Func.WM_USER_REDRAW_FORM, wparam, lparam);
                }
            }
            else
            {
                ixt_ID.Visible = true;
                if (btnSelect != null)
                {
                    btnSelect.Visible = m_SelectionButtonVisible;
                }
                if (!bExpanded)
                {
                    bExpanded = true;
                    btnExpand.Visible = true;
                    btnExpand.Text = "";
                    btnExpand.Image = Resource.IconMinus.ToBitmap();
                    System.IntPtr wparam = new IntPtr(0);
                    System.IntPtr lparam = new IntPtr(0);
                    PostMessage(pControl.Handle.ToInt32(), Func.WM_USER_REDRAW_FORM, wparam, lparam);
                }
            }
            if (pSQL_Table.iFillTableData==0)
            {
                if (DifferentToIndexInitialValue())
                {
                    pic_Changed.Changed = true;
                }
                else
                {
                    pic_Changed.Changed = false;
                }
                SetEvent_IndexChanged(this.pSQL_Table, this);
            }
        }

        void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.pSQL_Table.SetInputControls != null)
            {
                if (this.pSQL_Table.SetInputControls(this.pSQL_Table,nav))
                {
                    if (DifferentToIndexInitialValue())
                    {
                        SetEvent_IndexChanged(this.pSQL_Table, this);
                    }
                }
            }
            else
            {
                m_EditTable_Assistant_Form = new EditTable_Assistant_Form(this, pSQL_Table, ID_v, m_DBTables, Cursor.Position.X + btnSelect.Width, Cursor.Position.Y - btnSelect.Height);
                if (m_EditTable_Assistant_Form.ShowDialog() == DialogResult.OK)
                {
                    if (DifferentToIndexInitialValue())
                    {
                        SetEvent_IndexChanged(this.pSQL_Table, this);
                    }
                }
            }
        }

        //[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        //protected override void WndProc(ref Message m)
        //{
        //    // Listen for operating system messages.
        //    if (m.Msg == (int)WM_RBUTTONUP)
        //    {
        //        if (bExpanded)
        //        {
        //            //MessageBox.Show("Mouse Button UP Table: " + pSQL_Table.TableName);
        //            if (m_EditTable_Assistant_Form == null)
        //            {
        //                m_EditTable_Assistant_Form = new EditTable_Assistant_Form(this, pSQL_Table, m_DBTables);
        //                m_EditTable_Assistant_Form.Show();
        //            }
        //            else
        //            {
        //                if (m_EditTable_Assistant_Form.IsDisposed)
        //                {
        //                    m_EditTable_Assistant_Form = new EditTable_Assistant_Form(this, pSQL_Table, m_DBTables);
        //                    m_EditTable_Assistant_Form.Show();
        //                }
        //                else
        //                {
        //                    m_EditTable_Assistant_Form.TopLevel = true;
        //                    m_EditTable_Assistant_Form.Focus();
        //                }
        //            }
        //        }
        //    }
        //    base.WndProc(ref m);
        //}


        internal void FillInputControls(long Identity, bool bSetInitialValues)
        {
            string csError = "";
            if (!this.pSQL_Table.FillDataInputControl(m_DBTables.m_con, Identity,bSetInitialValues, ref csError))
            {
                LogFile.Error.Show(csError);
            }
        }

        internal void Show_And_Init_Reference_ID()
        {


            if (ixt_ID == null)
            {
                int x;
                x = btnExpand.Left + btnExpand.Width + 2;
                if (usrc_lbl != null)
                {
                    x = usrc_lbl.Left + x + usrc_lbl.Width + 2;
                }
                ixt_ID = new IndexBox();
                ixt_ID.Width = 60;
                ixt_ID.Left = x;
                ixt_ID.Top = btnExpand.Top;
                ixt_ID.ReadOnly = true;
                ixt_ID.BackColor = Color.LightGray;
                this.grpBox.Controls.Add(ixt_ID);
                ixt_ID.Visible = true;
                x = ixt_ID.Left + ixt_ID.Width + 2;
                btnSelect.Left = x;
            }
            if (ixt_ID != null)
            {
                if (this.pSQL_Table.current_row_ID != null)
                {
                    ixt_ID.Text = this.pSQL_Table.current_row_ID.v.ToString();
                    if (pSQL_Table.iFillTableData > 0)
                    {
                        IndexInitialValue = this.pSQL_Table.current_row_ID.v;
                    }
                    ixt_ID.Enabled = true;
                    if (usrc_lbl != null)
                    {
                        usrc_lbl.InitNoData(false);
                    }
                }
                else
                {
                    ixt_ID.Enabled = false;
                    if (usrc_lbl != null)
                    {
                        usrc_lbl.InitNoData(true);
                    }
                    if (pSQL_Table.iFillTableData > 0)
                    {
                        IndexInitialValue = null;
                    }
                }   
            }

        }

        internal void Hide_And_Init_Reference_ID()
        {
            if (ixt_ID == null)
            {
                int x;
                x = btnExpand.Left + btnExpand.Width + 2;
                if (usrc_lbl != null)
                {
                    x = usrc_lbl.Left + x + usrc_lbl.Width + 2;
                }
                ixt_ID = new IndexBox();
                ixt_ID.Width = 60;
                ixt_ID.Left = x;
                ixt_ID.Top = btnExpand.Top;
                ixt_ID.ReadOnly = true;
                ixt_ID.BackColor = Color.LightGray;
                this.grpBox.Controls.Add(ixt_ID);
                ixt_ID.Visible = true;
                x = ixt_ID.Left + ixt_ID.Width + 2;
                btnSelect.Left = x;
            }
            if (ixt_ID != null)
            {
                this.pSQL_Table.current_row_ID = null;
                ixt_ID.Enabled = false;
                ixt_ID.Valid = false;
                ixt_ID.Text = "";
                if (usrc_lbl != null)
                {
                    usrc_lbl.InitNoData(true);
                }
                foreach (Column col in this.pSQL_Table.Column)
                {
                    if (col.fKey != null)
                    {
                        col.fKey.fTable.myGroupBox.InitToDefault();
                    }
                    else
                    {
                        if (col.InputControl != null)
                        {
                            col.InputControl.InitToDefault();
                        }
                    }
                }
            }
        }

        private void InitToDefault()
        {
            Hide_And_Init_Reference_ID();
        }



        internal bool Get_ID(ref DBTypes.long_v id_v)
        {
            if (ixt_ID != null)
            {
                if (ixt_ID.Valid)
                {
                    long id = Convert.ToInt64(ixt_ID.Text);
                    if (id_v == null)
                    {
                        id_v = new DBTypes.long_v();
                    }
                    id_v.v = id;
                    return true;
                }
            }
            return false;
        }

        internal void MarkAsUndefined_Index()
        {
            if (ixt_ID != null)
            {
                //ixt_ID.BackColor = Color.Red;
            }
        }

        internal void SetEvent_ObjectChanged(SQLTable tbl, usrc_InputControl InputControl)
        {
            if (usrc_InputControl_ObjectChanged != null)
            {
                usrc_InputControl_ObjectChanged(tbl,InputControl);
            }
        }

        internal void SetEvent_IndexChanged(SQLTable tbl, usrc_myGroupBox xmyGroupBox)
        {
            if (usrc_myGroupBox_IndexChanged != null)
            {
                usrc_myGroupBox_IndexChanged(tbl, xmyGroupBox);
            }

        }


        internal bool SetEvent_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table,List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, CodeTables.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (RowReferenceFromTable_Check_NoChangeToOther != null)
            {
                return RowReferenceFromTable_Check_NoChangeToOther(pSQL_Table, usrc_RowReferencedFromTable_List, id_v, ref bCancelDialog, ref Instruction);
            }
            else
	        {
                bCancelDialog = true;
                return false;
            }
        }


        internal void DeleteControls()
        {
            if (this.ixt_ID != null)
            {
                ixt_ID.Dispose();
                ixt_ID = null;
            }
            if (this.usrc_lbl != null)
            {
                usrc_lbl.Dispose();
                usrc_lbl = null;
            }
            if (this.btnSelect != null)
            {
                btnSelect.Dispose();
                btnSelect = null;
            }
            if (this.btnExpand != null)
            {
                btnExpand.Dispose();
                btnExpand = null;
            }
        }



        internal void Unique_parameter_exist_Dialog_EventTrigger(SQLTable tbl, Column col, DataTable dt,object value, ref bool bHandled)
        {
            if (this.Unique_parameter_exist != null)
            {
                Unique_parameter_exist(tbl, col, dt, value,ref bHandled);
            }

        }


    }
}
