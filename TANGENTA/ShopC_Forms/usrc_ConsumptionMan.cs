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
using NavigationButtons;
using DBConnectionControl40;
using Global;
using TangentaProperties;

namespace ShopC_Forms
{
    public partial class usrc_ConsumptionMan : UserControl
    {
        //internal class Defpos
        //{
        //    internal int usrc_ConsumptionEditor_Left = 0;
        //    internal int usrc_ConsumptionEditor_Width = 0;
        //    internal int cmb_DocType_Left;
        //    internal int cmb_DocType_Top;
        //    internal int lbl_FinancialYear_Left;
        //    internal int lbl_FinancialYear_Top;
        //    internal int cmb_FinancialYear_Left;
        //    internal int cmb_FinancialYear_Top;
        //    internal int usrc_loginControl1_Left;
        //    internal int usrc_loginControl1_Top;
        //    internal int usrc_loginControl1_Width;
        //    internal int usrc_TransactionControl1_Left;
        //    internal int usrc_TransactionControl1_Top;
        //    internal int usrc_TableOfDocuments_Width;
        //}
        //private Defpos defpos = null;
        internal Form m_Form_Document = null;
        
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


        public ConsumptionMan ConsM = null;

        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;
        public delegate void delegate_Exit_Click(string sDocInvoice, ID doc_ID, LoginControl.LMOUser m_LMOUser, LoginControl.LoginCtrl.eExitReason eReason);
        public event delegate_Exit_Click Exit_Click;

        public string DocTyp
        {
            get
            {
                return ConsM.ConsumptionTyp;
            }
        }

        internal bool m_usrc_Invoice_ViewMode
        {
            get { return m_usrc_ConsumptionEditor.ConsE.m_mode == ConsumptionEditor.emode.view_eDocumentType; }
        }

  

        public bool m_usrc_InvoiceTable_Visible
        {
            get { return this.m_usrc_TableOfConsumption.Visible; }
        }

        public bool m_usrc_Invoice_Visible
        {
            get { return m_usrc_ConsumptionEditor.Visible; }
        }

        public bool ShopA_Visible
        {
            get {
                    if (m_usrc_ConsumptionEditor!=null)
                    {
                        return PropertiesUser.ShowShops_Get(((SettingsUser)ConsM.m_LMOUser.oSettings).mSettingsUserValues).Contains("A");
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
                if (m_usrc_ConsumptionEditor != null)
                {
                    return PropertiesUser.ShowShops_Get(((SettingsUser)ConsM.m_LMOUser.oSettings).mSettingsUserValues).Contains("B");
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
                if (m_usrc_ConsumptionEditor != null)
                {
                    return PropertiesUser.ShowShops_Get(((SettingsUser)ConsM.m_LMOUser.oSettings).mSettingsUserValues).Contains("C");
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
                    if (OperationMode.MultiUser)
                    {
                        if (TSettings.Login_MultipleUsers)
                        {
                            ConsM.timer_Login_MultiUsers_Countdown = TangentaProperties.Properties.Settings.Default.timer_Login_MultiUser_Countdown;
                            this.timer_Login_MultiUser.Enabled = true;
                        }
                    }
                }
                else
                {
                    this.timer_Login_MultiUser.Enabled = false;
                }
            }
        }

       
        public bool IsDocInvoice
        {
            get
            {
                return DocTyp.Equals(GlobalData.const_DocInvoice);
            }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
                return DocTyp.Equals(GlobalData.const_DocProformaInvoice);
            }
        }

        public usrc_ConsumptionMan()
        {
            InitializeComponent();
            //defpos = new Defpos();
            //defpos.usrc_ConsumptionEditor_Left = m_usrc_ConsumptionEditor.Left;
            //defpos.usrc_ConsumptionEditor_Width = m_usrc_ConsumptionEditor.Width;
            //defpos.cmb_DocType_Left = this.cmb_DocType.Left;
            //defpos.cmb_DocType_Top = this.cmb_DocType.Top;
            //defpos.lbl_FinancialYear_Left = this.lbl_FinancialYear.Left;
            //defpos.lbl_FinancialYear_Top = this.lbl_FinancialYear.Top;
            //defpos.cmb_FinancialYear_Left = this.cmb_FinancialYear.Left;
            //defpos.cmb_FinancialYear_Top = this.cmb_FinancialYear.Top;
            //defpos.usrc_TableOfDocuments_Width = this.m_usrc_TableOfConsumption.Width;

            ////if (Startup.CommandLineParam.bTransactionMonitor)
            ////{
            ////    this.usrc_TransactionControl1.DataBase_TransactionsLog = DBSync.DBSync.DB_for_Tangenta.DB_TransactionsLog;
            ////    this.usrc_TransactionControl1.Visible = true;
            ////}
            ////else
            ////{
            ////    this.usrc_TransactionControl1.DataBase_TransactionsLog = null;
            ////    this.usrc_TransactionControl1.Visible = false;
            ////}
   
            lng.s_Year.Text(lbl_FinancialYear);
            //m_usrc_ConsumptionEditor.LayoutChanged += M_usrc_Invoice_LayoutChanged;
           
        }

        internal bool Control_ConsumptionEditor_Init(ID xdoc_ID)
        {
            return m_usrc_ConsumptionEditor.Init(xdoc_ID);
        }

        private int TableOfDocuments_Init(ConsumptionMan xdocM,
                 bool bNew,
                 bool bInitialise_usrc_Invoice,
                 int iFinancialYear,
                 ID Consumption_ID_To_show)
        {
            return this.m_usrc_TableOfConsumption.Init(xdocM, bNew, bInitialise_usrc_Invoice, iFinancialYear, Consumption_ID_To_show);
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
            //m_Form_Document.loginControl1.SetAccessAuthentification(TangentaProperties.Properties.Settings.Default.AccessAuthentication);
            //if (TSettings.Login_MultipleUsers)
            //{
            //    initControlsRecursive(this.Controls);
            //}
        }



        public void SetMode(ConsumptionMan.eMode mode)
        {
            if (mode == ConsumptionMan.eMode.Shops)
            {
                
                m_usrc_TableOfConsumption.Visible = false;
                m_usrc_ConsumptionEditor.Visible = true;

                m_usrc_ConsumptionEditor.Left = 0;
                m_usrc_ConsumptionEditor.Width = this.Width;
                //m_usrc_ConsumptionEditor.Set_ConsumptionMan_eMode_Shops(defpos.usrc_ConsumptionEditor_Left,
                //                                                          defpos.usrc_loginControl1_Left + defpos.usrc_loginControl1_Width - defpos.usrc_TransactionControl1_Left);
                ////this.usrc_TransactionControl1.Top = this.cmb_DocType.Top;
                //this.usrc_TransactionControl1.Left = this.cmb_FinancialYear.Left + this.cmb_FinancialYear.Width + 5;
                //this.usrc_loginControl1.Left = this.usrc_TransactionControl1.Left + this.usrc_TransactionControl1.Width + 5;
                this.cmb_ConsumptionType.BringToFront();
                //this.usrc_TransactionControl1.BringToFront();
                this.lbl_FinancialYear.BringToFront();
                this.cmb_FinancialYear.BringToFront();
                btn_Exit.BringToFront();
                btn_SelectPanels.BringToFront();
                //usrc_FVI_SLO1.BringToFront();
                btn_Settings.BringToFront();
                m_usrc_Help.BringToFront();
                this.m_usrc_ConsumptionEditor.DoRefresh();
                this.usrc_DocIssue1.Visible = false;
            }
            else if (mode == ConsumptionMan.eMode.InvoiceTable)
            {
                m_usrc_ConsumptionEditor.Visible = false;
                this.m_usrc_TableOfConsumption.Visible = true;
                
                this.m_usrc_TableOfConsumption.Width = this.Width;
                this.m_usrc_ConsumptionEditor.Set_ConsumptionMan_eMode_Shops_and_InvoiceTable();
                this.m_usrc_ConsumptionEditor.DoRefresh();
                this.usrc_DocIssue1.Visible = true;
            }
            else
            {
                
                //m_usrc_ConsumptionEditor.Left = defpos.usrc_ConsumptionEditor_Left;
                //m_usrc_ConsumptionEditor.Width = defpos.usrc_ConsumptionEditor_Width;
                //m_usrc_ConsumptionEditor.Set_ConsumptionMan_eMode_Shops_and_InvoiceTable();
                //this.cmb_DocType.Left = defpos.cmb_DocType_Left;
                //this.cmb_DocType.Top = defpos.cmb_DocType_Top;
                //this.lbl_FinancialYear.Left = defpos.lbl_FinancialYear_Left;
                //this.lbl_FinancialYear.Top = defpos.lbl_FinancialYear_Top;
                //this.cmb_FinancialYear.Left = defpos.cmb_FinancialYear_Left;
                //this.cmb_FinancialYear.Top = defpos.cmb_FinancialYear_Top;
                //this.usrc_TransactionControl1.Left = defpos.usrc_TransactionControl1_Left;
                //this.usrc_TransactionControl1.Top = defpos.usrc_TransactionControl1_Top;
                //this.m_usrc_TableOfConsumption.Width = defpos.usrc_TableOfDocuments_Width;
                this.m_usrc_TableOfConsumption.Visible = true;
                m_usrc_ConsumptionEditor.Visible = true;
                this.m_usrc_ConsumptionEditor.DoRefresh();
                this.usrc_DocIssue1.Visible = false;
            }
        }

        private void Set_cmb_DocType()
        {
            if (this.cmb_ConsumptionType == null)
            {
                LogFile.LogFile.WriteDEBUG("usrc_ConsumptionMan.cs:Init():this.cmb_InvoiceType == null");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("usrc_ConsumptionMan.cs:Init():this.cmb_InvoiceType != null");
            }

            this.cmb_ConsumptionType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);


            ConsM.ConsumptionTyp = GlobalData.const_ConsumptionAll;

            //string sLastConsumptionType = null;

            //LogFile.LogFile.WriteDEBUG("usrc_ConsumptionMan.cs:Init():before if (Program.RunAs == null)");

            //if (TSettings.RunAs == null)
            //{
            //    //sLastDocInvoiceType =  PropertiesUser.LastDocType_Get(ConsM.mSettingsUserValues);
            //    if (sLastDocInvoiceType.Equals(GlobalData.const_DocInvoice) || sLastDocInvoiceType.Equals(GlobalData.const_DocProformaInvoice))
            //    {
            //        TSettings.RunAs = sLastDocInvoiceType;
            //    }
            //    else
            //    {
            //        TSettings.RunAs = GlobalData.const_DocInvoice;
            //    }

            //}
            //else
            //{
            //    sLastDocInvoiceType = TSettings.RunAs;
            //}


            //if (sLastDocInvoiceType.Equals(GlobalData.const_DocInvoice))
            //{
            //    ConsM.ConsumptionTyp = sLastDocInvoiceType;
            //}
            //else if (sLastDocInvoiceType.Equals(GlobalData.const_DocProformaInvoice))
            //{
            //    ConsM.ConsumptionTyp = sLastDocInvoiceType;
            //}
            //else
            //{
            //    ConsM.ConsumptionTyp = GlobalData.const_DocProformaInvoice;
            //    //PropertiesUser.LastDocType_Set(ConsM.mSettingsUserValues, ConsM.DocTyp);

            //}

            //if (ConsM.m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteInvoice }))
            //{
            //    //ConsM.DocType_DocInvoice = new DocType(lng.s_Invoice.s, GlobalData.const_DocInvoice);
            //    //ConsM.List_ConsumptionType.Add(ConsM.DocType_DocInvoice);
            //}

            //if (ConsM.m_LMOUser.HasLoginControlRole(new string[] { LoginControl.AWP.ROLE_Administrator, LoginControl.AWP.ROLE_WriteProformaInvoice }))
            //{
            ////    ConsM.DocType_DocProformaInvoice = new DocType(lng.s_DocProformaInvoice.s, GlobalData.const_DocProformaInvoice);
            ////    ConsM.List_ConsumptionType.Add(ConsM.DocType_DocProformaInvoice);
            //}

            ConsM.Consumption_All = new ConsumptionType(lng.s_AllConsumption.s, GlobalData.const_ConsumptionAll);
            ConsM.List_ConsumptionType.Add(ConsM.Consumption_All);

            ConsM.Consumption_WriteOff = new ConsumptionType(lng.s_WriteOff.s, GlobalData.const_ConsumptionWriteOff);
            ConsM.List_ConsumptionType.Add(ConsM.Consumption_WriteOff);

            ConsM.Consumption_OwnUse = new ConsumptionType(lng.s_OwnUse.s, GlobalData.const_ConsumptionOwnUse);
            ConsM.List_ConsumptionType.Add(ConsM.Consumption_OwnUse);


            if (ConsM.List_ConsumptionType.Count>0)
            {
                this.cmb_ConsumptionType.DataSource = null;
                this.cmb_ConsumptionType.DataSource = ConsM.List_ConsumptionType;
                this.cmb_ConsumptionType.DisplayMember = "ConsumptionType_Text_in_language";
                this.cmb_ConsumptionType.ValueMember = "Typ";
                if (ConsM.List_ConsumptionType.Count > 1)
                {
                    this.cmb_ConsumptionType.Enabled = true;
                }
                else
                {
                    this.cmb_ConsumptionType.Enabled = false;
                }
            }
            else
            {
                this.cmb_ConsumptionType.Enabled = false;
            }

            Set_cmb_InvoiceType_selected_index();
        }

        internal bool InitMan()
        {
            //LogFile.LogFile.WriteDEBUG("usrc_ConsumptionMan.cs:Init():start!");
            //Program.Cursor_Wait();

            Set_cmb_DocType();

            //if (!SetFinancialYears())
            //{
            //    return false;
            //}


            //splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_ConsumptionMan.cs:Init():before SetDocument()");
            Transaction transaction_usrcConsumptionMan1366x768_InitMan_SetDocument = DBSync.DBSync.NewTransaction("usrcConsumptionMan1366x768.InitMan.SetDocument");
            bool bRes = SetDocument(transaction_usrcConsumptionMan1366x768_InitMan_SetDocument);
            if (bRes)
            {
                transaction_usrcConsumptionMan1366x768_InitMan_SetDocument.Commit();
            }
            else
            {
                transaction_usrcConsumptionMan1366x768_InitMan_SetDocument.Rollback();
                return false;
            }

            this.cmb_ConsumptionType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
            SetColor();

            //Program.Cursor_Arrow();
           // this.m_usrc_ConsumptionEditor.Init(ID.Invalid);
            return bRes;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            m_usrc_ConsumptionEditor.WizzardShow_ShopsVisible(xshops_inuse);
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            m_usrc_ConsumptionEditor.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
        }

       

        //private bool SetFinancialYears()
        //{
        //    int Default_FinancialYear = ConsM.FinancialYear;

        //    cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;

        //    if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref ConsM.dt_FinancialYears, ConsM.IsDocInvoice, ConsM.IsDocProformaInvoice, ref Default_FinancialYear))
        //    {
        //        ConsM.FinancialYear = Default_FinancialYear;
        //        cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:Init:GlobalData.SetFinancialYears Failed!");
        //        return false;
        //    }

        //}

        private void Set_cmb_InvoiceType_selected_index()
        {
            if (this.cmb_ConsumptionType.Items.Count > 1)
            {
                int idx = find_cmb_DataType_Index(this.m_usrc_ConsumptionEditor.ConsE.DocTyp);
                if (idx >= 0)
                {
                    this.m_usrc_ConsumptionEditor.btn_New.Enabled = true;
                    this.cmb_ConsumptionType.SelectedIndex = idx;
                    //SetFinancialYears();
                }
            }
            else if (this.cmb_ConsumptionType.Items.Count == 1)
            {
                this.m_usrc_ConsumptionEditor.btn_New.Enabled = true;
                //string xDoxtyp = ((DocType)this.cmb_DocType.Items[0]).Typ;
                //ConsM.DocTyp = xDoxtyp;
                //SetFinancialYears();
            }
            else
            {
                cmb_FinancialYear.Enabled = false;
                this.cmb_ConsumptionType.Enabled = false;
                this.m_usrc_ConsumptionEditor.btn_New.Enabled = false;
            }
        }

        private int find_cmb_DataType_Index(string ConsTyp)
        {
            if (this.cmb_ConsumptionType.Items!=null)
            {
                int iCount = this.cmb_ConsumptionType.Items.Count;
                if (iCount >  0)
                {
                    for (int i=0;i<iCount;i++)
                    {
                        if (((ConsumptionType)this.cmb_ConsumptionType.Items[i]).Typ.Equals(ConsTyp))
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }


        internal bool SetDocument(Transaction transaction)
        {
            return ConsM.SetDocument(this.m_usrc_TableOfConsumption.Current_Consumption_ID, transaction);
        }

      

        //private void Cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
        //    //ConsM.Cmb_FinancialYear_SelectedIndexChanged(cmb_FinancialYear);
        //    cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
        //}


        private void m_usrc_Invoice_DocInvoiceSaved(ID DocInvoice_id)
        {
            //splitContainer1.Panel2Collapsed = false;
            ConsM.DocInvoiceSaved(DocInvoice_id);
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(ID DocProformaInvoice_id)
        {
            //splitContainer1.Panel2Collapsed = false;
            ConsM.DocProformaInvoiceSaved(DocProformaInvoice_id);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(ID DocInvoice_ID,bool bInitialise)
        {
            if (ID.Validate(DocInvoice_ID))
            {
                Transaction transaction_usrc_ConsumptionEditor_m_usrc_InvoiceTable_SelectedInvoiceChanged = DBSync.DBSync.NewTransaction("usrc_ConsumptionEditor.m_usrc_InvoiceTable_SelectedInvoiceChanged");
                if (m_usrc_ConsumptionEditor.DoCurrent(DocInvoice_ID, transaction_usrc_ConsumptionEditor_m_usrc_InvoiceTable_SelectedInvoiceChanged))
                {
                    transaction_usrc_ConsumptionEditor_m_usrc_InvoiceTable_SelectedInvoiceChanged.Commit();
                }
                else
                {
                    transaction_usrc_ConsumptionEditor_m_usrc_InvoiceTable_SelectedInvoiceChanged.Rollback();

                }
            }
            SetColor();
        }

        public void Reload()
        {
            //splitContainer1.Panel2Collapsed = false;
            SetMode(ConsumptionMan.eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show_v = null;
            if (m_usrc_ConsumptionEditor.ConsE != null)
            {
                if (m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption != null)
                {
                    if (ID.Validate(m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.Doc_ID))
                    {
                        Doc_ID_to_show_v = new ID(m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.Doc_ID);
                    }
                    this.m_usrc_TableOfConsumption.Init(ConsM, false, false, ConsM.FinancialYear, Doc_ID_to_show_v);
                }
            }
        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            Form_NewConsumption frm_new = new Form_NewConsumption(this, this.ConsM,this.m_usrc_ConsumptionEditor.usrc_DocIssue1.Total);
            frm_new.ShowDialog(this);
            switch (frm_new.eNewConsumptionResult)
            {
                case f_Consumption.eConsumptionType.OwnUse:
                    if (this.m_usrc_ConsumptionEditor.GetOwnUseData(this))
                    {

                        New_Empty_Consumption(f_Consumption.eConsumptionType.OwnUse);
                    }
                    break;
            }
            //if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;

            //if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
            //Form_NewDocument frm_new = new Form_NewDocument(this, this.ConsM, ConsM.mSettingsUserValues,this.m_usrc_ConsumptionEditor.usrc_DocIssue1.Total);
            //frm_new.ShowDialog(this);
            //if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;
            //switch (frm_new.eNewDocumentResult)
            //{
            //    case Form_NewDocument.e_NewDocument.New_Empty:
            //        New_Empty_Doc(frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, null);
            //        break;

            //    case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
            //        Transaction transaction_usrc_ConsumptionEditor_New_Copy_Of_SameDocType = DBSync.DBSync.NewTransaction("usrc_ConsumptionEditor.New_Copy_Of_SameDocType");
            //        if (New_Copy_Of_SameDocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, transaction_usrc_ConsumptionEditor_New_Copy_Of_SameDocType))
            //        {
            //            transaction_usrc_ConsumptionEditor_New_Copy_Of_SameDocType.Commit();
            //        }
            //        else
            //        {
            //            transaction_usrc_ConsumptionEditor_New_Copy_Of_SameDocType.Rollback();
            //        }
            //        break;
            //    case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
            //        Transaction transaction_usrc_ConsumptionEditor_New_Copy_To_Another_DocType = DBSync.DBSync.NewTransaction("usrc_ConsumptionEditor.New_Copy_To_Another_DocType");
            //        if (New_Copy_To_Another_DocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID, transaction_usrc_ConsumptionEditor_New_Copy_To_Another_DocType))
            //        {
            //            transaction_usrc_ConsumptionEditor_New_Copy_To_Another_DocType.Commit();
            //        }
            //        else
            //        {
            //            transaction_usrc_ConsumptionEditor_New_Copy_To_Another_DocType.Rollback();
            //        }
            //        break;
            //}
        }

        private void New_Empty_Consumption(f_Consumption.eConsumptionType xeConsumptionType)
        {
            //this.Cursor_Wait();

            if (cmb_ConsumptionType.SelectedItem is ConsumptionType)
            {
                ConsumptionType xConsumptionType = (ConsumptionType)cmb_ConsumptionType.SelectedItem;
                ConsM.ConsumptionTyp = xConsumptionType.Typ;

                //ID xAtom_Currency_ID = null;
                //Transaction transaction_usrc_ConsumptionMan_New_Empty_Consumption_f_Atom_Currency_Get = DBSync.DBSync.NewTransaction("usrc_ConsumptionMan.New_Empty_Consumption.f_Atom_Currency.Get");
                //if (f_Atom_Currency.Get(GlobalData.BaseCurrency.ID, ref xAtom_Currency_ID, transaction_usrc_ConsumptionMan_New_Empty_Consumption_f_Atom_Currency_Get))
                //{
                //    transaction_usrc_ConsumptionMan_New_Empty_Consumption_f_Atom_Currency_Get.Commit();
                //}
                //else
                //{
                //    transaction_usrc_ConsumptionMan_New_Empty_Consumption_f_Atom_Currency_Get.Rollback();
                //}

                //m_usrc_ConsumptionEditor.SetNewDraft(ConsM.m_LMOUser,
                //                                     ConsM.ConsumptionTyp,
                //                                     xeConsumptionType,
                //                                     ConsM.FinancialYear,
                //                                     GlobalData.BaseCurrency, 
                //                                     xAtom_Currency_ID);

                //    if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                //    {
                //        System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                //        int FinancialYear = (int)drv.Row.ItemArray[0];
                //        //Program.Cursor_Arrow();
                //        if (Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(FinancialYear))
                //        {
                //            Program.Cursor_Wait();
                //            m_usrc_ConsumptionEditor.SetNewDraft(ConsM.m_LMOUser, ConsM.DocTyp, FinancialYear, currency, xAtom_Currency_ID, workArea);
                ////            DateTime dtStart = DateTime.Now;
                ////            DateTime dtEnd = DateTime.Now;
                ////            m_usrc_TableOfConsumption.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                ////            m_usrc_TableOfConsumption.Init(ConsM, true, false, FinancialYear /*Properties.Settings.Default.FinancialYear*/, null);
                ////            ConsM.m_LMOUser.ReloadAdministratorsAndUserManagers();
                ////        }
                ////    }
                ////    else
                ////    {
                ////        Program.Cursor_Arrow();
                ////        LogFile.Error.Show("ERROR:usrc_ConsumptionMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                ////    }
                ////}
                ////Program.Cursor_Arrow();
            }
        }


        //private bool Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(int financialYear)
        //{
        //    if (ConsM.IsDocInvoice)
        //    {
        //        DateTime t = DateTime.Now;
        //        int current_year = t.Year;
        //        if (financialYear == current_year)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            int current_month = t.Month;
        //            if ((current_month <= OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice) && (financialYear + 1 == current_year))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                string smsg = lng.s_YouCanNotCreateNewInvoiceForPastFinancialYear.s + " " + financialYear + ".\r\n";
        //                smsg += lng.s_NumberOfMonthAfterNewYearToAllowCreateNewInvoiceIs.s + " " + OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.ToString() + "\r\n";
        //                XMessage.Box.Show(this, smsg, lng.s_Warning.s);
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        private bool ReadShopABC_items(ref List<TangentaDB.Consumption_ShopC_Item> xShopC_Data_Item_List, ref DataTable xdt_ShopB_Items, ref DataTable xdt_ShopA_Items, Transaction transaction)
        {
            if (xShopC_Data_Item_List == null)
            {
                xShopC_Data_Item_List = new List<TangentaDB.Consumption_ShopC_Item>();
            }
            else
            {
                xShopC_Data_Item_List.Clear();
            }
            if (this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.m_Basket.Read_Consumption_ShopC_Item_Table(ConsM.ConsumptionTyp, this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.Doc_ID, ref xShopC_Data_Item_List, transaction))
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
                
            }
            return false;
        }

        private bool WriteShopABC_items(string doc_type,
                                        List<TangentaDB.Consumption_ShopC_Item> xShopC_Data_Item_List, 
                                        DataTable xdt_ShopB_Items, 
                                        DataTable xdt_ShopA_Items,
                                        Transaction transaction)
        {
            //if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(ConsM.DocTyp, this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.Doc_ID, xdt_ShopA_Items, transaction))
            //{
            //    if (this.m_usrc_ConsumptionEditor.ConsE.m_ShopABC.Copy_ShopB_Price_Item_Table(ConsM.DocTyp, this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.Doc_ID, xdt_ShopB_Items, transaction))
            //    {
            //        //switch (this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.m_Basket.Copy_TangentaDB.Consumption_ShopC_Item(DocM.DocTyp,
            //        //                                                                                                this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption,
            //        //                                                                                                xShopC_Data_Item_List,
            //        //                                                                                                this.m_usrc_ConsumptionEditor.m_usrc_ShopC1366x768.AutomaticSelectionOfItemsFromStock,
            //        //                                                                                                this.m_usrc_ConsumptionEditor.m_usrc_ShopC1366x768.proc_Select_ShopC_Item_from_Stock,
            //        //                                                                                                this.m_usrc_ConsumptionEditor.m_usrc_ShopC1366x768.proc_Item_Not_In_Offer))
            //        //{
            //        //    case TangentaDB.Basket.eCopy_TangentaDB.Consumption_ShopC_Item_Result.OK:
            //        //        DocM.mSettingsUserValues.FinancialYear = this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.FinancialYear;
            //        //        m_usrc_TableOfDocuments.Init(DocM, true, false, this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.FinancialYear, null);
            //        //        cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            //        //        GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_ConsumptionEditor.ConsE.m_CurrentConsumption.FinancialYear);
            //        //        cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
            //        //        return true;
            //        //    case TangentaDB.Basket.eCopy_TangentaDB.Consumption_ShopC_Item_Result.ERROR_NO_ITEM_IN_DB:
            //        //        LogFile.Error.Show("ERROR:usrc_ConsumptionMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
            //        //        break;

            //        //    case TangentaDB.Basket.eCopy_TangentaDB.Consumption_ShopC_Item_Result.ERROR_DB:
            //        //        LogFile.Error.Show("ERROR:usrc_ConsumptionMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
            //        //        break;
            //        //}
            //    }
            //}
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
            //if (this.Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(xFinancialYear))
            //{
            //    Program.Cursor_Wait();
            //    if (cmb_DocType.SelectedItem is DocType)
            //    {
            //        DocType xDocType = (DocType)cmb_DocType.SelectedItem;
            //        string xdocType = xDocType.Typ;
            //        if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
            //        {
            //            List<TangentaDB.Consumption_ShopC_Item> xShopC_Data_Item_List = null;
            //            DataTable xdt_ShopB_Items = null;
            //            DataTable xdt_ShopA_Items = null;
            //            if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items, transaction))
            //            {
            //                m_usrc_ConsumptionEditor.SetNewDraft(ConsM.m_LMOUser,xdocType, xFinancialYear, currency, xAtom_Currency_ID,null);
            //                DateTime dtStart = DateTime.Now;
            //                DateTime dtEnd = DateTime.Now;
            //                m_usrc_TableOfConsumption.SetTimeSpanParam(usrc_TableOfConsumption.eMode.All, dtStart, dtEnd);
            //                if (WriteShopABC_items(xdocType,
            //                                   xShopC_Data_Item_List,
            //                                   xdt_ShopB_Items,
            //                                   xdt_ShopA_Items,
            //                                   transaction))
            //                {
            //                    m_usrc_TableOfConsumption.Init(ConsM, true, false, ConsM.FinancialYear, null);
            //                    ConsM.m_LMOUser.ReloadAdministratorsAndUserManagers();

            //                }
            //                else
            //                {
            //                    return false;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            Program.Cursor_Arrow();
            //            LogFile.Error.Show("ERROR:usrc_ConsumptionMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
            //        }
            //    }
            //    Program.Cursor_Arrow();
            //}
            return true;
        }


        //private bool New_Copy_To_Another_DocType(int xFinancialYear, xCurrency currency, ID xAtom_Currency_ID, Transaction transaction)
        //{
        //    if (this.Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(xFinancialYear))
        //    {
        //        Program.Cursor_Wait();
        //        if (cmb_DocType.SelectedItem is DocType)
        //        {
        //            DocType xDocType = (DocType)cmb_DocType.SelectedItem;
        //            string  xdoctyp = xDocType.Typ;
        //            string New_xdoctyp = GlobalData.const_DocInvoice;
        //            if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
        //            {
        //                List<TangentaDB.Consumption_ShopC_Item> xShopC_Data_Item_List = null;
        //                DataTable xdt_ShopB_Items = null;
        //                DataTable xdt_ShopA_Items = null;
        //                if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items, transaction))
        //                {
        //                    if (xdoctyp != null)
        //                    {
        //                        if (xdoctyp.Equals(GlobalData.const_DocInvoice))
        //                        {
        //                            ConsM.DocTyp = GlobalData.const_DocProformaInvoice;
        //                            New_xdoctyp = GlobalData.const_DocProformaInvoice;
        //                        }
        //                        else if (xdoctyp.Equals(GlobalData.const_DocProformaInvoice))
        //                        {
        //                            ConsM.DocTyp = GlobalData.const_DocInvoice;
        //                            New_xdoctyp = GlobalData.const_DocProformaInvoice;
        //                        }
        //                        else
        //                        {
        //                            LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:DocType not implemented:" + xdoctyp);
        //                            return false;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:DocType is null !");
        //                        return false;
        //                    }
        //                    SetDocInvoiceOrDocPoformaInvoice();
        //                    this.cmb_DocType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
        //                    Set_cmb_InvoiceType_selected_index();
        //                    this.cmb_DocType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

        //                    m_usrc_ConsumptionEditor.SetNewDraft(ConsM.m_LMOUser, New_xdoctyp, xFinancialYear, currency, xAtom_Currency_ID,null);
        //                    DateTime dtStart = DateTime.Now;
        //                    DateTime dtEnd = DateTime.Now;
        //                    m_usrc_TableOfConsumption.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
        //                    if (WriteShopABC_items(New_xdoctyp,
        //                                    xShopC_Data_Item_List,
        //                                    xdt_ShopB_Items,
        //                                    xdt_ShopA_Items,
        //                                    transaction))
        //                    {
        //                        m_usrc_TableOfConsumption.Init(ConsM, true, false, ConsM.mSettingsUserValues.FinancialYear, null);
        //                        ConsM.m_LMOUser.ReloadAdministratorsAndUserManagers();
        //                    }
        //                    else
        //                    {
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    Program.Cursor_Arrow();
        //                    LogFile.Error.Show("ERROR:usrc_ConsumptionMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
        //                }
        //            }
        //        }
        //    }
        //    Program.Cursor_Arrow();
        //    return true;
        //}

 
        //private void m_usrc_Invoice_Customer_Person_Changed(ID Customer_Person_ID)
        //{
        //    ConsM.Customer_Changed = true;
        //    if (this.m_usrc_TableOfConsumption.Visible)
        //    {
        //        ConsM.Customer_Changed = false;
        //        this.m_usrc_TableOfConsumption.Init(ConsM, false,false,ConsM.mSettingsUserValues.FinancialYear,null);
        //    }
        //}

        //private void m_usrc_Invoice_aa_Customer_Org_Changed(ID Customer_Org_ID)
        //{
        //    ConsM.Customer_Changed = true;
        //    if (this.m_usrc_TableOfConsumption.Visible)
        //    {
        //        ConsM.Customer_Changed = false;
        //        this.m_usrc_TableOfConsumption.Init(ConsM, false,false, ConsM.mSettingsUserValues.FinancialYear,null);
        //    }
        //}

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_TableOfConsumption.Init(ConsM, false,false, ConsM.FinancialYear,null);
        }


        private void btn_SelectPanels_Click(object sender, EventArgs e)
        {
            if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(ConsM);
            if (frm_select_panels.ShowDialog(this)==DialogResult.OK)
            {
                if (LayoutChanged!=null)
                {
                    LayoutChanged();
                }
            }
            if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;
        }

        internal void Activate_dgvx_XConsumption_SelectionChanged()
        {
            this.m_usrc_TableOfConsumption.Activate_dgvx_XConsumption_SelectionChanged();
        }

        private void SetDocInvoiceOrDocPoformaInvoice()
        {
            TSettings.RunAs = ConsM.ConsumptionTyp;

            this.m_usrc_TableOfConsumption.Clear();

            Transaction transaction_usrc_ConsumptionMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument = DBSync.DBSync.NewTransaction("usrc_ConsumptionMan.SetDocInvoiceOrDocPoformaInvoice.SetDocument");
            bool bRes = SetDocument(transaction_usrc_ConsumptionMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument);
            if (bRes)
            {
                transaction_usrc_ConsumptionMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument.Commit();
            }
            else
            {
                transaction_usrc_ConsumptionMan_SetDocInvoiceOrDocPoformaInvoice_SetDocument.Rollback();
                return;
            }
            //Program.Cursor_Arrow();
            //if (ConsM.IsDocInvoice)
            //{
            //    if (TSettings.b_FVI_SLO)
            //    {
            //        if (this.m_usrc_ConsumptionEditor.ConsE.InvoiceData.AddOnDI == null)
            //        {
            //            this.m_usrc_ConsumptionEditor.ConsE.InvoiceData.AddOnDI = new DocInvoice_AddOn();
            //        }
            //        this.m_usrc_ConsumptionEditor.ConsE.InvoiceData.AddOnDI.b_FVI_SLO = TSettings.b_FVI_SLO;
            //        TSettings.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(DBSync.DBSync.MyTransactionLog_delegates, this.m_usrc_ConsumptionEditor.ConsE.m_ShopABC, this.m_usrc_ConsumptionEditor.ConsE.InvoiceData.AddOnDI, this.m_usrc_ConsumptionEditor.ConsE.InvoiceData.AddOnDPI);
            //    }
            //}
        }
        private void cmb_InvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Program.Cursor_Wait();
            switch (cmb_ConsumptionType.SelectedIndex)
            {
                case 0: // usrc_Invoice.enum_Invoice.TaxInvoice:
                    ConsM.ConsumptionTyp = GlobalData.const_DocInvoice;
                    break;
                case 1: // usrc_Invoice.enum_Invoice.ProformaInvoice:
                    ConsM.ConsumptionTyp = GlobalData.const_DocProformaInvoice;

                    break;
            }
            SetColor();
            SetDocInvoiceOrDocPoformaInvoice();
            //SetFinancialYears();
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
        }

        internal void SetColor()
        {
            //if (ConsM.IsDocInvoice)
            //{
            //    this.BackColor = Colors.DocInvoice.BackColor;
            //    //this.pnl_MainMenu.BackColor = Colors.DocInvoice.BackColor;
            //    //this.pnl_MainMenu.ForeColor = Colors.DocInvoice.ForeColor;
            //    //this.splitContainer1.BackColor = Colors.DocInvoice.BackColor;
            //    this.m_usrc_ConsumptionEditor.SetColor();
            //    this.m_usrc_TableOfConsumption.BackColor = Colors.m_usrc_TableOfDocuments.BackColor;
            //    this.m_usrc_TableOfConsumption.ForeColor = Colors.m_usrc_TableOfDocuments.ForeColor;
            //}
            //else
            //{
            //    this.BackColor = Colors.DocProformaInvoice.BackColor;
            //    //this.pnl_MainMenu.BackColor = Colors.DocProformaInvoice.BackColor;
            //    //this.pnl_MainMenu.ForeColor = Colors.DocProformaInvoice.ForeColor;
            //    //this.splitContainer1.BackColor = Colors.DocProformaInvoice.BackColor;
            //    this.m_usrc_ConsumptionEditor.SetColor();
            //    this.m_usrc_TableOfConsumption.BackColor = Colors.m_usrc_TableOfDocuments.BackColor;
            //    this.m_usrc_TableOfConsumption.ForeColor = Colors.m_usrc_TableOfDocuments.ForeColor;
            //}
            //if (Program.MainForm != null)
            //{
            //    Program.MainForm.BackColor = this.BackColor;
            //}
        }

        internal bool Initialise(Form main_Form, LoginControl.LMOUser xLMOUser,int financialYear,string consumptiontype)
        {
            m_Form_Document = main_Form;
            ConsM = new ConsumptionMan(SetMode, TableOfDocuments_Init, Control_ConsumptionEditor_Init, SetInitialMode, xLMOUser, financialYear, consumptiontype);

            this.m_usrc_TableOfConsumption.Bind(ConsM.m_LMOUser);
            if (m_usrc_ConsumptionEditor.Initialise(ConsM, ConsM.m_LMOUser))
            {
                m_usrc_ConsumptionEditor.Issue += M_usrc_ConsumptionEditor_Issue;
                return true;
            }
            return false;

        }

        private bool M_usrc_ConsumptionEditor_Issue(OwnUseAddOn ownuse_add_on, Transaction transaction)
        {
            ID x_atom_currency_ID = null;
            if (!f_Atom_Currency.Get(GlobalData.BaseCurrency.ID,ref x_atom_currency_ID,transaction))
            {
                return false;
            }
            ID consumption_ID = null;
            int draftNumber = 0;
            if (this.ConsM.ConsE.MyConsumptionData.Issue(ConsM.m_LMOUser.Atom_WorkPeriod_ID,
                                                            ConsM.FinancialYear,
                                                            x_atom_currency_ID,
                                                            ownuse_add_on,
                                                            ref consumption_ID,
                                                            ref draftNumber,
                                                            transaction))
            {
                this.ConsM.ConsE.m_CurrentConsumption.Doc_ID = consumption_ID;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool Init()
        {
            return InitMan();
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit_Click != null)
            {
                Exit_Click(ConsM.ConsumptionTyp, this.m_usrc_TableOfConsumption.Current_Consumption_ID, ConsM.m_LMOUser, LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        internal void EndProgram(LoginControl.LoginCtrl.eExitReason eres)
        {
            if (Exit_Click != null)
            {
                Exit_Click(ConsM.ConsumptionTyp, this.m_usrc_TableOfConsumption.Current_Consumption_ID, ConsM.m_LMOUser, eres);
            }
        }

        //private void btn_Settings_Click(object sender, EventArgs e)
        //{
        //    if (ConsM.door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
        //    {
        //        if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = false;
        //        Form_SettingsSelect frm_settingsselect = new Form_SettingsSelect(m_Form_Document, this, ConsM.mSettingsUserValues);
        //        frm_settingsselect.ShowDialog(this);
        //        if (this.Visible && TSettings.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

        //    }
        //}

        //private void usrc_FVI_SLO1_PasswordCheck(ref bool PasswordOK)
        //{
        //    PasswordOK = false;
        //    if (ConsM.door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
        //    {
        //        PasswordOK = true;
        //    }
        //}

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
            if (ConsM.timer_Login_MultiUsers_Countdown >0)
            {
                if (HasWindowsOpened())
                {
                    ConsM.timer_Login_MultiUsers_Countdown = TangentaProperties.Properties.Settings.Default.timer_Login_MultiUser_Countdown;
                }
                else
                {
                    btn_Exit.Text = ConsM.timer_Login_MultiUsers_Countdown.ToString();
                    ConsM.timer_Login_MultiUsers_Countdown--;
                }
            }
            else
            {
                Exit_Click(ConsM.ConsumptionTyp, this.m_usrc_TableOfConsumption.Current_Consumption_ID, ConsM.m_LMOUser, LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => { ConsM.timer_Login_MultiUsers_Countdown = TangentaProperties.Properties.Settings.Default.timer_Login_MultiUser_Countdown; };
                initControlsRecursive(c.Controls);
            }
        }

        private void m_usrc_ConsumptionEditor_SetBtnIssueLabel(string slabel)
        {
            usrc_DocIssue1.BtnIssueLabel = slabel;
        }

        private void m_usrc_ConsumptionEditor_SetBtnIssueVisible(bool bvisible)
        {
            if (!m_usrc_ConsumptionEditor.Visible)
            {
                usrc_DocIssue1.Visible = bvisible;
            }
            else
            {
                usrc_DocIssue1.Visible = false;
            }
        }

        private void m_usrc_ConsumptionEditor_SetTotal(string stotal)
        {
            usrc_DocIssue1.Total = stotal;
        }

        private void m_usrc_ConsumptionEditor_SetTotalColor(Color color)
        {
            usrc_DocIssue1.TotalColor = color;
        }

        private void usrc_DocIssue1_DoClick(object sender, EventArgs e)
        {
            m_usrc_ConsumptionEditor.btn_Issue_Click(sender, e);
        }
    }
}
