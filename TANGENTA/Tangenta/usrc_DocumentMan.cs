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
using LanguageControl;
using TangentaDB;
using DBTypes;
using UpgradeDB;
using NavigationButtons;
using Startup;
using static Tangenta.Program;
using DBConnectionControl40;
using Global;

namespace Tangenta
{
    public partial class usrc_DocumentMan : UserControl
    {
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

        private SettingsUserValues mSettingsUserValues = null;

        internal LoginControl.LMOUser m_LMOUser = null;

        private Door door = null;

        private Form_Document m_Form_Document = null;

        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public delegate void delegate_Exit_Click(string sDocInvoice, ID doc_ID, LoginControl.LMOUser m_LMOUser, LoginControl.LoginCtrl.eExitReason eReason);

        private int timer_Login_MultiUsers_Countdown = 100;


        public event delegate_Exit_Click Exit_Click;

        internal CtrlLayout cl_btn_New = null;
        internal CtrlLayout cl_cmb_InvoiceType = null;
        internal CtrlLayout cl_lbl_FinancialYear = null;

        internal bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;

        public List<DocType> List_DocType = new List<DocType>();
        public DocType DocType_DocInvoice = null;
        public DocType DocType_DocProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();


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
                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:SetSplitContainer 1 SplitterDistance:Err=" + Err);
                }

            }
        }

        internal bool m_usrc_Invoice_ViewMode
        {
            get { return m_usrc_DocumentEditor.m_mode == usrc_DocumentEditor.emode.view_eDocumentType; }
        }

        private string m_DocTyp = null;

        public string DocTyp
        {
            get {
                    if (m_DocTyp == null)
                    {
                         if (!this.DesignMode) LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:property DocTyp: DocTyp is not defined (m_DocInvoice = null)!");
                    }
                    return m_DocTyp;
                }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    m_DocTyp = s;
                    m_usrc_DocumentEditor.DocTyp = s;
                    m_usrc_TableOfDocuments.DocTyp = s;
                }
                else
                {
                    if (s != null)
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:property string DocTyp: DocTyp = " + s + " is not implemented!");
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:property string DocTyp: DocTyp  value ==  null");
                    }

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

        public bool m_usrc_InvoiceTable_Visible
        {
            get { return splitContainer1.Panel2Collapsed == false; }
        }

        public bool m_usrc_Invoice_Visible
        {
            get { return splitContainer1.Panel1Collapsed == false; }
        }

        public bool ShopA_Visible
        {
            get {
                    if (m_usrc_DocumentEditor!=null)
                    {
                        return m_usrc_DocumentEditor.ShopsMode.Contains("A");
                    }
                    else
                    {
                        return false;
                    }
                } 
        }

        public bool ShopB_Visible
        { 
            get
            {
                if (m_usrc_DocumentEditor != null)
                {
                    return m_usrc_DocumentEditor.ShopsMode.Contains("B");
                }
                else
                {
                    return false;
                }
            }
        } 

        public bool ShopC_Visible
        {
            get
            {
                if (m_usrc_DocumentEditor != null)
                {
                    return m_usrc_DocumentEditor.ShopsMode.Contains("C");
                }
                else
                {
                    return false;
                }
            }
        }

        public bool m_usrc_InvoiceHead_Visible
        {
            get
            {
                if (m_usrc_DocumentEditor != null)
                {
                    return m_usrc_DocumentEditor.HeadVisible;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Active
        {
            get
            {
                return this.Visible;
            }

            internal  set
            {
                this.Visible = value;
                if (this.Visible)
                {
                    if (Program.RecordCashierActivity)
                    {
                        lbl_Cashier.Visible = true;
                        lbl_OpenedClosed.Visible = true;
                        switch (Program.CashierState)
                        {
                            case TangentaDB.CashierActivity.eCashierState.CLOSED:
                                lbl_OpenedClosed.Text = lng.s_CashierClosed.s;
                                lbl_OpenedClosed.ForeColor = Color.Red;
                                break;

                            case TangentaDB.CashierActivity.eCashierState.OPENED:
                                lbl_OpenedClosed.Text = lng.s_CashierOpened.s;
                                lbl_OpenedClosed.ForeColor = Color.Green;
                                break;
                        }
                    }
                    else
                    {
                        lbl_Cashier.Visible = false;
                        lbl_OpenedClosed.Visible = false;
                    }

                    if (Program.OperationMode.MultiUser)
                    {
                        if (Program.Login_MultipleUsers)
                        {
                            timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown;
                            this.timer_Login_MultiUser.Enabled = true;
                        }
                    }
                }
                else
                {
                    this.m_usrc_DocumentEditor.HideGroupHandlerForm();
                    this.timer_Login_MultiUser.Enabled = false;
                }
            }
        }

        public usrc_DocumentMan()
        {
            InitializeComponent();
            lng.s_btn_New.Text(btn_New);
            lng.s_Year.Text(lbl_FinancialYear);
            lng.s_Cashier.Text(lbl_Cashier);

m_usrc_DocumentEditor.LayoutChanged += M_usrc_Invoice_LayoutChanged;
        }

        private void M_usrc_Invoice_LayoutChanged()
        {
            if (this.LayoutChanged!=null)
            {
                this.LayoutChanged();
            }
        }

        public void SetInitialMode()
        {
            string sManagerMode = Properties.Settings.Default.eManagerMode;
            if ((sManagerMode.Contains("Shops")) && (sManagerMode.Contains("InvoiceTable")))
            {
                Mode = eMode.Shops_and_InvoiceTable;
            }
            else if (sManagerMode.Equals("Shops"))
            {
                Mode = eMode.Shops;
            }
            else if (sManagerMode.Equals("InvoiceTable"))
            {
                Mode = eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_DocumentMan:SetInitialMode:Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
                Mode = eMode.Shops_and_InvoiceTable;
            }


            m_Form_Document.loginControl1.SetAccessAuthentification(Properties.Settings.Default.AccessAuthentication);
            if (Program.Login_MultipleUsers)
            {
                initControlsRecursive(this.Controls);
            }
        }

        public void SetMode(eMode mode)
        {
            Mode = mode;
            if (mode == eMode.Shops)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
                Properties.Settings.Default.eManagerMode = "Shops";
            }
            else if (mode == eMode.InvoiceTable)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
                Properties.Settings.Default.eManagerMode = "InvoiceTable";
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = false;
                Properties.Settings.Default.eManagerMode = "Shops&InvoiceTable";
            }
            Properties.Settings.Default.Save();
        }

        private void Set_cmb_DocType()
        {
            if (this.cmb_DocType == null)
            {
                LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():this.cmb_InvoiceType == null");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():this.cmb_InvoiceType != null");
            }

            this.cmb_DocType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);


            string sLastDocInvoiceType = null;

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before if (Program.RunAs == null)");

            if (Program.RunAs == null)
            {
                sLastDocInvoiceType = mSettingsUserValues.LastDocInvoiceType;
                if (sLastDocInvoiceType.Equals(GlobalData.const_DocInvoice) || sLastDocInvoiceType.Equals(GlobalData.const_DocProformaInvoice))
                {
                    Program.RunAs = sLastDocInvoiceType;
                }
                else
                {
                    Program.RunAs = GlobalData.const_DocInvoice;
                }

            }
            else
            {
                sLastDocInvoiceType = Program.RunAs;
            }


            if (sLastDocInvoiceType.Equals(GlobalData.const_DocInvoice))
            {
                this.DocTyp = sLastDocInvoiceType;
            }
            else if (sLastDocInvoiceType.Equals(GlobalData.const_DocProformaInvoice))
            {
                this.DocTyp = sLastDocInvoiceType;
            }
            else
            {
                this.DocTyp = GlobalData.const_DocProformaInvoice;
            }

            mSettingsUserValues.LastDocInvoiceType = this.DocTyp;
            Properties.Settings.Default.Save();

            if (m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteInvoice }))
            {
                DocType_DocInvoice = new DocType(lng.s_Invoice.s, GlobalData.const_DocInvoice);
                List_DocType.Add(DocType_DocInvoice);
            }

            if (m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteProformaInvoice }))
            {
                DocType_DocProformaInvoice = new DocType(lng.s_DocProformaInvoice.s, GlobalData.const_DocProformaInvoice);
                List_DocType.Add(DocType_DocProformaInvoice);
            }

            if (List_DocType.Count>0)
            {
                this.cmb_DocType.DataSource = null;
                this.cmb_DocType.DataSource = List_DocType;
                this.cmb_DocType.DisplayMember = "DocType_Text_in_language";
                this.cmb_DocType.ValueMember = "Typ";
                if (List_DocType.Count > 1)
                {
                    this.cmb_DocType.Enabled = true;
                }
                else
                {
                    this.cmb_DocType.Enabled = false;
                }
            }
            else
            {
                this.cmb_DocType.Enabled = false;
            }

            Set_cmb_InvoiceType_selected_index();
        }

        internal bool InitMan()
        {
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():start!");
            Program.Cursor_Wait();

            Set_cmb_DocType();

            if (!SetFinancialYears())
            {
                return false;
            }


            splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before SetDocument()");

            bool bRes = SetDocument();

            this.cmb_DocType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
            SetColor();

            Program.Cursor_Arrow();
            return bRes;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            m_usrc_DocumentEditor.WizzardShow_ShopsVisible(xshops_inuse);
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            m_usrc_DocumentEditor.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
        }

        internal void WizzardShow_InvoiceTable_Visible(bool bvisible)
        {
            if (bvisible)
            {
                SetMode(usrc_DocumentMan.eMode.Shops_and_InvoiceTable);
            }
            else
            {
                SetMode(usrc_DocumentMan.eMode.Shops);
            }
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
            this.Refresh();
        }

        internal void WizzardShow_DocInvoice(string xDocInvoice)
        {
            if (xDocInvoice.Equals(GlobalData.const_DocProformaInvoice))
            {
                cmb_DocType.SelectedIndex = 1;
            }
            else if (xDocInvoice.Equals(GlobalData.const_DocInvoice))
            {
                cmb_DocType.SelectedIndex = 0;
            }
            this.Refresh();
            if (LayoutChanged != null)
            {
                LayoutChanged();
            }
        }

        private bool SetFinancialYears()
        {
            int Default_FinancialYear = mSettingsUserValues.FinancialYear;

            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;

            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref dt_FinancialYears, IsDocInvoice, IsDocProformaInvoice, ref Default_FinancialYear))
            {
                mSettingsUserValues.FinancialYear = Default_FinancialYear;
                cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:Init:GlobalData.SetFinancialYears Failed!");
                return false;
            }

        }

        private void Set_cmb_InvoiceType_selected_index()
        {
            if (this.cmb_DocType.Items.Count > 1)
            {
                int idx = find_cmb_DataType_Index(this.m_usrc_DocumentEditor.DocTyp);
                if (idx >= 0)
                {
                    this.btn_New.Enabled = true;
                    this.cmb_DocType.SelectedIndex = idx;
                    SetFinancialYears();
                }
            }
            else if (this.cmb_DocType.Items.Count == 1)
            {
                this.btn_New.Enabled = true;
                string xDoxtyp = ((DocType)this.cmb_DocType.Items[0]).Typ;
                this.DocTyp = xDoxtyp;
                SetFinancialYears();
            }
            else
            {
                cmb_FinancialYear.Enabled = false;
                this.cmb_DocType.Enabled = false;
                this.btn_New.Enabled = false;
            }
        }

        private int find_cmb_DataType_Index(string docTyp)
        {
            if (this.cmb_DocType.Items!=null)
            {
                int iCount = this.cmb_DocType.Items.Count;
                if (iCount >  0)
                {
                    for (int i=0;i<iCount;i++)
                    {
                        if (((DocType)this.cmb_DocType.Items[i]).Typ.Equals(docTyp))
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        internal bool SetDocument()
        {
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():before mthis.m_usrc_InvoiceTable.Init(..)");

            int iRowsCount = this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false, true, mSettingsUserValues.FinancialYear,null);

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():before m_usrc_Invoice.Init(xnav, this.m_usrc_InvoiceTable.Current_Doc_ID)");
            if (!m_usrc_DocumentEditor.Init(this.m_usrc_TableOfDocuments.Current_Doc_ID))
            {
                Program.Cursor_Arrow();
                return false;
            }

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():before SetInitialMode()");

            SetInitialMode();

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():after SetInitialMode()");

            SetMode(Mode);
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():End procedure ");
            return true;

        }

        internal void SaveSplitControlsSpliterDistance(SettingsUserValues xSettingsUserValues)
        {
            if (SplitContainer1_spd>0)
            {
                mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance = SplitContainer1_spd;
            }
            if (this.m_usrc_DocumentEditor != null)
            {
                this.m_usrc_DocumentEditor.SaveSplitControlsSpliterDistance(xSettingsUserValues);
            }
        }

        private void Cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
            if (drv["FinancialYear"] is int)
            {
                int iFinancialYear = (int)drv["FinancialYear"];
                if (iFinancialYear != mSettingsUserValues.FinancialYear)
                {
                    mSettingsUserValues.FinancialYear = iFinancialYear;
                    SetFinancialYears();
                    this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false,false, mSettingsUserValues.FinancialYear,null);
                }
            }
        }





        private void m_usrc_Invoice_DocInvoiceSaved(ID DocInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show_v = null;
            if (ID.Validate(DocInvoice_id))
            {
                Doc_ID_to_show_v = new ID(DocInvoice_id);
            }
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp,false,false, mSettingsUserValues.FinancialYear, Doc_ID_to_show_v);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(ID DocProformaInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show = null;
            if (ID.Validate(DocProformaInvoice_id))
            {
                Doc_ID_to_show = new ID(DocProformaInvoice_id);
            }
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false, false, mSettingsUserValues.FinancialYear, Doc_ID_to_show);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(ID DocInvoice_ID,bool bInitialise)
        {
            if (ID.Validate(DocInvoice_ID))
            {
                if (m_usrc_DocumentEditor.DoCurrent(DocInvoice_ID))
                {
                }
            }
            SetColor();
        }

        public void Reload()
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show_v = null;
            if (m_usrc_DocumentEditor.m_ShopABC != null)
            {
                if (m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc != null)
                {
                    if (ID.Validate(m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID))
                    {
                        Doc_ID_to_show_v = new ID(m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID);
                    }
                    this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false, false, mSettingsUserValues.FinancialYear, Doc_ID_to_show_v);
                }
            }
        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            if ((!Program.RecordCashierActivity)||(Program.CashierState == TangentaDB.CashierActivity.eCashierState.OPENED))
            {
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
                if (Program.UseWorkAreas)
                {
                    Form_NewDocument_WorkArea frm_new_workarea = new Form_NewDocument_WorkArea();
                    frm_new_workarea.ShowDialog(this);
                    switch (frm_new_workarea.eNewDocumentResult)
                    {
                        case Form_NewDocument.e_NewDocument.New_Empty:
                            New_Empty_Doc(frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID, frm_new_workarea.Warea);
                            break;

                        case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                            New_Copy_Of_SameDocType(frm_new_workarea.FinancialYear, frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID);
                            break;
                        case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                            New_Copy_To_Another_DocType(frm_new_workarea.FinancialYear, frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID);
                            break;
                    }
                }
                else
                {
                    Form_NewDocument frm_new = new Form_NewDocument(this, mSettingsUserValues);
                    frm_new.ShowDialog(this);
                    if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

                    switch (frm_new.eNewDocumentResult)
                    {
                        case Form_NewDocument.e_NewDocument.New_Empty:
                            New_Empty_Doc(frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, null);
                            break;

                        case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                            New_Copy_Of_SameDocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID);
                            break;
                        case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                            New_Copy_To_Another_DocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID);
                            break;
                    }
                }
            }
            else
            {
                XMessage.Box.Show(this, lng.s_YouCanNotWriteInvoices_CasshierIsClosed, MessageBoxIcon.Stop);
            }
        
        }

        private void New_Empty_Doc(xCurrency currency,ID xAtom_Currency_ID, WArea workArea)
        {
            Program.Cursor_Wait();
            if (cmb_DocType.SelectedItem is DocType)
            {
                DocType xDocType = (DocType)cmb_DocType.SelectedItem;
                DocTyp  = xDocType.Typ;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    int FinancialYear = (int)drv.Row.ItemArray[0];
                    Program.Cursor_Arrow();
                    if (Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(FinancialYear))
                    {
                        Program.Cursor_Wait();
                        m_usrc_DocumentEditor.SetNewDraft(m_LMOUser, DocTyp, FinancialYear, currency, xAtom_Currency_ID, workArea);
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;
                        m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                        m_usrc_TableOfDocuments.Init(DocTyp, true, false, FinancialYear /*Properties.Settings.Default.FinancialYear*/, null);
                        m_LMOUser.ReloadAdministratorsAndUserManagers();
                    }
                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_DocumentMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            Program.Cursor_Arrow();
        }

        internal void SetSplitControlsSpliterDistance()
        {
            if (mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance>0)
            {
                this.splitContainer1.SplitterDistance = mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance;
            }
            if (m_usrc_DocumentEditor!=null)
            {
                m_usrc_DocumentEditor.SetSplitControlsSpliterDistance(mSettingsUserValues);
            }
        }


        private bool Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(int financialYear)
        {
            if (IsDocInvoice)
            {
                DateTime t = DateTime.Now;
                int current_year = t.Year;
                if (financialYear == current_year)
                {
                    return true;
                }
                else
                {
                    int current_month = t.Month;
                    if ((current_month <= Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice) && (financialYear + 1 == current_year))
                    {
                        return true;
                    }
                    else
                    {
                        string smsg = lng.s_YouCanNotCreateNewInvoiceForPastFinancialYear.s + " " + financialYear + ".\r\n";
                        smsg += lng.s_NumberOfMonthAfterNewYearToAllowCreateNewInvoiceIs.s + " " + Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.ToString() + "\r\n";
                        XMessage.Box.Show(this, smsg, lng.s_Warning.s);
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        private bool ReadShopABC_items(ref List<object> xShopC_Data_Item_List, ref DataTable xdt_ShopB_Items, ref DataTable xdt_ShopA_Items)
        {
            if (xShopC_Data_Item_List == null)
            {
                xShopC_Data_Item_List = new List<object>();
            }
            else
            {
                xShopC_Data_Item_List.Clear();
            }
            if (this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocTyp, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID, ref xShopC_Data_Item_List))
            {
                if (xdt_ShopB_Items == null)
                {
                    xdt_ShopB_Items = new DataTable();
                }
                else
                {
                    xdt_ShopB_Items.Clear();
                    xdt_ShopB_Items.Columns.Clear();
                }
                if (this.m_usrc_DocumentEditor.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopB_Items))
                {
                    if (xdt_ShopA_Items == null)
                    {
                        xdt_ShopA_Items = new DataTable();
                    }
                    else
                    {
                        xdt_ShopA_Items.Clear();
                        xdt_ShopA_Items.Columns.Clear();
                    }
                    if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocTyp, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopA_Items))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool WriteShopABC_items(string doc_type,
                                        List<object> xShopC_Data_Item_List, 
                                        DataTable xdt_ShopB_Items, 
                                        DataTable xdt_ShopA_Items)
        {
            if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(DocTyp, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopA_Items))
            {
                if (this.m_usrc_DocumentEditor.m_ShopABC.Copy_ShopB_Price_Item_Table(this.DocTyp, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopB_Items))
                {
                    switch (this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.m_Basket.Copy_ShopC_Price_Item_Stock_Table(DocTyp,
                                                                                                                    this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc,
                                                                                                                    xShopC_Data_Item_List,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.AutomaticSelectionOfItemsFromStock,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Select_ShopC_Item_from_Stock,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Item_Not_In_Offer))
                    {
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.OK:
                            mSettingsUserValues.FinancialYear = this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.FinancialYear;
                            m_usrc_TableOfDocuments.Init(doc_type, true, false, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.FinancialYear, null);
                            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
                            GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.FinancialYear);
                            cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                            if (this.m_usrc_DocumentEditor.m_usrc_ShopC != null)
                            {
                                this.m_usrc_DocumentEditor.m_usrc_ShopC.usrc_ItemList.Paint_Current_Group();
                            }
                            return true;
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_NO_ITEM_IN_DB:
                            LogFile.Error.Show("ERROR:usrc_DocumentMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                            break;
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_DB:
                            LogFile.Error.Show("ERROR:usrc_DocumentMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                            break;
                    }
                }
            }
            return false;
        }

        internal void HelpReload()
        {
            if (m_usrc_Help!=null)
            {
                m_usrc_Help.Reload();
            }
        }

        private void New_Copy_Of_SameDocType(int xFinancialYear, xCurrency currency, ID xAtom_Currency_ID)
        {
            if (this.Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(xFinancialYear))
            {
                Program.Cursor_Wait();
                if (cmb_DocType.SelectedItem is DocType)
                {
                    DocType xDocType = (DocType)cmb_DocType.SelectedItem;
                    string xdocType = xDocType.Typ;
                    if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                    {
                        List<object> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                        {
                            m_usrc_DocumentEditor.SetNewDraft(m_LMOUser,xdocType, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(xdocType,
                                               xShopC_Data_Item_List,
                                               xdt_ShopB_Items,
                                               xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(xdocType, true, false, mSettingsUserValues.FinancialYear, null);
                            m_LMOUser.ReloadAdministratorsAndUserManagers();
                        }
                    }
                    else
                    {
                        Program.Cursor_Arrow();
                        LogFile.Error.Show("ERROR:usrc_DocumentMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                    }
                }
                Program.Cursor_Arrow();
            }
        }


        private void New_Copy_To_Another_DocType(int xFinancialYear, xCurrency currency, ID xAtom_Currency_ID)
        {
            if (this.Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(xFinancialYear))
            {
                Program.Cursor_Wait();
                if (cmb_DocType.SelectedItem is DocType)
                {
                    DocType xDocType = (DocType)cmb_DocType.SelectedItem;
                    string  xdoctyp = xDocType.Typ;
                    string New_xdoctyp = GlobalData.const_DocInvoice;
                    if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                    {
                        List<object> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                        {
                            if (xdoctyp != null)
                            {
                                if (xdoctyp.Equals(GlobalData.const_DocInvoice))
                                {
                                    DocTyp = GlobalData.const_DocProformaInvoice;
                                    New_xdoctyp = GlobalData.const_DocProformaInvoice;
                                }
                                else if (xdoctyp.Equals(GlobalData.const_DocProformaInvoice))
                                {
                                    DocTyp = GlobalData.const_DocInvoice;
                                    New_xdoctyp = GlobalData.const_DocProformaInvoice;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:DocType not implemented:" + xdoctyp);
                                    return;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:DocType is null !");
                                return;
                            }
                            SetDocInvoiceOrDocPoformaInvoice();
                            this.cmb_DocType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
                            Set_cmb_InvoiceType_selected_index();
                            this.cmb_DocType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

                            m_usrc_DocumentEditor.SetNewDraft(m_LMOUser, New_xdoctyp, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(New_xdoctyp,
                                            xShopC_Data_Item_List,
                                            xdt_ShopB_Items,
                                            xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(New_xdoctyp, true, false, mSettingsUserValues.FinancialYear, null);
                            m_LMOUser.ReloadAdministratorsAndUserManagers();
                        }
                        else
                        {
                            Program.Cursor_Arrow();
                            LogFile.Error.Show("ERROR:usrc_DocumentMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                        }
                    }
                }
            }
            Program.Cursor_Arrow();
        }

 
        private void m_usrc_Invoice_Customer_Person_Changed(ID Customer_Person_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                Customer_Changed = false;
                if (this.m_usrc_DocumentEditor!=null)
                {
                    if (this.m_usrc_DocumentEditor.m_ShopABC!=null)
                    {
                        if (this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc!=null)
                        {
                            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false, false, mSettingsUserValues.FinancialYear, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentDoc.Doc_ID);
                            return;
                        }
                    }
                }
                this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false,false,mSettingsUserValues.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(ID Customer_Org_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false,false, mSettingsUserValues.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.DocTyp, false,false, mSettingsUserValues.FinancialYear,null);
        }


        private void btn_SelectPanels_Click(object sender, EventArgs e)
        {
            if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(this,mSettingsUserValues);
            if (frm_select_panels.ShowDialog(this)==DialogResult.OK)
            {
                if (LayoutChanged!=null)
                {
                    LayoutChanged();
                }
            }
            if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;
        }

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            this.m_usrc_TableOfDocuments.Activate_dgvx_XInvoice_SelectionChanged();
        }

        private void SetDocInvoiceOrDocPoformaInvoice()
        {
            Program.RunAs = DocTyp;
            bool bRes = SetDocument();
            Program.Cursor_Arrow();
            if (this.IsDocInvoice)
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI == null)
                    {
                        this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI = new DocInvoice_AddOn();
                    }
                    this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                    Program.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor.m_ShopABC, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDPI);
                }
            }
        }
        private void cmb_InvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Cursor_Wait();
            switch (cmb_DocType.SelectedIndex)
            {
                case 0: // usrc_Invoice.enum_Invoice.TaxInvoice:
                    DocTyp = GlobalData.const_DocInvoice;
                    break;
                case 1: // usrc_Invoice.enum_Invoice.ProformaInvoice:
                    DocTyp = GlobalData.const_DocProformaInvoice;

                    break;
            }
            SetColor();
            SetDocInvoiceOrDocPoformaInvoice();
            SetFinancialYears();
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
        }

        internal void SetColor()
        {
            if (IsDocInvoice)
            {
                this.BackColor = Colors.DocInvoice.BackColor;
                this.pnl_MainMenu.BackColor = Colors.DocInvoice.BackColor;
                this.pnl_MainMenu.ForeColor = Colors.DocInvoice.ForeColor;
                this.splitContainer1.BackColor = Colors.DocInvoice.BackColor;
                this.m_usrc_DocumentEditor.SetColor();
                this.m_usrc_TableOfDocuments.BackColor = Colors.m_usrc_TableOfDocuments.BackColor;
                this.m_usrc_TableOfDocuments.ForeColor = Colors.m_usrc_TableOfDocuments.ForeColor;
            }
            else
            {
                this.BackColor = Colors.DocProformaInvoice.BackColor;
                this.pnl_MainMenu.BackColor = Colors.DocProformaInvoice.BackColor;
                this.pnl_MainMenu.ForeColor = Colors.DocProformaInvoice.ForeColor;
                this.splitContainer1.BackColor = Colors.DocProformaInvoice.BackColor;
                this.m_usrc_DocumentEditor.SetColor();
                this.m_usrc_TableOfDocuments.BackColor = Colors.m_usrc_TableOfDocuments.BackColor;
                this.m_usrc_TableOfDocuments.ForeColor = Colors.m_usrc_TableOfDocuments.ForeColor;
            }
            if (Program.MainForm != null)
            {
                Program.MainForm.BackColor = this.BackColor;
            }
        }

        internal bool Initialise(Form_Document main_Form, LoginControl.LMOUser xLMOUser)
        {
            mSettingsUserValues = ((SettingsUser)xLMOUser.oSettings).mSettingsUserValues;
            m_Form_Document = main_Form;
            m_LMOUser = xLMOUser;
            door = new Door(m_LMOUser);
            this.usrc_loginControl1.Bind(main_Form.loginControl1, xLMOUser);
            this.usrc_FVI_SLO1.Bind(m_Form_Document.fvI_SLO1);
            this.m_usrc_TableOfDocuments.Bind(m_LMOUser);
            return m_usrc_DocumentEditor.Initialise(this, m_LMOUser);
        }


        internal bool Init()
        {
            string Err = null;

            if (Program.b_FVI_SLO)
            {

                Program.FVI_SLO1.FursD_ElectronicDeviceID = GlobalData.ElectronicDevice_Name;
            }

            if (Program.b_FVI_SLO)
            {
                if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(m_Form_Document, ref myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.Atom_FVI_SLO_RealEstate_ID, 1))
                {
                }
            }

            LogFile.LogFile.WriteDEBUG("usrc_Document.cs:Init():before this.m_usrc_DocumentMan.Init(xnav)!");

            if (this.InitMan())
            {
                if (Program.b_FVI_SLO)
                {
                    switch (this.usrc_FVI_SLO1.m_FVI_SLO.Start(ref Err))
                    {
                        case FiscalVerificationOfInvoices_SLO.FVI_SLO.eStartResult.OK:
                        case FiscalVerificationOfInvoices_SLO.FVI_SLO.eStartResult.ALLREADY_RUNNING:
                            this.usrc_FVI_SLO1.Enabled = true;
                            if (this.IsDocInvoice)
                            {
                                if (Program.b_FVI_SLO)
                                {
                                    this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                    if (Program.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor.m_ShopABC, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDPI))
                                    {
                                        return this.SetDocument();
                                    }
                                    //Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_DocumentMan.m_usrc_Invoice.m_ShopABC, this.m_usrc_DocumentMan.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_DocumentMan.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
                                }
                            }
                            return true;

                        case FiscalVerificationOfInvoices_SLO.FVI_SLO.eStartResult.ERROR:
                            LogFile.Error.Show("usrc_Main:Init:this.usrc_FVI_SLO1.Start(ref Err):Err=" + Err);
                            return false;
                    }
                    LogFile.Error.Show("usrc_Main:Init:Ended on wrong place!");
                    return false;
                }
                else
                {
                    return this.SetDocument();
                }
            }
            else
            {
                return false;
            }
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            mSettingsUserValues.LastDocInvoiceType = this.DocTyp;
            if (Exit_Click != null)
            {
                Exit_Click(DocTyp,this.m_usrc_TableOfDocuments.Current_Doc_ID, m_LMOUser,LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        internal void EndProgram(LoginControl.LoginCtrl.eExitReason eres)
        {
            if (Exit_Click != null)
            {
                Exit_Click(DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, m_LMOUser, eres);
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
                Form_SettingsSelect frm_settingsselect = new Form_SettingsSelect(m_Form_Document, this,this.mSettingsUserValues);
                frm_settingsselect.ShowDialog(this);
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

            }
        }

        private void usrc_FVI_SLO1_PasswordCheck(ref bool PasswordOK)
        {
            PasswordOK = false;
            if (door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                PasswordOK = true;
            }
        }

        private bool HasWindowsOpened()
        {
            int disabledforms = 0;
            int visibleforms = 0;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Visible) visibleforms++;
                if (frm.Visible && !frm.CanFocus) disabledforms++;
            }
            if (disabledforms == visibleforms - 1 && disabledforms > 0) return true; //label1.Text = "Dialog shown";
            else if (disabledforms == visibleforms) return true;// label1.Text = "Message box shown";
            else return false;// label1.Text = "All systems go";
        }


        private void timer_Login_MultiUser_Tick(object sender, EventArgs e)
        {
            if (timer_Login_MultiUsers_Countdown>0)
            {
                if (HasWindowsOpened())
                {
                    timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown;
                }
                else
                {
                    btn_Exit.Text = timer_Login_MultiUsers_Countdown.ToString();
                    timer_Login_MultiUsers_Countdown--;
                }
            }
            else
            {
                Exit_Click(DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, m_LMOUser, LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => { timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown; };
                initControlsRecursive(c.Controls);
            }
        }
    }
}
