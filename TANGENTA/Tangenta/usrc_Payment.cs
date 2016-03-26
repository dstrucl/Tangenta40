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
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_Payment : UserControl
    {
        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_OK();
        public event delegate_OK OK;

        public InvoiceData m_InvoiceData = null;
        
        public GlobalData.ePaymentType PaymentType = GlobalData.ePaymentType.NONE;


        int Currency_DecimalPlaces = -1;
        decimal GrossSum = 0;
        public string sPaymentMethod = null;
        long Invoice_ID = -1;
        public usrc_Payment()
        {
            InitializeComponent();
            lngRPM.s_Cash.Text(rdb_Cash);
            lngRPM.s_PaymentCard.Text(rdb_PaymentCard);
            lngRPM.s_Amount.Text(lbl_Amount);
            lngRPM.s_ToReturn.Text(lbl_ToReturn);
            lngRPM.s_AlreadyPaid.Text(rdb_AllreadyPayed);
            lngRPM.s_Print.Text(btn_Print);
            lngRPM.s_Amount.Text(lbl_Amount,":");
            lngRPM.s_AmountReceived.Text(lbl_AmountReceived,":");
            lngRPM.s_PaymentOnBankAccount.Text(rdb_BankAccountTransfer);
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
                PaymentType = GlobalData.ePaymentType.ALLREADY_PAID;
                SetPaymentMethod(lngRPM.s_AlreadyPaid.s);
            }
        }

        void rdb_PaymentCard_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_PaymentCard.Checked)
            {
                PaymentType = GlobalData.ePaymentType.PAYMENT_CARD;
                SetPaymentMethod(lngRPM.s_PaymentCard.s);
            }
        }

        public bool Init(InvoiceData xInvoiceData, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            m_InvoiceData = xInvoiceData;
            Invoice_ID = m_InvoiceData.m_ShopABC.m_CurrentInvoice.Invoice_ID;
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
                PaymentType = GlobalData.ePaymentType.CASH;
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
            DateTime_v DocInvoiceTime = new DateTime_v();
            DocInvoiceTime.v = DateTime.Now;
            if (PaymentType == GlobalData.ePaymentType.CASH)
            {
                DoPrint(PaymentType, sPaymentMethod, txt_AmountReceived.Text, txt_ToReturn.Text, DocInvoiceTime);
            }
            else
            {
                DoPrint(PaymentType, sPaymentMethod, null, null, DocInvoiceTime);
            }

            if (OK != null)
            {
                OK();
            }

        }

        private void DoPrint(GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            long DocInvoice_ID = -1;
            int xNumberInFinancialYear = -1;
            if (m_InvoiceData.Save(ref DocInvoice_ID, ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, ref xNumberInFinancialYear))
            {
                m_InvoiceData.Set_NumberInFinancialYear(xNumberInFinancialYear);

                if (m_InvoiceData.SetInvoiceTime(issue_time))
                {

                    if (Program.b_FVI_SLO)
                    {
                        string furs_XML = m_InvoiceData.Create_furs_InvoiceXML(false,Properties.Resources.FVI_SLO_Invoice,Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID,Properties.Settings.Default.ElectronicDevice_ID,Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID,"","");
                        Image img_QR = null;
                        string furs_UniqeMsgID = null;
                        string furs_UniqeInvID = null;
                        string furs_BarCodeValue = null;
                        if (Program.usrc_FVI_SLO1.Send_SingleInvoice(false,furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID,ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                        {
                            m_InvoiceData.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                            m_InvoiceData.FURS_EOR_v = new string_v(furs_UniqeInvID);
                            m_InvoiceData.FURS_QR_v = new string_v(furs_BarCodeValue);
                            m_InvoiceData.FURS_Image_QRcode = img_QR;
                            m_InvoiceData.Write_FURS_Response_Data();
                        }
                        else
                        {
                            string xSerialNumber = null;
                            string xSetNumber = null;
                            string xInvoiceNumber = null;
                            Program.usrc_FVI_SLO1.Write_SalesBookInvoice(m_InvoiceData.Invoice_ID_v.v, m_InvoiceData.FinancialYear, m_InvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
                            long FVI_SLO_SalesBookInvoice_ID = -1;
                            if (InvoiceDB.f_FVI_SLO_SalesBookInvoice.Get(m_InvoiceData.Invoice_ID_v.v, xSerialNumber, xSetNumber, xInvoiceNumber,ref FVI_SLO_SalesBookInvoice_ID))
                            {
                                MessageBox.Show("Račun je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");

                                //LK SalesBookInvoice  prestavi na gumb
                                //string furs_XML_SB = m_InvoiceData.Create_furs_SalesBookInvoiceXML(Program.usrc_FVI_SLO1.XML_Template_FVI_SLO_SalesBook, Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID, xSetNumber, xSerialNumber);
                                //if (Program.usrc_FVI_SLO1.Send_SingleInvoice(furs_XML_SB, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
                                //{
                                //    m_InvoiceData.FURS_Response_Data = new FURS_Response_data(furs_UniqeMsgID, furs_UniqeInvID, furs_BarCodeValue, img_QR);
                                //    m_InvoiceData.FURS_Response_Data.Image_QRcode = img_QR;
                                //    m_InvoiceData.Write_FURS_Response_Data();
                                //}
                            }
                        }
                    }
                }
                Print(ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
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
    }
}
