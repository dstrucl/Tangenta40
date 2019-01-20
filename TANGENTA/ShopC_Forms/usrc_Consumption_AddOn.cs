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

namespace ShopC_Forms
{
    public partial class usrc_Consumption_AddOn : UserControl
    {
        internal ConsumptionMan ConsM = null;
        internal Control parent_Control = null;


        private bool IsWriteOff
        {
            get
            {
                if (ConsM != null)
                {
                    return ConsM.IsWriteOff;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsDocOwnUse
        {
            get
            {
                if (ConsM != null)
                {
                    return ConsM.IsOwnUse;
                }
                else
                {
                    return false;
                }
            }
        }

        public usrc_Consumption_AddOn()
        {
            InitializeComponent();
        }


        public void Init(Control xparent,ConsumptionMan x_consM)
        {
            parent_Control = xparent;
            ConsM = x_consM;
        }

   

        private void btn_Notice_Click(object sender, EventArgs e)
        {

            Get_Doc_AddOn(false);
        }

        public bool Get_Doc_AddOn(bool xbPrint)
        {
            if (IsWriteOff)
            {
                return Get_WriteOff_AddOn(ConsM.ConsE.MyConsumptionData.AddOnWriteOff, xbPrint);
            }
            else if (IsDocOwnUse)
            {
                return Get_OwnUse_AddOn(ConsM.ConsE.MyConsumptionData.AddOnOwnUse, xbPrint);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:usrc_AddOn:Get_Doc_AddOn: Unknown document type!");
                return false;
            }
        }
        
        private bool Get_WriteOff_AddOn(WriteOffAddOn x_WriteOffAddOn, bool xbPrint)
        {
            Form_WriteOff_AddOn payment_frm = new Form_WriteOff_AddOn(x_WriteOffAddOn, xbPrint, this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                Show(ConsM.ConsE.m_CurrentConsumption.Doc_ID);
                return true;
            }
            return false;
        }

        private bool Get_OwnUse_AddOn(OwnUseAddOn x_OwnUse_AddOn, bool xbPrint)
        {
            Form_OwnUse_AddOn OwnUseAddOn_frm = new Form_OwnUse_AddOn(x_OwnUse_AddOn, xbPrint, this);
            if (OwnUseAddOn_frm.ShowDialog() == DialogResult.OK)
            {
                Show(ConsM.ConsE.m_CurrentConsumption.Doc_ID);
                return true;
            }
            return false;
        }

        public void Show(ID ID)
        {
            if (IsWriteOff)
            {
                if (ConsM.ConsE.MyConsumptionData.AddOnWriteOff.Get(ID))
                {
                    DisplayAddOn();
                }
            }
            else if (IsDocOwnUse)
            {
                if (ConsM.ConsE.MyConsumptionData.AddOnOwnUse.Get(ID))
                {
                    DisplayAddOn();
                }
            }
        }

        private void DisplayAddOn()
        {
            string txt = "";
            if (IsWriteOff)
            {
                if (ConsM.ConsE.MyConsumptionData.AddOnWriteOff.MyIssueDate != null)
                {
                    txt += lng.s_IssueDate.s + ":" + ConsM.ConsE.MyConsumptionData.AddOnWriteOff.MyIssueDate.Date.ToShortDateString() + "\r\n";
                }
                //if (ConsM.ConsE.InvoiceData.AddOnDI.MyMethodOfPayment_DI != null)
                //{
                //    string txtMethodOfPayment = lng.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(ConsM.DocE.InvoiceData.AddOnDI.MyMethodOfPayment_DI.eType).s;
                //    switch (ConsM.DocE.InvoiceData.AddOnDI.MyMethodOfPayment_DI.eType)
                //    {
                //        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                //            txtMethodOfPayment += " [" + ConsM.DocE.InvoiceData.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount + "] " + ConsM.DocE.InvoiceData.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName;
                //            break;

                //    }
                //    txt += txtMethodOfPayment + "\r\n";
                //}
                //if (ConsM.DocE.InvoiceData.AddOnDI.MyTermsOfPayment != null)
                //{
                //    string txtTermsOfPayment = lng.s_TermsOfPayment.s + ":" + ConsM.DocE.InvoiceData.AddOnDI.MyTermsOfPayment.Description;
                //    txt += txtTermsOfPayment + "\r\n";
                //}
                //if (ConsM.DocE.InvoiceData.AddOnDI.MyPaymentDeadline != null)
                //{
                //    string txtTermsOfPayment = lng.s_Payment_Deadline.s + ":" + ConsM.DocE.InvoiceData.AddOnDI.MyPaymentDeadline.Date.ToShortDateString();
                //    txt += txtTermsOfPayment + "\r\n";
                //}

                //if (ConsM.DocE.InvoiceData.AddOnDI.m_NoticeText != null)
                //{
                //    txt += ConsM.DocE.InvoiceData.AddOnDI.m_NoticeText + "\r\n";
                //}

                this.txt_Notice.Text = txt;
            }
            else if (IsDocOwnUse)
            {
                if (ConsM.ConsE.MyConsumptionData.AddOnOwnUse.MyIssueDate != null)
                {
                    txt += lng.s_IssueDate.s + ":" + ConsM.ConsE.MyConsumptionData.AddOnOwnUse.MyIssueDate.Date.Date.ToShortDateString() + "\r\n";
                }
                //if (ConsM.DocE.InvoiceData.AddOnDPI.m_Duration != null)
                //{
                //    string txtValidity = lng.s_ProformaInvoice_Validity.s + ":";
                //    switch (ConsM.DocE.InvoiceData.AddOnDPI.m_Duration.type)
                //    {
                //        case 0:
                //            txtValidity += lng.s_Number_Of_Months.s + " = " + ConsM.DocE.InvoiceData.AddOnDPI.m_Duration.length.ToString();
                //            break;
                //        case 1:
                //            txtValidity += lng.s_Number_Of_Days + " = " + ConsM.DocE.InvoiceData.AddOnDPI.m_Duration.length.ToString();
                //            break;
                //        case 2:
                //            if (ConsM.DocE.InvoiceData.AddOnDPI.m_IssueDate != null)
                //            {
                //                DateTime dtValidUntil = ConsM.DocE.InvoiceData.AddOnDPI.m_IssueDate.Date.AddDays(Convert.ToInt32(ConsM.DocE.InvoiceData.AddOnDPI.m_Duration.length));
                //                txtValidity += lng.s_Valid_Until.s + dtValidUntil.ToShortDateString();
                //            }
                //            break;

                //    }
                //    txt += txtValidity + "\r\n";
                //}
                //if (ConsM.DocE.InvoiceData.AddOnDPI.m_MethodOfPayment_DPI != null)
                //{
                //    string txtMethodOfPayment = lng.s_MethodOfPayment.s + ":" + GlobalData.Get_sPaymentType_ltext(ConsM.DocE.InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.eType).s;
                //    switch (ConsM.DocE.InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.eType)
                //    {
                //        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                //            txtMethodOfPayment += " [" + ConsM.DocE.InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount + "] " + ConsM.DocE.InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankName;
                //            break;

                //    }
                //    txt += txtMethodOfPayment + "\r\n";
                //}
                //if (ConsM.DocE.InvoiceData.AddOnDPI.m_TermsOfPayment != null)
                //{
                //    string txtTermsOfPayment = lng.s_TermsOfPayment.s + ":" + ConsM.DocE.InvoiceData.AddOnDPI.m_TermsOfPayment.Description;
                //    txt += txtTermsOfPayment + "\r\n";
                //}

                //if (ConsM.DocE.InvoiceData.AddOnDPI.m_NoticeText != null)
                //{
                //    txt += ConsM.DocE.InvoiceData.AddOnDPI.m_NoticeText + "\r\n";
                //}
                //this.txt_Notice.Text = txt;
            }
        }

        public bool Check_Consumption_AddOn(WriteOffAddOn addOnWriteOff)
        {
            ltext ltMsg = null;
            if (addOnWriteOff.Completed(ref ltMsg))
            {
                return true;
                //if (addOnDI.IsCashPayment)
                //{
                //    Form_Consumption_PaymentCash dlg_cash = new Form_Consumption_PaymentCash(this.ConsM.DocE.GrossSum);
                //    if (dlg_cash.ShowDialog() == DialogResult.OK)
                //    {
                //        addOnDI.Cash_AmountReceived = dlg_cash.Cash_AmountReceived;
                //        addOnDI.Cash_ToReturn = dlg_cash.Cash_ToReturn;
                //        return true;
                //    }
                //}
                //else
                //{
                //    return true;
                //}
            }
            else
            {

            }
            return false;
        }

        public bool Check_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn addOnDPI)
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
