﻿#region LICENSE 
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

namespace Tangenta
{
    public partial class usrc_InvoiceMan : UserControl
    {
        internal bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;
        Form m_pparent = null;
        public List<Tangenta.usrc_Invoice.InvoiceType> List_InvoiceType = new List<Tangenta.usrc_Invoice.InvoiceType>();
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_DocInvoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_DocProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();
        private string m_DocInvoice = Program.const_DocInvoice;

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


        public usrc_InvoiceMan()
        {
            InitializeComponent();
            lngRPM.s_btn_New.Text(btn_New);
            lngRPM.s_Year.Text(lbl_FinancialYear);
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

        internal bool Initialise(Form pparent)
        {
            m_pparent = pparent;
            return m_usrc_Invoice.Initialise(this);
        }

        internal bool Init(NavigationButtons.Navigation xnav)
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

            InvoiceType_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_Invoice.s, Tangenta.usrc_Invoice.enum_Invoice.TaxInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocInvoice)");
            List_InvoiceType.Add(InvoiceType_DocInvoice);

            InvoiceType_DocProformaInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_DocProformaInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.ProformaInvoice);

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before List_InvoiceType.Add(InvoiceType_DocProformaInvoice);");

            List_InvoiceType.Add(InvoiceType_DocProformaInvoice);
            this.cmb_InvoiceType.DataSource = null;
            this.cmb_InvoiceType.DataSource = List_InvoiceType;
            this.cmb_InvoiceType.DisplayMember = "InvoiceType_Text";
            this.cmb_InvoiceType.ValueMember = "eInvoiceType";
            switch (this.m_usrc_Invoice.eInvoiceType)
            {
                case usrc_Invoice.enum_Invoice.TaxInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 0;
                    break;
                case usrc_Invoice.enum_Invoice.ProformaInvoice:
                    this.cmb_InvoiceType.SelectedIndex = 1;
                    break;
            }


            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before SetFinancialYears()");

            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            int Default_FinancialYear = Properties.Settings.Default.FinancialYear;
            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref dt_FinancialYears,IsDocInvoice,IsDocProformaInvoice,ref Default_FinancialYear))
            {
                Properties.Settings.Default.FinancialYear = Default_FinancialYear;
                Properties.Settings.Default.Save();
                cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_InvoiceMan:Init:GlobalData.SetFinancialYears Failed!");
                return false;
            }



            splitContainer1.Panel2Collapsed = false;

            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:Init():before SetDocument(xnav)");

            bool bRes = SetDocument(xnav);

            this.cmb_InvoiceType.SelectedIndexChanged += new System.EventHandler(this.cmb_InvoiceType_SelectedIndexChanged);

            Program.Cursor_Arrow();
            return bRes;
        }


        private bool SetDocument(NavigationButtons.Navigation xnav)
        {
            LogFile.LogFile.WriteDEBUG("usrc_InvoiceMan.cs:SetDocument():before mthis.m_usrc_InvoiceTable.Init(..)");

            int iRowsCount = this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, true, Properties.Settings.Default.FinancialYear);

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
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
                }
            }
        }





        private void m_usrc_Invoice_DocInvoiceSaved(long DocInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,true,false, Properties.Settings.Default.FinancialYear);
        }

        private void m_usrc_Invoice_DocProformaInvoiceSaved(long DocProformaInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, true, false, Properties.Settings.Default.FinancialYear);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(long DocInvoice_ID,bool bInitialise)
        {
            if (DocInvoice_ID >= 0)
            {
                if (m_usrc_Invoice.DoCurrent(DocInvoice_ID))
                {
                }
            }
        }


        private void btn_New_Click(object sender, EventArgs e)
        {
            Form_NewDocument frm_new = new Form_NewDocument(this);
            frm_new.ShowDialog(this);
            switch (frm_new.eNewDocumentResult)
            {
                case Form_NewDocument.e_NewDocument.New_Empty:
                    New_Empty_Doc();
                    break;

                case Form_NewDocument.e_NewDocument.New_Copy_Of_SameDocType:
                    New_Copy_Of_SameDocType(frm_new.FinancialYear);
                    break;
                case Form_NewDocument.e_NewDocument.New_Copy_To_Another_DocType:
                    New_Copy_To_Another_DocType(frm_new.FinancialYear);
                    break;
            }
        }

        private void New_Empty_Doc()
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

                    m_usrc_Invoice.SetNewDraft(eInvType, FinancialYear);
                    DateTime dtStart = DateTime.Now;
                    DateTime dtEnd = DateTime.Now;
                    m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                    m_usrc_InvoiceTable.Init(eInvType, true, false, Properties.Settings.Default.FinancialYear);
                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            Program.Cursor_Arrow();
        }


        private void New_Copy_To_Another_DocType(int xFinancialYear)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    //System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    //int FinancialYear = (int)drv.Row.ItemArray[0];

                    m_usrc_Invoice.SetNewDraft(eInvType, xFinancialYear);
                    DateTime dtStart = DateTime.Now;
                    DateTime dtEnd = DateTime.Now;
                    m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                    m_usrc_InvoiceTable.Init(eInvType, true, false, Properties.Settings.Default.FinancialYear);

                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            Program.Cursor_Arrow();
        }

        private void New_Copy_Of_SameDocType(int xFinancialYear)
        {
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    //System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
                    //int FinancialYear = (int)drv.Row.ItemArray[0];
                    List<object> xShopC_Data_Item_List = new List<object>();
                    if (this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xShopC_Data_Item_List))
                    {
                        DataTable xdt_ShopB_Items = new DataTable();
                        if (this.m_usrc_Invoice.m_ShopABC.Read_ShopB_Price_Item_Table(this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopB_Items))
                        {
                            DataTable xdt_ShopA_Items = new DataTable();
                            if (ShopA_dbfunc.dbfunc.Read_ShopA_Price_Item_Table(DocInvoice, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref xdt_ShopA_Items))
                            {
                                m_usrc_Invoice.SetNewDraft(eInvType, xFinancialYear);
                                DateTime dtStart = DateTime.Now;
                                DateTime dtEnd = DateTime.Now;
                                m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
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
                                                m_usrc_InvoiceTable.Init(eInvType, true, false, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear);
                                                cmb_FinancialYear.SelectedIndexChanged  -= Cmb_FinancialYear_SelectedIndexChanged;
                                                GlobalData.SelectFinancialYear(cmb_FinancialYear, this.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear);
                                                cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                                                if (this.m_usrc_Invoice.m_usrc_ShopC != null)
                                                {
                                                    this.m_usrc_Invoice.m_usrc_ShopC.usrc_ItemList.Paint_Current_Group();
                                                }
                                                break;
                                            case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_NO_ITEM_IN_DB:
                                                LogFile.Error.Show("ERROR:usrc_InvoiceMan:New_Copy_Of_SameDocType:ERROR_NO_ITEM_IN_DB ");
                                                break;
                                            case TangentaDB.Basket.eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_DB:
                                                break;
                                        }
                                    }
                                }
                            }
                        }
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

        private void m_usrc_Invoice_Customer_Person_Changed(long Customer_Person_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false,Properties.Settings.Default.FinancialYear);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(long Customer_Org_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
        }

        private void m_usrc_Invoice_Load(object sender, EventArgs e)
        {

        }




        public long myOrganisation_Person_ID { 
            get
            { if (this.m_usrc_Invoice!=null)
                {
                    return this.m_usrc_Invoice.myOrganisation_Person_ID;
                }
            else
            {
                return -1;
            }
            }
            }

        private void m_usrc_Invoice_PriceListChanged()
        {
            NavigationButtons.Navigation nav_Invoice_PriceListChanged = new NavigationButtons.Navigation();
            nav_Invoice_PriceListChanged.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.Init(nav_Invoice_PriceListChanged);
        }

        private void btn_SelectPanels_Click(object sender, EventArgs e)
        {
            Form_SelectPanels frm_select_panels = new Form_SelectPanels(this);
            frm_select_panels.ShowDialog(this);
        }

        internal void Activate_dgvx_XInvoice_SelectionChanged()
        {
            this.m_usrc_InvoiceTable.Activate_dgvx_XInvoice_SelectionChanged();
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
            Program.RunAs = DocInvoice;
            bool bRes = SetDocument(null);
            Program.Cursor_Arrow();
            if (this.IsDocInvoice)
            {
                if (Program.b_FVI_SLO)
                {
                    if (this.m_usrc_Invoice.m_InvoiceData.AddOnDI==null)
                    {
                        this.m_usrc_Invoice.m_InvoiceData.AddOnDI = new DocInvoice_AddOn();
                    }
                    this.m_usrc_Invoice.m_InvoiceData.AddOnDI.b_FVI_SLO = Program.b_FVI_SLO;
                    Program.usrc_FVI_SLO1.Check_SalesBookInvoice(this.m_usrc_Invoice.m_ShopABC, this.m_usrc_Invoice.m_InvoiceData.AddOnDI, this.m_usrc_Invoice.m_InvoiceData.AddOnDPI);
                }
            }
        }
    }
}
