﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;

namespace Tangenta
{
    public partial class Form_Receipt_Preview : Form
    {
        InvoiceDB m_InvoiceDB = null;
        long ProformaInvoice_ID = -1;
        long myCompany_Person_ID = -1;
        public usrc_Payment.ePaymentType m_ePaymentType = usrc_Payment.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_Receipt_Preview( long xProformaInvoice_ID, InvoiceDB x_InvoiceDB, long xmyCompany_Person_ID)
        {
            InitializeComponent();

            ProformaInvoice_ID = xProformaInvoice_ID;
            m_InvoiceDB = x_InvoiceDB;
            myCompany_Person_ID = xmyCompany_Person_ID;
            this.Text = lngRPM.s_PaymentAndPrint.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            if (m_InvoiceDB.m_CurrentInvoice.Exist)
            {
                if (m_InvoiceDB.m_CurrentInvoice.bDraft)
                {
                    m_usrc_Payment.Visible = true;
                    m_usrc_PrintExistingInvoice.Visible = false;
                }
                else
                {
                    m_usrc_PrintExistingInvoice.Top = m_usrc_Payment.Top;
                    m_usrc_PrintExistingInvoice.Left = m_usrc_Payment.Left;
                    m_usrc_PrintExistingInvoice.Width = m_usrc_Payment.Width;
                    m_usrc_PrintExistingInvoice.Height = m_usrc_Payment.Height;
                    m_usrc_PrintExistingInvoice.Anchor = m_usrc_Payment.Anchor;
                    m_usrc_Payment.Visible = false;
                    m_usrc_PrintExistingInvoice.Visible = true;
                }
            }
        }

        private void Print(usrc_Payment.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            if (ePaymentType == usrc_Payment.ePaymentType.CASH)
            {
                m_usrc_Print.Print_Receipt(ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                m_usrc_Print.Print_Receipt(ePaymentType, sPaymentMethod, null, null, issue_time);
            }
        }

        private void usrc_Payment_DoPrint(usrc_Payment.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            long ProformaInvoice_ID = -1;
            int xNumberInFinancialYear = -1;
            if (this.m_InvoiceDB.m_CurrentInvoice.Save(ref ProformaInvoice_ID, m_ePaymentType, m_sPaymentMethod, m_sAmountReceived, m_sToReturn, ref xNumberInFinancialYear))
            {
                m_usrc_Print.NumberInFinancialYear = xNumberInFinancialYear;
                if (m_InvoiceDB.m_CurrentInvoice.SetInvoiceTime(issue_time))
                {
                    
                    if (Program.b_FVI_SLO)
                    {
                        Program.usrc_FVI_SLO1.Get_FVI_SLO_Confirmation(GetPaymentTypeString(ePaymentType), sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                        Print(ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                    }
                    else
                    {
                        Print(ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                    }
                    m_ePaymentType = ePaymentType;
                    m_sPaymentMethod = sPaymentMethod;
                    m_sAmountReceived = sAmountReceived;
                    m_sToReturn = sToReturn;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                }
            }
        }

        private string GetPaymentTypeString(usrc_Payment.ePaymentType ePaymentType)
        {
          switch (ePaymentType)
            {
                case usrc_Payment.ePaymentType.CASH:
                    return "cash";
                case usrc_Payment.ePaymentType.PAYMENT_CARD:
                    return "payment_card";
                case usrc_Payment.ePaymentType.NONE:
                    return "none";
                case usrc_Payment.ePaymentType.ALLREADY_PAID:
                    return "allready_paid";
                    break;
            }
            return null;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void m_usrc_PrintExistingInvoice_DoPrint_Existing_Invoice(DateTime_v issue_time)
        {
            m_usrc_Print.Print_Receipt(usrc_Payment.ePaymentType.NONE, null, null, null, issue_time);
        }

        private void Form_Receipt_Preview_Load(object sender, EventArgs e)
        {
            if (m_usrc_Print.Init(ProformaInvoice_ID, m_InvoiceDB, myCompany_Person_ID))
            {
                if ((m_InvoiceDB.m_CurrentInvoice.bDraft))
                {
                    if (m_usrc_Payment.Init(m_InvoiceDB.m_CurrentInvoice.Invoice_ID, m_usrc_Print.Get_CurrencyD_DecimalPlaces(), m_usrc_Print.GrossSum))
                    {
                        //splitContainer1.Panel1Collapsed = true;
                        return;
                    }
                    else
                    {
                        this.Close();
                        DialogResult = DialogResult.Abort;
                    }
                }
                else
                {
                    string sInvoiceNumber = m_InvoiceDB.m_CurrentInvoice.FinancialYear.ToString() + "/" + m_InvoiceDB.m_CurrentInvoice.NumberInFinancialYear.ToString();
                    if (m_usrc_PrintExistingInvoice.Init(m_InvoiceDB.m_CurrentInvoice.ProformaInvoice_ID, sInvoiceNumber))
                    {
                        //splitContainer1.Panel1Collapsed = true;
                        return;
                    }
                }
            }

        }
    }
}
