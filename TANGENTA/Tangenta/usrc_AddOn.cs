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

namespace Tangenta
{
    public partial class usrc_AddOn : UserControl
    {
        internal usrc_Invoice m_usrc_Invoice = null;

        private bool IsDocInvoice
        {
            get
            {
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.IsDocInvoice;
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
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.IsDocProformaInvoice;
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

        public void Init(usrc_Invoice x_usrc_Invoice)
        {
            m_usrc_Invoice = x_usrc_Invoice;
        }
        private void btn_Notice_Click(object sender, EventArgs e)
        {
            if (IsDocInvoice)
            {
                Get_DocInvoice_AddOn(m_usrc_Invoice.AddOnDI);
            }
            else if (IsDocProformaInvoice)
            {
                Get_DocProformaInvoice_AddOn(m_usrc_Invoice.AddOnDPI);
            }
            //Form_Notice frm_notice = new Form_Notice(this);
            //frm_notice.ShowDialog();
        }

        public bool Get_DocInvoice_AddOn(DocInvoice_AddOn x_DocInvoice_AddOn)
        {
            Form_DocInvoice_AddOn payment_frm = new Form_DocInvoice_AddOn(x_DocInvoice_AddOn, false, this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public bool Get_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn m_DocProformaInvoice_AddOn)
        {
            Form_DocProformaInvoice_AddOn payment_frm = new Form_DocProformaInvoice_AddOn(m_DocProformaInvoice_AddOn, false, this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                Show(m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID);
                return true;
            }
            return false;
        }

        internal void Show(long ID)
        {
            if (IsDocInvoice)
            {
                if (m_usrc_Invoice.AddOnDI.Get(ID))
                {
                    DisplayAddOn();
                }
            }
            else if (IsDocProformaInvoice)
            {
                if (m_usrc_Invoice.AddOnDPI.Get(ID))
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
                if (m_usrc_Invoice.AddOnDI.m_IssueDate != null)
                {
                    txt += lngRPM.s_ProformaInvoice_IssueDate.s + ":" + m_usrc_Invoice.AddOnDI.m_IssueDate.Date.ToString() + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDI.m_MethodOfPayment != null)
                {
                    string txtMethodOfPayment = lngRPM.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(m_usrc_Invoice.AddOnDI.m_MethodOfPayment.eType).s;
                    switch (m_usrc_Invoice.AddOnDI.m_MethodOfPayment.eType)
                    {
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            txtMethodOfPayment += " [" + m_usrc_Invoice.AddOnDI.m_MethodOfPayment.BankAccount + "] " + m_usrc_Invoice.AddOnDI.m_MethodOfPayment.BankName;
                            break;

                    }
                    txt += txtMethodOfPayment + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDI.m_TermsOfPayment != null)
                {
                    string txtTermsOfPayment = lngRPM.s_TermsOfPayment.s + ":" + m_usrc_Invoice.AddOnDI.m_TermsOfPayment.Description;
                    txt += txtTermsOfPayment + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDI.m_PaymentDeadline != null)
                {
                    string txtTermsOfPayment = lngRPM.s_Payment_Deadline.s + ":" + m_usrc_Invoice.AddOnDI.m_PaymentDeadline.Date.ToString();
                    txt += txtTermsOfPayment + "\r\n";
                }

                this.txt_Notice.Text = txt;
            }
            else if (IsDocProformaInvoice)
            {
                if (m_usrc_Invoice.AddOnDPI.m_IssueDate != null)
                {
                    txt += lngRPM.s_ProformaInvoice_IssueDate.s + ":" + m_usrc_Invoice.AddOnDPI.m_IssueDate.Date.ToString() + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDPI.m_Duration != null)
                {
                    string txtValidity = lngRPM.s_ProformaInvoice_Validity.s + ":";
                    switch (m_usrc_Invoice.AddOnDPI.m_Duration.type)
                    {
                        case 0:
                            txtValidity += lngRPM.s_Number_Of_Months.s + " = " + m_usrc_Invoice.AddOnDPI.m_Duration.length.ToString();
                            break;
                        case 1:
                            txtValidity += lngRPM.s_Number_Of_Days + " = " + m_usrc_Invoice.AddOnDPI.m_Duration.length.ToString();
                            break;
                        case 2:
                            if (m_usrc_Invoice.AddOnDPI.m_IssueDate != null)
                            {
                                DateTime dtValidUntil = m_usrc_Invoice.AddOnDPI.m_IssueDate.Date.AddDays(Convert.ToInt32(m_usrc_Invoice.AddOnDPI.m_Duration.length));
                                txtValidity += lngRPM.s_Valid_Until.s + dtValidUntil.ToString();
                            }
                            break;

                    }
                    txt += txtValidity + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDPI.m_MethodOfPayment != null)
                {
                    string txtMethodOfPayment = lngRPM.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(m_usrc_Invoice.AddOnDPI.m_MethodOfPayment.eType).s;
                    switch (m_usrc_Invoice.AddOnDPI.m_MethodOfPayment.eType)
                    {
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            txtMethodOfPayment += " [" + m_usrc_Invoice.AddOnDPI.m_MethodOfPayment.BankAccount + "] " + m_usrc_Invoice.AddOnDPI.m_MethodOfPayment.BankName;
                            break;

                    }
                    txt += txtMethodOfPayment + "\r\n";
                }
                if (m_usrc_Invoice.AddOnDPI.m_TermsOfPayment != null)
                {
                    string txtTermsOfPayment = lngRPM.s_TermsOfPayment.s + ":" + m_usrc_Invoice.AddOnDPI.m_TermsOfPayment.Description;
                    txt += txtTermsOfPayment + "\r\n";
                }
                this.txt_Notice.Text = txt;
            }
        }
    }
}
