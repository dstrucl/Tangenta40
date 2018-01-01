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

        public Form_ECBExchangeRates()
        {
            InitializeComponent();
            lng.s_Reference.Text(lblRef);
            dataGrid1.CaptionText = lng.s_ExchangeRatePerDay.s;
            lng.s_lbl_Date.Text(lbl_Date);
            lng.s_lbl_From.Text(lbl_From);
            lng.s_lbl_To.Text(lbl_To);
            lng.s_lbl_FromCountryExchange.Text(lbl_FromCountryExchange);
            lng.s_lbl_ToCountryExchange.Text(lbl_ToCountryExchange);
            lng.s_btn_Calculate.Text(btn_Calculate);
            lng.s_ExchangeRates.Text(this);

        }

     
        private void InitCombo()
        {
            int DkIndex = 0;
            cmbDate.DataSource = _dsExchangeRate.Tables["Exchange"];
            cmbDate.DisplayMember = "Date";
            cmbDate.ValueMember = "Date";
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
                            if ("Name" == c.ColumnName)
                            {
                                if (r[c] is string)
                                {
                                    if (((string)r[c]).Equals("Euro")) DkIndex++;
                                    if (DkIndex <= 1)
                                    {
                                        cmbFromCountry.Items.Add((object)r[c]);
                                        cmbToCountry.Items.Add((object)r[c]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            cmbDate.SelectedIndex = 0;
            cmbFromCountry.SelectedIndex = 0;
            cmbToCountry.SelectedIndex = 0;
        }

        private void btnCalculat_Click(object sender, System.EventArgs e)
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

                txtHowMany.Text = Convert.ToString(ExRateValue(Input, dblFromLand, dblToLand, lblRef.Text));
            }
        }


        private static double ExRateValue(double Input, double FromContry, double ToContry, string reference)
        {
            double result = 0;
            if (0 < reference.IndexOf("Danmarks Nationalbank", 0, reference.Length))
            {
                if (ToContry == 0) return 0;
                result = (Input / ToContry) * FromContry;
            }
            else
            {
                result = (Input / FromContry) * ToContry;
            }
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
