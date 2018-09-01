using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace LoginControl
{
    public partial class usrc_MethotOfPaymentReport : UserControl
    {
        public usrc_MethotOfPaymentReport()
        {
            InitializeComponent();
        }
        public void Init(Report.PaymentType pt)
        {
            lng.s_lbl_MethodOfPayment_Total.Text(lbl_Total);
            lbl_MethodOfPayment_Name.Text = pt.Name;
            txt_MethodOfPayment_NumOfInvoices.Text = pt.Count.ToString();
            txt_Total_Value.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(pt.Total, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
        }
    }
}
