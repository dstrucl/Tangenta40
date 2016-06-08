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
    public partial class Form_PrintExistingInvoice : Form
    {
        public InvoiceData m_InvoiceData = null;
        public GlobalData.ePaymentType m_ePaymentType = GlobalData.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_PrintExistingInvoice(InvoiceData xInvoiceData)
        {
            InitializeComponent();

            m_InvoiceData = xInvoiceData;
            this.Text = lngRPM.s_PaymentAndPrint.s;
            lngRPM.s_Printer.Text(lbl_Printer);
            this.lbl_PrinterNameValue.Text = Program.usrc_Printer1.PrinterName;
            this.usrc_PrintExistingInvoice1.Init(xInvoiceData, xInvoiceData.NumberInFinancialYear.ToString());
        }


        private void Form_Receipt_Preview_Load(object sender, EventArgs e)
        {
        }

        private void usrc_PrintExistingInvoice1_Cancel()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
