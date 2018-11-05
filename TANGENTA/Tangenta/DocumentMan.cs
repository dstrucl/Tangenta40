using DBConnectionControl40;
using Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace Tangenta
{
    public class DocumentMan
    {
        public delegate void delegate_Control_SetMode(DocumentMan.eMode mode);
        private delegate_Control_SetMode delegate_control_SetMode = null;

        public delegate int delegate_Control_TableOfDocuments_Init(DocumentMan xdocM,
                          bool bNew,
                          bool bInitialise_usrc_Invoice,
                          int iFinancialYear,
                          ID Doc_ID_To_show);

        public delegate_Control_TableOfDocuments_Init Delegate_control_TableOfDocuments_Init = null;


        public delegate bool delegate_Control_DocumentEditor_Init(ID xDocument_ID);

        public delegate_Control_DocumentEditor_Init Delegate_Control_DocumentEditor_Init = null;

        public delegate void delegate_Control_SetInitialMode();
        public delegate_Control_SetInitialMode Delegate_Control_SetInitialMode = null;



        internal DocumentEditor DocE = null;

        internal SettingsUserValues mSettingsUserValues = null;

        internal LoginControl.LMOUser m_LMOUser = null;

        internal Door door = null;
      
        internal int timer_Login_MultiUsers_Countdown = 100;

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


        private string m_DocTyp = null;

        public string DocTyp
        {
            get
            {
                //if (m_DocTyp == null)
                //{
                //    if (!this.DesignMode) LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:property DocTyp: DocTyp is not defined (m_DocInvoice = null)!");
                //}
                return m_DocTyp;
            }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    m_DocTyp = s;
                    if (DocE!=null)
                    {
                        if (DocE.m_ShopABC!=null)
                        {
                            DocE.m_ShopABC.DocTyp = s;
                        }
                    }
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

        public DocumentMan(delegate_Control_SetMode xdelegate_control_SetMode,
                          delegate_Control_TableOfDocuments_Init xdelegate_control_TableOfDocuments_Init,
                          delegate_Control_DocumentEditor_Init xdelegate_Control_DocumentEditor_Init,
                          delegate_Control_SetInitialMode xdelegate_Control_SetInitialMode
            )
        {
            delegate_control_SetMode = xdelegate_control_SetMode;
            Delegate_control_TableOfDocuments_Init = xdelegate_control_TableOfDocuments_Init;
            Delegate_Control_DocumentEditor_Init = xdelegate_Control_DocumentEditor_Init;
            Delegate_Control_SetInitialMode = xdelegate_Control_SetInitialMode;
            DocE = new DocumentEditor(this);
        }

        public void SetMode(DocumentMan.eMode mode)
        {
            Mode = mode;
            if (mode == DocumentMan.eMode.Shops)
            {
                Properties.Settings.Default.eManagerMode = "Shops";
            }
            else if (mode == DocumentMan.eMode.InvoiceTable)
            {
                Properties.Settings.Default.eManagerMode = "InvoiceTable";
            }
            else
            {
                Properties.Settings.Default.eManagerMode = "Shops&InvoiceTable";
            }
            Properties.Settings.Default.Save();
            delegate_control_SetMode(Mode);
        }

        internal bool SetDocument(ID xCurrent_Doc_ID )
        {

            int iRowsCount = Delegate_control_TableOfDocuments_Init(this, false, true, this.mSettingsUserValues.FinancialYear, null);


            if (!Delegate_Control_DocumentEditor_Init(xCurrent_Doc_ID))
            {
                Program.Cursor_Arrow();
                return false;
            }

            SetInitialMode();

            SetMode(Mode);
            return true;

        }

        public void SetInitialMode()
        {
            string sManagerMode = Properties.Settings.Default.eManagerMode;
            if ((sManagerMode.Contains("Shops")) && (sManagerMode.Contains("InvoiceTable")))
            {
                Mode = DocumentMan.eMode.Shops_and_InvoiceTable;
            }
            else if (sManagerMode.Equals("Shops"))
            {
                Mode = DocumentMan.eMode.Shops;
            }
            else if (sManagerMode.Equals("InvoiceTable"))
            {
                Mode = DocumentMan.eMode.InvoiceTable;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_DocumentMan:SetInitialMode:Properties.Settings.Default.eManagerMode may have only these values:\"Shops\",\"InvoiceTable\" or \"Shops@InvoiceTable\"");
                Mode = DocumentMan.eMode.Shops_and_InvoiceTable;
            }

            Delegate_Control_SetInitialMode();
        }

        internal void Cmb_FinancialYear_SelectedIndexChanged(ComboBox cmb_FinancialYear)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)cmb_FinancialYear.SelectedItem;
            if (drv["FinancialYear"] is int)
            {
                int iFinancialYear = (int)drv["FinancialYear"];
                if (iFinancialYear != mSettingsUserValues.FinancialYear)
                {
                    mSettingsUserValues.FinancialYear = iFinancialYear;
                    SetFinancialYears(cmb_FinancialYear);
                    Delegate_control_TableOfDocuments_Init(this, false, false, mSettingsUserValues.FinancialYear, null);
                }
            }
        }


        private bool SetFinancialYears(ComboBox cmb_FinancialYear)
        {
            int Default_FinancialYear = mSettingsUserValues.FinancialYear;
            if (GlobalData.SetFinancialYears(cmb_FinancialYear, ref dt_FinancialYears, IsDocInvoice, IsDocProformaInvoice, ref Default_FinancialYear))
            {
                mSettingsUserValues.FinancialYear = Default_FinancialYear;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentMan:Init:GlobalData.SetFinancialYears Failed!");
                return false;
            }
        }

        internal void DocInvoiceSaved(ID docInvoice_id)
        {
            SetMode(DocumentMan.eMode.Shops_and_InvoiceTable);

            ID Doc_ID_to_show_v = null;
            if (ID.Validate(docInvoice_id))
            {
                Doc_ID_to_show_v = new ID(docInvoice_id);
            }
            this.Delegate_control_TableOfDocuments_Init(this, false, false, mSettingsUserValues.FinancialYear, Doc_ID_to_show_v);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }

        internal void DocProformaInvoiceSaved(ID docProformaInvoice_id)
        {
            SetMode(DocumentMan.eMode.Shops_and_InvoiceTable);
            ID Doc_ID_to_show = null;
            if (ID.Validate(docProformaInvoice_id))
            {
                Doc_ID_to_show = new ID(docProformaInvoice_id);
            }
            this.Delegate_control_TableOfDocuments_Init(this, false, false, mSettingsUserValues.FinancialYear, Doc_ID_to_show);
            m_LMOUser.ReloadAdministratorsAndUserManagers();
        }
    }
}
