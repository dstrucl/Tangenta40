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
        public bool MultiuserOperationWithLogin { get { return chk_MultiUserOperation.Checked; } }
        public bool StockCheckAtStartup { get {return chk_StockCheckAtStartup.Checked; } }

        public Form_DBSettings(NavigationButtons.Navigation xnav,string AdministratorLockedPassword, bool bMultiuserOperation,bool bStockCheckAtStartup)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_DataBaseVersion.Text(lbl_DataBaseVersion, MyDataBase_Tangenta.VERSION);
            lng.s_Administrator_password.Text(lbl_Administrator_Password);
            lng.s_MultiuserOperationWithLogin.Text(chk_MultiUserOperation);
            lng.s_StockCheckAtStartup.Text(chk_StockCheckAtStartup);
            if (AdministratorLockedPassword == null)
            {
                this.usrc_Password1.Text =Password.Password.LockPassword("12345");
            }
            else
            {
                this.usrc_Password1.Text = AdministratorLockedPassword;
            }
            chk_MultiUserOperation.Checked = bMultiuserOperation;
            chk_StockCheckAtStartup.Checked = bStockCheckAtStartup;
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
                    if (chk_MultiUserOperation.Checked)
                    {
                        sbMutiuserOperation = "1";
                    }
                    if (chk_StockCheckAtStartup.Checked)
                    {
                        sbStockCheckAtStartup = "1";
                    }
                    if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, sbMutiuserOperation, "0", ref DBSettings_ID))
                    {
                        if (fs.WriteDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.MultiUserOperation.Name, sbStockCheckAtStartup, "0", ref DBSettings_ID))
                        {
                            Close();
                            DialogResult = DialogResult.OK;
                            return true;
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
    }
}