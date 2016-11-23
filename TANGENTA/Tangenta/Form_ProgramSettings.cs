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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using TangentaDB;


namespace Tangenta
{
    public partial class Form_ProgramSettings : Form
    {
        private int default_language_ID = -1;
        private int newLanguage = -1;
        private usrc_Document m_usrc_Main;
        private bool bChanged = false;
        NavigationButtons.Navigation nav = null;
        private Form LogManager_dlg = null;

        public Form_ProgramSettings(usrc_Document usrc_Main,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            this.usrc_NavigationButtons1.Init(nav);
            lngRPM.sProgramSettings.Text(this);
            lngRPM.s_LogFile.Text(btn_LogFile);
            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_FullScreen.Text(chk_FullScreen);
            lngRPM.s_chk_AllowToEditText.Text(chk_AllowToEditText);
            lngRPM.s_ElectronicDevice_ID.Text(lbL_ElectronicDevice_ID);
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
            this.txt_ElectronicDevice_ID.Text = Properties.Settings.Default.ElectronicDevice_ID;
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

        void chk_AllowToEditText_CheckedChanged(object sender, EventArgs e)
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
                    XMessage.Box.Show(this, lngRPM.s_YouHaveChangedLanguageYouMustRestartProgramToUseNewLanguage, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                }
                if (bChanged)
                {
                    Properties.Settings.Default.ElectronicDevice_ID = this.txt_ElectronicDevice_ID.Text;
                    Properties.Settings.Default.Save();
                }
                if (LogManager_dlg != null)
                {
                    XMessage.Box.Show(this, lngRPM.s_CloseLogManagerDialog, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
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
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            do_Cancel();
                            nav.eExitResult = evt;
                            return;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            do_Cancel();
                            nav.eExitResult = evt;
                            return;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            if (do_OK())
                            {
                                nav.eExitResult = evt;
                            }
                            return;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            do_Cancel();
                            nav.eExitResult = evt;
                            return;
                    }
                    break;
            }
        }
    }
}
