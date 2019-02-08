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
using DBTypes;
using LanguageControl;
using TangentaDB;

namespace Form_Discount
{
    public partial class Form_Discount : Form
    {
        public decimal ExtraDiscount;
        decimal RetailPrice;
        decimal_v PurchasePrice_v = null;
        string sItemName = null;



        public Form_Discount(decimal xRetailPrice, decimal_v xPurchasePrice_v, decimal xDiscount, string xsItemName)
        {
            InitializeComponent();
            RetailPrice = xRetailPrice;
            PurchasePrice_v = xPurchasePrice_v;
            sItemName = xsItemName;
            if (sItemName == null)
            {
                sItemName = "???";
            }
            if (xPurchasePrice_v == null)
            {
                btn_PurchasePriceInfo.Visible = false;
            }
            lng.s_rdb_CustomDiscount.Text(rdb_Custom);
            lng.s_rdb_EndPrice.Text(rdb_EndPrice);
            lng.s_btn_PurchasePriceInfo.Text(btn_PurchasePriceInfo);
            ExtraDiscount = xDiscount;
            nm_UpDown_EndPrice.Maximum = 100000000000M;
            nm_UpDown_EndPrice.Minimum = 0M;
            nm_UpDown_Discount.Minimum = -10000000000;
            nm_UpDown_Discount.Increment = 1;
            nm_UpDown_Discount.Maximum = +10000000000;
            int_v iDecimalPlaces_v = new int_v();
            iDecimalPlaces_v.v = TangentaDB.GlobalData.BaseCurrency.DecimalPlaces;
            decimal dincrement = fs.GetIncrement(iDecimalPlaces_v, null);
            nm_UpDown_EndPrice.Increment = dincrement;
            nm_UpDown_EndPrice.DecimalPlaces = iDecimalPlaces_v.v;
            nm_UpDown_Discount.DecimalPlaces = 2;
            nm_UpDown_EndPrice.Enabled = false;
            Set_nm_UpDown_Discount(0);
            nm_UpDown_EndPrice.Value = xRetailPrice;
            SetCurrentDiscount(xDiscount);
            AddHandlers();
            DialogResult = DialogResult.Cancel;

            string s_RetailPrice = fs.Decimal2String(RetailPrice, GlobalData.BaseCurrency.DecimalPlaces) + " " + GlobalData.BaseCurrency.Abbreviation;
            lng.s_Price.Text(sItemName+", ", this, " = " +s_RetailPrice);

        }

        private void Set_nm_UpDown_Discount(decimal dvalue)
        {
            nm_UpDown_Discount.Value = dvalue;
        }

        private void SetCurrentDiscount(decimal xDiscount)
        {
            nm_UpDown_Discount.Enabled = false;

            if (xDiscount == 0)
            {
                this.rdb_0.Checked = true;
            }
            else if (xDiscount == 0.02M)
            {
                this.rdb_2.Checked = true;
            }
            else if (xDiscount == 0.03M)
            {
                this.rdb_3.Checked = true;
            }
            else if (xDiscount == 0.05M)
            {
                this.rdb_5.Checked = true;
            }
            else if (xDiscount == 0.07M)
            {
                this.rdb_7.Checked = true;
            }
            else if (xDiscount == 0.1M)
            {
                this.rdb_10.Checked = true;
            }
            else if (xDiscount == 0.15M)
            {
                this.rdb_15.Checked = true;
            }
            else if (xDiscount == 0.2M)
            {
                this.rdb_20.Checked = true;
            }
            else
            {
                this.rdb_Custom.Checked = true;
                nm_UpDown_Discount.Enabled = true;
                SetDiscount(this.rdb_Custom, xDiscount);
                //nm_UpDown_Discount.Value = decimal.Round(xDiscount*100,4);
            }

        }

        private void AddHandlers()
        {
            this.rdb_0.CheckedChanged += new System.EventHandler(this.rdb_0_CheckedChanged);
            this.rdb_2.CheckedChanged += new System.EventHandler(this.rdb_2_CheckedChanged);
            this.rdb_3.CheckedChanged += new System.EventHandler(this.rdb_3_CheckedChanged);
            this.rdb_5.CheckedChanged += new System.EventHandler(this.rdb_5_CheckedChanged);
            this.rdb_7.CheckedChanged += new System.EventHandler(this.rdb_7_CheckedChanged);
            this.rdb_10.CheckedChanged += new System.EventHandler(this.rdb_10_CheckedChanged);
            this.rdb_15.CheckedChanged += new System.EventHandler(this.rdb_15_CheckedChanged);
            this.rdb_20.CheckedChanged += new System.EventHandler(this.rdb_20_CheckedChanged);
            this.nm_UpDown_Discount.ValueChanged += new System.EventHandler(this.nm_UpDown_Discount_ValueChanged);
            this.rdb_Custom.CheckedChanged += new System.EventHandler(this.rdb_Custom_CheckedChanged);
            this.rdb_EndPrice.CheckedChanged += new System.EventHandler(this.rdb_EndPrice_CheckedChanged);
            this.nm_UpDown_EndPrice.ValueChanged += new System.EventHandler(this.nm_UpDown_EndPrice_ValueChanged);

        }
        private void rdb_0_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.0M);
        }

        private void rdb_2_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.02M);
        }

        private void rdb_3_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.03M);
        }

        private void rdb_5_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.05M);
        }

        private void rdb_7_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.07M);
        }

        private void rdb_10_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.1M);
        }

        private void rdb_15_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.15M);
        }

        private void rdb_20_CheckedChanged(object sender, EventArgs e)
        {
            SetDiscount((RadioButton)sender, 0.2M);
        }

        private void SetDiscount(RadioButton rdb, decimal discount)
        {
            if (rdb.Checked)
            {
                ExtraDiscount = discount;
                try
                {
                    Set_nm_UpDown_Discount(ExtraDiscount * 100);
                    nm_UpDown_EndPrice.Value = RetailPrice * (1 - ExtraDiscount);
                }
                catch
                {

                }
            }
        }

        private void rdb_Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Custom.Checked)
            {
                nm_UpDown_Discount.Enabled = true;
            }
            else
            {
                nm_UpDown_Discount.Enabled = false;
            }
        }

        private void nm_UpDown_Discount_ValueChanged(object sender, EventArgs e)
        {
            ExtraDiscount = nm_UpDown_Discount.Value / 100;
        }

        private void rdb_EndPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_EndPrice.Checked)
            {
                nm_UpDown_EndPrice.Enabled = true;
            }
            else
            {
                nm_UpDown_EndPrice.Enabled = false;
            }

        }

        private void nm_UpDown_EndPrice_ValueChanged(object sender, EventArgs e)
        {
            ExtraDiscount = (RetailPrice - nm_UpDown_EndPrice.Value) / RetailPrice;
            Set_nm_UpDown_Discount(ExtraDiscount * 100);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (PurchasePrice_v != null)
            {
                decimal RetailPrice_with_discount = RetailPrice - RetailPrice * ExtraDiscount;
                if (RetailPrice_with_discount <= PurchasePrice_v.v)
                {
                    string sMsg = lng.s_ExtraDiscountMakesLowerPriceThan_PurchasePrice.s;
                    string sRetailPrice = fs.Decimal2String(RetailPrice, 2) + " " + GlobalData.BaseCurrency.Abbreviation;
                    string sDiscount = fs.Decimal2String(ExtraDiscount * 100, 2) + "%";
                    string sRetailPrice_with_discount = fs.Decimal2String(RetailPrice_with_discount, 2) + " " + GlobalData.BaseCurrency.Abbreviation;
                    string sPurchasePrice = fs.Decimal2String(PurchasePrice_v.v, 2) + " " + GlobalData.BaseCurrency.Abbreviation;
                    sMsg = sMsg.Replace("%s1", sRetailPrice);
                    sMsg = sMsg.Replace("%s2", sDiscount);
                    sMsg = sMsg.Replace("%s3", sRetailPrice_with_discount);
                    sMsg = sMsg.Replace("%s4", sPurchasePrice);
                    if (XMessage.Box.Show(this, lng.s_ExtraDiscountMakesLowerPriceThan_PurchasePrice, sMsg, "!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.OK;

        }

        private void btn_PurchasePriceInfo_Click(object sender, EventArgs e)
        {
            string sMsg = lng.s_PurchasePriceInfoText.s;
            
            string sPurchasePrice = fs.Decimal2String(PurchasePrice_v.v, 2) + " " + GlobalData.BaseCurrency.Abbreviation;
            List<object> lobj = new List<object>();
            string s = sMsg.Replace("%s1", sItemName);
            s = s.Replace("%s2", sPurchasePrice);
            lobj.Add(s);
            ltext lmsg = new ltext(lobj);
            XMessage.Box.Show(this, lmsg, "", lng.s_PurchasePriceInfo.s, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void nm_UpDown_Discount_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
