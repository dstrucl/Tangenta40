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

namespace Tangenta
{
    public partial class usrc_InvoiceMan : UserControl
    {
        Form Main_Form = null;

        public delegate void delegate_LayoutChanged();
        public event delegate_LayoutChanged LayoutChanged = null;

        public delegate void delegate_Exit_Click();

        internal usrc_Invoice.eGetOrganisationDataResult Startup_05_Check_myOrganisation_Data()
        {
            usrc_Invoice.eGetOrganisationDataResult eres = this.m_usrc_Invoice.GetOrganisationData();
            return eres;

        }

        public event delegate_Exit_Click Exit_Click;

        public UpgradeDB_inThread m_UpgradeDB = null;


        internal bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;
        Form m_pparent = null;
        public List<Tangenta.usrc_Invoice.InvoiceType> List_InvoiceType = new List<Tangenta.usrc_Invoice.InvoiceType>();
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_DocInvoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_DocProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();
        private string m_DocInvoice = Program.const_DocInvoice;

        internal bool m_usrc_Invoice_ViewMode
        {
            get { return m_usrc_Invoice.m_mode == usrc_Invoice.emode.view_eInvoiceType; }
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
                m_usrc_Invoice.DocInvoice = m_DocInvoice;
                m_usrc_InvoiceTable.DocInvoice = m_DocInvoice;
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
                    if (m_usrc_Invoice!=null)
                    {
                        return m_usrc_Invoice.ShopA_Visible;
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
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.ShopB_Visible;
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
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.ShopC_Visible;
                }
                else
                {
                    return false;
                }
            }
        }


        public usrc_InvoiceMan()
        {
            InitializeComponent();
            m_UpgradeDB = new UpgradeDB_inThread(this);
            Program.usrc_TangentaPrint1 = this.usrc_TangentaPrint1;
            lng.s_btn_New.Text(btn_New);
            lng.s_Year.Text(lbl_FinancialYear);
            m_usrc_Invoice.LayoutChanged += M_usrc_Invoice_LayoutChanged;
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
            else if (sManagerMode.Equals(";"))
            {
                Mode = eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_InvoiceMan:SetInitialMode:Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
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
            return m_usrc_Invoice.Initialise(this);
        }

        internal bool InitMan(NavigationButtons.Navigation xnav)
        {
            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():start!");
            Program.Cursor_Wait();

            if (this.cmb_InvoiceType == null)
            {
                LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():this.cmb_InvoiceType == null");
            }
            else
            {
                LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():this.cmb_InvoiceType != null");
            }

            this.cmb_InvoiceType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);


            string sLastDocInvoiceType = null;

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before if (Program.RunAs == null)");

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

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before if (sLastDocInvoiceType.Equals(..))");

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

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before InvoiceType_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType!");

            InvoiceType_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType(lng.s_Invoice.s, Tangenta.usrc_Invoice.enum_Invoice.TaxInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocInvoice)");
            List_InvoiceType.Add(InvoiceType_DocInvoice);

            InvoiceType_DocProformaInvoice = new Tangenta.usrc_Invoice.InvoiceType(lng.s_DocProformaInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.ProformaInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocProformaInvoice);");

            List_InvoiceType.Add(InvoiceType_DocProformaInvoice);
            this.cmb_InvoiceType.DataSource = null;
            this.cmb_InvoiceType.DataSource = List_InvoiceType;
            this.cmb_InvoiceType.DisplayMember = "InvoiceType_Text";
            this.cmb_InvoiceType.ValueMember = "eInvoiceType";
            Set_cmb_InvoiceType_selected_index();

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before SetFinancialYears()");


            if (!SetFinancialYears())
            {
                return false;
            }


            splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before SetDocument(xnav)");

            bool bRes = SetDocument(xnav);

            this.cmb_InvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
            SetBackGroundColor();

            Program.Cursor_Arrow();
            return bRes;
        }

        internal void WizzardShow_ShopsVisible(string xshops_inuse)
        {
            m_usrc_Invoice.WizzardShow_ShopsVisible(xshops_inuse);
        }

        internal void WizzardShow_usrc_Invoice_Head_Visible(bool bvisible)
        {
            m_usrc_Invoice.WizzardShow_usrc_Invoice_Head_Visible(bvisible);
        }

        internal void WizzardShow_InvoiceTable_Visible(bool bvisible)
        {
            if (bvisible)
            {
                SetMode(usrc_InvoiceMan.eMode.Shops_and_InvoiceTable);
            }
            else
            {
                SetMode(usrc_InvoiceMan.eMode.Shops);
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
                LogFile.Error.Show("ERROR:Tangenta:usrc_InvoiceMan:Init:GlobalData.SetFinancialYears Failed!");
                return false;
            }

        }

        private void Set_cmb_InvoiceType_selected_index()
        {
            switch (this.m_usrc_Invoice.eInvoiceType)
            {
                case usrc_Invoice.enum_Invoice.TaxInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 0;
                    break;
                case usrc_Invoice.enum_Invoice.ProformaInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 1;
                    break;
            }
            SetFinancialYears();
        }

        internal bool SetDocument(NavigationButtons.Navigation xnav)
        {
            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():before mthis.m_usrc_InvoiceTable.Init(..)");

            int iRowsCount = this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, true, Properties.Settings.Default.FinancialYear,null);

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():before m_usrc_Invoice.Init(xnav, this.m_usrc_InvoiceTable.Current_Doc_ID)");
            if (!m_usrc_Invoice.Init(xnav, this.m_usrc_InvoiceTable.Current_Doc_ID))
            {
                Program.Cursor_Arrow();
                return false;
            }

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():before SetInitialMode()");

            SetInitialMode();

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():after SetInitialMode()");

            SetMode(Mode);
            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():End procedure ");
            return true;
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
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
                }
            }
        }





        private void m_usrc_Invoice_DocInvoiceSaved(long DocInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            long_v Doc_ID_to_show_v = null;
            if (DocInvoice_id>=0)
            {
                Doc_ID_to_show_v = new long_v(DocInvoice_id);
            }
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,false,false, Properties.Settings.Default.FinancialYear, Doc_ID_to_show_v);
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(long DocProformaInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            long_v Doc_ID_to_show_v = null;
            if (DocProformaInvoice_id >= 0)
            {
                Doc_ID_to_show_v = new long_v(DocProformaInvoice_id);
            }
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, false, Properties.Settings.Default.FinancialYear, Doc_ID_to_show_v);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(long DocInvoice_ID,bool bInitialise)
        {
            if (DocInvoice_ID >= 0)
            {
                if (m_usrc_Invoice.DoCurrent(DocInvoice_ID))
                {
                }
            }
            SetBackGroundColor();
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

        private void New_Empty_Doc(xCurrency currency,long xAtom_Currency_ID)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    int FinancialYear = (int)drv.Row.ItemArray[0];

                    m_usrc_Invoice.SetNewDraft(eInvType, FinancialYear, currency, xAtom_Currency_ID);
                    DateTime dtStart = DateTime.Now;
                    DateTime dtEnd = DateTime.Now;
                    m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                    m_usrc_InvoiceTable.Init(eInvType, true, false, FinancialYear /*Properties.Settings.Default.FinancialYear*/, null);
                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            Program.Cursor_Arrow();
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
            if (this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xShopC_Data_Item_List))
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
                if (this.m_usrc_Invoice.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopB_Items))
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
                    if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopA_Items))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool WriteShopABC_items(Tangenta.usrc_Invoice.enum_Invoice xeInvType,
                                        List<object> xShopC_Data_Item_List, 
                                        DataTable xdt_ShopB_Items, 
                                        DataTable xdt_ShopA_Items)
        {
            if (ShopA_dbfunc.dbfunc.Write_ShopA_Price_Item_Table(DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, xdt_ShopA_Items))
            {
                if (this.m_usrc_Invoice.m_ShopABC.Copy_ShopB_Price_Item_Table(this.DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, xdt_ShopB_Items))
                {
                    switch (this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.m_Basket.Copy_ShopC_Price_Item_Stock_Table(DocInvoice,
                                                                                                                    this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice,
                                                                                                                    xShopC_Data_Item_List,
                                                                                                                    this.m_usrc_Invoice.m_usrc_ShopC.AutomaticSelectionOfItemsFromStock,
                                                                                                                    this.m_usrc_Invoice.m_usrc_ShopC.proc_Select_ShopC_Item_from_Stock,
                                                                                                                    this.m_usrc_Invoice.m_usrc_ShopC.proc_Item_Not_In_Offer))
                    {
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.OK:
                            Properties.Settings.Default.FinancialYear = this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear;
                            Properties.Settings.Default.Save();
                            m_usrc_InvoiceTable.Init(xeInvType, true, false, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear, null);
                            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
                            GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear);
                            cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                            if (this.m_usrc_Invoice.m_usrc_ShopC != null)
                            {
                                this.m_usrc_Invoice.m_usrc_ShopC.usrc_ItemList.Paint_Current_Group();
                            }
                            return true;
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_NO_ITEM_IN_DB:
                            LogFile.Error.Show("ERROR:usrc_InvoiceMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                            break;
                        case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_DB:
                            LogFile.Error.Show("ERROR:usrc_InvoiceMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                            break;
                    }
                }
            }
            return false;
        }
        private void New_Copy_Of_SameDocType(int xFinancialYear, xCurrency currency, long xAtom_Currency_ID)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    List<object> xShopC_Data_Item_List = null;
                    DataTable xdt_ShopB_Items = null;
                    DataTable xdt_ShopA_Items = null;
                    if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                    {
                        m_usrc_Invoice.SetNewDraft(eInvType, xFinancialYear, currency, xAtom_Currency_ID);
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;
                        m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                        WriteShopABC_items(eInvType,
                                           xShopC_Data_Item_List,
                                           xdt_ShopB_Items,
                                           xdt_ShopA_Items);
                        m_usrc_InvoiceTable.Init(eInvType, true, false, Properties.Settings.Default.FinancialYear, null);
                    }
                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            Program.Cursor_Arrow();
        }


        private void New_Copy_To_Another_DocType(int xFinancialYear, xCurrency currency, long xAtom_Currency_ID)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                Tangenta.usrc_Invoice.enum_Invoice New_eInvType = usrc_Invoice.enum_Invoice.TaxInvoice;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    List<object> xShopC_Data_Item_List = null;
                    DataTable xdt_ShopB_Items = null;
                    DataTable xdt_ShopA_Items = null;
                    if (ReadShopABC_items(ref xShopC_Data_Item_List, ref xdt_ShopB_Items, ref xdt_ShopA_Items))
                    {
                        if (eInvType == usrc_Invoice.enum_Invoice.TaxInvoice)
                        {
                            DocInvoice = Program.const_DocProformaInvoice;
                            New_eInvType = usrc_Invoice.enum_Invoice.ProformaInvoice;
                        }
                        else if (eInvType == usrc_Invoice.enum_Invoice.ProformaInvoice)
                        {
                            DocInvoice = Program.const_DocInvoice;
                            New_eInvType = usrc_Invoice.enum_Invoice.TaxInvoice;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Tangenta:usrc_InvoiceMan:usrc_Invoice.enum_Invoice not implemented:" + eInvType.ToString());
                            return;
                        }
                        SetDocInvoiceOrDocPoformaInvoice();
                        this.cmb_InvoiceType.SelectedIndexChanged -= new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);
                        Set_cmb_InvoiceType_selected_index();
                        this.cmb_InvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

                        m_usrc_Invoice.SetNewDraft(New_eInvType, xFinancialYear, currency, xAtom_Currency_ID);
                        DateTime dtStart = DateTime.Now;
                        DateTime dtEnd = DateTime.Now;
                        m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                        WriteShopABC_items(New_eInvType,
                                        xShopC_Data_Item_List,
                                        xdt_ShopB_Items,
                                        xdt_ShopA_Items);
                        m_usrc_InvoiceTable.Init(New_eInvType, true, false, Properties.Settings.Default.FinancialYear, null);
                    }
                    else
                    {
                        Program.Cursor_Arrow();
                        LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                    }
                }
            }
            Program.Cursor_Arrow();
        }

 
        private void m_usrc_Invoice_Customer_Person_Changed(long Customer_Person_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false,Properties.Settings.Default.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(long Customer_Org_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear,null);
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
            this.m_usrc_InvoiceTable.Activate_dgvx_XInvoice_SelectionChanged();
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
                    if (this.m_usrc_Invoice.m_InvoiceData.AddOnDI == null)
                    {
                        this.m_usrc_Invoice.m_InvoiceData.AddOnDI = new DocInvoice_AddOn();
                    }
                    this.m_usrc_Invoice.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                    Program.usrc_FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_Invoice.m_ShopABC, this.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
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
            SetBackGroundColor();
            SetDocInvoiceOrDocPoformaInvoice();
            SetFinancialYears();
            if (LayoutChanged!=null)
            {
                LayoutChanged();
            }
        }

        private void SetBackGroundColor()
        {
            if (IsDocInvoice)
            {
                this.BackColor = Colors.DocInvoice.BackColor;
            }
            else
            {
                this.BackColor = Colors.DocProformaInvoice.BackColor;
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

                                    xnav.ChildDialog = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(myOrg.myOrg_Office_list[0].Office_Data_ID_v.v, xnav);
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

                            if (m_usrc_Invoice != null)
                            {
                                if (m_usrc_Invoice.DBtcn != null)
                                {
                                    m_usrc_Invoice.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
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
            if (m_usrc_Invoice != null)
            {
                if (m_usrc_Invoice.DBtcn != null)
                {
                    m_usrc_Invoice.Set_eShopsMode(Properties.Settings.Default.eShopsInUse, xnav);
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

                Program.usrc_FVI_SLO1.FursD_ElectronicDeviceID = Properties.Settings.Default.ElectronicDevice_ID;
            }

            if (Program.b_FVI_SLO)
            {
                if (f_Atom_FVI_SLO_RealEstateBP.Get_Atom_FVI_SLO_RealEstateBP_ID(Main_Form, ref Program.Atom_FVI_SLO_RealEstateBP_ID, 1))
                {
                }
            }

            LogFile.LogFile.WriteDEBUG("usrc_Document.cs:Init():before this.m_usrc_InvoiceMan.Init(xnav)!");

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
                                this.m_usrc_Invoice.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                                if (Program.usrc_FVI_SLO1.Check_InvoiceNotConfirmedAtFURS(this.m_usrc_Invoice.m_ShopABC, this.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_Invoice.m_InvoiceData.AddOnDPI))
                                {
                                    this.SetDocument(xnav);
                                }
                                //Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_InvoiceMan.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
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
            if (lRowsCount > 0)
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
                                                                return true;

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




        private bool getWorkPeriod(long myOrganisation_Person_ID, ref long xAtom_WorkPeriod_ID)
        {
            string Err = null;
            if (GlobalData.GetWorkPeriod(myOrganisation_Person_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
            {
                xAtom_WorkPeriod_ID = GlobalData.Atom_WorkPeriod_ID;
                return true;
            }
            else
            {
                xAtom_WorkPeriod_ID = -1;
                GlobalData.Atom_WorkPeriod_ID = -1;
                return false;
            }
        }

        public bool call_Edit_myOrganisationPerson(Form parentform, long myOrganisation_Person_ID, ref bool Changed, ref long myOrganisation_Person_ID_new)
        {
            Navigation xnav = new Navigation(null);
            xnav.m_eButtons = Navigation.eButtons.OkCancel;
            Form_myOrg_Person_Edit frm_myOrgPerEdit = new Form_myOrg_Person_Edit(1, xnav);
            frm_myOrgPerEdit.TopMost = parentform.TopMost;
            frm_myOrgPerEdit.Show(parentform);
            return true;
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

                if (this.loginControl1.Login(xnav, getWorkPeriod))
                {
                    //myStartup.eNextStep++;
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
                long myOrganisation_Person_first_ID = f_myOrganisation_Person.First_ID();
                if (myOrganisation_Person_first_ID >= 0)
                {
                    if (Program.bFirstTimeInstallation)
                    {
                        if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
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
                                if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
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
                            if (GlobalData.GetWorkPeriod(myOrganisation_Person_first_ID, f_Atom_WorkPeriod.sWorkPeriod, "Šiht", Properties.Settings.Default.ElectronicDevice_ID, null, DateTime.Now, null, ref Err))
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
