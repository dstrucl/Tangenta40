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
        private int m_NumberOfPrinters = 2;
        public int NumberOfPrinters
        {
            get { return m_NumberOfPrinters; }
        }
        public Printer[] Printers = null;

        public string PrinterName { get; set; }

        public usrc_TangentaPrint()
        {
            InitializeComponent();
            Printers = new Printer[NumberOfPrinters];
            for (int i = 0; i < Printers.Length; i++)
            {
                Printers[i] = new Printer(i);
            }

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

        private void btn_Printers_Click(object sender, EventArgs e)
        {
            SelectPrinters();
        }

        private void SelectPrinters()
        {
            Form_DefinePrinters frm_select_printers = new Form_DefinePrinters(this);
            frm_select_printers.ShowDialog();
        }

        public bool GetReceiptPrinter()
        {
            throw new NotImplementedException();
        }
    }
}
