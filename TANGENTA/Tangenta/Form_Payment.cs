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
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Payment : Form
    {
        public InvoiceData m_InvoiceData = null;
        public GlobalData.ePaymentType m_ePaymentType = GlobalData.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_Payment(InvoiceData xInvoiceData)
        {
            InitializeComponent();

            m_InvoiceData = xInvoiceData;
            this.Text = lngRPM.s_PaymentAndPrint.s;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Payment_Load(object sender, EventArgs e)
        {
            if (Program.usrc_Printer1.Init(m_InvoiceData))
            {
                if ((m_InvoiceData.m_ShopABC.m_CurrentInvoice.bDraft))
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
