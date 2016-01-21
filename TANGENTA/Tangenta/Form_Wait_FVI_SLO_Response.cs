using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Wait_FVI_SLO_Response : Form
    {
        private string fVI_MessageID;
        private string fVI_UniqueInvoiceID;
        private DateTime_v issue_time;
        private GlobalData.ePaymentType paymentType;
        private string sAmountReceived;
        private string sPaymentMethod;
        private string sToReturn;
        private InvoiceData xInvoiceData;


        public Form_Wait_FVI_SLO_Response(string fVI_MessageID, string fVI_UniqueInvoiceID, InvoiceData xInvoiceData, GlobalData.ePaymentType paymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            InitializeComponent();
            this.fVI_MessageID = fVI_MessageID;
            this.fVI_UniqueInvoiceID = fVI_UniqueInvoiceID;
            this.xInvoiceData = xInvoiceData;
            this.paymentType = paymentType;
            this.sPaymentMethod = sPaymentMethod;
            this.sAmountReceived = sAmountReceived;
            this.sToReturn = sToReturn;
            this.issue_time = issue_time;
        }
    }
}
