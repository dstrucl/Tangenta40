using ECB_ExchangeRates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECB_ExchangeRates_TEST
{
    public partial class Form_Test : Form
    {
        List<string> CurrencyAbbreviationList = new List<string>();

        public Form_Test()
        {
            InitializeComponent();


            CurrencyAbbreviationList.Add("DKK");
			CurrencyAbbreviationList.Add("EUR");
            CurrencyAbbreviationList.Add("USD");
            CurrencyAbbreviationList.Add("GBP");
            CurrencyAbbreviationList.Add("SEK");
            CurrencyAbbreviationList.Add("NOK");
            CurrencyAbbreviationList.Add("CNY");
            CurrencyAbbreviationList.Add("ISK");
            CurrencyAbbreviationList.Add("IDR");
            CurrencyAbbreviationList.Add("CHF");
            CurrencyAbbreviationList.Add("CAD");
            CurrencyAbbreviationList.Add("JPY");
            CurrencyAbbreviationList.Add("RUB");
            CurrencyAbbreviationList.Add("HRK");
            CurrencyAbbreviationList.Add("MYR");
            CurrencyAbbreviationList.Add("PHP");
            CurrencyAbbreviationList.Add("THB");
            CurrencyAbbreviationList.Add("AUD");
            CurrencyAbbreviationList.Add("NZD");
            CurrencyAbbreviationList.Add("EEK");
            CurrencyAbbreviationList.Add("LVL");
            CurrencyAbbreviationList.Add("LTL");
            CurrencyAbbreviationList.Add("PLN");
            CurrencyAbbreviationList.Add("CZK");
            CurrencyAbbreviationList.Add("HUF");
            CurrencyAbbreviationList.Add("HKD");
            CurrencyAbbreviationList.Add("SGD");
            CurrencyAbbreviationList.Add("SDR");
            CurrencyAbbreviationList.Add("BGN");
            CurrencyAbbreviationList.Add("CYP");
            CurrencyAbbreviationList.Add("MTL");
            CurrencyAbbreviationList.Add("ROL");
            CurrencyAbbreviationList.Add("SIT");
            CurrencyAbbreviationList.Add("SKK");
            CurrencyAbbreviationList.Add("TRY");
            CurrencyAbbreviationList.Add("KRW");
            CurrencyAbbreviationList.Add("ZAR");


            cmb_ConvertEuroToCurrency.DataSource = CurrencyAbbreviationList;
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            string sConvertEurToCurrencyWithAbbreviation = cmb_ConvertEuroToCurrency.Text;
            decimal dValueInEur = nm_UpDn_ValueInEUR.Value;
            ECB_ExchangeRates.Form_ECBExchangeRates frm = new ECB_ExchangeRates.Form_ECBExchangeRates(
                sConvertEurToCurrencyWithAbbreviation,
                dValueInEur,
                this.nm_UpDn_ExchangeRateProvisionInPercent.Value
                );
            frm.ShowDialog(this);
            txt_ConversionResult.Text = frm.Result.ToString();
        }

        private void btn_ShowWithoutParameters_Click(object sender, EventArgs e)
        {
            ECB_ExchangeRates.Form_ECBExchangeRates frm = new ECB_ExchangeRates.Form_ECBExchangeRates(
                );
            frm.ShowDialog(this);
            txt_ConversionResult.Text = frm.Result.ToString();
        }

        private void btn_ConvertDaily_Click(object sender, EventArgs e)
        {
            CurrencyDaily currency_exchange = new CurrencyDaily();
            string Err = null;
            if (currency_exchange.Load(ref Err))
            {
                currency_exchange.BaseCurrency = "EUR";
                String[] CurrencyList;
                CurrencyList = currency_exchange.GetCurrencyList().ToArray();
                string sConvertEurToCurrencyWithAbbreviation = cmb_ConvertEuroToCurrency.Text;
                txt_ConversionResult.Text = currency_exchange.Exchange(nm_UpDn_ValueInEUR.Value, "EUR", sConvertEurToCurrencyWithAbbreviation).ToString();
            }
        }
    }
}
