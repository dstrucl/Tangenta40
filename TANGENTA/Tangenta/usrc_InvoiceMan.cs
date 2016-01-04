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
        private bool Customer_Changed = false;

        public enum eMode { Items, ProformaInvoices, Items_and_ProformaInvoices };
        public eMode Mode = eMode.Items_and_ProformaInvoices;
        Form m_pparent = null;
        public List<Tangenta.usrc_Invoice.InvoiceType> List_InvoiceType = new List<Tangenta.usrc_Invoice.InvoiceType>();
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_Invoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_Invoice_From_ProformaInvoice = null;
        public Tangenta.usrc_Invoice.InvoiceType InvoiceType_ProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();

        public usrc_InvoiceMan()
        {
            InitializeComponent();
            lngRPM.s_btn_New.Text(btn_New);
            lngRPM.s_Year.Text(lbl_FinancialYear);
        }

        public void SetInitialMode()
        {
            Mode = eMode.Items_and_ProformaInvoices;
            if (m_usrc_Invoice.m_InvoiceDB!=null)
            {
                if (m_usrc_Invoice.m_InvoiceDB.m_CurrentInvoice!=null)
                {
                    if (m_usrc_Invoice.m_InvoiceDB.m_CurrentInvoice.bDraft)
                    {
                        Mode = eMode.Items;
                    }
                }
            }
        }

        public void SetMode(eMode mode)
        {
            Mode = mode;
            if (mode == eMode.Items)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
                this.rdb_Items.CheckedChanged -= new System.EventHandler(this.rdb_Items_CheckedChanged);
                this.rdb_Items.Checked = true;
                this.rdb_Items.CheckedChanged += new System.EventHandler(this.rdb_Items_CheckedChanged);
            }
            else if (mode == eMode.ProformaInvoices)
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
                this.rdb_ProformaInvoices.CheckedChanged -= new System.EventHandler(this.rdb_ProformaInvoices_CheckedChanged);
                this.rdb_ProformaInvoices.Checked = true;
                this.rdb_ProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ProformaInvoices_CheckedChanged);
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = false;
                this.rdb_ItemsAndProformaInvoices.CheckedChanged -= new System.EventHandler(this.rdb_ItemsAndProformaInvoices_CheckedChanged);
                this.rdb_ItemsAndProformaInvoices.Checked = true;
                this.rdb_ItemsAndProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ItemsAndProformaInvoices_CheckedChanged);
            }
        }

        internal bool Init(Form pparent)
        {
            Program.Cursor_Wait();
            m_pparent = pparent;
            InvoiceType_Invoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_Invoice.s, Tangenta.usrc_Invoice.enum_Invoice.Invoice);
            List_InvoiceType.Add(InvoiceType_Invoice);
            InvoiceType_Invoice_From_ProformaInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_Invoice_From_ProformaInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.ProformaInvoice);
            List_InvoiceType.Add(InvoiceType_Invoice_From_ProformaInvoice);
            InvoiceType_ProformaInvoice = new Tangenta.usrc_Invoice.InvoiceType(lngRPM.s_ProformaInvoice.s, Tangenta.usrc_Invoice.enum_Invoice.ProformaInvoice);
            List_InvoiceType.Add(InvoiceType_ProformaInvoice);
            this.cmb_InvoiceType.DataSource = null;
            this.cmb_InvoiceType.DataSource = List_InvoiceType;
            this.cmb_InvoiceType.DisplayMember = "InvoiceType_Text";
            this.cmb_InvoiceType.ValueMember = "eInvoiceType";
            this.cmb_InvoiceType.SelectedItem = this.m_usrc_Invoice.eInvoiceType;
            SetFinancialYears();



            splitContainer1.Panel2Collapsed = false;
            string Err = null;
            if (m_usrc_Invoice.Get_BaseCurrency(ref Err))
            {
                int iRowsCount = this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,false,Properties.Settings.Default.FinancialYear);
                if (iRowsCount == 0)
                {
                    if (!m_usrc_Invoice.Init(m_pparent, this,-1, true))
                    {
                        Program.Cursor_Arrow();
                        return false;
                    }
                }
                SetInitialMode();
                SetMode(Mode);
                this.rdb_Items.CheckedChanged += new System.EventHandler(this.rdb_Items_CheckedChanged);
                this.rdb_ItemsAndProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ItemsAndProformaInvoices_CheckedChanged);
                this.rdb_ProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ProformaInvoices_CheckedChanged);
                Program.Cursor_Arrow();
                return true;
            }
            else
            {
                Program.Cursor_Arrow();
                LogFile.Error.Show("ERROR:usrc_InvoiceMan:Init:m_usrc_Invoice.Get_BaseCurrency:Err = " + Err);
                return false;
            }

        }

        private bool SetFinancialYears()
        {
            cmb_FinancialYear.SelectedIndexChanged -= Cmb_FinancialYear_SelectedIndexChanged;
            string sql = "select distinct FinancialYear from ProformaInvoice";
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
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, Properties.Settings.Default.FinancialYear);
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

        public xCurrency BaseCurrency
        {
            get { return m_usrc_Invoice.BaseCurrency; }
        }

        private void m_usrc_Invoice_ProformaInvoiceSaved(long ProformaInvoice_id)
        {
            splitContainer1.Panel2Collapsed = false;
            SetMode(eMode.Items_and_ProformaInvoices);
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType,false, Properties.Settings.Default.FinancialYear);
        }

        private void m_usrc_InvoiceTable_SelectedInvoiceChanged(long ProformaInvoice_ID,bool bInitialise)
        {
            if (ProformaInvoice_ID >= 0)
            {
                if (m_usrc_Invoice.Init(m_pparent, this, ProformaInvoice_ID, bInitialise))
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
                    m_usrc_InvoiceTable.Init(eInvType,true,Properties.Settings.Default.FinancialYear);
                }
                else
                {
                    Program.Cursor_Arrow();
                    LogFile.Error.Show("ERROR:usrc_InvoiceMan:btn_New_Click:cmb_FinancialYear.SelectedItem is not type of System.Data.DataRowView but is type of " + cmb_FinancialYear.SelectedItem.GetType().ToString());
                }
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Program.Cursor_Arrow();
        }

        private void rdb_Items_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Items.Checked)
            { 
                SetMode(eMode.Items);
            }
        }

        private void rdb_ItemsAndProformaInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ItemsAndProformaInvoices.Checked)
            {
                SetMode(eMode.Items_and_ProformaInvoices);
                if (Customer_Changed)
                {
                    Customer_Changed = false;
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,Properties.Settings.Default.FinancialYear);
                }
            }

        }

        private void rdb_ProformaInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ProformaInvoices.Checked)
            {
                SetMode(eMode.ProformaInvoices);
                if (Customer_Changed)
                {
                    Customer_Changed = false;
                    this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,Properties.Settings.Default.FinancialYear);
                }
            }

        }

        private void m_usrc_Invoice_Customer_Person_Changed(long Customer_Person_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false,Properties.Settings.Default.FinancialYear);
            }
        }

        private void m_usrc_Invoice_aa_Customer_Org_Changed(long Customer_Org_ID)
        {
            Customer_Changed = true;
            if (this.m_usrc_InvoiceTable.Visible)
            {
                Customer_Changed = false;
                this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, Properties.Settings.Default.FinancialYear);
            }
        }

        private void m_usrc_Invoice_Storno(bool bStorno)
        {
            this.m_usrc_InvoiceTable.Init(m_usrc_Invoice.eInvoiceType, false, Properties.Settings.Default.FinancialYear);
        }

        private void m_usrc_Invoice_Load(object sender, EventArgs e)
        {

        }




        public long myCompany_Person_ID { 
            get
            { if (this.m_usrc_Invoice!=null)
                {
                    return this.m_usrc_Invoice.myCompany_Person_ID;
                }
            else
            {
                return -1;
            }
            }
            }

        private void m_usrc_Invoice_PriceListChanged()
        {
            this.Init(m_pparent);
        }

    }
}
