using CodeTables;
using DBConnectionControl40;
using DBTypes;
using Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace ShopC_Forms
{
    public class ConsumptionMan
    {

        public static Form MainForm = null;

        public LoginControl.LMOUser m_LMOUser = null;
        //public static Door doorFor1 = null;
        private int m_FinancialYear = 0;
        public int FinancialYear
        {
            get
            {
                return m_FinancialYear;
            }
        }

        private UserControl usrc_ConsumptionMan = null;

        public delegate void delegate_Control_SetMode(ConsumptionMan.eMode mode);
        private delegate_Control_SetMode delegate_control_SetMode = null;

        public delegate int delegate_Control_TableOfDocuments_Init(ConsumptionMan xdocM,
                          bool bNew,
                          bool bInitialise_usrc_Invoice,
                          int iFinancialYear,
                          ID Doc_ID_To_show);

        public delegate_Control_TableOfDocuments_Init Delegate_control_TableOfDocuments_Init = null;


        public delegate bool delegate_Control_DocumentEditor_Init(ID xDocument_ID);

        public delegate_Control_DocumentEditor_Init Delegate_Control_DocumentEditor_Init = null;

        public delegate void delegate_Control_SetInitialMode();
        public delegate_Control_SetInitialMode Delegate_Control_SetInitialMode = null;


        private ConsumptionEditor m_ConsE = null;
        public ConsumptionEditor ConsE
        {
            get
            {
                return m_ConsE;
            }
            set
            {
                m_ConsE = value;
            }
        }

        public List<ConsumptionType> List_ConsumptionType = new List<ConsumptionType>();
        public ConsumptionType Consumption_WriteOff = null;
        public ConsumptionType Consumption_OwnUse = null;
        public ConsumptionType Consumption_All = null;


        //public SettingsUserValues mSettingsUserValues = null;

        //public LoginControl.LMOUser m_LMOUser = null;

        //public Door door = null;

        public int timer_Login_MultiUsers_Countdown = 100;

        internal CtrlLayout cl_btn_New = null;
        internal CtrlLayout cl_cmb_InvoiceType = null;
        internal CtrlLayout cl_lbl_FinancialYear = null;

        public bool Customer_Changed = false;

        public enum eMode { Shops, InvoiceTable, Shops_and_InvoiceTable };
        public eMode Mode = eMode.Shops_and_InvoiceTable;

        //public List<DocType> List_DocType = new List<DocType>();
        //public DocType DocType_DocInvoice = null;
        //public DocType DocType_DocProformaInvoice = null;
        public DataTable dt_FinancialYears = new DataTable();


        private string m_ConsumptionTyp = null;

        public string ConsumptionTyp
        {
            get
            {
                //if (m_DocTyp == null)
                //{
                //    if (!this.DesignMode) LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:property DocTyp: DocTyp is not defined (m_DocInvoice = null)!");
                //}
                return m_ConsumptionTyp;
            }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_ConsumptionAll) || s.Equals(GlobalData.const_ConsumptionWriteOff) || s.Equals(GlobalData.const_ConsumptionOwnUse))
                {
                    m_ConsumptionTyp = s;
                }
                else
                {
                    if (s != null)
                    {
                        if (s.Length > 0)
                        {
                            LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:property string DocTyp: DocTyp = " + s + " is not implemented!");
                        }
                    }
                    else
                    {
                       LogFile.Error.Show("ERROR:Tangenta:usrc_ConsumptionMan:property string DocTyp: DocTyp  value ==  null");
                    }
                }
            }
        }

        public bool IsWriteOff
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionWriteOff); }
        }

        public bool IsOwnUse
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionOwnUse); }
        }

        public bool IsAll
        {
            get
            { return ConsumptionTyp.Equals(GlobalData.const_ConsumptionAll); }
        }

        public ConsumptionMan(delegate_Control_SetMode xdelegate_control_SetMode,
                          delegate_Control_TableOfDocuments_Init xdelegate_control_TableOfDocuments_Init,
                          delegate_Control_DocumentEditor_Init xdelegate_Control_DocumentEditor_Init,
                          delegate_Control_SetInitialMode xdelegate_Control_SetInitialMode,
                          LoginControl.LMOUser xlmoUser,
                          int iFinancialYear,
                          string consumptiontype)
        {
            this.m_LMOUser = xlmoUser;
            this.m_FinancialYear = iFinancialYear;
            this.m_ConsumptionTyp = consumptiontype;

            delegate_control_SetMode = xdelegate_control_SetMode;
            Delegate_control_TableOfDocuments_Init = xdelegate_control_TableOfDocuments_Init;
            Delegate_Control_DocumentEditor_Init = xdelegate_Control_DocumentEditor_Init;
            Delegate_Control_SetInitialMode = xdelegate_Control_SetInitialMode;
            ConsE = new ConsumptionEditor(this);
        }

        public static string GetInvoiceNumber(bool bDraft, int FinancialYear, int NumberInFinancialYear, int DraftNumber)
        {
            string sNumber = null;
            if (bDraft)
            {
                sNumber = FinancialYear.ToString() + "/" + lng.s_Draft.s + " " + DraftNumber.ToString();
            }
            else
            {
                sNumber = FinancialYear.ToString() + "/" + NumberInFinancialYear.ToString();
            }
            return sNumber;
        }

        public void SetMode(ConsumptionMan.eMode mode)
        {
            Mode = mode;
            if (mode == ConsumptionMan.eMode.Shops)
            {
                //TangentaProperties.Properties.Settings.Default.eManagerMode = "Shops";
            }
            else if (mode == ConsumptionMan.eMode.InvoiceTable)
            {
                //TangentaProperties.Properties.Settings.Default.eManagerMode = "InvoiceTable";
            }
            else
            {
                //TangentaProperties.Properties.Settings.Default.eManagerMode = "Shops&InvoiceTable";
            }
            //TangentaProperties.Properties.Settings.Default.Save();
            delegate_control_SetMode(Mode);
        }

        internal void Cursor_Arrow()
        {
            if (usrc_ConsumptionMan != null)
            {
                Form parent_frm = Global.f.GetParentForm(usrc_ConsumptionMan);
                if (parent_frm != null)
                {
                    parent_frm.Cursor = Cursors.Arrow;
                }
            }
        }

        public bool SetDocument(ID xCurrent_Consumption_ID, Transaction transaction)
        {

            int iRowsCount = Delegate_control_TableOfDocuments_Init(this, false, true, FinancialYear, null);


            if (!Delegate_Control_DocumentEditor_Init(xCurrent_Consumption_ID))
            {
                Cursor_Arrow();
                return false;
            }

            SetInitialMode();

            SetMode(Mode);
            return true;

        }

        public void SetInitialMode()
        {
            string sManagerMode = TangentaProperties.Properties.Settings.Default.eManagerMode;
            if ((sManagerMode.Contains("Shops")) && (sManagerMode.Contains("InvoiceTable")))
            {
                Mode = ConsumptionMan.eMode.Shops_and_InvoiceTable;
            }
            else if (sManagerMode.Equals("Shops"))
            {
                Mode = ConsumptionMan.eMode.Shops;
            }
            else if (sManagerMode.Equals("InvoiceTable"))
            {
                Mode = ConsumptionMan.eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ConsumptionMan:SetInitialMode:TangentaProperties.Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
                Mode = ConsumptionMan.eMode.Shops_and_InvoiceTable;
            }

            Delegate_Control_SetInitialMode();
        }

       


       

        public void DocInvoiceSaved(ID docInvoice_id)
        {
            //SetMode(ConsumptionMan.eMode.Shops_and_InvoiceTable);

            ID Doc_ID_to_show_v = null;
            if (ID.Validate(docInvoice_id))
            {
                Doc_ID_to_show_v = new ID(docInvoice_id);
            }
            this.Delegate_control_TableOfDocuments_Init(this, false, false, FinancialYear, Doc_ID_to_show_v);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }

        public void DocProformaInvoiceSaved(ID docProformaInvoice_id)
        {
           // SetMode(ConsumptionMan.eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show = null;
            if (ID.Validate(docProformaInvoice_id))
            {
                Doc_ID_to_show = new ID(docProformaInvoice_id);
            }
            this.Delegate_control_TableOfDocuments_Init(this, false, false, FinancialYear, Doc_ID_to_show);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }
    }
}
