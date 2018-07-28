#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class Form_Settings : Form
    {
        private FVI_SLO m_FVI_SLO = null;

        //public string certificateFileName = null;
        //public string CertPass = null;
        //public string fursWebServiceURL = null;
        //public string fursXmlNamespace = null;
        public int timeOutInSec = -1;
        NavigationButtons.Navigation nav = null;

        public Form_Settings(FVI_SLO x_usrc_FVI_SLO,NavigationButtons.Navigation xnav,ref bool Reset2FactorySettings_FiscalVerification_DLL)
        {
            InitializeComponent();
            nav = xnav;
            m_FVI_SLO = x_usrc_FVI_SLO;

            if (Reset2FactorySettings_FiscalVerification_DLL)
            {
                m_FVI_SLO.Settings_Reset(this);
                Reset2FactorySettings_FiscalVerification_DLL = false;
            }

            usrc_NavigationButtons1.Init(nav);
            Properties.Settings.Default.timeOutInSec = SetValue(nm_UpDown_timeOutInSec,Properties.Settings.Default.timeOutInSec);
            Properties.Settings.Default.timeToShowSuccessfulFURSResult = SetValue(this.nm_TimeToShowSuccessfulFURS_Transaction, Properties.Settings.Default.timeToShowSuccessfulFURSResult);
            Properties.Settings.Default.QRImageWidth = SetValue(this.nm_QRSizeWidth, Properties.Settings.Default.QRImageWidth);
            Properties.Settings.Default.Last_SalesBookInvoice_SetNumber = SetValue(nm_UpDn_SalesBookInvoice_Last_SetNumber, Properties.Settings.Default.Last_SalesBookInvoice_SetNumber);
            Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber = SetValue(nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook, Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber);
            Properties.Settings.Default.Save();

            lng.s_Furs_Environment.Text(rdb_FURS_Environment);
            lng.s_Furs_Test_Environment.Text(rdb_FURS_TEST_Environment);

            this.rdb_FURS_TEST_Environment.Checked = false;
            this.rdb_FURS_Environment.Checked = false;
            this.usrc_FURS_environment_settings.Init(false, m_FVI_SLO);
            this.usrc_FURS_environment_settings_TEST.Init(true, m_FVI_SLO);
            this.txt_SalesBookInvoice_Current_SerialNumber.Text = Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber;
            this.txt_SalesBookInvoice_SerialNumber_Format.Text = Properties.Settings.Default.SalesBookInvoice_SerialNumber_RegularExpression_pattern;


            if (m_FVI_SLO.FursTESTEnvironment)
            {
                this.rdb_FURS_TEST_Environment.Checked = true;
                this.usrc_FURS_environment_settings.Enabled = false;
                this.usrc_FURS_environment_settings_TEST.Enabled = true;
            }
            else
            {
                this.rdb_FURS_Environment.Checked = true;
                this.usrc_FURS_environment_settings.Enabled = true;
                this.usrc_FURS_environment_settings_TEST.Enabled = false;
            }

            rdb_FURS_TEST_Environment.CheckedChanged += Rdb_FURS_TEST_Environment_CheckedChanged;
            rdb_FURS_Environment.CheckedChanged += Rdb_FURS_Environment_CheckedChanged;
            chk_DebugAndTest.Checked = Properties.Settings.Default.DEBUG;
            chk_DebugAndTest.CheckedChanged += Chk_DebugAndTest_CheckedChanged;
        }

        private int SetValue(NumericUpDown nm_UpDn, int i)
        {
            decimal d = Convert.ToDecimal(i);
            if (nm_UpDn.Minimum > d)
            {
                d = nm_UpDn.Value = nm_UpDn.Minimum;
            }
            else
            {
                if (nm_UpDn.Maximum < d)
                {
                    d = nm_UpDn.Value = nm_UpDn.Maximum;
                }
                else
                {
                    nm_UpDn.Value = d;
                }
            }
            return Convert.ToInt32(d);
        }

        private void Rdb_FURS_Environment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FURS_Environment.Checked)
            {
                m_FVI_SLO.FursTESTEnvironment = false;
                this.usrc_FURS_environment_settings.Enabled = true;
                this.usrc_FURS_environment_settings_TEST.Enabled = false;
                m_FVI_SLO.LoadSettingsValues(false);

            }
        }

        private void Rdb_FURS_TEST_Environment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FURS_TEST_Environment.Checked)
            {
                m_FVI_SLO.FursTESTEnvironment = true;
                this.usrc_FURS_environment_settings.Enabled = false;
                this.usrc_FURS_environment_settings_TEST.Enabled = true;
                m_FVI_SLO.LoadSettingsValues(true);
            }
        }

        private void Chk_DebugAndTest_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DebugAndTest.Checked != Properties.Settings.Default.DEBUG)
            {
                Properties.Settings.Default.DEBUG = chk_DebugAndTest.Checked;
                Properties.Settings.Default.Save();
            }
            m_FVI_SLO.DEBUG = chk_DebugAndTest.Checked;

        }

       

        private void Do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        public void Do_OK()
        {
            this.usrc_FURS_environment_settings.Save();
            this.usrc_FURS_environment_settings_TEST.Save();
            Properties.Settings.Default.timeOutInSec = Convert.ToInt32(this.nm_UpDown_timeOutInSec.Value);
            Properties.Settings.Default.timeToShowSuccessfulFURSResult = Convert.ToInt32(this.nm_TimeToShowSuccessfulFURS_Transaction.Value);
            Properties.Settings.Default.QRImageWidth = Convert.ToInt32(this.nm_QRSizeWidth.Value);

            Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber = this.txt_SalesBookInvoice_Current_SerialNumber.Text;
            Properties.Settings.Default.Last_SalesBookInvoice_SetNumber = Convert.ToInt32(nm_UpDn_SalesBookInvoice_Last_SetNumber.Value);
            Properties.Settings.Default.SalesBookInvoice_SerialNumber_RegularExpression_pattern = this.txt_SalesBookInvoice_SerialNumber_Format.Text;
            Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber = Convert.ToInt32(this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Value);
            Properties.Settings.Default.Save();
            timeOutInSec = Properties.Settings.Default.timeOutInSec;
            bool bTest = Properties.Settings.Default.fursTEST_Environment;
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                            Do_OK();
                            return;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            Do_Cancel();
                            return;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            Do_Cancel();
                            return;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            Do_OK();
                            return;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            Do_Cancel();
                            return;
                    }
                    break;
            }
        }
    }
}
