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

namespace Tangenta
{
    public partial class usrc_DocumentMan : UserControl
    {
        private Form Main_Form = null;

        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public delegate void delegate_Exit_Click();

        internal usrc_DocumentEditor.eGetOrganisationDataResult Startup_05_Check_myOrganisation_Data()
        {
            usrc_DocumentEditor.eGetOrganisationDataResult eres = this.m_usrc_DocumentEditor.GetOrganisationData();
            return eres;

        }

        public event delegate_Exit_Click Exit_Click;


        internal bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;
        private Form m_pparent = null;
        public List<Tangenta.usrc_DocumentEditor.InvoiceType> List_InvoiceType = new List<Tangenta.usrc_DocumentEditor.InvoiceType>();
        public Tangenta.usrc_DocumentEditor.InvoiceType InvoiceType_DocInvoice = null;
        public Tangenta.usrc_DocumentEditor.InvoiceType InvoiceType_DocProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();
        private string m_DocInvoice = Program.const_DocInvoice;

        public int SplitContainer1_spd
        {
            get
            {
                return splitContainer1.SplitterDistance;
            }
            set
            {
                StaticLib.Func.SetSplitContainerValue(splitContainer1, value);
            }
        }

        internal bool m_usrc_Invoice_ViewMode
        {
            get { return m_usrc_DocumentEditor.m_mode == usrc_DocumentEditor.emode.view_eDocumentType; }
        }

        public string DocInvoice
        {
            get { return m_DocInvoice; }
            set
            {
                string s = value;
                if (s.Equals(Program.const_DocInvoice) || s.Equals(Program.const_DocProformaInvoice))
                {
                    m_DocInvoice = value;
                }
                m_usrc_DocumentEditor.DocInvoice = m_DocInvoice;
                m_usrc_TableOfDocuments.DocInvoice = m_DocInvoice;
            }
        }

        public bool IsDocInvoice
        {
            get
            { return DocInvoice.Equals(Program.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocInvoice.Equals(Program.const_DocProformaInvoice); }
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

        public usrc_DocumentMan()
        {
            InitializeComponent();
            Program.usrc_TangentaPrint1 = this.usrc_TangentaPrint1;
            lng.s_btn_New.Text(btn_New);
            lng.s_Year.Text(lbl_FinancialYear);
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

        internal bool InitialiseMan(Form pparent)
        {
            m_pparent = pparent;
            return m_usrc_DocumentEditor.Initialise(this);
        }

        internal bool InitMan(NavigationButtons.Navigation xnav)
        {
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():start!");
            Program.Cursor_Wait();

            if (this.cmb_InvoiceType == null)
            {
                LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():this.cmb_InvoiceType == null");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():this.cmb_InvoiceType != null");
            }

            this.cmb_InvoiceType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);


            string sLastDocInvoiceType = null;

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before if (Program.RunAs == null)");

            if (Program.RunAs == null)
            {
                sLastDocInvoiceType = Properties.Settings.Default.LastDocInvoiceType;
                if (sLastDocInvoiceType.Equals(Program.const_DocInvoice)|| sLastDocInvoiceType.Equals(Program.const_DocProformaInvoice))
                {
                    Program.RunAs = sLastDocInvoiceType;
                }
                else
                {
                    Program.RunAs = Program.const_DocInvoice;
                }

            }
            else 
            {
                sLastDocInvoiceType = Program.RunAs;
            }

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before if (sLastDocInvoiceType.Equals(..))");

            if (sLastDocInvoiceType.Equals(Program.const_DocInvoice))
            {
                this.DocInvoice = sLastDocInvoiceType;
            }
            else if (sLastDocInvoiceType.Equals(Program.const_DocProformaInvoice))
            {
                this.DocInvoice = sLastDocInvoiceType;
            }
            else
            {
                this.DocInvoice = Program.const_DocProformaInvoice;
                Properties.Settings.Default.LastDocInvoiceType = this.DocInvoice;
                Properties.Settings.Default.Save();
            }

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before InvoiceType_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType!");

            InvoiceType_DocInvoice = new Tangenta.usrc_DocumentEditor.InvoiceType(lng.s_Invoice.s, Tangenta.usrc_DocumentEditor.enum_Invoice.TaxInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocInvoice)");
            List_InvoiceType.Add(InvoiceType_DocInvoice);

            InvoiceType_DocProformaInvoice = new Tangenta.usrc_DocumentEditor.InvoiceType(lng.s_DocProformaInvoice.s, Tangenta.usrc_DocumentEditor.enum_Invoice.ProformaInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocProformaInvoice);");

            List_InvoiceType.Add(InvoiceType_DocProformaInvoice);
            this.cmb_InvoiceType.DataSource = null;
            this.cmb_InvoiceType.DataSource = List_InvoiceType;
            this.cmb_InvoiceType.DisplayMember = "InvoiceType_Text";
            this.cmb_InvoiceType.ValueMember = "eInvoiceType";
            Set_cmb_InvoiceType_selected_index();

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before SetFinancialYears()");


            if (!SetFinancialYears())
            {
                return false;
            }


            splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:Init():before SetDocument(xnav)");

            bool bRes = SetDocument(xnav);

            this.cmb_InvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
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
            if (xDocInvoice.Equals(Program.const_DocProformaInvoice))
            {
                cmb_InvoiceType.SelectedIndex = 1;
            }
            else if (xDocInvoice.Equals(Program.const_DocInvoice))
            {
                cmb_InvoiceType.SelectedIndex = 0;
            }
            this.Refresh();
            if (LayoutChanged != null)
            {
                LayoutChanged();
            }
        }

        private bool SetFinancialYears()
        {
            int Default_FinancialYear = Properties.Settings.Default.FinancialYear;

            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;

            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref dt_FinancialYears, IsDocInvoice, IsDocProformaInvoice, ref Default_FinancialYear))
            {
                Properties.Settings.Default.FinancialYear = Default_FinancialYear;
                Properties.Settings.Default.Save();
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
            switch (this.m_usrc_DocumentEditor.eInvoiceType)
            {
                case usrc_DocumentEditor.enum_Invoice.TaxInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 0;
                    break;
                case usrc_DocumentEditor.enum_Invoice.ProformaInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 1;
                    break;
            }
            SetFinancialYears();
        }

        internal bool SetDocument(NavigationButtons.Navigation xnav)
        {
            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():before mthis.m_usrc_InvoiceTable.Init(..)");

            int iRowsCount = this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false, true, Properties.Settings.Default.FinancialYear,null);

            LogFile.LogFile.WriteDEBUG("usrc_DocumentMan.cs:SetDocument():before m_usrc_Invoice.Init(xnav, this.m_usrc_InvoiceTable.Current_Doc_ID)");
            if (!m_usrc_DocumentEditor.Init(xnav, this.m_usrc_TableOfDocuments.Current_Doc_ID))
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

        internal void SaveSplitControlsSpliterDistance()
        {
            if (SplitContainer1_spd>0)
            {
                Properties.Settings.Default.DocumentMan_SplitControl1_splitterdistance = SplitContainer1_spd;
            }
            if (this.m_usrc_DocumentEditor != null)
            {
                this.m_usrc_DocumentEditor.SaveSplitControlsSpliterDistance();
            }
        }

        private void Cmb_FinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
            if (drv["FinancialYear"] is int)
            {
                int iFinancialYear = (int)drv["FinancialYear"];
                if (iFinancialYear != Properties.Settings.Default.FinancialYear)
                {
                    Properties.Settings.Default.FinancialYear = iFinancialYear;
                    Properties.Settings.Default.Save();
                    SetFinancialYears();
                    this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
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
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType,false,false, Properties.Settings.Default.FinancialYear, Doc_ID_to_show_v);
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
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false, false, Properties.Settings.Default.FinancialYear, Doc_ID_to_show);
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


        private void btn_New_Click(object sender, EventArgs e)
        {
            Form_NewDocument frm_new = new Form_NewDocument(this);
            frm_new.ShowDialog(this);
            switch (frm_new.eNewDocumentResult)
            {
                case Form_NewDocument.e_NewDocument.New_Empty:

                    New_Empty_Doc(frm_new.usrc_Currency1.Currency,frm_new.usrc_Currency1.Atom_Currency_ID);
                    break;

                case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                    New_Copy_Of_SameDocType(frm_new.FinancialYear, frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID);
                    break;
                case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                    New_Copy_To_Another_DocType(frm_new.FinancialYear,frm_new.usrc_Currency1.Currency, frm_new.usrc_Currency1.Atom_Currency_ID);
                    break;
            }
        }

        private void New_Empty_Doc(xCurrency currency,ID xAtom_Currency_ID)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_DocumentEditor.InvoiceType)
            {
                Tangenta.usrc_DocumentEditor.InvoiceType xInvoiceType = (Tangenta.usrc_DocumentEditor.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_DocumentEditor.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    int FinancialYear = (int)drv.Row.ItemArray[0];
                    Program.Cursor_Arrow();
                    if (Check_NumberOfMonthAfterNewYearToAllowCreateNewInvoice(FinancialYear))
                    {
                        Program.Cursor_Wait();
                        m_usrc_DocumentEditor.SetNewDraft(eInvType, FinancialYear, currency, xAtom_Currency_ID);
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;
                        m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                        m_usrc_TableOfDocuments.Init(eInvType, true, false, FinancialYear /*Properties.Settings.Default.FinancialYear*/, null);
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
            if (Properties.Settings.Default.DocumentMan_SplitControl1_splitterdistance>0)
            {
                this.splitContainer1.SplitterDistance = Properties.Settings.Default.DocumentMan_SplitControl1_splitterdistance;
            }
            if (m_usrc_DocumentEditor!=null)
            {
                m_usrc_DocumentEditor.SetSplitControlsSpliterDistance();
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
            if (this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xShopC_Data_Item_List))
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
                if (this.m_usrc_DocumentEditor.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopB_Items))
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
                    if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocInvoice, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopA_Items))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool WriteShopABC_items(Tangenta.usrc_DocumentEditor.enum_Invoice xeInvType,
                                        List<object> xShopC_Data_Item_List, 
                                        DataTable xdt_ShopB_Items, 
                                        DataTable xdt_ShopA_Items)
        {
            if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(DocInvoice, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.Doc_ID, xdt_ShopA_Items))
            {
                if (this.m_usrc_DocumentEditor.m_ShopABC.Copy_ShopB_Price_Item_Table(this.DocInvoice, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.Doc_ID, xdt_ShopB_Items))
                {
                    switch (this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.m_Basket.Copy_ShopC_Price_Item_Stock_Table(DocInvoice,
                                                                                                                    this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice,
                                                                                                                    xShopC_Data_Item_List,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.AutomaticSelectionOfItemsFromStock,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Select_ShopC_Item_from_Stock,
                                                                                                                    this.m_usrc_DocumentEditor.m_usrc_ShopC.proc_Item_Not_In_Offer))
                    {
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.OK:
                            Properties.Settings.Default.FinancialYear = this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear;
                            Properties.Settings.Default.Save();
                            m_usrc_TableOfDocuments.Init(xeInvType, true, false, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear, null);
                            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
                            GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear);
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
                if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_DocumentEditor.InvoiceType)
                {
                    Tangenta.usrc_DocumentEditor.InvoiceType xInvoiceType = (Tangenta.usrc_DocumentEditor.InvoiceType)cmb_InvoiceType.SelectedItem;
                    Tangenta.usrc_DocumentEditor.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                    if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                    {
                        List<object> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                        {
                            m_usrc_DocumentEditor.SetNewDraft(eInvType, xFinancialYear, currency, xAtom_Currency_ID);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(eInvType,
                                               xShopC_Data_Item_List,
                                               xdt_ShopB_Items,
                                               xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(eInvType, true, false, Properties.Settings.Default.FinancialYear, null);
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
                if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_DocumentEditor.InvoiceType)
                {
                    Tangenta.usrc_DocumentEditor.InvoiceType xInvoiceType = (Tangenta.usrc_DocumentEditor.InvoiceType)cmb_InvoiceType.SelectedItem;
                    Tangenta.usrc_DocumentEditor.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                    Tangenta.usrc_DocumentEditor.enum_Invoice New_eInvType = usrc_DocumentEditor.enum_Invoice.TaxInvoice;
                    if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                    {
                        List<object> xShopC_Data_Item_List = null;
                        DataTable xdt_ShopB_Items = null;
                        DataTable xdt_ShopA_Items = null;
                        if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                        {
                            if (eInvType == usrc_DocumentEditor.enum_Invoice.TaxInvoice)
                            {
                                DocInvoice = Program.const_DocProformaInvoice;
                                New_eInvType = usrc_DocumentEditor.enum_Invoice.ProformaInvoice;
                            }
                            else if (eInvType == usrc_DocumentEditor.enum_Invoice.ProformaInvoice)
                            {
                                DocInvoice = Program.const_DocInvoice;
                                New_eInvType = usrc_DocumentEditor.enum_Invoice.TaxInvoice;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:usrc_Invoice.enum_Invoice not implemented:" + eInvType.ToString());
                                return;
                            }
                            SetDocInvoiceOrDocPoformaInvoice();
                            this.cmb_InvoiceType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
                            Set_cmb_InvoiceType_selected_index();
                            this.cmb_InvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

                            m_usrc_DocumentEditor.SetNewDraft(New_eInvType, xFinancialYear, currency, xAtom_Currency_ID);
                            DateTime dtStart = DateTime.Now;
                            DateTime dtEnd = DateTime.Now;
                            m_usrc_TableOfDocuments.SetTimeSpanParam(usrc_TableOfDocuments.eMode.All, dtStart, dtEnd);
                            WriteShopABC_items(New_eInvType,
                                            xShopC_Data_Item_List,
                                            xdt_ShopB_Items,
                                            xdt_ShopA_Items);
                            m_usrc_TableOfDocuments.Init(New_eInvType, true, false, Properties.Settings.Default.FinancialYear, null);
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
                this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false,false,Properties.Settings.Default.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(ID Customer_Org_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_TableOfDocuments.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_TableOfDocuments.Init(m_usrc_DocumentEditor.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
        }

        private void m_usrc_Invoice_Load(object sender, EventArgs e)
        {

        }



        private void m_usrc_Invoice_PriceListChanged()
        {
            NavigationButtons.Navigation nav_Invoice_PriceListChanged = new NavigationButtons.Navigation(null);
            nav_Invoice_PriceListChanged.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.Init(nav_Invoice_PriceListChanged);
        }

        private void btn_SelectPanels_Click(object sender, EventArgs e)
        {
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(this);
            if (frm_select_panels.ShowDialog(this)==DialogResult.OK)
            {
                if (LayoutChanged!=null)
                {
                    LayoutChanged();
                }
            }
            
        }

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            this.m_usrc_TableOfDocuments.Activate_dgvx_XInvoice_SelectionChanged();
        }

        private void SetDocInvoiceOrDocPoformaInvoice()
        {
            Program.RunAs = DocInvoice;
            bool bRes = SetDocument(null);
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
                    Program.usrc_FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor.m_ShopABC, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDPI);
                }
            }
        }
        private void cmb_InvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Cursor_Wait();
            switch (cmb_InvoiceType.SelectedIndex)
            {
                case 0: // usrc_Invoice.enum_Invoice.TaxInvoice:
                    DocInvoice = Program.const_DocInvoice;
                    break;
                case 1: // usrc_Invoice.enum_Invoice.ProformaInvoice:
                    DocInvoice = Program.const_DocProformaInvoice;

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

        private bool Get_FVI(Navigation xnav)
        {
            Program.b_FVI_SLO = false;
            if (myOrg.Address_v != null)
            {
                if (myOrg.Address_v.Country_ISO_3166_num == TangentaDB.PostAddress_v.SLO_Country_ISO_3166_num)
                {
                    Program.b_FVI_SLO = true;
                    if (Program.bFirstTimeInstallation)
                    {
                        Do_Form_FVI_check:
                        xnav.ChildDialog = new Form_FVI_check(xnav);
                        xnav.ShowDialog();
                        if (Program.b_FVI_SLO)
                        {
                            if (xnav.eExitResult == Navigation.eEvent.NEXT)
                            {
                                long FVI_SLO_RealEstateBP_rows_count = fs.GetTableRowsCount("FVI_SLO_RealEstateBP");
                                if (FVI_SLO_RealEstateBP_rows_count == 0)
                                {

                                    Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP:

                                    xnav.ChildDialog = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID, xnav);
                                    xnav.ShowDialog();
                                    if (xnav.eExitResult == Navigation.eEvent.PREV)
                                    {
                                        goto Do_Form_FVI_check;
                                    }
                                    else if (xnav.eExitResult == Navigation.eEvent.NEXT)
                                    {
                                        bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
                                        xnav.ChildDialog = new FiscalVerificationOfInvoices_SLO.Form_Settings(usrc_FVI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL);
                                        Program.Reset2FactorySettings.FiscalVerification_DLL = Reset2FactorySettings_FiscalVerification_DLL;
                                        xnav.ShowDialog();
                                        if (xnav.eExitResult == Navigation.eEvent.PREV)
                                        {
                                            goto Do_Form_myOrg_Office_Data_FVI_SLO_RealEstateBP;
                                        }
                                    }
                                }
                                else
                                {
                                    bool Reset2FactorySettings_FiscalVerification_DLL = Program.Reset2FactorySettings.FiscalVerification_DLL;
                                    xnav.ChildDialog = new FiscalVerificationOfInvoices_SLO.Form_Settings(usrc_FVI_SLO1, xnav, ref Reset2FactorySettings_FiscalVerification_DLL);
                                    Program.Reset2FactorySettings.FiscalVerification_DLL = Reset2FactorySettings_FiscalVerification_DLL;
                                    xnav.ShowDialog();
                                    if (xnav.eExitResult == Navigation.eEvent.PREV)
                                    {
                                        goto Do_Form_FVI_check;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        internal bool Startup_08_CheckPogramSettings(bool bResetShopsInUse)
        {
            if (Program.bFirstTimeInstallation || (Program.Shops_in_use.Length == 0))
            {
                return false;
            }
            else
            {
                if (Program.Shops_in_use.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool Startup_08_Show_Form_ProgramSettings(NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_ProgramSettings(this, xnav), typeof(Form_ProgramSettings).ToString());
            return true;
        }


        public bool Get_ProgramSettings(NavigationButtons.Navigation xnav, bool bResetShopsInUse)
        {
            if (Program.bFirstTimeInstallation || (Program.Shops_in_use.Length == 0))
            {
                xnav.ChildDialog = new Form_ProgramSettings(this, xnav);
                xnav.ShowDialog();
                if (xnav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
                {
                    switch (xnav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            return true;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            return true;
                        default:
                            return false;
                    }
                }
                else if (xnav.m_eButtons == NavigationButtons.Navigation.eButtons.OkCancel)
                {
                    switch (xnav.eExitResult)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:

                            if (m_usrc_DocumentEditor != null)
                            {
                                if (m_usrc_DocumentEditor.DBtcn != null)
                                {
                                    m_usrc_DocumentEditor.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
                                    return true;
                                }
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Document:Get_shops_in_use:Error " + xnav.m_eButtons.ToString() + "not implemented!");
                    return false;
                }
            }
            else
            {
                if (Program.Shops_in_use.Length > 0)
                {
                    xnav.eExitResult = Navigation.eEvent.NEXT;
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Document:Get_shops_in_use:Error Program.Shops_in_use.Length <= 0!");
                    return false;
                }
            }
        }

        internal bool Startup_12_Get_Printer(startup myStartup, ref string Err)
        {
            //Insert default templates for Proforma Invoice and for 
            if (f_doc.InsertDefault())
            {
                TangentaPrint.PrintersList.Init();

                if (TangentaPrint.PrintersList.Read(Reset2FactorySettings.TangentaPrint_DLL))
                {
                    //myStartup.eNextStep++;
                    return true;
                }
                else
                {
                    return false;

                }
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        internal bool Get_Printer(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            //Insert default templates for Proforma Invoice and for 
            if (f_doc.InsertDefault())
            {
                TangentaPrint.PrintersList.Init();

                if (TangentaPrint.PrintersList.Read(Reset2FactorySettings.TangentaPrint_DLL))
                {
                    //myStartup.eNextStep++;
                    return true;
                }
                else
                {
                    if (TangentaPrint.PrintersList.Define(xnav))
                    {
                        if (xnav.eExitResult == Navigation.eEvent.NEXT)
                        {
                            //myStartup.eNextStep++;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.PREV)
                        {
                            //myStartup.eNextStep--;
                            return true;
                        }
                        else if (xnav.eExitResult == Navigation.eEvent.CANCEL)
                        {
                            //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return false;
                        }
                    }
                    return false;
                }
            }
            else
            {
                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                return false;
            }
        }

        internal bool Initialise(Form main_Form)
        {
            Main_Form = main_Form;
            return InitialiseMan(Main_Form);
        }


        internal bool SetShopsPricelists(startup myStartup, object oData, Navigation xnav, ref string Err)
        {
            if (m_usrc_DocumentEditor != null)
            {
                if (m_usrc_DocumentEditor.DBtcn != null)
                {
                    m_usrc_DocumentEditor.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
                    if (xnav.eExitResult == Navigation.eEvent.NEXT)
                    {
                        //myStartup.eNextStep++;
                        return true;
                    }
                    else if (xnav.eExitResult == Navigation.eEvent.PREV)
                    {
                        //myStartup.eNextStep--;
                        return true;
                    }
                    else if (xnav.eExitResult == Navigation.eEvent.EXIT)
                    {
                        //myStartup.eNextStep = startup_step.eStep.Cancel;
                        return true;
                    }
                }
            }

            //myStartup.eNextStep++;
            return true;
        }

        internal bool Init(NavigationButtons.Navigation xnav)
        {
            string Err = null;
            Program.usrc_FVI_SLO1 = this.usrc_FVI_SLO1;
            Program.thread_fvi = this.usrc_FVI_SLO1.thread_fvi;
            Program.message_box = this.usrc_FVI_SLO1.message_box;

            if (Program.b_FVI_SLO)
            {

                Program.usrc_FVI_SLO1.FursD_ElectronicDeviceID = GlobalData.ElectronicDevice_Name;
            }

            if (Program.b_FVI_SLO)
            {
                if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(Main_Form, ref Program.Atom_FVI_SLO_RealEstateBP_ID, 1))
                {
                }
            }

            LogFile.LogFile.WriteDEBUG("usrc_Document.cs:Init():before this.m_usrc_DocumentMan.Init(xnav)!");

            if (this.InitMan(xnav))
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.usrc_FVI_SLO1.Start(ref Err))
                    {
                        if (this.IsDocInvoice)
                        {
                            if (Program.b_FVI_SLO)
                            {
                                this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                if (Program.usrc_FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_DocumentEditor.m_ShopABC, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDI, this.m_usrc_DocumentEditor.m_InvoiceData.AddOnDPI))
                                {
                                    this.SetDocument(xnav);
                                }
                                //Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_DocumentMan.m_usrc_Invoice.m_ShopABC, this.m_usrc_DocumentMan.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_DocumentMan.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("usrc_Main:Init:this.usrc_FVI_SLO1.Start(ref Err):Err=" + Err);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckInsertSampleData(startup myStartup, NavigationButtons.Navigation xnav)
        {
            Form_CheckInsertSampleData frmdlg = new Form_CheckInsertSampleData(myStartup, xnav);
            xnav.ChildDialog = frmdlg;
            xnav.ShowDialog();
            return myStartup.bInsertSampleData;
        }

        internal bool Startup_05_Show_Form_CheckInsertSampleData(startup myStartup, NavigationButtons.Navigation xnav)
        {
            xnav.ShowForm(new Form_CheckInsertSampleData(myStartup, xnav), typeof(Form_CheckInsertSampleData).ToString());
            return true;
        }



        internal bool GetDBSettings(ref string Err)
        {
            bool bReadOnly = false;
            Err = null;
            long lRowsCount = fs.GetTableRowsCount("DBSettings");
            if (lRowsCount > 1) //Database "Version" is wriiten after database creation in DBSettings
            {
                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, ref Program.AdministratorLockedPassword, ref bReadOnly, ref Err))
                {
                    case fs.enum_GetDBSettings.DBSettings_OK:
                        string MultiuserOperationWithLogin = null;
                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, ref MultiuserOperationWithLogin, ref bReadOnly, ref Err))
                        {
                            case fs.enum_GetDBSettings.DBSettings_OK:
                                Program.OperationMode.MultiUser = MultiuserOperationWithLogin.Equals("1");

                                string StockCheckAtStartup = null;
                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name, ref StockCheckAtStartup, ref bReadOnly, ref Err))
                                {
                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                        Program.OperationMode.StockCheckAtStartup = StockCheckAtStartup.Equals("1");

                                        string sSingleUserLoginAsAdministrator = null;
                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.SingleUserLoginAsAdministrator.Name, ref sSingleUserLoginAsAdministrator, ref bReadOnly, ref Err))
                                        {
                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                Program.OperationMode.SingleUserLoginAsAdministrator = sSingleUserLoginAsAdministrator.Equals("1");

                                                string sShopC_ExclusivelySellFromStock = null;
                                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name, ref sShopC_ExclusivelySellFromStock, ref bReadOnly, ref Err))
                                                {
                                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                                        Program.OperationMode.ShopC_ExclusivelySellFromStock = sShopC_ExclusivelySellFromStock.Equals("1");

                                                        string sMultiCurrencyOperation = null;
                                                        switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name, ref sMultiCurrencyOperation, ref bReadOnly, ref Err))
                                                        {
                                                            case fs.enum_GetDBSettings.DBSettings_OK:
                                                                Program.OperationMode.MultiCurrency = sMultiCurrencyOperation.Equals("1");
                                                                string sNumberOfMonthAfterNewYearToAllowCreateNewInvoice = null;
                                                                switch (fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Name, ref sNumberOfMonthAfterNewYearToAllowCreateNewInvoice, ref bReadOnly, ref Err))
                                                                {
                                                                    case fs.enum_GetDBSettings.DBSettings_OK:
                                                                        try
                                                                        {
                                                                            Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice = Convert.ToInt32(sNumberOfMonthAfterNewYearToAllowCreateNewInvoice);
                                                                        }
                                                                        catch
                                                                        {
                                                                            Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice = 1;
                                                                        }
                                                                        return true;

                                                                    case fs.enum_GetDBSettings.No_TextValue:
                                                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Name;
                                                                        return false;

                                                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:

                                                                        return false;
                                                                }
                                                                break;

                                                            case fs.enum_GetDBSettings.No_TextValue:
                                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name;
                                                                return false;

                                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:

                                                                return false;
                                                        }
                                                        break;

                                                    case fs.enum_GetDBSettings.No_TextValue:
                                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name;
                                                        return false;

                                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                        return false;
                                                }
                                                break;


                                            case fs.enum_GetDBSettings.No_TextValue:
                                            case fs.enum_GetDBSettings.No_Data_Rows:
                                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                                return false;

                                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                                return false;
                                        }
                                        break;

                                    case fs.enum_GetDBSettings.No_ReadOnly:
                                    case fs.enum_GetDBSettings.No_TextValue:
                                    case fs.enum_GetDBSettings.No_Data_Rows:
                                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name;
                                        return false;
                                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                        return false;
                                }
                                break;


                            case fs.enum_GetDBSettings.No_ReadOnly:
                            case fs.enum_GetDBSettings.No_TextValue:
                            case fs.enum_GetDBSettings.No_Data_Rows:
                                Err = DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name;
                                return false;
                            case fs.enum_GetDBSettings.Error_Load_DBSettings:
                                return false;
                        }
                        break;
                    case fs.enum_GetDBSettings.No_ReadOnly:
                    case fs.enum_GetDBSettings.No_TextValue:
                    case fs.enum_GetDBSettings.No_Data_Rows:
                        Err = DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name;
                        return false;

                    case fs.enum_GetDBSettings.Error_Load_DBSettings:
                        Err = fs.ERROR;
                        return false;
                }

                return false; // GlobalData.Type_definitions_Read();
            }
            else
            {
                Err = fs.EMPTYTABLE;
                return false; // No DataRows;
            }
        }




        private bool getWorkPeriod(ID myOrganisation_Person_ID, ref ID xAtom_WorkPeriod_ID)
        {
            string Err = null;
            if (GlobalData.GetWorkPeriod(myOrganisation_Person_ID, f_Atom_WorkPeriod.sWorkPeriod, lng.s_WorkPeriod.s, DateTime.Now, null, ref Err))
            {
                xAtom_WorkPeriod_ID = GlobalData.Atom_WorkPeriod_ID;
                return true;
            }
            else
            {
                xAtom_WorkPeriod_ID = null;
                GlobalData.Atom_WorkPeriod_ID = null;
                return false;
            }
        }

        public bool call_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new)
        {
            Navigation xnav = new Navigation(null);
            xnav.m_eButtons = Navigation.eButtons.OkCancel;
            if (myOrg.m_myOrg_Office != null)
            {
                if (ID.Validate(myOrg.m_myOrg_Office.m_myOrg_Person.ID))
                {
                    Form_myOrg_Person_Edit frm_myOrgPerEdit = new Form_myOrg_Person_Edit(myOrg.m_myOrg_Office.m_myOrg_Person.ID, xnav);
                    frm_myOrgPerEdit.TopMost = parentform.TopMost;
                    frm_myOrgPerEdit.Show(parentform);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:call_Edit_myOrganisationPerson:myOrg.m_myOrg_Office.m_myOrg_Person.ID is not valid!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:call_Edit_myOrganisationPerson:(myOrg.m_myOrg_Office == null!");
                return false;
            }
        }


        public bool ShowMultipleUserLoginControl(startup myStartup, object oData, NavigationButtons.Navigation xnav, ref string Err)
        {
            if (Program.Login_MultipleUsers)
            {
                bool bCancel = false;
                this.loginControl1.Init(LoginControl.LoginCtrl.eDataTableCreationMode.AWP,
                                                DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con,
                                                this.getWorkPeriod,
                                                call_Edit_myOrganisationPerson,
                                                null,
                                                LanguageControl.DynSettings.LanguageID,
                                                ref bCancel
                                                );

                usrc_DocumentMan xusrc_DocumentMan = null;
                if (Program.Login_MultipleUsers)
                {
                    xusrc_DocumentMan = this;
                }

                if (this.loginControl1.Login(xnav, getWorkPeriod, xusrc_DocumentMan))
                {
                    //myStartup.eNextStep++;
                    myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(this.loginControl1.myOrganisation_Person_ID);
                    if (Program.Login_MultipleUsers)
                    {
                        return true;
                    }
                    else
                    {
                        if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:GetWorkPeriod:myOrg.m_myOrg_Office.m_myOrg_Person==null");
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool GetWorkPeriod(startup myStartup, object oData, NavigationButtons.Navigation xnav, ref string Err)
        {
            if (Program.OperationMode.MultiUser)
            {
                bool bCancel = false;
                this.loginControl1.Init(LoginControl.LoginCtrl.eDataTableCreationMode.AWP,
                                                DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con,
                                                this.getWorkPeriod,
                                                call_Edit_myOrganisationPerson,
                                                null,
                                                LanguageControl.DynSettings.LanguageID,
                                                ref bCancel
                                                );

        
                if (this.loginControl1.Login(xnav, getWorkPeriod, null))
                {
                    //myStartup.eNextStep++;
                    myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(this.loginControl1.myOrganisation_Person_ID);
                    if (Program.Login_MultipleUsers)
                    {
                        return true;
                    }
                    else
                    {
                        if (myOrg.m_myOrg_Office.m_myOrg_Person == null)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:GetWorkPeriod:myOrg.m_myOrg_Office.m_myOrg_Person==null");
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                    return false;
                }
            }
            else // Single user
            {
                this.loginControl1.Visible = false;
                ID myOrganisation_Person_first_ID = f_myOrganisation_Person.First_ID();
                if (ID.Validate(myOrganisation_Person_first_ID))
                {
                    if (Program.bFirstTimeInstallation)
                    {
                        if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, lng.s_WorkPeriod.s,  DateTime.Now, null, ref Err))
                        {
                            //myStartup.eNextStep++;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                            //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                            return false;
                        }
                    }
                    else
                    {
                        if (Program.OperationMode.SingleUserLoginAsAdministrator)
                        {
                            if (Door.DoLoginAsAdministrator((Form)this.Parent))
                            {
                                if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, lng.s_WorkPeriod.s, DateTime.Now, null, ref Err))
                                {
                                    //myStartup.eNextStep++;
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                                    //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                    return false;
                                }
                            }
                            else
                            {
                                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                return false;
                            }
                        }
                        else
                        {
                            if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, lng.s_WorkPeriod.s,  DateTime.Now, null, ref Err))
                            {
                                //myStartup.eNextStep++;
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Main:GlobalData.GetWorkPeriod:Err=" + Err);
                                //myStartup.eNextStep = Startup.startup_step.eStep.Cancel;
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit_Click != null)
            {
                Exit_Click();
            }
        }




        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                NavigationButtons.Navigation nav_Form_ProgramSettings = new NavigationButtons.Navigation(null);
                nav_Form_ProgramSettings.bDoModal = true;
                nav_Form_ProgramSettings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                Form_ProgramSettings edt_Form = new Form_ProgramSettings(this, nav_Form_ProgramSettings);
                edt_Form.ShowDialog();
                edt_Form.Dispose();
            }
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {

            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            NavigationButtons.Navigation nav = new NavigationButtons.Navigation(null);
            nav.btn3_Visible = true;
            nav.btn3_Text = "";
            nav.btn3_Image = Properties.Resources.Exit;
            string xCodeTables_IniFileFolder = null;
            string Err = null;
            if (StaticLib.Func.SetApplicationDataSubFolder(ref xCodeTables_IniFileFolder, Program.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                string xSQLitebackupFolder = Properties.Settings.Default.SQLiteBackupFolder;
                if (xSQLitebackupFolder.Length == 0)
                {
                    if (StaticLib.Func.SetApplicationDataSubFolder(ref xSQLitebackupFolder, Program.TANGENTA_SQLITEBACKUP_SUB_FOLDER, ref Err))
                    {
                    }
                }
                DBSync.DBSync.DBMan(Main_Form, Program.Reset2FactorySettings.DBConnectionControlXX_EXE, ((Form_Document)Main_Form).m_XmlFileName, xCodeTables_IniFileFolder, ref sDBType, ref xSQLitebackupFolder, nav);
                Properties.Settings.Default.SQLiteBackupFolder = xSQLitebackupFolder;
                Properties.Settings.Default.DBType = sDBType;
                Properties.Settings.Default.Save();
            }
        }


        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                Form_CodeTables fct_dlg = new Form_CodeTables();
                fct_dlg.ShowDialog();
            }
        }

        private void usrc_FVI_SLO1_PasswordCheck(ref bool PasswordOK)
        {
            PasswordOK = false;
            if (Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this)))
            {
                PasswordOK = true;
            }
        }

        private bool usrc_TangentaPrint1_CheckEditPrinterAccess()
        {
            return Door.OpenIfUserIsAdministrator(Global.f.GetParentForm(this));
        }

    }
}
