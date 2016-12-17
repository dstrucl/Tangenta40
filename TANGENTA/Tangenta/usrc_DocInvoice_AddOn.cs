﻿#region LICENSE 
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
using CodeTables;
using TangentaTableClass;

namespace Tangenta
{
    public partial class usrc_DocInvoice_AddOn : UserControl
    {

        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_OK();
        public event delegate_OK OK;

        private DocInvoice_AddOn m_AddOnDI;

        private usrc_AddOn m_usrc_AddOn = null;

        private bool m_bPrint;

        public usrc_DocInvoice_AddOn()
        {
            InitializeComponent();

            lngRPM.s_Cash.Text(rdb_Cash);
            lngRPM.s_PaymentCard.Text(this.rdb_CARD);
            lngRPM.s_AlreadyPaid.Text(rdb_AllreadyPayed);
            lngRPM.s_Print.Text(btn_Print);
            lngRPM.s_PaymentOnBankAccount.Text(rdb_BankAccountTransfer);
            lngRPM.s_lbl_DateOfInvoiceIssue.Text(lbl_DateOfIssue);
            lngRPM.s_Payment_Deadline.Text(lbl_PaymentDeadline);
            lngRPM.s_MethodOfPayment.Text(grp_MtehodOfPaymentType);
            lngRPM.s_TermsOfPayment.Text(grp_TermsOfPayment);
            btn_Print.Text = "OK";


            this.rdb_Cash.CheckedChanged += new System.EventHandler(this.rdb_Cash_CheckedChanged);
            this.rdb_Cash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdb_Cash_MouseUp);
            this.rdb_BankAccountTransfer.CheckedChanged += Rdb_BankAccountTransfer_CheckedChanged;
            this.rdb_CARD.CheckedChanged += Rdb_CARD_CheckedChanged;
            this.rdb_AllreadyPayed.CheckedChanged += rdb_AllreadyPayed_CheckedChanged;
            this.lbl_PaymentDeadline.Enabled = false;
            this.dtP_PaymentDeadline.Enabled = false;
            this.dtP_DateOfIssue.Value = DateTime.Now;
            this.dtP_PaymentDeadline.Value = DateTime.Now.AddDays(8);
            this.txt_BankAccount.Enabled = false;
            btn_Select_BankAccount.Enabled = false;

        }

        private void Enable_BankAccountTransfer(bool bEnable)
        {
            txt_BankAccount.Enabled = bEnable;
            btn_Select_BankAccount.Enabled = bEnable;
            lbl_PaymentDeadline.Enabled = bEnable;
            dtP_PaymentDeadline.Enabled = bEnable;
        }

        public bool Init(DocInvoice_AddOn x_AddOnDI, bool bxPrint, usrc_AddOn x_usrc_AddOn) //, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            Enable_BankAccountTransfer(false);
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

                if (m_AddOnDI.m_PaymentDeadline != null)
                {
                    dtP_PaymentDeadline.Value = m_AddOnDI.m_PaymentDeadline.Date;
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
                            Enable_BankAccountTransfer(true);
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

        private void Rdb_CARD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_CARD.Checked)
            {
                Enable_BankAccountTransfer(false);
                if (m_AddOnDI.m_MethodOfPayment==null)
                {
                    m_AddOnDI.m_MethodOfPayment = new DocInvoice_AddOn.MethodOfPayment();
                }
                m_AddOnDI.m_MethodOfPayment.eType = GlobalData.ePaymentType.PAYMENT_CARD;
            }
        }

        private void Rdb_BankAccountTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment == null)
                {
                    m_AddOnDI.m_MethodOfPayment = new DocInvoice_AddOn.MethodOfPayment();
                }
                m_AddOnDI.m_MethodOfPayment.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                Enable_BankAccountTransfer(true);
            }
        }

        void rdb_AllreadyPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment == null)
                {
                    m_AddOnDI.m_MethodOfPayment = new DocInvoice_AddOn.MethodOfPayment();
                }
                m_AddOnDI.m_MethodOfPayment.eType = GlobalData.ePaymentType.ALLREADY_PAID;
                Enable_BankAccountTransfer(false);

            }
        }


        private void rdb_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Cash.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment == null)
                {
                    m_AddOnDI.m_MethodOfPayment = new DocInvoice_AddOn.MethodOfPayment();
                }
                m_AddOnDI.m_MethodOfPayment.eType = GlobalData.ePaymentType.CASH;
                Enable_BankAccountTransfer(false);
            }
            else
            {
            }
        }


        private void btn_Select_BankAccount_Click(object sender, EventArgs e)
        {
            Select_MyOrgBankAccount();
        }

        private void Select_MyOrgBankAccount()
        {
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation();
            xnav.bDoModal = true;
            xnav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationAccount,
                                                                        " OrganisationAccount_$_org_$$Name desc", xnav);
            if (edt_Item_dlg.ShowDialog(this) == DialogResult.Yes)
            {
                if (this.m_AddOnDI.m_MethodOfPayment == null)
                {
                    this.m_AddOnDI.m_MethodOfPayment = new DocInvoice_AddOn.MethodOfPayment();

                }
                this.m_AddOnDI.m_MethodOfPayment.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                this.m_AddOnDI.m_MethodOfPayment.BankAccount_ID = edt_Item_dlg.BankAccount_ID;
                this.m_AddOnDI.m_MethodOfPayment.BankName = edt_Item_dlg.BankName;
                this.m_AddOnDI.m_MethodOfPayment.Bank_Tax_ID = edt_Item_dlg.Bank_Tax_ID;
                this.m_AddOnDI.m_MethodOfPayment.Bank_Registration_ID = edt_Item_dlg.Bank_Registration_ID;
                this.m_AddOnDI.m_MethodOfPayment.BankAccount = edt_Item_dlg.TRR;
                this.txt_BankAccount.Text = SetBankAccountText();
            }
        }

        private void btn_Select_Terms_of_Payment_Click(object sender, EventArgs e)
        {
            Select_Terms_of_Payment();
        }

        private void Select_Terms_of_Payment()
        {
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation();
            xnav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            SQLTable tbl_TermsOfPayment = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TermsOfPayment)));
            Form_TermsOfPayment_Edit TermsOfPayment_dlg = new Form_TermsOfPayment_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_TermsOfPayment, "ID asc", xnav);
            if (TermsOfPayment_dlg.ShowDialog() == DialogResult.OK)
            {
                this.txt_PaymantConditionsDescription.Text = TermsOfPayment_dlg.Description;
                if (this.m_AddOnDI.m_TermsOfPayment == null)
                {
                    this.m_AddOnDI.m_TermsOfPayment = new DocInvoice_AddOn.TermsOfPayment();
                }
                this.m_AddOnDI.m_TermsOfPayment.ID = TermsOfPayment_dlg.TermsOfPayment_ID;
                this.m_AddOnDI.m_TermsOfPayment.Description = TermsOfPayment_dlg.Description;
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

            if (m_AddOnDI.m_IssueDate == null)
            {
                m_AddOnDI.m_IssueDate = new DocInvoice_AddOn.IssueDate();
            }
            m_AddOnDI.m_IssueDate.Date = dtP_DateOfIssue.Value;

            m_AddOnDI.m_PaymentDeadline = null;
            if (m_AddOnDI.m_MethodOfPayment != null)
            {
                if (m_AddOnDI.m_MethodOfPayment.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                {
                    if (m_AddOnDI.m_PaymentDeadline == null)
                    {
                        m_AddOnDI.m_PaymentDeadline = new DocInvoice_AddOn.PaymentDeadline();
                    }
                    m_AddOnDI.m_PaymentDeadline.Date = dtP_PaymentDeadline.Value;
                }
            }

            ltext ltMsg = null;
            if (m_AddOnDI.Set(m_usrc_AddOn.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref ltMsg))
            {
                if (ltMsg == null)
                {
                    if (OK != null)
                    {
                        OK();
                    }
                }
                else
                {
                    XMessage.Box.Show(this, false, ltMsg);
                }
            }
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

        private void txt_PaymantConditionsDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}