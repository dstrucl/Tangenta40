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
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;
using InvoiceDB;


namespace Tangenta
{
    public partial class Form_Settings : Form
    {
        private int default_language_ID = -1;
        private int newLanguage = -1;
        private usrc_Main m_usrc_Main;

        public Form_Settings()
        {

        }

        public Form_Settings(usrc_Main usrc_Main)
        {
            InitializeComponent();
            lngRPM.s_CodeTables.Text(btn_CodeTables);
            lngRPM.s_LogFile.Text(btn_LogFile);
            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_FullScreen.Text(chk_FullScreen);
            lngRPM.s_Shops_In_Use.Text(btn_Shops_in_use);
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
            m_usrc_Main = usrc_Main;
        }

        private void Chk_FullScreen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FullScreen = chk_FullScreen.Checked;
            Properties.Settings.Default.Save();
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
            DynSettings.AllowToEditText = chk_AllowToEditText.Checked;
            Properties.Settings.Default.AllowToEditLanguageText = DynSettings.AllowToEditText;
            Properties.Settings.Default.Save();

        }










        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            newLanguage = cmb_Language.SelectedIndex;
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newLanguage != default_language_ID)
            {
                Properties.Settings.Default.LanguageID = newLanguage;
                Properties.Settings.Default.Save();
                XMessage.Box.Show(this, lngRPM.s_YouHaveChangedLanguageYouMustRestartProgramToUseNewLanguage, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_Shops_in_use_Click(object sender, EventArgs e)
        {
            Form_ShopsInUse frm_shops_in_use = new Form_ShopsInUse(m_usrc_Main);
            frm_shops_in_use.ShowDialog();
        }

        private void btn_LogFile_Click(object sender, EventArgs e)
        {
            LogFile.LogFile.LogManager();
        }

        private void BtnSetDefaulViewSettings_Click(object sender, EventArgs e)
        {
    
           Form_Main mform = (Form_Main)m_usrc_Main.Parent;
            mform.SetSplitContainerPositions(false,ref Program.ListOfAllSplitConatinerControls,Program.SplitConatinerControlsDefaulValues);
        }

        private void usrc_Printer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            Form_CodeTables fct_dlg = new Form_CodeTables();
            fct_dlg.ShowDialog();
        }
    }
}
