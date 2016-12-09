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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_DocInvoice_Payment : Form
    {
        private string m_DocInvoice = null;
        public InvoiceData m_InvoiceData = null;
        public GlobalData.ePaymentType m_ePaymentType = GlobalData.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_DocInvoice_Payment(InvoiceData xInvoiceData, string xDocInvoice)
        {
            InitializeComponent();
            m_DocInvoice = xDocInvoice;
            m_InvoiceData = xInvoiceData;
            this.Text = lngRPM.s_PaymentOfInvoiceAndPrint.s;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Payment_Load(object sender, EventArgs e)
        {
            if (Program.usrc_TangentaPrint1.Init(m_InvoiceData, m_DocInvoice))
            {
                if ((m_InvoiceData.m_ShopABC.m_CurrentInvoice.bDraft))
                {
                    if (m_usrc_Payment.Init(m_InvoiceData, Program.usrc_TangentaPrint1.Get_CurrencyD_DecimalPlaces(), m_InvoiceData.GrossSum))
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

        private void m_usrc_Payment_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void m_usrc_Payment_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
