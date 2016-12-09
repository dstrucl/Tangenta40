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

        private long m_OrganisationAccount_ID = 0;
        public long OrganisationAccount_ID
        {
            get { return m_OrganisationAccount_ID; }
        }

        private string m_BankName = null;
        public string BankName
        {
            get { return m_BankName; }
        }

        private string m_TRR = null;
        public string TRR
        {
            get { return m_TRR; }
        }

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

        public string m_MethodOfPayment = null;
        public string MethodOfPayment
        {
            get { return m_MethodOfPayment; }
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
            lngRPM.s_grp_ValidityOfTheTender.Text(grp_ValidityOfTheTender);
            lngRPM.s_rbtn_NumberOf.Text(rdb_ValidNumberOf);
            lngRPM.s_rdb_Valid_Tender_Until.Text(rdb_Valid_Tender_Until);
            lngRPM.s_Print.Text(btn_Print);
            rdb_BankAccountTransfer.CheckedChanged += Rdb_BankAccountTransfer_CheckedChanged;
            rdb_BankAccountTransfer.Checked = true;

            
            rdb_Valid_Tender_Until.CheckedChanged += Rdb_Valid_Tender_Until_CheckedChanged;
            rdb_ValidNumberOf.CheckedChanged += Rdb_ValidNumberOf_CheckedChanged;
            rdb_ValidNumberOf.Checked = true;
            cmb_DaysOrMonths.Items.Add(lngRPM.s_Number_Of_Months.s);
            cmb_DaysOrMonths.Items.Add(lngRPM.s_Number_Of_Days.s);
            cmb_DaysOrMonths.SelectedIndex = 0;
            nmUpDn_NumberOfDaysOrMonths.Value = 1;
            CalculateValidUntilDate();
        }

        private void Rdb_ValidNumberOf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ValidNumberOf.Checked)
            {
                this.cmb_DaysOrMonths.Enabled = true;
                this.nmUpDn_NumberOfDaysOrMonths.Enabled = true;
                this.dtP_TenderValidUntil.Enabled = false;
            }
            else
            {
                this.cmb_DaysOrMonths.Enabled = false;
                this.nmUpDn_NumberOfDaysOrMonths.Enabled = false;
            }
        }

        private void Rdb_Valid_Tender_Until_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Valid_Tender_Until.Checked)
            {
                this.cmb_DaysOrMonths.Enabled = false;
                this.nmUpDn_NumberOfDaysOrMonths.Enabled = false;
                this.dtP_TenderValidUntil.Enabled = true;
            }
            else
            {
                this.dtP_TenderValidUntil.Enabled = false;
            }
        }

        private void Rdb_BankAccountTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                txt_BankAccount.Enabled = true;
                btn_Select_BankAccount.Enabled = true;
            }
            else
            {
                txt_BankAccount.Enabled = false;
                btn_Select_BankAccount.Enabled = false;
            }

        }

        public bool Init(InvoiceData xInvoiceData, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            m_InvoiceData = xInvoiceData;
            DocInvoice_ID = m_InvoiceData.m_ShopABC.m_CurrentInvoice.Doc_ID;
            Currency_DecimalPlaces = xCurrency_DecimalPlaces;
            GrossSum = xGrossSum;
            return true;
        }





        private void btn_Print_Click(object sender, EventArgs e)
        {
            DateTime_v DocProformaInvoiceTime = new DateTime_v();
            DocProformaInvoiceTime.v = DateTime.Now;
            DocDurationType = 2;
            if (rdb_ValidNumberOf.Checked)
            {
                if (cmb_DaysOrMonths.SelectedIndex==0)
                {
                    DocDurationType = 0;
                }
                else if (cmb_DaysOrMonths.SelectedIndex == 1)
                {
                    DocDurationType = 1;
                }
                DocDuration = Convert.ToInt64(nmUpDn_NumberOfDaysOrMonths.Value);
            }
            if (rdb_BankAccountTransfer.Checked)
            {
                PaymentType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
            }
            else
            {
                PaymentType = GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD;
            }



            if (f_MethodOfPayment.Get(PaymentType, ref m_MethodOfPayment_ID, ref m_MethodOfPayment))
            {
                DoPrint(PaymentType, MethodOfPayment_ID, DocDuration, DocDurationType, TermsOfPayment_ID, DocProformaInvoiceTime);
                if (OK != null)
                {
                    OK();
                }
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
            Program.usrc_TangentaPrint1.Print_Receipt(m_InvoiceData, ePaymentType, sPaymentMethod, null, null, issue_time);
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
            if (edt_Item_dlg.ShowDialog(this)==DialogResult.Yes)
            {
                this.m_OrganisationAccount_ID = edt_Item_dlg.OgranisationAccount_ID;
                this.m_BankName = edt_Item_dlg.BankName;
                this.m_TRR = edt_Item_dlg.TRR;
                this.txt_BankAccount.Text = this.TRR + " ," + this.BankName;
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
                m_TermsOfPayment_ID = TermsOfPayment_dlg.TermsOfPayment_ID;
            }
        }

        private void dtP_TenderValidUntil_ValueChanged(object sender, EventArgs e)
        {

        }
        private void CalculateValidUntilDate()
        {
            if (rdb_ValidNumberOf.Checked)
            {
                DateTime dtnow = DateTime.Now;
                DateTime dtValidUntil;
                if (cmb_DaysOrMonths.SelectedIndex == 0)
                {
                    int iMonths = Convert.ToInt32(nmUpDn_NumberOfDaysOrMonths.Value);
                    dtValidUntil = dtnow.AddMonths(iMonths);
                    dtP_TenderValidUntil.Value = dtValidUntil;
                }
                else if (cmb_DaysOrMonths.SelectedIndex == 0)
                {
                    int iDays = Convert.ToInt32(nmUpDn_NumberOfDaysOrMonths.Value);
                    dtValidUntil = dtnow.AddDays(iDays);
                    dtP_TenderValidUntil.Value = dtValidUntil;
                }
            }
        }

        private void cmb_DaysOrMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateValidUntilDate();
        }

        private void nmUpDn_NumberOfDaysOrMonths_ValueChanged(object sender, EventArgs e)
        {
            CalculateValidUntilDate();
        }
    }
}
