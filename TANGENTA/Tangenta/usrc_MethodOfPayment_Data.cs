using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class usrc_MethodOfPayment_Data : UserControl
    {
        public bool IsDocInvoice
        {
            get
            { string s = Program.const_DocInvoice;
                return Program.RunAs.ToUpper().Equals(s.ToUpper());
            }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
                string s = Program.const_DocProformaInvoice;
                return Program.RunAs.ToUpper().Equals(s.ToUpper());
            }
        }

        public usrc_MethodOfPayment_Data()
        {
            InitializeComponent();
        }

        public bool GetMethodOfPaymentForDocInvoice(TangentaDB.InvoiceData xInvoiceData, string xDocInvoice)
        {
            Form_DocInvoice_Payment payment_frm = new Form_DocInvoice_Payment(xInvoiceData, xDocInvoice);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public bool GetMethodOfPaymentForDocProformaInvoice(TangentaDB.InvoiceData xInvoiceData, string xDocInvoice)
        {
            Form_DocProformaInvoice_Payment payment_frm = new Form_DocProformaInvoice_Payment(xInvoiceData, xDocInvoice);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
    }
}
