﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;

namespace Tangenta
{
    public partial class usrc_Payment : UserControl
    {
        public enum ePaymentType { NONE, CASH, ALLREADY_PAID, PAYMENT_CARD };
        public ePaymentType PaymentType = ePaymentType.NONE;
        public delegate void delegate_DoPrint (ePaymentType ePaymentType,string sPaymentMethod, string sAmountReceived, string sToReturn,DateTime_v issue_time);
        public event delegate_DoPrint DoPrint;


        int Currency_DecimalPlaces = -1;
        decimal GrossSum = 0;
        public string sPaymentMethod = null;
        long Invoice_ID = -1;
        public usrc_Payment()
        {
            InitializeComponent();
            rdb_Cash.Text = lngRPM.s_Cash.s;
            rdb_PaymentCard.Text = lngRPM.s_PaymentCard.s;
            this.lbl_Amount.Text = lngRPM.s_Amount.s;
            this.lbl_ToReturn.Text = lngRPM.s_ToReturn.s + ":";
            rdb_AllreadyPayed.Text = lngRPM.s_AlreadyPaid.s;
            btn_Print.Text = lngRPM.s_Print.s;
            lbl_Amount.Text = lngRPM.s_Amount.s + ":";
            lbl_AmountReceived.Text = lngRPM.s_AmountReceived.s + ":";
            btn_Print.Enabled = false;
            this.rdb_Cash.CheckedChanged += new System.EventHandler(this.rdb_Cash_CheckedChanged);
            this.rdb_Cash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdb_Cash_MouseUp);
            this.rdb_PaymentCard.CheckedChanged += rdb_PaymentCard_CheckedChanged;
            this.rdb_AllreadyPayed.CheckedChanged += rdb_AllreadyPayed_CheckedChanged;

        }

        void rdb_AllreadyPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                PaymentType = ePaymentType.ALLREADY_PAID;
                SetPaymentMethod(lngRPM.s_AlreadyPaid.s);
            }
        }

        void rdb_PaymentCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_PaymentCard.Checked)
            {
                PaymentType = ePaymentType.PAYMENT_CARD;
                SetPaymentMethod(lngRPM.s_PaymentCard.s);
            }
        }

        public bool Init(long xInvoice_ID, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            Invoice_ID = xInvoice_ID;
            Currency_DecimalPlaces = xCurrency_DecimalPlaces;
            GrossSum = xGrossSum;
            txt__Amount.Text = GrossSum.ToString();
            return true;
        }


        private void rdb_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Cash.Checked)
            {
                lbl_ToReturn.Visible = true;
                txt_ToReturn.Visible = true;
                lbl_AmountReceived.Visible = true;
                txt_AmountReceived.Visible = true;
                PaymentType = ePaymentType.CASH;
            }
            else
            {
                lbl_ToReturn.Visible = false;
                txt_ToReturn.Visible = false;
                lbl_AmountReceived.Visible = false;
                txt_AmountReceived.Visible = false;
            }
        }

        private void SetPaymentMethod(string sMethod)
        {
            btn_Print.Enabled = true;
            string spar_PaymentType = "@par_PaymentType";
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            SQL_Parameter par_PaymentType = new SQL_Parameter(spar_PaymentType, SQL_Parameter.eSQL_Parameter.Nvarchar, false, sMethod);
            lpar.Add(par_PaymentType);
            string sql = "select ID from methodofpayment where PaymentType=" + spar_PaymentType;
            DataTable dt = new DataTable();
            string Err = null;
            long methodofpayment_id = -1;
            object objret = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    methodofpayment_id = (long)dt.Rows[0]["ID"];
                }
                else
                {
                    sql = "insert into methodofpayment (PaymentType)values(" + spar_PaymentType +")";
                    if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref methodofpayment_id, ref objret, ref Err, "methodofpayment"))
                    {
                        LogFile.Error.Show("ERROR:usrc_Payment:SetPaymentMethod:sql=" + sql + "\nErr=" + Err);
                        return;
                    }
                }
                sql = "update invoice set methodofpayment_id = " + methodofpayment_id.ToString() + " where id = " + Invoice_ID.ToString();
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref objret, ref Err))
                {
                    sPaymentMethod = sMethod;
                    return;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Payment:SetPaymentMethod:sql=" + sql + "\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Payment:SetPaymentMethod:sql=" + sql + "\nErr=" + Err);
            }
                 
        }


        private void rdb_Cash_MouseUp(object sender, MouseEventArgs e)
        {
            Form_PaymentCash pay_in_cash_frm = new Form_PaymentCash(GrossSum);
            if (pay_in_cash_frm.ShowDialog() == DialogResult.OK)
            {
                txt_ToReturn.Text = decimal.Round(pay_in_cash_frm.money - GrossSum, Currency_DecimalPlaces).ToString();
                txt_AmountReceived.Text = pay_in_cash_frm.money.ToString();
                lbl_ToReturn.Visible = true;
                txt_ToReturn.Visible = true;
                lbl_AmountReceived.Visible = true;
                txt_AmountReceived.Visible = true;
                SetPaymentMethod(lngRPM.s_Cash.s);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (DoPrint!=null)
            {
                DateTime_v ProformaInvoiceTime = new DateTime_v();
                ProformaInvoiceTime.v = DateTime.Now;
                if (PaymentType == ePaymentType.CASH)
                {
                    DoPrint(PaymentType, sPaymentMethod, txt_AmountReceived.Text, txt_ToReturn.Text, ProformaInvoiceTime);
                }
                else
                {
                    DoPrint(PaymentType, sPaymentMethod, null, null, ProformaInvoiceTime);
                }
            }
        }

        private void lbl_Amount_Click(object sender, EventArgs e)
        {

        }

        private void txt__Amount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
