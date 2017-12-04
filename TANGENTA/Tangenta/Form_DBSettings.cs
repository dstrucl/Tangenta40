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
        NavigationButtons.Navigation nav = null;
        public string AdministratorLockedPassword { get { return this.usrc_Password1.Text; } }
        public bool MultiuserOperationWithLogin { get { return rdb_MultiUserOperation.Checked; } }
        public bool SingleUserLoginAsAdministrator { get { return chk_SingleUserLoginAsAdministrator.Checked; } }
        public bool StockCheckAtStartup { get {return chk_StockCheckAtStartup.Checked; } }
        public bool Changed = false;

        public Form_DBSettings(NavigationButtons.Navigation xnav,string AdministratorLockedPassword, bool bMultiuserOperation,bool bStockCheckAtStartup)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_DataBaseVersion.Text(lbl_DataBaseVersion, MyDataBase_Tangenta.VERSION);
            lng.s_Administrator_password.Text(lbl_Administrator_Password);
            lng.s_MultiuserOperationWithLogin.Text(rdb_MultiUserOperation);
            lng.s_StockCheckAtStartup.Text(chk_StockCheckAtStartup);
            lng.s_chk_ShopC_ExclusivelySellFromStock.Text(chk_ShopC_ExclusivelySellFromStock);
            if (AdministratorLockedPassword == null)
            {
                this.usrc_Password1.Text =Password.Password.LockPassword("12345");
            }
            else
            {
                this.usrc_Password1.Text = AdministratorLockedPassword;
            }
            rdb_MultiUserOperation.Checked = bMultiuserOperation;
            chk_StockCheckAtStartup.Checked = bStockCheckAtStartup;

            lng.s_grp_OperationMode.Text(grp_OperationMode);
            lng.s_rdb_MultiUser.Text(rdb_MultiUserOperation);
            lng.s_rdb_SingleUser.Text(rdb_SingleUser);
            lng.s_chk_LoginAsAdministrator.Text(chk_SingleUserLoginAsAdministrator);

            rdb_MultiUserOperation.Checked = Program.OperationMode.MultiUser;
            rdb_SingleUser.Checked = !Program.OperationMode.MultiUser;
            chk_SingleUserLoginAsAdministrator.Checked = Program.OperationMode.SingleUserLoginAsAdministrator;
            chk_ShopC_ExclusivelySellFromStock.Checked = Program.OperationMode.ShopC_ExclusivelySellFromStock;

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
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            break;

                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;

                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            nav.eExitResult = evt;
                            break;
                    }
                    break;
            }
        }

        private bool do_OK()
        {
            if (usrc_Password1.Match())
            {
                long DBSettings_ID = -1;
                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.AdminPassword.Name, usrc_Password1.Text, "0", ref DBSettings_ID))
                {
                    string sbMutiuserOperation = "0";
                    string sbStockCheckAtStartup = "0";
                    string sbSingleUserLoginAsAdministrator = "0";
                    string sbShopC_ExclusivelySellFromStock = "0";

                    if (rdb_MultiUserOperation.Checked)
                    {
                        sbMutiuserOperation = "1";
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

                    if ((rdb_MultiUserOperation.Checked!= Program.OperationMode.MultiUser)
                        ||(chk_StockCheckAtStartup.Checked!= Program.OperationMode.StockCheckAtStartup)
                        || (chk_SingleUserLoginAsAdministrator.Checked != Program.OperationMode.SingleUserLoginAsAdministrator)
                        || (chk_ShopC_ExclusivelySellFromStock.Checked != Program.OperationMode.ShopC_ExclusivelySellFromStock))
                    {
                        Changed = true;
                    }

                   
                    if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, sbMutiuserOperation, "0", ref DBSettings_ID))
                    {
                        Program.OperationMode.MultiUser = rdb_MultiUserOperation.Checked;

                        if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.StockCheckAtStartup.Name, sbStockCheckAtStartup, "0", ref DBSettings_ID))
                        {
                            Program.OperationMode.StockCheckAtStartup = chk_StockCheckAtStartup.Checked;
                            if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.SingleUserLoginAsAdministrator.Name, sbSingleUserLoginAsAdministrator, "0", ref DBSettings_ID))
                            {
                                Program.OperationMode.SingleUserLoginAsAdministrator = chk_SingleUserLoginAsAdministrator.Checked;
                                if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.ShopC_ExclusivelySellFromStock.Name, sbShopC_ExclusivelySellFromStock, "0", ref DBSettings_ID))
                                {
                                    Program.OperationMode.ShopC_ExclusivelySellFromStock = chk_ShopC_ExclusivelySellFromStock.Checked;
                                    Close();
                                    DialogResult = DialogResult.OK;
                                    return true;
                                }
                            }
                        }
                    }
                }
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