#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using TangentaDB;

namespace DocumentManager
{
    public partial class Form_DocInvoice_PaymentCash : Form
    {
        private decimal GrossSum = 0;
        private decimal m_Cash_AmountReceived = 0;
        private decimal m_Cash_ToReturn = 0;

        public decimal Cash_AmountReceived
        {
            get { return m_Cash_AmountReceived; }
        }

        public decimal Cash_ToReturn
        {
            get { return m_Cash_ToReturn; }
        }

        public Form_DocInvoice_PaymentCash(decimal xGrossSum)
        {
            InitializeComponent();
            GrossSum = xGrossSum;
            SetText("0");
            lng.s_ToReturn.Text(lbl_ToReturn);
            lng.s_Amount.Text(lbl_Amount, ":");
            lng.s_AmountReceived.Text(lbl_AmountReceived, ":");
            btn_Amount.Text = lng.s_EndPrice.s + ":" + GrossSum.ToString();
            this.Text = lng.s_AcceptedCashAmount.s;
        }
        private void CheckAmount()
        {
            decimal d = Convert.ToDecimal(txt_Display.Text);
            if (d >= GrossSum)
            {
                txt_Display.ForeColor = Color.Green;
                this.txt__Amount.Text = btn_Amount.Text;
                this.txt_AmountReceived.Text = txt_Display.Text;
                decimal dToReturn = d - GrossSum;
                this.txt_ToReturn.Text = dToReturn.ToString();
            }
            else
            {
                txt_Display.ForeColor = Color.Red;
                this.txt__Amount.Text = "";
                this.txt_AmountReceived.Text = "";
                this.txt_ToReturn.Text = "";
            }
        }
        private void AddCiffer(string c)
        {
            if (txt_Display.Text.Equals("0"))
            {
                txt_Display.Text = c;
            }
            else
            {
                txt_Display.Text = txt_Display.Text + c;
            }
            CheckAmount();
        }

        private void SetText(string c)
        {
           txt_Display.Text = c;
           CheckAmount();
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            AddCiffer("7");
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            AddCiffer("8");
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            AddCiffer("9");
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            AddCiffer("4");
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            AddCiffer("5");
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            AddCiffer("6");
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            AddCiffer("1");
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            AddCiffer("2");
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            AddCiffer("3");
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            AddCiffer("0");
        }

        private void btn_comma_Click(object sender, EventArgs e)
        {
            AddCiffer(",");
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SetText("0");
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            m_Cash_AmountReceived = Convert.ToDecimal(txt_Display.Text);
            m_Cash_ToReturn = m_Cash_AmountReceived - GrossSum;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_BackSpace_Click(object sender, EventArgs e)
        {
            if (txt_Display.Text.Length > 1)
            {
                SetText(txt_Display.Text.Substring(0, txt_Display.Text.Length - 1));
            }
            else
            {
                SetText("0");
            }
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            SetText("10,00");
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            SetText("20,00");
        }

        private void btn_30_Click(object sender, EventArgs e)
        {
            SetText("30,00");
        }

        private void btn_40_Click(object sender, EventArgs e)
        {
            SetText("40,00");
        }

        private void btn_50_Click(object sender, EventArgs e)
        {
            SetText("50,00");
        }

        private void btn_60_Click(object sender, EventArgs e)
        {
            SetText("60,00");
        }

        private void btn_100_Click(object sender, EventArgs e)
        {
            SetText("100,00");
        }

        private void btn_200_Click(object sender, EventArgs e)
        {
            SetText("150,00");
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            SetText("15,00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetText("25,00");
        }

        private void btn_35_Click(object sender, EventArgs e)
        {
            SetText("35,00");
        }

        private void btn_45_Click(object sender, EventArgs e)
        {
            SetText("45,00");
        }

        private void btn_70_Click(object sender, EventArgs e)
        {
            SetText("70,00");
        }

        private void btn_80_Click(object sender, EventArgs e)
        {
            SetText("80,00");
        }

        private void btn_120_Click(object sender, EventArgs e)
        {
            SetText("120,00");
        }

        private void btn_200_Click_1(object sender, EventArgs e)
        {
            SetText("200,00");
        }

        private void PaymentCash_Form_Load(object sender, EventArgs e)
        {

        }

        private void btn_250_Click(object sender, EventArgs e)
        {
            SetText("250,00");
        }

        private void btn_300_Click(object sender, EventArgs e)
        {
            SetText("300,00");
        }

        private void btn_400_Click(object sender, EventArgs e)
        {
            SetText("400,00");
        }

        private void btn_500_Click(object sender, EventArgs e)
        {
            SetText("500,00");
        }

        private void btn_Amount_Click(object sender, EventArgs e)
        {
            SetText(GrossSum.ToString());
        }

    }
}
