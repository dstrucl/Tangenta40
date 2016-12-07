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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using DBTypes;
using TangentaDB;

namespace Tangenta
{
    public partial class usrc_DocProformaInvoice_Payment : UserControl
    {
        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_OK();
        public event delegate_OK OK;

        public InvoiceData m_InvoiceData = null;
        
        public GlobalData.ePaymentType PaymentType = GlobalData.ePaymentType.NONE;

        private long m_DocDuration = -1;
        private long m_DocDurationType = -1;
        private long m_TermsOfPayment_ID = -1;
        private long m_MethodOfPayment_ID = -1;

        public long DocDuration
        {
            get { return m_DocDuration; }
            set { m_DocDuration = value; }
        }

        public long DocDurationType
        {
            get { return m_DocDurationType; }
            set { m_DocDurationType = value; }
        }

        public long TermsOfPayment_ID
        {
            get { return m_TermsOfPayment_ID; }
            set { m_TermsOfPayment_ID = value; }
        }

        public long MethodOfPayment_ID
        {
            get { return m_MethodOfPayment_ID; }
            set { m_MethodOfPayment_ID = value; }
        }



        int Currency_DecimalPlaces = -1;
        decimal GrossSum = 0;
        public string sPaymentMethod = null;
        long DocInvoice_ID = -1;
        public usrc_DocProformaInvoice_Payment()
        {
            InitializeComponent();
            lngRPM.s_MethodOfPayment.Text(this.grp_MtehodOfPaymentType);
            lngRPM.s_Payment_on_bank_account.Text(rdb_BankAccountTransfer);
            lngRPM.s_Payment_by_cash_or_card_on_delivery.Text(rdb_Payment_by_cash_or_credit_card_on_delivery);
            lngRPM.s_TermsOfPayment.Text(grp_TermsOfPayment);
            lngRPM.s_btn_Select_Terms_Of_Payment.Text(this.btn_Select_Terms_of_Payment);
            lngRPM.s_grp_ValidityOfTheTender.Text(grp_ValidityOfTheTender);
            lngRPM.s_rbtn_NumberOf.Text(rbtn_NumberOf);
            lngRPM.s_rdb_Valid_Tender_Until.Text(rdb_Valid_Tender_Until);
            lngRPM.s_Print.Text(btn_Print);

            btn_Print.Enabled = false;
        }



        public bool Init(InvoiceData xInvoiceData, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            m_InvoiceData = xInvoiceData;
            DocInvoice_ID = m_InvoiceData.m_ShopABC.m_CurrentInvoice.Doc_ID;
            Currency_DecimalPlaces = xCurrency_DecimalPlaces;
            GrossSum = xGrossSum;
            return true;
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
                sql = "update docinvoice set methodofpayment_id = " + methodofpayment_id.ToString() + " where id = " + DocInvoice_ID.ToString();
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


        private void btn_Print_Click(object sender, EventArgs e)
        {
            DateTime_v DocInvoiceTime = new DateTime_v();
            DocInvoiceTime.v = DateTime.Now;
            DoPrint(PaymentType,MethodOfPayment_ID,DocDuration,DocDurationType,TermsOfPayment_ID, DocInvoiceTime);
            if (OK != null)
            {
                OK();
            }
        }

        private void DoPrint(GlobalData.ePaymentType ePaymentType, long xMethodOfPayment_ID, long xDocDuration, long xDocDurationType, long xTermsOfPayment_ID, DateTime_v issue_time)
        {
            long DocInvoice_ID = -1;
            int xNumberInFinancialYear = -1;
            if (m_InvoiceData.SaveDocProformaInvoice(ref DocInvoice_ID, ePaymentType, xMethodOfPayment_ID, xDocDuration, xDocDurationType, xTermsOfPayment_ID, ref xNumberInFinancialYear))
             {
                m_InvoiceData.Set_NumberInFinancialYear(xNumberInFinancialYear);

                if (m_InvoiceData.SetInvoiceTime(issue_time))
                {
                    //Print(ePaymentType, xMethodOfPayment_ID, xDocDuration, xDocDurationType, xTermsOfPayment_ID, issue_time);
                }
            }
        }


        private void Print(GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            if (ePaymentType == GlobalData.ePaymentType.CASH)
            {
                Program.usrc_Printer1.Print_Receipt(m_InvoiceData, ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Program.usrc_Printer1.Print_Receipt(m_InvoiceData, ePaymentType, sPaymentMethod, null, null, issue_time);
            }
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
