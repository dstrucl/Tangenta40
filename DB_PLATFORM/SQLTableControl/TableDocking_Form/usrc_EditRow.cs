using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using StaticLib;
using System.Runtime.InteropServices;

namespace SQLTableControl.TableDocking_Form
{
    public partial class usrc_EditRow : UserControl
    {

        public delegate void delegate_before_New(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_New(SQLTable m_tbl, bool bRes);

        public delegate void delegate_before_InsertInDataBase(SQLTable m_tbl,ref bool bCancel);
        public delegate void delegate_after_InsertInDataBase(SQLTable m_tbl,long id,bool bRes);

        public delegate void delegate_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_UpdateDataBase(SQLTable m_tbl,long id,bool bRes);


        public event SQLTable.delegate_FillTable FillTable = null;
        public event SQLTable.delegate_mySetInputControlProperties SetInputControlProperties = null;

        public event delegate_before_New before_New = null;
        public event delegate_after_New after_New = null;

        public event delegate_before_InsertInDataBase before_InsertInDataBase = null;
        public event delegate_after_InsertInDataBase after_InsertInDataBase = null;

        public event delegate_before_UpdateDataBase before_UpdateDataBase = null;
        public event delegate_after_UpdateDataBase after_UpdateDataBase = null;

        public delegate bool delegate_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction);
        public event delegate_RowReferenceFromTable_Check_NoChangeToOther RowReferenceFromTable_Check_NoChangeToOther = null;

        public delegate void delegate_after_FillDataInputControl(SQLTable m_tbl, long ID);
        public event delegate_after_FillDataInputControl after_FillDataInputControl = null; 
          
        public enum eMode { NEW, VIEW, EDIT };

        private eMode m_eMode = eMode.NEW;
        DBTableControl m_DBTables;
        public SQLTable m_tbl;

        public MyTabControl m_TabControl;
        Random rand = null;
        public delegate void delegate_Update(bool res, long ID,string Err);
        public event delegate_Update Update = null;



        private bool bNewEntry;
        public Globals.delegate_SetControls SetControls = null;

        public bool m_SelectionButtonVisible = true;

        public bool Changed
        {
            get { if (m_tbl!=null)
                  {
                      if (m_tbl.myGroupBox != null)
                      {
                          return m_tbl.myGroupBox.Changed;
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

            set
            {
                if (m_tbl != null)
                {
                    if (m_tbl.myGroupBox != null)
                    {
                        m_tbl.myGroupBox.Changed_down = value;
                    }
                }
            }
        }

        public bool SelectionButtonVisible
        {
            get
            {
                if (this.m_tbl != null)
                {
                    m_SelectionButtonVisible = m_tbl.SelectionButtonVisible;
                }
                return m_SelectionButtonVisible;
            }
            set {
                    m_SelectionButtonVisible = value;
                    if (this.m_tbl != null)
                    {
                        m_tbl.SelectionButtonVisible = m_SelectionButtonVisible;
                    }
                }
        }

        public bool AllowUserToAddNew
        {
            get { return this.btn_New.Visible; }
            set { this.btn_New.Visible = value; }
        }

        public bool AllowUserToChange
        {
            get { return this.btn_Update.Visible; }
            set { this.btn_Update.Visible = value; }
        }

        public string Title
        {
            get
            {
                return lbl_Title.Text;
            }
            set
            {
                lbl_Title.Text = value;
            }
        }

        public void Text(ltext xltext)
        {
            xltext.Text(lbl_Title);
        }

        public Color Title_Color
        {
            get
            {
                return lbl_Title.ForeColor;
            }
            set
            {
                lbl_Title.ForeColor = value;
            }
        }

        public Font Title_Font
        {
            get
            {
                return lbl_Title.Font;
            }
            set
            {
                lbl_Title.Font = value;
            }
        }

        public usrc_EditRow()
        {
            InitializeComponent();
            lbl_Title.Text = "";
        }

        public bool GetRandomData
        {
            get
            {
                return BtnCallSecretaryToWork.Visible;
            }
            set
            {
                BtnCallSecretaryToWork.Visible = value;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);

        private void SetMode(eMode xMode)
        {
            m_eMode = xMode;
            //Control active = this.ActiveControl;
            switch (m_eMode)
            {
                case eMode.NEW:
                    //btn_New.Visible = true;
                    btn_New.Enabled = true;
                    //btn_Update.Visible = false;
                    btn_Update.Enabled = false;
                    //btn_Insert.Visible = true;
                    btn_Insert.Enabled = true;
                    break;
                case eMode.VIEW:
                    //btn_New.Visible = true;
                    btn_New.Enabled = true;
                    //btn_Update.Visible = false;
                    btn_Update.Enabled = false;
                    //btn_Insert.Visible = false;
                    btn_Insert.Enabled = false;
                    break;
                case eMode.EDIT:
                    //btn_New.Visible = true;
                    btn_New.Enabled = true;
                    //btn_Update.Visible = true;
                    btn_Update.Enabled = true;
                    //btn_Insert.Visible = false;
                    btn_Insert.Enabled = false;
                    break;
            }
            //if (active != null)
            //{
            //    active.Focus();
            //}
        }

        public eMode Mode
        {
            get { return m_eMode; }
        }

        public void Init(DBTableControl dbTables, SQLTable tbl, Globals.delegate_SetControls xSetControls, bool bReadOnly)
        {
            rand = new Random();

            SetControls = xSetControls;

            this.BtnCallSecretaryToWork.Text = lngRPM.sBtnCallSecretaryToWork.s;

            this.btn_Insert.Text = lngRPM.sInsertData.s;
            this.btn_Update.Text = lngRPM.sUpdate.s;
            this.btn_Update.Visible = false;
            this.btn_New.Text = lngRPM.sNew.s;
            m_DBTables = dbTables;
            m_tbl = tbl;
            m_tbl.SelectionButtonVisible = m_SelectionButtonVisible;
            CreateInputControls(bReadOnly);
            bNewDataEntry = true;
        }

        private void CreateInputControls(bool bReadOnly)
        {
            m_tbl.DeleteInputControls();

            MySize size = new MySize();
            size.cx = 0;
            size.cy = 0;

            m_tbl.CreateInputControls(null, null, "", ref m_tbl.inpCtrlList, this.pnl_Editor, this, m_DBTables, bReadOnly);
            m_tbl.myGroupBox.Left = 3;
            m_tbl.myGroupBox.Top = 3;


            m_tbl.RepositionInputControls(m_tbl.myGroupBox, ref size, 0);
            m_tbl.myGroupBox.Width = size.cx;
            m_tbl.myGroupBox.Height = size.cy;
            m_tbl.myGroupBox.Visible = true;
            if (!bReadOnly)
            { 
                m_tbl.myGroupBox.Unique_parameter_exist += new usrc_myGroupBox.delegate_Unique_parameter_exist(myGroupBox_Unique_parameter_exist);
                m_tbl.myGroupBox.RowReferenceFromTable_Check_NoChangeToOther += new usrc_myGroupBox.delegate_RowReferenceFromTable_Check_NoChangeToOther(myGroupBox_RowReferenceFromTable_Check_NoChangeToOther);
                m_tbl.myGroupBox.usrc_InputControl_ObjectChanged += new usrc_myGroupBox.delegate_ObjectChanged(myGroupBox_usrc_InputControl_ObjectChanged);
                m_tbl.myGroupBox.usrc_myGroupBox_IndexChanged += new usrc_myGroupBox.delegate_IndexChanged(myGroupBox_usrc_myGroupBox_IndexChanged);
            }

            this.BackColor = m_tbl.myGroupBox.BackColor;
        }

        void myGroupBox_Unique_parameter_exist(SQLTable tbl, Column col, DataTable dt, object value,ref bool bHandled)
        {
            
        }

        bool myGroupBox_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
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

        void myGroupBox_usrc_myGroupBox_IndexChanged(SQLTable tbl, usrc_myGroupBox myGroupBox)
        {
            if (this.Mode == eMode.VIEW)
            {
                if (m_tbl.AtLeastOneInputControlChanged())
                {
                    m_tbl.myGroupBox.Changed_up = true;
                    SetMode(eMode.EDIT);
                }
                else
                {
                    m_tbl.myGroupBox.Changed_up = false;
                }
            }
            else if (this.Mode == eMode.EDIT)
            {
                if (!m_tbl.AtLeastOneInputControlChanged())
                {
                    m_tbl.myGroupBox.Changed_up = false;
                    SetMode(eMode.VIEW);
                }
                else
                {
                    m_tbl.myGroupBox.Changed_up = true;
                }
            }
        }

        void myGroupBox_usrc_InputControl_ObjectChanged(SQLTable tbl,usrc_InputControl InputControl)
        {
            if (this.Mode == eMode.VIEW)
            {
                if (m_tbl.AtLeastOneInputControlChanged())
                {
                    //Control active = this.ActiveControl;
                    m_tbl.myGroupBox.Changed_up = true;
                    SetMode(eMode.EDIT);
                    //active.Focus();
                }
                else
                {
                    m_tbl.myGroupBox.Changed_up = false;
                }
            }
            else if (this.Mode == eMode.EDIT)
            {
                if (!m_tbl.AtLeastOneInputControlChanged())
                {
                    m_tbl.myGroupBox.Changed_up = false;
                    SetMode(eMode.VIEW);
                }
                else
                {
                    m_tbl.myGroupBox.Changed_up = true;
                }
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            if (m.Msg == (int)Func.WM_USER_REDRAW_FORM)
            {
                // The WParam value identifies what is occurring.
                // Invalidate to get new text painted.
                MySize size = new MySize();
                size.cx = 0;
                size.cy = 0;
                //m_tbl.myGroupBox.Top = 60;
                m_tbl.RepositionInputControls(m_tbl.myGroupBox, ref size, 0);
                m_tbl.myGroupBox.Width = size.cx;
                m_tbl.myGroupBox.Height = size.cy;
                m_tbl.myGroupBox.Visible = true;
                this.BackColor = m_tbl.myGroupBox.BackColor;
                this.Invalidate();
            }
            else if (m.Msg == (int)Func.WM_USER_GENERATE_RANDOM_INPUT)
            {
                InsertRandomData();
                StringBuilder sDataBaseused = new StringBuilder("USE " + m_DBTables.m_con.DataBase);
                Globals.InsertInDataBase_WithImportText(SetControls, m_tbl, m_DBTables, sDataBaseused, false);
                m_tbl.ClearInputControls_bManualyChanged();
                //string csError = "";
                //m_DB.SQLcmd_InsertTable(this, this.m_tbl, ref csError);
                System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
                //System.IntPtr lparam = new IntPtr(0);
                PostMessage(m.WParam.ToInt32(), Func.WM_USER_GENERATE_RANDOM_INPUT_OK, wparam, m.LParam);
            }
            else if (m.Msg == (int)Func.WM_DO_RANDOM_PARAM_SETTINGS_DIALOG)
            {
                if (!Func.bRANDOM_PARAM_SETTINGS_DIALOG_IS_RUNNING)
                {
                    Func.bRANDOM_PARAM_SETTINGS_DIALOG_IS_RUNNING = true;

                    //RandomGenerator.RandomDataParam_Form RandomDataParamDlg = new RandomGenerator.RandomDataParam_Form(m_DB, m_tbl,false);
                    //RandomDataParamDlg.ShowDialog();
                    this.m_DBTables.m_dCheckRandomParamSettings(m_tbl, false);


                    System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
                    PostMessage(m.WParam.ToInt32(), Func.WM_RANDOM_PARAM_SETTINGS_DIALOG_CLOSED, wparam, m.LParam);
                    Func.bRANDOM_PARAM_SETTINGS_DIALOG_IS_RUNNING = false;

                    //Call Delegate Function !!
                }
            }
            else if (m.Msg == (int)Func.WM_USER_GENERATE_RANDOM_INPUT_DONE)
            {
                if (SetControls != null)
                {
                    SetControls(m_tbl);
                }
            }


            base.WndProc(ref m);
        }

        private void InsertRandomData()
        {
            Random rd = new Random();
            bool bGenderMan;
            if (rd.NextDouble() > 0.5) bGenderMan = false;
            else bGenderMan = true;
            Random rand = new Random();
            this.m_tbl.GetRandomData(m_tbl.myGroupBox, ref bGenderMan, m_DBTables.m_dControlRandomData, bGenderMan);
        }



        private void BtnGetRandomDataParameters_Click(object sender, EventArgs e)
        {
            if (m_DBTables.m_dCheckRandomParamSettings(m_tbl, true))
            {
                VirtualSecretary_Thread VSecretaryThread = new VirtualSecretary_Thread();
                VSecretaryThread.StartThread(m_tbl, this);
            }
            else
            {
                MessageBox.Show(lngRPM.s_YouCanNotStartVirtualSecretaryUntilRandomDataParentAreSet.s);
            }
        }






        public void ShowTableRow(long Identity)
        {
            string csError = "";
            bNewDataEntry = false;
            if (this.m_tbl.FillDataInputControl(m_DBTables.m_con, Identity, true,ref csError))
            {
                if (this.m_tbl.myGroupBox != null)
                {
                    this.m_tbl.myGroupBox.Changed_up = false;
                }
                SetMode(eMode.VIEW);
                this.m_tbl.Show_And_Init_Reference_ID();
                if (after_FillDataInputControl!=null)
                {
                    after_FillDataInputControl(this.m_tbl, Identity);
                }
            }
            else
            {
                MessageBox.Show("Error: Can not do FillDataInputControl(..) :" + csError);
            }
        }

        private void btnInsertInDataBase_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            InsertInDataBase();
            this.Cursor = Cursors.Arrow;
        }
        private void InsertInDataBase()
        {
           string mymsg = null;
            m_tbl.Check_Null_Values(ref mymsg);
            if (mymsg==null)
            {
                bool bCancel = false;
                if (before_InsertInDataBase != null)
                {
                    before_InsertInDataBase(m_tbl, ref bCancel);
                }
                if (bCancel)
                {
                    return;
                }
                else
                {
                    string Err = null;
                    bool bRes = false;
                    //StringBuilder sDataBaseused = new StringBuilder("USE " + m_DBTables.m_con.DataBase);

                    //bRes = Globals.InsertInDataBase_WithImportText(SetControls, m_tbl, m_DBTables, sDataBaseused, false);
                    //if (bRes)
                    //{
                    //    MessageBox.Show(this, lngRPM.s_DataInsertedIntoDataBaseOK.s, lngRPM.s_Info.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    long ID = -1;
                    bRes = m_tbl.Insert(ref ID, m_DBTables);
                    if (bRes)
                    {
                        this.Changed = false;
                        btn_Insert.Visible = false;
                        if (Update != null)
                        {
                            Update(bRes, ID, Err);

                        }
                    }
                    else
                    {
                        {
                            Err = "ERROR:Insert in database failed!";
                            LogFile.Error.Show(Err);
                        }
                    }
                    if (after_InsertInDataBase != null)
                    {
                        after_InsertInDataBase(m_tbl,ID, bRes);
                    }
                }
            }
            else
            {
                MessageBox.Show(mymsg);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            UpdateDataBase();
            this.Cursor = Cursors.Arrow;
        }

        private void UpdateDataBase()
        {
            string mymsg = null;
            m_tbl.Check_Null_Values(ref mymsg);
            if (mymsg==null)
            {
                bool bCancel = false;
                if (before_UpdateDataBase!=null)
                {
                    before_UpdateDataBase(this.m_tbl, ref bCancel);
                }
                if (bCancel)
                {
                    return;
                }
                else
                {
                    string Err = null;
                    long ID = -1;
                    bool bRes = m_tbl.UpdateInputControls(m_DBTables, ref ID, ref Err);
                    if (Update != null)
                    {
                        Update(bRes, ID, Err);
                        if (ID >= 0)
                        {
                            ShowTableRow(ID);
                        }
                    }
                    if (after_UpdateDataBase != null)
                    {
                        after_UpdateDataBase(this.m_tbl,ID, bRes);
                    }
                }
            }
            else
            {
                MessageBox.Show(mymsg);
            }

        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool bCancel = false;
            if (before_New != null)
            {
                before_New(this.m_tbl, ref bCancel);
                if (bCancel)
                {
                    if (after_New != null)
                    {
                        after_New(this.m_tbl, false);
                    }
                    this.Cursor = Cursors.Arrow;
                    return;
                }
            }
            this.bNewDataEntry = true;
            this.m_tbl.ClearInputControls();
            CreateInputControls(false);
            SetMode(eMode.NEW);
            if (after_New != null)
            {
                after_New(this.m_tbl, true);
            }
            this.Cursor = Cursors.Arrow;
        }

        public bool bNewDataEntry
        {
            get
            {
                return bNewEntry;
            }
            set
            {
                if (value == true)
                {
                    this.bNewEntry = true;
                    //m_tbl.ClearInputControls();
                    //CreateInputControls();
                    this.btn_Update.Visible = false;
                    this.btn_Insert.Visible = true;
                }
                else
                {
                    this.bNewEntry = false;
                    //m_tbl.ClearInputControls();
                    //CreateInputControls();
                    this.btn_Update.Visible = true;
                    this.btn_Insert.Visible = false;
                }
            }
        }

        internal void Save()
        {
            if (btn_Insert.Visible && btn_Insert.Enabled)
            {
                InsertInDataBase();
            }
            else if (btn_Update.Visible && btn_Update.Enabled)
            {
                UpdateDataBase();
            }
        }

        public void Clear()
        {
            if (m_tbl!=null)
            {
                m_tbl.DeleteInputControls();
            }
        }

        internal void FillInitialData()
        {
            foreach (Column col in m_tbl.Column)
            {
                if (col.fKey!=null)
                {
                    if (col.fKey.fTable!=null)
                    {
                        col.fKey.fTable.FillTable(myFill);
                    }
                }
            }
        }
        internal void myFill(SQLTable tbl)
        {
            if (FillTable!=null)
            {
                FillTable(tbl);
            }
        }

        internal void CallBackSetInputControlProperties(object obj)
        {
            foreach (Column col in m_tbl.Column)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
                    {
                        col.fKey.fTable.SetInputControlProperties(mySetInputControlProperties, obj);
                    }
                }
                else
                {
                    mySetInputControlProperties(col,obj);
                }
            }
        }

        internal void mySetInputControlProperties(Column col, object obj)
        {
            if (SetInputControlProperties != null)
            {
                SetInputControlProperties(col, obj);
            }
        }

    }
}
