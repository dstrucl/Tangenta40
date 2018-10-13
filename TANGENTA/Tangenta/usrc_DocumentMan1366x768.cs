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
    public partial class usrc_DocumentMan1366x768 : UserControl
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

        public string DocTyp
        {
            get
            {
                return DocM.DocTyp;
            }
            set
            {
                string s = value;
                DocM.DocTyp = s;
            }
        }

        internal bool m_usrc_Invoice_ViewMode
        {
            get { return m_usrc_DocumentEditor1366x768.DocE.m_mode == DocumentEditor.emode.view_eDocumentType; }
        }

  

        public bool m_usrc_InvoiceTable_Visible
        {
            get { return this.m_usrc_TableOfDocuments.Visible; }
        }

        public bool m_usrc_Invoice_Visible
        {
            get { return m_usrc_DocumentEditor1366x768.Visible; }
        }

        public bool ShopA_Visible
        {
            get {
                    if (m_usrc_DocumentEditor1366x768!=null)
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
                if (m_usrc_DocumentEditor1366x768 != null)
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
                if (m_usrc_DocumentEditor1366x768 != null)
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
                if (m_usrc_DocumentEditor1366x768 != null)
                {
                    return m_usrc_DocumentEditor1366x768.HeadVisible;
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
                    if (Program.OperationMode.MultiUser)
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

        public usrc_DocumentMan1366x768()
        {
            InitializeComponent();
            lng.s_Year.Text(lbl_FinancialYear);
            m_usrc_DocumentEditor1366x768.LayoutChanged += M_usrc_Invoice_LayoutChanged;
            DocM = new DocumentMan(SetMode, TableOfDocuments_Init, Control_DocumentEditor_Init,SetInitialMode);
        }

        internal bool Control_DocumentEditor_Init(ID xdoc_ID)
        {
            return m_usrc_DocumentEditor1366x768.Init(xdoc_ID);
        }

        private int TableOfDocuments_Init(DocumentMan xdocM,
                 bool bNew,
                 bool bInitialise_usrc_Invoice,
                 int iFinancialYear,
                 ID Doc_ID_To_show)
        {
            return this.m_usrc_TableOfDocuments.Init(xdocM, bNew, bInitialise_usrc_Invoice, iFinancialYear, Doc_ID_To_show);
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
            m_Form_Document.loginControl1.SetAccessAuthentification(Properties.Settings.Default.AccessAuthentication);
            if (Program.Login_MultipleUsers)
            {
                initControlsRecursive(this.Controls);
            }
        }



        public void SetMode(DocumentMan.eMode mode)
        {
            if (mode == DocumentMan.eMode.Shops)
            {
                //splitContainer1.Panel2Collapsed = true;
                //splitContainer1.Panel1Collapsed = false;
            }
            else if (mode == DocumentMan.eMode.InvoiceTable)
            {
                //splitContainer1.Panel2Collapsed = false;
                //splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                //splitContainer1.Panel2Collapsed = false;
                //splitContainer1.Panel1Collapsed = false;
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
                sLastDocInvoiceType =  PropertiesUser.LastDocType_Get(DocM.mSettingsUserValues);
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
                DocM.DocTyp = sLastDocInvoiceType;
            }
            else if (sLastDocInvoiceType.Equals(GlobalData.const_DocProformaInvoice))
            {
                DocM.DocTyp = sLastDocInvoiceType;
            }
            else
            {
                DocM.DocTyp = GlobalData.const_DocProformaInvoice;
                PropertiesUser.LastDocType_Set(DocM.mSettingsUserValues, DocM.DocTyp);
              
            }

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

        internal bool InitMan()
        {
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():start!");
            Program.Cursor_Wait();

            Set_cmb_DocType();

            if (!SetFinancialYears())
            {
                return false;
            }


            //splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before SetDocument()");

            bool bRes = SetDocument();

            this.cmb_DocType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
            SetColor();

            Program.Cursor_Arrow();
            return bRes;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            m_usrc_DocumentEditor1366x768.WizzardShow_ShopsVisible(xshops_inuse);
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            m_usrc_DocumentEditor1366x768.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
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

            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref DocM.dt_FinancialYears, DocM.IsDocInvoice, DocM.IsDocProformaInvoice, ref Default_FinancialYear))
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
                int idx = find_cmb_DataType_Index(this.m_usrc_DocumentEditor1366x768.DocE.DocTyp);
                if (idx >= 0)
                {
                    this.m_usrc_DocumentEditor1366x768.btn_New.Enabled = true;
                    this.cmb_DocType.SelectedIndex = idx;
                    SetFinancialYears();
                }
            }
            else if (this.cmb_DocType.Items.Count == 1)
            {
                this.m_usrc_DocumentEditor1366x768.btn_New.Enabled = true;
                string xDoxtyp = ((DocType)this.cmb_DocType.Items[0]).Typ;
                DocM.DocTyp = xDoxtyp;
                SetFinancialYears();
            }
            else
            {
                cmb_FinancialYear.Enabled = false;
                this.cmb_DocType.Enabled = false;
                this.m_usrc_DocumentEditor1366x768.btn_New.Enabled = false;
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
            return DocM.SetDocument(this.m_usrc_TableOfDocuments.Current_Doc_ID);
        }

      

        private void Cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            DocM.Cmb_FinancialYear_SelectedIndexChanged(cmb_FinancialYear);
            cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
        }


        private void m_usrc_Invoice_DocInvoiceSaved(ID DocInvoice_id)
        {
            //splitContainer1.Panel2Collapsed = false;
            DocM.DocInvoiceSaved(DocInvoice_id);
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(ID DocProformaInvoice_id)
        {
            //splitContainer1.Panel2Collapsed = false;
            DocM.DocProformaInvoiceSaved(DocProformaInvoice_id);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(ID DocInvoice_ID,bool bInitialise)
        {
            if (ID.Validate(DocInvoice_ID))
            {
                if (m_usrc_DocumentEditor1366x768.DoCurrent(DocInvoice_ID))
                {
                }
            }
            SetColor();
        }

        public void Reload()
        {
            //splitContainer1.Panel2Collapsed = false;
            SetMode(DocumentMan.eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show_v = null;
            if (m_usrc_DocumentEditor1366x768.DocE.m_ShopABC != null)
            {
                if (m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc != null)
                {
                    if (ID.Validate(m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID))
                    {
                        Doc_ID_to_show_v = new ID(m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                    }
                    this.m_usrc_TableOfDocuments.Init(DocM, false, false, DocM.mSettingsUserValues.FinancialYear, Doc_ID_to_show_v);
                }
            }
        }


        private void btn_New_Click(object sender, EventArgs e)
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
                Form_NewDocument frm_new = new Form_NewDocument(this, DocM.mSettingsUserValues);
                frm_new.ShowDialog(this);
                if (this.Visible && Program.Login_MultipleUsers) timer_Login_MultiUser.Enabled = true;

                switch (frm_new.eNewDocumentResult)
                {
                    case Form_NewDocument.e_NewDocument.New_Empty:
                        New_Empty_Doc(frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID,null);
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

        private void New_Empty_Doc(xCurrency currency,ID xAtom_Currency_ID, WArea workArea)
        {
            Program.Cursor_Wait();
            if (cmb_DocType.SelectedItem is DocType)
            {
                DocType xDocType = (DocType)cmb_DocType.SelectedItem;
                DocM.DocTyp  = xDocType.Typ;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    int FinancialYear = (int)drv.Row.ItemArray[0];
                    Program.Cursor_Arrow();
                    if (Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(FinancialYear))
                    {
                        Program.Cursor_Wait();
                        m_usrc_DocumentEditor1366x768.SetNewDraft(DocM.m_LMOUser, DocM.DocTyp, FinancialYear, currency, xAtom_Currency_ID, workArea);
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


        private bool Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(int financialYear)
        {
            if (DocM.IsDocInvoice)
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
            if (this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.m_Basket.Read_Doc_ShopC_Item_Table(DocM.DocTyp, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xShopC_Data_Item_List))
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
                if (this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopB_Items))
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
                    if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocM.DocTyp, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref xdt_ShopA_Items))
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
            if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(DocM.DocTyp, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopA_Items))
            {
                if (this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.Copy_ShopB_Price_Item_Table(DocM.DocTyp, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, xdt_ShopB_Items))
                {
                    switch (this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.m_Basket.Copy_ShopC_Price_Item_Stock_Table(DocM.DocTyp,
                                                                                                                    this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc,
                                                                                                                    xShopC_Data_Item_List,
                                                                                                                    this.m_usrc_DocumentEditor1366x768.m_usrc_ShopC1366x768.AutomaticSelectionOfItemsFromStock,
                                                                                                                    this.m_usrc_DocumentEditor1366x768.m_usrc_ShopC1366x768.proc_Select_ShopC_Item_from_Stock,
                                                                                                                    this.m_usrc_DocumentEditor1366x768.m_usrc_ShopC1366x768.proc_Item_Not_In_Offer))
                    {
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.OK:
                            DocM.mSettingsUserValues.FinancialYear = this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.FinancialYear;
                            m_usrc_TableOfDocuments.Init(DocM, true, false, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.FinancialYear, null);
                            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
                            GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC.m_CurrentDoc.FinancialYear);
                            cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
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
                            m_usrc_DocumentEditor1366x768.SetNewDraft(DocM.m_LMOUser,xdocType, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(xdocType,
                                               xShopC_Data_Item_List,
                                               xdt_ShopB_Items,
                                               xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(DocM, true, false, DocM.mSettingsUserValues.FinancialYear, null);
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
                                    DocM.DocTyp = GlobalData.const_DocProformaInvoice;
                                    New_xdoctyp = GlobalData.const_DocProformaInvoice;
                                }
                                else if (xdoctyp.Equals(GlobalData.const_DocProformaInvoice))
                                {
                                    DocM.DocTyp = GlobalData.const_DocInvoice;
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

                            m_usrc_DocumentEditor1366x768.SetNewDraft(DocM.m_LMOUser, New_xdoctyp, xFinancialYear, currency, xAtom_Currency_ID,null);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(New_xdoctyp,
                                            xShopC_Data_Item_List,
                                            xdt_ShopB_Items,
                                            xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(DocM, true, false, DocM.mSettingsUserValues.FinancialYear, null);
                            DocM.m_LMOUser.ReloadAdministratorsAndUserManagers();
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
            DocM.Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                DocM.Customer_Changed = false;
                this.m_usrc_TableOfDocuments.Init(DocM, false,false,DocM.mSettingsUserValues.FinancialYear,null);
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
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(DocM,DocM.mSettingsUserValues);
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
            Program.RunAs = DocM.DocTyp;

            this.m_usrc_TableOfDocuments.Clear();

            bool bRes = SetDocument();
            Program.Cursor_Arrow();
            if (DocM.IsDocInvoice)
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI == null)
                    {
                        this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI = new DocInvoice_AddOn();
                    }
                    this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                    Program.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC, this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDPI);
                }
            }
        }
        private void cmb_InvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Cursor_Wait();
            switch (cmb_DocType.SelectedIndex)
            {
                case 0: // usrc_Invoice.enum_Invoice.TaxInvoice:
                    DocM.DocTyp = GlobalData.const_DocInvoice;
                    break;
                case 1: // usrc_Invoice.enum_Invoice.ProformaInvoice:
                    DocM.DocTyp = GlobalData.const_DocProformaInvoice;

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
            if (DocM.IsDocInvoice)
            {
                this.BackColor = Colors.DocInvoice.BackColor;
                //this.pnl_MainMenu.BackColor = Colors.DocInvoice.BackColor;
                //this.pnl_MainMenu.ForeColor = Colors.DocInvoice.ForeColor;
                //this.splitContainer1.BackColor = Colors.DocInvoice.BackColor;
                this.m_usrc_DocumentEditor1366x768.SetColor();
                this.m_usrc_TableOfDocuments.BackColor = Colors.m_usrc_TableOfDocuments.BackColor;
                this.m_usrc_TableOfDocuments.ForeColor = Colors.m_usrc_TableOfDocuments.ForeColor;
            }
            else
            {
                this.BackColor = Colors.DocProformaInvoice.BackColor;
                //this.pnl_MainMenu.BackColor = Colors.DocProformaInvoice.BackColor;
                //this.pnl_MainMenu.ForeColor = Colors.DocProformaInvoice.ForeColor;
                //this.splitContainer1.BackColor = Colors.DocProformaInvoice.BackColor;
                this.m_usrc_DocumentEditor1366x768.SetColor();
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
            return m_usrc_DocumentEditor1366x768.Initialise(DocM, DocM.m_LMOUser);
        }


        internal bool Init()
        {
            string Err = null;
            m_usrc_TableOfDocuments.DocM = this.DocM;
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
                            if (DocM.IsDocInvoice)
                            {
                                if (Program.b_FVI_SLO)
                                {
                                    this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                    if (Program.FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor1366x768.DocE.m_ShopABC, this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor1366x768.DocE.m_InvoiceData.AddOnDPI))
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
            PropertiesUser.LastDocType_Set(DocM.mSettingsUserValues, this.DocTyp);
            if (Exit_Click != null)
            {
                Exit_Click(DocM.DocTyp,this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser,LoginControl.LoginCtrl.eExitReason.NORMAL);
            }
        }

        internal void EndProgram(LoginControl.LoginCtrl.eExitReason eres)
        {
            if (Exit_Click != null)
            {
                Exit_Click(DocM.DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser, eres);
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
                Exit_Click(DocM.DocTyp, this.m_usrc_TableOfDocuments.Current_Doc_ID, DocM.m_LMOUser, LoginControl.LoginCtrl.eExitReason.NORMAL);
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
    }
}
