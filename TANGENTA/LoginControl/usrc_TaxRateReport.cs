using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_TaxRateReport : UserControl
    {
        public usrc_TaxRateReport()
        {
            InitializeComponent();
            lng.s_Neto.Text(lbl_Neto);
            lng.s_Tax.Text(lbl_Tax);
            lng.s_Total.Text(lbl_Total);
        }


        public usrc_TaxRateReport(string taxation_name ,decimal net, decimal tax, decimal total)
        {
            InitializeComponent();
            lng.s_Neto.Text(lbl_Neto);
            lng.s_Tax.Text(lbl_Tax);
            lng.s_Total.Text(lbl_Total);
            txt_TaxName.Text = taxation_name;
            txt_Neto_Value.Text = net.ToString();
            txt_Tax_Value.Text = tax.ToString();
            txt_Total_Value.Text = total.ToString();
        }
    }
}
