using HUDCMS;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_NewDocument : Form
    {
        private HUDCMS.HelpWizzardTagDC tagDCTop = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_Invoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_DocType_ProformaInvoice = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_EmptyDB_false = null;
        private HUDCMS.HelpWizzardTagDC tagDCBottom = null;

        internal HUDCMS.HelpWizzardTagDC[] TagDCs = null;


        public enum e_NewDocument { New_Empty, New_Copy_Of_SameDocType, New_Copy_To_Another_DocType,UNKNOWN}

        private usrc_DocumentMan m_usrc_DocumentMan = null;
        public e_NewDocument eNewDocumentResult = e_NewDocument.UNKNOWN;
        public int FinancialYear = -1;

        private Form_NewDocument_WizzardForHelp frm_NewDocument_WizzardForHelp = null;

        public Form_NewDocument(usrc_DocumentMan xusrc_DocumentMan)
        {
            InitializeComponent();
            m_usrc_DocumentMan = xusrc_DocumentMan;
            string sdraft = "";
            string sNumber = m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-" + m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString();
            string sInvoiceNumber = null;
            int ItemsCount = m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.ItemsCount(m_usrc_DocumentMan.DocInvoice);
            if (m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.bDraft)
            {
                sdraft = lng.s_Draft.s;
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-"+ m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.DraftNumber.ToString()
                                   + " " + lng.s_Total.s + " = " + m_usrc_DocumentMan.m_usrc_DocumentEditor.lbl_Sum.Text + ")";
            }
            else
            {
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-" + m_usrc_DocumentMan.m_usrc_DocumentEditor.m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString()
                +" " +lng.s_Total.s + " = " + m_usrc_DocumentMan.m_usrc_DocumentEditor.lbl_Sum.Text + ")";
            }

            if (m_usrc_DocumentMan.IsDocInvoice)
            {
                lng.s_New_Empty_Invoice.Text(this.btn_New_Empty);
            }
            else if (m_usrc_DocumentMan.IsDocProformaInvoice)
            {
                lng.s_New_Empty_ProformaInvoice.Text(this.btn_New_Empty);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_NewDocument.cs:Form_NewDocument: Unknown DocInvoice type!");
            }
            if (Program.OperationMode.MultiCurrency)
            {
                usrc_Currency1.Enabled = true;
            }
            else
            {
                usrc_Currency1.Enabled = false;
            }

            if (ItemsCount == 0 )
            {
                this.usrc_New_Copy_of_Same_DocType1.Visible = false;
                this.usrc_New_Copy_of_Another_DocType1.Visible = false;
                this.btn_Cancel.Top = this.btn_New_Empty.Bottom + 20;
                this.Height = this.btn_Cancel.Bottom + 50;
            }
            else
            {
                this.usrc_New_Copy_of_Same_DocType1.Visible = true;
                this.usrc_New_Copy_of_Another_DocType1.Visible = true;
                this.usrc_New_Copy_of_Same_DocType1.Init(m_usrc_DocumentMan.DocInvoice, sInvoiceNumber);
                this.usrc_New_Copy_of_Another_DocType1.Init(m_usrc_DocumentMan.DocInvoice, sInvoiceNumber);
            }
            usrc_Currency1.Init(GlobalData.BaseCurrency);
            SetNewFormTag();
        }

        private void btn_New_Empty_Click(object sender, EventArgs e)
        {
            eNewDocumentResult = e_NewDocument.New_Empty;
            this.Close();
            DialogResult = DialogResult.OK;
        }



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_New_Copy_of_Same_DocType1_Set_New_Copy_of_Same_DocType(string DocInvoice, int ixFinancialYear)
        {
            eNewDocumentResult = e_NewDocument.New_Copy_Of_SameDocType;
            FinancialYear = ixFinancialYear;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_New_Copy_of_Another_DocType1_Set_New_Copy_of_Another_DocType(string DocInvoice, int ixFinancialYear)
        {
            eNewDocumentResult = e_NewDocument.New_Copy_To_Another_DocType;
            FinancialYear = ixFinancialYear;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void SetNewFormTag()
        {

            tagDCTop = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "Top", "", null, null);

            tagDC_DocType_Invoice = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "DocType", "", "enum", "Invoice");
            tagDC_DocType_ProformaInvoice = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "DocType", "", "enum", "ProformaInvoice");

            tagDC_EmptyDB_true = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "DBEmpty", "", "bool", "true");
            tagDC_EmptyDB_false = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "DBEmpty", "", "bool", "false");


            tagDCBottom = new HelpWizzardTagDC(HUDCMS.HelpWizzardTagDC.eTip.ABOUT, "Bottom", "", null, null);


            TagDCs = new HUDCMS.HelpWizzardTagDC[] {
            tagDCTop,
            tagDC_DocType_Invoice,
            tagDC_DocType_ProformaInvoice,
            tagDC_EmptyDB_true,
            tagDC_EmptyDB_false,
            tagDCBottom
            };

            HUDCMS.HelpWizzardTag hlpwizTag = new HelpWizzardTag(TagDCs, null,null);
            hlpwizTag.DefaultControlWidth = this.Width;
            hlpwizTag.DefaultControlHeight = this.Height;



            long numberOfAll = -1;
            string[] sTagConditions = null;

            string sxmlfilesuffix = "";
            string sNewTag = GetStringTag(ref numberOfAll, ref sTagConditions, ref sxmlfilesuffix);

            hlpwizTag.FileSuffix = sNewTag;
            hlpwizTag.XmlFileSuffix = sxmlfilesuffix;
            hlpwizTag.ShowWizzard = HelpWizzardShow;

            this.Tag = hlpwizTag;
        }

        internal string GetStringTag(ref long numberOfAll, ref string[] sTagConditions, ref string sXMLFiletag)
        {
            string sNewTag = "_";
            sXMLFiletag = "_";
            List<string> tag_conditions = new List<string>();
            if (this.m_usrc_DocumentMan.IsDocInvoice)
            {
                numberOfAll = fs.NumberOInvoicesInDatabase();
                sNewTag += "i";
                sXMLFiletag += "i";
                tag_conditions.Add(tagDC_DocType_Invoice.NamedCondition);
            }
            else if (this.m_usrc_DocumentMan.IsDocProformaInvoice)
            {
                numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
                sNewTag += "p";
                sXMLFiletag += "p";
                tag_conditions.Add(tagDC_DocType_ProformaInvoice.NamedCondition);
            }

            if (numberOfAll < 0)
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_Document:SetNewFormTag:  numberOfAll invoices or proforma invoices < 0 !");
            }
            else if (numberOfAll == 0)
            {
                sNewTag += "Z";
                sXMLFiletag += "Z";
                tag_conditions.Add(tagDC_EmptyDB_true.NamedCondition);
            }
            else if (numberOfAll > 0)
            {
                sNewTag += "N";
                sXMLFiletag += "N";
                tag_conditions.Add(tagDC_EmptyDB_false.NamedCondition);
            }

            int iconditions_count = tag_conditions.Count;
            sTagConditions = new string[iconditions_count];
            for (int i = 0; i < iconditions_count; i++)
            {
                sTagConditions[i] = tag_conditions[i];
            }
            return sNewTag;
        }

        public void HelpWizzardShow(Control ctrl, MyControl root_ctrl, string xstyleFile)
        {
            if (frm_NewDocument_WizzardForHelp != null)
            {
                if (frm_NewDocument_WizzardForHelp.IsDisposed)
                {
                    frm_NewDocument_WizzardForHelp = null;
                }

            }
            if (frm_NewDocument_WizzardForHelp == null)
            {
                frm_NewDocument_WizzardForHelp = new Form_NewDocument_WizzardForHelp(ctrl, root_ctrl, xstyleFile);
                frm_NewDocument_WizzardForHelp.Owner = this;
            }
            frm_NewDocument_WizzardForHelp.Show();
        }
    }
}
