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

        private DocInvoice_AddOn m_AddOnDI = null;
        private DocInvoice_AddOn AddOnDI
        {
            get
            {
                return m_AddOnDI;
            }
            set
            {
                m_AddOnDI = value;
            }
        }

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
            AddOnDI = x_AddOnDI;
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

            if (AddOnDI.Get(m_usrc_AddOn.docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID))
            {
                if (AddOnDI.MyIssueDate != null)
                {
                    dtP_DateOfIssue.Value = AddOnDI.MyIssueDate.Date;
                }

                if (AddOnDI.MyPaymentDeadline != null)
                {
                    dtP_PaymentDeadline.Value = AddOnDI.MyPaymentDeadline.Date;
                }

                if (AddOnDI.MyMethodOfPayment_DI != null)
                {
                    switch (AddOnDI.MyMethodOfPayment_DI.eType)
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
                if (AddOnDI.MyTermsOfPayment == null)
                {
                    // set default value !
                    AddOnDI.MyTermsOfPayment = new DocInvoice_AddOn.TermsOfPayment();
                    AddOnDI.MyTermsOfPayment.GetDefault();
                    if (AddOnDI.MyTermsOfPayment.Description.Length > 0)
                    {
                        txt_PaymantConditionsDescription.Text = AddOnDI.MyTermsOfPayment.Description;
                    }
                }
                else
                {
                    txt_PaymantConditionsDescription.Text = AddOnDI.MyTermsOfPayment.Description;
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
            return "[" + AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount + "] " + AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName;
        }

        private void Rdb_CARD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_CARD.Checked)
            {
                Enable_BankAccountTransfer(false);
                if (AddOnDI.MyMethodOfPayment_DI==null)
                {
                    AddOnDI.MyMethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                AddOnDI.MyMethodOfPayment_DI.eType = GlobalData.ePaymentType.CARD;
            }
        }

        private void Rdb_BankAccountTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_BankAccountTransfer.Checked)
            {
                if (AddOnDI.MyMethodOfPayment_DI == null)
                {
                    AddOnDI.MyMethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                AddOnDI.MyMethodOfPayment_DI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                Enable_BankAccountTransfer(true);
            }
        }

        private void rdb_AllreadyPayed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_AllreadyPayed.Checked)
            {
                if (AddOnDI.MyMethodOfPayment_DI == null)
                {
                    AddOnDI.MyMethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                AddOnDI.MyMethodOfPayment_DI.eType = GlobalData.ePaymentType.ALLREADY_PAID;
                Enable_BankAccountTransfer(false);

            }
        }


        private void rdb_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Cash.Checked)
            {
                if (AddOnDI.MyMethodOfPayment_DI == null)
                {
                    AddOnDI.MyMethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                }
                AddOnDI.MyMethodOfPayment_DI.eType = GlobalData.ePaymentType.CASH;
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
                if (this.AddOnDI.MyMethodOfPayment_DI == null)
                {
                    this.AddOnDI.MyMethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();

                }
                this.AddOnDI.MyMethodOfPayment_DI.eType = GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER;
                if (this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment==null)
                {
                    this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                }
                this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount_ID = edt_Item_dlg.BankAccount_ID;
                this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName = edt_Item_dlg.BankName;
                this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Tax_ID = edt_Item_dlg.Bank_Tax_ID;
                this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Registration_ID = edt_Item_dlg.Bank_Registration_ID;
                this.AddOnDI.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount = edt_Item_dlg.TRR;
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
                if (this.AddOnDI.MyTermsOfPayment == null)
                {
                    this.AddOnDI.MyTermsOfPayment = new DocInvoice_AddOn.TermsOfPayment();
                }
                this.AddOnDI.MyTermsOfPayment.ID = TermsOfPayment_dlg.TermsOfPayment_ID;
                this.AddOnDI.MyTermsOfPayment.Description = TermsOfPayment_dlg.Description;
            }
        }

        private void btn_Issue_Click(object sender, EventArgs e)
        {
           
            if (AddOnDI.MyIssueDate == null)
            {
                AddOnDI.MyIssueDate = new DocInvoice_AddOn.IssueDate();
            }
            AddOnDI.MyIssueDate.Date = dtP_DateOfIssue.Value;

            AddOnDI.MyPaymentDeadline = null;
            if (AddOnDI.MyMethodOfPayment_DI != null)
            {
                if (AddOnDI.MyMethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                {
                    if (AddOnDI.MyPaymentDeadline == null)
                    {
                        AddOnDI.MyPaymentDeadline = new DocInvoice_AddOn.PaymentDeadline();
                    }
                    AddOnDI.MyPaymentDeadline.Date = dtP_PaymentDeadline.Value;
                }
            }

            ltext ltMsg = null;
            AddOnDI.m_NoticeText = this.usrc_Notice1.NoticeText;
            if (AddOnDI.Completed(ref ltMsg))
            {
                Transaction transaction_usrc_DocInvoice_AddOn_Set = DBSync.DBSync.NewTransaction("usrc_DocInvoice_AddOn_Set");
                if (m_AddOnDI.Set(m_usrc_AddOn.docM.DocE.m_ShopABC.m_CurrentDoc.Doc_ID, transaction_usrc_DocInvoice_AddOn_Set))
                {
                    if (transaction_usrc_DocInvoice_AddOn_Set.Commit())
                    {
                        if (Issue != null)
                        {
                            Issue();
                        }
                    }
                }
                else
                {
                    transaction_usrc_DocInvoice_AddOn_Set.Rollback();
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
