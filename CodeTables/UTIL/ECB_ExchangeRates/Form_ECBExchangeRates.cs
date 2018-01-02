using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECB_ExchangeRates
{
    public partial class Form_ECBExchangeRates : Form
    {
        private RateLoad _kl = new RateLoad();
        private ExchangeRate _dsExchangeRate = new ExchangeRate();
        private string m_ConvertToCurrencyWithAbbreviation = null;
        private decimal m_dEuroValueToConvert = 0;
        private decimal m_dExchangeRateProvision = 0;
        private decimal m_dResult = 0;

        public decimal ExchangeRateProvision { get { return m_dExchangeRateProvision; } }
        public decimal Result { get { return m_dResult; } }

        public Form_ECBExchangeRates()
        {
            InitializeComponent();
            InitializeControls();

        }

        public Form_ECBExchangeRates(string xConvertToCurrencyWithAbbreviation, decimal dEuroValueToConvert, decimal dExchangeRateProvision)
        {
            InitializeComponent();
            m_ConvertToCurrencyWithAbbreviation = xConvertToCurrencyWithAbbreviation;
            m_dEuroValueToConvert = dEuroValueToConvert;
            m_dExchangeRateProvision = dExchangeRateProvision;

            InitializeControls();
        }

        private void Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                string sText = ((RadioButton)sender).Text;
                if (sText.Equals("2,5%"))
                {
                    m_dExchangeRateProvision = 2.5M;
                }
                else if (sText.Length==0)
                {
                    m_dExchangeRateProvision = nmUpDn_ExchangeRateProvision.Value;
                }
                else
                {
                    try
                    {
                        sText = sText.Replace("%", "");
                        m_dExchangeRateProvision = Convert.ToDecimal(sText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: Can not convert to decimal:\""+sText+ "\".\r\nException="+ex.Message);
                        return;
                    }
                }
                convert();
            }
        }

        private void InitializeControls()
        {
            lng.s_Reference.Text(lblRef);
            dataGrid1.CaptionText = lng.s_ExchangeRatePerDay.s;
            lng.s_lbl_Date.Text(lbl_Date);
            lng.s_lbl_From.Text(lbl_From);
            lng.s_lbl_To.Text(lbl_To);
            lng.s_lbl_FromCountryExchange.Text(lbl_FromCountryExchange);
            lng.s_lbl_ToCountryExchange.Text(lbl_ToCountryExchange);
            lng.s_btn_Calculate.Text(btn_Calculate);
            lng.s_ExchangeRates.Text(this);
            lng.s_ExchangeRateProvision.Text(grp_ExchangeRateProvision);


            if (m_dExchangeRateProvision > nmUpDn_ExchangeRateProvision.Maximum)
            {
                m_dExchangeRateProvision = nmUpDn_ExchangeRateProvision.Maximum;
                nmUpDn_ExchangeRateProvision.Value = m_dExchangeRateProvision;
                rdb_nmUpDn.Checked = true;
            }
            else if (m_dExchangeRateProvision < nmUpDn_ExchangeRateProvision.Minimum)
            {
                m_dExchangeRateProvision = nmUpDn_ExchangeRateProvision.Minimum;
                nmUpDn_ExchangeRateProvision.Value = m_dExchangeRateProvision;
                rdb_nmUpDn.Checked = true;
            }
            else if (m_dExchangeRateProvision == 0)
            {
                nmUpDn_ExchangeRateProvision.Value = 0;
                rdb_0.Checked = true;
            }
            else if (m_dExchangeRateProvision == 1)
            {
                nmUpDn_ExchangeRateProvision.Value = 1;
                rdb_1.Checked = true;
            }
            else if (m_dExchangeRateProvision == 2)
            {
                nmUpDn_ExchangeRateProvision.Value = 2;
                rdb_2.Checked = true;
            }
            else if (m_dExchangeRateProvision == 2.5M)
            {
                nmUpDn_ExchangeRateProvision.Value = 2.5M;
                rdb_2_5.Checked = true;
            }
            else if (m_dExchangeRateProvision == 3)
            {
                nmUpDn_ExchangeRateProvision.Value = 3;
                rdb_3.Checked = true;
            }
            else if (m_dExchangeRateProvision == 4)
            {
                nmUpDn_ExchangeRateProvision.Value = 4;
                rdb_4.Checked = true;
            }
            else if (m_dExchangeRateProvision == 5)
            {
                nmUpDn_ExchangeRateProvision.Value = 5;
                rdb_5.Checked = true;
            }
            else if (m_dExchangeRateProvision == 6)
            {
                nmUpDn_ExchangeRateProvision.Value = 6;
                rdb_6.Checked = true;
            }
            else if (m_dExchangeRateProvision == 7)
            {
                nmUpDn_ExchangeRateProvision.Value = 7;
                rdb_7.Checked = true;
            }
            else if (m_dExchangeRateProvision == 8)
            {
                nmUpDn_ExchangeRateProvision.Value = 8;
                rdb_8.Checked = true;
            }
            else if (m_dExchangeRateProvision == 10)
            {
                nmUpDn_ExchangeRateProvision.Value = 10;
                rdb_10.Checked = true;
            }
            else if (m_dExchangeRateProvision == 15)
            {
                nmUpDn_ExchangeRateProvision.Value = 15;
                rdb_15.Checked = true;
            }
            else if (m_dExchangeRateProvision == 20)
            {
                nmUpDn_ExchangeRateProvision.Value = 20;
                rdb_20.Checked = true;
            }
            else if (m_dExchangeRateProvision == 25)
            {
                nmUpDn_ExchangeRateProvision.Value = 25;
                rdb_25.Checked = true;
            }
            else if (m_dExchangeRateProvision == 30)
            {
                nmUpDn_ExchangeRateProvision.Value = 30;
                rdb_30.Checked = true;
            }
            else
            {
                nmUpDn_ExchangeRateProvision.Value = m_dExchangeRateProvision;
                rdb_nmUpDn.Checked = true;
            }
            rdb_0.CheckedChanged += Rdb_CheckedChanged;
            rdb_1.CheckedChanged += Rdb_CheckedChanged;
            rdb_2.CheckedChanged += Rdb_CheckedChanged;
            rdb_2_5.CheckedChanged += Rdb_CheckedChanged;
            rdb_3.CheckedChanged += Rdb_CheckedChanged;
            rdb_4.CheckedChanged += Rdb_CheckedChanged;
            rdb_5.CheckedChanged += Rdb_CheckedChanged;
            rdb_6.CheckedChanged += Rdb_CheckedChanged;
            rdb_7.CheckedChanged += Rdb_CheckedChanged;
            rdb_8.CheckedChanged += Rdb_CheckedChanged;
            rdb_10.CheckedChanged += Rdb_CheckedChanged;
            rdb_15.CheckedChanged += Rdb_CheckedChanged;
            rdb_20.CheckedChanged += Rdb_CheckedChanged;
            rdb_25.CheckedChanged += Rdb_CheckedChanged;
            rdb_30.CheckedChanged += Rdb_CheckedChanged;
            rdb_nmUpDn.CheckedChanged += Rdb_CheckedChanged;

        }

        private void InitCombo()
        {
            int EuroIndex = 0;
            cmbDate.DataSource = _dsExchangeRate.Tables["Exchange"];
            cmbDate.DisplayMember = "Date";
            cmbDate.ValueMember = "Date";
            int HRK_Index = -1;
            foreach (DataTable t in _dsExchangeRate.Tables)
            {
                foreach (DataRow r in t.Rows)
                {
                    foreach (DataColumn c in t.Columns)
                    {
                        //if ("Exchange" == t.TableName)
                        //{
                        //    if ("Date" == c.ColumnName)
                        //    {
                        //        DateTime dato = (DateTime)r[c];
                        //        cmbDate.Items.Add((object)dato.DayOfWeek + " " + dato.ToLongDateString());
                        //    }
                        //}

                        if ("Country" == t.TableName)
                        {
                            if ("Initial" == c.ColumnName)
                            {
                                if (r[c] is string)
                                {

                                    if (m_ConvertToCurrencyWithAbbreviation == null)
                                    {
                                        if (((string)r[c]).Equals("EUR")) EuroIndex++;

                                        if (EuroIndex <= 1)
                                        {
                                            cmbFromCountry.Items.Add((object)r[c]);
                                            cmbToCountry.Items.Add((object)r[c]);
                                        }
                                    }
                                    else
                                    {
                                        if (((string)r[c]).Equals("EUR")) EuroIndex++;

                                        if (EuroIndex <= 1)
                                        {
                                            cmbFromCountry.Items.Add((object)r[c]);
                                        }

                                        if (((string)r[c]).Equals(m_ConvertToCurrencyWithAbbreviation))
                                        {
                                            HRK_Index = cmbToCountry.Items.Add((object)r[c]);
                                        }
                                        else
                                        {
                                            cmbToCountry.Items.Add((object)r[c]);
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }

            cmbDate.SelectedIndex = 0;
            cmbFromCountry.SelectedIndex = 0;
            if (HRK_Index >= 0)
            {
                cmbToCountry.SelectedIndex = HRK_Index;
            }
            else
            {
                cmbToCountry.SelectedIndex = 0;
            }
        }

        private void btnCalculat_Click(object sender, System.EventArgs e)
        {
            convert();
        }


        private bool convert ()
        {
            int Date = cmbDate.SelectedIndex;
            int FromC = cmbFromCountry.SelectedIndex;
            int ToC = cmbToCountry.SelectedIndex;

            string FromLand = null;
            double dblFromLand = 0;
            string ToLand = null;
            double dblToLand = 0;

            object oSelectedValue = cmbDate.SelectedValue;
            if (oSelectedValue is DateTime)
            {
                DateTime dato = (DateTime)oSelectedValue;

                try
                {
                    DataRow drFound;

                    // Find the Row specified in txtFindArg
                    drFound = _dsExchangeRate.Tables["Exchange"].Rows.Find(Date);
                    if (drFound == null)
                    {
                        MessageBox.Show("No PK matches " + cmbDate.Text);
                        return false;
                    }
                    else
                    {
                        if (Convert.ToDateTime(drFound[0]) == dato)
                        {
                            int Index = 0;
                            foreach (DataRow choiceRow in drFound.GetChildRows("Exchange_Country"))
                            {
                                if (FromC == Index)
                                {
                                    FromLand = choiceRow["Initial"].ToString();
                                    dblFromLand = (double)choiceRow["Rate"];
                                }

                                if (ToC == Index)
                                {
                                    ToLand = choiceRow["Initial"].ToString();
                                    dblToLand = (double)choiceRow["Rate"];
                                }

                                Index++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                label4.Text = FromLand;
                label5.Text = ToLand;
                string II = txtBelob.Text;
                double Input = Convert.ToDouble(II);
                double dResult = ExRateValue(Input, dblFromLand, dblToLand);
                dResult = dResult * (1 + (Convert.ToDouble(m_dExchangeRateProvision))/100);
                txtHowMany.Text = Convert.ToString(dResult);
                m_dResult = Convert.ToDecimal(dResult);
                return true;
            }
            else
            {
                return false;
            }

        }
        private static double ExRateValue(double Input, double FromContry, double ToContry)
        {
            double result = 0;
            result = (Input / FromContry) * ToContry;
            result = Math.Round(result, 2);
            return result;
        }

        private void Form_ECBExchangeReates_Load(object sender, EventArgs e)
        {
            _dsExchangeRate = _kl.LoadNationalBankExRate();
            lblRef.Text =lng.s_Reference.s + _kl.Author;
            dataGrid1.SetDataBinding(_dsExchangeRate, "Exchange");
            InitCombo();
        }
    }
}
