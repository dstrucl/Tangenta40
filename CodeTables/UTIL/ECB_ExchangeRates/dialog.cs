using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECB_ExchangeRates
{
    public static class dialog
    {
        public static void Show(Form pParent)
        {
            Form_ECBExchangeRates frm_ECBExchangeRates = new Form_ECBExchangeRates();
            frm_ECBExchangeRates.ShowDialog(pParent);
        }
    }
}
