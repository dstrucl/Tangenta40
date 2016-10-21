using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_NewDocument : Form
    {
        public enum e_NewDocument { New_Empty, New_Copy_Of_SameDocType, New_Copy_To_Another_DocType,UNKNOWN}

        usrc_InvoiceMan m_usrc_InvoiceMan = null;
        public e_NewDocument eNewDocumentResult = e_NewDocument.UNKNOWN;

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
                sdraft = lngRPM.s_Draft.s;
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-"+ m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.DraftNumber.ToString()
                                   + " " + lngRPM.s_Total.s + " = " + m_usrc_InvoiceMan.m_usrc_Invoice.lbl_Sum.Text + ")";
            }
            else
            {
                sInvoiceNumber = "(" + sdraft + " št.:" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.FinancialYear.ToString() + "-" + m_usrc_InvoiceMan.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.NumberInFinancialYear.ToString()
                +" " +lngRPM.s_Total.s + " = " + m_usrc_InvoiceMan.m_usrc_Invoice.lbl_Sum.Text + ")";
            }

            if (m_usrc_InvoiceMan.IsDocInvoice)
            {
                lngRPM.s_New_Empty_Invoice.Text(this.btn_New_Empty);
                lngRPM.s_New_Copy_ThisInvoice_ToNewOne.Text(this.btn_New_Copy_Of_SameDocType);
                lngRPM.s_New_Copy_ThisInvoice_ToNewProformaInvoice.Text(this.btn_New_Copy_To_Another_DocType);
            }
            else if (m_usrc_InvoiceMan.IsDocProformaInvoice)
            {
                lngRPM.s_New_Empty_ProformaInvoice.Text(this.btn_New_Empty);
                lngRPM.s_New_Copy_ThisProformaInvoice_ToNewOne.Text(this.btn_New_Copy_Of_SameDocType);
                lngRPM.s_New_Copy_ThisProformaInvoice_ToInvoice.Text(this.btn_New_Copy_To_Another_DocType);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_NewDocument.cs:Form_NewDocument: Unknown DocInvoice type!");
            }
            if (ItemsCount == 0 )
            {
                btn_New_Copy_Of_SameDocType.Visible = false;
                btn_New_Copy_To_Another_DocType.Visible = false;
            }
            else
            {
                btn_New_Copy_Of_SameDocType.Text = btn_New_Copy_Of_SameDocType.Text.Replace("%s", sInvoiceNumber);
                btn_New_Copy_To_Another_DocType.Text = btn_New_Copy_To_Another_DocType.Text.Replace("%s", sInvoiceNumber);
            }
        }

        private void btn_New_Empty_Click(object sender, EventArgs e)
        {
            eNewDocumentResult = e_NewDocument.New_Empty;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_New_Copy_Of_SameDocType_Click(object sender, EventArgs e)
        {
            eNewDocumentResult = e_NewDocument.New_Copy_Of_SameDocType;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_New_Copy_To_Another_DocType_Click(object sender, EventArgs e)
        {
            eNewDocumentResult = e_NewDocument.New_Copy_To_Another_DocType;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
