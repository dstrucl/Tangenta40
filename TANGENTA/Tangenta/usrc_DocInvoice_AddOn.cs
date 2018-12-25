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
using HUDCMS;

namespace Tangenta
{
    public partial class usrc_DocInvoice_AddOn : UserControl
    {

        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public delegate void delegate_Issue();
        public event delegate_Issue Issue;

        private DocInvoice_AddOn m_AddOnDI;

        private usrc_AddOn m_usrc_AddOn = null;

        private bool m_bPrint;

        public usrc_DocInvoice_AddOn()
        {
            InitializeComponent();

            lng.s_Cash.Text(rdb_Cash);
            lng.s_PaymentCard.Text(this.rdb_CARD);
            lng.s_AlreadyPaid.Text(rdb_AllreadyPayed);
            lng.s_PaymentOnBankAccount.Text(rdb_BankAccountTransfer);
            lng.s_lbl_DateOfInvoiceIssue.Text(lbl_DateOfIssue);
            lng.s_Payment_Deadline.Text(lbl_PaymentDeadline);
            lng.s_MethodOfPayment.Text(grp_MtehodOfPaymentType);
            lng.s_TermsOfPayment.Text(grp_TermsOfPayment);
            lng.s_Invoice_Issue.Text(btn_Invoice_Issue);

            this.rdb_Cash.CheckedChanged += new System.EventHandler(this.rdb_Cash_CheckedChanged);
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
                lng.s_Invoice_Issue.Text(this.btn_Invoice_Issue);
            }
            else
            {
                this.btn_Invoice_Issue.Text = lng.s_OK.s;
            }

            if (m_AddOnDI.Get(m_usrc_AddOn.docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID))
            {
                if (m_AddOnDI.m_IssueDate != null)
                {
                    dtP_DateOfIssue.Value = m_AddOnDI.m_IssueDate.Date;
                }

                if (m_AddOnDI.m_PaymentDeadline != null)
                {
                    dtP_PaymentDeadline.Value = m_AddOnDI.m_PaymentDeadline.Date;
                }

                if (m_AddOnDI.m_MethodOfPayment_DI != null)
                {
                    switch (m_AddOnDI.m_MethodOfPayment_DI.eType)
                    {
                        case GlobalData.ePaymentType.CASH:
                            rdb_Cash.Checked = true;
                            break;
                        case GlobalData.ePaymentType.CARD:
                            rdb_CARD.Checked = true;
                            break;
                        case GlobalData.ePaymentType.CASH_OR_CARD:
                            rdb_Cash.Checked = true;
                            break;
                        case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                            rdb_BankAccountTransfer.Checked = true;
                            txt_BankAccount.Text = SetBankAccountText();
                            Enable_BankAccountTransfer(true);
                            break;
                    }
                }
                if (m_AddOnDI.m_TermsOfPayment == null)
                {
                    // set default value !
                    m_AddOnDI.m_TermsOfPayment = new DocInvoice_AddOn.TermsOfPayment();
                    m_AddOnDI.m_TermsOfPayment.GetDefault();
                    if (m_AddOnDI.m_TermsOfPayment.Description.Length > 0)
                    {
                        txt_PaymantConditionsDescription.Text = m_AddOnDI.m_TermsOfPayment.Description;
                    }
                }
                else
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
            return "[" + m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount + "] " + m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName;
        }

        private void Rdb_CARD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_CARD.Checked)
            {
                Enable_BankAccountTransfer(false);
                if (m_AddOnDI.m_MethodOfPayment_DI==null)
                {
                    m_AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                m_AddOnDI.m_MethodOfPayment_DI.eType = GlobalData.ePaymentType.CARD;
            }
        }

        private void Rdb_BankAccountTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment_DI == null)
                {
                    m_AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                m_AddOnDI.m_MethodOfPayment_DI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                Enable_BankAccountTransfer(true);
            }
        }

        private void rdb_AllreadyPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment_DI == null)
                {
                    m_AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                m_AddOnDI.m_MethodOfPayment_DI.eType = GlobalData.ePaymentType.ALLREADY_PAID;
                Enable_BankAccountTransfer(false);

            }
        }


        private void rdb_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Cash.Checked)
            {
                if (m_AddOnDI.m_MethodOfPayment_DI == null)
                {
                    m_AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                m_AddOnDI.m_MethodOfPayment_DI.eType = GlobalData.ePaymentType.CASH;
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
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation(null);
            xnav.bDoModal = true;
            xnav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationAccount,
                                                                        " OrganisationAccount_$_org_$$Name desc", xnav);
            if (edt_Item_dlg.ShowDialog(this) == DialogResult.Yes)
            {
                if (this.m_AddOnDI.m_MethodOfPayment_DI == null)
                {
                    this.m_AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();

                }
                this.m_AddOnDI.m_MethodOfPayment_DI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                if (this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment==null)
                {
                    this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                }
                this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount_ID = edt_Item_dlg.BankAccount_ID;
                this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName = edt_Item_dlg.BankName;
                this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Tax_ID = edt_Item_dlg.Bank_Tax_ID;
                this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Registration_ID = edt_Item_dlg.Bank_Registration_ID;
                this.m_AddOnDI.m_MethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount = edt_Item_dlg.TRR;
                this.txt_BankAccount.Text = SetBankAccountText();
            }
        }

        private void btn_Select_Terms_of_Payment_Click(object sender, EventArgs e)
        {
            Select_Terms_of_Payment();
        }

        private void Select_Terms_of_Payment()
        {
            NavigationButtons.Navigation xnav = new NavigationButtons.Navigation(null);
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

        private void btn_Issue_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction("DocInvoice_AddOn_btn_Issue_Click", DBSync.DBSync.MyTransactionLog_delegates);

            if (m_AddOnDI.m_IssueDate == null)
            {
                m_AddOnDI.m_IssueDate = new DocInvoice_AddOn.IssueDate();
            }
            m_AddOnDI.m_IssueDate.Date = dtP_DateOfIssue.Value;

            m_AddOnDI.m_PaymentDeadline = null;
            if (m_AddOnDI.m_MethodOfPayment_DI != null)
            {
                if (m_AddOnDI.m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                {
                    if (m_AddOnDI.m_PaymentDeadline == null)
                    {
                        m_AddOnDI.m_PaymentDeadline = new DocInvoice_AddOn.PaymentDeadline();
                    }
                    m_AddOnDI.m_PaymentDeadline.Date = dtP_PaymentDeadline.Value;
                }
            }

            ltext ltMsg = null;
            m_AddOnDI.m_NoticeText = this.usrc_Notice1.NoticeText;
            if (m_AddOnDI.Completed(ref ltMsg))
            {
                if (m_AddOnDI.Set(m_usrc_AddOn.docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, ref ltMsg, transaction))
                {
                    if (Issue != null)
                    {
                        Issue();
                    }                 
                }
            }
            else
            {
                XMessage.Box.Show(this, false, ltMsg,MessageBoxIcon.Exclamation);
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
