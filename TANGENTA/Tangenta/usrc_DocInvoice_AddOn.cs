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
    public partial class usrc_DocInvoice_AddOn : UserControl
    {

        private usrc_AddOn m_usrc_AddOn = null;
        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_OK();
        public event delegate_OK OK;

        private DocInvoice_AddOn m_AddOnDI;
        private bool m_bPrint;

        public usrc_DocInvoice_AddOn()
        {
            InitializeComponent();

            lngRPM.s_Cash.Text(rdb_Cash);
            lngRPM.s_PaymentCard.Text(this.rdb_CARD);
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
            this.rdb_BankAccountTransfer.CheckedChanged += Rdb_BankAccountTransfer_CheckedChanged;
            this.rdb_CARD.CheckedChanged += Rdb_CARD_CheckedChanged;
            this.rdb_AllreadyPayed.CheckedChanged += rdb_AllreadyPayed_CheckedChanged;

        }

        private void Rdb_CARD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                //SetPaymentMethod(lngRPM.s_PaymentCard.s);
            }
        }

        private void Rdb_BankAccountTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                this.txt_BankAccount.Enabled = true;
                this.btn_Select_BankAccount.Enabled = true;
            }
        }

        void rdb_AllreadyPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                //SetPaymentMethod(lngRPM.s_AlreadyPaid.s);
            }
        }


        public bool Init(DocInvoice_AddOn x_AddOnDI, bool bxPrint, usrc_AddOn x_usrc_AddOn) //, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            //m_InvoiceData = xInvoiceData;
            m_AddOnDI = x_AddOnDI;
            m_bPrint = bxPrint;
            m_usrc_AddOn = x_usrc_AddOn;
            if (m_bPrint)
            {
                lngRPM.s_Print.Text(this.btn_Print);
            }
            else
            {
                this.btn_Print.Text = "OK";
            }
            if (m_AddOnDI.Get(m_usrc_AddOn.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID))
            {
                if (m_AddOnDI.m_IssueDate != null)
                {
                    dtP_DateOfIssue.Value = m_AddOnDI.m_IssueDate.Date;
                }
                if (m_AddOnDI.m_MethodOfPayment != null)
                {
                    switch (m_AddOnDI.m_MethodOfPayment.eType)
                    {
                        case GlobalData.ePaymentType.CASH:
                            rdb_Cash.Checked = true;
                            break;
                        case GlobalData.ePaymentType.PAYMENT_CARD:
                            rdb_CARD.Checked = true;
                            break;
                        case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                            rdb_Cash.Checked = true;
                            break;
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            rdb_BankAccountTransfer.Checked = true;
                            txt_BankAccount.Text = SetBankAccountText();
                            break;
                    }
                }
                if (m_AddOnDI.m_TermsOfPayment != null)
                {
                    txt_PaymantConditionsDescription.Text = m_AddOnDI.m_TermsOfPayment.Description;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private string SetBankAccountText()
        {
            return "[" + m_AddOnDI.m_MethodOfPayment.BankAccount + "] " + m_AddOnDI.m_MethodOfPayment.BankName;
        }





        private void rdb_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Cash.Checked)
            {
                lbl_ToReturn.Visible = true;
                txt_ToReturn.Visible = true;
                lbl_AmountReceived.Visible = true;
                txt_AmountReceived.Visible = true;
            }
            else
            {
                lbl_ToReturn.Visible = false;
                txt_ToReturn.Visible = false;
                lbl_AmountReceived.Visible = false;
                txt_AmountReceived.Visible = false;
            }
        }



        private void rdb_Cash_MouseUp(object sender, MouseEventArgs e)
        {
            //Form_DocInvoice_PaymentCash pay_in_cash_frm = new Form_DocInvoice_PaymentCash(GrossSum);
            //if (pay_in_cash_frm.ShowDialog() == DialogResult.OK)
            //{
            //    //txt_ToReturn.Text = decimal.Round(pay_in_cash_frm.money - GrossSum, Currency_DecimalPlaces).ToString();
            //    //txt_AmountReceived.Text = pay_in_cash_frm.money.ToString();
            //    //lbl_ToReturn.Visible = true;
            //    //txt_ToReturn.Visible = true;
            //    //lbl_AmountReceived.Visible = true;
            //    //txt_AmountReceived.Visible = true;
            //    //SetPaymentMethod(lngRPM.s_Cash.s);
            //}
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //DateTime_v DocInvoiceTime = new DateTime_v();
            //DocInvoiceTime.v = DateTime.Now;
            //if (PaymentType == GlobalData.ePaymentType.CASH)
            //{
            //    DoPrint(PaymentType, sPaymentMethod, txt_AmountReceived.Text, txt_ToReturn.Text, DocInvoiceTime);
            //}
            //else
            //{
            //    DoPrint(PaymentType, sPaymentMethod, null, null, DocInvoiceTime);
            //}

            if (OK != null)
            {
                OK();
            }

        }

        //private void DoPrint(GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        //{
        //    long DocInvoice_ID = -1;
        //    int xNumberInFinancialYear = -1;
        //    if (m_InvoiceData.SaveDocInvoice(ref DocInvoice_ID, ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, ref xNumberInFinancialYear))
        //    {
        //        m_InvoiceData.Set_NumberInFinancialYear(xNumberInFinancialYear);

        //        if (m_InvoiceData.SetInvoiceTime(issue_time))
        //        {

        //            if (Program.b_FVI_SLO)
        //            {
        //                string furs_XML = m_InvoiceData.AddOnDI.Create_furs_InvoiceXML(false,
        //                                                                               Properties.Resources.FVI_SLO_Invoice,
        //                                                                               Program.usrc_FVI_SLO1.FursD_MyOrgTaxID,
        //                                                                               Program.usrc_FVI_SLO1.FursD_BussinesPremiseID,
        //                                                                               Properties.Settings.Default.ElectronicDevice_ID,
        //                                                                               Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID,
        //                                                                               "","",
        //                                                                               m_InvoiceData.IssueDate_v,
        //                                                                               m_InvoiceData.NumberInFinancialYear,
        //                                                                               m_InvoiceData.GrossSum,
        //                                                                               m_InvoiceData.taxSum,
        //                                                                               m_InvoiceData.Invoice_Author
        //                                                                               );
        //                Image img_QR = null;
        //                string furs_UniqeMsgID = null;
        //                string furs_UniqeInvID = null;
        //                string furs_BarCodeValue = null;
        //                if (Program.usrc_FVI_SLO1.Send_SingleInvoice(false,furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID,ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
        //                {
        //                    m_InvoiceData.AddOnDI.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
        //                    m_InvoiceData.AddOnDI.FURS_EOR_v = new string_v(furs_UniqeInvID);
        //                    m_InvoiceData.AddOnDI.FURS_QR_v = new string_v(furs_BarCodeValue);
        //                    m_InvoiceData.AddOnDI.FURS_Image_QRcode = img_QR;
        //                    m_InvoiceData.AddOnDI.Write_FURS_Response_Data(m_InvoiceData.DocInvoice_ID);
        //                }
        //                else
        //                {
        //                    string xSerialNumber = null;
        //                    string xSetNumber = null;
        //                    string xInvoiceNumber = null;
        //                    Program.usrc_FVI_SLO1.Write_SalesBookInvoice(m_InvoiceData.DocInvoice_ID_v.v, m_InvoiceData.FinancialYear, m_InvoiceData.NumberInFinancialYear, ref xSerialNumber, ref xSetNumber, ref xInvoiceNumber);
        //                    long FVI_SLO_SalesBookInvoice_ID = -1;
        //                    if (TangentaDB.f_FVI_SLO_SalesBookInvoice.Get(m_InvoiceData.DocInvoice_ID_v.v, xSerialNumber, xSetNumber, xInvoiceNumber,ref FVI_SLO_SalesBookInvoice_ID))
        //                    {
        //                        MessageBox.Show("Račun je zabeležen v tabeli za pošiljanje računov iz vezane knjige računov! ");

        //                        //LK SalesBookInvoice  prestavi na gumb
        //                        //string furs_XML_SB = m_InvoiceData.Create_furs_SalesBookInvoiceXML(Program.usrc_FVI_SLO1.XML_Template_FVI_SLO_SalesBook, Program.usrc_FVI_SLO1.FursD_MyOrgTaxID, Program.usrc_FVI_SLO1.FursD_BussinesPremiseID, xSetNumber, xSerialNumber);
        //                        //if (Program.usrc_FVI_SLO1.Send_SingleInvoice(furs_XML_SB, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR) == FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK)
        //                        //{
        //                        //    m_InvoiceData.FURS_Response_Data = new FURS_Response_data(furs_UniqeMsgID, furs_UniqeInvID, furs_BarCodeValue, img_QR);
        //                        //    m_InvoiceData.FURS_Response_Data.Image_QRcode = img_QR;
        //                        //    m_InvoiceData.Write_FURS_Response_Data();
        //                        //}
        //                    }
        //                }
        //            }
        //        }
        //        Print(ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
        //    }
        //}


        //private void Print(GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        //{
        //    if (ePaymentType == GlobalData.ePaymentType.CASH)
        //    {
        //        Program.usrc_TangentaPrint1.Print_Receipt(m_InvoiceData, ePaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
        //    }
        //    else
        //    {
        //        Program.usrc_TangentaPrint1.Print_Receipt(m_InvoiceData, ePaymentType, sPaymentMethod, null, null, issue_time);
        //    }
        //}


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }
    }
}
