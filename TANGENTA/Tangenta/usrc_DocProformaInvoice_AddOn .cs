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
using CodeTables;
using TangentaTableClass;

namespace Tangenta
{
    public partial class usrc_DocProformaInvoice_AddOn : UserControl
    {
        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_OK();
        public event delegate_OK OK;

        public DocProformaInvoice_AddOn m_AddOnDPI = null;

        private usrc_AddOn m_usrc_AddOn = null;

        private bool m_bPrint = false;

        public usrc_DocProformaInvoice_AddOn()
        {
            InitializeComponent();
            lngRPM.s_MethodOfPayment.Text(this.grp_MtehodOfPaymentType);
            lngRPM.s_Payment_on_bank_account.Text(rdb_BankAccountTransfer);
            lngRPM.s_Payment_by_cash_or_card_on_delivery.Text(rdb_Payment_by_cash_or_credit_card_on_delivery);
            lngRPM.s_TermsOfPayment.Text(grp_TermsOfPayment);
            lngRPM.s_grp_ValidityOfTheTender.Text(grp_ValidityOfTheTender);
            lngRPM.s_rbtn_NumberOf.Text(rdb_ValidNumberOf);
            lngRPM.s_rdb_Valid_Tender_Until.Text(rdb_Valid_Tender_Until);
            lngRPM.s_lbl_DateOfProformaInvoiceIssue.Text(lbl_DateOfIssue);
            lngRPM.s_Invoice_Issue.Text(btn_ProformaInvoice_Issue);
            //lngRPM.s_btn_Select_BankAccount.Text(btn_Select_BankAccount);

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

        private string SetBankAccountText()
        {
            return "[" + m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount + "] " + m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankName;
        }

        public bool Init(DocProformaInvoice_AddOn x_AddOnDI,bool bxPrint, usrc_AddOn x_usrc_AddOn) //, int xCurrency_DecimalPlaces, decimal xGrossSum)
        {
            //m_InvoiceData = xInvoiceData;
            m_AddOnDPI = x_AddOnDI;
            m_bPrint = bxPrint;
            m_usrc_AddOn = x_usrc_AddOn;
            if (m_bPrint)
            {
                lngRPM.s_ProformaInvoice_Issue.Text(this.btn_ProformaInvoice_Issue);
            }
            else
            {
                lngRPM.s_OK.Text(this.btn_ProformaInvoice_Issue);
            }

            if (m_AddOnDPI.Get(m_usrc_AddOn.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID))
            {
                if (m_AddOnDPI.m_IssueDate != null)
                {
                    dtP_DateOfIssue.Value = m_AddOnDPI.m_IssueDate.Date;
                }
                if (m_AddOnDPI.m_MethodOfPayment_DPI != null)
                {
                    switch (m_AddOnDPI.m_MethodOfPayment_DPI.eType)
                    {
                        case GlobalData.ePaymentType.CASH:
                        case GlobalData.ePaymentType.CARD:
                        case GlobalData.ePaymentType.CASH_OR_CARD:
                            rdb_Payment_by_cash_or_credit_card_on_delivery.Checked = true;
                            break;
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            rdb_BankAccountTransfer.Checked = true;
                            txt_BankAccount.Text = SetBankAccountText();
                            break;
                    }
                }
                if (m_AddOnDPI.m_TermsOfPayment != null)
                {
                    txt_PaymantConditionsDescription.Text = m_AddOnDPI.m_TermsOfPayment.Description;
                }
                if (m_AddOnDPI.m_Duration != null)
                {
                    switch (m_AddOnDPI.m_Duration.type)
                    {
                        case 0: //length in months
                            rdb_ValidNumberOf.Checked = true;
                            cmb_DaysOrMonths.SelectedIndex = 0;
                            nmUpDn_NumberOfDaysOrMonths.Value = m_AddOnDPI.m_Duration.length;
                            dtP_TenderValidUntil.Value = m_AddOnDPI.m_IssueDate.Date.AddMonths((Convert.ToInt32(m_AddOnDPI.m_Duration.length)));
                            break;
                        case 1: //length in days
                            rdb_ValidNumberOf.Checked = true;
                            cmb_DaysOrMonths.SelectedIndex = 1;
                            nmUpDn_NumberOfDaysOrMonths.Value = m_AddOnDPI.m_Duration.length;
                            dtP_TenderValidUntil.Value = m_AddOnDPI.m_IssueDate.Date.AddDays((Convert.ToInt32(m_AddOnDPI.m_Duration.length)));
                            break;
                        case 2: //days from IssueDate to end date
                            rdb_Valid_Tender_Until.Checked = true;
                            cmb_DaysOrMonths.SelectedIndex = 1;
                            nmUpDn_NumberOfDaysOrMonths.Value = m_AddOnDPI.m_Duration.length;
                            dtP_TenderValidUntil.Value = m_AddOnDPI.m_IssueDate.Date.AddDays((Convert.ToInt32(m_AddOnDPI.m_Duration.length)));
                            break;
                    }

                }
                return true;
            }
            else
            {
                return false;
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
                if (this.m_AddOnDPI.m_MethodOfPayment_DPI==null)
                {
                    this.m_AddOnDPI.m_MethodOfPayment_DPI = new DocProformaInvoice_AddOn.MethodOfPayment_DPI();
                     
                }
                this.m_AddOnDPI.m_MethodOfPayment_DPI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                if (this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment==null)
                {
                    this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                }
                this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount_ID = edt_Item_dlg.BankAccount_ID;
                this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankName = edt_Item_dlg.BankName;
                this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.Bank_Tax_ID = edt_Item_dlg.Bank_Tax_ID;
                this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.Bank_Registration_ID = edt_Item_dlg.Bank_Registration_ID;
                this.m_AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount = edt_Item_dlg.TRR;
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
                if (this.m_AddOnDPI.m_TermsOfPayment==null)
                {
                    this.m_AddOnDPI.m_TermsOfPayment = new DocProformaInvoice_AddOn.TermsOfPayment();
                }
                this.m_AddOnDPI.m_TermsOfPayment.ID = TermsOfPayment_dlg.TermsOfPayment_ID;
                this.m_AddOnDPI.m_TermsOfPayment.Description = TermsOfPayment_dlg.Description;
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

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            if (m_AddOnDPI.m_IssueDate==null)
            {
                m_AddOnDPI.m_IssueDate = new DocProformaInvoice_AddOn.IssueDate();
            }
            m_AddOnDPI.m_IssueDate.Date = dtP_DateOfIssue.Value;



            if (m_AddOnDPI.m_Duration == null)
            {
                m_AddOnDPI.m_Duration = new DocProformaInvoice_AddOn.Duration();
            }
            if (rdb_ValidNumberOf.Checked)
            {
                if (cmb_DaysOrMonths.SelectedIndex==0)
                {
                    m_AddOnDPI.m_Duration.type = 0;
                }
                else if (cmb_DaysOrMonths.SelectedIndex == 1)
                {
                    m_AddOnDPI.m_Duration.type = 1;
                }

                m_AddOnDPI.m_Duration.length = Convert.ToInt64(nmUpDn_NumberOfDaysOrMonths.Value);
            }
            else
            {
                DateTime dtValidUntil = this.dtP_TenderValidUntil.Value;
                if (dtValidUntil > m_AddOnDPI.m_IssueDate.Date)
                {
                    m_AddOnDPI.m_Duration.type = 2;
                    TimeSpan ts = dtValidUntil - m_AddOnDPI.m_IssueDate.Date;
                    m_AddOnDPI.m_Duration.length = ts.Days;
                }
                else
                {
                    XMessage.Box.Show(this,false,lngRPM.s_DocProformaInvoice_ValidToDate_must_be_later_than_IssueDay);
                    return;
                }
            }

            m_AddOnDPI.m_NoticeText = usrc_Notice1.NoticeText;

            ltext ltMsg = null;
            if (m_AddOnDPI.Completed(ref ltMsg))
            {
                if (m_AddOnDPI.Set(m_usrc_AddOn.m_usrc_Invoice.m_ShopABC.m_CurrentInvoice.Doc_ID, ref ltMsg))
                {

                    if (OK != null)
                    {
                        OK();
                    }
                }
            }
            else
            {
               XMessage.Box.Show(this, false, ltMsg);
            }
        }

        private void rdb_Payment_by_cash_or_credit_card_on_delivery_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Payment_by_cash_or_credit_card_on_delivery.Checked)
            {
                if (m_AddOnDPI != null)
                {
                    if (m_AddOnDPI.m_MethodOfPayment_DPI == null)
                    {
                        m_AddOnDPI.m_MethodOfPayment_DPI = new DocProformaInvoice_AddOn.MethodOfPayment_DPI();
                    }
                    m_AddOnDPI.m_MethodOfPayment_DPI.eType = GlobalData.ePaymentType.CASH_OR_CARD;
                }
            }
        }

        private void rdb_BankAccountTransfer_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                if (m_AddOnDPI != null)
                {
                    if (m_AddOnDPI.m_MethodOfPayment_DPI == null)
                    {
                        m_AddOnDPI.m_MethodOfPayment_DPI = new DocProformaInvoice_AddOn.MethodOfPayment_DPI();
                    }
                    m_AddOnDPI.m_MethodOfPayment_DPI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                }
            }
        }
    }
}
