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
        public enum e_NewDocument { New_Empty, New_Copy_Of_SameDocType, New_Copy_To_Another_DocType,UNKNOWN}

        usrc_InvoiceMan m_usrc_InvoiceMan = null;
        public e_NewDocument eNewDocumentResult = e_NewDocument.UNKNOWN;
        public int FinancialYear = -1;

        public Form_NewDocument(usrc_InvoiceMan xusrc_InvoiceMan)
        {
            InitializeComponent();
            m_usrc_InvoiceMan = xusrc_InvoiceMan;
            string sdraft = "";
            string sNumber = m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString();
            string sInvoiceNumber = null;
            int ItemsCount = m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.ItemsCount(m_usrc_InvoiceMan.DocInvoice);
            if (m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.bDraft)
            {
                sdraft = lng.s_Draft.s;
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-"+ m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.DraftNumber.ToString()
                                   + " " + lng.s_Total.s + " = " + m_usrc_InvoiceMan.m_usrc_Invoice.lbl_Sum.Text + ")";
            }
            else
            {
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString()
                +" " +lng.s_Total.s + " = " + m_usrc_InvoiceMan.m_usrc_Invoice.lbl_Sum.Text + ")";
            }

            if (m_usrc_InvoiceMan.IsDocInvoice)
            {
                lng.s_New_Empty_Invoice.Text(this.btn_New_Empty);
            }
            else if (m_usrc_InvoiceMan.IsDocProformaInvoice)
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
                this.usrc_New_Copy_of_Same_DocType1.Init(m_usrc_InvoiceMan.DocInvoice, sInvoiceNumber);
                this.usrc_New_Copy_of_Another_DocType1.Init(m_usrc_InvoiceMan.DocInvoice, sInvoiceNumber);
            }
            usrc_Currency1.Init(GlobalData.BaseCurrency);
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
    }
}
