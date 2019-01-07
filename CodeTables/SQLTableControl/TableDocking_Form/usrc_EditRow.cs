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
using LanguageControl;
using StaticLib;
using System.Runtime.InteropServices;
using NavigationButtons;
using UniqueControlNames;
using DBConnectionControl40;

namespace CodeTables.TableDocking_Form
{
    public partial class usrc_EditRow : UserControl
    {

        public UniqueControlName uctrln = new UniqueControlName();

        public delegate void delegate_before_New(SQLTable m_tbl, ref bool bCancel);
        public delegate void delegate_after_New(SQLTable m_tbl, bool bRes);

        public delegate void delegate_before_InsertInDataBase(SQLTable m_tbl,ref bool bCancel,ref Transaction transaction);
        public delegate void delegate_after_InsertInDataBase(SQLTable m_tbl,ID id,bool bRes, Transaction transaction);

        public delegate void delegate_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel,ref Transaction transaction);
        public delegate void delegate_after_UpdateDataBase(SQLTable m_tbl,ID id,bool bRes, Transaction transaction);


        public event SQLTable.delegate_FillTable FillTable = null;
        public event SQLTable.delegate_mySetInputControlProperties SetInputControlProperties = null;

        public event delegate_before_New before_New = null;
        public event delegate_after_New after_New = null;

        public event delegate_before_InsertInDataBase before_InsertInDataBase = null;
        public event delegate_after_InsertInDataBase after_InsertInDataBase = null;

        public event delegate_before_UpdateDataBase before_UpdateDataBase = null;
        public event delegate_after_UpdateDataBase after_UpdateDataBase = null;

        public delegate bool delegate_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction);
        public event delegate_RowReferenceFromTable_Check_NoChangeToOther RowReferenceFromTable_Check_NoChangeToOther = null;

        public delegate void delegate_after_FillDataInputControl(SQLTable m_tbl, ID ID);
        public event delegate_after_FillDataInputControl after_FillDataInputControl = null; 
          
        public enum eMode { NEW, VIEW, EDIT };

        private eMode m_eMode = eMode.NEW;
        DBTableControl m_DBTables = null;
        TransactionLog_delegates m_TransactionLog_delegates = null;

        public SQLTable m_tbl;

        public MyTabControl m_TabControl;
        Random rand = null;
        public delegate void delegate_Update(bool res, ID ID,string Err);
        public new event delegate_Update Update = null;



        private bool bNewEntry;
        public Globals.delegate_SetControls SetControls = null;

        public bool m_SelectionButtonVisible = true;
        private Navigation nav = null;

        private string m_TransactionName = null;
        public string TransactionName
        {
            get
            {
                return m_TransactionName;
            }
            internal set
            {
                m_TransactionName = value;
            }
        }

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

        public new void Text(ltext xltext)
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

        public void Init(DBTableControl dbTables,
                 TransactionLog_delegates xTransactionLog_delegates,
                 SQLTable tbl,
                 Globals.delegate_SetControls xSetControls,
                 bool bReadOnly,
                 NavigationButtons.Navigation xnav,
                 string transaction_name
                 )
        {
            m_TransactionName = transaction_name;
            Init(dbTables,
                 xTransactionLog_delegates,
                 tbl,
                 xSetControls,
                 bReadOnly,
                 xnav);
                 
        }

        public void Init(DBTableControl dbTables,
                         TransactionLog_delegates xTransactionLog_delegates,
                         SQLTable tbl,
                         Globals.delegate_SetControls xSetControls,
                         bool bReadOnly,
                         NavigationButtons.Navigation xnav
                         )
        {
            if (m_TransactionName == null)
            {
                SetDefaultTransactionName(this);
            }
            nav = xnav;
            rand = new Random();

            SetControls = xSetControls;

            this.BtnCallSecretaryToWork.Text = lng.sBtnCallSecretaryToWork.s;

            this.btn_Insert.Text = lng.sInsertData.s;
            this.btn_Update.Text = lng.sUpdate.s;
            this.btn_Update.Visible = false;
            this.btn_New.Text = lng.sNew.s;
            m_DBTables = dbTables;
            m_TransactionLog_delegates = xTransactionLog_delegates;
            m_tbl = tbl;
            m_tbl.SelectionButtonVisible = m_SelectionButtonVisible;
            CreateInputControls(bReadOnly, uctrln, xnav);
            bNewDataEntry = true;
        }

        internal void SetDefaultTransactionName(Control xctrl)
        {
            Form parent_form = Global.f.GetParentForm(xctrl);
            string sparent_form_name = "";
            string sxctrl_name = "";
            if (parent_form != null)
            {
                if (parent_form.Name != null)
                {
                    sparent_form_name = parent_form.Name;
                }
            }
            if (xctrl.Name!=null)
            {
                sxctrl_name = xctrl.Name;
            }
            TransactionName = sparent_form_name + "." + sxctrl_name;
        }

        private void CreateInputControls(bool bReadOnly,UniqueControlName xuctrln,NavigationButtons.Navigation xnav)
        {
            m_tbl.DeleteInputControls();

            MySize size = new MySize();
            size.cx = 0;
            size.cy = 0;

            m_tbl.CreateInputControls(null, xuctrln, null, "", ref m_tbl.inpCtrlList, this.pnl_Editor, this, m_DBTables, bReadOnly, xnav);
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

        public void KeyPressed(Keys k)
        {
            switch (k)
            {
                case Keys.F2:
                    if ((this.btn_Update.Visible) & (this.btn_Update.Enabled))
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Transaction transaction_usrc_EditRow_KeyPressed_UpdateDataBase = new Transaction(m_TransactionLog_delegates,appendTransactionName("usrc_EditRow.KeyPressed.UpdateDataBase"));
                        if (UpdateDataBase(ref transaction_usrc_EditRow_KeyPressed_UpdateDataBase))
                        {
                            transaction_usrc_EditRow_KeyPressed_UpdateDataBase.Commit();
                        }
                        else
                        {
                            transaction_usrc_EditRow_KeyPressed_UpdateDataBase.Rollback();
                        }
                        this.Cursor = Cursors.Arrow;
                    }
                    break;
            }
        }

        private string appendTransactionName(string transaction_suffix)
        {
            if (m_TransactionName!=null)
            {
                return m_TransactionName + "." + transaction_suffix;
            }
            else
            {
                return transaction_suffix;
            }
        }

        void myGroupBox_Unique_parameter_exist(SQLTable tbl, Column col, DataTable dt, object value,ref bool bHandled)
        {
            
        }

        bool myGroupBox_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            if (RowReferenceFromTable_Check_NoChangeToOther != null)
            {
                return RowReferenceFromTable_Check_NoChangeToOther(pSQL_Table, usrc_RowReferencedFromTable_List, id, ref bCancelDialog, ref Instruction);
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
                StringBuilder sDataBaseused = new StringBuilder("USE " + m_DBTables.Con.DataBase);
                Transaction transaction_usrc_EditRow_WndProc_WM_USER_GENERATE_RANDOM_INPUT_InsertInDataBase_WithImportText = new Transaction(m_TransactionLog_delegates, appendTransactionName("usrc_EditRow.WndProc.WM_USER_GENERATE_RANDOM_INPUT.InsertInDataBase_WithImportText"));
                if (Globals.InsertInDataBase_WithImportText(SetControls,
                                                            m_tbl,
                                                            m_DBTables,
                                                            sDataBaseused,
                                                            false,
                                                            transaction_usrc_EditRow_WndProc_WM_USER_GENERATE_RANDOM_INPUT_InsertInDataBase_WithImportText))
                {

                    if (transaction_usrc_EditRow_WndProc_WM_USER_GENERATE_RANDOM_INPUT_InsertInDataBase_WithImportText.Commit())
                    {
                        m_tbl.ClearInputControls_bManualyChanged();
                        //string csError = "";
                        //m_DB.SQLcmd_InsertTable(this, this.m_tbl, ref csError);
                        System.IntPtr wparam = new IntPtr(this.Handle.ToInt32());
                        //System.IntPtr lparam = new IntPtr(0);
                        PostMessage(m.WParam.ToInt32(), Func.WM_USER_GENERATE_RANDOM_INPUT_OK, wparam, m.LParam);
                    }
                }
                else
                {
                    transaction_usrc_EditRow_WndProc_WM_USER_GENERATE_RANDOM_INPUT_InsertInDataBase_WithImportText.Rollback();
                }
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

        internal bool InsertingNewRow
        {
            get
            {
                return (btn_Insert.Visible && Changed);
            }
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
                MessageBox.Show(lng.s_YouCanNotStartVirtualSecretaryUntilRandomDataParentAreSet.s);
            }
        }






        public void ShowTableRow(ID Identity)
        {
            string csError = "";
            bNewDataEntry = false;
            if (this.m_tbl.FillDataInputControl(m_DBTables.Con, uctrln, Identity, true,ref csError))
            {
                if (this.m_tbl.myGroupBox != null)
                {
                    this.m_tbl.myGroupBox.Changed_up = false;
                }
                SetMode(eMode.VIEW);
                this.m_tbl.Show_And_Init_Reference_ID(uctrln);
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
            ID insertedRow_ID = null;
            Transaction transaction_usrc_EditRow_btnInsertInDataBase_Click_InsertInDataBase = new Transaction( m_TransactionLog_delegates, appendTransactionName("usrc.EditRow_btnInsertInDataBase_Click.InsertInDataBase"));
            if (InsertInDataBase(ref insertedRow_ID,
                                ref transaction_usrc_EditRow_btnInsertInDataBase_Click_InsertInDataBase))
            {
                transaction_usrc_EditRow_btnInsertInDataBase_Click_InsertInDataBase.Commit();
            }
            else
            {
                transaction_usrc_EditRow_btnInsertInDataBase_Click_InsertInDataBase.Rollback();
            }
            this.Cursor = Cursors.Arrow;
        }
        private bool InsertInDataBase(ref ID insertedRow_ID,ref Transaction transaction)
        {
           string mymsg = null;
            m_tbl.Check_Null_Values(ref mymsg);
            if (mymsg==null)
            {
                bool bCancel = false;
                if (before_InsertInDataBase != null)
                {
                    before_InsertInDataBase(m_tbl, ref bCancel,ref transaction);
                }
                if (bCancel)
                {
                    return false;
                }
                else
                {
                    string Err = null;
                    bool bRes = false;
                    //StringBuilder sDataBaseused = new StringBuilder("USE " + m_DBTables.m_con.DataBase);

                    //bRes = Globals.InsertInDataBase_WithImportText(SetControls, m_tbl, m_DBTables, sDataBaseused, false);
                    //if (bRes)
                    //{
                    //    MessageBox.Show(this, lng.s_DataInsertedIntoDataBaseOK.s, lng.s_Info.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    ID ID = null;
                    bRes = m_tbl.Insert(ref ID, m_DBTables, transaction);
                    if (bRes)
                    {
                        this.Changed = false;
                        btn_Insert.Visible = false;
                        if (Update != null)
                        {
                            Update(bRes, ID, Err);

                        }
                        insertedRow_ID = ID;
                        //Bug fix for recognising new editing immediately after inserting in database
                        this.m_tbl.FillDataInputControl(m_DBTables.Con, uctrln, ID, false, ref Err); 
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
                        after_InsertInDataBase(m_tbl,ID, bRes, transaction);
                    }
                    return bRes;
                }
            }
            else
            {
                MessageBox.Show(mymsg);
                return false;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaction transaction_usrc_EditRow_btn_Update_Click_UpdateDataBase = new Transaction(m_TransactionLog_delegates, appendTransactionName("usrc_EditRow.btn_Update_Click.UpdateDataBase"));
            if (UpdateDataBase(ref transaction_usrc_EditRow_btn_Update_Click_UpdateDataBase))
            {
                transaction_usrc_EditRow_btn_Update_Click_UpdateDataBase.Commit();
            }
            else
            {
                transaction_usrc_EditRow_btn_Update_Click_UpdateDataBase.Rollback();
            }
            this.Cursor = Cursors.Arrow;
        }

        private bool UpdateDataBase(ref Transaction transaction)
        {
            string mymsg = null;
            m_tbl.Check_Null_Values(ref mymsg);
            if (mymsg==null)
            {
                bool bCancel = false;
                if (before_UpdateDataBase!=null)
                {
                    before_UpdateDataBase(this.m_tbl, ref bCancel, ref transaction);
                }
                if (bCancel)
                {
                    return false;
                }
                else
                {
                    string Err = null;
                    ID ID = null;
                    bool bRes = m_tbl.UpdateInputControls(m_DBTables,
                                                          ref ID,
                                                          ref Err,
                                                          transaction);
                    if (Update != null)
                    {
                        Update(bRes, ID, Err);
                        if (ID.Validate(ID))
                        {
                            ShowTableRow(ID);
                        }
                    }
                    if (after_UpdateDataBase != null)
                    {
                        after_UpdateDataBase(this.m_tbl,ID, bRes,transaction);
                    }
                    return bRes;
                }
            }
            else
            {
                MessageBox.Show(mymsg);
                return false;
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
            UniqueControlName xuctrln = new UniqueControlName();
            CreateInputControls(false, xuctrln, nav);
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

        public bool Save(ref Transaction transaction)
        {
            if (btn_Insert.Visible && btn_Insert.Enabled)
            {
                ID insertedRow_ID = null;
                return InsertInDataBase(ref insertedRow_ID,ref transaction);
            }
            else if (btn_Update.Visible && btn_Update.Enabled)
            {
                return UpdateDataBase(ref transaction);
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            if (m_tbl!=null)
            {
                m_tbl.DeleteInputControls();
            }
        }

        public void FillInitialData()
        {

            foreach (Column col in m_tbl.Column)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
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
