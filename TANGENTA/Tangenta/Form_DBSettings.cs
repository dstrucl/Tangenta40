using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDataBaseDef;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_DBSettings : Form
    {
        private NavigationButtons.Navigation nav = null;
        public string AdministratorLockedPassword { get { return this.usrc_Password1.Text; } }
        public bool MultiuserOperationWithLogin { get { return rdb_MultiUserOperation.Checked; } }
        public bool SingleUserLoginAsAdministrator { get { return chk_SingleUserLoginAsAdministrator.Checked; } }
        public bool StockCheckAtStartup { get {return chk_StockCheckAtStartup.Checked; } }
        public bool MultiCurrencyOperation { get { return chk_MultiCurrency.Checked; } }
        public bool ShopC_ExclusivelySellFromStock { get { return chk_ShopC_ExclusivelySellFromStock.Checked; }  }
        public int NumberOfMonthAfterNewYearToAllowCreateNewInvoice
        {
            get
            {
                try
                {
                    return Convert.ToInt32(nmUpDnOfMonthsInANewYearToAllowNewInvoice.Value);
                }
                catch
                {
                    nmUpDnOfMonthsInANewYearToAllowNewInvoice.Value = 1;
                    return 1;
                }
            }
        }



        public bool Changed = false;

        public Form_DBSettings(NavigationButtons.Navigation xnav,string AdministratorLockedPassword)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_DataBaseVersion.Text(lbl_DataBaseVersion, MyDataBase_Tangenta.VERSION);
            lng.s_Administrator_password.Text(lbl_Administrator_Password);
            lng.s_MultiuserOperationWithLogin.Text(rdb_MultiUserOperation);
            lng.s_StockCheckAtStartup.Text(chk_StockCheckAtStartup);
            lng.s_chk_ShopC_ExclusivelySellFromStock.Text(chk_ShopC_ExclusivelySellFromStock);
            lng.s_nmUpDn_NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Text(this.nmUpDnOfMonthsInANewYearToAllowNewInvoice);
            if (AdministratorLockedPassword == null)
            {
                this.usrc_Password1.Text =Password.Password.LockPassword("12345");
            }
            else
            {
                this.usrc_Password1.Text = AdministratorLockedPassword;
            }

            lng.s_grp_OperationMode.Text(grp_OperationMode);
            lng.s_rdb_MultiUser.Text(rdb_MultiUserOperation);
            lng.s_rdb_SingleUser.Text(rdb_SingleUser);
            lng.s_chk_LoginAsAdministrator.Text(chk_SingleUserLoginAsAdministrator);
            lng.s_MultiCurrency.Text(chk_MultiCurrency);

            rdb_MultiUserOperation.Checked = Program.OperationMode.MultiUser;
            rdb_SingleUser.Checked = !Program.OperationMode.MultiUser;
            chk_SingleUserLoginAsAdministrator.Checked = Program.OperationMode.SingleUserLoginAsAdministrator;
            chk_ShopC_ExclusivelySellFromStock.Checked = Program.OperationMode.ShopC_ExclusivelySellFromStock;
            chk_StockCheckAtStartup.Checked = Program.OperationMode.StockCheckAtStartup;
            chk_MultiCurrency.Checked = Program.OperationMode.MultiCurrency;
            nmUpDnOfMonthsInANewYearToAllowNewInvoice.Value = Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice;

            if (rdb_SingleUser.Checked)
            {
                chk_SingleUserLoginAsAdministrator.Enabled = true;
                usrc_Password1.Enabled = true;
            }
            else
            {
                chk_SingleUserLoginAsAdministrator.Enabled = false;
                usrc_Password1.Enabled = false;
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (do_OK())
                            {
                            }
                            else
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;

                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
            }
        }

        private bool do_OK()
        {
            if (usrc_Password1.Match())
            {
                ID DBSettings_ID = null;
                Transaction transaction_Form_DBSettings_do_OK = new Transaction("Form_DBSettings_do_OK");

                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, usrc_Password1.Text, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                {
                    string sbMultiUserOperation = "0";
                    string sbStockCheckAtStartup = "0";
                    string sbSingleUserLoginAsAdministrator = "0";
                    string sbShopC_ExclusivelySellFromStock = "0";
                    string sbMultiCurrencyOperation = "0";

                    if (rdb_MultiUserOperation.Checked)
                    {
                        sbMultiUserOperation = "1";
                    }
                    else
                    {
                        Properties.Settings.Default.RecordCashierActivity = false;
                        Properties.Settings.Default.Save();
                    }

                    if (chk_StockCheckAtStartup.Checked)
                    {
                        sbStockCheckAtStartup = "1";
                    }

                    if (chk_SingleUserLoginAsAdministrator.Checked)
                    {
                        sbSingleUserLoginAsAdministrator = "1";
                    }

                    if (chk_ShopC_ExclusivelySellFromStock.Checked)
                    {
                        sbShopC_ExclusivelySellFromStock = "1";
                    }

                    if (chk_MultiCurrency.Checked)
                    {
                        sbShopC_ExclusivelySellFromStock = "1";
                    }

                    int iNumberOfMonthAfterNewYearToAllowCreateNewInvoice = Convert.ToInt32(nmUpDnOfMonthsInANewYearToAllowNewInvoice.Value);
                    string sbNumberOfMonthAfterNewYearToAllowCreateNewInvoice = iNumberOfMonthAfterNewYearToAllowCreateNewInvoice.ToString();

                    if ((rdb_MultiUserOperation.Checked!= Program.OperationMode.MultiUser)
                        ||(chk_StockCheckAtStartup.Checked!= Program.OperationMode.StockCheckAtStartup)
                        || (chk_SingleUserLoginAsAdministrator.Checked != Program.OperationMode.SingleUserLoginAsAdministrator)
                        || (chk_ShopC_ExclusivelySellFromStock.Checked != Program.OperationMode.ShopC_ExclusivelySellFromStock)
                        || (chk_MultiCurrency.Checked != Program.OperationMode.MultiCurrency)
                        || (iNumberOfMonthAfterNewYearToAllowCreateNewInvoice != Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice))
                    {
                        Changed = true;
                    }

                   
                    if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, sbMultiUserOperation, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                    {
                        Program.OperationMode.MultiUser = rdb_MultiUserOperation.Checked;

                        if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name, sbStockCheckAtStartup, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                        {
                            Program.OperationMode.StockCheckAtStartup = chk_StockCheckAtStartup.Checked;

                            if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.SingleUserLoginAsAdministrator.Name, sbSingleUserLoginAsAdministrator, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                            {
                                Program.OperationMode.SingleUserLoginAsAdministrator = chk_SingleUserLoginAsAdministrator.Checked;

                                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name, sbShopC_ExclusivelySellFromStock, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                                {
                                    Program.OperationMode.ShopC_ExclusivelySellFromStock = chk_ShopC_ExclusivelySellFromStock.Checked;

                                    if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiCurrencyOperation.Name, sbMultiCurrencyOperation, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                                    {
                                        Program.OperationMode.MultiCurrency = chk_MultiCurrency.Checked;
                                        if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.NumberOfMonthAfterNewYearToAllowCreateNewInvoice.Name, sbNumberOfMonthAfterNewYearToAllowCreateNewInvoice, "0", ref DBSettings_ID, transaction_Form_DBSettings_do_OK))
                                        {
                                            transaction_Form_DBSettings_do_OK.Commit();
                                            Program.OperationMode.NumberOfMonthAfterNewYearToAllowCreateNewInvoice = iNumberOfMonthAfterNewYearToAllowCreateNewInvoice;
                                            Close();
                                            DialogResult = DialogResult.OK;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                transaction_Form_DBSettings_do_OK.Rollback();
            }
            else
            {
                MessageBox.Show(this, lng.s_Password_does_not_match.s);
            }
            return false;
        }
        private void do_Cancel()
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void rdb_MultiUserOperation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_MultiUserOperation.Checked)
            {
                chk_SingleUserLoginAsAdministrator.Enabled = false;
                usrc_Password1.Enabled = false;
            }
            else
            {
                chk_SingleUserLoginAsAdministrator.Enabled = true;
                usrc_Password1.Enabled = true;
            }
        }

        private void usrc_Password1_PasswordTextChanged(object sender, EventArgs e)
        {
            Changed = true;
        }
    }
}