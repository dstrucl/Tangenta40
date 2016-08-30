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

namespace Tangenta
{
    public partial class usrc_InvoiceMan : UserControl
    {
        internal bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;
        Form m_pparent = null;
        public List<Tangenta.usrc_Invoice.InvoiceType> List_InvoiceType = new List<Tangenta.usrc_Invoice.InvoiceType>();
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_Invoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_Invoice_From_DocInvoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_DocInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();

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
            Program.Cursor_Wait();
            InvoiceType_Invoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_Invoice.s, Tangenta.usrc_Invoice.enum_Invoice.Invoice);
            List_InvoiceType.Add(InvoiceType_Invoice);
            InvoiceType_Invoice_From_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_Invoice_From_DocInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.DocInvoice);
            List_InvoiceType.Add(InvoiceType_Invoice_From_DocInvoice);
            InvoiceType_DocInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_DocInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.DocInvoice);
            List_InvoiceType.Add(InvoiceType_DocInvoice);
            this.cmb_InvoiceType.DataSource = null;
            this.cmb_InvoiceType.DataSource = List_InvoiceType;
            this.cmb_InvoiceType.DisplayMember = "InvoiceType_Text";
            this.cmb_InvoiceType.ValueMember = "eInvoiceType";
            this.cmb_InvoiceType.SelectedItem = this.m_usrc_Invoice.eInvoiceType;
            SetFinancialYears();



            splitContainer1.Panel2Collapsed = false;
            string Err = null;
            int iRowsCount = this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,false,true,Properties.Settings.Default.FinancialYear);
            //                if (iRowsCount == 0)
            //                {
            if (!m_usrc_Invoice.Init(xnav, - 1))
                {
                    Program.Cursor_Arrow();
                    return false;
                }
            //}
            SetInitialMode();
            SetMode(Mode);
            Program.Cursor_Arrow();
            return true;

        }

        private bool SetFinancialYears()
        {
            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            string sql = "select distinct FinancialYear from DocInvoice";
            string Err = null;
            dt_FinancialYears.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_FinancialYears,sql,ref Err))
            {
                int CurrentYear = DateTime.Now.Year;
                if (!FinancialYearExist(dt_FinancialYears, CurrentYear))
                {
                    DataRow dr = dt_FinancialYears.NewRow();
                    dr["FinancialYear"] = CurrentYear;
                    dt_FinancialYears.Rows.Add(dr);
                }
                cmb_FinancialYear.DataSource = dt_FinancialYears;
                cmb_FinancialYear.DisplayMember = "FinancialYear";
                cmb_FinancialYear.ValueMember = "FinancialYear";
                if (Properties.Settings.Default.FinancialYear==0)
                {
                    Properties.Settings.Default.FinancialYear = DateTime.Now.Year;
                    Properties.Settings.Default.Save();
                }
                SelectFinancialYear(Properties.Settings.Default.FinancialYear);
                //CheckFinancialYear()
                cmb_FinancialYear.SelectedIndexChanged += Cmb_FinancialYear_SelectedIndexChanged;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Man:SetFinancialYears:Err="+Err);
                return false;
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
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
                }
            }
        }


        private void SelectFinancialYear(int financialYear)
        {
            
            foreach (object oItem in cmb_FinancialYear.Items)
            {
                if (oItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView)oItem;
                    if (drv["FinancialYear"] is int)
                    {
                        if (((int)drv["FinancialYear"])== financialYear)
                        {
                            cmb_FinancialYear.SelectedItem = oItem;
                        }
                    }
                }
            }
                    
        }

        private bool FinancialYearExist(DataTable dt, int Year)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if ((int)dr["FinancialYear"] == Year)
                {
                    return true;
                }
            }
            return false;
        }


        private void m_usrc_Invoice_DocInvoiceSaved(long DocInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Shops_and_InvoiceTable);
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,false,false, Properties.Settings.Default.FinancialYear);
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
            Program.Cursor_Wait();
            if (cmb_InvoiceType.SelectedItem is Tangenta.usrc_Invoice.InvoiceType)
            {
                Tangenta.usrc_Invoice.InvoiceType xInvoiceType = (Tangenta.usrc_Invoice.InvoiceType)cmb_InvoiceType.SelectedItem;
                Tangenta.usrc_Invoice.enum_Invoice eInvType = xInvoiceType.eInvoiceType;
                if (cmb_FinancialYear.SelectedItem is System.Data.DataRowView)
                {
                    System.Data.DataRowView drv = (System.Data.DataRowView) cmb_FinancialYear.SelectedItem;
                    int FinancialYear = (int)drv.Row.ItemArray[0]; 

                    m_usrc_Invoice.SetNewDraft(eInvType, FinancialYear);
                    DateTime dtStart = DateTime.Now;
                    DateTime dtEnd = DateTime.Now;
                    m_usrc_InvoiceTable.SetTimeSpanParam(usrc_InvoiceTable.eMode.All, dtStart, dtEnd);
                    m_usrc_InvoiceTable.Init(eInvType,true,false,Properties.Settings.Default.FinancialYear);
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
    }
}
