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
        private usrc_FVI_SLO m_usrc_FVI_SLO = null;

        //public string certificateFileName = null;
        //public string CertPass = null;
        //public string fursWebServiceURL = null;
        //public string fursXmlNamespace = null;
        public int timeOutInSec = -1;


        public Form_Settings(usrc_FVI_SLO x_usrc_FVI_SLO)
        {
            InitializeComponent();

            try
            {
                m_usrc_FVI_SLO = x_usrc_FVI_SLO;

                lngRPM.s_Furs_Environment.Text(rdb_FURS_Environment);
                lngRPM.s_Furs_Test_Environment.Text(rdb_FURS_TEST_Environment);

                this.nm_UpDown_timeOutInSec.Value = Convert.ToDecimal(Properties.Settings.Default.timeOutInSec);
                this.nm_TimeToShoqSuccessfulFURS_Transaction.Value = Convert.ToDecimal(Properties.Settings.Default.timeToShowSuccessfulFURSResult);
                this.nm_QRSizeWidth.Value = Convert.ToDecimal(Properties.Settings.Default.QRImageWidth);
                this.rdb_FURS_TEST_Environment.Checked = false;
                this.rdb_FURS_Environment.Checked = false;
                this.usrc_FURS_environment_settings.Init(false, m_usrc_FVI_SLO);
                this.usrc_FURS_environment_settings_TEST.Init(true, m_usrc_FVI_SLO);
                this.txt_SalesBookInvoice_Current_SerialNumber.Text = Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber;
                this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Value = Convert.ToDecimal(Properties.Settings.Default.Last_SalesBookInvoice_SetNumber);
                this.txt_SalesBookInvoice_SerialNumber_Format.Text = Properties.Settings.Default.SalesBookInvoice_SerialNumber_RegularExpression_pattern;
                this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Value = Convert.ToDecimal(Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber);

                if (Properties.Settings.Default.fursTEST_Environment)
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
            catch 
            { }
        }

        private void Rdb_FURS_Environment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FURS_Environment.Checked)
            {
                Properties.Settings.Default.fursTEST_Environment = false;
                this.usrc_FURS_environment_settings.Enabled = true;
                this.usrc_FURS_environment_settings_TEST.Enabled = false;
                m_usrc_FVI_SLO.LoadSettingsValues(false);

            }
        }

        private void Rdb_FURS_TEST_Environment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FURS_TEST_Environment.Checked)
            {
                Properties.Settings.Default.fursTEST_Environment = true;
                this.usrc_FURS_environment_settings.Enabled = false;
                this.usrc_FURS_environment_settings_TEST.Enabled = true;
                m_usrc_FVI_SLO.LoadSettingsValues(true);
            }
        }

        private void Chk_DebugAndTest_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DebugAndTest.Checked != Properties.Settings.Default.DEBUG)
            {
                Properties.Settings.Default.DEBUG = chk_DebugAndTest.Checked;
                Properties.Settings.Default.Save();
            }
            m_usrc_FVI_SLO.DEBUG = chk_DebugAndTest.Checked;

        }

       

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        public void btn_OK_Click(object sender, EventArgs e)
        {
            this.usrc_FURS_environment_settings.Save();
            this.usrc_FURS_environment_settings_TEST.Save();
            Properties.Settings.Default.timeOutInSec = Convert.ToInt32(this.nm_UpDown_timeOutInSec.Value);
            Properties.Settings.Default.timeToShowSuccessfulFURSResult = Convert.ToInt32(this.nm_TimeToShoqSuccessfulFURS_Transaction.Value);
            Properties.Settings.Default.QRImageWidth = Convert.ToInt32(this.nm_QRSizeWidth.Value);

            Properties.Settings.Default.Last_SalesBookInvoice_SerialNumber = this.txt_SalesBookInvoice_Current_SerialNumber.Text;
            Properties.Settings.Default.Last_SalesBookInvoice_SetNumber = Convert.ToInt32(nm_UpDn_SalesBookInvoice_Last_SetNumber.Value);
            Properties.Settings.Default.SalesBookInvoice_SerialNumber_RegularExpression_pattern = this.txt_SalesBookInvoice_SerialNumber_Format.Text;
            Properties.Settings.Default.MAX_SalesBookInvoice_SetNumber = Convert.ToInt32(this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Value);
            Properties.Settings.Default.Save();


            //certificateFileName = Properties.Settings.Default.furscertificateFileName;
            //CertPass = Properties.Settings.Default.fursCertPass;
            //fursWebServiceURL = Properties.Settings.Default.fursWebServiceURL;
            //fursXmlNamespace = Properties.Settings.Default.fursXmlNamespace;
            timeOutInSec = Properties.Settings.Default.timeOutInSec;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
