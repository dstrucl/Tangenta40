using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace Tangenta
{
    public class DocumentEditor
    {
        public enum emode
        {
            view_eDocumentType,
            edit_eDocumentType
        }

        public SettingsUserValues mSettingsUserValues = null;

        public ID Atom_Currency_ID = null;

        public LoginControl.LMOUser m_LMOUser = null;

        public Door door = null;


        public emode m_mode = emode.view_eDocumentType;

        public DBTablesAndColumnNames DBtcn = null;

        public TangentaDB.ShopABC m_ShopABC = null;


        public InvoiceData m_InvoiceData = null;

        public ID myOrganisation_Person_id
        {
            get
            {
                if (myOrg.m_myOrg_Office != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Person != null)
                    {
                        return myOrg.m_myOrg_Office.m_myOrg_Person.ID;
                    }
                }
                return null;
            }
        }




        internal decimal GrossSum = 0;
        internal decimal NetSum = 0;
        internal StaticLib.TaxSum TaxSum = null;


        internal bool chk_Storno_CanBe_ManualyChanged = true;

        private string m_DocTyp = null;

        public string DocTyp
        {
            get
            {
                if (m_DocTyp == null)
                {
                    //LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property DocTyp: DocTyp is not defined (m_DocInvoice = null)!");
                }
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
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property string DocTyp: DocTyp = " + s + " is not implemented!");
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Tangenta:usrc_DocumentEditor:property string DocTyp: DocTyp  value ==  null");
                    }

                }

                if (this.m_ShopABC != null)
                {
                    this.m_ShopABC.DocTyp = DocTyp;
                }
                //if (this.m_usrc_ShopB1366x768 != null)
                //{
                //    this.m_usrc_ShopB1366x768.DocTyp = DocTyp;
                //}
                //if (this.m_usrc_ShopC1366x768 != null)
                //{
                //    this.m_usrc_ShopC1366x768.DocTyp = DocTyp;
                //}
            }
        }

    }
}
