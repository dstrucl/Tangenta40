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
        private usrc_DocumentMan m_usrc_Main;
        private bool bChanged = false;
        private NavigationButtons.Navigation nav = null;
        private Form LogManager_dlg = null;
        private bool bDBSettingsChanged = false;

        public Form_ProgramSettings(usrc_DocumentMan usrc_Main,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            this.usrc_NavigationButtons1.Init(nav);
            lng.sProgramSettings.Text(this);
            lng.s_LogFile.Text(btn_LogFile);
            lng.s_Language.Text(lbl_Language);
            lng.s_FullScreen.Text(chk_FullScreen);
            lng.s_chk_AllowToEditText.Text(chk_AllowToEditText);
            lng.s_ElectronicDevice_ID.Text(lbL_ElectronicDevice_ID);
            lng.s_grp_ColorSettings.Text(grp_ColorSettings);
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
            if (GlobalData.ElectronicDevice_Name==null)
            {
                GlobalData.ElectronicDevice_Name = "1";
            }
            this.txt_ElectronicDevice_ID.Text = GlobalData.ElectronicDevice_Name;
            this.txt_ElectronicDevice_ID.TextChanged += Txt_ElectronicDevice_ID_TextChanged;
            m_usrc_Main = usrc_Main;
            if (nav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
            {
                if (nav.m_Auto_NEXT != null)
                {
                    this.usrc_ShopsInuse1.chk_A_in_use.Checked = true;
                    this.usrc_ShopsInuse1.chk_B_in_use.Checked = true;
                    this.usrc_ShopsInuse1.chk_C_in_use.Checked = true;
                }
            }
            txt_ApplicationDataFolder.Text = StaticLib.Func.GetApplicationDataFolder();
            txt_GitSourceVersion.Text = LogFile.LogFile.VersionControlSourceVersion;
            this.usrc_SelectColorSheme1.ColorShemeChanged += Usrc_SelectColorSheme1_ColorShemeChanged;

        }

        private void Usrc_SelectColorSheme1_ColorShemeChanged()
        {
            this.m_usrc_Main.SetColor();
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
                if (newLanguage != default_language_ID)
                {
                    bChanged = true;
                    Properties.Settings.Default.LanguageID = newLanguage;
                
                }
                if (bChanged)
                {
                    if (txt_ElectronicDevice_ID.Text.Length==0)
                    {
                        XMessage.Box.Show(this,lng.s_ElectronicDevice_Name_is_not_defined,MessageBoxIcon.Warning);
                        this.txt_ElectronicDevice_ID.Focus();
                        return false;
                    }
                    f_Atom_ElectronicDevice.Get(this.txt_ElectronicDevice_ID.Text, null, ref GlobalData.Atom_ElectronicDevice_ID);
                    f_Atom_ElectronicDevice.Get(ref GlobalData.ElectronicDevice_Name,ref GlobalData.ElectronicDevice_Description, ref GlobalData.Atom_ElectronicDevice_ID);
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
    }
}
