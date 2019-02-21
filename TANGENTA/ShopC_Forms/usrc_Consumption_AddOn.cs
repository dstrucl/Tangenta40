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

            Get_Consumption_AddOn(false);
        }

        public bool Get_Consumption_AddOn(bool xbPrint)
        {
             return Get_Consumption_AddOn(ConsM.ConsE.MyConsumptionData.AddOnConsumption, xbPrint);
        }
        
    
        private bool Get_Consumption_AddOn(ConsumptionAddOn x_OwnUse_AddOn, bool xbPrint)
        {
            Form_Consumption_AddOn OwnUseAddOn_frm = new Form_Consumption_AddOn(x_OwnUse_AddOn, xbPrint, this);
            if (OwnUseAddOn_frm.ShowDialog() == DialogResult.OK)
            {
                Show(ConsM.ConsE.CurrentCons.Doc_ID);
                return true;
            }
            return false;
        }

        public void Show(ID ID)
        {
            if (ConsM.ConsE.MyConsumptionData.AddOnConsumption.Get(ID))
            {
                DisplayAddOn();
            }
        }

        private void DisplayAddOn()
        {
            string txt = "";
           
                if (ConsM.ConsE.MyConsumptionData.AddOnConsumption.MyIssueDate != null)
                {
                    txt += lng.s_IssueDate.s + ":" + ConsM.ConsE.MyConsumptionData.AddOnConsumption.MyIssueDate.Date.Date.ToShortDateString() + "\r\n";
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

        public bool Check_Consumption_AddOn(ConsumptionAddOn addOnConsumption)
        {
            ltext ltMsg = null;
            if (addOnConsumption.Completed(ref ltMsg))
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
