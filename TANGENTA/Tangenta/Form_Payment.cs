using System;
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
    public partial class Form_Payment : Form
    {
        public InvoiceData m_InvoiceData = null;
        public usrc_Payment.ePaymentType m_ePaymentType = usrc_Payment.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_Payment(InvoiceData xInvoiceData)
        {
            InitializeComponent();

            m_InvoiceData = xInvoiceData;
            this.Text = lngRPM.s_PaymentAndPrint.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
        }

        private void Print(usrc_Payment.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            if (ePaymentType == usrc_Payment.ePaymentType.CASH)
            {
                Program.usrc_Printer1.Print_Receipt(m_InvoiceData,ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Program.usrc_Printer1.Print_Receipt(m_InvoiceData,ePaymentType, sPaymentMethod, null, null, issue_time);
            }
        }

        private void usrc_Payment_DoPrint(usrc_Payment.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            long ProformaInvoice_ID = -1;
            int xNumberInFinancialYear = -1;
            if (m_InvoiceData.Save(ref ProformaInvoice_ID, m_ePaymentType, m_sPaymentMethod, m_sAmountReceived, m_sToReturn, ref xNumberInFinancialYear))
            {
                m_InvoiceData.Set_NumberInFinancialYear(xNumberInFinancialYear);

                if (m_InvoiceData.SetInvoiceTime(issue_time))
                {
                    
                    if (Program.b_FVI_SLO)
                    {
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



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Receipt_Preview_Load(object sender, EventArgs e)
        {
            if (Program.usrc_Printer1.Init(m_InvoiceData))
            {
                if ((m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.bDraft))
                {
                    if (m_usrc_Payment.Init(m_InvoiceData, Program.usrc_Printer1.Get_CurrencyD_DecimalPlaces(), m_InvoiceData.GrossSum))
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
                    LogFile.Error.Show("ERROR:Form_Payment:Not Draft!");
                }
            }
        }
    }
}
