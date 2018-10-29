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
using TangentaDB;
using LanguageControl;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class usrc_AddOn : UserControl
    {
        internal DocumentMan docM = null;
        internal Control parent_Control = null;


        private bool IsDocInvoice
        {
            get
            {
                if (docM != null)
                {
                    return docM.IsDocInvoice;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsDocProformaInvoice
        {
            get
            {
                if (docM != null)
                {
                    return docM.IsDocProformaInvoice;
                }
                else
                {
                    return false;
                }
            }
        }

        public usrc_AddOn()
        {
            InitializeComponent();
        }


        public void Init(Control xparent,DocumentMan x_docM)
        {
            parent_Control = xparent;
            docM = x_docM;
        }

   

        private void btn_Notice_Click(object sender, EventArgs e)
        {

            Get_Doc_AddOn(false);
        }

        public bool Get_Doc_AddOn(bool xbPrint)
        {
            if (IsDocInvoice)
            {
                return Get_DocInvoice_AddOn(docM.DocE.m_InvoiceData.AddOnDI, xbPrint);
            }
            else if (IsDocProformaInvoice)
            {
                return Get_DocProformaInvoice_AddOn(docM.DocE.m_InvoiceData.AddOnDPI, xbPrint);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_AddOn:Get_Doc_AddOn: Unknown document type!");
                return false;
            }
        }
        
        private bool Get_DocInvoice_AddOn(DocInvoice_AddOn x_DocInvoice_AddOn, bool xbPrint)
        {
            Form_DocInvoice_AddOn payment_frm = new Form_DocInvoice_AddOn(x_DocInvoice_AddOn, xbPrint, this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                Show(docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                return true;
            }
            return false;
        }

        private bool Get_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn m_DocProformaInvoice_AddOn, bool xbPrint)
        {
            Form_DocProformaInvoice_AddOn payment_frm = new Form_DocProformaInvoice_AddOn(m_DocProformaInvoice_AddOn, xbPrint, this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                Show(docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID);
                return true;
            }
            return false;
        }

        internal void Show(ID ID)
        {
            if (IsDocInvoice)
            {
                if (docM.DocE.m_InvoiceData.AddOnDI.Get(ID))
                {
                    DisplayAddOn();
                }
            }
            else if (IsDocProformaInvoice)
            {
                if (docM.DocE.m_InvoiceData.AddOnDPI.Get(ID))
                {
                    DisplayAddOn();
                }
            }
        }

        private void DisplayAddOn()
        {
            string txt = "";
            if (IsDocInvoice)
            {
                if (docM.DocE.m_InvoiceData.AddOnDI.m_IssueDate != null)
                {
                    txt += lng.s_Invoice_IssueDate.s + ":" + docM.DocE.m_InvoiceData.AddOnDI.m_IssueDate.Date.ToShortDateString() + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDI.m_MethodOfPayment_DI != null)
                {
                    string txtMethodOfPayment = lng.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(docM.DocE.m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.eType).s;
                    switch (docM.DocE.m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.eType)
                    {
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            txtMethodOfPayment += " [" + docM.DocE.m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount + "] " + docM.DocE.m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName;
                            break;

                    }
                    txt += txtMethodOfPayment + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDI.m_TermsOfPayment != null)
                {
                    string txtTermsOfPayment = lng.s_TermsOfPayment.s + ":" + docM.DocE.m_InvoiceData.AddOnDI.m_TermsOfPayment.Description;
                    txt += txtTermsOfPayment + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDI.m_PaymentDeadline != null)
                {
                    string txtTermsOfPayment = lng.s_Payment_Deadline.s + ":" + docM.DocE.m_InvoiceData.AddOnDI.m_PaymentDeadline.Date.ToShortDateString();
                    txt += txtTermsOfPayment + "\r\n";
                }

                if (docM.DocE.m_InvoiceData.AddOnDI.m_NoticeText != null)
                {
                    txt += docM.DocE.m_InvoiceData.AddOnDI.m_NoticeText + "\r\n";
                }

                this.txt_Notice.Text = txt;
            }
            else if (IsDocProformaInvoice)
            {
                if (docM.DocE.m_InvoiceData.AddOnDPI.m_IssueDate != null)
                {
                    txt += lng.s_ProformaInvoice_IssueDate.s + ":" + docM.DocE.m_InvoiceData.AddOnDPI.m_IssueDate.Date.Date.ToShortDateString() + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDPI.m_Duration != null)
                {
                    string txtValidity = lng.s_ProformaInvoice_Validity.s + ":";
                    switch (docM.DocE.m_InvoiceData.AddOnDPI.m_Duration.type)
                    {
                        case 0:
                            txtValidity += lng.s_Number_Of_Months.s + " = " + docM.DocE.m_InvoiceData.AddOnDPI.m_Duration.length.ToString();
                            break;
                        case 1:
                            txtValidity += lng.s_Number_Of_Days + " = " + docM.DocE.m_InvoiceData.AddOnDPI.m_Duration.length.ToString();
                            break;
                        case 2:
                            if (docM.DocE.m_InvoiceData.AddOnDPI.m_IssueDate != null)
                            {
                                DateTime dtValidUntil = docM.DocE.m_InvoiceData.AddOnDPI.m_IssueDate.Date.AddDays(Convert.ToInt32(docM.DocE.m_InvoiceData.AddOnDPI.m_Duration.length));
                                txtValidity += lng.s_Valid_Until.s + dtValidUntil.ToShortDateString();
                            }
                            break;

                    }
                    txt += txtValidity + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI != null)
                {
                    string txtMethodOfPayment = lng.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(docM.DocE.m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.eType).s;
                    switch (docM.DocE.m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.eType)
                    {
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            txtMethodOfPayment += " [" + docM.DocE.m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount + "] " + docM.DocE.m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankName;
                            break;

                    }
                    txt += txtMethodOfPayment + "\r\n";
                }
                if (docM.DocE.m_InvoiceData.AddOnDPI.m_TermsOfPayment != null)
                {
                    string txtTermsOfPayment = lng.s_TermsOfPayment.s + ":" + docM.DocE.m_InvoiceData.AddOnDPI.m_TermsOfPayment.Description;
                    txt += txtTermsOfPayment + "\r\n";
                }

                if (docM.DocE.m_InvoiceData.AddOnDPI.m_NoticeText != null)
                {
                    txt += docM.DocE.m_InvoiceData.AddOnDPI.m_NoticeText + "\r\n";
                }
                this.txt_Notice.Text = txt;
            }
        }

        internal bool Check_DocInvoice_AddOn(DocInvoice_AddOn addOnDI)
        {
            ltext ltMsg = null;
            if (addOnDI.Completed(ref ltMsg))
            {
                if (addOnDI.IsCashPayment)
                {
                    Form_DocInvoice_PaymentCash dlg_cash = new Form_DocInvoice_PaymentCash(this.docM.DocE.GrossSum);
                    if (dlg_cash.ShowDialog() == DialogResult.OK)
                    {
                        addOnDI.Cash_AmountReceived = dlg_cash.Cash_AmountReceived;
                        addOnDI.Cash_ToReturn = dlg_cash.Cash_ToReturn;
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {

            }
            return false;
        }

        internal bool Check_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn addOnDPI)
        {
            ltext ltMsg = null;
            if (addOnDPI.Completed(ref ltMsg))
            {
                return true;
            }
            else
            {

            }
            return false;
        }

    }
}
