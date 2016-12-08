using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using DBTypes;

namespace TangentaPrint
{
    public partial class usrc_TangentaPrint : UserControl
    {
        public Printer Printer;

        public string PrinterName { get; set; }

        public usrc_TangentaPrint()
        {
            InitializeComponent();
        }

        public bool Init(InvoiceData m_InvoiceData)
        {
            throw new NotImplementedException();
        }

        public int Get_CurrencyD_DecimalPlaces()
        {
            throw new NotImplementedException();
        }

        public void Print_Receipt(InvoiceData m_InvoiceData, GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            throw new NotImplementedException();
        }

        public void PrintReport(object m_usrc_InvoiceTable)
        {
            throw new NotImplementedException();
        }
    }
}
