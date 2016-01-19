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
    public partial class Form_PrintExistingInvoice : Form
    {
        public InvoiceData m_InvoiceData = null;
        public usrc_Payment.ePaymentType m_ePaymentType = usrc_Payment.ePaymentType.NONE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;

        public Form_PrintExistingInvoice(InvoiceData xInvoiceData)
        {
            InitializeComponent();

            m_InvoiceData = xInvoiceData;
            this.Text = lngRPM.s_PaymentAndPrint.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Receipt_Preview_Load(object sender, EventArgs e)
        {
        }
    }
}
