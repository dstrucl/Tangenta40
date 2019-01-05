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
using DocumentManager;

namespace Tangenta
{
    public partial class usrc_DocumentMan : UserControl
    {
        internal Form_Document m_Form_Document = null;

        

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

        public DocumentMan DocM = null;

        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;
        public delegate void delegate_Exit_Click(string sDocInvoice, ID doc_ID, LoginControl.LMOUser m_LMOUser, LoginControl.LoginCtrl.eExitReason eReason);
        public event delegate_Exit_Click Exit_Click;


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
            get { return m_usrc_DocumentEditor.DocE.m_mode == DocumentEditor.emode.view_eDocumentType; }
        }


        public string DocTyp
        {
            get {
                    return DocM.DocTyp;
                }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    DocM.DocTyp = s;
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
                    return PropertiesUser.ShowShops_Get(((SettingsUser)DocM.m_LMOUser.oSettings).mSettingsUserValues).Contains("A");
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
                    return PropertiesUser.ShowShops_Get(((SettingsUser)DocM.m_LMOUser.oSettings).mSettingsUserValues).Contains("B");
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
                    return PropertiesUser.ShowShops_Get(((SettingsUser)DocM.m_LMOUser.oSettings).mSettingsUserValues).Contains("C");
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
                    if (DocumentManager.DocumentMan.RecordCashierActivity)
                    {
                        lbl_Cashier.Visible = true;
                        lbl_OpenedClosed.Visible = true;
                        switch (DocumentMan.CashierState)
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

                    if (DocumentManager.OperationMode.MultiUser)
                    {
                        if (Program.Login_MultipleUsers)
                        {
                            DocM.timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown;
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
            if (Program.bTransactionMonitor)
            {
                this.usrc_TransactionControl1.DataBase_TransactionsLog = DBSync.DBSync.DB_for_Tangenta.DB_TransactionsLog;
                this.usrc_TransactionControl1.Visible = true;
            }
            else
            {
                this.usrc_TransactionControl1.DataBase_TransactionsLog = null;
                this.usrc_TransactionControl1.Visible = false;
            }
        
            lng.s_btn_New.Text(btn_New);
            lng.s_Year.Text(lbl_FinancialYear);
            lng.s_Cashier.Text(lbl_Cashier);

            DocM = new DocumentMan(SetMode,
                                   TableOfDocuments_Init,
                                   Control_DocumentEditor_Init,
                                   SetInitialMode);

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
                DocM.Mode = DocumentMan.eMode.Shops_and_InvoiceTable;
            }
            else if (sManagerMode.Equals("Shops"))
            {
                DocM.Mode = DocumentMan.eMode.Shops;
            }
            else if (sManagerMode.Equals("InvoiceTable"))
            {
                DocM.Mode = DocumentMan.eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_DocumentMan:SetInitialMode:Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
                DocM.Mode = DocumentMan.eMode.Shops_and_InvoiceTable;
            }


            m_Form_Document.loginControl1.SetAccessAuthentification(Properties.Settings.Default.AccessAuthentication);
            if (Program.Login_MultipleUsers)
            {
                initControlsRecursive(this.Controls);
            }
        }

        private int TableOfDocuments_Init(DocumentMan xdocM,
                     bool bNew,
                     bool bInitialise_usrc_Invoice,
                     int iFinancialYear,
                     ID Doc_ID_To_show)
        {
            return this.m_usrc_TableOfDocuments.Init(xdocM, bNew, bInitialise_usrc_Invoice, iFinancialYear, Doc_ID_To_show);
        }

        public void SetMode(DocumentMan.eMode mode)
        {
            if (mode == DocumentMan.eMode.Shops)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
            }
            else if (mode == DocumentMan.eMode.InvoiceTable)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = false;
            }
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
                sLastDocInvoiceType = PropertiesUser.LastDocType_Get(DocM.mSettingsUserValues);
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


            PropertiesUser.LastDocType_Set(DocM.mSettingsUserValues, this.DocTyp);


            if (DocM.m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteInvoice }))
            {
                DocM.DocType_DocInvoice = new DocType(lng.s_Invoice.s, GlobalData.const_DocInvoice);
                DocM.List_DocType.Add(DocM.DocType_DocInvoice);
            }

            if (DocM.m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteProformaInvoice }))
            {
                DocM.DocType_DocProformaInvoice = new DocType(lng.s_DocProformaInvoice.s, GlobalData.const_DocProformaInvoice);
                DocM.List_DocType.Add(DocM.DocType_DocProformaInvoice);
            }

            if (DocM.List_DocType.Count>0)
            {
                this.cmb_DocType.DataSource = null;
                this.cmb_DocType.DataSource = DocM.List_DocType;
                this.cmb_DocType.DisplayMember = "DocType_Text_in_language";
                this.cmb_DocType.ValueMember = "Typ";
                if (DocM.List_DocType.Count > 1)
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

        internal bool InitMan(Transaction transaction)
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

            
            bool bRes = SetDocument(transaction);

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
                SetMode(DocumentMan.eMode.Shops_and_InvoiceTable);
            }
            else
            {
                SetMode(DocumentMan.eMode.Shops);
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
            int Default_FinancialYear = DocM.mSettingsUserValues.FinancialYear;

            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;

            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref DocM.dt_FinancialYears, IsDocInvoice, IsDocProformaInvoice, ref Default_FinancialYear))
            {
                DocM.mSettingsUserValues.FinancialYear = Default_FinancialYear;
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

        internal bool Control_DocumentEditor_Init(ID xdoc_ID)
        {
            return m_usrc_DocumentEditor.Init(xdoc_ID);
        }

        internal bool SetDocument(Transaction transaction)
        {
            return DocM.SetDocument(this.m_usrc_TableOfDocuments.Current_Doc_ID,transaction);
        }

        internal void SaveSplitControlsSpliterDistance(SettingsUserValues xSettingsUserValues)
        {
            if (SplitContainer1_spd>0)
            {
                DocM.mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance = SplitContainer1_spd;
            }
            if (this.m_usrc_DocumentEditor != null)
            {
                this.m_usrc_DocumentEditor.SaveSplitControlsSpliterDistance(xSettingsUserValues);
            }
        }

        private void Cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            DocM.Cmb_FinancialYear_SelectedIndexChanged(cmb_FinancialYear);
            cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
        }


        private void m_usrc_Invoice_DocInvoiceSaved(ID DocInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            DocM.DocInvoiceSaved(DocInvoice_id);
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(ID DocProformaInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            DocM.DocProformaInvoiceSaved(DocProformaInvoice_id);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(ID DocInvoice_ID,bool bInitialise)
        {
            if (ID.Validate(DocInvoice_ID))
            {
                Transaction transaction_usrc_DocumentMan_m_usrc_DocumentEditor_DoCurrent = DBSync.DBSync.NewTransaction("usrc_DocumentMan.m_usrc_DocumentEditor.DoCurrent");
                if (m_usrc_DocumentEditor.DoCurrent(DocInvoice_ID, transaction_usrc_DocumentMan_m_usrc_DocumentEditor_DoCurrent))
                {
                    transaction_usrc_DocumentMan_m_usrc_DocumentEditor_DoCurrent.Commit();
                }
                else
                {
                    transaction_usrc_DocumentMan_m_usrc_DocumentEditor_DoCurrent.Rollback();
                }
            }
            SetColor();
        }

        public void Reload()
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(DocumentMan.eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show_v = null;
            if (m_usrc_DocumentEditor.DocE.m_ShopABC != null)
            {
                if (m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc != null)
                {
                    if (ID.Validate(m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID))
                    {
                        Doc_ID_to_show_v = new ID(m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                    }
                    this.m_usrc_TableOfDocuments.Init(DocM, false, false, DocM.mSettingsUserValues.FinancialYear, Doc_ID_to_show_v);
                }
            }
        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            if ((!DocumentMan.RecordCashierActivity)||(DocumentMan.CashierState == TangentaDB.CashierActivity.eCashierState.OPENED))
            {
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
                DataTable dtWorkAreaAll = null;
                int iWorkAreasCount = 0;
                if (f_WorkArea.GetWorkAreas(ref dtWorkAreaAll, ref iWorkAreasCount))
                {
                    if ((iWorkAreasCount>0)&&(Program.UseWorkAreas))
                    {
                        Form_NewDocument_WorkArea frm_new_workarea = new Form_NewDocument_WorkArea(dtWorkAreaAll);
                        frm_new_workarea.ShowDialog(this);
                        switch (frm_new_workarea.eNewDocumentResult)
                        {
                            case Form_NewDocument.e_NewDocument.New_Empty:
                                New_Empty_Doc(frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID, frm_new_workarea.Warea);
                                break;

                            case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                                Transaction transaction_usrc_DocumentMan_New_Copy_Of_SameDocType = DBSync.DBSync.NewTransaction("usrc_DocumentMan.New_Copy_Of_SameDocType");
                                if (New_Copy_Of_SameDocType(frm_new_workarea.FinancialYear, frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID, transaction_usrc_DocumentMan_New_Copy_Of_SameDocType))
                                {
                                    transaction_usrc_DocumentMan_New_Copy_Of_SameDocType.Commit();
                                }
                                else
                                {
                                    transaction_usrc_DocumentMan_New_Copy_Of_SameDocType.Rollback();
                                }
                                break;
                            case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                                Transaction transaction_usrc_DocumentMan_New_Copy_To_Another_DocType = DBSync.DBSync.NewTransaction("usrc_DocumentMan.New_Copy_To_Another_DocType");
                                if (New_Copy_To_Another_DocType(frm_new_workarea.FinancialYear, frm_new_workarea.Currency, frm_new_workarea.Atom_Currency_ID, transaction_usrc_DocumentMan_New_Copy_To_Another_DocType))
                                {
                                    transaction_usrc_DocumentMan_New_Copy_To_Another_DocType.Commit();
                                }
                                else
                                {
                                    transaction_usrc_DocumentMan_New_Copy_To_Another_DocType.Rollback();
                                }
                                break;
                        }
                    }
                    else
                    {
                        Form_NewDocument frm_new = new Form_NewDocument(this, this.DocM, DocM.mSettingsUserValues);
                        frm_new.ShowDialog(this);
                        if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

                        switch (frm_new.eNewDocumentResult)
                        {
                            case Form_NewDocument.e_NewDocument.New_Empty:
                                New_Empty_Doc(frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, null);
                                break;

                            case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                                Transaction transaction_usrc_DocumentMan_New_Copy_Of_SameDocType = DBSync.DBSync.NewTransaction("usrc_DocumentMan.New_Copy_Of_SameDocType");
                                if (New_Copy_Of_SameDocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, transaction_usrc_DocumentMan_New_Copy_Of_SameDocType))
                                {
                                    transaction_usrc_DocumentMan_New_Copy_Of_SameDocType.Commit();
                                }
                                else
                                {
                                    transaction_usrc_DocumentMan_New_Copy_Of_SameDocType.Rollback();
                                }
                                break;
                            case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                                Transaction transaction_usrc_DocumentMan_New_Copy_To_Another_DocType = DBSync.DBSync.NewTransaction("usrc_DocumentMan.New_Copy_To_Another_DocType");
                                if (New_Copy_To_Another_DocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, transaction_usrc_DocumentMan_New_Copy_To_Another_DocType))
                                {
                                    transaction_usrc_DocumentMan_New_Copy_To_Another_DocType.Commit();
                                }
                                else
                                {
                                    transaction_usrc_DocumentMan_New_Copy_To_Another_DocType.Rollback();
                                }
                                break;
                        }
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
                        m_usrc_DocumentEditor.SetNewDraft(DocM.m_LMOUser, DocTyp, FinancialYear, currency, xAtom_Currency_ID, workArea);
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;
                        m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                        m_usrc_TableOfDocuments.Init(DocM, true, false, FinancialYear /*Properties.Settings.Default.FinancialYear*/, null);
                        DocM.m_LMOUser.ReloadAdministratorsAndUserManagers();
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
            if (DocM.mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance>0)
            {
                this.splitContainer1.SplitterDistance = DocM.mSettingsUserValues.DocumentMan_SplitControl1_splitterdistance;
            }
            if (m_usrc_DocumentEditor!=null)
            {
                m_usrc_DocumentEditor.SetSplitControlsSpliterDistance(DocM.mSettingsUserValues);
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
                    if ((current_month <= DocumentManager.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice) && (financialYear + 1 == current_year))
                    {
                        return true;
                    }
                    else
                    {
                        string smsg = lng.s_YouCanNotCreateNewInvoiceForPastFinancialYear.s + " " + financialYear + ".\r\n";
                        smsg += lng.s_NumberOfMonthAfterNewYearToAllowCreateNewInvoiceIs.s + " " + DocumentManager.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.ToString() + "\r\n";
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

        private bool ReadShopABC_items(ref List<Doc_ShopC_Item> xShopC_Data_Item_List, ref DataTable xdt_ShopB_Items, ref DataTable xdt_ShopA_Items, Transaction transaction)
        {
            if (xShopC_Data_Item_List == null)
            {
                xShopC_Data_Item_List = new List<Doc_ShopC_Item>();
            }
            else
            {
                xShopC_Data_Item_List.Clear();
            }
            if (this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.m_Basket.Read_Doc_ShopC_Item_Table(DocTyp, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xShopC_Data_Item_List, transaction))
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
                if (this.m_usrc_DocumentEditor.DocE.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopB_Items))
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
                    if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocTyp, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopA_Items))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool WriteShopABC_items(string doc_type,
                                        List<Doc_ShopC_Item> xShopC_Data_Item_List, 
                                        DataTable xdt_ShopB_Items, 
                                        DataTable xdt_ShopA_Items,
                                        Transaction transaction)
        {
            if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(DocTyp, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopA_Items, transaction))
            {
                if (this.m_usrc_DocumentEditor.DocE.m_ShopABC.Copy_ShopB_Price_Item_Table(this.DocTyp, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopB_Items, transaction))
                {
                    //switch (this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.m_Basket.Copy_Doc_ShopC_Item(DocTyp,
                    //                                                                                                this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc,
                    //                                                                                                xShopC_Data_Item_List,
                    //                                                                                                this.m_usrc_DocumentEditor.m_usrc_ShopC.AutomaticSelectionOfItemsFromStock,
                    //                                                                                                this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Select_ShopC_Item_from_Stock,
                    //                                                                                                this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Item_Not_In_Offer))
                    //{
                    //    case TangentaDB.Basket.eCopy_Doc_ShopC_Item_Result.OK:
                    //        DocM.mSettingsUserValues.FinancialYear = this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.FinancialYear;
                    //        m_usrc_TableOfDocuments.Init(DocM, true, false, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.FinancialYear, null);
                    //        cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
                    //        GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.FinancialYear);
                    //        cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                    //        if (this.m_usrc_DocumentEditor.m_usrc_ShopC != null)
                    //        {
                    //            this.m_usrc_DocumentEditor.m_usrc_ShopC.usrc_ItemList.Paint_Current_Group();
                    //        }
                    //        return true;
                    //    case TangentaDB.Basket.eCopy_Doc_ShopC_Item_Result.ERROR_NO_ITEM_IN_DB:
                    //        LogFile.Error.Show("ERROR:usrc_DocumentMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                    //        break;
                    //    case TangentaDB.Basket.eCopy_Doc_ShopC_Item_Result.ERROR_DB:
                    //        LogFile.Error.Show("ERROR:usrc_DocumentMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                    //        break;
                    //}
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

        private bool New_Copy_Of_SameDocType(int xFinancialYear, xCurrency currency, ID xAtom_Currency_ID, Transaction transaction)
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
                        List<Doc_ShopC_Item> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items, transaction))
                        {
                            m_usrc_DocumentEditor.SetNewDraft(DocM.m_LMOUser,xdocType, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            if (WriteShopABC_items(xdocType,
                                               xShopC_Data_Item_List,
                                               xdt_ShopB_Items,
                                               xdt_ShopA_Items,
                                               transaction))
                            {
                                    m_usrc_TableOfDocuments.Init(DocM, true, false, DocM.mSettingsUserValues.FinancialYear, null);
                                    DocM.m_LMOUser.ReloadAdministratorsAndUserManagers();
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Program.Cursor_Arrow();
                        LogFile.Error.Show("ERROR:usrc_DocumentMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                        return false;
                    }
                }
            }
            Program.Cursor_Arrow();
            return true;
        }


        private bool New_Copy_To_Another_DocType(int xFinancialYear, xCurrency currency, ID xAtom_Currency_ID, Transaction transaction)
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
                        List<Doc_ShopC_Item> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items, transaction))
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
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:DocType is null !");
                                return false;
                            }
                            SetDocInvoiceOrDocPoformaInvoice();
                            this.cmb_DocType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
                            Set_cmb_InvoiceType_selected_index();
                            this.cmb_DocType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

                            m_usrc_DocumentEditor.SetNewDraft(DocM.m_LMOUser, New_xdoctyp, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            Transaction transaction_WriteShopABC_items = DBSync.DBSync.NewTransaction("WriteShopABC_items");
                            if (WriteShopABC_items(New_xdoctyp,
                                            xShopC_Data_Item_List,
                                            xdt_ShopB_Items,
                                            xdt_ShopA_Items,
                                            transaction_WriteShopABC_items))
                            {
                                if (transaction_WriteShopABC_items.Commit())
                                {
                                    m_usrc_TableOfDocuments.Init(DocM, true, false, DocM.mSettingsUserValues.FinancialYear, null);
                                    DocM.m_LMOUser.ReloadAdministratorsAndUserManagers();
                                }
                            }
                            else
                            {
                                transaction_WriteShopABC_items.Rollback();
                            }
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
            return true;
        }

 
        private void m_usrc_Invoice_Customer_Person_Changed(ID Customer_Person_ID)
        {
            DocM.Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                DocM.Customer_Changed = false;
                if (this.m_usrc_DocumentEditor!=null)
                {
                    if (this.m_usrc_DocumentEditor.DocE.m_ShopABC!=null)
                    {
                        if (this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc!=null)
                        {
                            this.m_usrc_TableOfDocuments.Init(DocM, false, false, DocM.mSettingsUserValues.FinancialYear, this.m_usrc_DocumentEditor.DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                            return;
                        }
                    }
                }
                this.m_usrc_TableOfDocuments.Init(DocM, false,false, DocM.mSettingsUserValues.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(ID Customer_Org_ID)
        {
            DocM.Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                DocM.Customer_Changed = false;
                this.m_usrc_TableOfDocuments.Init(DocM, false,false, DocM.mSettingsUserValues.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_TableOfDocuments.Init(DocM, false,false, DocM.mSettingsUserValues.FinancialYear,null);
        }


        private void btn_SelectPanels_Click(object sender, EventArgs e)
        {
            if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(DocM, DocM.mSettingsUserValues);
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

            this.m_usrc_TableOfDocuments.Clear();
            Transaction transaction_usrc_DocumentMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument = DBSync.DBSync.NewTransaction("usrc_DocumentMan.SetDocInvoiceOrDocPoformaInvoice.SetDocument");
            bool bRes = SetDocument(transaction_usrc_DocumentMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument);
            if (bRes)
            {
                transaction_usrc_DocumentMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument.Commit();
            }
            else
            {
                transaction_usrc_DocumentMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument.Rollback();
                return;
            }

            Program.Cursor_Arrow();
            if (this.IsDocInvoice)
            {
                if (DocumentMan.b_FVI_SLO)
                {
                    if (this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI == null)
                    {
                        this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI = new DocInvoice_AddOn();
                    }
                    this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI.b_FVI_SLO = DocumentMan.b_FVI_SLO;
                    DocumentMan.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(DBSync.DBSync.MyTransactionLog_delegates,this.m_usrc_DocumentEditor.DocE.m_ShopABC, this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDPI);
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
            DocM.mSettingsUserValues = ((SettingsUser)xLMOUser.oSettings).mSettingsUserValues;
            m_Form_Document = main_Form;
            DocM.m_LMOUser = xLMOUser;
            DocM.door = new Door(DocM.m_LMOUser);
            this.usrc_loginControl1.Bind(main_Form.loginControl1, xLMOUser);
            this.usrc_FVI_SLO1.Bind(m_Form_Document.fvI_SLO1);
            this.m_usrc_TableOfDocuments.Bind(DocM.m_LMOUser);
            return m_usrc_DocumentEditor.Initialise(DocM, DocM.m_LMOUser);
        }


        internal bool Init()
        {
            string Err = null;

            m_usrc_TableOfDocuments.DocM = this.DocM;

            if (DocumentMan.b_FVI_SLO)
            {

                DocumentMan.FVI_SLO1.FursD_ElectronicDeviceID = GlobalData.ElectronicDevice_Name;
            }

            if (DocumentMan.b_FVI_SLO)
            {
                Transaction transaction_Get_Atom_FVI_SLO_RealEstateBP_ID_1 = DBSync.DBSync.NewTransaction("Get_Atom_FVI_SLO_RealEstateBP_ID_1");

                if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(m_Form_Document, ref myOrg.m_myOrg_Office.myOrg_Office_FVI_SLO_RealEstate.Atom_FVI_SLO_RealEstate_ID, 1, transaction_Get_Atom_FVI_SLO_RealEstateBP_ID_1))
                {
                    if (!transaction_Get_Atom_FVI_SLO_RealEstateBP_ID_1.Commit())
                    {
                        return false;
                    }

                }
                else
                {
                    transaction_Get_Atom_FVI_SLO_RealEstateBP_ID_1.Rollback();
                    return false;
                }
            }

            LogFile.LogFile.WriteDEBUG("usrc_Document.cs:Init():before this.m_usrc_DocumentMan.Init(xnav)!");

            Transaction transaction_usrc_DocumentMan_InitMan = DBSync.DBSync.NewTransaction("usrc_DocumentMan.InitMan");
            if (this.InitMan(transaction_usrc_DocumentMan_InitMan))
            {
                if (transaction_usrc_DocumentMan_InitMan.Commit())
                {
                    if (DocumentMan.b_FVI_SLO)
                    {
                        switch (this.usrc_FVI_SLO1.m_FVI_SLO.Start(false, ref Err))
                        {
                            case FiscalVerificationOfInvoices_SLO.FVI_SLO.eStartResult.OK:
                            case FiscalVerificationOfInvoices_SLO.FVI_SLO.eStartResult.ALLREADY_RUNNING:
                                this.usrc_FVI_SLO1.Enabled = true;
                                if (this.IsDocInvoice)
                                {
                                    if (DocumentMan.b_FVI_SLO)
                                    {
                                        this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI.b_FVI_SLO = DocumentMan.b_FVI_SLO;
                                        if (DocumentMan.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(DBSync.DBSync.MyTransactionLog_delegates, this.m_usrc_DocumentEditor.DocE.m_ShopABC, this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.DocE.InvoiceData.AddOnDPI))
                                        {
                                            Transaction transaction_usrc_DocumentMan_b_FVI_SLO_SetDocument = DBSync.DBSync.NewTransaction("usrc_DocumentMan.b_FVI_SLO.SetDocument");
                                            if (this.SetDocument(transaction_usrc_DocumentMan_b_FVI_SLO_SetDocument))
                                            {
                                                if (!transaction_usrc_DocumentMan_b_FVI_SLO_SetDocument.Commit())
                                                {
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                transaction_usrc_DocumentMan_b_FVI_SLO_SetDocument.Rollback();
                                                return false;
                                            }
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
                        Transaction transaction_usrc_DocumentMan_SetDocument = DBSync.DBSync.NewTransaction("usrc_DocumentMan.SetDocument");
                        if (this.SetDocument(transaction_usrc_DocumentMan_SetDocument))
                        {
                            if (!transaction_usrc_DocumentMan_SetDocument.Commit())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            transaction_usrc_DocumentMan_SetDocument.Rollback();
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            PropertiesUser.LastDocType_Set(DocM.mSettingsUserValues, this.DocTyp);
            if (Exit_Click != null)
            {
                Exit_Click(DocTyp,this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser,LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        internal void EndProgram(LoginControl.LoginCtrl.eExitReason eres)
        {
            if (Exit_Click != null)
            {
                Exit_Click(DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser, eres);
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (DocM.door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
                Form_SettingsSelect frm_settingsselect = new Form_SettingsSelect(m_Form_Document, this, DocM.mSettingsUserValues);
                frm_settingsselect.ShowDialog(this);
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

            }
        }

        private void usrc_FVI_SLO1_PasswordCheck(ref bool PasswordOK)
        {
            PasswordOK = false;
            if (DocM.door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
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
            if (DocM.timer_Login_MultiUsers_Countdown >0)
            {
                if (HasWindowsOpened())
                {
                    DocM.timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown;
                }
                else
                {
                    btn_Exit.Text = DocM.timer_Login_MultiUsers_Countdown.ToString();
                    DocM.timer_Login_MultiUsers_Countdown--;
                }
            }
            else
            {
                Exit_Click(DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser, LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => { DocM.timer_Login_MultiUsers_Countdown = Properties.Settings.Default.timer_Login_MultiUser_Countdown; };
                initControlsRecursive(c.Controls);
            }
        }

        internal void BeforeRemove()
        {
            m_usrc_TableOfDocuments.BeforeRemove();
            this.Controls.Remove(this.m_usrc_TableOfDocuments);
            this.m_usrc_TableOfDocuments.Dispose();
        }
    }
}
