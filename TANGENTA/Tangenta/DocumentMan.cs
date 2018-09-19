using Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace Tangenta
{
    public class DocumentMan
    {
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
    }
}
