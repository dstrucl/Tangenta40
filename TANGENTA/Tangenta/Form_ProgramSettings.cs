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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using TangentaDB;
using NavigationButtons;

namespace Tangenta
{
    public partial class Form_ProgramSettings : Form
    {
        private int default_language_ID = -1;
        private int newLanguage = -1;

        private object m_usrc_DocumentManX = null;

        private bool bChanged = false;
        private NavigationButtons.Navigation nav = null;
        private Form LogManager_dlg = null;
        private bool bDBSettingsChanged = false;

        public Form_ProgramSettings(NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            Init();
        }


        public Form_ProgramSettings(object xusrc_DocumentManX,NavigationButtons.Navigation xnav, SettingsUserValues xSettingsUserValues)
        {
            InitializeComponent();
            m_usrc_DocumentManX = xusrc_DocumentManX;
            nav = xnav;
            usrc_ShopsInuse1.SettingsUserValues = xSettingsUserValues;
            usrc_ShopsInuse1.Init();
            Init();

        }

        private void Init()
        {
            this.usrc_NavigationButtons1.Init(nav);
            lng.sProgramSettings.Text(this);
            lng.s_LogFile.Text(btn_LogFile);
            lng.s_Language.Text(lbl_Language);
            lng.s_FullScreen.Text(chk_FullScreen);
            lng.s_chk_AllowToEditText.Text(chk_AllowToEditText);
            lng.s_grp_ColorSettings.Text(grp_ColorSettings);
            lng.s_chk_MultipleUserLogin.Text(chk_MultipleUserLogin);
            lng.s_chk_ControlLayout_TouchScreen.Text(chk_ControlLayout_TouchScreen);
            lng.s_chk_UserWorkAreas.Text(chk_UseWorkAreas);
            lng.s_chk_RecordCashierActivity.Text(chk_RecordCashierActivity);
            lng.s_chk_ShowChangeDatabaseButtonAtStartup.Text(chk_ShowChangeDatabaseButtonAtStartup);

            lng.s_grp_AccessAuthentication.Text(grp_AccessAuthentication);
            lng.s_rdb_Autentification_None.Text(rdb_Authentification_None);
            lng.s_rdb_Autentification_Password.Text(rdb_Authentification_Password);
            lng.s_rdb_Autentification_PIN.Text(rdb_Authentification_PIN);
            lng.s_rdb_Autentification_RFID.Text(rdb_Authentification_RFID);
            lng.s_lbl_ExitTimeout.Text(lbl_ExitTimeout);
            lng.s_btn_UserSettings.Text(btn_UserSettings);

            nmUpDn_ExitTimeout.Value = Convert.ToDecimal(Properties.Settings.Default.timer_Login_MultiUser_Countdown);

            rdb_Authentification_None.Checked = (Properties.Settings.Default.AccessAuthentication == 0);
            rdb_Authentification_Password.Checked = (Properties.Settings.Default.AccessAuthentication == 1);
            rdb_Authentification_PIN.Checked = (Properties.Settings.Default.AccessAuthentication == 2);
            rdb_Authentification_RFID.Checked = (Properties.Settings.Default.AccessAuthentication == 3);
            if ((Properties.Settings.Default.AccessAuthentication < 0) || (Properties.Settings.Default.AccessAuthentication > 3))
            {
                LogFile.Error.Show("ERROR:Tangenta:ProgramSettings:Properties.Settings.Default.AccessAuthentication is not 0,1,2,3 it may not be " + Properties.Settings.Default.AccessAuthentication.ToString());
            }

            if (Program.OperationMode.MultiUser)
            {
                chk_MultipleUserLogin.Enabled = true;
                chk_MultipleUserLogin.Checked = Properties.Settings.Default.Login_MultipleUsers;
                grp_AccessAuthentication.Enabled = true;
            }
            else
            {
                grp_AccessAuthentication.Enabled = false;
                chk_MultipleUserLogin.Enabled = false;
                chk_MultipleUserLogin.Checked = false;
            }


            chk_ShowChangeDatabaseButtonAtStartup.Checked = Properties.Settings.Default.WaitToChangeDataBaseAtStartup;

            chk_RecordCashierActivity.Checked = Program.RecordCashierActivity;

            chk_UseWorkAreas.Checked = Program.UseWorkAreas;

            chk_ControlLayout_TouchScreen.Checked = Program.ControlLayout_TouchScreen;

            default_language_ID = DynSettings.LanguageID;
            newLanguage = default_language_ID;
            cmb_Language.DataSource = DynSettings.s_language.sTextArr;
            cmb_Language.SelectedIndex = DynSettings.LanguageID;
            cmb_Language.SelectedIndexChanged += cmb_Language_SelectedIndexChanged;

            DynSettings.AllowToEditText = Properties.Settings.Default.AllowToEditLanguageText;
            chk_AllowToEditText.Checked = DynSettings.AllowToEditText;
            chk_AllowToEditText.CheckedChanged += chk_AllowToEditText_CheckedChanged;
            chk_FullScreen.Checked = Properties.Settings.Default.FullScreen;
            chk_FullScreen.CheckedChanged += Chk_FullScreen_CheckedChanged;
            if (nav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
            {
                if (nav.m_Auto_NEXT != null)
                {
                    this.usrc_ShopsInuse1.chk_A_in_use.Checked = true;
                    this.usrc_ShopsInuse1.chk_B_in_use.Checked = true;
                    this.usrc_ShopsInuse1.chk_C_in_use.Checked = true;
                }
            }
            txt_ApplicationDataFolder.Text = Global.f.GetApplicationDataFolder();
            txt_GitSourceVersion.Text = LogFile.LogFile.VersionControlSourceVersion;
            this.usrc_SelectColorSheme1.ColorShemeChanged += Usrc_SelectColorSheme1_ColorShemeChanged;


        }

        private void Usrc_SelectColorSheme1_ColorShemeChanged()
        {
            if (m_usrc_DocumentManX is usrc_DocumentMan)
            {
                ((usrc_DocumentMan)this.m_usrc_DocumentManX).SetColor();
            }
            else if (m_usrc_DocumentManX is usrc_DocumentMan1366x768)
            {
                ((usrc_DocumentMan1366x768)this.m_usrc_DocumentManX).SetColor();
            }
        }

        private void Txt_ElectronicDevice_ID_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
        }

        private void Chk_FullScreen_CheckedChanged(object sender, EventArgs e)
        {
            bChanged = true;
            Properties.Settings.Default.FullScreen = chk_FullScreen.Checked;
            if (Properties.Settings.Default.FullScreen)
            {
                Program.MainForm.WindowState= FormWindowState.Maximized;
                Program.MainForm.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                Program.MainForm.FormBorderStyle = FormBorderStyle.Sizable;
            }

        }

        private void chk_AllowToEditText_CheckedChanged(object sender, EventArgs e)
        {
            bChanged = true;
            DynSettings.AllowToEditText = chk_AllowToEditText.Checked;
            Properties.Settings.Default.AllowToEditLanguageText = DynSettings.AllowToEditText;
        }

        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            bChanged = true;
            newLanguage = cmb_Language.SelectedIndex;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_LogFile_Click(object sender, EventArgs e)
        {
           LogManager_dlg = LogFile.LogFile.LogManager(this,false);
        }


        private void usrc_Printer1_Load(object sender, EventArgs e)
        {

        }

      

        private bool do_OK()
        {
            if (usrc_ShopsInuse1.do_OK())
            {

                if (Program.OperationMode.MultiUser)
                {
                    if (Properties.Settings.Default.Login_MultipleUsers != chk_MultipleUserLogin.Checked)
                    {
                        Properties.Settings.Default.Login_MultipleUsers = chk_MultipleUserLogin.Checked;
                        bChanged = true;
                    }
                }
                if (chk_RecordCashierActivity.Checked !=  Properties.Settings.Default.RecordCashierActivity)
                {
                    Properties.Settings.Default.RecordCashierActivity = chk_RecordCashierActivity.Checked;
                    bChanged = true;
                }
                if (chk_UseWorkAreas.Checked != Properties.Settings.Default.UseWorkAreas)
                {
                    Properties.Settings.Default.UseWorkAreas = chk_UseWorkAreas.Checked;
                    bChanged = true;
                }

                if (chk_ShowChangeDatabaseButtonAtStartup.Checked != Properties.Settings.Default.WaitToChangeDataBaseAtStartup)
                {
                    Properties.Settings.Default.WaitToChangeDataBaseAtStartup = chk_ShowChangeDatabaseButtonAtStartup.Checked;
                    bChanged = true;
                }


                if (Properties.Settings.Default.Login_MultipleUsers)
                {
                    if (nmUpDn_ExitTimeout.Value != Convert.ToDecimal(Properties.Settings.Default.timer_Login_MultiUser_Countdown))
                    {
                        Properties.Settings.Default.timer_Login_MultiUser_Countdown = Convert.ToInt32(nmUpDn_ExitTimeout.Value);
                        bChanged = true;
                    }

                    if (rdb_Authentification_None.Checked && (Properties.Settings.Default.AccessAuthentication != 0))
                    {
                        Properties.Settings.Default.AccessAuthentication = 0;
                        bChanged = true;
                    }
                    if (rdb_Authentification_Password.Checked && (Properties.Settings.Default.AccessAuthentication != 1))
                    {
                        Properties.Settings.Default.AccessAuthentication = 1;
                        bChanged = true;
                    }
                    if (rdb_Authentification_PIN.Checked && (Properties.Settings.Default.AccessAuthentication != 2))
                    {
                        Properties.Settings.Default.AccessAuthentication = 2;
                        bChanged = true;
                    }

                    if (rdb_Authentification_RFID.Checked && (Properties.Settings.Default.AccessAuthentication != 3))
                    {
                        Properties.Settings.Default.AccessAuthentication = 3;
                        bChanged = true;
                    }
                }


                if (Properties.Settings.Default.ControlLayout_TouchScreen != chk_ControlLayout_TouchScreen.Checked)
                {
                    bChanged = true;
                    Properties.Settings.Default.ControlLayout_TouchScreen = chk_ControlLayout_TouchScreen.Checked;
                }


                if (newLanguage != default_language_ID)
                {
                    bChanged = true;
                    Properties.Settings.Default.LanguageID = newLanguage;
                }

                if (bChanged)
                {
                    Properties.Settings.Default.Save();
                }

                if ((bChanged || bDBSettingsChanged)&&(nav.m_eButtons== Navigation.eButtons.OkCancel))
                {
                    XMessage.Box.Show(this, lng.s_YouHaveChangedSettingsYouMustRestartProgramToUseNewSettings, "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                if (LogManager_dlg != null)
                {
                    XMessage.Box.Show(this, lng.s_CloseLogManagerDialog, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    LogManager_dlg.Show();
                    LogManager_dlg.Focus();
                    return false;
                }
                else
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void do_Cancel()
        {
            if (LogManager_dlg != null)
            {
                LogManager_dlg.Close();
            }
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = Navigation.eEvent.NOTHING;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            if (!do_OK())
                            {
                                nav.eExitResult = Navigation.eEvent.NOTHING;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            return;
                    }
                    break;
            }
        }

        private void btn_DBSettings_Click(object sender, EventArgs e)
        {
            NavigationButtons.Navigation nav_FormDBSettings = new Navigation(null);
            nav_FormDBSettings.bDoModal = true;
            nav_FormDBSettings.m_eButtons = Navigation.eButtons.OkCancel;
            nav_FormDBSettings.eExitResult = Navigation.eEvent.NOTHING;
            nav_FormDBSettings.ChildDialog = new Form_DBSettings(nav_FormDBSettings, Program.AdministratorLockedPassword);
            nav_FormDBSettings.ShowDialog();
            if (nav_FormDBSettings.eExitResult == Navigation.eEvent.OK)
            {
                bDBSettingsChanged = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).Changed;
                Program.AdministratorLockedPassword = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).AdministratorLockedPassword;

                Program.OperationMode.MultiUser = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).MultiuserOperationWithLogin;
                Program.OperationMode.SingleUserLoginAsAdministrator = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).SingleUserLoginAsAdministrator;
                Program.OperationMode.StockCheckAtStartup = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).StockCheckAtStartup;
                Program.OperationMode.ShopC_ExclusivelySellFromStock = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).ShopC_ExclusivelySellFromStock;
                Program.OperationMode.MultiCurrency = ((Form_DBSettings)nav_FormDBSettings.ChildDialog).MultiCurrencyOperation;
            }
        }

        private void chk_MultipleUserLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_MultipleUserLogin.Checked)
            {
                grp_AccessAuthentication.Enabled = true;
            }
            else
            {
                grp_AccessAuthentication.Enabled = false;
            }
        }

        private void btn_UserSettings_Click(object sender, EventArgs e)
        {
            LoginControl.LMOUser xLMO_User = null;
            if (m_usrc_DocumentManX is usrc_DocumentMan)
            {
                xLMO_User = ((usrc_DocumentMan)this.m_usrc_DocumentManX).DocM.m_LMOUser;
            }
            else if (m_usrc_DocumentManX is usrc_DocumentMan1366x768)
            {
                xLMO_User = ((usrc_DocumentMan1366x768)this.m_usrc_DocumentManX).DocM.m_LMOUser;
            }
            if (xLMO_User!=null)
            { 
                Form_SettingsUsers frm_settingsuser = new Form_SettingsUsers(xLMO_User);
                frm_settingsuser.Init();
                frm_settingsuser.ShowDialog(this);
            }
        }

        private void btn_IdleSettings_Click(object sender, EventArgs e)
        {
            Form pParentForm = null;
            if (m_usrc_DocumentManX is usrc_DocumentMan)
            {
                pParentForm = Global.f.GetParentForm((usrc_DocumentMan)m_usrc_DocumentManX);
            }
            else if (m_usrc_DocumentManX is usrc_DocumentMan1366x768)
            {
                pParentForm = Global.f.GetParentForm((usrc_DocumentMan1366x768)m_usrc_DocumentManX);
            }

            if (pParentForm != null)
            {
                Form_IdleSettings frm_idlesettings = new Form_IdleSettings(((Form_Document)pParentForm).loginControl1.IdleCtrl);
                frm_idlesettings.ShowDialog(this);
            }
        }
    }
}
